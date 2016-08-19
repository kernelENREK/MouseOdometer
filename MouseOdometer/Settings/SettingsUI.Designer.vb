<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsUI
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CboMeasureUnits = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnSetLegthToZero = New System.Windows.Forms.Button()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.Z80Txt_MonitorHeightPixels = New MouseOdometer.Z80_TextBox()
        Me.Z80Txt_MonitorWidthPixels = New MouseOdometer.Z80_TextBox()
        Me.Z80Txt_MonitorInches = New MouseOdometer.Z80_TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Show measure in:"
        '
        'CboMeasureUnits
        '
        Me.CboMeasureUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMeasureUnits.FormattingEnabled = True
        Me.CboMeasureUnits.Location = New System.Drawing.Point(177, 90)
        Me.CboMeasureUnits.Name = "CboMeasureUnits"
        Me.CboMeasureUnits.Size = New System.Drawing.Size(100, 21)
        Me.CboMeasureUnits.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Primary monitor Inches:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Primary monitor width:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Primary monitor height:"
        '
        'BtnSetLegthToZero
        '
        Me.BtnSetLegthToZero.Location = New System.Drawing.Point(11, 161)
        Me.BtnSetLegthToZero.Name = "BtnSetLegthToZero"
        Me.BtnSetLegthToZero.Size = New System.Drawing.Size(75, 40)
        Me.BtnSetLegthToZero.TabIndex = 8
        Me.BtnSetLegthToZero.Text = "Reset to zero"
        Me.ToolTip1.SetToolTip(Me.BtnSetLegthToZero, "Reset all counters to zero (mouse movement and button clicks)")
        Me.BtnSetLegthToZero.UseVisualStyleBackColor = True
        '
        'BtnOK
        '
        Me.BtnOK.Image = Global.MouseOdometer.My.Resources.Resources.button_ok
        Me.BtnOK.Location = New System.Drawing.Point(121, 161)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(75, 40)
        Me.BtnOK.TabIndex = 9
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Image = Global.MouseOdometer.My.Resources.Resources.button_cancel
        Me.BtnCancel.Location = New System.Drawing.Point(202, 161)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 40)
        Me.BtnCancel.TabIndex = 10
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'Z80Txt_MonitorHeightPixels
        '
        Me.Z80Txt_MonitorHeightPixels.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Z80Txt_MonitorHeightPixels.Location = New System.Drawing.Point(177, 64)
        Me.Z80Txt_MonitorHeightPixels.MaxLength = 8
        Me.Z80Txt_MonitorHeightPixels.Name = "Z80Txt_MonitorHeightPixels"
        Me.Z80Txt_MonitorHeightPixels.Size = New System.Drawing.Size(100, 20)
        Me.Z80Txt_MonitorHeightPixels.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.Z80Txt_MonitorHeightPixels, "leave blank to get default primary screen height")
        Me.Z80Txt_MonitorHeightPixels.Z80_BackColorChangeWhenEmptyText = False
        Me.Z80Txt_MonitorHeightPixels.Z80_BackColorEmptyText = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Z80Txt_MonitorHeightPixels.Z80_DecimalNumbers = 0
        Me.Z80Txt_MonitorHeightPixels.Z80_ForeColorEmptyText = System.Drawing.Color.Gray
        Me.Z80Txt_MonitorHeightPixels.Z80_OnlyNumbers = True
        Me.Z80Txt_MonitorHeightPixels.Z80_Text = "pixels"
        '
        'Z80Txt_MonitorWidthPixels
        '
        Me.Z80Txt_MonitorWidthPixels.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Z80Txt_MonitorWidthPixels.Location = New System.Drawing.Point(177, 38)
        Me.Z80Txt_MonitorWidthPixels.MaxLength = 8
        Me.Z80Txt_MonitorWidthPixels.Name = "Z80Txt_MonitorWidthPixels"
        Me.Z80Txt_MonitorWidthPixels.Size = New System.Drawing.Size(100, 20)
        Me.Z80Txt_MonitorWidthPixels.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.Z80Txt_MonitorWidthPixels, "leave blank to get default primary screen width")
        Me.Z80Txt_MonitorWidthPixels.Z80_BackColorChangeWhenEmptyText = False
        Me.Z80Txt_MonitorWidthPixels.Z80_BackColorEmptyText = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Z80Txt_MonitorWidthPixels.Z80_DecimalNumbers = 0
        Me.Z80Txt_MonitorWidthPixels.Z80_ForeColorEmptyText = System.Drawing.Color.Gray
        Me.Z80Txt_MonitorWidthPixels.Z80_OnlyNumbers = True
        Me.Z80Txt_MonitorWidthPixels.Z80_Text = "pixels"
        '
        'Z80Txt_MonitorInches
        '
        Me.Z80Txt_MonitorInches.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Z80Txt_MonitorInches.Location = New System.Drawing.Point(177, 12)
        Me.Z80Txt_MonitorInches.MaxLength = 8
        Me.Z80Txt_MonitorInches.Name = "Z80Txt_MonitorInches"
        Me.Z80Txt_MonitorInches.Size = New System.Drawing.Size(100, 20)
        Me.Z80Txt_MonitorInches.TabIndex = 3
        Me.Z80Txt_MonitorInches.Z80_BackColorChangeWhenEmptyText = True
        Me.Z80Txt_MonitorInches.Z80_BackColorEmptyText = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Z80Txt_MonitorInches.Z80_DecimalNumbers = 1
        Me.Z80Txt_MonitorInches.Z80_ForeColorEmptyText = System.Drawing.Color.Gray
        Me.Z80Txt_MonitorInches.Z80_OnlyNumbers = True
        Me.Z80Txt_MonitorInches.Z80_Text = "inches"
        '
        'SettingsUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(288, 210)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnSetLegthToZero)
        Me.Controls.Add(Me.Z80Txt_MonitorHeightPixels)
        Me.Controls.Add(Me.Z80Txt_MonitorWidthPixels)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Z80Txt_MonitorInches)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CboMeasureUnits)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SettingsUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SettingsUI"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents CboMeasureUnits As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Z80Txt_MonitorInches As Z80_TextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Z80Txt_MonitorWidthPixels As Z80_TextBox
    Friend WithEvents Z80Txt_MonitorHeightPixels As Z80_TextBox
    Friend WithEvents BtnSetLegthToZero As Button
    Friend WithEvents BtnOK As Button
    Friend WithEvents BtnCancel As Button
End Class
