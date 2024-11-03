<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagosHistorial
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
        Me.dgvDocumentos = New System.Windows.Forms.DataGridView()
        Me.DocumentoCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocumentoReferencias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocumentoTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocumentoFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAbrirPDF = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDocumentos
        '
        Me.dgvDocumentos.AllowUserToAddRows = False
        Me.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDocumentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DocumentoCodigo, Me.DocumentoReferencias, Me.DocumentoTipo, Me.DocumentoFecha, Me.btnAbrirPDF})
        Me.dgvDocumentos.Location = New System.Drawing.Point(119, 116)
        Me.dgvDocumentos.Name = "dgvDocumentos"
        Me.dgvDocumentos.Size = New System.Drawing.Size(793, 403)
        Me.dgvDocumentos.TabIndex = 0
        '
        'DocumentoCodigo
        '
        Me.DocumentoCodigo.DataPropertyName = "DocumentoCodigo"
        Me.DocumentoCodigo.HeaderText = "Codigo documento"
        Me.DocumentoCodigo.Name = "DocumentoCodigo"
        Me.DocumentoCodigo.Width = 150
        '
        'DocumentoReferencias
        '
        Me.DocumentoReferencias.DataPropertyName = "DocumentoReferencias"
        Me.DocumentoReferencias.HeaderText = "Codigo Comprobante"
        Me.DocumentoReferencias.Name = "DocumentoReferencias"
        Me.DocumentoReferencias.Width = 150
        '
        'DocumentoTipo
        '
        Me.DocumentoTipo.DataPropertyName = "DocumentoTipo"
        Me.DocumentoTipo.HeaderText = "Tipo de documento"
        Me.DocumentoTipo.Name = "DocumentoTipo"
        Me.DocumentoTipo.Width = 200
        '
        'DocumentoFecha
        '
        Me.DocumentoFecha.DataPropertyName = "DocumentoFecha"
        Me.DocumentoFecha.HeaderText = "Fecha de emision"
        Me.DocumentoFecha.Name = "DocumentoFecha"
        Me.DocumentoFecha.Width = 150
        '
        'btnAbrirPDF
        '
        Me.btnAbrirPDF.HeaderText = "pdf"
        Me.btnAbrirPDF.Image = Global.Restarurante_Roko.My.Resources.Resources.pdf
        Me.btnAbrirPDF.Name = "btnAbrirPDF"
        Me.btnAbrirPDF.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btnAbrirPDF.ToolTipText = "clic para ver pdf"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1058, 51)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Pagos del año 2024"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmPagosHistorial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1058, 599)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvDocumentos)
        Me.Name = "frmPagosHistorial"
        Me.Text = "frmPagosHistorial"
        CType(Me.dgvDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvDocumentos As DataGridView
    Friend WithEvents DocumentoCodigo As DataGridViewTextBoxColumn
    Friend WithEvents DocumentoReferencias As DataGridViewTextBoxColumn
    Friend WithEvents DocumentoTipo As DataGridViewTextBoxColumn
    Friend WithEvents DocumentoFecha As DataGridViewTextBoxColumn
    Friend WithEvents btnAbrirPDF As DataGridViewImageColumn
    Friend WithEvents Label1 As Label
End Class
