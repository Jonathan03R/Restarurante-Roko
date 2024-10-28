Imports System.Data.SqlClient

Public Class Cliente
    Public Property ClientesCodigo As String
    Public Property ClientesNombre As String
    Public Property ClientesApellidos As String
    Public Property ClientesNombreCompleto As String
    Public Property ClientesTelefono As String
    Public Property ClientesDNI As String
    Public Property ClientesCorreo As String
    Public Property ClientesFechaRegistro As Date
    Public Property ClientesEstado As String

    Public Function EsActivo() As Boolean
        Return ClientesEstado = "A"
    End Function

    Public Sub AsignarCodigo(codigo As String)
        Me.ClientesCodigo = codigo
    End Sub
End Class

