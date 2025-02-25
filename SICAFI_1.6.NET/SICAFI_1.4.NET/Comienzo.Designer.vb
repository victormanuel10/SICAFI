<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Comienzo
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
        Me.cmdConvertir = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdConvertir
        '
        Me.cmdConvertir.Location = New System.Drawing.Point(137, 97)
        Me.cmdConvertir.Name = "cmdConvertir"
        Me.cmdConvertir.Size = New System.Drawing.Size(303, 51)
        Me.cmdConvertir.TabIndex = 1
        Me.cmdConvertir.Text = "Convertir Word a PDF"
        Me.cmdConvertir.UseVisualStyleBackColor = True
        '
        'Comienzo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 299)
        Me.Controls.Add(Me.cmdConvertir)
        Me.Name = "Comienzo"
        Me.Text = "Comienzo"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdConvertir As System.Windows.Forms.Button
End Class
