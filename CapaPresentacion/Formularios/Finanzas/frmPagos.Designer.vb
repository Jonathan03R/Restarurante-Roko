<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagos
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.dgvClientes = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codCLi = New System.Windows.Forms.Label()
        Me.btnFinalizarPago = New System.Windows.Forms.Button()
        Me.lblMontoTotal = New System.Windows.Forms.Label()
        Me.rbtnBoleta = New System.Windows.Forms.RadioButton()
        Me.rbtnFactura = New System.Windows.Forms.RadioButton()
        Me.lblEmpleadoCodigo = New System.Windows.Forms.Label()
        Me.lblPedidoCodigo = New System.Windows.Forms.Label()
        Me.lblMesaCodigo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblClienteNombre = New System.Windows.Forms.Label()
        Me.panelBoleta = New System.Windows.Forms.Panel()
        Me.panelRuc = New System.Windows.Forms.Panel()
        Me.Cliente = New System.Windows.Forms.Label()
        Me.txtNombreCliente = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRucCliente = New System.Windows.Forms.TextBox()
        CType(Me.dgvClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.panelBoleta.SuspendLayout()
        Me.panelRuc.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(330, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 23)
        Me.Button1.TabIndex = 41
        Me.Button1.Text = "Agregar Nuevo cliente"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(256, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "buscar"
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(30, 16)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(220, 20)
        Me.txtBuscar.TabIndex = 39
        '
        'dgvClientes
        '
        Me.dgvClientes.AllowUserToAddRows = False
        Me.dgvClientes.AllowUserToDeleteRows = False
        Me.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.dgvClientes.Location = New System.Drawing.Point(30, 47)
        Me.dgvClientes.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvClientes.MultiSelect = False
        Me.dgvClientes.Name = "dgvClientes"
        Me.dgvClientes.ReadOnly = True
        Me.dgvClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvClientes.RowHeadersWidth = 51
        Me.dgvClientes.RowTemplate.Height = 24
        Me.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClientes.Size = New System.Drawing.Size(434, 276)
        Me.dgvClientes.TabIndex = 38
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ClientesCodigo"
        Me.DataGridViewTextBoxColumn1.HeaderText = "codigo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ClientesNombreCompleto"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre De Cliente"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 300
        '
        'codCLi
        '
        Me.codCLi.AutoSize = True
        Me.codCLi.Location = New System.Drawing.Point(151, 43)
        Me.codCLi.Name = "codCLi"
        Me.codCLi.Size = New System.Drawing.Size(13, 13)
        Me.codCLi.TabIndex = 42
        Me.codCLi.Text = "--"
        '
        'btnFinalizarPago
        '
        Me.btnFinalizarPago.Location = New System.Drawing.Point(658, 431)
        Me.btnFinalizarPago.Name = "btnFinalizarPago"
        Me.btnFinalizarPago.Size = New System.Drawing.Size(177, 43)
        Me.btnFinalizarPago.TabIndex = 43
        Me.btnFinalizarPago.Text = "Finalizar Pago"
        Me.btnFinalizarPago.UseVisualStyleBackColor = True
        '
        'lblMontoTotal
        '
        Me.lblMontoTotal.AutoSize = True
        Me.lblMontoTotal.Location = New System.Drawing.Point(151, 185)
        Me.lblMontoTotal.Name = "lblMontoTotal"
        Me.lblMontoTotal.Size = New System.Drawing.Size(39, 13)
        Me.lblMontoTotal.TabIndex = 44
        Me.lblMontoTotal.Text = "Label4"
        '
        'rbtnBoleta
        '
        Me.rbtnBoleta.AutoSize = True
        Me.rbtnBoleta.Location = New System.Drawing.Point(23, 39)
        Me.rbtnBoleta.Name = "rbtnBoleta"
        Me.rbtnBoleta.Size = New System.Drawing.Size(54, 17)
        Me.rbtnBoleta.TabIndex = 45
        Me.rbtnBoleta.TabStop = True
        Me.rbtnBoleta.Text = "boleta"
        Me.rbtnBoleta.UseVisualStyleBackColor = True
        '
        'rbtnFactura
        '
        Me.rbtnFactura.AutoSize = True
        Me.rbtnFactura.Location = New System.Drawing.Point(116, 39)
        Me.rbtnFactura.Name = "rbtnFactura"
        Me.rbtnFactura.Size = New System.Drawing.Size(58, 17)
        Me.rbtnFactura.TabIndex = 46
        Me.rbtnFactura.TabStop = True
        Me.rbtnFactura.Text = "factura"
        Me.rbtnFactura.UseVisualStyleBackColor = True
        '
        'lblEmpleadoCodigo
        '
        Me.lblEmpleadoCodigo.AutoSize = True
        Me.lblEmpleadoCodigo.Location = New System.Drawing.Point(151, 72)
        Me.lblEmpleadoCodigo.Name = "lblEmpleadoCodigo"
        Me.lblEmpleadoCodigo.Size = New System.Drawing.Size(39, 13)
        Me.lblEmpleadoCodigo.TabIndex = 47
        Me.lblEmpleadoCodigo.Text = "Label1"
        '
        'lblPedidoCodigo
        '
        Me.lblPedidoCodigo.AutoSize = True
        Me.lblPedidoCodigo.Location = New System.Drawing.Point(151, 104)
        Me.lblPedidoCodigo.Name = "lblPedidoCodigo"
        Me.lblPedidoCodigo.Size = New System.Drawing.Size(39, 13)
        Me.lblPedidoCodigo.TabIndex = 48
        Me.lblPedidoCodigo.Text = "Label1"
        '
        'lblMesaCodigo
        '
        Me.lblMesaCodigo.AutoSize = True
        Me.lblMesaCodigo.Location = New System.Drawing.Point(151, 136)
        Me.lblMesaCodigo.Name = "lblMesaCodigo"
        Me.lblMesaCodigo.Size = New System.Drawing.Size(39, 13)
        Me.lblMesaCodigo.TabIndex = 49
        Me.lblMesaCodigo.Text = "Label1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 185)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Total a pagar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Codigo cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Codigo empleado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Codigo pedido"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(35, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "Codigo mesa"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.codCLi)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblMontoTotal)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblEmpleadoCodigo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblPedidoCodigo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblMesaCodigo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(63, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(236, 239)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información General"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtnFactura)
        Me.GroupBox2.Controls.Add(Me.rbtnBoleta)
        Me.GroupBox2.Location = New System.Drawing.Point(63, 316)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox2.TabIndex = 56
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Comprobantes de pago"
        '
        'lblClienteNombre
        '
        Me.lblClienteNombre.AutoSize = True
        Me.lblClienteNombre.Location = New System.Drawing.Point(118, 481)
        Me.lblClienteNombre.Name = "lblClienteNombre"
        Me.lblClienteNombre.Size = New System.Drawing.Size(39, 13)
        Me.lblClienteNombre.TabIndex = 57
        Me.lblClienteNombre.Text = "Label7"
        Me.lblClienteNombre.Visible = False
        '
        'panelBoleta
        '
        Me.panelBoleta.Controls.Add(Me.txtBuscar)
        Me.panelBoleta.Controls.Add(Me.Label5)
        Me.panelBoleta.Controls.Add(Me.Button1)
        Me.panelBoleta.Controls.Add(Me.dgvClientes)
        Me.panelBoleta.Location = New System.Drawing.Point(314, 29)
        Me.panelBoleta.Name = "panelBoleta"
        Me.panelBoleta.Size = New System.Drawing.Size(541, 370)
        Me.panelBoleta.TabIndex = 58
        '
        'panelRuc
        '
        Me.panelRuc.Controls.Add(Me.Cliente)
        Me.panelRuc.Controls.Add(Me.txtNombreCliente)
        Me.panelRuc.Controls.Add(Me.Label7)
        Me.panelRuc.Controls.Add(Me.txtRucCliente)
        Me.panelRuc.Location = New System.Drawing.Point(317, 104)
        Me.panelRuc.Name = "panelRuc"
        Me.panelRuc.Size = New System.Drawing.Size(538, 127)
        Me.panelRuc.TabIndex = 59
        '
        'Cliente
        '
        Me.Cliente.AutoSize = True
        Me.Cliente.Location = New System.Drawing.Point(41, 67)
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Size = New System.Drawing.Size(39, 13)
        Me.Cliente.TabIndex = 3
        Me.Cliente.Text = "Cliente"
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.Location = New System.Drawing.Point(101, 60)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.Size = New System.Drawing.Size(336, 20)
        Me.txtNombreCliente.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(41, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(22, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "ruc"
        '
        'txtRucCliente
        '
        Me.txtRucCliente.Location = New System.Drawing.Point(101, 19)
        Me.txtRucCliente.Name = "txtRucCliente"
        Me.txtRucCliente.Size = New System.Drawing.Size(236, 20)
        Me.txtRucCliente.TabIndex = 0
        '
        'frmPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 877)
        Me.Controls.Add(Me.panelRuc)
        Me.Controls.Add(Me.lblClienteNombre)
        Me.Controls.Add(Me.panelBoleta)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnFinalizarPago)
        Me.Name = "frmPagos"
        Me.Text = "Pagos"
        CType(Me.dgvClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.panelBoleta.ResumeLayout(False)
        Me.panelBoleta.PerformLayout()
        Me.panelRuc.ResumeLayout(False)
        Me.panelRuc.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents dgvClientes As DataGridView
    Friend WithEvents codCLi As Label
    Friend WithEvents btnFinalizarPago As Button
    Friend WithEvents lblMontoTotal As Label
    Friend WithEvents rbtnBoleta As RadioButton
    Friend WithEvents rbtnFactura As RadioButton
    Friend WithEvents lblEmpleadoCodigo As Label
    Friend WithEvents lblPedidoCodigo As Label
    Friend WithEvents lblMesaCodigo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblClienteNombre As Label
    Friend WithEvents panelBoleta As Panel
    Friend WithEvents panelRuc As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents txtRucCliente As TextBox
    Friend WithEvents Cliente As Label
    Friend WithEvents txtNombreCliente As TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
End Class
