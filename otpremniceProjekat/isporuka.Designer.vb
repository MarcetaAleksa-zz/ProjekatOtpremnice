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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BrojServisaCB = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OtpremaTB = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.StanjeCB = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.datumtb = New System.Windows.Forms.TextBox()
        Me.SpasiIzmjeneBT = New System.Windows.Forms.Button()
        Me.OpisTB = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.EmailTB = New System.Windows.Forms.TextBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TelefonTB = New System.Windows.Forms.TextBox()
        Me.StatusServisaTB = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.DatumDanasLB = New System.Windows.Forms.Label()
        Me.DatumDTB = New System.Windows.Forms.TextBox()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
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
        Me.NazadBT.Location = New System.Drawing.Point(829, 463)
        Me.NazadBT.Name = "NazadBT"
        Me.NazadBT.Size = New System.Drawing.Size(45, 39)
        Me.NazadBT.TabIndex = 0
        Me.NazadBT.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Panel2.Controls.Add(Me.ServiserTB)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(12, 54)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(262, 34)
        Me.Panel2.TabIndex = 4
        '
        'ServiserTB
        '
        Me.ServiserTB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.ServiserTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ServiserTB.ForeColor = System.Drawing.Color.White
        Me.ServiserTB.Location = New System.Drawing.Point(53, 7)
        Me.ServiserTB.Multiline = True
        Me.ServiserTB.Name = "ServiserTB"
        Me.ServiserTB.ReadOnly = True
        Me.ServiserTB.Size = New System.Drawing.Size(199, 24)
        Me.ServiserTB.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(3, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Serviser: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Broj Servisa: "
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BrojServisaCB)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(262, 36)
        Me.Panel1.TabIndex = 3
        '
        'BrojServisaCB
        '
        Me.BrojServisaCB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.BrojServisaCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BrojServisaCB.ForeColor = System.Drawing.SystemColors.Control
        Me.BrojServisaCB.FormattingEnabled = True
        Me.BrojServisaCB.Items.AddRange(New Object() {"Isporuka"})
        Me.BrojServisaCB.Location = New System.Drawing.Point(78, 4)
        Me.BrojServisaCB.Name = "BrojServisaCB"
        Me.BrojServisaCB.Size = New System.Drawing.Size(53, 21)
        Me.BrojServisaCB.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.OtpremaTB)
        Me.Panel3.Location = New System.Drawing.Point(12, 104)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(262, 44)
        Me.Panel3.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(3, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Otpremi na naslov: "
        '
        'OtpremaTB
        '
        Me.OtpremaTB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.OtpremaTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OtpremaTB.ForeColor = System.Drawing.Color.White
        Me.OtpremaTB.Location = New System.Drawing.Point(100, 7)
        Me.OtpremaTB.Multiline = True
        Me.OtpremaTB.Name = "OtpremaTB"
        Me.OtpremaTB.ReadOnly = True
        Me.OtpremaTB.Size = New System.Drawing.Size(152, 24)
        Me.OtpremaTB.TabIndex = 1
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Panel6.Controls.Add(Me.StanjeCB)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Location = New System.Drawing.Point(8, 419)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(262, 27)
        Me.Panel6.TabIndex = 5
        '
        'StanjeCB
        '
        Me.StanjeCB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.StanjeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.StanjeCB.ForeColor = System.Drawing.SystemColors.Control
        Me.StanjeCB.FormattingEnabled = True
        Me.StanjeCB.Items.AddRange(New Object() {"Isporuka"})
        Me.StanjeCB.Location = New System.Drawing.Point(60, 4)
        Me.StanjeCB.Name = "StanjeCB"
        Me.StanjeCB.Size = New System.Drawing.Size(113, 21)
        Me.StanjeCB.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(3, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Stanje:"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.datumtb)
        Me.Panel5.Location = New System.Drawing.Point(12, 167)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(262, 27)
        Me.Panel5.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(3, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Datum: "
        '
        'datumtb
        '
        Me.datumtb.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.datumtb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.datumtb.ForeColor = System.Drawing.SystemColors.Control
        Me.datumtb.Location = New System.Drawing.Point(53, 7)
        Me.datumtb.Name = "datumtb"
        Me.datumtb.ReadOnly = True
        Me.datumtb.Size = New System.Drawing.Size(66, 13)
        Me.datumtb.TabIndex = 1
        Me.datumtb.Text = "yyyy/mm/dd"
        '
        'SpasiIzmjeneBT
        '
        Me.SpasiIzmjeneBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.SpasiIzmjeneBT.BackgroundImage = Global.otpremniceProjekat.My.Resources.Resources.saveeeeeeee1
        Me.SpasiIzmjeneBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SpasiIzmjeneBT.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.SpasiIzmjeneBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SpasiIzmjeneBT.Location = New System.Drawing.Point(829, 9)
        Me.SpasiIzmjeneBT.Name = "SpasiIzmjeneBT"
        Me.SpasiIzmjeneBT.Size = New System.Drawing.Size(45, 39)
        Me.SpasiIzmjeneBT.TabIndex = 6
        Me.SpasiIzmjeneBT.UseVisualStyleBackColor = False
        '
        'OpisTB
        '
        Me.OpisTB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.OpisTB.ForeColor = System.Drawing.Color.White
        Me.OpisTB.Location = New System.Drawing.Point(280, 12)
        Me.OpisTB.Multiline = True
        Me.OpisTB.Name = "OpisTB"
        Me.OpisTB.ReadOnly = True
        Me.OpisTB.Size = New System.Drawing.Size(370, 182)
        Me.OpisTB.TabIndex = 5
        Me.OpisTB.Text = "OPIS PROBLEMA"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Panel8)
        Me.Panel4.Controls.Add(Me.Panel9)
        Me.Panel4.Controls.Add(Me.StatusServisaTB)
        Me.Panel4.Controls.Add(Me.Panel7)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.SpasiIzmjeneBT)
        Me.Panel4.Controls.Add(Me.OpisTB)
        Me.Panel4.Controls.Add(Me.NazadBT)
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Location = New System.Drawing.Point(4, 13)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(888, 515)
        Me.Panel4.TabIndex = 7
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Panel8.Controls.Add(Me.Label7)
        Me.Panel8.Controls.Add(Me.EmailTB)
        Me.Panel8.Location = New System.Drawing.Point(18, 296)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(256, 29)
        Me.Panel8.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(3, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Email: "
        '
        'EmailTB
        '
        Me.EmailTB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.EmailTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.EmailTB.ForeColor = System.Drawing.Color.White
        Me.EmailTB.Location = New System.Drawing.Point(47, 7)
        Me.EmailTB.Multiline = True
        Me.EmailTB.Name = "EmailTB"
        Me.EmailTB.Size = New System.Drawing.Size(150, 19)
        Me.EmailTB.TabIndex = 1
        Me.EmailTB.Text = "Unesite broj email musterije"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Panel9.Controls.Add(Me.Label6)
        Me.Panel9.Controls.Add(Me.TelefonTB)
        Me.Panel9.Location = New System.Drawing.Point(18, 252)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(256, 29)
        Me.Panel9.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(3, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Telefon: "
        '
        'TelefonTB
        '
        Me.TelefonTB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.TelefonTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TelefonTB.ForeColor = System.Drawing.Color.White
        Me.TelefonTB.Location = New System.Drawing.Point(58, 7)
        Me.TelefonTB.Multiline = True
        Me.TelefonTB.Name = "TelefonTB"
        Me.TelefonTB.Size = New System.Drawing.Size(150, 19)
        Me.TelefonTB.TabIndex = 1
        Me.TelefonTB.Text = "Unesite broj telefona musterije"
        '
        'StatusServisaTB
        '
        Me.StatusServisaTB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.StatusServisaTB.ForeColor = System.Drawing.Color.Gray
        Me.StatusServisaTB.Location = New System.Drawing.Point(280, 252)
        Me.StatusServisaTB.Multiline = True
        Me.StatusServisaTB.Name = "StatusServisaTB"
        Me.StatusServisaTB.Size = New System.Drawing.Size(370, 250)
        Me.StatusServisaTB.TabIndex = 7
        Me.StatusServisaTB.Text = "OPIS ODRADJENOG POSLA (STANJA)"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Panel7.Controls.Add(Me.DatumDanasLB)
        Me.Panel7.Controls.Add(Me.DatumDTB)
        Me.Panel7.Location = New System.Drawing.Point(8, 463)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(262, 27)
        Me.Panel7.TabIndex = 5
        '
        'DatumDanasLB
        '
        Me.DatumDanasLB.AutoSize = True
        Me.DatumDanasLB.ForeColor = System.Drawing.SystemColors.Control
        Me.DatumDanasLB.Location = New System.Drawing.Point(3, 7)
        Me.DatumDanasLB.Name = "DatumDanasLB"
        Me.DatumDanasLB.Size = New System.Drawing.Size(84, 13)
        Me.DatumDanasLB.TabIndex = 2
        Me.DatumDanasLB.Text = "Trenutni datum: "
        '
        'DatumDTB
        '
        Me.DatumDTB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.DatumDTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DatumDTB.ForeColor = System.Drawing.SystemColors.Control
        Me.DatumDTB.Location = New System.Drawing.Point(93, 7)
        Me.DatumDTB.Name = "DatumDTB"
        Me.DatumDTB.ReadOnly = True
        Me.DatumDTB.Size = New System.Drawing.Size(66, 13)
        Me.DatumDTB.TabIndex = 1
        Me.DatumDTB.Text = "yyyy/mm/dd"
        '
        'isporuka
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(904, 540)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "isporuka"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "isporuka"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
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
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents OtpremaTB As TextBox
    Friend WithEvents Panel6 As Panel
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
End Class
