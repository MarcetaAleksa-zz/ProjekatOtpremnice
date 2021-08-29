Imports System.Data.SqlClient
Imports System.IO
Public Class dodajArtikal
    Private Sub dodajArtikal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If TextBox4.Text = "" Then
            Button7.Visible = False
            Button6.Visible = False
            Button4.Visible = False
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = "1.00"
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
                    TextBox3.Text = "1.00"
                    ComboBox1.SelectedIndex = -1
                    Button7.Visible = False
                    Button6.Visible = False
                    Button4.Visible = True
                End If
            Catch


            End Try
        End If

    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Medjuforma.Show()
        Me.Dispose()
    End Sub

    'Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox22.KeyPress

    '    If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") And Not Char.IsControl(e.KeyChar) Then
    '        e.Handled = True
    '    End If
    'End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress, TextBox2.KeyPress

        If Not (Char.IsDigit(e.KeyChar)) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click   'dodavanje
        If (TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" And ComboBox1.SelectedIndex <> -1) Then
            Dim odgovor = MsgBox("Da li zelite da unesete navedeni artikal?", vbYesNo, "Artikli")
            Select Case odgovor
                Case vbYes
                    Dim jedMjere
                    If ComboBox1.SelectedIndex = 0 Then
                        jedMjere = "True"
                    ElseIf ComboBox1.SelectedIndex = 1 Then
                        jedMjere = "False"
                    End If
                    Dim kommanden As New SqlCommand("INSERT INTO Inventar (id_robe, naziv_robe, kolicina, cijena, jed_mjere)
                            Values('" & TextBox4.Text & "', '" & TextBox1.Text & "', '" & TextBox2.Text & "','" & TextBox3.Text & "', '" & jedMjere.ToString & "') ", baza.konekcija)
                    kommanden.Connection.Open()
                    kommanden.ExecuteNonQuery()
                    kommanden.Connection.Close()
                    Me.Controls.Clear() 'removes all the controls on the form
                    InitializeComponent() 'load all the controls again
                    dodajArtikal_Load(e, e)
                Case vbNo
            End Select
        Else
            MsgBox("Popunite sva polja!", vbOKOnly, "Artikli")
        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click  'brisanje
        Dim odgovor = MsgBox("Da li zelite da izbrisete navedeni artikal?", vbYesNo)
        Select Case odgovor
            Case vbYes

                Dim kommanden As New SqlCommand("Delete  from Inventar where id_robe = '" & TextBox4.Text & "'", baza.konekcija)
                kommanden.Connection.Open()
                kommanden.ExecuteNonQuery()
                kommanden.Connection.Close()
                Me.Controls.Clear() 'removes all the controls on the form
                InitializeComponent() 'load all the controls again
                dodajArtikal_Load(e, e)
            Case vbNo
        End Select
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim odgovor = MsgBox("Da li zelite da azurirate navedeni artikal?", vbYesNo)
        If (TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" And ComboBox1.SelectedIndex <> -1 And TextBox2.Text > 0) Then
            Select Case odgovor
                Case vbYes
                    Dim jedMjere
                    If ComboBox1.SelectedIndex = 0 Then
                        jedMjere = "True"
                    ElseIf ComboBox1.SelectedIndex = 1 Then
                        jedMjere = "False"
                    End If
                    Dim kommanden As New SqlCommand("UPDATE Inventar SET naziv_robe =  '" & TextBox1.Text & "', kolicina=  '" & TextBox2.Text & "', cijena=  '" & TextBox3.Text & "' , jed_mjere=  '" & jedMjere.ToString & "' WHERE  id_robe = '" & TextBox4.Text & "'", baza.konekcija)
                    kommanden.Connection.Open()
                    kommanden.ExecuteNonQuery()
                    kommanden.Connection.Close()
                    Me.Controls.Clear() 'removes all the controls on the form
                    InitializeComponent() 'load all the controls again
                    dodajArtikal_Load(e, e)
                Case vbNo
            End Select
        Else
            MsgBox("Popunite sva polja!", vbOKOnly, "Artikli")
        End If

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)
        'Dim broj = TextBox22.Text
        'Try
        '    TextBox22.Text = broj.ToString("0.00")
        'Catch
        'End Try


    End Sub
End Class