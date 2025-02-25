<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_plano_manzanero
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consulta_plano_manzanero))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdLIMPIAR = New System.Windows.Forms.Button()
        Me.cmdCONSULTAR = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.axaVisorDocumentoPDF = New AxAcroPDFLib.AxAcroPDF()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.cboRUPMCLSE = New System.Windows.Forms.ComboBox()
        Me.cboRUPMCORR = New System.Windows.Forms.ComboBox()
        Me.cboRUPMMUNI = New System.Windows.Forms.ComboBox()
        Me.cboRUPMBAVE = New System.Windows.Forms.ComboBox()
        Me.cboRUPMDEPA = New System.Windows.Forms.ComboBox()
        Me.lblRUPMBAVE = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblRUPMDEPA = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.lblRUPMCORR = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.lblRUPMCLSE = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblRUPMMUNI = New System.Windows.Forms.Label()
        Me.lstMANZANA = New System.Windows.Forms.ListBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        CType(Me.axaVisorDocumentoPDF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdLIMPIAR)
        Me.GroupBox3.Controls.Add(Me.cmdCONSULTAR)
        Me.GroupBox3.Controls.Add(Me.cmdSALIR)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(12, 124)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1051, 47)
        Me.GroupBox3.TabIndex = 51
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
        Me.strBARRESTA.TabIndex = 53
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
        'axaVisorDocumentoPDF
        '
        Me.axaVisorDocumentoPDF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.axaVisorDocumentoPDF.Enabled = True
        Me.axaVisorDocumentoPDF.Location = New System.Drawing.Point(0, 0)
        Me.axaVisorDocumentoPDF.Name = "axaVisorDocumentoPDF"
        Me.axaVisorDocumentoPDF.OcxState = CType(resources.GetObject("axaVisorDocumentoPDF.OcxState"), System.Windows.Forms.AxHost.State)
        Me.axaVisorDocumentoPDF.Size = New System.Drawing.Size(758, 395)
        Me.axaVisorDocumentoPDF.TabIndex = 0
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.cboRUPMCLSE)
        Me.GroupBox11.Controls.Add(Me.cboRUPMCORR)
        Me.GroupBox11.Controls.Add(Me.cboRUPMMUNI)
        Me.GroupBox11.Controls.Add(Me.cboRUPMBAVE)
        Me.GroupBox11.Controls.Add(Me.cboRUPMDEPA)
        Me.GroupBox11.Controls.Add(Me.lblRUPMBAVE)
        Me.GroupBox11.Controls.Add(Me.Label8)
        Me.GroupBox11.Controls.Add(Me.lblRUPMDEPA)
        Me.GroupBox11.Controls.Add(Me.Label58)
        Me.GroupBox11.Controls.Add(Me.lblRUPMCORR)
        Me.GroupBox11.Controls.Add(Me.Label3)
        Me.GroupBox11.Controls.Add(Me.Label60)
        Me.GroupBox11.Controls.Add(Me.lblRUPMCLSE)
        Me.GroupBox11.Controls.Add(Me.Label27)
        Me.GroupBox11.Controls.Add(Me.lblRUPMMUNI)
        Me.GroupBox11.ForeColor = System.Drawing.Color.Black
        Me.GroupBox11.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(1051, 106)
        Me.GroupBox11.TabIndex = 54
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "CEDULA CATASTRAL"
        '
        'cboRUPMCLSE
        '
        Me.cboRUPMCLSE.AccessibleDescription = "Clase o sector "
        Me.cboRUPMCLSE.BackColor = System.Drawing.Color.White
        Me.cboRUPMCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUPMCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUPMCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUPMCLSE.Location = New System.Drawing.Point(147, 69)
        Me.cboRUPMCLSE.MaxDropDownItems = 15
        Me.cboRUPMCLSE.MaxLength = 1
        Me.cboRUPMCLSE.Name = "cboRUPMCLSE"
        Me.cboRUPMCLSE.Size = New System.Drawing.Size(303, 22)
        Me.cboRUPMCLSE.TabIndex = 3
        '
        'cboRUPMCORR
        '
        Me.cboRUPMCORR.AccessibleDescription = "Corregimiento"
        Me.cboRUPMCORR.BackColor = System.Drawing.Color.White
        Me.cboRUPMCORR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUPMCORR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUPMCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUPMCORR.Location = New System.Drawing.Point(663, 23)
        Me.cboRUPMCORR.MaxDropDownItems = 15
        Me.cboRUPMCORR.MaxLength = 1
        Me.cboRUPMCORR.Name = "cboRUPMCORR"
        Me.cboRUPMCORR.Size = New System.Drawing.Size(281, 22)
        Me.cboRUPMCORR.TabIndex = 4
        '
        'cboRUPMMUNI
        '
        Me.cboRUPMMUNI.AccessibleDescription = "Municipio"
        Me.cboRUPMMUNI.BackColor = System.Drawing.Color.White
        Me.cboRUPMMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUPMMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUPMMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUPMMUNI.Location = New System.Drawing.Point(147, 46)
        Me.cboRUPMMUNI.MaxDropDownItems = 15
        Me.cboRUPMMUNI.MaxLength = 1
        Me.cboRUPMMUNI.Name = "cboRUPMMUNI"
        Me.cboRUPMMUNI.Size = New System.Drawing.Size(303, 22)
        Me.cboRUPMMUNI.TabIndex = 2
        '
        'cboRUPMBAVE
        '
        Me.cboRUPMBAVE.AccessibleDescription = "Barrio - Vereda"
        Me.cboRUPMBAVE.BackColor = System.Drawing.Color.White
        Me.cboRUPMBAVE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUPMBAVE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUPMBAVE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUPMBAVE.Location = New System.Drawing.Point(663, 46)
        Me.cboRUPMBAVE.MaxDropDownItems = 15
        Me.cboRUPMBAVE.MaxLength = 1
        Me.cboRUPMBAVE.Name = "cboRUPMBAVE"
        Me.cboRUPMBAVE.Size = New System.Drawing.Size(281, 22)
        Me.cboRUPMBAVE.TabIndex = 6
        '
        'cboRUPMDEPA
        '
        Me.cboRUPMDEPA.AccessibleDescription = "Departamento"
        Me.cboRUPMDEPA.BackColor = System.Drawing.Color.White
        Me.cboRUPMDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUPMDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUPMDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUPMDEPA.Location = New System.Drawing.Point(147, 23)
        Me.cboRUPMDEPA.MaxDropDownItems = 15
        Me.cboRUPMDEPA.MaxLength = 1
        Me.cboRUPMDEPA.Name = "cboRUPMDEPA"
        Me.cboRUPMDEPA.Size = New System.Drawing.Size(303, 22)
        Me.cboRUPMDEPA.TabIndex = 1
        '
        'lblRUPMBAVE
        '
        Me.lblRUPMBAVE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUPMBAVE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUPMBAVE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUPMBAVE.ForeColor = System.Drawing.Color.Black
        Me.lblRUPMBAVE.Location = New System.Drawing.Point(948, 48)
        Me.lblRUPMBAVE.Name = "lblRUPMBAVE"
        Me.lblRUPMBAVE.Size = New System.Drawing.Size(85, 20)
        Me.lblRUPMBAVE.TabIndex = 383
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(534, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(126, 20)
        Me.Label8.TabIndex = 382
        Me.Label8.Text = "Barrio - Vereda"
        '
        'lblRUPMDEPA
        '
        Me.lblRUPMDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUPMDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUPMDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUPMDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblRUPMDEPA.Location = New System.Drawing.Point(454, 25)
        Me.lblRUPMDEPA.Name = "lblRUPMDEPA"
        Me.lblRUPMDEPA.Size = New System.Drawing.Size(76, 20)
        Me.lblRUPMDEPA.TabIndex = 381
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
        'lblRUPMCORR
        '
        Me.lblRUPMCORR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUPMCORR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUPMCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUPMCORR.ForeColor = System.Drawing.Color.Black
        Me.lblRUPMCORR.Location = New System.Drawing.Point(948, 25)
        Me.lblRUPMCORR.Name = "lblRUPMCORR"
        Me.lblRUPMCORR.Size = New System.Drawing.Size(85, 20)
        Me.lblRUPMCORR.TabIndex = 334
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(534, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 20)
        Me.Label3.TabIndex = 333
        Me.Label3.Text = "Corregimiento"
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
        'lblRUPMCLSE
        '
        Me.lblRUPMCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUPMCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUPMCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUPMCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblRUPMCLSE.Location = New System.Drawing.Point(454, 71)
        Me.lblRUPMCLSE.Name = "lblRUPMCLSE"
        Me.lblRUPMCLSE.Size = New System.Drawing.Size(76, 20)
        Me.lblRUPMCLSE.TabIndex = 327
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(17, 71)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(127, 20)
        Me.Label27.TabIndex = 326
        Me.Label27.Text = "Clase o sector"
        '
        'lblRUPMMUNI
        '
        Me.lblRUPMMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUPMMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUPMMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUPMMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblRUPMMUNI.Location = New System.Drawing.Point(454, 48)
        Me.lblRUPMMUNI.Name = "lblRUPMMUNI"
        Me.lblRUPMMUNI.Size = New System.Drawing.Size(76, 20)
        Me.lblRUPMMUNI.TabIndex = 325
        '
        'lstMANZANA
        '
        Me.lstMANZANA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstMANZANA.FormattingEnabled = True
        Me.lstMANZANA.Location = New System.Drawing.Point(3, 4)
        Me.lstMANZANA.Name = "lstMANZANA"
        Me.lstMANZANA.Size = New System.Drawing.Size(250, 381)
        Me.lstMANZANA.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(15, 19)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstMANZANA)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.axaVisorDocumentoPDF)
        Me.SplitContainer1.Size = New System.Drawing.Size(1018, 395)
        Me.SplitContainer1.SplitterDistance = 256
        Me.SplitContainer1.TabIndex = 56
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.SplitContainer1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 177)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1051, 430)
        Me.GroupBox1.TabIndex = 57
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CONSULTA"
        '
        'frm_consulta_plano_manzanero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 648)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_consulta_plano_manzanero"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CONSULTA PLANO MANZANERO"
        Me.GroupBox3.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        CType(Me.axaVisorDocumentoPDF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLIMPIAR As System.Windows.Forms.Button
    Friend WithEvents cmdCONSULTAR As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents cboRUPMCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents cboRUPMCORR As System.Windows.Forms.ComboBox
    Friend WithEvents cboRUPMMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents cboRUPMBAVE As System.Windows.Forms.ComboBox
    Friend WithEvents cboRUPMDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents lblRUPMBAVE As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblRUPMDEPA As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents lblRUPMCORR As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents lblRUPMCLSE As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lblRUPMMUNI As System.Windows.Forms.Label
    Friend WithEvents axaVisorDocumentoPDF As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents lstMANZANA As System.Windows.Forms.ListBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
