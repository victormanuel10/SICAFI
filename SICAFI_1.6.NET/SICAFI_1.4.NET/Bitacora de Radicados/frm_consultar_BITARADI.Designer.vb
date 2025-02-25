<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_BITARADI
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
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdCONSULTAR = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.fraRECLTROF = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMUDENUDO = New System.Windows.Forms.Label()
        Me.cboMUDENUDO = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboLIRAESTA = New System.Windows.Forms.ComboBox()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.fraRECLTROF.SuspendLayout()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 187)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(696, 25)
        Me.strBARRESTA.TabIndex = 362
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
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdCONSULTAR)
        Me.GroupBox4.Controls.Add(Me.cmdSALIR)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 126)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(671, 46)
        Me.GroupBox4.TabIndex = 361
        Me.GroupBox4.TabStop = False
        '
        'cmdCONSULTAR
        '
        Me.cmdCONSULTAR.AccessibleDescription = "Consultar"
        Me.cmdCONSULTAR.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdCONSULTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCONSULTAR.Location = New System.Drawing.Point(209, 15)
        Me.cmdCONSULTAR.Name = "cmdCONSULTAR"
        Me.cmdCONSULTAR.Size = New System.Drawing.Size(123, 23)
        Me.cmdCONSULTAR.TabIndex = 19
        Me.cmdCONSULTAR.Text = "&Consultar"
        Me.cmdCONSULTAR.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(338, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(126, 23)
        Me.cmdSALIR.TabIndex = 8
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'fraRECLTROF
        '
        Me.fraRECLTROF.Controls.Add(Me.Label1)
        Me.fraRECLTROF.Controls.Add(Me.cboLIRAESTA)
        Me.fraRECLTROF.Controls.Add(Me.Label2)
        Me.fraRECLTROF.Controls.Add(Me.txtMUDENUDO)
        Me.fraRECLTROF.Controls.Add(Me.cboMUDENUDO)
        Me.fraRECLTROF.Controls.Add(Me.Label4)
        Me.fraRECLTROF.ForeColor = System.Drawing.Color.Black
        Me.fraRECLTROF.Location = New System.Drawing.Point(12, 11)
        Me.fraRECLTROF.Name = "fraRECLTROF"
        Me.fraRECLTROF.Size = New System.Drawing.Size(671, 109)
        Me.fraRECLTROF.TabIndex = 360
        Me.fraRECLTROF.TabStop = False
        Me.fraRECLTROF.Text = "CONSULTAR FUNCIONARIO"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Cedula"
        '
        'txtMUDENUDO
        '
        Me.txtMUDENUDO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtMUDENUDO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtMUDENUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUDENUDO.ForeColor = System.Drawing.Color.Black
        Me.txtMUDENUDO.Location = New System.Drawing.Point(137, 49)
        Me.txtMUDENUDO.Name = "txtMUDENUDO"
        Me.txtMUDENUDO.Size = New System.Drawing.Size(517, 20)
        Me.txtMUDENUDO.TabIndex = 55
        '
        'cboMUDENUDO
        '
        Me.cboMUDENUDO.AccessibleDescription = "Funcionario"
        Me.cboMUDENUDO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMUDENUDO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMUDENUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMUDENUDO.FormattingEnabled = True
        Me.cboMUDENUDO.Location = New System.Drawing.Point(137, 24)
        Me.cboMUDENUDO.Name = "cboMUDENUDO"
        Me.cboMUDENUDO.Size = New System.Drawing.Size(517, 22)
        Me.cboMUDENUDO.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 20)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Funcionario"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 303
        Me.Label1.Text = "Estado"
        '
        'cboLIRAESTA
        '
        Me.cboLIRAESTA.AccessibleDescription = "Estado"
        Me.cboLIRAESTA.BackColor = System.Drawing.Color.White
        Me.cboLIRAESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboLIRAESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLIRAESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLIRAESTA.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11"})
        Me.cboLIRAESTA.Location = New System.Drawing.Point(137, 70)
        Me.cboLIRAESTA.MaxDropDownItems = 15
        Me.cboLIRAESTA.MaxLength = 2
        Me.cboLIRAESTA.Name = "cboLIRAESTA"
        Me.cboLIRAESTA.Size = New System.Drawing.Size(195, 22)
        Me.cboLIRAESTA.TabIndex = 2
        '
        'frm_consultar_BITARADI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 212)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.fraRECLTROF)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(712, 248)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(712, 248)
        Me.Name = "frm_consultar_BITARADI"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar registro"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.fraRECLTROF.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCONSULTAR As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents fraRECLTROF As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMUDENUDO As System.Windows.Forms.Label
    Friend WithEvents cboMUDENUDO As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboLIRAESTA As System.Windows.Forms.ComboBox
End Class
