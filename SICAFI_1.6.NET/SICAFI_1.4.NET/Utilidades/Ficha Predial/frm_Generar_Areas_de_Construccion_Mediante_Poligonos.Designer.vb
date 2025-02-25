<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Generar_Areas_de_Construccion_Mediante_Poligonos
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.pbProceso = New System.Windows.Forms.ProgressBar()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cmdEstructurarDatos = New System.Windows.Forms.Button()
        Me.cmdValidaDatos = New System.Windows.Forms.Button()
        Me.cmdCruzarDatos = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblRutaArchivo = New System.Windows.Forms.Label()
        Me.lblCantidadRegistros = New System.Windows.Forms.Label()
        Me.cmdAbrirArchivo = New System.Windows.Forms.Button()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdLIMPIAR = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdExportarExcel = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabResultado = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvListadoFuente = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvListadoEstructurado = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvListadoCruce = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.dgvInconsistencias = New System.Windows.Forms.DataGridView()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbdInconsistencias = New System.Windows.Forms.RadioButton()
        Me.rbdCruceDeDatos = New System.Windows.Forms.RadioButton()
        Me.rbdListadoEstructurado = New System.Windows.Forms.RadioButton()
        Me.rbdListadoFuente = New System.Windows.Forms.RadioButton()
        Me.cmdImportarDatos = New System.Windows.Forms.Button()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabResultado.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvListadoFuente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvListadoEstructurado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvListadoCruce, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvInconsistencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.pbProceso)
        Me.GroupBox7.ForeColor = System.Drawing.Color.Black
        Me.GroupBox7.Location = New System.Drawing.Point(21, 154)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(909, 54)
        Me.GroupBox7.TabIndex = 57
        Me.GroupBox7.TabStop = False
        '
        'pbProceso
        '
        Me.pbProceso.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pbProceso.Location = New System.Drawing.Point(19, 19)
        Me.pbProceso.Name = "pbProceso"
        Me.pbProceso.Size = New System.Drawing.Size(872, 17)
        Me.pbProceso.TabIndex = 24
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.GroupBox6)
        Me.GroupBox5.Controls.Add(Me.GroupBox4)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(21, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(909, 133)
        Me.GroupBox5.TabIndex = 53
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "PROCESOS"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cmdImportarDatos)
        Me.GroupBox6.Controls.Add(Me.cmdEstructurarDatos)
        Me.GroupBox6.Controls.Add(Me.cmdValidaDatos)
        Me.GroupBox6.Controls.Add(Me.cmdCruzarDatos)
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(19, 72)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(872, 47)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        '
        'cmdEstructurarDatos
        '
        Me.cmdEstructurarDatos.AccessibleDescription = "Estructurar datos"
        Me.cmdEstructurarDatos.Enabled = False
        Me.cmdEstructurarDatos.Image = Global.SICAFI.My.Resources.Resources._028
        Me.cmdEstructurarDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEstructurarDatos.Location = New System.Drawing.Point(212, 15)
        Me.cmdEstructurarDatos.Name = "cmdEstructurarDatos"
        Me.cmdEstructurarDatos.Size = New System.Drawing.Size(189, 23)
        Me.cmdEstructurarDatos.TabIndex = 6
        Me.cmdEstructurarDatos.Text = "Estructurar datos"
        Me.cmdEstructurarDatos.UseVisualStyleBackColor = True
        '
        'cmdValidaDatos
        '
        Me.cmdValidaDatos.AccessibleDescription = "Valida datos"
        Me.cmdValidaDatos.Enabled = False
        Me.cmdValidaDatos.Image = Global.SICAFI.My.Resources.Resources._125
        Me.cmdValidaDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdValidaDatos.Location = New System.Drawing.Point(19, 15)
        Me.cmdValidaDatos.Name = "cmdValidaDatos"
        Me.cmdValidaDatos.Size = New System.Drawing.Size(187, 23)
        Me.cmdValidaDatos.TabIndex = 1
        Me.cmdValidaDatos.Text = "Validar datos"
        Me.cmdValidaDatos.UseVisualStyleBackColor = True
        '
        'cmdCruzarDatos
        '
        Me.cmdCruzarDatos.AccessibleDescription = "Cruzar datos"
        Me.cmdCruzarDatos.Enabled = False
        Me.cmdCruzarDatos.Image = Global.SICAFI.My.Resources.Resources._934
        Me.cmdCruzarDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCruzarDatos.Location = New System.Drawing.Point(407, 15)
        Me.cmdCruzarDatos.Name = "cmdCruzarDatos"
        Me.cmdCruzarDatos.Size = New System.Drawing.Size(254, 23)
        Me.cmdCruzarDatos.TabIndex = 2
        Me.cmdCruzarDatos.Text = "Cruzar areas Geodata vs Base de datos"
        Me.cmdCruzarDatos.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblRutaArchivo)
        Me.GroupBox4.Controls.Add(Me.lblCantidadRegistros)
        Me.GroupBox4.Controls.Add(Me.cmdAbrirArchivo)
        Me.GroupBox4.Controls.Add(Me.lblPredio)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(19, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(872, 47)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'lblRutaArchivo
        '
        Me.lblRutaArchivo.AccessibleDescription = "Ruta archivo"
        Me.lblRutaArchivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRutaArchivo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRutaArchivo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutaArchivo.ForeColor = System.Drawing.Color.Black
        Me.lblRutaArchivo.Location = New System.Drawing.Point(162, 16)
        Me.lblRutaArchivo.Name = "lblRutaArchivo"
        Me.lblRutaArchivo.Size = New System.Drawing.Size(522, 20)
        Me.lblRutaArchivo.TabIndex = 356
        '
        'lblCantidadRegistros
        '
        Me.lblCantidadRegistros.AccessibleDescription = "Cantidad registros"
        Me.lblCantidadRegistros.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCantidadRegistros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCantidadRegistros.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadRegistros.Location = New System.Drawing.Point(778, 15)
        Me.lblCantidadRegistros.Name = "lblCantidadRegistros"
        Me.lblCantidadRegistros.Size = New System.Drawing.Size(84, 20)
        Me.lblCantidadRegistros.TabIndex = 367
        Me.lblCantidadRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdAbrirArchivo
        '
        Me.cmdAbrirArchivo.AccessibleDescription = "Abrir archivo"
        Me.cmdAbrirArchivo.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdAbrirArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAbrirArchivo.Location = New System.Drawing.Point(19, 15)
        Me.cmdAbrirArchivo.Name = "cmdAbrirArchivo"
        Me.cmdAbrirArchivo.Size = New System.Drawing.Size(123, 23)
        Me.cmdAbrirArchivo.TabIndex = 1
        Me.cmdAbrirArchivo.Text = "Abrir archivo"
        Me.cmdAbrirArchivo.UseVisualStyleBackColor = True
        '
        'lblPredio
        '
        Me.lblPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredio.ForeColor = System.Drawing.Color.Black
        Me.lblPredio.Location = New System.Drawing.Point(690, 15)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(84, 20)
        Me.lblPredio.TabIndex = 308
        Me.lblPredio.Text = "Cantidad :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cmdLIMPIAR)
        Me.GroupBox3.Controls.Add(Me.cmdSALIR)
        Me.GroupBox3.Controls.Add(Me.cmdExportarExcel)
        Me.GroupBox3.Location = New System.Drawing.Point(517, 478)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(413, 47)
        Me.GroupBox3.TabIndex = 55
        Me.GroupBox3.TabStop = False
        '
        'cmdLIMPIAR
        '
        Me.cmdLIMPIAR.AccessibleDescription = "Limpiar campo"
        Me.cmdLIMPIAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLIMPIAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLIMPIAR.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLIMPIAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLIMPIAR.Location = New System.Drawing.Point(141, 16)
        Me.cmdLIMPIAR.Name = "cmdLIMPIAR"
        Me.cmdLIMPIAR.Size = New System.Drawing.Size(123, 23)
        Me.cmdLIMPIAR.TabIndex = 7
        Me.cmdLIMPIAR.Text = "&Limpiar campos"
        Me.cmdLIMPIAR.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(273, 16)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(123, 23)
        Me.cmdSALIR.TabIndex = 8
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdExportarExcel
        '
        Me.cmdExportarExcel.AccessibleDescription = "Exportar Excel"
        Me.cmdExportarExcel.AccessibleName = ""
        Me.cmdExportarExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdExportarExcel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExportarExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExportarExcel.Image = Global.SICAFI.My.Resources.Resources._041
        Me.cmdExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdExportarExcel.Location = New System.Drawing.Point(12, 16)
        Me.cmdExportarExcel.Name = "cmdExportarExcel"
        Me.cmdExportarExcel.Size = New System.Drawing.Size(123, 23)
        Me.cmdExportarExcel.TabIndex = 4
        Me.cmdExportarExcel.Text = "&Exportar excel"
        Me.cmdExportarExcel.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TabResultado)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(21, 214)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(909, 258)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "RESULTADOS"
        '
        'TabResultado
        '
        Me.TabResultado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabResultado.Controls.Add(Me.TabPage1)
        Me.TabResultado.Controls.Add(Me.TabPage2)
        Me.TabResultado.Controls.Add(Me.TabPage3)
        Me.TabResultado.Controls.Add(Me.TabPage4)
        Me.TabResultado.Location = New System.Drawing.Point(19, 19)
        Me.TabResultado.Name = "TabResultado"
        Me.TabResultado.SelectedIndex = 0
        Me.TabResultado.Size = New System.Drawing.Size(872, 224)
        Me.TabResultado.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvListadoFuente)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(864, 198)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Listado Fuente"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvListadoFuente
        '
        Me.dgvListadoFuente.AccessibleDescription = "Listado fuente"
        Me.dgvListadoFuente.AllowUserToAddRows = False
        Me.dgvListadoFuente.AllowUserToDeleteRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvListadoFuente.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvListadoFuente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListadoFuente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvListadoFuente.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvListadoFuente.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvListadoFuente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvListadoFuente.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvListadoFuente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvListadoFuente.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvListadoFuente.Location = New System.Drawing.Point(6, 6)
        Me.dgvListadoFuente.Name = "dgvListadoFuente"
        Me.dgvListadoFuente.ReadOnly = True
        Me.dgvListadoFuente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvListadoFuente.ShowCellToolTips = False
        Me.dgvListadoFuente.Size = New System.Drawing.Size(852, 189)
        Me.dgvListadoFuente.StandardTab = True
        Me.dgvListadoFuente.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvListadoEstructurado)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(864, 198)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Listado Estructurado"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvListadoEstructurado
        '
        Me.dgvListadoEstructurado.AccessibleDescription = "LIstado estructurado"
        Me.dgvListadoEstructurado.AllowUserToAddRows = False
        Me.dgvListadoEstructurado.AllowUserToDeleteRows = False
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvListadoEstructurado.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvListadoEstructurado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListadoEstructurado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvListadoEstructurado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvListadoEstructurado.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvListadoEstructurado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvListadoEstructurado.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvListadoEstructurado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvListadoEstructurado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvListadoEstructurado.Location = New System.Drawing.Point(6, 6)
        Me.dgvListadoEstructurado.Name = "dgvListadoEstructurado"
        Me.dgvListadoEstructurado.ReadOnly = True
        Me.dgvListadoEstructurado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvListadoEstructurado.ShowCellToolTips = False
        Me.dgvListadoEstructurado.Size = New System.Drawing.Size(852, 189)
        Me.dgvListadoEstructurado.StandardTab = True
        Me.dgvListadoEstructurado.TabIndex = 2
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgvListadoCruce)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(864, 198)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Cruce de datos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgvListadoCruce
        '
        Me.dgvListadoCruce.AccessibleDescription = "Municipio"
        Me.dgvListadoCruce.AllowUserToAddRows = False
        Me.dgvListadoCruce.AllowUserToDeleteRows = False
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvListadoCruce.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvListadoCruce.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListadoCruce.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvListadoCruce.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvListadoCruce.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvListadoCruce.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvListadoCruce.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvListadoCruce.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvListadoCruce.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvListadoCruce.Location = New System.Drawing.Point(6, 6)
        Me.dgvListadoCruce.Name = "dgvListadoCruce"
        Me.dgvListadoCruce.ReadOnly = True
        Me.dgvListadoCruce.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvListadoCruce.ShowCellToolTips = False
        Me.dgvListadoCruce.Size = New System.Drawing.Size(852, 189)
        Me.dgvListadoCruce.StandardTab = True
        Me.dgvListadoCruce.TabIndex = 2
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.dgvInconsistencias)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(864, 198)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Inconsistencias"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'dgvInconsistencias
        '
        Me.dgvInconsistencias.AccessibleDescription = "Inconsistencias"
        Me.dgvInconsistencias.AllowUserToAddRows = False
        Me.dgvInconsistencias.AllowUserToDeleteRows = False
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvInconsistencias.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle16
        Me.dgvInconsistencias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInconsistencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvInconsistencias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvInconsistencias.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvInconsistencias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvInconsistencias.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvInconsistencias.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvInconsistencias.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvInconsistencias.Location = New System.Drawing.Point(6, 6)
        Me.dgvInconsistencias.Name = "dgvInconsistencias"
        Me.dgvInconsistencias.ReadOnly = True
        Me.dgvInconsistencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvInconsistencias.ShowCellToolTips = False
        Me.dgvInconsistencias.Size = New System.Drawing.Size(852, 189)
        Me.dgvInconsistencias.StandardTab = True
        Me.dgvInconsistencias.TabIndex = 3
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 531)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(947, 25)
        Me.strBARRESTA.TabIndex = 56
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
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.rbdInconsistencias)
        Me.GroupBox2.Controls.Add(Me.rbdCruceDeDatos)
        Me.GroupBox2.Controls.Add(Me.rbdListadoEstructurado)
        Me.GroupBox2.Controls.Add(Me.rbdListadoFuente)
        Me.GroupBox2.Location = New System.Drawing.Point(21, 478)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(490, 47)
        Me.GroupBox2.TabIndex = 58
        Me.GroupBox2.TabStop = False
        '
        'rbdInconsistencias
        '
        Me.rbdInconsistencias.AutoSize = True
        Me.rbdInconsistencias.Location = New System.Drawing.Point(370, 17)
        Me.rbdInconsistencias.Name = "rbdInconsistencias"
        Me.rbdInconsistencias.Size = New System.Drawing.Size(98, 17)
        Me.rbdInconsistencias.TabIndex = 3
        Me.rbdInconsistencias.Text = "Inconsistencias"
        Me.rbdInconsistencias.UseVisualStyleBackColor = True
        '
        'rbdCruceDeDatos
        '
        Me.rbdCruceDeDatos.AutoSize = True
        Me.rbdCruceDeDatos.Location = New System.Drawing.Point(258, 17)
        Me.rbdCruceDeDatos.Name = "rbdCruceDeDatos"
        Me.rbdCruceDeDatos.Size = New System.Drawing.Size(97, 17)
        Me.rbdCruceDeDatos.TabIndex = 2
        Me.rbdCruceDeDatos.Text = "Cruce de datos"
        Me.rbdCruceDeDatos.UseVisualStyleBackColor = True
        '
        'rbdListadoEstructurado
        '
        Me.rbdListadoEstructurado.AutoSize = True
        Me.rbdListadoEstructurado.Location = New System.Drawing.Point(122, 17)
        Me.rbdListadoEstructurado.Name = "rbdListadoEstructurado"
        Me.rbdListadoEstructurado.Size = New System.Drawing.Size(121, 17)
        Me.rbdListadoEstructurado.TabIndex = 1
        Me.rbdListadoEstructurado.Text = "Listado estructurado"
        Me.rbdListadoEstructurado.UseVisualStyleBackColor = True
        '
        'rbdListadoFuente
        '
        Me.rbdListadoFuente.AutoSize = True
        Me.rbdListadoFuente.Checked = True
        Me.rbdListadoFuente.Location = New System.Drawing.Point(19, 17)
        Me.rbdListadoFuente.Name = "rbdListadoFuente"
        Me.rbdListadoFuente.Size = New System.Drawing.Size(92, 17)
        Me.rbdListadoFuente.TabIndex = 0
        Me.rbdListadoFuente.TabStop = True
        Me.rbdListadoFuente.Text = "Listado fuente"
        Me.rbdListadoFuente.UseVisualStyleBackColor = True
        '
        'cmdImportarDatos
        '
        Me.cmdImportarDatos.AccessibleDescription = "Importar datos"
        Me.cmdImportarDatos.Image = Global.SICAFI.My.Resources.Resources._010
        Me.cmdImportarDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdImportarDatos.Location = New System.Drawing.Point(667, 15)
        Me.cmdImportarDatos.Name = "cmdImportarDatos"
        Me.cmdImportarDatos.Size = New System.Drawing.Size(195, 23)
        Me.cmdImportarDatos.TabIndex = 7
        Me.cmdImportarDatos.Text = "Importar datos estructurados"
        Me.cmdImportarDatos.UseVisualStyleBackColor = True
        '
        'frm_Generar_Areas_de_Construccion_Mediante_Poligonos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 556)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_Generar_Areas_de_Construccion_Mediante_Poligonos"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "GENERAR AREAS DE CONSTRUCCIÓN MEDIANTE POLIGONOS"
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TabResultado.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvListadoFuente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvListadoEstructurado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvListadoCruce, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgvInconsistencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents pbProceso As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdValidaDatos As System.Windows.Forms.Button
    Friend WithEvents cmdCruzarDatos As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRutaArchivo As System.Windows.Forms.Label
    Friend WithEvents lblCantidadRegistros As System.Windows.Forms.Label
    Friend WithEvents cmdAbrirArchivo As System.Windows.Forms.Button
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLIMPIAR As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdExportarExcel As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabResultado As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvListadoFuente As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvListadoEstructurado As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dgvListadoCruce As System.Windows.Forms.DataGridView
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmdEstructurarDatos As System.Windows.Forms.Button
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents dgvInconsistencias As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdInconsistencias As System.Windows.Forms.RadioButton
    Friend WithEvents rbdCruceDeDatos As System.Windows.Forms.RadioButton
    Friend WithEvents rbdListadoEstructurado As System.Windows.Forms.RadioButton
    Friend WithEvents rbdListadoFuente As System.Windows.Forms.RadioButton
    Friend WithEvents cmdImportarDatos As System.Windows.Forms.Button
End Class
