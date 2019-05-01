Imports System.Data.SqlClient
Imports O_FMS_V0.AccessPoint
Imports O_FMS_V0.Tba

Public Class TeamAdder

    Dim connection As New SqlConnection("data source=MY-PC\OFMS; Initial Catalog=OpenFMS; Integrated Security = true")
    Dim teamInfo As String = ""
    Dim teamNumber As String = ""


    'Add teams button to sql'
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        wpakey = generateWpaKey()
        teamNumber = formatTeam(TextBox2.Text)
        teamInfo = getTeam(teamNumber)

        Dim insertTeam As String = "INSERT INTO teaminfo ([Id], [Wpa], [Name]) VALUES('" & TextBox2.Text & "', '" & wpakey & "', '" & teamInfo & "')"

        ExecuteQuery(insertTeam)
        TextBox2.Text = ""

        TeamsInfo.DataSource = displayTeams(Nothing)
    End Sub

    Public Sub ExecuteQuery(query As String)
        Dim command As New SqlCommand(query, connection)
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

    Function displayTeams(ByVal ParamArray arrParam() As SqlParameter)
        Dim query As String = "SELECT * FROM teaminfo"
        Dim teamTable As DataTable
        'opens the connection'
        Using connection
            connection.Open()
            'defines the sql command'
            Using cmd = New SqlCommand
                cmd.Connection = connection
                cmd.CommandType = CommandType.Text
                cmd.CommandText = query
                'handles the parameter'
                If arrParam IsNot Nothing Then
                    For Each param As SqlParameter In arrParam
                        cmd.Parameters.Add(param)
                    Next
                End If
                'Fills the data table'
                Using da As New SqlDataAdapter(cmd)
                    teamTable = New DataTable
                    da.Fill(teamTable)
                End Using
            End Using
        End Using
        Return teamTable
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Match_Generator.Show()
        Me.Hide()
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        Dim deleteQuery As String = String.Format("Delete From teaminfo Where Id= {0}", TextBox3.Text)
        ExecuteQuery(deleteQuery)
        Dim data As String = String.Format("Deleted Team:{0}", TextBox3.Text)
        MessageBox.Show(data)
    End Sub
End Class