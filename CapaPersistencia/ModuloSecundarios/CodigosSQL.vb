
'cree este modulo de la capa persistencia para reutilizar el generador de codigo de las diferentes tablas existentes 
Imports System.Data.SqlClient

Public Class CodigosSQL
    Public Function GenerarCodigoUnico(prefijo As String, tabla As String, columnaCodigo As String) As String
        Dim codigoUnico As String = String.Empty

        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spGenerarCodigoUnico", cn)
            cmd.CommandType = CommandType.StoredProcedure

            ' Agregar parámetros al procedimiento almacenado
            cmd.Parameters.AddWithValue("@prefijo", prefijo)
            cmd.Parameters.AddWithValue("@tabla", tabla)
            cmd.Parameters.AddWithValue("@columnaCodigo", columnaCodigo)

            cn.Open()
            ' Ejecutar el procedimiento y obtener el código único
            codigoUnico = cmd.ExecuteScalar().ToString()
            cn.Close()
        End Using

        Return codigoUnico
    End Function
End Class

