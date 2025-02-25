<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_INFOUSUA
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
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtINUSOBSE = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblDireccion = New System.Windows.Forms.Label
        Me.lblTelefonos = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblNumeroDocumento = New System.Windows.Forms.Label
        Me.fraINFOUSUA = New System.Windows.Forms.GroupBox
        Me.txtINUSDIRE = New System.Windows.Forms.TextBox
        Me.txtINUSSEAP = New System.Windows.Forms.TextBox
        Me.txtINUSPRAP = New System.Windows.Forms.TextBox
        Me.txtINUSNUDO = New System.Windows.Forms.TextBox
        Me.txtINUSNOMB = New System.Windows.Forms.TextBox
        Me.txtINUSTEL2 = New System.Windows.Forms.TextBox
        Me.txtINUSTEL1 = New System.Windows.Forms.TextBox
        Me.txtINUSFERE = New System.Windows.Forms.MaskedTextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.cmdGUARDAR = New System.Windows.Forms.Button
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.fraINFOUSUA.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.SuspendLayout()
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
        'txtINUSOBSE
        '
        Me.txtINUSOBSE.AccessibleDescription = "Observación"
        Me.txtINUSOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtINUSOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtINUSOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtINUSOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtINUSOBSE.Location = New System.Drawing.Point(137, 95)
        Me.txtINUSOBSE.MaxLength = 1000
        Me.txtINUSOBSE.Multiline = True
        Me.txtINUSOBSE.Name = "txtINUSOBSE"
        Me.txtINUSOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtINUSOBSE.Size = New System.Drawing.Size(749, 87)
        Me.txtINUSOBSE.TabIndex = 9
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
        'lblDireccion
        '
        Me.lblDireccion.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblDireccion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDireccion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccion.ForeColor = System.Drawing.Color.Black
        Me.lblDireccion.Location = New System.Drawing.Point(312, 72)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(116, 20)
        Me.lblDireccion.TabIndex = 66
        Me.lblDireccion.Text = "Dirección"
        '
        'lblTelefonos
        '
        Me.lblTelefonos.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblTelefonos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTelefonos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefonos.ForeColor = System.Drawing.Color.Black
        Me.lblTelefonos.Location = New System.Drawing.Point(17, 72)
        Me.lblTelefonos.Name = "lblTelefonos"
        Me.lblTelefonos.Size = New System.Drawing.Size(116, 20)
        Me.lblTelefonos.TabIndex = 64
        Me.lblTelefonos.Text = "Telefonos"
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
        'fraINFOUSUA
        '
        Me.fraINFOUSUA.Controls.Add(Me.txtINUSDIRE)
        Me.fraINFOUSUA.Controls.Add(Me.txtINUSSEAP)
        Me.fraINFOUSUA.Controls.Add(Me.txtINUSPRAP)
        Me.fraINFOUSUA.Controls.Add(Me.txtINUSNUDO)
        Me.fraINFOUSUA.Controls.Add(Me.txtINUSNOMB)
        Me.fraINFOUSUA.Controls.Add(Me.txtINUSTEL2)
        Me.fraINFOUSUA.Controls.Add(Me.txtINUSTEL1)
        Me.fraINFOUSUA.Controls.Add(Me.txtINUSFERE)
        Me.fraINFOUSUA.Controls.Add(Me.lblNumeroDocumento)
        Me.fraINFOUSUA.Controls.Add(Me.Label11)
        Me.fraINFOUSUA.Controls.Add(Me.Label4)
        Me.fraINFOUSUA.Controls.Add(Me.txtINUSOBSE)
        Me.fraINFOUSUA.Controls.Add(Me.Label2)
        Me.fraINFOUSUA.Controls.Add(Me.Label5)
        Me.fraINFOUSUA.Controls.Add(Me.lblDireccion)
        Me.fraINFOUSUA.Controls.Add(Me.Label6)
        Me.fraINFOUSUA.Controls.Add(Me.lblTelefonos)
        Me.fraINFOUSUA.Location = New System.Drawing.Point(12, 12)
        Me.fraINFOUSUA.Name = "fraINFOUSUA"
        Me.fraINFOUSUA.Size = New System.Drawing.Size(906, 200)
        Me.fraINFOUSUA.TabIndex = 1
        Me.fraINFOUSUA.TabStop = False
        Me.fraINFOUSUA.Text = "INSERTAR INFORMACIÓN DEL USUARIO"
        '
        'txtINUSDIRE
        '
        Me.txtINUSDIRE.AccessibleDescription = "Dirección"
        Me.txtINUSDIRE.BackColor = System.Drawing.SystemColors.Window
        Me.txtINUSDIRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtINUSDIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtINUSDIRE.ForeColor = System.Drawing.Color.Black
        Me.txtINUSDIRE.Location = New System.Drawing.Point(432, 72)
        Me.txtINUSDIRE.MaxLength = 49
        Me.txtINUSDIRE.Name = "txtINUSDIRE"
        Me.txtINUSDIRE.Size = New System.Drawing.Size(454, 20)
        Me.txtINUSDIRE.TabIndex = 8
        '
        'txtINUSSEAP
        '
        Me.txtINUSSEAP.AccessibleDescription = "Segundo apellido"
        Me.txtINUSSEAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtINUSSEAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtINUSSEAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtINUSSEAP.ForeColor = System.Drawing.Color.Black
        Me.txtINUSSEAP.Location = New System.Drawing.Point(719, 48)
        Me.txtINUSSEAP.MaxLength = 49
        Me.txtINUSSEAP.Name = "txtINUSSEAP"
        Me.txtINUSSEAP.Size = New System.Drawing.Size(167, 20)
        Me.txtINUSSEAP.TabIndex = 5
        '
        'txtINUSPRAP
        '
        Me.txtINUSPRAP.AccessibleDescription = "Primer apellido"
        Me.txtINUSPRAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtINUSPRAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtINUSPRAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtINUSPRAP.ForeColor = System.Drawing.Color.Black
        Me.txtINUSPRAP.Location = New System.Drawing.Point(432, 49)
        Me.txtINUSPRAP.MaxLength = 49
        Me.txtINUSPRAP.Name = "txtINUSPRAP"
        Me.txtINUSPRAP.Size = New System.Drawing.Size(164, 20)
        Me.txtINUSPRAP.TabIndex = 4
        '
        'txtINUSNUDO
        '
        Me.txtINUSNUDO.AccessibleDescription = "Nro. Documento"
        Me.txtINUSNUDO.BackColor = System.Drawing.SystemColors.Window
        Me.txtINUSNUDO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtINUSNUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtINUSNUDO.ForeColor = System.Drawing.Color.Black
        Me.txtINUSNUDO.Location = New System.Drawing.Point(137, 26)
        Me.txtINUSNUDO.MaxLength = 49
        Me.txtINUSNUDO.Name = "txtINUSNUDO"
        Me.txtINUSNUDO.Size = New System.Drawing.Size(171, 20)
        Me.txtINUSNUDO.TabIndex = 1
        '
        'txtINUSNOMB
        '
        Me.txtINUSNOMB.AccessibleDescription = "Nombre"
        Me.txtINUSNOMB.BackColor = System.Drawing.SystemColors.Window
        Me.txtINUSNOMB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtINUSNOMB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtINUSNOMB.ForeColor = System.Drawing.Color.Black
        Me.txtINUSNOMB.Location = New System.Drawing.Point(137, 49)
        Me.txtINUSNOMB.MaxLength = 49
        Me.txtINUSNOMB.Name = "txtINUSNOMB"
        Me.txtINUSNOMB.Size = New System.Drawing.Size(171, 20)
        Me.txtINUSNOMB.TabIndex = 3
        '
        'txtINUSTEL2
        '
        Me.txtINUSTEL2.AccessibleDescription = "Telefono 2 "
        Me.txtINUSTEL2.BackColor = System.Drawing.SystemColors.Window
        Me.txtINUSTEL2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtINUSTEL2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtINUSTEL2.ForeColor = System.Drawing.Color.Black
        Me.txtINUSTEL2.Location = New System.Drawing.Point(224, 72)
        Me.txtINUSTEL2.MaxLength = 49
        Me.txtINUSTEL2.Name = "txtINUSTEL2"
        Me.txtINUSTEL2.Size = New System.Drawing.Size(84, 20)
        Me.txtINUSTEL2.TabIndex = 7
        '
        'txtINUSTEL1
        '
        Me.txtINUSTEL1.AccessibleDescription = "Telefono 1 "
        Me.txtINUSTEL1.BackColor = System.Drawing.SystemColors.Window
        Me.txtINUSTEL1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtINUSTEL1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtINUSTEL1.ForeColor = System.Drawing.Color.Black
        Me.txtINUSTEL1.Location = New System.Drawing.Point(137, 72)
        Me.txtINUSTEL1.MaxLength = 49
        Me.txtINUSTEL1.Name = "txtINUSTEL1"
        Me.txtINUSTEL1.Size = New System.Drawing.Size(84, 20)
        Me.txtINUSTEL1.TabIndex = 6
        '
        'txtINUSFERE
        '
        Me.txtINUSFERE.AccessibleDescription = "Fecha de ingreso"
        Me.txtINUSFERE.BackColor = System.Drawing.Color.White
        Me.txtINUSFERE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtINUSFERE.Location = New System.Drawing.Point(432, 26)
        Me.txtINUSFERE.Mask = "00-00-0000"
        Me.txtINUSFERE.Name = "txtINUSFERE"
        Me.txtINUSFERE.Size = New System.Drawing.Size(164, 20)
        Me.txtINUSFERE.TabIndex = 2
        Me.txtINUSFERE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdSALIR)
        Me.GroupBox4.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 218)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(906, 49)
        Me.GroupBox4.TabIndex = 10
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
        Me.strBARRESTA.TabIndex = 342
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
        'frm_insertar_INFOUSUA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 305)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraINFOUSUA)
        Me.MaximumSize = New System.Drawing.Size(946, 341)
        Me.MinimumSize = New System.Drawing.Size(946, 341)
        Me.Name = "frm_insertar_INFOUSUA"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.fraINFOUSUA.ResumeLayout(False)
        Me.fraINFOUSUA.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtINUSOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents lblTelefonos As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents fraINFOUSUA As System.Windows.Forms.GroupBox
    Friend WithEvents txtINUSFERE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtINUSDIRE As System.Windows.Forms.TextBox
    Friend WithEvents txtINUSSEAP As System.Windows.Forms.TextBox
    Friend WithEvents txtINUSPRAP As System.Windows.Forms.TextBox
    Friend WithEvents txtINUSNUDO As System.Windows.Forms.TextBox
    Friend WithEvents txtINUSNOMB As System.Windows.Forms.TextBox
    Friend WithEvents txtINUSTEL2 As System.Windows.Forms.TextBox
    Friend WithEvents txtINUSTEL1 As System.Windows.Forms.TextBox
End Class
