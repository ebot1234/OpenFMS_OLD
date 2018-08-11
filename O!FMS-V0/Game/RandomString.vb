Imports Microsoft.VisualBasic

'Imports UI.New_UI

Public Class RandomString

    Private Shared random As Random = New Random
    Public Shared gamedataUse
    Public Shared gamedataUse_PLC

    Public Shared Sub game_data_main(ByVal args() As String)
        Dim gameData As List(Of String) = Nothing

        'List of the Scale and Switch Vaules
        gameData.Add("LLL")
        gameData.Add("RRR")
        gameData.Add("LRL")
        gameData.Add("RLR")

        Dim i As Integer = 0
        Do While (i < 1)
            RandomString.getRandomItem(gameData)
            i = (i + 1)
        Loop
        gamedataUse = gameData
    End Sub
    Public Shared Sub game_data_PLC(ByVal args() As String)
        If gamedataUse = "LLL" Then
            gamedataUse_PLC = 111
        End If
        If gamedataUse = "RRR" Then
            gamedataUse_PLC = 0
        End If
        If gamedataUse = "LRL" Then
            gamedataUse_PLC = 101
        End If
        If gamedataUse = "RLR" Then
            gamedataUse_PLC = 10
        End If
    End Sub
    'Incharge of getting the random item from the list of vaules
    Private Shared Sub getRandomItem(ByVal gameData As List(Of String))
        'Size of the list is 5
        Dim index As Integer = random.Next(gameData.Count)
        Console.Out.Write(("" + gameData(index)))
    End Sub
End Class
'Colorized by: CarlosAg.CodeColorizer


