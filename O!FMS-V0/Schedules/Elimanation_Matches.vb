Imports System.Data.SqlClient
Imports O_FMS_V0.Main_Panel


Public Class Elimanation_Matches
    Shared connection As New SqlConnection("data source=MY-PC\OFMS; Initial Catalog=OpenFMS; Integrated Security = true")
    Shared team1
    Shared team2
    Shared team3
    Shared team4
    Shared rank
    Shared wins

    'This gets the alliances from the database'
    Shared Function getAlliance(alliance_num As Integer)
        Dim query As String = String.Format("Select ([team1], [team2], [team3], [team4]) From alliances Where rank= {0}", alliance_num)
        Dim selectData As New SqlCommand(query, connection)
        Dim adapter As New SqlDataAdapter(selectData)
        Dim table As New DataTable()
        adapter.Fill(table)

        If table.Rows.Count > 0 Then
            team1 = table.Rows(0)(0)
            team2 = table.Rows(0)(1)
            team3 = table.Rows(0)(2)
        End If

        Return team1 & team2 & team3
    End Function

    Shared Sub updateQuarterFinalMatches(match_num As Integer, blue_wins As Integer, red_wins As Integer)
        'This builds the matches for the quarterfinals'
        If match_num = 1 Then
            buildElimanationMatch(1, 8, 1, "Quarterfinal")
        End If

        If match_num = 2 Then
            buildElimanationMatch(2, 7, 2, "Quarterfinal")
        End If

        If match_num = 3 Then
            buildElimanationMatch(3, 6, 3, "Quarterfinal")
        End If

        If match_num = 4 Then
            buildElimanationMatch(4, 5, 4, "Quarterfinal")
        End If

 
    End Sub

    Shared Sub buildElimanationMatch(alliance1 As Integer, alliance2 As Integer, match_num As Integer, match_type As String)

    End Sub

    Shared Sub getElimantionResults()

    End Sub

    Public Sub executeQuery(query As String)
        Dim command As New SqlCommand(query, connection)
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub
End Class
