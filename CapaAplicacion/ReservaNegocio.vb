Public Class ReservaNegocio
    Private reservaSQL As New ReservaSQL
    Private codigoSQL As New CodigosSQL
    Public Function GenerarCodigoUnicoReserva() As String
        Return codigoSQL.GenerarCodigoUnico("RES", "Restaurante.MesaReservas", "ReservasCodigo")
    End Function

    Public Function InsertarReserva(reserva As MesaReserva) As Boolean
        If String.IsNullOrWhiteSpace(reserva.ReservasClientesCodigo) Then
            Throw New ArgumentException("Debe seleccionar un cliente para la reserva.")
        End If
        If String.IsNullOrWhiteSpace(reserva.ReservasMesasCodigo) Then
            Throw New ArgumentException("Debe seleccionar una mesa para la reserva.")
        End If

        Return reservaSQL.InsertarReserva(reserva)
    End Function

    Public Function ObtenerReservas(Optional estado As String = Nothing) As List(Of MesaReserva)
        Return reservaSQL.ObtenerReservas(estado)
    End Function


    Public Function ActualizarReserva(reserva As MesaReserva) As Boolean
        ' Validación del código de la reserva
        If String.IsNullOrEmpty(reserva.ReservasCodigo) Then
            Throw New ArgumentException("El código de la reserva es obligatorio.")
        End If

        ' Validación para verificar que al menos un campo se está actualizando
        If String.IsNullOrEmpty(reserva.ReservasMesasCodigo) AndAlso
       reserva.ReservasFechaHoraReserva = Date.MinValue AndAlso
       String.IsNullOrEmpty(reserva.ReservasEstado) Then
            Throw New ArgumentException("Debe actualizar al menos un campo: mesa, fecha, hora o estado.")
        End If

        ' Llamar a la capa de persistencia para realizar la actualización
        Return reservaSQL.ActualizarReserva(reserva)
    End Function


End Class
