Imports System.Data.SqlClient

Public Class ReservaSQL

    Public Function InsertarReserva(reserva As MesaReserva) As Boolean
        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spInsertarReserva", cn)
            cmd.CommandType = CommandType.StoredProcedure

            ' Agregar los parámetros al comando
            cmd.Parameters.AddWithValue("@ReservasCodigo", reserva.ReservasCodigo)
            cmd.Parameters.AddWithValue("@ReservasClientesCodigo", reserva.ReservasClientesCodigo)
            cmd.Parameters.AddWithValue("@ReservasMesasCodigo", reserva.ReservasMesasCodigo)
            cmd.Parameters.AddWithValue("@ReservasFechaHoraReserva", reserva.ReservasFechaHoraReserva)

            cn.Open()
            Try
                Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                Return filasAfectadas > 0
            Catch ex As SqlException
                Throw New Exception("Error al insertar reserva: " & ex.Message)
            Finally
                cn.Close()
            End Try
        End Using
    End Function


    Public Function ObtenerReservas(Optional estados As String = Nothing) As List(Of MesaReserva)
        Dim listaReservas As New List(Of MesaReserva)

        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spListarReservas", cn)
            cmd.CommandType = CommandType.StoredProcedure

            ' Si se pasan estados, agregarlos como parámetro
            If Not String.IsNullOrEmpty(estados) Then
                cmd.Parameters.AddWithValue("@Estados", estados)
            Else
                cmd.Parameters.AddWithValue("@Estados", DBNull.Value)
            End If

            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader()

            While dr.Read()
                Dim reserva As New MesaReserva()
                reserva.ReservasCodigo = dr("ReservasCodigo").ToString()
                reserva.ReservasClientesCodigo = dr("ReservasClientesCodigo").ToString()
                reserva.ReservasMesasCodigo = dr("ReservasMesasCodigo").ToString()
                reserva.Cliente = New Cliente With {
                    .ClientesNombreCompleto = dr("NombreCliente").ToString()
            }
                reserva.Mesa = New Mesa With {
                .MesasCapacidad = Convert.ToInt32(dr("CapacidadMesa"))
            }
                reserva.ReservasEstado = dr("EstadoReserva").ToString()
                reserva.ReservasFechaHoraReserva = Convert.ToDateTime(dr("ReservasFechaHoraReserva"))

                listaReservas.Add(reserva)
            End While

            dr.Close()
        End Using

        Return listaReservas
    End Function

    Public Function ActualizarReserva(reserva As MesaReserva) As Boolean
        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spActualizarReserva", cn)
            cmd.CommandType = CommandType.StoredProcedure

            ' Parámetro para el código de la reserva
            cmd.Parameters.AddWithValue("@ReservasCodigo", reserva.ReservasCodigo)

            ' Parámetro para el código de la mesa
            If Not String.IsNullOrEmpty(reserva.ReservasMesasCodigo) Then
                cmd.Parameters.AddWithValue("@ReservasMesasCodigo", reserva.ReservasMesasCodigo)
            Else
                cmd.Parameters.AddWithValue("@ReservasMesasCodigo", DBNull.Value)
            End If

            ' Parámetros separados para la fecha y la hora de la reserva
            ' Si se pasa una fecha, la añadimos como parámetro
            If reserva.ReservasFechaHoraReserva <> Date.MinValue Then
                cmd.Parameters.AddWithValue("@NuevaFecha", reserva.ReservasFechaHoraReserva.Date)
            Else
                cmd.Parameters.AddWithValue("@NuevaFecha", DBNull.Value)
            End If

            ' Si se pasa una hora, la añadimos como parámetro
            If reserva.ReservasFechaHoraReserva <> Date.MinValue Then
                cmd.Parameters.AddWithValue("@NuevaHora", reserva.ReservasFechaHoraReserva.TimeOfDay)
            Else
                cmd.Parameters.AddWithValue("@NuevaHora", DBNull.Value)
            End If

            ' Parámetro para el estado de la reserva
            If Not String.IsNullOrEmpty(reserva.ReservasEstado) Then
                cmd.Parameters.AddWithValue("@NuevoEstado", reserva.ReservasEstado)
            Else
                cmd.Parameters.AddWithValue("@NuevoEstado", DBNull.Value)
            End If

            cn.Open()
            Try
                Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                Return filasAfectadas > 0
            Catch ex As SqlException
                Throw New Exception("Error al actualizar reserva: " & ex.Message)
            Finally
                cn.Close()
            End Try
        End Using
    End Function
End Class
