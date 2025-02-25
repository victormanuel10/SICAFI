<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_DEECLOTE
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
        Me.fraDEECLOTE = New System.Windows.Forms.GroupBox
        Me.chkDELOTAAS = New System.Windows.Forms.CheckBox
        Me.chkDELOALPU = New System.Windows.Forms.CheckBox
        Me.chkDELOACBO = New System.Windows.Forms.CheckBox
        Me.chkDELOIMPR = New System.Windows.Forms.CheckBox
        Me.chkDELOLE44 = New System.Windows.Forms.CheckBox
        Me.chkDELOLOTE = New System.Windows.Forms.CheckBox
        Me.lblDELODEEC = New System.Windows.Forms.Label
        Me.cboDELODEEC = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblDELOVIGE = New System.Windows.Forms.Label
        Me.cboDELOVIGE = New System.Windows.Forms.ComboBox
        Me.lblDELOCLSE = New System.Windows.Forms.Label
        Me.cboDELOCLSE = New System.Windows.Forms.ComboBox
        Me.lblClaseosector = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblDELODEPA = New System.Windows.Forms.Label
        Me.cboDELODEPA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblDELOMUNI = New System.Windows.Forms.Label
        Me.cboDELOMUNI = New System.Windows.Forms.ComboBox
        Me.lblMUNICIPIO = New System.Windows.Forms.Label
        Me.cboDELOESTA = New System.Windows.Forms.ComboBox
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraDEECLOTE.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 358)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 424)
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
        'fraDEECLOTE
        '
        Me.fraDEECLOTE.BackColor = System.Drawing.SystemColors.Control
        Me.fraDEECLOTE.Controls.Add(Me.chkDELOTAAS)
        Me.fraDEECLOTE.Controls.Add(Me.chkDELOALPU)
        Me.fraDEECLOTE.Controls.Add(Me.chkDELOACBO)
        Me.fraDEECLOTE.Controls.Add(Me.chkDELOIMPR)
        Me.fraDEECLOTE.Controls.Add(Me.chkDELOLE44)
        Me.fraDEECLOTE.Controls.Add(Me.chkDELOLOTE)
        Me.fraDEECLOTE.Controls.Add(Me.lblDELODEEC)
        Me.fraDEECLOTE.Controls.Add(Me.cboDELODEEC)
        Me.fraDEECLOTE.Controls.Add(Me.Label11)
        Me.fraDEECLOTE.Controls.Add(Me.lblDELOVIGE)
        Me.fraDEECLOTE.Controls.Add(Me.cboDELOVIGE)
        Me.fraDEECLOTE.Controls.Add(Me.lblDELOCLSE)
        Me.fraDEECLOTE.Controls.Add(Me.cboDELOCLSE)
        Me.fraDEECLOTE.Controls.Add(Me.lblClaseosector)
        Me.fraDEECLOTE.Controls.Add(Me.Label3)
        Me.fraDEECLOTE.Controls.Add(Me.lblDELODEPA)
        Me.fraDEECLOTE.Controls.Add(Me.cboDELODEPA)
        Me.fraDEECLOTE.Controls.Add(Me.Label4)
        Me.fraDEECLOTE.Controls.Add(Me.lblDELOMUNI)
        Me.fraDEECLOTE.Controls.Add(Me.cboDELOMUNI)
        Me.fraDEECLOTE.Controls.Add(Me.lblMUNICIPIO)
        Me.fraDEECLOTE.Controls.Add(Me.cboDELOESTA)
        Me.fraDEECLOTE.Controls.Add(Me.lblCodigo)
        Me.fraDEECLOTE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraDEECLOTE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraDEECLOTE.Location = New System.Drawing.Point(12, 7)
        Me.fraDEECLOTE.Name = "fraDEECLOTE"
        Me.fraDEECLOTE.Size = New System.Drawing.Size(572, 345)
        Me.fraDEECLOTE.TabIndex = 49
        Me.fraDEECLOTE.TabStop = False
        Me.fraDEECLOTE.Text = "MODIFICAR DESTINACION ECONÓMICA POR LOTES"
        '
        'chkDELOTAAS
        '
        Me.chkDELOTAAS.AccessibleDescription = "Tasa de aseo"
        Me.chkDELOTAAS.AutoSize = True
        Me.chkDELOTAAS.Location = New System.Drawing.Point(19, 274)
        Me.chkDELOTAAS.Name = "chkDELOTAAS"
        Me.chkDELOTAAS.Size = New System.Drawing.Size(102, 19)
        Me.chkDELOTAAS.TabIndex = 11
        Me.chkDELOTAAS.Text = "Tasa de aseo"
        Me.chkDELOTAAS.UseVisualStyleBackColor = True
        '
        'chkDELOALPU
        '
        Me.chkDELOALPU.AccessibleDescription = "Alumbrado publico"
        Me.chkDELOALPU.AutoSize = True
        Me.chkDELOALPU.Location = New System.Drawing.Point(19, 249)
        Me.chkDELOALPU.Name = "chkDELOALPU"
        Me.chkDELOALPU.Size = New System.Drawing.Size(129, 19)
        Me.chkDELOALPU.TabIndex = 10
        Me.chkDELOALPU.Text = "Alumbrado publico"
        Me.chkDELOALPU.UseVisualStyleBackColor = True
        '
        'chkDELOACBO
        '
        Me.chkDELOACBO.AccessibleDescription = "Actividad bomberil"
        Me.chkDELOACBO.AutoSize = True
        Me.chkDELOACBO.Location = New System.Drawing.Point(19, 224)
        Me.chkDELOACBO.Name = "chkDELOACBO"
        Me.chkDELOACBO.Size = New System.Drawing.Size(126, 19)
        Me.chkDELOACBO.TabIndex = 9
        Me.chkDELOACBO.Text = "Actividad bomberil"
        Me.chkDELOACBO.UseVisualStyleBackColor = True
        '
        'chkDELOIMPR
        '
        Me.chkDELOIMPR.AccessibleDescription = "Impuesto predial"
        Me.chkDELOIMPR.AutoSize = True
        Me.chkDELOIMPR.Location = New System.Drawing.Point(19, 199)
        Me.chkDELOIMPR.Name = "chkDELOIMPR"
        Me.chkDELOIMPR.Size = New System.Drawing.Size(119, 19)
        Me.chkDELOIMPR.TabIndex = 8
        Me.chkDELOIMPR.Text = "Impuesto predial"
        Me.chkDELOIMPR.UseVisualStyleBackColor = True
        '
        'chkDELOLE44
        '
        Me.chkDELOLE44.AccessibleDescription = "Ley 44"
        Me.chkDELOLE44.AutoSize = True
        Me.chkDELOLE44.Location = New System.Drawing.Point(19, 174)
        Me.chkDELOLE44.Name = "chkDELOLE44"
        Me.chkDELOLE44.Size = New System.Drawing.Size(62, 19)
        Me.chkDELOLE44.TabIndex = 7
        Me.chkDELOLE44.Text = "Ley 44"
        Me.chkDELOLE44.UseVisualStyleBackColor = True
        '
        'chkDELOLOTE
        '
        Me.chkDELOLOTE.AccessibleDescription = "Lote"
        Me.chkDELOLOTE.AutoSize = True
        Me.chkDELOLOTE.Location = New System.Drawing.Point(19, 149)
        Me.chkDELOLOTE.Name = "chkDELOLOTE"
        Me.chkDELOLOTE.Size = New System.Drawing.Size(50, 19)
        Me.chkDELOLOTE.TabIndex = 6
        Me.chkDELOLOTE.Text = "Lote"
        Me.chkDELOLOTE.UseVisualStyleBackColor = True
        '
        'lblDELODEEC
        '
        Me.lblDELODEEC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDELODEEC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDELODEEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDELODEEC.ForeColor = System.Drawing.Color.Black
        Me.lblDELODEEC.Location = New System.Drawing.Point(442, 120)
        Me.lblDELODEEC.Name = "lblDELODEEC"
        Me.lblDELODEEC.Size = New System.Drawing.Size(116, 20)
        Me.lblDELODEEC.TabIndex = 78
        '
        'cboDELODEEC
        '
        Me.cboDELODEEC.AccessibleDescription = "Destinación"
        Me.cboDELODEEC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDELODEEC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDELODEEC.Enabled = False
        Me.cboDELODEEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDELODEEC.FormattingEnabled = True
        Me.cboDELODEEC.Location = New System.Drawing.Point(137, 118)
        Me.cboDELODEEC.Name = "cboDELODEEC"
        Me.cboDELODEEC.Size = New System.Drawing.Size(299, 22)
        Me.cboDELODEEC.TabIndex = 5
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
        Me.Label11.Text = "Destino Económico"
        '
        'lblDELOVIGE
        '
        Me.lblDELOVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDELOVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDELOVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDELOVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblDELOVIGE.Location = New System.Drawing.Point(442, 97)
        Me.lblDELOVIGE.Name = "lblDELOVIGE"
        Me.lblDELOVIGE.Size = New System.Drawing.Size(116, 20)
        Me.lblDELOVIGE.TabIndex = 62
        '
        'cboDELOVIGE
        '
        Me.cboDELOVIGE.AccessibleDescription = "Vigencia"
        Me.cboDELOVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDELOVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDELOVIGE.Enabled = False
        Me.cboDELOVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDELOVIGE.FormattingEnabled = True
        Me.cboDELOVIGE.Location = New System.Drawing.Point(137, 95)
        Me.cboDELOVIGE.Name = "cboDELOVIGE"
        Me.cboDELOVIGE.Size = New System.Drawing.Size(299, 22)
        Me.cboDELOVIGE.TabIndex = 4
        '
        'lblDELOCLSE
        '
        Me.lblDELOCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDELOCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDELOCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDELOCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblDELOCLSE.Location = New System.Drawing.Point(442, 74)
        Me.lblDELOCLSE.Name = "lblDELOCLSE"
        Me.lblDELOCLSE.Size = New System.Drawing.Size(116, 20)
        Me.lblDELOCLSE.TabIndex = 57
        '
        'cboDELOCLSE
        '
        Me.cboDELOCLSE.AccessibleDescription = "Clase o sector"
        Me.cboDELOCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDELOCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDELOCLSE.Enabled = False
        Me.cboDELOCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDELOCLSE.FormattingEnabled = True
        Me.cboDELOCLSE.Location = New System.Drawing.Point(137, 72)
        Me.cboDELOCLSE.Name = "cboDELOCLSE"
        Me.cboDELOCLSE.Size = New System.Drawing.Size(299, 22)
        Me.cboDELOCLSE.TabIndex = 3
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
        Me.Label3.Location = New System.Drawing.Point(19, 305)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'lblDELODEPA
        '
        Me.lblDELODEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDELODEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDELODEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDELODEPA.ForeColor = System.Drawing.Color.Black
        Me.lblDELODEPA.Location = New System.Drawing.Point(442, 28)
        Me.lblDELODEPA.Name = "lblDELODEPA"
        Me.lblDELODEPA.Size = New System.Drawing.Size(116, 20)
        Me.lblDELODEPA.TabIndex = 52
        '
        'cboDELODEPA
        '
        Me.cboDELODEPA.AccessibleDescription = "Departamento"
        Me.cboDELODEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDELODEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDELODEPA.Enabled = False
        Me.cboDELODEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDELODEPA.FormattingEnabled = True
        Me.cboDELODEPA.Location = New System.Drawing.Point(137, 26)
        Me.cboDELODEPA.Name = "cboDELODEPA"
        Me.cboDELODEPA.Size = New System.Drawing.Size(299, 22)
        Me.cboDELODEPA.TabIndex = 1
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
        'lblDELOMUNI
        '
        Me.lblDELOMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDELOMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDELOMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDELOMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblDELOMUNI.Location = New System.Drawing.Point(442, 51)
        Me.lblDELOMUNI.Name = "lblDELOMUNI"
        Me.lblDELOMUNI.Size = New System.Drawing.Size(116, 20)
        Me.lblDELOMUNI.TabIndex = 50
        '
        'cboDELOMUNI
        '
        Me.cboDELOMUNI.AccessibleDescription = "Municipio"
        Me.cboDELOMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDELOMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDELOMUNI.Enabled = False
        Me.cboDELOMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDELOMUNI.FormattingEnabled = True
        Me.cboDELOMUNI.Location = New System.Drawing.Point(137, 49)
        Me.cboDELOMUNI.Name = "cboDELOMUNI"
        Me.cboDELOMUNI.Size = New System.Drawing.Size(299, 22)
        Me.cboDELOMUNI.TabIndex = 2
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
        'cboDELOESTA
        '
        Me.cboDELOESTA.AccessibleDescription = "Estado"
        Me.cboDELOESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDELOESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDELOESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDELOESTA.FormattingEnabled = True
        Me.cboDELOESTA.Location = New System.Drawing.Point(137, 306)
        Me.cboDELOESTA.Name = "cboDELOESTA"
        Me.cboDELOESTA.Size = New System.Drawing.Size(299, 22)
        Me.cboDELOESTA.TabIndex = 12
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
        'frm_modificar_DEECLOTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 449)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraDEECLOTE)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(617, 485)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(617, 485)
        Me.Name = "frm_modificar_DEECLOTE"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraDEECLOTE.ResumeLayout(False)
        Me.fraDEECLOTE.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraDEECLOTE As System.Windows.Forms.GroupBox
    Friend WithEvents chkDELOTAAS As System.Windows.Forms.CheckBox
    Friend WithEvents chkDELOALPU As System.Windows.Forms.CheckBox
    Friend WithEvents chkDELOACBO As System.Windows.Forms.CheckBox
    Friend WithEvents chkDELOIMPR As System.Windows.Forms.CheckBox
    Friend WithEvents chkDELOLE44 As System.Windows.Forms.CheckBox
    Friend WithEvents chkDELOLOTE As System.Windows.Forms.CheckBox
    Friend WithEvents lblDELODEEC As System.Windows.Forms.Label
    Friend WithEvents cboDELODEEC As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblDELOVIGE As System.Windows.Forms.Label
    Friend WithEvents cboDELOVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents lblDELOCLSE As System.Windows.Forms.Label
    Friend WithEvents cboDELOCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblDELODEPA As System.Windows.Forms.Label
    Friend WithEvents cboDELODEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblDELOMUNI As System.Windows.Forms.Label
    Friend WithEvents cboDELOMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cboDELOESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
End Class
