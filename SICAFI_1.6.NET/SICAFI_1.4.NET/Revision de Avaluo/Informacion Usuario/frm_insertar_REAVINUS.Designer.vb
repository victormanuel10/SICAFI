<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_REAVINUS
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
        Me.nudRAIUNUAC = New System.Windows.Forms.NumericUpDown()
        Me.dtpRAIUFERE = New System.Windows.Forms.DateTimePicker()
        Me.dtpRAIUFEEN = New System.Windows.Forms.DateTimePicker()
        Me.txtRAIUFERE = New System.Windows.Forms.MaskedTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRAIUFEEN = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkRAIUACFI = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkRAIUACTA = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRAIUDINO = New System.Windows.Forms.TextBox()
        Me.txtRAIUSEAP = New System.Windows.Forms.TextBox()
        Me.txtRAIUPRAP = New System.Windows.Forms.TextBox()
        Me.txtRAIUDIPR = New System.Windows.Forms.TextBox()
        Me.txtRAIUNOMB = New System.Windows.Forms.TextBox()
        Me.txtRAIUTEL2 = New System.Windows.Forms.TextBox()
        Me.txtRAIUTEL1 = New System.Windows.Forms.TextBox()
        Me.lblNumeroDocumento = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRAIUOBSE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox4.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraINFOUSUA.SuspendLayout()
        CType(Me.nudRAIUNUAC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdSALIR)
        Me.GroupBox4.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 239)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(906, 49)
        Me.GroupBox4.TabIndex = 347
        Me.GroupBox4.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(472, 15)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(365, 15)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 304)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(931, 25)
        Me.strBARRESTA.TabIndex = 348
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
        Me.fraINFOUSUA.Controls.Add(Me.nudRAIUNUAC)
        Me.fraINFOUSUA.Controls.Add(Me.dtpRAIUFERE)
        Me.fraINFOUSUA.Controls.Add(Me.dtpRAIUFEEN)
        Me.fraINFOUSUA.Controls.Add(Me.txtRAIUFERE)
        Me.fraINFOUSUA.Controls.Add(Me.Label8)
        Me.fraINFOUSUA.Controls.Add(Me.txtRAIUFEEN)
        Me.fraINFOUSUA.Controls.Add(Me.Label7)
        Me.fraINFOUSUA.Controls.Add(Me.chkRAIUACFI)
        Me.fraINFOUSUA.Controls.Add(Me.Label3)
        Me.fraINFOUSUA.Controls.Add(Me.chkRAIUACTA)
        Me.fraINFOUSUA.Controls.Add(Me.Label1)
        Me.fraINFOUSUA.Controls.Add(Me.txtRAIUDINO)
        Me.fraINFOUSUA.Controls.Add(Me.txtRAIUSEAP)
        Me.fraINFOUSUA.Controls.Add(Me.txtRAIUPRAP)
        Me.fraINFOUSUA.Controls.Add(Me.txtRAIUDIPR)
        Me.fraINFOUSUA.Controls.Add(Me.txtRAIUNOMB)
        Me.fraINFOUSUA.Controls.Add(Me.txtRAIUTEL2)
        Me.fraINFOUSUA.Controls.Add(Me.txtRAIUTEL1)
        Me.fraINFOUSUA.Controls.Add(Me.lblNumeroDocumento)
        Me.fraINFOUSUA.Controls.Add(Me.Label11)
        Me.fraINFOUSUA.Controls.Add(Me.Label4)
        Me.fraINFOUSUA.Controls.Add(Me.txtRAIUOBSE)
        Me.fraINFOUSUA.Controls.Add(Me.Label2)
        Me.fraINFOUSUA.Controls.Add(Me.Label5)
        Me.fraINFOUSUA.Controls.Add(Me.Label6)
        Me.fraINFOUSUA.Location = New System.Drawing.Point(12, 10)
        Me.fraINFOUSUA.Name = "fraINFOUSUA"
        Me.fraINFOUSUA.Size = New System.Drawing.Size(906, 223)
        Me.fraINFOUSUA.TabIndex = 346
        Me.fraINFOUSUA.TabStop = False
        Me.fraINFOUSUA.Text = "INSERTAR INFORMACIÓN DEL USUARIO"
        '
        'nudRAIUNUAC
        '
        Me.nudRAIUNUAC.AccessibleDescription = "Nro. de actas"
        Me.nudRAIUNUAC.Location = New System.Drawing.Point(137, 46)
        Me.nudRAIUNUAC.Name = "nudRAIUNUAC"
        Me.nudRAIUNUAC.Size = New System.Drawing.Size(171, 20)
        Me.nudRAIUNUAC.TabIndex = 3
        '
        'dtpRAIUFERE
        '
        Me.dtpRAIUFERE.AccessibleDescription = "Fecha de recibido"
        Me.dtpRAIUFERE.Location = New System.Drawing.Point(867, 47)
        Me.dtpRAIUFERE.Name = "dtpRAIUFERE"
        Me.dtpRAIUFERE.Size = New System.Drawing.Size(23, 20)
        Me.dtpRAIUFERE.TabIndex = 7
        '
        'dtpRAIUFEEN
        '
        Me.dtpRAIUFEEN.AccessibleDescription = "Fecha de entrega"
        Me.dtpRAIUFEEN.Location = New System.Drawing.Point(577, 48)
        Me.dtpRAIUFEEN.Name = "dtpRAIUFEEN"
        Me.dtpRAIUFEEN.Size = New System.Drawing.Size(19, 20)
        Me.dtpRAIUFEEN.TabIndex = 5
        '
        'txtRAIUFERE
        '
        Me.txtRAIUFERE.AccessibleDescription = "Fecha de recibido"
        Me.txtRAIUFERE.BackColor = System.Drawing.Color.White
        Me.txtRAIUFERE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRAIUFERE.Location = New System.Drawing.Point(719, 47)
        Me.txtRAIUFERE.Mask = "00-00-0000"
        Me.txtRAIUFERE.Name = "txtRAIUFERE"
        Me.txtRAIUFERE.Size = New System.Drawing.Size(145, 20)
        Me.txtRAIUFERE.TabIndex = 6
        Me.txtRAIUFERE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRAIUFERE.ValidatingType = GetType(Date)
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(600, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 20)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "Fecha de recibido"
        '
        'txtRAIUFEEN
        '
        Me.txtRAIUFEEN.AccessibleDescription = "Fecha de entrega"
        Me.txtRAIUFEEN.BackColor = System.Drawing.Color.White
        Me.txtRAIUFEEN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRAIUFEEN.Location = New System.Drawing.Point(432, 48)
        Me.txtRAIUFEEN.Mask = "00-00-0000"
        Me.txtRAIUFEEN.Name = "txtRAIUFEEN"
        Me.txtRAIUFEEN.Size = New System.Drawing.Size(142, 20)
        Me.txtRAIUFEEN.TabIndex = 4
        Me.txtRAIUFEEN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRAIUFEEN.ValidatingType = GetType(Date)
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(312, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 20)
        Me.Label7.TabIndex = 79
        Me.Label7.Text = "Fecha de entrega"
        '
        'chkRAIUACFI
        '
        Me.chkRAIUACFI.AccessibleDescription = "Acta firmada"
        Me.chkRAIUACFI.AutoSize = True
        Me.chkRAIUACFI.Location = New System.Drawing.Point(236, 23)
        Me.chkRAIUACFI.Name = "chkRAIUACFI"
        Me.chkRAIUACFI.Size = New System.Drawing.Size(85, 17)
        Me.chkRAIUACFI.TabIndex = 2
        Me.chkRAIUACFI.Text = "Acta firmada"
        Me.chkRAIUACFI.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(17, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 20)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "Nro. de actas"
        '
        'chkRAIUACTA
        '
        Me.chkRAIUACTA.AccessibleDescription = "Acta de verificación"
        Me.chkRAIUACTA.AutoSize = True
        Me.chkRAIUACTA.Location = New System.Drawing.Point(17, 22)
        Me.chkRAIUACTA.Name = "chkRAIUACTA"
        Me.chkRAIUACTA.Size = New System.Drawing.Size(213, 17)
        Me.chkRAIUACTA.TabIndex = 1
        Me.chkRAIUACTA.Text = "Acta de verificación de linderos linderos"
        Me.chkRAIUACTA.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(600, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 20)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "Nro. telefono"
        '
        'txtRAIUDINO
        '
        Me.txtRAIUDINO.AccessibleDescription = "Dirección de notificación"
        Me.txtRAIUDINO.BackColor = System.Drawing.SystemColors.Window
        Me.txtRAIUDINO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRAIUDINO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRAIUDINO.ForeColor = System.Drawing.Color.Black
        Me.txtRAIUDINO.Location = New System.Drawing.Point(432, 93)
        Me.txtRAIUDINO.MaxLength = 50
        Me.txtRAIUDINO.Name = "txtRAIUDINO"
        Me.txtRAIUDINO.Size = New System.Drawing.Size(164, 20)
        Me.txtRAIUDINO.TabIndex = 12
        '
        'txtRAIUSEAP
        '
        Me.txtRAIUSEAP.AccessibleDescription = "Segundo apellido"
        Me.txtRAIUSEAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtRAIUSEAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRAIUSEAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRAIUSEAP.ForeColor = System.Drawing.Color.Black
        Me.txtRAIUSEAP.Location = New System.Drawing.Point(719, 69)
        Me.txtRAIUSEAP.MaxLength = 20
        Me.txtRAIUSEAP.Name = "txtRAIUSEAP"
        Me.txtRAIUSEAP.Size = New System.Drawing.Size(171, 20)
        Me.txtRAIUSEAP.TabIndex = 10
        '
        'txtRAIUPRAP
        '
        Me.txtRAIUPRAP.AccessibleDescription = "Primer apellido"
        Me.txtRAIUPRAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtRAIUPRAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRAIUPRAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRAIUPRAP.ForeColor = System.Drawing.Color.Black
        Me.txtRAIUPRAP.Location = New System.Drawing.Point(432, 70)
        Me.txtRAIUPRAP.MaxLength = 20
        Me.txtRAIUPRAP.Name = "txtRAIUPRAP"
        Me.txtRAIUPRAP.Size = New System.Drawing.Size(164, 20)
        Me.txtRAIUPRAP.TabIndex = 9
        '
        'txtRAIUDIPR
        '
        Me.txtRAIUDIPR.AccessibleDescription = "Dirección de predio"
        Me.txtRAIUDIPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRAIUDIPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRAIUDIPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRAIUDIPR.ForeColor = System.Drawing.Color.Black
        Me.txtRAIUDIPR.Location = New System.Drawing.Point(137, 93)
        Me.txtRAIUDIPR.MaxLength = 50
        Me.txtRAIUDIPR.Name = "txtRAIUDIPR"
        Me.txtRAIUDIPR.Size = New System.Drawing.Size(171, 20)
        Me.txtRAIUDIPR.TabIndex = 11
        '
        'txtRAIUNOMB
        '
        Me.txtRAIUNOMB.AccessibleDescription = "Nombre"
        Me.txtRAIUNOMB.BackColor = System.Drawing.SystemColors.Window
        Me.txtRAIUNOMB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRAIUNOMB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRAIUNOMB.ForeColor = System.Drawing.Color.Black
        Me.txtRAIUNOMB.Location = New System.Drawing.Point(137, 70)
        Me.txtRAIUNOMB.MaxLength = 50
        Me.txtRAIUNOMB.Name = "txtRAIUNOMB"
        Me.txtRAIUNOMB.Size = New System.Drawing.Size(171, 20)
        Me.txtRAIUNOMB.TabIndex = 8
        '
        'txtRAIUTEL2
        '
        Me.txtRAIUTEL2.AccessibleDescription = "Telefono 2 "
        Me.txtRAIUTEL2.BackColor = System.Drawing.SystemColors.Window
        Me.txtRAIUTEL2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRAIUTEL2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRAIUTEL2.ForeColor = System.Drawing.Color.Black
        Me.txtRAIUTEL2.Location = New System.Drawing.Point(806, 92)
        Me.txtRAIUTEL2.MaxLength = 10
        Me.txtRAIUTEL2.Name = "txtRAIUTEL2"
        Me.txtRAIUTEL2.Size = New System.Drawing.Size(84, 20)
        Me.txtRAIUTEL2.TabIndex = 14
        '
        'txtRAIUTEL1
        '
        Me.txtRAIUTEL1.AccessibleDescription = "Telefono 1 "
        Me.txtRAIUTEL1.BackColor = System.Drawing.SystemColors.Window
        Me.txtRAIUTEL1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRAIUTEL1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRAIUTEL1.ForeColor = System.Drawing.Color.Black
        Me.txtRAIUTEL1.Location = New System.Drawing.Point(719, 92)
        Me.txtRAIUTEL1.MaxLength = 10
        Me.txtRAIUTEL1.Name = "txtRAIUTEL1"
        Me.txtRAIUTEL1.Size = New System.Drawing.Size(84, 20)
        Me.txtRAIUTEL1.TabIndex = 13
        '
        'lblNumeroDocumento
        '
        Me.lblNumeroDocumento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblNumeroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumeroDocumento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroDocumento.ForeColor = System.Drawing.Color.Black
        Me.lblNumeroDocumento.Location = New System.Drawing.Point(17, 93)
        Me.lblNumeroDocumento.Name = "lblNumeroDocumento"
        Me.lblNumeroDocumento.Size = New System.Drawing.Size(116, 20)
        Me.lblNumeroDocumento.TabIndex = 56
        Me.lblNumeroDocumento.Text = "Dirección del predio"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(312, 93)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 20)
        Me.Label11.TabIndex = 70
        Me.Label11.Text = "Direc. de notificación"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(17, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 20)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Nombre (S)"
        '
        'txtRAIUOBSE
        '
        Me.txtRAIUOBSE.AccessibleDescription = "Observación"
        Me.txtRAIUOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtRAIUOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRAIUOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRAIUOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtRAIUOBSE.Location = New System.Drawing.Point(137, 116)
        Me.txtRAIUOBSE.MaxLength = 1000
        Me.txtRAIUOBSE.Multiline = True
        Me.txtRAIUOBSE.Name = "txtRAIUOBSE"
        Me.txtRAIUOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRAIUOBSE.Size = New System.Drawing.Size(753, 87)
        Me.txtRAIUOBSE.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(17, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 20)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Observación"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(312, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 20)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "Primer Apellido"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(600, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 20)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "Segundo Apellido"
        '
        'frm_insertar_REAVINUS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(931, 329)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraINFOUSUA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(947, 365)
        Me.MinimizeBox = False
        Me.Name = "frm_insertar_REAVINUS"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox4.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraINFOUSUA.ResumeLayout(False)
        Me.fraINFOUSUA.PerformLayout()
        CType(Me.nudRAIUNUAC, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents nudRAIUNUAC As System.Windows.Forms.NumericUpDown
    Friend WithEvents dtpRAIUFERE As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpRAIUFEEN As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRAIUFERE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRAIUFEEN As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkRAIUACFI As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkRAIUACTA As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRAIUDINO As System.Windows.Forms.TextBox
    Friend WithEvents txtRAIUSEAP As System.Windows.Forms.TextBox
    Friend WithEvents txtRAIUPRAP As System.Windows.Forms.TextBox
    Friend WithEvents txtRAIUDIPR As System.Windows.Forms.TextBox
    Friend WithEvents txtRAIUNOMB As System.Windows.Forms.TextBox
    Friend WithEvents txtRAIUTEL2 As System.Windows.Forms.TextBox
    Friend WithEvents txtRAIUTEL1 As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRAIUOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
