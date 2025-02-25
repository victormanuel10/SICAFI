<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_MOVIGEOG
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
        Me.txtMOGESECU = New System.Windows.Forms.Label()
        Me.fraFICHPRED = New System.Windows.Forms.GroupBox()
        Me.cboMOGENUDO = New System.Windows.Forms.ComboBox()
        Me.lblMOGENUDO = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboMOGECLVE = New System.Windows.Forms.ComboBox()
        Me.lblMOGECLVE = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMOGEOBSE = New System.Windows.Forms.TextBox()
        Me.cboMOGECAAC = New System.Windows.Forms.ComboBox()
        Me.lblMOGECAAC = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cboMOGEESTA = New System.Windows.Forms.ComboBox()
        Me.txtMOGECORR = New System.Windows.Forms.TextBox()
        Me.txtMOGEMUNI = New System.Windows.Forms.TextBox()
        Me.cboMOGEVIGE = New System.Windows.Forms.ComboBox()
        Me.cboMOGECLSE = New System.Windows.Forms.ComboBox()
        Me.lblMOGEVIGE = New System.Windows.Forms.Label()
        Me.lblMOGECLSE = New System.Windows.Forms.Label()
        Me.lblClaseOSector2 = New System.Windows.Forms.Label()
        Me.lblCategoriaDeSuelo = New System.Windows.Forms.Label()
        Me.txtMOGEPRED = New System.Windows.Forms.TextBox()
        Me.txtMOGEMANZ = New System.Windows.Forms.TextBox()
        Me.txtMOGEBARR = New System.Windows.Forms.TextBox()
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
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox2.SuspendLayout()
        Me.fraFICHPRED.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtMOGESECU)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(16, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(566, 48)
        Me.GroupBox2.TabIndex = 339
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
        Me.Label8.Size = New System.Drawing.Size(90, 20)
        Me.Label8.TabIndex = 319
        Me.Label8.Text = "Nro. Secuencia"
        '
        'txtMOGESECU
        '
        Me.txtMOGESECU.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtMOGESECU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtMOGESECU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOGESECU.ForeColor = System.Drawing.Color.Black
        Me.txtMOGESECU.Location = New System.Drawing.Point(111, 17)
        Me.txtMOGESECU.Name = "txtMOGESECU"
        Me.txtMOGESECU.Size = New System.Drawing.Size(172, 20)
        Me.txtMOGESECU.TabIndex = 312
        Me.txtMOGESECU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fraFICHPRED
        '
        Me.fraFICHPRED.BackColor = System.Drawing.SystemColors.Control
        Me.fraFICHPRED.Controls.Add(Me.cboMOGENUDO)
        Me.fraFICHPRED.Controls.Add(Me.lblMOGENUDO)
        Me.fraFICHPRED.Controls.Add(Me.Label4)
        Me.fraFICHPRED.Controls.Add(Me.cboMOGECLVE)
        Me.fraFICHPRED.Controls.Add(Me.lblMOGECLVE)
        Me.fraFICHPRED.Controls.Add(Me.Label10)
        Me.fraFICHPRED.Controls.Add(Me.Label5)
        Me.fraFICHPRED.Controls.Add(Me.txtMOGEOBSE)
        Me.fraFICHPRED.Controls.Add(Me.cboMOGECAAC)
        Me.fraFICHPRED.Controls.Add(Me.lblMOGECAAC)
        Me.fraFICHPRED.Controls.Add(Me.Label3)
        Me.fraFICHPRED.Controls.Add(Me.Label2)
        Me.fraFICHPRED.Controls.Add(Me.Label33)
        Me.fraFICHPRED.Controls.Add(Me.cboMOGEESTA)
        Me.fraFICHPRED.Controls.Add(Me.txtMOGECORR)
        Me.fraFICHPRED.Controls.Add(Me.txtMOGEMUNI)
        Me.fraFICHPRED.Controls.Add(Me.cboMOGEVIGE)
        Me.fraFICHPRED.Controls.Add(Me.cboMOGECLSE)
        Me.fraFICHPRED.Controls.Add(Me.lblMOGEVIGE)
        Me.fraFICHPRED.Controls.Add(Me.lblMOGECLSE)
        Me.fraFICHPRED.Controls.Add(Me.lblClaseOSector2)
        Me.fraFICHPRED.Controls.Add(Me.lblCategoriaDeSuelo)
        Me.fraFICHPRED.Controls.Add(Me.txtMOGEPRED)
        Me.fraFICHPRED.Controls.Add(Me.txtMOGEMANZ)
        Me.fraFICHPRED.Controls.Add(Me.txtMOGEBARR)
        Me.fraFICHPRED.Controls.Add(Me.lblCodigoActual)
        Me.fraFICHPRED.Controls.Add(Me.lblPredio)
        Me.fraFICHPRED.Controls.Add(Me.lblManzana)
        Me.fraFICHPRED.Controls.Add(Me.lblBarrio)
        Me.fraFICHPRED.Controls.Add(Me.lblCorregimiento)
        Me.fraFICHPRED.Controls.Add(Me.lblMunicipio)
        Me.fraFICHPRED.Controls.Add(Me.lblCodigo)
        Me.fraFICHPRED.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraFICHPRED.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraFICHPRED.Location = New System.Drawing.Point(16, 66)
        Me.fraFICHPRED.Name = "fraFICHPRED"
        Me.fraFICHPRED.Size = New System.Drawing.Size(566, 369)
        Me.fraFICHPRED.TabIndex = 336
        Me.fraFICHPRED.TabStop = False
        Me.fraFICHPRED.Text = "INSERTAR MOVIMIENTO GEOGRAFICO"
        '
        'cboMOGENUDO
        '
        Me.cboMOGENUDO.AccessibleDescription = "Nro. Documento"
        Me.cboMOGENUDO.BackColor = System.Drawing.Color.White
        Me.cboMOGENUDO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMOGENUDO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMOGENUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMOGENUDO.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboMOGENUDO.Location = New System.Drawing.Point(111, 139)
        Me.cboMOGENUDO.MaxDropDownItems = 15
        Me.cboMOGENUDO.MaxLength = 1
        Me.cboMOGENUDO.Name = "cboMOGENUDO"
        Me.cboMOGENUDO.Size = New System.Drawing.Size(261, 22)
        Me.cboMOGENUDO.TabIndex = 8
        '
        'lblMOGENUDO
        '
        Me.lblMOGENUDO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblMOGENUDO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMOGENUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMOGENUDO.ForeColor = System.Drawing.Color.Black
        Me.lblMOGENUDO.Location = New System.Drawing.Point(375, 141)
        Me.lblMOGENUDO.Name = "lblMOGENUDO"
        Me.lblMOGENUDO.Size = New System.Drawing.Size(172, 20)
        Me.lblMOGENUDO.TabIndex = 393
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(20, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 20)
        Me.Label4.TabIndex = 392
        Me.Label4.Text = "Funcionario"
        '
        'cboMOGECLVE
        '
        Me.cboMOGECLVE.AccessibleDescription = "Clase de versión"
        Me.cboMOGECLVE.BackColor = System.Drawing.Color.White
        Me.cboMOGECLVE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMOGECLVE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMOGECLVE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMOGECLVE.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboMOGECLVE.Location = New System.Drawing.Point(111, 185)
        Me.cboMOGECLVE.MaxDropDownItems = 15
        Me.cboMOGECLVE.MaxLength = 1
        Me.cboMOGECLVE.Name = "cboMOGECLVE"
        Me.cboMOGECLVE.Size = New System.Drawing.Size(173, 22)
        Me.cboMOGECLVE.TabIndex = 10
        '
        'lblMOGECLVE
        '
        Me.lblMOGECLVE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblMOGECLVE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMOGECLVE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMOGECLVE.ForeColor = System.Drawing.Color.Black
        Me.lblMOGECLVE.Location = New System.Drawing.Point(287, 187)
        Me.lblMOGECLVE.Name = "lblMOGECLVE"
        Me.lblMOGECLVE.Size = New System.Drawing.Size(260, 20)
        Me.lblMOGECLVE.TabIndex = 390
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(20, 187)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 20)
        Me.Label10.TabIndex = 389
        Me.Label10.Text = "Clase versión"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(20, 233)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(527, 20)
        Me.Label5.TabIndex = 380
        Me.Label5.Text = "OBSERVACIONES"
        '
        'txtMOGEOBSE
        '
        Me.txtMOGEOBSE.AccessibleDescription = "Observaciones"
        Me.txtMOGEOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOGEOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOGEOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOGEOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtMOGEOBSE.Location = New System.Drawing.Point(20, 256)
        Me.txtMOGEOBSE.MaxLength = 1000
        Me.txtMOGEOBSE.Multiline = True
        Me.txtMOGEOBSE.Name = "txtMOGEOBSE"
        Me.txtMOGEOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMOGEOBSE.Size = New System.Drawing.Size(527, 96)
        Me.txtMOGEOBSE.TabIndex = 12
        '
        'cboMOGECAAC
        '
        Me.cboMOGECAAC.AccessibleDescription = "Causa del acto"
        Me.cboMOGECAAC.BackColor = System.Drawing.Color.White
        Me.cboMOGECAAC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMOGECAAC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMOGECAAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMOGECAAC.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboMOGECAAC.Location = New System.Drawing.Point(111, 162)
        Me.cboMOGECAAC.MaxDropDownItems = 15
        Me.cboMOGECAAC.MaxLength = 1
        Me.cboMOGECAAC.Name = "cboMOGECAAC"
        Me.cboMOGECAAC.Size = New System.Drawing.Size(261, 22)
        Me.cboMOGECAAC.TabIndex = 9
        '
        'lblMOGECAAC
        '
        Me.lblMOGECAAC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblMOGECAAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMOGECAAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMOGECAAC.ForeColor = System.Drawing.Color.Black
        Me.lblMOGECAAC.Location = New System.Drawing.Point(375, 164)
        Me.lblMOGECAAC.Name = "lblMOGECAAC"
        Me.lblMOGECAAC.Size = New System.Drawing.Size(172, 20)
        Me.lblMOGECAAC.TabIndex = 376
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(20, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 20)
        Me.Label3.TabIndex = 375
        Me.Label3.Text = "Causa del acto"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(20, 210)
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
        Me.Label33.Text = "CEDULA CATASTRAL"
        '
        'cboMOGEESTA
        '
        Me.cboMOGEESTA.AccessibleDescription = "Estado"
        Me.cboMOGEESTA.BackColor = System.Drawing.Color.White
        Me.cboMOGEESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMOGEESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMOGEESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMOGEESTA.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11"})
        Me.cboMOGEESTA.Location = New System.Drawing.Point(111, 208)
        Me.cboMOGEESTA.MaxDropDownItems = 15
        Me.cboMOGEESTA.MaxLength = 2
        Me.cboMOGEESTA.Name = "cboMOGEESTA"
        Me.cboMOGEESTA.Size = New System.Drawing.Size(173, 22)
        Me.cboMOGEESTA.TabIndex = 11
        '
        'txtMOGECORR
        '
        Me.txtMOGECORR.AccessibleDescription = "Corregimiento"
        Me.txtMOGECORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOGECORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOGECORR.Location = New System.Drawing.Point(199, 72)
        Me.txtMOGECORR.MaxLength = 2
        Me.txtMOGECORR.Name = "txtMOGECORR"
        Me.txtMOGECORR.Size = New System.Drawing.Size(85, 20)
        Me.txtMOGECORR.TabIndex = 2
        '
        'txtMOGEMUNI
        '
        Me.txtMOGEMUNI.AccessibleDescription = "Municipio"
        Me.txtMOGEMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOGEMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOGEMUNI.Location = New System.Drawing.Point(111, 72)
        Me.txtMOGEMUNI.MaxLength = 3
        Me.txtMOGEMUNI.Name = "txtMOGEMUNI"
        Me.txtMOGEMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtMOGEMUNI.TabIndex = 1
        '
        'cboMOGEVIGE
        '
        Me.cboMOGEVIGE.AccessibleDescription = "Vigencia"
        Me.cboMOGEVIGE.BackColor = System.Drawing.Color.White
        Me.cboMOGEVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMOGEVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMOGEVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMOGEVIGE.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboMOGEVIGE.Location = New System.Drawing.Point(111, 116)
        Me.cboMOGEVIGE.MaxDropDownItems = 15
        Me.cboMOGEVIGE.MaxLength = 1
        Me.cboMOGEVIGE.Name = "cboMOGEVIGE"
        Me.cboMOGEVIGE.Size = New System.Drawing.Size(173, 22)
        Me.cboMOGEVIGE.TabIndex = 7
        '
        'cboMOGECLSE
        '
        Me.cboMOGECLSE.AccessibleDescription = "Clase o sector "
        Me.cboMOGECLSE.BackColor = System.Drawing.Color.White
        Me.cboMOGECLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMOGECLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMOGECLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMOGECLSE.Location = New System.Drawing.Point(111, 93)
        Me.cboMOGECLSE.MaxDropDownItems = 15
        Me.cboMOGECLSE.MaxLength = 1
        Me.cboMOGECLSE.Name = "cboMOGECLSE"
        Me.cboMOGECLSE.Size = New System.Drawing.Size(173, 22)
        Me.cboMOGECLSE.TabIndex = 6
        '
        'lblMOGEVIGE
        '
        Me.lblMOGEVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblMOGEVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMOGEVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMOGEVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblMOGEVIGE.Location = New System.Drawing.Point(287, 118)
        Me.lblMOGEVIGE.Name = "lblMOGEVIGE"
        Me.lblMOGEVIGE.Size = New System.Drawing.Size(260, 20)
        Me.lblMOGEVIGE.TabIndex = 51
        '
        'lblMOGECLSE
        '
        Me.lblMOGECLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblMOGECLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMOGECLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMOGECLSE.ForeColor = System.Drawing.Color.Black
        Me.lblMOGECLSE.Location = New System.Drawing.Point(287, 95)
        Me.lblMOGECLSE.Name = "lblMOGECLSE"
        Me.lblMOGECLSE.Size = New System.Drawing.Size(260, 20)
        Me.lblMOGECLSE.TabIndex = 47
        '
        'lblClaseOSector2
        '
        Me.lblClaseOSector2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseOSector2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseOSector2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseOSector2.ForeColor = System.Drawing.Color.Black
        Me.lblClaseOSector2.Location = New System.Drawing.Point(20, 95)
        Me.lblClaseOSector2.Name = "lblClaseOSector2"
        Me.lblClaseOSector2.Size = New System.Drawing.Size(88, 20)
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
        Me.lblCategoriaDeSuelo.Size = New System.Drawing.Size(88, 20)
        Me.lblCategoriaDeSuelo.TabIndex = 44
        Me.lblCategoriaDeSuelo.Text = "Vigencia"
        '
        'txtMOGEPRED
        '
        Me.txtMOGEPRED.AccessibleDescription = "Predio "
        Me.txtMOGEPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOGEPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOGEPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOGEPRED.ForeColor = System.Drawing.Color.Black
        Me.txtMOGEPRED.Location = New System.Drawing.Point(463, 72)
        Me.txtMOGEPRED.MaxLength = 5
        Me.txtMOGEPRED.Name = "txtMOGEPRED"
        Me.txtMOGEPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtMOGEPRED.TabIndex = 5
        '
        'txtMOGEMANZ
        '
        Me.txtMOGEMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtMOGEMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOGEMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOGEMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOGEMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtMOGEMANZ.Location = New System.Drawing.Point(375, 72)
        Me.txtMOGEMANZ.MaxLength = 3
        Me.txtMOGEMANZ.Name = "txtMOGEMANZ"
        Me.txtMOGEMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtMOGEMANZ.TabIndex = 4
        '
        'txtMOGEBARR
        '
        Me.txtMOGEBARR.AccessibleDescription = "Barrio "
        Me.txtMOGEBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOGEBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOGEBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOGEBARR.ForeColor = System.Drawing.Color.Black
        Me.txtMOGEBARR.Location = New System.Drawing.Point(287, 72)
        Me.txtMOGEBARR.MaxLength = 3
        Me.txtMOGEBARR.Name = "txtMOGEBARR"
        Me.txtMOGEBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtMOGEBARR.TabIndex = 3
        '
        'lblCodigoActual
        '
        Me.lblCodigoActual.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigoActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigoActual.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoActual.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoActual.Location = New System.Drawing.Point(20, 72)
        Me.lblCodigoActual.Name = "lblCodigoActual"
        Me.lblCodigoActual.Size = New System.Drawing.Size(88, 20)
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
        Me.lblCodigo.Size = New System.Drawing.Size(88, 20)
        Me.lblCodigo.TabIndex = 300
        Me.lblCodigo.Text = "CODIGO"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 441)
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
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 499)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(596, 25)
        Me.strBARRESTA.TabIndex = 338
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
        'frm_insertar_MOVIGEOG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 524)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.fraFICHPRED)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(612, 560)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(612, 560)
        Me.Name = "frm_insertar_MOVIGEOG"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox2.ResumeLayout(False)
        Me.fraFICHPRED.ResumeLayout(False)
        Me.fraFICHPRED.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMOGESECU As System.Windows.Forms.Label
    Friend WithEvents fraFICHPRED As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMOGEOBSE As System.Windows.Forms.TextBox
    Friend WithEvents cboMOGECAAC As System.Windows.Forms.ComboBox
    Friend WithEvents lblMOGECAAC As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cboMOGEESTA As System.Windows.Forms.ComboBox
    Friend WithEvents txtMOGECORR As System.Windows.Forms.TextBox
    Friend WithEvents txtMOGEMUNI As System.Windows.Forms.TextBox
    Friend WithEvents cboMOGEVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents cboMOGECLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblMOGEVIGE As System.Windows.Forms.Label
    Friend WithEvents lblMOGECLSE As System.Windows.Forms.Label
    Friend WithEvents lblClaseOSector2 As System.Windows.Forms.Label
    Friend WithEvents lblCategoriaDeSuelo As System.Windows.Forms.Label
    Friend WithEvents txtMOGEPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtMOGEMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtMOGEBARR As System.Windows.Forms.TextBox
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
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cboMOGECLVE As System.Windows.Forms.ComboBox
    Friend WithEvents lblMOGECLVE As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboMOGENUDO As System.Windows.Forms.ComboBox
    Friend WithEvents lblMOGENUDO As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
