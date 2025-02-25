<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_OBURSOLI
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
        Me.cboOUSOESTA = New System.Windows.Forms.ComboBox()
        Me.lblOUSOSOLI = New System.Windows.Forms.Label()
        Me.cboOUSOSOLI = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtOUSORESO = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtOUSOCOPO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOUSOCOEL = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtOUSODINO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOUSODIPR = New System.Windows.Forms.TextBox()
        Me.lblTelefonos = New System.Windows.Forms.Label()
        Me.txtOUSOTELE = New System.Windows.Forms.TextBox()
        Me.txtOUSOSEAP = New System.Windows.Forms.TextBox()
        Me.txtOUSOCELU = New System.Windows.Forms.TextBox()
        Me.txtOUSOPRAP = New System.Windows.Forms.TextBox()
        Me.txtOUSONUDO = New System.Windows.Forms.TextBox()
        Me.txtOUSONOMB = New System.Windows.Forms.TextBox()
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
        Me.GroupBox4.Location = New System.Drawing.Point(12, 222)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(906, 49)
        Me.GroupBox4.TabIndex = 356
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
        Me.strBARRESTA.TabIndex = 357
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
        Me.fraINFOUSUA.Controls.Add(Me.Label9)
        Me.fraINFOUSUA.Controls.Add(Me.cboOUSOESTA)
        Me.fraINFOUSUA.Controls.Add(Me.lblOUSOSOLI)
        Me.fraINFOUSUA.Controls.Add(Me.cboOUSOSOLI)
        Me.fraINFOUSUA.Controls.Add(Me.Label8)
        Me.fraINFOUSUA.Controls.Add(Me.txtOUSORESO)
        Me.fraINFOUSUA.Controls.Add(Me.Label7)
        Me.fraINFOUSUA.Controls.Add(Me.txtOUSOCOPO)
        Me.fraINFOUSUA.Controls.Add(Me.Label2)
        Me.fraINFOUSUA.Controls.Add(Me.txtOUSOCOEL)
        Me.fraINFOUSUA.Controls.Add(Me.Label3)
        Me.fraINFOUSUA.Controls.Add(Me.txtOUSODINO)
        Me.fraINFOUSUA.Controls.Add(Me.Label1)
        Me.fraINFOUSUA.Controls.Add(Me.txtOUSODIPR)
        Me.fraINFOUSUA.Controls.Add(Me.lblTelefonos)
        Me.fraINFOUSUA.Controls.Add(Me.txtOUSOTELE)
        Me.fraINFOUSUA.Controls.Add(Me.txtOUSOSEAP)
        Me.fraINFOUSUA.Controls.Add(Me.txtOUSOCELU)
        Me.fraINFOUSUA.Controls.Add(Me.txtOUSOPRAP)
        Me.fraINFOUSUA.Controls.Add(Me.txtOUSONUDO)
        Me.fraINFOUSUA.Controls.Add(Me.txtOUSONOMB)
        Me.fraINFOUSUA.Controls.Add(Me.lblNumeroDocumento)
        Me.fraINFOUSUA.Controls.Add(Me.Label4)
        Me.fraINFOUSUA.Controls.Add(Me.Label5)
        Me.fraINFOUSUA.Controls.Add(Me.lblDireccion)
        Me.fraINFOUSUA.Controls.Add(Me.Label6)
        Me.fraINFOUSUA.Location = New System.Drawing.Point(12, 12)
        Me.fraINFOUSUA.Name = "fraINFOUSUA"
        Me.fraINFOUSUA.Size = New System.Drawing.Size(906, 204)
        Me.fraINFOUSUA.TabIndex = 355
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
        'cboOUSOESTA
        '
        Me.cboOUSOESTA.AccessibleDescription = "Estado"
        Me.cboOUSOESTA.BackColor = System.Drawing.Color.White
        Me.cboOUSOESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUSOESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUSOESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUSOESTA.Location = New System.Drawing.Point(719, 164)
        Me.cboOUSOESTA.MaxDropDownItems = 15
        Me.cboOUSOESTA.MaxLength = 1
        Me.cboOUSOESTA.Name = "cboOUSOESTA"
        Me.cboOUSOESTA.Size = New System.Drawing.Size(172, 22)
        Me.cboOUSOESTA.TabIndex = 13
        '
        'lblOUSOSOLI
        '
        Me.lblOUSOSOLI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblOUSOSOLI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOUSOSOLI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOUSOSOLI.ForeColor = System.Drawing.Color.Black
        Me.lblOUSOSOLI.Location = New System.Drawing.Point(719, 26)
        Me.lblOUSOSOLI.Name = "lblOUSOSOLI"
        Me.lblOUSOSOLI.Size = New System.Drawing.Size(172, 20)
        Me.lblOUSOSOLI.TabIndex = 484
        '
        'cboOUSOSOLI
        '
        Me.cboOUSOSOLI.AccessibleDescription = "Solicitante"
        Me.cboOUSOSOLI.BackColor = System.Drawing.Color.White
        Me.cboOUSOSOLI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUSOSOLI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUSOSOLI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUSOSOLI.Location = New System.Drawing.Point(432, 24)
        Me.cboOUSOSOLI.MaxDropDownItems = 15
        Me.cboOUSOSOLI.MaxLength = 1
        Me.cboOUSOSOLI.Name = "cboOUSOSOLI"
        Me.cboOUSOSOLI.Size = New System.Drawing.Size(284, 22)
        Me.cboOUSOSOLI.TabIndex = 2
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
        'txtOUSORESO
        '
        Me.txtOUSORESO.AccessibleDescription = "Redes sociales"
        Me.txtOUSORESO.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUSORESO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUSORESO.ForeColor = System.Drawing.Color.Black
        Me.txtOUSORESO.Location = New System.Drawing.Point(137, 164)
        Me.txtOUSORESO.MaxLength = 50
        Me.txtOUSORESO.Name = "txtOUSORESO"
        Me.txtOUSORESO.Size = New System.Drawing.Size(459, 20)
        Me.txtOUSORESO.TabIndex = 12
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
        'txtOUSOCOPO
        '
        Me.txtOUSOCOPO.AccessibleDescription = "Código postal"
        Me.txtOUSOCOPO.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUSOCOPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUSOCOPO.ForeColor = System.Drawing.Color.Black
        Me.txtOUSOCOPO.Location = New System.Drawing.Point(137, 141)
        Me.txtOUSOCOPO.MaxLength = 50
        Me.txtOUSOCOPO.Name = "txtOUSOCOPO"
        Me.txtOUSOCOPO.Size = New System.Drawing.Size(754, 20)
        Me.txtOUSOCOPO.TabIndex = 11
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
        Me.Label2.Text = "Nombre del proyecto"
        '
        'txtOUSOCOEL
        '
        Me.txtOUSOCOEL.AccessibleDescription = "Correo electronico"
        Me.txtOUSOCOEL.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUSOCOEL.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtOUSOCOEL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUSOCOEL.ForeColor = System.Drawing.Color.Black
        Me.txtOUSOCOEL.Location = New System.Drawing.Point(432, 118)
        Me.txtOUSOCOEL.MaxLength = 50
        Me.txtOUSOCOEL.Name = "txtOUSOCOEL"
        Me.txtOUSOCOEL.Size = New System.Drawing.Size(459, 20)
        Me.txtOUSOCOEL.TabIndex = 10
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
        'txtOUSODINO
        '
        Me.txtOUSODINO.AccessibleDescription = "Dirección"
        Me.txtOUSODINO.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUSODINO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUSODINO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUSODINO.ForeColor = System.Drawing.Color.Black
        Me.txtOUSODINO.Location = New System.Drawing.Point(137, 95)
        Me.txtOUSODINO.MaxLength = 100
        Me.txtOUSODINO.Name = "txtOUSODINO"
        Me.txtOUSODINO.Size = New System.Drawing.Size(754, 20)
        Me.txtOUSODINO.TabIndex = 7
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
        'txtOUSODIPR
        '
        Me.txtOUSODIPR.AccessibleDescription = "Dirección"
        Me.txtOUSODIPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUSODIPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUSODIPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUSODIPR.ForeColor = System.Drawing.Color.Black
        Me.txtOUSODIPR.Location = New System.Drawing.Point(137, 72)
        Me.txtOUSODIPR.MaxLength = 100
        Me.txtOUSODIPR.Name = "txtOUSODIPR"
        Me.txtOUSODIPR.Size = New System.Drawing.Size(754, 20)
        Me.txtOUSODIPR.TabIndex = 6
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
        'txtOUSOTELE
        '
        Me.txtOUSOTELE.AccessibleDescription = "Telefono 1 "
        Me.txtOUSOTELE.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUSOTELE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUSOTELE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUSOTELE.ForeColor = System.Drawing.Color.Black
        Me.txtOUSOTELE.Location = New System.Drawing.Point(136, 118)
        Me.txtOUSOTELE.MaxLength = 20
        Me.txtOUSOTELE.Name = "txtOUSOTELE"
        Me.txtOUSOTELE.Size = New System.Drawing.Size(85, 20)
        Me.txtOUSOTELE.TabIndex = 8
        '
        'txtOUSOSEAP
        '
        Me.txtOUSOSEAP.AccessibleDescription = "Segundo apellido"
        Me.txtOUSOSEAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUSOSEAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUSOSEAP.ForeColor = System.Drawing.Color.Black
        Me.txtOUSOSEAP.Location = New System.Drawing.Point(719, 48)
        Me.txtOUSOSEAP.MaxLength = 50
        Me.txtOUSOSEAP.Name = "txtOUSOSEAP"
        Me.txtOUSOSEAP.Size = New System.Drawing.Size(172, 20)
        Me.txtOUSOSEAP.TabIndex = 5
        '
        'txtOUSOCELU
        '
        Me.txtOUSOCELU.AccessibleDescription = "Telefono 2 "
        Me.txtOUSOCELU.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUSOCELU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUSOCELU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUSOCELU.ForeColor = System.Drawing.Color.Black
        Me.txtOUSOCELU.Location = New System.Drawing.Point(224, 118)
        Me.txtOUSOCELU.MaxLength = 20
        Me.txtOUSOCELU.Name = "txtOUSOCELU"
        Me.txtOUSOCELU.Size = New System.Drawing.Size(84, 20)
        Me.txtOUSOCELU.TabIndex = 9
        '
        'txtOUSOPRAP
        '
        Me.txtOUSOPRAP.AccessibleDescription = "Primer apellido"
        Me.txtOUSOPRAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUSOPRAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUSOPRAP.ForeColor = System.Drawing.Color.Black
        Me.txtOUSOPRAP.Location = New System.Drawing.Point(432, 49)
        Me.txtOUSOPRAP.MaxLength = 50
        Me.txtOUSOPRAP.Name = "txtOUSOPRAP"
        Me.txtOUSOPRAP.Size = New System.Drawing.Size(164, 20)
        Me.txtOUSOPRAP.TabIndex = 4
        '
        'txtOUSONUDO
        '
        Me.txtOUSONUDO.AccessibleDescription = "Nro. Documento"
        Me.txtOUSONUDO.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUSONUDO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUSONUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUSONUDO.ForeColor = System.Drawing.Color.Black
        Me.txtOUSONUDO.Location = New System.Drawing.Point(137, 26)
        Me.txtOUSONUDO.MaxLength = 14
        Me.txtOUSONUDO.Name = "txtOUSONUDO"
        Me.txtOUSONUDO.Size = New System.Drawing.Size(171, 20)
        Me.txtOUSONUDO.TabIndex = 1
        '
        'txtOUSONOMB
        '
        Me.txtOUSONOMB.AccessibleDescription = "Nombre"
        Me.txtOUSONOMB.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUSONOMB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUSONOMB.ForeColor = System.Drawing.Color.Black
        Me.txtOUSONOMB.Location = New System.Drawing.Point(137, 49)
        Me.txtOUSONOMB.MaxLength = 50
        Me.txtOUSONOMB.Name = "txtOUSONOMB"
        Me.txtOUSONOMB.Size = New System.Drawing.Size(171, 20)
        Me.txtOUSONOMB.TabIndex = 3
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
        'frm_insertar_OBURSOLI
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
        Me.Name = "frm_insertar_OBURSOLI"
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
    Friend WithEvents cboOUSOESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblOUSOSOLI As System.Windows.Forms.Label
    Friend WithEvents cboOUSOSOLI As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtOUSORESO As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtOUSOCOPO As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtOUSOCOEL As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOUSODINO As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOUSODIPR As System.Windows.Forms.TextBox
    Friend WithEvents lblTelefonos As System.Windows.Forms.Label
    Friend WithEvents txtOUSOTELE As System.Windows.Forms.TextBox
    Friend WithEvents txtOUSOSEAP As System.Windows.Forms.TextBox
    Friend WithEvents txtOUSOCELU As System.Windows.Forms.TextBox
    Friend WithEvents txtOUSOPRAP As System.Windows.Forms.TextBox
    Friend WithEvents txtOUSONUDO As System.Windows.Forms.TextBox
    Friend WithEvents txtOUSONOMB As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
