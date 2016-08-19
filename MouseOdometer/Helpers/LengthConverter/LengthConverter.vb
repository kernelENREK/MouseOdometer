Namespace Helpers.LengthConverter

    ''' <summary>
    ''' Class for convert meters to another unit (providers)
    ''' </summary>
    Public Class LengthConverter

        Public Converter As ILength

        Public Sub New(provider As Providers)
            Try
                Select Case provider
                    Case Providers.Meters
                        Converter = New ConverterBase(1, "meters")
                    Case Providers.Kilometers
                        Converter = New ConverterBase(0.001, "kilometers")
                    Case Providers.Miles
                        Converter = New ConverterBase(0.000621371, "miles")
                    Case Providers.Feets
                        Converter = New ConverterBase(3.28084, "feets")
                    Case Providers.Yards
                        Converter = New ConverterBase(1.09361, "yards")
                    Case Providers.Inches
                        Converter = New ConverterBase(39.3701, "inches")
                End Select
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Return current provider name
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function ToString() As String
            Return Converter.ToString()
        End Function

    End Class

End Namespace
