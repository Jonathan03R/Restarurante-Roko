Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmMenuEliminados
    'Private menuNegocio As New MenuNegocio()
    Private procesoGestionarMenu As New ProcesoGestionarMenuServicio()

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
            Dim dataTable As DataTable = procesoGestionarMenu.MostrarMenu()

            lvMenu.Items.Clear()

            For Each row As DataRow In dataTable.Rows
                If row("MenuEstado").ToString() = "E" Then
                    Dim item As New ListViewItem(row("MenuCodigo").ToString().Trim())
                    item.SubItems.Add(row("MenuNombre").ToString())
                    item.SubItems.Add(row("MenuDescripcion").ToString())
                    item.SubItems.Add(Convert.ToDouble(row("MenuPrecio")).ToString("F2")) ' Formato de precio
                    item.SubItems.Add("Eliminado")

                    ' Agregar el elemento al ListView
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
            Dim result As Boolean = procesoGestionarMenu.ELiminarMenu(menuCodigo)
            If result Then
                MessageBox.Show("El menú ha sido recuperado correctamente y ahora está activo.")
            End If

            CargarListaMenuEliminado()
        Catch ex As Exception
            MessageBox.Show("Error al recuperar el menú: " & ex.Message)
        End Try
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub
End Class
