Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO




Public Class test
    Private Sub Button_Click(sender As Object, e As EventArgs) Handles snimi.Click
        Dim komanda As New SqlCommand("SELECT ID FROM Osnovne", baza.konekcija)
        Dim adapter As New SqlDataAdapter(komanda)
        Dim tabela As New DataTable
        adapter.Fill(tabela)
        Try
            Dim sfd As New SaveFileDialog With {.Filter = "PDF Files (*.pdf | *.pdfs"}   'Samo mozemo praviti file tipa .pdf, SaveFileDialog nam sluzi za poziv da sacuvamo file
            Dim appPath As String = My.Application.Info.DirectoryPath  ' dobijamo default lokaciju gdje se .exe projekta nalazi
            sfd.FileName = tabela.Rows(0)(0)  'dodjela naziva za .pdf file

            If sfd.ShowDialog = 1 Then

                Dim pdfDoc As New Document(PageSize.A4, 40, 40, 80, 20) 'postavljamo dimenzije naseg .pdf dokumenta
                Dim pdfWriter As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(sfd.FileName, FileMode.Create)) 'snimanje .pdf-a
                Dim fntTableFontHdr As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim fntTableFont As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)


                pdfDoc.Open()



                Dim ptabela As New PdfPTable(7) ' generisanje tabele (8) kolona
                ptabela.WidthPercentage = 100 '
                ptabela.SpacingAfter = 10

                ptabela.HorizontalAlignment = Element.ALIGN_CENTER
                Dim sgltblhdwidth(6) As Single
                sgltblhdwidth(0) = 30
                sgltblhdwidth(1) = 100
                sgltblhdwidth(2) = 30
                sgltblhdwidth(3) = 50
                sgltblhdwidth(4) = 75
                sgltblhdwidth(5) = 75
                sgltblhdwidth(6) = 50
                ptabela.SetWidths(sgltblhdwidth)

                Dim CellOneHdr As New PdfPCell(New Phrase("Red. broj", fntTableFontHdr))
                ptabela.AddCell(CellOneHdr)
                Dim celltwohdr As New PdfPCell(New Phrase("NAZIV ROBE/ USLUGE", fntTableFontHdr))
                ptabela.AddCell(celltwohdr)
                Dim cellthreehdr As New PdfPCell(New Phrase("Jed. mjere", fntTableFontHdr))
                ptabela.AddCell(cellthreehdr)
                Dim cellfourhdr As New PdfPCell(New Phrase("Kolicina", fntTableFontHdr))
                ptabela.AddCell(cellfourhdr)
                Dim cellfivehdr As New PdfPCell(New Phrase("Cijena", fntTableFontHdr))
                ptabela.AddCell(cellfivehdr)
                Dim cellsixhdr As New PdfPCell(New Phrase("Iznos", fntTableFontHdr))
                ptabela.AddCell(cellsixhdr)
                Dim cellsevenhdr As New PdfPCell(New Phrase("Rabat", fntTableFontHdr))
                ptabela.AddCell(cellsevenhdr)


                Dim cellone As New PdfPCell(New Phrase("001", fntTableFont))
                ptabela.AddCell(cellone)
                Dim celltwo As New PdfPCell(New Phrase("RAM", fntTableFont))
                ptabela.AddCell(celltwo)
                Dim cellthree As New PdfPCell(New Phrase("k", fntTableFont))
                ptabela.AddCell(cellthree)
                Dim cellfour As New PdfPCell(New Phrase("1", fntTableFont))
                ptabela.AddCell(cellfour)
                Dim cellfive As New PdfPCell(New Phrase("10", fntTableFont))
                ptabela.AddCell(cellfive)
                Dim cellsix As New PdfPCell(New Phrase("12", fntTableFont))
                ptabela.AddCell(cellsix)
                Dim cellseven As New PdfPCell(New Phrase("0", fntTableFont))
                ptabela.AddCell(cellseven)

                'Dim celloner2 As New PdfPCell(New Phrase("002", fntTableFont))
                'ptabela.AddCell(celloner2)
                'Dim celltwor2 As New PdfPCell(New Phrase("Ubacivanje RAM-a", fntTableFont))
                'ptabela.AddCell(celltwor2)
                'Dim cellthreer2 As New PdfPCell(New Phrase("h", fntTableFont))
                'ptabela.AddCell(cellthreer2)




                pdfDoc.Add(ptabela)
                pdfDoc.Close()




                ' u bloku koda ispod definisemo izgled tabele i njenih kolona/redova

            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try



    End Sub

    Private Sub test_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim command As New SqlCommand("select zaposleni.ime + ' ' + zaposleni.prezime as name from zaposleni", baza.konekcija)
        Dim adapter As New SqlDataAdapter(command)
        Dim tabela As New DataTable()
        Dim ds As New DataSet()
        adapter.Fill(ds)
        Dim brojac As Integer
        ComboBox1.DataSource = ds.Tables(0)
        ComboBox1.ValueMember = "name"
        ComboBox1.DisplayMember = "name"
        Dim datum As Date
        datum = DateTime.Now.ToString("yyyy/MM/dd")
        datumtb.Text = datum
        If brojac = 22 Then
            command.CommandText = "INSERT INTO Osnove (naziv_pravnog_lica, adresa, IB, otpremi_na_naslov, adresa_kupac, nacin_otpreme, reklamacija, datum, ID, IB_kupac, reg_br_vozila_sluzbenog) 
        VALUES ( " & id_lica() & ", '" & adresaTB.Text & "', '" & ibTB.Text & "','" & NaslovTB.Text & "', '" & adresaTB.Text & "'," & OtpremaTB.Text & "," & reklamacijatb.Text & ",'" & datumtb.Text & "'," & otpremnicatb.Text & ",'" & ib2tb.Text & "','" & vozilotb.Text & "')"
            MsgBox("Molimo popunite sva polja")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'If  Then
        '    MsgBox("meh")
        'Else
        '    MessageBox.Show("shew")
        'End If
    End Sub
    Private Function id_lica() As Integer
        Dim command As New SqlCommand("select zaposleni.ime + ' ' + zaposleni.prezime as name from zaposleni", baza.konekcija)
        command.CommandText = "select zaposleni.id from zaposleni where zaposleni.ime + ' ' + zaposleni.prezime  = '" & ComboBox1.SelectedValue & "'"
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)
        id_lica = table.Rows(0)(0)
        Return id_lica
    End Function
End Class