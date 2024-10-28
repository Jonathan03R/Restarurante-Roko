Public Class frmGestionarPedido

    Private procesarPedidosServicio As New ProcesarPedidoServicio()
    Public Property MesaCodigo As String
    Private pedidoCodigo As String
    Private pedidoFecha As Date

    Private Sub frmGestionarPedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarMenuActivo()
        CargarPedidoYDetalles()
        CargarDetallesPedido(MesaCodigo)
    End Sub
    Private Sub CargarMenuActivo()
        Dim listaMenu As List(Of Menu) = procesarPedidosServicio.ListarMenuActivo()
        cmbMenu.DisplayMember = "MenuNombre"
        cmbMenu.ValueMember = "MenuCodigo"
        cmbMenu.DataSource = listaMenu

    End Sub
    Private Sub cmbMenu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMenu.SelectedIndexChanged
        Dim menuSeleccionado As Menu = CType(cmbMenu.SelectedItem, Menu)
        If menuSeleccionado IsNot Nothing Then
            lblPrecio.Text = menuSeleccionado.MenuPrecio.ToString("C") ' Actualiza el precio formateado en el label
        Else
            lblPrecio.Text = "S/ 0.00"
        End If
    End Sub

    Private Sub CargarPedidoYDetalles()
        Dim pedido As Pedido = procesarPedidosServicio.ObtenerPedidoPorMesa(MesaCodigo)

        If pedido IsNot Nothing Then
            pedidoCodigo = pedido.PedidosCodigo
            pedidoFecha = pedido.PedidoFecha

            lblPedidoCodigo.Text = pedido.PedidosCodigo
            lblMesaCodigo.Text = pedido.PedidosMesasCodigo
            lblEmpleadoCodigo.Text = pedido.PedidosEmpleadosCodigo
            lblFechaPedido.Text = pedido.PedidoFecha
            lblFecha.Text = pedido.PedidoFecha.ToString()
        Else
            MessageBox.Show("No se encontró un pedido activo para esta mesa.")
            procesarPedidosServicio.cancelarElPedido(MesaCodigo)
            Me.Close()
        End If
    End Sub

    Private Sub CargarDetallesPedido(mesaCodigo As String)
        Try
            Dim detallesDataTable As DataTable = procesarPedidosServicio.ObtenerDetallesPedidoComoDataTable(mesaCodigo)

            lvDetallesPedido.Items.Clear()

            For Each row As DataRow In detallesDataTable.Rows
                Dim item As New ListViewItem(row("MenuNombre").ToString())
                item.SubItems.Add(row("DetallesPedidoCantidad").ToString())
                item.SubItems.Add(Convert.ToDouble(row("DetallesPedidoPrecio")).ToString("C"))
                item.SubItems.Add(Convert.ToDouble(row("Total")).ToString("C"))
                item.Tag = row("DetallesPedidoCodigo").ToString()
                lvDetallesPedido.Items.Add(item)
            Next

        Catch ex As Exception
            MessageBox.Show("Error al cargar detalles del pedido: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAgregarDetalle_Click(sender As Object, e As EventArgs) Handles btnAgregarDetalle.Click
        If cmbMenu.SelectedItem Is Nothing Then
            MessageBox.Show("Por favor seleccione un menú.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim precio As Double
        Dim cantidad As Double
        Dim precioTexto As String = lblPrecio.Text.Replace("S/ ", "").Trim()
        If Not Double.TryParse(precioTexto, precio) Then
            MessageBox.Show("El precio no es un valor válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Not Double.TryParse(txtCantidad.Text, cantidad) Then
            MessageBox.Show("La cantidad no es un valor válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim menuSeleccionado As Menu = CType(cmbMenu.SelectedItem, Menu)

        procesarPedidosServicio.agregarDetallePedidos(menuSeleccionado.MenuCodigo, precio, cantidad, MesaCodigo)
        CargarDetallesPedido(MesaCodigo)
        LimpiarControles()
    End Sub


    Private Sub LimpiarControles()
        cmbMenu.SelectedIndex = -1
        lblPrecio.Text = "S/ 0.00"
        txtCantidad.Clear()
    End Sub

    Private Sub btnEliminarDetalle_Click(sender As Object, e As EventArgs) Handles btnEliminarDetalle.Click
        If lvDetallesPedido.SelectedItems.Count > 0 Then
            Dim detalleCodigo As String = lvDetallesPedido.SelectedItems(0).Tag.ToString()
            Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este detalle?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                procesarPedidosServicio.EliminarDetallePedido(detalleCodigo)
                CargarDetallesPedido(MesaCodigo)
                MessageBox.Show("Detalle de pedido eliminado con éxito.", "Eliminado")
            End If
        Else
            MessageBox.Show("Seleccione un detalle para eliminar.", "Eliminar Detalle")
        End If
    End Sub

    Private Sub btnFinalizarPedido_Click(sender As Object, e As EventArgs) Handles btnFinalizarPedido.Click
        Dim detallesDataTable As DataTable = procesarPedidosServicio.ObtenerDetallesPedidoComoDataTable(MesaCodigo)

        Dim montoTotal As Decimal = 0

        For Each row As DataRow In detallesDataTable.Rows
            montoTotal += Convert.ToDecimal(row("Total"))
        Next

        Dim frmPago As New frmPagos() With {
            .PedidoCodigo = pedidoCodigo,
            .MesaCodigo = MesaCodigo,
            .MontoTotal = montoTotal
        }

        frmPago.ShowDialog()
        Me.Close()
    End Sub


End Class
