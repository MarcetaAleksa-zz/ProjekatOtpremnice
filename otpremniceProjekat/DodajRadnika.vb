Imports System.Data.SqlClient
Public Class DodajRadnika

    'Ucitavanje
    Private Sub DodajRadnika_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        potrebnaRB.Select()
        Try
            Dim k As New SqlCommand("select max(id)+1 from zaposleni", baza.konekcija)
            Dim a As New SqlDataAdapter(k)
            Dim t As New DataTable()

            a.Fill(t)
            idTB.Text = t.Rows(0)(0)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Try
            Dim k As New SqlCommand("select radna_pozicija from radne_pozicije", baza.konekcija)
            Dim a As New SqlDataAdapter(k)
            Dim s As New DataSet()
            a.Fill(s)

            pozicijaCB.DataSource = s.Tables(0)
            pozicijaCB.ValueMember = "radna_pozicija"
            pozicijaCB.DisplayMember = "radna_pozicija"
            pozicijaCB.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Try
            Dim k As New SqlCommand("select distinct sluz_voz from zaposleni", baza.konekcija)
            Dim a As New SqlDataAdapter(k)
            Dim s As New DataSet()
            a.Fill(s)

            sluzbenoVoziloCB.DataSource = s.Tables(0)
            sluzbenoVoziloCB.ValueMember = "sluz_voz"
            sluzbenoVoziloCB.DisplayMember = "sluz_voz"
            sluzbenoVoziloCB.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Try
            Dim k As New SqlCommand("select naziv from tipovi_naloga", baza.konekcija)
            Dim a As New SqlDataAdapter(k)
            Dim s As New DataSet()
            a.Fill(s)

            tipNalogaCB.DataSource = s.Tables(0)
            tipNalogaCB.ValueMember = "naziv"
            tipNalogaCB.DisplayMember = "naziv"
            tipNalogaCB.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        lozinkaTB.Text = "Unesi lozinku ovdje"
        lozinkaTB.UseSystemPasswordChar = False
        lozinkaTB.ForeColor = Color.Gray
        confLozinkaTB.Text = "Ponovo unesite lozinku ovdje"
        confLozinkaTB.UseSystemPasswordChar = False
        confLozinkaTB.ForeColor = Color.Gray
        korisnickoImeTB.Text = "Unesi korisnicko ime ovdje"
        korisnickoImeTB.ForeColor = Color.Gray
        imeTB.Text = "Unesi ime zaposlenog ovdje"
        imeTB.ForeColor = Color.Gray
        prezimeTB.Text = "Unesi prezime zaposlenog ovdje"
        prezimeTB.ForeColor = Color.Gray
        adresaStanovanjaTB.Text = "Unesi adresu boravka ovdje"
        adresaStanovanjaTB.ForeColor = Color.Gray
        telefonTB.Text = "Unesi telefon ovdje"
        telefonTB.ForeColor = Color.Gray
        emailAdresaTB.Text = "Unesi email ovdje"
        emailAdresaTB.ForeColor = Color.Gray
        saltTB.Text = "Unesi nasumicnu rijec ovdje"
        saltTB.ForeColor = Color.Gray
    End Sub
    'Dugmad
    Private Sub snimiTB_Click(sender As Object, e As EventArgs) Handles snimiTB.Click
        Dim brojac As Integer
        brojac = 0
        Try
            If korisnickoImeTB.Text <> "Unesi korisnicko ime ovdje" And korisnickoImeTB.Text <> "" And (korisnickoImeTB.Text).Length > 2 Then
                brojac += 1
                If imeTB.Text <> "Unesi ime zaposlenog ovdje" And imeTB.Text <> "" And (imeTB.Text).Length > 3 Then
                    brojac += 1
                    If prezimeTB.Text <> "Unesi prezime zaposlenog ovdje" And prezimeTB.Text <> "" And (prezimeTB.Text).Length > 4 Then
                        brojac += 1
                        If adresaStanovanjaTB.Text <> "Unesi adresu boravka ovdje" And adresaStanovanjaTB.Text <> "" And (adresaStanovanjaTB.Text).Length > 10 Then
                            brojac += 1
                            If emailAdresaTB.Text <> "Unesi email ovdje" And emailAdresaTB.Text <> "" And (emailAdresaTB.Text).Length > 10 Then
                                brojac += 1
                                If telefonTB.Text <> "Unesi telefon ovdje" And telefonTB.Text <> "" And (telefonTB.Text).Length > 11 Then
                                    brojac += 1
                                    If saltTB.Text <> "Unesi nasumicnu rijec ovdje" And saltTB.Text <> "" And (saltTB.Text).Length > 5 Then
                                        brojac += 1
                                        If lozinkaTB.Text = confLozinkaTB.Text And lozinkaTB.Text <> "Unesi lozinku ovdje" And lozinkaTB.Text <> "" And (lozinkaTB.Text).Length > 7 Then
                                            brojac += 1
                                            Hash.Hashing()
                                            If pozicijaCB.SelectedIndex <> -1 Then
                                                brojac += 1
                                                If sluzbenoVoziloCB.Text <> "" Then
                                                    brojac += 1
                                                    If tipNalogaCB.SelectedIndex <> -1 Then
                                                        brojac += 1
                                                        If brojac = 11 Then
                                                            Dim auth As Boolean
                                                            If nijePotrebnaRB.Checked Then
                                                                auth = True
                                                            ElseIf potrebnaRB.Checked Then
                                                                auth = False
                                                            Else
                                                                auth = Nothing
                                                            End If
                                                            Dim k As New SqlCommand("Insert into zaposleni(id, korisnicko_ime, lozinka, tip_naloga, ime, prezime, pozicija, adresa,  telefon, sluz_voz, email, salt, auth)  Values(" & idTB.Text & ", '" & (korisnickoImeTB.Text).ToLower & "', '" & Hash.HashNoviKorisnik & "', " & tipNalogaCB.SelectedIndex + 1 & ", '" & imeTB.Text & "', '" & prezimeTB.Text & "', " & pozicijaCB.SelectedIndex + 1 & ", '" & adresaStanovanjaTB.Text & "', '" & telefonTB.Text & "', '" & sluzbenoVoziloCB.Text & "', '" & emailAdresaTB.Text & "', '" & saltTB.Text & "', '" + auth.ToString + "');", baza.konekcija)
                                                            k.Connection.Open()
                                                            k.ExecuteNonQuery()
                                                            k.Connection.Close()
                                                            MsgBox("Nalog uspjesno napravljen.", vbInformation)
                                                            Me.Controls.Clear()
                                                            InitializeComponent()
                                                            DodajRadnika_Load(e, e)
                                                        End If
                                                    Else
                                                        MsgBox("Molimo izaberite tip naloga.", vbCritical)
                                                    End If
                                                Else
                                                    MsgBox("Molimo unesite registracijske tablice.", vbCritical)
                                                End If
                                            Else
                                                MsgBox("Molimo izaberite poziciju.", vbCritical)
                                            End If
                                        Else
                                            MsgBox("Lozinka se ne poklapa ili je kraca od 8 karaktera.", vbCritical)
                                        End If
                                    Else
                                        MsgBox("Nasumicna rijec mora biti duza od 6 karaktera.", vbCritical)
                                    End If
                                Else
                                    MsgBox("Molimo unesite broj telefona.", vbCritical)
                                End If
                            Else
                                MsgBox("Molimo unesite email adresu.", vbCritical)
                            End If
                        Else
                            MsgBox("Molimo unesite adresu boravka.", vbCritical)
                        End If
                    Else
                        MsgBox("Molimo unesite prezime.", vbCritical)
                    End If
                Else
                    MsgBox("Molimo unesite ime.", vbCritical)
                End If
            Else
                MsgBox("Molimo unesite korisnicko ime.", vbCritical)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        brojac = 0

    End Sub

    Private Sub Nazad_Click(sender As Object, e As EventArgs) Handles Nazad.Click
        AdminIzbor.Show()
        Me.Dispose()
    End Sub
    'place holderi
    '<------------------------------------------------------------------------------------------------------------------>
    'loznka
    Private Sub lozinkaTB_Enter(sender As Object, e As EventArgs) Handles lozinkaTB.Enter
        If (lozinkaTB.Text = "Unesi lozinku ovdje") Then
            lozinkaTB.Text = ""
            lozinkaTB.UseSystemPasswordChar = True
            lozinkaTB.ForeColor = Color.Black
        End If
    End Sub
    Private Sub lozinkaTB_Leave(sender As Object, e As EventArgs) Handles lozinkaTB.Leave
        If (lozinkaTB.Text = "") Then
            lozinkaTB.Text = "Unesi lozinku ovdje"
            lozinkaTB.UseSystemPasswordChar = False
            lozinkaTB.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub lozinkaTB_MouseEnter(sender As Object, e As EventArgs) Handles lozinkaTB.MouseEnter
        If (lozinkaTB.Text = "Unesi lozinku ovdje") Then
            lozinkaTB.Text = ""
            lozinkaTB.UseSystemPasswordChar = True
            lozinkaTB.ForeColor = Color.Black
        End If
    End Sub
    Private Sub lozinkaTB_MouseLeave(sender As Object, e As EventArgs) Handles lozinkaTB.MouseLeave
        If (lozinkaTB.Text = "") Then
            lozinkaTB.Text = "Unesi lozinku ovdje"
            lozinkaTB.UseSystemPasswordChar = False
            lozinkaTB.ForeColor = Color.Gray
        End If
    End Sub
    'ponovno unosenje lozinke
    Private Sub confLozinkaTB_Enter(sender As Object, e As EventArgs) Handles confLozinkaTB.Enter
        If (confLozinkaTB.Text = "Ponovo unesite lozinku ovdje") Then
            confLozinkaTB.Text = ""
            confLozinkaTB.UseSystemPasswordChar = True
            confLozinkaTB.ForeColor = Color.Black
        End If
    End Sub
    Private Sub confLozinkaTB_Leave(sender As Object, e As EventArgs) Handles confLozinkaTB.Leave
        If (confLozinkaTB.Text = "") Then
            confLozinkaTB.Text = "Ponovo unesite lozinku ovdje"
            confLozinkaTB.UseSystemPasswordChar = False
            confLozinkaTB.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub confLozinkaTB_MouseEnter(sender As Object, e As EventArgs) Handles confLozinkaTB.MouseEnter
        If (confLozinkaTB.Text = "Ponovo unesite lozinku ovdje") Then
            confLozinkaTB.Text = ""
            confLozinkaTB.UseSystemPasswordChar = True
            confLozinkaTB.ForeColor = Color.Black
        End If
    End Sub
    Private Sub confLozinkaTB_MouseLeave(sender As Object, e As EventArgs) Handles confLozinkaTB.MouseLeave
        If (confLozinkaTB.Text = "") Then
            confLozinkaTB.Text = "Ponovo unesite lozinku ovdje"
            confLozinkaTB.UseSystemPasswordChar = False
            confLozinkaTB.ForeColor = Color.Gray
        End If
    End Sub
    'korisnicko ime
    Private Sub korisnickoImeTB_Enter(sender As Object, e As EventArgs) Handles korisnickoImeTB.Enter
        If (korisnickoImeTB.Text = "Unesi korisnicko ime ovdje") Then
            korisnickoImeTB.Text = ""
            korisnickoImeTB.ForeColor = Color.Black
        End If
    End Sub
    Private Sub korisnickoImeTB_Leave(sender As Object, e As EventArgs) Handles korisnickoImeTB.Leave
        If (korisnickoImeTB.Text = "") Then
            korisnickoImeTB.Text = "Unesi korisnicko ime ovdje"
            korisnickoImeTB.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub korisnickoImeTB_MouseEnter(sender As Object, e As EventArgs) Handles korisnickoImeTB.MouseEnter
        If (korisnickoImeTB.Text = "Unesi korisnicko ime ovdje") Then
            korisnickoImeTB.Text = ""
            korisnickoImeTB.ForeColor = Color.Black
        End If
    End Sub
    Private Sub korisnickoImeTB_MouseLeave(sender As Object, e As EventArgs) Handles korisnickoImeTB.MouseLeave
        If (korisnickoImeTB.Text = "") Then
            korisnickoImeTB.Text = "Unesi korisnicko ime ovdje"
            korisnickoImeTB.ForeColor = Color.Gray
        End If
    End Sub
    'ime
    Private Sub imeTB_Enter(sender As Object, e As EventArgs) Handles imeTB.Enter
        If (imeTB.Text = "Unesi ime zaposlenog ovdje") Then
            imeTB.Text = ""
            imeTB.ForeColor = Color.Black
        End If
    End Sub
    Private Sub imeTB_Leave(sender As Object, e As EventArgs) Handles imeTB.Leave
        If (imeTB.Text = "") Then
            imeTB.Text = "Unesi ime zaposlenog ovdje"
            imeTB.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub imeTB_MouseEnter(sender As Object, e As EventArgs) Handles imeTB.MouseEnter
        If (imeTB.Text = "Unesi ime zaposlenog ovdje") Then
            imeTB.Text = ""
            imeTB.ForeColor = Color.Black
        End If
    End Sub
    Private Sub imeTB_MouseLeave(sender As Object, e As EventArgs) Handles imeTB.MouseLeave
        If (imeTB.Text = "") Then
            imeTB.Text = "Unesi ime zaposlenog ovdje"
            imeTB.ForeColor = Color.Gray
        End If
    End Sub
    'prezime
    Private Sub prezimeTB_Enter(sender As Object, e As EventArgs) Handles prezimeTB.Enter
        If (prezimeTB.Text = "Unesi prezime zaposlenog ovdje") Then
            prezimeTB.Text = ""
            prezimeTB.ForeColor = Color.Black
        End If
    End Sub
    Private Sub prezimeTB_Leave(sender As Object, e As EventArgs) Handles prezimeTB.Leave
        If (prezimeTB.Text = "") Then
            prezimeTB.Text = "Unesi prezime zaposlenog ovdje"
            prezimeTB.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub prezimeTB_MouseEnter(sender As Object, e As EventArgs) Handles prezimeTB.MouseEnter
        If (prezimeTB.Text = "Unesi prezime zaposlenog ovdje") Then
            prezimeTB.Text = ""
            prezimeTB.ForeColor = Color.Black
        End If
    End Sub
    Private Sub prezimeTB_MouseLeave(sender As Object, e As EventArgs) Handles prezimeTB.MouseLeave
        If (prezimeTB.Text = "") Then
            prezimeTB.Text = "Unesi prezime zaposlenog ovde"
            prezimeTB.ForeColor = Color.Gray
        End If
    End Sub
    'adresa
    Private Sub adresaStanovanjaTB_Enter(sender As Object, e As EventArgs) Handles adresaStanovanjaTB.Enter
        If (adresaStanovanjaTB.Text = "Unesi adresu boravka ovdje") Then
            adresaStanovanjaTB.Text = ""
            adresaStanovanjaTB.ForeColor = Color.Black
        End If
    End Sub
    Private Sub adresaStanovanjaTB_Leave(sender As Object, e As EventArgs) Handles adresaStanovanjaTB.Leave
        If (adresaStanovanjaTB.Text = "") Then
            adresaStanovanjaTB.Text = "Unesi adresu boravka ovdje"
            adresaStanovanjaTB.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub adresaStanovanjaTB_MouseEnter(sender As Object, e As EventArgs) Handles adresaStanovanjaTB.MouseEnter
        If (adresaStanovanjaTB.Text = "Unesi adresu boravka ovdje") Then
            adresaStanovanjaTB.Text = ""
            adresaStanovanjaTB.ForeColor = Color.Black
        End If
    End Sub
    Private Sub adresaStanovanjaTB_MouseLeave(sender As Object, e As EventArgs) Handles adresaStanovanjaTB.MouseLeave
        If (adresaStanovanjaTB.Text = "") Then
            adresaStanovanjaTB.Text = "Unesi adresu boravka ovdje"
            adresaStanovanjaTB.ForeColor = Color.Gray
        End If
    End Sub
    'telefon
    Private Sub telefonTB_Enter(sender As Object, e As EventArgs) Handles telefonTB.Enter
        If (telefonTB.Text = "Unesi telefon ovdje") Then
            telefonTB.Text = ""
            telefonTB.ForeColor = Color.Black
        End If
    End Sub
    Private Sub telefonTB_Leave(sender As Object, e As EventArgs) Handles telefonTB.Leave
        If (telefonTB.Text = "") Then
            telefonTB.Text = "Unesi telefon ovdje"
            telefonTB.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub telefonTB_MouseEnter(sender As Object, e As EventArgs) Handles telefonTB.MouseEnter
        If (telefonTB.Text = "Unesi telefon ovdje") Then
            telefonTB.Text = ""
            telefonTB.ForeColor = Color.Black
        End If
    End Sub
    Private Sub telefonTB_MouseLeave(sender As Object, e As EventArgs) Handles telefonTB.MouseLeave
        If (korisnickoImeTB.Text = "") Then
            korisnickoImeTB.Text = "Unesi telefon ovdje"
            korisnickoImeTB.ForeColor = Color.Gray
        End If
    End Sub
    'email
    Private Sub emailAdresaTB_Enter(sender As Object, e As EventArgs) Handles emailAdresaTB.Enter
        If (emailAdresaTB.Text = "Unesi email ovdje") Then
            emailAdresaTB.Text = ""
            emailAdresaTB.ForeColor = Color.Black
        End If
    End Sub
    Private Sub emailAdresaTB_Leave(sender As Object, e As EventArgs) Handles emailAdresaTB.Leave
        If (emailAdresaTB.Text = "") Then
            emailAdresaTB.Text = "Unesi email ovdje"
            emailAdresaTB.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub emailAdresaTB_MouseEnter(sender As Object, e As EventArgs) Handles emailAdresaTB.MouseEnter
        If (emailAdresaTB.Text = "Unesi email ovdje") Then
            emailAdresaTB.Text = ""
            emailAdresaTB.ForeColor = Color.Black
        End If
    End Sub
    Private Sub emailAdresaTB_MouseLeave(sender As Object, e As EventArgs) Handles emailAdresaTB.MouseLeave
        If (emailAdresaTB.Text = "") Then
            emailAdresaTB.Text = "Unesi email ovdje"
            emailAdresaTB.ForeColor = Color.Gray
        End If
    End Sub
    'salt
    Private Sub saltTB_Enter(sender As Object, e As EventArgs) Handles saltTB.Enter
        If (saltTB.Text = "Unesi nasumicnu rijec ovdje") Then
            saltTB.Text = ""
            saltTB.ForeColor = Color.Black
        End If
    End Sub
    Private Sub saltTB_Leave(sender As Object, e As EventArgs) Handles saltTB.Leave
        If (saltTB.Text = "") Then
            saltTB.Text = "Unesi nasumicnu rijec ovdje"
            saltTB.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub saltTB_MouseEnter(sender As Object, e As EventArgs) Handles saltTB.MouseEnter
        If (saltTB.Text = "Unesi nasumicnu rijec ovdje") Then
            saltTB.Text = ""
            saltTB.ForeColor = Color.Black
        End If
    End Sub
    Private Sub saltTB_MouseLeave(sender As Object, e As EventArgs) Handles saltTB.MouseLeave
        If (saltTB.Text = "") Then
            saltTB.Text = "Unesi nasumicnu rijec ovdje"
            saltTB.ForeColor = Color.Gray
        End If
    End Sub
End Class











