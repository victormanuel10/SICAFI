<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_DESTECON
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
        Me.fraDESTINACIONECONOMICA = New System.Windows.Forms.GroupBox()
        Me.cboDEECESTA = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDEECDESC = New System.Windows.Forms.TextBox()
        Me.txtDEECCODI = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCódigo = New System.Windows.Forms.Label()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkDEECLOTE = New System.Windows.Forms.CheckBox()
        Me.strBARRESTA.SuspendLayout()
        Me.fraDESTINACIONECONOMICA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 178)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(598, 25)
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
        'fraDESTINACIONECONOMICA
        '
        Me.fraDESTINACIONECONOMICA.BackColor = System.Drawing.SystemColors.Control
        Me.fraDESTINACIONECONOMICA.Controls.Add(Me.chkDEECLOTE)
        Me.fraDESTINACIONECONOMICA.Controls.Add(Me.cboDEECESTA)
        Me.fraDESTINACIONECONOMICA.Controls.Add(Me.Label2)
        Me.fraDESTINACIONECONOMICA.Controls.Add(Me.txtDEECDESC)
        Me.fraDESTINACIONECONOMICA.Controls.Add(Me.txtDEECCODI)
        Me.fraDESTINACIONECONOMICA.Controls.Add(Me.Label1)
        Me.fraDESTINACIONECONOMICA.Controls.Add(Me.lblCódigo)
        Me.fraDESTINACIONECONOMICA.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraDESTINACIONECONOMICA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraDESTINACIONECONOMICA.Location = New System.Drawing.Point(12, 3)
        Me.fraDESTINACIONECONOMICA.Name = "fraDESTINACIONECONOMICA"
        Me.fraDESTINACIONECONOMICA.Size = New System.Drawing.Size(572, 105)
        Me.fraDESTINACIONECONOMICA.TabIndex = 27
        Me.fraDESTINACIONECONOMICA.TabStop = False
        Me.fraDESTINACIONECONOMICA.Text = "MODIFICAR DESTINACIÓN ECONÓMICA"
        '
        'cboDEECESTA
        '
        Me.cboDEECESTA.AccessibleDescription = "Estado"
        Me.cboDEECESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDEECESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDEECESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDEECESTA.FormattingEnabled = True
        Me.cboDEECESTA.Location = New System.Drawing.Point(461, 49)
        Me.cboDEECESTA.Name = "cboDEECESTA"
        Me.cboDEECESTA.Size = New System.Drawing.Size(91, 22)
        Me.cboDEECESTA.TabIndex = 3
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
        'txtDEECDESC
        '
        Me.txtDEECDESC.AccessibleDescription = "Descripción"
        Me.txtDEECDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtDEECDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDEECDESC.Location = New System.Drawing.Point(107, 49)
        Me.txtDEECDESC.MaxLength = 50
        Me.txtDEECDESC.Name = "txtDEECDESC"
        Me.txtDEECDESC.Size = New System.Drawing.Size(351, 20)
        Me.txtDEECDESC.TabIndex = 2
        '
        'txtDEECCODI
        '
        Me.txtDEECCODI.AccessibleDescription = "Código"
        Me.txtDEECCODI.BackColor = System.Drawing.SystemColors.Window
        Me.txtDEECCODI.Enabled = False
        Me.txtDEECCODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDEECCODI.Location = New System.Drawing.Point(19, 49)
        Me.txtDEECCODI.MaxLength = 2
        Me.txtDEECCODI.Name = "txtDEECCODI"
        Me.txtDEECCODI.ReadOnly = True
        Me.txtDEECCODI.Size = New System.Drawing.Size(86, 20)
        Me.txtDEECCODI.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(107, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(350, 20)
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
        Me.cmdSALIR.Location = New System.Drawing.Point(291, 19)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 5
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
        Me.cmdGUARDAR.TabIndex = 4
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 114)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 52)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        '
        'chkDEECLOTE
        '
        Me.chkDEECLOTE.AutoSize = True
        Me.chkDEECLOTE.Location = New System.Drawing.Point(19, 75)
        Me.chkDEECLOTE.Name = "chkDEECLOTE"
        Me.chkDEECLOTE.Size = New System.Drawing.Size(50, 19)
        Me.chkDEECLOTE.TabIndex = 43
        Me.chkDEECLOTE.Text = "Lote"
        Me.chkDEECLOTE.UseVisualStyleBackColor = True
        '
        'frm_modificar_DESTECON
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdSALIR
        Me.ClientSize = New System.Drawing.Size(598, 203)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraDESTINACIONECONOMICA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(614, 239)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(614, 239)
        Me.Name = "frm_modificar_DESTECON"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraDESTINACIONECONOMICA.ResumeLayout(False)
        Me.fraDESTINACIONECONOMICA.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraDESTINACIONECONOMICA As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents cboDEECESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDEECDESC As System.Windows.Forms.TextBox
    Friend WithEvents txtDEECCODI As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCódigo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDEECLOTE As System.Windows.Forms.CheckBox
End Class
