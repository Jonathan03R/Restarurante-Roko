Public Class frmPedidos
    ' Variables y objetos necesarios
    'Private detalleNegocio As New DetallePedidoNegocio()
    'Private pedidoNegocio As New PedidoNegocio()
    'Private mesaNegocio As New MesaNegocio()
    'Private menuNegocio As New MenuNegocio()

    Private procesarPedidosServicio As New ProcesarPedidoServicio()
    Public Property MesaCodigo As String
    Private pedidoCodigo As String

    Dim mesa As New Mesa()

#Region "Inicialización"

    Private Sub frmPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mesa.MesasCodigo = MesaCodigo
        CrearPedido()
        CargarMenuActivo()
    End Sub

    Private Sub CrearPedido()
        Dim empleadoCodigo As String = "EMP00001"
        procesarPedidosServicio.CrearPedidoMesaVacia(MesaCodigo, empleadoCodigo)
    End Sub

    Private Sub CargarMenuActivo()
        Dim listaMenu As List(Of Menu) = procesarPedidosServicio.ListarMenuActivo()
        cmbMenu.DisplayMember = "MenuNombre"
        cmbMenu.ValueMember = "MenuCodigo"
        cmbMenu.DataSource = listaMenu

    End Sub

#End Region

#Region "Eventos"

    Private Sub cmbMenu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMenu.SelectedIndexChanged
        Dim menuSeleccionado As Menu = CType(cmbMenu.SelectedItem, Menu)
        If menuSeleccionado IsNot Nothing Then
            lblPrecio.Text = menuSeleccionado.MenuPrecio.ToString("C")
        Else
            lblPrecio.Text = "S/ 0.00"
        End If
    End Sub

    Private Sub btnAgregarProducto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click
        AgregarProducto()
    End Sub

    Private Sub btnCompletarPedido_Click(sender As Object, e As EventArgs) Handles btnCompletarPedido.Click
        If dgvDetallesPedido.Rows.Count > 0 Then
            MessageBox.Show("Pedido completado. ¡Gracias!")
            Me.Close()
        ElseIf cmbMenu.SelectedItem IsNot Nothing AndAlso Not String.IsNullOrEmpty(txtCantidad.Text) Then
            Dim menuSeleccionado As Menu = CType(cmbMenu.SelectedItem, Menu)
            Dim confirmacion As DialogResult = MessageBox.Show("No ha agregado ningún producto al pedido. ¿Desea agregar el siguiente producto y completar el pedido?: " & menuSeleccionado.MenuNombre, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirmacion = DialogResult.Yes Then
                AgregarProducto()
                MessageBox.Show("Pedido completado. ¡Gracias!")
                Me.Close()
            Else
                MessageBox.Show("No se puede completar el pedido sin productos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("No se puede completar el pedido sin productos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCancelarPedido_Click(sender As Object, e As EventArgs) Handles btnCancelarPedido.Click
        procesarPedidosServicio.cancelarElPedido(mesa)
        Me.Close()
    End Sub

#End Region

#Region "Lógica del Pedido"

    Private Sub AgregarProducto()
        If cmbMenu.SelectedItem Is Nothing Then
            MessageBox.Show("Por favor, seleccione un menú válido.")
            Exit Sub
        End If

        Dim menuSeleccionado As Menu = CType(cmbMenu.SelectedItem, Menu)
        Dim cantidad As Integer
        If Not Integer.TryParse(txtCantidad.Text, cantidad) OrElse cantidad <= 0 Then
            MessageBox.Show("Por favor, ingrese una cantidad válida.")
            Exit Sub
        End If

        procesarPedidosServicio.agregarDetallePedidos(menuSeleccionado.MenuCodigo, menuSeleccionado.MenuPrecio, cantidad, mesa)

        ' Actualizar la interfaz después de agregar el detalle
        ActualizarDetallesPedidoGrid(MesaCodigo)
        LimpiarCamposProducto()


    End Sub

    Private Sub ActualizarDetallesPedidoGrid(MesaCodigo As String)
        Try
            Dim procesarPedido As New ProcesarPedidoServicio()
            Dim detallesDataTable As DataTable = procesarPedido.ObtenerDetallesPedidoComoDataTable(mesa)
            dgvDetallesPedido.DataSource = detallesDataTable
        Catch ex As Exception
            MessageBox.Show("Error al actualizar detalles del pedido: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LimpiarCamposProducto()
        lblPrecio.Text = "S/ 0.00"
        txtCantidad.Clear()
        cmbMenu.SelectedIndex = -1
    End Sub

#End Region

End Class
