<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_LIRADEDI
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
        Me.fraRECLTRCA = New System.Windows.Forms.GroupBox()
        Me.dtpLRDDFEDE = New System.Windows.Forms.DateTimePicker()
        Me.txtLRDDFEDE = New System.Windows.Forms.MaskedTextBox()
        Me.txtLRDDNRDE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblLRDDDIVI = New System.Windows.Forms.Label()
        Me.txtLRDDFEAS = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.cboLRDDDIVI = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox4.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraRECLTRCA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdSALIR)
        Me.GroupBox4.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 147)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(644, 46)
        Me.GroupBox4.TabIndex = 354
        Me.GroupBox4.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(325, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 8
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(218, 15)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 7
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 212)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(668, 25)
        Me.strBARRESTA.TabIndex = 355
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
        'fraRECLTRCA
        '
        Me.fraRECLTRCA.Controls.Add(Me.dtpLRDDFEDE)
        Me.fraRECLTRCA.Controls.Add(Me.txtLRDDFEDE)
        Me.fraRECLTRCA.Controls.Add(Me.txtLRDDNRDE)
        Me.fraRECLTRCA.Controls.Add(Me.Label1)
        Me.fraRECLTRCA.Controls.Add(Me.lblLRDDDIVI)
        Me.fraRECLTRCA.Controls.Add(Me.txtLRDDFEAS)
        Me.fraRECLTRCA.Controls.Add(Me.Label2)
        Me.fraRECLTRCA.Controls.Add(Me.Label39)
        Me.fraRECLTRCA.Controls.Add(Me.cboLRDDDIVI)
        Me.fraRECLTRCA.Controls.Add(Me.Label4)
        Me.fraRECLTRCA.ForeColor = System.Drawing.Color.Black
        Me.fraRECLTRCA.Location = New System.Drawing.Point(12, 8)
        Me.fraRECLTRCA.Name = "fraRECLTRCA"
        Me.fraRECLTRCA.Size = New System.Drawing.Size(644, 133)
        Me.fraRECLTRCA.TabIndex = 353
        Me.fraRECLTRCA.TabStop = False
        Me.fraRECLTRCA.Text = "DESTINATARIO DIVISIÓN"
        '
        'dtpLRDDFEDE
        '
        Me.dtpLRDDFEDE.Location = New System.Drawing.Point(336, 95)
        Me.dtpLRDDFEDE.Name = "dtpLRDDFEDE"
        Me.dtpLRDDFEDE.Size = New System.Drawing.Size(21, 20)
        Me.dtpLRDDFEDE.TabIndex = 433
        '
        'txtLRDDFEDE
        '
        Me.txtLRDDFEDE.AccessibleDescription = "Fecha de radicado"
        Me.txtLRDDFEDE.BackColor = System.Drawing.Color.White
        Me.txtLRDDFEDE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRDDFEDE.Location = New System.Drawing.Point(173, 95)
        Me.txtLRDDFEDE.Mask = "00-00-0000"
        Me.txtLRDDFEDE.Name = "txtLRDDFEDE"
        Me.txtLRDDFEDE.Size = New System.Drawing.Size(160, 20)
        Me.txtLRDDFEDE.TabIndex = 4
        '
        'txtLRDDNRDE
        '
        Me.txtLRDDNRDE.AccessibleDescription = "Nro. Radicado"
        Me.txtLRDDNRDE.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRDDNRDE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRDDNRDE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRDDNRDE.ForeColor = System.Drawing.Color.Black
        Me.txtLRDDNRDE.Location = New System.Drawing.Point(173, 72)
        Me.txtLRDDNRDE.MaxLength = 9
        Me.txtLRDDNRDE.Name = "txtLRDDNRDE"
        Me.txtLRDDNRDE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLRDDNRDE.Size = New System.Drawing.Size(160, 20)
        Me.txtLRDDNRDE.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 20)
        Me.Label1.TabIndex = 340
        Me.Label1.Text = "Fecha de radicado"
        '
        'lblLRDDDIVI
        '
        Me.lblLRDDDIVI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblLRDDDIVI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLRDDDIVI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLRDDDIVI.ForeColor = System.Drawing.Color.Black
        Me.lblLRDDDIVI.Location = New System.Drawing.Point(484, 26)
        Me.lblLRDDDIVI.Name = "lblLRDDDIVI"
        Me.lblLRDDDIVI.Size = New System.Drawing.Size(141, 20)
        Me.lblLRDDDIVI.TabIndex = 55
        '
        'txtLRDDFEAS
        '
        Me.txtLRDDFEAS.AccessibleDescription = "Fecha de asignación"
        Me.txtLRDDFEAS.BackColor = System.Drawing.Color.White
        Me.txtLRDDFEAS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRDDFEAS.Location = New System.Drawing.Point(173, 49)
        Me.txtLRDDFEAS.Mask = "00-00-0000"
        Me.txtLRDDFEAS.Name = "txtLRDDFEAS"
        Me.txtLRDDFEAS.ReadOnly = True
        Me.txtLRDDFEAS.Size = New System.Drawing.Size(160, 20)
        Me.txtLRDDFEAS.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 20)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Fecha de asignación"
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label39.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(19, 72)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(150, 20)
        Me.Label39.TabIndex = 338
        Me.Label39.Text = "Nro. Radicado"
        '
        'cboLRDDDIVI
        '
        Me.cboLRDDDIVI.AccessibleDescription = "División"
        Me.cboLRDDDIVI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboLRDDDIVI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLRDDDIVI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLRDDDIVI.FormattingEnabled = True
        Me.cboLRDDDIVI.Location = New System.Drawing.Point(173, 24)
        Me.cboLRDDDIVI.Name = "cboLRDDDIVI"
        Me.cboLRDDDIVI.Size = New System.Drawing.Size(307, 22)
        Me.cboLRDDDIVI.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 20)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "División"
        '
        'frm_insertar_LIRADEDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 237)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraRECLTRCA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(684, 273)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(684, 273)
        Me.Name = "frm_insertar_LIRADEDI"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox4.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraRECLTRCA.ResumeLayout(False)
        Me.fraRECLTRCA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraRECLTRCA As System.Windows.Forms.GroupBox
    Friend WithEvents txtLRDDNRDE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLRDDFEAS As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblLRDDDIVI As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents cboLRDDDIVI As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpLRDDFEDE As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtLRDDFEDE As System.Windows.Forms.MaskedTextBox
End Class
