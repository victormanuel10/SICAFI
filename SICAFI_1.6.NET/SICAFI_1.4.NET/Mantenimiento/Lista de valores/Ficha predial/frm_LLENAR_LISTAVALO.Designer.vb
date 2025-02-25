<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_LLENAR_LISTAVALO
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdCANCELAR = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.cboLISTVALO = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboLISTVALO)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(521, 88)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "LISTA DE VALORES"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.cmdCANCELAR)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 106)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(521, 48)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'cmdCANCELAR
        '
        Me.cmdCANCELAR.AccessibleDescription = "Cancelar"
        Me.cmdCANCELAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCANCELAR.Image = Global.SICAFI.My.Resources.Resources._147
        Me.cmdCANCELAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCANCELAR.Location = New System.Drawing.Point(249, 13)
        Me.cmdCANCELAR.Name = "cmdCANCELAR"
        Me.cmdCANCELAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdCANCELAR.TabIndex = 29
        Me.cmdCANCELAR.Text = "&Cancelar"
        Me.cmdCANCELAR.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.AccessibleDescription = "Cancelar"
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Image = Global.SICAFI.My.Resources.Resources._208
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(142, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 23)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "&Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cboLISTVALO
        '
        Me.cboLISTVALO.AccessibleDescription = "Lista de valores"
        Me.cboLISTVALO.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboLISTVALO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboLISTVALO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLISTVALO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLISTVALO.Items.AddRange(New Object() {"Departamento", "Municipio", "Notaria", "Clase o sector", "Categoria de suelo"})
        Me.cboLISTVALO.Location = New System.Drawing.Point(17, 33)
        Me.cboLISTVALO.MaxDropDownItems = 15
        Me.cboLISTVALO.MaxLength = 1
        Me.cboLISTVALO.Name = "cboLISTVALO"
        Me.cboLISTVALO.Size = New System.Drawing.Size(480, 22)
        Me.cboLISTVALO.TabIndex = 14
        '
        'frm_LLENAR_LISTAVALO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 169)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frm_LLENAR_LISTAVALO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de valores ficha predial"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCANCELAR As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cboLISTVALO As System.Windows.Forms.ComboBox
End Class
