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
            'Dim command As New SqlCommand("select inv.naziv_robe, uz.jed_mjere, uz.kolicina, uz.cijena, uz.rabat, uz.iznos  from  Usluge as uz join Inventar as inv on (inv.id_robe = uz.naziv_robe) where uz.otpremnica_br = " & brojOtpremnice & "", baza.konekcija) 'izvlacenje u datagridView svih narucenih artikala pod narudzbomID ' ne radi join
            Dim command As New SqlCommand("select naziv_robe, jed_mjere, kolicina, cijena, rabat, Iznos  from  Usluge where otpremnica_br = " & brojOtpremnice & "", baza.konekcija) 'izvlacenje u datagridView svih narucenih artikala pod narudzbomID

            Dim adapter As New SqlDataAdapter(Command)
            Dim tabela As New DataTable()
            Dim ds As New DataSet()
            adapter.Fill(ds)

            DataGridView1.AutoGenerateColumns = True

            Dim dtCloned As DataSet = ds.Clone()
            dtCloned.Tables(0).Columns(1).DataType = GetType(String)
            For Each Row As DataRow In ds.Tables(0).Rows
                dtCloned.Tables(0).ImportRow(Row)
            Next
            For Each Row As DataRow In dtCloned.Tables(0).Rows
                If (Row.Item(1) = "True") Then
                    Row.Item(1) = "Kolicina"
                ElseIf (Row.Item(1) = "False") Then
                    Row.Item(1) = "Satnica"
                End If

            Next

            DataGridView1.DataSource = dtCloned.Tables(0)
            Me.DataGridView1.Columns(3).DefaultCellStyle.Format = "n2" 'formatiranje cijene na dvije decimale
            Me.DataGridView1.Columns(5).DefaultCellStyle.Format = "n2" 'formatiranje iznosa na dvije decimale
        Catch
        End Try

        Try
            Dim command As New SqlCommand("declare @x smallint	
set @x = " & brojOtpremnice & "
declare @otprema  varchar(20)
declare @naop smallint
declare @reklamacija smallint
declare @rekl smallint
set @rekl = (select reklamacija from Osnovne where ID = @x)
if @rekl = 1
begin
set @reklamacija = 7
end
else if @rekl = 2
begin
set @reklamacija = 14
end
else if @rekl = 3
begin
set @reklamacija = 21
end
set @naop = (select nacin_otpreme from Osnovne where ID = @x) 
if @naop = 1 
begin
set @otprema = 'Posta'
end
else if @naop  = 2
begin
set @otprema = 'Sluzbeno vozilo'
end
else if @naop = 3
begin 
set @otprema = 'Kupac preuzima'
end
select DISTINCT zaposleni.ime + ' ' + zaposleni.prezime as lice, os.datum, os.ID, os.IB, os.adresa, @otprema as [nacin otpreme], os.reg_br_vozila_sluzbenog, @reklamacija as reklamacija, os.otpremi_na_naslov, os.IB, os.adresa_kupac from  zaposleni join Osnovne as os on (zaposleni.id = naziv_pravnog_lica)  where os.ID = " & brojOtpremnice & ";", baza.konekcija) 'izvlacenje svih ostalih informacija pod nadurdzbomID (npr naziv pravnog lica, datum i sl)
            Dim adapter As New SqlDataAdapter(command)
            Dim tabela As New DataTable()
            adapter.Fill(tabela)

            Label1.Text = tabela.Rows(0)(0)     'naziv pravnog lica
            Label8.Text = tabela.Rows(0)(1)     'datum
            Label9.Text = tabela.Rows(0)(2)     'ID otrpemnice (broj)
            Label3.Text = tabela.Rows(0)(3)     'IB preduzeca
            Label2.Text = tabela.Rows(0)(4)     'adresa
            Label6.Text = tabela.Rows(0)(5)     'nacin otrpeme
            Label11.Text = tabela.Rows(0)(6)   'reg_br_vozila
            Label7.Text = tabela.Rows(0)(7)     'reklamacija
            Label4.Text = tabela.Rows(0)(8)     'KUPAC
            Label10.Text = tabela.Rows(0)(9)    'IB kupca
            Label5.Text = tabela.Rows(0)(10)     'adresa kupca

        Catch

        End Try

        DataGridView1.Refresh()
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
            sfd.FileName = Label9.Text + " " + Label4.Text 'dodjela naziva za .pdf file

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

                    Dim celltwo As New PdfPCell(New Phrase(DataGridView1.Rows(noviBrojOpet).Cells(0).Value, fntTableFont)) 'naziv usluge
                    ptabela.AddCell(celltwo)

                    Dim jedm
                    If DataGridView1.Rows(noviBrojOpet).Cells(1).Value = True Then
                        jedm = "K"
                    ElseIf DataGridView1.Rows(noviBrojOpet).Cells(1).Value = False Then
                        jedm = "H"
                    End If
                    Dim cellthree As New PdfPCell(New Phrase(jedm.ToString, fntTableFont)) With {
                        .HorizontalAlignment = PdfPCell.ALIGN_CENTER,
                    .VerticalAlignment = PdfPCell.ALIGN_CENTER
                    } 'jedinca mjere
                    ptabela.AddCell(cellthree)


                    Dim cellfour As New PdfPCell(New Phrase(DataGridView1.Rows(noviBrojOpet).Cells(2).Value, fntTableFont)) With {
                        .HorizontalAlignment = PdfPCell.ALIGN_CENTER,
                    .VerticalAlignment = PdfPCell.ALIGN_CENTER
                    } 'kolicina
                    ptabela.AddCell(cellfour)

                    '                            Dim cijenaKontrol As Control = TableLayoutPanel1.GetControlFromPosition(kaDesno, noviBrojOpet)
                    Dim cijenaDvijeDec = DataGridView1.Rows(noviBrojOpet).Cells(3).Value
                    cijenaDvijeDec = Format(Val(cijenaDvijeDec), "0.00")
                    Dim cellfive As New PdfPCell(New Phrase(cijenaDvijeDec.ToString, fntTableFont)) With {
                        .HorizontalAlignment = PdfPCell.ALIGN_RIGHT,
                    .VerticalAlignment = PdfPCell.ALIGN_RIGHT
                    } 'cijena
                    ptabela.AddCell(cellfive)


                    Dim cellsix As New PdfPCell(New Phrase(DataGridView1.Rows(noviBrojOpet).Cells(4).Value & "%", fntTableFont)) With {
                         .HorizontalAlignment = PdfPCell.ALIGN_CENTER,
                    .VerticalAlignment = PdfPCell.ALIGN_CENTER
                    } 'rabat
                    ptabela.AddCell(cellsix)


                    Dim iznosDvijeDec = DataGridView1.Rows(noviBrojOpet).Cells(5).Value
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

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim x As Integer
        MsgBox(DataGridView1.Rows(1).Cells(1).Value)
    End Sub

    Private Sub istorijaProdaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting

        If Me.DataGridView1.Columns(e.ColumnIndex).Name.Equals("jed_mjere") = True And Me.DataGridView1.Columns(e.ColumnIndex).Name.Equals("naziv_robe") <> Nothing Then
            If CBool(e.Value) = True Then

                e.Value = "Da"
            Else

                e.Value = "Ne"
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        DataGridView1("jed_mjere", e.RowIndex).Value = Convert.ToBoolean(DataGridView1("jed_mjere", e.RowIndex).Value)
    End Sub
End Class