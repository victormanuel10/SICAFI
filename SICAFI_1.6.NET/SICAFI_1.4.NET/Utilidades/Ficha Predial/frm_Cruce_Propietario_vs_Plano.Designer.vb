<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Cruce_Propietario_vs_Plano
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.pbProcesoDepartamento = New System.Windows.Forms.ProgressBar
        Me.lblFechaDepartamento = New System.Windows.Forms.Label
        Me.cmdValidaDatosDepartamento = New System.Windows.Forms.Button
        Me.cmdCargarDatosDepartamento = New System.Windows.Forms.Button
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.lblRutaArchivoDepartamento = New System.Windows.Forms.Label
        Me.lblCantidadPrediosDepartamento = New System.Windows.Forms.Label
        Me.cmdAbrirArchivoDepartamento = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.pbProcesoMunicipio = New System.Windows.Forms.ProgressBar
        Me.lblFechaMunicipio = New System.Windows.Forms.Label
        Me.cmdValidaDatosMunicipio = New System.Windows.Forms.Button
        Me.cmdCargarDatosMunicipio = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lblRutaArchivoMunicipio = New System.Windows.Forms.Label
        Me.lblCantidadPrediosMunicipio = New System.Windows.Forms.Label
        Me.cmdAbrirArchivoMunicipio = New System.Windows.Forms.Button
        Me.lblPredio = New System.Windows.Forms.Label
        Me.GroupBox11 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdCruceMunicipioVsDepartamento = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdExtructura = New System.Windows.Forms.Button
        Me.cmdLIMPIAR = New System.Windows.Forms.Button
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.txtSEPARADOR = New System.Windows.Forms.TextBox
        Me.cmdExportarPlano = New System.Windows.Forms.Button
        Me.cmdExportarExcel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dgvFIPRINCO = New System.Windows.Forms.DataGridView
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvFIPRINCO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.GroupBox8)
        Me.GroupBox7.Controls.Add(Me.GroupBox9)
        Me.GroupBox7.ForeColor = System.Drawing.Color.Black
        Me.GroupBox7.Location = New System.Drawing.Point(21, 153)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(829, 135)
        Me.GroupBox7.TabIndex = 57
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "CARGAR PLANO DEPARTAMENTO"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.pbProcesoDepartamento)
        Me.GroupBox8.Controls.Add(Me.lblFechaDepartamento)
        Me.GroupBox8.Controls.Add(Me.cmdValidaDatosDepartamento)
        Me.GroupBox8.Controls.Add(Me.cmdCargarDatosDepartamento)
        Me.GroupBox8.ForeColor = System.Drawing.Color.Black
        Me.GroupBox8.Location = New System.Drawing.Point(19, 72)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(792, 47)
        Me.GroupBox8.TabIndex = 3
        Me.GroupBox8.TabStop = False
        '
        'pbProcesoDepartamento
        '
        Me.pbProcesoDepartamento.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pbProcesoDepartamento.Location = New System.Drawing.Point(317, 19)
        Me.pbProcesoDepartamento.Name = "pbProcesoDepartamento"
        Me.pbProcesoDepartamento.Size = New System.Drawing.Size(455, 17)
        Me.pbProcesoDepartamento.TabIndex = 24
        '
        'lblFechaDepartamento
        '
        Me.lblFechaDepartamento.Image = Global.SICAFI.My.Resources.Resources._834
        Me.lblFechaDepartamento.Location = New System.Drawing.Point(148, 15)
        Me.lblFechaDepartamento.Name = "lblFechaDepartamento"
        Me.lblFechaDepartamento.Size = New System.Drawing.Size(22, 23)
        Me.lblFechaDepartamento.TabIndex = 5
        Me.lblFechaDepartamento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblFechaDepartamento.Visible = False
        '
        'cmdValidaDatosDepartamento
        '
        Me.cmdValidaDatosDepartamento.AccessibleDescription = "Valida datos"
        Me.cmdValidaDatosDepartamento.Enabled = False
        Me.cmdValidaDatosDepartamento.Image = Global.SICAFI.My.Resources.Resources._125
        Me.cmdValidaDatosDepartamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdValidaDatosDepartamento.Location = New System.Drawing.Point(19, 15)
        Me.cmdValidaDatosDepartamento.Name = "cmdValidaDatosDepartamento"
        Me.cmdValidaDatosDepartamento.Size = New System.Drawing.Size(123, 23)
        Me.cmdValidaDatosDepartamento.TabIndex = 1
        Me.cmdValidaDatosDepartamento.Text = "Valida datos"
        Me.cmdValidaDatosDepartamento.UseVisualStyleBackColor = True
        '
        'cmdCargarDatosDepartamento
        '
        Me.cmdCargarDatosDepartamento.AccessibleDescription = "Cargar datos"
        Me.cmdCargarDatosDepartamento.Enabled = False
        Me.cmdCargarDatosDepartamento.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdCargarDatosDepartamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCargarDatosDepartamento.Location = New System.Drawing.Point(176, 15)
        Me.cmdCargarDatosDepartamento.Name = "cmdCargarDatosDepartamento"
        Me.cmdCargarDatosDepartamento.Size = New System.Drawing.Size(123, 23)
        Me.cmdCargarDatosDepartamento.TabIndex = 2
        Me.cmdCargarDatosDepartamento.Text = "Cargar datos"
        Me.cmdCargarDatosDepartamento.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.lblRutaArchivoDepartamento)
        Me.GroupBox9.Controls.Add(Me.lblCantidadPrediosDepartamento)
        Me.GroupBox9.Controls.Add(Me.cmdAbrirArchivoDepartamento)
        Me.GroupBox9.Controls.Add(Me.Label4)
        Me.GroupBox9.ForeColor = System.Drawing.Color.Black
        Me.GroupBox9.Location = New System.Drawing.Point(19, 19)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(792, 47)
        Me.GroupBox9.TabIndex = 1
        Me.GroupBox9.TabStop = False
        '
        'lblRutaArchivoDepartamento
        '
        Me.lblRutaArchivoDepartamento.AccessibleDescription = "Ruta archivo"
        Me.lblRutaArchivoDepartamento.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRutaArchivoDepartamento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRutaArchivoDepartamento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutaArchivoDepartamento.ForeColor = System.Drawing.Color.Black
        Me.lblRutaArchivoDepartamento.Location = New System.Drawing.Point(162, 16)
        Me.lblRutaArchivoDepartamento.Name = "lblRutaArchivoDepartamento"
        Me.lblRutaArchivoDepartamento.Size = New System.Drawing.Size(433, 20)
        Me.lblRutaArchivoDepartamento.TabIndex = 356
        '
        'lblCantidadPrediosDepartamento
        '
        Me.lblCantidadPrediosDepartamento.AccessibleDescription = "Cantidad predios"
        Me.lblCantidadPrediosDepartamento.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCantidadPrediosDepartamento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCantidadPrediosDepartamento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadPrediosDepartamento.Location = New System.Drawing.Point(688, 16)
        Me.lblCantidadPrediosDepartamento.Name = "lblCantidadPrediosDepartamento"
        Me.lblCantidadPrediosDepartamento.Size = New System.Drawing.Size(84, 20)
        Me.lblCantidadPrediosDepartamento.TabIndex = 367
        Me.lblCantidadPrediosDepartamento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdAbrirArchivoDepartamento
        '
        Me.cmdAbrirArchivoDepartamento.AccessibleDescription = "Abrir archivo"
        Me.cmdAbrirArchivoDepartamento.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdAbrirArchivoDepartamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAbrirArchivoDepartamento.Location = New System.Drawing.Point(19, 15)
        Me.cmdAbrirArchivoDepartamento.Name = "cmdAbrirArchivoDepartamento"
        Me.cmdAbrirArchivoDepartamento.Size = New System.Drawing.Size(123, 23)
        Me.cmdAbrirArchivoDepartamento.TabIndex = 1
        Me.cmdAbrirArchivoDepartamento.Text = "Abrir archivo"
        Me.cmdAbrirArchivoDepartamento.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(600, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 20)
        Me.Label4.TabIndex = 308
        Me.Label4.Text = "Cantidad :"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.GroupBox6)
        Me.GroupBox5.Controls.Add(Me.GroupBox4)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(21, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(829, 135)
        Me.GroupBox5.TabIndex = 53
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "CARGAR PLANO MUNICIPIO"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.pbProcesoMunicipio)
        Me.GroupBox6.Controls.Add(Me.lblFechaMunicipio)
        Me.GroupBox6.Controls.Add(Me.cmdValidaDatosMunicipio)
        Me.GroupBox6.Controls.Add(Me.cmdCargarDatosMunicipio)
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(19, 72)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(792, 47)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        '
        'pbProcesoMunicipio
        '
        Me.pbProcesoMunicipio.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pbProcesoMunicipio.Location = New System.Drawing.Point(317, 19)
        Me.pbProcesoMunicipio.Name = "pbProcesoMunicipio"
        Me.pbProcesoMunicipio.Size = New System.Drawing.Size(455, 17)
        Me.pbProcesoMunicipio.TabIndex = 24
        '
        'lblFechaMunicipio
        '
        Me.lblFechaMunicipio.Image = Global.SICAFI.My.Resources.Resources._834
        Me.lblFechaMunicipio.Location = New System.Drawing.Point(148, 15)
        Me.lblFechaMunicipio.Name = "lblFechaMunicipio"
        Me.lblFechaMunicipio.Size = New System.Drawing.Size(22, 23)
        Me.lblFechaMunicipio.TabIndex = 5
        Me.lblFechaMunicipio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblFechaMunicipio.Visible = False
        '
        'cmdValidaDatosMunicipio
        '
        Me.cmdValidaDatosMunicipio.AccessibleDescription = "Valida datos"
        Me.cmdValidaDatosMunicipio.Enabled = False
        Me.cmdValidaDatosMunicipio.Image = Global.SICAFI.My.Resources.Resources._125
        Me.cmdValidaDatosMunicipio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdValidaDatosMunicipio.Location = New System.Drawing.Point(19, 15)
        Me.cmdValidaDatosMunicipio.Name = "cmdValidaDatosMunicipio"
        Me.cmdValidaDatosMunicipio.Size = New System.Drawing.Size(123, 23)
        Me.cmdValidaDatosMunicipio.TabIndex = 1
        Me.cmdValidaDatosMunicipio.Text = "Valida datos"
        Me.cmdValidaDatosMunicipio.UseVisualStyleBackColor = True
        '
        'cmdCargarDatosMunicipio
        '
        Me.cmdCargarDatosMunicipio.AccessibleDescription = "Cargar datos"
        Me.cmdCargarDatosMunicipio.Enabled = False
        Me.cmdCargarDatosMunicipio.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdCargarDatosMunicipio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCargarDatosMunicipio.Location = New System.Drawing.Point(176, 15)
        Me.cmdCargarDatosMunicipio.Name = "cmdCargarDatosMunicipio"
        Me.cmdCargarDatosMunicipio.Size = New System.Drawing.Size(123, 23)
        Me.cmdCargarDatosMunicipio.TabIndex = 2
        Me.cmdCargarDatosMunicipio.Text = "Cargar datos"
        Me.cmdCargarDatosMunicipio.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblRutaArchivoMunicipio)
        Me.GroupBox4.Controls.Add(Me.lblCantidadPrediosMunicipio)
        Me.GroupBox4.Controls.Add(Me.cmdAbrirArchivoMunicipio)
        Me.GroupBox4.Controls.Add(Me.lblPredio)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(19, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(792, 47)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'lblRutaArchivoMunicipio
        '
        Me.lblRutaArchivoMunicipio.AccessibleDescription = "Ruta archivo"
        Me.lblRutaArchivoMunicipio.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRutaArchivoMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRutaArchivoMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutaArchivoMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblRutaArchivoMunicipio.Location = New System.Drawing.Point(162, 16)
        Me.lblRutaArchivoMunicipio.Name = "lblRutaArchivoMunicipio"
        Me.lblRutaArchivoMunicipio.Size = New System.Drawing.Size(433, 20)
        Me.lblRutaArchivoMunicipio.TabIndex = 356
        '
        'lblCantidadPrediosMunicipio
        '
        Me.lblCantidadPrediosMunicipio.AccessibleDescription = "Cantidad predios"
        Me.lblCantidadPrediosMunicipio.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCantidadPrediosMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCantidadPrediosMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadPrediosMunicipio.Location = New System.Drawing.Point(688, 16)
        Me.lblCantidadPrediosMunicipio.Name = "lblCantidadPrediosMunicipio"
        Me.lblCantidadPrediosMunicipio.Size = New System.Drawing.Size(84, 20)
        Me.lblCantidadPrediosMunicipio.TabIndex = 367
        Me.lblCantidadPrediosMunicipio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdAbrirArchivoMunicipio
        '
        Me.cmdAbrirArchivoMunicipio.AccessibleDescription = "Abrir archivo"
        Me.cmdAbrirArchivoMunicipio.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdAbrirArchivoMunicipio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAbrirArchivoMunicipio.Location = New System.Drawing.Point(19, 15)
        Me.cmdAbrirArchivoMunicipio.Name = "cmdAbrirArchivoMunicipio"
        Me.cmdAbrirArchivoMunicipio.Size = New System.Drawing.Size(123, 23)
        Me.cmdAbrirArchivoMunicipio.TabIndex = 1
        Me.cmdAbrirArchivoMunicipio.Text = "Abrir archivo"
        Me.cmdAbrirArchivoMunicipio.UseVisualStyleBackColor = True
        '
        'lblPredio
        '
        Me.lblPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredio.ForeColor = System.Drawing.Color.Black
        Me.lblPredio.Location = New System.Drawing.Point(600, 16)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(84, 20)
        Me.lblPredio.TabIndex = 308
        Me.lblPredio.Text = "Cantidad :"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.GroupBox2)
        Me.GroupBox11.Location = New System.Drawing.Point(21, 294)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(829, 82)
        Me.GroupBox11.TabIndex = 52
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "CRUCE DE INFORMACIÓN"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdCruceMunicipioVsDepartamento)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(19, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(792, 47)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'cmdCruceMunicipioVsDepartamento
        '
        Me.cmdCruceMunicipioVsDepartamento.AccessibleDescription = "Municipio Vs Depa."
        Me.cmdCruceMunicipioVsDepartamento.Enabled = False
        Me.cmdCruceMunicipioVsDepartamento.Image = Global.SICAFI.My.Resources.Resources._125
        Me.cmdCruceMunicipioVsDepartamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCruceMunicipioVsDepartamento.Location = New System.Drawing.Point(19, 15)
        Me.cmdCruceMunicipioVsDepartamento.Name = "cmdCruceMunicipioVsDepartamento"
        Me.cmdCruceMunicipioVsDepartamento.Size = New System.Drawing.Size(370, 23)
        Me.cmdCruceMunicipioVsDepartamento.TabIndex = 1
        Me.cmdCruceMunicipioVsDepartamento.Text = "Cruce B.D. Municipio Vs B.D. Departamento"
        Me.cmdCruceMunicipioVsDepartamento.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cmdExtructura)
        Me.GroupBox3.Controls.Add(Me.cmdLIMPIAR)
        Me.GroupBox3.Controls.Add(Me.cmdSALIR)
        Me.GroupBox3.Controls.Add(Me.txtSEPARADOR)
        Me.GroupBox3.Controls.Add(Me.cmdExportarPlano)
        Me.GroupBox3.Controls.Add(Me.cmdExportarExcel)
        Me.GroupBox3.Location = New System.Drawing.Point(21, 530)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(829, 47)
        Me.GroupBox3.TabIndex = 55
        Me.GroupBox3.TabStop = False
        '
        'cmdExtructura
        '
        Me.cmdExtructura.AccessibleDescription = "Extructura"
        Me.cmdExtructura.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdExtructura.AutoEllipsis = True
        Me.cmdExtructura.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExtructura.Image = Global.SICAFI.My.Resources.Resources._677
        Me.cmdExtructura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExtructura.Location = New System.Drawing.Point(431, 16)
        Me.cmdExtructura.Name = "cmdExtructura"
        Me.cmdExtructura.Size = New System.Drawing.Size(123, 23)
        Me.cmdExtructura.TabIndex = 10
        Me.cmdExtructura.Text = "&Extructuras"
        Me.cmdExtructura.UseVisualStyleBackColor = True
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
        Me.GroupBox1.Location = New System.Drawing.Point(21, 382)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(829, 142)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "RESULTADO"
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
        Me.TabControl1.Size = New System.Drawing.Size(792, 108)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvFIPRINCO)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(784, 82)
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
        Me.dgvFIPRINCO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvFIPRINCO.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvFIPRINCO.Location = New System.Drawing.Point(6, 6)
        Me.dgvFIPRINCO.Name = "dgvFIPRINCO"
        Me.dgvFIPRINCO.ReadOnly = True
        Me.dgvFIPRINCO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvFIPRINCO.ShowCellToolTips = False
        Me.dgvFIPRINCO.Size = New System.Drawing.Size(772, 70)
        Me.dgvFIPRINCO.StandardTab = True
        Me.dgvFIPRINCO.TabIndex = 1
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 591)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(867, 25)
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
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'frm_Cruce_Propietario_vs_Plano
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 616)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_Cruce_Propietario_vs_Plano"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CRUCE PROPIETARIO MUNICIPIO VS DEPARTAMENTO"
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
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
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents pbProcesoDepartamento As System.Windows.Forms.ProgressBar
    Friend WithEvents lblFechaDepartamento As System.Windows.Forms.Label
    Friend WithEvents cmdValidaDatosDepartamento As System.Windows.Forms.Button
    Friend WithEvents cmdCargarDatosDepartamento As System.Windows.Forms.Button
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRutaArchivoDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblCantidadPrediosDepartamento As System.Windows.Forms.Label
    Friend WithEvents cmdAbrirArchivoDepartamento As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents pbProcesoMunicipio As System.Windows.Forms.ProgressBar
    Friend WithEvents lblFechaMunicipio As System.Windows.Forms.Label
    Friend WithEvents cmdValidaDatosMunicipio As System.Windows.Forms.Button
    Friend WithEvents cmdCargarDatosMunicipio As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRutaArchivoMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCantidadPrediosMunicipio As System.Windows.Forms.Label
    Friend WithEvents cmdAbrirArchivoMunicipio As System.Windows.Forms.Button
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCruceMunicipioVsDepartamento As System.Windows.Forms.Button
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
    Friend WithEvents cmdExtructura As System.Windows.Forms.Button
End Class
