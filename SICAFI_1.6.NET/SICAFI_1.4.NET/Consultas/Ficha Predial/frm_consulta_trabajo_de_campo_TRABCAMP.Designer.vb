<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_trabajo_de_campo_TRABCAMP
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
        Me.cmdConsultar = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraPERIODO = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTRCADESC = New System.Windows.Forms.TextBox()
        Me.txtTRCAFEES = New System.Windows.Forms.TextBox()
        Me.txtTRCAESTA = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTRCANOTA = New System.Windows.Forms.TextBox()
        Me.txtTRCANOMU = New System.Windows.Forms.TextBox()
        Me.txtTRCANODE = New System.Windows.Forms.TextBox()
        Me.txtTRCAESCR = New System.Windows.Forms.TextBox()
        Me.txtTRCACAAC = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTRCAVIGE = New System.Windows.Forms.TextBox()
        Me.txtTRCACLSE = New System.Windows.Forms.TextBox()
        Me.txtTRCAMAIN = New System.Windows.Forms.TextBox()
        Me.lblNotaria1 = New System.Windows.Forms.Label()
        Me.lblEscritura = New System.Windows.Forms.Label()
        Me.lblFechaEscritura = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTRCACORR = New System.Windows.Forms.TextBox()
        Me.txtTRCAMUNI = New System.Windows.Forms.TextBox()
        Me.lblClaseOSector2 = New System.Windows.Forms.Label()
        Me.lblCategoriaDeSuelo = New System.Windows.Forms.Label()
        Me.txtTRCAPRED = New System.Windows.Forms.TextBox()
        Me.txtTRCAMANZ = New System.Windows.Forms.TextBox()
        Me.txtTRCABARR = New System.Windows.Forms.TextBox()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.lblManzana = New System.Windows.Forms.Label()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
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
        Me.GroupBox1.Controls.Add(Me.cmdConsultar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 481)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(977, 60)
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
        Me.cmdExportarExcel.Location = New System.Drawing.Point(271, 20)
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
        Me.cmdSalir.Location = New System.Drawing.Point(835, 20)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(123, 23)
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
        Me.cmdLimpiar.Location = New System.Drawing.Point(148, 20)
        Me.cmdLimpiar.Name = "cmdLimpiar"
        Me.cmdLimpiar.Size = New System.Drawing.Size(117, 23)
        Me.cmdLimpiar.TabIndex = 1
        Me.cmdLimpiar.Text = "&Limpiar"
        Me.cmdLimpiar.UseVisualStyleBackColor = True
        '
        'cmdConsultar
        '
        Me.cmdConsultar.AccessibleDescription = "Consultar"
        Me.cmdConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdConsultar.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdConsultar.Location = New System.Drawing.Point(19, 20)
        Me.cmdConsultar.Name = "cmdConsultar"
        Me.cmdConsultar.Size = New System.Drawing.Size(123, 23)
        Me.cmdConsultar.TabIndex = 2
        Me.cmdConsultar.Text = "&Consultar"
        Me.cmdConsultar.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 558)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(1007, 25)
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
        Me.fraPERIODO.Controls.Add(Me.Label6)
        Me.fraPERIODO.Controls.Add(Me.txtTRCADESC)
        Me.fraPERIODO.Controls.Add(Me.txtTRCAFEES)
        Me.fraPERIODO.Controls.Add(Me.txtTRCAESTA)
        Me.fraPERIODO.Controls.Add(Me.Label3)
        Me.fraPERIODO.Controls.Add(Me.txtTRCANOTA)
        Me.fraPERIODO.Controls.Add(Me.txtTRCANOMU)
        Me.fraPERIODO.Controls.Add(Me.txtTRCANODE)
        Me.fraPERIODO.Controls.Add(Me.txtTRCAESCR)
        Me.fraPERIODO.Controls.Add(Me.txtTRCACAAC)
        Me.fraPERIODO.Controls.Add(Me.Label1)
        Me.fraPERIODO.Controls.Add(Me.txtTRCAVIGE)
        Me.fraPERIODO.Controls.Add(Me.txtTRCACLSE)
        Me.fraPERIODO.Controls.Add(Me.txtTRCAMAIN)
        Me.fraPERIODO.Controls.Add(Me.lblNotaria1)
        Me.fraPERIODO.Controls.Add(Me.lblEscritura)
        Me.fraPERIODO.Controls.Add(Me.lblFechaEscritura)
        Me.fraPERIODO.Controls.Add(Me.Label2)
        Me.fraPERIODO.Controls.Add(Me.txtTRCACORR)
        Me.fraPERIODO.Controls.Add(Me.txtTRCAMUNI)
        Me.fraPERIODO.Controls.Add(Me.lblClaseOSector2)
        Me.fraPERIODO.Controls.Add(Me.lblCategoriaDeSuelo)
        Me.fraPERIODO.Controls.Add(Me.txtTRCAPRED)
        Me.fraPERIODO.Controls.Add(Me.txtTRCAMANZ)
        Me.fraPERIODO.Controls.Add(Me.txtTRCABARR)
        Me.fraPERIODO.Controls.Add(Me.lblPredio)
        Me.fraPERIODO.Controls.Add(Me.lblManzana)
        Me.fraPERIODO.Controls.Add(Me.lblBarrio)
        Me.fraPERIODO.Controls.Add(Me.lblCorregimiento)
        Me.fraPERIODO.Controls.Add(Me.lblMunicipio)
        Me.fraPERIODO.Controls.Add(Me.dgvCONSULTA)
        Me.fraPERIODO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPERIODO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPERIODO.Location = New System.Drawing.Point(12, 12)
        Me.fraPERIODO.Name = "fraPERIODO"
        Me.fraPERIODO.Size = New System.Drawing.Size(977, 463)
        Me.fraPERIODO.TabIndex = 79
        Me.fraPERIODO.TabStop = False
        Me.fraPERIODO.Text = "PARAMETROS"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(638, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(320, 20)
        Me.Label6.TabIndex = 442
        Me.Label6.Text = "Descripción"
        '
        'txtTRCADESC
        '
        Me.txtTRCADESC.AccessibleDescription = "Descripción"
        Me.txtTRCADESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCADESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRCADESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCADESC.ForeColor = System.Drawing.Color.Black
        Me.txtTRCADESC.Location = New System.Drawing.Point(638, 98)
        Me.txtTRCADESC.MaxLength = 100
        Me.txtTRCADESC.Name = "txtTRCADESC"
        Me.txtTRCADESC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTRCADESC.Size = New System.Drawing.Size(320, 20)
        Me.txtTRCADESC.TabIndex = 441
        '
        'txtTRCAFEES
        '
        Me.txtTRCAFEES.AccessibleDescription = "Fecha de escritura"
        Me.txtTRCAFEES.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCAFEES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRCAFEES.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAFEES.ForeColor = System.Drawing.Color.Black
        Me.txtTRCAFEES.Location = New System.Drawing.Point(107, 98)
        Me.txtTRCAFEES.MaxLength = 20
        Me.txtTRCAFEES.Name = "txtTRCAFEES"
        Me.txtTRCAFEES.Size = New System.Drawing.Size(84, 20)
        Me.txtTRCAFEES.TabIndex = 9
        '
        'txtTRCAESTA
        '
        Me.txtTRCAESTA.AccessibleDescription = "Estado"
        Me.txtTRCAESTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCAESTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtTRCAESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAESTA.Location = New System.Drawing.Point(873, 52)
        Me.txtTRCAESTA.MaxLength = 8
        Me.txtTRCAESTA.Name = "txtTRCAESTA"
        Me.txtTRCAESTA.Size = New System.Drawing.Size(85, 20)
        Me.txtTRCAESTA.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(460, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(174, 20)
        Me.Label3.TabIndex = 426
        Me.Label3.Text = "Matricula inmobiliaria"
        '
        'txtTRCANOTA
        '
        Me.txtTRCANOTA.AccessibleDescription = "Notaria"
        Me.txtTRCANOTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCANOTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRCANOTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCANOTA.ForeColor = System.Drawing.Color.Black
        Me.txtTRCANOTA.Location = New System.Drawing.Point(371, 98)
        Me.txtTRCANOTA.MaxLength = 8
        Me.txtTRCANOTA.Name = "txtTRCANOTA"
        Me.txtTRCANOTA.Size = New System.Drawing.Size(85, 20)
        Me.txtTRCANOTA.TabIndex = 13
        '
        'txtTRCANOMU
        '
        Me.txtTRCANOMU.AccessibleDescription = "Municipio"
        Me.txtTRCANOMU.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCANOMU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRCANOMU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCANOMU.ForeColor = System.Drawing.Color.Black
        Me.txtTRCANOMU.Location = New System.Drawing.Point(283, 98)
        Me.txtTRCANOMU.MaxLength = 8
        Me.txtTRCANOMU.Name = "txtTRCANOMU"
        Me.txtTRCANOMU.Size = New System.Drawing.Size(85, 20)
        Me.txtTRCANOMU.TabIndex = 12
        '
        'txtTRCANODE
        '
        Me.txtTRCANODE.AccessibleDescription = "Departamento"
        Me.txtTRCANODE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCANODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRCANODE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCANODE.ForeColor = System.Drawing.Color.Black
        Me.txtTRCANODE.Location = New System.Drawing.Point(195, 98)
        Me.txtTRCANODE.MaxLength = 8
        Me.txtTRCANODE.Name = "txtTRCANODE"
        Me.txtTRCANODE.Size = New System.Drawing.Size(85, 20)
        Me.txtTRCANODE.TabIndex = 11
        '
        'txtTRCAESCR
        '
        Me.txtTRCAESCR.AccessibleDescription = "Escritura"
        Me.txtTRCAESCR.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCAESCR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRCAESCR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAESCR.ForeColor = System.Drawing.Color.Black
        Me.txtTRCAESCR.Location = New System.Drawing.Point(19, 98)
        Me.txtTRCAESCR.MaxLength = 8
        Me.txtTRCAESCR.Name = "txtTRCAESCR"
        Me.txtTRCAESCR.Size = New System.Drawing.Size(85, 20)
        Me.txtTRCAESCR.TabIndex = 10
        '
        'txtTRCACAAC
        '
        Me.txtTRCACAAC.AccessibleDescription = "Causa del acto"
        Me.txtTRCACAAC.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCACAAC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRCACAAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCACAAC.ForeColor = System.Drawing.Color.Black
        Me.txtTRCACAAC.Location = New System.Drawing.Point(638, 52)
        Me.txtTRCACAAC.MaxLength = 10
        Me.txtTRCACAAC.Name = "txtTRCACAAC"
        Me.txtTRCACAAC.Size = New System.Drawing.Size(231, 20)
        Me.txtTRCACAAC.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(638, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(231, 20)
        Me.Label1.TabIndex = 420
        Me.Label1.Text = "Causa del acto"
        '
        'txtTRCAVIGE
        '
        Me.txtTRCAVIGE.AccessibleDescription = "Vigencia"
        Me.txtTRCAVIGE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCAVIGE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRCAVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAVIGE.ForeColor = System.Drawing.Color.Black
        Me.txtTRCAVIGE.Location = New System.Drawing.Point(548, 52)
        Me.txtTRCAVIGE.MaxLength = 5
        Me.txtTRCAVIGE.Name = "txtTRCAVIGE"
        Me.txtTRCAVIGE.Size = New System.Drawing.Size(85, 20)
        Me.txtTRCAVIGE.TabIndex = 7
        '
        'txtTRCACLSE
        '
        Me.txtTRCACLSE.AccessibleDescription = "Sector"
        Me.txtTRCACLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCACLSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRCACLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCACLSE.ForeColor = System.Drawing.Color.Black
        Me.txtTRCACLSE.Location = New System.Drawing.Point(459, 52)
        Me.txtTRCACLSE.MaxLength = 5
        Me.txtTRCACLSE.Name = "txtTRCACLSE"
        Me.txtTRCACLSE.Size = New System.Drawing.Size(85, 20)
        Me.txtTRCACLSE.TabIndex = 6
        '
        'txtTRCAMAIN
        '
        Me.txtTRCAMAIN.AccessibleDescription = "Matricula"
        Me.txtTRCAMAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCAMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAMAIN.Location = New System.Drawing.Point(460, 98)
        Me.txtTRCAMAIN.MaxLength = 15
        Me.txtTRCAMAIN.Name = "txtTRCAMAIN"
        Me.txtTRCAMAIN.Size = New System.Drawing.Size(174, 20)
        Me.txtTRCAMAIN.TabIndex = 14
        '
        'lblNotaria1
        '
        Me.lblNotaria1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblNotaria1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNotaria1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotaria1.ForeColor = System.Drawing.Color.Black
        Me.lblNotaria1.Location = New System.Drawing.Point(195, 75)
        Me.lblNotaria1.Name = "lblNotaria1"
        Me.lblNotaria1.Size = New System.Drawing.Size(261, 20)
        Me.lblNotaria1.TabIndex = 412
        Me.lblNotaria1.Text = "Notaria (Dep-Mun-Notaria)"
        '
        'lblEscritura
        '
        Me.lblEscritura.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblEscritura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEscritura.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEscritura.ForeColor = System.Drawing.Color.Black
        Me.lblEscritura.Location = New System.Drawing.Point(19, 75)
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
        Me.lblFechaEscritura.Location = New System.Drawing.Point(107, 75)
        Me.lblFechaEscritura.Name = "lblFechaEscritura"
        Me.lblFechaEscritura.Size = New System.Drawing.Size(84, 20)
        Me.lblFechaEscritura.TabIndex = 410
        Me.lblFechaEscritura.Text = "Fech. escritura"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(873, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 20)
        Me.Label2.TabIndex = 409
        Me.Label2.Text = "Estado"
        '
        'txtTRCACORR
        '
        Me.txtTRCACORR.AccessibleDescription = "Corregimiento"
        Me.txtTRCACORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCACORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCACORR.Location = New System.Drawing.Point(107, 52)
        Me.txtTRCACORR.MaxLength = 2
        Me.txtTRCACORR.Name = "txtTRCACORR"
        Me.txtTRCACORR.Size = New System.Drawing.Size(85, 20)
        Me.txtTRCACORR.TabIndex = 2
        '
        'txtTRCAMUNI
        '
        Me.txtTRCAMUNI.AccessibleDescription = "Municipio"
        Me.txtTRCAMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCAMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAMUNI.Location = New System.Drawing.Point(19, 52)
        Me.txtTRCAMUNI.MaxLength = 3
        Me.txtTRCAMUNI.Name = "txtTRCAMUNI"
        Me.txtTRCAMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtTRCAMUNI.TabIndex = 1
        '
        'lblClaseOSector2
        '
        Me.lblClaseOSector2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseOSector2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseOSector2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseOSector2.ForeColor = System.Drawing.Color.Black
        Me.lblClaseOSector2.Location = New System.Drawing.Point(459, 29)
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
        Me.lblCategoriaDeSuelo.Location = New System.Drawing.Point(548, 29)
        Me.lblCategoriaDeSuelo.Name = "lblCategoriaDeSuelo"
        Me.lblCategoriaDeSuelo.Size = New System.Drawing.Size(85, 20)
        Me.lblCategoriaDeSuelo.TabIndex = 402
        Me.lblCategoriaDeSuelo.Text = "Vigencia"
        '
        'txtTRCAPRED
        '
        Me.txtTRCAPRED.AccessibleDescription = "Predio "
        Me.txtTRCAPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCAPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRCAPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAPRED.ForeColor = System.Drawing.Color.Black
        Me.txtTRCAPRED.Location = New System.Drawing.Point(371, 52)
        Me.txtTRCAPRED.MaxLength = 5
        Me.txtTRCAPRED.Name = "txtTRCAPRED"
        Me.txtTRCAPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtTRCAPRED.TabIndex = 5
        '
        'txtTRCAMANZ
        '
        Me.txtTRCAMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtTRCAMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCAMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRCAMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtTRCAMANZ.Location = New System.Drawing.Point(283, 52)
        Me.txtTRCAMANZ.MaxLength = 3
        Me.txtTRCAMANZ.Name = "txtTRCAMANZ"
        Me.txtTRCAMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtTRCAMANZ.TabIndex = 4
        '
        'txtTRCABARR
        '
        Me.txtTRCABARR.AccessibleDescription = "Barrio "
        Me.txtTRCABARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCABARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRCABARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCABARR.ForeColor = System.Drawing.Color.Black
        Me.txtTRCABARR.Location = New System.Drawing.Point(195, 52)
        Me.txtTRCABARR.MaxLength = 3
        Me.txtTRCABARR.Name = "txtTRCABARR"
        Me.txtTRCABARR.Size = New System.Drawing.Size(85, 20)
        Me.txtTRCABARR.TabIndex = 3
        '
        'lblPredio
        '
        Me.lblPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredio.ForeColor = System.Drawing.Color.Black
        Me.lblPredio.Location = New System.Drawing.Point(371, 29)
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
        Me.lblManzana.Location = New System.Drawing.Point(283, 29)
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
        Me.lblBarrio.Location = New System.Drawing.Point(195, 29)
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
        Me.lblCorregimiento.Location = New System.Drawing.Point(107, 29)
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
        Me.lblMunicipio.Location = New System.Drawing.Point(19, 29)
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
        Me.dgvCONSULTA.Location = New System.Drawing.Point(19, 124)
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        Me.dgvCONSULTA.RowHeadersVisible = False
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(939, 323)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 40
        '
        'frm_consulta_trabajo_de_campo_TRABCAMP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1007, 583)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraPERIODO)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_consulta_trabajo_de_campo_TRABCAMP"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CONSULTA TRABAJO DE CAMPO"
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
    Friend WithEvents cmdConsultar As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraPERIODO As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTRCADESC As System.Windows.Forms.TextBox
    Friend WithEvents txtTRCAFEES As System.Windows.Forms.TextBox
    Friend WithEvents txtTRCAESTA As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTRCANOTA As System.Windows.Forms.TextBox
    Friend WithEvents txtTRCANOMU As System.Windows.Forms.TextBox
    Friend WithEvents txtTRCANODE As System.Windows.Forms.TextBox
    Friend WithEvents txtTRCAESCR As System.Windows.Forms.TextBox
    Friend WithEvents txtTRCACAAC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTRCAVIGE As System.Windows.Forms.TextBox
    Friend WithEvents txtTRCACLSE As System.Windows.Forms.TextBox
    Friend WithEvents txtTRCAMAIN As System.Windows.Forms.TextBox
    Friend WithEvents lblNotaria1 As System.Windows.Forms.Label
    Friend WithEvents lblEscritura As System.Windows.Forms.Label
    Friend WithEvents lblFechaEscritura As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTRCACORR As System.Windows.Forms.TextBox
    Friend WithEvents txtTRCAMUNI As System.Windows.Forms.TextBox
    Friend WithEvents lblClaseOSector2 As System.Windows.Forms.Label
    Friend WithEvents lblCategoriaDeSuelo As System.Windows.Forms.Label
    Friend WithEvents txtTRCAPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtTRCAMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtTRCABARR As System.Windows.Forms.TextBox
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
End Class
