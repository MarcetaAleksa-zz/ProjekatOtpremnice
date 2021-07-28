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
                '   Dim celltwohdr As New PdfPCell(New Phrase(ComboBox5.SelectedValue, fntTableFontHdr))
                ' ptabela.AddCell(celltwohdr)
                ' Dim cellthreehdr As New PdfPCell(New Phrase(TextBox2.Text, fntTableFontHdr))
                'ptabela.AddCell(cellthreehdr)
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

        ComboBox10.SelectedIndex = 0
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
        '        If brojac = 22 Then
        '            command.CommandText = "INSERT INTO Osnove (naziv_pravnog_lica, adresa, IB, otpremi_na_naslov, adresa_kupac, nacin_otpreme, reklamacija, datum, ID, IB_kupac, reg_br_vozila_sluzbenog)
        '        VALUES ( " & id_lica() & ", '" & adresaTB.Text & "', '" & ibTB.Text & "','" & NaslovTB.SelectedValue & "', '" & kupacAdresaComboBox.SelectedValue & "'," & OtpremaTB.Text & "," & reklamacijatb.Text & ",'" & datumtb.Text & "'," & otpremnicatb.Text & ",'" & iBKupcaComboBox.SelectedValue & "','" & vozilotb.SelectedValue & "');
        'INSERT INTO Usluge (redni_broj, naziv_robe, kolicina, cijena, rabat, pdv, otpremnica_br, iznos)
        'VALUES (" & redni_broj() & ", " & roba() & ", "
        '            MsgBox("Molimo popunite sva polja")
        '        End If

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
            .BackColor = SystemColors.ActiveBorder
            .FlatStyle = FlatStyle.Flat
            .SelectedIndex = -1
            .Tag = novoI
            .DropDownStyle = ComboBoxStyle.DropDownList
            .DataSource = Rds.Tables(0)
            .SelectedIndex = -1 '
            AddHandler nazivRobe.SelectedIndexChanged, AddressOf ComboBox_change
        End With
        TableLayoutPanel1.Controls.Add(nazivRobe, 1, novoI)
        Dim jedMjere As TextBox = New TextBox
        With jedMjere
            .Name = "jedMjere" + (novoI + 1).ToString
            .Dock = DockStyle.Fill
            .BackColor = SystemColors.ActiveBorder
            .ReadOnly = True
            .BorderStyle = BorderStyle.FixedSingle
            .TextAlign = .TextAlign.Center
            TableLayoutPanel1.Controls.Add(jedMjere, 2, novoI)
            .Tag = novoI

        End With

        Dim kolicinaCombo As ComboBox = New ComboBox
        With kolicinaCombo
            .Name = "kolicinaCombo" + (novoI + 1).ToString
            '---------------------------------------- KOLICINA
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
            ' ----------------------------------------- CIJENA
            .Dock = DockStyle.Fill
            .BackColor = SystemColors.ActiveBorder
            .FlatStyle = FlatStyle.Flat
            TableLayoutPanel1.Controls.Add(cijenaCombo, 4, novoI)
            .SelectedIndex = -1
            .Tag = novoI
        End With

        Dim iznosCombo As TextBox = New TextBox
        With iznosCombo
            .Name = "iznosCombo" + (novoI + 1).ToString
            ' ----------------------------------------- IZNOS
            .Dock = DockStyle.Fill
            .BackColor = SystemColors.ActiveBorder
            .ReadOnly = True
            .BorderStyle = BorderStyle.FixedSingle
            .TextAlign = .TextAlign.Right
            TableLayoutPanel1.Controls.Add(iznosCombo, 6, novoI)
            .Tag = novoI
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
            .BackColor = SystemColors.ActiveBorder
            .FlatStyle = FlatStyle.Flat
            TableLayoutPanel1.Controls.Add(rabatCombo, 5, novoI)
            .SelectedIndex = -1
            .Tag = novoI
            AddHandler rabatCombo.SelectedIndexChanged, AddressOf rabat_change
        End With

        Dim dodajButton As Button = New Button
        With dodajButton
            .Text = "IZBRISI"
            .Name = "dodajButton" + (novoI + 1).ToString
            .Size = New Size(80, 40)
            .Tag = novoI
            AddHandler dodajButton.Click, AddressOf brisiDugme_Click
            TableLayoutPanel1.Controls.Add(dodajButton, 7, novoI)
            '.Visible = False
        End With
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
                End Select
                If (ComboBox.Name = "rabatCombo" + (ComboBox.Tag + 1).ToString) Then
                    ComboBox.Enabled = False
                End If
            End If

        Next


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
    Public Sub combobox_change(ByVal sender As Object, ByVal e As EventArgs) '------------------ povlacenje jedinice mjere nakon biranja artikla

        Dim cmbx As ComboBox = DirectCast(sender, ComboBox)
        Try

            Dim lista As Control
            For Each lista In TableLayoutPanel1.Controls

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

                        '        ElseIf (lista.Tag = cmbx.Tag And lista.Name <> "jedMjere" + (cmbx.Tag + 1).ToString And lista.Text <> "IZBRISI") Then
                    ElseIf (lista.Tag = cmbx.Tag And lista.Name <> "jedMjere" + (cmbx.Tag + 1).ToString And lista.Text <> "IZBRISI") Then
                        lista.Text = ""
                    End If ' if grananje gdje ulazimo u jedMjere textbox i dodjeljujemo vrijednosti

                    If (lista.Name = "kolicinaCombo" + (cmbx.Tag + 1).ToString) Then
                        'Dim instance = lista.GetValue(lista, null)

                        lista.Text = kolDS.Rows.Item(0)(1).ToString
                    End If ' if grananje gdje ulazimo u kilicina combobox i dodjeljujemo vrijednosti

                    If (lista.Name = "cijenaCombo" + (cmbx.Tag + 1).ToString) Then
                        Dim DecimalniBroj = kolDS.Rows.Item(0)(2)
                        Dim noviBroj = Math.Round(DecimalniBroj, 2)
                        lista.Text = noviBroj

                    End If ' if grananje gdje ulazimo u cijena combobox i dodjeljujemo vrijednosti
                    If (lista.Name = "rabatCombo" + (cmbx.Tag + 1).ToString) Then
                        lista.Enabled = True

                    End If



                End If '--- preko if-a ulazimo u textbox koji nosi isti tag kao promjenjeni ComboBox (provjera da l' pristupa ispravnom)

            Next

        Catch ex As Exception

        End Try
    End Sub
    Public Sub rabat_change(ByVal sender As Object, ByVal e As EventArgs) '------------------ povlacenje jedinice mjere nakon biranja artikla

        Dim cmbx As ComboBox = DirectCast(sender, ComboBox)
        Dim kolicina, cijena, rabat, pdv


        Try
            Dim lista As Control
            For Each lista In TableLayoutPanel1.Controls
                If (lista.Tag = cmbx.Tag) Then


                    Try

                        If (lista.Name = "kolicinaCombo" + (cmbx.Tag + 1).ToString) Then
                            kolicina = lista.Text
                        End If
                    Catch
                    End Try

                    Try


                        If (lista.Name = "cijenaCombo" + (cmbx.Tag + 1).ToString) Then
                            cijena = lista.Text
                        End If
                    Catch
                    End Try

                    Try

                        If (ComboBox10.SelectedIndex = 0) Then
                            pdv = True
                        ElseIf (ComboBox10.SelectedIndex = 1) Then
                            pdv = False
                        End If
                    Catch
                    End Try

                    Try

                        If (lista.Name = "rabatCombo" + (cmbx.Tag + 1).ToString) Then
                            rabat = lista.Text
                        End If
                    Catch
                    End Try


                    MsgBox(rabat, pdv.ToString, cijena.ToString)


                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Function GetAll(Control As Control, Type As Type) As IEnumerable(Of Control)
        Dim Controls = Control.Controls.Cast(Of Control)()
        Return Controls.SelectMany(Function(x) GetAll(x, Type)).Concat(Controls).Where(Function(y) y.GetType = Type)
    End Function
End Class

