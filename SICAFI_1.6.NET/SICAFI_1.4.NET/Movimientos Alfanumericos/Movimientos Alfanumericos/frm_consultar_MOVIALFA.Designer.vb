<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_MOVIALFA
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
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdLimpiar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdConsultar = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraMOVIGEOG = New System.Windows.Forms.GroupBox()
        Me.txtMOALFEFI = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMOALUSUA = New System.Windows.Forms.TextBox()
        Me.txtMOALFEIN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMOALESTA = New System.Windows.Forms.TextBox()
        Me.txtMOALCAAC = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMOALVIGE = New System.Windows.Forms.TextBox()
        Me.txtMOALCLSE = New System.Windows.Forms.TextBox()
        Me.txtMOALOBSE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMOALCORR = New System.Windows.Forms.TextBox()
        Me.txtMOALMUNI = New System.Windows.Forms.TextBox()
        Me.lblClaseOSector2 = New System.Windows.Forms.Label()
        Me.lblCategoriaDeSuelo = New System.Windows.Forms.Label()
        Me.txtMOALPRED = New System.Windows.Forms.TextBox()
        Me.txtMOALMANZ = New System.Windows.Forms.TextBox()
        Me.txtMOALBARR = New System.Windows.Forms.TextBox()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.lblManzana = New System.Windows.Forms.Label()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.dgvCONSULTA = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraMOVIGEOG.SuspendLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdSalir)
        Me.GroupBox1.Controls.Add(Me.cmdLimpiar)
        Me.GroupBox1.Controls.Add(Me.cmdAceptar)
        Me.GroupBox1.Controls.Add(Me.cmdConsultar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 437)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(918, 60)
        Me.GroupBox1.TabIndex = 83
        Me.GroupBox1.TabStop = False
        '
        'cmdSalir
        '
        Me.cmdSalir.AccessibleDescription = "Salir"
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(802, 20)
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
        Me.cmdAceptar.Location = New System.Drawing.Point(695, 20)
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
        Me.cmdConsultar.Location = New System.Drawing.Point(588, 20)
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
        Me.strBARRESTA.Size = New System.Drawing.Size(942, 25)
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
        'fraMOVIGEOG
        '
        Me.fraMOVIGEOG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraMOVIGEOG.BackColor = System.Drawing.SystemColors.Control
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOALFEFI)
        Me.fraMOVIGEOG.Controls.Add(Me.Label3)
        Me.fraMOVIGEOG.Controls.Add(Me.Label6)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOALUSUA)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOALFEIN)
        Me.fraMOVIGEOG.Controls.Add(Me.Label5)
        Me.fraMOVIGEOG.Controls.Add(Me.Label4)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOALESTA)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOALCAAC)
        Me.fraMOVIGEOG.Controls.Add(Me.Label1)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOALVIGE)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOALCLSE)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOALOBSE)
        Me.fraMOVIGEOG.Controls.Add(Me.Label2)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOALCORR)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOALMUNI)
        Me.fraMOVIGEOG.Controls.Add(Me.lblClaseOSector2)
        Me.fraMOVIGEOG.Controls.Add(Me.lblCategoriaDeSuelo)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOALPRED)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOALMANZ)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOALBARR)
        Me.fraMOVIGEOG.Controls.Add(Me.lblPredio)
        Me.fraMOVIGEOG.Controls.Add(Me.lblManzana)
        Me.fraMOVIGEOG.Controls.Add(Me.lblBarrio)
        Me.fraMOVIGEOG.Controls.Add(Me.lblCorregimiento)
        Me.fraMOVIGEOG.Controls.Add(Me.lblMunicipio)
        Me.fraMOVIGEOG.Controls.Add(Me.dgvCONSULTA)
        Me.fraMOVIGEOG.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraMOVIGEOG.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraMOVIGEOG.Location = New System.Drawing.Point(12, 9)
        Me.fraMOVIGEOG.Name = "fraMOVIGEOG"
        Me.fraMOVIGEOG.Size = New System.Drawing.Size(916, 425)
        Me.fraMOVIGEOG.TabIndex = 82
        Me.fraMOVIGEOG.TabStop = False
        Me.fraMOVIGEOG.Text = "CONSULTA MOVIMIENTO ALFANUMERICOS"
        '
        'txtMOALFEFI
        '
        Me.txtMOALFEFI.AccessibleDescription = "Estado"
        Me.txtMOALFEFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOALFEFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOALFEFI.Location = New System.Drawing.Point(726, 52)
        Me.txtMOALFEFI.MaxLength = 15
        Me.txtMOALFEFI.Name = "txtMOALFEFI"
        Me.txtMOALFEFI.Size = New System.Drawing.Size(85, 20)
        Me.txtMOALFEFI.TabIndex = 443
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(726, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 20)
        Me.Label3.TabIndex = 444
        Me.Label3.Text = "Fecha finalizal."
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(107, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(260, 20)
        Me.Label6.TabIndex = 442
        Me.Label6.Text = "Usuario"
        '
        'txtMOALUSUA
        '
        Me.txtMOALUSUA.AccessibleDescription = "Descripción"
        Me.txtMOALUSUA.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOALUSUA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOALUSUA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOALUSUA.ForeColor = System.Drawing.Color.Black
        Me.txtMOALUSUA.Location = New System.Drawing.Point(107, 98)
        Me.txtMOALUSUA.MaxLength = 100
        Me.txtMOALUSUA.Name = "txtMOALUSUA"
        Me.txtMOALUSUA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMOALUSUA.Size = New System.Drawing.Size(260, 20)
        Me.txtMOALUSUA.TabIndex = 441
        '
        'txtMOALFEIN
        '
        Me.txtMOALFEIN.AccessibleDescription = "Estado"
        Me.txtMOALFEIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOALFEIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOALFEIN.Location = New System.Drawing.Point(637, 52)
        Me.txtMOALFEIN.MaxLength = 15
        Me.txtMOALFEIN.Name = "txtMOALFEIN"
        Me.txtMOALFEIN.Size = New System.Drawing.Size(85, 20)
        Me.txtMOALFEIN.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(637, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 20)
        Me.Label5.TabIndex = 438
        Me.Label5.Text = "Fecha ingreso"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(371, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(529, 20)
        Me.Label4.TabIndex = 428
        Me.Label4.Text = "Observación"
        '
        'txtMOALESTA
        '
        Me.txtMOALESTA.AccessibleDescription = "Estado"
        Me.txtMOALESTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOALESTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtMOALESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOALESTA.Location = New System.Drawing.Point(815, 52)
        Me.txtMOALESTA.MaxLength = 2
        Me.txtMOALESTA.Name = "txtMOALESTA"
        Me.txtMOALESTA.Size = New System.Drawing.Size(85, 20)
        Me.txtMOALESTA.TabIndex = 9
        '
        'txtMOALCAAC
        '
        Me.txtMOALCAAC.AccessibleDescription = "Causa del acto"
        Me.txtMOALCAAC.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOALCAAC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOALCAAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOALCAAC.ForeColor = System.Drawing.Color.Black
        Me.txtMOALCAAC.Location = New System.Drawing.Point(19, 98)
        Me.txtMOALCAAC.MaxLength = 10
        Me.txtMOALCAAC.Name = "txtMOALCAAC"
        Me.txtMOALCAAC.Size = New System.Drawing.Size(84, 20)
        Me.txtMOALCAAC.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 20)
        Me.Label1.TabIndex = 420
        Me.Label1.Text = "Causa del acto"
        '
        'txtMOALVIGE
        '
        Me.txtMOALVIGE.AccessibleDescription = "Vigencia"
        Me.txtMOALVIGE.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOALVIGE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOALVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOALVIGE.ForeColor = System.Drawing.Color.Black
        Me.txtMOALVIGE.Location = New System.Drawing.Point(548, 52)
        Me.txtMOALVIGE.MaxLength = 5
        Me.txtMOALVIGE.Name = "txtMOALVIGE"
        Me.txtMOALVIGE.Size = New System.Drawing.Size(85, 20)
        Me.txtMOALVIGE.TabIndex = 7
        '
        'txtMOALCLSE
        '
        Me.txtMOALCLSE.AccessibleDescription = "Sector"
        Me.txtMOALCLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOALCLSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOALCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOALCLSE.ForeColor = System.Drawing.Color.Black
        Me.txtMOALCLSE.Location = New System.Drawing.Point(459, 52)
        Me.txtMOALCLSE.MaxLength = 5
        Me.txtMOALCLSE.Name = "txtMOALCLSE"
        Me.txtMOALCLSE.Size = New System.Drawing.Size(85, 20)
        Me.txtMOALCLSE.TabIndex = 6
        '
        'txtMOALOBSE
        '
        Me.txtMOALOBSE.AccessibleDescription = "Observaciones"
        Me.txtMOALOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOALOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOALOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOALOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtMOALOBSE.Location = New System.Drawing.Point(371, 98)
        Me.txtMOALOBSE.MaxLength = 1000
        Me.txtMOALOBSE.Name = "txtMOALOBSE"
        Me.txtMOALOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMOALOBSE.Size = New System.Drawing.Size(529, 20)
        Me.txtMOALOBSE.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(815, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 20)
        Me.Label2.TabIndex = 409
        Me.Label2.Text = "Estado"
        '
        'txtMOALCORR
        '
        Me.txtMOALCORR.AccessibleDescription = "Corregimiento"
        Me.txtMOALCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOALCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOALCORR.Location = New System.Drawing.Point(107, 52)
        Me.txtMOALCORR.MaxLength = 2
        Me.txtMOALCORR.Name = "txtMOALCORR"
        Me.txtMOALCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtMOALCORR.TabIndex = 2
        '
        'txtMOALMUNI
        '
        Me.txtMOALMUNI.AccessibleDescription = "Municipio"
        Me.txtMOALMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOALMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOALMUNI.Location = New System.Drawing.Point(19, 52)
        Me.txtMOALMUNI.MaximumSize = New System.Drawing.Size(85, 20)
        Me.txtMOALMUNI.MaxLength = 3
        Me.txtMOALMUNI.MinimumSize = New System.Drawing.Size(85, 20)
        Me.txtMOALMUNI.Name = "txtMOALMUNI"
        Me.txtMOALMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtMOALMUNI.TabIndex = 1
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
        'txtMOALPRED
        '
        Me.txtMOALPRED.AccessibleDescription = "Predio "
        Me.txtMOALPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOALPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOALPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOALPRED.ForeColor = System.Drawing.Color.Black
        Me.txtMOALPRED.Location = New System.Drawing.Point(371, 52)
        Me.txtMOALPRED.MaxLength = 5
        Me.txtMOALPRED.Name = "txtMOALPRED"
        Me.txtMOALPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtMOALPRED.TabIndex = 5
        '
        'txtMOALMANZ
        '
        Me.txtMOALMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtMOALMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOALMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOALMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOALMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtMOALMANZ.Location = New System.Drawing.Point(283, 52)
        Me.txtMOALMANZ.MaxLength = 3
        Me.txtMOALMANZ.Name = "txtMOALMANZ"
        Me.txtMOALMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtMOALMANZ.TabIndex = 4
        '
        'txtMOALBARR
        '
        Me.txtMOALBARR.AccessibleDescription = "Barrio "
        Me.txtMOALBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOALBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOALBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOALBARR.ForeColor = System.Drawing.Color.Black
        Me.txtMOALBARR.Location = New System.Drawing.Point(195, 52)
        Me.txtMOALBARR.MaxLength = 3
        Me.txtMOALBARR.Name = "txtMOALBARR"
        Me.txtMOALBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtMOALBARR.TabIndex = 3
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
        Me.dgvCONSULTA.Size = New System.Drawing.Size(881, 285)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 40
        '
        'frm_consultar_MOVIALFA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 534)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraMOVIGEOG)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(958, 570)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(958, 570)
        Me.Name = "frm_consultar_MOVIALFA"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraMOVIGEOG.ResumeLayout(False)
        Me.fraMOVIGEOG.PerformLayout()
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
    Friend WithEvents fraMOVIGEOG As System.Windows.Forms.GroupBox
    Friend WithEvents txtMOALFEFI As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMOALUSUA As System.Windows.Forms.TextBox
    Friend WithEvents txtMOALFEIN As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMOALESTA As System.Windows.Forms.TextBox
    Friend WithEvents txtMOALCAAC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMOALVIGE As System.Windows.Forms.TextBox
    Friend WithEvents txtMOALCLSE As System.Windows.Forms.TextBox
    Friend WithEvents txtMOALOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMOALCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtMOALMUNI As System.Windows.Forms.TextBox
    Friend WithEvents lblClaseOSector2 As System.Windows.Forms.Label
    Friend WithEvents lblCategoriaDeSuelo As System.Windows.Forms.Label
    Friend WithEvents txtMOALPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtMOALMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtMOALBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
End Class
