<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_funcionario_TRABCAMP
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboTRCAVIGE = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTRCANUDO = New System.Windows.Forms.ComboBox()
        Me.cboTRCAESTA = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbdARCHIVO = New System.Windows.Forms.RadioButton()
        Me.rbdLIQUIDACION = New System.Windows.Forms.RadioButton()
        Me.rbdDIGITACION = New System.Windows.Forms.RadioButton()
        Me.rbdLEVANTAMIENTO = New System.Windows.Forms.RadioButton()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtTOTAL = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTRCAPREL = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTRCAPRMO = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTRCAPRNU = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dgvCONSULTA = New System.Windows.Forms.DataGridView()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdLimpiar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdConsultar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboTRCAVIGE)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboTRCANUDO)
        Me.GroupBox1.Controls.Add(Me.cboTRCAESTA)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(975, 58)
        Me.GroupBox1.TabIndex = 339
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PARAMETROS"
        '
        'cboTRCAVIGE
        '
        Me.cboTRCAVIGE.AccessibleDescription = "Vigencia"
        Me.cboTRCAVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTRCAVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTRCAVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTRCAVIGE.FormattingEnabled = True
        Me.cboTRCAVIGE.Location = New System.Drawing.Point(566, 22)
        Me.cboTRCAVIGE.Name = "cboTRCAVIGE"
        Me.cboTRCAVIGE.Size = New System.Drawing.Size(172, 22)
        Me.cboTRCAVIGE.TabIndex = 342
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(478, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 343
        Me.Label3.Text = "Vigencia"
        '
        'cboTRCANUDO
        '
        Me.cboTRCANUDO.AccessibleDescription = "Trabajo de campo"
        Me.cboTRCANUDO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTRCANUDO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTRCANUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTRCANUDO.FormattingEnabled = True
        Me.cboTRCANUDO.Location = New System.Drawing.Point(150, 23)
        Me.cboTRCANUDO.Name = "cboTRCANUDO"
        Me.cboTRCANUDO.Size = New System.Drawing.Size(322, 22)
        Me.cboTRCANUDO.TabIndex = 341
        '
        'cboTRCAESTA
        '
        Me.cboTRCAESTA.AccessibleDescription = "Estado"
        Me.cboTRCAESTA.BackColor = System.Drawing.Color.White
        Me.cboTRCAESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTRCAESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTRCAESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTRCAESTA.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11"})
        Me.cboTRCAESTA.Location = New System.Drawing.Point(840, 21)
        Me.cboTRCAESTA.MaxDropDownItems = 15
        Me.cboTRCAESTA.MaxLength = 2
        Me.cboTRCAESTA.Name = "cboTRCAESTA"
        Me.cboTRCAESTA.Size = New System.Drawing.Size(120, 22)
        Me.cboTRCAESTA.TabIndex = 340
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(744, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 20)
        Me.Label2.TabIndex = 339
        Me.Label2.Text = "Estado"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 20)
        Me.Label1.TabIndex = 319
        Me.Label1.Text = "Funcionario"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbdARCHIVO)
        Me.GroupBox3.Controls.Add(Me.rbdLIQUIDACION)
        Me.GroupBox3.Controls.Add(Me.rbdDIGITACION)
        Me.GroupBox3.Controls.Add(Me.rbdLEVANTAMIENTO)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(12, 76)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(975, 58)
        Me.GroupBox3.TabIndex = 340
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "TIPO DE CONSULTA"
        '
        'rbdARCHIVO
        '
        Me.rbdARCHIVO.AutoSize = True
        Me.rbdARCHIVO.Location = New System.Drawing.Point(295, 23)
        Me.rbdARCHIVO.Name = "rbdARCHIVO"
        Me.rbdARCHIVO.Size = New System.Drawing.Size(61, 17)
        Me.rbdARCHIVO.TabIndex = 3
        Me.rbdARCHIVO.Text = "Archivo"
        Me.rbdARCHIVO.UseVisualStyleBackColor = True
        '
        'rbdLIQUIDACION
        '
        Me.rbdLIQUIDACION.AutoSize = True
        Me.rbdLIQUIDACION.Location = New System.Drawing.Point(202, 22)
        Me.rbdLIQUIDACION.Name = "rbdLIQUIDACION"
        Me.rbdLIQUIDACION.Size = New System.Drawing.Size(79, 17)
        Me.rbdLIQUIDACION.TabIndex = 2
        Me.rbdLIQUIDACION.Text = "Liquidación"
        Me.rbdLIQUIDACION.UseVisualStyleBackColor = True
        '
        'rbdDIGITACION
        '
        Me.rbdDIGITACION.AutoSize = True
        Me.rbdDIGITACION.Location = New System.Drawing.Point(119, 22)
        Me.rbdDIGITACION.Name = "rbdDIGITACION"
        Me.rbdDIGITACION.Size = New System.Drawing.Size(72, 17)
        Me.rbdDIGITACION.TabIndex = 1
        Me.rbdDIGITACION.Text = "Digitación"
        Me.rbdDIGITACION.UseVisualStyleBackColor = True
        '
        'rbdLEVANTAMIENTO
        '
        Me.rbdLEVANTAMIENTO.AutoSize = True
        Me.rbdLEVANTAMIENTO.Checked = True
        Me.rbdLEVANTAMIENTO.Location = New System.Drawing.Point(18, 22)
        Me.rbdLEVANTAMIENTO.Name = "rbdLEVANTAMIENTO"
        Me.rbdLEVANTAMIENTO.Size = New System.Drawing.Size(95, 17)
        Me.rbdLEVANTAMIENTO.TabIndex = 0
        Me.rbdLEVANTAMIENTO.TabStop = True
        Me.rbdLEVANTAMIENTO.Text = "Levantamiento"
        Me.rbdLEVANTAMIENTO.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 472)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(1004, 25)
        Me.strBARRESTA.TabIndex = 341
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
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.txtTOTAL)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.txtTRCAPREL)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.txtTRCAPRMO)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.txtTRCAPRNU)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.dgvCONSULTA)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(12, 140)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(975, 254)
        Me.GroupBox4.TabIndex = 342
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "CONSULTA"
        '
        'txtTOTAL
        '
        Me.txtTOTAL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTOTAL.BackColor = System.Drawing.Color.White
        Me.txtTOTAL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtTOTAL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTOTAL.ForeColor = System.Drawing.Color.Black
        Me.txtTOTAL.Location = New System.Drawing.Point(840, 219)
        Me.txtTOTAL.Name = "txtTOTAL"
        Me.txtTOTAL.Size = New System.Drawing.Size(120, 20)
        Me.txtTOTAL.TabIndex = 357
        Me.txtTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(708, 219)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 20)
        Me.Label4.TabIndex = 358
        Me.Label4.Text = "Total predios"
        '
        'txtTRCAPREL
        '
        Me.txtTRCAPREL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTRCAPREL.BackColor = System.Drawing.Color.White
        Me.txtTRCAPREL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtTRCAPREL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAPREL.ForeColor = System.Drawing.Color.Black
        Me.txtTRCAPREL.Location = New System.Drawing.Point(651, 219)
        Me.txtTRCAPREL.Name = "txtTRCAPREL"
        Me.txtTRCAPREL.Size = New System.Drawing.Size(53, 20)
        Me.txtTRCAPREL.TabIndex = 355
        Me.txtTRCAPREL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(478, 219)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(170, 20)
        Me.Label17.TabIndex = 356
        Me.Label17.Text = "Nro. predios eliminados"
        '
        'txtTRCAPRMO
        '
        Me.txtTRCAPRMO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTRCAPRMO.BackColor = System.Drawing.Color.White
        Me.txtTRCAPRMO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtTRCAPRMO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAPRMO.ForeColor = System.Drawing.Color.Black
        Me.txtTRCAPRMO.Location = New System.Drawing.Point(421, 219)
        Me.txtTRCAPRMO.Name = "txtTRCAPRMO"
        Me.txtTRCAPRMO.Size = New System.Drawing.Size(53, 20)
        Me.txtTRCAPRMO.TabIndex = 353
        Me.txtTRCAPRMO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(248, 219)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(170, 20)
        Me.Label14.TabIndex = 354
        Me.Label14.Text = "Nro. predios modificados"
        '
        'txtTRCAPRNU
        '
        Me.txtTRCAPRNU.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTRCAPRNU.BackColor = System.Drawing.Color.White
        Me.txtTRCAPRNU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtTRCAPRNU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRCAPRNU.ForeColor = System.Drawing.Color.Black
        Me.txtTRCAPRNU.Location = New System.Drawing.Point(191, 219)
        Me.txtTRCAPRNU.Name = "txtTRCAPRNU"
        Me.txtTRCAPRNU.Size = New System.Drawing.Size(53, 20)
        Me.txtTRCAPRNU.TabIndex = 351
        Me.txtTRCAPRNU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(18, 219)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(170, 20)
        Me.Label10.TabIndex = 352
        Me.Label10.Text = "Nro. predios nuevos"
        '
        'dgvCONSULTA
        '
        Me.dgvCONSULTA.AccessibleDescription = ""
        Me.dgvCONSULTA.AllowUserToAddRows = False
        Me.dgvCONSULTA.AllowUserToDeleteRows = False
        Me.dgvCONSULTA.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
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
        Me.dgvCONSULTA.Location = New System.Drawing.Point(18, 19)
        Me.dgvCONSULTA.MultiSelect = False
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        Me.dgvCONSULTA.RowHeadersVisible = False
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(942, 187)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 41
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.cmdSalir)
        Me.GroupBox5.Controls.Add(Me.cmdLimpiar)
        Me.GroupBox5.Controls.Add(Me.cmdAceptar)
        Me.GroupBox5.Controls.Add(Me.cmdConsultar)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 400)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(975, 60)
        Me.GroupBox5.TabIndex = 343
        Me.GroupBox5.TabStop = False
        '
        'cmdSalir
        '
        Me.cmdSalir.AccessibleDescription = "Salir"
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(859, 20)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(101, 23)
        Me.cmdSalir.TabIndex = 4
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdLimpiar
        '
        Me.cmdLimpiar.AccessibleDescription = "Limpiar"
        Me.cmdLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLimpiar.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLimpiar.Location = New System.Drawing.Point(19, 20)
        Me.cmdLimpiar.Name = "cmdLimpiar"
        Me.cmdLimpiar.Size = New System.Drawing.Size(101, 23)
        Me.cmdLimpiar.TabIndex = 1
        Me.cmdLimpiar.Text = "&Limpiar"
        Me.cmdLimpiar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.AccessibleDescription = "Aceptar"
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Enabled = False
        Me.cmdAceptar.Image = Global.SICAFI.My.Resources.Resources._22
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(752, 20)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(101, 23)
        Me.cmdAceptar.TabIndex = 3
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdConsultar
        '
        Me.cmdConsultar.AccessibleDescription = "Consultar"
        Me.cmdConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdConsultar.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdConsultar.Location = New System.Drawing.Point(645, 20)
        Me.cmdConsultar.Name = "cmdConsultar"
        Me.cmdConsultar.Size = New System.Drawing.Size(101, 23)
        Me.cmdConsultar.TabIndex = 2
        Me.cmdConsultar.Text = "&Consultar"
        Me.cmdConsultar.UseVisualStyleBackColor = True
        '
        'frm_consultar_funcionario_TRABCAMP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1004, 497)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frm_consultar_funcionario_TRABCAMP"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONSULTA TRABAJO DE CAMPO"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdARCHIVO As System.Windows.Forms.RadioButton
    Friend WithEvents rbdLIQUIDACION As System.Windows.Forms.RadioButton
    Friend WithEvents rbdDIGITACION As System.Windows.Forms.RadioButton
    Friend WithEvents rbdLEVANTAMIENTO As System.Windows.Forms.RadioButton
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents cmdLimpiar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdConsultar As System.Windows.Forms.Button
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTRCAESTA As System.Windows.Forms.ComboBox
    Friend WithEvents cboTRCANUDO As System.Windows.Forms.ComboBox
    Friend WithEvents txtTOTAL As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTRCAPREL As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTRCAPRMO As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTRCAPRNU As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboTRCAVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
