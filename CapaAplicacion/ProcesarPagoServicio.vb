Imports System.Data.SqlClient

Public Class ProcesarPagoServicio
    Private clienteSQL As New ClienteSQL()
    Private codigoSQL As New CodigosSQL()
    Private pedidoSQL As New PedidoSQL()

    Private pagoSQL As New PagoSQL()
    Private mesaSQL As New MesaSQL()
    Private detallesPedidosSQL As New DetallePedidoSQL()

    Private comprobanteSQL As New ComprobantePagoSQL()
    Private documentosSQL As New DocumentoSQL()
    Public Function buscarClientesPorNombre(nombre As String) As DataTable
        Try

            ModuloSistema.IniciarTransaccion()
            Dim listaClientes As List(Of Cliente) = clienteSQL.BuscarClientesPorNombre(nombre)
            ModuloSistema.TerminarTransaccion()

            ' Convertir la lista de clientes en un DataTable
            Dim dataTable As New DataTable()
            dataTable.Columns.Add("ClientesCodigo", GetType(String))
            dataTable.Columns.Add("ClientesNombreCompleto", GetType(String))
            dataTable.Columns.Add("ClientesTelefono", GetType(String))
            dataTable.Columns.Add("ClientesDNI", GetType(String))
            dataTable.Columns.Add("ClientesCorreo", GetType(String))
            dataTable.Columns.Add("ClientesFechaRegistro", GetType(DateTime))
            dataTable.Columns.Add("ClientesEstado", GetType(String))

            For Each cliente As Cliente In listaClientes
                Dim row As DataRow = dataTable.NewRow()
                row("ClientesCodigo") = cliente.ClientesCodigo
                row("ClientesNombreCompleto") = cliente.ClientesNombreCompleto
                row("ClientesTelefono") = cliente.ClientesTelefono
                row("ClientesDNI") = cliente.ClientesDNI
                row("ClientesCorreo") = cliente.ClientesCorreo
                row("ClientesFechaRegistro") = cliente.ClientesFechaRegistro
                row("ClientesEstado") = cliente.ClientesEstado
                dataTable.Rows.Add(row)
            Next

            Return dataTable
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw ex
        End Try
    End Function


    'Public Function CompletarPago(pedidoCodigo As String, mesaCodigo As String, empleadoCodigo As String, monto As Decimal, generarBoleta As Boolean, generarFactura As Boolean, boletaClientesCodigo As String, boletaNombreCompletoCliente As String, clienteNombreCompleto As String, clienteRUC As String, mesaCodigoPedido As String) As String
    '    ' Validaciones
    '    If String.IsNullOrEmpty(pedidoCodigo) Then
    '        Throw New Exception("El código del pedido no puede estar vacío.")
    '    End If
    '    If String.IsNullOrEmpty(mesaCodigo) Then
    '        Throw New Exception("El código de la mesa no puede estar vacío.")
    '    End If
    '    If String.IsNullOrEmpty(empleadoCodigo) Then
    '        Throw New Exception("El código del empleado no puede estar vacío.")
    '    End If
    '    If monto <= 0 Then
    '        Throw New Exception("El monto debe ser mayor a cero.")
    '    End If
    '    If generarBoleta AndAlso generarFactura Then
    '        Throw New Exception("No puede generar ambos, boleta y factura al mismo tiempo.")
    '    End If

    '    Dim codigoGenerado As String = String.Empty ' Variable para el código de boleta o factura generado
    '    Try
    '        ModuloSistema.IniciarTransaccion()

    '        Dim pagoCodigo As String = codigoSQL.GenerarCodigoUnico("PAG", "Restaurante.Pago", "PagoCodigo")
    '        Dim boletaCodigo As String = Nothing
    '        Dim facturaCodigo As String = Nothing

    '        If generarBoleta Then
    '            If String.IsNullOrEmpty(boletaClientesCodigo) OrElse String.IsNullOrEmpty(boletaNombreCompletoCliente) Then
    '                Throw New Exception("El código del cliente y el nombre completo del cliente son obligatorios para generar una boleta.")
    '            End If
    '            boletaCodigo = codigoSQL.GenerarCodigoUnico("BOL", "Restaurante.Boletas", "RestauranteBoletasCodigo")
    '            If String.IsNullOrEmpty(boletaCodigo) Then
    '                Throw New Exception("No se pudo generar un código de boleta válido.")
    '            End If
    '            codigoGenerado = boletaCodigo
    '        End If
    '        If generarFactura Then
    '            If String.IsNullOrEmpty(clienteNombreCompleto) OrElse String.IsNullOrEmpty(clienteRUC) Then
    '                Throw New Exception("El nombre completo del cliente y el RUC son obligatorios para generar una factura.")
    '            End If
    '            facturaCodigo = codigoSQL.GenerarCodigoUnico("FAC", "Restaurante.Facturas", "FacturasCodigo")
    '            If String.IsNullOrEmpty(facturaCodigo) Then
    '                Throw New Exception("No se pudo generar un código de factura válido.")
    '            End If
    '            codigoGenerado = facturaCodigo
    '        End If

    '        ' Intentar completar el pago y finalizar el pedido
    '        pedidoSQL.CompletarPagoYFinalizarPedido(pedidoCodigo, mesaCodigo, pagoCodigo, empleadoCodigo, monto, generarBoleta, generarFactura, boletaCodigo, facturaCodigo, boletaClientesCodigo, boletaNombreCompletoCliente, clienteNombreCompleto, clienteRUC, mesaCodigoPedido)
    '        ModuloSistema.TerminarTransaccion()

    '        ' Retornar el código generado de boleta o factura
    '        Return codigoGenerado

    '    Catch ex As Exception
    '        ModuloSistema.CancelarTransaccion()
    '        Throw ex
    '    End Try
    'End Function

    Public Function completarPago(pago As Pago, pedidoCodigo As Pedido, mesaCodigo As Mesa, boleta As Boleta, factura As Factura, generarBoleta As Boolean, generarFactura As Boolean) As Pedido
        Try

            ModuloSistema.IniciarTransaccion()
            If String.IsNullOrEmpty(pedidoCodigo.PedidosCodigo) Then
                Throw New Exception("El código del pedido no puede estar vacío.")
            End If
            pago.PagoCodigo = codigoSQL.GenerarCodigoUnico("PAG", "Restaurante.Pago", "PagoCodigo")

            comprobanteSQL.RegistrarPago(pago)
            pedidoSQL.FinalizarPedido(pedidoCodigo)
            mesaSQL.DesocuparMesa(mesaCodigo)

            Dim codigoComprobante As String = String.Empty

            If generarBoleta AndAlso Not generarFactura Then
                boleta.RestauranteBoletasCodigo = codigoSQL.GenerarCodigoUnico("BOL", "Restaurante.Boletas", "RestauranteBoletasCodigo")
                comprobanteSQL.crearBoleta(boleta)
            ElseIf generarFactura AndAlso Not generarBoleta Then
                factura.Pedido.Mesa.MesasCodigo = mesaCodigo.MesasCodigo
                factura.FacturasCodigo = codigoSQL.GenerarCodigoUnico("FAC", "Restaurante.Facturas", "FacturasCodigo")
                comprobanteSQL.crearFactura(factura)
            Else
                ' Lanzar excepción si ambos o ninguno son seleccionados
                Throw New Exception("Debe seleccionar solo una opción entre Boleta o Factura.")
            End If

            ModuloSistema.TerminarTransaccion()
            Return pedidoCodigo
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw ex
        End Try
    End Function

    Public Function ObtenerDetallesPedidoComoDataTable(mesaCodigo As Mesa) As DataTable
        Try
            ' Iniciar la transacción para obtener detalles de pedido
            ModuloSistema.IniciarTransaccion()
            Dim pedido As Pedido = pedidoSQL.ObtenerPedidoPorMesa(mesaCodigo)
            If pedido Is Nothing OrElse String.IsNullOrWhiteSpace(pedido.PedidosCodigo) Then
                Throw New Exception("No se encontró un pedido activo para la mesa especificada.")
            End If

            Dim listaDetalles As List(Of DetallePedido) = detallesPedidosSQL.ObtenerDetallesPedido(pedido.PedidosCodigo)
            ModuloSistema.TerminarTransaccion()

            ' Convertir la lista de DetallePedido en un DataTable
            Dim dataTable As New DataTable()
            dataTable.Columns.Add("DetallesPedidoCodigo", GetType(String))
            dataTable.Columns.Add("DetallesPedidoMenuCodigo", GetType(String))
            dataTable.Columns.Add("MenuNombre", GetType(String))
            dataTable.Columns.Add("DetallesPedidoPrecio", GetType(Double))
            dataTable.Columns.Add("DetallesPedidoCantidad", GetType(Double))
            dataTable.Columns.Add("Total", GetType(Double))
            dataTable.Columns.Add("DetallesPedidoEstado", GetType(String))

            For Each detalle As DetallePedido In listaDetalles
                Dim row As DataRow = dataTable.NewRow()
                row("DetallesPedidoCodigo") = detalle.DetallesPedidoCodigo
                row("DetallesPedidoMenuCodigo") = detalle.DetallesPedidoMenuCodigo
                row("MenuNombre") = detalle.Menu.MenuNombre
                row("DetallesPedidoPrecio") = detalle.DetallesPedidoPrecio
                row("DetallesPedidoCantidad") = detalle.DetallesPedidoCantidad
                row("Total") = detalle.CalcularTotal()
                row("DetallesPedidoEstado") = detalle.DetallesPedidoEstado
                dataTable.Rows.Add(row)
            Next

            Return dataTable
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw ex
        End Try
    End Function
    Public Function ObtenerDetallesPedido(codigoPedido As String) As DataTable
        Try
            ' Iniciar la transacción para obtener detalles de pedido
            ModuloSistema.IniciarTransaccion()


            Dim listaDetalles As List(Of DetallePedido) = detallesPedidosSQL.ObtenerDetallesPedido(codigoPedido)
            ModuloSistema.TerminarTransaccion()

            ' Convertir la lista de DetallePedido en un DataTable
            Dim dataTable As New DataTable()
            dataTable.Columns.Add("DetallesPedidoCodigo", GetType(String))
            dataTable.Columns.Add("DetallesPedidoMenuCodigo", GetType(String))
            dataTable.Columns.Add("MenuNombre", GetType(String))
            dataTable.Columns.Add("DetallesPedidoPrecio", GetType(Double))
            dataTable.Columns.Add("DetallesPedidoCantidad", GetType(Double))
            dataTable.Columns.Add("Total", GetType(Double))
            dataTable.Columns.Add("DetallesPedidoEstado", GetType(String))

            For Each detalle As DetallePedido In listaDetalles
                Dim row As DataRow = dataTable.NewRow()
                row("DetallesPedidoCodigo") = detalle.DetallesPedidoCodigo
                row("DetallesPedidoMenuCodigo") = detalle.DetallesPedidoMenuCodigo
                row("MenuNombre") = detalle.Menu.MenuNombre
                row("DetallesPedidoPrecio") = detalle.DetallesPedidoPrecio
                row("DetallesPedidoCantidad") = detalle.DetallesPedidoCantidad
                row("Total") = detalle.CalcularTotal()
                row("DetallesPedidoEstado") = detalle.DetallesPedidoEstado
                dataTable.Rows.Add(row)
            Next

            Return dataTable
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw ex
        End Try
    End Function



    Public Function ObtenerComprobantePorPedido(pedidoCodigo As Pedido) As DataTable
        Dim dtComprobante As DataTable
        Try
            ModuloSistema.IniciarTransaccion()
            dtComprobante = pedidoSQL.ObtenerComprobantePorPedido(pedidoCodigo)
            ModuloSistema.TerminarTransaccion()
            Return dtComprobante

        Catch ex As Exception
            Throw ex
            ModuloSistema.CancelarTransaccion()
        End Try
    End Function

    Public Sub GuardarDocumentoPDF(documento As Documento)
        Try
            ModuloSistema.IniciarTransaccion()
            documento.documentoCodigo = codigoSQL.GenerarCodigoUnico("DOC", "Restaurante.Documentos", "DocumentoCodigo")
            documentosSQL.agregarDocumento(documento)
            ModuloSistema.TerminarTransaccion()
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw ex
        End Try
    End Sub

    Public Function obtenerDocumentosComoDataTable() As DataTable
        Try
            ModuloSistema.IniciarTransaccion()

            Dim documentosSQL As New DocumentoSQL()
            Dim listaDocumentos As DataTable = documentosSQL.ListarDocumentos()

            Dim dataTable As New DataTable()
            dataTable.Columns.Add("DocumentoCodigo", GetType(String))
            dataTable.Columns.Add("DocumentoReferencias", GetType(String))
            dataTable.Columns.Add("DocumentoTipo", GetType(String))
            dataTable.Columns.Add("DocumentoFecha", GetType(DateTime))

            For Each row As DataRow In listaDocumentos.Rows
                dataTable.Rows.Add(
                row("DocumentoCodigo").ToString(),
                row("DocumentoReferencias").ToString(),
                row("DocumentoTipo").ToString(),
                Convert.ToDateTime(row("DocumentoFecha"))
            )
            Next
            ModuloSistema.TerminarTransaccion()
            Return dataTable

        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw New Exception("Error al obtener los documentos como DataTable: " & ex.Message)
        End Try
    End Function


    Public Function ObtenerDocumentoPDF(documentoCodigo As String) As Byte()
        Try
            ModuloSistema.IniciarTransaccion()

            Dim archivoPDF As Byte() = documentosSQL.ObtenerDocumentoPDF(New Documento With {.documentoCodigo = documentoCodigo})

            ModuloSistema.TerminarTransaccion()

            Return archivoPDF
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw New Exception("Error al obtener el documento PDF desde la capa de aplicación: " & ex.Message)
        End Try
    End Function


End Class
