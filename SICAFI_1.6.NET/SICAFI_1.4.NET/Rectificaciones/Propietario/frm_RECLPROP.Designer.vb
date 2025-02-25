<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_RECLPROP
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
        Me.dtpINUSFEEN = New System.Windows.Forms.DateTimePicker()
        Me.txtINUSFEEN = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtINUSSEAP = New System.Windows.Forms.TextBox()
        Me.txtINUSPRAP = New System.Windows.Forms.TextBox()
        Me.txtINUSNOMB = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRECLMAIN = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox4.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraINFOUSUA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdSALIR)
        Me.GroupBox4.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 131)
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
        Me.cmdSALIR.Location = New System.Drawing.Point(456, 15)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(349, 15)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 199)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(932, 25)
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
        Me.fraINFOUSUA.Controls.Add(Me.txtRECLMAIN)
        Me.fraINFOUSUA.Controls.Add(Me.TextBox3)
        Me.fraINFOUSUA.Controls.Add(Me.Label2)
        Me.fraINFOUSUA.Controls.Add(Me.Label1)
        Me.fraINFOUSUA.Controls.Add(Me.TextBox1)
        Me.fraINFOUSUA.Controls.Add(Me.dtpINUSFEEN)
        Me.fraINFOUSUA.Controls.Add(Me.txtINUSFEEN)
        Me.fraINFOUSUA.Controls.Add(Me.Label7)
        Me.fraINFOUSUA.Controls.Add(Me.Label3)
        Me.fraINFOUSUA.Controls.Add(Me.txtINUSSEAP)
        Me.fraINFOUSUA.Controls.Add(Me.txtINUSPRAP)
        Me.fraINFOUSUA.Controls.Add(Me.txtINUSNOMB)
        Me.fraINFOUSUA.Controls.Add(Me.Label4)
        Me.fraINFOUSUA.Controls.Add(Me.Label5)
        Me.fraINFOUSUA.Controls.Add(Me.Label6)
        Me.fraINFOUSUA.Location = New System.Drawing.Point(12, 12)
        Me.fraINFOUSUA.Name = "fraINFOUSUA"
        Me.fraINFOUSUA.Size = New System.Drawing.Size(906, 113)
        Me.fraINFOUSUA.TabIndex = 346
        Me.fraINFOUSUA.TabStop = False
        Me.fraINFOUSUA.Text = "INSERTAR PROPIETARIO O SOLICITANTE"
        '
        'dtpINUSFEEN
        '
        Me.dtpINUSFEEN.AccessibleDescription = "Fecha de entrega"
        Me.dtpINUSFEEN.Location = New System.Drawing.Point(869, 73)
        Me.dtpINUSFEEN.Name = "dtpINUSFEEN"
        Me.dtpINUSFEEN.Size = New System.Drawing.Size(19, 20)
        Me.dtpINUSFEEN.TabIndex = 5
        '
        'txtINUSFEEN
        '
        Me.txtINUSFEEN.AccessibleDescription = "Fecha de entrega"
        Me.txtINUSFEEN.BackColor = System.Drawing.Color.White
        Me.txtINUSFEEN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtINUSFEEN.Location = New System.Drawing.Point(718, 73)
        Me.txtINUSFEEN.Mask = "00-00-0000"
        Me.txtINUSFEEN.Name = "txtINUSFEEN"
        Me.txtINUSFEEN.Size = New System.Drawing.Size(147, 20)
        Me.txtINUSFEEN.TabIndex = 7
        Me.txtINUSFEEN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtINUSFEEN.ValidatingType = GetType(Date)
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(17, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 20)
        Me.Label7.TabIndex = 79
        Me.Label7.Text = "Matricula inmobiliaria"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(17, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 20)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "Nro. Documento"
        '
        'txtINUSSEAP
        '
        Me.txtINUSSEAP.AccessibleDescription = "Segundo apellido"
        Me.txtINUSSEAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtINUSSEAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtINUSSEAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtINUSSEAP.ForeColor = System.Drawing.Color.Black
        Me.txtINUSSEAP.Location = New System.Drawing.Point(717, 49)
        Me.txtINUSSEAP.MaxLength = 20
        Me.txtINUSSEAP.Name = "txtINUSSEAP"
        Me.txtINUSSEAP.Size = New System.Drawing.Size(171, 20)
        Me.txtINUSSEAP.TabIndex = 4
        '
        'txtINUSPRAP
        '
        Me.txtINUSPRAP.AccessibleDescription = "Primer apellido"
        Me.txtINUSPRAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtINUSPRAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtINUSPRAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtINUSPRAP.ForeColor = System.Drawing.Color.Black
        Me.txtINUSPRAP.Location = New System.Drawing.Point(430, 50)
        Me.txtINUSPRAP.MaxLength = 20
        Me.txtINUSPRAP.Name = "txtINUSPRAP"
        Me.txtINUSPRAP.Size = New System.Drawing.Size(164, 20)
        Me.txtINUSPRAP.TabIndex = 3
        '
        'txtINUSNOMB
        '
        Me.txtINUSNOMB.AccessibleDescription = "Nombre"
        Me.txtINUSNOMB.BackColor = System.Drawing.SystemColors.Window
        Me.txtINUSNOMB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtINUSNOMB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtINUSNOMB.ForeColor = System.Drawing.Color.Black
        Me.txtINUSNOMB.Location = New System.Drawing.Point(135, 50)
        Me.txtINUSNOMB.MaxLength = 20
        Me.txtINUSNOMB.Name = "txtINUSNOMB"
        Me.txtINUSNOMB.Size = New System.Drawing.Size(171, 20)
        Me.txtINUSNOMB.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(17, 50)
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
        Me.Label5.Location = New System.Drawing.Point(310, 50)
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
        Me.Label6.Location = New System.Drawing.Point(598, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 20)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "Segundo Apellido"
        '
        'TextBox1
        '
        Me.TextBox1.AccessibleDescription = "Nombre"
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(135, 27)
        Me.TextBox1.MaxLength = 14
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(171, 20)
        Me.TextBox1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(598, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 20)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "Fecha Rad. OVC N°"
        '
        'TextBox3
        '
        Me.TextBox3.AccessibleDescription = "Primer apellido"
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.Black
        Me.TextBox3.Location = New System.Drawing.Point(430, 73)
        Me.TextBox3.MaxLength = 9
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(164, 20)
        Me.TextBox3.TabIndex = 6
        Me.TextBox3.Text = "0"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(310, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 20)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "Radicado OVC N°"
        '
        'txtRECLMAIN
        '
        Me.txtRECLMAIN.AccessibleDescription = "Matricula"
        Me.txtRECLMAIN.BackColor = System.Drawing.Color.White
        Me.txtRECLMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECLMAIN.Location = New System.Drawing.Point(135, 72)
        Me.txtRECLMAIN.Mask = "000-0000000"
        Me.txtRECLMAIN.Name = "txtRECLMAIN"
        Me.txtRECLMAIN.Size = New System.Drawing.Size(171, 20)
        Me.txtRECLMAIN.TabIndex = 5
        Me.txtRECLMAIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frm_RECLPROP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 224)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraINFOUSUA)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_RECLPROP"
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
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents dtpINUSFEEN As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtINUSFEEN As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtINUSSEAP As System.Windows.Forms.TextBox
    Friend WithEvents txtINUSPRAP As System.Windows.Forms.TextBox
    Friend WithEvents txtINUSNOMB As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRECLMAIN As System.Windows.Forms.MaskedTextBox
End Class
