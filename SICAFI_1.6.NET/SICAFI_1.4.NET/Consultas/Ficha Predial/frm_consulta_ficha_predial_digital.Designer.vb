<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_ficha_predial_digital
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consulta_ficha_predial_digital))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdVisualizarFicha = New System.Windows.Forms.Button()
        Me.cmdULTIMACONSULTA = New System.Windows.Forms.Button()
        Me.cmdLIMPIAR = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.axaPlanoPredio = New AxAcroPDFLib.AxAcroPDF()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdVistaPredio = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvCONSULTA = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabCedulaCatastral = New System.Windows.Forms.TabPage()
        Me.txtFIPRCLSE = New System.Windows.Forms.TextBox()
        Me.fraFICHPRED = New System.Windows.Forms.GroupBox()
        Me.rbdReporteFichaResumen = New System.Windows.Forms.RadioButton()
        Me.cmdConsultaCedulaCatastral = New System.Windows.Forms.Button()
        Me.rbdReporteFichaPredial = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFIPRNUFI = New System.Windows.Forms.TextBox()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.txtFIPRDIRE = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtFIPRCORR = New System.Windows.Forms.TextBox()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.txtFIPRMUNI = New System.Windows.Forms.TextBox()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblClaseOSector2 = New System.Windows.Forms.Label()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.txtFIPRUNPR = New System.Windows.Forms.TextBox()
        Me.lblManzana = New System.Windows.Forms.Label()
        Me.txtFIPREDIF = New System.Windows.Forms.TextBox()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.txtFIPRPRED = New System.Windows.Forms.TextBox()
        Me.lblEdificio = New System.Windows.Forms.Label()
        Me.txtFIPRMANZ = New System.Windows.Forms.TextBox()
        Me.lblUnidadPredial = New System.Windows.Forms.Label()
        Me.txtFIPRBARR = New System.Windows.Forms.TextBox()
        Me.lblCodigoActual = New System.Windows.Forms.Label()
        Me.TabCedulaDeCiudadania = New System.Windows.Forms.TabPage()
        Me.lblFPPRNUDO = New System.Windows.Forms.Label()
        Me.txtFPPRNUDO = New System.Windows.Forms.TextBox()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.cmdConsultarCedulaDeCiudadania = New System.Windows.Forms.Button()
        Me.TabMatriculaInmobiliaria = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFPPRMAIN = New System.Windows.Forms.TextBox()
        Me.lblFPPRMAIN = New System.Windows.Forms.Label()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.cmdConsultarMatriculaInmobiliaria = New System.Windows.Forms.Button()
        Me.chkGenerarCroquis = New System.Windows.Forms.CheckBox()
        Me.GroupBox3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.axaPlanoPredio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabCedulaCatastral.SuspendLayout()
        Me.fraFICHPRED.SuspendLayout()
        Me.TabCedulaDeCiudadania.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.TabMatriculaInmobiliaria.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdVisualizarFicha)
        Me.GroupBox3.Controls.Add(Me.cmdULTIMACONSULTA)
        Me.GroupBox3.Controls.Add(Me.cmdLIMPIAR)
        Me.GroupBox3.Controls.Add(Me.cmdSALIR)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(16, 248)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(864, 47)
        Me.GroupBox3.TabIndex = 58
        Me.GroupBox3.TabStop = False
        '
        'cmdVisualizarFicha
        '
        Me.cmdVisualizarFicha.AccessibleDescription = "Visualizar ficha"
        Me.cmdVisualizarFicha.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdVisualizarFicha.Image = Global.SICAFI.My.Resources.Resources._047
        Me.cmdVisualizarFicha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdVisualizarFicha.Location = New System.Drawing.Point(31, 15)
        Me.cmdVisualizarFicha.Name = "cmdVisualizarFicha"
        Me.cmdVisualizarFicha.Size = New System.Drawing.Size(135, 23)
        Me.cmdVisualizarFicha.TabIndex = 25
        Me.cmdVisualizarFicha.Text = "&Visualizar Ficha"
        Me.cmdVisualizarFicha.UseVisualStyleBackColor = True
        '
        'cmdULTIMACONSULTA
        '
        Me.cmdULTIMACONSULTA.AccessibleDescription = "Ultima consulta"
        Me.cmdULTIMACONSULTA.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdULTIMACONSULTA.Image = Global.SICAFI.My.Resources.Resources._667
        Me.cmdULTIMACONSULTA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdULTIMACONSULTA.Location = New System.Drawing.Point(172, 15)
        Me.cmdULTIMACONSULTA.Name = "cmdULTIMACONSULTA"
        Me.cmdULTIMACONSULTA.Size = New System.Drawing.Size(135, 23)
        Me.cmdULTIMACONSULTA.TabIndex = 19
        Me.cmdULTIMACONSULTA.Text = "&Ultima Consulta"
        Me.cmdULTIMACONSULTA.UseVisualStyleBackColor = True
        '
        'cmdLIMPIAR
        '
        Me.cmdLIMPIAR.AccessibleDescription = "Limpiar campo"
        Me.cmdLIMPIAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLIMPIAR.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLIMPIAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLIMPIAR.Location = New System.Drawing.Point(313, 15)
        Me.cmdLIMPIAR.Name = "cmdLIMPIAR"
        Me.cmdLIMPIAR.Size = New System.Drawing.Size(135, 23)
        Me.cmdLIMPIAR.TabIndex = 20
        Me.cmdLIMPIAR.Text = "&Limpiar Campos"
        Me.cmdLIMPIAR.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Cancelar"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(710, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(135, 23)
        Me.cmdSALIR.TabIndex = 24
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(15, 432)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(865, 243)
        Me.TabControl1.TabIndex = 63
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.GroupBox10)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(857, 215)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Ficha Predial Catastral"
        '
        'GroupBox10
        '
        Me.GroupBox10.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox10.Controls.Add(Me.axaPlanoPredio)
        Me.GroupBox10.Location = New System.Drawing.Point(11, 6)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(636, 203)
        Me.GroupBox10.TabIndex = 7
        Me.GroupBox10.TabStop = False
        '
        'axaPlanoPredio
        '
        Me.axaPlanoPredio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.axaPlanoPredio.Enabled = True
        Me.axaPlanoPredio.Location = New System.Drawing.Point(3, 17)
        Me.axaPlanoPredio.Name = "axaPlanoPredio"
        Me.axaPlanoPredio.OcxState = CType(resources.GetObject("axaPlanoPredio.OcxState"), System.Windows.Forms.AxHost.State)
        Me.axaPlanoPredio.Size = New System.Drawing.Size(627, 192)
        Me.axaPlanoPredio.TabIndex = 5
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Controls.Add(Me.cmdVistaPredio)
        Me.GroupBox4.Location = New System.Drawing.Point(650, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(196, 54)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        '
        'cmdVistaPredio
        '
        Me.cmdVistaPredio.AccessibleDescription = "Vista predio"
        Me.cmdVistaPredio.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdVistaPredio.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdVistaPredio.Image = Global.SICAFI.My.Resources.Resources._047
        Me.cmdVistaPredio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdVistaPredio.Location = New System.Drawing.Point(18, 16)
        Me.cmdVistaPredio.Name = "cmdVistaPredio"
        Me.cmdVistaPredio.Size = New System.Drawing.Size(164, 23)
        Me.cmdVistaPredio.TabIndex = 429
        Me.cmdVistaPredio.Text = "Pantalla completa"
        Me.cmdVistaPredio.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 694)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(895, 25)
        Me.strBARRESTA.TabIndex = 61
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
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.dgvCONSULTA)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(15, 301)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(865, 125)
        Me.GroupBox2.TabIndex = 59
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CEDULA CATASTRAL"
        '
        'dgvCONSULTA
        '
        Me.dgvCONSULTA.AccessibleDescription = "Consulta predio"
        Me.dgvCONSULTA.AllowUserToAddRows = False
        Me.dgvCONSULTA.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCONSULTA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCONSULTA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
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
        Me.dgvCONSULTA.Size = New System.Drawing.Size(830, 87)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TabControl2)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(15, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(865, 238)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PARAMETRO DE CONSULTA"
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabCedulaCatastral)
        Me.TabControl2.Controls.Add(Me.TabCedulaDeCiudadania)
        Me.TabControl2.Controls.Add(Me.TabMatriculaInmobiliaria)
        Me.TabControl2.Location = New System.Drawing.Point(15, 19)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(835, 200)
        Me.TabControl2.TabIndex = 3
        '
        'TabCedulaCatastral
        '
        Me.TabCedulaCatastral.BackColor = System.Drawing.SystemColors.Control
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPRCLSE)
        Me.TabCedulaCatastral.Controls.Add(Me.fraFICHPRED)
        Me.TabCedulaCatastral.Controls.Add(Me.Label1)
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPRNUFI)
        Me.TabCedulaCatastral.Controls.Add(Me.lblDireccion)
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPRDIRE)
        Me.TabCedulaCatastral.Controls.Add(Me.Label33)
        Me.TabCedulaCatastral.Controls.Add(Me.lblCodigo)
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPRCORR)
        Me.TabCedulaCatastral.Controls.Add(Me.lblMunicipio)
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPRMUNI)
        Me.TabCedulaCatastral.Controls.Add(Me.lblCorregimiento)
        Me.TabCedulaCatastral.Controls.Add(Me.lblClaseOSector2)
        Me.TabCedulaCatastral.Controls.Add(Me.lblBarrio)
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPRUNPR)
        Me.TabCedulaCatastral.Controls.Add(Me.lblManzana)
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPREDIF)
        Me.TabCedulaCatastral.Controls.Add(Me.lblPredio)
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPRPRED)
        Me.TabCedulaCatastral.Controls.Add(Me.lblEdificio)
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPRMANZ)
        Me.TabCedulaCatastral.Controls.Add(Me.lblUnidadPredial)
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPRBARR)
        Me.TabCedulaCatastral.Controls.Add(Me.lblCodigoActual)
        Me.TabCedulaCatastral.Location = New System.Drawing.Point(4, 22)
        Me.TabCedulaCatastral.Name = "TabCedulaCatastral"
        Me.TabCedulaCatastral.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCedulaCatastral.Size = New System.Drawing.Size(827, 174)
        Me.TabCedulaCatastral.TabIndex = 0
        Me.TabCedulaCatastral.Text = "Cedula catastral"
        '
        'txtFIPRCLSE
        '
        Me.txtFIPRCLSE.AccessibleDescription = "Clase o sector"
        Me.txtFIPRCLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRCLSE.Location = New System.Drawing.Point(719, 79)
        Me.txtFIPRCLSE.MaxLength = 10
        Me.txtFIPRCLSE.Name = "txtFIPRCLSE"
        Me.txtFIPRCLSE.Size = New System.Drawing.Size(95, 20)
        Me.txtFIPRCLSE.TabIndex = 14
        '
        'fraFICHPRED
        '
        Me.fraFICHPRED.BackColor = System.Drawing.SystemColors.Control
        Me.fraFICHPRED.Controls.Add(Me.chkGenerarCroquis)
        Me.fraFICHPRED.Controls.Add(Me.rbdReporteFichaResumen)
        Me.fraFICHPRED.Controls.Add(Me.cmdConsultaCedulaCatastral)
        Me.fraFICHPRED.Controls.Add(Me.rbdReporteFichaPredial)
        Me.fraFICHPRED.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraFICHPRED.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraFICHPRED.Location = New System.Drawing.Point(13, 105)
        Me.fraFICHPRED.Name = "fraFICHPRED"
        Me.fraFICHPRED.Size = New System.Drawing.Size(801, 58)
        Me.fraFICHPRED.TabIndex = 2
        Me.fraFICHPRED.TabStop = False
        '
        'rbdReporteFichaResumen
        '
        Me.rbdReporteFichaResumen.Location = New System.Drawing.Point(427, 20)
        Me.rbdReporteFichaResumen.Name = "rbdReporteFichaResumen"
        Me.rbdReporteFichaResumen.Size = New System.Drawing.Size(169, 17)
        Me.rbdReporteFichaResumen.TabIndex = 20
        Me.rbdReporteFichaResumen.Text = "Reporte ficha resumen"
        Me.rbdReporteFichaResumen.UseVisualStyleBackColor = True
        '
        'cmdConsultaCedulaCatastral
        '
        Me.cmdConsultaCedulaCatastral.AccessibleDescription = "Consultar"
        Me.cmdConsultaCedulaCatastral.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdConsultaCedulaCatastral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdConsultaCedulaCatastral.Location = New System.Drawing.Point(21, 20)
        Me.cmdConsultaCedulaCatastral.Name = "cmdConsultaCedulaCatastral"
        Me.cmdConsultaCedulaCatastral.Size = New System.Drawing.Size(207, 23)
        Me.cmdConsultaCedulaCatastral.TabIndex = 18
        Me.cmdConsultaCedulaCatastral.Text = "&Consultar"
        Me.cmdConsultaCedulaCatastral.UseVisualStyleBackColor = True
        '
        'rbdReporteFichaPredial
        '
        Me.rbdReporteFichaPredial.Checked = True
        Me.rbdReporteFichaPredial.Location = New System.Drawing.Point(263, 20)
        Me.rbdReporteFichaPredial.Name = "rbdReporteFichaPredial"
        Me.rbdReporteFichaPredial.Size = New System.Drawing.Size(157, 17)
        Me.rbdReporteFichaPredial.TabIndex = 19
        Me.rbdReporteFichaPredial.TabStop = True
        Me.rbdReporteFichaPredial.Text = "Reporte ficha predial"
        Me.rbdReporteFichaPredial.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(13, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 20)
        Me.Label1.TabIndex = 288
        Me.Label1.Text = "Nro. FICHA"
        '
        'txtFIPRNUFI
        '
        Me.txtFIPRNUFI.AccessibleDescription = "Nro. Ficha predial"
        Me.txtFIPRNUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRNUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRNUFI.Location = New System.Drawing.Point(102, 10)
        Me.txtFIPRNUFI.MaxLength = 9
        Me.txtFIPRNUFI.Name = "txtFIPRNUFI"
        Me.txtFIPRNUFI.Size = New System.Drawing.Size(175, 20)
        Me.txtFIPRNUFI.TabIndex = 4
        '
        'lblDireccion
        '
        Me.lblDireccion.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblDireccion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDireccion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccion.ForeColor = System.Drawing.Color.Black
        Me.lblDireccion.Location = New System.Drawing.Point(280, 11)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(84, 20)
        Me.lblDireccion.TabIndex = 99
        Me.lblDireccion.Text = "Dirección"
        '
        'txtFIPRDIRE
        '
        Me.txtFIPRDIRE.AccessibleDescription = "Dirección "
        Me.txtFIPRDIRE.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRDIRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRDIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRDIRE.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRDIRE.Location = New System.Drawing.Point(368, 10)
        Me.txtFIPRDIRE.MaxLength = 49
        Me.txtFIPRDIRE.Name = "txtFIPRDIRE"
        Me.txtFIPRDIRE.Size = New System.Drawing.Size(447, 20)
        Me.txtFIPRDIRE.TabIndex = 5
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(13, 33)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(801, 20)
        Me.Label33.TabIndex = 278
        Me.Label33.Text = "CEDULA CATASTRAL ACTUAL"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(13, 56)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(85, 20)
        Me.lblCodigo.TabIndex = 300
        Me.lblCodigo.Text = "CODIGO"
        '
        'txtFIPRCORR
        '
        Me.txtFIPRCORR.AccessibleDescription = "Corregimiento"
        Me.txtFIPRCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRCORR.Location = New System.Drawing.Point(192, 79)
        Me.txtFIPRCORR.MaxLength = 10
        Me.txtFIPRCORR.Name = "txtFIPRCORR"
        Me.txtFIPRCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRCORR.TabIndex = 7
        '
        'lblMunicipio
        '
        Me.lblMunicipio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblMunicipio.Location = New System.Drawing.Point(102, 56)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(86, 20)
        Me.lblMunicipio.TabIndex = 300
        Me.lblMunicipio.Text = "Municipio"
        '
        'txtFIPRMUNI
        '
        Me.txtFIPRMUNI.AccessibleDescription = "Municipio"
        Me.txtFIPRMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMUNI.Location = New System.Drawing.Point(102, 79)
        Me.txtFIPRMUNI.MaxLength = 10
        Me.txtFIPRMUNI.Name = "txtFIPRMUNI"
        Me.txtFIPRMUNI.Size = New System.Drawing.Size(87, 20)
        Me.txtFIPRMUNI.TabIndex = 6
        '
        'lblCorregimiento
        '
        Me.lblCorregimiento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCorregimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorregimiento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorregimiento.ForeColor = System.Drawing.Color.Black
        Me.lblCorregimiento.Location = New System.Drawing.Point(192, 56)
        Me.lblCorregimiento.Name = "lblCorregimiento"
        Me.lblCorregimiento.Size = New System.Drawing.Size(84, 20)
        Me.lblCorregimiento.TabIndex = 30
        Me.lblCorregimiento.Text = "Corregimiento"
        '
        'lblClaseOSector2
        '
        Me.lblClaseOSector2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseOSector2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseOSector2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseOSector2.ForeColor = System.Drawing.Color.Black
        Me.lblClaseOSector2.Location = New System.Drawing.Point(719, 56)
        Me.lblClaseOSector2.Name = "lblClaseOSector2"
        Me.lblClaseOSector2.Size = New System.Drawing.Size(96, 20)
        Me.lblClaseOSector2.TabIndex = 45
        Me.lblClaseOSector2.Text = "Clase o Sector"
        '
        'lblBarrio
        '
        Me.lblBarrio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblBarrio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBarrio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarrio.ForeColor = System.Drawing.Color.Black
        Me.lblBarrio.Location = New System.Drawing.Point(280, 56)
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Size = New System.Drawing.Size(84, 20)
        Me.lblBarrio.TabIndex = 22
        Me.lblBarrio.Text = "Barrio"
        '
        'txtFIPRUNPR
        '
        Me.txtFIPRUNPR.AccessibleDescription = "Unidad predial "
        Me.txtFIPRUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRUNPR.Location = New System.Drawing.Point(632, 79)
        Me.txtFIPRUNPR.MaxLength = 10
        Me.txtFIPRUNPR.Name = "txtFIPRUNPR"
        Me.txtFIPRUNPR.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRUNPR.TabIndex = 12
        '
        'lblManzana
        '
        Me.lblManzana.AccessibleDescription = ""
        Me.lblManzana.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblManzana.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblManzana.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManzana.ForeColor = System.Drawing.Color.Black
        Me.lblManzana.Location = New System.Drawing.Point(368, 56)
        Me.lblManzana.Name = "lblManzana"
        Me.lblManzana.Size = New System.Drawing.Size(84, 20)
        Me.lblManzana.TabIndex = 23
        Me.lblManzana.Text = "Manza / Vered"
        '
        'txtFIPREDIF
        '
        Me.txtFIPREDIF.AccessibleDescription = "Edificio "
        Me.txtFIPREDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPREDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPREDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPREDIF.ForeColor = System.Drawing.Color.Black
        Me.txtFIPREDIF.Location = New System.Drawing.Point(544, 79)
        Me.txtFIPREDIF.MaxLength = 10
        Me.txtFIPREDIF.Name = "txtFIPREDIF"
        Me.txtFIPREDIF.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPREDIF.TabIndex = 11
        '
        'lblPredio
        '
        Me.lblPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredio.ForeColor = System.Drawing.Color.Black
        Me.lblPredio.Location = New System.Drawing.Point(456, 56)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(84, 20)
        Me.lblPredio.TabIndex = 24
        Me.lblPredio.Text = "Predio"
        '
        'txtFIPRPRED
        '
        Me.txtFIPRPRED.AccessibleDescription = "Predio "
        Me.txtFIPRPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRPRED.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRPRED.Location = New System.Drawing.Point(456, 79)
        Me.txtFIPRPRED.MaxLength = 10
        Me.txtFIPRPRED.Name = "txtFIPRPRED"
        Me.txtFIPRPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRPRED.TabIndex = 10
        '
        'lblEdificio
        '
        Me.lblEdificio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblEdificio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEdificio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdificio.ForeColor = System.Drawing.Color.Black
        Me.lblEdificio.Location = New System.Drawing.Point(544, 56)
        Me.lblEdificio.Name = "lblEdificio"
        Me.lblEdificio.Size = New System.Drawing.Size(84, 20)
        Me.lblEdificio.TabIndex = 25
        Me.lblEdificio.Text = "Edificio"
        '
        'txtFIPRMANZ
        '
        Me.txtFIPRMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtFIPRMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRMANZ.Location = New System.Drawing.Point(368, 79)
        Me.txtFIPRMANZ.MaxLength = 10
        Me.txtFIPRMANZ.Name = "txtFIPRMANZ"
        Me.txtFIPRMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRMANZ.TabIndex = 9
        '
        'lblUnidadPredial
        '
        Me.lblUnidadPredial.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblUnidadPredial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUnidadPredial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidadPredial.ForeColor = System.Drawing.Color.Black
        Me.lblUnidadPredial.Location = New System.Drawing.Point(632, 56)
        Me.lblUnidadPredial.Name = "lblUnidadPredial"
        Me.lblUnidadPredial.Size = New System.Drawing.Size(84, 20)
        Me.lblUnidadPredial.TabIndex = 26
        Me.lblUnidadPredial.Text = "Unidad Predial"
        '
        'txtFIPRBARR
        '
        Me.txtFIPRBARR.AccessibleDescription = "Barrio "
        Me.txtFIPRBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRBARR.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRBARR.Location = New System.Drawing.Point(280, 79)
        Me.txtFIPRBARR.MaxLength = 10
        Me.txtFIPRBARR.Name = "txtFIPRBARR"
        Me.txtFIPRBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRBARR.TabIndex = 8
        '
        'lblCodigoActual
        '
        Me.lblCodigoActual.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigoActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigoActual.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoActual.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoActual.Location = New System.Drawing.Point(13, 79)
        Me.lblCodigoActual.Name = "lblCodigoActual"
        Me.lblCodigoActual.Size = New System.Drawing.Size(85, 20)
        Me.lblCodigoActual.TabIndex = 27
        Me.lblCodigoActual.Text = "Código Actual"
        '
        'TabCedulaDeCiudadania
        '
        Me.TabCedulaDeCiudadania.BackColor = System.Drawing.SystemColors.Control
        Me.TabCedulaDeCiudadania.Controls.Add(Me.lblFPPRNUDO)
        Me.TabCedulaDeCiudadania.Controls.Add(Me.txtFPPRNUDO)
        Me.TabCedulaDeCiudadania.Controls.Add(Me.GroupBox15)
        Me.TabCedulaDeCiudadania.Location = New System.Drawing.Point(4, 22)
        Me.TabCedulaDeCiudadania.Name = "TabCedulaDeCiudadania"
        Me.TabCedulaDeCiudadania.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCedulaDeCiudadania.Size = New System.Drawing.Size(827, 174)
        Me.TabCedulaDeCiudadania.TabIndex = 1
        Me.TabCedulaDeCiudadania.Text = "Cedula de ciudadanía"
        '
        'lblFPPRNUDO
        '
        Me.lblFPPRNUDO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblFPPRNUDO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPPRNUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPPRNUDO.ForeColor = System.Drawing.Color.Black
        Me.lblFPPRNUDO.Location = New System.Drawing.Point(13, 13)
        Me.lblFPPRNUDO.Name = "lblFPPRNUDO"
        Me.lblFPPRNUDO.Size = New System.Drawing.Size(134, 20)
        Me.lblFPPRNUDO.TabIndex = 31
        Me.lblFPPRNUDO.Text = "Cedula de ciudadanía"
        '
        'txtFPPRNUDO
        '
        Me.txtFPPRNUDO.AccessibleDescription = "Nro. Documento"
        Me.txtFPPRNUDO.BackColor = System.Drawing.SystemColors.Window
        Me.txtFPPRNUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPPRNUDO.Location = New System.Drawing.Point(151, 13)
        Me.txtFPPRNUDO.MaxLength = 14
        Me.txtFPPRNUDO.Name = "txtFPPRNUDO"
        Me.txtFPPRNUDO.Size = New System.Drawing.Size(197, 20)
        Me.txtFPPRNUDO.TabIndex = 30
        '
        'GroupBox15
        '
        Me.GroupBox15.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox15.Controls.Add(Me.cmdConsultarCedulaDeCiudadania)
        Me.GroupBox15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox15.Location = New System.Drawing.Point(13, 105)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(801, 58)
        Me.GroupBox15.TabIndex = 3
        Me.GroupBox15.TabStop = False
        '
        'cmdConsultarCedulaDeCiudadania
        '
        Me.cmdConsultarCedulaDeCiudadania.AccessibleDescription = "Consultar"
        Me.cmdConsultarCedulaDeCiudadania.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdConsultarCedulaDeCiudadania.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdConsultarCedulaDeCiudadania.Location = New System.Drawing.Point(21, 20)
        Me.cmdConsultarCedulaDeCiudadania.Name = "cmdConsultarCedulaDeCiudadania"
        Me.cmdConsultarCedulaDeCiudadania.Size = New System.Drawing.Size(207, 23)
        Me.cmdConsultarCedulaDeCiudadania.TabIndex = 18
        Me.cmdConsultarCedulaDeCiudadania.Text = "&Consultar"
        Me.cmdConsultarCedulaDeCiudadania.UseVisualStyleBackColor = True
        '
        'TabMatriculaInmobiliaria
        '
        Me.TabMatriculaInmobiliaria.BackColor = System.Drawing.SystemColors.Control
        Me.TabMatriculaInmobiliaria.Controls.Add(Me.Label2)
        Me.TabMatriculaInmobiliaria.Controls.Add(Me.txtFPPRMAIN)
        Me.TabMatriculaInmobiliaria.Controls.Add(Me.lblFPPRMAIN)
        Me.TabMatriculaInmobiliaria.Controls.Add(Me.GroupBox16)
        Me.TabMatriculaInmobiliaria.Location = New System.Drawing.Point(4, 22)
        Me.TabMatriculaInmobiliaria.Name = "TabMatriculaInmobiliaria"
        Me.TabMatriculaInmobiliaria.Size = New System.Drawing.Size(827, 174)
        Me.TabMatriculaInmobiliaria.TabIndex = 2
        Me.TabMatriculaInmobiliaria.Text = "Matricula inmobiliaria"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(354, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 20)
        Me.Label2.TabIndex = 307
        Me.Label2.Text = "Ejemplo: 000-0000000"
        '
        'txtFPPRMAIN
        '
        Me.txtFPPRMAIN.AccessibleDescription = "Matricula"
        Me.txtFPPRMAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtFPPRMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPPRMAIN.Location = New System.Drawing.Point(151, 13)
        Me.txtFPPRMAIN.MaxLength = 11
        Me.txtFPPRMAIN.Name = "txtFPPRMAIN"
        Me.txtFPPRMAIN.Size = New System.Drawing.Size(197, 20)
        Me.txtFPPRMAIN.TabIndex = 305
        '
        'lblFPPRMAIN
        '
        Me.lblFPPRMAIN.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblFPPRMAIN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPPRMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPPRMAIN.ForeColor = System.Drawing.Color.Black
        Me.lblFPPRMAIN.Location = New System.Drawing.Point(13, 13)
        Me.lblFPPRMAIN.Name = "lblFPPRMAIN"
        Me.lblFPPRMAIN.Size = New System.Drawing.Size(134, 20)
        Me.lblFPPRMAIN.TabIndex = 306
        Me.lblFPPRMAIN.Text = "Matricula inmobiliaria"
        '
        'GroupBox16
        '
        Me.GroupBox16.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox16.Controls.Add(Me.cmdConsultarMatriculaInmobiliaria)
        Me.GroupBox16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox16.Location = New System.Drawing.Point(13, 105)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(801, 58)
        Me.GroupBox16.TabIndex = 3
        Me.GroupBox16.TabStop = False
        '
        'cmdConsultarMatriculaInmobiliaria
        '
        Me.cmdConsultarMatriculaInmobiliaria.AccessibleDescription = "Consultar"
        Me.cmdConsultarMatriculaInmobiliaria.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdConsultarMatriculaInmobiliaria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdConsultarMatriculaInmobiliaria.Location = New System.Drawing.Point(21, 20)
        Me.cmdConsultarMatriculaInmobiliaria.Name = "cmdConsultarMatriculaInmobiliaria"
        Me.cmdConsultarMatriculaInmobiliaria.Size = New System.Drawing.Size(207, 23)
        Me.cmdConsultarMatriculaInmobiliaria.TabIndex = 18
        Me.cmdConsultarMatriculaInmobiliaria.Text = "&Consultar"
        Me.cmdConsultarMatriculaInmobiliaria.UseVisualStyleBackColor = True
        '
        'chkGenerarCroquis
        '
        Me.chkGenerarCroquis.Location = New System.Drawing.Point(619, 20)
        Me.chkGenerarCroquis.Name = "chkGenerarCroquis"
        Me.chkGenerarCroquis.Size = New System.Drawing.Size(147, 17)
        Me.chkGenerarCroquis.TabIndex = 21
        Me.chkGenerarCroquis.Text = "Generar croquis"
        Me.chkGenerarCroquis.UseVisualStyleBackColor = True
        '
        'frm_consulta_ficha_predial_digital
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(895, 719)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_consulta_ficha_predial_digital"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CONSULTA FICHA PREDIAL DIGITAL"
        Me.GroupBox3.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        CType(Me.axaPlanoPredio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabCedulaCatastral.ResumeLayout(False)
        Me.TabCedulaCatastral.PerformLayout()
        Me.fraFICHPRED.ResumeLayout(False)
        Me.TabCedulaDeCiudadania.ResumeLayout(False)
        Me.TabCedulaDeCiudadania.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.TabMatriculaInmobiliaria.ResumeLayout(False)
        Me.TabMatriculaInmobiliaria.PerformLayout()
        Me.GroupBox16.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdULTIMACONSULTA As System.Windows.Forms.Button
    Friend WithEvents cmdLIMPIAR As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents axaPlanoPredio As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdVistaPredio As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabCedulaCatastral As System.Windows.Forms.TabPage
    Friend WithEvents txtFIPRCLSE As System.Windows.Forms.TextBox
    Friend WithEvents fraFICHPRED As System.Windows.Forms.GroupBox
    Friend WithEvents rbdReporteFichaResumen As System.Windows.Forms.RadioButton
    Friend WithEvents cmdConsultaCedulaCatastral As System.Windows.Forms.Button
    Friend WithEvents rbdReporteFichaPredial As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFIPRNUFI As System.Windows.Forms.TextBox
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents txtFIPRDIRE As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtFIPRCORR As System.Windows.Forms.TextBox
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents txtFIPRMUNI As System.Windows.Forms.TextBox
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblClaseOSector2 As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents txtFIPRUNPR As System.Windows.Forms.TextBox
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents txtFIPREDIF As System.Windows.Forms.TextBox
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents txtFIPRPRED As System.Windows.Forms.TextBox
    Friend WithEvents lblEdificio As System.Windows.Forms.Label
    Friend WithEvents txtFIPRMANZ As System.Windows.Forms.TextBox
    Friend WithEvents lblUnidadPredial As System.Windows.Forms.Label
    Friend WithEvents txtFIPRBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents TabCedulaDeCiudadania As System.Windows.Forms.TabPage
    Friend WithEvents lblFPPRNUDO As System.Windows.Forms.Label
    Friend WithEvents txtFPPRNUDO As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdConsultarCedulaDeCiudadania As System.Windows.Forms.Button
    Friend WithEvents TabMatriculaInmobiliaria As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFPPRMAIN As System.Windows.Forms.TextBox
    Friend WithEvents lblFPPRMAIN As System.Windows.Forms.Label
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdConsultarMatriculaInmobiliaria As System.Windows.Forms.Button
    Friend WithEvents cmdVisualizarFicha As System.Windows.Forms.Button
    Friend WithEvents chkGenerarCroquis As System.Windows.Forms.CheckBox
End Class
