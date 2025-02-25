<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_PERMCOCO
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraPERMCOCO = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbdPECCHABI = New System.Windows.Forms.RadioButton()
        Me.rbdPECCDESH = New System.Windows.Forms.RadioButton()
        Me.lblPECCUSUA = New System.Windows.Forms.Label()
        Me.cboPECCCOCO = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboPECCUSUA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboPECCFORM = New System.Windows.Forms.ComboBox()
        Me.lblMUNICIPIO = New System.Windows.Forms.Label()
        Me.cboPECCESTA = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraPERMCOCO.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 152)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(749, 52)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(376, 17)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 9
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(269, 17)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 8
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 216)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(774, 25)
        Me.strBARRESTA.TabIndex = 36
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
        'fraPERMCOCO
        '
        Me.fraPERMCOCO.BackColor = System.Drawing.SystemColors.Control
        Me.fraPERMCOCO.Controls.Add(Me.GroupBox2)
        Me.fraPERMCOCO.Controls.Add(Me.lblPECCUSUA)
        Me.fraPERMCOCO.Controls.Add(Me.cboPECCCOCO)
        Me.fraPERMCOCO.Controls.Add(Me.Label2)
        Me.fraPERMCOCO.Controls.Add(Me.Label3)
        Me.fraPERMCOCO.Controls.Add(Me.cboPECCUSUA)
        Me.fraPERMCOCO.Controls.Add(Me.Label4)
        Me.fraPERMCOCO.Controls.Add(Me.cboPECCFORM)
        Me.fraPERMCOCO.Controls.Add(Me.lblMUNICIPIO)
        Me.fraPERMCOCO.Controls.Add(Me.cboPECCESTA)
        Me.fraPERMCOCO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPERMCOCO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPERMCOCO.Location = New System.Drawing.Point(12, 8)
        Me.fraPERMCOCO.Name = "fraPERMCOCO"
        Me.fraPERMCOCO.Size = New System.Drawing.Size(749, 138)
        Me.fraPERMCOCO.TabIndex = 35
        Me.fraPERMCOCO.TabStop = False
        Me.fraPERMCOCO.Text = "MODIFICAR PERMISO CONTROL DE COMANDOS"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbdPECCHABI)
        Me.GroupBox2.Controls.Add(Me.rbdPECCDESH)
        Me.GroupBox2.Location = New System.Drawing.Point(405, 75)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(328, 45)
        Me.GroupBox2.TabIndex = 60
        Me.GroupBox2.TabStop = False
        '
        'rbdPECCHABI
        '
        Me.rbdPECCHABI.Checked = True
        Me.rbdPECCHABI.Location = New System.Drawing.Point(77, 16)
        Me.rbdPECCHABI.Name = "rbdPECCHABI"
        Me.rbdPECCHABI.Size = New System.Drawing.Size(90, 17)
        Me.rbdPECCHABI.TabIndex = 5
        Me.rbdPECCHABI.TabStop = True
        Me.rbdPECCHABI.Text = "Habilitar"
        Me.rbdPECCHABI.UseVisualStyleBackColor = True
        '
        'rbdPECCDESH
        '
        Me.rbdPECCDESH.Location = New System.Drawing.Point(167, 16)
        Me.rbdPECCDESH.Name = "rbdPECCDESH"
        Me.rbdPECCDESH.Size = New System.Drawing.Size(99, 17)
        Me.rbdPECCDESH.TabIndex = 6
        Me.rbdPECCDESH.Text = "Deshabilitar"
        Me.rbdPECCDESH.UseVisualStyleBackColor = True
        '
        'lblPECCUSUA
        '
        Me.lblPECCUSUA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPECCUSUA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPECCUSUA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPECCUSUA.ForeColor = System.Drawing.Color.Black
        Me.lblPECCUSUA.Location = New System.Drawing.Point(403, 26)
        Me.lblPECCUSUA.Name = "lblPECCUSUA"
        Me.lblPECCUSUA.Size = New System.Drawing.Size(330, 20)
        Me.lblPECCUSUA.TabIndex = 59
        '
        'cboPECCCOCO
        '
        Me.cboPECCCOCO.AccessibleDescription = "Comandos"
        Me.cboPECCCOCO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPECCCOCO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPECCCOCO.Enabled = False
        Me.cboPECCCOCO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPECCCOCO.FormattingEnabled = True
        Me.cboPECCCOCO.Location = New System.Drawing.Point(134, 74)
        Me.cboPECCCOCO.Name = "cboPECCCOCO"
        Me.cboPECCCOCO.Size = New System.Drawing.Size(265, 22)
        Me.cboPECCCOCO.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Control comandos"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'cboPECCUSUA
        '
        Me.cboPECCUSUA.AccessibleDescription = "Usuario"
        Me.cboPECCUSUA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPECCUSUA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPECCUSUA.Enabled = False
        Me.cboPECCUSUA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPECCUSUA.FormattingEnabled = True
        Me.cboPECCUSUA.Location = New System.Drawing.Point(134, 26)
        Me.cboPECCUSUA.Name = "cboPECCUSUA"
        Me.cboPECCUSUA.Size = New System.Drawing.Size(265, 22)
        Me.cboPECCUSUA.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 20)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Usuario"
        '
        'cboPECCFORM
        '
        Me.cboPECCFORM.AccessibleDescription = "Formulario"
        Me.cboPECCFORM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPECCFORM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPECCFORM.Enabled = False
        Me.cboPECCFORM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPECCFORM.FormattingEnabled = True
        Me.cboPECCFORM.Location = New System.Drawing.Point(134, 50)
        Me.cboPECCFORM.Name = "cboPECCFORM"
        Me.cboPECCFORM.Size = New System.Drawing.Size(599, 22)
        Me.cboPECCFORM.TabIndex = 2
        '
        'lblMUNICIPIO
        '
        Me.lblMUNICIPIO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMUNICIPIO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUNICIPIO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUNICIPIO.ForeColor = System.Drawing.Color.Black
        Me.lblMUNICIPIO.Location = New System.Drawing.Point(19, 51)
        Me.lblMUNICIPIO.Name = "lblMUNICIPIO"
        Me.lblMUNICIPIO.Size = New System.Drawing.Size(112, 20)
        Me.lblMUNICIPIO.TabIndex = 49
        Me.lblMUNICIPIO.Text = "Formulario"
        '
        'cboPECCESTA
        '
        Me.cboPECCESTA.AccessibleDescription = "Estado"
        Me.cboPECCESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPECCESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPECCESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPECCESTA.FormattingEnabled = True
        Me.cboPECCESTA.Location = New System.Drawing.Point(134, 98)
        Me.cboPECCESTA.Name = "cboPECCESTA"
        Me.cboPECCESTA.Size = New System.Drawing.Size(265, 22)
        Me.cboPECCESTA.TabIndex = 4
        '
        'frm_modificar_PERMCOCO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 241)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraPERMCOCO)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(790, 277)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(790, 277)
        Me.Name = "frm_modificar_PERMCOCO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraPERMCOCO.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraPERMCOCO As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdPECCHABI As System.Windows.Forms.RadioButton
    Friend WithEvents rbdPECCDESH As System.Windows.Forms.RadioButton
    Friend WithEvents lblPECCUSUA As System.Windows.Forms.Label
    Friend WithEvents cboPECCCOCO As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboPECCUSUA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboPECCFORM As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cboPECCESTA As System.Windows.Forms.ComboBox
End Class
