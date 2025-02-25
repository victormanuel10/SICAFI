<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CONSULTA_SQL
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.fraTERCERO = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtRUTA = New System.Windows.Forms.Label
        Me.cmdPLANO = New System.Windows.Forms.Button
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.cmdCONSULTAR = New System.Windows.Forms.Button
        Me.txtCONDICION = New System.Windows.Forms.TextBox
        Me.txtSELECT = New System.Windows.Forms.Label
        Me.dgvCONSULTA = New System.Windows.Forms.DataGridView
        Me.txtSEPARADOR = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNROREGISTROS = New System.Windows.Forms.Label
        Me.fraTERCERO.SuspendLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraTERCERO
        '
        Me.fraTERCERO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraTERCERO.BackColor = System.Drawing.SystemColors.Control
        Me.fraTERCERO.Controls.Add(Me.txtNROREGISTROS)
        Me.fraTERCERO.Controls.Add(Me.Label3)
        Me.fraTERCERO.Controls.Add(Me.Label2)
        Me.fraTERCERO.Controls.Add(Me.txtSEPARADOR)
        Me.fraTERCERO.Controls.Add(Me.Label1)
        Me.fraTERCERO.Controls.Add(Me.txtRUTA)
        Me.fraTERCERO.Controls.Add(Me.cmdPLANO)
        Me.fraTERCERO.Controls.Add(Me.cmdSALIR)
        Me.fraTERCERO.Controls.Add(Me.cmdCONSULTAR)
        Me.fraTERCERO.Controls.Add(Me.txtCONDICION)
        Me.fraTERCERO.Controls.Add(Me.txtSELECT)
        Me.fraTERCERO.Controls.Add(Me.dgvCONSULTA)
        Me.fraTERCERO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraTERCERO.ForeColor = System.Drawing.Color.Black
        Me.fraTERCERO.Location = New System.Drawing.Point(15, 12)
        Me.fraTERCERO.Name = "fraTERCERO"
        Me.fraTERCERO.Size = New System.Drawing.Size(719, 527)
        Me.fraTERCERO.TabIndex = 1
        Me.fraTERCERO.TabStop = False
        Me.fraTERCERO.Text = "CONSULTA LENGUAJE SQL Server"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 487)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 21)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "Separador"
        '
        'txtRUTA
        '
        Me.txtRUTA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRUTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtRUTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRUTA.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRUTA.ForeColor = System.Drawing.Color.Black
        Me.txtRUTA.Location = New System.Drawing.Point(183, 180)
        Me.txtRUTA.Name = "txtRUTA"
        Me.txtRUTA.Size = New System.Drawing.Size(516, 20)
        Me.txtRUTA.TabIndex = 43
        Me.txtRUTA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPLANO
        '
        Me.cmdPLANO.AccessibleDescription = "Plano"
        Me.cmdPLANO.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdPLANO.Image = Global.SICAFI.My.Resources.Resources._71
        Me.cmdPLANO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPLANO.Location = New System.Drawing.Point(183, 149)
        Me.cmdPLANO.Name = "cmdPLANO"
        Me.cmdPLANO.Size = New System.Drawing.Size(161, 23)
        Me.cmdPLANO.TabIndex = 4
        Me.cmdPLANO.Text = "&Generar archivo"
        Me.cmdPLANO.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Cancelar"
        Me.cmdSALIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(538, 486)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(161, 23)
        Me.cmdSALIR.TabIndex = 5
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdCONSULTAR
        '
        Me.cmdCONSULTAR.AccessibleDescription = "Consultar"
        Me.cmdCONSULTAR.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdCONSULTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCONSULTAR.Location = New System.Drawing.Point(16, 149)
        Me.cmdCONSULTAR.Name = "cmdCONSULTAR"
        Me.cmdCONSULTAR.Size = New System.Drawing.Size(161, 23)
        Me.cmdCONSULTAR.TabIndex = 2
        Me.cmdCONSULTAR.Text = "&Consultar"
        Me.cmdCONSULTAR.UseVisualStyleBackColor = True
        '
        'txtCONDICION
        '
        Me.txtCONDICION.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCONDICION.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONDICION.Location = New System.Drawing.Point(16, 56)
        Me.txtCONDICION.Multiline = True
        Me.txtCONDICION.Name = "txtCONDICION"
        Me.txtCONDICION.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCONDICION.Size = New System.Drawing.Size(683, 78)
        Me.txtCONDICION.TabIndex = 1
        '
        'txtSELECT
        '
        Me.txtSELECT.BackColor = System.Drawing.SystemColors.Window
        Me.txtSELECT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtSELECT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSELECT.ForeColor = System.Drawing.Color.Blue
        Me.txtSELECT.Location = New System.Drawing.Point(16, 33)
        Me.txtSELECT.Name = "txtSELECT"
        Me.txtSELECT.Size = New System.Drawing.Size(113, 20)
        Me.txtSELECT.TabIndex = 42
        Me.txtSELECT.Text = "Select"
        Me.txtSELECT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvCONSULTA
        '
        Me.dgvCONSULTA.AccessibleDescription = "Consulta abierta"
        Me.dgvCONSULTA.AllowUserToAddRows = False
        Me.dgvCONSULTA.AllowUserToDeleteRows = False
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
        Me.dgvCONSULTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCONSULTA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA.Location = New System.Drawing.Point(16, 214)
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(683, 257)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 3
        '
        'txtSEPARADOR
        '
        Me.txtSEPARADOR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSEPARADOR.Location = New System.Drawing.Point(135, 487)
        Me.txtSEPARADOR.Name = "txtSEPARADOR"
        Me.txtSEPARADOR.Size = New System.Drawing.Size(42, 21)
        Me.txtSEPARADOR.TabIndex = 99
        Me.txtSEPARADOR.Text = "|"
        Me.txtSEPARADOR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 180)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(161, 20)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "Ruta de archivo :"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(183, 487)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 21)
        Me.Label3.TabIndex = 101
        Me.Label3.Text = "Nro. registros :"
        '
        'txtNROREGISTROS
        '
        Me.txtNROREGISTROS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtNROREGISTROS.BackColor = System.Drawing.SystemColors.Window
        Me.txtNROREGISTROS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtNROREGISTROS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNROREGISTROS.ForeColor = System.Drawing.Color.Black
        Me.txtNROREGISTROS.Location = New System.Drawing.Point(302, 487)
        Me.txtNROREGISTROS.Name = "txtNROREGISTROS"
        Me.txtNROREGISTROS.Size = New System.Drawing.Size(42, 20)
        Me.txtNROREGISTROS.TabIndex = 102
        Me.txtNROREGISTROS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frm_CONSULTA_SQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 560)
        Me.Controls.Add(Me.fraTERCERO)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_CONSULTA_SQL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CONSULTA SQL"
        Me.fraTERCERO.ResumeLayout(False)
        Me.fraTERCERO.PerformLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraTERCERO As System.Windows.Forms.GroupBox
    Friend WithEvents txtSELECT As System.Windows.Forms.Label
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents txtCONDICION As System.Windows.Forms.TextBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdCONSULTAR As System.Windows.Forms.Button
    Friend WithEvents cmdPLANO As System.Windows.Forms.Button
    Friend WithEvents txtRUTA As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSEPARADOR As System.Windows.Forms.TextBox
    Friend WithEvents txtNROREGISTROS As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
