Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.Usluge' table. You can move, or remove it, as needed.
        Me.UslugeTableAdapter.Fill(Me.DataSet1.Usluge)

    End Sub
End Class