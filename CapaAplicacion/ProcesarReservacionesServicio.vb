Public Class ProcesarReservacionesServicio
    Private mesaSQL As New MesaSQL()
    Private clienteSQL As New ClienteSQL()
    Private reservaSQL As New ReservaSQL()
    Private codigosSQL As New CodigosSQL()

    ' Método para registrar una reserva
    Public Function RegistrarReserva(clienteCodigo As String, mesaCodigo As String, fechaReserva As DateTime) As Boolean

        Try
            ModuloSistema.IniciarTransaccion()
            If String.IsNullOrEmpty(clienteCodigo) Then Throw New Exception("El código de cliente es obligatorio.")
            If String.IsNullOrEmpty(mesaCodigo) Then Throw New Exception("El código de mesa es obligatorio.")
            If fechaReserva <= DateTime.Now Then Throw New Exception("La fecha de reserva debe ser en el futuro.")
            If Not mesaSQL.EstaDisponibleParaReservar(mesaCodigo, fechaReserva) Then
                Throw New Exception("La mesa seleccionada no está disponible para la fecha indicada.")
            End If

            Dim reservaCodigo As String = codigosSQL.GenerarCodigoUnico("RES", "Restaurante.MesaReservas", "ReservasCodigo")
            Dim reserva As New MesaReserva() With {
                .ReservasCodigo = reservaCodigo,
                .ReservasClientesCodigo = clienteCodigo,
                .ReservasMesasCodigo = mesaCodigo,
                .ReservasFechaHoraReserva = fechaReserva
            }
            Dim result As Boolean = reservaSQL.InsertarReserva(reserva)
            ModuloSistema.TerminarTransaccion()

            Return result
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw ex
        End Try

    End Function

    ' Método para actualizar una reserva
    Public Function ActualizarReserva(reservaCodigo As String, mesaCodigo As String, fechaReserva As DateTime, estadoReserva As String) As Boolean
        Try
            ModuloSistema.IniciarTransaccion()
            ' Crear instancia de la reserva para actualizar
            Dim reserva As New MesaReserva() With {
                .ReservasCodigo = reservaCodigo,
                .ReservasMesasCodigo = mesaCodigo,
                .ReservasFechaHoraReserva = fechaReserva,
                .ReservasEstado = estadoReserva
            }

            ' Actualizar la reserva en la base de datos
            Dim resultado As Boolean = reservaSQL.ActualizarReserva(reserva)

            ModuloSistema.TerminarTransaccion()
            Return resultado
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw New Exception("Error al actualizar la reserva: " & ex.Message)
        End Try
    End Function

    ' Método para obtener una lista de reservas como DataTable
    Public Function ObtenerReservas(Optional estados As String = Nothing) As DataTable

        ModuloSistema.AbrirConexion()
        Dim result As DataTable = reservaSQL.ObtenerReservasComoDataTable(estados)
        ModuloSistema.CerrarConexion()
        Return result

    End Function

    ' Método para obtener una lista de mesas disponibles como DataTable
    Public Function ObtenerMesas(Optional estadoMesas As String = Nothing) As DataTable
        Try
            ' Obtener mesas desde la capa de persistencia
            ModuloSistema.IniciarTransaccion()
            Dim result As DataTable = mesaSQL.ObtenerMesasComoDataTable(estadoMesas)
            ModuloSistema.TerminarTransaccion()
            Return result
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw New Exception("Error al obtener las mesas: " & ex.Message)
        End Try
    End Function

    ' Método para buscar clientes por nombre y obtenerlos como DataTable
    Public Function BuscarClientesPorNombre(nombre As String) As DataTable
        Try
            ModuloSistema.IniciarTransaccion()
            Dim result As DataTable = clienteSQL.BuscarClientesPorNombreComoDataTable(nombre)
            ModuloSistema.TerminarTransaccion()
            Return result
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw New Exception("Error al buscar clientes: " & ex.Message)
        End Try
    End Function

    ' Método para generar un código único de reserva
    Public Function GenerarCodigoUnicoReserva() As String
        Try
            ModuloSistema.IniciarTransaccion()
            Dim codigo As String = codigosSQL.GenerarCodigoUnico("RES", "Restaurante.MesaReservas", "ReservasCodigo")
            ModuloSistema.TerminarTransaccion()
            Return codigo
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw New Exception("Error al generar el código de reserva: " & ex.Message)
        End Try
    End Function
End Class
