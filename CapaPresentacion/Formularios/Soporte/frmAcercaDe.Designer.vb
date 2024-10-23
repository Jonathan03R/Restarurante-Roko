<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAcercaDe
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
        Me.LabelAcercaDe = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelAcercaDe
        '
        Me.LabelAcercaDe.AutoSize = True
        Me.LabelAcercaDe.Location = New System.Drawing.Point(84, 41)
        Me.LabelAcercaDe.Name = "LabelAcercaDe"
        Me.LabelAcercaDe.Size = New System.Drawing.Size(39, 13)
        Me.LabelAcercaDe.TabIndex = 0
        Me.LabelAcercaDe.Text = "Label1"
        '
        'frmAcercaDe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.LabelAcercaDe)
        Me.Name = "frmAcercaDe"
        Me.Text = "frmAcercaDe"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelAcercaDe As Label
End Class
