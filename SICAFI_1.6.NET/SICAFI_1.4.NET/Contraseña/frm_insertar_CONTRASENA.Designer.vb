<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_CONTRASENA
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
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraCONTRASENA = New System.Windows.Forms.GroupBox()
        Me.lblCONTNOMB = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCONTUSUA = New System.Windows.Forms.TextBox()
        Me.cboCONTESTA = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdCANCELAR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.cboCONTNUDO = New System.Windows.Forms.ComboBox()
        Me.lblCódigo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.strBARRESTA.SuspendLayout()
        Me.fraCONTRASENA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 207)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(602, 25)
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
        'fraCONTRASENA
        '
        Me.fraCONTRASENA.BackColor = System.Drawing.SystemColors.Control
        Me.fraCONTRASENA.Controls.Add(Me.lblCONTNOMB)
        Me.fraCONTRASENA.Controls.Add(Me.Label4)
        Me.fraCONTRASENA.Controls.Add(Me.txtCONTUSUA)
        Me.fraCONTRASENA.Controls.Add(Me.cboCONTESTA)
        Me.fraCONTRASENA.Controls.Add(Me.Label3)
        Me.fraCONTRASENA.Controls.Add(Me.cboCONTNUDO)
        Me.fraCONTRASENA.Controls.Add(Me.lblCódigo)
        Me.fraCONTRASENA.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraCONTRASENA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraCONTRASENA.Location = New System.Drawing.Point(16, 12)
        Me.fraCONTRASENA.Name = "fraCONTRASENA"
        Me.fraCONTRASENA.Size = New System.Drawing.Size(572, 114)
        Me.fraCONTRASENA.TabIndex = 29
        Me.fraCONTRASENA.TabStop = False
        Me.fraCONTRASENA.Text = "INSERTAR PERFIL DE USUARIO"
        '
        'lblCONTNOMB
        '
        Me.lblCONTNOMB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCONTNOMB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCONTNOMB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCONTNOMB.ForeColor = System.Drawing.Color.Black
        Me.lblCONTNOMB.Location = New System.Drawing.Point(251, 26)
        Me.lblCONTNOMB.Name = "lblCONTNOMB"
        Me.lblCONTNOMB.Size = New System.Drawing.Size(303, 20)
        Me.lblCONTNOMB.TabIndex = 51
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 20)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "Estado"
        '
        'txtCONTUSUA
        '
        Me.txtCONTUSUA.AccessibleDescription = "Usuario"
        Me.txtCONTUSUA.BackColor = System.Drawing.SystemColors.Window
        Me.txtCONTUSUA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCONTUSUA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONTUSUA.Location = New System.Drawing.Point(120, 49)
        Me.txtCONTUSUA.MaxLength = 20
        Me.txtCONTUSUA.Name = "txtCONTUSUA"
        Me.txtCONTUSUA.Size = New System.Drawing.Size(125, 20)
        Me.txtCONTUSUA.TabIndex = 3
        '
        'cboCONTESTA
        '
        Me.cboCONTESTA.AccessibleDescription = "Estado"
        Me.cboCONTESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCONTESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCONTESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCONTESTA.FormattingEnabled = True
        Me.cboCONTESTA.Location = New System.Drawing.Point(120, 72)
        Me.cboCONTESTA.Name = "cboCONTESTA"
        Me.cboCONTESTA.Size = New System.Drawing.Size(125, 22)
        Me.cboCONTESTA.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 20)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Usuario / Login"
        '
        'cmdCANCELAR
        '
        Me.cmdCANCELAR.AccessibleDescription = "Cancelar"
        Me.cmdCANCELAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCANCELAR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdCANCELAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCANCELAR.Location = New System.Drawing.Point(290, 23)
        Me.cmdCANCELAR.Name = "cmdCANCELAR"
        Me.cmdCANCELAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdCANCELAR.TabIndex = 7
        Me.cmdCANCELAR.Text = "&Salir"
        Me.cmdCANCELAR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(183, 23)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 6
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'cboCONTNUDO
        '
        Me.cboCONTNUDO.AccessibleDescription = "Nro. documento"
        Me.cboCONTNUDO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCONTNUDO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCONTNUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCONTNUDO.FormattingEnabled = True
        Me.cboCONTNUDO.Location = New System.Drawing.Point(120, 24)
        Me.cboCONTNUDO.Name = "cboCONTNUDO"
        Me.cboCONTNUDO.Size = New System.Drawing.Size(125, 22)
        Me.cboCONTNUDO.TabIndex = 1
        '
        'lblCódigo
        '
        Me.lblCódigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCódigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCódigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCódigo.ForeColor = System.Drawing.Color.Black
        Me.lblCódigo.Location = New System.Drawing.Point(19, 26)
        Me.lblCódigo.Name = "lblCódigo"
        Me.lblCódigo.Size = New System.Drawing.Size(95, 20)
        Me.lblCódigo.TabIndex = 37
        Me.lblCódigo.Text = "Nro. Documento"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Controls.Add(Me.cmdCANCELAR)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 132)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 61)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        '
        'frm_insertar_CONTRASENA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(602, 232)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.fraCONTRASENA)
        Me.Controls.Add(Me.strBARRESTA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(618, 268)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(618, 268)
        Me.Name = "frm_insertar_CONTRASENA"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraCONTRASENA.ResumeLayout(False)
        Me.fraCONTRASENA.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraCONTRASENA As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCANCELAR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents cboCONTNUDO As System.Windows.Forms.ComboBox
    Friend WithEvents lblCódigo As System.Windows.Forms.Label
    Friend WithEvents txtCONTUSUA As System.Windows.Forms.TextBox
    Friend WithEvents cboCONTESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCONTNOMB As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
