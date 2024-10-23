<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReservas
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
        Me.btnGenerarCodigo = New System.Windows.Forms.Button()
        Me.btnactualizar = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.tabla = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clientes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mesa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_registrada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.datefecha = New System.Windows.Forms.DateTimePicker()
        Me.comboMesas = New System.Windows.Forms.ComboBox()
        Me.txtcliente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvClientes = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.combEstadoReserva = New System.Windows.Forms.ComboBox()
        Me.labelEstado = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dateTime = New System.Windows.Forms.DateTimePicker()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.chkCancelado = New System.Windows.Forms.CheckBox()
        Me.chkPendiente = New System.Windows.Forms.CheckBox()
        Me.chkExpirada = New System.Windows.Forms.CheckBox()
        Me.chkFinalizada = New System.Windows.Forms.CheckBox()
        CType(Me.tabla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGenerarCodigo
        '
        Me.btnGenerarCodigo.Location = New System.Drawing.Point(276, 21)
        Me.btnGenerarCodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGenerarCodigo.Name = "btnGenerarCodigo"
        Me.btnGenerarCodigo.Size = New System.Drawing.Size(53, 24)
        Me.btnGenerarCodigo.TabIndex = 28
        Me.btnGenerarCodigo.Text = "generar"
        Me.btnGenerarCodigo.UseVisualStyleBackColor = True
        '
        'btnactualizar
        '
        Me.btnactualizar.Location = New System.Drawing.Point(386, 43)
        Me.btnactualizar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnactualizar.Name = "btnactualizar"
        Me.btnactualizar.Size = New System.Drawing.Size(101, 19)
        Me.btnactualizar.TabIndex = 25
        Me.btnactualizar.Text = "Actualizar"
        Me.btnactualizar.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(386, 19)
        Me.btnsave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(101, 19)
        Me.btnsave.TabIndex = 24
        Me.btnsave.Text = "Guardar"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'tabla
        '
        Me.tabla.AllowUserToAddRows = False
        Me.tabla.AllowUserToDeleteRows = False
        Me.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tabla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Clientes, Me.Mesa, Me.Column1, Me.Fecha_registrada, Me.Column2})
        Me.tabla.Location = New System.Drawing.Point(36, 282)
        Me.tabla.Margin = New System.Windows.Forms.Padding(2)
        Me.tabla.MultiSelect = False
        Me.tabla.Name = "tabla"
        Me.tabla.ReadOnly = True
        Me.tabla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.tabla.RowHeadersWidth = 51
        Me.tabla.RowTemplate.Height = 24
        Me.tabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tabla.Size = New System.Drawing.Size(549, 206)
        Me.tabla.TabIndex = 23
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        '
        'Clientes
        '
        Me.Clientes.HeaderText = "Clientes"
        Me.Clientes.Name = "Clientes"
        Me.Clientes.ReadOnly = True
        Me.Clientes.Width = 200
        '
        'Mesa
        '
        Me.Mesa.HeaderText = "Mesa"
        Me.Mesa.Name = "Mesa"
        Me.Mesa.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Estado mesa"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Fecha_registrada
        '
        Me.Fecha_registrada.HeaderText = "Fecha reserva"
        Me.Fecha_registrada.Name = "Fecha_registrada"
        Me.Fecha_registrada.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Hora de reserva"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 108)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Fecha Reserva"
        '
        'datefecha
        '
        Me.datefecha.CustomFormat = ""
        Me.datefecha.Location = New System.Drawing.Point(121, 102)
        Me.datefecha.Margin = New System.Windows.Forms.Padding(2)
        Me.datefecha.Name = "datefecha"
        Me.datefecha.Size = New System.Drawing.Size(215, 20)
        Me.datefecha.TabIndex = 21
        Me.datefecha.Value = New Date(2024, 10, 19, 11, 56, 40, 0)
        '
        'comboMesas
        '
        Me.comboMesas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboMesas.FormattingEnabled = True
        Me.comboMesas.Location = New System.Drawing.Point(121, 71)
        Me.comboMesas.Margin = New System.Windows.Forms.Padding(2)
        Me.comboMesas.Name = "comboMesas"
        Me.comboMesas.Size = New System.Drawing.Size(156, 21)
        Me.comboMesas.TabIndex = 20
        '
        'txtcliente
        '
        Me.txtcliente.Enabled = False
        Me.txtcliente.Location = New System.Drawing.Point(121, 47)
        Me.txtcliente.Margin = New System.Windows.Forms.Padding(2)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.Size = New System.Drawing.Size(156, 20)
        Me.txtcliente.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 50)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Cliente codigo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 74)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Mesa capacidad"
        '
        'txtcodigo
        '
        Me.txtcodigo.Enabled = False
        Me.txtcodigo.Location = New System.Drawing.Point(121, 23)
        Me.txtcodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(156, 20)
        Me.txtcodigo.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Codigo reserva"
        '
        'dgvClientes
        '
        Me.dgvClientes.AllowUserToAddRows = False
        Me.dgvClientes.AllowUserToDeleteRows = False
        Me.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.dgvClientes.Location = New System.Drawing.Point(609, 74)
        Me.dgvClientes.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvClientes.MultiSelect = False
        Me.dgvClientes.Name = "dgvClientes"
        Me.dgvClientes.ReadOnly = True
        Me.dgvClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvClientes.RowHeadersWidth = 51
        Me.dgvClientes.RowTemplate.Height = 24
        Me.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClientes.Size = New System.Drawing.Size(434, 276)
        Me.dgvClientes.TabIndex = 30
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "codigo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre De Cliente"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 300
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(609, 42)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(220, 20)
        Me.txtBuscar.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(835, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "buscar"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(909, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 23)
        Me.Button1.TabIndex = 33
        Me.Button1.Text = "Agregar Nuevo cliente"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'combEstadoReserva
        '
        Me.combEstadoReserva.FormattingEnabled = True
        Me.combEstadoReserva.Location = New System.Drawing.Point(121, 167)
        Me.combEstadoReserva.Name = "combEstadoReserva"
        Me.combEstadoReserva.Size = New System.Drawing.Size(166, 21)
        Me.combEstadoReserva.TabIndex = 34
        '
        'labelEstado
        '
        Me.labelEstado.AutoSize = True
        Me.labelEstado.Location = New System.Drawing.Point(33, 172)
        Me.labelEstado.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.labelEstado.Name = "labelEstado"
        Me.labelEstado.Size = New System.Drawing.Size(83, 13)
        Me.labelEstado.TabIndex = 35
        Me.labelEstado.Text = "Estado Reserva"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(36, 135)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Hora reserva"
        '
        'dateTime
        '
        Me.dateTime.CustomFormat = "HH:mm"
        Me.dateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateTime.Location = New System.Drawing.Point(121, 135)
        Me.dateTime.Name = "dateTime"
        Me.dateTime.ShowUpDown = True
        Me.dateTime.Size = New System.Drawing.Size(83, 20)
        Me.dateTime.TabIndex = 37
        Me.dateTime.Value = New Date(2024, 10, 19, 0, 0, 0, 0)
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Location = New System.Drawing.Point(167, 260)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(56, 17)
        Me.chkActivo.TabIndex = 38
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'chkCancelado
        '
        Me.chkCancelado.AutoSize = True
        Me.chkCancelado.Location = New System.Drawing.Point(233, 260)
        Me.chkCancelado.Name = "chkCancelado"
        Me.chkCancelado.Size = New System.Drawing.Size(77, 17)
        Me.chkCancelado.TabIndex = 39
        Me.chkCancelado.Text = "Cancelado"
        Me.chkCancelado.UseVisualStyleBackColor = True
        '
        'chkPendiente
        '
        Me.chkPendiente.AutoSize = True
        Me.chkPendiente.Location = New System.Drawing.Point(320, 260)
        Me.chkPendiente.Name = "chkPendiente"
        Me.chkPendiente.Size = New System.Drawing.Size(74, 17)
        Me.chkPendiente.TabIndex = 40
        Me.chkPendiente.Text = "Pendiente"
        Me.chkPendiente.UseVisualStyleBackColor = True
        '
        'chkExpirada
        '
        Me.chkExpirada.AutoSize = True
        Me.chkExpirada.Location = New System.Drawing.Point(404, 260)
        Me.chkExpirada.Name = "chkExpirada"
        Me.chkExpirada.Size = New System.Drawing.Size(67, 17)
        Me.chkExpirada.TabIndex = 41
        Me.chkExpirada.Text = "Expirada"
        Me.chkExpirada.UseVisualStyleBackColor = True
        '
        'chkFinalizada
        '
        Me.chkFinalizada.AutoSize = True
        Me.chkFinalizada.Location = New System.Drawing.Point(481, 260)
        Me.chkFinalizada.Name = "chkFinalizada"
        Me.chkFinalizada.Size = New System.Drawing.Size(73, 17)
        Me.chkFinalizada.TabIndex = 42
        Me.chkFinalizada.Text = "Finalizada"
        Me.chkFinalizada.UseVisualStyleBackColor = True
        '
        'frmReservas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1102, 547)
        Me.Controls.Add(Me.chkFinalizada)
        Me.Controls.Add(Me.chkExpirada)
        Me.Controls.Add(Me.chkPendiente)
        Me.Controls.Add(Me.chkCancelado)
        Me.Controls.Add(Me.chkActivo)
        Me.Controls.Add(Me.dateTime)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.labelEstado)
        Me.Controls.Add(Me.combEstadoReserva)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.dgvClientes)
        Me.Controls.Add(Me.btnGenerarCodigo)
        Me.Controls.Add(Me.btnactualizar)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.tabla)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.datefecha)
        Me.Controls.Add(Me.comboMesas)
        Me.Controls.Add(Me.txtcliente)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtcodigo)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmReservas"
        Me.Text = "Reservas"
        CType(Me.tabla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGenerarCodigo As Button
    Friend WithEvents btnactualizar As Button
    Friend WithEvents btnsave As Button
    Friend WithEvents tabla As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents datefecha As DateTimePicker
    Friend WithEvents comboMesas As ComboBox
    Friend WithEvents txtcliente As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtcodigo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvClientes As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents combEstadoReserva As ComboBox
    Friend WithEvents labelEstado As Label
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents Clientes As DataGridViewTextBoxColumn
    Friend WithEvents Mesa As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_registrada As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Label6 As Label
    Friend WithEvents dateTime As DateTimePicker
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents chkCancelado As CheckBox
    Friend WithEvents chkPendiente As CheckBox
    Friend WithEvents chkExpirada As CheckBox
    Friend WithEvents chkFinalizada As CheckBox
End Class
