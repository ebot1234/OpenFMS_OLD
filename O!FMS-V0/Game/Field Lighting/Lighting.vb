Imports System.Net.Sockets
Imports System.Text
'This class is for interating with the led controllers for the 2018 FRC game FIRST POWERUP'

Public Class Lighting
    Public Shared LightingPacket(32) As Byte
    Public Shared ControllerConnection As New UdpClient
    Public Shared Port As Integer = 5555
    Public Enum LightingModes
        Red
        Blue
        Warmup1
        Warmup2
        Awards
        Test
        Off
    End Enum
    'Connects to the controller'
    Public Sub ConnectController(ip As String)
        If ControllerConnection Is Nothing Then
            ControllerConnection.Connect(ip, Port)
        Else
            ControllerConnection.Close()
        End If
    End Sub
    'sets the mode of the leds'
    Public Shared Sub SetMode(LightingModes)
        Select Case (LightingModes)
            Case LightingModes.Red
                SendPacket("Red")
            Case LightingModes.Blue
                SendPacket("Blue")
            Case LightingModes.Warmup1
                SendPacket("Warmup1")
            Case LightingModes.Warmup2
                SendPacket("Warmup2")
            Case LightingModes.Awards
                SendPacket("Awards")
            Case LightingModes.Test
                SendPacket("Test")
            Case LightingModes.Off
                SendPacket("Off")
            Case Else
                LightingModes.Off
        End Select

    End Sub
    'Sends the udp packet containing the mode string to the led controller'
    Public Shared Sub SendPacket(mode As String)
        If ControllerConnection Is Nothing Then
            'Do Nothing'
        Else
            LightingPacket = Encoding.ASCII.GetBytes(mode)
            ControllerConnection.Send(LightingPacket, Port)
        End If
    End Sub
End Class
