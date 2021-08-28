<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class serv
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
        Me.PrijemBT = New System.Windows.Forms.Button()
        Me.IsporukaBT = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.pregledBT = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'PrijemBT
        '
        Me.PrijemBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.PrijemBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PrijemBT.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrijemBT.ForeColor = System.Drawing.SystemColors.Control
        Me.PrijemBT.Location = New System.Drawing.Point(0, -1)
        Me.PrijemBT.Name = "PrijemBT"
        Me.PrijemBT.Size = New System.Drawing.Size(150, 165)
        Me.PrijemBT.TabIndex = 7
        Me.PrijemBT.Text = "PRIJEM"
        Me.PrijemBT.UseVisualStyleBackColor = False
        '
        'IsporukaBT
        '
        Me.IsporukaBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.IsporukaBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IsporukaBT.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsporukaBT.ForeColor = System.Drawing.SystemColors.Control
        Me.IsporukaBT.Location = New System.Drawing.Point(144, -1)
        Me.IsporukaBT.Name = "IsporukaBT"
        Me.IsporukaBT.Size = New System.Drawing.Size(150, 165)
        Me.IsporukaBT.TabIndex = 8
        Me.IsporukaBT.Text = "ISPORUKA"
        Me.IsporukaBT.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.Control
        Me.Button5.Location = New System.Drawing.Point(0, 160)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(433, 77)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "NAZAD"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'pregledBT
        '
        Me.pregledBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.pregledBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pregledBT.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pregledBT.ForeColor = System.Drawing.SystemColors.Control
        Me.pregledBT.Location = New System.Drawing.Point(291, -1)
        Me.pregledBT.Name = "pregledBT"
        Me.pregledBT.Size = New System.Drawing.Size(142, 165)
        Me.pregledBT.TabIndex = 11
        Me.pregledBT.Text = "PREGLED"
        Me.pregledBT.UseVisualStyleBackColor = False
        '
        'serv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.ClientSize = New System.Drawing.Size(433, 235)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.pregledBT)
        Me.Controls.Add(Me.IsporukaBT)
        Me.Controls.Add(Me.PrijemBT)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "serv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "serv"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PrijemBT As Button
    Friend WithEvents IsporukaBT As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents pregledBT As Button
End Class
