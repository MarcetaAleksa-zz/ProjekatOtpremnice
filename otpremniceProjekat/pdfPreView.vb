
Imports System.IO
Imports System.Data.SqlClient
Public Class pdfPreView
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim com As New SqlCommand("", baza.konekcija)

        Dim odg
        odg = MsgBox("Da li ste sigurni da ne zelite sacuvati otpremnicu?", vbYesNo, "Pregled otpremnice")
        If odg = vbYes Then
            otpremnice.ukupanIznos.Text = 0
            otpremnice.ukupno = 0
            com.Connection.Open()
            com.CommandText = "DELETE from Osnovne where id = " + otpremnice.brojOtpremniceZaPdfPreView.ToString() + ";
            DELETE from Usluge where otpremnica_br = " + otpremnice.brojOtpremniceZaPdfPreView.ToString() + ";"
            com.ExecuteNonQuery()
            com.Connection.Close()
            otpremnice.Enabled = True
            Me.Dispose()
        ElseIf odg = vbNo Then


        End If
    End Sub

    Public Sub ucitavanjaPDFa(putanja As String)
        WebBrowser1.Navigate(putanja)  'ovde bi isla putanja
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        MsgBox("Uspjesno ste izdali otpremnicu!", vbOKOnly, "Pregled otpremince")
        otpremnice.Enabled = True
        otpremnice.reset()
        Me.Dispose()

        otpremnice.pdfPreviewOdgovor = 1

    End Sub
End Class