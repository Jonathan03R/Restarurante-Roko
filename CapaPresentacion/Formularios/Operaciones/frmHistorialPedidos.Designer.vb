<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistorialPedidos
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
        Me.dgvHistorialPedidos = New System.Windows.Forms.DataGridView()
        Me.chkCompletado = New System.Windows.Forms.CheckBox()
        Me.chkPendiente = New System.Windows.Forms.CheckBox()
        CType(Me.dgvHistorialPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvHistorialPedidos
        '
        Me.dgvHistorialPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHistorialPedidos.Location = New System.Drawing.Point(39, 73)
        Me.dgvHistorialPedidos.Name = "dgvHistorialPedidos"
        Me.dgvHistorialPedidos.Size = New System.Drawing.Size(733, 567)
        Me.dgvHistorialPedidos.TabIndex = 0
        '
        'chkCompletado
        '
        Me.chkCompletado.AutoSize = True
        Me.chkCompletado.Location = New System.Drawing.Point(39, 29)
        Me.chkCompletado.Name = "chkCompletado"
        Me.chkCompletado.Size = New System.Drawing.Size(87, 17)
        Me.chkCompletado.TabIndex = 1
        Me.chkCompletado.Text = "Completados"
        Me.chkCompletado.UseVisualStyleBackColor = True
        '
        'chkPendiente
        '
        Me.chkPendiente.AutoSize = True
        Me.chkPendiente.Location = New System.Drawing.Point(142, 29)
        Me.chkPendiente.Name = "chkPendiente"
        Me.chkPendiente.Size = New System.Drawing.Size(79, 17)
        Me.chkPendiente.TabIndex = 2
        Me.chkPendiente.Text = "Pendientes"
        Me.chkPendiente.UseVisualStyleBackColor = True
        '
        'frmHistorialPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 729)
        Me.Controls.Add(Me.chkPendiente)
        Me.Controls.Add(Me.chkCompletado)
        Me.Controls.Add(Me.dgvHistorialPedidos)
        Me.Name = "frmHistorialPedidos"
        Me.Text = "frmHistorialPedidos"
        CType(Me.dgvHistorialPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvHistorialPedidos As DataGridView
    Friend WithEvents chkCompletado As CheckBox
    Friend WithEvents chkPendiente As CheckBox
End Class
