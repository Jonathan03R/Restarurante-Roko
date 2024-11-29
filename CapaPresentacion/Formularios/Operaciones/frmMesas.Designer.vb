<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMesas
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
        Me.mostrar = New System.Windows.Forms.Button()
        Me.mostrarEliminados = New System.Windows.Forms.Button()
        Me.tablaMesas = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Capacidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnrestore = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.btnupdate = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.txtcapacidad = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.tablaMesas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mostrar
        '
        Me.mostrar.Location = New System.Drawing.Point(326, 198)
        Me.mostrar.Margin = New System.Windows.Forms.Padding(2)
        Me.mostrar.Name = "mostrar"
        Me.mostrar.Size = New System.Drawing.Size(110, 19)
        Me.mostrar.TabIndex = 21
        Me.mostrar.Text = "Mostrar tabla"
        Me.mostrar.UseVisualStyleBackColor = True
        '
        'mostrarEliminados
        '
        Me.mostrarEliminados.Location = New System.Drawing.Point(326, 174)
        Me.mostrarEliminados.Margin = New System.Windows.Forms.Padding(2)
        Me.mostrarEliminados.Name = "mostrarEliminados"
        Me.mostrarEliminados.Size = New System.Drawing.Size(110, 19)
        Me.mostrarEliminados.TabIndex = 20
        Me.mostrarEliminados.Text = "Mostrar eliminados"
        Me.mostrarEliminados.UseVisualStyleBackColor = True
        '
        'tablaMesas
        '
        Me.tablaMesas.AllowUserToAddRows = False
        Me.tablaMesas.AllowUserToDeleteRows = False
        Me.tablaMesas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tablaMesas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Capacidad, Me.Column1})
        Me.tablaMesas.Location = New System.Drawing.Point(37, 220)
        Me.tablaMesas.Margin = New System.Windows.Forms.Padding(2)
        Me.tablaMesas.MultiSelect = False
        Me.tablaMesas.Name = "tablaMesas"
        Me.tablaMesas.ReadOnly = True
        Me.tablaMesas.RowHeadersWidth = 51
        Me.tablaMesas.RowTemplate.Height = 24
        Me.tablaMesas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tablaMesas.Size = New System.Drawing.Size(404, 154)
        Me.tablaMesas.TabIndex = 19
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "codigo"
        Me.Codigo.MinimumWidth = 6
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 125
        '
        'Capacidad
        '
        Me.Capacidad.HeaderText = "capacidad"
        Me.Capacidad.MinimumWidth = 6
        Me.Capacidad.Name = "Capacidad"
        Me.Capacidad.ReadOnly = True
        Me.Capacidad.Width = 125
        '
        'Column1
        '
        Me.Column1.HeaderText = "Estado"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'btnrestore
        '
        Me.btnrestore.Location = New System.Drawing.Point(331, 100)
        Me.btnrestore.Margin = New System.Windows.Forms.Padding(2)
        Me.btnrestore.Name = "btnrestore"
        Me.btnrestore.Size = New System.Drawing.Size(110, 19)
        Me.btnrestore.TabIndex = 18
        Me.btnrestore.Text = "Recuperar"
        Me.btnrestore.UseVisualStyleBackColor = True
        '
        'btndelete
        '
        Me.btndelete.Location = New System.Drawing.Point(331, 77)
        Me.btndelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(110, 19)
        Me.btndelete.TabIndex = 17
        Me.btndelete.Text = "Eliminar"
        Me.btndelete.UseVisualStyleBackColor = True
        '
        'btnupdate
        '
        Me.btnupdate.Location = New System.Drawing.Point(331, 53)
        Me.btnupdate.Margin = New System.Windows.Forms.Padding(2)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(110, 19)
        Me.btnupdate.TabIndex = 16
        Me.btnupdate.Text = "Actualizar"
        Me.btnupdate.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(331, 30)
        Me.btnsave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(110, 19)
        Me.btnsave.TabIndex = 15
        Me.btnsave.Text = "Agregar"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'txtcapacidad
        '
        Me.txtcapacidad.Location = New System.Drawing.Point(105, 51)
        Me.txtcapacidad.Margin = New System.Windows.Forms.Padding(2)
        Me.txtcapacidad.Name = "txtcapacidad"
        Me.txtcapacidad.Size = New System.Drawing.Size(164, 20)
        Me.txtcapacidad.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 51)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Capacidad"
        '
        'txtcodigo
        '
        Me.txtcodigo.Location = New System.Drawing.Point(105, 29)
        Me.txtcodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(164, 20)
        Me.txtcodigo.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 29)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Codigo"
        '
        'frmMesas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 419)
        Me.Controls.Add(Me.mostrar)
        Me.Controls.Add(Me.mostrarEliminados)
        Me.Controls.Add(Me.tablaMesas)
        Me.Controls.Add(Me.btnrestore)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.btnupdate)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.txtcapacidad)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtcodigo)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmMesas"
        Me.Text = "Mesas Reservadas"
        CType(Me.tablaMesas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mostrar As Button
    Friend WithEvents mostrarEliminados As Button
    Friend WithEvents tablaMesas As DataGridView
    Friend WithEvents btnrestore As Button
    Friend WithEvents btndelete As Button
    Friend WithEvents btnupdate As Button
    Friend WithEvents btnsave As Button
    Friend WithEvents txtcapacidad As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtcodigo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents Capacidad As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
End Class
