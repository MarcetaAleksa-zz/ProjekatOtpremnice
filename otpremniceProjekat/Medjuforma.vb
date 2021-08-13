Public Class Medjuforma
    Private Sub Medjuforma_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub NapraviOtpremnicu_Click(sender As Object, e As EventArgs) Handles NapraviOtpremnicu.Click
        test.Show()
        Me.Close()
    End Sub

    Private Sub PregledOtpremnica_Click(sender As Object, e As EventArgs) Handles PregledOtpremnica.Click
        istorijaProdaje.Show()
        Me.Close()
    End Sub

    Private Sub DodajRobu_Click(sender As Object, e As EventArgs) Handles DodajRobu.Click
        dodajArtikal.Show()
        Me.Close()
    End Sub

    Private Sub Administrativno_Click(sender As Object, e As EventArgs) Handles Administrativno.Click
        MsgBox("WORK IN PROGRESS!")
    End Sub
End Class