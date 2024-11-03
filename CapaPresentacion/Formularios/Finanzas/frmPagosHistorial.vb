Imports System.IO

Public Class frmPagosHistorial
    Private servicioPago As New ProcesarPagoServicio()

    Private Sub frmPagosHistorial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDocumentos()
    End Sub

    Private Sub CargarDocumentos()
        Try
            dgvDocumentos.AutoGenerateColumns = False
            dgvDocumentos.DataSource = servicioPago.obtenerDocumentosComoDataTable()
        Catch ex As Exception
            MessageBox.Show("Error al cargar los documentos: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvDocumentos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDocumentos.CellClick
        If e.ColumnIndex = dgvDocumentos.Columns("btnAbrirPDF").Index AndAlso e.RowIndex >= 0 Then
            Dim documentoCodigo As String = dgvDocumentos.Rows(e.RowIndex).Cells("DocumentoCodigo").Value.ToString()
            VerDocumentoPDF(documentoCodigo)
        End If
    End Sub

    Private Sub VerDocumentoPDF(documentoCodigo As String)
        Try
            Dim archivoPDF As Byte() = servicioPago.ObtenerDocumentoPDF(documentoCodigo)
            If archivoPDF IsNot Nothing Then
                Dim rutaTemporal As String = Path.Combine(Path.GetTempPath(), "Documento_" & documentoCodigo & ".pdf")
                File.WriteAllBytes(rutaTemporal, archivoPDF)
                Process.Start(rutaTemporal)
            Else
                MessageBox.Show("No se encontró el documento PDF con el código especificado.", "Documento no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al visualizar el documento PDF: " & ex.Message)
        End Try
    End Sub
End Class
