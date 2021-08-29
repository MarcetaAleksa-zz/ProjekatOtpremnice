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

            Hash.HashStore = Nothing
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
            isporuka_Load(e, e)
        Catch error_t As Exception
            MessageBox.Show(error_t.ToString)
        End Try
    End Sub

    Private Sub StatusServisaTB_enter() Handles StatusServisaTB.Enter
        If (StatusServisaTB.Text = "OPIS ODRADJENOG POSLA (STANJA)") Then
            StatusServisaTB.Text = ""
            StatusServisaTB.ForeColor = Color.White

        End If
    End Sub
    Private Sub StatusServisaTB_leave() Handles StatusServisaTB.Leave
        If (StatusServisaTB.Text = "") Then
            StatusServisaTB.Text = "OPIS ODRADJENOG POSLA (STANJA)"
            StatusServisaTB.ForeColor = Color.Gray
        End If

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub
End Class