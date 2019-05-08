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
    Shared wins

    Shared QF1_win
    Shared QF2_win
    Shared QF3_win
    Shared QF4_win


    'This gets the teams from each alliances from the database'
    Shared Function getAllianceTeam(alliance_num As Integer, team_num As String, place As Integer)
        Dim query As String = String.Format("Select {0} From alliances Where rank= {0}", team_num, alliance_num)
        Dim selectData As New SqlCommand(query, connection)
        Dim adapter As New SqlDataAdapter(selectData)
        Dim table As New DataTable()
        adapter.Fill(table)

        If table.Rows.Count > 0 Then
            team = table.Rows(0)(place)
        End If

        Return team
    End Function

    'This is called once to create the first 4 elimanation matches'
    Shared Sub createFirstMatches()
        buildElimanationMatch(1, 8, 1, "Quarterfinal")
        buildElimanationMatch(4, 5, 2, "Quarterfinal")
        buildElimanationMatch(2, 7, 3, "Quarterfinal")
        buildElimanationMatch(3, 6, 4, "Quarterfinal")
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
        Dim prev_red_wins = getWins(red_alliance)
        Dim prev_blue_wins = getWins(blue_alliance)

        'This calculates the total wins'
        red_wins = red_win + prev_red_wins
        blue_wins = blue_win + prev_blue_wins

        'calculates the quarterfinal rounds'
        If red_alliance = 1 And blue_alliance = 8 Then
            'if the red team won the 1st then play again'
            If red_wins = 1 And blue_wins = 0 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                buildElimanationMatch(red_alliance, blue_alliance, 5, "Quarterfinal")
                'creates a second round'
            ElseIf red_wins = 0 And blue_wins = 1 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                buildElimanationMatch(red_alliance, blue_alliance, 5, "Quarterfinal")
                'No rematch since the red team won all matches'
            ElseIf red_wins = 2 And blue_wins = 0 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                QF1_win = red_alliance
                'No rematch since blue team won all matches'
            ElseIf red_wins = 0 And blue_wins = 2 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                QF1_win = blue_alliance
            ElseIf red_wins = 1 And blue_wins = 1 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                buildElimanationMatch(red_alliance, blue_alliance, 9, "Quarterfinal")
            End If
        End If

        If red_alliance = 4 And blue_alliance = 5 Then
            'if the red team won the 1st then play again'
            If red_wins = 1 And blue_wins = 0 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                buildElimanationMatch(red_alliance, blue_alliance, 6, "Quarterfinal")
                'creates a second round'
            ElseIf red_wins = 0 And blue_wins = 1 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                buildElimanationMatch(red_alliance, blue_alliance, 6, "Quarterfinal")
                'No rematch since the red team won all matches'
            ElseIf red_wins = 2 And blue_wins = 0 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                QF1_win = red_alliance
                'No rematch since blue team won all matches'
            ElseIf red_wins = 0 And blue_wins = 2 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                QF1_win = blue_alliance
            ElseIf red_wins = 1 And blue_wins = 1 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                buildElimanationMatch(red_alliance, blue_alliance, 10, "Quarterfinal")
            End If
        End If

        If red_alliance = 2 And blue_alliance = 7 Then
            'if the red team won the 1st then play again'
            If red_wins = 1 And blue_wins = 0 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                buildElimanationMatch(red_alliance, blue_alliance, 7, "Quarterfinal")
                'creates a second round'
            ElseIf red_wins = 0 And blue_wins = 1 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                buildElimanationMatch(red_alliance, blue_alliance, 7, "Quarterfinal")
                'No rematch since the red team won all matches'
            ElseIf red_wins = 2 And blue_wins = 0 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                QF1_win = red_alliance
                'No rematch since blue team won all matches'
            ElseIf red_wins = 0 And blue_wins = 2 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                QF1_win = blue_alliance
            ElseIf red_wins = 1 And blue_wins = 1 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                buildElimanationMatch(red_alliance, blue_alliance, 11, "Quarterfinal")
            End If
        End If

        If red_alliance = 3 And blue_alliance = 6 Then
            'if the red team won the 1st then play again'
            If red_wins = 1 And blue_wins = 0 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                buildElimanationMatch(red_alliance, blue_alliance, 8, "Quarterfinal")
                'creates a second round'
            ElseIf red_wins = 0 And blue_wins = 1 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                buildElimanationMatch(red_alliance, blue_alliance, 8, "Quarterfinal")
                'No rematch since the red team won all matches'
            ElseIf red_wins = 2 And blue_wins = 0 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                QF1_win = red_alliance
                'No rematch since blue team won all matches'
            ElseIf red_wins = 0 And blue_wins = 2 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                QF1_win = blue_alliance
            ElseIf red_wins = 1 And blue_wins = 1 Then
                publishWins(red_wins, red_alliance)
                publishWins(blue_wins, blue_alliance)
                buildElimanationMatch(red_alliance, blue_alliance, 11, "Quarterfinal")
            End If
        End If

        'Calculate the semifinal rounds'

    End Sub

    Shared Function getWins(rank As Integer)
        Dim getAllianceWins As String = Format("SELECT wins FROM alliances Where rank = {0}", rank)
        Dim selectData As New SqlCommand(getAllianceWins, connection)
        Dim adapter As New SqlDataAdapter(selectData)
        Dim table As New DataTable()
        adapter.Fill(table)

        If table.Rows.Count > 0 Then
            wins = table.Rows(0)(0)
        End If

        Return wins
    End Function

    Shared Sub publishWins(wins As Integer, alliance As Integer)
        Dim publish As String = String.Format("UPDATE alliances SET wins = {0} WHERE rank = {1}", wins, alliance)
        executeQuery(publish)
    End Sub

    Shared Sub executeQuery(query As String)
        Dim command As New SqlCommand(query, connection)
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub
End Class
