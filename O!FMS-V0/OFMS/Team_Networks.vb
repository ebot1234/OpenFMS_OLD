Imports O_FMS_V0.Form1
Imports O_FMS_V0.PLC_Comms_Server

Public Class Team_Networks
    Public Sub Main()
        Dim Red1 As String = Form1.RedTeam1.Text
        Dim red2 As String = Form1.RedTeam2.Text
        Dim red3 As String = Form1.RedTeam3.Text
        Dim blue1 As String = Form1.BlueTeam1.Text
        Dim blue2 As String = Form1.BlueTeam2.Text
        Dim blue3 As String = Form1.BlueTeam3.Text

        Dim red1length As Integer = Red1.Length
        Dim red2length As Integer = red2.Length
        Dim red3length As Integer = red3.Length
        Dim blue1length As Integer = blue1.Length
        Dim blue2length As Integer = blue2.Length
        Dim blue3length As Integer = blue3.Length
        Dim Red1_TE
        Dim Red1_AM
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


        Dim Red2_TE
        Dim Red2_AM
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
        Dim Red3_TE
        Dim Red3_AM
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
        Dim Blue1_TE
        Dim Blue1_AM
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
        Dim Blue2_TE
        Dim Blue2_AM
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

        Dim Blue3_TE
        Dim Blue3_AM
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

        Dim Red1Network As String = ("10." & Red1_TE & "." & Red1_AM & ".")
        Dim Red2Network As String = ("10." & Red2_TE & "." & Red2_AM & ".")
        Dim Red3Network As String = ("10." & Red3_TE & "." & Red3_AM & ".")
        Dim Blue1Network As String = ("10." & Blue1_TE & "." & Blue1_AM & ".")
        Dim Blue2Network As String = ("10." & Blue2_TE & "." & Blue2_AM & ".")
        Dim Blue3Network As String = ("10." & Blue3_TE & "." & Blue3_AM & ".")

        Dim ds = 1
        Dim robot = 2
        If My.Computer.Network.Ping(Red1Network & ds, 1000) Then
            DS_Linked_Red1 = True
        End If
        If My.Computer.Network.Ping(Red2Network & ds, 1000) Then
            DS_Linked_Red2 = True
        End If
        If My.Computer.Network.Ping(Red3Network & ds, 1000) Then
            DS_Linked_Red3 = True
        End If


        If My.Computer.Network.Ping(Red1Network & robot, 1000) Then
            robot_Linked_Red1 = True
        End If
        If My.Computer.Network.Ping(Red2Network & robot, 1000) Then
            robot_Linked_Red2 = True
        End If
        If My.Computer.Network.Ping(Red3Network & robot, 1000) Then
            robot_Linked_Red3 = True
        End If

        If My.Computer.Network.Ping(Blue1Network & ds, 1000) Then
            DS_Linked_blue1 = True
        End If
        If My.Computer.Network.Ping(Blue2Network & ds, 1000) Then
            DS_Linked_blue2 = True
        End If
        If My.Computer.Network.Ping(Blue3Network & ds, 1000) Then
            DS_Linked_blue3 = True
        End If


        If My.Computer.Network.Ping(Blue1Network & robot, 1000) Then
            robot_Linked_blue1 = True
        End If
        If My.Computer.Network.Ping(Blue2Network & robot, 1000) Then
            robot_Linked_blue2 = True
        End If
        If My.Computer.Network.Ping(Blue3Network & robot, 1000) Then
            robot_Linked_blue3 = True
        End If
    End Sub
End Class
