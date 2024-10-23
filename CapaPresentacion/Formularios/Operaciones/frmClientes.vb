Public Class frmClientes
    Dim clienteNegocio As New ClienteNegocio()
    Dim listaClientes As List(Of Cliente)

    Private Sub frmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarClientes()

        txtdni.Enabled = False
        datefecha.Value = DateTime.Now
        btnGuardar.Enabled = False
    End Sub

    Private Sub CargarClientes()
        listaClientes = clienteNegocio.ObtenerClientesActivos()
        LlenarGridClientes()
    End Sub

    Private Sub LlenarGridClientes()
        tabla.Rows.Clear()

        For Each cliente As Cliente In listaClientes
            Dim numeroDeReservas As Integer = If(cliente.Reservas IsNot Nothing, cliente.Reservas.Count, 0)

            Dim row As String() = New String() {
                cliente.ClientesCodigo,
                numeroDeReservas.ToString(), ' Número de reservas
                cliente.ClientesNombre,
                cliente.ClientesApellidos,
                cliente.ClientesTelefono,
                cliente.ClientesDNI,
                cliente.ClientesCorreo,
                cliente.ClientesFechaRegistro.ToString("dd/MM/yyyy")
            }

            tabla.Rows.Add(row)
        Next
    End Sub

    ' Evento cuando seleccionas una fila del DataGridView de clientes
    Private Sub tabla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tabla.CellClick
        If e.RowIndex >= 0 Then
            Dim filaSeleccionada As DataGridViewRow = tabla.Rows(e.RowIndex)

            ' Llenar los campos de texto con los datos del cliente
            txtcodigo.Text = filaSeleccionada.Cells(0).Value.ToString()
            txtnombres.Text = filaSeleccionada.Cells(2).Value.ToString()
            txtapellidos.Text = filaSeleccionada.Cells(3).Value.ToString()
            txttelefono.Text = filaSeleccionada.Cells(4).Value.ToString()
            txtdni.Text = filaSeleccionada.Cells(5).Value.ToString()
            txtcorreo.Text = filaSeleccionada.Cells(6).Value.ToString()

            Dim fechaRegistro As Date = Convert.ToDateTime(filaSeleccionada.Cells(7).Value)
            datefecha.Value = fechaRegistro

            Dim clienteCodigo As String = filaSeleccionada.Cells(0).Value.ToString()
            Dim reservas As List(Of MesaReserva) = clienteNegocio.ObtenerReservasPorCliente(clienteCodigo)

            LlenarGridReservas(reservas)
            txtdni.Enabled = False
            btnGuardar.Enabled = False
            btnActualizar.Enabled = True
            btndelete.Enabled = True

        End If
    End Sub

    ' Método para llenar el DataGridView de Reservas
    Private Sub LlenarGridReservas(reservas As List(Of MesaReserva))
        tablaReservas.Rows.Clear()

        For Each reserva As MesaReserva In reservas
            Dim row As String() = New String() {
                reserva.ReservasCodigo,
                reserva.ReservasFechaHoraReserva.ToString("dd/MM/yyyy"),
                reserva.ReservasEstado,
                reserva.ReservasMesasCodigo
            }

            tablaReservas.Rows.Add(row)
        Next
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim clienteActualizado As New Cliente With {
            .ClientesCodigo = txtcodigo.Text,
            .ClientesNombre = txtnombres.Text,
            .ClientesApellidos = txtapellidos.Text,
            .ClientesTelefono = txttelefono.Text,
            .ClientesCorreo = txtcorreo.Text
        }

        Try
            ' Llamamos a la capa de negocio para actualizar el cliente
            If clienteNegocio.ActualizarCliente(clienteActualizado) Then
                MessageBox.Show("Cliente actualizado correctamente.", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CargarClientes()
            Else
                MessageBox.Show("No se pudo actualizar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If tabla.SelectedRows.Count > 0 Then
            Dim clienteCodigo As String = tabla.SelectedRows(0).Cells(0).Value.ToString()

            Dim clienteAEliminar As New Cliente With {
                .ClientesCodigo = clienteCodigo
            }

            Dim confirmacion As DialogResult = MessageBox.Show("¿Estás seguro de eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If confirmacion = DialogResult.Yes Then
                Try
                    If clienteNegocio.EliminarCliente(clienteAEliminar) Then
                        MessageBox.Show("Cliente eliminado correctamente.", "Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CargarClientes()
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
            Dim nuevoCodigo As String = clienteNegocio.GenerarCodigoUnicoCliente()
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
            Dim nuevoCliente As New Cliente With {
                .ClientesCodigo = txtcodigo.Text,
                .ClientesNombre = txtnombres.Text,
                .ClientesApellidos = txtapellidos.Text,
                .ClientesTelefono = txttelefono.Text,
                .ClientesDNI = txtdni.Text,
                .ClientesCorreo = txtcorreo.Text
            }

            If clienteNegocio.InsertarCliente(nuevoCliente) Then
                MessageBox.Show("Cliente insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiarCampos()
                LlenarGridClientes()
                CargarClientes()
            Else
                MessageBox.Show("No se pudo insertar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class
