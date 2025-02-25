<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_ZONAFISI
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
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.fraZONAECONOMICA = New System.Windows.Forms.GroupBox
        Me.chkZOFIZOCO = New System.Windows.Forms.CheckBox
        Me.lblZOFICLSE = New System.Windows.Forms.Label
        Me.cboZOFICLSE = New System.Windows.Forms.ComboBox
        Me.lblClaseosector = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblZOFIDEPA = New System.Windows.Forms.Label
        Me.cboZOFIDEPA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblZOFIMUNI = New System.Windows.Forms.Label
        Me.cboZOFIMUNI = New System.Windows.Forms.ComboBox
        Me.lblMUNICIPIO = New System.Windows.Forms.Label
        Me.cboZOFIESTA = New System.Windows.Forms.ComboBox
        Me.txtZOFIDESC = New System.Windows.Forms.TextBox
        Me.txtZOFICODI = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.cmdGUARDAR = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.strBARRESTA.SuspendLayout()
        Me.fraZONAECONOMICA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 235)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(598, 25)
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
        'fraZONAECONOMICA
        '
        Me.fraZONAECONOMICA.BackColor = System.Drawing.SystemColors.Control
        Me.fraZONAECONOMICA.Controls.Add(Me.chkZOFIZOCO)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblZOFICLSE)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboZOFICLSE)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblClaseosector)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label3)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblZOFIDEPA)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboZOFIDEPA)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label4)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblZOFIMUNI)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboZOFIMUNI)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblMUNICIPIO)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboZOFIESTA)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtZOFIDESC)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtZOFICODI)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label1)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblCodigo)
        Me.fraZONAECONOMICA.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraZONAECONOMICA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraZONAECONOMICA.Location = New System.Drawing.Point(12, 2)
        Me.fraZONAECONOMICA.Name = "fraZONAECONOMICA"
        Me.fraZONAECONOMICA.Size = New System.Drawing.Size(572, 176)
        Me.fraZONAECONOMICA.TabIndex = 29
        Me.fraZONAECONOMICA.TabStop = False
        Me.fraZONAECONOMICA.Text = "MODIFICAR ZONA FÍSICA"
        '
        'chkZOFIZOCO
        '
        Me.chkZOFIZOCO.AccessibleDescription = "Zona común"
        Me.chkZOFIZOCO.AutoSize = True
        Me.chkZOFIZOCO.Location = New System.Drawing.Point(256, 146)
        Me.chkZOFIZOCO.Name = "chkZOFIZOCO"
        Me.chkZOFIZOCO.Size = New System.Drawing.Size(95, 19)
        Me.chkZOFIZOCO.TabIndex = 60
        Me.chkZOFIZOCO.Text = "Zona común"
        Me.chkZOFIZOCO.UseVisualStyleBackColor = True
        '
        'lblZOFICLSE
        '
        Me.lblZOFICLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZOFICLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZOFICLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZOFICLSE.ForeColor = System.Drawing.Color.Black
        Me.lblZOFICLSE.Location = New System.Drawing.Point(256, 74)
        Me.lblZOFICLSE.Name = "lblZOFICLSE"
        Me.lblZOFICLSE.Size = New System.Drawing.Size(302, 20)
        Me.lblZOFICLSE.TabIndex = 57
        '
        'cboZOFICLSE
        '
        Me.cboZOFICLSE.AccessibleDescription = "Clase o sector"
        Me.cboZOFICLSE.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboZOFICLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboZOFICLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZOFICLSE.Enabled = False
        Me.cboZOFICLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZOFICLSE.FormattingEnabled = True
        Me.cboZOFICLSE.Location = New System.Drawing.Point(137, 72)
        Me.cboZOFICLSE.Name = "cboZOFICLSE"
        Me.cboZOFICLSE.Size = New System.Drawing.Size(112, 22)
        Me.cboZOFICLSE.TabIndex = 3
        '
        'lblClaseosector
        '
        Me.lblClaseosector.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseosector.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseosector.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseosector.ForeColor = System.Drawing.Color.Black
        Me.lblClaseosector.Location = New System.Drawing.Point(19, 74)
        Me.lblClaseosector.Name = "lblClaseosector"
        Me.lblClaseosector.Size = New System.Drawing.Size(112, 20)
        Me.lblClaseosector.TabIndex = 56
        Me.lblClaseosector.Text = "Clase o sector"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'lblZOFIDEPA
        '
        Me.lblZOFIDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZOFIDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZOFIDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZOFIDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblZOFIDEPA.Location = New System.Drawing.Point(256, 28)
        Me.lblZOFIDEPA.Name = "lblZOFIDEPA"
        Me.lblZOFIDEPA.Size = New System.Drawing.Size(302, 20)
        Me.lblZOFIDEPA.TabIndex = 52
        '
        'cboZOFIDEPA
        '
        Me.cboZOFIDEPA.AccessibleDescription = "Departamento"
        Me.cboZOFIDEPA.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboZOFIDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboZOFIDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZOFIDEPA.Enabled = False
        Me.cboZOFIDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZOFIDEPA.FormattingEnabled = True
        Me.cboZOFIDEPA.Location = New System.Drawing.Point(137, 26)
        Me.cboZOFIDEPA.Name = "cboZOFIDEPA"
        Me.cboZOFIDEPA.Size = New System.Drawing.Size(112, 22)
        Me.cboZOFIDEPA.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 20)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Departamento"
        '
        'lblZOFIMUNI
        '
        Me.lblZOFIMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZOFIMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZOFIMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZOFIMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblZOFIMUNI.Location = New System.Drawing.Point(256, 51)
        Me.lblZOFIMUNI.Name = "lblZOFIMUNI"
        Me.lblZOFIMUNI.Size = New System.Drawing.Size(302, 20)
        Me.lblZOFIMUNI.TabIndex = 50
        '
        'cboZOFIMUNI
        '
        Me.cboZOFIMUNI.AccessibleDescription = "Municipio"
        Me.cboZOFIMUNI.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboZOFIMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboZOFIMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZOFIMUNI.Enabled = False
        Me.cboZOFIMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZOFIMUNI.FormattingEnabled = True
        Me.cboZOFIMUNI.Location = New System.Drawing.Point(137, 49)
        Me.cboZOFIMUNI.Name = "cboZOFIMUNI"
        Me.cboZOFIMUNI.Size = New System.Drawing.Size(112, 22)
        Me.cboZOFIMUNI.TabIndex = 2
        '
        'lblMUNICIPIO
        '
        Me.lblMUNICIPIO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMUNICIPIO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUNICIPIO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUNICIPIO.ForeColor = System.Drawing.Color.Black
        Me.lblMUNICIPIO.Location = New System.Drawing.Point(19, 51)
        Me.lblMUNICIPIO.Name = "lblMUNICIPIO"
        Me.lblMUNICIPIO.Size = New System.Drawing.Size(112, 20)
        Me.lblMUNICIPIO.TabIndex = 49
        Me.lblMUNICIPIO.Text = "Municipio"
        '
        'cboZOFIESTA
        '
        Me.cboZOFIESTA.AccessibleDescription = "Estado"
        Me.cboZOFIESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboZOFIESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZOFIESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZOFIESTA.FormattingEnabled = True
        Me.cboZOFIESTA.Location = New System.Drawing.Point(137, 143)
        Me.cboZOFIESTA.Name = "cboZOFIESTA"
        Me.cboZOFIESTA.Size = New System.Drawing.Size(112, 22)
        Me.cboZOFIESTA.TabIndex = 7
        '
        'txtZOFIDESC
        '
        Me.txtZOFIDESC.AccessibleDescription = "Descripción"
        Me.txtZOFIDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtZOFIDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZOFIDESC.Location = New System.Drawing.Point(137, 120)
        Me.txtZOFIDESC.MaxLength = 50
        Me.txtZOFIDESC.Name = "txtZOFIDESC"
        Me.txtZOFIDESC.Size = New System.Drawing.Size(421, 20)
        Me.txtZOFIDESC.TabIndex = 5
        '
        'txtZOFICODI
        '
        Me.txtZOFICODI.AccessibleDescription = "Código"
        Me.txtZOFICODI.BackColor = System.Drawing.SystemColors.Window
        Me.txtZOFICODI.Enabled = False
        Me.txtZOFICODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZOFICODI.Location = New System.Drawing.Point(137, 97)
        Me.txtZOFICODI.MaxLength = 3
        Me.txtZOFICODI.Name = "txtZOFICODI"
        Me.txtZOFICODI.Size = New System.Drawing.Size(112, 20)
        Me.txtZOFICODI.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Descripción"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(19, 97)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(112, 20)
        Me.lblCodigo.TabIndex = 37
        Me.lblCodigo.Text = "Zona física"
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(292, 17)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 9
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(185, 17)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 8
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 181)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 52)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        '
        'frm_modificar_ZONAFISI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdSALIR
        Me.ClientSize = New System.Drawing.Size(598, 260)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.fraZONAECONOMICA)
        Me.Controls.Add(Me.strBARRESTA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(614, 296)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(614, 296)
        Me.Name = "frm_modificar_ZONAFISI"
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraZONAECONOMICA.ResumeLayout(False)
        Me.fraZONAECONOMICA.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraZONAECONOMICA As System.Windows.Forms.GroupBox
    Friend WithEvents lblZOFICLSE As System.Windows.Forms.Label
    Friend WithEvents cboZOFICLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblZOFIDEPA As System.Windows.Forms.Label
    Friend WithEvents cboZOFIDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblZOFIMUNI As System.Windows.Forms.Label
    Friend WithEvents cboZOFIMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents cboZOFIESTA As System.Windows.Forms.ComboBox
    Friend WithEvents txtZOFIDESC As System.Windows.Forms.TextBox
    Friend WithEvents txtZOFICODI As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkZOFIZOCO As System.Windows.Forms.CheckBox
End Class
