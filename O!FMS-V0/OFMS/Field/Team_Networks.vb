Imports O_FMS_V0.Main_Panel
Imports O_FMS_V0.PLC_Comms_Server
Imports System.Net

Public Class Team_Networks
    Public Shared Red1Network As String = ("10." & Red1_TE & "." & Red1_AM & ".5")
    Public Shared Red2Network As String = ("10." & Red2_TE & "." & Red2_AM & ".5")
    Public Shared Red3Network As String = ("10." & Red3_TE & "." & Red3_AM & ".5")
    Public Shared Blue1Network As String = ("10." & Blue1_TE & "." & Blue1_AM & ".5")
    Public Shared Blue2Network As String = ("10." & Blue2_TE & "." & Blue2_AM & ".5")
    Public Shared Blue3Network As String = ("10." & Blue3_TE & "." & Blue3_AM & ".5")
    Public Shared Red1RobotIP As String = ("10." & Red1_TE & "." & Red1_AM & ".2")
    Public Shared Red2RobotIP As String = ("10." & Red2_TE & "." & Red2_AM & ".2")
    Public Shared Red3RobotIP As String = ("10." & Red3_TE & "." & Red3_AM & ".2")
    Public Shared Blue1RobotIP As String = ("10." & Blue1_TE & "." & Blue1_AM & ".2")
    Public Shared Blue2RobotIP As String = ("10." & Blue2_TE & "." & Blue2_AM & ".2")
    Public Shared Blue3RobotIP As String = ("10." & Blue3_TE & "." & Blue3_AM & ".2")
    Public Shared Red1Ip As IPAddress = IPAddress.Parse(Red1Network)
    Public Shared Red2Ip As IPAddress = IPAddress.Parse(Red2Network)
    Public Shared Red3Ip As IPAddress = IPAddress.Parse(Red3Network)
    Public Shared Blue1Ip As IPAddress = IPAddress.Parse(Blue1Network)
    Public Shared Blue2Ip As IPAddress = IPAddress.Parse(Blue2Network)
    Public Shared Blue3Ip As IPAddress = IPAddress.Parse(Blue3Network)
    Public Shared Red1 As String = Main_Panel.RedTeam1.Text
    Public Shared red2 As String = Main_Panel.RedTeam2.Text
    Public Shared red3 As String = Main_Panel.RedTeam3.Text
    Public Shared blue1 As String = Main_Panel.BlueTeam1.Text
    Public Shared blue2 As String = Main_Panel.BlueTeam2.Text
    Public Shared blue3 As String = Main_Panel.BlueTeam3.Text

    Public Shared red1length As Integer = Red1.Length
    Public Shared red2length As Integer = red2.Length
    Public Shared red3length As Integer = red3.Length
    Public Shared blue1length As Integer = blue1.Length
    Public Shared blue2length As Integer = blue2.Length
    Public Shared blue3length As Integer = blue3.Length
    Public Shared Red1_TE = 0
    Public Shared Red1_AM = 0
    Public Shared Red2_TE = 0
    Public Shared Red2_AM = 0
    Public Shared Red3_TE = 0
    Public Shared Red3_AM = 0
    Public Shared Blue1_TE = 0
    Public Shared Blue1_AM = 0
    Public Shared Blue3_TE = 0
    Public Shared Blue3_AM = 0
    Public Shared Blue2_TE = 0
    Public Shared Blue2_AM = 0

    Public Shared Sub Main()

        If red1length = 4 Then
            Red1_TE = Red1.Substring(0, 2)
            Red1_AM = Red1.Substring(2, 2)
        ElseIf red1length = 3 Then
            Red1_TE = Red1.Substring(0, 1)
            Red1_AM = Red1.Substring(2, 2)
        ElseIf red1length <= 2 Then
            Red1_TE = 0
            Red1_AM = Red1.Substring(0, 2)
        End If



        If red2length = 4 Then
            Red2_TE = red2.Substring(0, 2)
            Red2_AM = red2.Substring(2, 2)
        ElseIf red2length = 3 Then
            Red2_TE = red2.Substring(0, 1)
            Red2_AM = red2.Substring(2, 2)
        ElseIf red2length <= 2 Then
            Red2_TE = 0
            Red2_AM = red2.Substring(0, 2)
        End If

        If red3length = 4 Then
            Red3_TE = red3.Substring(0, 2)
            Red3_AM = red3.Substring(2, 2)
        ElseIf red3length = 3 Then
            Red3_TE = red3.Substring(0, 1)
            Red3_AM = red3.Substring(2, 2)
        ElseIf red3length <= 2 Then
            Red3_TE = 0
            Red3_AM = red3.Substring(0, 2)
        End If

        If blue1length = 4 Then
            Blue1_TE = blue1.Substring(0, 2)
            Blue1_AM = blue1.Substring(2, 2)
        ElseIf blue1length = 3 Then
            Blue1_TE = blue1.Substring(0, 1)
            Blue1_AM = blue1.Substring(2, 2)
        ElseIf blue1length <= 2 Then
            Blue1_TE = 0
            Blue1_AM = blue1.Substring(0, 2)
        End If

        If blue2length = 4 Then
            Blue2_TE = blue2.Substring(0, 2)
            Blue2_AM = blue2.Substring(2, 2)
        ElseIf blue2length = 3 Then
            Blue2_TE = blue2.Substring(0, 1)
            Blue2_AM = blue2.Substring(2, 2)
        ElseIf blue2length <= 2 Then
            Blue2_TE = 0
            Blue2_AM = blue2.Substring(0, 2)
        End If


        If blue3length = 4 Then
            Blue3_TE = blue3.Substring(0, 2)
            Blue3_AM = blue3.Substring(2, 2)
        ElseIf blue3length = 3 Then
            Blue3_TE = blue3.Substring(0, 1)
            Blue3_AM = blue3.Substring(2, 2)
        ElseIf blue3length <= 2 Then
            Blue3_TE = 0
            Blue3_AM = blue3.Substring(0, 2)
        End If


        Dim ds = 5
        Dim robot = 2
        If My.Computer.Network.Ping(Red1Network & ds, 1000) Then
            DS_Linked_Red1 = True
        Else
            DS_Linked_Red1 = False
        End If
        If My.Computer.Network.Ping(Red2Network & ds, 1000) Then
            DS_Linked_Red2 = True
        End If
        If My.Computer.Network.Ping(Red3Network & ds, 1000) Then
            DS_Linked_Red3 = True
        End If


        If My.Computer.Network.Ping(Red1Network & robot, 1000) Then
            Robot_Linked_Red1 = True
        End If
        If My.Computer.Network.Ping(Red2Network & robot, 1000) Then
            Robot_Linked_Red2 = True
        End If
        If My.Computer.Network.Ping(Red3Network & robot, 1000) Then
            Robot_Linked_Red3 = True
        End If

        If My.Computer.Network.Ping(Blue1Network & ds, 1000) Then
            DS_Linked_Blue1 = True
        End If
        If My.Computer.Network.Ping(Blue2Network & ds, 1000) Then
            DS_Linked_Blue2 = True
        End If
        If My.Computer.Network.Ping(Blue3Network & ds, 1000) Then
            DS_Linked_Blue3 = True
        End If


        If My.Computer.Network.Ping(Blue1Network & robot, 1000) Then
            Robot_Linked_Blue1 = True
        End If
        If My.Computer.Network.Ping(Blue2Network & robot, 1000) Then
            Robot_Linked_Blue2 = True
        End If
        If My.Computer.Network.Ping(Blue3Network & robot, 1000) Then
            Robot_Linked_Blue3 = True
        End If
    End Sub
End Class
