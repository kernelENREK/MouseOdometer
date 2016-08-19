Namespace Helpers.LengthConverter

    Public Interface ILength

        ''' <summary>
        ''' Return length in the unit provider
        ''' </summary>
        ''' <param name="meters">value in meters we want to convert to unit provider</param>
        ''' <returns></returns>
        ReadOnly Property Value(meters As Double) As Double

    End Interface

End Namespace

