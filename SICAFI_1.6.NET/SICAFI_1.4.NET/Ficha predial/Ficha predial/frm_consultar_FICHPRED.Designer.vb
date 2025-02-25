<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_FICHPRED
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consultar_FICHPRED))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraCONSFICHPRED = New System.Windows.Forms.GroupBox()
        Me.BindingNavigator_FICHPRED_1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdACEPTAR = New System.Windows.Forms.Button()
        Me.dgvFICHPRED = New System.Windows.Forms.DataGridView()
        Me.fraFIPRCECA = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboFIPRCLSE = New System.Windows.Forms.ComboBox()
        Me.lblFIPRCLSE = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtFIPRCORR = New System.Windows.Forms.TextBox()
        Me.txtFIPRMUNI = New System.Windows.Forms.TextBox()
        Me.txtFIPRPRED = New System.Windows.Forms.TextBox()
        Me.txtFIPRMANZ = New System.Windows.Forms.TextBox()
        Me.txtFIPRBARR = New System.Windows.Forms.TextBox()
        Me.lblCodigoActual = New System.Windows.Forms.Label()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.lblManzana = New System.Windows.Forms.Label()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFIPRMAIN = New System.Windows.Forms.TextBox()
        Me.txtFIPRNUDO = New System.Windows.Forms.TextBox()
        Me.txtFIPRDIRE = New System.Windows.Forms.TextBox()
        Me.txtFIPRNUFI = New System.Windows.Forms.TextBox()
        Me.rbdFIPRDIRE = New System.Windows.Forms.RadioButton()
        Me.rbdFIPRMAIN = New System.Windows.Forms.RadioButton()
        Me.rbdFIPRNUDO = New System.Windows.Forms.RadioButton()
        Me.rbdFIPRCECA = New System.Windows.Forms.RadioButton()
        Me.rbdFIPRNUFI = New System.Windows.Forms.RadioButton()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdCONSULTAR = New System.Windows.Forms.Button()
        Me.BindingSource_FICHPRED_1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.strBARRESTA.SuspendLayout()
        Me.fraCONSFICHPRED.SuspendLayout()
        CType(Me.BindingNavigator_FICHPRED_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator_FICHPRED_1.SuspendLayout()
        CType(Me.dgvFICHPRED, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraFIPRCECA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.BindingSource_FICHPRED_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 503)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(868, 25)
        Me.strBARRESTA.TabIndex = 34
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
        'fraCONSFICHPRED
        '
        Me.fraCONSFICHPRED.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraCONSFICHPRED.BackColor = System.Drawing.SystemColors.Control
        Me.fraCONSFICHPRED.Controls.Add(Me.BindingNavigator_FICHPRED_1)
        Me.fraCONSFICHPRED.Controls.Add(Me.cmdACEPTAR)
        Me.fraCONSFICHPRED.Controls.Add(Me.dgvFICHPRED)
        Me.fraCONSFICHPRED.Controls.Add(Me.fraFIPRCECA)
        Me.fraCONSFICHPRED.Controls.Add(Me.GroupBox1)
        Me.fraCONSFICHPRED.Controls.Add(Me.cmdSALIR)
        Me.fraCONSFICHPRED.Controls.Add(Me.cmdCONSULTAR)
        Me.fraCONSFICHPRED.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraCONSFICHPRED.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraCONSFICHPRED.Location = New System.Drawing.Point(12, 12)
        Me.fraCONSFICHPRED.Name = "fraCONSFICHPRED"
        Me.fraCONSFICHPRED.Size = New System.Drawing.Size(844, 476)
        Me.fraCONSFICHPRED.TabIndex = 33
        Me.fraCONSFICHPRED.TabStop = False
        Me.fraCONSFICHPRED.Text = "CONSULTAR FICHA PREDIAL"
        '
        'BindingNavigator_FICHPRED_1
        '
        Me.BindingNavigator_FICHPRED_1.AddNewItem = Nothing
        Me.BindingNavigator_FICHPRED_1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator_FICHPRED_1.DeleteItem = Nothing
        Me.BindingNavigator_FICHPRED_1.Dock = System.Windows.Forms.DockStyle.None
        Me.BindingNavigator_FICHPRED_1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator_FICHPRED_1.Location = New System.Drawing.Point(18, 200)
        Me.BindingNavigator_FICHPRED_1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator_FICHPRED_1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator_FICHPRED_1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator_FICHPRED_1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator_FICHPRED_1.Name = "BindingNavigator_FICHPRED_1"
        Me.BindingNavigator_FICHPRED_1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator_FICHPRED_1.Size = New System.Drawing.Size(211, 25)
        Me.BindingNavigator_FICHPRED_1.TabIndex = 324
        Me.BindingNavigator_FICHPRED_1.Text = "BindingNavigator1"
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
        'cmdACEPTAR
        '
        Me.cmdACEPTAR.AccessibleDescription = "Aceptar"
        Me.cmdACEPTAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdACEPTAR.Image = Global.SICAFI.My.Resources.Resources._208
        Me.cmdACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdACEPTAR.Location = New System.Drawing.Point(617, 435)
        Me.cmdACEPTAR.Name = "cmdACEPTAR"
        Me.cmdACEPTAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdACEPTAR.TabIndex = 10
        Me.cmdACEPTAR.Text = "&Aceptar"
        Me.cmdACEPTAR.UseVisualStyleBackColor = True
        '
        'dgvFICHPRED
        '
        Me.dgvFICHPRED.AccessibleDescription = "Destino económico"
        Me.dgvFICHPRED.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvFICHPRED.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFICHPRED.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFICHPRED.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvFICHPRED.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvFICHPRED.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvFICHPRED.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvFICHPRED.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvFICHPRED.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvFICHPRED.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvFICHPRED.Location = New System.Drawing.Point(18, 231)
        Me.dgvFICHPRED.Name = "dgvFICHPRED"
        Me.dgvFICHPRED.ReadOnly = True
        Me.dgvFICHPRED.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFICHPRED.ShowCellToolTips = False
        Me.dgvFICHPRED.Size = New System.Drawing.Size(807, 198)
        Me.dgvFICHPRED.StandardTab = True
        Me.dgvFICHPRED.TabIndex = 9
        '
        'fraFIPRCECA
        '
        Me.fraFIPRCECA.Controls.Add(Me.Label7)
        Me.fraFIPRCECA.Controls.Add(Me.Label8)
        Me.fraFIPRCECA.Controls.Add(Me.cboFIPRCLSE)
        Me.fraFIPRCECA.Controls.Add(Me.lblFIPRCLSE)
        Me.fraFIPRCECA.Controls.Add(Me.Label33)
        Me.fraFIPRCECA.Controls.Add(Me.txtFIPRCORR)
        Me.fraFIPRCECA.Controls.Add(Me.txtFIPRMUNI)
        Me.fraFIPRCECA.Controls.Add(Me.txtFIPRPRED)
        Me.fraFIPRCECA.Controls.Add(Me.txtFIPRMANZ)
        Me.fraFIPRCECA.Controls.Add(Me.txtFIPRBARR)
        Me.fraFIPRCECA.Controls.Add(Me.lblCodigoActual)
        Me.fraFIPRCECA.Controls.Add(Me.lblPredio)
        Me.fraFIPRCECA.Controls.Add(Me.lblManzana)
        Me.fraFIPRCECA.Controls.Add(Me.lblBarrio)
        Me.fraFIPRCECA.Controls.Add(Me.lblCorregimiento)
        Me.fraFIPRCECA.Controls.Add(Me.lblMunicipio)
        Me.fraFIPRCECA.Controls.Add(Me.lblCodigo)
        Me.fraFIPRCECA.Location = New System.Drawing.Point(18, 185)
        Me.fraFIPRCECA.Name = "fraFIPRCECA"
        Me.fraFIPRCECA.Size = New System.Drawing.Size(807, 11)
        Me.fraFIPRCECA.TabIndex = 303
        Me.fraFIPRCECA.TabStop = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(653, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(132, 20)
        Me.Label7.TabIndex = 329
        Me.Label7.Text = "Descripción"
        '
        'Label8
        '
        Me.Label8.AccessibleDescription = ""
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(565, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 20)
        Me.Label8.TabIndex = 328
        Me.Label8.Text = "Clase o sector"
        '
        'cboFIPRCLSE
        '
        Me.cboFIPRCLSE.AccessibleDescription = "Clase o sector "
        Me.cboFIPRCLSE.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboFIPRCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFIPRCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFIPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFIPRCLSE.Location = New System.Drawing.Point(565, 63)
        Me.cboFIPRCLSE.MaxDropDownItems = 5
        Me.cboFIPRCLSE.MaxLength = 1
        Me.cboFIPRCLSE.Name = "cboFIPRCLSE"
        Me.cboFIPRCLSE.Size = New System.Drawing.Size(84, 22)
        Me.cboFIPRCLSE.TabIndex = 7
        '
        'lblFIPRCLSE
        '
        Me.lblFIPRCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFIPRCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFIPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFIPRCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblFIPRCLSE.Location = New System.Drawing.Point(653, 63)
        Me.lblFIPRCLSE.Name = "lblFIPRCLSE"
        Me.lblFIPRCLSE.Size = New System.Drawing.Size(132, 20)
        Me.lblFIPRCLSE.TabIndex = 327
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(18, 17)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(767, 20)
        Me.Label33.TabIndex = 319
        Me.Label33.Text = "CEDULA CATASTRAL ACTUAL"
        '
        'txtFIPRCORR
        '
        Me.txtFIPRCORR.AccessibleDescription = "Corregimiento"
        Me.txtFIPRCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRCORR.Location = New System.Drawing.Point(197, 63)
        Me.txtFIPRCORR.MaxLength = 2
        Me.txtFIPRCORR.Name = "txtFIPRCORR"
        Me.txtFIPRCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRCORR.TabIndex = 6
        '
        'txtFIPRMUNI
        '
        Me.txtFIPRMUNI.AccessibleDescription = "Municipio"
        Me.txtFIPRMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMUNI.Location = New System.Drawing.Point(109, 63)
        Me.txtFIPRMUNI.Name = "txtFIPRMUNI"
        Me.txtFIPRMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRMUNI.TabIndex = 5
        '
        'txtFIPRPRED
        '
        Me.txtFIPRPRED.AccessibleDescription = "Predio "
        Me.txtFIPRPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRPRED.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRPRED.Location = New System.Drawing.Point(461, 63)
        Me.txtFIPRPRED.MaxLength = 5
        Me.txtFIPRPRED.Name = "txtFIPRPRED"
        Me.txtFIPRPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRPRED.TabIndex = 9
        '
        'txtFIPRMANZ
        '
        Me.txtFIPRMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtFIPRMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRMANZ.Location = New System.Drawing.Point(373, 63)
        Me.txtFIPRMANZ.MaxLength = 3
        Me.txtFIPRMANZ.Name = "txtFIPRMANZ"
        Me.txtFIPRMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRMANZ.TabIndex = 8
        '
        'txtFIPRBARR
        '
        Me.txtFIPRBARR.AccessibleDescription = "Barrio "
        Me.txtFIPRBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRBARR.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRBARR.Location = New System.Drawing.Point(285, 63)
        Me.txtFIPRBARR.MaxLength = 3
        Me.txtFIPRBARR.Name = "txtFIPRBARR"
        Me.txtFIPRBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRBARR.TabIndex = 7
        '
        'lblCodigoActual
        '
        Me.lblCodigoActual.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigoActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigoActual.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoActual.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoActual.Location = New System.Drawing.Point(18, 63)
        Me.lblCodigoActual.Name = "lblCodigoActual"
        Me.lblCodigoActual.Size = New System.Drawing.Size(85, 20)
        Me.lblCodigoActual.TabIndex = 313
        Me.lblCodigoActual.Text = "Código Actual"
        '
        'lblPredio
        '
        Me.lblPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredio.ForeColor = System.Drawing.Color.Black
        Me.lblPredio.Location = New System.Drawing.Point(461, 40)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(84, 20)
        Me.lblPredio.TabIndex = 310
        Me.lblPredio.Text = "Predio"
        '
        'lblManzana
        '
        Me.lblManzana.AccessibleDescription = ""
        Me.lblManzana.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblManzana.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblManzana.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManzana.ForeColor = System.Drawing.Color.Black
        Me.lblManzana.Location = New System.Drawing.Point(373, 40)
        Me.lblManzana.Name = "lblManzana"
        Me.lblManzana.Size = New System.Drawing.Size(84, 20)
        Me.lblManzana.TabIndex = 309
        Me.lblManzana.Text = "Manza / Vered"
        '
        'lblBarrio
        '
        Me.lblBarrio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblBarrio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBarrio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarrio.ForeColor = System.Drawing.Color.Black
        Me.lblBarrio.Location = New System.Drawing.Point(285, 40)
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Size = New System.Drawing.Size(84, 20)
        Me.lblBarrio.TabIndex = 308
        Me.lblBarrio.Text = "Barrio"
        '
        'lblCorregimiento
        '
        Me.lblCorregimiento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCorregimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorregimiento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorregimiento.ForeColor = System.Drawing.Color.Black
        Me.lblCorregimiento.Location = New System.Drawing.Point(197, 40)
        Me.lblCorregimiento.Name = "lblCorregimiento"
        Me.lblCorregimiento.Size = New System.Drawing.Size(84, 20)
        Me.lblCorregimiento.TabIndex = 314
        Me.lblCorregimiento.Text = "Corregimiento"
        '
        'lblMunicipio
        '
        Me.lblMunicipio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblMunicipio.Location = New System.Drawing.Point(109, 40)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(84, 20)
        Me.lblMunicipio.TabIndex = 321
        Me.lblMunicipio.Text = "Municipio"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(18, 40)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(85, 20)
        Me.lblCodigo.TabIndex = 320
        Me.lblCodigo.Text = "CODIGO"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtFIPRMAIN)
        Me.GroupBox1.Controls.Add(Me.txtFIPRNUDO)
        Me.GroupBox1.Controls.Add(Me.txtFIPRDIRE)
        Me.GroupBox1.Controls.Add(Me.txtFIPRNUFI)
        Me.GroupBox1.Controls.Add(Me.rbdFIPRDIRE)
        Me.GroupBox1.Controls.Add(Me.rbdFIPRMAIN)
        Me.GroupBox1.Controls.Add(Me.rbdFIPRNUDO)
        Me.GroupBox1.Controls.Add(Me.rbdFIPRCECA)
        Me.GroupBox1.Controls.Add(Me.rbdFIPRNUFI)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(807, 159)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'txtFIPRMAIN
        '
        Me.txtFIPRMAIN.AccessibleDescription = "Matricula inmobiliaria"
        Me.txtFIPRMAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMAIN.Location = New System.Drawing.Point(197, 99)
        Me.txtFIPRMAIN.MaxLength = 11
        Me.txtFIPRMAIN.Name = "txtFIPRMAIN"
        Me.txtFIPRMAIN.Size = New System.Drawing.Size(173, 20)
        Me.txtFIPRMAIN.TabIndex = 4
        '
        'txtFIPRNUDO
        '
        Me.txtFIPRNUDO.AccessibleDescription = "Nro. Documento"
        Me.txtFIPRNUDO.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRNUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRNUDO.Location = New System.Drawing.Point(197, 72)
        Me.txtFIPRNUDO.MaxLength = 14
        Me.txtFIPRNUDO.Name = "txtFIPRNUDO"
        Me.txtFIPRNUDO.Size = New System.Drawing.Size(173, 20)
        Me.txtFIPRNUDO.TabIndex = 3
        '
        'txtFIPRDIRE
        '
        Me.txtFIPRDIRE.AccessibleDescription = "Dirección del predio"
        Me.txtFIPRDIRE.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRDIRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRDIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRDIRE.Location = New System.Drawing.Point(197, 46)
        Me.txtFIPRDIRE.MaxLength = 49
        Me.txtFIPRDIRE.Name = "txtFIPRDIRE"
        Me.txtFIPRDIRE.Size = New System.Drawing.Size(413, 20)
        Me.txtFIPRDIRE.TabIndex = 2
        '
        'txtFIPRNUFI
        '
        Me.txtFIPRNUFI.AccessibleDescription = "Nro. Ficha predial"
        Me.txtFIPRNUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRNUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRNUFI.Location = New System.Drawing.Point(197, 20)
        Me.txtFIPRNUFI.MaxLength = 9
        Me.txtFIPRNUFI.Name = "txtFIPRNUFI"
        Me.txtFIPRNUFI.Size = New System.Drawing.Size(173, 20)
        Me.txtFIPRNUFI.TabIndex = 1
        '
        'rbdFIPRDIRE
        '
        Me.rbdFIPRDIRE.AutoSize = True
        Me.rbdFIPRDIRE.Location = New System.Drawing.Point(18, 45)
        Me.rbdFIPRDIRE.Name = "rbdFIPRDIRE"
        Me.rbdFIPRDIRE.Size = New System.Drawing.Size(135, 19)
        Me.rbdFIPRDIRE.TabIndex = 15
        Me.rbdFIPRDIRE.Text = "Dirección del predio"
        Me.rbdFIPRDIRE.UseVisualStyleBackColor = True
        '
        'rbdFIPRMAIN
        '
        Me.rbdFIPRMAIN.AutoSize = True
        Me.rbdFIPRMAIN.Location = New System.Drawing.Point(18, 95)
        Me.rbdFIPRMAIN.Name = "rbdFIPRMAIN"
        Me.rbdFIPRMAIN.Size = New System.Drawing.Size(142, 19)
        Me.rbdFIPRMAIN.TabIndex = 14
        Me.rbdFIPRMAIN.Text = "Matricula inmobiliaria"
        Me.rbdFIPRMAIN.UseVisualStyleBackColor = True
        '
        'rbdFIPRNUDO
        '
        Me.rbdFIPRNUDO.AutoSize = True
        Me.rbdFIPRNUDO.Location = New System.Drawing.Point(18, 70)
        Me.rbdFIPRNUDO.Name = "rbdFIPRNUDO"
        Me.rbdFIPRNUDO.Size = New System.Drawing.Size(113, 19)
        Me.rbdFIPRNUDO.TabIndex = 13
        Me.rbdFIPRNUDO.Text = "Nro. documento"
        Me.rbdFIPRNUDO.UseVisualStyleBackColor = True
        '
        'rbdFIPRCECA
        '
        Me.rbdFIPRCECA.AutoSize = True
        Me.rbdFIPRCECA.Location = New System.Drawing.Point(18, 120)
        Me.rbdFIPRCECA.Name = "rbdFIPRCECA"
        Me.rbdFIPRCECA.Size = New System.Drawing.Size(118, 19)
        Me.rbdFIPRCECA.TabIndex = 12
        Me.rbdFIPRCECA.Text = "Cedula Catastral"
        Me.rbdFIPRCECA.UseVisualStyleBackColor = True
        Me.rbdFIPRCECA.Visible = False
        '
        'rbdFIPRNUFI
        '
        Me.rbdFIPRNUFI.AutoSize = True
        Me.rbdFIPRNUFI.Checked = True
        Me.rbdFIPRNUFI.Location = New System.Drawing.Point(18, 20)
        Me.rbdFIPRNUFI.Name = "rbdFIPRNUFI"
        Me.rbdFIPRNUFI.Size = New System.Drawing.Size(123, 19)
        Me.rbdFIPRNUFI.TabIndex = 11
        Me.rbdFIPRNUFI.TabStop = True
        Me.rbdFIPRNUFI.Text = "Nro. Ficha Predial"
        Me.rbdFIPRNUFI.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(724, 435)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 11
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdCONSULTAR
        '
        Me.cmdCONSULTAR.AccessibleDescription = "Consultar"
        Me.cmdCONSULTAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCONSULTAR.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdCONSULTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCONSULTAR.Location = New System.Drawing.Point(510, 435)
        Me.cmdCONSULTAR.Name = "cmdCONSULTAR"
        Me.cmdCONSULTAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdCONSULTAR.TabIndex = 8
        Me.cmdCONSULTAR.Text = "&Consultar"
        Me.cmdCONSULTAR.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(386, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 20)
        Me.Label1.TabIndex = 454
        Me.Label1.Text = "Formato: 000-0000000"
        '
        'frm_consultar_FICHPRED
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdSALIR
        Me.ClientSize = New System.Drawing.Size(868, 528)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCONSFICHPRED)
        Me.Name = "frm_consultar_FICHPRED"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar registro"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraCONSFICHPRED.ResumeLayout(False)
        Me.fraCONSFICHPRED.PerformLayout()
        CType(Me.BindingNavigator_FICHPRED_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator_FICHPRED_1.ResumeLayout(False)
        Me.BindingNavigator_FICHPRED_1.PerformLayout()
        CType(Me.dgvFICHPRED, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraFIPRCECA.ResumeLayout(False)
        Me.fraFIPRCECA.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.BindingSource_FICHPRED_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraCONSFICHPRED As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdCONSULTAR As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdFIPRCECA As System.Windows.Forms.RadioButton
    Friend WithEvents rbdFIPRNUFI As System.Windows.Forms.RadioButton
    Friend WithEvents fraFIPRCECA As System.Windows.Forms.GroupBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtFIPRCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRMUNI As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtFIPRNUFI As System.Windows.Forms.TextBox
    Friend WithEvents rbdFIPRDIRE As System.Windows.Forms.RadioButton
    Friend WithEvents rbdFIPRMAIN As System.Windows.Forms.RadioButton
    Friend WithEvents rbdFIPRNUDO As System.Windows.Forms.RadioButton
    Friend WithEvents txtFIPRMAIN As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRNUDO As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRDIRE As System.Windows.Forms.TextBox
    Friend WithEvents cmdACEPTAR As System.Windows.Forms.Button
    Friend WithEvents dgvFICHPRED As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboFIPRCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblFIPRCLSE As System.Windows.Forms.Label
    Friend WithEvents BindingNavigator_FICHPRED_1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingSource_FICHPRED_1 As System.Windows.Forms.BindingSource
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
