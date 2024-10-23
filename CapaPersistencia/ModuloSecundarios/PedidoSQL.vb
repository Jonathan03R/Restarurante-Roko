Imports System.Data.SqlClient

Public Class PedidoSQL
    ' Método para crear un nuevo pedido en la base de datos
    Public Sub CrearPedido(pedidoCodigo As String, mesaCodigo As String, empleadoCodigo As String)
        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spCrearPedido", cn)
            cmd.CommandType = CommandType.StoredProcedure

            ' Pasar los parámetros al procedimiento almacenado
            cmd.Parameters.AddWithValue("@PedidosCodigo", pedidoCodigo) ' Código generado
            cmd.Parameters.AddWithValue("@MesasCodigo", mesaCodigo)
            cmd.Parameters.AddWithValue("@EmpleadosCodigo", empleadoCodigo)

            ' Abrir conexión y ejecutar
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        End Using
    End Sub

    Public Function ObtenerPedidoPorMesa(mesaCodigo As String) As Pedido
        Dim pedido As New Pedido()

        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spObtenerPedidoPorMesa", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@MesasCodigo", mesaCodigo)

            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader()

            If dr.Read() Then
                pedido.PedidosCodigo = dr("PedidosCodigo").ToString()
                pedido.PedidosMesasCodigo = dr("PedidosMesasCodigo").ToString()
                pedido.PedidosEmpleadosCodigo = dr("PedidosEmpleadosCodigo").ToString()
                pedido.PedidoFecha = Convert.ToDateTime(dr("PedidoFecha"))
                pedido.PedidosEstado = dr("PedidosEstado").ToString()
            End If

            dr.Close()
        End Using

        Return pedido
    End Function

    Public Sub CompletarPagoYFinalizarPedido(pedidoCodigo As String, mesaCodigo As String, pagoCodigo As String, empleadoCodigo As String, monto As Decimal, generarBoleta As Boolean, generarFactura As Boolean, boletaCodigo As String, facturaCodigo As String, boletaClientesCodigo As String, boletaNombreCompletoCliente As String, clienteNombreCompleto As String, clienteRUC As String, mesaCodigoPedido As String)

        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spCompletarPagoYFinalizarPedido", cn)
            cmd.CommandType = CommandType.StoredProcedure

            ' Parámetros básicos
            cmd.Parameters.AddWithValue("@PedidosCodigo", pedidoCodigo)
            cmd.Parameters.AddWithValue("@MesasCodigo", mesaCodigo)
            cmd.Parameters.AddWithValue("@PagoCodigo", pagoCodigo)
            cmd.Parameters.AddWithValue("@EmpleadosCodigo", empleadoCodigo)
            cmd.Parameters.AddWithValue("@Monto", monto)
            cmd.Parameters.AddWithValue("@GenerarBoleta", generarBoleta)
            cmd.Parameters.AddWithValue("@GenerarFactura", generarFactura)

            ' Parámetros desnormalizados para factura
            If generarFactura Then
                cmd.Parameters.AddWithValue("@ClientesNombreCompleto", clienteNombreCompleto)
                cmd.Parameters.AddWithValue("@ClientesRUC", clienteRUC) ' RUC del cliente
                cmd.Parameters.AddWithValue("@FacturaCodigo", facturaCodigo)
            End If

            ' Si se genera boleta, se pasa el código de boleta, el código de cliente y su nombre completo
            If generarBoleta Then
                cmd.Parameters.AddWithValue("@BoletaCodigo", boletaCodigo)
                cmd.Parameters.AddWithValue("@BoletaClientesCodigo", boletaClientesCodigo) ' Código del cliente en la boleta
                cmd.Parameters.AddWithValue("@BoletaNombreCompletoCliente", boletaNombreCompletoCliente) ' Nombre completo del cliente para boleta
            End If

            ' El código de mesa es necesario para ambos
            cmd.Parameters.AddWithValue("@PedidoMesaCodigo", mesaCodigoPedido)

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        End Using
    End Sub

    Public Sub FinalizarPedido(pedidoCodigo As String)
        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spFinalizarPedido", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@PedidosCodigo", pedidoCodigo)

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        End Using
    End Sub

    Public Function ObtenerPedidosConDetalle() As List(Of Pedido)
        Dim listaPedidos As New List(Of Pedido)()

        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("Restaurante.spObtenerPedidosConDetalle", cn)
            cmd.CommandType = CommandType.StoredProcedure

            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader()

            While dr.Read()
                Dim pedido As New Pedido()
                pedido.PedidosCodigo = dr("CodigoPedido").ToString()
                pedido.PedidosMesasCodigo = dr("CodigoMesa").ToString()
                pedido.PedidosEmpleadosCodigo = dr("CodigoEmpleado").ToString()

                ' Mapea los datos de Empleado y su RolPermiso
                pedido.Empleado = New Empleado() With {
                    .EmpleadosCodigo = dr("CodigoEmpleado").ToString(),
                    .EmpleadosNombreCompleto = dr("NombreEmpleado").ToString(),
                    .RolPermiso = New RolPermiso() With {
                        .RolesPermisosNombreRol = dr("CargoEmpleado").ToString()
                    }
                }

                pedido.PedidosEstado = dr("EstadoPedido").ToString()

                listaPedidos.Add(pedido)
            End While

            dr.Close()
        End Using

        Return listaPedidos
    End Function

End Class
