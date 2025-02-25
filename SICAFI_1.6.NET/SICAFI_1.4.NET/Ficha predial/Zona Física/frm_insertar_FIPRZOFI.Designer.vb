<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_FIPRZOFI
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_insertar_FIPRZOFI))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BindingNavigator_FIPRZOFI_1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.fraZONA = New System.Windows.Forms.GroupBox
        Me.cboFPZFESTA = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFPZFPORC = New System.Windows.Forms.TextBox
        Me.lblFPZFTOTA = New System.Windows.Forms.Label
        Me.lblFPZFDESC = New System.Windows.Forms.Label
        Me.lblFPZFSECU = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvFIPRZOFI = New System.Windows.Forms.DataGridView
        Me.cboFPZFZOFI = New System.Windows.Forms.ComboBox
        Me.Label63 = New System.Windows.Forms.Label
        Me.lbLDestinoEconomico = New System.Windows.Forms.Label
        Me.lblPorcentaje = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdGUARDAR = New System.Windows.Forms.Button
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.BindingSource_FIPRZOFI_1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.BindingNavigator_FIPRZOFI_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator_FIPRZOFI_1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraZONA.SuspendLayout()
        CType(Me.dgvFIPRZOFI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.BindingSource_FIPRZOFI_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BindingNavigator_FIPRZOFI_1
        '
        Me.BindingNavigator_FIPRZOFI_1.AddNewItem = Nothing
        Me.BindingNavigator_FIPRZOFI_1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator_FIPRZOFI_1.DeleteItem = Nothing
        Me.BindingNavigator_FIPRZOFI_1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator_FIPRZOFI_1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator_FIPRZOFI_1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator_FIPRZOFI_1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator_FIPRZOFI_1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator_FIPRZOFI_1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator_FIPRZOFI_1.Name = "BindingNavigator_FIPRZOFI_1"
        Me.BindingNavigator_FIPRZOFI_1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator_FIPRZOFI_1.Size = New System.Drawing.Size(630, 25)
        Me.BindingNavigator_FIPRZOFI_1.TabIndex = 323
        Me.BindingNavigator_FIPRZOFI_1.Text = "BindingNavigator1"
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
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 353)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(630, 25)
        Me.strBARRESTA.TabIndex = 322
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
        'fraZONA
        '
        Me.fraZONA.Controls.Add(Me.cboFPZFESTA)
        Me.fraZONA.Controls.Add(Me.Label2)
        Me.fraZONA.Controls.Add(Me.txtFPZFPORC)
        Me.fraZONA.Controls.Add(Me.lblFPZFTOTA)
        Me.fraZONA.Controls.Add(Me.lblFPZFDESC)
        Me.fraZONA.Controls.Add(Me.lblFPZFSECU)
        Me.fraZONA.Controls.Add(Me.Label6)
        Me.fraZONA.Controls.Add(Me.Label1)
        Me.fraZONA.Controls.Add(Me.dgvFIPRZOFI)
        Me.fraZONA.Controls.Add(Me.cboFPZFZOFI)
        Me.fraZONA.Controls.Add(Me.Label63)
        Me.fraZONA.Controls.Add(Me.lbLDestinoEconomico)
        Me.fraZONA.Controls.Add(Me.lblPorcentaje)
        Me.fraZONA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraZONA.Location = New System.Drawing.Point(12, 28)
        Me.fraZONA.Name = "fraZONA"
        Me.fraZONA.Size = New System.Drawing.Size(611, 268)
        Me.fraZONA.TabIndex = 321
        Me.fraZONA.TabStop = False
        Me.fraZONA.Text = "INSERTAR ZONA FÍSICA"
        '
        'cboFPZFESTA
        '
        Me.cboFPZFESTA.AccessibleDescription = "Estado"
        Me.cboFPZFESTA.BackColor = System.Drawing.Color.White
        Me.cboFPZFESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFPZFESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPZFESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFPZFESTA.FormattingEnabled = True
        Me.cboFPZFESTA.Location = New System.Drawing.Point(86, 234)
        Me.cboFPZFESTA.Name = "cboFPZFESTA"
        Me.cboFPZFESTA.Size = New System.Drawing.Size(86, 22)
        Me.cboFPZFESTA.TabIndex = 3
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
        'txtFPZFPORC
        '
        Me.txtFPZFPORC.AccessibleDescription = "Porcentaje"
        Me.txtFPZFPORC.Location = New System.Drawing.Point(524, 49)
        Me.txtFPZFPORC.MaxLength = 3
        Me.txtFPZFPORC.Name = "txtFPZFPORC"
        Me.txtFPZFPORC.Size = New System.Drawing.Size(71, 20)
        Me.txtFPZFPORC.TabIndex = 2
        '
        'lblFPZFTOTA
        '
        Me.lblFPZFTOTA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFPZFTOTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPZFTOTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPZFTOTA.ForeColor = System.Drawing.Color.Black
        Me.lblFPZFTOTA.Location = New System.Drawing.Point(524, 234)
        Me.lblFPZFTOTA.Name = "lblFPZFTOTA"
        Me.lblFPZFTOTA.Size = New System.Drawing.Size(71, 20)
        Me.lblFPZFTOTA.TabIndex = 328
        Me.lblFPZFTOTA.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblFPZFDESC
        '
        Me.lblFPZFDESC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFPZFDESC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPZFDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPZFDESC.ForeColor = System.Drawing.Color.Black
        Me.lblFPZFDESC.Location = New System.Drawing.Point(176, 49)
        Me.lblFPZFDESC.Name = "lblFPZFDESC"
        Me.lblFPZFDESC.Size = New System.Drawing.Size(344, 20)
        Me.lblFPZFDESC.TabIndex = 326
        '
        'lblFPZFSECU
        '
        Me.lblFPZFSECU.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFPZFSECU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPZFSECU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPZFSECU.ForeColor = System.Drawing.Color.Black
        Me.lblFPZFSECU.Location = New System.Drawing.Point(16, 49)
        Me.lblFPZFSECU.Name = "lblFPZFSECU"
        Me.lblFPZFSECU.Size = New System.Drawing.Size(66, 20)
        Me.lblFPZFSECU.TabIndex = 325
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
        'dgvFIPRZOFI
        '
        Me.dgvFIPRZOFI.AccessibleDescription = "Zona física"
        Me.dgvFIPRZOFI.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvFIPRZOFI.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFIPRZOFI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvFIPRZOFI.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvFIPRZOFI.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvFIPRZOFI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvFIPRZOFI.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvFIPRZOFI.ColumnHeadersHeight = 40
        Me.dgvFIPRZOFI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvFIPRZOFI.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvFIPRZOFI.Location = New System.Drawing.Point(16, 77)
        Me.dgvFIPRZOFI.MultiSelect = False
        Me.dgvFIPRZOFI.Name = "dgvFIPRZOFI"
        Me.dgvFIPRZOFI.ReadOnly = True
        Me.dgvFIPRZOFI.RowHeadersVisible = False
        Me.dgvFIPRZOFI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFIPRZOFI.ShowCellToolTips = False
        Me.dgvFIPRZOFI.Size = New System.Drawing.Size(579, 152)
        Me.dgvFIPRZOFI.StandardTab = True
        Me.dgvFIPRZOFI.TabIndex = 321
        '
        'cboFPZFZOFI
        '
        Me.cboFPZFZOFI.AccessibleDescription = "Zona física"
        Me.cboFPZFZOFI.BackColor = System.Drawing.Color.White
        Me.cboFPZFZOFI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFPZFZOFI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPZFZOFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFPZFZOFI.Items.AddRange(New Object() {"2004", "2005", "2006", "2007"})
        Me.cboFPZFZOFI.Location = New System.Drawing.Point(86, 49)
        Me.cboFPZFZOFI.MaxDropDownItems = 15
        Me.cboFPZFZOFI.MaxLength = 4
        Me.cboFPZFZOFI.Name = "cboFPZFZOFI"
        Me.cboFPZFZOFI.Size = New System.Drawing.Size(72, 22)
        Me.cboFPZFZOFI.TabIndex = 1
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
        Me.lbLDestinoEconomico.Text = "Zona"
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 302)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(611, 50)
        Me.GroupBox1.TabIndex = 324
        Me.GroupBox1.TabStop = False
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
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frm_insertar_FIPRZOFI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdSALIR
        Me.ClientSize = New System.Drawing.Size(630, 378)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BindingNavigator_FIPRZOFI_1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraZONA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(646, 414)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(646, 414)
        Me.Name = "frm_insertar_FIPRZOFI"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        CType(Me.BindingNavigator_FIPRZOFI_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator_FIPRZOFI_1.ResumeLayout(False)
        Me.BindingNavigator_FIPRZOFI_1.PerformLayout()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraZONA.ResumeLayout(False)
        Me.fraZONA.PerformLayout()
        CType(Me.dgvFIPRZOFI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.BindingSource_FIPRZOFI_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BindingNavigator_FIPRZOFI_1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraZONA As System.Windows.Forms.GroupBox
    Friend WithEvents cboFPZFESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFPZFPORC As System.Windows.Forms.TextBox
    Friend WithEvents lblFPZFTOTA As System.Windows.Forms.Label
    Friend WithEvents lblFPZFDESC As System.Windows.Forms.Label
    Friend WithEvents lblFPZFSECU As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvFIPRZOFI As System.Windows.Forms.DataGridView
    Friend WithEvents cboFPZFZOFI As System.Windows.Forms.ComboBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents lbLDestinoEconomico As System.Windows.Forms.Label
    Friend WithEvents lblPorcentaje As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents BindingSource_FIPRZOFI_1 As System.Windows.Forms.BindingSource
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
