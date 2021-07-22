Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO




Public Class test
    Dim novoI As Integer = 0
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

                Dim CellOneHdr As New PdfPCell(New Phrase(redni_broj(), fntTableFontHdr))
                ptabela.AddCell(CellOneHdr)
                Dim celltwohdr As New PdfPCell(New Phrase(ComboBox5.SelectedValue, fntTableFontHdr))
                ptabela.AddCell(celltwohdr)
                Dim cellthreehdr As New PdfPCell(New Phrase(TextBox2.Text, fntTableFontHdr))
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

    Public Sub test_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Focus()
        TableLayoutPanel1.HorizontalScroll.Enabled = True

        Dim command As New SqlCommand("select zaposleni.ime + ' ' + zaposleni.prezime as name from zaposleni", baza.konekcija)
        Dim adapter As New SqlDataAdapter(command)
        Dim tabela As New DataTable()
        Dim ds As New DataSet()
        adapter.Fill(ds)

        Dim brojac As Integer

        ComboBox1.DataSource = ds.Tables(0)
        ComboBox1.ValueMember = "name"
        ComboBox1.DisplayMember = "name"
        ComboBox1.SelectedIndex = -1



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




        Dim kolCommand As New SqlCommand("DECLARE @int as Integer	
set @int = (SELECT kolicina from Inventar where id_robe = 15)

while @int >= 1 
begin
print @int
set @int = @int - 1;
end;", baza.konekcija)



        For i = 0 To 11
            dodavanjeReda()
        Next



        Dim kolAdapter As New SqlDataAdapter(kolCommand)
        Dim kolDS As New DataSet()
        kolAdapter.Fill(kolDS)
        'ComboBox7.DataSource = kolDS.Tables(0)
        'ComboBox7.ValueMember = "@int"
        'ComboBox7.DisplayMember = "@int"
        If brojac = 22 Then
            command.CommandText = "INSERT INTO Osnove (naziv_pravnog_lica, adresa, IB, otpremi_na_naslov, adresa_kupac, nacin_otpreme, reklamacija, datum, ID, IB_kupac, reg_br_vozila_sluzbenog)
        VALUES ( " & id_lica() & ", '" & adresaTB.Text & "', '" & ibTB.Text & "','" & NaslovTB.SelectedValue & "', '" & kupacAdresaComboBox.SelectedValue & "'," & OtpremaTB.Text & "," & reklamacijatb.Text & ",'" & datumtb.Text & "'," & otpremnicatb.Text & ",'" & iBKupcaComboBox.SelectedValue & "','" & vozilotb.SelectedValue & "');
INSERT INTO Usluge (redni_broj, naziv_robe, kolicina, cijena, rabat, pdv, otpremnica_br, iznos)
VALUES (" & redni_broj() & ", " & roba() & ", "
            MsgBox("Molimo popunite sva polja")
        End If

    End Sub

    Private Sub dodavanjeReda()



        Dim redniBroj As TextBox = New TextBox
        With redniBroj
            .Text = (novoI + 1).ToString
            .ReadOnly = True
            .Name = "redniBroj" + (novoI + 1).ToString '------------------------------------- REDNI BROJ
            .TextAlign = ContentAlignment.TopCenter
            .Dock = DockStyle.Fill
            .BackColor = SystemColors.ActiveBorder
            .BorderStyle = BorderStyle.Fixed3D
            .Tag = 404
            TableLayoutPanel1.Controls.Add(redniBroj, 0, novoI)
        End With


        '----------------------------------------------------------------------------- dataSet za artikle
        Dim nazivRobe As ComboBox = New ComboBox
        Dim RCommand As New SqlCommand("Select naziv_robe from Inventar", baza.konekcija)
        Dim Radapter As New SqlDataAdapter(RCommand)
        Dim Rds As New DataSet()
        Radapter.Fill(Rds)

        '----------------------------------------------------------------------------- dataSet za artikle

        With nazivRobe
                .Name = "nazivRobe" + (novoI + 1).ToString
            .BindingContext = New BindingContext()
            .ValueMember = "naziv_robe"
                .DisplayMember = "naziv_robe" ' ------------------------------------------------- NAZIV ROBE
                .Dock = DockStyle.Fill
                .BackColor = SystemColors.ActiveBorder
            .FlatStyle = FlatStyle.Flat
            .SelectedIndex = -1
            .Tag = novoI

        End With
        TableLayoutPanel1.Controls.Add(nazivRobe, 1, novoI)
        Dim jedMjere As ComboBox = New ComboBox
        With jedMjere
            .Name = "jedMjere" + (novoI + 1).ToString
            .Dock = DockStyle.Fill
            .BackColor = SystemColors.ActiveBorder
            .FlatStyle = FlatStyle.Flat
            TableLayoutPanel1.Controls.Add(jedMjere, 2, novoI)
            .SelectedIndex = -1
            .Tag = novoI
        End With

        Dim kolicinaCombo As ComboBox = New ComboBox
        With kolicinaCombo
            .Name = "kolicinaCombo" + (novoI + 1).ToString
            '.DataSource = ComboBox5.DataSource ' ---------------------------------------- KOLICINA
            '.ValueMember = "naziv_robe"
            '.DisplayMember = "naziv_robe"
            .Dock = DockStyle.Fill
            .BackColor = SystemColors.ActiveBorder
            .FlatStyle = FlatStyle.Flat
            TableLayoutPanel1.Controls.Add(kolicinaCombo, 3, novoI)
            .SelectedIndex = -1
            .Tag = novoI
        End With

        Dim cijenaCombo As ComboBox = New ComboBox
        With cijenaCombo
            .Name = "cijenaCombo" + (novoI + 1).ToString
            '.DataSource = ComboBox5.DataSource ' ----------------------------------------- CIJENA
            '.ValueMember = "naziv_robe"
            '.DisplayMember = "naziv_robe"
            .Dock = DockStyle.Fill
            .BackColor = SystemColors.ActiveBorder
            .FlatStyle = FlatStyle.Flat
            TableLayoutPanel1.Controls.Add(cijenaCombo, 4, novoI)
            .SelectedIndex = -1
            .Tag = novoI
        End With

        Dim iznosCombo As ComboBox = New ComboBox
        With iznosCombo
            .Name = "iznosCombo" + (novoI + 1).ToString
            '.DataSource = ComboBox5.DataSource ' ----------------------------------------- IZNOS
            '.ValueMember = "naziv_robe"
            '.DisplayMember = "naziv_robe"
            .Dock = DockStyle.Fill
            .BackColor = SystemColors.ActiveBorder
            .FlatStyle = FlatStyle.Flat
            TableLayoutPanel1.Controls.Add(iznosCombo, 5, novoI)
            .SelectedIndex = -1
            .Tag = novoI
        End With

        Dim rabatCombo As ComboBox = New ComboBox
        With rabatCombo
            .Name = "rabatCombo" + (novoI + 1).ToString
            '.DataSource = ComboBox5.DataSource  ' ---------------------------------------- RABAT
            '.ValueMember = "naziv_robe"
            '.DisplayMember = "naziv_robe"
            .Dock = DockStyle.Fill
            .BackColor = SystemColors.ActiveBorder
            .FlatStyle = FlatStyle.Flat
            TableLayoutPanel1.Controls.Add(rabatCombo, 6, novoI)
            .SelectedIndex = -1
            .Tag = novoI
        End With

        Dim dodajButton As Button = New Button
        With dodajButton

            .Text = "IZBRISI"
            .Name = "dodajButton" + (novoI + 1).ToString
            .Visible = True
            .Size = New Size(80, 40)
            .Tag = novoI

            AddHandler dodajButton.Click, AddressOf btnCreate_Click
            TableLayoutPanel1.Controls.Add(dodajButton, 7, novoI)
        End With

        '-------------------------------------------------------------------------------------------------------------------------------------
        '-------------------------------------------------------------------------------------------------------------------------------------
        '           POPUNJAVANJE COMBOBOXOVA OVDE RADITI POSLE INICIJALIZACIJE KAKO BI SE IZBJEGLO POPUNJAVANJE-PRIKAZIVANJE-PRIKRIVANJE  ----
        nazivRobe.DataSource = Rds.Tables(0)
        nazivRobe.SelectedIndex = -1 '                                                                                                    ----
        '                                                                                                                                 ----
        '-------------------------------------------------------------------------------------------------------------------------------------
        '-------------------------------------------------------------------------------------------------------------------------------------

        novoI += 1


    End Sub

    Public Sub btnCreate_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim dugme As Button = DirectCast(sender, Button)


        For Each ComboBox In TableLayoutPanel1.Controls
            If (ComboBox.Tag = dugme.Tag) And (ComboBox.name <> dugme.Name) Then
                ComboBox.Text = ""
            End If
        Next


        'Try
        '    Dim nestoNovo = novoI


        '    'If dugme.Tag >= nestoNovo Then
        '    '    Return
        '    'End If

        '    ' delete all controls of row that we want to delete
        '    For i As Integer = 0 To TableLayoutPanel1.ColumnCount
        '        Dim Control = TableLayoutPanel1.GetControlFromPosition(i, dugme.Tag)
        '        TableLayoutPanel1.Controls.Remove(Control)

        '    Next


        '    'move up row controls that comes after row we want to remove


        '    For i = dugme.Tag + 1 To novoI
        '        For j = 0 To TableLayoutPanel1.ColumnCount
        '            Dim Control = TableLayoutPanel1.GetControlFromPosition(j, i)

        '            If (Control Is Nothing) Then

        '            Else

        '                TableLayoutPanel1.SetRow(Control, i - 1)
        '            End If
        '        Next

        '    Next


        '    Dim removeStyle = nestoNovo - 1

        '    If (nestoNovo > removeStyle) Then
        '        TableLayoutPanel1.RowStyles.RemoveAt(removeStyle)
        '    End If

        '    nestoNovo -= 1
        '    novoI -= 1
        'Catch

        'End Try
        ' brisanje reda i pomijeranje redova koji su ispod izbrisanog reda 


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'If  Then
        '    MsgBox("meh")
        'Else
        '    MessageBox.Show("shew")
        'End If

    End Sub
    Private Function id_lica() As Integer
        Dim command As New SqlCommand("Select zaposleni.ime + ' ' + zaposleni.prezime as name from zaposleni", baza.konekcija)
        command.CommandText = "select zaposleni.id from zaposleni where zaposleni.ime + ' ' + zaposleni.prezime  = '" & ComboBox1.SelectedValue & "'"
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)
        id_lica = table.Rows(0)(0)
        Return id_lica
    End Function
    Private Function redni_broj() As Integer
        Dim s As Integer
        Dim command As New SqlCommand("declare @new as smallint 
set @new = (select  MAX(redni_broj) as max
from Usluge) + 1;
select @new", baza.konekcija)
        Dim adapter As New SqlDataAdapter(command)
        Dim tabela As New DataTable()
        adapter.Fill(tabela)
        s = tabela.Rows(0)(0)
        Return s
    End Function
    Private Function roba() As Integer
        Dim x As Integer
        Dim command As New SqlCommand("Select id_robe from Inventar where naziv_robe = " & ComboBox5.SelectedValue & "")
        Dim tabela As New DataTable()
        Dim adatpter As New SqlDataAdapter(command)
        adatpter.Fill(tabela)
        x = tabela.Rows(0)(0)
        Return x
    End Function



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim miniBrojac As Integer = 0   'brojac koji provjerava da li je sve popunjeno kako bi dodalo novo dugme za novi red
        Try
            Dim ctrl As Control
            For Each ctrl In TableLayoutPanel1.Controls
                If (ctrl.Name = ("nazivRobe" + (novoI + 1).ToString) And ctrl.Text <> "") Then              'provjerava da li je naziv robe izabran o i povecava brojac
                    miniBrojac += 1
                End If
            Next
        Catch
        End Try

        Try
            Dim ctrl As Control
            For Each ctrl In TableLayoutPanel1.Controls
                If (ctrl.Name = ("jedMjere" + (novoI + 1).ToString) And ctrl.Text <> "") Then               'provjerava da li je jedinica mjere izabrana i povecava brojac
                    miniBrojac += 1
                End If
            Next

        Catch
        End Try

        Try
            Dim ctrl As Control
            For Each ctrl In TableLayoutPanel1.Controls
                If (ctrl.Name = ("kolicinaCombo" + (novoI + 1).ToString) And ctrl.Text <> "") Then               'provjerava da li je jedinica mjere izabrana i povecava brojac
                    miniBrojac += 1
                End If
            Next

        Catch
        End Try

        Try
            Dim ctrl As Control
            For Each ctrl In TableLayoutPanel1.Controls
                If (ctrl.Name = ("cijenaCombo" + (novoI + 1).ToString) And ctrl.Text <> "") Then               'provjerava da li je jedinica mjere izabrana i povecava brojac
                    miniBrojac += 1
                End If
            Next

        Catch
        End Try

        Try
            Dim ctrl As Control
            For Each ctrl In TableLayoutPanel1.Controls
                If (ctrl.Name = ("iznosCombo" + (novoI + 1).ToString) And ctrl.Text <> "") Then               'provjerava da li je jedinica mjere izabrana i povecava brojac
                    miniBrojac += 1
                End If
            Next

        Catch
        End Try

        Try
            Dim ctrl As Control
            For Each ctrl In TableLayoutPanel1.Controls
                If (ctrl.Name = ("rabatCombo" + (novoI + 1).ToString) And ctrl.Text <> "") Then               'provjerava da li je jedinica mjere izabrana i povecava brojac
                    miniBrojac += 1
                End If
            Next

        Catch
        End Try

        If miniBrojac = 6 Then              'dugme za dodavanje novog reda kada se popuni prethodni
            novoI += 1
            dodavanjeReda()
        Else
        End If



        '        Dim jCommand As New SqlCommand("declare @jed as bit	
        'declare @x as char(1)
        'set @jed = (Select DISTINCT jed_mjere  from Inventar  where naziv_robe = '" & ComboBox5.SelectedValue & "')
        'if @jed = 1 
        'set @x = 'k'
        'else if @jed = 0
        'set @x = 'h'
        'select @x", baza.konekcija)
        '        Dim jAdapter As New SqlDataAdapter(jCommand)
        '        Dim jDS As New DataTable()
        '        Try
        '            jAdapter.Fill(jDS)
        '            TextBox2.Text = jDS.Rows(0)(0)
        '        Catch ex As Exception

        '        End Try



    End Sub

    Private Sub NaslovTB_TextChanged(sender As Object, e As EventArgs) Handles NaslovTB.TextChanged
        'izvlacimo prethodne adrese izabranog kupca kao prijedlog

        Try
            Dim kaCommand As New SqlCommand("Select DISTINCT adresa_kupac from Osnovne WHERE otpremi_na_naslov = '" & NaslovTB.Text & "' ", baza.konekcija)
            Dim kaadapter As New SqlDataAdapter(kaCommand)
            Dim kads As New DataSet()

            kaadapter.Fill(kads)
            With kupacAdresaComboBox
                .DataSource = kads.Tables(0)
                .ValueMember = "adresa_kupac"
                .DisplayMember = "adresa_kupac"
                .SelectedIndex = -1
                .DropDownStyle = ComboBoxStyle.DropDown
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With
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

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            Dim broj = 0
            For Each lista As Control In TableLayoutPanel1.Controls
                If (lista.Name = "nazivRobe" + (broj + 1).ToString And lista.Text <> "") Then
                    For Each lista2 As Control In TableLayoutPanel1.Controls
                        If (lista2.Name = "jedMjere" + (broj + 1).ToString) Then

                            Dim kolCommand As New SqlCommand("DECLARE @int as Integer	
set @int = (SELECT kolicina from Inventar where naziv_robe = '" & lista.Text & "')

while @int >= 1 
begin
print @int                                   
set @int = @int - 1;
end;", baza.konekcija)
                            Dim kolAdapter As New SqlDataAdapter(kolCommand)
                            Dim kolDS As New DataTable()  '----------------------------------------------ovde se zaustavio
                            kolAdapter.Fill(kolDS)


                            lista2.Text = kolDS.Rows.Item(0)(0) ' kolDS.Tables(0)(0).ToString
                        End If
                    Next
                End If
            Next
        Catch

        End Try

    End Sub
End Class

