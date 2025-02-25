<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_CABEUAU
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
        Me.fraCOMANDOS = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraUAUPLPA = New System.Windows.Forms.GroupBox()
        Me.txtCBUAVALO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCBUACBPP = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboCBUAUAPP = New System.Windows.Forms.ComboBox()
        Me.cboCBAUPLPA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCBUAESTA = New System.Windows.Forms.ComboBox()
        Me.lblCAPRESTA = New System.Windows.Forms.Label()
        Me.lblCAPRCODI = New System.Windows.Forms.Label()
        Me.fraCOMANDOS.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraUAUPLPA.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraCOMANDOS
        '
        Me.fraCOMANDOS.Controls.Add(Me.cmdSALIR)
        Me.fraCOMANDOS.Controls.Add(Me.cmdGUARDAR)
        Me.fraCOMANDOS.Location = New System.Drawing.Point(18, 167)
        Me.fraCOMANDOS.Name = "fraCOMANDOS"
        Me.fraCOMANDOS.Size = New System.Drawing.Size(588, 50)
        Me.fraCOMANDOS.TabIndex = 52
        Me.fraCOMANDOS.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(296, 16)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 2
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(189, 16)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 1
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 234)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(621, 25)
        Me.strBARRESTA.TabIndex = 53
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
        'fraUAUPLPA
        '
        Me.fraUAUPLPA.BackColor = System.Drawing.SystemColors.Control
        Me.fraUAUPLPA.Controls.Add(Me.txtCBUAVALO)
        Me.fraUAUPLPA.Controls.Add(Me.Label2)
        Me.fraUAUPLPA.Controls.Add(Me.cboCBUACBPP)
        Me.fraUAUPLPA.Controls.Add(Me.Label1)
        Me.fraUAUPLPA.Controls.Add(Me.cboCBUAUAPP)
        Me.fraUAUPLPA.Controls.Add(Me.cboCBAUPLPA)
        Me.fraUAUPLPA.Controls.Add(Me.Label4)
        Me.fraUAUPLPA.Controls.Add(Me.cboCBUAESTA)
        Me.fraUAUPLPA.Controls.Add(Me.lblCAPRESTA)
        Me.fraUAUPLPA.Controls.Add(Me.lblCAPRCODI)
        Me.fraUAUPLPA.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraUAUPLPA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraUAUPLPA.Location = New System.Drawing.Point(18, 6)
        Me.fraUAUPLPA.Name = "fraUAUPLPA"
        Me.fraUAUPLPA.Size = New System.Drawing.Size(588, 155)
        Me.fraUAUPLPA.TabIndex = 51
        Me.fraUAUPLPA.TabStop = False
        Me.fraUAUPLPA.Text = "MODIFICAR CARGAS Y BENEFICIOS POR UNIDAD DE ACTUACIÓN"
        '
        'txtCBUAVALO
        '
        Me.txtCBUAVALO.AccessibleDescription = "Cesión espacio público"
        Me.txtCBUAVALO.BackColor = System.Drawing.SystemColors.Window
        Me.txtCBUAVALO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCBUAVALO.Location = New System.Drawing.Point(151, 97)
        Me.txtCBUAVALO.MaxLength = 9
        Me.txtCBUAVALO.Name = "txtCBUAVALO"
        Me.txtCBUAVALO.Size = New System.Drawing.Size(139, 20)
        Me.txtCBUAVALO.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(17, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 20)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Valor"
        '
        'cboCBUACBPP
        '
        Me.cboCBUACBPP.AccessibleDescription = "Estado"
        Me.cboCBUACBPP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCBUACBPP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCBUACBPP.Enabled = False
        Me.cboCBUACBPP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCBUACBPP.FormattingEnabled = True
        Me.cboCBUACBPP.Items.AddRange(New Object() {""})
        Me.cboCBUACBPP.Location = New System.Drawing.Point(151, 72)
        Me.cboCBUACBPP.Name = "cboCBUACBPP"
        Me.cboCBUACBPP.Size = New System.Drawing.Size(421, 22)
        Me.cboCBUACBPP.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 20)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Cargas y Beneficios"
        '
        'cboCBUAUAPP
        '
        Me.cboCBUAUAPP.AccessibleDescription = "Estado"
        Me.cboCBUAUAPP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCBUAUAPP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCBUAUAPP.Enabled = False
        Me.cboCBUAUAPP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCBUAUAPP.FormattingEnabled = True
        Me.cboCBUAUAPP.Items.AddRange(New Object() {""})
        Me.cboCBUAUAPP.Location = New System.Drawing.Point(151, 49)
        Me.cboCBUAUAPP.Name = "cboCBUAUAPP"
        Me.cboCBUAUAPP.Size = New System.Drawing.Size(421, 22)
        Me.cboCBUAUAPP.TabIndex = 2
        '
        'cboCBAUPLPA
        '
        Me.cboCBAUPLPA.AccessibleDescription = "Plan Parcial"
        Me.cboCBAUPLPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCBAUPLPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCBAUPLPA.Enabled = False
        Me.cboCBAUPLPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCBAUPLPA.FormattingEnabled = True
        Me.cboCBAUPLPA.Location = New System.Drawing.Point(151, 26)
        Me.cboCBAUPLPA.Name = "cboCBAUPLPA"
        Me.cboCBAUPLPA.Size = New System.Drawing.Size(421, 22)
        Me.cboCBAUPLPA.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(17, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 20)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Plan Parcial"
        '
        'cboCBUAESTA
        '
        Me.cboCBUAESTA.AccessibleDescription = "Estado"
        Me.cboCBUAESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCBUAESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCBUAESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCBUAESTA.FormattingEnabled = True
        Me.cboCBUAESTA.Items.AddRange(New Object() {""})
        Me.cboCBUAESTA.Location = New System.Drawing.Point(151, 119)
        Me.cboCBUAESTA.Name = "cboCBUAESTA"
        Me.cboCBUAESTA.Size = New System.Drawing.Size(246, 22)
        Me.cboCBUAESTA.TabIndex = 5
        '
        'lblCAPRESTA
        '
        Me.lblCAPRESTA.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCAPRESTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAPRESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAPRESTA.ForeColor = System.Drawing.Color.Black
        Me.lblCAPRESTA.Location = New System.Drawing.Point(17, 120)
        Me.lblCAPRESTA.Name = "lblCAPRESTA"
        Me.lblCAPRESTA.Size = New System.Drawing.Size(130, 20)
        Me.lblCAPRESTA.TabIndex = 41
        Me.lblCAPRESTA.Text = "Estado"
        '
        'lblCAPRCODI
        '
        Me.lblCAPRCODI.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCAPRCODI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAPRCODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAPRCODI.ForeColor = System.Drawing.Color.Black
        Me.lblCAPRCODI.Location = New System.Drawing.Point(17, 51)
        Me.lblCAPRCODI.Name = "lblCAPRCODI"
        Me.lblCAPRCODI.Size = New System.Drawing.Size(130, 20)
        Me.lblCAPRCODI.TabIndex = 37
        Me.lblCAPRCODI.Text = "Unidad de Actuación  U."
        '
        'frm_modificar_CABEUAU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 259)
        Me.Controls.Add(Me.fraCOMANDOS)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraUAUPLPA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(637, 295)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(637, 295)
        Me.Name = "frm_modificar_CABEUAU"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.fraCOMANDOS.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraUAUPLPA.ResumeLayout(False)
        Me.fraUAUPLPA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraCOMANDOS As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraUAUPLPA As System.Windows.Forms.GroupBox
    Friend WithEvents txtCBUAVALO As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCBUACBPP As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCBUAUAPP As System.Windows.Forms.ComboBox
    Friend WithEvents cboCBAUPLPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCBUAESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCAPRESTA As System.Windows.Forms.Label
    Friend WithEvents lblCAPRCODI As System.Windows.Forms.Label
End Class
