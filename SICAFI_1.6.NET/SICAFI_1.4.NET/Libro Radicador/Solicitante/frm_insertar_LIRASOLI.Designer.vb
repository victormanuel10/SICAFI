<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_LIRASOLI
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
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraINFOUSUA = New System.Windows.Forms.GroupBox()
        Me.lblLRSOSOLI = New System.Windows.Forms.Label()
        Me.cboLRSOSOLI = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtLRSORESO = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtLRSOCOPO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLRSOCOEL = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLRSODINO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLRSODIPR = New System.Windows.Forms.TextBox()
        Me.lblTelefonos = New System.Windows.Forms.Label()
        Me.txtLRSOTELE = New System.Windows.Forms.TextBox()
        Me.txtLRSOSEAP = New System.Windows.Forms.TextBox()
        Me.txtLRSOCELU = New System.Windows.Forms.TextBox()
        Me.txtLRSOPRAP = New System.Windows.Forms.TextBox()
        Me.txtLRSONUDO = New System.Windows.Forms.TextBox()
        Me.txtLRSONOMB = New System.Windows.Forms.TextBox()
        Me.lblNumeroDocumento = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox4.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraINFOUSUA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdSALIR)
        Me.GroupBox4.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 195)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(906, 49)
        Me.GroupBox4.TabIndex = 350
        Me.GroupBox4.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(457, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 11
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(350, 15)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 10
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 263)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(930, 25)
        Me.strBARRESTA.TabIndex = 351
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
        'fraINFOUSUA
        '
        Me.fraINFOUSUA.Controls.Add(Me.lblLRSOSOLI)
        Me.fraINFOUSUA.Controls.Add(Me.cboLRSOSOLI)
        Me.fraINFOUSUA.Controls.Add(Me.Label8)
        Me.fraINFOUSUA.Controls.Add(Me.txtLRSORESO)
        Me.fraINFOUSUA.Controls.Add(Me.Label7)
        Me.fraINFOUSUA.Controls.Add(Me.txtLRSOCOPO)
        Me.fraINFOUSUA.Controls.Add(Me.Label2)
        Me.fraINFOUSUA.Controls.Add(Me.txtLRSOCOEL)
        Me.fraINFOUSUA.Controls.Add(Me.Label3)
        Me.fraINFOUSUA.Controls.Add(Me.txtLRSODINO)
        Me.fraINFOUSUA.Controls.Add(Me.Label1)
        Me.fraINFOUSUA.Controls.Add(Me.txtLRSODIPR)
        Me.fraINFOUSUA.Controls.Add(Me.lblTelefonos)
        Me.fraINFOUSUA.Controls.Add(Me.txtLRSOTELE)
        Me.fraINFOUSUA.Controls.Add(Me.txtLRSOSEAP)
        Me.fraINFOUSUA.Controls.Add(Me.txtLRSOCELU)
        Me.fraINFOUSUA.Controls.Add(Me.txtLRSOPRAP)
        Me.fraINFOUSUA.Controls.Add(Me.txtLRSONUDO)
        Me.fraINFOUSUA.Controls.Add(Me.txtLRSONOMB)
        Me.fraINFOUSUA.Controls.Add(Me.lblNumeroDocumento)
        Me.fraINFOUSUA.Controls.Add(Me.Label4)
        Me.fraINFOUSUA.Controls.Add(Me.Label5)
        Me.fraINFOUSUA.Controls.Add(Me.lblDireccion)
        Me.fraINFOUSUA.Controls.Add(Me.Label6)
        Me.fraINFOUSUA.Location = New System.Drawing.Point(12, 10)
        Me.fraINFOUSUA.Name = "fraINFOUSUA"
        Me.fraINFOUSUA.Size = New System.Drawing.Size(906, 179)
        Me.fraINFOUSUA.TabIndex = 349
        Me.fraINFOUSUA.TabStop = False
        Me.fraINFOUSUA.Text = "INSERTAR SOLICITANTE"
        '
        'lblLRSOSOLI
        '
        Me.lblLRSOSOLI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblLRSOSOLI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLRSOSOLI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLRSOSOLI.ForeColor = System.Drawing.Color.Black
        Me.lblLRSOSOLI.Location = New System.Drawing.Point(719, 26)
        Me.lblLRSOSOLI.Name = "lblLRSOSOLI"
        Me.lblLRSOSOLI.Size = New System.Drawing.Size(172, 20)
        Me.lblLRSOSOLI.TabIndex = 484
        '
        'cboLRSOSOLI
        '
        Me.cboLRSOSOLI.AccessibleDescription = "Solicitante"
        Me.cboLRSOSOLI.BackColor = System.Drawing.Color.White
        Me.cboLRSOSOLI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboLRSOSOLI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLRSOSOLI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLRSOSOLI.Location = New System.Drawing.Point(432, 24)
        Me.cboLRSOSOLI.MaxDropDownItems = 15
        Me.cboLRSOSOLI.MaxLength = 1
        Me.cboLRSOSOLI.Name = "cboLRSOSOLI"
        Me.cboLRSOSOLI.Size = New System.Drawing.Size(284, 22)
        Me.cboLRSOSOLI.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(312, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 20)
        Me.Label8.TabIndex = 483
        Me.Label8.Text = "Solicitante"
        '
        'txtLRSORESO
        '
        Me.txtLRSORESO.AccessibleDescription = "Redes sociales"
        Me.txtLRSORESO.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRSORESO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRSORESO.ForeColor = System.Drawing.Color.Black
        Me.txtLRSORESO.Location = New System.Drawing.Point(552, 141)
        Me.txtLRSORESO.MaxLength = 50
        Me.txtLRSORESO.Name = "txtLRSORESO"
        Me.txtLRSORESO.Size = New System.Drawing.Size(339, 20)
        Me.txtLRSORESO.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(432, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 20)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "Redes sociales"
        '
        'txtLRSOCOPO
        '
        Me.txtLRSOCOPO.AccessibleDescription = "Código postal"
        Me.txtLRSOCOPO.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRSOCOPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRSOCOPO.ForeColor = System.Drawing.Color.Black
        Me.txtLRSOCOPO.Location = New System.Drawing.Point(137, 141)
        Me.txtLRSOCOPO.MaxLength = 50
        Me.txtLRSOCOPO.Name = "txtLRSOCOPO"
        Me.txtLRSOCOPO.Size = New System.Drawing.Size(291, 20)
        Me.txtLRSOCOPO.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(17, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 20)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Código postal"
        '
        'txtLRSOCOEL
        '
        Me.txtLRSOCOEL.AccessibleDescription = "Correo electronico"
        Me.txtLRSOCOEL.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRSOCOEL.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtLRSOCOEL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRSOCOEL.ForeColor = System.Drawing.Color.Black
        Me.txtLRSOCOEL.Location = New System.Drawing.Point(432, 118)
        Me.txtLRSOCOEL.MaxLength = 50
        Me.txtLRSOCOEL.Name = "txtLRSOCOEL"
        Me.txtLRSOCOEL.Size = New System.Drawing.Size(459, 20)
        Me.txtLRSOCOEL.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(312, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 20)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Correo electronico"
        '
        'txtLRSODINO
        '
        Me.txtLRSODINO.AccessibleDescription = "Dirección"
        Me.txtLRSODINO.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRSODINO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRSODINO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRSODINO.ForeColor = System.Drawing.Color.Black
        Me.txtLRSODINO.Location = New System.Drawing.Point(137, 95)
        Me.txtLRSODINO.MaxLength = 100
        Me.txtLRSODINO.Name = "txtLRSODINO"
        Me.txtLRSODINO.Size = New System.Drawing.Size(754, 20)
        Me.txtLRSODINO.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 20)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Dirección notificación"
        '
        'txtLRSODIPR
        '
        Me.txtLRSODIPR.AccessibleDescription = "Dirección"
        Me.txtLRSODIPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRSODIPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRSODIPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRSODIPR.ForeColor = System.Drawing.Color.Black
        Me.txtLRSODIPR.Location = New System.Drawing.Point(137, 72)
        Me.txtLRSODIPR.MaxLength = 100
        Me.txtLRSODIPR.Name = "txtLRSODIPR"
        Me.txtLRSODIPR.Size = New System.Drawing.Size(754, 20)
        Me.txtLRSODIPR.TabIndex = 6
        '
        'lblTelefonos
        '
        Me.lblTelefonos.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblTelefonos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTelefonos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefonos.ForeColor = System.Drawing.Color.Black
        Me.lblTelefonos.Location = New System.Drawing.Point(17, 118)
        Me.lblTelefonos.Name = "lblTelefonos"
        Me.lblTelefonos.Size = New System.Drawing.Size(116, 20)
        Me.lblTelefonos.TabIndex = 64
        Me.lblTelefonos.Text = "Telefono / Cecular"
        '
        'txtLRSOTELE
        '
        Me.txtLRSOTELE.AccessibleDescription = "Telefono 1 "
        Me.txtLRSOTELE.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRSOTELE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRSOTELE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRSOTELE.ForeColor = System.Drawing.Color.Black
        Me.txtLRSOTELE.Location = New System.Drawing.Point(136, 118)
        Me.txtLRSOTELE.MaxLength = 20
        Me.txtLRSOTELE.Name = "txtLRSOTELE"
        Me.txtLRSOTELE.Size = New System.Drawing.Size(85, 20)
        Me.txtLRSOTELE.TabIndex = 8
        '
        'txtLRSOSEAP
        '
        Me.txtLRSOSEAP.AccessibleDescription = "Segundo apellido"
        Me.txtLRSOSEAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRSOSEAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRSOSEAP.ForeColor = System.Drawing.Color.Black
        Me.txtLRSOSEAP.Location = New System.Drawing.Point(719, 48)
        Me.txtLRSOSEAP.MaxLength = 50
        Me.txtLRSOSEAP.Name = "txtLRSOSEAP"
        Me.txtLRSOSEAP.Size = New System.Drawing.Size(172, 20)
        Me.txtLRSOSEAP.TabIndex = 5
        '
        'txtLRSOCELU
        '
        Me.txtLRSOCELU.AccessibleDescription = "Telefono 2 "
        Me.txtLRSOCELU.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRSOCELU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRSOCELU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRSOCELU.ForeColor = System.Drawing.Color.Black
        Me.txtLRSOCELU.Location = New System.Drawing.Point(224, 118)
        Me.txtLRSOCELU.MaxLength = 20
        Me.txtLRSOCELU.Name = "txtLRSOCELU"
        Me.txtLRSOCELU.Size = New System.Drawing.Size(84, 20)
        Me.txtLRSOCELU.TabIndex = 9
        '
        'txtLRSOPRAP
        '
        Me.txtLRSOPRAP.AccessibleDescription = "Primer apellido"
        Me.txtLRSOPRAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRSOPRAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRSOPRAP.ForeColor = System.Drawing.Color.Black
        Me.txtLRSOPRAP.Location = New System.Drawing.Point(432, 49)
        Me.txtLRSOPRAP.MaxLength = 50
        Me.txtLRSOPRAP.Name = "txtLRSOPRAP"
        Me.txtLRSOPRAP.Size = New System.Drawing.Size(164, 20)
        Me.txtLRSOPRAP.TabIndex = 4
        '
        'txtLRSONUDO
        '
        Me.txtLRSONUDO.AccessibleDescription = "Nro. Documento"
        Me.txtLRSONUDO.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRSONUDO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRSONUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRSONUDO.ForeColor = System.Drawing.Color.Black
        Me.txtLRSONUDO.Location = New System.Drawing.Point(137, 26)
        Me.txtLRSONUDO.MaxLength = 14
        Me.txtLRSONUDO.Name = "txtLRSONUDO"
        Me.txtLRSONUDO.Size = New System.Drawing.Size(171, 20)
        Me.txtLRSONUDO.TabIndex = 1
        '
        'txtLRSONOMB
        '
        Me.txtLRSONOMB.AccessibleDescription = "Nombre"
        Me.txtLRSONOMB.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRSONOMB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRSONOMB.ForeColor = System.Drawing.Color.Black
        Me.txtLRSONOMB.Location = New System.Drawing.Point(137, 49)
        Me.txtLRSONOMB.MaxLength = 50
        Me.txtLRSONOMB.Name = "txtLRSONOMB"
        Me.txtLRSONOMB.Size = New System.Drawing.Size(171, 20)
        Me.txtLRSONOMB.TabIndex = 3
        '
        'lblNumeroDocumento
        '
        Me.lblNumeroDocumento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblNumeroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumeroDocumento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroDocumento.ForeColor = System.Drawing.Color.Black
        Me.lblNumeroDocumento.Location = New System.Drawing.Point(17, 26)
        Me.lblNumeroDocumento.Name = "lblNumeroDocumento"
        Me.lblNumeroDocumento.Size = New System.Drawing.Size(116, 20)
        Me.lblNumeroDocumento.TabIndex = 56
        Me.lblNumeroDocumento.Text = "Nro. Documento"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(17, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 20)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Nombre (S)"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(312, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 20)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "Primer Apellido"
        '
        'lblDireccion
        '
        Me.lblDireccion.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblDireccion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDireccion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccion.ForeColor = System.Drawing.Color.Black
        Me.lblDireccion.Location = New System.Drawing.Point(17, 72)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(116, 20)
        Me.lblDireccion.TabIndex = 66
        Me.lblDireccion.Text = "Dirección de predio"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(600, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 20)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "Segundo Apellido"
        '
        'frm_insertar_LIRASOLI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 288)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraINFOUSUA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(946, 324)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(946, 324)
        Me.Name = "frm_insertar_LIRASOLI"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox4.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraINFOUSUA.ResumeLayout(False)
        Me.fraINFOUSUA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraINFOUSUA As System.Windows.Forms.GroupBox
    Friend WithEvents txtLRSOCOEL As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLRSODINO As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLRSODIPR As System.Windows.Forms.TextBox
    Friend WithEvents txtLRSOSEAP As System.Windows.Forms.TextBox
    Friend WithEvents txtLRSOPRAP As System.Windows.Forms.TextBox
    Friend WithEvents txtLRSONUDO As System.Windows.Forms.TextBox
    Friend WithEvents txtLRSONOMB As System.Windows.Forms.TextBox
    Friend WithEvents txtLRSOCELU As System.Windows.Forms.TextBox
    Friend WithEvents txtLRSOTELE As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTelefonos As System.Windows.Forms.Label
    Friend WithEvents txtLRSORESO As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLRSOCOPO As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblLRSOSOLI As System.Windows.Forms.Label
    Friend WithEvents cboLRSOSOLI As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
