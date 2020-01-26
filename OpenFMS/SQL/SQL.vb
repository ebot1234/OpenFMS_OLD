Imports System.Data.SqlClient


'This Class Implements Any Functions Used By OpenFMS For SQL Database Management'
Public Class SQL
    Public Shared SQL_Connection As New SqlConnection("data source=data source=MY-PC\OFMS; Initial Catalog=OpenFMS; Integrated Security = true")
    Public Enum winners
        Red
        Blue
        Unknown
    End Enum

    'Loads Match Data From SQL Database'
    Public Shared Sub SQL_loadMatch(match_num As Integer)
        Dim select_query As New SqlCommand("Match, Blue1, B1Sur, Blue2, B2Sur, Blue3, B3Sur, Red1, R1Sur, Red2, R2Sur, Red3, R3Sur FROM matches where Match= @Matchnum", SQL_Connection)
        select_query.Parameters.Add("@Matchnum", SqlDbType.Int).Value = match_num

        Dim adapter As New SqlDataAdapter(select_query)
        Dim table As New DataTable()
        adapter.Fill(table)

        If table.Rows.Count() <> 0 Then
            'Add FCUI lables'
        Else
            MessageBox.Show("Match Data Not Loaded")
        End If
    End Sub

    'Publishes Normal Matches To SQL Database'
    Public Shared Sub SQL_Publish_Match(match_num As Integer, red1 As Integer, red2 As Integer, red3 As Integer, blue1 As Integer, blue2 As Integer, blue3 As Integer, red_score As Integer, blue_score As Integer, winner As winners)
        'Dim insert_query = "INSERT INTO ElimanationResults([alliance1], [alliance2], [round], [type], [red1], [red2], [red3], [blue1], [blue2], [blue3], [redscore], [bluescore]) VALUES('" & alliance1 & "', '" & alliance2 & "', '" & MatchNum.Text & "', '" & type & "', '" & RedTeam1.Text & "', '" & RedTeam2.Text & "', '" & RedTeam3.Text & "', '" & BlueTeam1.Text & "', '" & BlueTeam2.Text & "', '" & BlueTeam3.Text & "', '" & RedScoreLbl.Text & "', '" & BlueScoreLbl.Text & "')"
        'ExecuteQuery(insert_query)
    End Sub

    'Executes Any SQL Command'
    Public Shared Sub ExecuteQuery(query_str)
        Dim command As New SqlCommand(query_str, SQL_Connection)
        SQL_Connection.Open()
        command.ExecuteNonQuery()
        SQL_Connection.Close()
    End Sub

    'Creates The Match Score Table'
    Public Shared Sub CreateMatchTable()

    End Sub

    'Creates The Schedule Table'
    Public Shared Sub CreateScheduleTable()

    End Sub

    'Creates The Elimination Match Table'
    Public Shared Sub CreateEliminationTable()

    End Sub


End Class
