Imports System.Data.SqlClient
Public Class istorijaProdaje
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        test.Enabled = True
        Me.Dispose()
    End Sub

    Public Sub otvaranjeOtpremnice(brojOtpremnice)
        Try
            Dim command As New SqlCommand("select * from Usluge where otpremnica_br = '" & brojOtpremnice & "'", baza.konekcija)
            Dim adapter As New SqlDataAdapter(command)
            Dim tabela As New DataTable()
            Dim ds As New DataSet()
            adapter.Fill(ds)

            DataGridView1.AutoGenerateColumns = True
            DataGridView1.DataSource = ds.Tables(0)
        Catch

        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        test.Enabled = True
        Me.Dispose()
    End Sub
End Class