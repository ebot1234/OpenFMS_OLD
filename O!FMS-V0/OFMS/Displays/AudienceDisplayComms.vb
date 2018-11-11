Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports O_FMS_V0.Field

Public Class AudienceDisplayComms
    Public Shared AudienceDisplayConn As UdpClient
    Public Shared AudiencePort As Int32 = 5520
    Public Shared AudienceIP As String = "10.0.0.210"
    Public Shared AudienceNetwork As IPAddress = IPAddress.Parse(AudienceIP)

    Public Shared Sub ConnectAudienceDisplay()
        AudienceDisplayConn = New UdpClient
        AudienceDisplayConn.Connect(AudienceNetwork, AudiencePort)
    End Sub

    Public Shared Sub ChangeAudienceMode(AudienceMode As String)
        Dim sendByte As Byte() = Encoding.ASCII.GetBytes(AudienceMode)
        AudienceDisplayConn.Send(sendByte, sendByte.Length)
    End Sub

    Public Shared Sub UpdateAudienceDisplay()

    End Sub
End Class
