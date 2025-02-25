<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_TARIZOFI
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
        Me.fraZONAECONOMICA = New System.Windows.Forms.GroupBox()
        Me.txtTAZFTALO = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTAZFPORC = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboTAZFSIGN = New System.Windows.Forms.ComboBox()
        Me.lblTAZFVIGE = New System.Windows.Forms.Label()
        Me.cboTAZFVIGE = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTAZFTA06 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTAZFTA05 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTAZFTA04 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTAZFTA03 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTAZFTA02 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTAZFZOAP = New System.Windows.Forms.Label()
        Me.cboTAZFZOAP = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTAZFZOFI = New System.Windows.Forms.Label()
        Me.cboTAZFZOFI = New System.Windows.Forms.ComboBox()
        Me.txtTAZFTA01 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTAZFCLSE = New System.Windows.Forms.Label()
        Me.cboTAZFCLSE = New System.Windows.Forms.ComboBox()
        Me.lblClaseosector = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTAZFDEPA = New System.Windows.Forms.Label()
        Me.cboTAZFDEPA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTAZFMUNI = New System.Windows.Forms.Label()
        Me.cboTAZFMUNI = New System.Windows.Forms.ComboBox()
        Me.lblMUNICIPIO = New System.Windows.Forms.Label()
        Me.cboTAZFESTA = New System.Windows.Forms.ComboBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraZONAECONOMICA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 426)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 52)
        Me.GroupBox1.TabIndex = 37
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 493)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(598, 25)
        Me.strBARRESTA.TabIndex = 36
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
        'fraZONAECONOMICA
        '
        Me.fraZONAECONOMICA.BackColor = System.Drawing.SystemColors.Control
        Me.fraZONAECONOMICA.Controls.Add(Me.txtTAZFTALO)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label13)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtTAZFPORC)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label12)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label10)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTAZFSIGN)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblTAZFVIGE)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTAZFVIGE)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label11)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtTAZFTA06)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label9)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtTAZFTA05)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label8)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtTAZFTA04)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label7)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtTAZFTA03)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label6)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtTAZFTA02)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label1)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblTAZFZOAP)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTAZFZOAP)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label5)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblTAZFZOFI)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTAZFZOFI)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtTAZFTA01)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label2)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblTAZFCLSE)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTAZFCLSE)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblClaseosector)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label3)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblTAZFDEPA)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTAZFDEPA)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label4)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblTAZFMUNI)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTAZFMUNI)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblMUNICIPIO)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTAZFESTA)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblCodigo)
        Me.fraZONAECONOMICA.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraZONAECONOMICA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraZONAECONOMICA.Location = New System.Drawing.Point(12, 9)
        Me.fraZONAECONOMICA.Name = "fraZONAECONOMICA"
        Me.fraZONAECONOMICA.Size = New System.Drawing.Size(572, 411)
        Me.fraZONAECONOMICA.TabIndex = 35
        Me.fraZONAECONOMICA.TabStop = False
        Me.fraZONAECONOMICA.Text = "INSERTA TARIFA POR ZONA FÍSICA"
        '
        'txtTAZFTALO
        '
        Me.txtTAZFTALO.AccessibleDescription = "Tarifa lote"
        Me.txtTAZFTALO.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFTALO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFTALO.Location = New System.Drawing.Point(137, 373)
        Me.txtTAZFTALO.MaxLength = 5
        Me.txtTAZFTALO.Name = "txtTAZFTALO"
        Me.txtTAZFTALO.Size = New System.Drawing.Size(112, 20)
        Me.txtTAZFTALO.TabIndex = 16
        Me.txtTAZFTALO.Text = "0.00"
        Me.txtTAZFTALO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(19, 373)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 20)
        Me.Label13.TabIndex = 83
        Me.Label13.Text = "Talifa lote"
        '
        'txtTAZFPORC
        '
        Me.txtTAZFPORC.AccessibleDescription = "Porcentaje"
        Me.txtTAZFPORC.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFPORC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFPORC.Location = New System.Drawing.Point(137, 350)
        Me.txtTAZFPORC.MaxLength = 5
        Me.txtTAZFPORC.Name = "txtTAZFPORC"
        Me.txtTAZFPORC.Size = New System.Drawing.Size(112, 20)
        Me.txtTAZFPORC.TabIndex = 15
        Me.txtTAZFPORC.Text = "0.00"
        Me.txtTAZFPORC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(19, 350)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 20)
        Me.Label12.TabIndex = 81
        Me.Label12.Text = "Porcentaje"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(19, 327)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 20)
        Me.Label10.TabIndex = 80
        Me.Label10.Text = "Signo (+,-,*)"
        '
        'cboTAZFSIGN
        '
        Me.cboTAZFSIGN.AccessibleDescription = "Signo"
        Me.cboTAZFSIGN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAZFSIGN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAZFSIGN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAZFSIGN.FormattingEnabled = True
        Me.cboTAZFSIGN.Items.AddRange(New Object() {"+", "-", "*"})
        Me.cboTAZFSIGN.Location = New System.Drawing.Point(137, 327)
        Me.cboTAZFSIGN.Name = "cboTAZFSIGN"
        Me.cboTAZFSIGN.Size = New System.Drawing.Size(112, 22)
        Me.cboTAZFSIGN.TabIndex = 14
        '
        'lblTAZFVIGE
        '
        Me.lblTAZFVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAZFVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAZFVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAZFVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblTAZFVIGE.Location = New System.Drawing.Point(445, 97)
        Me.lblTAZFVIGE.Name = "lblTAZFVIGE"
        Me.lblTAZFVIGE.Size = New System.Drawing.Size(113, 20)
        Me.lblTAZFVIGE.TabIndex = 78
        '
        'cboTAZFVIGE
        '
        Me.cboTAZFVIGE.AccessibleDescription = "Vigencia"
        Me.cboTAZFVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAZFVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAZFVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAZFVIGE.FormattingEnabled = True
        Me.cboTAZFVIGE.Location = New System.Drawing.Point(137, 95)
        Me.cboTAZFVIGE.Name = "cboTAZFVIGE"
        Me.cboTAZFVIGE.Size = New System.Drawing.Size(302, 22)
        Me.cboTAZFVIGE.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(19, 97)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 20)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "Vigencia"
        '
        'txtTAZFTA06
        '
        Me.txtTAZFTA06.AccessibleDescription = "Tarifa 06"
        Me.txtTAZFTA06.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFTA06.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFTA06.Location = New System.Drawing.Point(137, 258)
        Me.txtTAZFTA06.MaxLength = 5
        Me.txtTAZFTA06.Name = "txtTAZFTA06"
        Me.txtTAZFTA06.Size = New System.Drawing.Size(112, 20)
        Me.txtTAZFTA06.TabIndex = 11
        Me.txtTAZFTA06.Text = "0.00"
        Me.txtTAZFTA06.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(19, 258)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 20)
        Me.Label9.TabIndex = 75
        Me.Label9.Text = "6. Alto 85 a 100"
        '
        'txtTAZFTA05
        '
        Me.txtTAZFTA05.AccessibleDescription = "Tarifa 05"
        Me.txtTAZFTA05.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFTA05.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFTA05.Location = New System.Drawing.Point(137, 235)
        Me.txtTAZFTA05.MaxLength = 5
        Me.txtTAZFTA05.Name = "txtTAZFTA05"
        Me.txtTAZFTA05.Size = New System.Drawing.Size(112, 20)
        Me.txtTAZFTA05.TabIndex = 10
        Me.txtTAZFTA05.Text = "0.00"
        Me.txtTAZFTA05.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(19, 235)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 20)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "5. Med-Alto 65 a 84"
        '
        'txtTAZFTA04
        '
        Me.txtTAZFTA04.AccessibleDescription = "Tarifa 04"
        Me.txtTAZFTA04.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFTA04.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFTA04.Location = New System.Drawing.Point(137, 212)
        Me.txtTAZFTA04.MaxLength = 5
        Me.txtTAZFTA04.Name = "txtTAZFTA04"
        Me.txtTAZFTA04.Size = New System.Drawing.Size(112, 20)
        Me.txtTAZFTA04.TabIndex = 9
        Me.txtTAZFTA04.Text = "0.00"
        Me.txtTAZFTA04.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(19, 212)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 20)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "4. Medio 47 a 64"
        '
        'txtTAZFTA03
        '
        Me.txtTAZFTA03.AccessibleDescription = "Tarifa 03"
        Me.txtTAZFTA03.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFTA03.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFTA03.Location = New System.Drawing.Point(137, 189)
        Me.txtTAZFTA03.MaxLength = 5
        Me.txtTAZFTA03.Name = "txtTAZFTA03"
        Me.txtTAZFTA03.Size = New System.Drawing.Size(112, 20)
        Me.txtTAZFTA03.TabIndex = 8
        Me.txtTAZFTA03.Text = "0.00"
        Me.txtTAZFTA03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(19, 189)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "3. Med-Baj 29 a 46"
        '
        'txtTAZFTA02
        '
        Me.txtTAZFTA02.AccessibleDescription = "Tarifa 02"
        Me.txtTAZFTA02.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFTA02.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFTA02.Location = New System.Drawing.Point(137, 166)
        Me.txtTAZFTA02.MaxLength = 5
        Me.txtTAZFTA02.Name = "txtTAZFTA02"
        Me.txtTAZFTA02.Size = New System.Drawing.Size(112, 20)
        Me.txtTAZFTA02.TabIndex = 7
        Me.txtTAZFTA02.Text = "0.00"
        Me.txtTAZFTA02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 166)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "2. Bajo 11 a 28"
        '
        'lblTAZFZOAP
        '
        Me.lblTAZFZOAP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAZFZOAP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAZFZOAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAZFZOAP.ForeColor = System.Drawing.Color.Black
        Me.lblTAZFZOAP.Location = New System.Drawing.Point(445, 283)
        Me.lblTAZFZOAP.Name = "lblTAZFZOAP"
        Me.lblTAZFZOAP.Size = New System.Drawing.Size(113, 20)
        Me.lblTAZFZOAP.TabIndex = 65
        '
        'cboTAZFZOAP
        '
        Me.cboTAZFZOAP.AccessibleDescription = "Zona aplicada"
        Me.cboTAZFZOAP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAZFZOAP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAZFZOAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAZFZOAP.FormattingEnabled = True
        Me.cboTAZFZOAP.Location = New System.Drawing.Point(137, 280)
        Me.cboTAZFZOAP.Name = "cboTAZFZOAP"
        Me.cboTAZFZOAP.Size = New System.Drawing.Size(302, 22)
        Me.cboTAZFZOAP.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 281)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Zona aplicada"
        '
        'lblTAZFZOFI
        '
        Me.lblTAZFZOFI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAZFZOFI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAZFZOFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAZFZOFI.ForeColor = System.Drawing.Color.Black
        Me.lblTAZFZOFI.Location = New System.Drawing.Point(445, 120)
        Me.lblTAZFZOFI.Name = "lblTAZFZOFI"
        Me.lblTAZFZOFI.Size = New System.Drawing.Size(113, 20)
        Me.lblTAZFZOFI.TabIndex = 62
        '
        'cboTAZFZOFI
        '
        Me.cboTAZFZOFI.AccessibleDescription = "Zona física"
        Me.cboTAZFZOFI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAZFZOFI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAZFZOFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAZFZOFI.FormattingEnabled = True
        Me.cboTAZFZOFI.Location = New System.Drawing.Point(137, 118)
        Me.cboTAZFZOFI.Name = "cboTAZFZOFI"
        Me.cboTAZFZOFI.Size = New System.Drawing.Size(302, 22)
        Me.cboTAZFZOFI.TabIndex = 5
        '
        'txtTAZFTA01
        '
        Me.txtTAZFTA01.AccessibleDescription = "Tarifa 01"
        Me.txtTAZFTA01.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZFTA01.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZFTA01.Location = New System.Drawing.Point(137, 143)
        Me.txtTAZFTA01.MaxLength = 5
        Me.txtTAZFTA01.Name = "txtTAZFTA01"
        Me.txtTAZFTA01.Size = New System.Drawing.Size(112, 20)
        Me.txtTAZFTA01.TabIndex = 6
        Me.txtTAZFTA01.Text = "0.00"
        Me.txtTAZFTA01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "1. Bajo-Bajo 0 a 10"
        '
        'lblTAZFCLSE
        '
        Me.lblTAZFCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAZFCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAZFCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAZFCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblTAZFCLSE.Location = New System.Drawing.Point(445, 74)
        Me.lblTAZFCLSE.Name = "lblTAZFCLSE"
        Me.lblTAZFCLSE.Size = New System.Drawing.Size(113, 20)
        Me.lblTAZFCLSE.TabIndex = 57
        '
        'cboTAZFCLSE
        '
        Me.cboTAZFCLSE.AccessibleDescription = "Clase o sector"
        Me.cboTAZFCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAZFCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAZFCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAZFCLSE.FormattingEnabled = True
        Me.cboTAZFCLSE.Location = New System.Drawing.Point(137, 72)
        Me.cboTAZFCLSE.Name = "cboTAZFCLSE"
        Me.cboTAZFCLSE.Size = New System.Drawing.Size(302, 22)
        Me.cboTAZFCLSE.TabIndex = 3
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
        Me.Label3.Location = New System.Drawing.Point(19, 304)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'lblTAZFDEPA
        '
        Me.lblTAZFDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAZFDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAZFDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAZFDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblTAZFDEPA.Location = New System.Drawing.Point(445, 28)
        Me.lblTAZFDEPA.Name = "lblTAZFDEPA"
        Me.lblTAZFDEPA.Size = New System.Drawing.Size(113, 20)
        Me.lblTAZFDEPA.TabIndex = 52
        '
        'cboTAZFDEPA
        '
        Me.cboTAZFDEPA.AccessibleDescription = "Departamento"
        Me.cboTAZFDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAZFDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAZFDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAZFDEPA.FormattingEnabled = True
        Me.cboTAZFDEPA.Location = New System.Drawing.Point(137, 26)
        Me.cboTAZFDEPA.Name = "cboTAZFDEPA"
        Me.cboTAZFDEPA.Size = New System.Drawing.Size(302, 22)
        Me.cboTAZFDEPA.TabIndex = 1
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
        'lblTAZFMUNI
        '
        Me.lblTAZFMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAZFMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAZFMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAZFMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblTAZFMUNI.Location = New System.Drawing.Point(445, 51)
        Me.lblTAZFMUNI.Name = "lblTAZFMUNI"
        Me.lblTAZFMUNI.Size = New System.Drawing.Size(113, 20)
        Me.lblTAZFMUNI.TabIndex = 50
        '
        'cboTAZFMUNI
        '
        Me.cboTAZFMUNI.AccessibleDescription = "Municipio"
        Me.cboTAZFMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAZFMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAZFMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAZFMUNI.FormattingEnabled = True
        Me.cboTAZFMUNI.Location = New System.Drawing.Point(137, 49)
        Me.cboTAZFMUNI.Name = "cboTAZFMUNI"
        Me.cboTAZFMUNI.Size = New System.Drawing.Size(302, 22)
        Me.cboTAZFMUNI.TabIndex = 2
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
        'cboTAZFESTA
        '
        Me.cboTAZFESTA.AccessibleDescription = "Estado"
        Me.cboTAZFESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAZFESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAZFESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAZFESTA.FormattingEnabled = True
        Me.cboTAZFESTA.Location = New System.Drawing.Point(137, 304)
        Me.cboTAZFESTA.Name = "cboTAZFESTA"
        Me.cboTAZFESTA.Size = New System.Drawing.Size(302, 22)
        Me.cboTAZFESTA.TabIndex = 13
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(19, 120)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(112, 20)
        Me.lblCodigo.TabIndex = 37
        Me.lblCodigo.Text = "Zona física"
        '
        'frm_insertar_TARIZOFI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 518)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraZONAECONOMICA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(614, 554)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(614, 554)
        Me.Name = "frm_insertar_TARIZOFI"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraZONAECONOMICA.ResumeLayout(False)
        Me.fraZONAECONOMICA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraZONAECONOMICA As System.Windows.Forms.GroupBox
    Friend WithEvents txtTAZFTALO As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTAZFPORC As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboTAZFSIGN As System.Windows.Forms.ComboBox
    Friend WithEvents lblTAZFVIGE As System.Windows.Forms.Label
    Friend WithEvents cboTAZFVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTAZFTA06 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTAZFTA05 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTAZFTA04 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTAZFTA03 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTAZFTA02 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTAZFZOAP As System.Windows.Forms.Label
    Friend WithEvents cboTAZFZOAP As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTAZFZOFI As System.Windows.Forms.Label
    Friend WithEvents cboTAZFZOFI As System.Windows.Forms.ComboBox
    Friend WithEvents txtTAZFTA01 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTAZFCLSE As System.Windows.Forms.Label
    Friend WithEvents cboTAZFCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTAZFDEPA As System.Windows.Forms.Label
    Friend WithEvents cboTAZFDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTAZFMUNI As System.Windows.Forms.Label
    Friend WithEvents cboTAZFMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cboTAZFESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
End Class
