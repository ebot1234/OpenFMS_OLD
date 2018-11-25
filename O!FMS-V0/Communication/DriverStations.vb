Imports O_FMS_V0.Main_Panel
Imports System.Net.Sockets
Imports System.Net
Imports O_FMS_V0.Timing
Imports O_FMS_V0.PLC_Comms_Server
Imports O_FMS_V0.Team_Networks


Public Class DriverStations
    Public packetCount As Integer = 0
    Public DSUpdSendPort As Int32 = 1121
    Public DSUdpReceivePort As Int32 = 1160
    Public Auto As Boolean = False
    Public Enabled As Boolean = False
    Public Estop As Boolean = False
    Public DsConn As New UdpClient
    public DSEndpoint as IPEndPoint

    Public Sub Connect(IP As IPAddress)
        DsConn.Connect(IP, DSUdpReceivePort)
    End Sub

    Public Sub sendPacketDS()
        Dim packet() As Byte = encodeControlPacket()
        If Auto = True Then
            DsConn.Send(packet, packet.Length)
        End If

        If Estop = True Then
            DsConn.Send(packet, packet.Length)
        End If

        If Enabled = True Then
            DsConn.Send(packet, packet.Length)
        End If

    End Sub
    
    public sub ListenForDSUdp()
        'Sets the teamId to zero at beginning of each match'
        dim teamId as integer = 0
        'Driver Station EndPoint to receive any byte data'
        DSEndPoint = new DSEndPoint(System.Net.IPAddress.Any, DSUdpReceivePort)
        'byte for receiving any driver station info'
        dim DSbytes(50) as byte = DsConn.Receive(DSEndPoint)
        'Gets the team id from the DSByte structure'
        teamId = DSBytes(4) << 8 + data(5)
    end sub
    
    Public Function encodeControlPacket()
        Dim data(1024) As Byte

        data(0) = packetCount >> 8 And &HFF
        data(1) = packetCount And &HFF

        data(2) = 0

        data(3) = 0

        If Auto = True Then
            data(3) = &H2
        End If
        If Enabled = True Then
            data(3) = &H4
        End If
        If Estop = True Then
            data(3) = &H80
        End If

        data(4) = 0

        data(5) = 0


        packetCount = packetCount + 1
        Return data
    End Function

End Class
