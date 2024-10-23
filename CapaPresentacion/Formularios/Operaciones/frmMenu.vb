Imports System.Data.SqlClient
Imports System.IO

Public Class frmMenu
    Private menuNegocio As New MenuNegocio()

    ' Cargar la lista de menús al cargar el formulario
    Private Sub frmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarListaMenu()
        btnActualizar.Enabled = False

        picMenuFoto.SizeMode = PictureBoxSizeMode.StretchImage

    End Sub

    Private Sub CargarListaMenu()
        Try
            Dim listaMenu As List(Of Menu) = menuNegocio.ObtenerMenu()

            Dim dt As New DataTable()
            dt.Columns.Add("MenuCodigo", GetType(String))
            dt.Columns.Add("MenuNombre", GetType(String))
            dt.Columns.Add("MenuDescripcion", GetType(String))
            dt.Columns.Add("MenuPrecio", GetType(Double))
            dt.Columns.Add("MenuEstado", GetType(String))

            For Each menuItem As Menu In listaMenu
                If menuItem.MenuEstado = "A" Then
                    Dim estadoTexto As String = "Activo"
                    dt.Rows.Add(menuItem.MenuCodigo.Trim(), menuItem.MenuNombre, menuItem.MenuDescripcion, menuItem.MenuPrecio, estadoTexto)
                End If
            Next
            dgvMenu.DataSource = dt
            dgvMenu.Columns("MenuCodigo").Visible = False
        Catch ex As Exception
            MessageBox.Show("Error al cargar la lista de menús: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvMenu_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMenu.CellClick
        Try
            If e.RowIndex >= 0 Then
                Dim menuCodigo As String = dgvMenu.Rows(e.RowIndex).Cells("MenuCodigo").Value.ToString().Trim()

                Dim menuSeleccionado As Menu = menuNegocio.ObtenerMenuPorCodigo(menuCodigo)

                If menuSeleccionado IsNot Nothing Then
                    txtMenuCodigo.Text = menuSeleccionado.MenuCodigo.Trim()
                    txtMenuNombre.Text = menuSeleccionado.MenuNombre
                    txtMenuDescripcion.Text = menuSeleccionado.MenuDescripcion
                    txtMenuPrecio.Text = menuSeleccionado.MenuPrecio.ToString("F2")

                    If menuSeleccionado.MenuFoto IsNot Nothing Then
                        picMenuFoto.Image = menuSeleccionado.MenuFoto
                    Else
                        picMenuFoto.Image = Nothing
                    End If


                    btnActualizar.Enabled = True
                    btnGuardar.Enabled = False
                Else
                    MessageBox.Show("No se encontró el menú seleccionado.")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error al seleccionar el menú: " & ex.Message)
        End Try

    End Sub

    ' Evento Click del botón Actualizar
    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            ' Crear un objeto Menu con los datos actualizados
            Dim menu As New Menu()
            menu.MenuCodigo = txtMenuCodigo.Text.Trim()
            menu.MenuNombre = txtMenuNombre.Text.Trim()
            menu.MenuDescripcion = txtMenuDescripcion.Text.Trim()
            menu.MenuPrecio = Convert.ToDouble(txtMenuPrecio.Text.Trim())
            menu.MenuEstado = "A" ' Asumiendo que deseas mantener el estado como 'A' (Activo)

            ' Manejar la imagen
            If picMenuFoto.Image IsNot Nothing Then
                menu.MenuFoto = picMenuFoto.Image
            Else
                menu.MenuFoto = Nothing
            End If

            ' Llamar al método de negocio para actualizar el menú
            If menuNegocio.ActualizarMenu(menu) Then
                MessageBox.Show("Menú actualizado correctamente.")
                ' Recargar la lista de menús
                CargarListaMenu()
                ' Limpiar los controles
                LimpiarFormulario()
            Else
                MessageBox.Show("No se pudo actualizar el menú.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al actualizar el menú: " & ex.Message)
        End Try
    End Sub

    ' Método para limpiar los controles del formulario
    Private Sub LimpiarFormulario()
        txtMenuCodigo.Text = ""
        txtMenuNombre.Text = ""
        txtMenuDescripcion.Text = ""
        txtMenuPrecio.Text = ""
        picMenuFoto.Image = Nothing
        btnActualizar.Enabled = False
    End Sub

    Private Sub btnCargarImagen_Click(sender As Object, e As EventArgs) Handles btnCargarImagen.Click
        Try
            Dim openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                picMenuFoto.Image = Image.FromFile(openFileDialog.FileName)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar la imagen: " & ex.Message)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If String.IsNullOrEmpty(txtMenuCodigo.Text.Trim()) Then
                MessageBox.Show("Debe ingresar un código para el menú.")
                Return
            End If
            Dim menu As New Menu()
            menu.MenuCodigo = txtMenuCodigo.Text.Trim()
            menu.MenuNombre = txtMenuNombre.Text.Trim()
            menu.MenuDescripcion = txtMenuDescripcion.Text.Trim()
            menu.MenuPrecio = Convert.ToDouble(txtMenuPrecio.Text.Trim())
            menu.MenuEstado = "A"
            If picMenuFoto.Image IsNot Nothing Then
                menu.MenuFoto = picMenuFoto.Image
            Else
                menu.MenuFoto = Nothing
            End If

            If menuNegocio.InsertarMenu(menu) Then
                MessageBox.Show("Menú insertado correctamente.")
                CargarListaMenu()
                LimpiarFormulario()
            Else
                MessageBox.Show("No se pudo insertar el menú.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al insertar el menú: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtMenuCodigo.Text = menuNegocio.GenerarCodigoUnicoMenu()
        btnGuardar.Enabled = True
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            ' Verificar que el campo del código del menú no esté vacío
            If String.IsNullOrEmpty(txtMenuCodigo.Text.Trim()) Then
                MessageBox.Show("Debe seleccionar un menú para eliminar.")
                Return
            End If

            ' Confirmar la eliminación del menú
            Dim resultado As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este menú?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If resultado = DialogResult.Yes Then
                ' Crear un objeto Menu con los datos del menú seleccionado
                Dim menu As New Menu()
                menu.MenuCodigo = txtMenuCodigo.Text.Trim()
                menu.MenuNombre = txtMenuNombre.Text.Trim()
                menu.MenuDescripcion = txtMenuDescripcion.Text.Trim()
                menu.MenuPrecio = Convert.ToDouble(txtMenuPrecio.Text.Trim())
                menu.MenuEstado = "E" ' Cambiar el estado a 'E' (Eliminado)

                ' Llamar al método de negocio para actualizar el estado del menú a 'E'
                If menuNegocio.ActualizarMenu(menu) Then
                    MessageBox.Show("Menú eliminado correctamente (estado cambiado a 'E').")
                    ' Recargar la lista de menús
                    CargarListaMenu()
                    ' Limpiar los controles
                    LimpiarFormulario()
                Else
                    MessageBox.Show("No se pudo eliminar el menú.")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar el menú: " & ex.Message)
        End Try
    End Sub

    Private Sub btnMostrarEliminados_Click(sender As Object, e As EventArgs) Handles btnMostrarEliminados.Click
        Dim frm As New frmMenuEliminados()
        frm.ShowDialog()

        CargarListaMenu()
    End Sub
End Class
