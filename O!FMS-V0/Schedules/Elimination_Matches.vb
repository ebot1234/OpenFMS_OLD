﻿Imports System.Data.SqlClient


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
    Shared SF_1 As Integer
    Shared SF_2 As Integer
    Shared SF_3 As Integer
    Shared SF_4 As Integer
    Shared F_1 As Integer
    Shared F_2 As Integer
    Shared Winner
    Shared Finalist
    Shared lastMatch

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
        buildQuarterFinalMatch(1, "QF1-1", 1, 8)
        buildQuarterFinalMatch(2, "QF1-2", 2, 7)
        buildQuarterFinalMatch(3, "QF1-3", 3, 6)
        buildQuarterFinalMatch(4, "QF1-4", 4, 5)
        buildQuarterFinalMatch(5, "QF2-1", 1, 8)
        buildQuarterFinalMatch(6, "QF2-2", 2, 7)
        buildQuarterFinalMatch(7, "QF2-3", 3, 6)
        buildQuarterFinalMatch(8, "QF2-4", 4, 5)
    End Sub

    Public Shared Sub buildFirstSemifinalMatches()
        buildSemifinalMatch(lastMatch, "SF1-1", SF_1, SF_4)
        buildSemifinalMatch(lastMatch + 1, "SF1-2", SF_2, SF_3)
        buildSemifinalMatch(lastMatch + 2, "SF2-1", SF_1, SF_4)
        buildSemifinalMatch(lastMatch + 3, "SF2-2", SF_2, SF_3)
    End Sub

    Public Shared Sub buildFirstFinalMatches()
        buildFinalMatch(lastMatch, "F1-1", F_1, F_2)
        buildFinalMatch(lastMatch + 1, "F1-2", F_1, F_2)
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
        Dim roundIndex As Integer = round + 1

        If alliance1Wins > alliance8Wins Then
            SF_1 = 1
        ElseIf alliance1Wins < alliance8Wins Then
            SF_1 = 8
        ElseIf alliance1Wins = alliance8Wins Then
            lastMatch = roundIndex
            buildQuarterFinalMatch(roundIndex, String.Format("QF3-{0}", roundIndex), 1, 8)
            roundIndex = roundIndex + 1
        End If

        If alliance2Wins > alliance7Wins Then
            SF_2 = 2
        ElseIf alliance2Wins < alliance7Wins Then
            SF_2 = 7
        ElseIf alliance2Wins = alliance7Wins Then
            lastMatch = roundIndex
            buildQuarterFinalMatch(roundIndex, String.Format("QF3-{0}", roundIndex), 2, 7)
            roundIndex = roundIndex + 1
        End If

        If alliance3Wins > alliance6Wins Then
            SF_3 = 3
        ElseIf alliance3Wins < alliance6Wins Then
            SF_3 = 6
        ElseIf alliance3Wins = alliance6Wins Then
            lastMatch = roundIndex
            buildQuarterFinalMatch(roundIndex, String.Format("QF3-{0}", roundIndex), 3, 6)
            roundIndex = roundIndex + 1
        End If

        If alliance4Wins > alliance5Wins Then
            SF_4 = 4
            lastMatch = roundIndex
            buildFirstSemifinalMatches()
        ElseIf alliance4Wins < alliance5Wins Then
            SF_4 = 5
            lastMatch = roundIndex
            buildFirstSemifinalMatches()
        ElseIf alliance4Wins = alliance5Wins Then
            lastMatch = roundIndex
            buildQuarterFinalMatch(roundIndex, String.Format("QF3-{0}", roundIndex), 4, 5)
            roundIndex = roundIndex + 1
        End If

    End Sub

    Shared Sub updateSemifinalMatches(round As Integer)
        Dim SF_1Wins = getWins(SF_1)
        Dim SF_2Wins = getWins(SF_2)
        Dim SF_3Wins = getWins(SF_3)
        Dim SF_4Wins = getWins(SF_4)
        Dim roundIndex As Integer = round + 10

        If SF_1Wins > SF_4Wins Then
            F_1 = SF_1
        ElseIf SF_1Wins < SF_4Wins Then
            F_1 = SF_4
        ElseIf SF_1Wins = SF_4Wins Then
            lastMatch = roundIndex
            buildSemifinalMatch(roundIndex, String.Format("SF3-{0}", roundIndex), SF_1, SF_4)
            roundIndex = roundIndex + 1
        End If

        If SF_2Wins > SF_3Wins Then
            F_2 = SF_2
            lastMatch = roundIndex
            buildFirstFinalMatches()
        ElseIf SF_2Wins < SF_3Wins Then
            F_2 = SF_3
            lastMatch = roundIndex
            buildFirstFinalMatches()
        ElseIf SF_2Wins = SF_3Wins Then
            lastMatch = roundIndex
            buildSemifinalMatch(roundIndex, String.Format("SF3-{0}", roundIndex), SF_2, SF_3)
            roundIndex = round + 1
        End If

    End Sub

    Public Shared Sub updateFinalMatches(round As Integer)
        Dim F_1Wins = getWins(F_1)
        Dim F_2Wins = getWins(F_2)
        Dim roundIndex As Integer = round + 20

        If F_1Wins > F_2Wins Then
            Winner = F_1
            Finalist = F_2
            AudianceDisplay.WinningAlliance.Text = F_1
        ElseIf F_1Wins < F_2Wins Then
            Winner = F_2
            Finalist = F_2
            AudianceDisplay.WinningAlliance.Text = F_2
        ElseIf F_1Wins = F_2Wins Then
            lastMatch = roundIndex
            buildFinalMatch(roundIndex, String.Format("F2-{0}", roundIndex), F_1, F_2)
            roundIndex = roundIndex + 1
        End If
    End Sub

    Public Shared Function getWins(alliance As Integer)
        Dim wins As Integer = 0
        Dim getQuery As String = String.Format("SELECT ([Wins]) FROM alliances Where rank = {0}", alliance)
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