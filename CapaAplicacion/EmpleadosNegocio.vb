Imports System.Data.SqlClient

Public Class EmpleadosNegocio
    Private empleadoSQL As New EmpleadoSQL()
    Private codigosSQL As New CodigosSQL()
    Public Function EliminarEmpleado(empleadoCodigo As String) As Boolean
        If String.IsNullOrWhiteSpace(empleadoCodigo) Then
            Throw New ArgumentException("El código del empleado no puede estar vacío.")
        End If
        Return empleadoSQL.CambiarEstadoEmpleado(empleadoCodigo, "spEliminarEmpleado")
    End Function
    Public Function RecuperarEmpleado(empleadoCodigo As String) As Boolean
        If String.IsNullOrWhiteSpace(empleadoCodigo) Then
            Throw New ArgumentException("El código del empleado no puede estar vacío.")
        End If
        Return empleadoSQL.CambiarEstadoEmpleado(empleadoCodigo, "spRecuperarEmpleado")
    End Function
    Public Function ObtenerEmpleadosActivos() As List(Of Empleado)
        Return empleadoSQL.ObtenerEmpleados("spListarEmpleadosActivos")
    End Function
    Public Function ObtenerEmpleadosBorrados() As List(Of Empleado)
        Return empleadoSQL.ObtenerEmpleados("spListarEmpleadosBorrados")
    End Function
    Public Function ActualizarEmpleado(empleado As Empleado) As Boolean
        ' Validaciones a nivel de negocio
        If String.IsNullOrWhiteSpace(empleado.EmpleadosCodigo) Then
            Throw New ArgumentException("El código del empleado es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(empleado.EmpleadosPaterno) Then
            Throw New ArgumentException("El apellido paterno es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(empleado.EmpleadosMaterno) Then
            Throw New ArgumentException("El apellido materno es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(empleado.EmpleadosNombres) Then
            Throw New ArgumentException("El nombre del empleado es obligatorio.")
        End If

        ' Validar que el sexo sea 'F' o 'M'
        If empleado.EmpleadosSexo <> "F" AndAlso empleado.EmpleadosSexo <> "M" Then
            Throw New ArgumentException("El sexo debe ser 'F' o 'M'.")
        End If

        ' Validar que el salario sea mayor a cero
        If empleado.EmpleadosSalario <= 0 Then
            Throw New ArgumentException("El salario debe ser mayor que cero.")
        End If

        ' Validar que el rol del empleado esté definido
        If String.IsNullOrWhiteSpace(empleado.EmpleadosRolesPermisosCodigo) Then
            Throw New ArgumentException("El rol del empleado es obligatorio.")
        End If

        ' Si todas las validaciones son correctas, proceder a la actualización
        Return empleadoSQL.ActualizarEmpleado(empleado)
    End Function

    Public Function GenerarCodigoUnicoEmpleado() As String
        Return codigosSQL.GenerarCodigoUnico("EMP", "Restaurante.Empleados", "EmpleadosCodigo")
    End Function
    Public Function InsertarEmpleado(empleado As Empleado) As Boolean
        ' Validaciones en la capa de negocio
        If String.IsNullOrWhiteSpace(empleado.EmpleadosCodigo) Then
            Throw New ArgumentException("El código del empleado es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(empleado.EmpleadosRolesPermisosCodigo) Then
            Throw New ArgumentException("El código del rol es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(empleado.EmpleadosPaterno) Then
            Throw New ArgumentException("El apellido paterno es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(empleado.EmpleadosMaterno) Then
            Throw New ArgumentException("El apellido materno es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(empleado.EmpleadosNombres) Then
            Throw New ArgumentException("El nombre del empleado es obligatorio.")
        End If

        ' Validar que el sexo sea 'F' o 'M'
        If empleado.EmpleadosSexo <> "F" AndAlso empleado.EmpleadosSexo <> "M" Then
            Throw New ArgumentException("El sexo debe ser 'F' o 'M'.")
        End If

        ' Validar que el salario sea mayor a cero
        If empleado.EmpleadosSalario <= 0 Then
            Throw New ArgumentException("El salario debe ser mayor que cero.")
        End If

        ' Validaciones completas, intentar insertar el empleado
        Try
            Return empleadoSQL.InsertarEmpleado(empleado)
        Catch sqlEx As SqlException When sqlEx.Number = 2627 ' Error de clave duplicada
            Throw New Exception("El código del empleado ya existe. Por favor, genere un nuevo código único antes de guardar.")
        Catch ex As Exception
            ' Re-lanzar cualquier otro error que pueda ocurrir, pero con un mensaje más amigable
            Throw New Exception("Ocurrió un error al intentar insertar el empleado. Por favor, verifica los datos e intenta nuevamente.")
        End Try
    End Function
End Class
