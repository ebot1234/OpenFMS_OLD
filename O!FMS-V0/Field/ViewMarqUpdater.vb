Imports System.Net.Sockets
Imports System.Net
Imports System.Text

Public Class ViewMarqUpdater
    Public Shared Sub sendCustomMessage(message As String)
        Dim Socket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        Dim serverAddress As IPAddress = IPAddress.Parse("192.168.1.9")
        Dim port As Integer = 5565
        Dim endPoint As New IPEndPoint(serverAddress, port)
        'Byte buffer for sending data'
        Dim send_buffer As [Byte]() = Encoding.ASCII.GetBytes(message)
        Socket.SendTo(send_buffer, endPoint)
    End Sub

    Public Shared Sub sendTime(data As String)
        Dim client As New UdpClient
        Dim port As Integer = 5555
        Dim endPoint As New IPEndPoint(IPAddress.Parse("192.168.1.9"), port)
        Dim bytes(1) As Byte
        bytes(0) = data
        client.Send(bytes, bytes.Length, endPoint)
    End Sub

    Public Shared Sub sendTeams()

    End Sub

End Class
