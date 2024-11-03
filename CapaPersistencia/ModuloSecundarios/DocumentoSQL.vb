Imports System.Data.SqlClient
Imports System.IO

Public Class DocumentoSQL


    Public Function agregarDocumento(documento As Documento) As Boolean
        Try

            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spDocumentoInsertar")

            cmd.Parameters.Add("@DocumentoCodigo", SqlDbType.NChar, 8).Value = documento.documentoCodigo.Trim()
            cmd.Parameters.Add("@DocumentoReferencias", SqlDbType.NChar, 8).Value = documento.documetoReferencias
            cmd.Parameters.Add("@DocumentoTipo", SqlDbType.NVarChar, 20).Value = documento.documentoTipo
            cmd.Parameters.Add("@DocumentoPDF", SqlDbType.Image).Value = documento.documentoPDF ' Almacena como imagen


            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ObtenerDocumentoPDF(codigoDocumento As Documento) As Byte()
        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spObtenerDocumentoPDF")
            cmd.Parameters.Add("@DocumentoCodigo", SqlDbType.NChar, 8).Value = codigoDocumento.documentoCodigo

            Dim resultado As Object = cmd.ExecuteScalar()
            If resultado IsNot DBNull.Value Then
                Return CType(resultado, Byte())
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw New Exception("Error al obtener el documento PDF: " & ex.Message)
        End Try
    End Function


    Public Function ListarDocumentos() As DataTable
        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spListarDocumentos")

            Dim adapter As New SqlDataAdapter(cmd)
            Dim dataTable As New DataTable()
            adapter.Fill(dataTable)

            Return dataTable
        Catch ex As Exception
            Throw New Exception("Error al listar los documentos: " & ex.Message)
        End Try
    End Function
End Class
