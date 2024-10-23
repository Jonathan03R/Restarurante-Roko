<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PaginaPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PaginaPrincipal))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OperacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuClientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEmpleados = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuReservas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMesas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPedidos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.FinanzasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPagos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFacturas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBoleta = New System.Windows.Forms.ToolStripMenuItem()
        Me.SoporteYAyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCentroDeAyuda = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuAcercaDe = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Left
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OperacionesToolStripMenuItem, Me.FinanzasToolStripMenuItem, Me.SoporteYAyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(246, 671)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OperacionesToolStripMenuItem
        '
        Me.OperacionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMenu, Me.ToolStripMenuItem1, Me.mnuClientes, Me.mnuEmpleados, Me.ToolStripMenuItem2, Me.mnuReservas, Me.mnuMesas, Me.mnuPedidos, Me.ToolStripMenuItem4, Me.mnuSalir})
        Me.OperacionesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.OperacionesToolStripMenuItem.Name = "OperacionesToolStripMenuItem"
        Me.OperacionesToolStripMenuItem.Size = New System.Drawing.Size(237, 36)
        Me.OperacionesToolStripMenuItem.Text = "Operaciones"
        '
        'mnuMenu
        '
        Me.mnuMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuMenu.Name = "mnuMenu"
        Me.mnuMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.mnuMenu.Size = New System.Drawing.Size(332, 36)
        Me.mnuMenu.Text = "Menu"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(329, 6)
        '
        'mnuClientes
        '
        Me.mnuClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuClientes.Name = "mnuClientes"
        Me.mnuClientes.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.mnuClientes.Size = New System.Drawing.Size(332, 36)
        Me.mnuClientes.Text = "Clientes"
        '
        'mnuEmpleados
        '
        Me.mnuEmpleados.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuEmpleados.Name = "mnuEmpleados"
        Me.mnuEmpleados.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.mnuEmpleados.Size = New System.Drawing.Size(332, 36)
        Me.mnuEmpleados.Text = "Empleados"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(329, 6)
        '
        'mnuReservas
        '
        Me.mnuReservas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuReservas.Name = "mnuReservas"
        Me.mnuReservas.Size = New System.Drawing.Size(332, 36)
        Me.mnuReservas.Text = "Reservaciones"
        '
        'mnuMesas
        '
        Me.mnuMesas.Name = "mnuMesas"
        Me.mnuMesas.Size = New System.Drawing.Size(332, 36)
        Me.mnuMesas.Text = "Mesas"
        '
        'mnuPedidos
        '
        Me.mnuPedidos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuPedidos.Name = "mnuPedidos"
        Me.mnuPedidos.Size = New System.Drawing.Size(332, 36)
        Me.mnuPedidos.Text = "Pedidos"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(329, 6)
        '
        'mnuSalir
        '
        Me.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.mnuSalir.Size = New System.Drawing.Size(332, 36)
        Me.mnuSalir.Text = "Salir"
        '
        'FinanzasToolStripMenuItem
        '
        Me.FinanzasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPagos, Me.mnuFacturas, Me.mnuBoleta})
        Me.FinanzasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.FinanzasToolStripMenuItem.Name = "FinanzasToolStripMenuItem"
        Me.FinanzasToolStripMenuItem.Size = New System.Drawing.Size(237, 36)
        Me.FinanzasToolStripMenuItem.Text = "Finanzas"
        '
        'mnuPagos
        '
        Me.mnuPagos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuPagos.Name = "mnuPagos"
        Me.mnuPagos.Size = New System.Drawing.Size(202, 36)
        Me.mnuPagos.Text = "Pagos"
        '
        'mnuFacturas
        '
        Me.mnuFacturas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuFacturas.Name = "mnuFacturas"
        Me.mnuFacturas.Size = New System.Drawing.Size(202, 36)
        Me.mnuFacturas.Text = "Facturas"
        '
        'mnuBoleta
        '
        Me.mnuBoleta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuBoleta.Name = "mnuBoleta"
        Me.mnuBoleta.Size = New System.Drawing.Size(202, 36)
        Me.mnuBoleta.Text = "Boleta"
        '
        'SoporteYAyudaToolStripMenuItem
        '
        Me.SoporteYAyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem6, Me.ToolStripMenuItem7, Me.mnuCentroDeAyuda, Me.ToolStripMenuItem5, Me.mnuAcercaDe})
        Me.SoporteYAyudaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SoporteYAyudaToolStripMenuItem.Name = "SoporteYAyudaToolStripMenuItem"
        Me.SoporteYAyudaToolStripMenuItem.Size = New System.Drawing.Size(237, 36)
        Me.SoporteYAyudaToolStripMenuItem.Text = "Soporte y Ayuda"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(527, 6)
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(527, 6)
        '
        'mnuCentroDeAyuda
        '
        Me.mnuCentroDeAyuda.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuCentroDeAyuda.Name = "mnuCentroDeAyuda"
        Me.mnuCentroDeAyuda.Size = New System.Drawing.Size(530, 36)
        Me.mnuCentroDeAyuda.Text = "Centro de Ayuda"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(527, 6)
        '
        'mnuAcercaDe
        '
        Me.mnuAcercaDe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuAcercaDe.Name = "mnuAcercaDe"
        Me.mnuAcercaDe.Size = New System.Drawing.Size(530, 36)
        Me.mnuAcercaDe.Text = "Acerca de Restaurante ""El Sabor"""
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(246, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(957, 62)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Restaurante ROKO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PaginaPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1203, 671)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.Name = "PaginaPrincipal"
        Me.Text = "PaginaPrincipal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents OperacionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuMenu As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents mnuClientes As ToolStripMenuItem
    Friend WithEvents mnuEmpleados As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents mnuReservas As ToolStripMenuItem
    Friend WithEvents mnuPedidos As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents FinanzasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuPagos As ToolStripMenuItem
    Friend WithEvents mnuFacturas As ToolStripMenuItem
    Friend WithEvents mnuBoleta As ToolStripMenuItem
    Friend WithEvents SoporteYAyudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem7 As ToolStripSeparator
    Friend WithEvents mnuCentroDeAyuda As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripSeparator
    Friend WithEvents mnuAcercaDe As ToolStripMenuItem
    Friend WithEvents mnuMesas As ToolStripMenuItem
    Friend WithEvents Label1 As Label
End Class
