<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_TARIZOFI
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdLimpiar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdConsultar = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraZONAECON = New System.Windows.Forms.GroupBox()
        Me.txtTAZFTA06 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTAZFTA05 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTAZFTA04 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTAZFTA03 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTAZFTA02 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTAZFTA01 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTAZFZOEC = New System.Windows.Forms.TextBox()
        Me.lblVIACVIAC = New System.Windows.Forms.Label()
        Me.txtTAZFZOAP = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTAZFVIGE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTAZFCLSE = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTAZFMUNI = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTAZFDEPA = New System.Windows.Forms.TextBox()
        Me.lblidzona = New System.Windows.Forms.Label()
        Me.txtTAZFESTA = New System.Windows.Forms.TextBox()
        Me.dgvCONSULTA = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraZONAECON.SuspendLayout()
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 417)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(636, 60)
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
        Me.cmdSalir.Location = New System.Drawing.Point(520, 20)
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
        Me.cmdAceptar.Location = New System.Drawing.Point(413, 20)
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
        Me.cmdConsultar.Location = New System.Drawing.Point(306, 20)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 489)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(663, 25)
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
        'fraZONAECON
        '
        Me.fraZONAECON.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraZONAECON.BackColor = System.Drawing.SystemColors.Control
        Me.fraZONAECON.Controls.Add(Me.txtTAZFTA06)
        Me.fraZONAECON.Controls.Add(Me.Label1)
        Me.fraZONAECON.Controls.Add(Me.txtTAZFTA05)
        Me.fraZONAECON.Controls.Add(Me.Label16)
        Me.fraZONAECON.Controls.Add(Me.txtTAZFTA04)
        Me.fraZONAECON.Controls.Add(Me.Label15)
        Me.fraZONAECON.Controls.Add(Me.txtTAZFTA03)
        Me.fraZONAECON.Controls.Add(Me.Label14)
        Me.fraZONAECON.Controls.Add(Me.txtTAZFTA02)
        Me.fraZONAECON.Controls.Add(Me.Label13)
        Me.fraZONAECON.Controls.Add(Me.txtTAZFTA01)
        Me.fraZONAECON.Controls.Add(Me.Label12)
        Me.fraZONAECON.Controls.Add(Me.txtTAZFZOEC)
        Me.fraZONAECON.Controls.Add(Me.lblVIACVIAC)
        Me.fraZONAECON.Controls.Add(Me.txtTAZFZOAP)
        Me.fraZONAECON.Controls.Add(Me.Label8)
        Me.fraZONAECON.Controls.Add(Me.txtTAZFVIGE)
        Me.fraZONAECON.Controls.Add(Me.Label6)
        Me.fraZONAECON.Controls.Add(Me.txtTAZFCLSE)
        Me.fraZONAECON.Controls.Add(Me.Label5)
        Me.fraZONAECON.Controls.Add(Me.txtTAZFMUNI)
        Me.fraZONAECON.Controls.Add(Me.Label3)
        Me.fraZONAECON.Controls.Add(Me.txtTAZFDEPA)
        Me.fraZONAECON.Controls.Add(Me.lblidzona)
        Me.fraZONAECON.Controls.Add(Me.txtTAZFESTA)
        Me.fraZONAECON.Controls.Add(Me.dgvCONSULTA)
        Me.fraZONAECON.Controls.Add(Me.Label2)
        Me.fraZONAECON.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraZONAECON.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraZONAECON.Location = New System.Drawing.Point(12, 9)
        Me.fraZONAECON.Name = "fraZONAECON"
        Me.fraZONAECON.Size = New System.Drawing.Size(637, 402)
        Me.fraZONAECON.TabIndex = 73
        Me.fraZONAECON.TabStop = False
        Me.fraZONAECON.Text = "TARIFA POR ZONA FÍSICA"
        '
        'txtTAZFTA06
        '
        Me.txtTAZFTA06.AccessibleDescription = "Tarifa 06"
        Me.txtTAZFTA06.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFTA06.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFTA06.Location = New System.Drawing.Point(449, 92)
        Me.txtTAZFTA06.MaxLength = 9
        Me.txtTAZFTA06.Name = "txtTAZFTA06"
        Me.txtTAZFTA06.Size = New System.Drawing.Size(83, 20)
        Me.txtTAZFTA06.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(449, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 20)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "Tarifa 06"
        '
        'txtTAZFTA05
        '
        Me.txtTAZFTA05.AccessibleDescription = "Tarifa 05"
        Me.txtTAZFTA05.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFTA05.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFTA05.Location = New System.Drawing.Point(363, 93)
        Me.txtTAZFTA05.MaxLength = 9
        Me.txtTAZFTA05.Name = "txtTAZFTA05"
        Me.txtTAZFTA05.Size = New System.Drawing.Size(83, 20)
        Me.txtTAZFTA05.TabIndex = 12
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(363, 70)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 20)
        Me.Label16.TabIndex = 76
        Me.Label16.Text = "Tarifa 05"
        '
        'txtTAZFTA04
        '
        Me.txtTAZFTA04.AccessibleDescription = "Tarifa 04"
        Me.txtTAZFTA04.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFTA04.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFTA04.Location = New System.Drawing.Point(277, 93)
        Me.txtTAZFTA04.MaxLength = 9
        Me.txtTAZFTA04.Name = "txtTAZFTA04"
        Me.txtTAZFTA04.Size = New System.Drawing.Size(83, 20)
        Me.txtTAZFTA04.TabIndex = 11
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(277, 70)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 20)
        Me.Label15.TabIndex = 74
        Me.Label15.Text = "Tarifa 04"
        '
        'txtTAZFTA03
        '
        Me.txtTAZFTA03.AccessibleDescription = "Tarifa 03"
        Me.txtTAZFTA03.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFTA03.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFTA03.Location = New System.Drawing.Point(191, 93)
        Me.txtTAZFTA03.MaxLength = 9
        Me.txtTAZFTA03.Name = "txtTAZFTA03"
        Me.txtTAZFTA03.Size = New System.Drawing.Size(83, 20)
        Me.txtTAZFTA03.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(191, 70)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 20)
        Me.Label14.TabIndex = 72
        Me.Label14.Text = "Tarifa 03"
        '
        'txtTAZFTA02
        '
        Me.txtTAZFTA02.AccessibleDescription = "Tarifa 02"
        Me.txtTAZFTA02.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFTA02.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFTA02.Location = New System.Drawing.Point(105, 93)
        Me.txtTAZFTA02.MaxLength = 9
        Me.txtTAZFTA02.Name = "txtTAZFTA02"
        Me.txtTAZFTA02.Size = New System.Drawing.Size(83, 20)
        Me.txtTAZFTA02.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(105, 70)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 20)
        Me.Label13.TabIndex = 70
        Me.Label13.Text = "Tarifa 02"
        '
        'txtTAZFTA01
        '
        Me.txtTAZFTA01.AccessibleDescription = "Tarifa 01"
        Me.txtTAZFTA01.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFTA01.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFTA01.Location = New System.Drawing.Point(19, 93)
        Me.txtTAZFTA01.MaxLength = 9
        Me.txtTAZFTA01.Name = "txtTAZFTA01"
        Me.txtTAZFTA01.Size = New System.Drawing.Size(83, 20)
        Me.txtTAZFTA01.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(19, 70)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 20)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "Tarifa 01"
        '
        'txtTAZFZOEC
        '
        Me.txtTAZFZOEC.AccessibleDescription = "Zona economica"
        Me.txtTAZFZOEC.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFZOEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFZOEC.Location = New System.Drawing.Point(363, 46)
        Me.txtTAZFZOEC.MaxLength = 9
        Me.txtTAZFZOEC.Name = "txtTAZFZOEC"
        Me.txtTAZFZOEC.Size = New System.Drawing.Size(83, 20)
        Me.txtTAZFZOEC.TabIndex = 5
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
        Me.lblVIACVIAC.Text = "Zona Econó."
        '
        'txtTAZFZOAP
        '
        Me.txtTAZFZOAP.AccessibleDescription = "Zona aplicada"
        Me.txtTAZFZOAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFZOAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFZOAP.Location = New System.Drawing.Point(449, 46)
        Me.txtTAZFZOAP.MaxLength = 9
        Me.txtTAZFZOAP.Name = "txtTAZFZOAP"
        Me.txtTAZFZOAP.Size = New System.Drawing.Size(83, 20)
        Me.txtTAZFZOAP.TabIndex = 6
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
        Me.Label8.Text = "Zona Aplicada"
        '
        'txtTAZFVIGE
        '
        Me.txtTAZFVIGE.AccessibleDescription = "Vigencia"
        Me.txtTAZFVIGE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFVIGE.Location = New System.Drawing.Point(277, 46)
        Me.txtTAZFVIGE.MaxLength = 9
        Me.txtTAZFVIGE.Name = "txtTAZFVIGE"
        Me.txtTAZFVIGE.Size = New System.Drawing.Size(83, 20)
        Me.txtTAZFVIGE.TabIndex = 4
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
        'txtTAZFCLSE
        '
        Me.txtTAZFCLSE.AccessibleDescription = "Sector"
        Me.txtTAZFCLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFCLSE.Location = New System.Drawing.Point(191, 46)
        Me.txtTAZFCLSE.MaxLength = 9
        Me.txtTAZFCLSE.Name = "txtTAZFCLSE"
        Me.txtTAZFCLSE.Size = New System.Drawing.Size(83, 20)
        Me.txtTAZFCLSE.TabIndex = 3
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
        'txtTAZFMUNI
        '
        Me.txtTAZFMUNI.AccessibleDescription = "Municipio"
        Me.txtTAZFMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFMUNI.Location = New System.Drawing.Point(105, 46)
        Me.txtTAZFMUNI.MaxLength = 9
        Me.txtTAZFMUNI.Name = "txtTAZFMUNI"
        Me.txtTAZFMUNI.Size = New System.Drawing.Size(83, 20)
        Me.txtTAZFMUNI.TabIndex = 2
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
        'txtTAZFDEPA
        '
        Me.txtTAZFDEPA.AccessibleDescription = "Departamento"
        Me.txtTAZFDEPA.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFDEPA.Location = New System.Drawing.Point(19, 46)
        Me.txtTAZFDEPA.MaxLength = 9
        Me.txtTAZFDEPA.Name = "txtTAZFDEPA"
        Me.txtTAZFDEPA.Size = New System.Drawing.Size(83, 20)
        Me.txtTAZFDEPA.TabIndex = 1
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
        'txtTAZFESTA
        '
        Me.txtTAZFESTA.AccessibleDescription = "Estado"
        Me.txtTAZFESTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFESTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtTAZFESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFESTA.Location = New System.Drawing.Point(535, 46)
        Me.txtTAZFESTA.MaxLength = 9
        Me.txtTAZFESTA.Name = "txtTAZFESTA"
        Me.txtTAZFESTA.Size = New System.Drawing.Size(83, 20)
        Me.txtTAZFESTA.TabIndex = 7
        '
        'dgvCONSULTA
        '
        Me.dgvCONSULTA.AccessibleDescription = ""
        Me.dgvCONSULTA.AllowUserToAddRows = False
        Me.dgvCONSULTA.AllowUserToDeleteRows = False
        Me.dgvCONSULTA.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
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
        Me.dgvCONSULTA.Location = New System.Drawing.Point(19, 127)
        Me.dgvCONSULTA.MultiSelect = False
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        Me.dgvCONSULTA.RowHeadersVisible = False
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(601, 259)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(535, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Estado"
        '
        'frm_consultar_TARIZOFI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 514)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraZONAECON)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(679, 550)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(679, 550)
        Me.Name = "frm_consultar_TARIZOFI"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraZONAECON.ResumeLayout(False)
        Me.fraZONAECON.PerformLayout()
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
    Friend WithEvents fraZONAECON As System.Windows.Forms.GroupBox
    Friend WithEvents txtTAZFTA06 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTAZFTA05 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTAZFTA04 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTAZFTA03 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTAZFTA02 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTAZFTA01 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTAZFZOEC As System.Windows.Forms.TextBox
    Friend WithEvents lblVIACVIAC As System.Windows.Forms.Label
    Friend WithEvents txtTAZFZOAP As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTAZFVIGE As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTAZFCLSE As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTAZFMUNI As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTAZFDEPA As System.Windows.Forms.TextBox
    Friend WithEvents lblidzona As System.Windows.Forms.Label
    Friend WithEvents txtTAZFESTA As System.Windows.Forms.TextBox
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
