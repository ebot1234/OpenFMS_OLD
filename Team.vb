Imports Microsoft.VisualBasic

Imports Communication.DSSender
Imports UI.UI_Layer
Imports java.net.InetAddress
Imports java.net.SocketException
Imports java.net.UnknownHostException
Imports java.util.logging.Level
Imports java.util.logging.Logger
Public Class Team
    Inherits Thread

    '<editor-fold defaultstate="collapsed" desc="Variables">
    Private Shared ROBOT_TELEOP_DISABLED As Byte = 67

    Private Shared ROBOT_AUTON_DISABLED As Byte = 83

    Private Shared ROBOT_ENABLED As Byte = 32

    Private Shared ROBOT_ESTOPPED As Byte = 0

    Private robotDesiredState As Byte = ROBOT_TELEOP_DISABLED

    Private addr As InetAddress

    Private alliance As Byte

    Private station As Byte

    Private allianceInt As Integer

    Private stationInt As Integer

    Private teamNum As Integer

    Private Shared MAX_PACKET_TRIP_TIME_MILLIS As Double = 1000

    Private diffInPacketTimeMillis As Double = MAX_PACKET_TRIP_TIME_MILLIS

    Private lastPacketTimeMillis As Double = (System.currentTimeMillis - MAX_PACKET_TRIP_TIME_MILLIS)

    Private fmsCommAlive As Boolean = False

    Private robotCommAlive As Boolean = False

    Private batteryVoltage As Double = 0

    Private teamReady As Boolean = False

    Private teamBypassed As Boolean = False

    Private ESTOPPED As Boolean = False

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Constructor and Thread Run">
    Public Sub New(ByVal number As Integer, ByVal alliance As Integer, ByVal station As Integer)
        MyBase.New()
        System.out.println("Team Constructor")
        Me.teamNum = number
        Me.allianceInt = Me.alliance
        Me.stationInt = Me.station
        Me.alliance = DSSender.byteForAlliance(Me.alliance)
        Me.station = DSSender.byteForStation(Me.station)
        Me.setTeamNumber(number)
    End Sub

    Public Sub startFMSUpdates()
        Me.start()
    End Sub

    <Override()> _
    Public Sub run()

        While True
            Me.updateSelfWithTimes()
            Dim gameUi As UI_Layer = UI_Layer.getInstance
            If (Not (gameUi) Is Nothing) Then
                gameUi.setCommStatus(Me.allianceInt, Me.stationInt, Me.fmsCommAlive, Me.robotCommAlive, Me.teamBypassed, Me.ESTOPPED)
                gameUi.setBatteryVisual(Me.allianceInt, Me.stationInt, Me.batteryVoltage)
            End If

            Try
                'Update the driver station
                DSSender.getInstance.updateTeam(Me, Me.getRobotState, Me.alliance, Me.station)
            Catch ex As SocketException
                Logger.getLogger(Team.class.getName).log(Level.SEVERE, Nothing, ex)
            End Try

            Try
                Thread.sleep(500)
            Catch ex As InterruptedException
                Logger.getLogger(Team.class.getName).log(Level.SEVERE, Nothing, ex)
            End Try


        End While

    End Sub

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Updaters">    
    Public Sub updateFromReceived(ByVal batteryVolts As Double, ByVal robCommAlive As Boolean)
        Me.lastPacketTimeMillis = System.currentTimeMillis
        Me.batteryVoltage = batteryVolts
        Me.robotCommAlive = robCommAlive
    End Sub

    Private Sub updateSelfWithTimes()
        Me.diffInPacketTimeMillis = (System.currentTimeMillis - Me.lastPacketTimeMillis)
        If (Me.diffInPacketTimeMillis >= MAX_PACKET_TRIP_TIME_MILLIS) Then
            Me.fmsCommAlive = False
            Me.robotCommAlive = False
        Else
            Me.fmsCommAlive = True
        End If

    End Sub

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Robot State, Bypass, and ESTOP">
    Public Sub setRobotState(ByVal mode As Integer, ByVal enabled As Boolean)
        Dim out As Byte = ROBOT_TELEOP_DISABLED
        If (mode = GovernThread.AUTO_MODE) Then
            ROBOT_AUTON_DISABLED()
        ElseIf (mode = GovernThread.TELE_MODE) Then
            ROBOT_TELEOP_DISABLED()
        End If

        If enabled Then
            ROBOT_ENABLED()
        End If

    End Sub

    Public Function getRobotState() As Byte
        Dim desiredState As Byte = Me.robotDesiredState
        If Me.ESTOPPED Then
            Return ROBOT_ESTOPPED
        ElseIf (Not Me.isBypassed _
                    AndAlso Me.isReady) Then
            'both ARE required, isReady is for status, isBypassed is for state
            Return desiredState
        Else
            Return ROBOT_TELEOP_DISABLED
        End If

    End Function

    Public Function isBypassed() As Boolean
        Return Me.teamBypassed
    End Function

    Public Sub setBypassed(ByVal isBypassed As Boolean)
        Me.teamBypassed = isBypassed
    End Sub

    Public Sub ESTOP()
        Me.ESTOPPED = True
    End Sub

    Public Function isESTOPPED() As Boolean
        Return Me.ESTOPPED
    End Function

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Reset Team and Zero Battery">
    Public Sub resetTeam()
        Me.zeroBatteryVoltage()
        Me.diffInPacketTimeMillis = MAX_PACKET_TRIP_TIME_MILLIS
        Me.lastPacketTimeMillis = (System.currentTimeMillis - MAX_PACKET_TRIP_TIME_MILLIS)
        Me.fmsCommAlive = False
        Me.robotCommAlive = False
        Me.setBypassed(False)
        Me.teamReady = False
        Me.ESTOPPED = False
    End Sub

    Public Sub zeroBatteryVoltage()
        Me.batteryVoltage = 0
    End Sub

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Team Number Control">
    Public Sub setTeamNumber(ByVal number As Double)
        Me.teamNum = CType(number, Integer)
        Dim num As String = ("" _
                    + (number / 100))
        Dim nums() As String = num.split("\\.")
        Dim first As String = nums(0)
        Dim last As String = nums(1)
        If (nums(1).length = 1) Then
            last = (nums(1) + "0")
        End If

        Dim teamIP As String = ("10." _
                    + (first + ("." _
                    + (last + ".5"))))
        Try
            Me.addr = InetAddress.getByName(teamIP)
        Catch e As UnknownHostException
            e.printStackTrace()
        End Try

    End Sub

    Public Function getTeamNumber() As Integer
        Return Me.teamNum
    End Function

    Public Function getInetAddress() As InetAddress
        Return Me.addr
    End Function

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Readiness Getters">
    Public Function isReady() As Boolean
        Me.teamReady = False
        If Not Me.teamBypassed Then
            Me.teamReady = (Me.fmsCommAlive AndAlso Me.robotCommAlive)
        Else
            Me.teamReady = True
        End If

        Return Me.teamReady
    End Function
End Class
