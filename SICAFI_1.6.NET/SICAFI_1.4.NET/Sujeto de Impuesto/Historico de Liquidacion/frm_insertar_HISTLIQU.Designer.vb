<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_HISTLIQU
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
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.cboHILIESTA = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtHILIPUNT = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtHILIARCO = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtHILIARTE = New System.Windows.Forms.TextBox
        Me.chkHILIAUAV = New System.Windows.Forms.CheckBox
        Me.chkHILILE56 = New System.Windows.Forms.CheckBox
        Me.chkHILILE44 = New System.Windows.Forms.CheckBox
        Me.chkHILILOCE = New System.Windows.Forms.CheckBox
        Me.chkHILILOTE = New System.Windows.Forms.CheckBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblHILITIPO = New System.Windows.Forms.Label
        Me.cboHILITIPO = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblHILIESTR = New System.Windows.Forms.Label
        Me.cboHILIESTR = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblHILIDEEC = New System.Windows.Forms.Label
        Me.cboHILIDEEC = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtHILIAVCA = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblHILIVIGE = New System.Windows.Forms.Label
        Me.cboHILIVIGE = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtHILIAVPR = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.cmdGUARDAR = New System.Windows.Forms.Button
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 320)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(777, 25)
        Me.strBARRESTA.TabIndex = 62
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
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cboHILIESTA)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.txtHILIPUNT)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.txtHILIARCO)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.txtHILIARTE)
        Me.GroupBox5.Controls.Add(Me.chkHILIAUAV)
        Me.GroupBox5.Controls.Add(Me.chkHILILE56)
        Me.GroupBox5.Controls.Add(Me.chkHILILE44)
        Me.GroupBox5.Controls.Add(Me.chkHILILOCE)
        Me.GroupBox5.Controls.Add(Me.chkHILILOTE)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.lblHILITIPO)
        Me.GroupBox5.Controls.Add(Me.cboHILITIPO)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.lblHILIESTR)
        Me.GroupBox5.Controls.Add(Me.cboHILIESTR)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.lblHILIDEEC)
        Me.GroupBox5.Controls.Add(Me.cboHILIDEEC)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.txtHILIAVCA)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.lblHILIVIGE)
        Me.GroupBox5.Controls.Add(Me.cboHILIVIGE)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.txtHILIAVPR)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(748, 232)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "INSERTAR HISTORICO DE LIQUIDACIÓN"
        '
        'cboHILIESTA
        '
        Me.cboHILIESTA.AccessibleDescription = "Estado"
        Me.cboHILIESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboHILIESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHILIESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHILIESTA.FormattingEnabled = True
        Me.cboHILIESTA.Location = New System.Drawing.Point(553, 191)
        Me.cboHILIESTA.Name = "cboHILIESTA"
        Me.cboHILIESTA.Size = New System.Drawing.Size(175, 22)
        Me.cboHILIESTA.TabIndex = 15
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(553, 168)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(175, 20)
        Me.Label18.TabIndex = 83
        Me.Label18.Text = "Estado"
        '
        'txtHILIPUNT
        '
        Me.txtHILIPUNT.AccessibleDescription = "Puntos"
        Me.txtHILIPUNT.BackColor = System.Drawing.SystemColors.Window
        Me.txtHILIPUNT.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHILIPUNT.Location = New System.Drawing.Point(407, 190)
        Me.txtHILIPUNT.MaxLength = 2
        Me.txtHILIPUNT.Name = "txtHILIPUNT"
        Me.txtHILIPUNT.Size = New System.Drawing.Size(143, 20)
        Me.txtHILIPUNT.TabIndex = 14
        Me.txtHILIPUNT.Text = "0"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(407, 167)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(143, 20)
        Me.Label17.TabIndex = 81
        Me.Label17.Text = "Puntos"
        '
        'txtHILIARCO
        '
        Me.txtHILIARCO.AccessibleDescription = "Area de construcción"
        Me.txtHILIARCO.BackColor = System.Drawing.SystemColors.Window
        Me.txtHILIARCO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHILIARCO.Location = New System.Drawing.Point(553, 48)
        Me.txtHILIARCO.MaxLength = 2
        Me.txtHILIARCO.Name = "txtHILIARCO"
        Me.txtHILIARCO.Size = New System.Drawing.Size(175, 20)
        Me.txtHILIARCO.TabIndex = 4
        Me.txtHILIARCO.Text = "0"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(553, 25)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(175, 20)
        Me.Label15.TabIndex = 79
        Me.Label15.Text = "Area de construcción mts2"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(375, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(175, 20)
        Me.Label16.TabIndex = 78
        Me.Label16.Text = "Area de terreno mts2"
        '
        'txtHILIARTE
        '
        Me.txtHILIARTE.AccessibleDescription = "Area de terreno"
        Me.txtHILIARTE.BackColor = System.Drawing.SystemColors.Window
        Me.txtHILIARTE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHILIARTE.Location = New System.Drawing.Point(375, 48)
        Me.txtHILIARTE.MaxLength = 2
        Me.txtHILIARTE.Name = "txtHILIARTE"
        Me.txtHILIARTE.Size = New System.Drawing.Size(175, 20)
        Me.txtHILIARTE.TabIndex = 3
        Me.txtHILIARTE.Text = "0"
        '
        'chkHILIAUAV
        '
        Me.chkHILIAUAV.AccessibleDescription = "Autoavalúo"
        Me.chkHILIAUAV.AutoSize = True
        Me.chkHILIAUAV.Location = New System.Drawing.Point(356, 191)
        Me.chkHILIAUAV.Name = "chkHILIAUAV"
        Me.chkHILIAUAV.Size = New System.Drawing.Size(15, 14)
        Me.chkHILIAUAV.TabIndex = 13
        Me.chkHILIAUAV.UseVisualStyleBackColor = True
        '
        'chkHILILE56
        '
        Me.chkHILILE56.AccessibleDescription = "Ley 56"
        Me.chkHILILE56.AutoSize = True
        Me.chkHILILE56.Location = New System.Drawing.Point(281, 191)
        Me.chkHILILE56.Name = "chkHILILE56"
        Me.chkHILILE56.Size = New System.Drawing.Size(15, 14)
        Me.chkHILILE56.TabIndex = 12
        Me.chkHILILE56.UseVisualStyleBackColor = True
        '
        'chkHILILE44
        '
        Me.chkHILILE44.AccessibleDescription = "Ley 44"
        Me.chkHILILE44.AutoSize = True
        Me.chkHILILE44.Location = New System.Drawing.Point(205, 191)
        Me.chkHILILE44.Name = "chkHILILE44"
        Me.chkHILILE44.Size = New System.Drawing.Size(15, 14)
        Me.chkHILILE44.TabIndex = 11
        Me.chkHILILE44.UseVisualStyleBackColor = True
        '
        'chkHILILOCE
        '
        Me.chkHILILOCE.AccessibleDescription = "Lote cercado"
        Me.chkHILILOCE.AutoSize = True
        Me.chkHILILOCE.Location = New System.Drawing.Point(126, 191)
        Me.chkHILILOCE.Name = "chkHILILOCE"
        Me.chkHILILOCE.Size = New System.Drawing.Size(15, 14)
        Me.chkHILILOCE.TabIndex = 10
        Me.chkHILILOCE.UseVisualStyleBackColor = True
        '
        'chkHILILOTE
        '
        Me.chkHILILOTE.AccessibleDescription = "Lote"
        Me.chkHILILOTE.AutoSize = True
        Me.chkHILILOTE.Location = New System.Drawing.Point(46, 191)
        Me.chkHILILOTE.Name = "chkHILILOTE"
        Me.chkHILILOTE.Size = New System.Drawing.Size(15, 14)
        Me.chkHILILOTE.TabIndex = 9
        Me.chkHILILOTE.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(332, 168)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 20)
        Me.Label14.TabIndex = 71
        Me.Label14.Text = "Autoavalúo"
        '
        'lblHILITIPO
        '
        Me.lblHILITIPO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblHILITIPO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHILITIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHILITIPO.ForeColor = System.Drawing.Color.Black
        Me.lblHILITIPO.Location = New System.Drawing.Point(473, 143)
        Me.lblHILITIPO.Name = "lblHILITIPO"
        Me.lblHILITIPO.Size = New System.Drawing.Size(255, 20)
        Me.lblHILITIPO.TabIndex = 70
        '
        'cboHILITIPO
        '
        Me.cboHILITIPO.AccessibleDescription = "Tipo de calificación"
        Me.cboHILITIPO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboHILITIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHILITIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHILITIPO.FormattingEnabled = True
        Me.cboHILITIPO.Location = New System.Drawing.Point(375, 142)
        Me.cboHILITIPO.Name = "cboHILITIPO"
        Me.cboHILITIPO.Size = New System.Drawing.Size(92, 22)
        Me.cboHILITIPO.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(375, 119)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(353, 20)
        Me.Label13.TabIndex = 69
        Me.Label13.Text = "Tipo de calificación"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(253, 168)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 20)
        Me.Label10.TabIndex = 67
        Me.Label10.Text = "Ley 56"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(173, 168)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 20)
        Me.Label11.TabIndex = 66
        Me.Label11.Text = "Ley 44"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(97, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 20)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "Lt cercado"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(18, 168)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 20)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "Lote"
        '
        'lblHILIESTR
        '
        Me.lblHILIESTR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblHILIESTR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHILIESTR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHILIESTR.ForeColor = System.Drawing.Color.Black
        Me.lblHILIESTR.Location = New System.Drawing.Point(470, 95)
        Me.lblHILIESTR.Name = "lblHILIESTR"
        Me.lblHILIESTR.Size = New System.Drawing.Size(258, 20)
        Me.lblHILIESTR.TabIndex = 63
        '
        'cboHILIESTR
        '
        Me.cboHILIESTR.AccessibleDescription = "Estrato"
        Me.cboHILIESTR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboHILIESTR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHILIESTR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHILIESTR.FormattingEnabled = True
        Me.cboHILIESTR.Location = New System.Drawing.Point(375, 94)
        Me.cboHILIESTR.Name = "cboHILIESTR"
        Me.cboHILIESTR.Size = New System.Drawing.Size(89, 22)
        Me.cboHILIESTR.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(375, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(353, 20)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "Estrato"
        '
        'lblHILIDEEC
        '
        Me.lblHILIDEEC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblHILIDEEC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHILIDEEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHILIDEEC.ForeColor = System.Drawing.Color.Black
        Me.lblHILIDEEC.Location = New System.Drawing.Point(116, 143)
        Me.lblHILIDEEC.Name = "lblHILIDEEC"
        Me.lblHILIDEEC.Size = New System.Drawing.Size(255, 20)
        Me.lblHILIDEEC.TabIndex = 60
        '
        'cboHILIDEEC
        '
        Me.cboHILIDEEC.AccessibleDescription = "Destinación económica"
        Me.cboHILIDEEC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboHILIDEEC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHILIDEEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHILIDEEC.FormattingEnabled = True
        Me.cboHILIDEEC.Location = New System.Drawing.Point(18, 142)
        Me.cboHILIDEEC.Name = "cboHILIDEEC"
        Me.cboHILIDEEC.Size = New System.Drawing.Size(92, 22)
        Me.cboHILIDEEC.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(18, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(353, 20)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Destinación económica"
        '
        'txtHILIAVCA
        '
        Me.txtHILIAVCA.AccessibleDescription = "Avaluo catastral"
        Me.txtHILIAVCA.BackColor = System.Drawing.SystemColors.Window
        Me.txtHILIAVCA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHILIAVCA.Location = New System.Drawing.Point(196, 48)
        Me.txtHILIAVCA.MaxLength = 2
        Me.txtHILIAVCA.Name = "txtHILIAVCA"
        Me.txtHILIAVCA.Size = New System.Drawing.Size(175, 20)
        Me.txtHILIAVCA.TabIndex = 2
        Me.txtHILIAVCA.Text = "0"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(196, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(175, 20)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Avalúo catastral"
        '
        'lblHILIVIGE
        '
        Me.lblHILIVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblHILIVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHILIVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHILIVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblHILIVIGE.Location = New System.Drawing.Point(113, 95)
        Me.lblHILIVIGE.Name = "lblHILIVIGE"
        Me.lblHILIVIGE.Size = New System.Drawing.Size(258, 20)
        Me.lblHILIVIGE.TabIndex = 55
        '
        'cboHILIVIGE
        '
        Me.cboHILIVIGE.AccessibleDescription = "Vigencia"
        Me.cboHILIVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboHILIVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHILIVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHILIVIGE.FormattingEnabled = True
        Me.cboHILIVIGE.Location = New System.Drawing.Point(18, 94)
        Me.cboHILIVIGE.Name = "cboHILIVIGE"
        Me.cboHILIVIGE.Size = New System.Drawing.Size(89, 22)
        Me.cboHILIVIGE.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(18, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(353, 20)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Vigencia"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(18, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 20)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Avalúo predio"
        '
        'txtHILIAVPR
        '
        Me.txtHILIAVPR.AccessibleDescription = "Avaluo predio"
        Me.txtHILIAVPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtHILIAVPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHILIAVPR.Location = New System.Drawing.Point(18, 48)
        Me.txtHILIAVPR.MaxLength = 2
        Me.txtHILIAVPR.Name = "txtHILIAVPR"
        Me.txtHILIAVPR.Size = New System.Drawing.Size(175, 20)
        Me.txtHILIAVPR.TabIndex = 1
        Me.txtHILIAVPR.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 250)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(748, 53)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(377, 19)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 17
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(270, 19)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 16
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'frm_insertar_HISTLIQU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 345)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximumSize = New System.Drawing.Size(793, 381)
        Me.MinimumSize = New System.Drawing.Size(793, 381)
        Me.Name = "frm_insertar_HISTLIQU"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtHILIAVPR As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents lblHILIVIGE As System.Windows.Forms.Label
    Friend WithEvents cboHILIVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblHILIESTR As System.Windows.Forms.Label
    Friend WithEvents cboHILIESTR As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblHILIDEEC As System.Windows.Forms.Label
    Friend WithEvents cboHILIDEEC As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtHILIAVCA As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkHILILE44 As System.Windows.Forms.CheckBox
    Friend WithEvents chkHILILOCE As System.Windows.Forms.CheckBox
    Friend WithEvents chkHILILOTE As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblHILITIPO As System.Windows.Forms.Label
    Friend WithEvents cboHILITIPO As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtHILIARCO As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtHILIARTE As System.Windows.Forms.TextBox
    Friend WithEvents chkHILIAUAV As System.Windows.Forms.CheckBox
    Friend WithEvents chkHILILE56 As System.Windows.Forms.CheckBox
    Friend WithEvents cboHILIESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtHILIPUNT As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
