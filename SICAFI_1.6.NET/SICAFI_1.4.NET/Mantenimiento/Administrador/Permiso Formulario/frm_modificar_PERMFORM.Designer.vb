<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_PERMFORM
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
        Me.fraZONAECONOMICA = New System.Windows.Forms.GroupBox
        Me.txtPEFODESC = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkPEFOELIM = New System.Windows.Forms.CheckBox
        Me.chkPEFOMODI = New System.Windows.Forms.CheckBox
        Me.chkPEFOAGRE = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblPEFOUSUA = New System.Windows.Forms.Label
        Me.cboPEFOUSUA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblPEFOFORM = New System.Windows.Forms.Label
        Me.cboPEFOFORM = New System.Windows.Forms.ComboBox
        Me.lblMUNICIPIO = New System.Windows.Forms.Label
        Me.cboPEFOESTA = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraZONAECONOMICA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 191)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(822, 52)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(410, 17)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(303, 17)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 257)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(846, 25)
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
        'fraZONAECONOMICA
        '
        Me.fraZONAECONOMICA.BackColor = System.Drawing.SystemColors.Control
        Me.fraZONAECONOMICA.Controls.Add(Me.txtPEFODESC)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label1)
        Me.fraZONAECONOMICA.Controls.Add(Me.chkPEFOELIM)
        Me.fraZONAECONOMICA.Controls.Add(Me.chkPEFOMODI)
        Me.fraZONAECONOMICA.Controls.Add(Me.chkPEFOAGRE)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label3)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblPEFOUSUA)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboPEFOUSUA)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label4)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblPEFOFORM)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboPEFOFORM)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblMUNICIPIO)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboPEFOESTA)
        Me.fraZONAECONOMICA.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraZONAECONOMICA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraZONAECONOMICA.Location = New System.Drawing.Point(12, 6)
        Me.fraZONAECONOMICA.Name = "fraZONAECONOMICA"
        Me.fraZONAECONOMICA.Size = New System.Drawing.Size(822, 179)
        Me.fraZONAECONOMICA.TabIndex = 32
        Me.fraZONAECONOMICA.TabStop = False
        Me.fraZONAECONOMICA.Text = "MODIFICAR FORMULARIO Y PERMISOS"
        '
        'txtPEFODESC
        '
        Me.txtPEFODESC.AccessibleDescription = "Descripción"
        Me.txtPEFODESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtPEFODESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPEFODESC.Location = New System.Drawing.Point(137, 74)
        Me.txtPEFODESC.MaxLength = 50
        Me.txtPEFODESC.Name = "txtPEFODESC"
        Me.txtPEFODESC.Size = New System.Drawing.Size(265, 20)
        Me.txtPEFODESC.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Descripción"
        '
        'chkPEFOELIM
        '
        Me.chkPEFOELIM.AccessibleDescription = "Eliminar S/N"
        Me.chkPEFOELIM.AutoSize = True
        Me.chkPEFOELIM.Location = New System.Drawing.Point(188, 107)
        Me.chkPEFOELIM.Name = "chkPEFOELIM"
        Me.chkPEFOELIM.Size = New System.Drawing.Size(72, 19)
        Me.chkPEFOELIM.TabIndex = 6
        Me.chkPEFOELIM.Text = "Eliminar"
        Me.chkPEFOELIM.UseVisualStyleBackColor = True
        '
        'chkPEFOMODI
        '
        Me.chkPEFOMODI.AccessibleDescription = "Modificar S/N"
        Me.chkPEFOMODI.AutoSize = True
        Me.chkPEFOMODI.Location = New System.Drawing.Point(107, 107)
        Me.chkPEFOMODI.Name = "chkPEFOMODI"
        Me.chkPEFOMODI.Size = New System.Drawing.Size(75, 19)
        Me.chkPEFOMODI.TabIndex = 5
        Me.chkPEFOMODI.Text = "Modificar"
        Me.chkPEFOMODI.UseVisualStyleBackColor = True
        '
        'chkPEFOAGRE
        '
        Me.chkPEFOAGRE.AccessibleDescription = "Agregar S/N"
        Me.chkPEFOAGRE.AutoSize = True
        Me.chkPEFOAGRE.Location = New System.Drawing.Point(19, 107)
        Me.chkPEFOAGRE.Name = "chkPEFOAGRE"
        Me.chkPEFOAGRE.Size = New System.Drawing.Size(69, 19)
        Me.chkPEFOAGRE.TabIndex = 4
        Me.chkPEFOAGRE.Text = "Agregar"
        Me.chkPEFOAGRE.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'lblPEFOUSUA
        '
        Me.lblPEFOUSUA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPEFOUSUA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPEFOUSUA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPEFOUSUA.ForeColor = System.Drawing.Color.Black
        Me.lblPEFOUSUA.Location = New System.Drawing.Point(410, 28)
        Me.lblPEFOUSUA.Name = "lblPEFOUSUA"
        Me.lblPEFOUSUA.Size = New System.Drawing.Size(392, 20)
        Me.lblPEFOUSUA.TabIndex = 52
        '
        'cboPEFOUSUA
        '
        Me.cboPEFOUSUA.AccessibleDescription = "Usuario"
        Me.cboPEFOUSUA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPEFOUSUA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPEFOUSUA.Enabled = False
        Me.cboPEFOUSUA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPEFOUSUA.FormattingEnabled = True
        Me.cboPEFOUSUA.Location = New System.Drawing.Point(137, 26)
        Me.cboPEFOUSUA.Name = "cboPEFOUSUA"
        Me.cboPEFOUSUA.Size = New System.Drawing.Size(265, 22)
        Me.cboPEFOUSUA.TabIndex = 1
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
        'lblPEFOFORM
        '
        Me.lblPEFOFORM.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPEFOFORM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPEFOFORM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPEFOFORM.ForeColor = System.Drawing.Color.Black
        Me.lblPEFOFORM.Location = New System.Drawing.Point(410, 51)
        Me.lblPEFOFORM.Name = "lblPEFOFORM"
        Me.lblPEFOFORM.Size = New System.Drawing.Size(392, 20)
        Me.lblPEFOFORM.TabIndex = 50
        '
        'cboPEFOFORM
        '
        Me.cboPEFOFORM.AccessibleDescription = "Formulario"
        Me.cboPEFOFORM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPEFOFORM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPEFOFORM.Enabled = False
        Me.cboPEFOFORM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPEFOFORM.FormattingEnabled = True
        Me.cboPEFOFORM.Location = New System.Drawing.Point(137, 49)
        Me.cboPEFOFORM.Name = "cboPEFOFORM"
        Me.cboPEFOFORM.Size = New System.Drawing.Size(265, 22)
        Me.cboPEFOFORM.TabIndex = 2
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
        'cboPEFOESTA
        '
        Me.cboPEFOESTA.AccessibleDescription = "Estado"
        Me.cboPEFOESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPEFOESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPEFOESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPEFOESTA.FormattingEnabled = True
        Me.cboPEFOESTA.Location = New System.Drawing.Point(137, 139)
        Me.cboPEFOESTA.Name = "cboPEFOESTA"
        Me.cboPEFOESTA.Size = New System.Drawing.Size(112, 22)
        Me.cboPEFOESTA.TabIndex = 7
        '
        'frm_modificar_PERMFORM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(846, 282)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraZONAECONOMICA)
        Me.MaximumSize = New System.Drawing.Size(862, 318)
        Me.MinimumSize = New System.Drawing.Size(862, 318)
        Me.Name = "frm_modificar_PERMFORM"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraZONAECONOMICA.ResumeLayout(False)
        Me.fraZONAECONOMICA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraZONAECONOMICA As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkPEFOELIM As System.Windows.Forms.CheckBox
    Friend WithEvents chkPEFOMODI As System.Windows.Forms.CheckBox
    Friend WithEvents chkPEFOAGRE As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPEFOUSUA As System.Windows.Forms.Label
    Friend WithEvents cboPEFOUSUA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblPEFOFORM As System.Windows.Forms.Label
    Friend WithEvents cboPEFOFORM As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cboPEFOESTA As System.Windows.Forms.ComboBox
    Friend WithEvents txtPEFODESC As System.Windows.Forms.TextBox
End Class
