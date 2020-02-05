Imports System.Net
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json


Public Class TBA
    Structure TBA_Client
        Public Shared Auth_Key As String = "Lat8J29zc3UrMOy8X4TSnreTqitAE9oMUvOqmpgXgPR0B6k4k96kh7UCiMjEy2Kg"
        Public Shared Secret_Key As String = "" 'Add your own TBA Write Key Here
        Public Shared Event_Code As String = "" 'Add your TBA Event Key Here'
        Public Shared Secret_ID As String = "" 'Add your TBA Secret ID Here'
    End Structure

    Structure TBA_Match
        Public Shared Comp_Level As String = ""
        Public Shared Set_Number As String = ""
        Public Shared Match_Number As String = ""
        Public Shared Time_String As String = ""
        Public Shared Time_String_UTC As String = ""
    End Structure

    Public Shared TeamNumber

    'Format team number for TBA standards I.E. frc1080'
    Public Shared Function FormatTeam(Number As String)
        TeamNumber = String.Format("frc{0}", Number)
        Return TeamNumber
    End Function

    'Grabs the Nickname of a TBA team'
    Public Shared Function GetTeamInfo(Team As String)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim results As String = ""
        Dim request_address As String = String.Format("https://www.thebluealliance.com/api/v3/team/{0}", Team)

        Try
            request = DirectCast(WebRequest.Create(request_address), HttpWebRequest)
            request.Headers.Set("X-TBA-Auth-Key", TBA_Client.Auth_Key)

            response = DirectCast(request.GetResponse(), HttpWebResponse)
            reader = New StreamReader(response.GetResponseStream())

            Dim raw_data As String
            raw_data = reader.ReadToEnd()

            Dim data As Object = JObject.Parse(raw_data)
            results = If(data("nickname") Is Nothing, "", data("nickname").ToString())

        Catch ex As Exception
            MessageBox.Show("Team doesn't exist in the Blue Alliance database")
            results = "NULL"
        End Try

        Return results
    End Function

    Public Shared Function PostJSON(resource As String, action As String, body As String) As Boolean
        Dim client As New WebClient()
        Dim resByte As Byte()
        Dim reqString() As Byte
        Dim post_address As String = String.Format("https://www.thebluealliance.com/api/trusted/v1/event/{0}/{1}/{2}", TBA_Client.Event_Code, resource, action)
        Dim signature = GetHash(TBA_Client.Secret_Key & post_address)

        Try
            client.Headers("content-type") = "application/json"
            client.Headers.Add("X-TBA-Auth-Id", TBA_Client.Secret_ID)
            client.Headers.Add("X-TBA-Auth-Sig", signature)
            reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(body, Formatting.Indented))
            resByte = client.UploadData(post_address, "POST", reqString)
            client.Dispose()
            Return True
        Catch ex As Exception
            MessageBox.Show("Error Posting Data to The Blue Alliance API")
            Return False
        End Try

    End Function

    'Creates a MD5 encryption'
    Public Shared Function GetHash(input As String) As String
        Using hasher As MD5 = MD5.Create()
            Dim dBytes As Byte() = hasher.ComputeHash(Encoding.UTF8.GetBytes(input))
            Dim sBuilder As New StringBuilder()

            For n As Integer = 0 To dBytes.Length - 1
                sBuilder.Append(dBytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using
    End Function

    'Posts a match to the Blue Alliance API'
    Public Shared Sub PostMatch()
        Dim jsonData As String = File.ReadAllText("C:\OFMS\PublishedMatch.txt")
        PostJSON("matches", "update", jsonData)
    End Sub

    'Creates a JSON file for posting matches to the Blue Alliance API'
    Public Shared Sub CreateMatchJSON()
        Dim text As String = File.ReadAllText("C:\OFMS\PublishMatchTemplate.txt")
        text = text.Replace("mLevel", TBA_Match.Comp_Level)
        text = text.Replace("mSetNumber", TBA_Match.Set_Number)
        'Add Team Numbers'

        'Blue Score Breakdown'


        'Writes all the text  to the new file'
        File.WriteAllText("C:\OFMS\PublishedMatch.txt", text)
    End Sub
End Class
