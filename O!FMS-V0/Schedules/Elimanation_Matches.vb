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
    Shared QF1_Winner
    Shared QF2_Winner
    Shared QF3_Winner
    Shared QF4_Winner

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

    Shared Function getUnplayedMatches()
        Dim match = ""
        Dim query As String = "SELECT * FROM ElimanationResults Where Status = Complete"
        Dim selectData As New SqlCommand(query, connection)
        Dim adapter As New SqlDataAdapter(selectData)
        Dim table As New DataTable()
        adapter.Fill(table)

        If table.Rows.Count > 0 Then
            match = table.Rows(0)(11)
        End If

        Return match
    End Function

    'This creates all the first elimanation matches to start the elimanation matches'
    Public Shared Sub createFirstElimanationMatches()
        buildQuarterFinalMatch(1, "QF-1", 1, 8)
        buildQuarterFinalMatch(2, "QF-2", 2, 7)
        buildQuarterFinalMatch(3, "QF-3", 3, 6)
        buildQuarterFinalMatch(4, "QF-4", 4, 5)
        buildQuarterFinalMatch(5, "QF-5", 1, 8)
        buildQuarterFinalMatch(6, "QF-6", 2, 7)
        buildQuarterFinalMatch(7, "QF-7", 3, 6)
        buildQuarterFinalMatch(8, "QF-8", 4, 5)
    End Sub

    Public Shared Sub updateQuarterFinalMatches()
        Dim alliance1Wins = getWins(1)
        Dim alliance2Wins = getWins(2)
        Dim alliance3Wins = getWins(3)
        Dim alliance4Wins = getWins(4)
        Dim alliance5Wins = getWins(5)
        Dim alliance6Wins = getWins(6)
        Dim alliance7Wins = getWins(7)
        Dim alliance8Wins = getWins(8)

        If alliance1Wins > alliance2Wins Then

        End If

    End Sub

    Public Shared Function getWins(alliance1 As Integer)
        Dim wins As Integer = 0
        Dim getQuery As String = String.Format("SELECT ([Wins]) FROM alliances Where alliance = {0}", alliance1)
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
        team1 = getAllianceTeam(alliance1, 1)
        team2 = getAllianceTeam(alliance1, 2)
        team3 = getAllianceTeam(alliance1, 3)
        team4 = getAllianceTeam(alliance2, 1)
        team5 = getAllianceTeam(alliance2, 2)
        team6 = getAllianceTeam(alliance2, 3)

        Dim insertQuery As String = ""
        insertQuery = "INSERT INTO elimanation ([type], [round], [red1], [red2], [red3], [blue1], [blue2], [blue3]) VALUES ('" & type & "', '" & round & "', '" & team1 & "', '" & team2 & "', '" & team3 & "', '" & team4 & "', '" & team5 & "', '" & team6 & "')"

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
        insertQuery = "INSERT INTO elimanation ([type], [round], [red1], [red2], [red3], [blue1], [blue2], [blue3]) VALUES ('" & type & "', '" & round & "', '" & team1 & "', '" & team2 & "', '" & team3 & "', '" & team4 & "', '" & team5 & "', '" & team6 & "')"

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
        insertQuery = "INSERT INTO elimanation ([type], [round], [red1], [red2], [red3], [blue1], [blue2], [blue3]) VALUES ('" & type & "', '" & round & "', '" & team1 & "', '" & team2 & "', '" & team3 & "', '" & team4 & "', '" & team5 & "', '" & team6 & "')"

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
