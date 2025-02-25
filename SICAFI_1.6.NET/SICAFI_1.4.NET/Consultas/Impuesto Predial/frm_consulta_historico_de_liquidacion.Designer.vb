<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_historico_de_liquidacion
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvCONSULTA = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.fraPROPIETARIO = New System.Windows.Forms.GroupBox()
        Me.cboHILITIPO = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkHILIAUAV = New System.Windows.Forms.CheckBox()
        Me.chkHILILE56 = New System.Windows.Forms.CheckBox()
        Me.chkHILILE44 = New System.Windows.Forms.CheckBox()
        Me.chkHILILOCE = New System.Windows.Forms.CheckBox()
        Me.chkHILILOTE = New System.Windows.Forms.CheckBox()
        Me.cboHILIESTR = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboHILIDEEC = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboHILIESTA = New System.Windows.Forms.ComboBox()
        Me.cboHILIVIGE = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtHILIPUCA = New System.Windows.Forms.TextBox()
        Me.txtHILIARTE = New System.Windows.Forms.TextBox()
        Me.txtHILIARCO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHILIAVCA = New System.Windows.Forms.TextBox()
        Me.txtHILIAVPR = New System.Windows.Forms.TextBox()
        Me.lblDocumento = New System.Windows.Forms.Label()
        Me.lblPrimerApellido = New System.Windows.Forms.Label()
        Me.lblCapr1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdExportarExcel = New System.Windows.Forms.Button()
        Me.cmdULTIMACONSULTA = New System.Windows.Forms.Button()
        Me.cmdLIMPIAR = New System.Windows.Forms.Button()
        Me.txtSEPARADOR = New System.Windows.Forms.TextBox()
        Me.cmdCONSULTAR = New System.Windows.Forms.Button()
        Me.cmdExportarPlano = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.fraFICHPRED = New System.Windows.Forms.GroupBox()
        Me.cboFIPRESTA = New System.Windows.Forms.ComboBox()
        Me.cboFIPRMOAD = New System.Windows.Forms.ComboBox()
        Me.cboFIPRCASU = New System.Windows.Forms.ComboBox()
        Me.cboFIPRCAPR = New System.Windows.Forms.ComboBox()
        Me.cboFIPRCLSE = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFIPRNUFI = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.lblAdquisicionDelPredio = New System.Windows.Forms.Label()
        Me.txtFIPRCORR = New System.Windows.Forms.TextBox()
        Me.txtFIPRMUNI = New System.Windows.Forms.TextBox()
        Me.lblClaseOSector2 = New System.Windows.Forms.Label()
        Me.lblCategoriaDeSuelo = New System.Windows.Forms.Label()
        Me.txtFIPRUNPR = New System.Windows.Forms.TextBox()
        Me.txtFIPREDIF = New System.Windows.Forms.TextBox()
        Me.txtFIPRPRED = New System.Windows.Forms.TextBox()
        Me.txtFIPRMANZ = New System.Windows.Forms.TextBox()
        Me.txtFIPRBARR = New System.Windows.Forms.TextBox()
        Me.lblCodigoActual = New System.Windows.Forms.Label()
        Me.lblUnidadPredial = New System.Windows.Forms.Label()
        Me.lblEdificio = New System.Windows.Forms.Label()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.lblManzana = New System.Windows.Forms.Label()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtFIPRDIRE = New System.Windows.Forms.TextBox()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.fraPROPIETARIO.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.fraFICHPRED.SuspendLayout()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 586)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(904, 25)
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
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.dgvCONSULTA)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(12, 428)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(877, 148)
        Me.GroupBox2.TabIndex = 43
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CONSULTA"
        '
        'dgvCONSULTA
        '
        Me.dgvCONSULTA.AccessibleDescription = "Consulta "
        Me.dgvCONSULTA.AllowUserToAddRows = False
        Me.dgvCONSULTA.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCONSULTA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCONSULTA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCONSULTA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCONSULTA.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCONSULTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCONSULTA.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCONSULTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCONSULTA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA.Location = New System.Drawing.Point(18, 20)
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        Me.dgvCONSULTA.RowHeadersVisible = False
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(842, 108)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.fraPROPIETARIO)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.fraFICHPRED)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(877, 411)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CONSULTAR HISTORICOS DE SUJETO DE IMPUESTO"
        '
        'fraPROPIETARIO
        '
        Me.fraPROPIETARIO.Controls.Add(Me.cboHILITIPO)
        Me.fraPROPIETARIO.Controls.Add(Me.Label4)
        Me.fraPROPIETARIO.Controls.Add(Me.chkHILIAUAV)
        Me.fraPROPIETARIO.Controls.Add(Me.chkHILILE56)
        Me.fraPROPIETARIO.Controls.Add(Me.chkHILILE44)
        Me.fraPROPIETARIO.Controls.Add(Me.chkHILILOCE)
        Me.fraPROPIETARIO.Controls.Add(Me.chkHILILOTE)
        Me.fraPROPIETARIO.Controls.Add(Me.cboHILIESTR)
        Me.fraPROPIETARIO.Controls.Add(Me.Label11)
        Me.fraPROPIETARIO.Controls.Add(Me.cboHILIDEEC)
        Me.fraPROPIETARIO.Controls.Add(Me.Label10)
        Me.fraPROPIETARIO.Controls.Add(Me.cboHILIESTA)
        Me.fraPROPIETARIO.Controls.Add(Me.cboHILIVIGE)
        Me.fraPROPIETARIO.Controls.Add(Me.Label8)
        Me.fraPROPIETARIO.Controls.Add(Me.txtHILIPUCA)
        Me.fraPROPIETARIO.Controls.Add(Me.txtHILIARTE)
        Me.fraPROPIETARIO.Controls.Add(Me.txtHILIARCO)
        Me.fraPROPIETARIO.Controls.Add(Me.Label3)
        Me.fraPROPIETARIO.Controls.Add(Me.Label5)
        Me.fraPROPIETARIO.Controls.Add(Me.Label6)
        Me.fraPROPIETARIO.Controls.Add(Me.txtHILIAVCA)
        Me.fraPROPIETARIO.Controls.Add(Me.txtHILIAVPR)
        Me.fraPROPIETARIO.Controls.Add(Me.lblDocumento)
        Me.fraPROPIETARIO.Controls.Add(Me.lblPrimerApellido)
        Me.fraPROPIETARIO.Controls.Add(Me.lblCapr1)
        Me.fraPROPIETARIO.ForeColor = System.Drawing.Color.Black
        Me.fraPROPIETARIO.Location = New System.Drawing.Point(15, 196)
        Me.fraPROPIETARIO.Name = "fraPROPIETARIO"
        Me.fraPROPIETARIO.Size = New System.Drawing.Size(845, 148)
        Me.fraPROPIETARIO.TabIndex = 3
        Me.fraPROPIETARIO.TabStop = False
        Me.fraPROPIETARIO.Text = "HISTORICO DE LIQUIDACIÓN"
        '
        'cboHILITIPO
        '
        Me.cboHILITIPO.AccessibleDescription = "Tipo de calificación"
        Me.cboHILITIPO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboHILITIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHILITIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHILITIPO.FormattingEnabled = True
        Me.cboHILITIPO.Location = New System.Drawing.Point(17, 96)
        Me.cboHILITIPO.Name = "cboHILITIPO"
        Me.cboHILITIPO.Size = New System.Drawing.Size(179, 22)
        Me.cboHILITIPO.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(17, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(178, 20)
        Me.Label4.TabIndex = 397
        Me.Label4.Text = "Tipo de calificación"
        '
        'chkHILIAUAV
        '
        Me.chkHILIAUAV.AccessibleDescription = "Autoavaluo"
        Me.chkHILIAUAV.AutoSize = True
        Me.chkHILIAUAV.Checked = True
        Me.chkHILIAUAV.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.chkHILIAUAV.Location = New System.Drawing.Point(388, 125)
        Me.chkHILIAUAV.Name = "chkHILIAUAV"
        Me.chkHILIAUAV.Size = New System.Drawing.Size(80, 17)
        Me.chkHILIAUAV.TabIndex = 15
        Me.chkHILIAUAV.Text = "Autoavalúo"
        Me.chkHILIAUAV.ThreeState = True
        Me.chkHILIAUAV.UseVisualStyleBackColor = True
        '
        'chkHILILE56
        '
        Me.chkHILILE56.AccessibleDescription = "Ley 56"
        Me.chkHILILE56.AutoSize = True
        Me.chkHILILE56.Checked = True
        Me.chkHILILE56.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.chkHILILE56.Location = New System.Drawing.Point(309, 125)
        Me.chkHILILE56.Name = "chkHILILE56"
        Me.chkHILILE56.Size = New System.Drawing.Size(58, 17)
        Me.chkHILILE56.TabIndex = 14
        Me.chkHILILE56.Text = "Ley 56"
        Me.chkHILILE56.ThreeState = True
        Me.chkHILILE56.UseVisualStyleBackColor = True
        '
        'chkHILILE44
        '
        Me.chkHILILE44.AccessibleDescription = "Ley 44"
        Me.chkHILILE44.AutoSize = True
        Me.chkHILILE44.Checked = True
        Me.chkHILILE44.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.chkHILILE44.Location = New System.Drawing.Point(216, 125)
        Me.chkHILILE44.Name = "chkHILILE44"
        Me.chkHILILE44.Size = New System.Drawing.Size(58, 17)
        Me.chkHILILE44.TabIndex = 13
        Me.chkHILILE44.Text = "Ley 44"
        Me.chkHILILE44.ThreeState = True
        Me.chkHILILE44.UseVisualStyleBackColor = True
        '
        'chkHILILOCE
        '
        Me.chkHILILOCE.AccessibleDescription = "Lote cercado"
        Me.chkHILILOCE.AutoSize = True
        Me.chkHILILOCE.Checked = True
        Me.chkHILILOCE.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.chkHILILOCE.Location = New System.Drawing.Point(104, 125)
        Me.chkHILILOCE.Name = "chkHILILOCE"
        Me.chkHILILOCE.Size = New System.Drawing.Size(89, 17)
        Me.chkHILILOCE.TabIndex = 12
        Me.chkHILILOCE.Text = "Lote cercado"
        Me.chkHILILOCE.ThreeState = True
        Me.chkHILILOCE.UseVisualStyleBackColor = True
        '
        'chkHILILOTE
        '
        Me.chkHILILOTE.AccessibleDescription = "Lote"
        Me.chkHILILOTE.AutoSize = True
        Me.chkHILILOTE.Checked = True
        Me.chkHILILOTE.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.chkHILILOTE.Location = New System.Drawing.Point(17, 125)
        Me.chkHILILOTE.Name = "chkHILILOTE"
        Me.chkHILILOTE.Size = New System.Drawing.Size(47, 17)
        Me.chkHILILOTE.TabIndex = 11
        Me.chkHILILOTE.Text = "Lote"
        Me.chkHILILOTE.ThreeState = True
        Me.chkHILILOTE.UseVisualStyleBackColor = True
        '
        'cboHILIESTR
        '
        Me.cboHILIESTR.AccessibleDescription = "Estrato"
        Me.cboHILIESTR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboHILIESTR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHILIESTR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHILIESTR.FormattingEnabled = True
        Me.cboHILIESTR.Location = New System.Drawing.Point(639, 48)
        Me.cboHILIESTR.Name = "cboHILIESTR"
        Me.cboHILIESTR.Size = New System.Drawing.Size(179, 22)
        Me.cboHILIESTR.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(639, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(178, 20)
        Me.Label11.TabIndex = 390
        Me.Label11.Text = "Estrato socioeconómico"
        '
        'cboHILIDEEC
        '
        Me.cboHILIDEEC.AccessibleDescription = "Destinación económica"
        Me.cboHILIDEEC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboHILIDEEC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHILIDEEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHILIDEEC.FormattingEnabled = True
        Me.cboHILIDEEC.Location = New System.Drawing.Point(463, 48)
        Me.cboHILIDEEC.Name = "cboHILIDEEC"
        Me.cboHILIDEEC.Size = New System.Drawing.Size(173, 22)
        Me.cboHILIDEEC.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(463, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(172, 20)
        Me.Label10.TabIndex = 388
        Me.Label10.Text = "Destinación económica"
        '
        'cboHILIESTA
        '
        Me.cboHILIESTA.AccessibleDescription = "Estado"
        Me.cboHILIESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboHILIESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHILIESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHILIESTA.FormattingEnabled = True
        Me.cboHILIESTA.Location = New System.Drawing.Point(727, 96)
        Me.cboHILIESTA.Name = "cboHILIESTA"
        Me.cboHILIESTA.Size = New System.Drawing.Size(91, 22)
        Me.cboHILIESTA.TabIndex = 10
        '
        'cboHILIVIGE
        '
        Me.cboHILIVIGE.AccessibleDescription = "Vigencia"
        Me.cboHILIVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboHILIVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHILIVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHILIVIGE.FormattingEnabled = True
        Me.cboHILIVIGE.Location = New System.Drawing.Point(17, 48)
        Me.cboHILIVIGE.Name = "cboHILIVIGE"
        Me.cboHILIVIGE.Size = New System.Drawing.Size(178, 22)
        Me.cboHILIVIGE.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(727, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 20)
        Me.Label8.TabIndex = 386
        Me.Label8.Text = "Estado"
        '
        'txtHILIPUCA
        '
        Me.txtHILIPUCA.AccessibleDescription = "Valor const. privada"
        Me.txtHILIPUCA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHILIPUCA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHILIPUCA.Location = New System.Drawing.Point(551, 96)
        Me.txtHILIPUCA.MaxLength = 9
        Me.txtHILIPUCA.Name = "txtHILIPUCA"
        Me.txtHILIPUCA.Size = New System.Drawing.Size(172, 20)
        Me.txtHILIPUCA.TabIndex = 9
        '
        'txtHILIARTE
        '
        Me.txtHILIARTE.AccessibleDescription = "Valor lote comun"
        Me.txtHILIARTE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHILIARTE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHILIARTE.Location = New System.Drawing.Point(375, 96)
        Me.txtHILIARTE.MaxLength = 9
        Me.txtHILIARTE.Name = "txtHILIARTE"
        Me.txtHILIARTE.Size = New System.Drawing.Size(173, 20)
        Me.txtHILIARTE.TabIndex = 8
        '
        'txtHILIARCO
        '
        Me.txtHILIARCO.AccessibleDescription = "Valor lote privado"
        Me.txtHILIARCO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHILIARCO.Location = New System.Drawing.Point(199, 96)
        Me.txtHILIARCO.MaxLength = 9
        Me.txtHILIARCO.Name = "txtHILIARCO"
        Me.txtHILIARCO.Size = New System.Drawing.Size(173, 20)
        Me.txtHILIARCO.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(199, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(173, 20)
        Me.Label3.TabIndex = 382
        Me.Label3.Text = "Area construida"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(551, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(172, 20)
        Me.Label5.TabIndex = 380
        Me.Label5.Text = "Puntos de calificación"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(375, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(173, 20)
        Me.Label6.TabIndex = 379
        Me.Label6.Text = "Area de terreno"
        '
        'txtHILIAVCA
        '
        Me.txtHILIAVCA.AccessibleDescription = "Avalúo catastral"
        Me.txtHILIAVCA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHILIAVCA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHILIAVCA.Location = New System.Drawing.Point(329, 48)
        Me.txtHILIAVCA.MaxLength = 15
        Me.txtHILIAVCA.Name = "txtHILIAVCA"
        Me.txtHILIAVCA.Size = New System.Drawing.Size(130, 20)
        Me.txtHILIAVCA.TabIndex = 3
        '
        'txtHILIAVPR
        '
        Me.txtHILIAVPR.AccessibleDescription = "Avalúo predial"
        Me.txtHILIAVPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHILIAVPR.Location = New System.Drawing.Point(199, 48)
        Me.txtHILIAVPR.MaxLength = 15
        Me.txtHILIAVPR.Name = "txtHILIAVPR"
        Me.txtHILIAVPR.Size = New System.Drawing.Size(126, 20)
        Me.txtHILIAVPR.TabIndex = 2
        '
        'lblDocumento
        '
        Me.lblDocumento.AccessibleDescription = "Área lote privado"
        Me.lblDocumento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDocumento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumento.ForeColor = System.Drawing.Color.Black
        Me.lblDocumento.Location = New System.Drawing.Point(199, 25)
        Me.lblDocumento.Name = "lblDocumento"
        Me.lblDocumento.Size = New System.Drawing.Size(126, 20)
        Me.lblDocumento.TabIndex = 374
        Me.lblDocumento.Text = "Avalúo predial"
        '
        'lblPrimerApellido
        '
        Me.lblPrimerApellido.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPrimerApellido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPrimerApellido.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrimerApellido.ForeColor = System.Drawing.Color.Black
        Me.lblPrimerApellido.Location = New System.Drawing.Point(329, 25)
        Me.lblPrimerApellido.Name = "lblPrimerApellido"
        Me.lblPrimerApellido.Size = New System.Drawing.Size(130, 20)
        Me.lblPrimerApellido.TabIndex = 370
        Me.lblPrimerApellido.Text = "Avalúo catastral"
        '
        'lblCapr1
        '
        Me.lblCapr1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCapr1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCapr1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapr1.ForeColor = System.Drawing.Color.Black
        Me.lblCapr1.Location = New System.Drawing.Point(17, 25)
        Me.lblCapr1.Name = "lblCapr1"
        Me.lblCapr1.Size = New System.Drawing.Size(177, 20)
        Me.lblCapr1.TabIndex = 369
        Me.lblCapr1.Text = "Vigencia "
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdExportarExcel)
        Me.GroupBox3.Controls.Add(Me.cmdULTIMACONSULTA)
        Me.GroupBox3.Controls.Add(Me.cmdLIMPIAR)
        Me.GroupBox3.Controls.Add(Me.txtSEPARADOR)
        Me.GroupBox3.Controls.Add(Me.cmdCONSULTAR)
        Me.GroupBox3.Controls.Add(Me.cmdExportarPlano)
        Me.GroupBox3.Controls.Add(Me.cmdSALIR)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(15, 350)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(845, 47)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'cmdExportarExcel
        '
        Me.cmdExportarExcel.AccessibleDescription = "Exportar Excel"
        Me.cmdExportarExcel.AccessibleName = ""
        Me.cmdExportarExcel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExportarExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExportarExcel.Image = Global.SICAFI.My.Resources.Resources._041
        Me.cmdExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdExportarExcel.Location = New System.Drawing.Point(535, 15)
        Me.cmdExportarExcel.Name = "cmdExportarExcel"
        Me.cmdExportarExcel.Size = New System.Drawing.Size(123, 23)
        Me.cmdExportarExcel.TabIndex = 38
        Me.cmdExportarExcel.Text = "&Exportar excel"
        Me.cmdExportarExcel.UseVisualStyleBackColor = False
        '
        'cmdULTIMACONSULTA
        '
        Me.cmdULTIMACONSULTA.AccessibleDescription = "Ultima consulta"
        Me.cmdULTIMACONSULTA.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdULTIMACONSULTA.Image = Global.SICAFI.My.Resources.Resources._667
        Me.cmdULTIMACONSULTA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdULTIMACONSULTA.Location = New System.Drawing.Point(148, 15)
        Me.cmdULTIMACONSULTA.Name = "cmdULTIMACONSULTA"
        Me.cmdULTIMACONSULTA.Size = New System.Drawing.Size(123, 23)
        Me.cmdULTIMACONSULTA.TabIndex = 35
        Me.cmdULTIMACONSULTA.Text = "&Ultima consulta"
        Me.cmdULTIMACONSULTA.UseVisualStyleBackColor = True
        '
        'cmdLIMPIAR
        '
        Me.cmdLIMPIAR.AccessibleDescription = "Limpiar campo"
        Me.cmdLIMPIAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLIMPIAR.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLIMPIAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLIMPIAR.Location = New System.Drawing.Point(277, 15)
        Me.cmdLIMPIAR.Name = "cmdLIMPIAR"
        Me.cmdLIMPIAR.Size = New System.Drawing.Size(123, 23)
        Me.cmdLIMPIAR.TabIndex = 36
        Me.cmdLIMPIAR.Text = "&Limpiar campos"
        Me.cmdLIMPIAR.UseVisualStyleBackColor = True
        '
        'txtSEPARADOR
        '
        Me.txtSEPARADOR.Location = New System.Drawing.Point(664, 17)
        Me.txtSEPARADOR.Name = "txtSEPARADOR"
        Me.txtSEPARADOR.Size = New System.Drawing.Size(34, 20)
        Me.txtSEPARADOR.TabIndex = 39
        Me.txtSEPARADOR.Text = "|"
        Me.txtSEPARADOR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdCONSULTAR
        '
        Me.cmdCONSULTAR.AccessibleDescription = "Consultar"
        Me.cmdCONSULTAR.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdCONSULTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCONSULTAR.Location = New System.Drawing.Point(19, 15)
        Me.cmdCONSULTAR.Name = "cmdCONSULTAR"
        Me.cmdCONSULTAR.Size = New System.Drawing.Size(123, 23)
        Me.cmdCONSULTAR.TabIndex = 34
        Me.cmdCONSULTAR.Text = "&Consultar"
        Me.cmdCONSULTAR.UseVisualStyleBackColor = True
        '
        'cmdExportarPlano
        '
        Me.cmdExportarPlano.AccessibleDescription = "Plano"
        Me.cmdExportarPlano.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExportarPlano.Image = Global.SICAFI.My.Resources.Resources._71
        Me.cmdExportarPlano.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExportarPlano.Location = New System.Drawing.Point(406, 15)
        Me.cmdExportarPlano.Name = "cmdExportarPlano"
        Me.cmdExportarPlano.Size = New System.Drawing.Size(123, 23)
        Me.cmdExportarPlano.TabIndex = 37
        Me.cmdExportarPlano.Text = "&Exportar plano"
        Me.cmdExportarPlano.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Cancelar"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(704, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(123, 23)
        Me.cmdSALIR.TabIndex = 40
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'fraFICHPRED
        '
        Me.fraFICHPRED.BackColor = System.Drawing.SystemColors.Control
        Me.fraFICHPRED.Controls.Add(Me.cboFIPRESTA)
        Me.fraFICHPRED.Controls.Add(Me.cboFIPRMOAD)
        Me.fraFICHPRED.Controls.Add(Me.cboFIPRCASU)
        Me.fraFICHPRED.Controls.Add(Me.cboFIPRCAPR)
        Me.fraFICHPRED.Controls.Add(Me.cboFIPRCLSE)
        Me.fraFICHPRED.Controls.Add(Me.Label2)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRNUFI)
        Me.fraFICHPRED.Controls.Add(Me.Label1)
        Me.fraFICHPRED.Controls.Add(Me.Label33)
        Me.fraFICHPRED.Controls.Add(Me.Label59)
        Me.fraFICHPRED.Controls.Add(Me.lblAdquisicionDelPredio)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRCORR)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRMUNI)
        Me.fraFICHPRED.Controls.Add(Me.lblClaseOSector2)
        Me.fraFICHPRED.Controls.Add(Me.lblCategoriaDeSuelo)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRUNPR)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPREDIF)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRPRED)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRMANZ)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRBARR)
        Me.fraFICHPRED.Controls.Add(Me.lblCodigoActual)
        Me.fraFICHPRED.Controls.Add(Me.lblUnidadPredial)
        Me.fraFICHPRED.Controls.Add(Me.lblEdificio)
        Me.fraFICHPRED.Controls.Add(Me.lblPredio)
        Me.fraFICHPRED.Controls.Add(Me.lblManzana)
        Me.fraFICHPRED.Controls.Add(Me.lblBarrio)
        Me.fraFICHPRED.Controls.Add(Me.lblCorregimiento)
        Me.fraFICHPRED.Controls.Add(Me.lblMunicipio)
        Me.fraFICHPRED.Controls.Add(Me.lblCodigo)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRDIRE)
        Me.fraFICHPRED.Controls.Add(Me.lblDireccion)
        Me.fraFICHPRED.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraFICHPRED.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraFICHPRED.Location = New System.Drawing.Point(15, 19)
        Me.fraFICHPRED.Name = "fraFICHPRED"
        Me.fraFICHPRED.Size = New System.Drawing.Size(845, 171)
        Me.fraFICHPRED.TabIndex = 2
        Me.fraFICHPRED.TabStop = False
        Me.fraFICHPRED.Text = "SUJETO DE IMPUESTO"
        '
        'cboFIPRESTA
        '
        Me.cboFIPRESTA.AccessibleDescription = "Estado"
        Me.cboFIPRESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFIPRESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFIPRESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFIPRESTA.FormattingEnabled = True
        Me.cboFIPRESTA.Location = New System.Drawing.Point(727, 88)
        Me.cboFIPRESTA.Name = "cboFIPRESTA"
        Me.cboFIPRESTA.Size = New System.Drawing.Size(91, 22)
        Me.cboFIPRESTA.TabIndex = 10
        '
        'cboFIPRMOAD
        '
        Me.cboFIPRMOAD.AccessibleDescription = "Modo de adquisición"
        Me.cboFIPRMOAD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFIPRMOAD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFIPRMOAD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFIPRMOAD.FormattingEnabled = True
        Me.cboFIPRMOAD.Location = New System.Drawing.Point(551, 135)
        Me.cboFIPRMOAD.Name = "cboFIPRMOAD"
        Me.cboFIPRMOAD.Size = New System.Drawing.Size(267, 22)
        Me.cboFIPRMOAD.TabIndex = 14
        '
        'cboFIPRCASU
        '
        Me.cboFIPRCASU.AccessibleDescription = "Categoria de suelo"
        Me.cboFIPRCASU.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFIPRCASU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFIPRCASU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFIPRCASU.FormattingEnabled = True
        Me.cboFIPRCASU.Location = New System.Drawing.Point(551, 112)
        Me.cboFIPRCASU.Name = "cboFIPRCASU"
        Me.cboFIPRCASU.Size = New System.Drawing.Size(267, 22)
        Me.cboFIPRCASU.TabIndex = 12
        '
        'cboFIPRCAPR
        '
        Me.cboFIPRCAPR.AccessibleDescription = "Caracteristica de predio"
        Me.cboFIPRCAPR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFIPRCAPR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFIPRCAPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFIPRCAPR.FormattingEnabled = True
        Me.cboFIPRCAPR.Location = New System.Drawing.Point(110, 135)
        Me.cboFIPRCAPR.Name = "cboFIPRCAPR"
        Me.cboFIPRCAPR.Size = New System.Drawing.Size(261, 22)
        Me.cboFIPRCAPR.TabIndex = 13
        '
        'cboFIPRCLSE
        '
        Me.cboFIPRCLSE.AccessibleDescription = "Clase o sector"
        Me.cboFIPRCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFIPRCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFIPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFIPRCLSE.FormattingEnabled = True
        Me.cboFIPRCLSE.Location = New System.Drawing.Point(110, 112)
        Me.cboFIPRCLSE.Name = "cboFIPRCLSE"
        Me.cboFIPRCLSE.Size = New System.Drawing.Size(261, 22)
        Me.cboFIPRCLSE.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(727, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 20)
        Me.Label2.TabIndex = 308
        Me.Label2.Text = "Estado"
        '
        'txtFIPRNUFI
        '
        Me.txtFIPRNUFI.AccessibleDescription = "Nro. Ficha predial"
        Me.txtFIPRNUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRNUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRNUFI.Location = New System.Drawing.Point(111, 19)
        Me.txtFIPRNUFI.MaxLength = 8
        Me.txtFIPRNUFI.Name = "txtFIPRNUFI"
        Me.txtFIPRNUFI.Size = New System.Drawing.Size(173, 20)
        Me.txtFIPRNUFI.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(20, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 20)
        Me.Label1.TabIndex = 288
        Me.Label1.Text = "Nro. FICHA"
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(20, 42)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(798, 20)
        Me.Label33.TabIndex = 278
        Me.Label33.Text = "CEDULA CATASTRAL ACTUAL"
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label59.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label59.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.ForeColor = System.Drawing.Color.Black
        Me.Label59.Location = New System.Drawing.Point(20, 135)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(85, 20)
        Me.Label59.TabIndex = 276
        Me.Label59.Text = "Caract. Predio"
        '
        'lblAdquisicionDelPredio
        '
        Me.lblAdquisicionDelPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblAdquisicionDelPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAdquisicionDelPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdquisicionDelPredio.ForeColor = System.Drawing.Color.Black
        Me.lblAdquisicionDelPredio.Location = New System.Drawing.Point(375, 135)
        Me.lblAdquisicionDelPredio.Name = "lblAdquisicionDelPredio"
        Me.lblAdquisicionDelPredio.Size = New System.Drawing.Size(172, 20)
        Me.lblAdquisicionDelPredio.TabIndex = 273
        Me.lblAdquisicionDelPredio.Text = "Modo de adquisición"
        '
        'txtFIPRCORR
        '
        Me.txtFIPRCORR.AccessibleDescription = "Corregimiento"
        Me.txtFIPRCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRCORR.Location = New System.Drawing.Point(199, 88)
        Me.txtFIPRCORR.MaxLength = 10
        Me.txtFIPRCORR.Name = "txtFIPRCORR"
        Me.txtFIPRCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRCORR.TabIndex = 4
        '
        'txtFIPRMUNI
        '
        Me.txtFIPRMUNI.AccessibleDescription = "Municipio"
        Me.txtFIPRMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMUNI.Location = New System.Drawing.Point(111, 88)
        Me.txtFIPRMUNI.MaxLength = 10
        Me.txtFIPRMUNI.Name = "txtFIPRMUNI"
        Me.txtFIPRMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRMUNI.TabIndex = 3
        '
        'lblClaseOSector2
        '
        Me.lblClaseOSector2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseOSector2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseOSector2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseOSector2.ForeColor = System.Drawing.Color.Black
        Me.lblClaseOSector2.Location = New System.Drawing.Point(20, 112)
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
        Me.lblCategoriaDeSuelo.Location = New System.Drawing.Point(375, 112)
        Me.lblCategoriaDeSuelo.Name = "lblCategoriaDeSuelo"
        Me.lblCategoriaDeSuelo.Size = New System.Drawing.Size(172, 20)
        Me.lblCategoriaDeSuelo.TabIndex = 44
        Me.lblCategoriaDeSuelo.Text = "Categoria de Suelo"
        '
        'txtFIPRUNPR
        '
        Me.txtFIPRUNPR.AccessibleDescription = "Unidad predial "
        Me.txtFIPRUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRUNPR.Location = New System.Drawing.Point(639, 88)
        Me.txtFIPRUNPR.MaxLength = 10
        Me.txtFIPRUNPR.Name = "txtFIPRUNPR"
        Me.txtFIPRUNPR.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRUNPR.TabIndex = 9
        '
        'txtFIPREDIF
        '
        Me.txtFIPREDIF.AccessibleDescription = "Edificio "
        Me.txtFIPREDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPREDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPREDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPREDIF.ForeColor = System.Drawing.Color.Black
        Me.txtFIPREDIF.Location = New System.Drawing.Point(551, 88)
        Me.txtFIPREDIF.MaxLength = 10
        Me.txtFIPREDIF.Name = "txtFIPREDIF"
        Me.txtFIPREDIF.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPREDIF.TabIndex = 8
        '
        'txtFIPRPRED
        '
        Me.txtFIPRPRED.AccessibleDescription = "Predio "
        Me.txtFIPRPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRPRED.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRPRED.Location = New System.Drawing.Point(463, 88)
        Me.txtFIPRPRED.MaxLength = 10
        Me.txtFIPRPRED.Name = "txtFIPRPRED"
        Me.txtFIPRPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRPRED.TabIndex = 7
        '
        'txtFIPRMANZ
        '
        Me.txtFIPRMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtFIPRMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRMANZ.Location = New System.Drawing.Point(375, 88)
        Me.txtFIPRMANZ.MaxLength = 10
        Me.txtFIPRMANZ.Name = "txtFIPRMANZ"
        Me.txtFIPRMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRMANZ.TabIndex = 6
        '
        'txtFIPRBARR
        '
        Me.txtFIPRBARR.AccessibleDescription = "Barrio "
        Me.txtFIPRBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRBARR.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRBARR.Location = New System.Drawing.Point(287, 88)
        Me.txtFIPRBARR.MaxLength = 10
        Me.txtFIPRBARR.Name = "txtFIPRBARR"
        Me.txtFIPRBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRBARR.TabIndex = 5
        '
        'lblCodigoActual
        '
        Me.lblCodigoActual.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigoActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigoActual.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoActual.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoActual.Location = New System.Drawing.Point(20, 88)
        Me.lblCodigoActual.Name = "lblCodigoActual"
        Me.lblCodigoActual.Size = New System.Drawing.Size(85, 20)
        Me.lblCodigoActual.TabIndex = 27
        Me.lblCodigoActual.Text = "Código Actual"
        '
        'lblUnidadPredial
        '
        Me.lblUnidadPredial.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblUnidadPredial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUnidadPredial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidadPredial.ForeColor = System.Drawing.Color.Black
        Me.lblUnidadPredial.Location = New System.Drawing.Point(639, 65)
        Me.lblUnidadPredial.Name = "lblUnidadPredial"
        Me.lblUnidadPredial.Size = New System.Drawing.Size(84, 20)
        Me.lblUnidadPredial.TabIndex = 26
        Me.lblUnidadPredial.Text = "Unidad Predial"
        '
        'lblEdificio
        '
        Me.lblEdificio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblEdificio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEdificio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdificio.ForeColor = System.Drawing.Color.Black
        Me.lblEdificio.Location = New System.Drawing.Point(551, 65)
        Me.lblEdificio.Name = "lblEdificio"
        Me.lblEdificio.Size = New System.Drawing.Size(84, 20)
        Me.lblEdificio.TabIndex = 25
        Me.lblEdificio.Text = "Edificio"
        '
        'lblPredio
        '
        Me.lblPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredio.ForeColor = System.Drawing.Color.Black
        Me.lblPredio.Location = New System.Drawing.Point(463, 65)
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
        Me.lblManzana.Location = New System.Drawing.Point(375, 65)
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
        Me.lblBarrio.Location = New System.Drawing.Point(287, 65)
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
        Me.lblCorregimiento.Location = New System.Drawing.Point(199, 65)
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
        Me.lblMunicipio.Location = New System.Drawing.Point(111, 65)
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
        Me.lblCodigo.Location = New System.Drawing.Point(20, 65)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(85, 20)
        Me.lblCodigo.TabIndex = 300
        Me.lblCodigo.Text = "CODIGO"
        '
        'txtFIPRDIRE
        '
        Me.txtFIPRDIRE.AccessibleDescription = "Dirección "
        Me.txtFIPRDIRE.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRDIRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRDIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRDIRE.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRDIRE.Location = New System.Drawing.Point(375, 19)
        Me.txtFIPRDIRE.MaxLength = 49
        Me.txtFIPRDIRE.Name = "txtFIPRDIRE"
        Me.txtFIPRDIRE.Size = New System.Drawing.Size(444, 20)
        Me.txtFIPRDIRE.TabIndex = 2
        '
        'lblDireccion
        '
        Me.lblDireccion.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblDireccion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDireccion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccion.ForeColor = System.Drawing.Color.Black
        Me.lblDireccion.Location = New System.Drawing.Point(287, 20)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(84, 20)
        Me.lblDireccion.TabIndex = 99
        Me.lblDireccion.Text = "Dirección"
        '
        'frm_consulta_historico_de_liquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 611)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_consulta_historico_de_liquidacion"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CONSULTA HISTORICO DE LIQUIDACIÓN"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.fraPROPIETARIO.ResumeLayout(False)
        Me.fraPROPIETARIO.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.fraFICHPRED.ResumeLayout(False)
        Me.fraFICHPRED.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents fraPROPIETARIO As System.Windows.Forms.GroupBox
    Friend WithEvents cboHILIESTA As System.Windows.Forms.ComboBox
    Friend WithEvents cboHILIVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtHILIPUCA As System.Windows.Forms.TextBox
    Friend WithEvents txtHILIARTE As System.Windows.Forms.TextBox
    Friend WithEvents txtHILIARCO As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHILIAVCA As System.Windows.Forms.TextBox
    Friend WithEvents txtHILIAVPR As System.Windows.Forms.TextBox
    Friend WithEvents lblDocumento As System.Windows.Forms.Label
    Friend WithEvents lblPrimerApellido As System.Windows.Forms.Label
    Friend WithEvents lblCapr1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExportarExcel As System.Windows.Forms.Button
    Friend WithEvents cmdULTIMACONSULTA As System.Windows.Forms.Button
    Friend WithEvents cmdLIMPIAR As System.Windows.Forms.Button
    Friend WithEvents txtSEPARADOR As System.Windows.Forms.TextBox
    Friend WithEvents cmdCONSULTAR As System.Windows.Forms.Button
    Friend WithEvents cmdExportarPlano As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents fraFICHPRED As System.Windows.Forms.GroupBox
    Friend WithEvents cboFIPRESTA As System.Windows.Forms.ComboBox
    Friend WithEvents cboFIPRMOAD As System.Windows.Forms.ComboBox
    Friend WithEvents cboFIPRCASU As System.Windows.Forms.ComboBox
    Friend WithEvents cboFIPRCAPR As System.Windows.Forms.ComboBox
    Friend WithEvents cboFIPRCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFIPRNUFI As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents lblAdquisicionDelPredio As System.Windows.Forms.Label
    Friend WithEvents txtFIPRCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRMUNI As System.Windows.Forms.TextBox
    Friend WithEvents lblClaseOSector2 As System.Windows.Forms.Label
    Friend WithEvents lblCategoriaDeSuelo As System.Windows.Forms.Label
    Friend WithEvents txtFIPRUNPR As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPREDIF As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents lblUnidadPredial As System.Windows.Forms.Label
    Friend WithEvents lblEdificio As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtFIPRDIRE As System.Windows.Forms.TextBox
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents cboHILIDEEC As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboHILIESTR As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkHILIAUAV As System.Windows.Forms.CheckBox
    Friend WithEvents chkHILILE56 As System.Windows.Forms.CheckBox
    Friend WithEvents chkHILILE44 As System.Windows.Forms.CheckBox
    Friend WithEvents chkHILILOCE As System.Windows.Forms.CheckBox
    Friend WithEvents chkHILILOTE As System.Windows.Forms.CheckBox
    Friend WithEvents cboHILITIPO As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
