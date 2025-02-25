<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_PROYECTO
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
        Me.fraPROYECTO = New System.Windows.Forms.GroupBox()
        Me.lblPROYDEPA = New System.Windows.Forms.Label()
        Me.cboPROYDEPA = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblPROYMUNI = New System.Windows.Forms.Label()
        Me.cboPROYMUNI = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblPROYCLSE = New System.Windows.Forms.Label()
        Me.cboPROYCLSE = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboPROYESTA = New System.Windows.Forms.ComboBox()
        Me.txtPROYDESC = New System.Windows.Forms.TextBox()
        Me.txtPROYCODI = New System.Windows.Forms.TextBox()
        Me.lblCódigo = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabAlcance = New System.Windows.Forms.TabPage()
        Me.txtPROYALCA = New System.Windows.Forms.TextBox()
        Me.tabRecursos = New System.Windows.Forms.TabPage()
        Me.txtPROYRECU = New System.Windows.Forms.TextBox()
        Me.tabJustificacion = New System.Windows.Forms.TabPage()
        Me.txtPROYJUST = New System.Windows.Forms.TextBox()
        Me.tabObjetivos = New System.Windows.Forms.TabPage()
        Me.txtPROYOBJE = New System.Windows.Forms.TextBox()
        Me.tabFinalidad = New System.Windows.Forms.TabPage()
        Me.txtPROYFINA = New System.Windows.Forms.TextBox()
        Me.tabObservaciones = New System.Windows.Forms.TabPage()
        Me.txtPROYOBSE = New System.Windows.Forms.TextBox()
        Me.tabConvenios = New System.Windows.Forms.TabPage()
        Me.txtPROYCONV = New System.Windows.Forms.TextBox()
        Me.tabCompromisos = New System.Windows.Forms.TabPage()
        Me.txtPROYCOMP = New System.Windows.Forms.TextBox()
        Me.tabNormatividad = New System.Windows.Forms.TabPage()
        Me.txtPROYNORM = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraPROYECTO.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabAlcance.SuspendLayout()
        Me.tabRecursos.SuspendLayout()
        Me.tabJustificacion.SuspendLayout()
        Me.tabObjetivos.SuspendLayout()
        Me.tabFinalidad.SuspendLayout()
        Me.tabObservaciones.SuspendLayout()
        Me.tabConvenios.SuspendLayout()
        Me.tabCompromisos.SuspendLayout()
        Me.tabNormatividad.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 356)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(600, 53)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(302, 19)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 5
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(195, 19)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 4
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 432)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(624, 25)
        Me.strBARRESTA.TabIndex = 38
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
        'fraPROYECTO
        '
        Me.fraPROYECTO.BackColor = System.Drawing.SystemColors.Control
        Me.fraPROYECTO.Controls.Add(Me.lblPROYDEPA)
        Me.fraPROYECTO.Controls.Add(Me.cboPROYDEPA)
        Me.fraPROYECTO.Controls.Add(Me.Label7)
        Me.fraPROYECTO.Controls.Add(Me.lblPROYMUNI)
        Me.fraPROYECTO.Controls.Add(Me.cboPROYMUNI)
        Me.fraPROYECTO.Controls.Add(Me.Label10)
        Me.fraPROYECTO.Controls.Add(Me.lblPROYCLSE)
        Me.fraPROYECTO.Controls.Add(Me.cboPROYCLSE)
        Me.fraPROYECTO.Controls.Add(Me.Label8)
        Me.fraPROYECTO.Controls.Add(Me.Label3)
        Me.fraPROYECTO.Controls.Add(Me.Label5)
        Me.fraPROYECTO.Controls.Add(Me.cboPROYESTA)
        Me.fraPROYECTO.Controls.Add(Me.txtPROYDESC)
        Me.fraPROYECTO.Controls.Add(Me.txtPROYCODI)
        Me.fraPROYECTO.Controls.Add(Me.lblCódigo)
        Me.fraPROYECTO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPROYECTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPROYECTO.Location = New System.Drawing.Point(12, 12)
        Me.fraPROYECTO.Name = "fraPROYECTO"
        Me.fraPROYECTO.Size = New System.Drawing.Size(600, 186)
        Me.fraPROYECTO.TabIndex = 37
        Me.fraPROYECTO.TabStop = False
        Me.fraPROYECTO.Text = "MODIFICAR PROYECTO"
        '
        'lblPROYDEPA
        '
        Me.lblPROYDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPROYDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPROYDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPROYDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblPROYDEPA.Location = New System.Drawing.Point(453, 28)
        Me.lblPROYDEPA.Name = "lblPROYDEPA"
        Me.lblPROYDEPA.Size = New System.Drawing.Size(124, 20)
        Me.lblPROYDEPA.TabIndex = 95
        '
        'cboPROYDEPA
        '
        Me.cboPROYDEPA.AccessibleDescription = "Departamento"
        Me.cboPROYDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPROYDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPROYDEPA.Enabled = False
        Me.cboPROYDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPROYDEPA.FormattingEnabled = True
        Me.cboPROYDEPA.Location = New System.Drawing.Point(156, 26)
        Me.cboPROYDEPA.Name = "cboPROYDEPA"
        Me.cboPROYDEPA.Size = New System.Drawing.Size(291, 22)
        Me.cboPROYDEPA.TabIndex = 81
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(22, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(130, 20)
        Me.Label7.TabIndex = 94
        Me.Label7.Text = "Departamento"
        '
        'lblPROYMUNI
        '
        Me.lblPROYMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPROYMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPROYMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPROYMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblPROYMUNI.Location = New System.Drawing.Point(453, 52)
        Me.lblPROYMUNI.Name = "lblPROYMUNI"
        Me.lblPROYMUNI.Size = New System.Drawing.Size(124, 20)
        Me.lblPROYMUNI.TabIndex = 93
        '
        'cboPROYMUNI
        '
        Me.cboPROYMUNI.AccessibleDescription = "Municipio"
        Me.cboPROYMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPROYMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPROYMUNI.Enabled = False
        Me.cboPROYMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPROYMUNI.FormattingEnabled = True
        Me.cboPROYMUNI.Location = New System.Drawing.Point(156, 50)
        Me.cboPROYMUNI.Name = "cboPROYMUNI"
        Me.cboPROYMUNI.Size = New System.Drawing.Size(291, 22)
        Me.cboPROYMUNI.TabIndex = 82
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(22, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(130, 20)
        Me.Label10.TabIndex = 92
        Me.Label10.Text = "Municipio"
        '
        'lblPROYCLSE
        '
        Me.lblPROYCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPROYCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPROYCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPROYCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblPROYCLSE.Location = New System.Drawing.Point(453, 75)
        Me.lblPROYCLSE.Name = "lblPROYCLSE"
        Me.lblPROYCLSE.Size = New System.Drawing.Size(124, 20)
        Me.lblPROYCLSE.TabIndex = 91
        '
        'cboPROYCLSE
        '
        Me.cboPROYCLSE.AccessibleDescription = "Clase o sector"
        Me.cboPROYCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPROYCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPROYCLSE.Enabled = False
        Me.cboPROYCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPROYCLSE.FormattingEnabled = True
        Me.cboPROYCLSE.Location = New System.Drawing.Point(156, 73)
        Me.cboPROYCLSE.Name = "cboPROYCLSE"
        Me.cboPROYCLSE.Size = New System.Drawing.Size(291, 22)
        Me.cboPROYCLSE.TabIndex = 83
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(22, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 20)
        Me.Label8.TabIndex = 90
        Me.Label8.Text = "Clase o sector"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(22, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 20)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "Descripción"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(22, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 20)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "Código"
        '
        'cboPROYESTA
        '
        Me.cboPROYESTA.AccessibleDescription = "Estado"
        Me.cboPROYESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPROYESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPROYESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPROYESTA.FormattingEnabled = True
        Me.cboPROYESTA.Location = New System.Drawing.Point(156, 142)
        Me.cboPROYESTA.Name = "cboPROYESTA"
        Me.cboPROYESTA.Size = New System.Drawing.Size(291, 22)
        Me.cboPROYESTA.TabIndex = 86
        '
        'txtPROYDESC
        '
        Me.txtPROYDESC.AccessibleDescription = "Descripción"
        Me.txtPROYDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtPROYDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPROYDESC.Location = New System.Drawing.Point(156, 121)
        Me.txtPROYDESC.MaxLength = 100
        Me.txtPROYDESC.Name = "txtPROYDESC"
        Me.txtPROYDESC.Size = New System.Drawing.Size(421, 20)
        Me.txtPROYDESC.TabIndex = 85
        '
        'txtPROYCODI
        '
        Me.txtPROYCODI.AccessibleDescription = "Código"
        Me.txtPROYCODI.BackColor = System.Drawing.SystemColors.Window
        Me.txtPROYCODI.Enabled = False
        Me.txtPROYCODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPROYCODI.Location = New System.Drawing.Point(156, 98)
        Me.txtPROYCODI.MaxLength = 9
        Me.txtPROYCODI.Name = "txtPROYCODI"
        Me.txtPROYCODI.Size = New System.Drawing.Size(152, 20)
        Me.txtPROYCODI.TabIndex = 84
        '
        'lblCódigo
        '
        Me.lblCódigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCódigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCódigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCódigo.ForeColor = System.Drawing.Color.Black
        Me.lblCódigo.Location = New System.Drawing.Point(22, 144)
        Me.lblCódigo.Name = "lblCódigo"
        Me.lblCódigo.Size = New System.Drawing.Size(130, 20)
        Me.lblCódigo.TabIndex = 87
        Me.lblCódigo.Text = "Código"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabAlcance)
        Me.TabControl1.Controls.Add(Me.tabRecursos)
        Me.TabControl1.Controls.Add(Me.tabJustificacion)
        Me.TabControl1.Controls.Add(Me.tabObjetivos)
        Me.TabControl1.Controls.Add(Me.tabFinalidad)
        Me.TabControl1.Controls.Add(Me.tabObservaciones)
        Me.TabControl1.Controls.Add(Me.tabConvenios)
        Me.TabControl1.Controls.Add(Me.tabCompromisos)
        Me.TabControl1.Controls.Add(Me.tabNormatividad)
        Me.TabControl1.Location = New System.Drawing.Point(12, 204)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(600, 146)
        Me.TabControl1.TabIndex = 72
        '
        'tabAlcance
        '
        Me.tabAlcance.BackColor = System.Drawing.SystemColors.Control
        Me.tabAlcance.Controls.Add(Me.txtPROYALCA)
        Me.tabAlcance.Location = New System.Drawing.Point(4, 22)
        Me.tabAlcance.Name = "tabAlcance"
        Me.tabAlcance.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAlcance.Size = New System.Drawing.Size(592, 120)
        Me.tabAlcance.TabIndex = 0
        Me.tabAlcance.Text = "Alcance"
        '
        'txtPROYALCA
        '
        Me.txtPROYALCA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPROYALCA.Location = New System.Drawing.Point(8, 6)
        Me.txtPROYALCA.MaxLength = 5000
        Me.txtPROYALCA.Multiline = True
        Me.txtPROYALCA.Name = "txtPROYALCA"
        Me.txtPROYALCA.Size = New System.Drawing.Size(578, 108)
        Me.txtPROYALCA.TabIndex = 0
        '
        'tabRecursos
        '
        Me.tabRecursos.BackColor = System.Drawing.SystemColors.Control
        Me.tabRecursos.Controls.Add(Me.txtPROYRECU)
        Me.tabRecursos.Location = New System.Drawing.Point(4, 22)
        Me.tabRecursos.Name = "tabRecursos"
        Me.tabRecursos.Padding = New System.Windows.Forms.Padding(3)
        Me.tabRecursos.Size = New System.Drawing.Size(592, 120)
        Me.tabRecursos.TabIndex = 1
        Me.tabRecursos.Text = "Recursos"
        '
        'txtPROYRECU
        '
        Me.txtPROYRECU.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPROYRECU.Location = New System.Drawing.Point(7, 6)
        Me.txtPROYRECU.MaxLength = 5000
        Me.txtPROYRECU.Multiline = True
        Me.txtPROYRECU.Name = "txtPROYRECU"
        Me.txtPROYRECU.Size = New System.Drawing.Size(579, 108)
        Me.txtPROYRECU.TabIndex = 1
        '
        'tabJustificacion
        '
        Me.tabJustificacion.Controls.Add(Me.txtPROYJUST)
        Me.tabJustificacion.Location = New System.Drawing.Point(4, 22)
        Me.tabJustificacion.Name = "tabJustificacion"
        Me.tabJustificacion.Size = New System.Drawing.Size(592, 120)
        Me.tabJustificacion.TabIndex = 2
        Me.tabJustificacion.Text = "Justificación"
        Me.tabJustificacion.UseVisualStyleBackColor = True
        '
        'txtPROYJUST
        '
        Me.txtPROYJUST.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPROYJUST.Location = New System.Drawing.Point(7, 6)
        Me.txtPROYJUST.MaxLength = 5000
        Me.txtPROYJUST.Multiline = True
        Me.txtPROYJUST.Name = "txtPROYJUST"
        Me.txtPROYJUST.Size = New System.Drawing.Size(579, 108)
        Me.txtPROYJUST.TabIndex = 1
        '
        'tabObjetivos
        '
        Me.tabObjetivos.Controls.Add(Me.txtPROYOBJE)
        Me.tabObjetivos.Location = New System.Drawing.Point(4, 22)
        Me.tabObjetivos.Name = "tabObjetivos"
        Me.tabObjetivos.Size = New System.Drawing.Size(592, 120)
        Me.tabObjetivos.TabIndex = 3
        Me.tabObjetivos.Text = "Objetivos"
        Me.tabObjetivos.UseVisualStyleBackColor = True
        '
        'txtPROYOBJE
        '
        Me.txtPROYOBJE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPROYOBJE.Location = New System.Drawing.Point(7, 6)
        Me.txtPROYOBJE.MaxLength = 5000
        Me.txtPROYOBJE.Multiline = True
        Me.txtPROYOBJE.Name = "txtPROYOBJE"
        Me.txtPROYOBJE.Size = New System.Drawing.Size(579, 108)
        Me.txtPROYOBJE.TabIndex = 1
        '
        'tabFinalidad
        '
        Me.tabFinalidad.Controls.Add(Me.txtPROYFINA)
        Me.tabFinalidad.Location = New System.Drawing.Point(4, 22)
        Me.tabFinalidad.Name = "tabFinalidad"
        Me.tabFinalidad.Size = New System.Drawing.Size(592, 120)
        Me.tabFinalidad.TabIndex = 4
        Me.tabFinalidad.Text = "Finalidad"
        Me.tabFinalidad.UseVisualStyleBackColor = True
        '
        'txtPROYFINA
        '
        Me.txtPROYFINA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPROYFINA.Location = New System.Drawing.Point(7, 6)
        Me.txtPROYFINA.MaxLength = 5000
        Me.txtPROYFINA.Multiline = True
        Me.txtPROYFINA.Name = "txtPROYFINA"
        Me.txtPROYFINA.Size = New System.Drawing.Size(579, 108)
        Me.txtPROYFINA.TabIndex = 1
        '
        'tabObservaciones
        '
        Me.tabObservaciones.Controls.Add(Me.txtPROYOBSE)
        Me.tabObservaciones.Location = New System.Drawing.Point(4, 22)
        Me.tabObservaciones.Name = "tabObservaciones"
        Me.tabObservaciones.Size = New System.Drawing.Size(592, 120)
        Me.tabObservaciones.TabIndex = 5
        Me.tabObservaciones.Text = "Observaciones"
        Me.tabObservaciones.UseVisualStyleBackColor = True
        '
        'txtPROYOBSE
        '
        Me.txtPROYOBSE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPROYOBSE.Location = New System.Drawing.Point(7, 6)
        Me.txtPROYOBSE.MaxLength = 5000
        Me.txtPROYOBSE.Multiline = True
        Me.txtPROYOBSE.Name = "txtPROYOBSE"
        Me.txtPROYOBSE.Size = New System.Drawing.Size(579, 108)
        Me.txtPROYOBSE.TabIndex = 1
        '
        'tabConvenios
        '
        Me.tabConvenios.Controls.Add(Me.txtPROYCONV)
        Me.tabConvenios.Location = New System.Drawing.Point(4, 22)
        Me.tabConvenios.Name = "tabConvenios"
        Me.tabConvenios.Size = New System.Drawing.Size(592, 120)
        Me.tabConvenios.TabIndex = 6
        Me.tabConvenios.Text = "Convenios"
        Me.tabConvenios.UseVisualStyleBackColor = True
        '
        'txtPROYCONV
        '
        Me.txtPROYCONV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPROYCONV.Location = New System.Drawing.Point(7, 6)
        Me.txtPROYCONV.MaxLength = 5000
        Me.txtPROYCONV.Multiline = True
        Me.txtPROYCONV.Name = "txtPROYCONV"
        Me.txtPROYCONV.Size = New System.Drawing.Size(579, 108)
        Me.txtPROYCONV.TabIndex = 1
        '
        'tabCompromisos
        '
        Me.tabCompromisos.Controls.Add(Me.txtPROYCOMP)
        Me.tabCompromisos.Location = New System.Drawing.Point(4, 22)
        Me.tabCompromisos.Name = "tabCompromisos"
        Me.tabCompromisos.Size = New System.Drawing.Size(592, 120)
        Me.tabCompromisos.TabIndex = 7
        Me.tabCompromisos.Text = "Compromisos"
        Me.tabCompromisos.UseVisualStyleBackColor = True
        '
        'txtPROYCOMP
        '
        Me.txtPROYCOMP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPROYCOMP.Location = New System.Drawing.Point(7, 6)
        Me.txtPROYCOMP.MaxLength = 5000
        Me.txtPROYCOMP.Multiline = True
        Me.txtPROYCOMP.Name = "txtPROYCOMP"
        Me.txtPROYCOMP.Size = New System.Drawing.Size(579, 108)
        Me.txtPROYCOMP.TabIndex = 1
        '
        'tabNormatividad
        '
        Me.tabNormatividad.Controls.Add(Me.txtPROYNORM)
        Me.tabNormatividad.Location = New System.Drawing.Point(4, 22)
        Me.tabNormatividad.Name = "tabNormatividad"
        Me.tabNormatividad.Size = New System.Drawing.Size(592, 120)
        Me.tabNormatividad.TabIndex = 8
        Me.tabNormatividad.Text = "Normatividad"
        Me.tabNormatividad.UseVisualStyleBackColor = True
        '
        'txtPROYNORM
        '
        Me.txtPROYNORM.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPROYNORM.Location = New System.Drawing.Point(7, 6)
        Me.txtPROYNORM.MaxLength = 5000
        Me.txtPROYNORM.Multiline = True
        Me.txtPROYNORM.Name = "txtPROYNORM"
        Me.txtPROYNORM.Size = New System.Drawing.Size(579, 108)
        Me.txtPROYNORM.TabIndex = 1
        '
        'frm_modificar_PROYECTO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 457)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraPROYECTO)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(640, 493)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(640, 493)
        Me.Name = "frm_modificar_PROYECTO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraPROYECTO.ResumeLayout(False)
        Me.fraPROYECTO.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabAlcance.ResumeLayout(False)
        Me.tabAlcance.PerformLayout()
        Me.tabRecursos.ResumeLayout(False)
        Me.tabRecursos.PerformLayout()
        Me.tabJustificacion.ResumeLayout(False)
        Me.tabJustificacion.PerformLayout()
        Me.tabObjetivos.ResumeLayout(False)
        Me.tabObjetivos.PerformLayout()
        Me.tabFinalidad.ResumeLayout(False)
        Me.tabFinalidad.PerformLayout()
        Me.tabObservaciones.ResumeLayout(False)
        Me.tabObservaciones.PerformLayout()
        Me.tabConvenios.ResumeLayout(False)
        Me.tabConvenios.PerformLayout()
        Me.tabCompromisos.ResumeLayout(False)
        Me.tabCompromisos.PerformLayout()
        Me.tabNormatividad.ResumeLayout(False)
        Me.tabNormatividad.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraPROYECTO As System.Windows.Forms.GroupBox
    Friend WithEvents lblPROYDEPA As System.Windows.Forms.Label
    Friend WithEvents cboPROYDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblPROYMUNI As System.Windows.Forms.Label
    Friend WithEvents cboPROYMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblPROYCLSE As System.Windows.Forms.Label
    Friend WithEvents cboPROYCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboPROYESTA As System.Windows.Forms.ComboBox
    Friend WithEvents txtPROYDESC As System.Windows.Forms.TextBox
    Friend WithEvents txtPROYCODI As System.Windows.Forms.TextBox
    Friend WithEvents lblCódigo As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabAlcance As System.Windows.Forms.TabPage
    Friend WithEvents txtPROYALCA As System.Windows.Forms.TextBox
    Friend WithEvents tabRecursos As System.Windows.Forms.TabPage
    Friend WithEvents txtPROYRECU As System.Windows.Forms.TextBox
    Friend WithEvents tabJustificacion As System.Windows.Forms.TabPage
    Friend WithEvents txtPROYJUST As System.Windows.Forms.TextBox
    Friend WithEvents tabObjetivos As System.Windows.Forms.TabPage
    Friend WithEvents txtPROYOBJE As System.Windows.Forms.TextBox
    Friend WithEvents tabFinalidad As System.Windows.Forms.TabPage
    Friend WithEvents txtPROYFINA As System.Windows.Forms.TextBox
    Friend WithEvents tabObservaciones As System.Windows.Forms.TabPage
    Friend WithEvents txtPROYOBSE As System.Windows.Forms.TextBox
    Friend WithEvents tabConvenios As System.Windows.Forms.TabPage
    Friend WithEvents txtPROYCONV As System.Windows.Forms.TextBox
    Friend WithEvents tabCompromisos As System.Windows.Forms.TabPage
    Friend WithEvents txtPROYCOMP As System.Windows.Forms.TextBox
    Friend WithEvents tabNormatividad As System.Windows.Forms.TabPage
    Friend WithEvents txtPROYNORM As System.Windows.Forms.TextBox
End Class
