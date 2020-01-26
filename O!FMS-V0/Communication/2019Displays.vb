Imports System.Net
Imports System.Net.Sockets
Imports System.Threading.Thread
Imports O_FMS_V0.Field



Public Class DisplayServer

    Public Shared Sub Server()
        Dim IpEndPoint As IPEndPoint = New IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888)
        Dim displayListener As New TcpListener(IpEndPoint)

        displayListener.Start()

        'Only accepts a display request if its during pre-start'
        While Field.fieldStatus = MatchEnums.PreMatch
            Dim client As TcpClient = displayListener.AcceptTcpClient()
            Dim buffer(5) As Byte

            client.GetStream().Read(buffer, 0, buffer.Length)

            If buffer(0) <> 2 And buffer(1) <> 0 And buffer(2) <> 1 And buffer(3) <> 9 Then
                client.Close()
            End If

            Dim Display_IP = CType(client.Client.RemoteEndPoint, IPEndPoint).Address

            Dim year1 = buffer(0)
            Dim year2 = buffer(1)
            Dim year3 = buffer(2)
            Dim year4 = buffer(3)
            Dim displayType = buffer(4)

            Dim total_year = year1 & year2 & year3 & year4

            If total_year = 2019 Then
                'If the display type is for audience displays'
                If displayType = 0 Then
                    AudienceDisplay.setConnections(Display_IP)
                End If
            End If

        End While
    End Sub
End Class

Public Class Audience2019
    Dim udpClient As UdpClient
    Dim udpClient1 As UdpClient
    Dim endPoint As IPEndPoint
    Public DisplayIP As IPAddress
    Public closed As Boolean = False
    Public audienceDisplaySendThread As Threading.Thread

    Public Sub setConnections(ip As IPAddress)
        DisplayIP = ip
        endPoint = New IPEndPoint(IPAddress.Parse(DisplayIP.ToString), 0)
        udpClient = New UdpClient("127.0.0.1", 8821)
        udpClient1 = New UdpClient("127.0.0.1", 8822)

        Dim thread As New Threading.Thread(AddressOf sendTeamNumbers)
        thread.Start()

        Dim thread2 As New Threading.Thread(AddressOf sendLengths)
        thread2.Start()
    End Sub

    Public Sub sendLengths()
        While True
            Dim data(10) As Byte

            data(0) = CType(Main_Panel.RedTeam1.Text.Length, Integer)

            udpClient1.Send(data, data.Length)

        End While
    End Sub

    'Sends the team numbers'
    Public Sub sendTeamNumbers()
        While True

            Dim send_buffer As [Byte]() = System.Text.Encoding.ASCII.GetBytes(Main_Panel.RedTeam1.Text & Main_Panel.RedTeam2.Text & Main_Panel.RedTeam3.Text &
                Main_Panel.BlueTeam1.Text & Main_Panel.BlueTeam2.Text & Main_Panel.BlueTeam3.Text)


            'Sends the data to the display'
            If udpClient IsNot Nothing Then
                If closed = False Then
                    udpClient.Send(send_buffer, send_buffer.Length)
                Else
                    Sleep(500)
                End If
            End If

        End While
    End Sub


    Public Sub sendTimeAndScore()
        While True
            Dim data(10) As Byte
            Dim rScore As String = Main_Panel.RedScore
            Dim bScore As String = Main_Panel.BlueScore

            data(0) = rScore.Length
            data(1) = bScore.Length

            If rScore.Length > 2 And rScore.Length < 4 Then
                data(2) = rScore.Substring(0, 2)
                data(3) = rScore.Substring(2)
            Else
                data(2) = rScore
            End If

            If bScore.Length > 2 And bScore.Length < 4 Then
                data(4) = bScore.Substring(0, 2)
                data(5) = bScore.Substring(2)
            Else
                data(4) = bScore
            End If

            'Screen Changer'
            If Field.fieldStatus = Field.MatchEnums.PreMatch Then
                data(8) = 0
            ElseIf Field.fieldStatus <> Field.MatchEnums.PreMatch Or fieldStatus <> MatchEnums.PostMatch Or fieldStatus <> MatchEnums.AbortMatch Then
                data(8) = 1
            ElseIf fieldStatus = MatchEnums.PostMatch Then
                data(8) = 2
            End If

            data(9) = Integer.Parse(Main_Panel.matchTimerLbl.Text)

            If closed = False Then
                If udpClient IsNot Nothing Then
                    udpClient.Send(data, data.Length)
                Else
                    Sleep(100)
                End If
            End If
        End While
    End Sub
End Class

Public Class FieldMonitor2019
    Public Sub setConnections(ip As IPAddress, tcpClient As TcpClient)

    End Sub
End Class
