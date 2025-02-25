<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_plano_predial_catastral
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consulta_plano_predial_catastral))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdVistaPredio = New System.Windows.Forms.Button()
        Me.cmdULTIMACONSULTA = New System.Windows.Forms.Button()
        Me.cmdLIMPIAR = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdConsultarCedulaCatastral = New System.Windows.Forms.Button()
        Me.fraFICHPRED = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabCedulaCatastral = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtFIPRCLSE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFIPRNUFI = New System.Windows.Forms.TextBox()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.txtFIPRDIRE = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtFIPRCORR = New System.Windows.Forms.TextBox()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.txtFIPRMUNI = New System.Windows.Forms.TextBox()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblClaseOSector2 = New System.Windows.Forms.Label()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.txtFIPRUNPR = New System.Windows.Forms.TextBox()
        Me.lblManzana = New System.Windows.Forms.Label()
        Me.txtFIPREDIF = New System.Windows.Forms.TextBox()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.txtFIPRPRED = New System.Windows.Forms.TextBox()
        Me.lblEdificio = New System.Windows.Forms.Label()
        Me.txtFIPRMANZ = New System.Windows.Forms.TextBox()
        Me.lblUnidadPredial = New System.Windows.Forms.Label()
        Me.txtFIPRBARR = New System.Windows.Forms.TextBox()
        Me.lblCodigoActual = New System.Windows.Forms.Label()
        Me.TabCedulaCiudadania = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.cmdConsultarCedulaDeCiudadania = New System.Windows.Forms.Button()
        Me.lblFPPRNUDO = New System.Windows.Forms.Label()
        Me.txtFPPRNUDO = New System.Windows.Forms.TextBox()
        Me.TabMatriculaInmobiliaria = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFPPRMAIN = New System.Windows.Forms.TextBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.cmdConsultarMatriculaInmobiliaria = New System.Windows.Forms.Button()
        Me.lblFPPRMAIN = New System.Windows.Forms.Label()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.axaVisorDocumentoPDF = New AxAcroPDFLib.AxAcroPDF()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvCONSULTA = New System.Windows.Forms.DataGridView()
        Me.GroupBox3.SuspendLayout()
        Me.fraFICHPRED.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabCedulaCatastral.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.TabCedulaCiudadania.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.TabMatriculaInmobiliaria.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.axaVisorDocumentoPDF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdVistaPredio)
        Me.GroupBox3.Controls.Add(Me.cmdULTIMACONSULTA)
        Me.GroupBox3.Controls.Add(Me.cmdLIMPIAR)
        Me.GroupBox3.Controls.Add(Me.cmdSALIR)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(12, 270)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(878, 47)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'cmdVistaPredio
        '
        Me.cmdVistaPredio.AccessibleDescription = "Vista predio"
        Me.cmdVistaPredio.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdVistaPredio.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdVistaPredio.Image = Global.SICAFI.My.Resources.Resources._047
        Me.cmdVistaPredio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdVistaPredio.Location = New System.Drawing.Point(300, 15)
        Me.cmdVistaPredio.Name = "cmdVistaPredio"
        Me.cmdVistaPredio.Size = New System.Drawing.Size(135, 23)
        Me.cmdVistaPredio.TabIndex = 429
        Me.cmdVistaPredio.Text = "Pantalla completa"
        Me.cmdVistaPredio.UseVisualStyleBackColor = True
        '
        'cmdULTIMACONSULTA
        '
        Me.cmdULTIMACONSULTA.AccessibleDescription = "Ultima consulta"
        Me.cmdULTIMACONSULTA.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdULTIMACONSULTA.Image = Global.SICAFI.My.Resources.Resources._667
        Me.cmdULTIMACONSULTA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdULTIMACONSULTA.Location = New System.Drawing.Point(18, 15)
        Me.cmdULTIMACONSULTA.Name = "cmdULTIMACONSULTA"
        Me.cmdULTIMACONSULTA.Size = New System.Drawing.Size(135, 23)
        Me.cmdULTIMACONSULTA.TabIndex = 19
        Me.cmdULTIMACONSULTA.Text = "&Ultima consulta"
        Me.cmdULTIMACONSULTA.UseVisualStyleBackColor = True
        '
        'cmdLIMPIAR
        '
        Me.cmdLIMPIAR.AccessibleDescription = "Limpiar campo"
        Me.cmdLIMPIAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLIMPIAR.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLIMPIAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLIMPIAR.Location = New System.Drawing.Point(159, 15)
        Me.cmdLIMPIAR.Name = "cmdLIMPIAR"
        Me.cmdLIMPIAR.Size = New System.Drawing.Size(135, 23)
        Me.cmdLIMPIAR.TabIndex = 20
        Me.cmdLIMPIAR.Text = "&Limpiar campos"
        Me.cmdLIMPIAR.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Cancelar"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(722, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(135, 23)
        Me.cmdSALIR.TabIndex = 24
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdConsultarCedulaCatastral
        '
        Me.cmdConsultarCedulaCatastral.AccessibleDescription = "Consultar"
        Me.cmdConsultarCedulaCatastral.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdConsultarCedulaCatastral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdConsultarCedulaCatastral.Location = New System.Drawing.Point(647, 20)
        Me.cmdConsultarCedulaCatastral.Name = "cmdConsultarCedulaCatastral"
        Me.cmdConsultarCedulaCatastral.Size = New System.Drawing.Size(135, 23)
        Me.cmdConsultarCedulaCatastral.TabIndex = 18
        Me.cmdConsultarCedulaCatastral.Text = "&Consultar"
        Me.cmdConsultarCedulaCatastral.UseVisualStyleBackColor = True
        '
        'fraFICHPRED
        '
        Me.fraFICHPRED.BackColor = System.Drawing.SystemColors.Control
        Me.fraFICHPRED.Controls.Add(Me.TabControl1)
        Me.fraFICHPRED.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraFICHPRED.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraFICHPRED.Location = New System.Drawing.Point(12, 12)
        Me.fraFICHPRED.Name = "fraFICHPRED"
        Me.fraFICHPRED.Size = New System.Drawing.Size(878, 252)
        Me.fraFICHPRED.TabIndex = 2
        Me.fraFICHPRED.TabStop = False
        Me.fraFICHPRED.Text = "PARAMETRO DE CONSULTA"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabCedulaCatastral)
        Me.TabControl1.Controls.Add(Me.TabCedulaCiudadania)
        Me.TabControl1.Controls.Add(Me.TabMatriculaInmobiliaria)
        Me.TabControl1.Location = New System.Drawing.Point(18, 20)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(843, 209)
        Me.TabControl1.TabIndex = 62
        '
        'TabCedulaCatastral
        '
        Me.TabCedulaCatastral.BackColor = System.Drawing.SystemColors.Control
        Me.TabCedulaCatastral.Controls.Add(Me.GroupBox6)
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPRCLSE)
        Me.TabCedulaCatastral.Controls.Add(Me.Label1)
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPRNUFI)
        Me.TabCedulaCatastral.Controls.Add(Me.lblDireccion)
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPRDIRE)
        Me.TabCedulaCatastral.Controls.Add(Me.Label33)
        Me.TabCedulaCatastral.Controls.Add(Me.lblCodigo)
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPRCORR)
        Me.TabCedulaCatastral.Controls.Add(Me.lblMunicipio)
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPRMUNI)
        Me.TabCedulaCatastral.Controls.Add(Me.lblCorregimiento)
        Me.TabCedulaCatastral.Controls.Add(Me.lblClaseOSector2)
        Me.TabCedulaCatastral.Controls.Add(Me.lblBarrio)
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPRUNPR)
        Me.TabCedulaCatastral.Controls.Add(Me.lblManzana)
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPREDIF)
        Me.TabCedulaCatastral.Controls.Add(Me.lblPredio)
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPRPRED)
        Me.TabCedulaCatastral.Controls.Add(Me.lblEdificio)
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPRMANZ)
        Me.TabCedulaCatastral.Controls.Add(Me.lblUnidadPredial)
        Me.TabCedulaCatastral.Controls.Add(Me.txtFIPRBARR)
        Me.TabCedulaCatastral.Controls.Add(Me.lblCodigoActual)
        Me.TabCedulaCatastral.Location = New System.Drawing.Point(4, 24)
        Me.TabCedulaCatastral.Name = "TabCedulaCatastral"
        Me.TabCedulaCatastral.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCedulaCatastral.Size = New System.Drawing.Size(835, 181)
        Me.TabCedulaCatastral.TabIndex = 0
        Me.TabCedulaCatastral.Text = "Cedula catastral"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox6.Controls.Add(Me.cmdConsultarCedulaCatastral)
        Me.GroupBox6.Location = New System.Drawing.Point(17, 107)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(801, 55)
        Me.GroupBox6.TabIndex = 301
        Me.GroupBox6.TabStop = False
        '
        'txtFIPRCLSE
        '
        Me.txtFIPRCLSE.AccessibleDescription = "Clase o sector"
        Me.txtFIPRCLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRCLSE.Location = New System.Drawing.Point(723, 81)
        Me.txtFIPRCLSE.MaxLength = 10
        Me.txtFIPRCLSE.Name = "txtFIPRCLSE"
        Me.txtFIPRCLSE.Size = New System.Drawing.Size(95, 20)
        Me.txtFIPRCLSE.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 20)
        Me.Label1.TabIndex = 288
        Me.Label1.Text = "Nro. FICHA"
        '
        'txtFIPRNUFI
        '
        Me.txtFIPRNUFI.AccessibleDescription = "Nro. Ficha predial"
        Me.txtFIPRNUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRNUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRNUFI.Location = New System.Drawing.Point(106, 12)
        Me.txtFIPRNUFI.MaxLength = 9
        Me.txtFIPRNUFI.Name = "txtFIPRNUFI"
        Me.txtFIPRNUFI.Size = New System.Drawing.Size(175, 20)
        Me.txtFIPRNUFI.TabIndex = 4
        '
        'lblDireccion
        '
        Me.lblDireccion.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblDireccion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDireccion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccion.ForeColor = System.Drawing.Color.Black
        Me.lblDireccion.Location = New System.Drawing.Point(284, 13)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(84, 20)
        Me.lblDireccion.TabIndex = 99
        Me.lblDireccion.Text = "Dirección"
        '
        'txtFIPRDIRE
        '
        Me.txtFIPRDIRE.AccessibleDescription = "Dirección "
        Me.txtFIPRDIRE.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRDIRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRDIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRDIRE.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRDIRE.Location = New System.Drawing.Point(372, 12)
        Me.txtFIPRDIRE.MaxLength = 49
        Me.txtFIPRDIRE.Name = "txtFIPRDIRE"
        Me.txtFIPRDIRE.Size = New System.Drawing.Size(447, 20)
        Me.txtFIPRDIRE.TabIndex = 5
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(17, 35)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(801, 20)
        Me.Label33.TabIndex = 278
        Me.Label33.Text = "CEDULA CATASTRAL ACTUAL"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(17, 58)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(85, 20)
        Me.lblCodigo.TabIndex = 300
        Me.lblCodigo.Text = "CODIGO"
        '
        'txtFIPRCORR
        '
        Me.txtFIPRCORR.AccessibleDescription = "Corregimiento"
        Me.txtFIPRCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRCORR.Location = New System.Drawing.Point(196, 81)
        Me.txtFIPRCORR.MaxLength = 10
        Me.txtFIPRCORR.Name = "txtFIPRCORR"
        Me.txtFIPRCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRCORR.TabIndex = 7
        '
        'lblMunicipio
        '
        Me.lblMunicipio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblMunicipio.Location = New System.Drawing.Point(106, 58)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(86, 20)
        Me.lblMunicipio.TabIndex = 300
        Me.lblMunicipio.Text = "Municipio"
        '
        'txtFIPRMUNI
        '
        Me.txtFIPRMUNI.AccessibleDescription = "Municipio"
        Me.txtFIPRMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMUNI.Location = New System.Drawing.Point(106, 81)
        Me.txtFIPRMUNI.MaxLength = 10
        Me.txtFIPRMUNI.Name = "txtFIPRMUNI"
        Me.txtFIPRMUNI.Size = New System.Drawing.Size(87, 20)
        Me.txtFIPRMUNI.TabIndex = 6
        '
        'lblCorregimiento
        '
        Me.lblCorregimiento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCorregimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorregimiento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorregimiento.ForeColor = System.Drawing.Color.Black
        Me.lblCorregimiento.Location = New System.Drawing.Point(196, 58)
        Me.lblCorregimiento.Name = "lblCorregimiento"
        Me.lblCorregimiento.Size = New System.Drawing.Size(84, 20)
        Me.lblCorregimiento.TabIndex = 30
        Me.lblCorregimiento.Text = "Corregimiento"
        '
        'lblClaseOSector2
        '
        Me.lblClaseOSector2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseOSector2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseOSector2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseOSector2.ForeColor = System.Drawing.Color.Black
        Me.lblClaseOSector2.Location = New System.Drawing.Point(723, 58)
        Me.lblClaseOSector2.Name = "lblClaseOSector2"
        Me.lblClaseOSector2.Size = New System.Drawing.Size(96, 20)
        Me.lblClaseOSector2.TabIndex = 45
        Me.lblClaseOSector2.Text = "Clase o Sector"
        '
        'lblBarrio
        '
        Me.lblBarrio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblBarrio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBarrio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarrio.ForeColor = System.Drawing.Color.Black
        Me.lblBarrio.Location = New System.Drawing.Point(284, 58)
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Size = New System.Drawing.Size(84, 20)
        Me.lblBarrio.TabIndex = 22
        Me.lblBarrio.Text = "Barrio"
        '
        'txtFIPRUNPR
        '
        Me.txtFIPRUNPR.AccessibleDescription = "Unidad predial "
        Me.txtFIPRUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRUNPR.Location = New System.Drawing.Point(636, 81)
        Me.txtFIPRUNPR.MaxLength = 10
        Me.txtFIPRUNPR.Name = "txtFIPRUNPR"
        Me.txtFIPRUNPR.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRUNPR.TabIndex = 12
        '
        'lblManzana
        '
        Me.lblManzana.AccessibleDescription = ""
        Me.lblManzana.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblManzana.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblManzana.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManzana.ForeColor = System.Drawing.Color.Black
        Me.lblManzana.Location = New System.Drawing.Point(372, 58)
        Me.lblManzana.Name = "lblManzana"
        Me.lblManzana.Size = New System.Drawing.Size(84, 20)
        Me.lblManzana.TabIndex = 23
        Me.lblManzana.Text = "Manza / Vered"
        '
        'txtFIPREDIF
        '
        Me.txtFIPREDIF.AccessibleDescription = "Edificio "
        Me.txtFIPREDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPREDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPREDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPREDIF.ForeColor = System.Drawing.Color.Black
        Me.txtFIPREDIF.Location = New System.Drawing.Point(548, 81)
        Me.txtFIPREDIF.MaxLength = 10
        Me.txtFIPREDIF.Name = "txtFIPREDIF"
        Me.txtFIPREDIF.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPREDIF.TabIndex = 11
        '
        'lblPredio
        '
        Me.lblPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredio.ForeColor = System.Drawing.Color.Black
        Me.lblPredio.Location = New System.Drawing.Point(460, 58)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(84, 20)
        Me.lblPredio.TabIndex = 24
        Me.lblPredio.Text = "Predio"
        '
        'txtFIPRPRED
        '
        Me.txtFIPRPRED.AccessibleDescription = "Predio "
        Me.txtFIPRPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRPRED.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRPRED.Location = New System.Drawing.Point(460, 81)
        Me.txtFIPRPRED.MaxLength = 10
        Me.txtFIPRPRED.Name = "txtFIPRPRED"
        Me.txtFIPRPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRPRED.TabIndex = 10
        '
        'lblEdificio
        '
        Me.lblEdificio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblEdificio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEdificio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdificio.ForeColor = System.Drawing.Color.Black
        Me.lblEdificio.Location = New System.Drawing.Point(548, 58)
        Me.lblEdificio.Name = "lblEdificio"
        Me.lblEdificio.Size = New System.Drawing.Size(84, 20)
        Me.lblEdificio.TabIndex = 25
        Me.lblEdificio.Text = "Edificio"
        '
        'txtFIPRMANZ
        '
        Me.txtFIPRMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtFIPRMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRMANZ.Location = New System.Drawing.Point(372, 81)
        Me.txtFIPRMANZ.MaxLength = 10
        Me.txtFIPRMANZ.Name = "txtFIPRMANZ"
        Me.txtFIPRMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRMANZ.TabIndex = 9
        '
        'lblUnidadPredial
        '
        Me.lblUnidadPredial.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblUnidadPredial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUnidadPredial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidadPredial.ForeColor = System.Drawing.Color.Black
        Me.lblUnidadPredial.Location = New System.Drawing.Point(636, 58)
        Me.lblUnidadPredial.Name = "lblUnidadPredial"
        Me.lblUnidadPredial.Size = New System.Drawing.Size(84, 20)
        Me.lblUnidadPredial.TabIndex = 26
        Me.lblUnidadPredial.Text = "Unidad Predial"
        '
        'txtFIPRBARR
        '
        Me.txtFIPRBARR.AccessibleDescription = "Barrio "
        Me.txtFIPRBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRBARR.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRBARR.Location = New System.Drawing.Point(284, 81)
        Me.txtFIPRBARR.MaxLength = 10
        Me.txtFIPRBARR.Name = "txtFIPRBARR"
        Me.txtFIPRBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRBARR.TabIndex = 8
        '
        'lblCodigoActual
        '
        Me.lblCodigoActual.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigoActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigoActual.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoActual.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoActual.Location = New System.Drawing.Point(17, 81)
        Me.lblCodigoActual.Name = "lblCodigoActual"
        Me.lblCodigoActual.Size = New System.Drawing.Size(85, 20)
        Me.lblCodigoActual.TabIndex = 27
        Me.lblCodigoActual.Text = "Código Actual"
        '
        'TabCedulaCiudadania
        '
        Me.TabCedulaCiudadania.BackColor = System.Drawing.SystemColors.Control
        Me.TabCedulaCiudadania.Controls.Add(Me.GroupBox7)
        Me.TabCedulaCiudadania.Controls.Add(Me.lblFPPRNUDO)
        Me.TabCedulaCiudadania.Controls.Add(Me.txtFPPRNUDO)
        Me.TabCedulaCiudadania.Location = New System.Drawing.Point(4, 24)
        Me.TabCedulaCiudadania.Name = "TabCedulaCiudadania"
        Me.TabCedulaCiudadania.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCedulaCiudadania.Size = New System.Drawing.Size(835, 181)
        Me.TabCedulaCiudadania.TabIndex = 1
        Me.TabCedulaCiudadania.Text = "Cedula de ciudadanía"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.cmdConsultarCedulaDeCiudadania)
        Me.GroupBox7.Location = New System.Drawing.Point(17, 107)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(801, 55)
        Me.GroupBox7.TabIndex = 302
        Me.GroupBox7.TabStop = False
        '
        'cmdConsultarCedulaDeCiudadania
        '
        Me.cmdConsultarCedulaDeCiudadania.AccessibleDescription = "Consultar"
        Me.cmdConsultarCedulaDeCiudadania.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdConsultarCedulaDeCiudadania.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdConsultarCedulaDeCiudadania.Location = New System.Drawing.Point(662, 18)
        Me.cmdConsultarCedulaDeCiudadania.Name = "cmdConsultarCedulaDeCiudadania"
        Me.cmdConsultarCedulaDeCiudadania.Size = New System.Drawing.Size(123, 23)
        Me.cmdConsultarCedulaDeCiudadania.TabIndex = 18
        Me.cmdConsultarCedulaDeCiudadania.Text = "&Consultar"
        Me.cmdConsultarCedulaDeCiudadania.UseVisualStyleBackColor = True
        '
        'lblFPPRNUDO
        '
        Me.lblFPPRNUDO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblFPPRNUDO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPPRNUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPPRNUDO.ForeColor = System.Drawing.Color.Black
        Me.lblFPPRNUDO.Location = New System.Drawing.Point(17, 13)
        Me.lblFPPRNUDO.Name = "lblFPPRNUDO"
        Me.lblFPPRNUDO.Size = New System.Drawing.Size(134, 20)
        Me.lblFPPRNUDO.TabIndex = 29
        Me.lblFPPRNUDO.Text = "Cedula de ciudadanía"
        '
        'txtFPPRNUDO
        '
        Me.txtFPPRNUDO.AccessibleDescription = "Nro. Documento"
        Me.txtFPPRNUDO.BackColor = System.Drawing.SystemColors.Window
        Me.txtFPPRNUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPPRNUDO.Location = New System.Drawing.Point(155, 13)
        Me.txtFPPRNUDO.MaxLength = 14
        Me.txtFPPRNUDO.Name = "txtFPPRNUDO"
        Me.txtFPPRNUDO.Size = New System.Drawing.Size(197, 20)
        Me.txtFPPRNUDO.TabIndex = 28
        '
        'TabMatriculaInmobiliaria
        '
        Me.TabMatriculaInmobiliaria.BackColor = System.Drawing.SystemColors.Control
        Me.TabMatriculaInmobiliaria.Controls.Add(Me.Label2)
        Me.TabMatriculaInmobiliaria.Controls.Add(Me.txtFPPRMAIN)
        Me.TabMatriculaInmobiliaria.Controls.Add(Me.GroupBox8)
        Me.TabMatriculaInmobiliaria.Controls.Add(Me.lblFPPRMAIN)
        Me.TabMatriculaInmobiliaria.Location = New System.Drawing.Point(4, 24)
        Me.TabMatriculaInmobiliaria.Name = "TabMatriculaInmobiliaria"
        Me.TabMatriculaInmobiliaria.Size = New System.Drawing.Size(835, 181)
        Me.TabMatriculaInmobiliaria.TabIndex = 2
        Me.TabMatriculaInmobiliaria.Text = "Matricula inmobiliaria"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(358, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 20)
        Me.Label2.TabIndex = 304
        Me.Label2.Text = "Ejemplo: 000-0000000"
        '
        'txtFPPRMAIN
        '
        Me.txtFPPRMAIN.AccessibleDescription = "Matricula"
        Me.txtFPPRMAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtFPPRMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPPRMAIN.Location = New System.Drawing.Point(155, 13)
        Me.txtFPPRMAIN.MaxLength = 11
        Me.txtFPPRMAIN.Name = "txtFPPRMAIN"
        Me.txtFPPRMAIN.Size = New System.Drawing.Size(197, 20)
        Me.txtFPPRMAIN.TabIndex = 30
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox8.Controls.Add(Me.cmdConsultarMatriculaInmobiliaria)
        Me.GroupBox8.Location = New System.Drawing.Point(17, 107)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(801, 55)
        Me.GroupBox8.TabIndex = 303
        Me.GroupBox8.TabStop = False
        '
        'cmdConsultarMatriculaInmobiliaria
        '
        Me.cmdConsultarMatriculaInmobiliaria.AccessibleDescription = "Consultar"
        Me.cmdConsultarMatriculaInmobiliaria.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdConsultarMatriculaInmobiliaria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdConsultarMatriculaInmobiliaria.Location = New System.Drawing.Point(662, 18)
        Me.cmdConsultarMatriculaInmobiliaria.Name = "cmdConsultarMatriculaInmobiliaria"
        Me.cmdConsultarMatriculaInmobiliaria.Size = New System.Drawing.Size(123, 23)
        Me.cmdConsultarMatriculaInmobiliaria.TabIndex = 18
        Me.cmdConsultarMatriculaInmobiliaria.Text = "&Consultar"
        Me.cmdConsultarMatriculaInmobiliaria.UseVisualStyleBackColor = True
        '
        'lblFPPRMAIN
        '
        Me.lblFPPRMAIN.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblFPPRMAIN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPPRMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPPRMAIN.ForeColor = System.Drawing.Color.Black
        Me.lblFPPRMAIN.Location = New System.Drawing.Point(17, 13)
        Me.lblFPPRMAIN.Name = "lblFPPRMAIN"
        Me.lblFPPRMAIN.Size = New System.Drawing.Size(134, 20)
        Me.lblFPPRMAIN.TabIndex = 31
        Me.lblFPPRMAIN.Text = "Matricula inmobiliaria"
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 706)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(907, 25)
        Me.strBARRESTA.TabIndex = 43
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
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.axaVisorDocumentoPDF)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(12, 444)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(881, 247)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CONSULTA"
        '
        'axaVisorDocumentoPDF
        '
        Me.axaVisorDocumentoPDF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.axaVisorDocumentoPDF.Enabled = True
        Me.axaVisorDocumentoPDF.Location = New System.Drawing.Point(3, 17)
        Me.axaVisorDocumentoPDF.Name = "axaVisorDocumentoPDF"
        Me.axaVisorDocumentoPDF.OcxState = CType(resources.GetObject("axaVisorDocumentoPDF.OcxState"), System.Windows.Forms.AxHost.State)
        Me.axaVisorDocumentoPDF.Size = New System.Drawing.Size(875, 227)
        Me.axaVisorDocumentoPDF.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.dgvCONSULTA)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(12, 323)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(878, 115)
        Me.GroupBox2.TabIndex = 59
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CEDULA CATASTRAL"
        '
        'dgvCONSULTA
        '
        Me.dgvCONSULTA.AccessibleDescription = "Consulta predio"
        Me.dgvCONSULTA.AllowUserToAddRows = False
        Me.dgvCONSULTA.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCONSULTA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCONSULTA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCONSULTA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCONSULTA.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCONSULTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCONSULTA.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCONSULTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCONSULTA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA.Location = New System.Drawing.Point(18, 20)
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        Me.dgvCONSULTA.RowHeadersVisible = False
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(843, 77)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 1
        '
        'frm_consulta_plano_predial_catastral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(907, 731)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.fraFICHPRED)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_consulta_plano_predial_catastral"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CONSULTA PLANO PREDIAL CATASTRAL"
        Me.GroupBox3.ResumeLayout(False)
        Me.fraFICHPRED.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabCedulaCatastral.ResumeLayout(False)
        Me.TabCedulaCatastral.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.TabCedulaCiudadania.ResumeLayout(False)
        Me.TabCedulaCiudadania.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.TabMatriculaInmobiliaria.ResumeLayout(False)
        Me.TabMatriculaInmobiliaria.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.axaVisorDocumentoPDF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdULTIMACONSULTA As System.Windows.Forms.Button
    Friend WithEvents cmdLIMPIAR As System.Windows.Forms.Button
    Friend WithEvents cmdConsultarCedulaCatastral As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents fraFICHPRED As System.Windows.Forms.GroupBox
    Friend WithEvents txtFIPRCLSE As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRNUFI As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtFIPRCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRMUNI As System.Windows.Forms.TextBox
    Friend WithEvents lblClaseOSector2 As System.Windows.Forms.Label
    Friend WithEvents txtFIPRUNPR As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPREDIF As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents lblUnidadPredial As System.Windows.Forms.Label
    Friend WithEvents lblEdificio As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtFIPRDIRE As System.Windows.Forms.TextBox
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents axaVisorDocumentoPDF As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents txtFPPRMAIN As System.Windows.Forms.TextBox
    Friend WithEvents lblFPPRMAIN As System.Windows.Forms.Label
    Friend WithEvents txtFPPRNUDO As System.Windows.Forms.TextBox
    Friend WithEvents lblFPPRNUDO As System.Windows.Forms.Label
    Friend WithEvents cmdVistaPredio As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabCedulaCatastral As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents TabCedulaCiudadania As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdConsultarCedulaDeCiudadania As System.Windows.Forms.Button
    Friend WithEvents TabMatriculaInmobiliaria As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdConsultarMatriculaInmobiliaria As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
