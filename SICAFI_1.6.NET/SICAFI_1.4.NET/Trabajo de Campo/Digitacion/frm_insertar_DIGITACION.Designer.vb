<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_DIGITACION
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
        Me.fraDIGITACION = New System.Windows.Forms.GroupBox()
        Me.dtpDIGIFERE = New System.Windows.Forms.DateTimePicker()
        Me.dtpDIGIFEEN = New System.Windows.Forms.DateTimePicker()
        Me.txtDIGIFERE = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDIGIOBSE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDIGIFEEN = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDIGINUDO = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.cboDIGINUDO = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox4.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraDIGITACION.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdSALIR)
        Me.GroupBox4.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 206)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(671, 46)
        Me.GroupBox4.TabIndex = 351
        Me.GroupBox4.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(342, 15)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(235, 15)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 269)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(697, 25)
        Me.strBARRESTA.TabIndex = 352
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
        'fraDIGITACION
        '
        Me.fraDIGITACION.Controls.Add(Me.dtpDIGIFERE)
        Me.fraDIGITACION.Controls.Add(Me.dtpDIGIFEEN)
        Me.fraDIGITACION.Controls.Add(Me.txtDIGIFERE)
        Me.fraDIGITACION.Controls.Add(Me.Label3)
        Me.fraDIGITACION.Controls.Add(Me.txtDIGIOBSE)
        Me.fraDIGITACION.Controls.Add(Me.Label1)
        Me.fraDIGITACION.Controls.Add(Me.txtDIGIFEEN)
        Me.fraDIGITACION.Controls.Add(Me.Label2)
        Me.fraDIGITACION.Controls.Add(Me.txtDIGINUDO)
        Me.fraDIGITACION.Controls.Add(Me.Label39)
        Me.fraDIGITACION.Controls.Add(Me.cboDIGINUDO)
        Me.fraDIGITACION.Controls.Add(Me.Label4)
        Me.fraDIGITACION.ForeColor = System.Drawing.Color.Black
        Me.fraDIGITACION.Location = New System.Drawing.Point(12, 6)
        Me.fraDIGITACION.Name = "fraDIGITACION"
        Me.fraDIGITACION.Size = New System.Drawing.Size(671, 194)
        Me.fraDIGITACION.TabIndex = 350
        Me.fraDIGITACION.TabStop = False
        Me.fraDIGITACION.Text = "INSERTA DIGITACIÓN"
        '
        'dtpDIGIFERE
        '
        Me.dtpDIGIFERE.Location = New System.Drawing.Point(636, 72)
        Me.dtpDIGIFERE.MaxDate = New Date(3000, 3, 15, 0, 0, 0, 0)
        Me.dtpDIGIFERE.Name = "dtpDIGIFERE"
        Me.dtpDIGIFERE.Size = New System.Drawing.Size(17, 20)
        Me.dtpDIGIFERE.TabIndex = 482
        Me.dtpDIGIFERE.Value = New Date(2011, 3, 15, 0, 0, 0, 0)
        '
        'dtpDIGIFEEN
        '
        Me.dtpDIGIFEEN.Location = New System.Drawing.Point(310, 72)
        Me.dtpDIGIFEEN.MaxDate = New Date(3000, 3, 15, 0, 0, 0, 0)
        Me.dtpDIGIFEEN.Name = "dtpDIGIFEEN"
        Me.dtpDIGIFEEN.Size = New System.Drawing.Size(17, 20)
        Me.dtpDIGIFEEN.TabIndex = 481
        Me.dtpDIGIFEEN.Value = New Date(2011, 3, 15, 0, 0, 0, 0)
        '
        'txtDIGIFERE
        '
        Me.txtDIGIFERE.AccessibleDescription = "Fecha de recibido"
        Me.txtDIGIFERE.BackColor = System.Drawing.Color.White
        Me.txtDIGIFERE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIGIFERE.Location = New System.Drawing.Point(447, 72)
        Me.txtDIGIFERE.Mask = "00-00-0000"
        Me.txtDIGIFERE.Name = "txtDIGIFERE"
        Me.txtDIGIFERE.Size = New System.Drawing.Size(183, 20)
        Me.txtDIGIFERE.TabIndex = 3
        Me.txtDIGIFERE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(331, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 343
        Me.Label3.Text = "Fecha finalización"
        '
        'txtDIGIOBSE
        '
        Me.txtDIGIOBSE.AccessibleDescription = "Observación"
        Me.txtDIGIOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtDIGIOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDIGIOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIGIOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtDIGIOBSE.Location = New System.Drawing.Point(19, 118)
        Me.txtDIGIOBSE.MaxLength = 1000
        Me.txtDIGIOBSE.Multiline = True
        Me.txtDIGIOBSE.Name = "txtDIGIOBSE"
        Me.txtDIGIOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDIGIOBSE.Size = New System.Drawing.Size(635, 56)
        Me.txtDIGIOBSE.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(635, 20)
        Me.Label1.TabIndex = 340
        Me.Label1.Text = "Observación"
        '
        'txtDIGIFEEN
        '
        Me.txtDIGIFEEN.AccessibleDescription = "Fecha de entrega"
        Me.txtDIGIFEEN.BackColor = System.Drawing.Color.White
        Me.txtDIGIFEEN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIGIFEEN.Location = New System.Drawing.Point(137, 72)
        Me.txtDIGIFEEN.Mask = "00-00-0000"
        Me.txtDIGIFEEN.Name = "txtDIGIFEEN"
        Me.txtDIGIFEEN.Size = New System.Drawing.Size(169, 20)
        Me.txtDIGIFEEN.TabIndex = 2
        Me.txtDIGIFEEN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        'txtDIGINUDO
        '
        Me.txtDIGINUDO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtDIGINUDO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtDIGINUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIGINUDO.ForeColor = System.Drawing.Color.Black
        Me.txtDIGINUDO.Location = New System.Drawing.Point(137, 49)
        Me.txtDIGINUDO.Name = "txtDIGINUDO"
        Me.txtDIGINUDO.Size = New System.Drawing.Size(517, 20)
        Me.txtDIGINUDO.TabIndex = 55
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label39.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(19, 72)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(112, 20)
        Me.Label39.TabIndex = 338
        Me.Label39.Text = "Fecha asignación"
        '
        'cboDIGINUDO
        '
        Me.cboDIGINUDO.AccessibleDescription = "Funcionario"
        Me.cboDIGINUDO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDIGINUDO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDIGINUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDIGINUDO.FormattingEnabled = True
        Me.cboDIGINUDO.Location = New System.Drawing.Point(137, 24)
        Me.cboDIGINUDO.Name = "cboDIGINUDO"
        Me.cboDIGINUDO.Size = New System.Drawing.Size(517, 22)
        Me.cboDIGINUDO.TabIndex = 1
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
        'frm_insertar_DIGITACION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 294)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraDIGITACION)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(713, 330)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(713, 330)
        Me.Name = "frm_insertar_DIGITACION"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox4.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraDIGITACION.ResumeLayout(False)
        Me.fraDIGITACION.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraDIGITACION As System.Windows.Forms.GroupBox
    Friend WithEvents txtDIGIFERE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDIGIOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDIGIFEEN As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDIGINUDO As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents cboDIGINUDO As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpDIGIFEEN As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDIGIFERE As System.Windows.Forms.DateTimePicker
End Class
