<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Cruce_Informacion_ICARE
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
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.rbdArchivoMunicipioAccess = New System.Windows.Forms.RadioButton()
        Me.rbdArchivoRegistroExcel = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lblCantidadRegistros = New System.Windows.Forms.Label()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.lblRutaInformacion = New System.Windows.Forms.Label()
        Me.cmdAbrirArchivoMunicipio = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.rbdCruzanMatriculasICAREvsMatriculasBD = New System.Windows.Forms.RadioButton()
        Me.rbdCargaInformaciónICARE = New System.Windows.Forms.RadioButton()
        Me.rbdCruzanCedulasICAREvsCedulasBD = New System.Windows.Forms.RadioButton()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.pbPROCESO = New System.Windows.Forms.ProgressBar()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdLIMPIAR = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdExportarExcel = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdCruzarCedulasICAREvsBD = New System.Windows.Forms.Button()
        Me.cmdCruzarMatriculasICAREvsBD = New System.Windows.Forms.Button()
        Me.cmdGuardarInformacionICARE = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvCargaInformacionICARE = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvCruzarMatriculasICAREvsBD = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.dgvCruzarCedulasICAREvsBD = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboRUPMCLSE = New System.Windows.Forms.ComboBox()
        Me.cboRUPMMUNI = New System.Windows.Forms.ComboBox()
        Me.cboRUPMDEPA = New System.Windows.Forms.ComboBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvCargaInformacionICARE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvCruzarMatriculasICAREvsBD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvCruzarCedulasICAREvsBD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.rbdArchivoMunicipioAccess)
        Me.GroupBox8.Controls.Add(Me.rbdArchivoRegistroExcel)
        Me.GroupBox8.ForeColor = System.Drawing.Color.Black
        Me.GroupBox8.Location = New System.Drawing.Point(748, 12)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(243, 62)
        Me.GroupBox8.TabIndex = 65
        Me.GroupBox8.TabStop = False
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
        'rbdArchivoRegistroExcel
        '
        Me.rbdArchivoRegistroExcel.AutoSize = True
        Me.rbdArchivoRegistroExcel.Checked = True
        Me.rbdArchivoRegistroExcel.Location = New System.Drawing.Point(14, 25)
        Me.rbdArchivoRegistroExcel.Name = "rbdArchivoRegistroExcel"
        Me.rbdArchivoRegistroExcel.Size = New System.Drawing.Size(90, 17)
        Me.rbdArchivoRegistroExcel.TabIndex = 357
        Me.rbdArchivoRegistroExcel.TabStop = True
        Me.rbdArchivoRegistroExcel.Text = "Archivo Excel"
        Me.rbdArchivoRegistroExcel.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblCantidadRegistros)
        Me.GroupBox5.Controls.Add(Me.lblPredio)
        Me.GroupBox5.Controls.Add(Me.lblRutaInformacion)
        Me.GroupBox5.Controls.Add(Me.cmdAbrirArchivoMunicipio)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(730, 62)
        Me.GroupBox5.TabIndex = 64
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "RUTA ARCHIVO"
        '
        'lblCantidadRegistros
        '
        Me.lblCantidadRegistros.AccessibleDescription = "Cantidad registros"
        Me.lblCantidadRegistros.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCantidadRegistros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCantidadRegistros.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadRegistros.Location = New System.Drawing.Point(599, 25)
        Me.lblCantidadRegistros.Name = "lblCantidadRegistros"
        Me.lblCantidadRegistros.Size = New System.Drawing.Size(113, 20)
        Me.lblCantidadRegistros.TabIndex = 369
        Me.lblCantidadRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPredio
        '
        Me.lblPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredio.ForeColor = System.Drawing.Color.Black
        Me.lblPredio.Location = New System.Drawing.Point(487, 25)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(106, 20)
        Me.lblPredio.TabIndex = 368
        Me.lblPredio.Text = "Cantidad :"
        '
        'lblRutaInformacion
        '
        Me.lblRutaInformacion.AccessibleDescription = "Ruta archivo"
        Me.lblRutaInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRutaInformacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRutaInformacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRutaInformacion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutaInformacion.ForeColor = System.Drawing.Color.Black
        Me.lblRutaInformacion.Location = New System.Drawing.Point(151, 25)
        Me.lblRutaInformacion.Name = "lblRutaInformacion"
        Me.lblRutaInformacion.Size = New System.Drawing.Size(330, 20)
        Me.lblRutaInformacion.TabIndex = 356
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
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.rbdCruzanMatriculasICAREvsMatriculasBD)
        Me.GroupBox6.Controls.Add(Me.rbdCargaInformaciónICARE)
        Me.GroupBox6.Controls.Add(Me.rbdCruzanCedulasICAREvsCedulasBD)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 445)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(979, 51)
        Me.GroupBox6.TabIndex = 71
        Me.GroupBox6.TabStop = False
        '
        'rbdCruzanMatriculasICAREvsMatriculasBD
        '
        Me.rbdCruzanMatriculasICAREvsMatriculasBD.Location = New System.Drawing.Point(210, 19)
        Me.rbdCruzanMatriculasICAREvsMatriculasBD.Name = "rbdCruzanMatriculasICAREvsMatriculasBD"
        Me.rbdCruzanMatriculasICAREvsMatriculasBD.Size = New System.Drawing.Size(203, 17)
        Me.rbdCruzanMatriculasICAREvsMatriculasBD.TabIndex = 4
        Me.rbdCruzanMatriculasICAREvsMatriculasBD.Text = "Cruzan Matriculas ICARE vs BD"
        Me.rbdCruzanMatriculasICAREvsMatriculasBD.UseVisualStyleBackColor = True
        '
        'rbdCargaInformaciónICARE
        '
        Me.rbdCargaInformaciónICARE.Checked = True
        Me.rbdCargaInformaciónICARE.Location = New System.Drawing.Point(19, 19)
        Me.rbdCargaInformaciónICARE.Name = "rbdCargaInformaciónICARE"
        Me.rbdCargaInformaciónICARE.Size = New System.Drawing.Size(162, 17)
        Me.rbdCargaInformaciónICARE.TabIndex = 3
        Me.rbdCargaInformaciónICARE.TabStop = True
        Me.rbdCargaInformaciónICARE.Text = "Carga Información ICARE"
        Me.rbdCargaInformaciónICARE.UseVisualStyleBackColor = True
        '
        'rbdCruzanCedulasICAREvsCedulasBD
        '
        Me.rbdCruzanCedulasICAREvsCedulasBD.Location = New System.Drawing.Point(419, 19)
        Me.rbdCruzanCedulasICAREvsCedulasBD.Name = "rbdCruzanCedulasICAREvsCedulasBD"
        Me.rbdCruzanCedulasICAREvsCedulasBD.Size = New System.Drawing.Size(184, 17)
        Me.rbdCruzanCedulasICAREvsCedulasBD.TabIndex = 0
        Me.rbdCruzanCedulasICAREvsCedulasBD.Text = "Cruzan Cedulas ICARE vs BD"
        Me.rbdCruzanCedulasICAREvsCedulasBD.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.pbPROCESO)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 191)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(979, 51)
        Me.GroupBox7.TabIndex = 69
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
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cmdLIMPIAR)
        Me.GroupBox3.Controls.Add(Me.cmdSALIR)
        Me.GroupBox3.Controls.Add(Me.cmdExportarExcel)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 500)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(979, 51)
        Me.GroupBox3.TabIndex = 67
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
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 557)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(1006, 25)
        Me.strBARRESTA.TabIndex = 68
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
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdCruzarCedulasICAREvsBD)
        Me.GroupBox4.Controls.Add(Me.cmdCruzarMatriculasICAREvsBD)
        Me.GroupBox4.Controls.Add(Me.cmdGuardarInformacionICARE)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(499, 78)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(492, 107)
        Me.GroupBox4.TabIndex = 70
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "PROCESOS"
        '
        'cmdCruzarCedulasICAREvsBD
        '
        Me.cmdCruzarCedulasICAREvsBD.AccessibleDescription = "Cruzar cedulas ICARE vs BD"
        Me.cmdCruzarCedulasICAREvsBD.Enabled = False
        Me.cmdCruzarCedulasICAREvsBD.Image = Global.SICAFI.My.Resources.Resources._125
        Me.cmdCruzarCedulasICAREvsBD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCruzarCedulasICAREvsBD.Location = New System.Drawing.Point(20, 70)
        Me.cmdCruzarCedulasICAREvsBD.Name = "cmdCruzarCedulasICAREvsBD"
        Me.cmdCruzarCedulasICAREvsBD.Size = New System.Drawing.Size(454, 23)
        Me.cmdCruzarCedulasICAREvsBD.TabIndex = 3
        Me.cmdCruzarCedulasICAREvsBD.Text = "Cruzar cedulas ICARE vs BD"
        Me.cmdCruzarCedulasICAREvsBD.UseVisualStyleBackColor = True
        '
        'cmdCruzarMatriculasICAREvsBD
        '
        Me.cmdCruzarMatriculasICAREvsBD.AccessibleDescription = "Cruzar matriculas ICARE vs BD"
        Me.cmdCruzarMatriculasICAREvsBD.Enabled = False
        Me.cmdCruzarMatriculasICAREvsBD.Image = Global.SICAFI.My.Resources.Resources._125
        Me.cmdCruzarMatriculasICAREvsBD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCruzarMatriculasICAREvsBD.Location = New System.Drawing.Point(20, 45)
        Me.cmdCruzarMatriculasICAREvsBD.Name = "cmdCruzarMatriculasICAREvsBD"
        Me.cmdCruzarMatriculasICAREvsBD.Size = New System.Drawing.Size(454, 23)
        Me.cmdCruzarMatriculasICAREvsBD.TabIndex = 2
        Me.cmdCruzarMatriculasICAREvsBD.Text = "Cruzar matriculas ICARE vs BD"
        Me.cmdCruzarMatriculasICAREvsBD.UseVisualStyleBackColor = True
        '
        'cmdGuardarInformacionICARE
        '
        Me.cmdGuardarInformacionICARE.AccessibleDescription = "Guardar informacion ICARE"
        Me.cmdGuardarInformacionICARE.Enabled = False
        Me.cmdGuardarInformacionICARE.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGuardarInformacionICARE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGuardarInformacionICARE.Location = New System.Drawing.Point(20, 20)
        Me.cmdGuardarInformacionICARE.Name = "cmdGuardarInformacionICARE"
        Me.cmdGuardarInformacionICARE.Size = New System.Drawing.Size(454, 23)
        Me.cmdGuardarInformacionICARE.TabIndex = 1
        Me.cmdGuardarInformacionICARE.Text = "Guardar información ICARE"
        Me.cmdGuardarInformacionICARE.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 248)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(979, 191)
        Me.GroupBox1.TabIndex = 66
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "LISTADOS"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(19, 19)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(942, 157)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvCargaInformacionICARE)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(934, 131)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Carga Información ICARE"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvCargaInformacionICARE
        '
        Me.dgvCargaInformacionICARE.AccessibleDescription = "Listado"
        Me.dgvCargaInformacionICARE.AllowUserToAddRows = False
        Me.dgvCargaInformacionICARE.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCargaInformacionICARE.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCargaInformacionICARE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCargaInformacionICARE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCargaInformacionICARE.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCargaInformacionICARE.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCargaInformacionICARE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCargaInformacionICARE.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvCargaInformacionICARE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCargaInformacionICARE.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCargaInformacionICARE.Location = New System.Drawing.Point(6, 6)
        Me.dgvCargaInformacionICARE.Name = "dgvCargaInformacionICARE"
        Me.dgvCargaInformacionICARE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvCargaInformacionICARE.ShowCellToolTips = False
        Me.dgvCargaInformacionICARE.Size = New System.Drawing.Size(922, 122)
        Me.dgvCargaInformacionICARE.StandardTab = True
        Me.dgvCargaInformacionICARE.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgvCruzarMatriculasICAREvsBD)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(934, 131)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Cruzan Matriculas ICARE vs BD"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgvCruzarMatriculasICAREvsBD
        '
        Me.dgvCruzarMatriculasICAREvsBD.AccessibleDescription = "Listado"
        Me.dgvCruzarMatriculasICAREvsBD.AllowUserToAddRows = False
        Me.dgvCruzarMatriculasICAREvsBD.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCruzarMatriculasICAREvsBD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCruzarMatriculasICAREvsBD.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCruzarMatriculasICAREvsBD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCruzarMatriculasICAREvsBD.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCruzarMatriculasICAREvsBD.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCruzarMatriculasICAREvsBD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCruzarMatriculasICAREvsBD.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvCruzarMatriculasICAREvsBD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCruzarMatriculasICAREvsBD.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCruzarMatriculasICAREvsBD.Location = New System.Drawing.Point(6, 6)
        Me.dgvCruzarMatriculasICAREvsBD.Name = "dgvCruzarMatriculasICAREvsBD"
        Me.dgvCruzarMatriculasICAREvsBD.ReadOnly = True
        Me.dgvCruzarMatriculasICAREvsBD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvCruzarMatriculasICAREvsBD.ShowCellToolTips = False
        Me.dgvCruzarMatriculasICAREvsBD.Size = New System.Drawing.Size(922, 122)
        Me.dgvCruzarMatriculasICAREvsBD.StandardTab = True
        Me.dgvCruzarMatriculasICAREvsBD.TabIndex = 3
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.dgvCruzarCedulasICAREvsBD)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(934, 131)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Cruzan Cedulas ICARE vs BD"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'dgvCruzarCedulasICAREvsBD
        '
        Me.dgvCruzarCedulasICAREvsBD.AccessibleDescription = "Listado"
        Me.dgvCruzarCedulasICAREvsBD.AllowUserToAddRows = False
        Me.dgvCruzarCedulasICAREvsBD.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCruzarCedulasICAREvsBD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCruzarCedulasICAREvsBD.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCruzarCedulasICAREvsBD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCruzarCedulasICAREvsBD.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCruzarCedulasICAREvsBD.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCruzarCedulasICAREvsBD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCruzarCedulasICAREvsBD.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvCruzarCedulasICAREvsBD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCruzarCedulasICAREvsBD.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCruzarCedulasICAREvsBD.Location = New System.Drawing.Point(6, 6)
        Me.dgvCruzarCedulasICAREvsBD.Name = "dgvCruzarCedulasICAREvsBD"
        Me.dgvCruzarCedulasICAREvsBD.ReadOnly = True
        Me.dgvCruzarCedulasICAREvsBD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvCruzarCedulasICAREvsBD.ShowCellToolTips = False
        Me.dgvCruzarCedulasICAREvsBD.Size = New System.Drawing.Size(922, 122)
        Me.dgvCruzarCedulasICAREvsBD.StandardTab = True
        Me.dgvCruzarCedulasICAREvsBD.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboRUPMCLSE)
        Me.GroupBox2.Controls.Add(Me.cboRUPMMUNI)
        Me.GroupBox2.Controls.Add(Me.cboRUPMDEPA)
        Me.GroupBox2.Controls.Add(Me.Label58)
        Me.GroupBox2.Controls.Add(Me.Label60)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(12, 78)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(481, 107)
        Me.GroupBox2.TabIndex = 72
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "UBICACIÓN"
        '
        'cboRUPMCLSE
        '
        Me.cboRUPMCLSE.AccessibleDescription = "Clase o sector "
        Me.cboRUPMCLSE.BackColor = System.Drawing.Color.White
        Me.cboRUPMCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUPMCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUPMCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUPMCLSE.Location = New System.Drawing.Point(149, 67)
        Me.cboRUPMCLSE.MaxDropDownItems = 15
        Me.cboRUPMCLSE.MaxLength = 1
        Me.cboRUPMCLSE.Name = "cboRUPMCLSE"
        Me.cboRUPMCLSE.Size = New System.Drawing.Size(312, 22)
        Me.cboRUPMCLSE.TabIndex = 384
        '
        'cboRUPMMUNI
        '
        Me.cboRUPMMUNI.AccessibleDescription = "Municipio"
        Me.cboRUPMMUNI.BackColor = System.Drawing.Color.White
        Me.cboRUPMMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUPMMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUPMMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUPMMUNI.Location = New System.Drawing.Point(149, 44)
        Me.cboRUPMMUNI.MaxDropDownItems = 15
        Me.cboRUPMMUNI.MaxLength = 1
        Me.cboRUPMMUNI.Name = "cboRUPMMUNI"
        Me.cboRUPMMUNI.Size = New System.Drawing.Size(312, 22)
        Me.cboRUPMMUNI.TabIndex = 383
        '
        'cboRUPMDEPA
        '
        Me.cboRUPMDEPA.AccessibleDescription = "Departamento"
        Me.cboRUPMDEPA.BackColor = System.Drawing.Color.White
        Me.cboRUPMDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUPMDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUPMDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUPMDEPA.Location = New System.Drawing.Point(149, 21)
        Me.cboRUPMDEPA.MaxDropDownItems = 15
        Me.cboRUPMDEPA.MaxLength = 1
        Me.cboRUPMDEPA.Name = "cboRUPMDEPA"
        Me.cboRUPMDEPA.Size = New System.Drawing.Size(312, 22)
        Me.cboRUPMDEPA.TabIndex = 382
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label58.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label58.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.Black
        Me.Label58.Location = New System.Drawing.Point(19, 23)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(127, 20)
        Me.Label58.TabIndex = 389
        Me.Label58.Text = "Departamento"
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label60.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label60.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.ForeColor = System.Drawing.Color.Black
        Me.Label60.Location = New System.Drawing.Point(19, 46)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(127, 20)
        Me.Label60.TabIndex = 388
        Me.Label60.Text = "Municipio"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(19, 69)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(127, 20)
        Me.Label27.TabIndex = 386
        Me.Label27.Text = "Clase o sector"
        '
        'frm_Cruce_Informacion_ICARE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1006, 582)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox5)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_Cruce_Informacion_ICARE"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CRUCE DE INFORMACIÓN ICARE"
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvCargaInformacionICARE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvCruzarMatriculasICAREvsBD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgvCruzarCedulasICAREvsBD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdArchivoMunicipioAccess As System.Windows.Forms.RadioButton
    Friend WithEvents rbdArchivoRegistroExcel As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCantidadRegistros As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblRutaInformacion As System.Windows.Forms.Label
    Friend WithEvents cmdAbrirArchivoMunicipio As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdCruzanMatriculasICAREvsMatriculasBD As System.Windows.Forms.RadioButton
    Friend WithEvents rbdCargaInformaciónICARE As System.Windows.Forms.RadioButton
    Friend WithEvents rbdCruzanCedulasICAREvsCedulasBD As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents pbPROCESO As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLIMPIAR As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdExportarExcel As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCruzarCedulasICAREvsBD As System.Windows.Forms.Button
    Friend WithEvents cmdCruzarMatriculasICAREvsBD As System.Windows.Forms.Button
    Friend WithEvents cmdGuardarInformacionICARE As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvCargaInformacionICARE As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dgvCruzarMatriculasICAREvsBD As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents dgvCruzarCedulasICAREvsBD As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboRUPMCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents cboRUPMMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents cboRUPMDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
End Class
