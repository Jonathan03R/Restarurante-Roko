Imports System.Data.SqlClient
Imports System.IO

Public Class PagoSQL



    Public Sub RegistrarPago(pago As Pago)
        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spRegistrarPago")
            cmd.Parameters.Add("@PagoCodigo", SqlDbType.NChar, 8).Value = pago.PagoCodigo.Trim()
            cmd.Parameters.Add("@PagoPedidoCodigo", SqlDbType.NChar, 8).Value = pago.pedido.PedidosCodigo.Trim()
            cmd.Parameters.Add("@@PagoMonto", SqlDbType.Decimal).Value = pago.PagoMonto

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
