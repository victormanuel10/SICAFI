<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_PREDEXNI
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdSalir = New System.Windows.Forms.Button
        Me.cmdLimpiar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.cmdConsultar = New System.Windows.Forms.Button
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.fraPERIODO = New System.Windows.Forms.GroupBox
        Me.txtPRENDESC = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtPRENCAPR = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPRENNUDO = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtPRENCONC = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPRENTIIM = New System.Windows.Forms.TextBox
        Me.lblVIACVIAC = New System.Windows.Forms.Label
        Me.txtPRENTIDO = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtPRENCLSE = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPRENMUNI = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPRENDEPA = New System.Windows.Forms.TextBox
        Me.lblidzona = New System.Windows.Forms.Label
        Me.txtPRENESTA = New System.Windows.Forms.TextBox
        Me.dgvCONSULTA = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPRENSEXO = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
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
        Me.GroupBox1.Location = New System.Drawing.Point(13, 405)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(722, 60)
        Me.GroupBox1.TabIndex = 83
        Me.GroupBox1.TabStop = False
        '
        'cmdSalir
        '
        Me.cmdSalir.AccessibleDescription = "Salir"
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(606, 20)
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
        Me.cmdAceptar.Location = New System.Drawing.Point(499, 20)
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
        Me.cmdConsultar.Location = New System.Drawing.Point(392, 20)
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
        Me.strBARRESTA.Size = New System.Drawing.Size(747, 25)
        Me.strBARRESTA.TabIndex = 84
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
        'fraPERIODO
        '
        Me.fraPERIODO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraPERIODO.BackColor = System.Drawing.SystemColors.Control
        Me.fraPERIODO.Controls.Add(Me.txtPRENSEXO)
        Me.fraPERIODO.Controls.Add(Me.Label12)
        Me.fraPERIODO.Controls.Add(Me.txtPRENDESC)
        Me.fraPERIODO.Controls.Add(Me.Label11)
        Me.fraPERIODO.Controls.Add(Me.txtPRENCAPR)
        Me.fraPERIODO.Controls.Add(Me.Label9)
        Me.fraPERIODO.Controls.Add(Me.txtPRENNUDO)
        Me.fraPERIODO.Controls.Add(Me.Label8)
        Me.fraPERIODO.Controls.Add(Me.txtPRENCONC)
        Me.fraPERIODO.Controls.Add(Me.Label1)
        Me.fraPERIODO.Controls.Add(Me.txtPRENTIIM)
        Me.fraPERIODO.Controls.Add(Me.lblVIACVIAC)
        Me.fraPERIODO.Controls.Add(Me.txtPRENTIDO)
        Me.fraPERIODO.Controls.Add(Me.Label6)
        Me.fraPERIODO.Controls.Add(Me.txtPRENCLSE)
        Me.fraPERIODO.Controls.Add(Me.Label5)
        Me.fraPERIODO.Controls.Add(Me.txtPRENMUNI)
        Me.fraPERIODO.Controls.Add(Me.Label3)
        Me.fraPERIODO.Controls.Add(Me.txtPRENDEPA)
        Me.fraPERIODO.Controls.Add(Me.lblidzona)
        Me.fraPERIODO.Controls.Add(Me.txtPRENESTA)
        Me.fraPERIODO.Controls.Add(Me.dgvCONSULTA)
        Me.fraPERIODO.Controls.Add(Me.Label2)
        Me.fraPERIODO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPERIODO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPERIODO.Location = New System.Drawing.Point(13, 12)
        Me.fraPERIODO.Name = "fraPERIODO"
        Me.fraPERIODO.Size = New System.Drawing.Size(722, 390)
        Me.fraPERIODO.TabIndex = 82
        Me.fraPERIODO.TabStop = False
        Me.fraPERIODO.Text = "CONSULTA PREDIOS EXENTOS POR NIT"
        '
        'txtPRENDESC
        '
        Me.txtPRENDESC.AccessibleDescription = "Observación"
        Me.txtPRENDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtPRENDESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtPRENDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRENDESC.Location = New System.Drawing.Point(191, 92)
        Me.txtPRENDESC.MaxLength = 100
        Me.txtPRENDESC.Name = "txtPRENDESC"
        Me.txtPRENDESC.Size = New System.Drawing.Size(427, 20)
        Me.txtPRENDESC.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(191, 69)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(427, 20)
        Me.Label11.TabIndex = 80
        Me.Label11.Text = "Descripción"
        '
        'txtPRENCAPR
        '
        Me.txtPRENCAPR.AccessibleDescription = "Vigencia"
        Me.txtPRENCAPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtPRENCAPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRENCAPR.Location = New System.Drawing.Point(535, 46)
        Me.txtPRENCAPR.MaxLength = 9
        Me.txtPRENCAPR.Name = "txtPRENCAPR"
        Me.txtPRENCAPR.Size = New System.Drawing.Size(83, 20)
        Me.txtPRENCAPR.TabIndex = 7
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
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "Cal. Propieta."
        '
        'txtPRENNUDO
        '
        Me.txtPRENNUDO.AccessibleDescription = "Nro. de Ficha"
        Me.txtPRENNUDO.BackColor = System.Drawing.SystemColors.Window
        Me.txtPRENNUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRENNUDO.Location = New System.Drawing.Point(19, 92)
        Me.txtPRENNUDO.MaxLength = 9
        Me.txtPRENNUDO.Name = "txtPRENNUDO"
        Me.txtPRENNUDO.Size = New System.Drawing.Size(169, 20)
        Me.txtPRENNUDO.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(19, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(169, 20)
        Me.Label8.TabIndex = 74
        Me.Label8.Text = "Nro. Documento"
        '
        'txtPRENCONC
        '
        Me.txtPRENCONC.AccessibleDescription = "Concepto"
        Me.txtPRENCONC.BackColor = System.Drawing.SystemColors.Window
        Me.txtPRENCONC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRENCONC.Location = New System.Drawing.Point(363, 46)
        Me.txtPRENCONC.MaxLength = 9
        Me.txtPRENCONC.Name = "txtPRENCONC"
        Me.txtPRENCONC.Size = New System.Drawing.Size(83, 20)
        Me.txtPRENCONC.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(363, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 20)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Concepto"
        '
        'txtPRENTIIM
        '
        Me.txtPRENTIIM.AccessibleDescription = "Tipo de impuesto"
        Me.txtPRENTIIM.BackColor = System.Drawing.SystemColors.Window
        Me.txtPRENTIIM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRENTIIM.Location = New System.Drawing.Point(277, 46)
        Me.txtPRENTIIM.MaxLength = 9
        Me.txtPRENTIIM.Name = "txtPRENTIIM"
        Me.txtPRENTIIM.Size = New System.Drawing.Size(83, 20)
        Me.txtPRENTIIM.TabIndex = 4
        '
        'lblVIACVIAC
        '
        Me.lblVIACVIAC.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblVIACVIAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVIACVIAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVIACVIAC.ForeColor = System.Drawing.Color.Black
        Me.lblVIACVIAC.Location = New System.Drawing.Point(277, 23)
        Me.lblVIACVIAC.Name = "lblVIACVIAC"
        Me.lblVIACVIAC.Size = New System.Drawing.Size(83, 20)
        Me.lblVIACVIAC.TabIndex = 60
        Me.lblVIACVIAC.Text = "Tipo impuesto"
        '
        'txtPRENTIDO
        '
        Me.txtPRENTIDO.AccessibleDescription = "Vigencia"
        Me.txtPRENTIDO.BackColor = System.Drawing.SystemColors.Window
        Me.txtPRENTIDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRENTIDO.Location = New System.Drawing.Point(449, 46)
        Me.txtPRENTIDO.MaxLength = 9
        Me.txtPRENTIDO.Name = "txtPRENTIDO"
        Me.txtPRENTIDO.Size = New System.Drawing.Size(83, 20)
        Me.txtPRENTIDO.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(449, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 20)
        Me.Label6.TabIndex = 56
        Me.Label6.Text = "Tipo Document."
        '
        'txtPRENCLSE
        '
        Me.txtPRENCLSE.AccessibleDescription = "Sector"
        Me.txtPRENCLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtPRENCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRENCLSE.Location = New System.Drawing.Point(191, 46)
        Me.txtPRENCLSE.MaxLength = 9
        Me.txtPRENCLSE.Name = "txtPRENCLSE"
        Me.txtPRENCLSE.Size = New System.Drawing.Size(83, 20)
        Me.txtPRENCLSE.TabIndex = 3
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
        'txtPRENMUNI
        '
        Me.txtPRENMUNI.AccessibleDescription = "Municipio"
        Me.txtPRENMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtPRENMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRENMUNI.Location = New System.Drawing.Point(105, 46)
        Me.txtPRENMUNI.MaxLength = 9
        Me.txtPRENMUNI.Name = "txtPRENMUNI"
        Me.txtPRENMUNI.Size = New System.Drawing.Size(83, 20)
        Me.txtPRENMUNI.TabIndex = 2
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
        'txtPRENDEPA
        '
        Me.txtPRENDEPA.AccessibleDescription = "Departamento"
        Me.txtPRENDEPA.BackColor = System.Drawing.SystemColors.Window
        Me.txtPRENDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRENDEPA.Location = New System.Drawing.Point(19, 46)
        Me.txtPRENDEPA.MaxLength = 9
        Me.txtPRENDEPA.Name = "txtPRENDEPA"
        Me.txtPRENDEPA.Size = New System.Drawing.Size(83, 20)
        Me.txtPRENDEPA.TabIndex = 1
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
        'txtPRENESTA
        '
        Me.txtPRENESTA.AccessibleDescription = "Estado"
        Me.txtPRENESTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtPRENESTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtPRENESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRENESTA.Location = New System.Drawing.Point(621, 92)
        Me.txtPRENESTA.MaxLength = 9
        Me.txtPRENESTA.Name = "txtPRENESTA"
        Me.txtPRENESTA.Size = New System.Drawing.Size(83, 20)
        Me.txtPRENESTA.TabIndex = 11
        '
        'dgvCONSULTA
        '
        Me.dgvCONSULTA.AccessibleDescription = ""
        Me.dgvCONSULTA.AllowUserToAddRows = False
        Me.dgvCONSULTA.AllowUserToDeleteRows = False
        Me.dgvCONSULTA.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
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
        Me.dgvCONSULTA.Size = New System.Drawing.Size(684, 253)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(621, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Estado"
        '
        'txtPRENSEXO
        '
        Me.txtPRENSEXO.AccessibleDescription = "Vigencia"
        Me.txtPRENSEXO.BackColor = System.Drawing.SystemColors.Window
        Me.txtPRENSEXO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRENSEXO.Location = New System.Drawing.Point(621, 46)
        Me.txtPRENSEXO.MaxLength = 9
        Me.txtPRENSEXO.Name = "txtPRENSEXO"
        Me.txtPRENSEXO.Size = New System.Drawing.Size(83, 20)
        Me.txtPRENSEXO.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(621, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 20)
        Me.Label12.TabIndex = 82
        Me.Label12.Text = "Sexo"
        '
        'frm_consultar_PREDEXNI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 499)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraPERIODO)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(763, 535)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(763, 535)
        Me.Name = "frm_consultar_PREDEXNI"
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
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraPERIODO As System.Windows.Forms.GroupBox
    Friend WithEvents txtPRENDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPRENCAPR As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPRENNUDO As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPRENCONC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPRENTIIM As System.Windows.Forms.TextBox
    Friend WithEvents lblVIACVIAC As System.Windows.Forms.Label
    Friend WithEvents txtPRENTIDO As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPRENCLSE As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPRENMUNI As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPRENDEPA As System.Windows.Forms.TextBox
    Friend WithEvents lblidzona As System.Windows.Forms.Label
    Friend WithEvents txtPRENESTA As System.Windows.Forms.TextBox
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPRENSEXO As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
