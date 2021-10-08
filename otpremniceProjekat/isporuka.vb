Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Text.StringBuilder

Public Class isporuka
    Public em As String
    Private Sub NazadBT_Click(sender As Object, e As EventArgs) Handles NazadBT.Click
        serv.Show()
        Me.Close()
    End Sub
    Private Function idServisa()
        Dim komanda As New SqlCommand("Select id_servisa from Panleksa.dbo.servis where stanje_servisa = 0", baza.konekcija)
        Dim adapter As New SqlDataAdapter(komanda)
        Dim ds As New DataSet
        adapter.Fill(ds)
        BrojServisaCB.DataSource = ds.Tables(0)
        BrojServisaCB.ValueMember = "id_servisa"
        BrojServisaCB.DisplayMember = "id_servisa"
        BrojServisaCB.SelectedIndex = 0
        StanjeCB.SelectedIndex = 0
        Dim datum As Date
        datum = DateTime.Now.ToString("yyyy/MM/dd")
        DatumDTB.Text = datum
    End Function
    Private Sub isporuka_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        idServisa()
        StatusServisaTB.Text = "OPIS ODRADJENOG POSLA (STANJA)"
        StatusServisaTB.ForeColor = Color.Gray
    End Sub
    Private Sub BrojServisaCb_change() Handles BrojServisaCB.SelectedIndexChanged
        Try
            Dim komanda1 As New SqlCommand("Select zap.ime + ' ' +  zap.prezime , usluga,  otprema_na_naslov, prijem, s.email, s.telefon from servis as s left join zaposleni as zap on (zap.id = s.serviser)  where id_servisa = " & BrojServisaCB.Text & "", baza.konekcija)
            Dim adapter1 As New SqlDataAdapter(komanda1)
            Dim tabela1 As New DataTable
            adapter1.Fill(tabela1)
            ServiserTB.Text = tabela1.Rows(0)(0)
            OpisTB.Text = tabela1.Rows(0)(1)
            OtpremaTB.Text = tabela1.Rows(0)(2)
            datumtb.Text = tabela1.Rows(0)(3)
            EmailTB.Text = tabela1.Rows(0)(4)
            TelefonTB.Text = tabela1.Rows(0)(5)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub SpasiIzmjeneBT_Click(sender As Object, e As EventArgs) Handles SpasiIzmjeneBT.Click
        Try
            If StatusServisaTB.Text = "" Or StatusServisaTB.Text = "OPIS ODRADJENOG POSLA (STANJA)" Then
                MessageBox.Show("Molimo da upisete opis za status servisa.")
            Else
                servispdf.biraj = 3

                Dim pdfDoc As New Document(PageSize.A4.Rotate, 40, 40, 80, 20) 'postavljamo dimenzije naseg .pdf dokumenta
                Dim filename As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Servis " & BrojServisaCB.Text & " zavrsen.pdfs")
                Dim pdfWriter As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(filename, FileMode.Create)) 'snimanje .pdf-a
                Dim fntTableFontHdr As iTextSharp.text.Font = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim fntTableFont As iTextSharp.text.Font = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
                Dim ev As New header
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

                Dim cellfourhdr As New PdfPCell(New Phrase(OpisTB.Text, fntTableFont)) With {
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


                Dim cellSixhdr As New PdfPCell(New Phrase(StatusServisaTB.Text, fntTableFont)) With {
                .VerticalAlignment = PdfPCell.ALIGN_LEFT,
            .HorizontalAlignment = PdfPCell.ALIGN_LEFT
             }
                ptabela.AddCell(cellSixhdr)



                pdfDoc.Add(ptabela)
                pdfDoc.Close()
                servispdf.Show()
                servispdf.ucitavanjaPDFa(filename)
                Me.Enabled = False
                Me.Hide()

            End If
        Catch
            MessageBox.Show("Zatvorite pdf dokument na kom vrsite izmjenu.")
        End Try
    End Sub

    Private Sub StatusServisaTB_enter() Handles StatusServisaTB.Enter
        If (StatusServisaTB.Text = "OPIS ODRADJENOG POSLA (STANJA)") Then
            StatusServisaTB.Text = ""
            StatusServisaTB.ForeColor = Color.Black

        End If
    End Sub
    Private Sub StatusServisaTB_leave() Handles StatusServisaTB.Leave
        If (StatusServisaTB.Text = "") Then
            StatusServisaTB.Text = "OPIS ODRADJENOG POSLA (STANJA)"
            StatusServisaTB.ForeColor = Color.Gray
        End If

    End Sub
    Private Sub StatusServisaTB_mouseenter() Handles StatusServisaTB.MouseEnter
        If (StatusServisaTB.Text = "OPIS ODRADJENOG POSLA (STANJA)") Then
            StatusServisaTB.Text = ""
            StatusServisaTB.ForeColor = Color.Black

        End If
    End Sub
    Private Sub StatusServisaTB_mouseleave() Handles StatusServisaTB.MouseLeave
        If (StatusServisaTB.Text = "") Then
            StatusServisaTB.Text = "OPIS ODRADJENOG POSLA (STANJA)"
            StatusServisaTB.ForeColor = Color.Gray
        End If

    End Sub

    Public Function isporucivanje()
        Try
            Dim komanda As New SqlCommand("UPDATE Panleksa.dbo.servis
SET stanje_servisa = 1, isporuka = '" & DatumDTB.Text & "', opis_servisa ='" & StatusServisaTB.Text & "'
 where id_servisa = " & BrojServisaCB.Text & "", baza.konekcija)
            Dim mailo As New SqlCommand("Select zap.ime + ' ' +  zap.prezime , usluga,  otprema_na_naslov, prijem, s.email, s.telefon from servis as s left join zaposleni as zap on (zap.id = s.serviser)  where id_servisa = " & BrojServisaCB.Text & "", baza.konekcija)
            Dim ad As New SqlDataAdapter(mailo)
            Dim tb1 As New DataTable
            ad.Fill(tb1)
            ServiserTB.Text = tb1.Rows(0)(0)
            OpisTB.Text = tb1.Rows(0)(1)
            OtpremaTB.Text = tb1.Rows(0)(2)
            datumtb.Text = tb1.Rows(0)(3)
            EmailTB.Text = tb1.Rows(0)(4)
            TelefonTB.Text = tb1.Rows(0)(5)
            em = tb1.Rows(0)(4)
            komanda.Connection.Open()
            komanda.ExecuteNonQuery()
            komanda.Connection.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Try

            Dim email As New MailMessage()


            Hash.HashStorePrijava = Nothing
            email.From = New MailAddress("servisracunaradoo@gmail.com")
            email.To.Add(em)
            email.Subject = "Racunari d.o.o 2FA"
            email.IsBodyHtml = False
            email.Body = "Postovani,
U saljemo Vam ovaj mail kako bi Vas obavjestili da je Vas uredjaj zavrsen i mozete ga doci i preuzeti.
Opis problema: " & OpisTB.Text & ",
Musterija: " & OtpremaTB.Text & ",
Datum predaje: " & datumtb.Text & ",
Vas servisni ID je: " & BrojServisaCB.Text & ",
Datum zavrsetka servisa: " & DatumDTB.Text & ",
Opis od strane servisera: " & StatusServisaTB.Text & ".
U slucaju dodatnih pitanja slobodno nas kontaktirajte na email adresu: servisracunaradoo@gmail.com
LP"
            Dim SMTP As New SmtpClient("smtp.gmail.com")
            SMTP.Port = 587S
            SMTP.EnableSsl = True
            SMTP.Credentials = New System.Net.NetworkCredential("servisracunaradoo@gmail.com", "RDBMSiSoftverskoInzinjerstvo")
            SMTP.Send(email)
            MsgBox("Email obavjestenja je poslat musteriji.", vbOKOnly, "SERVIS")
            Me.Controls.Clear() 'removes all the controls on the form
            InitializeComponent() 'load all the controls again
            serv.Show()
            Me.Dispose()
        Catch error_t As Exception
            MessageBox.Show(error_t.ToString)
        End Try
    End Function
End Class
Public Class header
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

        Dim podaciHeader As New List(Of String)({isporuka.StanjeCB.Text, isporuka.ServiserTB.Text, isporuka.OpisTB.Text, isporuka.datumtb.Text, isporuka.DatumDTB.Text, isporuka.TelefonTB.Text, isporuka.EmailTB.Text})

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