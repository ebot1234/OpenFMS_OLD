Imports System.Net.Sockets
Imports System.Text
Imports System.Net
Imports O_FMS_V0.RandomString
'This class is for interating with the led controllers for the 2018 FRC game FIRST POWERUP'

Public Class Lighting
    Public Shared Sub MainLighting()
        Dim socket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        MessageBox.Show("Created Socket for Arduino")
        Dim serverAddress As IPAddress = IPAddress.Parse("10.0.100.23")
        Dim endPoint As New IPEndPoint(serverAddress, 80)

        Dim message As String = "hello"

        Dim send_buffer As [Byte]() = Encoding.ASCII.GetBytes(message)

        socket.SendTo(send_buffer, endPoint)
        MessageBox.Show("Sent Hello")
        Threading.Thread.Sleep(100)
    End Sub
End Class
