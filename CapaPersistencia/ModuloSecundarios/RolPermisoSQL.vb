Imports System.Data.SqlClient

Public Class RolPermisoSQL
    Public Function ObtenerRolesActivos() As List(Of RolPermiso)
        Dim listaRoles As New List(Of RolPermiso)

        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spListarRolesActivos", cn)
            cmd.CommandType = CommandType.StoredProcedure

            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader()

            While dr.Read()
                Dim rolPermiso As New RolPermiso()
                rolPermiso.RolesPermisosCodigo = dr("RolesPermisosCodigo").ToString()
                rolPermiso.RolesPermisosNombreRol = dr("RolesPermisosNombreRol").ToString()
                listaRoles.Add(rolPermiso)
            End While

            dr.Close()
        End Using

        Return listaRoles
    End Function
End Class
