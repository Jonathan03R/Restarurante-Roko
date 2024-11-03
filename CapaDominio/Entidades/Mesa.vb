Public Class Mesa
    Public Property MesasCodigo As String
    Public Property MesasCapacidad As Integer
    Public Property MesasEstado As String


    Public Function EstaDisponibleParaReservar() As Boolean
        Return MesasEstado = "V"
    End Function

    Public Sub ReservarParaHoy()
        If DateTime.Now.Date = DateTime.Now.Date Then ' si es hoy
            Me.MesasEstado = "R"
        End If
    End Sub
End Class
