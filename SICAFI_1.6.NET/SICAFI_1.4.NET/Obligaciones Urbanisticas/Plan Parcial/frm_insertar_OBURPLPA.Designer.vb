<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_OBURPLPA
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
        Me.fraOBURPLPA = New System.Windows.Forms.GroupBox()
        Me.cboOUPPUAU = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboOUPPCABE = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboOUPPCOFP = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboOUPPFOPA = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboOUPPPLPA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboOUPPESTA = New System.Windows.Forms.ComboBox()
        Me.lblCAPRESTA = New System.Windows.Forms.Label()
        Me.fraCOMANDOS.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraOBURPLPA.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraCOMANDOS
        '
        Me.fraCOMANDOS.Controls.Add(Me.cmdSALIR)
        Me.fraCOMANDOS.Controls.Add(Me.cmdGUARDAR)
        Me.fraCOMANDOS.Location = New System.Drawing.Point(18, 199)
        Me.fraCOMANDOS.Name = "fraCOMANDOS"
        Me.fraCOMANDOS.Size = New System.Drawing.Size(588, 50)
        Me.fraCOMANDOS.TabIndex = 49
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 269)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(621, 25)
        Me.strBARRESTA.TabIndex = 50
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
        'fraOBURPLPA
        '
        Me.fraOBURPLPA.BackColor = System.Drawing.SystemColors.Control
        Me.fraOBURPLPA.Controls.Add(Me.cboOUPPUAU)
        Me.fraOBURPLPA.Controls.Add(Me.Label3)
        Me.fraOBURPLPA.Controls.Add(Me.cboOUPPCABE)
        Me.fraOBURPLPA.Controls.Add(Me.Label5)
        Me.fraOBURPLPA.Controls.Add(Me.cboOUPPCOFP)
        Me.fraOBURPLPA.Controls.Add(Me.Label2)
        Me.fraOBURPLPA.Controls.Add(Me.cboOUPPFOPA)
        Me.fraOBURPLPA.Controls.Add(Me.Label1)
        Me.fraOBURPLPA.Controls.Add(Me.cboOUPPPLPA)
        Me.fraOBURPLPA.Controls.Add(Me.Label4)
        Me.fraOBURPLPA.Controls.Add(Me.cboOUPPESTA)
        Me.fraOBURPLPA.Controls.Add(Me.lblCAPRESTA)
        Me.fraOBURPLPA.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraOBURPLPA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraOBURPLPA.Location = New System.Drawing.Point(18, 9)
        Me.fraOBURPLPA.Name = "fraOBURPLPA"
        Me.fraOBURPLPA.Size = New System.Drawing.Size(588, 184)
        Me.fraOBURPLPA.TabIndex = 48
        Me.fraOBURPLPA.TabStop = False
        Me.fraOBURPLPA.Text = "INSERTAR PLAN PARCIAL"
        '
        'cboOUPPUAU
        '
        Me.cboOUPPUAU.AccessibleDescription = "Unidad de Actuación"
        Me.cboOUPPUAU.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUPPUAU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUPPUAU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUPPUAU.FormattingEnabled = True
        Me.cboOUPPUAU.Location = New System.Drawing.Point(151, 72)
        Me.cboOUPPUAU.Name = "cboOUPPUAU"
        Me.cboOUPPUAU.Size = New System.Drawing.Size(421, 22)
        Me.cboOUPPUAU.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(17, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 20)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "U. A. U."
        '
        'cboOUPPCABE
        '
        Me.cboOUPPCABE.AccessibleDescription = "Carga y Beneficio"
        Me.cboOUPPCABE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUPPCABE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUPPCABE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUPPCABE.FormattingEnabled = True
        Me.cboOUPPCABE.Location = New System.Drawing.Point(151, 49)
        Me.cboOUPPCABE.Name = "cboOUPPCABE"
        Me.cboOUPPCABE.Size = New System.Drawing.Size(421, 22)
        Me.cboOUPPCABE.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(17, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 20)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Carga y Beneficio"
        '
        'cboOUPPCOFP
        '
        Me.cboOUPPCOFP.AccessibleDescription = "Control forma de pago"
        Me.cboOUPPCOFP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUPPCOFP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUPPCOFP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUPPCOFP.FormattingEnabled = True
        Me.cboOUPPCOFP.Location = New System.Drawing.Point(151, 118)
        Me.cboOUPPCOFP.Name = "cboOUPPCOFP"
        Me.cboOUPPCOFP.Size = New System.Drawing.Size(421, 22)
        Me.cboOUPPCOFP.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(17, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 20)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Control de Pago"
        '
        'cboOUPPFOPA
        '
        Me.cboOUPPFOPA.AccessibleDescription = "Forma de pago"
        Me.cboOUPPFOPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUPPFOPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUPPFOPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUPPFOPA.FormattingEnabled = True
        Me.cboOUPPFOPA.Location = New System.Drawing.Point(151, 95)
        Me.cboOUPPFOPA.Name = "cboOUPPFOPA"
        Me.cboOUPPFOPA.Size = New System.Drawing.Size(421, 22)
        Me.cboOUPPFOPA.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 20)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Forma de Pago"
        '
        'cboOUPPPLPA
        '
        Me.cboOUPPPLPA.AccessibleDescription = "Plan Parcial"
        Me.cboOUPPPLPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUPPPLPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUPPPLPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUPPPLPA.FormattingEnabled = True
        Me.cboOUPPPLPA.Location = New System.Drawing.Point(151, 26)
        Me.cboOUPPPLPA.Name = "cboOUPPPLPA"
        Me.cboOUPPPLPA.Size = New System.Drawing.Size(421, 22)
        Me.cboOUPPPLPA.TabIndex = 1
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
        'cboOUPPESTA
        '
        Me.cboOUPPESTA.AccessibleDescription = "Estado"
        Me.cboOUPPESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUPPESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUPPESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUPPESTA.FormattingEnabled = True
        Me.cboOUPPESTA.Items.AddRange(New Object() {""})
        Me.cboOUPPESTA.Location = New System.Drawing.Point(151, 141)
        Me.cboOUPPESTA.Name = "cboOUPPESTA"
        Me.cboOUPPESTA.Size = New System.Drawing.Size(246, 22)
        Me.cboOUPPESTA.TabIndex = 6
        '
        'lblCAPRESTA
        '
        Me.lblCAPRESTA.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCAPRESTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAPRESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAPRESTA.ForeColor = System.Drawing.Color.Black
        Me.lblCAPRESTA.Location = New System.Drawing.Point(17, 143)
        Me.lblCAPRESTA.Name = "lblCAPRESTA"
        Me.lblCAPRESTA.Size = New System.Drawing.Size(130, 20)
        Me.lblCAPRESTA.TabIndex = 41
        Me.lblCAPRESTA.Text = "Estado"
        '
        'frm_insertar_OBURPLPA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 294)
        Me.Controls.Add(Me.fraCOMANDOS)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraOBURPLPA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(637, 330)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(637, 330)
        Me.Name = "frm_insertar_OBURPLPA"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.fraCOMANDOS.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraOBURPLPA.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraCOMANDOS As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraOBURPLPA As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboOUPPCABE As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboOUPPCOFP As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboOUPPFOPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboOUPPPLPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboOUPPESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCAPRESTA As System.Windows.Forms.Label
    Friend WithEvents cboOUPPUAU As System.Windows.Forms.ComboBox
End Class
