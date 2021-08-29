Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports System.Drawing
Public Class istorijaProdaje
    Dim ukupno = 0
    Dim saPdv = 0
    Dim bezPdv = 0
    Public Shared comboIzabrani = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        otpremnice.Enabled = True
        Me.Dispose()
    End Sub

    Public Sub otvaranjeOtpremnice(brojOtpremnice)
        Try

            Dim command As New SqlCommand("select uz.redni_broj, inv.naziv_robe, uz.jed_mjere, uz.kolicina, uz.cijena, uz.rabat, uz.iznos  from  Panleksa.dbo.Usluge as uz join Panleksa.dbo.Inventar as inv on (inv.id_robe = uz.naziv_robe) where uz.otpremnica_br = " & brojOtpremnice & "", baza.konekcija)
            Dim adapter As New SqlDataAdapter(command)
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

            Dim command3 As New SqlCommand("select distinct pdv  from  Panleksa.dbo.Usluge where otpremnica_br = " & brojOtpremnice & "", baza.konekcija)
            Dim adapter3 As New SqlDataAdapter(command3)
            Dim tabela3 As New DataTable()
            adapter3.Fill(tabela3)


            Label1.Text = tabela.Rows(0)(0)     'naziv pravnog lica
            Label8.Text = tabela.Rows(0)(1)     'datum
            Label9.Text = tabela.Rows(0)(2)     'ID otrpemnice (broj)
            Label3.Text = tabela.Rows(0)(3)     'IB preduzeca
            Label2.Text = tabela.Rows(0)(4)     'adresa
            Label6.Text = tabela.Rows(0)(5)     'nacin otrpeme
            Label11.Text = tabela.Rows(0)(6)   'reg_br_vozila
            Label7.Text = tabela.Rows(0)(7)      'reklamacija
            If Label7.Text = "21" Then
                Label7.Text = "21 dan"
            Else
                Label7.Text = tabela.Rows(0)(7) & " dana"
            End If
            Label4.Text = tabela.Rows(0)(8)     'KUPAC
            Label10.Text = tabela.Rows(0)(9)    'IB kupca
            Label5.Text = tabela.Rows(0)(10)     'adresa kupca
            Label29.Text = tabela3.Rows(0)(0)
            If Label29.Text = True Then
                Label29.Text = "Da"
            Else
                Label29.Text = "Ne"
            End If
        Catch

        End Try
        ' DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.AutoResizeColumns()
        DataGridView1.Refresh()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        otpremnice.Enabled = True
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
                If comboIzabrani = 0 Then
                    Dim pdfDoc As New Document(PageSize.A4.Rotate, 40, 40, 80, 20) 'postavljamo dimenzije naseg .pdf dokumenta

                    Dim pdfWriter As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(sfd.FileName, FileMode.Create)) 'snimanje .pdf-a
                    Dim fntTableFontHdr As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                    Dim fntTableFont As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
                    Dim ev As New itsEvents
                    pdfWriter.PageEvent = ev



                    pdfDoc.Open()
                    Dim ptabela As New PdfPTable(7) With { ' generisanje tabele (7) kolona
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
                        ukupno += iznosDvijeDec
                        ptabela.AddCell(cellseven)



                        '------------------------------------------------- KRAJ TABELE -------------------------------------------------------------------------------------------

                        'ukupanIznos.Text  'ovo uglaviti na pdf kako bi osoba imala na pdfu koliko je sve kada se sumira
                        '-------------------------------------------------- KRAJ PDF-A -------------------------------------------------------------------------------------------






                        redniBroj += 1 'broj koji se vrti u for petlji i pomjera redove ka dole
                    Next
                    pdfDoc.Add(ptabela)

                    Dim ptabela3 As New PdfPTable(2) With { ' generisanje tabele (7) kolona
                    .WidthPercentage = 13, '
                    .SpacingAfter = 10,
                    .SpacingBefore = 10
                    }
                    ptabela3.HorizontalAlignment = Element.ALIGN_RIGHT
                    Dim sgltblhdwidth3(1) As Single
                    sgltblhdwidth3(0) = 7
                    sgltblhdwidth3(1) = 6
                    ptabela3.SetWidths(sgltblhdwidth3)
                    Dim nazivi As New List(Of String)({"Bez PDV-a:", "PDV:", "Ukupno:"})
                    If Label29.Text = "Da" Then
                        saPdv = ukupno * 0.17
                        bezPdv = ukupno - saPdv
                        saPdv = Format(Val(saPdv), "0.00")
                        bezPdv = Format(Val(bezPdv), "0.00")
                        ukupno = Format(Val(ukupno), "0.00")
                    Else
                        saPdv = 0
                        bezPdv = 0
                        saPdv = Format(Val(saPdv), "0.00")
                        bezPdv = Format(Val(bezPdv), "0.00")
                        ukupno = Format(Val(ukupno), "0.00")
                    End If

                    Dim vrijednosti As New List(Of String)({bezPdv, saPdv, ukupno})

                    For i = 0 To 2
                        Dim cellone As New PdfPCell(New Phrase(nazivi(i), fntTableFontHdr)) With {
                           .VerticalAlignment = PdfPCell.ALIGN_LEFT,
                       .HorizontalAlignment = PdfPCell.ALIGN_LEFT
                       }
                        ptabela3.AddCell(cellone)

                        Dim celltwo As New PdfPCell(New Phrase(vrijednosti(i), fntTableFont)) With {
                           .VerticalAlignment = PdfPCell.ALIGN_RIGHT,
                       .HorizontalAlignment = PdfPCell.ALIGN_RIGHT
                       }
                        ptabela3.AddCell(celltwo)
                    Next
                    pdfDoc.Add(ptabela3)
                    pdfDoc.Close()
                    MsgBox("Uspjesno ste izdali otpremnicu!", vbOKOnly, "Otpremnice")
                Else
                    Dim pdfDoc As New Document(PageSize.A4, 40, 40, 80, 20) 'postavljamo dimenzije naseg .pdf dokumenta
                    Dim pdfWriter As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(sfd.FileName, FileMode.Create)) 'snimanje .pdf-a
                    Dim fntTableFontHdr As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                    Dim fntTableFont As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
                    Dim ev As New itsEvents
                    pdfWriter.PageEvent = ev



                    pdfDoc.Open()
                    Dim ptabela As New PdfPTable(7) With { ' generisanje tabele (7) kolona
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
                        ukupno += iznosDvijeDec
                        ptabela.AddCell(cellseven)



                        '------------------------------------------------- KRAJ TABELE -------------------------------------------------------------------------------------------

                        'ukupanIznos.Text  'ovo uglaviti na pdf kako bi osoba imala na pdfu koliko je sve kada se sumira
                        '-------------------------------------------------- KRAJ PDF-A -------------------------------------------------------------------------------------------






                        redniBroj += 1 'broj koji se vrti u for petlji i pomjera redove ka dole
                    Next
                    pdfDoc.Add(ptabela)

                    Dim ptabela3 As New PdfPTable(2) With { ' generisanje tabele (7) kolona
                    .WidthPercentage = 23, '
                    .SpacingAfter = 10,
                    .SpacingBefore = 10
                    }
                    ptabela3.HorizontalAlignment = Element.ALIGN_RIGHT
                    Dim sgltblhdwidth3(1) As Single
                    sgltblhdwidth3(0) = 12
                    sgltblhdwidth3(1) = 11
                    ptabela3.SetWidths(sgltblhdwidth3)
                    Dim nazivi As New List(Of String)({"Bez PDV-a:", "PDV:", "Ukupno:"})
                    If Label29.Text = "Da" Then
                        saPdv = ukupno * 0.17
                        bezPdv = ukupno - saPdv
                        saPdv = Format(Val(saPdv), "0.00")
                        bezPdv = Format(Val(bezPdv), "0.00")
                        ukupno = Format(Val(ukupno), "0.00")
                    Else
                        saPdv = 0
                        bezPdv = 0
                        saPdv = Format(Val(saPdv), "0.00")
                        bezPdv = Format(Val(bezPdv), "0.00")
                        ukupno = Format(Val(ukupno), "0.00")
                    End If

                    Dim vrijednosti As New List(Of String)({bezPdv, saPdv, ukupno})

                    For i = 0 To 2
                        Dim cellone As New PdfPCell(New Phrase(nazivi(i), fntTableFontHdr)) With {
                           .VerticalAlignment = PdfPCell.ALIGN_LEFT,
                       .HorizontalAlignment = PdfPCell.ALIGN_LEFT
                       }
                        ptabela3.AddCell(cellone)

                        Dim celltwo As New PdfPCell(New Phrase(vrijednosti(i), fntTableFont)) With {
                           .VerticalAlignment = PdfPCell.ALIGN_RIGHT,
                       .HorizontalAlignment = PdfPCell.ALIGN_RIGHT
                       }
                        ptabela3.AddCell(celltwo)
                    Next
                    pdfDoc.Add(ptabela3)
                    pdfDoc.Close()
                    MsgBox("Uspjesno ste izdali otpremnicu!", vbOKOnly, "Otpremnice")
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "GRESKA")
        End Try
    End Sub
    Public Class itsEvents
        Inherits PdfPageEventHelper
        Public Overrides Sub OnStartPage(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As iTextSharp.text.Document)
            If comboIzabrani = 0 Then 'kada je rotirana tj. horizontalna
                Dim test As System.Drawing.Image = System.Drawing.Image.FromHbitmap(My.Resources.BANNER_EXTENDED.GetHbitmap())
                Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(test, System.Drawing.Imaging.ImageFormat.Png)
                logo.ScaleToFit(760.0F, 100.0F)
                logo.WidthPercentage = 100
                document.Add(logo)

                Dim fntTableFontHdr As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim fntTableFont As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
                Dim headerTabela As New PdfPTable(6) With { ' generisanje tabele (8) kolona
                    .WidthPercentage = 100, '
                    .SpacingAfter = 10,
                    .SpacingBefore = 10
                    }
                headerTabela.HorizontalAlignment = Element.ALIGN_LEFT
                Dim sgltblhdwidth(5) As Single
                sgltblhdwidth(0) = 30
                sgltblhdwidth(1) = 45
                sgltblhdwidth(2) = 35
                sgltblhdwidth(3) = 45
                sgltblhdwidth(4) = 35
                sgltblhdwidth(5) = 35

                headerTabela.SetWidths(sgltblhdwidth)

                Dim nazivi As New List(Of String)({"Naziv pravnog lica:", "Nacin otpreme:", "Otprema na naslov:", "IB:", "Registarske tablice:", "IB:", "Adresa:", "Reklamacija:", "Adresa:", "Broj otpremnice:", "PDV:", "Datum:"})
                Dim podaciHeader As New List(Of String)({istorijaProdaje.Label1.Text, istorijaProdaje.Label6.Text, istorijaProdaje.Label4.Text, istorijaProdaje.Label3.Text, istorijaProdaje.Label11.Text, istorijaProdaje.Label10.Text, istorijaProdaje.Label2.Text, istorijaProdaje.Label7.Text, istorijaProdaje.Label5.Text, istorijaProdaje.Label9.Text, istorijaProdaje.Label29.Text, istorijaProdaje.Label8.Text})

                For i = 0 To 11
                    Dim CellOneHdr As New PdfPCell(New Phrase(nazivi(i), fntTableFontHdr)) With {
                        .VerticalAlignment = PdfPCell.ALIGN_RIGHT,
                    .HorizontalAlignment = PdfPCell.ALIGN_RIGHT,
                    .Border = iTextSharp.text.Rectangle.NO_BORDER
                        }
                    headerTabela.AddCell(CellOneHdr)



                    Dim celltwohdr As New PdfPCell(New Phrase(podaciHeader(i), fntTableFont)) With {
                        .VerticalAlignment = PdfPCell.ALIGN_LEFT,
                    .HorizontalAlignment = PdfPCell.ALIGN_LEFT,
                    .Border = iTextSharp.text.Rectangle.NO_BORDER
                        }
                    headerTabela.AddCell(celltwohdr)

                Next
                document.Add(headerTabela)

            ElseIf comboIzabrani = 1 Then 'kada nije rotirana
                Dim test As System.Drawing.Image = System.Drawing.Image.FromHbitmap(My.Resources.BANNER.GetHbitmap())
                Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(test, System.Drawing.Imaging.ImageFormat.Png)
                logo.ScaleToFit(595.0F, 40.0F)
                logo.WidthPercentage = 100
                document.Add(logo)


                Dim fntTableFontHdr As iTextSharp.text.Font = FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim fntTableFont As iTextSharp.text.Font = FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
                Dim headerTabela As New PdfPTable(6) With { ' generisanje tabele (8) kolona
                    .WidthPercentage = 100, '
                    .SpacingAfter = 10,
                    .SpacingBefore = 10
                    }
                headerTabela.HorizontalAlignment = Element.ALIGN_LEFT
                Dim sgltblhdwidth(5) As Single
                sgltblhdwidth(0) = 30
                sgltblhdwidth(1) = 45
                sgltblhdwidth(2) = 35
                sgltblhdwidth(3) = 45
                sgltblhdwidth(4) = 35
                sgltblhdwidth(5) = 35

                headerTabela.SetWidths(sgltblhdwidth)

                Dim nazivi As New List(Of String)({"Naziv pravnog lica:", "Nacin otpreme:", "Otprema na naslov:", "IB:", "Registarske tablice:", "IB:", "Adresa:", "Reklamacija:", "Adresa:", "Broj otpremnice:", "PDV:", "Datum:"})
                Dim podaciHeader As New List(Of String)({istorijaProdaje.Label1.Text, istorijaProdaje.Label6.Text, istorijaProdaje.Label4.Text, istorijaProdaje.Label3.Text, istorijaProdaje.Label11.Text, istorijaProdaje.Label10.Text, istorijaProdaje.Label2.Text, istorijaProdaje.Label7.Text, istorijaProdaje.Label5.Text, istorijaProdaje.Label9.Text, istorijaProdaje.Label29.Text, istorijaProdaje.Label8.Text})

                For i = 0 To 11
                    Dim CellOneHdr As New PdfPCell(New Phrase(nazivi(i), fntTableFontHdr)) With {
                        .VerticalAlignment = PdfPCell.ALIGN_RIGHT,
                    .HorizontalAlignment = PdfPCell.ALIGN_RIGHT,
                    .Border = iTextSharp.text.Rectangle.NO_BORDER
                        }
                    headerTabela.AddCell(CellOneHdr)



                    Dim celltwohdr As New PdfPCell(New Phrase(podaciHeader(i), fntTableFont)) With {
                        .VerticalAlignment = PdfPCell.ALIGN_LEFT,
                    .HorizontalAlignment = PdfPCell.ALIGN_LEFT,
                    .Border = iTextSharp.text.Rectangle.NO_BORDER
                        }
                    headerTabela.AddCell(celltwohdr)

                Next
                document.Add(headerTabela)

            End If


        End Sub
    End Class

    Private Sub istorijaProdaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        comboIzabrani = ComboBox1.SelectedIndex
    End Sub
End Class