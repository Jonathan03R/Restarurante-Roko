Public Class frmGraficaMesas
    'Private listaMesas As List(Of Mesa)
    'Dim mesaNegocio As New MesaNegocio()
    Dim procesarPedido As New ProcesarPedidoServicio()
    Private listaMesas As DataTable
    Private Sub frmGraficaMesas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarMesasGraficamente()
    End Sub

    ' Cargar las mesas gráficamente y asignarles el estado correspondiente
    Private Sub cargarMesasGraficamente()
        ' Obtener las mesas activas desde el servicio
        listaMesas = procesarPedido.ObtenerMesas()

        FlowLayoutPanel1.Controls.Clear()

        For Each row As DataRow In listaMesas.Rows
            Dim btnMesa As New Button() With {
                .Width = 100,
                .Height = 100,
                .Text = row("MesasCodigo").ToString()
            }

            Select Case row("MesasEstado").ToString()
                Case "V" ' Vacío
                    btnMesa.BackColor = Color.Green
                Case "R" ' Reservado
                    btnMesa.BackColor = Color.Orange
                Case "O" ' Ocupado
                    btnMesa.BackColor = Color.Red
            End Select
            AddHandler btnMesa.Click, AddressOf btnMesa_Click

            FlowLayoutPanel1.Controls.Add(btnMesa)
        Next
    End Sub

    Private Sub btnMesa_Click(sender As Object, e As EventArgs)
        Dim btnMesa As Button = CType(sender, Button)
        Dim mesaSeleccionada As DataRow = listaMesas.Select($"MesasCodigo = '{btnMesa.Text}'").FirstOrDefault()

        If mesaSeleccionada IsNot Nothing Then
            Select Case mesaSeleccionada("MesasEstado").ToString()
                Case "V" ' Vacío
                    Dim frmPedidos As New frmPedidos()
                    frmPedidos.MesaCodigo = btnMesa.Text
                    frmPedidos.ShowDialog()

                Case "O" ' Ocupado
                    Dim frmGestionarPedido As New frmGestionarPedido()
                    frmGestionarPedido.MesaCodigo = btnMesa.Text
                    frmGestionarPedido.ShowDialog()
            End Select

            ' Recargar las mesas después de realizar cualquier cambio
            cargarMesasGraficamente()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) 
        Dim frmMesas As New frmMesas
        frmMesas.ShowDialog()
    End Sub
End Class
