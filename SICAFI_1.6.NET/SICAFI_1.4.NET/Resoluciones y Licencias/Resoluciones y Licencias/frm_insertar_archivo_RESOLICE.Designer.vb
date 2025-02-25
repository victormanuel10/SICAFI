<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_archivo_RESOLICE
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
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbdTODOS = New System.Windows.Forms.RadioButton()
        Me.rbdSELECCION = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbdMOVER = New System.Windows.Forms.RadioButton()
        Me.rbdCOPIAR = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lstLISTADO_DOCUMENTOS = New System.Windows.Forms.ListBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.cmdAbrirCarpeta = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbdTODOS)
        Me.GroupBox4.Controls.Add(Me.rbdSELECCION)
        Me.GroupBox4.Location = New System.Drawing.Point(764, 7)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(200, 62)
        Me.GroupBox4.TabIndex = 371
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "OPCIÓN"
        '
        'rbdTODOS
        '
        Me.rbdTODOS.Checked = True
        Me.rbdTODOS.Location = New System.Drawing.Point(112, 25)
        Me.rbdTODOS.Name = "rbdTODOS"
        Me.rbdTODOS.Size = New System.Drawing.Size(69, 17)
        Me.rbdTODOS.TabIndex = 3
        Me.rbdTODOS.TabStop = True
        Me.rbdTODOS.Text = "Todos"
        Me.rbdTODOS.UseVisualStyleBackColor = True
        '
        'rbdSELECCION
        '
        Me.rbdSELECCION.Location = New System.Drawing.Point(17, 25)
        Me.rbdSELECCION.Name = "rbdSELECCION"
        Me.rbdSELECCION.Size = New System.Drawing.Size(89, 17)
        Me.rbdSELECCION.TabIndex = 2
        Me.rbdSELECCION.Text = "Selección"
        Me.rbdSELECCION.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbdMOVER)
        Me.GroupBox2.Controls.Add(Me.rbdCOPIAR)
        Me.GroupBox2.Location = New System.Drawing.Point(558, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 62)
        Me.GroupBox2.TabIndex = 370
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "OPERACIÓN"
        '
        'rbdMOVER
        '
        Me.rbdMOVER.Checked = True
        Me.rbdMOVER.Location = New System.Drawing.Point(106, 24)
        Me.rbdMOVER.Name = "rbdMOVER"
        Me.rbdMOVER.Size = New System.Drawing.Size(72, 17)
        Me.rbdMOVER.TabIndex = 1
        Me.rbdMOVER.TabStop = True
        Me.rbdMOVER.Text = "Mover"
        Me.rbdMOVER.UseVisualStyleBackColor = True
        '
        'rbdCOPIAR
        '
        Me.rbdCOPIAR.Location = New System.Drawing.Point(19, 21)
        Me.rbdCOPIAR.Name = "rbdCOPIAR"
        Me.rbdCOPIAR.Size = New System.Drawing.Size(75, 24)
        Me.rbdCOPIAR.TabIndex = 0
        Me.rbdCOPIAR.Text = "Copiar"
        Me.rbdCOPIAR.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lstLISTADO_DOCUMENTOS)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(12, 75)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(952, 368)
        Me.GroupBox3.TabIndex = 369
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "ARCHIVOS"
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
        Me.lstLISTADO_DOCUMENTOS.Location = New System.Drawing.Point(19, 28)
        Me.lstLISTADO_DOCUMENTOS.Name = "lstLISTADO_DOCUMENTOS"
        Me.lstLISTADO_DOCUMENTOS.Size = New System.Drawing.Size(914, 308)
        Me.lstLISTADO_DOCUMENTOS.TabIndex = 335
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblRuta)
        Me.GroupBox5.Controls.Add(Me.cmdAbrirCarpeta)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(12, 7)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(540, 62)
        Me.GroupBox5.TabIndex = 366
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "RUTA ARCHIVO"
        '
        'lblRuta
        '
        Me.lblRuta.AccessibleDescription = "Ruta archivo"
        Me.lblRuta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRuta.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRuta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.ForeColor = System.Drawing.Color.Black
        Me.lblRuta.Location = New System.Drawing.Point(151, 25)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(371, 20)
        Me.lblRuta.TabIndex = 356
        '
        'cmdAbrirCarpeta
        '
        Me.cmdAbrirCarpeta.AccessibleDescription = "Abrir carpeta"
        Me.cmdAbrirCarpeta.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdAbrirCarpeta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAbrirCarpeta.Location = New System.Drawing.Point(19, 23)
        Me.cmdAbrirCarpeta.Name = "cmdAbrirCarpeta"
        Me.cmdAbrirCarpeta.Size = New System.Drawing.Size(123, 23)
        Me.cmdAbrirCarpeta.TabIndex = 1
        Me.cmdAbrirCarpeta.Text = "Abrir carpeta"
        Me.cmdAbrirCarpeta.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 449)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(952, 46)
        Me.GroupBox1.TabIndex = 367
        Me.GroupBox1.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(478, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 2
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(371, 15)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 1
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 517)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(976, 25)
        Me.strBARRESTA.TabIndex = 368
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
        'frm_insertar_archivo_RESOLICE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(976, 542)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(992, 578)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(992, 578)
        Me.Name = "frm_insertar_archivo_RESOLICE"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar archivo"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdTODOS As System.Windows.Forms.RadioButton
    Friend WithEvents rbdSELECCION As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdMOVER As System.Windows.Forms.RadioButton
    Friend WithEvents rbdCOPIAR As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lstLISTADO_DOCUMENTOS As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents cmdAbrirCarpeta As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
End Class
