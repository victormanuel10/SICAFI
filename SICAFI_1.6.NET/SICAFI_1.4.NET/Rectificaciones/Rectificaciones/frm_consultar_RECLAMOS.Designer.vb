<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_RECLAMOS
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdExportarExcel = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdLimpiar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdConsultar = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraPERIODO = New System.Windows.Forms.GroupBox()
        Me.txtRECLSECU = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRECLMIAN = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRECLESTA = New System.Windows.Forms.TextBox()
        Me.txtRECLTITR = New System.Windows.Forms.TextBox()
        Me.txtRECLFELC = New System.Windows.Forms.TextBox()
        Me.txtRECLFEDM = New System.Windows.Forms.TextBox()
        Me.txtRECLFEED = New System.Windows.Forms.TextBox()
        Me.txtRECLFEMU = New System.Windows.Forms.TextBox()
        Me.txtRECLFEDE = New System.Windows.Forms.TextBox()
        Me.txtRECLMAIN = New System.Windows.Forms.TextBox()
        Me.txtRECLCLSE = New System.Windows.Forms.TextBox()
        Me.txtRECLVIGE = New System.Windows.Forms.TextBox()
        Me.txtRECLRADM = New System.Windows.Forms.TextBox()
        Me.txtRECLRAED = New System.Windows.Forms.TextBox()
        Me.txtRECLRAMU = New System.Windows.Forms.TextBox()
        Me.txtRECLRADE = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtRECLSEAP = New System.Windows.Forms.TextBox()
        Me.txtRECLPRAP = New System.Windows.Forms.TextBox()
        Me.txtRECLNUDO = New System.Windows.Forms.TextBox()
        Me.txtRECLNOMB = New System.Windows.Forms.TextBox()
        Me.lblNumeroDocumento = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtRECLUNPR = New System.Windows.Forms.TextBox()
        Me.txtRECLEDIF = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRECLOBSE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtRECLCORR = New System.Windows.Forms.TextBox()
        Me.txtRECLMUNI = New System.Windows.Forms.TextBox()
        Me.lblClaseOSector2 = New System.Windows.Forms.Label()
        Me.lblCategoriaDeSuelo = New System.Windows.Forms.Label()
        Me.txtRECLPRED = New System.Windows.Forms.TextBox()
        Me.txtRECLMANZ = New System.Windows.Forms.TextBox()
        Me.txtRECLBARR = New System.Windows.Forms.TextBox()
        Me.lblCodigoActual = New System.Windows.Forms.Label()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.lblManzana = New System.Windows.Forms.Label()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.dgvCONSULTA = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraPERIODO.SuspendLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdExportarExcel)
        Me.GroupBox1.Controls.Add(Me.cmdSalir)
        Me.GroupBox1.Controls.Add(Me.cmdLimpiar)
        Me.GroupBox1.Controls.Add(Me.cmdAceptar)
        Me.GroupBox1.Controls.Add(Me.cmdConsultar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 597)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(742, 60)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'cmdExportarExcel
        '
        Me.cmdExportarExcel.AccessibleDescription = "Exportar Excel"
        Me.cmdExportarExcel.AccessibleName = ""
        Me.cmdExportarExcel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExportarExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExportarExcel.Image = Global.SICAFI.My.Resources.Resources._041
        Me.cmdExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdExportarExcel.Location = New System.Drawing.Point(141, 20)
        Me.cmdExportarExcel.Name = "cmdExportarExcel"
        Me.cmdExportarExcel.Size = New System.Drawing.Size(123, 23)
        Me.cmdExportarExcel.TabIndex = 26
        Me.cmdExportarExcel.Text = "&Exportar excel"
        Me.cmdExportarExcel.UseVisualStyleBackColor = False
        '
        'cmdSalir
        '
        Me.cmdSalir.AccessibleDescription = "Salir"
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(626, 20)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(101, 23)
        Me.cmdSalir.TabIndex = 4
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdLimpiar
        '
        Me.cmdLimpiar.AccessibleDescription = "Limpiar"
        Me.cmdLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLimpiar.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLimpiar.Location = New System.Drawing.Point(19, 20)
        Me.cmdLimpiar.Name = "cmdLimpiar"
        Me.cmdLimpiar.Size = New System.Drawing.Size(116, 23)
        Me.cmdLimpiar.TabIndex = 1
        Me.cmdLimpiar.Text = "&Limpiar"
        Me.cmdLimpiar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.AccessibleDescription = "Aceptar"
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Enabled = False
        Me.cmdAceptar.Image = Global.SICAFI.My.Resources.Resources._22
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(519, 20)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(101, 23)
        Me.cmdAceptar.TabIndex = 3
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdConsultar
        '
        Me.cmdConsultar.AccessibleDescription = "Consultar"
        Me.cmdConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdConsultar.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdConsultar.Location = New System.Drawing.Point(412, 20)
        Me.cmdConsultar.Name = "cmdConsultar"
        Me.cmdConsultar.Size = New System.Drawing.Size(101, 23)
        Me.cmdConsultar.TabIndex = 2
        Me.cmdConsultar.Text = "&Consultar"
        Me.cmdConsultar.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 671)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(772, 25)
        Me.strBARRESTA.TabIndex = 81
        '
        'tstBAESVALI
        '
        Me.tstBAESVALI.AutoSize = False
        Me.tstBAESVALI.BackColor = System.Drawing.Color.White
        Me.tstBAESVALI.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tstBAESVALI.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tstBAESVALI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstBAESVALI.ForeColor = System.Drawing.Color.Black
        Me.tstBAESVALI.ImageTransparentColor = System.Drawing.Color.White
        Me.tstBAESVALI.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.tstBAESVALI.Name = "tstBAESVALI"
        Me.tstBAESVALI.Size = New System.Drawing.Size(125, 22)
        Me.tstBAESVALI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tstBAESDESC
        '
        Me.tstBAESDESC.AutoSize = False
        Me.tstBAESDESC.BackColor = System.Drawing.Color.White
        Me.tstBAESDESC.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tstBAESDESC.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tstBAESDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstBAESDESC.ForeColor = System.Drawing.Color.Black
        Me.tstBAESDESC.ImageTransparentColor = System.Drawing.Color.White
        Me.tstBAESDESC.LinkColor = System.Drawing.Color.Black
        Me.tstBAESDESC.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.tstBAESDESC.Name = "tstBAESDESC"
        Me.tstBAESDESC.Size = New System.Drawing.Size(300, 22)
        Me.tstBAESDESC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.White
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(125, 22)
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fraPERIODO
        '
        Me.fraPERIODO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fraPERIODO.BackColor = System.Drawing.SystemColors.Control
        Me.fraPERIODO.Controls.Add(Me.txtRECLSECU)
        Me.fraPERIODO.Controls.Add(Me.Label4)
        Me.fraPERIODO.Controls.Add(Me.txtRECLMIAN)
        Me.fraPERIODO.Controls.Add(Me.Label8)
        Me.fraPERIODO.Controls.Add(Me.Label3)
        Me.fraPERIODO.Controls.Add(Me.txtRECLESTA)
        Me.fraPERIODO.Controls.Add(Me.txtRECLTITR)
        Me.fraPERIODO.Controls.Add(Me.txtRECLFELC)
        Me.fraPERIODO.Controls.Add(Me.txtRECLFEDM)
        Me.fraPERIODO.Controls.Add(Me.txtRECLFEED)
        Me.fraPERIODO.Controls.Add(Me.txtRECLFEMU)
        Me.fraPERIODO.Controls.Add(Me.txtRECLFEDE)
        Me.fraPERIODO.Controls.Add(Me.txtRECLMAIN)
        Me.fraPERIODO.Controls.Add(Me.txtRECLCLSE)
        Me.fraPERIODO.Controls.Add(Me.txtRECLVIGE)
        Me.fraPERIODO.Controls.Add(Me.txtRECLRADM)
        Me.fraPERIODO.Controls.Add(Me.txtRECLRAED)
        Me.fraPERIODO.Controls.Add(Me.txtRECLRAMU)
        Me.fraPERIODO.Controls.Add(Me.txtRECLRADE)
        Me.fraPERIODO.Controls.Add(Me.Label16)
        Me.fraPERIODO.Controls.Add(Me.Label17)
        Me.fraPERIODO.Controls.Add(Me.Label19)
        Me.fraPERIODO.Controls.Add(Me.Label14)
        Me.fraPERIODO.Controls.Add(Me.Label13)
        Me.fraPERIODO.Controls.Add(Me.Label15)
        Me.fraPERIODO.Controls.Add(Me.Label12)
        Me.fraPERIODO.Controls.Add(Me.Label18)
        Me.fraPERIODO.Controls.Add(Me.Label20)
        Me.fraPERIODO.Controls.Add(Me.Label39)
        Me.fraPERIODO.Controls.Add(Me.txtRECLSEAP)
        Me.fraPERIODO.Controls.Add(Me.txtRECLPRAP)
        Me.fraPERIODO.Controls.Add(Me.txtRECLNUDO)
        Me.fraPERIODO.Controls.Add(Me.txtRECLNOMB)
        Me.fraPERIODO.Controls.Add(Me.lblNumeroDocumento)
        Me.fraPERIODO.Controls.Add(Me.Label11)
        Me.fraPERIODO.Controls.Add(Me.Label7)
        Me.fraPERIODO.Controls.Add(Me.Label9)
        Me.fraPERIODO.Controls.Add(Me.Label10)
        Me.fraPERIODO.Controls.Add(Me.txtRECLUNPR)
        Me.fraPERIODO.Controls.Add(Me.txtRECLEDIF)
        Me.fraPERIODO.Controls.Add(Me.Label1)
        Me.fraPERIODO.Controls.Add(Me.Label6)
        Me.fraPERIODO.Controls.Add(Me.Label5)
        Me.fraPERIODO.Controls.Add(Me.txtRECLOBSE)
        Me.fraPERIODO.Controls.Add(Me.Label2)
        Me.fraPERIODO.Controls.Add(Me.Label33)
        Me.fraPERIODO.Controls.Add(Me.txtRECLCORR)
        Me.fraPERIODO.Controls.Add(Me.txtRECLMUNI)
        Me.fraPERIODO.Controls.Add(Me.lblClaseOSector2)
        Me.fraPERIODO.Controls.Add(Me.lblCategoriaDeSuelo)
        Me.fraPERIODO.Controls.Add(Me.txtRECLPRED)
        Me.fraPERIODO.Controls.Add(Me.txtRECLMANZ)
        Me.fraPERIODO.Controls.Add(Me.txtRECLBARR)
        Me.fraPERIODO.Controls.Add(Me.lblCodigoActual)
        Me.fraPERIODO.Controls.Add(Me.lblPredio)
        Me.fraPERIODO.Controls.Add(Me.lblManzana)
        Me.fraPERIODO.Controls.Add(Me.lblBarrio)
        Me.fraPERIODO.Controls.Add(Me.lblCorregimiento)
        Me.fraPERIODO.Controls.Add(Me.lblMunicipio)
        Me.fraPERIODO.Controls.Add(Me.lblCodigo)
        Me.fraPERIODO.Controls.Add(Me.dgvCONSULTA)
        Me.fraPERIODO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPERIODO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPERIODO.Location = New System.Drawing.Point(12, 7)
        Me.fraPERIODO.Name = "fraPERIODO"
        Me.fraPERIODO.Size = New System.Drawing.Size(742, 587)
        Me.fraPERIODO.TabIndex = 1
        Me.fraPERIODO.TabStop = False
        Me.fraPERIODO.Text = "CONSULTA RECTIFICACIÓN"
        '
        'txtRECLSECU
        '
        Me.txtRECLSECU.AccessibleDescription = "Predio "
        Me.txtRECLSECU.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLSECU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLSECU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLSECU.ForeColor = System.Drawing.Color.Black
        Me.txtRECLSECU.Location = New System.Drawing.Point(462, 95)
        Me.txtRECLSECU.MaxLength = 4
        Me.txtRECLSECU.Name = "txtRECLSECU"
        Me.txtRECLSECU.Size = New System.Drawing.Size(85, 20)
        Me.txtRECLSECU.TabIndex = 483
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(374, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 20)
        Me.Label4.TabIndex = 484
        Me.Label4.Text = "Nro. expediente"
        '
        'txtRECLMIAN
        '
        Me.txtRECLMIAN.AccessibleDescription = "Matricula anexa"
        Me.txtRECLMIAN.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLMIAN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLMIAN.ForeColor = System.Drawing.Color.Black
        Me.txtRECLMIAN.Location = New System.Drawing.Point(550, 188)
        Me.txtRECLMIAN.MaxLength = 50
        Me.txtRECLMIAN.Name = "txtRECLMIAN"
        Me.txtRECLMIAN.Size = New System.Drawing.Size(172, 20)
        Me.txtRECLMIAN.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(374, 188)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(173, 20)
        Me.Label8.TabIndex = 482
        Me.Label8.Text = "Matricula inmobiliaria anexa"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(638, 210)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 15)
        Me.Label3.TabIndex = 472
        Me.Label3.Text = "(dd-mm-aaaa)"
        '
        'txtRECLESTA
        '
        Me.txtRECLESTA.AccessibleDescription = "Estado"
        Me.txtRECLESTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLESTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtRECLESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLESTA.ForeColor = System.Drawing.Color.Black
        Me.txtRECLESTA.Location = New System.Drawing.Point(550, 324)
        Me.txtRECLESTA.MaxLength = 2
        Me.txtRECLESTA.Name = "txtRECLESTA"
        Me.txtRECLESTA.Size = New System.Drawing.Size(172, 20)
        Me.txtRECLESTA.TabIndex = 26
        '
        'txtRECLTITR
        '
        Me.txtRECLTITR.AccessibleDescription = "Tipo de tramite"
        Me.txtRECLTITR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLTITR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLTITR.ForeColor = System.Drawing.Color.Black
        Me.txtRECLTITR.Location = New System.Drawing.Point(197, 324)
        Me.txtRECLTITR.MaxLength = 3
        Me.txtRECLTITR.Name = "txtRECLTITR"
        Me.txtRECLTITR.Size = New System.Drawing.Size(173, 20)
        Me.txtRECLTITR.TabIndex = 25
        '
        'txtRECLFELC
        '
        Me.txtRECLFELC.AccessibleDescription = "Fecha radicado"
        Me.txtRECLFELC.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLFELC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLFELC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLFELC.ForeColor = System.Drawing.Color.Black
        Me.txtRECLFELC.Location = New System.Drawing.Point(462, 301)
        Me.txtRECLFELC.MaxLength = 10
        Me.txtRECLFELC.Name = "txtRECLFELC"
        Me.txtRECLFELC.Size = New System.Drawing.Size(172, 20)
        Me.txtRECLFELC.TabIndex = 24
        '
        'txtRECLFEDM
        '
        Me.txtRECLFEDM.AccessibleDescription = "Fecha radicado"
        Me.txtRECLFEDM.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLFEDM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLFEDM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLFEDM.ForeColor = System.Drawing.Color.Black
        Me.txtRECLFEDM.Location = New System.Drawing.Point(462, 279)
        Me.txtRECLFEDM.MaxLength = 10
        Me.txtRECLFEDM.Name = "txtRECLFEDM"
        Me.txtRECLFEDM.Size = New System.Drawing.Size(172, 20)
        Me.txtRECLFEDM.TabIndex = 23
        '
        'txtRECLFEED
        '
        Me.txtRECLFEED.AccessibleDescription = "Fecha radicado"
        Me.txtRECLFEED.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLFEED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLFEED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLFEED.ForeColor = System.Drawing.Color.Black
        Me.txtRECLFEED.Location = New System.Drawing.Point(462, 256)
        Me.txtRECLFEED.MaxLength = 10
        Me.txtRECLFEED.Name = "txtRECLFEED"
        Me.txtRECLFEED.Size = New System.Drawing.Size(172, 20)
        Me.txtRECLFEED.TabIndex = 21
        '
        'txtRECLFEMU
        '
        Me.txtRECLFEMU.AccessibleDescription = "Fecha radicado"
        Me.txtRECLFEMU.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLFEMU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLFEMU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLFEMU.ForeColor = System.Drawing.Color.Black
        Me.txtRECLFEMU.Location = New System.Drawing.Point(462, 233)
        Me.txtRECLFEMU.MaxLength = 10
        Me.txtRECLFEMU.Name = "txtRECLFEMU"
        Me.txtRECLFEMU.Size = New System.Drawing.Size(172, 20)
        Me.txtRECLFEMU.TabIndex = 19
        '
        'txtRECLFEDE
        '
        Me.txtRECLFEDE.AccessibleDescription = "Fecha radicado"
        Me.txtRECLFEDE.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLFEDE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLFEDE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLFEDE.ForeColor = System.Drawing.Color.Black
        Me.txtRECLFEDE.Location = New System.Drawing.Point(462, 210)
        Me.txtRECLFEDE.MaxLength = 10
        Me.txtRECLFEDE.Name = "txtRECLFEDE"
        Me.txtRECLFEDE.Size = New System.Drawing.Size(172, 20)
        Me.txtRECLFEDE.TabIndex = 17
        '
        'txtRECLMAIN
        '
        Me.txtRECLMAIN.AccessibleDescription = "Matricula"
        Me.txtRECLMAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLMAIN.ForeColor = System.Drawing.Color.Black
        Me.txtRECLMAIN.Location = New System.Drawing.Point(197, 187)
        Me.txtRECLMAIN.MaxLength = 11
        Me.txtRECLMAIN.Name = "txtRECLMAIN"
        Me.txtRECLMAIN.Size = New System.Drawing.Size(174, 20)
        Me.txtRECLMAIN.TabIndex = 14
        '
        'txtRECLCLSE
        '
        Me.txtRECLCLSE.AccessibleDescription = "Municipio"
        Me.txtRECLCLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLCLSE.Location = New System.Drawing.Point(110, 95)
        Me.txtRECLCLSE.MaxLength = 1
        Me.txtRECLCLSE.Name = "txtRECLCLSE"
        Me.txtRECLCLSE.Size = New System.Drawing.Size(85, 20)
        Me.txtRECLCLSE.TabIndex = 8
        '
        'txtRECLVIGE
        '
        Me.txtRECLVIGE.AccessibleDescription = "Predio "
        Me.txtRECLVIGE.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLVIGE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLVIGE.ForeColor = System.Drawing.Color.Black
        Me.txtRECLVIGE.Location = New System.Drawing.Point(286, 95)
        Me.txtRECLVIGE.MaxLength = 4
        Me.txtRECLVIGE.Name = "txtRECLVIGE"
        Me.txtRECLVIGE.Size = New System.Drawing.Size(85, 20)
        Me.txtRECLVIGE.TabIndex = 9
        '
        'txtRECLRADM
        '
        Me.txtRECLRADM.AccessibleDescription = "Radicado"
        Me.txtRECLRADM.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLRADM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLRADM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLRADM.ForeColor = System.Drawing.Color.Black
        Me.txtRECLRADM.Location = New System.Drawing.Point(286, 279)
        Me.txtRECLRADM.MaxLength = 8
        Me.txtRECLRADM.Name = "txtRECLRADM"
        Me.txtRECLRADM.Size = New System.Drawing.Size(85, 20)
        Me.txtRECLRADM.TabIndex = 22
        '
        'txtRECLRAED
        '
        Me.txtRECLRAED.AccessibleDescription = "Radicado"
        Me.txtRECLRAED.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLRAED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLRAED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLRAED.ForeColor = System.Drawing.Color.Black
        Me.txtRECLRAED.Location = New System.Drawing.Point(286, 256)
        Me.txtRECLRAED.MaxLength = 8
        Me.txtRECLRAED.Name = "txtRECLRAED"
        Me.txtRECLRAED.Size = New System.Drawing.Size(85, 20)
        Me.txtRECLRAED.TabIndex = 20
        '
        'txtRECLRAMU
        '
        Me.txtRECLRAMU.AccessibleDescription = "Radicado"
        Me.txtRECLRAMU.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLRAMU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLRAMU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLRAMU.ForeColor = System.Drawing.Color.Black
        Me.txtRECLRAMU.Location = New System.Drawing.Point(286, 233)
        Me.txtRECLRAMU.MaxLength = 8
        Me.txtRECLRAMU.Name = "txtRECLRAMU"
        Me.txtRECLRAMU.Size = New System.Drawing.Size(85, 20)
        Me.txtRECLRAMU.TabIndex = 18
        '
        'txtRECLRADE
        '
        Me.txtRECLRADE.AccessibleDescription = "Radicado"
        Me.txtRECLRADE.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLRADE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLRADE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLRADE.ForeColor = System.Drawing.Color.Black
        Me.txtRECLRADE.Location = New System.Drawing.Point(286, 210)
        Me.txtRECLRADE.MaxLength = 8
        Me.txtRECLRADE.Name = "txtRECLRADE"
        Me.txtRECLRADE.Size = New System.Drawing.Size(85, 20)
        Me.txtRECLRADE.TabIndex = 16
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(19, 324)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(175, 20)
        Me.Label16.TabIndex = 471
        Me.Label16.Text = "Tipo de tramite"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(19, 301)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(440, 20)
        Me.Label17.TabIndex = 470
        Me.Label17.Text = "Fecha de recibido"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(374, 279)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 20)
        Me.Label19.TabIndex = 469
        Me.Label19.Text = "Fecha"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(374, 256)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 20)
        Me.Label14.TabIndex = 468
        Me.Label14.Text = "Fecha"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(374, 233)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 20)
        Me.Label13.TabIndex = 467
        Me.Label13.Text = "Fecha"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(19, 256)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(264, 20)
        Me.Label15.TabIndex = 466
        Me.Label15.Text = "Radicado de tramite DSIC. (OVC)"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(374, 210)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 20)
        Me.Label12.TabIndex = 465
        Me.Label12.Text = "Fecha"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(19, 233)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(264, 20)
        Me.Label18.TabIndex = 463
        Me.Label18.Text = "Radicado de solicitud al Municipio de Envigado"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(19, 279)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(264, 20)
        Me.Label20.TabIndex = 464
        Me.Label20.Text = "Radicado de devolución"
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label39.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(19, 210)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(264, 20)
        Me.Label39.TabIndex = 462
        Me.Label39.Text = "Radicado de solicitud a la DSIC"
        '
        'txtRECLSEAP
        '
        Me.txtRECLSEAP.AccessibleDescription = "Segundo apellido"
        Me.txtRECLSEAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLSEAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLSEAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLSEAP.ForeColor = System.Drawing.Color.Black
        Me.txtRECLSEAP.Location = New System.Drawing.Point(550, 164)
        Me.txtRECLSEAP.MaxLength = 20
        Me.txtRECLSEAP.Name = "txtRECLSEAP"
        Me.txtRECLSEAP.Size = New System.Drawing.Size(172, 20)
        Me.txtRECLSEAP.TabIndex = 13
        '
        'txtRECLPRAP
        '
        Me.txtRECLPRAP.AccessibleDescription = "Primer apellido"
        Me.txtRECLPRAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLPRAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLPRAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLPRAP.ForeColor = System.Drawing.Color.Black
        Me.txtRECLPRAP.Location = New System.Drawing.Point(198, 164)
        Me.txtRECLPRAP.MaxLength = 20
        Me.txtRECLPRAP.Name = "txtRECLPRAP"
        Me.txtRECLPRAP.Size = New System.Drawing.Size(172, 20)
        Me.txtRECLPRAP.TabIndex = 12
        '
        'txtRECLNUDO
        '
        Me.txtRECLNUDO.AccessibleDescription = "Nro. Documento"
        Me.txtRECLNUDO.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLNUDO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLNUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLNUDO.ForeColor = System.Drawing.Color.Black
        Me.txtRECLNUDO.Location = New System.Drawing.Point(110, 118)
        Me.txtRECLNUDO.MaxLength = 49
        Me.txtRECLNUDO.Name = "txtRECLNUDO"
        Me.txtRECLNUDO.Size = New System.Drawing.Size(173, 20)
        Me.txtRECLNUDO.TabIndex = 10
        '
        'txtRECLNOMB
        '
        Me.txtRECLNOMB.AccessibleDescription = "Nombre"
        Me.txtRECLNOMB.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLNOMB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLNOMB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLNOMB.ForeColor = System.Drawing.Color.Black
        Me.txtRECLNOMB.Location = New System.Drawing.Point(198, 141)
        Me.txtRECLNOMB.MaxLength = 50
        Me.txtRECLNOMB.Name = "txtRECLNOMB"
        Me.txtRECLNOMB.Size = New System.Drawing.Size(524, 20)
        Me.txtRECLNOMB.TabIndex = 11
        '
        'lblNumeroDocumento
        '
        Me.lblNumeroDocumento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblNumeroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumeroDocumento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroDocumento.ForeColor = System.Drawing.Color.Black
        Me.lblNumeroDocumento.Location = New System.Drawing.Point(19, 118)
        Me.lblNumeroDocumento.Name = "lblNumeroDocumento"
        Me.lblNumeroDocumento.Size = New System.Drawing.Size(85, 20)
        Me.lblNumeroDocumento.TabIndex = 457
        Me.lblNumeroDocumento.Text = "Nro Documento"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(19, 187)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(175, 20)
        Me.Label11.TabIndex = 461
        Me.Label11.Text = "Matricula inmobiliaria"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(19, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(176, 20)
        Me.Label7.TabIndex = 458
        Me.Label7.Text = "Nombre (S)"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(19, 164)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(176, 20)
        Me.Label9.TabIndex = 459
        Me.Label9.Text = "Primer Apellido"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(374, 164)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(173, 20)
        Me.Label10.TabIndex = 460
        Me.Label10.Text = "Segundo Apellido"
        '
        'txtRECLUNPR
        '
        Me.txtRECLUNPR.AccessibleDescription = "Unidad predial"
        Me.txtRECLUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtRECLUNPR.Location = New System.Drawing.Point(638, 72)
        Me.txtRECLUNPR.MaxLength = 5
        Me.txtRECLUNPR.Name = "txtRECLUNPR"
        Me.txtRECLUNPR.Size = New System.Drawing.Size(85, 20)
        Me.txtRECLUNPR.TabIndex = 7
        '
        'txtRECLEDIF
        '
        Me.txtRECLEDIF.AccessibleDescription = "Edificio"
        Me.txtRECLEDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLEDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLEDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLEDIF.ForeColor = System.Drawing.Color.Black
        Me.txtRECLEDIF.Location = New System.Drawing.Point(550, 72)
        Me.txtRECLEDIF.MaxLength = 3
        Me.txtRECLEDIF.Name = "txtRECLEDIF"
        Me.txtRECLEDIF.Size = New System.Drawing.Size(85, 20)
        Me.txtRECLEDIF.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(638, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 20)
        Me.Label1.TabIndex = 456
        Me.Label1.Text = "Unidad Predial"
        '
        'Label6
        '
        Me.Label6.AccessibleDescription = ""
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(550, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 20)
        Me.Label6.TabIndex = 455
        Me.Label6.Text = "Edificio"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 347)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(703, 20)
        Me.Label5.TabIndex = 454
        Me.Label5.Text = "OBSERVACIONES"
        '
        'txtRECLOBSE
        '
        Me.txtRECLOBSE.AccessibleDescription = "Observaciones"
        Me.txtRECLOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtRECLOBSE.Location = New System.Drawing.Point(17, 370)
        Me.txtRECLOBSE.MaxLength = 1000
        Me.txtRECLOBSE.Name = "txtRECLOBSE"
        Me.txtRECLOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRECLOBSE.Size = New System.Drawing.Size(705, 20)
        Me.txtRECLOBSE.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(374, 324)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(173, 20)
        Me.Label2.TabIndex = 452
        Me.Label2.Text = "Estado"
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(19, 26)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(703, 20)
        Me.Label33.TabIndex = 449
        Me.Label33.Text = "CEDULA CATASTRAL ACTUAL"
        '
        'txtRECLCORR
        '
        Me.txtRECLCORR.AccessibleDescription = "Corregimiento"
        Me.txtRECLCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLCORR.Location = New System.Drawing.Point(198, 72)
        Me.txtRECLCORR.MaxLength = 2
        Me.txtRECLCORR.Name = "txtRECLCORR"
        Me.txtRECLCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtRECLCORR.TabIndex = 2
        '
        'txtRECLMUNI
        '
        Me.txtRECLMUNI.AccessibleDescription = "Municipio"
        Me.txtRECLMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLMUNI.Location = New System.Drawing.Point(110, 72)
        Me.txtRECLMUNI.MaxLength = 3
        Me.txtRECLMUNI.Name = "txtRECLMUNI"
        Me.txtRECLMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtRECLMUNI.TabIndex = 1
        '
        'lblClaseOSector2
        '
        Me.lblClaseOSector2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseOSector2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseOSector2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseOSector2.ForeColor = System.Drawing.Color.Black
        Me.lblClaseOSector2.Location = New System.Drawing.Point(19, 95)
        Me.lblClaseOSector2.Name = "lblClaseOSector2"
        Me.lblClaseOSector2.Size = New System.Drawing.Size(85, 20)
        Me.lblClaseOSector2.TabIndex = 446
        Me.lblClaseOSector2.Text = "Clase o Sector"
        '
        'lblCategoriaDeSuelo
        '
        Me.lblCategoriaDeSuelo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCategoriaDeSuelo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCategoriaDeSuelo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoriaDeSuelo.ForeColor = System.Drawing.Color.Black
        Me.lblCategoriaDeSuelo.Location = New System.Drawing.Point(198, 95)
        Me.lblCategoriaDeSuelo.Name = "lblCategoriaDeSuelo"
        Me.lblCategoriaDeSuelo.Size = New System.Drawing.Size(85, 20)
        Me.lblCategoriaDeSuelo.TabIndex = 445
        Me.lblCategoriaDeSuelo.Text = "Vigencia"
        '
        'txtRECLPRED
        '
        Me.txtRECLPRED.AccessibleDescription = "Predio "
        Me.txtRECLPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLPRED.ForeColor = System.Drawing.Color.Black
        Me.txtRECLPRED.Location = New System.Drawing.Point(462, 72)
        Me.txtRECLPRED.MaxLength = 5
        Me.txtRECLPRED.Name = "txtRECLPRED"
        Me.txtRECLPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtRECLPRED.TabIndex = 5
        '
        'txtRECLMANZ
        '
        Me.txtRECLMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtRECLMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtRECLMANZ.Location = New System.Drawing.Point(374, 72)
        Me.txtRECLMANZ.MaxLength = 3
        Me.txtRECLMANZ.Name = "txtRECLMANZ"
        Me.txtRECLMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtRECLMANZ.TabIndex = 4
        '
        'txtRECLBARR
        '
        Me.txtRECLBARR.AccessibleDescription = "Barrio "
        Me.txtRECLBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRECLBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRECLBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLBARR.ForeColor = System.Drawing.Color.Black
        Me.txtRECLBARR.Location = New System.Drawing.Point(286, 72)
        Me.txtRECLBARR.MaxLength = 3
        Me.txtRECLBARR.Name = "txtRECLBARR"
        Me.txtRECLBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtRECLBARR.TabIndex = 3
        '
        'lblCodigoActual
        '
        Me.lblCodigoActual.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigoActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigoActual.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoActual.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoActual.Location = New System.Drawing.Point(19, 72)
        Me.lblCodigoActual.Name = "lblCodigoActual"
        Me.lblCodigoActual.Size = New System.Drawing.Size(85, 20)
        Me.lblCodigoActual.TabIndex = 443
        Me.lblCodigoActual.Text = "Código Actual"
        '
        'lblPredio
        '
        Me.lblPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredio.ForeColor = System.Drawing.Color.Black
        Me.lblPredio.Location = New System.Drawing.Point(462, 49)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(84, 20)
        Me.lblPredio.TabIndex = 440
        Me.lblPredio.Text = "Predio"
        '
        'lblManzana
        '
        Me.lblManzana.AccessibleDescription = ""
        Me.lblManzana.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblManzana.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblManzana.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManzana.ForeColor = System.Drawing.Color.Black
        Me.lblManzana.Location = New System.Drawing.Point(374, 49)
        Me.lblManzana.Name = "lblManzana"
        Me.lblManzana.Size = New System.Drawing.Size(84, 20)
        Me.lblManzana.TabIndex = 437
        Me.lblManzana.Text = "Manza / Vered"
        '
        'lblBarrio
        '
        Me.lblBarrio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblBarrio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBarrio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarrio.ForeColor = System.Drawing.Color.Black
        Me.lblBarrio.Location = New System.Drawing.Point(286, 49)
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Size = New System.Drawing.Size(84, 20)
        Me.lblBarrio.TabIndex = 436
        Me.lblBarrio.Text = "Barrio"
        '
        'lblCorregimiento
        '
        Me.lblCorregimiento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCorregimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorregimiento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorregimiento.ForeColor = System.Drawing.Color.Black
        Me.lblCorregimiento.Location = New System.Drawing.Point(198, 49)
        Me.lblCorregimiento.Name = "lblCorregimiento"
        Me.lblCorregimiento.Size = New System.Drawing.Size(84, 20)
        Me.lblCorregimiento.TabIndex = 444
        Me.lblCorregimiento.Text = "Corregimiento"
        '
        'lblMunicipio
        '
        Me.lblMunicipio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblMunicipio.Location = New System.Drawing.Point(110, 49)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(84, 20)
        Me.lblMunicipio.TabIndex = 450
        Me.lblMunicipio.Text = "Municipio"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(19, 49)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(85, 20)
        Me.lblCodigo.TabIndex = 451
        Me.lblCodigo.Text = "CODIGO"
        '
        'dgvCONSULTA
        '
        Me.dgvCONSULTA.AccessibleDescription = ""
        Me.dgvCONSULTA.AllowUserToAddRows = False
        Me.dgvCONSULTA.AllowUserToDeleteRows = False
        Me.dgvCONSULTA.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCONSULTA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCONSULTA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCONSULTA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCONSULTA.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCONSULTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCONSULTA.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCONSULTA.ColumnHeadersHeight = 30
        Me.dgvCONSULTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCONSULTA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA.Location = New System.Drawing.Point(19, 396)
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        Me.dgvCONSULTA.RowHeadersVisible = False
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(703, 175)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 40
        '
        'frm_consultar_RECLAMOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 696)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraPERIODO)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(788, 732)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(788, 732)
        Me.Name = "frm_consultar_RECLAMOS"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraPERIODO.ResumeLayout(False)
        Me.fraPERIODO.PerformLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents cmdLimpiar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdConsultar As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraPERIODO As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents txtRECLCLSE As System.Windows.Forms.TextBox
    Friend WithEvents txtRECLVIGE As System.Windows.Forms.TextBox
    Friend WithEvents txtRECLRADM As System.Windows.Forms.TextBox
    Friend WithEvents txtRECLRAED As System.Windows.Forms.TextBox
    Friend WithEvents txtRECLRAMU As System.Windows.Forms.TextBox
    Friend WithEvents txtRECLRADE As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtRECLSEAP As System.Windows.Forms.TextBox
    Friend WithEvents txtRECLPRAP As System.Windows.Forms.TextBox
    Friend WithEvents txtRECLNUDO As System.Windows.Forms.TextBox
    Friend WithEvents txtRECLNOMB As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRECLUNPR As System.Windows.Forms.TextBox
    Friend WithEvents txtRECLEDIF As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRECLOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtRECLCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtRECLMUNI As System.Windows.Forms.TextBox
    Friend WithEvents lblClaseOSector2 As System.Windows.Forms.Label
    Friend WithEvents lblCategoriaDeSuelo As System.Windows.Forms.Label
    Friend WithEvents txtRECLPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtRECLMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtRECLBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtRECLFELC As System.Windows.Forms.TextBox
    Friend WithEvents txtRECLFEDM As System.Windows.Forms.TextBox
    Friend WithEvents txtRECLFEED As System.Windows.Forms.TextBox
    Friend WithEvents txtRECLFEMU As System.Windows.Forms.TextBox
    Friend WithEvents txtRECLFEDE As System.Windows.Forms.TextBox
    Friend WithEvents txtRECLMAIN As System.Windows.Forms.TextBox
    Friend WithEvents txtRECLESTA As System.Windows.Forms.TextBox
    Friend WithEvents txtRECLTITR As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdExportarExcel As System.Windows.Forms.Button
    Friend WithEvents txtRECLMIAN As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRECLSECU As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
