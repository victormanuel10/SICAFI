<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_Estadisticas_Ficha_Predial
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporte_Estadisticas_Ficha_Predial))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtSEPARADOR = New System.Windows.Forms.TextBox()
        Me.cmdExportarPlano = New System.Windows.Forms.Button()
        Me.cmdExportarExcel = New System.Windows.Forms.Button()
        Me.btnPageSetup = New System.Windows.Forms.Button()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.cmdIMPRIMIR = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTotalPorcentaje = New System.Windows.Forms.Label()
        Me.lblTotalRegistros = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvFIPRESTA = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtFIPRESTADISTICO = New System.Windows.Forms.TextBox()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdGrafico = New System.Windows.Forms.Button()
        Me.cboTIPOREPO = New System.Windows.Forms.ComboBox()
        Me.cmdGENERAR = New System.Windows.Forms.Button()
        Me.cmdLIMPIAR = New System.Windows.Forms.Button()
        Me.fraFICHPRED = New System.Windows.Forms.GroupBox()
        Me.txtFIPRESTA = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFIPRTIFI = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFIPRFIFI = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFIPRCLSE = New System.Windows.Forms.TextBox()
        Me.txtFIPRFIIN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtFIPRCORR = New System.Windows.Forms.TextBox()
        Me.txtFIPRMUNI = New System.Windows.Forms.TextBox()
        Me.lblClaseOSector2 = New System.Windows.Forms.Label()
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
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvFIPRESTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.fraFICHPRED.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.txtSEPARADOR)
        Me.GroupBox2.Controls.Add(Me.cmdExportarPlano)
        Me.GroupBox2.Controls.Add(Me.cmdExportarExcel)
        Me.GroupBox2.Controls.Add(Me.btnPageSetup)
        Me.GroupBox2.Controls.Add(Me.btnPrintPreview)
        Me.GroupBox2.Controls.Add(Me.cmdIMPRIMIR)
        Me.GroupBox2.Controls.Add(Me.cmdSALIR)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(21, 510)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(829, 47)
        Me.GroupBox2.TabIndex = 49
        Me.GroupBox2.TabStop = False
        '
        'txtSEPARADOR
        '
        Me.txtSEPARADOR.Location = New System.Drawing.Point(664, 17)
        Me.txtSEPARADOR.MaxLength = 1
        Me.txtSEPARADOR.Name = "txtSEPARADOR"
        Me.txtSEPARADOR.Size = New System.Drawing.Size(19, 20)
        Me.txtSEPARADOR.TabIndex = 19
        Me.txtSEPARADOR.Text = "|"
        Me.txtSEPARADOR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdExportarPlano
        '
        Me.cmdExportarPlano.AccessibleDescription = "Exportar plano"
        Me.cmdExportarPlano.AccessibleName = ""
        Me.cmdExportarPlano.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExportarPlano.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExportarPlano.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExportarPlano.Image = Global.SICAFI.My.Resources.Resources._71
        Me.cmdExportarPlano.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExportarPlano.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdExportarPlano.Location = New System.Drawing.Point(535, 15)
        Me.cmdExportarPlano.Name = "cmdExportarPlano"
        Me.cmdExportarPlano.Size = New System.Drawing.Size(123, 23)
        Me.cmdExportarPlano.TabIndex = 18
        Me.cmdExportarPlano.Text = "&Exportar plano"
        Me.cmdExportarPlano.UseVisualStyleBackColor = False
        '
        'cmdExportarExcel
        '
        Me.cmdExportarExcel.AccessibleDescription = "Exportar Excel"
        Me.cmdExportarExcel.AccessibleName = ""
        Me.cmdExportarExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExportarExcel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExportarExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExportarExcel.Image = Global.SICAFI.My.Resources.Resources._041
        Me.cmdExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdExportarExcel.Location = New System.Drawing.Point(406, 15)
        Me.cmdExportarExcel.Name = "cmdExportarExcel"
        Me.cmdExportarExcel.Size = New System.Drawing.Size(123, 23)
        Me.cmdExportarExcel.TabIndex = 17
        Me.cmdExportarExcel.Text = "&Exportar excel"
        Me.cmdExportarExcel.UseVisualStyleBackColor = False
        '
        'btnPageSetup
        '
        Me.btnPageSetup.AccessibleDescription = "Configurar"
        Me.btnPageSetup.AccessibleName = "Page Setup button"
        Me.btnPageSetup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPageSetup.BackColor = System.Drawing.SystemColors.Control
        Me.btnPageSetup.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPageSetup.Image = Global.SICAFI.My.Resources.Resources._187
        Me.btnPageSetup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPageSetup.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPageSetup.Location = New System.Drawing.Point(277, 15)
        Me.btnPageSetup.Name = "btnPageSetup"
        Me.btnPageSetup.Size = New System.Drawing.Size(123, 23)
        Me.btnPageSetup.TabIndex = 16
        Me.btnPageSetup.Text = "&Configurar"
        Me.btnPageSetup.UseVisualStyleBackColor = False
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.AccessibleDescription = "Vista previa"
        Me.btnPrintPreview.AccessibleName = "Print Preview button"
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.BackColor = System.Drawing.SystemColors.Control
        Me.btnPrintPreview.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPrintPreview.Image = Global.SICAFI.My.Resources.Resources._047
        Me.btnPrintPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintPreview.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPrintPreview.Location = New System.Drawing.Point(148, 15)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(123, 23)
        Me.btnPrintPreview.TabIndex = 15
        Me.btnPrintPreview.Text = "&Vista Previa"
        Me.btnPrintPreview.UseVisualStyleBackColor = False
        '
        'cmdIMPRIMIR
        '
        Me.cmdIMPRIMIR.AccessibleDescription = "Imprimir"
        Me.cmdIMPRIMIR.Image = Global.SICAFI.My.Resources.Resources._004
        Me.cmdIMPRIMIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdIMPRIMIR.Location = New System.Drawing.Point(19, 15)
        Me.cmdIMPRIMIR.Name = "cmdIMPRIMIR"
        Me.cmdIMPRIMIR.Size = New System.Drawing.Size(123, 23)
        Me.cmdIMPRIMIR.TabIndex = 14
        Me.cmdIMPRIMIR.Text = "&Imprimir"
        Me.cmdIMPRIMIR.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(689, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(123, 23)
        Me.cmdSALIR.TabIndex = 20
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblTotalPorcentaje)
        Me.GroupBox1.Controls.Add(Me.lblTotalRegistros)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(21, 230)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(829, 274)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ESTADISTICAS"
        '
        'lblTotalPorcentaje
        '
        Me.lblTotalPorcentaje.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalPorcentaje.BackColor = System.Drawing.Color.White
        Me.lblTotalPorcentaje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalPorcentaje.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPorcentaje.ForeColor = System.Drawing.Color.Black
        Me.lblTotalPorcentaje.Location = New System.Drawing.Point(286, 240)
        Me.lblTotalPorcentaje.Name = "lblTotalPorcentaje"
        Me.lblTotalPorcentaje.Size = New System.Drawing.Size(85, 20)
        Me.lblTotalPorcentaje.TabIndex = 33
        Me.lblTotalPorcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalRegistros
        '
        Me.lblTotalRegistros.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalRegistros.BackColor = System.Drawing.Color.White
        Me.lblTotalRegistros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalRegistros.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblTotalRegistros.Location = New System.Drawing.Point(109, 240)
        Me.lblTotalRegistros.Name = "lblTotalRegistros"
        Me.lblTotalRegistros.Size = New System.Drawing.Size(85, 20)
        Me.lblTotalRegistros.TabIndex = 32
        Me.lblTotalRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(198, 240)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 20)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Total porc(%):"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 240)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 20)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Total registros:"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(19, 19)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(792, 212)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvFIPRESTA)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(784, 186)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Vista en celdas"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvFIPRESTA
        '
        Me.dgvFIPRESTA.AccessibleDescription = "Estadisticas"
        Me.dgvFIPRESTA.AllowUserToAddRows = False
        Me.dgvFIPRESTA.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvFIPRESTA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFIPRESTA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFIPRESTA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvFIPRESTA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvFIPRESTA.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvFIPRESTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvFIPRESTA.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvFIPRESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvFIPRESTA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvFIPRESTA.Location = New System.Drawing.Point(6, 6)
        Me.dgvFIPRESTA.Name = "dgvFIPRESTA"
        Me.dgvFIPRESTA.ReadOnly = True
        Me.dgvFIPRESTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvFIPRESTA.ShowCellToolTips = False
        Me.dgvFIPRESTA.Size = New System.Drawing.Size(772, 174)
        Me.dgvFIPRESTA.StandardTab = True
        Me.dgvFIPRESTA.TabIndex = 323
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtFIPRESTADISTICO)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(784, 186)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Vista en texto"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtFIPRESTADISTICO
        '
        Me.txtFIPRESTADISTICO.AccessibleDescription = "Estadisticas"
        Me.txtFIPRESTADISTICO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFIPRESTADISTICO.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRESTADISTICO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRESTADISTICO.Location = New System.Drawing.Point(6, 6)
        Me.txtFIPRESTADISTICO.Multiline = True
        Me.txtFIPRESTADISTICO.Name = "txtFIPRESTADISTICO"
        Me.txtFIPRESTADISTICO.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtFIPRESTADISTICO.Size = New System.Drawing.Size(772, 201)
        Me.txtFIPRESTADISTICO.TabIndex = 4
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 569)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(867, 25)
        Me.strBARRESTA.TabIndex = 47
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
        Me.GroupBox3.Controls.Add(Me.cmdGrafico)
        Me.GroupBox3.Controls.Add(Me.cboTIPOREPO)
        Me.GroupBox3.Controls.Add(Me.cmdGENERAR)
        Me.GroupBox3.Controls.Add(Me.cmdLIMPIAR)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(21, 177)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(829, 47)
        Me.GroupBox3.TabIndex = 46
        Me.GroupBox3.TabStop = False
        '
        'cmdGrafico
        '
        Me.cmdGrafico.AccessibleDescription = "Grafico"
        Me.cmdGrafico.Enabled = False
        Me.cmdGrafico.Image = Global.SICAFI.My.Resources.Resources._1104
        Me.cmdGrafico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGrafico.Location = New System.Drawing.Point(148, 15)
        Me.cmdGrafico.Name = "cmdGrafico"
        Me.cmdGrafico.Size = New System.Drawing.Size(123, 23)
        Me.cmdGrafico.TabIndex = 15
        Me.cmdGrafico.Text = "&Gráfico"
        Me.cmdGrafico.UseVisualStyleBackColor = True
        '
        'cboTIPOREPO
        '
        Me.cboTIPOREPO.AccessibleDescription = "Tipo de reporte"
        Me.cboTIPOREPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTIPOREPO.FormattingEnabled = True
        Me.cboTIPOREPO.Items.AddRange(New Object() {"01. Reporte por Destinación Económica", "02. Reporte por Tipo de Documento", "03. Reporte por Identificador de Construcción", "04. Reporte por Zonas Económicas", "05. Reporte por Zonas Físicas", "06. Reporte por Modo de Adquisición", "07. Reporte por Caracteristica de Predio", "08. Reporte por Clase o Sector", "09. Reporte por Area de Terreno", "10. Reporte por Area de Construccion", "11. Reporte por Puntos de Calificacion", "12. Reporte de predios con porcentaje de destinación maximo ", "13. Reporte de predios con área construida valorable maxima", "14. Reporte por Calidad de Propietario", "15. Reporte de avalúo por Identificador", "16. Reporte de avalúo por Zona Económica", "17. Reporte de avalúo por Destinación Económica", "18. Reporte de avalúo por Calidad de Propietario", "19. Reporte de avalúo Totales", "20. Reporte de Ficha Predial", "21. Reporte de predios con tomo diferente de cero", "22. Reporte de predios que faltan por levantar en trabajo de campo", "23. Reporte de predio que no son mejoras", "24. Reporte de predio que son mejoras", "25. Reporte de estratificacion", "26. Reporte de registro y control", "27. Reporte cantidad de predios por barrio ", "28. Reporte cantidad de predios por barrio por usuario", "29. Reporte cantidad de predios por barrio y manzana", "30. Reporte cantidad de predios por barrio y manzana por usuario", "31. Reporte cantidad de viviendas por barrio", "32. Reporte cantidad de viviendas por barrio y manzana", "33. Reporte de Ficha Resumen", "34. Reporte Cantidad de predios - mejoras - unidades en RPH"})
        Me.cboTIPOREPO.Location = New System.Drawing.Point(418, 17)
        Me.cboTIPOREPO.MaxDropDownItems = 15
        Me.cboTIPOREPO.Name = "cboTIPOREPO"
        Me.cboTIPOREPO.Size = New System.Drawing.Size(394, 21)
        Me.cboTIPOREPO.TabIndex = 14
        '
        'cmdGENERAR
        '
        Me.cmdGENERAR.AccessibleDescription = "Generar"
        Me.cmdGENERAR.Image = Global.SICAFI.My.Resources.Resources._1172
        Me.cmdGENERAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGENERAR.Location = New System.Drawing.Point(19, 15)
        Me.cmdGENERAR.Name = "cmdGENERAR"
        Me.cmdGENERAR.Size = New System.Drawing.Size(123, 23)
        Me.cmdGENERAR.TabIndex = 12
        Me.cmdGENERAR.Text = "&Generar"
        Me.cmdGENERAR.UseVisualStyleBackColor = True
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
        Me.cmdLIMPIAR.TabIndex = 13
        Me.cmdLIMPIAR.Text = "&Limpiar campos"
        Me.cmdLIMPIAR.UseVisualStyleBackColor = True
        '
        'fraFICHPRED
        '
        Me.fraFICHPRED.BackColor = System.Drawing.SystemColors.Control
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRESTA)
        Me.fraFICHPRED.Controls.Add(Me.Label7)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRTIFI)
        Me.fraFICHPRED.Controls.Add(Me.Label4)
        Me.fraFICHPRED.Controls.Add(Me.Label2)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRFIFI)
        Me.fraFICHPRED.Controls.Add(Me.Label3)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRCLSE)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRFIIN)
        Me.fraFICHPRED.Controls.Add(Me.Label1)
        Me.fraFICHPRED.Controls.Add(Me.Label33)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRCORR)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRMUNI)
        Me.fraFICHPRED.Controls.Add(Me.lblClaseOSector2)
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
        Me.fraFICHPRED.Location = New System.Drawing.Point(21, 12)
        Me.fraFICHPRED.Name = "fraFICHPRED"
        Me.fraFICHPRED.Size = New System.Drawing.Size(829, 159)
        Me.fraFICHPRED.TabIndex = 45
        Me.fraFICHPRED.TabStop = False
        Me.fraFICHPRED.Text = "DATOS FICHA PREDIAL "
        '
        'txtFIPRESTA
        '
        Me.txtFIPRESTA.AccessibleDescription = "Estado"
        Me.txtFIPRESTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRESTA.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRESTA.Location = New System.Drawing.Point(637, 51)
        Me.txtFIPRESTA.MaxLength = 10
        Me.txtFIPRESTA.Name = "txtFIPRESTA"
        Me.txtFIPRESTA.Size = New System.Drawing.Size(174, 20)
        Me.txtFIPRESTA.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(550, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 20)
        Me.Label7.TabIndex = 318
        Me.Label7.Text = "Estado"
        '
        'txtFIPRTIFI
        '
        Me.txtFIPRTIFI.AccessibleDescription = "Tipo de ficha"
        Me.txtFIPRTIFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRTIFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRTIFI.Location = New System.Drawing.Point(462, 51)
        Me.txtFIPRTIFI.MaxLength = 8
        Me.txtFIPRTIFI.Name = "txtFIPRTIFI"
        Me.txtFIPRTIFI.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRTIFI.TabIndex = 3
        Me.txtFIPRTIFI.Text = "0"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(374, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 20)
        Me.Label4.TabIndex = 317
        Me.Label4.Text = "Tipo ficha"
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
        Me.txtFIPRFIFI.Location = New System.Drawing.Point(286, 51)
        Me.txtFIPRFIFI.MaxLength = 9
        Me.txtFIPRFIFI.Name = "txtFIPRFIFI"
        Me.txtFIPRFIFI.Size = New System.Drawing.Size(84, 20)
        Me.txtFIPRFIFI.TabIndex = 2
        Me.txtFIPRFIFI.Text = "999999999"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(198, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 313
        Me.Label3.Text = "Rango final"
        '
        'txtFIPRCLSE
        '
        Me.txtFIPRCLSE.AccessibleDescription = "Clase o sector"
        Me.txtFIPRCLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRCLSE.Location = New System.Drawing.Point(726, 120)
        Me.txtFIPRCLSE.MaxLength = 10
        Me.txtFIPRCLSE.Name = "txtFIPRCLSE"
        Me.txtFIPRCLSE.Size = New System.Drawing.Size(86, 20)
        Me.txtFIPRCLSE.TabIndex = 11
        '
        'txtFIPRFIIN
        '
        Me.txtFIPRFIIN.AccessibleDescription = "Ficha inicial"
        Me.txtFIPRFIIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRFIIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRFIIN.Location = New System.Drawing.Point(109, 51)
        Me.txtFIPRFIIN.MaxLength = 9
        Me.txtFIPRFIIN.Name = "txtFIPRFIIN"
        Me.txtFIPRFIIN.Size = New System.Drawing.Size(86, 20)
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
        Me.Label1.Size = New System.Drawing.Size(792, 20)
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
        Me.Label33.Size = New System.Drawing.Size(792, 20)
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
        'lblClaseOSector2
        '
        Me.lblClaseOSector2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseOSector2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseOSector2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseOSector2.ForeColor = System.Drawing.Color.Black
        Me.lblClaseOSector2.Location = New System.Drawing.Point(726, 97)
        Me.lblClaseOSector2.Name = "lblClaseOSector2"
        Me.lblClaseOSector2.Size = New System.Drawing.Size(85, 20)
        Me.lblClaseOSector2.TabIndex = 45
        Me.lblClaseOSector2.Text = "Clase o Sector"
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
        Me.txtFIPRUNPR.Size = New System.Drawing.Size(85, 20)
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
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDocument1
        '
        '
        'frm_reporte_Estadisticas_Ficha_Predial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(867, 594)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.fraFICHPRED)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_reporte_Estadisticas_Ficha_Predial"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ESTADISTICAS FICHA PREDIAL"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvFIPRESTA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.fraFICHPRED.ResumeLayout(False)
        Me.fraFICHPRED.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPageSetup As System.Windows.Forms.Button
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button
    Friend WithEvents cmdIMPRIMIR As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFIPRESTADISTICO As System.Windows.Forms.TextBox
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGENERAR As System.Windows.Forms.Button
    Friend WithEvents cmdLIMPIAR As System.Windows.Forms.Button
    Friend WithEvents fraFICHPRED As System.Windows.Forms.GroupBox
    Friend WithEvents txtFIPRTIFI As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFIPRFIFI As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFIPRCLSE As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRFIIN As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtFIPRCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRMUNI As System.Windows.Forms.TextBox
    Friend WithEvents lblClaseOSector2 As System.Windows.Forms.Label
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
    Friend WithEvents cboTIPOREPO As System.Windows.Forms.ComboBox
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents txtSEPARADOR As System.Windows.Forms.TextBox
    Friend WithEvents cmdExportarPlano As System.Windows.Forms.Button
    Friend WithEvents cmdExportarExcel As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvFIPRESTA As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPorcentaje As System.Windows.Forms.Label
    Friend WithEvents lblTotalRegistros As System.Windows.Forms.Label
    Friend WithEvents cmdGrafico As System.Windows.Forms.Button
    Friend WithEvents txtFIPRESTA As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
