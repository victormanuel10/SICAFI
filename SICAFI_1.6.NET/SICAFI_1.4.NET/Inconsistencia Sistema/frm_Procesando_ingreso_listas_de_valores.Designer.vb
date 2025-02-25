<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Procesando_ingreso_listas_de_valores
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pbPROCESO = New System.Windows.Forms.ProgressBar
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.timPROCESO = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'pbPROCESO
        '
        Me.pbPROCESO.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pbPROCESO.Location = New System.Drawing.Point(12, 59)
        Me.pbPROCESO.Name = "pbPROCESO"
        Me.pbPROCESO.Size = New System.Drawing.Size(474, 17)
        Me.pbPROCESO.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(12, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(474, 10)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "En proceso ......."
        '
        'timPROCESO
        '
        Me.timPROCESO.Enabled = True
        Me.timPROCESO.Interval = 1
        '
        'frm_Procesando_ingreso_listas_de_valores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(490, 98)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pbPROCESO)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(506, 134)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(506, 134)
        Me.Name = "frm_Procesando_ingreso_listas_de_valores"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INSERTAR REGISTROS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbPROCESO As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents timPROCESO As System.Windows.Forms.Timer
End Class
