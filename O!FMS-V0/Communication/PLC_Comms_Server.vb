Imports EasyModbus
Imports O_FMS_V0.Field
Imports O_FMS_V0.Lighting



Public Class PLC_Comms_Server
    'To check if PLC is connected'
    Public Shared isPlcConnected = False

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
    Public Shared PLC_Used_Boost_Red
    Public Shared PLC_Blue_Boost_1_Cube
    Public Shared PLC_Blue_Boost_2_Cube
    Public Shared PLC_Blue_Boost_3_Cube
    Public Shared PLC_Blue_Force_1_Cube
    Public Shared PLC_Blue_Force_2_Cube
    Public Shared PLC_Blue_Force_3_Cube
    Public Shared PLC_Blue_Lev_1_Cube
    Public Shared PLC_Blue_Lev_2_Cube
    Public Shared PLC_Blue_Lev_3_Cube
    Public Shared PLC_Red_Boost_1_Cube
    Public Shared PLC_Red_Boost_2_Cube
    Public Shared PLC_Red_Boost_3_Cube
    Public Shared PLC_Red_Force_1_Cube
    Public Shared PLC_Red_Force_2_Cube
    Public Shared PLC_Red_Force_3_Cube
    Public Shared PLC_Red_Lev_1_Cube
    Public Shared PLC_Red_Lev_2_Cube
    Public Shared PLC_Red_Lev_3_Cube
    Public Shared PLC_Used_Force_Red
    Public Shared PLC_Used_Lev_Red
    Public Shared PLC_Used_Boost_Blue
    Public Shared PLC_Used_Force_Blue
    Public Shared PLC_Used_Lev_Blue
    Public Shared PLC_Match_Timer
    Public Shared PLC_Match_Mode
    Public Shared PLC_RedPen_Ref
    Public Shared PLC_BluePen_Ref
    Public Shared PLC_BlueScaleOwned
    Public Shared PLC_RedScaleOwned
    Public Shared PLC_BlueSWOwned
    Public Shared PLC_RedSWOwned
    Public Shared PLC_RedSWBOwned
    Public Shared PLC_BlueSWROwned
    Public Shared PLC_Field_Reset
    Public Shared PLC_Field_Volunteers


    'Data Sent from FMS Software to PLC
    Public Shared CargoshipEnabled
    Public Shared CargoshipReleased
    Public Shared SandstormActive

    Public Shared Game_Data
    Public Shared PLC_Game_Data

    Public Shared Match_Start
    Public Shared Match_Stop
    Public Shared Match_PreStart
    Public Shared PLC_Reset
    Public Shared Red1Ready
    Public Shared Red2Ready
    Public Shared Red3Ready
    Public Shared Blue1Ready
    Public Shared Blue2Ready
    Public Shared Blue3Ready


    'Alliance Station Lights

    Public Shared Alliance_Light_Test
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


    'Teams
    Public Shared RedT1, RedT2, RedT3, BlueT1, BlueT2, BlueT3

    Public Shared modbusClient As ModbusClient = New ModbusClient("10.0.0.7", 502)

    Public Shared Sub ConnectPLC()
        Try
            modbusClient.Connect()
            isPlcConnected = True
        Catch e As Exception
            MessageBox.Show("PLC Not Connected")
        End Try
    End Sub

    Public Shared Sub DisconnectPLC()
        modbusClient.Disconnect()
    End Sub

    Public Shared Sub Modbus_Main(ByVal args() As String)
        Dim readCoils() As Boolean = modbusClient.ReadCoils(0, 66)
        'Read 66 Coils from Server, starting with address 0

        Dim readHoldingRegisters() As Integer = modbusClient.ReadHoldingRegisters(0, 20)
        'Read 20 Holding Registers from Server, starting with Address 0

        ' Output
        Dim i As Integer = 0
        Do While (i < readCoils.Length)
            Console.WriteLine(("Value of Coil " + ((42 + (i + 1)) + (" " + readCoils(i).ToString))))
            'Estops'
            PLC_Estop_Field = readCoils(0)
            PLC_Estop_Red1 = readCoils(1)
            PLC_Estop_Red2 = readCoils(2)
            PLC_Estop_Red3 = readCoils(3)
            PLC_Estop_Blue1 = readCoils(4)
            PLC_Estop_Blue2 = readCoils(5)
            PLC_Estop_Blue3 = readCoils(6)

            PLC_Field_Reset = readCoils(47)
            PLC_Field_Volunteers = readCoils(48)

            i = (i + 1)
        Loop


        Dim j As Integer = 0
        Console.WriteLine(("Value of HoldingRegister " + ((j + 1) + (" " + readHoldingRegisters(j).ToString))))

        PLC_Match_Timer = readHoldingRegisters(0)
        PLC_Match_Mode = readHoldingRegisters(1)
        PLC_RedScore = readHoldingRegisters(2)
        PLC_BlueScore = readHoldingRegisters(3)
        PLC_RedPen_Ref = readHoldingRegisters(5)
        PLC_BluePen_Ref = readHoldingRegisters(6)




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


    End Sub

    Public Shared Sub handleRegisters()
        Dim readHoldingRegisters = modbusClient.ReadHoldingRegisters(0, 6)

        Do While (True)
            PLC_Match_Timer = readHoldingRegisters(0)
            PLC_Match_Mode = readHoldingRegisters(1)
            PLC_RedScore = readHoldingRegisters(2)
            PLC_BlueScore = readHoldingRegisters(3)
            PLC_RedPen_Ref = readHoldingRegisters(5)
            PLC_BluePen_Ref = readHoldingRegisters(6)
        Loop
    End Sub

    Public Shared Sub handleFieldOuputs()
        Do While (True)
            'handles field status'
            If Match_Start = True Then
                modbusClient.WriteSingleCoil(13, True)
            End If

            If Match_Stop = True Then
                modbusClient.WriteSingleCoil(14, True)
            End If

            If PLC_Reset = True Then
                modbusClient.WriteSingleCoil(15, True)
            End If

            'handles the scoring table light testing'
            If Scoring_Light_Test = True Then
                'FieldGreen'
                modbusClient.WriteSingleCoil(28, True)
                'FieldBlue'
                modbusClient.WriteSingleCoil(29, True)
                'FieldRed'
                modbusClient.WriteSingleCoil(30, True)
                'FieldAmber'
                modbusClient.WriteSingleCoil(31, True)
            End If

            'handles the alliance station light testing'
            If Alliance_Light_Test = True Then
                'StnRed1Red
                modbusClient.WriteSingleCoil(16, True)
                'StnRed2Red
                modbusClient.WriteSingleCoil(17, True)
                'StnRed3Red
                modbusClient.WriteSingleCoil(18, True)
                'StnRed1Amb
                modbusClient.WriteSingleCoil(19, True)
                'StnRed2Amb
                modbusClient.WriteSingleCoil(20, True)
                'StnRed3Amb
                modbusClient.WriteSingleCoil(21, True)
                'StnBlue1Blue
                modbusClient.WriteSingleCoil(22, True)
                'StnBlue2Blue
                modbusClient.WriteSingleCoil(23, True)
                'StnBlue3Blue
                modbusClient.WriteSingleCoil(24, True)
                'StnBlue1Amb
                modbusClient.WriteSingleCoil(25, True)
                'StnBlue2Amb
                modbusClient.WriteSingleCoil(26, True)
                'StnBlue3Amb
                modbusClient.WriteSingleCoil(27, True)

                Threading.Thread.Sleep(2000)

                'StnRed1Red
                modbusClient.WriteSingleCoil(16, False)
                'StnRed2Red
                modbusClient.WriteSingleCoil(17, False)
                'StnRed3Red
                modbusClient.WriteSingleCoil(18, False)
                'StnRed1Amb
                modbusClient.WriteSingleCoil(19, False)
                'StnRed2Amb
                modbusClient.WriteSingleCoil(20, False)
                'StnRed3Amb
                modbusClient.WriteSingleCoil(21, False)
                'StnBlue1Blue
                modbusClient.WriteSingleCoil(22, False)
                'StnBlue2Blue
                modbusClient.WriteSingleCoil(23, False)
                'StnBlue3Blue
                modbusClient.WriteSingleCoil(24, False)
                'StnBlue1Amb
                modbusClient.WriteSingleCoil(25, False)
                'StnBlue2Amb
                modbusClient.WriteSingleCoil(26, False)
                'StnBlue3Amb
                modbusClient.WriteSingleCoil(27, False)
            End If

            'handles the team lights'
            If Red1Ready Then
                modbusClient.WriteSingleCoil(32, True)
            Else : modbusClient.WriteSingleCoil(32, False)
            End If

            If Red2Ready Then
                modbusClient.WriteSingleCoil(33, True)
            Else : modbusClient.WriteSingleCoil(33, False)
            End If

            If Red3Ready Then
                modbusClient.WriteSingleCoil(34, True)
            Else : modbusClient.WriteSingleCoil(34, False)
            End If

            If Blue1Ready Then
                modbusClient.WriteSingleCoil(35, True)
            Else : modbusClient.WriteSingleCoil(35, False)
            End If

            If Blue2Ready Then
                modbusClient.WriteSingleCoil(36, True)
            Else : modbusClient.WriteSingleCoil(36, False)
            End If

            If Blue3Ready Then
                modbusClient.WriteSingleCoil(37, True)
            Else : modbusClient.WriteSingleCoil(37, False)
            End If

            'Sends the team numbers to the ViewMarq Displays via PLC
            modbusClient.WriteSingleRegister(10, RedT1)
            modbusClient.WriteSingleRegister(11, RedT2)
            modbusClient.WriteSingleRegister(12, RedT3)
            modbusClient.WriteSingleRegister(13, BlueT1)
            modbusClient.WriteSingleRegister(14, BlueT2)
            modbusClient.WriteSingleRegister(15, BlueT3)
        Loop
    End Sub

    Public Shared Sub handleGameOutputs()
        Do While (True)
            'Releases the magnets on the Cargoship'
            If CargoshipEnabled = False Then
                modbusClient.WriteSingleCoil(40, True)
                modbusClient.WriteSingleCoil(41, True)
                modbusClient.WriteSingleCoil(42, False)
                modbusClient.WriteSingleCoil(43, False)
            End If

            'Enables the magnets on the Cargoships'
            If CargoshipEnabled = True Then
                modbusClient.WriteSingleCoil(40, False)
                modbusClient.WriteSingleCoil(41, False)
                modbusClient.WriteSingleCoil(42, True)
                modbusClient.WriteSingleCoil(43, True)
            End If

            If SandstormActive = False Then
                modbusClient.WriteSingleCoil(44, True)
                Threading.Thread.Sleep(1500)
                modbusClient.WriteSingleCoil(44, False)
                SandstormActive = True
            End If
        Loop
    End Sub

    Public Shared Sub handleEstops()
        'Reads and sets the Estops for teams'
        Dim readCoils() As Boolean = modbusClient.ReadCoils(0, 4)

        Do While (True)
            PLC_Estop_Field = readCoils(0)
            PLC_Estop_Red1 = readCoils(1)
            PLC_Estop_Red2 = readCoils(2)
            PLC_Estop_Red3 = readCoils(3)

            'Estops all robots on the field'
            If PLC_Estop_Field = False Then
                Red1DS.Estop = False
                Red2DS.Estop = False
                Red3DS.Estop = False
                Blue1DS.Estop = False
                Blue2DS.Estop = False
                Blue3DS.Estop = False
            End If

            'Estops Red 1'
            If PLC_Estop_Red1 = False Then
                Red1DS.Estop = False
            End If

            'Estops Red 2'
            If PLC_Estop_Red2 = False Then
                Red2DS.Estop = False
            End If

            'Estops Red 3'
            If PLC_Estop_Red3 = False Then
                Red3DS.Estop = False
            End If

            'Estops Blue 1'
            If PLC_Estop_Blue1 = False Then
                Blue1DS.Estop = False
            End If

            'Estops Blue 2'
            If PLC_Estop_Blue2 = False Then
                Blue2DS.Estop = False
            End If

            'Estops Blue 3'
            If PLC_Estop_Blue3 = False Then
                Blue3DS.Estop = False
            End If
        Loop
    End Sub

End Class
