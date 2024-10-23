Imports System.Data.SqlClient

Public Class DetallePedidoSQL
    Public Sub AgregarDetallePedido(detalleCodigo As String, pedidoCodigo As String, detalle As DetallePedido)
        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spAgregarDetallesPedido", cn)
            cmd.CommandType = CommandType.StoredProcedure

            ' Pasar los parámetros al procedimiento almacenado
            cmd.Parameters.AddWithValue("@DetallesPedidoCodigo", detalleCodigo) ' Código generado
            cmd.Parameters.AddWithValue("@PedidosCodigo", pedidoCodigo)
            cmd.Parameters.AddWithValue("@MenuCodigo", detalle.DetallesPedidoMenuCodigo)
            cmd.Parameters.AddWithValue("@Precio", detalle.DetallesPedidoPrecio)
            cmd.Parameters.AddWithValue("@Cantidad", detalle.DetallesPedidoCantidad)

            ' Abrir conexión y ejecutar
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        End Using
    End Sub

    Public Function ObtenerDetallesPedido(pedidoCodigo As String) As List(Of DetallePedido)
        Dim listaDetalles As New List(Of DetallePedido)

        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spObtenerDetallesPedido", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@PedidosCodigo", pedidoCodigo)

            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader()

            While dr.Read()
                Dim detalle As New DetallePedido With {
                    .DetallesPedidoCodigo = dr("DetallesPedidoCodigo").ToString(),
                    .DetallesPedidoMenuCodigo = dr("DetallesPedidoMenuCodigo").ToString(),
                    .DetallesPedidoPrecio = Convert.ToDouble(dr("DetallesPedidoPrecio")),
                    .DetallesPedidoCantidad = Convert.ToDouble(dr("DetallesPedidoCantidad")),
                    .DetallesPedidoEstado = dr("DetallesPedidoEstado").ToString()
                }
                detalle.Menu = New Menu()
                detalle.Menu.MenuCodigo = dr("DetallesPedidoMenuCodigo").ToString().Trim()
                detalle.Menu.MenuNombre = dr("MenuNombre").ToString()
                detalle.Menu.MenuPrecio = Convert.ToDouble(dr("DetallesPedidoPrecio"))
                listaDetalles.Add(detalle)
            End While

            dr.Close()
        End Using

        Return listaDetalles
    End Function

    Public Sub EliminarDetallePedido(detalleCodigo As String)
        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spEliminarDetallePedido", cn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@DetallesPedidoCodigo", detalleCodigo)

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        End Using
    End Sub
End Class
