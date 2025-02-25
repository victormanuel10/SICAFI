<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_CIRCREGI
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.cmdGUARDAR = New System.Windows.Forms.Button
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.fraCIRCREGI = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboCIREESTA = New System.Windows.Forms.ComboBox
        Me.lblCIREDEPA = New System.Windows.Forms.Label
        Me.cboCIREDEPA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblCIREMUNI = New System.Windows.Forms.Label
        Me.cboCIREMUNI = New System.Windows.Forms.ComboBox
        Me.lblMUNICIPIO = New System.Windows.Forms.Label
        Me.txtCIREDESC = New System.Windows.Forms.TextBox
        Me.txtCIRECIRE = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraCIRCREGI.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 170)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(588, 52)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(293, 17)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(186, 17)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 238)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(613, 25)
        Me.strBARRESTA.TabIndex = 33
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
        'fraCIRCREGI
        '
        Me.fraCIRCREGI.BackColor = System.Drawing.SystemColors.Control
        Me.fraCIRCREGI.Controls.Add(Me.Label3)
        Me.fraCIRCREGI.Controls.Add(Me.cboCIREESTA)
        Me.fraCIRCREGI.Controls.Add(Me.lblCIREDEPA)
        Me.fraCIRCREGI.Controls.Add(Me.cboCIREDEPA)
        Me.fraCIRCREGI.Controls.Add(Me.Label4)
        Me.fraCIRCREGI.Controls.Add(Me.lblCIREMUNI)
        Me.fraCIRCREGI.Controls.Add(Me.cboCIREMUNI)
        Me.fraCIRCREGI.Controls.Add(Me.lblMUNICIPIO)
        Me.fraCIRCREGI.Controls.Add(Me.txtCIREDESC)
        Me.fraCIRCREGI.Controls.Add(Me.txtCIRECIRE)
        Me.fraCIRCREGI.Controls.Add(Me.Label1)
        Me.fraCIRCREGI.Controls.Add(Me.lblCodigo)
        Me.fraCIRCREGI.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraCIRCREGI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraCIRCREGI.Location = New System.Drawing.Point(12, 5)
        Me.fraCIRCREGI.Name = "fraCIRCREGI"
        Me.fraCIRCREGI.Size = New System.Drawing.Size(588, 159)
        Me.fraCIRCREGI.TabIndex = 32
        Me.fraCIRCREGI.TabStop = False
        Me.fraCIRCREGI.Text = "INSERTAR CIRCULO DE REGISTRO"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'cboCIREESTA
        '
        Me.cboCIREESTA.AccessibleDescription = "Estado"
        Me.cboCIREESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCIREESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCIREESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCIREESTA.FormattingEnabled = True
        Me.cboCIREESTA.Location = New System.Drawing.Point(153, 120)
        Me.cboCIREESTA.Name = "cboCIREESTA"
        Me.cboCIREESTA.Size = New System.Drawing.Size(291, 22)
        Me.cboCIREESTA.TabIndex = 10
        '
        'lblCIREDEPA
        '
        Me.lblCIREDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCIREDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCIREDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCIREDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblCIREDEPA.Location = New System.Drawing.Point(450, 28)
        Me.lblCIREDEPA.Name = "lblCIREDEPA"
        Me.lblCIREDEPA.Size = New System.Drawing.Size(124, 20)
        Me.lblCIREDEPA.TabIndex = 52
        '
        'cboCIREDEPA
        '
        Me.cboCIREDEPA.AccessibleDescription = "Departamento"
        Me.cboCIREDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCIREDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCIREDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCIREDEPA.FormattingEnabled = True
        Me.cboCIREDEPA.Location = New System.Drawing.Point(153, 26)
        Me.cboCIREDEPA.Name = "cboCIREDEPA"
        Me.cboCIREDEPA.Size = New System.Drawing.Size(291, 22)
        Me.cboCIREDEPA.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 20)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Departamento"
        '
        'lblCIREMUNI
        '
        Me.lblCIREMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCIREMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCIREMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCIREMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblCIREMUNI.Location = New System.Drawing.Point(450, 51)
        Me.lblCIREMUNI.Name = "lblCIREMUNI"
        Me.lblCIREMUNI.Size = New System.Drawing.Size(124, 20)
        Me.lblCIREMUNI.TabIndex = 50
        '
        'cboCIREMUNI
        '
        Me.cboCIREMUNI.AccessibleDescription = "Municipio"
        Me.cboCIREMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCIREMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCIREMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCIREMUNI.FormattingEnabled = True
        Me.cboCIREMUNI.Location = New System.Drawing.Point(153, 49)
        Me.cboCIREMUNI.Name = "cboCIREMUNI"
        Me.cboCIREMUNI.Size = New System.Drawing.Size(291, 22)
        Me.cboCIREMUNI.TabIndex = 2
        '
        'lblMUNICIPIO
        '
        Me.lblMUNICIPIO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMUNICIPIO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUNICIPIO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUNICIPIO.ForeColor = System.Drawing.Color.Black
        Me.lblMUNICIPIO.Location = New System.Drawing.Point(19, 51)
        Me.lblMUNICIPIO.Name = "lblMUNICIPIO"
        Me.lblMUNICIPIO.Size = New System.Drawing.Size(130, 20)
        Me.lblMUNICIPIO.TabIndex = 49
        Me.lblMUNICIPIO.Text = "Municipio"
        '
        'txtCIREDESC
        '
        Me.txtCIREDESC.AccessibleDescription = "Descripción"
        Me.txtCIREDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtCIREDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCIREDESC.Location = New System.Drawing.Point(153, 97)
        Me.txtCIREDESC.MaxLength = 50
        Me.txtCIREDESC.Name = "txtCIREDESC"
        Me.txtCIREDESC.Size = New System.Drawing.Size(421, 20)
        Me.txtCIREDESC.TabIndex = 5
        '
        'txtCIRECIRE
        '
        Me.txtCIRECIRE.AccessibleDescription = "Circulo de registro"
        Me.txtCIRECIRE.BackColor = System.Drawing.SystemColors.Window
        Me.txtCIRECIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCIRECIRE.Location = New System.Drawing.Point(153, 74)
        Me.txtCIRECIRE.MaxLength = 9
        Me.txtCIRECIRE.Name = "txtCIRECIRE"
        Me.txtCIRECIRE.Size = New System.Drawing.Size(112, 20)
        Me.txtCIRECIRE.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 20)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Descripción"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(19, 74)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(130, 20)
        Me.lblCodigo.TabIndex = 37
        Me.lblCodigo.Text = "Circulo de registro"
        '
        'frm_insertar_CIRCREGI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 263)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCIRCREGI)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(629, 299)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(629, 299)
        Me.Name = "frm_insertar_CIRCREGI"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraCIRCREGI.ResumeLayout(False)
        Me.fraCIRCREGI.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraCIRCREGI As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCIREESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCIREDEPA As System.Windows.Forms.Label
    Friend WithEvents cboCIREDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCIREMUNI As System.Windows.Forms.Label
    Friend WithEvents cboCIREMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents txtCIREDESC As System.Windows.Forms.TextBox
    Friend WithEvents txtCIRECIRE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
End Class
