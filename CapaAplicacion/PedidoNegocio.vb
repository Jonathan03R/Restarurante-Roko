Imports System.Data.SqlClient

Public Class PedidoNegocio
    Private pedidoSQL As New PedidoSQL()
    Dim codigoSQL As New CodigosSQL()
    Public Function CrearPedido(mesaCodigo As String, empleadoCodigo As String) As String
        Dim pedidoCodigo As String = codigoSQL.GenerarCodigoUnico("PED", "Restaurante.Pedidos", "PedidosCodigo")

        pedidoSQL.CrearPedido(pedidoCodigo, mesaCodigo, empleadoCodigo)

        Return pedidoCodigo
    End Function

    Public Function ObtenerPedidoPorMesa(mesaCodigo As String) As Pedido
        Return pedidoSQL.ObtenerPedidoPorMesa(mesaCodigo)
    End Function


    Public Sub CompletarPago(pedidoCodigo As String, mesaCodigo As String, empleadoCodigo As String, monto As Decimal, generarBoleta As Boolean, generarFactura As Boolean, boletaClientesCodigo As String, boletaNombreCompletoCliente As String, clienteNombreCompleto As String, clienteRUC As String, mesaCodigoPedido As String)
        ' Validaciones
        If String.IsNullOrEmpty(pedidoCodigo) Then
            Throw New Exception("El código del pedido no puede estar vacío.")
        End If
        If String.IsNullOrEmpty(mesaCodigo) Then
            Throw New Exception("El código de la mesa no puede estar vacío.")
        End If
        If String.IsNullOrEmpty(empleadoCodigo) Then
            Throw New Exception("El código del empleado no puede estar vacío.")
        End If
        If monto <= 0 Then
            Throw New Exception("El monto debe ser mayor a cero.")
        End If
        If generarBoleta AndAlso generarFactura Then
            Throw New Exception("No puede generar ambos, boleta y factura al mismo tiempo.")
        End If

        ' Generar códigos
        Dim pagoCodigo As String = codigoSQL.GenerarCodigoUnico("PAG", "Restaurante.Pago", "PagoCodigo")
        Dim boletaCodigo As String = Nothing
        Dim facturaCodigo As String = Nothing

        ' Generar código de boleta si es necesario
        If generarBoleta Then
            boletaCodigo = codigoSQL.GenerarCodigoUnico("BOL", "Restaurante.Boletas", "RestauranteBoletasCodigo")
            If String.IsNullOrEmpty(boletaCodigo) Then
                Throw New Exception("No se pudo generar un código de boleta válido.")
            End If
        End If

        ' Generar código de factura si es necesario
        If generarFactura Then
            facturaCodigo = codigoSQL.GenerarCodigoUnico("FAC", "Restaurante.Facturas", "FacturasCodigo")
            If String.IsNullOrEmpty(facturaCodigo) Then
                Throw New Exception("No se pudo generar un código de factura válido.")
            End If
        End If

        ' Intentar completar el pago y finalizar el pedido
        Try
            ' Pasar los parámetros correspondientes para boleta o factura
            pedidoSQL.CompletarPagoYFinalizarPedido(pedidoCodigo, mesaCodigo, pagoCodigo, empleadoCodigo, monto, generarBoleta, generarFactura, boletaCodigo, facturaCodigo, boletaClientesCodigo, boletaNombreCompletoCliente, clienteNombreCompleto, clienteRUC, mesaCodigoPedido)
        Catch ex As SqlException
            Throw New Exception("Error al completar el pago: " & ex.Message)
        End Try
    End Sub

    Public Sub FinalizarPedido(pedidoCodigo As String)
        If String.IsNullOrEmpty(pedidoCodigo) Then
            Throw New ArgumentException("El código del pedido no puede estar vacío.")
        End If
        pedidoSQL.FinalizarPedido(pedidoCodigo)
    End Sub

    Public Function ObtenerPedidosConDetalle() As List(Of Pedido)
        Return pedidoSQL.ObtenerPedidosConDetalle()
    End Function

End Class
