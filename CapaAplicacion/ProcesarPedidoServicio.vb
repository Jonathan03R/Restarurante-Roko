'El servicio mas amplio tendra la obtencion y procesos necesarios para procesar un peedido xd

Imports System.Net.Configuration

Public Class ProcesarPedidoServicio
    Private mesasSQL As New MesaSQL()
    Private pedidoSQL As New PedidoSQL()
    Private detallesPedidosSQL As New DetallePedidoSQL()
    Private codigoSQL As New CodigosSQL()
    Private menuSQL As New MenuSQL()
    'necesitamos primero listar todas las mesas para poder verlas en la interfaz


    Public Function ObtenerMesas(Optional estadoMesas As String = Nothing) As DataTable
        Try
            ModuloSistema.IniciarTransaccion()
            ' Obtener mesas desde la capa de persistencia
            Dim result As DataTable = mesasSQL.ObtenerMesasComoDataTable(estadoMesas)
            ModuloSistema.TerminarTransaccion()
            Return result
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw ex
        End Try
    End Function

    'si la mesa esta vacia y se ingresa esta mesa comienza el proceso de un nuevo pedido para ello se crea el pedido
    Public Sub CrearPedidoMesaVacia(mesaCodigo As String, empleadoCodigo As String)
        Try
            ' Validar que mesaCodigo y empleadoCodigo no sean nulos o vacíos
            If String.IsNullOrWhiteSpace(mesaCodigo) Then
                Throw New ArgumentException("El código de la mesa no puede estar vacío.")
            End If

            If String.IsNullOrWhiteSpace(empleadoCodigo) Then
                Throw New ArgumentException("El código del empleado no puede estar vacío.")
            End If

            ModuloSistema.IniciarTransaccion()
            Dim codigoPedido = codigoSQL.GenerarCodigoUnico("PED", "Restaurante.Pedidos", "PedidosCodigo")
            pedidoSQL.CrearPedido(codigoPedido, mesaCodigo, empleadoCodigo)
            ModuloSistema.TerminarTransaccion()

        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw New Exception("Error al crear pedido " & ex.Message)
        End Try
    End Sub

    'luego se lista el menu de este pedido
    Public Function ListarMenuActivo() As List(Of Menu)
        Try
            ModuloSistema.IniciarTransaccion()
            Dim listaMenuActiva As List(Of Menu) = menuSQL.ListarMenuActivo()
            ModuloSistema.TerminarTransaccion()
            Return listaMenuActiva
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw New Exception("Error al listar el menú activo: " & ex.Message)
        End Try
    End Function

    'luego segun las elecciones se agrega un detalle pedido: 
    Public Sub agregarDetallePedidos(menuCodigo As String, precio As Double, cantidad As Integer, codigoMesa As String)
        Try

            Debug.WriteLine("datos " & menuCodigo & " " & precio.ToString() & " " & cantidad.ToString() & " " & codigoMesa)
            If String.IsNullOrWhiteSpace(menuCodigo) Then
                Throw New ArgumentException("El código del menú no puede estar vacío.")
            End If

            If precio <= 0 Then
                Throw New ArgumentException("El precio debe ser mayor que cero.")
            End If

            If cantidad <= 0 Then
                Throw New ArgumentException("La cantidad debe ser mayor que cero.")
            End If

            If String.IsNullOrWhiteSpace(codigoMesa) Then
                Throw New ArgumentException("El código de la mesa no puede estar vacío.")
            End If

            ' Iniciar transacción
            ModuloSistema.IniciarTransaccion()

            ' Generar código para el detalle del pedido

            Dim pedido As Pedido = pedidoSQL.ObtenerPedidoPorMesa(codigoMesa)
            If pedido Is Nothing OrElse String.IsNullOrWhiteSpace(pedido.PedidosCodigo) Then
                Throw New Exception("No se encontró un pedido activo para la mesa especificada.")
            End If
            Dim codigoDetalle = codigoSQL.GenerarCodigoUnico("DET", "Restaurante.DetallesPedido", "DetallesPedidoCodigo")
            ' Crear el objeto de detalle del pedido
            Dim detalle As New DetallePedido With {
            .DetallesPedidoCodigo = codigoDetalle,
            .DetallesPedidoPedidosCodigo = pedido.PedidosCodigo,
            .DetallesPedidoMenuCodigo = menuCodigo,
            .DetallesPedidoPrecio = precio,
            .DetallesPedidoCantidad = cantidad
        }
            detallesPedidosSQL.AgregarDetallePedido(codigoDetalle, pedido.PedidosCodigo, detalle)
            mesasSQL.OcuparMesa(codigoMesa)
            ModuloSistema.TerminarTransaccion()

        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw ex
        End Try
    End Sub

    'me tiene que devolver los detalles del pedido que esta actualmente en la mesa ocupada
    Public Function ObtenerDetallesPedidoComoDataTable(mesaCodigo As String) As DataTable
        Try
            ' Iniciar la transacción para obtener detalles de pedido
            ModuloSistema.IniciarTransaccion()
            Dim pedido As Pedido = pedidoSQL.ObtenerPedidoPorMesa(mesaCodigo)
            If pedido Is Nothing OrElse String.IsNullOrWhiteSpace(pedido.PedidosCodigo) Then
                Throw New Exception("No se encontró un pedido activo para la mesa especificada.")
            End If

            Dim listaDetalles As List(Of DetallePedido) = detallesPedidosSQL.ObtenerDetallesPedido(pedido.PedidosCodigo)
            ModuloSistema.TerminarTransaccion()

            ' Convertir la lista de DetallePedido en un DataTable
            Dim dataTable As New DataTable()
            dataTable.Columns.Add("DetallesPedidoCodigo", GetType(String))
            dataTable.Columns.Add("DetallesPedidoMenuCodigo", GetType(String))
            dataTable.Columns.Add("MenuNombre", GetType(String))
            dataTable.Columns.Add("DetallesPedidoPrecio", GetType(Double))
            dataTable.Columns.Add("DetallesPedidoCantidad", GetType(Double))
            dataTable.Columns.Add("Total", GetType(Double))
            dataTable.Columns.Add("DetallesPedidoEstado", GetType(String))

            For Each detalle As DetallePedido In listaDetalles
                Dim row As DataRow = dataTable.NewRow()
                row("DetallesPedidoCodigo") = detalle.DetallesPedidoCodigo
                row("DetallesPedidoMenuCodigo") = detalle.DetallesPedidoMenuCodigo
                row("MenuNombre") = detalle.Menu.MenuNombre
                row("DetallesPedidoPrecio") = detalle.DetallesPedidoPrecio
                row("DetallesPedidoCantidad") = detalle.DetallesPedidoCantidad
                row("Total") = detalle.CalcularTotal()
                row("DetallesPedidoEstado") = detalle.DetallesPedidoEstado
                dataTable.Rows.Add(row)
            Next

            Return dataTable
        Catch ex As Exception
            Throw New Exception("Error al obtener detalles del pedido: " & ex.Message)
            ModuloSistema.CancelarTransaccion()
        End Try
    End Function

    'imaginando que el cliente ya no quiere el pedido :C procede a cancelarse
    Public Sub cancelarElPedido(codigoMesa As String)
        Try
            If String.IsNullOrWhiteSpace(codigoMesa) Then
                Throw New ArgumentException("El código de la mesa no puede estar vacío.")
            End If
            ModuloSistema.IniciarTransaccion()
            Dim pedido As Pedido = pedidoSQL.ObtenerPedidoPorMesa(codigoMesa)
            If pedido Is Nothing OrElse String.IsNullOrWhiteSpace(pedido.PedidosCodigo) Then
                Throw New Exception("No se encontró un pedido activo para la mesa especificada.")
            End If
            pedidoSQL.FinalizarPedido(pedido.PedidosCodigo)
            mesasSQL.DesocuparMesa(codigoMesa)
            ModuloSistema.TerminarTransaccion()
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw ex
        End Try
    End Sub



    '**********************************************************************************
    'cuando la mesa esta ocupada, entonces:

    Public Function ObtenerPedidoPorMesa(mesaCodigo As String) As Pedido
        Try
            If String.IsNullOrWhiteSpace(mesaCodigo) Then
                Throw New ArgumentException("El código de la mesa no puede estar vacío.")
            End If
            ModuloSistema.IniciarTransaccion()
            Dim pedido As Pedido = pedidoSQL.ObtenerPedidoPorMesa(mesaCodigo)
            ModuloSistema.TerminarTransaccion()
            Return pedido

        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw New Exception("Error al obtener el pedido por mesa: " & ex.Message)
        End Try
    End Function

    'Eliminar Item del detalle del pedido

    Public Function EliminarDetallePedido(detalleCodigo As String) As Boolean
        Try
            If String.IsNullOrWhiteSpace(detalleCodigo) Then
                Throw New ArgumentException("El código del detalle no puede estar vacío.")
            End If
            ModuloSistema.IniciarTransaccion()
            detallesPedidosSQL.EliminarDetallePedido(detalleCodigo)
            ModuloSistema.TerminarTransaccion()
            Return True
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw New Exception("Error al eliminar el detalle del pedido: " & ex.Message)
        End Try
    End Function


    'obtenetener el listado de todos los pedidos 

    Public Function ObtenerListadosPedidos() As DataTable
        Try
            ModuloSistema.IniciarTransaccion()
            Dim listaPedidos As List(Of Pedido) = pedidoSQL.ObtenerPedidosConDetalle()
            Dim dataTable As New DataTable()
            dataTable.Columns.Add("CodigoPedido", GetType(String))
            dataTable.Columns.Add("CodigoMesa", GetType(String))
            dataTable.Columns.Add("CodigoEmpleado", GetType(String))
            dataTable.Columns.Add("NombreEmpleado", GetType(String))
            dataTable.Columns.Add("CargoEmpleado", GetType(String))
            dataTable.Columns.Add("EstadoPedido", GetType(String))

            For Each pedido As Pedido In listaPedidos
                Dim row As DataRow = dataTable.NewRow()
                row("CodigoPedido") = pedido.PedidosCodigo
                row("CodigoMesa") = pedido.PedidosMesasCodigo
                row("CodigoEmpleado") = pedido.PedidosEmpleadosCodigo
                row("NombreEmpleado") = pedido.Empleado.EmpleadosNombreCompleto
                row("CargoEmpleado") = pedido.Empleado.RolPermiso.RolesPermisosNombreRol
                row("EstadoPedido") = pedido.PedidosEstado
                dataTable.Rows.Add(row)
            Next
            ModuloSistema.TerminarTransaccion()
            Return dataTable
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw ex
        End Try
    End Function


End Class
