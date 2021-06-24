Public Class formaPrva
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Enabled = False
        dodajArtikal.Show()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
    End Sub
End Class
