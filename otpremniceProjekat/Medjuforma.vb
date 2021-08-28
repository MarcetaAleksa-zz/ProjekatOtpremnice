Public Class Medjuforma

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        prijava.Show()
        prijava.TextBox1.Text = "Unesi korisničko ime ovde"
        prijava.TextBox2.Text = "Unesi lozinku ovde"
        Me.Dispose()
    End Sub

    Private Sub Servis_Click(sender As Object, e As EventArgs) Handles Servis.Click
        serv.Show()

        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        '    Timer1.Enabled = True
        ucitavanje.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        dodajArtikal.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        prijava.Show()
        prijava.TextBox1.Text = "Unesi korisničko ime ovde"
        prijava.TextBox2.Text = "Unesi lozinku ovde"
        prijava.TextBox2.UseSystemPasswordChar = False
        Me.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("WORK IN PROGRESS!")
    End Sub
End Class