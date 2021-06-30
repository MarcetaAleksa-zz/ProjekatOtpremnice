Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO




Public Class test
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Dim sfd As New SaveFileDialog With {.Filter = "PDF Files (*.pdf | *.pdf"}   'Samo mozemo praviti file tipa .pdf, SaveFileDialog nam sluzi za poziv da sacuvamo file
            Dim appPath As String = My.Application.Info.DirectoryPath  ' dobijamo default lokaciju gdje se .exe projekta nalazi
            Dim whatisthis = TextBox1.Text  ' ovde cemo unositi ime musterije na osnovu kojeg ce se raditi pdf naziv, jos cemo dodavati trenutni datum i tako cemo sacuvati file
            sfd.FileName = whatisthis  'dodjela naziva za .pdf file

            If sfd.ShowDialog = 1 Then

                Dim pdfDoc As New Document(PageSize.A4, 40, 40, 80, 20) 'postavljamo parametre naseg .pdf dokumenta
                Dim pdfWriter As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(sfd.FileName, FileMode.Create)) 'snimanje .pdf-a
                Dim pKolona As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK) 'defomisanje kolona
                Dim pRed As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK) ' definisanje redova
                Dim ptabela As New PdfPTable(8) ' generisanje tabele (8) kolona
                ptabela.TotalWidth = 550.0F '
                ptabela.LockedWidth = True ' 
                ptabela.HorizontalAlignment = Element.ALIGN_CENTER
                ptabela.HeaderRows = 1

                Dim widths As Single() = New Single() {0.4F, 1.0F, 1.0F, 1.0F, 1.0F, 1.0F, 1.0F, 1.0F} '
                ptabela.SetWidths(widths)
                Dim ppolja As PdfPCell = Nothing

                pdfDoc.Open()
                pdfDoc.Add(New Paragraph("OTPREMNICA"))
                ' u bloku koda ispod definisemo izgled tabele i njenih kolona/redova
                ppolja = New PdfPCell(New Paragraph("Red. broj", pKolona))
                ppolja.HorizontalAlignment = Element.ALIGN_LEFT
                ppolja.MinimumHeight = 18
                ppolja.PaddingLeft = 5.0F
                ppolja.BackgroundColor = BaseColor.LIGHT_GRAY
                ptabela.AddCell(ppolja)

                ppolja = New PdfPCell(New Paragraph("NAZIV ROBE / USLUGE", pKolona))
                ppolja.HorizontalAlignment = Element.ALIGN_LEFT
                ppolja.MinimumHeight = 18
                ppolja.PaddingLeft = 5.0F
                ppolja.BackgroundColor = BaseColor.LIGHT_GRAY
                ptabela.AddCell(ppolja)

                ppolja = New PdfPCell(New Paragraph("Jed. mjere", pKolona))
                ppolja.HorizontalAlignment = Element.ALIGN_LEFT
                ppolja.MinimumHeight = 18
                ppolja.PaddingLeft = 5.0F
                ppolja.BackgroundColor = BaseColor.LIGHT_GRAY
                ptabela.AddCell(ppolja)

                ppolja = New PdfPCell(New Paragraph("Kolicina", pKolona))
                ppolja.HorizontalAlignment = Element.ALIGN_LEFT
                ppolja.MinimumHeight = 18
                ppolja.PaddingLeft = 5.0F
                ppolja.BackgroundColor = BaseColor.LIGHT_GRAY
                ptabela.AddCell(ppolja)

                ppolja = New PdfPCell(New Paragraph("Cijena", pKolona))
                ppolja.HorizontalAlignment = Element.ALIGN_LEFT
                ppolja.MinimumHeight = 18
                ppolja.PaddingLeft = 5.0F
                ppolja.BackgroundColor = BaseColor.LIGHT_GRAY
                ptabela.AddCell(ppolja)

                ppolja = New PdfPCell(New Paragraph("Iznos", pKolona))
                ppolja.HorizontalAlignment = Element.ALIGN_LEFT
                ppolja.MinimumHeight = 18
                ppolja.PaddingLeft = 5.0F
                ppolja.BackgroundColor = BaseColor.LIGHT_GRAY
                ptabela.AddCell(ppolja)

                ppolja = New PdfPCell(New Paragraph("Rabat", pKolona))
                ppolja.HorizontalAlignment = Element.ALIGN_LEFT
                ppolja.MinimumHeight = 18
                ppolja.PaddingLeft = 5.0F
                ppolja.BackgroundColor = BaseColor.LIGHT_GRAY
                ptabela.AddCell(ppolja)


                ppolja = New PdfPCell(New Paragraph("Smrad", pRed))
                ppolja.HorizontalAlignment = Element.ALIGN_LEFT
                ppolja.MinimumHeight = 18
                ppolja.PaddingLeft = 5.0F
                ptabela.AddCell(ppolja)

                'Dim dt As DataTable = GetDataTable()

                'For i = 0 To dt.Rows.Count - 1
                '    For j = 0 To dt.Columns.Count - 1
                '        ppolja = New PdfPCell(New Paragraph(dt.Rows(i)(j).ToString, pRed))
                '        ppolja.MinimumHeight = 18
                '        ppolja.PaddingLeft = 5.0F
                '        ppolja.HorizontalAlignment = Element.ALIGN_LEFT
                '        ptabela.AddCell(ppolja)
                '    Next
                'Next
                pdfDoc.Add(ptabela)
                pdfDoc.Close()
                MsgBox("PDF je eksportovan na: " & sfd.FileName, vbInformation)
                Process.Start(sfd.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try



    End Sub
    'Private Function GetDataTable()
    '    Dim datatable As New DataTable("dt")
    '    Dim dc1 As New DataColumn(datagridview1.columns(0).headertext.ToString, GetType(String))

    '    datatable.Columns.Add(dc1)
    '    Dim row As DataRow
    '    For i = 0 To Datagridview1.rows.count - 1
    '        row = datatable.NewRow
    '        row(dc1) = DataGridView1.Rows(i).Cells(0).Value.ToString
    '        datatable.Rows.Add(row)
    '    Next
    '    datatable.AcceptChanges()
    '    Return
    'End Function
End Class