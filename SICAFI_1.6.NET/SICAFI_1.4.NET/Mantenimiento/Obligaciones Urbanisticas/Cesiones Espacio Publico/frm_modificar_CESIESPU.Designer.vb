<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_CESIESPU
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
        Me.fraCESIESPU = New System.Windows.Forms.GroupBox()
        Me.txtCEEPAMCE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCEEPOTUS = New System.Windows.Forms.TextBox()
        Me.txtCEEPARCE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCEEPESTA = New System.Windows.Forms.ComboBox()
        Me.lblCAPRESTA = New System.Windows.Forms.Label()
        Me.txtCEEPDESC = New System.Windows.Forms.TextBox()
        Me.txtCEEPDEVI = New System.Windows.Forms.TextBox()
        Me.lblCAPRDESC = New System.Windows.Forms.Label()
        Me.lblCAPRCODI = New System.Windows.Forms.Label()
        Me.fraCOMANDOS.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraCESIESPU.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraCOMANDOS
        '
        Me.fraCOMANDOS.Controls.Add(Me.cmdSALIR)
        Me.fraCOMANDOS.Controls.Add(Me.cmdGUARDAR)
        Me.fraCOMANDOS.Location = New System.Drawing.Point(12, 215)
        Me.fraCOMANDOS.Name = "fraCOMANDOS"
        Me.fraCOMANDOS.Size = New System.Drawing.Size(650, 50)
        Me.fraCOMANDOS.TabIndex = 43
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 280)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(677, 25)
        Me.strBARRESTA.TabIndex = 44
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
        'fraCESIESPU
        '
        Me.fraCESIESPU.BackColor = System.Drawing.SystemColors.Control
        Me.fraCESIESPU.Controls.Add(Me.txtCEEPAMCE)
        Me.fraCESIESPU.Controls.Add(Me.Label3)
        Me.fraCESIESPU.Controls.Add(Me.txtCEEPOTUS)
        Me.fraCESIESPU.Controls.Add(Me.txtCEEPARCE)
        Me.fraCESIESPU.Controls.Add(Me.Label1)
        Me.fraCESIESPU.Controls.Add(Me.Label2)
        Me.fraCESIESPU.Controls.Add(Me.cboCEEPESTA)
        Me.fraCESIESPU.Controls.Add(Me.lblCAPRESTA)
        Me.fraCESIESPU.Controls.Add(Me.txtCEEPDESC)
        Me.fraCESIESPU.Controls.Add(Me.txtCEEPDEVI)
        Me.fraCESIESPU.Controls.Add(Me.lblCAPRDESC)
        Me.fraCESIESPU.Controls.Add(Me.lblCAPRCODI)
        Me.fraCESIESPU.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraCESIESPU.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraCESIESPU.Location = New System.Drawing.Point(12, 9)
        Me.fraCESIESPU.Name = "fraCESIESPU"
        Me.fraCESIESPU.Size = New System.Drawing.Size(650, 200)
        Me.fraCESIESPU.TabIndex = 42
        Me.fraCESIESPU.TabStop = False
        Me.fraCESIESPU.Text = "INSERTAR CESION ESPACIO PÚBLICO"
        '
        'txtCEEPAMCE
        '
        Me.txtCEEPAMCE.AccessibleDescription = "Área mímina a ceder"
        Me.txtCEEPAMCE.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEEPAMCE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEEPAMCE.Location = New System.Drawing.Point(303, 138)
        Me.txtCEEPAMCE.MaxLength = 5
        Me.txtCEEPAMCE.Name = "txtCEEPAMCE"
        Me.txtCEEPAMCE.Size = New System.Drawing.Size(117, 20)
        Me.txtCEEPAMCE.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(281, 20)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Área mínima a ceder del área bruta del lote / m2"
        '
        'txtCEEPOTUS
        '
        Me.txtCEEPOTUS.AccessibleDescription = "Otros usos"
        Me.txtCEEPOTUS.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEEPOTUS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEEPOTUS.Location = New System.Drawing.Point(303, 95)
        Me.txtCEEPOTUS.MaxLength = 5
        Me.txtCEEPOTUS.Name = "txtCEEPOTUS"
        Me.txtCEEPOTUS.Size = New System.Drawing.Size(117, 20)
        Me.txtCEEPOTUS.TabIndex = 4
        '
        'txtCEEPARCE
        '
        Me.txtCEEPARCE.AccessibleDescription = "Área a ceder"
        Me.txtCEEPARCE.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEEPARCE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEEPARCE.Location = New System.Drawing.Point(303, 72)
        Me.txtCEEPARCE.MaxLength = 5
        Me.txtCEEPARCE.Name = "txtCEEPARCE"
        Me.txtCEEPARCE.Size = New System.Drawing.Size(117, 20)
        Me.txtCEEPARCE.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(281, 40)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Aporte por otros usos por unidad de destinación y/o cada 100 m2 construidos"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(281, 20)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Área a ceder por unidad de vivienda / m2"
        '
        'cboCEEPESTA
        '
        Me.cboCEEPESTA.AccessibleDescription = "Estado"
        Me.cboCEEPESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCEEPESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCEEPESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCEEPESTA.FormattingEnabled = True
        Me.cboCEEPESTA.Items.AddRange(New Object() {""})
        Me.cboCEEPESTA.Location = New System.Drawing.Point(303, 161)
        Me.cboCEEPESTA.Name = "cboCEEPESTA"
        Me.cboCEEPESTA.Size = New System.Drawing.Size(117, 22)
        Me.cboCEEPESTA.TabIndex = 6
        '
        'lblCAPRESTA
        '
        Me.lblCAPRESTA.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCAPRESTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAPRESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAPRESTA.ForeColor = System.Drawing.Color.Black
        Me.lblCAPRESTA.Location = New System.Drawing.Point(19, 161)
        Me.lblCAPRESTA.Name = "lblCAPRESTA"
        Me.lblCAPRESTA.Size = New System.Drawing.Size(281, 20)
        Me.lblCAPRESTA.TabIndex = 41
        Me.lblCAPRESTA.Text = "Estado"
        '
        'txtCEEPDESC
        '
        Me.txtCEEPDESC.AccessibleDescription = "Descripción"
        Me.txtCEEPDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEEPDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEEPDESC.Location = New System.Drawing.Point(303, 49)
        Me.txtCEEPDESC.MaxLength = 50
        Me.txtCEEPDESC.Name = "txtCEEPDESC"
        Me.txtCEEPDESC.Size = New System.Drawing.Size(334, 20)
        Me.txtCEEPDESC.TabIndex = 2
        '
        'txtCEEPDEVI
        '
        Me.txtCEEPDEVI.AccessibleDescription = "Densida vivienda"
        Me.txtCEEPDEVI.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEEPDEVI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEEPDEVI.Location = New System.Drawing.Point(303, 26)
        Me.txtCEEPDEVI.MaxLength = 5
        Me.txtCEEPDEVI.Name = "txtCEEPDEVI"
        Me.txtCEEPDEVI.ReadOnly = True
        Me.txtCEEPDEVI.Size = New System.Drawing.Size(117, 20)
        Me.txtCEEPDEVI.TabIndex = 1
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
        Me.lblCAPRCODI.Text = "Densidad viviendas / Ha"
        '
        'frm_modificar_CESIESPU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 305)
        Me.Controls.Add(Me.fraCOMANDOS)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCESIESPU)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(693, 341)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(693, 341)
        Me.Name = "frm_modificar_CESIESPU"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.fraCOMANDOS.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraCESIESPU.ResumeLayout(False)
        Me.fraCESIESPU.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraCOMANDOS As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraCESIESPU As System.Windows.Forms.GroupBox
    Friend WithEvents txtCEEPAMCE As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCEEPOTUS As System.Windows.Forms.TextBox
    Friend WithEvents txtCEEPARCE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCEEPESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCAPRESTA As System.Windows.Forms.Label
    Friend WithEvents txtCEEPDESC As System.Windows.Forms.TextBox
    Friend WithEvents txtCEEPDEVI As System.Windows.Forms.TextBox
    Friend WithEvents lblCAPRDESC As System.Windows.Forms.Label
    Friend WithEvents lblCAPRCODI As System.Windows.Forms.Label
End Class
