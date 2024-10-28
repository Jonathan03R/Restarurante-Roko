Imports System.Data.SqlClient
Imports System.IO

Public Class frmMenu
    Private procesoGestionarMenu As New ProcesoGestionarMenuServicio()
    Private Sub frmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarListaMenu()
        btnActualizar.Enabled = False

        picMenuFoto.SizeMode = PictureBoxSizeMode.StretchImage

    End Sub

    Private Sub CargarListaMenu()
        Try
            Dim dtMenu As DataTable = procesoGestionarMenu.MostrarMenu()

            Dim dtFiltrado As New DataTable()
            dtFiltrado.Columns.Add("MenuCodigo", GetType(String))
            dtFiltrado.Columns.Add("MenuNombre", GetType(String))
            dtFiltrado.Columns.Add("MenuDescripcion", GetType(String))
            dtFiltrado.Columns.Add("MenuPrecio", GetType(Double))
            dtFiltrado.Columns.Add("MenuEstado", GetType(String))

            For Each row As DataRow In dtMenu.Rows
                If row("MenuEstado").ToString() = "A" Then
                    dtFiltrado.Rows.Add(row("MenuCodigo").ToString().Trim(), row("MenuNombre"), row("MenuDescripcion"), row("MenuPrecio"), "Activo")
                End If
            Next

            ' Asignar el DataTable filtrado al DataGridView
            dgvMenu.DataSource = dtFiltrado
            dgvMenu.Columns("MenuCodigo").Visible = False
        Catch ex As Exception
            MessageBox.Show("Error al cargar la lista de menús: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvMenu_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMenu.CellClick
        Try
            If e.RowIndex >= 0 Then
                Dim menuCodigo As String = dgvMenu.Rows(e.RowIndex).Cells("MenuCodigo").Value.ToString().Trim()
                Dim menuSeleccionado As DataTable = procesoGestionarMenu.ObtenerMenuPorCodigoComoDataTable(menuCodigo)
                If menuSeleccionado IsNot Nothing AndAlso menuSeleccionado.Rows.Count > 0 Then
                    Dim row As DataRow = menuSeleccionado.Rows(0) ' Tomar la primera fila
                    txtMenuCodigo.Text = row("MenuCodigo").ToString().Trim()
                    txtMenuNombre.Text = row("MenuNombre").ToString()
                    txtMenuDescripcion.Text = row("MenuDescripcion").ToString()
                    txtMenuPrecio.Text = Convert.ToDouble(row("MenuPrecio")).ToString("F2")

                    If Not IsDBNull(row("MenuFoto")) Then
                        picMenuFoto.Image = CType(row("MenuFoto"), Image)
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
            Dim menuCodigo As String = txtMenuCodigo.Text.Trim()
            Dim menuNombre As String = txtMenuNombre.Text.Trim()
            Dim menuDescripcion As String = txtMenuDescripcion.Text.Trim()
            Dim menuPrecio As Double = Convert.ToDouble(txtMenuPrecio.Text.Trim())
            Dim menuEstado As String = "A"
            Dim menuFoto As Image = If(picMenuFoto.Image IsNot Nothing, picMenuFoto.Image, Nothing)

            If procesoGestionarMenu.ActualizarMenu(menuCodigo, menuNombre, menuDescripcion, menuPrecio, menuEstado, menuFoto) Then
                MessageBox.Show("Menú actualizado correctamente.")
                CargarListaMenu()
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
        ' Validaciones de entrada
        Dim menuNombre As String = txtMenuNombre.Text.Trim()
        Dim menuDescripcion As String = txtMenuDescripcion.Text.Trim()
        Dim menuPrecio As Double

        If String.IsNullOrEmpty(menuNombre) Then
            MessageBox.Show("Debe ingresar un nombre para el menú.")
            Return
        End If

        If String.IsNullOrEmpty(menuDescripcion) Then
            MessageBox.Show("Debe ingresar una descripción para el menú.")
            Return
        End If

        If Not Double.TryParse(txtMenuPrecio.Text.Trim(), menuPrecio) OrElse menuPrecio <= 0 Then
            MessageBox.Show("Debe ingresar un precio válido para el menú.")
            Return
        End If

        Dim menuFoto As Image = If(picMenuFoto.Image IsNot Nothing, picMenuFoto.Image, Nothing)
        If procesoGestionarMenu.InsertarMenu(menuNombre, menuDescripcion, menuPrecio, menuFoto) Then
            MessageBox.Show("Menú insertado correctamente.")
            CargarListaMenu()
            LimpiarFormulario()
        Else
            MessageBox.Show("No se pudo insertar el menú.")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtMenuCodigo.Text = procesoGestionarMenu.GenerarCodigoUnicoMenu()
        btnGuardar.Enabled = True
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If String.IsNullOrEmpty(txtMenuCodigo.Text.Trim()) Then
                MessageBox.Show("Debe seleccionar un menú para eliminar.")
                Return
            End If

            Dim resultado As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este menú?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If resultado = DialogResult.Yes Then
                Dim menuCodigo As String = txtMenuCodigo.Text.Trim()
                Dim menuNombre As String = txtMenuNombre.Text.Trim()
                Dim menuDescripcion As String = txtMenuDescripcion.Text.Trim()
                Dim menuPrecio As Decimal = Convert.ToDecimal(txtMenuPrecio.Text.Trim())
                Dim menuEstado As String = "E" ' Cambiar el estado a 'E' para marcarlo como eliminado
                Dim menuFoto As Image = If(picMenuFoto.Image IsNot Nothing, picMenuFoto.Image, Nothing)

                If procesoGestionarMenu.ActualizarMenu(menuCodigo, menuNombre, menuDescripcion, menuPrecio, menuEstado, menuFoto) Then
                    MessageBox.Show("Menú eliminado correctamente (estado cambiado a 'E').")
                    CargarListaMenu()
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
