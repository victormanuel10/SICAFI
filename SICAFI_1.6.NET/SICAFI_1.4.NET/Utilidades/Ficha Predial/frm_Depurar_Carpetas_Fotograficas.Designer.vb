<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Depurar_Carpetas_Fotograficas
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdExportarExcel = New System.Windows.Forms.Button()
        Me.cmdMOVER = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdCARGAR = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dgvArchivosImagenesNoCruzan = New System.Windows.Forms.DataGridView()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtRutaDestino = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkMoverTodos = New System.Windows.Forms.CheckBox()
        Me.cmdAbrirCarpeta = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboRUCFMUNI = New System.Windows.Forms.ComboBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.lblRUCFMUNI = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.cboRUCFCLSE = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cboRUCFDEPA = New System.Windows.Forms.ComboBox()
        Me.lblRUCFCLSE = New System.Windows.Forms.Label()
        Me.lblRUCFDEPA = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.pbPROCESO = New System.Windows.Forms.ProgressBar()
        Me.cmdImportarDatos = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgvArchivosImagenesNoCruzan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cmdImportarDatos)
        Me.GroupBox3.Controls.Add(Me.cmdExportarExcel)
        Me.GroupBox3.Controls.Add(Me.cmdMOVER)
        Me.GroupBox3.Controls.Add(Me.cmdSALIR)
        Me.GroupBox3.Controls.Add(Me.cmdCARGAR)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 450)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(790, 46)
        Me.GroupBox3.TabIndex = 402
        Me.GroupBox3.TabStop = False
        '
        'cmdExportarExcel
        '
        Me.cmdExportarExcel.AccessibleDescription = "Exportar Excel"
        Me.cmdExportarExcel.AccessibleName = ""
        Me.cmdExportarExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdExportarExcel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExportarExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExportarExcel.Image = Global.SICAFI.My.Resources.Resources._229
        Me.cmdExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdExportarExcel.Location = New System.Drawing.Point(285, 15)
        Me.cmdExportarExcel.Name = "cmdExportarExcel"
        Me.cmdExportarExcel.Size = New System.Drawing.Size(123, 23)
        Me.cmdExportarExcel.TabIndex = 5
        Me.cmdExportarExcel.Text = "&Exportar excel"
        Me.cmdExportarExcel.UseVisualStyleBackColor = False
        '
        'cmdMOVER
        '
        Me.cmdMOVER.AccessibleDescription = "Mover"
        Me.cmdMOVER.Image = Global.SICAFI.My.Resources.Resources._25
        Me.cmdMOVER.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdMOVER.Location = New System.Drawing.Point(148, 15)
        Me.cmdMOVER.Name = "cmdMOVER"
        Me.cmdMOVER.Size = New System.Drawing.Size(131, 23)
        Me.cmdMOVER.TabIndex = 3
        Me.cmdMOVER.Text = "&Mover"
        Me.cmdMOVER.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(651, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(122, 23)
        Me.cmdSALIR.TabIndex = 2
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdCARGAR
        '
        Me.cmdCARGAR.AccessibleDescription = "Cargar"
        Me.cmdCARGAR.Image = Global.SICAFI.My.Resources.Resources._187
        Me.cmdCARGAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCARGAR.Location = New System.Drawing.Point(16, 15)
        Me.cmdCARGAR.Name = "cmdCARGAR"
        Me.cmdCARGAR.Size = New System.Drawing.Size(126, 23)
        Me.cmdCARGAR.TabIndex = 1
        Me.cmdCARGAR.Text = "&Cargar"
        Me.cmdCARGAR.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.dgvArchivosImagenesNoCruzan)
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(12, 246)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(790, 198)
        Me.GroupBox6.TabIndex = 404
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "ARCHIVOS"
        '
        'dgvArchivosImagenesNoCruzan
        '
        Me.dgvArchivosImagenesNoCruzan.AccessibleDescription = "Listado"
        Me.dgvArchivosImagenesNoCruzan.AllowUserToAddRows = False
        Me.dgvArchivosImagenesNoCruzan.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvArchivosImagenesNoCruzan.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvArchivosImagenesNoCruzan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvArchivosImagenesNoCruzan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvArchivosImagenesNoCruzan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvArchivosImagenesNoCruzan.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvArchivosImagenesNoCruzan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvArchivosImagenesNoCruzan.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvArchivosImagenesNoCruzan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvArchivosImagenesNoCruzan.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvArchivosImagenesNoCruzan.Location = New System.Drawing.Point(16, 19)
        Me.dgvArchivosImagenesNoCruzan.Name = "dgvArchivosImagenesNoCruzan"
        Me.dgvArchivosImagenesNoCruzan.ReadOnly = True
        Me.dgvArchivosImagenesNoCruzan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvArchivosImagenesNoCruzan.ShowCellToolTips = False
        Me.dgvArchivosImagenesNoCruzan.Size = New System.Drawing.Size(757, 161)
        Me.dgvArchivosImagenesNoCruzan.StandardTab = True
        Me.dgvArchivosImagenesNoCruzan.TabIndex = 4
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 515)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(816, 25)
        Me.strBARRESTA.TabIndex = 403
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
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtRutaDestino)
        Me.GroupBox5.Controls.Add(Me.cmdAbrirCarpeta)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(12, 121)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(638, 62)
        Me.GroupBox5.TabIndex = 401
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "RUTA DESTINO"
        '
        'txtRutaDestino
        '
        Me.txtRutaDestino.AccessibleDescription = "Ruta archivo"
        Me.txtRutaDestino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRutaDestino.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtRutaDestino.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRutaDestino.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRutaDestino.ForeColor = System.Drawing.Color.Black
        Me.txtRutaDestino.Location = New System.Drawing.Point(146, 25)
        Me.txtRutaDestino.Name = "txtRutaDestino"
        Me.txtRutaDestino.Size = New System.Drawing.Size(477, 20)
        Me.txtRutaDestino.TabIndex = 356
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkMoverTodos)
        Me.GroupBox4.Location = New System.Drawing.Point(656, 121)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(146, 62)
        Me.GroupBox4.TabIndex = 407
        Me.GroupBox4.TabStop = False
        '
        'chkMoverTodos
        '
        Me.chkMoverTodos.AutoSize = True
        Me.chkMoverTodos.Checked = True
        Me.chkMoverTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMoverTodos.Location = New System.Drawing.Point(14, 24)
        Me.chkMoverTodos.Name = "chkMoverTodos"
        Me.chkMoverTodos.Size = New System.Drawing.Size(85, 17)
        Me.chkMoverTodos.TabIndex = 0
        Me.chkMoverTodos.Text = "Mover todos"
        Me.chkMoverTodos.UseVisualStyleBackColor = True
        '
        'cmdAbrirCarpeta
        '
        Me.cmdAbrirCarpeta.AccessibleDescription = "Abrir carpeta"
        Me.cmdAbrirCarpeta.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdAbrirCarpeta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAbrirCarpeta.Location = New System.Drawing.Point(16, 23)
        Me.cmdAbrirCarpeta.Name = "cmdAbrirCarpeta"
        Me.cmdAbrirCarpeta.Size = New System.Drawing.Size(126, 23)
        Me.cmdAbrirCarpeta.TabIndex = 1
        Me.cmdAbrirCarpeta.Text = "Carpeta"
        Me.cmdAbrirCarpeta.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboRUCFMUNI)
        Me.GroupBox1.Controls.Add(Me.Label60)
        Me.GroupBox1.Controls.Add(Me.lblRUCFMUNI)
        Me.GroupBox1.Controls.Add(Me.Label58)
        Me.GroupBox1.Controls.Add(Me.cboRUCFCLSE)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.cboRUCFDEPA)
        Me.GroupBox1.Controls.Add(Me.lblRUCFCLSE)
        Me.GroupBox1.Controls.Add(Me.lblRUCFDEPA)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(790, 104)
        Me.GroupBox1.TabIndex = 400
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DEPURAR CARPETAS FOTOGRAFICAS"
        '
        'cboRUCFMUNI
        '
        Me.cboRUCFMUNI.AccessibleDescription = "Municipio"
        Me.cboRUCFMUNI.BackColor = System.Drawing.Color.White
        Me.cboRUCFMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUCFMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUCFMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUCFMUNI.Location = New System.Drawing.Point(146, 43)
        Me.cboRUCFMUNI.MaxDropDownItems = 15
        Me.cboRUCFMUNI.MaxLength = 1
        Me.cboRUCFMUNI.Name = "cboRUCFMUNI"
        Me.cboRUCFMUNI.Size = New System.Drawing.Size(493, 22)
        Me.cboRUCFMUNI.TabIndex = 2
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label60.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label60.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.ForeColor = System.Drawing.Color.Black
        Me.Label60.Location = New System.Drawing.Point(16, 45)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(126, 20)
        Me.Label60.TabIndex = 392
        Me.Label60.Text = "Municipio"
        '
        'lblRUCFMUNI
        '
        Me.lblRUCFMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUCFMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUCFMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUCFMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblRUCFMUNI.Location = New System.Drawing.Point(644, 45)
        Me.lblRUCFMUNI.Name = "lblRUCFMUNI"
        Me.lblRUCFMUNI.Size = New System.Drawing.Size(129, 20)
        Me.lblRUCFMUNI.TabIndex = 391
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label58.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label58.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.Black
        Me.Label58.Location = New System.Drawing.Point(16, 22)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(126, 20)
        Me.Label58.TabIndex = 386
        Me.Label58.Text = "Departamento"
        '
        'cboRUCFCLSE
        '
        Me.cboRUCFCLSE.AccessibleDescription = "Clase o sector "
        Me.cboRUCFCLSE.BackColor = System.Drawing.Color.White
        Me.cboRUCFCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUCFCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUCFCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUCFCLSE.Location = New System.Drawing.Point(146, 66)
        Me.cboRUCFCLSE.MaxDropDownItems = 15
        Me.cboRUCFCLSE.MaxLength = 1
        Me.cboRUCFCLSE.Name = "cboRUCFCLSE"
        Me.cboRUCFCLSE.Size = New System.Drawing.Size(493, 22)
        Me.cboRUCFCLSE.TabIndex = 3
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(16, 68)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(126, 20)
        Me.Label27.TabIndex = 384
        Me.Label27.Text = "Clase o sector"
        '
        'cboRUCFDEPA
        '
        Me.cboRUCFDEPA.AccessibleDescription = "Departamento"
        Me.cboRUCFDEPA.BackColor = System.Drawing.Color.White
        Me.cboRUCFDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUCFDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUCFDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUCFDEPA.Location = New System.Drawing.Point(146, 20)
        Me.cboRUCFDEPA.MaxDropDownItems = 15
        Me.cboRUCFDEPA.MaxLength = 1
        Me.cboRUCFDEPA.Name = "cboRUCFDEPA"
        Me.cboRUCFDEPA.Size = New System.Drawing.Size(493, 22)
        Me.cboRUCFDEPA.TabIndex = 1
        '
        'lblRUCFCLSE
        '
        Me.lblRUCFCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUCFCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUCFCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUCFCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblRUCFCLSE.Location = New System.Drawing.Point(644, 68)
        Me.lblRUCFCLSE.Name = "lblRUCFCLSE"
        Me.lblRUCFCLSE.Size = New System.Drawing.Size(129, 20)
        Me.lblRUCFCLSE.TabIndex = 385
        '
        'lblRUCFDEPA
        '
        Me.lblRUCFDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUCFDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUCFDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUCFDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblRUCFDEPA.Location = New System.Drawing.Point(644, 22)
        Me.lblRUCFDEPA.Name = "lblRUCFDEPA"
        Me.lblRUCFDEPA.Size = New System.Drawing.Size(129, 20)
        Me.lblRUCFDEPA.TabIndex = 387
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.pbPROCESO)
        Me.GroupBox8.Location = New System.Drawing.Point(12, 189)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(790, 51)
        Me.GroupBox8.TabIndex = 408
        Me.GroupBox8.TabStop = False
        '
        'pbPROCESO
        '
        Me.pbPROCESO.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pbPROCESO.Location = New System.Drawing.Point(16, 19)
        Me.pbPROCESO.Name = "pbPROCESO"
        Me.pbPROCESO.Size = New System.Drawing.Size(756, 17)
        Me.pbPROCESO.TabIndex = 25
        '
        'cmdImportarDatos
        '
        Me.cmdImportarDatos.AccessibleDescription = "Importar datos"
        Me.cmdImportarDatos.Image = Global.SICAFI.My.Resources.Resources._010
        Me.cmdImportarDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdImportarDatos.Location = New System.Drawing.Point(414, 15)
        Me.cmdImportarDatos.Name = "cmdImportarDatos"
        Me.cmdImportarDatos.Size = New System.Drawing.Size(123, 23)
        Me.cmdImportarDatos.TabIndex = 6
        Me.cmdImportarDatos.Text = "Importar datos"
        Me.cmdImportarDatos.UseVisualStyleBackColor = True
        '
        'frm_Depurar_Carpetas_Fotograficas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 540)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_Depurar_Carpetas_Fotograficas"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "DEPURAR CARPETAS FOTOGRAFICAS"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dgvArchivosImagenesNoCruzan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdCARGAR As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRutaDestino As System.Windows.Forms.Label
    Friend WithEvents cmdAbrirCarpeta As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboRUCFMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents lblRUCFMUNI As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents cboRUCFCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cboRUCFDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents lblRUCFCLSE As System.Windows.Forms.Label
    Friend WithEvents lblRUCFDEPA As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkMoverTodos As System.Windows.Forms.CheckBox
    Friend WithEvents dgvArchivosImagenesNoCruzan As System.Windows.Forms.DataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents pbPROCESO As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdMOVER As System.Windows.Forms.Button
    Friend WithEvents cmdExportarExcel As System.Windows.Forms.Button
    Friend WithEvents cmdImportarDatos As System.Windows.Forms.Button
End Class
