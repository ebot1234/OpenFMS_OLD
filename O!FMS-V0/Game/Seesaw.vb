Imports Microsoft.VisualBasic

Imports O_FMS_V0.FieldAndRobots

Public Class Seesaw

    Private alliance As Integer

    Private redAlliance As Integer

    Private blueAlliance As Integer

    Private nearIsRed As Boolean

    Private seesaw As Boolean

    Private neitherAlliance As Integer

    Private ownedBy As Integer

    'Scale sensors 
    Private scaleSensor1 As Boolean

    'defult = true no score if false blue score
    Private scaleSensor2 As Boolean

    'if true red score
    'Red Switch sensors
    Private redSwitch1 As Boolean

    'if false blue scores
    Private redSwitch2 As Boolean

    'if true red scores
    'Blue Switch sensors
    Private blueSwitch1 As Boolean

    'same as above
    Private blueSwitch2 As Boolean

    'same as above
    Private score As Integer

    Private BlueVaultScore As Integer = 0

    Private RedVaultScore As Integer = 0

    Private BlueOwnershipScore As Integer = 0

    Private RedOwnershipscore As Integer = 0

    Private startTime As Timer

    Private endTime As Timer

    Private currentTime As Timer

    'Public Sub RedOwnership()
    '    Dim Ownership As Long = (System.currentTimeMillis + 1000)
    '    ' Current time + 1 second

    '    While True
    '        If (Ownership <= System.currentTimeMillis) Then
    '            Me.RedOwnershipscore = (Me.RedOwnershipscore + 1)
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

    'sets the Randomization of the scale or switch with the Scoring Table if true is red
    Public Sub setRandomisation()
        Me.seesaw = Me.nearIsRed
    End Sub

    'Public Sub neitherAlliance()
    '    Me.neitherAlliance = (Me.redAlliance And Me.blueAlliance)
    'End Sub

    Public Sub RedScore()
        ' To keep track of the total red score
    End Sub

    Public Sub BlueScore()
        ' To keep track of the total blue score
    End Sub

    'this does something? maybe sets the side of the scale and switch
    Public Sub setSeesaw(ByVal seesaw As Boolean)
        Me.seesaw = Me.seesaw
        ' Me.neitherAlliance()
        'need to add the current state of the powerups
        'scale stuff
    End Sub
End Class
