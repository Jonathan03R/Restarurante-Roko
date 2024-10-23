<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturas
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
        Me.btnMostrarEliminados = New System.Windows.Forms.Button()
        Me.btnMostrarTabla = New System.Windows.Forms.Button()
        Me.tabla = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero_Factura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pedidos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnRestaurar = New System.Windows.Forms.Button()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.pedidos_ = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.total_ = New System.Windows.Forms.TextBox()
        Me.cliente_ = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.fechacreacion_ = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numerofactura_ = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.codigo_ = New System.Windows.Forms.TextBox()
        CType(Me.tabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnMostrarEliminados
        '
        Me.btnMostrarEliminados.Location = New System.Drawing.Point(559, 193)
        Me.btnMostrarEliminados.Name = "btnMostrarEliminados"
        Me.btnMostrarEliminados.Size = New System.Drawing.Size(114, 23)
        Me.btnMostrarEliminados.TabIndex = 38
        Me.btnMostrarEliminados.Text = "Mostrar eliminados"
        Me.btnMostrarEliminados.UseVisualStyleBackColor = True
        '
        'btnMostrarTabla
        '
        Me.btnMostrarTabla.Location = New System.Drawing.Point(559, 222)
        Me.btnMostrarTabla.Name = "btnMostrarTabla"
        Me.btnMostrarTabla.Size = New System.Drawing.Size(114, 23)
        Me.btnMostrarTabla.TabIndex = 37
        Me.btnMostrarTabla.Text = "Mostrar tabla"
        Me.btnMostrarTabla.UseVisualStyleBackColor = True
        '
        'tabla
        '
        Me.tabla.AllowUserToAddRows = False
        Me.tabla.AllowUserToDeleteRows = False
        Me.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tabla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Numero_Factura, Me.Fecha_Creacion, Me.Cliente, Me.Total, Me.Pedidos})
        Me.tabla.Location = New System.Drawing.Point(43, 251)
        Me.tabla.Name = "tabla"
        Me.tabla.ReadOnly = True
        Me.tabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tabla.Size = New System.Drawing.Size(630, 212)
        Me.tabla.TabIndex = 36
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        '
        'Numero_Factura
        '
        Me.Numero_Factura.HeaderText = "Numero factura"
        Me.Numero_Factura.Name = "Numero_Factura"
        Me.Numero_Factura.ReadOnly = True
        '
        'Fecha_Creacion
        '
        Me.Fecha_Creacion.HeaderText = "Fecha creacion"
        Me.Fecha_Creacion.Name = "Fecha_Creacion"
        Me.Fecha_Creacion.ReadOnly = True
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        '
        'Total
        '
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'Pedidos
        '
        Me.Pedidos.HeaderText = "Pedidos"
        Me.Pedidos.Name = "Pedidos"
        Me.Pedidos.ReadOnly = True
        '
        'btnRestaurar
        '
        Me.btnRestaurar.Location = New System.Drawing.Point(601, 117)
        Me.btnRestaurar.Name = "btnRestaurar"
        Me.btnRestaurar.Size = New System.Drawing.Size(75, 23)
        Me.btnRestaurar.TabIndex = 35
        Me.btnRestaurar.Text = "Restaurar"
        Me.btnRestaurar.UseVisualStyleBackColor = True
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(601, 62)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnActualizar.TabIndex = 34
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(601, 88)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 33
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(601, 36)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 32
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'pedidos_
        '
        Me.pedidos_.FormattingEnabled = True
        Me.pedidos_.Location = New System.Drawing.Point(146, 167)
        Me.pedidos_.Name = "pedidos_"
        Me.pedidos_.Size = New System.Drawing.Size(121, 21)
        Me.pedidos_.TabIndex = 31
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(43, 170)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Pedidos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(43, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Total"
        '
        'total_
        '
        Me.total_.Location = New System.Drawing.Point(146, 141)
        Me.total_.Name = "total_"
        Me.total_.Size = New System.Drawing.Size(100, 20)
        Me.total_.TabIndex = 28
        '
        'cliente_
        '
        Me.cliente_.FormattingEnabled = True
        Me.cliente_.Location = New System.Drawing.Point(146, 114)
        Me.cliente_.Name = "cliente_"
        Me.cliente_.Size = New System.Drawing.Size(121, 21)
        Me.cliente_.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(44, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Cliente"
        '
        'fechacreacion_
        '
        Me.fechacreacion_.Location = New System.Drawing.Point(146, 89)
        Me.fechacreacion_.Name = "fechacreacion_"
        Me.fechacreacion_.Size = New System.Drawing.Size(137, 20)
        Me.fechacreacion_.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Fecha creacion"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Numero factura"
        '
        'numerofactura_
        '
        Me.numerofactura_.Location = New System.Drawing.Point(146, 59)
        Me.numerofactura_.Name = "numerofactura_"
        Me.numerofactura_.Size = New System.Drawing.Size(100, 20)
        Me.numerofactura_.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Codigo"
        '
        'codigo_
        '
        Me.codigo_.Location = New System.Drawing.Point(146, 33)
        Me.codigo_.Name = "codigo_"
        Me.codigo_.Size = New System.Drawing.Size(100, 20)
        Me.codigo_.TabIndex = 20
        '
        'frmFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 516)
        Me.Controls.Add(Me.btnMostrarEliminados)
        Me.Controls.Add(Me.btnMostrarTabla)
        Me.Controls.Add(Me.tabla)
        Me.Controls.Add(Me.btnRestaurar)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.pedidos_)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.total_)
        Me.Controls.Add(Me.cliente_)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.fechacreacion_)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.numerofactura_)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.codigo_)
        Me.Name = "frmFacturas"
        Me.Text = "Facturas"
        CType(Me.tabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnMostrarEliminados As Button
    Friend WithEvents btnMostrarTabla As Button
    Friend WithEvents tabla As DataGridView
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents Numero_Factura As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Creacion As DataGridViewTextBoxColumn
    Friend WithEvents Cliente As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents Pedidos As DataGridViewTextBoxColumn
    Friend WithEvents btnRestaurar As Button
    Friend WithEvents btnActualizar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents pedidos_ As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents total_ As TextBox
    Friend WithEvents cliente_ As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents fechacreacion_ As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents numerofactura_ As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents codigo_ As TextBox
End Class
