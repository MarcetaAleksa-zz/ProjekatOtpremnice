Imports System.Data.SqlClient

Public Class pregled
    Private Sub stanjeServisaTB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim komanda As New SqlCommand("Select id_servisa from servis where stanje_servisa = 1", baza.konekcija)
            Dim adapter As New SqlDataAdapter(komanda)
            Dim ds As New DataSet()
            adapter.Fill(ds)
            idServisaCB.SelectedIndex = -1
            idServisaCB.DataSource = ds.Tables(0)
            idServisaCB.ValueMember = "id_servisa"
            idServisaCB.DisplayMember = "id_servisa"

            Dim kom As New SqlCommand("Select * from servis where id_servisa = " & idServisaCB.Text & "", baza.konekcija)
            Dim ad As New SqlDataAdapter(kom)
            Dim tb As New DataTable()
            ad.Fill(tb)
            serviserTB.Text = tb.Rows(0)(1)
            uslugaTB.Text = tb.Rows(0)(2)
            musterijaTB.Text = tb.Rows(0)(3)
            datumPTB.Text = tb.Rows(0)(4)
            stanjeServisaTB.Text = tb.Rows(0)(5)
            datumITB.Text = tb.Rows(0)(6)
            emailTB.Text = tb.Rows(0)(7)
            telefonTB.Text = tb.Rows(0)(8)
            opisServisaTB.Text = tb.Rows(0)(9)
        Catch
        End Try

    End Sub
    Private Sub idServisaCB_change() Handles idServisaCB.SelectedIndexChanged
        Try
            Dim kom As New SqlCommand("Select id_servisa, zap.ime + ' ' +  zap.prezime , usluga,  otprema_na_naslov, prijem, s.stanje_servisa, s.isporuka, s.email, s.telefon,  s.opis_servisa from servis as s left join zaposleni as zap on (zap.id = s.serviser)  where id_servisa = " & idServisaCB.Text & "", baza.konekcija)
            Dim ad As New SqlDataAdapter(kom)
            Dim tb As New DataTable()
            ad.Fill(tb)
            serviserTB.Text = tb.Rows(0)(1)
            uslugaTB.Text = tb.Rows(0)(2)
            musterijaTB.Text = tb.Rows(0)(3)
            datumPTB.Text = tb.Rows(0)(4)
            stanjeServisaTB.Text = tb.Rows(0)(5)
            datumITB.Text = tb.Rows(0)(6)
            emailTB.Text = tb.Rows(0)(7)
            telefonTB.Text = tb.Rows(0)(8)
            opisServisaTB.Text = tb.Rows(0)(9)
        Catch
        End Try

    End Sub

    Private Sub Nazad_Click(sender As Object, e As EventArgs) Handles Nazad.Click
        serv.Show()
        Me.Close()
    End Sub
End Class