<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_comandos_TABLAS
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
        Me.fraTABLAS = New System.Windows.Forms.GroupBox()
        Me.rbdTABLSIST = New System.Windows.Forms.RadioButton()
        Me.rbdTABLMANT = New System.Windows.Forms.RadioButton()
        Me.rbdTABLPRIN = New System.Windows.Forms.RadioButton()
        Me.cboTABLESTA = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTABLDESC = New System.Windows.Forms.TextBox()
        Me.txtTABLCODI = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCódigo = New System.Windows.Forms.Label()
        Me.fraCOMANDOS2.SuspendLayout()
        Me.fraCONSULTA.SuspendLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraCOMANDOS1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraTABLAS.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraCOMANDOS2
        '
        Me.fraCOMANDOS2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fraCOMANDOS2.Controls.Add(Me.cmdLIMPIAR)
        Me.fraCOMANDOS2.Controls.Add(Me.cmdACEPTAR)
        Me.fraCOMANDOS2.Controls.Add(Me.cmdCONSULTAR)
        Me.fraCOMANDOS2.Location = New System.Drawing.Point(13, 350)
        Me.fraCOMANDOS2.Name = "fraCOMANDOS2"
        Me.fraCOMANDOS2.Size = New System.Drawing.Size(643, 60)
        Me.fraCOMANDOS2.TabIndex = 79
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
        Me.fraCONSULTA.Location = New System.Drawing.Point(13, 179)
        Me.fraCONSULTA.Name = "fraCONSULTA"
        Me.fraCONSULTA.Size = New System.Drawing.Size(643, 165)
        Me.fraCONSULTA.TabIndex = 78
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
        Me.fraCOMANDOS1.Location = New System.Drawing.Point(13, 119)
        Me.fraCOMANDOS1.Name = "fraCOMANDOS1"
        Me.fraCOMANDOS1.Size = New System.Drawing.Size(643, 54)
        Me.fraCOMANDOS1.TabIndex = 77
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 422)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(670, 25)
        Me.strBARRESTA.TabIndex = 76
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
        'fraTABLAS
        '
        Me.fraTABLAS.BackColor = System.Drawing.SystemColors.Control
        Me.fraTABLAS.Controls.Add(Me.rbdTABLSIST)
        Me.fraTABLAS.Controls.Add(Me.rbdTABLMANT)
        Me.fraTABLAS.Controls.Add(Me.rbdTABLPRIN)
        Me.fraTABLAS.Controls.Add(Me.cboTABLESTA)
        Me.fraTABLAS.Controls.Add(Me.Label2)
        Me.fraTABLAS.Controls.Add(Me.txtTABLDESC)
        Me.fraTABLAS.Controls.Add(Me.txtTABLCODI)
        Me.fraTABLAS.Controls.Add(Me.Label1)
        Me.fraTABLAS.Controls.Add(Me.lblCódigo)
        Me.fraTABLAS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraTABLAS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraTABLAS.Location = New System.Drawing.Point(13, 7)
        Me.fraTABLAS.Name = "fraTABLAS"
        Me.fraTABLAS.Size = New System.Drawing.Size(643, 106)
        Me.fraTABLAS.TabIndex = 75
        Me.fraTABLAS.TabStop = False
        Me.fraTABLAS.Text = "TABLAS"
        '
        'rbdTABLSIST
        '
        Me.rbdTABLSIST.AccessibleDescription = "Sistema"
        Me.rbdTABLSIST.AutoSize = True
        Me.rbdTABLSIST.Location = New System.Drawing.Point(252, 75)
        Me.rbdTABLSIST.Name = "rbdTABLSIST"
        Me.rbdTABLSIST.Size = New System.Drawing.Size(71, 19)
        Me.rbdTABLSIST.TabIndex = 6
        Me.rbdTABLSIST.Text = "Sistema"
        Me.rbdTABLSIST.UseVisualStyleBackColor = True
        '
        'rbdTABLMANT
        '
        Me.rbdTABLMANT.AccessibleDescription = "Mantenimiento"
        Me.rbdTABLMANT.AutoSize = True
        Me.rbdTABLMANT.Location = New System.Drawing.Point(121, 75)
        Me.rbdTABLMANT.Name = "rbdTABLMANT"
        Me.rbdTABLMANT.Size = New System.Drawing.Size(106, 19)
        Me.rbdTABLMANT.TabIndex = 5
        Me.rbdTABLMANT.Text = "Mantenimiento"
        Me.rbdTABLMANT.UseVisualStyleBackColor = True
        '
        'rbdTABLPRIN
        '
        Me.rbdTABLPRIN.AccessibleDescription = "Principal"
        Me.rbdTABLPRIN.AutoSize = True
        Me.rbdTABLPRIN.Checked = True
        Me.rbdTABLPRIN.Location = New System.Drawing.Point(20, 75)
        Me.rbdTABLPRIN.Name = "rbdTABLPRIN"
        Me.rbdTABLPRIN.Size = New System.Drawing.Size(73, 19)
        Me.rbdTABLPRIN.TabIndex = 4
        Me.rbdTABLPRIN.TabStop = True
        Me.rbdTABLPRIN.Text = "Principal"
        Me.rbdTABLPRIN.UseVisualStyleBackColor = True
        '
        'cboTABLESTA
        '
        Me.cboTABLESTA.AccessibleDescription = "Estado"
        Me.cboTABLESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTABLESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTABLESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTABLESTA.FormattingEnabled = True
        Me.cboTABLESTA.Location = New System.Drawing.Point(518, 49)
        Me.cboTABLESTA.Name = "cboTABLESTA"
        Me.cboTABLESTA.Size = New System.Drawing.Size(105, 22)
        Me.cboTABLESTA.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(518, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Estado"
        '
        'txtTABLDESC
        '
        Me.txtTABLDESC.AccessibleDescription = "Descripción"
        Me.txtTABLDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtTABLDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTABLDESC.Location = New System.Drawing.Point(179, 49)
        Me.txtTABLDESC.MaxLength = 50
        Me.txtTABLDESC.Name = "txtTABLDESC"
        Me.txtTABLDESC.Size = New System.Drawing.Size(337, 20)
        Me.txtTABLDESC.TabIndex = 2
        '
        'txtTABLCODI
        '
        Me.txtTABLCODI.AccessibleDescription = "Código"
        Me.txtTABLCODI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTABLCODI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTABLCODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTABLCODI.Location = New System.Drawing.Point(19, 49)
        Me.txtTABLCODI.MaxLength = 20
        Me.txtTABLCODI.Name = "txtTABLCODI"
        Me.txtTABLCODI.Size = New System.Drawing.Size(157, 20)
        Me.txtTABLCODI.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(179, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(336, 20)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Descripción"
        '
        'lblCódigo
        '
        Me.lblCódigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCódigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCódigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCódigo.ForeColor = System.Drawing.Color.Black
        Me.lblCódigo.Location = New System.Drawing.Point(19, 26)
        Me.lblCódigo.Name = "lblCódigo"
        Me.lblCódigo.Size = New System.Drawing.Size(157, 20)
        Me.lblCódigo.TabIndex = 37
        Me.lblCódigo.Text = "Tabla"
        '
        'frm_comandos_TABLAS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 447)
        Me.Controls.Add(Me.fraCOMANDOS2)
        Me.Controls.Add(Me.fraCONSULTA)
        Me.Controls.Add(Me.fraCOMANDOS1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraTABLAS)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_comandos_TABLAS"
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
        Me.fraTABLAS.ResumeLayout(False)
        Me.fraTABLAS.PerformLayout()
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
    Friend WithEvents fraTABLAS As System.Windows.Forms.GroupBox
    Friend WithEvents rbdTABLSIST As System.Windows.Forms.RadioButton
    Friend WithEvents rbdTABLMANT As System.Windows.Forms.RadioButton
    Friend WithEvents rbdTABLPRIN As System.Windows.Forms.RadioButton
    Friend WithEvents cboTABLESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTABLDESC As System.Windows.Forms.TextBox
    Friend WithEvents txtTABLCODI As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCódigo As System.Windows.Forms.Label
End Class
