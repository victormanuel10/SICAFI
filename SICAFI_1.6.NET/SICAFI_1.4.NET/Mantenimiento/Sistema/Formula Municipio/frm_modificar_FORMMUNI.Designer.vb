<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_FORMMUNI
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
        Me.txtFOMUDESC = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblFOMUFORM = New System.Windows.Forms.Label
        Me.cboFOMUFORM = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblFOMUCONC = New System.Windows.Forms.Label
        Me.cboFOMUCONC = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkFOMUTAAS = New System.Windows.Forms.CheckBox
        Me.chkFOMUALPU = New System.Windows.Forms.CheckBox
        Me.chkFOMUACBO = New System.Windows.Forms.CheckBox
        Me.chkFOMUIMPR = New System.Windows.Forms.CheckBox
        Me.lblFOMUTIIM = New System.Windows.Forms.Label
        Me.cboFOMUTIIM = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblFOMUVIGE = New System.Windows.Forms.Label
        Me.cboFOMUVIGE = New System.Windows.Forms.ComboBox
        Me.lblFOMUCLSE = New System.Windows.Forms.Label
        Me.cboFOMUCLSE = New System.Windows.Forms.ComboBox
        Me.lblClaseosector = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblFOMUDEPA = New System.Windows.Forms.Label
        Me.cboFOMUDEPA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblFOMUMUNI = New System.Windows.Forms.Label
        Me.cboFOMUMUNI = New System.Windows.Forms.ComboBox
        Me.lblMUNICIPIO = New System.Windows.Forms.Label
        Me.cboFOMUESTA = New System.Windows.Forms.ComboBox
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 366)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 430)
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
        Me.fraFORMMUNI.Controls.Add(Me.txtFOMUDESC)
        Me.fraFORMMUNI.Controls.Add(Me.Label1)
        Me.fraFORMMUNI.Controls.Add(Me.lblFOMUFORM)
        Me.fraFORMMUNI.Controls.Add(Me.cboFOMUFORM)
        Me.fraFORMMUNI.Controls.Add(Me.Label6)
        Me.fraFORMMUNI.Controls.Add(Me.lblFOMUCONC)
        Me.fraFORMMUNI.Controls.Add(Me.cboFOMUCONC)
        Me.fraFORMMUNI.Controls.Add(Me.Label2)
        Me.fraFORMMUNI.Controls.Add(Me.chkFOMUTAAS)
        Me.fraFORMMUNI.Controls.Add(Me.chkFOMUALPU)
        Me.fraFORMMUNI.Controls.Add(Me.chkFOMUACBO)
        Me.fraFORMMUNI.Controls.Add(Me.chkFOMUIMPR)
        Me.fraFORMMUNI.Controls.Add(Me.lblFOMUTIIM)
        Me.fraFORMMUNI.Controls.Add(Me.cboFOMUTIIM)
        Me.fraFORMMUNI.Controls.Add(Me.Label11)
        Me.fraFORMMUNI.Controls.Add(Me.lblFOMUVIGE)
        Me.fraFORMMUNI.Controls.Add(Me.cboFOMUVIGE)
        Me.fraFORMMUNI.Controls.Add(Me.lblFOMUCLSE)
        Me.fraFORMMUNI.Controls.Add(Me.cboFOMUCLSE)
        Me.fraFORMMUNI.Controls.Add(Me.lblClaseosector)
        Me.fraFORMMUNI.Controls.Add(Me.Label3)
        Me.fraFORMMUNI.Controls.Add(Me.lblFOMUDEPA)
        Me.fraFORMMUNI.Controls.Add(Me.cboFOMUDEPA)
        Me.fraFORMMUNI.Controls.Add(Me.Label4)
        Me.fraFORMMUNI.Controls.Add(Me.lblFOMUMUNI)
        Me.fraFORMMUNI.Controls.Add(Me.cboFOMUMUNI)
        Me.fraFORMMUNI.Controls.Add(Me.lblMUNICIPIO)
        Me.fraFORMMUNI.Controls.Add(Me.cboFOMUESTA)
        Me.fraFORMMUNI.Controls.Add(Me.lblCodigo)
        Me.fraFORMMUNI.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraFORMMUNI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraFORMMUNI.Location = New System.Drawing.Point(12, 4)
        Me.fraFORMMUNI.Name = "fraFORMMUNI"
        Me.fraFORMMUNI.Size = New System.Drawing.Size(572, 356)
        Me.fraFORMMUNI.TabIndex = 52
        Me.fraFORMMUNI.TabStop = False
        Me.fraFORMMUNI.Text = "MODIFICAR FORMULA MUNICIPIO"
        '
        'txtFOMUDESC
        '
        Me.txtFOMUDESC.AccessibleDescription = "Descripción"
        Me.txtFOMUDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtFOMUDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFOMUDESC.Location = New System.Drawing.Point(137, 191)
        Me.txtFOMUDESC.MaxLength = 50
        Me.txtFOMUDESC.Name = "txtFOMUDESC"
        Me.txtFOMUDESC.Size = New System.Drawing.Size(421, 20)
        Me.txtFOMUDESC.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 191)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Descripción"
        '
        'lblFOMUFORM
        '
        Me.lblFOMUFORM.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFOMUFORM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFOMUFORM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFOMUFORM.ForeColor = System.Drawing.Color.Black
        Me.lblFOMUFORM.Location = New System.Drawing.Point(448, 167)
        Me.lblFOMUFORM.Name = "lblFOMUFORM"
        Me.lblFOMUFORM.Size = New System.Drawing.Size(110, 20)
        Me.lblFOMUFORM.TabIndex = 84
        '
        'cboFOMUFORM
        '
        Me.cboFOMUFORM.AccessibleDescription = "Formula"
        Me.cboFOMUFORM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFOMUFORM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOMUFORM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFOMUFORM.FormattingEnabled = True
        Me.cboFOMUFORM.Location = New System.Drawing.Point(137, 165)
        Me.cboFOMUFORM.Name = "cboFOMUFORM"
        Me.cboFOMUFORM.Size = New System.Drawing.Size(305, 22)
        Me.cboFOMUFORM.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(19, 167)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "Formula"
        '
        'lblFOMUCONC
        '
        Me.lblFOMUCONC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFOMUCONC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFOMUCONC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFOMUCONC.ForeColor = System.Drawing.Color.Black
        Me.lblFOMUCONC.Location = New System.Drawing.Point(448, 144)
        Me.lblFOMUCONC.Name = "lblFOMUCONC"
        Me.lblFOMUCONC.Size = New System.Drawing.Size(110, 20)
        Me.lblFOMUCONC.TabIndex = 81
        '
        'cboFOMUCONC
        '
        Me.cboFOMUCONC.AccessibleDescription = "Concepto"
        Me.cboFOMUCONC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFOMUCONC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOMUCONC.Enabled = False
        Me.cboFOMUCONC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFOMUCONC.FormattingEnabled = True
        Me.cboFOMUCONC.Location = New System.Drawing.Point(137, 142)
        Me.cboFOMUCONC.Name = "cboFOMUCONC"
        Me.cboFOMUCONC.Size = New System.Drawing.Size(305, 22)
        Me.cboFOMUCONC.TabIndex = 6
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
        'chkFOMUTAAS
        '
        Me.chkFOMUTAAS.AccessibleDescription = "Tasa de aseo"
        Me.chkFOMUTAAS.AutoSize = True
        Me.chkFOMUTAAS.Location = New System.Drawing.Point(19, 291)
        Me.chkFOMUTAAS.Name = "chkFOMUTAAS"
        Me.chkFOMUTAAS.Size = New System.Drawing.Size(102, 19)
        Me.chkFOMUTAAS.TabIndex = 12
        Me.chkFOMUTAAS.Text = "Tasa de aseo"
        Me.chkFOMUTAAS.UseVisualStyleBackColor = True
        '
        'chkFOMUALPU
        '
        Me.chkFOMUALPU.AccessibleDescription = "Alumbrado publico"
        Me.chkFOMUALPU.AutoSize = True
        Me.chkFOMUALPU.Location = New System.Drawing.Point(19, 267)
        Me.chkFOMUALPU.Name = "chkFOMUALPU"
        Me.chkFOMUALPU.Size = New System.Drawing.Size(129, 19)
        Me.chkFOMUALPU.TabIndex = 11
        Me.chkFOMUALPU.Text = "Alumbrado publico"
        Me.chkFOMUALPU.UseVisualStyleBackColor = True
        '
        'chkFOMUACBO
        '
        Me.chkFOMUACBO.AccessibleDescription = "Actividad bomberil"
        Me.chkFOMUACBO.AutoSize = True
        Me.chkFOMUACBO.Location = New System.Drawing.Point(19, 242)
        Me.chkFOMUACBO.Name = "chkFOMUACBO"
        Me.chkFOMUACBO.Size = New System.Drawing.Size(126, 19)
        Me.chkFOMUACBO.TabIndex = 10
        Me.chkFOMUACBO.Text = "Actividad bomberil"
        Me.chkFOMUACBO.UseVisualStyleBackColor = True
        '
        'chkFOMUIMPR
        '
        Me.chkFOMUIMPR.AccessibleDescription = "Impuesto predial"
        Me.chkFOMUIMPR.AutoSize = True
        Me.chkFOMUIMPR.Location = New System.Drawing.Point(19, 217)
        Me.chkFOMUIMPR.Name = "chkFOMUIMPR"
        Me.chkFOMUIMPR.Size = New System.Drawing.Size(119, 19)
        Me.chkFOMUIMPR.TabIndex = 9
        Me.chkFOMUIMPR.Text = "Impuesto predial"
        Me.chkFOMUIMPR.UseVisualStyleBackColor = True
        '
        'lblFOMUTIIM
        '
        Me.lblFOMUTIIM.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFOMUTIIM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFOMUTIIM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFOMUTIIM.ForeColor = System.Drawing.Color.Black
        Me.lblFOMUTIIM.Location = New System.Drawing.Point(448, 120)
        Me.lblFOMUTIIM.Name = "lblFOMUTIIM"
        Me.lblFOMUTIIM.Size = New System.Drawing.Size(110, 20)
        Me.lblFOMUTIIM.TabIndex = 78
        '
        'cboFOMUTIIM
        '
        Me.cboFOMUTIIM.AccessibleDescription = "Tipo de impuesto"
        Me.cboFOMUTIIM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFOMUTIIM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOMUTIIM.Enabled = False
        Me.cboFOMUTIIM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFOMUTIIM.FormattingEnabled = True
        Me.cboFOMUTIIM.Location = New System.Drawing.Point(137, 118)
        Me.cboFOMUTIIM.Name = "cboFOMUTIIM"
        Me.cboFOMUTIIM.Size = New System.Drawing.Size(305, 22)
        Me.cboFOMUTIIM.TabIndex = 5
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
        'lblFOMUVIGE
        '
        Me.lblFOMUVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFOMUVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFOMUVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFOMUVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblFOMUVIGE.Location = New System.Drawing.Point(448, 97)
        Me.lblFOMUVIGE.Name = "lblFOMUVIGE"
        Me.lblFOMUVIGE.Size = New System.Drawing.Size(110, 20)
        Me.lblFOMUVIGE.TabIndex = 62
        '
        'cboFOMUVIGE
        '
        Me.cboFOMUVIGE.AccessibleDescription = "Vigencia"
        Me.cboFOMUVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFOMUVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOMUVIGE.Enabled = False
        Me.cboFOMUVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFOMUVIGE.FormattingEnabled = True
        Me.cboFOMUVIGE.Location = New System.Drawing.Point(137, 95)
        Me.cboFOMUVIGE.Name = "cboFOMUVIGE"
        Me.cboFOMUVIGE.Size = New System.Drawing.Size(305, 22)
        Me.cboFOMUVIGE.TabIndex = 4
        '
        'lblFOMUCLSE
        '
        Me.lblFOMUCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFOMUCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFOMUCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFOMUCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblFOMUCLSE.Location = New System.Drawing.Point(448, 74)
        Me.lblFOMUCLSE.Name = "lblFOMUCLSE"
        Me.lblFOMUCLSE.Size = New System.Drawing.Size(110, 20)
        Me.lblFOMUCLSE.TabIndex = 57
        '
        'cboFOMUCLSE
        '
        Me.cboFOMUCLSE.AccessibleDescription = "Clase o sector"
        Me.cboFOMUCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFOMUCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOMUCLSE.Enabled = False
        Me.cboFOMUCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFOMUCLSE.FormattingEnabled = True
        Me.cboFOMUCLSE.Location = New System.Drawing.Point(137, 72)
        Me.cboFOMUCLSE.Name = "cboFOMUCLSE"
        Me.cboFOMUCLSE.Size = New System.Drawing.Size(305, 22)
        Me.cboFOMUCLSE.TabIndex = 3
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
        Me.Label3.Location = New System.Drawing.Point(19, 316)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'lblFOMUDEPA
        '
        Me.lblFOMUDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFOMUDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFOMUDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFOMUDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblFOMUDEPA.Location = New System.Drawing.Point(448, 28)
        Me.lblFOMUDEPA.Name = "lblFOMUDEPA"
        Me.lblFOMUDEPA.Size = New System.Drawing.Size(110, 20)
        Me.lblFOMUDEPA.TabIndex = 52
        '
        'cboFOMUDEPA
        '
        Me.cboFOMUDEPA.AccessibleDescription = "Departamento"
        Me.cboFOMUDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFOMUDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOMUDEPA.Enabled = False
        Me.cboFOMUDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFOMUDEPA.FormattingEnabled = True
        Me.cboFOMUDEPA.Location = New System.Drawing.Point(137, 26)
        Me.cboFOMUDEPA.Name = "cboFOMUDEPA"
        Me.cboFOMUDEPA.Size = New System.Drawing.Size(305, 22)
        Me.cboFOMUDEPA.TabIndex = 1
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
        'lblFOMUMUNI
        '
        Me.lblFOMUMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFOMUMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFOMUMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFOMUMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblFOMUMUNI.Location = New System.Drawing.Point(448, 51)
        Me.lblFOMUMUNI.Name = "lblFOMUMUNI"
        Me.lblFOMUMUNI.Size = New System.Drawing.Size(110, 20)
        Me.lblFOMUMUNI.TabIndex = 50
        '
        'cboFOMUMUNI
        '
        Me.cboFOMUMUNI.AccessibleDescription = "Municipio"
        Me.cboFOMUMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFOMUMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOMUMUNI.Enabled = False
        Me.cboFOMUMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFOMUMUNI.FormattingEnabled = True
        Me.cboFOMUMUNI.Location = New System.Drawing.Point(137, 49)
        Me.cboFOMUMUNI.Name = "cboFOMUMUNI"
        Me.cboFOMUMUNI.Size = New System.Drawing.Size(305, 22)
        Me.cboFOMUMUNI.TabIndex = 2
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
        'cboFOMUESTA
        '
        Me.cboFOMUESTA.AccessibleDescription = "Estado"
        Me.cboFOMUESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFOMUESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFOMUESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFOMUESTA.FormattingEnabled = True
        Me.cboFOMUESTA.Location = New System.Drawing.Point(137, 317)
        Me.cboFOMUESTA.Name = "cboFOMUESTA"
        Me.cboFOMUESTA.Size = New System.Drawing.Size(305, 22)
        Me.cboFOMUESTA.TabIndex = 13
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
        'frm_modificar_FORMMUNI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 455)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraFORMMUNI)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(617, 491)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(617, 491)
        Me.Name = "frm_modificar_FORMMUNI"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
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
    Friend WithEvents txtFOMUDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFOMUFORM As System.Windows.Forms.Label
    Friend WithEvents cboFOMUFORM As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblFOMUCONC As System.Windows.Forms.Label
    Friend WithEvents cboFOMUCONC As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkFOMUTAAS As System.Windows.Forms.CheckBox
    Friend WithEvents chkFOMUALPU As System.Windows.Forms.CheckBox
    Friend WithEvents chkFOMUACBO As System.Windows.Forms.CheckBox
    Friend WithEvents chkFOMUIMPR As System.Windows.Forms.CheckBox
    Friend WithEvents lblFOMUTIIM As System.Windows.Forms.Label
    Friend WithEvents cboFOMUTIIM As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblFOMUVIGE As System.Windows.Forms.Label
    Friend WithEvents cboFOMUVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents lblFOMUCLSE As System.Windows.Forms.Label
    Friend WithEvents cboFOMUCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFOMUDEPA As System.Windows.Forms.Label
    Friend WithEvents cboFOMUDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFOMUMUNI As System.Windows.Forms.Label
    Friend WithEvents cboFOMUMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cboFOMUESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
End Class
