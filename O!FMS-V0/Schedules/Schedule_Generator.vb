Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Sockets
Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports System.IO
Imports O_FMS_V0.Match_Generator



Public Class Schedule_Generator

    Public Shared dir = Match_Generator.TeamListDir.Text = "C:\OFMS"
    'Public Shared fullpath = dir() & "\Teams.txt"
    Public Shared lineCount As Int16 = File.ReadLines("C:\OFMS\teams.txt").Count
    Public Shared matchDir As String = "C:\OFMS\matches.txt"
    Public Shared connection As New SqlConnection("data source=MY-PC\OFMS; Initial Catalog=OpenFMS; Integrated Security = true")
    Public Shared name As String = ""

    'This generates the team list for matches'
    Public Shared Sub Team_list_gen(filePath As String)
        Dim selectQuery As New SqlCommand("Select Id FROM teaminfo", connection)

        connection.Open()

        Dim myReader As SqlDataReader = selectQuery.ExecuteReader()

        'create a stream object which can write text to a file
        Dim outputStream As StreamWriter = New StreamWriter(filePath + "\teams.txt")

        Do While myReader.Read
            Dim values(myReader.FieldCount - 1) As Object
            'get all the field values
            myReader.GetValues(values)

            'write the text of each value to a comma seperated string
            Dim line As String = String.Join(",", values)
            outputStream.WriteLine(line)
        Loop
        myReader.Close()
        outputStream.Close()
        connection.Close()
        'teamlistdone = True
    End Sub

    'This adds the generated matches to SQL'
    Shared Function getMatches() As DataTable

        'This deletes the previous matches so they don't over lap'
        Dim deletePrev As String = "Delete From matches"
        ExecuteQuery(deletePrev)

        Dim table As New DataTable

        table.Columns.Add("Match", GetType(String))
        table.Columns.Add("Blue1", GetType(String))
        table.Columns.Add("B1Sur", GetType(String))
        table.Columns.Add("Blue2", GetType(String))
        table.Columns.Add("B2ur", GetType(String))
        table.Columns.Add("Blue3", GetType(String))
        table.Columns.Add("B3Sur", GetType(String))
        table.Columns.Add("Red1", GetType(String))
        table.Columns.Add("R1Sur", GetType(String))
        table.Columns.Add("Red2", GetType(String))
        table.Columns.Add("R2Sur", GetType(String))
        table.Columns.Add("Red3", GetType(String))
        table.Columns.Add("R3Sur", GetType(String))

        Dim FileName As String = "C:\OFMS\matches.txt"
        Dim Stream As StreamReader = New StreamReader(FileName)
        Dim lines = File.ReadAllLines(FileName)
        Dim line As String

        For Each line In lines
            table.Rows.Add(line.Split(" "))
        Next

        'match table varibles'
        Dim amount As Integer = 0
        Dim matchNum As String
        Dim blue1 As String
        Dim b1Sur As String
        Dim blue2 As String
        Dim b2Sur As String
        Dim blue3 As String
        Dim b3Sur As String
        Dim red1 As String
        Dim r1Sur As String
        Dim red2 As String
        Dim r2Sur As String
        Dim red3 As String
        Dim r3Sur As String

        For Each row In table.Rows
            matchNum = table.Rows(amount)(0).ToString()
            blue1 = table.Rows(amount)(1).ToString()
            b1Sur = table.Rows(amount)(2).ToString()
            blue2 = table.Rows(amount)(3).ToString()
            b2Sur = table.Rows(amount)(4).ToString()
            blue3 = table.Rows(amount)(5).ToString()
            b3Sur = table.Rows(amount)(6).ToString()
            red1 = table.Rows(amount)(7).ToString()
            r1Sur = table.Rows(amount)(8).ToString()
            red2 = table.Rows(amount)(9).ToString()
            r2Sur = table.Rows(amount)(10).ToString()
            red3 = table.Rows(amount)(11).ToString()
            r3Sur = table.Rows(amount)(12).ToString()

            Dim query As String = "INSERT INTO matches ([Match], [Blue1], [B1Sur], [Blue2], [B2Sur], [Blue3], [B3Sur], [Red1], [R1Sur], [Red2], [R2Sur], [Red3], [R3Sur])  VALUES ('" & matchNum & "', '" & blue1 & "', '" & b1Sur & "', '" & blue2 & "', '" & b2Sur & "', '" & blue3 & "', '" & b3Sur & "', '" & red1 & "', '" & r1Sur & "', '" & red2 & "', '" & r2Sur & "', '" & red3 & "', '" & r3Sur & "')"
            ExecuteQuery(query)

            amount = amount + 1
        Next

        Return table
    End Function


    Shared Sub ExecuteQuery(query As String)
        Dim command As New SqlCommand(query, connection)
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

    Shared Function getTeamName(teamNumber As String)
        Dim selectQuery As String = String.Format("Select name From teaminfo Where Id={0}", teamNumber)
        Dim selectData As New SqlCommand(selectQuery, connection)
        Dim adapter As New SqlDataAdapter(selectData)
        Dim table As New DataTable()
        adapter.Fill(table)

        If table.Rows.Count > 0 Then
            name = table.Rows(0)(0)
        End If

        Return Name
    End Function

End Class
