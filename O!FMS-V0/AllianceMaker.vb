Imports System.Data.SqlClient
Imports O_FMS_V0.Elimanation_Matches
Imports O_FMS_V0.Main_Panel

Public Class AllianceMaker
    Dim connection As New SqlConnection("data source=MY-PC\OFMS; Initial Catalog=OpenFMS; Integrated Security = true")

    Public Sub SaveAlliance(team_1 As String, team_2 As String, team_3 As String, rank As Integer, wins As Integer)
        Dim query As String = "INSERT INTO alliances ([team1], [team2], [team3], [rank], [wins]) VALUES('" & team_1 & "', '" & team_2 & "', '" & team_3 & "', '" & rank & "', '" & wins & "')"
        executeQuery(query)
    End Sub

    Public Sub executeQuery(query As String)
        Dim command As New SqlCommand(query, connection)
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveAlliance(TextBox1.Text, TextBox2.Text, TextBox3.Text, 1, 0)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaveAlliance(TextBox24.Text, TextBox23.Text, TextBox22.Text, 2, 0)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SaveAlliance(TextBox21.Text, TextBox18.Text, TextBox15.Text, 3, 0)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SaveAlliance(TextBox12.Text, TextBox9.Text, TextBox6.Text, 4, 0)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SaveAlliance(TextBox20.Text, TextBox17.Text, TextBox14.Text, 5, 0)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        SaveAlliance(TextBox11.Text, TextBox8.Text, TextBox5.Text, 6, 0)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        SaveAlliance(TextBox19.Text, TextBox16.Text, TextBox13.Text, 7, 0)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        SaveAlliance(TextBox4.Text, TextBox7.Text, TextBox10.Text, 8, 0)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        'createFirstMatches()
    End Sub
End Class