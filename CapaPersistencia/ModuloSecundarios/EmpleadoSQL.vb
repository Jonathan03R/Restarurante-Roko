Imports System.Data.SqlClient

Public Class EmpleadoSQL
    Public Function ObtenerEmpleados(procedimiento As String) As List(Of Empleado)
        Dim listaEmpleados As New List(Of Empleado)

        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand(procedimiento, cn)
            cmd.CommandType = CommandType.StoredProcedure

            cn.Open()
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
                empleado.EmpleadosFechaContratacion = Convert.ToDateTime(dr("EmpleadosFechaContratacion"))

                ' Asignar el rol del empleado
                Dim rolPermiso As New RolPermiso()
                rolPermiso.RolesPermisosNombreRol = dr("RolesPermisosNombreRol").ToString()
                empleado.RolPermiso = rolPermiso

                listaEmpleados.Add(empleado)
            End While
            dr.Close()
        End Using

        Return listaEmpleados
    End Function
    Public Function CambiarEstadoEmpleado(empleadoCodigo As String, procedimiento As String) As Boolean
        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand(procedimiento, cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@EmpleadoCodigo", empleadoCodigo)
            cn.Open()
            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
            cn.Close()
            Return filasAfectadas > 0
        End Using
    End Function
    Public Function ActualizarEmpleado(empleado As Empleado) As Boolean
        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spActualizarEmpleado", cn)
            cmd.CommandType = CommandType.StoredProcedure

            ' Validar qué parámetros agregar para evitar pasar valores vacíos
            If Not String.IsNullOrWhiteSpace(empleado.EmpleadosPaterno) Then
                cmd.Parameters.AddWithValue("@EmpleadosPaterno", empleado.EmpleadosPaterno)
            End If

            If Not String.IsNullOrWhiteSpace(empleado.EmpleadosMaterno) Then
                cmd.Parameters.AddWithValue("@EmpleadosMaterno", empleado.EmpleadosMaterno)
            End If

            If Not String.IsNullOrWhiteSpace(empleado.EmpleadosNombres) Then
                cmd.Parameters.AddWithValue("@EmpleadosNombres", empleado.EmpleadosNombres)
            End If

            If Not String.IsNullOrWhiteSpace(empleado.EmpleadosTelefono) Then
                cmd.Parameters.AddWithValue("@EmpleadosTelefono", empleado.EmpleadosTelefono)
            End If

            If Not String.IsNullOrWhiteSpace(empleado.EmpleadosSexo) Then
                cmd.Parameters.AddWithValue("@EmpleadosSexo", empleado.EmpleadosSexo)
            End If

            If Not String.IsNullOrWhiteSpace(empleado.EmpleadosHoraEntreada) Then
                cmd.Parameters.AddWithValue("@EmpleadosHoraEntreada", empleado.EmpleadosHoraEntreada)
            End If

            If empleado.EmpleadosSalario > 0 Then
                cmd.Parameters.AddWithValue("@EmpleadosSalario", empleado.EmpleadosSalario)
            End If

            ' Este parámetro es obligatorio, siempre se envía
            cmd.Parameters.AddWithValue("@EmpleadosCodigo", empleado.EmpleadosCodigo)

            ' Roles permisos
            cmd.Parameters.AddWithValue("@EmpleadosRolesPermisosCodigo", empleado.EmpleadosRolesPermisosCodigo)

            cn.Open()
            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
            cn.Close()

            Return filasAfectadas > 0
        End Using
    End Function
    Public Function InsertarEmpleado(empleado As Empleado) As Boolean
        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spInsertarEmpleado", cn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@EmpleadosCodigo", empleado.EmpleadosCodigo)
            cmd.Parameters.AddWithValue("@EmpleadosRolesPermisosCodigo", empleado.EmpleadosRolesPermisosCodigo)
            cmd.Parameters.AddWithValue("@EmpleadosPaterno", empleado.EmpleadosPaterno)
            cmd.Parameters.AddWithValue("@EmpleadosMaterno", empleado.EmpleadosMaterno)
            cmd.Parameters.AddWithValue("@EmpleadosNombres", empleado.EmpleadosNombres)
            cmd.Parameters.AddWithValue("@EmpleadosTelefono", empleado.EmpleadosTelefono)
            cmd.Parameters.AddWithValue("@EmpleadosSexo", empleado.EmpleadosSexo)
            cmd.Parameters.AddWithValue("@EmpleadosHoraEntreada", empleado.EmpleadosHoraEntreada)
            cmd.Parameters.AddWithValue("@EmpleadosSalario", empleado.EmpleadosSalario)

            cn.Open()
            Try
                Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                cn.Close()
                Return filasAfectadas > 0
            Catch ex As SqlException
                cn.Close()
                Throw New Exception("Error al insertar empleado: " & ex.Message)
            End Try
        End Using
    End Function
End Class
