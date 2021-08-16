Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports System.Drawing
Public Class istorijaProdaje
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        test.Enabled = True
        Me.Dispose()
    End Sub

    Public Sub otvaranjeOtpremnice(brojOtpremnice)
        Try
            Dim command As New SqlCommand("select * from Usluge where otpremnica_br = '" & brojOtpremnice & "'", baza.konekcija) 'izvlacenje u datagridView svih narucenih artikala pod narudzbomID
            Dim adapter As New SqlDataAdapter(command)
            Dim tabela As New DataTable()
            Dim ds As New DataSet()
            adapter.Fill(ds)

            DataGridView1.AutoGenerateColumns = True
            DataGridView1.DataSource = ds.Tables(0)
        Catch
        End Try

        Try
            Dim command As New SqlCommand("select * from Osnovne where ID = '" & brojOtpremnice & "'", baza.konekcija) 'izvlacenje svih ostalih informacija pod nadurdzbomID (npr naziv pravnog lica, datum i sl)
            Dim adapter As New SqlDataAdapter(command)
            Dim tabela As New DataTable()
            adapter.Fill(tabela)

            Label1.Text = tabela.Rows(0)(0)     'naziv pravnog lica
            Label2.Text = tabela.Rows(0)(1)     'adresa
            Label3.Text = tabela.Rows(0)(2)     'IB preduzeca
            Label4.Text = tabela.Rows(0)(3)     'KUPAC
            Label5.Text = tabela.Rows(0)(4)     'adresa kupca
            Label6.Text = tabela.Rows(0)(5)     'nacin otrpeme
            Label7.Text = tabela.Rows(0)(6)     'reklamacija
            Label8.Text = tabela.Rows(0)(7)     'datum
            Label9.Text = tabela.Rows(0)(8)     'ID otrpemnice (broj)
            Label10.Text = tabela.Rows(0)(9)    'IB kupca
            Label11.Text = tabela.Rows(0)(10)   'reg_br_vozila

        Catch

        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        test.Enabled = True
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim komanda As New SqlCommand("SELECT MAX(ID) FROM Osnovne", baza.konekcija)
        Dim adapter As New SqlDataAdapter(komanda)
        Dim tabela As New DataTable
        adapter.Fill(tabela)

        '-------------------------------------------------------- POCETAK PDF-A -------------------------------------------------------------------------------------------
        Try


            Dim sfd As New SaveFileDialog With {.Filter = "PDF Files (*.pdf | *.pdfs"}   'Samo mozemo praviti file tipa .pdf, SaveFileDialog nam sluzi za poziv da sacuvamo file
            Dim appPath As String = My.Application.Info.DirectoryPath  ' dobijamo default lokaciju gdje se .exe projekta nalazi
            sfd.FileName = Label9.Text + " " + Label1.Text 'dodjela naziva za .pdf file

            If sfd.ShowDialog = 1 Then
                Dim pdfDoc As New Document(PageSize.A4, 40, 40, 80, 20) 'postavljamo dimenzije naseg .pdf dokumenta
                Dim pdfWriter As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(sfd.FileName, FileMode.Create)) 'snimanje .pdf-a
                Dim fntTableFontHdr As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim fntTableFont As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)


                pdfDoc.Open()


                Dim ptabela As New PdfPTable(7) With { ' generisanje tabele (8) kolona
                .WidthPercentage = 100, '
                .SpacingAfter = 10
                }
                ptabela.HorizontalAlignment = Element.ALIGN_CENTER
                Dim sgltblhdwidth(6) As Single
                sgltblhdwidth(0) = 13
                sgltblhdwidth(1) = 120
                sgltblhdwidth(2) = 36
                sgltblhdwidth(3) = 35
                sgltblhdwidth(4) = 21
                sgltblhdwidth(5) = 25
                sgltblhdwidth(6) = 65
                ptabela.SetWidths(sgltblhdwidth)
                '------------------------------------------------- POCETAK TABELE -------------------------------------------------------------------------------------------
                Dim CellOneHdr As New PdfPCell(New Phrase("BR", fntTableFontHdr)) With {
                    .VerticalAlignment = PdfPCell.ALIGN_CENTER,
                .HorizontalAlignment = PdfPCell.ALIGN_CENTER
                    }

                ptabela.AddCell(CellOneHdr)
                Dim celltwohdr As New PdfPCell(New Phrase("NAZIV USLUGE/ROBE", fntTableFontHdr))
                ptabela.AddCell(celltwohdr)

                Dim cellthreehdr As New PdfPCell(New Phrase("JED. MJER.", fntTableFontHdr)) With {
                    .VerticalAlignment = PdfPCell.ALIGN_CENTER,
                .HorizontalAlignment = PdfPCell.ALIGN_CENTER
                }
                ptabela.AddCell(cellthreehdr)

                Dim cellfourhdr As New PdfPCell(New Phrase("KOLICINA", fntTableFontHdr)) With {
                .VerticalAlignment = PdfPCell.ALIGN_CENTER, .HorizontalAlignment = PdfPCell.ALIGN_CENTER
                }
                ptabela.AddCell(cellfourhdr)

                Dim cellfivehdr As New PdfPCell(New Phrase("CIJENA", fntTableFontHdr)) With {
                    .VerticalAlignment = PdfPCell.ALIGN_CENTER,
                .HorizontalAlignment = PdfPCell.ALIGN_CENTER
                }
                ptabela.AddCell(cellfivehdr)

                Dim cellsixhdr As New PdfPCell(New Phrase("RABAT", fntTableFontHdr)) With {
                    .VerticalAlignment = PdfPCell.ALIGN_CENTER,
                .HorizontalAlignment = PdfPCell.ALIGN_CENTER
                }
                ptabela.AddCell(cellsixhdr)

                Dim cellsevenhdr As New PdfPCell(New Phrase("IZNOS", fntTableFontHdr)) With {
                    .VerticalAlignment = PdfPCell.ALIGN_RIGHT,
                .HorizontalAlignment = PdfPCell.ALIGN_RIGHT
                }
                ptabela.AddCell(cellsevenhdr)

                Dim noviBrojOpet = 0
                Dim redniBroj = 1
                For noviBrojOpet = 0 To DataGridView1.RowCount - 2

                    Dim cellone As New PdfPCell(New Phrase(redniBroj.ToString, fntTableFont)) With {
                        .VerticalAlignment = PdfPCell.ALIGN_CENTER,
                    .HorizontalAlignment = PdfPCell.ALIGN_CENTER
                    } 'redni broj
                    ptabela.AddCell(cellone)

                    Dim celltwo As New PdfPCell(New Phrase(DataGridView1.Rows(noviBrojOpet).Cells(1).Value, fntTableFont)) 'naziv usluge
                    ptabela.AddCell(celltwo)

                    Dim jedm
                    If DataGridView1.Rows(noviBrojOpet).Cells(2).Value = True Then
                        jedm = "K"
                    ElseIf DataGridView1.Rows(noviBrojOpet).Cells(2).Value = False Then
                        jedm = "H"
                    End If
                    Dim cellthree As New PdfPCell(New Phrase(jedm.ToString, fntTableFont)) With {
                        .HorizontalAlignment = PdfPCell.ALIGN_CENTER,
                    .VerticalAlignment = PdfPCell.ALIGN_CENTER
                    } 'jedinca mjere
                    ptabela.AddCell(cellthree)


                    Dim cellfour As New PdfPCell(New Phrase(DataGridView1.Rows(noviBrojOpet).Cells(3).Value, fntTableFont)) With {
                        .HorizontalAlignment = PdfPCell.ALIGN_CENTER,
                    .VerticalAlignment = PdfPCell.ALIGN_CENTER
                    } 'kolicina
                    ptabela.AddCell(cellfour)

                    '                            Dim cijenaKontrol As Control = TableLayoutPanel1.GetControlFromPosition(kaDesno, noviBrojOpet)
                    Dim cijenaDvijeDec = DataGridView1.Rows(noviBrojOpet).Cells(4).Value
                    cijenaDvijeDec = Format(Val(cijenaDvijeDec), "0.00")
                    Dim cellfive As New PdfPCell(New Phrase(cijenaDvijeDec.ToString, fntTableFont)) With {
                        .HorizontalAlignment = PdfPCell.ALIGN_RIGHT,
                    .VerticalAlignment = PdfPCell.ALIGN_RIGHT
                    } 'cijena
                    ptabela.AddCell(cellfive)


                    Dim cellsix As New PdfPCell(New Phrase(DataGridView1.Rows(noviBrojOpet).Cells(5).Value & "%", fntTableFont)) With {
                         .HorizontalAlignment = PdfPCell.ALIGN_CENTER,
                    .VerticalAlignment = PdfPCell.ALIGN_CENTER
                    } 'rabat
                    ptabela.AddCell(cellsix)


                    Dim iznosDvijeDec = DataGridView1.Rows(noviBrojOpet).Cells(8).Value
                    iznosDvijeDec = Format(Val(iznosDvijeDec), "0.00")
                    Dim cellseven As New PdfPCell(New Phrase(iznosDvijeDec, fntTableFont)) With {
.HorizontalAlignment = PdfPCell.ALIGN_RIGHT,
                    .VerticalAlignment = PdfPCell.ALIGN_RIGHT
                    } 'iznos
                    ptabela.AddCell(cellseven)



                    '------------------------------------------------- KRAJ TABELE -------------------------------------------------------------------------------------------




                    'ukupanIznos.Text  'ovo uglaviti na pdf kako bi osoba imala na pdfu koliko je sve kada se sumira
                    '-------------------------------------------------- KRAJ PDF-A -------------------------------------------------------------------------------------------






                    redniBroj += 1 'broj koji se vrti u for petlji i pomjera redove ka dole
                Next
                pdfDoc.Add(ptabela)
                pdfDoc.Close()
                MsgBox("Uspjesno ste izdali otpremnicu!")
            End If


        Catch ex As Exception
        MsgBox(ex.Message, vbCritical)

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim x As Integer
        MsgBox(DataGridView1.Rows(1).Cells(1).Value)
    End Sub
End Class