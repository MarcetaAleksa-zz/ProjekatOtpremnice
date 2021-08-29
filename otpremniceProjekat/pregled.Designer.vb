<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class pregled
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pregled))
        Dim Panel4 As System.Windows.Forms.Panel
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Nazad = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.emailTB = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.telefonTB = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.datumITB = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.datumPTB = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.musterijaTB = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.serviserTB = New System.Windows.Forms.TextBox()
        Me.DatumDanasLB = New System.Windows.Forms.Label()
        Me.idServisaCB = New System.Windows.Forms.ComboBox()
        Me.uslugaTB = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.opisServisaTB = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.stanjeServisaTB = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Panel4 = New System.Windows.Forms.Panel()
        Me.Panel8.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'Nazad
        '
        Me.Nazad.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Nazad.BackgroundImage = CType(resources.GetObject("Nazad.BackgroundImage"), System.Drawing.Image)
        Me.Nazad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Nazad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Nazad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Nazad.Location = New System.Drawing.Point(1288, 3)
        Me.Nazad.Name = "Nazad"
        Me.Nazad.Size = New System.Drawing.Size(45, 39)
        Me.Nazad.TabIndex = 21
        Me.Nazad.UseVisualStyleBackColor = False
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.SystemColors.Control
        Me.Panel8.Controls.Add(Me.emailTB)
        Me.Panel8.Location = New System.Drawing.Point(171, 286)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(339, 36)
        Me.Panel8.TabIndex = 95
        '
        'emailTB
        '
        Me.emailTB.BackColor = System.Drawing.SystemColors.Control
        Me.emailTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.emailTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.emailTB.ForeColor = System.Drawing.Color.Black
        Me.emailTB.Location = New System.Drawing.Point(8, 4)
        Me.emailTB.Multiline = True
        Me.emailTB.Name = "emailTB"
        Me.emailTB.ReadOnly = True
        Me.emailTB.Size = New System.Drawing.Size(319, 29)
        Me.emailTB.TabIndex = 7
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label18.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.Control
        Me.Label18.Location = New System.Drawing.Point(101, 70)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(66, 17)
        Me.Label18.TabIndex = 79
        Me.Label18.Text = "SERVISER:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.Control
        Me.Label16.Location = New System.Drawing.Point(27, 110)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(140, 17)
        Me.Label16.TabIndex = 78
        Me.Label16.Text = "OTPREMI NA NASLOV:"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.SystemColors.Control
        Me.Panel9.Controls.Add(Me.telefonTB)
        Me.Panel9.Location = New System.Drawing.Point(171, 240)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(339, 36)
        Me.Panel9.TabIndex = 94
        '
        'telefonTB
        '
        Me.telefonTB.BackColor = System.Drawing.SystemColors.Control
        Me.telefonTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.telefonTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.telefonTB.ForeColor = System.Drawing.Color.Black
        Me.telefonTB.Location = New System.Drawing.Point(7, 4)
        Me.telefonTB.Multiline = True
        Me.telefonTB.Name = "telefonTB"
        Me.telefonTB.ReadOnly = True
        Me.telefonTB.Size = New System.Drawing.Size(319, 32)
        Me.telefonTB.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.Control
        Me.Label15.Location = New System.Drawing.Point(55, 156)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(110, 17)
        Me.Label15.TabIndex = 84
        Me.Label15.Text = "DATUM PRIJEMA:"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.SystemColors.Control
        Me.Panel7.Controls.Add(Me.datumITB)
        Me.Panel7.Location = New System.Drawing.Point(173, 194)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(92, 36)
        Me.Panel7.TabIndex = 91
        '
        'datumITB
        '
        Me.datumITB.BackColor = System.Drawing.SystemColors.Control
        Me.datumITB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.datumITB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.datumITB.ForeColor = System.Drawing.Color.Black
        Me.datumITB.Location = New System.Drawing.Point(3, 4)
        Me.datumITB.Multiline = True
        Me.datumITB.Name = "datumITB"
        Me.datumITB.ReadOnly = True
        Me.datumITB.Size = New System.Drawing.Size(84, 27)
        Me.datumITB.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.Control
        Me.Label14.Location = New System.Drawing.Point(101, 249)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 17)
        Me.Label14.TabIndex = 83
        Me.Label14.Text = "TELEFON:"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.Control
        Me.Panel5.Controls.Add(Me.datumPTB)
        Me.Panel5.Location = New System.Drawing.Point(173, 148)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(92, 36)
        Me.Panel5.TabIndex = 87
        '
        'datumPTB
        '
        Me.datumPTB.BackColor = System.Drawing.SystemColors.Control
        Me.datumPTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.datumPTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.datumPTB.ForeColor = System.Drawing.Color.Black
        Me.datumPTB.Location = New System.Drawing.Point(4, 6)
        Me.datumPTB.Multiline = True
        Me.datumPTB.Name = "datumPTB"
        Me.datumPTB.ReadOnly = True
        Me.datumPTB.Size = New System.Drawing.Size(82, 26)
        Me.datumPTB.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.Control
        Me.Label13.Location = New System.Drawing.Point(103, 343)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 17)
        Me.Label13.TabIndex = 82
        Me.Label13.Text = "STANJE:"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.Controls.Add(Me.musterijaTB)
        Me.Panel3.Location = New System.Drawing.Point(173, 102)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(339, 36)
        Me.Panel3.TabIndex = 89
        '
        'musterijaTB
        '
        Me.musterijaTB.BackColor = System.Drawing.SystemColors.Control
        Me.musterijaTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.musterijaTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.musterijaTB.ForeColor = System.Drawing.Color.Black
        Me.musterijaTB.Location = New System.Drawing.Point(6, 5)
        Me.musterijaTB.Multiline = True
        Me.musterijaTB.Name = "musterijaTB"
        Me.musterijaTB.ReadOnly = True
        Me.musterijaTB.Size = New System.Drawing.Size(330, 26)
        Me.musterijaTB.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.Control
        Me.Label12.Location = New System.Drawing.Point(111, 294)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 17)
        Me.Label12.TabIndex = 81
        Me.Label12.Text = "EMAIL:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.serviserTB)
        Me.Panel2.Location = New System.Drawing.Point(173, 57)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(339, 36)
        Me.Panel2.TabIndex = 88
        '
        'serviserTB
        '
        Me.serviserTB.BackColor = System.Drawing.SystemColors.Control
        Me.serviserTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.serviserTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.serviserTB.ForeColor = System.Drawing.Color.Black
        Me.serviserTB.Location = New System.Drawing.Point(5, 4)
        Me.serviserTB.Multiline = True
        Me.serviserTB.Name = "serviserTB"
        Me.serviserTB.ReadOnly = True
        Me.serviserTB.Size = New System.Drawing.Size(330, 29)
        Me.serviserTB.TabIndex = 1
        '
        'DatumDanasLB
        '
        Me.DatumDanasLB.AutoSize = True
        Me.DatumDanasLB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.DatumDanasLB.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatumDanasLB.ForeColor = System.Drawing.SystemColors.Control
        Me.DatumDanasLB.Location = New System.Drawing.Point(46, 205)
        Me.DatumDanasLB.Name = "DatumDanasLB"
        Me.DatumDanasLB.Size = New System.Drawing.Size(119, 17)
        Me.DatumDanasLB.TabIndex = 80
        Me.DatumDanasLB.Text = "DATUM ISPORUKE:"
        '
        'idServisaCB
        '
        Me.idServisaCB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.idServisaCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.idServisaCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.idServisaCB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.idServisaCB.ForeColor = System.Drawing.Color.White
        Me.idServisaCB.FormattingEnabled = True
        Me.idServisaCB.Location = New System.Drawing.Point(173, 24)
        Me.idServisaCB.Name = "idServisaCB"
        Me.idServisaCB.Size = New System.Drawing.Size(64, 28)
        Me.idServisaCB.TabIndex = 20
        '
        'uslugaTB
        '
        Me.uslugaTB.BackColor = System.Drawing.SystemColors.Control
        Me.uslugaTB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.uslugaTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.uslugaTB.ForeColor = System.Drawing.Color.Black
        Me.uslugaTB.Location = New System.Drawing.Point(567, 58)
        Me.uslugaTB.Multiline = True
        Me.uslugaTB.Name = "uslugaTB"
        Me.uslugaTB.ReadOnly = True
        Me.uslugaTB.Size = New System.Drawing.Size(370, 441)
        Me.uslugaTB.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label17.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.Control
        Me.Label17.Location = New System.Drawing.Point(74, 26)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(93, 17)
        Me.Label17.TabIndex = 85
        Me.Label17.Text = "BROJ SERVISA:"
        '
        'opisServisaTB
        '
        Me.opisServisaTB.BackColor = System.Drawing.SystemColors.Control
        Me.opisServisaTB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.opisServisaTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.opisServisaTB.ForeColor = System.Drawing.Color.Black
        Me.opisServisaTB.Location = New System.Drawing.Point(979, 58)
        Me.opisServisaTB.Multiline = True
        Me.opisServisaTB.Name = "opisServisaTB"
        Me.opisServisaTB.ReadOnly = True
        Me.opisServisaTB.Size = New System.Drawing.Size(370, 441)
        Me.opisServisaTB.TabIndex = 9
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.Control
        Me.Label27.Location = New System.Drawing.Point(656, 26)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(184, 25)
        Me.Label27.TabIndex = 96
        Me.Label27.Text = "OPIS PROBLEMA"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.stanjeServisaTB)
        Me.Panel1.Location = New System.Drawing.Point(171, 335)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(92, 36)
        Me.Panel1.TabIndex = 98
        '
        'stanjeServisaTB
        '
        Me.stanjeServisaTB.BackColor = System.Drawing.SystemColors.Control
        Me.stanjeServisaTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.stanjeServisaTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.stanjeServisaTB.ForeColor = System.Drawing.Color.Black
        Me.stanjeServisaTB.Location = New System.Drawing.Point(3, 4)
        Me.stanjeServisaTB.Multiline = True
        Me.stanjeServisaTB.Name = "stanjeServisaTB"
        Me.stanjeServisaTB.ReadOnly = True
        Me.stanjeServisaTB.Size = New System.Drawing.Size(87, 28)
        Me.stanjeServisaTB.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.Control
        Me.Label11.Location = New System.Drawing.Point(974, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(391, 25)
        Me.Label11.TabIndex = 97
        Me.Label11.Text = "OPIS ODRADJENOG POSLA (STANJA)"
        '
        'Panel4
        '
        Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Panel4.Controls.Add(Me.Label11)
        Panel4.Controls.Add(Me.Panel1)
        Panel4.Controls.Add(Me.Label27)
        Panel4.Controls.Add(Me.opisServisaTB)
        Panel4.Controls.Add(Me.Label17)
        Panel4.Controls.Add(Me.uslugaTB)
        Panel4.Controls.Add(Me.idServisaCB)
        Panel4.Controls.Add(Me.DatumDanasLB)
        Panel4.Controls.Add(Me.Panel2)
        Panel4.Controls.Add(Me.Label12)
        Panel4.Controls.Add(Me.Panel3)
        Panel4.Controls.Add(Me.Label13)
        Panel4.Controls.Add(Me.Panel5)
        Panel4.Controls.Add(Me.Label14)
        Panel4.Controls.Add(Me.Panel7)
        Panel4.Controls.Add(Me.Label15)
        Panel4.Controls.Add(Me.Panel9)
        Panel4.Controls.Add(Me.Label16)
        Panel4.Controls.Add(Me.Label18)
        Panel4.Controls.Add(Me.Panel8)
        Panel4.Location = New System.Drawing.Point(4, 27)
        Panel4.Name = "Panel4"
        Panel4.Size = New System.Drawing.Size(1400, 515)
        Panel4.TabIndex = 99
        '
        'pregled
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1416, 554)
        Me.Controls.Add(Me.Nazad)
        Me.Controls.Add(Panel4)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "pregled"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "pregled"
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Nazad As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents emailTB As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents telefonTB As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents datumITB As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents datumPTB As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents musterijaTB As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents serviserTB As TextBox
    Friend WithEvents DatumDanasLB As Label
    Friend WithEvents idServisaCB As ComboBox
    Friend WithEvents uslugaTB As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents opisServisaTB As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents stanjeServisaTB As TextBox
    Friend WithEvents Label11 As Label
End Class
