<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientes
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
        Me.tabla = New System.Windows.Forms.DataGridView()
        Me.ClientesCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Reservas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClientesNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClientesApellidos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClientesTelefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClientesDNI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClientesCorreo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClientesFechaRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnrestore = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.datefecha = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtcorreo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtdni = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txttelefono = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtapellidos = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtnombres = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.generarCodigo = New System.Windows.Forms.Button()
        Me.tablaReservas = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservasBox = New System.Windows.Forms.GroupBox()
        CType(Me.tabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tablaReservas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ReservasBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabla
        '
        Me.tabla.AllowUserToAddRows = False
        Me.tabla.AllowUserToDeleteRows = False
        Me.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tabla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ClientesCodigo, Me.Reservas, Me.ClientesNombre, Me.ClientesApellidos, Me.ClientesTelefono, Me.ClientesDNI, Me.ClientesCorreo, Me.ClientesFechaRegistro})
        Me.tabla.Location = New System.Drawing.Point(42, 338)
        Me.tabla.MultiSelect = False
        Me.tabla.Name = "tabla"
        Me.tabla.ReadOnly = True
        Me.tabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tabla.Size = New System.Drawing.Size(603, 211)
        Me.tabla.TabIndex = 47
        '
        'ClientesCodigo
        '
        Me.ClientesCodigo.DataPropertyName = "ClientesCodigo"
        Me.ClientesCodigo.HeaderText = "Codigo"
        Me.ClientesCodigo.Name = "ClientesCodigo"
        Me.ClientesCodigo.ReadOnly = True
        '
        'Reservas
        '
        Me.Reservas.DataPropertyName = "Reservas"
        Me.Reservas.HeaderText = "Reservas"
        Me.Reservas.Name = "Reservas"
        Me.Reservas.ReadOnly = True
        '
        'ClientesNombre
        '
        Me.ClientesNombre.DataPropertyName = "ClientesNombre"
        Me.ClientesNombre.HeaderText = "Nombres"
        Me.ClientesNombre.Name = "ClientesNombre"
        Me.ClientesNombre.ReadOnly = True
        '
        'ClientesApellidos
        '
        Me.ClientesApellidos.DataPropertyName = "ClientesApellidos"
        Me.ClientesApellidos.HeaderText = "Apellidos"
        Me.ClientesApellidos.Name = "ClientesApellidos"
        Me.ClientesApellidos.ReadOnly = True
        '
        'ClientesTelefono
        '
        Me.ClientesTelefono.DataPropertyName = "ClientesTelefono"
        Me.ClientesTelefono.HeaderText = "Télefono"
        Me.ClientesTelefono.Name = "ClientesTelefono"
        Me.ClientesTelefono.ReadOnly = True
        '
        'ClientesDNI
        '
        Me.ClientesDNI.DataPropertyName = "ClientesDNI"
        Me.ClientesDNI.HeaderText = "dni"
        Me.ClientesDNI.Name = "ClientesDNI"
        Me.ClientesDNI.ReadOnly = True
        '
        'ClientesCorreo
        '
        Me.ClientesCorreo.DataPropertyName = "ClientesCorreo"
        Me.ClientesCorreo.HeaderText = "Correo"
        Me.ClientesCorreo.Name = "ClientesCorreo"
        Me.ClientesCorreo.ReadOnly = True
        '
        'ClientesFechaRegistro
        '
        Me.ClientesFechaRegistro.DataPropertyName = "ClientesFechaRegistro"
        Me.ClientesFechaRegistro.HeaderText = "Fecha registro"
        Me.ClientesFechaRegistro.Name = "ClientesFechaRegistro"
        Me.ClientesFechaRegistro.ReadOnly = True
        '
        'btnrestore
        '
        Me.btnrestore.Location = New System.Drawing.Point(809, 397)
        Me.btnrestore.Name = "btnrestore"
        Me.btnrestore.Size = New System.Drawing.Size(114, 23)
        Me.btnrestore.TabIndex = 46
        Me.btnrestore.Text = "Recuperar"
        Me.btnrestore.UseVisualStyleBackColor = True
        '
        'btndelete
        '
        Me.btndelete.Location = New System.Drawing.Point(809, 368)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(114, 23)
        Me.btndelete.TabIndex = 45
        Me.btndelete.Text = "Eliminar"
        Me.btndelete.UseVisualStyleBackColor = True
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(809, 338)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(114, 23)
        Me.btnActualizar.TabIndex = 44
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'datefecha
        '
        Me.datefecha.Enabled = False
        Me.datefecha.Location = New System.Drawing.Point(92, 185)
        Me.datefecha.Name = "datefecha"
        Me.datefecha.Size = New System.Drawing.Size(200, 20)
        Me.datefecha.TabIndex = 42
        Me.datefecha.Value = New Date(2024, 10, 18, 19, 39, 40, 0)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 188)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 13)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Fecha registro:"
        '
        'txtcorreo
        '
        Me.txtcorreo.Location = New System.Drawing.Point(63, 149)
        Me.txtcorreo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtcorreo.Name = "txtcorreo"
        Me.txtcorreo.Size = New System.Drawing.Size(366, 20)
        Me.txtcorreo.TabIndex = 40
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 152)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Correo:"
        '
        'txtdni
        '
        Me.txtdni.Enabled = False
        Me.txtdni.Location = New System.Drawing.Point(285, 106)
        Me.txtdni.Margin = New System.Windows.Forms.Padding(2)
        Me.txtdni.Name = "txtdni"
        Me.txtdni.Size = New System.Drawing.Size(144, 20)
        Me.txtdni.TabIndex = 38
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(252, 109)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "DNI:"
        '
        'txttelefono
        '
        Me.txttelefono.Location = New System.Drawing.Point(63, 106)
        Me.txttelefono.Margin = New System.Windows.Forms.Padding(2)
        Me.txttelefono.MaxLength = 12
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(144, 20)
        Me.txttelefono.TabIndex = 36
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 109)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Telefono:"
        '
        'txtapellidos
        '
        Me.txtapellidos.Location = New System.Drawing.Point(285, 64)
        Me.txtapellidos.Margin = New System.Windows.Forms.Padding(2)
        Me.txtapellidos.Name = "txtapellidos"
        Me.txtapellidos.Size = New System.Drawing.Size(144, 20)
        Me.txtapellidos.TabIndex = 34
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(232, 67)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Apellidos:"
        '
        'txtnombres
        '
        Me.txtnombres.Location = New System.Drawing.Point(63, 64)
        Me.txtnombres.Margin = New System.Windows.Forms.Padding(2)
        Me.txtnombres.Name = "txtnombres"
        Me.txtnombres.Size = New System.Drawing.Size(144, 20)
        Me.txtnombres.TabIndex = 32
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 67)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Nombres:"
        '
        'txtcodigo
        '
        Me.txtcodigo.Enabled = False
        Me.txtcodigo.Location = New System.Drawing.Point(63, 31)
        Me.txtcodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(144, 20)
        Me.txtcodigo.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 34)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Codigo:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.generarCodigo)
        Me.GroupBox1.Controls.Add(Me.txtcodigo)
        Me.GroupBox1.Controls.Add(Me.txtcorreo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtdni)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txttelefono)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtapellidos)
        Me.GroupBox1.Controls.Add(Me.datefecha)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtnombres)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(442, 281)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Cliente"
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(354, 236)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 44
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'generarCodigo
        '
        Me.generarCodigo.Location = New System.Drawing.Point(206, 28)
        Me.generarCodigo.Name = "generarCodigo"
        Me.generarCodigo.Size = New System.Drawing.Size(60, 23)
        Me.generarCodigo.TabIndex = 43
        Me.generarCodigo.Text = "generar"
        Me.generarCodigo.UseVisualStyleBackColor = True
        '
        'tablaReservas
        '
        Me.tablaReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tablaReservas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column4, Me.Column3, Me.Column2})
        Me.tablaReservas.Location = New System.Drawing.Point(39, 49)
        Me.tablaReservas.Name = "tablaReservas"
        Me.tablaReservas.Size = New System.Drawing.Size(437, 170)
        Me.tablaReservas.TabIndex = 51
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "ReservasCodigo"
        Me.Column1.HeaderText = "Codigo"
        Me.Column1.Name = "Column1"
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "ReservasFechaHoraReserva"
        Me.Column4.HeaderText = "Fecha"
        Me.Column4.Name = "Column4"
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "ReservasEstado"
        Me.Column3.HeaderText = "Estado"
        Me.Column3.Name = "Column3"
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "ReservasMesasCodigo"
        Me.Column2.HeaderText = "Codigo Mesa"
        Me.Column2.Name = "Column2"
        '
        'ReservasBox
        '
        Me.ReservasBox.Controls.Add(Me.tablaReservas)
        Me.ReservasBox.Location = New System.Drawing.Point(510, 31)
        Me.ReservasBox.Name = "ReservasBox"
        Me.ReservasBox.Size = New System.Drawing.Size(492, 281)
        Me.ReservasBox.TabIndex = 52
        Me.ReservasBox.TabStop = False
        Me.ReservasBox.Text = "Reservas del Clientes"
        '
        'frmClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 585)
        Me.Controls.Add(Me.ReservasBox)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tabla)
        Me.Controls.Add(Me.btnrestore)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.btnActualizar)
        Me.Name = "frmClientes"
        Me.Text = "Clientes"
        CType(Me.tabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.tablaReservas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ReservasBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabla As DataGridView
    Friend WithEvents btnrestore As Button
    Friend WithEvents btndelete As Button
    Friend WithEvents btnActualizar As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents txtcorreo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtdni As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txttelefono As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtapellidos As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtnombres As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtcodigo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Private WithEvents datefecha As DateTimePicker
    Friend WithEvents tablaReservas As DataGridView
    Friend WithEvents ReservasBox As GroupBox
    Friend WithEvents generarCodigo As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents ClientesCodigo As DataGridViewTextBoxColumn
    Friend WithEvents Reservas As DataGridViewTextBoxColumn
    Friend WithEvents ClientesNombre As DataGridViewTextBoxColumn
    Friend WithEvents ClientesApellidos As DataGridViewTextBoxColumn
    Friend WithEvents ClientesTelefono As DataGridViewTextBoxColumn
    Friend WithEvents ClientesDNI As DataGridViewTextBoxColumn
    Friend WithEvents ClientesCorreo As DataGridViewTextBoxColumn
    Friend WithEvents ClientesFechaRegistro As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
End Class
