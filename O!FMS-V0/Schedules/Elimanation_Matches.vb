Imports System.Data.SqlClient
Imports O_FMS_V0.Main_Panel


Public Class Elimanation_Matches
    Shared connection As New SqlConnection("data source=MY-PC\OFMS; Initial Catalog=OpenFMS; Integrated Security = true")
    'team varibles to hold team numbers until posted to SQL'
    Shared team
    Shared team1
    Shared team2
    Shared team3
    Shared team4
    Shared team5
    Shared team6

    Shared blue_wins
    Shared red_wins


    'This gets the teams from each alliances from the database'
    Shared Function getAllianceTeam(alliance_num As Integer, team_num As String, place As Integer)
        Dim query As String = String.Format("Select ([{0}]) From alliances Where rank= {0}", team_num, alliance_num)
        Dim selectData As New SqlCommand(query, connection)
        Dim adapter As New SqlDataAdapter(selectData)
        Dim table As New DataTable()
        adapter.Fill(table)

        If table.Rows.Count > 0 Then
            team = table.Rows(0)(place)
        End If

        Return team
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

    Shared Sub createFirstMatches()

    End Sub

    'This builds and saves the match'
    Shared Sub buildElimanationMatch(alliance1 As Integer, alliance2 As Integer, match_num As Integer, match_type As String)
        'This gets an alliance'
        team1 = getAllianceTeam(alliance1, "team1", 1)
        team2 = getAllianceTeam(alliance1, "team2", 2)
        team3 = getAllianceTeam(alliance1, "team3", 3)

        'This gets the other alliance'
        team4 = getAllianceTeam(alliance2, "team1", 1)
        team5 = getAllianceTeam(alliance2, "team2", 2)
        team6 = getAllianceTeam(alliance2, "team3", 3)

        'Build and save the match'
        Dim saveQuery As String = "INSERT INTO elimanation ([red1], [red2], [red3], [blue1], [blue2], [blue3], [match], [type], [rank1], [rank2]) VALUES ('" & team1 & "', '" & team2 & "', '" & team3 & "', '" & team4 & "', '" & team5 & "', '" & team6 & "', '" & match_num & "', '" & match_type & "')"
        executeQuery(saveQuery)
    End Sub

    'This gets the match results and figures out the next needed match'
    Shared Sub getElimantionResults(match_num As Integer, red_win As Integer, blue_win As Integer, blue_alliance As Integer, red_alliance As Integer)
        Dim saveAllianceQuery As String = ""

        If match_num = 0 Then
            MessageBox.Show("You still need to play the first match")
        End If

        If match_num = 1 Then
            'saves the wins to the alliance DB'
            If blue_win = 1 Then
                saveAllianceQuery = "UPDATE alliances SET wins = '" & blue_win & "' WHERE rank = '" & blue_alliance & "'"
                executeQuery(saveAllianceQuery)

            ElseIf blue_win = 2 Then
                saveAllianceQuery = "UPDATE alliances SET wins = '" & blue_win & "' WHERE rank = '" & blue_alliance & "'"
                executeQuery(saveAllianceQuery)
            End If
        End If
    End Sub

    Shared Sub executeQuery(query As String)
        Dim command As New SqlCommand(query, connection)
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub
End Class
