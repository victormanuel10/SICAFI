<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CAMPOS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_CAMPOS))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BindingNavigator_CAMPOS_1 = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.BindingSource_CAMPOS_1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.fraConcepto = New System.Windows.Forms.GroupBox()
        Me.lblCAMPTASI = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCAMPTAMA = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgvCAMPOS1 = New System.Windows.Forms.DataGridView()
        Me.dgvCAMPOS2 = New System.Windows.Forms.DataGridView()
        Me.lblCAMPTABL = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCAMPPROC = New System.Windows.Forms.Label()
        Me.lblProcedimiento = New System.Windows.Forms.Label()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.BindingNavigator_CAMPOS_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator_CAMPOS_1.SuspendLayout()
        CType(Me.BindingSource_CAMPOS_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraConcepto.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvCAMPOS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCAMPOS2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        Me.SuspendLayout()
        '
        'BindingNavigator_CAMPOS_1
        '
        Me.BindingNavigator_CAMPOS_1.AddNewItem = Nothing
        Me.BindingNavigator_CAMPOS_1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator_CAMPOS_1.DeleteItem = Nothing
        Me.BindingNavigator_CAMPOS_1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.cmdAGREGAR, Me.cmdMODIFICAR, Me.cmdELIMINAR, Me.ToolStripSeparator3, Me.cmdCONSULTAR, Me.cmdRECONSULTAR, Me.ToolStripSeparator1, Me.cmdSALIR, Me.ToolStripSeparator2})
        Me.BindingNavigator_CAMPOS_1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator_CAMPOS_1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator_CAMPOS_1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator_CAMPOS_1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator_CAMPOS_1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator_CAMPOS_1.Name = "BindingNavigator_CAMPOS_1"
        Me.BindingNavigator_CAMPOS_1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator_CAMPOS_1.Size = New System.Drawing.Size(1048, 25)
        Me.BindingNavigator_CAMPOS_1.TabIndex = 30
        Me.BindingNavigator_CAMPOS_1.Text = "BindingNavigator1"
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
        Me.cmdCONSULTAR.AccessibleDescription = "Consultar"
        Me.cmdCONSULTAR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdCONSULTAR.Image = Global.SICAFI.My.Resources.Resources._045
        Me.cmdCONSULTAR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdCONSULTAR.Name = "cmdCONSULTAR"
        Me.cmdCONSULTAR.Size = New System.Drawing.Size(23, 22)
        Me.cmdCONSULTAR.ToolTipText = "Consultar (F7)"
        '
        'cmdRECONSULTAR
        '
        Me.cmdRECONSULTAR.AccessibleDescription = "Reconsultar"
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
        Me.cmdSALIR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(23, 22)
        Me.cmdSALIR.ToolTipText = "Salir "
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'fraConcepto
        '
        Me.fraConcepto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraConcepto.BackColor = System.Drawing.SystemColors.Control
        Me.fraConcepto.Controls.Add(Me.lblCAMPTASI)
        Me.fraConcepto.Controls.Add(Me.Label3)
        Me.fraConcepto.Controls.Add(Me.lblCAMPTAMA)
        Me.fraConcepto.Controls.Add(Me.Label5)
        Me.fraConcepto.Controls.Add(Me.SplitContainer1)
        Me.fraConcepto.Controls.Add(Me.lblCAMPTABL)
        Me.fraConcepto.Controls.Add(Me.Label2)
        Me.fraConcepto.Controls.Add(Me.lblCAMPPROC)
        Me.fraConcepto.Controls.Add(Me.lblProcedimiento)
        Me.fraConcepto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraConcepto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraConcepto.Location = New System.Drawing.Point(12, 33)
        Me.fraConcepto.Name = "fraConcepto"
        Me.fraConcepto.Size = New System.Drawing.Size(1024, 515)
        Me.fraConcepto.TabIndex = 29
        Me.fraConcepto.TabStop = False
        Me.fraConcepto.Text = "CAMPOS"
        '
        'lblCAMPTASI
        '
        Me.lblCAMPTASI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCAMPTASI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCAMPTASI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAMPTASI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAMPTASI.ForeColor = System.Drawing.Color.Black
        Me.lblCAMPTASI.Location = New System.Drawing.Point(641, 480)
        Me.lblCAMPTASI.Name = "lblCAMPTASI"
        Me.lblCAMPTASI.Size = New System.Drawing.Size(278, 20)
        Me.lblCAMPTASI.TabIndex = 61
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(471, 480)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(166, 20)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Tabla sistema"
        '
        'lblCAMPTAMA
        '
        Me.lblCAMPTAMA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCAMPTAMA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCAMPTAMA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAMPTAMA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAMPTAMA.ForeColor = System.Drawing.Color.Black
        Me.lblCAMPTAMA.Location = New System.Drawing.Point(641, 457)
        Me.lblCAMPTAMA.Name = "lblCAMPTAMA"
        Me.lblCAMPTAMA.Size = New System.Drawing.Size(278, 20)
        Me.lblCAMPTAMA.TabIndex = 59
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(471, 457)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(166, 20)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "Tabla mantenimiento"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(19, 20)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvCAMPOS1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvCAMPOS2)
        Me.SplitContainer1.Size = New System.Drawing.Size(986, 423)
        Me.SplitContainer1.SplitterDistance = 210
        Me.SplitContainer1.TabIndex = 57
        '
        'dgvCAMPOS1
        '
        Me.dgvCAMPOS1.AccessibleDescription = "Campos"
        Me.dgvCAMPOS1.AllowUserToAddRows = False
        Me.dgvCAMPOS1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCAMPOS1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCAMPOS1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCAMPOS1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCAMPOS1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCAMPOS1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCAMPOS1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCAMPOS1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCAMPOS1.ColumnHeadersHeight = 40
        Me.dgvCAMPOS1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvCAMPOS1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCAMPOS1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCAMPOS1.Location = New System.Drawing.Point(3, 3)
        Me.dgvCAMPOS1.Name = "dgvCAMPOS1"
        Me.dgvCAMPOS1.ReadOnly = True
        Me.dgvCAMPOS1.RowHeadersVisible = False
        Me.dgvCAMPOS1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvCAMPOS1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCAMPOS1.ShowCellToolTips = False
        Me.dgvCAMPOS1.Size = New System.Drawing.Size(980, 204)
        Me.dgvCAMPOS1.StandardTab = True
        Me.dgvCAMPOS1.TabIndex = 0
        '
        'dgvCAMPOS2
        '
        Me.dgvCAMPOS2.AccessibleDescription = "Campos"
        Me.dgvCAMPOS2.AllowUserToAddRows = False
        Me.dgvCAMPOS2.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCAMPOS2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCAMPOS2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCAMPOS2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCAMPOS2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCAMPOS2.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCAMPOS2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCAMPOS2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCAMPOS2.ColumnHeadersHeight = 40
        Me.dgvCAMPOS2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvCAMPOS2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCAMPOS2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCAMPOS2.Location = New System.Drawing.Point(3, 1)
        Me.dgvCAMPOS2.Name = "dgvCAMPOS2"
        Me.dgvCAMPOS2.ReadOnly = True
        Me.dgvCAMPOS2.RowHeadersVisible = False
        Me.dgvCAMPOS2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvCAMPOS2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCAMPOS2.ShowCellToolTips = False
        Me.dgvCAMPOS2.Size = New System.Drawing.Size(980, 206)
        Me.dgvCAMPOS2.StandardTab = True
        Me.dgvCAMPOS2.TabIndex = 1
        '
        'lblCAMPTABL
        '
        Me.lblCAMPTABL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCAMPTABL.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCAMPTABL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAMPTABL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAMPTABL.ForeColor = System.Drawing.Color.Black
        Me.lblCAMPTABL.Location = New System.Drawing.Point(189, 480)
        Me.lblCAMPTABL.Name = "lblCAMPTABL"
        Me.lblCAMPTABL.Size = New System.Drawing.Size(278, 20)
        Me.lblCAMPTABL.TabIndex = 56
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 480)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(166, 20)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Tabla"
        '
        'lblCAMPPROC
        '
        Me.lblCAMPPROC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCAMPPROC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCAMPPROC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAMPPROC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAMPPROC.ForeColor = System.Drawing.Color.Black
        Me.lblCAMPPROC.Location = New System.Drawing.Point(189, 457)
        Me.lblCAMPPROC.Name = "lblCAMPPROC"
        Me.lblCAMPPROC.Size = New System.Drawing.Size(278, 20)
        Me.lblCAMPPROC.TabIndex = 54
        '
        'lblProcedimiento
        '
        Me.lblProcedimiento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblProcedimiento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblProcedimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblProcedimiento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcedimiento.ForeColor = System.Drawing.Color.Black
        Me.lblProcedimiento.Location = New System.Drawing.Point(19, 457)
        Me.lblProcedimiento.Name = "lblProcedimiento"
        Me.lblProcedimiento.Size = New System.Drawing.Size(166, 20)
        Me.lblProcedimiento.TabIndex = 53
        Me.lblProcedimiento.Text = "Procedimiento"
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 563)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(1048, 25)
        Me.strBARRESTA.TabIndex = 28
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
        'frm_CAMPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1048, 588)
        Me.Controls.Add(Me.BindingNavigator_CAMPOS_1)
        Me.Controls.Add(Me.fraConcepto)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_CAMPOS"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "MANTENIMIENTO DE CAMPOS"
        CType(Me.BindingNavigator_CAMPOS_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator_CAMPOS_1.ResumeLayout(False)
        Me.BindingNavigator_CAMPOS_1.PerformLayout()
        CType(Me.BindingSource_CAMPOS_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraConcepto.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvCAMPOS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCAMPOS2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BindingNavigator_CAMPOS_1 As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents BindingSource_CAMPOS_1 As System.Windows.Forms.BindingSource
    Friend WithEvents fraConcepto As System.Windows.Forms.GroupBox
    Friend WithEvents lblCAMPTABL As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCAMPPROC As System.Windows.Forms.Label
    Friend WithEvents lblProcedimiento As System.Windows.Forms.Label
    Friend WithEvents dgvCAMPOS1 As System.Windows.Forms.DataGridView
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvCAMPOS2 As System.Windows.Forms.DataGridView
    Friend WithEvents lblCAMPTASI As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCAMPTAMA As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
