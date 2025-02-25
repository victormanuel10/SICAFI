<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_TARILOTE
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
        Me.fraTARILOTE = New System.Windows.Forms.GroupBox
        Me.txtTALOAVFI = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTALOAVIN = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtTALOTARI = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblTALOZOEC = New System.Windows.Forms.Label
        Me.cboTALOZOEC = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblTALOVIGE = New System.Windows.Forms.Label
        Me.cboTALOVIGE = New System.Windows.Forms.ComboBox
        Me.lblTALOCLSE = New System.Windows.Forms.Label
        Me.cboTALOCLSE = New System.Windows.Forms.ComboBox
        Me.lblClaseosector = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblTALODEPA = New System.Windows.Forms.Label
        Me.cboTALODEPA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblTALOMUNI = New System.Windows.Forms.Label
        Me.cboTALOMUNI = New System.Windows.Forms.ComboBox
        Me.lblMUNICIPIO = New System.Windows.Forms.Label
        Me.cboTALOESTA = New System.Windows.Forms.ComboBox
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraTARILOTE.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 268)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 52)
        Me.GroupBox1.TabIndex = 50
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
        Me.strBARRESTA.TabIndex = 51
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
        'fraTARILOTE
        '
        Me.fraTARILOTE.BackColor = System.Drawing.SystemColors.Control
        Me.fraTARILOTE.Controls.Add(Me.txtTALOAVFI)
        Me.fraTARILOTE.Controls.Add(Me.Label9)
        Me.fraTARILOTE.Controls.Add(Me.txtTALOAVIN)
        Me.fraTARILOTE.Controls.Add(Me.Label17)
        Me.fraTARILOTE.Controls.Add(Me.txtTALOTARI)
        Me.fraTARILOTE.Controls.Add(Me.Label14)
        Me.fraTARILOTE.Controls.Add(Me.lblTALOZOEC)
        Me.fraTARILOTE.Controls.Add(Me.cboTALOZOEC)
        Me.fraTARILOTE.Controls.Add(Me.Label11)
        Me.fraTARILOTE.Controls.Add(Me.lblTALOVIGE)
        Me.fraTARILOTE.Controls.Add(Me.cboTALOVIGE)
        Me.fraTARILOTE.Controls.Add(Me.lblTALOCLSE)
        Me.fraTARILOTE.Controls.Add(Me.cboTALOCLSE)
        Me.fraTARILOTE.Controls.Add(Me.lblClaseosector)
        Me.fraTARILOTE.Controls.Add(Me.Label3)
        Me.fraTARILOTE.Controls.Add(Me.lblTALODEPA)
        Me.fraTARILOTE.Controls.Add(Me.cboTALODEPA)
        Me.fraTARILOTE.Controls.Add(Me.Label4)
        Me.fraTARILOTE.Controls.Add(Me.lblTALOMUNI)
        Me.fraTARILOTE.Controls.Add(Me.cboTALOMUNI)
        Me.fraTARILOTE.Controls.Add(Me.lblMUNICIPIO)
        Me.fraTARILOTE.Controls.Add(Me.cboTALOESTA)
        Me.fraTARILOTE.Controls.Add(Me.lblCodigo)
        Me.fraTARILOTE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraTARILOTE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraTARILOTE.Location = New System.Drawing.Point(12, 9)
        Me.fraTARILOTE.Name = "fraTARILOTE"
        Me.fraTARILOTE.Size = New System.Drawing.Size(572, 253)
        Me.fraTARILOTE.TabIndex = 49
        Me.fraTARILOTE.TabStop = False
        Me.fraTARILOTE.Text = "MODIFICAR TARIFA POR LOTES"
        '
        'txtTALOAVFI
        '
        Me.txtTALOAVFI.AccessibleDescription = "Avalúo final"
        Me.txtTALOAVFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTALOAVFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTALOAVFI.Location = New System.Drawing.Point(137, 189)
        Me.txtTALOAVFI.MaxLength = 12
        Me.txtTALOAVFI.Name = "txtTALOAVFI"
        Me.txtTALOAVFI.Size = New System.Drawing.Size(112, 20)
        Me.txtTALOAVFI.TabIndex = 16
        Me.txtTALOAVFI.Text = "0"
        Me.txtTALOAVFI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txtTALOAVIN
        '
        Me.txtTALOAVIN.AccessibleDescription = "Avaluo inicial"
        Me.txtTALOAVIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtTALOAVIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTALOAVIN.Location = New System.Drawing.Point(137, 166)
        Me.txtTALOAVIN.MaxLength = 12
        Me.txtTALOAVIN.Name = "txtTALOAVIN"
        Me.txtTALOAVIN.Size = New System.Drawing.Size(112, 20)
        Me.txtTALOAVIN.TabIndex = 15
        Me.txtTALOAVIN.Text = "0"
        Me.txtTALOAVIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txtTALOTARI
        '
        Me.txtTALOTARI.AccessibleDescription = "Tarifa "
        Me.txtTALOTARI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTALOTARI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTALOTARI.Location = New System.Drawing.Point(137, 143)
        Me.txtTALOTARI.MaxLength = 9
        Me.txtTALOTARI.Name = "txtTALOTARI"
        Me.txtTALOTARI.Size = New System.Drawing.Size(112, 20)
        Me.txtTALOTARI.TabIndex = 6
        Me.txtTALOTARI.Text = "0"
        Me.txtTALOTARI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.Label14.Text = "$ Tarifa mt2"
        '
        'lblTALOZOEC
        '
        Me.lblTALOZOEC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTALOZOEC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTALOZOEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTALOZOEC.ForeColor = System.Drawing.Color.Black
        Me.lblTALOZOEC.Location = New System.Drawing.Point(453, 120)
        Me.lblTALOZOEC.Name = "lblTALOZOEC"
        Me.lblTALOZOEC.Size = New System.Drawing.Size(105, 20)
        Me.lblTALOZOEC.TabIndex = 78
        '
        'cboTALOZOEC
        '
        Me.cboTALOZOEC.AccessibleDescription = "Zona económica"
        Me.cboTALOZOEC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTALOZOEC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTALOZOEC.Enabled = False
        Me.cboTALOZOEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTALOZOEC.FormattingEnabled = True
        Me.cboTALOZOEC.Location = New System.Drawing.Point(137, 118)
        Me.cboTALOZOEC.Name = "cboTALOZOEC"
        Me.cboTALOZOEC.Size = New System.Drawing.Size(310, 22)
        Me.cboTALOZOEC.TabIndex = 5
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
        Me.Label11.Text = "Zona económica"
        '
        'lblTALOVIGE
        '
        Me.lblTALOVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTALOVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTALOVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTALOVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblTALOVIGE.Location = New System.Drawing.Point(453, 97)
        Me.lblTALOVIGE.Name = "lblTALOVIGE"
        Me.lblTALOVIGE.Size = New System.Drawing.Size(105, 20)
        Me.lblTALOVIGE.TabIndex = 62
        '
        'cboTALOVIGE
        '
        Me.cboTALOVIGE.AccessibleDescription = "Vigencia"
        Me.cboTALOVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTALOVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTALOVIGE.Enabled = False
        Me.cboTALOVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTALOVIGE.FormattingEnabled = True
        Me.cboTALOVIGE.Location = New System.Drawing.Point(137, 95)
        Me.cboTALOVIGE.Name = "cboTALOVIGE"
        Me.cboTALOVIGE.Size = New System.Drawing.Size(310, 22)
        Me.cboTALOVIGE.TabIndex = 4
        '
        'lblTALOCLSE
        '
        Me.lblTALOCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTALOCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTALOCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTALOCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblTALOCLSE.Location = New System.Drawing.Point(453, 74)
        Me.lblTALOCLSE.Name = "lblTALOCLSE"
        Me.lblTALOCLSE.Size = New System.Drawing.Size(105, 20)
        Me.lblTALOCLSE.TabIndex = 57
        '
        'cboTALOCLSE
        '
        Me.cboTALOCLSE.AccessibleDescription = "Clase o sector"
        Me.cboTALOCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTALOCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTALOCLSE.Enabled = False
        Me.cboTALOCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTALOCLSE.FormattingEnabled = True
        Me.cboTALOCLSE.Location = New System.Drawing.Point(137, 72)
        Me.cboTALOCLSE.Name = "cboTALOCLSE"
        Me.cboTALOCLSE.Size = New System.Drawing.Size(310, 22)
        Me.cboTALOCLSE.TabIndex = 3
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
        'lblTALODEPA
        '
        Me.lblTALODEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTALODEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTALODEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTALODEPA.ForeColor = System.Drawing.Color.Black
        Me.lblTALODEPA.Location = New System.Drawing.Point(453, 28)
        Me.lblTALODEPA.Name = "lblTALODEPA"
        Me.lblTALODEPA.Size = New System.Drawing.Size(105, 20)
        Me.lblTALODEPA.TabIndex = 52
        '
        'cboTALODEPA
        '
        Me.cboTALODEPA.AccessibleDescription = "Departamento"
        Me.cboTALODEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTALODEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTALODEPA.Enabled = False
        Me.cboTALODEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTALODEPA.FormattingEnabled = True
        Me.cboTALODEPA.Location = New System.Drawing.Point(137, 26)
        Me.cboTALODEPA.Name = "cboTALODEPA"
        Me.cboTALODEPA.Size = New System.Drawing.Size(310, 22)
        Me.cboTALODEPA.TabIndex = 1
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
        'lblTALOMUNI
        '
        Me.lblTALOMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTALOMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTALOMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTALOMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblTALOMUNI.Location = New System.Drawing.Point(453, 51)
        Me.lblTALOMUNI.Name = "lblTALOMUNI"
        Me.lblTALOMUNI.Size = New System.Drawing.Size(105, 20)
        Me.lblTALOMUNI.TabIndex = 50
        '
        'cboTALOMUNI
        '
        Me.cboTALOMUNI.AccessibleDescription = "Municipio"
        Me.cboTALOMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTALOMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTALOMUNI.Enabled = False
        Me.cboTALOMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTALOMUNI.FormattingEnabled = True
        Me.cboTALOMUNI.Location = New System.Drawing.Point(137, 49)
        Me.cboTALOMUNI.Name = "cboTALOMUNI"
        Me.cboTALOMUNI.Size = New System.Drawing.Size(310, 22)
        Me.cboTALOMUNI.TabIndex = 2
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
        'cboTALOESTA
        '
        Me.cboTALOESTA.AccessibleDescription = "Estado"
        Me.cboTALOESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTALOESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTALOESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTALOESTA.FormattingEnabled = True
        Me.cboTALOESTA.Location = New System.Drawing.Point(137, 213)
        Me.cboTALOESTA.Name = "cboTALOESTA"
        Me.cboTALOESTA.Size = New System.Drawing.Size(310, 22)
        Me.cboTALOESTA.TabIndex = 17
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
        'frm_modificar_TARILOTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 356)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraTARILOTE)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(617, 392)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(617, 392)
        Me.Name = "frm_modificar_TARILOTE"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraTARILOTE.ResumeLayout(False)
        Me.fraTARILOTE.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraTARILOTE As System.Windows.Forms.GroupBox
    Friend WithEvents txtTALOAVFI As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTALOAVIN As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTALOTARI As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblTALOZOEC As System.Windows.Forms.Label
    Friend WithEvents cboTALOZOEC As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblTALOVIGE As System.Windows.Forms.Label
    Friend WithEvents cboTALOVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents lblTALOCLSE As System.Windows.Forms.Label
    Friend WithEvents cboTALOCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTALODEPA As System.Windows.Forms.Label
    Friend WithEvents cboTALODEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTALOMUNI As System.Windows.Forms.Label
    Friend WithEvents cboTALOMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cboTALOESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
End Class
