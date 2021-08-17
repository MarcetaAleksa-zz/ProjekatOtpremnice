<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Medjuforma
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
        Me.NapraviOtpremnicu = New System.Windows.Forms.Button()
        Me.DodajRobu = New System.Windows.Forms.Button()
        Me.Administrativno = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'NapraviOtpremnicu
        '
        Me.NapraviOtpremnicu.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.NapraviOtpremnicu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NapraviOtpremnicu.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NapraviOtpremnicu.ForeColor = System.Drawing.SystemColors.Control
        Me.NapraviOtpremnicu.Location = New System.Drawing.Point(-1, -2)
        Me.NapraviOtpremnicu.Name = "NapraviOtpremnicu"
        Me.NapraviOtpremnicu.Size = New System.Drawing.Size(400, 200)
        Me.NapraviOtpremnicu.TabIndex = 0
        Me.NapraviOtpremnicu.Text = "OTPREMNICE"
        Me.NapraviOtpremnicu.UseVisualStyleBackColor = False
        '
        'DodajRobu
        '
        Me.DodajRobu.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.DodajRobu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DodajRobu.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DodajRobu.ForeColor = System.Drawing.SystemColors.Control
        Me.DodajRobu.Location = New System.Drawing.Point(395, -3)
        Me.DodajRobu.Name = "DodajRobu"
        Me.DodajRobu.Size = New System.Drawing.Size(403, 200)
        Me.DodajRobu.TabIndex = 1
        Me.DodajRobu.Text = "UNOS ROBE"
        Me.DodajRobu.UseVisualStyleBackColor = False
        '
        'Administrativno
        '
        Me.Administrativno.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Administrativno.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Administrativno.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Administrativno.ForeColor = System.Drawing.SystemColors.Control
        Me.Administrativno.Location = New System.Drawing.Point(-1, 196)
        Me.Administrativno.Name = "Administrativno"
        Me.Administrativno.Size = New System.Drawing.Size(400, 200)
        Me.Administrativno.TabIndex = 3
        Me.Administrativno.Text = "ADMINISTRATIVNA ZONA"
        Me.Administrativno.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.Control
        Me.Button1.Location = New System.Drawing.Point(395, 196)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(403, 200)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "NAZAD"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Medjuforma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(795, 395)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DodajRobu)
        Me.Controls.Add(Me.Administrativno)
        Me.Controls.Add(Me.NapraviOtpremnicu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Medjuforma"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Medjuforma"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NapraviOtpremnicu As Button
    Friend WithEvents DodajRobu As Button
    Friend WithEvents Administrativno As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Button1 As Button
End Class
