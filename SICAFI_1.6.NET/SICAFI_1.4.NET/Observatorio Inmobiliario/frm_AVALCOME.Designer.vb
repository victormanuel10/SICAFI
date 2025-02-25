<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_AVALCOME
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvCONSULTA = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdReconsultar = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdGenerar = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.nudAVCOVM2CA = New System.Windows.Forms.NumericUpDown()
        Me.nudAVCOVCCA = New System.Windows.Forms.NumericUpDown()
        Me.nudAVCOVTCA = New System.Windows.Forms.NumericUpDown()
        Me.txtAVCOVCCA = New System.Windows.Forms.Label()
        Me.txtAVCOVTCA = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAVCOVM2CA = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.nudAVCOVCCO = New System.Windows.Forms.NumericUpDown()
        Me.nudAVCOVTCO = New System.Windows.Forms.NumericUpDown()
        Me.txtAVCOVCCO = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAVCOCOVA = New System.Windows.Forms.Label()
        Me.txtAVCOVTCO = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAVCOVM2CO = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAVCODEES = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAVCOMEDI = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblAviso = New System.Windows.Forms.Label()
        Me.cmdExportarExcel = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.nudAVCOVM2CA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAVCOVCCA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAVCOVTCA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAVCOVCCO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAVCOVTCO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgvCONSULTA)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1066, 413)
        Me.GroupBox2.TabIndex = 370
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CONSULTA"
        '
        'dgvCONSULTA
        '
        Me.dgvCONSULTA.AccessibleDescription = ""
        Me.dgvCONSULTA.AllowUserToAddRows = False
        Me.dgvCONSULTA.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCONSULTA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCONSULTA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCONSULTA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCONSULTA.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCONSULTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCONSULTA.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCONSULTA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvCONSULTA.ColumnHeadersHeight = 40
        Me.dgvCONSULTA.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCONSULTA.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvCONSULTA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA.Location = New System.Drawing.Point(17, 19)
        Me.dgvCONSULTA.MultiSelect = False
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCONSULTA.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(1032, 379)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 368
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdExportarExcel)
        Me.GroupBox1.Controls.Add(Me.cmdReconsultar)
        Me.GroupBox1.Controls.Add(Me.cmdSalir)
        Me.GroupBox1.Controls.Add(Me.cmdGenerar)
        Me.GroupBox1.Location = New System.Drawing.Point(339, 538)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(739, 60)
        Me.GroupBox1.TabIndex = 372
        Me.GroupBox1.TabStop = False
        '
        'cmdReconsultar
        '
        Me.cmdReconsultar.AccessibleDescription = "Reconsultar"
        Me.cmdReconsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdReconsultar.Image = Global.SICAFI.My.Resources.Resources._667
        Me.cmdReconsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdReconsultar.Location = New System.Drawing.Point(143, 20)
        Me.cmdReconsultar.Name = "cmdReconsultar"
        Me.cmdReconsultar.Size = New System.Drawing.Size(123, 23)
        Me.cmdReconsultar.TabIndex = 5
        Me.cmdReconsultar.Text = "&Reconsultar"
        Me.cmdReconsultar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.AccessibleDescription = "Salir"
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(599, 20)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(123, 23)
        Me.cmdSalir.TabIndex = 4
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdGenerar
        '
        Me.cmdGenerar.AccessibleDescription = "Generar"
        Me.cmdGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdGenerar.Image = Global.SICAFI.My.Resources.Resources._187
        Me.cmdGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGenerar.Location = New System.Drawing.Point(14, 20)
        Me.cmdGenerar.Name = "cmdGenerar"
        Me.cmdGenerar.Size = New System.Drawing.Size(123, 23)
        Me.cmdGenerar.TabIndex = 3
        Me.cmdGenerar.Text = "&Liquidar"
        Me.cmdGenerar.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 614)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(1090, 25)
        Me.strBARRESTA.TabIndex = 371
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
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.nudAVCOVM2CA)
        Me.GroupBox3.Controls.Add(Me.nudAVCOVCCA)
        Me.GroupBox3.Controls.Add(Me.nudAVCOVTCA)
        Me.GroupBox3.Controls.Add(Me.txtAVCOVCCA)
        Me.GroupBox3.Controls.Add(Me.txtAVCOVTCA)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtAVCOVM2CA)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.nudAVCOVCCO)
        Me.GroupBox3.Controls.Add(Me.nudAVCOVTCO)
        Me.GroupBox3.Controls.Add(Me.txtAVCOVCCO)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtAVCOCOVA)
        Me.GroupBox3.Controls.Add(Me.txtAVCOVTCO)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtAVCOVM2CO)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtAVCODEES)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtAVCOMEDI)
        Me.GroupBox3.Controls.Add(Me.Label38)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 431)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1066, 101)
        Me.GroupBox3.TabIndex = 373
        Me.GroupBox3.TabStop = False
        '
        'nudAVCOVM2CA
        '
        Me.nudAVCOVM2CA.Location = New System.Drawing.Point(865, 23)
        Me.nudAVCOVM2CA.Name = "nudAVCOVM2CA"
        Me.nudAVCOVM2CA.Size = New System.Drawing.Size(53, 20)
        Me.nudAVCOVM2CA.TabIndex = 381
        Me.nudAVCOVM2CA.Value = New Decimal(New Integer() {70, 0, 0, 0})
        '
        'nudAVCOVCCA
        '
        Me.nudAVCOVCCA.Location = New System.Drawing.Point(865, 68)
        Me.nudAVCOVCCA.Name = "nudAVCOVCCA"
        Me.nudAVCOVCCA.Size = New System.Drawing.Size(53, 20)
        Me.nudAVCOVCCA.TabIndex = 374
        Me.nudAVCOVCCA.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'nudAVCOVTCA
        '
        Me.nudAVCOVTCA.Location = New System.Drawing.Point(865, 46)
        Me.nudAVCOVTCA.Name = "nudAVCOVTCA"
        Me.nudAVCOVTCA.Size = New System.Drawing.Size(53, 20)
        Me.nudAVCOVTCA.TabIndex = 373
        Me.nudAVCOVTCA.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'txtAVCOVCCA
        '
        Me.txtAVCOVCCA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAVCOVCCA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtAVCOVCCA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtAVCOVCCA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAVCOVCCA.ForeColor = System.Drawing.Color.Black
        Me.txtAVCOVCCA.Location = New System.Drawing.Point(921, 69)
        Me.txtAVCOVCCA.Name = "txtAVCOVCCA"
        Me.txtAVCOVCCA.Size = New System.Drawing.Size(124, 20)
        Me.txtAVCOVCCA.TabIndex = 380
        '
        'txtAVCOVTCA
        '
        Me.txtAVCOVTCA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAVCOVTCA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtAVCOVTCA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtAVCOVTCA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAVCOVTCA.ForeColor = System.Drawing.Color.Black
        Me.txtAVCOVTCA.Location = New System.Drawing.Point(921, 46)
        Me.txtAVCOVTCA.Name = "txtAVCOVTCA"
        Me.txtAVCOVTCA.Size = New System.Drawing.Size(124, 20)
        Me.txtAVCOVTCA.TabIndex = 379
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(688, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(174, 20)
        Me.Label8.TabIndex = 378
        Me.Label8.Text = "Valor construcción (%) $"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(688, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(174, 20)
        Me.Label9.TabIndex = 377
        Me.Label9.Text = "Valor terreno (%) $"
        '
        'txtAVCOVM2CA
        '
        Me.txtAVCOVM2CA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAVCOVM2CA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtAVCOVM2CA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtAVCOVM2CA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAVCOVM2CA.ForeColor = System.Drawing.Color.Black
        Me.txtAVCOVM2CA.Location = New System.Drawing.Point(921, 23)
        Me.txtAVCOVM2CA.Name = "txtAVCOVM2CA"
        Me.txtAVCOVM2CA.Size = New System.Drawing.Size(124, 20)
        Me.txtAVCOVM2CA.TabIndex = 376
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(688, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(174, 20)
        Me.Label11.TabIndex = 375
        Me.Label11.Text = "Valor mts2 catastral (%) $"
        '
        'nudAVCOVCCO
        '
        Me.nudAVCOVCCO.Location = New System.Drawing.Point(504, 68)
        Me.nudAVCOVCCO.Name = "nudAVCOVCCO"
        Me.nudAVCOVCCO.Size = New System.Drawing.Size(53, 20)
        Me.nudAVCOVCCO.TabIndex = 7
        Me.nudAVCOVCCO.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'nudAVCOVTCO
        '
        Me.nudAVCOVTCO.AccessibleDescription = "% valor terreno"
        Me.nudAVCOVTCO.Location = New System.Drawing.Point(504, 46)
        Me.nudAVCOVTCO.Name = "nudAVCOVTCO"
        Me.nudAVCOVTCO.Size = New System.Drawing.Size(53, 20)
        Me.nudAVCOVTCO.TabIndex = 6
        Me.nudAVCOVTCO.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'txtAVCOVCCO
        '
        Me.txtAVCOVCCO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAVCOVCCO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtAVCOVCCO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtAVCOVCCO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAVCOVCCO.ForeColor = System.Drawing.Color.Black
        Me.txtAVCOVCCO.Location = New System.Drawing.Point(560, 69)
        Me.txtAVCOVCCO.Name = "txtAVCOVCCO"
        Me.txtAVCOVCCO.Size = New System.Drawing.Size(124, 20)
        Me.txtAVCOVCCO.TabIndex = 372
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(14, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(188, 20)
        Me.Label6.TabIndex = 365
        Me.Label6.Text = "Coeficiente de variación %"
        '
        'txtAVCOCOVA
        '
        Me.txtAVCOCOVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAVCOCOVA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtAVCOCOVA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtAVCOCOVA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAVCOCOVA.ForeColor = System.Drawing.Color.Black
        Me.txtAVCOCOVA.Location = New System.Drawing.Point(205, 69)
        Me.txtAVCOCOVA.Name = "txtAVCOCOVA"
        Me.txtAVCOCOVA.Size = New System.Drawing.Size(118, 20)
        Me.txtAVCOCOVA.TabIndex = 366
        '
        'txtAVCOVTCO
        '
        Me.txtAVCOVTCO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAVCOVTCO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtAVCOVTCO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtAVCOVTCO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAVCOVTCO.ForeColor = System.Drawing.Color.Black
        Me.txtAVCOVTCO.Location = New System.Drawing.Point(560, 46)
        Me.txtAVCOVTCO.Name = "txtAVCOVTCO"
        Me.txtAVCOVTCO.Size = New System.Drawing.Size(124, 20)
        Me.txtAVCOVTCO.TabIndex = 371
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(327, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(174, 20)
        Me.Label3.TabIndex = 370
        Me.Label3.Text = "Valor construcción (%) $"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(327, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 20)
        Me.Label1.TabIndex = 369
        Me.Label1.Text = "Valor terreno (%) $"
        '
        'txtAVCOVM2CO
        '
        Me.txtAVCOVM2CO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAVCOVM2CO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtAVCOVM2CO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtAVCOVM2CO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAVCOVM2CO.ForeColor = System.Drawing.Color.Black
        Me.txtAVCOVM2CO.Location = New System.Drawing.Point(560, 23)
        Me.txtAVCOVM2CO.Name = "txtAVCOVM2CO"
        Me.txtAVCOVM2CO.Size = New System.Drawing.Size(124, 20)
        Me.txtAVCOVM2CO.TabIndex = 368
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(327, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(230, 20)
        Me.Label4.TabIndex = 367
        Me.Label4.Text = "Valor mts2 comercial $"
        '
        'txtAVCODEES
        '
        Me.txtAVCODEES.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAVCODEES.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtAVCODEES.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtAVCODEES.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAVCODEES.ForeColor = System.Drawing.Color.Black
        Me.txtAVCODEES.Location = New System.Drawing.Point(205, 46)
        Me.txtAVCODEES.Name = "txtAVCODEES"
        Me.txtAVCODEES.Size = New System.Drawing.Size(118, 20)
        Me.txtAVCODEES.TabIndex = 364
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(14, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(188, 20)
        Me.Label2.TabIndex = 363
        Me.Label2.Text = "Desviación estandar"
        '
        'txtAVCOMEDI
        '
        Me.txtAVCOMEDI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAVCOMEDI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtAVCOMEDI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtAVCOMEDI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAVCOMEDI.ForeColor = System.Drawing.Color.Black
        Me.txtAVCOMEDI.Location = New System.Drawing.Point(205, 23)
        Me.txtAVCOMEDI.Name = "txtAVCOMEDI"
        Me.txtAVCOMEDI.Size = New System.Drawing.Size(118, 20)
        Me.txtAVCOMEDI.TabIndex = 362
        '
        'Label38
        '
        Me.Label38.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label38.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label38.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(14, 23)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(188, 20)
        Me.Label38.TabIndex = 361
        Me.Label38.Text = "Media "
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.lblAviso)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 538)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(321, 60)
        Me.GroupBox4.TabIndex = 374
        Me.GroupBox4.TabStop = False
        '
        'lblAviso
        '
        Me.lblAviso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAviso.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblAviso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAviso.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAviso.ForeColor = System.Drawing.Color.Black
        Me.lblAviso.Location = New System.Drawing.Point(16, 20)
        Me.lblAviso.Name = "lblAviso"
        Me.lblAviso.Size = New System.Drawing.Size(288, 25)
        Me.lblAviso.TabIndex = 367
        Me.lblAviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdExportarExcel
        '
        Me.cmdExportarExcel.AccessibleDescription = "Exportar Excel"
        Me.cmdExportarExcel.AccessibleName = ""
        Me.cmdExportarExcel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExportarExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExportarExcel.Image = Global.SICAFI.My.Resources.Resources._041
        Me.cmdExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdExportarExcel.Location = New System.Drawing.Point(272, 20)
        Me.cmdExportarExcel.Name = "cmdExportarExcel"
        Me.cmdExportarExcel.Size = New System.Drawing.Size(123, 23)
        Me.cmdExportarExcel.TabIndex = 23
        Me.cmdExportarExcel.Text = "&Exportar excel"
        Me.cmdExportarExcel.UseVisualStyleBackColor = False
        '
        'frm_AVALCOME
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1090, 639)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frm_AVALCOME"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AVALÚO COMERCIAL"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.nudAVCOVM2CA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAVCOVCCA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAVCOVTCA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAVCOVCCO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAVCOVTCO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents cmdGenerar As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAVCOVM2CO As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAVCOCOVA As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAVCODEES As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAVCOMEDI As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdReconsultar As System.Windows.Forms.Button
    Friend WithEvents lblAviso As System.Windows.Forms.Label
    Friend WithEvents txtAVCOVCCO As System.Windows.Forms.Label
    Friend WithEvents txtAVCOVTCO As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudAVCOVCCO As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudAVCOVTCO As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudAVCOVCCA As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudAVCOVTCA As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtAVCOVCCA As System.Windows.Forms.Label
    Friend WithEvents txtAVCOVTCA As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAVCOVM2CA As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents nudAVCOVM2CA As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmdExportarExcel As System.Windows.Forms.Button
End Class
