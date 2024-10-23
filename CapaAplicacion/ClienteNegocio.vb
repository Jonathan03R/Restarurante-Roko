Public Class ClienteNegocio
    Private clienteSQL As New ClienteSQL()

    Private codigoSQL As New CodigosSQL()

    Public Function ObtenerClientesActivos() As List(Of Cliente)
        Return clienteSQL.ObtenerClientesActivos()
    End Function

    Public Function ActualizarCliente(cliente As Cliente) As Boolean
        ' Variables que almacenan las partes de la consulta que se van a actualizar
        Dim camposParaActualizar As New List(Of String)

        ' Validar si cada campo no está vacío, y si no lo está, lo agregamos a la lista de campos para actualizar
        If Not String.IsNullOrWhiteSpace(cliente.ClientesNombre) Then
            camposParaActualizar.Add("ClientesNombre = @ClientesNombre")
        End If
        If Not String.IsNullOrWhiteSpace(cliente.ClientesApellidos) Then
            camposParaActualizar.Add("ClientesApellidos = @ClientesApellidos")
        End If
        If Not String.IsNullOrWhiteSpace(cliente.ClientesTelefono) Then
            camposParaActualizar.Add("ClientesTelefono = @ClientesTelefono")
        End If
        If Not String.IsNullOrWhiteSpace(cliente.ClientesCorreo) Then
            camposParaActualizar.Add("ClientesCorreo = @ClientesCorreo")
        End If

        ' Si no hay campos para actualizar, se lanza una excepción
        If camposParaActualizar.Count = 0 Then
            Throw New ArgumentException("Debe proporcionar al menos un campo para actualizar.")
        End If

        ' Construir la consulta con los campos dinámicos
        Dim consultaActualizacion As String = "update Restaurante.Clientes set " & String.Join(", ", camposParaActualizar) & " where ClientesCodigo = @ClientesCodigo"

        ' Llamamos a la capa de persistencia, pasando la consulta generada dinámicamente
        Return clienteSQL.ActualizarCliente(cliente, consultaActualizacion)
    End Function
    Public Function ObtenerReservasPorCliente(clienteCodigo As String) As List(Of MesaReserva)
        Return clienteSQL.ObtenerReservasPorCliente(clienteCodigo)
    End Function

    Public Function EliminarCliente(cliente As Cliente) As Boolean
        If String.IsNullOrWhiteSpace(cliente.ClientesCodigo) Then
            Throw New ArgumentException("El código del cliente no puede estar vacío.")
        End If

        Return clienteSQL.EliminarCliente(cliente.ClientesCodigo)
    End Function

    Public Function ObtenerClientesBorrados() As List(Of Cliente)
        Return clienteSQL.ObtenerClientesBorrados()
    End Function


    Public Function RecuperarCliente(clienteCodigo As String) As Boolean
        Return clienteSQL.RecuperarCliente(clienteCodigo)
    End Function

    Public Function BuscarClientesPorNombre(nombre As String) As List(Of Cliente)
        Return clienteSQL.BuscarClientesPorNombre(nombre)
    End Function

    Public Function GenerarCodigoUnicoCliente() As String
        Return codigoSQL.GenerarCodigoUnico("CL", "Restaurante.Clientes", "ClientesCodigo")
    End Function

    Public Function InsertarCliente(cliente As Cliente) As Boolean
        ' Validaciones a nivel de negocio
        If String.IsNullOrWhiteSpace(cliente.ClientesCodigo) Then
            Throw New ArgumentException("El código del cliente es obligatorio.")
        End If
        If String.IsNullOrWhiteSpace(cliente.ClientesNombre) Then
            Throw New ArgumentException("El nombre del cliente es obligatorio.")
        End If
        If String.IsNullOrWhiteSpace(cliente.ClientesApellidos) Then
            Throw New ArgumentException("El apellido del cliente es obligatorio.")
        End If
        If String.IsNullOrWhiteSpace(cliente.ClientesDNI) Then
            Throw New ArgumentException("El DNI del cliente es obligatorio.")
        End If
        If String.IsNullOrWhiteSpace(cliente.ClientesCorreo) Then
            Throw New ArgumentException("El correo electrónico es obligatorio.")
        End If

        ' Llamada a la capa de persistencia
        Return clienteSQL.InsertarCliente(cliente)
    End Function


End Class
