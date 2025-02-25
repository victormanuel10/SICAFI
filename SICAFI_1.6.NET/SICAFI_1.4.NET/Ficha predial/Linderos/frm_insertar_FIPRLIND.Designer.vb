<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_FIPRLIND
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_insertar_FIPRLIND))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraDESTINOECONOMICO = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lstFPLICOLI_PREDIO_UNIDAD = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lstFPLICOLI_UNIDAD = New System.Windows.Forms.ListBox()
        Me.lstFPLICOLI_PREDIO = New System.Windows.Forms.ListBox()
        Me.cboFPLIESTA = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFPLICOLI = New System.Windows.Forms.TextBox()
        Me.lblFPLIDESC = New System.Windows.Forms.Label()
        Me.lblFPLISECU = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvFIPRLIND = New System.Windows.Forms.DataGridView()
        Me.cboFPLIPUCA = New System.Windows.Forms.ComboBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.lbLDestinoEconomico = New System.Windows.Forms.Label()
        Me.lblPorcentaje = New System.Windows.Forms.Label()
        Me.BindingSource_FIPRLIND_1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigator_FIPRLIND_1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdZonaVerde = New System.Windows.Forms.Button()
        Me.cmdServidumbre = New System.Windows.Forms.Button()
        Me.cmdCieloAbierto = New System.Windows.Forms.Button()
        Me.cmdSubsuelo = New System.Windows.Forms.Button()
        Me.cmdCubierta = New System.Windows.Forms.Button()
        Me.cmdZonaComun = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraDESTINOECONOMICO.SuspendLayout()
        CType(Me.dgvFIPRLIND, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource_FIPRLIND_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator_FIPRLIND_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator_FIPRLIND_1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 560)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(806, 50)
        Me.GroupBox1.TabIndex = 324
        Me.GroupBox1.TabStop = False
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(297, 17)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 4
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(404, 17)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 5
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 633)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(832, 25)
        Me.strBARRESTA.TabIndex = 323
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
        'fraDESTINOECONOMICO
        '
        Me.fraDESTINOECONOMICO.Controls.Add(Me.Label5)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.lstFPLICOLI_PREDIO_UNIDAD)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.Label4)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.Label3)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.lstFPLICOLI_UNIDAD)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.lstFPLICOLI_PREDIO)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.cboFPLIESTA)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.Label2)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.txtFPLICOLI)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.lblFPLIDESC)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.lblFPLISECU)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.Label1)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.dgvFIPRLIND)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.cboFPLIPUCA)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.Label63)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.lbLDestinoEconomico)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.lblPorcentaje)
        Me.fraDESTINOECONOMICO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraDESTINOECONOMICO.Location = New System.Drawing.Point(12, 28)
        Me.fraDESTINOECONOMICO.Name = "fraDESTINOECONOMICO"
        Me.fraDESTINOECONOMICO.Size = New System.Drawing.Size(806, 471)
        Me.fraDESTINOECONOMICO.TabIndex = 322
        Me.fraDESTINOECONOMICO.TabStop = False
        Me.fraDESTINOECONOMICO.Text = "INSERTAR LINDERO"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(278, 272)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(253, 20)
        Me.Label5.TabIndex = 336
        Me.Label5.Text = "Predio - Unidad predial"
        '
        'lstFPLICOLI_PREDIO_UNIDAD
        '
        Me.lstFPLICOLI_PREDIO_UNIDAD.FormattingEnabled = True
        Me.lstFPLICOLI_PREDIO_UNIDAD.Location = New System.Drawing.Point(278, 298)
        Me.lstFPLICOLI_PREDIO_UNIDAD.Name = "lstFPLICOLI_PREDIO_UNIDAD"
        Me.lstFPLICOLI_PREDIO_UNIDAD.Size = New System.Drawing.Size(253, 160)
        Me.lstFPLICOLI_PREDIO_UNIDAD.TabIndex = 335
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(537, 272)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(251, 20)
        Me.Label4.TabIndex = 334
        Me.Label4.Text = "Unidad predial"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 272)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(256, 20)
        Me.Label3.TabIndex = 333
        Me.Label3.Text = "Predio"
        '
        'lstFPLICOLI_UNIDAD
        '
        Me.lstFPLICOLI_UNIDAD.FormattingEnabled = True
        Me.lstFPLICOLI_UNIDAD.Location = New System.Drawing.Point(537, 298)
        Me.lstFPLICOLI_UNIDAD.Name = "lstFPLICOLI_UNIDAD"
        Me.lstFPLICOLI_UNIDAD.Size = New System.Drawing.Size(251, 160)
        Me.lstFPLICOLI_UNIDAD.TabIndex = 332
        '
        'lstFPLICOLI_PREDIO
        '
        Me.lstFPLICOLI_PREDIO.FormattingEnabled = True
        Me.lstFPLICOLI_PREDIO.Location = New System.Drawing.Point(16, 298)
        Me.lstFPLICOLI_PREDIO.Name = "lstFPLICOLI_PREDIO"
        Me.lstFPLICOLI_PREDIO.Size = New System.Drawing.Size(256, 160)
        Me.lstFPLICOLI_PREDIO.TabIndex = 331
        '
        'cboFPLIESTA
        '
        Me.cboFPLIESTA.AccessibleDescription = "Estado"
        Me.cboFPLIESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFPLIESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPLIESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFPLIESTA.FormattingEnabled = True
        Me.cboFPLIESTA.Location = New System.Drawing.Point(691, 49)
        Me.cboFPLIESTA.Name = "cboFPLIESTA"
        Me.cboFPLIESTA.Size = New System.Drawing.Size(97, 22)
        Me.cboFPLIESTA.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(691, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 20)
        Me.Label2.TabIndex = 330
        Me.Label2.Text = "Estado"
        '
        'txtFPLICOLI
        '
        Me.txtFPLICOLI.AccessibleDescription = "Colindante"
        Me.txtFPLICOLI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFPLICOLI.Location = New System.Drawing.Point(309, 49)
        Me.txtFPLICOLI.MaxLength = 30
        Me.txtFPLICOLI.Name = "txtFPLICOLI"
        Me.txtFPLICOLI.Size = New System.Drawing.Size(378, 20)
        Me.txtFPLICOLI.TabIndex = 2
        '
        'lblFPLIDESC
        '
        Me.lblFPLIDESC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFPLIDESC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPLIDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPLIDESC.ForeColor = System.Drawing.Color.Black
        Me.lblFPLIDESC.Location = New System.Drawing.Point(176, 49)
        Me.lblFPLIDESC.Name = "lblFPLIDESC"
        Me.lblFPLIDESC.Size = New System.Drawing.Size(129, 20)
        Me.lblFPLIDESC.TabIndex = 326
        '
        'lblFPLISECU
        '
        Me.lblFPLISECU.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFPLISECU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPLISECU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPLISECU.ForeColor = System.Drawing.Color.Black
        Me.lblFPLISECU.Location = New System.Drawing.Point(16, 49)
        Me.lblFPLISECU.Name = "lblFPLISECU"
        Me.lblFPLISECU.Size = New System.Drawing.Size(66, 20)
        Me.lblFPLISECU.TabIndex = 325
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 20)
        Me.Label1.TabIndex = 322
        Me.Label1.Text = "Secuencia"
        '
        'dgvFIPRLIND
        '
        Me.dgvFIPRLIND.AccessibleDescription = "Lindero"
        Me.dgvFIPRLIND.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvFIPRLIND.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFIPRLIND.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvFIPRLIND.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvFIPRLIND.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvFIPRLIND.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvFIPRLIND.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvFIPRLIND.ColumnHeadersHeight = 40
        Me.dgvFIPRLIND.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvFIPRLIND.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvFIPRLIND.Location = New System.Drawing.Point(16, 77)
        Me.dgvFIPRLIND.MultiSelect = False
        Me.dgvFIPRLIND.Name = "dgvFIPRLIND"
        Me.dgvFIPRLIND.ReadOnly = True
        Me.dgvFIPRLIND.RowHeadersVisible = False
        Me.dgvFIPRLIND.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFIPRLIND.ShowCellToolTips = False
        Me.dgvFIPRLIND.Size = New System.Drawing.Size(772, 187)
        Me.dgvFIPRLIND.StandardTab = True
        Me.dgvFIPRLIND.TabIndex = 321
        '
        'cboFPLIPUCA
        '
        Me.cboFPLIPUCA.AccessibleDescription = "Punto cardinal"
        Me.cboFPLIPUCA.BackColor = System.Drawing.Color.White
        Me.cboFPLIPUCA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFPLIPUCA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPLIPUCA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFPLIPUCA.Items.AddRange(New Object() {"2004", "2005", "2006", "2007"})
        Me.cboFPLIPUCA.Location = New System.Drawing.Point(86, 49)
        Me.cboFPLIPUCA.MaxDropDownItems = 15
        Me.cboFPLIPUCA.MaxLength = 4
        Me.cboFPLIPUCA.Name = "cboFPLIPUCA"
        Me.cboFPLIPUCA.Size = New System.Drawing.Size(86, 22)
        Me.cboFPLIPUCA.TabIndex = 1
        '
        'Label63
        '
        Me.Label63.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label63.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label63.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.ForeColor = System.Drawing.Color.Black
        Me.Label63.Location = New System.Drawing.Point(176, 26)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(129, 20)
        Me.Label63.TabIndex = 319
        Me.Label63.Text = "Descripción"
        '
        'lbLDestinoEconomico
        '
        Me.lbLDestinoEconomico.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lbLDestinoEconomico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbLDestinoEconomico.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLDestinoEconomico.ForeColor = System.Drawing.Color.Black
        Me.lbLDestinoEconomico.Location = New System.Drawing.Point(86, 26)
        Me.lbLDestinoEconomico.Name = "lbLDestinoEconomico"
        Me.lbLDestinoEconomico.Size = New System.Drawing.Size(86, 20)
        Me.lbLDestinoEconomico.TabIndex = 318
        Me.lbLDestinoEconomico.Text = "Punto cardinal"
        '
        'lblPorcentaje
        '
        Me.lblPorcentaje.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPorcentaje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPorcentaje.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcentaje.ForeColor = System.Drawing.Color.Black
        Me.lblPorcentaje.Location = New System.Drawing.Point(309, 26)
        Me.lblPorcentaje.Name = "lblPorcentaje"
        Me.lblPorcentaje.Size = New System.Drawing.Size(378, 20)
        Me.lblPorcentaje.TabIndex = 317
        Me.lblPorcentaje.Text = "Colindante"
        '
        'BindingNavigator_FIPRLIND_1
        '
        Me.BindingNavigator_FIPRLIND_1.AddNewItem = Nothing
        Me.BindingNavigator_FIPRLIND_1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator_FIPRLIND_1.DeleteItem = Nothing
        Me.BindingNavigator_FIPRLIND_1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator_FIPRLIND_1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator_FIPRLIND_1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator_FIPRLIND_1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator_FIPRLIND_1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator_FIPRLIND_1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator_FIPRLIND_1.Name = "BindingNavigator_FIPRLIND_1"
        Me.BindingNavigator_FIPRLIND_1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator_FIPRLIND_1.Size = New System.Drawing.Size(832, 25)
        Me.BindingNavigator_FIPRLIND_1.TabIndex = 325
        Me.BindingNavigator_FIPRLIND_1.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Número total de elementos"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Mover primero"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Mover anterior"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Posición"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Posición actual"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Mover siguiente"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Mover último"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdZonaVerde)
        Me.GroupBox2.Controls.Add(Me.cmdServidumbre)
        Me.GroupBox2.Controls.Add(Me.cmdCieloAbierto)
        Me.GroupBox2.Controls.Add(Me.cmdSubsuelo)
        Me.GroupBox2.Controls.Add(Me.cmdCubierta)
        Me.GroupBox2.Controls.Add(Me.cmdZonaComun)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 505)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(806, 50)
        Me.GroupBox2.TabIndex = 328
        Me.GroupBox2.TabStop = False
        '
        'cmdZonaVerde
        '
        Me.cmdZonaVerde.AccessibleDescription = "Zona verde"
        Me.cmdZonaVerde.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdZonaVerde.Location = New System.Drawing.Point(663, 16)
        Me.cmdZonaVerde.Name = "cmdZonaVerde"
        Me.cmdZonaVerde.Size = New System.Drawing.Size(127, 23)
        Me.cmdZonaVerde.TabIndex = 9
        Me.cmdZonaVerde.Text = "Zona verde"
        Me.cmdZonaVerde.UseVisualStyleBackColor = True
        '
        'cmdServidumbre
        '
        Me.cmdServidumbre.AccessibleDescription = "Servidumbre"
        Me.cmdServidumbre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdServidumbre.Location = New System.Drawing.Point(537, 16)
        Me.cmdServidumbre.Name = "cmdServidumbre"
        Me.cmdServidumbre.Size = New System.Drawing.Size(120, 23)
        Me.cmdServidumbre.TabIndex = 8
        Me.cmdServidumbre.Text = "Servidumbre"
        Me.cmdServidumbre.UseVisualStyleBackColor = True
        '
        'cmdCieloAbierto
        '
        Me.cmdCieloAbierto.AccessibleDescription = "Cielo abierto"
        Me.cmdCieloAbierto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCieloAbierto.Location = New System.Drawing.Point(404, 16)
        Me.cmdCieloAbierto.Name = "cmdCieloAbierto"
        Me.cmdCieloAbierto.Size = New System.Drawing.Size(127, 23)
        Me.cmdCieloAbierto.TabIndex = 7
        Me.cmdCieloAbierto.Text = "Cielo abierto"
        Me.cmdCieloAbierto.UseVisualStyleBackColor = True
        '
        'cmdSubsuelo
        '
        Me.cmdSubsuelo.AccessibleDescription = "Subsuelo"
        Me.cmdSubsuelo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSubsuelo.Location = New System.Drawing.Point(145, 16)
        Me.cmdSubsuelo.Name = "cmdSubsuelo"
        Me.cmdSubsuelo.Size = New System.Drawing.Size(127, 23)
        Me.cmdSubsuelo.TabIndex = 6
        Me.cmdSubsuelo.Text = "Subsuelo"
        Me.cmdSubsuelo.UseVisualStyleBackColor = True
        '
        'cmdCubierta
        '
        Me.cmdCubierta.AccessibleDescription = "Cubierta"
        Me.cmdCubierta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCubierta.Location = New System.Drawing.Point(18, 16)
        Me.cmdCubierta.Name = "cmdCubierta"
        Me.cmdCubierta.Size = New System.Drawing.Size(121, 23)
        Me.cmdCubierta.TabIndex = 4
        Me.cmdCubierta.Text = "Cubierta"
        Me.cmdCubierta.UseVisualStyleBackColor = True
        '
        'cmdZonaComun
        '
        Me.cmdZonaComun.AccessibleDescription = "Zona comun"
        Me.cmdZonaComun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdZonaComun.Location = New System.Drawing.Point(278, 16)
        Me.cmdZonaComun.Name = "cmdZonaComun"
        Me.cmdZonaComun.Size = New System.Drawing.Size(120, 23)
        Me.cmdZonaComun.TabIndex = 5
        Me.cmdZonaComun.Text = "Zona comun"
        Me.cmdZonaComun.UseVisualStyleBackColor = True
        '
        'frm_insertar_FIPRLIND
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdSALIR
        Me.ClientSize = New System.Drawing.Size(832, 658)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BindingNavigator_FIPRLIND_1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraDESTINOECONOMICO)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(848, 694)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(848, 694)
        Me.Name = "frm_insertar_FIPRLIND"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraDESTINOECONOMICO.ResumeLayout(False)
        Me.fraDESTINOECONOMICO.PerformLayout()
        CType(Me.dgvFIPRLIND, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource_FIPRLIND_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator_FIPRLIND_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator_FIPRLIND_1.ResumeLayout(False)
        Me.BindingNavigator_FIPRLIND_1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraDESTINOECONOMICO As System.Windows.Forms.GroupBox
    Friend WithEvents cboFPLIESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFPLICOLI As System.Windows.Forms.TextBox
    Friend WithEvents lblFPLIDESC As System.Windows.Forms.Label
    Friend WithEvents lblFPLISECU As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvFIPRLIND As System.Windows.Forms.DataGridView
    Friend WithEvents cboFPLIPUCA As System.Windows.Forms.ComboBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents lbLDestinoEconomico As System.Windows.Forms.Label
    Friend WithEvents lblPorcentaje As System.Windows.Forms.Label
    Friend WithEvents BindingSource_FIPRLIND_1 As System.Windows.Forms.BindingSource
    Friend WithEvents BindingNavigator_FIPRLIND_1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lstFPLICOLI_PREDIO As System.Windows.Forms.ListBox
    Friend WithEvents lstFPLICOLI_UNIDAD As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lstFPLICOLI_PREDIO_UNIDAD As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCieloAbierto As System.Windows.Forms.Button
    Friend WithEvents cmdSubsuelo As System.Windows.Forms.Button
    Friend WithEvents cmdCubierta As System.Windows.Forms.Button
    Friend WithEvents cmdZonaComun As System.Windows.Forms.Button
    Friend WithEvents cmdZonaVerde As System.Windows.Forms.Button
    Friend WithEvents cmdServidumbre As System.Windows.Forms.Button
End Class
