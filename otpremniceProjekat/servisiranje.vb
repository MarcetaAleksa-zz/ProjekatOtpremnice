Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Text.StringBuilder


Public Class servisiranje

    Private Sub Nazad_Click(sender As Object, e As EventArgs) Handles Nazad.Click
        serv.Show()
        Me.Close()
    End Sub
    Public brojac As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        brojac = 0
        Try
            If ServiserCB.SelectedIndex = -1 Then
                MsgBox("Molimo izaberite servisera", vbOKOnly, "SERVIS")

            Else
                brojac += 1
                If OpisTB.Text = Nothing Or OpisTB.Text = "OPIS PROBLEMA" Then
                    brojac = 0
                    MsgBox("Molimo da popunite polje za opisom.", vbOKOnly, "SERVIS")
                Else
                    brojac += 1
                    If OtpremaTB.Text = Nothing Or OtpremaTB.Text = "Unesite ime i prezime musterije" Then
                        brojac = 0
                        MsgBox("Molimo unesite ime musterije.", vbOKOnly, "SERVIS")
                    Else
                        brojac += 1
                        If EmailTB.Text = Nothing Or EmailTB.Text = "Unesite broj email musterije" Then
                            MsgBox("Molimo unesite email adresu", vbOKOnly, "SERVIS")
                        Else
                            brojac += 1
                            If TelefonTB.Text = Nothing Or TelefonTB.Text = "Unesite broj telefona musterije" Then
                                MsgBox("Molimo unesite broj telefona", vbOKOnly, "SERVIS")
                            Else
                                brojac += 1
                                Dim pdfDoc As New Document(PageSize.A4.Rotate, 40, 40, 80, 20) 'postavljamo dimenzije naseg .pdf dokumenta
                                Dim filename As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Servis " & BrojServisaTB.Text & ".pdfs")
                                Dim pdfWriter As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(filename, FileMode.Create)) 'snimanje .pdf-a
                                Dim fntTableFontHdr As iTextSharp.text.Font = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                                Dim fntTableFont As iTextSharp.text.Font = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
                                Dim ev As New events
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
                                '-------------------------------------------------KRAJ TABELE------------------------------------------------------------------------------------------------

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


                                Dim cellSixhdr As New PdfPCell(New Phrase("/", fntTableFont)) With {
                .VerticalAlignment = PdfPCell.ALIGN_LEFT,
            .HorizontalAlignment = PdfPCell.ALIGN_LEFT
             }
                                ptabela.AddCell(cellSixhdr)

                                pdfDoc.Add(ptabela)
                                pdfDoc.Close()
                                servispdf.Show()
                                servispdf.ucitavanjaPDFa(filename)
                                servispdf.biraj = 1
                                Me.Enabled = False
                                Me.Hide()

                            End If

                        End If

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Me.Dispose()
        End Try


    End Sub

    Private Sub servisiranje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim komanda As New SqlCommand("select zaposleni.ime + ' ' + zaposleni.prezime as serviser from zaposleni", baza.konekcija)
        Dim adapter As New SqlDataAdapter(komanda)
        Dim dataset As New DataSet
        adapter.Fill(dataset)
        ServiserCB.DataSource = dataset.Tables(0)
        ServiserCB.ValueMember = "serviser"
        ServiserCB.DisplayMember = "serviser"
        ServiserCB.SelectedIndex = -1
        StanjeCB.SelectedIndex = 0

        Dim commandBrojOtpremnice As New SqlCommand("select MAX(id_servisa) from servis", baza.konekcija)
        Dim adapterBO As New SqlDataAdapter(commandBrojOtpremnice)
        Dim tabelaBO As New DataTable()
        adapterBO.Fill(tabelaBO)

        BrojServisaTB.Text = tabelaBO.Rows(0)(0) + 1

        Dim datum As Date
        datum = DateTime.Now.ToString("yyyy/MM/dd")
        datumtb.Text = datum
        Me.WindowState = FormWindowState.Normal
    End Sub
    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles OtpremaTB.Enter
        If (OtpremaTB.Text = "Unesite ime i prezime musterije") Then
            OtpremaTB.Text = ""
            OtpremaTB.ForeColor = Color.Black
        End If
    End Sub
    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles OtpremaTB.Leave
        If (OtpremaTB.Text = "") Then
            OtpremaTB.Text = "Unesite ime i prezime musterije"
            OtpremaTB.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub EmailTB_Enter(sender As Object, e As EventArgs) Handles EmailTB.Enter
        If (EmailTB.Text = "Unesite broj email musterije") Then
            EmailTB.Text = ""
            EmailTB.ForeColor = Color.Black

        End If
    End Sub
    Private Sub EmailTB_leave(sender As Object, e As EventArgs) Handles EmailTB.Leave
        If (EmailTB.Text = "") Then
            EmailTB.Text = "Unesite broj email musterije"
            EmailTB.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TelefonTB_Enter(sender As Object, e As EventArgs) Handles TelefonTB.Enter
        If (TelefonTB.Text = "Unesite broj telefona musterije") Then
            TelefonTB.Text = ""
            TelefonTB.ForeColor = Color.Black

        End If
    End Sub
    Private Sub TelefonTB_leave(sender As Object, e As EventArgs) Handles TelefonTB.Leave
        If (TelefonTB.Text = "") Then
            TelefonTB.Text = "Unesite broj telefona musterije"
            TelefonTB.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub
    Public Function salji()
        If brojac = 5 Then
            Dim komanda As New SqlCommand("Insert into Panleksa.dbo.servis (id_servisa, serviser, usluga, otprema_na_naslov, prijem, stanje_servisa, email, telefon)
Values (" & BrojServisaTB.Text & "," & ServiserCB.SelectedIndex + 1 & ", '" & OpisTB.Text & "', '" & OtpremaTB.Text & "', '" & datumtb.Text & "', 0, '" & EmailTB.Text & "', '" & TelefonTB.Text & "')", baza.konekcija)
            komanda.Connection.Open()
            komanda.ExecuteNonQuery()
            komanda.Connection.Close()
            brojac = 0
            Try
                Dim email As New MailMessage()


                Hash.HashStorePrijava = Nothing
                email.From = New MailAddress("servisracunaradoo@gmail.com")
                email.To.Add(EmailTB.Text)
                email.Subject = "Racunari d.o.o 2FA"
                email.IsBodyHtml = False
                email.Body = "Postovani,
U prilogu Vam saljemo potvrdu da ste uspjesno predali uredjaj na servisiranje.
Opis problema: " & OpisTB.Text & "
Musterija: " & OtpremaTB.Text & "
Datum predaje: " & datumtb.Text & "
Vas servisni ID je: " & BrojServisaTB.Text & ".
U slucaju dodatnih pitanja slobodno nas kontaktirajte na email adresu: servisracunaradoo@gmail.com
LP"
                Dim SMTP As New SmtpClient("smtp.gmail.com")
                SMTP.Port = 587S
                SMTP.EnableSsl = True
                SMTP.Credentials = New System.Net.NetworkCredential("servisracunaradoo@gmail.com", "RDBMSiSoftverskoInzinjerstvo")
                SMTP.Send(email)
                MsgBox("Email obavjestenja je poslat musteriji.", vbOKOnly, "SERVIS")
            Catch error_t As Exception

            End Try

            serv.Show()
            Me.Dispose()

        End If
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ServiserCB.SelectedIndex = 1
        OtpremaTB.Text = "Aleksandar Panzalovic"
        EmailTB.Text = "aleksandar.panzalovic@gmail.com"
        TelefonTB.Text = "+38765552558"
        OpisTB.Text = "Text"
    End Sub
End Class
Public Class events
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
        Dim podaciHeader As New List(Of String)({servisiranje.BrojServisaTB.Text, servisiranje.ServiserCB.Text, servisiranje.OtpremaTB.Text, servisiranje.datumtb.Text, "/", servisiranje.TelefonTB.Text, servisiranje.EmailTB.Text})

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
