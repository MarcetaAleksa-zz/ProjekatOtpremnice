Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Text.StringBuilder

Public Class pregled
    Private Sub stanjeServisaTB_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim komanda As New SqlCommand("Select id_servisa from servis", baza.konekcija)
            Dim adapter As New SqlDataAdapter(komanda)
            Dim ds As New DataSet()
            adapter.Fill(ds)
            idServisaCB.DataSource = ds.Tables(0)
            idServisaCB.ValueMember = "id_servisa"
            idServisaCB.DisplayMember = "id_servisa"
        Catch
        End Try
    End Sub
    Private Sub idServisaCB_change() Handles idServisaCB.SelectedIndexChanged
        Try
            If idServisaCB.SelectedIndex = -1 Then
                serviserTB.Text = ""
                uslugaTB.Text = ""
                musterijaTB.Text = ""
                datumPTB.Text = ""
                stanjeServisaTB.Text = ""
                datumITB.Text = ""
                emailTB.Text = ""
                telefonTB.Text = ""
                opisServisaTB.Text = ""
            Else
                Dim kom As New SqlCommand("Select id_servisa, zap.ime + ' ' +  zap.prezime , usluga,  otprema_na_naslov, prijem, s.stanje_servisa, s.isporuka, s.email, s.telefon,  s.opis_servisa from servis as s left join zaposleni as zap on (zap.id = s.serviser)  where id_servisa = " & idServisaCB.Text & "", baza.konekcija)
                Dim ad As New SqlDataAdapter(kom)
                Dim tb As New DataTable()
                ad.Fill(tb)
                serviserTB.Text = tb.Rows(0)(1)
                uslugaTB.Text = tb.Rows(0)(2)
                musterijaTB.Text = tb.Rows(0)(3)
                datumPTB.Text = tb.Rows(0)(4)
                If tb.Rows(0)(5) = True Then
                    stanjeServisaTB.Text = "Isporuceno"

                ElseIf tb.Rows(0)(5) = False Then
                    stanjeServisaTB.Text = "Zaprimljeno"

                End If
                emailTB.Text = tb.Rows(0)(7)
                telefonTB.Text = tb.Rows(0)(8)

                If IsDBNull(tb.Rows(0)(6)) Then
                    opisServisaTB.Text = ""
                    datumITB.Text = ""
                Else

                    datumITB.Text = tb.Rows(0)(6)
                    opisServisaTB.Text = tb.Rows(0)(9)
                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Nazad_Click(sender As Object, e As EventArgs) Handles Nazad.Click
        serv.Show()
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ime As String
        If stanjeServisaTB.Text = "Isporuceno" Then
            ime = "Servis " & idServisaCB.Text & " zavrsen.pdfs"
        ElseIf stanjeServisaTB.Text = "Zaprimljeno" Then
            ime = "Servis " & idServisaCB.Text & ".pdfs"
        End If
        Dim pdfDoc As New Document(PageSize.A4.Rotate, 40, 40, 80, 20) 'postavljamo dimenzije naseg .pdf dokumenta
        Dim filename As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), ime)
        Dim pdfWriter As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(filename, FileMode.Create)) 'snimanje .pdf-a
        Dim fntTableFontHdr As iTextSharp.text.Font = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim fntTableFont As iTextSharp.text.Font = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim ev As New sacuvaj
        pdfWriter.PageEvent = ev
        pdfDoc.Open()

        Dim ptabela As New PdfPTable(3) With {
.WidthPercentage = 100, '
.SpacingAfter = 10
}
        ptabela.HorizontalAlignment = Element.ALIGN_CENTER
        Dim sgltblhdwidth(2) As Single
        sgltblhdwidth(0) = 60
        sgltblhdwidth(1) = 30
        sgltblhdwidth(2) = 60

        ptabela.SetWidths(sgltblhdwidth)
        '------------------------------------------------- POCETAK TABELE -------------------------------------------------------------------------------------------
        Dim CellOneHdr As New PdfPCell(New Phrase("Opis Problema", fntTableFontHdr)) With {
.VerticalAlignment = PdfPCell.ALIGN_CENTER,
.HorizontalAlignment = PdfPCell.ALIGN_CENTER
}

        ptabela.AddCell(CellOneHdr)

        Dim celltwohdr As New PdfPCell(New Phrase("", fntTableFontHdr)) With {
.VerticalAlignment = PdfPCell.ALIGN_CENTER,
.HorizontalAlignment = PdfPCell.ALIGN_CENTER,
.Border = iTextSharp.text.Rectangle.NO_BORDER
}
        ptabela.AddCell(celltwohdr)

        Dim cellthreehdr As New PdfPCell(New Phrase("Rijesenje Problema", fntTableFontHdr)) With {
.VerticalAlignment = PdfPCell.ALIGN_CENTER,
.HorizontalAlignment = PdfPCell.ALIGN_CENTER
}
        ptabela.AddCell(cellthreehdr)

        Dim cellfourhdr As New PdfPCell(New Phrase(uslugaTB.Text, fntTableFont)) With {
                .VerticalAlignment = PdfPCell.ALIGN_LEFT,
            .HorizontalAlignment = PdfPCell.ALIGN_LEFT
             }
        ptabela.AddCell(cellfourhdr)



        Dim cellfivehdr As New PdfPCell(New Phrase("", fntTableFont)) With {
                .VerticalAlignment = PdfPCell.ALIGN_LEFT,
            .HorizontalAlignment = PdfPCell.ALIGN_LEFT,
            .Border = iTextSharp.text.Rectangle.NO_BORDER
             }
        ptabela.AddCell(cellfivehdr)

        If opisServisaTB.Text = "" Then
            Dim cellSixhdr As New PdfPCell(New Phrase("/", fntTableFont)) With {
                .VerticalAlignment = PdfPCell.ALIGN_LEFT,
            .HorizontalAlignment = PdfPCell.ALIGN_LEFT
             }
            ptabela.AddCell(cellSixhdr)
        Else
            Dim cellSixhdr As New PdfPCell(New Phrase(opisServisaTB.Text, fntTableFont)) With {
                .VerticalAlignment = PdfPCell.ALIGN_LEFT,
            .HorizontalAlignment = PdfPCell.ALIGN_LEFT
             }
            ptabela.AddCell(cellSixhdr)
        End If


        pdfDoc.Add(ptabela)
        pdfDoc.Close()
        servispdf.Show()
        servispdf.ucitavanjaPDFa(filename)
        servispdf.biraj = 2
        Me.Enabled = False
        Me.Hide()
    End Sub
End Class
Public Class sacuvaj
    Inherits PdfPageEventHelper
    Public Overrides Sub OnStartPage(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As iTextSharp.text.Document)
        Dim test As System.Drawing.Image = System.Drawing.Image.FromHbitmap(My.Resources.BANNER_EXTENDED.GetHbitmap())
        Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(test, System.Drawing.Imaging.ImageFormat.Png)
        logo.ScaleToFit(760.0F, 120.0F)
        logo.WidthPercentage = 100
        document.Add(logo)

        Dim fntTableFontHdr As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim fntTableFont As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim headerTabela As New PdfPTable(6) With {
                    .WidthPercentage = 100,
                    .SpacingBefore = 10,
                    .SpacingAfter = 10
                    }
        headerTabela.HorizontalAlignment = Element.ALIGN_LEFT
        Dim sgltblhdwidth(5) As Single
        sgltblhdwidth(0) = 15
        sgltblhdwidth(1) = 30
        sgltblhdwidth(2) = 30
        sgltblhdwidth(3) = 40
        sgltblhdwidth(4) = 30
        sgltblhdwidth(5) = 30

        headerTabela.SetWidths(sgltblhdwidth)

        Dim nazivi As New List(Of String)({"Broj servisa:", "Serviser :", "Otprema na naslov:", "Datum prijema:", "Datum isporuke:", "Telefon:", "Email:"})
        Dim datum As String
        If pregled.datumITB.Text = "" Then
            datum = "/"
        Else
            datum = pregled.datumITB.Text
        End If
        Dim podaciHeader As New List(Of String)({pregled.idServisaCB.Text, pregled.serviserTB.Text, pregled.musterijaTB.Text, pregled.datumPTB.Text, datum.ToString, pregled.telefonTB.Text, pregled.emailTB.Text})

        For i = 0 To 6
            Dim CellOneHdr As New PdfPCell(New Phrase(nazivi(i), fntTableFontHdr)) With {
                .VerticalAlignment = PdfPCell.ALIGN_LEFT,
            .HorizontalAlignment = PdfPCell.ALIGN_LEFT,
            .Border = iTextSharp.text.Rectangle.NO_BORDER
                }
            headerTabela.AddCell(CellOneHdr)



            Dim celltwohdr As New PdfPCell(New Phrase(podaciHeader(i), fntTableFont)) With {
                .VerticalAlignment = PdfPCell.ALIGN_LEFT,
            .HorizontalAlignment = PdfPCell.ALIGN_LEFT,
            .Border = iTextSharp.text.Rectangle.NO_BORDER
                }
            headerTabela.AddCell(celltwohdr)

        Next
        document.Add(headerTabela)
    End Sub
End Class

