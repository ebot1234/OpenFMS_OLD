Imports O_FMS_V0.PLC_Comms_Server

Public Class Team_Networks
    Public Shared Red1 As String = Main_Panel.RedTeam1.Text
    Public Shared Red2 As String = Main_Panel.RedTeam2.Text
    Public Shared Red3 As String = Main_Panel.RedTeam3.Text
    Public Shared Blue1 As String = Main_Panel.BlueTeam1.Text
    Public Shared Blue2 As String = Main_Panel.BlueTeam2.Text
    Public Shared Blue3 As String = Main_Panel.BlueTeam3.Text
    Public Shared Red1Network As String = String.Empty
    Public Shared Red2Network As String = String.Empty
    Public Shared Red3Network As String = String.Empty
    Public Shared Blue1Network As String = String.Empty
    Public Shared Blue2Network As String = String.Empty
    Public Shared Blue3Network As String = String.Empty
    Public Shared Red1NetworkRobot As String = String.Empty
    Public Shared Red2NetworkRobot As String = String.Empty
    Public Shared Red3NetworkRobot As String = String.Empty
    Public Shared Blue1NetworkRobot As String = String.Empty
    Public Shared Blue2NetworkRobot As String = String.Empty
    Public Shared Blue3NetworkRobot As String = String.Empty
    Public Shared red1length As Integer = Red1.Length
    Public Shared red2length As Integer = Red2.Length
    Public Shared red3length As Integer = Red3.Length
    Public Shared blue1length As Integer = Blue1.Length
    Public Shared blue2length As Integer = Blue2.Length
    Public Shared blue3length As Integer = Blue3.Length
    Public Shared Red1_TE As String = String.Empty
    Public Shared Red1_AM As String = String.Empty
    Public Shared Red2_TE As String = String.Empty
    Public Shared Red2_AM As String = String.Empty
    Public Shared Red3_TE As String = String.Empty
    Public Shared Red3_AM As String = String.Empty
    Public Shared Blue1_TE As String = String.Empty
    Public Shared Blue1_AM As String = String.Empty
    Public Shared Blue2_TE As String = String.Empty
    Public Shared Blue2_AM As String = String.Empty
    Public Shared Blue3_TE As String = String.Empty
    Public Shared Blue3_AM As String = String.Empty


    Public Shared Sub CreateConnections()

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

        Red1Network = ("10." & Red1_TE & "." & Red1_AM & ".5")
        Red1NetworkRobot = ("10." & Red1_TE & "." & Red1_AM & ".2")

        If red2length = 4 Then
            Red2_TE = Red2.Substring(0, 2)
            Red2_AM = Red2.Substring(2, 2)
        ElseIf red2length = 3 Then
            Red2_TE = Red2.Substring(0, 1)
            Red2_AM = Red2.Substring(2, 2)
        ElseIf red2length <= 2 Then
            Red2_TE = 0
            Red2_AM = Red2.Substring(0, 2)
        End If

        Red2Network = ("10." & Red2_TE & "." & Red2_AM & ".5")
        Red2NetworkRobot = ("10." & Red2_TE & "." & Red2_AM & ".2")

        If red3length = 4 Then
            Red3_TE = Red3.Substring(0, 2)
            Red3_AM = Red3.Substring(2, 2)
        ElseIf red3length = 3 Then
            Red3_TE = Red3.Substring(0, 1)
            Red3_AM = Red3.Substring(2, 2)
        ElseIf red3length <= 2 Then
            Red3_TE = 0
            Red3_AM = Red3.Substring(0, 2)
        End If

        Red3Network = ("10." & Red3_TE & "." & Red3_AM & ".5")
        Red3NetworkRobot = ("10." & Red3_TE & "." & Red3_AM & ".2")

        If blue1length = 4 Then
            Blue1_TE = Blue1.Substring(0, 2)
            Blue1_AM = Blue1.Substring(2, 2)
        ElseIf blue1length = 3 Then
            Blue1_TE = Blue1.Substring(0, 1)
            Blue1_AM = Blue1.Substring(2, 2)
        ElseIf blue1length <= 2 Then
            Blue1_TE = 0
            Blue1_AM = Blue1.Substring(0, 2)
        End If

        Blue1Network = ("10." & Blue1_TE & "." & Blue1_AM & ".5")
        Blue1NetworkRobot = ("10." & Blue1_TE & "." & Blue1_AM & ".2")

        If blue2length = 4 Then
            Blue2_TE = Blue2.Substring(0, 2)
            Blue2_AM = Blue2.Substring(2, 2)
        ElseIf blue2length = 3 Then
            Blue2_TE = Blue2.Substring(0, 1)
            Blue2_AM = Blue2.Substring(2, 2)
        ElseIf blue2length <= 2 Then
            Blue2_TE = 0
            Blue2_AM = Blue2.Substring(0, 2)
        End If

        Blue2Network = ("10." & Blue2_TE & "." & Blue2_AM & ".5")
        Blue2NetworkRobot = ("10." & Blue2_TE & "." & Blue2_AM & ".2")

        If blue3length = 4 Then
            Blue3_TE = Blue3.Substring(0, 2)
            Blue3_AM = Blue3.Substring(2, 2)
        ElseIf blue3length = 3 Then
            Blue3_TE = Blue3.Substring(0, 1)
            Blue3_AM = Blue3.Substring(2, 2)
        ElseIf blue3length <= 2 Then
            Blue3_TE = 0
            Blue3_AM = Blue3.Substring(0, 2)
        End If

        Blue3Network = ("10." & Blue3_TE & "." & Blue3_AM & ".5")
        Blue3NetworkRobot = ("10." & Blue3_TE & "." & Blue3_AM & ".2")

    End Sub

    Public Shared Sub pingDSConnections()
        If My.Computer.Network.Ping(Red1Network, 1000) Then
            DS_Linked_Red1 = True
        Else
            DS_Linked_Red1 = False
        End If

        If My.Computer.Network.Ping(Red2Network, 1000) Then
            DS_Linked_Red2 = True
        Else
            DS_Linked_Red2 = False
        End If

        If My.Computer.Network.Ping(Red3Network, 1000) Then
            DS_Linked_Red3 = True
        Else
            DS_Linked_Red3 = False
        End If

        If My.Computer.Network.Ping(Blue1Network, 1000) Then
            DS_Linked_Blue1 = True
        Else
            DS_Linked_Blue1 = False
        End If

        If My.Computer.Network.Ping(Blue2Network, 1000) Then
            DS_Linked_Blue2 = True
        Else
            DS_Linked_Blue2 = False
        End If

        If My.Computer.Network.Ping(Blue3Network, 1000) Then
            DS_Linked_Blue3 = True
        Else
            DS_Linked_Blue3 = False
        End If
    End Sub

    Public Shared Sub pingRobots()
        If My.Computer.Network.Ping(Red1NetworkRobot, 1000) Then
            Robot_Linked_Red1 = True
        Else
            Robot_Linked_Red1 = False
        End If

        If My.Computer.Network.Ping(Red2NetworkRobot, 1000) Then
            Robot_Linked_Red2 = True
        Else
            Robot_Linked_Red2 = False
        End If

        If My.Computer.Network.Ping(Red3NetworkRobot, 1000) Then
            Robot_Linked_Red3 = True
        Else
            Robot_Linked_Red3 = False
        End If

        If My.Computer.Network.Ping(Blue1NetworkRobot, 1000) Then
            Robot_Linked_Blue1 = True
        Else
            Robot_Linked_Blue1 = False
        End If

        If My.Computer.Network.Ping(Blue2NetworkRobot, 1000) Then
            Robot_Linked_Blue2 = True
        Else
            Robot_Linked_Blue2 = False
        End If

        If My.Computer.Network.Ping(Blue3NetworkRobot, 1000) Then
            Robot_Linked_Blue3 = True = True
        Else
            Robot_Linked_Blue3 = False
        End If
    End Sub

End Class
