<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_COMUNA
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
        Me.fraVIGEACTU = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCOMUESTA = New System.Windows.Forms.ComboBox()
        Me.lblCOMUCLSE = New System.Windows.Forms.Label()
        Me.cboCOMUCLSE = New System.Windows.Forms.ComboBox()
        Me.lblClaseosector = New System.Windows.Forms.Label()
        Me.lblCOMUDEPA = New System.Windows.Forms.Label()
        Me.cboCOMUDEPA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCOMUMUNI = New System.Windows.Forms.Label()
        Me.cboCOMUMUNI = New System.Windows.Forms.ComboBox()
        Me.lblMUNICIPIO = New System.Windows.Forms.Label()
        Me.txtCOMUDESC = New System.Windows.Forms.TextBox()
        Me.txtCOMUCODI = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraVIGEACTU.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 193)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(588, 52)
        Me.GroupBox1.TabIndex = 40
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 258)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(613, 25)
        Me.strBARRESTA.TabIndex = 39
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
        'fraVIGEACTU
        '
        Me.fraVIGEACTU.BackColor = System.Drawing.SystemColors.Control
        Me.fraVIGEACTU.Controls.Add(Me.Label3)
        Me.fraVIGEACTU.Controls.Add(Me.cboCOMUESTA)
        Me.fraVIGEACTU.Controls.Add(Me.lblCOMUCLSE)
        Me.fraVIGEACTU.Controls.Add(Me.cboCOMUCLSE)
        Me.fraVIGEACTU.Controls.Add(Me.lblClaseosector)
        Me.fraVIGEACTU.Controls.Add(Me.lblCOMUDEPA)
        Me.fraVIGEACTU.Controls.Add(Me.cboCOMUDEPA)
        Me.fraVIGEACTU.Controls.Add(Me.Label4)
        Me.fraVIGEACTU.Controls.Add(Me.lblCOMUMUNI)
        Me.fraVIGEACTU.Controls.Add(Me.cboCOMUMUNI)
        Me.fraVIGEACTU.Controls.Add(Me.lblMUNICIPIO)
        Me.fraVIGEACTU.Controls.Add(Me.txtCOMUDESC)
        Me.fraVIGEACTU.Controls.Add(Me.txtCOMUCODI)
        Me.fraVIGEACTU.Controls.Add(Me.Label1)
        Me.fraVIGEACTU.Controls.Add(Me.lblCodigo)
        Me.fraVIGEACTU.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraVIGEACTU.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraVIGEACTU.Location = New System.Drawing.Point(12, 7)
        Me.fraVIGEACTU.Name = "fraVIGEACTU"
        Me.fraVIGEACTU.Size = New System.Drawing.Size(588, 180)
        Me.fraVIGEACTU.TabIndex = 38
        Me.fraVIGEACTU.TabStop = False
        Me.fraVIGEACTU.Text = "MODIFICAR COMUNA"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'cboCOMUESTA
        '
        Me.cboCOMUESTA.AccessibleDescription = "Estado"
        Me.cboCOMUESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCOMUESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCOMUESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCOMUESTA.FormattingEnabled = True
        Me.cboCOMUESTA.Location = New System.Drawing.Point(153, 143)
        Me.cboCOMUESTA.Name = "cboCOMUESTA"
        Me.cboCOMUESTA.Size = New System.Drawing.Size(295, 22)
        Me.cboCOMUESTA.TabIndex = 10
        '
        'lblCOMUCLSE
        '
        Me.lblCOMUCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCOMUCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCOMUCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCOMUCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblCOMUCLSE.Location = New System.Drawing.Point(454, 74)
        Me.lblCOMUCLSE.Name = "lblCOMUCLSE"
        Me.lblCOMUCLSE.Size = New System.Drawing.Size(120, 20)
        Me.lblCOMUCLSE.TabIndex = 57
        '
        'cboCOMUCLSE
        '
        Me.cboCOMUCLSE.AccessibleDescription = "Clase o sector"
        Me.cboCOMUCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCOMUCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCOMUCLSE.Enabled = False
        Me.cboCOMUCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCOMUCLSE.FormattingEnabled = True
        Me.cboCOMUCLSE.Location = New System.Drawing.Point(153, 72)
        Me.cboCOMUCLSE.Name = "cboCOMUCLSE"
        Me.cboCOMUCLSE.Size = New System.Drawing.Size(295, 22)
        Me.cboCOMUCLSE.TabIndex = 3
        '
        'lblClaseosector
        '
        Me.lblClaseosector.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseosector.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseosector.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseosector.ForeColor = System.Drawing.Color.Black
        Me.lblClaseosector.Location = New System.Drawing.Point(19, 74)
        Me.lblClaseosector.Name = "lblClaseosector"
        Me.lblClaseosector.Size = New System.Drawing.Size(130, 20)
        Me.lblClaseosector.TabIndex = 56
        Me.lblClaseosector.Text = "Clase o sector"
        '
        'lblCOMUDEPA
        '
        Me.lblCOMUDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCOMUDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCOMUDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCOMUDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblCOMUDEPA.Location = New System.Drawing.Point(454, 28)
        Me.lblCOMUDEPA.Name = "lblCOMUDEPA"
        Me.lblCOMUDEPA.Size = New System.Drawing.Size(120, 20)
        Me.lblCOMUDEPA.TabIndex = 52
        '
        'cboCOMUDEPA
        '
        Me.cboCOMUDEPA.AccessibleDescription = "Departamento"
        Me.cboCOMUDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCOMUDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCOMUDEPA.Enabled = False
        Me.cboCOMUDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCOMUDEPA.FormattingEnabled = True
        Me.cboCOMUDEPA.Location = New System.Drawing.Point(153, 26)
        Me.cboCOMUDEPA.Name = "cboCOMUDEPA"
        Me.cboCOMUDEPA.Size = New System.Drawing.Size(295, 22)
        Me.cboCOMUDEPA.TabIndex = 1
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
        'lblCOMUMUNI
        '
        Me.lblCOMUMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCOMUMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCOMUMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCOMUMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblCOMUMUNI.Location = New System.Drawing.Point(454, 51)
        Me.lblCOMUMUNI.Name = "lblCOMUMUNI"
        Me.lblCOMUMUNI.Size = New System.Drawing.Size(120, 20)
        Me.lblCOMUMUNI.TabIndex = 50
        '
        'cboCOMUMUNI
        '
        Me.cboCOMUMUNI.AccessibleDescription = "Municipio"
        Me.cboCOMUMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCOMUMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCOMUMUNI.Enabled = False
        Me.cboCOMUMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCOMUMUNI.FormattingEnabled = True
        Me.cboCOMUMUNI.Location = New System.Drawing.Point(153, 49)
        Me.cboCOMUMUNI.Name = "cboCOMUMUNI"
        Me.cboCOMUMUNI.Size = New System.Drawing.Size(295, 22)
        Me.cboCOMUMUNI.TabIndex = 2
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
        'txtCOMUDESC
        '
        Me.txtCOMUDESC.AccessibleDescription = "Descripción"
        Me.txtCOMUDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtCOMUDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOMUDESC.Location = New System.Drawing.Point(153, 120)
        Me.txtCOMUDESC.MaxLength = 50
        Me.txtCOMUDESC.Name = "txtCOMUDESC"
        Me.txtCOMUDESC.Size = New System.Drawing.Size(421, 20)
        Me.txtCOMUDESC.TabIndex = 5
        '
        'txtCOMUCODI
        '
        Me.txtCOMUCODI.AccessibleDescription = "Comuna"
        Me.txtCOMUCODI.BackColor = System.Drawing.SystemColors.Window
        Me.txtCOMUCODI.Enabled = False
        Me.txtCOMUCODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOMUCODI.Location = New System.Drawing.Point(153, 97)
        Me.txtCOMUCODI.MaxLength = 9
        Me.txtCOMUCODI.Name = "txtCOMUCODI"
        Me.txtCOMUCODI.Size = New System.Drawing.Size(112, 20)
        Me.txtCOMUCODI.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 120)
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
        Me.lblCodigo.Location = New System.Drawing.Point(19, 97)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(130, 20)
        Me.lblCodigo.TabIndex = 37
        Me.lblCodigo.Text = "Comuna"
        '
        'frm_modificar_COMUNA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 283)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraVIGEACTU)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(629, 319)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(629, 319)
        Me.Name = "frm_modificar_COMUNA"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modifica registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraVIGEACTU.ResumeLayout(False)
        Me.fraVIGEACTU.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraVIGEACTU As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCOMUESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCOMUCLSE As System.Windows.Forms.Label
    Friend WithEvents cboCOMUCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents lblCOMUDEPA As System.Windows.Forms.Label
    Friend WithEvents cboCOMUDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCOMUMUNI As System.Windows.Forms.Label
    Friend WithEvents cboCOMUMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents txtCOMUDESC As System.Windows.Forms.TextBox
    Friend WithEvents txtCOMUCODI As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
End Class
