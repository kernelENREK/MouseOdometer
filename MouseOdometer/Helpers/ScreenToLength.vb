Namespace Helpers

    ''' <summary>
    ''' Helper to convert screen coordinates to 'real world' measure lenght
    ''' </summary>
    Public NotInheritable Class ScreenToLength

        ''' <summary>
        ''' Initialize de physical DPI (not the logial DPI) for the screen. This physical DPI value is used to calculate distance between two points
        ''' </summary>
        ''' <param name="monitorInch">monitor inch (diagonally)</param>
        ''' <param name="monitorSizeWidth">width size measured in pixels</param>
        ''' <param name="monitorSizeHeight">height size measured in pixels</param>
        ''' <returns></returns>
        Public Shared ReadOnly Property PhysicalDPI(monitorInch As Decimal, Optional monitorSizeWidth As Integer? = Nothing, Optional monitorSizeHeight As Integer? = Nothing) As Double
            Get
                Dim monitorWidth As Integer = SystemInformation.PrimaryMonitorSize.Width
                Dim monitorHeight As Integer = SystemInformation.PrimaryMonitorSize.Height

                If (monitorSizeWidth IsNot Nothing) Then monitorWidth = monitorSizeWidth
                If (monitorSizeHeight IsNot Nothing) Then monitorHeight = monitorSizeHeight

                Dim hypotenuseScreen As Double = Math.Sqrt(Math.Pow(monitorWidth, 2) +
                                                           Math.Pow(monitorHeight, 2))

                Dim widthPixels As Double = (monitorWidth * monitorInch) / hypotenuseScreen

                Return monitorWidth / widthPixels
            End Get
        End Property

        ''' <summary>
        ''' Distance measured in millimeters between two points
        ''' </summary>
        ''' <param name="p1">first point (source)</param>
        ''' <param name="p2">end point (destination)</param>
        ''' <param name="dpi">physical screen dpi</param>
        ''' <returns></returns>
        Public Shared Function GetDistancePointsInMillimeters(p1 As Point, p2 As Point, dpi As Double) As Double
            Dim distancePixels As Double = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) +
                                                     Math.Pow(p2.Y - p1.Y, 2))
            Dim distanceInches As Double = distancePixels / dpi
            Return distanceInches * 25.4
        End Function

    End Class

End Namespace
