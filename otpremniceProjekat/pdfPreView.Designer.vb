<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class servispdf
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
        Me.servisbrowser = New System.Windows.Forms.WebBrowser()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'servisbrowser
        '
        Me.servisbrowser.Location = New System.Drawing.Point(23, 4)
        Me.servisbrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.servisbrowser.Name = "servisbrowser"
        Me.servisbrowser.ScrollBarsEnabled = False
        Me.servisbrowser.Size = New System.Drawing.Size(768, 1100)
        Me.servisbrowser.TabIndex = 0
        Me.servisbrowser.WebBrowserShortcutsEnabled = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(810, 179)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(184, 56)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "NAZAD"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.otpremniceProjekat.My.Resources.Resources.saveeeeeeee1
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(810, 107)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(187, 56)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "SACUVAJ"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'servispdf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1009, 1100)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.servisbrowser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "servispdf"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "pdfPreView"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents servisbrowser As WebBrowser
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
