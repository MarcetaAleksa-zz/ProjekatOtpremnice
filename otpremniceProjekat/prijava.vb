Imports System.Text.StringBuilder
Imports System.Data.SqlClient
Imports System.Net.Mail
'U = otpremnicepdf@mail.com
'P = RDBMSiSoftverskoInzinjerstvo
Public Class prijava
    Public Shared pozicija As Integer
    Public Shared Salt As String
    Public Shared Hashed As String
    Public Shared pw As String
    Private Sub dugmePrijava_Click(sender As Object, e As EventArgs) Handles dugmePrijava.Click
        If TextBox1.Text = "Unesi korisničko ime ovde" Or TextBox2.Text = "Unesi lozinku ovde" Then
            MsgBox("Unesite podatke za prijavu!", vbOKOnly, "Prijava")
        Else
            Dim AuthKey As String
            Dim tempo As String
            Dim r As New Random
            Dim emailZ As String
            Dim komanda As New SqlCommand("SELECT email, korisnicko_ime, lozinka, salt, auth, pozicija  from zaposleni where korisnicko_ime ='" & TextBox1.Text & "'", baza.konekcija)
            Dim adapter As New SqlDataAdapter(komanda)
            Dim tabela As New DataTable
            Dim email As New MailMessage()
            Dim UN As String
            Dim pz As Integer
            Dim auth As Boolean
            Try
                adapter.Fill(tabela)
                emailZ = tabela.Rows(0)(0)
                UN = tabela.Rows(0)(1)
                pw = tabela.Rows(0)(2)
                Salt = tabela.Rows(0)(3)
                auth = tabela.Rows(0)(4)
                tempo = RandomString(r)
                pozicija = tabela.Rows(0)(5)
            Catch
                MsgBox("Netacni podaci!", vbOKOnly, "GRESKA")
            End Try
            Hash.Hashing()
            Try
                If TextBox1.Text.ToLower = tabela.Rows(0)(1) And Hash.HashStorePrijava = Hash.HashStore Then
                    If auth = True Then
                        MsgBox("Dobrodosli", vbOKOnly, "Prijava")
                        Medjuforma.Show()
                        Me.Hide()
                    Else
                        Try
                            Hash.HashStore = Nothing
                            Hash.HashStorePrijava = Nothing
                            email.From = New MailAddress("servisracunaradoo@gmail.com")
                            email.To.Add(emailZ)
                            email.Subject = "Racunari d.o.o 2FA"
                            email.IsBodyHtml = False
                            email.Body = "Vas autentikacioni kod za Servis Racunara DOO je: " + tempo
                            Dim SMTP As New SmtpClient("smtp.gmail.com")
                            SMTP.Port = 587S
                            SMTP.EnableSsl = True
                            SMTP.Credentials = New System.Net.NetworkCredential("servisracunaradoo@gmail.com", "RDBMSiSoftverskoInzinjerstvo")
                            SMTP.Send(email)
                            MsgBox("Poslali smo Vam autentikacioni kljuc na Vasu email adresu.", vbOKOnly, "Dvostruka provjera identiteta")
                        Catch error_t As Exception

                        End Try
                        AuthKey = InputBox("Unesite autentikacioni kljuc:")
                        If AuthKey = tempo Then 'tempo
                            MsgBox("Dobrodosli", vbOKOnly, "Prijava")
                            Medjuforma.Show()
                            Me.Hide()
                        Else
                            MsgBox("Pogresan kod. Molimo zatrazite novi kod kako bi ste se prijavili.", vbOKOnly, "GRESKA")
                            TextBox1.Text = "Unesi korisničko ime ovde"
                            TextBox1.ForeColor = Color.Gray
                            TextBox2.Text = "Unesi lozinku ovde"
                            TextBox2.UseSystemPasswordChar = False
                            TextBox2.ForeColor = Color.Gray
                        End If
                    End If
                Else
                    MsgBox("Pogresna lozinka, molimo unesite ispravnu.")
                    Hash.HashStore = Nothing
                    Hash.HashStorePrijava = Nothing
                    TextBox2.Text = "Unesi lozinku ovde"
                    TextBox2.UseSystemPasswordChar = False
                    TextBox2.ForeColor = Color.Gray
                    pozicija = Nothing
                End If
            Catch
            End Try
        End If
    End Sub
    Public Sub reload(sender As Object, e As EventArgs)
        Me.Controls.Clear() 'removes all the controls on the form
        InitializeComponent() 'load all the controls again
        prijava_Load(e, e)
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
    Private Sub TextBox1_MouseEnter(Sender As Object, e As EventArgs) Handles TextBox1.MouseEnter
        If (TextBox1.Text = "Unesi korisničko ime ovde") Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub
    Private Sub TextBox1_MouserLeave(sender As Object, e As EventArgs) Handles TextBox1.MouseLeave
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
    Private Sub TextBix2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        If (TextBox2.Text = "") Then
            TextBox2.Text = "Unesi lozinku ovde"
            TextBox2.UseSystemPasswordChar = False
            TextBox2.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox2_MouseEnter(sender As Object, e As EventArgs) Handles TextBox2.MouseEnter
        If (TextBox2.Text = "Unesi lozinku ovde") Then
            TextBox2.Text = ""
            TextBox2.UseSystemPasswordChar = True
            TextBox2.ForeColor = Color.Black
        End If
    End Sub
    Private Sub TextBix2_MouseLeave(sender As Object, e As EventArgs) Handles TextBox2.MouseLeave
        If (TextBox2.Text = "") Then
            TextBox2.Text = "Unesi lozinku ovde"
            TextBox2.UseSystemPasswordChar = False
            TextBox2.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub prijava_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim odogovor = MsgBox("Da li zelite da izadjete iz programa?", vbYesNo, "SERVIS RACUNARA D.O.O")
        If odogovor = vbYes Then
            Me.Close()
            dodajArtikal.Close()
            isporuka.Close()
            istorijaProdaje.Close()
            Medjuforma.Close()
            otpremnice.Close()
            serv.Close()
            servisiranje.Close()
            ucitavanje.Close()
            isporuka.Close()
            AdminIzbor.Close()
            DodajRadnika.Close()
            IzmjeniIzbrisiRadnika.Close()
        End If
    End Sub
End Class