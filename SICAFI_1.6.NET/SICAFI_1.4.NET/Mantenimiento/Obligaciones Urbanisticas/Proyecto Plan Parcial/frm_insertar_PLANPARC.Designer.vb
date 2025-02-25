<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_PLANPARC
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
        Me.fraPLANPARC = New System.Windows.Forms.GroupBox()
        Me.txtPLPAFERE = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboPLPAESTA = New System.Windows.Forms.ComboBox()
        Me.lblCAPRESTA = New System.Windows.Forms.Label()
        Me.txtPLPADESC = New System.Windows.Forms.TextBox()
        Me.txtPLPANURE = New System.Windows.Forms.TextBox()
        Me.lblCAPRDESC = New System.Windows.Forms.Label()
        Me.lblCAPRCODI = New System.Windows.Forms.Label()
        Me.fraCOMANDOS.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraPLANPARC.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraCOMANDOS
        '
        Me.fraCOMANDOS.Controls.Add(Me.cmdSALIR)
        Me.fraCOMANDOS.Controls.Add(Me.cmdGUARDAR)
        Me.fraCOMANDOS.Location = New System.Drawing.Point(18, 95)
        Me.fraCOMANDOS.Name = "fraCOMANDOS"
        Me.fraCOMANDOS.Size = New System.Drawing.Size(721, 50)
        Me.fraCOMANDOS.TabIndex = 40
        Me.fraCOMANDOS.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(364, 16)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(257, 16)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 160)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(758, 25)
        Me.strBARRESTA.TabIndex = 41
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
        'fraPLANPARC
        '
        Me.fraPLANPARC.BackColor = System.Drawing.SystemColors.Control
        Me.fraPLANPARC.Controls.Add(Me.txtPLPAFERE)
        Me.fraPLANPARC.Controls.Add(Me.Label1)
        Me.fraPLANPARC.Controls.Add(Me.cboPLPAESTA)
        Me.fraPLANPARC.Controls.Add(Me.lblCAPRESTA)
        Me.fraPLANPARC.Controls.Add(Me.txtPLPADESC)
        Me.fraPLANPARC.Controls.Add(Me.txtPLPANURE)
        Me.fraPLANPARC.Controls.Add(Me.lblCAPRDESC)
        Me.fraPLANPARC.Controls.Add(Me.lblCAPRCODI)
        Me.fraPLANPARC.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPLANPARC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPLANPARC.Location = New System.Drawing.Point(18, 5)
        Me.fraPLANPARC.Name = "fraPLANPARC"
        Me.fraPLANPARC.Size = New System.Drawing.Size(721, 87)
        Me.fraPLANPARC.TabIndex = 39
        Me.fraPLANPARC.TabStop = False
        Me.fraPLANPARC.Text = "INSERTAR PROYECTO PLAN PARCIAL"
        '
        'txtPLPAFERE
        '
        Me.txtPLPAFERE.AccessibleDescription = "Fecha resolución"
        Me.txtPLPAFERE.BackColor = System.Drawing.Color.White
        Me.txtPLPAFERE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPLPAFERE.Location = New System.Drawing.Point(139, 49)
        Me.txtPLPAFERE.Mask = "00-00-0000"
        Me.txtPLPAFERE.Name = "txtPLPAFERE"
        Me.txtPLPAFERE.Size = New System.Drawing.Size(117, 20)
        Me.txtPLPAFERE.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(139, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 20)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Fecha Resolución"
        '
        'cboPLPAESTA
        '
        Me.cboPLPAESTA.AccessibleDescription = "Estado"
        Me.cboPLPAESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPLPAESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPLPAESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPLPAESTA.FormattingEnabled = True
        Me.cboPLPAESTA.Items.AddRange(New Object() {""})
        Me.cboPLPAESTA.Location = New System.Drawing.Point(613, 49)
        Me.cboPLPAESTA.Name = "cboPLPAESTA"
        Me.cboPLPAESTA.Size = New System.Drawing.Size(91, 22)
        Me.cboPLPAESTA.TabIndex = 4
        '
        'lblCAPRESTA
        '
        Me.lblCAPRESTA.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCAPRESTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAPRESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAPRESTA.ForeColor = System.Drawing.Color.Black
        Me.lblCAPRESTA.Location = New System.Drawing.Point(613, 26)
        Me.lblCAPRESTA.Name = "lblCAPRESTA"
        Me.lblCAPRESTA.Size = New System.Drawing.Size(90, 20)
        Me.lblCAPRESTA.TabIndex = 41
        Me.lblCAPRESTA.Text = "Estado"
        '
        'txtPLPADESC
        '
        Me.txtPLPADESC.AccessibleDescription = "Descripción"
        Me.txtPLPADESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtPLPADESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPLPADESC.Location = New System.Drawing.Point(259, 49)
        Me.txtPLPADESC.MaxLength = 50
        Me.txtPLPADESC.Name = "txtPLPADESC"
        Me.txtPLPADESC.Size = New System.Drawing.Size(351, 20)
        Me.txtPLPADESC.TabIndex = 3
        '
        'txtPLPANURE
        '
        Me.txtPLPANURE.AccessibleDescription = "Nro. Resolución"
        Me.txtPLPANURE.BackColor = System.Drawing.SystemColors.Window
        Me.txtPLPANURE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPLPANURE.Location = New System.Drawing.Point(19, 49)
        Me.txtPLPANURE.MaxLength = 9
        Me.txtPLPANURE.Name = "txtPLPANURE"
        Me.txtPLPANURE.Size = New System.Drawing.Size(118, 20)
        Me.txtPLPANURE.TabIndex = 1
        '
        'lblCAPRDESC
        '
        Me.lblCAPRDESC.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCAPRDESC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAPRDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAPRDESC.ForeColor = System.Drawing.Color.Black
        Me.lblCAPRDESC.Location = New System.Drawing.Point(259, 26)
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
        Me.lblCAPRCODI.Size = New System.Drawing.Size(117, 20)
        Me.lblCAPRCODI.TabIndex = 37
        Me.lblCAPRCODI.Text = "Nro. Resolución"
        '
        'frm_insertar_PLANPARC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(758, 185)
        Me.Controls.Add(Me.fraCOMANDOS)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraPLANPARC)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(774, 221)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(774, 221)
        Me.Name = "frm_insertar_PLANPARC"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.fraCOMANDOS.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraPLANPARC.ResumeLayout(False)
        Me.fraPLANPARC.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraCOMANDOS As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraPLANPARC As System.Windows.Forms.GroupBox
    Friend WithEvents cboPLPAESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCAPRESTA As System.Windows.Forms.Label
    Friend WithEvents txtPLPADESC As System.Windows.Forms.TextBox
    Friend WithEvents txtPLPANURE As System.Windows.Forms.TextBox
    Friend WithEvents lblCAPRDESC As System.Windows.Forms.Label
    Friend WithEvents lblCAPRCODI As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPLPAFERE As System.Windows.Forms.MaskedTextBox
End Class
