Public Class AdminIzbor
    Private Sub DodajRadnikaBT_Click(sender As Object, e As EventArgs) Handles DodajRadnikaBT.Click
        DodajRadnika.Show()
        Me.Dispose()
    End Sub

    Private Sub IzbrisiIzmjeniRadnikaTB_Click(sender As Object, e As EventArgs) Handles IzbrisiIzmjeniRadnikaTB.Click
        IzmjeniIzbrisiRadnika.Show()
        Me.Dispose()
    End Sub

    Private Sub NazadBT_Click(sender As Object, e As EventArgs) Handles NazadBT.Click
        Medjuforma.Show()
        Me.Dispose()
    End Sub
End Class