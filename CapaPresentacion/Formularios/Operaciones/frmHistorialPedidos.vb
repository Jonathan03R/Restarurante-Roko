Public Class frmHistorialPedidos
    Private pedidoNegocio As New PedidoNegocio()

    Private Sub frmHistorialPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarHistorialPedidos()
    End Sub

    Private Sub CargarHistorialPedidos(Optional filtroEstado As List(Of String) = Nothing)
        Try
            Dim pedidos As List(Of Pedido) = pedidoNegocio.ObtenerPedidosConDetalle()
            If filtroEstado IsNot Nothing AndAlso filtroEstado.Count > 0 Then
                pedidos = pedidos.Where(Function(p) filtroEstado.Contains(p.PedidosEstado)).ToList()
            End If
            Dim pedidosMostrar = pedidos.Select(Function(p) New With {
                .CodigoPedido = p.PedidosCodigo,
                .CodigoMesa = p.PedidosMesasCodigo,
                .NombreEmpleado = p.Empleado.EmpleadosNombreCompleto,
                .CargoEmpleado = p.Empleado.RolPermiso.RolesPermisosNombreRol,
                .EstadoPedido = p.PedidosEstado
            }).ToList()
            dgvHistorialPedidos.DataSource = pedidosMostrar
            dgvHistorialPedidos.Columns("CodigoPedido").HeaderText = "Código del Pedido"
            dgvHistorialPedidos.Columns("CodigoMesa").HeaderText = "Código de la Mesa"
            dgvHistorialPedidos.Columns("NombreEmpleado").HeaderText = "Nombre del Empleado"
            dgvHistorialPedidos.Columns("CargoEmpleado").HeaderText = "Cargo del Empleado"
            dgvHistorialPedidos.Columns("EstadoPedido").HeaderText = "Estado del Pedido"

        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al cargar el historial de pedidos: " & ex.Message)
        End Try
    End Sub
    Private Sub chkPendiente_CheckedChanged(sender As Object, e As EventArgs) Handles chkPendiente.CheckedChanged
        AplicarFiltros()
    End Sub
    Private Sub chkCompletado_CheckedChanged(sender As Object, e As EventArgs) Handles chkCompletado.CheckedChanged
        AplicarFiltros()
    End Sub
    Private Sub AplicarFiltros()
        Dim filtroEstado As New List(Of String)
        If chkPendiente.Checked Then
            filtroEstado.Add("Pendiente")
        End If
        If chkCompletado.Checked Then
            filtroEstado.Add("Completado")
        End If

        ' Cargar los pedidos con el filtro aplicado
        CargarHistorialPedidos(filtroEstado)
    End Sub
End Class
