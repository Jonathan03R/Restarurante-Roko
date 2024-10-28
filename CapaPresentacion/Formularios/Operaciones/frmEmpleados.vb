Public Class frmEmpleados
    Private gestionarEmpleadoServicios As New ProcesoGestionarEmpleadosServicios()

    Private Sub frmEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarEmpleados()
        CargarRoles()
        btnsave.Enabled = False
        btnupdate.Enabled = False
        btndelete.Enabled = False
    End Sub

    Private Sub CargarRoles()
        Try
            Dim dtRoles As DataTable = gestionarEmpleadoServicios.ObtenerRolesActivosComoDataTable()

            comboRoles.DataSource = dtRoles
            comboRoles.DisplayMember = "RolesPermisosNombreRol"
            comboRoles.ValueMember = "RolesPermisosCodigo"

        Catch ex As Exception
            MessageBox.Show("Error al cargar los roles activos: " & ex.Message)
        End Try
    End Sub

    Private Sub tabla_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tabla.CellClick
        If e.RowIndex >= 0 Then
            Dim filaSeleccionada As DataGridViewRow = tabla.Rows(e.RowIndex)
            txtcodigo.Text = filaSeleccionada.Cells("EmpleadosCodigo").Value.ToString()
            txtApellidoPaterno.Text = filaSeleccionada.Cells("EmpleadosPaterno").Value.ToString()
            txtApellidoMaterno.Text = filaSeleccionada.Cells("EmpleadosMaterno").Value.ToString()
            txtnombres.Text = filaSeleccionada.Cells("EmpleadosNombres").Value.ToString()
            txttelefono.Text = filaSeleccionada.Cells("EmpleadosTelefono").Value.ToString()
            comboSexo.SelectedItem = filaSeleccionada.Cells("EmpleadosSexo").Value.ToString()
            Dim rolSeleccionado As String = filaSeleccionada.Cells("RolesPermisosNombreRol").Value.ToString()
            Dim index As Integer = comboRoles.FindStringExact(rolSeleccionado)
            If index >= 0 Then
                comboRoles.SelectedIndex = index
            Else
                comboRoles.SelectedIndex = -1
            End If
            txtentrada.Text = filaSeleccionada.Cells("EmpleadosHoraEntreada").Value.ToString()
            dateContratacion.Value = Convert.ToDateTime(filaSeleccionada.Cells("EmpleadosFechaContratacion").Value)
            txtsalario.Text = filaSeleccionada.Cells("EmpleadosSalario").Value.ToString()

            ' Ajustar botones
            btnsave.Enabled = False
            btnupdate.Enabled = True
            btndelete.Enabled = True
        End If
    End Sub


    Private Sub CargarEmpleados()
        tabla.AutoGenerateColumns = False
        Dim empleadosLista As DataTable = gestionarEmpleadoServicios.obtenerEmpleadoActivos()
        tabla.DataSource = empleadosLista
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Try
            Dim rolCodigoSeleccionado As String = comboRoles.SelectedValue.ToString()

            If String.IsNullOrEmpty(rolCodigoSeleccionado) Then
                MessageBox.Show("Seleccione un rol válido para el empleado." & rolCodigoSeleccionado, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            gestionarEmpleadoServicios.actualizarEmpleado(
            EmpleadosCodigo:=txtcodigo.Text,
            EmpleadosRolesPermisosCodigo:=rolCodigoSeleccionado,
            EmpleadosPaterno:=txtApellidoPaterno.Text,
            EmpleadosMaterno:=txtApellidoMaterno.Text,
            EmpleadosNombres:=txtnombres.Text,
            EmpleadosTelefono:=txttelefono.Text,
            EmpleadosSexo:=comboSexo.SelectedItem.ToString(),
            EmpleadosHoraEntrada:=txtentrada.Text,
            EmpleadosSalario:=Convert.ToDouble(txtsalario.Text)
        )

            MessageBox.Show("Empleado actualizado correctamente.", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CargarEmpleados()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            Dim rolCodigoSeleccionado As String = comboRoles.SelectedValue.ToString()

            If String.IsNullOrEmpty(rolCodigoSeleccionado) Then
                MessageBox.Show("Seleccione un rol válido para el empleado." & rolCodigoSeleccionado, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            gestionarEmpleadoServicios.crearNuevoEmpleado(
            rolCodigoSeleccionado,
            txtApellidoPaterno.Text,
            txtApellidoMaterno.Text,
            txtnombres.Text,
            txttelefono.Text,
            comboSexo.SelectedItem.ToString(),
            txtentrada.Text,
            Convert.ToDouble(txtsalario.Text)
        )

            MessageBox.Show("Empleado insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CargarEmpleados()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGenerarCodigo_Click(sender As Object, e As EventArgs) Handles btnGenerarCodigo.Click
        Try
            btnsave.Enabled = True
            btnupdate.Enabled = False
            btndelete.Enabled = False
            Dim nuevoCodigo As String = gestionarEmpleadoServicios.GenerarCodigoUnicoEmpleado()
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
        If tabla.SelectedRows.Count > 0 Then
            Dim empleadoCodigo As String = tabla.SelectedRows(0).Cells("EmpleadosCodigo").Value.ToString()

            Dim confirmacion As DialogResult = MessageBox.Show("¿Estás seguro de eliminar este emplado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If confirmacion = DialogResult.Yes Then
                Try
                    If gestionarEmpleadoServicios.CambiarEstadoInactivoEmpleado(empleadoCodigo) Then
                        MessageBox.Show("Empleado: " + empleadoCodigo + " a sido eliminado correctamente.", "Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CargarEmpleados()
                    Else
                        MessageBox.Show("No se pudo eliminar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Por favor, selecciona un empleado para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class
