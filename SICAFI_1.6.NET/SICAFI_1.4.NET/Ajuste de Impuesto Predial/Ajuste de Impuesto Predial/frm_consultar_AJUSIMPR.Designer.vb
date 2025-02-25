<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_AJUSIMPR
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
        Me.txtAJIPSECU = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAJIPESTA = New System.Windows.Forms.TextBox()
        Me.txtAJIPFEOF = New System.Windows.Forms.TextBox()
        Me.txtAJIPFERE = New System.Windows.Forms.TextBox()
        Me.txtAJIPFERA = New System.Windows.Forms.TextBox()
        Me.txtAJIPMAIN = New System.Windows.Forms.TextBox()
        Me.txtAJIPCLSE = New System.Windows.Forms.TextBox()
        Me.txtAJIPVIGE = New System.Windows.Forms.TextBox()
        Me.txtAJIPNUOF = New System.Windows.Forms.TextBox()
        Me.txtAJIPNURE = New System.Windows.Forms.TextBox()
        Me.txtAJIPNURA = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtAJIPNUFI = New System.Windows.Forms.TextBox()
        Me.lblNumeroDocumento = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtAJIPUNPR = New System.Windows.Forms.TextBox()
        Me.txtAJIPEDIF = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAJIPOBSE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtAJIPCORR = New System.Windows.Forms.TextBox()
        Me.txtAJIPMUNI = New System.Windows.Forms.TextBox()
        Me.lblClaseOSector2 = New System.Windows.Forms.Label()
        Me.lblCategoriaDeSuelo = New System.Windows.Forms.Label()
        Me.txtAJIPPRED = New System.Windows.Forms.TextBox()
        Me.txtAJIPMANZ = New System.Windows.Forms.TextBox()
        Me.txtAJIPBARR = New System.Windows.Forms.TextBox()
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 449)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(742, 60)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 521)
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
        Me.fraPERIODO.Controls.Add(Me.txtAJIPSECU)
        Me.fraPERIODO.Controls.Add(Me.Label4)
        Me.fraPERIODO.Controls.Add(Me.Label3)
        Me.fraPERIODO.Controls.Add(Me.txtAJIPESTA)
        Me.fraPERIODO.Controls.Add(Me.txtAJIPFEOF)
        Me.fraPERIODO.Controls.Add(Me.txtAJIPFERE)
        Me.fraPERIODO.Controls.Add(Me.txtAJIPFERA)
        Me.fraPERIODO.Controls.Add(Me.txtAJIPMAIN)
        Me.fraPERIODO.Controls.Add(Me.txtAJIPCLSE)
        Me.fraPERIODO.Controls.Add(Me.txtAJIPVIGE)
        Me.fraPERIODO.Controls.Add(Me.txtAJIPNUOF)
        Me.fraPERIODO.Controls.Add(Me.txtAJIPNURE)
        Me.fraPERIODO.Controls.Add(Me.txtAJIPNURA)
        Me.fraPERIODO.Controls.Add(Me.Label14)
        Me.fraPERIODO.Controls.Add(Me.Label13)
        Me.fraPERIODO.Controls.Add(Me.Label15)
        Me.fraPERIODO.Controls.Add(Me.Label12)
        Me.fraPERIODO.Controls.Add(Me.Label18)
        Me.fraPERIODO.Controls.Add(Me.Label39)
        Me.fraPERIODO.Controls.Add(Me.txtAJIPNUFI)
        Me.fraPERIODO.Controls.Add(Me.lblNumeroDocumento)
        Me.fraPERIODO.Controls.Add(Me.Label11)
        Me.fraPERIODO.Controls.Add(Me.txtAJIPUNPR)
        Me.fraPERIODO.Controls.Add(Me.txtAJIPEDIF)
        Me.fraPERIODO.Controls.Add(Me.Label1)
        Me.fraPERIODO.Controls.Add(Me.Label6)
        Me.fraPERIODO.Controls.Add(Me.Label5)
        Me.fraPERIODO.Controls.Add(Me.txtAJIPOBSE)
        Me.fraPERIODO.Controls.Add(Me.Label2)
        Me.fraPERIODO.Controls.Add(Me.Label33)
        Me.fraPERIODO.Controls.Add(Me.txtAJIPCORR)
        Me.fraPERIODO.Controls.Add(Me.txtAJIPMUNI)
        Me.fraPERIODO.Controls.Add(Me.lblClaseOSector2)
        Me.fraPERIODO.Controls.Add(Me.lblCategoriaDeSuelo)
        Me.fraPERIODO.Controls.Add(Me.txtAJIPPRED)
        Me.fraPERIODO.Controls.Add(Me.txtAJIPMANZ)
        Me.fraPERIODO.Controls.Add(Me.txtAJIPBARR)
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
        Me.fraPERIODO.Location = New System.Drawing.Point(12, 9)
        Me.fraPERIODO.Name = "fraPERIODO"
        Me.fraPERIODO.Size = New System.Drawing.Size(742, 434)
        Me.fraPERIODO.TabIndex = 82
        Me.fraPERIODO.TabStop = False
        Me.fraPERIODO.Text = "CONSULTA AJUSTE DE IMPUESTO PREDIAL"
        '
        'txtAJIPSECU
        '
        Me.txtAJIPSECU.AccessibleDescription = "Tramite"
        Me.txtAJIPSECU.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPSECU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIPSECU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPSECU.ForeColor = System.Drawing.Color.Black
        Me.txtAJIPSECU.Location = New System.Drawing.Point(110, 118)
        Me.txtAJIPSECU.MaxLength = 4
        Me.txtAJIPSECU.Name = "txtAJIPSECU"
        Me.txtAJIPSECU.Size = New System.Drawing.Size(84, 20)
        Me.txtAJIPSECU.TabIndex = 483
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 20)
        Me.Label4.TabIndex = 484
        Me.Label4.Text = "Nro. Tramite"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(548, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 15)
        Me.Label3.TabIndex = 472
        Me.Label3.Text = "(dd-mm-aaaa)"
        '
        'txtAJIPESTA
        '
        Me.txtAJIPESTA.AccessibleDescription = "Estado"
        Me.txtAJIPESTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPESTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtAJIPESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPESTA.ForeColor = System.Drawing.Color.Black
        Me.txtAJIPESTA.Location = New System.Drawing.Point(638, 95)
        Me.txtAJIPESTA.MaxLength = 2
        Me.txtAJIPESTA.Name = "txtAJIPESTA"
        Me.txtAJIPESTA.Size = New System.Drawing.Size(84, 20)
        Me.txtAJIPESTA.TabIndex = 26
        '
        'txtAJIPFEOF
        '
        Me.txtAJIPFEOF.AccessibleDescription = "Fecha radicado"
        Me.txtAJIPFEOF.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPFEOF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIPFEOF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPFEOF.ForeColor = System.Drawing.Color.Black
        Me.txtAJIPFEOF.Location = New System.Drawing.Point(374, 187)
        Me.txtAJIPFEOF.MaxLength = 10
        Me.txtAJIPFEOF.Name = "txtAJIPFEOF"
        Me.txtAJIPFEOF.Size = New System.Drawing.Size(173, 20)
        Me.txtAJIPFEOF.TabIndex = 21
        '
        'txtAJIPFERE
        '
        Me.txtAJIPFERE.AccessibleDescription = "Fecha radicado"
        Me.txtAJIPFERE.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPFERE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIPFERE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPFERE.ForeColor = System.Drawing.Color.Black
        Me.txtAJIPFERE.Location = New System.Drawing.Point(374, 164)
        Me.txtAJIPFERE.MaxLength = 10
        Me.txtAJIPFERE.Name = "txtAJIPFERE"
        Me.txtAJIPFERE.Size = New System.Drawing.Size(173, 20)
        Me.txtAJIPFERE.TabIndex = 19
        '
        'txtAJIPFERA
        '
        Me.txtAJIPFERA.AccessibleDescription = "Fecha radicado"
        Me.txtAJIPFERA.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPFERA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIPFERA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPFERA.ForeColor = System.Drawing.Color.Black
        Me.txtAJIPFERA.Location = New System.Drawing.Point(374, 141)
        Me.txtAJIPFERA.MaxLength = 10
        Me.txtAJIPFERA.Name = "txtAJIPFERA"
        Me.txtAJIPFERA.Size = New System.Drawing.Size(173, 20)
        Me.txtAJIPFERA.TabIndex = 17
        '
        'txtAJIPMAIN
        '
        Me.txtAJIPMAIN.AccessibleDescription = "Matricula"
        Me.txtAJIPMAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPMAIN.ForeColor = System.Drawing.Color.Black
        Me.txtAJIPMAIN.Location = New System.Drawing.Point(374, 118)
        Me.txtAJIPMAIN.MaxLength = 11
        Me.txtAJIPMAIN.Name = "txtAJIPMAIN"
        Me.txtAJIPMAIN.Size = New System.Drawing.Size(173, 20)
        Me.txtAJIPMAIN.TabIndex = 14
        '
        'txtAJIPCLSE
        '
        Me.txtAJIPCLSE.AccessibleDescription = "Municipio"
        Me.txtAJIPCLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPCLSE.Location = New System.Drawing.Point(110, 95)
        Me.txtAJIPCLSE.MaxLength = 1
        Me.txtAJIPCLSE.Name = "txtAJIPCLSE"
        Me.txtAJIPCLSE.Size = New System.Drawing.Size(85, 20)
        Me.txtAJIPCLSE.TabIndex = 8
        '
        'txtAJIPVIGE
        '
        Me.txtAJIPVIGE.AccessibleDescription = "Predio "
        Me.txtAJIPVIGE.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPVIGE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIPVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPVIGE.ForeColor = System.Drawing.Color.Black
        Me.txtAJIPVIGE.Location = New System.Drawing.Point(286, 95)
        Me.txtAJIPVIGE.MaxLength = 4
        Me.txtAJIPVIGE.Name = "txtAJIPVIGE"
        Me.txtAJIPVIGE.Size = New System.Drawing.Size(85, 20)
        Me.txtAJIPVIGE.TabIndex = 9
        '
        'txtAJIPNUOF
        '
        Me.txtAJIPNUOF.AccessibleDescription = "Radicado"
        Me.txtAJIPNUOF.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPNUOF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIPNUOF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPNUOF.ForeColor = System.Drawing.Color.Black
        Me.txtAJIPNUOF.Location = New System.Drawing.Point(197, 187)
        Me.txtAJIPNUOF.MaxLength = 9
        Me.txtAJIPNUOF.Name = "txtAJIPNUOF"
        Me.txtAJIPNUOF.Size = New System.Drawing.Size(85, 20)
        Me.txtAJIPNUOF.TabIndex = 20
        '
        'txtAJIPNURE
        '
        Me.txtAJIPNURE.AccessibleDescription = "Radicado"
        Me.txtAJIPNURE.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPNURE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIPNURE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPNURE.ForeColor = System.Drawing.Color.Black
        Me.txtAJIPNURE.Location = New System.Drawing.Point(197, 164)
        Me.txtAJIPNURE.MaxLength = 9
        Me.txtAJIPNURE.Name = "txtAJIPNURE"
        Me.txtAJIPNURE.Size = New System.Drawing.Size(85, 20)
        Me.txtAJIPNURE.TabIndex = 18
        '
        'txtAJIPNURA
        '
        Me.txtAJIPNURA.AccessibleDescription = "Radicado"
        Me.txtAJIPNURA.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPNURA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIPNURA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPNURA.ForeColor = System.Drawing.Color.Black
        Me.txtAJIPNURA.Location = New System.Drawing.Point(197, 141)
        Me.txtAJIPNURA.MaxLength = 9
        Me.txtAJIPNURA.Name = "txtAJIPNURA"
        Me.txtAJIPNURA.Size = New System.Drawing.Size(85, 20)
        Me.txtAJIPNURA.TabIndex = 16
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(286, 187)
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
        Me.Label13.Location = New System.Drawing.Point(286, 164)
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
        Me.Label15.Location = New System.Drawing.Point(19, 187)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(175, 20)
        Me.Label15.TabIndex = 466
        Me.Label15.Text = "Nro. de Oficio"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(286, 141)
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
        Me.Label18.Location = New System.Drawing.Point(19, 164)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(175, 20)
        Me.Label18.TabIndex = 463
        Me.Label18.Text = "Nro. de Resolución"
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label39.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(19, 141)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(175, 20)
        Me.Label39.TabIndex = 462
        Me.Label39.Text = "Nro. de Radicado"
        '
        'txtAJIPNUFI
        '
        Me.txtAJIPNUFI.AccessibleDescription = "Nro. Ficha"
        Me.txtAJIPNUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPNUFI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIPNUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPNUFI.ForeColor = System.Drawing.Color.Black
        Me.txtAJIPNUFI.Location = New System.Drawing.Point(462, 95)
        Me.txtAJIPNUFI.MaxLength = 49
        Me.txtAJIPNUFI.Name = "txtAJIPNUFI"
        Me.txtAJIPNUFI.Size = New System.Drawing.Size(84, 20)
        Me.txtAJIPNUFI.TabIndex = 10
        '
        'lblNumeroDocumento
        '
        Me.lblNumeroDocumento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblNumeroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumeroDocumento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroDocumento.ForeColor = System.Drawing.Color.Black
        Me.lblNumeroDocumento.Location = New System.Drawing.Point(374, 95)
        Me.lblNumeroDocumento.Name = "lblNumeroDocumento"
        Me.lblNumeroDocumento.Size = New System.Drawing.Size(85, 20)
        Me.lblNumeroDocumento.TabIndex = 457
        Me.lblNumeroDocumento.Text = "Nro. Ficha"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(198, 118)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(173, 20)
        Me.Label11.TabIndex = 461
        Me.Label11.Text = "Matricula inmobiliaria"
        '
        'txtAJIPUNPR
        '
        Me.txtAJIPUNPR.AccessibleDescription = "Unidad predial"
        Me.txtAJIPUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIPUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtAJIPUNPR.Location = New System.Drawing.Point(638, 72)
        Me.txtAJIPUNPR.MaxLength = 5
        Me.txtAJIPUNPR.Name = "txtAJIPUNPR"
        Me.txtAJIPUNPR.Size = New System.Drawing.Size(85, 20)
        Me.txtAJIPUNPR.TabIndex = 7
        '
        'txtAJIPEDIF
        '
        Me.txtAJIPEDIF.AccessibleDescription = "Edificio"
        Me.txtAJIPEDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPEDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIPEDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPEDIF.ForeColor = System.Drawing.Color.Black
        Me.txtAJIPEDIF.Location = New System.Drawing.Point(550, 72)
        Me.txtAJIPEDIF.MaxLength = 3
        Me.txtAJIPEDIF.Name = "txtAJIPEDIF"
        Me.txtAJIPEDIF.Size = New System.Drawing.Size(85, 20)
        Me.txtAJIPEDIF.TabIndex = 6
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
        Me.Label5.Location = New System.Drawing.Point(20, 210)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(703, 20)
        Me.Label5.TabIndex = 454
        Me.Label5.Text = "OBSERVACIONES"
        '
        'txtAJIPOBSE
        '
        Me.txtAJIPOBSE.AccessibleDescription = "Observaciones"
        Me.txtAJIPOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIPOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtAJIPOBSE.Location = New System.Drawing.Point(20, 233)
        Me.txtAJIPOBSE.MaxLength = 1000
        Me.txtAJIPOBSE.Name = "txtAJIPOBSE"
        Me.txtAJIPOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAJIPOBSE.Size = New System.Drawing.Size(703, 20)
        Me.txtAJIPOBSE.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(550, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 20)
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
        'txtAJIPCORR
        '
        Me.txtAJIPCORR.AccessibleDescription = "Corregimiento"
        Me.txtAJIPCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPCORR.Location = New System.Drawing.Point(198, 72)
        Me.txtAJIPCORR.MaxLength = 2
        Me.txtAJIPCORR.Name = "txtAJIPCORR"
        Me.txtAJIPCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtAJIPCORR.TabIndex = 2
        '
        'txtAJIPMUNI
        '
        Me.txtAJIPMUNI.AccessibleDescription = "Municipio"
        Me.txtAJIPMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPMUNI.Location = New System.Drawing.Point(110, 72)
        Me.txtAJIPMUNI.MaxLength = 3
        Me.txtAJIPMUNI.Name = "txtAJIPMUNI"
        Me.txtAJIPMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtAJIPMUNI.TabIndex = 1
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
        'txtAJIPPRED
        '
        Me.txtAJIPPRED.AccessibleDescription = "Predio "
        Me.txtAJIPPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIPPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPPRED.ForeColor = System.Drawing.Color.Black
        Me.txtAJIPPRED.Location = New System.Drawing.Point(462, 72)
        Me.txtAJIPPRED.MaxLength = 5
        Me.txtAJIPPRED.Name = "txtAJIPPRED"
        Me.txtAJIPPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtAJIPPRED.TabIndex = 5
        '
        'txtAJIPMANZ
        '
        Me.txtAJIPMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtAJIPMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIPMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtAJIPMANZ.Location = New System.Drawing.Point(374, 72)
        Me.txtAJIPMANZ.MaxLength = 3
        Me.txtAJIPMANZ.Name = "txtAJIPMANZ"
        Me.txtAJIPMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtAJIPMANZ.TabIndex = 4
        '
        'txtAJIPBARR
        '
        Me.txtAJIPBARR.AccessibleDescription = "Barrio "
        Me.txtAJIPBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIPBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIPBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIPBARR.ForeColor = System.Drawing.Color.Black
        Me.txtAJIPBARR.Location = New System.Drawing.Point(286, 72)
        Me.txtAJIPBARR.MaxLength = 3
        Me.txtAJIPBARR.Name = "txtAJIPBARR"
        Me.txtAJIPBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtAJIPBARR.TabIndex = 3
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
        Me.dgvCONSULTA.Location = New System.Drawing.Point(19, 259)
        Me.dgvCONSULTA.MultiSelect = False
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        Me.dgvCONSULTA.RowHeadersVisible = False
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(703, 154)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 40
        '
        'frm_consultar_AJUSIMPR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 546)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraPERIODO)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(788, 582)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(788, 582)
        Me.Name = "frm_consultar_AJUSIMPR"
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
    Friend WithEvents txtAJIPSECU As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAJIPESTA As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIPFEOF As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIPFERE As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIPFERA As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIPMAIN As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIPCLSE As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIPVIGE As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIPNUOF As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIPNURE As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIPNURA As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtAJIPNUFI As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtAJIPUNPR As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIPEDIF As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAJIPOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtAJIPCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIPMUNI As System.Windows.Forms.TextBox
    Friend WithEvents lblClaseOSector2 As System.Windows.Forms.Label
    Friend WithEvents lblCategoriaDeSuelo As System.Windows.Forms.Label
    Friend WithEvents txtAJIPPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIPMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIPBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
End Class
