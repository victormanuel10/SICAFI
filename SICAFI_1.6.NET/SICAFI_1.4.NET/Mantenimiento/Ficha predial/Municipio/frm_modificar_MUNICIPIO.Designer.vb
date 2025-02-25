<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_MUNICIPIO
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.fraMUNICIPIO = New System.Windows.Forms.GroupBox
        Me.lblMUNIDEPA = New System.Windows.Forms.Label
        Me.cboMUNIDEPA = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtMUNIRAFI = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtMUNIRAIN = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboMUNIESTA = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtMUNIDESC = New System.Windows.Forms.TextBox
        Me.txtMUNICODI = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblCódigo = New System.Windows.Forms.Label
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.cmdGUARDAR = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.strBARRESTA.SuspendLayout()
        Me.fraMUNICIPIO.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 249)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(599, 25)
        Me.strBARRESTA.TabIndex = 28
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
        'fraMUNICIPIO
        '
        Me.fraMUNICIPIO.BackColor = System.Drawing.SystemColors.Control
        Me.fraMUNICIPIO.Controls.Add(Me.lblMUNIDEPA)
        Me.fraMUNICIPIO.Controls.Add(Me.cboMUNIDEPA)
        Me.fraMUNICIPIO.Controls.Add(Me.Label5)
        Me.fraMUNICIPIO.Controls.Add(Me.txtMUNIRAFI)
        Me.fraMUNICIPIO.Controls.Add(Me.Label4)
        Me.fraMUNICIPIO.Controls.Add(Me.txtMUNIRAIN)
        Me.fraMUNICIPIO.Controls.Add(Me.Label3)
        Me.fraMUNICIPIO.Controls.Add(Me.cboMUNIESTA)
        Me.fraMUNICIPIO.Controls.Add(Me.Label2)
        Me.fraMUNICIPIO.Controls.Add(Me.txtMUNIDESC)
        Me.fraMUNICIPIO.Controls.Add(Me.txtMUNICODI)
        Me.fraMUNICIPIO.Controls.Add(Me.Label1)
        Me.fraMUNICIPIO.Controls.Add(Me.lblCódigo)
        Me.fraMUNICIPIO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraMUNICIPIO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraMUNICIPIO.Location = New System.Drawing.Point(12, 2)
        Me.fraMUNICIPIO.Name = "fraMUNICIPIO"
        Me.fraMUNICIPIO.Size = New System.Drawing.Size(572, 176)
        Me.fraMUNICIPIO.TabIndex = 27
        Me.fraMUNICIPIO.TabStop = False
        Me.fraMUNICIPIO.Text = "MODIFICAR MUNICIPIO"
        '
        'lblMUNIDEPA
        '
        Me.lblMUNIDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblMUNIDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUNIDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUNIDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblMUNIDEPA.Location = New System.Drawing.Point(252, 25)
        Me.lblMUNIDEPA.Name = "lblMUNIDEPA"
        Me.lblMUNIDEPA.Size = New System.Drawing.Size(302, 20)
        Me.lblMUNIDEPA.TabIndex = 60
        '
        'cboMUNIDEPA
        '
        Me.cboMUNIDEPA.AccessibleDescription = "Departamento"
        Me.cboMUNIDEPA.BackColor = System.Drawing.SystemColors.Window
        Me.cboMUNIDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMUNIDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMUNIDEPA.Enabled = False
        Me.cboMUNIDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMUNIDEPA.FormattingEnabled = True
        Me.cboMUNIDEPA.Location = New System.Drawing.Point(132, 24)
        Me.cboMUNIDEPA.Name = "cboMUNIDEPA"
        Me.cboMUNIDEPA.Size = New System.Drawing.Size(114, 22)
        Me.cboMUNIDEPA.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(15, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Departamento"
        '
        'txtMUNIRAFI
        '
        Me.txtMUNIRAFI.AccessibleDescription = "Rango ficha final"
        Me.txtMUNIRAFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUNIRAFI.Enabled = False
        Me.txtMUNIRAFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUNIRAFI.Location = New System.Drawing.Point(132, 117)
        Me.txtMUNIRAFI.MaxLength = 8
        Me.txtMUNIRAFI.Name = "txtMUNIRAFI"
        Me.txtMUNIRAFI.Size = New System.Drawing.Size(114, 20)
        Me.txtMUNIRAFI.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(15, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 20)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Rango ficha final"
        '
        'txtMUNIRAIN
        '
        Me.txtMUNIRAIN.AccessibleDescription = "Rango ficha inicial"
        Me.txtMUNIRAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUNIRAIN.Enabled = False
        Me.txtMUNIRAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUNIRAIN.Location = New System.Drawing.Point(132, 94)
        Me.txtMUNIRAIN.MaxLength = 8
        Me.txtMUNIRAIN.Name = "txtMUNIRAIN"
        Me.txtMUNIRAIN.Size = New System.Drawing.Size(114, 20)
        Me.txtMUNIRAIN.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(15, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "Rango ficha inicial"
        '
        'cboMUNIESTA
        '
        Me.cboMUNIESTA.AccessibleDescription = "Estado"
        Me.cboMUNIESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMUNIESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMUNIESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMUNIESTA.FormattingEnabled = True
        Me.cboMUNIESTA.Location = New System.Drawing.Point(132, 141)
        Me.cboMUNIESTA.Name = "cboMUNIESTA"
        Me.cboMUNIESTA.Size = New System.Drawing.Size(113, 22)
        Me.cboMUNIESTA.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(15, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Estado"
        '
        'txtMUNIDESC
        '
        Me.txtMUNIDESC.AccessibleDescription = "Descripción"
        Me.txtMUNIDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUNIDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUNIDESC.Location = New System.Drawing.Point(132, 71)
        Me.txtMUNIDESC.MaxLength = 50
        Me.txtMUNIDESC.Name = "txtMUNIDESC"
        Me.txtMUNIDESC.Size = New System.Drawing.Size(422, 20)
        Me.txtMUNIDESC.TabIndex = 3
        '
        'txtMUNICODI
        '
        Me.txtMUNICODI.AccessibleDescription = "Código"
        Me.txtMUNICODI.BackColor = System.Drawing.SystemColors.Window
        Me.txtMUNICODI.Enabled = False
        Me.txtMUNICODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMUNICODI.Location = New System.Drawing.Point(132, 48)
        Me.txtMUNICODI.MaxLength = 3
        Me.txtMUNICODI.Name = "txtMUNICODI"
        Me.txtMUNICODI.ReadOnly = True
        Me.txtMUNICODI.Size = New System.Drawing.Size(114, 20)
        Me.txtMUNICODI.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(15, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Descripción"
        '
        'lblCódigo
        '
        Me.lblCódigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCódigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCódigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCódigo.ForeColor = System.Drawing.Color.Black
        Me.lblCódigo.Location = New System.Drawing.Point(15, 48)
        Me.lblCódigo.Name = "lblCódigo"
        Me.lblCódigo.Size = New System.Drawing.Size(112, 20)
        Me.lblCódigo.TabIndex = 53
        Me.lblCódigo.Text = "Municipio"
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(291, 19)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(184, 19)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 7
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 184)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 60)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        '
        'frm_modificar_MUNICIPIO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdSALIR
        Me.ClientSize = New System.Drawing.Size(599, 274)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraMUNICIPIO)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(615, 310)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(615, 310)
        Me.Name = "frm_modificar_MUNICIPIO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraMUNICIPIO.ResumeLayout(False)
        Me.fraMUNICIPIO.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraMUNICIPIO As System.Windows.Forms.GroupBox
    Friend WithEvents txtMUNIRAFI As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMUNIRAIN As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents cboMUNIESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMUNIDESC As System.Windows.Forms.TextBox
    Friend WithEvents txtMUNICODI As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCódigo As System.Windows.Forms.Label
    Friend WithEvents cboMUNIDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblMUNIDEPA As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
