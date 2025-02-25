<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_AJIPINUS
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
        Me.txtAJIUCOEL = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAJIUDICO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAJIUDIPR = New System.Windows.Forms.TextBox()
        Me.txtAJIUSEAP = New System.Windows.Forms.TextBox()
        Me.txtAJIUPRAP = New System.Windows.Forms.TextBox()
        Me.txtAJIUNUDO = New System.Windows.Forms.TextBox()
        Me.txtAJIUNOMB = New System.Windows.Forms.TextBox()
        Me.txtAJIUTEL2 = New System.Windows.Forms.TextBox()
        Me.txtAJIUTEL1 = New System.Windows.Forms.TextBox()
        Me.txtAJIUFERE = New System.Windows.Forms.MaskedTextBox()
        Me.lblNumeroDocumento = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAJIUOBSE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTelefonos = New System.Windows.Forms.Label()
        Me.GroupBox4.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraINFOUSUA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdSALIR)
        Me.GroupBox4.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 216)
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
        Me.cmdSALIR.Location = New System.Drawing.Point(466, 15)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(359, 15)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 280)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(930, 25)
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
        Me.fraINFOUSUA.Controls.Add(Me.txtAJIUCOEL)
        Me.fraINFOUSUA.Controls.Add(Me.Label3)
        Me.fraINFOUSUA.Controls.Add(Me.txtAJIUDICO)
        Me.fraINFOUSUA.Controls.Add(Me.Label1)
        Me.fraINFOUSUA.Controls.Add(Me.txtAJIUDIPR)
        Me.fraINFOUSUA.Controls.Add(Me.txtAJIUSEAP)
        Me.fraINFOUSUA.Controls.Add(Me.txtAJIUPRAP)
        Me.fraINFOUSUA.Controls.Add(Me.txtAJIUNUDO)
        Me.fraINFOUSUA.Controls.Add(Me.txtAJIUNOMB)
        Me.fraINFOUSUA.Controls.Add(Me.txtAJIUTEL2)
        Me.fraINFOUSUA.Controls.Add(Me.txtAJIUTEL1)
        Me.fraINFOUSUA.Controls.Add(Me.txtAJIUFERE)
        Me.fraINFOUSUA.Controls.Add(Me.lblNumeroDocumento)
        Me.fraINFOUSUA.Controls.Add(Me.Label11)
        Me.fraINFOUSUA.Controls.Add(Me.Label4)
        Me.fraINFOUSUA.Controls.Add(Me.txtAJIUOBSE)
        Me.fraINFOUSUA.Controls.Add(Me.Label2)
        Me.fraINFOUSUA.Controls.Add(Me.Label5)
        Me.fraINFOUSUA.Controls.Add(Me.lblDireccion)
        Me.fraINFOUSUA.Controls.Add(Me.Label6)
        Me.fraINFOUSUA.Controls.Add(Me.lblTelefonos)
        Me.fraINFOUSUA.Location = New System.Drawing.Point(12, 10)
        Me.fraINFOUSUA.Name = "fraINFOUSUA"
        Me.fraINFOUSUA.Size = New System.Drawing.Size(906, 200)
        Me.fraINFOUSUA.TabIndex = 346
        Me.fraINFOUSUA.TabStop = False
        Me.fraINFOUSUA.Text = "INSERTAR INFORMACIÓN DEL USUARIO"
        '
        'txtAJIUCOEL
        '
        Me.txtAJIUCOEL.AccessibleDescription = "Dirección"
        Me.txtAJIUCOEL.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIUCOEL.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtAJIUCOEL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIUCOEL.ForeColor = System.Drawing.Color.Black
        Me.txtAJIUCOEL.Location = New System.Drawing.Point(720, 72)
        Me.txtAJIUCOEL.MaxLength = 49
        Me.txtAJIUCOEL.Name = "txtAJIUCOEL"
        Me.txtAJIUCOEL.Size = New System.Drawing.Size(171, 20)
        Me.txtAJIUCOEL.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(600, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 20)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Correo electronico"
        '
        'txtAJIUDICO
        '
        Me.txtAJIUDICO.AccessibleDescription = "Dirección"
        Me.txtAJIUDICO.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIUDICO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIUDICO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIUDICO.ForeColor = System.Drawing.Color.Black
        Me.txtAJIUDICO.Location = New System.Drawing.Point(432, 72)
        Me.txtAJIUDICO.MaxLength = 49
        Me.txtAJIUDICO.Name = "txtAJIUDICO"
        Me.txtAJIUDICO.Size = New System.Drawing.Size(164, 20)
        Me.txtAJIUDICO.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(312, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 20)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Dirección de cobro"
        '
        'txtAJIUDIPR
        '
        Me.txtAJIUDIPR.AccessibleDescription = "Dirección"
        Me.txtAJIUDIPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIUDIPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIUDIPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIUDIPR.ForeColor = System.Drawing.Color.Black
        Me.txtAJIUDIPR.Location = New System.Drawing.Point(137, 72)
        Me.txtAJIUDIPR.MaxLength = 49
        Me.txtAJIUDIPR.Name = "txtAJIUDIPR"
        Me.txtAJIUDIPR.Size = New System.Drawing.Size(171, 20)
        Me.txtAJIUDIPR.TabIndex = 8
        '
        'txtAJIUSEAP
        '
        Me.txtAJIUSEAP.AccessibleDescription = "Segundo apellido"
        Me.txtAJIUSEAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIUSEAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIUSEAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIUSEAP.ForeColor = System.Drawing.Color.Black
        Me.txtAJIUSEAP.Location = New System.Drawing.Point(719, 48)
        Me.txtAJIUSEAP.MaxLength = 49
        Me.txtAJIUSEAP.Name = "txtAJIUSEAP"
        Me.txtAJIUSEAP.Size = New System.Drawing.Size(172, 20)
        Me.txtAJIUSEAP.TabIndex = 7
        '
        'txtAJIUPRAP
        '
        Me.txtAJIUPRAP.AccessibleDescription = "Primer apellido"
        Me.txtAJIUPRAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIUPRAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIUPRAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIUPRAP.ForeColor = System.Drawing.Color.Black
        Me.txtAJIUPRAP.Location = New System.Drawing.Point(432, 49)
        Me.txtAJIUPRAP.MaxLength = 49
        Me.txtAJIUPRAP.Name = "txtAJIUPRAP"
        Me.txtAJIUPRAP.Size = New System.Drawing.Size(164, 20)
        Me.txtAJIUPRAP.TabIndex = 6
        '
        'txtAJIUNUDO
        '
        Me.txtAJIUNUDO.AccessibleDescription = "Nro. Documento"
        Me.txtAJIUNUDO.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIUNUDO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIUNUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIUNUDO.ForeColor = System.Drawing.Color.Black
        Me.txtAJIUNUDO.Location = New System.Drawing.Point(137, 26)
        Me.txtAJIUNUDO.MaxLength = 49
        Me.txtAJIUNUDO.Name = "txtAJIUNUDO"
        Me.txtAJIUNUDO.Size = New System.Drawing.Size(171, 20)
        Me.txtAJIUNUDO.TabIndex = 1
        '
        'txtAJIUNOMB
        '
        Me.txtAJIUNOMB.AccessibleDescription = "Nombre"
        Me.txtAJIUNOMB.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIUNOMB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIUNOMB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIUNOMB.ForeColor = System.Drawing.Color.Black
        Me.txtAJIUNOMB.Location = New System.Drawing.Point(137, 49)
        Me.txtAJIUNOMB.MaxLength = 49
        Me.txtAJIUNOMB.Name = "txtAJIUNOMB"
        Me.txtAJIUNOMB.Size = New System.Drawing.Size(171, 20)
        Me.txtAJIUNOMB.TabIndex = 5
        '
        'txtAJIUTEL2
        '
        Me.txtAJIUTEL2.AccessibleDescription = "Telefono 2 "
        Me.txtAJIUTEL2.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIUTEL2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIUTEL2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIUTEL2.ForeColor = System.Drawing.Color.Black
        Me.txtAJIUTEL2.Location = New System.Drawing.Point(807, 26)
        Me.txtAJIUTEL2.MaxLength = 49
        Me.txtAJIUTEL2.Name = "txtAJIUTEL2"
        Me.txtAJIUTEL2.Size = New System.Drawing.Size(84, 20)
        Me.txtAJIUTEL2.TabIndex = 4
        '
        'txtAJIUTEL1
        '
        Me.txtAJIUTEL1.AccessibleDescription = "Telefono 1 "
        Me.txtAJIUTEL1.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIUTEL1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIUTEL1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIUTEL1.ForeColor = System.Drawing.Color.Black
        Me.txtAJIUTEL1.Location = New System.Drawing.Point(719, 26)
        Me.txtAJIUTEL1.MaxLength = 49
        Me.txtAJIUTEL1.Name = "txtAJIUTEL1"
        Me.txtAJIUTEL1.Size = New System.Drawing.Size(85, 20)
        Me.txtAJIUTEL1.TabIndex = 3
        '
        'txtAJIUFERE
        '
        Me.txtAJIUFERE.AccessibleDescription = "Fecha de ingreso"
        Me.txtAJIUFERE.BackColor = System.Drawing.Color.White
        Me.txtAJIUFERE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIUFERE.Location = New System.Drawing.Point(432, 26)
        Me.txtAJIUFERE.Mask = "00-00-0000"
        Me.txtAJIUFERE.Name = "txtAJIUFERE"
        Me.txtAJIUFERE.Size = New System.Drawing.Size(164, 20)
        Me.txtAJIUFERE.TabIndex = 2
        Me.txtAJIUFERE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(312, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 20)
        Me.Label11.TabIndex = 70
        Me.Label11.Text = "Fecha de Recibido"
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
        'txtAJIUOBSE
        '
        Me.txtAJIUOBSE.AccessibleDescription = "Observación"
        Me.txtAJIUOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtAJIUOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAJIUOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAJIUOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtAJIUOBSE.Location = New System.Drawing.Point(137, 95)
        Me.txtAJIUOBSE.MaxLength = 1000
        Me.txtAJIUOBSE.Multiline = True
        Me.txtAJIUOBSE.Name = "txtAJIUOBSE"
        Me.txtAJIUOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAJIUOBSE.Size = New System.Drawing.Size(754, 87)
        Me.txtAJIUOBSE.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(17, 95)
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
        'lblTelefonos
        '
        Me.lblTelefonos.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblTelefonos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTelefonos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefonos.ForeColor = System.Drawing.Color.Black
        Me.lblTelefonos.Location = New System.Drawing.Point(600, 26)
        Me.lblTelefonos.Name = "lblTelefonos"
        Me.lblTelefonos.Size = New System.Drawing.Size(116, 20)
        Me.lblTelefonos.TabIndex = 64
        Me.lblTelefonos.Text = "Telefonos"
        '
        'frm_insertar_AJIPINUS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 305)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraINFOUSUA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(946, 341)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(946, 341)
        Me.Name = "frm_insertar_AJIPINUS"
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
    Friend WithEvents txtAJIUDIPR As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIUSEAP As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIUPRAP As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIUNUDO As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIUNOMB As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIUTEL2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIUTEL1 As System.Windows.Forms.TextBox
    Friend WithEvents txtAJIUFERE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAJIUOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTelefonos As System.Windows.Forms.Label
    Friend WithEvents txtAJIUCOEL As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAJIUDICO As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
