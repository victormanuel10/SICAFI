<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_MUTAPRIM
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMUPRSECU = New System.Windows.Forms.Label()
        Me.fraFICHPRED = New System.Windows.Forms.GroupBox()
        Me.nudMUPRSEMA = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMUPRRESO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMUPRUSUA = New System.Windows.Forms.Label()
        Me.cboMUPRUSUA = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboMUPRTIRE = New System.Windows.Forms.ComboBox()
        Me.lblMUPRTIRE = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMUPROBSE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboMUPRESTA = New System.Windows.Forms.ComboBox()
        Me.cboMUPRVIGE = New System.Windows.Forms.ComboBox()
        Me.lblMUPRVIGE = New System.Windows.Forms.Label()
        Me.lblCategoriaDeSuelo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox2.SuspendLayout()
        Me.fraFICHPRED.SuspendLayout()
        CType(Me.nudMUPRSEMA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtMUPRSECU)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(15, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(637, 48)
        Me.GroupBox2.TabIndex = 347
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "REGISTRO"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(20, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 20)
        Me.Label8.TabIndex = 319
        Me.Label8.Text = "Nro. Secuencia"
        '
        'txtMUPRSECU
        '
        Me.txtMUPRSECU.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtMUPRSECU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtMUPRSECU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUPRSECU.ForeColor = System.Drawing.Color.Black
        Me.txtMUPRSECU.Location = New System.Drawing.Point(109, 17)
        Me.txtMUPRSECU.Name = "txtMUPRSECU"
        Me.txtMUPRSECU.Size = New System.Drawing.Size(86, 20)
        Me.txtMUPRSECU.TabIndex = 312
        Me.txtMUPRSECU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fraFICHPRED
        '
        Me.fraFICHPRED.BackColor = System.Drawing.SystemColors.Control
        Me.fraFICHPRED.Controls.Add(Me.nudMUPRSEMA)
        Me.fraFICHPRED.Controls.Add(Me.Label3)
        Me.fraFICHPRED.Controls.Add(Me.txtMUPRRESO)
        Me.fraFICHPRED.Controls.Add(Me.Label1)
        Me.fraFICHPRED.Controls.Add(Me.lblMUPRUSUA)
        Me.fraFICHPRED.Controls.Add(Me.cboMUPRUSUA)
        Me.fraFICHPRED.Controls.Add(Me.Label9)
        Me.fraFICHPRED.Controls.Add(Me.cboMUPRTIRE)
        Me.fraFICHPRED.Controls.Add(Me.lblMUPRTIRE)
        Me.fraFICHPRED.Controls.Add(Me.Label4)
        Me.fraFICHPRED.Controls.Add(Me.Label5)
        Me.fraFICHPRED.Controls.Add(Me.txtMUPROBSE)
        Me.fraFICHPRED.Controls.Add(Me.Label2)
        Me.fraFICHPRED.Controls.Add(Me.cboMUPRESTA)
        Me.fraFICHPRED.Controls.Add(Me.cboMUPRVIGE)
        Me.fraFICHPRED.Controls.Add(Me.lblMUPRVIGE)
        Me.fraFICHPRED.Controls.Add(Me.lblCategoriaDeSuelo)
        Me.fraFICHPRED.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraFICHPRED.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraFICHPRED.Location = New System.Drawing.Point(15, 67)
        Me.fraFICHPRED.Name = "fraFICHPRED"
        Me.fraFICHPRED.Size = New System.Drawing.Size(637, 266)
        Me.fraFICHPRED.TabIndex = 344
        Me.fraFICHPRED.TabStop = False
        Me.fraFICHPRED.Text = "INSERTAR MUTACIONES DE PRIMERA CLASE"
        '
        'nudMUPRSEMA
        '
        Me.nudMUPRSEMA.AccessibleDescription = "Semana"
        Me.nudMUPRSEMA.Location = New System.Drawing.Point(155, 95)
        Me.nudMUPRSEMA.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
        Me.nudMUPRSEMA.Name = "nudMUPRSEMA"
        Me.nudMUPRSEMA.Size = New System.Drawing.Size(160, 21)
        Me.nudMUPRSEMA.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(20, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 20)
        Me.Label3.TabIndex = 431
        Me.Label3.Text = "Nro. Semana"
        '
        'txtMUPRRESO
        '
        Me.txtMUPRRESO.AccessibleDescription = "Resolución"
        Me.txtMUPRRESO.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUPRRESO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMUPRRESO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUPRRESO.ForeColor = System.Drawing.Color.Black
        Me.txtMUPRRESO.Location = New System.Drawing.Point(155, 72)
        Me.txtMUPRRESO.MaxLength = 7
        Me.txtMUPRRESO.Name = "txtMUPRRESO"
        Me.txtMUPRRESO.Size = New System.Drawing.Size(160, 20)
        Me.txtMUPRRESO.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(20, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 20)
        Me.Label1.TabIndex = 429
        Me.Label1.Text = "Nro. Resolución"
        '
        'lblMUPRUSUA
        '
        Me.lblMUPRUSUA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblMUPRUSUA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUPRUSUA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUPRUSUA.ForeColor = System.Drawing.Color.Black
        Me.lblMUPRUSUA.Location = New System.Drawing.Point(499, 118)
        Me.lblMUPRUSUA.Name = "lblMUPRUSUA"
        Me.lblMUPRUSUA.Size = New System.Drawing.Size(121, 20)
        Me.lblMUPRUSUA.TabIndex = 422
        '
        'cboMUPRUSUA
        '
        Me.cboMUPRUSUA.AccessibleDescription = "Usuario"
        Me.cboMUPRUSUA.BackColor = System.Drawing.Color.White
        Me.cboMUPRUSUA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMUPRUSUA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMUPRUSUA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMUPRUSUA.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboMUPRUSUA.Location = New System.Drawing.Point(155, 116)
        Me.cboMUPRUSUA.MaxDropDownItems = 15
        Me.cboMUPRUSUA.MaxLength = 1
        Me.cboMUPRUSUA.Name = "cboMUPRUSUA"
        Me.cboMUPRUSUA.Size = New System.Drawing.Size(340, 22)
        Me.cboMUPRUSUA.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(20, 118)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(132, 20)
        Me.Label9.TabIndex = 421
        Me.Label9.Text = "Usuario"
        '
        'cboMUPRTIRE
        '
        Me.cboMUPRTIRE.AccessibleDescription = "Tipo de Resolución"
        Me.cboMUPRTIRE.BackColor = System.Drawing.Color.White
        Me.cboMUPRTIRE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMUPRTIRE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMUPRTIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMUPRTIRE.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboMUPRTIRE.Location = New System.Drawing.Point(155, 47)
        Me.cboMUPRTIRE.MaxDropDownItems = 15
        Me.cboMUPRTIRE.MaxLength = 2
        Me.cboMUPRTIRE.Name = "cboMUPRTIRE"
        Me.cboMUPRTIRE.Size = New System.Drawing.Size(340, 22)
        Me.cboMUPRTIRE.TabIndex = 2
        '
        'lblMUPRTIRE
        '
        Me.lblMUPRTIRE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblMUPRTIRE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUPRTIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUPRTIRE.ForeColor = System.Drawing.Color.Black
        Me.lblMUPRTIRE.Location = New System.Drawing.Point(499, 49)
        Me.lblMUPRTIRE.Name = "lblMUPRTIRE"
        Me.lblMUPRTIRE.Size = New System.Drawing.Size(121, 20)
        Me.lblMUPRTIRE.TabIndex = 419
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(20, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 20)
        Me.Label4.TabIndex = 418
        Me.Label4.Text = "Tipo de Resolución"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(20, 164)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(600, 20)
        Me.Label5.TabIndex = 380
        Me.Label5.Text = "OBSERVACIONES"
        '
        'txtMUPROBSE
        '
        Me.txtMUPROBSE.AccessibleDescription = "Observaciones"
        Me.txtMUPROBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUPROBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMUPROBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUPROBSE.ForeColor = System.Drawing.Color.Black
        Me.txtMUPROBSE.Location = New System.Drawing.Point(20, 187)
        Me.txtMUPROBSE.MaxLength = 1000
        Me.txtMUPROBSE.Multiline = True
        Me.txtMUPROBSE.Name = "txtMUPROBSE"
        Me.txtMUPROBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMUPROBSE.Size = New System.Drawing.Size(600, 60)
        Me.txtMUPROBSE.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(20, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 20)
        Me.Label2.TabIndex = 301
        Me.Label2.Text = "Estado"
        '
        'cboMUPRESTA
        '
        Me.cboMUPRESTA.AccessibleDescription = "Estado"
        Me.cboMUPRESTA.BackColor = System.Drawing.Color.White
        Me.cboMUPRESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMUPRESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMUPRESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMUPRESTA.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11"})
        Me.cboMUPRESTA.Location = New System.Drawing.Point(155, 139)
        Me.cboMUPRESTA.MaxDropDownItems = 15
        Me.cboMUPRESTA.MaxLength = 2
        Me.cboMUPRESTA.Name = "cboMUPRESTA"
        Me.cboMUPRESTA.Size = New System.Drawing.Size(340, 22)
        Me.cboMUPRESTA.TabIndex = 6
        '
        'cboMUPRVIGE
        '
        Me.cboMUPRVIGE.AccessibleDescription = "Vigencia"
        Me.cboMUPRVIGE.BackColor = System.Drawing.Color.White
        Me.cboMUPRVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMUPRVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMUPRVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMUPRVIGE.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboMUPRVIGE.Location = New System.Drawing.Point(155, 24)
        Me.cboMUPRVIGE.MaxDropDownItems = 15
        Me.cboMUPRVIGE.MaxLength = 1
        Me.cboMUPRVIGE.Name = "cboMUPRVIGE"
        Me.cboMUPRVIGE.Size = New System.Drawing.Size(340, 22)
        Me.cboMUPRVIGE.TabIndex = 1
        '
        'lblMUPRVIGE
        '
        Me.lblMUPRVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblMUPRVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUPRVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUPRVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblMUPRVIGE.Location = New System.Drawing.Point(499, 26)
        Me.lblMUPRVIGE.Name = "lblMUPRVIGE"
        Me.lblMUPRVIGE.Size = New System.Drawing.Size(121, 20)
        Me.lblMUPRVIGE.TabIndex = 51
        '
        'lblCategoriaDeSuelo
        '
        Me.lblCategoriaDeSuelo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCategoriaDeSuelo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCategoriaDeSuelo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoriaDeSuelo.ForeColor = System.Drawing.Color.Black
        Me.lblCategoriaDeSuelo.Location = New System.Drawing.Point(20, 26)
        Me.lblCategoriaDeSuelo.Name = "lblCategoriaDeSuelo"
        Me.lblCategoriaDeSuelo.Size = New System.Drawing.Size(132, 20)
        Me.lblCategoriaDeSuelo.TabIndex = 44
        Me.lblCategoriaDeSuelo.Text = "Vigencia"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 339)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(637, 46)
        Me.GroupBox1.TabIndex = 345
        Me.GroupBox1.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(321, 15)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(214, 15)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 402)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(665, 25)
        Me.strBARRESTA.TabIndex = 346
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
        'frm_insertar_MUTAPRIM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 427)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.fraFICHPRED)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(681, 463)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(681, 463)
        Me.Name = "frm_insertar_MUTAPRIM"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox2.ResumeLayout(False)
        Me.fraFICHPRED.ResumeLayout(False)
        Me.fraFICHPRED.PerformLayout()
        CType(Me.nudMUPRSEMA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMUPRSECU As System.Windows.Forms.Label
    Friend WithEvents fraFICHPRED As System.Windows.Forms.GroupBox
    Friend WithEvents lblMUPRUSUA As System.Windows.Forms.Label
    Friend WithEvents cboMUPRUSUA As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboMUPRTIRE As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUPRTIRE As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMUPROBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboMUPRESTA As System.Windows.Forms.ComboBox
    Friend WithEvents cboMUPRVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUPRVIGE As System.Windows.Forms.Label
    Friend WithEvents lblCategoriaDeSuelo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudMUPRSEMA As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMUPRRESO As System.Windows.Forms.TextBox
End Class
