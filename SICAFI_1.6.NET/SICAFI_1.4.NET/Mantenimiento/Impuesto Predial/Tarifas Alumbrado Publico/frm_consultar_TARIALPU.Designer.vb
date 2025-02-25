<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_TARIALPU
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
        Me.txtTAAPAVFI = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtTAAPAVIN = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtTAAPTA05 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtTAAPTA04 = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtTAAPTA03 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtTAAPTA02 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtTAAPTA01 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtTAAPESTR = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtTAAPTAIN = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTAAPTACO = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTAAPTIPO = New System.Windows.Forms.TextBox
        Me.lblVIACVIAC = New System.Windows.Forms.Label
        Me.txtTAAPTARE = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtTAAPVIGE = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTAAPCLSE = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTAAPMUNI = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTAAPDEPA = New System.Windows.Forms.TextBox
        Me.lblidzona = New System.Windows.Forms.Label
        Me.txtTAAPESTA = New System.Windows.Forms.TextBox
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 396)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(805, 60)
        Me.GroupBox1.TabIndex = 68
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
        Me.strBARRESTA.TabIndex = 69
        '
        'tstBAESVALI
        '
        Me.tstBAESVALI.AutoSize = False
        Me.tstBAESVALI.BackColor = System.Drawing.Color.White
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
        Me.tstBAESDESC.BackColor = System.Drawing.Color.White
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
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.White
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
        Me.fraPERIODO.Controls.Add(Me.txtTAAPAVFI)
        Me.fraPERIODO.Controls.Add(Me.Label18)
        Me.fraPERIODO.Controls.Add(Me.txtTAAPAVIN)
        Me.fraPERIODO.Controls.Add(Me.Label17)
        Me.fraPERIODO.Controls.Add(Me.txtTAAPTA05)
        Me.fraPERIODO.Controls.Add(Me.Label16)
        Me.fraPERIODO.Controls.Add(Me.txtTAAPTA04)
        Me.fraPERIODO.Controls.Add(Me.Label15)
        Me.fraPERIODO.Controls.Add(Me.txtTAAPTA03)
        Me.fraPERIODO.Controls.Add(Me.Label14)
        Me.fraPERIODO.Controls.Add(Me.txtTAAPTA02)
        Me.fraPERIODO.Controls.Add(Me.Label13)
        Me.fraPERIODO.Controls.Add(Me.txtTAAPTA01)
        Me.fraPERIODO.Controls.Add(Me.Label12)
        Me.fraPERIODO.Controls.Add(Me.txtTAAPESTR)
        Me.fraPERIODO.Controls.Add(Me.Label11)
        Me.fraPERIODO.Controls.Add(Me.txtTAAPTAIN)
        Me.fraPERIODO.Controls.Add(Me.Label10)
        Me.fraPERIODO.Controls.Add(Me.txtTAAPTACO)
        Me.fraPERIODO.Controls.Add(Me.Label9)
        Me.fraPERIODO.Controls.Add(Me.txtTAAPTIPO)
        Me.fraPERIODO.Controls.Add(Me.lblVIACVIAC)
        Me.fraPERIODO.Controls.Add(Me.txtTAAPTARE)
        Me.fraPERIODO.Controls.Add(Me.Label8)
        Me.fraPERIODO.Controls.Add(Me.txtTAAPVIGE)
        Me.fraPERIODO.Controls.Add(Me.Label6)
        Me.fraPERIODO.Controls.Add(Me.txtTAAPCLSE)
        Me.fraPERIODO.Controls.Add(Me.Label5)
        Me.fraPERIODO.Controls.Add(Me.txtTAAPMUNI)
        Me.fraPERIODO.Controls.Add(Me.Label3)
        Me.fraPERIODO.Controls.Add(Me.txtTAAPDEPA)
        Me.fraPERIODO.Controls.Add(Me.lblidzona)
        Me.fraPERIODO.Controls.Add(Me.txtTAAPESTA)
        Me.fraPERIODO.Controls.Add(Me.dgvCONSULTA)
        Me.fraPERIODO.Controls.Add(Me.Label2)
        Me.fraPERIODO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPERIODO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPERIODO.Location = New System.Drawing.Point(12, 3)
        Me.fraPERIODO.Name = "fraPERIODO"
        Me.fraPERIODO.Size = New System.Drawing.Size(805, 390)
        Me.fraPERIODO.TabIndex = 67
        Me.fraPERIODO.TabStop = False
        Me.fraPERIODO.Text = "TARIFA ALUMBRADO PUBLICO"
        '
        'txtTAAPAVFI
        '
        Me.txtTAAPAVFI.AccessibleDescription = "Avalúo final"
        Me.txtTAAPAVFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPAVFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPAVFI.Location = New System.Drawing.Point(580, 92)
        Me.txtTAAPAVFI.MaxLength = 9
        Me.txtTAAPAVFI.Name = "txtTAAPAVFI"
        Me.txtTAAPAVFI.Size = New System.Drawing.Size(124, 20)
        Me.txtTAAPAVFI.TabIndex = 16
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
        'txtTAAPAVIN
        '
        Me.txtTAAPAVIN.AccessibleDescription = "Avalúo inicial"
        Me.txtTAAPAVIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPAVIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPAVIN.Location = New System.Drawing.Point(449, 92)
        Me.txtTAAPAVIN.MaxLength = 9
        Me.txtTAAPAVIN.Name = "txtTAAPAVIN"
        Me.txtTAAPAVIN.Size = New System.Drawing.Size(127, 20)
        Me.txtTAAPAVIN.TabIndex = 15
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
        'txtTAAPTA05
        '
        Me.txtTAAPTA05.AccessibleDescription = "Tarifa 05"
        Me.txtTAAPTA05.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPTA05.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPTA05.Location = New System.Drawing.Point(363, 92)
        Me.txtTAAPTA05.MaxLength = 9
        Me.txtTAAPTA05.Name = "txtTAAPTA05"
        Me.txtTAAPTA05.Size = New System.Drawing.Size(83, 20)
        Me.txtTAAPTA05.TabIndex = 14
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
        'txtTAAPTA04
        '
        Me.txtTAAPTA04.AccessibleDescription = "Tarifa 04"
        Me.txtTAAPTA04.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPTA04.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPTA04.Location = New System.Drawing.Point(277, 92)
        Me.txtTAAPTA04.MaxLength = 9
        Me.txtTAAPTA04.Name = "txtTAAPTA04"
        Me.txtTAAPTA04.Size = New System.Drawing.Size(83, 20)
        Me.txtTAAPTA04.TabIndex = 13
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
        'txtTAAPTA03
        '
        Me.txtTAAPTA03.AccessibleDescription = "Tarifa 03"
        Me.txtTAAPTA03.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPTA03.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPTA03.Location = New System.Drawing.Point(191, 92)
        Me.txtTAAPTA03.MaxLength = 9
        Me.txtTAAPTA03.Name = "txtTAAPTA03"
        Me.txtTAAPTA03.Size = New System.Drawing.Size(83, 20)
        Me.txtTAAPTA03.TabIndex = 12
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
        'txtTAAPTA02
        '
        Me.txtTAAPTA02.AccessibleDescription = "Tarifa 02"
        Me.txtTAAPTA02.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPTA02.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPTA02.Location = New System.Drawing.Point(105, 92)
        Me.txtTAAPTA02.MaxLength = 9
        Me.txtTAAPTA02.Name = "txtTAAPTA02"
        Me.txtTAAPTA02.Size = New System.Drawing.Size(83, 20)
        Me.txtTAAPTA02.TabIndex = 11
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
        'txtTAAPTA01
        '
        Me.txtTAAPTA01.AccessibleDescription = "Tarifa 01"
        Me.txtTAAPTA01.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPTA01.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPTA01.Location = New System.Drawing.Point(19, 92)
        Me.txtTAAPTA01.MaxLength = 9
        Me.txtTAAPTA01.Name = "txtTAAPTA01"
        Me.txtTAAPTA01.Size = New System.Drawing.Size(83, 20)
        Me.txtTAAPTA01.TabIndex = 10
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
        'txtTAAPESTR
        '
        Me.txtTAAPESTR.AccessibleDescription = "Estrato"
        Me.txtTAAPESTR.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPESTR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPESTR.Location = New System.Drawing.Point(707, 46)
        Me.txtTAAPESTR.MaxLength = 9
        Me.txtTAAPESTR.Name = "txtTAAPESTR"
        Me.txtTAAPESTR.Size = New System.Drawing.Size(83, 20)
        Me.txtTAAPESTR.TabIndex = 9
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
        'txtTAAPTAIN
        '
        Me.txtTAAPTAIN.AccessibleDescription = "Tarifa industrial"
        Me.txtTAAPTAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPTAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPTAIN.Location = New System.Drawing.Point(621, 46)
        Me.txtTAAPTAIN.MaxLength = 9
        Me.txtTAAPTAIN.Name = "txtTAAPTAIN"
        Me.txtTAAPTAIN.Size = New System.Drawing.Size(83, 20)
        Me.txtTAAPTAIN.TabIndex = 8
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
        'txtTAAPTACO
        '
        Me.txtTAAPTACO.AccessibleDescription = "Tarifa comercial"
        Me.txtTAAPTACO.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPTACO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPTACO.Location = New System.Drawing.Point(535, 46)
        Me.txtTAAPTACO.MaxLength = 9
        Me.txtTAAPTACO.Name = "txtTAAPTACO"
        Me.txtTAAPTACO.Size = New System.Drawing.Size(83, 20)
        Me.txtTAAPTACO.TabIndex = 7
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
        'txtTAAPTIPO
        '
        Me.txtTAAPTIPO.AccessibleDescription = "Tipo calificación"
        Me.txtTAAPTIPO.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPTIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPTIPO.Location = New System.Drawing.Point(363, 46)
        Me.txtTAAPTIPO.MaxLength = 9
        Me.txtTAAPTIPO.Name = "txtTAAPTIPO"
        Me.txtTAAPTIPO.Size = New System.Drawing.Size(83, 20)
        Me.txtTAAPTIPO.TabIndex = 5
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
        'txtTAAPTARE
        '
        Me.txtTAAPTARE.AccessibleDescription = "Tarifa residencial"
        Me.txtTAAPTARE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPTARE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPTARE.Location = New System.Drawing.Point(449, 46)
        Me.txtTAAPTARE.MaxLength = 9
        Me.txtTAAPTARE.Name = "txtTAAPTARE"
        Me.txtTAAPTARE.Size = New System.Drawing.Size(83, 20)
        Me.txtTAAPTARE.TabIndex = 6
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
        'txtTAAPVIGE
        '
        Me.txtTAAPVIGE.AccessibleDescription = "Vigencia"
        Me.txtTAAPVIGE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPVIGE.Location = New System.Drawing.Point(277, 46)
        Me.txtTAAPVIGE.MaxLength = 9
        Me.txtTAAPVIGE.Name = "txtTAAPVIGE"
        Me.txtTAAPVIGE.Size = New System.Drawing.Size(83, 20)
        Me.txtTAAPVIGE.TabIndex = 4
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
        'txtTAAPCLSE
        '
        Me.txtTAAPCLSE.AccessibleDescription = "Sector"
        Me.txtTAAPCLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPCLSE.Location = New System.Drawing.Point(191, 46)
        Me.txtTAAPCLSE.MaxLength = 9
        Me.txtTAAPCLSE.Name = "txtTAAPCLSE"
        Me.txtTAAPCLSE.Size = New System.Drawing.Size(83, 20)
        Me.txtTAAPCLSE.TabIndex = 3
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
        'txtTAAPMUNI
        '
        Me.txtTAAPMUNI.AccessibleDescription = "Municipio"
        Me.txtTAAPMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPMUNI.Location = New System.Drawing.Point(105, 46)
        Me.txtTAAPMUNI.MaxLength = 9
        Me.txtTAAPMUNI.Name = "txtTAAPMUNI"
        Me.txtTAAPMUNI.Size = New System.Drawing.Size(83, 20)
        Me.txtTAAPMUNI.TabIndex = 2
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
        'txtTAAPDEPA
        '
        Me.txtTAAPDEPA.AccessibleDescription = "Departamento"
        Me.txtTAAPDEPA.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPDEPA.Location = New System.Drawing.Point(19, 46)
        Me.txtTAAPDEPA.MaxLength = 9
        Me.txtTAAPDEPA.Name = "txtTAAPDEPA"
        Me.txtTAAPDEPA.Size = New System.Drawing.Size(83, 20)
        Me.txtTAAPDEPA.TabIndex = 1
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
        'txtTAAPESTA
        '
        Me.txtTAAPESTA.AccessibleDescription = "Estado"
        Me.txtTAAPESTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAAPESTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtTAAPESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAAPESTA.Location = New System.Drawing.Point(707, 92)
        Me.txtTAAPESTA.MaxLength = 9
        Me.txtTAAPESTA.Name = "txtTAAPESTA"
        Me.txtTAAPESTA.Size = New System.Drawing.Size(83, 20)
        Me.txtTAAPESTA.TabIndex = 17
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
        'frm_consultar_TARIALPU
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
        Me.Name = "frm_consultar_TARIALPU"
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
    Friend WithEvents txtTAAPTIPO As System.Windows.Forms.TextBox
    Friend WithEvents lblVIACVIAC As System.Windows.Forms.Label
    Friend WithEvents txtTAAPTARE As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPVIGE As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPCLSE As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPMUNI As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPDEPA As System.Windows.Forms.TextBox
    Friend WithEvents lblidzona As System.Windows.Forms.Label
    Friend WithEvents txtTAAPESTA As System.Windows.Forms.TextBox
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPTAIN As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPTACO As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPESTR As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPTA05 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPTA04 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPTA03 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPTA02 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPTA01 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPAVFI As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtTAAPAVIN As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
