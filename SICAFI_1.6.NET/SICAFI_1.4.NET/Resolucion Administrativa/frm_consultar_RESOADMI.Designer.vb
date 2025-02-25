<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_RESOADMI
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
        Me.fraPERIODO = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabRadicado = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdLimpiarResolucionConservacion = New System.Windows.Forms.Button()
        Me.cmdAceptarResolucionConservacion = New System.Windows.Forms.Button()
        Me.cmdConsultarResolucionConservacion = New System.Windows.Forms.Button()
        Me.dgvCONSULTA_RESOCONS = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtREADFERE = New System.Windows.Forms.TextBox()
        Me.txtREADNURE = New System.Windows.Forms.TextBox()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraPERIODO.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabRadicado.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCONSULTA_RESOCONS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraPERIODO
        '
        Me.fraPERIODO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraPERIODO.BackColor = System.Drawing.SystemColors.Control
        Me.fraPERIODO.Controls.Add(Me.GroupBox2)
        Me.fraPERIODO.Controls.Add(Me.TabControl1)
        Me.fraPERIODO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPERIODO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPERIODO.Location = New System.Drawing.Point(12, 12)
        Me.fraPERIODO.Name = "fraPERIODO"
        Me.fraPERIODO.Size = New System.Drawing.Size(951, 447)
        Me.fraPERIODO.TabIndex = 91
        Me.fraPERIODO.TabStop = False
        Me.fraPERIODO.Text = "CONSULTA RESOLUCIÓN ADMINISTRATIVA"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmdSalir)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 375)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(918, 54)
        Me.GroupBox2.TabIndex = 88
        Me.GroupBox2.TabStop = False
        '
        'cmdSalir
        '
        Me.cmdSalir.AccessibleDescription = "Salir"
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(792, 18)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(101, 23)
        Me.cmdSalir.TabIndex = 4
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabRadicado)
        Me.TabControl1.Location = New System.Drawing.Point(16, 20)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(918, 355)
        Me.TabControl1.TabIndex = 0
        '
        'TabRadicado
        '
        Me.TabRadicado.BackColor = System.Drawing.SystemColors.Control
        Me.TabRadicado.Controls.Add(Me.Label8)
        Me.TabRadicado.Controls.Add(Me.GroupBox1)
        Me.TabRadicado.Controls.Add(Me.dgvCONSULTA_RESOCONS)
        Me.TabRadicado.Controls.Add(Me.Label1)
        Me.TabRadicado.Controls.Add(Me.Label9)
        Me.TabRadicado.Controls.Add(Me.txtREADFERE)
        Me.TabRadicado.Controls.Add(Me.txtREADNURE)
        Me.TabRadicado.Location = New System.Drawing.Point(4, 24)
        Me.TabRadicado.Name = "TabRadicado"
        Me.TabRadicado.Padding = New System.Windows.Forms.Padding(3)
        Me.TabRadicado.Size = New System.Drawing.Size(910, 327)
        Me.TabRadicado.TabIndex = 0
        Me.TabRadicado.Text = "Resolución"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(753, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 20)
        Me.Label8.TabIndex = 453
        Me.Label8.Text = "(dd-mm-aaaa)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.cmdLimpiarResolucionConservacion)
        Me.GroupBox1.Controls.Add(Me.cmdAceptarResolucionConservacion)
        Me.GroupBox1.Controls.Add(Me.cmdConsultarResolucionConservacion)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 256)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(898, 60)
        Me.GroupBox1.TabIndex = 87
        Me.GroupBox1.TabStop = False
        '
        'cmdLimpiarResolucionConservacion
        '
        Me.cmdLimpiarResolucionConservacion.AccessibleDescription = "Limpiar"
        Me.cmdLimpiarResolucionConservacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLimpiarResolucionConservacion.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLimpiarResolucionConservacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLimpiarResolucionConservacion.Location = New System.Drawing.Point(19, 20)
        Me.cmdLimpiarResolucionConservacion.Name = "cmdLimpiarResolucionConservacion"
        Me.cmdLimpiarResolucionConservacion.Size = New System.Drawing.Size(117, 23)
        Me.cmdLimpiarResolucionConservacion.TabIndex = 1
        Me.cmdLimpiarResolucionConservacion.Text = "&Limpiar"
        Me.cmdLimpiarResolucionConservacion.UseVisualStyleBackColor = True
        '
        'cmdAceptarResolucionConservacion
        '
        Me.cmdAceptarResolucionConservacion.AccessibleDescription = "Aceptar"
        Me.cmdAceptarResolucionConservacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptarResolucionConservacion.Enabled = False
        Me.cmdAceptarResolucionConservacion.Image = Global.SICAFI.My.Resources.Resources._22
        Me.cmdAceptarResolucionConservacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptarResolucionConservacion.Location = New System.Drawing.Point(778, 20)
        Me.cmdAceptarResolucionConservacion.Name = "cmdAceptarResolucionConservacion"
        Me.cmdAceptarResolucionConservacion.Size = New System.Drawing.Size(101, 23)
        Me.cmdAceptarResolucionConservacion.TabIndex = 3
        Me.cmdAceptarResolucionConservacion.Text = "&Aceptar"
        Me.cmdAceptarResolucionConservacion.UseVisualStyleBackColor = True
        '
        'cmdConsultarResolucionConservacion
        '
        Me.cmdConsultarResolucionConservacion.AccessibleDescription = "Consultar"
        Me.cmdConsultarResolucionConservacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdConsultarResolucionConservacion.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdConsultarResolucionConservacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdConsultarResolucionConservacion.Location = New System.Drawing.Point(671, 20)
        Me.cmdConsultarResolucionConservacion.Name = "cmdConsultarResolucionConservacion"
        Me.cmdConsultarResolucionConservacion.Size = New System.Drawing.Size(101, 23)
        Me.cmdConsultarResolucionConservacion.TabIndex = 2
        Me.cmdConsultarResolucionConservacion.Text = "&Consultar"
        Me.cmdConsultarResolucionConservacion.UseVisualStyleBackColor = True
        '
        'dgvCONSULTA_RESOCONS
        '
        Me.dgvCONSULTA_RESOCONS.AccessibleDescription = ""
        Me.dgvCONSULTA_RESOCONS.AllowUserToAddRows = False
        Me.dgvCONSULTA_RESOCONS.AllowUserToDeleteRows = False
        Me.dgvCONSULTA_RESOCONS.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA_RESOCONS.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCONSULTA_RESOCONS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCONSULTA_RESOCONS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCONSULTA_RESOCONS.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCONSULTA_RESOCONS.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCONSULTA_RESOCONS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCONSULTA_RESOCONS.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCONSULTA_RESOCONS.ColumnHeadersHeight = 30
        Me.dgvCONSULTA_RESOCONS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCONSULTA_RESOCONS.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA_RESOCONS.Location = New System.Drawing.Point(6, 37)
        Me.dgvCONSULTA_RESOCONS.MultiSelect = False
        Me.dgvCONSULTA_RESOCONS.Name = "dgvCONSULTA_RESOCONS"
        Me.dgvCONSULTA_RESOCONS.ReadOnly = True
        Me.dgvCONSULTA_RESOCONS.RowHeadersVisible = False
        Me.dgvCONSULTA_RESOCONS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA_RESOCONS.ShowCellToolTips = False
        Me.dgvCONSULTA_RESOCONS.Size = New System.Drawing.Size(898, 217)
        Me.dgvCONSULTA_RESOCONS.StandardTab = True
        Me.dgvCONSULTA_RESOCONS.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 20)
        Me.Label1.TabIndex = 420
        Me.Label1.Text = "Nro. Resolución"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(378, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(193, 20)
        Me.Label9.TabIndex = 448
        Me.Label9.Text = "Fecha de resolución"
        '
        'txtREADFERE
        '
        Me.txtREADFERE.AccessibleDescription = "Fecha de Resolución"
        Me.txtREADFERE.BackColor = System.Drawing.SystemColors.Window
        Me.txtREADFERE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREADFERE.Location = New System.Drawing.Point(574, 11)
        Me.txtREADFERE.MaxLength = 10
        Me.txtREADFERE.Name = "txtREADFERE"
        Me.txtREADFERE.Size = New System.Drawing.Size(173, 20)
        Me.txtREADFERE.TabIndex = 2
        '
        'txtREADNURE
        '
        Me.txtREADNURE.AccessibleDescription = "Nro. Resolución"
        Me.txtREADNURE.BackColor = System.Drawing.SystemColors.Window
        Me.txtREADNURE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREADNURE.ForeColor = System.Drawing.Color.Black
        Me.txtREADNURE.Location = New System.Drawing.Point(202, 11)
        Me.txtREADNURE.MaxLength = 9
        Me.txtREADNURE.Name = "txtREADNURE"
        Me.txtREADNURE.Size = New System.Drawing.Size(173, 20)
        Me.txtREADNURE.TabIndex = 1
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 475)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(975, 25)
        Me.strBARRESTA.TabIndex = 92
        '
        'tstBAESVALI
        '
        Me.tstBAESVALI.AutoSize = False
        Me.tstBAESVALI.BackColor = System.Drawing.Color.White
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
        Me.tstBAESDESC.BackColor = System.Drawing.Color.White
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
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.White
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(125, 22)
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frm_consultar_RESOADMI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(975, 500)
        Me.Controls.Add(Me.fraPERIODO)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Name = "frm_consultar_RESOADMI"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar registro"
        Me.fraPERIODO.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabRadicado.ResumeLayout(False)
        Me.TabRadicado.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvCONSULTA_RESOCONS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraPERIODO As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabRadicado As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLimpiarResolucionConservacion As System.Windows.Forms.Button
    Friend WithEvents cmdAceptarResolucionConservacion As System.Windows.Forms.Button
    Friend WithEvents cmdConsultarResolucionConservacion As System.Windows.Forms.Button
    Friend WithEvents dgvCONSULTA_RESOCONS As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtREADFERE As System.Windows.Forms.TextBox
    Friend WithEvents txtREADNURE As System.Windows.Forms.TextBox
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
End Class
