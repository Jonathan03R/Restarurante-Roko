Public Class frmGraficaMesas
    Private listaMesas As List(Of Mesa)
    Dim mesaNegocio As New MesaNegocio()

    ' Método que carga las mesas gráficamente
    Private Sub frmGraficaMesas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarMesasGraficamente()
    End Sub

    ' Cargar las mesas gráficamente y asignarles el estado correspondiente
    Private Sub cargarMesasGraficamente()
        listaMesas = mesaNegocio.ObtenerMesas()
        FlowLayoutPanel1.Controls.Clear()

        For Each mesa In listaMesas
            Dim btnMesa As New Button()
            btnMesa.Width = 100
            btnMesa.Height = 100
            btnMesa.Text = mesa.MesasCodigo

            ' Cambiar el color del botón según el estado de la mesa
            Select Case mesa.MesasEstado
                Case "Vacío"
                    btnMesa.BackColor = Color.Green
                Case "Reservado"
                    btnMesa.BackColor = Color.Orange
                Case "Ocupado"
                    btnMesa.BackColor = Color.Red
            End Select

            ' Añadir el evento Click para cada botón
            AddHandler btnMesa.Click, AddressOf btnMesa_Click

            FlowLayoutPanel1.Controls.Add(btnMesa)
        Next
    End Sub

    Private Sub btnMesa_Click(sender As Object, e As EventArgs)
        Dim btnMesa As Button = CType(sender, Button)
        Dim mesaSeleccionada = listaMesas.FirstOrDefault(Function(mesa) mesa.MesasCodigo = btnMesa.Text)

        If mesaSeleccionada.MesasEstado = "Vacío" Then
            Dim frmPedidos As New frmPedidos()
            frmPedidos.MesaCodigo = btnMesa.Text
            frmPedidos.ShowDialog()

        ElseIf mesaSeleccionada.MesasEstado = "Ocupado" Then

            Dim frmGestionarPedido As New frmGestionarPedido()
            frmGestionarPedido.MesaCodigo = btnMesa.Text
            frmGestionarPedido.ShowDialog()

        End If

        cargarMesasGraficamente()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frmMesas As New frmMesas
        frmMesas.ShowDialog()
    End Sub
End Class
