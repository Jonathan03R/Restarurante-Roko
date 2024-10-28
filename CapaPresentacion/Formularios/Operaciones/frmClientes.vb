Public Class frmClientes

    Private gestionasClientesServicios As New procesoGestionClientesServicio()

    Private Sub frmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarClientes()

        txtdni.Enabled = False
        datefecha.Value = DateTime.Now
        btnGuardar.Enabled = False
    End Sub

    Private Sub CargarClientes()

        tabla.AutoGenerateColumns = False
        Dim clientesActivos As DataTable = gestionasClientesServicios.ObtenerClientesActivosComoDataTable()
        tabla.DataSource = clientesActivos
    End Sub

    ' Evento cuando seleccionas una fila del DataGridView de clientes
    Private Sub tabla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tabla.CellClick
        If e.RowIndex >= 0 Then
            Dim filaSeleccionada As DataGridViewRow = tabla.Rows(e.RowIndex)

            ' Llenar los campos de texto con los datos del cliente
            txtcodigo.Text = filaSeleccionada.Cells("ClientesCodigo").Value.ToString()
            txtnombres.Text = filaSeleccionada.Cells("ClientesNombre").Value.ToString()
            txtapellidos.Text = filaSeleccionada.Cells("ClientesApellidos").Value.ToString()
            txttelefono.Text = filaSeleccionada.Cells("ClientesTelefono").Value.ToString()
            txtdni.Text = filaSeleccionada.Cells("ClientesDNI").Value.ToString()
            txtcorreo.Text = filaSeleccionada.Cells("ClientesCorreo").Value.ToString()

            datefecha.Value = Convert.ToDateTime(filaSeleccionada.Cells("ClientesFechaRegistro").Value)

            Dim clienteCodigo As String = filaSeleccionada.Cells("ClientesCodigo").Value.ToString()

            llenarReservas(clienteCodigo)

            'LlenarGridReservas(reservas)
            txtdni.Enabled = False
            btnGuardar.Enabled = False
            btnActualizar.Enabled = True
            btndelete.Enabled = True

        End If
    End Sub

    ' Método para llenar el DataGridView de Reservas
    Private Sub llenarReservas(clienteCodigo As String)
        tablaReservas.AutoGenerateColumns = False
        Dim reservasDeClientes As DataTable = gestionasClientesServicios.obtenerReservasPorClientes(clienteCodigo)

        tablaReservas.DataSource = reservasDeClientes
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            ' Obtenemos los valores desde los TextBox
            Dim clienteCodigo As String = txtcodigo.Text
            Dim nombre As String = txtnombres.Text
            Dim apellidos As String = txtapellidos.Text
            Dim telefono As String = txttelefono.Text
            Dim correo As String = txtcorreo.Text

            ' Llamamos a la capa de aplicación para actualizar el cliente
            Dim resultado As Boolean = gestionasClientesServicios.ActualizarCliente(clienteCodigo, nombre, apellidos, telefono, correo)

            If resultado Then
                MessageBox.Show("Cliente actualizado correctamente.", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CargarClientes() ' Refrescamos la lista de clientes después de la actualización
            Else
                MessageBox.Show("No se pudo actualizar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If tabla.SelectedRows.Count > 0 Then
            Dim clienteCodigo As String = tabla.SelectedRows(0).Cells("ClientesCodigo").Value.ToString()

            Dim confirmacion As DialogResult = MessageBox.Show("¿Estás seguro de eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If confirmacion = DialogResult.Yes Then
                Try
                    ' Llamada a la capa de negocio para eliminar el cliente
                    If gestionasClientesServicios.CambiarEstadoClienteAInactivo(clienteCodigo) Then
                        MessageBox.Show("Cliente: " + clienteCodigo + " a sido eliminado correctamente.", "Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CargarClientes() ' Recargar la lista de clientes para reflejar los cambios
                    Else
                        MessageBox.Show("No se pudo eliminar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Por favor, selecciona un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnrestore_Click(sender As Object, e As EventArgs) Handles btnrestore.Click
        Dim frmEliminados As New frmClientesEliminados()
        frmEliminados.ShowDialog()
        CargarClientes()
    End Sub

    Private Sub generarCodigo_Click(sender As Object, e As EventArgs) Handles generarCodigo.Click

        Try
            txtdni.Enabled = True
            btnActualizar.Enabled = False
            btndelete.Enabled = False
            datefecha.Value = DateTime.Now
            btnGuardar.Enabled = True
            limpiarCampos()
            Dim nuevoCodigo As String = gestionasClientesServicios.GenerarCodigoUnicoCliente()
            txtcodigo.Text = nuevoCodigo
        Catch ex As Exception
            MessageBox.Show("Error al generar el código del empleado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub limpiarCampos()
        txtdni.Clear()
        txtapellidos.Clear()
        txtcorreo.Clear()
        txtnombres.Clear()
        txttelefono.Clear()
        txtcodigo.Clear()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim resultado As Boolean = gestionasClientesServicios.AgregarNuevoCliente(
            ClienteNombre:=txtnombres.Text,
            ClienteApellido:=txtapellidos.Text,
            ClienteTelefono:=txttelefono.Text,
            ClienteDni:=txtdni.Text,
            ClienteCorreo:=txtcorreo.Text
        )


            If resultado Then
                MessageBox.Show("Cliente insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiarCampos()
                CargarClientes() 'Actualizar el DataGridView con los nuevos datos
            Else
                MessageBox.Show("No se pudo insertar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class
