<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_LIBRRADI
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtLIRASECU = New System.Windows.Forms.Label()
        Me.fraFICHPRED = New System.Windows.Forms.GroupBox()
        Me.dtpLIRAFEAS = New System.Windows.Forms.DateTimePicker()
        Me.txtLIRAFEAS = New System.Windows.Forms.MaskedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtLIRAOFSA = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboLIRAMENO = New System.Windows.Forms.ComboBox()
        Me.lblLIRAMENO = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpLIRAFEMN = New System.Windows.Forms.DateTimePicker()
        Me.txtLIRAFEMN = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtLIRAASUN = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpLIRAFERA = New System.Windows.Forms.DateTimePicker()
        Me.txtLIRANURA = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLIRAFERA = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblLIRADIVI = New System.Windows.Forms.Label()
        Me.cboLIRADIVI = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboLIRAMERE = New System.Windows.Forms.ComboBox()
        Me.lblLIRAMERE = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLIRAOBSE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboLIRAESTA = New System.Windows.Forms.ComboBox()
        Me.cboLIRAACAD = New System.Windows.Forms.ComboBox()
        Me.lblLIRAACAD = New System.Windows.Forms.Label()
        Me.lblCategoriaDeSuelo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox2.SuspendLayout()
        Me.fraFICHPRED.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtLIRASECU)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(15, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(637, 48)
        Me.GroupBox2.TabIndex = 347
        Me.GroupBox2.TabStop = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(20, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 20)
        Me.Label8.TabIndex = 319
        Me.Label8.Text = "Secuencia"
        '
        'txtLIRASECU
        '
        Me.txtLIRASECU.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtLIRASECU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtLIRASECU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLIRASECU.ForeColor = System.Drawing.Color.Black
        Me.txtLIRASECU.Location = New System.Drawing.Point(155, 17)
        Me.txtLIRASECU.Name = "txtLIRASECU"
        Me.txtLIRASECU.Size = New System.Drawing.Size(160, 20)
        Me.txtLIRASECU.TabIndex = 312
        Me.txtLIRASECU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fraFICHPRED
        '
        Me.fraFICHPRED.BackColor = System.Drawing.SystemColors.Control
        Me.fraFICHPRED.Controls.Add(Me.dtpLIRAFEAS)
        Me.fraFICHPRED.Controls.Add(Me.txtLIRAFEAS)
        Me.fraFICHPRED.Controls.Add(Me.Label12)
        Me.fraFICHPRED.Controls.Add(Me.txtLIRAOFSA)
        Me.fraFICHPRED.Controls.Add(Me.Label6)
        Me.fraFICHPRED.Controls.Add(Me.cboLIRAMENO)
        Me.fraFICHPRED.Controls.Add(Me.lblLIRAMENO)
        Me.fraFICHPRED.Controls.Add(Me.Label10)
        Me.fraFICHPRED.Controls.Add(Me.dtpLIRAFEMN)
        Me.fraFICHPRED.Controls.Add(Me.txtLIRAFEMN)
        Me.fraFICHPRED.Controls.Add(Me.Label7)
        Me.fraFICHPRED.Controls.Add(Me.txtLIRAASUN)
        Me.fraFICHPRED.Controls.Add(Me.Label3)
        Me.fraFICHPRED.Controls.Add(Me.dtpLIRAFERA)
        Me.fraFICHPRED.Controls.Add(Me.txtLIRANURA)
        Me.fraFICHPRED.Controls.Add(Me.Label1)
        Me.fraFICHPRED.Controls.Add(Me.txtLIRAFERA)
        Me.fraFICHPRED.Controls.Add(Me.Label11)
        Me.fraFICHPRED.Controls.Add(Me.lblLIRADIVI)
        Me.fraFICHPRED.Controls.Add(Me.cboLIRADIVI)
        Me.fraFICHPRED.Controls.Add(Me.Label9)
        Me.fraFICHPRED.Controls.Add(Me.cboLIRAMERE)
        Me.fraFICHPRED.Controls.Add(Me.lblLIRAMERE)
        Me.fraFICHPRED.Controls.Add(Me.Label4)
        Me.fraFICHPRED.Controls.Add(Me.Label5)
        Me.fraFICHPRED.Controls.Add(Me.txtLIRAOBSE)
        Me.fraFICHPRED.Controls.Add(Me.Label2)
        Me.fraFICHPRED.Controls.Add(Me.cboLIRAESTA)
        Me.fraFICHPRED.Controls.Add(Me.cboLIRAACAD)
        Me.fraFICHPRED.Controls.Add(Me.lblLIRAACAD)
        Me.fraFICHPRED.Controls.Add(Me.lblCategoriaDeSuelo)
        Me.fraFICHPRED.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraFICHPRED.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraFICHPRED.Location = New System.Drawing.Point(15, 66)
        Me.fraFICHPRED.Name = "fraFICHPRED"
        Me.fraFICHPRED.Size = New System.Drawing.Size(637, 382)
        Me.fraFICHPRED.TabIndex = 344
        Me.fraFICHPRED.TabStop = False
        Me.fraFICHPRED.Text = "INSERTAR LIBRO RADICADOR"
        '
        'dtpLIRAFEAS
        '
        Me.dtpLIRAFEAS.Location = New System.Drawing.Point(318, 231)
        Me.dtpLIRAFEAS.Name = "dtpLIRAFEAS"
        Me.dtpLIRAFEAS.Size = New System.Drawing.Size(21, 21)
        Me.dtpLIRAFEAS.TabIndex = 446
        '
        'txtLIRAFEAS
        '
        Me.txtLIRAFEAS.AccessibleDescription = "Fecha de asignación"
        Me.txtLIRAFEAS.BackColor = System.Drawing.Color.White
        Me.txtLIRAFEAS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLIRAFEAS.Location = New System.Drawing.Point(155, 231)
        Me.txtLIRAFEAS.Mask = "00-00-0000"
        Me.txtLIRAFEAS.Name = "txtLIRAFEAS"
        Me.txtLIRAFEAS.Size = New System.Drawing.Size(160, 20)
        Me.txtLIRAFEAS.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(20, 232)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(132, 20)
        Me.Label12.TabIndex = 445
        Me.Label12.Text = "Fecha de asignación"
        '
        'txtLIRAOFSA
        '
        Me.txtLIRAOFSA.AccessibleDescription = "Oficio de salida"
        Me.txtLIRAOFSA.BackColor = System.Drawing.SystemColors.Window
        Me.txtLIRAOFSA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLIRAOFSA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLIRAOFSA.ForeColor = System.Drawing.Color.Black
        Me.txtLIRAOFSA.Location = New System.Drawing.Point(155, 209)
        Me.txtLIRAOFSA.MaxLength = 50
        Me.txtLIRAOFSA.Name = "txtLIRAOFSA"
        Me.txtLIRAOFSA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLIRAOFSA.Size = New System.Drawing.Size(160, 20)
        Me.txtLIRAOFSA.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(20, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 20)
        Me.Label6.TabIndex = 443
        Me.Label6.Text = "Oficio de salida"
        '
        'cboLIRAMENO
        '
        Me.cboLIRAMENO.AccessibleDescription = "Medio de notificación"
        Me.cboLIRAMENO.BackColor = System.Drawing.Color.White
        Me.cboLIRAMENO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboLIRAMENO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLIRAMENO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLIRAMENO.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboLIRAMENO.Location = New System.Drawing.Point(155, 138)
        Me.cboLIRAMENO.MaxDropDownItems = 15
        Me.cboLIRAMENO.MaxLength = 1
        Me.cboLIRAMENO.Name = "cboLIRAMENO"
        Me.cboLIRAMENO.Size = New System.Drawing.Size(340, 22)
        Me.cboLIRAMENO.TabIndex = 6
        '
        'lblLIRAMENO
        '
        Me.lblLIRAMENO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblLIRAMENO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLIRAMENO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLIRAMENO.ForeColor = System.Drawing.Color.Black
        Me.lblLIRAMENO.Location = New System.Drawing.Point(499, 140)
        Me.lblLIRAMENO.Name = "lblLIRAMENO"
        Me.lblLIRAMENO.Size = New System.Drawing.Size(121, 20)
        Me.lblLIRAMENO.TabIndex = 441
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(20, 140)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(132, 20)
        Me.Label10.TabIndex = 440
        Me.Label10.Text = "Medio de notificación"
        '
        'dtpLIRAFEMN
        '
        Me.dtpLIRAFEMN.Location = New System.Drawing.Point(318, 162)
        Me.dtpLIRAFEMN.Name = "dtpLIRAFEMN"
        Me.dtpLIRAFEMN.Size = New System.Drawing.Size(21, 21)
        Me.dtpLIRAFEMN.TabIndex = 438
        '
        'txtLIRAFEMN
        '
        Me.txtLIRAFEMN.AccessibleDescription = "Fecha de notificación"
        Me.txtLIRAFEMN.BackColor = System.Drawing.Color.White
        Me.txtLIRAFEMN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLIRAFEMN.Location = New System.Drawing.Point(155, 162)
        Me.txtLIRAFEMN.Mask = "00-00-0000"
        Me.txtLIRAFEMN.Name = "txtLIRAFEMN"
        Me.txtLIRAFEMN.Size = New System.Drawing.Size(160, 20)
        Me.txtLIRAFEMN.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(20, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(132, 20)
        Me.Label7.TabIndex = 435
        Me.Label7.Text = "Fecha de notificación"
        '
        'txtLIRAASUN
        '
        Me.txtLIRAASUN.AccessibleDescription = "Asunto"
        Me.txtLIRAASUN.BackColor = System.Drawing.SystemColors.Window
        Me.txtLIRAASUN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLIRAASUN.ForeColor = System.Drawing.Color.Black
        Me.txtLIRAASUN.Location = New System.Drawing.Point(155, 117)
        Me.txtLIRAASUN.MaxLength = 100
        Me.txtLIRAASUN.Name = "txtLIRAASUN"
        Me.txtLIRAASUN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLIRAASUN.Size = New System.Drawing.Size(465, 20)
        Me.txtLIRAASUN.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(20, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 20)
        Me.Label3.TabIndex = 432
        Me.Label3.Text = "Asunto"
        '
        'dtpLIRAFERA
        '
        Me.dtpLIRAFERA.Location = New System.Drawing.Point(318, 94)
        Me.dtpLIRAFERA.Name = "dtpLIRAFERA"
        Me.dtpLIRAFERA.Size = New System.Drawing.Size(21, 21)
        Me.dtpLIRAFERA.TabIndex = 431
        '
        'txtLIRANURA
        '
        Me.txtLIRANURA.AccessibleDescription = "Nro. Radicado"
        Me.txtLIRANURA.BackColor = System.Drawing.SystemColors.Window
        Me.txtLIRANURA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLIRANURA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLIRANURA.ForeColor = System.Drawing.Color.Black
        Me.txtLIRANURA.Location = New System.Drawing.Point(155, 72)
        Me.txtLIRANURA.MaxLength = 9
        Me.txtLIRANURA.Name = "txtLIRANURA"
        Me.txtLIRANURA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLIRANURA.Size = New System.Drawing.Size(160, 20)
        Me.txtLIRANURA.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(20, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 20)
        Me.Label1.TabIndex = 429
        Me.Label1.Text = "Nro. Radicado"
        '
        'txtLIRAFERA
        '
        Me.txtLIRAFERA.AccessibleDescription = "Fecha de radicado"
        Me.txtLIRAFERA.BackColor = System.Drawing.Color.White
        Me.txtLIRAFERA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLIRAFERA.Location = New System.Drawing.Point(155, 94)
        Me.txtLIRAFERA.Mask = "00-00-0000"
        Me.txtLIRAFERA.Name = "txtLIRAFERA"
        Me.txtLIRAFERA.Size = New System.Drawing.Size(160, 20)
        Me.txtLIRAFERA.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(20, 95)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 20)
        Me.Label11.TabIndex = 425
        Me.Label11.Text = "Fecha de radicado"
        '
        'lblLIRADIVI
        '
        Me.lblLIRADIVI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblLIRADIVI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLIRADIVI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLIRADIVI.ForeColor = System.Drawing.Color.Black
        Me.lblLIRADIVI.Location = New System.Drawing.Point(499, 186)
        Me.lblLIRADIVI.Name = "lblLIRADIVI"
        Me.lblLIRADIVI.Size = New System.Drawing.Size(121, 20)
        Me.lblLIRADIVI.TabIndex = 422
        '
        'cboLIRADIVI
        '
        Me.cboLIRADIVI.AccessibleDescription = "División"
        Me.cboLIRADIVI.BackColor = System.Drawing.Color.White
        Me.cboLIRADIVI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboLIRADIVI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLIRADIVI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLIRADIVI.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboLIRADIVI.Location = New System.Drawing.Point(155, 184)
        Me.cboLIRADIVI.MaxDropDownItems = 15
        Me.cboLIRADIVI.MaxLength = 1
        Me.cboLIRADIVI.Name = "cboLIRADIVI"
        Me.cboLIRADIVI.Size = New System.Drawing.Size(340, 22)
        Me.cboLIRADIVI.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(20, 186)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(132, 20)
        Me.Label9.TabIndex = 421
        Me.Label9.Text = "División"
        '
        'cboLIRAMERE
        '
        Me.cboLIRAMERE.AccessibleDescription = "Medio de recepción"
        Me.cboLIRAMERE.BackColor = System.Drawing.Color.White
        Me.cboLIRAMERE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboLIRAMERE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLIRAMERE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLIRAMERE.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboLIRAMERE.Location = New System.Drawing.Point(155, 47)
        Me.cboLIRAMERE.MaxDropDownItems = 15
        Me.cboLIRAMERE.MaxLength = 1
        Me.cboLIRAMERE.Name = "cboLIRAMERE"
        Me.cboLIRAMERE.Size = New System.Drawing.Size(340, 22)
        Me.cboLIRAMERE.TabIndex = 2
        '
        'lblLIRAMERE
        '
        Me.lblLIRAMERE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblLIRAMERE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLIRAMERE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLIRAMERE.ForeColor = System.Drawing.Color.Black
        Me.lblLIRAMERE.Location = New System.Drawing.Point(499, 49)
        Me.lblLIRAMERE.Name = "lblLIRAMERE"
        Me.lblLIRAMERE.Size = New System.Drawing.Size(121, 20)
        Me.lblLIRAMERE.TabIndex = 419
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(20, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 20)
        Me.Label4.TabIndex = 418
        Me.Label4.Text = "Medio de recepción"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(20, 278)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(600, 20)
        Me.Label5.TabIndex = 380
        Me.Label5.Text = "OBSERVACIONES"
        '
        'txtLIRAOBSE
        '
        Me.txtLIRAOBSE.AccessibleDescription = "Observaciones"
        Me.txtLIRAOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtLIRAOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLIRAOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtLIRAOBSE.Location = New System.Drawing.Point(20, 301)
        Me.txtLIRAOBSE.MaxLength = 4000
        Me.txtLIRAOBSE.Multiline = True
        Me.txtLIRAOBSE.Name = "txtLIRAOBSE"
        Me.txtLIRAOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLIRAOBSE.Size = New System.Drawing.Size(600, 62)
        Me.txtLIRAOBSE.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(20, 255)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 20)
        Me.Label2.TabIndex = 301
        Me.Label2.Text = "Estado"
        '
        'cboLIRAESTA
        '
        Me.cboLIRAESTA.AccessibleDescription = "Estado"
        Me.cboLIRAESTA.BackColor = System.Drawing.Color.White
        Me.cboLIRAESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboLIRAESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLIRAESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLIRAESTA.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11"})
        Me.cboLIRAESTA.Location = New System.Drawing.Point(155, 253)
        Me.cboLIRAESTA.MaxDropDownItems = 15
        Me.cboLIRAESTA.MaxLength = 2
        Me.cboLIRAESTA.Name = "cboLIRAESTA"
        Me.cboLIRAESTA.Size = New System.Drawing.Size(340, 22)
        Me.cboLIRAESTA.TabIndex = 11
        '
        'cboLIRAACAD
        '
        Me.cboLIRAACAD.AccessibleDescription = "Clasificación"
        Me.cboLIRAACAD.BackColor = System.Drawing.Color.White
        Me.cboLIRAACAD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboLIRAACAD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLIRAACAD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLIRAACAD.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboLIRAACAD.Location = New System.Drawing.Point(155, 24)
        Me.cboLIRAACAD.MaxDropDownItems = 15
        Me.cboLIRAACAD.MaxLength = 1
        Me.cboLIRAACAD.Name = "cboLIRAACAD"
        Me.cboLIRAACAD.Size = New System.Drawing.Size(340, 22)
        Me.cboLIRAACAD.TabIndex = 1
        '
        'lblLIRAACAD
        '
        Me.lblLIRAACAD.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblLIRAACAD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLIRAACAD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLIRAACAD.ForeColor = System.Drawing.Color.Black
        Me.lblLIRAACAD.Location = New System.Drawing.Point(499, 26)
        Me.lblLIRAACAD.Name = "lblLIRAACAD"
        Me.lblLIRAACAD.Size = New System.Drawing.Size(121, 20)
        Me.lblLIRAACAD.TabIndex = 51
        '
        'lblCategoriaDeSuelo
        '
        Me.lblCategoriaDeSuelo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCategoriaDeSuelo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCategoriaDeSuelo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoriaDeSuelo.ForeColor = System.Drawing.Color.Black
        Me.lblCategoriaDeSuelo.Location = New System.Drawing.Point(20, 26)
        Me.lblCategoriaDeSuelo.Name = "lblCategoriaDeSuelo"
        Me.lblCategoriaDeSuelo.Size = New System.Drawing.Size(132, 20)
        Me.lblCategoriaDeSuelo.TabIndex = 44
        Me.lblCategoriaDeSuelo.Text = "Clasificación"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 454)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(637, 46)
        Me.GroupBox1.TabIndex = 345
        Me.GroupBox1.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(321, 15)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(214, 15)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 515)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(665, 25)
        Me.strBARRESTA.TabIndex = 346
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
        'frm_insertar_LIBRRADI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 540)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.fraFICHPRED)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(681, 576)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(681, 576)
        Me.Name = "frm_insertar_LIBRRADI"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox2.ResumeLayout(False)
        Me.fraFICHPRED.ResumeLayout(False)
        Me.fraFICHPRED.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtLIRASECU As System.Windows.Forms.Label
    Friend WithEvents fraFICHPRED As System.Windows.Forms.GroupBox
    Friend WithEvents txtLIRAFERA As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblLIRADIVI As System.Windows.Forms.Label
    Friend WithEvents cboLIRADIVI As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboLIRAMERE As System.Windows.Forms.ComboBox
    Friend WithEvents lblLIRAMERE As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLIRAOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboLIRAESTA As System.Windows.Forms.ComboBox
    Friend WithEvents cboLIRAACAD As System.Windows.Forms.ComboBox
    Friend WithEvents lblLIRAACAD As System.Windows.Forms.Label
    Friend WithEvents lblCategoriaDeSuelo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtLIRANURA As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpLIRAFERA As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtLIRAASUN As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboLIRAMENO As System.Windows.Forms.ComboBox
    Friend WithEvents lblLIRAMENO As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpLIRAFEMN As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtLIRAFEMN As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLIRAOFSA As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpLIRAFEAS As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtLIRAFEAS As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
