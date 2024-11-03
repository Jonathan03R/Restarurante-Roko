Public Class Factura

    Public Property FacturasCodigo As String
    Public Property FacturaClientesCodigo As String
    Public Property FacturasNumeroFacura As String
    Public Property FacturasFechaCreacion As Date
    Public Property FacturasTotal As Double
    Public Property FacturaRuc As String
    Public Property FacturaEmpresaCliente As String
    Public Property FacturasEstado As String

    Public Property Pedido As Pedido
    Public Property Cliente As Cliente
End Class
