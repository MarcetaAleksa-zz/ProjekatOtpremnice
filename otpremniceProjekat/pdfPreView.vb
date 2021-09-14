Public Class pdfPreView
    Private Sub pdfPreView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim appPath As String = My.Application.Info.DirectoryPath + "\15.pdfs"
        ucitavanjaPDFa(appPath)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        otpremnice.pdfPreviewOdgovor = 0
        otpremnice.Enabled = True
        Me.Dispose()
    End Sub

    Public Sub ucitavanjaPDFa(putanja As String)
        WebBrowser1.Navigate(putanja)  'ovde bi isla putanja
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        otpremnice.pdfPreviewOdgovor = 1
    End Sub
End Class