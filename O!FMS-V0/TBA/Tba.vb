Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.IO

Public Class Tba

    Shared teamNum
    Shared statusCode As HttpStatusCode = HttpStatusCode.BadRequest
    Shared Function formatTeam(number As String)
        teamNum = String.Format("frc{0}", number)
        Return teamNum
    End Function

    'gets data from the Blue Alliance via JSON and HTTP GET request'
    Public Function getTeam(team As String, command As String)

        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim results As String = ""

        Dim requestAddress As String = String.Format("https://www.thebluealliance.com/api/v3/team/{0}", team)

        Try


            response = DirectCast(request.GetResponse(), HttpWebResponse)
            reader = New StreamReader(response.GetResponseStream())

            request = DirectCast(WebRequest.Create(requestAddress), HttpWebRequest)
            request.Headers.Set("X-TBA-Auth-Key", "Lat8J29zc3UrMOy8X4TSnreTqitAE9oMUvOqmpgXgPR0B6k4k96kh7UCiMjEy2Kg")

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
End Class
