Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmMenuEliminados
    Private menuNegocio As New MenuNegocio()

    Private Sub frmMenuEliminado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lvMenu.View = View.Details
        lvMenu.Columns.Clear()
        lvMenu.Columns.Add("Código", 100, HorizontalAlignment.Left)
        lvMenu.Columns.Add("Nombre", 150, HorizontalAlignment.Left)
        lvMenu.Columns.Add("Descripción", 200, HorizontalAlignment.Left)
        lvMenu.Columns.Add("Precio", 100, HorizontalAlignment.Right)

        CargarListaMenuEliminado()
    End Sub

    Private Sub CargarListaMenuEliminado()
        Try
            Dim listaMenu As List(Of Menu) = menuNegocio.ObtenerMenu()

            lvMenu.Items.Clear()

            For Each menuItem As Menu In listaMenu
                If menuItem.MenuEstado = "E" Then ' Filtrar solo los menús eliminados
                    Dim item As New ListViewItem(menuItem.MenuCodigo.Trim())
                    item.SubItems.Add(menuItem.MenuNombre)
                    item.SubItems.Add(menuItem.MenuDescripcion)
                    item.SubItems.Add(menuItem.MenuPrecio.ToString("F2")) ' Formato de precio
                    item.SubItems.Add("Eliminado")

                    lvMenu.Items.Add(item)
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Error al cargar la lista de menús eliminados: " & ex.Message)
        End Try
    End Sub

    Private Sub cmdRecuperar_Click(sender As Object, e As EventArgs) Handles cmdRecuperar.Click
        Try
            If lvMenu.SelectedItems.Count = 0 Then
                MessageBox.Show("Debe seleccionar un menú para recuperar.")
                Return
            End If
            Dim menuCodigo As String = lvMenu.SelectedItems(0).SubItems(0).Text.Trim()
            Dim menuSeleccionado As Menu = menuNegocio.ObtenerMenuPorCodigo(menuCodigo)
            If menuSeleccionado IsNot Nothing Then
                menuSeleccionado.MenuEstado = "A"
                If menuNegocio.ActualizarMenu(menuSeleccionado) Then
                    MessageBox.Show("El menú ha sido recuperado correctamente y ahora está activo.")
                    CargarListaMenuEliminado()
                Else
                    MessageBox.Show("No se pudo recuperar el menú.")
                End If
            Else
                MessageBox.Show("No se encontró el menú seleccionado.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error al recuperar el menú: " & ex.Message)
        End Try
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub
End Class
