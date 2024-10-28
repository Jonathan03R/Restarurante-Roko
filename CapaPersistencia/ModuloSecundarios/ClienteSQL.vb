Imports System.Data.SqlClient

Public Class ClienteSQL

    ' Método para obtener todos los clientes activos
    Public Function ObtenerClientesActivos() As List(Of Cliente)
        Dim listaClientes As New List(Of Cliente)
        Dim procedimientoSQL As String = "spListarClientesActivos"

        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento(procedimientoSQL)
            Using dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    Dim cliente As New Cliente() With {
                        .ClientesCodigo = dr("ClientesCodigo").ToString(),
                        .ClientesNombre = dr("ClientesNombre").ToString(),
                        .ClientesApellidos = dr("ClientesApellidos").ToString(),
                        .ClientesTelefono = dr("ClientesTelefono").ToString(),
                        .ClientesDNI = dr("ClientesDNI").ToString(),
                        .ClientesCorreo = dr("ClientesCorreo").ToString(),
                        .ClientesFechaRegistro = Convert.ToDateTime(dr("ClientesFechaRegistro")),
                        .ClientesEstado = dr("ClientesEstado").ToString()
                    }
                    listaClientes.Add(cliente)
                End While
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener clientes activos: " & ex.Message)
        Finally
            ' Cerrar la conexión
            ModuloSistema.CerrarConexion()
        End Try

        Return listaClientes
    End Function

    ' Método para obtener reservas de un cliente específico
    Public Function ObtenerReservasPorCliente(clienteCodigo As String) As List(Of MesaReserva)
        Dim reservas As New List(Of MesaReserva)
        Dim procedimientoSQL As String = "spListarReservasPorCliente"

        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento(procedimientoSQL)
            cmd.Parameters.AddWithValue("@ClientesCodigo", clienteCodigo)
            Using dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    Dim reserva As New MesaReserva() With {
                        .ReservasCodigo = dr("ReservasCodigo").ToString(),
                        .ReservasMesasCodigo = dr("ReservasMesasCodigo").ToString(),
                        .ReservasEstado = dr("ReservasEstado").ToString(),
                        .ReservasFechaHoraReserva = Convert.ToDateTime(dr("ReservasFechaHoraReserva"))
                    }
                    reservas.Add(reserva)
                End While
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener reservas del cliente: " & ex.Message)
        End Try

        Return reservas
    End Function

    ' Método para actualizar un cliente
    Public Function ActualizarCliente(cliente As Cliente) As Boolean
        Dim procedimientoSQL As String = "spActualizarCliente" ' Nombre del procedimiento almacenado

        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento(procedimientoSQL)

            ' Agregar los parámetros necesarios al comando
            cmd.Parameters.AddWithValue("@ClientesCodigo", cliente.ClientesCodigo)
            cmd.Parameters.AddWithValue("@ClientesNombre", cliente.ClientesNombre)
            cmd.Parameters.AddWithValue("@ClientesApellidos", cliente.ClientesApellidos)
            cmd.Parameters.AddWithValue("@ClientesTelefono", cliente.ClientesTelefono)
            cmd.Parameters.AddWithValue("@ClientesCorreo", cliente.ClientesCorreo)

            ' Ejecutar el comando y devolver el resultado
            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
            Return filasAfectadas > 0
        Catch ex As Exception
            Throw New Exception("Error al actualizar cliente: " & ex.Message)
        End Try
    End Function

    ' Método para eliminar un cliente
    Public Function EliminarCliente(clienteCodigo As String) As Boolean
        Dim procedimientoSQL As String = "spEliminarCliente"

        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento(procedimientoSQL)
            cmd.Parameters.AddWithValue("@clienteCodigo", clienteCodigo)
            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
            Return filasAfectadas > 0
        Catch ex As Exception
            Throw New Exception("Error al eliminar cliente: " & ex.Message)
        End Try
    End Function

    ' Método para obtener clientes borrados
    Public Function ObtenerClientesBorrados() As List(Of Cliente)
        Dim listaClientes As New List(Of Cliente)
        Dim procedimientoSQL As String = "spListarClientesBorrados"

        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento(procedimientoSQL)
            Using dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    Dim cliente As New Cliente() With {
                        .ClientesCodigo = dr("ClientesCodigo").ToString(),
                        .ClientesNombreCompleto = dr("ClientesNombreCompleto").ToString(),
                        .ClientesFechaRegistro = Convert.ToDateTime(dr("ClientesFechaRegistro"))
                    }
                    listaClientes.Add(cliente)
                End While
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener clientes borrados: " & ex.Message)
        End Try

        Return listaClientes
    End Function

    ' Método para recuperar un cliente eliminado
    Public Function RecuperarCliente(clienteCodigo As String) As Boolean
        Dim procedimientoSQL As String = "spRecuperarClientes"

        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento(procedimientoSQL)
            cmd.Parameters.AddWithValue("@clienteCodigo", clienteCodigo)
            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
            Return filasAfectadas > 0
        Catch ex As Exception
            Throw New Exception("Error al recuperar cliente: " & ex.Message)
        End Try
    End Function

    ' Método para buscar clientes por nombre
    Public Function BuscarClientesPorNombre(nombre As String) As List(Of Cliente)
        Dim listaClientes As New List(Of Cliente)
        Dim procedimientoSQL As String = "spBuscarClientesPorNombre"

        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento(procedimientoSQL)
            cmd.Parameters.AddWithValue("@nombre", nombre)
            Using dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    Dim cliente As New Cliente() With {
                        .ClientesCodigo = dr("ClientesCodigo").ToString(),
                        .ClientesNombreCompleto = dr("ClientesNombreCompleto").ToString(),
                        .ClientesTelefono = dr("ClientesTelefono").ToString(),
                        .ClientesDNI = dr("ClientesDNI").ToString(),
                        .ClientesCorreo = dr("ClientesCorreo").ToString(),
                        .ClientesFechaRegistro = Convert.ToDateTime(dr("ClientesFechaRegistro")),
                        .ClientesEstado = dr("ClientesEstado").ToString()
                    }
                    listaClientes.Add(cliente)
                End While
            End Using
        Catch ex As Exception
            Throw New Exception("Error al buscar clientes por nombre: " & ex.Message)
        End Try

        Return listaClientes
    End Function

    Public Function BuscarClientesPorNombreComoDataTable(nombre As String) As DataTable
        Dim dataTable As New DataTable()
        Dim procedimientoSQL As String = "spBuscarClientesPorNombre"

        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento(procedimientoSQL)
            cmd.Parameters.AddWithValue("@nombre", nombre)

            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dataTable)
        Catch ex As Exception
            Throw New Exception("Error al buscar clientes: " & ex.Message)
        End Try

        Return dataTable
    End Function

    ' Método para insertar un nuevo cliente
    Public Function InsertarCliente(cliente As Cliente) As Boolean
        Dim procedimientoSQL As String = "spInsertarCliente"

        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento(procedimientoSQL)
            cmd.Parameters.AddWithValue("@ClientesCodigo", cliente.ClientesCodigo)
            cmd.Parameters.AddWithValue("@ClientesNombre", cliente.ClientesNombre)
            cmd.Parameters.AddWithValue("@ClientesApellidos", cliente.ClientesApellidos)
            cmd.Parameters.AddWithValue("@ClientesTelefono", cliente.ClientesTelefono)
            cmd.Parameters.AddWithValue("@ClientesDNI", cliente.ClientesDNI)
            cmd.Parameters.AddWithValue("@ClientesCorreo", cliente.ClientesCorreo)

            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
            Return filasAfectadas > 0
        Catch ex As SqlException
            Throw New Exception("Error al insertar cliente: " & ex.Message)
        End Try
    End Function

End Class
