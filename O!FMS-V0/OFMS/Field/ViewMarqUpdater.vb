Imports System.Net.Sockets
Imports System.Net
Imports System.Text

Public Class ViewMarqUpdater
    'Team number varibles'
    Public Shared team1
    Public Shared team2
    Public Shared team3
    'Match timer varible'
    Public Shared time
    'Viewmarq Specfic varibles'
    Public Shared viewmarq As TcpClient
    Public Shared viewmarqCommand As String
    Public Shared viewmarqIpAddress As String = "10.0.100.30"
    Public Shared viewmarqPort As Integer = 1080

    Public Shared Sub makeCommand(team1, team2, team3)
        'default command to send to the viewmarq'
        viewmarqCommand = String.Format("<ID 0><CLR><WIN 0 0 287 31><POS 0 0><LJ><BL N><CS 0><GRN><DEC 1 4 {0}><DEC 1 4 {1}><DEC 1 4 {2}>", team1, team2, team3)

    End Sub

    Public Shared Sub sendCommand()
        makeCommand(team1, team2, team3)
        viewmarq = New TcpClient()

        viewmarq.Connect(viewmarqIpAddress, viewmarqPort)

        Dim networkStream As NetworkStream = viewmarq.GetStream()
        Dim sendCommand As [Byte]() = Encoding.ASCII.GetBytes(viewmarqCommand)

        If networkStream.CanWrite Then
            networkStream.Write(sendCommand, 0, sendCommand.Length)
        End If

        'Flushes the viewmarqs network stream'
        networkStream.Flush()
    End Sub

End Class
