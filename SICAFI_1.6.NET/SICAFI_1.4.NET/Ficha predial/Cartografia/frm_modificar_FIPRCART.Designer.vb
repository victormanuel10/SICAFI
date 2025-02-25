<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_FIPRCART
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboFPCAESTA = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboFPCAVIAE = New System.Windows.Forms.ComboBox()
        Me.cboFPCAVIGR = New System.Windows.Forms.ComboBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.lblEscalaAerofotografica = New System.Windows.Forms.Label()
        Me.txtFPCAESAE = New System.Windows.Forms.TextBox()
        Me.lblAmpliacion = New System.Windows.Forms.Label()
        Me.txtFPCAAMPL = New System.Windows.Forms.TextBox()
        Me.lblVigenciaAerofotografica = New System.Windows.Forms.Label()
        Me.lblFoto = New System.Windows.Forms.Label()
        Me.txtFPCAFOTO = New System.Windows.Forms.TextBox()
        Me.lblFaja = New System.Windows.Forms.Label()
        Me.txtFPCAFAJA = New System.Windows.Forms.TextBox()
        Me.lblVuelo = New System.Windows.Forms.Label()
        Me.txtFPCAVUEL = New System.Windows.Forms.TextBox()
        Me.lblVigenciaGrafica = New System.Windows.Forms.Label()
        Me.lblEscalaGrafica = New System.Windows.Forms.Label()
        Me.txtFPCAESGR = New System.Windows.Forms.TextBox()
        Me.lblVentana = New System.Windows.Forms.Label()
        Me.txtFPCAVENT = New System.Windows.Forms.TextBox()
        Me.lblPlancha = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFPCAPLAN = New System.Windows.Forms.TextBox()
        Me.GroupBox2.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox2.Controls.Add(Me.cmdSALIR)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 228)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(708, 50)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(253, 16)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 12
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(360, 16)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 13
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 304)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(737, 25)
        Me.strBARRESTA.TabIndex = 327
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
        Me.GroupBox1.Controls.Add(Me.cboFPCAESTA)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboFPCAVIAE)
        Me.GroupBox1.Controls.Add(Me.cboFPCAVIGR)
        Me.GroupBox1.Controls.Add(Me.Label55)
        Me.GroupBox1.Controls.Add(Me.lblEscalaAerofotografica)
        Me.GroupBox1.Controls.Add(Me.txtFPCAESAE)
        Me.GroupBox1.Controls.Add(Me.lblAmpliacion)
        Me.GroupBox1.Controls.Add(Me.txtFPCAAMPL)
        Me.GroupBox1.Controls.Add(Me.lblVigenciaAerofotografica)
        Me.GroupBox1.Controls.Add(Me.lblFoto)
        Me.GroupBox1.Controls.Add(Me.txtFPCAFOTO)
        Me.GroupBox1.Controls.Add(Me.lblFaja)
        Me.GroupBox1.Controls.Add(Me.txtFPCAFAJA)
        Me.GroupBox1.Controls.Add(Me.lblVuelo)
        Me.GroupBox1.Controls.Add(Me.txtFPCAVUEL)
        Me.GroupBox1.Controls.Add(Me.lblVigenciaGrafica)
        Me.GroupBox1.Controls.Add(Me.lblEscalaGrafica)
        Me.GroupBox1.Controls.Add(Me.txtFPCAESGR)
        Me.GroupBox1.Controls.Add(Me.lblVentana)
        Me.GroupBox1.Controls.Add(Me.txtFPCAVENT)
        Me.GroupBox1.Controls.Add(Me.lblPlancha)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtFPCAPLAN)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(708, 210)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MODIFICAR CARTOGRAFIA"
        '
        'cboFPCAESTA
        '
        Me.cboFPCAESTA.AccessibleDescription = "Estado"
        Me.cboFPCAESTA.BackColor = System.Drawing.Color.White
        Me.cboFPCAESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFPCAESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPCAESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFPCAESTA.Items.AddRange(New Object() {"2004", "2005", "2006", "2007"})
        Me.cboFPCAESTA.Location = New System.Drawing.Point(133, 172)
        Me.cboFPCAESTA.MaxDropDownItems = 10
        Me.cboFPCAESTA.MaxLength = 4
        Me.cboFPCAESTA.Name = "cboFPCAESTA"
        Me.cboFPCAESTA.Size = New System.Drawing.Size(109, 22)
        Me.cboFPCAESTA.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(20, 172)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 20)
        Me.Label2.TabIndex = 375
        Me.Label2.Text = "Estado"
        '
        'cboFPCAVIAE
        '
        Me.cboFPCAVIAE.AccessibleDescription = "Vigencia "
        Me.cboFPCAVIAE.BackColor = System.Drawing.Color.White
        Me.cboFPCAVIAE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFPCAVIAE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPCAVIAE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFPCAVIAE.Items.AddRange(New Object() {"2004", "2005", "2006", "2007"})
        Me.cboFPCAVIAE.Location = New System.Drawing.Point(355, 148)
        Me.cboFPCAVIAE.MaxDropDownItems = 10
        Me.cboFPCAVIAE.MaxLength = 4
        Me.cboFPCAVIAE.Name = "cboFPCAVIAE"
        Me.cboFPCAVIAE.Size = New System.Drawing.Size(110, 22)
        Me.cboFPCAVIAE.TabIndex = 8
        '
        'cboFPCAVIGR
        '
        Me.cboFPCAVIGR.AccessibleDescription = "Vigencia "
        Me.cboFPCAVIGR.BackColor = System.Drawing.Color.White
        Me.cboFPCAVIGR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFPCAVIGR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPCAVIGR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFPCAVIGR.Items.AddRange(New Object() {"2004", "2005", "2006", "2007"})
        Me.cboFPCAVIGR.Location = New System.Drawing.Point(355, 74)
        Me.cboFPCAVIGR.MaxDropDownItems = 10
        Me.cboFPCAVIGR.MaxLength = 4
        Me.cboFPCAVIGR.Name = "cboFPCAVIGR"
        Me.cboFPCAVIGR.Size = New System.Drawing.Size(112, 22)
        Me.cboFPCAVIGR.TabIndex = 4
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label55.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label55.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.Black
        Me.Label55.Location = New System.Drawing.Point(20, 99)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(669, 20)
        Me.Label55.TabIndex = 370
        Me.Label55.Text = "Información Aerofotográfia"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEscalaAerofotografica
        '
        Me.lblEscalaAerofotografica.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblEscalaAerofotografica.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEscalaAerofotografica.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEscalaAerofotografica.ForeColor = System.Drawing.Color.Black
        Me.lblEscalaAerofotografica.Location = New System.Drawing.Point(580, 123)
        Me.lblEscalaAerofotografica.Name = "lblEscalaAerofotografica"
        Me.lblEscalaAerofotografica.Size = New System.Drawing.Size(109, 20)
        Me.lblEscalaAerofotografica.TabIndex = 369
        Me.lblEscalaAerofotografica.Text = "Escala"
        '
        'txtFPCAESAE
        '
        Me.txtFPCAESAE.AccessibleDescription = "Escala"
        Me.txtFPCAESAE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFPCAESAE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPCAESAE.ForeColor = System.Drawing.Color.Black
        Me.txtFPCAESAE.Location = New System.Drawing.Point(580, 148)
        Me.txtFPCAESAE.MaxLength = 14
        Me.txtFPCAESAE.Name = "txtFPCAESAE"
        Me.txtFPCAESAE.Size = New System.Drawing.Size(109, 20)
        Me.txtFPCAESAE.TabIndex = 10
        '
        'lblAmpliacion
        '
        Me.lblAmpliacion.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblAmpliacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAmpliacion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmpliacion.ForeColor = System.Drawing.Color.Black
        Me.lblAmpliacion.Location = New System.Drawing.Point(468, 123)
        Me.lblAmpliacion.Name = "lblAmpliacion"
        Me.lblAmpliacion.Size = New System.Drawing.Size(109, 20)
        Me.lblAmpliacion.TabIndex = 367
        Me.lblAmpliacion.Text = "Ampliación"
        '
        'txtFPCAAMPL
        '
        Me.txtFPCAAMPL.AccessibleDescription = "Ampliación"
        Me.txtFPCAAMPL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFPCAAMPL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPCAAMPL.ForeColor = System.Drawing.Color.Black
        Me.txtFPCAAMPL.Location = New System.Drawing.Point(468, 148)
        Me.txtFPCAAMPL.MaxLength = 14
        Me.txtFPCAAMPL.Name = "txtFPCAAMPL"
        Me.txtFPCAAMPL.Size = New System.Drawing.Size(109, 20)
        Me.txtFPCAAMPL.TabIndex = 9
        '
        'lblVigenciaAerofotografica
        '
        Me.lblVigenciaAerofotografica.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblVigenciaAerofotografica.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVigenciaAerofotografica.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVigenciaAerofotografica.ForeColor = System.Drawing.Color.Black
        Me.lblVigenciaAerofotografica.Location = New System.Drawing.Point(355, 123)
        Me.lblVigenciaAerofotografica.Name = "lblVigenciaAerofotografica"
        Me.lblVigenciaAerofotografica.Size = New System.Drawing.Size(110, 20)
        Me.lblVigenciaAerofotografica.TabIndex = 365
        Me.lblVigenciaAerofotografica.Text = "Vigencia"
        '
        'lblFoto
        '
        Me.lblFoto.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblFoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFoto.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFoto.ForeColor = System.Drawing.Color.Black
        Me.lblFoto.Location = New System.Drawing.Point(244, 123)
        Me.lblFoto.Name = "lblFoto"
        Me.lblFoto.Size = New System.Drawing.Size(109, 20)
        Me.lblFoto.TabIndex = 364
        Me.lblFoto.Text = "Foto"
        '
        'txtFPCAFOTO
        '
        Me.txtFPCAFOTO.AccessibleDescription = "Foto"
        Me.txtFPCAFOTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFPCAFOTO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPCAFOTO.ForeColor = System.Drawing.Color.Black
        Me.txtFPCAFOTO.Location = New System.Drawing.Point(244, 148)
        Me.txtFPCAFOTO.MaxLength = 14
        Me.txtFPCAFOTO.Name = "txtFPCAFOTO"
        Me.txtFPCAFOTO.Size = New System.Drawing.Size(110, 20)
        Me.txtFPCAFOTO.TabIndex = 7
        '
        'lblFaja
        '
        Me.lblFaja.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblFaja.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFaja.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFaja.ForeColor = System.Drawing.Color.Black
        Me.lblFaja.Location = New System.Drawing.Point(132, 123)
        Me.lblFaja.Name = "lblFaja"
        Me.lblFaja.Size = New System.Drawing.Size(109, 20)
        Me.lblFaja.TabIndex = 362
        Me.lblFaja.Text = "Faja"
        '
        'txtFPCAFAJA
        '
        Me.txtFPCAFAJA.AccessibleDescription = "Faja"
        Me.txtFPCAFAJA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFPCAFAJA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPCAFAJA.ForeColor = System.Drawing.Color.Black
        Me.txtFPCAFAJA.Location = New System.Drawing.Point(132, 148)
        Me.txtFPCAFAJA.MaxLength = 14
        Me.txtFPCAFAJA.Name = "txtFPCAFAJA"
        Me.txtFPCAFAJA.Size = New System.Drawing.Size(110, 20)
        Me.txtFPCAFAJA.TabIndex = 6
        '
        'lblVuelo
        '
        Me.lblVuelo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblVuelo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVuelo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVuelo.ForeColor = System.Drawing.Color.Black
        Me.lblVuelo.Location = New System.Drawing.Point(20, 123)
        Me.lblVuelo.Name = "lblVuelo"
        Me.lblVuelo.Size = New System.Drawing.Size(109, 20)
        Me.lblVuelo.TabIndex = 360
        Me.lblVuelo.Text = "Vuelo"
        '
        'txtFPCAVUEL
        '
        Me.txtFPCAVUEL.AccessibleDescription = "Vuelo"
        Me.txtFPCAVUEL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFPCAVUEL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPCAVUEL.ForeColor = System.Drawing.Color.Black
        Me.txtFPCAVUEL.Location = New System.Drawing.Point(20, 148)
        Me.txtFPCAVUEL.MaxLength = 14
        Me.txtFPCAVUEL.Name = "txtFPCAVUEL"
        Me.txtFPCAVUEL.Size = New System.Drawing.Size(110, 20)
        Me.txtFPCAVUEL.TabIndex = 5
        '
        'lblVigenciaGrafica
        '
        Me.lblVigenciaGrafica.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblVigenciaGrafica.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVigenciaGrafica.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVigenciaGrafica.ForeColor = System.Drawing.Color.Black
        Me.lblVigenciaGrafica.Location = New System.Drawing.Point(355, 51)
        Me.lblVigenciaGrafica.Name = "lblVigenciaGrafica"
        Me.lblVigenciaGrafica.Size = New System.Drawing.Size(112, 20)
        Me.lblVigenciaGrafica.TabIndex = 358
        Me.lblVigenciaGrafica.Text = "Vigencia"
        '
        'lblEscalaGrafica
        '
        Me.lblEscalaGrafica.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblEscalaGrafica.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEscalaGrafica.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEscalaGrafica.ForeColor = System.Drawing.Color.Black
        Me.lblEscalaGrafica.Location = New System.Drawing.Point(244, 51)
        Me.lblEscalaGrafica.Name = "lblEscalaGrafica"
        Me.lblEscalaGrafica.Size = New System.Drawing.Size(108, 20)
        Me.lblEscalaGrafica.TabIndex = 357
        Me.lblEscalaGrafica.Text = "Escala"
        '
        'txtFPCAESGR
        '
        Me.txtFPCAESGR.AccessibleDescription = "Escala"
        Me.txtFPCAESGR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFPCAESGR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPCAESGR.ForeColor = System.Drawing.Color.Black
        Me.txtFPCAESGR.Location = New System.Drawing.Point(244, 74)
        Me.txtFPCAESGR.MaxLength = 14
        Me.txtFPCAESGR.Name = "txtFPCAESGR"
        Me.txtFPCAESGR.Size = New System.Drawing.Size(108, 20)
        Me.txtFPCAESGR.TabIndex = 3
        '
        'lblVentana
        '
        Me.lblVentana.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblVentana.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVentana.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVentana.ForeColor = System.Drawing.Color.Black
        Me.lblVentana.Location = New System.Drawing.Point(132, 51)
        Me.lblVentana.Name = "lblVentana"
        Me.lblVentana.Size = New System.Drawing.Size(109, 20)
        Me.lblVentana.TabIndex = 355
        Me.lblVentana.Text = "Ventana"
        '
        'txtFPCAVENT
        '
        Me.txtFPCAVENT.AccessibleDescription = "Ventana"
        Me.txtFPCAVENT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFPCAVENT.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPCAVENT.ForeColor = System.Drawing.Color.Black
        Me.txtFPCAVENT.Location = New System.Drawing.Point(132, 74)
        Me.txtFPCAVENT.MaxLength = 14
        Me.txtFPCAVENT.Name = "txtFPCAVENT"
        Me.txtFPCAVENT.Size = New System.Drawing.Size(110, 20)
        Me.txtFPCAVENT.TabIndex = 2
        '
        'lblPlancha
        '
        Me.lblPlancha.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPlancha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPlancha.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlancha.ForeColor = System.Drawing.Color.Black
        Me.lblPlancha.Location = New System.Drawing.Point(20, 51)
        Me.lblPlancha.Name = "lblPlancha"
        Me.lblPlancha.Size = New System.Drawing.Size(109, 20)
        Me.lblPlancha.TabIndex = 353
        Me.lblPlancha.Text = "Plancha"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(20, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(447, 20)
        Me.Label8.TabIndex = 352
        Me.Label8.Text = "Información Gráfica "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFPCAPLAN
        '
        Me.txtFPCAPLAN.AccessibleDescription = "Plancha"
        Me.txtFPCAPLAN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPCAPLAN.ForeColor = System.Drawing.Color.Black
        Me.txtFPCAPLAN.Location = New System.Drawing.Point(19, 74)
        Me.txtFPCAPLAN.MaxLength = 14
        Me.txtFPCAPLAN.Name = "txtFPCAPLAN"
        Me.txtFPCAPLAN.Size = New System.Drawing.Size(110, 20)
        Me.txtFPCAPLAN.TabIndex = 1
        '
        'frm_modificar_FIPRCART
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdSALIR
        Me.ClientSize = New System.Drawing.Size(737, 329)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(753, 365)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(753, 365)
        Me.Name = "frm_modificar_FIPRCART"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.GroupBox2.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboFPCAVIAE As System.Windows.Forms.ComboBox
    Friend WithEvents cboFPCAVIGR As System.Windows.Forms.ComboBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents lblEscalaAerofotografica As System.Windows.Forms.Label
    Friend WithEvents txtFPCAESAE As System.Windows.Forms.TextBox
    Friend WithEvents lblAmpliacion As System.Windows.Forms.Label
    Friend WithEvents txtFPCAAMPL As System.Windows.Forms.TextBox
    Friend WithEvents lblVigenciaAerofotografica As System.Windows.Forms.Label
    Friend WithEvents lblFoto As System.Windows.Forms.Label
    Friend WithEvents txtFPCAFOTO As System.Windows.Forms.TextBox
    Friend WithEvents lblFaja As System.Windows.Forms.Label
    Friend WithEvents txtFPCAFAJA As System.Windows.Forms.TextBox
    Friend WithEvents lblVuelo As System.Windows.Forms.Label
    Friend WithEvents txtFPCAVUEL As System.Windows.Forms.TextBox
    Friend WithEvents lblVigenciaGrafica As System.Windows.Forms.Label
    Friend WithEvents lblEscalaGrafica As System.Windows.Forms.Label
    Friend WithEvents txtFPCAESGR As System.Windows.Forms.TextBox
    Friend WithEvents lblVentana As System.Windows.Forms.Label
    Friend WithEvents txtFPCAVENT As System.Windows.Forms.TextBox
    Friend WithEvents lblPlancha As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFPCAPLAN As System.Windows.Forms.TextBox
    Friend WithEvents cboFPCAESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
