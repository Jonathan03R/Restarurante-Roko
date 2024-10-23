Public Class frmEmpleadosEliminados
    Dim empleadosNegocio As New EmpleadosNegocio()
    Dim listaEmpleadosBorrados As List(Of Empleado)

    Private Sub frmEmpleadosEliminados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarEmpleadosEliminados()
    End Sub

    Private Sub CargarEmpleadosEliminados()
        listaEmpleadosBorrados = empleadosNegocio.ObtenerEmpleadosBorrados()

        lvEmpleados.Items.Clear()

        For Each empleado As Empleado In listaEmpleadosBorrados
            Dim item As New ListViewItem(empleado.EmpleadosCodigo)
            item.SubItems.Add(empleado.EmpleadosNombreCompleto)
            item.SubItems.Add(empleado.EmpleadosFechaContratacion.ToString("dd/MM/yyyy"))
            item.SubItems.Add(empleado.RolPermiso.RolesPermisosNombreRol)

            lvEmpleados.Items.Add(item)
        Next
    End Sub

    Private Sub lvEmpleados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvEmpleados.SelectedIndexChanged
        If lvEmpleados.SelectedItems.Count > 0 Then
            Dim empleadoSeleccionado As ListViewItem = lvEmpleados.SelectedItems(0)

        End If
    End Sub

    Private Sub cmdRecuperar_Click(sender As Object, e As EventArgs) Handles cmdRecuperar.Click
        If lvEmpleados.SelectedItems.Count > 0 Then
            Dim empleadosCodigo As String = lvEmpleados.SelectedItems(0).Text
            Dim resultado As DialogResult = MessageBox.Show("¿Está seguro de que desea recuperar este cliente?", "Confirmar Recuperación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If resultado = DialogResult.Yes Then
                If empleadosNegocio.RecuperarEmpleado(empleadosCodigo) Then
                    MessageBox.Show("Cliente recuperado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CargarEmpleadosEliminados()
                Else
                    MessageBox.Show("No se pudo recuperar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Por favor, seleccione un cliente para recuperar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub
End Class
