Imports System.Data.SqlClient

Public Class MesaSQL
    ' Método para obtener todas las mesas, con opción de filtrar por estado
    Public Function ObtenerMesas(Optional estado As String = Nothing) As List(Of Mesa)
        Dim listaMesas As New List(Of Mesa)
        Dim procedimientoSQL As String = "spListarMesas"

        Try
            ' Obtener el comando usando ModuloSistema
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento(procedimientoSQL)

            ' Si se especifica un estado, agregar el parámetro correspondiente
            If Not String.IsNullOrEmpty(estado) Then
                cmd.Parameters.AddWithValue("@MesasEstado", estado)
            End If

            ' Ejecutar el comando y leer los resultados
            Using dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    Dim mesa As New Mesa() With {
                        .MesasCodigo = dr("MesasCodigo").ToString(),
                        .MesasCapacidad = Convert.ToInt32(dr("MesasCapacidad")),
                        .MesasEstado = dr("MesasEstado").ToString()
                    }
                    listaMesas.Add(mesa)
                End While
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener mesas: " & ex.Message)
        End Try

        Return listaMesas
    End Function


    Public Function ObtenerMesasComoDataTable(Optional estado As String = Nothing) As DataTable
        Dim dataTable As New DataTable()
        Dim procedimientoSQL As String = "spListarMesas"

        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento(procedimientoSQL)
            If Not String.IsNullOrEmpty(estado) Then
                cmd.Parameters.AddWithValue("@MesasEstado", estado)
            End If
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dataTable)
        Catch ex As Exception
            Throw New Exception("Error al obtener mesas: " & ex.Message)
        End Try

        Return dataTable
    End Function



    ' Método para marcar una mesa como ocupada
    Public Sub OcuparMesa(mesaCodigo As String)
        Dim procedimientoSQL As String = "spOcuparMesa"

        Try
            ' Obtener el comando de procedimiento almacenado
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento(procedimientoSQL)
            cmd.Parameters.AddWithValue("@MesasCodigo", mesaCodigo)

            ' Ejecutar el comando para ocupar la mesa
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Throw New Exception("Error al ocupar la mesa: " & ex.Message)
        End Try
    End Sub

    ' Método para liberar una mesa
    Public Sub DesocuparMesa(mesaCodigo As String)
        Dim procedimientoSQL As String = "spLiberarMesa"

        Try
            ' Obtener el comando de procedimiento almacenado
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento(procedimientoSQL)
            cmd.Parameters.AddWithValue("@MesasCodigo", mesaCodigo)

            ' Ejecutar el comando para liberar la mesa
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Throw New Exception("Error al liberar la mesa: " & ex.Message)
        End Try
    End Sub

    ' Método para verificar la disponibilidad de una mesa para una fecha específica
    Public Function EstaDisponibleParaReservar(mesaCodigo As String, fechaReserva As DateTime) As Boolean
        Dim procedimientoSQL As String = "spVerificarDisponibilidadMesa"

        Try
            ' Obtener el comando del procedimiento almacenado
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento(procedimientoSQL)
            cmd.Parameters.AddWithValue("@MesasCodigo", mesaCodigo)
            cmd.Parameters.AddWithValue("@FechaReserva", fechaReserva)

            ' Ejecutar el comando y verificar si la mesa está disponible
            Dim resultado As Object = cmd.ExecuteScalar()
            Return Convert.ToInt32(resultado) = 1
        Catch ex As SqlException
            Throw New Exception("Error al verificar la disponibilidad de la mesa: " & ex.Message)
        End Try
    End Function

    Public Sub ActualizarMesasEstadoReservada()
        Dim procedimientoSQL As String = "spActualizarEstadoMesasReservadas"
        Try
            ' Obtener el comando usando ModuloSistema
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento(procedimientoSQL)

            ' Ejecutar el procedimiento para actualizar el estado de las mesas
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Error al actualizar el estado de las mesas reservadas: " & ex.Message)
        End Try
    End Sub
End Class
