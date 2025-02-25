<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_TARIRAAV
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
        Me.fraTARIRAAV = New System.Windows.Forms.GroupBox()
        Me.lblTARATIPO = New System.Windows.Forms.Label()
        Me.cboTARATIPO = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTARAESTR = New System.Windows.Forms.Label()
        Me.cboTARAESTR = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTARAAVFI = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTARAAVIN = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTARATARI = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblTARADEEC = New System.Windows.Forms.Label()
        Me.cboTARADEEC = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblTARAVIGE = New System.Windows.Forms.Label()
        Me.cboTARAVIGE = New System.Windows.Forms.ComboBox()
        Me.lblTARACLSE = New System.Windows.Forms.Label()
        Me.cboTARACLSE = New System.Windows.Forms.ComboBox()
        Me.lblClaseosector = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTARADEPA = New System.Windows.Forms.Label()
        Me.cboTARADEPA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTARAMUNI = New System.Windows.Forms.Label()
        Me.cboTARAMUNI = New System.Windows.Forms.ComboBox()
        Me.lblMUNICIPIO = New System.Windows.Forms.Label()
        Me.cboTARAESTA = New System.Windows.Forms.ComboBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraTARIRAAV.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 315)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(576, 52)
        Me.GroupBox1.TabIndex = 47
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
        Me.cmdSALIR.TabIndex = 21
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
        Me.cmdGUARDAR.TabIndex = 20
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 392)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(603, 25)
        Me.strBARRESTA.TabIndex = 48
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
        'fraTARIRAAV
        '
        Me.fraTARIRAAV.BackColor = System.Drawing.SystemColors.Control
        Me.fraTARIRAAV.Controls.Add(Me.lblTARATIPO)
        Me.fraTARIRAAV.Controls.Add(Me.cboTARATIPO)
        Me.fraTARIRAAV.Controls.Add(Me.Label5)
        Me.fraTARIRAAV.Controls.Add(Me.lblTARAESTR)
        Me.fraTARIRAAV.Controls.Add(Me.cboTARAESTR)
        Me.fraTARIRAAV.Controls.Add(Me.Label2)
        Me.fraTARIRAAV.Controls.Add(Me.txtTARAAVFI)
        Me.fraTARIRAAV.Controls.Add(Me.Label9)
        Me.fraTARIRAAV.Controls.Add(Me.txtTARAAVIN)
        Me.fraTARIRAAV.Controls.Add(Me.Label17)
        Me.fraTARIRAAV.Controls.Add(Me.txtTARATARI)
        Me.fraTARIRAAV.Controls.Add(Me.Label14)
        Me.fraTARIRAAV.Controls.Add(Me.lblTARADEEC)
        Me.fraTARIRAAV.Controls.Add(Me.cboTARADEEC)
        Me.fraTARIRAAV.Controls.Add(Me.Label11)
        Me.fraTARIRAAV.Controls.Add(Me.lblTARAVIGE)
        Me.fraTARIRAAV.Controls.Add(Me.cboTARAVIGE)
        Me.fraTARIRAAV.Controls.Add(Me.lblTARACLSE)
        Me.fraTARIRAAV.Controls.Add(Me.cboTARACLSE)
        Me.fraTARIRAAV.Controls.Add(Me.lblClaseosector)
        Me.fraTARIRAAV.Controls.Add(Me.Label3)
        Me.fraTARIRAAV.Controls.Add(Me.lblTARADEPA)
        Me.fraTARIRAAV.Controls.Add(Me.cboTARADEPA)
        Me.fraTARIRAAV.Controls.Add(Me.Label4)
        Me.fraTARIRAAV.Controls.Add(Me.lblTARAMUNI)
        Me.fraTARIRAAV.Controls.Add(Me.cboTARAMUNI)
        Me.fraTARIRAAV.Controls.Add(Me.lblMUNICIPIO)
        Me.fraTARIRAAV.Controls.Add(Me.cboTARAESTA)
        Me.fraTARIRAAV.Controls.Add(Me.lblCodigo)
        Me.fraTARIRAAV.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraTARIRAAV.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraTARIRAAV.Location = New System.Drawing.Point(12, 12)
        Me.fraTARIRAAV.Name = "fraTARIRAAV"
        Me.fraTARIRAAV.Size = New System.Drawing.Size(576, 297)
        Me.fraTARIRAAV.TabIndex = 46
        Me.fraTARIRAAV.TabStop = False
        Me.fraTARIRAAV.Text = "INSERTAR TARIFAS POR RANGOS DE AVALÚOS"
        '
        'lblTARATIPO
        '
        Me.lblTARATIPO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTARATIPO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTARATIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTARATIPO.ForeColor = System.Drawing.Color.Black
        Me.lblTARATIPO.Location = New System.Drawing.Point(450, 166)
        Me.lblTARATIPO.Name = "lblTARATIPO"
        Me.lblTARATIPO.Size = New System.Drawing.Size(108, 20)
        Me.lblTARATIPO.TabIndex = 97
        '
        'cboTARATIPO
        '
        Me.cboTARATIPO.AccessibleDescription = "Tipo calicación"
        Me.cboTARATIPO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTARATIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTARATIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTARATIPO.FormattingEnabled = True
        Me.cboTARATIPO.Location = New System.Drawing.Point(137, 164)
        Me.cboTARATIPO.Name = "cboTARATIPO"
        Me.cboTARATIPO.Size = New System.Drawing.Size(307, 22)
        Me.cboTARATIPO.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 96
        Me.Label5.Text = "Tipo calificación"
        '
        'lblTARAESTR
        '
        Me.lblTARAESTR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTARAESTR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTARAESTR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTARAESTR.ForeColor = System.Drawing.Color.Black
        Me.lblTARAESTR.Location = New System.Drawing.Point(450, 143)
        Me.lblTARAESTR.Name = "lblTARAESTR"
        Me.lblTARAESTR.Size = New System.Drawing.Size(108, 20)
        Me.lblTARAESTR.TabIndex = 94
        '
        'cboTARAESTR
        '
        Me.cboTARAESTR.AccessibleDescription = "Estrato"
        Me.cboTARAESTR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTARAESTR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTARAESTR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTARAESTR.FormattingEnabled = True
        Me.cboTARAESTR.Location = New System.Drawing.Point(137, 141)
        Me.cboTARAESTR.Name = "cboTARAESTR"
        Me.cboTARAESTR.Size = New System.Drawing.Size(307, 22)
        Me.cboTARAESTR.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Estrato"
        '
        'txtTARAAVFI
        '
        Me.txtTARAAVFI.AccessibleDescription = "Avalúo final"
        Me.txtTARAAVFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTARAAVFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTARAAVFI.Location = New System.Drawing.Point(137, 235)
        Me.txtTARAAVFI.MaxLength = 12
        Me.txtTARAAVFI.Name = "txtTARAAVFI"
        Me.txtTARAAVFI.Size = New System.Drawing.Size(112, 20)
        Me.txtTARAAVFI.TabIndex = 10
        Me.txtTARAAVFI.Text = "0"
        Me.txtTARAAVFI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(19, 235)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 20)
        Me.Label9.TabIndex = 91
        Me.Label9.Text = "$ Avalúo final"
        '
        'txtTARAAVIN
        '
        Me.txtTARAAVIN.AccessibleDescription = "Avaluo inicial"
        Me.txtTARAAVIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtTARAAVIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTARAAVIN.Location = New System.Drawing.Point(137, 212)
        Me.txtTARAAVIN.MaxLength = 12
        Me.txtTARAAVIN.Name = "txtTARAAVIN"
        Me.txtTARAAVIN.Size = New System.Drawing.Size(112, 20)
        Me.txtTARAAVIN.TabIndex = 9
        Me.txtTARAAVIN.Text = "0"
        Me.txtTARAAVIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(19, 212)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(112, 20)
        Me.Label17.TabIndex = 90
        Me.Label17.Text = "$ Avalúo inicial"
        '
        'txtTARATARI
        '
        Me.txtTARATARI.AccessibleDescription = "Tarifa "
        Me.txtTARATARI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTARATARI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTARATARI.Location = New System.Drawing.Point(137, 189)
        Me.txtTARATARI.MaxLength = 9
        Me.txtTARATARI.Name = "txtTARATARI"
        Me.txtTARATARI.Size = New System.Drawing.Size(112, 20)
        Me.txtTARATARI.TabIndex = 8
        Me.txtTARATARI.Text = "0.0"
        Me.txtTARATARI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(19, 189)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(112, 20)
        Me.Label14.TabIndex = 82
        Me.Label14.Text = "Tarifa "
        '
        'lblTARADEEC
        '
        Me.lblTARADEEC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTARADEEC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTARADEEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTARADEEC.ForeColor = System.Drawing.Color.Black
        Me.lblTARADEEC.Location = New System.Drawing.Point(450, 120)
        Me.lblTARADEEC.Name = "lblTARADEEC"
        Me.lblTARADEEC.Size = New System.Drawing.Size(108, 20)
        Me.lblTARADEEC.TabIndex = 78
        '
        'cboTARADEEC
        '
        Me.cboTARADEEC.AccessibleDescription = "Destinación"
        Me.cboTARADEEC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTARADEEC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTARADEEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTARADEEC.FormattingEnabled = True
        Me.cboTARADEEC.Location = New System.Drawing.Point(137, 118)
        Me.cboTARADEEC.Name = "cboTARADEEC"
        Me.cboTARADEEC.Size = New System.Drawing.Size(307, 22)
        Me.cboTARADEEC.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(19, 120)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 20)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "Destino Económico"
        '
        'lblTARAVIGE
        '
        Me.lblTARAVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTARAVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTARAVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTARAVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblTARAVIGE.Location = New System.Drawing.Point(450, 97)
        Me.lblTARAVIGE.Name = "lblTARAVIGE"
        Me.lblTARAVIGE.Size = New System.Drawing.Size(108, 20)
        Me.lblTARAVIGE.TabIndex = 62
        '
        'cboTARAVIGE
        '
        Me.cboTARAVIGE.AccessibleDescription = "Vigencia"
        Me.cboTARAVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTARAVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTARAVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTARAVIGE.FormattingEnabled = True
        Me.cboTARAVIGE.Location = New System.Drawing.Point(137, 95)
        Me.cboTARAVIGE.Name = "cboTARAVIGE"
        Me.cboTARAVIGE.Size = New System.Drawing.Size(307, 22)
        Me.cboTARAVIGE.TabIndex = 4
        '
        'lblTARACLSE
        '
        Me.lblTARACLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTARACLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTARACLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTARACLSE.ForeColor = System.Drawing.Color.Black
        Me.lblTARACLSE.Location = New System.Drawing.Point(450, 74)
        Me.lblTARACLSE.Name = "lblTARACLSE"
        Me.lblTARACLSE.Size = New System.Drawing.Size(108, 20)
        Me.lblTARACLSE.TabIndex = 57
        '
        'cboTARACLSE
        '
        Me.cboTARACLSE.AccessibleDescription = "Clase o sector"
        Me.cboTARACLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTARACLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTARACLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTARACLSE.FormattingEnabled = True
        Me.cboTARACLSE.Location = New System.Drawing.Point(137, 72)
        Me.cboTARACLSE.Name = "cboTARACLSE"
        Me.cboTARACLSE.Size = New System.Drawing.Size(307, 22)
        Me.cboTARACLSE.TabIndex = 3
        '
        'lblClaseosector
        '
        Me.lblClaseosector.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseosector.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseosector.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseosector.ForeColor = System.Drawing.Color.Black
        Me.lblClaseosector.Location = New System.Drawing.Point(19, 74)
        Me.lblClaseosector.Name = "lblClaseosector"
        Me.lblClaseosector.Size = New System.Drawing.Size(112, 20)
        Me.lblClaseosector.TabIndex = 56
        Me.lblClaseosector.Text = "Clase o sector"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 258)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'lblTARADEPA
        '
        Me.lblTARADEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTARADEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTARADEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTARADEPA.ForeColor = System.Drawing.Color.Black
        Me.lblTARADEPA.Location = New System.Drawing.Point(450, 28)
        Me.lblTARADEPA.Name = "lblTARADEPA"
        Me.lblTARADEPA.Size = New System.Drawing.Size(108, 20)
        Me.lblTARADEPA.TabIndex = 52
        '
        'cboTARADEPA
        '
        Me.cboTARADEPA.AccessibleDescription = "Departamento"
        Me.cboTARADEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTARADEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTARADEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTARADEPA.FormattingEnabled = True
        Me.cboTARADEPA.Location = New System.Drawing.Point(137, 26)
        Me.cboTARADEPA.Name = "cboTARADEPA"
        Me.cboTARADEPA.Size = New System.Drawing.Size(307, 22)
        Me.cboTARADEPA.TabIndex = 1
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
        Me.Label4.Text = "Departamento"
        '
        'lblTARAMUNI
        '
        Me.lblTARAMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTARAMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTARAMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTARAMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblTARAMUNI.Location = New System.Drawing.Point(450, 51)
        Me.lblTARAMUNI.Name = "lblTARAMUNI"
        Me.lblTARAMUNI.Size = New System.Drawing.Size(108, 20)
        Me.lblTARAMUNI.TabIndex = 50
        '
        'cboTARAMUNI
        '
        Me.cboTARAMUNI.AccessibleDescription = "Municipio"
        Me.cboTARAMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTARAMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTARAMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTARAMUNI.FormattingEnabled = True
        Me.cboTARAMUNI.Location = New System.Drawing.Point(137, 49)
        Me.cboTARAMUNI.Name = "cboTARAMUNI"
        Me.cboTARAMUNI.Size = New System.Drawing.Size(307, 22)
        Me.cboTARAMUNI.TabIndex = 2
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
        Me.lblMUNICIPIO.Text = "Municipio"
        '
        'cboTARAESTA
        '
        Me.cboTARAESTA.AccessibleDescription = "Estado"
        Me.cboTARAESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTARAESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTARAESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTARAESTA.FormattingEnabled = True
        Me.cboTARAESTA.Location = New System.Drawing.Point(137, 259)
        Me.cboTARAESTA.Name = "cboTARAESTA"
        Me.cboTARAESTA.Size = New System.Drawing.Size(307, 22)
        Me.cboTARAESTA.TabIndex = 11
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(19, 97)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(112, 20)
        Me.lblCodigo.TabIndex = 37
        Me.lblCodigo.Text = "Vigencia"
        '
        'frm_insertar_TARIRAAV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(603, 417)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraTARIRAAV)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(619, 453)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(619, 453)
        Me.Name = "frm_insertar_TARIRAAV"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraTARIRAAV.ResumeLayout(False)
        Me.fraTARIRAAV.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraTARIRAAV As System.Windows.Forms.GroupBox
    Friend WithEvents lblTARAESTR As System.Windows.Forms.Label
    Friend WithEvents cboTARAESTR As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTARAAVFI As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTARAAVIN As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTARATARI As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblTARADEEC As System.Windows.Forms.Label
    Friend WithEvents cboTARADEEC As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblTARAVIGE As System.Windows.Forms.Label
    Friend WithEvents cboTARAVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents lblTARACLSE As System.Windows.Forms.Label
    Friend WithEvents cboTARACLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTARADEPA As System.Windows.Forms.Label
    Friend WithEvents cboTARADEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTARAMUNI As System.Windows.Forms.Label
    Friend WithEvents cboTARAMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cboTARAESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblTARATIPO As System.Windows.Forms.Label
    Friend WithEvents cboTARATIPO As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
