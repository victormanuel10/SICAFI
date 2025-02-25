<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_REVIAVAL
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.txtREAVSECU = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtREAVMIAN = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtREAVESTA = New System.Windows.Forms.TextBox()
        Me.txtREAVTITR = New System.Windows.Forms.TextBox()
        Me.txtREAVFELC = New System.Windows.Forms.TextBox()
        Me.txtREAVFEDM = New System.Windows.Forms.TextBox()
        Me.txtREAVFEED = New System.Windows.Forms.TextBox()
        Me.txtREAVFEMU = New System.Windows.Forms.TextBox()
        Me.txtREAVFEDE = New System.Windows.Forms.TextBox()
        Me.txtREAVMAIN = New System.Windows.Forms.TextBox()
        Me.txtREAVCLSE = New System.Windows.Forms.TextBox()
        Me.txtREAVVIGE = New System.Windows.Forms.TextBox()
        Me.txtREAVRADM = New System.Windows.Forms.TextBox()
        Me.txtREAVRAED = New System.Windows.Forms.TextBox()
        Me.txtREAVRAMU = New System.Windows.Forms.TextBox()
        Me.txtREAVRADE = New System.Windows.Forms.TextBox()
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
        Me.txtREAVSEAP = New System.Windows.Forms.TextBox()
        Me.txtREAVPRAP = New System.Windows.Forms.TextBox()
        Me.txtREAVNUDO = New System.Windows.Forms.TextBox()
        Me.txtREAVNOMB = New System.Windows.Forms.TextBox()
        Me.lblNumeroDocumento = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtREAVUNPR = New System.Windows.Forms.TextBox()
        Me.txtREAVEDIF = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtREAVOBSE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtREAVCORR = New System.Windows.Forms.TextBox()
        Me.txtREAVMUNI = New System.Windows.Forms.TextBox()
        Me.lblClaseOSector2 = New System.Windows.Forms.Label()
        Me.lblCategoriaDeSuelo = New System.Windows.Forms.Label()
        Me.txtREAVPRED = New System.Windows.Forms.TextBox()
        Me.txtREAVMANZ = New System.Windows.Forms.TextBox()
        Me.txtREAVBARR = New System.Windows.Forms.TextBox()
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
        Me.GroupBox1.Size = New System.Drawing.Size(748, 60)
        Me.GroupBox1.TabIndex = 83
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
        Me.cmdSalir.Location = New System.Drawing.Point(632, 20)
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
        Me.cmdAceptar.Location = New System.Drawing.Point(525, 20)
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
        Me.cmdConsultar.Location = New System.Drawing.Point(418, 20)
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
        Me.strBARRESTA.TabIndex = 84
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
        Me.fraPERIODO.Controls.Add(Me.txtREAVSECU)
        Me.fraPERIODO.Controls.Add(Me.Label4)
        Me.fraPERIODO.Controls.Add(Me.txtREAVMIAN)
        Me.fraPERIODO.Controls.Add(Me.Label8)
        Me.fraPERIODO.Controls.Add(Me.Label3)
        Me.fraPERIODO.Controls.Add(Me.txtREAVESTA)
        Me.fraPERIODO.Controls.Add(Me.txtREAVTITR)
        Me.fraPERIODO.Controls.Add(Me.txtREAVFELC)
        Me.fraPERIODO.Controls.Add(Me.txtREAVFEDM)
        Me.fraPERIODO.Controls.Add(Me.txtREAVFEED)
        Me.fraPERIODO.Controls.Add(Me.txtREAVFEMU)
        Me.fraPERIODO.Controls.Add(Me.txtREAVFEDE)
        Me.fraPERIODO.Controls.Add(Me.txtREAVMAIN)
        Me.fraPERIODO.Controls.Add(Me.txtREAVCLSE)
        Me.fraPERIODO.Controls.Add(Me.txtREAVVIGE)
        Me.fraPERIODO.Controls.Add(Me.txtREAVRADM)
        Me.fraPERIODO.Controls.Add(Me.txtREAVRAED)
        Me.fraPERIODO.Controls.Add(Me.txtREAVRAMU)
        Me.fraPERIODO.Controls.Add(Me.txtREAVRADE)
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
        Me.fraPERIODO.Controls.Add(Me.txtREAVSEAP)
        Me.fraPERIODO.Controls.Add(Me.txtREAVPRAP)
        Me.fraPERIODO.Controls.Add(Me.txtREAVNUDO)
        Me.fraPERIODO.Controls.Add(Me.txtREAVNOMB)
        Me.fraPERIODO.Controls.Add(Me.lblNumeroDocumento)
        Me.fraPERIODO.Controls.Add(Me.Label11)
        Me.fraPERIODO.Controls.Add(Me.Label7)
        Me.fraPERIODO.Controls.Add(Me.Label9)
        Me.fraPERIODO.Controls.Add(Me.Label10)
        Me.fraPERIODO.Controls.Add(Me.txtREAVUNPR)
        Me.fraPERIODO.Controls.Add(Me.txtREAVEDIF)
        Me.fraPERIODO.Controls.Add(Me.Label1)
        Me.fraPERIODO.Controls.Add(Me.Label6)
        Me.fraPERIODO.Controls.Add(Me.Label5)
        Me.fraPERIODO.Controls.Add(Me.txtREAVOBSE)
        Me.fraPERIODO.Controls.Add(Me.Label2)
        Me.fraPERIODO.Controls.Add(Me.Label33)
        Me.fraPERIODO.Controls.Add(Me.txtREAVCORR)
        Me.fraPERIODO.Controls.Add(Me.txtREAVMUNI)
        Me.fraPERIODO.Controls.Add(Me.lblClaseOSector2)
        Me.fraPERIODO.Controls.Add(Me.lblCategoriaDeSuelo)
        Me.fraPERIODO.Controls.Add(Me.txtREAVPRED)
        Me.fraPERIODO.Controls.Add(Me.txtREAVMANZ)
        Me.fraPERIODO.Controls.Add(Me.txtREAVBARR)
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
        Me.fraPERIODO.TabIndex = 82
        Me.fraPERIODO.TabStop = False
        Me.fraPERIODO.Text = "CONSULTA REVISIÓN DE AVALÚO"
        '
        'txtREAVSECU
        '
        Me.txtREAVSECU.AccessibleDescription = "Predio "
        Me.txtREAVSECU.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVSECU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVSECU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVSECU.ForeColor = System.Drawing.Color.Black
        Me.txtREAVSECU.Location = New System.Drawing.Point(462, 95)
        Me.txtREAVSECU.MaxLength = 4
        Me.txtREAVSECU.Name = "txtREAVSECU"
        Me.txtREAVSECU.Size = New System.Drawing.Size(85, 20)
        Me.txtREAVSECU.TabIndex = 483
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
        'txtREAVMIAN
        '
        Me.txtREAVMIAN.AccessibleDescription = "Matricula anexa"
        Me.txtREAVMIAN.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVMIAN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVMIAN.ForeColor = System.Drawing.Color.Black
        Me.txtREAVMIAN.Location = New System.Drawing.Point(462, 188)
        Me.txtREAVMIAN.MaxLength = 50
        Me.txtREAVMIAN.Name = "txtREAVMIAN"
        Me.txtREAVMIAN.Size = New System.Drawing.Size(260, 20)
        Me.txtREAVMIAN.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(286, 188)
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
        'txtREAVESTA
        '
        Me.txtREAVESTA.AccessibleDescription = "Estado"
        Me.txtREAVESTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVESTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtREAVESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVESTA.ForeColor = System.Drawing.Color.Black
        Me.txtREAVESTA.Location = New System.Drawing.Point(550, 324)
        Me.txtREAVESTA.MaxLength = 2
        Me.txtREAVESTA.Name = "txtREAVESTA"
        Me.txtREAVESTA.Size = New System.Drawing.Size(172, 20)
        Me.txtREAVESTA.TabIndex = 26
        '
        'txtREAVTITR
        '
        Me.txtREAVTITR.AccessibleDescription = "Tipo de tramite"
        Me.txtREAVTITR.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVTITR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVTITR.ForeColor = System.Drawing.Color.Black
        Me.txtREAVTITR.Location = New System.Drawing.Point(197, 324)
        Me.txtREAVTITR.MaxLength = 3
        Me.txtREAVTITR.Name = "txtREAVTITR"
        Me.txtREAVTITR.Size = New System.Drawing.Size(173, 20)
        Me.txtREAVTITR.TabIndex = 25
        '
        'txtREAVFELC
        '
        Me.txtREAVFELC.AccessibleDescription = "Fecha radicado"
        Me.txtREAVFELC.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVFELC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVFELC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVFELC.ForeColor = System.Drawing.Color.Black
        Me.txtREAVFELC.Location = New System.Drawing.Point(462, 301)
        Me.txtREAVFELC.MaxLength = 10
        Me.txtREAVFELC.Name = "txtREAVFELC"
        Me.txtREAVFELC.Size = New System.Drawing.Size(172, 20)
        Me.txtREAVFELC.TabIndex = 24
        '
        'txtREAVFEDM
        '
        Me.txtREAVFEDM.AccessibleDescription = "Fecha radicado"
        Me.txtREAVFEDM.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVFEDM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVFEDM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVFEDM.ForeColor = System.Drawing.Color.Black
        Me.txtREAVFEDM.Location = New System.Drawing.Point(462, 279)
        Me.txtREAVFEDM.MaxLength = 10
        Me.txtREAVFEDM.Name = "txtREAVFEDM"
        Me.txtREAVFEDM.Size = New System.Drawing.Size(172, 20)
        Me.txtREAVFEDM.TabIndex = 23
        '
        'txtREAVFEED
        '
        Me.txtREAVFEED.AccessibleDescription = "Fecha radicado"
        Me.txtREAVFEED.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVFEED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVFEED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVFEED.ForeColor = System.Drawing.Color.Black
        Me.txtREAVFEED.Location = New System.Drawing.Point(462, 256)
        Me.txtREAVFEED.MaxLength = 10
        Me.txtREAVFEED.Name = "txtREAVFEED"
        Me.txtREAVFEED.Size = New System.Drawing.Size(172, 20)
        Me.txtREAVFEED.TabIndex = 21
        '
        'txtREAVFEMU
        '
        Me.txtREAVFEMU.AccessibleDescription = "Fecha radicado"
        Me.txtREAVFEMU.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVFEMU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVFEMU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVFEMU.ForeColor = System.Drawing.Color.Black
        Me.txtREAVFEMU.Location = New System.Drawing.Point(462, 233)
        Me.txtREAVFEMU.MaxLength = 10
        Me.txtREAVFEMU.Name = "txtREAVFEMU"
        Me.txtREAVFEMU.Size = New System.Drawing.Size(172, 20)
        Me.txtREAVFEMU.TabIndex = 19
        '
        'txtREAVFEDE
        '
        Me.txtREAVFEDE.AccessibleDescription = "Fecha radicado"
        Me.txtREAVFEDE.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVFEDE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVFEDE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVFEDE.ForeColor = System.Drawing.Color.Black
        Me.txtREAVFEDE.Location = New System.Drawing.Point(462, 210)
        Me.txtREAVFEDE.MaxLength = 10
        Me.txtREAVFEDE.Name = "txtREAVFEDE"
        Me.txtREAVFEDE.Size = New System.Drawing.Size(172, 20)
        Me.txtREAVFEDE.TabIndex = 17
        '
        'txtREAVMAIN
        '
        Me.txtREAVMAIN.AccessibleDescription = "Matricula"
        Me.txtREAVMAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVMAIN.ForeColor = System.Drawing.Color.Black
        Me.txtREAVMAIN.Location = New System.Drawing.Point(197, 187)
        Me.txtREAVMAIN.MaxLength = 11
        Me.txtREAVMAIN.Name = "txtREAVMAIN"
        Me.txtREAVMAIN.Size = New System.Drawing.Size(86, 20)
        Me.txtREAVMAIN.TabIndex = 14
        '
        'txtREAVCLSE
        '
        Me.txtREAVCLSE.AccessibleDescription = "Municipio"
        Me.txtREAVCLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVCLSE.Location = New System.Drawing.Point(110, 95)
        Me.txtREAVCLSE.MaxLength = 1
        Me.txtREAVCLSE.Name = "txtREAVCLSE"
        Me.txtREAVCLSE.Size = New System.Drawing.Size(85, 20)
        Me.txtREAVCLSE.TabIndex = 8
        '
        'txtREAVVIGE
        '
        Me.txtREAVVIGE.AccessibleDescription = "Predio "
        Me.txtREAVVIGE.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVVIGE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVVIGE.ForeColor = System.Drawing.Color.Black
        Me.txtREAVVIGE.Location = New System.Drawing.Point(286, 95)
        Me.txtREAVVIGE.MaxLength = 4
        Me.txtREAVVIGE.Name = "txtREAVVIGE"
        Me.txtREAVVIGE.Size = New System.Drawing.Size(85, 20)
        Me.txtREAVVIGE.TabIndex = 9
        '
        'txtREAVRADM
        '
        Me.txtREAVRADM.AccessibleDescription = "Radicado"
        Me.txtREAVRADM.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVRADM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVRADM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVRADM.ForeColor = System.Drawing.Color.Black
        Me.txtREAVRADM.Location = New System.Drawing.Point(286, 279)
        Me.txtREAVRADM.MaxLength = 8
        Me.txtREAVRADM.Name = "txtREAVRADM"
        Me.txtREAVRADM.Size = New System.Drawing.Size(85, 20)
        Me.txtREAVRADM.TabIndex = 22
        '
        'txtREAVRAED
        '
        Me.txtREAVRAED.AccessibleDescription = "Radicado"
        Me.txtREAVRAED.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVRAED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVRAED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVRAED.ForeColor = System.Drawing.Color.Black
        Me.txtREAVRAED.Location = New System.Drawing.Point(286, 256)
        Me.txtREAVRAED.MaxLength = 8
        Me.txtREAVRAED.Name = "txtREAVRAED"
        Me.txtREAVRAED.Size = New System.Drawing.Size(85, 20)
        Me.txtREAVRAED.TabIndex = 20
        '
        'txtREAVRAMU
        '
        Me.txtREAVRAMU.AccessibleDescription = "Radicado"
        Me.txtREAVRAMU.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVRAMU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVRAMU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVRAMU.ForeColor = System.Drawing.Color.Black
        Me.txtREAVRAMU.Location = New System.Drawing.Point(286, 233)
        Me.txtREAVRAMU.MaxLength = 8
        Me.txtREAVRAMU.Name = "txtREAVRAMU"
        Me.txtREAVRAMU.Size = New System.Drawing.Size(85, 20)
        Me.txtREAVRAMU.TabIndex = 18
        '
        'txtREAVRADE
        '
        Me.txtREAVRADE.AccessibleDescription = "Radicado"
        Me.txtREAVRADE.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVRADE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVRADE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVRADE.ForeColor = System.Drawing.Color.Black
        Me.txtREAVRADE.Location = New System.Drawing.Point(286, 210)
        Me.txtREAVRADE.MaxLength = 8
        Me.txtREAVRADE.Name = "txtREAVRADE"
        Me.txtREAVRADE.Size = New System.Drawing.Size(85, 20)
        Me.txtREAVRADE.TabIndex = 16
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
        'txtREAVSEAP
        '
        Me.txtREAVSEAP.AccessibleDescription = "Segundo apellido"
        Me.txtREAVSEAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVSEAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVSEAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVSEAP.ForeColor = System.Drawing.Color.Black
        Me.txtREAVSEAP.Location = New System.Drawing.Point(550, 164)
        Me.txtREAVSEAP.MaxLength = 20
        Me.txtREAVSEAP.Name = "txtREAVSEAP"
        Me.txtREAVSEAP.Size = New System.Drawing.Size(172, 20)
        Me.txtREAVSEAP.TabIndex = 13
        '
        'txtREAVPRAP
        '
        Me.txtREAVPRAP.AccessibleDescription = "Primer apellido"
        Me.txtREAVPRAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVPRAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVPRAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVPRAP.ForeColor = System.Drawing.Color.Black
        Me.txtREAVPRAP.Location = New System.Drawing.Point(198, 164)
        Me.txtREAVPRAP.MaxLength = 20
        Me.txtREAVPRAP.Name = "txtREAVPRAP"
        Me.txtREAVPRAP.Size = New System.Drawing.Size(172, 20)
        Me.txtREAVPRAP.TabIndex = 12
        '
        'txtREAVNUDO
        '
        Me.txtREAVNUDO.AccessibleDescription = "Nro. Documento"
        Me.txtREAVNUDO.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVNUDO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVNUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVNUDO.ForeColor = System.Drawing.Color.Black
        Me.txtREAVNUDO.Location = New System.Drawing.Point(110, 118)
        Me.txtREAVNUDO.MaxLength = 49
        Me.txtREAVNUDO.Name = "txtREAVNUDO"
        Me.txtREAVNUDO.Size = New System.Drawing.Size(173, 20)
        Me.txtREAVNUDO.TabIndex = 10
        '
        'txtREAVNOMB
        '
        Me.txtREAVNOMB.AccessibleDescription = "Nombre"
        Me.txtREAVNOMB.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVNOMB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVNOMB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVNOMB.ForeColor = System.Drawing.Color.Black
        Me.txtREAVNOMB.Location = New System.Drawing.Point(198, 141)
        Me.txtREAVNOMB.MaxLength = 50
        Me.txtREAVNOMB.Name = "txtREAVNOMB"
        Me.txtREAVNOMB.Size = New System.Drawing.Size(524, 20)
        Me.txtREAVNOMB.TabIndex = 11
        '
        'lblNumeroDocumento
        '
        Me.lblNumeroDocumento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblNumeroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumeroDocumento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroDocumento.ForeColor = System.Drawing.Color.Black
        Me.lblNumeroDocumento.Location = New System.Drawing.Point(19, 118)
        Me.lblNumeroDocumento.Name = "lblNumeroDocumento"
        Me.lblNumeroDocumento.Size = New System.Drawing.Size(88, 20)
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
        'txtREAVUNPR
        '
        Me.txtREAVUNPR.AccessibleDescription = "Unidad predial"
        Me.txtREAVUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtREAVUNPR.Location = New System.Drawing.Point(638, 72)
        Me.txtREAVUNPR.MaxLength = 5
        Me.txtREAVUNPR.Name = "txtREAVUNPR"
        Me.txtREAVUNPR.Size = New System.Drawing.Size(85, 20)
        Me.txtREAVUNPR.TabIndex = 7
        '
        'txtREAVEDIF
        '
        Me.txtREAVEDIF.AccessibleDescription = "Edificio"
        Me.txtREAVEDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVEDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVEDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVEDIF.ForeColor = System.Drawing.Color.Black
        Me.txtREAVEDIF.Location = New System.Drawing.Point(550, 72)
        Me.txtREAVEDIF.MaxLength = 3
        Me.txtREAVEDIF.Name = "txtREAVEDIF"
        Me.txtREAVEDIF.Size = New System.Drawing.Size(85, 20)
        Me.txtREAVEDIF.TabIndex = 6
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
        'txtREAVOBSE
        '
        Me.txtREAVOBSE.AccessibleDescription = "Observaciones"
        Me.txtREAVOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtREAVOBSE.Location = New System.Drawing.Point(17, 370)
        Me.txtREAVOBSE.MaxLength = 1000
        Me.txtREAVOBSE.Name = "txtREAVOBSE"
        Me.txtREAVOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtREAVOBSE.Size = New System.Drawing.Size(705, 20)
        Me.txtREAVOBSE.TabIndex = 27
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
        'txtREAVCORR
        '
        Me.txtREAVCORR.AccessibleDescription = "Corregimiento"
        Me.txtREAVCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVCORR.Location = New System.Drawing.Point(198, 72)
        Me.txtREAVCORR.MaxLength = 2
        Me.txtREAVCORR.Name = "txtREAVCORR"
        Me.txtREAVCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtREAVCORR.TabIndex = 2
        '
        'txtREAVMUNI
        '
        Me.txtREAVMUNI.AccessibleDescription = "Municipio"
        Me.txtREAVMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVMUNI.Location = New System.Drawing.Point(110, 72)
        Me.txtREAVMUNI.MaxLength = 3
        Me.txtREAVMUNI.Name = "txtREAVMUNI"
        Me.txtREAVMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtREAVMUNI.TabIndex = 1
        '
        'lblClaseOSector2
        '
        Me.lblClaseOSector2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseOSector2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseOSector2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseOSector2.ForeColor = System.Drawing.Color.Black
        Me.lblClaseOSector2.Location = New System.Drawing.Point(19, 95)
        Me.lblClaseOSector2.Name = "lblClaseOSector2"
        Me.lblClaseOSector2.Size = New System.Drawing.Size(88, 20)
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
        'txtREAVPRED
        '
        Me.txtREAVPRED.AccessibleDescription = "Predio "
        Me.txtREAVPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVPRED.ForeColor = System.Drawing.Color.Black
        Me.txtREAVPRED.Location = New System.Drawing.Point(462, 72)
        Me.txtREAVPRED.MaxLength = 5
        Me.txtREAVPRED.Name = "txtREAVPRED"
        Me.txtREAVPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtREAVPRED.TabIndex = 5
        '
        'txtREAVMANZ
        '
        Me.txtREAVMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtREAVMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtREAVMANZ.Location = New System.Drawing.Point(374, 72)
        Me.txtREAVMANZ.MaxLength = 3
        Me.txtREAVMANZ.Name = "txtREAVMANZ"
        Me.txtREAVMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtREAVMANZ.TabIndex = 4
        '
        'txtREAVBARR
        '
        Me.txtREAVBARR.AccessibleDescription = "Barrio "
        Me.txtREAVBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAVBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAVBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAVBARR.ForeColor = System.Drawing.Color.Black
        Me.txtREAVBARR.Location = New System.Drawing.Point(286, 72)
        Me.txtREAVBARR.MaxLength = 3
        Me.txtREAVBARR.Name = "txtREAVBARR"
        Me.txtREAVBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtREAVBARR.TabIndex = 3
        '
        'lblCodigoActual
        '
        Me.lblCodigoActual.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigoActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigoActual.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoActual.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoActual.Location = New System.Drawing.Point(19, 72)
        Me.lblCodigoActual.Name = "lblCodigoActual"
        Me.lblCodigoActual.Size = New System.Drawing.Size(88, 20)
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
        Me.lblCodigo.Size = New System.Drawing.Size(88, 20)
        Me.lblCodigo.TabIndex = 451
        Me.lblCodigo.Text = "CODIGO"
        '
        'dgvCONSULTA
        '
        Me.dgvCONSULTA.AccessibleDescription = ""
        Me.dgvCONSULTA.AllowUserToAddRows = False
        Me.dgvCONSULTA.AllowUserToDeleteRows = False
        Me.dgvCONSULTA.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
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
        Me.dgvCONSULTA.MultiSelect = False
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        Me.dgvCONSULTA.RowHeadersVisible = False
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(703, 175)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 40
        '
        'frm_consultar_REVIAVAL
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
        Me.Name = "frm_consultar_REVIAVAL"
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
    Friend WithEvents cmdExportarExcel As System.Windows.Forms.Button
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents cmdLimpiar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdConsultar As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraPERIODO As System.Windows.Forms.GroupBox
    Friend WithEvents txtREAVSECU As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtREAVMIAN As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtREAVESTA As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVTITR As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVFELC As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVFEDM As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVFEED As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVFEMU As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVFEDE As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVMAIN As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVCLSE As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVVIGE As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVRADM As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVRAED As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVRAMU As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVRADE As System.Windows.Forms.TextBox
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
    Friend WithEvents txtREAVSEAP As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVPRAP As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVNUDO As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVNOMB As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtREAVUNPR As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVEDIF As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtREAVOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtREAVCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVMUNI As System.Windows.Forms.TextBox
    Friend WithEvents lblClaseOSector2 As System.Windows.Forms.Label
    Friend WithEvents lblCategoriaDeSuelo As System.Windows.Forms.Label
    Friend WithEvents txtREAVPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtREAVBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
End Class
