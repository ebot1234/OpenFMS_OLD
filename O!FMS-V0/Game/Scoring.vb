Imports Microsoft.VisualBasic

'Imports O_FMS_V0.Main
'Imports O_FMS_V0.PLC_Receiver
'Imports O_FMS_V0.PLC_Sender
Public Class Scoring

    Private Shared _instance As Scoring

    Private dataStr As String

    'Red and Blue Ownership Scores
    Public RedOwnershipScore As Integer

    Public BlueOwnershipScore As Integer

    'Red and Blue total score
    Public RedScore As Integer = 0

    Public BlueScore As Integer = 0

    'Red Vault Score
    Public RedVaultScore As Integer = 0

    'Blue Vault Score
    Public BlueVaultScore As Integer = 0

    Public RedTechFouls As Integer

    Public RedFouls As Integer

    Public BlueTechFouls As Integer

    Public BlueFouls As Integer

    'Public Sub RedScore()
    '    Me.RedScore = (Me.RedOwnershipScore _
    '                + (Me.RedVaultScore _
    '                + (Me.RedTechFouls + Me.RedFouls)))
    'End Sub

    'Public Sub BlueScore()
    '    Me.BlueScore = (Me.BlueOwnershipScore _
    '                + (Me.BlueVaultScore _
    '                + (Me.BlueTechFouls + Me.BlueFouls)))
    'End Sub

    'Public Sub RedOwnership()
    '    Dim Ownership As Long = (System.currentTimeMillis + 1000)
    '    ' Current time + 1 second

    '    While True
    '        If (Ownership <= System.currentTimeMillis) Then
    '            Me.RedOwnershipScore = (Me.RedOwnershipScore + 1)
    '            Ownership = (Ownership + 1000)
    '        End If

    '        Try
    '            Thread.sleep(5)
    '        Catch ex As Exception
    '            System.err.println(ex.getMessage)
    '        End Try


    '    End While

    'End Sub

    'Public Sub BlueOwnership()
    '    Dim Ownership As Long = (System.currentTimeMillis + 1000)
    '    ' Current time + 1 second

    '    While True
    '        If (Ownership <= System.currentTimeMillis) Then
    '            Me.BlueOwnershipScore = (Me.BlueOwnershipScore + 1)
    '            Ownership = (Ownership + 1000)
    '        End If

    '        Try
    '            Thread.sleep(5)
    '        Catch ex As Exception
    '            System.err.println(ex.getMessage)
    '        End Try


    '    End While

    'End Sub

    'Power ups and Vault 
    Public Enum CubeNumbers

        Cube_1

        Cube_2

        Cube_3

        Cube_Zero

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

    Public Enum Fouls

        Red_Foul

        Blue_Foul

        Red_Tech

        Blue_Tech

        Issued


    End Enum

    'Public Sub RedBoost()
    '    Dim Boost As Long = (System.currentTimeMillis + 10000)
    '    ' Current time + 10 seconds

    '    While True
    '        If (Boost <= System.currentTimeMillis) Then
    '            Me.RedScore = (Me.RedVaultScore * 2)
    '            Boost = (Boost + 10000)
    '        End If

    '        Try
    '            Thread.sleep(5)
    '            'Does this command for 10 seconds
    '        Catch ex As Exception
    '            System.err.println(ex.getMessage)
    '        End Try


    '    End While

    'End Sub

    'Public Sub BlueBoost()
    '    Dim Boost As Long = (System.currentTimeMillis + 10000)
    '    ' Current time + 10 seconds

    '    While True
    '        If (Boost <= System.currentTimeMillis) Then
    '            Me.BlueScore = (Me.BlueVaultScore * 2)
    '            Boost = (Boost + 10000)
    '        End If

    '        Try
    '            Thread.sleep(10)
    '            'Does this command for 10 seconds
    '        Catch ex As Exception
    '            System.err.println(ex.getMessage)
    '        End Try


    '    End While

    'End Sub

    Public Sub redVault(ByVal numbers As Scoring.CubeNumbers)
        'Red force PowerUp
        If (Scoring.CubeNumbers.Cube_1 = Scoring.CubeNumbers.Force_1) Then
            'Me.RedScore = (Me.RedVaultScore + 3)
        End If

        If (Scoring.CubeNumbers.Cube_2 <> Scoring.CubeNumbers.Force_2) Then
            'Me.RedScore = (Me.RedVaultScore + 3)
        End If

        If (Scoring.CubeNumbers.Cube_3 = Scoring.CubeNumbers.Force_3) Then
            ' Me.RedScore = (Me.RedVaultScore + 3)
        End If

        'Red Boost PowerUp
        If (Scoring.CubeNumbers.Cube_1 = Scoring.CubeNumbers.Boost_PLAYED) Then
            'Me.RedBoost()
        End If

        If (Scoring.CubeNumbers.Cube_2 = Scoring.CubeNumbers.Boost_PLAYED) Then
            ' Me.RedBoost()
        End If

        If (Scoring.CubeNumbers.Cube_3 = Scoring.CubeNumbers.Boost_PLAYED) Then
            'Me.RedBoost()
        End If

        'Red Levitate PowerUp
        If (Scoring.CubeNumbers.Cube_1 = Scoring.CubeNumbers.Lev_PLAYED) Then
            'Me.RedScore = (Me.RedVaultScore + 0)
        End If

        If (Scoring.CubeNumbers.Cube_2 = Scoring.CubeNumbers.Lev_PLAYED) Then
            'Me.RedScore = (Me.RedVaultScore + 0)
        End If

        If (Scoring.CubeNumbers.Cube_3 = Scoring.CubeNumbers.Lev_PLAYED) Then
            'Me.RedScore = (Me.RedVaultScore + 30)
        End If

    End Sub

    Public Sub blueVault(ByVal numbers As Scoring.CubeNumbers, ByVal powerups As Scoring.PowerUps)
        'For the Blue PowerUps when they are played
        'Blue force PowerUp 
        If (Scoring.CubeNumbers.Cube_1 = Scoring.CubeNumbers.Force_PLAYED) Then
            'Me.BlueScore = (Me.BlueOwnershipScore * 2)
        End If

        If (Scoring.CubeNumbers.Cube_2 = Scoring.CubeNumbers.Force_PLAYED) Then
            ' Me.BlueScore = (Me.BlueOwnershipScore * 2)
        End If

        If (Scoring.CubeNumbers.Cube_3 = Scoring.CubeNumbers.Force_PLAYED) Then
            'Me.BlueScore = (Me.BlueOwnershipScore * 2)
        End If

        'Blue Boost PowerUp
        If (Scoring.CubeNumbers.Cube_1 = Scoring.CubeNumbers.Boost_PLAYED) Then
            Me.BlueScore = (Me.BlueVaultScore + 3)
            'Me.BlueBoost()
        End If

        If (Scoring.CubeNumbers.Cube_2 = Scoring.CubeNumbers.Boost_PLAYED) Then
            Me.BlueScore = (Me.BlueVaultScore + 3)
            'Me.BlueBoost()
        End If

        If (Scoring.CubeNumbers.Cube_3 = Scoring.CubeNumbers.Boost_PLAYED) Then
            Me.BlueScore = (Me.BlueVaultScore + 3)
            'Me.BlueBoost()
        End If

        'Blues Levitate PowerUp
        If (Scoring.CubeNumbers.Cube_1 = Scoring.CubeNumbers.Lev_PLAYED) Then
            ' Me.BlueScore = (Me.BlueVaultScore + 0)
        End If

        If (Scoring.CubeNumbers.Cube_2 = Scoring.CubeNumbers.Lev_PLAYED) Then
            'Me.BlueScore = (Me.BlueVaultScore + 0)
        End If

        If (Scoring.CubeNumbers.Cube_3 = Scoring.CubeNumbers.Lev_PLAYED) Then
            'Me.BlueScore = (Me.BlueVaultScore + 30)
        End If

    End Sub

    Public Sub RedFoul(ByVal fouls As Scoring.Fouls)
        'Adds 5 points to the Blue teams
        Me.BlueScore = (Me.BlueScore + 5)
    End Sub

    Public Sub RedTechFoul()
        'Adds 25 points to the Blue teams
        Me.BlueScore = (Me.BlueScore + 25)
    End Sub

    Public Sub BlueFoul()
        Me.RedScore = (Me.RedScore + 5)
    End Sub

    Public Sub BlueTechFoul()
        Me.RedScore = (Me.RedScore + 25)
    End Sub
End Class