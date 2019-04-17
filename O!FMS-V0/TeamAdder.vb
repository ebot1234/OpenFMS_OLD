Imports System.Data.SqlClient

Public Class TeamAdder

    Dim connection As New SqlConnection("data source=MY-PC\OFMS; Initial Catalog=O!FMS; Integrated Security = true")

    'Add teams button to sql'
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim insertTeam As String = "INSERT INTO teaminfo ([Team]) VALUES('" & TextBox2.Text & "')"

        ExecuteQuery(insertTeam)
        MessageBox.Show("Team Added")
    End Sub

    Public Sub ExecuteQuery(query As String)
        Dim command As New SqlCommand(query, connection)
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

End Class