Imports MouseOdometer.Helpers
Imports MouseOdometer.Helpers.LengthConverter

''' <summary>
''' Form for user settings
''' </summary>
Public Class SettingsUI

#Region "Variables"

    Private _lSettings As SettingsModel

    Private Class tProvider
        Public Property Provider As Helpers.LengthConverter.Providers
        Public Property Name As String
    End Class
    Private providers As List(Of tProvider)

    Private bCboMeasureUnitsSelectedIndexChanged As Boolean

#End Region

#Region "Constructor"

    Public Sub New()

        InitializeComponent()

        Me.Icon = My.Resources.NotifyIconICO

        Me.Text = String.Format("{0} - Settings", Application.ProductName)

        If (IO.File.Exists(AppGlobals.SETTINGS_FILE)) Then
            _lSettings = XMLserialization.Deserialize(Of SettingsModel)(AppGlobals.SETTINGS_FILE)
        Else
            _lSettings = AppGlobals.Settings
        End If

        ' Display user settings in textboxes
        If (_lSettings.Monitor.Inches IsNot Nothing) Then Z80Txt_MonitorInches.Text = _lSettings.Monitor.Inches
        If (_lSettings.Monitor.Width IsNot Nothing) Then Z80Txt_MonitorWidthPixels.Text = _lSettings.Monitor.Width
        If (_lSettings.Monitor.Height IsNot Nothing) Then Z80Txt_MonitorHeightPixels.Text = _lSettings.Monitor.Height

        ' Fill combobox with converter units available --------------------------------------------
        providers = New List(Of tProvider)()
        Dim items As Array = System.Enum.GetValues(GetType(Helpers.LengthConverter.Providers))
        For Each p In items
            Dim temp As LengthConverter = New LengthConverter(p)
            Dim addProvider As tProvider = New tProvider() With {.Provider = p, .Name = temp.ToString()}
            providers.Add(addProvider)
        Next

        CboMeasureUnits.Items.Clear()
        CboMeasureUnits.DataSource = providers
        CboMeasureUnits.ValueMember = "Provider"
        CboMeasureUnits.DisplayMember = "Name"

        CboMeasureUnits.SelectedIndex = -1
        bCboMeasureUnitsSelectedIndexChanged = True
        Dim selectedProvider = providers.Find(Function(c) c.Provider = _lSettings.Measure).Provider
        CboMeasureUnits.SelectedValue = selectedProvider

    End Sub

#End Region

#Region "Unit combobox"

    Private Sub CboMeasureUnits_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboMeasureUnits.SelectedIndexChanged
        If (Not bCboMeasureUnitsSelectedIndexChanged) Then Exit Sub

        Dim provider As Helpers.LengthConverter.Providers = CboMeasureUnits.SelectedValue
        _lSettings.Measure = provider

    End Sub

#End Region

#Region "Validation user inputs"

    ''' <summary>
    ''' Returns true if settings are correct
    ''' </summary>
    ''' <returns></returns>
    Private Function CheckSettings() As Boolean
        If (String.IsNullOrWhiteSpace(Z80Txt_MonitorInches.Text)) Then
            MessageBox.Show("Monitor inches missing", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Z80Txt_MonitorInches.Focus()
            Return False
        End If
        If (Not String.IsNullOrWhiteSpace(Z80Txt_MonitorWidthPixels.Text)) Then
            Dim v = Integer.Parse(Z80Txt_MonitorWidthPixels.Text)
            If (v = 0) Then
                MessageBox.Show("0 width pixels!!! Really?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Z80Txt_MonitorWidthPixels.Focus()
                Return False
            End If
        End If
        If (Not String.IsNullOrWhiteSpace(Z80Txt_MonitorHeightPixels.Text)) Then
            Dim v = Integer.Parse(Z80Txt_MonitorHeightPixels.Text)
            If (v = 0) Then
                MessageBox.Show("0 height pixels!!! Really?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Z80Txt_MonitorHeightPixels.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub AssignNewSettings()
        AppGlobals.Settings.Measure = _lSettings.Measure
        AppGlobals.Settings.Monitor.Inches = CDec(Z80Txt_MonitorInches.Text)
        If (Not String.IsNullOrWhiteSpace(Z80Txt_MonitorWidthPixels.Text)) Then AppGlobals.Settings.Monitor.Width = CInt(Z80Txt_MonitorWidthPixels.Text)
        If (Not String.IsNullOrWhiteSpace(Z80Txt_MonitorHeightPixels.Text)) Then AppGlobals.Settings.Monitor.Height = CInt(Z80Txt_MonitorHeightPixels.Text)
    End Sub

#End Region

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        If (CheckSettings()) Then
            If (MessageBox.Show("Are you sure to change the settings?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes) Then
                Try
                    AssignNewSettings()
                    XMLserialization.Serialize(AppGlobals.SETTINGS_FILE, AppGlobals.Settings)
                    Me.DialogResult = DialogResult.OK
                Catch ex As Exception
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Private Sub BtnSetLegthToZero_Click(sender As Object, e As EventArgs) Handles BtnSetLegthToZero.Click
        If (MessageBox.Show("Are you sure to reset odometer buttons and counter length?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes) Then
            AppGlobals.Settings.MetersCounter = 0
            AppGlobals.Settings.LeftClickCounter = 0
            AppGlobals.Settings.RightClickCounter = 0
            AppGlobals.Settings.DateCapturedSince = Now
            Try
                XMLserialization.Serialize(AppGlobals.SETTINGS_FILE, AppGlobals.Settings)
                Me.DialogResult = DialogResult.OK
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

End Class