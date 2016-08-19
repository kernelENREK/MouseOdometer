Namespace Helpers.LengthConverter

    Public Class ConverterBase
        Implements ILength

        Private metersFactor As Double
        Private name As String

        ''' <summary>
        ''' Converter constructor
        ''' </summary>
        ''' <param name="metersFactor">value for convert meters to unit provider</param>
        ''' <param name="name">Provider name for overrides ToString()</param>
        Public Sub New(metersFactor As Double, name As String)
            Me.metersFactor = metersFactor
            Me.name = name
        End Sub

        Public Overrides Function ToString() As String
            Return name
        End Function

#Region "Ilength implementation"

        Public ReadOnly Property Value(meters As Double) As Double Implements ILength.Value
            Get
                Return meters * metersFactor
            End Get
        End Property

#End Region

    End Class

End Namespace

