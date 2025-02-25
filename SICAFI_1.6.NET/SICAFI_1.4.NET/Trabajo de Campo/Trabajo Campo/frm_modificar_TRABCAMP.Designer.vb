<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_TRABCAMP
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
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTRCASECU = New System.Windows.Forms.Label()
        Me.fraFICHPRED = New System.Windows.Forms.GroupBox()
        Me.txtTRCAMAIN = New System.Windows.Forms.MaskedTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTRCAOBSE_NUEVAS = New System.Windows.Forms.TextBox()
        Me.txtTRCADESC = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.nudTRCAPRMO = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nudTRCAPREL = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudTRCAPRNU = New System.Windows.Forms.NumericUpDown()
        Me.dtpTRCAFEES = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTRCAOBSE = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTRCACAAC = New System.Windows.Forms.ComboBox()
        Me.lblTRCACAAC = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTRCANOTA = New System.Windows.Forms.ComboBox()
        Me.cboTRCANOMU = New System.Windows.Forms.ComboBox()
        Me.cboTRCANODE = New System.Windows.Forms.ComboBox()
        Me.txtTRCAESCR = New System.Windows.Forms.MaskedTextBox()
        Me.lblTRCANOTA = New System.Windows.Forms.Label()
        Me.lblNotaria1 = New System.Windows.Forms.Label()
        Me.lblEscritura = New System.Windows.Forms.Label()
        Me.txtTRCAFEES = New System.Windows.Forms.MaskedTextBox()
        Me.lblFechaEscritura = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cboTRCAESTA = New System.Windows.Forms.ComboBox()
        Me.txtTRCACORR = New System.Windows.Forms.TextBox()
        Me.txtTRCAMUNI = New System.Windows.Forms.TextBox()
        Me.cboTRCAVIGE = New System.Windows.Forms.ComboBox()
        Me.cboTRCACLSE = New System.Windows.Forms.ComboBox()
        Me.lblTRCAVIGE = New System.Windows.Forms.Label()
        Me.lblTRCACLSE = New System.Windows.Forms.Label()
        Me.lblClaseOSector2 = New System.Windows.Forms.Label()
        Me.lblCategoriaDeSuelo = New System.Windows.Forms.Label()
        Me.txtTRCAPRED = New System.Windows.Forms.TextBox()
        Me.txtTRCAMANZ = New System.Windows.Forms.TextBox()
        Me.txtTRCABARR = New System.Windows.Forms.TextBox()
        Me.lblCodigoActual = New System.Windows.Forms.Label()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.lblManzana = New System.Windows.Forms.Label()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.fraFICHPRED.SuspendLayout()
        CType(Me.nudTRCAPRMO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTRCAPREL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTRCAPRNU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 557)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(601, 25)
        Me.strBARRESTA.TabIndex = 37
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtTRCASECU)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(17, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(566, 48)
        Me.GroupBox2.TabIndex = 338
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "TRAMITE"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(18, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 20)
        Me.Label8.TabIndex = 319
        Me.Label8.Text = "Nro. Secuencia"
        '
        'txtTRCASECU
        '
        Me.txtTRCASECU.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtTRCASECU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtTRCASECU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCASECU.ForeColor = System.Drawing.Color.Black
        Me.txtTRCASECU.Location = New System.Drawing.Point(111, 17)
        Me.txtTRCASECU.Name = "txtTRCASECU"
        Me.txtTRCASECU.Size = New System.Drawing.Size(79, 20)
        Me.txtTRCASECU.TabIndex = 312
        Me.txtTRCASECU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fraFICHPRED
        '
        Me.fraFICHPRED.BackColor = System.Drawing.SystemColors.Control
        Me.fraFICHPRED.Controls.Add(Me.txtTRCAMAIN)
        Me.fraFICHPRED.Controls.Add(Me.Label10)
        Me.fraFICHPRED.Controls.Add(Me.Label9)
        Me.fraFICHPRED.Controls.Add(Me.txtTRCAOBSE_NUEVAS)
        Me.fraFICHPRED.Controls.Add(Me.txtTRCADESC)
        Me.fraFICHPRED.Controls.Add(Me.Label7)
        Me.fraFICHPRED.Controls.Add(Me.nudTRCAPRMO)
        Me.fraFICHPRED.Controls.Add(Me.Label6)
        Me.fraFICHPRED.Controls.Add(Me.nudTRCAPREL)
        Me.fraFICHPRED.Controls.Add(Me.Label1)
        Me.fraFICHPRED.Controls.Add(Me.nudTRCAPRNU)
        Me.fraFICHPRED.Controls.Add(Me.dtpTRCAFEES)
        Me.fraFICHPRED.Controls.Add(Me.Label5)
        Me.fraFICHPRED.Controls.Add(Me.txtTRCAOBSE)
        Me.fraFICHPRED.Controls.Add(Me.Label4)
        Me.fraFICHPRED.Controls.Add(Me.cboTRCACAAC)
        Me.fraFICHPRED.Controls.Add(Me.lblTRCACAAC)
        Me.fraFICHPRED.Controls.Add(Me.Label3)
        Me.fraFICHPRED.Controls.Add(Me.cboTRCANOTA)
        Me.fraFICHPRED.Controls.Add(Me.cboTRCANOMU)
        Me.fraFICHPRED.Controls.Add(Me.cboTRCANODE)
        Me.fraFICHPRED.Controls.Add(Me.txtTRCAESCR)
        Me.fraFICHPRED.Controls.Add(Me.lblTRCANOTA)
        Me.fraFICHPRED.Controls.Add(Me.lblNotaria1)
        Me.fraFICHPRED.Controls.Add(Me.lblEscritura)
        Me.fraFICHPRED.Controls.Add(Me.txtTRCAFEES)
        Me.fraFICHPRED.Controls.Add(Me.lblFechaEscritura)
        Me.fraFICHPRED.Controls.Add(Me.Label2)
        Me.fraFICHPRED.Controls.Add(Me.Label33)
        Me.fraFICHPRED.Controls.Add(Me.cboTRCAESTA)
        Me.fraFICHPRED.Controls.Add(Me.txtTRCACORR)
        Me.fraFICHPRED.Controls.Add(Me.txtTRCAMUNI)
        Me.fraFICHPRED.Controls.Add(Me.cboTRCAVIGE)
        Me.fraFICHPRED.Controls.Add(Me.cboTRCACLSE)
        Me.fraFICHPRED.Controls.Add(Me.lblTRCAVIGE)
        Me.fraFICHPRED.Controls.Add(Me.lblTRCACLSE)
        Me.fraFICHPRED.Controls.Add(Me.lblClaseOSector2)
        Me.fraFICHPRED.Controls.Add(Me.lblCategoriaDeSuelo)
        Me.fraFICHPRED.Controls.Add(Me.txtTRCAPRED)
        Me.fraFICHPRED.Controls.Add(Me.txtTRCAMANZ)
        Me.fraFICHPRED.Controls.Add(Me.txtTRCABARR)
        Me.fraFICHPRED.Controls.Add(Me.lblCodigoActual)
        Me.fraFICHPRED.Controls.Add(Me.lblPredio)
        Me.fraFICHPRED.Controls.Add(Me.lblManzana)
        Me.fraFICHPRED.Controls.Add(Me.lblBarrio)
        Me.fraFICHPRED.Controls.Add(Me.lblCorregimiento)
        Me.fraFICHPRED.Controls.Add(Me.lblMunicipio)
        Me.fraFICHPRED.Controls.Add(Me.lblCodigo)
        Me.fraFICHPRED.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraFICHPRED.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraFICHPRED.Location = New System.Drawing.Point(17, 71)
        Me.fraFICHPRED.Name = "fraFICHPRED"
        Me.fraFICHPRED.Size = New System.Drawing.Size(566, 422)
        Me.fraFICHPRED.TabIndex = 336
        Me.fraFICHPRED.TabStop = False
        Me.fraFICHPRED.Text = "MODIFICAR TRABAJO DE CAMPO"
        '
        'txtTRCAMAIN
        '
        Me.txtTRCAMAIN.AccessibleDescription = "Matricula"
        Me.txtTRCAMAIN.BackColor = System.Drawing.Color.White
        Me.txtTRCAMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAMAIN.Location = New System.Drawing.Point(462, 233)
        Me.txtTRCAMAIN.Mask = "000-0000000"
        Me.txtTRCAMAIN.Name = "txtTRCAMAIN"
        Me.txtTRCAMAIN.Size = New System.Drawing.Size(85, 20)
        Me.txtTRCAMAIN.TabIndex = 17
        Me.txtTRCAMAIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(287, 233)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(173, 20)
        Me.Label10.TabIndex = 395
        Me.Label10.Text = "Matricula inmobiliaria"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(20, 302)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(263, 20)
        Me.Label9.TabIndex = 393
        Me.Label9.Text = "OBSERVACIONES NUEVAS"
        '
        'txtTRCAOBSE_NUEVAS
        '
        Me.txtTRCAOBSE_NUEVAS.AccessibleDescription = "Observaciones"
        Me.txtTRCAOBSE_NUEVAS.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCAOBSE_NUEVAS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRCAOBSE_NUEVAS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAOBSE_NUEVAS.ForeColor = System.Drawing.Color.Black
        Me.txtTRCAOBSE_NUEVAS.Location = New System.Drawing.Point(20, 325)
        Me.txtTRCAOBSE_NUEVAS.MaxLength = 1000
        Me.txtTRCAOBSE_NUEVAS.Multiline = True
        Me.txtTRCAOBSE_NUEVAS.Name = "txtTRCAOBSE_NUEVAS"
        Me.txtTRCAOBSE_NUEVAS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTRCAOBSE_NUEVAS.Size = New System.Drawing.Size(261, 80)
        Me.txtTRCAOBSE_NUEVAS.TabIndex = 20
        '
        'txtTRCADESC
        '
        Me.txtTRCADESC.AccessibleDescription = "Descripción"
        Me.txtTRCADESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCADESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRCADESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCADESC.Location = New System.Drawing.Point(111, 256)
        Me.txtTRCADESC.MaxLength = 100
        Me.txtTRCADESC.Name = "txtTRCADESC"
        Me.txtTRCADESC.Size = New System.Drawing.Size(436, 20)
        Me.txtTRCADESC.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(20, 256)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 20)
        Me.Label7.TabIndex = 391
        Me.Label7.Text = "Descripción"
        '
        'nudTRCAPRMO
        '
        Me.nudTRCAPRMO.AccessibleDescription = "Nro de predios modificar"
        Me.nudTRCAPRMO.Location = New System.Drawing.Point(463, 209)
        Me.nudTRCAPRMO.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudTRCAPRMO.Name = "nudTRCAPRMO"
        Me.nudTRCAPRMO.Size = New System.Drawing.Size(84, 21)
        Me.nudTRCAPRMO.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(287, 210)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(173, 20)
        Me.Label6.TabIndex = 389
        Me.Label6.Text = "Predios modificados"
        '
        'nudTRCAPREL
        '
        Me.nudTRCAPREL.AccessibleDescription = "Nro de predios eliminar"
        Me.nudTRCAPREL.Location = New System.Drawing.Point(199, 232)
        Me.nudTRCAPREL.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudTRCAPREL.Name = "nudTRCAPREL"
        Me.nudTRCAPREL.Size = New System.Drawing.Size(84, 21)
        Me.nudTRCAPREL.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(20, 233)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 20)
        Me.Label1.TabIndex = 388
        Me.Label1.Text = "Predios eliminados"
        '
        'nudTRCAPRNU
        '
        Me.nudTRCAPRNU.AccessibleDescription = "Nro de predios nuevos"
        Me.nudTRCAPRNU.Location = New System.Drawing.Point(199, 209)
        Me.nudTRCAPRNU.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudTRCAPRNU.Name = "nudTRCAPRNU"
        Me.nudTRCAPRNU.Size = New System.Drawing.Size(84, 21)
        Me.nudTRCAPRNU.TabIndex = 14
        '
        'dtpTRCAFEES
        '
        Me.dtpTRCAFEES.Location = New System.Drawing.Point(263, 162)
        Me.dtpTRCAFEES.Name = "dtpTRCAFEES"
        Me.dtpTRCAFEES.Size = New System.Drawing.Size(20, 21)
        Me.dtpTRCAFEES.TabIndex = 382
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(287, 302)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(260, 20)
        Me.Label5.TabIndex = 380
        Me.Label5.Text = "OBSERVACIONES ANTERIORES"
        '
        'txtTRCAOBSE
        '
        Me.txtTRCAOBSE.AccessibleDescription = "Observaciones"
        Me.txtTRCAOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCAOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRCAOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtTRCAOBSE.Location = New System.Drawing.Point(287, 325)
        Me.txtTRCAOBSE.MaxLength = 1000
        Me.txtTRCAOBSE.Multiline = True
        Me.txtTRCAOBSE.Name = "txtTRCAOBSE"
        Me.txtTRCAOBSE.ReadOnly = True
        Me.txtTRCAOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTRCAOBSE.Size = New System.Drawing.Size(260, 80)
        Me.txtTRCAOBSE.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(20, 210)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(176, 20)
        Me.Label4.TabIndex = 378
        Me.Label4.Text = "Predios nuevos"
        '
        'cboTRCACAAC
        '
        Me.cboTRCACAAC.AccessibleDescription = "Causa del acto"
        Me.cboTRCACAAC.BackColor = System.Drawing.Color.White
        Me.cboTRCACAAC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTRCACAAC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTRCACAAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTRCACAAC.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboTRCACAAC.Location = New System.Drawing.Point(111, 139)
        Me.cboTRCACAAC.MaxDropDownItems = 15
        Me.cboTRCACAAC.MaxLength = 1
        Me.cboTRCACAAC.Name = "cboTRCACAAC"
        Me.cboTRCACAAC.Size = New System.Drawing.Size(260, 22)
        Me.cboTRCACAAC.TabIndex = 8
        '
        'lblTRCACAAC
        '
        Me.lblTRCACAAC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTRCACAAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTRCACAAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTRCACAAC.ForeColor = System.Drawing.Color.Black
        Me.lblTRCACAAC.Location = New System.Drawing.Point(375, 141)
        Me.lblTRCACAAC.Name = "lblTRCACAAC"
        Me.lblTRCACAAC.Size = New System.Drawing.Size(172, 20)
        Me.lblTRCACAAC.TabIndex = 376
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(20, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 20)
        Me.Label3.TabIndex = 375
        Me.Label3.Text = "Causa del acto"
        '
        'cboTRCANOTA
        '
        Me.cboTRCANOTA.AccessibleDescription = "Notaria"
        Me.cboTRCANOTA.BackColor = System.Drawing.Color.White
        Me.cboTRCANOTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTRCANOTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTRCANOTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTRCANOTA.Items.AddRange(New Object() {"001"})
        Me.cboTRCANOTA.Location = New System.Drawing.Point(287, 185)
        Me.cboTRCANOTA.MaxLength = 2
        Me.cboTRCANOTA.Name = "cboTRCANOTA"
        Me.cboTRCANOTA.Size = New System.Drawing.Size(85, 22)
        Me.cboTRCANOTA.TabIndex = 13
        '
        'cboTRCANOMU
        '
        Me.cboTRCANOMU.AccessibleDescription = "Municipio"
        Me.cboTRCANOMU.BackColor = System.Drawing.Color.White
        Me.cboTRCANOMU.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTRCANOMU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTRCANOMU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTRCANOMU.Items.AddRange(New Object() {"001"})
        Me.cboTRCANOMU.Location = New System.Drawing.Point(199, 185)
        Me.cboTRCANOMU.MaxLength = 2
        Me.cboTRCANOMU.Name = "cboTRCANOMU"
        Me.cboTRCANOMU.Size = New System.Drawing.Size(84, 22)
        Me.cboTRCANOMU.TabIndex = 12
        '
        'cboTRCANODE
        '
        Me.cboTRCANODE.AccessibleDescription = "Departamento"
        Me.cboTRCANODE.BackColor = System.Drawing.Color.White
        Me.cboTRCANODE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTRCANODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTRCANODE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTRCANODE.Items.AddRange(New Object() {"001"})
        Me.cboTRCANODE.Location = New System.Drawing.Point(111, 185)
        Me.cboTRCANODE.MaxLength = 2
        Me.cboTRCANODE.Name = "cboTRCANODE"
        Me.cboTRCANODE.Size = New System.Drawing.Size(84, 22)
        Me.cboTRCANODE.TabIndex = 11
        '
        'txtTRCAESCR
        '
        Me.txtTRCAESCR.AccessibleDescription = "Escritura"
        Me.txtTRCAESCR.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCAESCR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAESCR.Location = New System.Drawing.Point(463, 162)
        Me.txtTRCAESCR.Name = "txtTRCAESCR"
        Me.txtTRCAESCR.Size = New System.Drawing.Size(84, 20)
        Me.txtTRCAESCR.TabIndex = 10
        Me.txtTRCAESCR.Text = "0"
        '
        'lblTRCANOTA
        '
        Me.lblTRCANOTA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTRCANOTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTRCANOTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTRCANOTA.ForeColor = System.Drawing.Color.Black
        Me.lblTRCANOTA.Location = New System.Drawing.Point(375, 187)
        Me.lblTRCANOTA.Name = "lblTRCANOTA"
        Me.lblTRCANOTA.Size = New System.Drawing.Size(173, 20)
        Me.lblTRCANOTA.TabIndex = 373
        '
        'lblNotaria1
        '
        Me.lblNotaria1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblNotaria1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNotaria1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotaria1.ForeColor = System.Drawing.Color.Black
        Me.lblNotaria1.Location = New System.Drawing.Point(20, 187)
        Me.lblNotaria1.Name = "lblNotaria1"
        Me.lblNotaria1.Size = New System.Drawing.Size(85, 20)
        Me.lblNotaria1.TabIndex = 372
        Me.lblNotaria1.Text = "Notaria"
        '
        'lblEscritura
        '
        Me.lblEscritura.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblEscritura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEscritura.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEscritura.ForeColor = System.Drawing.Color.Black
        Me.lblEscritura.Location = New System.Drawing.Point(287, 163)
        Me.lblEscritura.Name = "lblEscritura"
        Me.lblEscritura.Size = New System.Drawing.Size(172, 20)
        Me.lblEscritura.TabIndex = 371
        Me.lblEscritura.Text = "Escritura"
        '
        'txtTRCAFEES
        '
        Me.txtTRCAFEES.AccessibleDescription = "Fecha de escritura"
        Me.txtTRCAFEES.BackColor = System.Drawing.Color.White
        Me.txtTRCAFEES.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAFEES.Location = New System.Drawing.Point(111, 163)
        Me.txtTRCAFEES.Mask = "00-00-0000"
        Me.txtTRCAFEES.Name = "txtTRCAFEES"
        Me.txtTRCAFEES.Size = New System.Drawing.Size(150, 20)
        Me.txtTRCAFEES.TabIndex = 9
        Me.txtTRCAFEES.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblFechaEscritura
        '
        Me.lblFechaEscritura.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblFechaEscritura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFechaEscritura.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaEscritura.ForeColor = System.Drawing.Color.Black
        Me.lblFechaEscritura.Location = New System.Drawing.Point(20, 164)
        Me.lblFechaEscritura.Name = "lblFechaEscritura"
        Me.lblFechaEscritura.Size = New System.Drawing.Size(85, 20)
        Me.lblFechaEscritura.TabIndex = 365
        Me.lblFechaEscritura.Text = "Fec. Escritura"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(20, 279)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 20)
        Me.Label2.TabIndex = 301
        Me.Label2.Text = "Estado"
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(20, 26)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(527, 20)
        Me.Label33.TabIndex = 278
        Me.Label33.Text = "CEDULA CATASTRAL ACTUAL"
        '
        'cboTRCAESTA
        '
        Me.cboTRCAESTA.AccessibleDescription = "Estado"
        Me.cboTRCAESTA.BackColor = System.Drawing.Color.White
        Me.cboTRCAESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTRCAESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTRCAESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTRCAESTA.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11"})
        Me.cboTRCAESTA.Location = New System.Drawing.Point(111, 277)
        Me.cboTRCAESTA.MaxDropDownItems = 15
        Me.cboTRCAESTA.MaxLength = 2
        Me.cboTRCAESTA.Name = "cboTRCAESTA"
        Me.cboTRCAESTA.Size = New System.Drawing.Size(172, 22)
        Me.cboTRCAESTA.TabIndex = 19
        '
        'txtTRCACORR
        '
        Me.txtTRCACORR.AccessibleDescription = "Corregimiento"
        Me.txtTRCACORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCACORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCACORR.Location = New System.Drawing.Point(199, 72)
        Me.txtTRCACORR.MaxLength = 2
        Me.txtTRCACORR.Name = "txtTRCACORR"
        Me.txtTRCACORR.ReadOnly = True
        Me.txtTRCACORR.Size = New System.Drawing.Size(85, 20)
        Me.txtTRCACORR.TabIndex = 2
        '
        'txtTRCAMUNI
        '
        Me.txtTRCAMUNI.AccessibleDescription = "Municipio"
        Me.txtTRCAMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCAMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAMUNI.Location = New System.Drawing.Point(111, 72)
        Me.txtTRCAMUNI.MaxLength = 3
        Me.txtTRCAMUNI.Name = "txtTRCAMUNI"
        Me.txtTRCAMUNI.ReadOnly = True
        Me.txtTRCAMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtTRCAMUNI.TabIndex = 1
        '
        'cboTRCAVIGE
        '
        Me.cboTRCAVIGE.AccessibleDescription = "Vigencia"
        Me.cboTRCAVIGE.BackColor = System.Drawing.Color.White
        Me.cboTRCAVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTRCAVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTRCAVIGE.Enabled = False
        Me.cboTRCAVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTRCAVIGE.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboTRCAVIGE.Location = New System.Drawing.Point(111, 116)
        Me.cboTRCAVIGE.MaxDropDownItems = 15
        Me.cboTRCAVIGE.MaxLength = 1
        Me.cboTRCAVIGE.Name = "cboTRCAVIGE"
        Me.cboTRCAVIGE.Size = New System.Drawing.Size(173, 22)
        Me.cboTRCAVIGE.TabIndex = 7
        '
        'cboTRCACLSE
        '
        Me.cboTRCACLSE.AccessibleDescription = "Clase o sector "
        Me.cboTRCACLSE.BackColor = System.Drawing.Color.White
        Me.cboTRCACLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTRCACLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTRCACLSE.Enabled = False
        Me.cboTRCACLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTRCACLSE.Location = New System.Drawing.Point(111, 93)
        Me.cboTRCACLSE.MaxDropDownItems = 15
        Me.cboTRCACLSE.MaxLength = 1
        Me.cboTRCACLSE.Name = "cboTRCACLSE"
        Me.cboTRCACLSE.Size = New System.Drawing.Size(173, 22)
        Me.cboTRCACLSE.TabIndex = 6
        '
        'lblTRCAVIGE
        '
        Me.lblTRCAVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTRCAVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTRCAVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTRCAVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblTRCAVIGE.Location = New System.Drawing.Point(287, 118)
        Me.lblTRCAVIGE.Name = "lblTRCAVIGE"
        Me.lblTRCAVIGE.Size = New System.Drawing.Size(260, 20)
        Me.lblTRCAVIGE.TabIndex = 51
        '
        'lblTRCACLSE
        '
        Me.lblTRCACLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTRCACLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTRCACLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTRCACLSE.ForeColor = System.Drawing.Color.Black
        Me.lblTRCACLSE.Location = New System.Drawing.Point(287, 95)
        Me.lblTRCACLSE.Name = "lblTRCACLSE"
        Me.lblTRCACLSE.Size = New System.Drawing.Size(260, 20)
        Me.lblTRCACLSE.TabIndex = 47
        '
        'lblClaseOSector2
        '
        Me.lblClaseOSector2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseOSector2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseOSector2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseOSector2.ForeColor = System.Drawing.Color.Black
        Me.lblClaseOSector2.Location = New System.Drawing.Point(20, 95)
        Me.lblClaseOSector2.Name = "lblClaseOSector2"
        Me.lblClaseOSector2.Size = New System.Drawing.Size(85, 20)
        Me.lblClaseOSector2.TabIndex = 45
        Me.lblClaseOSector2.Text = "Clase o Sector"
        '
        'lblCategoriaDeSuelo
        '
        Me.lblCategoriaDeSuelo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCategoriaDeSuelo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCategoriaDeSuelo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoriaDeSuelo.ForeColor = System.Drawing.Color.Black
        Me.lblCategoriaDeSuelo.Location = New System.Drawing.Point(20, 118)
        Me.lblCategoriaDeSuelo.Name = "lblCategoriaDeSuelo"
        Me.lblCategoriaDeSuelo.Size = New System.Drawing.Size(85, 20)
        Me.lblCategoriaDeSuelo.TabIndex = 44
        Me.lblCategoriaDeSuelo.Text = "Vigencia"
        '
        'txtTRCAPRED
        '
        Me.txtTRCAPRED.AccessibleDescription = "Predio "
        Me.txtTRCAPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCAPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRCAPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAPRED.ForeColor = System.Drawing.Color.Black
        Me.txtTRCAPRED.Location = New System.Drawing.Point(463, 72)
        Me.txtTRCAPRED.MaxLength = 5
        Me.txtTRCAPRED.Name = "txtTRCAPRED"
        Me.txtTRCAPRED.ReadOnly = True
        Me.txtTRCAPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtTRCAPRED.TabIndex = 5
        '
        'txtTRCAMANZ
        '
        Me.txtTRCAMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtTRCAMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCAMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRCAMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtTRCAMANZ.Location = New System.Drawing.Point(375, 72)
        Me.txtTRCAMANZ.MaxLength = 3
        Me.txtTRCAMANZ.Name = "txtTRCAMANZ"
        Me.txtTRCAMANZ.ReadOnly = True
        Me.txtTRCAMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtTRCAMANZ.TabIndex = 4
        '
        'txtTRCABARR
        '
        Me.txtTRCABARR.AccessibleDescription = "Barrio "
        Me.txtTRCABARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCABARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRCABARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCABARR.ForeColor = System.Drawing.Color.Black
        Me.txtTRCABARR.Location = New System.Drawing.Point(287, 72)
        Me.txtTRCABARR.MaxLength = 3
        Me.txtTRCABARR.Name = "txtTRCABARR"
        Me.txtTRCABARR.ReadOnly = True
        Me.txtTRCABARR.Size = New System.Drawing.Size(85, 20)
        Me.txtTRCABARR.TabIndex = 3
        '
        'lblCodigoActual
        '
        Me.lblCodigoActual.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigoActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigoActual.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoActual.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoActual.Location = New System.Drawing.Point(20, 72)
        Me.lblCodigoActual.Name = "lblCodigoActual"
        Me.lblCodigoActual.Size = New System.Drawing.Size(85, 20)
        Me.lblCodigoActual.TabIndex = 27
        Me.lblCodigoActual.Text = "Código Actual"
        '
        'lblPredio
        '
        Me.lblPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredio.ForeColor = System.Drawing.Color.Black
        Me.lblPredio.Location = New System.Drawing.Point(463, 49)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(84, 20)
        Me.lblPredio.TabIndex = 24
        Me.lblPredio.Text = "Predio"
        '
        'lblManzana
        '
        Me.lblManzana.AccessibleDescription = ""
        Me.lblManzana.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblManzana.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblManzana.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManzana.ForeColor = System.Drawing.Color.Black
        Me.lblManzana.Location = New System.Drawing.Point(375, 49)
        Me.lblManzana.Name = "lblManzana"
        Me.lblManzana.Size = New System.Drawing.Size(84, 20)
        Me.lblManzana.TabIndex = 23
        Me.lblManzana.Text = "Manza / Vered"
        '
        'lblBarrio
        '
        Me.lblBarrio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblBarrio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBarrio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarrio.ForeColor = System.Drawing.Color.Black
        Me.lblBarrio.Location = New System.Drawing.Point(287, 49)
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Size = New System.Drawing.Size(84, 20)
        Me.lblBarrio.TabIndex = 22
        Me.lblBarrio.Text = "Barrio"
        '
        'lblCorregimiento
        '
        Me.lblCorregimiento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCorregimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorregimiento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorregimiento.ForeColor = System.Drawing.Color.Black
        Me.lblCorregimiento.Location = New System.Drawing.Point(199, 49)
        Me.lblCorregimiento.Name = "lblCorregimiento"
        Me.lblCorregimiento.Size = New System.Drawing.Size(84, 20)
        Me.lblCorregimiento.TabIndex = 30
        Me.lblCorregimiento.Text = "Corregimiento"
        '
        'lblMunicipio
        '
        Me.lblMunicipio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblMunicipio.Location = New System.Drawing.Point(111, 49)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(84, 20)
        Me.lblMunicipio.TabIndex = 300
        Me.lblMunicipio.Text = "Municipio"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(20, 49)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(85, 20)
        Me.lblCodigo.TabIndex = 300
        Me.lblCodigo.Text = "CODIGO"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 499)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(566, 46)
        Me.GroupBox1.TabIndex = 337
        Me.GroupBox1.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(292, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 18
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(185, 15)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 17
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'frm_modificar_TRABCAMP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 582)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.fraFICHPRED)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_modificar_TRABCAMP"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.fraFICHPRED.ResumeLayout(False)
        Me.fraFICHPRED.PerformLayout()
        CType(Me.nudTRCAPRMO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTRCAPREL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTRCAPRNU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTRCASECU As System.Windows.Forms.Label
    Friend WithEvents fraFICHPRED As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTRCAOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTRCACAAC As System.Windows.Forms.ComboBox
    Friend WithEvents lblTRCACAAC As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboTRCANOTA As System.Windows.Forms.ComboBox
    Friend WithEvents cboTRCANOMU As System.Windows.Forms.ComboBox
    Friend WithEvents cboTRCANODE As System.Windows.Forms.ComboBox
    Friend WithEvents txtTRCAESCR As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblTRCANOTA As System.Windows.Forms.Label
    Friend WithEvents lblNotaria1 As System.Windows.Forms.Label
    Friend WithEvents lblEscritura As System.Windows.Forms.Label
    Friend WithEvents txtTRCAFEES As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblFechaEscritura As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cboTRCAESTA As System.Windows.Forms.ComboBox
    Friend WithEvents txtTRCACORR As System.Windows.Forms.TextBox
    Friend WithEvents txtTRCAMUNI As System.Windows.Forms.TextBox
    Friend WithEvents cboTRCAVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents cboTRCACLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblTRCAVIGE As System.Windows.Forms.Label
    Friend WithEvents lblTRCACLSE As System.Windows.Forms.Label
    Friend WithEvents lblClaseOSector2 As System.Windows.Forms.Label
    Friend WithEvents lblCategoriaDeSuelo As System.Windows.Forms.Label
    Friend WithEvents txtTRCAPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtTRCAMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtTRCABARR As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents dtpTRCAFEES As System.Windows.Forms.DateTimePicker
    Friend WithEvents nudTRCAPRNU As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudTRCAPRMO As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nudTRCAPREL As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTRCADESC As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTRCAOBSE_NUEVAS As System.Windows.Forms.TextBox
    Friend WithEvents txtTRCAMAIN As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
