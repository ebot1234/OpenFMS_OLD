Imports System.Net.Sockets
Imports System.Text
Imports System.Net
'This class is for interating with the led controllers for the 2018 FRC game FIRST POWERUP'

Public Class Lighting
    Public Shared Sub sendClearScale()
        Dim socket As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        Dim address As IPAddress = IPAddress.Parse("10.0.100.23")
        Dim endPoint As New IPEndPoint(address, 80)
        Dim sendByte(1) As Byte
        sendByte(0) = &H0
        sendByte(1) = &H0

        socket.SendTo(sendByte, endPoint)
    End Sub

    'Sends the mode string to the led controller through a UDP socket'
    Public Shared Sub setModeScale(mode As String)
        'Creates the socket for communicating with the led controller'
        Dim Socket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        'Address of the led controller set as an EndPoint with the port'
        Dim serverAddress As IPAddress = IPAddress.Parse("10.0.100.23")
        Dim port As Integer = 80
        Dim endPoint As New IPEndPoint(serverAddress, port)
        'Byte buffer for sending data'
        Dim send_buffer As [Byte]() = Encoding.ASCII.GetBytes(mode)
        'Sends data to the led controller through the socket'
        Socket.SendTo(send_buffer, endPoint)
        'Thread sleeps 100ms for a break'
        Threading.Thread.Sleep(100)
    End Sub
End Class
