Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports O_FMS_V0.TbaBreakdowns

Public Class Tba

    Public Shared TBA_Auth_Key As String = "Lat8J29zc3UrMOy8X4TSnreTqitAE9oMUvOqmpgXgPR0B6k4k96kh7UCiMjEy2Kg"
    Public Shared secret As String = ""

    Shared teamNum

    Public Structure client
        Public Shared eventCode As String
        Public Shared secretId As String
        Public Shared secret As String
    End Structure

    Public Structure match
        Public Shared CompLevel As String
        Public Shared SetNumber As Integer
        Public Shared MatchNumber As Integer
        Public Shared Alliances As String
        Public Shared ScoreBreakdown() As String
        Public Shared TimeString As String
        Public Shared TimeUtc As String
    End Structure

    Public Structure alliances
        Public Shared Teams() As String
        Public Shared Surrogates As String()
        Public Shared Dqs As String()
        Public Shared Score As Integer
    End Structure

    Shared Function formatTeam(number As String)
            teamNum = String.Format("frc{0}", number)
            Return teamNum
        End Function

    Shared Function getTeam(team As String)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim results As String = ""

        Dim requestAddress As String = String.Format("https://www.thebluealliance.com/api/v3/team/{0}", team)

        Try

            request = DirectCast(WebRequest.Create(requestAddress), HttpWebRequest)
            request.Headers.Set("X-TBA-Auth-Key", TBA_Auth_Key)

            response = DirectCast(request.GetResponse(), HttpWebResponse)
            reader = New StreamReader(response.GetResponseStream())

            Dim rawresp As String
            rawresp = reader.ReadToEnd()

            Dim data As Object = JObject.Parse(rawresp)
            results = If(data("nickname") Is Nothing, "", data("nickname").ToString())

        Catch ex As Exception
            MessageBox.Show("Team doesn't exist in The Blue Alliance")
            results = "NULL"
        End Try

        Return results
    End Function

    'This posts anything you need to the blue alliance api'
    Shared Function postRequest(resource As String, action As String, body As Byte())
            Dim request As HttpWebRequest = Nothing
            Dim results As String = ""

            Dim path As String = String.Format("https://www.thebluealliance/api/trusted/v1/event/{0}/{1}/{2}", client.eventCode, resource, action)

        Dim signature = GetHash(client.secret & path)

        request = DirectCast(WebRequest.Create(path), HttpWebRequest)
        request.ContentType = "application/json"
        request.ContentLength = body.Length
        request.Method = "POST"
        request.Headers.Add("X-TBA-Auth-Id", client.secretId)
        request.Headers.Add("X-TBA-Auth-Sig", signature)

        Dim stream = request.GetRequestStream()
        stream.Write(body, 0, body.Length())

        Dim response = request.GetResponse().GetResponseStream()

        Dim reader As New StreamReader(response)
            results = reader.ReadToEnd()
            reader.Close()
            response.Close()

        Return results
    End Function

    'Gets a MD5 Hash from a string'
    Shared Function GetHash(input As String) As String
        Using hasher As MD5 = MD5.Create()
            Dim dBytes As Byte() = hasher.ComputeHash(Encoding.UTF8.GetBytes(input))
            Dim sBuilder As New StringBuilder()

            For n As Integer = 0 To dBytes.Length - 1
                sBuilder.Append(dBytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using
    End Function

    Public Shared Sub createBaseMatchJSON()
        'This writes the team and match data to a file for writing matches to The Blue Alliance API'
        Dim file As String
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("mLevel", match.CompLevel)
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("mSetNumber", match.SetNumber)
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("mMatchNumber", match.MatchNumber)
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("r1", "red1")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("r2", "red2")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("r3", "red3")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("rScore", "redScore")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("b1", "blue1")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("b2", "blue2")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("b3", "blue3")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bScore", "blueScore")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("timeStr", DateTime.Now.ToShortTimeString)
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("utcTime", DateTime.UtcNow.ToString("s"))
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)

        createScoringBreakdowns()
    End Sub

    Public Shared Sub createScoringBreakdowns()
        'This fills the scoring info for the match breakdown'
        Dim file As String
        'Blue Score Stuff'
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bAdjustPoints", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bAutoPoints", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bBay1", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bBay2", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bBay3", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bBay4", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bBay5", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bBay6", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bBay7", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bBay8", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bCargoPoints", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bRocketRP", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bRocketFar", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bRocketNear", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bRobot1end", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bRobot2end", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bRobot3end", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bFoulCount", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bFoulPoints", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bClimbPoints", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bHabRP", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bLowLeftRocketFar", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bLowLeftRocketNear", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bLowRightRocketFar", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bLowRightRocketNear", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bMidLeftRocketFar", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bMidLeftRocketNear", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bMidRightRocketFar", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bMidRightRocketNear", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bPreBay1", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bPreBay2", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bPreBay3", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bPreBay4", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bPreBay5", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bPreBay6", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bPreBay7", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bPreBay8", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bHabLevel1", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bHabLevel2", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bHabLevel3", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bRP", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bSandStormBonus", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bTechCount", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bTelePoints", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bTopLeftRocketFar", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bTopLeftRocketNear", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bTopRightRocketFar", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bTopRightRocketNear", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        file = My.Computer.FileSystem.ReadAllText("C:\OFMS\UpdateMatch.txt").Replace("bTotalPoints", "0")
        My.Computer.FileSystem.WriteAllText("C:\OFMS\UpdateMatch1.txt", file, False)
        'TODO Add Red Points'
    End Sub
End Class
