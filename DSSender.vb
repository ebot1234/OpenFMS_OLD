Imports Microsoft.VisualBasic
Imports OFMS.FieldAndRobots
Imports OFMS.GovernThread
Imports OFMS.Main.gameData
Imports OFMS.Team
Imports java.io.IOException
Imports java.net.DatagramPacket
Imports java.net.DatagramSocket
Imports java.net.InetAddress
Imports java.net.SocketException
Imports java.nio.ByteBuffer
Imports java.util.ArrayList
Imports java.util.List
Imports java.util.zip.CRC32
Imports Game.RandomString
Imports java.util.Random
Public Class DSSender

    Private Shared _instance As DSSender

    Private dsock As DatagramSocket

    Public Shared Function getInstance() As DSSender
        If (_instance Is Nothing) Then
            _instance = New DSSender
            System.out.println("DSSender Constructed")
        End If

        Return _instance
    End Function

    Private Sub New()
        MyBase.New()
        Try
            Me.dsock = New DatagramSocket
        Catch e As SocketException
            e.printStackTrace()
        End Try

    End Sub

    Public Shared Function byteForStation(ByVal station As Integer) As Byte
        Select Case (station)
            Case 1
                Return 49
                ' Station 1
            Case 2
                Return 50
                ' Station 2
            Case 3
                Return 51
                ' Station 3
        End Select

        Return 49
        ' Defaults to station 1
    End Function

    Public Shared Function byteForAlliance(ByVal alliance As Integer) As Byte
        Select Case (alliance)
            Case 1
                Return 82
                ' Red Alliance
            Case 2
                Return 66
                ' Blue Alliance
        End Select

        Return 82
        ' Defaults to Red Alliance
    End Function

    Public Sub updateTeam(ByVal team As Team, ByVal robotState As Byte, ByVal allianceColor As Byte, ByVal station As Byte)
        Me.sendPacket(Me.buildPacket(team.getInetAddress, robotState, allianceColor, station))
    End Sub

    Public Sub updateGameData(ByVal team As Team, ByVal game As Byte)
        Me.sendPacket(Me.buildGameSpecificDataPacket(team.getInetAddress, game))
    End Sub

    Private Sub sendPacket(ByVal p As DatagramPacket)
        Try
            Me.dsock.send(p)
        Catch e As IOException
            e.printStackTrace()
        End Try

    End Sub

    Private gameString As String = ("" + gameData)

    Private game() As Byte = Me.gameString.getBytes

    Private Function buildGameSpecificDataPacket(ByVal addr As InetAddress, ByVal game As Byte) As DatagramPacket
        Dim data() As Byte = New Byte((4) - 1) {}
        Dim i As Integer = 0
        Do While (i < 4)
            data(i) = 0
            i = (i + 1)
        Loop

        data(0) = 0
        data(1) = +2
        data(2) = 28
        data(3) = Me.game
        'Game data (LRL, RRR, LLL)
        Return New DatagramPacket(data, data.length, addr, 1121)
    End Function

    Private Function buildPacket(ByVal addr As InetAddress, ByVal robotState As Byte, ByVal allianceColor As Byte, ByVal station As Byte) As DatagramPacket
        ' Create array
        Dim data() As Byte = New Byte((74) - 1) {}
        ' Fill array with blank information
        Dim i As Integer = 0
        Do While (i < 74)
            data(i) = 0
            i = (i + 1)
        Loop

        ' Packet number
        data(0) = CType(98, Byte)
        '9818
        data(1) = CType(18, Byte)
        '4342
        ' Robot state
        data(2) = robotState
        ' Alliance Station
        data(3) = allianceColor
        ' Color
        data(4) = station
        ' Station number
        ' FMS version
        data(18) = 0
        data(19) = 6
        data(20) = 2
        data(21) = 5
        data(22) = 0
        data(23) = 8
        data(24) = 4
        data(25) = 6
        ' CRC 32(Checksum)
        Dim check As CRC32 = New CRC32
        check.update(data)
        Dim crc() As Byte = ByteBuffer.allocate(4).putInt(CType(check.getValue, Integer)).array
        ' CRC hash
        data(70) = crc(0)
        data(71) = crc(1)
        data(72) = crc(2)
        data(73) = crc(3)
        ' 1121 is the port used by the DS to recieve FMS packets
        Return New DatagramPacket(data, data.length, addr, 1121)
    End Function
End Class