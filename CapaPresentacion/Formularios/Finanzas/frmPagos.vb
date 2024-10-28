﻿
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Diagnostics
Public Class frmPagos

    Private procesoPagoServicio As New ProcesarPagoServicio()

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
        'codCLi.Text = codigoCliente
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
        Dim clientesDataTable As DataTable = procesoPagoServicio.buscarClientesPorNombre(textoBusqueda)

        dgvClientes.Rows.Clear()

        For Each row As DataRow In clientesDataTable.Rows
            Dim cliente As New Cliente With {
            .ClientesCodigo = row("ClientesCodigo").ToString(),
            .ClientesNombreCompleto = row("ClientesNombreCompleto").ToString()
        }
            Dim index As Integer = dgvClientes.Rows.Add(row("ClientesCodigo").ToString(), row("ClientesNombreCompleto").ToString())
            dgvClientes.Rows(index).Tag = cliente
        Next
    End Sub

    Private Sub dgvClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellClick
        If e.RowIndex >= 0 Then
            Dim filaSeleccionada As DataGridViewRow = dgvClientes.Rows(e.RowIndex)
            Dim clienteSeleccionado As Cliente = CType(filaSeleccionada.Tag, Cliente)
            If clienteSeleccionado IsNot Nothing Then
                codigoCliente = clienteSeleccionado.ClientesCodigo ' Almacenar código del cliente
                codCLi.Text = clienteSeleccionado.ClientesCodigo
                lblClienteNombre.Text = clienteSeleccionado.ClientesNombreCompleto ' Mostrar el nombre del cliente
            Else
                MessageBox.Show("No se encontró la información completa del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnFinalizarPago_Click(sender As Object, e As EventArgs) Handles btnFinalizarPago.Click
        Try
            If Not ValidarEntradas() Then Exit Sub

            Dim montoDecimal As Decimal = ObtenerMonto()
            If montoDecimal <= 0 Then Exit Sub

            Dim clienteInfo As Dictionary(Of String, String) = ObtenerInformacionCliente()
            If clienteInfo Is Nothing Then Exit Sub

            ' Llamada al método de completar pago en la capa de negocio y obtener el código generado
            Dim codigoGenerado As String = procesoPagoServicio.CompletarPago(
            PedidoCodigo,
            MesaCodigo,
            lblEmpleadoCodigo.Text,
            montoDecimal,
            rbtnBoleta.Checked,
            rbtnFactura.Checked,
            codigoCliente,
            lblClienteNombre.Text,
            clienteInfo("Nombre"),
            clienteInfo("RUC"),
            MesaCodigo
        )

            ' Obtener y generar el comprobante de pago
            GenerarComprobante(PedidoCodigo)

            MessageBox.Show("Pago y finalización del pedido completados.")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    ' Método para validar las entradas básicas
    Private Function ValidarEntradas() As Boolean
        If String.IsNullOrEmpty(lblEmpleadoCodigo.Text) Then
            MessageBox.Show("El código de empleado no está configurado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If String.IsNullOrEmpty(MesaCodigo) Then
            MessageBox.Show("El código de mesa no está configurado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If String.IsNullOrEmpty(PedidoCodigo) Then
            MessageBox.Show("El código de pedido no está configurado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If rbtnBoleta.Checked AndAlso rbtnFactura.Checked Then
            MessageBox.Show("No puede seleccionar boleta y factura al mismo tiempo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Return True
    End Function

    ' Método para obtener el monto y convertirlo a decimal
    Private Function ObtenerMonto() As Decimal
        Dim montoLimpio As String = lblMontoTotal.Text.Replace("S/ ", "").Trim()
        Dim montoDecimal As Decimal

        If Not Decimal.TryParse(montoLimpio, montoDecimal) Then
            MessageBox.Show("El monto no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End If

        Return montoDecimal
    End Function

    Private Function ObtenerInformacionCliente() As Dictionary(Of String, String)
        Dim infoCliente As New Dictionary(Of String, String)

        If rbtnFactura.Checked Then
            Dim clienteNombreCompleto As String = txtNombreCliente.Text
            Dim clienteRUC As String = txtRucCliente.Text

            If String.IsNullOrEmpty(clienteNombreCompleto) OrElse String.IsNullOrEmpty(clienteRUC) Then
                MessageBox.Show("Debe ingresar el nombre completo y RUC para la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End If

            infoCliente("Nombre") = clienteNombreCompleto
            infoCliente("RUC") = clienteRUC
        Else
            infoCliente("Nombre") = lblClienteNombre.Text
            infoCliente("RUC") = ""
        End If

        Return infoCliente
    End Function
    ' Método para generar el comprobante de pago en formato PDF
    Private Sub GenerarComprobante(pedidoCodigo As String)
        Dim dtComprobante As DataTable = procesoPagoServicio.ObtenerComprobantePorPedido(pedidoCodigo)

        If dtComprobante.Rows.Count > 0 Then
            Dim tipoComprobante As String = dtComprobante.Rows(0)("TipoComprobante").ToString()
            If tipoComprobante = "Boleta" Then
                GenerarBoletaPDF(dtComprobante)
            ElseIf tipoComprobante = "Factura" Then
                GenerarFacturaPDF(dtComprobante)
            End If
        Else
            MessageBox.Show("No se encontró un comprobante asociado al código de pedido especificado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frmclientes As New frmClientes()
        AddHandler frmclientes.FormClosed, AddressOf ActualizarClientes
        frmclientes.ShowDialog()
    End Sub

    Private Sub ActualizarClientes(sender As Object, e As FormClosedEventArgs)
        CargarClientes()
    End Sub


    Private Sub AgregarCabeceraEmpresa(doc As Document)
        ' Información de la empresa según tu solicitud
        Dim titulo As New Paragraph("Restaurante Roko", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20))
        titulo.Alignment = Element.ALIGN_CENTER
        doc.Add(titulo)

        Dim subTitulo As New Paragraph("RUC: 10737782943", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))
        subTitulo.Alignment = Element.ALIGN_CENTER
        doc.Add(subTitulo)

        doc.Add(New Paragraph("Dirección: chao-viru", FontFactory.GetFont(FontFactory.HELVETICA, 10)))
        doc.Add(New Paragraph("Teléfono: 999999999", FontFactory.GetFont(FontFactory.HELVETICA, 10)))
        doc.Add(New Paragraph("Email: restauranteRoco@gmail.com", FontFactory.GetFont(FontFactory.HELVETICA, 10)))
        doc.Add(New Paragraph(" ")) ' Espacio
    End Sub

    Private Sub AgregarTotales(doc As Document, row As DataRow)
        doc.Add(New Paragraph(" "))
        Dim tableTotales As New PdfPTable(2)
        tableTotales.WidthPercentage = 40
        tableTotales.HorizontalAlignment = Element.ALIGN_RIGHT
        tableTotales.SetWidths(New Single() {2.0F, 1.0F})

        tableTotales.AddCell(New Phrase("Total sin IGV:", FontFactory.GetFont(FontFactory.HELVETICA, 10)))
        tableTotales.AddCell(New Phrase("S/ " & Convert.ToDecimal(row("TotalSinIGV")).ToString("F2"), FontFactory.GetFont(FontFactory.HELVETICA, 10)))

        tableTotales.AddCell(New Phrase("IGV (18%):", FontFactory.GetFont(FontFactory.HELVETICA, 10)))
        tableTotales.AddCell(New Phrase("S/ " & Convert.ToDecimal(row("IGV")).ToString("F2"), FontFactory.GetFont(FontFactory.HELVETICA, 10)))

        tableTotales.AddCell(New Phrase("Total con IGV:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
        tableTotales.AddCell(New Phrase("S/ " & Convert.ToDecimal(row("TotalConIGV")).ToString("F2"), FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))

        doc.Add(tableTotales)
    End Sub

    Private Sub AgregarInformacionCliente(doc As Document, row As DataRow)
        doc.Add(New Paragraph($"Fecha: {Convert.ToDateTime(row("Fecha")).ToString("dd/MM/yyyy")}", FontFactory.GetFont(FontFactory.HELVETICA, 10)))
        doc.Add(New Paragraph($"Cliente: {row("NombreCliente").ToString()}", FontFactory.GetFont(FontFactory.HELVETICA, 10)))
        If row.Table.Columns.Contains("RUCCliente") AndAlso Not String.IsNullOrEmpty(row("RUCCliente").ToString()) Then
            doc.Add(New Paragraph($"RUC: {row("RUCCliente").ToString()}", FontFactory.GetFont(FontFactory.HELVETICA, 10)))
        End If
        doc.Add(New Paragraph(" ")) ' Espacio adicional
    End Sub

    Private Sub AgregarTablaDetalles(doc As Document, dtDetalles As DataTable)
        ' Crear una tabla con 5 columnas: Item, Descripción, Cantidad, Precio Unitario, Precio Total
        Dim table As New PdfPTable(5)
        table.WidthPercentage = 100
        table.SetWidths(New Single() {1.0F, 4.0F, 1.5F, 1.5F, 1.5F}) ' Anchos relativos de las columnas

        ' Encabezados de la tabla
        Dim cell As PdfPCell
        cell = New PdfPCell(New Phrase("Item", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)))
        cell.HorizontalAlignment = Element.ALIGN_CENTER
        table.AddCell(cell)

        cell = New PdfPCell(New Phrase("Descripción", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)))
        cell.HorizontalAlignment = Element.ALIGN_CENTER
        table.AddCell(cell)

        cell = New PdfPCell(New Phrase("Cantidad", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)))
        cell.HorizontalAlignment = Element.ALIGN_CENTER
        table.AddCell(cell)

        cell = New PdfPCell(New Phrase("Precio Unit.", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)))
        cell.HorizontalAlignment = Element.ALIGN_CENTER
        table.AddCell(cell)

        cell = New PdfPCell(New Phrase("Precio Total", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)))
        cell.HorizontalAlignment = Element.ALIGN_CENTER
        table.AddCell(cell)

        ' Agregar filas con los detalles
        Dim itemIndex As Integer = 1
        For Each detalleRow As DataRow In dtDetalles.Rows
            table.AddCell(New Phrase(itemIndex.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10)))
            table.AddCell(New Phrase(detalleRow("MenuNombre").ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10)))
            table.AddCell(New Phrase(detalleRow("DetallesPedidoCantidad").ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 10)))
            table.AddCell(New Phrase(Convert.ToDecimal(detalleRow("DetallesPedidoPrecio")).ToString("F2"), FontFactory.GetFont(FontFactory.HELVETICA, 10)))
            table.AddCell(New Phrase(Convert.ToDecimal(detalleRow("Total")).ToString("F2"), FontFactory.GetFont(FontFactory.HELVETICA, 10)))
            itemIndex += 1
        Next

        doc.Add(table)
    End Sub

    ' Método para generar el PDF de la boleta
    Private Sub GenerarBoletaPDF(dtComprobante As DataTable)
        Dim nombreArchivo As String = "Boleta_" & PedidoCodigo & ".pdf"
        Dim rutaArchivo As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nombreArchivo)

        Dim doc As New Document(PageSize.A4, 40, 40, 40, 20)
        Try
            PdfWriter.GetInstance(doc, New FileStream(rutaArchivo, FileMode.Create))
            doc.Open()

            Dim row As DataRow = dtComprobante.Rows(0)

            ' Agregar secciones al documento
            AgregarCabeceraEmpresa(doc)
            Dim tituloComprobante As New Paragraph("BOLETA DE VENTA", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16))
            tituloComprobante.Alignment = Element.ALIGN_CENTER
            doc.Add(tituloComprobante)
            doc.Add(New Paragraph("Código de Boleta: " & row("CodigoComprobante").ToString(), FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
            doc.Add(New Paragraph(" ")) ' Espacio
            AgregarInformacionCliente(doc, row)

            ' Obtener y agregar los detalles del pedido
            Dim dtDetalles As DataTable = procesoPagoServicio.ObtenerDetallesPedido(PedidoCodigo)
            AgregarTablaDetalles(doc, dtDetalles)

            ' Agregar totales
            AgregarTotales(doc, row)

            doc.Close()
            Process.Start(rutaArchivo)
            MessageBox.Show("Boleta generada correctamente en: " & rutaArchivo)
        Catch ex As Exception
            Throw New Exception("Error al generar la boleta: " & ex.Message)
        End Try
    End Sub

    ' Método para generar el PDF de la factura
    Private Sub GenerarFacturaPDF(dtComprobante As DataTable)
        Dim nombreArchivo As String = "Factura_" & PedidoCodigo & ".pdf"
        Dim rutaArchivo As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nombreArchivo)

        Dim doc As New Document(PageSize.A4, 40, 40, 40, 20)
        Try
            PdfWriter.GetInstance(doc, New FileStream(rutaArchivo, FileMode.Create))
            doc.Open()

            Dim row As DataRow = dtComprobante.Rows(0)

            ' Agregar secciones al documento
            AgregarCabeceraEmpresa(doc)
            Dim tituloComprobante As New Paragraph("FACTURA", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16))
            tituloComprobante.Alignment = Element.ALIGN_CENTER
            doc.Add(tituloComprobante)
            doc.Add(New Paragraph("Código de Factura: " & row("CodigoComprobante").ToString(), FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
            doc.Add(New Paragraph(" ")) ' Espacio
            AgregarInformacionCliente(doc, row)

            ' Obtener y agregar los detalles del pedido
            Dim dtDetalles As DataTable = procesoPagoServicio.ObtenerDetallesPedido(PedidoCodigo)
            AgregarTablaDetalles(doc, dtDetalles)

            ' Agregar totales
            AgregarTotales(doc, row)

            doc.Close()
            Process.Start(rutaArchivo)
            MessageBox.Show("Factura generada correctamente en: " & rutaArchivo)
        Catch ex As Exception
            Throw New Exception("Error al generar la factura: " & ex.Message)
        End Try
    End Sub

End Class
