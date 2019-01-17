Imports O_FMS_V0.Schedule_Generator
Imports System.IO



Public Class Match_Generator
    ' Public dir = Directory.Text = "C:\OFMS"
    Public dir = "C:\OFMS"
    Public fullpath = dir & "\Teams.txt"
    Public lineCount As Int16 = File.ReadLines(dir & "\Teams.txt").Count
    Public numTeams As String
    Public numRounds As String
    Public Quality
    Private Sub Match_Generator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer = 0
        If i = 0 Then
            i = 1
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Team_list_gen()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        If System.IO.File.Exists(dir & "\Teams.txt") Then

        Else : MessageBox.Show("Teams.txt not found")
        End If


        If lineCount = NumTeamsBox.Text Then

        Else : MessageBox.Show("Teams List Count doesn't match selected # of Teams")
        End If
        If matchQuality.Text = "Fair" Then
            Quality = "-f"
        ElseIf matchQuality.Text = "Good" Then
            Quality = "-g"
        ElseIf matchQuality.Text = "Best" Then
            Quality = "-b"
        ElseIf matchQuality.Text = Nothing Then
            MessageBox.Show("Quality not selected")
        End If

        numTeams = NumTeamsBox.Text
        numRounds = NumRoundsBox.Text

        'runs the match maker software with the varibles set from the form
        runMatchMaker()

    End Sub
    Private Sub runMatchMaker()
        Const workingDirectory As String = "C:\OFMS"
        Dim exePath As String = Environment.SystemDirectory & "\cmd.exe"
        Dim startInfo As New ProcessStartInfo(exePath)
        Dim cmdSession As New Process

        Dim command As String = String.Format("MatchMaker -t {0} -r {1} -l teams.txt {2} -u 3 -q -s > matches.txt", numTeams, numRounds, Quality)

        startInfo.UseShellExecute = False
        startInfo.WorkingDirectory = workingDirectory
        startInfo.Arguments = "/C" + command
        cmdSession.StartInfo = startInfo

        cmdSession.Start()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs)
        numTeams = numTeams + 1

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub


End Class