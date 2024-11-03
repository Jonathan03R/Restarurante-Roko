Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class ComprobantePagoSQL

    '================================================================================
    '                          BOLETAS
    '================================================================================
    Public Sub RegistrarPago(pago As Pago)
        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spRegistrarPago")

            cmd.Parameters.Add("@PagoCodigo", SqlDbType.NChar, 8).Value = pago.PagoCodigo.Trim()
            cmd.Parameters.Add("@PagoPedidoCodigo", SqlDbType.NChar, 8).Value = pago.pedido.PedidosCodigo.Trim()
            cmd.Parameters.Add("@PagoMonto", SqlDbType.Decimal).Value = pago.PagoMonto

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub crearBoleta(boleta As Boleta)
        Try

            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spCrearBoleta")
            cmd.Parameters.Add("@BoletaCodigo", SqlDbType.NChar, 8).Value = boleta.RestauranteBoletasCodigo.Trim()
            cmd.Parameters.Add("@BoletaPedidosCodigo", SqlDbType.NChar, 8).Value = boleta.Pedido.PedidosCodigo.Trim()
            cmd.Parameters.Add("@BoletaEmpleadosCodigo", SqlDbType.NChar, 8).Value = boleta.Empleado.EmpleadosCodigo.Trim()
            cmd.Parameters.Add("@BoletaClientesCodigo", SqlDbType.NChar, 8).Value = boleta.Cliente.ClientesCodigo.Trim()

            cmd.Parameters.Add("@BoletaTotal", SqlDbType.Decimal).Value = boleta.RestauranteBoletasTotal()
            cmd.Parameters.Add("@BoletaClienteNombreCompleto", SqlDbType.NVarChar, 200).Value = boleta.RestauranteBoletasClienteNombreCompleto()

            cmd.ExecuteNonQuery()

        Catch ex As Exception

            Throw ex
        End Try


    End Sub

    '================================================================================
    '                          FACTURAS
    '================================================================================


    Public Sub crearFactura(factura As Factura)
        Try

            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spCrearFactura")
            cmd.Parameters.Add("@facturaCodigo", SqlDbType.NChar, 8).Value = factura.FacturasCodigo.Trim()
            cmd.Parameters.Add("@facturaPedidoCodigo", SqlDbType.NChar, 8).Value = factura.Pedido.PedidosCodigo.Trim()
            cmd.Parameters.Add("@facturaPedidoMesaCodigo", SqlDbType.NChar, 8).Value = factura.Pedido.Mesa.MesasCodigo.Trim()
            cmd.Parameters.Add("@facturaTotal", SqlDbType.Decimal).Value = factura.FacturasTotal
            cmd.Parameters.Add("@facturaEmpresaCliente", SqlDbType.NVarChar, 150).Value = factura.FacturaEmpresaCliente
            cmd.Parameters.Add("@facturaRUC", SqlDbType.NVarChar, 50).Value = factura.FacturaRuc

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
