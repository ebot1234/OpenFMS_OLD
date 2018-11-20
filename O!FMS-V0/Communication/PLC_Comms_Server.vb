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
        modbusClient.WriteSingleRegister(7, RedT1)
        modbusClient.WriteSingleRegister(8, RedT2)
        modbusClient.WriteSingleRegister(9, RedT3)
        modbusClient.WriteSingleRegister(10, BlueT1)
        modbusClient.WriteSingleRegister(11, BlueT2)
        modbusClient.WriteSingleRegister(12, BlueT3)

        'modbusClient.WriteMultipleCoils(16, New Boolean() {True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True})
        'Write Coils starting with Address 16

    End Sub




    '    Public Sub New(ByVal addressFamily As AddressFamily, ByVal socketType As SocketType, ByVal protocolType As ProtocolType)



    '        Dim bindAddress As IPAddress, parsedAddress As IPAddress

    '        bindAddress = IPAddress.Any
    '        bindAddress = IPAddress.IPv6Any


    '        Try
    '            'set to the FMS Computer Ip
    '            parsedAddress = IPAddress.Parse("10.0.0.5")
    '            parsedAddress = IPAddress.Parse("fe80::2ff:abcd:1234%3")
    '        Catch err As FormatException
    '            Console.WriteLine("Invalid IP Address", err.Message)
    '        End Try


    '        Dim bindEndPoint As IPEndPoint = New IPEndPoint(bindAddress, 5000)
    '        Dim plcSocket = Nothing

    '        Try
    '            plcSocket = New Socket(bindAddress.AddressFamily, socketType.Dgram, protocolType.Udp)
    '            plcSocket.Bind(bindEndPoint)
    '        Catch err As SocketException
    '            If (Not plcSocket Is Nothing) Then
    '                plcSocket.Close()
    '            End If
    '        End Try

    '        Dim tcpSocket As Socket
    '        Dim resolvedServer As IPHostEntry
    '        Dim serverEndPoint As IPEndPoint
    '        Dim addr As IPAddress

    '        tcpSocket = Nothing

    '        Try
    '            resolvedServer = Dns.GetHostEntry("PLC Connection")
    '            For Each addr In resolvedServer.AddressList
    '                serverEndPoint = New IPEndPoint(addr, 5000)
    '                tcpSocket = New Socket(addr.AddressFamily, socketType.Stream, protocolType.Tcp)
    '                Try
    '                    tcpSocket.Connect(serverEndPoint)

    '                Catch ex As Exception
    '                    If (Not tcpSocket Is Nothing) Then
    '                        tcpSocket.Close()
    '                    End If
    '                    GoTo ContinueLoop
    '                End Try
    'ContinueLoop:
    '            Next
    '        Catch ex As Exception
    '            Console.WriteLine("Client connection failed: {0}")
    '        End Try
    '        'Now we communicate with a TCP Socket with the Server'
    '        Dim ClientSocket As Socket

    '        Dim dataBuffer(1024) As Byte 'sample byte'


    '        Try
    '            ClientSocket.Send(dataBuffer)
    '            'ClientSocket.Send() 'Add the packets to the send method'
    '        Catch ex As Exception
    '            Console.WriteLine("Send Failed {0}")
    '        End Try

    '        Dim destAddress As IPAddress = IPAddress.Parse("10.0.0.5")
    '        Dim destEndPoint As IPEndPoint = New IPEndPoint(destAddress, 8000)
    '        Dim udpSocket As Socket
    '        Dim message() As Byte = System.Text.Encoding.ASCII.GetBytes("Hello World")

    '        udpSocket = New Socket(destAddress.AddressFamily, socketType.Dgram, protocolType.Udp)

    '        Try
    '            udpSocket.SendTo(message, destEndPoint)
    '        Catch ex As Exception
    '            Console.WriteLine("Send To Failed {0}")
    '        End Try
    '        'Receive Data'
    '        Dim receiveBuffer(1024) As Byte
    '        Dim senderEndPoint As IPEndPoint = New IPEndPoint(bindAddress.AddressFamily, 0)
    '        Dim castSenderEndPoint As EndPoint = CType(senderEndPoint, EndPoint)
    '        Dim rc As Integer

    '        udpSocket = New Socket(bindAddress.AddressFamily, socketType.Dgram, protocolType.Udp)
    '        Try
    '            udpSocket.Bind(bindEndPoint)
    '            udpSocket.ReceiveFrom(receiveBuffer, castSenderEndPoint)
    '            senderEndPoint = CType(castSenderEndPoint, IPEndPoint)
    '            Console.WriteLine("Received {0} byte from {1}", rc, senderEndPoint.ToString())
    '        Catch ex As Exception
    '            Console.WriteLine("Error Occurred: {0}")
    '        Finally
    '            udpSocket.Close()
    '        End Try

    '        Dim requestBuffer(1024) As Byte

    '        Try
    '            tcpSocket.Send(requestBuffer)
    '            tcpSocket.Shutdown(SocketShutdown.Send)

    '            Do While True
    '                rc = tcpSocket.Receive(requestBuffer)
    '                'may need to change the shutdown data rate'
    '                If (rc > 1) Then
    '                ElseIf (rc = 1) Then
    '                    Exit Do
    '                End If
    '            Loop

    '        Catch ex As Exception
    '            Console.WriteLine("An Error Occurred: {0}")
    '        End Try
    '    End Sub
    'Varibles for the packets'
    'Dim LIGHT_OFF As Byte = "0"
    'Dim LIGHT_ON As Byte = "1"
    'Dim LIGHT_BLINKING As Byte = "S"
    'Dim FIELD_OFF As Byte = "0"
    'Dim FIELD_ON As Byte = "1"
    'Dim FIELD_BLINKING As Byte = "S"
    'Dim LIGHT_MODE As Byte = "L"
    'Dim TEAM_NUM_MODE As Byte = "N"
    'Dim TIME_MODE As Byte = "T"
    'Dim VIEW_MODE As Byte = "V"
    'Dim BYTE_ZERO As Byte = "0"
    'Dim BYTE_CLEAR As Byte = BYTE_ZERO
    'Dim HW_MODE As Byte = "H"

    ''Scale byte
    'Dim SCALE_SENSOR1 As Byte = "SS1"
    'Dim SCALE_SENSOR2 As Byte = "SS2"

    ''Red side Switch
    'Dim RED_SWITCH_SENSOR1 As Byte = "RSS1"
    'Dim RED_SWITCH_SENSOR2 As Byte = "RSS2"

    ''Blue side Switch
    'Dim BLUE_SWITCH_SENSOR2 As Byte = "BSS2"
    'Dim BLUE_SWITCH_SENSOR1 As Byte = "BSS1"
    'Dim NeitherAlliance As Byte = "NA"

    'Private Shared RED As Integer = FieldAndRobots.RED
    'Private Shared BLUE As Integer = FieldAndRobots.BLUE
    'Private Shared ONE As Integer = FieldAndRobots.ONE
    'Private Shared TWO As Integer = FieldAndRobots.TWO
    'Private Shared THREE As Integer = FieldAndRobots.THREE
    'Private Shared matchTime As String = "0010"

    'Build the Packets to send to the PLC'

    'Private Function buildTimeModePacket(ByVal clientSocket As Socket) As Byte
    '    Dim data() As Byte = New Byte((9) - 1) {}
    '    Dim i As Integer = 0
    '    Do While (i < 9)
    '        data(i) = BYTE_ZERO
    '        i = (i + 1)
    '    Loop
    '    If (Not (GovernThread.getInstance) Is Nothing) Then
    '        matchTime = Me.checkAndFixNum(GovernThread.getInstance.get_PLC_Time, 4)
    '    Else

    '    End If

    '    Console.WriteLine("matchTime", matchTime)
    '    data(0) = TIME_MODE
    '    data(1) = matchTime.Substring(0, 1)
    '    data(2) = matchTime.Substring(1, 2)
    '    data(3) = matchTime.Substring(2, 3)
    '    data(4) = matchTime.Substring(3, 4)

    '    Return data(9)
    'End Function

    'Private Function checkAndFixNum(ByVal initTime As String, ByVal length As Integer) As String
    '    If (initTime.Length < length) Then
    '        initTime = "0".Concat(initTime)
    '        Return Me.checkAndFixNum(initTime, length)
    '    End If

    '    Return initTime
    'End Function



End Class