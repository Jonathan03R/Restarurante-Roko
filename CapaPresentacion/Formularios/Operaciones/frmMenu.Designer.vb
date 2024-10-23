<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenu
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
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.dgvMenu = New System.Windows.Forms.DataGridView()
        Me.btnCargarImagen = New System.Windows.Forms.Button()
        Me.txtMenuPrecio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.picMenuFoto = New System.Windows.Forms.PictureBox()
        Me.txtMenuDescripcion = New System.Windows.Forms.RichTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMenuNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMenuCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgvMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMenuFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnMostrarEliminados
        '
        Me.btnMostrarEliminados.Location = New System.Drawing.Point(593, 137)
        Me.btnMostrarEliminados.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMostrarEliminados.Name = "btnMostrarEliminados"
        Me.btnMostrarEliminados.Size = New System.Drawing.Size(115, 19)
        Me.btnMostrarEliminados.TabIndex = 37
        Me.btnMostrarEliminados.Text = "Mostrar eliminados"
        Me.btnMostrarEliminados.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(593, 79)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(115, 19)
        Me.btnEliminar.TabIndex = 34
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(593, 56)
        Me.btnActualizar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(115, 19)
        Me.btnActualizar.TabIndex = 33
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(593, 35)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(115, 19)
        Me.btnGuardar.TabIndex = 32
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'dgvMenu
        '
        Me.dgvMenu.AllowUserToAddRows = False
        Me.dgvMenu.AllowUserToDeleteRows = False
        Me.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMenu.Location = New System.Drawing.Point(22, 220)
        Me.dgvMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvMenu.Name = "dgvMenu"
        Me.dgvMenu.ReadOnly = True
        Me.dgvMenu.RowHeadersWidth = 51
        Me.dgvMenu.RowTemplate.Height = 24
        Me.dgvMenu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMenu.Size = New System.Drawing.Size(475, 220)
        Me.dgvMenu.TabIndex = 31
        '
        'btnCargarImagen
        '
        Me.btnCargarImagen.Location = New System.Drawing.Point(513, 189)
        Me.btnCargarImagen.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCargarImagen.Name = "btnCargarImagen"
        Me.btnCargarImagen.Size = New System.Drawing.Size(56, 19)
        Me.btnCargarImagen.TabIndex = 29
        Me.btnCargarImagen.Text = "Buscar"
        Me.btnCargarImagen.UseVisualStyleBackColor = True
        '
        'txtMenuPrecio
        '
        Me.txtMenuPrecio.Location = New System.Drawing.Point(89, 144)
        Me.txtMenuPrecio.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMenuPrecio.Name = "txtMenuPrecio"
        Me.txtMenuPrecio.Size = New System.Drawing.Size(168, 20)
        Me.txtMenuPrecio.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 149)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Precio"
        '
        'picMenuFoto
        '
        Me.picMenuFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picMenuFoto.Location = New System.Drawing.Point(346, 11)
        Me.picMenuFoto.Margin = New System.Windows.Forms.Padding(2)
        Me.picMenuFoto.Name = "picMenuFoto"
        Me.picMenuFoto.Size = New System.Drawing.Size(223, 174)
        Me.picMenuFoto.TabIndex = 26
        Me.picMenuFoto.TabStop = False
        '
        'txtMenuDescripcion
        '
        Me.txtMenuDescripcion.Location = New System.Drawing.Point(89, 59)
        Me.txtMenuDescripcion.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMenuDescripcion.Name = "txtMenuDescripcion"
        Me.txtMenuDescripcion.Size = New System.Drawing.Size(168, 79)
        Me.txtMenuDescripcion.TabIndex = 25
        Me.txtMenuDescripcion.Text = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 59)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Descripcion"
        '
        'txtMenuNombre
        '
        Me.txtMenuNombre.Location = New System.Drawing.Point(89, 33)
        Me.txtMenuNombre.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMenuNombre.Name = "txtMenuNombre"
        Me.txtMenuNombre.Size = New System.Drawing.Size(168, 20)
        Me.txtMenuNombre.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 38)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Nombre"
        '
        'txtMenuCodigo
        '
        Me.txtMenuCodigo.Enabled = False
        Me.txtMenuCodigo.Location = New System.Drawing.Point(89, 11)
        Me.txtMenuCodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMenuCodigo.Name = "txtMenuCodigo"
        Me.txtMenuCodigo.Size = New System.Drawing.Size(168, 20)
        Me.txtMenuCodigo.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Codigo"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(253, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 39
        Me.Button1.Text = "generar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 502)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnMostrarEliminados)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.dgvMenu)
        Me.Controls.Add(Me.btnCargarImagen)
        Me.Controls.Add(Me.txtMenuPrecio)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.picMenuFoto)
        Me.Controls.Add(Me.txtMenuDescripcion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMenuNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMenuCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmMenu"
        Me.Text = "Menu"
        CType(Me.dgvMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMenuFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnMostrarEliminados As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnActualizar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents dgvMenu As DataGridView
    Friend WithEvents btnCargarImagen As Button
    Friend WithEvents txtMenuPrecio As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents picMenuFoto As PictureBox
    Friend WithEvents txtMenuDescripcion As RichTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtMenuNombre As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtMenuCodigo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
End Class
