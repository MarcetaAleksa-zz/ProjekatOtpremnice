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
        Me.NapraviOtpremnicu = New System.Windows.Forms.Button()
        Me.DodajRobu = New System.Windows.Forms.Button()
        Me.PregledOtpremnica = New System.Windows.Forms.Button()
        Me.Administrativno = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'NapraviOtpremnicu
        '
        Me.NapraviOtpremnicu.Location = New System.Drawing.Point(99, 61)
        Me.NapraviOtpremnicu.Name = "NapraviOtpremnicu"
        Me.NapraviOtpremnicu.Size = New System.Drawing.Size(143, 119)
        Me.NapraviOtpremnicu.TabIndex = 0
        Me.NapraviOtpremnicu.Text = "Napravi novu otpremnicu"
        Me.NapraviOtpremnicu.UseVisualStyleBackColor = True
        '
        'DodajRobu
        '
        Me.DodajRobu.Location = New System.Drawing.Point(553, 61)
        Me.DodajRobu.Name = "DodajRobu"
        Me.DodajRobu.Size = New System.Drawing.Size(143, 123)
        Me.DodajRobu.TabIndex = 1
        Me.DodajRobu.Text = "Dodaj Robu"
        Me.DodajRobu.UseVisualStyleBackColor = True
        '
        'PregledOtpremnica
        '
        Me.PregledOtpremnica.Location = New System.Drawing.Point(99, 237)
        Me.PregledOtpremnica.Name = "PregledOtpremnica"
        Me.PregledOtpremnica.Size = New System.Drawing.Size(146, 119)
        Me.PregledOtpremnica.TabIndex = 2
        Me.PregledOtpremnica.Text = "Pregled Otpremnica"
        Me.PregledOtpremnica.UseVisualStyleBackColor = True
        '
        'Administrativno
        '
        Me.Administrativno.Location = New System.Drawing.Point(553, 237)
        Me.Administrativno.Name = "Administrativno"
        Me.Administrativno.Size = New System.Drawing.Size(143, 119)
        Me.Administrativno.TabIndex = 3
        Me.Administrativno.Text = "Administrativna Zona"
        Me.Administrativno.UseVisualStyleBackColor = True
        '
        'Medjuforma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Administrativno)
        Me.Controls.Add(Me.PregledOtpremnica)
        Me.Controls.Add(Me.DodajRobu)
        Me.Controls.Add(Me.NapraviOtpremnicu)
        Me.Name = "Medjuforma"
        Me.Text = "Medjuforma"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NapraviOtpremnicu As Button
    Friend WithEvents DodajRobu As Button
    Friend WithEvents PregledOtpremnica As Button
    Friend WithEvents Administrativno As Button
End Class
