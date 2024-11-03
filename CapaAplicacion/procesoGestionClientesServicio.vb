Imports System.Text.RegularExpressions

Public Class procesoGestionClientesServicio
    Private clienteSQL As New ClienteSQL()
    Private codigoSQL As New CodigosSQL()

    Public Function ObtenerClientesActivosComoDataTable() As DataTable
        Try
            ModuloSistema.IniciarTransaccion()
            ' Obtener la lista de clientes desde la capa de persistencia
            Dim listaClientes As List(Of Cliente) = clienteSQL.ObtenerClientesActivos()

            ' Crear un DataTable para los datos
            Dim dataTable As New DataTable()
            dataTable.Columns.Add("ClientesCodigo", GetType(String))
            dataTable.Columns.Add("Reservas", GetType(Integer))
            dataTable.Columns.Add("ClientesNombre", GetType(String))
            dataTable.Columns.Add("ClientesApellidos", GetType(String))

            dataTable.Columns.Add("ClientesTelefono", GetType(String))
            dataTable.Columns.Add("ClientesDNI", GetType(String))
            dataTable.Columns.Add("ClientesCorreo", GetType(String))
            dataTable.Columns.Add("ClientesFechaRegistro", GetType(DateTime))
            dataTable.Columns.Add("ClientesEstado", GetType(String))

            ' Rellenar el DataTable usando solo clientes activos
            For Each cliente As Cliente In listaClientes
                If cliente.EsActivo() Then
                    Dim numeroReservas As Integer = clienteSQL.ObtenerReservasPorCliente(cliente.ClientesCodigo).Count
                    dataTable.Rows.Add(
                        cliente.ClientesCodigo,
                        numeroReservas,
                        cliente.ClientesNombre,
                        cliente.ClientesApellidos,
                        cliente.ClientesTelefono,
                        cliente.ClientesDNI,
                        cliente.ClientesCorreo,
                        cliente.ClientesFechaRegistro,
                        cliente.ClientesEstado
                        )
                End If
            Next
            ModuloSistema.TerminarTransaccion()
            Return dataTable
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw New Exception("Error al obtener los clientes activos como DataTable: " & ex.Message)
        End Try
    End Function

    Public Function MostrarClientesBorrados() As DataTable
        Try
            ModuloSistema.IniciarTransaccion()
            Dim listasClientesBorrados As List(Of Cliente) = clienteSQL.ObtenerClientesBorrados()
            Dim dataTable As New DataTable()
            dataTable.Columns.Add("ClientesCodigo", GetType(String))
            dataTable.Columns.Add("ClientesNombreCompleto", GetType(String))

            For Each cliente As Cliente In listasClientesBorrados
                If Not cliente.EsActivo() Then
                    dataTable.Rows.Add(
                        cliente.ClientesCodigo,
                        cliente.ClientesNombreCompleto
                        )
                End If
            Next
            ModuloSistema.TerminarTransaccion()
            Return dataTable
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw New Exception("Error al obtener los clientes que se han elimimnado : " & ex.Message)

        End Try
    End Function

    Public Function obtenerReservasPorClientes(clienteCodigo As String) As DataTable
        Try
            ModuloSistema.IniciarTransaccion()
            If String.IsNullOrEmpty(clienteCodigo) Then
                Throw New Exception("El código del cliente es obligatorio para obtener sus reservas.")
            End If

            Dim listaReservas As List(Of MesaReserva) = clienteSQL.ObtenerReservasPorCliente(clienteCodigo)
            Dim dataTable As New DataTable()

            dataTable.Columns.Add("ReservasCodigo", GetType(String))
            dataTable.Columns.Add("ReservasMesasCodigo", GetType(String))
            dataTable.Columns.Add("ReservasEstado", GetType(String))
            dataTable.Columns.Add("ReservasFechaHoraReserva", GetType(DateTime))
            For Each reserva As MesaReserva In listaReservas
                dataTable.Rows.Add(
                    reserva.ReservasCodigo,
                    reserva.ReservasMesasCodigo,
                    reserva.ReservasEstado,
                    reserva.ReservasFechaHoraReserva
                )
            Next
            ModuloSistema.TerminarTransaccion()
            Return dataTable
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw New Exception("Error al obtener las reservas del cliente: " & ex.Message)
        End Try
    End Function

    Public Function ActualizarCliente(clienteCodigo As String, nombre As String, apellidos As String, telefono As String, correo As String) As Boolean
        Try
            ' Iniciar la transacción
            ModuloSistema.IniciarTransaccion()

            Dim cliente As New Cliente With {
                .ClientesCodigo = clienteCodigo,
                .ClientesNombre = nombre,
                .ClientesApellidos = apellidos,
                .ClientesTelefono = telefono,
                .ClientesCorreo = correo
            }

            Dim resultado As Boolean = clienteSQL.ActualizarCliente(cliente)

            ModuloSistema.TerminarTransaccion()

            Return resultado
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw New Exception("Error al actualizar el cliente en la capa de aplicación: " & ex.Message)
        End Try
    End Function


    Public Function CambiarEstadoClienteAInactivo(clienteCodigo As String) As Boolean
        Try
            If String.IsNullOrEmpty(clienteCodigo) Then
                Throw New Exception("El código del cliente es obligatorio para cambiar su estado.")
            End If
            ' Iniciar la transacción
            ModuloSistema.IniciarTransaccion()
            Dim resultado As Boolean = clienteSQL.EliminarCliente(clienteCodigo)
            ModuloSistema.TerminarTransaccion()
            Return resultado
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw ex
        End Try
    End Function


    Public Function AgregarNuevoCliente(ClienteNombre As String, ClienteApellido As String, ClienteTelefono As String, ClienteDni As String, ClienteCorreo As String) As Boolean
        Try

            If String.IsNullOrEmpty(ClienteNombre) Then
                Throw New Exception("El nombre del cliente es obligatorio.")
            End If

            If String.IsNullOrEmpty(ClienteApellido) Then
                Throw New Exception("El apellido del cliente es obligatorio.")
            End If

            If Not String.IsNullOrEmpty(ClienteTelefono) AndAlso (ClienteTelefono.Length > 12 OrElse Not IsNumeric(ClienteTelefono)) Then
                Throw New Exception("El teléfono debe tener hasta 12 caracteres numéricos.")
            End If

            If String.IsNullOrEmpty(ClienteDni) OrElse ClienteDni.Length <> 8 OrElse Not IsNumeric(ClienteDni) Then
                Throw New Exception("El DNI debe tener exactamente 8 caracteres numéricos.")
            End If

            If String.IsNullOrEmpty(ClienteCorreo) OrElse Not Regex.IsMatch(ClienteCorreo, "^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$") Then
                Throw New Exception("El correo electrónico es inválido.")
            End If

            Dim clienteCodigo = GenerarCodigoUnicoCliente()
            ModuloSistema.IniciarTransaccion()
            Dim cliente As New Cliente With {
                .ClientesCodigo = clienteCodigo,
                .ClientesNombre = ClienteNombre,
                .ClientesApellidos = ClienteApellido,
                .ClientesTelefono = ClienteTelefono,
                .ClientesDNI = ClienteDni,
                .ClientesCorreo = ClienteCorreo
            }
            Dim resultado As Boolean = clienteSQL.InsertarCliente(cliente)
            ModuloSistema.TerminarTransaccion()

            Return resultado
        Catch ex As Exception
            Throw New Exception("Error al intentar agregar el nuevo Cliente: " & ex.Message)
            ModuloSistema.CancelarTransaccion()
        End Try

    End Function

    Public Function recuperarCliente(CodigoCliente As String)
        Try
            ModuloSistema.IniciarTransaccion()
            Dim respuesta As Boolean = clienteSQL.RecuperarCliente(CodigoCliente)
            ModuloSistema.TerminarTransaccion()

            Return respuesta
        Catch ex As Exception
            Throw New Exception("Error al obtener los clientes que se han elimimnado : " & ex.Message)
            ModuloSistema.CancelarTransaccion()
        End Try
    End Function

    Public Function GenerarCodigoUnicoCliente() As String

        Try
            ModuloSistema.IniciarTransaccion()
            Dim result = codigoSQL.GenerarCodigoUnico("CLI", "Restaurante.Clientes", "ClientesCodigo")
            ModuloSistema.TerminarTransaccion()
            Return result
        Catch ex As Exception
            Throw ex
            ModuloSistema.CancelarTransaccion()
        End Try
    End Function

End Class
