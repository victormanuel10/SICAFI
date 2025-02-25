<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_MOVIGEOG
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
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdLimpiar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdConsultar = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraMOVIGEOG = New System.Windows.Forms.GroupBox()
        Me.txtMOGEFEFI = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMOGEUSUA = New System.Windows.Forms.TextBox()
        Me.txtMOGEFEIN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMOGEESTA = New System.Windows.Forms.TextBox()
        Me.txtMOGECAAC = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMOGEVIGE = New System.Windows.Forms.TextBox()
        Me.txtMOGECLSE = New System.Windows.Forms.TextBox()
        Me.txtTRCAOBSE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMOGECORR = New System.Windows.Forms.TextBox()
        Me.txtMOGEMUNI = New System.Windows.Forms.TextBox()
        Me.lblClaseOSector2 = New System.Windows.Forms.Label()
        Me.lblCategoriaDeSuelo = New System.Windows.Forms.Label()
        Me.txtMOGEPRED = New System.Windows.Forms.TextBox()
        Me.txtMOGEMANZ = New System.Windows.Forms.TextBox()
        Me.txtMOGEBARR = New System.Windows.Forms.TextBox()
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 440)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(918, 60)
        Me.GroupBox1.TabIndex = 80
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
        'fraMOVIGEOG
        '
        Me.fraMOVIGEOG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraMOVIGEOG.BackColor = System.Drawing.SystemColors.Control
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOGEFEFI)
        Me.fraMOVIGEOG.Controls.Add(Me.Label3)
        Me.fraMOVIGEOG.Controls.Add(Me.Label6)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOGEUSUA)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOGEFEIN)
        Me.fraMOVIGEOG.Controls.Add(Me.Label5)
        Me.fraMOVIGEOG.Controls.Add(Me.Label4)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOGEESTA)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOGECAAC)
        Me.fraMOVIGEOG.Controls.Add(Me.Label1)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOGEVIGE)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOGECLSE)
        Me.fraMOVIGEOG.Controls.Add(Me.txtTRCAOBSE)
        Me.fraMOVIGEOG.Controls.Add(Me.Label2)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOGECORR)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOGEMUNI)
        Me.fraMOVIGEOG.Controls.Add(Me.lblClaseOSector2)
        Me.fraMOVIGEOG.Controls.Add(Me.lblCategoriaDeSuelo)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOGEPRED)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOGEMANZ)
        Me.fraMOVIGEOG.Controls.Add(Me.txtMOGEBARR)
        Me.fraMOVIGEOG.Controls.Add(Me.lblPredio)
        Me.fraMOVIGEOG.Controls.Add(Me.lblManzana)
        Me.fraMOVIGEOG.Controls.Add(Me.lblBarrio)
        Me.fraMOVIGEOG.Controls.Add(Me.lblCorregimiento)
        Me.fraMOVIGEOG.Controls.Add(Me.lblMunicipio)
        Me.fraMOVIGEOG.Controls.Add(Me.dgvCONSULTA)
        Me.fraMOVIGEOG.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraMOVIGEOG.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraMOVIGEOG.Location = New System.Drawing.Point(12, 12)
        Me.fraMOVIGEOG.Name = "fraMOVIGEOG"
        Me.fraMOVIGEOG.Size = New System.Drawing.Size(916, 425)
        Me.fraMOVIGEOG.TabIndex = 79
        Me.fraMOVIGEOG.TabStop = False
        Me.fraMOVIGEOG.Text = "CONSULTA MOVIMIENTO GEOGRAFICO"
        '
        'txtMOGEFEFI
        '
        Me.txtMOGEFEFI.AccessibleDescription = "Estado"
        Me.txtMOGEFEFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOGEFEFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOGEFEFI.Location = New System.Drawing.Point(726, 52)
        Me.txtMOGEFEFI.MaxLength = 15
        Me.txtMOGEFEFI.Name = "txtMOGEFEFI"
        Me.txtMOGEFEFI.Size = New System.Drawing.Size(85, 20)
        Me.txtMOGEFEFI.TabIndex = 443
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
        'txtMOGEUSUA
        '
        Me.txtMOGEUSUA.AccessibleDescription = "Descripción"
        Me.txtMOGEUSUA.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOGEUSUA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOGEUSUA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOGEUSUA.ForeColor = System.Drawing.Color.Black
        Me.txtMOGEUSUA.Location = New System.Drawing.Point(107, 98)
        Me.txtMOGEUSUA.MaxLength = 100
        Me.txtMOGEUSUA.Name = "txtMOGEUSUA"
        Me.txtMOGEUSUA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMOGEUSUA.Size = New System.Drawing.Size(260, 20)
        Me.txtMOGEUSUA.TabIndex = 441
        '
        'txtMOGEFEIN
        '
        Me.txtMOGEFEIN.AccessibleDescription = "Estado"
        Me.txtMOGEFEIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOGEFEIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOGEFEIN.Location = New System.Drawing.Point(637, 52)
        Me.txtMOGEFEIN.MaxLength = 15
        Me.txtMOGEFEIN.Name = "txtMOGEFEIN"
        Me.txtMOGEFEIN.Size = New System.Drawing.Size(85, 20)
        Me.txtMOGEFEIN.TabIndex = 8
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
        'txtMOGEESTA
        '
        Me.txtMOGEESTA.AccessibleDescription = "Estado"
        Me.txtMOGEESTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOGEESTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtMOGEESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOGEESTA.Location = New System.Drawing.Point(815, 52)
        Me.txtMOGEESTA.MaxLength = 2
        Me.txtMOGEESTA.Name = "txtMOGEESTA"
        Me.txtMOGEESTA.Size = New System.Drawing.Size(85, 20)
        Me.txtMOGEESTA.TabIndex = 9
        '
        'txtMOGECAAC
        '
        Me.txtMOGECAAC.AccessibleDescription = "Causa del acto"
        Me.txtMOGECAAC.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOGECAAC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOGECAAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOGECAAC.ForeColor = System.Drawing.Color.Black
        Me.txtMOGECAAC.Location = New System.Drawing.Point(19, 98)
        Me.txtMOGECAAC.MaxLength = 10
        Me.txtMOGECAAC.Name = "txtMOGECAAC"
        Me.txtMOGECAAC.Size = New System.Drawing.Size(84, 20)
        Me.txtMOGECAAC.TabIndex = 8
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
        'txtMOGEVIGE
        '
        Me.txtMOGEVIGE.AccessibleDescription = "Vigencia"
        Me.txtMOGEVIGE.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOGEVIGE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOGEVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOGEVIGE.ForeColor = System.Drawing.Color.Black
        Me.txtMOGEVIGE.Location = New System.Drawing.Point(548, 52)
        Me.txtMOGEVIGE.MaxLength = 5
        Me.txtMOGEVIGE.Name = "txtMOGEVIGE"
        Me.txtMOGEVIGE.Size = New System.Drawing.Size(85, 20)
        Me.txtMOGEVIGE.TabIndex = 7
        '
        'txtMOGECLSE
        '
        Me.txtMOGECLSE.AccessibleDescription = "Sector"
        Me.txtMOGECLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOGECLSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOGECLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOGECLSE.ForeColor = System.Drawing.Color.Black
        Me.txtMOGECLSE.Location = New System.Drawing.Point(459, 52)
        Me.txtMOGECLSE.MaxLength = 5
        Me.txtMOGECLSE.Name = "txtMOGECLSE"
        Me.txtMOGECLSE.Size = New System.Drawing.Size(85, 20)
        Me.txtMOGECLSE.TabIndex = 6
        '
        'txtTRCAOBSE
        '
        Me.txtTRCAOBSE.AccessibleDescription = "Observaciones"
        Me.txtTRCAOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRCAOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTRCAOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtTRCAOBSE.Location = New System.Drawing.Point(371, 98)
        Me.txtTRCAOBSE.MaxLength = 1000
        Me.txtTRCAOBSE.Name = "txtTRCAOBSE"
        Me.txtTRCAOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTRCAOBSE.Size = New System.Drawing.Size(529, 20)
        Me.txtTRCAOBSE.TabIndex = 16
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
        'txtMOGECORR
        '
        Me.txtMOGECORR.AccessibleDescription = "Corregimiento"
        Me.txtMOGECORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOGECORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOGECORR.Location = New System.Drawing.Point(107, 52)
        Me.txtMOGECORR.MaxLength = 2
        Me.txtMOGECORR.Name = "txtMOGECORR"
        Me.txtMOGECORR.Size = New System.Drawing.Size(85, 20)
        Me.txtMOGECORR.TabIndex = 2
        '
        'txtMOGEMUNI
        '
        Me.txtMOGEMUNI.AccessibleDescription = "Municipio"
        Me.txtMOGEMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOGEMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOGEMUNI.Location = New System.Drawing.Point(19, 52)
        Me.txtMOGEMUNI.MaximumSize = New System.Drawing.Size(85, 20)
        Me.txtMOGEMUNI.MaxLength = 3
        Me.txtMOGEMUNI.MinimumSize = New System.Drawing.Size(85, 20)
        Me.txtMOGEMUNI.Name = "txtMOGEMUNI"
        Me.txtMOGEMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtMOGEMUNI.TabIndex = 1
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
        'txtMOGEPRED
        '
        Me.txtMOGEPRED.AccessibleDescription = "Predio "
        Me.txtMOGEPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOGEPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOGEPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOGEPRED.ForeColor = System.Drawing.Color.Black
        Me.txtMOGEPRED.Location = New System.Drawing.Point(371, 52)
        Me.txtMOGEPRED.MaxLength = 5
        Me.txtMOGEPRED.Name = "txtMOGEPRED"
        Me.txtMOGEPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtMOGEPRED.TabIndex = 5
        '
        'txtMOGEMANZ
        '
        Me.txtMOGEMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtMOGEMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOGEMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOGEMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOGEMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtMOGEMANZ.Location = New System.Drawing.Point(283, 52)
        Me.txtMOGEMANZ.MaxLength = 3
        Me.txtMOGEMANZ.Name = "txtMOGEMANZ"
        Me.txtMOGEMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtMOGEMANZ.TabIndex = 4
        '
        'txtMOGEBARR
        '
        Me.txtMOGEBARR.AccessibleDescription = "Barrio "
        Me.txtMOGEBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtMOGEBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOGEBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOGEBARR.ForeColor = System.Drawing.Color.Black
        Me.txtMOGEBARR.Location = New System.Drawing.Point(195, 52)
        Me.txtMOGEBARR.MaxLength = 3
        Me.txtMOGEBARR.Name = "txtMOGEBARR"
        Me.txtMOGEBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtMOGEBARR.TabIndex = 3
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
        'frm_consultar_MOVIGEOG
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
        Me.Name = "frm_consultar_MOVIGEOG"
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMOGEUSUA As System.Windows.Forms.TextBox
    Friend WithEvents txtMOGEFEIN As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMOGEESTA As System.Windows.Forms.TextBox
    Friend WithEvents txtMOGECAAC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMOGEVIGE As System.Windows.Forms.TextBox
    Friend WithEvents txtMOGECLSE As System.Windows.Forms.TextBox
    Friend WithEvents txtTRCAOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMOGECORR As System.Windows.Forms.TextBox
    Friend WithEvents txtMOGEMUNI As System.Windows.Forms.TextBox
    Friend WithEvents lblClaseOSector2 As System.Windows.Forms.Label
    Friend WithEvents lblCategoriaDeSuelo As System.Windows.Forms.Label
    Friend WithEvents txtMOGEPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtMOGEMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtMOGEBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents txtMOGEFEFI As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
