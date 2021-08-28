Public Class serv
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Medjuforma.Show()
        Me.Hide()
    End Sub

    Private Sub PrijemBT_Click(sender As Object, e As EventArgs) Handles PrijemBT.Click
        servisiranje.Show()
        Me.Hide()
    End Sub

    Private Sub IsporukaBT_Click(sender As Object, e As EventArgs) Handles IsporukaBT.Click
        isporuka.Show()
        Me.Hide()
    End Sub

    Private Sub pregledBT_Click(sender As Object, e As EventArgs) Handles pregledBT.Click
        pregled.Show()
        Me.Hide()
    End Sub
End Class