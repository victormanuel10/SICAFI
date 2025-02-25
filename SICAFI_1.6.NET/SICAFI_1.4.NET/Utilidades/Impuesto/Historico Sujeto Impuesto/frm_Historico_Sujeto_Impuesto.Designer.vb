<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Historico_Sujeto_Impuesto
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdLIMPIAR = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.pbPROCESO = New System.Windows.Forms.ProgressBar()
        Me.cmdLIQUIDAR = New System.Windows.Forms.Button()
        Me.fraFICHPRED = New System.Windows.Forms.GroupBox()
        Me.lblAFSICONC = New System.Windows.Forms.Label()
        Me.cboAFSICONC = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblAFSITIIM = New System.Windows.Forms.Label()
        Me.cboAFSITIIM = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblFIPRCLSE = New System.Windows.Forms.Label()
        Me.cboFIPRCLSE = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblFIPRVIGE = New System.Windows.Forms.Label()
        Me.cboFIPRVIGE = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFIPRFIFI = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFIPRFIIN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtFIPRCORR = New System.Windows.Forms.TextBox()
        Me.txtFIPRMUNI = New System.Windows.Forms.TextBox()
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
        Me.rbdSUIMVIAN = New System.Windows.Forms.RadioButton()
        Me.rbdSUIMVIAC = New System.Windows.Forms.RadioButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbdRemplazarTodosLosPredios = New System.Windows.Forms.RadioButton()
        Me.rbdInscribirSoloPrediosNuevos = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkAforoImpuesto = New System.Windows.Forms.CheckBox()
        Me.chkHistoricoLiquidacion = New System.Windows.Forms.CheckBox()
        Me.chkHistoricoAvaluo = New System.Windows.Forms.CheckBox()
        Me.chkHistoricoZonas = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.chkLiquidaIncrementoIdentificador = New System.Windows.Forms.CheckBox()
        Me.chkLiquidaIncrementoZona = New System.Windows.Forms.CheckBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.chkAplicarPorcentajeMaximoDeLiquidacion = New System.Windows.Forms.CheckBox()
        Me.rbdAplicarTarifaPorZonaAlLote = New System.Windows.Forms.RadioButton()
        Me.rbdAplicarTarifaUnicaAlLote = New System.Windows.Forms.RadioButton()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.rbdZonaEconomica = New System.Windows.Forms.RadioButton()
        Me.rbdZonaFisica = New System.Windows.Forms.RadioButton()
        Me.GroupBox2.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.fraFICHPRED.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdLIMPIAR)
        Me.GroupBox2.Controls.Add(Me.cmdSALIR)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(17, 541)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(740, 47)
        Me.GroupBox2.TabIndex = 66
        Me.GroupBox2.TabStop = False
        '
        'cmdLIMPIAR
        '
        Me.cmdLIMPIAR.AccessibleDescription = "Limpiar campo"
        Me.cmdLIMPIAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLIMPIAR.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLIMPIAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLIMPIAR.Location = New System.Drawing.Point(19, 15)
        Me.cmdLIMPIAR.Name = "cmdLIMPIAR"
        Me.cmdLIMPIAR.Size = New System.Drawing.Size(123, 23)
        Me.cmdLIMPIAR.TabIndex = 13
        Me.cmdLIMPIAR.Text = "&Limpiar campos"
        Me.cmdLIMPIAR.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(599, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(123, 23)
        Me.cmdSALIR.TabIndex = 20
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 605)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(771, 25)
        Me.strBARRESTA.TabIndex = 65
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.pbPROCESO)
        Me.GroupBox3.Controls.Add(Me.cmdLIQUIDAR)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(17, 488)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(740, 47)
        Me.GroupBox3.TabIndex = 64
        Me.GroupBox3.TabStop = False
        '
        'pbPROCESO
        '
        Me.pbPROCESO.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pbPROCESO.Location = New System.Drawing.Point(286, 19)
        Me.pbPROCESO.Name = "pbPROCESO"
        Me.pbPROCESO.Size = New System.Drawing.Size(436, 17)
        Me.pbPROCESO.TabIndex = 23
        '
        'cmdLIQUIDAR
        '
        Me.cmdLIQUIDAR.AccessibleDescription = "Liquidar avalúo"
        Me.cmdLIQUIDAR.Image = Global.SICAFI.My.Resources.Resources._167
        Me.cmdLIQUIDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLIQUIDAR.Location = New System.Drawing.Point(19, 15)
        Me.cmdLIQUIDAR.Name = "cmdLIQUIDAR"
        Me.cmdLIQUIDAR.Size = New System.Drawing.Size(261, 23)
        Me.cmdLIQUIDAR.TabIndex = 12
        Me.cmdLIQUIDAR.Text = "&Procesar Historico Sujeto Impuesto"
        Me.cmdLIQUIDAR.UseVisualStyleBackColor = True
        '
        'fraFICHPRED
        '
        Me.fraFICHPRED.BackColor = System.Drawing.SystemColors.Control
        Me.fraFICHPRED.Controls.Add(Me.lblAFSICONC)
        Me.fraFICHPRED.Controls.Add(Me.cboAFSICONC)
        Me.fraFICHPRED.Controls.Add(Me.Label6)
        Me.fraFICHPRED.Controls.Add(Me.lblAFSITIIM)
        Me.fraFICHPRED.Controls.Add(Me.cboAFSITIIM)
        Me.fraFICHPRED.Controls.Add(Me.Label11)
        Me.fraFICHPRED.Controls.Add(Me.lblFIPRCLSE)
        Me.fraFICHPRED.Controls.Add(Me.cboFIPRCLSE)
        Me.fraFICHPRED.Controls.Add(Me.Label5)
        Me.fraFICHPRED.Controls.Add(Me.lblFIPRVIGE)
        Me.fraFICHPRED.Controls.Add(Me.cboFIPRVIGE)
        Me.fraFICHPRED.Controls.Add(Me.Label4)
        Me.fraFICHPRED.Controls.Add(Me.Label2)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRFIFI)
        Me.fraFICHPRED.Controls.Add(Me.Label3)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRFIIN)
        Me.fraFICHPRED.Controls.Add(Me.Label1)
        Me.fraFICHPRED.Controls.Add(Me.Label33)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRCORR)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRMUNI)
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
        Me.fraFICHPRED.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraFICHPRED.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraFICHPRED.Location = New System.Drawing.Point(17, 4)
        Me.fraFICHPRED.Name = "fraFICHPRED"
        Me.fraFICHPRED.Size = New System.Drawing.Size(740, 205)
        Me.fraFICHPRED.TabIndex = 63
        Me.fraFICHPRED.TabStop = False
        Me.fraFICHPRED.Text = "DATOS FICHA PREDIAL "
        '
        'lblAFSICONC
        '
        Me.lblAFSICONC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblAFSICONC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAFSICONC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAFSICONC.ForeColor = System.Drawing.Color.Black
        Me.lblAFSICONC.Location = New System.Drawing.Point(638, 171)
        Me.lblAFSICONC.Name = "lblAFSICONC"
        Me.lblAFSICONC.Size = New System.Drawing.Size(83, 20)
        Me.lblAFSICONC.TabIndex = 334
        '
        'cboAFSICONC
        '
        Me.cboAFSICONC.AccessibleDescription = "Concepto"
        Me.cboAFSICONC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboAFSICONC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAFSICONC.Enabled = False
        Me.cboAFSICONC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAFSICONC.FormattingEnabled = True
        Me.cboAFSICONC.Location = New System.Drawing.Point(462, 169)
        Me.cboAFSICONC.Name = "cboAFSICONC"
        Me.cboAFSICONC.Size = New System.Drawing.Size(172, 22)
        Me.cboAFSICONC.TabIndex = 330
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(374, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 20)
        Me.Label6.TabIndex = 333
        Me.Label6.Text = "Concepto"
        '
        'lblAFSITIIM
        '
        Me.lblAFSITIIM.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblAFSITIIM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAFSITIIM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAFSITIIM.ForeColor = System.Drawing.Color.Black
        Me.lblAFSITIIM.Location = New System.Drawing.Point(638, 147)
        Me.lblAFSITIIM.Name = "lblAFSITIIM"
        Me.lblAFSITIIM.Size = New System.Drawing.Size(83, 20)
        Me.lblAFSITIIM.TabIndex = 332
        '
        'cboAFSITIIM
        '
        Me.cboAFSITIIM.AccessibleDescription = "Tipo de impuesto"
        Me.cboAFSITIIM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboAFSITIIM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAFSITIIM.Enabled = False
        Me.cboAFSITIIM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAFSITIIM.FormattingEnabled = True
        Me.cboAFSITIIM.Location = New System.Drawing.Point(462, 145)
        Me.cboAFSITIIM.Name = "cboAFSITIIM"
        Me.cboAFSITIIM.Size = New System.Drawing.Size(172, 22)
        Me.cboAFSITIIM.TabIndex = 329
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(374, 145)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 20)
        Me.Label11.TabIndex = 331
        Me.Label11.Text = "Tipo Impuesto"
        '
        'lblFIPRCLSE
        '
        Me.lblFIPRCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFIPRCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFIPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFIPRCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblFIPRCLSE.Location = New System.Drawing.Point(286, 168)
        Me.lblFIPRCLSE.Name = "lblFIPRCLSE"
        Me.lblFIPRCLSE.Size = New System.Drawing.Size(84, 20)
        Me.lblFIPRCLSE.TabIndex = 322
        '
        'cboFIPRCLSE
        '
        Me.cboFIPRCLSE.AccessibleDescription = "Sector"
        Me.cboFIPRCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFIPRCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFIPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFIPRCLSE.FormattingEnabled = True
        Me.cboFIPRCLSE.Location = New System.Drawing.Point(109, 166)
        Me.cboFIPRCLSE.Name = "cboFIPRCLSE"
        Me.cboFIPRCLSE.Size = New System.Drawing.Size(173, 22)
        Me.cboFIPRCLSE.TabIndex = 321
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 20)
        Me.Label5.TabIndex = 320
        Me.Label5.Text = "Sector"
        '
        'lblFIPRVIGE
        '
        Me.lblFIPRVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFIPRVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFIPRVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFIPRVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblFIPRVIGE.Location = New System.Drawing.Point(286, 145)
        Me.lblFIPRVIGE.Name = "lblFIPRVIGE"
        Me.lblFIPRVIGE.Size = New System.Drawing.Size(84, 20)
        Me.lblFIPRVIGE.TabIndex = 319
        '
        'cboFIPRVIGE
        '
        Me.cboFIPRVIGE.AccessibleDescription = "Vigencia"
        Me.cboFIPRVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFIPRVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFIPRVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFIPRVIGE.FormattingEnabled = True
        Me.cboFIPRVIGE.Location = New System.Drawing.Point(109, 143)
        Me.cboFIPRVIGE.Name = "cboFIPRVIGE"
        Me.cboFIPRVIGE.Size = New System.Drawing.Size(173, 22)
        Me.cboFIPRVIGE.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 20)
        Me.Label4.TabIndex = 317
        Me.Label4.Text = "Vigencia"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 20)
        Me.Label2.TabIndex = 315
        Me.Label2.Text = "Rango inicial"
        '
        'txtFIPRFIFI
        '
        Me.txtFIPRFIFI.AccessibleDescription = "Ficha final"
        Me.txtFIPRFIFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRFIFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRFIFI.Location = New System.Drawing.Point(374, 51)
        Me.txtFIPRFIFI.MaxLength = 9
        Me.txtFIPRFIFI.Name = "txtFIPRFIFI"
        Me.txtFIPRFIFI.Size = New System.Drawing.Size(173, 20)
        Me.txtFIPRFIFI.TabIndex = 2
        Me.txtFIPRFIFI.Text = "999999999"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(286, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 313
        Me.Label3.Text = "Rango final"
        '
        'txtFIPRFIIN
        '
        Me.txtFIPRFIIN.AccessibleDescription = "Ficha inicial"
        Me.txtFIPRFIIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRFIIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRFIIN.Location = New System.Drawing.Point(109, 51)
        Me.txtFIPRFIIN.MaxLength = 9
        Me.txtFIPRFIIN.Name = "txtFIPRFIIN"
        Me.txtFIPRFIIN.Size = New System.Drawing.Size(173, 20)
        Me.txtFIPRFIIN.TabIndex = 1
        Me.txtFIPRFIIN.Text = "0"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(528, 20)
        Me.Label1.TabIndex = 288
        Me.Label1.Text = "NUMERO DE FICHA"
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(19, 74)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(702, 20)
        Me.Label33.TabIndex = 278
        Me.Label33.Text = "CEDULA CATASTRAL ACTUAL"
        '
        'txtFIPRCORR
        '
        Me.txtFIPRCORR.AccessibleDescription = "Corregimiento"
        Me.txtFIPRCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRCORR.Location = New System.Drawing.Point(198, 120)
        Me.txtFIPRCORR.MaxLength = 10
        Me.txtFIPRCORR.Name = "txtFIPRCORR"
        Me.txtFIPRCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRCORR.TabIndex = 5
        '
        'txtFIPRMUNI
        '
        Me.txtFIPRMUNI.AccessibleDescription = "Municipio"
        Me.txtFIPRMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMUNI.Location = New System.Drawing.Point(110, 120)
        Me.txtFIPRMUNI.MaxLength = 10
        Me.txtFIPRMUNI.Name = "txtFIPRMUNI"
        Me.txtFIPRMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRMUNI.TabIndex = 4
        '
        'txtFIPRUNPR
        '
        Me.txtFIPRUNPR.AccessibleDescription = "Unidad predial "
        Me.txtFIPRUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRUNPR.Location = New System.Drawing.Point(638, 120)
        Me.txtFIPRUNPR.MaxLength = 10
        Me.txtFIPRUNPR.Name = "txtFIPRUNPR"
        Me.txtFIPRUNPR.Size = New System.Drawing.Size(83, 20)
        Me.txtFIPRUNPR.TabIndex = 10
        '
        'txtFIPREDIF
        '
        Me.txtFIPREDIF.AccessibleDescription = "Edificio "
        Me.txtFIPREDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPREDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPREDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPREDIF.ForeColor = System.Drawing.Color.Black
        Me.txtFIPREDIF.Location = New System.Drawing.Point(550, 120)
        Me.txtFIPREDIF.MaxLength = 10
        Me.txtFIPREDIF.Name = "txtFIPREDIF"
        Me.txtFIPREDIF.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPREDIF.TabIndex = 9
        '
        'txtFIPRPRED
        '
        Me.txtFIPRPRED.AccessibleDescription = "Predio "
        Me.txtFIPRPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRPRED.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRPRED.Location = New System.Drawing.Point(462, 120)
        Me.txtFIPRPRED.MaxLength = 10
        Me.txtFIPRPRED.Name = "txtFIPRPRED"
        Me.txtFIPRPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRPRED.TabIndex = 8
        '
        'txtFIPRMANZ
        '
        Me.txtFIPRMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtFIPRMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRMANZ.Location = New System.Drawing.Point(374, 120)
        Me.txtFIPRMANZ.MaxLength = 10
        Me.txtFIPRMANZ.Name = "txtFIPRMANZ"
        Me.txtFIPRMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRMANZ.TabIndex = 7
        '
        'txtFIPRBARR
        '
        Me.txtFIPRBARR.AccessibleDescription = "Barrio "
        Me.txtFIPRBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRBARR.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRBARR.Location = New System.Drawing.Point(286, 120)
        Me.txtFIPRBARR.MaxLength = 10
        Me.txtFIPRBARR.Name = "txtFIPRBARR"
        Me.txtFIPRBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRBARR.TabIndex = 6
        '
        'lblCodigoActual
        '
        Me.lblCodigoActual.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigoActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigoActual.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoActual.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoActual.Location = New System.Drawing.Point(19, 120)
        Me.lblCodigoActual.Name = "lblCodigoActual"
        Me.lblCodigoActual.Size = New System.Drawing.Size(87, 20)
        Me.lblCodigoActual.TabIndex = 27
        Me.lblCodigoActual.Text = "Código Actual"
        '
        'lblUnidadPredial
        '
        Me.lblUnidadPredial.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblUnidadPredial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUnidadPredial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidadPredial.ForeColor = System.Drawing.Color.Black
        Me.lblUnidadPredial.Location = New System.Drawing.Point(638, 97)
        Me.lblUnidadPredial.Name = "lblUnidadPredial"
        Me.lblUnidadPredial.Size = New System.Drawing.Size(83, 20)
        Me.lblUnidadPredial.TabIndex = 26
        Me.lblUnidadPredial.Text = "Unidad Predial"
        '
        'lblEdificio
        '
        Me.lblEdificio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblEdificio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEdificio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdificio.ForeColor = System.Drawing.Color.Black
        Me.lblEdificio.Location = New System.Drawing.Point(550, 97)
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
        Me.lblPredio.Location = New System.Drawing.Point(462, 97)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(85, 20)
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
        Me.lblManzana.Location = New System.Drawing.Point(374, 97)
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
        Me.lblBarrio.Location = New System.Drawing.Point(286, 97)
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
        Me.lblCorregimiento.Location = New System.Drawing.Point(198, 97)
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
        Me.lblMunicipio.Location = New System.Drawing.Point(110, 97)
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
        Me.lblCodigo.Location = New System.Drawing.Point(19, 97)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(87, 20)
        Me.lblCodigo.TabIndex = 300
        Me.lblCodigo.Text = "CODIGO"
        '
        'rbdSUIMVIAN
        '
        Me.rbdSUIMVIAN.AutoSize = True
        Me.rbdSUIMVIAN.Checked = True
        Me.rbdSUIMVIAN.Location = New System.Drawing.Point(19, 13)
        Me.rbdSUIMVIAN.Name = "rbdSUIMVIAN"
        Me.rbdSUIMVIAN.Size = New System.Drawing.Size(104, 17)
        Me.rbdSUIMVIAN.TabIndex = 324
        Me.rbdSUIMVIAN.TabStop = True
        Me.rbdSUIMVIAN.Text = "Vigencia anterior"
        Me.rbdSUIMVIAN.UseVisualStyleBackColor = True
        '
        'rbdSUIMVIAC
        '
        Me.rbdSUIMVIAC.AutoSize = True
        Me.rbdSUIMVIAC.Location = New System.Drawing.Point(148, 13)
        Me.rbdSUIMVIAC.Name = "rbdSUIMVIAC"
        Me.rbdSUIMVIAC.Size = New System.Drawing.Size(111, 17)
        Me.rbdSUIMVIAC.TabIndex = 323
        Me.rbdSUIMVIAC.Text = "Vigencia siguiente"
        Me.rbdSUIMVIAC.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbdSUIMVIAN)
        Me.GroupBox1.Controls.Add(Me.rbdSUIMVIAC)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 215)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(282, 40)
        Me.GroupBox1.TabIndex = 67
        Me.GroupBox1.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbdRemplazarTodosLosPredios)
        Me.GroupBox4.Controls.Add(Me.rbdInscribirSoloPrediosNuevos)
        Me.GroupBox4.Location = New System.Drawing.Point(303, 215)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(454, 40)
        Me.GroupBox4.TabIndex = 68
        Me.GroupBox4.TabStop = False
        '
        'rbdRemplazarTodosLosPredios
        '
        Me.rbdRemplazarTodosLosPredios.AutoSize = True
        Me.rbdRemplazarTodosLosPredios.Checked = True
        Me.rbdRemplazarTodosLosPredios.Location = New System.Drawing.Point(19, 13)
        Me.rbdRemplazarTodosLosPredios.Name = "rbdRemplazarTodosLosPredios"
        Me.rbdRemplazarTodosLosPredios.Size = New System.Drawing.Size(157, 17)
        Me.rbdRemplazarTodosLosPredios.TabIndex = 326
        Me.rbdRemplazarTodosLosPredios.TabStop = True
        Me.rbdRemplazarTodosLosPredios.Text = "Remplazar todos los predios"
        Me.rbdRemplazarTodosLosPredios.UseVisualStyleBackColor = True
        '
        'rbdInscribirSoloPrediosNuevos
        '
        Me.rbdInscribirSoloPrediosNuevos.AutoSize = True
        Me.rbdInscribirSoloPrediosNuevos.Location = New System.Drawing.Point(189, 13)
        Me.rbdInscribirSoloPrediosNuevos.Name = "rbdInscribirSoloPrediosNuevos"
        Me.rbdInscribirSoloPrediosNuevos.Size = New System.Drawing.Size(158, 17)
        Me.rbdInscribirSoloPrediosNuevos.TabIndex = 325
        Me.rbdInscribirSoloPrediosNuevos.Text = "Inscribir solo predios nuevos"
        Me.rbdInscribirSoloPrediosNuevos.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rbdZonaEconomica)
        Me.GroupBox5.Controls.Add(Me.rbdZonaFisica)
        Me.GroupBox5.Controls.Add(Me.chkHistoricoZonas)
        Me.GroupBox5.Location = New System.Drawing.Point(19, 314)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(738, 42)
        Me.GroupBox5.TabIndex = 69
        Me.GroupBox5.TabStop = False
        '
        'chkAforoImpuesto
        '
        Me.chkAforoImpuesto.AutoSize = True
        Me.chkAforoImpuesto.Location = New System.Drawing.Point(331, 16)
        Me.chkAforoImpuesto.Name = "chkAforoImpuesto"
        Me.chkAforoImpuesto.Size = New System.Drawing.Size(111, 17)
        Me.chkAforoImpuesto.TabIndex = 3
        Me.chkAforoImpuesto.Text = "Aforo de impuesto"
        Me.chkAforoImpuesto.UseVisualStyleBackColor = True
        Me.chkAforoImpuesto.Visible = False
        '
        'chkHistoricoLiquidacion
        '
        Me.chkHistoricoLiquidacion.AutoSize = True
        Me.chkHistoricoLiquidacion.Location = New System.Drawing.Point(161, 16)
        Me.chkHistoricoLiquidacion.Name = "chkHistoricoLiquidacion"
        Me.chkHistoricoLiquidacion.Size = New System.Drawing.Size(135, 17)
        Me.chkHistoricoLiquidacion.TabIndex = 2
        Me.chkHistoricoLiquidacion.Text = "Historico de liquidación"
        Me.chkHistoricoLiquidacion.UseVisualStyleBackColor = True
        Me.chkHistoricoLiquidacion.Visible = False
        '
        'chkHistoricoAvaluo
        '
        Me.chkHistoricoAvaluo.AutoSize = True
        Me.chkHistoricoAvaluo.Location = New System.Drawing.Point(19, 16)
        Me.chkHistoricoAvaluo.Name = "chkHistoricoAvaluo"
        Me.chkHistoricoAvaluo.Size = New System.Drawing.Size(117, 17)
        Me.chkHistoricoAvaluo.TabIndex = 1
        Me.chkHistoricoAvaluo.Text = "Historico de avalúo"
        Me.chkHistoricoAvaluo.UseVisualStyleBackColor = True
        '
        'chkHistoricoZonas
        '
        Me.chkHistoricoZonas.AutoSize = True
        Me.chkHistoricoZonas.Location = New System.Drawing.Point(19, 15)
        Me.chkHistoricoZonas.Name = "chkHistoricoZonas"
        Me.chkHistoricoZonas.Size = New System.Drawing.Size(113, 17)
        Me.chkHistoricoZonas.TabIndex = 0
        Me.chkHistoricoZonas.Text = "Historico de zonas"
        Me.chkHistoricoZonas.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.chkLiquidaIncrementoIdentificador)
        Me.GroupBox6.Controls.Add(Me.chkLiquidaIncrementoZona)
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(17, 408)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(740, 74)
        Me.GroupBox6.TabIndex = 70
        Me.GroupBox6.TabStop = False
        '
        'chkLiquidaIncrementoIdentificador
        '
        Me.chkLiquidaIncrementoIdentificador.AutoSize = True
        Me.chkLiquidaIncrementoIdentificador.Location = New System.Drawing.Point(19, 42)
        Me.chkLiquidaIncrementoIdentificador.Name = "chkLiquidaIncrementoIdentificador"
        Me.chkLiquidaIncrementoIdentificador.Size = New System.Drawing.Size(466, 17)
        Me.chkLiquidaIncrementoIdentificador.TabIndex = 0
        Me.chkLiquidaIncrementoIdentificador.Text = "Liquida Historico de avaluos con incremento individual de cada identificador de c" & _
            "onstruccion."
        Me.chkLiquidaIncrementoIdentificador.UseVisualStyleBackColor = True
        Me.chkLiquidaIncrementoIdentificador.Visible = False
        '
        'chkLiquidaIncrementoZona
        '
        Me.chkLiquidaIncrementoZona.AccessibleDescription = "Zona economica"
        Me.chkLiquidaIncrementoZona.AutoSize = True
        Me.chkLiquidaIncrementoZona.Location = New System.Drawing.Point(19, 19)
        Me.chkLiquidaIncrementoZona.Name = "chkLiquidaIncrementoZona"
        Me.chkLiquidaIncrementoZona.Size = New System.Drawing.Size(408, 17)
        Me.chkLiquidaIncrementoZona.TabIndex = 0
        Me.chkLiquidaIncrementoZona.Text = "Liquida Historico de avaluos con incremento individual de cada zona economica."
        Me.chkLiquidaIncrementoZona.UseVisualStyleBackColor = True
        Me.chkLiquidaIncrementoZona.Visible = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.chkAplicarPorcentajeMaximoDeLiquidacion)
        Me.GroupBox7.Controls.Add(Me.rbdAplicarTarifaPorZonaAlLote)
        Me.GroupBox7.Controls.Add(Me.rbdAplicarTarifaUnicaAlLote)
        Me.GroupBox7.Location = New System.Drawing.Point(19, 262)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(738, 46)
        Me.GroupBox7.TabIndex = 71
        Me.GroupBox7.TabStop = False
        '
        'chkAplicarPorcentajeMaximoDeLiquidacion
        '
        Me.chkAplicarPorcentajeMaximoDeLiquidacion.AutoSize = True
        Me.chkAplicarPorcentajeMaximoDeLiquidacion.Location = New System.Drawing.Point(372, 19)
        Me.chkAplicarPorcentajeMaximoDeLiquidacion.Name = "chkAplicarPorcentajeMaximoDeLiquidacion"
        Me.chkAplicarPorcentajeMaximoDeLiquidacion.Size = New System.Drawing.Size(254, 17)
        Me.chkAplicarPorcentajeMaximoDeLiquidacion.TabIndex = 338
        Me.chkAplicarPorcentajeMaximoDeLiquidacion.Text = "Aplicar % permitido maximo de liquidación predial"
        Me.chkAplicarPorcentajeMaximoDeLiquidacion.UseVisualStyleBackColor = True
        '
        'rbdAplicarTarifaPorZonaAlLote
        '
        Me.rbdAplicarTarifaPorZonaAlLote.AutoSize = True
        Me.rbdAplicarTarifaPorZonaAlLote.Location = New System.Drawing.Point(184, 19)
        Me.rbdAplicarTarifaPorZonaAlLote.Name = "rbdAplicarTarifaPorZonaAlLote"
        Me.rbdAplicarTarifaPorZonaAlLote.Size = New System.Drawing.Size(158, 17)
        Me.rbdAplicarTarifaPorZonaAlLote.TabIndex = 337
        Me.rbdAplicarTarifaPorZonaAlLote.Text = "Aplicar tarifa por zona al lote"
        Me.rbdAplicarTarifaPorZonaAlLote.UseVisualStyleBackColor = True
        '
        'rbdAplicarTarifaUnicaAlLote
        '
        Me.rbdAplicarTarifaUnicaAlLote.AutoSize = True
        Me.rbdAplicarTarifaUnicaAlLote.Checked = True
        Me.rbdAplicarTarifaUnicaAlLote.Location = New System.Drawing.Point(17, 19)
        Me.rbdAplicarTarifaUnicaAlLote.Name = "rbdAplicarTarifaUnicaAlLote"
        Me.rbdAplicarTarifaUnicaAlLote.Size = New System.Drawing.Size(143, 17)
        Me.rbdAplicarTarifaUnicaAlLote.TabIndex = 336
        Me.rbdAplicarTarifaUnicaAlLote.TabStop = True
        Me.rbdAplicarTarifaUnicaAlLote.Text = "Aplicar tarifa unica al lote"
        Me.rbdAplicarTarifaUnicaAlLote.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.chkAforoImpuesto)
        Me.GroupBox8.Controls.Add(Me.chkHistoricoAvaluo)
        Me.GroupBox8.Controls.Add(Me.chkHistoricoLiquidacion)
        Me.GroupBox8.Location = New System.Drawing.Point(19, 362)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(738, 40)
        Me.GroupBox8.TabIndex = 72
        Me.GroupBox8.TabStop = False
        '
        'rbdZonaEconomica
        '
        Me.rbdZonaEconomica.AutoSize = True
        Me.rbdZonaEconomica.Checked = True
        Me.rbdZonaEconomica.Location = New System.Drawing.Point(184, 15)
        Me.rbdZonaEconomica.Name = "rbdZonaEconomica"
        Me.rbdZonaEconomica.Size = New System.Drawing.Size(105, 17)
        Me.rbdZonaEconomica.TabIndex = 326
        Me.rbdZonaEconomica.TabStop = True
        Me.rbdZonaEconomica.Text = "Zona económica"
        Me.rbdZonaEconomica.UseVisualStyleBackColor = True
        '
        'rbdZonaFisica
        '
        Me.rbdZonaFisica.AutoSize = True
        Me.rbdZonaFisica.Location = New System.Drawing.Point(313, 15)
        Me.rbdZonaFisica.Name = "rbdZonaFisica"
        Me.rbdZonaFisica.Size = New System.Drawing.Size(79, 17)
        Me.rbdZonaFisica.TabIndex = 325
        Me.rbdZonaFisica.Text = "Zona física"
        Me.rbdZonaFisica.UseVisualStyleBackColor = True
        '
        'frm_Historico_Sujeto_Impuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 630)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.fraFICHPRED)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_Historico_Sujeto_Impuesto"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "HISTORICO SUJETO IMPUESTO"
        Me.GroupBox2.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.fraFICHPRED.ResumeLayout(False)
        Me.fraFICHPRED.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLIMPIAR As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents pbPROCESO As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdLIQUIDAR As System.Windows.Forms.Button
    Friend WithEvents fraFICHPRED As System.Windows.Forms.GroupBox
    Friend WithEvents lblFIPRCLSE As System.Windows.Forms.Label
    Friend WithEvents cboFIPRCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblFIPRVIGE As System.Windows.Forms.Label
    Friend WithEvents cboFIPRVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFIPRFIFI As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFIPRFIIN As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtFIPRCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRMUNI As System.Windows.Forms.TextBox
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
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents rbdSUIMVIAN As System.Windows.Forms.RadioButton
    Friend WithEvents rbdSUIMVIAC As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdRemplazarTodosLosPredios As System.Windows.Forms.RadioButton
    Friend WithEvents rbdInscribirSoloPrediosNuevos As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chkAforoImpuesto As System.Windows.Forms.CheckBox
    Friend WithEvents chkHistoricoLiquidacion As System.Windows.Forms.CheckBox
    Friend WithEvents chkHistoricoAvaluo As System.Windows.Forms.CheckBox
    Friend WithEvents chkHistoricoZonas As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents chkLiquidaIncrementoIdentificador As System.Windows.Forms.CheckBox
    Friend WithEvents chkLiquidaIncrementoZona As System.Windows.Forms.CheckBox
    Friend WithEvents lblAFSICONC As System.Windows.Forms.Label
    Friend WithEvents cboAFSICONC As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblAFSITIIM As System.Windows.Forms.Label
    Friend WithEvents cboAFSITIIM As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdAplicarTarifaPorZonaAlLote As System.Windows.Forms.RadioButton
    Friend WithEvents rbdAplicarTarifaUnicaAlLote As System.Windows.Forms.RadioButton
    Friend WithEvents chkAplicarPorcentajeMaximoDeLiquidacion As System.Windows.Forms.CheckBox
    Friend WithEvents rbdZonaEconomica As System.Windows.Forms.RadioButton
    Friend WithEvents rbdZonaFisica As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
End Class
