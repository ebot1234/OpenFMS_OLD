Imports Microsoft.VisualBasic

Imports UI.New_UI
Imports java.util.ArrayList
Imports java.util.List
Imports java.util.Random
Imports javax.swing.JOptionPane
Public Class RandomString

    Private Shared random As Random = New Random

    Public Shared Sub main(ByVal args() As String)
        Dim gameData As List(Of String) = New ArrayList
        'List of the Scale and Switch Vaules
        gameData.add("LLL")
        gameData.add("RRR")
        gameData.add("LRL")
        gameData.add("RLR")
        Dim i As Integer = 0
        Do While (i < 1)
            RandomString.getRandomItem(gameData)
            i = (i + 1)
        Loop

    End Sub

    'Incharge of getting the random item from the list of vaules
    Private Shared Sub getRandomItem(ByVal gameData As List(Of String))
        'Size of the list is 5
        Dim index As Integer = random.nextInt(gameData.size)
        System.out.println(("" + gameData.get(index)))
    End Sub
End Class
'Colorized by: CarlosAg.CodeColorizer


