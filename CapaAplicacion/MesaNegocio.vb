Public Class MesaNegocio
    Private mesaSQL As New MesaSQL()

    Public Function ObtenerMesas() As List(Of Mesa)
        Return mesaSQL.ObtenerMesas()
    End Function

    Public Sub OcuparMesa(mesaCodigo As String)
        ' Llamar a la capa de persistencia para ocupar la mesa
        mesaSQL.OcuparMesa(mesaCodigo)
    End Sub

    Public Sub DesocuparMesa(mesaCodigo As String)
        mesaSQL.DesocuparMeSA(mesaCodigo)
    End Sub
End Class
