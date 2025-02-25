<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_RESOLICE
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraPERIODO = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabRadicado = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRELIMAIN = New System.Windows.Forms.TextBox()
        Me.txtRELIVIGE = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdLimpiarLibroRadicador = New System.Windows.Forms.Button()
        Me.cmdAceptarLibroRadicador = New System.Windows.Forms.Button()
        Me.cmdConsultarLibroRadicador = New System.Windows.Forms.Button()
        Me.dgvCONSULTA_RESOLICE = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtRELIFERA = New System.Windows.Forms.TextBox()
        Me.txtRELINURA = New System.Windows.Forms.TextBox()
        Me.TabSolicitante = New System.Windows.Forms.TabPage()
        Me.txtRLSODIRE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRLSONOMB = New System.Windows.Forms.TextBox()
        Me.txtRLSOSEAP = New System.Windows.Forms.TextBox()
        Me.txtRLSOPRAP = New System.Windows.Forms.TextBox()
        Me.txtRLSONUDO = New System.Windows.Forms.TextBox()
        Me.lblDocumento = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblSegundoApellido = New System.Windows.Forms.Label()
        Me.lblPrimerApellido = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdLimpiarSolicitante = New System.Windows.Forms.Button()
        Me.cmdAceptarSolicitante = New System.Windows.Forms.Button()
        Me.cmdConsultarSolicitante = New System.Windows.Forms.Button()
        Me.dgvCONSULTA_RELISOLI = New System.Windows.Forms.DataGridView()
        Me.TabPredio = New System.Windows.Forms.TabPage()
        Me.txtRLPRMAIN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRLPRNUFI = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRLPRCLSE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRLPRCORR = New System.Windows.Forms.TextBox()
        Me.txtRLPRMUNI = New System.Windows.Forms.TextBox()
        Me.txtRLPRUNPR = New System.Windows.Forms.TextBox()
        Me.txtRLPREDIF = New System.Windows.Forms.TextBox()
        Me.txtRLPRPRED = New System.Windows.Forms.TextBox()
        Me.txtRLPRMANZ = New System.Windows.Forms.TextBox()
        Me.txtRLPRBARR = New System.Windows.Forms.TextBox()
        Me.lblUnidadPredial = New System.Windows.Forms.Label()
        Me.lblEdificio = New System.Windows.Forms.Label()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.lblManzana = New System.Windows.Forms.Label()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdLimpiarPredio = New System.Windows.Forms.Button()
        Me.cmdAceptarPredio = New System.Windows.Forms.Button()
        Me.cmdConsultarPredio = New System.Windows.Forms.Button()
        Me.dgvCONSULTA_RELIPRED = New System.Windows.Forms.DataGridView()
        Me.TabPropietario = New System.Windows.Forms.TabPage()
        Me.txtRLPRDERE = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtRLPRNOMB = New System.Windows.Forms.TextBox()
        Me.txtRLPRSEAP = New System.Windows.Forms.TextBox()
        Me.txtRLPRPRAP = New System.Windows.Forms.TextBox()
        Me.txtRLPRNUDO = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cmdLimpiarPropietario = New System.Windows.Forms.Button()
        Me.cmdAceptarPropietario = New System.Windows.Forms.Button()
        Me.cmdConsultarPropietario = New System.Windows.Forms.Button()
        Me.dgvCONSULTA_RELIPROP = New System.Windows.Forms.DataGridView()
        Me.strBARRESTA.SuspendLayout()
        Me.fraPERIODO.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabRadicado.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCONSULTA_RESOLICE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabSolicitante.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvCONSULTA_RELISOLI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPredio.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvCONSULTA_RELIPRED, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPropietario.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgvCONSULTA_RELIPROP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 475)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(975, 25)
        Me.strBARRESTA.TabIndex = 88
        '
        'tstBAESVALI
        '
        Me.tstBAESVALI.AutoSize = False
        Me.tstBAESVALI.BackColor = System.Drawing.Color.White
        Me.tstBAESVALI.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tstBAESVALI.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tstBAESVALI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstBAESVALI.ForeColor = System.Drawing.Color.Black
        Me.tstBAESVALI.ImageTransparentColor = System.Drawing.Color.White
        Me.tstBAESVALI.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.tstBAESVALI.Name = "tstBAESVALI"
        Me.tstBAESVALI.Size = New System.Drawing.Size(125, 22)
        Me.tstBAESVALI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tstBAESDESC
        '
        Me.tstBAESDESC.AutoSize = False
        Me.tstBAESDESC.BackColor = System.Drawing.Color.White
        Me.tstBAESDESC.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tstBAESDESC.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tstBAESDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstBAESDESC.ForeColor = System.Drawing.Color.Black
        Me.tstBAESDESC.ImageTransparentColor = System.Drawing.Color.White
        Me.tstBAESDESC.LinkColor = System.Drawing.Color.Black
        Me.tstBAESDESC.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.tstBAESDESC.Name = "tstBAESDESC"
        Me.tstBAESDESC.Size = New System.Drawing.Size(300, 22)
        Me.tstBAESDESC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.White
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(125, 22)
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fraPERIODO
        '
        Me.fraPERIODO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraPERIODO.BackColor = System.Drawing.SystemColors.Control
        Me.fraPERIODO.Controls.Add(Me.GroupBox2)
        Me.fraPERIODO.Controls.Add(Me.TabControl1)
        Me.fraPERIODO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPERIODO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPERIODO.Location = New System.Drawing.Point(12, 9)
        Me.fraPERIODO.Name = "fraPERIODO"
        Me.fraPERIODO.Size = New System.Drawing.Size(951, 447)
        Me.fraPERIODO.TabIndex = 87
        Me.fraPERIODO.TabStop = False
        Me.fraPERIODO.Text = "CONSULTA RESOLUCIONES Y LICENCIAS"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmdSalir)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 375)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(918, 54)
        Me.GroupBox2.TabIndex = 88
        Me.GroupBox2.TabStop = False
        '
        'cmdSalir
        '
        Me.cmdSalir.AccessibleDescription = "Salir"
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(792, 18)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(101, 23)
        Me.cmdSalir.TabIndex = 4
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabRadicado)
        Me.TabControl1.Controls.Add(Me.TabSolicitante)
        Me.TabControl1.Controls.Add(Me.TabPredio)
        Me.TabControl1.Controls.Add(Me.TabPropietario)
        Me.TabControl1.Location = New System.Drawing.Point(16, 20)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(918, 355)
        Me.TabControl1.TabIndex = 0
        '
        'TabRadicado
        '
        Me.TabRadicado.BackColor = System.Drawing.SystemColors.Control
        Me.TabRadicado.Controls.Add(Me.Label8)
        Me.TabRadicado.Controls.Add(Me.Label6)
        Me.TabRadicado.Controls.Add(Me.Label7)
        Me.TabRadicado.Controls.Add(Me.txtRELIMAIN)
        Me.TabRadicado.Controls.Add(Me.txtRELIVIGE)
        Me.TabRadicado.Controls.Add(Me.GroupBox1)
        Me.TabRadicado.Controls.Add(Me.dgvCONSULTA_RESOLICE)
        Me.TabRadicado.Controls.Add(Me.Label1)
        Me.TabRadicado.Controls.Add(Me.Label9)
        Me.TabRadicado.Controls.Add(Me.txtRELIFERA)
        Me.TabRadicado.Controls.Add(Me.txtRELINURA)
        Me.TabRadicado.Location = New System.Drawing.Point(4, 24)
        Me.TabRadicado.Name = "TabRadicado"
        Me.TabRadicado.Padding = New System.Windows.Forms.Padding(3)
        Me.TabRadicado.Size = New System.Drawing.Size(910, 327)
        Me.TabRadicado.TabIndex = 0
        Me.TabRadicado.Text = "Resolución"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(738, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 20)
        Me.Label8.TabIndex = 453
        Me.Label8.Text = "(dd-mm-aaaa)"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(6, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(179, 20)
        Me.Label6.TabIndex = 451
        Me.Label6.Text = "Vigencia"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(371, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(179, 20)
        Me.Label7.TabIndex = 452
        Me.Label7.Text = "Matricula inmobiliaria"
        '
        'txtRELIMAIN
        '
        Me.txtRELIMAIN.AccessibleDescription = "Matricula inmobiliaria"
        Me.txtRELIMAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtRELIMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRELIMAIN.Location = New System.Drawing.Point(553, 34)
        Me.txtRELIMAIN.MaxLength = 9
        Me.txtRELIMAIN.Name = "txtRELIMAIN"
        Me.txtRELIMAIN.Size = New System.Drawing.Size(179, 20)
        Me.txtRELIMAIN.TabIndex = 4
        '
        'txtRELIVIGE
        '
        Me.txtRELIVIGE.AccessibleDescription = "Vigencia"
        Me.txtRELIVIGE.BackColor = System.Drawing.SystemColors.Window
        Me.txtRELIVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRELIVIGE.ForeColor = System.Drawing.Color.Black
        Me.txtRELIVIGE.Location = New System.Drawing.Point(188, 34)
        Me.txtRELIVIGE.MaxLength = 9
        Me.txtRELIVIGE.Name = "txtRELIVIGE"
        Me.txtRELIVIGE.Size = New System.Drawing.Size(179, 20)
        Me.txtRELIVIGE.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.cmdLimpiarLibroRadicador)
        Me.GroupBox1.Controls.Add(Me.cmdAceptarLibroRadicador)
        Me.GroupBox1.Controls.Add(Me.cmdConsultarLibroRadicador)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 256)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(898, 60)
        Me.GroupBox1.TabIndex = 87
        Me.GroupBox1.TabStop = False
        '
        'cmdLimpiarLibroRadicador
        '
        Me.cmdLimpiarLibroRadicador.AccessibleDescription = "Limpiar"
        Me.cmdLimpiarLibroRadicador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLimpiarLibroRadicador.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLimpiarLibroRadicador.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLimpiarLibroRadicador.Location = New System.Drawing.Point(19, 20)
        Me.cmdLimpiarLibroRadicador.Name = "cmdLimpiarLibroRadicador"
        Me.cmdLimpiarLibroRadicador.Size = New System.Drawing.Size(117, 23)
        Me.cmdLimpiarLibroRadicador.TabIndex = 1
        Me.cmdLimpiarLibroRadicador.Text = "&Limpiar"
        Me.cmdLimpiarLibroRadicador.UseVisualStyleBackColor = True
        '
        'cmdAceptarLibroRadicador
        '
        Me.cmdAceptarLibroRadicador.AccessibleDescription = "Aceptar"
        Me.cmdAceptarLibroRadicador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptarLibroRadicador.Enabled = False
        Me.cmdAceptarLibroRadicador.Image = Global.SICAFI.My.Resources.Resources._22
        Me.cmdAceptarLibroRadicador.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptarLibroRadicador.Location = New System.Drawing.Point(778, 20)
        Me.cmdAceptarLibroRadicador.Name = "cmdAceptarLibroRadicador"
        Me.cmdAceptarLibroRadicador.Size = New System.Drawing.Size(101, 23)
        Me.cmdAceptarLibroRadicador.TabIndex = 3
        Me.cmdAceptarLibroRadicador.Text = "&Aceptar"
        Me.cmdAceptarLibroRadicador.UseVisualStyleBackColor = True
        '
        'cmdConsultarLibroRadicador
        '
        Me.cmdConsultarLibroRadicador.AccessibleDescription = "Consultar"
        Me.cmdConsultarLibroRadicador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdConsultarLibroRadicador.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdConsultarLibroRadicador.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdConsultarLibroRadicador.Location = New System.Drawing.Point(671, 20)
        Me.cmdConsultarLibroRadicador.Name = "cmdConsultarLibroRadicador"
        Me.cmdConsultarLibroRadicador.Size = New System.Drawing.Size(101, 23)
        Me.cmdConsultarLibroRadicador.TabIndex = 2
        Me.cmdConsultarLibroRadicador.Text = "&Consultar"
        Me.cmdConsultarLibroRadicador.UseVisualStyleBackColor = True
        '
        'dgvCONSULTA_RESOLICE
        '
        Me.dgvCONSULTA_RESOLICE.AccessibleDescription = ""
        Me.dgvCONSULTA_RESOLICE.AllowUserToAddRows = False
        Me.dgvCONSULTA_RESOLICE.AllowUserToDeleteRows = False
        Me.dgvCONSULTA_RESOLICE.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA_RESOLICE.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCONSULTA_RESOLICE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCONSULTA_RESOLICE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCONSULTA_RESOLICE.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCONSULTA_RESOLICE.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCONSULTA_RESOLICE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCONSULTA_RESOLICE.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCONSULTA_RESOLICE.ColumnHeadersHeight = 30
        Me.dgvCONSULTA_RESOLICE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCONSULTA_RESOLICE.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA_RESOLICE.Location = New System.Drawing.Point(6, 61)
        Me.dgvCONSULTA_RESOLICE.MultiSelect = False
        Me.dgvCONSULTA_RESOLICE.Name = "dgvCONSULTA_RESOLICE"
        Me.dgvCONSULTA_RESOLICE.ReadOnly = True
        Me.dgvCONSULTA_RESOLICE.RowHeadersVisible = False
        Me.dgvCONSULTA_RESOLICE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA_RESOLICE.ShowCellToolTips = False
        Me.dgvCONSULTA_RESOLICE.Size = New System.Drawing.Size(898, 193)
        Me.dgvCONSULTA_RESOLICE.StandardTab = True
        Me.dgvCONSULTA_RESOLICE.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(179, 20)
        Me.Label1.TabIndex = 420
        Me.Label1.Text = "Nro. Resolución"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(371, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(179, 20)
        Me.Label9.TabIndex = 448
        Me.Label9.Text = "Fecha de Resolución"
        '
        'txtRELIFERA
        '
        Me.txtRELIFERA.AccessibleDescription = "Fecha de Resolución"
        Me.txtRELIFERA.BackColor = System.Drawing.SystemColors.Window
        Me.txtRELIFERA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRELIFERA.Location = New System.Drawing.Point(553, 11)
        Me.txtRELIFERA.MaxLength = 10
        Me.txtRELIFERA.Name = "txtRELIFERA"
        Me.txtRELIFERA.Size = New System.Drawing.Size(179, 20)
        Me.txtRELIFERA.TabIndex = 2
        '
        'txtRELINURA
        '
        Me.txtRELINURA.AccessibleDescription = "Nro. Resolución"
        Me.txtRELINURA.BackColor = System.Drawing.SystemColors.Window
        Me.txtRELINURA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRELINURA.ForeColor = System.Drawing.Color.Black
        Me.txtRELINURA.Location = New System.Drawing.Point(188, 11)
        Me.txtRELINURA.MaxLength = 9
        Me.txtRELINURA.Name = "txtRELINURA"
        Me.txtRELINURA.Size = New System.Drawing.Size(179, 20)
        Me.txtRELINURA.TabIndex = 1
        '
        'TabSolicitante
        '
        Me.TabSolicitante.BackColor = System.Drawing.SystemColors.Control
        Me.TabSolicitante.Controls.Add(Me.txtRLSODIRE)
        Me.TabSolicitante.Controls.Add(Me.Label2)
        Me.TabSolicitante.Controls.Add(Me.txtRLSONOMB)
        Me.TabSolicitante.Controls.Add(Me.txtRLSOSEAP)
        Me.TabSolicitante.Controls.Add(Me.txtRLSOPRAP)
        Me.TabSolicitante.Controls.Add(Me.txtRLSONUDO)
        Me.TabSolicitante.Controls.Add(Me.lblDocumento)
        Me.TabSolicitante.Controls.Add(Me.lblNombre)
        Me.TabSolicitante.Controls.Add(Me.lblSegundoApellido)
        Me.TabSolicitante.Controls.Add(Me.lblPrimerApellido)
        Me.TabSolicitante.Controls.Add(Me.GroupBox3)
        Me.TabSolicitante.Controls.Add(Me.dgvCONSULTA_RELISOLI)
        Me.TabSolicitante.Location = New System.Drawing.Point(4, 24)
        Me.TabSolicitante.Name = "TabSolicitante"
        Me.TabSolicitante.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSolicitante.Size = New System.Drawing.Size(910, 327)
        Me.TabSolicitante.TabIndex = 1
        Me.TabSolicitante.Text = "Solicitante(s)"
        '
        'txtRLSODIRE
        '
        Me.txtRLSODIRE.AccessibleDescription = "Dirección"
        Me.txtRLSODIRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLSODIRE.Location = New System.Drawing.Point(601, 35)
        Me.txtRLSODIRE.MaxLength = 20
        Me.txtRLSODIRE.Name = "txtRLSODIRE"
        Me.txtRLSODIRE.Size = New System.Drawing.Size(303, 21)
        Me.txtRLSODIRE.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(601, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(303, 20)
        Me.Label2.TabIndex = 462
        Me.Label2.Text = "Dirección predio"
        '
        'txtRLSONOMB
        '
        Me.txtRLSONOMB.AccessibleDescription = "Nombre (s)"
        Me.txtRLSONOMB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLSONOMB.Location = New System.Drawing.Point(379, 35)
        Me.txtRLSONOMB.MaxLength = 20
        Me.txtRLSONOMB.Name = "txtRLSONOMB"
        Me.txtRLSONOMB.Size = New System.Drawing.Size(219, 21)
        Me.txtRLSONOMB.TabIndex = 6
        '
        'txtRLSOSEAP
        '
        Me.txtRLSOSEAP.AccessibleDescription = "Segundo apellido"
        Me.txtRLSOSEAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLSOSEAP.Location = New System.Drawing.Point(250, 35)
        Me.txtRLSOSEAP.MaxLength = 15
        Me.txtRLSOSEAP.Name = "txtRLSOSEAP"
        Me.txtRLSOSEAP.Size = New System.Drawing.Size(126, 21)
        Me.txtRLSOSEAP.TabIndex = 5
        '
        'txtRLSOPRAP
        '
        Me.txtRLSOPRAP.AccessibleDescription = "Primer apellido"
        Me.txtRLSOPRAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLSOPRAP.Location = New System.Drawing.Point(121, 35)
        Me.txtRLSOPRAP.MaxLength = 15
        Me.txtRLSOPRAP.Name = "txtRLSOPRAP"
        Me.txtRLSOPRAP.Size = New System.Drawing.Size(126, 21)
        Me.txtRLSOPRAP.TabIndex = 4
        '
        'txtRLSONUDO
        '
        Me.txtRLSONUDO.AccessibleDescription = "Documento"
        Me.txtRLSONUDO.Location = New System.Drawing.Point(6, 35)
        Me.txtRLSONUDO.MaxLength = 14
        Me.txtRLSONUDO.Name = "txtRLSONUDO"
        Me.txtRLSONUDO.Size = New System.Drawing.Size(112, 21)
        Me.txtRLSONUDO.TabIndex = 3
        '
        'lblDocumento
        '
        Me.lblDocumento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDocumento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumento.ForeColor = System.Drawing.Color.Black
        Me.lblDocumento.Location = New System.Drawing.Point(6, 12)
        Me.lblDocumento.Name = "lblDocumento"
        Me.lblDocumento.Size = New System.Drawing.Size(112, 20)
        Me.lblDocumento.TabIndex = 460
        Me.lblDocumento.Text = "Nro. Documento"
        '
        'lblNombre
        '
        Me.lblNombre.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombre.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.Black
        Me.lblNombre.Location = New System.Drawing.Point(379, 12)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(219, 20)
        Me.lblNombre.TabIndex = 459
        Me.lblNombre.Text = "Nombre(s)"
        '
        'lblSegundoApellido
        '
        Me.lblSegundoApellido.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblSegundoApellido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSegundoApellido.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSegundoApellido.ForeColor = System.Drawing.Color.Black
        Me.lblSegundoApellido.Location = New System.Drawing.Point(250, 12)
        Me.lblSegundoApellido.Name = "lblSegundoApellido"
        Me.lblSegundoApellido.Size = New System.Drawing.Size(126, 20)
        Me.lblSegundoApellido.TabIndex = 458
        Me.lblSegundoApellido.Text = "Segundo Apellido"
        '
        'lblPrimerApellido
        '
        Me.lblPrimerApellido.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPrimerApellido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPrimerApellido.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrimerApellido.ForeColor = System.Drawing.Color.Black
        Me.lblPrimerApellido.Location = New System.Drawing.Point(121, 12)
        Me.lblPrimerApellido.Name = "lblPrimerApellido"
        Me.lblPrimerApellido.Size = New System.Drawing.Size(126, 20)
        Me.lblPrimerApellido.TabIndex = 457
        Me.lblPrimerApellido.Text = "Primer Apellido"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox3.Controls.Add(Me.cmdLimpiarSolicitante)
        Me.GroupBox3.Controls.Add(Me.cmdAceptarSolicitante)
        Me.GroupBox3.Controls.Add(Me.cmdConsultarSolicitante)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 256)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(898, 60)
        Me.GroupBox3.TabIndex = 452
        Me.GroupBox3.TabStop = False
        '
        'cmdLimpiarSolicitante
        '
        Me.cmdLimpiarSolicitante.AccessibleDescription = "Limpiar"
        Me.cmdLimpiarSolicitante.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLimpiarSolicitante.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLimpiarSolicitante.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLimpiarSolicitante.Location = New System.Drawing.Point(19, 20)
        Me.cmdLimpiarSolicitante.Name = "cmdLimpiarSolicitante"
        Me.cmdLimpiarSolicitante.Size = New System.Drawing.Size(117, 23)
        Me.cmdLimpiarSolicitante.TabIndex = 1
        Me.cmdLimpiarSolicitante.Text = "&Limpiar"
        Me.cmdLimpiarSolicitante.UseVisualStyleBackColor = True
        '
        'cmdAceptarSolicitante
        '
        Me.cmdAceptarSolicitante.AccessibleDescription = "Aceptar"
        Me.cmdAceptarSolicitante.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptarSolicitante.Enabled = False
        Me.cmdAceptarSolicitante.Image = Global.SICAFI.My.Resources.Resources._22
        Me.cmdAceptarSolicitante.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptarSolicitante.Location = New System.Drawing.Point(778, 20)
        Me.cmdAceptarSolicitante.Name = "cmdAceptarSolicitante"
        Me.cmdAceptarSolicitante.Size = New System.Drawing.Size(101, 23)
        Me.cmdAceptarSolicitante.TabIndex = 3
        Me.cmdAceptarSolicitante.Text = "&Aceptar"
        Me.cmdAceptarSolicitante.UseVisualStyleBackColor = True
        '
        'cmdConsultarSolicitante
        '
        Me.cmdConsultarSolicitante.AccessibleDescription = "Consultar"
        Me.cmdConsultarSolicitante.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdConsultarSolicitante.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdConsultarSolicitante.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdConsultarSolicitante.Location = New System.Drawing.Point(671, 20)
        Me.cmdConsultarSolicitante.Name = "cmdConsultarSolicitante"
        Me.cmdConsultarSolicitante.Size = New System.Drawing.Size(101, 23)
        Me.cmdConsultarSolicitante.TabIndex = 2
        Me.cmdConsultarSolicitante.Text = "&Consultar"
        Me.cmdConsultarSolicitante.UseVisualStyleBackColor = True
        '
        'dgvCONSULTA_RELISOLI
        '
        Me.dgvCONSULTA_RELISOLI.AccessibleDescription = ""
        Me.dgvCONSULTA_RELISOLI.AllowUserToAddRows = False
        Me.dgvCONSULTA_RELISOLI.AllowUserToDeleteRows = False
        Me.dgvCONSULTA_RELISOLI.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA_RELISOLI.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCONSULTA_RELISOLI.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCONSULTA_RELISOLI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCONSULTA_RELISOLI.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCONSULTA_RELISOLI.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCONSULTA_RELISOLI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCONSULTA_RELISOLI.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCONSULTA_RELISOLI.ColumnHeadersHeight = 30
        Me.dgvCONSULTA_RELISOLI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCONSULTA_RELISOLI.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA_RELISOLI.Location = New System.Drawing.Point(6, 62)
        Me.dgvCONSULTA_RELISOLI.MultiSelect = False
        Me.dgvCONSULTA_RELISOLI.Name = "dgvCONSULTA_RELISOLI"
        Me.dgvCONSULTA_RELISOLI.ReadOnly = True
        Me.dgvCONSULTA_RELISOLI.RowHeadersVisible = False
        Me.dgvCONSULTA_RELISOLI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA_RELISOLI.ShowCellToolTips = False
        Me.dgvCONSULTA_RELISOLI.Size = New System.Drawing.Size(898, 192)
        Me.dgvCONSULTA_RELISOLI.StandardTab = True
        Me.dgvCONSULTA_RELISOLI.TabIndex = 451
        '
        'TabPredio
        '
        Me.TabPredio.BackColor = System.Drawing.SystemColors.Control
        Me.TabPredio.Controls.Add(Me.txtRLPRMAIN)
        Me.TabPredio.Controls.Add(Me.Label5)
        Me.TabPredio.Controls.Add(Me.txtRLPRNUFI)
        Me.TabPredio.Controls.Add(Me.Label4)
        Me.TabPredio.Controls.Add(Me.txtRLPRCLSE)
        Me.TabPredio.Controls.Add(Me.Label3)
        Me.TabPredio.Controls.Add(Me.txtRLPRCORR)
        Me.TabPredio.Controls.Add(Me.txtRLPRMUNI)
        Me.TabPredio.Controls.Add(Me.txtRLPRUNPR)
        Me.TabPredio.Controls.Add(Me.txtRLPREDIF)
        Me.TabPredio.Controls.Add(Me.txtRLPRPRED)
        Me.TabPredio.Controls.Add(Me.txtRLPRMANZ)
        Me.TabPredio.Controls.Add(Me.txtRLPRBARR)
        Me.TabPredio.Controls.Add(Me.lblUnidadPredial)
        Me.TabPredio.Controls.Add(Me.lblEdificio)
        Me.TabPredio.Controls.Add(Me.lblPredio)
        Me.TabPredio.Controls.Add(Me.lblManzana)
        Me.TabPredio.Controls.Add(Me.lblBarrio)
        Me.TabPredio.Controls.Add(Me.lblCorregimiento)
        Me.TabPredio.Controls.Add(Me.lblMunicipio)
        Me.TabPredio.Controls.Add(Me.GroupBox4)
        Me.TabPredio.Controls.Add(Me.dgvCONSULTA_RELIPRED)
        Me.TabPredio.Location = New System.Drawing.Point(4, 24)
        Me.TabPredio.Name = "TabPredio"
        Me.TabPredio.Size = New System.Drawing.Size(910, 327)
        Me.TabPredio.TabIndex = 2
        Me.TabPredio.Text = "Predio(s)"
        '
        'txtRLPRMAIN
        '
        Me.txtRLPRMAIN.AccessibleDescription = "Matricula"
        Me.txtRLPRMAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLPRMAIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtRLPRMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLPRMAIN.ForeColor = System.Drawing.Color.Black
        Me.txtRLPRMAIN.Location = New System.Drawing.Point(800, 34)
        Me.txtRLPRMAIN.MaxLength = 9
        Me.txtRLPRMAIN.Name = "txtRLPRMAIN"
        Me.txtRLPRMAIN.Size = New System.Drawing.Size(104, 20)
        Me.txtRLPRMAIN.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(800, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 20)
        Me.Label5.TabIndex = 472
        Me.Label5.Text = "Matricula"
        '
        'txtRLPRNUFI
        '
        Me.txtRLPRNUFI.AccessibleDescription = "Estado"
        Me.txtRLPRNUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLPRNUFI.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtRLPRNUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLPRNUFI.ForeColor = System.Drawing.Color.Black
        Me.txtRLPRNUFI.Location = New System.Drawing.Point(711, 34)
        Me.txtRLPRNUFI.MaxLength = 9
        Me.txtRLPRNUFI.Name = "txtRLPRNUFI"
        Me.txtRLPRNUFI.Size = New System.Drawing.Size(85, 20)
        Me.txtRLPRNUFI.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(711, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 20)
        Me.Label4.TabIndex = 470
        Me.Label4.Text = "Nro. Ficha"
        '
        'txtRLPRCLSE
        '
        Me.txtRLPRCLSE.AccessibleDescription = "Sector"
        Me.txtRLPRCLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLPRCLSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtRLPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLPRCLSE.ForeColor = System.Drawing.Color.Black
        Me.txtRLPRCLSE.Location = New System.Drawing.Point(622, 34)
        Me.txtRLPRCLSE.MaxLength = 10
        Me.txtRLPRCLSE.Name = "txtRLPRCLSE"
        Me.txtRLPRCLSE.Size = New System.Drawing.Size(85, 20)
        Me.txtRLPRCLSE.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(622, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 20)
        Me.Label3.TabIndex = 468
        Me.Label3.Text = "Sector"
        '
        'txtRLPRCORR
        '
        Me.txtRLPRCORR.AccessibleDescription = "Corregimiento"
        Me.txtRLPRCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLPRCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLPRCORR.Location = New System.Drawing.Point(94, 34)
        Me.txtRLPRCORR.MaxLength = 10
        Me.txtRLPRCORR.Name = "txtRLPRCORR"
        Me.txtRLPRCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtRLPRCORR.TabIndex = 9
        '
        'txtRLPRMUNI
        '
        Me.txtRLPRMUNI.AccessibleDescription = "Municipio"
        Me.txtRLPRMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLPRMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLPRMUNI.Location = New System.Drawing.Point(6, 34)
        Me.txtRLPRMUNI.MaxLength = 10
        Me.txtRLPRMUNI.Name = "txtRLPRMUNI"
        Me.txtRLPRMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtRLPRMUNI.TabIndex = 8
        '
        'txtRLPRUNPR
        '
        Me.txtRLPRUNPR.AccessibleDescription = "Unidad predial "
        Me.txtRLPRUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLPRUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLPRUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLPRUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtRLPRUNPR.Location = New System.Drawing.Point(534, 34)
        Me.txtRLPRUNPR.MaxLength = 10
        Me.txtRLPRUNPR.Name = "txtRLPRUNPR"
        Me.txtRLPRUNPR.Size = New System.Drawing.Size(85, 20)
        Me.txtRLPRUNPR.TabIndex = 14
        '
        'txtRLPREDIF
        '
        Me.txtRLPREDIF.AccessibleDescription = "Edificio "
        Me.txtRLPREDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLPREDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLPREDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLPREDIF.ForeColor = System.Drawing.Color.Black
        Me.txtRLPREDIF.Location = New System.Drawing.Point(446, 34)
        Me.txtRLPREDIF.MaxLength = 10
        Me.txtRLPREDIF.Name = "txtRLPREDIF"
        Me.txtRLPREDIF.Size = New System.Drawing.Size(85, 20)
        Me.txtRLPREDIF.TabIndex = 13
        '
        'txtRLPRPRED
        '
        Me.txtRLPRPRED.AccessibleDescription = "Predio "
        Me.txtRLPRPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLPRPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLPRPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLPRPRED.ForeColor = System.Drawing.Color.Black
        Me.txtRLPRPRED.Location = New System.Drawing.Point(358, 34)
        Me.txtRLPRPRED.MaxLength = 10
        Me.txtRLPRPRED.Name = "txtRLPRPRED"
        Me.txtRLPRPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtRLPRPRED.TabIndex = 12
        '
        'txtRLPRMANZ
        '
        Me.txtRLPRMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtRLPRMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLPRMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLPRMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLPRMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtRLPRMANZ.Location = New System.Drawing.Point(270, 34)
        Me.txtRLPRMANZ.MaxLength = 10
        Me.txtRLPRMANZ.Name = "txtRLPRMANZ"
        Me.txtRLPRMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtRLPRMANZ.TabIndex = 11
        '
        'txtRLPRBARR
        '
        Me.txtRLPRBARR.AccessibleDescription = "Barrio "
        Me.txtRLPRBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLPRBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLPRBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLPRBARR.ForeColor = System.Drawing.Color.Black
        Me.txtRLPRBARR.Location = New System.Drawing.Point(182, 34)
        Me.txtRLPRBARR.MaxLength = 10
        Me.txtRLPRBARR.Name = "txtRLPRBARR"
        Me.txtRLPRBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtRLPRBARR.TabIndex = 10
        '
        'lblUnidadPredial
        '
        Me.lblUnidadPredial.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblUnidadPredial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUnidadPredial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidadPredial.ForeColor = System.Drawing.Color.Black
        Me.lblUnidadPredial.Location = New System.Drawing.Point(534, 11)
        Me.lblUnidadPredial.Name = "lblUnidadPredial"
        Me.lblUnidadPredial.Size = New System.Drawing.Size(84, 20)
        Me.lblUnidadPredial.TabIndex = 461
        Me.lblUnidadPredial.Text = "Unidad Predial"
        '
        'lblEdificio
        '
        Me.lblEdificio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblEdificio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEdificio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdificio.ForeColor = System.Drawing.Color.Black
        Me.lblEdificio.Location = New System.Drawing.Point(446, 11)
        Me.lblEdificio.Name = "lblEdificio"
        Me.lblEdificio.Size = New System.Drawing.Size(84, 20)
        Me.lblEdificio.TabIndex = 459
        Me.lblEdificio.Text = "Edificio"
        '
        'lblPredio
        '
        Me.lblPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredio.ForeColor = System.Drawing.Color.Black
        Me.lblPredio.Location = New System.Drawing.Point(358, 11)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(84, 20)
        Me.lblPredio.TabIndex = 458
        Me.lblPredio.Text = "Predio"
        '
        'lblManzana
        '
        Me.lblManzana.AccessibleDescription = ""
        Me.lblManzana.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblManzana.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblManzana.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManzana.ForeColor = System.Drawing.Color.Black
        Me.lblManzana.Location = New System.Drawing.Point(270, 11)
        Me.lblManzana.Name = "lblManzana"
        Me.lblManzana.Size = New System.Drawing.Size(84, 20)
        Me.lblManzana.TabIndex = 455
        Me.lblManzana.Text = "Manza / Vered"
        '
        'lblBarrio
        '
        Me.lblBarrio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblBarrio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBarrio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarrio.ForeColor = System.Drawing.Color.Black
        Me.lblBarrio.Location = New System.Drawing.Point(182, 11)
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Size = New System.Drawing.Size(84, 20)
        Me.lblBarrio.TabIndex = 453
        Me.lblBarrio.Text = "Barrio"
        '
        'lblCorregimiento
        '
        Me.lblCorregimiento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCorregimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorregimiento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorregimiento.ForeColor = System.Drawing.Color.Black
        Me.lblCorregimiento.Location = New System.Drawing.Point(94, 11)
        Me.lblCorregimiento.Name = "lblCorregimiento"
        Me.lblCorregimiento.Size = New System.Drawing.Size(84, 20)
        Me.lblCorregimiento.TabIndex = 466
        Me.lblCorregimiento.Text = "Corregimiento"
        '
        'lblMunicipio
        '
        Me.lblMunicipio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblMunicipio.Location = New System.Drawing.Point(6, 11)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(84, 20)
        Me.lblMunicipio.TabIndex = 467
        Me.lblMunicipio.Text = "Municipio"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Controls.Add(Me.cmdLimpiarPredio)
        Me.GroupBox4.Controls.Add(Me.cmdAceptarPredio)
        Me.GroupBox4.Controls.Add(Me.cmdConsultarPredio)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 256)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(898, 60)
        Me.GroupBox4.TabIndex = 452
        Me.GroupBox4.TabStop = False
        '
        'cmdLimpiarPredio
        '
        Me.cmdLimpiarPredio.AccessibleDescription = "Limpiar"
        Me.cmdLimpiarPredio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLimpiarPredio.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLimpiarPredio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLimpiarPredio.Location = New System.Drawing.Point(19, 20)
        Me.cmdLimpiarPredio.Name = "cmdLimpiarPredio"
        Me.cmdLimpiarPredio.Size = New System.Drawing.Size(117, 23)
        Me.cmdLimpiarPredio.TabIndex = 1
        Me.cmdLimpiarPredio.Text = "&Limpiar"
        Me.cmdLimpiarPredio.UseVisualStyleBackColor = True
        '
        'cmdAceptarPredio
        '
        Me.cmdAceptarPredio.AccessibleDescription = "Aceptar"
        Me.cmdAceptarPredio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptarPredio.Enabled = False
        Me.cmdAceptarPredio.Image = Global.SICAFI.My.Resources.Resources._22
        Me.cmdAceptarPredio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptarPredio.Location = New System.Drawing.Point(778, 20)
        Me.cmdAceptarPredio.Name = "cmdAceptarPredio"
        Me.cmdAceptarPredio.Size = New System.Drawing.Size(101, 23)
        Me.cmdAceptarPredio.TabIndex = 3
        Me.cmdAceptarPredio.Text = "&Aceptar"
        Me.cmdAceptarPredio.UseVisualStyleBackColor = True
        '
        'cmdConsultarPredio
        '
        Me.cmdConsultarPredio.AccessibleDescription = "Consultar"
        Me.cmdConsultarPredio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdConsultarPredio.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdConsultarPredio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdConsultarPredio.Location = New System.Drawing.Point(671, 20)
        Me.cmdConsultarPredio.Name = "cmdConsultarPredio"
        Me.cmdConsultarPredio.Size = New System.Drawing.Size(101, 23)
        Me.cmdConsultarPredio.TabIndex = 2
        Me.cmdConsultarPredio.Text = "&Consultar"
        Me.cmdConsultarPredio.UseVisualStyleBackColor = True
        '
        'dgvCONSULTA_RELIPRED
        '
        Me.dgvCONSULTA_RELIPRED.AccessibleDescription = ""
        Me.dgvCONSULTA_RELIPRED.AllowUserToAddRows = False
        Me.dgvCONSULTA_RELIPRED.AllowUserToDeleteRows = False
        Me.dgvCONSULTA_RELIPRED.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA_RELIPRED.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCONSULTA_RELIPRED.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCONSULTA_RELIPRED.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCONSULTA_RELIPRED.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCONSULTA_RELIPRED.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCONSULTA_RELIPRED.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCONSULTA_RELIPRED.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCONSULTA_RELIPRED.ColumnHeadersHeight = 30
        Me.dgvCONSULTA_RELIPRED.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCONSULTA_RELIPRED.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA_RELIPRED.Location = New System.Drawing.Point(6, 60)
        Me.dgvCONSULTA_RELIPRED.MultiSelect = False
        Me.dgvCONSULTA_RELIPRED.Name = "dgvCONSULTA_RELIPRED"
        Me.dgvCONSULTA_RELIPRED.ReadOnly = True
        Me.dgvCONSULTA_RELIPRED.RowHeadersVisible = False
        Me.dgvCONSULTA_RELIPRED.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA_RELIPRED.ShowCellToolTips = False
        Me.dgvCONSULTA_RELIPRED.Size = New System.Drawing.Size(898, 194)
        Me.dgvCONSULTA_RELIPRED.StandardTab = True
        Me.dgvCONSULTA_RELIPRED.TabIndex = 451
        '
        'TabPropietario
        '
        Me.TabPropietario.BackColor = System.Drawing.SystemColors.Control
        Me.TabPropietario.Controls.Add(Me.txtRLPRDERE)
        Me.TabPropietario.Controls.Add(Me.Label10)
        Me.TabPropietario.Controls.Add(Me.txtRLPRNOMB)
        Me.TabPropietario.Controls.Add(Me.txtRLPRSEAP)
        Me.TabPropietario.Controls.Add(Me.txtRLPRPRAP)
        Me.TabPropietario.Controls.Add(Me.txtRLPRNUDO)
        Me.TabPropietario.Controls.Add(Me.Label11)
        Me.TabPropietario.Controls.Add(Me.Label12)
        Me.TabPropietario.Controls.Add(Me.Label13)
        Me.TabPropietario.Controls.Add(Me.Label14)
        Me.TabPropietario.Controls.Add(Me.GroupBox5)
        Me.TabPropietario.Controls.Add(Me.dgvCONSULTA_RELIPROP)
        Me.TabPropietario.Location = New System.Drawing.Point(4, 24)
        Me.TabPropietario.Name = "TabPropietario"
        Me.TabPropietario.Size = New System.Drawing.Size(910, 327)
        Me.TabPropietario.TabIndex = 3
        Me.TabPropietario.Text = "Propietario(s)"
        '
        'txtRLPRDERE
        '
        Me.txtRLPRDERE.AccessibleDescription = "Derecho"
        Me.txtRLPRDERE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLPRDERE.Location = New System.Drawing.Point(788, 34)
        Me.txtRLPRDERE.MaxLength = 20
        Me.txtRLPRDERE.Name = "txtRLPRDERE"
        Me.txtRLPRDERE.Size = New System.Drawing.Size(116, 21)
        Me.txtRLPRDERE.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(788, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 20)
        Me.Label10.TabIndex = 474
        Me.Label10.Text = "Derecho"
        '
        'txtRLPRNOMB
        '
        Me.txtRLPRNOMB.AccessibleDescription = "Nombre (s)"
        Me.txtRLPRNOMB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLPRNOMB.Location = New System.Drawing.Point(379, 34)
        Me.txtRLPRNOMB.MaxLength = 20
        Me.txtRLPRNOMB.Name = "txtRLPRNOMB"
        Me.txtRLPRNOMB.Size = New System.Drawing.Size(406, 21)
        Me.txtRLPRNOMB.TabIndex = 4
        '
        'txtRLPRSEAP
        '
        Me.txtRLPRSEAP.AccessibleDescription = "Segundo apellido"
        Me.txtRLPRSEAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLPRSEAP.Location = New System.Drawing.Point(250, 34)
        Me.txtRLPRSEAP.MaxLength = 15
        Me.txtRLPRSEAP.Name = "txtRLPRSEAP"
        Me.txtRLPRSEAP.Size = New System.Drawing.Size(126, 21)
        Me.txtRLPRSEAP.TabIndex = 3
        '
        'txtRLPRPRAP
        '
        Me.txtRLPRPRAP.AccessibleDescription = "Primer apellido"
        Me.txtRLPRPRAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLPRPRAP.Location = New System.Drawing.Point(121, 34)
        Me.txtRLPRPRAP.MaxLength = 15
        Me.txtRLPRPRAP.Name = "txtRLPRPRAP"
        Me.txtRLPRPRAP.Size = New System.Drawing.Size(126, 21)
        Me.txtRLPRPRAP.TabIndex = 2
        '
        'txtRLPRNUDO
        '
        Me.txtRLPRNUDO.AccessibleDescription = "Documento"
        Me.txtRLPRNUDO.Location = New System.Drawing.Point(6, 34)
        Me.txtRLPRNUDO.MaxLength = 14
        Me.txtRLPRNUDO.Name = "txtRLPRNUDO"
        Me.txtRLPRNUDO.Size = New System.Drawing.Size(112, 21)
        Me.txtRLPRNUDO.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(6, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 20)
        Me.Label11.TabIndex = 473
        Me.Label11.Text = "Nro. Documento"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(379, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(406, 20)
        Me.Label12.TabIndex = 472
        Me.Label12.Text = "Nombre(s)"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(250, 11)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(126, 20)
        Me.Label13.TabIndex = 471
        Me.Label13.Text = "Segundo Apellido"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(121, 11)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(126, 20)
        Me.Label14.TabIndex = 470
        Me.Label14.Text = "Primer Apellido"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox5.Controls.Add(Me.cmdLimpiarPropietario)
        Me.GroupBox5.Controls.Add(Me.cmdAceptarPropietario)
        Me.GroupBox5.Controls.Add(Me.cmdConsultarPropietario)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 255)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(898, 60)
        Me.GroupBox5.TabIndex = 469
        Me.GroupBox5.TabStop = False
        '
        'cmdLimpiarPropietario
        '
        Me.cmdLimpiarPropietario.AccessibleDescription = "Limpiar"
        Me.cmdLimpiarPropietario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLimpiarPropietario.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLimpiarPropietario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLimpiarPropietario.Location = New System.Drawing.Point(19, 20)
        Me.cmdLimpiarPropietario.Name = "cmdLimpiarPropietario"
        Me.cmdLimpiarPropietario.Size = New System.Drawing.Size(117, 23)
        Me.cmdLimpiarPropietario.TabIndex = 1
        Me.cmdLimpiarPropietario.Text = "&Limpiar"
        Me.cmdLimpiarPropietario.UseVisualStyleBackColor = True
        '
        'cmdAceptarPropietario
        '
        Me.cmdAceptarPropietario.AccessibleDescription = "Aceptar"
        Me.cmdAceptarPropietario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptarPropietario.Enabled = False
        Me.cmdAceptarPropietario.Image = Global.SICAFI.My.Resources.Resources._22
        Me.cmdAceptarPropietario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptarPropietario.Location = New System.Drawing.Point(778, 20)
        Me.cmdAceptarPropietario.Name = "cmdAceptarPropietario"
        Me.cmdAceptarPropietario.Size = New System.Drawing.Size(101, 23)
        Me.cmdAceptarPropietario.TabIndex = 3
        Me.cmdAceptarPropietario.Text = "&Aceptar"
        Me.cmdAceptarPropietario.UseVisualStyleBackColor = True
        '
        'cmdConsultarPropietario
        '
        Me.cmdConsultarPropietario.AccessibleDescription = "Consultar"
        Me.cmdConsultarPropietario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdConsultarPropietario.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdConsultarPropietario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdConsultarPropietario.Location = New System.Drawing.Point(671, 20)
        Me.cmdConsultarPropietario.Name = "cmdConsultarPropietario"
        Me.cmdConsultarPropietario.Size = New System.Drawing.Size(101, 23)
        Me.cmdConsultarPropietario.TabIndex = 2
        Me.cmdConsultarPropietario.Text = "&Consultar"
        Me.cmdConsultarPropietario.UseVisualStyleBackColor = True
        '
        'dgvCONSULTA_RELIPROP
        '
        Me.dgvCONSULTA_RELIPROP.AccessibleDescription = ""
        Me.dgvCONSULTA_RELIPROP.AllowUserToAddRows = False
        Me.dgvCONSULTA_RELIPROP.AllowUserToDeleteRows = False
        Me.dgvCONSULTA_RELIPROP.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA_RELIPROP.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvCONSULTA_RELIPROP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCONSULTA_RELIPROP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCONSULTA_RELIPROP.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCONSULTA_RELIPROP.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCONSULTA_RELIPROP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCONSULTA_RELIPROP.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCONSULTA_RELIPROP.ColumnHeadersHeight = 30
        Me.dgvCONSULTA_RELIPROP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCONSULTA_RELIPROP.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA_RELIPROP.Location = New System.Drawing.Point(6, 61)
        Me.dgvCONSULTA_RELIPROP.MultiSelect = False
        Me.dgvCONSULTA_RELIPROP.Name = "dgvCONSULTA_RELIPROP"
        Me.dgvCONSULTA_RELIPROP.ReadOnly = True
        Me.dgvCONSULTA_RELIPROP.RowHeadersVisible = False
        Me.dgvCONSULTA_RELIPROP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA_RELIPROP.ShowCellToolTips = False
        Me.dgvCONSULTA_RELIPROP.Size = New System.Drawing.Size(898, 192)
        Me.dgvCONSULTA_RELIPROP.StandardTab = True
        Me.dgvCONSULTA_RELIPROP.TabIndex = 468
        '
        'frm_consultar_RESOLICE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(975, 500)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraPERIODO)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(991, 536)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(991, 536)
        Me.Name = "frm_consultar_RESOLICE"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar registro"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraPERIODO.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabRadicado.ResumeLayout(False)
        Me.TabRadicado.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvCONSULTA_RESOLICE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabSolicitante.ResumeLayout(False)
        Me.TabSolicitante.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvCONSULTA_RELISOLI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPredio.ResumeLayout(False)
        Me.TabPredio.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvCONSULTA_RELIPRED, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPropietario.ResumeLayout(False)
        Me.TabPropietario.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.dgvCONSULTA_RELIPROP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraPERIODO As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabRadicado As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLimpiarLibroRadicador As System.Windows.Forms.Button
    Friend WithEvents cmdAceptarLibroRadicador As System.Windows.Forms.Button
    Friend WithEvents cmdConsultarLibroRadicador As System.Windows.Forms.Button
    Friend WithEvents dgvCONSULTA_RESOLICE As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRELIFERA As System.Windows.Forms.TextBox
    Friend WithEvents txtRELINURA As System.Windows.Forms.TextBox
    Friend WithEvents TabSolicitante As System.Windows.Forms.TabPage
    Friend WithEvents txtRLSODIRE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRLSONOMB As System.Windows.Forms.TextBox
    Friend WithEvents txtRLSOSEAP As System.Windows.Forms.TextBox
    Friend WithEvents txtRLSOPRAP As System.Windows.Forms.TextBox
    Friend WithEvents txtRLSONUDO As System.Windows.Forms.TextBox
    Friend WithEvents lblDocumento As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblSegundoApellido As System.Windows.Forms.Label
    Friend WithEvents lblPrimerApellido As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLimpiarSolicitante As System.Windows.Forms.Button
    Friend WithEvents cmdAceptarSolicitante As System.Windows.Forms.Button
    Friend WithEvents cmdConsultarSolicitante As System.Windows.Forms.Button
    Friend WithEvents dgvCONSULTA_RELISOLI As System.Windows.Forms.DataGridView
    Friend WithEvents TabPredio As System.Windows.Forms.TabPage
    Friend WithEvents txtRLPRMAIN As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRLPRNUFI As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRLPRCLSE As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRLPRCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtRLPRMUNI As System.Windows.Forms.TextBox
    Friend WithEvents txtRLPRUNPR As System.Windows.Forms.TextBox
    Friend WithEvents txtRLPREDIF As System.Windows.Forms.TextBox
    Friend WithEvents txtRLPRPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtRLPRMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtRLPRBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblUnidadPredial As System.Windows.Forms.Label
    Friend WithEvents lblEdificio As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLimpiarPredio As System.Windows.Forms.Button
    Friend WithEvents cmdAceptarPredio As System.Windows.Forms.Button
    Friend WithEvents cmdConsultarPredio As System.Windows.Forms.Button
    Friend WithEvents dgvCONSULTA_RELIPRED As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRELIMAIN As System.Windows.Forms.TextBox
    Friend WithEvents txtRELIVIGE As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TabPropietario As System.Windows.Forms.TabPage
    Friend WithEvents txtRLPRDERE As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRLPRNOMB As System.Windows.Forms.TextBox
    Friend WithEvents txtRLPRSEAP As System.Windows.Forms.TextBox
    Friend WithEvents txtRLPRPRAP As System.Windows.Forms.TextBox
    Friend WithEvents txtRLPRNUDO As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLimpiarPropietario As System.Windows.Forms.Button
    Friend WithEvents cmdAceptarPropietario As System.Windows.Forms.Button
    Friend WithEvents cmdConsultarPropietario As System.Windows.Forms.Button
    Friend WithEvents dgvCONSULTA_RELIPROP As System.Windows.Forms.DataGridView
End Class
