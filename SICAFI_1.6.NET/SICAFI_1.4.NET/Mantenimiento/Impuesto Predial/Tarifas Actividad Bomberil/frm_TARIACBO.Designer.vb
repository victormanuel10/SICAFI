<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_TARIACBO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_TARIACBO))
        Me.fraALUMPUBL = New System.Windows.Forms.GroupBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.dgvTARIACBO_1 = New System.Windows.Forms.DataGridView
        Me.dgvTARIACBO_2 = New System.Windows.Forms.DataGridView
        Me.lblTAABESTR = New System.Windows.Forms.Label
        Me.lblESTRATO = New System.Windows.Forms.Label
        Me.lblTAABTIPO = New System.Windows.Forms.Label
        Me.lblTIPO = New System.Windows.Forms.Label
        Me.lblTAABVIGE = New System.Windows.Forms.Label
        Me.lblVIGENCIA = New System.Windows.Forms.Label
        Me.lblTAABCLSE = New System.Windows.Forms.Label
        Me.lblSECTOR = New System.Windows.Forms.Label
        Me.lblTAABDEPA = New System.Windows.Forms.Label
        Me.lblDEPARTAMENTO = New System.Windows.Forms.Label
        Me.lblTAABMUNI = New System.Windows.Forms.Label
        Me.lblMUNICIPIO = New System.Windows.Forms.Label
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.BindingNavigator_TARIACBO_1 = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.BindingSource_TARIACBO_1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.fraALUMPUBL.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvTARIACBO_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTARIACBO_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        CType(Me.BindingNavigator_TARIACBO_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator_TARIACBO_1.SuspendLayout()
        CType(Me.BindingSource_TARIACBO_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraALUMPUBL
        '
        Me.fraALUMPUBL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraALUMPUBL.BackColor = System.Drawing.SystemColors.Control
        Me.fraALUMPUBL.Controls.Add(Me.SplitContainer1)
        Me.fraALUMPUBL.Controls.Add(Me.lblTAABESTR)
        Me.fraALUMPUBL.Controls.Add(Me.lblESTRATO)
        Me.fraALUMPUBL.Controls.Add(Me.lblTAABTIPO)
        Me.fraALUMPUBL.Controls.Add(Me.lblTIPO)
        Me.fraALUMPUBL.Controls.Add(Me.lblTAABVIGE)
        Me.fraALUMPUBL.Controls.Add(Me.lblVIGENCIA)
        Me.fraALUMPUBL.Controls.Add(Me.lblTAABCLSE)
        Me.fraALUMPUBL.Controls.Add(Me.lblSECTOR)
        Me.fraALUMPUBL.Controls.Add(Me.lblTAABDEPA)
        Me.fraALUMPUBL.Controls.Add(Me.lblDEPARTAMENTO)
        Me.fraALUMPUBL.Controls.Add(Me.lblTAABMUNI)
        Me.fraALUMPUBL.Controls.Add(Me.lblMUNICIPIO)
        Me.fraALUMPUBL.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraALUMPUBL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraALUMPUBL.Location = New System.Drawing.Point(14, 35)
        Me.fraALUMPUBL.Name = "fraALUMPUBL"
        Me.fraALUMPUBL.Size = New System.Drawing.Size(943, 514)
        Me.fraALUMPUBL.TabIndex = 36
        Me.fraALUMPUBL.TabStop = False
        Me.fraALUMPUBL.Text = "TARIFAS ACTIVIDAD BOMBERIL"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvTARIACBO_1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvTARIACBO_2)
        Me.SplitContainer1.Size = New System.Drawing.Size(908, 386)
        Me.SplitContainer1.SplitterDistance = 188
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 64
        '
        'dgvTARIACBO_1
        '
        Me.dgvTARIACBO_1.AccessibleDescription = "Actividad bomberil"
        Me.dgvTARIACBO_1.AllowUserToAddRows = False
        Me.dgvTARIACBO_1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvTARIACBO_1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTARIACBO_1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTARIACBO_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTARIACBO_1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvTARIACBO_1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvTARIACBO_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvTARIACBO_1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTARIACBO_1.ColumnHeadersHeight = 40
        Me.dgvTARIACBO_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvTARIACBO_1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvTARIACBO_1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvTARIACBO_1.Location = New System.Drawing.Point(5, 3)
        Me.dgvTARIACBO_1.MultiSelect = False
        Me.dgvTARIACBO_1.Name = "dgvTARIACBO_1"
        Me.dgvTARIACBO_1.ReadOnly = True
        Me.dgvTARIACBO_1.RowHeadersVisible = False
        Me.dgvTARIACBO_1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvTARIACBO_1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTARIACBO_1.ShowCellToolTips = False
        Me.dgvTARIACBO_1.Size = New System.Drawing.Size(900, 182)
        Me.dgvTARIACBO_1.StandardTab = True
        Me.dgvTARIACBO_1.TabIndex = 0
        '
        'dgvTARIACBO_2
        '
        Me.dgvTARIACBO_2.AccessibleDescription = "Actividad bomberil"
        Me.dgvTARIACBO_2.AllowUserToAddRows = False
        Me.dgvTARIACBO_2.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvTARIACBO_2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTARIACBO_2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTARIACBO_2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTARIACBO_2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvTARIACBO_2.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvTARIACBO_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvTARIACBO_2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTARIACBO_2.ColumnHeadersHeight = 40
        Me.dgvTARIACBO_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvTARIACBO_2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvTARIACBO_2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvTARIACBO_2.Location = New System.Drawing.Point(3, 3)
        Me.dgvTARIACBO_2.MultiSelect = False
        Me.dgvTARIACBO_2.Name = "dgvTARIACBO_2"
        Me.dgvTARIACBO_2.ReadOnly = True
        Me.dgvTARIACBO_2.RowHeadersVisible = False
        Me.dgvTARIACBO_2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvTARIACBO_2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTARIACBO_2.ShowCellToolTips = False
        Me.dgvTARIACBO_2.Size = New System.Drawing.Size(902, 187)
        Me.dgvTARIACBO_2.StandardTab = True
        Me.dgvTARIACBO_2.TabIndex = 60
        '
        'lblTAABESTR
        '
        Me.lblTAABESTR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTAABESTR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAABESTR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAABESTR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAABESTR.ForeColor = System.Drawing.Color.Black
        Me.lblTAABESTR.Location = New System.Drawing.Point(585, 476)
        Me.lblTAABESTR.Name = "lblTAABESTR"
        Me.lblTAABESTR.Size = New System.Drawing.Size(338, 20)
        Me.lblTAABESTR.TabIndex = 60
        '
        'lblESTRATO
        '
        Me.lblESTRATO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblESTRATO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblESTRATO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblESTRATO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblESTRATO.ForeColor = System.Drawing.Color.Black
        Me.lblESTRATO.Location = New System.Drawing.Point(467, 476)
        Me.lblESTRATO.Name = "lblESTRATO"
        Me.lblESTRATO.Size = New System.Drawing.Size(112, 20)
        Me.lblESTRATO.TabIndex = 59
        Me.lblESTRATO.Text = "Estrato"
        '
        'lblTAABTIPO
        '
        Me.lblTAABTIPO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTAABTIPO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAABTIPO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAABTIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAABTIPO.ForeColor = System.Drawing.Color.Black
        Me.lblTAABTIPO.Location = New System.Drawing.Point(585, 452)
        Me.lblTAABTIPO.Name = "lblTAABTIPO"
        Me.lblTAABTIPO.Size = New System.Drawing.Size(338, 20)
        Me.lblTAABTIPO.TabIndex = 58
        '
        'lblTIPO
        '
        Me.lblTIPO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTIPO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblTIPO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTIPO.ForeColor = System.Drawing.Color.Black
        Me.lblTIPO.Location = New System.Drawing.Point(467, 452)
        Me.lblTIPO.Name = "lblTIPO"
        Me.lblTIPO.Size = New System.Drawing.Size(112, 20)
        Me.lblTIPO.TabIndex = 57
        Me.lblTIPO.Text = "Tipo calificación"
        '
        'lblTAABVIGE
        '
        Me.lblTAABVIGE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTAABVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAABVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAABVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAABVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblTAABVIGE.Location = New System.Drawing.Point(585, 429)
        Me.lblTAABVIGE.Name = "lblTAABVIGE"
        Me.lblTAABVIGE.Size = New System.Drawing.Size(338, 20)
        Me.lblTAABVIGE.TabIndex = 56
        '
        'lblVIGENCIA
        '
        Me.lblVIGENCIA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVIGENCIA.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblVIGENCIA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVIGENCIA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVIGENCIA.ForeColor = System.Drawing.Color.Black
        Me.lblVIGENCIA.Location = New System.Drawing.Point(467, 429)
        Me.lblVIGENCIA.Name = "lblVIGENCIA"
        Me.lblVIGENCIA.Size = New System.Drawing.Size(112, 20)
        Me.lblVIGENCIA.TabIndex = 55
        Me.lblVIGENCIA.Text = "Vigencia"
        '
        'lblTAABCLSE
        '
        Me.lblTAABCLSE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTAABCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAABCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAABCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAABCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblTAABCLSE.Location = New System.Drawing.Point(135, 477)
        Me.lblTAABCLSE.Name = "lblTAABCLSE"
        Me.lblTAABCLSE.Size = New System.Drawing.Size(328, 20)
        Me.lblTAABCLSE.TabIndex = 54
        '
        'lblSECTOR
        '
        Me.lblSECTOR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSECTOR.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblSECTOR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSECTOR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSECTOR.ForeColor = System.Drawing.Color.Black
        Me.lblSECTOR.Location = New System.Drawing.Point(17, 477)
        Me.lblSECTOR.Name = "lblSECTOR"
        Me.lblSECTOR.Size = New System.Drawing.Size(112, 20)
        Me.lblSECTOR.TabIndex = 53
        Me.lblSECTOR.Text = "Clase o sector"
        '
        'lblTAABDEPA
        '
        Me.lblTAABDEPA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTAABDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAABDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAABDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAABDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblTAABDEPA.Location = New System.Drawing.Point(135, 429)
        Me.lblTAABDEPA.Name = "lblTAABDEPA"
        Me.lblTAABDEPA.Size = New System.Drawing.Size(328, 20)
        Me.lblTAABDEPA.TabIndex = 52
        '
        'lblDEPARTAMENTO
        '
        Me.lblDEPARTAMENTO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDEPARTAMENTO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblDEPARTAMENTO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDEPARTAMENTO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDEPARTAMENTO.ForeColor = System.Drawing.Color.Black
        Me.lblDEPARTAMENTO.Location = New System.Drawing.Point(17, 429)
        Me.lblDEPARTAMENTO.Name = "lblDEPARTAMENTO"
        Me.lblDEPARTAMENTO.Size = New System.Drawing.Size(112, 20)
        Me.lblDEPARTAMENTO.TabIndex = 51
        Me.lblDEPARTAMENTO.Text = "Departamento"
        '
        'lblTAABMUNI
        '
        Me.lblTAABMUNI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTAABMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAABMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAABMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAABMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblTAABMUNI.Location = New System.Drawing.Point(135, 453)
        Me.lblTAABMUNI.Name = "lblTAABMUNI"
        Me.lblTAABMUNI.Size = New System.Drawing.Size(328, 20)
        Me.lblTAABMUNI.TabIndex = 50
        '
        'lblMUNICIPIO
        '
        Me.lblMUNICIPIO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMUNICIPIO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMUNICIPIO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUNICIPIO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUNICIPIO.ForeColor = System.Drawing.Color.Black
        Me.lblMUNICIPIO.Location = New System.Drawing.Point(17, 453)
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
        Me.strBARRESTA.TabIndex = 35
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
        'BindingNavigator_TARIACBO_1
        '
        Me.BindingNavigator_TARIACBO_1.AddNewItem = Nothing
        Me.BindingNavigator_TARIACBO_1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator_TARIACBO_1.DeleteItem = Nothing
        Me.BindingNavigator_TARIACBO_1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.cmdAGREGAR, Me.cmdMODIFICAR, Me.cmdELIMINAR, Me.ToolStripSeparator3, Me.cmdCONSULTAR, Me.cmdRECONSULTAR, Me.ToolStripSeparator1, Me.cmdSALIR, Me.ToolStripSeparator2})
        Me.BindingNavigator_TARIACBO_1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator_TARIACBO_1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator_TARIACBO_1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator_TARIACBO_1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator_TARIACBO_1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator_TARIACBO_1.Name = "BindingNavigator_TARIACBO_1"
        Me.BindingNavigator_TARIACBO_1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator_TARIACBO_1.Size = New System.Drawing.Size(969, 25)
        Me.BindingNavigator_TARIACBO_1.TabIndex = 34
        Me.BindingNavigator_TARIACBO_1.Text = "BindingNavigator1"
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
        'frm_TARIACBO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 585)
        Me.Controls.Add(Me.fraALUMPUBL)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.BindingNavigator_TARIACBO_1)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_TARIACBO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "TARIFAS ACTIVIDAD BOMBERIL"
        Me.fraALUMPUBL.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvTARIACBO_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTARIACBO_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        CType(Me.BindingNavigator_TARIACBO_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator_TARIACBO_1.ResumeLayout(False)
        Me.BindingNavigator_TARIACBO_1.PerformLayout()
        CType(Me.BindingSource_TARIACBO_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraALUMPUBL As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvTARIACBO_1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgvTARIACBO_2 As System.Windows.Forms.DataGridView
    Friend WithEvents lblTAABESTR As System.Windows.Forms.Label
    Friend WithEvents lblESTRATO As System.Windows.Forms.Label
    Friend WithEvents lblTAABTIPO As System.Windows.Forms.Label
    Friend WithEvents lblTIPO As System.Windows.Forms.Label
    Friend WithEvents lblTAABVIGE As System.Windows.Forms.Label
    Friend WithEvents lblVIGENCIA As System.Windows.Forms.Label
    Friend WithEvents lblTAABCLSE As System.Windows.Forms.Label
    Friend WithEvents lblSECTOR As System.Windows.Forms.Label
    Friend WithEvents lblTAABDEPA As System.Windows.Forms.Label
    Friend WithEvents lblDEPARTAMENTO As System.Windows.Forms.Label
    Friend WithEvents lblTAABMUNI As System.Windows.Forms.Label
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BindingNavigator_TARIACBO_1 As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents BindingSource_TARIACBO_1 As System.Windows.Forms.BindingSource
End Class
