Public Class RolPermisoNegocio
    Private rolPermisoSQL As New RolPermisoSQL()

    Public Function ObtenerRolesActivos() As List(Of RolPermiso)
        Return rolPermisoSQL.ObtenerRolesActivos()
    End Function
End Class
