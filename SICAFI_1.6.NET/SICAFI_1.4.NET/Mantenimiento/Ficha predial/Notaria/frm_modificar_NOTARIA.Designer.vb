<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_NOTARIA
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
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.fraNOTARIA = New System.Windows.Forms.GroupBox
        Me.lblNOTADEPA = New System.Windows.Forms.Label
        Me.cboNOTADEPA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblNOTAMUNI = New System.Windows.Forms.Label
        Me.cboNOTAMUNI = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboNOTAESTA = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNOTADESC = New System.Windows.Forms.TextBox
        Me.txtNOTACODI = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblCódigo = New System.Windows.Forms.Label
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.cmdGUARDAR = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.strBARRESTA.SuspendLayout()
        Me.fraNOTARIA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 258)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(596, 25)
        Me.strBARRESTA.TabIndex = 28
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
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.AutoSize = False
        Me.ToolStripStatusLabel4.BackColor = System.Drawing.SystemColors.Window
        Me.ToolStripStatusLabel4.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel4.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel4.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(125, 22)
        Me.ToolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.AutoSize = False
        Me.ToolStripStatusLabel3.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ToolStripStatusLabel3.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel3.ForeColor = System.Drawing.Color.Red
        Me.ToolStripStatusLabel3.LinkColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel3.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(300, 22)
        Me.ToolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.AutoSize = False
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.SystemColors.Window
        Me.ToolStripStatusLabel2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(125, 22)
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
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
        'fraNOTARIA
        '
        Me.fraNOTARIA.BackColor = System.Drawing.SystemColors.Control
        Me.fraNOTARIA.Controls.Add(Me.lblNOTADEPA)
        Me.fraNOTARIA.Controls.Add(Me.cboNOTADEPA)
        Me.fraNOTARIA.Controls.Add(Me.Label4)
        Me.fraNOTARIA.Controls.Add(Me.lblNOTAMUNI)
        Me.fraNOTARIA.Controls.Add(Me.cboNOTAMUNI)
        Me.fraNOTARIA.Controls.Add(Me.Label3)
        Me.fraNOTARIA.Controls.Add(Me.cboNOTAESTA)
        Me.fraNOTARIA.Controls.Add(Me.Label2)
        Me.fraNOTARIA.Controls.Add(Me.txtNOTADESC)
        Me.fraNOTARIA.Controls.Add(Me.txtNOTACODI)
        Me.fraNOTARIA.Controls.Add(Me.Label1)
        Me.fraNOTARIA.Controls.Add(Me.lblCódigo)
        Me.fraNOTARIA.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraNOTARIA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraNOTARIA.Location = New System.Drawing.Point(12, 12)
        Me.fraNOTARIA.Name = "fraNOTARIA"
        Me.fraNOTARIA.Size = New System.Drawing.Size(572, 161)
        Me.fraNOTARIA.TabIndex = 27
        Me.fraNOTARIA.TabStop = False
        Me.fraNOTARIA.Text = "MODIFICAR NOTARIA"
        '
        'lblNOTADEPA
        '
        Me.lblNOTADEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblNOTADEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNOTADEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNOTADEPA.ForeColor = System.Drawing.Color.Black
        Me.lblNOTADEPA.Location = New System.Drawing.Point(252, 28)
        Me.lblNOTADEPA.Name = "lblNOTADEPA"
        Me.lblNOTADEPA.Size = New System.Drawing.Size(300, 20)
        Me.lblNOTADEPA.TabIndex = 49
        '
        'cboNOTADEPA
        '
        Me.cboNOTADEPA.AccessibleDescription = "Departamento"
        Me.cboNOTADEPA.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboNOTADEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboNOTADEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNOTADEPA.Enabled = False
        Me.cboNOTADEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNOTADEPA.FormattingEnabled = True
        Me.cboNOTADEPA.Location = New System.Drawing.Point(133, 26)
        Me.cboNOTADEPA.MaxLength = 200
        Me.cboNOTADEPA.Name = "cboNOTADEPA"
        Me.cboNOTADEPA.Size = New System.Drawing.Size(113, 22)
        Me.cboNOTADEPA.TabIndex = 47
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(15, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 20)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Departamento"
        '
        'lblNOTAMUNI
        '
        Me.lblNOTAMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblNOTAMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNOTAMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNOTAMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblNOTAMUNI.Location = New System.Drawing.Point(252, 52)
        Me.lblNOTAMUNI.Name = "lblNOTAMUNI"
        Me.lblNOTAMUNI.Size = New System.Drawing.Size(300, 20)
        Me.lblNOTAMUNI.TabIndex = 43
        '
        'cboNOTAMUNI
        '
        Me.cboNOTAMUNI.AccessibleDescription = "Municipio"
        Me.cboNOTAMUNI.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboNOTAMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboNOTAMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNOTAMUNI.Enabled = False
        Me.cboNOTAMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNOTAMUNI.FormattingEnabled = True
        Me.cboNOTAMUNI.Location = New System.Drawing.Point(133, 52)
        Me.cboNOTAMUNI.MaxLength = 200
        Me.cboNOTAMUNI.Name = "cboNOTAMUNI"
        Me.cboNOTAMUNI.Size = New System.Drawing.Size(113, 22)
        Me.cboNOTAMUNI.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(15, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Municipio"
        '
        'cboNOTAESTA
        '
        Me.cboNOTAESTA.AccessibleDescription = "Estado"
        Me.cboNOTAESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboNOTAESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNOTAESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNOTAESTA.FormattingEnabled = True
        Me.cboNOTAESTA.Location = New System.Drawing.Point(133, 124)
        Me.cboNOTAESTA.Name = "cboNOTAESTA"
        Me.cboNOTAESTA.Size = New System.Drawing.Size(113, 22)
        Me.cboNOTAESTA.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(15, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Estado"
        '
        'txtNOTADESC
        '
        Me.txtNOTADESC.AccessibleDescription = "Descripción"
        Me.txtNOTADESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtNOTADESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNOTADESC.Location = New System.Drawing.Point(133, 100)
        Me.txtNOTADESC.MaxLength = 50
        Me.txtNOTADESC.Name = "txtNOTADESC"
        Me.txtNOTADESC.Size = New System.Drawing.Size(419, 20)
        Me.txtNOTADESC.TabIndex = 3
        '
        'txtNOTACODI
        '
        Me.txtNOTACODI.AccessibleDescription = "Código"
        Me.txtNOTACODI.BackColor = System.Drawing.SystemColors.Window
        Me.txtNOTACODI.Enabled = False
        Me.txtNOTACODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNOTACODI.Location = New System.Drawing.Point(133, 76)
        Me.txtNOTACODI.MaxLength = 5
        Me.txtNOTACODI.Name = "txtNOTACODI"
        Me.txtNOTACODI.ReadOnly = True
        Me.txtNOTACODI.Size = New System.Drawing.Size(113, 20)
        Me.txtNOTACODI.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(15, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Descripción"
        '
        'lblCódigo
        '
        Me.lblCódigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCódigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCódigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCódigo.ForeColor = System.Drawing.Color.Black
        Me.lblCódigo.Location = New System.Drawing.Point(15, 76)
        Me.lblCódigo.Name = "lblCódigo"
        Me.lblCódigo.Size = New System.Drawing.Size(112, 20)
        Me.lblCódigo.TabIndex = 37
        Me.lblCódigo.Text = "Notaria"
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(286, 19)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 6
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(179, 19)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 5
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 180)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 58)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        '
        'frm_modificar_NOTARIA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdSALIR
        Me.ClientSize = New System.Drawing.Size(596, 283)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraNOTARIA)
        Me.Location = New System.Drawing.Point(604, 310)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_modificar_NOTARIA"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraNOTARIA.ResumeLayout(False)
        Me.fraNOTARIA.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraNOTARIA As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents cboNOTAESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNOTADESC As System.Windows.Forms.TextBox
    Friend WithEvents txtNOTACODI As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCódigo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboNOTAMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblNOTAMUNI As System.Windows.Forms.Label
    Friend WithEvents lblNOTADEPA As System.Windows.Forms.Label
    Friend WithEvents cboNOTADEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
