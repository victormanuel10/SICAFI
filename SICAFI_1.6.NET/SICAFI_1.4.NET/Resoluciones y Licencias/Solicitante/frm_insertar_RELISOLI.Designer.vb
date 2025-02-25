<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_RELISOLI
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
        Me.lblRLSOSOLI = New System.Windows.Forms.Label()
        Me.cboRLSOSOLI = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRLSORESO = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRLSOCOPO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRLSOCOEL = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRLSODINO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRLSODIPR = New System.Windows.Forms.TextBox()
        Me.lblTelefonos = New System.Windows.Forms.Label()
        Me.txtRLSOTELE = New System.Windows.Forms.TextBox()
        Me.txtRLSOSEAP = New System.Windows.Forms.TextBox()
        Me.txtRLSOCELU = New System.Windows.Forms.TextBox()
        Me.txtRLSOPRAP = New System.Windows.Forms.TextBox()
        Me.txtRLSONUDO = New System.Windows.Forms.TextBox()
        Me.txtRLSONOMB = New System.Windows.Forms.TextBox()
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
        Me.GroupBox4.Location = New System.Drawing.Point(12, 193)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(906, 49)
        Me.GroupBox4.TabIndex = 353
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
        Me.strBARRESTA.TabIndex = 354
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
        Me.fraINFOUSUA.Controls.Add(Me.lblRLSOSOLI)
        Me.fraINFOUSUA.Controls.Add(Me.cboRLSOSOLI)
        Me.fraINFOUSUA.Controls.Add(Me.Label8)
        Me.fraINFOUSUA.Controls.Add(Me.txtRLSORESO)
        Me.fraINFOUSUA.Controls.Add(Me.Label7)
        Me.fraINFOUSUA.Controls.Add(Me.txtRLSOCOPO)
        Me.fraINFOUSUA.Controls.Add(Me.Label2)
        Me.fraINFOUSUA.Controls.Add(Me.txtRLSOCOEL)
        Me.fraINFOUSUA.Controls.Add(Me.Label3)
        Me.fraINFOUSUA.Controls.Add(Me.txtRLSODINO)
        Me.fraINFOUSUA.Controls.Add(Me.Label1)
        Me.fraINFOUSUA.Controls.Add(Me.txtRLSODIPR)
        Me.fraINFOUSUA.Controls.Add(Me.lblTelefonos)
        Me.fraINFOUSUA.Controls.Add(Me.txtRLSOTELE)
        Me.fraINFOUSUA.Controls.Add(Me.txtRLSOSEAP)
        Me.fraINFOUSUA.Controls.Add(Me.txtRLSOCELU)
        Me.fraINFOUSUA.Controls.Add(Me.txtRLSOPRAP)
        Me.fraINFOUSUA.Controls.Add(Me.txtRLSONUDO)
        Me.fraINFOUSUA.Controls.Add(Me.txtRLSONOMB)
        Me.fraINFOUSUA.Controls.Add(Me.lblNumeroDocumento)
        Me.fraINFOUSUA.Controls.Add(Me.Label4)
        Me.fraINFOUSUA.Controls.Add(Me.Label5)
        Me.fraINFOUSUA.Controls.Add(Me.lblDireccion)
        Me.fraINFOUSUA.Controls.Add(Me.Label6)
        Me.fraINFOUSUA.Location = New System.Drawing.Point(12, 8)
        Me.fraINFOUSUA.Name = "fraINFOUSUA"
        Me.fraINFOUSUA.Size = New System.Drawing.Size(906, 179)
        Me.fraINFOUSUA.TabIndex = 352
        Me.fraINFOUSUA.TabStop = False
        Me.fraINFOUSUA.Text = "INSERTAR SOLICITANTE"
        '
        'lblRLSOSOLI
        '
        Me.lblRLSOSOLI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRLSOSOLI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRLSOSOLI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRLSOSOLI.ForeColor = System.Drawing.Color.Black
        Me.lblRLSOSOLI.Location = New System.Drawing.Point(719, 26)
        Me.lblRLSOSOLI.Name = "lblRLSOSOLI"
        Me.lblRLSOSOLI.Size = New System.Drawing.Size(172, 20)
        Me.lblRLSOSOLI.TabIndex = 484
        '
        'cboRLSOSOLI
        '
        Me.cboRLSOSOLI.AccessibleDescription = "Solicitante"
        Me.cboRLSOSOLI.BackColor = System.Drawing.Color.White
        Me.cboRLSOSOLI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRLSOSOLI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRLSOSOLI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRLSOSOLI.Location = New System.Drawing.Point(432, 24)
        Me.cboRLSOSOLI.MaxDropDownItems = 15
        Me.cboRLSOSOLI.MaxLength = 1
        Me.cboRLSOSOLI.Name = "cboRLSOSOLI"
        Me.cboRLSOSOLI.Size = New System.Drawing.Size(284, 22)
        Me.cboRLSOSOLI.TabIndex = 2
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
        'txtRLSORESO
        '
        Me.txtRLSORESO.AccessibleDescription = "Redes sociales"
        Me.txtRLSORESO.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLSORESO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLSORESO.ForeColor = System.Drawing.Color.Black
        Me.txtRLSORESO.Location = New System.Drawing.Point(552, 141)
        Me.txtRLSORESO.MaxLength = 50
        Me.txtRLSORESO.Name = "txtRLSORESO"
        Me.txtRLSORESO.Size = New System.Drawing.Size(339, 20)
        Me.txtRLSORESO.TabIndex = 12
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
        'txtRLSOCOPO
        '
        Me.txtRLSOCOPO.AccessibleDescription = "Código postal"
        Me.txtRLSOCOPO.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLSOCOPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLSOCOPO.ForeColor = System.Drawing.Color.Black
        Me.txtRLSOCOPO.Location = New System.Drawing.Point(137, 141)
        Me.txtRLSOCOPO.MaxLength = 50
        Me.txtRLSOCOPO.Name = "txtRLSOCOPO"
        Me.txtRLSOCOPO.Size = New System.Drawing.Size(291, 20)
        Me.txtRLSOCOPO.TabIndex = 11
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
        'txtRLSOCOEL
        '
        Me.txtRLSOCOEL.AccessibleDescription = "Correo electronico"
        Me.txtRLSOCOEL.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLSOCOEL.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtRLSOCOEL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLSOCOEL.ForeColor = System.Drawing.Color.Black
        Me.txtRLSOCOEL.Location = New System.Drawing.Point(432, 118)
        Me.txtRLSOCOEL.MaxLength = 50
        Me.txtRLSOCOEL.Name = "txtRLSOCOEL"
        Me.txtRLSOCOEL.Size = New System.Drawing.Size(459, 20)
        Me.txtRLSOCOEL.TabIndex = 10
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
        'txtRLSODINO
        '
        Me.txtRLSODINO.AccessibleDescription = "Dirección"
        Me.txtRLSODINO.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLSODINO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLSODINO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLSODINO.ForeColor = System.Drawing.Color.Black
        Me.txtRLSODINO.Location = New System.Drawing.Point(137, 95)
        Me.txtRLSODINO.MaxLength = 100
        Me.txtRLSODINO.Name = "txtRLSODINO"
        Me.txtRLSODINO.Size = New System.Drawing.Size(754, 20)
        Me.txtRLSODINO.TabIndex = 7
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
        'txtRLSODIPR
        '
        Me.txtRLSODIPR.AccessibleDescription = "Dirección"
        Me.txtRLSODIPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLSODIPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLSODIPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLSODIPR.ForeColor = System.Drawing.Color.Black
        Me.txtRLSODIPR.Location = New System.Drawing.Point(137, 72)
        Me.txtRLSODIPR.MaxLength = 100
        Me.txtRLSODIPR.Name = "txtRLSODIPR"
        Me.txtRLSODIPR.Size = New System.Drawing.Size(754, 20)
        Me.txtRLSODIPR.TabIndex = 6
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
        'txtRLSOTELE
        '
        Me.txtRLSOTELE.AccessibleDescription = "Telefono 1 "
        Me.txtRLSOTELE.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLSOTELE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLSOTELE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLSOTELE.ForeColor = System.Drawing.Color.Black
        Me.txtRLSOTELE.Location = New System.Drawing.Point(136, 118)
        Me.txtRLSOTELE.MaxLength = 20
        Me.txtRLSOTELE.Name = "txtRLSOTELE"
        Me.txtRLSOTELE.Size = New System.Drawing.Size(85, 20)
        Me.txtRLSOTELE.TabIndex = 8
        '
        'txtRLSOSEAP
        '
        Me.txtRLSOSEAP.AccessibleDescription = "Segundo apellido"
        Me.txtRLSOSEAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLSOSEAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLSOSEAP.ForeColor = System.Drawing.Color.Black
        Me.txtRLSOSEAP.Location = New System.Drawing.Point(719, 48)
        Me.txtRLSOSEAP.MaxLength = 50
        Me.txtRLSOSEAP.Name = "txtRLSOSEAP"
        Me.txtRLSOSEAP.Size = New System.Drawing.Size(172, 20)
        Me.txtRLSOSEAP.TabIndex = 5
        '
        'txtRLSOCELU
        '
        Me.txtRLSOCELU.AccessibleDescription = "Telefono 2 "
        Me.txtRLSOCELU.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLSOCELU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLSOCELU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLSOCELU.ForeColor = System.Drawing.Color.Black
        Me.txtRLSOCELU.Location = New System.Drawing.Point(224, 118)
        Me.txtRLSOCELU.MaxLength = 20
        Me.txtRLSOCELU.Name = "txtRLSOCELU"
        Me.txtRLSOCELU.Size = New System.Drawing.Size(84, 20)
        Me.txtRLSOCELU.TabIndex = 9
        '
        'txtRLSOPRAP
        '
        Me.txtRLSOPRAP.AccessibleDescription = "Primer apellido"
        Me.txtRLSOPRAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLSOPRAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLSOPRAP.ForeColor = System.Drawing.Color.Black
        Me.txtRLSOPRAP.Location = New System.Drawing.Point(432, 49)
        Me.txtRLSOPRAP.MaxLength = 50
        Me.txtRLSOPRAP.Name = "txtRLSOPRAP"
        Me.txtRLSOPRAP.Size = New System.Drawing.Size(164, 20)
        Me.txtRLSOPRAP.TabIndex = 4
        '
        'txtRLSONUDO
        '
        Me.txtRLSONUDO.AccessibleDescription = "Nro. Documento"
        Me.txtRLSONUDO.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLSONUDO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLSONUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLSONUDO.ForeColor = System.Drawing.Color.Black
        Me.txtRLSONUDO.Location = New System.Drawing.Point(137, 26)
        Me.txtRLSONUDO.MaxLength = 14
        Me.txtRLSONUDO.Name = "txtRLSONUDO"
        Me.txtRLSONUDO.Size = New System.Drawing.Size(171, 20)
        Me.txtRLSONUDO.TabIndex = 1
        '
        'txtRLSONOMB
        '
        Me.txtRLSONOMB.AccessibleDescription = "Nombre"
        Me.txtRLSONOMB.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLSONOMB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLSONOMB.ForeColor = System.Drawing.Color.Black
        Me.txtRLSONOMB.Location = New System.Drawing.Point(137, 49)
        Me.txtRLSONOMB.MaxLength = 50
        Me.txtRLSONOMB.Name = "txtRLSONOMB"
        Me.txtRLSONOMB.Size = New System.Drawing.Size(171, 20)
        Me.txtRLSONOMB.TabIndex = 3
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
        'frm_insertar_RELISOLI
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
        Me.Name = "frm_insertar_RELISOLI"
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
    Friend WithEvents lblRLSOSOLI As System.Windows.Forms.Label
    Friend WithEvents cboRLSOSOLI As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRLSORESO As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRLSOCOPO As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRLSOCOEL As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRLSODINO As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRLSODIPR As System.Windows.Forms.TextBox
    Friend WithEvents lblTelefonos As System.Windows.Forms.Label
    Friend WithEvents txtRLSOTELE As System.Windows.Forms.TextBox
    Friend WithEvents txtRLSOSEAP As System.Windows.Forms.TextBox
    Friend WithEvents txtRLSOCELU As System.Windows.Forms.TextBox
    Friend WithEvents txtRLSOPRAP As System.Windows.Forms.TextBox
    Friend WithEvents txtRLSONUDO As System.Windows.Forms.TextBox
    Friend WithEvents txtRLSONOMB As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
