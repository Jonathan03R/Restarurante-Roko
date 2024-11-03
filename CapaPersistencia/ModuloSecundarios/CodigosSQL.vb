Imports System.Data.SqlClient

Public Class CodigosSQL
    Public Function GenerarCodigoUnico(prefijo As String, tabla As String, columnaCodigo As String) As String
        Dim codigoUnico As String = String.Empty

        Try
            ' Obtener el comando del procedimiento almacenado usando ModuloSistema
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spGenerarCodigoUnico")

            ' Agregar parámetros al procedimiento almacenado
            cmd.Parameters.AddWithValue("@prefijo", prefijo)
            cmd.Parameters.AddWithValue("@tabla", tabla)
            cmd.Parameters.AddWithValue("@columnaCodigo", columnaCodigo)

            ' Ejecutar el procedimiento y obtener el código único
            codigoUnico = cmd.ExecuteScalar().ToString()
        Catch ex As Exception
            Throw New Exception("Error al generar código único: " & ex.Message)
        End Try

        Return codigoUnico
    End Function
End Class