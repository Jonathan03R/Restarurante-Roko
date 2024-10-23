<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGestionarPedido
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
        Me.lblPedidoCodigo = New System.Windows.Forms.Label()
        Me.lblMesaCodigo = New System.Windows.Forms.Label()
        Me.lblEmpleadoCodigo = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.btnAgregarDetalle = New System.Windows.Forms.Button()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbMenu = New System.Windows.Forms.ComboBox()
        Me.btnEliminarDetalle = New System.Windows.Forms.Button()
        Me.lvDetallesPedido = New System.Windows.Forms.ListView()
        Me.Producto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Porciones = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Precio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SubTotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblFechaPedido = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnFinalizarPedido = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblPedidoCodigo
        '
        Me.lblPedidoCodigo.AutoSize = True
        Me.lblPedidoCodigo.Location = New System.Drawing.Point(162, 51)
        Me.lblPedidoCodigo.Name = "lblPedidoCodigo"
        Me.lblPedidoCodigo.Size = New System.Drawing.Size(25, 13)
        Me.lblPedidoCodigo.TabIndex = 1
        Me.lblPedidoCodigo.Text = "cod"
        '
        'lblMesaCodigo
        '
        Me.lblMesaCodigo.AutoSize = True
        Me.lblMesaCodigo.Location = New System.Drawing.Point(162, 85)
        Me.lblMesaCodigo.Name = "lblMesaCodigo"
        Me.lblMesaCodigo.Size = New System.Drawing.Size(39, 13)
        Me.lblMesaCodigo.TabIndex = 2
        Me.lblMesaCodigo.Text = "Label1"
        '
        'lblEmpleadoCodigo
        '
        Me.lblEmpleadoCodigo.AutoSize = True
        Me.lblEmpleadoCodigo.Location = New System.Drawing.Point(162, 120)
        Me.lblEmpleadoCodigo.Name = "lblEmpleadoCodigo"
        Me.lblEmpleadoCodigo.Size = New System.Drawing.Size(39, 13)
        Me.lblEmpleadoCodigo.TabIndex = 3
        Me.lblEmpleadoCodigo.Text = "Label1"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(162, 149)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(39, 13)
        Me.lblFecha.TabIndex = 4
        Me.lblFecha.Text = "Label2"
        '
        'btnAgregarDetalle
        '
        Me.btnAgregarDetalle.Location = New System.Drawing.Point(218, 167)
        Me.btnAgregarDetalle.Name = "btnAgregarDetalle"
        Me.btnAgregarDetalle.Size = New System.Drawing.Size(160, 23)
        Me.btnAgregarDetalle.TabIndex = 5
        Me.btnAgregarDetalle.Text = "Agregar pedido"
        Me.btnAgregarDetalle.UseVisualStyleBackColor = True
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Location = New System.Drawing.Point(291, 119)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(47, 13)
        Me.lblPrecio.TabIndex = 6
        Me.lblPrecio.Text = "lblPrecio"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(215, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "precio"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(250, 47)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(100, 20)
        Me.txtCantidad.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(215, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "cantidad"
        '
        'cmbMenu
        '
        Me.cmbMenu.FormattingEnabled = True
        Me.cmbMenu.Location = New System.Drawing.Point(35, 47)
        Me.cmbMenu.Name = "cmbMenu"
        Me.cmbMenu.Size = New System.Drawing.Size(121, 21)
        Me.cmbMenu.TabIndex = 10
        '
        'btnEliminarDetalle
        '
        Me.btnEliminarDetalle.Location = New System.Drawing.Point(720, 280)
        Me.btnEliminarDetalle.Name = "btnEliminarDetalle"
        Me.btnEliminarDetalle.Size = New System.Drawing.Size(116, 23)
        Me.btnEliminarDetalle.TabIndex = 11
        Me.btnEliminarDetalle.Text = "Eliminar Plato"
        Me.btnEliminarDetalle.UseVisualStyleBackColor = True
        '
        'lvDetallesPedido
        '
        Me.lvDetallesPedido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDetallesPedido.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Producto, Me.Porciones, Me.Precio, Me.SubTotal})
        Me.lvDetallesPedido.FullRowSelect = True
        Me.lvDetallesPedido.GridLines = True
        Me.lvDetallesPedido.HideSelection = False
        Me.lvDetallesPedido.Location = New System.Drawing.Point(431, 308)
        Me.lvDetallesPedido.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lvDetallesPedido.Name = "lvDetallesPedido"
        Me.lvDetallesPedido.Size = New System.Drawing.Size(405, 230)
        Me.lvDetallesPedido.TabIndex = 23
        Me.lvDetallesPedido.UseCompatibleStateImageBehavior = False
        Me.lvDetallesPedido.View = System.Windows.Forms.View.Details
        '
        'Producto
        '
        Me.Producto.Text = "Producto"
        Me.Producto.Width = 100
        '
        'Porciones
        '
        Me.Porciones.Text = "Porciones"
        Me.Porciones.Width = 100
        '
        'Precio
        '
        Me.Precio.Text = "Precio"
        Me.Precio.Width = 100
        '
        'SubTotal
        '
        Me.SubTotal.Text = "SubTotal"
        Me.SubTotal.Width = 100
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Codigo del pedido"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Codigo de mesa"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Codigo empleado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 149)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Fecha del pedido"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblFechaPedido)
        Me.GroupBox1.Controls.Add(Me.lblEmpleadoCodigo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblPedidoCodigo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblMesaCodigo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblFecha)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(65, 308)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(283, 240)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del pedido"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(31, 179)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Fecha"
        '
        'lblFechaPedido
        '
        Me.lblFechaPedido.AutoSize = True
        Me.lblFechaPedido.Location = New System.Drawing.Point(162, 179)
        Me.lblFechaPedido.Name = "lblFechaPedido"
        Me.lblFechaPedido.Size = New System.Drawing.Size(39, 13)
        Me.lblFechaPedido.TabIndex = 28
        Me.lblFechaPedido.Text = "Label8"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cmbMenu)
        Me.GroupBox2.Controls.Add(Me.txtCantidad)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.btnAgregarDetalle)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.lblPrecio)
        Me.GroupBox2.Location = New System.Drawing.Point(77, 66)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(402, 205)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Nuevo producto"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "menú"
        '
        'btnFinalizarPedido
        '
        Me.btnFinalizarPedido.Location = New System.Drawing.Point(497, 76)
        Me.btnFinalizarPedido.Name = "btnFinalizarPedido"
        Me.btnFinalizarPedido.Size = New System.Drawing.Size(142, 54)
        Me.btnFinalizarPedido.TabIndex = 30
        Me.btnFinalizarPedido.Text = "Finalizar Pedido"
        Me.btnFinalizarPedido.UseVisualStyleBackColor = True
        '
        'frmGestionarPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 620)
        Me.Controls.Add(Me.btnFinalizarPedido)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lvDetallesPedido)
        Me.Controls.Add(Me.btnEliminarDetalle)
        Me.Name = "frmGestionarPedido"
        Me.Text = "frmGestionarPedido"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblPedidoCodigo As Label
    Friend WithEvents lblMesaCodigo As Label
    Friend WithEvents lblEmpleadoCodigo As Label
    Friend WithEvents lblFecha As Label
    Friend WithEvents btnAgregarDetalle As Button
    Friend WithEvents lblPrecio As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbMenu As ComboBox
    Friend WithEvents btnEliminarDetalle As Button
    Friend WithEvents lvDetallesPedido As ListView
    Friend WithEvents Producto As ColumnHeader
    Friend WithEvents Porciones As ColumnHeader
    Friend WithEvents Precio As ColumnHeader
    Friend WithEvents SubTotal As ColumnHeader
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnFinalizarPedido As Button
    Friend WithEvents lblFechaPedido As Label
    Friend WithEvents Label8 As Label
End Class
