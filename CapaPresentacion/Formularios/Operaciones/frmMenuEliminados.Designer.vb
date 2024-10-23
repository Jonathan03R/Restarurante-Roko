<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMenuEliminados
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdRecuperar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lvMenu = New System.Windows.Forms.ListView()
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
        Me.Label1.Size = New System.Drawing.Size(706, 51)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Menu Eliminados"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.ImageKey = "IconoAgregar.gif"
        Me.cmdCerrar.Location = New System.Drawing.Point(520, 389)
        Me.cmdCerrar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(119, 39)
        Me.cmdCerrar.TabIndex = 29
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdRecuperar
        '
        Me.cmdRecuperar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRecuperar.ImageKey = "House_48x48-32.gif"
        Me.cmdRecuperar.Location = New System.Drawing.Point(374, 389)
        Me.cmdRecuperar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdRecuperar.Name = "cmdRecuperar"
        Me.cmdRecuperar.Size = New System.Drawing.Size(119, 39)
        Me.cmdRecuperar.TabIndex = 28
        Me.cmdRecuperar.Text = "Recuperar"
        Me.cmdRecuperar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdRecuperar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(35, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(145, 20)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Menu Eliminados"
        '
        'lvMenu
        '
        Me.lvMenu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvMenu.FullRowSelect = True
        Me.lvMenu.GridLines = True
        Me.lvMenu.HideSelection = False
        Me.lvMenu.Location = New System.Drawing.Point(31, 127)
        Me.lvMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lvMenu.Name = "lvMenu"
        Me.lvMenu.Size = New System.Drawing.Size(663, 230)
        Me.lvMenu.TabIndex = 26
        Me.lvMenu.UseCompatibleStateImageBehavior = False
        Me.lvMenu.View = System.Windows.Forms.View.Details
        '
        'frmMenuEliminados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(706, 524)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdRecuperar)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lvMenu)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmMenuEliminados"
        Me.Text = "frmMenuEliminados"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdRecuperar As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents lvMenu As ListView
End Class
