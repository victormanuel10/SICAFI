<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_bitacora_pendientes_liquidar_RESOCONS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_bitacora_pendientes_liquidar_RESOCONS))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdFinalizar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BindingNavigator_RESOCONS_1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdCONSULTAR_BITACORA = New System.Windows.Forms.ToolStripButton()
        Me.cmdRECONSULTAR_BITACORA = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator23 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdSALIR_RESOCONS = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.dgvRESOCONS = New System.Windows.Forms.DataGridView()
        Me.txtRECOFERE_2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRECOFEIN_2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRECOFERE_1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRECOFEIN_1 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRECOREFI = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRECOREAC = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lsvMovimientosPorUsuarioRectificaciones = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BindingSource_RESOCONS_1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtRECOOBSE = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.BindingNavigator_RESOCONS_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator_RESOCONS_1.SuspendLayout()
        CType(Me.dgvRESOCONS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource_RESOCONS_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 709)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(1039, 25)
        Me.strBARRESTA.TabIndex = 355
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
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.cmdAceptar)
        Me.GroupBox4.Controls.Add(Me.cmdFinalizar)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(15, 351)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1012, 43)
        Me.GroupBox4.TabIndex = 356
        Me.GroupBox4.TabStop = False
        '
        'cmdAceptar
        '
        Me.cmdAceptar.AccessibleDescription = "Aceptar"
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Enabled = False
        Me.cmdAceptar.Image = Global.SICAFI.My.Resources.Resources._22
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(508, 14)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(120, 23)
        Me.cmdAceptar.TabIndex = 23
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdFinalizar
        '
        Me.cmdFinalizar.AccessibleDescription = "Finalizar"
        Me.cmdFinalizar.AccessibleName = ""
        Me.cmdFinalizar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFinalizar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFinalizar.Image = Global.SICAFI.My.Resources.Resources._125
        Me.cmdFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdFinalizar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdFinalizar.Location = New System.Drawing.Point(382, 14)
        Me.cmdFinalizar.Name = "cmdFinalizar"
        Me.cmdFinalizar.Size = New System.Drawing.Size(120, 23)
        Me.cmdFinalizar.TabIndex = 22
        Me.cmdFinalizar.Text = "Finalizar"
        Me.cmdFinalizar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BindingNavigator_RESOCONS_1)
        Me.GroupBox1.Controls.Add(Me.dgvRESOCONS)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1012, 333)
        Me.GroupBox1.TabIndex = 357
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "RESOLUCIONES PENDIENTES POR LIQUIDACIÓN"
        '
        'BindingNavigator_RESOCONS_1
        '
        Me.BindingNavigator_RESOCONS_1.AddNewItem = Nothing
        Me.BindingNavigator_RESOCONS_1.CountItem = Me.ToolStripLabel1
        Me.BindingNavigator_RESOCONS_1.DeleteItem = Nothing
        Me.BindingNavigator_RESOCONS_1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator19, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator20, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator21, Me.cmdCONSULTAR_BITACORA, Me.cmdRECONSULTAR_BITACORA, Me.ToolStripSeparator23, Me.cmdSALIR_RESOCONS, Me.ToolStripSeparator5})
        Me.BindingNavigator_RESOCONS_1.Location = New System.Drawing.Point(3, 16)
        Me.BindingNavigator_RESOCONS_1.MoveFirstItem = Me.ToolStripButton1
        Me.BindingNavigator_RESOCONS_1.MoveLastItem = Me.ToolStripButton4
        Me.BindingNavigator_RESOCONS_1.MoveNextItem = Me.ToolStripButton3
        Me.BindingNavigator_RESOCONS_1.MovePreviousItem = Me.ToolStripButton2
        Me.BindingNavigator_RESOCONS_1.Name = "BindingNavigator_RESOCONS_1"
        Me.BindingNavigator_RESOCONS_1.PositionItem = Me.ToolStripTextBox1
        Me.BindingNavigator_RESOCONS_1.Size = New System.Drawing.Size(1006, 25)
        Me.BindingNavigator_RESOCONS_1.TabIndex = 339
        Me.BindingNavigator_RESOCONS_1.Text = "BindingNavigator1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel1.Text = "de {0}"
        Me.ToolStripLabel1.ToolTipText = "Número total de elementos"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Mover primero"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Mover anterior"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.AccessibleName = "Posición"
        Me.ToolStripTextBox1.AutoSize = False
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox1.Text = "0"
        Me.ToolStripTextBox1.ToolTipText = "Posición actual"
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Mover siguiente"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Mover último"
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(6, 25)
        '
        'cmdCONSULTAR_BITACORA
        '
        Me.cmdCONSULTAR_BITACORA.AccessibleDescription = "Consultar"
        Me.cmdCONSULTAR_BITACORA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdCONSULTAR_BITACORA.Image = Global.SICAFI.My.Resources.Resources._045
        Me.cmdCONSULTAR_BITACORA.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdCONSULTAR_BITACORA.Name = "cmdCONSULTAR_BITACORA"
        Me.cmdCONSULTAR_BITACORA.Size = New System.Drawing.Size(23, 22)
        Me.cmdCONSULTAR_BITACORA.ToolTipText = "Consultar (F7)"
        '
        'cmdRECONSULTAR_BITACORA
        '
        Me.cmdRECONSULTAR_BITACORA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdRECONSULTAR_BITACORA.Image = Global.SICAFI.My.Resources.Resources._096
        Me.cmdRECONSULTAR_BITACORA.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdRECONSULTAR_BITACORA.Name = "cmdRECONSULTAR_BITACORA"
        Me.cmdRECONSULTAR_BITACORA.Size = New System.Drawing.Size(23, 22)
        Me.cmdRECONSULTAR_BITACORA.ToolTipText = "Reconsultar"
        '
        'ToolStripSeparator23
        '
        Me.ToolStripSeparator23.Name = "ToolStripSeparator23"
        Me.ToolStripSeparator23.Size = New System.Drawing.Size(6, 25)
        '
        'cmdSALIR_RESOCONS
        '
        Me.cmdSALIR_RESOCONS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdSALIR_RESOCONS.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR_RESOCONS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSALIR_RESOCONS.Name = "cmdSALIR_RESOCONS"
        Me.cmdSALIR_RESOCONS.Size = New System.Drawing.Size(23, 22)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'dgvRESOCONS
        '
        Me.dgvRESOCONS.AccessibleDescription = "Resoluciones de conservación"
        Me.dgvRESOCONS.AllowUserToAddRows = False
        Me.dgvRESOCONS.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvRESOCONS.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvRESOCONS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRESOCONS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRESOCONS.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvRESOCONS.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvRESOCONS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvRESOCONS.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRESOCONS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvRESOCONS.ColumnHeadersHeight = 40
        Me.dgvRESOCONS.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRESOCONS.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvRESOCONS.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvRESOCONS.Location = New System.Drawing.Point(17, 54)
        Me.dgvRESOCONS.Name = "dgvRESOCONS"
        Me.dgvRESOCONS.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRESOCONS.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvRESOCONS.RowHeadersVisible = False
        Me.dgvRESOCONS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRESOCONS.ShowCellToolTips = False
        Me.dgvRESOCONS.Size = New System.Drawing.Size(978, 261)
        Me.dgvRESOCONS.StandardTab = True
        Me.dgvRESOCONS.TabIndex = 328
        '
        'txtRECOFERE_2
        '
        Me.txtRECOFERE_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtRECOFERE_2.BackColor = System.Drawing.Color.White
        Me.txtRECOFERE_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRECOFERE_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECOFERE_2.ForeColor = System.Drawing.Color.Black
        Me.txtRECOFERE_2.Location = New System.Drawing.Point(399, 42)
        Me.txtRECOFERE_2.Name = "txtRECOFERE_2"
        Me.txtRECOFERE_2.Size = New System.Drawing.Size(103, 20)
        Me.txtRECOFERE_2.TabIndex = 404
        Me.txtRECOFERE_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(16, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(379, 20)
        Me.Label5.TabIndex = 403
        Me.Label5.Text = "Nro. de días hábiles por fecha de resolución"
        '
        'txtRECOFEIN_2
        '
        Me.txtRECOFEIN_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtRECOFEIN_2.BackColor = System.Drawing.Color.White
        Me.txtRECOFEIN_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRECOFEIN_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECOFEIN_2.ForeColor = System.Drawing.Color.Black
        Me.txtRECOFEIN_2.Location = New System.Drawing.Point(399, 65)
        Me.txtRECOFEIN_2.Name = "txtRECOFEIN_2"
        Me.txtRECOFEIN_2.Size = New System.Drawing.Size(103, 20)
        Me.txtRECOFEIN_2.TabIndex = 402
        Me.txtRECOFEIN_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(16, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(379, 20)
        Me.Label8.TabIndex = 401
        Me.Label8.Text = "Nro. de días hábiles por fecha de ingreso"
        '
        'txtRECOFERE_1
        '
        Me.txtRECOFERE_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtRECOFERE_1.BackColor = System.Drawing.Color.White
        Me.txtRECOFERE_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRECOFERE_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECOFERE_1.ForeColor = System.Drawing.Color.Black
        Me.txtRECOFERE_1.Location = New System.Drawing.Point(887, 43)
        Me.txtRECOFERE_1.Name = "txtRECOFERE_1"
        Me.txtRECOFERE_1.Size = New System.Drawing.Size(103, 20)
        Me.txtRECOFERE_1.TabIndex = 400
        Me.txtRECOFERE_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(508, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(375, 20)
        Me.Label7.TabIndex = 399
        Me.Label7.Text = "Nro. de días calendario por fecha de resolución"
        '
        'txtRECOFEIN_1
        '
        Me.txtRECOFEIN_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtRECOFEIN_1.BackColor = System.Drawing.Color.White
        Me.txtRECOFEIN_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRECOFEIN_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECOFEIN_1.ForeColor = System.Drawing.Color.Black
        Me.txtRECOFEIN_1.Location = New System.Drawing.Point(887, 66)
        Me.txtRECOFEIN_1.Name = "txtRECOFEIN_1"
        Me.txtRECOFEIN_1.Size = New System.Drawing.Size(103, 20)
        Me.txtRECOFEIN_1.TabIndex = 398
        Me.txtRECOFEIN_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(508, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(375, 20)
        Me.Label1.TabIndex = 397
        Me.Label1.Text = "Nro. de días calendario por fecha de ingreso"
        '
        'txtRECOREFI
        '
        Me.txtRECOREFI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtRECOREFI.BackColor = System.Drawing.Color.White
        Me.txtRECOREFI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRECOREFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECOREFI.ForeColor = System.Drawing.Color.Black
        Me.txtRECOREFI.Location = New System.Drawing.Point(887, 19)
        Me.txtRECOREFI.Name = "txtRECOREFI"
        Me.txtRECOREFI.Size = New System.Drawing.Size(103, 20)
        Me.txtRECOREFI.TabIndex = 392
        Me.txtRECOREFI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(508, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(375, 20)
        Me.Label3.TabIndex = 391
        Me.Label3.Text = "Resoluciones finalizadas"
        '
        'txtRECOREAC
        '
        Me.txtRECOREAC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtRECOREAC.BackColor = System.Drawing.Color.White
        Me.txtRECOREAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRECOREAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECOREAC.ForeColor = System.Drawing.Color.Black
        Me.txtRECOREAC.Location = New System.Drawing.Point(399, 19)
        Me.txtRECOREAC.Name = "txtRECOREAC"
        Me.txtRECOREAC.Size = New System.Drawing.Size(103, 20)
        Me.txtRECOREAC.TabIndex = 390
        Me.txtRECOREAC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(379, 20)
        Me.Label4.TabIndex = 386
        Me.Label4.Text = "Resoluciones activas"
        '
        'lsvMovimientosPorUsuarioRectificaciones
        '
        Me.lsvMovimientosPorUsuarioRectificaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lsvMovimientosPorUsuarioRectificaciones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader4})
        Me.lsvMovimientosPorUsuarioRectificaciones.FullRowSelect = True
        Me.lsvMovimientosPorUsuarioRectificaciones.GridLines = True
        Me.lsvMovimientosPorUsuarioRectificaciones.Location = New System.Drawing.Point(16, -62)
        Me.lsvMovimientosPorUsuarioRectificaciones.Name = "lsvMovimientosPorUsuarioRectificaciones"
        Me.lsvMovimientosPorUsuarioRectificaciones.Size = New System.Drawing.Size(323, 75)
        Me.lsvMovimientosPorUsuarioRectificaciones.TabIndex = 402
        Me.lsvMovimientosPorUsuarioRectificaciones.UseCompatibleStateImageBehavior = False
        Me.lsvMovimientosPorUsuarioRectificaciones.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Usuario"
        Me.ColumnHeader5.Width = 200
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Finalizados"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 100
        '
        'txtRECOOBSE
        '
        Me.txtRECOOBSE.AccessibleDescription = "Observaciones"
        Me.txtRECOOBSE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRECOOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECOOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECOOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECOOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtRECOOBSE.Location = New System.Drawing.Point(14, 20)
        Me.txtRECOOBSE.MaxLength = 1000
        Me.txtRECOOBSE.Multiline = True
        Me.txtRECOOBSE.Name = "txtRECOOBSE"
        Me.txtRECOOBSE.ReadOnly = True
        Me.txtRECOOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRECOOBSE.Size = New System.Drawing.Size(976, 151)
        Me.txtRECOOBSE.TabIndex = 189
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.txtRECOFEIN_1)
        Me.GroupBox2.Controls.Add(Me.txtRECOFERE_2)
        Me.GroupBox2.Controls.Add(Me.txtRECOFERE_1)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtRECOREFI)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtRECOREAC)
        Me.GroupBox2.Controls.Add(Me.txtRECOFEIN_2)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(15, 400)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1012, 101)
        Me.GroupBox2.TabIndex = 373
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Información"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lsvMovimientosPorUsuarioRectificaciones)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(1159, 656)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(10, 10)
        Me.GroupBox3.TabIndex = 374
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Resoluciones por usuario"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.txtRECOOBSE)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(15, 507)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1012, 183)
        Me.GroupBox5.TabIndex = 375
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Observaciones"
        '
        'frm_bitacora_pendientes_liquidar_RESOCONS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 734)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.strBARRESTA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1055, 770)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1055, 736)
        Me.Name = "frm_bitacora_pendientes_liquidar_RESOCONS"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RESOLUCIONES PENDIENTES POR LIQUIDACIÓN"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.BindingNavigator_RESOCONS_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator_RESOCONS_1.ResumeLayout(False)
        Me.BindingNavigator_RESOCONS_1.PerformLayout()
        CType(Me.dgvRESOCONS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource_RESOCONS_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdFinalizar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRECOFERE_2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRECOFEIN_2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRECOFERE_1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRECOFEIN_1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRECOREFI As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRECOREAC As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lsvMovimientosPorUsuarioRectificaciones As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents dgvRESOCONS As System.Windows.Forms.DataGridView
    Friend WithEvents BindingNavigator_RESOCONS_1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator20 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdRECONSULTAR_BITACORA As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator23 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdSALIR_RESOCONS As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingSource_RESOCONS_1 As System.Windows.Forms.BindingSource
    Friend WithEvents txtRECOOBSE As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCONSULTAR_BITACORA As System.Windows.Forms.ToolStripButton
End Class
