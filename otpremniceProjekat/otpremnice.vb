Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports System.Drawing

Public Class otpremnice
    Dim ukupno = 0
    Dim saPdv = 0
    Dim bezPdv = 0
    Public Shared comboIzabrani = 0
    Public Shared nazivPL '
    Public Shared brojOtp '
    Public Shared datumOTP '
    Public Shared kupacOTP '
    Public Shared IBFirme
    Public Shared nacinOtp
    Public Shared reklamacijeOTP
    Public Shared PDVOTP
    Public Shared IBKupca
    Public Shared adresaFirme
    Public Shared adresaKupca
    Public Shared regBrOTP
    Dim novoI As Integer = 0 'KORISTIMO ZA DINAMICKO DODAVANJE OBJEKATA I VEOMA JE VAZNO!
    Dim brojDodanih As String = 0 'jos nije utvrdjeno cemu sluzi..
    Dim sveOkej As Integer = 0 'KORISTIMO ZA PROVJERU DA LI JE USPJESNO UNIJELO U BAZU I IZRADILO PDF, AKO JE SVE OKEJ OVA VARIABLA CE NATJERATI PROGRAM DA SE PONOVO UCITA
    Dim brojacSvihPolja As Integer = 0 'KORISTIMO ZA PROVJERU PRIJE OBRADE PODATAKA DA LI JE SVE UNESENO

    Private Sub Button_Click(sender As Object, e As EventArgs) Handles snimi.Click

        brojacSvihPolja = 0
        If ComboBox1.SelectedIndex <> -1 Then 'naziv pravnog lica
            brojacSvihPolja += 1
            If NaslovTB.Text <> "" Then ' kupac
                brojacSvihPolja += 1
                If iBKupcaComboBox.Text <> "" Then 'IB KUPCA
                    brojacSvihPolja += 1
                    If kupacAdresaComboBox.Text <> "" Then
                        brojacSvihPolja += 1
                        If vozilotb.Text <> "" Then
                            brojacSvihPolja += 1
                            If ukupanIznos.Text <> "00.00" Then
                                brojacSvihPolja += 1
                            Else
                                ' MsgBox("Nema izabranih artikala!")
                                brojacSvihPolja = 0
                            End If
                        Else
                            '      MsgBox("Izaberite naziv pravnog lica!")
                            brojacSvihPolja = 0
                        End If
                    Else
                        '     MsgBox("Unesite adresu kupca!")
                        brojacSvihPolja = 0
                    End If
                Else
                    '   MsgBox("Unesite IB kupca!")
                    brojacSvihPolja = 0
                End If
            Else
                '   MsgBox("Unesite kupca!")
                brojacSvihPolja = 0
            End If
        Else
            '    MsgBox("Izaberite naziv pravnog lica!")
            brojacSvihPolja = 0
        End If

        If brojacSvihPolja = 6 Then
            Dim komanda As New SqlCommand("SELECT MAX(ID) FROM Osnovne", baza.konekcija)
            Dim adapter As New SqlDataAdapter(komanda)
            Dim tabela As New DataTable
            adapter.Fill(tabela)

            '-------------------------------------------------------- POCETAK PDF-A -------------------------------------------------------------------------------------------
            Try
                kupacOTP = NaslovTB.Text
                datumOTP = datumtb.Text
                brojOtp = brotpremniceTxt.Text
                nazivPL = ComboBox1.Text
                IBFirme = ibTB.Text
                nacinOtp = OtpremaTB.Text
                reklamacijeOTP = reklamacijatb.Text
                If reklamacijeOTP.ToString = "21" Then
                    reklamacijeOTP = "21 dan"
                Else
                    reklamacijeOTP = reklamacijatb.Text & " dana"
                End If
                PDVOTP = ComboBox10.Text
                IBKupca = iBKupcaComboBox.Text
                adresaFirme = adresaTB.Text
                adresaKupca = kupacAdresaComboBox.Text
                regBrOTP = vozilotb.Text

                Dim sfd As New SaveFileDialog With {.Filter = "PDF Files (*.pdf | *.pdfs"}   'Samo mozemo praviti file tipa .pdf, SaveFileDialog nam sluzi za poziv da sacuvamo file
                Dim appPath As String = My.Application.Info.DirectoryPath  ' dobijamo default lokaciju gdje se .exe projekta nalazi
                sfd.FileName = (tabela.Rows(0)(0) + 1).ToString + " " + NaslovTB.Text 'dodjela naziva za .pdf file

                If sfd.ShowDialog = 1 Then
                    sveOkej = 0
                    If comboIzabrani = 0 Then
                        Dim pdfDoc As New Document(PageSize.A4.Rotate, 40, 40, 80, 20) 'postavljamo dimenzije naseg .pdf dokumenta
                        Dim pdfWriter As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(sfd.FileName, FileMode.Create)) 'snimanje .pdf-a
                        Dim fntTableFontHdr As iTextSharp.text.Font = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                        Dim fntTableFont As iTextSharp.text.Font = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
                        Dim ev As New itsEvents
                        pdfWriter.PageEvent = ev

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
                        For noviBrojOpet = 0 To TableLayoutPanel1.RowCount - 1
                            Dim kaDesno = 1
                            Dim Naziv As Control = TableLayoutPanel1.GetControlFromPosition(kaDesno, noviBrojOpet)
                            Dim cmbxx As New ComboBox
                            cmbxx = Naziv
                            Try
                                If cmbxx Is Nothing Then
                                ElseIf cmbxx.Text <> "" Then

                                    Dim cellone As New PdfPCell(New Phrase(redniBroj.ToString, fntTableFont)) With {
                                    .VerticalAlignment = PdfPCell.ALIGN_CENTER,
                                .HorizontalAlignment = PdfPCell.ALIGN_CENTER
                                } 'redni broj
                                    ptabela.AddCell(cellone)
                                    Dim celltwo As New PdfPCell(New Phrase(cmbxx.Text, fntTableFont)) 'naziv usluge
                                    ptabela.AddCell(celltwo)
                                    kaDesno += 1

                                    Dim jedinicaMjere As Control = TableLayoutPanel1.GetControlFromPosition(kaDesno, noviBrojOpet)
                                    Dim cellthree As New PdfPCell(New Phrase(jedinicaMjere.Text, fntTableFont)) With {
                                    .HorizontalAlignment = PdfPCell.ALIGN_CENTER,
                                .VerticalAlignment = PdfPCell.ALIGN_CENTER
                                } 'jedinca mjere
                                    ptabela.AddCell(cellthree)
                                    kaDesno += 1
                                    Dim kolicinaKontrol As Control = TableLayoutPanel1.GetControlFromPosition(kaDesno, noviBrojOpet)
                                    Dim cellfour As New PdfPCell(New Phrase(kolicinaKontrol.Text, fntTableFont)) With {
                                    .HorizontalAlignment = PdfPCell.ALIGN_CENTER,
                                .VerticalAlignment = PdfPCell.ALIGN_CENTER
                                } 'kolicina
                                    ptabela.AddCell(cellfour)
                                    kaDesno += 1
                                    Dim cijenaKontrol As Control = TableLayoutPanel1.GetControlFromPosition(kaDesno, noviBrojOpet)
                                    Dim cellfive As New PdfPCell(New Phrase(cijenaKontrol.Text, fntTableFont)) With {
                                    .HorizontalAlignment = PdfPCell.ALIGN_RIGHT,
                                .VerticalAlignment = PdfPCell.ALIGN_RIGHT
                                } 'cijena
                                    ptabela.AddCell(cellfive)
                                    kaDesno += 1
                                    Dim rabatKontrol As Control = TableLayoutPanel1.GetControlFromPosition(kaDesno, noviBrojOpet)
                                    Dim cellsix As New PdfPCell(New Phrase(rabatKontrol.Text & "%", fntTableFont)) With {
                                     .HorizontalAlignment = PdfPCell.ALIGN_CENTER,
                                .VerticalAlignment = PdfPCell.ALIGN_CENTER
                                } 'rabat
                                    ptabela.AddCell(cellsix)
                                    kaDesno += 1
                                    Dim iznosKontrol As Control = TableLayoutPanel1.GetControlFromPosition(kaDesno, noviBrojOpet)
                                    Dim cellseven As New PdfPCell(New Phrase(iznosKontrol.Text, fntTableFont)) With {
    .HorizontalAlignment = PdfPCell.ALIGN_RIGHT,
                                .VerticalAlignment = PdfPCell.ALIGN_RIGHT
                                } 'iznos
                                    '------------------------------------------------- KRAJ TABELE -------------------------------------------------------------------------------------------




                                    'ukupanIznos.Text  'ovo uglaviti na pdf kako bi osoba imala na pdfu koliko je sve kada se sumira
                                    '-------------------------------------------------- KRAJ PDF-A -------------------------------------------------------------------------------------------


                                    ptabela.AddCell(cellseven)
                                    ukupno += CDbl(TryCast(iznosKontrol, TextBox).Text)
                                    Dim jedm As Boolean
                                    If jedinicaMjere.Text = "K" Then
                                        jedm = True
                                    ElseIf jedinicaMjere.Text = "H" Then
                                        jedm = False
                                    End If


                                    Dim kommanden As New SqlCommand("
declare @y smallint
set @y = (Select id_robe from Inventar where naziv_robe = '" & cmbxx.Text & "')
INSERT INTO Usluge (redni_broj, naziv_robe, jed_mjere, kolicina, cijena, rabat, pdv, otpremnica_br)
                            Values(" & redniBroj.ToString & ", @y, '" & jedm & "'," & kolicinaKontrol.Text & ", " & cijenaKontrol.Text & ", " & rabatKontrol.Text & "," & ComboBox10.SelectedIndex & ", " & brotpremniceTxt.Text & ");
                            declare @x as bit
set @x = (select jed_mjere from Inventar where naziv_robe = '" & cmbxx.Text & "')
if @x = 1
begin

                            declare @jeste int
set @jeste = (SELECT kolicina from Panleksa.dbo.Inventar where naziv_robe = '" & cmbxx.Text & "')
UPDATE Panleksa.dbo.Inventar 
SET kolicina = (@jeste - " & kolicinaKontrol.Text & ")
Where naziv_robe = '" & cmbxx.Text & "'
end", baza.konekcija)
                                    kommanden.Connection.Open()
                                    kommanden.ExecuteNonQuery()
                                    kommanden.Connection.Close()
                                    redniBroj += 1
                                End If
                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                            End Try
                        Next
                        Dim command As New SqlCommand("INSERT INTO Panleksa.dbo.Osnovne (naziv_pravnog_lica, adresa, IB, otpremi_na_naslov, adresa_kupac, nacin_otpreme, reklamacija, datum, ID, IB_kupac, reg_br_vozila_sluzbenog)
                            VALUES ( " & id_lica() & ", '" & adresaTB.Text & "', '" & ibTB.Text & "','" & NaslovTB.Text & "', '" & kupacAdresaComboBox.Text & "'," & OtpremaTB.SelectedIndex + 1 & "," & reklamacijatb.SelectedIndex + 1 & ",'" & datumtb.Text & "'," & brotpremniceTxt.Text & ",'" & iBKupcaComboBox.Text & "','" & vozilotb.Text & "');", baza.konekcija)
                        command.Connection.Open()
                        command.ExecuteNonQuery()
                        command.Connection.Close()
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
                        If PDVOTP = "Da" Then
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
                        sveOkej = 1
                    Else
                        Dim pdfDoc As New Document(PageSize.A4, 40, 40, 80, 20) 'postavljamo dimenzije naseg .pdf dokumenta
                        Dim pdfWriter As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(sfd.FileName, FileMode.Create)) 'snimanje .pdf-a
                        Dim fntTableFontHdr As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                        Dim fntTableFont As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
                        Dim ev As New itsEvents
                        pdfWriter.PageEvent = ev

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
                        For noviBrojOpet = 0 To TableLayoutPanel1.RowCount - 1
                            Dim kaDesno = 1
                            Dim Naziv As Control = TableLayoutPanel1.GetControlFromPosition(kaDesno, noviBrojOpet)
                            Dim cmbxx As New ComboBox
                            cmbxx = Naziv
                            Try
                                If cmbxx Is Nothing Then
                                ElseIf cmbxx.Text <> "" Then

                                    Dim cellone As New PdfPCell(New Phrase(redniBroj.ToString, fntTableFont)) With {
                                    .VerticalAlignment = PdfPCell.ALIGN_CENTER,
                                .HorizontalAlignment = PdfPCell.ALIGN_CENTER
                                } 'redni broj
                                    ptabela.AddCell(cellone)
                                    Dim celltwo As New PdfPCell(New Phrase(cmbxx.Text, fntTableFont)) 'naziv usluge
                                    ptabela.AddCell(celltwo)
                                    kaDesno += 1

                                    Dim jedinicaMjere As Control = TableLayoutPanel1.GetControlFromPosition(kaDesno, noviBrojOpet)
                                    Dim cellthree As New PdfPCell(New Phrase(jedinicaMjere.Text, fntTableFont)) With {
                                    .HorizontalAlignment = PdfPCell.ALIGN_CENTER,
                                .VerticalAlignment = PdfPCell.ALIGN_CENTER
                                } 'jedinca mjere
                                    ptabela.AddCell(cellthree)
                                    kaDesno += 1
                                    Dim kolicinaKontrol As Control = TableLayoutPanel1.GetControlFromPosition(kaDesno, noviBrojOpet)
                                    Dim cellfour As New PdfPCell(New Phrase(kolicinaKontrol.Text, fntTableFont)) With {
                                    .HorizontalAlignment = PdfPCell.ALIGN_CENTER,
                                .VerticalAlignment = PdfPCell.ALIGN_CENTER
                                } 'kolicina
                                    ptabela.AddCell(cellfour)
                                    kaDesno += 1
                                    Dim cijenaKontrol As Control = TableLayoutPanel1.GetControlFromPosition(kaDesno, noviBrojOpet)
                                    Dim cellfive As New PdfPCell(New Phrase(cijenaKontrol.Text, fntTableFont)) With {
                                    .HorizontalAlignment = PdfPCell.ALIGN_RIGHT,
                                .VerticalAlignment = PdfPCell.ALIGN_RIGHT
                                } 'cijena
                                    ptabela.AddCell(cellfive)
                                    kaDesno += 1
                                    Dim rabatKontrol As Control = TableLayoutPanel1.GetControlFromPosition(kaDesno, noviBrojOpet)
                                    Dim cellsix As New PdfPCell(New Phrase(rabatKontrol.Text & "%", fntTableFont)) With {
                                     .HorizontalAlignment = PdfPCell.ALIGN_CENTER,
                                .VerticalAlignment = PdfPCell.ALIGN_CENTER
                                } 'rabat
                                    ptabela.AddCell(cellsix)
                                    kaDesno += 1
                                    Dim iznosKontrol As Control = TableLayoutPanel1.GetControlFromPosition(kaDesno, noviBrojOpet)
                                    Dim cellseven As New PdfPCell(New Phrase(iznosKontrol.Text, fntTableFont)) With {
    .HorizontalAlignment = PdfPCell.ALIGN_RIGHT,
                                .VerticalAlignment = PdfPCell.ALIGN_RIGHT
                                } 'iznos
                                    '------------------------------------------------- KRAJ TABELE -------------------------------------------------------------------------------------------




                                    'ukupanIznos.Text  'ovo uglaviti na pdf kako bi osoba imala na pdfu koliko je sve kada se sumira
                                    '-------------------------------------------------- KRAJ PDF-A -------------------------------------------------------------------------------------------


                                    ptabela.AddCell(cellseven)
                                    ukupno += CDbl(TryCast(iznosKontrol, TextBox).Text)
                                    Dim jedm As Boolean
                                    If jedinicaMjere.Text = "K" Then
                                        jedm = True
                                    ElseIf jedinicaMjere.Text = "H" Then
                                        jedm = False
                                    End If


                                    Dim kommanden As New SqlCommand("
declare @y smallint
set @y = (Select id_robe from Inventar where naziv_robe = '" & cmbxx.Text & "')
INSERT INTO Usluge (redni_broj, naziv_robe, jed_mjere, kolicina, cijena, rabat, pdv, otpremnica_br)
                            Values(" & redniBroj.ToString & ", @y, '" & jedm & "'," & kolicinaKontrol.Text & ", " & cijenaKontrol.Text & ", " & rabatKontrol.Text & "," & ComboBox10.SelectedIndex & ", " & brotpremniceTxt.Text & ");
                            declare @x as bit
set @x = (select jed_mjere from Inventar where naziv_robe = '" & cmbxx.Text & "')
if @x = 1
begin

                            declare @jeste int
set @jeste = (SELECT kolicina from Panleksa.dbo.Inventar where naziv_robe = '" & cmbxx.Text & "')
UPDATE Panleksa.dbo.Inventar 
SET kolicina = (@jeste - " & kolicinaKontrol.Text & ")
Where naziv_robe = '" & cmbxx.Text & "'
end", baza.konekcija)
                                    kommanden.Connection.Open()
                                    kommanden.ExecuteNonQuery()
                                    kommanden.Connection.Close()
                                    redniBroj += 1
                                End If
                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                            End Try
                        Next
                        Dim command As New SqlCommand("INSERT INTO Panleksa.dbo.Osnovne (naziv_pravnog_lica, adresa, IB, otpremi_na_naslov, adresa_kupac, nacin_otpreme, reklamacija, datum, ID, IB_kupac, reg_br_vozila_sluzbenog)
                            VALUES ( " & id_lica() & ", '" & adresaTB.Text & "', '" & ibTB.Text & "','" & NaslovTB.Text & "', '" & kupacAdresaComboBox.Text & "'," & OtpremaTB.SelectedIndex + 1 & "," & reklamacijatb.SelectedIndex + 1 & ",'" & datumtb.Text & "'," & brotpremniceTxt.Text & ",'" & iBKupcaComboBox.Text & "','" & vozilotb.Text & "');", baza.konekcija)
                        command.Connection.Open()
                        command.ExecuteNonQuery()
                        command.Connection.Close()
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
                        If PDVOTP = "Da" Then
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

                        sveOkej = 1
                    End If
                    MsgBox("Uspjesno ste izdali otpremnicu!")
                Else

                End If

            Catch ex As Exception
                MsgBox(ex.Message, vbCritical)

            End Try
            If sveOkej = 1 Then
                novoI = 0
                ucitavanje.Show()
                Me.Dispose()
            Else
                MsgBox("Desila se greska sa bazom!")
            End If
        Else
            MsgBox("Popunite sva polja!")
        End If

    End Sub
    Public Sub iznos_change()
        Try
            ukupanIznos.Text = "00.00"
            Dim iznosReda As New Control
            For i = 0 To novoI - 1

                iznosReda = TableLayoutPanel1.GetControlFromPosition(6, i)
                If TryCast(iznosReda, TextBox).Text <> "" Then
                    ukupanIznos.Text += Math.Round(CDbl(iznosReda.Text), 2)
                    ukupanIznos.Text = Format(Val(ukupanIznos.Text), "0.00")
                End If

            Next

        Catch
        End Try
        'If ukupanIznos.Text = "0" Then
        '    ukupanIznos.Text = "00.00"
        'End If
    End Sub
    Public Sub test_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBox10.SelectedIndex = 1
        ComboBox2.SelectedIndex = 0
        Focus()
        TableLayoutPanel1.HorizontalScroll.Enabled = True
        'For Each row As RowStyle In Me.TableLayoutPanel2.RowStyles
        '    row.SizeType = SizeType.Absolute
        '    row.Height = 30.0!
        'Next

        Dim command As New SqlCommand("select zaposleni.ime + ' ' + zaposleni.prezime as name from zaposleni", baza.konekcija)
        Dim adapter As New SqlDataAdapter(command)
        Dim tabela As New DataTable()
        Dim ds As New DataSet()
        adapter.Fill(ds)



        ComboBox1.DataSource = ds.Tables(0)
        ComboBox1.ValueMember = "name"
        ComboBox1.DisplayMember = "name"
        ComboBox1.SelectedIndex = -1



        Dim commandBrojOtpremnice As New SqlCommand("select MAX(otpremnica_br) from Usluge", baza.konekcija)
        Dim adapterBO As New SqlDataAdapter(commandBrojOtpremnice)
        Dim tabelaBO As New DataTable()
        adapterBO.Fill(tabelaBO)

        brotpremniceTxt.Text = tabelaBO.Rows(0)(0) + 1


        Dim datum As Date
        datum = DateTime.Now.ToString("yyyy/MM/dd")
        datumtb.Text = datum


        Dim oCommand As New SqlCommand("Select DISTINCT otpremi_na_naslov from Osnovne", baza.konekcija)
        Dim oAdatper As New SqlDataAdapter(oCommand)
        Dim oDS As New DataSet()

        oAdatper.Fill(oDS)

        NaslovTB.DataSource = oDS.Tables(0)
        NaslovTB.ValueMember = "otpremi_na_naslov"
        NaslovTB.DisplayMember = "otpremi_na_naslov"
        NaslovTB.SelectedIndex = -1


        dodavanjeRedaOtpremnica()
        For i = 0 To 11
            dodavanjeReda()
        Next
        ComboBox1.TabStop = True
        reklamacijatb.SelectedIndex = 0
        OtpremaTB.SelectedIndex = -1
        ComboBox10.SelectedIndex = 1
        Me.WindowState = FormWindowState.Normal
    End Sub
    Private Sub dodavanjeRedaOtpremnica()
        'TableLayoutPanel2.GetControlFromPosition(0, 0).BackColor = Color.control

        Dim label1 As New TextBox                                          'SIFRA
        With label1
            .Name = "LSifra"
            .Text = "ŠIF"
            .Font = New Drawing.Font("Microsoft Sans Serif", 9.75)
            .Dock = DockStyle.Fill
            .ReadOnly = True
            .TabStop = False

            .ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333")
            .BackColor = SystemColors.Control
            TableLayoutPanel2.Controls.Add(label1, 0, 0)
        End With
        Dim label2 As New TextBox                                          'KUPAC
        With label2
            .Name = "LKUPAC"
            .Text = "KUPAC"

            .TabStop = False
            .Font = New Drawing.Font("Microsoft Sans Serif", 9.75)
            .Dock = DockStyle.Fill
            .ReadOnly = True
            .TextAlign = ContentAlignment.TopCenter
            .ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333")
            .BackColor = SystemColors.Control
            TableLayoutPanel2.Controls.Add(label2, 1, 0)
        End With
        Dim label3 As New TextBox                                          'DATUM
        With label3

            .TabStop = False
            .Name = "LDATUM"
            .Text = "DATUM"
            .Font = New Drawing.Font("Microsoft Sans Serif", 9.75)
            .Dock = DockStyle.Fill
            .ReadOnly = True
            .TextAlign = ContentAlignment.TopCenter
            .ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333")
            .BackColor = SystemColors.Control
            TableLayoutPanel2.Controls.Add(label3, 2, 0)
        End With
        Try
            '----------------------------------------------------------------------------- dt za otpremnice

            Dim bRCommand As New SqlCommand("Select ID, otpremi_na_naslov, datum from Osnovne", baza.konekcija)
            Dim bRadapter As New SqlDataAdapter(bRCommand)
            Dim bRds As New DataTable()
            bRadapter.Fill(bRds)

            If bRds.Rows.Count > 16 Then
                Dim kolikoTreba = bRds.Rows.Count - 16
                For i = 0 To kolikoTreba
                    TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0))
                Next
            End If

            '----------------------------------------------------------------------------- dt za otpremnice
            For smg = 0 To bRds.Rows.Count - 1

                Dim L As New TextBox                                          'SIFRA OTPREMNICE
                With L
                    .Text = bRds.Rows(smg)(0)
                    .Name = "mBrOtpremnice" + smg.ToString
                    .BorderStyle = BorderStyle.Fixed3D
                    .Font = New Drawing.Font("Microsoft Sans Serif", 9.75)
                    .TextAlign = ContentAlignment.TopCenter
                    .ForeColor = SystemColors.Control
                    .Enabled = True

                    .TabStop = False
                    .ReadOnly = True
                    .BackColor = System.Drawing.ColorTranslator.FromHtml("#333333")
                    TableLayoutPanel2.Controls.Add(L, 0, smg + 1)
                End With

                Dim T As New TextBox                                           'NAZIV KUPCA
                With T
                    .Text = " " + bRds.Rows(smg)(1)
                    .Name = "mTrOtpremnice" + smg.ToString
                    .Font = New Drawing.Font("Microsoft Sans Serif", 9.75)
                    .BorderStyle = BorderStyle.Fixed3D
                    .Enabled = True

                    .TabStop = False
                    .Dock = DockStyle.Fill
                    .ReadOnly = True
                    .ForeColor = SystemColors.Control
                    .BackColor = System.Drawing.ColorTranslator.FromHtml("#333333")
                    TableLayoutPanel2.Controls.Add(T, 1, smg + 1)
                End With

                Dim T2 As New TextBox                                           'DATUM OTP
                With T2
                    .Text = bRds.Rows(smg)(2)
                    .BorderStyle = BorderStyle.Fixed3D
                    .TextAlign = ContentAlignment.TopCenter

                    .TabStop = False
                    .Font = New Drawing.Font("Microsoft Sans Serif", 9.75)
                    .Name = "mTfOtpremnice" + smg.ToString
                    .ReadOnly = True
                    .Enabled = True
                    .ForeColor = SystemColors.Control
                    .BackColor = System.Drawing.ColorTranslator.FromHtml("#333333")
                    TableLayoutPanel2.Controls.Add(T2, 2, smg + 1)
                End With

                Dim btn1 As New PictureBox
                Dim tt As New ToolTip
                With btn1
                    .Size = New Size(28, 24)
                    .Name = "btn1" + smg.ToString
                    ' .FlatStyle = FlatStyle.Flat
                    .ForeColor = SystemColors.Control
                    .Size = New Size(28, 24)
                    .BackgroundImageLayout = ImageLayout.Stretch
                    .Image = My.Resources.saveeeeeeee1
                    .Size = New Size(28, 24)
                    .BackColor = System.Drawing.ColorTranslator.FromHtml("#333333")
                    .Dock = DockStyle.Fill
                    .Tag = bRds.Rows(smg)(0)
                    .Size = New Size(28, 24)
                    AddHandler btn1.Click, AddressOf otvoriOtpremnicu_Click
                    TableLayoutPanel2.Controls.Add(btn1, 3, smg + 1)
                End With
                tt.SetToolTip(btn1, "Otvori otpremnicu")
                'Dim btn2 As New Button                                           'DUGME IZMIJENI OTPREMNICU
                'With btn2

                '    .Name = "btn2" + smg.ToString
                '    .FlatStyle = FlatStyle.Flat
                '    .Dock = DockStyle.Fill
                '    .Size = New Size(28, 24)
                '    .BackgroundImageLayout = ImageLayout.Stretch
                '    .Image = My.Resources.saveeeeeeee1
                '    .Size = New Size(28, 24)
                '    .ForeColor = SystemColors.Control
                '    .BackColor = System.Drawing.ColorTranslator.FromHtml("#333333")
                '    .Tag = bRds.Rows(smg)(0) 'TAG JE SIFRA OTPREMNICE TKD KADA KLIKNEMO NA DUGME ODMAH OTVARA NOVU FORMU U KOJOJ UZ DUGME STIZE KOJU SIFRU OTPREMNNICE TO DUGME NOSI UZ SEBE, TAKO DA ODMAH U NOVOJ FORMI MOZEMO IZ BTN.TAG IZVUCI SVE VEZANO ZA TU SIFRU OTPREMNICE
                '    '    AddHandler dodajButton.Click, AddressOf brisiDugme_Click
                '    TableLayoutPanel2.Controls.Add(btn2, 4, smg + 1)
                'End With
            Next
        Catch
        End Try
    End Sub
    Public Sub otvoriOtpremnicu_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim dugme As PictureBox = DirectCast(sender, PictureBox)
        istorijaProdaje.Show()
        istorijaProdaje.otvaranjeOtpremnice(dugme.Tag)
        Me.Enabled = False
    End Sub
    Private Sub dodavanjeReda()
        Dim redniBroj As TextBox = New TextBox
        With redniBroj
            .Text = (novoI + 1).ToString
            .ReadOnly = True
            .Name = "redniBroj" + (novoI + 1).ToString '------------------------------------- REDNI BROJ
            .TextAlign = ContentAlignment.TopCenter
            .Dock = DockStyle.Fill
            .ForeColor = SystemColors.Control
            .BackColor = System.Drawing.ColorTranslator.FromHtml("#333333")
            .BorderStyle = BorderStyle.Fixed3D
            .Tag = 404
            TableLayoutPanel1.Controls.Add(redniBroj, 0, novoI)
        End With
        '----------------------------------------------------------------------------- dataSet za artikle
        Dim nazivRobe As ComboBox = New ComboBox
        Dim RCommand As New SqlCommand("Select naziv_robe from Inventar where kolicina > 0", baza.konekcija)
        Dim Radapter As New SqlDataAdapter(RCommand)
        Dim Rds As New DataSet()
        Radapter.Fill(Rds)

        '----------------------------------------------------------------------------- dataSet za artikle
        '----------------------------------------------------------------------------- tabela za rabat
        Dim rabatKomanda As New SqlCommand("Select rb from Rabat", baza.konekcija)
        Dim rabatAdapter As New SqlDataAdapter(rabatKomanda)
        Dim rabatDSet As New DataSet()
        rabatAdapter.Fill(rabatDSet)

        '----------------------------------------------------------------------------- tabela za rabat

        With nazivRobe

            .Name = "nazivRobe" + (novoI + 1).ToString
            .BindingContext = New BindingContext()
            .ValueMember = "naziv_robe"
            .DisplayMember = "naziv_robe" ' ------------------------------------------------- NAZIV ROBE
            .Dock = DockStyle.Fill
            .ForeColor = SystemColors.Control
            .BackColor = System.Drawing.ColorTranslator.FromHtml("#333333")
            .FlatStyle = FlatStyle.Flat
            .SelectedIndex = -1
            .Tag = novoI
            .DropDownStyle = ComboBoxStyle.DropDownList
            .DataSource = Rds.Tables(0)
            .SelectedIndex = -1 '
            AddHandler nazivRobe.SelectedIndexChanged, AddressOf combobox_change
        End With
        TableLayoutPanel1.Controls.Add(nazivRobe, 1, novoI)
        Dim jedMjere As TextBox = New TextBox
        With jedMjere
            .Name = "jedMjere" + (novoI + 1).ToString
            .Dock = DockStyle.Fill
            .ForeColor = SystemColors.Control
            .BackColor = System.Drawing.ColorTranslator.FromHtml("#333333")
            .ReadOnly = True
            .BorderStyle = BorderStyle.FixedSingle
            .TextAlign = HorizontalAlignment.Center
            TableLayoutPanel1.Controls.Add(jedMjere, 2, novoI)
            .Tag = novoI

        End With
        Dim cijenaCombo As TextBox = New TextBox
        With cijenaCombo
            .Name = "cijenaCombo" + (novoI + 1).ToString
            ' ----------------------------------------- CIJENA
            .Dock = DockStyle.Fill
            .ForeColor = SystemColors.Control
            .BackColor = System.Drawing.ColorTranslator.FromHtml("#333333")
            .ReadOnly = True
            .BorderStyle = BorderStyle.FixedSingle
            .TextAlign = HorizontalAlignment.Center
            .Tag = novoI
            TableLayoutPanel1.Controls.Add(cijenaCombo, 4, novoI)
            ' .SelectedIndex = -1
        End With
        Dim rabatCombo As ComboBox = New ComboBox
        With rabatCombo
            .Name = "rabatCombo" + (novoI + 1).ToString
            ' ---------------------------------------- RABAT
            .BindingContext = New BindingContext()
            .ValueMember = "rb"
            .DisplayMember = "rb"
            .Enabled = False
            .DataSource = rabatDSet.Tables(0)
            .Dock = DockStyle.Fill
            .ForeColor = SystemColors.Control
            .BackColor = System.Drawing.ColorTranslator.FromHtml("#333333")
            .FlatStyle = FlatStyle.Flat
            .Tag = novoI
            TableLayoutPanel1.Controls.Add(rabatCombo, 5, novoI)
            AddHandler rabatCombo.SelectedIndexChanged, AddressOf kolicina_change
            .SelectedIndex = -1
        End With
        Dim dodajButton As Button = New Button
        With dodajButton
            .Text = "IZBRISI"
            .Name = "dodajButton" + (novoI + 1).ToString
            .FlatStyle = FlatStyle.Flat
            .ForeColor = SystemColors.Control
            .BackColor = System.Drawing.ColorTranslator.FromHtml("#333333")

            .Size = New Size(61, 24)
            .Tag = novoI
            AddHandler dodajButton.Click, AddressOf brisiDugme_Click
            TableLayoutPanel1.Controls.Add(dodajButton, 7, novoI)
            '.Visible = False
        End With
        Dim kolicinaCombo As ComboBox = New ComboBox
        With kolicinaCombo
            .Name = "kolicinaCombo" + (novoI + 1).ToString
            '---------------------------------------- KOLICINA
            .Dock = DockStyle.Fill
            .ForeColor = SystemColors.Control
            .BackColor = System.Drawing.ColorTranslator.FromHtml("#333333")
            .FlatStyle = FlatStyle.Flat

            .DropDownStyle = ComboBoxStyle.DropDownList
            TableLayoutPanel1.Controls.Add(kolicinaCombo, 3, novoI)
            .SelectedIndex = -1
            .Tag = novoI
            AddHandler kolicinaCombo.SelectedIndexChanged, AddressOf kolicina_change
        End With
        Dim iznosCombo As TextBox = New TextBox
        With iznosCombo
            .Name = "iznosCombo" + (novoI + 1).ToString
            ' ----------------------------------------- IZNOS
            .Dock = DockStyle.Fill
            .ForeColor = SystemColors.Control
            .BackColor = System.Drawing.ColorTranslator.FromHtml("#333333")
            .ReadOnly = True
            .BorderStyle = BorderStyle.FixedSingle
            .TextAlign = HorizontalAlignment.Right
            .Tag = novoI
            TableLayoutPanel1.Controls.Add(iznosCombo, 6, novoI)
        End With
        If novoI > 14 Then
            TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0))
            TableLayoutPanel1.RowCount += 1

        End If
        'If novoI > 14 Then
        '    TableLayoutPanel1.RowCount += 1
        'End If
        novoI += 1

    End Sub
    Public Sub brisiDugme_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim dugme As Button = DirectCast(sender, Button)
        For Each ComboBox In TableLayoutPanel1.Controls
            If (ComboBox.Tag = dugme.Tag) And (ComboBox.Name <> dugme.Name) Then
                Select Case ComboBox.GetType
                    Case GetType(TextBox)
                        ComboBox.Text = ""
                    Case GetType(ComboBox)
                        ComboBox.selectedIndex = -1
                        ComboBox.Text = ""
                        ComboBox.selectedIndex = -1
                        ComboBox.selectedIndex = -1
                        ComboBox.selectedIndex = -1
                        snimi.TabStop = True
                End Select
                If (ComboBox.Name = "rabatCombo" + (ComboBox.Tag + 1).ToString) Then
                    ComboBox.Enabled = False

                    brojDodanih -= 1
                End If
            End If
        Next
    End Sub
    Private Function id_lica() As Integer
        Dim command As New SqlCommand("Select zaposleni.ime + ' ' + zaposleni.prezime as name from zaposleni", baza.konekcija) With {
             .CommandText = "select zaposleni.id from zaposleni where zaposleni.ime + ' ' + zaposleni.prezime  = '" & ComboBox1.SelectedValue & "'"
        }
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)
        id_lica = table.Rows(0)(0)
        Return id_lica
    End Function
    Private Sub NaslovTB_TextChanged(sender As Object, e As EventArgs) Handles NaslovTB.TextChanged
        'izvlacimo prethodne adrese izabranog kupca kao prijedlog

        Try
            Dim kaCommand As New SqlCommand("Select DISTINCT adresa_kupac from Osnovne WHERE otpremi_na_naslov = '" & NaslovTB.Text & "' ", baza.konekcija)
            Dim kaadapter As New SqlDataAdapter(kaCommand)
            Dim kads As New DataSet()

            kaadapter.Fill(kads)
            If kads.Tables(0).Rows.Count > 0 Then
                With kupacAdresaComboBox
                    .DataSource = kads.Tables(0)
                    .ValueMember = "adresa_kupac"
                    .DisplayMember = "adresa_kupac"
                    .SelectedIndex = 0
                    .DropDownStyle = ComboBoxStyle.DropDownList
                    .AutoCompleteMode = AutoCompleteMode.Suggest
                    .AutoCompleteSource = AutoCompleteSource.ListItems
                End With
            Else
                With kupacAdresaComboBox
                    .Text = ""
                    .DataSource = Nothing
                    .ValueMember = ""
                    .DisplayMember = ""
                    .SelectedIndex = -1
                    .DropDownStyle = ComboBoxStyle.DropDown
                    .AutoCompleteMode = AutoCompleteMode.Suggest
                    .AutoCompleteSource = AutoCompleteSource.ListItems
                End With
            End If
        Catch


        End Try


        'IB kupca povucen na osnovu njegovog imena

        Try
            Dim kaaCommand As New SqlCommand("Select DISTINCT IB_kupac from Osnovne WHERE otpremi_na_naslov = '" & NaslovTB.Text & "' ", baza.konekcija)
            Dim kaaadapter As New SqlDataAdapter(kaaCommand)
            Dim kaads As New DataSet()


            kaaadapter.Fill(kaads)
            If kaads.Tables(0).Rows.Count > 0 Then
                With iBKupcaComboBox
                    .DataSource = kaads.Tables(0)
                    .ValueMember = "IB_kupac"
                    .DisplayMember = "IB_kupac"

                    .DropDownStyle = ComboBoxStyle.DropDownList
                    .AutoCompleteMode = AutoCompleteMode.Suggest
                    .AutoCompleteSource = AutoCompleteSource.ListItems
                End With

            Else
                With iBKupcaComboBox
                    .Text = ""
                    .DataSource = Nothing
                    .ValueMember = ""
                    .DisplayMember = ""
                    .SelectedIndex = -1
                    .DropDownStyle = ComboBoxStyle.DropDown
                    .AutoCompleteMode = AutoCompleteMode.Suggest
                    .AutoCompleteSource = AutoCompleteSource.ListItems
                End With
            End If

        Catch
        End Try

        'Izvlacimo podatke o vozilu kupca
        Dim kom As New SqlCommand("select distinct reg_br_vozila_sluzbenog from Osnovne where nacin_otpreme = 2 and otpremi_na_naslov = '" & NaslovTB.Text & "' ", baza.konekcija)
        Dim ad As New SqlDataAdapter(kom)
        Dim ds As New DataSet()
        ad.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            vozilotb.DataSource = ds.Tables(0)
            vozilotb.ValueMember = "reg_br_vozila_sluzbenog"
            vozilotb.DisplayMember = "reg_br_vozila_sluzbenog"
            vozilotb.SelectedIndex = -1
        Else
            With vozilotb
                .Text = ""
                .DataSource = Nothing
                .ValueMember = ""
                .DisplayMember = ""
                .SelectedIndex = -1
                .DropDownStyle = ComboBoxStyle.DropDown
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With
        End If


    End Sub
    Private Sub iBKupcaComboBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles iBKupcaComboBox.KeyPress

        'IB kupca prima samo brojeve

        Dim KeyAscii As Integer = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 8, 27, 48 To 57, 9
            Case Else
                KeyAscii = 0
        End Select

        If KeyAscii = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
    Private Sub dodajRedButton_Click(sender As Object, e As EventArgs) Handles dodajRedButton.Click

        dodavanjeReda()  'dugme za dodavanje novog reda, van funkcije je jer je visible = false jer smo automatski stavili da dodaje novi red kad se prethodni popuni

    End Sub
    Public Sub combobox_change(ByVal sender As Object, ByVal e As EventArgs) '------------------ povlacenje jedinice mjere nakon biranja artikla

        Dim cmbx As ComboBox = DirectCast(sender, ComboBox)
        Dim k As Double
        Try

            For i = 0 To novoI - 1

                Dim nazivRobice = TableLayoutPanel1.GetControlFromPosition(1, i)
                If cmbx.Text = nazivRobice.Text And cmbx.Tag <> nazivRobice.Tag And TryCast(nazivRobice, ComboBox).SelectedIndex <> -1 Then          'novo petlja za provjeru da li je izabrani artikal vec ranije izabran


                    Dim dugmence = TableLayoutPanel1.GetControlFromPosition(7, cmbx.Tag)
                    TryCast(dugmence, Button).PerformClick()

                    TryCast(nazivRobice, ComboBox).DroppedDown = True
                End If
            Next
            snimi.Focus()
            If cmbx.Tag = novoI - 1 Then
                dodajRedButton_Click(e, e)
            End If





            Dim lista As Control
            For Each lista In TableLayoutPanel1.Controls
                If (lista.Text = cmbx.Text) And (lista.Tag <> cmbx.Tag) Then
                Else
                    If (lista.Tag = cmbx.Tag) Then
                        Dim kolCommand As New SqlCommand("SELECT jed_mjere, kolicina, cijena from Inventar where naziv_robe = '" + cmbx.Text + "'", baza.konekcija)
                        Dim kolAdapter As New SqlDataAdapter(kolCommand)
                        Dim kolDS As New DataTable()
                        kolAdapter.Fill(kolDS)

                        If (lista.Name = "jedMjere" + (cmbx.Tag + 1).ToString) Then
                            Dim pretvori As String = kolDS.Rows.Item(0)(0).ToString
                            If pretvori = "True" Then
                                lista.Text = "K"
                            Else
                                lista.Text = "H"
                            End If


                        ElseIf (lista.Tag = cmbx.Tag And lista.Name <> "jedMjere" + (cmbx.Tag + 1).ToString And lista.Text <> "IZBRISI" And lista.Name <> "rabatCombo" + (cmbx.Tag + 1).ToString) Then
                            lista.Text = ""
                        End If

                        If (lista.Name = "kolicinaCombo" + (cmbx.Tag + 1).ToString And lista.GetType() Is GetType(ComboBox)) Then


                            Dim kolicinaCommand As New SqlCommand("SELECT kolicina from Inventar where naziv_robe = '" + cmbx.Text + "'", baza.konekcija)
                            Dim kolicinaAdapter As New SqlDataAdapter(kolicinaCommand)
                            Dim kolicinaDataSet As New DataTable()
                            kolicinaAdapter.Fill(kolicinaDataSet)

                            Dim privBroj As Integer
                            TryCast(lista, ComboBox).Items.Clear()
                            For privBroj = 1 To kolicinaDataSet.Rows(0)(0)
                                TryCast(lista, ComboBox).Items.Add(privBroj)
                            Next

                            TryCast(lista, ComboBox).ValueMember = "kolicina"
                            TryCast(lista, ComboBox).DisplayMember = "kolicina"
                            TryCast(lista, ComboBox).SelectedIndex = 0
                            TryCast(lista, ComboBox).SelectedIndex = 0
                            k = 1

                        End If

                        If (lista.Name = "cijenaCombo" + (cmbx.Tag + 1).ToString) Then
                            Dim DecimalniBroj = kolDS.Rows.Item(0)(2)
                            Dim noviBroj = Math.Round(DecimalniBroj, 2)
                            lista.Text = noviBroj

                        End If
                        If (lista.Name = "rabatCombo" + (cmbx.Tag + 1).ToString) Then
                            lista.Enabled = True
                            TryCast(lista, ComboBox).SelectedIndex = 0

                            TryCast(lista, ComboBox).SelectedIndex = 0
                        End If
                        If (lista.Name = "iznosCombo" + (cmbx.Tag + 1).ToString) Then
                            Dim DecimalniBroj = kolDS.Rows.Item(0)(2)
                            Dim noviBroj = Math.Round(DecimalniBroj, 2)

                            If (ComboBox10.SelectedIndex = 1) Then
                                lista.Text = (noviBroj * 17) / 100 + noviBroj
                            ElseIf (ComboBox10.SelectedIndex = 0) Then
                                lista.Text = noviBroj
                            End If
                        End If



                    End If

                End If


            Next

        Catch ex As Exception

        End Try
    End Sub
    Public Sub kolicina_change(ByVal sender As Object, ByVal e As EventArgs) '------------------ povlacenje jedinice mjere nakon biranja artikla

        Dim cmbx As ComboBox = DirectCast(sender, ComboBox)
        Dim kolicina, cijena, rabat, pdv As Double
        kolicina = 0
        cijena = 0
        rabat = 0
        pdv = 0

        Try
            Dim lista As Control
            For Each lista In TableLayoutPanel1.Controls
                If (lista.Tag = cmbx.Tag) Then


                    Try

                        If (lista.Name = "kolicinaCombo" + (cmbx.Tag + 1).ToString) Then
                            kolicina = CDbl(lista.Text)
                        End If
                    Catch
                    End Try

                    Try

                        If (lista.Name = "cijenaCombo" + (cmbx.Tag + 1).ToString) Then
                            cijena = CDbl(lista.Text)
                        End If
                    Catch
                    End Try

                    Try

                        If (ComboBox10.SelectedIndex = 1) Then
                            pdv = 17
                        ElseIf (ComboBox10.SelectedIndex = 0) Then
                            pdv = 1
                        End If

                    Catch
                    End Try

                    Try

                        If (lista.Name = "rabatCombo" + (cmbx.Tag + 1).ToString) Then
                            rabat = CDbl(lista.Text)
                        End If
                    Catch
                    End Try


                    Try

                        If (lista.Name = "iznosCombo" + (cmbx.Tag + 1).ToString) Then
                            Dim broj As Double
                            If pdv = 17 And rabat <> 0 And kolicina <> 0 Then
                                broj = Math.Round((cijena * kolicina * pdv) / 100 + cijena * kolicina - (cijena * kolicina * rabat) / 100, 2)
                                lista.Text = Format(Val(broj), "0.00")
                            ElseIf pdv = 17 And rabat = 0 And kolicina <> 0 Then
                                broj = Math.Round((cijena * kolicina * 17) / 100 + cijena * kolicina, 2)
                                lista.Text = Format(Val(broj), "0.00")
                            ElseIf pdv = 1 And rabat <> 0 And kolicina <> 0 Then
                                broj = Math.Round(cijena * kolicina - (cijena * kolicina * rabat) / 100, 2)
                                lista.Text = Format(Val(broj), "0.00")
                            ElseIf pdv = 1 And rabat = 0 And kolicina <> 0 Then
                                broj = Math.Round(cijena * kolicina, 2)
                                lista.Text = Format(Val(broj), "0.00")
                            End If
                        End If
                        iznos_change()

                    Catch
                    End Try




                End If
            Next
        Catch
        End Try
    End Sub
    Private Sub ComboBox10_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox10.SelectedIndexChanged
        Dim nekoI = 1
        For Each ctrl In TableLayoutPanel1.Controls                                 'kada se mijenja stanje pdv-a

            If (ctrl.name = "kolicinaCombo" + nekoI.ToString) Then
                Dim nekoKombo = New ComboBox
                nekoKombo = ctrl
                kolicina_change(nekoKombo, e)
                nekoI += 1
            End If
        Next
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Medjuforma.Show()
        Me.Dispose()
    End Sub
    Private Sub OtpremaTB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles OtpremaTB.SelectedIndexChanged



        If OtpremaTB.SelectedIndex = 1 Then
            Dim kom As New SqlCommand("select distinct sluz_voz from zaposleni where id = " & ComboBox1.SelectedIndex & "", baza.konekcija)
            Dim ad As New SqlDataAdapter(kom)
            Dim ds As New DataSet()
            ad.Fill(ds)
            vozilotb.DataSource = ds.Tables(0)
            vozilotb.ValueMember = "sluz_voz"
            vozilotb.DisplayMember = "sluz_voz"
            vozilotb.SelectedIndex = -1

        ElseIf OtpremaTB.SelectedIndex = 0 Then
            Dim kom As New SqlCommand("select distinct reg_br_vozila_sluzbenog  as posta from Osnovne where nacin_otpreme = 3", baza.konekcija)
            Dim ad As New SqlDataAdapter(kom)
            Dim ds As New DataSet()
            ad.Fill(ds)
            vozilotb.DataSource = ds.Tables(0)
            vozilotb.ValueMember = "posta"
            vozilotb.DisplayMember = "posta"
            vozilotb.SelectedIndex = -1


        ElseIf OtpremaTB.SelectedIndex = 2 Then
            Dim kom As New SqlCommand("select distinct reg_br_vozila_sluzbenog from Osnovne where nacin_otpreme = 2 and otpremi_na_naslov = '" & NaslovTB.Text & "' ", baza.konekcija)
            Dim ad As New SqlDataAdapter(kom)
            Dim ds As New DataSet()
            ad.Fill(ds)
            vozilotb.DataSource = ds.Tables(0)
            vozilotb.ValueMember = "reg_br_vozila_sluzbenog"
            vozilotb.DisplayMember = "reg_br_vozila_sluzbenog"
            vozilotb.SelectedIndex = -1
        Else
            vozilotb.DataSource = Nothing
            vozilotb.Items.Add("")
            vozilotb.Items.Clear()
        End If

    End Sub
    Public Sub Combobox1_SelecedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim kom As New SqlCommand("select distinct sluz_voz from zaposleni where id = " & ComboBox1.SelectedIndex & "", baza.konekcija)
        Dim ad As New SqlDataAdapter(kom)
        Dim ds As New DataSet()
        ad.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            vozilotb.DataSource = ds.Tables(0)
            vozilotb.ValueMember = "sluz_voz"
            vozilotb.DisplayMember = "sluz_voz"
            vozilotb.SelectedIndex = -1
        Else
            With vozilotb
                .Text = ""
                .DataSource = Nothing
                .ValueMember = ""
                .DisplayMember = ""
                .SelectedIndex = -1
                .DropDownStyle = ComboBoxStyle.DropDown
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With
        End If

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click



        Dim odgovor = MsgBox("Da li zelite brisati i podatke o kupcu?", vbYesNoCancel)

        If odgovor = vbYes Then

            vozilotb.DataSource = Nothing
            vozilotb.Items.Add("")
            vozilotb.Items.Clear()
            NaslovTB.SelectedIndex = -1
            iBKupcaComboBox.DataSource = Nothing
            iBKupcaComboBox.Items.Add("")
            iBKupcaComboBox.Items.Clear()
            kupacAdresaComboBox.DataSource = Nothing
            kupacAdresaComboBox.Items.Add("")
            kupacAdresaComboBox.Items.Clear()
            OtpremaTB.SelectedIndex = -1
            reklamacijatb.SelectedIndex = 0
            ComboBox10.SelectedIndex = 1
            ComboBox1.SelectedIndex = -1 'u slucaju da zelimo i prodavaca resetovati
            Try
                For i = 0 To novoI - 1
                    Dim dugmence = TableLayoutPanel1.GetControlFromPosition(7, i)
                    TryCast(dugmence, Button).PerformClick()
                Next

            Catch
            End Try
        ElseIf odgovor = vbNo Then
            Try
                For i = 0 To novoI - 1
                    Dim dugmence = TableLayoutPanel1.GetControlFromPosition(7, i)
                    TryCast(dugmence, Button).PerformClick()
                Next

            Catch
            End Try
        ElseIf odgovor = vbCancel Then

        End If


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
                Dim podaciHeader As New List(Of String)({nazivPL, nacinOtp, kupacOTP, IBFirme, regBrOTP, IBKupca, adresaFirme, reklamacijeOTP, adresaKupca, brojOtp, PDVOTP, datumOTP})

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
                Dim podaciHeader As New List(Of String)({nazivPL, nacinOtp, kupacOTP, IBFirme, regBrOTP, IBKupca, adresaFirme, reklamacijeOTP, adresaKupca, brojOtp, PDVOTP, datumOTP})

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

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        comboIzabrani = ComboBox2.SelectedIndex
    End Sub
End Class

