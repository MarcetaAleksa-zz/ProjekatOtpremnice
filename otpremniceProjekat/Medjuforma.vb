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
        ucitavanje.Show()
        Me.Hide()
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        prijava.Show()
        prijava.reload(e, e)
        prijava.TextBox1.Text = "Unesi korisničko ime ovde"
        prijava.TextBox2.Text = "Unesi lozinku ovde"
        prijava.TextBox2.ForeColor = Color.Gray
        prijava.TextBox1.ForeColor = Color.Gray
        prijava.TextBox2.UseSystemPasswordChar = False
        prijava.pozicija = Nothing
        Hash.HashStorePrijava = Nothing
        Me.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AdminIzbor.Show()
        Me.Hide()
    End Sub

    Private Sub Medjuforma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If prijava.pozicija <> 1 Then
            Button3.Hide()
        Else
            Button3.Show()
        End If
    End Sub

    Private Sub DodajRobu_Click(sender As Object, e As EventArgs) Handles DodajRobu.Click
        dodajArtikal.Show()
        Me.Hide()
    End Sub
End Class