
Imports myOPC
Imports OPCAutomation
Public Class testcomm

    ' Create OPC instances
    Public myAsynchOpc As AsynchOpc = New AsynchOpc
    Public mySynchOpc As myOPC.myOPC = New myOPC.myOPC

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Define Asynchronous Parameters
        myAsynchOpc.AsynchMode = True
        myAsynchOpc.ChannelName = "my2Channel"
        myAsynchOpc.DeviceName = "my2Device"
        myAsynchOpc.DeadBand = 0
        myAsynchOpc.GroupName = "myAsynchGroup"
        myAsynchOpc.NumItems = 1
        myAsynchOpc.OPCServerType = 2
        myAsynchOpc.SilentMode = False
        myAsynchOpc.UpdateRate = 100
        myAsynchOpc.OPCItemNames(1) = "myTrigger"

        ' Define Synchronous Parameters
        mySynchOpc.AsynchMode = False
        mySynchOpc.ChannelName = "my2Channel"
        mySynchOpc.DeviceName = "my2Device"
        mySynchOpc.DeadBand = 0
        mySynchOpc.GroupName = "mySynchGroup"
        mySynchOpc.NumItems = 2
        mySynchOpc.OPCServerType = 2
        mySynchOpc.SilentMode = False
        mySynchOpc.UpdateRate = 100
        mySynchOpc.OPCItemNames(1) = "myData[0]"
        mySynchOpc.OPCItemNames(2) = "myData[1]"

        Try 'Start OPC's
            Dim asynchOpcStarted As Boolean = myAsynchOpc.StartOPC()
            Dim synchOpcStarted As Boolean = mySynchOpc.StartOPC()
            ' Add logic to verify they started
        Catch ex As Exception
            ' Error Logic Here
        End Try
    End Sub

    ' Don't forget to be a good steward and close OPC connections
    Private Sub Form1_FormClosing(sender As Object, _
                e As FormClosingEventArgs) Handles MyBase.FormClosing
        myAsynchOpc.Close()
        mySynchOpc.Close()
    End Sub

    Public Class AsynchOpc
        Inherits myOPC.myOPC

        Protected Overrides Sub OPCdataChanged()
            MyBase.OPCdataChanged()

            ' Shown for clarity could inline this
            Dim theTrigger As Boolean = Convert.ToBoolean(OPCItemValues(1))

            If theTrigger = True Then
                ' If the trigger is on read data
                Form1.mySynchOpc.OPCsynchReadGroup()
                ' Grab Data
                Dim Data0 As Int32 = Convert.ToInt32(Form1.mySynchOpc.OPCItemValues(1))
                Dim Data1 As Int32 = Convert.ToInt32(Form1.mySynchOpc.OPCItemValues(2))
                ' Reset Trigger
                OPCwrite(0, 1)
            End If
        End Sub
    End Class

End Class
