Imports System.Data.SqlClient

Public Class EmpleadoSQL
    Public Function ObtenerEmpleadosActivos() As List(Of Empleado)
        Dim listaEmpleados As New List(Of Empleado)

        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spListarEmpleadosActivos")
            Dim dr As SqlDataReader = cmd.ExecuteReader()

            While dr.Read()
                Dim empleado As New Empleado()
                empleado.EmpleadosCodigo = dr("EmpleadosCodigo").ToString()
                empleado.EmpleadosRolesPermisosCodigo = dr("EmpleadosRolesPermisosCodigo").ToString()
                empleado.EmpleadosPaterno = dr("EmpleadosPaterno").ToString()
                empleado.EmpleadosMaterno = dr("EmpleadosMaterno").ToString()
                empleado.EmpleadosNombres = dr("EmpleadosNombres").ToString()
                empleado.EmpleadosNombreCompleto = dr("EmpleadosNombreCompleto").ToString()
                empleado.EmpleadosTelefono = dr("EmpleadosTelefono").ToString()
                empleado.EmpleadosEstado = dr("EmpleadosEstado").ToString()
                empleado.EmpleadosSexo = dr("EmpleadosSexo").ToString()
                empleado.EmpleadosHoraEntreada = dr("EmpleadosHoraEntreada").ToString()
                empleado.EmpleadosSalario = Convert.ToDouble(dr("EmpleadosSalario"))
                empleado.EmpleadosFechaContratacion = DateTime.ParseExact(dr("EmpleadosFechaContratacion").ToString(), "dd/MM/yy", Nothing)

                Dim rolPermiso As New RolPermiso()
                rolPermiso.RolesPermisosNombreRol = dr("RolesPermisosNombreRol").ToString()
                empleado.RolPermiso = rolPermiso

                listaEmpleados.Add(empleado)
            End While
            dr.Close()
        Catch ex As Exception
            Throw New Exception("Error al obtener empleados activos: " & ex.Message)
        End Try

        Return listaEmpleados
    End Function

    Public Function ObtenerEmpleadosBorrados() As List(Of Empleado)
        Dim listaEmpleados As New List(Of Empleado)

        Try
            ' Configuramos el comando con el procedimiento almacenado "spListarEmpleadosBorrados"
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spListarEmpleadosBorrados")

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                Dim empleado As New Empleado()
                empleado.EmpleadosCodigo = dr("EmpleadosCodigo").ToString()
                empleado.EmpleadosRolesPermisosCodigo = dr("EmpleadosRolesPermisosCodigo").ToString()
                empleado.EmpleadosPaterno = dr("EmpleadosPaterno").ToString()
                empleado.EmpleadosMaterno = dr("EmpleadosMaterno").ToString()
                empleado.EmpleadosNombres = dr("EmpleadosNombres").ToString()
                empleado.EmpleadosNombreCompleto = dr("EmpleadosNombreCompleto").ToString()
                empleado.EmpleadosTelefono = dr("EmpleadosTelefono").ToString()
                empleado.EmpleadosEstado = dr("EmpleadosEstado").ToString()
                empleado.EmpleadosSexo = dr("EmpleadosSexo").ToString()
                empleado.EmpleadosHoraEntreada = dr("EmpleadosHoraEntreada").ToString()
                empleado.EmpleadosSalario = Convert.ToDouble(dr("EmpleadosSalario"))
                empleado.EmpleadosFechaContratacion = DateTime.ParseExact(dr("EmpleadosFechaContratacion").ToString(), "dd/MM/yy", Nothing)

                Dim rolPermiso As New RolPermiso()
                rolPermiso.RolesPermisosNombreRol = dr("RolesPermisosNombreRol").ToString()
                empleado.RolPermiso = rolPermiso

                listaEmpleados.Add(empleado)
            End While
            dr.Close()
        Catch ex As Exception
            Throw New Exception("Error al obtener empleados borrados: " & ex.Message)
        End Try

        Return listaEmpleados
    End Function

    Public Function EliminarEmpleado(empleadoCodigo As String) As Boolean
        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spEliminarEmpleado")
            cmd.Parameters.AddWithValue("@EmpleadoCodigo", empleadoCodigo)

            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
            Return filasAfectadas > 0
        Catch ex As Exception
            Throw New Exception("Error al eliminar empleado: " & ex.Message)
        End Try
    End Function

    Public Function RecuperarEmpleado(empleadoCodigo As String) As Boolean
        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spRecuperarEmpleado")
            cmd.Parameters.AddWithValue("@EmpleadoCodigo", empleadoCodigo)

            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
            Return filasAfectadas > 0
        Catch ex As Exception
            Throw New Exception("Error al recuperar empleado: " & ex.Message)
        End Try
    End Function

    Public Function ActualizarEmpleado(empleado As Empleado) As Boolean
        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spActualizarEmpleado")

            cmd.Parameters.AddWithValue("@EmpleadosCodigo", empleado.EmpleadosCodigo)
            cmd.Parameters.AddWithValue("@EmpleadosPaterno", empleado.EmpleadosPaterno)
            cmd.Parameters.AddWithValue("@EmpleadosMaterno", empleado.EmpleadosMaterno)
            cmd.Parameters.AddWithValue("@EmpleadosNombres", empleado.EmpleadosNombres)
            cmd.Parameters.AddWithValue("@EmpleadosTelefono", empleado.EmpleadosTelefono)
            cmd.Parameters.AddWithValue("@EmpleadosSexo", empleado.EmpleadosSexo)
            cmd.Parameters.AddWithValue("@EmpleadosHoraEntreada", empleado.EmpleadosHoraEntreada)
            cmd.Parameters.AddWithValue("@EmpleadosSalario", empleado.EmpleadosSalario)
            cmd.Parameters.AddWithValue("@EmpleadosRolesPermisosCodigo", empleado.EmpleadosRolesPermisosCodigo)

            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
            Return filasAfectadas > 0
        Catch ex As Exception
            Throw New Exception("Error al actualizar empleado: " & ex.Message)
        End Try
    End Function

    Public Function InsertarEmpleado(empleado As Empleado) As Boolean
        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spInsertarEmpleado")

            cmd.Parameters.AddWithValue("@EmpleadosCodigo", empleado.EmpleadosCodigo)
            cmd.Parameters.AddWithValue("@EmpleadosRolesPermisosCodigo", empleado.EmpleadosRolesPermisosCodigo)
            cmd.Parameters.AddWithValue("@EmpleadosPaterno", empleado.EmpleadosPaterno)
            cmd.Parameters.AddWithValue("@EmpleadosMaterno", empleado.EmpleadosMaterno)
            cmd.Parameters.AddWithValue("@EmpleadosNombres", empleado.EmpleadosNombres)
            cmd.Parameters.AddWithValue("@EmpleadosTelefono", empleado.EmpleadosTelefono)
            cmd.Parameters.AddWithValue("@EmpleadosSexo", empleado.EmpleadosSexo)
            cmd.Parameters.AddWithValue("@EmpleadosHoraEntreada", empleado.EmpleadosHoraEntreada)
            cmd.Parameters.AddWithValue("@EmpleadosSalario", empleado.EmpleadosSalario)

            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
            Return filasAfectadas > 0
        Catch ex As SqlException
            Throw New Exception("Error al insertar empleado: " & ex.Message)
        End Try
    End Function

End Class
