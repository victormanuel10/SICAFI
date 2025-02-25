<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_CALIPROP
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
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.fraCALIPROP = New System.Windows.Forms.GroupBox
        Me.cboCAPRESTA = New System.Windows.Forms.ComboBox
        Me.lblCAPRESTA = New System.Windows.Forms.Label
        Me.txtCAPRDESC = New System.Windows.Forms.TextBox
        Me.txtCAPRCODI = New System.Windows.Forms.TextBox
        Me.lblCAPRDESC = New System.Windows.Forms.Label
        Me.lblCAPRCODI = New System.Windows.Forms.Label
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.cmdGUARDARR = New System.Windows.Forms.Button
        Me.fraCOMANDOS = New System.Windows.Forms.GroupBox
        Me.strBARRESTA.SuspendLayout()
        Me.fraCALIPROP.SuspendLayout()
        Me.fraCOMANDOS.SuspendLayout()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 160)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(608, 25)
        Me.strBARRESTA.TabIndex = 29
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
        'fraCALIPROP
        '
        Me.fraCALIPROP.BackColor = System.Drawing.SystemColors.Control
        Me.fraCALIPROP.Controls.Add(Me.cboCAPRESTA)
        Me.fraCALIPROP.Controls.Add(Me.lblCAPRESTA)
        Me.fraCALIPROP.Controls.Add(Me.txtCAPRDESC)
        Me.fraCALIPROP.Controls.Add(Me.txtCAPRCODI)
        Me.fraCALIPROP.Controls.Add(Me.lblCAPRDESC)
        Me.fraCALIPROP.Controls.Add(Me.lblCAPRCODI)
        Me.fraCALIPROP.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraCALIPROP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraCALIPROP.Location = New System.Drawing.Point(18, 7)
        Me.fraCALIPROP.Name = "fraCALIPROP"
        Me.fraCALIPROP.Size = New System.Drawing.Size(572, 87)
        Me.fraCALIPROP.TabIndex = 0
        Me.fraCALIPROP.TabStop = False
        Me.fraCALIPROP.Text = "INSERTAR CALIDAD DE PROPIETARIO"
        '
        'cboCAPRESTA
        '
        Me.cboCAPRESTA.AccessibleDescription = "Estado"
        Me.cboCAPRESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCAPRESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCAPRESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCAPRESTA.FormattingEnabled = True
        Me.cboCAPRESTA.Items.AddRange(New Object() {""})
        Me.cboCAPRESTA.Location = New System.Drawing.Point(461, 49)
        Me.cboCAPRESTA.Name = "cboCAPRESTA"
        Me.cboCAPRESTA.Size = New System.Drawing.Size(91, 22)
        Me.cboCAPRESTA.TabIndex = 3
        '
        'lblCAPRESTA
        '
        Me.lblCAPRESTA.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCAPRESTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAPRESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAPRESTA.ForeColor = System.Drawing.Color.Black
        Me.lblCAPRESTA.Location = New System.Drawing.Point(461, 26)
        Me.lblCAPRESTA.Name = "lblCAPRESTA"
        Me.lblCAPRESTA.Size = New System.Drawing.Size(90, 20)
        Me.lblCAPRESTA.TabIndex = 41
        Me.lblCAPRESTA.Text = "Estado"
        '
        'txtCAPRDESC
        '
        Me.txtCAPRDESC.AccessibleDescription = "Descripción"
        Me.txtCAPRDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtCAPRDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCAPRDESC.Location = New System.Drawing.Point(107, 49)
        Me.txtCAPRDESC.MaxLength = 50
        Me.txtCAPRDESC.Name = "txtCAPRDESC"
        Me.txtCAPRDESC.Size = New System.Drawing.Size(351, 20)
        Me.txtCAPRDESC.TabIndex = 2
        '
        'txtCAPRCODI
        '
        Me.txtCAPRCODI.AccessibleDescription = "Código"
        Me.txtCAPRCODI.BackColor = System.Drawing.SystemColors.Window
        Me.txtCAPRCODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCAPRCODI.Location = New System.Drawing.Point(19, 49)
        Me.txtCAPRCODI.MaxLength = 2
        Me.txtCAPRCODI.Name = "txtCAPRCODI"
        Me.txtCAPRCODI.Size = New System.Drawing.Size(86, 20)
        Me.txtCAPRCODI.TabIndex = 1
        '
        'lblCAPRDESC
        '
        Me.lblCAPRDESC.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCAPRDESC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAPRDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAPRDESC.ForeColor = System.Drawing.Color.Black
        Me.lblCAPRDESC.Location = New System.Drawing.Point(107, 26)
        Me.lblCAPRDESC.Name = "lblCAPRDESC"
        Me.lblCAPRDESC.Size = New System.Drawing.Size(350, 20)
        Me.lblCAPRDESC.TabIndex = 38
        Me.lblCAPRDESC.Text = "Descripción"
        '
        'lblCAPRCODI
        '
        Me.lblCAPRCODI.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCAPRCODI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAPRCODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAPRCODI.ForeColor = System.Drawing.Color.Black
        Me.lblCAPRCODI.Location = New System.Drawing.Point(19, 26)
        Me.lblCAPRCODI.Name = "lblCAPRCODI"
        Me.lblCAPRCODI.Size = New System.Drawing.Size(85, 20)
        Me.lblCAPRCODI.TabIndex = 37
        Me.lblCAPRCODI.Text = "Código"
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(289, 16)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 2
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDARR
        '
        Me.cmdGUARDARR.AccessibleDescription = "Guardar"
        Me.cmdGUARDARR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDARR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDARR.Location = New System.Drawing.Point(182, 16)
        Me.cmdGUARDARR.Name = "cmdGUARDARR"
        Me.cmdGUARDARR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDARR.TabIndex = 1
        Me.cmdGUARDARR.Text = "&Guardar"
        Me.cmdGUARDARR.UseVisualStyleBackColor = True
        '
        'fraCOMANDOS
        '
        Me.fraCOMANDOS.Controls.Add(Me.cmdSALIR)
        Me.fraCOMANDOS.Controls.Add(Me.cmdGUARDARR)
        Me.fraCOMANDOS.Location = New System.Drawing.Point(18, 100)
        Me.fraCOMANDOS.Name = "fraCOMANDOS"
        Me.fraCOMANDOS.Size = New System.Drawing.Size(572, 50)
        Me.fraCOMANDOS.TabIndex = 1
        Me.fraCOMANDOS.TabStop = False
        '
        'frm_insertar_CALIPROP
        '
        Me.AccessibleDescription = "Calidad de propietario"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdSALIR
        Me.ClientSize = New System.Drawing.Size(608, 185)
        Me.Controls.Add(Me.fraCOMANDOS)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCALIPROP)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(624, 221)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(624, 221)
        Me.Name = "frm_insertar_CALIPROP"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraCALIPROP.ResumeLayout(False)
        Me.fraCALIPROP.PerformLayout()
        Me.fraCOMANDOS.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraCALIPROP As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDARR As System.Windows.Forms.Button
    Friend WithEvents cboCAPRESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCAPRESTA As System.Windows.Forms.Label
    Friend WithEvents txtCAPRDESC As System.Windows.Forms.TextBox
    Friend WithEvents txtCAPRCODI As System.Windows.Forms.TextBox
    Friend WithEvents lblCAPRDESC As System.Windows.Forms.Label
    Friend WithEvents lblCAPRCODI As System.Windows.Forms.Label
    Friend WithEvents fraCOMANDOS As System.Windows.Forms.GroupBox
End Class
