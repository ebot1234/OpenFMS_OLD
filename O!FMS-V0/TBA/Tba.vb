Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.IO

Public Class Tba

    Public Function getTeamId(number As String)
        Return String.Format("frc{0}", number)
    End Function

    'gets data from the Blue Alliance via JSON and HTTP GET request'
    Public Sub getJsonRequest(url As String, command As String)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader

        Dim requestAddress As String = String.Format("https://www.thebluealliance.com/api/v3/{0}", url)
        request = DirectCast(WebRequest.Create(requestAddress), HttpWebRequest)
        request.Headers.Set("X-TBA-Auth-Key", "Lat8J29zc3UrMOy8X4TSnreTqitAE9oMUvOqmpgXgPR0B6k4k96kh7UCiMjEy2Kg")

        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()

        Dim data As Object = JObject.Parse(rawresp)
        'If(data(command) Is Nothing, "", data(command).ToString())
    End Sub
End Class
