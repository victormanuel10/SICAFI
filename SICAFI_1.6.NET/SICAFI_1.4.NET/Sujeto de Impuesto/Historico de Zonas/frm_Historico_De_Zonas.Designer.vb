<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Historico_De_Zonas
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CORR = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblZOECVIG0 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblZOECZON0 = New System.Windows.Forms.Label()
        Me.dgvZOECFIP0 = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblZOECVIG2 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblZOECZON2 = New System.Windows.Forms.Label()
        Me.dgvZOECFIP2 = New System.Windows.Forms.DataGridView()
        Me.BindingSource_ZONAS_1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblZOFIVIG0 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblZOFIZON0 = New System.Windows.Forms.Label()
        Me.dgvZOFIFIP0 = New System.Windows.Forms.DataGridView()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblZOFIVIG2 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblZOFIZON2 = New System.Windows.Forms.Label()
        Me.dgvZOFIFIP2 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.CORR.SuspendLayout()
        CType(Me.dgvZOECFIP0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvZOECFIP2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource_ZONAS_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvZOFIFIP0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgvZOFIFIP2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdSalir)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 403)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1021, 60)
        Me.GroupBox1.TabIndex = 65
        Me.GroupBox1.TabStop = False
        '
        'cmdSalir
        '
        Me.cmdSalir.AccessibleDescription = "Salir"
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(899, 20)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(101, 23)
        Me.cmdSalir.TabIndex = 8
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 479)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(1040, 25)
        Me.strBARRESTA.TabIndex = 66
        '
        'tstBAESVALI
        '
        Me.tstBAESVALI.AutoSize = False
        Me.tstBAESVALI.BackColor = System.Drawing.Color.White
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
        Me.tstBAESDESC.BackColor = System.Drawing.Color.White
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
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.White
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
        'CORR
        '
        Me.CORR.BackColor = System.Drawing.SystemColors.Control
        Me.CORR.Controls.Add(Me.Label3)
        Me.CORR.Controls.Add(Me.lblZOECVIG0)
        Me.CORR.Controls.Add(Me.Label1)
        Me.CORR.Controls.Add(Me.lblZOECZON0)
        Me.CORR.Controls.Add(Me.dgvZOECFIP0)
        Me.CORR.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CORR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CORR.Location = New System.Drawing.Point(5, 6)
        Me.CORR.Name = "CORR"
        Me.CORR.Size = New System.Drawing.Size(497, 346)
        Me.CORR.TabIndex = 64
        Me.CORR.TabStop = False
        Me.CORR.Text = "FICHA PREDIAL"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 289)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 20)
        Me.Label3.TabIndex = 369
        Me.Label3.Text = "Vigencia"
        '
        'lblZOECVIG0
        '
        Me.lblZOECVIG0.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblZOECVIG0.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZOECVIG0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZOECVIG0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZOECVIG0.ForeColor = System.Drawing.Color.Black
        Me.lblZOECVIG0.Location = New System.Drawing.Point(112, 289)
        Me.lblZOECVIG0.Name = "lblZOECVIG0"
        Me.lblZOECVIG0.Size = New System.Drawing.Size(364, 20)
        Me.lblZOECVIG0.TabIndex = 368
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 312)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 20)
        Me.Label1.TabIndex = 367
        Me.Label1.Text = "Zona"
        '
        'lblZOECZON0
        '
        Me.lblZOECZON0.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblZOECZON0.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZOECZON0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZOECZON0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZOECZON0.ForeColor = System.Drawing.Color.Black
        Me.lblZOECZON0.Location = New System.Drawing.Point(112, 312)
        Me.lblZOECZON0.Name = "lblZOECZON0"
        Me.lblZOECZON0.Size = New System.Drawing.Size(364, 20)
        Me.lblZOECZON0.TabIndex = 365
        '
        'dgvZOECFIP0
        '
        Me.dgvZOECFIP0.AccessibleDescription = "Zonas ficha predial"
        Me.dgvZOECFIP0.AllowUserToAddRows = False
        Me.dgvZOECFIP0.AllowUserToDeleteRows = False
        Me.dgvZOECFIP0.AllowUserToResizeRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvZOECFIP0.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvZOECFIP0.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvZOECFIP0.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvZOECFIP0.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvZOECFIP0.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvZOECFIP0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvZOECFIP0.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvZOECFIP0.ColumnHeadersHeight = 40
        Me.dgvZOECFIP0.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvZOECFIP0.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvZOECFIP0.Location = New System.Drawing.Point(19, 29)
        Me.dgvZOECFIP0.MultiSelect = False
        Me.dgvZOECFIP0.Name = "dgvZOECFIP0"
        Me.dgvZOECFIP0.ReadOnly = True
        Me.dgvZOECFIP0.RowHeadersVisible = False
        Me.dgvZOECFIP0.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvZOECFIP0.ShowCellToolTips = False
        Me.dgvZOECFIP0.Size = New System.Drawing.Size(457, 246)
        Me.dgvZOECFIP0.StandardTab = True
        Me.dgvZOECFIP0.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.lblZOECVIG2)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblZOECZON2)
        Me.GroupBox2.Controls.Add(Me.dgvZOECFIP2)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(508, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(494, 346)
        Me.GroupBox2.TabIndex = 67
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "FICHA RESUMEN"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(19, 289)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 20)
        Me.Label6.TabIndex = 371
        Me.Label6.Text = "Vigencia"
        '
        'lblZOECVIG2
        '
        Me.lblZOECVIG2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblZOECVIG2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZOECVIG2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZOECVIG2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZOECVIG2.ForeColor = System.Drawing.Color.Black
        Me.lblZOECVIG2.Location = New System.Drawing.Point(112, 289)
        Me.lblZOECVIG2.Name = "lblZOECVIG2"
        Me.lblZOECVIG2.Size = New System.Drawing.Size(364, 20)
        Me.lblZOECVIG2.TabIndex = 370
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 312)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 20)
        Me.Label2.TabIndex = 369
        Me.Label2.Text = "Zona"
        '
        'lblZOECZON2
        '
        Me.lblZOECZON2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblZOECZON2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZOECZON2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZOECZON2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZOECZON2.ForeColor = System.Drawing.Color.Black
        Me.lblZOECZON2.Location = New System.Drawing.Point(112, 312)
        Me.lblZOECZON2.Name = "lblZOECZON2"
        Me.lblZOECZON2.Size = New System.Drawing.Size(364, 20)
        Me.lblZOECZON2.TabIndex = 368
        '
        'dgvZOECFIP2
        '
        Me.dgvZOECFIP2.AccessibleDescription = "Zonas ficha resumen 2"
        Me.dgvZOECFIP2.AllowUserToAddRows = False
        Me.dgvZOECFIP2.AllowUserToDeleteRows = False
        Me.dgvZOECFIP2.AllowUserToResizeRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvZOECFIP2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvZOECFIP2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvZOECFIP2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvZOECFIP2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvZOECFIP2.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvZOECFIP2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvZOECFIP2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvZOECFIP2.ColumnHeadersHeight = 40
        Me.dgvZOECFIP2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvZOECFIP2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvZOECFIP2.Location = New System.Drawing.Point(19, 29)
        Me.dgvZOECFIP2.MultiSelect = False
        Me.dgvZOECFIP2.Name = "dgvZOECFIP2"
        Me.dgvZOECFIP2.ReadOnly = True
        Me.dgvZOECFIP2.RowHeadersVisible = False
        Me.dgvZOECFIP2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvZOECFIP2.ShowCellToolTips = False
        Me.dgvZOECFIP2.Size = New System.Drawing.Size(454, 246)
        Me.dgvZOECFIP2.StandardTab = True
        Me.dgvZOECFIP2.TabIndex = 4
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(13, 13)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1016, 384)
        Me.TabControl1.TabIndex = 69
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.CORR)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1008, 358)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Zona Económica"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.GroupBox6)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1008, 358)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Zona Física"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.lblZOFIVIG0)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.lblZOFIZON0)
        Me.GroupBox4.Controls.Add(Me.dgvZOFIFIP0)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox4.Location = New System.Drawing.Point(5, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(497, 346)
        Me.GroupBox4.TabIndex = 69
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "FICHA PREDIAL"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 289)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 20)
        Me.Label5.TabIndex = 369
        Me.Label5.Text = "Vigencia"
        '
        'lblZOFIVIG0
        '
        Me.lblZOFIVIG0.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblZOFIVIG0.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZOFIVIG0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZOFIVIG0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZOFIVIG0.ForeColor = System.Drawing.Color.Black
        Me.lblZOFIVIG0.Location = New System.Drawing.Point(112, 289)
        Me.lblZOFIVIG0.Name = "lblZOFIVIG0"
        Me.lblZOFIVIG0.Size = New System.Drawing.Size(364, 20)
        Me.lblZOFIVIG0.TabIndex = 368
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(19, 312)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 20)
        Me.Label9.TabIndex = 367
        Me.Label9.Text = "Zona"
        '
        'lblZOFIZON0
        '
        Me.lblZOFIZON0.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblZOFIZON0.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZOFIZON0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZOFIZON0.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZOFIZON0.ForeColor = System.Drawing.Color.Black
        Me.lblZOFIZON0.Location = New System.Drawing.Point(112, 312)
        Me.lblZOFIZON0.Name = "lblZOFIZON0"
        Me.lblZOFIZON0.Size = New System.Drawing.Size(364, 20)
        Me.lblZOFIZON0.TabIndex = 365
        '
        'dgvZOFIFIP0
        '
        Me.dgvZOFIFIP0.AccessibleDescription = "Zonas ficha predial"
        Me.dgvZOFIFIP0.AllowUserToAddRows = False
        Me.dgvZOFIFIP0.AllowUserToDeleteRows = False
        Me.dgvZOFIFIP0.AllowUserToResizeRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvZOFIFIP0.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvZOFIFIP0.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvZOFIFIP0.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvZOFIFIP0.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvZOFIFIP0.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvZOFIFIP0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvZOFIFIP0.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvZOFIFIP0.ColumnHeadersHeight = 40
        Me.dgvZOFIFIP0.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvZOFIFIP0.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvZOFIFIP0.Location = New System.Drawing.Point(19, 29)
        Me.dgvZOFIFIP0.MultiSelect = False
        Me.dgvZOFIFIP0.Name = "dgvZOFIFIP0"
        Me.dgvZOFIFIP0.ReadOnly = True
        Me.dgvZOFIFIP0.RowHeadersVisible = False
        Me.dgvZOFIFIP0.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvZOFIFIP0.ShowCellToolTips = False
        Me.dgvZOFIFIP0.Size = New System.Drawing.Size(457, 246)
        Me.dgvZOFIFIP0.StandardTab = True
        Me.dgvZOFIFIP0.TabIndex = 4
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Controls.Add(Me.lblZOFIVIG2)
        Me.GroupBox6.Controls.Add(Me.Label17)
        Me.GroupBox6.Controls.Add(Me.lblZOFIZON2)
        Me.GroupBox6.Controls.Add(Me.dgvZOFIFIP2)
        Me.GroupBox6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox6.Location = New System.Drawing.Point(508, 6)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(494, 346)
        Me.GroupBox6.TabIndex = 70
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "FICHA RESUMEN"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(19, 289)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(90, 20)
        Me.Label15.TabIndex = 371
        Me.Label15.Text = "Vigencia"
        '
        'lblZOFIVIG2
        '
        Me.lblZOFIVIG2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblZOFIVIG2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZOFIVIG2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZOFIVIG2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZOFIVIG2.ForeColor = System.Drawing.Color.Black
        Me.lblZOFIVIG2.Location = New System.Drawing.Point(112, 289)
        Me.lblZOFIVIG2.Name = "lblZOFIVIG2"
        Me.lblZOFIVIG2.Size = New System.Drawing.Size(364, 20)
        Me.lblZOFIVIG2.TabIndex = 370
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(19, 312)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 20)
        Me.Label17.TabIndex = 369
        Me.Label17.Text = "Zona"
        '
        'lblZOFIZON2
        '
        Me.lblZOFIZON2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblZOFIZON2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZOFIZON2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZOFIZON2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZOFIZON2.ForeColor = System.Drawing.Color.Black
        Me.lblZOFIZON2.Location = New System.Drawing.Point(112, 312)
        Me.lblZOFIZON2.Name = "lblZOFIZON2"
        Me.lblZOFIZON2.Size = New System.Drawing.Size(364, 20)
        Me.lblZOFIZON2.TabIndex = 368
        '
        'dgvZOFIFIP2
        '
        Me.dgvZOFIFIP2.AccessibleDescription = "Zonas ficha resumen 2"
        Me.dgvZOFIFIP2.AllowUserToAddRows = False
        Me.dgvZOFIFIP2.AllowUserToDeleteRows = False
        Me.dgvZOFIFIP2.AllowUserToResizeRows = False
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvZOFIFIP2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvZOFIFIP2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvZOFIFIP2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvZOFIFIP2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvZOFIFIP2.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvZOFIFIP2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvZOFIFIP2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvZOFIFIP2.ColumnHeadersHeight = 40
        Me.dgvZOFIFIP2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvZOFIFIP2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvZOFIFIP2.Location = New System.Drawing.Point(19, 29)
        Me.dgvZOFIFIP2.MultiSelect = False
        Me.dgvZOFIFIP2.Name = "dgvZOFIFIP2"
        Me.dgvZOFIFIP2.ReadOnly = True
        Me.dgvZOFIFIP2.RowHeadersVisible = False
        Me.dgvZOFIFIP2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvZOFIFIP2.ShowCellToolTips = False
        Me.dgvZOFIFIP2.Size = New System.Drawing.Size(454, 246)
        Me.dgvZOFIFIP2.StandardTab = True
        Me.dgvZOFIFIP2.TabIndex = 4
        '
        'frm_Historico_De_Zonas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1040, 504)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1056, 540)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1056, 540)
        Me.Name = "frm_Historico_De_Zonas"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HISTORICO DE ZONAS"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.CORR.ResumeLayout(False)
        CType(Me.dgvZOECFIP0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvZOECFIP2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource_ZONAS_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvZOFIFIP0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dgvZOFIFIP2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CORR As System.Windows.Forms.GroupBox
    Friend WithEvents dgvZOECFIP0 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvZOECFIP2 As System.Windows.Forms.DataGridView
    Friend WithEvents BindingSource_ZONAS_1 As System.Windows.Forms.BindingSource
    Friend WithEvents lblZOECZON0 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblZOECZON2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblZOECVIG0 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblZOECVIG2 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblZOFIVIG0 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblZOFIZON0 As System.Windows.Forms.Label
    Friend WithEvents dgvZOFIFIP0 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblZOFIVIG2 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblZOFIZON2 As System.Windows.Forms.Label
    Friend WithEvents dgvZOFIFIP2 As System.Windows.Forms.DataGridView
End Class
