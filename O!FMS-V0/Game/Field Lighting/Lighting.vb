Imports System.Net.Sockets
Imports System.Text
Imports O_FMS_V0.RandomString
'This class is for interating with the led controllers for the 2018 FRC game FIRST POWERUP'

Public Class Lighting
    'lighting packet that is going to be sent'
    Public Shared LightingPacket(32) As Byte
    'UdpClient for the controller'
    Public Shared ControllerConnection As New UdpClient
    'Port Number for the communication to the controllers'
    Public Shared Port As Integer = 5555
    'Varible for using the game data for 2018, for warmup'
    Public Shared GameData = gamedatause
    'Led Types'
    Public Enum LightingModes
        Green
        Purple
        Red
        Blue
        Awards
        Test
        Off
        Owned_Red
        Owned_Blue
        NotOwned
        Red_Force
        Red_Boost
        Red_Levitate
        Blue_Force
        Blue_Boost
        Blue_Levitate
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
            Case LightingModes.Owned_Red
            SendPacket("Red_Owned")
            Case LightingModes.Owned_Blue
            SendPacket("Blue_Owned)
            case LightingModes.NotOwned
                SendPacket("NotOwned")
            Case LightingModes.Blue_Force
                SendPacket("Blue_Force")
            Case LightingModes.Blue_Boost
                SendPacket("Blue_Boost")
            Case LightingModes.Blue_Levitate
                SendPacket("Blue_Levitate")
            Case LightingModes.Red_Levitate
                SendPacket("Red_Levitate")
            Case LightingModes.Red_Force
                SendPacket("Red_Force")
            Case LightingModes.Red_Boost
                SendPacket("Red_Boost")
            Case LightingModes.Purple
                SendPacket("Purple")
            Case LightingModes.Green
                SendPacket("Green")
            Case LightingModes.Red
                SendPacket("Red")
            Case LightingModes.Blue
                SendPacket("Blue")
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
                messageBox.show("Led Controller not connected, check connections and firewalls")
        Else
                'Sends the mode to the controller on port 5555'
            LightingPacket = Encoding.ASCII.GetBytes(mode)
            ControllerConnection.Send(LightingPacket, Port)
        End If
    End Sub
End Class
