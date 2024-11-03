Public Class Pedido
    Public Property PedidosCodigo As String
    Public Property PedidosMesasCodigo As String
    Public Property PedidosEmpleadosCodigo As String
    Public Property PedidoFecha As Date
    Public Property PedidosEstado As String

    Public Property Mesa As Mesa
    Public Property Empleado As Empleado


    Public Function el_pedido_es_valido() As Boolean
        If PedidosEstado = "P" Then
            Return True
        Else
            Return False
        End If
    End Function



End Class
