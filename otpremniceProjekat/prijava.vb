Imports System.Text.StringBuilder
Imports System.Data.SqlClient
Imports System.Net.Mail
'U = otpremnicepdf@mail.com
'P = RDBMSiSoftverskoInzinjerstvo
Public Class prijava
    Private Sub dugmePrijava_Click(sender As Object, e As EventArgs) Handles dugmePrijava.Click
        TextBox1.Text = "Aleksandar"
        Dim AuthKey As String
        Dim temp As String
        Dim r As New Random
        Dim emailZ As String
        Dim komanda As New SqlCommand("SELECT email from zaposleni where korisnicko_ime ='" & TextBox1.Text & "'", baza.konekcija)
        Dim adapter As New SqlDataAdapter(komanda)
        Dim tabela As New DataTable
        Dim email As New MailMessage()




        adapter.Fill(tabela)
        emailZ = tabela.Rows(0)(0)
        temp = RandomString(r)
        MessageBox.Show(emailZ)


        MessageBox.Show(temp)
        AuthKey = InputBox("Unesite autentikacioni kljuc:")
        If AuthKey = temp Then
            MessageBox.Show("Dobrodosli")
        Else
            MessageBox.Show("Pogresan kod")
        End If


        Try
            email.From = New MailAddress("otpremnicepdf@mail.com")
            email.To.Add(emailZ)
            email.Subject = "Racunari d.o.o 2FA"
            email.IsBodyHtml = False
            email.Body = temp
            Dim SMTP As New SmtpClient("smtp.gmail.com")
            SMTP.Port = 587S
            SMTP.EnableSsl = True
            SMTP.Credentials = New System.Net.NetworkCredential("otpremnicepdf@mail.com", "RDBMSiSoftverskoInzinjerstvo")
            SMTP.Send(email)
            MsgBox("Mail Sent")
        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try



    End Sub
    Function RandomString(r As Random)
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim sb As New System.Text.StringBuilder
        Dim cnt As Integer = r.Next(20, 50)
        For i As Integer = 1 To cnt
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function
End Class