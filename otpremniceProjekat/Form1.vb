Imports System.Data.SqlClient
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim komanda As New SqlCommand("SELECT * FROM Inventar", baza.konekcija)
        Dim adapter As New SqlDataAdapter(komanda)
        Dim tabela As New DataTable
        adapter.Fill(tabela)
        MessageBox.Show(tabela.Rows(0)(0))
    End Sub
End Class