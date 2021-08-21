<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class servisiranje
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(servisiranje))
        Me.Nazad = New System.Windows.Forms.Button()
        Me.BrojServisaTB = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ServiserCB = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OtpremaTB = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.OpisTB = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Nazad
        '
        Me.Nazad.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Nazad.BackgroundImage = CType(resources.GetObject("Nazad.BackgroundImage"), System.Drawing.Image)
        Me.Nazad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Nazad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Nazad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Nazad.Location = New System.Drawing.Point(627, 117)
        Me.Nazad.Name = "Nazad"
        Me.Nazad.Size = New System.Drawing.Size(45, 39)
        Me.Nazad.TabIndex = 0
        Me.Nazad.UseVisualStyleBackColor = False
        '
        'BrojServisaTB
        '
        Me.BrojServisaTB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.BrojServisaTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.BrojServisaTB.ForeColor = System.Drawing.SystemColors.Control
        Me.BrojServisaTB.Location = New System.Drawing.Point(78, 7)
        Me.BrojServisaTB.Name = "BrojServisaTB"
        Me.BrojServisaTB.ReadOnly = True
        Me.BrojServisaTB.Size = New System.Drawing.Size(39, 13)
        Me.BrojServisaTB.TabIndex = 1
        Me.BrojServisaTB.Text = "000"
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
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.BrojServisaTB)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(262, 27)
        Me.Panel1.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Panel2.Controls.Add(Me.ServiserCB)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(12, 54)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(262, 27)
        Me.Panel2.TabIndex = 4
        '
        'ServiserCB
        '
        Me.ServiserCB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.ServiserCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ServiserCB.ForeColor = System.Drawing.SystemColors.Control
        Me.ServiserCB.FormattingEnabled = True
        Me.ServiserCB.Location = New System.Drawing.Point(60, 4)
        Me.ServiserCB.Name = "ServiserCB"
        Me.ServiserCB.Size = New System.Drawing.Size(113, 21)
        Me.ServiserCB.TabIndex = 3
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
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.OtpremaTB)
        Me.Panel3.Location = New System.Drawing.Point(12, 108)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(262, 44)
        Me.Panel3.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(11, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Otpremi na naslov: "
        '
        'OtpremaTB
        '
        Me.OtpremaTB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.OtpremaTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OtpremaTB.ForeColor = System.Drawing.SystemColors.Control
        Me.OtpremaTB.Location = New System.Drawing.Point(115, 7)
        Me.OtpremaTB.Multiline = True
        Me.OtpremaTB.Name = "OtpremaTB"
        Me.OtpremaTB.Size = New System.Drawing.Size(144, 24)
        Me.OtpremaTB.TabIndex = 1
        Me.OtpremaTB.Text = "Ime i Prezime"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Controls.Add(Me.OpisTB)
        Me.Panel4.Controls.Add(Me.Nazad)
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(675, 169)
        Me.Panel4.TabIndex = 5
        '
        'OpisTB
        '
        Me.OpisTB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.OpisTB.ForeColor = System.Drawing.SystemColors.Control
        Me.OpisTB.Location = New System.Drawing.Point(298, 12)
        Me.OpisTB.Multiline = True
        Me.OpisTB.Name = "OpisTB"
        Me.OpisTB.Size = New System.Drawing.Size(272, 140)
        Me.OpisTB.TabIndex = 5
        Me.OpisTB.Text = "OPIS PROBLEMA"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Button1.BackgroundImage = Global.otpremniceProjekat.My.Resources.Resources.saveeeeeeee1
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(576, 117)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(45, 39)
        Me.Button1.TabIndex = 6
        Me.Button1.UseVisualStyleBackColor = False
        '
        'servisiranje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(675, 168)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "servisiranje"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "servis"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Nazad As Button
    Friend WithEvents BrojServisaTB As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ServiserCB As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents OtpremaTB As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents OpisTB As TextBox
End Class
