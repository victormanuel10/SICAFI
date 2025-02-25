<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_FIPRZOEC
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdGUARDAR = New System.Windows.Forms.Button
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.fraCALIDADDEPROPIETARIO = New System.Windows.Forms.GroupBox
        Me.cboFPZEZOEC = New System.Windows.Forms.ComboBox
        Me.lblFPZEDESC = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboFPZEESTA = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFPZEPORC = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblCódigo = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraCALIDADDEPROPIETARIO.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 103)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 50)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(184, 16)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 4
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(291, 16)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 5
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 153)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(592, 25)
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
        'fraCALIDADDEPROPIETARIO
        '
        Me.fraCALIDADDEPROPIETARIO.BackColor = System.Drawing.SystemColors.Control
        Me.fraCALIDADDEPROPIETARIO.Controls.Add(Me.cboFPZEZOEC)
        Me.fraCALIDADDEPROPIETARIO.Controls.Add(Me.lblFPZEDESC)
        Me.fraCALIDADDEPROPIETARIO.Controls.Add(Me.Label3)
        Me.fraCALIDADDEPROPIETARIO.Controls.Add(Me.cboFPZEESTA)
        Me.fraCALIDADDEPROPIETARIO.Controls.Add(Me.Label2)
        Me.fraCALIDADDEPROPIETARIO.Controls.Add(Me.txtFPZEPORC)
        Me.fraCALIDADDEPROPIETARIO.Controls.Add(Me.Label1)
        Me.fraCALIDADDEPROPIETARIO.Controls.Add(Me.lblCódigo)
        Me.fraCALIDADDEPROPIETARIO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraCALIDADDEPROPIETARIO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraCALIDADDEPROPIETARIO.Location = New System.Drawing.Point(12, 12)
        Me.fraCALIDADDEPROPIETARIO.Name = "fraCALIDADDEPROPIETARIO"
        Me.fraCALIDADDEPROPIETARIO.Size = New System.Drawing.Size(572, 85)
        Me.fraCALIDADDEPROPIETARIO.TabIndex = 35
        Me.fraCALIDADDEPROPIETARIO.TabStop = False
        Me.fraCALIDADDEPROPIETARIO.Text = "MODIFICAR ZONA ECONÓMICA"
        '
        'cboFPZEZOEC
        '
        Me.cboFPZEZOEC.AccessibleDescription = "Zona económica"
        Me.cboFPZEZOEC.BackColor = System.Drawing.Color.White
        Me.cboFPZEZOEC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFPZEZOEC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPZEZOEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFPZEZOEC.Items.AddRange(New Object() {"2004", "2005", "2006", "2007"})
        Me.cboFPZEZOEC.Location = New System.Drawing.Point(19, 49)
        Me.cboFPZEZOEC.MaxDropDownItems = 15
        Me.cboFPZEZOEC.MaxLength = 4
        Me.cboFPZEZOEC.Name = "cboFPZEZOEC"
        Me.cboFPZEZOEC.Size = New System.Drawing.Size(85, 22)
        Me.cboFPZEZOEC.TabIndex = 1
        '
        'lblFPZEDESC
        '
        Me.lblFPZEDESC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFPZEDESC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFPZEDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPZEDESC.ForeColor = System.Drawing.Color.Black
        Me.lblFPZEDESC.Location = New System.Drawing.Point(109, 49)
        Me.lblFPZEDESC.Name = "lblFPZEDESC"
        Me.lblFPZEDESC.Size = New System.Drawing.Size(255, 20)
        Me.lblFPZEDESC.TabIndex = 327
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(368, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 20)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Porcentaje"
        '
        'cboFPZEESTA
        '
        Me.cboFPZEESTA.AccessibleDescription = "Estado"
        Me.cboFPZEESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFPZEESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFPZEESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFPZEESTA.FormattingEnabled = True
        Me.cboFPZEESTA.Location = New System.Drawing.Point(461, 49)
        Me.cboFPZEESTA.Name = "cboFPZEESTA"
        Me.cboFPZEESTA.Size = New System.Drawing.Size(91, 22)
        Me.cboFPZEESTA.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(461, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Estado"
        '
        'txtFPZEPORC
        '
        Me.txtFPZEPORC.AccessibleDescription = "Porcentaje"
        Me.txtFPZEPORC.BackColor = System.Drawing.SystemColors.Window
        Me.txtFPZEPORC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPZEPORC.Location = New System.Drawing.Point(368, 49)
        Me.txtFPZEPORC.MaxLength = 3
        Me.txtFPZEPORC.Name = "txtFPZEPORC"
        Me.txtFPZEPORC.Size = New System.Drawing.Size(90, 20)
        Me.txtFPZEPORC.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(109, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(255, 20)
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
        'frm_modificar_FIPRZOEC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdSALIR
        Me.ClientSize = New System.Drawing.Size(592, 178)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCALIDADDEPROPIETARIO)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(608, 214)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(608, 214)
        Me.Name = "frm_modificar_FIPRZOEC"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraCALIDADDEPROPIETARIO.ResumeLayout(False)
        Me.fraCALIDADDEPROPIETARIO.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraCALIDADDEPROPIETARIO As System.Windows.Forms.GroupBox
    Friend WithEvents cboFPZEZOEC As System.Windows.Forms.ComboBox
    Friend WithEvents lblFPZEDESC As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboFPZEESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFPZEPORC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCódigo As System.Windows.Forms.Label
End Class
