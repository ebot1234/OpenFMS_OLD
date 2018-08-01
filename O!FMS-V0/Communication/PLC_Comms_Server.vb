Imports System.Net
Imports System.Net.Sockets
Imports System
Imports System.Collections
Imports System.Security.Cryptography
Imports myOPC
Imports OPCAutomation



Public Class PLC_Comms_Server

    

    'Estops bidirectional communications
    Public Shared PLC_Estop_Red1
    Public Shared PLC_Estop_Red2
    Public Shared PLC_Estop_Red3
    Public Shared PLC_Estop_Blue1
    Public Shared PLC_Estop_Blue2
    Public Shared PLC_Estop_Blue3
    Public Shared PLC_Estop_Field

    'Driver Station Linked (Pulled from DS)
    Public Shared DS_Linked_Red1
    Public Shared DS_Linked_Red2
    Public Shared DS_Linked_Red3
    Public Shared DS_Linked_Blue1
    Public Shared DS_Linked_Blue2
    Public Shared DS_Linked_Blue3

    'Robot Linked (Pulled from DS)
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
    Public Shared PLC_Used_Force_Red
    Public Shared PLC_Used_Lev_Red
    Public Shared PLC_Used_Boost_Blue
    Public Shared PLC_Used_Force_Blue
    Public Shared PLC_Used_Lev_Blue
    Public Shared PLC_Match_Timer
    Public Shared PLC_Match_Mode

    'Data Sent from FMS Software to PLC
    Public Shared Game_Data
    Public Shared Match_Start
    Public Shared Match_Stop
    Public Shared PLC_Reset







    Public Sub New(ByVal addressFamily As AddressFamily, ByVal socketType As SocketType, ByVal protocolType As ProtocolType)



        Dim bindAddress As IPAddress, parsedAddress As IPAddress

        bindAddress = IPAddress.Any
        bindAddress = IPAddress.IPv6Any


        Try
            'set to the FMS Computer Ip
            parsedAddress = IPAddress.Parse("10.0.0.5")
            parsedAddress = IPAddress.Parse("fe80::2ff:abcd:1234%3")
        Catch err As FormatException
            Console.WriteLine("Invalid IP Address", err.Message)
        End Try


        Dim bindEndPoint As IPEndPoint = New IPEndPoint(bindAddress, 5000)
        Dim plcSocket = Nothing

        Try
            plcSocket = New Socket(bindAddress.AddressFamily, socketType.Dgram, protocolType.Udp)
            plcSocket.Bind(bindEndPoint)
        Catch err As SocketException
            If (Not plcSocket Is Nothing) Then
                plcSocket.Close()
            End If
        End Try

        Dim tcpSocket As Socket
        Dim resolvedServer As IPHostEntry
        Dim serverEndPoint As IPEndPoint
        Dim addr As IPAddress

        tcpSocket = Nothing

        Try
            resolvedServer = Dns.GetHostEntry("PLC Connection")
            For Each addr In resolvedServer.AddressList
                serverEndPoint = New IPEndPoint(addr, 5000)
                tcpSocket = New Socket(addr.AddressFamily, socketType.Stream, protocolType.Tcp)
                Try
                    tcpSocket.Connect(serverEndPoint)

                Catch ex As Exception
                    If (Not tcpSocket Is Nothing) Then
                        tcpSocket.Close()
                    End If
                    GoTo ContinueLoop
                End Try
ContinueLoop:
            Next
        Catch ex As Exception
            Console.WriteLine("Client connection failed: {0}")
        End Try
        'Now we communicate with a TCP Socket with the Server'
        Dim ClientSocket As Socket

        Dim dataBuffer(1024) As Byte 'sample byte'


        Try
            ClientSocket.Send(dataBuffer)
            ClientSocket.Send() 'Add the packets to the send method'
        Catch ex As Exception
            Console.WriteLine("Send Failed {0}")
        End Try

        Dim destAddress As IPAddress = IPAddress.Parse("10.0.0.5")
        Dim destEndPoint As IPEndPoint = New IPEndPoint(destAddress, 8000)
        Dim udpSocket As Socket
        Dim message() As Byte = System.Text.Encoding.ASCII.GetBytes("Hello World")

        udpSocket = New Socket(destAddress.AddressFamily, socketType.Dgram, protocolType.Udp)

        Try
            udpSocket.SendTo(message, destEndPoint)
        Catch ex As Exception
            Console.WriteLine("Send To Failed {0}")
        End Try
        'Receive Data'
        Dim receiveBuffer(1024) As Byte
        Dim senderEndPoint As IPEndPoint = New IPEndPoint(bindAddress.AddressFamily, 0)
        Dim castSenderEndPoint As EndPoint = CType(senderEndPoint, EndPoint)
        Dim rc As Integer

        udpSocket = New Socket(bindAddress.AddressFamily, socketType.Dgram, protocolType.Udp)
        Try
            udpSocket.Bind(bindEndPoint)
            udpSocket.ReceiveFrom(receiveBuffer, castSenderEndPoint)
            senderEndPoint = CType(castSenderEndPoint, IPEndPoint)
            Console.WriteLine("Received {0} byte from {1}", rc, senderEndPoint.ToString())
        Catch ex As Exception
            Console.WriteLine("Error Occurred: {0}")
        Finally
            udpSocket.Close()
        End Try

        Dim requestBuffer(1024) As Byte

        Try
            tcpSocket.Send(requestBuffer)
            tcpSocket.Shutdown(SocketShutdown.Send)

            Do While True
                rc = tcpSocket.Receive(requestBuffer)
                'may need to change the shutdown data rate'
                If (rc > 1) Then
                ElseIf (rc = 1) Then
                    Exit Do
                End If
            Loop

        Catch ex As Exception
            Console.WriteLine("An Error Occurred: {0}")
        End Try
    End Sub
    'Varibles for the packets'
    Dim LIGHT_OFF As Byte = "0"
    Dim LIGHT_ON As Byte = "1"
    Dim LIGHT_BLINKING As Byte = "S"
    Dim FIELD_OFF As Byte = "0"
    Dim FIELD_ON As Byte = "1"
    Dim FIELD_BLINKING As Byte = "S"
    Dim LIGHT_MODE As Byte = "L"
    Dim TEAM_NUM_MODE As Byte = "N"
    Dim TIME_MODE As Byte = "T"
    Dim VIEW_MODE As Byte = "V"
    Dim BYTE_ZERO As Byte = "0"
    Dim BYTE_CLEAR As Byte = BYTE_ZERO
    Dim HW_MODE As Byte = "H"

    'Scale byte
    Dim SCALE_SENSOR1 As Byte = "SS1"
    Dim SCALE_SENSOR2 As Byte = "SS2"

    'Red side Switch
    Dim RED_SWITCH_SENSOR1 As Byte = "RSS1"
    Dim RED_SWITCH_SENSOR2 As Byte = "RSS2"

    'Blue side Switch
    Dim BLUE_SWITCH_SENSOR2 As Byte = "BSS2"
    Dim BLUE_SWITCH_SENSOR1 As Byte = "BSS1"
    Dim NeitherAlliance As Byte = "NA"

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

    Private Function checkAndFixNum(ByVal initTime As String, ByVal length As Integer) As String
        If (initTime.Length < length) Then
            initTime = "0".Concat(initTime)
            Return Me.checkAndFixNum(initTime, length)
        End If

        Return initTime
    End Function



End Class
