
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Diagnostics
Public Class frmPagos

    Dim clienteNegocio As New ClienteNegocio()
    Dim pedidoNegocio As New PedidoNegocio()
    Private codigoCliente As String
    Private nombreCompleto As String
    Public Property MesaCodigo As String
    Public Property MontoTotal As Decimal
    Public Property PedidoCodigo As String
    Public Property PedidoFecha As Date

    Private Sub frmPagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMesaCodigo.Text = MesaCodigo
        lblPedidoCodigo.Text = PedidoCodigo
        lblMontoTotal.Text = MontoTotal.ToString("C")
        lblEmpleadoCodigo.Text = "EMP00001"

        panelBoleta.Visible = True
        panelRuc.Visible = False
        CargarClientes()
        MessageBox.Show("Iniciando el pago para el pedido: " & PedidoCodigo)
    End Sub

    Private Sub rbtnBoleta_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnBoleta.CheckedChanged
        If rbtnBoleta.Checked Then
            panelBoleta.Visible = True
            panelRuc.Visible = False
        End If
    End Sub

    Private Sub rbtnFactura_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnFactura.CheckedChanged
        If rbtnFactura.Checked Then
            panelRuc.Visible = True
            panelBoleta.Visible = False
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Dim textoBusqueda As String = txtBuscar.Text
        CargarClientes(textoBusqueda)
    End Sub

    Private Sub CargarClientes(Optional textoBusqueda As String = "")
        Dim clientesFiltrados As List(Of Cliente) = clienteNegocio.BuscarClientesPorNombre(textoBusqueda)
        dgvClientes.Rows.Clear()

        For Each cliente As Cliente In clientesFiltrados
            Dim row As String() = {cliente.ClientesCodigo, cliente.ClientesNombreCompleto}
            Dim index As Integer = dgvClientes.Rows.Add(row)
            dgvClientes.Rows(index).Tag = cliente
        Next
    End Sub

    Private Sub dgvClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellClick
        If e.RowIndex >= 0 Then
            Dim filaSeleccionada As DataGridViewRow = dgvClientes.Rows(e.RowIndex)
            Dim clienteSeleccionado As Cliente = CType(filaSeleccionada.Tag, Cliente)
            If clienteSeleccionado IsNot Nothing Then
                codigoCliente = clienteSeleccionado.ClientesCodigo ' Almacenar código del cliente
                lblClienteNombre.Text = clienteSeleccionado.ClientesNombreCompleto ' Mostrar el nombre del cliente
            Else
                MessageBox.Show("No se encontró la información completa del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnFinalizarPago_Click(sender As Object, e As EventArgs) Handles btnFinalizarPago.Click
        Dim generarBoleta As Boolean = rbtnBoleta.Checked
        Dim generarFactura As Boolean = rbtnFactura.Checked
        Dim empleadoCodigo As String = lblEmpleadoCodigo.Text

        ' Validaciones básicas
        If String.IsNullOrEmpty(empleadoCodigo) Then
            MessageBox.Show("El código de empleado no está configurado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If String.IsNullOrEmpty(MesaCodigo) Then
            MessageBox.Show("El código de mesa no está configurado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If String.IsNullOrEmpty(PedidoCodigo) Then
            MessageBox.Show("El código de pedido no está configurado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If generarBoleta AndAlso generarFactura Then
            MessageBox.Show("No puede seleccionar boleta y factura al mismo tiempo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Limpiar el monto eliminando el símbolo de moneda y convertirlo a decimal
        Dim montoLimpio As String = lblMontoTotal.Text.Replace("S/ ", "").Trim()
        Dim montoDecimal As Decimal
        If Not Decimal.TryParse(montoLimpio, montoDecimal) Then
            MessageBox.Show("El monto no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Información del cliente
        Dim clienteNombreCompleto As String = Nothing
        Dim clienteRUC As String = Nothing
        Dim boletaClientesCodigo As String = codigoCliente ' Código del cliente para boleta
        Dim boletaNombreCompletoCliente As String = lblClienteNombre.Text ' Nombre del cliente para boleta

        ' Si es una factura, requerimos el nombre completo y el RUC
        If generarFactura Then
            clienteNombreCompleto = txtNombreCliente.Text
            clienteRUC = txtRucCliente.Text

            ' Validaciones específicas para factura
            If String.IsNullOrEmpty(clienteNombreCompleto) OrElse String.IsNullOrEmpty(clienteRUC) Then
                MessageBox.Show("Debe ingresar el nombre completo y RUC para la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        Try
            ' Generar el PDF correspondiente
            If generarBoleta Then
                GenerarBoletaPDF(boletaClientesCodigo, boletaNombreCompletoCliente, montoDecimal)
            ElseIf generarFactura Then
                GenerarFacturaPDF(clienteNombreCompleto, clienteRUC, montoDecimal)
            Else
                MessageBox.Show("Debe seleccionar Boleta o Factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Llamada al método de completar pago en la capa de negocio
            pedidoNegocio.CompletarPago(
                PedidoCodigo,
                MesaCodigo,
                empleadoCodigo,
                montoDecimal,
                generarBoleta,
                generarFactura,
                boletaClientesCodigo,
                boletaNombreCompletoCliente,
                clienteNombreCompleto,
                clienteRUC,
                MesaCodigo
            )

            MessageBox.Show("Pago y finalización del pedido completados.")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frmclientes As New frmClientes()
        AddHandler frmclientes.FormClosed, AddressOf ActualizarClientes
        frmclientes.ShowDialog()
    End Sub

    Private Sub ActualizarClientes(sender As Object, e As FormClosedEventArgs)
        CargarClientes()
    End Sub



    Private Sub GenerarBoletaPDF(clienteCodigo As String, clienteNombre As String, montoTotal As Decimal)
        Dim nombreArchivo As String = "Boleta_" & PedidoCodigo & ".pdf"
        Dim rutaArchivo As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nombreArchivo)

        Dim doc As New Document(PageSize.A4, 40, 40, 40, 20)
        Try
            PdfWriter.GetInstance(doc, New FileStream(rutaArchivo, FileMode.Create))
            doc.Open()

            ' Agregar contenido al documento
            doc.Add(New Paragraph("BOLETA DE VENTA", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)))
            doc.Add(New Paragraph(" "))

            doc.Add(New Paragraph("Código de Boleta: " & PedidoCodigo))
            doc.Add(New Paragraph("Fecha: " & DateTime.Now.ToString("dd/MM/yyyy")))
            doc.Add(New Paragraph("Cliente: " & clienteNombre))
            doc.Add(New Paragraph("Código Cliente: " & clienteCodigo))
            doc.Add(New Paragraph(" "))

            ' Tabla para los detalles del pedido
            Dim tabla As New PdfPTable(4)
            tabla.WidthPercentage = 100
            tabla.SetWidths(New Single() {40, 20, 20, 20})

            ' Encabezados de la tabla
            tabla.AddCell(New Phrase("Producto", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
            tabla.AddCell(New Phrase("Cantidad", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
            tabla.AddCell(New Phrase("Precio Unitario", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
            tabla.AddCell(New Phrase("Total", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))

            ' Obtener los detalles del pedido desde la base de datos
            Dim detalleNegocio As New DetallePedidoNegocio()
            Dim listaDetalles As List(Of DetallePedido) = detalleNegocio.ObtenerDetallesPedido(PedidoCodigo)

            ' Agregar los detalles a la tabla
            For Each detalle In listaDetalles
                tabla.AddCell(detalle.Menu.MenuNombre)
                tabla.AddCell(detalle.DetallesPedidoCantidad.ToString())
                tabla.AddCell("S/ " & detalle.DetallesPedidoPrecio.ToString("F2"))
                Dim totalDetalle As Decimal = detalle.DetallesPedidoCantidad * detalle.DetallesPedidoPrecio
                tabla.AddCell("S/ " & totalDetalle.ToString("F2"))
            Next

            doc.Add(tabla)
            doc.Add(New Paragraph(" "))

            ' Total
            doc.Add(New Paragraph("Monto Total: S/ " & montoTotal.ToString("F2"), FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))

            doc.Close()

            ' Abrir el archivo PDF automáticamente
            Process.Start(rutaArchivo)

            MessageBox.Show("Boleta generada correctamente en: " & rutaArchivo)
        Catch ex As Exception
            MessageBox.Show("Error al generar la boleta: " & ex.Message)
        End Try
    End Sub

    ' Método para generar la factura en PDF
    Private Sub GenerarFacturaPDF(clienteNombre As String, clienteRUC As String, montoTotal As Decimal)
        Dim nombreArchivo As String = "Factura_" & PedidoCodigo & ".pdf"
        Dim rutaArchivo As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nombreArchivo)

        Dim doc As New Document(PageSize.A4, 40, 40, 40, 20)
        Try
            PdfWriter.GetInstance(doc, New FileStream(rutaArchivo, FileMode.Create))
            doc.Open()

            ' Agregar contenido al documento
            doc.Add(New Paragraph("FACTURA", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)))
            doc.Add(New Paragraph(" "))

            doc.Add(New Paragraph("Código de Factura: " & PedidoCodigo))
            doc.Add(New Paragraph("Fecha: " & DateTime.Now.ToString("dd/MM/yyyy")))
            doc.Add(New Paragraph("Cliente: " & clienteNombre))
            doc.Add(New Paragraph("RUC: " & clienteRUC))
            doc.Add(New Paragraph(" "))

            ' Tabla para los detalles del pedido
            Dim tabla As New PdfPTable(4)
            tabla.WidthPercentage = 100
            tabla.SetWidths(New Single() {40, 20, 20, 20})

            ' Encabezados de la tabla
            tabla.AddCell(New Phrase("Producto", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
            tabla.AddCell(New Phrase("Cantidad", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
            tabla.AddCell(New Phrase("Precio Unitario", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
            tabla.AddCell(New Phrase("Total", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))

            ' Obtener los detalles del pedido desde la base de datos
            Dim detalleNegocio As New DetallePedidoNegocio()
            Dim listaDetalles As List(Of DetallePedido) = detalleNegocio.ObtenerDetallesPedido(PedidoCodigo)

            ' Agregar los detalles a la tabla
            For Each detalle In listaDetalles
                tabla.AddCell(detalle.Menu.MenuNombre)
                tabla.AddCell(detalle.DetallesPedidoCantidad.ToString())
                tabla.AddCell("S/ " & detalle.DetallesPedidoPrecio.ToString("F2"))
                Dim totalDetalle As Decimal = detalle.DetallesPedidoCantidad * detalle.DetallesPedidoPrecio
                tabla.AddCell("S/ " & totalDetalle.ToString("F2"))
            Next

            doc.Add(tabla)
            doc.Add(New Paragraph(" "))

            ' Total
            doc.Add(New Paragraph("Monto Total: S/ " & montoTotal.ToString("F2"), FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))

            doc.Close()

            ' Abrir el archivo PDF automáticamente
            Process.Start(rutaArchivo)

            MessageBox.Show("Factura generada correctamente en: " & rutaArchivo)
        Catch ex As Exception
            MessageBox.Show("Error al generar la factura: " & ex.Message)
        End Try
    End Sub
End Class
