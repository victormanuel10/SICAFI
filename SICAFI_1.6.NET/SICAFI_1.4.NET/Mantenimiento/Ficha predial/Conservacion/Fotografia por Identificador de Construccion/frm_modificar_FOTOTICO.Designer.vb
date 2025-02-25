<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_FOTOTICO
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboFOTCTICO = New System.Windows.Forms.ComboBox()
        Me.lblFOTCTICO = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.cboFOTCCLCO = New System.Windows.Forms.ComboBox()
        Me.cboFOTCTIPO = New System.Windows.Forms.ComboBox()
        Me.lblFOTCCLCO = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblFOTCTIPO = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFOTCCAFO = New System.Windows.Forms.Label()
        Me.cboFOTCCAFO = New System.Windows.Forms.ComboBox()
        Me.cboFOTCESTA = New System.Windows.Forms.ComboBox()
        Me.lblCAPRESTA = New System.Windows.Forms.Label()
        Me.cboFOTCMUNI = New System.Windows.Forms.ComboBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.lblFOTCMUNI = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.cboFOTCCLSE = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cboFOTCDEPA = New System.Windows.Forms.ComboBox()
        Me.lblFOTCCLSE = New System.Windows.Forms.Label()
        Me.lblFOTCDEPA = New System.Windows.Forms.Label()
        Me.fraCOMANDOS.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraCOMANDOS
        '
        Me.fraCOMANDOS.Controls.Add(Me.cmdSALIR)
        Me.fraCOMANDOS.Controls.Add(Me.cmdGUARDAR)
        Me.fraCOMANDOS.Location = New System.Drawing.Point(12, 242)
        Me.fraCOMANDOS.Name = "fraCOMANDOS"
        Me.fraCOMANDOS.Size = New System.Drawing.Size(719, 50)
        Me.fraCOMANDOS.TabIndex = 398
        Me.fraCOMANDOS.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(362, 16)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(255, 16)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 309)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(745, 25)
        Me.strBARRESTA.TabIndex = 399
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboFOTCTICO)
        Me.GroupBox1.Controls.Add(Me.lblFOTCTICO)
        Me.GroupBox1.Controls.Add(Me.Label47)
        Me.GroupBox1.Controls.Add(Me.cboFOTCCLCO)
        Me.GroupBox1.Controls.Add(Me.cboFOTCTIPO)
        Me.GroupBox1.Controls.Add(Me.lblFOTCCLCO)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.lblFOTCTIPO)
        Me.GroupBox1.Controls.Add(Me.Label43)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblFOTCCAFO)
        Me.GroupBox1.Controls.Add(Me.cboFOTCCAFO)
        Me.GroupBox1.Controls.Add(Me.cboFOTCESTA)
        Me.GroupBox1.Controls.Add(Me.lblCAPRESTA)
        Me.GroupBox1.Controls.Add(Me.cboFOTCMUNI)
        Me.GroupBox1.Controls.Add(Me.Label60)
        Me.GroupBox1.Controls.Add(Me.lblFOTCMUNI)
        Me.GroupBox1.Controls.Add(Me.Label58)
        Me.GroupBox1.Controls.Add(Me.cboFOTCCLSE)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.cboFOTCDEPA)
        Me.GroupBox1.Controls.Add(Me.lblFOTCCLSE)
        Me.GroupBox1.Controls.Add(Me.lblFOTCDEPA)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(719, 226)
        Me.GroupBox1.TabIndex = 397
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "INSERTAR FOTOGRAFIA POR IDENTIFICADOR DE CONSTRUCCIÓN"
        '
        'cboFOTCTICO
        '
        Me.cboFOTCTICO.AccessibleDescription = "Tipo construcción"
        Me.cboFOTCTICO.BackColor = System.Drawing.Color.White
        Me.cboFOTCTICO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFOTCTICO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOTCTICO.Enabled = False
        Me.cboFOTCTICO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFOTCTICO.Location = New System.Drawing.Point(145, 139)
        Me.cboFOTCTICO.MaxDropDownItems = 15
        Me.cboFOTCTICO.MaxLength = 1
        Me.cboFOTCTICO.Name = "cboFOTCTICO"
        Me.cboFOTCTICO.Size = New System.Drawing.Size(424, 22)
        Me.cboFOTCTICO.TabIndex = 6
        '
        'lblFOTCTICO
        '
        Me.lblFOTCTICO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFOTCTICO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFOTCTICO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFOTCTICO.ForeColor = System.Drawing.Color.Black
        Me.lblFOTCTICO.Location = New System.Drawing.Point(573, 141)
        Me.lblFOTCTICO.Name = "lblFOTCTICO"
        Me.lblFOTCTICO.Size = New System.Drawing.Size(131, 20)
        Me.lblFOTCTICO.TabIndex = 412
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label47.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.Black
        Me.Label47.Location = New System.Drawing.Point(16, 141)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(126, 20)
        Me.Label47.TabIndex = 411
        Me.Label47.Text = "Identificador"
        '
        'cboFOTCCLCO
        '
        Me.cboFOTCCLCO.AccessibleDescription = "Clase construcción"
        Me.cboFOTCCLCO.BackColor = System.Drawing.Color.White
        Me.cboFOTCCLCO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFOTCCLCO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOTCCLCO.Enabled = False
        Me.cboFOTCCLCO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFOTCCLCO.Location = New System.Drawing.Point(145, 116)
        Me.cboFOTCCLCO.MaxDropDownItems = 15
        Me.cboFOTCCLCO.MaxLength = 1
        Me.cboFOTCCLCO.Name = "cboFOTCCLCO"
        Me.cboFOTCCLCO.Size = New System.Drawing.Size(424, 22)
        Me.cboFOTCCLCO.TabIndex = 5
        '
        'cboFOTCTIPO
        '
        Me.cboFOTCTIPO.AccessibleDescription = "Topo de calificación"
        Me.cboFOTCTIPO.BackColor = System.Drawing.Color.White
        Me.cboFOTCTIPO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFOTCTIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOTCTIPO.Enabled = False
        Me.cboFOTCTIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFOTCTIPO.Location = New System.Drawing.Point(145, 93)
        Me.cboFOTCTIPO.MaxDropDownItems = 15
        Me.cboFOTCTIPO.MaxLength = 1
        Me.cboFOTCTIPO.Name = "cboFOTCTIPO"
        Me.cboFOTCTIPO.Size = New System.Drawing.Size(424, 22)
        Me.cboFOTCTIPO.TabIndex = 4
        '
        'lblFOTCCLCO
        '
        Me.lblFOTCCLCO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFOTCCLCO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFOTCCLCO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFOTCCLCO.ForeColor = System.Drawing.Color.Black
        Me.lblFOTCCLCO.Location = New System.Drawing.Point(573, 118)
        Me.lblFOTCCLCO.Name = "lblFOTCCLCO"
        Me.lblFOTCCLCO.Size = New System.Drawing.Size(131, 20)
        Me.lblFOTCCLCO.TabIndex = 406
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(16, 118)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(126, 20)
        Me.Label13.TabIndex = 405
        Me.Label13.Text = "Clase de construcción"
        '
        'lblFOTCTIPO
        '
        Me.lblFOTCTIPO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFOTCTIPO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFOTCTIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFOTCTIPO.ForeColor = System.Drawing.Color.Black
        Me.lblFOTCTIPO.Location = New System.Drawing.Point(573, 95)
        Me.lblFOTCTIPO.Name = "lblFOTCTIPO"
        Me.lblFOTCTIPO.Size = New System.Drawing.Size(131, 20)
        Me.lblFOTCTIPO.TabIndex = 404
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label43.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.Black
        Me.Label43.Location = New System.Drawing.Point(16, 95)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(126, 20)
        Me.Label43.TabIndex = 403
        Me.Label43.Text = "Tipo de calificación"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 20)
        Me.Label3.TabIndex = 393
        Me.Label3.Text = "Carpeta fotografica"
        '
        'lblFOTCCAFO
        '
        Me.lblFOTCCAFO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFOTCCAFO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFOTCCAFO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFOTCCAFO.ForeColor = System.Drawing.Color.Black
        Me.lblFOTCCAFO.Location = New System.Drawing.Point(573, 164)
        Me.lblFOTCCAFO.Name = "lblFOTCCAFO"
        Me.lblFOTCCAFO.Size = New System.Drawing.Size(131, 20)
        Me.lblFOTCCAFO.TabIndex = 394
        '
        'cboFOTCCAFO
        '
        Me.cboFOTCCAFO.AccessibleDescription = "Carpeta"
        Me.cboFOTCCAFO.BackColor = System.Drawing.Color.White
        Me.cboFOTCCAFO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFOTCCAFO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOTCCAFO.Enabled = False
        Me.cboFOTCCAFO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFOTCCAFO.Location = New System.Drawing.Point(145, 162)
        Me.cboFOTCCAFO.MaxDropDownItems = 15
        Me.cboFOTCCAFO.MaxLength = 1
        Me.cboFOTCCAFO.Name = "cboFOTCCAFO"
        Me.cboFOTCCAFO.Size = New System.Drawing.Size(424, 22)
        Me.cboFOTCCAFO.TabIndex = 7
        '
        'cboFOTCESTA
        '
        Me.cboFOTCESTA.AccessibleDescription = "Estado"
        Me.cboFOTCESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFOTCESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOTCESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFOTCESTA.FormattingEnabled = True
        Me.cboFOTCESTA.Items.AddRange(New Object() {""})
        Me.cboFOTCESTA.Location = New System.Drawing.Point(145, 186)
        Me.cboFOTCESTA.Name = "cboFOTCESTA"
        Me.cboFOTCESTA.Size = New System.Drawing.Size(211, 22)
        Me.cboFOTCESTA.TabIndex = 8
        '
        'lblCAPRESTA
        '
        Me.lblCAPRESTA.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCAPRESTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAPRESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAPRESTA.ForeColor = System.Drawing.Color.Black
        Me.lblCAPRESTA.Location = New System.Drawing.Point(16, 187)
        Me.lblCAPRESTA.Name = "lblCAPRESTA"
        Me.lblCAPRESTA.Size = New System.Drawing.Size(126, 20)
        Me.lblCAPRESTA.TabIndex = 400
        Me.lblCAPRESTA.Text = "Estado"
        '
        'cboFOTCMUNI
        '
        Me.cboFOTCMUNI.AccessibleDescription = "Municipio"
        Me.cboFOTCMUNI.BackColor = System.Drawing.Color.White
        Me.cboFOTCMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFOTCMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOTCMUNI.Enabled = False
        Me.cboFOTCMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFOTCMUNI.Location = New System.Drawing.Point(145, 47)
        Me.cboFOTCMUNI.MaxDropDownItems = 15
        Me.cboFOTCMUNI.MaxLength = 1
        Me.cboFOTCMUNI.Name = "cboFOTCMUNI"
        Me.cboFOTCMUNI.Size = New System.Drawing.Size(424, 22)
        Me.cboFOTCMUNI.TabIndex = 2
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label60.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label60.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.ForeColor = System.Drawing.Color.Black
        Me.Label60.Location = New System.Drawing.Point(16, 49)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(126, 20)
        Me.Label60.TabIndex = 392
        Me.Label60.Text = "Municipio"
        '
        'lblFOTCMUNI
        '
        Me.lblFOTCMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFOTCMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFOTCMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFOTCMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblFOTCMUNI.Location = New System.Drawing.Point(573, 49)
        Me.lblFOTCMUNI.Name = "lblFOTCMUNI"
        Me.lblFOTCMUNI.Size = New System.Drawing.Size(131, 20)
        Me.lblFOTCMUNI.TabIndex = 391
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label58.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label58.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.Black
        Me.Label58.Location = New System.Drawing.Point(16, 26)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(126, 20)
        Me.Label58.TabIndex = 386
        Me.Label58.Text = "Departamento"
        '
        'cboFOTCCLSE
        '
        Me.cboFOTCCLSE.AccessibleDescription = "Clase o sector "
        Me.cboFOTCCLSE.BackColor = System.Drawing.Color.White
        Me.cboFOTCCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFOTCCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOTCCLSE.Enabled = False
        Me.cboFOTCCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFOTCCLSE.Location = New System.Drawing.Point(145, 70)
        Me.cboFOTCCLSE.MaxDropDownItems = 15
        Me.cboFOTCCLSE.MaxLength = 1
        Me.cboFOTCCLSE.Name = "cboFOTCCLSE"
        Me.cboFOTCCLSE.Size = New System.Drawing.Size(424, 22)
        Me.cboFOTCCLSE.TabIndex = 3
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(16, 72)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(126, 20)
        Me.Label27.TabIndex = 384
        Me.Label27.Text = "Clase o sector"
        '
        'cboFOTCDEPA
        '
        Me.cboFOTCDEPA.AccessibleDescription = "Departamento"
        Me.cboFOTCDEPA.BackColor = System.Drawing.Color.White
        Me.cboFOTCDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFOTCDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOTCDEPA.Enabled = False
        Me.cboFOTCDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFOTCDEPA.Location = New System.Drawing.Point(145, 24)
        Me.cboFOTCDEPA.MaxDropDownItems = 15
        Me.cboFOTCDEPA.MaxLength = 1
        Me.cboFOTCDEPA.Name = "cboFOTCDEPA"
        Me.cboFOTCDEPA.Size = New System.Drawing.Size(424, 22)
        Me.cboFOTCDEPA.TabIndex = 1
        '
        'lblFOTCCLSE
        '
        Me.lblFOTCCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFOTCCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFOTCCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFOTCCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblFOTCCLSE.Location = New System.Drawing.Point(573, 72)
        Me.lblFOTCCLSE.Name = "lblFOTCCLSE"
        Me.lblFOTCCLSE.Size = New System.Drawing.Size(131, 20)
        Me.lblFOTCCLSE.TabIndex = 385
        '
        'lblFOTCDEPA
        '
        Me.lblFOTCDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFOTCDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFOTCDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFOTCDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblFOTCDEPA.Location = New System.Drawing.Point(573, 26)
        Me.lblFOTCDEPA.Name = "lblFOTCDEPA"
        Me.lblFOTCDEPA.Size = New System.Drawing.Size(131, 20)
        Me.lblFOTCDEPA.TabIndex = 387
        '
        'frm_modificar_FOTOTICO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 334)
        Me.Controls.Add(Me.fraCOMANDOS)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(761, 370)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(761, 370)
        Me.Name = "frm_modificar_FOTOTICO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.fraCOMANDOS.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraCOMANDOS As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboFOTCTICO As System.Windows.Forms.ComboBox
    Friend WithEvents lblFOTCTICO As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents cboFOTCCLCO As System.Windows.Forms.ComboBox
    Friend WithEvents cboFOTCTIPO As System.Windows.Forms.ComboBox
    Friend WithEvents lblFOTCCLCO As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblFOTCTIPO As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFOTCCAFO As System.Windows.Forms.Label
    Friend WithEvents cboFOTCCAFO As System.Windows.Forms.ComboBox
    Friend WithEvents cboFOTCESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCAPRESTA As System.Windows.Forms.Label
    Friend WithEvents cboFOTCMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents lblFOTCMUNI As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents cboFOTCCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cboFOTCDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents lblFOTCCLSE As System.Windows.Forms.Label
    Friend WithEvents lblFOTCDEPA As System.Windows.Forms.Label
End Class
