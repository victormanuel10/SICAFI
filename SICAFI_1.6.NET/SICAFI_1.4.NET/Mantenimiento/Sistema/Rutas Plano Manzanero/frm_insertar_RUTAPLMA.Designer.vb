<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_RUTAPLMA
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
        Me.cboRUPMCLSE = New System.Windows.Forms.ComboBox()
        Me.cboRUPMDEPA = New System.Windows.Forms.ComboBox()
        Me.lblRUPMDEPA = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.lblRUPMCLSE = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdCARPETA = New System.Windows.Forms.Button()
        Me.txtRUPMRUTA = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboRUPMESTA = New System.Windows.Forms.ComboBox()
        Me.lblCAPRESTA = New System.Windows.Forms.Label()
        Me.cboRUPMCORR = New System.Windows.Forms.ComboBox()
        Me.cboRUPMMUNI = New System.Windows.Forms.ComboBox()
        Me.cboRUPMBAVE = New System.Windows.Forms.ComboBox()
        Me.lblRUPMBAVE = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblRUPMCORR = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.lblRUPMMUNI = New System.Windows.Forms.Label()
        Me.fraCOMANDOS = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1.SuspendLayout()
        Me.fraCOMANDOS.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboRUPMCLSE
        '
        Me.cboRUPMCLSE.AccessibleDescription = "Clase o sector "
        Me.cboRUPMCLSE.BackColor = System.Drawing.Color.White
        Me.cboRUPMCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUPMCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUPMCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUPMCLSE.Location = New System.Drawing.Point(145, 47)
        Me.cboRUPMCLSE.MaxDropDownItems = 15
        Me.cboRUPMCLSE.MaxLength = 1
        Me.cboRUPMCLSE.Name = "cboRUPMCLSE"
        Me.cboRUPMCLSE.Size = New System.Drawing.Size(222, 22)
        Me.cboRUPMCLSE.TabIndex = 2
        '
        'cboRUPMDEPA
        '
        Me.cboRUPMDEPA.AccessibleDescription = "Departamento"
        Me.cboRUPMDEPA.BackColor = System.Drawing.Color.White
        Me.cboRUPMDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUPMDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUPMDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUPMDEPA.Location = New System.Drawing.Point(145, 24)
        Me.cboRUPMDEPA.MaxDropDownItems = 15
        Me.cboRUPMDEPA.MaxLength = 1
        Me.cboRUPMDEPA.Name = "cboRUPMDEPA"
        Me.cboRUPMDEPA.Size = New System.Drawing.Size(222, 22)
        Me.cboRUPMDEPA.TabIndex = 1
        '
        'lblRUPMDEPA
        '
        Me.lblRUPMDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUPMDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUPMDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUPMDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblRUPMDEPA.Location = New System.Drawing.Point(370, 26)
        Me.lblRUPMDEPA.Name = "lblRUPMDEPA"
        Me.lblRUPMDEPA.Size = New System.Drawing.Size(345, 20)
        Me.lblRUPMDEPA.TabIndex = 387
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
        'lblRUPMCLSE
        '
        Me.lblRUPMCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUPMCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUPMCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUPMCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblRUPMCLSE.Location = New System.Drawing.Point(370, 49)
        Me.lblRUPMCLSE.Name = "lblRUPMCLSE"
        Me.lblRUPMCLSE.Size = New System.Drawing.Size(345, 20)
        Me.lblRUPMCLSE.TabIndex = 385
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(16, 49)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(126, 20)
        Me.Label27.TabIndex = 384
        Me.Label27.Text = "Clase o sector"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdCARPETA)
        Me.GroupBox1.Controls.Add(Me.txtRUPMRUTA)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboRUPMESTA)
        Me.GroupBox1.Controls.Add(Me.lblCAPRESTA)
        Me.GroupBox1.Controls.Add(Me.cboRUPMCORR)
        Me.GroupBox1.Controls.Add(Me.cboRUPMMUNI)
        Me.GroupBox1.Controls.Add(Me.cboRUPMBAVE)
        Me.GroupBox1.Controls.Add(Me.lblRUPMBAVE)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblRUPMCORR)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label60)
        Me.GroupBox1.Controls.Add(Me.lblRUPMMUNI)
        Me.GroupBox1.Controls.Add(Me.Label58)
        Me.GroupBox1.Controls.Add(Me.cboRUPMCLSE)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.cboRUPMDEPA)
        Me.GroupBox1.Controls.Add(Me.lblRUPMCLSE)
        Me.GroupBox1.Controls.Add(Me.lblRUPMDEPA)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(730, 230)
        Me.GroupBox1.TabIndex = 388
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "INSERTAR RUTA PLANO MANZANERO"
        '
        'cmdCARPETA
        '
        Me.cmdCARPETA.AccessibleDescription = "Carpeta"
        Me.cmdCARPETA.Image = Global.SICAFI.My.Resources.Resources._5
        Me.cmdCARPETA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCARPETA.Location = New System.Drawing.Point(16, 164)
        Me.cmdCARPETA.Name = "cmdCARPETA"
        Me.cmdCARPETA.Size = New System.Drawing.Size(126, 23)
        Me.cmdCARPETA.TabIndex = 5
        Me.cmdCARPETA.Text = "&Carpeta..."
        Me.cmdCARPETA.UseVisualStyleBackColor = True
        '
        'txtRUPMRUTA
        '
        Me.txtRUPMRUTA.AccessibleDescription = "Ruta"
        Me.txtRUPMRUTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtRUPMRUTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRUPMRUTA.Location = New System.Drawing.Point(145, 164)
        Me.txtRUPMRUTA.MaxLength = 200
        Me.txtRUPMRUTA.Name = "txtRUPMRUTA"
        Me.txtRUPMRUTA.Size = New System.Drawing.Size(570, 20)
        Me.txtRUPMRUTA.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 141)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(699, 20)
        Me.Label1.TabIndex = 401
        Me.Label1.Text = "Ruta de archivo"
        '
        'cboRUPMESTA
        '
        Me.cboRUPMESTA.AccessibleDescription = "Estado"
        Me.cboRUPMESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUPMESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUPMESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUPMESTA.FormattingEnabled = True
        Me.cboRUPMESTA.Items.AddRange(New Object() {""})
        Me.cboRUPMESTA.Location = New System.Drawing.Point(145, 189)
        Me.cboRUPMESTA.Name = "cboRUPMESTA"
        Me.cboRUPMESTA.Size = New System.Drawing.Size(222, 22)
        Me.cboRUPMESTA.TabIndex = 7
        '
        'lblCAPRESTA
        '
        Me.lblCAPRESTA.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCAPRESTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAPRESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAPRESTA.ForeColor = System.Drawing.Color.Black
        Me.lblCAPRESTA.Location = New System.Drawing.Point(15, 190)
        Me.lblCAPRESTA.Name = "lblCAPRESTA"
        Me.lblCAPRESTA.Size = New System.Drawing.Size(127, 20)
        Me.lblCAPRESTA.TabIndex = 400
        Me.lblCAPRESTA.Text = "Estado"
        '
        'cboRUPMCORR
        '
        Me.cboRUPMCORR.AccessibleDescription = "Corregimiento"
        Me.cboRUPMCORR.BackColor = System.Drawing.Color.White
        Me.cboRUPMCORR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUPMCORR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUPMCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUPMCORR.Location = New System.Drawing.Point(145, 93)
        Me.cboRUPMCORR.MaxDropDownItems = 15
        Me.cboRUPMCORR.MaxLength = 1
        Me.cboRUPMCORR.Name = "cboRUPMCORR"
        Me.cboRUPMCORR.Size = New System.Drawing.Size(222, 22)
        Me.cboRUPMCORR.TabIndex = 4
        '
        'cboRUPMMUNI
        '
        Me.cboRUPMMUNI.AccessibleDescription = "Municipio"
        Me.cboRUPMMUNI.BackColor = System.Drawing.Color.White
        Me.cboRUPMMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUPMMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUPMMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUPMMUNI.Location = New System.Drawing.Point(145, 70)
        Me.cboRUPMMUNI.MaxDropDownItems = 15
        Me.cboRUPMMUNI.MaxLength = 1
        Me.cboRUPMMUNI.Name = "cboRUPMMUNI"
        Me.cboRUPMMUNI.Size = New System.Drawing.Size(222, 22)
        Me.cboRUPMMUNI.TabIndex = 3
        '
        'cboRUPMBAVE
        '
        Me.cboRUPMBAVE.AccessibleDescription = "Barrio - Vereda"
        Me.cboRUPMBAVE.BackColor = System.Drawing.Color.White
        Me.cboRUPMBAVE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUPMBAVE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUPMBAVE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUPMBAVE.Location = New System.Drawing.Point(145, 116)
        Me.cboRUPMBAVE.MaxDropDownItems = 15
        Me.cboRUPMBAVE.MaxLength = 1
        Me.cboRUPMBAVE.Name = "cboRUPMBAVE"
        Me.cboRUPMBAVE.Size = New System.Drawing.Size(222, 22)
        Me.cboRUPMBAVE.TabIndex = 390
        '
        'lblRUPMBAVE
        '
        Me.lblRUPMBAVE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUPMBAVE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUPMBAVE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUPMBAVE.ForeColor = System.Drawing.Color.Black
        Me.lblRUPMBAVE.Location = New System.Drawing.Point(370, 118)
        Me.lblRUPMBAVE.Name = "lblRUPMBAVE"
        Me.lblRUPMBAVE.Size = New System.Drawing.Size(345, 20)
        Me.lblRUPMBAVE.TabIndex = 396
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(16, 118)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(126, 20)
        Me.Label8.TabIndex = 395
        Me.Label8.Text = "Barrio - Vereda"
        '
        'lblRUPMCORR
        '
        Me.lblRUPMCORR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUPMCORR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUPMCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUPMCORR.ForeColor = System.Drawing.Color.Black
        Me.lblRUPMCORR.Location = New System.Drawing.Point(370, 95)
        Me.lblRUPMCORR.Name = "lblRUPMCORR"
        Me.lblRUPMCORR.Size = New System.Drawing.Size(345, 20)
        Me.lblRUPMCORR.TabIndex = 394
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
        Me.Label3.Text = "Corregimiento"
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label60.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label60.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.ForeColor = System.Drawing.Color.Black
        Me.Label60.Location = New System.Drawing.Point(16, 72)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(126, 20)
        Me.Label60.TabIndex = 392
        Me.Label60.Text = "Municipio"
        '
        'lblRUPMMUNI
        '
        Me.lblRUPMMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUPMMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUPMMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUPMMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblRUPMMUNI.Location = New System.Drawing.Point(370, 72)
        Me.lblRUPMMUNI.Name = "lblRUPMMUNI"
        Me.lblRUPMMUNI.Size = New System.Drawing.Size(345, 20)
        Me.lblRUPMMUNI.TabIndex = 391
        '
        'fraCOMANDOS
        '
        Me.fraCOMANDOS.Controls.Add(Me.cmdSALIR)
        Me.fraCOMANDOS.Controls.Add(Me.cmdGUARDAR)
        Me.fraCOMANDOS.Location = New System.Drawing.Point(12, 248)
        Me.fraCOMANDOS.Name = "fraCOMANDOS"
        Me.fraCOMANDOS.Size = New System.Drawing.Size(730, 50)
        Me.fraCOMANDOS.TabIndex = 389
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 311)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(754, 25)
        Me.strBARRESTA.TabIndex = 390
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
        'frm_insertar_RUTAPLMA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 336)
        Me.Controls.Add(Me.fraCOMANDOS)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(770, 372)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(770, 372)
        Me.Name = "frm_insertar_RUTAPLMA"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.fraCOMANDOS.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboRUPMCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents cboRUPMDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents lblRUPMDEPA As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents lblRUPMCLSE As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboRUPMCORR As System.Windows.Forms.ComboBox
    Friend WithEvents cboRUPMMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents cboRUPMBAVE As System.Windows.Forms.ComboBox
    Friend WithEvents lblRUPMBAVE As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblRUPMCORR As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents lblRUPMMUNI As System.Windows.Forms.Label
    Friend WithEvents cmdCARPETA As System.Windows.Forms.Button
    Friend WithEvents txtRUPMRUTA As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboRUPMESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCAPRESTA As System.Windows.Forms.Label
    Friend WithEvents fraCOMANDOS As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
End Class
