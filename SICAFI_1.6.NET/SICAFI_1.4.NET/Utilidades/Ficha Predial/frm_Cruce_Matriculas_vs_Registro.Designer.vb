<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Cruce_Matriculas_vs_Registro
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.rbdArchivoXML = New System.Windows.Forms.RadioButton
        Me.rbdArchivoEstructurado = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lblRUTA = New System.Windows.Forms.Label
        Me.cmdAbrirArchivo = New System.Windows.Forms.Button
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.pbPROCESO = New System.Windows.Forms.ProgressBar
        Me.lblFlecha2 = New System.Windows.Forms.Label
        Me.cmdValidaDatos = New System.Windows.Forms.Button
        Me.cmdGrabarDatos = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dgvCONSULTA = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblMATRCLSE = New System.Windows.Forms.Label
        Me.cboMATRCLSE = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblMATRDEPA = New System.Windows.Forms.Label
        Me.cboMATRDEPA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblMATRMUNI = New System.Windows.Forms.Label
        Me.cboMATRMUNI = New System.Windows.Forms.ComboBox
        Me.lblMUNICIPIO = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdListadoDePrediosConMatricula = New System.Windows.Forms.Button
        Me.cmdCruceRegistroVsMunicipio = New System.Windows.Forms.Button
        Me.cmdCruceMunicipioVsRegistro = New System.Windows.Forms.Button
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.cmdLIMPIAR = New System.Windows.Forms.Button
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.txtSEPARADOR = New System.Windows.Forms.TextBox
        Me.cmdExportarPlano = New System.Windows.Forms.Button
        Me.cmdExportarExcel = New System.Windows.Forms.Button
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.GroupBox8)
        Me.GroupBox5.Controls.Add(Me.GroupBox4)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(829, 134)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "IMPORTACIÓN DE DATOS"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.rbdArchivoXML)
        Me.GroupBox8.Controls.Add(Me.rbdArchivoEstructurado)
        Me.GroupBox8.Location = New System.Drawing.Point(15, 72)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(796, 47)
        Me.GroupBox8.TabIndex = 2
        Me.GroupBox8.TabStop = False
        '
        'rbdArchivoXML
        '
        Me.rbdArchivoXML.AutoSize = True
        Me.rbdArchivoXML.Checked = True
        Me.rbdArchivoXML.Location = New System.Drawing.Point(27, 17)
        Me.rbdArchivoXML.Name = "rbdArchivoXML"
        Me.rbdArchivoXML.Size = New System.Drawing.Size(86, 17)
        Me.rbdArchivoXML.TabIndex = 1
        Me.rbdArchivoXML.TabStop = True
        Me.rbdArchivoXML.Text = "Archivo XML"
        Me.rbdArchivoXML.UseVisualStyleBackColor = True
        '
        'rbdArchivoEstructurado
        '
        Me.rbdArchivoEstructurado.AutoSize = True
        Me.rbdArchivoEstructurado.Location = New System.Drawing.Point(154, 18)
        Me.rbdArchivoEstructurado.Name = "rbdArchivoEstructurado"
        Me.rbdArchivoEstructurado.Size = New System.Drawing.Size(123, 17)
        Me.rbdArchivoEstructurado.TabIndex = 0
        Me.rbdArchivoEstructurado.Text = "Archivo estructurado"
        Me.rbdArchivoEstructurado.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblRUTA)
        Me.GroupBox4.Controls.Add(Me.cmdAbrirArchivo)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(15, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(796, 47)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'lblRUTA
        '
        Me.lblRUTA.AccessibleDescription = "Ruta archivo"
        Me.lblRUTA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRUTA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUTA.ForeColor = System.Drawing.Color.Black
        Me.lblRUTA.Location = New System.Drawing.Point(157, 18)
        Me.lblRUTA.Name = "lblRUTA"
        Me.lblRUTA.Size = New System.Drawing.Size(619, 20)
        Me.lblRUTA.TabIndex = 356
        '
        'cmdAbrirArchivo
        '
        Me.cmdAbrirArchivo.AccessibleDescription = "Abrir archivo"
        Me.cmdAbrirArchivo.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdAbrirArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAbrirArchivo.Location = New System.Drawing.Point(19, 16)
        Me.cmdAbrirArchivo.Name = "cmdAbrirArchivo"
        Me.cmdAbrirArchivo.Size = New System.Drawing.Size(123, 23)
        Me.cmdAbrirArchivo.TabIndex = 1
        Me.cmdAbrirArchivo.Text = "Abrir archivo"
        Me.cmdAbrirArchivo.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 579)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(856, 25)
        Me.strBARRESTA.TabIndex = 47
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
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.pbPROCESO)
        Me.GroupBox6.Controls.Add(Me.lblFlecha2)
        Me.GroupBox6.Controls.Add(Me.cmdValidaDatos)
        Me.GroupBox6.Controls.Add(Me.cmdGrabarDatos)
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(12, 271)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(829, 47)
        Me.GroupBox6.TabIndex = 49
        Me.GroupBox6.TabStop = False
        '
        'pbPROCESO
        '
        Me.pbPROCESO.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pbPROCESO.Location = New System.Drawing.Point(317, 19)
        Me.pbPROCESO.Name = "pbPROCESO"
        Me.pbPROCESO.Size = New System.Drawing.Size(494, 17)
        Me.pbPROCESO.TabIndex = 24
        '
        'lblFlecha2
        '
        Me.lblFlecha2.Image = Global.SICAFI.My.Resources.Resources._834
        Me.lblFlecha2.Location = New System.Drawing.Point(148, 15)
        Me.lblFlecha2.Name = "lblFlecha2"
        Me.lblFlecha2.Size = New System.Drawing.Size(22, 23)
        Me.lblFlecha2.TabIndex = 5
        Me.lblFlecha2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblFlecha2.Visible = False
        '
        'cmdValidaDatos
        '
        Me.cmdValidaDatos.AccessibleDescription = "Valida datos"
        Me.cmdValidaDatos.Enabled = False
        Me.cmdValidaDatos.Image = Global.SICAFI.My.Resources.Resources._125
        Me.cmdValidaDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdValidaDatos.Location = New System.Drawing.Point(19, 15)
        Me.cmdValidaDatos.Name = "cmdValidaDatos"
        Me.cmdValidaDatos.Size = New System.Drawing.Size(123, 23)
        Me.cmdValidaDatos.TabIndex = 1
        Me.cmdValidaDatos.Text = "Valida datos"
        Me.cmdValidaDatos.UseVisualStyleBackColor = True
        '
        'cmdGrabarDatos
        '
        Me.cmdGrabarDatos.AccessibleDescription = "Guardar datos"
        Me.cmdGrabarDatos.Enabled = False
        Me.cmdGrabarDatos.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGrabarDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGrabarDatos.Location = New System.Drawing.Point(176, 15)
        Me.cmdGrabarDatos.Name = "cmdGrabarDatos"
        Me.cmdGrabarDatos.Size = New System.Drawing.Size(123, 23)
        Me.cmdGrabarDatos.TabIndex = 2
        Me.cmdGrabarDatos.Text = "Guardar datos"
        Me.cmdGrabarDatos.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 324)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(829, 190)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CONSULTA"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(19, 19)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(792, 156)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvCONSULTA)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(784, 130)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Ficha Predial"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvCONSULTA
        '
        Me.dgvCONSULTA.AccessibleDescription = "Consulta"
        Me.dgvCONSULTA.AllowUserToAddRows = False
        Me.dgvCONSULTA.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCONSULTA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCONSULTA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCONSULTA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCONSULTA.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCONSULTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCONSULTA.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvCONSULTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCONSULTA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA.Location = New System.Drawing.Point(6, 6)
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(772, 118)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblMATRCLSE)
        Me.GroupBox2.Controls.Add(Me.cboMATRCLSE)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblMATRDEPA)
        Me.GroupBox2.Controls.Add(Me.cboMATRDEPA)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lblMATRMUNI)
        Me.GroupBox2.Controls.Add(Me.cboMATRMUNI)
        Me.GroupBox2.Controls.Add(Me.lblMUNICIPIO)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(12, 152)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(481, 113)
        Me.GroupBox2.TabIndex = 50
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "SELECCIÓN DEL DEPARTAMENTO - MUNICIPIO"
        '
        'lblMATRCLSE
        '
        Me.lblMATRCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblMATRCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMATRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMATRCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblMATRCLSE.Location = New System.Drawing.Point(252, 69)
        Me.lblMATRCLSE.Name = "lblMATRCLSE"
        Me.lblMATRCLSE.Size = New System.Drawing.Size(214, 20)
        Me.lblMATRCLSE.TabIndex = 67
        '
        'cboMATRCLSE
        '
        Me.cboMATRCLSE.AccessibleDescription = "Clase o sector"
        Me.cboMATRCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMATRCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMATRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMATRCLSE.FormattingEnabled = True
        Me.cboMATRCLSE.Location = New System.Drawing.Point(133, 67)
        Me.cboMATRCLSE.Name = "cboMATRCLSE"
        Me.cboMATRCLSE.Size = New System.Drawing.Size(112, 22)
        Me.cboMATRCLSE.TabIndex = 65
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(15, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Clase o sector"
        '
        'lblMATRDEPA
        '
        Me.lblMATRDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblMATRDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMATRDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMATRDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblMATRDEPA.Location = New System.Drawing.Point(252, 23)
        Me.lblMATRDEPA.Name = "lblMATRDEPA"
        Me.lblMATRDEPA.Size = New System.Drawing.Size(214, 20)
        Me.lblMATRDEPA.TabIndex = 64
        '
        'cboMATRDEPA
        '
        Me.cboMATRDEPA.AccessibleDescription = "Departamento"
        Me.cboMATRDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMATRDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMATRDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMATRDEPA.FormattingEnabled = True
        Me.cboMATRDEPA.Location = New System.Drawing.Point(133, 21)
        Me.cboMATRDEPA.Name = "cboMATRDEPA"
        Me.cboMATRDEPA.Size = New System.Drawing.Size(112, 22)
        Me.cboMATRDEPA.TabIndex = 58
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(15, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 20)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "Departamento"
        '
        'lblMATRMUNI
        '
        Me.lblMATRMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblMATRMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMATRMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMATRMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblMATRMUNI.Location = New System.Drawing.Point(252, 46)
        Me.lblMATRMUNI.Name = "lblMATRMUNI"
        Me.lblMATRMUNI.Size = New System.Drawing.Size(214, 20)
        Me.lblMATRMUNI.TabIndex = 62
        '
        'cboMATRMUNI
        '
        Me.cboMATRMUNI.AccessibleDescription = "Municipio"
        Me.cboMATRMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMATRMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMATRMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMATRMUNI.FormattingEnabled = True
        Me.cboMATRMUNI.Location = New System.Drawing.Point(133, 44)
        Me.cboMATRMUNI.Name = "cboMATRMUNI"
        Me.cboMATRMUNI.Size = New System.Drawing.Size(112, 22)
        Me.cboMATRMUNI.TabIndex = 59
        '
        'lblMUNICIPIO
        '
        Me.lblMUNICIPIO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMUNICIPIO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUNICIPIO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUNICIPIO.ForeColor = System.Drawing.Color.Black
        Me.lblMUNICIPIO.Location = New System.Drawing.Point(15, 46)
        Me.lblMUNICIPIO.Name = "lblMUNICIPIO"
        Me.lblMUNICIPIO.Size = New System.Drawing.Size(112, 20)
        Me.lblMUNICIPIO.TabIndex = 61
        Me.lblMUNICIPIO.Text = "Municipio"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdListadoDePrediosConMatricula)
        Me.GroupBox3.Controls.Add(Me.cmdCruceRegistroVsMunicipio)
        Me.GroupBox3.Controls.Add(Me.cmdCruceMunicipioVsRegistro)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(499, 152)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(342, 113)
        Me.GroupBox3.TabIndex = 51
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "PROCESOS"
        '
        'cmdListadoDePrediosConMatricula
        '
        Me.cmdListadoDePrediosConMatricula.AccessibleDescription = "Listado de predios con matriculas"
        Me.cmdListadoDePrediosConMatricula.AccessibleName = ""
        Me.cmdListadoDePrediosConMatricula.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdListadoDePrediosConMatricula.BackColor = System.Drawing.SystemColors.Control
        Me.cmdListadoDePrediosConMatricula.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdListadoDePrediosConMatricula.Image = Global.SICAFI.My.Resources.Resources._1172
        Me.cmdListadoDePrediosConMatricula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdListadoDePrediosConMatricula.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdListadoDePrediosConMatricula.Location = New System.Drawing.Point(15, 76)
        Me.cmdListadoDePrediosConMatricula.Name = "cmdListadoDePrediosConMatricula"
        Me.cmdListadoDePrediosConMatricula.Size = New System.Drawing.Size(305, 23)
        Me.cmdListadoDePrediosConMatricula.TabIndex = 5
        Me.cmdListadoDePrediosConMatricula.Text = "&Listado de predios con matricula"
        Me.cmdListadoDePrediosConMatricula.UseVisualStyleBackColor = False
        '
        'cmdCruceRegistroVsMunicipio
        '
        Me.cmdCruceRegistroVsMunicipio.AccessibleDescription = "Cruce registro vs municipio"
        Me.cmdCruceRegistroVsMunicipio.AccessibleName = ""
        Me.cmdCruceRegistroVsMunicipio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCruceRegistroVsMunicipio.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCruceRegistroVsMunicipio.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCruceRegistroVsMunicipio.Image = Global.SICAFI.My.Resources.Resources._1172
        Me.cmdCruceRegistroVsMunicipio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCruceRegistroVsMunicipio.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCruceRegistroVsMunicipio.Location = New System.Drawing.Point(15, 48)
        Me.cmdCruceRegistroVsMunicipio.Name = "cmdCruceRegistroVsMunicipio"
        Me.cmdCruceRegistroVsMunicipio.Size = New System.Drawing.Size(305, 23)
        Me.cmdCruceRegistroVsMunicipio.TabIndex = 4
        Me.cmdCruceRegistroVsMunicipio.Text = "Cruce &Registro vs Municipio"
        Me.cmdCruceRegistroVsMunicipio.UseVisualStyleBackColor = False
        '
        'cmdCruceMunicipioVsRegistro
        '
        Me.cmdCruceMunicipioVsRegistro.AccessibleDescription = "Cruce Municipio Vs Registro"
        Me.cmdCruceMunicipioVsRegistro.AccessibleName = ""
        Me.cmdCruceMunicipioVsRegistro.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCruceMunicipioVsRegistro.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCruceMunicipioVsRegistro.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCruceMunicipioVsRegistro.Image = Global.SICAFI.My.Resources.Resources._1172
        Me.cmdCruceMunicipioVsRegistro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCruceMunicipioVsRegistro.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCruceMunicipioVsRegistro.Location = New System.Drawing.Point(15, 19)
        Me.cmdCruceMunicipioVsRegistro.Name = "cmdCruceMunicipioVsRegistro"
        Me.cmdCruceMunicipioVsRegistro.Size = New System.Drawing.Size(305, 23)
        Me.cmdCruceMunicipioVsRegistro.TabIndex = 3
        Me.cmdCruceMunicipioVsRegistro.Text = "Cruce &Municipio vs Registro"
        Me.cmdCruceMunicipioVsRegistro.UseVisualStyleBackColor = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.cmdLIMPIAR)
        Me.GroupBox7.Controls.Add(Me.cmdSALIR)
        Me.GroupBox7.Controls.Add(Me.txtSEPARADOR)
        Me.GroupBox7.Controls.Add(Me.cmdExportarPlano)
        Me.GroupBox7.Controls.Add(Me.cmdExportarExcel)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 520)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(829, 47)
        Me.GroupBox7.TabIndex = 52
        Me.GroupBox7.TabStop = False
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
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(688, 16)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(123, 23)
        Me.cmdSALIR.TabIndex = 8
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
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
        'frm_Cruce_Matriculas_vs_Registro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 604)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox5)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_Cruce_Matriculas_vs_Registro"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CRUCE DE MATRICULAS MUNICIPIO VS REGISTRO"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRUTA As System.Windows.Forms.Label
    Friend WithEvents cmdAbrirArchivo As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents pbPROCESO As System.Windows.Forms.ProgressBar
    Friend WithEvents lblFlecha2 As System.Windows.Forms.Label
    Friend WithEvents cmdValidaDatos As System.Windows.Forms.Button
    Friend WithEvents cmdGrabarDatos As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMATRDEPA As System.Windows.Forms.Label
    Friend WithEvents cboMATRDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblMATRMUNI As System.Windows.Forms.Label
    Friend WithEvents cboMATRMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdListadoDePrediosConMatricula As System.Windows.Forms.Button
    Friend WithEvents cmdCruceRegistroVsMunicipio As System.Windows.Forms.Button
    Friend WithEvents cmdCruceMunicipioVsRegistro As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLIMPIAR As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents txtSEPARADOR As System.Windows.Forms.TextBox
    Friend WithEvents cmdExportarPlano As System.Windows.Forms.Button
    Friend WithEvents cmdExportarExcel As System.Windows.Forms.Button
    Friend WithEvents lblMATRCLSE As System.Windows.Forms.Label
    Friend WithEvents cboMATRCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdArchivoXML As System.Windows.Forms.RadioButton
    Friend WithEvents rbdArchivoEstructurado As System.Windows.Forms.RadioButton
End Class
