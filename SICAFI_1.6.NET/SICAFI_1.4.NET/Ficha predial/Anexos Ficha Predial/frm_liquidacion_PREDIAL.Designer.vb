<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_liquidacion_PREDIAL
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtPREDTIRE = New System.Windows.Forms.TextBox
        Me.txtPREDNUDO = New System.Windows.Forms.TextBox
        Me.txtPREDVIGE = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPREDPRED = New System.Windows.Forms.TextBox
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdSALIR)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 99)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(631, 53)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(495, 19)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(110, 23)
        Me.cmdSALIR.TabIndex = 1
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPREDTIRE)
        Me.GroupBox1.Controls.Add(Me.txtPREDNUDO)
        Me.GroupBox1.Controls.Add(Me.txtPREDVIGE)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Location = New System.Drawing.Point(194, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(453, 81)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DOCUMENTO ADMINISTRATIVO"
        '
        'txtPREDTIRE
        '
        Me.txtPREDTIRE.AccessibleDescription = "Tipo de resolución"
        Me.txtPREDTIRE.BackColor = System.Drawing.SystemColors.Window
        Me.txtPREDTIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPREDTIRE.Location = New System.Drawing.Point(19, 45)
        Me.txtPREDTIRE.Name = "txtPREDTIRE"
        Me.txtPREDTIRE.ReadOnly = True
        Me.txtPREDTIRE.Size = New System.Drawing.Size(137, 20)
        Me.txtPREDTIRE.TabIndex = 3
        '
        'txtPREDNUDO
        '
        Me.txtPREDNUDO.AccessibleDescription = "Nro. documento"
        Me.txtPREDNUDO.BackColor = System.Drawing.SystemColors.Window
        Me.txtPREDNUDO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPREDNUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPREDNUDO.ForeColor = System.Drawing.Color.Black
        Me.txtPREDNUDO.Location = New System.Drawing.Point(299, 45)
        Me.txtPREDNUDO.MaxLength = 5
        Me.txtPREDNUDO.Name = "txtPREDNUDO"
        Me.txtPREDNUDO.ReadOnly = True
        Me.txtPREDNUDO.Size = New System.Drawing.Size(137, 20)
        Me.txtPREDNUDO.TabIndex = 5
        '
        'txtPREDVIGE
        '
        Me.txtPREDVIGE.AccessibleDescription = "Vigencia"
        Me.txtPREDVIGE.BackColor = System.Drawing.SystemColors.Window
        Me.txtPREDVIGE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPREDVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPREDVIGE.ForeColor = System.Drawing.Color.Black
        Me.txtPREDVIGE.Location = New System.Drawing.Point(159, 45)
        Me.txtPREDVIGE.MaxLength = 3
        Me.txtPREDVIGE.Name = "txtPREDVIGE"
        Me.txtPREDVIGE.ReadOnly = True
        Me.txtPREDVIGE.Size = New System.Drawing.Size(137, 20)
        Me.txtPREDVIGE.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(299, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 20)
        Me.Label3.TabIndex = 335
        Me.Label3.Text = "Nro. de Documento"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(159, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 20)
        Me.Label7.TabIndex = 334
        Me.Label7.Text = "Vigencia "
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(19, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(137, 20)
        Me.Label12.TabIndex = 336
        Me.Label12.Text = "Tipo de Resolución"
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 168)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(660, 25)
        Me.strBARRESTA.TabIndex = 373
        '
        'tstBAESVALI
        '
        Me.tstBAESVALI.AutoSize = False
        Me.tstBAESVALI.BackColor = System.Drawing.SystemColors.Window
        Me.tstBAESVALI.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tstBAESVALI.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tstBAESVALI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstBAESVALI.ForeColor = System.Drawing.Color.Black
        Me.tstBAESVALI.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.tstBAESVALI.Name = "tstBAESVALI"
        Me.tstBAESVALI.Size = New System.Drawing.Size(125, 22)
        Me.tstBAESVALI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tstBAESDESC
        '
        Me.tstBAESDESC.AutoSize = False
        Me.tstBAESDESC.BackColor = System.Drawing.SystemColors.Window
        Me.tstBAESDESC.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tstBAESDESC.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tstBAESDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstBAESDESC.ForeColor = System.Drawing.Color.Red
        Me.tstBAESDESC.LinkColor = System.Drawing.Color.Black
        Me.tstBAESDESC.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.tstBAESDESC.Name = "tstBAESDESC"
        Me.tstBAESDESC.Size = New System.Drawing.Size(300, 22)
        Me.tstBAESDESC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Window
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(125, 22)
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtPREDPRED)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(172, 81)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "VALOR PREDIAL"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TextBox3)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.TextBox4)
        Me.GroupBox4.Controls.Add(Me.TextBox5)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 193)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(570, 69)
        Me.GroupBox4.TabIndex = 370
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "VARIABLES"
        '
        'TextBox3
        '
        Me.TextBox3.AccessibleDescription = "Coeficiente de edificio"
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.Black
        Me.TextBox3.Location = New System.Drawing.Point(464, 28)
        Me.TextBox3.MaxLength = 10
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(85, 20)
        Me.TextBox3.TabIndex = 368
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(376, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 20)
        Me.Label4.TabIndex = 369
        Me.Label4.Text = "Puntos "
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(24, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 20)
        Me.Label5.TabIndex = 366
        Me.Label5.Text = "Coef. Predio"
        '
        'TextBox4
        '
        Me.TextBox4.AccessibleDescription = "Coeficiente de edificio"
        Me.TextBox4.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.ForeColor = System.Drawing.Color.Black
        Me.TextBox4.Location = New System.Drawing.Point(287, 28)
        Me.TextBox4.MaxLength = 10
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(85, 20)
        Me.TextBox4.TabIndex = 365
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox5
        '
        Me.TextBox5.AccessibleDescription = "Coeficiente de predio"
        Me.TextBox5.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.ForeColor = System.Drawing.Color.Black
        Me.TextBox5.Location = New System.Drawing.Point(113, 28)
        Me.TextBox5.MaxLength = 10
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(84, 20)
        Me.TextBox5.TabIndex = 364
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(200, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 20)
        Me.Label6.TabIndex = 367
        Me.Label6.Text = "Coef. Edificio"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(18, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 20)
        Me.Label2.TabIndex = 333
        Me.Label2.Text = "Valor Predial"
        '
        'txtPREDPRED
        '
        Me.txtPREDPRED.AccessibleDescription = "Valor predial"
        Me.txtPREDPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtPREDPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPREDPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPREDPRED.ForeColor = System.Drawing.Color.Black
        Me.txtPREDPRED.Location = New System.Drawing.Point(18, 45)
        Me.txtPREDPRED.MaxLength = 5
        Me.txtPREDPRED.Name = "txtPREDPRED"
        Me.txtPREDPRED.ReadOnly = True
        Me.txtPREDPRED.Size = New System.Drawing.Size(137, 20)
        Me.txtPREDPRED.TabIndex = 2
        Me.txtPREDPRED.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frm_liquidacion_PREDIAL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 193)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(676, 229)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(676, 229)
        Me.Name = "frm_liquidacion_PREDIAL"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VALOR PREDIAL DE LA FICHA "
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPREDTIRE As System.Windows.Forms.TextBox
    Friend WithEvents txtPREDNUDO As System.Windows.Forms.TextBox
    Friend WithEvents txtPREDVIGE As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPREDPRED As System.Windows.Forms.TextBox
End Class
