Imports System.Data.SqlClient

Public Class isporuka
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
        datum = DateTime.Now.ToString("MM/dd/yyyy")
        DatumDTB.Text = datum
    End Function
    Private Sub isporuka_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        idServisa()
    End Sub
    Private Sub BrojServisaCb_change() Handles BrojServisaCB.SelectedIndexChanged
        Try
            Dim komanda1 As New SqlCommand("Select zap.ime + ' ' +  zap.prezime , usluga,  otprema_na_naslov, prijem from servis left join zaposleni as zap on (zap.id = servis.serviser)  where id_servisa = " & BrojServisaCB.Text & "", baza.konekcija)
            Dim adapter1 As New SqlDataAdapter(komanda1)
            Dim tabela1 As New DataTable
            adapter1.Fill(tabela1)
            ServiserTB.Text = tabela1.Rows(0)(0)
            OpisTB.Text = tabela1.Rows(0)(1)
            OtpremaTB.Text = tabela1.Rows(0)(2)
            datumtb.Text = tabela1.Rows(0)(3)
        Catch

        End Try

    End Sub

    Private Sub SpasiIzmjeneBT_Click(sender As Object, e As EventArgs) Handles SpasiIzmjeneBT.Click
        Try
            Dim komanda As New SqlCommand("UPDATE Panleksa.dbo.servis
SET stanje_servisa = 1, prijem = '" & DatumDTB.Text & "'
 where id_servisa = " & BrojServisaCB.Text & "", baza.konekcija)
            komanda.Connection.Open()
            komanda.ExecuteNonQuery()
            komanda.Connection.Close()
            serv.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class