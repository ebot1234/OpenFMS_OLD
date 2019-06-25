Imports System.Net
Imports System.Net.Sockets
Imports System.Threading


Public Class FieldMonitor
    Public Shared FieldMonitorSocket As Socket

    'This sends the data to the Field Monitor program'
    Public Shared Sub sendData(IP As String, Port As Integer, sendData() As Byte)
        FieldMonitorSocket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        Dim endPoint As New IPEndPoint(IP, Port)
        FieldMonitorSocket.SendTo(sendData, endPoint)
        Thread.Sleep(100)
    End Sub

    'This builds the packet being sent to the Field Monitor'
    Public Shared Function encodeFieldData() As Byte()
        Dim data(30) As Byte
        'Sends the team numbers
        data(0) = "1080"
        data(1) = "384"
        data(2) = "1885"
        data(3) = "4444"
        data(4) = "5555"
        data(5) = "6666"
        'Sends the Match Number'
        data(6) = "1"



        Return data
    End Function

    Public Shared Sub handleFieldMonitor()
        While (True)
            sendData("10.0.100.99", 8888, encodeFieldData)
            Thread.Sleep(1000)
        End While

    End Sub
End Class
