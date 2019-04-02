Imports EasyModbus.ModbusClient
Imports O_FMS_V0.Field
Imports O_FMS_V0.Main_Panel




Public Class PLC_Comms_Server
    'To check if PLC is connected'
    Public Shared isPlcConnected = False
    Public Shared Field_Estop As Boolean = False

    'Estops bidirectional communications
    Public Shared PLC_Estop_Red1
    Public Shared PLC_Estop_Red2
    Public Shared PLC_Estop_Red3
    Public Shared PLC_Estop_Blue1
    Public Shared PLC_Estop_Blue2
    Public Shared PLC_Estop_Blue3
    Public Shared PLC_Estop_Field

    'Driver Station Linked (Pulled from DS & Sent to PLC)
    Public Shared DS_Linked_Red1
    Public Shared DS_Linked_Red2
    Public Shared DS_Linked_Red3
    Public Shared DS_Linked_Blue1
    Public Shared DS_Linked_Blue2
    Public Shared DS_Linked_Blue3

    'Robot Linked (Pulled from DS & Sent to PLC)
    Public Shared Robot_Linked_Red1
    Public Shared Robot_Linked_Red2
    Public Shared Robot_Linked_Red3
    Public Shared Robot_Linked_Blue1
    Public Shared Robot_Linked_Blue2
    Public Shared Robot_Linked_Blue3

    'Robot Voltages (Pulled from DS)
    Public Shared Robot_Voltage_Red1
    Public Shared Robot_Voltage_Red2
    Public Shared Robot_Voltage_Red3
    Public Shared Robot_Voltage_Blue1
    Public Shared Robot_Voltage_Blue2
    Public Shared Robot_Voltage_Blue3

    'Data Pulled from PLC
    Public Shared PLC_RedScore
    Public Shared PLC_BlueScore
    Public Shared PLC_Match_Timer
    Public Shared PLC_Match_Mode
    Public Shared PLC_RedPen_Ref
    Public Shared PLC_BluePen_Ref
    Public Shared PLC_Field_Reset
    Public Shared PLC_Field_Volunteers


    'Data Sent from FMS Software to PLC
    Public Shared CargoshipEnabled
    Public Shared CargoshipReleased
    Public Shared SandstormActive

    Public Shared Match_Start
    Public Shared Match_Stop
    Public Shared Field_Ready
    Public Shared PLC_Reset
    Public Shared Red1Ready
    Public Shared Red2Ready
    Public Shared Red3Ready
    Public Shared Blue1Ready
    Public Shared Blue2Ready
    Public Shared Blue3Ready


    'Alliance Station Lights

    Public Shared DS_Light_Test
    Public Shared Scoring_Light_Test

    'RED Alliance
    Public Shared StnRed1Red
    Public Shared StnRed2Red
    Public Shared StnRed3Red

    Public Shared StnRed1Amb
    Public Shared StnRed2Amb
    Public Shared StnRed3Amb


    'BLUE Alliance
    Public Shared StnBlue1Blue
    Public Shared StnBlue2Blue
    Public Shared StnBlue3Blue

    Public Shared StnBlue1Amb
    Public Shared StnBlue2Amb
    Public Shared StnBlue3Amb

    'Field Control Lights
    Public Shared FieldGreen
    Public Shared FieldBlue
    Public Shared FieldRed
    Public Shared FieldAmber


    'Teams number varibles
    Public Shared RedT1, RedT2, RedT3, BlueT1, BlueT2, BlueT3

    Public Shared modbusClient As New EasyModbus.ModbusClient("127.0.0.1", 502)

    Public Shared Sub ConnectPLC()
        modbusClient.Connect()
        PLC_Thread.Start()
    End Sub

    Public Shared Sub DisconnectPLC()
        MessageBox.Show("PLC is disconnecting!")
        modbusClient.Disconnect()
    End Sub

    Public Shared Sub checkAlliances()
        If DS_Linked_Red1 = True & Robot_Linked_Red1 = True Then
            Red1Ready = True
        End If

        If DS_Linked_Red2 = True & Robot_Linked_Red2 = True Then
            Red2Ready = True
        End If

        If DS_Linked_Red3 = True & Robot_Linked_Red3 = True Then
            Red3Ready = True
        End If

        If DS_Linked_Blue1 = True & Robot_Linked_Blue1 = True Then
            Blue1Ready = True
        End If

        If DS_Linked_Blue2 = True & Robot_Linked_Blue2 = True Then
            Blue2Ready = True
        End If

        If DS_Linked_Blue3 = True & Robot_Linked_Blue3 = True Then
            Blue3Ready = True
        End If

        'Checks if the alliances are ready'
        If Red1Ready = True And Red2Ready = True And Red3Ready = True And Blue1Ready = True And Blue2Ready = True And Blue3Ready = True Then
            modbusClient.WriteSingleCoil(10, True)
            Field_Ready = True

        Else
            modbusClient.WriteSingleCoil(10, False)
            Field_Ready = False
        End If
    End Sub

    Public Shared Sub handleRegisters()
        Dim readHoldingRegisters = modbusClient.ReadHoldingRegisters(0, 7)
        PLC_Match_Timer = readHoldingRegisters(0)
        PLC_Match_Mode = readHoldingRegisters(1)
        PLC_RedScore = readHoldingRegisters(2)
        PLC_BlueScore = readHoldingRegisters(3)
        PLC_RedPen_Ref = readHoldingRegisters(5)
        PLC_BluePen_Ref = readHoldingRegisters(6)

    End Sub

    Public Shared Sub handleFieldOuputs()

        'handles field status'
        If Match_Start = True Then

        End If

            If Match_Stop = True Then

        End If

            If PLC_Reset = True Then

        End If

            'handles the scoring table light testing'
            If Scoring_Light_Test = True Then
            modbusClient.WriteSingleCoil(11, True)
        End If

        'handles the alliance station light testing'
        If DS_Light_Test = True Then


        End If



        'Sends the team numbers to the ViewMarq Displays via PLC
        modbusClient.WriteSingleRegister(10, RedT1)
            modbusClient.WriteSingleRegister(11, RedT2)
            modbusClient.WriteSingleRegister(12, RedT3)
            modbusClient.WriteSingleRegister(13, BlueT1)
            modbusClient.WriteSingleRegister(14, BlueT2)
            modbusClient.WriteSingleRegister(15, BlueT3)

    End Sub

    Public Shared Sub handleGameOutputs()

        'Releases the magnets on the Cargoship'
        If CargoshipEnabled = False Then
            modbusClient.WriteSingleCoil(8, False)
        End If

        'Enables the magnets on the Cargoships'
        If CargoshipEnabled = True Then
            modbusClient.WriteSingleCoil(8, True)
        End If

        If SandstormActive = True Then
            'modbusClient.WriteSingleCoil(0, True)
        Else

            SandstormActive = True
        End If

    End Sub
    Public Shared Sub handleCoils()
        Dim readCoils() As Boolean = modbusClient.ReadCoils(0, 49)



    End Sub
    Public Shared Sub handleEstops()
        'Reads and sets the Estops for teams'
        Dim readCoils() As Boolean = modbusClient.ReadCoils(0, 7)

        PLC_Estop_Red1 = readCoils(1)
        PLC_Estop_Red2 = readCoils(2)
        PLC_Estop_Red3 = readCoils(3)
        PLC_Estop_Blue1 = readCoils(4)
        PLC_Estop_Blue2 = readCoils(5)
        PLC_Estop_Blue3 = readCoils(6)

        'Estops Red 1'
        If PLC_Estop_Red1 = False Then
            Red1DS.Estop = True
        End If

            'Estops Red 2'
            If PLC_Estop_Red2 = False Then
            Red2DS.Estop = True
        End If

            'Estops Red 3'
            If PLC_Estop_Red3 = False Then
            Red3DS.Estop = True
        End If

            'Estops Blue 1'
            If PLC_Estop_Blue1 = False Then
            Blue1DS.Estop = True
        End If

        'Estops Blue 2'
        If PLC_Estop_Blue2 = False Then
            Blue2DS.Estop = True
        End If

        'Estops Blue 3'
        If PLC_Estop_Blue3 = False Then
            Blue3DS.Estop = True
        End If

        If Field_Estop = True Then
            Red1DS.Estop = True
            Red2DS.Estop = True
            Red3DS.Estop = True
            Blue1DS.Estop = True
            Blue2DS.Estop = True
            Blue3DS.Estop = True
        End If

        If PLC_Reset = True Then

        End If

    End Sub

    Public Shared Sub abortedMatch()

    End Sub

    Public Shared Sub handleFieldEstop()
        Dim readCoils() As Boolean = modbusClient.ReadCoils(0, 1)

        PLC_Estop_Field = readCoils(0)

        If PLC_Estop_Field = False Then
            Field_Estop = True

        End If



    End Sub
End Class
