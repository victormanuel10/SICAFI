<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CONSULTA_SQL
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fraTERCERO = New System.Windows.Forms.GroupBox()
        Me.rbdInsertar = New System.Windows.Forms.RadioButton()
        Me.rbdEliminar = New System.Windows.Forms.RadioButton()
        Me.rbdActualizar = New System.Windows.Forms.RadioButton()
        Me.rbdConsultar = New System.Windows.Forms.RadioButton()
        Me.txtCODIGO = New System.Windows.Forms.TextBox()
        Me.txtSELECT = New System.Windows.Forms.Label()
        Me.cmdEjecutar = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.dgvCONSULTA = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdLimpiar = New System.Windows.Forms.Button()
        Me.cmdRestablecer = New System.Windows.Forms.Button()
        Me.cmdAbrirArchivo = New System.Windows.Forms.Button()
        Me.cmdExportarExcel = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cmdExportarPlano = New System.Windows.Forms.Button()
        Me.txtSEPARADOR = New System.Windows.Forms.TextBox()
        Me.fraTERCERO.SuspendLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraTERCERO
        '
        Me.fraTERCERO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraTERCERO.BackColor = System.Drawing.SystemColors.Control
        Me.fraTERCERO.Controls.Add(Me.rbdInsertar)
        Me.fraTERCERO.Controls.Add(Me.rbdEliminar)
        Me.fraTERCERO.Controls.Add(Me.rbdActualizar)
        Me.fraTERCERO.Controls.Add(Me.rbdConsultar)
        Me.fraTERCERO.Controls.Add(Me.txtCODIGO)
        Me.fraTERCERO.Controls.Add(Me.txtSELECT)
        Me.fraTERCERO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraTERCERO.ForeColor = System.Drawing.Color.Black
        Me.fraTERCERO.Location = New System.Drawing.Point(3, 3)
        Me.fraTERCERO.Name = "fraTERCERO"
        Me.fraTERCERO.Size = New System.Drawing.Size(1033, 188)
        Me.fraTERCERO.TabIndex = 1
        Me.fraTERCERO.TabStop = False
        Me.fraTERCERO.Text = "SECUENCIA LENGUAJE SQL Server"
        '
        'rbdInsertar
        '
        Me.rbdInsertar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rbdInsertar.AutoSize = True
        Me.rbdInsertar.Location = New System.Drawing.Point(116, 159)
        Me.rbdInsertar.Name = "rbdInsertar"
        Me.rbdInsertar.Size = New System.Drawing.Size(67, 19)
        Me.rbdInsertar.TabIndex = 106
        Me.rbdInsertar.Text = "Insertar"
        Me.rbdInsertar.UseVisualStyleBackColor = True
        '
        'rbdEliminar
        '
        Me.rbdEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rbdEliminar.AutoSize = True
        Me.rbdEliminar.Location = New System.Drawing.Point(301, 159)
        Me.rbdEliminar.Name = "rbdEliminar"
        Me.rbdEliminar.Size = New System.Drawing.Size(71, 19)
        Me.rbdEliminar.TabIndex = 105
        Me.rbdEliminar.Text = "Eliminar"
        Me.rbdEliminar.UseVisualStyleBackColor = True
        '
        'rbdActualizar
        '
        Me.rbdActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rbdActualizar.AutoSize = True
        Me.rbdActualizar.Location = New System.Drawing.Point(206, 159)
        Me.rbdActualizar.Name = "rbdActualizar"
        Me.rbdActualizar.Size = New System.Drawing.Size(77, 19)
        Me.rbdActualizar.TabIndex = 104
        Me.rbdActualizar.Text = "Actualizar"
        Me.rbdActualizar.UseVisualStyleBackColor = True
        '
        'rbdConsultar
        '
        Me.rbdConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rbdConsultar.AutoSize = True
        Me.rbdConsultar.Checked = True
        Me.rbdConsultar.Location = New System.Drawing.Point(16, 159)
        Me.rbdConsultar.Name = "rbdConsultar"
        Me.rbdConsultar.Size = New System.Drawing.Size(79, 19)
        Me.rbdConsultar.TabIndex = 103
        Me.rbdConsultar.TabStop = True
        Me.rbdConsultar.Text = "Consultar"
        Me.rbdConsultar.UseVisualStyleBackColor = True
        '
        'txtCODIGO
        '
        Me.txtCODIGO.AccessibleDescription = "Codigo"
        Me.txtCODIGO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCODIGO.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCODIGO.Location = New System.Drawing.Point(16, 53)
        Me.txtCODIGO.Multiline = True
        Me.txtCODIGO.Name = "txtCODIGO"
        Me.txtCODIGO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCODIGO.Size = New System.Drawing.Size(997, 93)
        Me.txtCODIGO.TabIndex = 1
        '
        'txtSELECT
        '
        Me.txtSELECT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSELECT.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtSELECT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtSELECT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSELECT.ForeColor = System.Drawing.Color.Black
        Me.txtSELECT.Location = New System.Drawing.Point(16, 26)
        Me.txtSELECT.Name = "txtSELECT"
        Me.txtSELECT.Size = New System.Drawing.Size(997, 20)
        Me.txtSELECT.TabIndex = 42
        Me.txtSELECT.Text = "Secuencia SQL"
        Me.txtSELECT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdEjecutar
        '
        Me.cmdEjecutar.AccessibleDescription = "Ejecutar"
        Me.cmdEjecutar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdEjecutar.Image = Global.SICAFI.My.Resources.Resources._25
        Me.cmdEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEjecutar.Location = New System.Drawing.Point(16, 17)
        Me.cmdEjecutar.Name = "cmdEjecutar"
        Me.cmdEjecutar.Size = New System.Drawing.Size(123, 23)
        Me.cmdEjecutar.TabIndex = 2
        Me.cmdEjecutar.Text = "&Ejecutar"
        Me.cmdEjecutar.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(890, 17)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(123, 23)
        Me.cmdSALIR.TabIndex = 6
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'dgvCONSULTA
        '
        Me.dgvCONSULTA.AccessibleDescription = "Consulta "
        Me.dgvCONSULTA.AllowUserToAddRows = False
        Me.dgvCONSULTA.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvCONSULTA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCONSULTA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCONSULTA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCONSULTA.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCONSULTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCONSULTA.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCONSULTA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvCONSULTA.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCONSULTA.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvCONSULTA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA.Location = New System.Drawing.Point(16, 19)
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCONSULTA.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(997, 215)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgvCONSULTA)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1033, 251)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CONSULTA"
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 555)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(1068, 25)
        Me.strBARRESTA.TabIndex = 34
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
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.txtSEPARADOR)
        Me.GroupBox3.Controls.Add(Me.cmdExportarPlano)
        Me.GroupBox3.Controls.Add(Me.cmdLimpiar)
        Me.GroupBox3.Controls.Add(Me.cmdRestablecer)
        Me.GroupBox3.Controls.Add(Me.cmdAbrirArchivo)
        Me.GroupBox3.Controls.Add(Me.cmdExportarExcel)
        Me.GroupBox3.Controls.Add(Me.cmdSALIR)
        Me.GroupBox3.Controls.Add(Me.cmdEjecutar)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 197)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1033, 52)
        Me.GroupBox3.TabIndex = 35
        Me.GroupBox3.TabStop = False
        '
        'cmdLimpiar
        '
        Me.cmdLimpiar.AccessibleDescription = "Limpiar"
        Me.cmdLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLimpiar.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLimpiar.Location = New System.Drawing.Point(274, 17)
        Me.cmdLimpiar.Name = "cmdLimpiar"
        Me.cmdLimpiar.Size = New System.Drawing.Size(123, 23)
        Me.cmdLimpiar.TabIndex = 23
        Me.cmdLimpiar.Text = "Limpiar"
        Me.cmdLimpiar.UseVisualStyleBackColor = True
        '
        'cmdRestablecer
        '
        Me.cmdRestablecer.AccessibleDescription = "Restablecer"
        Me.cmdRestablecer.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdRestablecer.Image = Global.SICAFI.My.Resources.Resources._667
        Me.cmdRestablecer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRestablecer.Location = New System.Drawing.Point(145, 17)
        Me.cmdRestablecer.Name = "cmdRestablecer"
        Me.cmdRestablecer.Size = New System.Drawing.Size(123, 23)
        Me.cmdRestablecer.TabIndex = 22
        Me.cmdRestablecer.Text = "Restablecer"
        Me.cmdRestablecer.UseVisualStyleBackColor = True
        '
        'cmdAbrirArchivo
        '
        Me.cmdAbrirArchivo.AccessibleDescription = "Abrir archivo"
        Me.cmdAbrirArchivo.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdAbrirArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAbrirArchivo.Location = New System.Drawing.Point(403, 17)
        Me.cmdAbrirArchivo.Name = "cmdAbrirArchivo"
        Me.cmdAbrirArchivo.Size = New System.Drawing.Size(124, 23)
        Me.cmdAbrirArchivo.TabIndex = 7
        Me.cmdAbrirArchivo.Text = "Abrir archivo"
        Me.cmdAbrirArchivo.UseVisualStyleBackColor = True
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
        Me.cmdExportarExcel.Location = New System.Drawing.Point(533, 17)
        Me.cmdExportarExcel.Name = "cmdExportarExcel"
        Me.cmdExportarExcel.Size = New System.Drawing.Size(123, 23)
        Me.cmdExportarExcel.TabIndex = 5
        Me.cmdExportarExcel.Text = "&Exportar excel"
        Me.cmdExportarExcel.UseVisualStyleBackColor = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(15, 12)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.fraTERCERO)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1039, 520)
        Me.SplitContainer1.SplitterDistance = 259
        Me.SplitContainer1.TabIndex = 36
        '
        'cmdExportarPlano
        '
        Me.cmdExportarPlano.AccessibleDescription = "Plano"
        Me.cmdExportarPlano.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExportarPlano.Image = Global.SICAFI.My.Resources.Resources._71
        Me.cmdExportarPlano.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExportarPlano.Location = New System.Drawing.Point(662, 17)
        Me.cmdExportarPlano.Name = "cmdExportarPlano"
        Me.cmdExportarPlano.Size = New System.Drawing.Size(123, 23)
        Me.cmdExportarPlano.TabIndex = 24
        Me.cmdExportarPlano.Text = "&Exportar plano"
        Me.cmdExportarPlano.UseVisualStyleBackColor = True
        '
        'txtSEPARADOR
        '
        Me.txtSEPARADOR.Location = New System.Drawing.Point(791, 17)
        Me.txtSEPARADOR.Name = "txtSEPARADOR"
        Me.txtSEPARADOR.Size = New System.Drawing.Size(34, 20)
        Me.txtSEPARADOR.TabIndex = 104
        Me.txtSEPARADOR.Text = "|"
        Me.txtSEPARADOR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frm_CONSULTA_SQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1068, 580)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_CONSULTA_SQL"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CONSULTA SQL"
        Me.fraTERCERO.ResumeLayout(False)
        Me.fraTERCERO.PerformLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraTERCERO As System.Windows.Forms.GroupBox
    Friend WithEvents txtSELECT As System.Windows.Forms.Label
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents txtCODIGO As System.Windows.Forms.TextBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdEjecutar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExportarExcel As System.Windows.Forms.Button
    Friend WithEvents cmdAbrirArchivo As System.Windows.Forms.Button
    Friend WithEvents cmdRestablecer As System.Windows.Forms.Button
    Friend WithEvents rbdEliminar As System.Windows.Forms.RadioButton
    Friend WithEvents rbdActualizar As System.Windows.Forms.RadioButton
    Friend WithEvents rbdConsultar As System.Windows.Forms.RadioButton
    Friend WithEvents rbdInsertar As System.Windows.Forms.RadioButton
    Friend WithEvents cmdLimpiar As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmdExportarPlano As System.Windows.Forms.Button
    Friend WithEvents txtSEPARADOR As System.Windows.Forms.TextBox
End Class
