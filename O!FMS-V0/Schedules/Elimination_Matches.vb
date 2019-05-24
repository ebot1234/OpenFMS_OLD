Imports System.Data.SqlClient
Imports O_FMS_V0.AudianceDisplay


Public Class Elimination_Matches
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
    Shared QF1_Winner
    Shared QF2_Winner
    Shared QF3_Winner
    Shared QF4_Winner
    Shared SF_1 As String
    Shared SF_2 As String
    Shared SF_3 As String
    Shared SF_4 As String
    Shared F_1 As String
    Shared F_2 As String
    Shared Winner As String
    Shared Finalist As String

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

    'This creates all the first elimanation matches to start the elimanation matches'
    Public Shared Sub buildFirstQuarterFinalMatches()
        buildQuarterFinalMatch(1, "QF-1", 1, 8)
        buildQuarterFinalMatch(2, "QF-2", 2, 7)
        buildQuarterFinalMatch(3, "QF-3", 3, 6)
        buildQuarterFinalMatch(4, "QF-4", 4, 5)
        buildQuarterFinalMatch(5, "QF-5", 1, 8)
        buildQuarterFinalMatch(6, "QF-6", 2, 7)
        buildQuarterFinalMatch(7, "QF-7", 3, 6)
        buildQuarterFinalMatch(8, "QF-8", 4, 5)
    End Sub

    Public Shared Sub buildFirstSemifinalMatches()
        buildSemifinalMatch(1, "SF-1", SF_1, SF_4)
        buildSemifinalMatch(2, "SF-2", SF_2, SF_3)
        buildSemifinalMatch(3, "SF-3", SF_1, SF_4)
        buildSemifinalMatch(4, "SF-4", SF_2, SF_3)
    End Sub

    Public Shared Sub buildFirstFinalMatches()
        buildFinalMatch(1, "F-1", F_1, F_2)
        buildFinalMatch(2, "F-2", F_1, F_2)
    End Sub

    Public Shared Sub updateQuarterFinalMatches(round As Integer)
        Dim alliance1Wins = getWins(1)
        Dim alliance2Wins = getWins(2)
        Dim alliance3Wins = getWins(3)
        Dim alliance4Wins = getWins(4)
        Dim alliance5Wins = getWins(5)
        Dim alliance6Wins = getWins(6)
        Dim alliance7Wins = getWins(7)
        Dim alliance8Wins = getWins(8)

        If alliance1Wins > alliance8Wins And round > 8 Then
            SF_1 = 1
        ElseIf alliance1Wins < alliance8Wins And round > 8 Then
            SF_1 = 8
        ElseIf alliance1Wins = alliance8Wins And round > 8 Then
            buildQuarterFinalMatch(9, "QF-9", 1, 8)
        End If

        If alliance2Wins > alliance7Wins And round > 8 Then
            SF_2 = 2
        ElseIf alliance2Wins < alliance7Wins And round > 8 Then
            SF_2 = 7
        ElseIf alliance2Wins = alliance7Wins And round > 8 Then
            buildQuarterFinalMatch(10, "QF-10", 2, 7)
        End If

        If alliance3Wins > alliance6Wins And round > 8 Then
            SF_3 = 3
        ElseIf alliance3Wins < alliance6Wins And round > 8 Then
            SF_3 = 6
        ElseIf alliance3Wins = alliance6Wins And round > 8 Then
            buildQuarterFinalMatch(11, "QF-11", 3, 6)
        End If

        If alliance4Wins > alliance5Wins And round > 8 Then
            SF_4 = 4
        ElseIf alliance4Wins < alliance5Wins And round > 8 Then
            SF_4 = 5
        ElseIf alliance4Wins = alliance5Wins And round > 8 Then
            buildQuarterFinalMatch(12, "QF-12", 4, 5)
        End If

        buildFirstSemifinalMatches()
    End Sub

    Shared Sub updateSemifinalMatches(round As Integer)
        Dim SF_1Wins = getWins(SF_1)
        Dim SF_2Wins = getWins(SF_2)
        Dim SF_3Wins = getWins(SF_3)
        Dim SF_4Wins = getWins(SF_4)

        If SF_1Wins > SF_4Wins And round > 4 Then
            F_1 = SF_1
        ElseIf SF_1Wins < SF_4Wins And round > 4 Then
            F_1 = SF_4
        ElseIf SF_1Wins = SF_4Wins And round > 4 Then
            buildSemifinalMatch(round, String.Format("SF-{0}", round), 1, 8)
        End If

        If SF_2Wins > SF_3Wins And round > 4 Then
            F_2 = SF_2
        ElseIf SF_2Wins < SF_3Wins And round > 4 Then
            F_2 = SF_3
        ElseIf SF_2Wins = SF_3Wins And round > 4 Then
            If round = 5 And SF_1Wins <> SF_4Wins Then
                buildSemifinalMatch(round, String.Format("SF-{0}", round), SF_2, SF_3)
            Else
                buildSemifinalMatch(round + 1, String.Format("SF-{0}", round + 1), SF_2, SF_3)
            End If
        Else
            buildFirstFinalMatches()
        End If
    End Sub

    Public Shared Sub updateFinalMatches(round As Integer)
        Dim F_1Wins = getWins(F_1)
        Dim F_2Wins = getWins(F_2)

        If F_1Wins > F_2Wins And round > 2 Then
            Winner = F_1
            Finalist = F_2
            AudianceDisplay.WinningAlliance.Text = F_1
        ElseIf F_1Wins < F_2Wins And round > 2 Then
            Winner = F_2
            Finalist = F_2
            AudianceDisplay.WinningAlliance.Text = F_2
        ElseIf F_1Wins = F_2Wins And round > 2 Then
            buildFinalMatch(3, "F-3", F_1, F_2)
        End If
    End Sub

    Public Shared Function getWins(alliance1 As Integer)
        Dim wins As Integer = 0
        Dim getQuery As String = String.Format("SELECT ([Wins]) FROM alliances Where rank = {0}", alliance1)
        Dim selectQuery As New SqlCommand(getQuery, connection)
        Dim adpater As New SqlDataAdapter(selectQuery)
        Dim table As New DataTable()
        adpater.Fill(table)

        If table.Rows.Count > 0 Then
            wins = table.Rows(0)(0)
        End If

        Return wins
    End Function


    Public Shared Sub buildFinalMatch(round As Integer, type As String, alliance1 As Integer, alliance2 As Integer)
        team1 = getAllianceTeam(alliance1, 0)
        team2 = getAllianceTeam(alliance1, 1)
        team3 = getAllianceTeam(alliance1, 2)
        team4 = getAllianceTeam(alliance2, 0)
        team5 = getAllianceTeam(alliance2, 1)
        team6 = getAllianceTeam(alliance2, 2)

        Dim insertQuery As String = ""
        insertQuery = "INSERT INTO elimination ([type], [round], [red1], [red2], [red3], [blue1], [blue2], [blue3], [alliance1], [alliance2]) VALUES ('" & type & "', '" & round & "', '" & team1 & "', '" & team2 & "', '" & team3 & "', '" & team4 & "', '" & team5 & "', '" & team6 & "', '" & alliance1 & "', '" & alliance2 & "')"

        executeQuery(insertQuery)
    End Sub

    Public Shared Sub buildSemifinalMatch(round As Integer, type As String, alliance1 As Integer, alliance2 As Integer)
        team1 = getAllianceTeam(alliance1, 0)
        team2 = getAllianceTeam(alliance1, 1)
        team3 = getAllianceTeam(alliance1, 2)
        team4 = getAllianceTeam(alliance2, 0)
        team5 = getAllianceTeam(alliance2, 1)
        team6 = getAllianceTeam(alliance2, 2)

        Dim insertQuery As String = ""
        insertQuery = "INSERT INTO elimination ([type], [round], [red1], [red2], [red3], [blue1], [blue2], [blue3], [alliance1], [alliance2]) VALUES ('" & type & "', '" & round & "', '" & team1 & "', '" & team2 & "', '" & team3 & "', '" & team4 & "', '" & team5 & "', '" & team6 & "', '" & alliance1 & "', '" & alliance2 & "')"

        executeQuery(insertQuery)
    End Sub

    Public Shared Sub buildQuarterFinalMatch(round As Integer, type As String, alliance1 As Integer, alliance2 As Integer)
        team1 = getAllianceTeam(alliance1, 0)
        team2 = getAllianceTeam(alliance1, 1)
        team3 = getAllianceTeam(alliance1, 2)
        team4 = getAllianceTeam(alliance2, 0)
        team5 = getAllianceTeam(alliance2, 1)
        team6 = getAllianceTeam(alliance2, 2)

        Dim insertQuery As String = ""
        insertQuery = "INSERT INTO elimination ([type], [round], [red1], [red2], [red3], [blue1], [blue2], [blue3], [alliance1], [alliance2]) VALUES ('" & type & "', '" & round & "', '" & team1 & "', '" & team2 & "', '" & team3 & "', '" & team4 & "', '" & team5 & "', '" & team6 & "', '" & alliance1 & "', '" & alliance2 & "')"

        executeQuery(insertQuery)
    End Sub

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
