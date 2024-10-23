Imports System.Data.SqlClient

Public Class MesaSQL
    Public Function ObtenerMesas(Optional estado As String = Nothing) As List(Of Mesa)
        Dim listaMesas As New List(Of Mesa)

        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spListarMesas", cn)
            cmd.CommandType = CommandType.StoredProcedure

            If Not String.IsNullOrEmpty(estado) Then
                cmd.Parameters.AddWithValue("@MesasEstado", estado)
            End If

            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader()

            While dr.Read()
                Dim estadoMesa As String = dr("MesasEstado").ToString()
                Dim estadoDescriptivo As String = ""

                Select Case estadoMesa
                    Case "V"
                        estadoDescriptivo = "Vacío"
                    Case "R"
                        estadoDescriptivo = "Reservado"
                    Case "O"
                        estadoDescriptivo = "Ocupado"
                    Case Else
                        estadoDescriptivo = estadoMesa
                End Select

                Dim mesa As New Mesa() With {
                    .MesasCodigo = dr("MesasCodigo").ToString(),
                    .MesasCapacidad = Convert.ToInt32(dr("MesasCapacidad")),
                    .MesasEstado = estadoDescriptivo
                }

                listaMesas.Add(mesa)
            End While
            dr.Close()
        End Using

        Return listaMesas
    End Function

    Public Sub OcuparMesa(mesaCodigo As String)
        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spOcuparMesa", cn)
            cmd.CommandType = CommandType.StoredProcedure

            ' Pasar el código de la mesa al procedimiento almacenado
            cmd.Parameters.AddWithValue("@MesasCodigo", mesaCodigo)

            ' Abrir conexión y ejecutar el procedimiento para ocupar la mesa
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        End Using
    End Sub

    Public Sub DesocuparMeSA(mesaCodigo As String)
        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spLiberarMesa", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@MesasCodigo", mesaCodigo)

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        End Using
    End Sub
End Class
