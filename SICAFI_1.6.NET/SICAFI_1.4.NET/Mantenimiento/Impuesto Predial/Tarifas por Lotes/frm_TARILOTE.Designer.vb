<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_TARILOTE
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_TARILOTE))
        Me.fraALUMPUBL = New System.Windows.Forms.GroupBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.dgvTARILOTE_1 = New System.Windows.Forms.DataGridView
        Me.dgvTARILOTE_2 = New System.Windows.Forms.DataGridView
        Me.lblTAPEZOEC = New System.Windows.Forms.Label
        Me.lblTIPO = New System.Windows.Forms.Label
        Me.lblTAPEVIGE = New System.Windows.Forms.Label
        Me.lblVIGENCIA = New System.Windows.Forms.Label
        Me.lblTAPECLSE = New System.Windows.Forms.Label
        Me.lblSECTOR = New System.Windows.Forms.Label
        Me.lblTAPEDEPA = New System.Windows.Forms.Label
        Me.lblDEPARTAMENTO = New System.Windows.Forms.Label
        Me.lblTAPEMUNI = New System.Windows.Forms.Label
        Me.lblMUNICIPIO = New System.Windows.Forms.Label
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.BindingNavigator_TARILOTE_1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdAGREGAR = New System.Windows.Forms.ToolStripButton
        Me.cmdMODIFICAR = New System.Windows.Forms.ToolStripButton
        Me.cmdELIMINAR = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdCONSULTAR = New System.Windows.Forms.ToolStripButton
        Me.cmdRECONSULTAR = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdSALIR = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingSource_TARILOTE_1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.fraALUMPUBL.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvTARILOTE_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTARILOTE_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        CType(Me.BindingNavigator_TARILOTE_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator_TARILOTE_1.SuspendLayout()
        CType(Me.BindingSource_TARILOTE_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraALUMPUBL
        '
        Me.fraALUMPUBL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraALUMPUBL.BackColor = System.Drawing.SystemColors.Control
        Me.fraALUMPUBL.Controls.Add(Me.SplitContainer1)
        Me.fraALUMPUBL.Controls.Add(Me.lblTAPEZOEC)
        Me.fraALUMPUBL.Controls.Add(Me.lblTIPO)
        Me.fraALUMPUBL.Controls.Add(Me.lblTAPEVIGE)
        Me.fraALUMPUBL.Controls.Add(Me.lblVIGENCIA)
        Me.fraALUMPUBL.Controls.Add(Me.lblTAPECLSE)
        Me.fraALUMPUBL.Controls.Add(Me.lblSECTOR)
        Me.fraALUMPUBL.Controls.Add(Me.lblTAPEDEPA)
        Me.fraALUMPUBL.Controls.Add(Me.lblDEPARTAMENTO)
        Me.fraALUMPUBL.Controls.Add(Me.lblTAPEMUNI)
        Me.fraALUMPUBL.Controls.Add(Me.lblMUNICIPIO)
        Me.fraALUMPUBL.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraALUMPUBL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraALUMPUBL.Location = New System.Drawing.Point(14, 35)
        Me.fraALUMPUBL.Name = "fraALUMPUBL"
        Me.fraALUMPUBL.Size = New System.Drawing.Size(943, 514)
        Me.fraALUMPUBL.TabIndex = 39
        Me.fraALUMPUBL.TabStop = False
        Me.fraALUMPUBL.Text = "TARIFAS POR LOTES"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(17, 30)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvTARILOTE_1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvTARILOTE_2)
        Me.SplitContainer1.Size = New System.Drawing.Size(908, 334)
        Me.SplitContainer1.SplitterDistance = 162
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 64
        '
        'dgvTARILOTE_1
        '
        Me.dgvTARILOTE_1.AccessibleDescription = "Tarifa por lotes"
        Me.dgvTARILOTE_1.AllowUserToAddRows = False
        Me.dgvTARILOTE_1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvTARILOTE_1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTARILOTE_1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTARILOTE_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTARILOTE_1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvTARILOTE_1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvTARILOTE_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvTARILOTE_1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTARILOTE_1.ColumnHeadersHeight = 40
        Me.dgvTARILOTE_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvTARILOTE_1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvTARILOTE_1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvTARILOTE_1.Location = New System.Drawing.Point(5, 3)
        Me.dgvTARILOTE_1.MultiSelect = False
        Me.dgvTARILOTE_1.Name = "dgvTARILOTE_1"
        Me.dgvTARILOTE_1.ReadOnly = True
        Me.dgvTARILOTE_1.RowHeadersVisible = False
        Me.dgvTARILOTE_1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvTARILOTE_1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTARILOTE_1.ShowCellToolTips = False
        Me.dgvTARILOTE_1.Size = New System.Drawing.Size(900, 156)
        Me.dgvTARILOTE_1.StandardTab = True
        Me.dgvTARILOTE_1.TabIndex = 0
        '
        'dgvTARILOTE_2
        '
        Me.dgvTARILOTE_2.AccessibleDescription = "Tarifa por lotes"
        Me.dgvTARILOTE_2.AllowUserToAddRows = False
        Me.dgvTARILOTE_2.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvTARILOTE_2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTARILOTE_2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTARILOTE_2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTARILOTE_2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvTARILOTE_2.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvTARILOTE_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvTARILOTE_2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTARILOTE_2.ColumnHeadersHeight = 40
        Me.dgvTARILOTE_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvTARILOTE_2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvTARILOTE_2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvTARILOTE_2.Location = New System.Drawing.Point(3, 3)
        Me.dgvTARILOTE_2.MultiSelect = False
        Me.dgvTARILOTE_2.Name = "dgvTARILOTE_2"
        Me.dgvTARILOTE_2.ReadOnly = True
        Me.dgvTARILOTE_2.RowHeadersVisible = False
        Me.dgvTARILOTE_2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvTARILOTE_2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTARILOTE_2.ShowCellToolTips = False
        Me.dgvTARILOTE_2.Size = New System.Drawing.Size(902, 161)
        Me.dgvTARILOTE_2.StandardTab = True
        Me.dgvTARILOTE_2.TabIndex = 60
        '
        'lblTAPEZOEC
        '
        Me.lblTAPEZOEC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTAPEZOEC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAPEZOEC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAPEZOEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAPEZOEC.ForeColor = System.Drawing.Color.Black
        Me.lblTAPEZOEC.Location = New System.Drawing.Point(137, 475)
        Me.lblTAPEZOEC.Name = "lblTAPEZOEC"
        Me.lblTAPEZOEC.Size = New System.Drawing.Size(788, 20)
        Me.lblTAPEZOEC.TabIndex = 58
        '
        'lblTIPO
        '
        Me.lblTIPO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTIPO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblTIPO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTIPO.ForeColor = System.Drawing.Color.Black
        Me.lblTIPO.Location = New System.Drawing.Point(19, 475)
        Me.lblTIPO.Name = "lblTIPO"
        Me.lblTIPO.Size = New System.Drawing.Size(112, 20)
        Me.lblTIPO.TabIndex = 57
        Me.lblTIPO.Text = "Zona económica"
        '
        'lblTAPEVIGE
        '
        Me.lblTAPEVIGE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTAPEVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAPEVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAPEVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAPEVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblTAPEVIGE.Location = New System.Drawing.Point(137, 452)
        Me.lblTAPEVIGE.Name = "lblTAPEVIGE"
        Me.lblTAPEVIGE.Size = New System.Drawing.Size(788, 20)
        Me.lblTAPEVIGE.TabIndex = 56
        '
        'lblVIGENCIA
        '
        Me.lblVIGENCIA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVIGENCIA.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblVIGENCIA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVIGENCIA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVIGENCIA.ForeColor = System.Drawing.Color.Black
        Me.lblVIGENCIA.Location = New System.Drawing.Point(19, 452)
        Me.lblVIGENCIA.Name = "lblVIGENCIA"
        Me.lblVIGENCIA.Size = New System.Drawing.Size(112, 20)
        Me.lblVIGENCIA.TabIndex = 55
        Me.lblVIGENCIA.Text = "Vigencia"
        '
        'lblTAPECLSE
        '
        Me.lblTAPECLSE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTAPECLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAPECLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAPECLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAPECLSE.ForeColor = System.Drawing.Color.Black
        Me.lblTAPECLSE.Location = New System.Drawing.Point(137, 428)
        Me.lblTAPECLSE.Name = "lblTAPECLSE"
        Me.lblTAPECLSE.Size = New System.Drawing.Size(788, 20)
        Me.lblTAPECLSE.TabIndex = 54
        '
        'lblSECTOR
        '
        Me.lblSECTOR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSECTOR.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblSECTOR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSECTOR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSECTOR.ForeColor = System.Drawing.Color.Black
        Me.lblSECTOR.Location = New System.Drawing.Point(19, 428)
        Me.lblSECTOR.Name = "lblSECTOR"
        Me.lblSECTOR.Size = New System.Drawing.Size(112, 20)
        Me.lblSECTOR.TabIndex = 53
        Me.lblSECTOR.Text = "Clase o sector"
        '
        'lblTAPEDEPA
        '
        Me.lblTAPEDEPA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTAPEDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAPEDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAPEDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAPEDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblTAPEDEPA.Location = New System.Drawing.Point(137, 380)
        Me.lblTAPEDEPA.Name = "lblTAPEDEPA"
        Me.lblTAPEDEPA.Size = New System.Drawing.Size(788, 20)
        Me.lblTAPEDEPA.TabIndex = 52
        '
        'lblDEPARTAMENTO
        '
        Me.lblDEPARTAMENTO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDEPARTAMENTO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblDEPARTAMENTO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDEPARTAMENTO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDEPARTAMENTO.ForeColor = System.Drawing.Color.Black
        Me.lblDEPARTAMENTO.Location = New System.Drawing.Point(19, 380)
        Me.lblDEPARTAMENTO.Name = "lblDEPARTAMENTO"
        Me.lblDEPARTAMENTO.Size = New System.Drawing.Size(112, 20)
        Me.lblDEPARTAMENTO.TabIndex = 51
        Me.lblDEPARTAMENTO.Text = "Departamento"
        '
        'lblTAPEMUNI
        '
        Me.lblTAPEMUNI.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTAPEMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAPEMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAPEMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAPEMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblTAPEMUNI.Location = New System.Drawing.Point(137, 404)
        Me.lblTAPEMUNI.Name = "lblTAPEMUNI"
        Me.lblTAPEMUNI.Size = New System.Drawing.Size(788, 20)
        Me.lblTAPEMUNI.TabIndex = 50
        '
        'lblMUNICIPIO
        '
        Me.lblMUNICIPIO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMUNICIPIO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMUNICIPIO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUNICIPIO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUNICIPIO.ForeColor = System.Drawing.Color.Black
        Me.lblMUNICIPIO.Location = New System.Drawing.Point(19, 404)
        Me.lblMUNICIPIO.Name = "lblMUNICIPIO"
        Me.lblMUNICIPIO.Size = New System.Drawing.Size(112, 20)
        Me.lblMUNICIPIO.TabIndex = 49
        Me.lblMUNICIPIO.Text = "Municipio"
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 560)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(969, 25)
        Me.strBARRESTA.TabIndex = 38
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
        'BindingNavigator_TARILOTE_1
        '
        Me.BindingNavigator_TARILOTE_1.AddNewItem = Nothing
        Me.BindingNavigator_TARILOTE_1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator_TARILOTE_1.DeleteItem = Nothing
        Me.BindingNavigator_TARILOTE_1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.cmdAGREGAR, Me.cmdMODIFICAR, Me.cmdELIMINAR, Me.ToolStripSeparator3, Me.cmdCONSULTAR, Me.cmdRECONSULTAR, Me.ToolStripSeparator1, Me.cmdSALIR, Me.ToolStripSeparator2})
        Me.BindingNavigator_TARILOTE_1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator_TARILOTE_1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator_TARILOTE_1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator_TARILOTE_1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator_TARILOTE_1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator_TARILOTE_1.Name = "BindingNavigator_TARILOTE_1"
        Me.BindingNavigator_TARILOTE_1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator_TARILOTE_1.Size = New System.Drawing.Size(969, 25)
        Me.BindingNavigator_TARILOTE_1.TabIndex = 37
        Me.BindingNavigator_TARILOTE_1.Text = "BindingNavigator1"
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
        'cmdAGREGAR
        '
        Me.cmdAGREGAR.AccessibleDescription = "Agregar"
        Me.cmdAGREGAR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdAGREGAR.Image = Global.SICAFI.My.Resources.Resources._210
        Me.cmdAGREGAR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdAGREGAR.Name = "cmdAGREGAR"
        Me.cmdAGREGAR.Size = New System.Drawing.Size(23, 22)
        Me.cmdAGREGAR.ToolTipText = "Agregar (F2)"
        '
        'cmdMODIFICAR
        '
        Me.cmdMODIFICAR.AccessibleDescription = "Modificar"
        Me.cmdMODIFICAR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdMODIFICAR.Image = Global.SICAFI.My.Resources.Resources.icon_edit
        Me.cmdMODIFICAR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdMODIFICAR.Name = "cmdMODIFICAR"
        Me.cmdMODIFICAR.Size = New System.Drawing.Size(23, 22)
        Me.cmdMODIFICAR.ToolTipText = "Modificar (F3)"
        '
        'cmdELIMINAR
        '
        Me.cmdELIMINAR.AccessibleDescription = "Eliminar"
        Me.cmdELIMINAR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdELIMINAR.Image = Global.SICAFI.My.Resources.Resources._132
        Me.cmdELIMINAR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdELIMINAR.Name = "cmdELIMINAR"
        Me.cmdELIMINAR.Size = New System.Drawing.Size(23, 22)
        Me.cmdELIMINAR.ToolTipText = "Eliminar (Supr)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'cmdCONSULTAR
        '
        Me.cmdCONSULTAR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdCONSULTAR.Image = Global.SICAFI.My.Resources.Resources._045
        Me.cmdCONSULTAR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdCONSULTAR.Name = "cmdCONSULTAR"
        Me.cmdCONSULTAR.Size = New System.Drawing.Size(23, 22)
        Me.cmdCONSULTAR.ToolTipText = "Consultar (F7)"
        '
        'cmdRECONSULTAR
        '
        Me.cmdRECONSULTAR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdRECONSULTAR.Image = Global.SICAFI.My.Resources.Resources._096
        Me.cmdRECONSULTAR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdRECONSULTAR.Name = "cmdRECONSULTAR"
        Me.cmdRECONSULTAR.Size = New System.Drawing.Size(23, 22)
        Me.cmdRECONSULTAR.ToolTipText = "Reconsultar (F8)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(23, 22)
        Me.cmdSALIR.ToolTipText = "Salir"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'frm_TARILOTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 585)
        Me.Controls.Add(Me.fraALUMPUBL)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.BindingNavigator_TARILOTE_1)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_TARILOTE"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "TARIFA POR LOTE"
        Me.fraALUMPUBL.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvTARILOTE_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTARILOTE_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        CType(Me.BindingNavigator_TARILOTE_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator_TARILOTE_1.ResumeLayout(False)
        Me.BindingNavigator_TARILOTE_1.PerformLayout()
        CType(Me.BindingSource_TARILOTE_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraALUMPUBL As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvTARILOTE_1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgvTARILOTE_2 As System.Windows.Forms.DataGridView
    Friend WithEvents lblTAPEZOEC As System.Windows.Forms.Label
    Friend WithEvents lblTIPO As System.Windows.Forms.Label
    Friend WithEvents lblTAPEVIGE As System.Windows.Forms.Label
    Friend WithEvents lblVIGENCIA As System.Windows.Forms.Label
    Friend WithEvents lblTAPECLSE As System.Windows.Forms.Label
    Friend WithEvents lblSECTOR As System.Windows.Forms.Label
    Friend WithEvents lblTAPEDEPA As System.Windows.Forms.Label
    Friend WithEvents lblDEPARTAMENTO As System.Windows.Forms.Label
    Friend WithEvents lblTAPEMUNI As System.Windows.Forms.Label
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BindingNavigator_TARILOTE_1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdAGREGAR As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdMODIFICAR As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdELIMINAR As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdCONSULTAR As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdRECONSULTAR As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdSALIR As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingSource_TARILOTE_1 As System.Windows.Forms.BindingSource
End Class
