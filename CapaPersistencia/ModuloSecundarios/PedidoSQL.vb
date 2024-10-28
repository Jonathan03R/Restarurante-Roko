Imports System.Data.SqlClient

Public Class PedidoSQL



    ' Método para crear un nuevo pedido en la base de datos
    Public Sub CrearPedido(pedidoCodigo As String, mesaCodigo As String, empleadoCodigo As String)
        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spCrearPedido")

            ' Pasar los parámetros al procedimiento almacenado
            cmd.Parameters.AddWithValue("@PedidosCodigo", pedidoCodigo)
            cmd.Parameters.AddWithValue("@MesasCodigo", mesaCodigo)
            cmd.Parameters.AddWithValue("@EmpleadosCodigo", empleadoCodigo)

            ' Ejecutar el comando
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Throw New Exception("Error al crear el pedido: " & ex.Message)

        End Try
    End Sub

    Public Function ObtenerPedidoPorMesa(mesaCodigo As String) As Pedido
        Dim pedido As Pedido = Nothing
        Try
            ' Obtener el comando para el procedimiento almacenado desde ModuloSistema
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spObtenerPedidoPorMesa")
            cmd.Parameters.AddWithValue("@MesasCodigo", mesaCodigo)

            ' Ejecutar el comando y leer los resultados
            Using dr As SqlDataReader = cmd.ExecuteReader()
                If dr.Read() Then
                    pedido = New Pedido()
                    pedido.PedidosCodigo = dr("PedidosCodigo").ToString()
                    pedido.PedidosMesasCodigo = dr("PedidosMesasCodigo").ToString()
                    pedido.PedidosEmpleadosCodigo = dr("PedidosEmpleadosCodigo").ToString()
                    pedido.PedidoFecha = Convert.ToDateTime(dr("PedidoFecha"))
                    pedido.PedidosEstado = dr("PedidosEstado").ToString()
                End If
            End Using
        Catch ex As Exception
            Throw ex

        End Try

        Return Pedido
    End Function

    ' Método para completar el pago y finalizar un pedido
    Public Sub CompletarPagoYFinalizarPedido(pedidoCodigo As String, mesaCodigo As String, pagoCodigo As String, empleadoCodigo As String, monto As Decimal, generarBoleta As Boolean, generarFactura As Boolean, boletaCodigo As String, facturaCodigo As String, boletaClientesCodigo As String, boletaNombreCompletoCliente As String, clienteNombreCompleto As String, clienteRUC As String, mesaCodigoPedido As String)
        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spCompletarPagoYFinalizarPedido")

            ' Parámetros básicos
            cmd.Parameters.AddWithValue("@PedidosCodigo", pedidoCodigo)
            cmd.Parameters.AddWithValue("@MesasCodigo", mesaCodigo)
            cmd.Parameters.AddWithValue("@PagoCodigo", pagoCodigo)
            cmd.Parameters.AddWithValue("@EmpleadosCodigo", empleadoCodigo)
            cmd.Parameters.AddWithValue("@Monto", monto)
            cmd.Parameters.AddWithValue("@GenerarBoleta", generarBoleta)
            cmd.Parameters.AddWithValue("@GenerarFactura", generarFactura)

            ' Parámetros adicionales según el tipo de documento
            If generarFactura Then
                cmd.Parameters.AddWithValue("@ClientesNombreCompleto", clienteNombreCompleto)
                cmd.Parameters.AddWithValue("@ClientesRUC", clienteRUC)
                cmd.Parameters.AddWithValue("@FacturaCodigo", facturaCodigo)
            End If

            If generarBoleta Then
                cmd.Parameters.AddWithValue("@BoletaCodigo", boletaCodigo)
                cmd.Parameters.AddWithValue("@BoletaClientesCodigo", boletaClientesCodigo)
                cmd.Parameters.AddWithValue("@BoletaNombreCompletoCliente", boletaNombreCompletoCliente)
            End If

            cmd.Parameters.AddWithValue("@PedidoMesaCodigo", mesaCodigoPedido)

            ' Ejecutar el comando
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Error al completar el pago y finalizar el pedido: " & ex.Message)

        End Try
    End Sub

    Public Sub FinalizarPedido(pedidoCodigo As String)
        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spFinalizarPedido")
            cmd.Parameters.AddWithValue("@PedidosCodigo", pedidoCodigo)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Public Function ObtenerPedidosConDetalle() As List(Of Pedido)
        Dim listaPedidos As New List(Of Pedido)()
        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("Restaurante.spObtenerPedidosConDetalle")

            ' Ejecutar el comando y leer los resultados
            Using dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    Dim pedido As New Pedido() With {
                        .PedidosCodigo = dr("CodigoPedido").ToString(),
                        .PedidosMesasCodigo = dr("CodigoMesa").ToString(),
                        .PedidosEmpleadosCodigo = dr("CodigoEmpleado").ToString(),
                        .PedidosEstado = dr("EstadoPedido").ToString(),
                        .Empleado = New Empleado() With {
                            .EmpleadosCodigo = dr("CodigoEmpleado").ToString(),
                            .EmpleadosNombreCompleto = dr("NombreEmpleado").ToString(),
                            .RolPermiso = New RolPermiso() With {
                                .RolesPermisosNombreRol = dr("CargoEmpleado").ToString()
                            }
                        }
                    }
                    listaPedidos.Add(pedido)
                End While
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener pedidos con detalle: " & ex.Message)

        End Try
        Return listaPedidos
    End Function


    Public Function ObtenerComprobantePorPedido(pedidoCodigo As String) As DataTable
        Dim dtComprobante As New DataTable()
        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("Restaurante.spObtenerComprobantePorPedido")
            cmd.Parameters.AddWithValue("@PedidoCodigo", pedidoCodigo)

            ' Ejecutar el comando y llenar el DataTable con los resultados
            Using dr As SqlDataReader = cmd.ExecuteReader()
                dtComprobante.Load(dr)
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener el comprobante por pedido: " & ex.Message)
        End Try
        Return dtComprobante
    End Function
End Class
