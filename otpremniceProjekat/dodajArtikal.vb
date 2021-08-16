Imports System.Data.SqlClient
Imports System.IO
Public Class dodajArtikal
    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub dodajArtikal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If TextBox4.Text = "" Then
            Button7.Visible = False
            Button6.Visible = False
            Button4.Visible = False
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            ComboBox1.SelectedIndex = -1

        Else
            Try
                Dim kaCommand As New SqlCommand("Select * from Inventar WHERE id_robe = '" & TextBox4.Text & "' ", baza.konekcija)
                Dim kaadapter As New SqlDataAdapter(kaCommand)
                Dim kads As New DataTable()

                kaadapter.Fill(kads)
                If kads.Rows.Count > 0 Then
                    TextBox1.Text = kads.Rows(0)(1)
                    TextBox2.Text = kads.Rows(0)(2)
                    Dim cijenaDvijeDec = kads.Rows(0)(3)
                    cijenaDvijeDec = Format(Val(cijenaDvijeDec), "0.00")
                    TextBox3.Text = cijenaDvijeDec.ToString
                    If kads.Rows(0)(4) = True Then
                        ComboBox1.SelectedIndex = 0
                    ElseIf kads.Rows(0)(4) = False Then
                        ComboBox1.SelectedIndex = 1
                    End If
                    Button7.Visible = True
                    Button6.Visible = True
                    Button4.Visible = False
                Else
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    ComboBox1.SelectedIndex = -1
                    Button7.Visible = False
                    Button6.Visible = False
                    Button4.Visible = True
                End If
            Catch


            End Try
        End If

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Medjuforma.Show()
        Me.Dispose()
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress, TextBox3.KeyPress, TextBox2.KeyPress
        'Dim KeyAscii As Integer = Asc(e.KeyChar)
        'Select Case KeyAscii
        '    Case 8, 27, 48 To 57, 9
        '    Case Else
        '        KeyAscii = 0
        'End Select

        'If KeyAscii = 0 Then
        '    e.Handled = True
        'Else
        '    e.Handled = False
        'End If
        'e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class