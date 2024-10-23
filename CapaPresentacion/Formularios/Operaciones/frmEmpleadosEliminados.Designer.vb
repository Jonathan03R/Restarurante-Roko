<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpleadosEliminados
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdRecuperar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lvEmpleados = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Lime
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(972, 51)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Empleados Eliminados"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.ImageKey = "IconoAgregar.gif"
        Me.cmdCerrar.Location = New System.Drawing.Point(784, 372)
        Me.cmdCerrar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(119, 39)
        Me.cmdCerrar.TabIndex = 25
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdRecuperar
        '
        Me.cmdRecuperar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRecuperar.ImageKey = "House_48x48-32.gif"
        Me.cmdRecuperar.Location = New System.Drawing.Point(638, 372)
        Me.cmdRecuperar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdRecuperar.Name = "cmdRecuperar"
        Me.cmdRecuperar.Size = New System.Drawing.Size(119, 39)
        Me.cmdRecuperar.TabIndex = 24
        Me.cmdRecuperar.Text = "Recuperar"
        Me.cmdRecuperar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdRecuperar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(52, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(188, 20)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Empleados eliminados"
        '
        'lvEmpleados
        '
        Me.lvEmpleados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvEmpleados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvEmpleados.FullRowSelect = True
        Me.lvEmpleados.GridLines = True
        Me.lvEmpleados.HideSelection = False
        Me.lvEmpleados.Location = New System.Drawing.Point(48, 110)
        Me.lvEmpleados.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lvEmpleados.Name = "lvEmpleados"
        Me.lvEmpleados.Size = New System.Drawing.Size(891, 230)
        Me.lvEmpleados.TabIndex = 22
        Me.lvEmpleados.UseCompatibleStateImageBehavior = False
        Me.lvEmpleados.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Apellidos y nombres"
        Me.ColumnHeader2.Width = 417
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Fecha Contratacion"
        Me.ColumnHeader3.Width = 223
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Cargo"
        Me.ColumnHeader4.Width = 100
        '
        'frmEmpleadosEliminados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 457)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdRecuperar)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lvEmpleados)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmEmpleadosEliminados"
        Me.Text = "frmEmpleadosEliminados"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdRecuperar As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents lvEmpleados As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
End Class
