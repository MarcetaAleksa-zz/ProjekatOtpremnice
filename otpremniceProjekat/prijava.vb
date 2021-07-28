Imports System.Text.StringBuilder
Imports System.Data.SqlClient
Imports System.Net.Mail
'U = otpremnicepdf@mail.com
'P = RDBMSiSoftverskoInzinjerstvo
Public Class prijava

    Private Sub dugmePrijava_Click(sender As Object, e As EventArgs) Handles dugmePrijava.Click
        Dim AuthKey As String
        Dim temp As String
        Dim r As New Random
        Dim emailZ As String
        Dim komanda As New SqlCommand("SELECT email, korisnicko_ime, lozinka  from zaposleni where korisnicko_ime ='" & TextBox1.Text & "'", baza.konekcija)
        Dim adapter As New SqlDataAdapter(komanda)
        Dim tabela As New DataTable
        Dim email As New MailMessage()
        Dim UN As String
        Dim pw As String
        Dim pz As Integer

        Try
            adapter.Fill(tabela)
            emailZ = tabela.Rows(0)(0)
            UN = tabela.Rows(0)(1)
            pw = tabela.Rows(0)(2)
            pz = tabela.Rows(0)(3)
            temp = RandomString(r)
        Catch ex As Exception
        End Try



        Try
            If TextBox1.Text = UN And TextBox2.Text = pw Then
                Try
                    email.From = New MailAddress("servisracunaradoo@gmail.com")
                    email.To.Add(emailZ)
                    email.Subject = "Racunari d.o.o 2FA"
                    email.IsBodyHtml = False
                    email.Body = temp
                    Dim SMTP As New SmtpClient("smtp.gmail.com")
                    SMTP.Port = 587S
                    SMTP.EnableSsl = True
                    SMTP.Credentials = New System.Net.NetworkCredential("servisracunaradoo@gmail.com", "RDBMSiSoftverskoInzinjerstvo")
                    SMTP.Send(email)
                    MsgBox("Poslali smo Vam autentikacioni kljuc na Vasu email adresu.")
                Catch error_t As Exception

                End Try
                AuthKey = InputBox("Unesite autentikacioni kljuc:")
                If AuthKey = temp Then
                    MessageBox.Show("Dobrodosli")
                Else
                    MessageBox.Show("Pogresan kod, probajte ponovo.")
                    MessageBox.Show("Pokusaji preostali: 3")
                    AuthKey = InputBox("Unesite autentikacioni kljuc:")
                    If AuthKey = temp Then
                        MessageBox.Show("Dobrodosli")
                    Else
                        MessageBox.Show("Pogresan kod, probajte ponovo.")
                        MessageBox.Show("Pokusaji preostali: 2")
                        AuthKey = InputBox("Unesite autentikacioni kljuc:")
                        If AuthKey = temp Then
                            MessageBox.Show("Dobrodosli")
                        Else
                            MessageBox.Show("Pogresan kod, probajte ponovo.")
                            MessageBox.Show("Pokusaji preostali: 1")
                            AuthKey = InputBox("Unesite autentikacioni kljuc:")
                            If AuthKey = temp Then
                                MessageBox.Show("Dobrodosli")
                            Else
                                MessageBox.Show("Pogresan kod, nemate vise pokusaja. Molimo zatrazite novi kod kako bi ste se prijavili.")

                            End If
                        End If
                    End If

                End If

            Else
                MessageBox.Show("Pogresna lozinka, molimo unesite ispravnu.")
                End If

        Catch ex As Exception
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
    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        If (TextBox1.Text = "Unesi korisničko ime ovde") Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub
    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If (TextBox1.Text = "") Then
            TextBox1.Text = "Unesi korisničko ime ovde"
            TextBox1.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox2_Enter(sender As Object, e As EventArgs) Handles TextBox2.Enter
        If (TextBox2.Text = "Unesi lozinku ovde") Then
            TextBox2.Text = ""
            TextBox2.UseSystemPasswordChar = True
            TextBox2.ForeColor = Color.Black
        End If
    End Sub
    Private Sub Password_Form_Box_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        If (TextBox2.Text = "") Then
            TextBox2.Text = "Unesi lozinku ovde"
            TextBox2.UseSystemPasswordChar = False
            TextBox2.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub prijava_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
    End Sub
End Class