'This class implements the generation of the game specific data for 2020'
Public Class GameSpecificData
    Public Shared GameString As String = ""

    'Generates and Returns the GameString'
    Public Shared Function GenerateGameData()
        Dim ValidGameData = {"R", "G", "B", "Y"}
        Dim GameDataList As New List(Of String)

        For Each Color As String In ValidGameData
            GameDataList.Add(Color)
        Next

        Dim rnd As New Random()
        GameString = GameDataList(rnd.Next(0, GameDataList.Count))

        Return GameString
    End Function
End Class
