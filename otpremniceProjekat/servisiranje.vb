Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Drawing
Imports System.Data.SqlClient
Public Class servisiranje
    Private Sub Nazad_Click(sender As Object, e As EventArgs) Handles Nazad.Click
        Medjuforma.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

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

        Dim commandBrojOtpremnice As New SqlCommand("select MAX(id_servisa) from servis", baza.konekcija)
        Dim adapterBO As New SqlDataAdapter(commandBrojOtpremnice)
        Dim tabelaBO As New DataTable()
        adapterBO.Fill(tabelaBO)

        BrojServisaTB.Text = tabelaBO.Rows(0)(0) + 1

        Dim datum As Date
        datum = DateTime.Now.ToString("yyyy/MM/dd")
        datumtb.Text = datum
    End Sub

    Private Sub OtpremaTB_TextChanged(sender As Object, e As EventArgs) Handles OtpremaTB.TextChanged

    End Sub
End Class