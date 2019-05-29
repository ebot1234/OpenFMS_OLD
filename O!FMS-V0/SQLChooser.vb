Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class SQLChooser
    Public Shared DBServerName As String
    Public Shared DBInstanceName As String
    Public Shared DBConnectionString As String
    Public Shared dr As DataRow

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dt As DataTable = SqlDataSourceEnumerator.Instance.GetDataSources
        For Each dr In dt.Rows
            DBInstances.Items.Add(String.Concat(dr("InstanceName")))
            DBInstances.Text = "Select an Instance"
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DBServerName = dr("ServerName")
        DBInstanceName = dr("InstanceName")
        DBConnectionString = String.Format("data source=" & DBServerName & "\" & DBInstanceName & "; Initial Catalog=OpenFMS; Integrated Security= True")
        Me.Hide()
        Startup_Screen.Show()
    End Sub

    Public Shared Sub createSQLDatabase(folderLocation As String, name As String)
        Dim connectionString As String = "data source=" & DBServerName & "\" & DBInstanceName & "; Initial Catalog=master; Integerated Security= True"
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim cmd As SqlCommand = connection.CreateCommand
            Dim str As String = "CREATE Database {0} ON (Name= N'{0}', FILENAME='{1}\{0}.mdf')"
            cmd.CommandText = String.Format(str, name, folderLocation)
            cmd.ExecuteNonQuery()
        End Using
    End Sub
End Class