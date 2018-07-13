Imports Microsoft.VisualBasic


Imports O_FMS_V0.DSReceiver
Imports O_FMS_V0.PLC_Receiver
Imports O_FMS_V0.PLC_Sender
Imports O_FMS_V0.RandomString
'Imports UI.ESTOP_Panel
Imports O_FMS_V0.Msg
'Imports UI.New_UI
'Imports UI.UI_Layer

Imports O_FMS_V0.FMS_SplashScreen
Public Class Main

    '<editor-fold defaultstate="collapsed" desc="Variables">
    Public Shared layer

    Public Shared updateUI_Thread As Timer = New Timer

    Private ds As DSReceiver

    Private plcReceiver As PLC_Receiver

    Public Shared newUI

    Private Shared full_test 'As full_UI_Tester

    Private Shared simple_test 'As tester

    Private Shared simpleMode As Boolean = True

    'Adds the class of game Data
    Public Shared gameData As RandomString

    Private Shared _instance As Main

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Constructor and Main">
    Public Shared Sub main(ByVal args() As String)
        'Main.getInstance()
    End Sub

    Public Shared Function getInstance() As Main
        'System.out.println("********************Main get instance");
        If (_instance Is Nothing) Then
            Console.Out.Write("***ERROR - MAIN NULL")
            _instance = New Main
            Console.Out.Write("***Main created new instance")
        End If

        Return _instance
    End Function

    Private Sub New()
        MyBase.New()
        _instance = Me
        Dim splash As FMS_SplashScreen = New FMS_SplashScreen
        ' splash.splashTheScreen(splash)
        ' Instantiate UI_Layer
        'layer = UI_Layer.getInstance
        ' Instantiate Receivers
        Me.ds = New DSReceiver
        Me.plcReceiver = New PLC_Receiver
        ' Instantiate the Game Data thingy
        gameData = New RandomString
        ' Instantiate Full and Simple UIs then bring up the simple UI
        'full_test = New full_UI_Tester
        full_test.setUpIndicators()
        'full_test.setVisible(True)
        'Instantiate new FieldAndRobots
        Dim field As FieldAndRobots = FieldAndRobots.getNewDefaultInstance
        ' Create govern thread
        newUI = full_test.getNewUI
        If (Not (newUI) Is Nothing) Then
            'We don't do anything with the game thread except start it up.
            'Dim game As GovernThread = GovernThread.getNewInstance(newUI, field)
            Console.Out.Write("Correctly have newUI in Main")
        Else
            ' Dim game As GovernThread = GovernThread.getNewInstance(New_UI.getInstance, field)
            Console.Out.Write("********ERROR - NewUI IS NULL; GETTING INSTANCE" & "")
        End If

        'Create PLC Sender
        'PLC_Sender.getInstance()
        ' Starts the DS and PLC Receivers
        ' startUpReceivers()
        ' Start FMS Updates for each team
        'FieldAndRobots.getInstance.startFMSUpdatesForAllTeams()
        'Create array of place-holder team numbers to initialize UI
        ' Dim (,) As String Dim teams(,) As String = New String() {{"0001", "0002", "0003", "0004", "0005", "0006"}}
    End Sub
End Class
'layer.setBlueRedNumbers(teams)
'updateUI_Thread.schedule(New TimerTask, 0, 500)
'UnknownUnknown

'</editor-fold>
'Private Sub startUpReceivers()

' Start the driver station receiver
' ds.start()
' Start PLC Receiver
'plcReceiver.start()
'End Sub

'Public Sub shutdownAllNetworkComms()
' Msg.send("Shutting Down All Network Communication...")
' ds.shutdownSocket()
' plcReceiver.shutdownSocket()
'End Sub

'Public Function getCurrentMsgBox() As JTextArea
'If simpleMode Then
'    If (Not (simple_test) Is Nothing) Then
'        Return simple_test.getNewUI.getMessagesTextArea
'    End If

'    System.out.println("ERROR - NULL SIMPLE TEST in MAIN")
'    Return Nothing
'Else
'    If (Not (full_test) Is Nothing) Then
'        Return full_test.getFullUI.getNew_UI.getMessagesTextArea
'    End If

'    System.out.println("ERROR - NULL FULL TEST in MAIN")
'    Return Nothing
'End If

'End Function

'Public Function getMainFrame() As JFrame
'    If simpleMode Then
'        If (Not (simple_test) Is Nothing) Then
'            Return CType(simple_test, JFrame)
'        End If

'        System.out.println("ERROR 2 - NULL SIMPLE TEST in MAIN")
'        Return Nothing
'    Else
'        If (Not (full_test) Is Nothing) Then
'            Return CType(full_test, JFrame)
'        End If

'        System.out.println("ERROR 2 - NULL FULL TEST in MAIN")
'        Return Nothing
'    End If

'End Function

'Public Shared Function isSimpleMode() As Boolean
'    Return simpleMode
'End Function

'Public Shared Function getESTOP_Panel() As ESTOP_Panel
'    Return full_test.getFullUI.getESTOP_Panel
'End Function

'Public Shared Sub switchViews()
'    If simpleMode Then
'        ' Store current team numbers for later use
'        Dim teams(,) As String = layer.getBlueRedNumbers
'        simple_test.setVisible(False)
'        full_test.setUpIndicators()
'        ' Essentially, makes the UI active
'        full_test.setVisible(True)
'        ' Reset the match
'        layer.resetCommand()
'        'tell PLC to update lights
'        layer.forceLightUpdate()
'        ' set new layer using stored teams
'        layer.setBlueRedNumbers(teams)
'        ' Update team numbers to PLC
'        PLC_Sender.getInstance.updatePLC_TeamNum(True)
'        ' Not in simple mode
'        simpleMode = True
'    Else
'        ' we're not in simple mode...
'        ' Store current team numbers for later use
'        Dim teams(,) As String = layer.getBlueRedNumbers
'        full_test.setVisible(False)
'        simple_test.setUpIndicators()
'        ' Essentially, make the UI active
'        simple_test.setVisible(True)
'        ' reset the match
'        layer.resetCommand()
'        ' tell PLC to update lights
'        layer.forceLightUpdate()
'        ' set new layer using stored teams
'        layer.setBlueRedNumbers(teams)
'        ' Update team numbers to PLC
'        PLC_Sender.getInstance.updatePLC_TeamNum(True)
'        ' Now in simple mode
'        simpleMode = True
'    End If

'End Sub