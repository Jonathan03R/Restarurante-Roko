Public Class ProcesoGestionarEmpleadosServicios
    Private empleadosSQL As New EmpleadoSQL()
    Private codigoSQL As New CodigosSQL()
    Private rolPermisoSQL As New RolPermisoSQL()

    Public Function crearNuevoEmpleado(
                                   EmpleadosRolesPermisosCodigo As String,
                                   EmpleadosPaterno As String,
                                   EmpleadosMaterno As String,
                                   EmpleadosNombres As String,
                                   EmpleadosTelefono As String,
                                   EmpleadosSexo As String,
                                   EmpleadosHoraEntrada As String,
                                   EmpleadosSalario As Double
                               ) As Boolean

        If String.IsNullOrWhiteSpace(EmpleadosRolesPermisosCodigo) OrElse EmpleadosRolesPermisosCodigo.Length <> 8 Then
            Throw New ArgumentException("El código de roles y permisos debe tener 8 caracteres.")
        End If

        If String.IsNullOrWhiteSpace(EmpleadosPaterno) Then
            Throw New ArgumentException("El apellido paterno no puede estar vacío.")
        End If

        If String.IsNullOrWhiteSpace(EmpleadosMaterno) Then
            Throw New ArgumentException("El apellido materno no puede estar vacío.")
        End If

        If String.IsNullOrWhiteSpace(EmpleadosNombres) Then
            Throw New ArgumentException("El nombre no puede estar vacío.")
        End If

        If Not String.IsNullOrWhiteSpace(EmpleadosSexo) AndAlso EmpleadosSexo <> "M" AndAlso EmpleadosSexo <> "F" Then
            Throw New ArgumentException("El sexo debe ser 'M' o 'F'.")
        End If

        If EmpleadosSalario < 0 Then
            Throw New ArgumentException("El salario no puede ser negativo.")
        End If

        Try
            Dim EmpleadoCodigo = GenerarCodigoUnicoEmpleado()
            ModuloSistema.IniciarTransaccion()
            Dim empleado As New Empleado With {
                .EmpleadosCodigo = EmpleadoCodigo,
                .EmpleadosRolesPermisosCodigo = EmpleadosRolesPermisosCodigo,
                .EmpleadosPaterno = EmpleadosPaterno,
                .EmpleadosMaterno = EmpleadosMaterno,
                .EmpleadosNombres = EmpleadosNombres,
                .EmpleadosTelefono = EmpleadosTelefono,
                .EmpleadosSexo = EmpleadosSexo,
                .EmpleadosHoraEntreada = EmpleadosHoraEntrada,
                .EmpleadosSalario = EmpleadosSalario
            }

            Dim resultado As Boolean = empleadosSQL.InsertarEmpleado(empleado)

            ModuloSistema.TerminarTransaccion()
            Return resultado
        Catch ex As Exception
            Throw ex
            ModuloSistema.CancelarTransaccion()
        End Try
    End Function

    Public Function actualizarEmpleado(
                                   EmpleadosCodigo As String,
                                   EmpleadosRolesPermisosCodigo As String,
                                   EmpleadosPaterno As String,
                                   EmpleadosMaterno As String,
                                   EmpleadosNombres As String,
                                   EmpleadosTelefono As String,
                                   EmpleadosSexo As String,
                                   EmpleadosHoraEntrada As String,
                                   EmpleadosSalario As Double
                               ) As Boolean

        ' Validaciones para los parámetros de actualización de empleado
        If String.IsNullOrWhiteSpace(EmpleadosCodigo) OrElse EmpleadosCodigo.Length <> 8 Then
            Throw New ArgumentException("El código del empleado debe tener 8 caracteres.")
        End If

        If String.IsNullOrWhiteSpace(EmpleadosRolesPermisosCodigo) OrElse EmpleadosRolesPermisosCodigo.Length <> 8 Then
            Throw New ArgumentException("El código de roles y permisos debe tener 8 caracteres.")
        End If

        If String.IsNullOrWhiteSpace(EmpleadosPaterno) Then
            Throw New ArgumentException("El apellido paterno no puede estar vacío.")
        End If

        If String.IsNullOrWhiteSpace(EmpleadosMaterno) Then
            Throw New ArgumentException("El apellido materno no puede estar vacío.")
        End If

        If String.IsNullOrWhiteSpace(EmpleadosNombres) Then
            Throw New ArgumentException("El nombre no puede estar vacío.")
        End If

        If Not String.IsNullOrWhiteSpace(EmpleadosSexo) AndAlso EmpleadosSexo <> "M" AndAlso EmpleadosSexo <> "F" Then
            Throw New ArgumentException("El sexo debe ser 'M' o 'F'.")
        End If

        If EmpleadosSalario < 0 Then
            Throw New ArgumentException("El salario no puede ser negativo.")
        End If

        Try
            ' Iniciar la transacción antes de actualizar
            ModuloSistema.IniciarTransaccion()
            Dim empleado As New Empleado With {
                .EmpleadosCodigo = EmpleadosCodigo,
                .EmpleadosRolesPermisosCodigo = EmpleadosRolesPermisosCodigo,
                .EmpleadosPaterno = EmpleadosPaterno,
                .EmpleadosMaterno = EmpleadosMaterno,
                .EmpleadosNombres = EmpleadosNombres,
                .EmpleadosTelefono = EmpleadosTelefono,
                .EmpleadosSexo = EmpleadosSexo,
                .EmpleadosHoraEntreada = EmpleadosHoraEntrada,
                .EmpleadosSalario = EmpleadosSalario
            }

            Dim resultado As Boolean = empleadosSQL.ActualizarEmpleado(empleado)
            ModuloSistema.TerminarTransaccion()
            Return resultado

        Catch ex As Exception
            Throw ex
            ModuloSistema.CancelarTransaccion()
        End Try
    End Function

    Public Function obtenerEmpleadoActivos() As DataTable
        Try
            ModuloSistema.IniciarTransaccion()
            Dim listaEmpleados As List(Of Empleado) = empleadosSQL.ObtenerEmpleadosActivos()
            ' Crear el DataTable y definir las columnas
            Dim dataTable As New DataTable()
            dataTable.Columns.Add("EmpleadosCodigo", GetType(String))
            dataTable.Columns.Add("RolesPermisosNombreRol", GetType(String))
            dataTable.Columns.Add("EmpleadosPaterno", GetType(String))
            dataTable.Columns.Add("EmpleadosMaterno", GetType(String))
            dataTable.Columns.Add("EmpleadosNombres", GetType(String))
            dataTable.Columns.Add("EmpleadosNombreCompleto", GetType(String))
            dataTable.Columns.Add("EmpleadosTelefono", GetType(String))
            dataTable.Columns.Add("EmpleadosEstado", GetType(String))
            dataTable.Columns.Add("EmpleadosSexo", GetType(String))
            dataTable.Columns.Add("EmpleadosHoraEntreada", GetType(String))
            dataTable.Columns.Add("EmpleadosSalario", GetType(Double))
            dataTable.Columns.Add("EmpleadosFechaContratacion", GetType(Date))

            ' Llenar el DataTable con los datos de cada empleado
            For Each empleado In listaEmpleados
                Dim row As DataRow = dataTable.NewRow()
                row("EmpleadosCodigo") = empleado.EmpleadosCodigo
                row("RolesPermisosNombreRol") = empleado.RolPermiso.RolesPermisosNombreRol
                row("EmpleadosPaterno") = empleado.EmpleadosPaterno
                row("EmpleadosMaterno") = empleado.EmpleadosMaterno
                row("EmpleadosNombres") = empleado.EmpleadosNombres
                row("EmpleadosNombreCompleto") = empleado.EmpleadosNombreCompleto
                row("EmpleadosTelefono") = empleado.EmpleadosTelefono
                row("EmpleadosEstado") = empleado.EmpleadosEstado
                row("EmpleadosSexo") = empleado.EmpleadosSexo
                row("EmpleadosHoraEntreada") = empleado.EmpleadosHoraEntreada
                row("EmpleadosSalario") = empleado.EmpleadosSalario
                row("EmpleadosFechaContratacion") = empleado.EmpleadosFechaContratacion
                dataTable.Rows.Add(row)
            Next

            ModuloSistema.TerminarTransaccion()

            Return dataTable

        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw New Exception("Error al obtener la lista de clientes activos: " & ex.Message)
        End Try
    End Function

    Public Function obtenerEmpleadoInactivo() As DataTable
        Try
            ModuloSistema.IniciarTransaccion()
            Dim listaEmpleados As List(Of Empleado) = empleadosSQL.ObtenerEmpleadosBorrados()
            Dim dataTable As New DataTable()
            dataTable.Columns.Add("EmpleadosCodigo", GetType(String))
            dataTable.Columns.Add("RolesPermisosNombreRol", GetType(String))
            dataTable.Columns.Add("EmpleadosPaterno", GetType(String))
            dataTable.Columns.Add("EmpleadosMaterno", GetType(String))
            dataTable.Columns.Add("EmpleadosNombres", GetType(String))
            dataTable.Columns.Add("EmpleadosNombreCompleto", GetType(String))
            dataTable.Columns.Add("EmpleadosTelefono", GetType(String))
            dataTable.Columns.Add("EmpleadosEstado", GetType(String))
            dataTable.Columns.Add("EmpleadosSexo", GetType(String))
            dataTable.Columns.Add("EmpleadosHoraEntreada", GetType(String))
            dataTable.Columns.Add("EmpleadosSalario", GetType(Double))
            dataTable.Columns.Add("EmpleadosFechaContratacion", GetType(Date))

            ' Llenar el DataTable con los datos de cada empleado
            For Each empleado In listaEmpleados
                Dim row As DataRow = dataTable.NewRow()
                row("EmpleadosCodigo") = empleado.EmpleadosCodigo
                row("RolesPermisosNombreRol") = empleado.RolPermiso.RolesPermisosNombreRol
                row("EmpleadosPaterno") = empleado.EmpleadosPaterno
                row("EmpleadosMaterno") = empleado.EmpleadosMaterno
                row("EmpleadosNombres") = empleado.EmpleadosNombres
                row("EmpleadosNombreCompleto") = empleado.EmpleadosNombreCompleto
                row("EmpleadosTelefono") = empleado.EmpleadosTelefono
                row("EmpleadosEstado") = empleado.EmpleadosEstado
                row("EmpleadosSexo") = empleado.EmpleadosSexo
                row("EmpleadosHoraEntreada") = empleado.EmpleadosHoraEntreada
                row("EmpleadosSalario") = empleado.EmpleadosSalario
                row("EmpleadosFechaContratacion") = empleado.EmpleadosFechaContratacion
                dataTable.Rows.Add(row)
            Next
            ModuloSistema.TerminarTransaccion()
            ' Retornar el DataTable completo
            Return dataTable

        Catch ex As Exception

            Throw New Exception("Error al obtener la lista de clientes activos: " & ex.Message)
            ModuloSistema.CancelarTransaccion()
        End Try
    End Function

    Public Function recuperarEmpleado(CodigoEmpleado As String)
        Try
            ModuloSistema.IniciarTransaccion()
            Dim respuesta As Boolean = empleadosSQL.RecuperarEmpleado(CodigoEmpleado)
            ModuloSistema.TerminarTransaccion()

            Return respuesta
        Catch ex As Exception
            Throw New Exception("Error al recuperar empleado: " & ex.Message)
            ModuloSistema.CancelarTransaccion()
        End Try
    End Function

    Public Function CambiarEstadoInactivoEmpleado(codigoEmpleado As String) As Boolean
        Try
            If String.IsNullOrEmpty(codigoEmpleado) Then
                Throw New Exception("El código del cliente es obligatorio para cambiar su estado.")
            End If

            ModuloSistema.IniciarTransaccion()
            Dim resultado As Boolean = empleadosSQL.EliminarEmpleado(codigoEmpleado)
            ModuloSistema.TerminarTransaccion()
            Return resultado
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw New Exception("Error al cambiar el estado del empleado en la capa de aplicación: " & ex.Message)
        End Try
    End Function
    Public Function GenerarCodigoUnicoEmpleado() As String
        Try
            ModuloSistema.IniciarTransaccion()
            Dim result = codigoSQL.GenerarCodigoUnico("EMP", "Restaurante.Empleados", "EmpleadosCodigo")
            ModuloSistema.TerminarTransaccion()
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function ObtenerRolesActivosComoDataTable() As DataTable
        Try
            IniciarTransaccion()
            Dim listaRoles As List(Of RolPermiso) = rolPermisoSQL.ObtenerRolesActivos()
            Dim dtRoles As New DataTable()
            dtRoles.Columns.Add("RolesPermisosCodigo", GetType(String))
            dtRoles.Columns.Add("RolesPermisosNombreRol", GetType(String))

            For Each rol In listaRoles
                Dim row As DataRow = dtRoles.NewRow()
                row("RolesPermisosCodigo") = rol.RolesPermisosCodigo
                row("RolesPermisosNombreRol") = rol.RolesPermisosNombreRol
                dtRoles.Rows.Add(row)
            Next
            TerminarTransaccion()
            Return dtRoles
        Catch ex As Exception
            Throw ex
            CancelarTransaccion()
        End Try
    End Function
End Class
