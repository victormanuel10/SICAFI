<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_PERMCOCO
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_PERMCOCO))
        Me.fraVIGEACTU = New System.Windows.Forms.GroupBox()
        Me.lblPECCCOCO = New System.Windows.Forms.Label()
        Me.lblclaseosector = New System.Windows.Forms.Label()
        Me.lblPECCUSUA = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPECCFORM = New System.Windows.Forms.Label()
        Me.lblMUNICIPIO = New System.Windows.Forms.Label()
        Me.dgvPERMCOCO = New System.Windows.Forms.DataGridView()
        Me.BindingSource_PERMCOCO_1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BindingNavigator_PERMCOCO_1 = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.fraVIGEACTU.SuspendLayout()
        CType(Me.dgvPERMCOCO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource_PERMCOCO_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        CType(Me.BindingNavigator_PERMCOCO_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator_PERMCOCO_1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraVIGEACTU
        '
        Me.fraVIGEACTU.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraVIGEACTU.BackColor = System.Drawing.SystemColors.Control
        Me.fraVIGEACTU.Controls.Add(Me.lblPECCCOCO)
        Me.fraVIGEACTU.Controls.Add(Me.lblclaseosector)
        Me.fraVIGEACTU.Controls.Add(Me.lblPECCUSUA)
        Me.fraVIGEACTU.Controls.Add(Me.Label2)
        Me.fraVIGEACTU.Controls.Add(Me.lblPECCFORM)
        Me.fraVIGEACTU.Controls.Add(Me.lblMUNICIPIO)
        Me.fraVIGEACTU.Controls.Add(Me.dgvPERMCOCO)
        Me.fraVIGEACTU.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraVIGEACTU.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraVIGEACTU.Location = New System.Drawing.Point(11, 39)
        Me.fraVIGEACTU.Name = "fraVIGEACTU"
        Me.fraVIGEACTU.Size = New System.Drawing.Size(976, 514)
        Me.fraVIGEACTU.TabIndex = 31
        Me.fraVIGEACTU.TabStop = False
        Me.fraVIGEACTU.Text = "PERMISO CONTROL DE COMANDOS"
        '
        'lblPECCCOCO
        '
        Me.lblPECCCOCO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPECCCOCO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPECCCOCO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPECCCOCO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPECCCOCO.ForeColor = System.Drawing.Color.Black
        Me.lblPECCCOCO.Location = New System.Drawing.Point(161, 475)
        Me.lblPECCCOCO.Name = "lblPECCCOCO"
        Me.lblPECCCOCO.Size = New System.Drawing.Size(797, 20)
        Me.lblPECCCOCO.TabIndex = 54
        '
        'lblclaseosector
        '
        Me.lblclaseosector.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblclaseosector.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblclaseosector.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblclaseosector.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblclaseosector.ForeColor = System.Drawing.Color.Black
        Me.lblclaseosector.Location = New System.Drawing.Point(19, 475)
        Me.lblclaseosector.Name = "lblclaseosector"
        Me.lblclaseosector.Size = New System.Drawing.Size(138, 20)
        Me.lblclaseosector.TabIndex = 53
        Me.lblclaseosector.Text = "Control de comandos"
        '
        'lblPECCUSUA
        '
        Me.lblPECCUSUA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPECCUSUA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPECCUSUA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPECCUSUA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPECCUSUA.ForeColor = System.Drawing.Color.Black
        Me.lblPECCUSUA.Location = New System.Drawing.Point(161, 427)
        Me.lblPECCUSUA.Name = "lblPECCUSUA"
        Me.lblPECCUSUA.Size = New System.Drawing.Size(797, 20)
        Me.lblPECCUSUA.TabIndex = 52
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 427)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 20)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Usuario"
        '
        'lblPECCFORM
        '
        Me.lblPECCFORM.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPECCFORM.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPECCFORM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPECCFORM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPECCFORM.ForeColor = System.Drawing.Color.Black
        Me.lblPECCFORM.Location = New System.Drawing.Point(161, 451)
        Me.lblPECCFORM.Name = "lblPECCFORM"
        Me.lblPECCFORM.Size = New System.Drawing.Size(797, 20)
        Me.lblPECCFORM.TabIndex = 50
        '
        'lblMUNICIPIO
        '
        Me.lblMUNICIPIO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMUNICIPIO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMUNICIPIO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUNICIPIO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUNICIPIO.ForeColor = System.Drawing.Color.Black
        Me.lblMUNICIPIO.Location = New System.Drawing.Point(19, 451)
        Me.lblMUNICIPIO.Name = "lblMUNICIPIO"
        Me.lblMUNICIPIO.Size = New System.Drawing.Size(138, 20)
        Me.lblMUNICIPIO.TabIndex = 49
        Me.lblMUNICIPIO.Text = "Formulario"
        '
        'dgvPERMCOCO
        '
        Me.dgvPERMCOCO.AccessibleDescription = "Permiso control comandos"
        Me.dgvPERMCOCO.AllowUserToAddRows = False
        Me.dgvPERMCOCO.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvPERMCOCO.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPERMCOCO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPERMCOCO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPERMCOCO.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvPERMCOCO.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvPERMCOCO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPERMCOCO.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPERMCOCO.ColumnHeadersHeight = 40
        Me.dgvPERMCOCO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPERMCOCO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvPERMCOCO.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvPERMCOCO.Location = New System.Drawing.Point(19, 26)
        Me.dgvPERMCOCO.Name = "dgvPERMCOCO"
        Me.dgvPERMCOCO.ReadOnly = True
        Me.dgvPERMCOCO.RowHeadersVisible = False
        Me.dgvPERMCOCO.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvPERMCOCO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPERMCOCO.ShowCellToolTips = False
        Me.dgvPERMCOCO.Size = New System.Drawing.Size(939, 386)
        Me.dgvPERMCOCO.StandardTab = True
        Me.dgvPERMCOCO.TabIndex = 0
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 565)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(1004, 25)
        Me.strBARRESTA.TabIndex = 30
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
        'BindingNavigator_PERMCOCO_1
        '
        Me.BindingNavigator_PERMCOCO_1.AddNewItem = Nothing
        Me.BindingNavigator_PERMCOCO_1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator_PERMCOCO_1.DeleteItem = Nothing
        Me.BindingNavigator_PERMCOCO_1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.cmdAGREGAR, Me.cmdMODIFICAR, Me.cmdELIMINAR, Me.ToolStripSeparator3, Me.cmdCONSULTAR, Me.cmdRECONSULTAR, Me.ToolStripSeparator1, Me.cmdSALIR, Me.ToolStripSeparator2})
        Me.BindingNavigator_PERMCOCO_1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator_PERMCOCO_1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator_PERMCOCO_1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator_PERMCOCO_1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator_PERMCOCO_1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator_PERMCOCO_1.Name = "BindingNavigator_PERMCOCO_1"
        Me.BindingNavigator_PERMCOCO_1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator_PERMCOCO_1.Size = New System.Drawing.Size(1004, 25)
        Me.BindingNavigator_PERMCOCO_1.TabIndex = 29
        Me.BindingNavigator_PERMCOCO_1.Text = "BindingNavigator1"
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
        'frm_PERMCOCO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1004, 590)
        Me.Controls.Add(Me.fraVIGEACTU)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.BindingNavigator_PERMCOCO_1)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_PERMCOCO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "PERMISO CONTROL DE COMANDOS"
        Me.fraVIGEACTU.ResumeLayout(False)
        CType(Me.dgvPERMCOCO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource_PERMCOCO_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        CType(Me.BindingNavigator_PERMCOCO_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator_PERMCOCO_1.ResumeLayout(False)
        Me.BindingNavigator_PERMCOCO_1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraVIGEACTU As System.Windows.Forms.GroupBox
    Friend WithEvents lblPECCCOCO As System.Windows.Forms.Label
    Friend WithEvents lblclaseosector As System.Windows.Forms.Label
    Friend WithEvents lblPECCUSUA As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPECCFORM As System.Windows.Forms.Label
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents dgvPERMCOCO As System.Windows.Forms.DataGridView
    Friend WithEvents BindingSource_PERMCOCO_1 As System.Windows.Forms.BindingSource
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BindingNavigator_PERMCOCO_1 As System.Windows.Forms.BindingNavigator
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
End Class
