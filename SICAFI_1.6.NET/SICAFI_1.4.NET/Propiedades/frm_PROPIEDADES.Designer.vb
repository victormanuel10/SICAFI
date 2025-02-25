<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_PROPIEDADES
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.computerInfoPropertyGrid = New System.Windows.Forms.PropertyGrid()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.computerInfoPropertyGrid)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(514, 314)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PROPIEDADES"
        '
        'computerInfoPropertyGrid
        '
        Me.computerInfoPropertyGrid.HelpVisible = False
        Me.computerInfoPropertyGrid.Location = New System.Drawing.Point(17, 28)
        Me.computerInfoPropertyGrid.Name = "computerInfoPropertyGrid"
        Me.computerInfoPropertyGrid.Size = New System.Drawing.Size(479, 268)
        Me.computerInfoPropertyGrid.TabIndex = 11
        '
        'cmdSALIR
        '
        Me.cmdSALIR.Location = New System.Drawing.Point(424, 342)
        Me.cmdSALIR.MaximumSize = New System.Drawing.Size(102, 23)
        Me.cmdSALIR.MinimumSize = New System.Drawing.Size(102, 23)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(102, 23)
        Me.cmdSALIR.TabIndex = 1
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'frm_PROPIEDADES
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 377)
        Me.Controls.Add(Me.cmdSALIR)
        Me.Controls.Add(Me.GroupBox1)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(554, 413)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(554, 413)
        Me.Name = "frm_PROPIEDADES"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "PROPIEDADES DEL SISTEMA"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents computerInfoPropertyGrid As System.Windows.Forms.PropertyGrid
End Class
