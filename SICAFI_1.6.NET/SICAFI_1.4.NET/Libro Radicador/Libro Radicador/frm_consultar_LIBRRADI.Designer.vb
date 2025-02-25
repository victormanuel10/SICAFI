<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_LIBRRADI
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
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraPERIODO = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabRadicado = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtLIRAOFSA = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdLimpiarLibroRadicador = New System.Windows.Forms.Button()
        Me.cmdAceptarLibroRadicador = New System.Windows.Forms.Button()
        Me.cmdConsultarLibroRadicador = New System.Windows.Forms.Button()
        Me.dgvCONSULTA_LIBRRADI = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtLIRAFERA = New System.Windows.Forms.TextBox()
        Me.txtLIRANURA = New System.Windows.Forms.TextBox()
        Me.TabSolicitante = New System.Windows.Forms.TabPage()
        Me.txtLRSODIRE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLRSONOMB = New System.Windows.Forms.TextBox()
        Me.txtLRSOSEAP = New System.Windows.Forms.TextBox()
        Me.txtLRSOPRAP = New System.Windows.Forms.TextBox()
        Me.txtLRSONUDO = New System.Windows.Forms.TextBox()
        Me.lblDocumento = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblSegundoApellido = New System.Windows.Forms.Label()
        Me.lblPrimerApellido = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdLimpiarSolicitante = New System.Windows.Forms.Button()
        Me.cmdAceptarSolicitante = New System.Windows.Forms.Button()
        Me.cmdConsultarSolicitante = New System.Windows.Forms.Button()
        Me.dgvCONSULTA_LIRASOLI = New System.Windows.Forms.DataGridView()
        Me.TabPredio = New System.Windows.Forms.TabPage()
        Me.txtLRPRMAIN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLRPRNUFI = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLRPRCLSE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLRPRCORR = New System.Windows.Forms.TextBox()
        Me.txtLRPRMUNI = New System.Windows.Forms.TextBox()
        Me.txtLRPRUNPR = New System.Windows.Forms.TextBox()
        Me.txtLRPREDIF = New System.Windows.Forms.TextBox()
        Me.txtLRPRPRED = New System.Windows.Forms.TextBox()
        Me.txtLRPRMANZ = New System.Windows.Forms.TextBox()
        Me.txtLRPRBARR = New System.Windows.Forms.TextBox()
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
        Me.dgvCONSULTA_LIRAPRED = New System.Windows.Forms.DataGridView()
        Me.strBARRESTA.SuspendLayout()
        Me.fraPERIODO.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabRadicado.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCONSULTA_LIBRRADI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabSolicitante.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvCONSULTA_LIRASOLI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPredio.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvCONSULTA_LIRAPRED, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 475)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(975, 25)
        Me.strBARRESTA.TabIndex = 86
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
        Me.fraPERIODO.Location = New System.Drawing.Point(12, 12)
        Me.fraPERIODO.Name = "fraPERIODO"
        Me.fraPERIODO.Size = New System.Drawing.Size(951, 447)
        Me.fraPERIODO.TabIndex = 85
        Me.fraPERIODO.TabStop = False
        Me.fraPERIODO.Text = "CONSULTA LIBRO RADICADOR"
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
        Me.TabControl1.Location = New System.Drawing.Point(16, 20)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(918, 355)
        Me.TabControl1.TabIndex = 0
        '
        'TabRadicado
        '
        Me.TabRadicado.BackColor = System.Drawing.SystemColors.Control
        Me.TabRadicado.Controls.Add(Me.Label7)
        Me.TabRadicado.Controls.Add(Me.txtLIRAOFSA)
        Me.TabRadicado.Controls.Add(Me.Label6)
        Me.TabRadicado.Controls.Add(Me.GroupBox1)
        Me.TabRadicado.Controls.Add(Me.dgvCONSULTA_LIBRRADI)
        Me.TabRadicado.Controls.Add(Me.Label1)
        Me.TabRadicado.Controls.Add(Me.Label9)
        Me.TabRadicado.Controls.Add(Me.txtLIRAFERA)
        Me.TabRadicado.Controls.Add(Me.txtLIRANURA)
        Me.TabRadicado.Location = New System.Drawing.Point(4, 24)
        Me.TabRadicado.Name = "TabRadicado"
        Me.TabRadicado.Padding = New System.Windows.Forms.Padding(3)
        Me.TabRadicado.Size = New System.Drawing.Size(910, 327)
        Me.TabRadicado.TabIndex = 0
        Me.TabRadicado.Text = "Radicado"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(597, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 20)
        Me.Label7.TabIndex = 451
        Me.Label7.Text = "Oficio de salida"
        '
        'txtLIRAOFSA
        '
        Me.txtLIRAOFSA.AccessibleDescription = "Oficio de salida"
        Me.txtLIRAOFSA.BackColor = System.Drawing.SystemColors.Window
        Me.txtLIRAOFSA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLIRAOFSA.Location = New System.Drawing.Point(716, 9)
        Me.txtLIRAOFSA.MaxLength = 50
        Me.txtLIRAOFSA.Name = "txtLIRAOFSA"
        Me.txtLIRAOFSA.Size = New System.Drawing.Size(188, 20)
        Me.txtLIRAOFSA.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(493, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 20)
        Me.Label6.TabIndex = 449
        Me.Label6.Text = "(dd-mm-aaaa)"
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
        'dgvCONSULTA_LIBRRADI
        '
        Me.dgvCONSULTA_LIBRRADI.AccessibleDescription = ""
        Me.dgvCONSULTA_LIBRRADI.AllowUserToAddRows = False
        Me.dgvCONSULTA_LIBRRADI.AllowUserToDeleteRows = False
        Me.dgvCONSULTA_LIBRRADI.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA_LIBRRADI.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCONSULTA_LIBRRADI.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCONSULTA_LIBRRADI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCONSULTA_LIBRRADI.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCONSULTA_LIBRRADI.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCONSULTA_LIBRRADI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCONSULTA_LIBRRADI.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCONSULTA_LIBRRADI.ColumnHeadersHeight = 30
        Me.dgvCONSULTA_LIBRRADI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCONSULTA_LIBRRADI.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA_LIBRRADI.Location = New System.Drawing.Point(6, 38)
        Me.dgvCONSULTA_LIBRRADI.MultiSelect = False
        Me.dgvCONSULTA_LIBRRADI.Name = "dgvCONSULTA_LIBRRADI"
        Me.dgvCONSULTA_LIBRRADI.ReadOnly = True
        Me.dgvCONSULTA_LIBRRADI.RowHeadersVisible = False
        Me.dgvCONSULTA_LIBRRADI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA_LIBRRADI.ShowCellToolTips = False
        Me.dgvCONSULTA_LIBRRADI.Size = New System.Drawing.Size(898, 216)
        Me.dgvCONSULTA_LIBRRADI.StandardTab = True
        Me.dgvCONSULTA_LIBRRADI.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 20)
        Me.Label1.TabIndex = 420
        Me.Label1.Text = "Nro. Radicado"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(246, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 20)
        Me.Label9.TabIndex = 448
        Me.Label9.Text = "Fecha de Radicado"
        '
        'txtLIRAFERA
        '
        Me.txtLIRAFERA.AccessibleDescription = "Fecha de Radicado"
        Me.txtLIRAFERA.BackColor = System.Drawing.SystemColors.Window
        Me.txtLIRAFERA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLIRAFERA.Location = New System.Drawing.Point(365, 10)
        Me.txtLIRAFERA.MaxLength = 10
        Me.txtLIRAFERA.Name = "txtLIRAFERA"
        Me.txtLIRAFERA.Size = New System.Drawing.Size(115, 20)
        Me.txtLIRAFERA.TabIndex = 2
        '
        'txtLIRANURA
        '
        Me.txtLIRANURA.AccessibleDescription = "Nro. Radicado"
        Me.txtLIRANURA.BackColor = System.Drawing.SystemColors.Window
        Me.txtLIRANURA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLIRANURA.ForeColor = System.Drawing.Color.Black
        Me.txtLIRANURA.Location = New System.Drawing.Point(125, 11)
        Me.txtLIRANURA.MaxLength = 9
        Me.txtLIRANURA.Name = "txtLIRANURA"
        Me.txtLIRANURA.Size = New System.Drawing.Size(115, 20)
        Me.txtLIRANURA.TabIndex = 1
        '
        'TabSolicitante
        '
        Me.TabSolicitante.BackColor = System.Drawing.SystemColors.Control
        Me.TabSolicitante.Controls.Add(Me.txtLRSODIRE)
        Me.TabSolicitante.Controls.Add(Me.Label2)
        Me.TabSolicitante.Controls.Add(Me.txtLRSONOMB)
        Me.TabSolicitante.Controls.Add(Me.txtLRSOSEAP)
        Me.TabSolicitante.Controls.Add(Me.txtLRSOPRAP)
        Me.TabSolicitante.Controls.Add(Me.txtLRSONUDO)
        Me.TabSolicitante.Controls.Add(Me.lblDocumento)
        Me.TabSolicitante.Controls.Add(Me.lblNombre)
        Me.TabSolicitante.Controls.Add(Me.lblSegundoApellido)
        Me.TabSolicitante.Controls.Add(Me.lblPrimerApellido)
        Me.TabSolicitante.Controls.Add(Me.GroupBox3)
        Me.TabSolicitante.Controls.Add(Me.dgvCONSULTA_LIRASOLI)
        Me.TabSolicitante.Location = New System.Drawing.Point(4, 24)
        Me.TabSolicitante.Name = "TabSolicitante"
        Me.TabSolicitante.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSolicitante.Size = New System.Drawing.Size(910, 327)
        Me.TabSolicitante.TabIndex = 1
        Me.TabSolicitante.Text = "Solicitante(s)"
        '
        'txtLRSODIRE
        '
        Me.txtLRSODIRE.AccessibleDescription = "Dirección"
        Me.txtLRSODIRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRSODIRE.Location = New System.Drawing.Point(601, 35)
        Me.txtLRSODIRE.MaxLength = 20
        Me.txtLRSODIRE.Name = "txtLRSODIRE"
        Me.txtLRSODIRE.Size = New System.Drawing.Size(303, 21)
        Me.txtLRSODIRE.TabIndex = 7
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
        'txtLRSONOMB
        '
        Me.txtLRSONOMB.AccessibleDescription = "Nombre (s)"
        Me.txtLRSONOMB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRSONOMB.Location = New System.Drawing.Point(379, 35)
        Me.txtLRSONOMB.MaxLength = 20
        Me.txtLRSONOMB.Name = "txtLRSONOMB"
        Me.txtLRSONOMB.Size = New System.Drawing.Size(219, 21)
        Me.txtLRSONOMB.TabIndex = 6
        '
        'txtLRSOSEAP
        '
        Me.txtLRSOSEAP.AccessibleDescription = "Segundo apellido"
        Me.txtLRSOSEAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRSOSEAP.Location = New System.Drawing.Point(250, 35)
        Me.txtLRSOSEAP.MaxLength = 15
        Me.txtLRSOSEAP.Name = "txtLRSOSEAP"
        Me.txtLRSOSEAP.Size = New System.Drawing.Size(126, 21)
        Me.txtLRSOSEAP.TabIndex = 5
        '
        'txtLRSOPRAP
        '
        Me.txtLRSOPRAP.AccessibleDescription = "Primer apellido"
        Me.txtLRSOPRAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRSOPRAP.Location = New System.Drawing.Point(121, 35)
        Me.txtLRSOPRAP.MaxLength = 15
        Me.txtLRSOPRAP.Name = "txtLRSOPRAP"
        Me.txtLRSOPRAP.Size = New System.Drawing.Size(126, 21)
        Me.txtLRSOPRAP.TabIndex = 4
        '
        'txtLRSONUDO
        '
        Me.txtLRSONUDO.AccessibleDescription = "Documento"
        Me.txtLRSONUDO.Location = New System.Drawing.Point(6, 35)
        Me.txtLRSONUDO.MaxLength = 14
        Me.txtLRSONUDO.Name = "txtLRSONUDO"
        Me.txtLRSONUDO.Size = New System.Drawing.Size(112, 21)
        Me.txtLRSONUDO.TabIndex = 3
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
        'dgvCONSULTA_LIRASOLI
        '
        Me.dgvCONSULTA_LIRASOLI.AccessibleDescription = ""
        Me.dgvCONSULTA_LIRASOLI.AllowUserToAddRows = False
        Me.dgvCONSULTA_LIRASOLI.AllowUserToDeleteRows = False
        Me.dgvCONSULTA_LIRASOLI.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA_LIRASOLI.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCONSULTA_LIRASOLI.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCONSULTA_LIRASOLI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCONSULTA_LIRASOLI.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCONSULTA_LIRASOLI.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCONSULTA_LIRASOLI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCONSULTA_LIRASOLI.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCONSULTA_LIRASOLI.ColumnHeadersHeight = 30
        Me.dgvCONSULTA_LIRASOLI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCONSULTA_LIRASOLI.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA_LIRASOLI.Location = New System.Drawing.Point(6, 62)
        Me.dgvCONSULTA_LIRASOLI.MultiSelect = False
        Me.dgvCONSULTA_LIRASOLI.Name = "dgvCONSULTA_LIRASOLI"
        Me.dgvCONSULTA_LIRASOLI.ReadOnly = True
        Me.dgvCONSULTA_LIRASOLI.RowHeadersVisible = False
        Me.dgvCONSULTA_LIRASOLI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA_LIRASOLI.ShowCellToolTips = False
        Me.dgvCONSULTA_LIRASOLI.Size = New System.Drawing.Size(898, 192)
        Me.dgvCONSULTA_LIRASOLI.StandardTab = True
        Me.dgvCONSULTA_LIRASOLI.TabIndex = 451
        '
        'TabPredio
        '
        Me.TabPredio.BackColor = System.Drawing.SystemColors.Control
        Me.TabPredio.Controls.Add(Me.txtLRPRMAIN)
        Me.TabPredio.Controls.Add(Me.Label5)
        Me.TabPredio.Controls.Add(Me.txtLRPRNUFI)
        Me.TabPredio.Controls.Add(Me.Label4)
        Me.TabPredio.Controls.Add(Me.txtLRPRCLSE)
        Me.TabPredio.Controls.Add(Me.Label3)
        Me.TabPredio.Controls.Add(Me.txtLRPRCORR)
        Me.TabPredio.Controls.Add(Me.txtLRPRMUNI)
        Me.TabPredio.Controls.Add(Me.txtLRPRUNPR)
        Me.TabPredio.Controls.Add(Me.txtLRPREDIF)
        Me.TabPredio.Controls.Add(Me.txtLRPRPRED)
        Me.TabPredio.Controls.Add(Me.txtLRPRMANZ)
        Me.TabPredio.Controls.Add(Me.txtLRPRBARR)
        Me.TabPredio.Controls.Add(Me.lblUnidadPredial)
        Me.TabPredio.Controls.Add(Me.lblEdificio)
        Me.TabPredio.Controls.Add(Me.lblPredio)
        Me.TabPredio.Controls.Add(Me.lblManzana)
        Me.TabPredio.Controls.Add(Me.lblBarrio)
        Me.TabPredio.Controls.Add(Me.lblCorregimiento)
        Me.TabPredio.Controls.Add(Me.lblMunicipio)
        Me.TabPredio.Controls.Add(Me.GroupBox4)
        Me.TabPredio.Controls.Add(Me.dgvCONSULTA_LIRAPRED)
        Me.TabPredio.Location = New System.Drawing.Point(4, 24)
        Me.TabPredio.Name = "TabPredio"
        Me.TabPredio.Size = New System.Drawing.Size(910, 327)
        Me.TabPredio.TabIndex = 2
        Me.TabPredio.Text = "Predio(s)"
        '
        'txtLRPRMAIN
        '
        Me.txtLRPRMAIN.AccessibleDescription = "Matricula"
        Me.txtLRPRMAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRPRMAIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtLRPRMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRPRMAIN.ForeColor = System.Drawing.Color.Black
        Me.txtLRPRMAIN.Location = New System.Drawing.Point(800, 34)
        Me.txtLRPRMAIN.MaxLength = 9
        Me.txtLRPRMAIN.Name = "txtLRPRMAIN"
        Me.txtLRPRMAIN.Size = New System.Drawing.Size(104, 20)
        Me.txtLRPRMAIN.TabIndex = 17
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
        'txtLRPRNUFI
        '
        Me.txtLRPRNUFI.AccessibleDescription = "Estado"
        Me.txtLRPRNUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRPRNUFI.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtLRPRNUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRPRNUFI.ForeColor = System.Drawing.Color.Black
        Me.txtLRPRNUFI.Location = New System.Drawing.Point(711, 34)
        Me.txtLRPRNUFI.MaxLength = 9
        Me.txtLRPRNUFI.Name = "txtLRPRNUFI"
        Me.txtLRPRNUFI.Size = New System.Drawing.Size(85, 20)
        Me.txtLRPRNUFI.TabIndex = 16
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
        'txtLRPRCLSE
        '
        Me.txtLRPRCLSE.AccessibleDescription = "Sector"
        Me.txtLRPRCLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRPRCLSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtLRPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRPRCLSE.ForeColor = System.Drawing.Color.Black
        Me.txtLRPRCLSE.Location = New System.Drawing.Point(622, 34)
        Me.txtLRPRCLSE.MaxLength = 10
        Me.txtLRPRCLSE.Name = "txtLRPRCLSE"
        Me.txtLRPRCLSE.Size = New System.Drawing.Size(85, 20)
        Me.txtLRPRCLSE.TabIndex = 15
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
        'txtLRPRCORR
        '
        Me.txtLRPRCORR.AccessibleDescription = "Corregimiento"
        Me.txtLRPRCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRPRCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRPRCORR.Location = New System.Drawing.Point(94, 34)
        Me.txtLRPRCORR.MaxLength = 10
        Me.txtLRPRCORR.Name = "txtLRPRCORR"
        Me.txtLRPRCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtLRPRCORR.TabIndex = 9
        '
        'txtLRPRMUNI
        '
        Me.txtLRPRMUNI.AccessibleDescription = "Municipio"
        Me.txtLRPRMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRPRMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRPRMUNI.Location = New System.Drawing.Point(6, 34)
        Me.txtLRPRMUNI.MaxLength = 10
        Me.txtLRPRMUNI.Name = "txtLRPRMUNI"
        Me.txtLRPRMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtLRPRMUNI.TabIndex = 8
        '
        'txtLRPRUNPR
        '
        Me.txtLRPRUNPR.AccessibleDescription = "Unidad predial "
        Me.txtLRPRUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRPRUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRPRUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRPRUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtLRPRUNPR.Location = New System.Drawing.Point(534, 34)
        Me.txtLRPRUNPR.MaxLength = 10
        Me.txtLRPRUNPR.Name = "txtLRPRUNPR"
        Me.txtLRPRUNPR.Size = New System.Drawing.Size(85, 20)
        Me.txtLRPRUNPR.TabIndex = 14
        '
        'txtLRPREDIF
        '
        Me.txtLRPREDIF.AccessibleDescription = "Edificio "
        Me.txtLRPREDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRPREDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRPREDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRPREDIF.ForeColor = System.Drawing.Color.Black
        Me.txtLRPREDIF.Location = New System.Drawing.Point(446, 34)
        Me.txtLRPREDIF.MaxLength = 10
        Me.txtLRPREDIF.Name = "txtLRPREDIF"
        Me.txtLRPREDIF.Size = New System.Drawing.Size(85, 20)
        Me.txtLRPREDIF.TabIndex = 13
        '
        'txtLRPRPRED
        '
        Me.txtLRPRPRED.AccessibleDescription = "Predio "
        Me.txtLRPRPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRPRPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRPRPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRPRPRED.ForeColor = System.Drawing.Color.Black
        Me.txtLRPRPRED.Location = New System.Drawing.Point(358, 34)
        Me.txtLRPRPRED.MaxLength = 10
        Me.txtLRPRPRED.Name = "txtLRPRPRED"
        Me.txtLRPRPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtLRPRPRED.TabIndex = 12
        '
        'txtLRPRMANZ
        '
        Me.txtLRPRMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtLRPRMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRPRMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRPRMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRPRMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtLRPRMANZ.Location = New System.Drawing.Point(270, 34)
        Me.txtLRPRMANZ.MaxLength = 10
        Me.txtLRPRMANZ.Name = "txtLRPRMANZ"
        Me.txtLRPRMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtLRPRMANZ.TabIndex = 11
        '
        'txtLRPRBARR
        '
        Me.txtLRPRBARR.AccessibleDescription = "Barrio "
        Me.txtLRPRBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRPRBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRPRBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRPRBARR.ForeColor = System.Drawing.Color.Black
        Me.txtLRPRBARR.Location = New System.Drawing.Point(182, 34)
        Me.txtLRPRBARR.MaxLength = 10
        Me.txtLRPRBARR.Name = "txtLRPRBARR"
        Me.txtLRPRBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtLRPRBARR.TabIndex = 10
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
        'dgvCONSULTA_LIRAPRED
        '
        Me.dgvCONSULTA_LIRAPRED.AccessibleDescription = ""
        Me.dgvCONSULTA_LIRAPRED.AllowUserToAddRows = False
        Me.dgvCONSULTA_LIRAPRED.AllowUserToDeleteRows = False
        Me.dgvCONSULTA_LIRAPRED.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA_LIRAPRED.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCONSULTA_LIRAPRED.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCONSULTA_LIRAPRED.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCONSULTA_LIRAPRED.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCONSULTA_LIRAPRED.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCONSULTA_LIRAPRED.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCONSULTA_LIRAPRED.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCONSULTA_LIRAPRED.ColumnHeadersHeight = 30
        Me.dgvCONSULTA_LIRAPRED.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCONSULTA_LIRAPRED.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA_LIRAPRED.Location = New System.Drawing.Point(6, 60)
        Me.dgvCONSULTA_LIRAPRED.MultiSelect = False
        Me.dgvCONSULTA_LIRAPRED.Name = "dgvCONSULTA_LIRAPRED"
        Me.dgvCONSULTA_LIRAPRED.ReadOnly = True
        Me.dgvCONSULTA_LIRAPRED.RowHeadersVisible = False
        Me.dgvCONSULTA_LIRAPRED.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA_LIRAPRED.ShowCellToolTips = False
        Me.dgvCONSULTA_LIRAPRED.Size = New System.Drawing.Size(898, 194)
        Me.dgvCONSULTA_LIRAPRED.StandardTab = True
        Me.dgvCONSULTA_LIRAPRED.TabIndex = 451
        '
        'frm_consultar_LIBRRADI
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
        Me.Name = "frm_consultar_LIBRRADI"
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
        CType(Me.dgvCONSULTA_LIBRRADI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabSolicitante.ResumeLayout(False)
        Me.TabSolicitante.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvCONSULTA_LIRASOLI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPredio.ResumeLayout(False)
        Me.TabPredio.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvCONSULTA_LIRAPRED, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraPERIODO As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtLIRANURA As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLIRAFERA As System.Windows.Forms.TextBox
    Friend WithEvents dgvCONSULTA_LIBRRADI As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabRadicado As System.Windows.Forms.TabPage
    Friend WithEvents TabSolicitante As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLimpiarLibroRadicador As System.Windows.Forms.Button
    Friend WithEvents cmdAceptarLibroRadicador As System.Windows.Forms.Button
    Friend WithEvents cmdConsultarLibroRadicador As System.Windows.Forms.Button
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TabPredio As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLimpiarSolicitante As System.Windows.Forms.Button
    Friend WithEvents cmdAceptarSolicitante As System.Windows.Forms.Button
    Friend WithEvents cmdConsultarSolicitante As System.Windows.Forms.Button
    Friend WithEvents dgvCONSULTA_LIRASOLI As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLimpiarPredio As System.Windows.Forms.Button
    Friend WithEvents cmdAceptarPredio As System.Windows.Forms.Button
    Friend WithEvents cmdConsultarPredio As System.Windows.Forms.Button
    Friend WithEvents dgvCONSULTA_LIRAPRED As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtLRSODIRE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLRSONOMB As System.Windows.Forms.TextBox
    Friend WithEvents txtLRSOSEAP As System.Windows.Forms.TextBox
    Friend WithEvents txtLRSOPRAP As System.Windows.Forms.TextBox
    Friend WithEvents txtLRSONUDO As System.Windows.Forms.TextBox
    Friend WithEvents lblDocumento As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblSegundoApellido As System.Windows.Forms.Label
    Friend WithEvents lblPrimerApellido As System.Windows.Forms.Label
    Friend WithEvents txtLRPRMAIN As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLRPRNUFI As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLRPRCLSE As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLRPRCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtLRPRMUNI As System.Windows.Forms.TextBox
    Friend WithEvents txtLRPRUNPR As System.Windows.Forms.TextBox
    Friend WithEvents txtLRPREDIF As System.Windows.Forms.TextBox
    Friend WithEvents txtLRPRPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtLRPRMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtLRPRBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblUnidadPredial As System.Windows.Forms.Label
    Friend WithEvents lblEdificio As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLIRAOFSA As System.Windows.Forms.TextBox
End Class
