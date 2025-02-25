<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_TARIACBO
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
        Me.txtTAABAVFI = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtTAABAVIN = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtTAABTA05 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtTAABTA04 = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtTAABTA03 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtTAABTA02 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtTAABTA01 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtTAABESTR = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtTAABTAIN = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTAABTACO = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTAABTIPO = New System.Windows.Forms.TextBox
        Me.lblVIACVIAC = New System.Windows.Forms.Label
        Me.txtTAABTARE = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtTAABVIGE = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTAABCLSE = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTAABMUNI = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTAABDEPA = New System.Windows.Forms.TextBox
        Me.lblidzona = New System.Windows.Forms.Label
        Me.txtTAABESTA = New System.Windows.Forms.TextBox
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 394)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(805, 60)
        Me.GroupBox1.TabIndex = 71
        Me.GroupBox1.TabStop = False
        '
        'cmdSalir
        '
        Me.cmdSalir.AccessibleDescription = "Salir"
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(689, 20)
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
        Me.cmdAceptar.Location = New System.Drawing.Point(582, 20)
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
        Me.cmdConsultar.Location = New System.Drawing.Point(475, 20)
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
        Me.strBARRESTA.Size = New System.Drawing.Size(830, 25)
        Me.strBARRESTA.TabIndex = 72
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
        Me.fraPERIODO.Controls.Add(Me.txtTAABAVFI)
        Me.fraPERIODO.Controls.Add(Me.Label18)
        Me.fraPERIODO.Controls.Add(Me.txtTAABAVIN)
        Me.fraPERIODO.Controls.Add(Me.Label17)
        Me.fraPERIODO.Controls.Add(Me.txtTAABTA05)
        Me.fraPERIODO.Controls.Add(Me.Label16)
        Me.fraPERIODO.Controls.Add(Me.txtTAABTA04)
        Me.fraPERIODO.Controls.Add(Me.Label15)
        Me.fraPERIODO.Controls.Add(Me.txtTAABTA03)
        Me.fraPERIODO.Controls.Add(Me.Label14)
        Me.fraPERIODO.Controls.Add(Me.txtTAABTA02)
        Me.fraPERIODO.Controls.Add(Me.Label13)
        Me.fraPERIODO.Controls.Add(Me.txtTAABTA01)
        Me.fraPERIODO.Controls.Add(Me.Label12)
        Me.fraPERIODO.Controls.Add(Me.txtTAABESTR)
        Me.fraPERIODO.Controls.Add(Me.Label11)
        Me.fraPERIODO.Controls.Add(Me.txtTAABTAIN)
        Me.fraPERIODO.Controls.Add(Me.Label10)
        Me.fraPERIODO.Controls.Add(Me.txtTAABTACO)
        Me.fraPERIODO.Controls.Add(Me.Label9)
        Me.fraPERIODO.Controls.Add(Me.txtTAABTIPO)
        Me.fraPERIODO.Controls.Add(Me.lblVIACVIAC)
        Me.fraPERIODO.Controls.Add(Me.txtTAABTARE)
        Me.fraPERIODO.Controls.Add(Me.Label8)
        Me.fraPERIODO.Controls.Add(Me.txtTAABVIGE)
        Me.fraPERIODO.Controls.Add(Me.Label6)
        Me.fraPERIODO.Controls.Add(Me.txtTAABCLSE)
        Me.fraPERIODO.Controls.Add(Me.Label5)
        Me.fraPERIODO.Controls.Add(Me.txtTAABMUNI)
        Me.fraPERIODO.Controls.Add(Me.Label3)
        Me.fraPERIODO.Controls.Add(Me.txtTAABDEPA)
        Me.fraPERIODO.Controls.Add(Me.lblidzona)
        Me.fraPERIODO.Controls.Add(Me.txtTAABESTA)
        Me.fraPERIODO.Controls.Add(Me.dgvCONSULTA)
        Me.fraPERIODO.Controls.Add(Me.Label2)
        Me.fraPERIODO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPERIODO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPERIODO.Location = New System.Drawing.Point(12, 1)
        Me.fraPERIODO.Name = "fraPERIODO"
        Me.fraPERIODO.Size = New System.Drawing.Size(805, 390)
        Me.fraPERIODO.TabIndex = 70
        Me.fraPERIODO.TabStop = False
        Me.fraPERIODO.Text = "TARIFA ACTIVIDAD BOMBERIL"
        '
        'txtTAABAVFI
        '
        Me.txtTAABAVFI.AccessibleDescription = "Avalúo final"
        Me.txtTAABAVFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABAVFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABAVFI.Location = New System.Drawing.Point(580, 92)
        Me.txtTAABAVFI.MaxLength = 9
        Me.txtTAABAVFI.Name = "txtTAABAVFI"
        Me.txtTAABAVFI.Size = New System.Drawing.Size(124, 20)
        Me.txtTAABAVFI.TabIndex = 16
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(580, 69)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(124, 20)
        Me.Label18.TabIndex = 80
        Me.Label18.Text = "Avalúo final"
        '
        'txtTAABAVIN
        '
        Me.txtTAABAVIN.AccessibleDescription = "Avalúo inicial"
        Me.txtTAABAVIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABAVIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABAVIN.Location = New System.Drawing.Point(449, 92)
        Me.txtTAABAVIN.MaxLength = 9
        Me.txtTAABAVIN.Name = "txtTAABAVIN"
        Me.txtTAABAVIN.Size = New System.Drawing.Size(127, 20)
        Me.txtTAABAVIN.TabIndex = 15
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(449, 69)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(127, 20)
        Me.Label17.TabIndex = 78
        Me.Label17.Text = "Avalúo inicial"
        '
        'txtTAABTA05
        '
        Me.txtTAABTA05.AccessibleDescription = "Tarifa 05"
        Me.txtTAABTA05.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABTA05.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABTA05.Location = New System.Drawing.Point(363, 92)
        Me.txtTAABTA05.MaxLength = 9
        Me.txtTAABTA05.Name = "txtTAABTA05"
        Me.txtTAABTA05.Size = New System.Drawing.Size(83, 20)
        Me.txtTAABTA05.TabIndex = 14
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(363, 69)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 20)
        Me.Label16.TabIndex = 76
        Me.Label16.Text = "Tarifa 05"
        '
        'txtTAABTA04
        '
        Me.txtTAABTA04.AccessibleDescription = "Tarifa 04"
        Me.txtTAABTA04.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABTA04.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABTA04.Location = New System.Drawing.Point(277, 92)
        Me.txtTAABTA04.MaxLength = 9
        Me.txtTAABTA04.Name = "txtTAABTA04"
        Me.txtTAABTA04.Size = New System.Drawing.Size(83, 20)
        Me.txtTAABTA04.TabIndex = 13
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(277, 69)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 20)
        Me.Label15.TabIndex = 74
        Me.Label15.Text = "Tarifa 04"
        '
        'txtTAABTA03
        '
        Me.txtTAABTA03.AccessibleDescription = "Tarifa 03"
        Me.txtTAABTA03.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABTA03.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABTA03.Location = New System.Drawing.Point(191, 92)
        Me.txtTAABTA03.MaxLength = 9
        Me.txtTAABTA03.Name = "txtTAABTA03"
        Me.txtTAABTA03.Size = New System.Drawing.Size(83, 20)
        Me.txtTAABTA03.TabIndex = 12
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(191, 69)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 20)
        Me.Label14.TabIndex = 72
        Me.Label14.Text = "Tarifa 03"
        '
        'txtTAABTA02
        '
        Me.txtTAABTA02.AccessibleDescription = "Tarifa 02"
        Me.txtTAABTA02.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABTA02.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABTA02.Location = New System.Drawing.Point(105, 92)
        Me.txtTAABTA02.MaxLength = 9
        Me.txtTAABTA02.Name = "txtTAABTA02"
        Me.txtTAABTA02.Size = New System.Drawing.Size(83, 20)
        Me.txtTAABTA02.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(105, 69)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 20)
        Me.Label13.TabIndex = 70
        Me.Label13.Text = "Tarifa 02"
        '
        'txtTAABTA01
        '
        Me.txtTAABTA01.AccessibleDescription = "Tarifa 01"
        Me.txtTAABTA01.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABTA01.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABTA01.Location = New System.Drawing.Point(19, 92)
        Me.txtTAABTA01.MaxLength = 9
        Me.txtTAABTA01.Name = "txtTAABTA01"
        Me.txtTAABTA01.Size = New System.Drawing.Size(83, 20)
        Me.txtTAABTA01.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(19, 69)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 20)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "Tarifa 01"
        '
        'txtTAABESTR
        '
        Me.txtTAABESTR.AccessibleDescription = "Estrato"
        Me.txtTAABESTR.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABESTR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABESTR.Location = New System.Drawing.Point(707, 46)
        Me.txtTAABESTR.MaxLength = 9
        Me.txtTAABESTR.Name = "txtTAABESTR"
        Me.txtTAABESTR.Size = New System.Drawing.Size(83, 20)
        Me.txtTAABESTR.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(707, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 20)
        Me.Label11.TabIndex = 66
        Me.Label11.Text = "Estrato"
        '
        'txtTAABTAIN
        '
        Me.txtTAABTAIN.AccessibleDescription = "Tarifa industrial"
        Me.txtTAABTAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABTAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABTAIN.Location = New System.Drawing.Point(621, 46)
        Me.txtTAABTAIN.MaxLength = 9
        Me.txtTAABTAIN.Name = "txtTAABTAIN"
        Me.txtTAABTAIN.Size = New System.Drawing.Size(83, 20)
        Me.txtTAABTAIN.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(621, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 20)
        Me.Label10.TabIndex = 64
        Me.Label10.Text = "Ta. Industrial"
        '
        'txtTAABTACO
        '
        Me.txtTAABTACO.AccessibleDescription = "Tarifa comercial"
        Me.txtTAABTACO.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABTACO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABTACO.Location = New System.Drawing.Point(535, 46)
        Me.txtTAABTACO.MaxLength = 9
        Me.txtTAABTACO.Name = "txtTAABTACO"
        Me.txtTAABTACO.Size = New System.Drawing.Size(83, 20)
        Me.txtTAABTACO.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(535, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 20)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "Ta. Comercial"
        '
        'txtTAABTIPO
        '
        Me.txtTAABTIPO.AccessibleDescription = "Tipo calificación"
        Me.txtTAABTIPO.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABTIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABTIPO.Location = New System.Drawing.Point(363, 46)
        Me.txtTAABTIPO.MaxLength = 9
        Me.txtTAABTIPO.Name = "txtTAABTIPO"
        Me.txtTAABTIPO.Size = New System.Drawing.Size(83, 20)
        Me.txtTAABTIPO.TabIndex = 5
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
        Me.lblVIACVIAC.Text = "Tipo califica."
        '
        'txtTAABTARE
        '
        Me.txtTAABTARE.AccessibleDescription = "Tarifa residencial"
        Me.txtTAABTARE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABTARE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABTARE.Location = New System.Drawing.Point(449, 46)
        Me.txtTAABTARE.MaxLength = 9
        Me.txtTAABTARE.Name = "txtTAABTARE"
        Me.txtTAABTARE.Size = New System.Drawing.Size(83, 20)
        Me.txtTAABTARE.TabIndex = 6
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
        Me.Label8.Text = "Ta. Residencial"
        '
        'txtTAABVIGE
        '
        Me.txtTAABVIGE.AccessibleDescription = "Vigencia"
        Me.txtTAABVIGE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABVIGE.Location = New System.Drawing.Point(277, 46)
        Me.txtTAABVIGE.MaxLength = 9
        Me.txtTAABVIGE.Name = "txtTAABVIGE"
        Me.txtTAABVIGE.Size = New System.Drawing.Size(83, 20)
        Me.txtTAABVIGE.TabIndex = 4
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
        'txtTAABCLSE
        '
        Me.txtTAABCLSE.AccessibleDescription = "Sector"
        Me.txtTAABCLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABCLSE.Location = New System.Drawing.Point(191, 46)
        Me.txtTAABCLSE.MaxLength = 9
        Me.txtTAABCLSE.Name = "txtTAABCLSE"
        Me.txtTAABCLSE.Size = New System.Drawing.Size(83, 20)
        Me.txtTAABCLSE.TabIndex = 3
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
        'txtTAABMUNI
        '
        Me.txtTAABMUNI.AccessibleDescription = "Municipio"
        Me.txtTAABMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABMUNI.Location = New System.Drawing.Point(105, 46)
        Me.txtTAABMUNI.MaxLength = 9
        Me.txtTAABMUNI.Name = "txtTAABMUNI"
        Me.txtTAABMUNI.Size = New System.Drawing.Size(83, 20)
        Me.txtTAABMUNI.TabIndex = 2
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
        'txtTAABDEPA
        '
        Me.txtTAABDEPA.AccessibleDescription = "Departamento"
        Me.txtTAABDEPA.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABDEPA.Location = New System.Drawing.Point(19, 46)
        Me.txtTAABDEPA.MaxLength = 9
        Me.txtTAABDEPA.Name = "txtTAABDEPA"
        Me.txtTAABDEPA.Size = New System.Drawing.Size(83, 20)
        Me.txtTAABDEPA.TabIndex = 1
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
        'txtTAABESTA
        '
        Me.txtTAABESTA.AccessibleDescription = "Estado"
        Me.txtTAABESTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAABESTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtTAABESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAABESTA.Location = New System.Drawing.Point(707, 92)
        Me.txtTAABESTA.MaxLength = 9
        Me.txtTAABESTA.Name = "txtTAABESTA"
        Me.txtTAABESTA.Size = New System.Drawing.Size(83, 20)
        Me.txtTAABESTA.TabIndex = 17
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
        Me.dgvCONSULTA.Location = New System.Drawing.Point(19, 118)
        Me.dgvCONSULTA.MultiSelect = False
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        Me.dgvCONSULTA.RowHeadersVisible = False
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(771, 256)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(707, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Estado"
        '
        'frm_consultar_TARIACBO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 499)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraPERIODO)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(846, 535)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(846, 535)
        Me.Name = "frm_consultar_TARIACBO"
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
    Friend WithEvents txtTAABAVFI As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtTAABAVIN As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTAABTA05 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTAABTA04 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTAABTA03 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTAABTA02 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTAABTA01 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTAABESTR As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTAABTAIN As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTAABTACO As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTAABTIPO As System.Windows.Forms.TextBox
    Friend WithEvents lblVIACVIAC As System.Windows.Forms.Label
    Friend WithEvents txtTAABTARE As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTAABVIGE As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTAABCLSE As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTAABMUNI As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTAABDEPA As System.Windows.Forms.TextBox
    Friend WithEvents lblidzona As System.Windows.Forms.Label
    Friend WithEvents txtTAABESTA As System.Windows.Forms.TextBox
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
