<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_RESOADMI
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
        Me.fraFICHPRED = New System.Windows.Forms.GroupBox()
        Me.cboREADESTA = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboREADTIRE = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboREADCLSE = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboREADVIRE = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpREADFERE = New System.Windows.Forms.DateTimePicker()
        Me.txtREADNURE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtREADFERE = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboREADCLAS = New System.Windows.Forms.ComboBox()
        Me.lblCategoriaDeSuelo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraFICHPRED.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraFICHPRED
        '
        Me.fraFICHPRED.BackColor = System.Drawing.SystemColors.Control
        Me.fraFICHPRED.Controls.Add(Me.cboREADESTA)
        Me.fraFICHPRED.Controls.Add(Me.Label2)
        Me.fraFICHPRED.Controls.Add(Me.cboREADTIRE)
        Me.fraFICHPRED.Controls.Add(Me.Label7)
        Me.fraFICHPRED.Controls.Add(Me.cboREADCLSE)
        Me.fraFICHPRED.Controls.Add(Me.Label6)
        Me.fraFICHPRED.Controls.Add(Me.cboREADVIRE)
        Me.fraFICHPRED.Controls.Add(Me.Label10)
        Me.fraFICHPRED.Controls.Add(Me.dtpREADFERE)
        Me.fraFICHPRED.Controls.Add(Me.txtREADNURE)
        Me.fraFICHPRED.Controls.Add(Me.Label1)
        Me.fraFICHPRED.Controls.Add(Me.txtREADFERE)
        Me.fraFICHPRED.Controls.Add(Me.Label11)
        Me.fraFICHPRED.Controls.Add(Me.cboREADCLAS)
        Me.fraFICHPRED.Controls.Add(Me.lblCategoriaDeSuelo)
        Me.fraFICHPRED.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraFICHPRED.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraFICHPRED.Location = New System.Drawing.Point(15, 12)
        Me.fraFICHPRED.Name = "fraFICHPRED"
        Me.fraFICHPRED.Size = New System.Drawing.Size(637, 202)
        Me.fraFICHPRED.TabIndex = 356
        Me.fraFICHPRED.TabStop = False
        Me.fraFICHPRED.Text = "INSERTAR RESOLUCIÓN ADMINISTRATIVA"
        '
        'cboREADESTA
        '
        Me.cboREADESTA.AccessibleDescription = "Estado"
        Me.cboREADESTA.BackColor = System.Drawing.Color.White
        Me.cboREADESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboREADESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboREADESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboREADESTA.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboREADESTA.Location = New System.Drawing.Point(155, 162)
        Me.cboREADESTA.MaxDropDownItems = 15
        Me.cboREADESTA.MaxLength = 1
        Me.cboREADESTA.Name = "cboREADESTA"
        Me.cboREADESTA.Size = New System.Drawing.Size(465, 22)
        Me.cboREADESTA.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(20, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 20)
        Me.Label2.TabIndex = 453
        Me.Label2.Text = "Estado"
        '
        'cboREADTIRE
        '
        Me.cboREADTIRE.AccessibleDescription = "Tipo de resolución"
        Me.cboREADTIRE.BackColor = System.Drawing.Color.White
        Me.cboREADTIRE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboREADTIRE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboREADTIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboREADTIRE.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboREADTIRE.Location = New System.Drawing.Point(155, 93)
        Me.cboREADTIRE.MaxDropDownItems = 15
        Me.cboREADTIRE.MaxLength = 1
        Me.cboREADTIRE.Name = "cboREADTIRE"
        Me.cboREADTIRE.Size = New System.Drawing.Size(465, 22)
        Me.cboREADTIRE.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(20, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(132, 20)
        Me.Label7.TabIndex = 451
        Me.Label7.Text = "Tipo de resolución"
        '
        'cboREADCLSE
        '
        Me.cboREADCLSE.AccessibleDescription = "Clase o sector"
        Me.cboREADCLSE.BackColor = System.Drawing.Color.White
        Me.cboREADCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboREADCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboREADCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboREADCLSE.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboREADCLSE.Location = New System.Drawing.Point(155, 116)
        Me.cboREADCLSE.MaxDropDownItems = 15
        Me.cboREADCLSE.MaxLength = 1
        Me.cboREADCLSE.Name = "cboREADCLSE"
        Me.cboREADCLSE.Size = New System.Drawing.Size(465, 22)
        Me.cboREADCLSE.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(20, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 20)
        Me.Label6.TabIndex = 448
        Me.Label6.Text = "Clase o sector"
        '
        'cboREADVIRE
        '
        Me.cboREADVIRE.AccessibleDescription = "Vigencia resolución"
        Me.cboREADVIRE.BackColor = System.Drawing.Color.White
        Me.cboREADVIRE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboREADVIRE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboREADVIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboREADVIRE.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboREADVIRE.Location = New System.Drawing.Point(155, 139)
        Me.cboREADVIRE.MaxDropDownItems = 15
        Me.cboREADVIRE.MaxLength = 1
        Me.cboREADVIRE.Name = "cboREADVIRE"
        Me.cboREADVIRE.Size = New System.Drawing.Size(465, 22)
        Me.cboREADVIRE.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(20, 141)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(132, 20)
        Me.Label10.TabIndex = 440
        Me.Label10.Text = "Vigencia resolución"
        '
        'dtpREADFERE
        '
        Me.dtpREADFERE.Location = New System.Drawing.Point(318, 71)
        Me.dtpREADFERE.Name = "dtpREADFERE"
        Me.dtpREADFERE.Size = New System.Drawing.Size(302, 21)
        Me.dtpREADFERE.TabIndex = 431
        '
        'txtREADNURE
        '
        Me.txtREADNURE.AccessibleDescription = "Nro. Resolución"
        Me.txtREADNURE.BackColor = System.Drawing.SystemColors.Window
        Me.txtREADNURE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREADNURE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREADNURE.ForeColor = System.Drawing.Color.Black
        Me.txtREADNURE.Location = New System.Drawing.Point(155, 49)
        Me.txtREADNURE.MaxLength = 9
        Me.txtREADNURE.Name = "txtREADNURE"
        Me.txtREADNURE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtREADNURE.Size = New System.Drawing.Size(160, 20)
        Me.txtREADNURE.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(20, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 20)
        Me.Label1.TabIndex = 429
        Me.Label1.Text = "Nro. Resolución"
        '
        'txtREADFERE
        '
        Me.txtREADFERE.AccessibleDescription = "Fecha resolución"
        Me.txtREADFERE.BackColor = System.Drawing.Color.White
        Me.txtREADFERE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREADFERE.Location = New System.Drawing.Point(155, 71)
        Me.txtREADFERE.Mask = "00-00-0000"
        Me.txtREADFERE.Name = "txtREADFERE"
        Me.txtREADFERE.Size = New System.Drawing.Size(160, 20)
        Me.txtREADFERE.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(20, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 20)
        Me.Label11.TabIndex = 425
        Me.Label11.Text = "Fecha de resolución"
        '
        'cboREADCLAS
        '
        Me.cboREADCLAS.AccessibleDescription = "Clasificación"
        Me.cboREADCLAS.BackColor = System.Drawing.Color.White
        Me.cboREADCLAS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboREADCLAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboREADCLAS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboREADCLAS.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboREADCLAS.Location = New System.Drawing.Point(155, 24)
        Me.cboREADCLAS.MaxDropDownItems = 15
        Me.cboREADCLAS.MaxLength = 1
        Me.cboREADCLAS.Name = "cboREADCLAS"
        Me.cboREADCLAS.Size = New System.Drawing.Size(465, 22)
        Me.cboREADCLAS.TabIndex = 1
        '
        'lblCategoriaDeSuelo
        '
        Me.lblCategoriaDeSuelo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCategoriaDeSuelo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCategoriaDeSuelo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoriaDeSuelo.ForeColor = System.Drawing.Color.Black
        Me.lblCategoriaDeSuelo.Location = New System.Drawing.Point(20, 26)
        Me.lblCategoriaDeSuelo.Name = "lblCategoriaDeSuelo"
        Me.lblCategoriaDeSuelo.Size = New System.Drawing.Size(132, 20)
        Me.lblCategoriaDeSuelo.TabIndex = 44
        Me.lblCategoriaDeSuelo.Text = "Clasificación"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 220)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(637, 46)
        Me.GroupBox1.TabIndex = 357
        Me.GroupBox1.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(321, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 2
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(214, 15)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 1
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 287)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(665, 25)
        Me.strBARRESTA.TabIndex = 358
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
        'frm_insertar_RESOADMI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 312)
        Me.Controls.Add(Me.fraFICHPRED)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(681, 348)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(681, 348)
        Me.Name = "frm_insertar_RESOADMI"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.fraFICHPRED.ResumeLayout(False)
        Me.fraFICHPRED.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraFICHPRED As System.Windows.Forms.GroupBox
    Friend WithEvents cboREADTIRE As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboREADCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboREADVIRE As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpREADFERE As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtREADNURE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtREADFERE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboREADCLAS As System.Windows.Forms.ComboBox
    Friend WithEvents lblCategoriaDeSuelo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cboREADESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
