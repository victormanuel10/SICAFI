<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_REGIMUTA
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdExportarExcel = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdLimpiar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdConsultar = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraPERIODO = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbdListadoPorPredios = New System.Windows.Forms.RadioButton()
        Me.rbdListadoPorMesVigencia = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtREMUMES = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtREMUVIGE = New System.Windows.Forms.TextBox()
        Me.dgvCONSULTA = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraPERIODO.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdExportarExcel)
        Me.GroupBox1.Controls.Add(Me.cmdSalir)
        Me.GroupBox1.Controls.Add(Me.cmdLimpiar)
        Me.GroupBox1.Controls.Add(Me.cmdAceptar)
        Me.GroupBox1.Controls.Add(Me.cmdConsultar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 329)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(829, 60)
        Me.GroupBox1.TabIndex = 83
        Me.GroupBox1.TabStop = False
        '
        'cmdExportarExcel
        '
        Me.cmdExportarExcel.AccessibleDescription = "Exportar Excel"
        Me.cmdExportarExcel.AccessibleName = ""
        Me.cmdExportarExcel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExportarExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExportarExcel.Image = Global.SICAFI.My.Resources.Resources._041
        Me.cmdExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdExportarExcel.Location = New System.Drawing.Point(142, 20)
        Me.cmdExportarExcel.Name = "cmdExportarExcel"
        Me.cmdExportarExcel.Size = New System.Drawing.Size(123, 23)
        Me.cmdExportarExcel.TabIndex = 25
        Me.cmdExportarExcel.Text = "&Exportar excel"
        Me.cmdExportarExcel.UseVisualStyleBackColor = False
        '
        'cmdSalir
        '
        Me.cmdSalir.AccessibleDescription = "Salir"
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(713, 20)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(101, 23)
        Me.cmdSalir.TabIndex = 4
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
        Me.cmdLimpiar.Size = New System.Drawing.Size(117, 23)
        Me.cmdLimpiar.TabIndex = 1
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
        Me.cmdAceptar.Location = New System.Drawing.Point(606, 20)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(101, 23)
        Me.cmdAceptar.TabIndex = 3
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdConsultar
        '
        Me.cmdConsultar.AccessibleDescription = "Consultar"
        Me.cmdConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdConsultar.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdConsultar.Location = New System.Drawing.Point(499, 20)
        Me.cmdConsultar.Name = "cmdConsultar"
        Me.cmdConsultar.Size = New System.Drawing.Size(101, 23)
        Me.cmdConsultar.TabIndex = 2
        Me.cmdConsultar.Text = "&Consultar"
        Me.cmdConsultar.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 402)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(853, 25)
        Me.strBARRESTA.TabIndex = 84
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
        'fraPERIODO
        '
        Me.fraPERIODO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraPERIODO.BackColor = System.Drawing.SystemColors.Control
        Me.fraPERIODO.Controls.Add(Me.GroupBox2)
        Me.fraPERIODO.Controls.Add(Me.Label9)
        Me.fraPERIODO.Controls.Add(Me.txtREMUMES)
        Me.fraPERIODO.Controls.Add(Me.Label1)
        Me.fraPERIODO.Controls.Add(Me.txtREMUVIGE)
        Me.fraPERIODO.Controls.Add(Me.dgvCONSULTA)
        Me.fraPERIODO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPERIODO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPERIODO.Location = New System.Drawing.Point(12, 8)
        Me.fraPERIODO.Name = "fraPERIODO"
        Me.fraPERIODO.Size = New System.Drawing.Size(827, 318)
        Me.fraPERIODO.TabIndex = 82
        Me.fraPERIODO.TabStop = False
        Me.fraPERIODO.Text = "CONSULTA REGISTRO DE MUTACIONES"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbdListadoPorPredios)
        Me.GroupBox2.Controls.Add(Me.rbdListadoPorMesVigencia)
        Me.GroupBox2.Location = New System.Drawing.Point(375, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(436, 51)
        Me.GroupBox2.TabIndex = 449
        Me.GroupBox2.TabStop = False
        '
        'rbdListadoPorPredios
        '
        Me.rbdListadoPorPredios.Location = New System.Drawing.Point(251, 20)
        Me.rbdListadoPorPredios.Name = "rbdListadoPorPredios"
        Me.rbdListadoPorPredios.Size = New System.Drawing.Size(179, 19)
        Me.rbdListadoPorPredios.TabIndex = 1
        Me.rbdListadoPorPredios.Text = "Listado por predios"
        Me.rbdListadoPorPredios.UseVisualStyleBackColor = True
        '
        'rbdListadoPorMesVigencia
        '
        Me.rbdListadoPorMesVigencia.Checked = True
        Me.rbdListadoPorMesVigencia.Location = New System.Drawing.Point(38, 21)
        Me.rbdListadoPorMesVigencia.Name = "rbdListadoPorMesVigencia"
        Me.rbdListadoPorMesVigencia.Size = New System.Drawing.Size(187, 17)
        Me.rbdListadoPorMesVigencia.TabIndex = 0
        Me.rbdListadoPorMesVigencia.TabStop = True
        Me.rbdListadoPorMesVigencia.Text = "Listado por mes y vigencia"
        Me.rbdListadoPorMesVigencia.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(195, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(173, 20)
        Me.Label9.TabIndex = 448
        Me.Label9.Text = "Vigencia"
        '
        'txtREMUMES
        '
        Me.txtREMUMES.AccessibleDescription = "Mes"
        Me.txtREMUMES.BackColor = System.Drawing.SystemColors.Window
        Me.txtREMUMES.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREMUMES.ForeColor = System.Drawing.Color.Black
        Me.txtREMUMES.Location = New System.Drawing.Point(19, 46)
        Me.txtREMUMES.MaxLength = 9
        Me.txtREMUMES.Name = "txtREMUMES"
        Me.txtREMUMES.Size = New System.Drawing.Size(172, 20)
        Me.txtREMUMES.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(173, 20)
        Me.Label1.TabIndex = 420
        Me.Label1.Text = "Mes"
        '
        'txtREMUVIGE
        '
        Me.txtREMUVIGE.AccessibleDescription = "Vigencia"
        Me.txtREMUVIGE.BackColor = System.Drawing.SystemColors.Window
        Me.txtREMUVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREMUVIGE.Location = New System.Drawing.Point(195, 46)
        Me.txtREMUVIGE.MaxLength = 9
        Me.txtREMUVIGE.Name = "txtREMUVIGE"
        Me.txtREMUVIGE.Size = New System.Drawing.Size(173, 20)
        Me.txtREMUVIGE.TabIndex = 2
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
        Me.dgvCONSULTA.Location = New System.Drawing.Point(19, 72)
        Me.dgvCONSULTA.MultiSelect = False
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        Me.dgvCONSULTA.RowHeadersVisible = False
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(792, 230)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 40
        '
        'frm_consultar_REGIMUTA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 427)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraPERIODO)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(869, 463)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(869, 463)
        Me.Name = "frm_consultar_REGIMUTA"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraPERIODO.ResumeLayout(False)
        Me.fraPERIODO.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExportarExcel As System.Windows.Forms.Button
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents cmdLimpiar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdConsultar As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraPERIODO As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtREMUMES As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtREMUVIGE As System.Windows.Forms.TextBox
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdListadoPorPredios As System.Windows.Forms.RadioButton
    Friend WithEvents rbdListadoPorMesVigencia As System.Windows.Forms.RadioButton
End Class
