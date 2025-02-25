<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_importar_planos_FICHA_PREDIAL
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtSEPARADOR = New System.Windows.Forms.TextBox()
        Me.cmdExportarPlano = New System.Windows.Forms.Button()
        Me.cmdLIMPIAR = New System.Windows.Forms.Button()
        Me.cmdExportarExcel = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvFIPRINCO = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvFIREINCO = New System.Windows.Forms.DataGridView()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblAbrirArchivoResolucionActualizacion = New System.Windows.Forms.Label()
        Me.cmdAbrirArchivoResolucionActualizacion = New System.Windows.Forms.Button()
        Me.rbdFichaResumenResolucionActualizacion = New System.Windows.Forms.RadioButton()
        Me.rbdFichaPredialResolucionActualizacion = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.rbdInsertaPrediosNuevosResolucionActualizacion = New System.Windows.Forms.RadioButton()
        Me.rbdActualizarInsertarPrediosResolucionActualizacion = New System.Windows.Forms.RadioButton()
        Me.chkSobrescribirBDexistenteResolucionActualizacion = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkInsertarMaestrosResolucionActualizacion = New System.Windows.Forms.CheckBox()
        Me.cmdSeleccionResolucionActualizacion = New System.Windows.Forms.Button()
        Me.txtREACCLSE = New System.Windows.Forms.Label()
        Me.txtREACRESO = New System.Windows.Forms.Label()
        Me.txtREACTIRE = New System.Windows.Forms.Label()
        Me.txtREACVIGE = New System.Windows.Forms.Label()
        Me.txtREACMUNI = New System.Windows.Forms.Label()
        Me.lblREACMUNI = New System.Windows.Forms.Label()
        Me.lblREACTIRE = New System.Windows.Forms.Label()
        Me.lblREACCLSE = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.pbProcesoResolucionActualizacion = New System.Windows.Forms.ProgressBar()
        Me.lblFecha2ResolucionActualizacion = New System.Windows.Forms.Label()
        Me.cmdValidaDatosResolucionActualizacion = New System.Windows.Forms.Button()
        Me.cmdGrabarDatosResolucionActualizacion = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.fraFIPRRESO = New System.Windows.Forms.GroupBox()
        Me.txtREACDEPA = New System.Windows.Forms.Label()
        Me.lblREACDEPA = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.lblREACRESO = New System.Windows.Forms.Label()
        Me.lblTipoResolución = New System.Windows.Forms.Label()
        Me.lblREACVIGE = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblResoMunicipio = New System.Windows.Forms.Label()
        Me.lblVigencia = New System.Windows.Forms.Label()
        Me.fraTablasResolucionActualizacion = New System.Windows.Forms.GroupBox()
        Me.chkCartografiaResolucionActualizacion = New System.Windows.Forms.CheckBox()
        Me.chkLinderoResolucionActualizacion = New System.Windows.Forms.CheckBox()
        Me.chkConstruccionResolucionActualizacion = New System.Windows.Forms.CheckBox()
        Me.chkPropietarioResolucionActualizacion = New System.Windows.Forms.CheckBox()
        Me.chkDestinoEconomicoResolucionActualizacion = New System.Windows.Forms.CheckBox()
        Me.flaovc = New System.Windows.Forms.GroupBox()
        Me.chkInactivasFichasResolucionActualizacion = New System.Windows.Forms.CheckBox()
        Me.chkFichasOVCResolucionActualizacion = New System.Windows.Forms.CheckBox()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabResolucionActualizacion = New System.Windows.Forms.TabPage()
        Me.TabResolucionAdministrativa = New System.Windows.Forms.TabPage()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.rbdInsertaPrediosNuevosResolucionAdministrativa = New System.Windows.Forms.RadioButton()
        Me.rbdActualizarInsertarPrediosResolucionAdministrativa = New System.Windows.Forms.RadioButton()
        Me.chkSobrescribirBDexistenteResolucionAdministrativa = New System.Windows.Forms.CheckBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.chkInsertarMaestrosResolucionAdministrativa = New System.Windows.Forms.CheckBox()
        Me.cmdSeleccionResolucionAdministrativa = New System.Windows.Forms.Button()
        Me.rbdFichaPredialResolucionAdministrativa = New System.Windows.Forms.RadioButton()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.lblAbrirArchivoResolucionAdministrativa = New System.Windows.Forms.Label()
        Me.cmdAbrirArchivoResolucionAdministrativa = New System.Windows.Forms.Button()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.pbProcesoResolucionAdministrativa = New System.Windows.Forms.ProgressBar()
        Me.lblFecha2ResolucionAdministrativa = New System.Windows.Forms.Label()
        Me.cmdValidaDatosResolucionAdministrativa = New System.Windows.Forms.Button()
        Me.cmdGrabarDatosResolucionAdministrativa = New System.Windows.Forms.Button()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.txtREADTIRE = New System.Windows.Forms.Label()
        Me.txtREADCLSE = New System.Windows.Forms.Label()
        Me.lblREADTIRE = New System.Windows.Forms.Label()
        Me.txtREADMUNI = New System.Windows.Forms.Label()
        Me.lblREADMUNI = New System.Windows.Forms.Label()
        Me.txtREADVIGE = New System.Windows.Forms.Label()
        Me.txtREADDEPA = New System.Windows.Forms.Label()
        Me.txtREADRESO = New System.Windows.Forms.Label()
        Me.lblREADDEPA = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblREADCLSE = New System.Windows.Forms.Label()
        Me.lblREADVIGE = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.chkInactivasFichasResolucionAdministrativa = New System.Windows.Forms.CheckBox()
        Me.chkFichasOVCResolucionAdministrativa = New System.Windows.Forms.CheckBox()
        Me.fraTablasResolucionAdminsitrativa = New System.Windows.Forms.GroupBox()
        Me.chkConstruccionResolucionAdministrativa = New System.Windows.Forms.CheckBox()
        Me.chkPropietarioResolucionAdministrativa = New System.Windows.Forms.CheckBox()
        Me.chkDestinoEconomicoResolucionAdministrativa = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvFIPRINCO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvFIREINCO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.fraFIPRRESO.SuspendLayout()
        Me.fraTablasResolucionActualizacion.SuspendLayout()
        Me.flaovc.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabResolucionActualizacion.SuspendLayout()
        Me.TabResolucionAdministrativa.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.fraTablasResolucionAdminsitrativa.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSEPARADOR
        '
        Me.txtSEPARADOR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSEPARADOR.Location = New System.Drawing.Point(277, 18)
        Me.txtSEPARADOR.MaxLength = 1
        Me.txtSEPARADOR.Name = "txtSEPARADOR"
        Me.txtSEPARADOR.Size = New System.Drawing.Size(19, 20)
        Me.txtSEPARADOR.TabIndex = 6
        Me.txtSEPARADOR.Text = "|"
        Me.txtSEPARADOR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdExportarPlano
        '
        Me.cmdExportarPlano.AccessibleDescription = "Exportar plano"
        Me.cmdExportarPlano.AccessibleName = ""
        Me.cmdExportarPlano.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdExportarPlano.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExportarPlano.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExportarPlano.Image = Global.SICAFI.My.Resources.Resources._71
        Me.cmdExportarPlano.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExportarPlano.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdExportarPlano.Location = New System.Drawing.Point(148, 16)
        Me.cmdExportarPlano.Name = "cmdExportarPlano"
        Me.cmdExportarPlano.Size = New System.Drawing.Size(123, 23)
        Me.cmdExportarPlano.TabIndex = 5
        Me.cmdExportarPlano.Text = "&Exportar plano"
        Me.cmdExportarPlano.UseVisualStyleBackColor = False
        '
        'cmdLIMPIAR
        '
        Me.cmdLIMPIAR.AccessibleDescription = "Limpiar campo"
        Me.cmdLIMPIAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLIMPIAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLIMPIAR.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLIMPIAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLIMPIAR.Location = New System.Drawing.Point(302, 16)
        Me.cmdLIMPIAR.Name = "cmdLIMPIAR"
        Me.cmdLIMPIAR.Size = New System.Drawing.Size(123, 23)
        Me.cmdLIMPIAR.TabIndex = 7
        Me.cmdLIMPIAR.Text = "&Limpiar campos"
        Me.cmdLIMPIAR.UseVisualStyleBackColor = True
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
        Me.cmdExportarExcel.Location = New System.Drawing.Point(19, 16)
        Me.cmdExportarExcel.Name = "cmdExportarExcel"
        Me.cmdExportarExcel.Size = New System.Drawing.Size(123, 23)
        Me.cmdExportarExcel.TabIndex = 4
        Me.cmdExportarExcel.Text = "&Exportar excel"
        Me.cmdExportarExcel.UseVisualStyleBackColor = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(716, 18)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(123, 23)
        Me.cmdSALIR.TabIndex = 8
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(21, 408)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(862, 160)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "LISTADO DE INCONSISTENCIAS"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(19, 19)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(825, 126)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvFIPRINCO)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(817, 100)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Ficha Predial"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvFIPRINCO
        '
        Me.dgvFIPRINCO.AccessibleDescription = "Inconsistencias"
        Me.dgvFIPRINCO.AllowUserToAddRows = False
        Me.dgvFIPRINCO.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvFIPRINCO.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvFIPRINCO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFIPRINCO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvFIPRINCO.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvFIPRINCO.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvFIPRINCO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvFIPRINCO.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvFIPRINCO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvFIPRINCO.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvFIPRINCO.Location = New System.Drawing.Point(6, 6)
        Me.dgvFIPRINCO.Name = "dgvFIPRINCO"
        Me.dgvFIPRINCO.ReadOnly = True
        Me.dgvFIPRINCO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvFIPRINCO.ShowCellToolTips = False
        Me.dgvFIPRINCO.Size = New System.Drawing.Size(805, 88)
        Me.dgvFIPRINCO.StandardTab = True
        Me.dgvFIPRINCO.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvFIREINCO)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(817, 126)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Ficha Resumen"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvFIREINCO
        '
        Me.dgvFIREINCO.AccessibleDescription = "Inconsistencias"
        Me.dgvFIREINCO.AllowUserToAddRows = False
        Me.dgvFIREINCO.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvFIREINCO.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvFIREINCO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFIREINCO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvFIREINCO.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvFIREINCO.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvFIREINCO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvFIREINCO.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvFIREINCO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvFIREINCO.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvFIREINCO.Location = New System.Drawing.Point(6, 6)
        Me.dgvFIREINCO.Name = "dgvFIREINCO"
        Me.dgvFIREINCO.ReadOnly = True
        Me.dgvFIREINCO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvFIREINCO.ShowCellToolTips = False
        Me.dgvFIREINCO.Size = New System.Drawing.Size(772, 110)
        Me.dgvFIREINCO.StandardTab = True
        Me.dgvFIREINCO.TabIndex = 3
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 635)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(906, 25)
        Me.strBARRESTA.TabIndex = 46
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
        Me.GroupBox4.Controls.Add(Me.lblAbrirArchivoResolucionActualizacion)
        Me.GroupBox4.Controls.Add(Me.cmdAbrirArchivoResolucionActualizacion)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(19, 68)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(560, 47)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'lblAbrirArchivoResolucionActualizacion
        '
        Me.lblAbrirArchivoResolucionActualizacion.AccessibleDescription = "Ruta archivo"
        Me.lblAbrirArchivoResolucionActualizacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAbrirArchivoResolucionActualizacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblAbrirArchivoResolucionActualizacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAbrirArchivoResolucionActualizacion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbrirArchivoResolucionActualizacion.ForeColor = System.Drawing.Color.Black
        Me.lblAbrirArchivoResolucionActualizacion.Location = New System.Drawing.Point(157, 18)
        Me.lblAbrirArchivoResolucionActualizacion.Name = "lblAbrirArchivoResolucionActualizacion"
        Me.lblAbrirArchivoResolucionActualizacion.Size = New System.Drawing.Size(383, 20)
        Me.lblAbrirArchivoResolucionActualizacion.TabIndex = 356
        '
        'cmdAbrirArchivoResolucionActualizacion
        '
        Me.cmdAbrirArchivoResolucionActualizacion.AccessibleDescription = "Abrir archivo"
        Me.cmdAbrirArchivoResolucionActualizacion.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdAbrirArchivoResolucionActualizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAbrirArchivoResolucionActualizacion.Location = New System.Drawing.Point(19, 16)
        Me.cmdAbrirArchivoResolucionActualizacion.Name = "cmdAbrirArchivoResolucionActualizacion"
        Me.cmdAbrirArchivoResolucionActualizacion.Size = New System.Drawing.Size(123, 23)
        Me.cmdAbrirArchivoResolucionActualizacion.TabIndex = 1
        Me.cmdAbrirArchivoResolucionActualizacion.Text = "Abrir archivo"
        Me.cmdAbrirArchivoResolucionActualizacion.UseVisualStyleBackColor = True
        '
        'rbdFichaResumenResolucionActualizacion
        '
        Me.rbdFichaResumenResolucionActualizacion.AccessibleDescription = "Opción ficha resumen"
        Me.rbdFichaResumenResolucionActualizacion.AutoSize = True
        Me.rbdFichaResumenResolucionActualizacion.Location = New System.Drawing.Point(129, 19)
        Me.rbdFichaResumenResolucionActualizacion.Name = "rbdFichaResumenResolucionActualizacion"
        Me.rbdFichaResumenResolucionActualizacion.Size = New System.Drawing.Size(94, 17)
        Me.rbdFichaResumenResolucionActualizacion.TabIndex = 3
        Me.rbdFichaResumenResolucionActualizacion.Text = "Ficha &resumen"
        Me.rbdFichaResumenResolucionActualizacion.UseVisualStyleBackColor = True
        '
        'rbdFichaPredialResolucionActualizacion
        '
        Me.rbdFichaPredialResolucionActualizacion.AccessibleDescription = "Opción ficha predial"
        Me.rbdFichaPredialResolucionActualizacion.AutoSize = True
        Me.rbdFichaPredialResolucionActualizacion.Checked = True
        Me.rbdFichaPredialResolucionActualizacion.Location = New System.Drawing.Point(23, 19)
        Me.rbdFichaPredialResolucionActualizacion.Name = "rbdFichaPredialResolucionActualizacion"
        Me.rbdFichaPredialResolucionActualizacion.Size = New System.Drawing.Size(85, 17)
        Me.rbdFichaPredialResolucionActualizacion.TabIndex = 2
        Me.rbdFichaPredialResolucionActualizacion.TabStop = True
        Me.rbdFichaPredialResolucionActualizacion.Text = "Ficha &predial"
        Me.rbdFichaPredialResolucionActualizacion.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.GroupBox7)
        Me.GroupBox5.Controls.Add(Me.GroupBox2)
        Me.GroupBox5.Controls.Add(Me.GroupBox4)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(829, 127)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "IMPORTACIÓN DE DATOS"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.rbdInsertaPrediosNuevosResolucionActualizacion)
        Me.GroupBox7.Controls.Add(Me.rbdActualizarInsertarPrediosResolucionActualizacion)
        Me.GroupBox7.Controls.Add(Me.chkSobrescribirBDexistenteResolucionActualizacion)
        Me.GroupBox7.Location = New System.Drawing.Point(585, 15)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(226, 100)
        Me.GroupBox7.TabIndex = 5
        Me.GroupBox7.TabStop = False
        '
        'rbdInsertaPrediosNuevosResolucionActualizacion
        '
        Me.rbdInsertaPrediosNuevosResolucionActualizacion.Location = New System.Drawing.Point(14, 71)
        Me.rbdInsertaPrediosNuevosResolucionActualizacion.Name = "rbdInsertaPrediosNuevosResolucionActualizacion"
        Me.rbdInsertaPrediosNuevosResolucionActualizacion.Size = New System.Drawing.Size(202, 17)
        Me.rbdInsertaPrediosNuevosResolucionActualizacion.TabIndex = 7
        Me.rbdInsertaPrediosNuevosResolucionActualizacion.Text = "Insertar solo predios nuevos"
        Me.rbdInsertaPrediosNuevosResolucionActualizacion.UseVisualStyleBackColor = True
        '
        'rbdActualizarInsertarPrediosResolucionActualizacion
        '
        Me.rbdActualizarInsertarPrediosResolucionActualizacion.Checked = True
        Me.rbdActualizarInsertarPrediosResolucionActualizacion.Location = New System.Drawing.Point(14, 45)
        Me.rbdActualizarInsertarPrediosResolucionActualizacion.Name = "rbdActualizarInsertarPrediosResolucionActualizacion"
        Me.rbdActualizarInsertarPrediosResolucionActualizacion.Size = New System.Drawing.Size(202, 17)
        Me.rbdActualizarInsertarPrediosResolucionActualizacion.TabIndex = 6
        Me.rbdActualizarInsertarPrediosResolucionActualizacion.TabStop = True
        Me.rbdActualizarInsertarPrediosResolucionActualizacion.Text = "Insertar y actualizar predios"
        Me.rbdActualizarInsertarPrediosResolucionActualizacion.UseVisualStyleBackColor = True
        '
        'chkSobrescribirBDexistenteResolucionActualizacion
        '
        Me.chkSobrescribirBDexistenteResolucionActualizacion.Location = New System.Drawing.Point(14, 18)
        Me.chkSobrescribirBDexistenteResolucionActualizacion.Name = "chkSobrescribirBDexistenteResolucionActualizacion"
        Me.chkSobrescribirBDexistenteResolucionActualizacion.Size = New System.Drawing.Size(202, 17)
        Me.chkSobrescribirBDexistenteResolucionActualizacion.TabIndex = 5
        Me.chkSobrescribirBDexistenteResolucionActualizacion.Text = "Sobrescribir base de datos"
        Me.chkSobrescribirBDexistenteResolucionActualizacion.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkInsertarMaestrosResolucionActualizacion)
        Me.GroupBox2.Controls.Add(Me.cmdSeleccionResolucionActualizacion)
        Me.GroupBox2.Controls.Add(Me.rbdFichaResumenResolucionActualizacion)
        Me.GroupBox2.Controls.Add(Me.rbdFichaPredialResolucionActualizacion)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(560, 47)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'chkInsertarMaestrosResolucionActualizacion
        '
        Me.chkInsertarMaestrosResolucionActualizacion.AutoSize = True
        Me.chkInsertarMaestrosResolucionActualizacion.Checked = True
        Me.chkInsertarMaestrosResolucionActualizacion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInsertarMaestrosResolucionActualizacion.Location = New System.Drawing.Point(240, 20)
        Me.chkInsertarMaestrosResolucionActualizacion.Name = "chkInsertarMaestrosResolucionActualizacion"
        Me.chkInsertarMaestrosResolucionActualizacion.Size = New System.Drawing.Size(106, 17)
        Me.chkInsertarMaestrosResolucionActualizacion.TabIndex = 4
        Me.chkInsertarMaestrosResolucionActualizacion.Text = "Insertar maestros"
        Me.chkInsertarMaestrosResolucionActualizacion.UseVisualStyleBackColor = True
        '
        'cmdSeleccionResolucionActualizacion
        '
        Me.cmdSeleccionResolucionActualizacion.AccessibleDescription = "Seleccionar resolución"
        Me.cmdSeleccionResolucionActualizacion.AccessibleName = ""
        Me.cmdSeleccionResolucionActualizacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSeleccionResolucionActualizacion.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSeleccionResolucionActualizacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSeleccionResolucionActualizacion.Image = Global.SICAFI.My.Resources.Resources._1172
        Me.cmdSeleccionResolucionActualizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSeleccionResolucionActualizacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdSeleccionResolucionActualizacion.Location = New System.Drawing.Point(371, 14)
        Me.cmdSeleccionResolucionActualizacion.Name = "cmdSeleccionResolucionActualizacion"
        Me.cmdSeleccionResolucionActualizacion.Size = New System.Drawing.Size(170, 23)
        Me.cmdSeleccionResolucionActualizacion.TabIndex = 2
        Me.cmdSeleccionResolucionActualizacion.Text = "&Seleccionar &resolución"
        Me.cmdSeleccionResolucionActualizacion.UseVisualStyleBackColor = False
        Me.cmdSeleccionResolucionActualizacion.Visible = False
        '
        'txtREACCLSE
        '
        Me.txtREACCLSE.AccessibleDescription = "Clase o sector"
        Me.txtREACCLSE.BackColor = System.Drawing.Color.White
        Me.txtREACCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtREACCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREACCLSE.Location = New System.Drawing.Point(495, 26)
        Me.txtREACCLSE.Name = "txtREACCLSE"
        Me.txtREACCLSE.Size = New System.Drawing.Size(84, 20)
        Me.txtREACCLSE.TabIndex = 367
        Me.txtREACCLSE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtREACRESO
        '
        Me.txtREACRESO.AccessibleDescription = "Resolucion"
        Me.txtREACRESO.BackColor = System.Drawing.Color.White
        Me.txtREACRESO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtREACRESO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREACRESO.Location = New System.Drawing.Point(495, 74)
        Me.txtREACRESO.Name = "txtREACRESO"
        Me.txtREACRESO.Size = New System.Drawing.Size(84, 20)
        Me.txtREACRESO.TabIndex = 366
        Me.txtREACRESO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtREACTIRE
        '
        Me.txtREACTIRE.AccessibleDescription = "Tipo resolucion"
        Me.txtREACTIRE.BackColor = System.Drawing.Color.White
        Me.txtREACTIRE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtREACTIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREACTIRE.Location = New System.Drawing.Point(110, 76)
        Me.txtREACTIRE.Name = "txtREACTIRE"
        Me.txtREACTIRE.Size = New System.Drawing.Size(84, 20)
        Me.txtREACTIRE.TabIndex = 365
        Me.txtREACTIRE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtREACVIGE
        '
        Me.txtREACVIGE.AccessibleDescription = "Vigencia"
        Me.txtREACVIGE.BackColor = System.Drawing.Color.White
        Me.txtREACVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtREACVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREACVIGE.Location = New System.Drawing.Point(495, 50)
        Me.txtREACVIGE.Name = "txtREACVIGE"
        Me.txtREACVIGE.Size = New System.Drawing.Size(84, 20)
        Me.txtREACVIGE.TabIndex = 364
        Me.txtREACVIGE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtREACMUNI
        '
        Me.txtREACMUNI.AccessibleDescription = "Municipio"
        Me.txtREACMUNI.BackColor = System.Drawing.Color.White
        Me.txtREACMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtREACMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREACMUNI.Location = New System.Drawing.Point(110, 52)
        Me.txtREACMUNI.Name = "txtREACMUNI"
        Me.txtREACMUNI.Size = New System.Drawing.Size(84, 20)
        Me.txtREACMUNI.TabIndex = 363
        Me.txtREACMUNI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblREACMUNI
        '
        Me.lblREACMUNI.AccessibleDescription = "Municipio"
        Me.lblREACMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREACMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREACMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREACMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblREACMUNI.Location = New System.Drawing.Point(200, 52)
        Me.lblREACMUNI.Name = "lblREACMUNI"
        Me.lblREACMUNI.Size = New System.Drawing.Size(198, 20)
        Me.lblREACMUNI.TabIndex = 361
        '
        'lblREACTIRE
        '
        Me.lblREACTIRE.AccessibleDescription = "Tipo resolución"
        Me.lblREACTIRE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREACTIRE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREACTIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREACTIRE.ForeColor = System.Drawing.Color.Black
        Me.lblREACTIRE.Location = New System.Drawing.Point(200, 76)
        Me.lblREACTIRE.Name = "lblREACTIRE"
        Me.lblREACTIRE.Size = New System.Drawing.Size(198, 20)
        Me.lblREACTIRE.TabIndex = 359
        '
        'lblREACCLSE
        '
        Me.lblREACCLSE.AccessibleDescription = "Clase o sector"
        Me.lblREACCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREACCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREACCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREACCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblREACCLSE.Location = New System.Drawing.Point(585, 26)
        Me.lblREACCLSE.Name = "lblREACCLSE"
        Me.lblREACCLSE.Size = New System.Drawing.Size(228, 20)
        Me.lblREACCLSE.TabIndex = 357
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.pbProcesoResolucionActualizacion)
        Me.GroupBox6.Controls.Add(Me.lblFecha2ResolucionActualizacion)
        Me.GroupBox6.Controls.Add(Me.cmdValidaDatosResolucionActualizacion)
        Me.GroupBox6.Controls.Add(Me.cmdGrabarDatosResolucionActualizacion)
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(12, 302)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(829, 47)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        '
        'pbProcesoResolucionActualizacion
        '
        Me.pbProcesoResolucionActualizacion.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pbProcesoResolucionActualizacion.Location = New System.Drawing.Point(317, 19)
        Me.pbProcesoResolucionActualizacion.Name = "pbProcesoResolucionActualizacion"
        Me.pbProcesoResolucionActualizacion.Size = New System.Drawing.Size(494, 17)
        Me.pbProcesoResolucionActualizacion.TabIndex = 24
        '
        'lblFecha2ResolucionActualizacion
        '
        Me.lblFecha2ResolucionActualizacion.Image = Global.SICAFI.My.Resources.Resources._834
        Me.lblFecha2ResolucionActualizacion.Location = New System.Drawing.Point(148, 15)
        Me.lblFecha2ResolucionActualizacion.Name = "lblFecha2ResolucionActualizacion"
        Me.lblFecha2ResolucionActualizacion.Size = New System.Drawing.Size(22, 23)
        Me.lblFecha2ResolucionActualizacion.TabIndex = 5
        Me.lblFecha2ResolucionActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblFecha2ResolucionActualizacion.Visible = False
        '
        'cmdValidaDatosResolucionActualizacion
        '
        Me.cmdValidaDatosResolucionActualizacion.AccessibleDescription = "Valida datos"
        Me.cmdValidaDatosResolucionActualizacion.Enabled = False
        Me.cmdValidaDatosResolucionActualizacion.Image = Global.SICAFI.My.Resources.Resources._125
        Me.cmdValidaDatosResolucionActualizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdValidaDatosResolucionActualizacion.Location = New System.Drawing.Point(19, 15)
        Me.cmdValidaDatosResolucionActualizacion.Name = "cmdValidaDatosResolucionActualizacion"
        Me.cmdValidaDatosResolucionActualizacion.Size = New System.Drawing.Size(123, 23)
        Me.cmdValidaDatosResolucionActualizacion.TabIndex = 1
        Me.cmdValidaDatosResolucionActualizacion.Text = "Valida datos"
        Me.cmdValidaDatosResolucionActualizacion.UseVisualStyleBackColor = True
        '
        'cmdGrabarDatosResolucionActualizacion
        '
        Me.cmdGrabarDatosResolucionActualizacion.AccessibleDescription = "Guardar datos"
        Me.cmdGrabarDatosResolucionActualizacion.Enabled = False
        Me.cmdGrabarDatosResolucionActualizacion.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGrabarDatosResolucionActualizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGrabarDatosResolucionActualizacion.Location = New System.Drawing.Point(176, 15)
        Me.cmdGrabarDatosResolucionActualizacion.Name = "cmdGrabarDatosResolucionActualizacion"
        Me.cmdGrabarDatosResolucionActualizacion.Size = New System.Drawing.Size(123, 23)
        Me.cmdGrabarDatosResolucionActualizacion.TabIndex = 2
        Me.cmdGrabarDatosResolucionActualizacion.Text = "Guardar datos"
        Me.cmdGrabarDatosResolucionActualizacion.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cmdLIMPIAR)
        Me.GroupBox3.Controls.Add(Me.cmdSALIR)
        Me.GroupBox3.Controls.Add(Me.txtSEPARADOR)
        Me.GroupBox3.Controls.Add(Me.cmdExportarPlano)
        Me.GroupBox3.Controls.Add(Me.cmdExportarExcel)
        Me.GroupBox3.Location = New System.Drawing.Point(21, 574)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(858, 47)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'fraFIPRRESO
        '
        Me.fraFIPRRESO.BackColor = System.Drawing.SystemColors.Control
        Me.fraFIPRRESO.Controls.Add(Me.txtREACTIRE)
        Me.fraFIPRRESO.Controls.Add(Me.txtREACCLSE)
        Me.fraFIPRRESO.Controls.Add(Me.lblREACTIRE)
        Me.fraFIPRRESO.Controls.Add(Me.txtREACMUNI)
        Me.fraFIPRRESO.Controls.Add(Me.lblREACMUNI)
        Me.fraFIPRRESO.Controls.Add(Me.txtREACVIGE)
        Me.fraFIPRRESO.Controls.Add(Me.txtREACDEPA)
        Me.fraFIPRRESO.Controls.Add(Me.txtREACRESO)
        Me.fraFIPRRESO.Controls.Add(Me.lblREACDEPA)
        Me.fraFIPRRESO.Controls.Add(Me.Label39)
        Me.fraFIPRRESO.Controls.Add(Me.Label62)
        Me.fraFIPRRESO.Controls.Add(Me.lblREACRESO)
        Me.fraFIPRRESO.Controls.Add(Me.lblTipoResolución)
        Me.fraFIPRRESO.Controls.Add(Me.lblREACCLSE)
        Me.fraFIPRRESO.Controls.Add(Me.lblREACVIGE)
        Me.fraFIPRRESO.Controls.Add(Me.Label17)
        Me.fraFIPRRESO.Controls.Add(Me.lblResoMunicipio)
        Me.fraFIPRRESO.Controls.Add(Me.lblVigencia)
        Me.fraFIPRRESO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraFIPRRESO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraFIPRRESO.Location = New System.Drawing.Point(12, 189)
        Me.fraFIPRRESO.Name = "fraFIPRRESO"
        Me.fraFIPRRESO.Size = New System.Drawing.Size(829, 107)
        Me.fraFIPRRESO.TabIndex = 51
        Me.fraFIPRRESO.TabStop = False
        Me.fraFIPRRESO.Text = "DATOS RESOLUCIÓN"
        '
        'txtREACDEPA
        '
        Me.txtREACDEPA.BackColor = System.Drawing.SystemColors.Window
        Me.txtREACDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtREACDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREACDEPA.ForeColor = System.Drawing.Color.Black
        Me.txtREACDEPA.Location = New System.Drawing.Point(110, 27)
        Me.txtREACDEPA.Name = "txtREACDEPA"
        Me.txtREACDEPA.Size = New System.Drawing.Size(84, 20)
        Me.txtREACDEPA.TabIndex = 289
        '
        'lblREACDEPA
        '
        Me.lblREACDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREACDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREACDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREACDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblREACDEPA.Location = New System.Drawing.Point(200, 27)
        Me.lblREACDEPA.Name = "lblREACDEPA"
        Me.lblREACDEPA.Size = New System.Drawing.Size(198, 20)
        Me.lblREACDEPA.TabIndex = 239
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label39.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(19, 27)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(87, 21)
        Me.Label39.TabIndex = 238
        Me.Label39.Text = "Departamento"
        '
        'Label62
        '
        Me.Label62.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label62.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label62.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.Color.Black
        Me.Label62.Location = New System.Drawing.Point(404, 26)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(87, 21)
        Me.Label62.TabIndex = 234
        Me.Label62.Tag = ""
        Me.Label62.Text = "Clase o Sector"
        '
        'lblREACRESO
        '
        Me.lblREACRESO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREACRESO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREACRESO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREACRESO.ForeColor = System.Drawing.Color.Black
        Me.lblREACRESO.Location = New System.Drawing.Point(585, 74)
        Me.lblREACRESO.Name = "lblREACRESO"
        Me.lblREACRESO.Size = New System.Drawing.Size(228, 20)
        Me.lblREACRESO.TabIndex = 233
        '
        'lblTipoResolución
        '
        Me.lblTipoResolución.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblTipoResolución.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoResolución.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoResolución.ForeColor = System.Drawing.Color.Black
        Me.lblTipoResolución.Location = New System.Drawing.Point(404, 74)
        Me.lblTipoResolución.Name = "lblTipoResolución"
        Me.lblTipoResolución.Size = New System.Drawing.Size(87, 21)
        Me.lblTipoResolución.TabIndex = 231
        Me.lblTipoResolución.Text = "Resolución"
        '
        'lblREACVIGE
        '
        Me.lblREACVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREACVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREACVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREACVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblREACVIGE.Location = New System.Drawing.Point(585, 50)
        Me.lblREACVIGE.Name = "lblREACVIGE"
        Me.lblREACVIGE.Size = New System.Drawing.Size(228, 20)
        Me.lblREACVIGE.TabIndex = 230
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(19, 75)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(87, 21)
        Me.Label17.TabIndex = 226
        Me.Label17.Text = "Tipo Resolución"
        '
        'lblResoMunicipio
        '
        Me.lblResoMunicipio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblResoMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblResoMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResoMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblResoMunicipio.Location = New System.Drawing.Point(19, 51)
        Me.lblResoMunicipio.Name = "lblResoMunicipio"
        Me.lblResoMunicipio.Size = New System.Drawing.Size(87, 21)
        Me.lblResoMunicipio.TabIndex = 7
        Me.lblResoMunicipio.Text = "Municipio"
        '
        'lblVigencia
        '
        Me.lblVigencia.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblVigencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVigencia.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVigencia.ForeColor = System.Drawing.Color.Black
        Me.lblVigencia.Location = New System.Drawing.Point(404, 50)
        Me.lblVigencia.Name = "lblVigencia"
        Me.lblVigencia.Size = New System.Drawing.Size(87, 21)
        Me.lblVigencia.TabIndex = 2
        Me.lblVigencia.Text = "Vigencia"
        '
        'fraTablasResolucionActualizacion
        '
        Me.fraTablasResolucionActualizacion.Controls.Add(Me.chkCartografiaResolucionActualizacion)
        Me.fraTablasResolucionActualizacion.Controls.Add(Me.chkLinderoResolucionActualizacion)
        Me.fraTablasResolucionActualizacion.Controls.Add(Me.chkConstruccionResolucionActualizacion)
        Me.fraTablasResolucionActualizacion.Controls.Add(Me.chkPropietarioResolucionActualizacion)
        Me.fraTablasResolucionActualizacion.Controls.Add(Me.chkDestinoEconomicoResolucionActualizacion)
        Me.fraTablasResolucionActualizacion.Location = New System.Drawing.Point(12, 137)
        Me.fraTablasResolucionActualizacion.Name = "fraTablasResolucionActualizacion"
        Me.fraTablasResolucionActualizacion.Size = New System.Drawing.Size(579, 46)
        Me.fraTablasResolucionActualizacion.TabIndex = 6
        Me.fraTablasResolucionActualizacion.TabStop = False
        '
        'chkCartografiaResolucionActualizacion
        '
        Me.chkCartografiaResolucionActualizacion.AutoSize = True
        Me.chkCartografiaResolucionActualizacion.Checked = True
        Me.chkCartografiaResolucionActualizacion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCartografiaResolucionActualizacion.Location = New System.Drawing.Point(482, 19)
        Me.chkCartografiaResolucionActualizacion.Name = "chkCartografiaResolucionActualizacion"
        Me.chkCartografiaResolucionActualizacion.Size = New System.Drawing.Size(77, 17)
        Me.chkCartografiaResolucionActualizacion.TabIndex = 11
        Me.chkCartografiaResolucionActualizacion.Text = "Cartografia"
        Me.chkCartografiaResolucionActualizacion.UseVisualStyleBackColor = True
        '
        'chkLinderoResolucionActualizacion
        '
        Me.chkLinderoResolucionActualizacion.AutoSize = True
        Me.chkLinderoResolucionActualizacion.Checked = True
        Me.chkLinderoResolucionActualizacion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLinderoResolucionActualizacion.Location = New System.Drawing.Point(390, 19)
        Me.chkLinderoResolucionActualizacion.Name = "chkLinderoResolucionActualizacion"
        Me.chkLinderoResolucionActualizacion.Size = New System.Drawing.Size(61, 17)
        Me.chkLinderoResolucionActualizacion.TabIndex = 10
        Me.chkLinderoResolucionActualizacion.Text = "Lindero"
        Me.chkLinderoResolucionActualizacion.UseVisualStyleBackColor = True
        '
        'chkConstruccionResolucionActualizacion
        '
        Me.chkConstruccionResolucionActualizacion.AutoSize = True
        Me.chkConstruccionResolucionActualizacion.Checked = True
        Me.chkConstruccionResolucionActualizacion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkConstruccionResolucionActualizacion.Location = New System.Drawing.Point(277, 19)
        Me.chkConstruccionResolucionActualizacion.Name = "chkConstruccionResolucionActualizacion"
        Me.chkConstruccionResolucionActualizacion.Size = New System.Drawing.Size(88, 17)
        Me.chkConstruccionResolucionActualizacion.TabIndex = 8
        Me.chkConstruccionResolucionActualizacion.Text = "Construcción"
        Me.chkConstruccionResolucionActualizacion.UseVisualStyleBackColor = True
        '
        'chkPropietarioResolucionActualizacion
        '
        Me.chkPropietarioResolucionActualizacion.AutoSize = True
        Me.chkPropietarioResolucionActualizacion.Checked = True
        Me.chkPropietarioResolucionActualizacion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPropietarioResolucionActualizacion.Location = New System.Drawing.Point(166, 19)
        Me.chkPropietarioResolucionActualizacion.Name = "chkPropietarioResolucionActualizacion"
        Me.chkPropietarioResolucionActualizacion.Size = New System.Drawing.Size(76, 17)
        Me.chkPropietarioResolucionActualizacion.TabIndex = 7
        Me.chkPropietarioResolucionActualizacion.Text = "Propietario"
        Me.chkPropietarioResolucionActualizacion.UseVisualStyleBackColor = True
        '
        'chkDestinoEconomicoResolucionActualizacion
        '
        Me.chkDestinoEconomicoResolucionActualizacion.AutoSize = True
        Me.chkDestinoEconomicoResolucionActualizacion.Checked = True
        Me.chkDestinoEconomicoResolucionActualizacion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDestinoEconomicoResolucionActualizacion.Location = New System.Drawing.Point(19, 19)
        Me.chkDestinoEconomicoResolucionActualizacion.Name = "chkDestinoEconomicoResolucionActualizacion"
        Me.chkDestinoEconomicoResolucionActualizacion.Size = New System.Drawing.Size(117, 17)
        Me.chkDestinoEconomicoResolucionActualizacion.TabIndex = 6
        Me.chkDestinoEconomicoResolucionActualizacion.Text = "Destino económico"
        Me.chkDestinoEconomicoResolucionActualizacion.UseVisualStyleBackColor = True
        '
        'flaovc
        '
        Me.flaovc.Controls.Add(Me.chkInactivasFichasResolucionActualizacion)
        Me.flaovc.Controls.Add(Me.chkFichasOVCResolucionActualizacion)
        Me.flaovc.Location = New System.Drawing.Point(597, 137)
        Me.flaovc.Name = "flaovc"
        Me.flaovc.Size = New System.Drawing.Size(243, 46)
        Me.flaovc.TabIndex = 52
        Me.flaovc.TabStop = False
        '
        'chkInactivasFichasResolucionActualizacion
        '
        Me.chkInactivasFichasResolucionActualizacion.AutoSize = True
        Me.chkInactivasFichasResolucionActualizacion.Location = New System.Drawing.Point(136, 19)
        Me.chkInactivasFichasResolucionActualizacion.Name = "chkInactivasFichasResolucionActualizacion"
        Me.chkInactivasFichasResolucionActualizacion.Size = New System.Drawing.Size(100, 17)
        Me.chkInactivasFichasResolucionActualizacion.TabIndex = 7
        Me.chkInactivasFichasResolucionActualizacion.Text = "Inactivas fichas"
        Me.chkInactivasFichasResolucionActualizacion.UseVisualStyleBackColor = True
        '
        'chkFichasOVCResolucionActualizacion
        '
        Me.chkFichasOVCResolucionActualizacion.AutoSize = True
        Me.chkFichasOVCResolucionActualizacion.Checked = True
        Me.chkFichasOVCResolucionActualizacion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFichasOVCResolucionActualizacion.Location = New System.Drawing.Point(13, 19)
        Me.chkFichasOVCResolucionActualizacion.Name = "chkFichasOVCResolucionActualizacion"
        Me.chkFichasOVCResolucionActualizacion.Size = New System.Drawing.Size(117, 17)
        Me.chkFichasOVCResolucionActualizacion.TabIndex = 6
        Me.chkFichasOVCResolucionActualizacion.Text = "Insertar fichas OVC"
        Me.chkFichasOVCResolucionActualizacion.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabResolucionActualizacion)
        Me.TabControl2.Controls.Add(Me.TabResolucionAdministrativa)
        Me.TabControl2.Location = New System.Drawing.Point(21, 12)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(862, 390)
        Me.TabControl2.TabIndex = 53
        '
        'TabResolucionActualizacion
        '
        Me.TabResolucionActualizacion.BackColor = System.Drawing.SystemColors.Control
        Me.TabResolucionActualizacion.Controls.Add(Me.GroupBox5)
        Me.TabResolucionActualizacion.Controls.Add(Me.GroupBox6)
        Me.TabResolucionActualizacion.Controls.Add(Me.fraFIPRRESO)
        Me.TabResolucionActualizacion.Controls.Add(Me.flaovc)
        Me.TabResolucionActualizacion.Controls.Add(Me.fraTablasResolucionActualizacion)
        Me.TabResolucionActualizacion.Location = New System.Drawing.Point(4, 22)
        Me.TabResolucionActualizacion.Name = "TabResolucionActualizacion"
        Me.TabResolucionActualizacion.Padding = New System.Windows.Forms.Padding(3)
        Me.TabResolucionActualizacion.Size = New System.Drawing.Size(854, 364)
        Me.TabResolucionActualizacion.TabIndex = 0
        Me.TabResolucionActualizacion.Text = "Resolución de actualización"
        '
        'TabResolucionAdministrativa
        '
        Me.TabResolucionAdministrativa.BackColor = System.Drawing.SystemColors.Control
        Me.TabResolucionAdministrativa.Controls.Add(Me.GroupBox8)
        Me.TabResolucionAdministrativa.Controls.Add(Me.GroupBox12)
        Me.TabResolucionAdministrativa.Controls.Add(Me.GroupBox13)
        Me.TabResolucionAdministrativa.Controls.Add(Me.GroupBox14)
        Me.TabResolucionAdministrativa.Controls.Add(Me.fraTablasResolucionAdminsitrativa)
        Me.TabResolucionAdministrativa.Location = New System.Drawing.Point(4, 22)
        Me.TabResolucionAdministrativa.Name = "TabResolucionAdministrativa"
        Me.TabResolucionAdministrativa.Padding = New System.Windows.Forms.Padding(3)
        Me.TabResolucionAdministrativa.Size = New System.Drawing.Size(854, 364)
        Me.TabResolucionAdministrativa.TabIndex = 1
        Me.TabResolucionAdministrativa.Text = "Resolución administrativa"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.GroupBox9)
        Me.GroupBox8.Controls.Add(Me.GroupBox10)
        Me.GroupBox8.Controls.Add(Me.GroupBox11)
        Me.GroupBox8.ForeColor = System.Drawing.Color.Black
        Me.GroupBox8.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(829, 127)
        Me.GroupBox8.TabIndex = 53
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "IMPORTACIÓN DE DATOS"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.rbdInsertaPrediosNuevosResolucionAdministrativa)
        Me.GroupBox9.Controls.Add(Me.rbdActualizarInsertarPrediosResolucionAdministrativa)
        Me.GroupBox9.Controls.Add(Me.chkSobrescribirBDexistenteResolucionAdministrativa)
        Me.GroupBox9.Location = New System.Drawing.Point(585, 15)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(226, 100)
        Me.GroupBox9.TabIndex = 5
        Me.GroupBox9.TabStop = False
        '
        'rbdInsertaPrediosNuevosResolucionAdministrativa
        '
        Me.rbdInsertaPrediosNuevosResolucionAdministrativa.Location = New System.Drawing.Point(14, 71)
        Me.rbdInsertaPrediosNuevosResolucionAdministrativa.Name = "rbdInsertaPrediosNuevosResolucionAdministrativa"
        Me.rbdInsertaPrediosNuevosResolucionAdministrativa.Size = New System.Drawing.Size(202, 17)
        Me.rbdInsertaPrediosNuevosResolucionAdministrativa.TabIndex = 7
        Me.rbdInsertaPrediosNuevosResolucionAdministrativa.Text = "Insertar solo predios nuevos"
        Me.rbdInsertaPrediosNuevosResolucionAdministrativa.UseVisualStyleBackColor = True
        '
        'rbdActualizarInsertarPrediosResolucionAdministrativa
        '
        Me.rbdActualizarInsertarPrediosResolucionAdministrativa.Checked = True
        Me.rbdActualizarInsertarPrediosResolucionAdministrativa.Location = New System.Drawing.Point(14, 45)
        Me.rbdActualizarInsertarPrediosResolucionAdministrativa.Name = "rbdActualizarInsertarPrediosResolucionAdministrativa"
        Me.rbdActualizarInsertarPrediosResolucionAdministrativa.Size = New System.Drawing.Size(202, 17)
        Me.rbdActualizarInsertarPrediosResolucionAdministrativa.TabIndex = 6
        Me.rbdActualizarInsertarPrediosResolucionAdministrativa.TabStop = True
        Me.rbdActualizarInsertarPrediosResolucionAdministrativa.Text = "Insertar y actualizar predios"
        Me.rbdActualizarInsertarPrediosResolucionAdministrativa.UseVisualStyleBackColor = True
        '
        'chkSobrescribirBDexistenteResolucionAdministrativa
        '
        Me.chkSobrescribirBDexistenteResolucionAdministrativa.Location = New System.Drawing.Point(14, 18)
        Me.chkSobrescribirBDexistenteResolucionAdministrativa.Name = "chkSobrescribirBDexistenteResolucionAdministrativa"
        Me.chkSobrescribirBDexistenteResolucionAdministrativa.Size = New System.Drawing.Size(202, 17)
        Me.chkSobrescribirBDexistenteResolucionAdministrativa.TabIndex = 5
        Me.chkSobrescribirBDexistenteResolucionAdministrativa.Text = "Sobrescribir base de datos"
        Me.chkSobrescribirBDexistenteResolucionAdministrativa.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.chkInsertarMaestrosResolucionAdministrativa)
        Me.GroupBox10.Controls.Add(Me.cmdSeleccionResolucionAdministrativa)
        Me.GroupBox10.Controls.Add(Me.rbdFichaPredialResolucionAdministrativa)
        Me.GroupBox10.Location = New System.Drawing.Point(19, 15)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(560, 47)
        Me.GroupBox10.TabIndex = 4
        Me.GroupBox10.TabStop = False
        '
        'chkInsertarMaestrosResolucionAdministrativa
        '
        Me.chkInsertarMaestrosResolucionAdministrativa.AutoSize = True
        Me.chkInsertarMaestrosResolucionAdministrativa.Checked = True
        Me.chkInsertarMaestrosResolucionAdministrativa.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInsertarMaestrosResolucionAdministrativa.Location = New System.Drawing.Point(147, 18)
        Me.chkInsertarMaestrosResolucionAdministrativa.Name = "chkInsertarMaestrosResolucionAdministrativa"
        Me.chkInsertarMaestrosResolucionAdministrativa.Size = New System.Drawing.Size(106, 17)
        Me.chkInsertarMaestrosResolucionAdministrativa.TabIndex = 4
        Me.chkInsertarMaestrosResolucionAdministrativa.Text = "Insertar maestros"
        Me.chkInsertarMaestrosResolucionAdministrativa.UseVisualStyleBackColor = True
        '
        'cmdSeleccionResolucionAdministrativa
        '
        Me.cmdSeleccionResolucionAdministrativa.AccessibleDescription = "Seleccionar resolución"
        Me.cmdSeleccionResolucionAdministrativa.AccessibleName = ""
        Me.cmdSeleccionResolucionAdministrativa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSeleccionResolucionAdministrativa.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSeleccionResolucionAdministrativa.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSeleccionResolucionAdministrativa.Image = Global.SICAFI.My.Resources.Resources._1172
        Me.cmdSeleccionResolucionAdministrativa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSeleccionResolucionAdministrativa.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdSeleccionResolucionAdministrativa.Location = New System.Drawing.Point(371, 14)
        Me.cmdSeleccionResolucionAdministrativa.Name = "cmdSeleccionResolucionAdministrativa"
        Me.cmdSeleccionResolucionAdministrativa.Size = New System.Drawing.Size(170, 23)
        Me.cmdSeleccionResolucionAdministrativa.TabIndex = 2
        Me.cmdSeleccionResolucionAdministrativa.Text = "&Seleccionar &resolución"
        Me.cmdSeleccionResolucionAdministrativa.UseVisualStyleBackColor = False
        '
        'rbdFichaPredialResolucionAdministrativa
        '
        Me.rbdFichaPredialResolucionAdministrativa.AccessibleDescription = "Opción ficha predial"
        Me.rbdFichaPredialResolucionAdministrativa.AutoSize = True
        Me.rbdFichaPredialResolucionAdministrativa.Checked = True
        Me.rbdFichaPredialResolucionAdministrativa.Location = New System.Drawing.Point(23, 19)
        Me.rbdFichaPredialResolucionAdministrativa.Name = "rbdFichaPredialResolucionAdministrativa"
        Me.rbdFichaPredialResolucionAdministrativa.Size = New System.Drawing.Size(85, 17)
        Me.rbdFichaPredialResolucionAdministrativa.TabIndex = 2
        Me.rbdFichaPredialResolucionAdministrativa.TabStop = True
        Me.rbdFichaPredialResolucionAdministrativa.Text = "Ficha &predial"
        Me.rbdFichaPredialResolucionAdministrativa.UseVisualStyleBackColor = True
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.lblAbrirArchivoResolucionAdministrativa)
        Me.GroupBox11.Controls.Add(Me.cmdAbrirArchivoResolucionAdministrativa)
        Me.GroupBox11.ForeColor = System.Drawing.Color.Black
        Me.GroupBox11.Location = New System.Drawing.Point(19, 68)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(560, 47)
        Me.GroupBox11.TabIndex = 1
        Me.GroupBox11.TabStop = False
        '
        'lblAbrirArchivoResolucionAdministrativa
        '
        Me.lblAbrirArchivoResolucionAdministrativa.AccessibleDescription = "Ruta archivo"
        Me.lblAbrirArchivoResolucionAdministrativa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAbrirArchivoResolucionAdministrativa.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblAbrirArchivoResolucionAdministrativa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAbrirArchivoResolucionAdministrativa.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbrirArchivoResolucionAdministrativa.ForeColor = System.Drawing.Color.Black
        Me.lblAbrirArchivoResolucionAdministrativa.Location = New System.Drawing.Point(157, 18)
        Me.lblAbrirArchivoResolucionAdministrativa.Name = "lblAbrirArchivoResolucionAdministrativa"
        Me.lblAbrirArchivoResolucionAdministrativa.Size = New System.Drawing.Size(383, 20)
        Me.lblAbrirArchivoResolucionAdministrativa.TabIndex = 356
        '
        'cmdAbrirArchivoResolucionAdministrativa
        '
        Me.cmdAbrirArchivoResolucionAdministrativa.AccessibleDescription = "Abrir archivo"
        Me.cmdAbrirArchivoResolucionAdministrativa.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdAbrirArchivoResolucionAdministrativa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAbrirArchivoResolucionAdministrativa.Location = New System.Drawing.Point(19, 16)
        Me.cmdAbrirArchivoResolucionAdministrativa.Name = "cmdAbrirArchivoResolucionAdministrativa"
        Me.cmdAbrirArchivoResolucionAdministrativa.Size = New System.Drawing.Size(123, 23)
        Me.cmdAbrirArchivoResolucionAdministrativa.TabIndex = 1
        Me.cmdAbrirArchivoResolucionAdministrativa.Text = "Abrir archivo"
        Me.cmdAbrirArchivoResolucionAdministrativa.UseVisualStyleBackColor = True
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.pbProcesoResolucionAdministrativa)
        Me.GroupBox12.Controls.Add(Me.lblFecha2ResolucionAdministrativa)
        Me.GroupBox12.Controls.Add(Me.cmdValidaDatosResolucionAdministrativa)
        Me.GroupBox12.Controls.Add(Me.cmdGrabarDatosResolucionAdministrativa)
        Me.GroupBox12.ForeColor = System.Drawing.Color.Black
        Me.GroupBox12.Location = New System.Drawing.Point(12, 302)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(829, 47)
        Me.GroupBox12.TabIndex = 54
        Me.GroupBox12.TabStop = False
        '
        'pbProcesoResolucionAdministrativa
        '
        Me.pbProcesoResolucionAdministrativa.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pbProcesoResolucionAdministrativa.Location = New System.Drawing.Point(317, 19)
        Me.pbProcesoResolucionAdministrativa.Name = "pbProcesoResolucionAdministrativa"
        Me.pbProcesoResolucionAdministrativa.Size = New System.Drawing.Size(494, 17)
        Me.pbProcesoResolucionAdministrativa.TabIndex = 24
        '
        'lblFecha2ResolucionAdministrativa
        '
        Me.lblFecha2ResolucionAdministrativa.Image = Global.SICAFI.My.Resources.Resources._834
        Me.lblFecha2ResolucionAdministrativa.Location = New System.Drawing.Point(148, 15)
        Me.lblFecha2ResolucionAdministrativa.Name = "lblFecha2ResolucionAdministrativa"
        Me.lblFecha2ResolucionAdministrativa.Size = New System.Drawing.Size(22, 23)
        Me.lblFecha2ResolucionAdministrativa.TabIndex = 5
        Me.lblFecha2ResolucionAdministrativa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblFecha2ResolucionAdministrativa.Visible = False
        '
        'cmdValidaDatosResolucionAdministrativa
        '
        Me.cmdValidaDatosResolucionAdministrativa.AccessibleDescription = "Valida datos"
        Me.cmdValidaDatosResolucionAdministrativa.Enabled = False
        Me.cmdValidaDatosResolucionAdministrativa.Image = Global.SICAFI.My.Resources.Resources._125
        Me.cmdValidaDatosResolucionAdministrativa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdValidaDatosResolucionAdministrativa.Location = New System.Drawing.Point(19, 15)
        Me.cmdValidaDatosResolucionAdministrativa.Name = "cmdValidaDatosResolucionAdministrativa"
        Me.cmdValidaDatosResolucionAdministrativa.Size = New System.Drawing.Size(123, 23)
        Me.cmdValidaDatosResolucionAdministrativa.TabIndex = 1
        Me.cmdValidaDatosResolucionAdministrativa.Text = "Valida datos"
        Me.cmdValidaDatosResolucionAdministrativa.UseVisualStyleBackColor = True
        '
        'cmdGrabarDatosResolucionAdministrativa
        '
        Me.cmdGrabarDatosResolucionAdministrativa.AccessibleDescription = "Guardar datos"
        Me.cmdGrabarDatosResolucionAdministrativa.Enabled = False
        Me.cmdGrabarDatosResolucionAdministrativa.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGrabarDatosResolucionAdministrativa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGrabarDatosResolucionAdministrativa.Location = New System.Drawing.Point(176, 15)
        Me.cmdGrabarDatosResolucionAdministrativa.Name = "cmdGrabarDatosResolucionAdministrativa"
        Me.cmdGrabarDatosResolucionAdministrativa.Size = New System.Drawing.Size(123, 23)
        Me.cmdGrabarDatosResolucionAdministrativa.TabIndex = 2
        Me.cmdGrabarDatosResolucionAdministrativa.Text = "Guardar datos"
        Me.cmdGrabarDatosResolucionAdministrativa.UseVisualStyleBackColor = True
        '
        'GroupBox13
        '
        Me.GroupBox13.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox13.Controls.Add(Me.txtREADTIRE)
        Me.GroupBox13.Controls.Add(Me.txtREADCLSE)
        Me.GroupBox13.Controls.Add(Me.lblREADTIRE)
        Me.GroupBox13.Controls.Add(Me.txtREADMUNI)
        Me.GroupBox13.Controls.Add(Me.lblREADMUNI)
        Me.GroupBox13.Controls.Add(Me.txtREADVIGE)
        Me.GroupBox13.Controls.Add(Me.txtREADDEPA)
        Me.GroupBox13.Controls.Add(Me.txtREADRESO)
        Me.GroupBox13.Controls.Add(Me.lblREADDEPA)
        Me.GroupBox13.Controls.Add(Me.Label10)
        Me.GroupBox13.Controls.Add(Me.Label11)
        Me.GroupBox13.Controls.Add(Me.Label13)
        Me.GroupBox13.Controls.Add(Me.lblREADCLSE)
        Me.GroupBox13.Controls.Add(Me.lblREADVIGE)
        Me.GroupBox13.Controls.Add(Me.Label16)
        Me.GroupBox13.Controls.Add(Me.Label18)
        Me.GroupBox13.Controls.Add(Me.Label19)
        Me.GroupBox13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox13.Location = New System.Drawing.Point(12, 189)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(829, 107)
        Me.GroupBox13.TabIndex = 56
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "DATOS RESOLUCIÓN"
        '
        'txtREADTIRE
        '
        Me.txtREADTIRE.AccessibleDescription = "Tipo resolucion"
        Me.txtREADTIRE.BackColor = System.Drawing.Color.White
        Me.txtREADTIRE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtREADTIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREADTIRE.Location = New System.Drawing.Point(110, 76)
        Me.txtREADTIRE.Name = "txtREADTIRE"
        Me.txtREADTIRE.Size = New System.Drawing.Size(84, 20)
        Me.txtREADTIRE.TabIndex = 383
        Me.txtREADTIRE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtREADCLSE
        '
        Me.txtREADCLSE.AccessibleDescription = "Clase o sector"
        Me.txtREADCLSE.BackColor = System.Drawing.Color.White
        Me.txtREADCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtREADCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREADCLSE.Location = New System.Drawing.Point(495, 26)
        Me.txtREADCLSE.Name = "txtREADCLSE"
        Me.txtREADCLSE.Size = New System.Drawing.Size(84, 20)
        Me.txtREADCLSE.TabIndex = 385
        Me.txtREADCLSE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblREADTIRE
        '
        Me.lblREADTIRE.AccessibleDescription = "Tipo resolución"
        Me.lblREADTIRE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREADTIRE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREADTIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREADTIRE.ForeColor = System.Drawing.Color.Black
        Me.lblREADTIRE.Location = New System.Drawing.Point(200, 76)
        Me.lblREADTIRE.Name = "lblREADTIRE"
        Me.lblREADTIRE.Size = New System.Drawing.Size(198, 20)
        Me.lblREADTIRE.TabIndex = 379
        '
        'txtREADMUNI
        '
        Me.txtREADMUNI.AccessibleDescription = "Municipio"
        Me.txtREADMUNI.BackColor = System.Drawing.Color.White
        Me.txtREADMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtREADMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREADMUNI.Location = New System.Drawing.Point(110, 52)
        Me.txtREADMUNI.Name = "txtREADMUNI"
        Me.txtREADMUNI.Size = New System.Drawing.Size(84, 20)
        Me.txtREADMUNI.TabIndex = 381
        Me.txtREADMUNI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblREADMUNI
        '
        Me.lblREADMUNI.AccessibleDescription = "Municipio"
        Me.lblREADMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREADMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREADMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREADMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblREADMUNI.Location = New System.Drawing.Point(200, 52)
        Me.lblREADMUNI.Name = "lblREADMUNI"
        Me.lblREADMUNI.Size = New System.Drawing.Size(198, 20)
        Me.lblREADMUNI.TabIndex = 380
        '
        'txtREADVIGE
        '
        Me.txtREADVIGE.AccessibleDescription = "Vigencia"
        Me.txtREADVIGE.BackColor = System.Drawing.Color.White
        Me.txtREADVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtREADVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREADVIGE.Location = New System.Drawing.Point(495, 50)
        Me.txtREADVIGE.Name = "txtREADVIGE"
        Me.txtREADVIGE.Size = New System.Drawing.Size(84, 20)
        Me.txtREADVIGE.TabIndex = 382
        Me.txtREADVIGE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtREADDEPA
        '
        Me.txtREADDEPA.BackColor = System.Drawing.SystemColors.Window
        Me.txtREADDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtREADDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREADDEPA.ForeColor = System.Drawing.Color.Black
        Me.txtREADDEPA.Location = New System.Drawing.Point(110, 27)
        Me.txtREADDEPA.Name = "txtREADDEPA"
        Me.txtREADDEPA.Size = New System.Drawing.Size(84, 20)
        Me.txtREADDEPA.TabIndex = 377
        '
        'txtREADRESO
        '
        Me.txtREADRESO.AccessibleDescription = "Resolucion"
        Me.txtREADRESO.BackColor = System.Drawing.Color.White
        Me.txtREADRESO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtREADRESO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREADRESO.Location = New System.Drawing.Point(495, 74)
        Me.txtREADRESO.Name = "txtREADRESO"
        Me.txtREADRESO.Size = New System.Drawing.Size(318, 20)
        Me.txtREADRESO.TabIndex = 384
        Me.txtREADRESO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblREADDEPA
        '
        Me.lblREADDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREADDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREADDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREADDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblREADDEPA.Location = New System.Drawing.Point(200, 27)
        Me.lblREADDEPA.Name = "lblREADDEPA"
        Me.lblREADDEPA.Size = New System.Drawing.Size(198, 20)
        Me.lblREADDEPA.TabIndex = 376
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(19, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 21)
        Me.Label10.TabIndex = 375
        Me.Label10.Text = "Departamento"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(404, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 21)
        Me.Label11.TabIndex = 374
        Me.Label11.Tag = ""
        Me.Label11.Text = "Clase o Sector"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(404, 74)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 21)
        Me.Label13.TabIndex = 372
        Me.Label13.Text = "Resolución"
        '
        'lblREADCLSE
        '
        Me.lblREADCLSE.AccessibleDescription = "Clase o sector"
        Me.lblREADCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREADCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREADCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREADCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblREADCLSE.Location = New System.Drawing.Point(585, 26)
        Me.lblREADCLSE.Name = "lblREADCLSE"
        Me.lblREADCLSE.Size = New System.Drawing.Size(228, 20)
        Me.lblREADCLSE.TabIndex = 378
        '
        'lblREADVIGE
        '
        Me.lblREADVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREADVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREADVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREADVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblREADVIGE.Location = New System.Drawing.Point(585, 50)
        Me.lblREADVIGE.Name = "lblREADVIGE"
        Me.lblREADVIGE.Size = New System.Drawing.Size(228, 20)
        Me.lblREADVIGE.TabIndex = 371
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(19, 75)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 21)
        Me.Label16.TabIndex = 370
        Me.Label16.Text = "Tipo Resolución"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(19, 51)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(87, 21)
        Me.Label18.TabIndex = 369
        Me.Label18.Text = "Municipio"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(404, 50)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(87, 21)
        Me.Label19.TabIndex = 368
        Me.Label19.Text = "Vigencia"
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.chkInactivasFichasResolucionAdministrativa)
        Me.GroupBox14.Controls.Add(Me.chkFichasOVCResolucionAdministrativa)
        Me.GroupBox14.Location = New System.Drawing.Point(597, 137)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(249, 46)
        Me.GroupBox14.TabIndex = 57
        Me.GroupBox14.TabStop = False
        '
        'chkInactivasFichasResolucionAdministrativa
        '
        Me.chkInactivasFichasResolucionAdministrativa.AutoSize = True
        Me.chkInactivasFichasResolucionAdministrativa.Location = New System.Drawing.Point(136, 19)
        Me.chkInactivasFichasResolucionAdministrativa.Name = "chkInactivasFichasResolucionAdministrativa"
        Me.chkInactivasFichasResolucionAdministrativa.Size = New System.Drawing.Size(100, 17)
        Me.chkInactivasFichasResolucionAdministrativa.TabIndex = 7
        Me.chkInactivasFichasResolucionAdministrativa.Text = "Inactivas fichas"
        Me.chkInactivasFichasResolucionAdministrativa.UseVisualStyleBackColor = True
        '
        'chkFichasOVCResolucionAdministrativa
        '
        Me.chkFichasOVCResolucionAdministrativa.AutoSize = True
        Me.chkFichasOVCResolucionAdministrativa.Checked = True
        Me.chkFichasOVCResolucionAdministrativa.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFichasOVCResolucionAdministrativa.Location = New System.Drawing.Point(13, 19)
        Me.chkFichasOVCResolucionAdministrativa.Name = "chkFichasOVCResolucionAdministrativa"
        Me.chkFichasOVCResolucionAdministrativa.Size = New System.Drawing.Size(117, 17)
        Me.chkFichasOVCResolucionAdministrativa.TabIndex = 6
        Me.chkFichasOVCResolucionAdministrativa.Text = "Insertar fichas OVC"
        Me.chkFichasOVCResolucionAdministrativa.UseVisualStyleBackColor = True
        '
        'fraTablasResolucionAdminsitrativa
        '
        Me.fraTablasResolucionAdminsitrativa.Controls.Add(Me.chkConstruccionResolucionAdministrativa)
        Me.fraTablasResolucionAdminsitrativa.Controls.Add(Me.chkPropietarioResolucionAdministrativa)
        Me.fraTablasResolucionAdminsitrativa.Controls.Add(Me.chkDestinoEconomicoResolucionAdministrativa)
        Me.fraTablasResolucionAdminsitrativa.Location = New System.Drawing.Point(12, 137)
        Me.fraTablasResolucionAdminsitrativa.Name = "fraTablasResolucionAdminsitrativa"
        Me.fraTablasResolucionAdminsitrativa.Size = New System.Drawing.Size(579, 46)
        Me.fraTablasResolucionAdminsitrativa.TabIndex = 55
        Me.fraTablasResolucionAdminsitrativa.TabStop = False
        '
        'chkConstruccionResolucionAdministrativa
        '
        Me.chkConstruccionResolucionAdministrativa.AutoSize = True
        Me.chkConstruccionResolucionAdministrativa.Checked = True
        Me.chkConstruccionResolucionAdministrativa.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkConstruccionResolucionAdministrativa.Location = New System.Drawing.Point(277, 19)
        Me.chkConstruccionResolucionAdministrativa.Name = "chkConstruccionResolucionAdministrativa"
        Me.chkConstruccionResolucionAdministrativa.Size = New System.Drawing.Size(88, 17)
        Me.chkConstruccionResolucionAdministrativa.TabIndex = 8
        Me.chkConstruccionResolucionAdministrativa.Text = "Construcción"
        Me.chkConstruccionResolucionAdministrativa.UseVisualStyleBackColor = True
        '
        'chkPropietarioResolucionAdministrativa
        '
        Me.chkPropietarioResolucionAdministrativa.AutoSize = True
        Me.chkPropietarioResolucionAdministrativa.Checked = True
        Me.chkPropietarioResolucionAdministrativa.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPropietarioResolucionAdministrativa.Location = New System.Drawing.Point(166, 19)
        Me.chkPropietarioResolucionAdministrativa.Name = "chkPropietarioResolucionAdministrativa"
        Me.chkPropietarioResolucionAdministrativa.Size = New System.Drawing.Size(76, 17)
        Me.chkPropietarioResolucionAdministrativa.TabIndex = 7
        Me.chkPropietarioResolucionAdministrativa.Text = "Propietario"
        Me.chkPropietarioResolucionAdministrativa.UseVisualStyleBackColor = True
        '
        'chkDestinoEconomicoResolucionAdministrativa
        '
        Me.chkDestinoEconomicoResolucionAdministrativa.AutoSize = True
        Me.chkDestinoEconomicoResolucionAdministrativa.Checked = True
        Me.chkDestinoEconomicoResolucionAdministrativa.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDestinoEconomicoResolucionAdministrativa.Location = New System.Drawing.Point(19, 19)
        Me.chkDestinoEconomicoResolucionAdministrativa.Name = "chkDestinoEconomicoResolucionAdministrativa"
        Me.chkDestinoEconomicoResolucionAdministrativa.Size = New System.Drawing.Size(117, 17)
        Me.chkDestinoEconomicoResolucionAdministrativa.TabIndex = 6
        Me.chkDestinoEconomicoResolucionAdministrativa.Text = "Destino económico"
        Me.chkDestinoEconomicoResolucionAdministrativa.UseVisualStyleBackColor = True
        '
        'frm_importar_planos_FICHA_PREDIAL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 660)
        Me.Controls.Add(Me.TabControl2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_importar_planos_FICHA_PREDIAL"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "IMPORTAR PLANOS FICHA PREDIAL Y RESUMEN"
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvFIPRINCO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvFIREINCO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.fraFIPRRESO.ResumeLayout(False)
        Me.fraTablasResolucionActualizacion.ResumeLayout(False)
        Me.fraTablasResolucionActualizacion.PerformLayout()
        Me.flaovc.ResumeLayout(False)
        Me.flaovc.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabResolucionActualizacion.ResumeLayout(False)
        Me.TabResolucionAdministrativa.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.fraTablasResolucionAdminsitrativa.ResumeLayout(False)
        Me.fraTablasResolucionAdminsitrativa.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtSEPARADOR As System.Windows.Forms.TextBox
    Friend WithEvents cmdExportarPlano As System.Windows.Forms.Button
    Friend WithEvents cmdExportarExcel As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvFIPRINCO As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmdLIMPIAR As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvFIREINCO As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdFichaResumenResolucionActualizacion As System.Windows.Forms.RadioButton
    Friend WithEvents rbdFichaPredialResolucionActualizacion As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAbrirArchivoResolucionActualizacion As System.Windows.Forms.Button
    Friend WithEvents lblAbrirArchivoResolucionActualizacion As System.Windows.Forms.Label
    Friend WithEvents cmdGrabarDatosResolucionActualizacion As System.Windows.Forms.Button
    Friend WithEvents cmdValidaDatosResolucionActualizacion As System.Windows.Forms.Button
    Friend WithEvents lblFecha2ResolucionActualizacion As System.Windows.Forms.Label
    Friend WithEvents pbProcesoResolucionActualizacion As System.Windows.Forms.ProgressBar
    Friend WithEvents lblREACCLSE As System.Windows.Forms.Label
    Friend WithEvents lblREACTIRE As System.Windows.Forms.Label
    Friend WithEvents lblREACMUNI As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtREACMUNI As System.Windows.Forms.Label
    Friend WithEvents txtREACCLSE As System.Windows.Forms.Label
    Friend WithEvents txtREACRESO As System.Windows.Forms.Label
    Friend WithEvents txtREACTIRE As System.Windows.Forms.Label
    Friend WithEvents txtREACVIGE As System.Windows.Forms.Label
    Friend WithEvents fraFIPRRESO As System.Windows.Forms.GroupBox
    Friend WithEvents txtREACDEPA As System.Windows.Forms.Label
    Friend WithEvents lblREACDEPA As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents lblTipoResolución As System.Windows.Forms.Label
    Friend WithEvents lblREACVIGE As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblResoMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblVigencia As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSeleccionResolucionActualizacion As System.Windows.Forms.Button
    Friend WithEvents chkInsertarMaestrosResolucionActualizacion As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents chkSobrescribirBDexistenteResolucionActualizacion As System.Windows.Forms.CheckBox
    Friend WithEvents rbdInsertaPrediosNuevosResolucionActualizacion As System.Windows.Forms.RadioButton
    Friend WithEvents rbdActualizarInsertarPrediosResolucionActualizacion As System.Windows.Forms.RadioButton
    Friend WithEvents fraTablasResolucionActualizacion As System.Windows.Forms.GroupBox
    Friend WithEvents chkCartografiaResolucionActualizacion As System.Windows.Forms.CheckBox
    Friend WithEvents chkLinderoResolucionActualizacion As System.Windows.Forms.CheckBox
    Friend WithEvents chkConstruccionResolucionActualizacion As System.Windows.Forms.CheckBox
    Friend WithEvents chkPropietarioResolucionActualizacion As System.Windows.Forms.CheckBox
    Friend WithEvents chkDestinoEconomicoResolucionActualizacion As System.Windows.Forms.CheckBox
    Friend WithEvents flaovc As System.Windows.Forms.GroupBox
    Friend WithEvents chkFichasOVCResolucionActualizacion As System.Windows.Forms.CheckBox
    Friend WithEvents chkInactivasFichasResolucionActualizacion As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabResolucionActualizacion As System.Windows.Forms.TabPage
    Friend WithEvents TabResolucionAdministrativa As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdInsertaPrediosNuevosResolucionAdministrativa As System.Windows.Forms.RadioButton
    Friend WithEvents rbdActualizarInsertarPrediosResolucionAdministrativa As System.Windows.Forms.RadioButton
    Friend WithEvents chkSobrescribirBDexistenteResolucionAdministrativa As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents chkInsertarMaestrosResolucionAdministrativa As System.Windows.Forms.CheckBox
    Friend WithEvents cmdSeleccionResolucionAdministrativa As System.Windows.Forms.Button
    Friend WithEvents rbdFichaPredialResolucionAdministrativa As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents lblAbrirArchivoResolucionAdministrativa As System.Windows.Forms.Label
    Friend WithEvents cmdAbrirArchivoResolucionAdministrativa As System.Windows.Forms.Button
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents pbProcesoResolucionAdministrativa As System.Windows.Forms.ProgressBar
    Friend WithEvents lblFecha2ResolucionAdministrativa As System.Windows.Forms.Label
    Friend WithEvents cmdValidaDatosResolucionAdministrativa As System.Windows.Forms.Button
    Friend WithEvents cmdGrabarDatosResolucionAdministrativa As System.Windows.Forms.Button
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents chkInactivasFichasResolucionAdministrativa As System.Windows.Forms.CheckBox
    Friend WithEvents chkFichasOVCResolucionAdministrativa As System.Windows.Forms.CheckBox
    Friend WithEvents fraTablasResolucionAdminsitrativa As System.Windows.Forms.GroupBox
    Friend WithEvents chkConstruccionResolucionAdministrativa As System.Windows.Forms.CheckBox
    Friend WithEvents chkPropietarioResolucionAdministrativa As System.Windows.Forms.CheckBox
    Friend WithEvents chkDestinoEconomicoResolucionAdministrativa As System.Windows.Forms.CheckBox
    Friend WithEvents txtREADTIRE As System.Windows.Forms.Label
    Friend WithEvents txtREADCLSE As System.Windows.Forms.Label
    Friend WithEvents lblREADTIRE As System.Windows.Forms.Label
    Friend WithEvents txtREADMUNI As System.Windows.Forms.Label
    Friend WithEvents lblREADMUNI As System.Windows.Forms.Label
    Friend WithEvents txtREADVIGE As System.Windows.Forms.Label
    Friend WithEvents txtREADDEPA As System.Windows.Forms.Label
    Friend WithEvents txtREADRESO As System.Windows.Forms.Label
    Friend WithEvents lblREADDEPA As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblREADCLSE As System.Windows.Forms.Label
    Friend WithEvents lblREADVIGE As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblREACRESO As System.Windows.Forms.Label
End Class
