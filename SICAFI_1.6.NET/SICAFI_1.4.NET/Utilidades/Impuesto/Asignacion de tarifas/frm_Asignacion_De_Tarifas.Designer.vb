<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Asignacion_De_Tarifas
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdLIMPIAR = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.pbPROCESO = New System.Windows.Forms.ProgressBar()
        Me.cmdLIQUIDAR = New System.Windows.Forms.Button()
        Me.fraFICHPRED = New System.Windows.Forms.GroupBox()
        Me.cmdAplicarIncrementoTarifario = New System.Windows.Forms.Button()
        Me.chkSumaIncrementoTarifario = New System.Windows.Forms.CheckBox()
        Me.chkAplicarPorcentajePromedioLotes = New System.Windows.Forms.CheckBox()
        Me.chkAplicarPorcentajePromedioRCI = New System.Windows.Forms.CheckBox()
        Me.chkAplicarIncrementoMilaje = New System.Windows.Forms.CheckBox()
        Me.nudAplicarIncrementoMilaje = New System.Windows.Forms.NumericUpDown()
        Me.nudPorcentajePromedioLote = New System.Windows.Forms.NumericUpDown()
        Me.chkCalcularTarifasZonasComunes = New System.Windows.Forms.CheckBox()
        Me.chkAplicarTarifaMinima = New System.Windows.Forms.CheckBox()
        Me.nudPorcentajePromedioRCI = New System.Windows.Forms.NumericUpDown()
        Me.lblASTACLSE = New System.Windows.Forms.Label()
        Me.cboASTACLSE = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblASTAVIGE = New System.Windows.Forms.Label()
        Me.cboASTAVIGE = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtFIPRMUNI = New System.Windows.Forms.TextBox()
        Me.lblCodigoActual = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbdAsignarTarifasLote = New System.Windows.Forms.RadioButton()
        Me.rbdAsignarTarifasRCI = New System.Windows.Forms.RadioButton()
        Me.GroupBox2.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.fraFICHPRED.SuspendLayout()
        CType(Me.nudAplicarIncrementoMilaje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPorcentajePromedioLote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPorcentajePromedioRCI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdLIMPIAR)
        Me.GroupBox2.Controls.Add(Me.cmdSALIR)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(16, 419)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(740, 47)
        Me.GroupBox2.TabIndex = 70
        Me.GroupBox2.TabStop = False
        '
        'cmdLIMPIAR
        '
        Me.cmdLIMPIAR.AccessibleDescription = "Limpiar campo"
        Me.cmdLIMPIAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLIMPIAR.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLIMPIAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLIMPIAR.Location = New System.Drawing.Point(19, 15)
        Me.cmdLIMPIAR.Name = "cmdLIMPIAR"
        Me.cmdLIMPIAR.Size = New System.Drawing.Size(123, 23)
        Me.cmdLIMPIAR.TabIndex = 13
        Me.cmdLIMPIAR.Text = "&Limpiar campos"
        Me.cmdLIMPIAR.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(599, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(123, 23)
        Me.cmdSALIR.TabIndex = 20
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 481)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(771, 25)
        Me.strBARRESTA.TabIndex = 69
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
        Me.GroupBox3.Controls.Add(Me.pbPROCESO)
        Me.GroupBox3.Controls.Add(Me.cmdLIQUIDAR)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(16, 366)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(740, 47)
        Me.GroupBox3.TabIndex = 68
        Me.GroupBox3.TabStop = False
        '
        'pbPROCESO
        '
        Me.pbPROCESO.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pbPROCESO.Location = New System.Drawing.Point(286, 19)
        Me.pbPROCESO.Name = "pbPROCESO"
        Me.pbPROCESO.Size = New System.Drawing.Size(436, 17)
        Me.pbPROCESO.TabIndex = 23
        '
        'cmdLIQUIDAR
        '
        Me.cmdLIQUIDAR.AccessibleDescription = "Liquida aforo"
        Me.cmdLIQUIDAR.Image = Global.SICAFI.My.Resources.Resources._412
        Me.cmdLIQUIDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLIQUIDAR.Location = New System.Drawing.Point(19, 15)
        Me.cmdLIQUIDAR.Name = "cmdLIQUIDAR"
        Me.cmdLIQUIDAR.Size = New System.Drawing.Size(210, 23)
        Me.cmdLIQUIDAR.TabIndex = 12
        Me.cmdLIQUIDAR.Text = "&Asignar tarifas"
        Me.cmdLIQUIDAR.UseVisualStyleBackColor = True
        '
        'fraFICHPRED
        '
        Me.fraFICHPRED.BackColor = System.Drawing.SystemColors.Control
        Me.fraFICHPRED.Controls.Add(Me.cmdAplicarIncrementoTarifario)
        Me.fraFICHPRED.Controls.Add(Me.chkSumaIncrementoTarifario)
        Me.fraFICHPRED.Controls.Add(Me.chkAplicarPorcentajePromedioLotes)
        Me.fraFICHPRED.Controls.Add(Me.chkAplicarPorcentajePromedioRCI)
        Me.fraFICHPRED.Controls.Add(Me.chkAplicarIncrementoMilaje)
        Me.fraFICHPRED.Controls.Add(Me.nudAplicarIncrementoMilaje)
        Me.fraFICHPRED.Controls.Add(Me.nudPorcentajePromedioLote)
        Me.fraFICHPRED.Controls.Add(Me.chkCalcularTarifasZonasComunes)
        Me.fraFICHPRED.Controls.Add(Me.chkAplicarTarifaMinima)
        Me.fraFICHPRED.Controls.Add(Me.nudPorcentajePromedioRCI)
        Me.fraFICHPRED.Controls.Add(Me.lblASTACLSE)
        Me.fraFICHPRED.Controls.Add(Me.cboASTACLSE)
        Me.fraFICHPRED.Controls.Add(Me.Label5)
        Me.fraFICHPRED.Controls.Add(Me.lblASTAVIGE)
        Me.fraFICHPRED.Controls.Add(Me.cboASTAVIGE)
        Me.fraFICHPRED.Controls.Add(Me.Label4)
        Me.fraFICHPRED.Controls.Add(Me.Label33)
        Me.fraFICHPRED.Controls.Add(Me.txtFIPRMUNI)
        Me.fraFICHPRED.Controls.Add(Me.lblCodigoActual)
        Me.fraFICHPRED.Controls.Add(Me.lblMunicipio)
        Me.fraFICHPRED.Controls.Add(Me.lblCodigo)
        Me.fraFICHPRED.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraFICHPRED.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraFICHPRED.Location = New System.Drawing.Point(16, 11)
        Me.fraFICHPRED.Name = "fraFICHPRED"
        Me.fraFICHPRED.Size = New System.Drawing.Size(740, 296)
        Me.fraFICHPRED.TabIndex = 67
        Me.fraFICHPRED.TabStop = False
        Me.fraFICHPRED.Text = "DATOS FICHA PREDIAL "
        '
        'cmdAplicarIncrementoTarifario
        '
        Me.cmdAplicarIncrementoTarifario.AccessibleDescription = "Aplica incremento"
        Me.cmdAplicarIncrementoTarifario.Image = Global.SICAFI.My.Resources.Resources._22
        Me.cmdAplicarIncrementoTarifario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAplicarIncrementoTarifario.Location = New System.Drawing.Point(374, 267)
        Me.cmdAplicarIncrementoTarifario.Name = "cmdAplicarIncrementoTarifario"
        Me.cmdAplicarIncrementoTarifario.Size = New System.Drawing.Size(140, 23)
        Me.cmdAplicarIncrementoTarifario.TabIndex = 337
        Me.cmdAplicarIncrementoTarifario.Text = "&Aplicar"
        Me.cmdAplicarIncrementoTarifario.UseVisualStyleBackColor = True
        Me.cmdAplicarIncrementoTarifario.Visible = False
        '
        'chkSumaIncrementoTarifario
        '
        Me.chkSumaIncrementoTarifario.AutoSize = True
        Me.chkSumaIncrementoTarifario.Location = New System.Drawing.Point(19, 270)
        Me.chkSumaIncrementoTarifario.Name = "chkSumaIncrementoTarifario"
        Me.chkSumaIncrementoTarifario.Size = New System.Drawing.Size(222, 19)
        Me.chkSumaIncrementoTarifario.TabIndex = 336
        Me.chkSumaIncrementoTarifario.Text = "Aplica % de incremento a las tarifas"
        Me.chkSumaIncrementoTarifario.UseVisualStyleBackColor = True
        '
        'chkAplicarPorcentajePromedioLotes
        '
        Me.chkAplicarPorcentajePromedioLotes.AutoSize = True
        Me.chkAplicarPorcentajePromedioLotes.Location = New System.Drawing.Point(19, 170)
        Me.chkAplicarPorcentajePromedioLotes.Name = "chkAplicarPorcentajePromedioLotes"
        Me.chkAplicarPorcentajePromedioLotes.Size = New System.Drawing.Size(243, 19)
        Me.chkAplicarPorcentajePromedioLotes.TabIndex = 335
        Me.chkAplicarPorcentajePromedioLotes.Text = "Aplicar % promedio de liquidación lotes"
        Me.chkAplicarPorcentajePromedioLotes.UseVisualStyleBackColor = True
        '
        'chkAplicarPorcentajePromedioRCI
        '
        Me.chkAplicarPorcentajePromedioRCI.AutoSize = True
        Me.chkAplicarPorcentajePromedioRCI.Checked = True
        Me.chkAplicarPorcentajePromedioRCI.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAplicarPorcentajePromedioRCI.Location = New System.Drawing.Point(19, 146)
        Me.chkAplicarPorcentajePromedioRCI.Name = "chkAplicarPorcentajePromedioRCI"
        Me.chkAplicarPorcentajePromedioRCI.Size = New System.Drawing.Size(258, 19)
        Me.chkAplicarPorcentajePromedioRCI.TabIndex = 334
        Me.chkAplicarPorcentajePromedioRCI.Text = "Aplicar % promedio de liquidación R-C-I-O"
        Me.chkAplicarPorcentajePromedioRCI.UseVisualStyleBackColor = True
        '
        'chkAplicarIncrementoMilaje
        '
        Me.chkAplicarIncrementoMilaje.AutoSize = True
        Me.chkAplicarIncrementoMilaje.Checked = True
        Me.chkAplicarIncrementoMilaje.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAplicarIncrementoMilaje.Location = New System.Drawing.Point(19, 195)
        Me.chkAplicarIncrementoMilaje.Name = "chkAplicarIncrementoMilaje"
        Me.chkAplicarIncrementoMilaje.Size = New System.Drawing.Size(181, 19)
        Me.chkAplicarIncrementoMilaje.TabIndex = 333
        Me.chkAplicarIncrementoMilaje.Text = "Aplicar incremento a la tarifa"
        Me.chkAplicarIncrementoMilaje.UseVisualStyleBackColor = True
        '
        'nudAplicarIncrementoMilaje
        '
        Me.nudAplicarIncrementoMilaje.Location = New System.Drawing.Point(374, 193)
        Me.nudAplicarIncrementoMilaje.Maximum = New Decimal(New Integer() {9, 0, 0, 0})
        Me.nudAplicarIncrementoMilaje.Name = "nudAplicarIncrementoMilaje"
        Me.nudAplicarIncrementoMilaje.Size = New System.Drawing.Size(140, 21)
        Me.nudAplicarIncrementoMilaje.TabIndex = 332
        '
        'nudPorcentajePromedioLote
        '
        Me.nudPorcentajePromedioLote.Location = New System.Drawing.Point(374, 169)
        Me.nudPorcentajePromedioLote.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.nudPorcentajePromedioLote.Name = "nudPorcentajePromedioLote"
        Me.nudPorcentajePromedioLote.Size = New System.Drawing.Size(140, 21)
        Me.nudPorcentajePromedioLote.TabIndex = 328
        Me.nudPorcentajePromedioLote.Value = New Decimal(New Integer() {50, 0, 0, 0})
        Me.nudPorcentajePromedioLote.Visible = False
        '
        'chkCalcularTarifasZonasComunes
        '
        Me.chkCalcularTarifasZonasComunes.AutoSize = True
        Me.chkCalcularTarifasZonasComunes.Location = New System.Drawing.Point(19, 245)
        Me.chkCalcularTarifasZonasComunes.Name = "chkCalcularTarifasZonasComunes"
        Me.chkCalcularTarifasZonasComunes.Size = New System.Drawing.Size(217, 19)
        Me.chkCalcularTarifasZonasComunes.TabIndex = 326
        Me.chkCalcularTarifasZonasComunes.Text = "Calcular tarifas de zonas comunes"
        Me.chkCalcularTarifasZonasComunes.UseVisualStyleBackColor = True
        '
        'chkAplicarTarifaMinima
        '
        Me.chkAplicarTarifaMinima.AutoSize = True
        Me.chkAplicarTarifaMinima.Checked = True
        Me.chkAplicarTarifaMinima.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAplicarTarifaMinima.Location = New System.Drawing.Point(19, 220)
        Me.chkAplicarTarifaMinima.Name = "chkAplicarTarifaMinima"
        Me.chkAplicarTarifaMinima.Size = New System.Drawing.Size(347, 19)
        Me.chkAplicarTarifaMinima.TabIndex = 325
        Me.chkAplicarTarifaMinima.Text = "Aplicar tarifa mínima por vigencia (3-2012, 4-2014, 5-2015)"
        Me.chkAplicarTarifaMinima.UseVisualStyleBackColor = True
        '
        'nudPorcentajePromedioRCI
        '
        Me.nudPorcentajePromedioRCI.Location = New System.Drawing.Point(374, 146)
        Me.nudPorcentajePromedioRCI.Name = "nudPorcentajePromedioRCI"
        Me.nudPorcentajePromedioRCI.Size = New System.Drawing.Size(140, 21)
        Me.nudPorcentajePromedioRCI.TabIndex = 324
        Me.nudPorcentajePromedioRCI.Value = New Decimal(New Integer() {20, 0, 0, 0})
        Me.nudPorcentajePromedioRCI.Visible = False
        '
        'lblASTACLSE
        '
        Me.lblASTACLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblASTACLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblASTACLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblASTACLSE.ForeColor = System.Drawing.Color.Black
        Me.lblASTACLSE.Location = New System.Drawing.Point(374, 121)
        Me.lblASTACLSE.Name = "lblASTACLSE"
        Me.lblASTACLSE.Size = New System.Drawing.Size(348, 20)
        Me.lblASTACLSE.TabIndex = 322
        '
        'cboASTACLSE
        '
        Me.cboASTACLSE.AccessibleDescription = "Sector"
        Me.cboASTACLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboASTACLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboASTACLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboASTACLSE.FormattingEnabled = True
        Me.cboASTACLSE.Location = New System.Drawing.Point(109, 118)
        Me.cboASTACLSE.Name = "cboASTACLSE"
        Me.cboASTACLSE.Size = New System.Drawing.Size(262, 22)
        Me.cboASTACLSE.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 20)
        Me.Label5.TabIndex = 320
        Me.Label5.Text = "Sector"
        '
        'lblASTAVIGE
        '
        Me.lblASTAVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblASTAVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblASTAVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblASTAVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblASTAVIGE.Location = New System.Drawing.Point(374, 98)
        Me.lblASTAVIGE.Name = "lblASTAVIGE"
        Me.lblASTAVIGE.Size = New System.Drawing.Size(348, 20)
        Me.lblASTAVIGE.TabIndex = 319
        '
        'cboASTAVIGE
        '
        Me.cboASTAVIGE.AccessibleDescription = "Vigencia"
        Me.cboASTAVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboASTAVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboASTAVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboASTAVIGE.FormattingEnabled = True
        Me.cboASTAVIGE.Location = New System.Drawing.Point(109, 95)
        Me.cboASTAVIGE.Name = "cboASTAVIGE"
        Me.cboASTAVIGE.Size = New System.Drawing.Size(261, 22)
        Me.cboASTAVIGE.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 20)
        Me.Label4.TabIndex = 317
        Me.Label4.Text = "Vigencia"
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(19, 27)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(703, 20)
        Me.Label33.TabIndex = 278
        Me.Label33.Text = "CEDULA CATASTRAL ACTUAL"
        '
        'txtFIPRMUNI
        '
        Me.txtFIPRMUNI.AccessibleDescription = "Municipio"
        Me.txtFIPRMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMUNI.Location = New System.Drawing.Point(110, 73)
        Me.txtFIPRMUNI.MaxLength = 3
        Me.txtFIPRMUNI.Name = "txtFIPRMUNI"
        Me.txtFIPRMUNI.Size = New System.Drawing.Size(612, 20)
        Me.txtFIPRMUNI.TabIndex = 4
        '
        'lblCodigoActual
        '
        Me.lblCodigoActual.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigoActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigoActual.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoActual.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoActual.Location = New System.Drawing.Point(19, 73)
        Me.lblCodigoActual.Name = "lblCodigoActual"
        Me.lblCodigoActual.Size = New System.Drawing.Size(87, 20)
        Me.lblCodigoActual.TabIndex = 27
        Me.lblCodigoActual.Text = "Código Actual"
        '
        'lblMunicipio
        '
        Me.lblMunicipio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblMunicipio.Location = New System.Drawing.Point(110, 50)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(611, 20)
        Me.lblMunicipio.TabIndex = 300
        Me.lblMunicipio.Text = "Municipio"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(19, 50)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(87, 20)
        Me.lblCodigo.TabIndex = 300
        Me.lblCodigo.Text = "CODIGO"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbdAsignarTarifasLote)
        Me.GroupBox1.Controls.Add(Me.rbdAsignarTarifasRCI)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(16, 313)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(740, 47)
        Me.GroupBox1.TabIndex = 71
        Me.GroupBox1.TabStop = False
        '
        'rbdAsignarTarifasLote
        '
        Me.rbdAsignarTarifasLote.AutoSize = True
        Me.rbdAsignarTarifasLote.Location = New System.Drawing.Point(370, 17)
        Me.rbdAsignarTarifasLote.Name = "rbdAsignarTarifasLote"
        Me.rbdAsignarTarifasLote.Size = New System.Drawing.Size(333, 17)
        Me.rbdAsignarTarifasLote.TabIndex = 1
        Me.rbdAsignarTarifasLote.Text = "Asignar tarifas de lote urbanizado y lote urbanizable no construido"
        Me.rbdAsignarTarifasLote.UseVisualStyleBackColor = True
        '
        'rbdAsignarTarifasRCI
        '
        Me.rbdAsignarTarifasRCI.AutoSize = True
        Me.rbdAsignarTarifasRCI.Checked = True
        Me.rbdAsignarTarifasRCI.Location = New System.Drawing.Point(19, 17)
        Me.rbdAsignarTarifasRCI.Name = "rbdAsignarTarifasRCI"
        Me.rbdAsignarTarifasRCI.Size = New System.Drawing.Size(328, 17)
        Me.rbdAsignarTarifasRCI.TabIndex = 0
        Me.rbdAsignarTarifasRCI.TabStop = True
        Me.rbdAsignarTarifasRCI.Text = "Asignar tarifas de predio residenciales, comerciales e industriales"
        Me.rbdAsignarTarifasRCI.UseVisualStyleBackColor = True
        '
        'frm_Asignacion_De_Tarifas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 506)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.fraFICHPRED)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.MinimumSize = New System.Drawing.Size(787, 395)
        Me.Name = "frm_Asignacion_De_Tarifas"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ASIGNACION DE TARIFAS"
        Me.GroupBox2.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.fraFICHPRED.ResumeLayout(False)
        Me.fraFICHPRED.PerformLayout()
        CType(Me.nudAplicarIncrementoMilaje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPorcentajePromedioLote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPorcentajePromedioRCI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLIMPIAR As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents pbPROCESO As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdLIQUIDAR As System.Windows.Forms.Button
    Friend WithEvents fraFICHPRED As System.Windows.Forms.GroupBox
    Friend WithEvents lblASTACLSE As System.Windows.Forms.Label
    Friend WithEvents cboASTACLSE As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblASTAVIGE As System.Windows.Forms.Label
    Friend WithEvents cboASTAVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtFIPRMUNI As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents nudPorcentajePromedioRCI As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkAplicarTarifaMinima As System.Windows.Forms.CheckBox
    Friend WithEvents chkCalcularTarifasZonasComunes As System.Windows.Forms.CheckBox
    Friend WithEvents nudPorcentajePromedioLote As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkAplicarIncrementoMilaje As System.Windows.Forms.CheckBox
    Friend WithEvents nudAplicarIncrementoMilaje As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkAplicarPorcentajePromedioLotes As System.Windows.Forms.CheckBox
    Friend WithEvents chkAplicarPorcentajePromedioRCI As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdAsignarTarifasLote As System.Windows.Forms.RadioButton
    Friend WithEvents rbdAsignarTarifasRCI As System.Windows.Forms.RadioButton
    Friend WithEvents cmdAplicarIncrementoTarifario As System.Windows.Forms.Button
    Friend WithEvents chkSumaIncrementoTarifario As System.Windows.Forms.CheckBox
End Class
