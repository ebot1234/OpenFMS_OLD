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
    Public Shared red_hatch_count
    Public Shared red_cargo_count
    Public Shared blue_hatch_count
    Public Shared blue_cargo_count
    Public Shared red_rocket_rp_count
    Public Shared blue_rocket_rp_count
    Public Shared red_hab_rp_count
    Public Shared blue_hab_rp_count
    Public Shared red_rocket_near_bay1
    Public Shared red_rocket_near_bay2
    Public Shared red_rocket_near_bay3
    Public Shared red_rocket_near_bay4
    Public Shared red_rocket_near_bay5
    Public Shared red_rocket_near_bay6
    Public Shared red_rocket_far_bay1
    Public Shared red_rocket_far_bay2
    Public Shared red_rocket_far_bay3
    Public Shared red_rocket_far_bay4
    Public Shared red_rocket_far_bay5
    Public Shared red_rocket_far_bay6
    Public Shared blue_rocket_near_bay1
    Public Shared blue_rocket_near_bay2
    Public Shared blue_rocket_near_bay3
    Public Shared blue_rocket_near_bay4
    Public Shared blue_rocket_near_bay5
    Public Shared blue_rocket_near_bay6
    Public Shared blue_rocket_far_bay1
    Public Shared blue_rocket_far_bay2
    Public Shared blue_rocket_far_bay3
    Public Shared blue_rocket_far_bay4
    Public Shared blue_rocket_far_bay5
    Public Shared blue_rocket_far_bay6
    Public Shared red_cs_bay1
    Public Shared red_cs_bay2
    Public Shared red_cs_bay3
    Public Shared red_cs_bay4
    Public Shared red_cs_bay5
    Public Shared red_cs_bay6
    Public Shared red_cs_bay7
    Public Shared red_cs_bay8
    Public Shared blue_cs_bay1
    Public Shared blue_cs_bay2
    Public Shared blue_cs_bay3
    Public Shared blue_cs_bay4
    Public Shared blue_cs_bay5
    Public Shared blue_cs_bay6
    Public Shared blue_cs_bay7
    Public Shared blue_cs_bay8

    'Data Sent from FMS Software to PLC
    Public Shared Match_Start 'MC13'
    Public Shared Match_Stop 'MC14'
    Public Shared Field_Ready
    Public Shared Pre_Start_Match
    Public Shared PLC_Reset
    Public Shared red_foul_count
    Public Shared blue_foul_count
    Public Shared red_tech_count
    Public Shared blue_tech_count

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
        If DS_Linked_Red1 = True And Robot_Linked_Red1 = True Or Red1Bypass = True Then
            Red1Ready = True
        Else
            Red1Ready = False
        End If

        If DS_Linked_Red2 = True And Robot_Linked_Red2 = True Or Red2Bypass = True Then
            Red2Ready = True
        Else
            Red2Ready = False
        End If

        If DS_Linked_Red3 = True And Robot_Linked_Red3 = True Or Red3Bypass = True Then
            Red3Ready = True
        Else
            Red3Ready = False
        End If

        If DS_Linked_Blue1 = True And Robot_Linked_Blue1 = True Or Blue1Bypass = True Then
            Blue1Ready = True
        Else
            Blue1Ready = False
        End If

        If DS_Linked_Blue2 = True And Robot_Linked_Blue2 = True Or Blue2Bypass = True Then
            Blue2Ready = True
        Else
            Blue2Ready = False
        End If

        If DS_Linked_Blue3 = True And Robot_Linked_Blue3 = True Or Blue3Bypass = True Then
            Blue3Ready = True
        Else
            Blue3Ready = False
        End If

        'Checks if the alliances are ready'
        If Red1Ready = True And Red2Ready = True And Red3Ready = True And Blue1Ready = True And Blue2Ready = True And Blue3Ready = True Then
            Field_Ready = True
        Else
            Field_Ready = False
        End If
    End Sub

    Public Shared Sub handleAutomatedScoring()
        'Updates the hatch points'
        For Each red_hatch As Integer In red_hatch_count
            redHatchPanelPoints = redHatchPanelPoints + 2
        Next

        For Each blue_hatch As Integer In blue_hatch_count
            blueHatchPanelPoints = blueHatchPanelPoints + 2
        Next

        'Updates the cargo points'
        For Each red_cargo As Integer In red_cargo_count
            redCargoPoints = redCargoPoints + 3
        Next

        For Each blue_cargo As Integer In blue_cargo_count
            blueCargoPoints = blueCargoPoints + 3
        Next

        'Updates the fouls'
        For Each red_fouls As Integer In red_foul_count
            blueFoulPoints = blueFoulPoints + 3
        Next

        For Each blue_fouls As Integer In blue_foul_count
            redFoulPoints = redFoulPoints + 3
        Next

        'Updates the tech fouls'
        For Each red_tech_foul As Integer In red_tech_count
            blueFoulPoints = blueFoulPoints + 10
        Next

        For Each blue_tech_foul As Integer In blue_tech_count
            redFoulPoints = redFoulPoints + 10
        Next

        'Updates the foul counts'
        redFoulCount = red_foul_count
        redTechCount = red_tech_count
        blueFoulCount = blue_foul_count
        blueTechCount = blue_tech_count

        'Red Rocket Placement Scoring'
        If red_rocket_far_bay1 = 0 Then
            redLowLeftRocketFar = "None"
        ElseIf red_rocket_far_bay1 = 1 Then
            redLowLeftRocketFar = "Panel"
        ElseIf red_rocket_far_bay1 = 2 Then
            redLowLeftRocketFar = "PanelAndCargo"
        Else
            redLowLeftRocketFar = "None"
        End If

        If red_rocket_far_bay2 = 0 Then
            redLowRightRocketFar = "None"
        ElseIf red_rocket_far_bay2 = 1 Then
            redLowRightRocketFar = "Panel"
        ElseIf red_rocket_far_bay2 = 2 Then
            redLowRightRocketFar = "PanelAndCargo"
        Else
            redLowRightRocketFar = "None"
        End If

        If red_rocket_far_bay3 = 0 Then
            redMidLeftRocketFar = "None"
        ElseIf red_rocket_far_bay3 = 1 Then
            redMidLeftRocketFar = "Panel"
        ElseIf red_rocket_far_bay3 = 2 Then
            redMidLeftRocketFar = "PanelAndCargo"
        Else
            redMidLeftRocketFar = "None"
        End If

        If red_rocket_far_bay4 = 0 Then
            redMidRightRocketFar = "None"
        ElseIf red_rocket_far_bay4 = 1 Then
            redMidRightRocketFar = "Panel"
        ElseIf red_rocket_far_bay4 = 2 Then
            redMidRightRocketFar = "PanelAndCargo"
        Else
            redMidRightRocketFar = "None"
        End If

        If red_rocket_far_bay5 = 0 Then
            redTopLeftRocketFar = "None"
        ElseIf red_rocket_far_bay5 = 1 Then
            redTopLeftRocketFar = "Panel"
        ElseIf red_rocket_far_bay5 = 2 Then
            redTopLeftRocketFar = "PanelAndCargo"
        Else
            redTopLeftRocketFar = "None"
        End If

        If red_rocket_far_bay6 = 0 Then
            redTopRightRocketFar = "None"
        ElseIf red_rocket_far_bay6 = 1 Then
            redTopRightRocketFar = "Panel"
        ElseIf red_rocket_far_bay6 = 2 Then
            redTopRightRocketFar = "PanelAndCargo"
        Else
            redTopRightRocketFar = "None"
        End If

        If red_rocket_near_bay1 = 0 Then
            redLowRightRocketNear = "None"
        ElseIf red_rocket_near_bay1 = 1 Then
            redLowRightRocketNear = "Panel"
        ElseIf red_rocket_near_bay1 = 2 Then
            redLowRightRocketNear = "PanelAndCargo"
        Else
            redLowRightRocketNear = "None"
        End If

        If red_rocket_near_bay2 = 0 Then
            redLowLeftRocketNear = "None"
        ElseIf red_rocket_near_bay2 = 1 Then
            redLowLeftRocketNear = "Panel"
        ElseIf red_rocket_near_bay2 = 2 Then
            redLowLeftRocketNear = "PanelAndCargo"
        Else
            redLowLeftRocketNear = "None"
        End If

        If red_rocket_near_bay3 = 0 Then
            redMidLeftRocketNear = "None"
        ElseIf red_rocket_near_bay3 = 1 Then
            redMidLeftRocketNear = "Panel"
        ElseIf red_rocket_near_bay3 = 2 Then
            redMidLeftRocketNear = "PanelAndCargo"
        Else
            redMidLeftRocketNear = "None"
        End If

        If red_rocket_near_bay4 = 0 Then
            redMidRightRocketNear = "None"
        ElseIf red_rocket_near_bay4 = 1 Then
            redMidRightRocketNear = "Panel"
        ElseIf red_rocket_near_bay4 = 2 Then
            redMidRightRocketNear = "PanelAndCargo"
        Else
            redMidRightRocketNear = "None"
        End If

        If red_rocket_near_bay5 = 0 Then
            redTopLeftRocketNear = "None"
        ElseIf red_rocket_near_bay5 = 1 Then
            redTopLeftRocketNear = "Panel"
        ElseIf red_rocket_near_bay5 = 2 Then
            redTopLeftRocketNear = "PanelAndCargo"
        Else
            redTopLeftRocketNear = "None"
        End If

        If red_rocket_near_bay6 = 0 Then
            redTopRightRocketNear = "None"
        ElseIf red_rocket_near_bay6 = 1 Then
            redTopRightRocketNear = "Panel"
        ElseIf red_rocket_near_bay6 = 2 Then
            redTopRightRocketNear = "PanelAndCargo"
        Else
            redTopRightRocketNear = "None"
        End If


        'Blue Rocket Placement Scoring'
        If blue_rocket_far_bay1 = 0 Then
            blueLowLeftRocketFar = "None"
        ElseIf blue_rocket_far_bay1 = 1 Then
            blueLowLeftRocketFar = "Panel"
        ElseIf blue_rocket_far_bay1 = 2 Then
            blueLowLeftRocketFar = "PanelAndCargo"
        Else
            blueLowLeftRocketFar = "None"
        End If

        If blue_rocket_far_bay2 = 0 Then
            blueLowRightRocketFar = "None"
        ElseIf blue_rocket_far_bay2 = 1 Then
            blueLowRightRocketFar = "Panel"
        ElseIf blue_rocket_far_bay2 = 2 Then
            blueLowRightRocketFar = "PanelAndCargo"
        Else
            blueLowRightRocketFar = "None"
        End If

        If blue_rocket_far_bay3 = 0 Then
            blueMidLeftRocketFar = "None"
        ElseIf blue_rocket_far_bay3 = 1 Then
            blueMidLeftRocketFar = "Panel"
        ElseIf blue_rocket_far_bay3 = 2 Then
            blueMidLeftRocketFar = "PanelAndCargo"
        Else
            blueMidLeftRocketFar = "None"
        End If

        If blue_rocket_far_bay4 = 0 Then
            blueMidRightRocketFar = "None"
        ElseIf blue_rocket_far_bay4 = 1 Then
            blueMidRightRocketFar = "Panel"
        ElseIf blue_rocket_far_bay4 = 2 Then
            blueMidRightRocketFar = "PanelAndCargo"
        Else
            blueMidRightRocketFar = "None"
        End If

        If blue_rocket_far_bay5 = 0 Then
            blueTopLeftRocketFar = "None"
        ElseIf blue_rocket_far_bay5 = 1 Then
            blueTopLeftRocketFar = "Panel"
        ElseIf blue_rocket_far_bay5 = 2 Then
            blueTopLeftRocketFar = "PanelAndCargo"
        Else
            blueTopLeftRocketFar = "None"
        End If

        If blue_rocket_far_bay6 = 0 Then
            blueTopRightRocketFar = "None"
        ElseIf blue_rocket_far_bay6 = 1 Then
            blueTopRightRocketFar = "Panel"
        ElseIf blue_rocket_far_bay6 = 2 Then
            blueTopRightRocketFar = "PanelAndCargo"
        Else
            blueTopRightRocketFar = "None"
        End If

        If blue_rocket_near_bay1 = 0 Then
            blueLowRightRocketNear = "None"
        ElseIf blue_rocket_near_bay1 = 1 Then
            blueLowRightRocketNear = "Panel"
        ElseIf blue_rocket_near_bay1 = 2 Then
            blueLowRightRocketNear = "PanelAndCargo"
        Else
            blueLowRightRocketNear = "None"
        End If

        If blue_rocket_near_bay2 = 0 Then
            blueLowLeftRocketNear = "None"
        ElseIf blue_rocket_near_bay2 = 1 Then
            blueLowLeftRocketNear = "Panel"
        ElseIf blue_rocket_near_bay2 = 2 Then
            blueLowLeftRocketNear = "PanelAndCargo"
        Else
            blueLowLeftRocketNear = "None"
        End If

        If blue_rocket_near_bay3 = 0 Then
            blueMidLeftRocketNear = "None"
        ElseIf blue_rocket_near_bay3 = 1 Then
            blueMidLeftRocketNear = "Panel"
        ElseIf blue_rocket_near_bay3 = 2 Then
            blueMidLeftRocketNear = "PanelAndCargo"
        Else
            blueMidLeftRocketNear = "None"
        End If

        If blue_rocket_near_bay4 = 0 Then
            blueMidRightRocketNear = "None"
        ElseIf blue_rocket_near_bay4 = 1 Then
            blueMidRightRocketNear = "Panel"
        ElseIf blue_rocket_near_bay4 = 2 Then
            blueMidRightRocketNear = "PanelAndCargo"
        Else
            blueMidRightRocketNear = "None"
        End If

        If blue_rocket_near_bay5 = 0 Then
            blueTopLeftRocketNear = "None"
        ElseIf blue_rocket_near_bay5 = 1 Then
            blueTopLeftRocketNear = "Panel"
        ElseIf blue_rocket_near_bay5 = 2 Then
            blueTopLeftRocketNear = "PanelAndCargo"
        Else
            blueTopLeftRocketNear = "None"
        End If

        If blue_rocket_near_bay6 = 0 Then
            blueTopRightRocketNear = "None"
        ElseIf blue_rocket_near_bay6 = 1 Then
            blueTopRightRocketNear = "Panel"
        ElseIf blue_rocket_near_bay6 = 2 Then
            blueTopRightRocketNear = "PanelAndCargo"
        Else
            blueTopRightRocketNear = "None"
        End If

    End Sub

    Public Shared Sub handleFieldOuputs()
        'If match is ready to start'
        If Field_Ready = True Then

        Else

        End If
        'If match is running'
        If fieldStatus = MatchEnums.SandStorm Or fieldStatus = MatchEnums.TeleOp Or fieldStatus = MatchEnums.EndGameWarning Or fieldStatus = MatchEnums.EndGame Then

        Else

        End If
        'If match is over'
        If fieldStatus = MatchEnums.PostMatch Then

        Else

        End If
        'if match is estopped'
        If fieldStatus = MatchEnums.AbortMatch Then

        Else

        End If
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

        If fieldStatus = MatchEnums.TeleOp Then
            redSandstormUp = True
            blueSandstormUp = True
            Threading.Thread.Sleep(1000)
            redSandstormUp = False
            blueSandstormUp = False
        Else
            redSandstormUp = False
            blueSandstormUp = False
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
        If redCompleteRocketFar = True Then
            'ADD in the functions'
        End If

        If redCompleteRocketNear = True Then

        End If

        If blueCompleteRocketFar = True Then

        End If

        If blueCompleteRocketNear = True Then

        End If
    End Sub

    Public Shared Sub writeCoils()
        'This writes the values to the plc'
        'I.E. modbusClient.WriteSingleCoil(0, redCargoshipMagnet)'
        'TODO Add real values'
        modbusClient.WriteSingleCoil(0, redCargoshipMagnet)
        modbusClient.WriteSingleCoil(1, redCargoshipLight)
        modbusClient.WriteSingleCoil(2, blueCargoshipMagnet)
        modbusClient.WriteSingleCoil(3, blueCargoshipLight)
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
        Dim readRegisters() As Integer = modbusClient.ReadHoldingRegisters(0, 200)
        'Hatch and Cargo Counts'
        red_hatch_count = readRegisters(0)
        red_cargo_count = readRegisters(1)
        blue_hatch_count = readRegisters(2)
        blue_cargo_count = readRegisters(3)
        'Foul Counts'
        red_foul_count = readRegisters(4)
        red_tech_count = readRegisters(5)
        blue_foul_count = readRegisters(6)
        blue_tech_count = readRegisters(7)
        'Red Rocket Placement'
        red_rocket_far_bay1 = readRegisters(8)
        red_rocket_far_bay2 = readRegisters(9)
        red_rocket_far_bay3 = readRegisters(10)
        red_rocket_far_bay4 = readRegisters(11)
        red_rocket_far_bay5 = readRegisters(12)
        red_rocket_far_bay6 = readRegisters(13)
        red_rocket_near_bay1 = readRegisters(14)
        red_rocket_near_bay2 = readRegisters(15)
        red_rocket_near_bay3 = readRegisters(16)
        red_rocket_near_bay4 = readRegisters(17)
        red_rocket_near_bay5 = readRegisters(18)
        red_rocket_near_bay6 = readRegisters(19)
        'Red Cargoship Placement'
        red_cs_bay1 = readRegisters(20)
        red_cs_bay2 = readRegisters(21)
        red_cs_bay3 = readRegisters(22)
        red_cs_bay4 = readRegisters(23)
        red_cs_bay5 = readRegisters(24)
        red_cs_bay6 = readRegisters(25)
        red_cs_bay7 = readRegisters(26)
        red_cs_bay8 = readRegisters(27)
        'Blue Rocket Placement'
        blue_rocket_far_bay1 = readRegisters(28)
        blue_rocket_far_bay2 = readRegisters(29)
        blue_rocket_far_bay3 = readRegisters(30)
        blue_rocket_far_bay4 = readRegisters(31)
        blue_rocket_far_bay5 = readRegisters(32)
        blue_rocket_far_bay6 = readRegisters(33)
        blue_rocket_near_bay1 = readRegisters(34)
        blue_rocket_near_bay2 = readRegisters(35)
        blue_rocket_near_bay3 = readRegisters(36)
        blue_rocket_near_bay4 = readRegisters(37)
        blue_rocket_near_bay5 = readRegisters(38)
        blue_rocket_near_bay6 = readRegisters(39)
        'Blue Cargoship Placement'
        blue_cs_bay1 = readRegisters(40)
        blue_cs_bay2 = readRegisters(41)
        blue_cs_bay3 = readRegisters(42)
        blue_cs_bay4 = readRegisters(43)
        blue_cs_bay5 = readRegisters(44)
        blue_cs_bay6 = readRegisters(45)
        blue_cs_bay7 = readRegisters(46)
        blue_cs_bay8 = readRegisters(47)
    End Sub
End Class
