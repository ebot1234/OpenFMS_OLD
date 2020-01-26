Imports System.IO
Imports iTextSharp.text




Public Class SchedulePrinter
    Public Shared matchDir As String = "C:\OFMS\matches.txt"


    Public Sub createMatchPDF()
        Using fs As New FileStream("C:\OFMS\bob.pdf", FileMode.Create)
            Using doc As New Document
                Dim pdfWriter As pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs)
                doc.Open()

                doc.Add(New DataTable("bob"))

                doc.Close()

            End Using
        End Using
    End Sub
End Class
