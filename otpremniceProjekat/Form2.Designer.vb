<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.components = New System.ComponentModel.Container()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataSet1 = New otpremniceProjekat.DataSet1()
        Me.UslugeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UslugeTableAdapter = New otpremniceProjekat.DataSet1TableAdapters.UslugeTableAdapter()
        Me.RednibrojDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NazivrobeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JedmjereDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KolicinaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CijenaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RabatDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PdvDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.OtpremnicabrDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IznosDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UslugeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RednibrojDataGridViewTextBoxColumn, Me.NazivrobeDataGridViewTextBoxColumn, Me.JedmjereDataGridViewTextBoxColumn, Me.KolicinaDataGridViewTextBoxColumn, Me.CijenaDataGridViewTextBoxColumn, Me.RabatDataGridViewCheckBoxColumn, Me.PdvDataGridViewCheckBoxColumn, Me.OtpremnicabrDataGridViewTextBoxColumn, Me.IznosDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.UslugeBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(146, 101)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(581, 290)
        Me.DataGridView1.TabIndex = 0
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UslugeBindingSource
        '
        Me.UslugeBindingSource.DataMember = "Usluge"
        Me.UslugeBindingSource.DataSource = Me.DataSet1
        '
        'UslugeTableAdapter
        '
        Me.UslugeTableAdapter.ClearBeforeFill = True
        '
        'RednibrojDataGridViewTextBoxColumn
        '
        Me.RednibrojDataGridViewTextBoxColumn.DataPropertyName = "redni_broj"
        Me.RednibrojDataGridViewTextBoxColumn.HeaderText = "redni_broj"
        Me.RednibrojDataGridViewTextBoxColumn.Name = "RednibrojDataGridViewTextBoxColumn"
        '
        'NazivrobeDataGridViewTextBoxColumn
        '
        Me.NazivrobeDataGridViewTextBoxColumn.DataPropertyName = "naziv_robe"
        Me.NazivrobeDataGridViewTextBoxColumn.HeaderText = "naziv_robe"
        Me.NazivrobeDataGridViewTextBoxColumn.Name = "NazivrobeDataGridViewTextBoxColumn"
        '
        'JedmjereDataGridViewTextBoxColumn
        '
        Me.JedmjereDataGridViewTextBoxColumn.DataPropertyName = "jed_mjere"
        Me.JedmjereDataGridViewTextBoxColumn.HeaderText = "jed_mjere"
        Me.JedmjereDataGridViewTextBoxColumn.Name = "JedmjereDataGridViewTextBoxColumn"
        '
        'KolicinaDataGridViewTextBoxColumn
        '
        Me.KolicinaDataGridViewTextBoxColumn.DataPropertyName = "kolicina"
        Me.KolicinaDataGridViewTextBoxColumn.HeaderText = "kolicina"
        Me.KolicinaDataGridViewTextBoxColumn.Name = "KolicinaDataGridViewTextBoxColumn"
        '
        'CijenaDataGridViewTextBoxColumn
        '
        Me.CijenaDataGridViewTextBoxColumn.DataPropertyName = "cijena"
        Me.CijenaDataGridViewTextBoxColumn.HeaderText = "cijena"
        Me.CijenaDataGridViewTextBoxColumn.Name = "CijenaDataGridViewTextBoxColumn"
        '
        'RabatDataGridViewCheckBoxColumn
        '
        Me.RabatDataGridViewCheckBoxColumn.DataPropertyName = "rabat"
        Me.RabatDataGridViewCheckBoxColumn.HeaderText = "rabat"
        Me.RabatDataGridViewCheckBoxColumn.Name = "RabatDataGridViewCheckBoxColumn"
        '
        'PdvDataGridViewCheckBoxColumn
        '
        Me.PdvDataGridViewCheckBoxColumn.DataPropertyName = "pdv"
        Me.PdvDataGridViewCheckBoxColumn.HeaderText = "pdv"
        Me.PdvDataGridViewCheckBoxColumn.Name = "PdvDataGridViewCheckBoxColumn"
        '
        'OtpremnicabrDataGridViewTextBoxColumn
        '
        Me.OtpremnicabrDataGridViewTextBoxColumn.DataPropertyName = "otpremnica_br"
        Me.OtpremnicabrDataGridViewTextBoxColumn.HeaderText = "otpremnica_br"
        Me.OtpremnicabrDataGridViewTextBoxColumn.Name = "OtpremnicabrDataGridViewTextBoxColumn"
        '
        'IznosDataGridViewTextBoxColumn
        '
        Me.IznosDataGridViewTextBoxColumn.DataPropertyName = "iznos"
        Me.IznosDataGridViewTextBoxColumn.HeaderText = "iznos"
        Me.IznosDataGridViewTextBoxColumn.Name = "IznosDataGridViewTextBoxColumn"
        Me.IznosDataGridViewTextBoxColumn.ReadOnly = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UslugeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataSet1 As DataSet1
    Friend WithEvents UslugeBindingSource As BindingSource
    Friend WithEvents UslugeTableAdapter As DataSet1TableAdapters.UslugeTableAdapter
    Friend WithEvents RednibrojDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NazivrobeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents JedmjereDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents KolicinaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CijenaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RabatDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents PdvDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents OtpremnicabrDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IznosDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
