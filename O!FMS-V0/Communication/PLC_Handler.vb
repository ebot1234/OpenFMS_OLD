Imports O_FMS_V0.Lighting
Imports O_FMS_V0.Field
Imports O_FMS_V0.Main_Panel
Imports O_FMS_V0.Tba


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
    Public Shared redCargoshipMagnet
    Public Shared blueCargoshipMagnet
    Public Shared redCargoshipLight
    Public Shared blueCargoshipLight
    Public Shared redSandstormUp
    Public Shared blueSandstormUp
    Public Shared RedRocket1Light
    Public Shared RedRocket2Light
    Public Shared BlueRocket1Light
    Public Shared BlueRocket2Light


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

    Public Shared modbusClient As New EasyModbus.ModbusClient("192.168.1.9", 502)

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

    Public Shared Sub handleAutomatedScoring()
        'TODO add scoring'
        Dim red_hatch_count
        Dim red_cargo_count

        For i As Integer = 0 To red_hatch_count
            redHatchPanelPoints = redHatchPanelPoints + 2
        Next

        For i As Integer = 0 To red_cargo_count
            redCargoPoints = redCargoPoints + 3
        Next

    End Sub

    Public Shared Sub handleFieldOuputs()
        'TODO Add Scoring table lights and alliance lights'
    End Sub

    Public Shared Sub handleGameOutputs()
        'Sets the magnets to on during the match setup and sandstorm'
        If Field.fieldStatus = MatchEnums.PreMatch Then
            redCargoshipMagnet = True
            redCargoshipLight = True
            blueCargoshipMagnet = True
            blueCargoshipLight = True
        ElseIf Field.fieldStatus = MatchEnums.SandStorm Then
            redCargoshipMagnet = True
            redCargoshipLight = True
            blueCargoshipMagnet = True
            blueCargoshipLight = True
        Else
            redCargoshipMagnet = False
            redCargoshipLight = False
            blueCargoshipMagnet = False
            blueCargoshipLight = False
        End If
    End Sub


    Public Shared Sub handleEstops()
        'Field Estop'
        If PLC_Estop_Field = True Then
            Red1DS.Estop = True
            Red2DS.Estop = True
            Red3DS.Estop = True
            Blue1DS.Estop = True
            Blue2DS.Estop = True
            Blue3DS.Estop = True
            Red_1_Estop = True
            Red_2_Estop = True
            Red_3_Estop = True
            Blue_1_Estop = True
            Blue_2_Estop = True
            Blue_3_Estop = True
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
        'FIX THIS @ETHEN'
    End Sub

    Public Shared Sub writeCoils()
        'This writes the values to the plc'
        'I.E. modbusClient.WriteSingleCoil(0, redCargoshipMagnet)'
        'TODO Add real values'
    End Sub

    Public Shared Sub readCoils()
        'This reads coils from the plc'
        Dim readCoils() As Boolean = modbusClient.ReadCoils(0, 200)
        'PLC to FMS for estoping the robots'
        PLC_Estop_Red1 = readCoils(7)
        PLC_Estop_Red2 = readCoils(8)
        PLC_Estop_Red3 = readCoils(9)
        PLC_Estop_Blue1 = readCoils(10)
        PLC_Estop_Blue2 = readCoils(11)
        PLC_Estop_Blue3 = readCoils(12)
        PLC_Estop_Field = readCoils(13)
    End Sub

    Public Shared Sub writeRegisters()
        'This writes registers to the plc'
        'I.E. modbusClient.WriteSingleRegister(0, PLC_Match_Timer)
        modbusClient.WriteSingleRegister(0, PLC_Match_Timer)
    End Sub

    Public Shared Sub readRegisters()
        'This reads registers from the plc'
    End Sub
End Class
