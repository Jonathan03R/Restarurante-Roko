Imports System.Data.SqlClient

Public Class DetallePedidoSQL
    Public Sub AgregarDetallePedido(detalleCodigo As String, pedidoCodigo As String, detalle As DetallePedido)
        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spAgregarDetallesPedido")

            cmd.Parameters.AddWithValue("@DetallesPedidoCodigo", detalleCodigo)
            cmd.Parameters.AddWithValue("@PedidosCodigo", pedidoCodigo)
            cmd.Parameters.AddWithValue("@MenuCodigo", detalle.DetallesPedidoMenuCodigo)
            cmd.Parameters.AddWithValue("@Precio", detalle.DetallesPedidoPrecio)
            cmd.Parameters.AddWithValue("@Cantidad", detalle.DetallesPedidoCantidad)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ObtenerDetallesPedido(pedidoCodigo As String) As List(Of DetallePedido)
        Dim listaDetalles As New List(Of DetallePedido)

        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spObtenerDetallesPedido")
            cmd.Parameters.AddWithValue("@PedidosCodigo", pedidoCodigo)

            Using dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    Dim detalle As New DetallePedido With {
                        .DetallesPedidoCodigo = dr("DetallesPedidoCodigo").ToString(),
                        .DetallesPedidoMenuCodigo = dr("DetallesPedidoMenuCodigo").ToString(),
                        .DetallesPedidoPrecio = Convert.ToDouble(dr("DetallesPedidoPrecio")),
                        .DetallesPedidoCantidad = Convert.ToDouble(dr("DetallesPedidoCantidad")),
                        .DetallesPedidoEstado = dr("DetallesPedidoEstado").ToString()
                    }
                    detalle.Menu = New Menu() With {
                        .MenuCodigo = dr("DetallesPedidoMenuCodigo").ToString().Trim(),
                        .MenuNombre = dr("MenuNombre").ToString(),
                        .MenuPrecio = Convert.ToDouble(dr("DetallesPedidoPrecio"))
                    }
                    listaDetalles.Add(detalle)
                End While
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return listaDetalles
    End Function

    Public Sub EliminarDetallePedido(detalleCodigo As String)
        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spEliminarDetallePedido")
            cmd.Parameters.AddWithValue("@DetallesPedidoCodigo", detalleCodigo)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
