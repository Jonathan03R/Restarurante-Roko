Public Class Boleta
    Public Property RestauranteBoletasCodigo As String
    Public Property RestauranteBoletasFechaHora As Date
    Public Property RestauranteBoletasTotal As Double
    Public Property RestauranteBoletasEstado As String

    'desnormalizado
    Public Property RestauranteBoletasClienteNombreCompleto As String

    Public Property Pedido As Pedido
    Public Property Empleado As Empleado
    Public Property Cliente As Cliente


End Class
