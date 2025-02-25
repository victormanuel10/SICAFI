<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_MUTACIONES
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtMUTAUNPR = New System.Windows.Forms.TextBox()
        Me.txtMUTAEDIF = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTRCADESC = New System.Windows.Forms.TextBox()
        Me.cmdLimpiar2 = New System.Windows.Forms.Button()
        Me.chkTRCAESTA = New System.Windows.Forms.CheckBox()
        Me.txtMUTAFEIN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkTRCAFEIN = New System.Windows.Forms.CheckBox()
        Me.chkTRCAVIGE = New System.Windows.Forms.CheckBox()
        Me.chkTRCACLSE = New System.Windows.Forms.CheckBox()
        Me.chkTRCAPRED = New System.Windows.Forms.CheckBox()
        Me.chkTRCAMANZ = New System.Windows.Forms.CheckBox()
        Me.chkTRCABARR = New System.Windows.Forms.CheckBox()
        Me.chkTRCACORR = New System.Windows.Forms.CheckBox()
        Me.chkTRCAMUNI = New System.Windows.Forms.CheckBox()
        Me.txtMUTAFEES = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMUTAESTA = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMUTANUFI = New System.Windows.Forms.TextBox()
        Me.txtMUTANURA = New System.Windows.Forms.TextBox()
        Me.txtMUTAFERA = New System.Windows.Forms.TextBox()
        Me.txtMUTAESCR = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMUTAVIGE = New System.Windows.Forms.TextBox()
        Me.txtMUTACLSE = New System.Windows.Forms.TextBox()
        Me.txtTRCAOBSE = New System.Windows.Forms.TextBox()
        Me.txtMUTAMAIN = New System.Windows.Forms.TextBox()
        Me.lblNotaria1 = New System.Windows.Forms.Label()
        Me.lblEscritura = New System.Windows.Forms.Label()
        Me.lblFechaEscritura = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMUTACORR = New System.Windows.Forms.TextBox()
        Me.txtMUTAMUNI = New System.Windows.Forms.TextBox()
        Me.lblClaseOSector2 = New System.Windows.Forms.Label()
        Me.lblCategoriaDeSuelo = New System.Windows.Forms.Label()
        Me.txtMUTAPRED = New System.Windows.Forms.TextBox()
        Me.txtMUTAMANZ = New System.Windows.Forms.TextBox()
        Me.txtMUTABARR = New System.Windows.Forms.TextBox()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.lblManzana = New System.Windows.Forms.Label()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.dgvCONSULTA = New System.Windows.Forms.DataGridView()
        Me.Label10 = New System.Windows.Forms.Label()
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 438)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(829, 60)
        Me.GroupBox1.TabIndex = 80
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
        Me.cmdExportarExcel.Location = New System.Drawing.Point(142, 20)
        Me.cmdExportarExcel.Name = "cmdExportarExcel"
        Me.cmdExportarExcel.Size = New System.Drawing.Size(123, 23)
        Me.cmdExportarExcel.TabIndex = 25
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
        Me.cmdSalir.Location = New System.Drawing.Point(713, 20)
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
        Me.cmdLimpiar.Size = New System.Drawing.Size(117, 23)
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
        Me.cmdAceptar.Location = New System.Drawing.Point(606, 20)
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
        Me.cmdConsultar.Location = New System.Drawing.Point(499, 20)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 509)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(853, 25)
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
        Me.fraPERIODO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraPERIODO.BackColor = System.Drawing.SystemColors.Control
        Me.fraPERIODO.Controls.Add(Me.Label10)
        Me.fraPERIODO.Controls.Add(Me.Label9)
        Me.fraPERIODO.Controls.Add(Me.txtMUTAUNPR)
        Me.fraPERIODO.Controls.Add(Me.txtMUTAEDIF)
        Me.fraPERIODO.Controls.Add(Me.Label7)
        Me.fraPERIODO.Controls.Add(Me.Label8)
        Me.fraPERIODO.Controls.Add(Me.Label6)
        Me.fraPERIODO.Controls.Add(Me.txtTRCADESC)
        Me.fraPERIODO.Controls.Add(Me.cmdLimpiar2)
        Me.fraPERIODO.Controls.Add(Me.chkTRCAESTA)
        Me.fraPERIODO.Controls.Add(Me.txtMUTAFEIN)
        Me.fraPERIODO.Controls.Add(Me.Label5)
        Me.fraPERIODO.Controls.Add(Me.chkTRCAFEIN)
        Me.fraPERIODO.Controls.Add(Me.chkTRCAVIGE)
        Me.fraPERIODO.Controls.Add(Me.chkTRCACLSE)
        Me.fraPERIODO.Controls.Add(Me.chkTRCAPRED)
        Me.fraPERIODO.Controls.Add(Me.chkTRCAMANZ)
        Me.fraPERIODO.Controls.Add(Me.chkTRCABARR)
        Me.fraPERIODO.Controls.Add(Me.chkTRCACORR)
        Me.fraPERIODO.Controls.Add(Me.chkTRCAMUNI)
        Me.fraPERIODO.Controls.Add(Me.txtMUTAFEES)
        Me.fraPERIODO.Controls.Add(Me.Label4)
        Me.fraPERIODO.Controls.Add(Me.txtMUTAESTA)
        Me.fraPERIODO.Controls.Add(Me.Label3)
        Me.fraPERIODO.Controls.Add(Me.txtMUTANUFI)
        Me.fraPERIODO.Controls.Add(Me.txtMUTANURA)
        Me.fraPERIODO.Controls.Add(Me.txtMUTAFERA)
        Me.fraPERIODO.Controls.Add(Me.txtMUTAESCR)
        Me.fraPERIODO.Controls.Add(Me.Label1)
        Me.fraPERIODO.Controls.Add(Me.txtMUTAVIGE)
        Me.fraPERIODO.Controls.Add(Me.txtMUTACLSE)
        Me.fraPERIODO.Controls.Add(Me.txtTRCAOBSE)
        Me.fraPERIODO.Controls.Add(Me.txtMUTAMAIN)
        Me.fraPERIODO.Controls.Add(Me.lblNotaria1)
        Me.fraPERIODO.Controls.Add(Me.lblEscritura)
        Me.fraPERIODO.Controls.Add(Me.lblFechaEscritura)
        Me.fraPERIODO.Controls.Add(Me.Label2)
        Me.fraPERIODO.Controls.Add(Me.txtMUTACORR)
        Me.fraPERIODO.Controls.Add(Me.txtMUTAMUNI)
        Me.fraPERIODO.Controls.Add(Me.lblClaseOSector2)
        Me.fraPERIODO.Controls.Add(Me.lblCategoriaDeSuelo)
        Me.fraPERIODO.Controls.Add(Me.txtMUTAPRED)
        Me.fraPERIODO.Controls.Add(Me.txtMUTAMANZ)
        Me.fraPERIODO.Controls.Add(Me.txtMUTABARR)
        Me.fraPERIODO.Controls.Add(Me.lblPredio)
        Me.fraPERIODO.Controls.Add(Me.lblManzana)
        Me.fraPERIODO.Controls.Add(Me.lblBarrio)
        Me.fraPERIODO.Controls.Add(Me.lblCorregimiento)
        Me.fraPERIODO.Controls.Add(Me.lblMunicipio)
        Me.fraPERIODO.Controls.Add(Me.dgvCONSULTA)
        Me.fraPERIODO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPERIODO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPERIODO.Location = New System.Drawing.Point(12, 10)
        Me.fraPERIODO.Name = "fraPERIODO"
        Me.fraPERIODO.Size = New System.Drawing.Size(827, 425)
        Me.fraPERIODO.TabIndex = 79
        Me.fraPERIODO.TabStop = False
        Me.fraPERIODO.Text = "CONSULTA MUTACIONES"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(195, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(173, 20)
        Me.Label9.TabIndex = 448
        Me.Label9.Text = "Matricula inmobiliaria"
        '
        'txtMUTAUNPR
        '
        Me.txtMUTAUNPR.AccessibleDescription = "Unidad predial"
        Me.txtMUTAUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUTAUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUTAUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtMUTAUNPR.Location = New System.Drawing.Point(547, 95)
        Me.txtMUTAUNPR.MaxLength = 5
        Me.txtMUTAUNPR.Name = "txtMUTAUNPR"
        Me.txtMUTAUNPR.Size = New System.Drawing.Size(85, 20)
        Me.txtMUTAUNPR.TabIndex = 9
        '
        'txtMUTAEDIF
        '
        Me.txtMUTAEDIF.AccessibleDescription = "Edificio"
        Me.txtMUTAEDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUTAEDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUTAEDIF.ForeColor = System.Drawing.Color.Black
        Me.txtMUTAEDIF.Location = New System.Drawing.Point(459, 95)
        Me.txtMUTAEDIF.MaxLength = 3
        Me.txtMUTAEDIF.Name = "txtMUTAEDIF"
        Me.txtMUTAEDIF.Size = New System.Drawing.Size(85, 20)
        Me.txtMUTAEDIF.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(547, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 20)
        Me.Label7.TabIndex = 446
        Me.Label7.Text = "Unidad predial"
        '
        'Label8
        '
        Me.Label8.AccessibleDescription = ""
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(459, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 20)
        Me.Label8.TabIndex = 445
        Me.Label8.Text = "Edificio"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(19, 164)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(349, 20)
        Me.Label6.TabIndex = 442
        Me.Label6.Text = "Descripción"
        '
        'txtTRCADESC
        '
        Me.txtTRCADESC.AccessibleDescription = "Descripción"
        Me.txtTRCADESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCADESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCADESC.ForeColor = System.Drawing.Color.Black
        Me.txtTRCADESC.Location = New System.Drawing.Point(19, 187)
        Me.txtTRCADESC.MaxLength = 100
        Me.txtTRCADESC.Name = "txtTRCADESC"
        Me.txtTRCADESC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTRCADESC.Size = New System.Drawing.Size(349, 20)
        Me.txtTRCADESC.TabIndex = 18
        '
        'cmdLimpiar2
        '
        Me.cmdLimpiar2.AccessibleDescription = "Limpiar"
        Me.cmdLimpiar2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.cmdLimpiar2.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLimpiar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLimpiar2.Location = New System.Drawing.Point(710, 219)
        Me.cmdLimpiar2.Name = "cmdLimpiar2"
        Me.cmdLimpiar2.Size = New System.Drawing.Size(101, 23)
        Me.cmdLimpiar2.TabIndex = 440
        Me.cmdLimpiar2.Text = "&Limpiar"
        Me.cmdLimpiar2.UseVisualStyleBackColor = True
        '
        'chkTRCAESTA
        '
        Me.chkTRCAESTA.AutoSize = True
        Me.chkTRCAESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTRCAESTA.Location = New System.Drawing.Point(637, 220)
        Me.chkTRCAESTA.Name = "chkTRCAESTA"
        Me.chkTRCAESTA.Size = New System.Drawing.Size(59, 18)
        Me.chkTRCAESTA.TabIndex = 439
        Me.chkTRCAESTA.Text = "Estado"
        Me.chkTRCAESTA.UseVisualStyleBackColor = True
        '
        'txtMUTAFEIN
        '
        Me.txtMUTAFEIN.AccessibleDescription = "Estado"
        Me.txtMUTAFEIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUTAFEIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUTAFEIN.Location = New System.Drawing.Point(547, 141)
        Me.txtMUTAFEIN.MaxLength = 20
        Me.txtMUTAFEIN.Name = "txtMUTAFEIN"
        Me.txtMUTAFEIN.Size = New System.Drawing.Size(173, 20)
        Me.txtMUTAFEIN.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(547, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(173, 20)
        Me.Label5.TabIndex = 438
        Me.Label5.Text = "Fecha ingreso"
        '
        'chkTRCAFEIN
        '
        Me.chkTRCAFEIN.AutoSize = True
        Me.chkTRCAFEIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTRCAFEIN.Location = New System.Drawing.Point(542, 220)
        Me.chkTRCAFEIN.Name = "chkTRCAFEIN"
        Me.chkTRCAFEIN.Size = New System.Drawing.Size(95, 18)
        Me.chkTRCAFEIN.TabIndex = 436
        Me.chkTRCAFEIN.Text = "Fecha ingreso"
        Me.chkTRCAFEIN.UseVisualStyleBackColor = True
        '
        'chkTRCAVIGE
        '
        Me.chkTRCAVIGE.AutoSize = True
        Me.chkTRCAVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTRCAVIGE.Location = New System.Drawing.Point(468, 220)
        Me.chkTRCAVIGE.Name = "chkTRCAVIGE"
        Me.chkTRCAVIGE.Size = New System.Drawing.Size(68, 18)
        Me.chkTRCAVIGE.TabIndex = 435
        Me.chkTRCAVIGE.Text = "Vigencia"
        Me.chkTRCAVIGE.UseVisualStyleBackColor = True
        '
        'chkTRCACLSE
        '
        Me.chkTRCACLSE.AutoSize = True
        Me.chkTRCACLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTRCACLSE.Location = New System.Drawing.Point(404, 220)
        Me.chkTRCACLSE.Name = "chkTRCACLSE"
        Me.chkTRCACLSE.Size = New System.Drawing.Size(58, 18)
        Me.chkTRCACLSE.TabIndex = 434
        Me.chkTRCACLSE.Text = "Sector"
        Me.chkTRCACLSE.UseVisualStyleBackColor = True
        '
        'chkTRCAPRED
        '
        Me.chkTRCAPRED.AutoSize = True
        Me.chkTRCAPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTRCAPRED.Location = New System.Drawing.Point(342, 220)
        Me.chkTRCAPRED.Name = "chkTRCAPRED"
        Me.chkTRCAPRED.Size = New System.Drawing.Size(56, 18)
        Me.chkTRCAPRED.TabIndex = 433
        Me.chkTRCAPRED.Text = "Predio"
        Me.chkTRCAPRED.UseVisualStyleBackColor = True
        '
        'chkTRCAMANZ
        '
        Me.chkTRCAMANZ.AutoSize = True
        Me.chkTRCAMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTRCAMANZ.Location = New System.Drawing.Point(245, 220)
        Me.chkTRCAMANZ.Name = "chkTRCAMANZ"
        Me.chkTRCAMANZ.Size = New System.Drawing.Size(91, 18)
        Me.chkTRCAMANZ.TabIndex = 432
        Me.chkTRCAMANZ.Text = "Manz \ Vered"
        Me.chkTRCAMANZ.UseVisualStyleBackColor = True
        '
        'chkTRCABARR
        '
        Me.chkTRCABARR.AutoSize = True
        Me.chkTRCABARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTRCABARR.Location = New System.Drawing.Point(184, 220)
        Me.chkTRCABARR.Name = "chkTRCABARR"
        Me.chkTRCABARR.Size = New System.Drawing.Size(55, 18)
        Me.chkTRCABARR.TabIndex = 431
        Me.chkTRCABARR.Text = "Barrio"
        Me.chkTRCABARR.UseVisualStyleBackColor = True
        '
        'chkTRCACORR
        '
        Me.chkTRCACORR.AutoSize = True
        Me.chkTRCACORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTRCACORR.Location = New System.Drawing.Point(90, 220)
        Me.chkTRCACORR.Name = "chkTRCACORR"
        Me.chkTRCACORR.Size = New System.Drawing.Size(92, 18)
        Me.chkTRCACORR.TabIndex = 430
        Me.chkTRCACORR.Text = "Corregimiento"
        Me.chkTRCACORR.UseVisualStyleBackColor = True
        '
        'chkTRCAMUNI
        '
        Me.chkTRCAMUNI.AutoSize = True
        Me.chkTRCAMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTRCAMUNI.Location = New System.Drawing.Point(19, 220)
        Me.chkTRCAMUNI.Name = "chkTRCAMUNI"
        Me.chkTRCAMUNI.Size = New System.Drawing.Size(70, 18)
        Me.chkTRCAMUNI.TabIndex = 429
        Me.chkTRCAMUNI.Text = "Municipio"
        Me.chkTRCAMUNI.UseVisualStyleBackColor = True
        '
        'txtMUTAFEES
        '
        Me.txtMUTAFEES.AccessibleDescription = "Fecha de escritura"
        Me.txtMUTAFEES.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUTAFEES.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUTAFEES.ForeColor = System.Drawing.Color.Black
        Me.txtMUTAFEES.Location = New System.Drawing.Point(107, 141)
        Me.txtMUTAFEES.MaxLength = 20
        Me.txtMUTAFEES.Name = "txtMUTAFEES"
        Me.txtMUTAFEES.Size = New System.Drawing.Size(174, 20)
        Me.txtMUTAFEES.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(371, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(440, 20)
        Me.Label4.TabIndex = 428
        Me.Label4.Text = "Observación"
        '
        'txtMUTAESTA
        '
        Me.txtMUTAESTA.AccessibleDescription = "Estado"
        Me.txtMUTAESTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUTAESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUTAESTA.Location = New System.Drawing.Point(723, 141)
        Me.txtMUTAESTA.MaxLength = 8
        Me.txtMUTAESTA.Name = "txtMUTAESTA"
        Me.txtMUTAESTA.Size = New System.Drawing.Size(85, 20)
        Me.txtMUTAESTA.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(283, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 20)
        Me.Label3.TabIndex = 426
        Me.Label3.Text = "Nro. Radicado"
        '
        'txtMUTANUFI
        '
        Me.txtMUTANUFI.AccessibleDescription = "Nro Ficha"
        Me.txtMUTANUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUTANUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUTANUFI.ForeColor = System.Drawing.Color.Black
        Me.txtMUTANUFI.Location = New System.Drawing.Point(19, 46)
        Me.txtMUTANUFI.MaxLength = 8
        Me.txtMUTANUFI.Name = "txtMUTANUFI"
        Me.txtMUTANUFI.Size = New System.Drawing.Size(172, 20)
        Me.txtMUTANUFI.TabIndex = 1
        '
        'txtMUTANURA
        '
        Me.txtMUTANURA.AccessibleDescription = "Nro. Radicado"
        Me.txtMUTANURA.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUTANURA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUTANURA.ForeColor = System.Drawing.Color.Black
        Me.txtMUTANURA.Location = New System.Drawing.Point(283, 141)
        Me.txtMUTANURA.MaxLength = 8
        Me.txtMUTANURA.Name = "txtMUTANURA"
        Me.txtMUTANURA.Size = New System.Drawing.Size(85, 20)
        Me.txtMUTANURA.TabIndex = 14
        '
        'txtMUTAFERA
        '
        Me.txtMUTAFERA.AccessibleDescription = "Fecha radicado"
        Me.txtMUTAFERA.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUTAFERA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUTAFERA.ForeColor = System.Drawing.Color.Black
        Me.txtMUTAFERA.Location = New System.Drawing.Point(371, 141)
        Me.txtMUTAFERA.MaxLength = 20
        Me.txtMUTAFERA.Name = "txtMUTAFERA"
        Me.txtMUTAFERA.Size = New System.Drawing.Size(173, 20)
        Me.txtMUTAFERA.TabIndex = 15
        '
        'txtMUTAESCR
        '
        Me.txtMUTAESCR.AccessibleDescription = "Escritura"
        Me.txtMUTAESCR.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUTAESCR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUTAESCR.ForeColor = System.Drawing.Color.Black
        Me.txtMUTAESCR.Location = New System.Drawing.Point(19, 141)
        Me.txtMUTAESCR.MaxLength = 8
        Me.txtMUTAESCR.Name = "txtMUTAESCR"
        Me.txtMUTAESCR.Size = New System.Drawing.Size(85, 20)
        Me.txtMUTAESCR.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(173, 20)
        Me.Label1.TabIndex = 420
        Me.Label1.Text = "Nro. de ficha predial"
        '
        'txtMUTAVIGE
        '
        Me.txtMUTAVIGE.AccessibleDescription = "Vigencia"
        Me.txtMUTAVIGE.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUTAVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUTAVIGE.ForeColor = System.Drawing.Color.Black
        Me.txtMUTAVIGE.Location = New System.Drawing.Point(724, 95)
        Me.txtMUTAVIGE.MaxLength = 5
        Me.txtMUTAVIGE.Name = "txtMUTAVIGE"
        Me.txtMUTAVIGE.Size = New System.Drawing.Size(85, 20)
        Me.txtMUTAVIGE.TabIndex = 11
        '
        'txtMUTACLSE
        '
        Me.txtMUTACLSE.AccessibleDescription = "Sector"
        Me.txtMUTACLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUTACLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUTACLSE.ForeColor = System.Drawing.Color.Black
        Me.txtMUTACLSE.Location = New System.Drawing.Point(635, 95)
        Me.txtMUTACLSE.MaxLength = 5
        Me.txtMUTACLSE.Name = "txtMUTACLSE"
        Me.txtMUTACLSE.Size = New System.Drawing.Size(85, 20)
        Me.txtMUTACLSE.TabIndex = 10
        '
        'txtTRCAOBSE
        '
        Me.txtTRCAOBSE.AccessibleDescription = "Observaciones"
        Me.txtTRCAOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCAOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtTRCAOBSE.Location = New System.Drawing.Point(371, 187)
        Me.txtTRCAOBSE.MaxLength = 1000
        Me.txtTRCAOBSE.Name = "txtTRCAOBSE"
        Me.txtTRCAOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTRCAOBSE.Size = New System.Drawing.Size(440, 20)
        Me.txtTRCAOBSE.TabIndex = 19
        '
        'txtMUTAMAIN
        '
        Me.txtMUTAMAIN.AccessibleDescription = "Matricula"
        Me.txtMUTAMAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUTAMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUTAMAIN.Location = New System.Drawing.Point(195, 46)
        Me.txtMUTAMAIN.MaxLength = 8
        Me.txtMUTAMAIN.Name = "txtMUTAMAIN"
        Me.txtMUTAMAIN.Size = New System.Drawing.Size(173, 20)
        Me.txtMUTAMAIN.TabIndex = 2
        '
        'lblNotaria1
        '
        Me.lblNotaria1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblNotaria1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNotaria1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotaria1.ForeColor = System.Drawing.Color.Black
        Me.lblNotaria1.Location = New System.Drawing.Point(371, 118)
        Me.lblNotaria1.Name = "lblNotaria1"
        Me.lblNotaria1.Size = New System.Drawing.Size(173, 20)
        Me.lblNotaria1.TabIndex = 412
        Me.lblNotaria1.Text = "Fecha radicado"
        '
        'lblEscritura
        '
        Me.lblEscritura.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblEscritura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEscritura.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEscritura.ForeColor = System.Drawing.Color.Black
        Me.lblEscritura.Location = New System.Drawing.Point(19, 118)
        Me.lblEscritura.Name = "lblEscritura"
        Me.lblEscritura.Size = New System.Drawing.Size(85, 20)
        Me.lblEscritura.TabIndex = 411
        Me.lblEscritura.Text = "Nro. Escritura"
        '
        'lblFechaEscritura
        '
        Me.lblFechaEscritura.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblFechaEscritura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFechaEscritura.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaEscritura.ForeColor = System.Drawing.Color.Black
        Me.lblFechaEscritura.Location = New System.Drawing.Point(107, 118)
        Me.lblFechaEscritura.Name = "lblFechaEscritura"
        Me.lblFechaEscritura.Size = New System.Drawing.Size(173, 20)
        Me.lblFechaEscritura.TabIndex = 410
        Me.lblFechaEscritura.Text = "Fecha escrit."
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(723, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 20)
        Me.Label2.TabIndex = 409
        Me.Label2.Text = "Estado"
        '
        'txtMUTACORR
        '
        Me.txtMUTACORR.AccessibleDescription = "Corregimiento"
        Me.txtMUTACORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUTACORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUTACORR.Location = New System.Drawing.Point(107, 95)
        Me.txtMUTACORR.MaxLength = 2
        Me.txtMUTACORR.Name = "txtMUTACORR"
        Me.txtMUTACORR.Size = New System.Drawing.Size(85, 20)
        Me.txtMUTACORR.TabIndex = 4
        '
        'txtMUTAMUNI
        '
        Me.txtMUTAMUNI.AccessibleDescription = "Municipio"
        Me.txtMUTAMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUTAMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUTAMUNI.Location = New System.Drawing.Point(19, 95)
        Me.txtMUTAMUNI.MaxLength = 3
        Me.txtMUTAMUNI.Name = "txtMUTAMUNI"
        Me.txtMUTAMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtMUTAMUNI.TabIndex = 3
        '
        'lblClaseOSector2
        '
        Me.lblClaseOSector2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseOSector2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseOSector2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseOSector2.ForeColor = System.Drawing.Color.Black
        Me.lblClaseOSector2.Location = New System.Drawing.Point(635, 72)
        Me.lblClaseOSector2.Name = "lblClaseOSector2"
        Me.lblClaseOSector2.Size = New System.Drawing.Size(85, 20)
        Me.lblClaseOSector2.TabIndex = 403
        Me.lblClaseOSector2.Text = "Clase o Sector"
        '
        'lblCategoriaDeSuelo
        '
        Me.lblCategoriaDeSuelo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCategoriaDeSuelo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCategoriaDeSuelo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoriaDeSuelo.ForeColor = System.Drawing.Color.Black
        Me.lblCategoriaDeSuelo.Location = New System.Drawing.Point(724, 72)
        Me.lblCategoriaDeSuelo.Name = "lblCategoriaDeSuelo"
        Me.lblCategoriaDeSuelo.Size = New System.Drawing.Size(85, 20)
        Me.lblCategoriaDeSuelo.TabIndex = 402
        Me.lblCategoriaDeSuelo.Text = "Vigencia"
        '
        'txtMUTAPRED
        '
        Me.txtMUTAPRED.AccessibleDescription = "Predio "
        Me.txtMUTAPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUTAPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUTAPRED.ForeColor = System.Drawing.Color.Black
        Me.txtMUTAPRED.Location = New System.Drawing.Point(371, 95)
        Me.txtMUTAPRED.MaxLength = 5
        Me.txtMUTAPRED.Name = "txtMUTAPRED"
        Me.txtMUTAPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtMUTAPRED.TabIndex = 7
        '
        'txtMUTAMANZ
        '
        Me.txtMUTAMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtMUTAMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUTAMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUTAMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtMUTAMANZ.Location = New System.Drawing.Point(283, 95)
        Me.txtMUTAMANZ.MaxLength = 3
        Me.txtMUTAMANZ.Name = "txtMUTAMANZ"
        Me.txtMUTAMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtMUTAMANZ.TabIndex = 6
        '
        'txtMUTABARR
        '
        Me.txtMUTABARR.AccessibleDescription = "Barrio "
        Me.txtMUTABARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUTABARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUTABARR.ForeColor = System.Drawing.Color.Black
        Me.txtMUTABARR.Location = New System.Drawing.Point(195, 95)
        Me.txtMUTABARR.MaxLength = 3
        Me.txtMUTABARR.Name = "txtMUTABARR"
        Me.txtMUTABARR.Size = New System.Drawing.Size(85, 20)
        Me.txtMUTABARR.TabIndex = 5
        '
        'lblPredio
        '
        Me.lblPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredio.ForeColor = System.Drawing.Color.Black
        Me.lblPredio.Location = New System.Drawing.Point(371, 72)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(84, 20)
        Me.lblPredio.TabIndex = 399
        Me.lblPredio.Text = "Predio"
        '
        'lblManzana
        '
        Me.lblManzana.AccessibleDescription = ""
        Me.lblManzana.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblManzana.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblManzana.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManzana.ForeColor = System.Drawing.Color.Black
        Me.lblManzana.Location = New System.Drawing.Point(283, 72)
        Me.lblManzana.Name = "lblManzana"
        Me.lblManzana.Size = New System.Drawing.Size(84, 20)
        Me.lblManzana.TabIndex = 398
        Me.lblManzana.Text = "Manza / Vered"
        '
        'lblBarrio
        '
        Me.lblBarrio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblBarrio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBarrio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarrio.ForeColor = System.Drawing.Color.Black
        Me.lblBarrio.Location = New System.Drawing.Point(195, 72)
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Size = New System.Drawing.Size(84, 20)
        Me.lblBarrio.TabIndex = 397
        Me.lblBarrio.Text = "Barrio"
        '
        'lblCorregimiento
        '
        Me.lblCorregimiento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCorregimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorregimiento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorregimiento.ForeColor = System.Drawing.Color.Black
        Me.lblCorregimiento.Location = New System.Drawing.Point(107, 72)
        Me.lblCorregimiento.Name = "lblCorregimiento"
        Me.lblCorregimiento.Size = New System.Drawing.Size(84, 20)
        Me.lblCorregimiento.TabIndex = 401
        Me.lblCorregimiento.Text = "Corregimiento"
        '
        'lblMunicipio
        '
        Me.lblMunicipio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblMunicipio.Location = New System.Drawing.Point(19, 72)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(84, 20)
        Me.lblMunicipio.TabIndex = 407
        Me.lblMunicipio.Text = "Municipio"
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
        Me.dgvCONSULTA.Location = New System.Drawing.Point(19, 248)
        Me.dgvCONSULTA.MultiSelect = False
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        Me.dgvCONSULTA.RowHeadersVisible = False
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(792, 161)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 40
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(374, 46)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(169, 20)
        Me.Label10.TabIndex = 449
        Me.Label10.Text = "Formato: (0000000)"
        '
        'frm_consultar_MUTACIONES
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 534)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraPERIODO)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(869, 570)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(869, 570)
        Me.Name = "frm_consultar_MUTACIONES"
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTRCADESC As System.Windows.Forms.TextBox
    Friend WithEvents cmdLimpiar2 As System.Windows.Forms.Button
    Friend WithEvents chkTRCAESTA As System.Windows.Forms.CheckBox
    Friend WithEvents txtMUTAFEIN As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkTRCAFEIN As System.Windows.Forms.CheckBox
    Friend WithEvents chkTRCAVIGE As System.Windows.Forms.CheckBox
    Friend WithEvents chkTRCACLSE As System.Windows.Forms.CheckBox
    Friend WithEvents chkTRCAPRED As System.Windows.Forms.CheckBox
    Friend WithEvents chkTRCAMANZ As System.Windows.Forms.CheckBox
    Friend WithEvents chkTRCABARR As System.Windows.Forms.CheckBox
    Friend WithEvents chkTRCACORR As System.Windows.Forms.CheckBox
    Friend WithEvents chkTRCAMUNI As System.Windows.Forms.CheckBox
    Friend WithEvents txtMUTAFEES As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMUTAESTA As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMUTAESCR As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMUTAVIGE As System.Windows.Forms.TextBox
    Friend WithEvents txtMUTACLSE As System.Windows.Forms.TextBox
    Friend WithEvents txtTRCAOBSE As System.Windows.Forms.TextBox
    Friend WithEvents txtMUTAMAIN As System.Windows.Forms.TextBox
    Friend WithEvents lblEscritura As System.Windows.Forms.Label
    Friend WithEvents lblFechaEscritura As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMUTACORR As System.Windows.Forms.TextBox
    Friend WithEvents txtMUTAMUNI As System.Windows.Forms.TextBox
    Friend WithEvents lblClaseOSector2 As System.Windows.Forms.Label
    Friend WithEvents lblCategoriaDeSuelo As System.Windows.Forms.Label
    Friend WithEvents txtMUTAPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtMUTAMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtMUTABARR As System.Windows.Forms.TextBox
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents txtMUTANUFI As System.Windows.Forms.TextBox
    Friend WithEvents txtMUTANURA As System.Windows.Forms.TextBox
    Friend WithEvents txtMUTAFERA As System.Windows.Forms.TextBox
    Friend WithEvents lblNotaria1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMUTAUNPR As System.Windows.Forms.TextBox
    Friend WithEvents txtMUTAEDIF As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
