<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_CEESSOLI
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboCESOESTA = New System.Windows.Forms.ComboBox()
        Me.lblCESOSOLI = New System.Windows.Forms.Label()
        Me.cboCESOSOLI = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCESORESO = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCESOCOPO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCESOCOEL = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCESODINO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCESODIPR = New System.Windows.Forms.TextBox()
        Me.lblTelefonos = New System.Windows.Forms.Label()
        Me.txtCESOTELE = New System.Windows.Forms.TextBox()
        Me.txtCESOSEAP = New System.Windows.Forms.TextBox()
        Me.txtCESOCELU = New System.Windows.Forms.TextBox()
        Me.txtCESOPRAP = New System.Windows.Forms.TextBox()
        Me.txtCESONUDO = New System.Windows.Forms.TextBox()
        Me.txtCESONOMB = New System.Windows.Forms.TextBox()
        Me.lblNumeroDocumento = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCESOPROY = New System.Windows.Forms.TextBox()
        Me.GroupBox4.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraINFOUSUA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdSALIR)
        Me.GroupBox4.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 221)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(906, 49)
        Me.GroupBox4.TabIndex = 359
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 288)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(930, 25)
        Me.strBARRESTA.TabIndex = 360
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
        Me.fraINFOUSUA.Controls.Add(Me.txtCESOPROY)
        Me.fraINFOUSUA.Controls.Add(Me.Label10)
        Me.fraINFOUSUA.Controls.Add(Me.Label9)
        Me.fraINFOUSUA.Controls.Add(Me.cboCESOESTA)
        Me.fraINFOUSUA.Controls.Add(Me.lblCESOSOLI)
        Me.fraINFOUSUA.Controls.Add(Me.cboCESOSOLI)
        Me.fraINFOUSUA.Controls.Add(Me.Label8)
        Me.fraINFOUSUA.Controls.Add(Me.txtCESORESO)
        Me.fraINFOUSUA.Controls.Add(Me.Label7)
        Me.fraINFOUSUA.Controls.Add(Me.txtCESOCOPO)
        Me.fraINFOUSUA.Controls.Add(Me.Label2)
        Me.fraINFOUSUA.Controls.Add(Me.txtCESOCOEL)
        Me.fraINFOUSUA.Controls.Add(Me.Label3)
        Me.fraINFOUSUA.Controls.Add(Me.txtCESODINO)
        Me.fraINFOUSUA.Controls.Add(Me.Label1)
        Me.fraINFOUSUA.Controls.Add(Me.txtCESODIPR)
        Me.fraINFOUSUA.Controls.Add(Me.lblTelefonos)
        Me.fraINFOUSUA.Controls.Add(Me.txtCESOTELE)
        Me.fraINFOUSUA.Controls.Add(Me.txtCESOSEAP)
        Me.fraINFOUSUA.Controls.Add(Me.txtCESOCELU)
        Me.fraINFOUSUA.Controls.Add(Me.txtCESOPRAP)
        Me.fraINFOUSUA.Controls.Add(Me.txtCESONUDO)
        Me.fraINFOUSUA.Controls.Add(Me.txtCESONOMB)
        Me.fraINFOUSUA.Controls.Add(Me.lblNumeroDocumento)
        Me.fraINFOUSUA.Controls.Add(Me.Label4)
        Me.fraINFOUSUA.Controls.Add(Me.Label5)
        Me.fraINFOUSUA.Controls.Add(Me.lblDireccion)
        Me.fraINFOUSUA.Controls.Add(Me.Label6)
        Me.fraINFOUSUA.Location = New System.Drawing.Point(12, 11)
        Me.fraINFOUSUA.Name = "fraINFOUSUA"
        Me.fraINFOUSUA.Size = New System.Drawing.Size(906, 204)
        Me.fraINFOUSUA.TabIndex = 358
        Me.fraINFOUSUA.TabStop = False
        Me.fraINFOUSUA.Text = "INSERTAR SOLICITANTE"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(600, 164)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 20)
        Me.Label9.TabIndex = 485
        Me.Label9.Text = "Estado"
        '
        'cboCESOESTA
        '
        Me.cboCESOESTA.AccessibleDescription = "Estado"
        Me.cboCESOESTA.BackColor = System.Drawing.Color.White
        Me.cboCESOESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCESOESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCESOESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCESOESTA.Location = New System.Drawing.Point(719, 164)
        Me.cboCESOESTA.MaxDropDownItems = 15
        Me.cboCESOESTA.MaxLength = 1
        Me.cboCESOESTA.Name = "cboCESOESTA"
        Me.cboCESOESTA.Size = New System.Drawing.Size(172, 22)
        Me.cboCESOESTA.TabIndex = 14
        '
        'lblCESOSOLI
        '
        Me.lblCESOSOLI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCESOSOLI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCESOSOLI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCESOSOLI.ForeColor = System.Drawing.Color.Black
        Me.lblCESOSOLI.Location = New System.Drawing.Point(719, 26)
        Me.lblCESOSOLI.Name = "lblCESOSOLI"
        Me.lblCESOSOLI.Size = New System.Drawing.Size(172, 20)
        Me.lblCESOSOLI.TabIndex = 484
        '
        'cboCESOSOLI
        '
        Me.cboCESOSOLI.AccessibleDescription = "Solicitante"
        Me.cboCESOSOLI.BackColor = System.Drawing.Color.White
        Me.cboCESOSOLI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCESOSOLI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCESOSOLI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCESOSOLI.Location = New System.Drawing.Point(432, 24)
        Me.cboCESOSOLI.MaxDropDownItems = 15
        Me.cboCESOSOLI.MaxLength = 1
        Me.cboCESOSOLI.Name = "cboCESOSOLI"
        Me.cboCESOSOLI.Size = New System.Drawing.Size(284, 22)
        Me.cboCESOSOLI.TabIndex = 2
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
        'txtCESORESO
        '
        Me.txtCESORESO.AccessibleDescription = "Redes sociales"
        Me.txtCESORESO.BackColor = System.Drawing.SystemColors.Window
        Me.txtCESORESO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCESORESO.ForeColor = System.Drawing.Color.Black
        Me.txtCESORESO.Location = New System.Drawing.Point(137, 164)
        Me.txtCESORESO.MaxLength = 50
        Me.txtCESORESO.Name = "txtCESORESO"
        Me.txtCESORESO.Size = New System.Drawing.Size(459, 20)
        Me.txtCESORESO.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(17, 164)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 20)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "Redes sociales"
        '
        'txtCESOCOPO
        '
        Me.txtCESOCOPO.AccessibleDescription = "Código postal"
        Me.txtCESOCOPO.BackColor = System.Drawing.SystemColors.Window
        Me.txtCESOCOPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCESOCOPO.ForeColor = System.Drawing.Color.Black
        Me.txtCESOCOPO.Location = New System.Drawing.Point(137, 141)
        Me.txtCESOCOPO.MaxLength = 50
        Me.txtCESOCOPO.Name = "txtCESOCOPO"
        Me.txtCESOCOPO.Size = New System.Drawing.Size(171, 20)
        Me.txtCESOCOPO.TabIndex = 11
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
        'txtCESOCOEL
        '
        Me.txtCESOCOEL.AccessibleDescription = "Correo electronico"
        Me.txtCESOCOEL.BackColor = System.Drawing.SystemColors.Window
        Me.txtCESOCOEL.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtCESOCOEL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCESOCOEL.ForeColor = System.Drawing.Color.Black
        Me.txtCESOCOEL.Location = New System.Drawing.Point(432, 118)
        Me.txtCESOCOEL.MaxLength = 50
        Me.txtCESOCOEL.Name = "txtCESOCOEL"
        Me.txtCESOCOEL.Size = New System.Drawing.Size(459, 20)
        Me.txtCESOCOEL.TabIndex = 10
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
        'txtCESODINO
        '
        Me.txtCESODINO.AccessibleDescription = "Dirección"
        Me.txtCESODINO.BackColor = System.Drawing.SystemColors.Window
        Me.txtCESODINO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCESODINO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCESODINO.ForeColor = System.Drawing.Color.Black
        Me.txtCESODINO.Location = New System.Drawing.Point(137, 95)
        Me.txtCESODINO.MaxLength = 100
        Me.txtCESODINO.Name = "txtCESODINO"
        Me.txtCESODINO.Size = New System.Drawing.Size(754, 20)
        Me.txtCESODINO.TabIndex = 7
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
        'txtCESODIPR
        '
        Me.txtCESODIPR.AccessibleDescription = "Dirección"
        Me.txtCESODIPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtCESODIPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCESODIPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCESODIPR.ForeColor = System.Drawing.Color.Black
        Me.txtCESODIPR.Location = New System.Drawing.Point(137, 72)
        Me.txtCESODIPR.MaxLength = 100
        Me.txtCESODIPR.Name = "txtCESODIPR"
        Me.txtCESODIPR.Size = New System.Drawing.Size(754, 20)
        Me.txtCESODIPR.TabIndex = 6
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
        'txtCESOTELE
        '
        Me.txtCESOTELE.AccessibleDescription = "Telefono 1 "
        Me.txtCESOTELE.BackColor = System.Drawing.SystemColors.Window
        Me.txtCESOTELE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCESOTELE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCESOTELE.ForeColor = System.Drawing.Color.Black
        Me.txtCESOTELE.Location = New System.Drawing.Point(136, 118)
        Me.txtCESOTELE.MaxLength = 20
        Me.txtCESOTELE.Name = "txtCESOTELE"
        Me.txtCESOTELE.Size = New System.Drawing.Size(85, 20)
        Me.txtCESOTELE.TabIndex = 8
        '
        'txtCESOSEAP
        '
        Me.txtCESOSEAP.AccessibleDescription = "Segundo apellido"
        Me.txtCESOSEAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtCESOSEAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCESOSEAP.ForeColor = System.Drawing.Color.Black
        Me.txtCESOSEAP.Location = New System.Drawing.Point(719, 48)
        Me.txtCESOSEAP.MaxLength = 50
        Me.txtCESOSEAP.Name = "txtCESOSEAP"
        Me.txtCESOSEAP.Size = New System.Drawing.Size(172, 20)
        Me.txtCESOSEAP.TabIndex = 5
        '
        'txtCESOCELU
        '
        Me.txtCESOCELU.AccessibleDescription = "Telefono 2 "
        Me.txtCESOCELU.BackColor = System.Drawing.SystemColors.Window
        Me.txtCESOCELU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCESOCELU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCESOCELU.ForeColor = System.Drawing.Color.Black
        Me.txtCESOCELU.Location = New System.Drawing.Point(224, 118)
        Me.txtCESOCELU.MaxLength = 20
        Me.txtCESOCELU.Name = "txtCESOCELU"
        Me.txtCESOCELU.Size = New System.Drawing.Size(84, 20)
        Me.txtCESOCELU.TabIndex = 9
        '
        'txtCESOPRAP
        '
        Me.txtCESOPRAP.AccessibleDescription = "Primer apellido"
        Me.txtCESOPRAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtCESOPRAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCESOPRAP.ForeColor = System.Drawing.Color.Black
        Me.txtCESOPRAP.Location = New System.Drawing.Point(432, 49)
        Me.txtCESOPRAP.MaxLength = 50
        Me.txtCESOPRAP.Name = "txtCESOPRAP"
        Me.txtCESOPRAP.Size = New System.Drawing.Size(164, 20)
        Me.txtCESOPRAP.TabIndex = 4
        '
        'txtCESONUDO
        '
        Me.txtCESONUDO.AccessibleDescription = "Nro. Documento"
        Me.txtCESONUDO.BackColor = System.Drawing.SystemColors.Window
        Me.txtCESONUDO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCESONUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCESONUDO.ForeColor = System.Drawing.Color.Black
        Me.txtCESONUDO.Location = New System.Drawing.Point(137, 26)
        Me.txtCESONUDO.MaxLength = 14
        Me.txtCESONUDO.Name = "txtCESONUDO"
        Me.txtCESONUDO.Size = New System.Drawing.Size(171, 20)
        Me.txtCESONUDO.TabIndex = 1
        '
        'txtCESONOMB
        '
        Me.txtCESONOMB.AccessibleDescription = "Nombre"
        Me.txtCESONOMB.BackColor = System.Drawing.SystemColors.Window
        Me.txtCESONOMB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCESONOMB.ForeColor = System.Drawing.Color.Black
        Me.txtCESONOMB.Location = New System.Drawing.Point(137, 49)
        Me.txtCESONOMB.MaxLength = 50
        Me.txtCESONOMB.Name = "txtCESONOMB"
        Me.txtCESONOMB.Size = New System.Drawing.Size(171, 20)
        Me.txtCESONOMB.TabIndex = 3
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
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(312, 141)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 20)
        Me.Label10.TabIndex = 486
        Me.Label10.Text = "Proyecto"
        '
        'txtCESOPROY
        '
        Me.txtCESOPROY.AccessibleDescription = "Proyecto"
        Me.txtCESOPROY.BackColor = System.Drawing.SystemColors.Window
        Me.txtCESOPROY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCESOPROY.ForeColor = System.Drawing.Color.Black
        Me.txtCESOPROY.Location = New System.Drawing.Point(432, 141)
        Me.txtCESOPROY.MaxLength = 50
        Me.txtCESOPROY.Name = "txtCESOPROY"
        Me.txtCESOPROY.Size = New System.Drawing.Size(459, 20)
        Me.txtCESOPROY.TabIndex = 12
        '
        'frm_insertar_CEESSOLI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 313)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraINFOUSUA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(946, 349)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(946, 349)
        Me.Name = "frm_insertar_CEESSOLI"
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
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboCESOESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCESOSOLI As System.Windows.Forms.Label
    Friend WithEvents cboCESOSOLI As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCESORESO As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCESOCOPO As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCESOCOEL As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCESODINO As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCESODIPR As System.Windows.Forms.TextBox
    Friend WithEvents lblTelefonos As System.Windows.Forms.Label
    Friend WithEvents txtCESOTELE As System.Windows.Forms.TextBox
    Friend WithEvents txtCESOSEAP As System.Windows.Forms.TextBox
    Friend WithEvents txtCESOCELU As System.Windows.Forms.TextBox
    Friend WithEvents txtCESOPRAP As System.Windows.Forms.TextBox
    Friend WithEvents txtCESONUDO As System.Windows.Forms.TextBox
    Friend WithEvents txtCESONOMB As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCESOPROY As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
