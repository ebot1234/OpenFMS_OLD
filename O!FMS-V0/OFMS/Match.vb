Public Class Match
    Public id As Integer
    Public Type As Integer
    Public time As DateTime
    Public ElimRound As Integer
    Public ElimGroup As Integer
    Public ElimInstance As Integer
    Public Red1 As Integer
    Public Red1IsSurragate As Boolean
    Public Red2 As Integer
    Public Red2IsSurragate As Boolean
    Public Red3 As Integer
    Public Red3IsSurragate As Boolean
    Public Blue1 As Integer
    Public Blue1IsSurragate As Boolean
    Public Blue2 As Integer
    Public Blue2IsSurragate As Boolean
    Public Blue3 As Integer
    Public Blue3IsSurragate As Boolean
    Public Status As String
    Public StartedAt As DateTime
    Public Winner As String
    Public GameSpecificData As String

    Public ElimRoundNames As String = 1 = "F" & 2 = "SF" & 4 = "QF" & 8 = "EF"

End Class