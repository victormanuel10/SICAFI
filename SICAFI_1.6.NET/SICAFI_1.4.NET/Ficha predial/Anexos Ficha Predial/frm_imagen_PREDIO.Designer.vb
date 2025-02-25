<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_imagen_PREDIO
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lblRUTA = New System.Windows.Forms.Label
        Me.cmdAbrirArchivo = New System.Windows.Forms.Button
        Me.pibImagenPredio = New System.Windows.Forms.PictureBox
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdEliminar = New System.Windows.Forms.Button
        Me.cmdGuardar = New System.Windows.Forms.Button
        Me.lblCorregimiento = New System.Windows.Forms.Label
        Me.cboPresentacion = New System.Windows.Forms.ComboBox
        Me.cmdLimpiar = New System.Windows.Forms.Button
        Me.cmdSalir = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.pibImagenPredio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.pibImagenPredio)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(772, 480)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "IMAGEN PREDIO"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.lblRUTA)
        Me.GroupBox4.Controls.Add(Me.cmdAbrirArchivo)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(19, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(735, 47)
        Me.GroupBox4.TabIndex = 42
        Me.GroupBox4.TabStop = False
        '
        'lblRUTA
        '
        Me.lblRUTA.AccessibleDescription = "Ruta archivo"
        Me.lblRUTA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRUTA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUTA.ForeColor = System.Drawing.Color.Black
        Me.lblRUTA.Location = New System.Drawing.Point(163, 17)
        Me.lblRUTA.Name = "lblRUTA"
        Me.lblRUTA.Size = New System.Drawing.Size(553, 20)
        Me.lblRUTA.TabIndex = 357
        '
        'cmdAbrirArchivo
        '
        Me.cmdAbrirArchivo.AccessibleDescription = "Abrir archivo"
        Me.cmdAbrirArchivo.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdAbrirArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAbrirArchivo.Location = New System.Drawing.Point(19, 15)
        Me.cmdAbrirArchivo.Name = "cmdAbrirArchivo"
        Me.cmdAbrirArchivo.Size = New System.Drawing.Size(123, 23)
        Me.cmdAbrirArchivo.TabIndex = 1
        Me.cmdAbrirArchivo.Text = "Abrir archivo"
        Me.cmdAbrirArchivo.UseVisualStyleBackColor = True
        '
        'pibImagenPredio
        '
        Me.pibImagenPredio.AccessibleDescription = "Imagen del predio"
        Me.pibImagenPredio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pibImagenPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pibImagenPredio.Location = New System.Drawing.Point(19, 83)
        Me.pibImagenPredio.Name = "pibImagenPredio"
        Me.pibImagenPredio.Size = New System.Drawing.Size(735, 378)
        Me.pibImagenPredio.TabIndex = 0
        Me.pibImagenPredio.TabStop = False
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 555)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(796, 25)
        Me.strBARRESTA.TabIndex = 40
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
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cmdEliminar)
        Me.GroupBox3.Controls.Add(Me.cmdGuardar)
        Me.GroupBox3.Controls.Add(Me.lblCorregimiento)
        Me.GroupBox3.Controls.Add(Me.cboPresentacion)
        Me.GroupBox3.Controls.Add(Me.cmdLimpiar)
        Me.GroupBox3.Controls.Add(Me.cmdSalir)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(12, 498)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(772, 47)
        Me.GroupBox3.TabIndex = 41
        Me.GroupBox3.TabStop = False
        '
        'cmdEliminar
        '
        Me.cmdEliminar.AccessibleDescription = "Eliminar"
        Me.cmdEliminar.Image = Global.SICAFI.My.Resources.Resources._132
        Me.cmdEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEliminar.Location = New System.Drawing.Point(373, 15)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(123, 23)
        Me.cmdEliminar.TabIndex = 44
        Me.cmdEliminar.Text = "&Eliminar"
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'cmdGuardar
        '
        Me.cmdGuardar.AccessibleDescription = "Guardar"
        Me.cmdGuardar.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGuardar.Location = New System.Drawing.Point(244, 15)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(123, 23)
        Me.cmdGuardar.TabIndex = 45
        Me.cmdGuardar.Text = "&Guardar"
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'lblCorregimiento
        '
        Me.lblCorregimiento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCorregimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorregimiento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorregimiento.ForeColor = System.Drawing.Color.Black
        Me.lblCorregimiento.Location = New System.Drawing.Point(19, 15)
        Me.lblCorregimiento.Name = "lblCorregimiento"
        Me.lblCorregimiento.Size = New System.Drawing.Size(104, 22)
        Me.lblCorregimiento.TabIndex = 44
        Me.lblCorregimiento.Text = "Vista imagen:"
        Me.lblCorregimiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPresentacion
        '
        Me.cboPresentacion.AccessibleDescription = "Tipo de presentación"
        Me.cboPresentacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPresentacion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPresentacion.Items.AddRange(New Object() {"Estrecha", "Centrada", "Normal", "Ajustada"})
        Me.cboPresentacion.Location = New System.Drawing.Point(129, 15)
        Me.cboPresentacion.Name = "cboPresentacion"
        Me.cboPresentacion.Size = New System.Drawing.Size(108, 22)
        Me.cboPresentacion.TabIndex = 43
        '
        'cmdLimpiar
        '
        Me.cmdLimpiar.AccessibleDescription = "Limpiar campos"
        Me.cmdLimpiar.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLimpiar.Location = New System.Drawing.Point(502, 15)
        Me.cmdLimpiar.Name = "cmdLimpiar"
        Me.cmdLimpiar.Size = New System.Drawing.Size(123, 23)
        Me.cmdLimpiar.TabIndex = 20
        Me.cmdLimpiar.Text = "&Limpiar campos"
        Me.cmdLimpiar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.AccessibleDescription = "Salir"
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(631, 15)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(123, 23)
        Me.cmdSalir.TabIndex = 24
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'frm_imagen_PREDIO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 580)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox1)
        Me.MinimumSize = New System.Drawing.Size(804, 607)
        Me.Name = "frm_imagen_PREDIO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IMAGEN DEL PREDIO"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.pibImagenPredio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pibImagenPredio As System.Windows.Forms.PictureBox
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLimpiar As System.Windows.Forms.Button
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAbrirArchivo As System.Windows.Forms.Button
    Friend WithEvents lblRUTA As System.Windows.Forms.Label
    Friend WithEvents cboPresentacion As System.Windows.Forms.ComboBox
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents cmdGuardar As System.Windows.Forms.Button
    Friend WithEvents cmdEliminar As System.Windows.Forms.Button
End Class
