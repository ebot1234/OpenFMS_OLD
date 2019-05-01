Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class Tba

    Public Shared TBA_Auth_Key As String = "Lat8J29zc3UrMOy8X4TSnreTqitAE9oMUvOqmpgXgPR0B6k4k96kh7UCiMjEy2Kg"
    Public Shared event_code As String = ""
    Public Shared secretId As String = ""
    Public Shared secret As String = ""

    Shared teamNum

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


    Shared Function MD5(ByRef strText As String) As String
        Dim MD5Service As New MD5CryptoServiceProvider
        Dim bytes() As Byte = MD5Service.ComputeHash(Encoding.ASCII.GetBytes(strText))
        Dim s As String = ""
        For Each By As Byte In bytes
            s += By.ToString("x2")
        Next
        Return s
    End Function

End Class
