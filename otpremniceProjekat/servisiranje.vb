Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Drawing
Imports System.Data.SqlClient
Public Class servisiranje
    Private Sub Nazad_Click(sender As Object, e As EventArgs) Handles Nazad.Click
        serv.Show()
        Me.Hide()
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
                        If brojac = 3 Then
                            Dim komanda As New SqlCommand("Insert into Panleksa.dbo.servis (id_servisa, serviser, usluga, otprema_na_naslov, prijem, stanje_servisa)
Values (" & BrojServisaTB.Text & "," & ServiserCB.SelectedIndex + 1 & ", '" & OpisTB.Text & "', '" & OtpremaTB.Text & "', '" & datumtb.Text & "', 0)", baza.konekcija)
                            komanda.Connection.Open()
                            komanda.ExecuteNonQuery()
                            komanda.Connection.Close()
                            brojac = 0
                            serv.Show()
                            Me.Close()

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
        datum = DateTime.Now.ToString("MM/dd/yyyy")
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
End Class