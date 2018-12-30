Imports System.Net.Sockets
Imports System.Text
Imports System.Net
'This class is for interating with the led controllers for the 2018 FRC game FIRST POWERUP'

Public Class Lighting

    Public Shared address As String = "10.0.100.23"
    Public Shared port As Integer = 80
    Public Shared socket As Socket

    'Sends the mode string to the led controller through a UDP socket'
    Public Shared Sub setMode(mode As String)
        'Creates the socket for communicating with the led controller'
        socket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        'Address of the led controller set as an EndPoint with the port'
        Dim endPoint As New IPEndPoint(address, port)
        'Byte buffer for sending data'
        Dim send_buffer As [Byte]() = Encoding.ASCII.GetBytes(mode)
        'Sends data to the led controller through the socket'
        socket.SendTo(send_buffer, endPoint)
        'Thread sleeps 100ms for a break'
        Threading.Thread.Sleep(100)
    End Sub
End Class
