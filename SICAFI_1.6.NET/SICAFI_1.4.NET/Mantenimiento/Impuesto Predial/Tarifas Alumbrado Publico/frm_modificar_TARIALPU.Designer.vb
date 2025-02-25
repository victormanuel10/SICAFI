<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_TARIALPU
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
        Me.fraTARIALPU = New System.Windows.Forms.GroupBox
        Me.txtTAAPAVFI = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTAAPAVIN = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.lblTAAPESTR = New System.Windows.Forms.Label
        Me.cboTAAPESTR = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtTAAPTAIN = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtTAAPTACO = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtTAAPTARE = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblTAAPTIPO = New System.Windows.Forms.Label
        Me.cboTAAPTIPO = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtTAAPTA05 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtTAAPTA04 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtTAAPTA03 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTAAPTA02 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblTAAPVIGE = New System.Windows.Forms.Label
        Me.cboTAAPVIGE = New System.Windows.Forms.ComboBox
        Me.txtTAAPTA01 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblTAAPCLSE = New System.Windows.Forms.Label
        Me.cboTAAPCLSE = New System.Windows.Forms.ComboBox
        Me.lblClaseosector = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblTAAPDEPA = New System.Windows.Forms.Label
        Me.cboTAAPDEPA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblTAAPMUNI = New System.Windows.Forms.Label
        Me.cboTAAPMUNI = New System.Windows.Forms.ComboBox
        Me.lblMUNICIPIO = New System.Windows.Forms.Label
        Me.cboTAAPESTA = New System.Windows.Forms.ComboBox
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraTARIALPU.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 444)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 52)
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
        Me.cmdSALIR.TabIndex = 14
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
        Me.cmdGUARDAR.TabIndex = 13
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 510)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(601, 25)
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
        'fraTARIALPU
        '
        Me.fraTARIALPU.BackColor = System.Drawing.SystemColors.Control
        Me.fraTARIALPU.Controls.Add(Me.txtTAAPAVFI)
        Me.fraTARIALPU.Controls.Add(Me.Label9)
        Me.fraTARIALPU.Controls.Add(Me.txtTAAPAVIN)
        Me.fraTARIALPU.Controls.Add(Me.Label17)
        Me.fraTARIALPU.Controls.Add(Me.lblTAAPESTR)
        Me.fraTARIALPU.Controls.Add(Me.cboTAAPESTR)
        Me.fraTARIALPU.Controls.Add(Me.Label16)
        Me.fraTARIALPU.Controls.Add(Me.txtTAAPTAIN)
        Me.fraTARIALPU.Controls.Add(Me.Label12)
        Me.fraTARIALPU.Controls.Add(Me.txtTAAPTACO)
        Me.fraTARIALPU.Controls.Add(Me.Label13)
        Me.fraTARIALPU.Controls.Add(Me.txtTAAPTARE)
        Me.fraTARIALPU.Controls.Add(Me.Label14)
        Me.fraTARIALPU.Controls.Add(Me.lblTAAPTIPO)
        Me.fraTARIALPU.Controls.Add(Me.cboTAAPTIPO)
        Me.fraTARIALPU.Controls.Add(Me.Label11)
        Me.fraTARIALPU.Controls.Add(Me.txtTAAPTA05)
        Me.fraTARIALPU.Controls.Add(Me.Label8)
        Me.fraTARIALPU.Controls.Add(Me.txtTAAPTA04)
        Me.fraTARIALPU.Controls.Add(Me.Label7)
        Me.fraTARIALPU.Controls.Add(Me.txtTAAPTA03)
        Me.fraTARIALPU.Controls.Add(Me.Label6)
        Me.fraTARIALPU.Controls.Add(Me.txtTAAPTA02)
        Me.fraTARIALPU.Controls.Add(Me.Label1)
        Me.fraTARIALPU.Controls.Add(Me.lblTAAPVIGE)
        Me.fraTARIALPU.Controls.Add(Me.cboTAAPVIGE)
        Me.fraTARIALPU.Controls.Add(Me.txtTAAPTA01)
        Me.fraTARIALPU.Controls.Add(Me.Label2)
        Me.fraTARIALPU.Controls.Add(Me.lblTAAPCLSE)
        Me.fraTARIALPU.Controls.Add(Me.cboTAAPCLSE)
        Me.fraTARIALPU.Controls.Add(Me.lblClaseosector)
        Me.fraTARIALPU.Controls.Add(Me.Label3)
        Me.fraTARIALPU.Controls.Add(Me.lblTAAPDEPA)
        Me.fraTARIALPU.Controls.Add(Me.cboTAAPDEPA)
        Me.fraTARIALPU.Controls.Add(Me.Label4)
        Me.fraTARIALPU.Controls.Add(Me.lblTAAPMUNI)
        Me.fraTARIALPU.Controls.Add(Me.cboTAAPMUNI)
        Me.fraTARIALPU.Controls.Add(Me.lblMUNICIPIO)
        Me.fraTARIALPU.Controls.Add(Me.cboTAAPESTA)
        Me.fraTARIALPU.Controls.Add(Me.lblCodigo)
        Me.fraTARIALPU.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraTARIALPU.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraTARIALPU.Location = New System.Drawing.Point(12, 5)
        Me.fraTARIALPU.Name = "fraTARIALPU"
        Me.fraTARIALPU.Size = New System.Drawing.Size(572, 436)
        Me.fraTARIALPU.TabIndex = 41
        Me.fraTARIALPU.TabStop = False
        Me.fraTARIALPU.Text = "MODIFICAR TARIFA ALUMBRADO PUBLICO"
        '
        'txtTAAPAVFI
        '
        Me.txtTAAPAVFI.AccessibleDescription = "Avalúo final"
        Me.txtTAAPAVFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPAVFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPAVFI.Location = New System.Drawing.Point(137, 373)
        Me.txtTAAPAVFI.MaxLength = 12
        Me.txtTAAPAVFI.Name = "txtTAAPAVFI"
        Me.txtTAAPAVFI.Size = New System.Drawing.Size(112, 20)
        Me.txtTAAPAVFI.TabIndex = 16
        Me.txtTAAPAVFI.Text = "0"
        Me.txtTAAPAVFI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(19, 373)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 20)
        Me.Label9.TabIndex = 91
        Me.Label9.Text = "Avalúo final"
        '
        'txtTAAPAVIN
        '
        Me.txtTAAPAVIN.AccessibleDescription = "Avaluo inicial"
        Me.txtTAAPAVIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPAVIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPAVIN.Location = New System.Drawing.Point(137, 350)
        Me.txtTAAPAVIN.MaxLength = 12
        Me.txtTAAPAVIN.Name = "txtTAAPAVIN"
        Me.txtTAAPAVIN.Size = New System.Drawing.Size(112, 20)
        Me.txtTAAPAVIN.TabIndex = 15
        Me.txtTAAPAVIN.Text = "0"
        Me.txtTAAPAVIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(19, 350)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(112, 20)
        Me.Label17.TabIndex = 90
        Me.Label17.Text = "Avalúo inicial"
        '
        'lblTAAPESTR
        '
        Me.lblTAAPESTR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAAPESTR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAAPESTR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAAPESTR.ForeColor = System.Drawing.Color.Black
        Me.lblTAAPESTR.Location = New System.Drawing.Point(442, 212)
        Me.lblTAAPESTR.Name = "lblTAAPESTR"
        Me.lblTAAPESTR.Size = New System.Drawing.Size(116, 20)
        Me.lblTAAPESTR.TabIndex = 87
        '
        'cboTAAPESTR
        '
        Me.cboTAAPESTR.AccessibleDescription = "Estrato"
        Me.cboTAAPESTR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAAPESTR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAAPESTR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAAPESTR.FormattingEnabled = True
        Me.cboTAAPESTR.Location = New System.Drawing.Point(137, 210)
        Me.cboTAAPESTR.Name = "cboTAAPESTR"
        Me.cboTAAPESTR.Size = New System.Drawing.Size(299, 22)
        Me.cboTAAPESTR.TabIndex = 9
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(19, 212)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(112, 20)
        Me.Label16.TabIndex = 86
        Me.Label16.Text = "Estrato"
        '
        'txtTAAPTAIN
        '
        Me.txtTAAPTAIN.AccessibleDescription = "Tarifa industrial"
        Me.txtTAAPTAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPTAIN.Enabled = False
        Me.txtTAAPTAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPTAIN.Location = New System.Drawing.Point(137, 189)
        Me.txtTAAPTAIN.MaxLength = 9
        Me.txtTAAPTAIN.Name = "txtTAAPTAIN"
        Me.txtTAAPTAIN.Size = New System.Drawing.Size(112, 20)
        Me.txtTAAPTAIN.TabIndex = 8
        Me.txtTAAPTAIN.Text = "0"
        Me.txtTAAPTAIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(19, 189)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 20)
        Me.Label12.TabIndex = 84
        Me.Label12.Text = "$ Tarifa industrial"
        '
        'txtTAAPTACO
        '
        Me.txtTAAPTACO.AccessibleDescription = "Tarifa comercial"
        Me.txtTAAPTACO.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPTACO.Enabled = False
        Me.txtTAAPTACO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPTACO.Location = New System.Drawing.Point(137, 166)
        Me.txtTAAPTACO.MaxLength = 9
        Me.txtTAAPTACO.Name = "txtTAAPTACO"
        Me.txtTAAPTACO.Size = New System.Drawing.Size(112, 20)
        Me.txtTAAPTACO.TabIndex = 7
        Me.txtTAAPTACO.Text = "0"
        Me.txtTAAPTACO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(19, 166)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 20)
        Me.Label13.TabIndex = 83
        Me.Label13.Text = "$ Tarifa comercial"
        '
        'txtTAAPTARE
        '
        Me.txtTAAPTARE.AccessibleDescription = "Tarifa residencial"
        Me.txtTAAPTARE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPTARE.Enabled = False
        Me.txtTAAPTARE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPTARE.Location = New System.Drawing.Point(137, 143)
        Me.txtTAAPTARE.MaxLength = 9
        Me.txtTAAPTARE.Name = "txtTAAPTARE"
        Me.txtTAAPTARE.Size = New System.Drawing.Size(112, 20)
        Me.txtTAAPTARE.TabIndex = 6
        Me.txtTAAPTARE.Text = "0"
        Me.txtTAAPTARE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.Label14.Text = "$ Tarifa residencial"
        '
        'lblTAAPTIPO
        '
        Me.lblTAAPTIPO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAAPTIPO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAAPTIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAAPTIPO.ForeColor = System.Drawing.Color.Black
        Me.lblTAAPTIPO.Location = New System.Drawing.Point(442, 120)
        Me.lblTAAPTIPO.Name = "lblTAAPTIPO"
        Me.lblTAAPTIPO.Size = New System.Drawing.Size(116, 20)
        Me.lblTAAPTIPO.TabIndex = 78
        '
        'cboTAAPTIPO
        '
        Me.cboTAAPTIPO.AccessibleDescription = "Tipo de calificación"
        Me.cboTAAPTIPO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAAPTIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAAPTIPO.Enabled = False
        Me.cboTAAPTIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAAPTIPO.FormattingEnabled = True
        Me.cboTAAPTIPO.Location = New System.Drawing.Point(137, 118)
        Me.cboTAAPTIPO.Name = "cboTAAPTIPO"
        Me.cboTAAPTIPO.Size = New System.Drawing.Size(299, 22)
        Me.cboTAAPTIPO.TabIndex = 5
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
        Me.Label11.Text = "Tipo calificación"
        '
        'txtTAAPTA05
        '
        Me.txtTAAPTA05.AccessibleDescription = "Tarifa 05"
        Me.txtTAAPTA05.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPTA05.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPTA05.Location = New System.Drawing.Point(137, 327)
        Me.txtTAAPTA05.MaxLength = 3
        Me.txtTAAPTA05.Name = "txtTAAPTA05"
        Me.txtTAAPTA05.Size = New System.Drawing.Size(112, 20)
        Me.txtTAAPTA05.TabIndex = 14
        Me.txtTAAPTA05.Text = "0"
        Me.txtTAAPTA05.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(19, 327)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 20)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "5. 70 a 100 Puntos"
        '
        'txtTAAPTA04
        '
        Me.txtTAAPTA04.AccessibleDescription = "Tarifa 04"
        Me.txtTAAPTA04.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPTA04.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPTA04.Location = New System.Drawing.Point(137, 304)
        Me.txtTAAPTA04.MaxLength = 3
        Me.txtTAAPTA04.Name = "txtTAAPTA04"
        Me.txtTAAPTA04.Size = New System.Drawing.Size(112, 20)
        Me.txtTAAPTA04.TabIndex = 13
        Me.txtTAAPTA04.Text = "0"
        Me.txtTAAPTA04.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(19, 304)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 20)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "3. 47 a 69 Puntos"
        '
        'txtTAAPTA03
        '
        Me.txtTAAPTA03.AccessibleDescription = "Tarifa 03"
        Me.txtTAAPTA03.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPTA03.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPTA03.Location = New System.Drawing.Point(137, 281)
        Me.txtTAAPTA03.MaxLength = 3
        Me.txtTAAPTA03.Name = "txtTAAPTA03"
        Me.txtTAAPTA03.Size = New System.Drawing.Size(112, 20)
        Me.txtTAAPTA03.TabIndex = 12
        Me.txtTAAPTA03.Text = "0"
        Me.txtTAAPTA03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(19, 281)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "3. 29 a 46 Puntos"
        '
        'txtTAAPTA02
        '
        Me.txtTAAPTA02.AccessibleDescription = "Tarifa 02"
        Me.txtTAAPTA02.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPTA02.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPTA02.Location = New System.Drawing.Point(137, 258)
        Me.txtTAAPTA02.MaxLength = 3
        Me.txtTAAPTA02.Name = "txtTAAPTA02"
        Me.txtTAAPTA02.Size = New System.Drawing.Size(112, 20)
        Me.txtTAAPTA02.TabIndex = 11
        Me.txtTAAPTA02.Text = "0"
        Me.txtTAAPTA02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 258)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "2. 11 a 28 Puntos"
        '
        'lblTAAPVIGE
        '
        Me.lblTAAPVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAAPVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAAPVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAAPVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblTAAPVIGE.Location = New System.Drawing.Point(442, 97)
        Me.lblTAAPVIGE.Name = "lblTAAPVIGE"
        Me.lblTAAPVIGE.Size = New System.Drawing.Size(116, 20)
        Me.lblTAAPVIGE.TabIndex = 62
        '
        'cboTAAPVIGE
        '
        Me.cboTAAPVIGE.AccessibleDescription = "Vigencia"
        Me.cboTAAPVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAAPVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAAPVIGE.Enabled = False
        Me.cboTAAPVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAAPVIGE.FormattingEnabled = True
        Me.cboTAAPVIGE.Location = New System.Drawing.Point(137, 95)
        Me.cboTAAPVIGE.Name = "cboTAAPVIGE"
        Me.cboTAAPVIGE.Size = New System.Drawing.Size(299, 22)
        Me.cboTAAPVIGE.TabIndex = 4
        '
        'txtTAAPTA01
        '
        Me.txtTAAPTA01.AccessibleDescription = "Tarifa 01"
        Me.txtTAAPTA01.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPTA01.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPTA01.Location = New System.Drawing.Point(137, 235)
        Me.txtTAAPTA01.MaxLength = 3
        Me.txtTAAPTA01.Name = "txtTAAPTA01"
        Me.txtTAAPTA01.Size = New System.Drawing.Size(112, 20)
        Me.txtTAAPTA01.TabIndex = 10
        Me.txtTAAPTA01.Text = "0"
        Me.txtTAAPTA01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 235)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "1. 01 a 10 Puntos"
        '
        'lblTAAPCLSE
        '
        Me.lblTAAPCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAAPCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAAPCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAAPCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblTAAPCLSE.Location = New System.Drawing.Point(442, 74)
        Me.lblTAAPCLSE.Name = "lblTAAPCLSE"
        Me.lblTAAPCLSE.Size = New System.Drawing.Size(116, 20)
        Me.lblTAAPCLSE.TabIndex = 57
        '
        'cboTAAPCLSE
        '
        Me.cboTAAPCLSE.AccessibleDescription = "Clase o sector"
        Me.cboTAAPCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAAPCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAAPCLSE.Enabled = False
        Me.cboTAAPCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAAPCLSE.FormattingEnabled = True
        Me.cboTAAPCLSE.Location = New System.Drawing.Point(137, 72)
        Me.cboTAAPCLSE.Name = "cboTAAPCLSE"
        Me.cboTAAPCLSE.Size = New System.Drawing.Size(299, 22)
        Me.cboTAAPCLSE.TabIndex = 3
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
        Me.Label3.Location = New System.Drawing.Point(19, 396)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'lblTAAPDEPA
        '
        Me.lblTAAPDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAAPDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAAPDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAAPDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblTAAPDEPA.Location = New System.Drawing.Point(442, 28)
        Me.lblTAAPDEPA.Name = "lblTAAPDEPA"
        Me.lblTAAPDEPA.Size = New System.Drawing.Size(116, 20)
        Me.lblTAAPDEPA.TabIndex = 52
        '
        'cboTAAPDEPA
        '
        Me.cboTAAPDEPA.AccessibleDescription = "Departamento"
        Me.cboTAAPDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAAPDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAAPDEPA.Enabled = False
        Me.cboTAAPDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAAPDEPA.FormattingEnabled = True
        Me.cboTAAPDEPA.Location = New System.Drawing.Point(137, 26)
        Me.cboTAAPDEPA.Name = "cboTAAPDEPA"
        Me.cboTAAPDEPA.Size = New System.Drawing.Size(299, 22)
        Me.cboTAAPDEPA.TabIndex = 1
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
        'lblTAAPMUNI
        '
        Me.lblTAAPMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAAPMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAAPMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAAPMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblTAAPMUNI.Location = New System.Drawing.Point(442, 51)
        Me.lblTAAPMUNI.Name = "lblTAAPMUNI"
        Me.lblTAAPMUNI.Size = New System.Drawing.Size(116, 20)
        Me.lblTAAPMUNI.TabIndex = 50
        '
        'cboTAAPMUNI
        '
        Me.cboTAAPMUNI.AccessibleDescription = "Municipio"
        Me.cboTAAPMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAAPMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAAPMUNI.Enabled = False
        Me.cboTAAPMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAAPMUNI.FormattingEnabled = True
        Me.cboTAAPMUNI.Location = New System.Drawing.Point(137, 49)
        Me.cboTAAPMUNI.Name = "cboTAAPMUNI"
        Me.cboTAAPMUNI.Size = New System.Drawing.Size(299, 22)
        Me.cboTAAPMUNI.TabIndex = 2
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
        'cboTAAPESTA
        '
        Me.cboTAAPESTA.AccessibleDescription = "Estado"
        Me.cboTAAPESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAAPESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAAPESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAAPESTA.FormattingEnabled = True
        Me.cboTAAPESTA.Location = New System.Drawing.Point(137, 397)
        Me.cboTAAPESTA.Name = "cboTAAPESTA"
        Me.cboTAAPESTA.Size = New System.Drawing.Size(299, 22)
        Me.cboTAAPESTA.TabIndex = 17
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
        'frm_modificar_TARIALPU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 535)
        Me.Controls.Add(Me.fraTARIALPU)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(617, 571)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(617, 571)
        Me.Name = "frm_modificar_TARIALPU"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraTARIALPU.ResumeLayout(False)
        Me.fraTARIALPU.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraTARIALPU As System.Windows.Forms.GroupBox
    Friend WithEvents txtTAAPAVFI As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPAVIN As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblTAAPESTR As System.Windows.Forms.Label
    Friend WithEvents cboTAAPESTR As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPTAIN As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPTACO As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPTARE As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblTAAPTIPO As System.Windows.Forms.Label
    Friend WithEvents cboTAAPTIPO As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPTA05 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPTA04 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPTA03 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPTA02 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTAAPVIGE As System.Windows.Forms.Label
    Friend WithEvents cboTAAPVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents txtTAAPTA01 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTAAPCLSE As System.Windows.Forms.Label
    Friend WithEvents cboTAAPCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTAAPDEPA As System.Windows.Forms.Label
    Friend WithEvents cboTAAPDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTAAPMUNI As System.Windows.Forms.Label
    Friend WithEvents cboTAAPMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cboTAAPESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
End Class
