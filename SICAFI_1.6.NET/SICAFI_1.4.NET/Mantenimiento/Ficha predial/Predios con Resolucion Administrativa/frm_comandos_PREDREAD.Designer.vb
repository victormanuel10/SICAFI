<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_comandos_PREDREAD
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
        Me.fraPREDREAD = New System.Windows.Forms.GroupBox()
        Me.cboPRRAESTA = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPRRAOBSE = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPRRAARTE = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblPRRAVIGE = New System.Windows.Forms.Label()
        Me.cboPRRAVIGE = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblPRRACLSE = New System.Windows.Forms.Label()
        Me.cboPRRACLSE = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPRRARESO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPRRATITR = New System.Windows.Forms.Label()
        Me.cboPRRATITR = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPRRANUFI = New System.Windows.Forms.TextBox()
        Me.lblCódigo = New System.Windows.Forms.Label()
        Me.fraCOMANDOS2.SuspendLayout()
        Me.fraCONSULTA.SuspendLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraCOMANDOS1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraPREDREAD.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraCOMANDOS2
        '
        Me.fraCOMANDOS2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fraCOMANDOS2.Controls.Add(Me.cmdLIMPIAR)
        Me.fraCOMANDOS2.Controls.Add(Me.cmdACEPTAR)
        Me.fraCOMANDOS2.Controls.Add(Me.cmdCONSULTAR)
        Me.fraCOMANDOS2.Location = New System.Drawing.Point(12, 516)
        Me.fraCOMANDOS2.Name = "fraCOMANDOS2"
        Me.fraCOMANDOS2.Size = New System.Drawing.Size(593, 60)
        Me.fraCOMANDOS2.TabIndex = 74
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
        Me.cmdACEPTAR.Location = New System.Drawing.Point(472, 20)
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
        Me.cmdCONSULTAR.Location = New System.Drawing.Point(365, 20)
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
        Me.fraCONSULTA.Location = New System.Drawing.Point(12, 306)
        Me.fraCONSULTA.Name = "fraCONSULTA"
        Me.fraCONSULTA.Size = New System.Drawing.Size(593, 204)
        Me.fraCONSULTA.TabIndex = 73
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
        Me.dgvCONSULTA.ColumnHeadersHeight = 40
        Me.dgvCONSULTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCONSULTA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA.Location = New System.Drawing.Point(19, 19)
        Me.dgvCONSULTA.MultiSelect = False
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        Me.dgvCONSULTA.RowHeadersVisible = False
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(554, 168)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 5
        '
        'fraCOMANDOS1
        '
        Me.fraCOMANDOS1.Controls.Add(Me.cmdSALIR)
        Me.fraCOMANDOS1.Controls.Add(Me.cmdGUARDAR)
        Me.fraCOMANDOS1.Location = New System.Drawing.Point(12, 246)
        Me.fraCOMANDOS1.Name = "fraCOMANDOS1"
        Me.fraCOMANDOS1.Size = New System.Drawing.Size(593, 54)
        Me.fraCOMANDOS1.TabIndex = 72
        Me.fraCOMANDOS1.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(471, 19)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(364, 19)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 590)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(626, 25)
        Me.strBARRESTA.TabIndex = 71
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
        'fraPREDREAD
        '
        Me.fraPREDREAD.BackColor = System.Drawing.SystemColors.Control
        Me.fraPREDREAD.Controls.Add(Me.cboPRRAESTA)
        Me.fraPREDREAD.Controls.Add(Me.Label9)
        Me.fraPREDREAD.Controls.Add(Me.txtPRRAOBSE)
        Me.fraPREDREAD.Controls.Add(Me.Label8)
        Me.fraPREDREAD.Controls.Add(Me.txtPRRAARTE)
        Me.fraPREDREAD.Controls.Add(Me.Label7)
        Me.fraPREDREAD.Controls.Add(Me.lblPRRAVIGE)
        Me.fraPREDREAD.Controls.Add(Me.cboPRRAVIGE)
        Me.fraPREDREAD.Controls.Add(Me.Label6)
        Me.fraPREDREAD.Controls.Add(Me.lblPRRACLSE)
        Me.fraPREDREAD.Controls.Add(Me.cboPRRACLSE)
        Me.fraPREDREAD.Controls.Add(Me.Label5)
        Me.fraPREDREAD.Controls.Add(Me.txtPRRARESO)
        Me.fraPREDREAD.Controls.Add(Me.Label3)
        Me.fraPREDREAD.Controls.Add(Me.lblPRRATITR)
        Me.fraPREDREAD.Controls.Add(Me.cboPRRATITR)
        Me.fraPREDREAD.Controls.Add(Me.Label2)
        Me.fraPREDREAD.Controls.Add(Me.txtPRRANUFI)
        Me.fraPREDREAD.Controls.Add(Me.lblCódigo)
        Me.fraPREDREAD.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPREDREAD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPREDREAD.Location = New System.Drawing.Point(12, 12)
        Me.fraPREDREAD.Name = "fraPREDREAD"
        Me.fraPREDREAD.Size = New System.Drawing.Size(593, 228)
        Me.fraPREDREAD.TabIndex = 70
        Me.fraPREDREAD.TabStop = False
        '
        'cboPRRAESTA
        '
        Me.cboPRRAESTA.AccessibleDescription = "Estado"
        Me.cboPRRAESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPRRAESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPRRAESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPRRAESTA.FormattingEnabled = True
        Me.cboPRRAESTA.Location = New System.Drawing.Point(142, 189)
        Me.cboPRRAESTA.Name = "cboPRRAESTA"
        Me.cboPRRAESTA.Size = New System.Drawing.Size(153, 22)
        Me.cboPRRAESTA.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(19, 191)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 20)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "Estado"
        '
        'txtPRRAOBSE
        '
        Me.txtPRRAOBSE.AccessibleDescription = "Observación"
        Me.txtPRRAOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtPRRAOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRRAOBSE.Location = New System.Drawing.Point(142, 168)
        Me.txtPRRAOBSE.MaxLength = 100
        Me.txtPRRAOBSE.Name = "txtPRRAOBSE"
        Me.txtPRRAOBSE.Size = New System.Drawing.Size(430, 20)
        Me.txtPRRAOBSE.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(19, 168)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 20)
        Me.Label8.TabIndex = 67
        Me.Label8.Text = "Observación"
        '
        'txtPRRAARTE
        '
        Me.txtPRRAARTE.AccessibleDescription = "Área de terreno mts2"
        Me.txtPRRAARTE.BackColor = System.Drawing.SystemColors.Window
        Me.txtPRRAARTE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRRAARTE.Location = New System.Drawing.Point(142, 145)
        Me.txtPRRAARTE.MaxLength = 9
        Me.txtPRRAARTE.Name = "txtPRRAARTE"
        Me.txtPRRAARTE.Size = New System.Drawing.Size(153, 20)
        Me.txtPRRAARTE.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(19, 145)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 20)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "Área de terreno mts2"
        '
        'lblPRRAVIGE
        '
        Me.lblPRRAVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPRRAVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPRRAVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPRRAVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblPRRAVIGE.Location = New System.Drawing.Point(463, 122)
        Me.lblPRRAVIGE.Name = "lblPRRAVIGE"
        Me.lblPRRAVIGE.Size = New System.Drawing.Size(109, 20)
        Me.lblPRRAVIGE.TabIndex = 63
        '
        'cboPRRAVIGE
        '
        Me.cboPRRAVIGE.AccessibleDescription = "Vigencia"
        Me.cboPRRAVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPRRAVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPRRAVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPRRAVIGE.FormattingEnabled = True
        Me.cboPRRAVIGE.Location = New System.Drawing.Point(142, 120)
        Me.cboPRRAVIGE.Name = "cboPRRAVIGE"
        Me.cboPRRAVIGE.Size = New System.Drawing.Size(315, 22)
        Me.cboPRRAVIGE.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(19, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 20)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "Vigencia"
        '
        'lblPRRACLSE
        '
        Me.lblPRRACLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPRRACLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPRRACLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPRRACLSE.ForeColor = System.Drawing.Color.Black
        Me.lblPRRACLSE.Location = New System.Drawing.Point(463, 99)
        Me.lblPRRACLSE.Name = "lblPRRACLSE"
        Me.lblPRRACLSE.Size = New System.Drawing.Size(109, 20)
        Me.lblPRRACLSE.TabIndex = 60
        '
        'cboPRRACLSE
        '
        Me.cboPRRACLSE.AccessibleDescription = "Clase o sector"
        Me.cboPRRACLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPRRACLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPRRACLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPRRACLSE.FormattingEnabled = True
        Me.cboPRRACLSE.Location = New System.Drawing.Point(142, 97)
        Me.cboPRRACLSE.Name = "cboPRRACLSE"
        Me.cboPRRACLSE.Size = New System.Drawing.Size(315, 22)
        Me.cboPRRACLSE.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 20)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Clase / sector"
        '
        'txtPRRARESO
        '
        Me.txtPRRARESO.AccessibleDescription = "Resolución"
        Me.txtPRRARESO.BackColor = System.Drawing.SystemColors.Window
        Me.txtPRRARESO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRRARESO.Location = New System.Drawing.Point(142, 76)
        Me.txtPRRARESO.MaxLength = 9
        Me.txtPRRARESO.Name = "txtPRRARESO"
        Me.txtPRRARESO.Size = New System.Drawing.Size(153, 20)
        Me.txtPRRARESO.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 20)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Nro. de resolución"
        '
        'lblPRRATITR
        '
        Me.lblPRRATITR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPRRATITR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPRRATITR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPRRATITR.ForeColor = System.Drawing.Color.Black
        Me.lblPRRATITR.Location = New System.Drawing.Point(463, 30)
        Me.lblPRRATITR.Name = "lblPRRATITR"
        Me.lblPRRATITR.Size = New System.Drawing.Size(109, 20)
        Me.lblPRRATITR.TabIndex = 55
        '
        'cboPRRATITR
        '
        Me.cboPRRATITR.AccessibleDescription = "Tipo de tramite"
        Me.cboPRRATITR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPRRATITR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPRRATITR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPRRATITR.FormattingEnabled = True
        Me.cboPRRATITR.Location = New System.Drawing.Point(142, 28)
        Me.cboPRRATITR.Name = "cboPRRATITR"
        Me.cboPRRATITR.Size = New System.Drawing.Size(315, 22)
        Me.cboPRRATITR.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Tipo de tramite"
        '
        'txtPRRANUFI
        '
        Me.txtPRRANUFI.AccessibleDescription = "Nro. de ficha"
        Me.txtPRRANUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtPRRANUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRRANUFI.Location = New System.Drawing.Point(142, 53)
        Me.txtPRRANUFI.MaxLength = 9
        Me.txtPRRANUFI.Name = "txtPRRANUFI"
        Me.txtPRRANUFI.Size = New System.Drawing.Size(153, 20)
        Me.txtPRRANUFI.TabIndex = 2
        '
        'lblCódigo
        '
        Me.lblCódigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCódigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCódigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCódigo.ForeColor = System.Drawing.Color.Black
        Me.lblCódigo.Location = New System.Drawing.Point(19, 53)
        Me.lblCódigo.Name = "lblCódigo"
        Me.lblCódigo.Size = New System.Drawing.Size(120, 20)
        Me.lblCódigo.TabIndex = 37
        Me.lblCódigo.Text = "Nro. de ficha"
        '
        'frm_comandos_PREDREAD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 615)
        Me.Controls.Add(Me.fraCOMANDOS2)
        Me.Controls.Add(Me.fraCONSULTA)
        Me.Controls.Add(Me.fraCOMANDOS1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraPREDREAD)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_comandos_PREDREAD"
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
        Me.fraPREDREAD.ResumeLayout(False)
        Me.fraPREDREAD.PerformLayout()
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
    Friend WithEvents fraPREDREAD As System.Windows.Forms.GroupBox
    Friend WithEvents cboPRRATITR As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPRRANUFI As System.Windows.Forms.TextBox
    Friend WithEvents lblCódigo As System.Windows.Forms.Label
    Friend WithEvents cboPRRAESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPRRAOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPRRAARTE As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblPRRAVIGE As System.Windows.Forms.Label
    Friend WithEvents cboPRRAVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblPRRACLSE As System.Windows.Forms.Label
    Friend WithEvents cboPRRACLSE As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPRRARESO As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPRRATITR As System.Windows.Forms.Label
End Class
