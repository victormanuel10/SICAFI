<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_CAUSACTO
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraCAUSACTO = New System.Windows.Forms.GroupBox()
        Me.cboCAACESTA = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCAACDESC = New System.Windows.Forms.TextBox()
        Me.txtCAACCODI = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCódigo = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkCAACRECO = New System.Windows.Forms.CheckBox()
        Me.chkCAACINCO = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkCAACREPR = New System.Windows.Forms.CheckBox()
        Me.chkCAACINPR = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraCAUSACTO.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 151)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(631, 53)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(320, 19)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 5
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(213, 19)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 4
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 228)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(658, 25)
        Me.strBARRESTA.TabIndex = 35
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
        'fraCAUSACTO
        '
        Me.fraCAUSACTO.BackColor = System.Drawing.SystemColors.Control
        Me.fraCAUSACTO.Controls.Add(Me.cboCAACESTA)
        Me.fraCAUSACTO.Controls.Add(Me.Label2)
        Me.fraCAUSACTO.Controls.Add(Me.txtCAACDESC)
        Me.fraCAUSACTO.Controls.Add(Me.txtCAACCODI)
        Me.fraCAUSACTO.Controls.Add(Me.Label1)
        Me.fraCAUSACTO.Controls.Add(Me.lblCódigo)
        Me.fraCAUSACTO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraCAUSACTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraCAUSACTO.Location = New System.Drawing.Point(12, 2)
        Me.fraCAUSACTO.Name = "fraCAUSACTO"
        Me.fraCAUSACTO.Size = New System.Drawing.Size(631, 83)
        Me.fraCAUSACTO.TabIndex = 34
        Me.fraCAUSACTO.TabStop = False
        Me.fraCAUSACTO.Text = "MODIFICAR CAUSA DEL ACTO"
        '
        'cboCAACESTA
        '
        Me.cboCAACESTA.AccessibleDescription = "Estado"
        Me.cboCAACESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCAACESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCAACESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCAACESTA.FormattingEnabled = True
        Me.cboCAACESTA.Location = New System.Drawing.Point(517, 49)
        Me.cboCAACESTA.Name = "cboCAACESTA"
        Me.cboCAACESTA.Size = New System.Drawing.Size(91, 22)
        Me.cboCAACESTA.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(517, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Estado"
        '
        'txtCAACDESC
        '
        Me.txtCAACDESC.AccessibleDescription = "Descripción"
        Me.txtCAACDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtCAACDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCAACDESC.Location = New System.Drawing.Point(107, 49)
        Me.txtCAACDESC.MaxLength = 50
        Me.txtCAACDESC.Name = "txtCAACDESC"
        Me.txtCAACDESC.Size = New System.Drawing.Size(407, 20)
        Me.txtCAACDESC.TabIndex = 2
        '
        'txtCAACCODI
        '
        Me.txtCAACCODI.AccessibleDescription = "Código"
        Me.txtCAACCODI.BackColor = System.Drawing.SystemColors.Window
        Me.txtCAACCODI.Enabled = False
        Me.txtCAACCODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCAACCODI.Location = New System.Drawing.Point(19, 49)
        Me.txtCAACCODI.MaxLength = 1
        Me.txtCAACCODI.Name = "txtCAACCODI"
        Me.txtCAACCODI.ReadOnly = True
        Me.txtCAACCODI.Size = New System.Drawing.Size(86, 20)
        Me.txtCAACCODI.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(107, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(406, 20)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Descripción"
        '
        'lblCódigo
        '
        Me.lblCódigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCódigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCódigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCódigo.ForeColor = System.Drawing.Color.Black
        Me.lblCódigo.Location = New System.Drawing.Point(19, 26)
        Me.lblCódigo.Name = "lblCódigo"
        Me.lblCódigo.Size = New System.Drawing.Size(85, 20)
        Me.lblCódigo.TabIndex = 37
        Me.lblCódigo.Text = "Código"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkCAACRECO)
        Me.GroupBox3.Controls.Add(Me.chkCAACINCO)
        Me.GroupBox3.Location = New System.Drawing.Point(289, 91)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(354, 54)
        Me.GroupBox3.TabIndex = 39
        Me.GroupBox3.TabStop = False
        '
        'chkCAACRECO
        '
        Me.chkCAACRECO.AccessibleDescription = "Retiro de construcción"
        Me.chkCAACRECO.Location = New System.Drawing.Point(190, 20)
        Me.chkCAACRECO.Name = "chkCAACRECO"
        Me.chkCAACRECO.Size = New System.Drawing.Size(140, 17)
        Me.chkCAACRECO.TabIndex = 1
        Me.chkCAACRECO.Text = "Retiro de construcción"
        Me.chkCAACRECO.UseVisualStyleBackColor = True
        '
        'chkCAACINCO
        '
        Me.chkCAACINCO.AccessibleDescription = "Inscripción de construcción"
        Me.chkCAACINCO.Location = New System.Drawing.Point(22, 16)
        Me.chkCAACINCO.Name = "chkCAACINCO"
        Me.chkCAACINCO.Size = New System.Drawing.Size(162, 24)
        Me.chkCAACINCO.TabIndex = 0
        Me.chkCAACINCO.Text = "Inscripción de construcción"
        Me.chkCAACINCO.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkCAACREPR)
        Me.GroupBox2.Controls.Add(Me.chkCAACINPR)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 91)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(271, 54)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        '
        'chkCAACREPR
        '
        Me.chkCAACREPR.AccessibleDescription = "Retiro de predio"
        Me.chkCAACREPR.Location = New System.Drawing.Point(155, 20)
        Me.chkCAACREPR.Name = "chkCAACREPR"
        Me.chkCAACREPR.Size = New System.Drawing.Size(110, 17)
        Me.chkCAACREPR.TabIndex = 2
        Me.chkCAACREPR.Text = "Retiro de predio"
        Me.chkCAACREPR.UseVisualStyleBackColor = True
        '
        'chkCAACINPR
        '
        Me.chkCAACINPR.AccessibleDescription = "Inscripción de predio"
        Me.chkCAACINPR.Location = New System.Drawing.Point(19, 20)
        Me.chkCAACINPR.Name = "chkCAACINPR"
        Me.chkCAACINPR.Size = New System.Drawing.Size(130, 17)
        Me.chkCAACINPR.TabIndex = 1
        Me.chkCAACINPR.Text = "Inscripción de predio"
        Me.chkCAACINPR.UseVisualStyleBackColor = True
        '
        'frm_modificar_CAUSACTO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 253)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCAUSACTO)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(674, 289)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(674, 289)
        Me.Name = "frm_modificar_CAUSACTO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraCAUSACTO.ResumeLayout(False)
        Me.fraCAUSACTO.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraCAUSACTO As System.Windows.Forms.GroupBox
    Friend WithEvents cboCAACESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCAACDESC As System.Windows.Forms.TextBox
    Friend WithEvents txtCAACCODI As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCódigo As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkCAACRECO As System.Windows.Forms.CheckBox
    Friend WithEvents chkCAACINCO As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkCAACREPR As System.Windows.Forms.CheckBox
    Friend WithEvents chkCAACINPR As System.Windows.Forms.CheckBox
End Class
