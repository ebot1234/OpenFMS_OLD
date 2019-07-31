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
        Dim text As String = File.ReadAllText("C:\OFMS\UpdateMatch.txt")
        text = text.Replace("mLevel", "qm")
        text = text.Replace("mSetNumber", "1")
        text = text.Replace("mMatchNumber", "1")
        text = text.Replace("r1", "red1")
        text = text.Replace("r2", "red2")
        text = text.Replace("r3", "red3")
        text = text.Replace("rScore", "redScore")
        text = text.Replace("b1", "blue1")
        text = text.Replace("b2", "blue2")
        text = text.Replace("b3", "blue3")
        text = text.Replace("bScore", "blueScore")
        text = text.Replace("timeStr", DateTime.Now.ToShortTimeString)
        text = text.Replace("utcTime", DateTime.UtcNow.ToString("s"))
        'Blue Score Breakdown'
        text = text.Replace("bAdjustPoints", "0")
        text = text.Replace("bAutoPoints", "0")
        text = text.Replace("bBay1", "0")
        text = text.Replace("bBay2", "0")
        text = text.Replace("bBay3", "0")
        text = text.Replace("bBay4", "0")
        text = text.Replace("bBay5", "0")
        text = text.Replace("bBay6", "0")
        text = text.Replace("bBay7", "0")
        text = text.Replace("bBay8", "0")
        text = text.Replace("bCargoPoints", "0")
        text = text.Replace("bRocketRP", "0")
        text = text.Replace("bRocketFar", "0")
        text = text.Replace("bRocketNear", "0")
        text = text.Replace("bRobot1end", "0")
        text = text.Replace("bRobot2end", "0")
        text = text.Replace("bRobot3end", "0")
        text = text.Replace("bFoulCount", "0")
        text = text.Replace("bFoulPoints", "0")
        text = text.Replace("1111", "0")
        text = text.Replace("bHabRP", "0")
        text = text.Replace("bRobot1Line", "0")
        text = text.Replace("bRobot2Line", "0")
        text = text.Replace("bRobot3Line", "0")
        text = text.Replace("bHatchPoints", "0")
        text = text.Replace("bLowLeftRocketFar", "0")
        text = text.Replace("bLowLeftRocketNear", "0")
        text = text.Replace("bLowRightRocketFar", "0")
        text = text.Replace("bLowRightRocketNear", "0")
        text = text.Replace("bMidLeftRocketFar", "0")
        text = text.Replace("bMidLeftRocketNear", "0")
        text = text.Replace("bMidRightRocketFar", "0")
        text = text.Replace("bMidRightRocketNear", "0")
        text = text.Replace("bPreBay1", "0")
        text = text.Replace("bPreBay2", "0")
        text = text.Replace("bPreBay3", "0")
        text = text.Replace("bPreBay4", "0")
        text = text.Replace("bPreBay5", "0")
        text = text.Replace("bPreBay6", "0")
        text = text.Replace("bPreBay7", "0")
        text = text.Replace("bPreBay8", "0")
        text = text.Replace("bHabLevel1", "0")
        text = text.Replace("bHabLevel2", "0")
        text = text.Replace("bHabLevel3", "0")
        text = text.Replace("bRP", "0")
        text = text.Replace("bSandStormBonus", "0")
        text = text.Replace("bTechCount", "0")
        text = text.Replace("bTelePoints", "0")
        text = text.Replace("bTopLeftRocketFar", "0")
        text = text.Replace("bTopLeftRocketNear", "0")
        text = text.Replace("bTopRightRocketFar", "0")
        text = text.Replace("bTopRightRocketNear", "0")
        text = text.Replace("bTotalPoints", "0")
        'Red Score Breakdown'
        text = text.Replace("rAdjustPoints", "0")
        text = text.Replace("rAutoPoints", "0")
        text = text.Replace("rBay1", "0")
        text = text.Replace("rBay2", "0")
        text = text.Replace("rBay3", "0")
        text = text.Replace("rBay4", "0")
        text = text.Replace("rBay5", "0")
        text = text.Replace("rBay6", "0")
        text = text.Replace("rBay7", "0")
        text = text.Replace("rBay8", "0")
        text = text.Replace("rCargoPoints", "0")
        text = text.Replace("rRocketRP", "0")
        text = text.Replace("rCompletedRocketFar", "0")
        text = text.Replace("rCompletedRocketNear", "0")
        text = text.Replace("rRobot1end", "0")
        text = text.Replace("rRobot2end", "0")
        text = text.Replace("rRobot3end", "0")
        text = text.Replace("rFoulCount", "0")
        text = text.Replace("rFoulPoints", "0")
        text = text.Replace("rStuff", "0")
        text = text.Replace("RED", "0")
        text = text.Replace("rRobot1Line", "0")
        text = text.Replace("rRobot2Line", "0")
        text = text.Replace("rRobot3Line", "0")
        text = text.Replace("rHatchPoints", "0")
        text = text.Replace("rLowLeftRocketFar", "0")
        text = text.Replace("rLowLeftRocketNear", "0")
        text = text.Replace("rLowRightRocketFar", "0")
        text = text.Replace("rLowRightRocketNear", "0")
        text = text.Replace("rMidLeftRocketFar", "0")
        text = text.Replace("rMidLeftRocketNear", "0")
        text = text.Replace("rMidRightRocketFar", "0")
        text = text.Replace("rMidRightRocketNear", "0")
        text = text.Replace("rPreBay1", "0")
        text = text.Replace("rPreBay2", "0")
        text = text.Replace("rPreBay3", "0")
        text = text.Replace("rPreBay4", "0")
        text = text.Replace("rPreBay5", "0")
        text = text.Replace("rPreBay6", "0")
        text = text.Replace("rPreBay7", "0")
        text = text.Replace("rPreBay8", "0")
        text = text.Replace("rLevel1", "0")
        text = text.Replace("rLevel2", "0")
        text = text.Replace("rLevel3", "0")
        text = text.Replace("rRP", "0")
        text = text.Replace("rSandStormBonus", "0")
        text = text.Replace("rTechCount", "0")
        text = text.Replace("rTelePoints", "0")
        text = text.Replace("rTopLeftRocketFar", "0")
        text = text.Replace("rTopLeftRocketNear", "0")
        text = text.Replace("rTopRightRocketFar", "0")
        text = text.Replace("rTopRightRocketNear", "0")
        text = text.Replace("rTotalPoints", "0")

        'Writes all the text to the new file'
        File.WriteAllText("C:\OFMS\UpdateMatch1.txt", text)
    End Sub
End Class
