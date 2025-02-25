<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_TARIACBO
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
        Me.fraTARIACBO = New System.Windows.Forms.GroupBox
        Me.txtTAABAVFI = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTAABAVIN = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.lblTAABESTR = New System.Windows.Forms.Label
        Me.cboTAABESTR = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtTAABTAIN = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtTAABTACO = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtTAABTARE = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblTAABTIPO = New System.Windows.Forms.Label
        Me.cboTAABTIPO = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtTAABTA05 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtTAABTA04 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtTAABTA03 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTAABTA02 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblTAABVIGE = New System.Windows.Forms.Label
        Me.cboTAABVIGE = New System.Windows.Forms.ComboBox
        Me.txtTAABTA01 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblTAABCLSE = New System.Windows.Forms.Label
        Me.cboTAABCLSE = New System.Windows.Forms.ComboBox
        Me.lblClaseosector = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblTAABDEPA = New System.Windows.Forms.Label
        Me.cboTAABDEPA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblTAABMUNI = New System.Windows.Forms.Label
        Me.cboTAABMUNI = New System.Windows.Forms.ComboBox
        Me.lblMUNICIPIO = New System.Windows.Forms.Label
        Me.cboTAABESTA = New System.Windows.Forms.ComboBox
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraTARIACBO.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 451)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 52)
        Me.GroupBox1.TabIndex = 44
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 522)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(601, 25)
        Me.strBARRESTA.TabIndex = 45
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
        'fraTARIACBO
        '
        Me.fraTARIACBO.BackColor = System.Drawing.SystemColors.Control
        Me.fraTARIACBO.Controls.Add(Me.txtTAABAVFI)
        Me.fraTARIACBO.Controls.Add(Me.Label9)
        Me.fraTARIACBO.Controls.Add(Me.txtTAABAVIN)
        Me.fraTARIACBO.Controls.Add(Me.Label17)
        Me.fraTARIACBO.Controls.Add(Me.lblTAABESTR)
        Me.fraTARIACBO.Controls.Add(Me.cboTAABESTR)
        Me.fraTARIACBO.Controls.Add(Me.Label16)
        Me.fraTARIACBO.Controls.Add(Me.txtTAABTAIN)
        Me.fraTARIACBO.Controls.Add(Me.Label12)
        Me.fraTARIACBO.Controls.Add(Me.txtTAABTACO)
        Me.fraTARIACBO.Controls.Add(Me.Label13)
        Me.fraTARIACBO.Controls.Add(Me.txtTAABTARE)
        Me.fraTARIACBO.Controls.Add(Me.Label14)
        Me.fraTARIACBO.Controls.Add(Me.lblTAABTIPO)
        Me.fraTARIACBO.Controls.Add(Me.cboTAABTIPO)
        Me.fraTARIACBO.Controls.Add(Me.Label11)
        Me.fraTARIACBO.Controls.Add(Me.txtTAABTA05)
        Me.fraTARIACBO.Controls.Add(Me.Label8)
        Me.fraTARIACBO.Controls.Add(Me.txtTAABTA04)
        Me.fraTARIACBO.Controls.Add(Me.Label7)
        Me.fraTARIACBO.Controls.Add(Me.txtTAABTA03)
        Me.fraTARIACBO.Controls.Add(Me.Label6)
        Me.fraTARIACBO.Controls.Add(Me.txtTAABTA02)
        Me.fraTARIACBO.Controls.Add(Me.Label1)
        Me.fraTARIACBO.Controls.Add(Me.lblTAABVIGE)
        Me.fraTARIACBO.Controls.Add(Me.cboTAABVIGE)
        Me.fraTARIACBO.Controls.Add(Me.txtTAABTA01)
        Me.fraTARIACBO.Controls.Add(Me.Label2)
        Me.fraTARIACBO.Controls.Add(Me.lblTAABCLSE)
        Me.fraTARIACBO.Controls.Add(Me.cboTAABCLSE)
        Me.fraTARIACBO.Controls.Add(Me.lblClaseosector)
        Me.fraTARIACBO.Controls.Add(Me.Label3)
        Me.fraTARIACBO.Controls.Add(Me.lblTAABDEPA)
        Me.fraTARIACBO.Controls.Add(Me.cboTAABDEPA)
        Me.fraTARIACBO.Controls.Add(Me.Label4)
        Me.fraTARIACBO.Controls.Add(Me.lblTAABMUNI)
        Me.fraTARIACBO.Controls.Add(Me.cboTAABMUNI)
        Me.fraTARIACBO.Controls.Add(Me.lblMUNICIPIO)
        Me.fraTARIACBO.Controls.Add(Me.cboTAABESTA)
        Me.fraTARIACBO.Controls.Add(Me.lblCodigo)
        Me.fraTARIACBO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraTARIACBO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraTARIACBO.Location = New System.Drawing.Point(12, 6)
        Me.fraTARIACBO.Name = "fraTARIACBO"
        Me.fraTARIACBO.Size = New System.Drawing.Size(577, 436)
        Me.fraTARIACBO.TabIndex = 43
        Me.fraTARIACBO.TabStop = False
        Me.fraTARIACBO.Text = "INSERTAR TARIFA ACTIVIDAD BOMBERIL"
        '
        'txtTAABAVFI
        '
        Me.txtTAABAVFI.AccessibleDescription = "Avalúo final"
        Me.txtTAABAVFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABAVFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABAVFI.Location = New System.Drawing.Point(137, 373)
        Me.txtTAABAVFI.MaxLength = 12
        Me.txtTAABAVFI.Name = "txtTAABAVFI"
        Me.txtTAABAVFI.Size = New System.Drawing.Size(112, 20)
        Me.txtTAABAVFI.TabIndex = 16
        Me.txtTAABAVFI.Text = "0"
        Me.txtTAABAVFI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txtTAABAVIN
        '
        Me.txtTAABAVIN.AccessibleDescription = "Avaluo inicial"
        Me.txtTAABAVIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABAVIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABAVIN.Location = New System.Drawing.Point(137, 350)
        Me.txtTAABAVIN.MaxLength = 12
        Me.txtTAABAVIN.Name = "txtTAABAVIN"
        Me.txtTAABAVIN.Size = New System.Drawing.Size(112, 20)
        Me.txtTAABAVIN.TabIndex = 15
        Me.txtTAABAVIN.Text = "0"
        Me.txtTAABAVIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'lblTAABESTR
        '
        Me.lblTAABESTR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAABESTR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAABESTR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAABESTR.ForeColor = System.Drawing.Color.Black
        Me.lblTAABESTR.Location = New System.Drawing.Point(447, 212)
        Me.lblTAABESTR.Name = "lblTAABESTR"
        Me.lblTAABESTR.Size = New System.Drawing.Size(111, 20)
        Me.lblTAABESTR.TabIndex = 87
        '
        'cboTAABESTR
        '
        Me.cboTAABESTR.AccessibleDescription = "Estrato"
        Me.cboTAABESTR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAABESTR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAABESTR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAABESTR.FormattingEnabled = True
        Me.cboTAABESTR.Location = New System.Drawing.Point(137, 210)
        Me.cboTAABESTR.Name = "cboTAABESTR"
        Me.cboTAABESTR.Size = New System.Drawing.Size(304, 22)
        Me.cboTAABESTR.TabIndex = 9
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
        'txtTAABTAIN
        '
        Me.txtTAABTAIN.AccessibleDescription = "Tarifa industrial"
        Me.txtTAABTAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABTAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABTAIN.Location = New System.Drawing.Point(137, 189)
        Me.txtTAABTAIN.MaxLength = 9
        Me.txtTAABTAIN.Name = "txtTAABTAIN"
        Me.txtTAABTAIN.Size = New System.Drawing.Size(112, 20)
        Me.txtTAABTAIN.TabIndex = 8
        Me.txtTAABTAIN.Text = "0"
        Me.txtTAABTAIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txtTAABTACO
        '
        Me.txtTAABTACO.AccessibleDescription = "Tarifa comercial"
        Me.txtTAABTACO.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABTACO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABTACO.Location = New System.Drawing.Point(137, 166)
        Me.txtTAABTACO.MaxLength = 9
        Me.txtTAABTACO.Name = "txtTAABTACO"
        Me.txtTAABTACO.Size = New System.Drawing.Size(112, 20)
        Me.txtTAABTACO.TabIndex = 7
        Me.txtTAABTACO.Text = "0"
        Me.txtTAABTACO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txtTAABTARE
        '
        Me.txtTAABTARE.AccessibleDescription = "Tarifa residencial"
        Me.txtTAABTARE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABTARE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABTARE.Location = New System.Drawing.Point(137, 143)
        Me.txtTAABTARE.MaxLength = 9
        Me.txtTAABTARE.Name = "txtTAABTARE"
        Me.txtTAABTARE.Size = New System.Drawing.Size(112, 20)
        Me.txtTAABTARE.TabIndex = 6
        Me.txtTAABTARE.Text = "0"
        Me.txtTAABTARE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'lblTAABTIPO
        '
        Me.lblTAABTIPO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAABTIPO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAABTIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAABTIPO.ForeColor = System.Drawing.Color.Black
        Me.lblTAABTIPO.Location = New System.Drawing.Point(447, 120)
        Me.lblTAABTIPO.Name = "lblTAABTIPO"
        Me.lblTAABTIPO.Size = New System.Drawing.Size(111, 20)
        Me.lblTAABTIPO.TabIndex = 78
        '
        'cboTAABTIPO
        '
        Me.cboTAABTIPO.AccessibleDescription = "Tipo de calificación"
        Me.cboTAABTIPO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAABTIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAABTIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAABTIPO.FormattingEnabled = True
        Me.cboTAABTIPO.Location = New System.Drawing.Point(137, 118)
        Me.cboTAABTIPO.Name = "cboTAABTIPO"
        Me.cboTAABTIPO.Size = New System.Drawing.Size(304, 22)
        Me.cboTAABTIPO.TabIndex = 5
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
        'txtTAABTA05
        '
        Me.txtTAABTA05.AccessibleDescription = "Tarifa 05"
        Me.txtTAABTA05.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABTA05.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABTA05.Location = New System.Drawing.Point(137, 327)
        Me.txtTAABTA05.MaxLength = 3
        Me.txtTAABTA05.Name = "txtTAABTA05"
        Me.txtTAABTA05.Size = New System.Drawing.Size(112, 20)
        Me.txtTAABTA05.TabIndex = 14
        Me.txtTAABTA05.Text = "0"
        Me.txtTAABTA05.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txtTAABTA04
        '
        Me.txtTAABTA04.AccessibleDescription = "Tarifa 04"
        Me.txtTAABTA04.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABTA04.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABTA04.Location = New System.Drawing.Point(137, 304)
        Me.txtTAABTA04.MaxLength = 3
        Me.txtTAABTA04.Name = "txtTAABTA04"
        Me.txtTAABTA04.Size = New System.Drawing.Size(112, 20)
        Me.txtTAABTA04.TabIndex = 13
        Me.txtTAABTA04.Text = "0"
        Me.txtTAABTA04.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txtTAABTA03
        '
        Me.txtTAABTA03.AccessibleDescription = "Tarifa 03"
        Me.txtTAABTA03.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABTA03.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABTA03.Location = New System.Drawing.Point(137, 281)
        Me.txtTAABTA03.MaxLength = 3
        Me.txtTAABTA03.Name = "txtTAABTA03"
        Me.txtTAABTA03.Size = New System.Drawing.Size(112, 20)
        Me.txtTAABTA03.TabIndex = 12
        Me.txtTAABTA03.Text = "0"
        Me.txtTAABTA03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txtTAABTA02
        '
        Me.txtTAABTA02.AccessibleDescription = "Tarifa 02"
        Me.txtTAABTA02.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABTA02.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABTA02.Location = New System.Drawing.Point(137, 258)
        Me.txtTAABTA02.MaxLength = 3
        Me.txtTAABTA02.Name = "txtTAABTA02"
        Me.txtTAABTA02.Size = New System.Drawing.Size(112, 20)
        Me.txtTAABTA02.TabIndex = 11
        Me.txtTAABTA02.Text = "0"
        Me.txtTAABTA02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'lblTAABVIGE
        '
        Me.lblTAABVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAABVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAABVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAABVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblTAABVIGE.Location = New System.Drawing.Point(447, 97)
        Me.lblTAABVIGE.Name = "lblTAABVIGE"
        Me.lblTAABVIGE.Size = New System.Drawing.Size(111, 20)
        Me.lblTAABVIGE.TabIndex = 62
        '
        'cboTAABVIGE
        '
        Me.cboTAABVIGE.AccessibleDescription = "Vigencia"
        Me.cboTAABVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAABVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAABVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAABVIGE.FormattingEnabled = True
        Me.cboTAABVIGE.Location = New System.Drawing.Point(137, 95)
        Me.cboTAABVIGE.Name = "cboTAABVIGE"
        Me.cboTAABVIGE.Size = New System.Drawing.Size(304, 22)
        Me.cboTAABVIGE.TabIndex = 4
        '
        'txtTAABTA01
        '
        Me.txtTAABTA01.AccessibleDescription = "Tarifa 01"
        Me.txtTAABTA01.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABTA01.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABTA01.Location = New System.Drawing.Point(137, 235)
        Me.txtTAABTA01.MaxLength = 3
        Me.txtTAABTA01.Name = "txtTAABTA01"
        Me.txtTAABTA01.Size = New System.Drawing.Size(112, 20)
        Me.txtTAABTA01.TabIndex = 10
        Me.txtTAABTA01.Text = "0"
        Me.txtTAABTA01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'lblTAABCLSE
        '
        Me.lblTAABCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAABCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAABCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAABCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblTAABCLSE.Location = New System.Drawing.Point(447, 74)
        Me.lblTAABCLSE.Name = "lblTAABCLSE"
        Me.lblTAABCLSE.Size = New System.Drawing.Size(111, 20)
        Me.lblTAABCLSE.TabIndex = 57
        '
        'cboTAABCLSE
        '
        Me.cboTAABCLSE.AccessibleDescription = "Clase o sector"
        Me.cboTAABCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAABCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAABCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAABCLSE.FormattingEnabled = True
        Me.cboTAABCLSE.Location = New System.Drawing.Point(137, 72)
        Me.cboTAABCLSE.Name = "cboTAABCLSE"
        Me.cboTAABCLSE.Size = New System.Drawing.Size(304, 22)
        Me.cboTAABCLSE.TabIndex = 3
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
        'lblTAABDEPA
        '
        Me.lblTAABDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAABDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAABDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAABDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblTAABDEPA.Location = New System.Drawing.Point(447, 28)
        Me.lblTAABDEPA.Name = "lblTAABDEPA"
        Me.lblTAABDEPA.Size = New System.Drawing.Size(111, 20)
        Me.lblTAABDEPA.TabIndex = 52
        '
        'cboTAABDEPA
        '
        Me.cboTAABDEPA.AccessibleDescription = "Departamento"
        Me.cboTAABDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAABDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAABDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAABDEPA.FormattingEnabled = True
        Me.cboTAABDEPA.Location = New System.Drawing.Point(137, 26)
        Me.cboTAABDEPA.Name = "cboTAABDEPA"
        Me.cboTAABDEPA.Size = New System.Drawing.Size(304, 22)
        Me.cboTAABDEPA.TabIndex = 1
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
        'lblTAABMUNI
        '
        Me.lblTAABMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAABMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAABMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAABMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblTAABMUNI.Location = New System.Drawing.Point(447, 51)
        Me.lblTAABMUNI.Name = "lblTAABMUNI"
        Me.lblTAABMUNI.Size = New System.Drawing.Size(111, 20)
        Me.lblTAABMUNI.TabIndex = 50
        '
        'cboTAABMUNI
        '
        Me.cboTAABMUNI.AccessibleDescription = "Municipio"
        Me.cboTAABMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAABMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAABMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAABMUNI.FormattingEnabled = True
        Me.cboTAABMUNI.Location = New System.Drawing.Point(137, 49)
        Me.cboTAABMUNI.Name = "cboTAABMUNI"
        Me.cboTAABMUNI.Size = New System.Drawing.Size(304, 22)
        Me.cboTAABMUNI.TabIndex = 2
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
        'cboTAABESTA
        '
        Me.cboTAABESTA.AccessibleDescription = "Estado"
        Me.cboTAABESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAABESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAABESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAABESTA.FormattingEnabled = True
        Me.cboTAABESTA.Location = New System.Drawing.Point(137, 397)
        Me.cboTAABESTA.Name = "cboTAABESTA"
        Me.cboTAABESTA.Size = New System.Drawing.Size(304, 22)
        Me.cboTAABESTA.TabIndex = 17
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
        'frm_insertar_TARIACBO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 547)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraTARIACBO)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(617, 583)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(617, 583)
        Me.Name = "frm_insertar_TARIACBO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraTARIACBO.ResumeLayout(False)
        Me.fraTARIACBO.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraTARIACBO As System.Windows.Forms.GroupBox
    Friend WithEvents txtTAABAVFI As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTAABAVIN As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblTAABESTR As System.Windows.Forms.Label
    Friend WithEvents cboTAABESTR As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTAABTAIN As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTAABTACO As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTAABTARE As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblTAABTIPO As System.Windows.Forms.Label
    Friend WithEvents cboTAABTIPO As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTAABTA05 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTAABTA04 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTAABTA03 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTAABTA02 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTAABVIGE As System.Windows.Forms.Label
    Friend WithEvents cboTAABVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents txtTAABTA01 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTAABCLSE As System.Windows.Forms.Label
    Friend WithEvents cboTAABCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTAABDEPA As System.Windows.Forms.Label
    Friend WithEvents cboTAABDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTAABMUNI As System.Windows.Forms.Label
    Friend WithEvents cboTAABMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cboTAABESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
End Class
