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
            'Dim command As New SqlCommand("select inv.naziv_robe, uz.jed_mjere, uz.kolicina, uz.cijena, uz.rabat, uz.iznos  from  Usluge as uz inner join Inventar as inv on (inv.id_robe = uz.naziv_robe) where uz.otpremnica_br = " & brojOtpremnice & "", baza.konekcija)
            '''moj Dim command As New SqlCommand("select Inventar.naziv_robe, Usluge.jed_mjere, Usluge.kolicina, Usluge.cijena, Usluge.rabat, Usluge.iznos  from  Usluge inner join Inventar on (Inventar.id_robe = Usluge.naziv_robe) where Usluge.otpremnica_br = " & brojOtpremnice & "", baza.konekcija) 'izvlacenje u datagridView svih narucenih artikala pod narudzbomID ' ne radi join
            ' Dim command As New SqlCommand("select naziv_robe, jed_mjere, kolicina, cijena, rabat, Iznos  from  Usluge where otpremnica_br = " & brojOtpremnice & "", baza.konekcija) 'izvlacenje u datagridView svih narucenih artikala pod narudzbomID
            Dim command As New SqlCommand("select uz.redni_broj, inv.naziv_robe, uz.jed_mjere, uz.kolicina, uz.cijena, uz.rabat, uz.iznos  from  Panleksa.dbo.Usluge as uz join Panleksa.dbo.Inventar as inv on (inv.id_robe = uz.naziv_robe) where uz.otpremnica_br = " & brojOtpremnice & "", baza.konekcija)
            Dim adapter As New SqlDataAdapter(Command)
            Dim tabela As New DataTable()
            Dim ds As New DataSet()
            adapter.Fill(ds)


            DataGridView1.AutoGenerateColumns = True

            Dim dtCloned As DataSet = ds.Clone()
            dtCloned.Tables(0).Columns(2).DataType = GetType(String)
            For Each Row As DataRow In ds.Tables(0).Rows
                dtCloned.Tables(0).ImportRow(Row)
            Next
            For Each Row As DataRow In dtCloned.Tables(0).Rows
                If (Row.Item(2) = "True") Then
                    Row.Item(2) = "Kolicina"
                ElseIf (Row.Item(2) = "False") Then
                    Row.Item(2) = "Satnica"
                End If

            Next

            DataGridView1.DataSource = dtCloned.Tables(0)
            With DataGridView1
                .RowHeadersVisible = False
                .Columns(0).HeaderCell.Value = "RB"
                .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                .Columns(1).HeaderCell.Value = "NAZIV ROBE"
                .Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
                .Columns(2).HeaderCell.Value = "JED.MJER."
                .Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
                .Columns(3).HeaderCell.Value = "KOLICINA"
                .Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
                .Columns(4).HeaderCell.Value = "CIJENA"
                .Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
                .Columns(5).HeaderCell.Value = "RABAT%"
                .Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
                .Columns(6).HeaderCell.Value = "IZNOS"
                .Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                .Columns(0).HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending
            End With
            DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            Me.DataGridView1.Columns(4).DefaultCellStyle.Format = "n2" 'formatiranje cijene na dvije decimale
            Me.DataGridView1.Columns(6).DefaultCellStyle.Format = "n2" 'formatiranje iznosa na dvije decimale
            Me.DataGridView1.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.DataGridView1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.DataGridView1.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.DataGridView1.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnsMode.Fill
            Me.DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            Me.DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' DataGridView1.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable


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
            Label7.Text = tabela.Rows(0)(7) & " dana"     'reklamacija
            Label4.Text = tabela.Rows(0)(8)     'KUPAC
            Label10.Text = tabela.Rows(0)(9)    'IB kupca
            Label5.Text = tabela.Rows(0)(10)     'adresa kupca

        Catch

        End Try
        ' DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.AutoResizeColumns()
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
                Dim ev As New itsEvents
                pdfWriter.PageEvent = ev



                pdfDoc.Open()
                Dim ptabela As New PdfPTable(7) With { ' generisanje tabele (8) kolona
                .WidthPercentage = 100, '
                .SpacingAfter = 10,
                .SpacingBefore = 10
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
                    If DataGridView1.Rows(noviBrojOpet).Cells(2).Value = "Kolicina" Then
                        jedm = "K"
                    ElseIf DataGridView1.Rows(noviBrojOpet).Cells(2).Value = "Satnica" Then
                        jedm = "H"
                    End If
                    Dim cellthree As New PdfPCell(New Phrase(jedm.ToString, fntTableFont)) With {
                        .HorizontalAlignment = PdfPCell.ALIGN_CENTER,
                    .VerticalAlignment = PdfPCell.ALIGN_CENTER
                    } 'jedinca mjere
                    ptabela.AddCell(cellthree)


                    Dim cellfour As New PdfPCell(New Phrase(DataGridView1.Rows(noviBrojOpet).Cells(3).Value.ToString, fntTableFont)) With {
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


                    Dim iznosDvijeDec = DataGridView1.Rows(noviBrojOpet).Cells(6).Value
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
    Public Class itsEvents
        Inherits PdfPageEventHelper
        Public Overrides Sub OnStartPage(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As iTextSharp.text.Document)

            Dim test As System.Drawing.Image = System.Drawing.Image.FromHbitmap(My.Resources.BANNER.GetHbitmap())
            Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(test, System.Drawing.Imaging.ImageFormat.Png)
            logo.ScaleToFit(595.0F, 40.0F)
            document.Add(logo)
            Dim fntTableFontHdr As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim fntTableFont As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
            Dim datum As New Chunk("                                                                                                    Datum: " + istorijaProdaje.Label8.Text, fntTableFont)
            Dim id As New Chunk("                       ID Otpremnice: " + istorijaProdaje.Label9.Text, fntTableFont)
            Dim lice As New Chunk("Naziv pravnog lica: " + istorijaProdaje.Label1.Text, fntTableFont)
            Dim otprema As New Chunk("                      Nacin otpreme: " + istorijaProdaje.Label6.Text, fntTableFont)
            Dim naziv As New Chunk("                                 Otprema na naslov: " + istorijaProdaje.Label4.Text, fntTableFont)
            Dim ib1 As New Chunk("IB: " + istorijaProdaje.Label3.Text, fntTableFont)
            Dim regTab As New Chunk("                                               Registarske tablice: " + istorijaProdaje.Label11.Text, fntTableFont)
            Dim ib2 As New Chunk("                                  IB: " + istorijaProdaje.Label10.Text, fntTableFont)
            Dim adresa1 As New Chunk("Adresa: " + istorijaProdaje.Label2.Text, fntTableFont)
            Dim reklamacija As New Chunk("                                 Reklamacija: " + istorijaProdaje.Label7.Text, fntTableFont)
            Dim adresa2 As New Chunk("                                                Adresa: " + istorijaProdaje.Label5.Text, fntTableFont)
            document.Add(New Paragraph(""))
            document.Add(id)
            document.Add(datum)
            document.Add(New Paragraph(""))
            document.Add(lice)
            document.Add(otprema)
            document.Add(naziv)
            document.Add(New Paragraph(""))
            document.Add(ib1)
            document.Add(regTab)
            document.Add(ib2)
            document.Add(New Paragraph(""))
            document.Add(adresa1)
            document.Add(reklamacija)
            document.Add(adresa2)
            ' Dim slika As New iTextSharp.text.Image


            'Dim headerTbl = New PdfPTable(4)
            'headerTbl.SetWidths({4, 1})
            'headerTbl.TotalWidth = document.PageSize.Width



            'Dim cell = New PdfPCell(logo)
            'cell.HorizontalAlignment = Element.ALIGN_RIGHT
            'cell.PaddingRight = 20
            'cell.Border = iTextSharp.text.Rectangle.NO_BORDER

        End Sub
    End Class
End Class