Public Class DetallePedidoNegocio
    Private detallePedidoSQL As New DetallePedidoSQL()
    Dim codigoSQL As New CodigosSQL()

    Public Sub AgregarDetallePedido(pedidoCodigo As String, detalle As DetallePedido)
        Dim detalleCodigo As String = codigoSQL.GenerarCodigoUnico("DET", "Restaurante.DetallesPedido", "DetallesPedidoCodigo")

        detallePedidoSQL.AgregarDetallePedido(detalleCodigo, pedidoCodigo, detalle)
    End Sub

    Public Function ObtenerDetallesPedido(pedidoCodigo As String) As List(Of DetallePedido)
        ' Llamar al método de la capa de persistencia para obtener los detalles del pedido
        Return DetallePedidoSQL.ObtenerDetallesPedido(pedidoCodigo)
    End Function

    Public Sub EliminarDetallePedido(detalleCodigo As String)
        detallePedidoSQL.EliminarDetallePedido(detalleCodigo)
    End Sub
End Class
