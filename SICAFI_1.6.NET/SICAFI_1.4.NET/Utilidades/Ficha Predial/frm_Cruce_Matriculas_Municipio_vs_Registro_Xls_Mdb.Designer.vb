<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Cruce_Matriculas_Municipio_vs_Registro_Xls_Mdb
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lblCantidadPrediosMunicipio = New System.Windows.Forms.Label()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.lblRutaMunicipio = New System.Windows.Forms.Label()
        Me.cmdAbrirArchivoMunicipio = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdLIMPIAR = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdExportarExcel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvCargaMunicipio = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvCargaRegistro = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvMatriculasCruzanMunicipioRegistro = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.dgvMatriculasMunicipioNoRegistro = New System.Windows.Forms.DataGridView()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.dgvMatriculasRegistroNoMunicipio = New System.Windows.Forms.DataGridView()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblCantidadPrediosRegistro = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblRutaRegistro = New System.Windows.Forms.Label()
        Me.cmdAbrirArchivoRegistro = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdMatriculasRegistroNoMunicipio = New System.Windows.Forms.Button()
        Me.cmdMatriculasMunicipioNoRegistro = New System.Windows.Forms.Button()
        Me.cmdMatriculasCruzanMunicipioRegistro = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.pbPROCESO = New System.Windows.Forms.ProgressBar()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.rbdCargaRegistro = New System.Windows.Forms.RadioButton()
        Me.rbdCargaMunicipio = New System.Windows.Forms.RadioButton()
        Me.rbdMatriculasRegistroNoMunicipio = New System.Windows.Forms.RadioButton()
        Me.rbdMatriculasMunicipioNoRegistro = New System.Windows.Forms.RadioButton()
        Me.rbdMatriculasCruzanMunicipioRegistro = New System.Windows.Forms.RadioButton()
        Me.rbdArchivoMunicipioExcel = New System.Windows.Forms.RadioButton()
        Me.rbdArchivoMunicipioAccess = New System.Windows.Forms.RadioButton()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.rbdArchivoRegistroAccess = New System.Windows.Forms.RadioButton()
        Me.rbdArchivoRegistroExcel = New System.Windows.Forms.RadioButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvCargaMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvCargaRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvMatriculasCruzanMunicipioRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvMatriculasMunicipioNoRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgvMatriculasRegistroNoMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblCantidadPrediosMunicipio)
        Me.GroupBox5.Controls.Add(Me.lblPredio)
        Me.GroupBox5.Controls.Add(Me.lblRutaMunicipio)
        Me.GroupBox5.Controls.Add(Me.cmdAbrirArchivoMunicipio)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(730, 62)
        Me.GroupBox5.TabIndex = 53
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "RUTA ARCHIVO MUNICIPIO"
        '
        'lblCantidadPrediosMunicipio
        '
        Me.lblCantidadPrediosMunicipio.AccessibleDescription = "Cantidad predios"
        Me.lblCantidadPrediosMunicipio.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCantidadPrediosMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCantidadPrediosMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadPrediosMunicipio.Location = New System.Drawing.Point(628, 25)
        Me.lblCantidadPrediosMunicipio.Name = "lblCantidadPrediosMunicipio"
        Me.lblCantidadPrediosMunicipio.Size = New System.Drawing.Size(84, 20)
        Me.lblCantidadPrediosMunicipio.TabIndex = 369
        Me.lblCantidadPrediosMunicipio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPredio
        '
        Me.lblPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredio.ForeColor = System.Drawing.Color.Black
        Me.lblPredio.Location = New System.Drawing.Point(540, 25)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(84, 20)
        Me.lblPredio.TabIndex = 368
        Me.lblPredio.Text = "Cantidad :"
        '
        'lblRutaMunicipio
        '
        Me.lblRutaMunicipio.AccessibleDescription = "Ruta archivo"
        Me.lblRutaMunicipio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRutaMunicipio.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRutaMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRutaMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutaMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblRutaMunicipio.Location = New System.Drawing.Point(151, 25)
        Me.lblRutaMunicipio.Name = "lblRutaMunicipio"
        Me.lblRutaMunicipio.Size = New System.Drawing.Size(385, 20)
        Me.lblRutaMunicipio.TabIndex = 356
        '
        'cmdAbrirArchivoMunicipio
        '
        Me.cmdAbrirArchivoMunicipio.AccessibleDescription = "Abrir archivo"
        Me.cmdAbrirArchivoMunicipio.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdAbrirArchivoMunicipio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAbrirArchivoMunicipio.Location = New System.Drawing.Point(19, 23)
        Me.cmdAbrirArchivoMunicipio.Name = "cmdAbrirArchivoMunicipio"
        Me.cmdAbrirArchivoMunicipio.Size = New System.Drawing.Size(123, 23)
        Me.cmdAbrirArchivoMunicipio.TabIndex = 1
        Me.cmdAbrirArchivoMunicipio.Text = "Abrir archivo"
        Me.cmdAbrirArchivoMunicipio.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cmdLIMPIAR)
        Me.GroupBox3.Controls.Add(Me.cmdSALIR)
        Me.GroupBox3.Controls.Add(Me.cmdExportarExcel)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 508)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(979, 51)
        Me.GroupBox3.TabIndex = 58
        Me.GroupBox3.TabStop = False
        '
        'cmdLIMPIAR
        '
        Me.cmdLIMPIAR.AccessibleDescription = "Limpiar campo"
        Me.cmdLIMPIAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLIMPIAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLIMPIAR.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLIMPIAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLIMPIAR.Location = New System.Drawing.Point(148, 17)
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
        Me.cmdSALIR.Location = New System.Drawing.Point(834, 17)
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
        Me.cmdExportarExcel.Location = New System.Drawing.Point(19, 17)
        Me.cmdExportarExcel.Name = "cmdExportarExcel"
        Me.cmdExportarExcel.Size = New System.Drawing.Size(123, 23)
        Me.cmdExportarExcel.TabIndex = 4
        Me.cmdExportarExcel.Text = "&Exportar excel"
        Me.cmdExportarExcel.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 273)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(979, 174)
        Me.GroupBox1.TabIndex = 57
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "LISTADOS"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(19, 19)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(942, 140)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvCargaMunicipio)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(934, 114)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Carga Matriculas Municipio"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvCargaMunicipio
        '
        Me.dgvCargaMunicipio.AccessibleDescription = "Listado"
        Me.dgvCargaMunicipio.AllowUserToAddRows = False
        Me.dgvCargaMunicipio.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCargaMunicipio.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCargaMunicipio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCargaMunicipio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCargaMunicipio.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCargaMunicipio.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCargaMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCargaMunicipio.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvCargaMunicipio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCargaMunicipio.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCargaMunicipio.Location = New System.Drawing.Point(6, 6)
        Me.dgvCargaMunicipio.Name = "dgvCargaMunicipio"
        Me.dgvCargaMunicipio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvCargaMunicipio.ShowCellToolTips = False
        Me.dgvCargaMunicipio.Size = New System.Drawing.Size(922, 105)
        Me.dgvCargaMunicipio.StandardTab = True
        Me.dgvCargaMunicipio.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvCargaRegistro)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(934, 114)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Carga Matriculas Registro"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvCargaRegistro
        '
        Me.dgvCargaRegistro.AccessibleDescription = "Listado"
        Me.dgvCargaRegistro.AllowUserToAddRows = False
        Me.dgvCargaRegistro.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCargaRegistro.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCargaRegistro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCargaRegistro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCargaRegistro.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCargaRegistro.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCargaRegistro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCargaRegistro.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvCargaRegistro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCargaRegistro.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCargaRegistro.Location = New System.Drawing.Point(6, 6)
        Me.dgvCargaRegistro.Name = "dgvCargaRegistro"
        Me.dgvCargaRegistro.ReadOnly = True
        Me.dgvCargaRegistro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvCargaRegistro.ShowCellToolTips = False
        Me.dgvCargaRegistro.Size = New System.Drawing.Size(922, 105)
        Me.dgvCargaRegistro.StandardTab = True
        Me.dgvCargaRegistro.TabIndex = 2
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgvMatriculasCruzanMunicipioRegistro)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(934, 114)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Cruzan Municipio vs Registro"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgvMatriculasCruzanMunicipioRegistro
        '
        Me.dgvMatriculasCruzanMunicipioRegistro.AccessibleDescription = "Listado"
        Me.dgvMatriculasCruzanMunicipioRegistro.AllowUserToAddRows = False
        Me.dgvMatriculasCruzanMunicipioRegistro.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvMatriculasCruzanMunicipioRegistro.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvMatriculasCruzanMunicipioRegistro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMatriculasCruzanMunicipioRegistro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvMatriculasCruzanMunicipioRegistro.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvMatriculasCruzanMunicipioRegistro.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvMatriculasCruzanMunicipioRegistro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMatriculasCruzanMunicipioRegistro.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvMatriculasCruzanMunicipioRegistro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvMatriculasCruzanMunicipioRegistro.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvMatriculasCruzanMunicipioRegistro.Location = New System.Drawing.Point(6, 6)
        Me.dgvMatriculasCruzanMunicipioRegistro.Name = "dgvMatriculasCruzanMunicipioRegistro"
        Me.dgvMatriculasCruzanMunicipioRegistro.ReadOnly = True
        Me.dgvMatriculasCruzanMunicipioRegistro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvMatriculasCruzanMunicipioRegistro.ShowCellToolTips = False
        Me.dgvMatriculasCruzanMunicipioRegistro.Size = New System.Drawing.Size(922, 105)
        Me.dgvMatriculasCruzanMunicipioRegistro.StandardTab = True
        Me.dgvMatriculasCruzanMunicipioRegistro.TabIndex = 3
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.dgvMatriculasMunicipioNoRegistro)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(934, 114)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Existentes en Municipio y no en Registro"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'dgvMatriculasMunicipioNoRegistro
        '
        Me.dgvMatriculasMunicipioNoRegistro.AccessibleDescription = "Listado"
        Me.dgvMatriculasMunicipioNoRegistro.AllowUserToAddRows = False
        Me.dgvMatriculasMunicipioNoRegistro.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvMatriculasMunicipioNoRegistro.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvMatriculasMunicipioNoRegistro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMatriculasMunicipioNoRegistro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvMatriculasMunicipioNoRegistro.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvMatriculasMunicipioNoRegistro.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvMatriculasMunicipioNoRegistro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMatriculasMunicipioNoRegistro.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvMatriculasMunicipioNoRegistro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvMatriculasMunicipioNoRegistro.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvMatriculasMunicipioNoRegistro.Location = New System.Drawing.Point(6, 6)
        Me.dgvMatriculasMunicipioNoRegistro.Name = "dgvMatriculasMunicipioNoRegistro"
        Me.dgvMatriculasMunicipioNoRegistro.ReadOnly = True
        Me.dgvMatriculasMunicipioNoRegistro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvMatriculasMunicipioNoRegistro.ShowCellToolTips = False
        Me.dgvMatriculasMunicipioNoRegistro.Size = New System.Drawing.Size(922, 105)
        Me.dgvMatriculasMunicipioNoRegistro.StandardTab = True
        Me.dgvMatriculasMunicipioNoRegistro.TabIndex = 3
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.dgvMatriculasRegistroNoMunicipio)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(934, 114)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Existentes en Registro y no en Municipio"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'dgvMatriculasRegistroNoMunicipio
        '
        Me.dgvMatriculasRegistroNoMunicipio.AccessibleDescription = "Listado"
        Me.dgvMatriculasRegistroNoMunicipio.AllowUserToAddRows = False
        Me.dgvMatriculasRegistroNoMunicipio.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvMatriculasRegistroNoMunicipio.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvMatriculasRegistroNoMunicipio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMatriculasRegistroNoMunicipio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvMatriculasRegistroNoMunicipio.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvMatriculasRegistroNoMunicipio.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvMatriculasRegistroNoMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMatriculasRegistroNoMunicipio.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvMatriculasRegistroNoMunicipio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvMatriculasRegistroNoMunicipio.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvMatriculasRegistroNoMunicipio.Location = New System.Drawing.Point(6, 6)
        Me.dgvMatriculasRegistroNoMunicipio.Name = "dgvMatriculasRegistroNoMunicipio"
        Me.dgvMatriculasRegistroNoMunicipio.ReadOnly = True
        Me.dgvMatriculasRegistroNoMunicipio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvMatriculasRegistroNoMunicipio.ShowCellToolTips = False
        Me.dgvMatriculasRegistroNoMunicipio.Size = New System.Drawing.Size(922, 105)
        Me.dgvMatriculasRegistroNoMunicipio.StandardTab = True
        Me.dgvMatriculasRegistroNoMunicipio.TabIndex = 3
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 571)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(1003, 25)
        Me.strBARRESTA.TabIndex = 59
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
        Me.GroupBox2.Controls.Add(Me.lblCantidadPrediosRegistro)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblRutaRegistro)
        Me.GroupBox2.Controls.Add(Me.cmdAbrirArchivoRegistro)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(12, 79)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(730, 62)
        Me.GroupBox2.TabIndex = 60
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "RUTA ARCHIVO REGISTRO"
        '
        'lblCantidadPrediosRegistro
        '
        Me.lblCantidadPrediosRegistro.AccessibleDescription = "Cantidad predios"
        Me.lblCantidadPrediosRegistro.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCantidadPrediosRegistro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCantidadPrediosRegistro.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadPrediosRegistro.Location = New System.Drawing.Point(628, 25)
        Me.lblCantidadPrediosRegistro.Name = "lblCantidadPrediosRegistro"
        Me.lblCantidadPrediosRegistro.Size = New System.Drawing.Size(84, 20)
        Me.lblCantidadPrediosRegistro.TabIndex = 371
        Me.lblCantidadPrediosRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(540, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 20)
        Me.Label2.TabIndex = 370
        Me.Label2.Text = "Cantidad :"
        '
        'lblRutaRegistro
        '
        Me.lblRutaRegistro.AccessibleDescription = "Ruta archivo"
        Me.lblRutaRegistro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRutaRegistro.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRutaRegistro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRutaRegistro.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutaRegistro.ForeColor = System.Drawing.Color.Black
        Me.lblRutaRegistro.Location = New System.Drawing.Point(151, 25)
        Me.lblRutaRegistro.Name = "lblRutaRegistro"
        Me.lblRutaRegistro.Size = New System.Drawing.Size(385, 20)
        Me.lblRutaRegistro.TabIndex = 356
        '
        'cmdAbrirArchivoRegistro
        '
        Me.cmdAbrirArchivoRegistro.AccessibleDescription = "Abrir archivo"
        Me.cmdAbrirArchivoRegistro.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdAbrirArchivoRegistro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAbrirArchivoRegistro.Location = New System.Drawing.Point(19, 23)
        Me.cmdAbrirArchivoRegistro.Name = "cmdAbrirArchivoRegistro"
        Me.cmdAbrirArchivoRegistro.Size = New System.Drawing.Size(123, 23)
        Me.cmdAbrirArchivoRegistro.TabIndex = 1
        Me.cmdAbrirArchivoRegistro.Text = "Abrir archivo"
        Me.cmdAbrirArchivoRegistro.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdMatriculasRegistroNoMunicipio)
        Me.GroupBox4.Controls.Add(Me.cmdMatriculasMunicipioNoRegistro)
        Me.GroupBox4.Controls.Add(Me.cmdMatriculasCruzanMunicipioRegistro)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(12, 147)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(979, 62)
        Me.GroupBox4.TabIndex = 61
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "PROCESOS"
        '
        'cmdMatriculasRegistroNoMunicipio
        '
        Me.cmdMatriculasRegistroNoMunicipio.AccessibleDescription = "Existen registro no municipio"
        Me.cmdMatriculasRegistroNoMunicipio.Enabled = False
        Me.cmdMatriculasRegistroNoMunicipio.Image = Global.SICAFI.My.Resources.Resources._125
        Me.cmdMatriculasRegistroNoMunicipio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdMatriculasRegistroNoMunicipio.Location = New System.Drawing.Point(654, 22)
        Me.cmdMatriculasRegistroNoMunicipio.Name = "cmdMatriculasRegistroNoMunicipio"
        Me.cmdMatriculasRegistroNoMunicipio.Size = New System.Drawing.Size(307, 23)
        Me.cmdMatriculasRegistroNoMunicipio.TabIndex = 3
        Me.cmdMatriculasRegistroNoMunicipio.Text = "Matriculas existentes en Registro y no en Municipio"
        Me.cmdMatriculasRegistroNoMunicipio.UseVisualStyleBackColor = True
        '
        'cmdMatriculasMunicipioNoRegistro
        '
        Me.cmdMatriculasMunicipioNoRegistro.AccessibleDescription = "Existen municipio no registro"
        Me.cmdMatriculasMunicipioNoRegistro.Enabled = False
        Me.cmdMatriculasMunicipioNoRegistro.Image = Global.SICAFI.My.Resources.Resources._125
        Me.cmdMatriculasMunicipioNoRegistro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdMatriculasMunicipioNoRegistro.Location = New System.Drawing.Point(332, 22)
        Me.cmdMatriculasMunicipioNoRegistro.Name = "cmdMatriculasMunicipioNoRegistro"
        Me.cmdMatriculasMunicipioNoRegistro.Size = New System.Drawing.Size(316, 23)
        Me.cmdMatriculasMunicipioNoRegistro.TabIndex = 2
        Me.cmdMatriculasMunicipioNoRegistro.Text = "Matriculas existentes en Municipio y no en Registro"
        Me.cmdMatriculasMunicipioNoRegistro.UseVisualStyleBackColor = True
        '
        'cmdMatriculasCruzanMunicipioRegistro
        '
        Me.cmdMatriculasCruzanMunicipioRegistro.AccessibleDescription = "Matriculas que cruzan"
        Me.cmdMatriculasCruzanMunicipioRegistro.Enabled = False
        Me.cmdMatriculasCruzanMunicipioRegistro.Image = Global.SICAFI.My.Resources.Resources._125
        Me.cmdMatriculasCruzanMunicipioRegistro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdMatriculasCruzanMunicipioRegistro.Location = New System.Drawing.Point(19, 22)
        Me.cmdMatriculasCruzanMunicipioRegistro.Name = "cmdMatriculasCruzanMunicipioRegistro"
        Me.cmdMatriculasCruzanMunicipioRegistro.Size = New System.Drawing.Size(307, 23)
        Me.cmdMatriculasCruzanMunicipioRegistro.TabIndex = 1
        Me.cmdMatriculasCruzanMunicipioRegistro.Text = "Matriculas que cruzan Municipio vs Registro"
        Me.cmdMatriculasCruzanMunicipioRegistro.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.pbPROCESO)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 215)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(979, 51)
        Me.GroupBox7.TabIndex = 59
        Me.GroupBox7.TabStop = False
        '
        'pbPROCESO
        '
        Me.pbPROCESO.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pbPROCESO.Location = New System.Drawing.Point(19, 19)
        Me.pbPROCESO.Name = "pbPROCESO"
        Me.pbPROCESO.Size = New System.Drawing.Size(942, 17)
        Me.pbPROCESO.TabIndex = 25
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.rbdCargaRegistro)
        Me.GroupBox6.Controls.Add(Me.rbdCargaMunicipio)
        Me.GroupBox6.Controls.Add(Me.rbdMatriculasRegistroNoMunicipio)
        Me.GroupBox6.Controls.Add(Me.rbdMatriculasMunicipioNoRegistro)
        Me.GroupBox6.Controls.Add(Me.rbdMatriculasCruzanMunicipioRegistro)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 453)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(979, 51)
        Me.GroupBox6.TabIndex = 62
        Me.GroupBox6.TabStop = False
        '
        'rbdCargaRegistro
        '
        Me.rbdCargaRegistro.Location = New System.Drawing.Point(160, 19)
        Me.rbdCargaRegistro.Name = "rbdCargaRegistro"
        Me.rbdCargaRegistro.Size = New System.Drawing.Size(111, 17)
        Me.rbdCargaRegistro.TabIndex = 4
        Me.rbdCargaRegistro.Text = "Carga Registro"
        Me.rbdCargaRegistro.UseVisualStyleBackColor = True
        '
        'rbdCargaMunicipio
        '
        Me.rbdCargaMunicipio.Checked = True
        Me.rbdCargaMunicipio.Location = New System.Drawing.Point(19, 19)
        Me.rbdCargaMunicipio.Name = "rbdCargaMunicipio"
        Me.rbdCargaMunicipio.Size = New System.Drawing.Size(123, 17)
        Me.rbdCargaMunicipio.TabIndex = 3
        Me.rbdCargaMunicipio.TabStop = True
        Me.rbdCargaMunicipio.Text = "Carga Municipio"
        Me.rbdCargaMunicipio.UseVisualStyleBackColor = True
        '
        'rbdMatriculasRegistroNoMunicipio
        '
        Me.rbdMatriculasRegistroNoMunicipio.Location = New System.Drawing.Point(741, 19)
        Me.rbdMatriculasRegistroNoMunicipio.Name = "rbdMatriculasRegistroNoMunicipio"
        Me.rbdMatriculasRegistroNoMunicipio.Size = New System.Drawing.Size(232, 17)
        Me.rbdMatriculasRegistroNoMunicipio.TabIndex = 2
        Me.rbdMatriculasRegistroNoMunicipio.Text = "Existentes en Registro y no en Municipio"
        Me.rbdMatriculasRegistroNoMunicipio.UseVisualStyleBackColor = True
        '
        'rbdMatriculasMunicipioNoRegistro
        '
        Me.rbdMatriculasMunicipioNoRegistro.Location = New System.Drawing.Point(495, 19)
        Me.rbdMatriculasMunicipioNoRegistro.Name = "rbdMatriculasMunicipioNoRegistro"
        Me.rbdMatriculasMunicipioNoRegistro.Size = New System.Drawing.Size(235, 17)
        Me.rbdMatriculasMunicipioNoRegistro.TabIndex = 1
        Me.rbdMatriculasMunicipioNoRegistro.Text = "Existentes en Municipio y no en Registro"
        Me.rbdMatriculasMunicipioNoRegistro.UseVisualStyleBackColor = True
        '
        'rbdMatriculasCruzanMunicipioRegistro
        '
        Me.rbdMatriculasCruzanMunicipioRegistro.Location = New System.Drawing.Point(291, 19)
        Me.rbdMatriculasCruzanMunicipioRegistro.Name = "rbdMatriculasCruzanMunicipioRegistro"
        Me.rbdMatriculasCruzanMunicipioRegistro.Size = New System.Drawing.Size(183, 17)
        Me.rbdMatriculasCruzanMunicipioRegistro.TabIndex = 0
        Me.rbdMatriculasCruzanMunicipioRegistro.Text = "Cruzan Municipio vs Registro"
        Me.rbdMatriculasCruzanMunicipioRegistro.UseVisualStyleBackColor = True
        '
        'rbdArchivoMunicipioExcel
        '
        Me.rbdArchivoMunicipioExcel.AutoSize = True
        Me.rbdArchivoMunicipioExcel.Checked = True
        Me.rbdArchivoMunicipioExcel.Location = New System.Drawing.Point(14, 25)
        Me.rbdArchivoMunicipioExcel.Name = "rbdArchivoMunicipioExcel"
        Me.rbdArchivoMunicipioExcel.Size = New System.Drawing.Size(90, 17)
        Me.rbdArchivoMunicipioExcel.TabIndex = 357
        Me.rbdArchivoMunicipioExcel.TabStop = True
        Me.rbdArchivoMunicipioExcel.Text = "Archivo Excel"
        Me.rbdArchivoMunicipioExcel.UseVisualStyleBackColor = True
        '
        'rbdArchivoMunicipioAccess
        '
        Me.rbdArchivoMunicipioAccess.AutoSize = True
        Me.rbdArchivoMunicipioAccess.Location = New System.Drawing.Point(120, 24)
        Me.rbdArchivoMunicipioAccess.Name = "rbdArchivoMunicipioAccess"
        Me.rbdArchivoMunicipioAccess.Size = New System.Drawing.Size(99, 17)
        Me.rbdArchivoMunicipioAccess.TabIndex = 358
        Me.rbdArchivoMunicipioAccess.Text = "Archivo Access"
        Me.rbdArchivoMunicipioAccess.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.rbdArchivoMunicipioAccess)
        Me.GroupBox8.Controls.Add(Me.rbdArchivoMunicipioExcel)
        Me.GroupBox8.ForeColor = System.Drawing.Color.Black
        Me.GroupBox8.Location = New System.Drawing.Point(748, 13)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(243, 62)
        Me.GroupBox8.TabIndex = 63
        Me.GroupBox8.TabStop = False
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.rbdArchivoRegistroAccess)
        Me.GroupBox9.Controls.Add(Me.rbdArchivoRegistroExcel)
        Me.GroupBox9.ForeColor = System.Drawing.Color.Black
        Me.GroupBox9.Location = New System.Drawing.Point(748, 81)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(243, 62)
        Me.GroupBox9.TabIndex = 64
        Me.GroupBox9.TabStop = False
        '
        'rbdArchivoRegistroAccess
        '
        Me.rbdArchivoRegistroAccess.AutoSize = True
        Me.rbdArchivoRegistroAccess.Location = New System.Drawing.Point(120, 23)
        Me.rbdArchivoRegistroAccess.Name = "rbdArchivoRegistroAccess"
        Me.rbdArchivoRegistroAccess.Size = New System.Drawing.Size(99, 17)
        Me.rbdArchivoRegistroAccess.TabIndex = 358
        Me.rbdArchivoRegistroAccess.Text = "Archivo Access"
        Me.rbdArchivoRegistroAccess.UseVisualStyleBackColor = True
        '
        'rbdArchivoRegistroExcel
        '
        Me.rbdArchivoRegistroExcel.AutoSize = True
        Me.rbdArchivoRegistroExcel.Checked = True
        Me.rbdArchivoRegistroExcel.Location = New System.Drawing.Point(14, 24)
        Me.rbdArchivoRegistroExcel.Name = "rbdArchivoRegistroExcel"
        Me.rbdArchivoRegistroExcel.Size = New System.Drawing.Size(90, 17)
        Me.rbdArchivoRegistroExcel.TabIndex = 357
        Me.rbdArchivoRegistroExcel.TabStop = True
        Me.rbdArchivoRegistroExcel.Text = "Archivo Excel"
        Me.rbdArchivoRegistroExcel.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'frm_Cruce_Matriculas_Municipio_vs_Registro_Xls_Mdb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 596)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox5)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_Cruce_Matriculas_Municipio_vs_Registro_Xls_Mdb"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CRUCE MATRICULAS MUNICIPIO VS REGISTRO XLS - MDB"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvCargaMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvCargaRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvMatriculasCruzanMunicipioRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgvMatriculasMunicipioNoRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.dgvMatriculasRegistroNoMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRutaMunicipio As System.Windows.Forms.Label
    Friend WithEvents cmdAbrirArchivoMunicipio As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdExportarExcel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvCargaMunicipio As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvCargaRegistro As System.Windows.Forms.DataGridView
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRutaRegistro As System.Windows.Forms.Label
    Friend WithEvents cmdAbrirArchivoRegistro As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdMatriculasCruzanMunicipioRegistro As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdMatriculasRegistroNoMunicipio As System.Windows.Forms.Button
    Friend WithEvents cmdMatriculasMunicipioNoRegistro As System.Windows.Forms.Button
    Friend WithEvents pbPROCESO As System.Windows.Forms.ProgressBar
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents dgvMatriculasCruzanMunicipioRegistro As System.Windows.Forms.DataGridView
    Friend WithEvents dgvMatriculasMunicipioNoRegistro As System.Windows.Forms.DataGridView
    Friend WithEvents dgvMatriculasRegistroNoMunicipio As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdCargaMunicipio As System.Windows.Forms.RadioButton
    Friend WithEvents rbdMatriculasRegistroNoMunicipio As System.Windows.Forms.RadioButton
    Friend WithEvents rbdMatriculasMunicipioNoRegistro As System.Windows.Forms.RadioButton
    Friend WithEvents rbdMatriculasCruzanMunicipioRegistro As System.Windows.Forms.RadioButton
    Friend WithEvents rbdCargaRegistro As System.Windows.Forms.RadioButton
    Friend WithEvents cmdLIMPIAR As System.Windows.Forms.Button
    Friend WithEvents rbdArchivoMunicipioExcel As System.Windows.Forms.RadioButton
    Friend WithEvents rbdArchivoMunicipioAccess As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdArchivoRegistroAccess As System.Windows.Forms.RadioButton
    Friend WithEvents rbdArchivoRegistroExcel As System.Windows.Forms.RadioButton
    Friend WithEvents lblCantidadPrediosMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblCantidadPrediosRegistro As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
