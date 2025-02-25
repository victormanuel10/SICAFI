<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_RESOLUCION_FICHPRED
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consultar_RESOLUCION_FICHPRED))
        Me.fraRESOLUCION = New System.Windows.Forms.GroupBox
        Me.lblRESOCODI = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkRESOPATO = New System.Windows.Forms.CheckBox
        Me.lblRESOVIGE = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblRESODEPA = New System.Windows.Forms.Label
        Me.lblRESOCLSE = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblRESOTIRE = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblRESOMUNI = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.cmdACEPTAR = New System.Windows.Forms.Button
        Me.dgvRESOLUCION = New System.Windows.Forms.DataGridView
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.BindingSource_RESOLUCION_1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigator_RESOLUCION_1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.fraRESOLUCION.SuspendLayout()
        CType(Me.dgvRESOLUCION, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        CType(Me.BindingSource_RESOLUCION_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator_RESOLUCION_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator_RESOLUCION_1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraRESOLUCION
        '
        Me.fraRESOLUCION.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraRESOLUCION.BackColor = System.Drawing.SystemColors.Control
        Me.fraRESOLUCION.Controls.Add(Me.lblRESOCODI)
        Me.fraRESOLUCION.Controls.Add(Me.Label1)
        Me.fraRESOLUCION.Controls.Add(Me.chkRESOPATO)
        Me.fraRESOLUCION.Controls.Add(Me.lblRESOVIGE)
        Me.fraRESOLUCION.Controls.Add(Me.Label7)
        Me.fraRESOLUCION.Controls.Add(Me.lblRESODEPA)
        Me.fraRESOLUCION.Controls.Add(Me.lblRESOCLSE)
        Me.fraRESOLUCION.Controls.Add(Me.Label6)
        Me.fraRESOLUCION.Controls.Add(Me.lblRESOTIRE)
        Me.fraRESOLUCION.Controls.Add(Me.Label3)
        Me.fraRESOLUCION.Controls.Add(Me.Label2)
        Me.fraRESOLUCION.Controls.Add(Me.lblRESOMUNI)
        Me.fraRESOLUCION.Controls.Add(Me.Label5)
        Me.fraRESOLUCION.Controls.Add(Me.cmdSALIR)
        Me.fraRESOLUCION.Controls.Add(Me.cmdACEPTAR)
        Me.fraRESOLUCION.Controls.Add(Me.dgvRESOLUCION)
        Me.fraRESOLUCION.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraRESOLUCION.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraRESOLUCION.Location = New System.Drawing.Point(12, 28)
        Me.fraRESOLUCION.Name = "fraRESOLUCION"
        Me.fraRESOLUCION.Size = New System.Drawing.Size(832, 361)
        Me.fraRESOLUCION.TabIndex = 29
        Me.fraRESOLUCION.TabStop = False
        Me.fraRESOLUCION.Text = "CONSULTAR RESOLUCIÓN"
        '
        'lblRESOCODI
        '
        Me.lblRESOCODI.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRESOCODI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOCODI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOCODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOCODI.ForeColor = System.Drawing.Color.Black
        Me.lblRESOCODI.Location = New System.Drawing.Point(535, 292)
        Me.lblRESOCODI.Name = "lblRESOCODI"
        Me.lblRESOCODI.Size = New System.Drawing.Size(156, 20)
        Me.lblRESOCODI.TabIndex = 75
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(417, 292)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Código"
        '
        'chkRESOPATO
        '
        Me.chkRESOPATO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkRESOPATO.AutoSize = True
        Me.chkRESOPATO.Location = New System.Drawing.Point(697, 293)
        Me.chkRESOPATO.Name = "chkRESOPATO"
        Me.chkRESOPATO.Size = New System.Drawing.Size(115, 19)
        Me.chkRESOPATO.TabIndex = 73
        Me.chkRESOPATO.Text = "Resolución total"
        Me.chkRESOPATO.UseVisualStyleBackColor = True
        '
        'lblRESOVIGE
        '
        Me.lblRESOVIGE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRESOVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblRESOVIGE.Location = New System.Drawing.Point(535, 246)
        Me.lblRESOVIGE.Name = "lblRESOVIGE"
        Me.lblRESOVIGE.Size = New System.Drawing.Size(277, 20)
        Me.lblRESOVIGE.TabIndex = 72
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(417, 246)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 20)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "Vigencia"
        '
        'lblRESODEPA
        '
        Me.lblRESODEPA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRESODEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESODEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESODEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESODEPA.ForeColor = System.Drawing.Color.Black
        Me.lblRESODEPA.Location = New System.Drawing.Point(137, 246)
        Me.lblRESODEPA.Name = "lblRESODEPA"
        Me.lblRESODEPA.Size = New System.Drawing.Size(274, 20)
        Me.lblRESODEPA.TabIndex = 66
        '
        'lblRESOCLSE
        '
        Me.lblRESOCLSE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRESOCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblRESOCLSE.Location = New System.Drawing.Point(535, 269)
        Me.lblRESOCLSE.Name = "lblRESOCLSE"
        Me.lblRESOCLSE.Size = New System.Drawing.Size(277, 20)
        Me.lblRESOCLSE.TabIndex = 71
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(417, 269)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "Clase o sector"
        '
        'lblRESOTIRE
        '
        Me.lblRESOTIRE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRESOTIRE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOTIRE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOTIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOTIRE.ForeColor = System.Drawing.Color.Black
        Me.lblRESOTIRE.Location = New System.Drawing.Point(137, 292)
        Me.lblRESOTIRE.Name = "lblRESOTIRE"
        Me.lblRESOTIRE.Size = New System.Drawing.Size(274, 20)
        Me.lblRESOTIRE.TabIndex = 68
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 292)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Tipo de resolución"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 246)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Departamento"
        '
        'lblRESOMUNI
        '
        Me.lblRESOMUNI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRESOMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblRESOMUNI.Location = New System.Drawing.Point(137, 269)
        Me.lblRESOMUNI.Name = "lblRESOMUNI"
        Me.lblRESOMUNI.Size = New System.Drawing.Size(274, 20)
        Me.lblRESOMUNI.TabIndex = 64
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 269)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "Municipio"
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(417, 323)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 61
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdACEPTAR
        '
        Me.cmdACEPTAR.AccessibleDescription = "Aceptar"
        Me.cmdACEPTAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdACEPTAR.Image = Global.SICAFI.My.Resources.Resources._208
        Me.cmdACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdACEPTAR.Location = New System.Drawing.Point(310, 323)
        Me.cmdACEPTAR.Name = "cmdACEPTAR"
        Me.cmdACEPTAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdACEPTAR.TabIndex = 60
        Me.cmdACEPTAR.Text = "&Aceptar"
        Me.cmdACEPTAR.UseVisualStyleBackColor = True
        '
        'dgvRESOLUCION
        '
        Me.dgvRESOLUCION.AccessibleDescription = "Resolución"
        Me.dgvRESOLUCION.AllowUserToAddRows = False
        Me.dgvRESOLUCION.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvRESOLUCION.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRESOLUCION.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRESOLUCION.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRESOLUCION.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvRESOLUCION.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvRESOLUCION.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvRESOLUCION.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvRESOLUCION.ColumnHeadersHeight = 40
        Me.dgvRESOLUCION.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvRESOLUCION.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvRESOLUCION.Location = New System.Drawing.Point(19, 26)
        Me.dgvRESOLUCION.MultiSelect = False
        Me.dgvRESOLUCION.Name = "dgvRESOLUCION"
        Me.dgvRESOLUCION.ReadOnly = True
        Me.dgvRESOLUCION.RowHeadersVisible = False
        Me.dgvRESOLUCION.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRESOLUCION.ShowCellToolTips = False
        Me.dgvRESOLUCION.Size = New System.Drawing.Size(793, 207)
        Me.dgvRESOLUCION.StandardTab = True
        Me.dgvRESOLUCION.TabIndex = 0
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 405)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(856, 25)
        Me.strBARRESTA.TabIndex = 28
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
        'BindingNavigator_RESOLUCION_1
        '
        Me.BindingNavigator_RESOLUCION_1.AddNewItem = Nothing
        Me.BindingNavigator_RESOLUCION_1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator_RESOLUCION_1.DeleteItem = Nothing
        Me.BindingNavigator_RESOLUCION_1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator_RESOLUCION_1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator_RESOLUCION_1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator_RESOLUCION_1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator_RESOLUCION_1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator_RESOLUCION_1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator_RESOLUCION_1.Name = "BindingNavigator_RESOLUCION_1"
        Me.BindingNavigator_RESOLUCION_1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator_RESOLUCION_1.Size = New System.Drawing.Size(856, 25)
        Me.BindingNavigator_RESOLUCION_1.TabIndex = 30
        Me.BindingNavigator_RESOLUCION_1.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Número total de elementos"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Mover primero"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Mover anterior"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Posición"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Posición actual"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Mover siguiente"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Mover último"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'frm_consultar_RESOLUCION_FICHPRED
        '
        Me.AcceptButton = Me.cmdACEPTAR
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 430)
        Me.Controls.Add(Me.BindingNavigator_RESOLUCION_1)
        Me.Controls.Add(Me.fraRESOLUCION)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Name = "frm_consultar_RESOLUCION_FICHPRED"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar registro"
        Me.fraRESOLUCION.ResumeLayout(False)
        Me.fraRESOLUCION.PerformLayout()
        CType(Me.dgvRESOLUCION, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        CType(Me.BindingSource_RESOLUCION_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator_RESOLUCION_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator_RESOLUCION_1.ResumeLayout(False)
        Me.BindingNavigator_RESOLUCION_1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraRESOLUCION As System.Windows.Forms.GroupBox
    Friend WithEvents dgvRESOLUCION As System.Windows.Forms.DataGridView
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdACEPTAR As System.Windows.Forms.Button
    Friend WithEvents BindingSource_RESOLUCION_1 As System.Windows.Forms.BindingSource
    Friend WithEvents BindingNavigator_RESOLUCION_1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblRESOCODI As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkRESOPATO As System.Windows.Forms.CheckBox
    Friend WithEvents lblRESOVIGE As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblRESODEPA As System.Windows.Forms.Label
    Friend WithEvents lblRESOCLSE As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblRESOTIRE As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblRESOMUNI As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
