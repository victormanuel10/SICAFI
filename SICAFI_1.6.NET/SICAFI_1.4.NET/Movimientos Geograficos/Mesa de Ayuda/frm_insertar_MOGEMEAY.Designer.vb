<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_MOGEMEAY
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
        Me.txtMGMAPEAS = New System.Windows.Forms.TextBox()
        Me.txtMGMAVERS = New System.Windows.Forms.TextBox()
        Me.txtMGMANURA = New System.Windows.Forms.TextBox()
        Me.txtMGMANUCA = New System.Windows.Forms.TextBox()
        Me.txtMGMAFERA = New System.Windows.Forms.MaskedTextBox()
        Me.lblNumeroDocumento = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMGMAOBSE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.GroupBox4.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraINFOUSUA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdSALIR)
        Me.GroupBox4.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 211)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(615, 49)
        Me.GroupBox4.TabIndex = 350
        Me.GroupBox4.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(314, 15)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(207, 15)
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
        Me.strBARRESTA.Size = New System.Drawing.Size(643, 25)
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
        Me.fraINFOUSUA.Controls.Add(Me.txtMGMAPEAS)
        Me.fraINFOUSUA.Controls.Add(Me.txtMGMAVERS)
        Me.fraINFOUSUA.Controls.Add(Me.txtMGMANURA)
        Me.fraINFOUSUA.Controls.Add(Me.txtMGMANUCA)
        Me.fraINFOUSUA.Controls.Add(Me.txtMGMAFERA)
        Me.fraINFOUSUA.Controls.Add(Me.lblNumeroDocumento)
        Me.fraINFOUSUA.Controls.Add(Me.Label11)
        Me.fraINFOUSUA.Controls.Add(Me.Label4)
        Me.fraINFOUSUA.Controls.Add(Me.txtMGMAOBSE)
        Me.fraINFOUSUA.Controls.Add(Me.Label2)
        Me.fraINFOUSUA.Controls.Add(Me.Label5)
        Me.fraINFOUSUA.Controls.Add(Me.lblDireccion)
        Me.fraINFOUSUA.Location = New System.Drawing.Point(12, 5)
        Me.fraINFOUSUA.Name = "fraINFOUSUA"
        Me.fraINFOUSUA.Size = New System.Drawing.Size(615, 200)
        Me.fraINFOUSUA.TabIndex = 349
        Me.fraINFOUSUA.TabStop = False
        Me.fraINFOUSUA.Text = "INSERTAR MESA DE AYUDA"
        '
        'txtMGMAPEAS
        '
        Me.txtMGMAPEAS.AccessibleDescription = "Personal asignado"
        Me.txtMGMAPEAS.BackColor = System.Drawing.SystemColors.Window
        Me.txtMGMAPEAS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMGMAPEAS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMGMAPEAS.ForeColor = System.Drawing.Color.Black
        Me.txtMGMAPEAS.Location = New System.Drawing.Point(137, 72)
        Me.txtMGMAPEAS.MaxLength = 50
        Me.txtMGMAPEAS.Name = "txtMGMAPEAS"
        Me.txtMGMAPEAS.Size = New System.Drawing.Size(459, 20)
        Me.txtMGMAPEAS.TabIndex = 5
        '
        'txtMGMAVERS
        '
        Me.txtMGMAVERS.AccessibleDescription = "Versión"
        Me.txtMGMAVERS.BackColor = System.Drawing.SystemColors.Window
        Me.txtMGMAVERS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMGMAVERS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMGMAVERS.ForeColor = System.Drawing.Color.Black
        Me.txtMGMAVERS.Location = New System.Drawing.Point(431, 49)
        Me.txtMGMAVERS.MaxLength = 10
        Me.txtMGMAVERS.Name = "txtMGMAVERS"
        Me.txtMGMAVERS.Size = New System.Drawing.Size(165, 20)
        Me.txtMGMAVERS.TabIndex = 4
        '
        'txtMGMANURA
        '
        Me.txtMGMANURA.AccessibleDescription = "Nro. Radicado"
        Me.txtMGMANURA.BackColor = System.Drawing.SystemColors.Window
        Me.txtMGMANURA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMGMANURA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMGMANURA.ForeColor = System.Drawing.Color.Black
        Me.txtMGMANURA.Location = New System.Drawing.Point(137, 26)
        Me.txtMGMANURA.MaxLength = 9
        Me.txtMGMANURA.Name = "txtMGMANURA"
        Me.txtMGMANURA.Size = New System.Drawing.Size(171, 20)
        Me.txtMGMANURA.TabIndex = 1
        '
        'txtMGMANUCA
        '
        Me.txtMGMANUCA.AccessibleDescription = "Nro. de Caso"
        Me.txtMGMANUCA.BackColor = System.Drawing.SystemColors.Window
        Me.txtMGMANUCA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMGMANUCA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMGMANUCA.ForeColor = System.Drawing.Color.Black
        Me.txtMGMANUCA.Location = New System.Drawing.Point(137, 49)
        Me.txtMGMANUCA.MaxLength = 9
        Me.txtMGMANUCA.Name = "txtMGMANUCA"
        Me.txtMGMANUCA.Size = New System.Drawing.Size(171, 20)
        Me.txtMGMANUCA.TabIndex = 3
        '
        'txtMGMAFERA
        '
        Me.txtMGMAFERA.AccessibleDescription = "Fecha de radicado"
        Me.txtMGMAFERA.BackColor = System.Drawing.Color.White
        Me.txtMGMAFERA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMGMAFERA.Location = New System.Drawing.Point(431, 26)
        Me.txtMGMAFERA.Mask = "00-00-0000"
        Me.txtMGMAFERA.Name = "txtMGMAFERA"
        Me.txtMGMAFERA.Size = New System.Drawing.Size(165, 20)
        Me.txtMGMAFERA.TabIndex = 2
        Me.txtMGMAFERA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.lblNumeroDocumento.Text = "Nro. Radicado"
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
        Me.Label11.Text = "Fecha de Radicado"
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
        Me.Label4.Text = "Nro. de Caso"
        '
        'txtMGMAOBSE
        '
        Me.txtMGMAOBSE.AccessibleDescription = "Observación"
        Me.txtMGMAOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtMGMAOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMGMAOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMGMAOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtMGMAOBSE.Location = New System.Drawing.Point(137, 95)
        Me.txtMGMAOBSE.MaxLength = 4000
        Me.txtMGMAOBSE.Multiline = True
        Me.txtMGMAOBSE.Name = "txtMGMAOBSE"
        Me.txtMGMAOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMGMAOBSE.Size = New System.Drawing.Size(459, 87)
        Me.txtMGMAOBSE.TabIndex = 6
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
        Me.Label5.Text = "Versión"
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
        Me.lblDireccion.Text = "Personal asignado"
        '
        'frm_MOGEMEAY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 305)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraINFOUSUA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(659, 341)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(659, 341)
        Me.Name = "frm_MOGEMEAY"
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
    Friend WithEvents txtMGMAPEAS As System.Windows.Forms.TextBox
    Friend WithEvents txtMGMAVERS As System.Windows.Forms.TextBox
    Friend WithEvents txtMGMANURA As System.Windows.Forms.TextBox
    Friend WithEvents txtMGMANUCA As System.Windows.Forms.TextBox
    Friend WithEvents txtMGMAFERA As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMGMAOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
End Class
