<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_Documentos_Generales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consulta_Documentos_Generales))
        Me.lstDOCUMENTOS = New System.Windows.Forms.ListBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.cboRUDGMUNI = New System.Windows.Forms.ComboBox()
        Me.cboRUDGDOGE = New System.Windows.Forms.ComboBox()
        Me.cboRUDGDEPA = New System.Windows.Forms.ComboBox()
        Me.lblRUDGDOGE = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblRUDGDEPA = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.lblRUDGMUNI = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdLIMPIAR = New System.Windows.Forms.Button()
        Me.cmdCONSULTAR = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.axaVisorDocumentoPDF = New AxAcroPDFLib.AxAcroPDF()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.axaVisorDocumentoPDF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstDOCUMENTOS
        '
        Me.lstDOCUMENTOS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstDOCUMENTOS.FormattingEnabled = True
        Me.lstDOCUMENTOS.ItemHeight = 15
        Me.lstDOCUMENTOS.Location = New System.Drawing.Point(3, 3)
        Me.lstDOCUMENTOS.Name = "lstDOCUMENTOS"
        Me.lstDOCUMENTOS.Size = New System.Drawing.Size(333, 379)
        Me.lstDOCUMENTOS.TabIndex = 0
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.cboRUDGMUNI)
        Me.GroupBox11.Controls.Add(Me.cboRUDGDOGE)
        Me.GroupBox11.Controls.Add(Me.cboRUDGDEPA)
        Me.GroupBox11.Controls.Add(Me.lblRUDGDOGE)
        Me.GroupBox11.Controls.Add(Me.Label8)
        Me.GroupBox11.Controls.Add(Me.lblRUDGDEPA)
        Me.GroupBox11.Controls.Add(Me.Label58)
        Me.GroupBox11.Controls.Add(Me.Label60)
        Me.GroupBox11.Controls.Add(Me.lblRUDGMUNI)
        Me.GroupBox11.ForeColor = System.Drawing.Color.Black
        Me.GroupBox11.Location = New System.Drawing.Point(12, 10)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(1051, 106)
        Me.GroupBox11.TabIndex = 59
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "CEDULA CATASTRAL"
        '
        'cboRUDGMUNI
        '
        Me.cboRUDGMUNI.AccessibleDescription = "Municipio"
        Me.cboRUDGMUNI.BackColor = System.Drawing.Color.White
        Me.cboRUDGMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUDGMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUDGMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUDGMUNI.Location = New System.Drawing.Point(147, 46)
        Me.cboRUDGMUNI.MaxDropDownItems = 15
        Me.cboRUDGMUNI.MaxLength = 1
        Me.cboRUDGMUNI.Name = "cboRUDGMUNI"
        Me.cboRUDGMUNI.Size = New System.Drawing.Size(473, 22)
        Me.cboRUDGMUNI.TabIndex = 2
        '
        'cboRUDGDOGE
        '
        Me.cboRUDGDOGE.AccessibleDescription = "Documentos"
        Me.cboRUDGDOGE.BackColor = System.Drawing.Color.White
        Me.cboRUDGDOGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUDGDOGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUDGDOGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUDGDOGE.Location = New System.Drawing.Point(147, 69)
        Me.cboRUDGDOGE.MaxDropDownItems = 15
        Me.cboRUDGDOGE.MaxLength = 1
        Me.cboRUDGDOGE.Name = "cboRUDGDOGE"
        Me.cboRUDGDOGE.Size = New System.Drawing.Size(473, 22)
        Me.cboRUDGDOGE.TabIndex = 6
        '
        'cboRUDGDEPA
        '
        Me.cboRUDGDEPA.AccessibleDescription = "Departamento"
        Me.cboRUDGDEPA.BackColor = System.Drawing.Color.White
        Me.cboRUDGDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUDGDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUDGDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUDGDEPA.Location = New System.Drawing.Point(147, 23)
        Me.cboRUDGDEPA.MaxDropDownItems = 15
        Me.cboRUDGDEPA.MaxLength = 1
        Me.cboRUDGDEPA.Name = "cboRUDGDEPA"
        Me.cboRUDGDEPA.Size = New System.Drawing.Size(473, 22)
        Me.cboRUDGDEPA.TabIndex = 1
        '
        'lblRUDGDOGE
        '
        Me.lblRUDGDOGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUDGDOGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUDGDOGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUDGDOGE.ForeColor = System.Drawing.Color.Black
        Me.lblRUDGDOGE.Location = New System.Drawing.Point(624, 71)
        Me.lblRUDGDOGE.Name = "lblRUDGDOGE"
        Me.lblRUDGDOGE.Size = New System.Drawing.Size(125, 20)
        Me.lblRUDGDOGE.TabIndex = 383
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(17, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 20)
        Me.Label8.TabIndex = 382
        Me.Label8.Text = "Documentos"
        '
        'lblRUDGDEPA
        '
        Me.lblRUDGDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUDGDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUDGDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUDGDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblRUDGDEPA.Location = New System.Drawing.Point(624, 25)
        Me.lblRUDGDEPA.Name = "lblRUDGDEPA"
        Me.lblRUDGDEPA.Size = New System.Drawing.Size(125, 20)
        Me.lblRUDGDEPA.TabIndex = 381
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label58.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label58.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.Black
        Me.Label58.Location = New System.Drawing.Point(17, 25)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(127, 20)
        Me.Label58.TabIndex = 380
        Me.Label58.Text = "Departamento"
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label60.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label60.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.ForeColor = System.Drawing.Color.Black
        Me.Label60.Location = New System.Drawing.Point(17, 48)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(127, 20)
        Me.Label60.TabIndex = 331
        Me.Label60.Text = "Municipio"
        '
        'lblRUDGMUNI
        '
        Me.lblRUDGMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUDGMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUDGMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUDGMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblRUDGMUNI.Location = New System.Drawing.Point(624, 48)
        Me.lblRUDGMUNI.Name = "lblRUDGMUNI"
        Me.lblRUDGMUNI.Size = New System.Drawing.Size(125, 20)
        Me.lblRUDGMUNI.TabIndex = 325
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdLIMPIAR)
        Me.GroupBox3.Controls.Add(Me.cmdCONSULTAR)
        Me.GroupBox3.Controls.Add(Me.cmdSALIR)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(12, 122)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1051, 47)
        Me.GroupBox3.TabIndex = 56
        Me.GroupBox3.TabStop = False
        '
        'cmdLIMPIAR
        '
        Me.cmdLIMPIAR.AccessibleDescription = "Limpiar campo"
        Me.cmdLIMPIAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLIMPIAR.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLIMPIAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLIMPIAR.Location = New System.Drawing.Point(148, 15)
        Me.cmdLIMPIAR.Name = "cmdLIMPIAR"
        Me.cmdLIMPIAR.Size = New System.Drawing.Size(123, 23)
        Me.cmdLIMPIAR.TabIndex = 36
        Me.cmdLIMPIAR.Text = "&Limpiar campos"
        Me.cmdLIMPIAR.UseVisualStyleBackColor = True
        '
        'cmdCONSULTAR
        '
        Me.cmdCONSULTAR.AccessibleDescription = "Consultar"
        Me.cmdCONSULTAR.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdCONSULTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCONSULTAR.Location = New System.Drawing.Point(19, 15)
        Me.cmdCONSULTAR.Name = "cmdCONSULTAR"
        Me.cmdCONSULTAR.Size = New System.Drawing.Size(123, 23)
        Me.cmdCONSULTAR.TabIndex = 34
        Me.cmdCONSULTAR.Text = "&Consultar"
        Me.cmdCONSULTAR.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Cancelar"
        Me.cmdSALIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(910, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(123, 23)
        Me.cmdSALIR.TabIndex = 40
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 623)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(1078, 25)
        Me.strBARRESTA.TabIndex = 58
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
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.SplitContainer1)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(12, 175)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1051, 431)
        Me.GroupBox2.TabIndex = 57
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CONSULTA"
        '
        'axaVisorDocumentoPDF
        '
        Me.axaVisorDocumentoPDF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.axaVisorDocumentoPDF.Enabled = True
        Me.axaVisorDocumentoPDF.Location = New System.Drawing.Point(0, 0)
        Me.axaVisorDocumentoPDF.Name = "axaVisorDocumentoPDF"
        Me.axaVisorDocumentoPDF.OcxState = CType(resources.GetObject("axaVisorDocumentoPDF.OcxState"), System.Windows.Forms.AxHost.State)
        Me.axaVisorDocumentoPDF.Size = New System.Drawing.Size(674, 392)
        Me.axaVisorDocumentoPDF.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(16, 21)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstDOCUMENTOS)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.axaVisorDocumentoPDF)
        Me.SplitContainer1.Size = New System.Drawing.Size(1017, 392)
        Me.SplitContainer1.SplitterDistance = 339
        Me.SplitContainer1.TabIndex = 0
        '
        'frm_consulta_Documentos_Generales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 648)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox2)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_consulta_Documentos_Generales"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CONSULTA DOCUMENTOS GENERALES"
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.axaVisorDocumentoPDF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstDOCUMENTOS As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents cboRUDGMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents cboRUDGDOGE As System.Windows.Forms.ComboBox
    Friend WithEvents cboRUDGDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents lblRUDGDOGE As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblRUDGDEPA As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents lblRUDGMUNI As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLIMPIAR As System.Windows.Forms.Button
    Friend WithEvents cmdCONSULTAR As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents axaVisorDocumentoPDF As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
End Class
