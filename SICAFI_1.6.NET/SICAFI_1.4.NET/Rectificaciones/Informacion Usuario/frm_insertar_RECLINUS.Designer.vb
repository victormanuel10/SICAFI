<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_RECLINUS
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
        Me.nudREIUNUAC = New System.Windows.Forms.NumericUpDown()
        Me.dtpREIUFERE = New System.Windows.Forms.DateTimePicker()
        Me.dtpREIUFEEN = New System.Windows.Forms.DateTimePicker()
        Me.txtREIUFERE = New System.Windows.Forms.MaskedTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtREIUFEEN = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkREIUACFI = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkREIUACTA = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtREIUDINO = New System.Windows.Forms.TextBox()
        Me.txtREIUSEAP = New System.Windows.Forms.TextBox()
        Me.txtREIUPRAP = New System.Windows.Forms.TextBox()
        Me.txtREIUDIPR = New System.Windows.Forms.TextBox()
        Me.txtREIUNOMB = New System.Windows.Forms.TextBox()
        Me.txtREIUTEL2 = New System.Windows.Forms.TextBox()
        Me.txtREIUTEL1 = New System.Windows.Forms.TextBox()
        Me.lblNumeroDocumento = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtREIUOBSE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox4.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraINFOUSUA.SuspendLayout()
        CType(Me.nudREIUNUAC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdSALIR)
        Me.GroupBox4.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 241)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(906, 49)
        Me.GroupBox4.TabIndex = 344
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
        Me.strBARRESTA.TabIndex = 345
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
        Me.fraINFOUSUA.Controls.Add(Me.nudREIUNUAC)
        Me.fraINFOUSUA.Controls.Add(Me.dtpREIUFERE)
        Me.fraINFOUSUA.Controls.Add(Me.dtpREIUFEEN)
        Me.fraINFOUSUA.Controls.Add(Me.txtREIUFERE)
        Me.fraINFOUSUA.Controls.Add(Me.Label8)
        Me.fraINFOUSUA.Controls.Add(Me.txtREIUFEEN)
        Me.fraINFOUSUA.Controls.Add(Me.Label7)
        Me.fraINFOUSUA.Controls.Add(Me.chkREIUACFI)
        Me.fraINFOUSUA.Controls.Add(Me.Label3)
        Me.fraINFOUSUA.Controls.Add(Me.chkREIUACTA)
        Me.fraINFOUSUA.Controls.Add(Me.Label1)
        Me.fraINFOUSUA.Controls.Add(Me.txtREIUDINO)
        Me.fraINFOUSUA.Controls.Add(Me.txtREIUSEAP)
        Me.fraINFOUSUA.Controls.Add(Me.txtREIUPRAP)
        Me.fraINFOUSUA.Controls.Add(Me.txtREIUDIPR)
        Me.fraINFOUSUA.Controls.Add(Me.txtREIUNOMB)
        Me.fraINFOUSUA.Controls.Add(Me.txtREIUTEL2)
        Me.fraINFOUSUA.Controls.Add(Me.txtREIUTEL1)
        Me.fraINFOUSUA.Controls.Add(Me.lblNumeroDocumento)
        Me.fraINFOUSUA.Controls.Add(Me.Label11)
        Me.fraINFOUSUA.Controls.Add(Me.Label4)
        Me.fraINFOUSUA.Controls.Add(Me.txtREIUOBSE)
        Me.fraINFOUSUA.Controls.Add(Me.Label2)
        Me.fraINFOUSUA.Controls.Add(Me.Label5)
        Me.fraINFOUSUA.Controls.Add(Me.Label6)
        Me.fraINFOUSUA.Location = New System.Drawing.Point(12, 12)
        Me.fraINFOUSUA.Name = "fraINFOUSUA"
        Me.fraINFOUSUA.Size = New System.Drawing.Size(906, 223)
        Me.fraINFOUSUA.TabIndex = 343
        Me.fraINFOUSUA.TabStop = False
        Me.fraINFOUSUA.Text = "INSERTAR INFORMACIÓN DEL USUARIO"
        '
        'nudREIUNUAC
        '
        Me.nudREIUNUAC.AccessibleDescription = "Nro. de actas"
        Me.nudREIUNUAC.Location = New System.Drawing.Point(137, 46)
        Me.nudREIUNUAC.Name = "nudREIUNUAC"
        Me.nudREIUNUAC.Size = New System.Drawing.Size(171, 20)
        Me.nudREIUNUAC.TabIndex = 3
        '
        'dtpREIUFERE
        '
        Me.dtpREIUFERE.AccessibleDescription = "Fecha de recibido"
        Me.dtpREIUFERE.Location = New System.Drawing.Point(867, 47)
        Me.dtpREIUFERE.Name = "dtpREIUFERE"
        Me.dtpREIUFERE.Size = New System.Drawing.Size(23, 20)
        Me.dtpREIUFERE.TabIndex = 7
        '
        'dtpREIUFEEN
        '
        Me.dtpREIUFEEN.AccessibleDescription = "Fecha de entrega"
        Me.dtpREIUFEEN.Location = New System.Drawing.Point(577, 48)
        Me.dtpREIUFEEN.Name = "dtpREIUFEEN"
        Me.dtpREIUFEEN.Size = New System.Drawing.Size(19, 20)
        Me.dtpREIUFEEN.TabIndex = 5
        '
        'txtREIUFERE
        '
        Me.txtREIUFERE.AccessibleDescription = "Fecha de recibido"
        Me.txtREIUFERE.BackColor = System.Drawing.Color.White
        Me.txtREIUFERE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREIUFERE.Location = New System.Drawing.Point(719, 47)
        Me.txtREIUFERE.Mask = "00-00-0000"
        Me.txtREIUFERE.Name = "txtREIUFERE"
        Me.txtREIUFERE.Size = New System.Drawing.Size(145, 20)
        Me.txtREIUFERE.TabIndex = 6
        Me.txtREIUFERE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtREIUFERE.ValidatingType = GetType(Date)
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
        'txtREIUFEEN
        '
        Me.txtREIUFEEN.AccessibleDescription = "Fecha de entrega"
        Me.txtREIUFEEN.BackColor = System.Drawing.Color.White
        Me.txtREIUFEEN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREIUFEEN.Location = New System.Drawing.Point(432, 48)
        Me.txtREIUFEEN.Mask = "00-00-0000"
        Me.txtREIUFEEN.Name = "txtREIUFEEN"
        Me.txtREIUFEEN.Size = New System.Drawing.Size(142, 20)
        Me.txtREIUFEEN.TabIndex = 4
        Me.txtREIUFEEN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtREIUFEEN.ValidatingType = GetType(Date)
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
        'chkREIUACFI
        '
        Me.chkREIUACFI.AccessibleDescription = "Acta firmada"
        Me.chkREIUACFI.AutoSize = True
        Me.chkREIUACFI.Location = New System.Drawing.Point(236, 23)
        Me.chkREIUACFI.Name = "chkREIUACFI"
        Me.chkREIUACFI.Size = New System.Drawing.Size(85, 17)
        Me.chkREIUACFI.TabIndex = 2
        Me.chkREIUACFI.Text = "Acta firmada"
        Me.chkREIUACFI.UseVisualStyleBackColor = True
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
        'chkREIUACTA
        '
        Me.chkREIUACTA.AccessibleDescription = "Acta de verificación"
        Me.chkREIUACTA.AutoSize = True
        Me.chkREIUACTA.Location = New System.Drawing.Point(17, 22)
        Me.chkREIUACTA.Name = "chkREIUACTA"
        Me.chkREIUACTA.Size = New System.Drawing.Size(213, 17)
        Me.chkREIUACTA.TabIndex = 1
        Me.chkREIUACTA.Text = "Acta de verificación de linderos linderos"
        Me.chkREIUACTA.UseVisualStyleBackColor = True
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
        'txtREIUDINO
        '
        Me.txtREIUDINO.AccessibleDescription = "Dirección de notificación"
        Me.txtREIUDINO.BackColor = System.Drawing.SystemColors.Window
        Me.txtREIUDINO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREIUDINO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREIUDINO.ForeColor = System.Drawing.Color.Black
        Me.txtREIUDINO.Location = New System.Drawing.Point(432, 93)
        Me.txtREIUDINO.MaxLength = 50
        Me.txtREIUDINO.Name = "txtREIUDINO"
        Me.txtREIUDINO.Size = New System.Drawing.Size(164, 20)
        Me.txtREIUDINO.TabIndex = 12
        '
        'txtREIUSEAP
        '
        Me.txtREIUSEAP.AccessibleDescription = "Segundo apellido"
        Me.txtREIUSEAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtREIUSEAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREIUSEAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREIUSEAP.ForeColor = System.Drawing.Color.Black
        Me.txtREIUSEAP.Location = New System.Drawing.Point(719, 69)
        Me.txtREIUSEAP.MaxLength = 20
        Me.txtREIUSEAP.Name = "txtREIUSEAP"
        Me.txtREIUSEAP.Size = New System.Drawing.Size(171, 20)
        Me.txtREIUSEAP.TabIndex = 10
        '
        'txtREIUPRAP
        '
        Me.txtREIUPRAP.AccessibleDescription = "Primer apellido"
        Me.txtREIUPRAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtREIUPRAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREIUPRAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREIUPRAP.ForeColor = System.Drawing.Color.Black
        Me.txtREIUPRAP.Location = New System.Drawing.Point(432, 70)
        Me.txtREIUPRAP.MaxLength = 20
        Me.txtREIUPRAP.Name = "txtREIUPRAP"
        Me.txtREIUPRAP.Size = New System.Drawing.Size(164, 20)
        Me.txtREIUPRAP.TabIndex = 9
        '
        'txtREIUDIPR
        '
        Me.txtREIUDIPR.AccessibleDescription = "Dirección de predio"
        Me.txtREIUDIPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtREIUDIPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREIUDIPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREIUDIPR.ForeColor = System.Drawing.Color.Black
        Me.txtREIUDIPR.Location = New System.Drawing.Point(137, 93)
        Me.txtREIUDIPR.MaxLength = 50
        Me.txtREIUDIPR.Name = "txtREIUDIPR"
        Me.txtREIUDIPR.Size = New System.Drawing.Size(171, 20)
        Me.txtREIUDIPR.TabIndex = 11
        '
        'txtREIUNOMB
        '
        Me.txtREIUNOMB.AccessibleDescription = "Nombre"
        Me.txtREIUNOMB.BackColor = System.Drawing.SystemColors.Window
        Me.txtREIUNOMB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREIUNOMB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREIUNOMB.ForeColor = System.Drawing.Color.Black
        Me.txtREIUNOMB.Location = New System.Drawing.Point(137, 70)
        Me.txtREIUNOMB.MaxLength = 50
        Me.txtREIUNOMB.Name = "txtREIUNOMB"
        Me.txtREIUNOMB.Size = New System.Drawing.Size(171, 20)
        Me.txtREIUNOMB.TabIndex = 8
        '
        'txtREIUTEL2
        '
        Me.txtREIUTEL2.AccessibleDescription = "Telefono 2 "
        Me.txtREIUTEL2.BackColor = System.Drawing.SystemColors.Window
        Me.txtREIUTEL2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREIUTEL2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREIUTEL2.ForeColor = System.Drawing.Color.Black
        Me.txtREIUTEL2.Location = New System.Drawing.Point(806, 92)
        Me.txtREIUTEL2.MaxLength = 10
        Me.txtREIUTEL2.Name = "txtREIUTEL2"
        Me.txtREIUTEL2.Size = New System.Drawing.Size(84, 20)
        Me.txtREIUTEL2.TabIndex = 14
        '
        'txtREIUTEL1
        '
        Me.txtREIUTEL1.AccessibleDescription = "Telefono 1 "
        Me.txtREIUTEL1.BackColor = System.Drawing.SystemColors.Window
        Me.txtREIUTEL1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREIUTEL1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREIUTEL1.ForeColor = System.Drawing.Color.Black
        Me.txtREIUTEL1.Location = New System.Drawing.Point(719, 92)
        Me.txtREIUTEL1.MaxLength = 10
        Me.txtREIUTEL1.Name = "txtREIUTEL1"
        Me.txtREIUTEL1.Size = New System.Drawing.Size(84, 20)
        Me.txtREIUTEL1.TabIndex = 13
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
        'txtREIUOBSE
        '
        Me.txtREIUOBSE.AccessibleDescription = "Observación"
        Me.txtREIUOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtREIUOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREIUOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREIUOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtREIUOBSE.Location = New System.Drawing.Point(137, 116)
        Me.txtREIUOBSE.MaxLength = 1000
        Me.txtREIUOBSE.Multiline = True
        Me.txtREIUOBSE.Name = "txtREIUOBSE"
        Me.txtREIUOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtREIUOBSE.Size = New System.Drawing.Size(753, 87)
        Me.txtREIUOBSE.TabIndex = 15
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
        'frm_insertar_RECLINUS
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
        Me.MinimumSize = New System.Drawing.Size(947, 365)
        Me.Name = "frm_insertar_RECLINUS"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox4.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraINFOUSUA.ResumeLayout(False)
        Me.fraINFOUSUA.PerformLayout()
        CType(Me.nudREIUNUAC, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtREIUSEAP As System.Windows.Forms.TextBox
    Friend WithEvents txtREIUPRAP As System.Windows.Forms.TextBox
    Friend WithEvents txtREIUDIPR As System.Windows.Forms.TextBox
    Friend WithEvents txtREIUNOMB As System.Windows.Forms.TextBox
    Friend WithEvents txtREIUTEL2 As System.Windows.Forms.TextBox
    Friend WithEvents txtREIUTEL1 As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtREIUOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtREIUDINO As System.Windows.Forms.TextBox
    Friend WithEvents chkREIUACFI As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkREIUACTA As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtREIUFERE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtREIUFEEN As System.Windows.Forms.MaskedTextBox
    Friend WithEvents dtpREIUFERE As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpREIUFEEN As System.Windows.Forms.DateTimePicker
    Friend WithEvents nudREIUNUAC As System.Windows.Forms.NumericUpDown
End Class
