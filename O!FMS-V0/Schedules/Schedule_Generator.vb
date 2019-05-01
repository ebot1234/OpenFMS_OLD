Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Sockets
Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports System.IO
Imports O_FMS_V0.Match_Generator



Public Class Schedule_Generator

    Public Shared dir = Match_Generator.Directory.Text = "C:\OFMS"
    'Public Shared fullpath = dir() & "\Teams.txt"
    Public Shared lineCount As Int16 = File.ReadLines("C:\OFMS\teams.txt").Count
    Public Shared matchDir As String = "C:\OFMS\matches.txt"
    Public Shared connection As New SqlConnection("data source=MY-PC\OFMS; Initial Catalog=OpenFMS; Integrated Security = true")

    Public Shared Sub Team_list_gen()
        Dim selectQuery As New SqlCommand("Select Id FROM teaminfo", connection)

        connection.Open()

        Dim myReader As SqlDataReader = selectQuery.ExecuteReader()
        Dim fileName As String = "C:\OFMS\Teams.txt"
        'create a stream object which can write text to a file
        Dim outputStream As StreamWriter = New StreamWriter(fileName)

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
    Public Shared Sub File_Convert()
        Dim i As Int16 = lineCount
        Dim j As Int16 = lineCount
        i = 400
        j = 400
        Dim teams = i
        Dim PlaceHolder(j)


        Dim selectQuery As New SqlCommand("Select Id FROM teaminfo", connection)
        selectQuery.Parameters.Add("team", SqlDbType.Int).Value = teams
        Dim adapter As New SqlDataAdapter(selectQuery)
        Dim table As New DataTable()
        adapter.Fill(table)

        My.Computer.FileSystem.WriteAllText("C:\OFMS\temp.csv", My.Computer.FileSystem.ReadAllText("C:\OFMS\matches.txt").Replace(" ", ","), True)
        'below line not needed
        ' My.Computer.FileSystem.WriteAllText("C:\OFMS\temp.csv", My.Computer.FileSystem.ReadAllText("C:\OFMS\temp.txt").Replace(",0", ""), False)


        MessageBox.Show("Converted File to CSV")
        'Matchgen()

    End Sub

    Shared Function getMatches() As DataTable
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

    Public Shared Sub Matchgen()
        Dim table As New DataTable()
        Dim parser As New FileIO.TextFieldParser("C:\OFMS\temp.csv")

        table.Columns.Add("Match")
        table.Columns.Add("Blue1")
        table.Columns.Add("B1Sur")
        table.Columns.Add("Blue2")
        table.Columns.Add("B2ur")
        table.Columns.Add("Blue3")
        table.Columns.Add("B3Sur")
        table.Columns.Add("Red1")
        table.Columns.Add("R1Sur")
        table.Columns.Add("Red2")
        table.Columns.Add("R2Sur")
        table.Columns.Add("Red3")
        table.Columns.Add("R3Sur")



        parser.Delimiters = New String() {","}
        parser.HasFieldsEnclosedInQuotes = True
        parser.TrimWhiteSpace = True
        parser.ReadLine()

        Do Until parser.EndOfData = True
            table.Rows.Add(parser.ReadFields())
        Loop

        Dim strSql As String = "INSERT INTO matches ([Match], [Blue1], [B1Sur], [Blue2], [B2Sur], [Blue3], [B3Sur], [Red1], [R1Sur], [Red2], [R2Sur], [Red3], [R3Sur])  VALUES (Match, Blue1, B1Sur, Blue2, B2Sur, Blue3, B3Sur, Red1, R1Sur, Red2, R2Sur, Red3, R3Sur)"

        Dim connection As New SqlConnection("data source=MY-PC\OFMS; Initial Catalog=OpenFMS; Integrated Security = true")
        Dim cmd As New SqlClient.SqlCommand(strSql, connection)
        ' With cmd.Parameters
        '.Add("Match", SqlDbType.Int, 8, "Match")
        '.Add("Blue1", SqlDbType.Int, 8, "Blue1")
        '.Add("B1Sur", SqlDbType.Int, 8, "B1Sur")
        '.Add("Blue2", SqlDbType.Int, 8, "Blue2")
        '.Add("B2Sur", SqlDbType.Int, 8, "B2Sur")
        '.Add("Blue3", SqlDbType.Int, 8, "Blue3")
        '.Add("B3Sur", SqlDbType.Int, 8, "B3Sur")
        '.Add("Red1", SqlDbType.Int, 8, "Red1")
        '.Add("R1Sur", SqlDbType.Int, 8, "R1Sur")
        '.Add("Red2", SqlDbType.Int, 8, "Red2")
        '.Add("R2Sur", SqlDbType.Int, 8, "R2Sur")
        '.Add("Red3", SqlDbType.Int, 8, "Red3")
        '.Add("R3Sur", SqlDbType.Int, 8, "R3Sur")

        'End With

        Dim adapter As New SqlClient.SqlDataAdapter()
        adapter.InsertCommand = cmd
        adapter.Update(table)

        ' Dim iRowsInserted As Int32 = adapter.Update(table)


    End Sub

    'Do not use  doesn't account for surogate teams
    Public Shared Sub Matches_to_SQL()

        '--First create a datatable with the same cols as CSV file, the cols order in both should be same
        Dim table As New DataTable()

        table.Columns.Add("Match")
        table.Columns.Add("Blue1")
        table.Columns.Add("B1Sur")
        table.Columns.Add("Blue2")
        table.Columns.Add("B2Sur")
        table.Columns.Add("Blue3")
        table.Columns.Add("B3Sur")
        table.Columns.Add("Red1")
        table.Columns.Add("R1Sur")
        table.Columns.Add("Red2")
        table.Columns.Add("R2Sur")
        table.Columns.Add("Red3")
        table.Columns.Add("R3Sur")


        '--TextField Parser is used to read the files 
        Dim parser As New FileIO.TextFieldParser("C:\OFMS\matches.txt")

        parser.Delimiters = New String() {","} ' fields are separated by comma
        parser.HasFieldsEnclosedInQuotes = False ' each of the values is not enclosed with double quotes
        parser.TrimWhiteSpace = True

        '--First line is skipped , its the header
        parser.ReadLine()


        '-- Add all the rows to datatable
        Do Until parser.EndOfData = True
            table.Rows.Add(parser.ReadFields())


            '--Create SQL query
            Dim strSql As String = "INSERT INTO matches (Match, Blue1, BlSur, Blue2, B2Sur, Blue3, B3Sur, Red1, R1Sur, Red2, R2Sur, Red3, R3Sur) VALUES (@Match, @Blue1, @BlSur, @Blue2, @B2Sur, @Blue3, @B3Sur, @Red1, @R1Sur, @Red2, @R2Sur, @Red3, @R3Sur)"


            Dim connection As New SqlConnection("data source=MY-PC\OFMS; Initial Catalog=OpenFMS; Integrated Security = true")

            Using connection

                Dim cmd As New SqlClient.SqlCommand(strSql, connection) ' create command objects and add parameters
                With cmd.Parameters
                    .Add("@Match", SqlDbType.Int, 8, "Match")
                    .Add("@Blue1", SqlDbType.Int, 8, "Blue1")
                    .Add("@B1Sur", SqlDbType.Int, 8, "B1Sur")
                    .Add("@Blue2", SqlDbType.Int, 8, "Blue2")
                    .Add("@B2Sur", SqlDbType.Int, 8, "B2Sur")
                    .Add("@Blue3", SqlDbType.Int, 8, "Blue3")
                    .Add("@B3Sur", SqlDbType.Int, 8, "B3Sur")
                    .Add("@Red1", SqlDbType.Int, 8, "Red1")
                    .Add("@R1Sur", SqlDbType.Int, 8, "R1Sur")
                    .Add("@Red2", SqlDbType.Int, 8, "Red2")
                    .Add("@R2Sur", SqlDbType.Int, 8, "R2Sur")
                    .Add("@Red3", SqlDbType.Int, 8, "Red3")
                    .Add("@R3Sur", SqlDbType.Int, 8, "R3Sur")
                End With

                Dim adapter As New SqlClient.SqlDataAdapter()
                adapter.InsertCommand = cmd
                adapter.Update(table)
                executeCommand(adapter.ToString())


            End Using
        Loop

    End Sub

    Public Shared Sub executeCommand(input As String)
        Dim command As New SqlCommand(input, connection)
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

    Public Shared Sub addMatches()

        Dim i As Long = 0
        Dim sr As StreamReader = New StreamReader(matchDir)
        Dim line As String = sr.ReadLine()
        Dim dbConn As SqlConnection = New SqlConnection("data source=MY-PC\OFMS; Initial Catalog=O!FMS; Integrated Security = true")
        Dim dbCmd As SqlCommand = New SqlCommand()
        dbCmd.Connection = dbConn
        While Not (sr.EndOfStream)
            line = sr.ReadLine()
            Dim fields() As String = line.Split(",")
            dbCmd.CommandText = "INSERT INTO dbo. matchlist(Match, Blue1, BlSur, Blue2, B2Sur, Blue3, B3Sur, Red1, R1Sur, Red2, R2Sur, Red3, R3Sur) VALUES (@Match, @Blue1, @BlSur, @Blue2, @B2Sur, @Blue3, @B3Sur, @Red1, @R1Sur, @Red2, @R2Sur, @Red3, @R3Sur)"
            dbConn.Open()
            dbCmd.ExecuteNonQuery()
            i = i + 1

        End While
        dbConn.Close()
    End Sub

End Class
