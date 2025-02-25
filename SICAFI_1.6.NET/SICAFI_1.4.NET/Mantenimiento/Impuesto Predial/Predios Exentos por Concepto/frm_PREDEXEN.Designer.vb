<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_PREDEXEN
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_PREDEXEN))
        Me.fraFORMMUNI = New System.Windows.Forms.GroupBox()
        Me.lblPREXOBSE = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPREXVIIN = New System.Windows.Forms.Label()
        Me.Formula = New System.Windows.Forms.Label()
        Me.lblPREXCONC = New System.Windows.Forms.Label()
        Me.LB = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgvPREDEXEN_1 = New System.Windows.Forms.DataGridView()
        Me.dgvPREDEXEN_2 = New System.Windows.Forms.DataGridView()
        Me.lblPREXTIIM = New System.Windows.Forms.Label()
        Me.lblTIPO = New System.Windows.Forms.Label()
        Me.lblPREXVIFI = New System.Windows.Forms.Label()
        Me.lblVIGENCIA = New System.Windows.Forms.Label()
        Me.lblPREXCLSE = New System.Windows.Forms.Label()
        Me.lblSECTOR = New System.Windows.Forms.Label()
        Me.lblPREXDEPA = New System.Windows.Forms.Label()
        Me.lblDEPARTAMENTO = New System.Windows.Forms.Label()
        Me.lblPREXMUNI = New System.Windows.Forms.Label()
        Me.lblMUNICIPIO = New System.Windows.Forms.Label()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BindingNavigator_PREDEXEN_1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdAGREGAR = New System.Windows.Forms.ToolStripButton()
        Me.cmdMODIFICAR = New System.Windows.Forms.ToolStripButton()
        Me.cmdELIMINAR = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdCONSULTAR = New System.Windows.Forms.ToolStripButton()
        Me.cmdRECONSULTAR = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdSALIR = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingSource_PREDEXEN_1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.fraFORMMUNI.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvPREDEXEN_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPREDEXEN_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        CType(Me.BindingNavigator_PREDEXEN_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator_PREDEXEN_1.SuspendLayout()
        CType(Me.BindingSource_PREDEXEN_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraFORMMUNI
        '
        Me.fraFORMMUNI.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraFORMMUNI.BackColor = System.Drawing.SystemColors.Control
        Me.fraFORMMUNI.Controls.Add(Me.lblPREXOBSE)
        Me.fraFORMMUNI.Controls.Add(Me.Label2)
        Me.fraFORMMUNI.Controls.Add(Me.lblPREXVIIN)
        Me.fraFORMMUNI.Controls.Add(Me.Formula)
        Me.fraFORMMUNI.Controls.Add(Me.lblPREXCONC)
        Me.fraFORMMUNI.Controls.Add(Me.LB)
        Me.fraFORMMUNI.Controls.Add(Me.SplitContainer1)
        Me.fraFORMMUNI.Controls.Add(Me.lblPREXTIIM)
        Me.fraFORMMUNI.Controls.Add(Me.lblTIPO)
        Me.fraFORMMUNI.Controls.Add(Me.lblPREXVIFI)
        Me.fraFORMMUNI.Controls.Add(Me.lblVIGENCIA)
        Me.fraFORMMUNI.Controls.Add(Me.lblPREXCLSE)
        Me.fraFORMMUNI.Controls.Add(Me.lblSECTOR)
        Me.fraFORMMUNI.Controls.Add(Me.lblPREXDEPA)
        Me.fraFORMMUNI.Controls.Add(Me.lblDEPARTAMENTO)
        Me.fraFORMMUNI.Controls.Add(Me.lblPREXMUNI)
        Me.fraFORMMUNI.Controls.Add(Me.lblMUNICIPIO)
        Me.fraFORMMUNI.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraFORMMUNI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraFORMMUNI.Location = New System.Drawing.Point(14, 35)
        Me.fraFORMMUNI.Name = "fraFORMMUNI"
        Me.fraFORMMUNI.Size = New System.Drawing.Size(943, 527)
        Me.fraFORMMUNI.TabIndex = 45
        Me.fraFORMMUNI.TabStop = False
        Me.fraFORMMUNI.Text = "PREDIOS EXENTOS"
        '
        'lblPREXOBSE
        '
        Me.lblPREXOBSE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPREXOBSE.BackColor = System.Drawing.Color.White
        Me.lblPREXOBSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPREXOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPREXOBSE.ForeColor = System.Drawing.Color.Black
        Me.lblPREXOBSE.Location = New System.Drawing.Point(133, 494)
        Me.lblPREXOBSE.Name = "lblPREXOBSE"
        Me.lblPREXOBSE.Size = New System.Drawing.Size(792, 20)
        Me.lblPREXOBSE.TabIndex = 70
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(17, 494)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Observación"
        '
        'lblPREXVIIN
        '
        Me.lblPREXVIIN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPREXVIIN.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPREXVIIN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPREXVIIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPREXVIIN.ForeColor = System.Drawing.Color.Black
        Me.lblPREXVIIN.Location = New System.Drawing.Point(133, 470)
        Me.lblPREXVIIN.Name = "lblPREXVIIN"
        Me.lblPREXVIIN.Size = New System.Drawing.Size(792, 20)
        Me.lblPREXVIIN.TabIndex = 68
        '
        'Formula
        '
        Me.Formula.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Formula.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Formula.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Formula.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Formula.ForeColor = System.Drawing.Color.Black
        Me.Formula.Location = New System.Drawing.Point(17, 470)
        Me.Formula.Name = "Formula"
        Me.Formula.Size = New System.Drawing.Size(112, 20)
        Me.Formula.TabIndex = 67
        Me.Formula.Text = "Vigencia inicial"
        '
        'lblPREXCONC
        '
        Me.lblPREXCONC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPREXCONC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPREXCONC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPREXCONC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPREXCONC.ForeColor = System.Drawing.Color.Black
        Me.lblPREXCONC.Location = New System.Drawing.Point(575, 446)
        Me.lblPREXCONC.Name = "lblPREXCONC"
        Me.lblPREXCONC.Size = New System.Drawing.Size(350, 20)
        Me.lblPREXCONC.TabIndex = 66
        '
        'LB
        '
        Me.LB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LB.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.LB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB.ForeColor = System.Drawing.Color.Black
        Me.LB.Location = New System.Drawing.Point(459, 446)
        Me.LB.Name = "LB"
        Me.LB.Size = New System.Drawing.Size(112, 20)
        Me.LB.TabIndex = 65
        Me.LB.Text = "Concepto"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvPREDEXEN_1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvPREDEXEN_2)
        Me.SplitContainer1.Size = New System.Drawing.Size(908, 357)
        Me.SplitContainer1.SplitterDistance = 171
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 64
        '
        'dgvPREDEXEN_1
        '
        Me.dgvPREDEXEN_1.AccessibleDescription = "Predios exentos"
        Me.dgvPREDEXEN_1.AllowUserToAddRows = False
        Me.dgvPREDEXEN_1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvPREDEXEN_1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPREDEXEN_1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPREDEXEN_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPREDEXEN_1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvPREDEXEN_1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvPREDEXEN_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPREDEXEN_1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPREDEXEN_1.ColumnHeadersHeight = 40
        Me.dgvPREDEXEN_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPREDEXEN_1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvPREDEXEN_1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvPREDEXEN_1.Location = New System.Drawing.Point(3, 3)
        Me.dgvPREDEXEN_1.MultiSelect = False
        Me.dgvPREDEXEN_1.Name = "dgvPREDEXEN_1"
        Me.dgvPREDEXEN_1.ReadOnly = True
        Me.dgvPREDEXEN_1.RowHeadersVisible = False
        Me.dgvPREDEXEN_1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvPREDEXEN_1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPREDEXEN_1.ShowCellToolTips = False
        Me.dgvPREDEXEN_1.Size = New System.Drawing.Size(902, 165)
        Me.dgvPREDEXEN_1.StandardTab = True
        Me.dgvPREDEXEN_1.TabIndex = 0
        '
        'dgvPREDEXEN_2
        '
        Me.dgvPREDEXEN_2.AccessibleDescription = "Predios exentos"
        Me.dgvPREDEXEN_2.AllowUserToAddRows = False
        Me.dgvPREDEXEN_2.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvPREDEXEN_2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPREDEXEN_2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPREDEXEN_2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPREDEXEN_2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvPREDEXEN_2.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvPREDEXEN_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPREDEXEN_2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPREDEXEN_2.ColumnHeadersHeight = 40
        Me.dgvPREDEXEN_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPREDEXEN_2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvPREDEXEN_2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvPREDEXEN_2.Location = New System.Drawing.Point(3, 3)
        Me.dgvPREDEXEN_2.MultiSelect = False
        Me.dgvPREDEXEN_2.Name = "dgvPREDEXEN_2"
        Me.dgvPREDEXEN_2.ReadOnly = True
        Me.dgvPREDEXEN_2.RowHeadersVisible = False
        Me.dgvPREDEXEN_2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvPREDEXEN_2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPREDEXEN_2.ShowCellToolTips = False
        Me.dgvPREDEXEN_2.Size = New System.Drawing.Size(902, 175)
        Me.dgvPREDEXEN_2.StandardTab = True
        Me.dgvPREDEXEN_2.TabIndex = 60
        '
        'lblPREXTIIM
        '
        Me.lblPREXTIIM.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPREXTIIM.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPREXTIIM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPREXTIIM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPREXTIIM.ForeColor = System.Drawing.Color.Black
        Me.lblPREXTIIM.Location = New System.Drawing.Point(575, 421)
        Me.lblPREXTIIM.Name = "lblPREXTIIM"
        Me.lblPREXTIIM.Size = New System.Drawing.Size(350, 20)
        Me.lblPREXTIIM.TabIndex = 58
        '
        'lblTIPO
        '
        Me.lblTIPO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTIPO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblTIPO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTIPO.ForeColor = System.Drawing.Color.Black
        Me.lblTIPO.Location = New System.Drawing.Point(459, 421)
        Me.lblTIPO.Name = "lblTIPO"
        Me.lblTIPO.Size = New System.Drawing.Size(112, 20)
        Me.lblTIPO.TabIndex = 57
        Me.lblTIPO.Text = "Tipo de impuesto"
        '
        'lblPREXVIFI
        '
        Me.lblPREXVIFI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPREXVIFI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPREXVIFI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPREXVIFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPREXVIFI.ForeColor = System.Drawing.Color.Black
        Me.lblPREXVIFI.Location = New System.Drawing.Point(575, 398)
        Me.lblPREXVIFI.Name = "lblPREXVIFI"
        Me.lblPREXVIFI.Size = New System.Drawing.Size(350, 20)
        Me.lblPREXVIFI.TabIndex = 56
        '
        'lblVIGENCIA
        '
        Me.lblVIGENCIA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVIGENCIA.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblVIGENCIA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVIGENCIA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVIGENCIA.ForeColor = System.Drawing.Color.Black
        Me.lblVIGENCIA.Location = New System.Drawing.Point(459, 398)
        Me.lblVIGENCIA.Name = "lblVIGENCIA"
        Me.lblVIGENCIA.Size = New System.Drawing.Size(112, 20)
        Me.lblVIGENCIA.TabIndex = 55
        Me.lblVIGENCIA.Text = "Vigencia final"
        '
        'lblPREXCLSE
        '
        Me.lblPREXCLSE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPREXCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPREXCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPREXCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPREXCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblPREXCLSE.Location = New System.Drawing.Point(133, 446)
        Me.lblPREXCLSE.Name = "lblPREXCLSE"
        Me.lblPREXCLSE.Size = New System.Drawing.Size(322, 20)
        Me.lblPREXCLSE.TabIndex = 54
        '
        'lblSECTOR
        '
        Me.lblSECTOR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSECTOR.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblSECTOR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSECTOR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSECTOR.ForeColor = System.Drawing.Color.Black
        Me.lblSECTOR.Location = New System.Drawing.Point(17, 446)
        Me.lblSECTOR.Name = "lblSECTOR"
        Me.lblSECTOR.Size = New System.Drawing.Size(112, 20)
        Me.lblSECTOR.TabIndex = 53
        Me.lblSECTOR.Text = "Clase o sector"
        '
        'lblPREXDEPA
        '
        Me.lblPREXDEPA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPREXDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPREXDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPREXDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPREXDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblPREXDEPA.Location = New System.Drawing.Point(133, 398)
        Me.lblPREXDEPA.Name = "lblPREXDEPA"
        Me.lblPREXDEPA.Size = New System.Drawing.Size(322, 20)
        Me.lblPREXDEPA.TabIndex = 52
        '
        'lblDEPARTAMENTO
        '
        Me.lblDEPARTAMENTO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDEPARTAMENTO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblDEPARTAMENTO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDEPARTAMENTO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDEPARTAMENTO.ForeColor = System.Drawing.Color.Black
        Me.lblDEPARTAMENTO.Location = New System.Drawing.Point(17, 398)
        Me.lblDEPARTAMENTO.Name = "lblDEPARTAMENTO"
        Me.lblDEPARTAMENTO.Size = New System.Drawing.Size(112, 20)
        Me.lblDEPARTAMENTO.TabIndex = 51
        Me.lblDEPARTAMENTO.Text = "Departamento"
        '
        'lblPREXMUNI
        '
        Me.lblPREXMUNI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPREXMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPREXMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPREXMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPREXMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblPREXMUNI.Location = New System.Drawing.Point(133, 422)
        Me.lblPREXMUNI.Name = "lblPREXMUNI"
        Me.lblPREXMUNI.Size = New System.Drawing.Size(322, 20)
        Me.lblPREXMUNI.TabIndex = 50
        '
        'lblMUNICIPIO
        '
        Me.lblMUNICIPIO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMUNICIPIO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMUNICIPIO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUNICIPIO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUNICIPIO.ForeColor = System.Drawing.Color.Black
        Me.lblMUNICIPIO.Location = New System.Drawing.Point(17, 422)
        Me.lblMUNICIPIO.Name = "lblMUNICIPIO"
        Me.lblMUNICIPIO.Size = New System.Drawing.Size(112, 20)
        Me.lblMUNICIPIO.TabIndex = 49
        Me.lblMUNICIPIO.Text = "Municipio"
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 573)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(969, 25)
        Me.strBARRESTA.TabIndex = 44
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
        'BindingNavigator_PREDEXEN_1
        '
        Me.BindingNavigator_PREDEXEN_1.AddNewItem = Nothing
        Me.BindingNavigator_PREDEXEN_1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator_PREDEXEN_1.DeleteItem = Nothing
        Me.BindingNavigator_PREDEXEN_1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.cmdAGREGAR, Me.cmdMODIFICAR, Me.cmdELIMINAR, Me.ToolStripSeparator3, Me.cmdCONSULTAR, Me.cmdRECONSULTAR, Me.ToolStripSeparator1, Me.cmdSALIR, Me.ToolStripSeparator2})
        Me.BindingNavigator_PREDEXEN_1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator_PREDEXEN_1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator_PREDEXEN_1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator_PREDEXEN_1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator_PREDEXEN_1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator_PREDEXEN_1.Name = "BindingNavigator_PREDEXEN_1"
        Me.BindingNavigator_PREDEXEN_1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator_PREDEXEN_1.Size = New System.Drawing.Size(969, 25)
        Me.BindingNavigator_PREDEXEN_1.TabIndex = 43
        Me.BindingNavigator_PREDEXEN_1.Text = "BindingNavigator1"
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
        'frm_PREDEXEN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 598)
        Me.Controls.Add(Me.fraFORMMUNI)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.BindingNavigator_PREDEXEN_1)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_PREDEXEN"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "PREDIOS EXENTOS POR CONCEPTO"
        Me.fraFORMMUNI.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvPREDEXEN_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPREDEXEN_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        CType(Me.BindingNavigator_PREDEXEN_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator_PREDEXEN_1.ResumeLayout(False)
        Me.BindingNavigator_PREDEXEN_1.PerformLayout()
        CType(Me.BindingSource_PREDEXEN_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraFORMMUNI As System.Windows.Forms.GroupBox
    Friend WithEvents lblPREXVIIN As System.Windows.Forms.Label
    Friend WithEvents Formula As System.Windows.Forms.Label
    Friend WithEvents lblPREXCONC As System.Windows.Forms.Label
    Friend WithEvents LB As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvPREDEXEN_1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgvPREDEXEN_2 As System.Windows.Forms.DataGridView
    Friend WithEvents lblPREXTIIM As System.Windows.Forms.Label
    Friend WithEvents lblTIPO As System.Windows.Forms.Label
    Friend WithEvents lblPREXVIFI As System.Windows.Forms.Label
    Friend WithEvents lblVIGENCIA As System.Windows.Forms.Label
    Friend WithEvents lblPREXCLSE As System.Windows.Forms.Label
    Friend WithEvents lblSECTOR As System.Windows.Forms.Label
    Friend WithEvents lblPREXDEPA As System.Windows.Forms.Label
    Friend WithEvents lblDEPARTAMENTO As System.Windows.Forms.Label
    Friend WithEvents lblPREXMUNI As System.Windows.Forms.Label
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BindingNavigator_PREDEXEN_1 As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents BindingSource_PREDEXEN_1 As System.Windows.Forms.BindingSource
    Friend WithEvents lblPREXOBSE As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
