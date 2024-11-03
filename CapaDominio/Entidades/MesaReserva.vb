Public Class MesaReserva
    Public Property ReservasCodigo As String
    Public Property ReservasClientesCodigo As String
    Public Property ReservasMesasCodigo As String
    Public Property ReservasEstado As String
    Public Property ReservasFechaHoraReserva As Date


    Public Property Mesa As Mesa
    Public Property Cliente As Cliente



    Public Sub AsignarCodigo(codigo As String)
        Me.ReservasCodigo = codigo
    End Sub

    Public Sub Activar()
        Me.ReservasEstado = "A"
    End Sub

    Public Function EsFechaValida() As Boolean
        Return ReservasFechaHoraReserva > DateTime.Now
    End Function

End Class
