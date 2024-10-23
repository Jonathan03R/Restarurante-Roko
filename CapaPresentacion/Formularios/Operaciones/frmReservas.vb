Public Class frmReservas

    ' Instancias de las capas de negocio para gestionar clientes, mesas y reservas
    Dim clienteNegocio As New ClienteNegocio()
    Dim mesaNegocio As New MesaNegocio()
    Dim reservaNegocio As New ReservaNegocio()

    ' Control de formulario cargado y lista de reservas
    Private formularioCargado As Boolean = False
    Private listaReservas As List(Of MesaReserva)

    ' Variable para almacenar el estado seleccionado
    Private estadosSeleccionados As String



#Region "Carga de Datos"

    ' Método para cargar la lista de clientes en el DataGridView de clientes
    Private Sub CargarClientes(Optional textoBusqueda As String = "")
        Dim clientesFiltrados As List(Of Cliente) = clienteNegocio.BuscarClientesPorNombre(textoBusqueda)
        dgvClientes.Rows.Clear()
        For Each cliente As Cliente In clientesFiltrados
            Dim row As String() = {
                cliente.ClientesCodigo,
                cliente.ClientesNombreCompleto
            }
            dgvClientes.Rows.Add(row)
        Next
    End Sub

    ' Método para cargar la lista de reservas en el DataGridView principal
    Private Sub CargarReservas(Optional estados As String = Nothing)
        listaReservas = reservaNegocio.ObtenerReservas(estados)
        tabla.Rows.Clear()

        For Each reserva As MesaReserva In listaReservas
            Dim row As String() = {
            reserva.ReservasCodigo,
            reserva.Cliente.ClientesNombreCompleto,
            reserva.Mesa.MesasCapacidad.ToString(),
            reserva.ReservasEstado,
            reserva.ReservasFechaHoraReserva.ToString("dd/MM/yyyy"),
            reserva.ReservasFechaHoraReserva.ToString("HH:mm")
        }
            tabla.Rows.Add(row)
        Next
    End Sub

    ' Método para cargar las mesas disponibles en el ComboBox
    Private Sub CargarMesas(Optional estadoMesas As String = Nothing)
        Dim listaMesas As List(Of Mesa) = mesaNegocio.ObtenerMesas()

        comboMesas.DataSource = listaMesas
        comboMesas.DisplayMember = "MesasCapacidad"
        comboMesas.ValueMember = "MesasCodigo"
    End Sub

#End Region

#Region "Eventos de Formulario"

    ' Método que se ejecuta al cargar el formulario, inicializa datos
    Private Sub frmReservas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarClientes()
        CargarReservas(estadosSeleccionados)
        CargarMesas("V")
        formularioCargado = True
        chkActivo.Checked = True
        labelEstado.Visible = False
        combEstadoReserva.Visible = False
        btnsave.Enabled = False
        btnactualizar.Enabled = False
        combEstadoReserva.Items.Clear()
        combEstadoReserva.Items.Add("Activo")
        combEstadoReserva.Items.Add("Cancelado")
        combEstadoReserva.Items.Add("Pendiente")
        combEstadoReserva.Items.Add("Expirada")
        combEstadoReserva.Items.Add("Finalizada")

    End Sub

    ' Evento que maneja la búsqueda de clientes a medida que se escribe en el TextBox de búsqueda
    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Dim textoBusqueda As String = txtBuscar.Text
        CargarClientes(textoBusqueda)
    End Sub

    ' Evento que maneja la selección de un cliente en el DataGridView de clientes
    Private Sub dgvClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellClick
        If e.RowIndex >= 0 Then
            Dim filaSeleccionada As DataGridViewRow = dgvClientes.Rows(e.RowIndex)
            txtcliente.Text = filaSeleccionada.Cells(0).Value.ToString()
        End If
    End Sub

    ' Evento que maneja la selección de un ítem en el ComboBox de mesas
    Private Sub comboMesas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboMesas.SelectedIndexChanged
        If formularioCargado AndAlso comboMesas.SelectedValue IsNot Nothing Then
            Dim codigoMesaSeleccionada As String = comboMesas.SelectedValue.ToString()
            MessageBox.Show("Mesa seleccionada: " & codigoMesaSeleccionada)
        End If
    End Sub

    ' Evento que genera un nuevo código único de reserva cuando se presiona el botón "Generar"
    Private Sub btnGenerarCodigo_Click(sender As Object, e As EventArgs) Handles btnGenerarCodigo.Click
        Try
            Dim nuevoCodigo As String = reservaNegocio.GenerarCodigoUnicoReserva()
            txtcodigo.Text = nuevoCodigo
        Catch ex As Exception
            MessageBox.Show("Error al generar el código del empleado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        btnsave.Enabled = True
        btnactualizar.Enabled = False
        labelEstado.Visible = False
        combEstadoReserva.Visible = False
    End Sub

    ' Evento que guarda la reserva cuando se presiona el botón "Guardar"
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            Dim fechaHoraReserva As DateTime = datefecha.Value.Date + dateTime.Value.TimeOfDay
            Dim nuevaReserva As New MesaReserva With {
                .ReservasCodigo = txtcodigo.Text,
                .ReservasClientesCodigo = txtcliente.Text,
                .ReservasMesasCodigo = comboMesas.SelectedValue.ToString(),
                .ReservasFechaHoraReserva = fechaHoraReserva
            }

            If reservaNegocio.InsertarReserva(nuevaReserva) Then
                MessageBox.Show("Reserva insertada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarCampos()
                CargarReservas(estadosSeleccionados)
                CargarMesas("V")
            Else
                MessageBox.Show("No se pudo insertar la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Evento que maneja la selección de una reserva en el DataGridView principal
    Private Sub tabla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tabla.CellClick
        If e.RowIndex >= 0 Then
            Dim reservaSeleccionada As MesaReserva = listaReservas(e.RowIndex)
            txtcodigo.Text = reservaSeleccionada.ReservasCodigo
            txtcliente.Text = reservaSeleccionada.ReservasClientesCodigo
            Dim codigoMesaSeleccionada As String = reservaSeleccionada.ReservasMesasCodigo
            If Not String.IsNullOrEmpty(codigoMesaSeleccionada) Then
                comboMesas.SelectedValue = codigoMesaSeleccionada
            Else
                MessageBox.Show("El código de la mesa es nulo o vacío.")
            End If
            datefecha.Value = reservaSeleccionada.ReservasFechaHoraReserva.Date
            dateTime.Value = reservaSeleccionada.ReservasFechaHoraReserva
            combEstadoReserva.SelectedItem = reservaSeleccionada.ReservasEstado
            btnsave.Enabled = False
            btnactualizar.Enabled = True
            labelEstado.Visible = True
            combEstadoReserva.Visible = True
        End If
    End Sub

    ' Evento que actualiza la reserva cuando se presiona el botón "Actualizar"
    Private Sub btnactualizar_Click(sender As Object, e As EventArgs) Handles btnactualizar.Click
        Try
            Dim fechaHoraReserva As DateTime = datefecha.Value.Date + dateTime.Value.TimeOfDay
            Dim reservaActualizada As New MesaReserva With {
                .ReservasCodigo = txtcodigo.Text,
                .ReservasMesasCodigo = If(comboMesas.SelectedValue IsNot Nothing, comboMesas.SelectedValue.ToString(), Nothing),
                .ReservasFechaHoraReserva = fechaHoraReserva
            }
            Dim estadoSeleccionado As String = combEstadoReserva.SelectedItem.ToString()
            reservaActualizada.ReservasEstado = estadoSeleccionado.ToLower()

            If reservaNegocio.ActualizarReserva(reservaActualizada) Then
                MessageBox.Show("Reserva actualizada correctamente.", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CargarReservas(estadosSeleccionados)
                CargarMesas("V")
            Else
                MessageBox.Show("No se pudo actualizar la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EstadoCheckBoxChanged(sender As Object, e As EventArgs) Handles chkActivo.CheckedChanged, chkCancelado.CheckedChanged, chkPendiente.CheckedChanged, chkExpirada.CheckedChanged
        Dim estados As New List(Of String)

        If chkActivo.Checked Then
            estados.Add("A")
        End If
        If chkCancelado.Checked Then
            estados.Add("C")
        End If
        If chkPendiente.Checked Then
            estados.Add("P")
        End If
        If chkExpirada.Checked Then
            estados.Add("E")
        End If
        If chkFinalizada.Checked Then
            estados.Add("F")
        End If

        estadosSeleccionados = String.Join(",", estados)

        CargarReservas(estadosSeleccionados)
    End Sub

#End Region

#Region "Métodos Auxiliares"

    ' Método para limpiar los campos del formulario
    Private Sub LimpiarCampos()
        txtcodigo.Clear()
        txtcliente.Clear()
        comboMesas.SelectedIndex = -1
        datefecha.Value = Date.Now
    End Sub

    ' Método para obtener el código del cliente a partir de su nombre completo
    Public Function ObtenerCodigoClientePorNombre(nombreCompleto As String) As String
        Dim listaClientes As List(Of Cliente) = clienteNegocio.ObtenerClientesActivos()
        Dim clienteEncontrado = listaClientes.FirstOrDefault(Function(c) c.ClientesNombreCompleto = nombreCompleto)
        If clienteEncontrado IsNot Nothing Then
            Return clienteEncontrado.ClientesCodigo
        Else
            Return String.Empty
        End If
    End Function

#End Region

    ' Botón para abrir el formulario de clientes
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frmClientes As New frmClientes
        frmClientes.ShowDialog()
    End Sub
End Class
