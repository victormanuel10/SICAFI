<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_FIPRPROP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_modificar_FIPRPROP))
        Me.fraCOMANDOS = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraPROPIETARIO = New System.Windows.Forms.GroupBox()
        Me.cboFPPRMOAD = New System.Windows.Forms.ComboBox()
        Me.lblFPPRMOAD = New System.Windows.Forms.Label()
        Me.lblAdquisicionDelPredioPropietario = New System.Windows.Forms.Label()
        Me.txtFPPRNOMB = New System.Windows.Forms.TextBox()
        Me.txtFPPRSEAP = New System.Windows.Forms.TextBox()
        Me.txtFPPRPRAP = New System.Windows.Forms.TextBox()
        Me.txtFPPRNUDO = New System.Windows.Forms.TextBox()
        Me.cboFPPRESTA = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.lblFPPRSEXO = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cboFPPRSEXO = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lblFPPRTIDO = New System.Windows.Forms.Label()
        Me.txtFPPRFEES = New System.Windows.Forms.MaskedTextBox()
        Me.cboFPPRNOTA = New System.Windows.Forms.ComboBox()
        Me.cboFPPRMUNI = New System.Windows.Forms.ComboBox()
        Me.cboFPPRDEPA = New System.Windows.Forms.ComboBox()
        Me.txtFPPRMAIN = New System.Windows.Forms.MaskedTextBox()
        Me.txtFPPRFERE = New System.Windows.Forms.MaskedTextBox()
        Me.txtFPPRESCR = New System.Windows.Forms.MaskedTextBox()
        Me.cboFPPRTIDO = New System.Windows.Forms.ComboBox()
        Me.cboFPPRCAPR = New System.Windows.Forms.ComboBox()
        Me.lblTipoDeDocumento = New System.Windows.Forms.Label()
        Me.lblDocumento = New System.Windows.Forms.Label()
        Me.txtFPPRDERE = New System.Windows.Forms.TextBox()
        Me.lblDerecho = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblSegundoApellido = New System.Windows.Forms.Label()
        Me.lblPrimerApellido = New System.Windows.Forms.Label()
        Me.lblCapr1 = New System.Windows.Forms.Label()
        Me.lblMatricula = New System.Windows.Forms.Label()
        Me.txtFPPRTOMO = New System.Windows.Forms.TextBox()
        Me.lblTomo = New System.Windows.Forms.Label()
        Me.lblFPPRNOTA = New System.Windows.Forms.Label()
        Me.lblNotaria1 = New System.Windows.Forms.Label()
        Me.lblFechaRegistro = New System.Windows.Forms.Label()
        Me.lblFechaEscritura = New System.Windows.Forms.Label()
        Me.lblEscritura = New System.Windows.Forms.Label()
        Me.chkFPPRGRAV = New System.Windows.Forms.CheckBox()
        Me.txtFPPRSICO = New System.Windows.Forms.TextBox()
        Me.lblSiglaComercial = New System.Windows.Forms.Label()
        Me.lblFPPRCAPR = New System.Windows.Forms.Label()
        Me.lblCaPr2 = New System.Windows.Forms.Label()
        Me.fraCOMANDOS.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraPROPIETARIO.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraCOMANDOS
        '
        Me.fraCOMANDOS.Controls.Add(Me.cmdSALIR)
        Me.fraCOMANDOS.Controls.Add(Me.cmdGUARDAR)
        Me.fraCOMANDOS.Location = New System.Drawing.Point(12, 207)
        Me.fraCOMANDOS.Name = "fraCOMANDOS"
        Me.fraCOMANDOS.Size = New System.Drawing.Size(842, 46)
        Me.fraCOMANDOS.TabIndex = 53
        Me.fraCOMANDOS.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(440, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 20
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = CType(resources.GetObject("cmdGUARDAR.Image"), System.Drawing.Image)
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(336, 15)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 19
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 281)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(872, 25)
        Me.strBARRESTA.TabIndex = 52
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
        'fraPROPIETARIO
        '
        Me.fraPROPIETARIO.Controls.Add(Me.cboFPPRMOAD)
        Me.fraPROPIETARIO.Controls.Add(Me.lblFPPRMOAD)
        Me.fraPROPIETARIO.Controls.Add(Me.lblAdquisicionDelPredioPropietario)
        Me.fraPROPIETARIO.Controls.Add(Me.txtFPPRNOMB)
        Me.fraPROPIETARIO.Controls.Add(Me.txtFPPRSEAP)
        Me.fraPROPIETARIO.Controls.Add(Me.txtFPPRPRAP)
        Me.fraPROPIETARIO.Controls.Add(Me.txtFPPRNUDO)
        Me.fraPROPIETARIO.Controls.Add(Me.cboFPPRESTA)
        Me.fraPROPIETARIO.Controls.Add(Me.Label32)
        Me.fraPROPIETARIO.Controls.Add(Me.lblFPPRSEXO)
        Me.fraPROPIETARIO.Controls.Add(Me.Label30)
        Me.fraPROPIETARIO.Controls.Add(Me.cboFPPRSEXO)
        Me.fraPROPIETARIO.Controls.Add(Me.Label29)
        Me.fraPROPIETARIO.Controls.Add(Me.Label28)
        Me.fraPROPIETARIO.Controls.Add(Me.lblFPPRTIDO)
        Me.fraPROPIETARIO.Controls.Add(Me.txtFPPRFEES)
        Me.fraPROPIETARIO.Controls.Add(Me.cboFPPRNOTA)
        Me.fraPROPIETARIO.Controls.Add(Me.cboFPPRMUNI)
        Me.fraPROPIETARIO.Controls.Add(Me.cboFPPRDEPA)
        Me.fraPROPIETARIO.Controls.Add(Me.txtFPPRMAIN)
        Me.fraPROPIETARIO.Controls.Add(Me.txtFPPRFERE)
        Me.fraPROPIETARIO.Controls.Add(Me.txtFPPRESCR)
        Me.fraPROPIETARIO.Controls.Add(Me.cboFPPRTIDO)
        Me.fraPROPIETARIO.Controls.Add(Me.cboFPPRCAPR)
        Me.fraPROPIETARIO.Controls.Add(Me.lblTipoDeDocumento)
        Me.fraPROPIETARIO.Controls.Add(Me.lblDocumento)
        Me.fraPROPIETARIO.Controls.Add(Me.txtFPPRDERE)
        Me.fraPROPIETARIO.Controls.Add(Me.lblDerecho)
        Me.fraPROPIETARIO.Controls.Add(Me.lblNombre)
        Me.fraPROPIETARIO.Controls.Add(Me.lblSegundoApellido)
        Me.fraPROPIETARIO.Controls.Add(Me.lblPrimerApellido)
        Me.fraPROPIETARIO.Controls.Add(Me.lblCapr1)
        Me.fraPROPIETARIO.Controls.Add(Me.lblMatricula)
        Me.fraPROPIETARIO.Controls.Add(Me.txtFPPRTOMO)
        Me.fraPROPIETARIO.Controls.Add(Me.lblTomo)
        Me.fraPROPIETARIO.Controls.Add(Me.lblFPPRNOTA)
        Me.fraPROPIETARIO.Controls.Add(Me.lblNotaria1)
        Me.fraPROPIETARIO.Controls.Add(Me.lblFechaRegistro)
        Me.fraPROPIETARIO.Controls.Add(Me.lblFechaEscritura)
        Me.fraPROPIETARIO.Controls.Add(Me.lblEscritura)
        Me.fraPROPIETARIO.Controls.Add(Me.chkFPPRGRAV)
        Me.fraPROPIETARIO.Controls.Add(Me.txtFPPRSICO)
        Me.fraPROPIETARIO.Controls.Add(Me.lblSiglaComercial)
        Me.fraPROPIETARIO.Controls.Add(Me.lblFPPRCAPR)
        Me.fraPROPIETARIO.Controls.Add(Me.lblCaPr2)
        Me.fraPROPIETARIO.ForeColor = System.Drawing.Color.Black
        Me.fraPROPIETARIO.Location = New System.Drawing.Point(12, 18)
        Me.fraPROPIETARIO.Name = "fraPROPIETARIO"
        Me.fraPROPIETARIO.Size = New System.Drawing.Size(842, 183)
        Me.fraPROPIETARIO.TabIndex = 51
        Me.fraPROPIETARIO.TabStop = False
        Me.fraPROPIETARIO.Text = "MODIFICAR PROPIETARIO"
        '
        'cboFPPRMOAD
        '
        Me.cboFPPRMOAD.AccessibleDescription = "Modo de adquisición"
        Me.cboFPPRMOAD.BackColor = System.Drawing.Color.White
        Me.cboFPPRMOAD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFPPRMOAD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPPRMOAD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFPPRMOAD.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboFPPRMOAD.Location = New System.Drawing.Point(266, 144)
        Me.cboFPPRMOAD.MaxDropDownItems = 15
        Me.cboFPPRMOAD.MaxLength = 1
        Me.cboFPPRMOAD.Name = "cboFPPRMOAD"
        Me.cboFPPRMOAD.Size = New System.Drawing.Size(88, 22)
        Me.cboFPPRMOAD.TabIndex = 405
        Me.cboFPPRMOAD.Visible = False
        '
        'lblFPPRMOAD
        '
        Me.lblFPPRMOAD.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFPPRMOAD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPPRMOAD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPPRMOAD.ForeColor = System.Drawing.Color.Black
        Me.lblFPPRMOAD.Location = New System.Drawing.Point(358, 145)
        Me.lblFPPRMOAD.Name = "lblFPPRMOAD"
        Me.lblFPPRMOAD.Size = New System.Drawing.Size(242, 20)
        Me.lblFPPRMOAD.TabIndex = 407
        Me.lblFPPRMOAD.Visible = False
        '
        'lblAdquisicionDelPredioPropietario
        '
        Me.lblAdquisicionDelPredioPropietario.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblAdquisicionDelPredioPropietario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAdquisicionDelPredioPropietario.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdquisicionDelPredioPropietario.ForeColor = System.Drawing.Color.Black
        Me.lblAdquisicionDelPredioPropietario.Location = New System.Drawing.Point(189, 145)
        Me.lblAdquisicionDelPredioPropietario.Name = "lblAdquisicionDelPredioPropietario"
        Me.lblAdquisicionDelPredioPropietario.Size = New System.Drawing.Size(74, 20)
        Me.lblAdquisicionDelPredioPropietario.TabIndex = 406
        Me.lblAdquisicionDelPredioPropietario.Text = "Adquisición"
        Me.lblAdquisicionDelPredioPropietario.Visible = False
        '
        'txtFPPRNOMB
        '
        Me.txtFPPRNOMB.AccessibleDescription = "Nombre (s)"
        Me.txtFPPRNOMB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFPPRNOMB.Location = New System.Drawing.Point(524, 49)
        Me.txtFPPRNOMB.MaxLength = 20
        Me.txtFPPRNOMB.Name = "txtFPPRNOMB"
        Me.txtFPPRNOMB.Size = New System.Drawing.Size(219, 20)
        Me.txtFPPRNOMB.TabIndex = 7
        '
        'txtFPPRSEAP
        '
        Me.txtFPPRSEAP.AccessibleDescription = "Segundo apellido"
        Me.txtFPPRSEAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFPPRSEAP.Location = New System.Drawing.Point(395, 49)
        Me.txtFPPRSEAP.MaxLength = 15
        Me.txtFPPRSEAP.Name = "txtFPPRSEAP"
        Me.txtFPPRSEAP.Size = New System.Drawing.Size(126, 20)
        Me.txtFPPRSEAP.TabIndex = 6
        '
        'txtFPPRPRAP
        '
        Me.txtFPPRPRAP.AccessibleDescription = "Primer apellido"
        Me.txtFPPRPRAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFPPRPRAP.Location = New System.Drawing.Point(266, 49)
        Me.txtFPPRPRAP.MaxLength = 15
        Me.txtFPPRPRAP.Name = "txtFPPRPRAP"
        Me.txtFPPRPRAP.Size = New System.Drawing.Size(126, 20)
        Me.txtFPPRPRAP.TabIndex = 5
        '
        'txtFPPRNUDO
        '
        Me.txtFPPRNUDO.AccessibleDescription = "Documento"
        Me.txtFPPRNUDO.Location = New System.Drawing.Point(151, 49)
        Me.txtFPPRNUDO.MaxLength = 14
        Me.txtFPPRNUDO.Name = "txtFPPRNUDO"
        Me.txtFPPRNUDO.Size = New System.Drawing.Size(112, 20)
        Me.txtFPPRNUDO.TabIndex = 4
        '
        'cboFPPRESTA
        '
        Me.cboFPPRESTA.AccessibleDescription = "Estado"
        Me.cboFPPRESTA.BackColor = System.Drawing.Color.White
        Me.cboFPPRESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPPRESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFPPRESTA.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11"})
        Me.cboFPPRESTA.Location = New System.Drawing.Point(106, 145)
        Me.cboFPPRESTA.MaxLength = 2
        Me.cboFPPRESTA.Name = "cboFPPRESTA"
        Me.cboFPPRESTA.Size = New System.Drawing.Size(81, 22)
        Me.cboFPPRESTA.TabIndex = 18
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label32.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(17, 145)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(85, 20)
        Me.Label32.TabIndex = 391
        Me.Label32.Text = "Estado"
        '
        'lblFPPRSEXO
        '
        Me.lblFPPRSEXO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFPPRSEXO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPPRSEXO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPPRSEXO.ForeColor = System.Drawing.Color.Black
        Me.lblFPPRSEXO.Location = New System.Drawing.Point(358, 74)
        Me.lblFPPRSEXO.Name = "lblFPPRSEXO"
        Me.lblFPPRSEXO.Size = New System.Drawing.Size(125, 20)
        Me.lblFPPRSEXO.TabIndex = 390
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label30.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(266, 74)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(89, 20)
        Me.Label30.TabIndex = 389
        Me.Label30.Text = "Genero"
        '
        'cboFPPRSEXO
        '
        Me.cboFPPRSEXO.AccessibleDescription = "Sexo"
        Me.cboFPPRSEXO.BackColor = System.Drawing.Color.White
        Me.cboFPPRSEXO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFPPRSEXO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPPRSEXO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFPPRSEXO.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11"})
        Me.cboFPPRSEXO.Location = New System.Drawing.Point(61, 49)
        Me.cboFPPRSEXO.MaxLength = 2
        Me.cboFPPRSEXO.Name = "cboFPPRSEXO"
        Me.cboFPPRSEXO.Size = New System.Drawing.Size(43, 22)
        Me.cboFPPRSEXO.TabIndex = 2
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label29.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(61, 26)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(42, 20)
        Me.Label29.TabIndex = 388
        Me.Label29.Text = "Sexo"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label28.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(486, 74)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(114, 20)
        Me.Label28.TabIndex = 386
        Me.Label28.Text = "Tipo de documento"
        '
        'lblFPPRTIDO
        '
        Me.lblFPPRTIDO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFPPRTIDO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPPRTIDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPPRTIDO.ForeColor = System.Drawing.Color.Black
        Me.lblFPPRTIDO.Location = New System.Drawing.Point(603, 74)
        Me.lblFPPRTIDO.Name = "lblFPPRTIDO"
        Me.lblFPPRTIDO.Size = New System.Drawing.Size(220, 20)
        Me.lblFPPRTIDO.TabIndex = 385
        '
        'txtFPPRFEES
        '
        Me.txtFPPRFEES.AccessibleDescription = "Fecha de escritura"
        Me.txtFPPRFEES.BackColor = System.Drawing.Color.White
        Me.txtFPPRFEES.Location = New System.Drawing.Point(106, 120)
        Me.txtFPPRFEES.Mask = "00-00-0000"
        Me.txtFPPRFEES.Name = "txtFPPRFEES"
        Me.txtFPPRFEES.Size = New System.Drawing.Size(81, 20)
        Me.txtFPPRFEES.TabIndex = 14
        '
        'cboFPPRNOTA
        '
        Me.cboFPPRNOTA.AccessibleDescription = "Notaria"
        Me.cboFPPRNOTA.BackColor = System.Drawing.Color.White
        Me.cboFPPRNOTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFPPRNOTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPPRNOTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFPPRNOTA.Items.AddRange(New Object() {"001"})
        Me.cboFPPRNOTA.Location = New System.Drawing.Point(533, 96)
        Me.cboFPPRNOTA.MaxLength = 2
        Me.cboFPPRNOTA.Name = "cboFPPRNOTA"
        Me.cboFPPRNOTA.Size = New System.Drawing.Size(67, 22)
        Me.cboFPPRNOTA.TabIndex = 13
        '
        'cboFPPRMUNI
        '
        Me.cboFPPRMUNI.AccessibleDescription = "Municipio"
        Me.cboFPPRMUNI.BackColor = System.Drawing.Color.White
        Me.cboFPPRMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFPPRMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPPRMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFPPRMUNI.Items.AddRange(New Object() {"001"})
        Me.cboFPPRMUNI.Location = New System.Drawing.Point(486, 96)
        Me.cboFPPRMUNI.MaxLength = 2
        Me.cboFPPRMUNI.Name = "cboFPPRMUNI"
        Me.cboFPPRMUNI.Size = New System.Drawing.Size(45, 22)
        Me.cboFPPRMUNI.TabIndex = 12
        '
        'cboFPPRDEPA
        '
        Me.cboFPPRDEPA.AccessibleDescription = "Departamento"
        Me.cboFPPRDEPA.BackColor = System.Drawing.Color.White
        Me.cboFPPRDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFPPRDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPPRDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFPPRDEPA.Items.AddRange(New Object() {"001"})
        Me.cboFPPRDEPA.Location = New System.Drawing.Point(440, 96)
        Me.cboFPPRDEPA.MaxLength = 2
        Me.cboFPPRDEPA.Name = "cboFPPRDEPA"
        Me.cboFPPRDEPA.Size = New System.Drawing.Size(43, 22)
        Me.cboFPPRDEPA.TabIndex = 11
        '
        'txtFPPRMAIN
        '
        Me.txtFPPRMAIN.AccessibleDescription = "Matricula inmobiliaria"
        Me.txtFPPRMAIN.BackColor = System.Drawing.Color.White
        Me.txtFPPRMAIN.Location = New System.Drawing.Point(603, 121)
        Me.txtFPPRMAIN.Mask = "000-0000000"
        Me.txtFPPRMAIN.Name = "txtFPPRMAIN"
        Me.txtFPPRMAIN.Size = New System.Drawing.Size(137, 20)
        Me.txtFPPRMAIN.TabIndex = 17
        '
        'txtFPPRFERE
        '
        Me.txtFPPRFERE.AccessibleDescription = "Fecha de registro"
        Me.txtFPPRFERE.BackColor = System.Drawing.Color.White
        Me.txtFPPRFERE.Location = New System.Drawing.Point(266, 120)
        Me.txtFPPRFERE.Mask = "00-00-0000"
        Me.txtFPPRFERE.Name = "txtFPPRFERE"
        Me.txtFPPRFERE.Size = New System.Drawing.Size(90, 20)
        Me.txtFPPRFERE.TabIndex = 15
        '
        'txtFPPRESCR
        '
        Me.txtFPPRESCR.AccessibleDescription = "Escritura"
        Me.txtFPPRESCR.BackColor = System.Drawing.SystemColors.Window
        Me.txtFPPRESCR.Location = New System.Drawing.Point(266, 97)
        Me.txtFPPRESCR.Name = "txtFPPRESCR"
        Me.txtFPPRESCR.Size = New System.Drawing.Size(90, 20)
        Me.txtFPPRESCR.TabIndex = 10
        '
        'cboFPPRTIDO
        '
        Me.cboFPPRTIDO.AccessibleDescription = "Tipo documento"
        Me.cboFPPRTIDO.BackColor = System.Drawing.Color.White
        Me.cboFPPRTIDO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFPPRTIDO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPPRTIDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFPPRTIDO.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.cboFPPRTIDO.Location = New System.Drawing.Point(106, 49)
        Me.cboFPPRTIDO.Name = "cboFPPRTIDO"
        Me.cboFPPRTIDO.Size = New System.Drawing.Size(43, 22)
        Me.cboFPPRTIDO.TabIndex = 3
        '
        'cboFPPRCAPR
        '
        Me.cboFPPRCAPR.AccessibleDescription = "Calidad propietario"
        Me.cboFPPRCAPR.BackColor = System.Drawing.Color.White
        Me.cboFPPRCAPR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFPPRCAPR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPPRCAPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFPPRCAPR.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11"})
        Me.cboFPPRCAPR.Location = New System.Drawing.Point(17, 49)
        Me.cboFPPRCAPR.MaxLength = 2
        Me.cboFPPRCAPR.Name = "cboFPPRCAPR"
        Me.cboFPPRCAPR.Size = New System.Drawing.Size(42, 22)
        Me.cboFPPRCAPR.TabIndex = 1
        '
        'lblTipoDeDocumento
        '
        Me.lblTipoDeDocumento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblTipoDeDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoDeDocumento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoDeDocumento.ForeColor = System.Drawing.Color.Black
        Me.lblTipoDeDocumento.Location = New System.Drawing.Point(106, 26)
        Me.lblTipoDeDocumento.Name = "lblTipoDeDocumento"
        Me.lblTipoDeDocumento.Size = New System.Drawing.Size(42, 20)
        Me.lblTipoDeDocumento.TabIndex = 375
        Me.lblTipoDeDocumento.Text = "Ti. Do"
        '
        'lblDocumento
        '
        Me.lblDocumento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDocumento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumento.ForeColor = System.Drawing.Color.Black
        Me.lblDocumento.Location = New System.Drawing.Point(151, 26)
        Me.lblDocumento.Name = "lblDocumento"
        Me.lblDocumento.Size = New System.Drawing.Size(112, 20)
        Me.lblDocumento.TabIndex = 374
        Me.lblDocumento.Text = "Nro. Documento"
        '
        'txtFPPRDERE
        '
        Me.txtFPPRDERE.AccessibleDescription = "Derecho"
        Me.txtFPPRDERE.BackColor = System.Drawing.SystemColors.Window
        Me.txtFPPRDERE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFPPRDERE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPPRDERE.ForeColor = System.Drawing.Color.Black
        Me.txtFPPRDERE.Location = New System.Drawing.Point(746, 49)
        Me.txtFPPRDERE.MaxLength = 9
        Me.txtFPPRDERE.Name = "txtFPPRDERE"
        Me.txtFPPRDERE.Size = New System.Drawing.Size(77, 20)
        Me.txtFPPRDERE.TabIndex = 8
        Me.txtFPPRDERE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDerecho
        '
        Me.lblDerecho.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblDerecho.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDerecho.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDerecho.ForeColor = System.Drawing.Color.Black
        Me.lblDerecho.Location = New System.Drawing.Point(746, 26)
        Me.lblDerecho.Name = "lblDerecho"
        Me.lblDerecho.Size = New System.Drawing.Size(77, 20)
        Me.lblDerecho.TabIndex = 373
        Me.lblDerecho.Text = "% Derecho"
        '
        'lblNombre
        '
        Me.lblNombre.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombre.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.Black
        Me.lblNombre.Location = New System.Drawing.Point(524, 26)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(219, 20)
        Me.lblNombre.TabIndex = 372
        Me.lblNombre.Text = "Nombre(s)"
        '
        'lblSegundoApellido
        '
        Me.lblSegundoApellido.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblSegundoApellido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSegundoApellido.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSegundoApellido.ForeColor = System.Drawing.Color.Black
        Me.lblSegundoApellido.Location = New System.Drawing.Point(395, 26)
        Me.lblSegundoApellido.Name = "lblSegundoApellido"
        Me.lblSegundoApellido.Size = New System.Drawing.Size(126, 20)
        Me.lblSegundoApellido.TabIndex = 371
        Me.lblSegundoApellido.Text = "Segundo Apellido"
        '
        'lblPrimerApellido
        '
        Me.lblPrimerApellido.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPrimerApellido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPrimerApellido.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrimerApellido.ForeColor = System.Drawing.Color.Black
        Me.lblPrimerApellido.Location = New System.Drawing.Point(266, 26)
        Me.lblPrimerApellido.Name = "lblPrimerApellido"
        Me.lblPrimerApellido.Size = New System.Drawing.Size(126, 20)
        Me.lblPrimerApellido.TabIndex = 370
        Me.lblPrimerApellido.Text = "Primer Apellido"
        '
        'lblCapr1
        '
        Me.lblCapr1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCapr1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCapr1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapr1.ForeColor = System.Drawing.Color.Black
        Me.lblCapr1.Location = New System.Drawing.Point(17, 26)
        Me.lblCapr1.Name = "lblCapr1"
        Me.lblCapr1.Size = New System.Drawing.Size(41, 20)
        Me.lblCapr1.TabIndex = 369
        Me.lblCapr1.Text = "Ca. Pr"
        '
        'lblMatricula
        '
        Me.lblMatricula.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMatricula.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMatricula.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatricula.ForeColor = System.Drawing.Color.Black
        Me.lblMatricula.Location = New System.Drawing.Point(486, 121)
        Me.lblMatricula.Name = "lblMatricula"
        Me.lblMatricula.Size = New System.Drawing.Size(113, 20)
        Me.lblMatricula.TabIndex = 368
        Me.lblMatricula.Text = "Matricula inmobiliaria"
        '
        'txtFPPRTOMO
        '
        Me.txtFPPRTOMO.AccessibleDescription = "Tomo"
        Me.txtFPPRTOMO.BackColor = System.Drawing.SystemColors.Window
        Me.txtFPPRTOMO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFPPRTOMO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPPRTOMO.ForeColor = System.Drawing.Color.Black
        Me.txtFPPRTOMO.Location = New System.Drawing.Point(440, 121)
        Me.txtFPPRTOMO.MaxLength = 3
        Me.txtFPPRTOMO.Name = "txtFPPRTOMO"
        Me.txtFPPRTOMO.Size = New System.Drawing.Size(43, 20)
        Me.txtFPPRTOMO.TabIndex = 16
        '
        'lblTomo
        '
        Me.lblTomo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblTomo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTomo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTomo.ForeColor = System.Drawing.Color.Black
        Me.lblTomo.Location = New System.Drawing.Point(358, 121)
        Me.lblTomo.Name = "lblTomo"
        Me.lblTomo.Size = New System.Drawing.Size(79, 20)
        Me.lblTomo.TabIndex = 367
        Me.lblTomo.Text = "Tomo"
        '
        'lblFPPRNOTA
        '
        Me.lblFPPRNOTA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFPPRNOTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPPRNOTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPPRNOTA.ForeColor = System.Drawing.Color.Black
        Me.lblFPPRNOTA.Location = New System.Drawing.Point(603, 97)
        Me.lblFPPRNOTA.Name = "lblFPPRNOTA"
        Me.lblFPPRNOTA.Size = New System.Drawing.Size(220, 20)
        Me.lblFPPRNOTA.TabIndex = 366
        '
        'lblNotaria1
        '
        Me.lblNotaria1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblNotaria1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNotaria1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotaria1.ForeColor = System.Drawing.Color.Black
        Me.lblNotaria1.Location = New System.Drawing.Point(358, 97)
        Me.lblNotaria1.Name = "lblNotaria1"
        Me.lblNotaria1.Size = New System.Drawing.Size(79, 20)
        Me.lblNotaria1.TabIndex = 365
        Me.lblNotaria1.Text = "Notaria"
        '
        'lblFechaRegistro
        '
        Me.lblFechaRegistro.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblFechaRegistro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFechaRegistro.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaRegistro.ForeColor = System.Drawing.Color.Black
        Me.lblFechaRegistro.Location = New System.Drawing.Point(189, 121)
        Me.lblFechaRegistro.Name = "lblFechaRegistro"
        Me.lblFechaRegistro.Size = New System.Drawing.Size(74, 20)
        Me.lblFechaRegistro.TabIndex = 364
        Me.lblFechaRegistro.Text = "Fec. Registro"
        '
        'lblFechaEscritura
        '
        Me.lblFechaEscritura.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblFechaEscritura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFechaEscritura.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaEscritura.ForeColor = System.Drawing.Color.Black
        Me.lblFechaEscritura.Location = New System.Drawing.Point(17, 121)
        Me.lblFechaEscritura.Name = "lblFechaEscritura"
        Me.lblFechaEscritura.Size = New System.Drawing.Size(85, 20)
        Me.lblFechaEscritura.TabIndex = 363
        Me.lblFechaEscritura.Text = "Fec. Escritura"
        '
        'lblEscritura
        '
        Me.lblEscritura.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblEscritura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEscritura.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEscritura.ForeColor = System.Drawing.Color.Black
        Me.lblEscritura.Location = New System.Drawing.Point(189, 97)
        Me.lblEscritura.Name = "lblEscritura"
        Me.lblEscritura.Size = New System.Drawing.Size(74, 20)
        Me.lblEscritura.TabIndex = 362
        Me.lblEscritura.Text = "Escritura"
        '
        'chkFPPRGRAV
        '
        Me.chkFPPRGRAV.AccessibleDescription = "Gravable"
        Me.chkFPPRGRAV.Checked = True
        Me.chkFPPRGRAV.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFPPRGRAV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFPPRGRAV.ForeColor = System.Drawing.Color.Black
        Me.chkFPPRGRAV.Location = New System.Drawing.Point(746, 121)
        Me.chkFPPRGRAV.Name = "chkFPPRGRAV"
        Me.chkFPPRGRAV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkFPPRGRAV.Size = New System.Drawing.Size(78, 20)
        Me.chkFPPRGRAV.TabIndex = 357
        Me.chkFPPRGRAV.Text = "Gravable"
        '
        'txtFPPRSICO
        '
        Me.txtFPPRSICO.AccessibleDescription = "Sigla comercial"
        Me.txtFPPRSICO.BackColor = System.Drawing.SystemColors.Window
        Me.txtFPPRSICO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFPPRSICO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPPRSICO.ForeColor = System.Drawing.Color.Black
        Me.txtFPPRSICO.Location = New System.Drawing.Point(106, 97)
        Me.txtFPPRSICO.MaxLength = 20
        Me.txtFPPRSICO.Name = "txtFPPRSICO"
        Me.txtFPPRSICO.ReadOnly = True
        Me.txtFPPRSICO.Size = New System.Drawing.Size(81, 20)
        Me.txtFPPRSICO.TabIndex = 9
        '
        'lblSiglaComercial
        '
        Me.lblSiglaComercial.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblSiglaComercial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSiglaComercial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSiglaComercial.ForeColor = System.Drawing.Color.Black
        Me.lblSiglaComercial.Location = New System.Drawing.Point(17, 97)
        Me.lblSiglaComercial.Name = "lblSiglaComercial"
        Me.lblSiglaComercial.Size = New System.Drawing.Size(85, 20)
        Me.lblSiglaComercial.TabIndex = 361
        Me.lblSiglaComercial.Text = "Sigla Comercial"
        '
        'lblFPPRCAPR
        '
        Me.lblFPPRCAPR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFPPRCAPR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPPRCAPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPPRCAPR.ForeColor = System.Drawing.Color.Black
        Me.lblFPPRCAPR.Location = New System.Drawing.Point(106, 74)
        Me.lblFPPRCAPR.Name = "lblFPPRCAPR"
        Me.lblFPPRCAPR.Size = New System.Drawing.Size(157, 20)
        Me.lblFPPRCAPR.TabIndex = 360
        '
        'lblCaPr2
        '
        Me.lblCaPr2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCaPr2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCaPr2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaPr2.ForeColor = System.Drawing.Color.Black
        Me.lblCaPr2.Location = New System.Drawing.Point(17, 74)
        Me.lblCaPr2.Name = "lblCaPr2"
        Me.lblCaPr2.Size = New System.Drawing.Size(85, 20)
        Me.lblCaPr2.TabIndex = 359
        Me.lblCaPr2.Text = "Calidad Prop."
        '
        'frm_modificar_FIPRPROP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdSALIR
        Me.ClientSize = New System.Drawing.Size(872, 306)
        Me.Controls.Add(Me.fraCOMANDOS)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraPROPIETARIO)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(888, 342)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(888, 342)
        Me.Name = "frm_modificar_FIPRPROP"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.fraCOMANDOS.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraPROPIETARIO.ResumeLayout(False)
        Me.fraPROPIETARIO.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraCOMANDOS As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraPROPIETARIO As System.Windows.Forms.GroupBox
    Friend WithEvents txtFPPRNOMB As System.Windows.Forms.TextBox
    Friend WithEvents txtFPPRSEAP As System.Windows.Forms.TextBox
    Friend WithEvents txtFPPRPRAP As System.Windows.Forms.TextBox
    Friend WithEvents txtFPPRNUDO As System.Windows.Forms.TextBox
    Friend WithEvents cboFPPRESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents lblFPPRSEXO As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cboFPPRSEXO As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lblFPPRTIDO As System.Windows.Forms.Label
    Friend WithEvents txtFPPRFEES As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cboFPPRNOTA As System.Windows.Forms.ComboBox
    Friend WithEvents cboFPPRMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents cboFPPRDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents txtFPPRMAIN As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFPPRFERE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFPPRESCR As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cboFPPRTIDO As System.Windows.Forms.ComboBox
    Friend WithEvents cboFPPRCAPR As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoDeDocumento As System.Windows.Forms.Label
    Friend WithEvents lblDocumento As System.Windows.Forms.Label
    Friend WithEvents txtFPPRDERE As System.Windows.Forms.TextBox
    Friend WithEvents lblDerecho As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblSegundoApellido As System.Windows.Forms.Label
    Friend WithEvents lblPrimerApellido As System.Windows.Forms.Label
    Friend WithEvents lblCapr1 As System.Windows.Forms.Label
    Friend WithEvents lblMatricula As System.Windows.Forms.Label
    Friend WithEvents txtFPPRTOMO As System.Windows.Forms.TextBox
    Friend WithEvents lblTomo As System.Windows.Forms.Label
    Friend WithEvents lblFPPRNOTA As System.Windows.Forms.Label
    Friend WithEvents lblNotaria1 As System.Windows.Forms.Label
    Friend WithEvents lblFechaRegistro As System.Windows.Forms.Label
    Friend WithEvents lblFechaEscritura As System.Windows.Forms.Label
    Friend WithEvents lblEscritura As System.Windows.Forms.Label
    Friend WithEvents chkFPPRGRAV As System.Windows.Forms.CheckBox
    Friend WithEvents txtFPPRSICO As System.Windows.Forms.TextBox
    Friend WithEvents lblSiglaComercial As System.Windows.Forms.Label
    Friend WithEvents lblFPPRCAPR As System.Windows.Forms.Label
    Friend WithEvents lblCaPr2 As System.Windows.Forms.Label
    Friend WithEvents cboFPPRMOAD As System.Windows.Forms.ComboBox
    Friend WithEvents lblFPPRMOAD As System.Windows.Forms.Label
    Friend WithEvents lblAdquisicionDelPredioPropietario As System.Windows.Forms.Label
End Class
