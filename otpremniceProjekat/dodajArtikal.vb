Public Class dodajArtikal
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        Medjuforma.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'provjera za svaki onChange event na textbox od barkoda da li se nalazi takav barkod u bazi
        'ako da onda odraditi dole navedeno na loadforme 
        'if (true) than dugmeSacuvajizmene.visible=true and dugmeIzbrisiArtikal.visible=true
        'else
        'dugmeDodajNoviArtikal.visible=true

        If RadioButton2.Checked = True Then
            Button1.Visible = False
            Button3.Visible = False
            Button2.Visible = True
        Else
            Button1.Visible = True
            Button3.Visible = True
            Button2.Visible = False
        End If



    End Sub

    Private Sub dodajArtikal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'fetch artikala u tabelu iz koje cemo preko timera provjeravati da li je uneseni bar kod
        'vec postojeci u bazi podataka
        'ako da onda prikazati dugme za izbrisi artikal i spasi izmjene
        'ako ne onda prikazati dugme za dodaj novi artikal
    End Sub
End Class