<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Migrar_Datos_Catastrales
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
        Me.fraBOTON = New System.Windows.Forms.GroupBox()
        Me.cmdSeleccionResolucion = New System.Windows.Forms.Button()
        Me.fraFIPRRESO = New System.Windows.Forms.GroupBox()
        Me.txtRESOCODI = New System.Windows.Forms.Label()
        Me.txtRESOVIGE = New System.Windows.Forms.Label()
        Me.txtRESOCLSE = New System.Windows.Forms.Label()
        Me.txtRESOTIRE = New System.Windows.Forms.Label()
        Me.txtRESOMUNI = New System.Windows.Forms.Label()
        Me.txtRESODEPA = New System.Windows.Forms.Label()
        Me.lblRESODEPA = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.lblRESOCLSE = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.lblRESODESC = New System.Windows.Forms.Label()
        Me.lblTipoResolución = New System.Windows.Forms.Label()
        Me.lblRESOVIGE = New System.Windows.Forms.Label()
        Me.lblRESOTIRE = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblRESOMUNI = New System.Windows.Forms.Label()
        Me.lblResoMunicipio = New System.Windows.Forms.Label()
        Me.lblVigencia = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.pbPROCESO1 = New System.Windows.Forms.ProgressBar()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.pbPROCESO2 = New System.Windows.Forms.ProgressBar()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdLimpiar = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.chkSobrescribirDatos = New System.Windows.Forms.CheckBox()
        Me.fraBOTON.SuspendLayout()
        Me.fraFIPRRESO.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraBOTON
        '
        Me.fraBOTON.Controls.Add(Me.cmdSeleccionResolucion)
        Me.fraBOTON.Location = New System.Drawing.Point(12, 12)
        Me.fraBOTON.Name = "fraBOTON"
        Me.fraBOTON.Size = New System.Drawing.Size(415, 47)
        Me.fraBOTON.TabIndex = 52
        Me.fraBOTON.TabStop = False
        '
        'cmdSeleccionResolucion
        '
        Me.cmdSeleccionResolucion.AccessibleDescription = "Seleccionar resolución"
        Me.cmdSeleccionResolucion.AccessibleName = ""
        Me.cmdSeleccionResolucion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSeleccionResolucion.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSeleccionResolucion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSeleccionResolucion.Image = Global.SICAFI.My.Resources.Resources._1172
        Me.cmdSeleccionResolucion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSeleccionResolucion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdSeleccionResolucion.Location = New System.Drawing.Point(18, 16)
        Me.cmdSeleccionResolucion.Name = "cmdSeleccionResolucion"
        Me.cmdSeleccionResolucion.Size = New System.Drawing.Size(273, 23)
        Me.cmdSeleccionResolucion.TabIndex = 2
        Me.cmdSeleccionResolucion.Text = "&Seleccionar resolución de actualización"
        Me.cmdSeleccionResolucion.UseVisualStyleBackColor = False
        '
        'fraFIPRRESO
        '
        Me.fraFIPRRESO.BackColor = System.Drawing.SystemColors.Control
        Me.fraFIPRRESO.Controls.Add(Me.txtRESOCODI)
        Me.fraFIPRRESO.Controls.Add(Me.txtRESOVIGE)
        Me.fraFIPRRESO.Controls.Add(Me.txtRESOCLSE)
        Me.fraFIPRRESO.Controls.Add(Me.txtRESOTIRE)
        Me.fraFIPRRESO.Controls.Add(Me.txtRESOMUNI)
        Me.fraFIPRRESO.Controls.Add(Me.txtRESODEPA)
        Me.fraFIPRRESO.Controls.Add(Me.lblRESODEPA)
        Me.fraFIPRRESO.Controls.Add(Me.Label39)
        Me.fraFIPRRESO.Controls.Add(Me.lblRESOCLSE)
        Me.fraFIPRRESO.Controls.Add(Me.Label62)
        Me.fraFIPRRESO.Controls.Add(Me.lblRESODESC)
        Me.fraFIPRRESO.Controls.Add(Me.lblTipoResolución)
        Me.fraFIPRRESO.Controls.Add(Me.lblRESOVIGE)
        Me.fraFIPRRESO.Controls.Add(Me.lblRESOTIRE)
        Me.fraFIPRRESO.Controls.Add(Me.Label17)
        Me.fraFIPRRESO.Controls.Add(Me.lblRESOMUNI)
        Me.fraFIPRRESO.Controls.Add(Me.lblResoMunicipio)
        Me.fraFIPRRESO.Controls.Add(Me.lblVigencia)
        Me.fraFIPRRESO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraFIPRRESO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraFIPRRESO.Location = New System.Drawing.Point(12, 65)
        Me.fraFIPRRESO.Name = "fraFIPRRESO"
        Me.fraFIPRRESO.Size = New System.Drawing.Size(843, 115)
        Me.fraFIPRRESO.TabIndex = 53
        Me.fraFIPRRESO.TabStop = False
        Me.fraFIPRRESO.Text = "DATOS RESOLUCIÓN"
        '
        'txtRESOCODI
        '
        Me.txtRESOCODI.BackColor = System.Drawing.SystemColors.Window
        Me.txtRESOCODI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRESOCODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRESOCODI.ForeColor = System.Drawing.Color.Black
        Me.txtRESOCODI.Location = New System.Drawing.Point(512, 74)
        Me.txtRESOCODI.Name = "txtRESOCODI"
        Me.txtRESOCODI.Size = New System.Drawing.Size(84, 20)
        Me.txtRESOCODI.TabIndex = 294
        '
        'txtRESOVIGE
        '
        Me.txtRESOVIGE.BackColor = System.Drawing.SystemColors.Window
        Me.txtRESOVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRESOVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRESOVIGE.ForeColor = System.Drawing.Color.Black
        Me.txtRESOVIGE.Location = New System.Drawing.Point(512, 50)
        Me.txtRESOVIGE.Name = "txtRESOVIGE"
        Me.txtRESOVIGE.Size = New System.Drawing.Size(84, 20)
        Me.txtRESOVIGE.TabIndex = 293
        '
        'txtRESOCLSE
        '
        Me.txtRESOCLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtRESOCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRESOCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRESOCLSE.ForeColor = System.Drawing.Color.Black
        Me.txtRESOCLSE.Location = New System.Drawing.Point(512, 26)
        Me.txtRESOCLSE.Name = "txtRESOCLSE"
        Me.txtRESOCLSE.Size = New System.Drawing.Size(84, 20)
        Me.txtRESOCLSE.TabIndex = 292
        '
        'txtRESOTIRE
        '
        Me.txtRESOTIRE.BackColor = System.Drawing.SystemColors.Window
        Me.txtRESOTIRE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRESOTIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRESOTIRE.ForeColor = System.Drawing.Color.Black
        Me.txtRESOTIRE.Location = New System.Drawing.Point(108, 74)
        Me.txtRESOTIRE.Name = "txtRESOTIRE"
        Me.txtRESOTIRE.Size = New System.Drawing.Size(84, 20)
        Me.txtRESOTIRE.TabIndex = 291
        '
        'txtRESOMUNI
        '
        Me.txtRESOMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtRESOMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRESOMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRESOMUNI.ForeColor = System.Drawing.Color.Black
        Me.txtRESOMUNI.Location = New System.Drawing.Point(108, 50)
        Me.txtRESOMUNI.Name = "txtRESOMUNI"
        Me.txtRESOMUNI.Size = New System.Drawing.Size(84, 20)
        Me.txtRESOMUNI.TabIndex = 290
        '
        'txtRESODEPA
        '
        Me.txtRESODEPA.BackColor = System.Drawing.SystemColors.Window
        Me.txtRESODEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRESODEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRESODEPA.ForeColor = System.Drawing.Color.Black
        Me.txtRESODEPA.Location = New System.Drawing.Point(108, 26)
        Me.txtRESODEPA.Name = "txtRESODEPA"
        Me.txtRESODEPA.Size = New System.Drawing.Size(84, 20)
        Me.txtRESODEPA.TabIndex = 289
        '
        'lblRESODEPA
        '
        Me.lblRESODEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESODEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESODEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESODEPA.ForeColor = System.Drawing.Color.Black
        Me.lblRESODEPA.Location = New System.Drawing.Point(198, 26)
        Me.lblRESODEPA.Name = "lblRESODEPA"
        Me.lblRESODEPA.Size = New System.Drawing.Size(217, 20)
        Me.lblRESODEPA.TabIndex = 239
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label39.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(17, 26)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(87, 21)
        Me.Label39.TabIndex = 238
        Me.Label39.Text = "Departamento"
        '
        'lblRESOCLSE
        '
        Me.lblRESOCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblRESOCLSE.Location = New System.Drawing.Point(602, 26)
        Me.lblRESOCLSE.Name = "lblRESOCLSE"
        Me.lblRESOCLSE.Size = New System.Drawing.Size(221, 20)
        Me.lblRESOCLSE.TabIndex = 236
        '
        'Label62
        '
        Me.Label62.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label62.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label62.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.Color.Black
        Me.Label62.Location = New System.Drawing.Point(421, 26)
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
        Me.lblRESODESC.Location = New System.Drawing.Point(602, 74)
        Me.lblRESODESC.Name = "lblRESODESC"
        Me.lblRESODESC.Size = New System.Drawing.Size(221, 20)
        Me.lblRESODESC.TabIndex = 233
        '
        'lblTipoResolución
        '
        Me.lblTipoResolución.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblTipoResolución.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoResolución.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoResolución.ForeColor = System.Drawing.Color.Black
        Me.lblTipoResolución.Location = New System.Drawing.Point(421, 74)
        Me.lblTipoResolución.Name = "lblTipoResolución"
        Me.lblTipoResolución.Size = New System.Drawing.Size(87, 21)
        Me.lblTipoResolución.TabIndex = 231
        Me.lblTipoResolución.Text = "Resolución"
        '
        'lblRESOVIGE
        '
        Me.lblRESOVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblRESOVIGE.Location = New System.Drawing.Point(602, 50)
        Me.lblRESOVIGE.Name = "lblRESOVIGE"
        Me.lblRESOVIGE.Size = New System.Drawing.Size(221, 20)
        Me.lblRESOVIGE.TabIndex = 230
        '
        'lblRESOTIRE
        '
        Me.lblRESOTIRE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOTIRE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOTIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOTIRE.ForeColor = System.Drawing.Color.Black
        Me.lblRESOTIRE.Location = New System.Drawing.Point(198, 74)
        Me.lblRESOTIRE.Name = "lblRESOTIRE"
        Me.lblRESOTIRE.Size = New System.Drawing.Size(217, 20)
        Me.lblRESOTIRE.TabIndex = 228
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(17, 74)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(87, 21)
        Me.Label17.TabIndex = 226
        Me.Label17.Text = "Tipo Resolución"
        '
        'lblRESOMUNI
        '
        Me.lblRESOMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblRESOMUNI.Location = New System.Drawing.Point(198, 50)
        Me.lblRESOMUNI.Name = "lblRESOMUNI"
        Me.lblRESOMUNI.Size = New System.Drawing.Size(217, 20)
        Me.lblRESOMUNI.TabIndex = 225
        '
        'lblResoMunicipio
        '
        Me.lblResoMunicipio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblResoMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblResoMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResoMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblResoMunicipio.Location = New System.Drawing.Point(17, 50)
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
        Me.lblVigencia.Location = New System.Drawing.Point(421, 50)
        Me.lblVigencia.Name = "lblVigencia"
        Me.lblVigencia.Size = New System.Drawing.Size(87, 21)
        Me.lblVigencia.TabIndex = 2
        Me.lblVigencia.Text = "Vigencia"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.pbPROCESO1)
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(12, 186)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(843, 47)
        Me.GroupBox6.TabIndex = 54
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "AVANCE PARCIAL"
        '
        'pbPROCESO1
        '
        Me.pbPROCESO1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pbPROCESO1.Location = New System.Drawing.Point(17, 19)
        Me.pbPROCESO1.Name = "pbPROCESO1"
        Me.pbPROCESO1.Size = New System.Drawing.Size(805, 17)
        Me.pbPROCESO1.TabIndex = 24
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdGuardar)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(12, 292)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(843, 47)
        Me.GroupBox2.TabIndex = 55
        Me.GroupBox2.TabStop = False
        '
        'cmdGuardar
        '
        Me.cmdGuardar.AccessibleDescription = "Guardar datos"
        Me.cmdGuardar.Enabled = False
        Me.cmdGuardar.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGuardar.Location = New System.Drawing.Point(288, 15)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(308, 23)
        Me.cmdGuardar.TabIndex = 2
        Me.cmdGuardar.Text = "Realizar copia catastral del servidor al equipo local"
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.pbPROCESO2)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(12, 239)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(843, 47)
        Me.GroupBox3.TabIndex = 56
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "AVANCE TOTAL"
        '
        'pbPROCESO2
        '
        Me.pbPROCESO2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pbPROCESO2.Location = New System.Drawing.Point(17, 19)
        Me.pbPROCESO2.Name = "pbPROCESO2"
        Me.pbPROCESO2.Size = New System.Drawing.Size(805, 17)
        Me.pbPROCESO2.TabIndex = 24
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdLimpiar)
        Me.GroupBox4.Controls.Add(Me.cmdSalir)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 345)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(843, 47)
        Me.GroupBox4.TabIndex = 57
        Me.GroupBox4.TabStop = False
        '
        'cmdLimpiar
        '
        Me.cmdLimpiar.AccessibleDescription = "Limpiar campo"
        Me.cmdLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLimpiar.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLimpiar.Location = New System.Drawing.Point(17, 15)
        Me.cmdLimpiar.Name = "cmdLimpiar"
        Me.cmdLimpiar.Size = New System.Drawing.Size(123, 23)
        Me.cmdLimpiar.TabIndex = 1
        Me.cmdLimpiar.Text = "&Limpiar campos"
        Me.cmdLimpiar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.AccessibleDescription = "Salir"
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(700, 15)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(123, 23)
        Me.cmdSalir.TabIndex = 2
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 405)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(869, 25)
        Me.strBARRESTA.TabIndex = 58
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
        'Timer2
        '
        Me.Timer2.Interval = 1
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.chkSobrescribirDatos)
        Me.GroupBox7.Location = New System.Drawing.Point(433, 12)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(422, 47)
        Me.GroupBox7.TabIndex = 59
        Me.GroupBox7.TabStop = False
        '
        'chkSobrescribirDatos
        '
        Me.chkSobrescribirDatos.AutoSize = True
        Me.chkSobrescribirDatos.Checked = True
        Me.chkSobrescribirDatos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSobrescribirDatos.Enabled = False
        Me.chkSobrescribirDatos.Location = New System.Drawing.Point(14, 18)
        Me.chkSobrescribirDatos.Name = "chkSobrescribirDatos"
        Me.chkSobrescribirDatos.Size = New System.Drawing.Size(263, 17)
        Me.chkSobrescribirDatos.TabIndex = 5
        Me.chkSobrescribirDatos.Text = "Sobrescribir los datos de la ficha predial y resumen"
        Me.chkSobrescribirDatos.UseVisualStyleBackColor = True
        '
        'frm_Migrar_Datos_Catastrales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 430)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.fraBOTON)
        Me.Controls.Add(Me.fraFIPRRESO)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_Migrar_Datos_Catastrales"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "MIGRAR DATOS CATASTRALES"
        Me.fraBOTON.ResumeLayout(False)
        Me.fraFIPRRESO.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraBOTON As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSeleccionResolucion As System.Windows.Forms.Button
    Friend WithEvents fraFIPRRESO As System.Windows.Forms.GroupBox
    Friend WithEvents txtRESOCODI As System.Windows.Forms.Label
    Friend WithEvents txtRESOVIGE As System.Windows.Forms.Label
    Friend WithEvents txtRESOCLSE As System.Windows.Forms.Label
    Friend WithEvents txtRESOTIRE As System.Windows.Forms.Label
    Friend WithEvents txtRESOMUNI As System.Windows.Forms.Label
    Friend WithEvents txtRESODEPA As System.Windows.Forms.Label
    Friend WithEvents lblRESODEPA As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents lblRESOCLSE As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents lblRESODESC As System.Windows.Forms.Label
    Friend WithEvents lblTipoResolución As System.Windows.Forms.Label
    Friend WithEvents lblRESOVIGE As System.Windows.Forms.Label
    Friend WithEvents lblRESOTIRE As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblRESOMUNI As System.Windows.Forms.Label
    Friend WithEvents lblResoMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblVigencia As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents pbPROCESO1 As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGuardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents pbPROCESO2 As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLimpiar As System.Windows.Forms.Button
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents chkSobrescribirDatos As System.Windows.Forms.CheckBox
End Class
