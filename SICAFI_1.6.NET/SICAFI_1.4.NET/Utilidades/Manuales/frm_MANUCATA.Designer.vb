<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MANUCATA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MANUCATA))
        Me.fraMANUALES = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.nudTAMANO = New System.Windows.Forms.NumericUpDown()
        Me.lblTAMANO = New System.Windows.Forms.Label()
        Me.cmdFUENTE = New System.Windows.Forms.Button()
        Me.btnPageSetup = New System.Windows.Forms.Button()
        Me.btnPrintDialog = New System.Windows.Forms.Button()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.txtDOCUMENTO = New System.Windows.Forms.TextBox()
        Me.cboSELECCION = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraMANUALES.SuspendLayout()
        CType(Me.nudTAMANO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraMANUALES
        '
        Me.fraMANUALES.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraMANUALES.BackColor = System.Drawing.SystemColors.Control
        Me.fraMANUALES.Controls.Add(Me.cmdSALIR)
        Me.fraMANUALES.Controls.Add(Me.nudTAMANO)
        Me.fraMANUALES.Controls.Add(Me.lblTAMANO)
        Me.fraMANUALES.Controls.Add(Me.cmdFUENTE)
        Me.fraMANUALES.Controls.Add(Me.btnPageSetup)
        Me.fraMANUALES.Controls.Add(Me.btnPrintDialog)
        Me.fraMANUALES.Controls.Add(Me.btnPrintPreview)
        Me.fraMANUALES.Controls.Add(Me.txtDOCUMENTO)
        Me.fraMANUALES.Controls.Add(Me.cboSELECCION)
        Me.fraMANUALES.Controls.Add(Me.Label25)
        Me.fraMANUALES.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraMANUALES.ForeColor = System.Drawing.Color.Black
        Me.fraMANUALES.Location = New System.Drawing.Point(12, 12)
        Me.fraMANUALES.Name = "fraMANUALES"
        Me.fraMANUALES.Size = New System.Drawing.Size(962, 529)
        Me.fraMANUALES.TabIndex = 48
        Me.fraMANUALES.TabStop = False
        Me.fraMANUALES.Text = "MANUALES Y ESTRUCTURAS CATASTRALES"
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.AccessibleName = "Print Dialog button"
        Me.cmdSALIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSALIR.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSALIR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdSALIR.Location = New System.Drawing.Point(824, 489)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(116, 25)
        Me.cmdSALIR.TabIndex = 56
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = False
        '
        'nudTAMANO
        '
        Me.nudTAMANO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nudTAMANO.Location = New System.Drawing.Point(210, 491)
        Me.nudTAMANO.Name = "nudTAMANO"
        Me.nudTAMANO.Size = New System.Drawing.Size(49, 21)
        Me.nudTAMANO.TabIndex = 55
        Me.nudTAMANO.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'lblTAMANO
        '
        Me.lblTAMANO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTAMANO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblTAMANO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAMANO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAMANO.ForeColor = System.Drawing.Color.Black
        Me.lblTAMANO.Location = New System.Drawing.Point(21, 491)
        Me.lblTAMANO.Name = "lblTAMANO"
        Me.lblTAMANO.Size = New System.Drawing.Size(183, 21)
        Me.lblTAMANO.TabIndex = 54
        Me.lblTAMANO.Text = "Tamaño fuente impresión"
        Me.lblTAMANO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdFUENTE
        '
        Me.cmdFUENTE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdFUENTE.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFUENTE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFUENTE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFUENTE.Image = Global.SICAFI.My.Resources.Resources._028
        Me.cmdFUENTE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdFUENTE.Location = New System.Drawing.Point(265, 489)
        Me.cmdFUENTE.Name = "cmdFUENTE"
        Me.cmdFUENTE.Size = New System.Drawing.Size(116, 25)
        Me.cmdFUENTE.TabIndex = 53
        Me.cmdFUENTE.Text = "&Fuente"
        Me.cmdFUENTE.UseVisualStyleBackColor = False
        '
        'btnPageSetup
        '
        Me.btnPageSetup.AccessibleDescription = "Button with text ""Page Setup"""
        Me.btnPageSetup.AccessibleName = "Page Setup button"
        Me.btnPageSetup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPageSetup.BackColor = System.Drawing.SystemColors.Control
        Me.btnPageSetup.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPageSetup.Image = Global.SICAFI.My.Resources.Resources._526
        Me.btnPageSetup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPageSetup.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPageSetup.Location = New System.Drawing.Point(509, 489)
        Me.btnPageSetup.Name = "btnPageSetup"
        Me.btnPageSetup.Size = New System.Drawing.Size(116, 25)
        Me.btnPageSetup.TabIndex = 52
        Me.btnPageSetup.Text = "&Configurar"
        Me.btnPageSetup.UseVisualStyleBackColor = False
        '
        'btnPrintDialog
        '
        Me.btnPrintDialog.AccessibleDescription = "Button with text ""Print Dialog"""
        Me.btnPrintDialog.AccessibleName = "Print Dialog button"
        Me.btnPrintDialog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintDialog.BackColor = System.Drawing.SystemColors.Control
        Me.btnPrintDialog.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPrintDialog.Image = Global.SICAFI.My.Resources.Resources._004
        Me.btnPrintDialog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintDialog.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPrintDialog.Location = New System.Drawing.Point(631, 489)
        Me.btnPrintDialog.Name = "btnPrintDialog"
        Me.btnPrintDialog.Size = New System.Drawing.Size(116, 25)
        Me.btnPrintDialog.TabIndex = 51
        Me.btnPrintDialog.Text = "&Imprimir"
        Me.btnPrintDialog.UseVisualStyleBackColor = False
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.AccessibleDescription = "Button with text ""Print Preview"""
        Me.btnPrintPreview.AccessibleName = "Print Preview button"
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.BackColor = System.Drawing.SystemColors.Control
        Me.btnPrintPreview.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPrintPreview.Image = Global.SICAFI.My.Resources.Resources._499
        Me.btnPrintPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintPreview.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPrintPreview.Location = New System.Drawing.Point(387, 489)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(116, 25)
        Me.btnPrintPreview.TabIndex = 50
        Me.btnPrintPreview.Text = "&Vista Previa"
        Me.btnPrintPreview.UseVisualStyleBackColor = False
        '
        'txtDOCUMENTO
        '
        Me.txtDOCUMENTO.AccessibleDescription = "TextBox to contain text for printing"
        Me.txtDOCUMENTO.AccessibleName = "TextBox for printing"
        Me.txtDOCUMENTO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDOCUMENTO.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtDOCUMENTO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDOCUMENTO.Location = New System.Drawing.Point(21, 68)
        Me.txtDOCUMENTO.Multiline = True
        Me.txtDOCUMENTO.Name = "txtDOCUMENTO"
        Me.txtDOCUMENTO.ReadOnly = True
        Me.txtDOCUMENTO.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDOCUMENTO.Size = New System.Drawing.Size(919, 400)
        Me.txtDOCUMENTO.TabIndex = 49
        '
        'cboSELECCION
        '
        Me.cboSELECCION.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSELECCION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSELECCION.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSELECCION.Items.AddRange(New Object() {"01. Que es Catastro ?", "02. Ley 14 del 1983", "03. Resolución 2555 de 1988", "04. Ley 675 de 2001", "05. Diligenciamiento de la ficha predial Predial", "06. Procedimientos para informar movimientos", "07. Reconocimiento y calificación de las construcciones", "08. Formulas de liquidación de avalúos catastrales", "09. Estructura de importación del propietario anterior", "10. Estructura de importación de las áreas de terreno.", "11. Estructura para el cruce de areas de terreno bd vs cartografia", "12. Estructura de importacion de cedulas catastrales", "13. Cruce matriculas municipio vs registro xls - mdb ", "14. Estructura de importación de investigacion juridica", "15. Resolución 70 de 2011", "16. Estructura de importación de registro y control", "17. Estructura de importación de resoluciones administrativas", "18. Estructura de importación de las áreas de construccion.", "19. Estrcutura de importación observación ficha predial", "20. Estructura de importación identificador de construcción", "21. Estructura de importación para generar areas de construcción mediante poligon" & _
                        "os", "22. Estructura de importación de historicos de avaluos", "23. Estructura de importación de zonas económicas de la ficha predial", "24. Estructura de importación categoria de predio ficha predial", "25. Estructura de importación coeficiente de edificio", "26. Estructura de importación información RPH", "27. Estructura de importación linderos ficha predial", "28. Estructura de importación ICARE"})
        Me.cboSELECCION.Location = New System.Drawing.Point(21, 40)
        Me.cboSELECCION.MaxDropDownItems = 20
        Me.cboSELECCION.Name = "cboSELECCION"
        Me.cboSELECCION.Size = New System.Drawing.Size(919, 22)
        Me.cboSELECCION.TabIndex = 48
        '
        'Label25
        '
        Me.Label25.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(21, 17)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(919, 20)
        Me.Label25.TabIndex = 47
        Me.Label25.Text = "SELECCIONAR EL MANUAL O ESTRUCTURA CATASTRAL"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 570)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(986, 25)
        Me.strBARRESTA.TabIndex = 77
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
        'frm_MANUCATA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(986, 595)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraMANUALES)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_MANUCATA"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "MANUALES CATASTRALES"
        Me.fraMANUALES.ResumeLayout(False)
        Me.fraMANUALES.PerformLayout()
        CType(Me.nudTAMANO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraMANUALES As System.Windows.Forms.GroupBox
    Friend WithEvents nudTAMANO As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTAMANO As System.Windows.Forms.Label
    Friend WithEvents cmdFUENTE As System.Windows.Forms.Button
    Friend WithEvents btnPageSetup As System.Windows.Forms.Button
    Friend WithEvents btnPrintDialog As System.Windows.Forms.Button
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button
    Friend WithEvents txtDOCUMENTO As System.Windows.Forms.TextBox
    Friend WithEvents cboSELECCION As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
End Class
