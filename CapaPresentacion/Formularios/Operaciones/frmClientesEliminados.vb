Public Class frmClientesEliminados
    Dim gestionClientesServicio As New procesoGestionClientesServicio()

    Private Sub frmClientesEliminados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarClientesBorrados()
    End Sub

    Private Sub CargarClientesBorrados()

        Dim dataTableClientesBorrados As DataTable = gestionClientesServicio.MostrarClientesBorrados()

        lvClientes.Items.Clear()

        For Each row As DataRow In dataTableClientesBorrados.Rows
            Dim item As New ListViewItem(row("ClientesCodigo").ToString())
            item.SubItems.Add(row("ClientesNombreCompleto").ToString())
            lvClientes.Items.Add(item)
        Next
    End Sub

    Private Sub lvClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvClientes.SelectedIndexChanged

    End Sub

    Private Sub cmdRecuperar_Click(sender As Object, e As EventArgs) Handles cmdRecuperar.Click
        If lvClientes.SelectedItems.Count > 0 Then
            Dim clienteCodigo As String = lvClientes.SelectedItems(0).Text
            Dim resultado As DialogResult = MessageBox.Show("¿Está seguro de que desea recuperar este cliente?", "Confirmar Recuperación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If resultado = DialogResult.Yes Then
                If gestionClientesServicio.recuperarCliente(clienteCodigo) Then
                    MessageBox.Show("Cliente recuperado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CargarClientesBorrados()
                Else
                    MessageBox.Show("No se pudo recuperar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Por favor, seleccione un cliente para recuperar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub
End Class