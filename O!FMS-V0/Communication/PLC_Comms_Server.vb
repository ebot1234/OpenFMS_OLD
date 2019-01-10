Imports EasyModbus
Imports O_FMS_V0.RandomString



Public Class PLC_Comms_Server



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

    Public Shared RedCargoShipPlatesRelease
    Public Shared BlueCargoShipPlatesRelease
    Public Shared ResetCargoShips
    Public Shared BlueCargoShipLight
    Public Shared RedCargoShipLight

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


            PLC_Estop_Field = readCoils(0)
            PLC_Estop_Red1 = readCoils(1)
            PLC_Estop_Red2 = readCoils(2)
            PLC_Estop_Red3 = readCoils(3)
            PLC_Estop_Blue1 = readCoils(4)
            PLC_Estop_Blue2 = readCoils(5)
            PLC_Estop_Blue3 = readCoils(6)


            PLC_Used_Boost_Red = readCoils(7)
            PLC_Used_Force_Red = readCoils(8)
            PLC_Used_Lev_Red = readCoils(9)
            PLC_Used_Boost_Blue = readCoils(10)
            PLC_Used_Force_Blue = readCoils(11)
            PLC_Used_Lev_Blue = readCoils(12)


            PLC_BlueScaleOwned = readCoils(40)
            PLC_BlueSWOwned = readCoils(41)
            PLC_RedSWOwned = readCoils(42)
            PLC_RedScaleOwned = readCoils(43)
            PLC_BlueSWROwned = readCoils(45)
            PLC_RedSWBOwned = readCoils(46)

            PLC_Field_Reset = readCoils(47)
            PLC_Field_Volunteers = readCoils(48)

            'Blue powerup levels'
            PLC_Blue_Boost_1_Cube = readCoils(49)
            PLC_Blue_Boost_2_Cube = readCoils(50)
            PLC_Blue_Boost_3_Cube = readCoils(51)
            PLC_Blue_Force_1_Cube = readCoils(52)
            PLC_Blue_Force_2_Cube = readCoils(53)
            PLC_Blue_Force_3_Cube = readCoils(54)
            PLC_Blue_Lev_1_Cube = readCoils(55)
            PLC_Blue_Lev_2_Cube = readCoils(56)
            PLC_Blue_Lev_3_Cube = readCoils(57)

            'Red powerup levels'
            PLC_Red_Boost_1_Cube = readCoils(58)
            PLC_Red_Boost_2_Cube = readCoils(59)
            PLC_Red_Boost_3_Cube = readCoils(60)
            PLC_Red_Force_1_Cube = readCoils(61)
            PLC_Red_Force_2_Cube = readCoils(62)
            PLC_Red_Force_3_Cube = readCoils(63)
            PLC_Red_Lev_1_Cube = readCoils(64)
            PLC_Red_Lev_2_Cube = readCoils(65)
            PLC_Red_Lev_3_Cube = readCoils(66)



            i = (i + 1)
        Loop


        Dim j As Integer = 0
        Do While (j < readHoldingRegisters.Length)
            Console.WriteLine(("Value of HoldingRegister " + ((j + 1) + (" " + readHoldingRegisters(j).ToString))))

            PLC_Match_Timer = readHoldingRegisters(0)
            PLC_Match_Mode = readHoldingRegisters(1)
            PLC_RedScore = readHoldingRegisters(2)
            PLC_BlueScore = readHoldingRegisters(3)
            PLC_RedPen_Ref = readHoldingRegisters(5)
            PLC_BluePen_Ref = readHoldingRegisters(6)


            j = (j + 1)
        Loop



        If Match_Start = True Then
            modbusClient.WriteSingleCoil(13, True)
            'Writes value True to Coil Address 13
        End If

        If Match_Stop = True Then
            modbusClient.WriteSingleCoil(14, True)
        End If

        If PLC_Reset = True Then
            modbusClient.WriteSingleCoil(15, True)
        End If

        If RedCargoShipPlatesRelease = True Then
            modbusClient.WriteSingleCoil(40, True)
        End If

        If BlueCargoShipPlatesRelease = True Then
            modbusClient.WriteSingleCoil(41, True)
        End If

        'Alliance Light Test
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

        End If

        If Scoring_Light_Test = True Then

            'FieldGreen
            modbusClient.WriteSingleCoil(28, True)
            'FieldBlue
            modbusClient.WriteSingleCoil(29, True)
            'FieldRed
            modbusClient.WriteSingleCoil(30, True)
            'FieldAmber
            modbusClient.WriteSingleCoil(31, True)

        End If


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

        'GameData to PLC
        modbusClient.WriteSingleRegister(4, GamedataUse)


        'Teams To PLC
        modbusClient.WriteSingleRegister(10, RedT1)
        modbusClient.WriteSingleRegister(11, RedT2)
        modbusClient.WriteSingleRegister(12, RedT3)
        modbusClient.WriteSingleRegister(13, BlueT1)
        modbusClient.WriteSingleRegister(14, BlueT2)
        modbusClient.WriteSingleRegister(15, BlueT3)

        'modbusClient.WriteMultipleCoils(16, New Boolean() {True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True})
        'Write Coils starting with Address 16

    End Sub

End Class
