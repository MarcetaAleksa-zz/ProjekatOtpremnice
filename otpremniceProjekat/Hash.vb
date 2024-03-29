﻿Imports System.Data.SqlClient
Imports System.IO
Public Class Hash
    Public Shared HashStorePrijava As String
    Public Shared HashNoviKorisnik As String

    Private Shared Function StringtoSha512(ByRef content As String) As String
        Dim sha As New System.Security.Cryptography.SHA512CryptoServiceProvider
        Dim ByteString() As Byte = System.Text.Encoding.ASCII.GetBytes(content)
        ByteString = sha.ComputeHash(ByteString)
        Dim FinalString As String = Nothing
        For Each bt As Byte In ByteString
            FinalString &= bt.ToString("x2")
        Next
        Return FinalString.ToUpper()
    End Function
    Public Shared Sub Hashing()
        If HashStorePrijava = String.Empty Then
            Try
                Dim temp As String
                temp = Chr(128) & StringtoSha512(prijava.TextBox2.Text)
                HashStorePrijava = Chr(128) & StringtoSha512(prijava.Salt + temp)
            Catch
            End Try
        End If
        If HashNoviKorisnik = String.Empty Then
            Try
                Dim temp As String
                temp = Chr(128) & StringtoSha512(DodajRadnika.lozinkaTB.Text)
                HashNoviKorisnik = Chr(128) & StringtoSha512(DodajRadnika.saltTB.Text + temp)
            Catch
            End Try
        End If
    End Sub
End Class
