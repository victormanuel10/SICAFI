<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_RUTAFPDI
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
        Me.rbdFPDIARCH = New System.Windows.Forms.RadioButton()
        Me.rbdFPDICARP = New System.Windows.Forms.RadioButton()
        Me.cmdCARPETA = New System.Windows.Forms.Button()
        Me.txtRUFDRUTA = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblRUFDFPDI = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboRUFDFPDI = New System.Windows.Forms.ComboBox()
        Me.cboRUFDESTA = New System.Windows.Forms.ComboBox()
        Me.lblCAPRESTA = New System.Windows.Forms.Label()
        Me.cboRUFDMUNI = New System.Windows.Forms.ComboBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.lblRUFDMUNI = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.cboRUFDCLSE = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cboRUFDDEPA = New System.Windows.Forms.ComboBox()
        Me.lblRUFDCLSE = New System.Windows.Forms.Label()
        Me.lblRUFDDEPA = New System.Windows.Forms.Label()
        Me.fraCOMANDOS.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraCOMANDOS
        '
        Me.fraCOMANDOS.Controls.Add(Me.cmdSALIR)
        Me.fraCOMANDOS.Controls.Add(Me.cmdGUARDAR)
        Me.fraCOMANDOS.Location = New System.Drawing.Point(12, 218)
        Me.fraCOMANDOS.Name = "fraCOMANDOS"
        Me.fraCOMANDOS.Size = New System.Drawing.Size(730, 50)
        Me.fraCOMANDOS.TabIndex = 401
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
        Me.strBARRESTA.TabIndex = 402
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
        Me.GroupBox1.Controls.Add(Me.rbdFPDIARCH)
        Me.GroupBox1.Controls.Add(Me.rbdFPDICARP)
        Me.GroupBox1.Controls.Add(Me.cmdCARPETA)
        Me.GroupBox1.Controls.Add(Me.txtRUFDRUTA)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblRUFDFPDI)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboRUFDFPDI)
        Me.GroupBox1.Controls.Add(Me.cboRUFDESTA)
        Me.GroupBox1.Controls.Add(Me.lblCAPRESTA)
        Me.GroupBox1.Controls.Add(Me.cboRUFDMUNI)
        Me.GroupBox1.Controls.Add(Me.Label60)
        Me.GroupBox1.Controls.Add(Me.lblRUFDMUNI)
        Me.GroupBox1.Controls.Add(Me.Label58)
        Me.GroupBox1.Controls.Add(Me.cboRUFDCLSE)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.cboRUFDDEPA)
        Me.GroupBox1.Controls.Add(Me.lblRUFDCLSE)
        Me.GroupBox1.Controls.Add(Me.lblRUFDDEPA)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(730, 203)
        Me.GroupBox1.TabIndex = 400
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MODIFICAR RUTA FICHA PREDIAL DIGITAL"
        '
        'rbdFPDIARCH
        '
        Me.rbdFPDIARCH.Location = New System.Drawing.Point(560, 118)
        Me.rbdFPDIARCH.Name = "rbdFPDIARCH"
        Me.rbdFPDIARCH.Size = New System.Drawing.Size(78, 17)
        Me.rbdFPDIARCH.TabIndex = 405
        Me.rbdFPDIARCH.Text = "Archivo"
        Me.rbdFPDIARCH.UseVisualStyleBackColor = True
        '
        'rbdFPDICARP
        '
        Me.rbdFPDICARP.Checked = True
        Me.rbdFPDICARP.Location = New System.Drawing.Point(466, 118)
        Me.rbdFPDICARP.Name = "rbdFPDICARP"
        Me.rbdFPDICARP.Size = New System.Drawing.Size(78, 17)
        Me.rbdFPDICARP.TabIndex = 404
        Me.rbdFPDICARP.TabStop = True
        Me.rbdFPDICARP.Text = "Carpeta"
        Me.rbdFPDICARP.UseVisualStyleBackColor = True
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
        Me.cmdCARPETA.Text = "Selección ruta..."
        Me.cmdCARPETA.UseVisualStyleBackColor = True
        '
        'txtRUFDRUTA
        '
        Me.txtRUFDRUTA.AccessibleDescription = "Ruta"
        Me.txtRUFDRUTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtRUFDRUTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRUFDRUTA.Location = New System.Drawing.Point(145, 141)
        Me.txtRUFDRUTA.MaxLength = 200
        Me.txtRUFDRUTA.Name = "txtRUFDRUTA"
        Me.txtRUFDRUTA.Size = New System.Drawing.Size(570, 20)
        Me.txtRUFDRUTA.TabIndex = 5
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
        Me.Label3.Text = "Ruta especifica"
        '
        'lblRUFDFPDI
        '
        Me.lblRUFDFPDI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUFDFPDI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUFDFPDI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUFDFPDI.ForeColor = System.Drawing.Color.Black
        Me.lblRUFDFPDI.Location = New System.Drawing.Point(370, 95)
        Me.lblRUFDFPDI.Name = "lblRUFDFPDI"
        Me.lblRUFDFPDI.Size = New System.Drawing.Size(345, 20)
        Me.lblRUFDFPDI.TabIndex = 394
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(351, 20)
        Me.Label1.TabIndex = 401
        Me.Label1.Text = "Ruta de archivo"
        '
        'cboRUFDFPDI
        '
        Me.cboRUFDFPDI.AccessibleDescription = "Ficha predial digital"
        Me.cboRUFDFPDI.BackColor = System.Drawing.Color.White
        Me.cboRUFDFPDI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUFDFPDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUFDFPDI.Enabled = False
        Me.cboRUFDFPDI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUFDFPDI.Location = New System.Drawing.Point(145, 93)
        Me.cboRUFDFPDI.MaxDropDownItems = 15
        Me.cboRUFDFPDI.MaxLength = 1
        Me.cboRUFDFPDI.Name = "cboRUFDFPDI"
        Me.cboRUFDFPDI.Size = New System.Drawing.Size(222, 22)
        Me.cboRUFDFPDI.TabIndex = 4
        '
        'cboRUFDESTA
        '
        Me.cboRUFDESTA.AccessibleDescription = "Estado"
        Me.cboRUFDESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUFDESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUFDESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUFDESTA.FormattingEnabled = True
        Me.cboRUFDESTA.Items.AddRange(New Object() {""})
        Me.cboRUFDESTA.Location = New System.Drawing.Point(145, 166)
        Me.cboRUFDESTA.Name = "cboRUFDESTA"
        Me.cboRUFDESTA.Size = New System.Drawing.Size(222, 22)
        Me.cboRUFDESTA.TabIndex = 6
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
        'cboRUFDMUNI
        '
        Me.cboRUFDMUNI.AccessibleDescription = "Municipio"
        Me.cboRUFDMUNI.BackColor = System.Drawing.Color.White
        Me.cboRUFDMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUFDMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUFDMUNI.Enabled = False
        Me.cboRUFDMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUFDMUNI.Location = New System.Drawing.Point(145, 47)
        Me.cboRUFDMUNI.MaxDropDownItems = 15
        Me.cboRUFDMUNI.MaxLength = 1
        Me.cboRUFDMUNI.Name = "cboRUFDMUNI"
        Me.cboRUFDMUNI.Size = New System.Drawing.Size(222, 22)
        Me.cboRUFDMUNI.TabIndex = 2
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
        'lblRUFDMUNI
        '
        Me.lblRUFDMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUFDMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUFDMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUFDMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblRUFDMUNI.Location = New System.Drawing.Point(370, 49)
        Me.lblRUFDMUNI.Name = "lblRUFDMUNI"
        Me.lblRUFDMUNI.Size = New System.Drawing.Size(345, 20)
        Me.lblRUFDMUNI.TabIndex = 391
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
        'cboRUFDCLSE
        '
        Me.cboRUFDCLSE.AccessibleDescription = "Clase o sector "
        Me.cboRUFDCLSE.BackColor = System.Drawing.Color.White
        Me.cboRUFDCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUFDCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUFDCLSE.Enabled = False
        Me.cboRUFDCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUFDCLSE.Location = New System.Drawing.Point(145, 70)
        Me.cboRUFDCLSE.MaxDropDownItems = 15
        Me.cboRUFDCLSE.MaxLength = 1
        Me.cboRUFDCLSE.Name = "cboRUFDCLSE"
        Me.cboRUFDCLSE.Size = New System.Drawing.Size(222, 22)
        Me.cboRUFDCLSE.TabIndex = 3
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
        'cboRUFDDEPA
        '
        Me.cboRUFDDEPA.AccessibleDescription = "Departamento"
        Me.cboRUFDDEPA.BackColor = System.Drawing.Color.White
        Me.cboRUFDDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUFDDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUFDDEPA.Enabled = False
        Me.cboRUFDDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUFDDEPA.Location = New System.Drawing.Point(145, 24)
        Me.cboRUFDDEPA.MaxDropDownItems = 15
        Me.cboRUFDDEPA.MaxLength = 1
        Me.cboRUFDDEPA.Name = "cboRUFDDEPA"
        Me.cboRUFDDEPA.Size = New System.Drawing.Size(222, 22)
        Me.cboRUFDDEPA.TabIndex = 1
        '
        'lblRUFDCLSE
        '
        Me.lblRUFDCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUFDCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUFDCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUFDCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblRUFDCLSE.Location = New System.Drawing.Point(370, 72)
        Me.lblRUFDCLSE.Name = "lblRUFDCLSE"
        Me.lblRUFDCLSE.Size = New System.Drawing.Size(345, 20)
        Me.lblRUFDCLSE.TabIndex = 385
        '
        'lblRUFDDEPA
        '
        Me.lblRUFDDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUFDDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUFDDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUFDDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblRUFDDEPA.Location = New System.Drawing.Point(370, 26)
        Me.lblRUFDDEPA.Name = "lblRUFDDEPA"
        Me.lblRUFDDEPA.Size = New System.Drawing.Size(345, 20)
        Me.lblRUFDDEPA.TabIndex = 387
        '
        'frm_modificar_RUTAFPDI
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
        Me.Name = "frm_modificar_RUTAFPDI"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modifica registro"
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
    Friend WithEvents txtRUFDRUTA As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblRUFDFPDI As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboRUFDFPDI As System.Windows.Forms.ComboBox
    Friend WithEvents cboRUFDESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCAPRESTA As System.Windows.Forms.Label
    Friend WithEvents cboRUFDMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents lblRUFDMUNI As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents cboRUFDCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cboRUFDDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents lblRUFDCLSE As System.Windows.Forms.Label
    Friend WithEvents lblRUFDDEPA As System.Windows.Forms.Label
    Friend WithEvents rbdFPDIARCH As System.Windows.Forms.RadioButton
    Friend WithEvents rbdFPDICARP As System.Windows.Forms.RadioButton
End Class
