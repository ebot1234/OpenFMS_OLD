Imports System.Data.SqlClient
Imports O_FMS_V0.Match


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
    Shared alliance1Num
    Shared alliance2Num
    Shared round
    Shared type


    'This gets the teams from each alliances from the database'
    Shared Function getAllianceTeam(alliance_num As Integer, team_placement As Integer)
        Dim query As String = String.Format("Select * From alliances Where rank= {0}", alliance_num)
        Dim selectData As New SqlCommand(query, connection)
        Dim adapter As New SqlDataAdapter(selectData)
        Dim table As New DataTable()
        adapter.Fill(table)

        If table.Rows.Count > 0 Then
            team = table.Rows(0)(team_placement)
        End If

        Return team
    End Function

    Public Shared Sub updateElimanationMatches(Tie As Boolean)
        Dim getQuery As String = "SELECT * FROM ElimanationResults"
        Dim selectData As New SqlCommand(getQuery, connection)
        Dim adapter As New SqlDataAdapter(selectData)
        Dim table As New DataTable()
        adapter.Fill(table)

        If table.Rows.Count > 0 Then
            alliance1Num = table.Rows(0)(0)
            alliance2Num = table.Rows(0)(1)
            round = table.Rows(0)(2)
            type = table.Rows(0)(3)
        End If

        'This switches for the next round of QF matches'
        If type = "QF" And round = 4 Then
            If alliance1Num = 3 And alliance2Num = 6 Then
                alliance1Num = 1 And alliance2Num = 8
            End If
        End If

        'This increments the round number to match the next match
        round = round + 1

            'This switches between the match types from the tie and round values
            If type = "QF" And round > 8 And Tie = True Then
                round = round - 8
                type = "QF-Tie"
            End If

            If type = "SF" And round > 4 And Tie = True Then
                round = round - 4
                type = "SF-Tie"
            End If

            If type = "F" And round > 2 And Tie = True Then
                round = round - 2
                type = "F-Tie"
            End If

            buildElimanationMatch(round, type, alliance1Num, alliance2Num)
    End Sub

    Public Shared Sub buildElimanationMatch(round As Integer, type As String, alliance1 As Integer, alliance2 As Integer)
        'This switches between the match type
        Select Case type
            Case "QF"
                buildQuarterFinalMatch(round, type, alliance1, alliance2)
            Case "QF-Tie"
                buildQuarterFinalMatch(round, type, alliance1, alliance2)
            Case "SF"
                buildSemifinalMatch(round, type, alliance1, alliance2)
            Case "SF-Tie"
                buildSemifinalMatch(round, type, alliance1, alliance2)
            Case "F"
                buildFinalMatch(round, type, alliance1, alliance2)
            Case "F-Tie"
                buildFinalMatch(round, type, alliance1, alliance2)
        End Select
    End Sub

    Public Shared Sub buildFinalMatch(round As Integer, type As String, alliance1 As Integer, alliance2 As Integer)
        team1 = getAllianceTeam(alliance1, 1)
        team2 = getAllianceTeam(alliance1, 2)
        team3 = getAllianceTeam(alliance1, 3)
        team4 = getAllianceTeam(alliance2, 1)
        team5 = getAllianceTeam(alliance2, 2)
        team6 = getAllianceTeam(alliance2, 3)

        Dim insertQuery As String = ""

        If round > 2 Then
            insertQuery = "INSERT INTO elimanation ([type], [round], [red1], [red2], [red3], [blue1], [blue2], [blue3]) VALUES (Final Tiebreaker, '" & round & "', '" & team1 & "', '" & team2 & "', '" & team3 & "', '" & team4 & "', '" & team5 & "', '" & team6 & "')"
        Else
            insertQuery = "INSERT INTO elimanation ([type], [round], [red1], [red2], [red3], [blue1], [blue2], [blue3]) VALUES (Final, '" & round & "', '" & team1 & "', '" & team2 & "', '" & team3 & "', '" & team4 & "', '" & team5 & "', '" & team6 & "')"
        End If

        executeQuery(insertQuery)
    End Sub

    Public Shared Sub buildSemifinalMatch(round As Integer, type As String, alliance1 As Integer, alliance2 As Integer)
        team1 = getAllianceTeam(alliance1, 1)
        team2 = getAllianceTeam(alliance1, 2)
        team3 = getAllianceTeam(alliance1, 3)
        team4 = getAllianceTeam(alliance2, 1)
        team5 = getAllianceTeam(alliance2, 2)
        team6 = getAllianceTeam(alliance2, 3)

        Dim insertQuery As String = ""

        If round > 4 Then
            insertQuery = "INSERT INTO elimanation ([type], [round], [red1], [red2], [red3], [blue1], [blue2], [blue3]) VALUES (Semifinal Tiebreaker, '" & round & "', '" & team1 & "', '" & team2 & "', '" & team3 & "', '" & team4 & "', '" & team5 & "', '" & team6 & "')"
        Else
            insertQuery = "INSERT INTO elimanation ([type], [round], [red1], [red2], [red3], [blue1], [blue2], [blue3]) VALUES (Semifinal, '" & round & "', '" & team1 & "', '" & team2 & "', '" & team3 & "', '" & team4 & "', '" & team5 & "', '" & team6 & "')"
        End If

        executeQuery(insertQuery)
    End Sub

    Public Shared Sub buildQuarterFinalMatch(round As Integer, type As String, alliance1 As Integer, alliance2 As Integer)
        team1 = getAllianceTeam(alliance1, 1)
        team2 = getAllianceTeam(alliance1, 2)
        team3 = getAllianceTeam(alliance1, 3)
        team4 = getAllianceTeam(alliance2, 1)
        team5 = getAllianceTeam(alliance2, 2)
        team6 = getAllianceTeam(alliance2, 3)

        Dim insertQuery As String = ""

        If type = "QF-Tie" Then
            insertQuery = "INSERT INTO elimanation ([type], [round], [red1], [red2], [red3], [blue1], [blue2], [blue3]) VALUES (Quarterfinal Tiebreaker, '" & round & "', '" & team1 & "', '" & team2 & "', '" & team3 & "', '" & team4 & "', '" & team5 & "', '" & team6 & "')"
        Else
            insertQuery = "INSERT INTO elimanation ([type], [round], [red1], [red2], [red3], [blue1], [blue2], [blue3]) VALUES (Quarterfinal, '" & round & "', '" & team1 & "', '" & team2 & "', '" & team3 & "', '" & team4 & "', '" & team5 & "', '" & team6 & "')"
        End If

        executeQuery(insertQuery)
    End Sub

    Public Shared Sub positionRedTeams(alliance() As Integer)
        team1 = alliance(0)
        team2 = alliance(1)
        team3 = alliance(2)
    End Sub

    Public Shared Sub positionBlueTeams(alliance() As Integer)
        team4 = alliance(0)
        team5 = alliance(1)
        team6 = alliance(2)
    End Sub

    Public Shared Function GetMatchesByElimGroup(group As Integer, round As Integer)
        Dim selectQuery As String = String.Format("SELECT match FROM elimanation Where group = {0}", group)
        'return the result of the query from elim match progress table
    End Function

    Public Shared Sub createMatch(roundName As Integer, round As Integer, group As Integer, instance As Integer, redAlliance() As Integer, blueAlliance() As Integer)
        If round = -1 Then
            round = "Tie Breaker"
        End If

        positionRedTeams(redAlliance)
        positionBlueTeams(blueAlliance)

        Dim insertQuery As String = String.Format("INSERT INTO elimanation ([round], [red1], [red2], [red3], [blue1], [blue2], [blue3]) VALUES ('" & round & "', '" & team1 & "', '" & team2 & "', '" & team3 & "', '" & team4 & "', '" & team5 & "', '" & team6 & "')")
        executeQuery(insertQuery)
    End Sub

    Public Shared Function reorderTeams(t1 As Integer, t2 As Integer, t3 As Integer, alliance() As Integer)
        Return 0
    End Function

    Shared Sub publishWins(wins As Integer, alliance As Integer)
        Dim publish As String = String.Format("UPDATE alliances SET wins = {0} WHERE rank = {1}", wins, alliance)
        executeQuery(publish)
    End Sub

    Shared Function getUnplayedMatches()
        Dim amount = 0
        Dim result As String = ""
        Dim getQuery As String = String.Format("SELECT Match From elimanation")
        Dim selectData As New SqlCommand(getQuery, connection)
        Dim adapter As New SqlDataAdapter(selectData)
        Dim table As New DataTable()
        adapter.Fill(table)

        If table.Rows.Count > 0 Then
            For Each row In table.Rows
                result = table.Rows(amount)(0)
                amount = amount + 1
            Next

        End If

        Return result
    End Function

    Shared Sub executeQuery(query As String)
        Dim command As New SqlCommand(query, connection)
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub
End Class
