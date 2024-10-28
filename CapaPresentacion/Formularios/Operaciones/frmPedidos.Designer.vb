<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnCancelarPedido = New System.Windows.Forms.Button()
        Me.btnCompletarPedido = New System.Windows.Forms.Button()
        Me.cmbMenu = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvDetallesPedido = New System.Windows.Forms.DataGridView()
        Me.btnAgregarProducto = New System.Windows.Forms.Button()
        Me.producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDetallesPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelarPedido
        '
        Me.btnCancelarPedido.Location = New System.Drawing.Point(623, 34)
        Me.btnCancelarPedido.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancelarPedido.Name = "btnCancelarPedido"
        Me.btnCancelarPedido.Size = New System.Drawing.Size(134, 19)
        Me.btnCancelarPedido.TabIndex = 25
        Me.btnCancelarPedido.Text = "Cancelar Pedido"
        Me.btnCancelarPedido.UseVisualStyleBackColor = True
        '
        'btnCompletarPedido
        '
        Me.btnCompletarPedido.Location = New System.Drawing.Point(623, 70)
        Me.btnCompletarPedido.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCompletarPedido.Name = "btnCompletarPedido"
        Me.btnCompletarPedido.Size = New System.Drawing.Size(134, 19)
        Me.btnCompletarPedido.TabIndex = 23
        Me.btnCompletarPedido.Text = "Guardar pedido"
        Me.btnCompletarPedido.UseVisualStyleBackColor = True
        '
        'cmbMenu
        '
        Me.cmbMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMenu.FormattingEnabled = True
        Me.cmbMenu.Location = New System.Drawing.Point(139, 73)
        Me.cmbMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbMenu.Name = "cmbMenu"
        Me.cmbMenu.Size = New System.Drawing.Size(157, 21)
        Me.cmbMenu.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 30)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Empleados codigo"
        Me.Label3.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(139, 30)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(157, 20)
        Me.TextBox1.TabIndex = 30
        Me.TextBox1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(76, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Menu"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(139, 127)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(157, 20)
        Me.txtCantidad.TabIndex = 32
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(66, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Porciones"
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Location = New System.Drawing.Point(257, 183)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(39, 13)
        Me.lblPrecio.TabIndex = 34
        Me.lblPrecio.Text = "Label6"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(66, 183)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Precio del Producto"
        '
        'dgvDetallesPedido
        '
        Me.dgvDetallesPedido.AllowUserToAddRows = False
        Me.dgvDetallesPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetallesPedido.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.producto, Me.Column1, Me.Column2, Me.Column3})
        Me.dgvDetallesPedido.Location = New System.Drawing.Point(363, 116)
        Me.dgvDetallesPedido.Name = "dgvDetallesPedido"
        Me.dgvDetallesPedido.Size = New System.Drawing.Size(431, 380)
        Me.dgvDetallesPedido.TabIndex = 36
        '
        'btnAgregarProducto
        '
        Me.btnAgregarProducto.Location = New System.Drawing.Point(374, 30)
        Me.btnAgregarProducto.Name = "btnAgregarProducto"
        Me.btnAgregarProducto.Size = New System.Drawing.Size(113, 23)
        Me.btnAgregarProducto.TabIndex = 37
        Me.btnAgregarProducto.Text = "Agregar Producto"
        Me.btnAgregarProducto.UseVisualStyleBackColor = True
        '
        'producto
        '
        Me.producto.DataPropertyName = "MenuNombre"
        Me.producto.HeaderText = "producto"
        Me.producto.Name = "producto"
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "DetallesPedidoPrecio"
        Me.Column1.HeaderText = "precio"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "DetallesPedidoCantidad"
        Me.Column2.HeaderText = "cantidad"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "Total"
        Me.Column3.HeaderText = "total"
        Me.Column3.Name = "Column3"
        '
        'frmPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 587)
        Me.Controls.Add(Me.btnAgregarProducto)
        Me.Controls.Add(Me.dgvDetallesPedido)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblPrecio)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnCancelarPedido)
        Me.Controls.Add(Me.btnCompletarPedido)
        Me.Controls.Add(Me.cmbMenu)
        Me.Controls.Add(Me.Label3)
        Me.Name = "frmPedidos"
        Me.Text = "Pedidos"
        CType(Me.dgvDetallesPedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancelarPedido As Button
    Friend WithEvents btnCompletarPedido As Button
    Friend WithEvents cmbMenu As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lblPrecio As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents dgvDetallesPedido As DataGridView
    Friend WithEvents btnAgregarProducto As Button
    Friend WithEvents producto As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
End Class
