<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_INCO_insertar_registro_sin_listas_de_valores
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
        Me.txtSolucion = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSolucion
        '
        Me.txtSolucion.AccessibleDescription = "Código"
        Me.txtSolucion.BackColor = System.Drawing.SystemColors.Info
        Me.txtSolucion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSolucion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSolucion.Location = New System.Drawing.Point(12, 71)
        Me.txtSolucion.MaxLength = 1
        Me.txtSolucion.Multiline = True
        Me.txtSolucion.Name = "txtSolucion"
        Me.txtSolucion.ReadOnly = True
        Me.txtSolucion.Size = New System.Drawing.Size(538, 116)
        Me.txtSolucion.TabIndex = 43
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.164383!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 93.83562!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(404, 193)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 40
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(23, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(108, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "&Salir"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.AccessibleDescription = "Código"
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(12, 13)
        Me.TextBox1.MaxLength = 1
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(538, 52)
        Me.TextBox1.TabIndex = 44
        Me.TextBox1.Text = "1. ) No se puede ingresar el registro."
        '
        'frm_INCO_insertar_registro_sin_listas_de_valores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(574, 240)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.txtSolucion)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(580, 266)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(580, 266)
        Me.Name = "frm_INCO_insertar_registro_sin_listas_de_valores"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "POSIBLE INCONSISTENCIA"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSolucion As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

End Class
