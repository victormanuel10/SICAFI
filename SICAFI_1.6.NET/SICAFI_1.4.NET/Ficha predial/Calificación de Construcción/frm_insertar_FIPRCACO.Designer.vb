<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_FIPRCACO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_insertar_FIPRCACO))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fraCOMANDOS = New System.Windows.Forms.GroupBox()
        Me.cmdELIMINAR = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BindingSource_FIPRCACO_1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigator_FIPRCACO_1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.dgvFIPRCACO = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rbdFPCCOTRA = New System.Windows.Forms.RadioButton()
        Me.rbdFPCCINDU = New System.Windows.Forms.RadioButton()
        Me.rbdFPCCCOME = New System.Windows.Forms.RadioButton()
        Me.rbdFPCCRESI = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFPCCCOHI = New System.Windows.Forms.Label()
        Me.lblFPCCCOPA = New System.Windows.Forms.Label()
        Me.lblFPCCTOTA = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtFPCCCODI = New System.Windows.Forms.TextBox()
        Me.lblUnidad = New System.Windows.Forms.Label()
        Me.lblFPCCCODI = New System.Windows.Forms.Label()
        Me.lblClaseDeConstruccion2 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.fraCOMANDOS.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        CType(Me.BindingSource_FIPRCACO_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator_FIPRCACO_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator_FIPRCACO_1.SuspendLayout()
        CType(Me.dgvFIPRCACO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraCOMANDOS
        '
        Me.fraCOMANDOS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraCOMANDOS.Controls.Add(Me.cmdELIMINAR)
        Me.fraCOMANDOS.Controls.Add(Me.cmdSALIR)
        Me.fraCOMANDOS.Controls.Add(Me.cmdGUARDAR)
        Me.fraCOMANDOS.Location = New System.Drawing.Point(12, 513)
        Me.fraCOMANDOS.Name = "fraCOMANDOS"
        Me.fraCOMANDOS.Size = New System.Drawing.Size(752, 46)
        Me.fraCOMANDOS.TabIndex = 2
        Me.fraCOMANDOS.TabStop = False
        '
        'cmdELIMINAR
        '
        Me.cmdELIMINAR.AccessibleDescription = "Eliminar"
        Me.cmdELIMINAR.Image = Global.SICAFI.My.Resources.Resources._132
        Me.cmdELIMINAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdELIMINAR.Location = New System.Drawing.Point(324, 14)
        Me.cmdELIMINAR.Name = "cmdELIMINAR"
        Me.cmdELIMINAR.Size = New System.Drawing.Size(106, 23)
        Me.cmdELIMINAR.TabIndex = 2
        Me.cmdELIMINAR.Text = "&Eliminar"
        Me.cmdELIMINAR.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(436, 14)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(106, 23)
        Me.cmdSALIR.TabIndex = 3
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = CType(resources.GetObject("cmdGUARDAR.Image"), System.Drawing.Image)
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(212, 14)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(106, 23)
        Me.cmdGUARDAR.TabIndex = 1
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 600)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(792, 25)
        Me.strBARRESTA.TabIndex = 53
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
        'BindingNavigator_FIPRCACO_1
        '
        Me.BindingNavigator_FIPRCACO_1.AddNewItem = Nothing
        Me.BindingNavigator_FIPRCACO_1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator_FIPRCACO_1.DeleteItem = Nothing
        Me.BindingNavigator_FIPRCACO_1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator_FIPRCACO_1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator_FIPRCACO_1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator_FIPRCACO_1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator_FIPRCACO_1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator_FIPRCACO_1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator_FIPRCACO_1.Name = "BindingNavigator_FIPRCACO_1"
        Me.BindingNavigator_FIPRCACO_1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator_FIPRCACO_1.Size = New System.Drawing.Size(792, 25)
        Me.BindingNavigator_FIPRCACO_1.TabIndex = 54
        Me.BindingNavigator_FIPRCACO_1.Text = "BindingNavigator1"
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
        'dgvFIPRCACO
        '
        Me.dgvFIPRCACO.AccessibleDescription = "Calificación "
        Me.dgvFIPRCACO.AllowUserToAddRows = False
        Me.dgvFIPRCACO.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvFIPRCACO.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFIPRCACO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFIPRCACO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvFIPRCACO.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvFIPRCACO.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvFIPRCACO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvFIPRCACO.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvFIPRCACO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvFIPRCACO.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvFIPRCACO.Location = New System.Drawing.Point(17, 123)
        Me.dgvFIPRCACO.MultiSelect = False
        Me.dgvFIPRCACO.Name = "dgvFIPRCACO"
        Me.dgvFIPRCACO.ReadOnly = True
        Me.dgvFIPRCACO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFIPRCACO.ShowCellToolTips = False
        Me.dgvFIPRCACO.Size = New System.Drawing.Size(715, 309)
        Me.dgvFIPRCACO.StandardTab = True
        Me.dgvFIPRCACO.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblFPCCCOHI)
        Me.GroupBox1.Controls.Add(Me.lblFPCCCOPA)
        Me.GroupBox1.Controls.Add(Me.lblFPCCTOTA)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtFPCCCODI)
        Me.GroupBox1.Controls.Add(Me.lblUnidad)
        Me.GroupBox1.Controls.Add(Me.lblFPCCCODI)
        Me.GroupBox1.Controls.Add(Me.lblClaseDeConstruccion2)
        Me.GroupBox1.Controls.Add(Me.dgvFIPRCACO)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(752, 467)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "INSERTAR CALIFICACIÓN DE CONSTRUCCIÓN"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox5.Controls.Add(Me.rbdFPCCOTRA)
        Me.GroupBox5.Controls.Add(Me.rbdFPCCINDU)
        Me.GroupBox5.Controls.Add(Me.rbdFPCCCOME)
        Me.GroupBox5.Controls.Add(Me.rbdFPCCRESI)
        Me.GroupBox5.Location = New System.Drawing.Point(375, 68)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(358, 49)
        Me.GroupBox5.TabIndex = 368
        Me.GroupBox5.TabStop = False
        '
        'rbdFPCCOTRA
        '
        Me.rbdFPCCOTRA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbdFPCCOTRA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbdFPCCOTRA.Location = New System.Drawing.Point(288, 15)
        Me.rbdFPCCOTRA.Name = "rbdFPCCOTRA"
        Me.rbdFPCCOTRA.Size = New System.Drawing.Size(57, 24)
        Me.rbdFPCCOTRA.TabIndex = 3
        Me.rbdFPCCOTRA.Text = "&Otras"
        '
        'rbdFPCCINDU
        '
        Me.rbdFPCCINDU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbdFPCCINDU.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbdFPCCINDU.Location = New System.Drawing.Point(203, 15)
        Me.rbdFPCCINDU.Name = "rbdFPCCINDU"
        Me.rbdFPCCINDU.Size = New System.Drawing.Size(79, 24)
        Me.rbdFPCCINDU.TabIndex = 2
        Me.rbdFPCCINDU.Text = "&Industrial"
        '
        'rbdFPCCCOME
        '
        Me.rbdFPCCCOME.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbdFPCCCOME.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbdFPCCCOME.Location = New System.Drawing.Point(117, 15)
        Me.rbdFPCCCOME.Name = "rbdFPCCCOME"
        Me.rbdFPCCCOME.Size = New System.Drawing.Size(80, 24)
        Me.rbdFPCCCOME.TabIndex = 1
        Me.rbdFPCCCOME.Text = "&Comercial"
        '
        'rbdFPCCRESI
        '
        Me.rbdFPCCRESI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbdFPCCRESI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbdFPCCRESI.Location = New System.Drawing.Point(23, 15)
        Me.rbdFPCCRESI.Name = "rbdFPCCRESI"
        Me.rbdFPCCRESI.Size = New System.Drawing.Size(90, 24)
        Me.rbdFPCCRESI.TabIndex = 0
        Me.rbdFPCCRESI.Text = "&Residencial"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(375, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(357, 20)
        Me.Label2.TabIndex = 367
        Me.Label2.Text = "Sub bloque de calificación"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(353, 20)
        Me.Label1.TabIndex = 366
        Me.Label1.Text = "Bloque de calificación"
        '
        'lblFPCCCOHI
        '
        Me.lblFPCCCOHI.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFPCCCOHI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFPCCCOHI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPCCCOHI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPCCCOHI.ForeColor = System.Drawing.Color.Black
        Me.lblFPCCCOHI.Location = New System.Drawing.Point(375, 49)
        Me.lblFPCCCOHI.Name = "lblFPCCCOHI"
        Me.lblFPCCCOHI.Size = New System.Drawing.Size(357, 20)
        Me.lblFPCCCOHI.TabIndex = 365
        '
        'lblFPCCCOPA
        '
        Me.lblFPCCCOPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFPCCCOPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPCCCOPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPCCCOPA.ForeColor = System.Drawing.Color.Black
        Me.lblFPCCCOPA.Location = New System.Drawing.Point(17, 49)
        Me.lblFPCCCOPA.Name = "lblFPCCCOPA"
        Me.lblFPCCCOPA.Size = New System.Drawing.Size(354, 20)
        Me.lblFPCCCOPA.TabIndex = 364
        '
        'lblFPCCTOTA
        '
        Me.lblFPCCTOTA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFPCCTOTA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFPCCTOTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPCCTOTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPCCTOTA.ForeColor = System.Drawing.Color.Black
        Me.lblFPCCTOTA.Location = New System.Drawing.Point(648, 438)
        Me.lblFPCCTOTA.Name = "lblFPCCTOTA"
        Me.lblFPCCTOTA.Size = New System.Drawing.Size(84, 20)
        Me.lblFPCCTOTA.TabIndex = 363
        Me.lblFPCCTOTA.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(560, 438)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 20)
        Me.Label12.TabIndex = 362
        Me.Label12.Text = "Total puntos :"
        '
        'txtFPCCCODI
        '
        Me.txtFPCCCODI.AccessibleDescription = "Código calificación"
        Me.txtFPCCCODI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFPCCCODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPCCCODI.ForeColor = System.Drawing.Color.Black
        Me.txtFPCCCODI.Location = New System.Drawing.Point(17, 97)
        Me.txtFPCCCODI.MaxLength = 3
        Me.txtFPCCCODI.Name = "txtFPCCCODI"
        Me.txtFPCCCODI.Size = New System.Drawing.Size(61, 20)
        Me.txtFPCCCODI.TabIndex = 1
        '
        'lblUnidad
        '
        Me.lblUnidad.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblUnidad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUnidad.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidad.ForeColor = System.Drawing.Color.Black
        Me.lblUnidad.Location = New System.Drawing.Point(17, 73)
        Me.lblUnidad.Name = "lblUnidad"
        Me.lblUnidad.Size = New System.Drawing.Size(61, 20)
        Me.lblUnidad.TabIndex = 361
        Me.lblUnidad.Text = "Código"
        '
        'lblFPCCCODI
        '
        Me.lblFPCCCODI.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFPCCCODI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFPCCCODI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPCCCODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPCCCODI.ForeColor = System.Drawing.Color.Black
        Me.lblFPCCCODI.Location = New System.Drawing.Point(81, 97)
        Me.lblFPCCCODI.Name = "lblFPCCCODI"
        Me.lblFPCCCODI.Size = New System.Drawing.Size(289, 20)
        Me.lblFPCCCODI.TabIndex = 360
        '
        'lblClaseDeConstruccion2
        '
        Me.lblClaseDeConstruccion2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblClaseDeConstruccion2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseDeConstruccion2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseDeConstruccion2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseDeConstruccion2.ForeColor = System.Drawing.Color.Black
        Me.lblClaseDeConstruccion2.Location = New System.Drawing.Point(81, 73)
        Me.lblClaseDeConstruccion2.Name = "lblClaseDeConstruccion2"
        Me.lblClaseDeConstruccion2.Size = New System.Drawing.Size(289, 20)
        Me.lblClaseDeConstruccion2.TabIndex = 359
        Me.lblClaseDeConstruccion2.Text = "Descripción"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.RightToLeft = True
        '
        'frm_insertar_FIPRCACO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdSALIR
        Me.ClientSize = New System.Drawing.Size(792, 625)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BindingNavigator_FIPRCACO_1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCOMANDOS)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(808, 661)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(808, 661)
        Me.Name = "frm_insertar_FIPRCACO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.fraCOMANDOS.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        CType(Me.BindingSource_FIPRCACO_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator_FIPRCACO_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator_FIPRCACO_1.ResumeLayout(False)
        Me.BindingNavigator_FIPRCACO_1.PerformLayout()
        CType(Me.dgvFIPRCACO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraCOMANDOS As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BindingSource_FIPRCACO_1 As System.Windows.Forms.BindingSource
    Friend WithEvents BindingNavigator_FIPRCACO_1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvFIPRCACO As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFPCCCODI As System.Windows.Forms.TextBox
    Friend WithEvents lblUnidad As System.Windows.Forms.Label
    Friend WithEvents lblFPCCCODI As System.Windows.Forms.Label
    Friend WithEvents lblClaseDeConstruccion2 As System.Windows.Forms.Label
    Friend WithEvents lblFPCCTOTA As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdELIMINAR As System.Windows.Forms.Button
    Friend WithEvents lblFPCCCOPA As System.Windows.Forms.Label
    Friend WithEvents lblFPCCCOHI As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdFPCCOTRA As System.Windows.Forms.RadioButton
    Friend WithEvents rbdFPCCINDU As System.Windows.Forms.RadioButton
    Friend WithEvents rbdFPCCCOME As System.Windows.Forms.RadioButton
    Friend WithEvents rbdFPCCRESI As System.Windows.Forms.RadioButton
End Class
