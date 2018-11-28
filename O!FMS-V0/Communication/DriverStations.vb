Imports O_FMS_V0.Main_Panel
Imports System.Net.Sockets
Imports System.Net
Imports O_FMS_V0.Timing
Imports O_FMS_V0.PLC_Comms_Server
Imports O_FMS_V0.Team_Networks


Public Class DriverStations
    Public packetCount As Integer = 0
    Public DSUpdSendPort As Int32 = 1121
    Public DSUdpReceivePort As Int32 = 1160
    Public Auto As Boolean = False
    Public Enabled As Boolean = False
    Public Estop As Boolean = False
    Public DsConn As New UdpClient
    Public DSEndpoint As IPEndPoint = New IPEndPoint(IPAddress.Any, DSUdpReceivePort)
    Public BatteryVoltage As Double
    Public RadioLinked As Boolean
    Public RobotLinked As Boolean



    Public Sub sendPacketDS()
        Dim packet() As Byte = encodeControlPacket()
        If Auto = True Then
            DsConn.Send(packet, packet.Length)
        End If

        If Estop = True Then
            DsConn.Send(packet, packet.Length)
        End If

        If Enabled = True Then
            DsConn.Send(packet, packet.Length)
        End If

    End Sub

    Public Sub ListenForDSUdp(allianceStation As String)
        'Team Id for getting team number from DS'
        Dim teamId As Integer = 0
        Dim DSBytes As Byte()

        Try
            'Recieves the data from the DS'
            DSBytes = DsConn.Receive(DSEndpoint)
            'Gets the team id from the DSByte structure'
            teamId = DSBytes(4) << 8 + DSBytes(5)
            'Checks the team id from the main panel'
            Dim teamNumber As Integer = Convert.ToInt32(allianceStation)
            'Gets the Voltage but this is not implemented Yet!'
            BatteryVoltage = DSBytes(6) + DSBytes(7) / 256

            'Gets the robot if it is linked'
            If allianceStation = Main_Panel.RedTeam1.Text Then
                If RobotLinked = DSBytes(3) = &H20 Then
                    Robot_Linked_Red1 = True
                End If
            End If

            If allianceStation = Main_Panel.RedTeam2.Text Then
                If RobotLinked = DSBytes(3) = &H20 Then
                    Robot_Linked_Red1 = True
                End If
            End If

            If allianceStation = Main_Panel.RedTeam3.Text Then
                If RobotLinked = DSBytes(3) = &H20 Then
                    Robot_Linked_Red1 = True
                End If
            End If

            If allianceStation = Main_Panel.BlueTeam1.Text Then
                If RobotLinked = DSBytes(3) = &H20 Then
                    Robot_Linked_Red1 = True
                End If
            End If

            If allianceStation = Main_Panel.BlueTeam2.Text Then
                If RobotLinked = DSBytes(3) = &H20 Then
                    Robot_Linked_Red1 = True
                End If
            End If

            If allianceStation = Main_Panel.BlueTeam3.Text Then
                If RobotLinked = DSBytes(3) = &H20 Then
                    Robot_Linked_Red1 = True
                End If
            End If

        Catch e As Exception
            MessageBox.Show("DS Listener for UDP has problems")
        End Try
        If allianceStation = teamId Then
            'Does nothing, TCP will handle this if this is wrong'
        Else
            Threading.Thread.Sleep(500)
            'Closes if the id doesn't match the main panel'
            DsConn.Close()
        End If
    End Sub

    Public Function encodeControlPacket()
        Dim data(22) As Byte

        data(0) = packetCount >> 8 And &HFF
        data(1) = packetCount And &HFF
        'Protocol version'
        data(2) = 0
        'Robot status byte'
        data(3) = 0

        If Auto = True Then
            data(3) = &H2
        End If
        If Enabled = True Then
            data(3) = &H4
        End If
        If Estop = True Then
            data(3) = &H80
        End If
        'Unused byte or unknown'
        data(4) = 0
        'Alliance Station byte, TODO add map of alliance stations'
        data(5) = 0
        'Match Type info from SQL/Main Panel'
        'Add that'
        
        data(9) = 1
        
        'Add curent time'
        data(10) = 0
        'time is bytes 10-19'
        
        'Match Time for bytes 20 and 21'

        packetCount = packetCount + 1
        Return data
    End Function

End Class
