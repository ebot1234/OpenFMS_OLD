Imports System.Net
Imports System.Net.Sockets
Imports System.Text.Encoding

Public Class Field_Lighting
    Public Shared Led_Address As String
    Public Shared Led_IP As IPAddress
    Public Shared Port As Integer = 9999
    Public Shared Client As UdpClient
    Public Shared Led_Mode

    Structure Led_Modes
        Public Shared RedMode = "R"
        Public Shared BlueMode = "B"
        Public Shared GreenMode = "G"
        Public Shared Red_Stage_Ready = "RR"
        Public Shared Blue_Stage_Ready = "BR"
    End Structure

    Public Sub changeMode(ByVal mode As Led_Modes)
        updateLedController(mode)
    End Sub

    Public Sub updateLedController(mode As Object)
        Dim Socket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        Dim EndPoint As New IPEndPoint(Led_IP, Port)
        Dim send_buffer As [Byte]() = ASCII.GetBytes(mode)

        Socket.SendTo(send_buffer, EndPoint)
    End Sub
End Class
