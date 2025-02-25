<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Reducir_Tamano_Fotografia
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
        Me.components = New System.ComponentModel.Container()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.pbPROCESO = New System.Windows.Forms.ProgressBar()
        Me.cmdEjecutarReduccion = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCarpetaDestino = New System.Windows.Forms.Label()
        Me.cmdCarpetaDestino = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lblRutaArchivo = New System.Windows.Forms.Label()
        Me.cmdAbrirArchivo = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lstLISTADO_DOCUMENTOS = New System.Windows.Forms.ListBox()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 409)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(679, 25)
        Me.strBARRESTA.TabIndex = 87
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
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.pbPROCESO)
        Me.GroupBox6.Controls.Add(Me.cmdEjecutarReduccion)
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(12, 340)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(651, 54)
        Me.GroupBox6.TabIndex = 85
        Me.GroupBox6.TabStop = False
        '
        'pbPROCESO
        '
        Me.pbPROCESO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbPROCESO.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pbPROCESO.Location = New System.Drawing.Point(210, 18)
        Me.pbPROCESO.Name = "pbPROCESO"
        Me.pbPROCESO.Size = New System.Drawing.Size(425, 17)
        Me.pbPROCESO.TabIndex = 24
        '
        'cmdEjecutarReduccion
        '
        Me.cmdEjecutarReduccion.AccessibleDescription = "Ejecutar reducción"
        Me.cmdEjecutarReduccion.Enabled = False
        Me.cmdEjecutarReduccion.Image = Global.SICAFI.My.Resources.Resources._008
        Me.cmdEjecutarReduccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEjecutarReduccion.Location = New System.Drawing.Point(19, 15)
        Me.cmdEjecutarReduccion.Name = "cmdEjecutarReduccion"
        Me.cmdEjecutarReduccion.Size = New System.Drawing.Size(185, 23)
        Me.cmdEjecutarReduccion.TabIndex = 14
        Me.cmdEjecutarReduccion.Text = "Ejecutar reducción"
        Me.cmdEjecutarReduccion.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCarpetaDestino)
        Me.GroupBox1.Controls.Add(Me.cmdCarpetaDestino)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(651, 57)
        Me.GroupBox1.TabIndex = 84
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CARPETA DESTINO"
        '
        'lblCarpetaDestino
        '
        Me.lblCarpetaDestino.AccessibleDescription = "Carpeta destino"
        Me.lblCarpetaDestino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCarpetaDestino.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCarpetaDestino.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCarpetaDestino.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarpetaDestino.ForeColor = System.Drawing.Color.Black
        Me.lblCarpetaDestino.Location = New System.Drawing.Point(210, 25)
        Me.lblCarpetaDestino.Name = "lblCarpetaDestino"
        Me.lblCarpetaDestino.Size = New System.Drawing.Size(425, 20)
        Me.lblCarpetaDestino.TabIndex = 356
        '
        'cmdCarpetaDestino
        '
        Me.cmdCarpetaDestino.AccessibleDescription = "Carpeta destino"
        Me.cmdCarpetaDestino.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdCarpetaDestino.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCarpetaDestino.Location = New System.Drawing.Point(19, 23)
        Me.cmdCarpetaDestino.Name = "cmdCarpetaDestino"
        Me.cmdCarpetaDestino.Size = New System.Drawing.Size(185, 23)
        Me.cmdCarpetaDestino.TabIndex = 13
        Me.cmdCarpetaDestino.Text = "Carpeta destino"
        Me.cmdCarpetaDestino.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblRutaArchivo)
        Me.GroupBox5.Controls.Add(Me.cmdAbrirArchivo)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(12, 9)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(651, 57)
        Me.GroupBox5.TabIndex = 83
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "CARPETA FUENTE"
        '
        'lblRutaArchivo
        '
        Me.lblRutaArchivo.AccessibleDescription = "Ruta archivo"
        Me.lblRutaArchivo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRutaArchivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRutaArchivo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRutaArchivo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutaArchivo.ForeColor = System.Drawing.Color.Black
        Me.lblRutaArchivo.Location = New System.Drawing.Point(210, 25)
        Me.lblRutaArchivo.Name = "lblRutaArchivo"
        Me.lblRutaArchivo.Size = New System.Drawing.Size(425, 20)
        Me.lblRutaArchivo.TabIndex = 356
        '
        'cmdAbrirArchivo
        '
        Me.cmdAbrirArchivo.AccessibleDescription = "Abrir archivo"
        Me.cmdAbrirArchivo.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdAbrirArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAbrirArchivo.Location = New System.Drawing.Point(19, 23)
        Me.cmdAbrirArchivo.Name = "cmdAbrirArchivo"
        Me.cmdAbrirArchivo.Size = New System.Drawing.Size(185, 23)
        Me.cmdAbrirArchivo.TabIndex = 13
        Me.cmdAbrirArchivo.Text = "Carpeta fuente"
        Me.cmdAbrirArchivo.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstLISTADO_DOCUMENTOS)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 135)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(651, 199)
        Me.GroupBox2.TabIndex = 86
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ARCHIVOS"
        '
        'lstLISTADO_DOCUMENTOS
        '
        Me.lstLISTADO_DOCUMENTOS.AccessibleDescription = "Listado"
        Me.lstLISTADO_DOCUMENTOS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstLISTADO_DOCUMENTOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLISTADO_DOCUMENTOS.FormattingEnabled = True
        Me.lstLISTADO_DOCUMENTOS.ItemHeight = 16
        Me.lstLISTADO_DOCUMENTOS.Location = New System.Drawing.Point(19, 19)
        Me.lstLISTADO_DOCUMENTOS.Name = "lstLISTADO_DOCUMENTOS"
        Me.lstLISTADO_DOCUMENTOS.Size = New System.Drawing.Size(616, 164)
        Me.lstLISTADO_DOCUMENTOS.TabIndex = 336
        '
        'frm_Reducir_Tamano_Fotografia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 434)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_Reducir_Tamano_Fotografia"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "REDUCIR TAMAÑO DE ARCHIVO FOTOGRAFICO"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents pbPROCESO As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdEjecutarReduccion As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCarpetaDestino As System.Windows.Forms.Label
    Friend WithEvents cmdCarpetaDestino As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRutaArchivo As System.Windows.Forms.Label
    Friend WithEvents cmdAbrirArchivo As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lstLISTADO_DOCUMENTOS As System.Windows.Forms.ListBox
End Class
