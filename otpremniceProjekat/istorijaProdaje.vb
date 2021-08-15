Imports System.Data.SqlClient
Public Class istorijaProdaje
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        test.Enabled = True
        Me.Dispose()
    End Sub

    Public Sub otvaranjeOtpremnice(brojOtpremnice)
        Try
            Dim command As New SqlCommand("select * from Usluge where otpremnica_br = '" & brojOtpremnice & "'", baza.konekcija) 'izvlacenje u datagridView svih narucenih artikala pod narudzbomID
            Dim adapter As New SqlDataAdapter(command)
            Dim tabela As New DataTable()
            Dim ds As New DataSet()
            adapter.Fill(ds)

            DataGridView1.AutoGenerateColumns = True
            DataGridView1.DataSource = ds.Tables(0)
        Catch
        End Try

        Try
            Dim command As New SqlCommand("select * from Osnovne where ID = '" & brojOtpremnice & "'", baza.konekcija) 'izvlacenje svih ostalih informacija pod nadurdzbomID (npr naziv pravnog lica, datum i sl)
            Dim adapter As New SqlDataAdapter(command)
            Dim tabela As New DataTable()
            adapter.Fill(tabela)

            Label1.Text = tabela.Rows(0)(0)     'naziv pravnog lica
            Label2.Text = tabela.Rows(0)(1)     'adresa
            Label3.Text = tabela.Rows(0)(2)     'IB preduzeca
            Label4.Text = tabela.Rows(0)(3)     'KUPAC
            Label5.Text = tabela.Rows(0)(4)     'adresa kupca
            Label6.Text = tabela.Rows(0)(5)     'nacin otrpeme
            Label7.Text = tabela.Rows(0)(6)     'reklamacija
            Label8.Text = tabela.Rows(0)(7)     'datum
            Label9.Text = tabela.Rows(0)(8)     'ID otrpemnice (broj)
            Label10.Text = tabela.Rows(0)(9)    'IB kupca
            Label11.Text = tabela.Rows(0)(10)   'reg_br_vozila

        Catch

        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        test.Enabled = True
        Me.Dispose()
    End Sub

End Class