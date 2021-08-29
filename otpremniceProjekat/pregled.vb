Imports System.Data.SqlClient

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

    Private Sub idServisaCB_change(sender As Object, e As EventArgs) Handles idServisaCB.SelectedIndexChanged

    End Sub
End Class