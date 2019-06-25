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

    Public Structure scorebreakdown

    End Structure

    Shared Sub createBreakdown()



    End Sub
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

        Using hash As MD5 = MD5.Create()
            Dim Md5String1 As String = Encoding.ASCII.GetString(body)
            Dim Md5String2 As String = GetHash(client.secret + path)
            Dim signature As String = String.Format("{0}", Md5String2 + Md5String1)


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
        End Using

        Return results

        End Function

    Shared Function GetHash(strToHash As String) As String

        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        Dim strResult As New StringBuilder

        For Each b As Byte In bytesToHash
            strResult.Append(b.ToString("x2"))
        Next

        Return strResult.ToString

    End Function
End Class
