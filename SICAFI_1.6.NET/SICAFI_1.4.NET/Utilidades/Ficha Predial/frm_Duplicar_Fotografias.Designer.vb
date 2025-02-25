<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Duplicar_Fotografias
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCarpetaDestino = New System.Windows.Forms.Label()
        Me.cmdCarpetaDestino = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lblRutaArchivo = New System.Windows.Forms.Label()
        Me.cmdAbrirArchivo = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.pbPROCESO = New System.Windows.Forms.ProgressBar()
        Me.cmdEjecutarCopia = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.nudFotografia = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudNroConstrucciones = New System.Windows.Forms.NumericUpDown()
        Me.txtNroFichaPredial = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nudNroRepeticiones = New System.Windows.Forms.NumericUpDown()
        Me.chkDuplicarCroquis = New System.Windows.Forms.CheckBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudFotografia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudNroConstrucciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudNroRepeticiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCarpetaDestino)
        Me.GroupBox1.Controls.Add(Me.cmdCarpetaDestino)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 75)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(651, 57)
        Me.GroupBox1.TabIndex = 78
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CARPETA DE DESTINO"
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
        Me.lblCarpetaDestino.Location = New System.Drawing.Point(151, 25)
        Me.lblCarpetaDestino.Name = "lblCarpetaDestino"
        Me.lblCarpetaDestino.Size = New System.Drawing.Size(484, 20)
        Me.lblCarpetaDestino.TabIndex = 356
        '
        'cmdCarpetaDestino
        '
        Me.cmdCarpetaDestino.AccessibleDescription = "Carpeta destino"
        Me.cmdCarpetaDestino.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdCarpetaDestino.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCarpetaDestino.Location = New System.Drawing.Point(19, 23)
        Me.cmdCarpetaDestino.Name = "cmdCarpetaDestino"
        Me.cmdCarpetaDestino.Size = New System.Drawing.Size(123, 23)
        Me.cmdCarpetaDestino.TabIndex = 13
        Me.cmdCarpetaDestino.Text = "Carpeta"
        Me.cmdCarpetaDestino.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblRutaArchivo)
        Me.GroupBox5.Controls.Add(Me.cmdAbrirArchivo)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(651, 57)
        Me.GroupBox5.TabIndex = 77
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "ARCHIVO FUENTE"
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
        Me.lblRutaArchivo.Location = New System.Drawing.Point(151, 25)
        Me.lblRutaArchivo.Name = "lblRutaArchivo"
        Me.lblRutaArchivo.Size = New System.Drawing.Size(484, 20)
        Me.lblRutaArchivo.TabIndex = 356
        '
        'cmdAbrirArchivo
        '
        Me.cmdAbrirArchivo.AccessibleDescription = "Abrir archivo"
        Me.cmdAbrirArchivo.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdAbrirArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAbrirArchivo.Location = New System.Drawing.Point(19, 23)
        Me.cmdAbrirArchivo.Name = "cmdAbrirArchivo"
        Me.cmdAbrirArchivo.Size = New System.Drawing.Size(123, 23)
        Me.cmdAbrirArchivo.TabIndex = 13
        Me.cmdAbrirArchivo.Text = "Abrir archivo"
        Me.cmdAbrirArchivo.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.pbPROCESO)
        Me.GroupBox6.Controls.Add(Me.cmdEjecutarCopia)
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(12, 343)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(651, 54)
        Me.GroupBox6.TabIndex = 79
        Me.GroupBox6.TabStop = False
        '
        'pbPROCESO
        '
        Me.pbPROCESO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbPROCESO.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pbPROCESO.Location = New System.Drawing.Point(151, 18)
        Me.pbPROCESO.Name = "pbPROCESO"
        Me.pbPROCESO.Size = New System.Drawing.Size(484, 17)
        Me.pbPROCESO.TabIndex = 24
        '
        'cmdEjecutarCopia
        '
        Me.cmdEjecutarCopia.AccessibleDescription = "Ejecutar copia"
        Me.cmdEjecutarCopia.Enabled = False
        Me.cmdEjecutarCopia.Image = Global.SICAFI.My.Resources.Resources._008
        Me.cmdEjecutarCopia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEjecutarCopia.Location = New System.Drawing.Point(19, 15)
        Me.cmdEjecutarCopia.Name = "cmdEjecutarCopia"
        Me.cmdEjecutarCopia.Size = New System.Drawing.Size(123, 23)
        Me.cmdEjecutarCopia.TabIndex = 14
        Me.cmdEjecutarCopia.Text = "Ejecutar copia"
        Me.cmdEjecutarCopia.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.nudFotografia)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.nudNroConstrucciones)
        Me.GroupBox2.Controls.Add(Me.txtNroFichaPredial)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.nudNroRepeticiones)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 198)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(651, 139)
        Me.GroupBox2.TabIndex = 80
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CONFIGURACIÓN"
        '
        'nudFotografia
        '
        Me.nudFotografia.Location = New System.Drawing.Point(204, 102)
        Me.nudFotografia.Name = "nudFotografia"
        Me.nudFotografia.Size = New System.Drawing.Size(120, 20)
        Me.nudFotografia.TabIndex = 377
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 20)
        Me.Label1.TabIndex = 376
        Me.Label1.Text = "Nro. de fotografía :"
        '
        'nudNroConstrucciones
        '
        Me.nudNroConstrucciones.Location = New System.Drawing.Point(204, 79)
        Me.nudNroConstrucciones.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudNroConstrucciones.Name = "nudNroConstrucciones"
        Me.nudNroConstrucciones.Size = New System.Drawing.Size(120, 20)
        Me.nudNroConstrucciones.TabIndex = 375
        '
        'txtNroFichaPredial
        '
        Me.txtNroFichaPredial.Location = New System.Drawing.Point(204, 31)
        Me.txtNroFichaPredial.MaxLength = 9
        Me.txtNroFichaPredial.Name = "txtNroFichaPredial"
        Me.txtNroFichaPredial.Size = New System.Drawing.Size(120, 20)
        Me.txtNroFichaPredial.TabIndex = 374
        Me.txtNroFichaPredial.Text = "0"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(180, 20)
        Me.Label3.TabIndex = 373
        Me.Label3.Text = "Nro. de construcción :"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 20)
        Me.Label2.TabIndex = 372
        Me.Label2.Text = "Nro. de repeticiones :"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(180, 20)
        Me.Label4.TabIndex = 371
        Me.Label4.Text = "Nro. de ficha predial inicial :"
        '
        'nudNroRepeticiones
        '
        Me.nudNroRepeticiones.Location = New System.Drawing.Point(204, 54)
        Me.nudNroRepeticiones.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudNroRepeticiones.Name = "nudNroRepeticiones"
        Me.nudNroRepeticiones.Size = New System.Drawing.Size(120, 20)
        Me.nudNroRepeticiones.TabIndex = 0
        '
        'chkDuplicarCroquis
        '
        Me.chkDuplicarCroquis.Location = New System.Drawing.Point(19, 19)
        Me.chkDuplicarCroquis.Name = "chkDuplicarCroquis"
        Me.chkDuplicarCroquis.Size = New System.Drawing.Size(157, 24)
        Me.chkDuplicarCroquis.TabIndex = 378
        Me.chkDuplicarCroquis.Text = "Duplicar croquis del predio"
        Me.chkDuplicarCroquis.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 409)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(679, 25)
        Me.strBARRESTA.TabIndex = 81
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
        Me.GroupBox3.Controls.Add(Me.chkDuplicarCroquis)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(12, 138)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(651, 54)
        Me.GroupBox3.TabIndex = 82
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "PARAMETRO"
        '
        'BackgroundWorker1
        '
        '
        'frm_Duplicar_Fotografias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 434)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.MinimumSize = New System.Drawing.Size(695, 470)
        Me.Name = "frm_Duplicar_Fotografias"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "DUPLICAR FOTOGRAFIAS"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudFotografia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudNroConstrucciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudNroRepeticiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCarpetaDestino As System.Windows.Forms.Label
    Friend WithEvents cmdCarpetaDestino As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRutaArchivo As System.Windows.Forms.Label
    Friend WithEvents cmdAbrirArchivo As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents pbPROCESO As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdEjecutarCopia As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents nudNroRepeticiones As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nudFotografia As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudNroConstrucciones As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtNroFichaPredial As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents chkDuplicarCroquis As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
