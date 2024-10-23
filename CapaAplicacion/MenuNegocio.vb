Public Class MenuNegocio
    Private menuSQL As New MenuSQL()

    Private codigoSQL As New CodigosSQL()

    ' Método para obtener el menú activo
    Public Function ObtenerMenuActivo() As List(Of Menu)
        Return menuSQL.ListarMenuActivo()
    End Function

    Public Function ObtenerMenuPorCodigo(menuCodigo As String) As Menu
        Return menuSQL.ObtenerMenuPorCodigo(menuCodigo)
    End Function

    Public Function ActualizarMenu(menu As Menu) As Boolean
        Return menuSQL.ActualizarMenu(menu)
    End Function

    Public Function InsertarMenu(menu As Menu) As Boolean
        Return menuSQL.InsertarMenu(menu)
    End Function

    Public Function ObtenerMenu() As List(Of Menu)
        Return menuSQL.ListarMenu()
    End Function

    Public Function GenerarCodigoUnicoMenu() As String
        Return codigoSQL.GenerarCodigoUnico("MEN", "Restaurante.Menu", "MenuCodigo")
    End Function

End Class
