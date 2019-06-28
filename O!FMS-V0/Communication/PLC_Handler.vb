Imports O_FMS_V0.Lighting
Imports O_FMS_V0.Field
Imports O_FMS_V0.Main_Panel




Public Class PLC_Handler
    'To check if PLC is connected'
    Public Shared isPlcConnected = False
    Public Shared Field_Estop As Boolean = False

    'Estop Bits to tell FMS -- MC'
    Public Shared PLC_Estop_Red1
    Public Shared PLC_Estop_Red2
    Public Shared PLC_Estop_Red3
    Public Shared PLC_Estop_Blue1
    Public Shared PLC_Estop_Blue2
    Public Shared PLC_Estop_Blue3
    Public Shared PLC_Estop_Field

    'Light bits for the Estops -- MC'
    Public Shared Red_1_Estop
    Public Shared Red_2_Estop
    Public Shared Red_3_Estop
    Public Shared Blue_1_Estop
    Public Shared Blue_2_Estop
    Public Shared Blue_3_Estop
    Public Shared Field_Estop_Bit

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
    Public Shared PLC_Red_Foul
    Public Shared PLC_Red_Tech
    Public Shared PLC_Blue_Foul
    Public Shared PLC_Blue_Tech
    Public Shared PLC_Field_Reset
    Public Shared PLC_Field_Volunteers

    'Game Varibles'
    Public Shared CargoshipEnabled
    Public Shared CargoshipReleased
    Public Shared SandstormUp
    Public Shared RedRocket1
    Public Shared RedRocket2
    Public Shared BlueRocket1
    Public Shared BlueRocket2

    'Data Sent from FMS Software to PLC
    Public Shared Match_Start 'MC13'
    Public Shared Match_Stop 'MC14'
    Public Shared Field_Ready
    Public Shared Pre_Start_Match
    Public Shared PLC_Reset

    'Driver Station Statuses'
    Public Shared Red1Ready
    Public Shared Red2Ready
    Public Shared Red3Ready
    Public Shared Blue1Ready
    Public Shared Blue2Ready
    Public Shared Blue3Ready
    Public Shared Custom_Message


    'Alliance Station Lights

    Public Shared DS_Light_Test
    Public Shared Scoring_Light_Test

    'RED Alliance
    Public Shared StnRed1Red
    Public Shared StnRed2Red
    Public Shared StnRed3Red


    'BLUE Alliance
    Public Shared StnBlue1Blue
    Public Shared StnBlue2Blue
    Public Shared StnBlue3Blue

    'Field Control Lights
    Public Shared FieldGreen
    Public Shared FieldBlue
    Public Shared FieldRed
    Public Shared FieldAmber


    'Teams number varibles
    Public Shared RedT1, RedT2, RedT3, BlueT1, BlueT2, BlueT3

    Public Shared modbusClient As New EasyModbus.ModbusClient("192.168.1.6", 502)

    Public Shared Sub ConnectPLC()
        modbusClient.Connect()
        PLC_Thread.Start()
    End Sub

    Public Shared Sub DisconnectPLC()
        MessageBox.Show("PLC is disconnecting.")
        modbusClient.Disconnect()
    End Sub

    Public Shared Sub checkAlliances()
        If DS_Linked_Red1 = True And Robot_Linked_Red1 = True Then
            Red1Ready = True
        End If

        If DS_Linked_Red2 = True And Robot_Linked_Red2 = True Then
            Red2Ready = True
        End If

        If DS_Linked_Red3 = True And Robot_Linked_Red3 = True Then
            Red3Ready = True
        End If

        If DS_Linked_Blue1 = True And Robot_Linked_Blue1 = True Then
            Blue1Ready = True
        End If

        If DS_Linked_Blue2 = True And Robot_Linked_Blue2 = True Then
            Blue2Ready = True
        End If

        If DS_Linked_Blue3 = True And Robot_Linked_Blue3 = True Then
            Blue3Ready = True
        End If

        'Checks if the alliances are ready'
        If Red1Ready = True And Red2Ready = True And Red3Ready = True And Blue1Ready = True And Blue2Ready = True And Blue3Ready = True Then
            'modbusClient.WriteSingleCoil(10, True)
            Field_Ready = True
        Else
            'modbusClient.WriteSingleCoil(10, False)
            Field_Ready = False
        End If
    End Sub

    Public Shared Sub handleRegisters()
        'Reads the scores and other registers from the PLC'
        Dim readHoldingRegisters = modbusClient.ReadHoldingRegisters(0, 74)

        PLC_RedScore = readHoldingRegisters(60)
        PLC_Red_Foul = readHoldingRegisters(63)
        PLC_Red_Tech = readHoldingRegisters(62)
        PLC_BlueScore = readHoldingRegisters(61)
        PLC_Blue_Foul = readHoldingRegisters(65)
        PLC_Blue_Tech = readHoldingRegisters(64)

    End Sub

    Public Shared Sub handleFieldOuputs()
        'handles the scoring table light testing'
        If Scoring_Light_Test = True Then

        End If

        'handles the alliance station light testing'
        If DS_Light_Test = True Then


        End If

        'Sends the team numbers to the ViewMarq Displays via PLC
        modbusClient.WriteSingleRegister(66, RedT1)
        modbusClient.WriteSingleRegister(67, RedT2)
        modbusClient.WriteSingleRegister(68, RedT3)
        modbusClient.WriteSingleRegister(69, BlueT1)
        modbusClient.WriteSingleRegister(71, BlueT2)
        modbusClient.WriteSingleRegister(72, BlueT3)

        'Sends the time and a custom message to the ViewMarq Displays via PLC
        modbusClient.WriteSingleRegister(0, PLC_Match_Timer)
        modbusClient.WriteSingleRegister(1, Custom_Message)

    End Sub

    Public Shared Sub handleGameOutputs()

    End Sub
    Public Shared Sub handleCoils()
        'FMS to PLC Estops for the Lights'
        If Red_1_Estop = True Then
            modbusClient.WriteSingleCoil(0, True)
        Else
            modbusClient.WriteSingleCoil(0, False)
        End If

        If Red_2_Estop = True Then
            modbusClient.WriteSingleCoil(1, True)
        Else
            modbusClient.WriteSingleCoil(1, False)
        End If

        If Red_3_Estop = True Then
            modbusClient.WriteSingleCoil(2, True)
        Else
            modbusClient.WriteSingleCoil(2, False)
        End If

        If Blue_1_Estop = True Then
            modbusClient.WriteSingleCoil(3, True)
        Else
            modbusClient.WriteSingleCoil(3, False)
        End If

        If Blue_2_Estop = True Then
            modbusClient.WriteSingleCoil(4, True)
        Else
            modbusClient.WriteSingleCoil(4, False)
        End If

        If Blue_3_Estop = True Then
            modbusClient.WriteSingleCoil(5, True)
        Else
            modbusClient.WriteSingleCoil(5, False)
        End If

        If Main_Panel.Field_Estopped = True Then
            modbusClient.WriteSingleCoil(6, True)
        Else
            modbusClient.WriteSingleCoil(6, False)
        End If

        'Red Team Statuses'
        If Red1Ready = True Then
            modbusClient.WriteSingleCoil(14, True)
        Else
            modbusClient.WriteSingleCoil(14, False)
        End If

        If Red2Ready = True Then
            modbusClient.WriteSingleCoil(15, True)
        Else
            modbusClient.WriteSingleCoil(15, False)
        End If

        If Red3Ready = True Then
            modbusClient.WriteSingleCoil(16, True)
        Else
            modbusClient.WriteSingleCoil(16, False)
        End If

        'Blue Team Statuses'
        If Blue1Ready = True Then
            modbusClient.WriteSingleCoil(17, True)
        Else
            modbusClient.WriteSingleCoil(17, False)
        End If

        If Pre_Start_Match = True Then
            modbusClient.WriteSingleCoil(31, True)
        Else
            modbusClient.WriteSingleCoil(31, False)
        End If

        If Match_Start = True Then
            modbusClient.WriteSingleCoil(29, True)
        Else
            modbusClient.WriteSingleCoil(29, False)
        End If
    End Sub

    Public Shared Sub resetCoils()
        modbusClient.WriteSingleCoil(0, False)
        modbusClient.WriteSingleCoil(1, False)
        modbusClient.WriteSingleCoil(2, False)
        modbusClient.WriteSingleCoil(3, False)
        modbusClient.WriteSingleCoil(4, False)
        modbusClient.WriteSingleCoil(5, False)
        modbusClient.WriteSingleCoil(6, False)
        modbusClient.WriteSingleCoil(7, False)
        modbusClient.WriteSingleCoil(8, False)
        modbusClient.WriteSingleCoil(9, False)
        modbusClient.WriteSingleCoil(10, False)
        modbusClient.WriteSingleCoil(11, False)
        modbusClient.WriteSingleCoil(12, False)
        modbusClient.WriteSingleCoil(13, False)
        modbusClient.WriteSingleCoil(14, False)
        modbusClient.WriteSingleCoil(15, False)
        modbusClient.WriteSingleCoil(16, False)
    End Sub
    Public Shared Sub handleEstops()
        'Reads the coils from PLC address 1 to 7'
        Dim readCoils() As Boolean = modbusClient.ReadCoils(0, 50)
        'PLC to FMS for estoping the robots'
        PLC_Estop_Red1 = readCoils(7)
        PLC_Estop_Red2 = readCoils(8)
        PLC_Estop_Red3 = readCoils(9)
        PLC_Estop_Blue1 = readCoils(10)
        PLC_Estop_Blue2 = readCoils(11)
        PLC_Estop_Blue3 = readCoils(12)
        PLC_Estop_Field = readCoils(13)

        'Field Estop'
        If PLC_Estop_Field = True Then
            Red1DS.Estop = True
            Red2DS.Estop = True
            Red3DS.Estop = True
            Blue1DS.Estop = True
            Blue2DS.Estop = True
            Blue3DS.Estop = True
        End If

        'Estops Red 1'
        If PLC_Estop_Red1 = True Then
            Red1DS.Estop = True
        End If

        'Estops Red 2'
        If PLC_Estop_Red2 = True Then
            Red2DS.Estop = True
        End If

        'Estops Red 3'
        If PLC_Estop_Red3 = True Then
            Red3DS.Estop = True
        End If

        'Estops Blue 1'
        If PLC_Estop_Blue1 = True Then
            Blue1DS.Estop = True
        End If

        'Estops Blue 2'
        If PLC_Estop_Blue2 = True Then
            Blue2DS.Estop = True
        End If

        'Estops Blue 3'
        If PLC_Estop_Blue3 = True Then
            Blue3DS.Estop = True
        End If
    End Sub

    Public Shared Sub handleLighting()
        'Handles the lighting to what the match state is in'
        If fieldStatus = MatchEnums.PreMatch Then
            setModeRocketNear("G")
            setModeRocketFar("G")
        ElseIf fieldStatus = MatchEnums.PostMatch Then
            setModeRocketFar("O")
            setModeRocketNear("O")
        End If
        'Changes the lighting to what the PLC returns'
        If RedRocket1 = True Then
            setModeRocketFar("R")
        ElseIf RedRocket2 = True Then
            setModeRocketNear("R")
        ElseIf BlueRocket1 = True Then
            setModeRocketFar("B")
        ElseIf BlueRocket2 Then
            setModeRocketNear("B")
        End If
        'Turns the field to purple if volunteers can enter or green for teams'
        If PLC_Field_Volunteers = True Then
            setModeRocketNear("P")
            setModeRocketFar("P")
        ElseIf PLC_Field_Reset = True Then
            setModeRocketNear("G")
            setModeRocketFar("G")
        End If
    End Sub

End Class
