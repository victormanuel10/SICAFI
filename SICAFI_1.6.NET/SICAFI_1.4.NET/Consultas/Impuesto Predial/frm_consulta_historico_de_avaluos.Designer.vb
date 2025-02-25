<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_historico_de_avaluos
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
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtHIAVTOAV = New System.Windows.Forms.TextBox()
        Me.txtHIAVTVCC = New System.Windows.Forms.TextBox()
        Me.txtHIAVTVCP = New System.Windows.Forms.TextBox()
        Me.txtHIAVTVTC = New System.Windows.Forms.TextBox()
        Me.txtHIAVTVTP = New System.Windows.Forms.TextBox()
        Me.fraPROPIETARIO = New System.Windows.Forms.GroupBox()
        Me.cboHIAVESTA = New System.Windows.Forms.ComboBox()
        Me.cboHIAVVIGE = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtHIAVAVAL = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtHIAVVACC = New System.Windows.Forms.TextBox()
        Me.txtHIAVVACP = New System.Windows.Forms.TextBox()
        Me.txtHIAVVATC = New System.Windows.Forms.TextBox()
        Me.txtHIAVVATP = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHIAVACCO = New System.Windows.Forms.TextBox()
        Me.txtHIAVACPR = New System.Windows.Forms.TextBox()
        Me.txtHIAVATCO = New System.Windows.Forms.TextBox()
        Me.txtHIAVATPR = New System.Windows.Forms.TextBox()
        Me.lblDocumento = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblSegundoApellido = New System.Windows.Forms.Label()
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
        Me.cboSUIMESTA = New System.Windows.Forms.ComboBox()
        Me.cboSUIMMOAD = New System.Windows.Forms.ComboBox()
        Me.cboSUIMCAPR = New System.Windows.Forms.ComboBox()
        Me.cboSUIMCLSE = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSUIMNUFI = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.lblAdquisicionDelPredio = New System.Windows.Forms.Label()
        Me.txtSUIMCORR = New System.Windows.Forms.TextBox()
        Me.txtSUIMMUNI = New System.Windows.Forms.TextBox()
        Me.lblClaseOSector2 = New System.Windows.Forms.Label()
        Me.txtSUIMUNPR = New System.Windows.Forms.TextBox()
        Me.txtSUIMEDIF = New System.Windows.Forms.TextBox()
        Me.txtSUIMPRED = New System.Windows.Forms.TextBox()
        Me.txtSUIMMANZ = New System.Windows.Forms.TextBox()
        Me.txtSUIMBARR = New System.Windows.Forms.TextBox()
        Me.lblCodigoActual = New System.Windows.Forms.Label()
        Me.lblUnidadPredial = New System.Windows.Forms.Label()
        Me.lblEdificio = New System.Windows.Forms.Label()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.lblManzana = New System.Windows.Forms.Label()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtSUIMDIRE = New System.Windows.Forms.TextBox()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.fraPROPIETARIO.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.fraFICHPRED.SuspendLayout()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 660)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(904, 25)
        Me.strBARRESTA.TabIndex = 41
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
        Me.GroupBox2.Location = New System.Drawing.Point(12, 473)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(877, 172)
        Me.GroupBox2.TabIndex = 39
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
        Me.dgvCONSULTA.Size = New System.Drawing.Size(842, 134)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.fraPROPIETARIO)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.fraFICHPRED)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(877, 461)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CONSULTAR HISTORICOS DE SUJETO DE IMPUESTO"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txtHIAVTOAV)
        Me.GroupBox4.Controls.Add(Me.txtHIAVTVCC)
        Me.GroupBox4.Controls.Add(Me.txtHIAVTVCP)
        Me.GroupBox4.Controls.Add(Me.txtHIAVTVTC)
        Me.GroupBox4.Controls.Add(Me.txtHIAVTVTP)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(15, 335)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(845, 57)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "TOTALES"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(16, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(217, 20)
        Me.Label9.TabIndex = 390
        Me.Label9.Text = "Totales de avalúos"
        '
        'txtHIAVTOAV
        '
        Me.txtHIAVTOAV.AccessibleDescription = "Avalúo total"
        Me.txtHIAVTOAV.BackColor = System.Drawing.Color.White
        Me.txtHIAVTOAV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHIAVTOAV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHIAVTOAV.Location = New System.Drawing.Point(702, 19)
        Me.txtHIAVTOAV.MaxLength = 9
        Me.txtHIAVTOAV.Name = "txtHIAVTOAV"
        Me.txtHIAVTOAV.ReadOnly = True
        Me.txtHIAVTOAV.Size = New System.Drawing.Size(118, 20)
        Me.txtHIAVTOAV.TabIndex = 30
        '
        'txtHIAVTVCC
        '
        Me.txtHIAVTVCC.AccessibleDescription = "Valor const. comun"
        Me.txtHIAVTVCC.BackColor = System.Drawing.Color.White
        Me.txtHIAVTVCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHIAVTVCC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHIAVTVCC.Location = New System.Drawing.Point(583, 19)
        Me.txtHIAVTVCC.MaxLength = 9
        Me.txtHIAVTVCC.Name = "txtHIAVTVCC"
        Me.txtHIAVTVCC.ReadOnly = True
        Me.txtHIAVTVCC.Size = New System.Drawing.Size(117, 20)
        Me.txtHIAVTVCC.TabIndex = 29
        '
        'txtHIAVTVCP
        '
        Me.txtHIAVTVCP.AccessibleDescription = "Valor const. privada"
        Me.txtHIAVTVCP.BackColor = System.Drawing.Color.White
        Me.txtHIAVTVCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHIAVTVCP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHIAVTVCP.Location = New System.Drawing.Point(466, 19)
        Me.txtHIAVTVCP.MaxLength = 9
        Me.txtHIAVTVCP.Name = "txtHIAVTVCP"
        Me.txtHIAVTVCP.ReadOnly = True
        Me.txtHIAVTVCP.Size = New System.Drawing.Size(114, 20)
        Me.txtHIAVTVCP.TabIndex = 28
        '
        'txtHIAVTVTC
        '
        Me.txtHIAVTVTC.AccessibleDescription = "Valor lote comun"
        Me.txtHIAVTVTC.BackColor = System.Drawing.Color.White
        Me.txtHIAVTVTC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHIAVTVTC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHIAVTVTC.Location = New System.Drawing.Point(351, 19)
        Me.txtHIAVTVTC.MaxLength = 9
        Me.txtHIAVTVTC.Name = "txtHIAVTVTC"
        Me.txtHIAVTVTC.ReadOnly = True
        Me.txtHIAVTVTC.Size = New System.Drawing.Size(112, 20)
        Me.txtHIAVTVTC.TabIndex = 27
        '
        'txtHIAVTVTP
        '
        Me.txtHIAVTVTP.AccessibleDescription = "Valor lote privado"
        Me.txtHIAVTVTP.BackColor = System.Drawing.Color.White
        Me.txtHIAVTVTP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHIAVTVTP.Location = New System.Drawing.Point(236, 19)
        Me.txtHIAVTVTP.MaxLength = 9
        Me.txtHIAVTVTP.Name = "txtHIAVTVTP"
        Me.txtHIAVTVTP.ReadOnly = True
        Me.txtHIAVTVTP.Size = New System.Drawing.Size(112, 20)
        Me.txtHIAVTVTP.TabIndex = 26
        '
        'fraPROPIETARIO
        '
        Me.fraPROPIETARIO.Controls.Add(Me.cboHIAVESTA)
        Me.fraPROPIETARIO.Controls.Add(Me.cboHIAVVIGE)
        Me.fraPROPIETARIO.Controls.Add(Me.Label8)
        Me.fraPROPIETARIO.Controls.Add(Me.txtHIAVAVAL)
        Me.fraPROPIETARIO.Controls.Add(Me.Label7)
        Me.fraPROPIETARIO.Controls.Add(Me.txtHIAVVACC)
        Me.fraPROPIETARIO.Controls.Add(Me.txtHIAVVACP)
        Me.fraPROPIETARIO.Controls.Add(Me.txtHIAVVATC)
        Me.fraPROPIETARIO.Controls.Add(Me.txtHIAVVATP)
        Me.fraPROPIETARIO.Controls.Add(Me.Label3)
        Me.fraPROPIETARIO.Controls.Add(Me.Label4)
        Me.fraPROPIETARIO.Controls.Add(Me.Label5)
        Me.fraPROPIETARIO.Controls.Add(Me.Label6)
        Me.fraPROPIETARIO.Controls.Add(Me.txtHIAVACCO)
        Me.fraPROPIETARIO.Controls.Add(Me.txtHIAVACPR)
        Me.fraPROPIETARIO.Controls.Add(Me.txtHIAVATCO)
        Me.fraPROPIETARIO.Controls.Add(Me.txtHIAVATPR)
        Me.fraPROPIETARIO.Controls.Add(Me.lblDocumento)
        Me.fraPROPIETARIO.Controls.Add(Me.lblNombre)
        Me.fraPROPIETARIO.Controls.Add(Me.lblSegundoApellido)
        Me.fraPROPIETARIO.Controls.Add(Me.lblPrimerApellido)
        Me.fraPROPIETARIO.Controls.Add(Me.lblCapr1)
        Me.fraPROPIETARIO.ForeColor = System.Drawing.Color.Black
        Me.fraPROPIETARIO.Location = New System.Drawing.Point(15, 196)
        Me.fraPROPIETARIO.Name = "fraPROPIETARIO"
        Me.fraPROPIETARIO.Size = New System.Drawing.Size(845, 133)
        Me.fraPROPIETARIO.TabIndex = 3
        Me.fraPROPIETARIO.TabStop = False
        Me.fraPROPIETARIO.Text = "AVALÚO CATASTRAL"
        '
        'cboHIAVESTA
        '
        Me.cboHIAVESTA.AccessibleDescription = "Estado"
        Me.cboHIAVESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboHIAVESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHIAVESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHIAVESTA.FormattingEnabled = True
        Me.cboHIAVESTA.Location = New System.Drawing.Point(17, 97)
        Me.cboHIAVESTA.Name = "cboHIAVESTA"
        Me.cboHIAVESTA.Size = New System.Drawing.Size(216, 22)
        Me.cboHIAVESTA.TabIndex = 20
        '
        'cboHIAVVIGE
        '
        Me.cboHIAVVIGE.AccessibleDescription = "Vigencia"
        Me.cboHIAVVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboHIAVVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHIAVVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHIAVVIGE.FormattingEnabled = True
        Me.cboHIAVVIGE.Location = New System.Drawing.Point(17, 48)
        Me.cboHIAVVIGE.Name = "cboHIAVVIGE"
        Me.cboHIAVVIGE.Size = New System.Drawing.Size(216, 22)
        Me.cboHIAVVIGE.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(17, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(216, 20)
        Me.Label8.TabIndex = 386
        Me.Label8.Text = "Estado"
        '
        'txtHIAVAVAL
        '
        Me.txtHIAVAVAL.AccessibleDescription = "Avalúo total"
        Me.txtHIAVAVAL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHIAVAVAL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHIAVAVAL.Location = New System.Drawing.Point(702, 97)
        Me.txtHIAVAVAL.MaxLength = 9
        Me.txtHIAVAVAL.Name = "txtHIAVAVAL"
        Me.txtHIAVAVAL.Size = New System.Drawing.Size(118, 20)
        Me.txtHIAVAVAL.TabIndex = 25
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(702, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 20)
        Me.Label7.TabIndex = 384
        Me.Label7.Text = "Avalúo total"
        '
        'txtHIAVVACC
        '
        Me.txtHIAVVACC.AccessibleDescription = "Valor const. comun"
        Me.txtHIAVVACC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHIAVVACC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHIAVVACC.Location = New System.Drawing.Point(583, 97)
        Me.txtHIAVVACC.MaxLength = 9
        Me.txtHIAVVACC.Name = "txtHIAVVACC"
        Me.txtHIAVVACC.Size = New System.Drawing.Size(116, 20)
        Me.txtHIAVVACC.TabIndex = 24
        '
        'txtHIAVVACP
        '
        Me.txtHIAVVACP.AccessibleDescription = "Valor const. privada"
        Me.txtHIAVVACP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHIAVVACP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHIAVVACP.Location = New System.Drawing.Point(466, 97)
        Me.txtHIAVVACP.MaxLength = 9
        Me.txtHIAVVACP.Name = "txtHIAVVACP"
        Me.txtHIAVVACP.Size = New System.Drawing.Size(114, 20)
        Me.txtHIAVVACP.TabIndex = 23
        '
        'txtHIAVVATC
        '
        Me.txtHIAVVATC.AccessibleDescription = "Valor lote comun"
        Me.txtHIAVVATC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHIAVVATC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHIAVVATC.Location = New System.Drawing.Point(351, 97)
        Me.txtHIAVVATC.MaxLength = 9
        Me.txtHIAVVATC.Name = "txtHIAVVATC"
        Me.txtHIAVVATC.Size = New System.Drawing.Size(112, 20)
        Me.txtHIAVVATC.TabIndex = 22
        '
        'txtHIAVVATP
        '
        Me.txtHIAVVATP.AccessibleDescription = "Valor lote privado"
        Me.txtHIAVVATP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHIAVVATP.Location = New System.Drawing.Point(236, 97)
        Me.txtHIAVVATP.MaxLength = 9
        Me.txtHIAVVATP.Name = "txtHIAVVATP"
        Me.txtHIAVVATP.Size = New System.Drawing.Size(112, 20)
        Me.txtHIAVVATP.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(236, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 382
        Me.Label3.Text = "Valor terreno privado"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(583, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 20)
        Me.Label4.TabIndex = 381
        Me.Label4.Text = "Valor const. comun"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(466, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 20)
        Me.Label5.TabIndex = 380
        Me.Label5.Text = "Valor const. privada"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(351, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 379
        Me.Label6.Text = "Valor terreno comun"
        '
        'txtHIAVACCO
        '
        Me.txtHIAVACCO.AccessibleDescription = "Área const. comun"
        Me.txtHIAVACCO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHIAVACCO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHIAVACCO.Location = New System.Drawing.Point(584, 48)
        Me.txtHIAVACCO.MaxLength = 15
        Me.txtHIAVACCO.Name = "txtHIAVACCO"
        Me.txtHIAVACCO.Size = New System.Drawing.Size(116, 20)
        Me.txtHIAVACCO.TabIndex = 19
        '
        'txtHIAVACPR
        '
        Me.txtHIAVACPR.AccessibleDescription = "Área const. privada"
        Me.txtHIAVACPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHIAVACPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHIAVACPR.Location = New System.Drawing.Point(467, 48)
        Me.txtHIAVACPR.MaxLength = 15
        Me.txtHIAVACPR.Name = "txtHIAVACPR"
        Me.txtHIAVACPR.Size = New System.Drawing.Size(114, 20)
        Me.txtHIAVACPR.TabIndex = 18
        '
        'txtHIAVATCO
        '
        Me.txtHIAVATCO.AccessibleDescription = "Área lote comun"
        Me.txtHIAVATCO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHIAVATCO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHIAVATCO.Location = New System.Drawing.Point(351, 48)
        Me.txtHIAVATCO.MaxLength = 15
        Me.txtHIAVATCO.Name = "txtHIAVATCO"
        Me.txtHIAVATCO.Size = New System.Drawing.Size(113, 20)
        Me.txtHIAVATCO.TabIndex = 17
        '
        'txtHIAVATPR
        '
        Me.txtHIAVATPR.AccessibleDescription = "Área lote privado"
        Me.txtHIAVATPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHIAVATPR.Location = New System.Drawing.Point(236, 48)
        Me.txtHIAVATPR.MaxLength = 15
        Me.txtHIAVATPR.Name = "txtHIAVATPR"
        Me.txtHIAVATPR.Size = New System.Drawing.Size(112, 20)
        Me.txtHIAVATPR.TabIndex = 16
        '
        'lblDocumento
        '
        Me.lblDocumento.AccessibleDescription = "Área lote privado"
        Me.lblDocumento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDocumento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumento.ForeColor = System.Drawing.Color.Black
        Me.lblDocumento.Location = New System.Drawing.Point(236, 25)
        Me.lblDocumento.Name = "lblDocumento"
        Me.lblDocumento.Size = New System.Drawing.Size(112, 20)
        Me.lblDocumento.TabIndex = 374
        Me.lblDocumento.Text = "Área terreno privado"
        '
        'lblNombre
        '
        Me.lblNombre.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombre.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.Black
        Me.lblNombre.Location = New System.Drawing.Point(584, 25)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(116, 20)
        Me.lblNombre.TabIndex = 372
        Me.lblNombre.Text = "Área const. comun"
        '
        'lblSegundoApellido
        '
        Me.lblSegundoApellido.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblSegundoApellido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSegundoApellido.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSegundoApellido.ForeColor = System.Drawing.Color.Black
        Me.lblSegundoApellido.Location = New System.Drawing.Point(467, 25)
        Me.lblSegundoApellido.Name = "lblSegundoApellido"
        Me.lblSegundoApellido.Size = New System.Drawing.Size(114, 20)
        Me.lblSegundoApellido.TabIndex = 371
        Me.lblSegundoApellido.Text = "Área const. privada"
        '
        'lblPrimerApellido
        '
        Me.lblPrimerApellido.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPrimerApellido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPrimerApellido.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrimerApellido.ForeColor = System.Drawing.Color.Black
        Me.lblPrimerApellido.Location = New System.Drawing.Point(351, 25)
        Me.lblPrimerApellido.Name = "lblPrimerApellido"
        Me.lblPrimerApellido.Size = New System.Drawing.Size(113, 20)
        Me.lblPrimerApellido.TabIndex = 370
        Me.lblPrimerApellido.Text = "Área terreno comun"
        '
        'lblCapr1
        '
        Me.lblCapr1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCapr1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCapr1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapr1.ForeColor = System.Drawing.Color.Black
        Me.lblCapr1.Location = New System.Drawing.Point(17, 25)
        Me.lblCapr1.Name = "lblCapr1"
        Me.lblCapr1.Size = New System.Drawing.Size(215, 20)
        Me.lblCapr1.TabIndex = 369
        Me.lblCapr1.Text = "Vigencia de avalúo"
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
        Me.GroupBox3.Location = New System.Drawing.Point(15, 398)
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
        Me.fraFICHPRED.Controls.Add(Me.cboSUIMESTA)
        Me.fraFICHPRED.Controls.Add(Me.cboSUIMMOAD)
        Me.fraFICHPRED.Controls.Add(Me.cboSUIMCAPR)
        Me.fraFICHPRED.Controls.Add(Me.cboSUIMCLSE)
        Me.fraFICHPRED.Controls.Add(Me.Label2)
        Me.fraFICHPRED.Controls.Add(Me.txtSUIMNUFI)
        Me.fraFICHPRED.Controls.Add(Me.Label1)
        Me.fraFICHPRED.Controls.Add(Me.Label33)
        Me.fraFICHPRED.Controls.Add(Me.Label59)
        Me.fraFICHPRED.Controls.Add(Me.lblAdquisicionDelPredio)
        Me.fraFICHPRED.Controls.Add(Me.txtSUIMCORR)
        Me.fraFICHPRED.Controls.Add(Me.txtSUIMMUNI)
        Me.fraFICHPRED.Controls.Add(Me.lblClaseOSector2)
        Me.fraFICHPRED.Controls.Add(Me.txtSUIMUNPR)
        Me.fraFICHPRED.Controls.Add(Me.txtSUIMEDIF)
        Me.fraFICHPRED.Controls.Add(Me.txtSUIMPRED)
        Me.fraFICHPRED.Controls.Add(Me.txtSUIMMANZ)
        Me.fraFICHPRED.Controls.Add(Me.txtSUIMBARR)
        Me.fraFICHPRED.Controls.Add(Me.lblCodigoActual)
        Me.fraFICHPRED.Controls.Add(Me.lblUnidadPredial)
        Me.fraFICHPRED.Controls.Add(Me.lblEdificio)
        Me.fraFICHPRED.Controls.Add(Me.lblPredio)
        Me.fraFICHPRED.Controls.Add(Me.lblManzana)
        Me.fraFICHPRED.Controls.Add(Me.lblBarrio)
        Me.fraFICHPRED.Controls.Add(Me.lblCorregimiento)
        Me.fraFICHPRED.Controls.Add(Me.lblMunicipio)
        Me.fraFICHPRED.Controls.Add(Me.lblCodigo)
        Me.fraFICHPRED.Controls.Add(Me.txtSUIMDIRE)
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
        'cboSUIMESTA
        '
        Me.cboSUIMESTA.AccessibleDescription = "Estado"
        Me.cboSUIMESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSUIMESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSUIMESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSUIMESTA.FormattingEnabled = True
        Me.cboSUIMESTA.Location = New System.Drawing.Point(727, 88)
        Me.cboSUIMESTA.Name = "cboSUIMESTA"
        Me.cboSUIMESTA.Size = New System.Drawing.Size(91, 22)
        Me.cboSUIMESTA.TabIndex = 10
        '
        'cboSUIMMOAD
        '
        Me.cboSUIMMOAD.AccessibleDescription = "Modo de adquisición"
        Me.cboSUIMMOAD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSUIMMOAD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSUIMMOAD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSUIMMOAD.FormattingEnabled = True
        Me.cboSUIMMOAD.Location = New System.Drawing.Point(551, 114)
        Me.cboSUIMMOAD.Name = "cboSUIMMOAD"
        Me.cboSUIMMOAD.Size = New System.Drawing.Size(267, 22)
        Me.cboSUIMMOAD.TabIndex = 14
        '
        'cboSUIMCAPR
        '
        Me.cboSUIMCAPR.AccessibleDescription = "Caracteristica de predio"
        Me.cboSUIMCAPR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSUIMCAPR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSUIMCAPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSUIMCAPR.FormattingEnabled = True
        Me.cboSUIMCAPR.Location = New System.Drawing.Point(110, 135)
        Me.cboSUIMCAPR.Name = "cboSUIMCAPR"
        Me.cboSUIMCAPR.Size = New System.Drawing.Size(261, 22)
        Me.cboSUIMCAPR.TabIndex = 13
        '
        'cboSUIMCLSE
        '
        Me.cboSUIMCLSE.AccessibleDescription = "Clase o sector"
        Me.cboSUIMCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSUIMCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSUIMCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSUIMCLSE.FormattingEnabled = True
        Me.cboSUIMCLSE.Location = New System.Drawing.Point(110, 112)
        Me.cboSUIMCLSE.Name = "cboSUIMCLSE"
        Me.cboSUIMCLSE.Size = New System.Drawing.Size(261, 22)
        Me.cboSUIMCLSE.TabIndex = 11
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
        'txtSUIMNUFI
        '
        Me.txtSUIMNUFI.AccessibleDescription = "Nro. Ficha predial"
        Me.txtSUIMNUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMNUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMNUFI.Location = New System.Drawing.Point(111, 19)
        Me.txtSUIMNUFI.MaxLength = 8
        Me.txtSUIMNUFI.Name = "txtSUIMNUFI"
        Me.txtSUIMNUFI.Size = New System.Drawing.Size(173, 20)
        Me.txtSUIMNUFI.TabIndex = 1
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
        Me.lblAdquisicionDelPredio.Location = New System.Drawing.Point(375, 114)
        Me.lblAdquisicionDelPredio.Name = "lblAdquisicionDelPredio"
        Me.lblAdquisicionDelPredio.Size = New System.Drawing.Size(172, 20)
        Me.lblAdquisicionDelPredio.TabIndex = 273
        Me.lblAdquisicionDelPredio.Text = "Modo de adquisición"
        '
        'txtSUIMCORR
        '
        Me.txtSUIMCORR.AccessibleDescription = "Corregimiento"
        Me.txtSUIMCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMCORR.Location = New System.Drawing.Point(199, 88)
        Me.txtSUIMCORR.MaxLength = 10
        Me.txtSUIMCORR.Name = "txtSUIMCORR"
        Me.txtSUIMCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtSUIMCORR.TabIndex = 4
        '
        'txtSUIMMUNI
        '
        Me.txtSUIMMUNI.AccessibleDescription = "Municipio"
        Me.txtSUIMMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMMUNI.Location = New System.Drawing.Point(111, 88)
        Me.txtSUIMMUNI.MaxLength = 10
        Me.txtSUIMMUNI.Name = "txtSUIMMUNI"
        Me.txtSUIMMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtSUIMMUNI.TabIndex = 3
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
        'txtSUIMUNPR
        '
        Me.txtSUIMUNPR.AccessibleDescription = "Unidad predial "
        Me.txtSUIMUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUIMUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtSUIMUNPR.Location = New System.Drawing.Point(639, 88)
        Me.txtSUIMUNPR.MaxLength = 10
        Me.txtSUIMUNPR.Name = "txtSUIMUNPR"
        Me.txtSUIMUNPR.Size = New System.Drawing.Size(85, 20)
        Me.txtSUIMUNPR.TabIndex = 9
        '
        'txtSUIMEDIF
        '
        Me.txtSUIMEDIF.AccessibleDescription = "Edificio "
        Me.txtSUIMEDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMEDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUIMEDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMEDIF.ForeColor = System.Drawing.Color.Black
        Me.txtSUIMEDIF.Location = New System.Drawing.Point(551, 88)
        Me.txtSUIMEDIF.MaxLength = 10
        Me.txtSUIMEDIF.Name = "txtSUIMEDIF"
        Me.txtSUIMEDIF.Size = New System.Drawing.Size(85, 20)
        Me.txtSUIMEDIF.TabIndex = 8
        '
        'txtSUIMPRED
        '
        Me.txtSUIMPRED.AccessibleDescription = "Predio "
        Me.txtSUIMPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUIMPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMPRED.ForeColor = System.Drawing.Color.Black
        Me.txtSUIMPRED.Location = New System.Drawing.Point(463, 88)
        Me.txtSUIMPRED.MaxLength = 10
        Me.txtSUIMPRED.Name = "txtSUIMPRED"
        Me.txtSUIMPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtSUIMPRED.TabIndex = 7
        '
        'txtSUIMMANZ
        '
        Me.txtSUIMMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtSUIMMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUIMMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtSUIMMANZ.Location = New System.Drawing.Point(375, 88)
        Me.txtSUIMMANZ.MaxLength = 10
        Me.txtSUIMMANZ.Name = "txtSUIMMANZ"
        Me.txtSUIMMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtSUIMMANZ.TabIndex = 6
        '
        'txtSUIMBARR
        '
        Me.txtSUIMBARR.AccessibleDescription = "Barrio "
        Me.txtSUIMBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUIMBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMBARR.ForeColor = System.Drawing.Color.Black
        Me.txtSUIMBARR.Location = New System.Drawing.Point(287, 88)
        Me.txtSUIMBARR.MaxLength = 10
        Me.txtSUIMBARR.Name = "txtSUIMBARR"
        Me.txtSUIMBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtSUIMBARR.TabIndex = 5
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
        'txtSUIMDIRE
        '
        Me.txtSUIMDIRE.AccessibleDescription = "Dirección "
        Me.txtSUIMDIRE.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMDIRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUIMDIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMDIRE.ForeColor = System.Drawing.Color.Black
        Me.txtSUIMDIRE.Location = New System.Drawing.Point(375, 19)
        Me.txtSUIMDIRE.MaxLength = 49
        Me.txtSUIMDIRE.Name = "txtSUIMDIRE"
        Me.txtSUIMDIRE.Size = New System.Drawing.Size(444, 20)
        Me.txtSUIMDIRE.TabIndex = 2
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
        'frm_consulta_historico_de_avaluos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 685)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_consulta_historico_de_avaluos"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CONSULTA HISTORICO DE AVALÚOS"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
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
    Friend WithEvents txtHIAVACCO As System.Windows.Forms.TextBox
    Friend WithEvents txtHIAVACPR As System.Windows.Forms.TextBox
    Friend WithEvents txtHIAVATCO As System.Windows.Forms.TextBox
    Friend WithEvents txtHIAVATPR As System.Windows.Forms.TextBox
    Friend WithEvents lblDocumento As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblSegundoApellido As System.Windows.Forms.Label
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSUIMNUFI As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents lblAdquisicionDelPredio As System.Windows.Forms.Label
    Friend WithEvents txtSUIMCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtSUIMMUNI As System.Windows.Forms.TextBox
    Friend WithEvents lblClaseOSector2 As System.Windows.Forms.Label
    Friend WithEvents txtSUIMUNPR As System.Windows.Forms.TextBox
    Friend WithEvents txtSUIMEDIF As System.Windows.Forms.TextBox
    Friend WithEvents txtSUIMPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtSUIMMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtSUIMBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents lblUnidadPredial As System.Windows.Forms.Label
    Friend WithEvents lblEdificio As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtSUIMDIRE As System.Windows.Forms.TextBox
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents txtHIAVVACC As System.Windows.Forms.TextBox
    Friend WithEvents txtHIAVVACP As System.Windows.Forms.TextBox
    Friend WithEvents txtHIAVVATC As System.Windows.Forms.TextBox
    Friend WithEvents txtHIAVVATP As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHIAVAVAL As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHIAVTOAV As System.Windows.Forms.TextBox
    Friend WithEvents txtHIAVTVCC As System.Windows.Forms.TextBox
    Friend WithEvents txtHIAVTVCP As System.Windows.Forms.TextBox
    Friend WithEvents txtHIAVTVTC As System.Windows.Forms.TextBox
    Friend WithEvents txtHIAVTVTP As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboSUIMESTA As System.Windows.Forms.ComboBox
    Friend WithEvents cboSUIMMOAD As System.Windows.Forms.ComboBox
    Friend WithEvents cboSUIMCAPR As System.Windows.Forms.ComboBox
    Friend WithEvents cboSUIMCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents cboHIAVESTA As System.Windows.Forms.ComboBox
    Friend WithEvents cboHIAVVIGE As System.Windows.Forms.ComboBox
End Class
