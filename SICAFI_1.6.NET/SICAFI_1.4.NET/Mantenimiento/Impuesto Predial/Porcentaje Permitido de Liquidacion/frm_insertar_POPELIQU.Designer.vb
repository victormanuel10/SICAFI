<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_POPELIQU
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
        Me.fraPREDEXEN = New System.Windows.Forms.GroupBox()
        Me.nudPPLIVIAP = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPPLIFECH = New System.Windows.Forms.MaskedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPPLIRESO = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPPLIPOAP = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblPPLIVIFI = New System.Windows.Forms.Label()
        Me.cboPPLIVIFI = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPPLIOBSE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPPLICONC = New System.Windows.Forms.Label()
        Me.cboPPLICONC = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPPLITIIM = New System.Windows.Forms.Label()
        Me.cboPPLITIIM = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblPPLIVIIN = New System.Windows.Forms.Label()
        Me.cboPPLIVIIN = New System.Windows.Forms.ComboBox()
        Me.lblPPLICLSE = New System.Windows.Forms.Label()
        Me.cboPPLICLSE = New System.Windows.Forms.ComboBox()
        Me.lblClaseosector = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPPLIDEPA = New System.Windows.Forms.Label()
        Me.cboPPLIDEPA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblPPLIMUNI = New System.Windows.Forms.Label()
        Me.cboPPLIMUNI = New System.Windows.Forms.ComboBox()
        Me.lblMUNICIPIO = New System.Windows.Forms.Label()
        Me.cboPPLIESTA = New System.Windows.Forms.ComboBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraPREDEXEN.SuspendLayout()
        CType(Me.nudPPLIVIAP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 447)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 52)
        Me.GroupBox1.TabIndex = 56
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 507)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(606, 25)
        Me.strBARRESTA.TabIndex = 57
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
        'fraPREDEXEN
        '
        Me.fraPREDEXEN.BackColor = System.Drawing.SystemColors.Control
        Me.fraPREDEXEN.Controls.Add(Me.nudPPLIVIAP)
        Me.fraPREDEXEN.Controls.Add(Me.Label6)
        Me.fraPREDEXEN.Controls.Add(Me.txtPPLIFECH)
        Me.fraPREDEXEN.Controls.Add(Me.Label12)
        Me.fraPREDEXEN.Controls.Add(Me.txtPPLIRESO)
        Me.fraPREDEXEN.Controls.Add(Me.Label10)
        Me.fraPREDEXEN.Controls.Add(Me.txtPPLIPOAP)
        Me.fraPREDEXEN.Controls.Add(Me.Label9)
        Me.fraPREDEXEN.Controls.Add(Me.lblPPLIVIFI)
        Me.fraPREDEXEN.Controls.Add(Me.cboPPLIVIFI)
        Me.fraPREDEXEN.Controls.Add(Me.Label8)
        Me.fraPREDEXEN.Controls.Add(Me.txtPPLIOBSE)
        Me.fraPREDEXEN.Controls.Add(Me.Label1)
        Me.fraPREDEXEN.Controls.Add(Me.lblPPLICONC)
        Me.fraPREDEXEN.Controls.Add(Me.cboPPLICONC)
        Me.fraPREDEXEN.Controls.Add(Me.Label2)
        Me.fraPREDEXEN.Controls.Add(Me.lblPPLITIIM)
        Me.fraPREDEXEN.Controls.Add(Me.cboPPLITIIM)
        Me.fraPREDEXEN.Controls.Add(Me.Label11)
        Me.fraPREDEXEN.Controls.Add(Me.lblPPLIVIIN)
        Me.fraPREDEXEN.Controls.Add(Me.cboPPLIVIIN)
        Me.fraPREDEXEN.Controls.Add(Me.lblPPLICLSE)
        Me.fraPREDEXEN.Controls.Add(Me.cboPPLICLSE)
        Me.fraPREDEXEN.Controls.Add(Me.lblClaseosector)
        Me.fraPREDEXEN.Controls.Add(Me.Label3)
        Me.fraPREDEXEN.Controls.Add(Me.lblPPLIDEPA)
        Me.fraPREDEXEN.Controls.Add(Me.cboPPLIDEPA)
        Me.fraPREDEXEN.Controls.Add(Me.Label4)
        Me.fraPREDEXEN.Controls.Add(Me.lblPPLIMUNI)
        Me.fraPREDEXEN.Controls.Add(Me.cboPPLIMUNI)
        Me.fraPREDEXEN.Controls.Add(Me.lblMUNICIPIO)
        Me.fraPREDEXEN.Controls.Add(Me.cboPPLIESTA)
        Me.fraPREDEXEN.Controls.Add(Me.lblCodigo)
        Me.fraPREDEXEN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPREDEXEN.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPREDEXEN.Location = New System.Drawing.Point(16, 10)
        Me.fraPREDEXEN.Name = "fraPREDEXEN"
        Me.fraPREDEXEN.Size = New System.Drawing.Size(572, 431)
        Me.fraPREDEXEN.TabIndex = 55
        Me.fraPREDEXEN.TabStop = False
        Me.fraPREDEXEN.Text = "INSERTAR PORCENTAJE PERMITIDO"
        '
        'nudPPLIVIAP
        '
        Me.nudPPLIVIAP.AccessibleDescription = "Vigencia aplicada"
        Me.nudPPLIVIAP.Location = New System.Drawing.Point(137, 214)
        Me.nudPPLIVIAP.Name = "nudPPLIVIAP"
        Me.nudPPLIVIAP.Size = New System.Drawing.Size(150, 21)
        Me.nudPPLIVIAP.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(19, 214)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 98
        Me.Label6.Text = "Vigencias aplicadas"
        '
        'txtPPLIFECH
        '
        Me.txtPPLIFECH.AccessibleDescription = "Fecha de resolución"
        Me.txtPPLIFECH.BackColor = System.Drawing.Color.White
        Me.txtPPLIFECH.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPPLIFECH.Location = New System.Drawing.Point(137, 261)
        Me.txtPPLIFECH.Mask = "00-00-0000"
        Me.txtPPLIFECH.Name = "txtPPLIFECH"
        Me.txtPPLIFECH.Size = New System.Drawing.Size(150, 20)
        Me.txtPPLIFECH.TabIndex = 12
        Me.txtPPLIFECH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(19, 261)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 20)
        Me.Label12.TabIndex = 96
        Me.Label12.Text = "Fecha resolución"
        '
        'txtPPLIRESO
        '
        Me.txtPPLIRESO.AccessibleDescription = "Resolución"
        Me.txtPPLIRESO.BackColor = System.Drawing.SystemColors.Window
        Me.txtPPLIRESO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPPLIRESO.Location = New System.Drawing.Point(137, 238)
        Me.txtPPLIRESO.MaxLength = 20
        Me.txtPPLIRESO.Name = "txtPPLIRESO"
        Me.txtPPLIRESO.Size = New System.Drawing.Size(150, 20)
        Me.txtPPLIRESO.TabIndex = 11
        Me.txtPPLIRESO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(19, 238)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 20)
        Me.Label10.TabIndex = 94
        Me.Label10.Text = "Resolución"
        '
        'txtPPLIPOAP
        '
        Me.txtPPLIPOAP.AccessibleDescription = "(%) Aplicado"
        Me.txtPPLIPOAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtPPLIPOAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPPLIPOAP.Location = New System.Drawing.Point(137, 191)
        Me.txtPPLIPOAP.MaxLength = 5
        Me.txtPPLIPOAP.Name = "txtPPLIPOAP"
        Me.txtPPLIPOAP.Size = New System.Drawing.Size(150, 20)
        Me.txtPPLIPOAP.TabIndex = 9
        Me.txtPPLIPOAP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(19, 191)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 20)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "(%) Aplicado"
        '
        'lblPPLIVIFI
        '
        Me.lblPPLIVIFI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPPLIVIFI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPPLIVIFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPPLIVIFI.ForeColor = System.Drawing.Color.Black
        Me.lblPPLIVIFI.Location = New System.Drawing.Point(448, 167)
        Me.lblPPLIVIFI.Name = "lblPPLIVIFI"
        Me.lblPPLIVIFI.Size = New System.Drawing.Size(110, 20)
        Me.lblPPLIVIFI.TabIndex = 90
        '
        'cboPPLIVIFI
        '
        Me.cboPPLIVIFI.AccessibleDescription = "Vigencia final"
        Me.cboPPLIVIFI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPPLIVIFI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPPLIVIFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPPLIVIFI.FormattingEnabled = True
        Me.cboPPLIVIFI.Location = New System.Drawing.Point(137, 166)
        Me.cboPPLIVIFI.Name = "cboPPLIVIFI"
        Me.cboPPLIVIFI.Size = New System.Drawing.Size(305, 22)
        Me.cboPPLIVIFI.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(19, 168)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 20)
        Me.Label8.TabIndex = 89
        Me.Label8.Text = "Vigencia final"
        '
        'txtPPLIOBSE
        '
        Me.txtPPLIOBSE.AccessibleDescription = "Observación"
        Me.txtPPLIOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtPPLIOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPPLIOBSE.Location = New System.Drawing.Point(137, 307)
        Me.txtPPLIOBSE.MaxLength = 100
        Me.txtPPLIOBSE.Multiline = True
        Me.txtPPLIOBSE.Name = "txtPPLIOBSE"
        Me.txtPPLIOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPPLIOBSE.Size = New System.Drawing.Size(421, 106)
        Me.txtPPLIOBSE.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 307)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Descripción"
        '
        'lblPPLICONC
        '
        Me.lblPPLICONC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPPLICONC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPPLICONC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPPLICONC.ForeColor = System.Drawing.Color.Black
        Me.lblPPLICONC.Location = New System.Drawing.Point(448, 121)
        Me.lblPPLICONC.Name = "lblPPLICONC"
        Me.lblPPLICONC.Size = New System.Drawing.Size(110, 20)
        Me.lblPPLICONC.TabIndex = 81
        '
        'cboPPLICONC
        '
        Me.cboPPLICONC.AccessibleDescription = "Concepto"
        Me.cboPPLICONC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPPLICONC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPPLICONC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPPLICONC.FormattingEnabled = True
        Me.cboPPLICONC.Location = New System.Drawing.Point(137, 120)
        Me.cboPPLICONC.Name = "cboPPLICONC"
        Me.cboPPLICONC.Size = New System.Drawing.Size(305, 22)
        Me.cboPPLICONC.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Concepto"
        '
        'lblPPLITIIM
        '
        Me.lblPPLITIIM.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPPLITIIM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPPLITIIM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPPLITIIM.ForeColor = System.Drawing.Color.Black
        Me.lblPPLITIIM.Location = New System.Drawing.Point(448, 97)
        Me.lblPPLITIIM.Name = "lblPPLITIIM"
        Me.lblPPLITIIM.Size = New System.Drawing.Size(110, 20)
        Me.lblPPLITIIM.TabIndex = 78
        '
        'cboPPLITIIM
        '
        Me.cboPPLITIIM.AccessibleDescription = "Tipo de impuesto"
        Me.cboPPLITIIM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPPLITIIM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPPLITIIM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPPLITIIM.FormattingEnabled = True
        Me.cboPPLITIIM.Location = New System.Drawing.Point(137, 96)
        Me.cboPPLITIIM.Name = "cboPPLITIIM"
        Me.cboPPLITIIM.Size = New System.Drawing.Size(305, 22)
        Me.cboPPLITIIM.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(19, 98)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 20)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "Tipo de impuesto"
        '
        'lblPPLIVIIN
        '
        Me.lblPPLIVIIN.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPPLIVIIN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPPLIVIIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPPLIVIIN.ForeColor = System.Drawing.Color.Black
        Me.lblPPLIVIIN.Location = New System.Drawing.Point(448, 144)
        Me.lblPPLIVIIN.Name = "lblPPLIVIIN"
        Me.lblPPLIVIIN.Size = New System.Drawing.Size(110, 20)
        Me.lblPPLIVIIN.TabIndex = 62
        '
        'cboPPLIVIIN
        '
        Me.cboPPLIVIIN.AccessibleDescription = "Vigencia inicial"
        Me.cboPPLIVIIN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPPLIVIIN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPPLIVIIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPPLIVIIN.FormattingEnabled = True
        Me.cboPPLIVIIN.Location = New System.Drawing.Point(137, 143)
        Me.cboPPLIVIIN.Name = "cboPPLIVIIN"
        Me.cboPPLIVIIN.Size = New System.Drawing.Size(305, 22)
        Me.cboPPLIVIIN.TabIndex = 7
        '
        'lblPPLICLSE
        '
        Me.lblPPLICLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPPLICLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPPLICLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPPLICLSE.ForeColor = System.Drawing.Color.Black
        Me.lblPPLICLSE.Location = New System.Drawing.Point(448, 74)
        Me.lblPPLICLSE.Name = "lblPPLICLSE"
        Me.lblPPLICLSE.Size = New System.Drawing.Size(110, 20)
        Me.lblPPLICLSE.TabIndex = 57
        '
        'cboPPLICLSE
        '
        Me.cboPPLICLSE.AccessibleDescription = "Clase o sector"
        Me.cboPPLICLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPPLICLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPPLICLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPPLICLSE.FormattingEnabled = True
        Me.cboPPLICLSE.Location = New System.Drawing.Point(137, 72)
        Me.cboPPLICLSE.Name = "cboPPLICLSE"
        Me.cboPPLICLSE.Size = New System.Drawing.Size(305, 22)
        Me.cboPPLICLSE.TabIndex = 3
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
        Me.Label3.Location = New System.Drawing.Point(19, 284)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'lblPPLIDEPA
        '
        Me.lblPPLIDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPPLIDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPPLIDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPPLIDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblPPLIDEPA.Location = New System.Drawing.Point(448, 28)
        Me.lblPPLIDEPA.Name = "lblPPLIDEPA"
        Me.lblPPLIDEPA.Size = New System.Drawing.Size(110, 20)
        Me.lblPPLIDEPA.TabIndex = 52
        '
        'cboPPLIDEPA
        '
        Me.cboPPLIDEPA.AccessibleDescription = "Departamento"
        Me.cboPPLIDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPPLIDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPPLIDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPPLIDEPA.FormattingEnabled = True
        Me.cboPPLIDEPA.Location = New System.Drawing.Point(137, 26)
        Me.cboPPLIDEPA.Name = "cboPPLIDEPA"
        Me.cboPPLIDEPA.Size = New System.Drawing.Size(305, 22)
        Me.cboPPLIDEPA.TabIndex = 1
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
        'lblPPLIMUNI
        '
        Me.lblPPLIMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPPLIMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPPLIMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPPLIMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblPPLIMUNI.Location = New System.Drawing.Point(448, 51)
        Me.lblPPLIMUNI.Name = "lblPPLIMUNI"
        Me.lblPPLIMUNI.Size = New System.Drawing.Size(110, 20)
        Me.lblPPLIMUNI.TabIndex = 50
        '
        'cboPPLIMUNI
        '
        Me.cboPPLIMUNI.AccessibleDescription = "Municipio"
        Me.cboPPLIMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPPLIMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPPLIMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPPLIMUNI.FormattingEnabled = True
        Me.cboPPLIMUNI.Location = New System.Drawing.Point(137, 49)
        Me.cboPPLIMUNI.Name = "cboPPLIMUNI"
        Me.cboPPLIMUNI.Size = New System.Drawing.Size(305, 22)
        Me.cboPPLIMUNI.TabIndex = 2
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
        'cboPPLIESTA
        '
        Me.cboPPLIESTA.AccessibleDescription = "Estado"
        Me.cboPPLIESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPPLIESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPPLIESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPPLIESTA.FormattingEnabled = True
        Me.cboPPLIESTA.Location = New System.Drawing.Point(137, 283)
        Me.cboPPLIESTA.Name = "cboPPLIESTA"
        Me.cboPPLIESTA.Size = New System.Drawing.Size(305, 22)
        Me.cboPPLIESTA.TabIndex = 13
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(19, 145)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(112, 20)
        Me.lblCodigo.TabIndex = 37
        Me.lblCodigo.Text = "Vigencia inicial "
        '
        'frm_insertar_POPELIQU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606, 532)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraPREDEXEN)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(622, 568)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(622, 568)
        Me.Name = "frm_insertar_POPELIQU"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraPREDEXEN.ResumeLayout(False)
        Me.fraPREDEXEN.PerformLayout()
        CType(Me.nudPPLIVIAP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraPREDEXEN As System.Windows.Forms.GroupBox
    Friend WithEvents txtPPLIFECH As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPPLIRESO As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPPLIPOAP As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblPPLIVIFI As System.Windows.Forms.Label
    Friend WithEvents cboPPLIVIFI As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPPLIOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPPLICONC As System.Windows.Forms.Label
    Friend WithEvents cboPPLICONC As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPPLITIIM As System.Windows.Forms.Label
    Friend WithEvents cboPPLITIIM As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblPPLIVIIN As System.Windows.Forms.Label
    Friend WithEvents cboPPLIVIIN As System.Windows.Forms.ComboBox
    Friend WithEvents lblPPLICLSE As System.Windows.Forms.Label
    Friend WithEvents cboPPLICLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPPLIDEPA As System.Windows.Forms.Label
    Friend WithEvents cboPPLIDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblPPLIMUNI As System.Windows.Forms.Label
    Friend WithEvents cboPPLIMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cboPPLIESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents nudPPLIVIAP As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
