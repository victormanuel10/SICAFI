<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_FORMMUNI
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
        Me.fraPERIODO = New System.Windows.Forms.GroupBox
        Me.txtFOMUDESC = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtFOMUFORM = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtFOMUCONC = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkFOMUTAAS = New System.Windows.Forms.CheckBox
        Me.chkFOMUALPU = New System.Windows.Forms.CheckBox
        Me.chkFOMUACBO = New System.Windows.Forms.CheckBox
        Me.chkFOMUIMPR = New System.Windows.Forms.CheckBox
        Me.txtFOMUTIIM = New System.Windows.Forms.TextBox
        Me.lblVIACVIAC = New System.Windows.Forms.Label
        Me.txtFOMUVIGE = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtFOMUCLSE = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtFOMUMUNI = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtFOMUDEPA = New System.Windows.Forms.TextBox
        Me.lblidzona = New System.Windows.Forms.Label
        Me.txtFOMUESTA = New System.Windows.Forms.TextBox
        Me.dgvCONSULTA = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
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
        Me.GroupBox1.Size = New System.Drawing.Size(881, 60)
        Me.GroupBox1.TabIndex = 77
        Me.GroupBox1.TabStop = False
        '
        'cmdSalir
        '
        Me.cmdSalir.AccessibleDescription = "Salir"
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(765, 20)
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
        Me.cmdAceptar.Location = New System.Drawing.Point(658, 20)
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
        Me.cmdConsultar.Location = New System.Drawing.Point(551, 20)
        Me.cmdConsultar.Name = "cmdConsultar"
        Me.cmdConsultar.Size = New System.Drawing.Size(101, 23)
        Me.cmdConsultar.TabIndex = 6
        Me.cmdConsultar.Text = "&Consultar"
        Me.cmdConsultar.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel4})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 474)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(906, 25)
        Me.strBARRESTA.TabIndex = 78
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
        Me.tstBAESVALI.ImageTransparentColor = System.Drawing.Color.White
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
        Me.tstBAESDESC.ForeColor = System.Drawing.Color.Black
        Me.tstBAESDESC.ImageTransparentColor = System.Drawing.Color.White
        Me.tstBAESDESC.LinkColor = System.Drawing.Color.Black
        Me.tstBAESDESC.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.tstBAESDESC.Name = "tstBAESDESC"
        Me.tstBAESDESC.Size = New System.Drawing.Size(300, 22)
        Me.tstBAESDESC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fraPERIODO
        '
        Me.fraPERIODO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraPERIODO.BackColor = System.Drawing.SystemColors.Control
        Me.fraPERIODO.Controls.Add(Me.txtFOMUDESC)
        Me.fraPERIODO.Controls.Add(Me.Label7)
        Me.fraPERIODO.Controls.Add(Me.txtFOMUFORM)
        Me.fraPERIODO.Controls.Add(Me.Label4)
        Me.fraPERIODO.Controls.Add(Me.txtFOMUCONC)
        Me.fraPERIODO.Controls.Add(Me.Label1)
        Me.fraPERIODO.Controls.Add(Me.chkFOMUTAAS)
        Me.fraPERIODO.Controls.Add(Me.chkFOMUALPU)
        Me.fraPERIODO.Controls.Add(Me.chkFOMUACBO)
        Me.fraPERIODO.Controls.Add(Me.chkFOMUIMPR)
        Me.fraPERIODO.Controls.Add(Me.txtFOMUTIIM)
        Me.fraPERIODO.Controls.Add(Me.lblVIACVIAC)
        Me.fraPERIODO.Controls.Add(Me.txtFOMUVIGE)
        Me.fraPERIODO.Controls.Add(Me.Label6)
        Me.fraPERIODO.Controls.Add(Me.txtFOMUCLSE)
        Me.fraPERIODO.Controls.Add(Me.Label5)
        Me.fraPERIODO.Controls.Add(Me.txtFOMUMUNI)
        Me.fraPERIODO.Controls.Add(Me.Label3)
        Me.fraPERIODO.Controls.Add(Me.txtFOMUDEPA)
        Me.fraPERIODO.Controls.Add(Me.lblidzona)
        Me.fraPERIODO.Controls.Add(Me.txtFOMUESTA)
        Me.fraPERIODO.Controls.Add(Me.dgvCONSULTA)
        Me.fraPERIODO.Controls.Add(Me.Label2)
        Me.fraPERIODO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPERIODO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPERIODO.Location = New System.Drawing.Point(12, 8)
        Me.fraPERIODO.Name = "fraPERIODO"
        Me.fraPERIODO.Size = New System.Drawing.Size(881, 390)
        Me.fraPERIODO.TabIndex = 76
        Me.fraPERIODO.TabStop = False
        Me.fraPERIODO.Text = "CONSULTA FORMULA MUNICIPIO"
        '
        'txtFOMUDESC
        '
        Me.txtFOMUDESC.AccessibleDescription = "Descripción"
        Me.txtFOMUDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtFOMUDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFOMUDESC.Location = New System.Drawing.Point(621, 46)
        Me.txtFOMUDESC.MaxLength = 9
        Me.txtFOMUDESC.Name = "txtFOMUDESC"
        Me.txtFOMUDESC.Size = New System.Drawing.Size(159, 20)
        Me.txtFOMUDESC.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(621, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(159, 20)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "Descripción"
        '
        'txtFOMUFORM
        '
        Me.txtFOMUFORM.AccessibleDescription = "Formula"
        Me.txtFOMUFORM.BackColor = System.Drawing.SystemColors.Window
        Me.txtFOMUFORM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFOMUFORM.Location = New System.Drawing.Point(535, 46)
        Me.txtFOMUFORM.MaxLength = 9
        Me.txtFOMUFORM.Name = "txtFOMUFORM"
        Me.txtFOMUFORM.Size = New System.Drawing.Size(83, 20)
        Me.txtFOMUFORM.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(535, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 20)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "Formula"
        '
        'txtFOMUCONC
        '
        Me.txtFOMUCONC.AccessibleDescription = "Concepto"
        Me.txtFOMUCONC.BackColor = System.Drawing.SystemColors.Window
        Me.txtFOMUCONC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFOMUCONC.Location = New System.Drawing.Point(449, 46)
        Me.txtFOMUCONC.MaxLength = 9
        Me.txtFOMUCONC.Name = "txtFOMUCONC"
        Me.txtFOMUCONC.Size = New System.Drawing.Size(83, 20)
        Me.txtFOMUCONC.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(449, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 20)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Concepto"
        '
        'chkFOMUTAAS
        '
        Me.chkFOMUTAAS.AccessibleDescription = "Tasa de aseo"
        Me.chkFOMUTAAS.AutoSize = True
        Me.chkFOMUTAAS.Checked = True
        Me.chkFOMUTAAS.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.chkFOMUTAAS.Location = New System.Drawing.Point(535, 75)
        Me.chkFOMUTAAS.Name = "chkFOMUTAAS"
        Me.chkFOMUTAAS.Size = New System.Drawing.Size(102, 19)
        Me.chkFOMUTAAS.TabIndex = 13
        Me.chkFOMUTAAS.Text = "Tasa de aseo"
        Me.chkFOMUTAAS.ThreeState = True
        Me.chkFOMUTAAS.UseVisualStyleBackColor = True
        '
        'chkFOMUALPU
        '
        Me.chkFOMUALPU.AccessibleDescription = "Alumbrado publico"
        Me.chkFOMUALPU.AutoSize = True
        Me.chkFOMUALPU.Checked = True
        Me.chkFOMUALPU.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.chkFOMUALPU.Location = New System.Drawing.Point(191, 75)
        Me.chkFOMUALPU.Name = "chkFOMUALPU"
        Me.chkFOMUALPU.Size = New System.Drawing.Size(129, 19)
        Me.chkFOMUALPU.TabIndex = 11
        Me.chkFOMUALPU.Text = "Alumbrado publico"
        Me.chkFOMUALPU.ThreeState = True
        Me.chkFOMUALPU.UseVisualStyleBackColor = True
        '
        'chkFOMUACBO
        '
        Me.chkFOMUACBO.AccessibleDescription = "Actividad bomberil"
        Me.chkFOMUACBO.AutoSize = True
        Me.chkFOMUACBO.Checked = True
        Me.chkFOMUACBO.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.chkFOMUACBO.Location = New System.Drawing.Point(363, 75)
        Me.chkFOMUACBO.Name = "chkFOMUACBO"
        Me.chkFOMUACBO.Size = New System.Drawing.Size(126, 19)
        Me.chkFOMUACBO.TabIndex = 12
        Me.chkFOMUACBO.Text = "Actividad bomberil"
        Me.chkFOMUACBO.ThreeState = True
        Me.chkFOMUACBO.UseVisualStyleBackColor = True
        '
        'chkFOMUIMPR
        '
        Me.chkFOMUIMPR.AccessibleDescription = "Impuesto predial"
        Me.chkFOMUIMPR.AutoSize = True
        Me.chkFOMUIMPR.Checked = True
        Me.chkFOMUIMPR.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.chkFOMUIMPR.Location = New System.Drawing.Point(19, 75)
        Me.chkFOMUIMPR.Name = "chkFOMUIMPR"
        Me.chkFOMUIMPR.Size = New System.Drawing.Size(119, 19)
        Me.chkFOMUIMPR.TabIndex = 10
        Me.chkFOMUIMPR.Text = "Impuesto predial"
        Me.chkFOMUIMPR.ThreeState = True
        Me.chkFOMUIMPR.UseVisualStyleBackColor = True
        '
        'txtFOMUTIIM
        '
        Me.txtFOMUTIIM.AccessibleDescription = "Tipo de impuesto"
        Me.txtFOMUTIIM.BackColor = System.Drawing.SystemColors.Window
        Me.txtFOMUTIIM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFOMUTIIM.Location = New System.Drawing.Point(363, 46)
        Me.txtFOMUTIIM.MaxLength = 9
        Me.txtFOMUTIIM.Name = "txtFOMUTIIM"
        Me.txtFOMUTIIM.Size = New System.Drawing.Size(83, 20)
        Me.txtFOMUTIIM.TabIndex = 5
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
        Me.lblVIACVIAC.Text = "Tipo impuesto"
        '
        'txtFOMUVIGE
        '
        Me.txtFOMUVIGE.AccessibleDescription = "Vigencia"
        Me.txtFOMUVIGE.BackColor = System.Drawing.SystemColors.Window
        Me.txtFOMUVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFOMUVIGE.Location = New System.Drawing.Point(277, 46)
        Me.txtFOMUVIGE.MaxLength = 9
        Me.txtFOMUVIGE.Name = "txtFOMUVIGE"
        Me.txtFOMUVIGE.Size = New System.Drawing.Size(83, 20)
        Me.txtFOMUVIGE.TabIndex = 4
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
        'txtFOMUCLSE
        '
        Me.txtFOMUCLSE.AccessibleDescription = "Sector"
        Me.txtFOMUCLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtFOMUCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFOMUCLSE.Location = New System.Drawing.Point(191, 46)
        Me.txtFOMUCLSE.MaxLength = 9
        Me.txtFOMUCLSE.Name = "txtFOMUCLSE"
        Me.txtFOMUCLSE.Size = New System.Drawing.Size(83, 20)
        Me.txtFOMUCLSE.TabIndex = 3
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
        'txtFOMUMUNI
        '
        Me.txtFOMUMUNI.AccessibleDescription = "Municipio"
        Me.txtFOMUMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtFOMUMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFOMUMUNI.Location = New System.Drawing.Point(105, 46)
        Me.txtFOMUMUNI.MaxLength = 9
        Me.txtFOMUMUNI.Name = "txtFOMUMUNI"
        Me.txtFOMUMUNI.Size = New System.Drawing.Size(83, 20)
        Me.txtFOMUMUNI.TabIndex = 2
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
        'txtFOMUDEPA
        '
        Me.txtFOMUDEPA.AccessibleDescription = "Departamento"
        Me.txtFOMUDEPA.BackColor = System.Drawing.SystemColors.Window
        Me.txtFOMUDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFOMUDEPA.Location = New System.Drawing.Point(19, 46)
        Me.txtFOMUDEPA.MaxLength = 9
        Me.txtFOMUDEPA.Name = "txtFOMUDEPA"
        Me.txtFOMUDEPA.Size = New System.Drawing.Size(83, 20)
        Me.txtFOMUDEPA.TabIndex = 1
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
        'txtFOMUESTA
        '
        Me.txtFOMUESTA.AccessibleDescription = "Estado"
        Me.txtFOMUESTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtFOMUESTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtFOMUESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFOMUESTA.Location = New System.Drawing.Point(783, 46)
        Me.txtFOMUESTA.MaxLength = 9
        Me.txtFOMUESTA.Name = "txtFOMUESTA"
        Me.txtFOMUESTA.Size = New System.Drawing.Size(83, 20)
        Me.txtFOMUESTA.TabIndex = 9
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
        Me.dgvCONSULTA.Location = New System.Drawing.Point(19, 106)
        Me.dgvCONSULTA.MultiSelect = False
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        Me.dgvCONSULTA.RowHeadersVisible = False
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(847, 268)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(783, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Estado"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.AutoSize = False
        Me.ToolStripStatusLabel4.BackColor = System.Drawing.SystemColors.Window
        Me.ToolStripStatusLabel4.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel4.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel4.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripStatusLabel4.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(125, 22)
        Me.ToolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frm_consultar_FORMMUNI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 499)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraPERIODO)
        Me.Name = "frm_consultar_FORMMUNI"
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
    Friend WithEvents fraPERIODO As System.Windows.Forms.GroupBox
    Friend WithEvents chkFOMUTAAS As System.Windows.Forms.CheckBox
    Friend WithEvents chkFOMUALPU As System.Windows.Forms.CheckBox
    Friend WithEvents chkFOMUACBO As System.Windows.Forms.CheckBox
    Friend WithEvents chkFOMUIMPR As System.Windows.Forms.CheckBox
    Friend WithEvents txtFOMUTIIM As System.Windows.Forms.TextBox
    Friend WithEvents lblVIACVIAC As System.Windows.Forms.Label
    Friend WithEvents txtFOMUVIGE As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFOMUCLSE As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFOMUMUNI As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFOMUDEPA As System.Windows.Forms.TextBox
    Friend WithEvents lblidzona As System.Windows.Forms.Label
    Friend WithEvents txtFOMUESTA As System.Windows.Forms.TextBox
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFOMUCONC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFOMUFORM As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFOMUDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
End Class
