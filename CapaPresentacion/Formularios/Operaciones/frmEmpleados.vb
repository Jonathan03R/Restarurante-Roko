Public Class frmEmpleados
    Dim empleadosNegocio As New EmpleadosNegocio()
    Dim rolesNegocio As New RolPermisoNegocio()
    Dim listaEmpleados As List(Of Empleado)
    Dim listaRoles As List(Of RolPermiso)

    Private Sub frmEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarEmpleados()
        CargarRoles()
        btnsave.Enabled = False
        btnupdate.Enabled = False
        btndelete.Enabled = False
    End Sub

    Private Sub CargarRoles()
        listaRoles = rolesNegocio.ObtenerRolesActivos()


        comboRoles.Items.Clear()


        For Each rol As RolPermiso In listaRoles
            comboRoles.Items.Add(rol.RolesPermisosNombreRol)
        Next
    End Sub

    Private Sub tabla_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tabla.CellClick
        If e.RowIndex >= 0 Then
            Dim filaSeleccionada As DataGridViewRow = tabla.Rows(e.RowIndex)
            Dim empleadoSeleccionado As Empleado = listaEmpleados(e.RowIndex)


            txtcodigo.Text = empleadoSeleccionado.EmpleadosCodigo
            txtApellidoPaterno.Text = empleadoSeleccionado.EmpleadosPaterno
            txtApellidoMaterno.Text = empleadoSeleccionado.EmpleadosMaterno
            txtnombres.Text = empleadoSeleccionado.EmpleadosNombres
            txttelefono.Text = empleadoSeleccionado.EmpleadosTelefono
            comboSexo.SelectedItem = empleadoSeleccionado.EmpleadosSexo
            comboRoles.SelectedItem = empleadoSeleccionado.RolPermiso.RolesPermisosNombreRol
            txtentrada.Text = empleadoSeleccionado.EmpleadosHoraEntreada
            dateContratacion.Value = empleadoSeleccionado.EmpleadosFechaContratacion
            txtsalario.Text = empleadoSeleccionado.EmpleadosSalario.ToString()

            btnsave.Enabled = False
            btnupdate.Enabled = True
            btndelete.Enabled = True
        End If
    End Sub

    Private Sub CargarEmpleados()
        listaEmpleados = empleadosNegocio.ObtenerEmpleadosActivos()

        tabla.Rows.Clear()

        For Each empleado As Empleado In listaEmpleados
            Dim row As String() = New String() {
                empleado.EmpleadosCodigo,
                empleado.EmpleadosNombreCompleto,
                empleado.EmpleadosTelefono,
                empleado.EmpleadosSexo,
                empleado.RolPermiso.RolesPermisosNombreRol,
                empleado.EmpleadosHoraEntreada,
                empleado.EmpleadosFechaContratacion.ToString("dd/MM/yyyy"),
                empleado.EmpleadosSalario.ToString()
            }

            tabla.Rows.Add(row)
        Next
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        ' Obtener el código del rol seleccionado
        Dim rolSeleccionado As RolPermiso = listaRoles.Find(Function(rol) rol.RolesPermisosNombreRol = comboRoles.SelectedItem.ToString())

        Dim empleadoActualizado As New Empleado With {
            .EmpleadosCodigo = txtcodigo.Text,
            .EmpleadosPaterno = txtApellidoPaterno.Text,
            .EmpleadosMaterno = txtApellidoMaterno.Text,
            .EmpleadosNombres = txtnombres.Text,
            .EmpleadosTelefono = txttelefono.Text,
            .EmpleadosSexo = comboSexo.SelectedItem.ToString(),
            .EmpleadosHoraEntreada = txtentrada.Text,
            .EmpleadosSalario = Convert.ToDouble(txtsalario.Text),
            .EmpleadosRolesPermisosCodigo = rolSeleccionado.RolesPermisosCodigo ' Asignar el código del rol
        }

        Try
            If empleadosNegocio.ActualizarEmpleado(empleadoActualizado) Then
                MessageBox.Show("Empleado actualizado correctamente.", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CargarEmpleados() ' Recargar la lista de empleados
            Else
                MessageBox.Show("No se pudo actualizar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            ' Obtener el código del rol seleccionado
            Dim rolSeleccionado As RolPermiso = listaRoles.Find(Function(rol) rol.RolesPermisosNombreRol = comboRoles.SelectedItem.ToString())

            ' Crear un nuevo empleado
            Dim nuevoEmpleado As New Empleado With {
            .EmpleadosCodigo = txtcodigo.Text,
            .EmpleadosRolesPermisosCodigo = rolSeleccionado.RolesPermisosCodigo,
            .EmpleadosPaterno = txtApellidoPaterno.Text,
            .EmpleadosMaterno = txtApellidoMaterno.Text,
            .EmpleadosNombres = txtnombres.Text,
            .EmpleadosTelefono = txttelefono.Text,
            .EmpleadosSexo = comboSexo.SelectedItem.ToString(),
            .EmpleadosHoraEntreada = txtentrada.Text,
            .EmpleadosSalario = Convert.ToDouble(txtsalario.Text)
        }

            ' Intentar insertar el nuevo empleado
            If empleadosNegocio.InsertarEmpleado(nuevoEmpleado) Then
                MessageBox.Show("Empleado insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CargarEmpleados() ' Recargar la lista de empleados
            End If

        Catch ex As Exception
            ' Mostrar un mensaje de error más comprensible
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGenerarCodigo_Click(sender As Object, e As EventArgs) Handles btnGenerarCodigo.Click
        Try
            btnsave.Enabled = True
            btnupdate.Enabled = False
            btndelete.Enabled = False
            Dim nuevoCodigo As String = empleadosNegocio.GenerarCodigoUnicoEmpleado()
            txtcodigo.Text = nuevoCodigo
        Catch ex As Exception
            MessageBox.Show("Error al generar el código del empleado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnMostrarEliminados_Click(sender As Object, e As EventArgs) Handles btnMostrarEliminados.Click
        Dim frmEmpleadosEliminados As New frmEmpleadosEliminados()
        frmEmpleadosEliminados.ShowDialog()
        CargarEmpleados()
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click

    End Sub
End Class
