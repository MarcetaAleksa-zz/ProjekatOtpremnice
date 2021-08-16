Public Class Medjuforma
    Private Sub Medjuforma_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub NapraviOtpremnicu_Click(sender As Object, e As EventArgs) Handles NapraviOtpremnicu.Click
        '    Timer1.Enabled = True
        ucitavanje.Show()
        Me.Hide()
    End Sub

    Private Sub DodajRobu_Click(sender As Object, e As EventArgs) Handles DodajRobu.Click
        dodajArtikal.Show()
        Me.Hide()
    End Sub

    Private Sub Administrativno_Click(sender As Object, e As EventArgs) Handles Administrativno.Click
        MsgBox("WORK IN PROGRESS!")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        prijava.Show()
        Me.Dispose()
    End Sub
End Class