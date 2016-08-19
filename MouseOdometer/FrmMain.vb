Imports System.ComponentModel
Imports Gma.System.MouseKeyHook
Imports MouseOdometer.Helpers.LengthConverter
Imports MouseOdometer.Helpers
Public Class FrmMain

#Region "Variables"

    ''' <summary>
    ''' Object for hooking mouse (and keyboard)
    ''' </summary>
    Private m_GlobalHook As IKeyboardMouseEvents

    ''' <summary>
    ''' Last mouse point
    ''' </summary>
    Private lastMousePoint As Point = New Point(-999, 999)

    ''' <summary>
    ''' Objecto to convert meters to user settings units
    ''' </summary>
    Private myConverter As LengthConverter

    ''' <summary>
    ''' Physical DPI to calculate mouse move length
    ''' </summary>
    Private _physicalDPI As Double

    ''' <summary>
    ''' Instead saving data EACH time on mouse movement, we use a timer to save the data to avoid intensive IO operations to HDD
    ''' </summary>
    Private WithEvents TIMER_SaveToFile As New Timer

#End Region

#Region "Constructor"

    Public Sub New()

        InitializeComponent()

        Me.WindowState = FormWindowState.Minimized
        Me.ShowInTaskbar = False

        ' User settings first time ----------------------------------------------------------------
        If (IO.File.Exists(AppGlobals.SETTINGS_FILE)) Then
            AppGlobals.Settings = XMLserialization.Deserialize(Of SettingsModel)(AppGlobals.SETTINGS_FILE)
        Else
            AppGlobals.Settings = New SettingsModel()
            Dim f As SettingsUI = New SettingsUI()
            If (f.ShowDialog() = DialogResult.Cancel) Then
                End
            End If
        End If

        If (IsNothing(AppGlobals.Settings.DateCapturedSince)) Then
            AppGlobals.Settings.DateCapturedSince = Now
            AppGlobals.Settings.MetersCounter = 0
        End If


        ' Calculate physical DPI for futher use:
        _physicalDPI = Helpers.ScreenToLength.PhysicalDPI(AppGlobals.Settings.Monitor.Inches,
                                                          AppGlobals.Settings.Monitor.Width,
                                                          AppGlobals.Settings.Monitor.Height)

        ' Initialize out length converter:
        myConverter = New LengthConverter(AppGlobals.Settings.Measure)

        ' Hook mouse
        Suscribe()

        NotifyIcon1.Icon = My.Resources.NotifyIconICO
    End Sub

#End Region

#Region "Mouse Hook Stuff"

    Private Sub Suscribe()
        m_GlobalHook = Hook.GlobalEvents()
        AddHandler m_GlobalHook.MouseMove, AddressOf OnGlobalHookMouseMove
        AddHandler m_GlobalHook.MouseDownExt, AddressOf OnGlobalhookMouseDownExt
    End Sub

    Private Sub Unsuscribe()
        m_GlobalHook.Dispose()
    End Sub

    Private Sub OnGlobalhookMouseDownExt(sender As Object, e As MouseEventExtArgs)
        If (e.Button = MouseButtons.Right) Then AppGlobals.Settings.RightClickCounter += 1
        If (e.Button = MouseButtons.Left) Then AppGlobals.Settings.LeftClickCounter += 1
        RightButtonToolStripMenuItem.Text = String.Format("Right clicks: {0}", AppGlobals.Settings.RightClickCounter)
        LeftButtonToolStripMenuItem.Text = String.Format("Left clicks: {0}", AppGlobals.Settings.LeftClickCounter)
    End Sub

    Private Sub OnGlobalHookMouseMove(sender As Object, e As MouseEventArgs)
        If (lastMousePoint.X <> -999) Then

            Dim p As Point
            p.X = e.X
            p.Y = e.Y

            ' Calculate distance (millimeters) between last mouse point and current mouse point
            Dim milimeters As Double = Helpers.ScreenToLength.GetDistancePointsInMillimeters(lastMousePoint, p, _physicalDPI)

            ' The current point becomes lastMousePoint for next iteration
            lastMousePoint = p

            ' We store distance in meters, independent to user settings measure
            Dim meters As Double = milimeters * 0.001

            AppGlobals.Settings.MetersCounter += meters

            ' Print to NotifyIcon text and context menu text total distance and mouseclicks
            NotifyIcon1.Text = String.Format("{0} {1}", myConverter.Converter.Value(AppGlobals.Settings.MetersCounter), myConverter.ToString())
            TotalToolStripMenuItem.Text = NotifyIcon1.Text

            SinceToolStripMenuItem.Text = String.Format("Since {0}:", AppGlobals.Settings.DateCapturedSince.Value.ToString("d"))

            TIMER_SaveToFile.Interval = 5000

            ' Trick: We re-trigger the timer everytime in mousemove 
            TIMER_SaveToFile.Enabled = False
            TIMER_SaveToFile.Enabled = True
        Else
            lastMousePoint = New Point(e.X, e.Y)
        End If

    End Sub

#End Region

#Region "Form Events: Load and Closing"

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NotifyIcon1.ShowBalloonTip(1000, Application.ProductName, "Running", ToolTipIcon.Info)
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        NotifyIcon1.Icon = Nothing
        NotifyIcon1.Dispose()

        If (TIMER_SaveToFile.Enabled) Then
            UpdateFile()
        End If
        TIMER_SaveToFile.Dispose()

        Unsuscribe()
    End Sub

#End Region

#Region "Context Menu"

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim f As SettingsUI = New SettingsUI()

        If (f.ShowDialog() = DialogResult.OK) Then
            myConverter = New LengthConverter(AppGlobals.Settings.Measure)
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

#End Region

    Private Sub UpdateFile()
        Debug.Print("Updating file...")
        TIMER_SaveToFile.Enabled = False
        Try
            XMLserialization.Serialize(AppGlobals.SETTINGS_FILE, AppGlobals.Settings)
        Catch ex As Exception
            Unsuscribe()
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Suscribe()
        End Try
    End Sub

    Private Sub TIMER_SaveToFile_Tick(sender As Object, e As EventArgs) Handles TIMER_SaveToFile.Tick
        UpdateFile()
    End Sub

End Class
