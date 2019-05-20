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
    Shared wins

    Shared QF1_win
    Shared QF2_win
    Shared QF3_win
    Shared QF4_win

    Shared SF1_Tie_breaker As Boolean = False
    Shared SF2_Tie_breaker As Boolean = False

    Shared SF1_Win
    Shared SF2_Win

    Shared F_Win
    Shared F_Tie_Breaker



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

    Public Shared Function buildElimanationMatch(round As Integer, group As Integer, numAlliances As Integer)
        If numAlliances < 2 Then
            MessageBox.Show("Too little alliances")
        End If

        Dim redAlliance(3) As Integer
        Dim blueAlliance(3) As Integer

        If numAlliances < 4 * round Then
            Dim matchups() As Integer = {1, 16, 8, 9, 4, 13, 5, 12, 2, 15, 7, 10, 3, 14, 6, 11}
            Dim factor = Len(matchups) / round
            Dim redAllianceNumber = matchups((group - 1) * factor)
            Dim blueAllianceNumber = matchups((group - 1) * factor + factor / 2)
            Dim numDirectAlliances = 4 * round - numAlliances

            If redAllianceNumber <= numDirectAlliances Then
                redAlliance(0) = getAllianceTeam(redAllianceNumber, 1)
                redAlliance(1) = getAllianceTeam(redAllianceNumber, 2)
                redAlliance(2) = getAllianceTeam(redAllianceNumber, 3)
            End If

            If blueAllianceNumber <= numDirectAlliances Then
                blueAlliance(0) = getAllianceTeam(blueAllianceNumber, 1)
                blueAlliance(1) = getAllianceTeam(blueAllianceNumber, 2)
                blueAlliance(2) = getAllianceTeam(blueAllianceNumber, 3)
            End If
        End If

        If Len(redAlliance) = 0 Then
            redAlliance = buildElimanationMatch(round * 2, group * 2 - 1, numAlliances)
        End If

        If Len(blueAlliance) = 0 Then
            blueAlliance = buildElimanationMatch(round * 2, group * 2 - 1, numAlliances)
        End If


        If Len(redAlliance) = 0 And Len(blueAlliance) = 0 Then
            Return Nothing
        End If

        Dim redWins As Integer
        Dim blueWins As Integer
        Dim numIncomplete As Integer
        'Fix this ties definition'
        Dim ties As Integer
        Dim matches = GetMatchesByElimGroup(round, group)

        If matches IsNot Nothing Then
            Return Nothing
        End If
        'fix this defiinition
        Dim unplayedMatches

        For Each Match In matches
            If Field.fieldStatus <> Field.MatchEnums.Complete Then
                If Len(redAlliance) <> 0 Then
                    positionRedTeams(redAlliance)
                    'Save Match'
                End If

                If Len(blueAlliance) <> 0 Then
                    positionBlueTeams(blueAlliance)
                    'Save Match'
                End If

                unplayedMatches = Match
                numIncomplete += 1
            End If

            reorderTeams(team1, team2, team3, redAlliance)
            reorderTeams(team4, team5, team6, blueAlliance)

            Select Case Match.Winner
                Case "R"
                    redWins += 1
                Case "B"
                    blueWins += 1
                Case "T"
                    ties = Match
                Case Else
                    MessageBox.Show("Match has no winner this is a problem")
            End Select
        Next

        If redWins = 2 Or blueWins = 2 Then
            For Each Match In unplayedMatches
                'Delete Match'  

                If redWins = 2 Then
                    Return redAlliance
                Else
                    Return blueAlliance
                End If
            Next
        End If

        If Len(matches) = 0 Or Len(ties) = 0 And numIncomplete = 0 Then
            If Len(redAlliance) = 0 Then
                redAlliance = {0, 0, 0}
            ElseIf Len(blueAlliance) = 0 Then
                blueAlliance = {0, 0, 0}
            End If

            If Len(redAlliance) < 3 Or Len(blueAlliance) < 3 Then
                MessageBox.Show("An alliance must have at least 3 teams")
            End If

            If Len(matches) < 1 Then
                'Create match'
            End If

            If Len(matches) < 2 Then
                'Create match
            End If

            If Len(matches) < 3 Then
                'Create match
            End If
        End If

        If numIncomplete = 0 Then
            For index As Integer = 0 To ties
                'Create match CreateMatch(createMatch(roundName, round, group, len(matches)+index+1, redAlliance, blueAlliance))
            Next
        End If

        Return Nothing
    End Function

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

    Public Shared Sub createMatch(roundName As String, round As Integer, group As Integer, instance As Integer, redAlliance() As Integer, blueAlliance() As Integer)
        Dim matchs = 

    End Sub

    Public Shared Function reorderTeams(t1 As Integer, t2 As Integer, t3 As Integer, alliance() As Integer)
        Return 0
    End Function

    Shared Function GetMatchesByElimGroup(round As Integer, group As String)

    End Function

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
