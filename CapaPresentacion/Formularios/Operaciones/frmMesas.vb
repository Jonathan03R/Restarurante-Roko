Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmMesas
    Private gestionarMesasServicio As New ProcesoGestionarMesasServicio()

    Private Sub cargarMesas()
        Try
            Dim dataTableMesas As DataTable = gestionarMesasServicio.CrearUnaNuevaMesa()
            tablaMesas.Rows.Clear()

            For Each row As DataRow In dataTableMesas.Rows
                tablaMesas.Rows.Add(row("MesasCodigo"), row("MesasCapacidad"), row("MesasEstado"))
            Next

        Catch ex As Exception
            MessageBox.Show("Error al cargar mesas: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmMesas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarMesas()
    End Sub

    Private Sub mostrar_Click(sender As Object, e As EventArgs) Handles mostrar.Click
        Dim frmGrafiMesas As New frmGraficaMesas()
        frmGrafiMesas.ShowDialog()
    End Sub
End Class