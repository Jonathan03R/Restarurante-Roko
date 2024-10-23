<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpleados
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
        Me.btndelete = New System.Windows.Forms.Button()
        Me.btnupdate = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.tabla = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Telefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sexo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Entrada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_constratacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Salario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtsalario = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dateContratacion = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtentrada = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.comboSexo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txttelefono = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtApellidoPaterno = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtnombres = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtApellidoMaterno = New System.Windows.Forms.TextBox()
        Me.btnGenerarCodigo = New System.Windows.Forms.Button()
        Me.comboRoles = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.tabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnMostrarEliminados
        '
        Me.btnMostrarEliminados.Location = New System.Drawing.Point(689, 131)
        Me.btnMostrarEliminados.Name = "btnMostrarEliminados"
        Me.btnMostrarEliminados.Size = New System.Drawing.Size(123, 23)
        Me.btnMostrarEliminados.TabIndex = 53
        Me.btnMostrarEliminados.Text = "Mostrar eliminados"
        Me.btnMostrarEliminados.UseVisualStyleBackColor = True
        '
        'btndelete
        '
        Me.btndelete.Location = New System.Drawing.Point(689, 97)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(123, 23)
        Me.btndelete.TabIndex = 50
        Me.btndelete.Text = "Eliminar"
        Me.btndelete.UseVisualStyleBackColor = True
        '
        'btnupdate
        '
        Me.btnupdate.Location = New System.Drawing.Point(688, 65)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(123, 23)
        Me.btnupdate.TabIndex = 49
        Me.btnupdate.Text = "Actualizar"
        Me.btnupdate.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(688, 36)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(123, 23)
        Me.btnsave.TabIndex = 48
        Me.btnsave.Text = "Guardar"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'tabla
        '
        Me.tabla.AllowUserToAddRows = False
        Me.tabla.AllowUserToDeleteRows = False
        Me.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tabla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Nombres, Me.Telefono, Me.Sexo, Me.Cargo, Me.Entrada, Me.Fecha_constratacion, Me.Salario})
        Me.tabla.Location = New System.Drawing.Point(39, 313)
        Me.tabla.MultiSelect = False
        Me.tabla.Name = "tabla"
        Me.tabla.ReadOnly = True
        Me.tabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tabla.Size = New System.Drawing.Size(773, 257)
        Me.tabla.TabIndex = 47
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        '
        'Nombres
        '
        Me.Nombres.HeaderText = "Nombres Completos"
        Me.Nombres.Name = "Nombres"
        Me.Nombres.ReadOnly = True
        Me.Nombres.Width = 200
        '
        'Telefono
        '
        Me.Telefono.HeaderText = "Telefono"
        Me.Telefono.Name = "Telefono"
        Me.Telefono.ReadOnly = True
        '
        'Sexo
        '
        Me.Sexo.HeaderText = "Sexo"
        Me.Sexo.Name = "Sexo"
        Me.Sexo.ReadOnly = True
        '
        'Cargo
        '
        Me.Cargo.HeaderText = "Cargo"
        Me.Cargo.Name = "Cargo"
        Me.Cargo.ReadOnly = True
        '
        'Entrada
        '
        Me.Entrada.HeaderText = "Entrada"
        Me.Entrada.Name = "Entrada"
        Me.Entrada.ReadOnly = True
        '
        'Fecha_constratacion
        '
        Me.Fecha_constratacion.HeaderText = "Fecha constratacion"
        Me.Fecha_constratacion.Name = "Fecha_constratacion"
        Me.Fecha_constratacion.ReadOnly = True
        '
        'Salario
        '
        Me.Salario.HeaderText = "Salario"
        Me.Salario.Name = "Salario"
        Me.Salario.ReadOnly = True
        '
        'txtsalario
        '
        Me.txtsalario.Location = New System.Drawing.Point(138, 170)
        Me.txtsalario.Name = "txtsalario"
        Me.txtsalario.Size = New System.Drawing.Size(159, 20)
        Me.txtsalario.TabIndex = 46
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(37, 173)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Salario"
        '
        'dateContratacion
        '
        Me.dateContratacion.Enabled = False
        Me.dateContratacion.Location = New System.Drawing.Point(138, 212)
        Me.dateContratacion.Name = "dateContratacion"
        Me.dateContratacion.Size = New System.Drawing.Size(200, 20)
        Me.dateContratacion.TabIndex = 44
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(37, 215)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 13)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "Fecha contratacion"
        '
        'txtentrada
        '
        Me.txtentrada.Location = New System.Drawing.Point(138, 134)
        Me.txtentrada.Name = "txtentrada"
        Me.txtentrada.Size = New System.Drawing.Size(159, 20)
        Me.txtentrada.TabIndex = 42
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(37, 137)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "Hora entrada"
        '
        'comboSexo
        '
        Me.comboSexo.DisplayMember = "F"
        Me.comboSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboSexo.FormattingEnabled = True
        Me.comboSexo.Items.AddRange(New Object() {"F", "M"})
        Me.comboSexo.Location = New System.Drawing.Point(442, 141)
        Me.comboSexo.Name = "comboSexo"
        Me.comboSexo.Size = New System.Drawing.Size(159, 21)
        Me.comboSexo.TabIndex = 36
        Me.comboSexo.Tag = ""
        Me.comboSexo.ValueMember = "F"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(358, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Sexo"
        '
        'txttelefono
        '
        Me.txttelefono.Location = New System.Drawing.Point(138, 104)
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(159, 20)
        Me.txttelefono.TabIndex = 34
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(37, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Telefono"
        '
        'txtApellidoPaterno
        '
        Me.txtApellidoPaterno.Location = New System.Drawing.Point(138, 70)
        Me.txtApellidoPaterno.Name = "txtApellidoPaterno"
        Me.txtApellidoPaterno.Size = New System.Drawing.Size(159, 20)
        Me.txtApellidoPaterno.TabIndex = 32
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Apellido Paterno"
        '
        'txtnombres
        '
        Me.txtnombres.Location = New System.Drawing.Point(442, 67)
        Me.txtnombres.Name = "txtnombres"
        Me.txtnombres.Size = New System.Drawing.Size(159, 20)
        Me.txtnombres.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(358, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Nombres"
        '
        'txtcodigo
        '
        Me.txtcodigo.Enabled = False
        Me.txtcodigo.Location = New System.Drawing.Point(138, 36)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(159, 20)
        Me.txtcodigo.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Codigo"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(358, 105)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Apellido Materno"
        '
        'txtApellidoMaterno
        '
        Me.txtApellidoMaterno.Location = New System.Drawing.Point(442, 102)
        Me.txtApellidoMaterno.Name = "txtApellidoMaterno"
        Me.txtApellidoMaterno.Size = New System.Drawing.Size(159, 20)
        Me.txtApellidoMaterno.TabIndex = 32
        '
        'btnGenerarCodigo
        '
        Me.btnGenerarCodigo.Location = New System.Drawing.Point(294, 34)
        Me.btnGenerarCodigo.Name = "btnGenerarCodigo"
        Me.btnGenerarCodigo.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerarCodigo.TabIndex = 54
        Me.btnGenerarCodigo.Text = "generar"
        Me.btnGenerarCodigo.UseVisualStyleBackColor = True
        '
        'comboRoles
        '
        Me.comboRoles.FormattingEnabled = True
        Me.comboRoles.Location = New System.Drawing.Point(442, 188)
        Me.comboRoles.Name = "comboRoles"
        Me.comboRoles.Size = New System.Drawing.Size(159, 21)
        Me.comboRoles.TabIndex = 55
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(358, 196)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Roles"
        '
        'frmEmpleados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 611)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.comboRoles)
        Me.Controls.Add(Me.btnGenerarCodigo)
        Me.Controls.Add(Me.btnMostrarEliminados)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.btnupdate)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.tabla)
        Me.Controls.Add(Me.txtsalario)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.dateContratacion)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtentrada)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.comboSexo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txttelefono)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtApellidoMaterno)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtApellidoPaterno)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtnombres)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtcodigo)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmEmpleados"
        Me.Text = "Empleados"
        CType(Me.tabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnMostrarEliminados As Button
    Friend WithEvents btndelete As Button
    Friend WithEvents btnupdate As Button
    Friend WithEvents btnsave As Button
    Friend WithEvents tabla As DataGridView
    Friend WithEvents txtsalario As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents dateContratacion As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents txtentrada As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents comboSexo As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txttelefono As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtApellidoPaterno As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtnombres As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtcodigo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtApellidoMaterno As TextBox
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents Nombres As DataGridViewTextBoxColumn
    Friend WithEvents Telefono As DataGridViewTextBoxColumn
    Friend WithEvents Sexo As DataGridViewTextBoxColumn
    Friend WithEvents Cargo As DataGridViewTextBoxColumn
    Friend WithEvents Entrada As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_constratacion As DataGridViewTextBoxColumn
    Friend WithEvents Salario As DataGridViewTextBoxColumn
    Friend WithEvents btnGenerarCodigo As Button
    Friend WithEvents comboRoles As ComboBox
    Friend WithEvents Label7 As Label
End Class
