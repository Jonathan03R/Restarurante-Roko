Public Class ProcesoGestionarMenuServicio
    Private menuSQL As New MenuSQL()
    Private codigoSQL As New CodigosSQL()

    Public Function MostrarMenu() As DataTable
        Try

            ModuloSistema.IniciarTransaccion()

            Dim listaMenu As List(Of Menu) = menuSQL.ListarMenu()

            Dim dataTable As New DataTable()
            dataTable.Columns.Add("MenuCodigo", GetType(String))
            dataTable.Columns.Add("MenuNombre", GetType(String))
            dataTable.Columns.Add("MenuDescripcion", GetType(String))
            dataTable.Columns.Add("MenuPrecio", GetType(Double))
            dataTable.Columns.Add("MenuEstado", GetType(String))
            dataTable.Columns.Add("MenuFoto", GetType(Image))

            For Each menuItem As Menu In listaMenu
                Dim row As DataRow = dataTable.NewRow()
                row("MenuCodigo") = menuItem.MenuCodigo
                row("MenuNombre") = menuItem.MenuNombre
                row("MenuDescripcion") = menuItem.MenuDescripcion
                row("MenuPrecio") = menuItem.MenuPrecio
                row("MenuEstado") = menuItem.MenuEstado
                row("MenuFoto") = menuItem.MenuFoto
                dataTable.Rows.Add(row)
            Next
            ModuloSistema.TerminarTransaccion()
            Return dataTable
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw ex
        End Try
    End Function

    Public Function ObtenerMenuPorCodigoComoDataTable(menuCodigo As String) As DataTable
        Try
            If String.IsNullOrWhiteSpace(menuCodigo) Then
                Throw New ArgumentException("El código del menú no puede estar vacío.")
            End If
            ModuloSistema.IniciarTransaccion()
            Dim menu As Menu = menuSQL.ObtenerMenuPorCodigo(menuCodigo)
            Dim dataTable As New DataTable()
            dataTable.Columns.Add("MenuCodigo", GetType(String))
            dataTable.Columns.Add("MenuNombre", GetType(String))
            dataTable.Columns.Add("MenuDescripcion", GetType(String))
            dataTable.Columns.Add("MenuPrecio", GetType(Double))
            dataTable.Columns.Add("MenuEstado", GetType(String))
            dataTable.Columns.Add("MenuFoto", GetType(Image))
            If menu IsNot Nothing Then
                Dim row As DataRow = dataTable.NewRow()
                row("MenuCodigo") = menu.MenuCodigo
                row("MenuNombre") = menu.MenuNombre
                row("MenuDescripcion") = menu.MenuDescripcion
                row("MenuPrecio") = menu.MenuPrecio
                row("MenuEstado") = menu.MenuEstado
                row("MenuFoto") = menu.MenuFoto
                dataTable.Rows.Add(row)
            End If

            ModuloSistema.TerminarTransaccion()
            Return dataTable
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw ex
        End Try
    End Function

    Public Function ActualizarMenu(menuCodigo As String, menuNombre As String, menuDescripcion As String, menuPrecio As Decimal, menuEstado As String, Optional menuFoto As Image = Nothing) As Boolean
        Try
            If String.IsNullOrWhiteSpace(menuCodigo) Then Throw New ArgumentException("El código del menú no puede estar vacío.")
            If String.IsNullOrWhiteSpace(menuNombre) Then Throw New ArgumentException("El nombre del menú no puede estar vacío.")
            If menuPrecio <= 0 Then Throw New ArgumentException("El precio del menú debe ser mayor a cero.")
            If String.IsNullOrWhiteSpace(menuEstado) Then Throw New ArgumentException("El estado del menú no puede estar vacío.")
            Dim menu As New Menu() With {
                .MenuCodigo = menuCodigo.Trim(),
                .MenuNombre = menuNombre,
                .MenuDescripcion = menuDescripcion,
                .MenuPrecio = menuPrecio,
                .MenuEstado = menuEstado,
                .MenuFoto = menuFoto
            }

            ModuloSistema.IniciarTransaccion()
            Dim resultado As Boolean = menuSQL.ActualizarMenu(menu)
            ModuloSistema.TerminarTransaccion()

            Return resultado
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw ex
        End Try
    End Function

    Public Function InsertarMenu(menuNombre As String, menuDescripcion As String, menuPrecio As Double, Optional menuFoto As Image = Nothing) As Boolean
        Try
            If String.IsNullOrWhiteSpace(menuNombre) Then
                Throw New ArgumentException("El nombre del menú no puede estar vacío.")
            End If

            If menuNombre.Length > 50 Then
                Throw New ArgumentException("El nombre del menú no puede exceder los 50 caracteres.")
            End If

            If String.IsNullOrWhiteSpace(menuDescripcion) Then
                Throw New ArgumentException("La descripción del menú no puede estar vacía.")
            End If

            If menuDescripcion.Length > 100 Then
                Throw New ArgumentException("La descripción del menú no puede exceder los 100 caracteres.")
            End If

            If menuPrecio <= 0 OrElse menuPrecio >= 1000000 Then
                Throw New ArgumentException("El precio del menú debe ser mayor a 0 y menor a 1,000,000.")
            End If

            ModuloSistema.IniciarTransaccion()
            Dim codigoMenu = codigoSQL.GenerarCodigoUnico("MEN", "Restaurante.Menu", "MenuCodigo")
            Dim menu As New Menu With {
                .MenuCodigo = codigoMenu,
                .MenuNombre = menuNombre.Trim(),
                .MenuDescripcion = menuDescripcion.Trim(),
                .MenuPrecio = Math.Round(menuPrecio, 2),
                .MenuFoto = menuFoto
            }
            Dim result As Boolean = menuSQL.InsertarMenu(menu)
            ModuloSistema.TerminarTransaccion()
            Return result

        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw New Exception("Error al insertar el menú: " & ex.Message)
        End Try
    End Function


    Public Function GenerarCodigoUnicoMenu() As String
        Try
            ModuloSistema.IniciarTransaccion()
            Dim result = codigoSQL.GenerarCodigoUnico("MEN", "Restaurante.Menu", "MenuCodigo")
            ModuloSistema.TerminarTransaccion()
            Return result
        Catch ex As Exception
            ModuloSistema.CancelarTransaccion()
            Throw ex
        End Try
    End Function

    'proceso para eliminar un menu
    Public Function ELiminarMenu(menuCodigo As String) As Boolean
        Try
            ModuloSistema.IniciarTransaccion()
            Dim menu As Menu = menuSQL.ObtenerMenuPorCodigo(menuCodigo)
            If menu Is Nothing Then
                Throw New Exception("No se encontró el menú con el código especificado.")
            End If
            menu.MenuEstado = "A"
            Dim result As Boolean = menuSQL.ActualizarMenu(menu)
            ModuloSistema.TerminarTransaccion()
            Return result
        Catch ex As Exception
            Throw ex
            ModuloSistema.CancelarTransaccion()
        End Try
    End Function

End Class
