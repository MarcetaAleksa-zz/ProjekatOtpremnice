Imports System.Data.SqlClient
Public Class IzmjeniIzbrisiRadnika
    Dim id As Integer
    Dim vozilo As Integer
    Dim nalog As Integer
    Dim pozicija As Integer

    Private Sub Nazad_Click(sender As Object, e As EventArgs) Handles Nazad.Click
        AdminIzbor.Show()
        Me.Dispose()
    End Sub

    Private Sub IzmjeniIzbrisiRadnika_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        delBT.Visible = False
        saveBT.Visible = False
        editBT.Visible = False
        Try
            Dim k As New SqlCommand("SELECT korisnicko_ime from zaposleni", baza.konekcija)
            Dim a As New SqlDataAdapter(k)
            Dim ds As New DataSet()
            a.Fill(ds)
            pretragaCB.DataSource = ds.Tables(0)
            pretragaCB.ValueMember = "korisnicko_ime"
            pretragaCB.DisplayMember = "korisnicko_ime"
            pretragaCB.SelectedIndex = -1

        Catch
        End Try

    End Sub
    Private Sub editBT_Click(sender As Object, e As EventArgs) Handles editBT.Click

        If delBT.Visible = False Then
            delBT.Visible = True
            saveBT.Visible = True
            imeTB.ReadOnly = False
            prezimeTB.ReadOnly = False
            userTB.ReadOnly = False
            adresaTB.ReadOnly = False
            emailTB.ReadOnly = False
            telefonTB.ReadOnly = False
            Dim tn As New SqlCommand("SELECT naziv from tipovi_naloga", baza.konekcija)
            Dim tna As New SqlDataAdapter(tn)
            Dim tds As New DataSet()
            tna.Fill(tds)
            tipNCB.DataSource = tds.Tables(0)
            tipNCB.DisplayMember = "naziv"
            Dim pz As New SqlCommand("Select radna_pozicija from radne_pozicije", baza.konekcija)
            Dim pza As New SqlDataAdapter(pz)
            Dim pzs As New DataSet()
            pza.Fill(pzs)
            tipPCB.DataSource = pzs.Tables(0)
            tipPCB.DisplayMember = "radna_pozicija"
            Dim sv As New SqlCommand("Select distinct sluz_voz from zaposleni", baza.konekcija)
            Dim sva As New SqlDataAdapter(sv)
            Dim svs As New DataSet()
            sva.Fill(svs)
            voziloCB.DropDownStyle = ComboBoxStyle.DropDown
            voziloCB.DataSource = svs.Tables(0)
            voziloCB.DisplayMember = "sluz_voz"
        Else
            delBT.Visible = False
            saveBT.Visible = False
            imeTB.ReadOnly = True
            prezimeTB.ReadOnly = True
            userTB.ReadOnly = True
            tipNCB.DropDownStyle = ComboBoxStyle.DropDownList
            tipPCB.DropDownStyle = ComboBoxStyle.DropDownList
            voziloCB.DropDownStyle = ComboBoxStyle.DropDownList
            adresaTB.ReadOnly = True
            emailTB.ReadOnly = True
            telefonTB.ReadOnly = True
            Me.Controls.Clear()
            InitializeComponent()
            IzmjeniIzbrisiRadnika_Load(e, e)

        End If

    End Sub
    Private Sub delBT_Click(sender As Object, e As EventArgs) Handles delBT.Click
        Try
            Dim k As New SqlCommand("", baza.konekcija)
            k.CommandText = "DELETE FROM zaposleni where id = " & id & ""
            k.Connection.Open()
            k.ExecuteNonQuery()
            k.Connection.Close()
            MessageBox.Show("Nalog uspjesno izbrisan.")
            Me.Controls.Clear()
            InitializeComponent()
            IzmjeniIzbrisiRadnika_Load(e, e)
        Catch
        End Try
    End Sub

    Private Sub pretragaCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles pretragaCB.SelectedIndexChanged
        Try
            Dim k As New SqlCommand("select zap.id, ime, prezime, korisnicko_ime, adresa, email, telefon, sluz_voz, naziv, rp.radna_pozicija from tipovi_naloga as tn left join zaposleni as zap on (tn.id = tip_naloga) inner join radne_pozicije as rp on (rp.id = zap.pozicija) where korisnicko_ime = '" + pretragaCB.SelectedValue + "'", baza.konekcija)
            Dim a As New SqlDataAdapter(k)
            Dim t As New DataTable()
            a.Fill(t)
            id = t.Rows(0)(0)
            imeTB.Text = t.Rows(0)(1)
            prezimeTB.Text = t.Rows(0)(2)
            userTB.Text = t.Rows(0)(3)
            adresaTB.Text = t.Rows(0)(4)
            emailTB.Text = t.Rows(0)(5)
            telefonTB.Text = t.Rows(0)(6)
            voziloCB.DataSource = t
            voziloCB.DisplayMember = "sluz_voz"
            voziloCB.ValueMember = "sluz_voz"
            tipNCB.DataSource = t
            tipNCB.DisplayMember = "naziv"
            tipNCB.ValueMember = "naziv"
            tipPCB.DataSource = t
            tipPCB.DisplayMember = "radna_pozicija"
            tipPCB.ValueMember = "radna_pozicija"
            If pretragaCB.SelectedIndex <> -1 Then
                editBT.Visible = True
            Else
                editBT.Visible = False
            End If
        Catch
        End Try

    End Sub

    Private Sub saveBT_Click(sender As Object, e As EventArgs) Handles saveBT.Click
        Dim k As New SqlCommand("", baza.konekcija)

        Try
            k.CommandText = "UPDATE zaposleni
  set korisnicko_ime = '" & userTB.Text.ToLower & "',  tip_naloga = " & tipNCB.SelectedIndex + 1 & ",  ime =  '" & imeTB.Text & "',  prezime = '" & prezimeTB.Text & "',  pozicija = " & tipPCB.SelectedIndex + 1 & ",  adresa =  '" & adresaTB.Text & "',  sluz_voz =  '" & voziloCB.Text & "',  email = '" & emailTB.Text & "' where id = " & id.ToString & ";"
            k.Connection.Open()
            k.ExecuteNonQuery()
            k.Connection.Close()
            MsgBox("Korisnik izmjenjen.", vbInformation)
            Me.Controls.Clear()
            InitializeComponent()
            IzmjeniIzbrisiRadnika_Load(e, e)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class