''' <summary>
''' Class for user settings. We serialize this class
''' </summary>
Public Class SettingsModel
    ''' <summary>
    ''' Monitor settings
    ''' </summary>
    Public Monitor As MonitorSettings

    ''' <summary>
    ''' Unit for measure lenght
    ''' </summary>
    ''' <returns></returns>
    Public Property Measure As Helpers.LengthConverter.Providers

    ''' <summary>
    ''' Total meters mouse move
    ''' </summary>
    ''' <returns></returns>
    Public Property MetersCounter As Double

    ''' <summary>
    ''' How mmany right mouse clicks have been done
    ''' </summary>
    ''' <returns></returns>
    Public Property RightClickCounter As Integer

    ''' <summary>
    ''' How many left mouse clicks have been done
    ''' </summary>
    ''' <returns></returns>
    Public Property LeftClickCounter As Integer

    ''' <summary>
    ''' Date from capture start
    ''' </summary>
    ''' <returns></returns>
    Public Property DateCapturedSince As Date?

    Public Sub New()
        Monitor = New MonitorSettings()
        Measure = Helpers.LengthConverter.Providers.Meters
        MetersCounter = 0
        RightClickCounter = 0
        LeftClickCounter = 0
    End Sub

End Class

''' <summary>
''' Monitor settings
''' </summary>
Public Class MonitorSettings
    ''' <summary>
    ''' Inches for our monitor
    ''' </summary>
    ''' <returns></returns>
    Public Property Inches As Decimal?
    ''' <summary>
    ''' Pixel width resolution
    ''' </summary>
    ''' <returns></returns>
    Public Property Width As Integer?
    ''' <summary>
    ''' Pixel height resolution
    ''' </summary>
    ''' <returns></returns>
    Public Property Height As Integer?
End Class
