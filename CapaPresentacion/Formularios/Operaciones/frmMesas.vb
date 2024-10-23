Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmMesas
    Dim mesaNegocio As New MesaNegocio()
    Private listaMesas As List(Of Mesa)
    Private Sub cargarMesas()
        listaMesas = mesaNegocio.ObtenerMesas()
        tablaMesas.Rows.Clear()


        For Each mesas As Mesa In listaMesas
            Dim row As String() = {
                mesas.MesasCodigo,
                mesas.MesasCapacidad,
                mesas.MesasEstado
            }
            tablaMesas.Rows.Add(row)
        Next
    End Sub

    Private Sub frmMesas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarMesas()
    End Sub

    Private Sub mostrar_Click(sender As Object, e As EventArgs) Handles mostrar.Click
        Dim frmGrafiMesas As New frmGraficaMesas()
        frmGrafiMesas.ShowDialog()
    End Sub
End Class