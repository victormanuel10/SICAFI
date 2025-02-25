<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_PEPELIQU
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
        Me.fraFORMMUNI = New System.Windows.Forms.GroupBox
        Me.txtPPLIDESC = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblPPLICONC = New System.Windows.Forms.Label
        Me.cboPPLICONC = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkPPLIAFSI = New System.Windows.Forms.CheckBox
        Me.chkPPLIHILI = New System.Windows.Forms.CheckBox
        Me.chkPPLIHIAV = New System.Windows.Forms.CheckBox
        Me.lblPPLITIIM = New System.Windows.Forms.Label
        Me.cboPPLITIIM = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblPPLIVIGE = New System.Windows.Forms.Label
        Me.cboPPLIVIGE = New System.Windows.Forms.ComboBox
        Me.lblPPLICLSE = New System.Windows.Forms.Label
        Me.cboPPLICLSE = New System.Windows.Forms.ComboBox
        Me.lblClaseosector = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblPPLIDEPA = New System.Windows.Forms.Label
        Me.cboPPLIDEPA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblPPLIMUNI = New System.Windows.Forms.Label
        Me.cboPPLIMUNI = New System.Windows.Forms.ComboBox
        Me.lblMUNICIPIO = New System.Windows.Forms.Label
        Me.cboPPLIESTA = New System.Windows.Forms.ComboBox
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraFORMMUNI.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 320)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 52)
        Me.GroupBox1.TabIndex = 53
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 384)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(601, 25)
        Me.strBARRESTA.TabIndex = 54
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
        'fraFORMMUNI
        '
        Me.fraFORMMUNI.BackColor = System.Drawing.SystemColors.Control
        Me.fraFORMMUNI.Controls.Add(Me.txtPPLIDESC)
        Me.fraFORMMUNI.Controls.Add(Me.Label1)
        Me.fraFORMMUNI.Controls.Add(Me.lblPPLICONC)
        Me.fraFORMMUNI.Controls.Add(Me.cboPPLICONC)
        Me.fraFORMMUNI.Controls.Add(Me.Label2)
        Me.fraFORMMUNI.Controls.Add(Me.chkPPLIAFSI)
        Me.fraFORMMUNI.Controls.Add(Me.chkPPLIHILI)
        Me.fraFORMMUNI.Controls.Add(Me.chkPPLIHIAV)
        Me.fraFORMMUNI.Controls.Add(Me.lblPPLITIIM)
        Me.fraFORMMUNI.Controls.Add(Me.cboPPLITIIM)
        Me.fraFORMMUNI.Controls.Add(Me.Label11)
        Me.fraFORMMUNI.Controls.Add(Me.lblPPLIVIGE)
        Me.fraFORMMUNI.Controls.Add(Me.cboPPLIVIGE)
        Me.fraFORMMUNI.Controls.Add(Me.lblPPLICLSE)
        Me.fraFORMMUNI.Controls.Add(Me.cboPPLICLSE)
        Me.fraFORMMUNI.Controls.Add(Me.lblClaseosector)
        Me.fraFORMMUNI.Controls.Add(Me.Label3)
        Me.fraFORMMUNI.Controls.Add(Me.lblPPLIDEPA)
        Me.fraFORMMUNI.Controls.Add(Me.cboPPLIDEPA)
        Me.fraFORMMUNI.Controls.Add(Me.Label4)
        Me.fraFORMMUNI.Controls.Add(Me.lblPPLIMUNI)
        Me.fraFORMMUNI.Controls.Add(Me.cboPPLIMUNI)
        Me.fraFORMMUNI.Controls.Add(Me.lblMUNICIPIO)
        Me.fraFORMMUNI.Controls.Add(Me.cboPPLIESTA)
        Me.fraFORMMUNI.Controls.Add(Me.lblCodigo)
        Me.fraFORMMUNI.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraFORMMUNI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraFORMMUNI.Location = New System.Drawing.Point(12, 5)
        Me.fraFORMMUNI.Name = "fraFORMMUNI"
        Me.fraFORMMUNI.Size = New System.Drawing.Size(572, 309)
        Me.fraFORMMUNI.TabIndex = 52
        Me.fraFORMMUNI.TabStop = False
        Me.fraFORMMUNI.Text = "INSERTAR PERIODO PERMITIDO DE LIQUIDACIÓN"
        '
        'txtPPLIDESC
        '
        Me.txtPPLIDESC.AccessibleDescription = "Descripción"
        Me.txtPPLIDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtPPLIDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPPLIDESC.Location = New System.Drawing.Point(137, 168)
        Me.txtPPLIDESC.MaxLength = 50
        Me.txtPPLIDESC.Name = "txtPPLIDESC"
        Me.txtPPLIDESC.Size = New System.Drawing.Size(421, 20)
        Me.txtPPLIDESC.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 168)
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
        Me.lblPPLICONC.Location = New System.Drawing.Point(448, 144)
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
        Me.cboPPLICONC.Location = New System.Drawing.Point(137, 142)
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
        Me.Label2.Location = New System.Drawing.Point(19, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Concepto"
        '
        'chkPPLIAFSI
        '
        Me.chkPPLIAFSI.AccessibleDescription = "Aforo de impuesto"
        Me.chkPPLIAFSI.AutoSize = True
        Me.chkPPLIAFSI.Location = New System.Drawing.Point(19, 244)
        Me.chkPPLIAFSI.Name = "chkPPLIAFSI"
        Me.chkPPLIAFSI.Size = New System.Drawing.Size(126, 19)
        Me.chkPPLIAFSI.TabIndex = 11
        Me.chkPPLIAFSI.Text = "Aforo de impuesto"
        Me.chkPPLIAFSI.UseVisualStyleBackColor = True
        '
        'chkPPLIHILI
        '
        Me.chkPPLIHILI.AccessibleDescription = "Historico de liquidación"
        Me.chkPPLIHILI.AutoSize = True
        Me.chkPPLIHILI.Location = New System.Drawing.Point(19, 219)
        Me.chkPPLIHILI.Name = "chkPPLIHILI"
        Me.chkPPLIHILI.Size = New System.Drawing.Size(155, 19)
        Me.chkPPLIHILI.TabIndex = 10
        Me.chkPPLIHILI.Text = "Historico de liquidación"
        Me.chkPPLIHILI.UseVisualStyleBackColor = True
        '
        'chkPPLIHIAV
        '
        Me.chkPPLIHIAV.AccessibleDescription = "Histolico de avalúo"
        Me.chkPPLIHIAV.AutoSize = True
        Me.chkPPLIHIAV.Location = New System.Drawing.Point(19, 194)
        Me.chkPPLIHIAV.Name = "chkPPLIHIAV"
        Me.chkPPLIHIAV.Size = New System.Drawing.Size(130, 19)
        Me.chkPPLIHIAV.TabIndex = 9
        Me.chkPPLIHIAV.Text = "Histolico de avalúo"
        Me.chkPPLIHIAV.UseVisualStyleBackColor = True
        '
        'lblPPLITIIM
        '
        Me.lblPPLITIIM.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPPLITIIM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPPLITIIM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPPLITIIM.ForeColor = System.Drawing.Color.Black
        Me.lblPPLITIIM.Location = New System.Drawing.Point(448, 120)
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
        Me.cboPPLITIIM.Location = New System.Drawing.Point(137, 118)
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
        Me.Label11.Location = New System.Drawing.Point(19, 120)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 20)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "Tipo de impuesto"
        '
        'lblPPLIVIGE
        '
        Me.lblPPLIVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPPLIVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPPLIVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPPLIVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblPPLIVIGE.Location = New System.Drawing.Point(448, 97)
        Me.lblPPLIVIGE.Name = "lblPPLIVIGE"
        Me.lblPPLIVIGE.Size = New System.Drawing.Size(110, 20)
        Me.lblPPLIVIGE.TabIndex = 62
        '
        'cboPPLIVIGE
        '
        Me.cboPPLIVIGE.AccessibleDescription = "Vigencia"
        Me.cboPPLIVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPPLIVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPPLIVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPPLIVIGE.FormattingEnabled = True
        Me.cboPPLIVIGE.Location = New System.Drawing.Point(137, 95)
        Me.cboPPLIVIGE.Name = "cboPPLIVIGE"
        Me.cboPPLIVIGE.Size = New System.Drawing.Size(305, 22)
        Me.cboPPLIVIGE.TabIndex = 4
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
        Me.Label3.Location = New System.Drawing.Point(19, 266)
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
        Me.cboPPLIESTA.Location = New System.Drawing.Point(137, 267)
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
        Me.lblCodigo.Location = New System.Drawing.Point(19, 97)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(112, 20)
        Me.lblCodigo.TabIndex = 37
        Me.lblCodigo.Text = "Vigencia"
        '
        'frm_insertar_PEPELIQU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 409)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraFORMMUNI)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(617, 445)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(617, 445)
        Me.Name = "frm_insertar_PEPELIQU"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraFORMMUNI.ResumeLayout(False)
        Me.fraFORMMUNI.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraFORMMUNI As System.Windows.Forms.GroupBox
    Friend WithEvents txtPPLIDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPPLICONC As System.Windows.Forms.Label
    Friend WithEvents cboPPLICONC As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkPPLIAFSI As System.Windows.Forms.CheckBox
    Friend WithEvents chkPPLIHILI As System.Windows.Forms.CheckBox
    Friend WithEvents chkPPLIHIAV As System.Windows.Forms.CheckBox
    Friend WithEvents lblPPLITIIM As System.Windows.Forms.Label
    Friend WithEvents cboPPLITIIM As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblPPLIVIGE As System.Windows.Forms.Label
    Friend WithEvents cboPPLIVIGE As System.Windows.Forms.ComboBox
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
End Class
