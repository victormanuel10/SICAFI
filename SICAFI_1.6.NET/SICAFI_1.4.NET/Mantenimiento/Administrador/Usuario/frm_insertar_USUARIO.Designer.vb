<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_USUARIO
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
        Me.components = New System.ComponentModel.Container
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.fraTERCERO = New System.Windows.Forms.GroupBox
        Me.cmdVALIDAR = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtUSUAOBSE = New System.Windows.Forms.TextBox
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.cmdGUARDAR = New System.Windows.Forms.Button
        Me.cboUSUAESTA = New System.Windows.Forms.ComboBox
        Me.cboUSUACAPR = New System.Windows.Forms.ComboBox
        Me.cboUSUASEXO = New System.Windows.Forms.ComboBox
        Me.cboUSUATIDO = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtUSUADIRE = New System.Windows.Forms.TextBox
        Me.lblDireccion = New System.Windows.Forms.Label
        Me.txtUSUAFAX1 = New System.Windows.Forms.TextBox
        Me.lblContrasena = New System.Windows.Forms.Label
        Me.txtUSUATEL2 = New System.Windows.Forms.TextBox
        Me.txtUSUATEL1 = New System.Windows.Forms.TextBox
        Me.lblTelefonos = New System.Windows.Forms.Label
        Me.lblUSUACAPR = New System.Windows.Forms.Label
        Me.lblUSUASEXO = New System.Windows.Forms.Label
        Me.txtUSUANUDO = New System.Windows.Forms.TextBox
        Me.lblUSUATIDO = New System.Windows.Forms.Label
        Me.txtUSUASICO = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtUSUASEAP = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtUSUAPRAP = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtUSUANOMB = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblCalidadPropietario2 = New System.Windows.Forms.Label
        Me.lblSexo2 = New System.Windows.Forms.Label
        Me.lblTipoDocumento2 = New System.Windows.Forms.Label
        Me.lblNumeroDocumento = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.strBARRESTA.SuspendLayout()
        Me.fraTERCERO.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 369)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(739, 25)
        Me.strBARRESTA.TabIndex = 29
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
        'fraTERCERO
        '
        Me.fraTERCERO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraTERCERO.BackColor = System.Drawing.SystemColors.Control
        Me.fraTERCERO.Controls.Add(Me.cmdVALIDAR)
        Me.fraTERCERO.Controls.Add(Me.Label3)
        Me.fraTERCERO.Controls.Add(Me.txtUSUAOBSE)
        Me.fraTERCERO.Controls.Add(Me.cmdSALIR)
        Me.fraTERCERO.Controls.Add(Me.cmdGUARDAR)
        Me.fraTERCERO.Controls.Add(Me.cboUSUAESTA)
        Me.fraTERCERO.Controls.Add(Me.cboUSUACAPR)
        Me.fraTERCERO.Controls.Add(Me.cboUSUASEXO)
        Me.fraTERCERO.Controls.Add(Me.cboUSUATIDO)
        Me.fraTERCERO.Controls.Add(Me.Label1)
        Me.fraTERCERO.Controls.Add(Me.txtUSUADIRE)
        Me.fraTERCERO.Controls.Add(Me.lblDireccion)
        Me.fraTERCERO.Controls.Add(Me.txtUSUAFAX1)
        Me.fraTERCERO.Controls.Add(Me.lblContrasena)
        Me.fraTERCERO.Controls.Add(Me.txtUSUATEL2)
        Me.fraTERCERO.Controls.Add(Me.txtUSUATEL1)
        Me.fraTERCERO.Controls.Add(Me.lblTelefonos)
        Me.fraTERCERO.Controls.Add(Me.lblUSUACAPR)
        Me.fraTERCERO.Controls.Add(Me.lblUSUASEXO)
        Me.fraTERCERO.Controls.Add(Me.txtUSUANUDO)
        Me.fraTERCERO.Controls.Add(Me.lblUSUATIDO)
        Me.fraTERCERO.Controls.Add(Me.txtUSUASICO)
        Me.fraTERCERO.Controls.Add(Me.Label7)
        Me.fraTERCERO.Controls.Add(Me.txtUSUASEAP)
        Me.fraTERCERO.Controls.Add(Me.Label6)
        Me.fraTERCERO.Controls.Add(Me.txtUSUAPRAP)
        Me.fraTERCERO.Controls.Add(Me.Label5)
        Me.fraTERCERO.Controls.Add(Me.txtUSUANOMB)
        Me.fraTERCERO.Controls.Add(Me.Label4)
        Me.fraTERCERO.Controls.Add(Me.lblCalidadPropietario2)
        Me.fraTERCERO.Controls.Add(Me.lblSexo2)
        Me.fraTERCERO.Controls.Add(Me.lblTipoDocumento2)
        Me.fraTERCERO.Controls.Add(Me.lblNumeroDocumento)
        Me.fraTERCERO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraTERCERO.ForeColor = System.Drawing.Color.Black
        Me.fraTERCERO.Location = New System.Drawing.Point(12, 12)
        Me.fraTERCERO.Name = "fraTERCERO"
        Me.fraTERCERO.Size = New System.Drawing.Size(723, 351)
        Me.fraTERCERO.TabIndex = 30
        Me.fraTERCERO.TabStop = False
        Me.fraTERCERO.Text = "INSERTAR USUARIO"
        '
        'cmdVALIDAR
        '
        Me.cmdVALIDAR.AccessibleDescription = "Guardar"
        Me.cmdVALIDAR.Image = Global.SICAFI.My.Resources.Resources._295
        Me.cmdVALIDAR.Location = New System.Drawing.Point(671, 195)
        Me.cmdVALIDAR.Name = "cmdVALIDAR"
        Me.cmdVALIDAR.Size = New System.Drawing.Size(33, 23)
        Me.cmdVALIDAR.TabIndex = 49
        Me.cmdVALIDAR.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(17, 221)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(687, 20)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Observaciones"
        '
        'txtUSUAOBSE
        '
        Me.txtUSUAOBSE.AccessibleDescription = "Observaciones"
        Me.txtUSUAOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtUSUAOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUSUAOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUSUAOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtUSUAOBSE.Location = New System.Drawing.Point(17, 246)
        Me.txtUSUAOBSE.MaxLength = 1000
        Me.txtUSUAOBSE.Multiline = True
        Me.txtUSUAOBSE.Name = "txtUSUAOBSE"
        Me.txtUSUAOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtUSUAOBSE.Size = New System.Drawing.Size(687, 50)
        Me.txtUSUAOBSE.TabIndex = 47
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(357, 311)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 15
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(250, 311)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 14
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'cboUSUAESTA
        '
        Me.cboUSUAESTA.AccessibleDescription = "Estado"
        Me.cboUSUAESTA.BackColor = System.Drawing.SystemColors.Window
        Me.cboUSUAESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUSUAESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUSUAESTA.FormattingEnabled = True
        Me.cboUSUAESTA.Location = New System.Drawing.Point(137, 196)
        Me.cboUSUAESTA.MaxDropDownItems = 11
        Me.cboUSUAESTA.Name = "cboUSUAESTA"
        Me.cboUSUAESTA.Size = New System.Drawing.Size(111, 22)
        Me.cboUSUAESTA.TabIndex = 13
        '
        'cboUSUACAPR
        '
        Me.cboUSUACAPR.AccessibleDescription = "Calidad de propietario"
        Me.cboUSUACAPR.BackColor = System.Drawing.SystemColors.Window
        Me.cboUSUACAPR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboUSUACAPR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUSUACAPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUSUACAPR.FormattingEnabled = True
        Me.cboUSUACAPR.Location = New System.Drawing.Point(137, 52)
        Me.cboUSUACAPR.MaxDropDownItems = 11
        Me.cboUSUACAPR.Name = "cboUSUACAPR"
        Me.cboUSUACAPR.Size = New System.Drawing.Size(50, 22)
        Me.cboUSUACAPR.TabIndex = 3
        '
        'cboUSUASEXO
        '
        Me.cboUSUASEXO.AccessibleDescription = "Sexo"
        Me.cboUSUASEXO.BackColor = System.Drawing.SystemColors.Window
        Me.cboUSUASEXO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboUSUASEXO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUSUASEXO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUSUASEXO.FormattingEnabled = True
        Me.cboUSUASEXO.Location = New System.Drawing.Point(476, 50)
        Me.cboUSUASEXO.Name = "cboUSUASEXO"
        Me.cboUSUASEXO.Size = New System.Drawing.Size(50, 22)
        Me.cboUSUASEXO.TabIndex = 4
        '
        'cboUSUATIDO
        '
        Me.cboUSUATIDO.AccessibleDescription = "Tipo de documento"
        Me.cboUSUATIDO.BackColor = System.Drawing.SystemColors.Window
        Me.cboUSUATIDO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboUSUATIDO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUSUATIDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUSUATIDO.FormattingEnabled = True
        Me.cboUSUATIDO.Location = New System.Drawing.Point(476, 27)
        Me.cboUSUATIDO.Name = "cboUSUATIDO"
        Me.cboUSUATIDO.Size = New System.Drawing.Size(50, 22)
        Me.cboUSUATIDO.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 196)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 20)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Estado"
        '
        'txtUSUADIRE
        '
        Me.txtUSUADIRE.AccessibleDescription = "Dirección de predio"
        Me.txtUSUADIRE.BackColor = System.Drawing.SystemColors.Window
        Me.txtUSUADIRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUSUADIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUSUADIRE.ForeColor = System.Drawing.Color.Black
        Me.txtUSUADIRE.Location = New System.Drawing.Point(137, 172)
        Me.txtUSUADIRE.MaxLength = 49
        Me.txtUSUADIRE.Name = "txtUSUADIRE"
        Me.txtUSUADIRE.Size = New System.Drawing.Size(567, 20)
        Me.txtUSUADIRE.TabIndex = 12
        '
        'lblDireccion
        '
        Me.lblDireccion.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblDireccion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDireccion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccion.ForeColor = System.Drawing.Color.Black
        Me.lblDireccion.Location = New System.Drawing.Point(17, 172)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(116, 20)
        Me.lblDireccion.TabIndex = 40
        Me.lblDireccion.Text = "Dirección"
        '
        'txtUSUAFAX1
        '
        Me.txtUSUAFAX1.AccessibleDescription = "Fax 1"
        Me.txtUSUAFAX1.BackColor = System.Drawing.SystemColors.Window
        Me.txtUSUAFAX1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUSUAFAX1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUSUAFAX1.ForeColor = System.Drawing.Color.Black
        Me.txtUSUAFAX1.Location = New System.Drawing.Point(476, 148)
        Me.txtUSUAFAX1.MaxLength = 15
        Me.txtUSUAFAX1.Name = "txtUSUAFAX1"
        Me.txtUSUAFAX1.Size = New System.Drawing.Size(228, 20)
        Me.txtUSUAFAX1.TabIndex = 11
        '
        'lblContrasena
        '
        Me.lblContrasena.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblContrasena.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblContrasena.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContrasena.ForeColor = System.Drawing.Color.Black
        Me.lblContrasena.Location = New System.Drawing.Point(357, 148)
        Me.lblContrasena.Name = "lblContrasena"
        Me.lblContrasena.Size = New System.Drawing.Size(116, 20)
        Me.lblContrasena.TabIndex = 37
        Me.lblContrasena.Text = "Fax"
        '
        'txtUSUATEL2
        '
        Me.txtUSUATEL2.AccessibleDescription = "Telefono 2"
        Me.txtUSUATEL2.BackColor = System.Drawing.SystemColors.Window
        Me.txtUSUATEL2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUSUATEL2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUSUATEL2.ForeColor = System.Drawing.Color.Black
        Me.txtUSUATEL2.Location = New System.Drawing.Point(248, 148)
        Me.txtUSUATEL2.MaxLength = 15
        Me.txtUSUATEL2.Name = "txtUSUATEL2"
        Me.txtUSUATEL2.Size = New System.Drawing.Size(107, 20)
        Me.txtUSUATEL2.TabIndex = 10
        '
        'txtUSUATEL1
        '
        Me.txtUSUATEL1.AccessibleDescription = "Telefono 1"
        Me.txtUSUATEL1.BackColor = System.Drawing.SystemColors.Window
        Me.txtUSUATEL1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUSUATEL1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUSUATEL1.ForeColor = System.Drawing.Color.Black
        Me.txtUSUATEL1.Location = New System.Drawing.Point(137, 148)
        Me.txtUSUATEL1.MaxLength = 15
        Me.txtUSUATEL1.Name = "txtUSUATEL1"
        Me.txtUSUATEL1.Size = New System.Drawing.Size(108, 20)
        Me.txtUSUATEL1.TabIndex = 9
        '
        'lblTelefonos
        '
        Me.lblTelefonos.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblTelefonos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTelefonos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefonos.ForeColor = System.Drawing.Color.Black
        Me.lblTelefonos.Location = New System.Drawing.Point(17, 148)
        Me.lblTelefonos.Name = "lblTelefonos"
        Me.lblTelefonos.Size = New System.Drawing.Size(116, 20)
        Me.lblTelefonos.TabIndex = 34
        Me.lblTelefonos.Text = "Telefonos"
        '
        'lblUSUACAPR
        '
        Me.lblUSUACAPR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblUSUACAPR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUSUACAPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUSUACAPR.ForeColor = System.Drawing.Color.Black
        Me.lblUSUACAPR.Location = New System.Drawing.Point(193, 52)
        Me.lblUSUACAPR.Name = "lblUSUACAPR"
        Me.lblUSUACAPR.Size = New System.Drawing.Size(160, 20)
        Me.lblUSUACAPR.TabIndex = 33
        '
        'lblUSUASEXO
        '
        Me.lblUSUASEXO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblUSUASEXO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUSUASEXO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUSUASEXO.ForeColor = System.Drawing.Color.Black
        Me.lblUSUASEXO.Location = New System.Drawing.Point(532, 52)
        Me.lblUSUASEXO.Name = "lblUSUASEXO"
        Me.lblUSUASEXO.Size = New System.Drawing.Size(172, 20)
        Me.lblUSUASEXO.TabIndex = 32
        '
        'txtUSUANUDO
        '
        Me.txtUSUANUDO.AccessibleDescription = "Numero de documento"
        Me.txtUSUANUDO.BackColor = System.Drawing.SystemColors.Window
        Me.txtUSUANUDO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUSUANUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUSUANUDO.ForeColor = System.Drawing.Color.Black
        Me.txtUSUANUDO.Location = New System.Drawing.Point(137, 28)
        Me.txtUSUANUDO.MaxLength = 14
        Me.txtUSUANUDO.Name = "txtUSUANUDO"
        Me.txtUSUANUDO.Size = New System.Drawing.Size(200, 20)
        Me.txtUSUANUDO.TabIndex = 1
        '
        'lblUSUATIDO
        '
        Me.lblUSUATIDO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblUSUATIDO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUSUATIDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUSUATIDO.ForeColor = System.Drawing.Color.Black
        Me.lblUSUATIDO.Location = New System.Drawing.Point(532, 29)
        Me.lblUSUATIDO.Name = "lblUSUATIDO"
        Me.lblUSUATIDO.Size = New System.Drawing.Size(172, 20)
        Me.lblUSUATIDO.TabIndex = 29
        '
        'txtUSUASICO
        '
        Me.txtUSUASICO.AccessibleDescription = "Sigla comercial"
        Me.txtUSUASICO.BackColor = System.Drawing.SystemColors.Window
        Me.txtUSUASICO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUSUASICO.ForeColor = System.Drawing.Color.Black
        Me.txtUSUASICO.Location = New System.Drawing.Point(137, 124)
        Me.txtUSUASICO.MaxLength = 20
        Me.txtUSUASICO.Name = "txtUSUASICO"
        Me.txtUSUASICO.Size = New System.Drawing.Size(567, 20)
        Me.txtUSUASICO.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(17, 124)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 20)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Sigla Comercial"
        '
        'txtUSUASEAP
        '
        Me.txtUSUASEAP.AccessibleDescription = "Segundo apellido"
        Me.txtUSUASEAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtUSUASEAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUSUASEAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUSUASEAP.ForeColor = System.Drawing.Color.Black
        Me.txtUSUASEAP.Location = New System.Drawing.Point(476, 100)
        Me.txtUSUASEAP.MaxLength = 15
        Me.txtUSUASEAP.Name = "txtUSUASEAP"
        Me.txtUSUASEAP.Size = New System.Drawing.Size(228, 20)
        Me.txtUSUASEAP.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(357, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 20)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Segundo Apellido"
        '
        'txtUSUAPRAP
        '
        Me.txtUSUAPRAP.AccessibleDescription = "Primer apellido"
        Me.txtUSUAPRAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtUSUAPRAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUSUAPRAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUSUAPRAP.ForeColor = System.Drawing.Color.Black
        Me.txtUSUAPRAP.Location = New System.Drawing.Point(137, 100)
        Me.txtUSUAPRAP.MaxLength = 15
        Me.txtUSUAPRAP.Name = "txtUSUAPRAP"
        Me.txtUSUAPRAP.Size = New System.Drawing.Size(218, 20)
        Me.txtUSUAPRAP.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(17, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 20)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Primer Apellido"
        '
        'txtUSUANOMB
        '
        Me.txtUSUANOMB.AccessibleDescription = "Nombre (s)"
        Me.txtUSUANOMB.BackColor = System.Drawing.SystemColors.Window
        Me.txtUSUANOMB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUSUANOMB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUSUANOMB.ForeColor = System.Drawing.Color.Black
        Me.txtUSUANOMB.Location = New System.Drawing.Point(137, 76)
        Me.txtUSUANOMB.MaxLength = 20
        Me.txtUSUANOMB.Name = "txtUSUANOMB"
        Me.txtUSUANOMB.Size = New System.Drawing.Size(567, 20)
        Me.txtUSUANOMB.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(17, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 20)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Nombre (S)"
        '
        'lblCalidadPropietario2
        '
        Me.lblCalidadPropietario2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCalidadPropietario2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCalidadPropietario2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalidadPropietario2.ForeColor = System.Drawing.Color.Black
        Me.lblCalidadPropietario2.Location = New System.Drawing.Point(17, 52)
        Me.lblCalidadPropietario2.Name = "lblCalidadPropietario2"
        Me.lblCalidadPropietario2.Size = New System.Drawing.Size(116, 20)
        Me.lblCalidadPropietario2.TabIndex = 20
        Me.lblCalidadPropietario2.Text = "Calidad Propietario"
        '
        'lblSexo2
        '
        Me.lblSexo2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblSexo2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSexo2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSexo2.ForeColor = System.Drawing.Color.Black
        Me.lblSexo2.Location = New System.Drawing.Point(357, 52)
        Me.lblSexo2.Name = "lblSexo2"
        Me.lblSexo2.Size = New System.Drawing.Size(116, 19)
        Me.lblSexo2.TabIndex = 18
        Me.lblSexo2.Text = "Sexo"
        '
        'lblTipoDocumento2
        '
        Me.lblTipoDocumento2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblTipoDocumento2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoDocumento2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoDocumento2.ForeColor = System.Drawing.Color.Black
        Me.lblTipoDocumento2.Location = New System.Drawing.Point(357, 29)
        Me.lblTipoDocumento2.Name = "lblTipoDocumento2"
        Me.lblTipoDocumento2.Size = New System.Drawing.Size(116, 19)
        Me.lblTipoDocumento2.TabIndex = 16
        Me.lblTipoDocumento2.Text = "Tipo de documento"
        '
        'lblNumeroDocumento
        '
        Me.lblNumeroDocumento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblNumeroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumeroDocumento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroDocumento.ForeColor = System.Drawing.Color.Black
        Me.lblNumeroDocumento.Location = New System.Drawing.Point(17, 28)
        Me.lblNumeroDocumento.Name = "lblNumeroDocumento"
        Me.lblNumeroDocumento.Size = New System.Drawing.Size(116, 20)
        Me.lblNumeroDocumento.TabIndex = 14
        Me.lblNumeroDocumento.Text = "Nro. Documento"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frm_insertar_USUARIO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdSALIR
        Me.ClientSize = New System.Drawing.Size(739, 394)
        Me.Controls.Add(Me.fraTERCERO)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(755, 430)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(755, 430)
        Me.Name = "frm_insertar_USUARIO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraTERCERO.ResumeLayout(False)
        Me.fraTERCERO.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraTERCERO As System.Windows.Forms.GroupBox
    Friend WithEvents cmdVALIDAR As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUSUAOBSE As System.Windows.Forms.TextBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents cboUSUAESTA As System.Windows.Forms.ComboBox
    Friend WithEvents cboUSUACAPR As System.Windows.Forms.ComboBox
    Friend WithEvents cboUSUASEXO As System.Windows.Forms.ComboBox
    Friend WithEvents cboUSUATIDO As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUSUADIRE As System.Windows.Forms.TextBox
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents txtUSUAFAX1 As System.Windows.Forms.TextBox
    Friend WithEvents lblContrasena As System.Windows.Forms.Label
    Friend WithEvents txtUSUATEL2 As System.Windows.Forms.TextBox
    Friend WithEvents txtUSUATEL1 As System.Windows.Forms.TextBox
    Friend WithEvents lblTelefonos As System.Windows.Forms.Label
    Friend WithEvents lblUSUACAPR As System.Windows.Forms.Label
    Friend WithEvents lblUSUASEXO As System.Windows.Forms.Label
    Friend WithEvents txtUSUANUDO As System.Windows.Forms.TextBox
    Friend WithEvents lblUSUATIDO As System.Windows.Forms.Label
    Friend WithEvents txtUSUASICO As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtUSUASEAP As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtUSUAPRAP As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtUSUANOMB As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCalidadPropietario2 As System.Windows.Forms.Label
    Friend WithEvents lblSexo2 As System.Windows.Forms.Label
    Friend WithEvents lblTipoDocumento2 As System.Windows.Forms.Label
    Friend WithEvents lblNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
