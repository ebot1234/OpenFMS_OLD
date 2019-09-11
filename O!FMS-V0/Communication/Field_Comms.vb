Imports System.Net
Imports System.Net.Sockets

Public Class Field_Comms
    Public Shared teamID
    Public Shared r As Integer
    Public Shared b As Integer
    Public Shared redAlliance As DriverStations()
    Public Shared blueAlliance As DriverStations()
    Public Shared allianceStation As Integer
    Public Shared stationStatus As Integer

    Public Shared Sub dsConnectThread()
        Dim IpEndPoint As IPEndPoint = New IPEndPoint(IPAddress.Parse("127.0.0.1"), 1750)
        Dim dsListener As TcpListener = New TcpListener(IpEndPoint)

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

            Dim stationStatus As Integer = -1

            Dim TCP_DS_IP = CType(TcpClient.Client.RemoteEndPoint, IPEndPoint).Address
            'Sets the Red DriverStations'
            For r = 0 To 3
                If redAlliance(b).TeamNum = teamID Then
                    redAlliance(b).setDsConnections(TCP_DS_IP, TcpClient)
                End If

            Next
            'Sets the Blue DriverStations'
            For b = 0 To 3
                If blueAlliance(b).TeamNum = teamID Then
                    blueAlliance(b).setDsConnections(TCP_DS_IP, TcpClient)
                End If

            Next

            If Field.fieldStatus <> Field.MatchEnums.PreMatch Then
                Exit While
            End If

            stationStatus = 0

            For r = 0 To 3
                allianceStation = r
                Dim assignmentPacket(5) As Byte
                assignmentPacket(0) = 0 'packet size'
                assignmentPacket(1) = 3 'packet size'
                assignmentPacket(2) = 25 'packet type'
                assignmentPacket(3) = allianceStation
                assignmentPacket(4) = stationStatus 'station status, need to add station checking'

                TcpClient.GetStream.Write(assignmentPacket, 0, assignmentPacket.Length)
            Next

            For b = 0 To 3
                allianceStation = b
                Dim assignmentPacket(5) As Byte
                assignmentPacket(0) = 0 'packet size'
                assignmentPacket(1) = 3 'packet size'
                assignmentPacket(2) = 25 'packet type'
                assignmentPacket(3) = allianceStation
                assignmentPacket(4) = stationStatus 'station status, need to add station checking'

                TcpClient.GetStream.Write(assignmentPacket, 0, assignmentPacket.Length)
            Next


            If stationStatus = -1 Then
                TcpClient.Close()
            End If

        End While

        dsListener.Stop()
    End Sub
End Class
