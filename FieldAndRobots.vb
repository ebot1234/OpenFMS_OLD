Imports Microsoft.VisualBasic


Imports Game.Seesaw
Imports java.util.ArrayList
Imports java.util.List
Imports java.util.Random
Imports Game.Scoring
Public Class FieldAndRobots

    Public Shared powerups As PowerUps

    '<editor-fold defaultstate="collapsed" desc="Variables">
    Public teams(,) As Team

    Public Shared RED As Integer = 0

    Public Shared BLUE As Integer = 1

    Public Shared ONE As Integer = 0

    Public Shared TWO As Integer = 1

    Public Shared THREE As Integer = 2

    Private Shared _instance As FieldAndRobots

    'Red Vault Score
    Private RedVaultScore As Integer = 0

    'Blue Vault Score
    Private BlueVaultScore As Integer = 0

    Private RedScore As Integer = 0

    Private BlueScore As Integer = 0

    Private RedOwnershipScore As Integer = 0

    Private BlueOwnershipScore As Integer = 0

    Private random As Random = New Random

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Creation And Instancing FAR">
    Private Sub New(ByVal allianceCount As Integer, ByVal teamsPerAlliance As Integer)
        MyBase.New()
        Me.teams = New Team((allianceCount) - 1) {}
        teamsPerAlliance()
        System.out.println("FieldAndRobots Contructor")
        System.out.println("Initializing Teams...")
        Dim teamId As Integer = 0
        Dim allianceNbr As Integer = 0
        Do While (allianceNbr < allianceCount)
            Dim team As Integer = 0
            Do While (team < teamsPerAlliance)
                Me.teams(allianceNbr)(team) = New Team(teamId, allianceNbr, team)
                System.out.println(("Alliance " _
                                + (allianceNbr + (" Team " _
                                + (team + " Initialized")))))
                teamId = (teamId + 1)
                team = (team + 1)
            Loop

            allianceNbr = (allianceNbr + 1)
        Loop

    End Sub

    Public Shared Function getNewInstance(ByVal allianceCount As Integer, ByVal teamsPerAlliance As Integer) As FieldAndRobots
        If (Not (_instance) Is Nothing) Then
            System.out.println(("Asked for a new instance of FAR, had one already, " + "throwing it away."))
        End If

        If (allianceCount = 0) Then
            System.out.println(("Defaults triggered: using 2 alliances with " + "three teams each."))
            allianceCount = 2
            teamsPerAlliance = 3
        End If

        _instance = New FieldAndRobots(allianceCount, teamsPerAlliance)
        Return _instance
    End Function

    Public Shared Function getNewDefaultInstance() As FieldAndRobots
        Return FieldAndRobots.getNewInstance(0, 0)
    End Function

    Public Shared Function getInstance() As FieldAndRobots
        If (Not (_instance) Is Nothing) Then
            Return _instance
        End If

        Return FieldAndRobots.getNewDefaultInstance
    End Function

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Control All Teams">
    Public Sub startFMSUpdatesForAllTeams()
        For Each alliance() As Team In Me.teams
            For Each team As Team In alliance
                If (Not (team) Is Nothing) Then
                    team.startFMSUpdates()
                End If

            Next
        Next
        System.out.println("Finished Starting Team FMS Updates...")
    End Sub

    Public Sub setAllRobotStates(ByVal mode As Integer, ByVal enabled As Boolean)
        For Each alliance() As Team In Me.teams
            For Each team As Team In alliance
                If (Not (team) Is Nothing) Then
                    team.setRobotState(mode, enabled)
                End If

            Next
        Next
    End Sub

    Public Sub setGameData()
        'For the generation of the game data
        Dim gameData As List(Of String) = New ArrayList
        'List of the Scale and Switch Vaules
        gameData.add("LLL")
        gameData.add("RRR")
        gameData.add("LRL")
        gameData.add("RLR")
        Dim i As Integer = 0
        Do While (i < 1)
            Me.getRandomItem(gameData)
            i = (i + 1)
        Loop

    End Sub

    Public Sub getRandomItem(ByVal gameData As List(Of String))
        'Size of the list is 5
        Dim index As Integer = Me.random.nextInt(gameData.size)
        System.out.println(("" + gameData.get(index)))
    End Sub

    Public Sub setBypassForAllRobots(ByVal bypassState As Boolean)
        For Each alliance() As Team In Me.teams
            For Each team As Team In alliance
                If (Not (team) Is Nothing) Then
                    team.setBypassed(bypassState)
                End If

            Next
        Next
        System.out.println("Bypassing in FAR done...")
    End Sub

    Public Sub resetAllRobots()
        For Each alliance() As Team In Me.teams
            For Each team As Team In alliance
                If (Not (team) Is Nothing) Then
                    team.resetTeam()
                End If

            Next
        Next
        System.out.println("Resetting in FAR done...")
    End Sub

    Public Function getRedBlueNumbers() As String(,)
        Dim red() As String = New String() {Main.layer.fixNumTeam((Me.teams(0)(0).getTeamNumber + ""), "Red 1 - FAR"), Main.layer.fixNumTeam((Me.teams(0)(1).getTeamNumber + ""), "Red 2 - FAR"), Main.layer.fixNumTeam((Me.teams(0)(2).getTeamNumber + ""), "Red 3 - FAR")}
        Dim blue() As String = New String() {Main.layer.fixNumTeam((Me.teams(1)(0).getTeamNumber + ""), "Blue 1 - FAR"), Main.layer.fixNumTeam((Me.teams(1)(1).getTeamNumber + ""), "Blue 2 - FAR"), Main.layer.fixNumTeam((Me.teams(1)(2).getTeamNumber + ""), "Blue 3 - FAR")}
        Dim robots(,) As String = New String() {red, blue}
        Return robots
    End Function

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Control Specific Teams">
    Public Sub setTeamNumber(ByVal alliance As Integer, ByVal stationNumber As Integer, ByVal teamNumber As Integer)
        If Me.verify(alliance, stationNumber) Then
            Me.teams(alliance)(stationNumber).setTeamNumber(teamNumber)
        Else
            System.out.println("SetTeamNumber Error!")
        End If

    End Sub

    Public Sub updateRobotStatus(ByVal teamNumber As Integer, ByVal batteryVoltage As Double, ByVal isRobotCommunicating As Boolean)
        'Look for the team; if we find it, update it and break out
        For Each alliance() As Team In Me.teams
            For Each team As Team In alliance
                If (team.getTeamNumber = teamNumber) Then
                    team.updateFromReceived(batteryVoltage, isRobotCommunicating)
                    Return
                End If

            Next
        Next
    End Sub

    Public Function isAllianceReady(ByVal allianceNumber As Integer) As Boolean
        Dim allReady As Boolean = True
        If (allianceNumber < Me.teams.length) Then
            For Each team As Team In Me.teams(allianceNumber)
                If (Not (team) Is Nothing) Then
                    If Not team.isReady Then
                        allReady = False
                        Exit For
                    End If

                End If

            Next
        End If

        Return allReady
    End Function

    Public Enum SpecialState

        ESTOP_ROBOT

        ZERO_BATTERY

        BYPASS

        UNBYPASS


    End Enum

    Public Enum CubeNumbers

        Cube_1

        Cube_2

        Cube_3

        PLAYED

        Cube_Zero

        Force_PLAYED

        Boost_PLAYED

        Lev_PLAYED


    End Enum

    Public Enum PowerUps

        Force_1

        Levitate_2

        Boost_2

        Force_PLAYED

        Boost_PLAYED

        Lev_PLAYED

        Force_2

        Force_3

        Levitate_1

        Levitate_3

        Boost_1

        Boost_3

        PLAYED


    End Enum

    Public Sub RedOwnership()
        Dim Ownership As Long = (System.currentTimeMillis + 1000)
        ' Current time + 1 second

        While True
            If (Ownership <= System.currentTimeMillis) Then
                Me.RedOwnershipScore = (Me.RedOwnershipScore + 1)
                Ownership = (Ownership + 1000)
            End If

            Try
                Thread.sleep(5)
            Catch ex As Exception
                System.err.println(ex.getMessage)
            End Try


        End While

    End Sub

    Public Sub BlueOwnership()
        Dim Ownership As Long = (System.currentTimeMillis + 1000)
        ' Current time + 1 second

        While True
            If (Ownership <= System.currentTimeMillis) Then
                Me.BlueOwnershipScore = (Me.BlueOwnershipScore + 1)
                Ownership = (Ownership + 1000)
            End If

            Try
                Thread.sleep(5)
            Catch ex As Exception
                System.err.println(ex.getMessage)
            End Try


        End While

    End Sub

    Public Sub RedBoost()
        Dim Boost As Long = (System.currentTimeMillis + 10000)
        ' Current time + 10 seconds

        While True
            If (Boost <= System.currentTimeMillis) Then
                Me.RedScore = (Me.RedVaultScore * 2)
                Boost = (Boost + 10000)
            End If

            Try
                Thread.sleep(5)
                'Does this command for 10 seconds
            Catch ex As Exception
                System.err.println(ex.getMessage)
            End Try


        End While

    End Sub

    Public Sub BlueBoost()
        Dim Boost As Long = (System.currentTimeMillis + 10000)
        ' Current time + 10 seconds

        While True
            If (Boost <= System.currentTimeMillis) Then
                Me.BlueScore = (Me.BlueVaultScore * 2)
                Boost = (Boost + 10000)
            End If

            Try
                Thread.sleep(10)
                'Does this command for 10 seconds
            Catch ex As Exception
                System.err.println(ex.getMessage)
            End Try


        End While

    End Sub

    Public Sub redFoul(ByVal fouls As Scoring.Fouls)
        If (Scoring.Fouls.Red_Foul = Scoring.Fouls.Red_Foul) Then
            Me.BlueScore = (Me.BlueScore + 5)
        End If

    End Sub

    Public Sub blueFoul(ByVal fouls As Scoring.Fouls)
        If (Scoring.Fouls.Blue_Foul = Scoring.Fouls.Blue_Foul) Then
            Me.RedScore = (Me.RedScore + 5)
        End If

    End Sub

    Public Sub redTech(ByVal fouls As Scoring.Fouls)
        If (Scoring.Fouls.Red_Tech = Scoring.Fouls.Red_Tech) Then
            Me.BlueScore = (Me.BlueScore + 25)
        End If

    End Sub

    Public Sub blueTech(ByVal fouls As Scoring.Fouls)
        If (Scoring.Fouls.Blue_Tech = Scoring.Fouls.Blue_Tech) Then
            Me.RedScore = (Me.RedScore + 25)
        End If

    End Sub

    Public Sub redVaultForce(ByVal numbers As Scoring.CubeNumbers)
        'Red force PowerUp
        If (Scoring.CubeNumbers.Force_1 = Scoring.CubeNumbers.Force_PLAYED) Then
            Me.RedScore = (Me.RedOwnershipScore * 2)
        End If

        If (Scoring.CubeNumbers.Force_2 = Scoring.CubeNumbers.Force_PLAYED) Then
            Me.RedScore = (Me.RedOwnershipScore * 2)
        End If

        If (Scoring.CubeNumbers.Force_3 = Scoring.CubeNumbers.Force_PLAYED) Then
            Me.RedScore = (Me.RedOwnershipScore * 2)
        End If

        If (Scoring.CubeNumbers.Force_1 = Scoring.CubeNumbers.Cube_1) Then
            Me.RedScore = (Me.RedOwnershipScore + 3)
        End If

        If (Scoring.CubeNumbers.Force_2 = Scoring.CubeNumbers.Cube_2) Then
            Me.RedScore = (Me.RedOwnershipScore + 3)
        End If

        If (Scoring.CubeNumbers.Force_3 = Scoring.CubeNumbers.Cube_3) Then
            Me.RedScore = (Me.RedOwnershipScore + 3)
        End If

    End Sub

    Public Sub redVaultBoost(ByVal numbers As Scoring.CubeNumbers)
        If (Scoring.CubeNumbers.Boost_1 = Scoring.CubeNumbers.Boost_PLAYED) Then
            Me.RedBoost()
        End If

        If (Scoring.CubeNumbers.Boost_2 = Scoring.CubeNumbers.Boost_PLAYED) Then
            Me.RedBoost()
        End If

        If (Scoring.CubeNumbers.Boost_1 = Scoring.CubeNumbers.Boost_PLAYED) Then
            Me.RedBoost()
        End If

        If (Scoring.CubeNumbers.Boost_1 = Scoring.CubeNumbers.Cube_1) Then
            Me.RedScore = (Me.RedOwnershipScore + 3)
        End If

        If (Scoring.CubeNumbers.Boost_2 = Scoring.CubeNumbers.Cube_2) Then
            Me.RedScore = (Me.RedOwnershipScore + 3)
        End If

        If (Scoring.CubeNumbers.Boost_3 = Scoring.CubeNumbers.Cube_3) Then
            Me.RedScore = (Me.RedOwnershipScore + 3)
        End If

    End Sub

    Public Sub redVaultLev(ByVal numbers As Scoring.CubeNumbers)
        If (Scoring.CubeNumbers.Levitate_1 = Scoring.CubeNumbers.Lev_PLAYED) Then

        End If

        If (Scoring.CubeNumbers.Levitate_2 = Scoring.CubeNumbers.Lev_PLAYED) Then

        End If

        If (Scoring.CubeNumbers.Levitate_3 = Scoring.CubeNumbers.Levitate_3) Then

        End If

        If (Scoring.CubeNumbers.Levitate_1 = Scoring.CubeNumbers.Cube_1) Then
            Me.RedScore = (Me.RedVaultScore + 3)
        End If

        If (Scoring.CubeNumbers.Levitate_2 = Scoring.CubeNumbers.Cube_2) Then
            Me.RedScore = (Me.RedVaultScore + 3)
        End If

        If (Scoring.CubeNumbers.Levitate_3 = Scoring.CubeNumbers.Cube_3) Then
            Me.RedScore = (Me.RedVaultScore + 3)
        End If

    End Sub

    Public Sub blueVaultForce(ByVal numbers As Scoring.CubeNumbers)
        'Red force PowerUp
        If (Scoring.CubeNumbers.Force_1 = Scoring.CubeNumbers.Force_PLAYED) Then
            Me.BlueScore = (Me.BlueOwnershipScore * 2)
        End If

        If (Scoring.CubeNumbers.Force_2 = Scoring.CubeNumbers.Force_PLAYED) Then
            Me.BlueScore = (Me.BlueOwnershipScore * 2)
        End If

        If (Scoring.CubeNumbers.Force_3 = Scoring.CubeNumbers.Force_PLAYED) Then
            Me.BlueScore = (Me.BlueOwnershipScore * 2)
        End If

        If (Scoring.CubeNumbers.Force_1 = Scoring.CubeNumbers.Cube_1) Then
            Me.BlueScore = (Me.BlueOwnershipScore + 3)
        End If

        If (Scoring.CubeNumbers.Force_2 = Scoring.CubeNumbers.Cube_2) Then
            Me.BlueScore = (Me.BlueOwnershipScore + 3)
        End If

        If (Scoring.CubeNumbers.Force_3 = Scoring.CubeNumbers.Cube_3) Then
            Me.BlueScore = (Me.BlueOwnershipScore + 3)
        End If

    End Sub

    Public Sub blueVaultBoost(ByVal numbers As Scoring.CubeNumbers)
        If (Scoring.CubeNumbers.Boost_1 = Scoring.CubeNumbers.Boost_PLAYED) Then
            Me.BlueBoost()
        End If

        If (Scoring.CubeNumbers.Boost_2 = Scoring.CubeNumbers.Boost_PLAYED) Then
            Me.BlueBoost()
        End If

        If (Scoring.CubeNumbers.Boost_1 = Scoring.CubeNumbers.Boost_PLAYED) Then
            Me.BlueBoost()
        End If

        If (Scoring.CubeNumbers.Boost_1 = Scoring.CubeNumbers.Cube_1) Then
            Me.BlueScore = (Me.BlueOwnershipScore + 3)
        End If

        If (Scoring.CubeNumbers.Boost_2 = Scoring.CubeNumbers.Cube_2) Then
            Me.BlueScore = (Me.BlueOwnershipScore + 3)
        End If

        If (Scoring.CubeNumbers.Boost_3 = Scoring.CubeNumbers.Cube_3) Then
            Me.BlueScore = (Me.BlueOwnershipScore + 3)
        End If

    End Sub

    Public Sub blueVaultLev(ByVal numbers As Scoring.CubeNumbers)
        If (Scoring.CubeNumbers.Levitate_1 = Scoring.CubeNumbers.Lev_PLAYED) Then

        End If

        If (Scoring.CubeNumbers.Levitate_2 = Scoring.CubeNumbers.Lev_PLAYED) Then

        End If

        If (Scoring.CubeNumbers.Levitate_3 = Scoring.CubeNumbers.Levitate_3) Then

        End If

        If (Scoring.CubeNumbers.Levitate_1 = Scoring.CubeNumbers.Cube_1) Then
            Me.RedScore = (Me.RedVaultScore + 3)
        End If

        If (Scoring.CubeNumbers.Levitate_2 = Scoring.CubeNumbers.Cube_2) Then
            Me.RedScore = (Me.RedVaultScore + 3)
        End If

        If (Scoring.CubeNumbers.Levitate_3 = Scoring.CubeNumbers.Cube_3) Then
            Me.RedScore = (Me.RedVaultScore + 3)
        End If

    End Sub

    Public Sub actOnRobot(ByVal alliance As Integer, ByVal stationNumber As Integer, ByVal state As SpecialState)
        If Me.verify(alliance, stationNumber) Then
            If (state = SpecialState.ESTOP_ROBOT) Then
                Me.teams(alliance)(stationNumber).ESTOP()
            ElseIf (state = SpecialState.ZERO_BATTERY) Then
                Me.teams(alliance)(stationNumber).zeroBatteryVoltage()
            ElseIf (state = SpecialState.BYPASS) Then
                Me.teams(alliance)(stationNumber).setBypassed(True)
            ElseIf (state = SpecialState.UNBYPASS) Then
                Me.teams(alliance)(stationNumber).setBypassed(False)
            Else
                System.out.println("INCORRECT STATE(in actOnRobot): NOTHING DONE")
            End If

        Else
            System.out.println("ActOnRobot Verification Error!")
        End If

    End Sub

    Private Function verify(ByVal alliance As Integer, ByVal station As Integer) As Boolean
        Return ((alliance < Me.teams.length) _
                    AndAlso ((station < Me.teams(alliance).length) _
                    AndAlso (Not (Me.teams(alliance)(station)) Is Nothing)))
    End Function

    '</editor-fold>
    Public Function areRobotsNotESTOPPED() As Boolean
        For Each alliance() As Team In Me.teams
            For Each team As Team In alliance
                If team.isESTOPPED Then
                    Return False
                End If

            Next
        Next
        Return True
    End Function
End Class