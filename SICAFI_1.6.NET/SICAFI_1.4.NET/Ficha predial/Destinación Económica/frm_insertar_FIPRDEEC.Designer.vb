<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_FIPRDEEC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_insertar_FIPRDEEC))
        Me.fraDESTINOECONOMICO = New System.Windows.Forms.GroupBox()
        Me.cboFPDEESTA = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFPDEPORC = New System.Windows.Forms.TextBox()
        Me.lblFPDETOTA = New System.Windows.Forms.Label()
        Me.lblFPDEDESC = New System.Windows.Forms.Label()
        Me.txtFPDESECU = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvFIPRDEEC = New System.Windows.Forms.DataGridView()
        Me.cboFPDEDEEC = New System.Windows.Forms.ComboBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.lbLDestinoEconomico = New System.Windows.Forms.Label()
        Me.lblPorcentaje = New System.Windows.Forms.Label()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BindingSource_FIPRDEEC_1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigator_FIPRDEEC_1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.fraDESTINOECONOMICO.SuspendLayout()
        CType(Me.dgvFIPRDEEC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource_FIPRDEEC_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator_FIPRDEEC_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator_FIPRDEEC_1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraDESTINOECONOMICO
        '
        Me.fraDESTINOECONOMICO.Controls.Add(Me.cboFPDEESTA)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.Label2)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.txtFPDEPORC)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.lblFPDETOTA)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.lblFPDEDESC)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.txtFPDESECU)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.Label6)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.Label1)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.dgvFIPRDEEC)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.cboFPDEDEEC)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.Label63)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.lbLDestinoEconomico)
        Me.fraDESTINOECONOMICO.Controls.Add(Me.lblPorcentaje)
        Me.fraDESTINOECONOMICO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraDESTINOECONOMICO.Location = New System.Drawing.Point(12, 28)
        Me.fraDESTINOECONOMICO.Name = "fraDESTINOECONOMICO"
        Me.fraDESTINOECONOMICO.Size = New System.Drawing.Size(611, 268)
        Me.fraDESTINOECONOMICO.TabIndex = 1
        Me.fraDESTINOECONOMICO.TabStop = False
        Me.fraDESTINOECONOMICO.Text = "INSERTAR DESTINACIÓN ECONÓMICA"
        '
        'cboFPDEESTA
        '
        Me.cboFPDEESTA.AccessibleDescription = "Estado"
        Me.cboFPDEESTA.BackColor = System.Drawing.Color.White
        Me.cboFPDEESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFPDEESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPDEESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFPDEESTA.FormattingEnabled = True
        Me.cboFPDEESTA.Location = New System.Drawing.Point(86, 234)
        Me.cboFPDEESTA.Name = "cboFPDEESTA"
        Me.cboFPDEESTA.Size = New System.Drawing.Size(86, 22)
        Me.cboFPDEESTA.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 234)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 20)
        Me.Label2.TabIndex = 330
        Me.Label2.Text = "Estado"
        '
        'txtFPDEPORC
        '
        Me.txtFPDEPORC.AccessibleDescription = "Porcentaje"
        Me.txtFPDEPORC.Location = New System.Drawing.Point(524, 49)
        Me.txtFPDEPORC.MaxLength = 3
        Me.txtFPDEPORC.Name = "txtFPDEPORC"
        Me.txtFPDEPORC.Size = New System.Drawing.Size(71, 20)
        Me.txtFPDEPORC.TabIndex = 2
        '
        'lblFPDETOTA
        '
        Me.lblFPDETOTA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFPDETOTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPDETOTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPDETOTA.ForeColor = System.Drawing.Color.Black
        Me.lblFPDETOTA.Location = New System.Drawing.Point(524, 234)
        Me.lblFPDETOTA.Name = "lblFPDETOTA"
        Me.lblFPDETOTA.Size = New System.Drawing.Size(71, 20)
        Me.lblFPDETOTA.TabIndex = 328
        Me.lblFPDETOTA.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblFPDEDESC
        '
        Me.lblFPDEDESC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFPDEDESC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPDEDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPDEDESC.ForeColor = System.Drawing.Color.Black
        Me.lblFPDEDESC.Location = New System.Drawing.Point(176, 49)
        Me.lblFPDEDESC.Name = "lblFPDEDESC"
        Me.lblFPDEDESC.Size = New System.Drawing.Size(344, 20)
        Me.lblFPDEDESC.TabIndex = 326
        '
        'txtFPDESECU
        '
        Me.txtFPDESECU.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtFPDESECU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtFPDESECU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPDESECU.ForeColor = System.Drawing.Color.Black
        Me.txtFPDESECU.Location = New System.Drawing.Point(16, 49)
        Me.txtFPDESECU.Name = "txtFPDESECU"
        Me.txtFPDESECU.Size = New System.Drawing.Size(66, 20)
        Me.txtFPDESECU.TabIndex = 325
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(447, 234)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 20)
        Me.Label6.TabIndex = 324
        Me.Label6.Text = "Total "
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
        'dgvFIPRDEEC
        '
        Me.dgvFIPRDEEC.AccessibleDescription = "Destino económico"
        Me.dgvFIPRDEEC.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvFIPRDEEC.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFIPRDEEC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvFIPRDEEC.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvFIPRDEEC.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvFIPRDEEC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvFIPRDEEC.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvFIPRDEEC.ColumnHeadersHeight = 40
        Me.dgvFIPRDEEC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvFIPRDEEC.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvFIPRDEEC.Location = New System.Drawing.Point(16, 77)
        Me.dgvFIPRDEEC.MultiSelect = False
        Me.dgvFIPRDEEC.Name = "dgvFIPRDEEC"
        Me.dgvFIPRDEEC.ReadOnly = True
        Me.dgvFIPRDEEC.RowHeadersVisible = False
        Me.dgvFIPRDEEC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFIPRDEEC.ShowCellToolTips = False
        Me.dgvFIPRDEEC.Size = New System.Drawing.Size(579, 152)
        Me.dgvFIPRDEEC.StandardTab = True
        Me.dgvFIPRDEEC.TabIndex = 321
        '
        'cboFPDEDEEC
        '
        Me.cboFPDEDEEC.AccessibleDescription = "Destinación económica"
        Me.cboFPDEDEEC.BackColor = System.Drawing.Color.White
        Me.cboFPDEDEEC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFPDEDEEC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPDEDEEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFPDEDEEC.Items.AddRange(New Object() {"2004", "2005", "2006", "2007"})
        Me.cboFPDEDEEC.Location = New System.Drawing.Point(86, 49)
        Me.cboFPDEDEEC.MaxDropDownItems = 15
        Me.cboFPDEDEEC.MaxLength = 4
        Me.cboFPDEDEEC.Name = "cboFPDEDEEC"
        Me.cboFPDEDEEC.Size = New System.Drawing.Size(72, 22)
        Me.cboFPDEDEEC.TabIndex = 1
        '
        'Label63
        '
        Me.Label63.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label63.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label63.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.ForeColor = System.Drawing.Color.Black
        Me.Label63.Location = New System.Drawing.Point(176, 26)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(344, 20)
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
        Me.lbLDestinoEconomico.Text = "Destino "
        '
        'lblPorcentaje
        '
        Me.lblPorcentaje.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPorcentaje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPorcentaje.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcentaje.ForeColor = System.Drawing.Color.Black
        Me.lblPorcentaje.Location = New System.Drawing.Point(524, 26)
        Me.lblPorcentaje.Name = "lblPorcentaje"
        Me.lblPorcentaje.Size = New System.Drawing.Size(71, 20)
        Me.lblPorcentaje.TabIndex = 317
        Me.lblPorcentaje.Text = "(%) Porcen."
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(308, 16)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 5
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(201, 16)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 4
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 374)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(638, 25)
        Me.strBARRESTA.TabIndex = 319
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
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.ErrorProvider1.ContainerControl = Me
        '
        'BindingNavigator_FIPRDEEC_1
        '
        Me.BindingNavigator_FIPRDEEC_1.AddNewItem = Nothing
        Me.BindingNavigator_FIPRDEEC_1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator_FIPRDEEC_1.DeleteItem = Nothing
        Me.BindingNavigator_FIPRDEEC_1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator_FIPRDEEC_1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator_FIPRDEEC_1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator_FIPRDEEC_1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator_FIPRDEEC_1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator_FIPRDEEC_1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator_FIPRDEEC_1.Name = "BindingNavigator_FIPRDEEC_1"
        Me.BindingNavigator_FIPRDEEC_1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator_FIPRDEEC_1.Size = New System.Drawing.Size(638, 25)
        Me.BindingNavigator_FIPRDEEC_1.TabIndex = 320
        Me.BindingNavigator_FIPRDEEC_1.Text = "BindingNavigator1"
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 302)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(611, 50)
        Me.GroupBox1.TabIndex = 321
        Me.GroupBox1.TabStop = False
        '
        'frm_insertar_FIPRDEEC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdSALIR
        Me.ClientSize = New System.Drawing.Size(638, 399)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BindingNavigator_FIPRDEEC_1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraDESTINOECONOMICO)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(654, 435)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(654, 435)
        Me.Name = "frm_insertar_FIPRDEEC"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.fraDESTINOECONOMICO.ResumeLayout(False)
        Me.fraDESTINOECONOMICO.PerformLayout()
        CType(Me.dgvFIPRDEEC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource_FIPRDEEC_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator_FIPRDEEC_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator_FIPRDEEC_1.ResumeLayout(False)
        Me.BindingNavigator_FIPRDEEC_1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraDESTINOECONOMICO As System.Windows.Forms.GroupBox
    Friend WithEvents lblFPDETOTA As System.Windows.Forms.Label
    Friend WithEvents lblFPDEDESC As System.Windows.Forms.Label
    Friend WithEvents txtFPDESECU As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvFIPRDEEC As System.Windows.Forms.DataGridView
    Friend WithEvents cboFPDEDEEC As System.Windows.Forms.ComboBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents lbLDestinoEconomico As System.Windows.Forms.Label
    Friend WithEvents lblPorcentaje As System.Windows.Forms.Label
    Friend WithEvents txtFPDEPORC As System.Windows.Forms.TextBox
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents cboFPDEESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents BindingNavigator_FIPRDEEC_1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingSource_FIPRDEEC_1 As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
