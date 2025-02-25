<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_TIPOCONS
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
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.fraTIPODOCUMENTO = New System.Windows.Forms.GroupBox
        Me.txtTICOPOIN = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblTICOCLSE = New System.Windows.Forms.Label
        Me.cboTICOCLSE = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.chkTICOARCO = New System.Windows.Forms.CheckBox
        Me.cboTICOMOLI = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtTICOFAC2 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTICOFAC1 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtTICOPUMA = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtTICOPUNT = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblTICOTIPO = New System.Windows.Forms.Label
        Me.cboTICOTIPO = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblTICOCLCO = New System.Windows.Forms.Label
        Me.cboTICOCLCO = New System.Windows.Forms.ComboBox
        Me.lblClaseosector = New System.Windows.Forms.Label
        Me.lblTICODEPA = New System.Windows.Forms.Label
        Me.cboTICODEPA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblTICOMUNI = New System.Windows.Forms.Label
        Me.cboTICOMUNI = New System.Windows.Forms.ComboBox
        Me.lblMUNICIPIO = New System.Windows.Forms.Label
        Me.cboTICOESTA = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtTICODESC = New System.Windows.Forms.TextBox
        Me.txtTICOCODI = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblCódigo = New System.Windows.Forms.Label
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.cmdGUARDAR = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.strBARRESTA.SuspendLayout()
        Me.fraTIPODOCUMENTO.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 446)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(605, 25)
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
        'fraTIPODOCUMENTO
        '
        Me.fraTIPODOCUMENTO.BackColor = System.Drawing.SystemColors.Control
        Me.fraTIPODOCUMENTO.Controls.Add(Me.txtTICOPOIN)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.Label3)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.lblTICOCLSE)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.cboTICOCLSE)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.Label10)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.chkTICOARCO)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.cboTICOMOLI)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.Label11)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.txtTICOFAC2)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.Label9)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.txtTICOFAC1)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.Label8)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.txtTICOPUMA)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.Label7)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.txtTICOPUNT)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.Label6)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.lblTICOTIPO)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.cboTICOTIPO)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.Label5)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.lblTICOCLCO)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.cboTICOCLCO)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.lblClaseosector)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.lblTICODEPA)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.cboTICODEPA)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.Label4)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.lblTICOMUNI)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.cboTICOMUNI)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.lblMUNICIPIO)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.cboTICOESTA)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.Label2)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.txtTICODESC)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.txtTICOCODI)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.Label1)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.lblCódigo)
        Me.fraTIPODOCUMENTO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraTIPODOCUMENTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraTIPODOCUMENTO.Location = New System.Drawing.Point(12, 12)
        Me.fraTIPODOCUMENTO.Name = "fraTIPODOCUMENTO"
        Me.fraTIPODOCUMENTO.Size = New System.Drawing.Size(580, 364)
        Me.fraTIPODOCUMENTO.TabIndex = 29
        Me.fraTIPODOCUMENTO.TabStop = False
        Me.fraTIPODOCUMENTO.Text = "MODIFICAR IDENTIFICADOR DE CONSTRUCCIÓN"
        '
        'txtTICOPOIN
        '
        Me.txtTICOPOIN.AccessibleDescription = "% de Incremento"
        Me.txtTICOPOIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtTICOPOIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTICOPOIN.Location = New System.Drawing.Point(137, 326)
        Me.txtTICOPOIN.MaxLength = 4
        Me.txtTICOPOIN.Name = "txtTICOPOIN"
        Me.txtTICOPOIN.Size = New System.Drawing.Size(112, 20)
        Me.txtTICOPOIN.TabIndex = 14
        Me.txtTICOPOIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 326)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "% de Incremento"
        '
        'lblTICOCLSE
        '
        Me.lblTICOCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTICOCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTICOCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTICOCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblTICOCLSE.Location = New System.Drawing.Point(256, 119)
        Me.lblTICOCLSE.Name = "lblTICOCLSE"
        Me.lblTICOCLSE.Size = New System.Drawing.Size(302, 20)
        Me.lblTICOCLSE.TabIndex = 82
        '
        'cboTICOCLSE
        '
        Me.cboTICOCLSE.AccessibleDescription = "Clase o sector"
        Me.cboTICOCLSE.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboTICOCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTICOCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTICOCLSE.Enabled = False
        Me.cboTICOCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTICOCLSE.FormattingEnabled = True
        Me.cboTICOCLSE.Location = New System.Drawing.Point(137, 119)
        Me.cboTICOCLSE.Name = "cboTICOCLSE"
        Me.cboTICOCLSE.Size = New System.Drawing.Size(112, 22)
        Me.cboTICOCLSE.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(19, 119)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 20)
        Me.Label10.TabIndex = 81
        Me.Label10.Text = "Clase o sector"
        '
        'chkTICOARCO
        '
        Me.chkTICOARCO.AccessibleDescription = "Area convergente"
        Me.chkTICOARCO.AutoSize = True
        Me.chkTICOARCO.Location = New System.Drawing.Point(256, 327)
        Me.chkTICOARCO.Name = "chkTICOARCO"
        Me.chkTICOARCO.Size = New System.Drawing.Size(265, 19)
        Me.chkTICOARCO.TabIndex = 15
        Me.chkTICOARCO.Text = "Identificador en área convergente comercial"
        Me.chkTICOARCO.UseVisualStyleBackColor = True
        '
        'cboTICOMOLI
        '
        Me.cboTICOMOLI.AccessibleDescription = "Modo de liquidación"
        Me.cboTICOMOLI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTICOMOLI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTICOMOLI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTICOMOLI.FormattingEnabled = True
        Me.cboTICOMOLI.Items.AddRange(New Object() {"Ninguno", "Potencial", "Exponencial", "Lineal"})
        Me.cboTICOMOLI.Location = New System.Drawing.Point(137, 280)
        Me.cboTICOMOLI.Name = "cboTICOMOLI"
        Me.cboTICOMOLI.Size = New System.Drawing.Size(112, 22)
        Me.cboTICOMOLI.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(19, 280)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 20)
        Me.Label11.TabIndex = 79
        Me.Label11.Text = "Modo de liquidación"
        '
        'txtTICOFAC2
        '
        Me.txtTICOFAC2.AccessibleDescription = "Factor 2"
        Me.txtTICOFAC2.BackColor = System.Drawing.SystemColors.Window
        Me.txtTICOFAC2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTICOFAC2.Location = New System.Drawing.Point(137, 257)
        Me.txtTICOFAC2.MaxLength = 20
        Me.txtTICOFAC2.Name = "txtTICOFAC2"
        Me.txtTICOFAC2.Size = New System.Drawing.Size(201, 20)
        Me.txtTICOFAC2.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(19, 257)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 20)
        Me.Label9.TabIndex = 77
        Me.Label9.Text = "Factor 2"
        '
        'txtTICOFAC1
        '
        Me.txtTICOFAC1.AccessibleDescription = "Factor 1"
        Me.txtTICOFAC1.BackColor = System.Drawing.SystemColors.Window
        Me.txtTICOFAC1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTICOFAC1.Location = New System.Drawing.Point(137, 234)
        Me.txtTICOFAC1.MaxLength = 20
        Me.txtTICOFAC1.Name = "txtTICOFAC1"
        Me.txtTICOFAC1.Size = New System.Drawing.Size(201, 20)
        Me.txtTICOFAC1.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(19, 234)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 20)
        Me.Label8.TabIndex = 75
        Me.Label8.Text = "Factor 1"
        '
        'txtTICOPUMA
        '
        Me.txtTICOPUMA.AccessibleDescription = "Puntaje maximo"
        Me.txtTICOPUMA.BackColor = System.Drawing.SystemColors.Window
        Me.txtTICOPUMA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTICOPUMA.Location = New System.Drawing.Point(137, 211)
        Me.txtTICOPUMA.MaxLength = 3
        Me.txtTICOPUMA.Name = "txtTICOPUMA"
        Me.txtTICOPUMA.Size = New System.Drawing.Size(112, 20)
        Me.txtTICOPUMA.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(19, 211)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 20)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "Puntaje maximo"
        '
        'txtTICOPUNT
        '
        Me.txtTICOPUNT.AccessibleDescription = "Puntos"
        Me.txtTICOPUNT.BackColor = System.Drawing.SystemColors.Window
        Me.txtTICOPUNT.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTICOPUNT.Location = New System.Drawing.Point(137, 188)
        Me.txtTICOPUNT.MaxLength = 3
        Me.txtTICOPUNT.Name = "txtTICOPUNT"
        Me.txtTICOPUNT.Size = New System.Drawing.Size(112, 20)
        Me.txtTICOPUNT.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(19, 188)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 71
        Me.Label6.Text = "Puntos (Predet.)"
        '
        'lblTICOTIPO
        '
        Me.lblTICOTIPO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTICOTIPO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTICOTIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTICOTIPO.ForeColor = System.Drawing.Color.Black
        Me.lblTICOTIPO.Location = New System.Drawing.Point(256, 95)
        Me.lblTICOTIPO.Name = "lblTICOTIPO"
        Me.lblTICOTIPO.Size = New System.Drawing.Size(302, 20)
        Me.lblTICOTIPO.TabIndex = 69
        '
        'cboTICOTIPO
        '
        Me.cboTICOTIPO.AccessibleDescription = "Tipo"
        Me.cboTICOTIPO.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboTICOTIPO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTICOTIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTICOTIPO.Enabled = False
        Me.cboTICOTIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTICOTIPO.FormattingEnabled = True
        Me.cboTICOTIPO.Location = New System.Drawing.Point(137, 94)
        Me.cboTICOTIPO.Name = "cboTICOTIPO"
        Me.cboTICOTIPO.Size = New System.Drawing.Size(112, 22)
        Me.cboTICOTIPO.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "Tipo de calificación"
        '
        'lblTICOCLCO
        '
        Me.lblTICOCLCO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTICOCLCO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTICOCLCO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTICOCLCO.ForeColor = System.Drawing.Color.Black
        Me.lblTICOCLCO.Location = New System.Drawing.Point(256, 72)
        Me.lblTICOCLCO.Name = "lblTICOCLCO"
        Me.lblTICOCLCO.Size = New System.Drawing.Size(302, 20)
        Me.lblTICOCLCO.TabIndex = 66
        '
        'cboTICOCLCO
        '
        Me.cboTICOCLCO.AccessibleDescription = "Clase de construcción"
        Me.cboTICOCLCO.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboTICOCLCO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTICOCLCO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTICOCLCO.Enabled = False
        Me.cboTICOCLCO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTICOCLCO.FormattingEnabled = True
        Me.cboTICOCLCO.Location = New System.Drawing.Point(137, 70)
        Me.cboTICOCLCO.Name = "cboTICOCLCO"
        Me.cboTICOCLCO.Size = New System.Drawing.Size(112, 22)
        Me.cboTICOCLCO.TabIndex = 3
        '
        'lblClaseosector
        '
        Me.lblClaseosector.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseosector.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseosector.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseosector.ForeColor = System.Drawing.Color.Black
        Me.lblClaseosector.Location = New System.Drawing.Point(19, 72)
        Me.lblClaseosector.Name = "lblClaseosector"
        Me.lblClaseosector.Size = New System.Drawing.Size(112, 20)
        Me.lblClaseosector.TabIndex = 65
        Me.lblClaseosector.Text = "Clase de const."
        '
        'lblTICODEPA
        '
        Me.lblTICODEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTICODEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTICODEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTICODEPA.ForeColor = System.Drawing.Color.Black
        Me.lblTICODEPA.Location = New System.Drawing.Point(256, 26)
        Me.lblTICODEPA.Name = "lblTICODEPA"
        Me.lblTICODEPA.Size = New System.Drawing.Size(302, 20)
        Me.lblTICODEPA.TabIndex = 64
        '
        'cboTICODEPA
        '
        Me.cboTICODEPA.AccessibleDescription = "Departamento"
        Me.cboTICODEPA.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboTICODEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTICODEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTICODEPA.Enabled = False
        Me.cboTICODEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTICODEPA.FormattingEnabled = True
        Me.cboTICODEPA.Location = New System.Drawing.Point(137, 24)
        Me.cboTICODEPA.Name = "cboTICODEPA"
        Me.cboTICODEPA.Size = New System.Drawing.Size(112, 22)
        Me.cboTICODEPA.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 20)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "Departamento"
        '
        'lblTICOMUNI
        '
        Me.lblTICOMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTICOMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTICOMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTICOMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblTICOMUNI.Location = New System.Drawing.Point(256, 49)
        Me.lblTICOMUNI.Name = "lblTICOMUNI"
        Me.lblTICOMUNI.Size = New System.Drawing.Size(302, 20)
        Me.lblTICOMUNI.TabIndex = 62
        '
        'cboTICOMUNI
        '
        Me.cboTICOMUNI.AccessibleDescription = "Municipio"
        Me.cboTICOMUNI.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboTICOMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTICOMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTICOMUNI.Enabled = False
        Me.cboTICOMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTICOMUNI.FormattingEnabled = True
        Me.cboTICOMUNI.Location = New System.Drawing.Point(137, 47)
        Me.cboTICOMUNI.Name = "cboTICOMUNI"
        Me.cboTICOMUNI.Size = New System.Drawing.Size(112, 22)
        Me.cboTICOMUNI.TabIndex = 2
        '
        'lblMUNICIPIO
        '
        Me.lblMUNICIPIO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMUNICIPIO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUNICIPIO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUNICIPIO.ForeColor = System.Drawing.Color.Black
        Me.lblMUNICIPIO.Location = New System.Drawing.Point(19, 49)
        Me.lblMUNICIPIO.Name = "lblMUNICIPIO"
        Me.lblMUNICIPIO.Size = New System.Drawing.Size(112, 20)
        Me.lblMUNICIPIO.TabIndex = 61
        Me.lblMUNICIPIO.Text = "Municipio"
        '
        'cboTICOESTA
        '
        Me.cboTICOESTA.AccessibleDescription = "Estado"
        Me.cboTICOESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTICOESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTICOESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTICOESTA.FormattingEnabled = True
        Me.cboTICOESTA.Location = New System.Drawing.Point(137, 303)
        Me.cboTICOESTA.Name = "cboTICOESTA"
        Me.cboTICOESTA.Size = New System.Drawing.Size(112, 22)
        Me.cboTICOESTA.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 303)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Estado"
        '
        'txtTICODESC
        '
        Me.txtTICODESC.AccessibleDescription = "Descripción"
        Me.txtTICODESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtTICODESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTICODESC.Location = New System.Drawing.Point(137, 165)
        Me.txtTICODESC.MaxLength = 50
        Me.txtTICODESC.Name = "txtTICODESC"
        Me.txtTICODESC.Size = New System.Drawing.Size(421, 20)
        Me.txtTICODESC.TabIndex = 7
        '
        'txtTICOCODI
        '
        Me.txtTICOCODI.AccessibleDescription = "Identificador"
        Me.txtTICOCODI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTICOCODI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTICOCODI.Enabled = False
        Me.txtTICOCODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTICOCODI.Location = New System.Drawing.Point(137, 142)
        Me.txtTICOCODI.MaxLength = 3
        Me.txtTICOCODI.Name = "txtTICOCODI"
        Me.txtTICOCODI.Size = New System.Drawing.Size(112, 20)
        Me.txtTICOCODI.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 165)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Descripción"
        '
        'lblCódigo
        '
        Me.lblCódigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCódigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCódigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCódigo.ForeColor = System.Drawing.Color.Black
        Me.lblCódigo.Location = New System.Drawing.Point(19, 142)
        Me.lblCódigo.Name = "lblCódigo"
        Me.lblCódigo.Size = New System.Drawing.Size(112, 20)
        Me.lblCódigo.TabIndex = 37
        Me.lblCódigo.Text = "Identificador"
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(290, 17)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 17
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(183, 17)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 16
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 382)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(580, 52)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        '
        'frm_modificar_TIPOCONS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdSALIR
        Me.ClientSize = New System.Drawing.Size(605, 471)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.fraTIPODOCUMENTO)
        Me.Controls.Add(Me.strBARRESTA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(621, 507)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(621, 507)
        Me.Name = "frm_modificar_TIPOCONS"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraTIPODOCUMENTO.ResumeLayout(False)
        Me.fraTIPODOCUMENTO.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraTIPODOCUMENTO As System.Windows.Forms.GroupBox
    Friend WithEvents cboTICOMOLI As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTICOFAC2 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTICOFAC1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTICOPUMA As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTICOPUNT As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTICOTIPO As System.Windows.Forms.Label
    Friend WithEvents cboTICOTIPO As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTICOCLCO As System.Windows.Forms.Label
    Friend WithEvents cboTICOCLCO As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents lblTICODEPA As System.Windows.Forms.Label
    Friend WithEvents cboTICODEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTICOMUNI As System.Windows.Forms.Label
    Friend WithEvents cboTICOMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents cboTICOESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTICODESC As System.Windows.Forms.TextBox
    Friend WithEvents txtTICOCODI As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCódigo As System.Windows.Forms.Label
    Friend WithEvents chkTICOARCO As System.Windows.Forms.CheckBox
    Friend WithEvents lblTICOCLSE As System.Windows.Forms.Label
    Friend WithEvents cboTICOCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTICOPOIN As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
