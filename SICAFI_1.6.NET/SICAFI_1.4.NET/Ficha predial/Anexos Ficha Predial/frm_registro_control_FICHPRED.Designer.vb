<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_registro_control_FICHPRED
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
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraUSUAOBSE = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRECOEMPR = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRECOPRED = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRECOINGE = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtpRECOFECH = New System.Windows.Forms.DateTimePicker()
        Me.txtRECOFECH = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRECOREPR = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRECOPROP = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraUSUAOBSE.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 241)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(711, 61)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(252, 22)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 1
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Cancelar"
        Me.cmdSALIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(359, 22)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 2
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 317)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(735, 25)
        Me.strBARRESTA.TabIndex = 38
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
        'fraUSUAOBSE
        '
        Me.fraUSUAOBSE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraUSUAOBSE.Controls.Add(Me.Label4)
        Me.fraUSUAOBSE.Controls.Add(Me.txtRECOEMPR)
        Me.fraUSUAOBSE.Controls.Add(Me.Label1)
        Me.fraUSUAOBSE.Controls.Add(Me.txtRECOPRED)
        Me.fraUSUAOBSE.Controls.Add(Me.Label3)
        Me.fraUSUAOBSE.Controls.Add(Me.txtRECOINGE)
        Me.fraUSUAOBSE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraUSUAOBSE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraUSUAOBSE.Location = New System.Drawing.Point(12, 3)
        Me.fraUSUAOBSE.Name = "fraUSUAOBSE"
        Me.fraUSUAOBSE.Size = New System.Drawing.Size(711, 113)
        Me.fraUSUAOBSE.TabIndex = 1
        Me.fraUSUAOBSE.TabStop = False
        Me.fraUSUAOBSE.Text = "CONTRATISTA"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 20)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "Empresa"
        '
        'txtRECOEMPR
        '
        Me.txtRECOEMPR.AccessibleDescription = "Empresa"
        Me.txtRECOEMPR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRECOEMPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECOEMPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECOEMPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECOEMPR.ForeColor = System.Drawing.Color.Black
        Me.txtRECOEMPR.Location = New System.Drawing.Point(188, 73)
        Me.txtRECOEMPR.MaxLength = 100
        Me.txtRECOEMPR.Name = "txtRECOEMPR"
        Me.txtRECOEMPR.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRECOEMPR.Size = New System.Drawing.Size(504, 20)
        Me.txtRECOEMPR.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 20)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Prediador"
        '
        'txtRECOPRED
        '
        Me.txtRECOPRED.AccessibleDescription = "Prediador"
        Me.txtRECOPRED.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRECOPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECOPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECOPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECOPRED.ForeColor = System.Drawing.Color.Black
        Me.txtRECOPRED.Location = New System.Drawing.Point(188, 50)
        Me.txtRECOPRED.MaxLength = 100
        Me.txtRECOPRED.Name = "txtRECOPRED"
        Me.txtRECOPRED.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRECOPRED.Size = New System.Drawing.Size(504, 20)
        Me.txtRECOPRED.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 20)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Ingeniero residente"
        '
        'txtRECOINGE
        '
        Me.txtRECOINGE.AccessibleDescription = "Ingeniero"
        Me.txtRECOINGE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRECOINGE.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECOINGE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECOINGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECOINGE.ForeColor = System.Drawing.Color.Black
        Me.txtRECOINGE.Location = New System.Drawing.Point(188, 27)
        Me.txtRECOINGE.MaxLength = 100
        Me.txtRECOINGE.Name = "txtRECOINGE"
        Me.txtRECOINGE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRECOINGE.Size = New System.Drawing.Size(504, 20)
        Me.txtRECOINGE.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dtpRECOFECH)
        Me.GroupBox2.Controls.Add(Me.txtRECOFECH)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtRECOREPR)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtRECOPROP)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(12, 122)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(711, 113)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PROPIETARIO O REPRESENTANTE"
        '
        'dtpRECOFECH
        '
        Me.dtpRECOFECH.AccessibleDescription = "Fecha"
        Me.dtpRECOFECH.Location = New System.Drawing.Point(316, 72)
        Me.dtpRECOFECH.MaxDate = New Date(3000, 3, 15, 0, 0, 0, 0)
        Me.dtpRECOFECH.Name = "dtpRECOFECH"
        Me.dtpRECOFECH.Size = New System.Drawing.Size(17, 21)
        Me.dtpRECOFECH.TabIndex = 475
        Me.dtpRECOFECH.Value = New Date(2011, 3, 15, 0, 0, 0, 0)
        '
        'txtRECOFECH
        '
        Me.txtRECOFECH.AccessibleDescription = "fecha"
        Me.txtRECOFECH.BackColor = System.Drawing.Color.White
        Me.txtRECOFECH.Location = New System.Drawing.Point(188, 72)
        Me.txtRECOFECH.Mask = "00-00-0000"
        Me.txtRECOFECH.Name = "txtRECOFECH"
        Me.txtRECOFECH.Size = New System.Drawing.Size(125, 21)
        Me.txtRECOFECH.TabIndex = 3
        Me.txtRECOFECH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 20)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(16, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(168, 20)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Representante"
        '
        'txtRECOREPR
        '
        Me.txtRECOREPR.AccessibleDescription = "Representante"
        Me.txtRECOREPR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRECOREPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECOREPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECOREPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECOREPR.ForeColor = System.Drawing.Color.Black
        Me.txtRECOREPR.Location = New System.Drawing.Point(188, 50)
        Me.txtRECOREPR.MaxLength = 100
        Me.txtRECOREPR.Name = "txtRECOREPR"
        Me.txtRECOREPR.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRECOREPR.Size = New System.Drawing.Size(504, 20)
        Me.txtRECOREPR.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(16, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 20)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "Propietario"
        '
        'txtRECOPROP
        '
        Me.txtRECOPROP.AccessibleDescription = "Propietario"
        Me.txtRECOPROP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRECOPROP.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECOPROP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECOPROP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECOPROP.ForeColor = System.Drawing.Color.Black
        Me.txtRECOPROP.Location = New System.Drawing.Point(188, 27)
        Me.txtRECOPROP.MaxLength = 100
        Me.txtRECOPROP.Name = "txtRECOPROP"
        Me.txtRECOPROP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRECOPROP.Size = New System.Drawing.Size(504, 20)
        Me.txtRECOPROP.TabIndex = 1
        '
        'frm_registro_control_FICHPRED
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 342)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraUSUAOBSE)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(751, 378)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(751, 378)
        Me.Name = "frm_registro_control_FICHPRED"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REGISTRO Y CONTROL"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraUSUAOBSE.ResumeLayout(False)
        Me.fraUSUAOBSE.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraUSUAOBSE As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRECOEMPR As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRECOPRED As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRECOINGE As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRECOREPR As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRECOPROP As System.Windows.Forms.TextBox
    Friend WithEvents txtRECOFECH As System.Windows.Forms.MaskedTextBox
    Friend WithEvents dtpRECOFECH As System.Windows.Forms.DateTimePicker
End Class
