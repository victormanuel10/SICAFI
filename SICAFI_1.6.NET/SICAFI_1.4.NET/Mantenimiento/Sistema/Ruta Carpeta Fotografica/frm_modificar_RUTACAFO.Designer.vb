<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_RUTACAFO
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
        Me.fraCOMANDOS = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdCARPETA = New System.Windows.Forms.Button()
        Me.txtRUCFRUTA = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblRUCFCAFO = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboRUCFCAFO = New System.Windows.Forms.ComboBox()
        Me.cboRUCFESTA = New System.Windows.Forms.ComboBox()
        Me.lblCAPRESTA = New System.Windows.Forms.Label()
        Me.cboRUCFMUNI = New System.Windows.Forms.ComboBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.lblRUCFMUNI = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.cboRUCFCLSE = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cboRUCFDEPA = New System.Windows.Forms.ComboBox()
        Me.lblRUCFCLSE = New System.Windows.Forms.Label()
        Me.lblRUCFDEPA = New System.Windows.Forms.Label()
        Me.fraCOMANDOS.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraCOMANDOS
        '
        Me.fraCOMANDOS.Controls.Add(Me.cmdSALIR)
        Me.fraCOMANDOS.Controls.Add(Me.cmdGUARDAR)
        Me.fraCOMANDOS.Location = New System.Drawing.Point(12, 221)
        Me.fraCOMANDOS.Name = "fraCOMANDOS"
        Me.fraCOMANDOS.Size = New System.Drawing.Size(730, 50)
        Me.fraCOMANDOS.TabIndex = 395
        Me.fraCOMANDOS.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(362, 16)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(255, 16)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 284)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(754, 25)
        Me.strBARRESTA.TabIndex = 396
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdCARPETA)
        Me.GroupBox1.Controls.Add(Me.txtRUCFRUTA)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblRUCFCAFO)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboRUCFCAFO)
        Me.GroupBox1.Controls.Add(Me.cboRUCFESTA)
        Me.GroupBox1.Controls.Add(Me.lblCAPRESTA)
        Me.GroupBox1.Controls.Add(Me.cboRUCFMUNI)
        Me.GroupBox1.Controls.Add(Me.Label60)
        Me.GroupBox1.Controls.Add(Me.lblRUCFMUNI)
        Me.GroupBox1.Controls.Add(Me.Label58)
        Me.GroupBox1.Controls.Add(Me.cboRUCFCLSE)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.cboRUCFDEPA)
        Me.GroupBox1.Controls.Add(Me.lblRUCFCLSE)
        Me.GroupBox1.Controls.Add(Me.lblRUCFDEPA)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(730, 203)
        Me.GroupBox1.TabIndex = 394
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MODIFICAR RUTA CARPETA FOTOGRAFICA"
        '
        'cmdCARPETA
        '
        Me.cmdCARPETA.AccessibleDescription = "Carpeta"
        Me.cmdCARPETA.Image = Global.SICAFI.My.Resources.Resources._5
        Me.cmdCARPETA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCARPETA.Location = New System.Drawing.Point(16, 141)
        Me.cmdCARPETA.Name = "cmdCARPETA"
        Me.cmdCARPETA.Size = New System.Drawing.Size(126, 23)
        Me.cmdCARPETA.TabIndex = 5
        Me.cmdCARPETA.Text = "&Carpeta..."
        Me.cmdCARPETA.UseVisualStyleBackColor = True
        '
        'txtRUCFRUTA
        '
        Me.txtRUCFRUTA.AccessibleDescription = "Ruta"
        Me.txtRUCFRUTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtRUCFRUTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRUCFRUTA.Location = New System.Drawing.Point(145, 141)
        Me.txtRUCFRUTA.MaxLength = 200
        Me.txtRUCFRUTA.Name = "txtRUCFRUTA"
        Me.txtRUCFRUTA.Size = New System.Drawing.Size(570, 20)
        Me.txtRUCFRUTA.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 20)
        Me.Label3.TabIndex = 393
        Me.Label3.Text = "Carpeta"
        '
        'lblRUCFCAFO
        '
        Me.lblRUCFCAFO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUCFCAFO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUCFCAFO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUCFCAFO.ForeColor = System.Drawing.Color.Black
        Me.lblRUCFCAFO.Location = New System.Drawing.Point(370, 95)
        Me.lblRUCFCAFO.Name = "lblRUCFCAFO"
        Me.lblRUCFCAFO.Size = New System.Drawing.Size(345, 20)
        Me.lblRUCFCAFO.TabIndex = 394
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(699, 20)
        Me.Label1.TabIndex = 401
        Me.Label1.Text = "Ruta de archivo"
        '
        'cboRUCFCAFO
        '
        Me.cboRUCFCAFO.AccessibleDescription = "Carpeta"
        Me.cboRUCFCAFO.BackColor = System.Drawing.Color.White
        Me.cboRUCFCAFO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUCFCAFO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUCFCAFO.Enabled = False
        Me.cboRUCFCAFO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUCFCAFO.Location = New System.Drawing.Point(145, 93)
        Me.cboRUCFCAFO.MaxDropDownItems = 15
        Me.cboRUCFCAFO.MaxLength = 1
        Me.cboRUCFCAFO.Name = "cboRUCFCAFO"
        Me.cboRUCFCAFO.Size = New System.Drawing.Size(222, 22)
        Me.cboRUCFCAFO.TabIndex = 4
        '
        'cboRUCFESTA
        '
        Me.cboRUCFESTA.AccessibleDescription = "Estado"
        Me.cboRUCFESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUCFESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUCFESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUCFESTA.FormattingEnabled = True
        Me.cboRUCFESTA.Items.AddRange(New Object() {""})
        Me.cboRUCFESTA.Location = New System.Drawing.Point(145, 166)
        Me.cboRUCFESTA.Name = "cboRUCFESTA"
        Me.cboRUCFESTA.Size = New System.Drawing.Size(222, 22)
        Me.cboRUCFESTA.TabIndex = 6
        '
        'lblCAPRESTA
        '
        Me.lblCAPRESTA.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCAPRESTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAPRESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAPRESTA.ForeColor = System.Drawing.Color.Black
        Me.lblCAPRESTA.Location = New System.Drawing.Point(15, 167)
        Me.lblCAPRESTA.Name = "lblCAPRESTA"
        Me.lblCAPRESTA.Size = New System.Drawing.Size(127, 20)
        Me.lblCAPRESTA.TabIndex = 400
        Me.lblCAPRESTA.Text = "Estado"
        '
        'cboRUCFMUNI
        '
        Me.cboRUCFMUNI.AccessibleDescription = "Municipio"
        Me.cboRUCFMUNI.BackColor = System.Drawing.Color.White
        Me.cboRUCFMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUCFMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUCFMUNI.Enabled = False
        Me.cboRUCFMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUCFMUNI.Location = New System.Drawing.Point(145, 47)
        Me.cboRUCFMUNI.MaxDropDownItems = 15
        Me.cboRUCFMUNI.MaxLength = 1
        Me.cboRUCFMUNI.Name = "cboRUCFMUNI"
        Me.cboRUCFMUNI.Size = New System.Drawing.Size(222, 22)
        Me.cboRUCFMUNI.TabIndex = 2
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label60.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label60.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.ForeColor = System.Drawing.Color.Black
        Me.Label60.Location = New System.Drawing.Point(16, 49)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(126, 20)
        Me.Label60.TabIndex = 392
        Me.Label60.Text = "Municipio"
        '
        'lblRUCFMUNI
        '
        Me.lblRUCFMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUCFMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUCFMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUCFMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblRUCFMUNI.Location = New System.Drawing.Point(370, 49)
        Me.lblRUCFMUNI.Name = "lblRUCFMUNI"
        Me.lblRUCFMUNI.Size = New System.Drawing.Size(345, 20)
        Me.lblRUCFMUNI.TabIndex = 391
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label58.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label58.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.Black
        Me.Label58.Location = New System.Drawing.Point(16, 26)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(126, 20)
        Me.Label58.TabIndex = 386
        Me.Label58.Text = "Departamento"
        '
        'cboRUCFCLSE
        '
        Me.cboRUCFCLSE.AccessibleDescription = "Clase o sector "
        Me.cboRUCFCLSE.BackColor = System.Drawing.Color.White
        Me.cboRUCFCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUCFCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUCFCLSE.Enabled = False
        Me.cboRUCFCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUCFCLSE.Location = New System.Drawing.Point(145, 70)
        Me.cboRUCFCLSE.MaxDropDownItems = 15
        Me.cboRUCFCLSE.MaxLength = 1
        Me.cboRUCFCLSE.Name = "cboRUCFCLSE"
        Me.cboRUCFCLSE.Size = New System.Drawing.Size(222, 22)
        Me.cboRUCFCLSE.TabIndex = 3
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(16, 72)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(126, 20)
        Me.Label27.TabIndex = 384
        Me.Label27.Text = "Clase o sector"
        '
        'cboRUCFDEPA
        '
        Me.cboRUCFDEPA.AccessibleDescription = "Departamento"
        Me.cboRUCFDEPA.BackColor = System.Drawing.Color.White
        Me.cboRUCFDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUCFDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUCFDEPA.Enabled = False
        Me.cboRUCFDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUCFDEPA.Location = New System.Drawing.Point(145, 24)
        Me.cboRUCFDEPA.MaxDropDownItems = 15
        Me.cboRUCFDEPA.MaxLength = 1
        Me.cboRUCFDEPA.Name = "cboRUCFDEPA"
        Me.cboRUCFDEPA.Size = New System.Drawing.Size(222, 22)
        Me.cboRUCFDEPA.TabIndex = 1
        '
        'lblRUCFCLSE
        '
        Me.lblRUCFCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUCFCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUCFCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUCFCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblRUCFCLSE.Location = New System.Drawing.Point(370, 72)
        Me.lblRUCFCLSE.Name = "lblRUCFCLSE"
        Me.lblRUCFCLSE.Size = New System.Drawing.Size(345, 20)
        Me.lblRUCFCLSE.TabIndex = 385
        '
        'lblRUCFDEPA
        '
        Me.lblRUCFDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUCFDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUCFDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUCFDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblRUCFDEPA.Location = New System.Drawing.Point(370, 26)
        Me.lblRUCFDEPA.Name = "lblRUCFDEPA"
        Me.lblRUCFDEPA.Size = New System.Drawing.Size(345, 20)
        Me.lblRUCFDEPA.TabIndex = 387
        '
        'frm_modificar_RUTACAFO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 309)
        Me.Controls.Add(Me.fraCOMANDOS)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(770, 345)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(770, 345)
        Me.Name = "frm_modificar_RUTACAFO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.fraCOMANDOS.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraCOMANDOS As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCARPETA As System.Windows.Forms.Button
    Friend WithEvents txtRUCFRUTA As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblRUCFCAFO As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboRUCFCAFO As System.Windows.Forms.ComboBox
    Friend WithEvents cboRUCFESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCAPRESTA As System.Windows.Forms.Label
    Friend WithEvents cboRUCFMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents lblRUCFMUNI As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents cboRUCFCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cboRUCFDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents lblRUCFCLSE As System.Windows.Forms.Label
    Friend WithEvents lblRUCFDEPA As System.Windows.Forms.Label
End Class
