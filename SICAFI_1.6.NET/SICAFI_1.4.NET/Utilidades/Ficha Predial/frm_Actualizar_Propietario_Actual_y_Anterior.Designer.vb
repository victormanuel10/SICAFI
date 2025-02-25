<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Actualizar_Propietario_Actual_y_Anterior
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
        Me.fraFIPRRESO = New System.Windows.Forms.GroupBox()
        Me.txtRESOTIRE = New System.Windows.Forms.Label()
        Me.txtRESOCLSE = New System.Windows.Forms.Label()
        Me.lblRESOTIRE = New System.Windows.Forms.Label()
        Me.txtRESOMUNI = New System.Windows.Forms.Label()
        Me.lblRESOMUNI = New System.Windows.Forms.Label()
        Me.txtRESOVIGE = New System.Windows.Forms.Label()
        Me.txtRESODEPA = New System.Windows.Forms.Label()
        Me.txtRESOCODI = New System.Windows.Forms.Label()
        Me.lblRESODEPA = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.lblRESODESC = New System.Windows.Forms.Label()
        Me.lblTipoResolución = New System.Windows.Forms.Label()
        Me.lblRESOCLSE = New System.Windows.Forms.Label()
        Me.lblRESOVIGE = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblResoMunicipio = New System.Windows.Forms.Label()
        Me.lblVigencia = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.pbPROCESO = New System.Windows.Forms.ProgressBar()
        Me.lblFecha2 = New System.Windows.Forms.Label()
        Me.cmdValidaDatos = New System.Windows.Forms.Button()
        Me.cmdGrabarDatos = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lblRUTA = New System.Windows.Forms.Label()
        Me.cmdAbrirArchivo = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdLIMPIAR = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.txtSEPARADOR = New System.Windows.Forms.TextBox()
        Me.cmdExportarPlano = New System.Windows.Forms.Button()
        Me.cmdExportarExcel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvFIPRINCO = New System.Windows.Forms.DataGridView()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblVIACVIAC = New System.Windows.Forms.Label()
        Me.cboVIACVIAC = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblPRANCAAC = New System.Windows.Forms.Label()
        Me.cboPRANCAAC = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fraFIPRRESO.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvFIPRINCO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraFIPRRESO
        '
        Me.fraFIPRRESO.BackColor = System.Drawing.SystemColors.Control
        Me.fraFIPRRESO.Controls.Add(Me.txtRESOTIRE)
        Me.fraFIPRRESO.Controls.Add(Me.txtRESOCLSE)
        Me.fraFIPRRESO.Controls.Add(Me.lblRESOTIRE)
        Me.fraFIPRRESO.Controls.Add(Me.txtRESOMUNI)
        Me.fraFIPRRESO.Controls.Add(Me.lblRESOMUNI)
        Me.fraFIPRRESO.Controls.Add(Me.txtRESOVIGE)
        Me.fraFIPRRESO.Controls.Add(Me.txtRESODEPA)
        Me.fraFIPRRESO.Controls.Add(Me.txtRESOCODI)
        Me.fraFIPRRESO.Controls.Add(Me.lblRESODEPA)
        Me.fraFIPRRESO.Controls.Add(Me.Label39)
        Me.fraFIPRRESO.Controls.Add(Me.Label62)
        Me.fraFIPRRESO.Controls.Add(Me.lblRESODESC)
        Me.fraFIPRRESO.Controls.Add(Me.lblTipoResolución)
        Me.fraFIPRRESO.Controls.Add(Me.lblRESOCLSE)
        Me.fraFIPRRESO.Controls.Add(Me.lblRESOVIGE)
        Me.fraFIPRRESO.Controls.Add(Me.Label17)
        Me.fraFIPRRESO.Controls.Add(Me.lblResoMunicipio)
        Me.fraFIPRRESO.Controls.Add(Me.lblVigencia)
        Me.fraFIPRRESO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraFIPRRESO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraFIPRRESO.Location = New System.Drawing.Point(21, 137)
        Me.fraFIPRRESO.Name = "fraFIPRRESO"
        Me.fraFIPRRESO.Size = New System.Drawing.Size(829, 107)
        Me.fraFIPRRESO.TabIndex = 58
        Me.fraFIPRRESO.TabStop = False
        Me.fraFIPRRESO.Text = "RESOLUCIÓN"
        '
        'txtRESOTIRE
        '
        Me.txtRESOTIRE.AccessibleDescription = "Tipo resolucion"
        Me.txtRESOTIRE.BackColor = System.Drawing.Color.White
        Me.txtRESOTIRE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRESOTIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRESOTIRE.Location = New System.Drawing.Point(110, 76)
        Me.txtRESOTIRE.Name = "txtRESOTIRE"
        Me.txtRESOTIRE.Size = New System.Drawing.Size(84, 20)
        Me.txtRESOTIRE.TabIndex = 365
        Me.txtRESOTIRE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRESOCLSE
        '
        Me.txtRESOCLSE.AccessibleDescription = "Clase o sector"
        Me.txtRESOCLSE.BackColor = System.Drawing.Color.White
        Me.txtRESOCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRESOCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRESOCLSE.Location = New System.Drawing.Point(495, 26)
        Me.txtRESOCLSE.Name = "txtRESOCLSE"
        Me.txtRESOCLSE.Size = New System.Drawing.Size(84, 20)
        Me.txtRESOCLSE.TabIndex = 367
        Me.txtRESOCLSE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRESOTIRE
        '
        Me.lblRESOTIRE.AccessibleDescription = "Tipo resolución"
        Me.lblRESOTIRE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOTIRE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOTIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOTIRE.ForeColor = System.Drawing.Color.Black
        Me.lblRESOTIRE.Location = New System.Drawing.Point(200, 76)
        Me.lblRESOTIRE.Name = "lblRESOTIRE"
        Me.lblRESOTIRE.Size = New System.Drawing.Size(198, 20)
        Me.lblRESOTIRE.TabIndex = 359
        '
        'txtRESOMUNI
        '
        Me.txtRESOMUNI.AccessibleDescription = "Municipio"
        Me.txtRESOMUNI.BackColor = System.Drawing.Color.White
        Me.txtRESOMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRESOMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRESOMUNI.Location = New System.Drawing.Point(110, 52)
        Me.txtRESOMUNI.Name = "txtRESOMUNI"
        Me.txtRESOMUNI.Size = New System.Drawing.Size(84, 20)
        Me.txtRESOMUNI.TabIndex = 363
        Me.txtRESOMUNI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRESOMUNI
        '
        Me.lblRESOMUNI.AccessibleDescription = "Municipio"
        Me.lblRESOMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblRESOMUNI.Location = New System.Drawing.Point(200, 52)
        Me.lblRESOMUNI.Name = "lblRESOMUNI"
        Me.lblRESOMUNI.Size = New System.Drawing.Size(198, 20)
        Me.lblRESOMUNI.TabIndex = 361
        '
        'txtRESOVIGE
        '
        Me.txtRESOVIGE.AccessibleDescription = "Vigencia"
        Me.txtRESOVIGE.BackColor = System.Drawing.Color.White
        Me.txtRESOVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRESOVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRESOVIGE.Location = New System.Drawing.Point(495, 50)
        Me.txtRESOVIGE.Name = "txtRESOVIGE"
        Me.txtRESOVIGE.Size = New System.Drawing.Size(84, 20)
        Me.txtRESOVIGE.TabIndex = 364
        Me.txtRESOVIGE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRESODEPA
        '
        Me.txtRESODEPA.BackColor = System.Drawing.SystemColors.Window
        Me.txtRESODEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRESODEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRESODEPA.ForeColor = System.Drawing.Color.Black
        Me.txtRESODEPA.Location = New System.Drawing.Point(110, 27)
        Me.txtRESODEPA.Name = "txtRESODEPA"
        Me.txtRESODEPA.Size = New System.Drawing.Size(84, 20)
        Me.txtRESODEPA.TabIndex = 289
        '
        'txtRESOCODI
        '
        Me.txtRESOCODI.AccessibleDescription = "Resolucion"
        Me.txtRESOCODI.BackColor = System.Drawing.Color.White
        Me.txtRESOCODI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRESOCODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRESOCODI.Location = New System.Drawing.Point(495, 74)
        Me.txtRESOCODI.Name = "txtRESOCODI"
        Me.txtRESOCODI.Size = New System.Drawing.Size(84, 20)
        Me.txtRESOCODI.TabIndex = 366
        Me.txtRESOCODI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRESODEPA
        '
        Me.lblRESODEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESODEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESODEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESODEPA.ForeColor = System.Drawing.Color.Black
        Me.lblRESODEPA.Location = New System.Drawing.Point(200, 27)
        Me.lblRESODEPA.Name = "lblRESODEPA"
        Me.lblRESODEPA.Size = New System.Drawing.Size(198, 20)
        Me.lblRESODEPA.TabIndex = 239
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
        'lblRESODESC
        '
        Me.lblRESODESC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESODESC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESODESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESODESC.ForeColor = System.Drawing.Color.Black
        Me.lblRESODESC.Location = New System.Drawing.Point(585, 74)
        Me.lblRESODESC.Name = "lblRESODESC"
        Me.lblRESODESC.Size = New System.Drawing.Size(228, 20)
        Me.lblRESODESC.TabIndex = 233
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
        'lblRESOCLSE
        '
        Me.lblRESOCLSE.AccessibleDescription = "Clase o sector"
        Me.lblRESOCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblRESOCLSE.Location = New System.Drawing.Point(585, 26)
        Me.lblRESOCLSE.Name = "lblRESOCLSE"
        Me.lblRESOCLSE.Size = New System.Drawing.Size(228, 20)
        Me.lblRESOCLSE.TabIndex = 357
        '
        'lblRESOVIGE
        '
        Me.lblRESOVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblRESOVIGE.Location = New System.Drawing.Point(585, 50)
        Me.lblRESOVIGE.Name = "lblRESOVIGE"
        Me.lblRESOVIGE.Size = New System.Drawing.Size(228, 20)
        Me.lblRESOVIGE.TabIndex = 230
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
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.pbPROCESO)
        Me.GroupBox6.Controls.Add(Me.lblFecha2)
        Me.GroupBox6.Controls.Add(Me.cmdValidaDatos)
        Me.GroupBox6.Controls.Add(Me.cmdGrabarDatos)
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(21, 250)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(829, 47)
        Me.GroupBox6.TabIndex = 54
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
        'lblFecha2
        '
        Me.lblFecha2.Image = Global.SICAFI.My.Resources.Resources._834
        Me.lblFecha2.Location = New System.Drawing.Point(148, 15)
        Me.lblFecha2.Name = "lblFecha2"
        Me.lblFecha2.Size = New System.Drawing.Size(22, 23)
        Me.lblFecha2.TabIndex = 5
        Me.lblFecha2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblFecha2.Visible = False
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
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblRUTA)
        Me.GroupBox5.Controls.Add(Me.cmdAbrirArchivo)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(21, 11)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(829, 57)
        Me.GroupBox5.TabIndex = 52
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "IMPORTACIÓN DE DATOS"
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
        Me.lblRUTA.Location = New System.Drawing.Point(200, 24)
        Me.lblRUTA.Name = "lblRUTA"
        Me.lblRUTA.Size = New System.Drawing.Size(613, 20)
        Me.lblRUTA.TabIndex = 356
        '
        'cmdAbrirArchivo
        '
        Me.cmdAbrirArchivo.AccessibleDescription = "Abrir archivo"
        Me.cmdAbrirArchivo.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdAbrirArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAbrirArchivo.Location = New System.Drawing.Point(19, 22)
        Me.cmdAbrirArchivo.Name = "cmdAbrirArchivo"
        Me.cmdAbrirArchivo.Size = New System.Drawing.Size(175, 23)
        Me.cmdAbrirArchivo.TabIndex = 1
        Me.cmdAbrirArchivo.Text = "Abrir archivo"
        Me.cmdAbrirArchivo.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cmdLIMPIAR)
        Me.GroupBox3.Controls.Add(Me.cmdSALIR)
        Me.GroupBox3.Controls.Add(Me.txtSEPARADOR)
        Me.GroupBox3.Controls.Add(Me.cmdExportarPlano)
        Me.GroupBox3.Controls.Add(Me.cmdExportarExcel)
        Me.GroupBox3.Location = New System.Drawing.Point(21, 493)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(829, 47)
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
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(21, 303)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(829, 184)
        Me.GroupBox1.TabIndex = 53
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
        Me.TabControl1.Size = New System.Drawing.Size(792, 150)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvFIPRINCO)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(784, 124)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Ficha Predial"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvFIPRINCO
        '
        Me.dgvFIPRINCO.AccessibleDescription = "Inconsistencias"
        Me.dgvFIPRINCO.AllowUserToAddRows = False
        Me.dgvFIPRINCO.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvFIPRINCO.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFIPRINCO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFIPRINCO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvFIPRINCO.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvFIPRINCO.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvFIPRINCO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvFIPRINCO.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFIPRINCO.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvFIPRINCO.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFIPRINCO.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvFIPRINCO.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvFIPRINCO.Location = New System.Drawing.Point(6, 6)
        Me.dgvFIPRINCO.Name = "dgvFIPRINCO"
        Me.dgvFIPRINCO.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFIPRINCO.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvFIPRINCO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvFIPRINCO.ShowCellToolTips = False
        Me.dgvFIPRINCO.Size = New System.Drawing.Size(772, 112)
        Me.dgvFIPRINCO.StandardTab = True
        Me.dgvFIPRINCO.TabIndex = 1
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 555)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(867, 25)
        Me.strBARRESTA.TabIndex = 57
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
        Me.GroupBox2.Controls.Add(Me.lblVIACVIAC)
        Me.GroupBox2.Controls.Add(Me.cboVIACVIAC)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.lblPRANCAAC)
        Me.GroupBox2.Controls.Add(Me.cboPRANCAAC)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(21, 74)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(829, 57)
        Me.GroupBox2.TabIndex = 59
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PARAMETROS"
        '
        'lblVIACVIAC
        '
        Me.lblVIACVIAC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblVIACVIAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVIACVIAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVIACVIAC.ForeColor = System.Drawing.Color.Black
        Me.lblVIACVIAC.Location = New System.Drawing.Point(839, 22)
        Me.lblVIACVIAC.Name = "lblVIACVIAC"
        Me.lblVIACVIAC.Size = New System.Drawing.Size(120, 20)
        Me.lblVIACVIAC.TabIndex = 244
        '
        'cboVIACVIAC
        '
        Me.cboVIACVIAC.AccessibleDescription = "Vigencia actualización"
        Me.cboVIACVIAC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboVIACVIAC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVIACVIAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVIACVIAC.FormattingEnabled = True
        Me.cboVIACVIAC.Location = New System.Drawing.Point(585, 21)
        Me.cboVIACVIAC.Name = "cboVIACVIAC"
        Me.cboVIACVIAC.Size = New System.Drawing.Size(228, 22)
        Me.cboVIACVIAC.TabIndex = 242
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(404, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(175, 20)
        Me.Label6.TabIndex = 243
        Me.Label6.Text = "Vigencia de la fecha de escritura"
        '
        'lblPRANCAAC
        '
        Me.lblPRANCAAC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPRANCAAC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPRANCAAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPRANCAAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPRANCAAC.ForeColor = System.Drawing.Color.Black
        Me.lblPRANCAAC.Location = New System.Drawing.Point(200, 22)
        Me.lblPRANCAAC.Name = "lblPRANCAAC"
        Me.lblPRANCAAC.Size = New System.Drawing.Size(198, 20)
        Me.lblPRANCAAC.TabIndex = 241
        '
        'cboPRANCAAC
        '
        Me.cboPRANCAAC.AccessibleDescription = "Causa del acto"
        Me.cboPRANCAAC.BackColor = System.Drawing.Color.White
        Me.cboPRANCAAC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPRANCAAC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPRANCAAC.Location = New System.Drawing.Point(110, 22)
        Me.cboPRANCAAC.MaxLength = 50
        Me.cboPRANCAAC.Name = "cboPRANCAAC"
        Me.cboPRANCAAC.Size = New System.Drawing.Size(84, 21)
        Me.cboPRANCAAC.TabIndex = 240
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 21)
        Me.Label1.TabIndex = 239
        Me.Label1.Text = "Causa del acto"
        '
        'frm_Actualizar_Propietario_Actual_y_Anterior
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 580)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.fraFIPRRESO)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_Actualizar_Propietario_Actual_y_Anterior"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ACTUALIZAR PROPIETARIO ACTUAL Y ANTERIOR"
        Me.fraFIPRRESO.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvFIPRINCO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraFIPRRESO As System.Windows.Forms.GroupBox
    Friend WithEvents txtRESOTIRE As System.Windows.Forms.Label
    Friend WithEvents txtRESOCLSE As System.Windows.Forms.Label
    Friend WithEvents lblRESOTIRE As System.Windows.Forms.Label
    Friend WithEvents txtRESOMUNI As System.Windows.Forms.Label
    Friend WithEvents lblRESOMUNI As System.Windows.Forms.Label
    Friend WithEvents txtRESOVIGE As System.Windows.Forms.Label
    Friend WithEvents txtRESODEPA As System.Windows.Forms.Label
    Friend WithEvents txtRESOCODI As System.Windows.Forms.Label
    Friend WithEvents lblRESODEPA As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents lblRESODESC As System.Windows.Forms.Label
    Friend WithEvents lblTipoResolución As System.Windows.Forms.Label
    Friend WithEvents lblRESOCLSE As System.Windows.Forms.Label
    Friend WithEvents lblRESOVIGE As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblResoMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblVigencia As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents pbPROCESO As System.Windows.Forms.ProgressBar
    Friend WithEvents lblFecha2 As System.Windows.Forms.Label
    Friend WithEvents cmdValidaDatos As System.Windows.Forms.Button
    Friend WithEvents cmdGrabarDatos As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRUTA As System.Windows.Forms.Label
    Friend WithEvents cmdAbrirArchivo As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLIMPIAR As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents txtSEPARADOR As System.Windows.Forms.TextBox
    Friend WithEvents cmdExportarPlano As System.Windows.Forms.Button
    Friend WithEvents cmdExportarExcel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvFIPRINCO As System.Windows.Forms.DataGridView
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPRANCAAC As System.Windows.Forms.Label
    Friend WithEvents cboPRANCAAC As System.Windows.Forms.ComboBox
    Friend WithEvents lblVIACVIAC As System.Windows.Forms.Label
    Friend WithEvents cboVIACVIAC As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
