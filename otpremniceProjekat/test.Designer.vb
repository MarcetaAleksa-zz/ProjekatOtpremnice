<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class test
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.snimi = New System.Windows.Forms.Button()
        Me.nazivPravnogLica = New System.Windows.Forms.Label()
        Me.adresaProdavca = New System.Windows.Forms.Label()
        Me.IB = New System.Windows.Forms.Label()
        Me.otpremiNaNaslov = New System.Windows.Forms.Label()
        Me.adresaTB = New System.Windows.Forms.TextBox()
        Me.ibTB = New System.Windows.Forms.TextBox()
        Me.adresaPrimalac = New System.Windows.Forms.Label()
        Me.nacinOtpreme = New System.Windows.Forms.Label()
        Me.reklamacije = New System.Windows.Forms.Label()
        Me.idOtpremnice = New System.Windows.Forms.Label()
        Me.IBKupac = New System.Windows.Forms.Label()
        Me.vozilo = New System.Windows.Forms.Label()
        Me.pdv = New System.Windows.Forms.Label()
        Me.izdavaoc = New System.Windows.Forms.Label()
        Me.primalac = New System.Windows.Forms.Label()
        Me.licna = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.otpremnicatb = New System.Windows.Forms.TextBox()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.datumtb = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.OtpremaTB = New System.Windows.Forms.ComboBox()
        Me.reklamacijatb = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.ComboBox7 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.redniBrojTB = New System.Windows.Forms.TextBox()
        Me.NaslovTB = New System.Windows.Forms.ComboBox()
        Me.iBKupcaComboBox = New System.Windows.Forms.ComboBox()
        Me.vozilotb = New System.Windows.Forms.ComboBox()
        Me.kupacAdresaComboBox = New System.Windows.Forms.ComboBox()
        Me.ComboBox10 = New System.Windows.Forms.ComboBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.SuspendLayout()
        '
        'snimi
        '
        Me.snimi.Location = New System.Drawing.Point(651, 695)
        Me.snimi.Name = "snimi"
        Me.snimi.Size = New System.Drawing.Size(140, 48)
        Me.snimi.TabIndex = 0
        Me.snimi.Text = "Sacuvaj otpremnicu"
        Me.snimi.UseVisualStyleBackColor = True
        '
        'nazivPravnogLica
        '
        Me.nazivPravnogLica.AutoSize = True
        Me.nazivPravnogLica.Location = New System.Drawing.Point(12, 9)
        Me.nazivPravnogLica.Name = "nazivPravnogLica"
        Me.nazivPravnogLica.Size = New System.Drawing.Size(98, 13)
        Me.nazivPravnogLica.TabIndex = 2
        Me.nazivPravnogLica.Text = "Naziv pravnog lica:"
        '
        'adresaProdavca
        '
        Me.adresaProdavca.AutoSize = True
        Me.adresaProdavca.Location = New System.Drawing.Point(12, 35)
        Me.adresaProdavca.Name = "adresaProdavca"
        Me.adresaProdavca.Size = New System.Drawing.Size(43, 13)
        Me.adresaProdavca.TabIndex = 3
        Me.adresaProdavca.Text = "Adresa:"
        '
        'IB
        '
        Me.IB.AutoSize = True
        Me.IB.Location = New System.Drawing.Point(12, 65)
        Me.IB.Name = "IB"
        Me.IB.Size = New System.Drawing.Size(20, 13)
        Me.IB.TabIndex = 4
        Me.IB.Text = "IB:"
        '
        'otpremiNaNaslov
        '
        Me.otpremiNaNaslov.AutoSize = True
        Me.otpremiNaNaslov.Location = New System.Drawing.Point(12, 96)
        Me.otpremiNaNaslov.Name = "otpremiNaNaslov"
        Me.otpremiNaNaslov.Size = New System.Drawing.Size(95, 13)
        Me.otpremiNaNaslov.TabIndex = 5
        Me.otpremiNaNaslov.Text = "Otpremi na naslov:"
        '
        'adresaTB
        '
        Me.adresaTB.AllowDrop = True
        Me.adresaTB.Location = New System.Drawing.Point(61, 32)
        Me.adresaTB.Multiline = True
        Me.adresaTB.Name = "adresaTB"
        Me.adresaTB.ReadOnly = True
        Me.adresaTB.Size = New System.Drawing.Size(349, 20)
        Me.adresaTB.TabIndex = 6
        Me.adresaTB.Text = "Vatrenih Jahaca BB"
        '
        'ibTB
        '
        Me.ibTB.Location = New System.Drawing.Point(38, 58)
        Me.ibTB.Multiline = True
        Me.ibTB.Name = "ibTB"
        Me.ibTB.ReadOnly = True
        Me.ibTB.Size = New System.Drawing.Size(372, 20)
        Me.ibTB.TabIndex = 7
        Me.ibTB.Text = "4428006942051"
        '
        'adresaPrimalac
        '
        Me.adresaPrimalac.AutoSize = True
        Me.adresaPrimalac.Location = New System.Drawing.Point(12, 127)
        Me.adresaPrimalac.Name = "adresaPrimalac"
        Me.adresaPrimalac.Size = New System.Drawing.Size(43, 13)
        Me.adresaPrimalac.TabIndex = 9
        Me.adresaPrimalac.Text = "Adresa:"
        '
        'nacinOtpreme
        '
        Me.nacinOtpreme.AutoSize = True
        Me.nacinOtpreme.Location = New System.Drawing.Point(13, 160)
        Me.nacinOtpreme.Name = "nacinOtpreme"
        Me.nacinOtpreme.Size = New System.Drawing.Size(79, 13)
        Me.nacinOtpreme.TabIndex = 10
        Me.nacinOtpreme.Text = "Nacin otpreme:"
        '
        'reklamacije
        '
        Me.reklamacije.AutoSize = True
        Me.reklamacije.Location = New System.Drawing.Point(13, 188)
        Me.reklamacije.Name = "reklamacije"
        Me.reklamacije.Size = New System.Drawing.Size(169, 13)
        Me.reklamacije.TabIndex = 11
        Me.reklamacije.Text = "Reklamacije se primaju u roku od: "
        '
        'idOtpremnice
        '
        Me.idOtpremnice.AutoSize = True
        Me.idOtpremnice.Location = New System.Drawing.Point(571, 53)
        Me.idOtpremnice.Name = "idOtpremnice"
        Me.idOtpremnice.Size = New System.Drawing.Size(76, 13)
        Me.idOtpremnice.TabIndex = 12
        Me.idOtpremnice.Text = "Otpremnica br."
        '
        'IBKupac
        '
        Me.IBKupac.AutoSize = True
        Me.IBKupac.Location = New System.Drawing.Point(428, 129)
        Me.IBKupac.Name = "IBKupac"
        Me.IBKupac.Size = New System.Drawing.Size(20, 13)
        Me.IBKupac.TabIndex = 13
        Me.IBKupac.Text = "IB:"
        '
        'vozilo
        '
        Me.vozilo.AutoSize = True
        Me.vozilo.Location = New System.Drawing.Point(428, 157)
        Me.vozilo.Name = "vozilo"
        Me.vozilo.Size = New System.Drawing.Size(81, 13)
        Me.vozilo.TabIndex = 14
        Me.vozilo.Text = "Reg. br. vozila: "
        '
        'pdv
        '
        Me.pdv.AutoSize = True
        Me.pdv.Location = New System.Drawing.Point(10, 695)
        Me.pdv.Name = "pdv"
        Me.pdv.Size = New System.Drawing.Size(95, 13)
        Me.pdv.TabIndex = 16
        Me.pdv.Text = "Cijena sa PDV-om:"
        '
        'izdavaoc
        '
        Me.izdavaoc.AutoSize = True
        Me.izdavaoc.Location = New System.Drawing.Point(7, 728)
        Me.izdavaoc.Name = "izdavaoc"
        Me.izdavaoc.Size = New System.Drawing.Size(36, 13)
        Me.izdavaoc.TabIndex = 17
        Me.izdavaoc.Text = "Izdao:"
        '
        'primalac
        '
        Me.primalac.AutoSize = True
        Me.primalac.Location = New System.Drawing.Point(325, 728)
        Me.primalac.Name = "primalac"
        Me.primalac.Size = New System.Drawing.Size(38, 13)
        Me.primalac.TabIndex = 18
        Me.primalac.Text = "Primio:"
        '
        'licna
        '
        Me.licna.AutoSize = True
        Me.licna.Location = New System.Drawing.Point(475, 730)
        Me.licna.Name = "licna"
        Me.licna.Size = New System.Drawing.Size(35, 13)
        Me.licna.TabIndex = 19
        Me.licna.Text = "LK br."
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(49, 725)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(162, 20)
        Me.TextBox9.TabIndex = 24
        '
        'otpremnicatb
        '
        Me.otpremnicatb.Location = New System.Drawing.Point(653, 50)
        Me.otpremnicatb.Name = "otpremnicatb"
        Me.otpremnicatb.Size = New System.Drawing.Size(100, 20)
        Me.otpremnicatb.TabIndex = 27
        '
        'TextBox13
        '
        Me.TextBox13.Location = New System.Drawing.Point(369, 725)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(100, 20)
        Me.TextBox13.TabIndex = 28
        '
        'TextBox14
        '
        Me.TextBox14.Location = New System.Drawing.Point(513, 725)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(100, 20)
        Me.TextBox14.TabIndex = 29
        '
        'datumtb
        '
        Me.datumtb.Location = New System.Drawing.Point(575, 12)
        Me.datumtb.Name = "datumtb"
        Me.datumtb.ReadOnly = True
        Me.datumtb.Size = New System.Drawing.Size(178, 20)
        Me.datumtb.TabIndex = 30
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(113, 5)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(297, 21)
        Me.ComboBox1.TabIndex = 35
        '
        'OtpremaTB
        '
        Me.OtpremaTB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.OtpremaTB.FormattingEnabled = True
        Me.OtpremaTB.Items.AddRange(New Object() {"Posta", "Sluzbeno vozilo", "Kupac preuzima"})
        Me.OtpremaTB.Location = New System.Drawing.Point(92, 157)
        Me.OtpremaTB.Name = "OtpremaTB"
        Me.OtpremaTB.Size = New System.Drawing.Size(318, 21)
        Me.OtpremaTB.TabIndex = 36
        '
        'reklamacijatb
        '
        Me.reklamacijatb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.reklamacijatb.FormattingEnabled = True
        Me.reklamacijatb.Items.AddRange(New Object() {"7", "14", "21"})
        Me.reklamacijatb.Location = New System.Drawing.Point(180, 185)
        Me.reklamacijatb.Name = "reklamacijatb"
        Me.reklamacijatb.Size = New System.Drawing.Size(121, 21)
        Me.reklamacijatb.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(308, 188)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "dana."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 220)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Redni Broj"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(93, 217)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "NAZIV ROBE / USLUGE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(375, 219)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Kolicina"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(428, 218)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Cijena"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(512, 217)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Iznos"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(308, 219)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "Jed. mjere"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(648, 220)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Rabat"
        '
        'ComboBox5
        '
        Me.ComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Location = New System.Drawing.Point(77, 237)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(224, 21)
        Me.ComboBox5.TabIndex = 47
        '
        'ComboBox6
        '
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Location = New System.Drawing.Point(431, 238)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(45, 21)
        Me.ComboBox6.TabIndex = 48
        '
        'ComboBox7
        '
        Me.ComboBox7.FormattingEnabled = True
        Me.ComboBox7.Location = New System.Drawing.Point(371, 239)
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(48, 21)
        Me.ComboBox7.TabIndex = 49
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(653, 240)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(31, 20)
        Me.TextBox1.TabIndex = 51
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(515, 238)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(100, 20)
        Me.TextBox6.TabIndex = 52
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(691, 244)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(15, 13)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "%"
        '
        'redniBrojTB
        '
        Me.redniBrojTB.Location = New System.Drawing.Point(15, 237)
        Me.redniBrojTB.Name = "redniBrojTB"
        Me.redniBrojTB.ReadOnly = True
        Me.redniBrojTB.Size = New System.Drawing.Size(40, 20)
        Me.redniBrojTB.TabIndex = 55
        '
        'NaslovTB
        '
        Me.NaslovTB.FormattingEnabled = True
        Me.NaslovTB.Location = New System.Drawing.Point(116, 88)
        Me.NaslovTB.Name = "NaslovTB"
        Me.NaslovTB.Size = New System.Drawing.Size(294, 21)
        Me.NaslovTB.TabIndex = 56
        '
        'iBKupcaComboBox
        '
        Me.iBKupcaComboBox.FormattingEnabled = True
        Me.iBKupcaComboBox.Location = New System.Drawing.Point(454, 124)
        Me.iBKupcaComboBox.Name = "iBKupcaComboBox"
        Me.iBKupcaComboBox.Size = New System.Drawing.Size(299, 21)
        Me.iBKupcaComboBox.TabIndex = 57
        '
        'vozilotb
        '
        Me.vozilotb.FormattingEnabled = True
        Me.vozilotb.Location = New System.Drawing.Point(515, 154)
        Me.vozilotb.Name = "vozilotb"
        Me.vozilotb.Size = New System.Drawing.Size(238, 21)
        Me.vozilotb.TabIndex = 58
        '
        'kupacAdresaComboBox
        '
        Me.kupacAdresaComboBox.FormattingEnabled = True
        Me.kupacAdresaComboBox.Location = New System.Drawing.Point(61, 120)
        Me.kupacAdresaComboBox.Name = "kupacAdresaComboBox"
        Me.kupacAdresaComboBox.Size = New System.Drawing.Size(349, 21)
        Me.kupacAdresaComboBox.TabIndex = 59
        '
        'ComboBox10
        '
        Me.ComboBox10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox10.FormattingEnabled = True
        Me.ComboBox10.Items.AddRange(New Object() {"Da", "Ne"})
        Me.ComboBox10.Location = New System.Drawing.Point(111, 695)
        Me.ComboBox10.Name = "ComboBox10"
        Me.ComboBox10.Size = New System.Drawing.Size(100, 21)
        Me.ComboBox10.TabIndex = 60
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(311, 239)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(54, 20)
        Me.TextBox2.TabIndex = 61
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoScroll = True
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(8, 273)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 0, 20, 0)
        Me.TableLayoutPanel1.RowCount = 15
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(745, 385)
        Me.TableLayoutPanel1.TabIndex = 62
        '
        'test
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 755)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.ComboBox10)
        Me.Controls.Add(Me.kupacAdresaComboBox)
        Me.Controls.Add(Me.vozilotb)
        Me.Controls.Add(Me.iBKupcaComboBox)
        Me.Controls.Add(Me.NaslovTB)
        Me.Controls.Add(Me.redniBrojTB)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ComboBox7)
        Me.Controls.Add(Me.ComboBox6)
        Me.Controls.Add(Me.ComboBox5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.reklamacijatb)
        Me.Controls.Add(Me.OtpremaTB)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.datumtb)
        Me.Controls.Add(Me.TextBox14)
        Me.Controls.Add(Me.TextBox13)
        Me.Controls.Add(Me.otpremnicatb)
        Me.Controls.Add(Me.TextBox9)
        Me.Controls.Add(Me.licna)
        Me.Controls.Add(Me.primalac)
        Me.Controls.Add(Me.izdavaoc)
        Me.Controls.Add(Me.pdv)
        Me.Controls.Add(Me.vozilo)
        Me.Controls.Add(Me.IBKupac)
        Me.Controls.Add(Me.idOtpremnice)
        Me.Controls.Add(Me.reklamacije)
        Me.Controls.Add(Me.nacinOtpreme)
        Me.Controls.Add(Me.adresaPrimalac)
        Me.Controls.Add(Me.ibTB)
        Me.Controls.Add(Me.adresaTB)
        Me.Controls.Add(Me.otpremiNaNaslov)
        Me.Controls.Add(Me.IB)
        Me.Controls.Add(Me.adresaProdavca)
        Me.Controls.Add(Me.nazivPravnogLica)
        Me.Controls.Add(Me.snimi)
        Me.Name = "test"
        Me.Text = "test"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents snimi As Button
    Friend WithEvents nazivPravnogLica As Label
    Friend WithEvents adresaProdavca As Label
    Friend WithEvents IB As Label
    Friend WithEvents otpremiNaNaslov As Label
    Friend WithEvents adresaTB As TextBox
    Friend WithEvents ibTB As TextBox
    Friend WithEvents adresaPrimalac As Label
    Friend WithEvents nacinOtpreme As Label
    Friend WithEvents reklamacije As Label
    Friend WithEvents idOtpremnice As Label
    Friend WithEvents IBKupac As Label
    Friend WithEvents vozilo As Label
    Friend WithEvents pdv As Label
    Friend WithEvents izdavaoc As Label
    Friend WithEvents primalac As Label
    Friend WithEvents licna As Label
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents otpremnicatb As TextBox
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents TextBox14 As TextBox
    Friend WithEvents datumtb As TextBox

    Friend WithEvents ZaposleniBindingSource1 As BindingSource
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents OtpremaTB As ComboBox
    Friend WithEvents reklamacijatb As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ComboBox5 As ComboBox
    Friend WithEvents ComboBox6 As ComboBox
    Friend WithEvents ComboBox7 As ComboBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents redniBrojTB As TextBox
    Friend WithEvents NaslovTB As ComboBox
    Friend WithEvents iBKupcaComboBox As ComboBox
    Friend WithEvents vozilotb As ComboBox
    Friend WithEvents kupacAdresaComboBox As ComboBox
    Friend WithEvents ComboBox10 As ComboBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
