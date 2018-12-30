Imports System.Net.Sockets
Imports System.Text
Imports System.Net
Imports O_FMS_V0.RandomString
'This class is for interating with the led controllers for the 2018 FRC game FIRST POWERUP'

Public Class Lighting

    Public Shared Sub setMode(mode As String)
        'Creates the socket for communicating with the led controller'
        Dim socket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        'Address of the led controller set as an EndPoint with the port'
        Dim serverAddress As IPAddress = IPAddress.Parse("10.0.100.23")
        Dim endPoint As New IPEndPoint(serverAddress, 80)
        'Byte buffer for sending data'
        Dim send_buffer As [Byte]() = Encoding.ASCII.GetBytes(mode)
        'Sends data to the led controller through the socket'
        socket.SendTo(send_buffer, endPoint)
        'Thread sleeps 100ms for a break'
        Threading.Thread.Sleep(100)
    End Sub
End Class
