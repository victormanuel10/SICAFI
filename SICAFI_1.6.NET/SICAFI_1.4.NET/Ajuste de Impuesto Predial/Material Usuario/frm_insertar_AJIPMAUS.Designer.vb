<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_AJIPMAUS
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtMAUSFECH = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtMAUSOBSE = New System.Windows.Forms.TextBox()
        Me.cmdELIMINAR = New System.Windows.Forms.Button()
        Me.cmdAGREGAR = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvMATEUSUA = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvMATECAMP = New System.Windows.Forms.DataGridView()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvMATEUSUA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvMATECAMP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdSALIR)
        Me.GroupBox4.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox4.Location = New System.Drawing.Point(18, 452)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(818, 46)
        Me.GroupBox4.TabIndex = 362
        Me.GroupBox4.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(406, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 18
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(299, 15)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 17
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtMAUSFECH)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label39)
        Me.GroupBox3.Controls.Add(Me.txtMAUSOBSE)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(18, 337)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(818, 109)
        Me.GroupBox3.TabIndex = 361
        Me.GroupBox3.TabStop = False
        '
        'txtMAUSFECH
        '
        Me.txtMAUSFECH.AccessibleDescription = "Fecha de ingreso"
        Me.txtMAUSFECH.BackColor = System.Drawing.Color.White
        Me.txtMAUSFECH.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMAUSFECH.Location = New System.Drawing.Point(139, 22)
        Me.txtMAUSFECH.Mask = "00-00-0000"
        Me.txtMAUSFECH.Name = "txtMAUSFECH"
        Me.txtMAUSFECH.Size = New System.Drawing.Size(207, 20)
        Me.txtMAUSFECH.TabIndex = 342
        Me.txtMAUSFECH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(777, 20)
        Me.Label1.TabIndex = 340
        Me.Label1.Text = "Observación"
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label39.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(19, 22)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(116, 20)
        Me.Label39.TabIndex = 338
        Me.Label39.Text = "Fecha de ingreso"
        '
        'txtMAUSOBSE
        '
        Me.txtMAUSOBSE.AccessibleDescription = "Observaciones"
        Me.txtMAUSOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtMAUSOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMAUSOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMAUSOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtMAUSOBSE.Location = New System.Drawing.Point(19, 68)
        Me.txtMAUSOBSE.MaxLength = 1000
        Me.txtMAUSOBSE.Name = "txtMAUSOBSE"
        Me.txtMAUSOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMAUSOBSE.Size = New System.Drawing.Size(777, 20)
        Me.txtMAUSOBSE.TabIndex = 187
        '
        'cmdELIMINAR
        '
        Me.cmdELIMINAR.AccessibleDescription = "Eliminar"
        Me.cmdELIMINAR.Image = Global.SICAFI.My.Resources.Resources._132
        Me.cmdELIMINAR.Location = New System.Drawing.Point(394, 180)
        Me.cmdELIMINAR.Name = "cmdELIMINAR"
        Me.cmdELIMINAR.Size = New System.Drawing.Size(66, 61)
        Me.cmdELIMINAR.TabIndex = 360
        Me.cmdELIMINAR.Text = "Eliminar"
        Me.cmdELIMINAR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdELIMINAR.UseVisualStyleBackColor = True
        '
        'cmdAGREGAR
        '
        Me.cmdAGREGAR.AccessibleDescription = "Agregar"
        Me.cmdAGREGAR.Image = Global.SICAFI.My.Resources.Resources._834
        Me.cmdAGREGAR.Location = New System.Drawing.Point(394, 95)
        Me.cmdAGREGAR.Name = "cmdAGREGAR"
        Me.cmdAGREGAR.Size = New System.Drawing.Size(66, 61)
        Me.cmdAGREGAR.TabIndex = 359
        Me.cmdAGREGAR.Text = "Agregar"
        Me.cmdAGREGAR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdAGREGAR.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgvMATEUSUA)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(470, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(366, 317)
        Me.GroupBox2.TabIndex = 358
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "MATERIAL DE USUARIO"
        '
        'dgvMATEUSUA
        '
        Me.dgvMATEUSUA.AccessibleDescription = "Material de usuario"
        Me.dgvMATEUSUA.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvMATEUSUA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMATEUSUA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMATEUSUA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMATEUSUA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvMATEUSUA.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvMATEUSUA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMATEUSUA.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMATEUSUA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMATEUSUA.ColumnHeadersHeight = 40
        Me.dgvMATEUSUA.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMATEUSUA.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvMATEUSUA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvMATEUSUA.Location = New System.Drawing.Point(19, 28)
        Me.dgvMATEUSUA.MultiSelect = False
        Me.dgvMATEUSUA.Name = "dgvMATEUSUA"
        Me.dgvMATEUSUA.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMATEUSUA.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvMATEUSUA.RowHeadersVisible = False
        Me.dgvMATEUSUA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMATEUSUA.ShowCellToolTips = False
        Me.dgvMATEUSUA.Size = New System.Drawing.Size(325, 271)
        Me.dgvMATEUSUA.StandardTab = True
        Me.dgvMATEUSUA.TabIndex = 327
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgvMATECAMP)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(18, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(366, 317)
        Me.GroupBox1.TabIndex = 357
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MATERIAL DE CAMPO"
        '
        'dgvMATECAMP
        '
        Me.dgvMATECAMP.AccessibleDescription = "Material de campo"
        Me.dgvMATECAMP.AllowUserToAddRows = False
        Me.dgvMATECAMP.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvMATECAMP.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvMATECAMP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMATECAMP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMATECAMP.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvMATECAMP.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvMATECAMP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMATECAMP.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMATECAMP.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvMATECAMP.ColumnHeadersHeight = 40
        Me.dgvMATECAMP.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMATECAMP.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvMATECAMP.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvMATECAMP.Location = New System.Drawing.Point(19, 28)
        Me.dgvMATECAMP.MultiSelect = False
        Me.dgvMATECAMP.Name = "dgvMATECAMP"
        Me.dgvMATECAMP.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMATECAMP.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvMATECAMP.RowHeadersVisible = False
        Me.dgvMATECAMP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMATECAMP.ShowCellToolTips = False
        Me.dgvMATECAMP.Size = New System.Drawing.Size(327, 271)
        Me.dgvMATECAMP.StandardTab = True
        Me.dgvMATECAMP.TabIndex = 326
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 515)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(855, 25)
        Me.strBARRESTA.TabIndex = 356
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
        'frm_insertar_AJIPMAUS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 540)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdELIMINAR)
        Me.Controls.Add(Me.cmdAGREGAR)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(871, 576)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(871, 576)
        Me.Name = "frm_insertar_AJIPMAUS"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvMATEUSUA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvMATECAMP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMAUSFECH As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtMAUSOBSE As System.Windows.Forms.TextBox
    Friend WithEvents cmdELIMINAR As System.Windows.Forms.Button
    Friend WithEvents cmdAGREGAR As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvMATEUSUA As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvMATECAMP As System.Windows.Forms.DataGridView
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
End Class
