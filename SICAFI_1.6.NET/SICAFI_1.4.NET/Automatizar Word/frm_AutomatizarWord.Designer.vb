<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_AutomatizarWord
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
        Me.cmdGenerarArchivoWord = New System.Windows.Forms.Button()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdGenerarArchivoWord
        '
        Me.cmdGenerarArchivoWord.Location = New System.Drawing.Point(334, 148)
        Me.cmdGenerarArchivoWord.Name = "cmdGenerarArchivoWord"
        Me.cmdGenerarArchivoWord.Size = New System.Drawing.Size(157, 23)
        Me.cmdGenerarArchivoWord.TabIndex = 0
        Me.cmdGenerarArchivoWord.Text = "Generar archivo"
        Me.cmdGenerarArchivoWord.UseVisualStyleBackColor = True
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(138, 34)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(353, 20)
        Me.txtNombre.TabIndex = 1
        Me.txtNombre.Text = "Fabio Mejia"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(53, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Direccion"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(53, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Telefono"
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(138, 64)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(353, 20)
        Me.txtDireccion.TabIndex = 5
        Me.txtDireccion.Text = "Cl 64 N 41-41"
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(138, 95)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(353, 20)
        Me.txtTelefono.TabIndex = 6
        Me.txtTelefono.Text = "2910871"
        '
        'frm_AutomatizarWord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 207)
        Me.Controls.Add(Me.txtTelefono)
        Me.Controls.Add(Me.txtDireccion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.cmdGenerarArchivoWord)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_AutomatizarWord"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "AUTOMATIZAR WORD"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdGenerarArchivoWord As System.Windows.Forms.Button
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
End Class
