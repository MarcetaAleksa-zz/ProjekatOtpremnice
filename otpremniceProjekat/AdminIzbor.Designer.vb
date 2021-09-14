<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminIzbor
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
        Me.DodajRadnikaBT = New System.Windows.Forms.Button()
        Me.IzbrisiIzmjeniRadnikaTB = New System.Windows.Forms.Button()
        Me.NazadBT = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'DodajRadnikaBT
        '
        Me.DodajRadnikaBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.DodajRadnikaBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DodajRadnikaBT.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.DodajRadnikaBT.ForeColor = System.Drawing.Color.White
        Me.DodajRadnikaBT.Location = New System.Drawing.Point(1, -3)
        Me.DodajRadnikaBT.Name = "DodajRadnikaBT"
        Me.DodajRadnikaBT.Size = New System.Drawing.Size(134, 191)
        Me.DodajRadnikaBT.TabIndex = 0
        Me.DodajRadnikaBT.Text = "DODAJ RADNIKA"
        Me.DodajRadnikaBT.UseVisualStyleBackColor = False
        '
        'IzbrisiIzmjeniRadnikaTB
        '
        Me.IzbrisiIzmjeniRadnikaTB.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.IzbrisiIzmjeniRadnikaTB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IzbrisiIzmjeniRadnikaTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.IzbrisiIzmjeniRadnikaTB.ForeColor = System.Drawing.Color.White
        Me.IzbrisiIzmjeniRadnikaTB.Location = New System.Drawing.Point(133, -3)
        Me.IzbrisiIzmjeniRadnikaTB.Name = "IzbrisiIzmjeniRadnikaTB"
        Me.IzbrisiIzmjeniRadnikaTB.Size = New System.Drawing.Size(134, 191)
        Me.IzbrisiIzmjeniRadnikaTB.TabIndex = 1
        Me.IzbrisiIzmjeniRadnikaTB.Text = "IZMJENI/IZBRISI RADNIKA"
        Me.IzbrisiIzmjeniRadnikaTB.UseVisualStyleBackColor = False
        '
        'NazadBT
        '
        Me.NazadBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.NazadBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NazadBT.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.NazadBT.ForeColor = System.Drawing.Color.White
        Me.NazadBT.Location = New System.Drawing.Point(1, 188)
        Me.NazadBT.Name = "NazadBT"
        Me.NazadBT.Size = New System.Drawing.Size(266, 45)
        Me.NazadBT.TabIndex = 2
        Me.NazadBT.Text = "NAZAD"
        Me.NazadBT.UseVisualStyleBackColor = False
        '
        'AdminIzbor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(267, 233)
        Me.Controls.Add(Me.NazadBT)
        Me.Controls.Add(Me.IzbrisiIzmjeniRadnikaTB)
        Me.Controls.Add(Me.DodajRadnikaBT)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AdminIzbor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AdminIzbor"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DodajRadnikaBT As Button
    Friend WithEvents IzbrisiIzmjeniRadnikaTB As Button
    Friend WithEvents NazadBT As Button
End Class
