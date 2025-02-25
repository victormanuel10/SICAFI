<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_importar_planos_ZONAS
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.chkEliminarZonasExistentes = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblRUTA = New System.Windows.Forms.Label()
        Me.cmdAbrirArchivo = New System.Windows.Forms.Button()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.txtRESOCLSE = New System.Windows.Forms.Label()
        Me.txtRESOVIGE = New System.Windows.Forms.Label()
        Me.txtRESOMUNI = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblRESOMUNI = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblRESOVIGE = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblRESOCLSE = New System.Windows.Forms.Label()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.pbPROCESO = New System.Windows.Forms.ProgressBar()
        Me.lblFecha2 = New System.Windows.Forms.Label()
        Me.cmdValidaDatos = New System.Windows.Forms.Button()
        Me.cmdGrabarDatos = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbdZonaFisica = New System.Windows.Forms.RadioButton()
        Me.rbdZonaEconomica = New System.Windows.Forms.RadioButton()
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvFIPRINCO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.GroupBox7)
        Me.GroupBox5.Controls.Add(Me.GroupBox2)
        Me.GroupBox5.Controls.Add(Me.GroupBox11)
        Me.GroupBox5.Controls.Add(Me.GroupBox6)
        Me.GroupBox5.Controls.Add(Me.GroupBox4)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(21, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(831, 265)
        Me.GroupBox5.TabIndex = 47
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "IMPORTACIÓN DE DATOS"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.chkEliminarZonasExistentes)
        Me.GroupBox7.ForeColor = System.Drawing.Color.Black
        Me.GroupBox7.Location = New System.Drawing.Point(641, 19)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(172, 47)
        Me.GroupBox7.TabIndex = 6
        Me.GroupBox7.TabStop = False
        '
        'chkEliminarZonasExistentes
        '
        Me.chkEliminarZonasExistentes.Checked = True
        Me.chkEliminarZonasExistentes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEliminarZonasExistentes.Location = New System.Drawing.Point(16, 19)
        Me.chkEliminarZonasExistentes.Name = "chkEliminarZonasExistentes"
        Me.chkEliminarZonasExistentes.Size = New System.Drawing.Size(150, 17)
        Me.chkEliminarZonasExistentes.TabIndex = 0
        Me.chkEliminarZonasExistentes.Text = "Eliminar zonas existentes"
        Me.chkEliminarZonasExistentes.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblRUTA)
        Me.GroupBox2.Controls.Add(Me.cmdAbrirArchivo)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(19, 72)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(794, 47)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'lblRUTA
        '
        Me.lblRUTA.AccessibleDescription = "Ruta archivo"
        Me.lblRUTA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUTA.ForeColor = System.Drawing.Color.Black
        Me.lblRUTA.Location = New System.Drawing.Point(162, 19)
        Me.lblRUTA.Name = "lblRUTA"
        Me.lblRUTA.Size = New System.Drawing.Size(613, 20)
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
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.txtRESOCLSE)
        Me.GroupBox11.Controls.Add(Me.txtRESOVIGE)
        Me.GroupBox11.Controls.Add(Me.txtRESOMUNI)
        Me.GroupBox11.Controls.Add(Me.Label3)
        Me.GroupBox11.Controls.Add(Me.lblRESOMUNI)
        Me.GroupBox11.Controls.Add(Me.Label1)
        Me.GroupBox11.Controls.Add(Me.lblRESOVIGE)
        Me.GroupBox11.Controls.Add(Me.Label2)
        Me.GroupBox11.Controls.Add(Me.lblRESOCLSE)
        Me.GroupBox11.Controls.Add(Me.lblPredio)
        Me.GroupBox11.Controls.Add(Me.lblCorregimiento)
        Me.GroupBox11.Controls.Add(Me.lblMunicipio)
        Me.GroupBox11.Location = New System.Drawing.Point(19, 125)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(794, 73)
        Me.GroupBox11.TabIndex = 4
        Me.GroupBox11.TabStop = False
        '
        'txtRESOCLSE
        '
        Me.txtRESOCLSE.AccessibleDescription = "Clase o sector"
        Me.txtRESOCLSE.BackColor = System.Drawing.Color.White
        Me.txtRESOCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRESOCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRESOCLSE.Location = New System.Drawing.Point(534, 39)
        Me.txtRESOCLSE.Name = "txtRESOCLSE"
        Me.txtRESOCLSE.Size = New System.Drawing.Size(84, 20)
        Me.txtRESOCLSE.TabIndex = 367
        Me.txtRESOCLSE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRESOVIGE
        '
        Me.txtRESOVIGE.AccessibleDescription = "Vigencia"
        Me.txtRESOVIGE.BackColor = System.Drawing.Color.White
        Me.txtRESOVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRESOVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRESOVIGE.Location = New System.Drawing.Point(280, 39)
        Me.txtRESOVIGE.Name = "txtRESOVIGE"
        Me.txtRESOVIGE.Size = New System.Drawing.Size(84, 20)
        Me.txtRESOVIGE.TabIndex = 364
        Me.txtRESOVIGE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRESOMUNI
        '
        Me.txtRESOMUNI.AccessibleDescription = "Municipio"
        Me.txtRESOMUNI.BackColor = System.Drawing.Color.White
        Me.txtRESOMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRESOMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRESOMUNI.Location = New System.Drawing.Point(19, 39)
        Me.txtRESOMUNI.Name = "txtRESOMUNI"
        Me.txtRESOMUNI.Size = New System.Drawing.Size(84, 20)
        Me.txtRESOMUNI.TabIndex = 363
        Me.txtRESOMUNI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(107, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(170, 20)
        Me.Label3.TabIndex = 362
        Me.Label3.Text = "Descripción"
        '
        'lblRESOMUNI
        '
        Me.lblRESOMUNI.AccessibleDescription = "Municipio"
        Me.lblRESOMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblRESOMUNI.Location = New System.Drawing.Point(107, 39)
        Me.lblRESOMUNI.Name = "lblRESOMUNI"
        Me.lblRESOMUNI.Size = New System.Drawing.Size(170, 20)
        Me.lblRESOMUNI.TabIndex = 361
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(368, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 20)
        Me.Label1.TabIndex = 360
        Me.Label1.Text = "Descripción"
        '
        'lblRESOVIGE
        '
        Me.lblRESOVIGE.AccessibleDescription = "Vigencia"
        Me.lblRESOVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblRESOVIGE.Location = New System.Drawing.Point(368, 39)
        Me.lblRESOVIGE.Name = "lblRESOVIGE"
        Me.lblRESOVIGE.Size = New System.Drawing.Size(162, 20)
        Me.lblRESOVIGE.TabIndex = 359
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(622, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 20)
        Me.Label2.TabIndex = 358
        Me.Label2.Text = "Descripción"
        '
        'lblRESOCLSE
        '
        Me.lblRESOCLSE.AccessibleDescription = "Clase o sector"
        Me.lblRESOCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblRESOCLSE.Location = New System.Drawing.Point(622, 39)
        Me.lblRESOCLSE.Name = "lblRESOCLSE"
        Me.lblRESOCLSE.Size = New System.Drawing.Size(153, 20)
        Me.lblRESOCLSE.TabIndex = 357
        '
        'lblPredio
        '
        Me.lblPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredio.ForeColor = System.Drawing.Color.Black
        Me.lblPredio.Location = New System.Drawing.Point(534, 16)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(84, 20)
        Me.lblPredio.TabIndex = 308
        Me.lblPredio.Text = "Clase o Sector"
        '
        'lblCorregimiento
        '
        Me.lblCorregimiento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCorregimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorregimiento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorregimiento.ForeColor = System.Drawing.Color.Black
        Me.lblCorregimiento.Location = New System.Drawing.Point(280, 16)
        Me.lblCorregimiento.Name = "lblCorregimiento"
        Me.lblCorregimiento.Size = New System.Drawing.Size(84, 20)
        Me.lblCorregimiento.TabIndex = 310
        Me.lblCorregimiento.Text = "Vigencia"
        '
        'lblMunicipio
        '
        Me.lblMunicipio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblMunicipio.Location = New System.Drawing.Point(19, 16)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(84, 20)
        Me.lblMunicipio.TabIndex = 312
        Me.lblMunicipio.Text = "Municipio"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.pbPROCESO)
        Me.GroupBox6.Controls.Add(Me.lblFecha2)
        Me.GroupBox6.Controls.Add(Me.cmdValidaDatos)
        Me.GroupBox6.Controls.Add(Me.cmdGrabarDatos)
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(19, 204)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(794, 47)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        '
        'pbPROCESO
        '
        Me.pbPROCESO.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pbPROCESO.Location = New System.Drawing.Point(317, 19)
        Me.pbPROCESO.Name = "pbPROCESO"
        Me.pbPROCESO.Size = New System.Drawing.Size(458, 17)
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
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbdZonaFisica)
        Me.GroupBox4.Controls.Add(Me.rbdZonaEconomica)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(19, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(616, 47)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'rbdZonaFisica
        '
        Me.rbdZonaFisica.AccessibleDescription = "Zonas físicas"
        Me.rbdZonaFisica.AutoSize = True
        Me.rbdZonaFisica.Location = New System.Drawing.Point(162, 19)
        Me.rbdZonaFisica.Name = "rbdZonaFisica"
        Me.rbdZonaFisica.Size = New System.Drawing.Size(87, 17)
        Me.rbdZonaFisica.TabIndex = 3
        Me.rbdZonaFisica.Text = "Zonas &fisicas"
        Me.rbdZonaFisica.UseVisualStyleBackColor = True
        '
        'rbdZonaEconomica
        '
        Me.rbdZonaEconomica.AccessibleDescription = "Zonas económicas"
        Me.rbdZonaEconomica.AutoSize = True
        Me.rbdZonaEconomica.Checked = True
        Me.rbdZonaEconomica.Location = New System.Drawing.Point(27, 19)
        Me.rbdZonaEconomica.Name = "rbdZonaEconomica"
        Me.rbdZonaEconomica.Size = New System.Drawing.Size(115, 17)
        Me.rbdZonaEconomica.TabIndex = 2
        Me.rbdZonaEconomica.TabStop = True
        Me.rbdZonaEconomica.Text = "Zonas &económicas"
        Me.rbdZonaEconomica.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cmdLIMPIAR)
        Me.GroupBox3.Controls.Add(Me.cmdSALIR)
        Me.GroupBox3.Controls.Add(Me.txtSEPARADOR)
        Me.GroupBox3.Controls.Add(Me.cmdExportarPlano)
        Me.GroupBox3.Controls.Add(Me.cmdExportarExcel)
        Me.GroupBox3.Location = New System.Drawing.Point(21, 510)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(831, 47)
        Me.GroupBox3.TabIndex = 49
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
        Me.cmdSALIR.Location = New System.Drawing.Point(690, 15)
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
        Me.GroupBox1.Location = New System.Drawing.Point(21, 283)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(831, 221)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "INCONSISTENCIAS DE CARGA"
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
        Me.TabControl1.Size = New System.Drawing.Size(794, 187)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvFIPRINCO)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(786, 161)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Zonas Físicas y Económicas"
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
        Me.dgvFIPRINCO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvFIPRINCO.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvFIPRINCO.Location = New System.Drawing.Point(6, 6)
        Me.dgvFIPRINCO.Name = "dgvFIPRINCO"
        Me.dgvFIPRINCO.ReadOnly = True
        Me.dgvFIPRINCO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvFIPRINCO.ShowCellToolTips = False
        Me.dgvFIPRINCO.Size = New System.Drawing.Size(774, 149)
        Me.dgvFIPRINCO.StandardTab = True
        Me.dgvFIPRINCO.TabIndex = 1
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 569)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(867, 25)
        Me.strBARRESTA.TabIndex = 50
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
        'frm_importar_planos_ZONAS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 594)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_importar_planos_ZONAS"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "IMPORTAR PLANOS ZONAS FÍSICAS Y ECONÓMICAS"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvFIPRINCO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents pbPROCESO As System.Windows.Forms.ProgressBar
    Friend WithEvents lblFecha2 As System.Windows.Forms.Label
    Friend WithEvents cmdValidaDatos As System.Windows.Forms.Button
    Friend WithEvents cmdGrabarDatos As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRUTA As System.Windows.Forms.Label
    Friend WithEvents rbdZonaFisica As System.Windows.Forms.RadioButton
    Friend WithEvents cmdAbrirArchivo As System.Windows.Forms.Button
    Friend WithEvents rbdZonaEconomica As System.Windows.Forms.RadioButton
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
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRESOCLSE As System.Windows.Forms.Label
    Friend WithEvents txtRESOVIGE As System.Windows.Forms.Label
    Friend WithEvents txtRESOMUNI As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblRESOMUNI As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblRESOVIGE As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblRESOCLSE As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents chkEliminarZonasExistentes As System.Windows.Forms.CheckBox
End Class
