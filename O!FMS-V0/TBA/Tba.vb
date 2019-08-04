Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports O_FMS_V0.Pre_Match_Selector
Imports O_FMS_V0.Main_Panel

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
        Public Shared TimeString As String
        Public Shared TimeUtc As String
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
    Shared Function postRequest(resource As String, action As String, body As String)
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
        Dim sendBytes = Encoding.UTF8.GetBytes(body)
        stream.Write(sendBytes, 0, sendBytes.Length())

        Dim response = request.GetResponse().GetResponseStream()

        Dim reader As New StreamReader(response)
        results = reader.ReadToEnd()
        reader.Close()
        response.Close()

        Return results
    End Function

    Shared Sub postMatch()
        createBaseMatchJSON()
        Dim jsonData As String = File.ReadAllText("C:\OFMS\UpdateMatch1.txt")
        postRequest("matches", "update", jsonData)
    End Sub

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
        text = text.Replace("mLevel", type)
        text = text.Replace("mSetNumber", "1")
        text = text.Replace("mMatchNumber", Main_Panel.MatchNum.Text)
        text = text.Replace("r1", Main_Panel.RedTeam1.Text)
        text = text.Replace("r2", Main_Panel.RedTeam2.Text)
        text = text.Replace("r3", Main_Panel.RedTeam3.Text)
        text = text.Replace("rScore", redTotalPoints)
        text = text.Replace("b1", Main_Panel.BlueTeam1.Text)
        text = text.Replace("b2", Main_Panel.BlueTeam2.Text)
        text = text.Replace("b3", Main_Panel.BlueTeam3.Text)
        text = text.Replace("bScore", blueTotalPoints)
        text = text.Replace("timeStr", DateTime.Now.ToShortTimeString)
        text = text.Replace("utcTime", DateTime.UtcNow.ToString("s"))
        'Blue Score Breakdown'
        text = text.Replace("bAdjustPoints", "0")
        text = text.Replace("bAutoPoints", blueAutoPoints)
        text = text.Replace("bBay1", blueBay1)
        text = text.Replace("bBay2", blueBay2)
        text = text.Replace("bBay3", blueBay3)
        text = text.Replace("bBay4", blueBay4)
        text = text.Replace("bBay5", blueBay5)
        text = text.Replace("bBay6", blueBay6)
        text = text.Replace("bBay7", blueBay7)
        text = text.Replace("bBay8", blueBay8)
        text = text.Replace("bCargoPoints", blueCargoPoints)
        text = text.Replace("bRocketRP", blueRocketRP)
        text = text.Replace("bRocketFar", blueCompleteRocketFar)
        text = text.Replace("bRocketNear", blueCompleteRocketNear)
        text = text.Replace("bRobot1end", blueEndgameRobot1)
        text = text.Replace("bRobot2end", blueEndgameRobot2)
        text = text.Replace("bRobot3end", blueEndgameRobot3)
        text = text.Replace("bFoulCount", blueFoulCount)
        text = text.Replace("bFoulPoints", blueFoulPoints)
        text = text.Replace("1111", blueHABClimbPoints)
        text = text.Replace("bHabRP", blueHABRP)
        text = text.Replace("bRobot1Line", blueHABLineRobot1)
        text = text.Replace("bRobot2Line", blueHABLineRobot2)
        text = text.Replace("bRobot3Line", blueHABLineRobot3)
        text = text.Replace("bHatchPoints", blueHatchPanelPoints)
        text = text.Replace("bLowLeftRocketFar", blueLowLeftRocketFar)
        text = text.Replace("bLowLeftRocketNear", blueLowLeftRocketNear)
        text = text.Replace("bLowRightRocketFar", blueLowRightRocketFar)
        text = text.Replace("bLowRightRocketNear", blueLowRightRocketNear)
        text = text.Replace("bMidLeftRocketFar", blueMidLeftRocketFar)
        text = text.Replace("bMidLeftRocketNear", blueMidLeftRocketNear)
        text = text.Replace("bMidRightRocketFar", blueMidRightRocketFar)
        text = text.Replace("bMidRightRocketNear", blueMidRightRocketNear)
        text = text.Replace("bPreBay1", bluePBay1)
        text = text.Replace("bPreBay2", bluePBay2)
        text = text.Replace("bPreBay3", bluePBay3)
        text = text.Replace("bPreBay4", bluePBay4)
        text = text.Replace("bPreBay5", bluePBay5)
        text = text.Replace("bPreBay6", bluePBay6)
        text = text.Replace("bPreBay7", bluePBay7)
        text = text.Replace("bPreBay8", bluePBay8)
        text = text.Replace("bHabLevel1", bluePRobot1)
        text = text.Replace("bHabLevel2", bluePRobot2)
        text = text.Replace("bHabLevel3", bluePRobot3)
        text = text.Replace("bRP", blueRP)
        text = text.Replace("bSandStormBonus", blueSandStormBonus)
        text = text.Replace("bTechCount", blueTechCount)
        text = text.Replace("bTelePoints", blueTelePoints)
        text = text.Replace("bTopLeftRocketFar", blueTopLeftRocketFar)
        text = text.Replace("bTopLeftRocketNear", blueTopLeftRocketNear)
        text = text.Replace("bTopRightRocketFar", blueTopRightRocketFar)
        text = text.Replace("bTopRightRocketNear", blueTopRightRocketNear)
        text = text.Replace("bTotalPoints", blueTotalPoints)
        'Red Score Breakdown'
        text = text.Replace("rAdjustPoints", "0")
        text = text.Replace("rAutoPoints", redAutoPoints)
        text = text.Replace("rBay1", redBay1)
        text = text.Replace("rBay2", redBay2)
        text = text.Replace("rBay3", redBay3)
        text = text.Replace("rBay4", redBay4)
        text = text.Replace("rBay5", redBay5)
        text = text.Replace("rBay6", redBay6)
        text = text.Replace("rBay7", redBay7)
        text = text.Replace("rBay8", redBay8)
        text = text.Replace("rPoints", redCargoPoints)
        text = text.Replace("rRocketRP", redRocketRP)
        text = text.Replace("rCompletedRocketFar", redCompleteRocketFar)
        text = text.Replace("rCompletedRocketNear", redCompleteRocketNear)
        text = text.Replace("rRobot1end", redEndgameRobot1)
        text = text.Replace("rRobot2end", redEndgameRobot2)
        text = text.Replace("rRobot3end", redEndgameRobot3)
        text = text.Replace("rFoulCount", redFoulCount)
        text = text.Replace("rFoulPoints", redFoulPoints)
        text = text.Replace("rStuff", redHABClimbPoints)
        text = text.Replace("RED", redHABRP)
        text = text.Replace("rRobot1Line", redHABLineRobot1)
        text = text.Replace("rRobot2Line", redHABLineRobot2)
        text = text.Replace("rRobot3Line", redHABLineRobot3)
        text = text.Replace("rHatchPoints", redHatchPanelPoints)
        text = text.Replace("rLowLeftRocketFar", redLowLeftRocketFar)
        text = text.Replace("rLowLeftRocketNear", redLowLeftRocketNear)
        text = text.Replace("rLowRightRocketFar", redLowRightRocketFar)
        text = text.Replace("rLowRightRocketNear", redLowRightRocketNear)
        text = text.Replace("rMidLeftRocketFar", redMidLeftRocketFar)
        text = text.Replace("rMidLeftRocketNear", redMidLeftRocketNear)
        text = text.Replace("rMidRightRocketFar", redMidRightRocketFar)
        text = text.Replace("rMidRightRocketNear", redMidRightRocketNear)
        text = text.Replace("rPreBay1", redPBay1)
        text = text.Replace("rPreBay2", redPBay2)
        text = text.Replace("rPreBay3", redPBay3)
        text = text.Replace("rPreBay4", redPBay4)
        text = text.Replace("rPreBay5", redPBay5)
        text = text.Replace("rPreBay6", redPBay6)
        text = text.Replace("rPreBay7", redPBay7)
        text = text.Replace("rPreBay8", redPBay8)
        text = text.Replace("rLevel1", redPRobot1)
        text = text.Replace("rLevel2", redPRobot2)
        text = text.Replace("rLevel3", redPRobot3)
        text = text.Replace("rRP", redRP)
        text = text.Replace("rSandStormBonus", redSandStormBonus)
        text = text.Replace("rTechCount", redTechCount)
        text = text.Replace("rTelePoints", redTelePoints)
        text = text.Replace("rTopLeftRocketFar", redTopLeftRocketFar)
        text = text.Replace("rTopLeftRocketNear", redTopLeftRocketNear)
        text = text.Replace("rTopRightRocketFar", redTopRightRocketFar)
        text = text.Replace("rTopRightRocketNear", redTopRightRocketNear)
        text = text.Replace("rTotalPoints", redTotalPoints)

        'Writes all the text to the new file'
        File.WriteAllText("C:\OFMS\UpdateMatch1.txt", text)
    End Sub
End Class
