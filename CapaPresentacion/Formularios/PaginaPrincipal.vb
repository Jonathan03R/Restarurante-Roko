Public Class PaginaPrincipal

#Region "Operaciones Opciones"

    Private Sub OperacionesOpciones(sender As Object, e As EventArgs) _
        Handles mnuMenu.Click, mnuClientes.Click,
        mnuEmpleados.Click, mnuPedidos.Click, mnuReservas.Click, mnuSalir.Click, mnuMesas.Click

        If sender Is mnuMenu Then
            Menu()
        ElseIf sender Is mnuClientes Then
            Clientes()
        ElseIf sender Is mnuEmpleados Then
            Empleados()
        ElseIf sender Is mnuReservas Then
            reservaciones()
        ElseIf sender Is mnuMesas Then
            Mesas()
        ElseIf sender Is mnuPedidos Then
            Pedidos()
        ElseIf sender Is mnuReservas Then
            Reservas()
        ElseIf sender Is mnuSalir Then
            Salir()

        End If



    End Sub

    Private Sub Salir()
        End
    End Sub
    Private Sub Reservas()
        Dim fReservas As New frmReservas
        Dim F As Form
        Dim fPrincipal As PaginaPrincipal = Me
        For Each F In fPrincipal.MdiChildren
            If F.Name = fReservas.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fReservas.MdiParent = Me
        fReservas.Show()
    End Sub

    Private Sub Pedidos()
        Dim frmhistorialPedidos As New frmHistorialPedidos
        frmhistorialPedidos.MdiParent = Me
        frmhistorialPedidos.Show()
    End Sub

    Private Sub Mesas()
        Dim fMesasReservadas As New frmGraficaMesas
        Dim F As Form
        Dim fPrincipal As PaginaPrincipal = Me
        For Each F In fPrincipal.MdiChildren
            If F.Name = fMesasReservadas.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fMesasReservadas.MdiParent = Me
        fMesasReservadas.Show()

        fMesasReservadas.Left = (Me.ClientSize.Width - fMesasReservadas.Width) \ 2
        fMesasReservadas.Top = (Me.ClientSize.Height - fMesasReservadas.Height) \ 2
    End Sub

    Private Sub reservaciones()
        Dim frmReservaciones As New frmReservas
        frmReservaciones.MdiParent = Me
        frmReservaciones.Show()
    End Sub

    Private Sub Empleados()
        Dim fEmpleados As New frmEmpleados
        fEmpleados.MdiParent = Me
        fEmpleados.Show()
    End Sub

    Private Sub Clientes()
        Dim fClientes As New frmClientes
        fClientes.MdiParent = Me
        fClientes.Show()
    End Sub

    Private Sub Facturas()

    End Sub

    Private Sub Menu()
        Dim fMenu As New frmMenu
        Dim F As Form
        Dim fPrincipal As PaginaPrincipal = Me
        For Each F In fPrincipal.MdiChildren
            If F.Name = fMenu.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fMenu.MdiParent = Me
        fMenu.Show()
    End Sub



#End Region

#Region "FinanzasOpciones"

    Private Sub FinanzasOpciones(sender As Object, e As EventArgs)

    End Sub

    Private Sub Boleta()
        Dim frmBoleta As Form = New frmBoletas
        frmBoletas.MdiParent = Me
        frmBoletas.Show()
    End Sub

    Private Sub Pagos()
        Dim frmPago As Form = New frmPagos
        frmPago.MdiParent = Me
        frmPago.Show()
    End Sub




#End Region

#Region "Soporte y Ayuda"
    Private Sub SoporteyAyudaOpciones(sender As Object, e As EventArgs) _
        Handles mnuCentroDeAyuda.Click, mnuAcercaDe.Click


        If sender Is mnuCentroDeAyuda Then
            CentroDeAyuda()
        ElseIf sender Is mnuAcercaDe Then
            AcercaDe()

        End If


    End Sub

    Private Sub AcercaDe()
        Dim acercaDeForm As New frmAcercaDe()
        acercaDeForm.ShowDialog()
    End Sub

    Private Sub CentroDeAyuda()
        Dim centroAyuda As New frmCentroDeAyuda()
        centroAyuda.ShowDialog()
    End Sub

    Private Sub RolesyPermisos()
    End Sub

    Private Sub ConfiguracionDelSistema()
    End Sub

    Private Sub PedidosToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub mnuFacturas_Click(sender As Object, e As EventArgs) Handles mnuFacturas.Click
        MessageBox.Show("Aun esta en desarrollo", "Historial de Facturas", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub



#End Region

#Region "Cerrar por completo la interfaz"
    Private Sub PaginaPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit() ' Cierra toda la aplicación cuando se cierra el formulario
    End Sub

    Private Sub MesasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuMesas.Click

    End Sub

    Private Sub PaginaPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub mnuPagos_Click(sender As Object, e As EventArgs) Handles mnuPagos.Click
        MessageBox.Show("Aun esta en desarrollo", "Pagos", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub mnuBoleta_Click(sender As Object, e As EventArgs) Handles mnuBoleta.Click
        MessageBox.Show("Aun esta en desarrollo", "Historial de Boletas", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
#End Region


End Class