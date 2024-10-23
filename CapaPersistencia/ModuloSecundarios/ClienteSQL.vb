Imports System.Data.SqlClient

Public Class ClienteSQL

    Public Function ObtenerClientesActivos() As List(Of Cliente)
        Dim listaClientes As New List(Of Cliente)

        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spListarClientesActivos", cn)
            cmd.CommandType = CommandType.StoredProcedure

            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader()

            While dr.Read()
                Dim cliente As New Cliente()
                cliente.ClientesCodigo = dr("ClientesCodigo").ToString()
                cliente.ClientesNombre = dr("ClientesNombre").ToString()
                cliente.ClientesApellidos = dr("ClientesApellidos").ToString()
                cliente.ClientesTelefono = dr("ClientesTelefono").ToString()
                cliente.ClientesDNI = dr("ClientesDNI").ToString()
                cliente.ClientesCorreo = dr("ClientesCorreo").ToString()
                cliente.ClientesFechaRegistro = Convert.ToDateTime(dr("ClientesFechaRegistro"))
                cliente.ClientesEstado = dr("ClientesEstado").ToString()

                ' Obtener reservas para el cliente actual
                cliente.Reservas = ObtenerReservasPorCliente(cliente.ClientesCodigo)

                listaClientes.Add(cliente)
            End While
            dr.Close()
        End Using

        Return listaClientes
    End Function

    Public Function ObtenerReservasPorCliente(clienteCodigo As String) As List(Of MesaReserva)
        Dim reservas As New List(Of MesaReserva)

        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spListarReservasPorCliente", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ClientesCodigo", clienteCodigo)

            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader()

            ' Leer cada reserva y agregarla a la lista
            While dr.Read()
                Dim reserva As New MesaReserva()
                reserva.ReservasCodigo = dr("ReservasCodigo").ToString()
                reserva.ReservasMesasCodigo = dr("ReservasMesasCodigo").ToString()
                reserva.ReservasEstado = dr("ReservasEstado").ToString()
                reserva.ReservasFechaHoraReserva = Convert.ToDateTime(dr("ReservasFechaHoraReserva"))

                reservas.Add(reserva)
            End While
            dr.Close()
        End Using

        Return reservas
    End Function
    Public Function ActualizarCliente(cliente As Cliente, consultaActualizacion As String) As Boolean
        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand(consultaActualizacion, cn)

            ' Solo agregar los parámetros si se incluyen en la consulta
            If consultaActualizacion.Contains("@ClientesNombre") Then
                cmd.Parameters.AddWithValue("@ClientesNombre", cliente.ClientesNombre)
            End If
            If consultaActualizacion.Contains("@ClientesApellidos") Then
                cmd.Parameters.AddWithValue("@ClientesApellidos", cliente.ClientesApellidos)
            End If
            If consultaActualizacion.Contains("@ClientesTelefono") Then
                cmd.Parameters.AddWithValue("@ClientesTelefono", cliente.ClientesTelefono)
            End If
            If consultaActualizacion.Contains("@ClientesCorreo") Then
                cmd.Parameters.AddWithValue("@ClientesCorreo", cliente.ClientesCorreo)
            End If

            ' Agregar siempre el código del cliente
            cmd.Parameters.AddWithValue("@ClientesCodigo", cliente.ClientesCodigo)

            cn.Open()
            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
            cn.Close()

            ' Verificar si se actualizó alguna fila
            Return filasAfectadas > 0
        End Using
    End Function

    Public Function EliminarCliente(clienteCodigo As String) As Boolean
        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spEliminarCliente", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@clienteCodigo", clienteCodigo)

            cn.Open()
            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
            cn.Close()

            ' Retorna true si se afectó alguna fila
            Return filasAfectadas > 0
        End Using
    End Function


    Public Function ObtenerClientesBorrados() As List(Of Cliente)
        Dim listaClientes As New List(Of Cliente)

        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spListarClientesBorrados", cn)
            cmd.CommandType = CommandType.StoredProcedure

            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader()

            While dr.Read()
                Dim cliente As New Cliente()
                cliente.ClientesCodigo = dr("ClientesCodigo").ToString()
                cliente.ClientesNombreCompleto = dr("ClientesNombreCompleto").ToString()
                cliente.ClientesFechaRegistro = Convert.ToDateTime(dr("ClientesFechaRegistro"))

                listaClientes.Add(cliente)
            End While
            dr.Close()
        End Using

        Return listaClientes
    End Function


    Public Function RecuperarCliente(clienteCodigo As String) As Boolean
        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spRecuperarClientes", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@clienteCodigo", clienteCodigo)

            cn.Open()
            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
            cn.Close()

            Return filasAfectadas > 0 ' Devolver true si se afectó alguna fila
        End Using
    End Function


    Public Function BuscarClientesPorNombre(nombre As String) As List(Of Cliente)
        Dim listaClientes As New List(Of Cliente)

        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spBuscarClientesPorNombre", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@nombre", nombre)

            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader()

            While dr.Read()
                Dim cliente As New Cliente()
                cliente.ClientesCodigo = dr("ClientesCodigo").ToString()
                cliente.ClientesNombreCompleto = dr("ClientesNombreCompleto").ToString()
                cliente.ClientesTelefono = dr("ClientesTelefono").ToString()
                cliente.ClientesDNI = dr("ClientesDNI").ToString()
                cliente.ClientesCorreo = dr("ClientesCorreo").ToString()
                cliente.ClientesFechaRegistro = Convert.ToDateTime(dr("ClientesFechaRegistro"))
                cliente.ClientesEstado = dr("ClientesEstado").ToString()

                listaClientes.Add(cliente)
            End While
            dr.Close()
        End Using

        Return listaClientes
    End Function

    Public Function InsertarCliente(cliente As Cliente) As Boolean
        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spInsertarCliente", cn)
            cmd.CommandType = CommandType.StoredProcedure

            ' Agregamos los parámetros
            cmd.Parameters.AddWithValue("@ClientesCodigo", cliente.ClientesCodigo)
            cmd.Parameters.AddWithValue("@ClientesNombre", cliente.ClientesNombre)
            cmd.Parameters.AddWithValue("@ClientesApellidos", cliente.ClientesApellidos)
            cmd.Parameters.AddWithValue("@ClientesTelefono", cliente.ClientesTelefono)
            cmd.Parameters.AddWithValue("@ClientesDNI", cliente.ClientesDNI)
            cmd.Parameters.AddWithValue("@ClientesCorreo", cliente.ClientesCorreo)

            cn.Open()

            Try
                ' Ejecutamos el comando
                Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                Return filasAfectadas > 0
            Catch ex As SqlException
                Throw New Exception("Error al insertar cliente: " & ex.Message)
            Finally
                cn.Close()
            End Try
        End Using
    End Function

End Class
