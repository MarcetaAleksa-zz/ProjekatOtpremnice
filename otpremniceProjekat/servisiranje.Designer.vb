<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class servisiranje
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(servisiranje))
        Me.OpisTB = New System.Windows.Forms.TextBox()
        Me.datumtb = New System.Windows.Forms.TextBox()
        Me.StanjeCB = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OtpremaTB = New System.Windows.Forms.TextBox()
        Me.ServiserCB = New System.Windows.Forms.ComboBox()
        Me.BrojServisaTB = New System.Windows.Forms.TextBox()
        Me.Nazad = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.EmailTB = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.TelefonTB = New System.Windows.Forms.TextBox()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel4.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpisTB
        '
        Me.OpisTB.BackColor = System.Drawing.SystemColors.Control
        Me.OpisTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.OpisTB.ForeColor = System.Drawing.Color.Black
        Me.OpisTB.Location = New System.Drawing.Point(590, 68)
        Me.OpisTB.Multiline = True
        Me.OpisTB.Name = "OpisTB"
        Me.OpisTB.Size = New System.Drawing.Size(370, 441)
        Me.OpisTB.TabIndex = 5
        '
        'datumtb
        '
        Me.datumtb.BackColor = System.Drawing.SystemColors.Control
        Me.datumtb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.datumtb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.datumtb.ForeColor = System.Drawing.Color.Black
        Me.datumtb.Location = New System.Drawing.Point(4, 9)
        Me.datumtb.Name = "datumtb"
        Me.datumtb.ReadOnly = True
        Me.datumtb.Size = New System.Drawing.Size(85, 19)
        Me.datumtb.TabIndex = 1
        Me.datumtb.Text = "yyyy/mm/dd"
        '
        'StanjeCB
        '
        Me.StanjeCB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.StanjeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.StanjeCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.StanjeCB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.StanjeCB.ForeColor = System.Drawing.SystemColors.Control
        Me.StanjeCB.FormattingEnabled = True
        Me.StanjeCB.Items.AddRange(New Object() {"Prijem"})
        Me.StanjeCB.Location = New System.Drawing.Point(171, 306)
        Me.StanjeCB.Name = "StanjeCB"
        Me.StanjeCB.Size = New System.Drawing.Size(113, 28)
        Me.StanjeCB.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Button1.BackgroundImage = Global.otpremniceProjekat.My.Resources.Resources.saveeeeeeee1
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(984, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(45, 39)
        Me.Button1.TabIndex = 6
        Me.Button1.UseVisualStyleBackColor = False
        '
        'OtpremaTB
        '
        Me.OtpremaTB.BackColor = System.Drawing.SystemColors.Control
        Me.OtpremaTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OtpremaTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.OtpremaTB.ForeColor = System.Drawing.Color.Gray
        Me.OtpremaTB.Location = New System.Drawing.Point(6, 6)
        Me.OtpremaTB.Multiline = True
        Me.OtpremaTB.Name = "OtpremaTB"
        Me.OtpremaTB.Size = New System.Drawing.Size(321, 33)
        Me.OtpremaTB.TabIndex = 1
        Me.OtpremaTB.Text = "Unesite ime i prezime musterije"
        '
        'ServiserCB
        '
        Me.ServiserCB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.ServiserCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ServiserCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ServiserCB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.ServiserCB.ForeColor = System.Drawing.SystemColors.Control
        Me.ServiserCB.FormattingEnabled = True
        Me.ServiserCB.Location = New System.Drawing.Point(177, 68)
        Me.ServiserCB.Name = "ServiserCB"
        Me.ServiserCB.Size = New System.Drawing.Size(246, 28)
        Me.ServiserCB.TabIndex = 3
        '
        'BrojServisaTB
        '
        Me.BrojServisaTB.BackColor = System.Drawing.SystemColors.Control
        Me.BrojServisaTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.BrojServisaTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.BrojServisaTB.ForeColor = System.Drawing.Color.Black
        Me.BrojServisaTB.Location = New System.Drawing.Point(4, 9)
        Me.BrojServisaTB.Name = "BrojServisaTB"
        Me.BrojServisaTB.ReadOnly = True
        Me.BrojServisaTB.Size = New System.Drawing.Size(39, 17)
        Me.BrojServisaTB.TabIndex = 1
        Me.BrojServisaTB.Text = "000"
        '
        'Nazad
        '
        Me.Nazad.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Nazad.BackgroundImage = CType(resources.GetObject("Nazad.BackgroundImage"), System.Drawing.Image)
        Me.Nazad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Nazad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Nazad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Nazad.Location = New System.Drawing.Point(914, 5)
        Me.Nazad.Name = "Nazad"
        Me.Nazad.Size = New System.Drawing.Size(45, 39)
        Me.Nazad.TabIndex = 0
        Me.Nazad.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Panel4.Controls.Add(Me.StanjeCB)
        Me.Panel4.Controls.Add(Me.ServiserCB)
        Me.Panel4.Controls.Add(Me.Panel15)
        Me.Panel4.Controls.Add(Me.Label27)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.Panel9)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.Panel10)
        Me.Panel4.Controls.Add(Me.Panel12)
        Me.Panel4.Controls.Add(Me.Panel13)
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Controls.Add(Me.OpisTB)
        Me.Panel4.Controls.Add(Me.Nazad)
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1057, 550)
        Me.Panel4.TabIndex = 6
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.SystemColors.Control
        Me.Panel15.Controls.Add(Me.BrojServisaTB)
        Me.Panel15.Location = New System.Drawing.Point(176, 18)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(33, 36)
        Me.Panel15.TabIndex = 96
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.Control
        Me.Label27.Location = New System.Drawing.Point(684, 40)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(184, 25)
        Me.Label27.TabIndex = 95
        Me.Label27.Text = "OPIS PROBLEMA"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Control
        Me.Label8.Location = New System.Drawing.Point(111, 262)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 17)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "EMAIL:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.Control
        Me.Label9.Location = New System.Drawing.Point(103, 311)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 17)
        Me.Label9.TabIndex = 81
        Me.Label9.Text = "STANJE:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.Control
        Me.Label10.Location = New System.Drawing.Point(101, 217)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 17)
        Me.Label10.TabIndex = 82
        Me.Label10.Text = "TELEFON:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.Control
        Me.Label11.Location = New System.Drawing.Point(111, 162)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 17)
        Me.Label11.TabIndex = 83
        Me.Label11.Text = "DATUM:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.Control
        Me.Label12.Location = New System.Drawing.Point(27, 114)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(140, 17)
        Me.Label12.TabIndex = 78
        Me.Label12.Text = "OTPREMI NA NASLOV:"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.SystemColors.Control
        Me.Panel9.Controls.Add(Me.EmailTB)
        Me.Panel9.Location = New System.Drawing.Point(171, 254)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(339, 36)
        Me.Panel9.TabIndex = 94
        '
        'EmailTB
        '
        Me.EmailTB.BackColor = System.Drawing.SystemColors.Control
        Me.EmailTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.EmailTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.EmailTB.ForeColor = System.Drawing.Color.Gray
        Me.EmailTB.Location = New System.Drawing.Point(6, 7)
        Me.EmailTB.Multiline = True
        Me.EmailTB.Name = "EmailTB"
        Me.EmailTB.Size = New System.Drawing.Size(316, 32)
        Me.EmailTB.TabIndex = 1
        Me.EmailTB.Text = "Unesite broj email musterije"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.Control
        Me.Label13.Location = New System.Drawing.Point(74, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 17)
        Me.Label13.TabIndex = 85
        Me.Label13.Text = "BROJ SERVISA:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.Control
        Me.Label14.Location = New System.Drawing.Point(101, 72)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 17)
        Me.Label14.TabIndex = 84
        Me.Label14.Text = "SERVISER:"
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.SystemColors.Control
        Me.Panel10.Controls.Add(Me.TelefonTB)
        Me.Panel10.Location = New System.Drawing.Point(171, 208)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(339, 36)
        Me.Panel10.TabIndex = 93
        '
        'TelefonTB
        '
        Me.TelefonTB.BackColor = System.Drawing.SystemColors.Control
        Me.TelefonTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TelefonTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TelefonTB.ForeColor = System.Drawing.Color.Gray
        Me.TelefonTB.Location = New System.Drawing.Point(9, 6)
        Me.TelefonTB.Multiline = True
        Me.TelefonTB.Name = "TelefonTB"
        Me.TelefonTB.Size = New System.Drawing.Size(313, 27)
        Me.TelefonTB.TabIndex = 1
        Me.TelefonTB.Text = "Unesite broj telefona musterije"
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.SystemColors.Control
        Me.Panel12.Controls.Add(Me.datumtb)
        Me.Panel12.Location = New System.Drawing.Point(173, 152)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(90, 36)
        Me.Panel12.TabIndex = 87
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.SystemColors.Control
        Me.Panel13.Controls.Add(Me.OtpremaTB)
        Me.Panel13.Location = New System.Drawing.Point(173, 106)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(339, 36)
        Me.Panel13.TabIndex = 89
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'servisiranje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ClientSize = New System.Drawing.Size(1054, 544)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "servisiranje"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "servisiranje"
        Me.TopMost = True
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OpisTB As TextBox
    Friend WithEvents datumtb As TextBox
    Friend WithEvents StanjeCB As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents OtpremaTB As TextBox
    Friend WithEvents ServiserCB As ComboBox
    Friend WithEvents BrojServisaTB As TextBox
    Friend WithEvents Nazad As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TelefonTB As TextBox
    Friend WithEvents EmailTB As TextBox
    Friend WithEvents Panel15 As Panel
    Friend WithEvents Label27 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Panel13 As Panel
End Class
