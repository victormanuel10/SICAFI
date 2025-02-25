<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Insertar_CODICALI
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
        Me.components = New System.ComponentModel.Container
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.fraCODIGOCALIFICACION = New System.Windows.Forms.GroupBox
        Me.txtCOCACOHI = New System.Windows.Forms.TextBox
        Me.txtCOCACOPA = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboCOCAESTA = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCOCADESC = New System.Windows.Forms.TextBox
        Me.txtCOCACODI = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblCódigo = New System.Windows.Forms.Label
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.cmdGUARDAR = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.strBARRESTA.SuspendLayout()
        Me.fraCODIGOCALIFICACION.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel2, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 211)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(607, 25)
        Me.strBARRESTA.TabIndex = 27
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
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.AutoSize = False
        Me.ToolStripStatusLabel3.BackColor = System.Drawing.SystemColors.Window
        Me.ToolStripStatusLabel3.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel3.ForeColor = System.Drawing.Color.Red
        Me.ToolStripStatusLabel3.LinkColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel3.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(300, 22)
        Me.ToolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.AutoSize = False
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.SystemColors.Window
        Me.ToolStripStatusLabel2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(125, 22)
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tstBAESDESC
        '
        Me.tstBAESDESC.AutoSize = False
        Me.tstBAESDESC.BackColor = System.Drawing.SystemColors.InactiveCaptionText
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
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
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
        'fraCODIGOCALIFICACION
        '
        Me.fraCODIGOCALIFICACION.BackColor = System.Drawing.SystemColors.Control
        Me.fraCODIGOCALIFICACION.Controls.Add(Me.txtCOCACOHI)
        Me.fraCODIGOCALIFICACION.Controls.Add(Me.txtCOCACOPA)
        Me.fraCODIGOCALIFICACION.Controls.Add(Me.Label4)
        Me.fraCODIGOCALIFICACION.Controls.Add(Me.Label5)
        Me.fraCODIGOCALIFICACION.Controls.Add(Me.cboCOCAESTA)
        Me.fraCODIGOCALIFICACION.Controls.Add(Me.Label2)
        Me.fraCODIGOCALIFICACION.Controls.Add(Me.txtCOCADESC)
        Me.fraCODIGOCALIFICACION.Controls.Add(Me.txtCOCACODI)
        Me.fraCODIGOCALIFICACION.Controls.Add(Me.Label1)
        Me.fraCODIGOCALIFICACION.Controls.Add(Me.lblCódigo)
        Me.fraCODIGOCALIFICACION.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraCODIGOCALIFICACION.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraCODIGOCALIFICACION.Location = New System.Drawing.Point(12, 3)
        Me.fraCODIGOCALIFICACION.Name = "fraCODIGOCALIFICACION"
        Me.fraCODIGOCALIFICACION.Size = New System.Drawing.Size(591, 157)
        Me.fraCODIGOCALIFICACION.TabIndex = 26
        Me.fraCODIGOCALIFICACION.TabStop = False
        Me.fraCODIGOCALIFICACION.Text = "INSERTAR CÓDIGOS DE CALIFICACIÓN"
        '
        'txtCOCACOHI
        '
        Me.txtCOCACOHI.AccessibleDescription = "Código hijo"
        Me.txtCOCACOHI.BackColor = System.Drawing.SystemColors.Window
        Me.txtCOCACOHI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOCACOHI.Location = New System.Drawing.Point(110, 99)
        Me.txtCOCACOHI.MaxLength = 50
        Me.txtCOCACOHI.Name = "txtCOCACOHI"
        Me.txtCOCACOHI.Size = New System.Drawing.Size(280, 20)
        Me.txtCOCACOHI.TabIndex = 4
        '
        'txtCOCACOPA
        '
        Me.txtCOCACOPA.AccessibleDescription = "Código padre"
        Me.txtCOCACOPA.BackColor = System.Drawing.SystemColors.Window
        Me.txtCOCACOPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOCACOPA.Location = New System.Drawing.Point(110, 75)
        Me.txtCOCACOPA.MaxLength = 50
        Me.txtCOCACOPA.Name = "txtCOCACOPA"
        Me.txtCOCACOPA.Size = New System.Drawing.Size(280, 20)
        Me.txtCOCACOPA.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 20)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Estado"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 20)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Código hijo"
        '
        'cboCOCAESTA
        '
        Me.cboCOCAESTA.AccessibleDescription = "Estado"
        Me.cboCOCAESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCOCAESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCOCAESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCOCAESTA.FormattingEnabled = True
        Me.cboCOCAESTA.Location = New System.Drawing.Point(110, 122)
        Me.cboCOCAESTA.Name = "cboCOCAESTA"
        Me.cboCOCAESTA.Size = New System.Drawing.Size(91, 22)
        Me.cboCOCAESTA.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Código padre"
        '
        'txtCOCADESC
        '
        Me.txtCOCADESC.AccessibleDescription = "Descripción"
        Me.txtCOCADESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtCOCADESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOCADESC.Location = New System.Drawing.Point(110, 52)
        Me.txtCOCADESC.MaxLength = 50
        Me.txtCOCADESC.Name = "txtCOCADESC"
        Me.txtCOCADESC.Size = New System.Drawing.Size(451, 20)
        Me.txtCOCADESC.TabIndex = 2
        '
        'txtCOCACODI
        '
        Me.txtCOCACODI.AccessibleDescription = "Código"
        Me.txtCOCACODI.BackColor = System.Drawing.SystemColors.Window
        Me.txtCOCACODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOCACODI.Location = New System.Drawing.Point(110, 26)
        Me.txtCOCACODI.MaxLength = 3
        Me.txtCOCACODI.Name = "txtCOCACODI"
        Me.txtCOCACODI.Size = New System.Drawing.Size(86, 20)
        Me.txtCOCACODI.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 20)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Descripción"
        '
        'lblCódigo
        '
        Me.lblCódigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCódigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCódigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCódigo.ForeColor = System.Drawing.Color.Black
        Me.lblCódigo.Location = New System.Drawing.Point(19, 26)
        Me.lblCódigo.Name = "lblCódigo"
        Me.lblCódigo.Size = New System.Drawing.Size(85, 20)
        Me.lblCódigo.TabIndex = 37
        Me.lblCódigo.Text = "Código"
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(302, 17)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 7
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(195, 17)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 6
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.ErrorProvider1.ContainerControl = Me
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 164)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(591, 51)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        '
        'frm_Insertar_CODICALI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdSALIR
        Me.ClientSize = New System.Drawing.Size(607, 236)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCODIGOCALIFICACION)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(623, 272)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(623, 272)
        Me.Name = "frm_Insertar_CODICALI"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraCODIGOCALIFICACION.ResumeLayout(False)
        Me.fraCODIGOCALIFICACION.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraCODIGOCALIFICACION As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents cboCOCAESTA As System.Windows.Forms.ComboBox
    Friend WithEvents txtCOCADESC As System.Windows.Forms.TextBox
    Friend WithEvents txtCOCACODI As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCódigo As System.Windows.Forms.Label
    Friend WithEvents txtCOCACOHI As System.Windows.Forms.TextBox
    Friend WithEvents txtCOCACOPA As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
