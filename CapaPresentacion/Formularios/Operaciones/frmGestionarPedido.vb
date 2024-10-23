Public Class frmGestionarPedido
    Public Property MesaCodigo As String
    Private pedidoCodigo As String
    Private pedidoFecha As Date

    Private Sub frmGestionarPedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarMenuActivo()
        CargarPedidoYDetalles()
    End Sub
    Private Sub CargarMenuActivo()
        Dim menuNegocio As New MenuNegocio()
        Dim listaMenu = menuNegocio.ObtenerMenuActivo()

        cmbMenu.Items.Clear()
        For Each item As Menu In listaMenu
            cmbMenu.Items.Add(item)
        Next
        cmbMenu.DisplayMember = "MenuNombre"
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
        Dim pedidoNegocio As New PedidoNegocio()
        Dim pedido As Pedido = pedidoNegocio.ObtenerPedidoPorMesa(MesaCodigo)

        If pedido IsNot Nothing Then
            pedidoCodigo = pedido.PedidosCodigo
            pedidoFecha = pedido.PedidoFecha

            lblPedidoCodigo.Text = pedido.PedidosCodigo
            lblMesaCodigo.Text = pedido.PedidosMesasCodigo
            lblEmpleadoCodigo.Text = pedido.PedidosEmpleadosCodigo
            lblFechaPedido.text = pedido.PedidoFecha
            lblFecha.Text = pedido.PedidoFecha.ToString()
            CargarDetallesPedido(pedido.PedidosCodigo)
        Else
            MessageBox.Show("No se encontró un pedido activo para esta mesa.")
            Me.Close()
        End If
    End Sub

    Private Sub CargarDetallesPedido(pedidoCodigo As String)
        Dim detalleNegocio As New DetallePedidoNegocio()
        Dim listaDetalles As List(Of DetallePedido) = detalleNegocio.ObtenerDetallesPedido(pedidoCodigo)

        lvDetallesPedido.Items.Clear() ' Limpiar el ListView antes de cargar

        For Each detalle In listaDetalles
            Dim item As New ListViewItem(detalle.Menu.MenuNombre)
            item.SubItems.Add(detalle.DetallesPedidoCantidad.ToString())
            item.SubItems.Add(detalle.DetallesPedidoPrecio.ToString("C"))
            item.SubItems.Add((detalle.DetallesPedidoCantidad * detalle.DetallesPedidoPrecio).ToString("C"))

            ' Agregar el item al ListView
            lvDetallesPedido.Items.Add(item)
        Next
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
        Dim codigoSQL As New CodigosSQL()
        Dim detalleCodigo As String = codigoSQL.GenerarCodigoUnico("DET", "Restaurante.DetallesPedido", "DetallesPedidoCodigo")
        Dim nuevoDetalle As New DetallePedido With {
        .DetallesPedidoMenuCodigo = menuSeleccionado.MenuCodigo,
        .DetallesPedidoPrecio = precio,
        .DetallesPedidoCantidad = cantidad,
        .Menu = menuSeleccionado
    }
        Dim detalleNegocio As New DetallePedidoNegocio()
        detalleNegocio.AgregarDetallePedido(pedidoCodigo, nuevoDetalle)
        ActualizarDetallesPedidoListView(nuevoDetalle)
        LimpiarControles()
    End Sub
    Private Sub ActualizarDetallesPedidoListView(detalle As DetallePedido)
        Dim item As New ListViewItem(detalle.Menu.MenuNombre)
        item.SubItems.Add(detalle.DetallesPedidoCantidad.ToString()) ' Cantidad
        item.SubItems.Add(detalle.DetallesPedidoPrecio.ToString("C")) ' Precio en formato moneda
        item.SubItems.Add((detalle.DetallesPedidoCantidad * detalle.DetallesPedidoPrecio).ToString("C")) ' Total en formato moneda

        ' Agregar el ítem al ListView
        lvDetallesPedido.Items.Add(item)
    End Sub

    Private Sub LimpiarControles()
        cmbMenu.SelectedIndex = -1
        lblPrecio.Text = "S/ 0.00"
        txtCantidad.Clear()
    End Sub

    Private Sub btnEliminarDetalle_Click(sender As Object, e As EventArgs) Handles btnEliminarDetalle.Click
        If lvDetallesPedido.SelectedItems.Count > 0 Then
            Dim detalleCodigo As String = lvDetallesPedido.SelectedItems(0).Text
            Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este detalle?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                Dim detalleNegocio As New DetallePedidoNegocio()
                detalleNegocio.EliminarDetallePedido(detalleCodigo)
                lvDetallesPedido.Items.Remove(lvDetallesPedido.SelectedItems(0))

                MessageBox.Show("Detalle de pedido eliminado con éxito.", "Eliminado")
            End If
        Else
            MessageBox.Show("Seleccione un detalle para eliminar.", "Eliminar Detalle")
        End If
    End Sub

    Private Sub btnFinalizarPedido_Click(sender As Object, e As EventArgs) Handles btnFinalizarPedido.Click
        Dim detalleNegocio As New DetallePedidoNegocio()
        Dim listaDetalles As List(Of DetallePedido) = detalleNegocio.ObtenerDetallesPedido(pedidoCodigo)

        Dim montoTotal As Decimal = 0

        For Each detalle In listaDetalles
            montoTotal += Convert.ToDecimal(detalle.DetallesPedidoCantidad * detalle.DetallesPedidoPrecio)
        Next
        Dim frmPago As New frmPagos()
        frmPago.PedidoCodigo = pedidoCodigo
        frmPago.MesaCodigo = MesaCodigo
        frmPago.PedidoFecha = pedidoFecha
        frmPago.MontoTotal = montoTotal
        frmPago.ShowDialog()
        Me.Close()
    End Sub


End Class
