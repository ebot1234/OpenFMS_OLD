
Public Class RandomString

    Public Shared gamedatause As String
    Public Shared Sub GameDataGen()
        Dim gameList As New ArrayList
        gameList.Add("RRR")
        gameList.Add("RLR")
        gameList.Add("LLL")
        gameList.Add("LRL")

        Dim rnd As New Random
        Dim randomNumber As Integer = rnd.Next(4)
        gamedatause = gameList(randomNumber)
    End Sub
End Class



