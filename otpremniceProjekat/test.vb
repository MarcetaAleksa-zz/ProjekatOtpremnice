Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO




Public Class test
    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Button.Click
        Dim komanda As New SqlCommand("SELECT ID FROM Osnovne", baza.konekcija)
        Dim adapter As New SqlDataAdapter(komanda)
        Dim tabela As New DataTable
        adapter.Fill(tabela)
        Try
            Dim sfd As New SaveFileDialog With {.Filter = "PDF Files (*.pdf | *.pdfs"}   'Samo mozemo praviti file tipa .pdf, SaveFileDialog nam sluzi za poziv da sacuvamo file
            Dim appPath As String = My.Application.Info.DirectoryPath  ' dobijamo default lokaciju gdje se .exe projekta nalazi
            sfd.FileName = tabela.Rows(0)(0)  'dodjela naziva za .pdf file

            If sfd.ShowDialog = 1 Then

                Dim pdfDoc As New Document(PageSize.A4, 40, 40, 80, 20) 'postavljamo parametre naseg .pdf dokumenta
                Dim pdfWriter As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(sfd.FileName, FileMode.Create)) 'snimanje .pdf-a
                Dim pKolona As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK) 'defomisanje kolona
                Dim pRed As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK) ' definisanje redova
                pdfWriter.PageEvent = New HeaderFooter
                Dim ptabela As New PdfPTable(8) ' generisanje tabele (8) kolona
                ptabela.TotalWidth = 550.0F '
                ptabela.LockedWidth = True ' 
                ptabela.HorizontalAlignment = Element.ALIGN_CENTER
                ptabela.HeaderRows = 1

                Dim widths As Single() = New Single() {0.4F, 1.0F, 1.0F, 1.0F, 1.0F, 1.0F, 1.0F, 1.0F} '
                ptabela.SetWidths(widths)
                Dim ppolja As PdfPCell = Nothing

                pdfDoc.Open()
                pdfDoc.Add(New Paragraph(" "))
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




                Dim dt As DataTable = GetDataTable()

                For i = 0 To dt.Rows.Count - 1
                    For j = 0 To dt.Columns.Count - 1
                        ppolja = New PdfPCell(New Paragraph(dt.Rows(i)(j).ToString, pRed))
                        ppolja.MinimumHeight = 18
                        ppolja.PaddingLeft = 5.0F
                        ppolja.HorizontalAlignment = Element.ALIGN_LEFT
                        ptabela.AddCell(ppolja)
                    Next
                Next
                pdfDoc.Add(ptabela)
                pdfDoc.Close()
                MsgBox("PDF je eksportovan na: " & sfd.FileName, vbInformation)
                Process.Start(sfd.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try



    End Sub
    Private Function GetDataTable()
        Dim datatable As New DataTable("dt")
        Dim dc1 As New DataColumn(Form2.DataGridView1.Columns(0).HeaderText.ToString, GetType(String))
        Dim dc2 As New DataColumn(Form2.DataGridView1.Columns(1).HeaderText.ToString, GetType(String))
        Dim dc3 As New DataColumn(Form2.DataGridView1.Columns(2).HeaderText.ToString, GetType(String))
        Dim dc4 As New DataColumn(Form2.DataGridView1.Columns(3).HeaderText.ToString, GetType(String))
        Dim dc5 As New DataColumn(Form2.DataGridView1.Columns(4).HeaderText.ToString, GetType(String))
        Dim dc6 As New DataColumn(Form2.DataGridView1.Columns(5).HeaderText.ToString, GetType(String))
        Dim dc7 As New DataColumn(Form2.DataGridView1.Columns(6).HeaderText.ToString, GetType(String))
        datatable.Columns.Add(dc1)
        datatable.Columns.Add(dc2)
        datatable.Columns.Add(dc3)
        datatable.Columns.Add(dc4)
        datatable.Columns.Add(dc5)
        datatable.Columns.Add(dc6)
        datatable.Columns.Add(dc7)
        Dim row As DataRow
        For i = 0 To Form2.DataGridView1.Rows.Count - 1
            row = datatable.NewRow
            row(dc1) = Form2.DataGridView1.Rows(i).Cells(0).Value.ToString
            row(dc2) = Form2.DataGridView1.Rows(i).Cells(1).Value.ToString
            row(dc3) = Form2.DataGridView1.Rows(i).Cells(2).Value.ToString
            row(dc4) = Form2.DataGridView1.Rows(i).Cells(3).Value.ToString
            row(dc5) = Form2.DataGridView1.Rows(i).Cells(4).Value.ToString
            row(dc6) = Form2.DataGridView1.Rows(i).Cells(5).Value.ToString
            row(dc7) = Form2.DataGridView1.Rows(i).Cells(6).Value.ToString
            datatable.Rows.Add(row)
        Next
        datatable.AcceptChanges()
        Return datatable
    End Function
    Class HeaderFooter
        Inherits PdfPageEventHelper
        Public Overrides Sub OnEndPage(writer As PdfWriter, document As Document)
            Dim headerfont As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font1 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pdfcell As PdfPCell = Nothing
            Dim pHeader As New PdfPTable(1)
            pHeader.TotalWidth = document.PageSize.Width
            pHeader.DefaultCell.Border = 0
            pdfcell = New PdfPCell(New Paragraph("OTPREMNICE", headerfont))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            'pdfcell.Border = 0
            pHeader.AddCell(pdfcell)
            pHeader.WriteSelectedRows(0, -1, document.LeftMargin, document.GetTop(document.TopMargin) + 100, writer.DirectContent)
        End Sub
    End Class
End Class