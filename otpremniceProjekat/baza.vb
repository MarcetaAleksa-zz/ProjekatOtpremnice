Imports System.Data.SqlClient
Public Class baza
    Public Shared konekcija As New SqlConnection("SERVER=tcp:192.168.50.44,1433; DATABASE=Panleksa; user id=Aleksa; Password=P@$$w0rd")
End Class
