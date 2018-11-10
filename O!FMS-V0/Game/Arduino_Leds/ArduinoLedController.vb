Imports System.Net.Sockets
Imports System.Net
Imports System.Text
'This class is for sending strings to an Arduino for controlling the leds on the field'
'For 2018 this controls the Switches and Scale leds'

Public Class ArduinoLedController
    Public Shared ArduinoConn As New UdpClient
    Public Shared ArduinoPort As Int32 = 5555
    Public Shared message As String
    Public Shared ip As IPAddress

    Public Sub ConnectArduino(ip)
        ArduinoConn = New UdpClient()
        ArduinoConn.Connect(ip, ArduinoPort)
    End Sub

    Public Sub SendPackets(message As String)
        Dim sendByte As Byte() = Encoding.ASCII.GetBytes(message)
        ArduinoConn.Send(sendByte, sendByte.Length)
    End Sub



End Class
