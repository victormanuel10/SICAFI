<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_CESIEQUI
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
        Me.fraCESIEQUI = New System.Windows.Forms.GroupBox()
        Me.txtCEEQEQSA = New System.Windows.Forms.TextBox()
        Me.txtCEEQUNDE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCEEQESTA = New System.Windows.Forms.ComboBox()
        Me.lblCAPRESTA = New System.Windows.Forms.Label()
        Me.txtCEEQDESC = New System.Windows.Forms.TextBox()
        Me.txtCEEQESSO = New System.Windows.Forms.TextBox()
        Me.lblCAPRDESC = New System.Windows.Forms.Label()
        Me.lblCAPRCODI = New System.Windows.Forms.Label()
        Me.fraCOMANDOS.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraCESIEQUI.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraCOMANDOS
        '
        Me.fraCOMANDOS.Controls.Add(Me.cmdSALIR)
        Me.fraCOMANDOS.Controls.Add(Me.cmdGUARDAR)
        Me.fraCOMANDOS.Location = New System.Drawing.Point(12, 211)
        Me.fraCOMANDOS.Name = "fraCOMANDOS"
        Me.fraCOMANDOS.Size = New System.Drawing.Size(650, 50)
        Me.fraCOMANDOS.TabIndex = 46
        Me.fraCOMANDOS.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(329, 19)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(222, 19)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 274)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(677, 25)
        Me.strBARRESTA.TabIndex = 47
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
        'fraCESIEQUI
        '
        Me.fraCESIEQUI.BackColor = System.Drawing.SystemColors.Control
        Me.fraCESIEQUI.Controls.Add(Me.txtCEEQEQSA)
        Me.fraCESIEQUI.Controls.Add(Me.txtCEEQUNDE)
        Me.fraCESIEQUI.Controls.Add(Me.Label1)
        Me.fraCESIEQUI.Controls.Add(Me.Label2)
        Me.fraCESIEQUI.Controls.Add(Me.cboCEEQESTA)
        Me.fraCESIEQUI.Controls.Add(Me.lblCAPRESTA)
        Me.fraCESIEQUI.Controls.Add(Me.txtCEEQDESC)
        Me.fraCESIEQUI.Controls.Add(Me.txtCEEQESSO)
        Me.fraCESIEQUI.Controls.Add(Me.lblCAPRDESC)
        Me.fraCESIEQUI.Controls.Add(Me.lblCAPRCODI)
        Me.fraCESIEQUI.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraCESIEQUI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraCESIEQUI.Location = New System.Drawing.Point(12, 8)
        Me.fraCESIEQUI.Name = "fraCESIEQUI"
        Me.fraCESIEQUI.Size = New System.Drawing.Size(650, 197)
        Me.fraCESIEQUI.TabIndex = 45
        Me.fraCESIEQUI.TabStop = False
        Me.fraCESIEQUI.Text = "INSERTAR CESIONES PARA EQUIPAMIENTO"
        '
        'txtCEEQEQSA
        '
        Me.txtCEEQEQSA.AccessibleDescription = "Equivalencia en salarios"
        Me.txtCEEQEQSA.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEEQEQSA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEEQEQSA.Location = New System.Drawing.Point(303, 115)
        Me.txtCEEQEQSA.MaxLength = 5
        Me.txtCEEQEQSA.Name = "txtCEEQEQSA"
        Me.txtCEEQEQSA.Size = New System.Drawing.Size(117, 20)
        Me.txtCEEQEQSA.TabIndex = 4
        '
        'txtCEEQUNDE
        '
        Me.txtCEEQUNDE.AccessibleDescription = "Unidad de destinación"
        Me.txtCEEQUNDE.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEEQUNDE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEEQUNDE.Location = New System.Drawing.Point(303, 72)
        Me.txtCEEQUNDE.MaxLength = 5
        Me.txtCEEQUNDE.Name = "txtCEEQUNDE"
        Me.txtCEEQUNDE.Size = New System.Drawing.Size(117, 20)
        Me.txtCEEQUNDE.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(281, 40)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Equivalencia en salarios mínimos legales mensuales vigentes por unidad de destina" & _
            "ción"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(281, 40)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "m2 por unidad de destinación y/o por cada 100 m2 de área construida util de otros" & _
            " usos"
        '
        'cboCEEQESTA
        '
        Me.cboCEEQESTA.AccessibleDescription = "Estado"
        Me.cboCEEQESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCEEQESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCEEQESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCEEQESTA.FormattingEnabled = True
        Me.cboCEEQESTA.Items.AddRange(New Object() {""})
        Me.cboCEEQESTA.Location = New System.Drawing.Point(303, 158)
        Me.cboCEEQESTA.Name = "cboCEEQESTA"
        Me.cboCEEQESTA.Size = New System.Drawing.Size(117, 22)
        Me.cboCEEQESTA.TabIndex = 5
        '
        'lblCAPRESTA
        '
        Me.lblCAPRESTA.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCAPRESTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAPRESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAPRESTA.ForeColor = System.Drawing.Color.Black
        Me.lblCAPRESTA.Location = New System.Drawing.Point(19, 158)
        Me.lblCAPRESTA.Name = "lblCAPRESTA"
        Me.lblCAPRESTA.Size = New System.Drawing.Size(281, 20)
        Me.lblCAPRESTA.TabIndex = 41
        Me.lblCAPRESTA.Text = "Estado"
        '
        'txtCEEQDESC
        '
        Me.txtCEEQDESC.AccessibleDescription = "Descripción"
        Me.txtCEEQDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEEQDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEEQDESC.Location = New System.Drawing.Point(303, 49)
        Me.txtCEEQDESC.MaxLength = 50
        Me.txtCEEQDESC.Name = "txtCEEQDESC"
        Me.txtCEEQDESC.Size = New System.Drawing.Size(334, 20)
        Me.txtCEEQDESC.TabIndex = 2
        '
        'txtCEEQESSO
        '
        Me.txtCEEQESSO.AccessibleDescription = "Estrato"
        Me.txtCEEQESSO.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEEQESSO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEEQESSO.Location = New System.Drawing.Point(303, 26)
        Me.txtCEEQESSO.MaxLength = 5
        Me.txtCEEQESSO.Name = "txtCEEQESSO"
        Me.txtCEEQESSO.ReadOnly = True
        Me.txtCEEQESSO.Size = New System.Drawing.Size(117, 20)
        Me.txtCEEQESSO.TabIndex = 1
        '
        'lblCAPRDESC
        '
        Me.lblCAPRDESC.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCAPRDESC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAPRDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAPRDESC.ForeColor = System.Drawing.Color.Black
        Me.lblCAPRDESC.Location = New System.Drawing.Point(19, 49)
        Me.lblCAPRDESC.Name = "lblCAPRDESC"
        Me.lblCAPRDESC.Size = New System.Drawing.Size(281, 20)
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
        Me.lblCAPRCODI.Size = New System.Drawing.Size(281, 20)
        Me.lblCAPRCODI.TabIndex = 37
        Me.lblCAPRCODI.Text = "Estrato socioeconómico"
        '
        'frm_modificar_CESIEQUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 299)
        Me.Controls.Add(Me.fraCOMANDOS)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCESIEQUI)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(693, 335)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(693, 335)
        Me.Name = "frm_modificar_CESIEQUI"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.fraCOMANDOS.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraCESIEQUI.ResumeLayout(False)
        Me.fraCESIEQUI.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraCOMANDOS As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraCESIEQUI As System.Windows.Forms.GroupBox
    Friend WithEvents txtCEEQEQSA As System.Windows.Forms.TextBox
    Friend WithEvents txtCEEQUNDE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCEEQESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCAPRESTA As System.Windows.Forms.Label
    Friend WithEvents txtCEEQDESC As System.Windows.Forms.TextBox
    Friend WithEvents txtCEEQESSO As System.Windows.Forms.TextBox
    Friend WithEvents lblCAPRDESC As System.Windows.Forms.Label
    Friend WithEvents lblCAPRCODI As System.Windows.Forms.Label
End Class
