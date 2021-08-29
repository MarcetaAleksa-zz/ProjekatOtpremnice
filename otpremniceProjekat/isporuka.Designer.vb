<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class isporuka
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(isporuka))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.NazadBT = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ServiserTB = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BrojServisaCB = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.OtpremaTB = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.StanjeCB = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.datumtb = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SpasiIzmjeneBT = New System.Windows.Forms.Button()
        Me.OpisTB = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.DatumDanasLB = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.EmailTB = New System.Windows.Forms.TextBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.TelefonTB = New System.Windows.Forms.TextBox()
        Me.StatusServisaTB = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.DatumDTB = New System.Windows.Forms.TextBox()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'NazadBT
        '
        Me.NazadBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.NazadBT.BackgroundImage = CType(resources.GetObject("NazadBT.BackgroundImage"), System.Drawing.Image)
        Me.NazadBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.NazadBT.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.NazadBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NazadBT.Location = New System.Drawing.Point(1288, 3)
        Me.NazadBT.Name = "NazadBT"
        Me.NazadBT.Size = New System.Drawing.Size(45, 39)
        Me.NazadBT.TabIndex = 0
        Me.NazadBT.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.ServiserTB)
        Me.Panel2.Location = New System.Drawing.Point(173, 57)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(339, 36)
        Me.Panel2.TabIndex = 4
        '
        'ServiserTB
        '
        Me.ServiserTB.BackColor = System.Drawing.SystemColors.Control
        Me.ServiserTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ServiserTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ServiserTB.ForeColor = System.Drawing.Color.Black
        Me.ServiserTB.Location = New System.Drawing.Point(5, 6)
        Me.ServiserTB.Multiline = True
        Me.ServiserTB.Name = "ServiserTB"
        Me.ServiserTB.ReadOnly = True
        Me.ServiserTB.Size = New System.Drawing.Size(322, 24)
        Me.ServiserTB.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(101, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "SERVISER:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(74, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "BROJ SERVISA:"
        '
        'BrojServisaCB
        '
        Me.BrojServisaCB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.BrojServisaCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BrojServisaCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BrojServisaCB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.BrojServisaCB.ForeColor = System.Drawing.SystemColors.Control
        Me.BrojServisaCB.FormattingEnabled = True
        Me.BrojServisaCB.Items.AddRange(New Object() {"Isporuka"})
        Me.BrojServisaCB.Location = New System.Drawing.Point(173, 24)
        Me.BrojServisaCB.Name = "BrojServisaCB"
        Me.BrojServisaCB.Size = New System.Drawing.Size(60, 28)
        Me.BrojServisaCB.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.Controls.Add(Me.OtpremaTB)
        Me.Panel3.Location = New System.Drawing.Point(173, 102)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(339, 36)
        Me.Panel3.TabIndex = 4
        '
        'OtpremaTB
        '
        Me.OtpremaTB.BackColor = System.Drawing.SystemColors.Control
        Me.OtpremaTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OtpremaTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OtpremaTB.ForeColor = System.Drawing.Color.Black
        Me.OtpremaTB.Location = New System.Drawing.Point(5, 6)
        Me.OtpremaTB.Multiline = True
        Me.OtpremaTB.Name = "OtpremaTB"
        Me.OtpremaTB.ReadOnly = True
        Me.OtpremaTB.Size = New System.Drawing.Size(323, 24)
        Me.OtpremaTB.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(27, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "OTPREMI NA NASLOV:"
        '
        'StanjeCB
        '
        Me.StanjeCB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.StanjeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.StanjeCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.StanjeCB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.StanjeCB.ForeColor = System.Drawing.SystemColors.Control
        Me.StanjeCB.FormattingEnabled = True
        Me.StanjeCB.Items.AddRange(New Object() {"Isporuka"})
        Me.StanjeCB.Location = New System.Drawing.Point(171, 307)
        Me.StanjeCB.Name = "StanjeCB"
        Me.StanjeCB.Size = New System.Drawing.Size(92, 28)
        Me.StanjeCB.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(103, 307)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 17)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "STANJE:"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.Control
        Me.Panel5.Controls.Add(Me.datumtb)
        Me.Panel5.Location = New System.Drawing.Point(173, 148)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(92, 36)
        Me.Panel5.TabIndex = 4
        '
        'datumtb
        '
        Me.datumtb.BackColor = System.Drawing.SystemColors.Control
        Me.datumtb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.datumtb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.datumtb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.datumtb.Location = New System.Drawing.Point(6, 9)
        Me.datumtb.Name = "datumtb"
        Me.datumtb.ReadOnly = True
        Me.datumtb.Size = New System.Drawing.Size(82, 19)
        Me.datumtb.TabIndex = 1
        Me.datumtb.Text = "yyyy/mm/dd"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(111, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 17)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "DATUM:"
        '
        'SpasiIzmjeneBT
        '
        Me.SpasiIzmjeneBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.SpasiIzmjeneBT.BackgroundImage = Global.otpremniceProjekat.My.Resources.Resources.saveeeeeeee1
        Me.SpasiIzmjeneBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SpasiIzmjeneBT.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.SpasiIzmjeneBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SpasiIzmjeneBT.Location = New System.Drawing.Point(1339, 3)
        Me.SpasiIzmjeneBT.Name = "SpasiIzmjeneBT"
        Me.SpasiIzmjeneBT.Size = New System.Drawing.Size(45, 39)
        Me.SpasiIzmjeneBT.TabIndex = 6
        Me.SpasiIzmjeneBT.UseVisualStyleBackColor = False
        '
        'OpisTB
        '
        Me.OpisTB.BackColor = System.Drawing.SystemColors.Control
        Me.OpisTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.OpisTB.ForeColor = System.Drawing.Color.Black
        Me.OpisTB.Location = New System.Drawing.Point(567, 58)
        Me.OpisTB.Multiline = True
        Me.OpisTB.Name = "OpisTB"
        Me.OpisTB.ReadOnly = True
        Me.OpisTB.Size = New System.Drawing.Size(370, 441)
        Me.OpisTB.TabIndex = 5
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.Label27)
        Me.Panel4.Controls.Add(Me.StanjeCB)
        Me.Panel4.Controls.Add(Me.BrojServisaCB)
        Me.Panel4.Controls.Add(Me.DatumDanasLB)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Panel8)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Panel9)
        Me.Panel4.Controls.Add(Me.StatusServisaTB)
        Me.Panel4.Controls.Add(Me.Panel7)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.OpisTB)
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Location = New System.Drawing.Point(4, 27)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1400, 515)
        Me.Panel4.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Control
        Me.Label8.Location = New System.Drawing.Point(974, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(391, 25)
        Me.Label8.TabIndex = 77
        Me.Label8.Text = "OPIS ODRADJENOG POSLA (STANJA)"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.Control
        Me.Label27.Location = New System.Drawing.Point(656, 26)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(184, 25)
        Me.Label27.TabIndex = 77
        Me.Label27.Text = "OPIS PROBLEMA"
        '
        'DatumDanasLB
        '
        Me.DatumDanasLB.AutoSize = True
        Me.DatumDanasLB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.DatumDanasLB.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatumDanasLB.ForeColor = System.Drawing.SystemColors.Control
        Me.DatumDanasLB.Location = New System.Drawing.Point(37, 354)
        Me.DatumDanasLB.Name = "DatumDanasLB"
        Me.DatumDanasLB.Size = New System.Drawing.Size(121, 17)
        Me.DatumDanasLB.TabIndex = 2
        Me.DatumDanasLB.Text = "TRENUTNI DATUM:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(111, 258)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 17)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "EMAIL:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(101, 213)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 17)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "TELEFON:"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.SystemColors.Control
        Me.Panel8.Controls.Add(Me.EmailTB)
        Me.Panel8.Location = New System.Drawing.Point(171, 250)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(339, 36)
        Me.Panel8.TabIndex = 9
        '
        'EmailTB
        '
        Me.EmailTB.BackColor = System.Drawing.SystemColors.Control
        Me.EmailTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.EmailTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmailTB.ForeColor = System.Drawing.Color.Black
        Me.EmailTB.Location = New System.Drawing.Point(6, 7)
        Me.EmailTB.Multiline = True
        Me.EmailTB.Name = "EmailTB"
        Me.EmailTB.Size = New System.Drawing.Size(316, 24)
        Me.EmailTB.TabIndex = 1
        Me.EmailTB.Text = "Unesite broj email musterije"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.SystemColors.Control
        Me.Panel9.Controls.Add(Me.TelefonTB)
        Me.Panel9.Location = New System.Drawing.Point(171, 204)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(339, 36)
        Me.Panel9.TabIndex = 8
        '
        'TelefonTB
        '
        Me.TelefonTB.BackColor = System.Drawing.SystemColors.Control
        Me.TelefonTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TelefonTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TelefonTB.ForeColor = System.Drawing.Color.Black
        Me.TelefonTB.Location = New System.Drawing.Point(7, 7)
        Me.TelefonTB.Multiline = True
        Me.TelefonTB.Name = "TelefonTB"
        Me.TelefonTB.Size = New System.Drawing.Size(322, 19)
        Me.TelefonTB.TabIndex = 1
        Me.TelefonTB.Text = "Unesite broj telefona musterije"
        '
        'StatusServisaTB
        '
        Me.StatusServisaTB.BackColor = System.Drawing.SystemColors.Control
        Me.StatusServisaTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.StatusServisaTB.ForeColor = System.Drawing.Color.Black
        Me.StatusServisaTB.Location = New System.Drawing.Point(979, 58)
        Me.StatusServisaTB.Multiline = True
        Me.StatusServisaTB.Name = "StatusServisaTB"
        Me.StatusServisaTB.Size = New System.Drawing.Size(370, 441)
        Me.StatusServisaTB.TabIndex = 7
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.SystemColors.Control
        Me.Panel7.Controls.Add(Me.DatumDTB)
        Me.Panel7.Location = New System.Drawing.Point(171, 344)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(92, 36)
        Me.Panel7.TabIndex = 5
        '
        'DatumDTB
        '
        Me.DatumDTB.BackColor = System.Drawing.SystemColors.Control
        Me.DatumDTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DatumDTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.DatumDTB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.DatumDTB.Location = New System.Drawing.Point(5, 9)
        Me.DatumDTB.Name = "DatumDTB"
        Me.DatumDTB.ReadOnly = True
        Me.DatumDTB.Size = New System.Drawing.Size(82, 19)
        Me.DatumDTB.TabIndex = 1
        Me.DatumDTB.Text = "yyyy/mm/dd"
        '
        'isporuka
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1416, 554)
        Me.Controls.Add(Me.SpasiIzmjeneBT)
        Me.Controls.Add(Me.NazadBT)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "isporuka"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "isporuka"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents NazadBT As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents OtpremaTB As TextBox
    Friend WithEvents StanjeCB As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents datumtb As TextBox
    Friend WithEvents SpasiIzmjeneBT As Button
    Friend WithEvents OpisTB As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents ServiserTB As TextBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents DatumDanasLB As Label
    Friend WithEvents DatumDTB As TextBox
    Friend WithEvents BrojServisaCB As ComboBox
    Friend WithEvents StatusServisaTB As TextBox
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents EmailTB As TextBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents TelefonTB As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label27 As Label
End Class
