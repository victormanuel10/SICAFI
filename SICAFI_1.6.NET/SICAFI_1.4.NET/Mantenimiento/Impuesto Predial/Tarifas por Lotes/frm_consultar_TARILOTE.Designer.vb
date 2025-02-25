<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_TARILOTE
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdSalir = New System.Windows.Forms.Button
        Me.cmdLimpiar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.cmdConsultar = New System.Windows.Forms.Button
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.fraPERIODO = New System.Windows.Forms.GroupBox
        Me.txtTALOAVFI = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtTALOAVIN = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtTALOZOEC = New System.Windows.Forms.TextBox
        Me.lblVIACVIAC = New System.Windows.Forms.Label
        Me.txtTALOTARI = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtTALOVIGE = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTALOCLSE = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTALOMUNI = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTALODEPA = New System.Windows.Forms.TextBox
        Me.lblidzona = New System.Windows.Forms.Label
        Me.txtTALOESTA = New System.Windows.Forms.TextBox
        Me.dgvCONSULTA = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraPERIODO.SuspendLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdSalir)
        Me.GroupBox1.Controls.Add(Me.cmdLimpiar)
        Me.GroupBox1.Controls.Add(Me.cmdAceptar)
        Me.GroupBox1.Controls.Add(Me.cmdConsultar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 401)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(892, 60)
        Me.GroupBox1.TabIndex = 74
        Me.GroupBox1.TabStop = False
        '
        'cmdSalir
        '
        Me.cmdSalir.AccessibleDescription = "Salir"
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(776, 20)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(101, 23)
        Me.cmdSalir.TabIndex = 8
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdLimpiar
        '
        Me.cmdLimpiar.AccessibleDescription = "Limpiar"
        Me.cmdLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLimpiar.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLimpiar.Location = New System.Drawing.Point(19, 20)
        Me.cmdLimpiar.Name = "cmdLimpiar"
        Me.cmdLimpiar.Size = New System.Drawing.Size(101, 23)
        Me.cmdLimpiar.TabIndex = 5
        Me.cmdLimpiar.Text = "&Limpiar"
        Me.cmdLimpiar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.AccessibleDescription = "Aceptar"
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Enabled = False
        Me.cmdAceptar.Image = Global.SICAFI.My.Resources.Resources._22
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(669, 20)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(101, 23)
        Me.cmdAceptar.TabIndex = 7
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdConsultar
        '
        Me.cmdConsultar.AccessibleDescription = "Consultar"
        Me.cmdConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdConsultar.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdConsultar.Location = New System.Drawing.Point(562, 20)
        Me.cmdConsultar.Name = "cmdConsultar"
        Me.cmdConsultar.Size = New System.Drawing.Size(101, 23)
        Me.cmdConsultar.TabIndex = 6
        Me.cmdConsultar.Text = "&Consultar"
        Me.cmdConsultar.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 474)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(917, 25)
        Me.strBARRESTA.TabIndex = 75
        '
        'tstBAESVALI
        '
        Me.tstBAESVALI.AutoSize = False
        Me.tstBAESVALI.BackColor = System.Drawing.SystemColors.Control
        Me.tstBAESVALI.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tstBAESVALI.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tstBAESVALI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstBAESVALI.ForeColor = System.Drawing.Color.Black
        Me.tstBAESVALI.ImageTransparentColor = System.Drawing.Color.White
        Me.tstBAESVALI.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.tstBAESVALI.Name = "tstBAESVALI"
        Me.tstBAESVALI.Size = New System.Drawing.Size(125, 22)
        Me.tstBAESVALI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tstBAESDESC
        '
        Me.tstBAESDESC.AutoSize = False
        Me.tstBAESDESC.BackColor = System.Drawing.SystemColors.Control
        Me.tstBAESDESC.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tstBAESDESC.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tstBAESDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstBAESDESC.ForeColor = System.Drawing.Color.Black
        Me.tstBAESDESC.ImageTransparentColor = System.Drawing.Color.White
        Me.tstBAESDESC.LinkColor = System.Drawing.Color.Black
        Me.tstBAESDESC.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.tstBAESDESC.Name = "tstBAESDESC"
        Me.tstBAESDESC.Size = New System.Drawing.Size(300, 22)
        Me.tstBAESDESC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(125, 22)
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fraPERIODO
        '
        Me.fraPERIODO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fraPERIODO.BackColor = System.Drawing.SystemColors.Control
        Me.fraPERIODO.Controls.Add(Me.txtTALOAVFI)
        Me.fraPERIODO.Controls.Add(Me.Label18)
        Me.fraPERIODO.Controls.Add(Me.txtTALOAVIN)
        Me.fraPERIODO.Controls.Add(Me.Label17)
        Me.fraPERIODO.Controls.Add(Me.txtTALOZOEC)
        Me.fraPERIODO.Controls.Add(Me.lblVIACVIAC)
        Me.fraPERIODO.Controls.Add(Me.txtTALOTARI)
        Me.fraPERIODO.Controls.Add(Me.Label8)
        Me.fraPERIODO.Controls.Add(Me.txtTALOVIGE)
        Me.fraPERIODO.Controls.Add(Me.Label6)
        Me.fraPERIODO.Controls.Add(Me.txtTALOCLSE)
        Me.fraPERIODO.Controls.Add(Me.Label5)
        Me.fraPERIODO.Controls.Add(Me.txtTALOMUNI)
        Me.fraPERIODO.Controls.Add(Me.Label3)
        Me.fraPERIODO.Controls.Add(Me.txtTALODEPA)
        Me.fraPERIODO.Controls.Add(Me.lblidzona)
        Me.fraPERIODO.Controls.Add(Me.txtTALOESTA)
        Me.fraPERIODO.Controls.Add(Me.dgvCONSULTA)
        Me.fraPERIODO.Controls.Add(Me.Label2)
        Me.fraPERIODO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPERIODO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPERIODO.Location = New System.Drawing.Point(12, 8)
        Me.fraPERIODO.Name = "fraPERIODO"
        Me.fraPERIODO.Size = New System.Drawing.Size(890, 390)
        Me.fraPERIODO.TabIndex = 73
        Me.fraPERIODO.TabStop = False
        Me.fraPERIODO.Text = "CONSULTA TARIFA POR LOTES"
        '
        'txtTALOAVFI
        '
        Me.txtTALOAVFI.AccessibleDescription = "Avalúo final"
        Me.txtTALOAVFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTALOAVFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTALOAVFI.Location = New System.Drawing.Point(666, 46)
        Me.txtTALOAVFI.MaxLength = 9
        Me.txtTALOAVFI.Name = "txtTALOAVFI"
        Me.txtTALOAVFI.Size = New System.Drawing.Size(124, 20)
        Me.txtTALOAVFI.TabIndex = 16
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(666, 23)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(124, 20)
        Me.Label18.TabIndex = 80
        Me.Label18.Text = "Avalúo final"
        '
        'txtTALOAVIN
        '
        Me.txtTALOAVIN.AccessibleDescription = "Avalúo inicial"
        Me.txtTALOAVIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtTALOAVIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTALOAVIN.Location = New System.Drawing.Point(535, 46)
        Me.txtTALOAVIN.MaxLength = 9
        Me.txtTALOAVIN.Name = "txtTALOAVIN"
        Me.txtTALOAVIN.Size = New System.Drawing.Size(127, 20)
        Me.txtTALOAVIN.TabIndex = 15
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(535, 23)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(127, 20)
        Me.Label17.TabIndex = 78
        Me.Label17.Text = "Avalúo inicial"
        '
        'txtTALOZOEC
        '
        Me.txtTALOZOEC.AccessibleDescription = "Zona "
        Me.txtTALOZOEC.BackColor = System.Drawing.SystemColors.Window
        Me.txtTALOZOEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTALOZOEC.Location = New System.Drawing.Point(363, 46)
        Me.txtTALOZOEC.MaxLength = 9
        Me.txtTALOZOEC.Name = "txtTALOZOEC"
        Me.txtTALOZOEC.Size = New System.Drawing.Size(83, 20)
        Me.txtTALOZOEC.TabIndex = 5
        '
        'lblVIACVIAC
        '
        Me.lblVIACVIAC.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblVIACVIAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVIACVIAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVIACVIAC.ForeColor = System.Drawing.Color.Black
        Me.lblVIACVIAC.Location = New System.Drawing.Point(363, 23)
        Me.lblVIACVIAC.Name = "lblVIACVIAC"
        Me.lblVIACVIAC.Size = New System.Drawing.Size(83, 20)
        Me.lblVIACVIAC.TabIndex = 60
        Me.lblVIACVIAC.Text = "Zona"
        '
        'txtTALOTARI
        '
        Me.txtTALOTARI.AccessibleDescription = "Tarifa "
        Me.txtTALOTARI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTALOTARI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTALOTARI.Location = New System.Drawing.Point(449, 46)
        Me.txtTALOTARI.MaxLength = 9
        Me.txtTALOTARI.Name = "txtTALOTARI"
        Me.txtTALOTARI.Size = New System.Drawing.Size(83, 20)
        Me.txtTALOTARI.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(449, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 20)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "Tarifa"
        '
        'txtTALOVIGE
        '
        Me.txtTALOVIGE.AccessibleDescription = "Vigencia"
        Me.txtTALOVIGE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTALOVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTALOVIGE.Location = New System.Drawing.Point(277, 46)
        Me.txtTALOVIGE.MaxLength = 9
        Me.txtTALOVIGE.Name = "txtTALOVIGE"
        Me.txtTALOVIGE.Size = New System.Drawing.Size(83, 20)
        Me.txtTALOVIGE.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(277, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 20)
        Me.Label6.TabIndex = 56
        Me.Label6.Text = "Vigencia"
        '
        'txtTALOCLSE
        '
        Me.txtTALOCLSE.AccessibleDescription = "Sector"
        Me.txtTALOCLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTALOCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTALOCLSE.Location = New System.Drawing.Point(191, 46)
        Me.txtTALOCLSE.MaxLength = 9
        Me.txtTALOCLSE.Name = "txtTALOCLSE"
        Me.txtTALOCLSE.Size = New System.Drawing.Size(83, 20)
        Me.txtTALOCLSE.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(191, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 20)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Sector"
        '
        'txtTALOMUNI
        '
        Me.txtTALOMUNI.AccessibleDescription = "Municipio"
        Me.txtTALOMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTALOMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTALOMUNI.Location = New System.Drawing.Point(105, 46)
        Me.txtTALOMUNI.MaxLength = 9
        Me.txtTALOMUNI.Name = "txtTALOMUNI"
        Me.txtTALOMUNI.Size = New System.Drawing.Size(83, 20)
        Me.txtTALOMUNI.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(105, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 20)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Municipio"
        '
        'txtTALODEPA
        '
        Me.txtTALODEPA.AccessibleDescription = "Departamento"
        Me.txtTALODEPA.BackColor = System.Drawing.SystemColors.Window
        Me.txtTALODEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTALODEPA.Location = New System.Drawing.Point(19, 46)
        Me.txtTALODEPA.MaxLength = 9
        Me.txtTALODEPA.Name = "txtTALODEPA"
        Me.txtTALODEPA.Size = New System.Drawing.Size(83, 20)
        Me.txtTALODEPA.TabIndex = 1
        '
        'lblidzona
        '
        Me.lblidzona.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblidzona.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblidzona.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblidzona.ForeColor = System.Drawing.Color.Black
        Me.lblidzona.Location = New System.Drawing.Point(19, 23)
        Me.lblidzona.Name = "lblidzona"
        Me.lblidzona.Size = New System.Drawing.Size(83, 20)
        Me.lblidzona.TabIndex = 48
        Me.lblidzona.Text = "Departamento"
        '
        'txtTALOESTA
        '
        Me.txtTALOESTA.AccessibleDescription = "Estado"
        Me.txtTALOESTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtTALOESTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtTALOESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTALOESTA.Location = New System.Drawing.Point(793, 46)
        Me.txtTALOESTA.MaxLength = 9
        Me.txtTALOESTA.Name = "txtTALOESTA"
        Me.txtTALOESTA.Size = New System.Drawing.Size(83, 20)
        Me.txtTALOESTA.TabIndex = 17
        '
        'dgvCONSULTA
        '
        Me.dgvCONSULTA.AccessibleDescription = ""
        Me.dgvCONSULTA.AllowUserToAddRows = False
        Me.dgvCONSULTA.AllowUserToDeleteRows = False
        Me.dgvCONSULTA.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCONSULTA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCONSULTA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCONSULTA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCONSULTA.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCONSULTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCONSULTA.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCONSULTA.ColumnHeadersHeight = 30
        Me.dgvCONSULTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCONSULTA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA.Location = New System.Drawing.Point(19, 72)
        Me.dgvCONSULTA.MultiSelect = False
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        Me.dgvCONSULTA.RowHeadersVisible = False
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(856, 302)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(793, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Estado"
        '
        'frm_consultar_TARILOTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 499)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraPERIODO)
        Me.Name = "frm_consultar_TARILOTE"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraPERIODO.ResumeLayout(False)
        Me.fraPERIODO.PerformLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents cmdLimpiar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdConsultar As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraPERIODO As System.Windows.Forms.GroupBox
    Friend WithEvents txtTALOAVFI As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtTALOAVIN As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTALOZOEC As System.Windows.Forms.TextBox
    Friend WithEvents lblVIACVIAC As System.Windows.Forms.Label
    Friend WithEvents txtTALOTARI As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTALOVIGE As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTALOCLSE As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTALOMUNI As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTALODEPA As System.Windows.Forms.TextBox
    Friend WithEvents lblidzona As System.Windows.Forms.Label
    Friend WithEvents txtTALOESTA As System.Windows.Forms.TextBox
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
