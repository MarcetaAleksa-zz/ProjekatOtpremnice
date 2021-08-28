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
                MessageBox.Show("Molimo izaberite servisera")

            Else
                brojac += 1
                If OpisTB.Text = Nothing Or OpisTB.Text = "OPIS PROBLEMA" Then
                    brojac = 0
                    MessageBox.Show("Molimo da popunite polje za opisom.")
                Else
                    brojac += 1
                    If OtpremaTB.Text = Nothing Or OtpremaTB.Text = "Unesite ime i prezime musterije" Then
                        brojac = 0
                        MessageBox.Show("Molimo unesite ime musterije.")
                    Else
                        brojac += 1
                        If EmailTB.Text = Nothing Or EmailTB.Text = "Unesite broj email musterije" Then
                            MessageBox.Show("Molimo unesite email adresu")
                        Else
                            brojac += 1
                            If TelefonTB.Text = Nothing Or TelefonTB.Text = "Unesite broj telefona musterije" Then
                                MessageBox.Show("Molimo unesite broj telefona")
                            Else
                                brojac += 1
                                If brojac = 5 Then
                                    Dim komanda As New SqlCommand("Insert into Panleksa.dbo.servis (id_servisa, serviser, usluga, otprema_na_naslov, prijem, stanje_servisa, email, telefon)
Values (" & BrojServisaTB.Text & "," & ServiserCB.SelectedIndex + 1 & ", '" & OpisTB.Text & "', '" & OtpremaTB.Text & "', '" & datumtb.Text & "', 0, '" & EmailTB.Text & "', '" & TelefonTB.Text & "')", baza.konekcija)
                                    komanda.Connection.Open()
                                    komanda.ExecuteNonQuery()
                                    komanda.Connection.Close()
                                    brojac = 0
                                    Try
                                        Dim email As New MailMessage()

                                        Hash.HashStore = Nothing
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
                                        MsgBox("Email obavjestelja je poslat musteriji.")
                                    Catch error_t As Exception

                                    End Try

                                    serv.Show()
                                    Me.Close()

                                End If
                            End If

                        End If

                    End If
                    End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
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
    End Sub
    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles OtpremaTB.Enter
        If (OtpremaTB.Text = "Unesite ime i prezime musterije") Then
            OtpremaTB.Text = ""
            OtpremaTB.ForeColor = Color.White
        End If
    End Sub
    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles OtpremaTB.Leave
        If (OtpremaTB.Text = "") Then
            OtpremaTB.Text = "Unesite ime i prezime musterije"
            OtpremaTB.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub OpisTB_Enter(sender As Object, e As EventArgs) Handles OpisTB.Enter
        If (OpisTB.Text = "OPIS PROBLEMA") Then
            OpisTB.Text = ""
            OpisTB.ForeColor = Color.White

        End If
    End Sub
    Private Sub OpisTB_leave(sender As Object, e As EventArgs) Handles OtpremaTB.Leave
        If (OpisTB.Text = "") Then
            OpisTB.Text = "OPIS PROBLEMA"
            OpisTB.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub EmailTB_Enter(sender As Object, e As EventArgs) Handles EmailTB.Enter
        If (EmailTB.Text = "Unesite broj email musterije") Then
            EmailTB.Text = ""
            EmailTB.ForeColor = Color.White

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
            TelefonTB.ForeColor = Color.White

        End If
    End Sub
    Private Sub TelefonTB_leave(sender As Object, e As EventArgs) Handles TelefonTB.Leave
        If (TelefonTB.Text = "") Then
            TelefonTB.Text = "Unesite broj telefona musterije"
            TelefonTB.ForeColor = Color.Gray
        End If
    End Sub

End Class