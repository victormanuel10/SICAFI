<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_TARIPRES
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
        Me.fraTARIPRES = New System.Windows.Forms.GroupBox
        Me.txtTAPEAVFI = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTAPEAVIN = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtTAPETARI = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblTAPEDEEC = New System.Windows.Forms.Label
        Me.cboTAPEDEEC = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblTAPEVIGE = New System.Windows.Forms.Label
        Me.cboTAPEVIGE = New System.Windows.Forms.ComboBox
        Me.lblTAPECLSE = New System.Windows.Forms.Label
        Me.cboTAPECLSE = New System.Windows.Forms.ComboBox
        Me.lblClaseosector = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblTAPEDEPA = New System.Windows.Forms.Label
        Me.cboTAPEDEPA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblTAPEMUNI = New System.Windows.Forms.Label
        Me.cboTAPEMUNI = New System.Windows.Forms.ComboBox
        Me.lblMUNICIPIO = New System.Windows.Forms.Label
        Me.cboTAPEESTA = New System.Windows.Forms.ComboBox
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraTARIPRES.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 262)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 52)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 331)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(601, 25)
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
        'fraTARIPRES
        '
        Me.fraTARIPRES.BackColor = System.Drawing.SystemColors.Control
        Me.fraTARIPRES.Controls.Add(Me.txtTAPEAVFI)
        Me.fraTARIPRES.Controls.Add(Me.Label9)
        Me.fraTARIPRES.Controls.Add(Me.txtTAPEAVIN)
        Me.fraTARIPRES.Controls.Add(Me.Label17)
        Me.fraTARIPRES.Controls.Add(Me.txtTAPETARI)
        Me.fraTARIPRES.Controls.Add(Me.Label14)
        Me.fraTARIPRES.Controls.Add(Me.lblTAPEDEEC)
        Me.fraTARIPRES.Controls.Add(Me.cboTAPEDEEC)
        Me.fraTARIPRES.Controls.Add(Me.Label11)
        Me.fraTARIPRES.Controls.Add(Me.lblTAPEVIGE)
        Me.fraTARIPRES.Controls.Add(Me.cboTAPEVIGE)
        Me.fraTARIPRES.Controls.Add(Me.lblTAPECLSE)
        Me.fraTARIPRES.Controls.Add(Me.cboTAPECLSE)
        Me.fraTARIPRES.Controls.Add(Me.lblClaseosector)
        Me.fraTARIPRES.Controls.Add(Me.Label3)
        Me.fraTARIPRES.Controls.Add(Me.lblTAPEDEPA)
        Me.fraTARIPRES.Controls.Add(Me.cboTAPEDEPA)
        Me.fraTARIPRES.Controls.Add(Me.Label4)
        Me.fraTARIPRES.Controls.Add(Me.lblTAPEMUNI)
        Me.fraTARIPRES.Controls.Add(Me.cboTAPEMUNI)
        Me.fraTARIPRES.Controls.Add(Me.lblMUNICIPIO)
        Me.fraTARIPRES.Controls.Add(Me.cboTAPEESTA)
        Me.fraTARIPRES.Controls.Add(Me.lblCodigo)
        Me.fraTARIPRES.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraTARIPRES.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraTARIPRES.Location = New System.Drawing.Point(12, 3)
        Me.fraTARIPRES.Name = "fraTARIPRES"
        Me.fraTARIPRES.Size = New System.Drawing.Size(572, 253)
        Me.fraTARIPRES.TabIndex = 46
        Me.fraTARIPRES.TabStop = False
        Me.fraTARIPRES.Text = "MODIFCAR TARIFA PREDIOS ESPECIALES"
        '
        'txtTAPEAVFI
        '
        Me.txtTAPEAVFI.AccessibleDescription = "Avalúo final"
        Me.txtTAPEAVFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAPEAVFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAPEAVFI.Location = New System.Drawing.Point(137, 189)
        Me.txtTAPEAVFI.MaxLength = 12
        Me.txtTAPEAVFI.Name = "txtTAPEAVFI"
        Me.txtTAPEAVFI.Size = New System.Drawing.Size(112, 20)
        Me.txtTAPEAVFI.TabIndex = 16
        Me.txtTAPEAVFI.Text = "0"
        Me.txtTAPEAVFI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(19, 189)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 20)
        Me.Label9.TabIndex = 91
        Me.Label9.Text = "Avalúo final"
        '
        'txtTAPEAVIN
        '
        Me.txtTAPEAVIN.AccessibleDescription = "Avaluo inicial"
        Me.txtTAPEAVIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAPEAVIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAPEAVIN.Location = New System.Drawing.Point(137, 166)
        Me.txtTAPEAVIN.MaxLength = 12
        Me.txtTAPEAVIN.Name = "txtTAPEAVIN"
        Me.txtTAPEAVIN.Size = New System.Drawing.Size(112, 20)
        Me.txtTAPEAVIN.TabIndex = 15
        Me.txtTAPEAVIN.Text = "0"
        Me.txtTAPEAVIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(19, 166)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(112, 20)
        Me.Label17.TabIndex = 90
        Me.Label17.Text = "Avalúo inicial"
        '
        'txtTAPETARI
        '
        Me.txtTAPETARI.AccessibleDescription = "Tarifa "
        Me.txtTAPETARI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAPETARI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAPETARI.Location = New System.Drawing.Point(137, 143)
        Me.txtTAPETARI.MaxLength = 9
        Me.txtTAPETARI.Name = "txtTAPETARI"
        Me.txtTAPETARI.Size = New System.Drawing.Size(112, 20)
        Me.txtTAPETARI.TabIndex = 6
        Me.txtTAPETARI.Text = "0"
        Me.txtTAPETARI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(19, 143)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(112, 20)
        Me.Label14.TabIndex = 82
        Me.Label14.Text = "$ Tarifa "
        '
        'lblTAPEDEEC
        '
        Me.lblTAPEDEEC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAPEDEEC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAPEDEEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAPEDEEC.ForeColor = System.Drawing.Color.Black
        Me.lblTAPEDEEC.Location = New System.Drawing.Point(449, 120)
        Me.lblTAPEDEEC.Name = "lblTAPEDEEC"
        Me.lblTAPEDEEC.Size = New System.Drawing.Size(109, 20)
        Me.lblTAPEDEEC.TabIndex = 78
        '
        'cboTAPEDEEC
        '
        Me.cboTAPEDEEC.AccessibleDescription = "Destinación"
        Me.cboTAPEDEEC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAPEDEEC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAPEDEEC.Enabled = False
        Me.cboTAPEDEEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAPEDEEC.FormattingEnabled = True
        Me.cboTAPEDEEC.Location = New System.Drawing.Point(137, 118)
        Me.cboTAPEDEEC.Name = "cboTAPEDEEC"
        Me.cboTAPEDEEC.Size = New System.Drawing.Size(306, 22)
        Me.cboTAPEDEEC.TabIndex = 5
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
        'lblTAPEVIGE
        '
        Me.lblTAPEVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAPEVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAPEVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAPEVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblTAPEVIGE.Location = New System.Drawing.Point(449, 97)
        Me.lblTAPEVIGE.Name = "lblTAPEVIGE"
        Me.lblTAPEVIGE.Size = New System.Drawing.Size(109, 20)
        Me.lblTAPEVIGE.TabIndex = 62
        '
        'cboTAPEVIGE
        '
        Me.cboTAPEVIGE.AccessibleDescription = "Vigencia"
        Me.cboTAPEVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAPEVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAPEVIGE.Enabled = False
        Me.cboTAPEVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAPEVIGE.FormattingEnabled = True
        Me.cboTAPEVIGE.Location = New System.Drawing.Point(137, 95)
        Me.cboTAPEVIGE.Name = "cboTAPEVIGE"
        Me.cboTAPEVIGE.Size = New System.Drawing.Size(306, 22)
        Me.cboTAPEVIGE.TabIndex = 4
        '
        'lblTAPECLSE
        '
        Me.lblTAPECLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAPECLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAPECLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAPECLSE.ForeColor = System.Drawing.Color.Black
        Me.lblTAPECLSE.Location = New System.Drawing.Point(449, 74)
        Me.lblTAPECLSE.Name = "lblTAPECLSE"
        Me.lblTAPECLSE.Size = New System.Drawing.Size(109, 20)
        Me.lblTAPECLSE.TabIndex = 57
        '
        'cboTAPECLSE
        '
        Me.cboTAPECLSE.AccessibleDescription = "Clase o sector"
        Me.cboTAPECLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAPECLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAPECLSE.Enabled = False
        Me.cboTAPECLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAPECLSE.FormattingEnabled = True
        Me.cboTAPECLSE.Location = New System.Drawing.Point(137, 72)
        Me.cboTAPECLSE.Name = "cboTAPECLSE"
        Me.cboTAPECLSE.Size = New System.Drawing.Size(306, 22)
        Me.cboTAPECLSE.TabIndex = 3
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
        Me.Label3.Location = New System.Drawing.Point(19, 212)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'lblTAPEDEPA
        '
        Me.lblTAPEDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAPEDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAPEDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAPEDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblTAPEDEPA.Location = New System.Drawing.Point(449, 28)
        Me.lblTAPEDEPA.Name = "lblTAPEDEPA"
        Me.lblTAPEDEPA.Size = New System.Drawing.Size(109, 20)
        Me.lblTAPEDEPA.TabIndex = 52
        '
        'cboTAPEDEPA
        '
        Me.cboTAPEDEPA.AccessibleDescription = "Departamento"
        Me.cboTAPEDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAPEDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAPEDEPA.Enabled = False
        Me.cboTAPEDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAPEDEPA.FormattingEnabled = True
        Me.cboTAPEDEPA.Location = New System.Drawing.Point(137, 26)
        Me.cboTAPEDEPA.Name = "cboTAPEDEPA"
        Me.cboTAPEDEPA.Size = New System.Drawing.Size(306, 22)
        Me.cboTAPEDEPA.TabIndex = 1
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
        'lblTAPEMUNI
        '
        Me.lblTAPEMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAPEMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAPEMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAPEMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblTAPEMUNI.Location = New System.Drawing.Point(449, 51)
        Me.lblTAPEMUNI.Name = "lblTAPEMUNI"
        Me.lblTAPEMUNI.Size = New System.Drawing.Size(109, 20)
        Me.lblTAPEMUNI.TabIndex = 50
        '
        'cboTAPEMUNI
        '
        Me.cboTAPEMUNI.AccessibleDescription = "Municipio"
        Me.cboTAPEMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAPEMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAPEMUNI.Enabled = False
        Me.cboTAPEMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAPEMUNI.FormattingEnabled = True
        Me.cboTAPEMUNI.Location = New System.Drawing.Point(137, 49)
        Me.cboTAPEMUNI.Name = "cboTAPEMUNI"
        Me.cboTAPEMUNI.Size = New System.Drawing.Size(306, 22)
        Me.cboTAPEMUNI.TabIndex = 2
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
        'cboTAPEESTA
        '
        Me.cboTAPEESTA.AccessibleDescription = "Estado"
        Me.cboTAPEESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAPEESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAPEESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAPEESTA.FormattingEnabled = True
        Me.cboTAPEESTA.Location = New System.Drawing.Point(137, 213)
        Me.cboTAPEESTA.Name = "cboTAPEESTA"
        Me.cboTAPEESTA.Size = New System.Drawing.Size(306, 22)
        Me.cboTAPEESTA.TabIndex = 17
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
        'frm_modificar_TARIPRES
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 356)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraTARIPRES)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(617, 392)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(617, 392)
        Me.Name = "frm_modificar_TARIPRES"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraTARIPRES.ResumeLayout(False)
        Me.fraTARIPRES.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraTARIPRES As System.Windows.Forms.GroupBox
    Friend WithEvents txtTAPEAVFI As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTAPEAVIN As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTAPETARI As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblTAPEDEEC As System.Windows.Forms.Label
    Friend WithEvents cboTAPEDEEC As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblTAPEVIGE As System.Windows.Forms.Label
    Friend WithEvents cboTAPEVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents lblTAPECLSE As System.Windows.Forms.Label
    Friend WithEvents cboTAPECLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTAPEDEPA As System.Windows.Forms.Label
    Friend WithEvents cboTAPEDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTAPEMUNI As System.Windows.Forms.Label
    Friend WithEvents cboTAPEMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cboTAPEESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
End Class
