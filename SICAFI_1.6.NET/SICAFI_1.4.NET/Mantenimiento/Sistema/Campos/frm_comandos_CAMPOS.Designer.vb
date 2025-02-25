<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_comandos_CAMPOS
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fraCOMANDOS2 = New System.Windows.Forms.GroupBox()
        Me.cmdLIMPIAR = New System.Windows.Forms.Button()
        Me.cmdACEPTAR = New System.Windows.Forms.Button()
        Me.cmdCONSULTAR = New System.Windows.Forms.Button()
        Me.fraCONSULTA = New System.Windows.Forms.GroupBox()
        Me.dgvCONSULTA = New System.Windows.Forms.DataGridView()
        Me.fraCOMANDOS1 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraCAMPOS = New System.Windows.Forms.GroupBox()
        Me.txtCAMPLLSI = New System.Windows.Forms.TextBox()
        Me.txtCAMPLLMA = New System.Windows.Forms.TextBox()
        Me.txtCAMPLONG = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkCAMPSIST = New System.Windows.Forms.CheckBox()
        Me.lblCAMPTAMA = New System.Windows.Forms.Label()
        Me.cboCAMPTAMA = New System.Windows.Forms.ComboBox()
        Me.lblCAMPTASI = New System.Windows.Forms.Label()
        Me.cboCAMPTASI = New System.Windows.Forms.ComboBox()
        Me.chkCAMPMANT = New System.Windows.Forms.CheckBox()
        Me.chkCAMPCOND = New System.Windows.Forms.CheckBox()
        Me.chkCAMPREQU = New System.Windows.Forms.CheckBox()
        Me.chkCAMPLLPR = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbdCAMPTIDA_DECI = New System.Windows.Forms.RadioButton()
        Me.rbdCAMPTIDA_NUME = New System.Windows.Forms.RadioButton()
        Me.rbdCAMPTIDA_ALFA = New System.Windows.Forms.RadioButton()
        Me.txtCAMPDESC = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCAMPPROC = New System.Windows.Forms.Label()
        Me.cboCAMPPROC = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCAMPTABL = New System.Windows.Forms.Label()
        Me.cboCAMPTABL = New System.Windows.Forms.ComboBox()
        Me.lblMUNICIPIO = New System.Windows.Forms.Label()
        Me.cboCAMPESTA = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCAMPCODI = New System.Windows.Forms.TextBox()
        Me.lblCódigo = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.fraCOMANDOS2.SuspendLayout()
        Me.fraCONSULTA.SuspendLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraCOMANDOS1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraCAMPOS.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraCOMANDOS2
        '
        Me.fraCOMANDOS2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fraCOMANDOS2.Controls.Add(Me.cmdLIMPIAR)
        Me.fraCOMANDOS2.Controls.Add(Me.cmdACEPTAR)
        Me.fraCOMANDOS2.Controls.Add(Me.cmdCONSULTAR)
        Me.fraCOMANDOS2.Location = New System.Drawing.Point(13, 494)
        Me.fraCOMANDOS2.Name = "fraCOMANDOS2"
        Me.fraCOMANDOS2.Size = New System.Drawing.Size(643, 60)
        Me.fraCOMANDOS2.TabIndex = 84
        Me.fraCOMANDOS2.TabStop = False
        '
        'cmdLIMPIAR
        '
        Me.cmdLIMPIAR.AccessibleDescription = "Limpiar"
        Me.cmdLIMPIAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLIMPIAR.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLIMPIAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLIMPIAR.Location = New System.Drawing.Point(19, 20)
        Me.cmdLIMPIAR.Name = "cmdLIMPIAR"
        Me.cmdLIMPIAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdLIMPIAR.TabIndex = 5
        Me.cmdLIMPIAR.Text = "&Limpiar"
        Me.cmdLIMPIAR.UseVisualStyleBackColor = True
        '
        'cmdACEPTAR
        '
        Me.cmdACEPTAR.AccessibleDescription = "Aceptar"
        Me.cmdACEPTAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdACEPTAR.Enabled = False
        Me.cmdACEPTAR.Image = Global.SICAFI.My.Resources.Resources._22
        Me.cmdACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdACEPTAR.Location = New System.Drawing.Point(522, 20)
        Me.cmdACEPTAR.Name = "cmdACEPTAR"
        Me.cmdACEPTAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdACEPTAR.TabIndex = 7
        Me.cmdACEPTAR.Text = "&Aceptar"
        Me.cmdACEPTAR.UseVisualStyleBackColor = True
        '
        'cmdCONSULTAR
        '
        Me.cmdCONSULTAR.AccessibleDescription = "Consultar"
        Me.cmdCONSULTAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCONSULTAR.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdCONSULTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCONSULTAR.Location = New System.Drawing.Point(415, 20)
        Me.cmdCONSULTAR.Name = "cmdCONSULTAR"
        Me.cmdCONSULTAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdCONSULTAR.TabIndex = 6
        Me.cmdCONSULTAR.Text = "&Consultar"
        Me.cmdCONSULTAR.UseVisualStyleBackColor = True
        '
        'fraCONSULTA
        '
        Me.fraCONSULTA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fraCONSULTA.Controls.Add(Me.dgvCONSULTA)
        Me.fraCONSULTA.Location = New System.Drawing.Point(13, 323)
        Me.fraCONSULTA.Name = "fraCONSULTA"
        Me.fraCONSULTA.Size = New System.Drawing.Size(643, 165)
        Me.fraCONSULTA.TabIndex = 83
        Me.fraCONSULTA.TabStop = False
        Me.fraCONSULTA.Text = "CONSULTA"
        '
        'dgvCONSULTA
        '
        Me.dgvCONSULTA.AccessibleDescription = ""
        Me.dgvCONSULTA.AllowUserToAddRows = False
        Me.dgvCONSULTA.AllowUserToDeleteRows = False
        Me.dgvCONSULTA.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCONSULTA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCONSULTA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCONSULTA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCONSULTA.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCONSULTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCONSULTA.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCONSULTA.ColumnHeadersHeight = 30
        Me.dgvCONSULTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCONSULTA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA.Location = New System.Drawing.Point(19, 19)
        Me.dgvCONSULTA.MultiSelect = False
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        Me.dgvCONSULTA.RowHeadersVisible = False
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(604, 129)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 5
        '
        'fraCOMANDOS1
        '
        Me.fraCOMANDOS1.Controls.Add(Me.cmdSALIR)
        Me.fraCOMANDOS1.Controls.Add(Me.cmdGUARDAR)
        Me.fraCOMANDOS1.Location = New System.Drawing.Point(13, 265)
        Me.fraCOMANDOS1.Name = "fraCOMANDOS1"
        Me.fraCOMANDOS1.Size = New System.Drawing.Size(643, 54)
        Me.fraCOMANDOS1.TabIndex = 82
        Me.fraCOMANDOS1.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(522, 19)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 5
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(415, 19)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 4
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel2, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 566)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(670, 25)
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
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.AutoSize = False
        Me.ToolStripStatusLabel3.BackColor = System.Drawing.SystemColors.Window
        Me.ToolStripStatusLabel3.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel3.ForeColor = System.Drawing.Color.Red
        Me.ToolStripStatusLabel3.LinkColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel3.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(300, 22)
        Me.ToolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.AutoSize = False
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.SystemColors.Window
        Me.ToolStripStatusLabel2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(125, 22)
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tstBAESDESC
        '
        Me.tstBAESDESC.AutoSize = False
        Me.tstBAESDESC.BackColor = System.Drawing.SystemColors.InactiveCaptionText
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
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
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
        'fraCAMPOS
        '
        Me.fraCAMPOS.BackColor = System.Drawing.SystemColors.Control
        Me.fraCAMPOS.Controls.Add(Me.txtCAMPLLSI)
        Me.fraCAMPOS.Controls.Add(Me.txtCAMPLLMA)
        Me.fraCAMPOS.Controls.Add(Me.txtCAMPLONG)
        Me.fraCAMPOS.Controls.Add(Me.Label1)
        Me.fraCAMPOS.Controls.Add(Me.chkCAMPSIST)
        Me.fraCAMPOS.Controls.Add(Me.lblCAMPTAMA)
        Me.fraCAMPOS.Controls.Add(Me.cboCAMPTAMA)
        Me.fraCAMPOS.Controls.Add(Me.lblCAMPTASI)
        Me.fraCAMPOS.Controls.Add(Me.cboCAMPTASI)
        Me.fraCAMPOS.Controls.Add(Me.chkCAMPMANT)
        Me.fraCAMPOS.Controls.Add(Me.chkCAMPCOND)
        Me.fraCAMPOS.Controls.Add(Me.chkCAMPREQU)
        Me.fraCAMPOS.Controls.Add(Me.chkCAMPLLPR)
        Me.fraCAMPOS.Controls.Add(Me.GroupBox1)
        Me.fraCAMPOS.Controls.Add(Me.txtCAMPDESC)
        Me.fraCAMPOS.Controls.Add(Me.Label3)
        Me.fraCAMPOS.Controls.Add(Me.lblCAMPPROC)
        Me.fraCAMPOS.Controls.Add(Me.cboCAMPPROC)
        Me.fraCAMPOS.Controls.Add(Me.Label4)
        Me.fraCAMPOS.Controls.Add(Me.lblCAMPTABL)
        Me.fraCAMPOS.Controls.Add(Me.cboCAMPTABL)
        Me.fraCAMPOS.Controls.Add(Me.lblMUNICIPIO)
        Me.fraCAMPOS.Controls.Add(Me.cboCAMPESTA)
        Me.fraCAMPOS.Controls.Add(Me.Label2)
        Me.fraCAMPOS.Controls.Add(Me.txtCAMPCODI)
        Me.fraCAMPOS.Controls.Add(Me.lblCódigo)
        Me.fraCAMPOS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraCAMPOS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraCAMPOS.Location = New System.Drawing.Point(13, 7)
        Me.fraCAMPOS.Name = "fraCAMPOS"
        Me.fraCAMPOS.Size = New System.Drawing.Size(643, 252)
        Me.fraCAMPOS.TabIndex = 80
        Me.fraCAMPOS.TabStop = False
        Me.fraCAMPOS.Text = "CAMPOS"
        '
        'txtCAMPLLSI
        '
        Me.txtCAMPLLSI.AccessibleDescription = "Llave sistema"
        Me.txtCAMPLLSI.BackColor = System.Drawing.SystemColors.Window
        Me.txtCAMPLLSI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCAMPLLSI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCAMPLLSI.Location = New System.Drawing.Point(467, 191)
        Me.txtCAMPLLSI.MaxLength = 20
        Me.txtCAMPLLSI.Name = "txtCAMPLLSI"
        Me.txtCAMPLLSI.Size = New System.Drawing.Size(156, 20)
        Me.txtCAMPLLSI.TabIndex = 13
        '
        'txtCAMPLLMA
        '
        Me.txtCAMPLLMA.AccessibleDescription = "Llave mantenimiento"
        Me.txtCAMPLLMA.BackColor = System.Drawing.SystemColors.Window
        Me.txtCAMPLLMA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCAMPLLMA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCAMPLLMA.Location = New System.Drawing.Point(467, 168)
        Me.txtCAMPLLMA.MaxLength = 20
        Me.txtCAMPLLMA.Name = "txtCAMPLLMA"
        Me.txtCAMPLLMA.Size = New System.Drawing.Size(156, 20)
        Me.txtCAMPLLMA.TabIndex = 11
        '
        'txtCAMPLONG
        '
        Me.txtCAMPLONG.AccessibleDescription = "Longitud"
        Me.txtCAMPLONG.BackColor = System.Drawing.SystemColors.Window
        Me.txtCAMPLONG.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCAMPLONG.Location = New System.Drawing.Point(136, 116)
        Me.txtCAMPLONG.MaxLength = 3
        Me.txtCAMPLONG.Name = "txtCAMPLONG"
        Me.txtCAMPLONG.Size = New System.Drawing.Size(84, 20)
        Me.txtCAMPLONG.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Longitud"
        '
        'chkCAMPSIST
        '
        Me.chkCAMPSIST.AccessibleDescription = "Sistema"
        Me.chkCAMPSIST.AutoSize = True
        Me.chkCAMPSIST.Location = New System.Drawing.Point(19, 191)
        Me.chkCAMPSIST.Name = "chkCAMPSIST"
        Me.chkCAMPSIST.Size = New System.Drawing.Size(72, 19)
        Me.chkCAMPSIST.TabIndex = 11
        Me.chkCAMPSIST.Text = "Sistema"
        Me.chkCAMPSIST.UseVisualStyleBackColor = True
        '
        'lblCAMPTAMA
        '
        Me.lblCAMPTAMA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCAMPTAMA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAMPTAMA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAMPTAMA.ForeColor = System.Drawing.Color.Black
        Me.lblCAMPTAMA.Location = New System.Drawing.Point(332, 168)
        Me.lblCAMPTAMA.Name = "lblCAMPTAMA"
        Me.lblCAMPTAMA.Size = New System.Drawing.Size(129, 20)
        Me.lblCAMPTAMA.TabIndex = 69
        '
        'cboCAMPTAMA
        '
        Me.cboCAMPTAMA.AccessibleDescription = "Tabla mantenimiento"
        Me.cboCAMPTAMA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCAMPTAMA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCAMPTAMA.Enabled = False
        Me.cboCAMPTAMA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCAMPTAMA.FormattingEnabled = True
        Me.cboCAMPTAMA.Location = New System.Drawing.Point(137, 168)
        Me.cboCAMPTAMA.Name = "cboCAMPTAMA"
        Me.cboCAMPTAMA.Size = New System.Drawing.Size(189, 22)
        Me.cboCAMPTAMA.TabIndex = 10
        '
        'lblCAMPTASI
        '
        Me.lblCAMPTASI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCAMPTASI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAMPTASI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAMPTASI.ForeColor = System.Drawing.Color.Black
        Me.lblCAMPTASI.Location = New System.Drawing.Point(332, 192)
        Me.lblCAMPTASI.Name = "lblCAMPTASI"
        Me.lblCAMPTASI.Size = New System.Drawing.Size(129, 20)
        Me.lblCAMPTASI.TabIndex = 68
        '
        'cboCAMPTASI
        '
        Me.cboCAMPTASI.AccessibleDescription = "Tabla sistema"
        Me.cboCAMPTASI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCAMPTASI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCAMPTASI.Enabled = False
        Me.cboCAMPTASI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCAMPTASI.FormattingEnabled = True
        Me.cboCAMPTASI.Location = New System.Drawing.Point(137, 191)
        Me.cboCAMPTASI.Name = "cboCAMPTASI"
        Me.cboCAMPTASI.Size = New System.Drawing.Size(189, 22)
        Me.cboCAMPTASI.TabIndex = 12
        '
        'chkCAMPMANT
        '
        Me.chkCAMPMANT.AccessibleDescription = "Mantenimiento"
        Me.chkCAMPMANT.AutoSize = True
        Me.chkCAMPMANT.Location = New System.Drawing.Point(19, 167)
        Me.chkCAMPMANT.Name = "chkCAMPMANT"
        Me.chkCAMPMANT.Size = New System.Drawing.Size(107, 19)
        Me.chkCAMPMANT.TabIndex = 9
        Me.chkCAMPMANT.Text = "Mantenimiento"
        Me.chkCAMPMANT.UseVisualStyleBackColor = True
        '
        'chkCAMPCOND
        '
        Me.chkCAMPCOND.AccessibleDescription = "Condicional"
        Me.chkCAMPCOND.AutoSize = True
        Me.chkCAMPCOND.Location = New System.Drawing.Point(231, 143)
        Me.chkCAMPCOND.Name = "chkCAMPCOND"
        Me.chkCAMPCOND.Size = New System.Drawing.Size(92, 19)
        Me.chkCAMPCOND.TabIndex = 8
        Me.chkCAMPCOND.Text = "Condicional"
        Me.chkCAMPCOND.UseVisualStyleBackColor = True
        '
        'chkCAMPREQU
        '
        Me.chkCAMPREQU.AccessibleDescription = "Requerido"
        Me.chkCAMPREQU.AutoSize = True
        Me.chkCAMPREQU.Location = New System.Drawing.Point(136, 143)
        Me.chkCAMPREQU.Name = "chkCAMPREQU"
        Me.chkCAMPREQU.Size = New System.Drawing.Size(84, 19)
        Me.chkCAMPREQU.TabIndex = 7
        Me.chkCAMPREQU.Text = "Requerido"
        Me.chkCAMPREQU.UseVisualStyleBackColor = True
        '
        'chkCAMPLLPR
        '
        Me.chkCAMPLLPR.AccessibleDescription = "Llave primaria"
        Me.chkCAMPLLPR.AutoSize = True
        Me.chkCAMPLLPR.Location = New System.Drawing.Point(19, 143)
        Me.chkCAMPLLPR.Name = "chkCAMPLLPR"
        Me.chkCAMPLLPR.Size = New System.Drawing.Size(104, 19)
        Me.chkCAMPLLPR.TabIndex = 6
        Me.chkCAMPLLPR.Text = "Llave primaria"
        Me.chkCAMPLLPR.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbdCAMPTIDA_DECI)
        Me.GroupBox1.Controls.Add(Me.rbdCAMPTIDA_NUME)
        Me.GroupBox1.Controls.Add(Me.rbdCAMPTIDA_ALFA)
        Me.GroupBox1.Location = New System.Drawing.Point(467, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(156, 91)
        Me.GroupBox1.TabIndex = 61
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de dato"
        '
        'rbdCAMPTIDA_DECI
        '
        Me.rbdCAMPTIDA_DECI.AccessibleDescription = "Decimal"
        Me.rbdCAMPTIDA_DECI.AutoSize = True
        Me.rbdCAMPTIDA_DECI.Location = New System.Drawing.Point(18, 63)
        Me.rbdCAMPTIDA_DECI.Name = "rbdCAMPTIDA_DECI"
        Me.rbdCAMPTIDA_DECI.Size = New System.Drawing.Size(71, 19)
        Me.rbdCAMPTIDA_DECI.TabIndex = 2
        Me.rbdCAMPTIDA_DECI.Text = "Decimal"
        Me.rbdCAMPTIDA_DECI.UseVisualStyleBackColor = True
        '
        'rbdCAMPTIDA_NUME
        '
        Me.rbdCAMPTIDA_NUME.AccessibleDescription = "Numerico"
        Me.rbdCAMPTIDA_NUME.AutoSize = True
        Me.rbdCAMPTIDA_NUME.Location = New System.Drawing.Point(18, 41)
        Me.rbdCAMPTIDA_NUME.Name = "rbdCAMPTIDA_NUME"
        Me.rbdCAMPTIDA_NUME.Size = New System.Drawing.Size(79, 19)
        Me.rbdCAMPTIDA_NUME.TabIndex = 1
        Me.rbdCAMPTIDA_NUME.Text = "Numérico"
        Me.rbdCAMPTIDA_NUME.UseVisualStyleBackColor = True
        '
        'rbdCAMPTIDA_ALFA
        '
        Me.rbdCAMPTIDA_ALFA.AccessibleDescription = "Alfanumerico"
        Me.rbdCAMPTIDA_ALFA.AutoSize = True
        Me.rbdCAMPTIDA_ALFA.Checked = True
        Me.rbdCAMPTIDA_ALFA.Location = New System.Drawing.Point(18, 20)
        Me.rbdCAMPTIDA_ALFA.Name = "rbdCAMPTIDA_ALFA"
        Me.rbdCAMPTIDA_ALFA.Size = New System.Drawing.Size(97, 19)
        Me.rbdCAMPTIDA_ALFA.TabIndex = 0
        Me.rbdCAMPTIDA_ALFA.TabStop = True
        Me.rbdCAMPTIDA_ALFA.Text = "Alfanumérico"
        Me.rbdCAMPTIDA_ALFA.UseVisualStyleBackColor = True
        '
        'txtCAMPDESC
        '
        Me.txtCAMPDESC.AccessibleDescription = "Descripción"
        Me.txtCAMPDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtCAMPDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCAMPDESC.Location = New System.Drawing.Point(136, 93)
        Me.txtCAMPDESC.MaxLength = 50
        Me.txtCAMPDESC.Name = "txtCAMPDESC"
        Me.txtCAMPDESC.Size = New System.Drawing.Size(325, 20)
        Me.txtCAMPDESC.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Descripción"
        '
        'lblCAMPPROC
        '
        Me.lblCAMPPROC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCAMPPROC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAMPPROC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAMPPROC.ForeColor = System.Drawing.Color.Black
        Me.lblCAMPPROC.Location = New System.Drawing.Point(467, 24)
        Me.lblCAMPPROC.Name = "lblCAMPPROC"
        Me.lblCAMPPROC.Size = New System.Drawing.Size(156, 20)
        Me.lblCAMPPROC.TabIndex = 58
        '
        'cboCAMPPROC
        '
        Me.cboCAMPPROC.AccessibleDescription = "Procedimiento"
        Me.cboCAMPPROC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCAMPPROC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCAMPPROC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCAMPPROC.FormattingEnabled = True
        Me.cboCAMPPROC.Location = New System.Drawing.Point(137, 22)
        Me.cboCAMPPROC.Name = "cboCAMPPROC"
        Me.cboCAMPPROC.Size = New System.Drawing.Size(324, 22)
        Me.cboCAMPPROC.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 20)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Procedimiento"
        '
        'lblCAMPTABL
        '
        Me.lblCAMPTABL.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCAMPTABL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAMPTABL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAMPTABL.ForeColor = System.Drawing.Color.Black
        Me.lblCAMPTABL.Location = New System.Drawing.Point(467, 47)
        Me.lblCAMPTABL.Name = "lblCAMPTABL"
        Me.lblCAMPTABL.Size = New System.Drawing.Size(156, 20)
        Me.lblCAMPTABL.TabIndex = 56
        '
        'cboCAMPTABL
        '
        Me.cboCAMPTABL.AccessibleDescription = "Tabla"
        Me.cboCAMPTABL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCAMPTABL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCAMPTABL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCAMPTABL.FormattingEnabled = True
        Me.cboCAMPTABL.Location = New System.Drawing.Point(137, 45)
        Me.cboCAMPTABL.Name = "cboCAMPTABL"
        Me.cboCAMPTABL.Size = New System.Drawing.Size(324, 22)
        Me.cboCAMPTABL.TabIndex = 2
        '
        'lblMUNICIPIO
        '
        Me.lblMUNICIPIO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMUNICIPIO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUNICIPIO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUNICIPIO.ForeColor = System.Drawing.Color.Black
        Me.lblMUNICIPIO.Location = New System.Drawing.Point(19, 47)
        Me.lblMUNICIPIO.Name = "lblMUNICIPIO"
        Me.lblMUNICIPIO.Size = New System.Drawing.Size(112, 20)
        Me.lblMUNICIPIO.TabIndex = 55
        Me.lblMUNICIPIO.Text = "Tabla"
        '
        'cboCAMPESTA
        '
        Me.cboCAMPESTA.AccessibleDescription = "Estado"
        Me.cboCAMPESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCAMPESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCAMPESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCAMPESTA.FormattingEnabled = True
        Me.cboCAMPESTA.Location = New System.Drawing.Point(137, 214)
        Me.cboCAMPESTA.Name = "cboCAMPESTA"
        Me.cboCAMPESTA.Size = New System.Drawing.Size(141, 22)
        Me.cboCAMPESTA.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 216)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Estado"
        '
        'txtCAMPCODI
        '
        Me.txtCAMPCODI.AccessibleDescription = "Campo"
        Me.txtCAMPCODI.BackColor = System.Drawing.SystemColors.Window
        Me.txtCAMPCODI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCAMPCODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCAMPCODI.Location = New System.Drawing.Point(137, 70)
        Me.txtCAMPCODI.MaxLength = 20
        Me.txtCAMPCODI.Name = "txtCAMPCODI"
        Me.txtCAMPCODI.Size = New System.Drawing.Size(324, 20)
        Me.txtCAMPCODI.TabIndex = 3
        '
        'lblCódigo
        '
        Me.lblCódigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCódigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCódigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCódigo.ForeColor = System.Drawing.Color.Black
        Me.lblCódigo.Location = New System.Drawing.Point(19, 70)
        Me.lblCódigo.Name = "lblCódigo"
        Me.lblCódigo.Size = New System.Drawing.Size(112, 20)
        Me.lblCódigo.TabIndex = 37
        Me.lblCódigo.Text = "Campo"
        '
        'TextBox2
        '
        Me.TextBox2.AccessibleDescription = "Longitud"
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(136, 116)
        Me.TextBox2.MaxLength = 5
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(187, 20)
        Me.TextBox2.TabIndex = 5
        '
        'frm_comandos_CAMPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 591)
        Me.Controls.Add(Me.fraCOMANDOS2)
        Me.Controls.Add(Me.fraCONSULTA)
        Me.Controls.Add(Me.fraCOMANDOS1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCAMPOS)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_comandos_CAMPOS"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.fraCOMANDOS2.ResumeLayout(False)
        Me.fraCONSULTA.ResumeLayout(False)
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraCOMANDOS1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraCAMPOS.ResumeLayout(False)
        Me.fraCAMPOS.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraCOMANDOS2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLIMPIAR As System.Windows.Forms.Button
    Friend WithEvents cmdACEPTAR As System.Windows.Forms.Button
    Friend WithEvents cmdCONSULTAR As System.Windows.Forms.Button
    Friend WithEvents fraCONSULTA As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents fraCOMANDOS1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraCAMPOS As System.Windows.Forms.GroupBox
    Friend WithEvents cboCAMPESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCAMPCODI As System.Windows.Forms.TextBox
    Friend WithEvents lblCódigo As System.Windows.Forms.Label
    Friend WithEvents txtCAMPDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCAMPPROC As System.Windows.Forms.Label
    Friend WithEvents cboCAMPPROC As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCAMPTABL As System.Windows.Forms.Label
    Friend WithEvents cboCAMPTABL As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents chkCAMPCOND As System.Windows.Forms.CheckBox
    Friend WithEvents chkCAMPREQU As System.Windows.Forms.CheckBox
    Friend WithEvents chkCAMPLLPR As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdCAMPTIDA_NUME As System.Windows.Forms.RadioButton
    Friend WithEvents rbdCAMPTIDA_ALFA As System.Windows.Forms.RadioButton
    Friend WithEvents txtCAMPLONG As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkCAMPSIST As System.Windows.Forms.CheckBox
    Friend WithEvents lblCAMPTAMA As System.Windows.Forms.Label
    Friend WithEvents cboCAMPTAMA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCAMPTASI As System.Windows.Forms.Label
    Friend WithEvents cboCAMPTASI As System.Windows.Forms.ComboBox
    Friend WithEvents chkCAMPMANT As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents rbdCAMPTIDA_DECI As System.Windows.Forms.RadioButton
    Friend WithEvents txtCAMPLLSI As System.Windows.Forms.TextBox
    Friend WithEvents txtCAMPLLMA As System.Windows.Forms.TextBox
End Class
