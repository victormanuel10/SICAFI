<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_MUPRMUTA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_insertar_MUPRMUTA))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraCEDUCATA = New System.Windows.Forms.GroupBox()
        Me.txtMPMUNOVC = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtMPMUCAAC = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboMPMUNOVE = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboMPMUESTA = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMPMUUNPR = New System.Windows.Forms.TextBox()
        Me.txtMPMUEDIF = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboMPMUCLSE = New System.Windows.Forms.ComboBox()
        Me.txtMPMUNUFI = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMPMUCORR = New System.Windows.Forms.TextBox()
        Me.txtMPMUMUNI = New System.Windows.Forms.TextBox()
        Me.txtMPMUPRED = New System.Windows.Forms.TextBox()
        Me.txtMPMUMANZ = New System.Windows.Forms.TextBox()
        Me.txtMPMUBARR = New System.Windows.Forms.TextBox()
        Me.lblCodigoActual = New System.Windows.Forms.Label()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.lblManzana = New System.Windows.Forms.Label()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lblMPMUVIGE = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblMPMURESO = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblMPMUTIRE = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraCEDUCATA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdSALIR)
        Me.GroupBox2.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 255)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(776, 46)
        Me.GroupBox2.TabIndex = 357
        Me.GroupBox2.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = CType(resources.GetObject("cmdSALIR.Image"), System.Drawing.Image)
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(392, 14)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 18
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = CType(resources.GetObject("cmdGUARDAR.Image"), System.Drawing.Image)
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(285, 14)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 17
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 315)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(813, 25)
        Me.strBARRESTA.TabIndex = 358
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
        'fraCEDUCATA
        '
        Me.fraCEDUCATA.Controls.Add(Me.txtMPMUNOVC)
        Me.fraCEDUCATA.Controls.Add(Me.Label20)
        Me.fraCEDUCATA.Controls.Add(Me.txtMPMUCAAC)
        Me.fraCEDUCATA.Controls.Add(Me.Label16)
        Me.fraCEDUCATA.Controls.Add(Me.cboMPMUNOVE)
        Me.fraCEDUCATA.Controls.Add(Me.Label15)
        Me.fraCEDUCATA.Controls.Add(Me.cboMPMUESTA)
        Me.fraCEDUCATA.Controls.Add(Me.Label8)
        Me.fraCEDUCATA.Controls.Add(Me.txtMPMUUNPR)
        Me.fraCEDUCATA.Controls.Add(Me.txtMPMUEDIF)
        Me.fraCEDUCATA.Controls.Add(Me.Label1)
        Me.fraCEDUCATA.Controls.Add(Me.Label6)
        Me.fraCEDUCATA.Controls.Add(Me.cboMPMUCLSE)
        Me.fraCEDUCATA.Controls.Add(Me.txtMPMUNUFI)
        Me.fraCEDUCATA.Controls.Add(Me.Label3)
        Me.fraCEDUCATA.Controls.Add(Me.Label4)
        Me.fraCEDUCATA.Controls.Add(Me.txtMPMUCORR)
        Me.fraCEDUCATA.Controls.Add(Me.txtMPMUMUNI)
        Me.fraCEDUCATA.Controls.Add(Me.txtMPMUPRED)
        Me.fraCEDUCATA.Controls.Add(Me.txtMPMUMANZ)
        Me.fraCEDUCATA.Controls.Add(Me.txtMPMUBARR)
        Me.fraCEDUCATA.Controls.Add(Me.lblCodigoActual)
        Me.fraCEDUCATA.Controls.Add(Me.lblPredio)
        Me.fraCEDUCATA.Controls.Add(Me.lblManzana)
        Me.fraCEDUCATA.Controls.Add(Me.lblBarrio)
        Me.fraCEDUCATA.Controls.Add(Me.lblCorregimiento)
        Me.fraCEDUCATA.Controls.Add(Me.lblMunicipio)
        Me.fraCEDUCATA.Controls.Add(Me.lblCodigo)
        Me.fraCEDUCATA.Location = New System.Drawing.Point(16, 69)
        Me.fraCEDUCATA.Name = "fraCEDUCATA"
        Me.fraCEDUCATA.Size = New System.Drawing.Size(776, 180)
        Me.fraCEDUCATA.TabIndex = 356
        Me.fraCEDUCATA.TabStop = False
        Me.fraCEDUCATA.Text = "INSERTAR MUTACIÓN"
        '
        'txtMPMUNOVC
        '
        Me.txtMPMUNOVC.AccessibleDescription = "Nro. Ficha Predial"
        Me.txtMPMUNOVC.BackColor = System.Drawing.SystemColors.Window
        Me.txtMPMUNOVC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMPMUNOVC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMPMUNOVC.ForeColor = System.Drawing.Color.Black
        Me.txtMPMUNOVC.Location = New System.Drawing.Point(583, 48)
        Me.txtMPMUNOVC.MaxLength = 9
        Me.txtMPMUNOVC.Name = "txtMPMUNOVC"
        Me.txtMPMUNOVC.Size = New System.Drawing.Size(173, 20)
        Me.txtMPMUNOVC.TabIndex = 3
        '
        'Label20
        '
        Me.Label20.AccessibleDescription = ""
        Me.Label20.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(408, 48)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(172, 20)
        Me.Label20.TabIndex = 444
        Me.Label20.Text = "Nro. Ficha OVC"
        '
        'txtMPMUCAAC
        '
        Me.txtMPMUCAAC.AccessibleDescription = "Causa del acto"
        Me.txtMPMUCAAC.BackColor = System.Drawing.SystemColors.Window
        Me.txtMPMUCAAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMPMUCAAC.ForeColor = System.Drawing.Color.Black
        Me.txtMPMUCAAC.Location = New System.Drawing.Point(583, 117)
        Me.txtMPMUCAAC.MaxLength = 9
        Me.txtMPMUCAAC.Name = "txtMPMUCAAC"
        Me.txtMPMUCAAC.Size = New System.Drawing.Size(173, 20)
        Me.txtMPMUCAAC.TabIndex = 12
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(408, 117)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(172, 20)
        Me.Label16.TabIndex = 440
        Me.Label16.Text = "Causa del acto"
        '
        'cboMPMUNOVE
        '
        Me.cboMPMUNOVE.AccessibleDescription = "Novedad"
        Me.cboMPMUNOVE.BackColor = System.Drawing.Color.White
        Me.cboMPMUNOVE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMPMUNOVE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMPMUNOVE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMPMUNOVE.Location = New System.Drawing.Point(144, 23)
        Me.cboMPMUNOVE.MaxDropDownItems = 15
        Me.cboMPMUNOVE.MaxLength = 1
        Me.cboMPMUNOVE.Name = "cboMPMUNOVE"
        Me.cboMPMUNOVE.Size = New System.Drawing.Size(261, 22)
        Me.cboMPMUNOVE.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(16, 25)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(125, 20)
        Me.Label15.TabIndex = 437
        Me.Label15.Text = "Novedad"
        '
        'cboMPMUESTA
        '
        Me.cboMPMUESTA.AccessibleDescription = "Estado"
        Me.cboMPMUESTA.BackColor = System.Drawing.Color.White
        Me.cboMPMUESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMPMUESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMPMUESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMPMUESTA.Location = New System.Drawing.Point(144, 139)
        Me.cboMPMUESTA.MaxDropDownItems = 15
        Me.cboMPMUESTA.MaxLength = 1
        Me.cboMPMUESTA.Name = "cboMPMUESTA"
        Me.cboMPMUESTA.Size = New System.Drawing.Size(261, 22)
        Me.cboMPMUESTA.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(16, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 20)
        Me.Label8.TabIndex = 421
        Me.Label8.Text = "Estado"
        '
        'txtMPMUUNPR
        '
        Me.txtMPMUUNPR.AccessibleDescription = "Unidad predial"
        Me.txtMPMUUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtMPMUUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMPMUUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMPMUUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtMPMUUNPR.Location = New System.Drawing.Point(671, 94)
        Me.txtMPMUUNPR.MaxLength = 5
        Me.txtMPMUUNPR.Name = "txtMPMUUNPR"
        Me.txtMPMUUNPR.Size = New System.Drawing.Size(85, 20)
        Me.txtMPMUUNPR.TabIndex = 10
        '
        'txtMPMUEDIF
        '
        Me.txtMPMUEDIF.AccessibleDescription = "Edificio"
        Me.txtMPMUEDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtMPMUEDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMPMUEDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMPMUEDIF.ForeColor = System.Drawing.Color.Black
        Me.txtMPMUEDIF.Location = New System.Drawing.Point(583, 94)
        Me.txtMPMUEDIF.MaxLength = 3
        Me.txtMPMUEDIF.Name = "txtMPMUEDIF"
        Me.txtMPMUEDIF.Size = New System.Drawing.Size(85, 20)
        Me.txtMPMUEDIF.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(671, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 20)
        Me.Label1.TabIndex = 416
        Me.Label1.Text = "Unidad predial"
        '
        'Label6
        '
        Me.Label6.AccessibleDescription = ""
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(583, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 20)
        Me.Label6.TabIndex = 415
        Me.Label6.Text = "Edificio"
        '
        'cboMPMUCLSE
        '
        Me.cboMPMUCLSE.AccessibleDescription = "Clase o sector "
        Me.cboMPMUCLSE.BackColor = System.Drawing.Color.White
        Me.cboMPMUCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMPMUCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMPMUCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMPMUCLSE.Location = New System.Drawing.Point(144, 116)
        Me.cboMPMUCLSE.MaxDropDownItems = 15
        Me.cboMPMUCLSE.MaxLength = 11
        Me.cboMPMUCLSE.Name = "cboMPMUCLSE"
        Me.cboMPMUCLSE.Size = New System.Drawing.Size(261, 22)
        Me.cboMPMUCLSE.TabIndex = 11
        '
        'txtMPMUNUFI
        '
        Me.txtMPMUNUFI.AccessibleDescription = "Nro. Ficha Predial"
        Me.txtMPMUNUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtMPMUNUFI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMPMUNUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMPMUNUFI.ForeColor = System.Drawing.Color.Black
        Me.txtMPMUNUFI.Location = New System.Drawing.Point(143, 48)
        Me.txtMPMUNUFI.MaxLength = 9
        Me.txtMPMUNUFI.Name = "txtMPMUNUFI"
        Me.txtMPMUNUFI.Size = New System.Drawing.Size(262, 20)
        Me.txtMPMUNUFI.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = ""
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 20)
        Me.Label3.TabIndex = 406
        Me.Label3.Text = "Nro. Ficha Municipio"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 20)
        Me.Label4.TabIndex = 405
        Me.Label4.Text = "Clase o Sector"
        '
        'txtMPMUCORR
        '
        Me.txtMPMUCORR.AccessibleDescription = "Corregimiento"
        Me.txtMPMUCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtMPMUCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMPMUCORR.Location = New System.Drawing.Point(232, 94)
        Me.txtMPMUCORR.MaxLength = 2
        Me.txtMPMUCORR.Name = "txtMPMUCORR"
        Me.txtMPMUCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtMPMUCORR.TabIndex = 5
        '
        'txtMPMUMUNI
        '
        Me.txtMPMUMUNI.AccessibleDescription = "Municipio"
        Me.txtMPMUMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtMPMUMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMPMUMUNI.Location = New System.Drawing.Point(144, 94)
        Me.txtMPMUMUNI.MaxLength = 3
        Me.txtMPMUMUNI.Name = "txtMPMUMUNI"
        Me.txtMPMUMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtMPMUMUNI.TabIndex = 4
        '
        'txtMPMUPRED
        '
        Me.txtMPMUPRED.AccessibleDescription = "Predio "
        Me.txtMPMUPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtMPMUPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMPMUPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMPMUPRED.ForeColor = System.Drawing.Color.Black
        Me.txtMPMUPRED.Location = New System.Drawing.Point(496, 94)
        Me.txtMPMUPRED.MaxLength = 5
        Me.txtMPMUPRED.Name = "txtMPMUPRED"
        Me.txtMPMUPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtMPMUPRED.TabIndex = 8
        '
        'txtMPMUMANZ
        '
        Me.txtMPMUMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtMPMUMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtMPMUMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMPMUMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMPMUMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtMPMUMANZ.Location = New System.Drawing.Point(408, 94)
        Me.txtMPMUMANZ.MaxLength = 3
        Me.txtMPMUMANZ.Name = "txtMPMUMANZ"
        Me.txtMPMUMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtMPMUMANZ.TabIndex = 7
        '
        'txtMPMUBARR
        '
        Me.txtMPMUBARR.AccessibleDescription = "Barrio "
        Me.txtMPMUBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtMPMUBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMPMUBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMPMUBARR.ForeColor = System.Drawing.Color.Black
        Me.txtMPMUBARR.Location = New System.Drawing.Point(320, 94)
        Me.txtMPMUBARR.MaxLength = 3
        Me.txtMPMUBARR.Name = "txtMPMUBARR"
        Me.txtMPMUBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtMPMUBARR.TabIndex = 6
        '
        'lblCodigoActual
        '
        Me.lblCodigoActual.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigoActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigoActual.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoActual.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoActual.Location = New System.Drawing.Point(16, 94)
        Me.lblCodigoActual.Name = "lblCodigoActual"
        Me.lblCodigoActual.Size = New System.Drawing.Size(125, 20)
        Me.lblCodigoActual.TabIndex = 395
        Me.lblCodigoActual.Text = "Código actual"
        '
        'lblPredio
        '
        Me.lblPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredio.ForeColor = System.Drawing.Color.Black
        Me.lblPredio.Location = New System.Drawing.Point(496, 71)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(84, 20)
        Me.lblPredio.TabIndex = 394
        Me.lblPredio.Text = "Predio"
        '
        'lblManzana
        '
        Me.lblManzana.AccessibleDescription = ""
        Me.lblManzana.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblManzana.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblManzana.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManzana.ForeColor = System.Drawing.Color.Black
        Me.lblManzana.Location = New System.Drawing.Point(408, 71)
        Me.lblManzana.Name = "lblManzana"
        Me.lblManzana.Size = New System.Drawing.Size(84, 20)
        Me.lblManzana.TabIndex = 393
        Me.lblManzana.Text = "Manza / Vered"
        '
        'lblBarrio
        '
        Me.lblBarrio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblBarrio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBarrio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarrio.ForeColor = System.Drawing.Color.Black
        Me.lblBarrio.Location = New System.Drawing.Point(320, 71)
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Size = New System.Drawing.Size(84, 20)
        Me.lblBarrio.TabIndex = 392
        Me.lblBarrio.Text = "Barrio"
        '
        'lblCorregimiento
        '
        Me.lblCorregimiento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCorregimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorregimiento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorregimiento.ForeColor = System.Drawing.Color.Black
        Me.lblCorregimiento.Location = New System.Drawing.Point(232, 71)
        Me.lblCorregimiento.Name = "lblCorregimiento"
        Me.lblCorregimiento.Size = New System.Drawing.Size(84, 20)
        Me.lblCorregimiento.TabIndex = 396
        Me.lblCorregimiento.Text = "Corregimiento"
        '
        'lblMunicipio
        '
        Me.lblMunicipio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblMunicipio.Location = New System.Drawing.Point(144, 71)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(84, 20)
        Me.lblMunicipio.TabIndex = 398
        Me.lblMunicipio.Text = "Municipio"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(16, 71)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(125, 20)
        Me.lblCodigo.TabIndex = 399
        Me.lblCodigo.Text = "Cedula catastral"
        '
        'lblMPMUVIGE
        '
        Me.lblMPMUVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblMPMUVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMPMUVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMPMUVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblMPMUVIGE.Location = New System.Drawing.Point(144, 18)
        Me.lblMPMUVIGE.Name = "lblMPMUVIGE"
        Me.lblMPMUVIGE.Size = New System.Drawing.Size(85, 20)
        Me.lblMPMUVIGE.TabIndex = 438
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.lblMPMURESO)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.lblMPMUTIRE)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.lblMPMUVIGE)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 51)
        Me.GroupBox1.TabIndex = 359
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "RESOLUCIÓN"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(496, 18)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(125, 20)
        Me.Label19.TabIndex = 442
        Me.Label19.Text = "Resolución"
        '
        'lblMPMURESO
        '
        Me.lblMPMURESO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblMPMURESO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMPMURESO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMPMURESO.ForeColor = System.Drawing.Color.Black
        Me.lblMPMURESO.Location = New System.Drawing.Point(624, 18)
        Me.lblMPMURESO.Name = "lblMPMURESO"
        Me.lblMPMURESO.Size = New System.Drawing.Size(132, 20)
        Me.lblMPMURESO.TabIndex = 441
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(232, 18)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(125, 20)
        Me.Label17.TabIndex = 440
        Me.Label17.Text = "Tipo de Resolución"
        '
        'lblMPMUTIRE
        '
        Me.lblMPMUTIRE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblMPMUTIRE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMPMUTIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMPMUTIRE.ForeColor = System.Drawing.Color.Black
        Me.lblMPMUTIRE.Location = New System.Drawing.Point(360, 18)
        Me.lblMPMUTIRE.Name = "lblMPMUTIRE"
        Me.lblMPMUTIRE.Size = New System.Drawing.Size(133, 20)
        Me.lblMPMUTIRE.TabIndex = 439
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(16, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(125, 20)
        Me.Label12.TabIndex = 438
        Me.Label12.Text = "Vigencia"
        '
        'frm_insertar_MUPRMUTA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 340)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCEDUCATA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(829, 376)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(829, 376)
        Me.Name = "frm_insertar_MUPRMUTA"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox2.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraCEDUCATA.ResumeLayout(False)
        Me.fraCEDUCATA.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraCEDUCATA As System.Windows.Forms.GroupBox
    Friend WithEvents txtMPMUCAAC As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboMPMUNOVE As System.Windows.Forms.ComboBox
    Friend WithEvents lblMPMUVIGE As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboMPMUESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtOUAPUNPR As System.Windows.Forms.TextBox
    Friend WithEvents txtMPMUEDIF As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboMPMUCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents txtMPMUNUFI As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtOUAPCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtOUAPMUNI As System.Windows.Forms.TextBox
    Friend WithEvents txtOUAPPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtMPMUMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtOUAPBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblMPMURESO As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblMPMUTIRE As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtMPMUUNPR As System.Windows.Forms.TextBox
    Friend WithEvents txtMPMUCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtMPMUMUNI As System.Windows.Forms.TextBox
    Friend WithEvents txtMPMUPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtMPMUBARR As System.Windows.Forms.TextBox
    Friend WithEvents txtMPMUNOVC As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
End Class
