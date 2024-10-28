Public Class DetallePedido
    Public Property DetallesPedidoCodigo As String
    Public Property DetallesPedidoPedidosCodigo As String
    Public Property DetallesPedidoMenuCodigo As String
    Public Property DetallesPedidoPrecio As Double
    Public Property DetallesPedidoCantidad As Double
    Public Property DetallesPedidoEstado As String

    Public Property Pedido As Pedido
    Public Property Menu As Menu


    Public Function CalcularTotal() As Double
        Return DetallesPedidoCantidad * DetallesPedidoPrecio
    End Function

    'Public Function MenuDisponible() As Boolean
    '    Return Menu IsNot Nothing AndAlso Menu.MenuEstado = "A"
    'End Function


    Public Sub MarcarComoCancelado()
        DetallesPedidoEstado = "X" ' X para Cancelado
    End Sub

End Class
