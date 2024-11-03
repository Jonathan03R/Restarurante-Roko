Imports System.Data.SqlClient

Public Class ReservaSQL

    ' Método para insertar una reserva en la base de datos
    Public Function InsertarReserva(reserva As MesaReserva) As Boolean
        Dim procedimientoSQL As String = "spInsertarReserva"
        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento(procedimientoSQL)

            ' Agregar los parámetros al comando
            cmd.Parameters.AddWithValue("@ReservasCodigo", reserva.ReservasCodigo)
            cmd.Parameters.AddWithValue("@ReservasClientesCodigo", reserva.ReservasClientesCodigo)
            cmd.Parameters.AddWithValue("@ReservasMesasCodigo", reserva.ReservasMesasCodigo)
            cmd.Parameters.AddWithValue("@ReservasFechaHoraReserva", reserva.ReservasFechaHoraReserva)

            ' Ejecutar el comando
            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
            Return filasAfectadas > 0
        Catch ex As SqlException
            Throw New Exception("Error al insertar reserva: " & ex.Message)
        End Try
    End Function

    ' Método para obtener todas las reservas, con opción de filtrar por estado
    Public Function ObtenerReservas(Optional estados As String = Nothing) As List(Of MesaReserva)
        Dim listaReservas As New List(Of MesaReserva)
        Dim procedimientoSQL As String = "spListarReservas"

        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento(procedimientoSQL)

            ' Si se pasan estados, agregarlos como parámetro
            If Not String.IsNullOrEmpty(estados) Then
                cmd.Parameters.AddWithValue("@Estados", estados)
            Else
                cmd.Parameters.AddWithValue("@Estados", DBNull.Value)
            End If

            ' Ejecutar el comando y leer los resultados
            Using dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    Dim reserva As New MesaReserva() With {
                        .ReservasCodigo = dr("ReservasCodigo").ToString(),
                        .ReservasClientesCodigo = dr("ReservasClientesCodigo").ToString(),
                        .ReservasMesasCodigo = dr("ReservasMesasCodigo").ToString(),
                        .ReservasEstado = dr("EstadoReserva").ToString(),
                        .ReservasFechaHoraReserva = Convert.ToDateTime(dr("ReservasFechaHoraReserva"))
                    }
                    reserva.Cliente = New Cliente With {
                        .ClientesNombreCompleto = dr("NombreCliente").ToString()
                    }
                    reserva.Mesa = New Mesa With {
                        .MesasCapacidad = Convert.ToInt32(dr("CapacidadMesa"))
                    }

                    listaReservas.Add(reserva)
                End While
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener reservas: " & ex.Message)
        End Try

        Return listaReservas
    End Function


    Public Function ObtenerReservasComoDataTable(Optional estados As String = Nothing) As DataTable
        Dim dataTable As New DataTable()
        Dim procedimientoSQL As String = "spListarReservas"

        Try
            ' Obtener el comando del procedimiento almacenado
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento(procedimientoSQL)

            ' Si se especifican estados, agregar el parámetro
            If Not String.IsNullOrEmpty(estados) Then
                cmd.Parameters.AddWithValue("@Estados", estados)
            End If

            ' Crear un SqlDataAdapter para llenar el DataTable
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dataTable)
        Catch ex As Exception
            Throw New Exception("Error al obtener reservas: " & ex.Message)
        End Try

        Return dataTable
    End Function

    ' Método para actualizar una reserva en la base de datos
    Public Function ActualizarReserva(reserva As MesaReserva) As Boolean
        Dim procedimientoSQL As String = "spActualizarReserva"
        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento(procedimientoSQL)

            ' Parámetro para el código de la reserva
            cmd.Parameters.AddWithValue("@ReservasCodigo", reserva.ReservasCodigo)

            ' Parámetro para el código de la mesa
            If Not String.IsNullOrEmpty(reserva.ReservasMesasCodigo) Then
                cmd.Parameters.AddWithValue("@ReservasMesasCodigo", reserva.ReservasMesasCodigo)
            Else
                cmd.Parameters.AddWithValue("@ReservasMesasCodigo", DBNull.Value)
            End If

            ' Parámetros para la fecha y hora de la reserva
            If reserva.ReservasFechaHoraReserva <> Date.MinValue Then
                cmd.Parameters.AddWithValue("@NuevaFecha", reserva.ReservasFechaHoraReserva.Date)
                cmd.Parameters.AddWithValue("@NuevaHora", reserva.ReservasFechaHoraReserva.TimeOfDay)
            Else
                cmd.Parameters.AddWithValue("@NuevaFecha", DBNull.Value)
                cmd.Parameters.AddWithValue("@NuevaHora", DBNull.Value)
            End If

            ' Parámetro para el estado de la reserva
            If Not String.IsNullOrEmpty(reserva.ReservasEstado) Then
                cmd.Parameters.AddWithValue("@NuevoEstado", reserva.ReservasEstado)
            Else
                cmd.Parameters.AddWithValue("@NuevoEstado", DBNull.Value)
            End If

            ' Ejecutar el comando
            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
            Return filasAfectadas > 0
        Catch ex As SqlException
            Throw New Exception("Error al actualizar reserva: " & ex.Message)
        End Try
    End Function
End Class
