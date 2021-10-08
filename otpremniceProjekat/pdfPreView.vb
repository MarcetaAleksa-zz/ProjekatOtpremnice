
Imports System.IO
Imports System.Data.SqlClient
Public Class servispdf
    Public biraj = 0
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim com As New SqlCommand("", baza.konekcija)
        Dim odg
        If biraj = 0 Then

            odg = MsgBox("Da li ste sigurni da ne zelite sacuvati otpremnicu?", vbYesNo, "Pregled otpremnice")
            If odg = vbYes Then
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

        ElseIf biraj = 1 Then
            odg = MsgBox("Da li ste sigurni da ne zeline sacuvati izvjestaj sa servisa?", vbYesNo, "Izvjestaj servisa")
            If odg = vbYes Then
                servisiranje.Show()
                servisiranje.Enabled = True
                Me.Dispose()
            End If
        ElseIf biraj = 2 Then
            odg = MsgBox("Da li ste sigurni da ne zelite sacuvati izvjestaj?", vbYesNo, "Izvjestaj")
            If odg = vbYes Then
                pregled.Show()
                pregled.Enabled = True
                Me.Dispose()

            End If
        ElseIf biraj = 3 Then
            odg = MsgBox("Da li ste sigurni da ne zelite sacuvati zavrsen izvjestaj?", vbYesNo, "Izvjestaj zavrsetka servisa")
            If odg = vbYes Then
                isporuka.Show()
                isporuka.Enabled = True
                Me.Dispose()
            End If
        End If
    End Sub

    Public Sub ucitavanjaPDFa(putanja As String)
        servisbrowser.Navigate(putanja)  'ovde bi isla putanja
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If biraj = 0 Then
            MsgBox("Uspjesno ste izdali otpremnicu!", vbOKOnly, "Pregled otpremince")
            otpremnice.Enabled = True
            otpremnice.skiniStanje()
            otpremnice.reset()
            Me.Dispose()
        ElseIf biraj = 1 Then
            servisiranje.Enabled = True
            servisiranje.salji()
            Me.Dispose()
        ElseIf biraj = 2 Then
            pregled.Enabled = True
            pregled.Show()
            Me.Dispose()
        ElseIf biraj = 3 Then
            isporuka.Enabled = True
            isporuka.isporucivanje()
            Me.Dispose()

        End If

        otpremnice.pdfPreviewOdgovor = 1

    End Sub
End Class