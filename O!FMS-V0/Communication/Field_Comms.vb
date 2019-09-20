Imports System.Net
Imports System.Net.Sockets
Imports O_FMS_V0.Field

Public Class Field_Comms
    Public Shared teamID
    Public Shared allianceStation As Integer
    Public Shared stationStatus As Integer = 0
    Public Shared dsThread As Threading.Thread

    Public Shared Sub dsConnectThread()
        Dim IpEndPoint As IPEndPoint = New IPEndPoint(IPAddress.Parse("127.0.0.1"), 1750)
        Dim dsListener As New TcpListener(IpEndPoint)

        dsListener.Start()

        While (Field.fieldStatus = Field.MatchEnums.PreMatch)
            Dim TcpClient As TcpClient = dsListener.AcceptTcpClient()

            Dim Buffer(6) As Byte

            TcpClient.GetStream().Read(Buffer, 0, Buffer.Length)

            If Buffer(0) <> 0 And Buffer(1) <> 24 And Buffer(2) <> 3 Then
                TcpClient.Close()
                MessageBox.Show("Client was rejected since inital packet wasn't right")
            End If

            Dim teamid_1 = Buffer(3) << 8
            Dim teamid_2 = Buffer(4)

            teamID = teamid_1 & teamid_2

            Dim TCP_DS_IP = CType(TcpClient.Client.RemoteEndPoint, IPEndPoint).Address
            'Sets the Red DriverStations'
            If Red1DS.Team_Number = teamID Then
                Red1DS.setDsConnections(TCP_DS_IP, TcpClient)
                stationStatus = 0
                allianceStation = 0
            ElseIf Red2DS.Team_Number = teamID Then
                Red2DS.setDsConnections(TCP_DS_IP, TcpClient)
                stationStatus = 0
                allianceStation = 1
            ElseIf Red3DS.Team_Number = teamID Then
                Red3DS.setDsConnections(TCP_DS_IP, TcpClient)
                stationStatus = 0
                allianceStation = 2
                'Sets the Blue DriverStations'
            ElseIf Blue1DS.Team_Number = teamID Then
                Blue1DS.setDsConnections(TCP_DS_IP, TcpClient)
                stationStatus = 0
                allianceStation = 3
            ElseIf Blue2DS.Team_Number = teamID Then
                Blue2DS.setDsConnections(TCP_DS_IP, TcpClient)
                stationStatus = 0
                allianceStation = 4
            ElseIf Blue3DS.Team_Number = teamID Then
                Blue3DS.setDsConnections(TCP_DS_IP, TcpClient)
                stationStatus = 0
                allianceStation = 5
            Else
                'DS Rejected since it is not in the match'
                stationStatus = 1
            End If

            'If the match is running exit the while loop since ds discovery is over'
            If Field.fieldStatus = Field.MatchEnums.SandStorm Or fieldStatus = MatchEnums.TeleOp Or fieldStatus = MatchEnums.EndGameWarning Or fieldStatus =
                MatchEnums.EndGame Or fieldStatus = MatchEnums.AbortMatch Or fieldStatus = MatchEnums.PostMatch Then
                Exit While
            End If

            Dim assignmentPacket(5) As Byte
            assignmentPacket(0) = 0 'packet size'
            assignmentPacket(1) = 3 'packet size'
            assignmentPacket(2) = 25 'packet type'
            assignmentPacket(3) = allianceStation
            assignmentPacket(4) = stationStatus 'station status, need to add station checking'

            TcpClient.GetStream.Write(assignmentPacket, 0, assignmentPacket.Length)

            'If stationStatus = -1 Then
            'TcpClient.Close()
            'End If

        End While

        dsListener.Stop()
    End Sub
End Class
