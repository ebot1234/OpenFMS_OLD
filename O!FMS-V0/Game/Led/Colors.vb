
Imports O_FMS_V0

Public Class Colors
    Public red As New Color
    Public orange As Color
    Public yellow As Color
    Public green As Color
    Public teal As Color
    Public blue As Color
    Public purple As Color
    Public white As Color
    Public black As Color
    Public purpleRed As Color
    Public purpleBlue As Color
    Public dimRed As Color
    Public dimBlue As Color

    Public Sub getColors()
        red = Color.FromArgb(255, 0, 0)
        orange = Color.FromArgb(255, 50, 0)
        yellow = Color.FromArgb(255, 255, 0)
        green = Color.FromArgb(0, 255, 0)
        teal = Color.FromArgb(0, 100, 100)
        blue = Color.FromArgb(0, 0, 255)
        purple = Color.FromArgb(100, 0, 100)
        white = Color.FromArgb(255, 255, 255)
        black = Color.FromArgb(0, 0, 0)
        purpleRed = Color.FromArgb(200, 0, 50)
        purpleBlue = Color.FromArgb(50, 0, 200)
        dimRed = Color.FromArgb(100, 0, 0)
        dimBlue = Color.FromArgb(0, 0, 100)
    End Sub

    Public Shared Widening Operator CType(v As Colors) As Byte
        Throw New NotImplementedException()
    End Operator
End Class

