<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_FACTPROY
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraCLASSUEL = New System.Windows.Forms.GroupBox()
        Me.chkFAPRAPRA = New System.Windows.Forms.CheckBox()
        Me.lblFAPRVARI = New System.Windows.Forms.Label()
        Me.cboFAPRVARI = New System.Windows.Forms.ComboBox()
        Me.lblFAPRCLSE = New System.Windows.Forms.Label()
        Me.cboFAPRCLSE = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblFAPRDEPA = New System.Windows.Forms.Label()
        Me.cboFAPRDEPA = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblFAPRMUNI = New System.Windows.Forms.Label()
        Me.cboFAPRMUNI = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblFAPRPROY = New System.Windows.Forms.Label()
        Me.cboFAPRPROY = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFAPRFAAP = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFAPRFAFI = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFAPRFAIN = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFAPRTIVA = New System.Windows.Forms.Label()
        Me.cboFAPRTIVA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboFAPRESTA = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFAPRDESC = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCódigo = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraCLASSUEL.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 311)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(589, 53)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(283, 19)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(176, 19)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 4
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 384)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(619, 25)
        Me.strBARRESTA.TabIndex = 32
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
        'fraCLASSUEL
        '
        Me.fraCLASSUEL.BackColor = System.Drawing.SystemColors.Control
        Me.fraCLASSUEL.Controls.Add(Me.chkFAPRAPRA)
        Me.fraCLASSUEL.Controls.Add(Me.lblFAPRVARI)
        Me.fraCLASSUEL.Controls.Add(Me.cboFAPRVARI)
        Me.fraCLASSUEL.Controls.Add(Me.lblFAPRCLSE)
        Me.fraCLASSUEL.Controls.Add(Me.cboFAPRCLSE)
        Me.fraCLASSUEL.Controls.Add(Me.Label13)
        Me.fraCLASSUEL.Controls.Add(Me.lblFAPRDEPA)
        Me.fraCLASSUEL.Controls.Add(Me.cboFAPRDEPA)
        Me.fraCLASSUEL.Controls.Add(Me.Label9)
        Me.fraCLASSUEL.Controls.Add(Me.lblFAPRMUNI)
        Me.fraCLASSUEL.Controls.Add(Me.cboFAPRMUNI)
        Me.fraCLASSUEL.Controls.Add(Me.Label11)
        Me.fraCLASSUEL.Controls.Add(Me.lblFAPRPROY)
        Me.fraCLASSUEL.Controls.Add(Me.cboFAPRPROY)
        Me.fraCLASSUEL.Controls.Add(Me.Label8)
        Me.fraCLASSUEL.Controls.Add(Me.txtFAPRFAAP)
        Me.fraCLASSUEL.Controls.Add(Me.Label6)
        Me.fraCLASSUEL.Controls.Add(Me.txtFAPRFAFI)
        Me.fraCLASSUEL.Controls.Add(Me.Label5)
        Me.fraCLASSUEL.Controls.Add(Me.txtFAPRFAIN)
        Me.fraCLASSUEL.Controls.Add(Me.Label3)
        Me.fraCLASSUEL.Controls.Add(Me.lblFAPRTIVA)
        Me.fraCLASSUEL.Controls.Add(Me.cboFAPRTIVA)
        Me.fraCLASSUEL.Controls.Add(Me.Label4)
        Me.fraCLASSUEL.Controls.Add(Me.cboFAPRESTA)
        Me.fraCLASSUEL.Controls.Add(Me.Label2)
        Me.fraCLASSUEL.Controls.Add(Me.txtFAPRDESC)
        Me.fraCLASSUEL.Controls.Add(Me.Label1)
        Me.fraCLASSUEL.Controls.Add(Me.lblCódigo)
        Me.fraCLASSUEL.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraCLASSUEL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraCLASSUEL.Location = New System.Drawing.Point(12, 6)
        Me.fraCLASSUEL.Name = "fraCLASSUEL"
        Me.fraCLASSUEL.Size = New System.Drawing.Size(589, 299)
        Me.fraCLASSUEL.TabIndex = 31
        Me.fraCLASSUEL.TabStop = False
        Me.fraCLASSUEL.Text = "MODIFICAR FACTORES POR PROYECTO"
        '
        'chkFAPRAPRA
        '
        Me.chkFAPRAPRA.AutoSize = True
        Me.chkFAPRAPRA.Location = New System.Drawing.Point(449, 257)
        Me.chkFAPRAPRA.Name = "chkFAPRAPRA"
        Me.chkFAPRAPRA.Size = New System.Drawing.Size(98, 19)
        Me.chkFAPRAPRA.TabIndex = 85
        Me.chkFAPRAPRA.Text = "Aplicar rango"
        Me.chkFAPRAPRA.UseVisualStyleBackColor = True
        '
        'lblFAPRVARI
        '
        Me.lblFAPRVARI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFAPRVARI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFAPRVARI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFAPRVARI.ForeColor = System.Drawing.Color.Black
        Me.lblFAPRVARI.Location = New System.Drawing.Point(449, 141)
        Me.lblFAPRVARI.Name = "lblFAPRVARI"
        Me.lblFAPRVARI.Size = New System.Drawing.Size(124, 20)
        Me.lblFAPRVARI.TabIndex = 84
        '
        'cboFAPRVARI
        '
        Me.cboFAPRVARI.AccessibleDescription = "Variable"
        Me.cboFAPRVARI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFAPRVARI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFAPRVARI.Enabled = False
        Me.cboFAPRVARI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFAPRVARI.FormattingEnabled = True
        Me.cboFAPRVARI.Location = New System.Drawing.Point(152, 139)
        Me.cboFAPRVARI.Name = "cboFAPRVARI"
        Me.cboFAPRVARI.Size = New System.Drawing.Size(291, 22)
        Me.cboFAPRVARI.TabIndex = 83
        '
        'lblFAPRCLSE
        '
        Me.lblFAPRCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFAPRCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFAPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFAPRCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblFAPRCLSE.Location = New System.Drawing.Point(449, 72)
        Me.lblFAPRCLSE.Name = "lblFAPRCLSE"
        Me.lblFAPRCLSE.Size = New System.Drawing.Size(124, 20)
        Me.lblFAPRCLSE.TabIndex = 82
        '
        'cboFAPRCLSE
        '
        Me.cboFAPRCLSE.AccessibleDescription = "Clase o sector"
        Me.cboFAPRCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFAPRCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFAPRCLSE.Enabled = False
        Me.cboFAPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFAPRCLSE.FormattingEnabled = True
        Me.cboFAPRCLSE.Location = New System.Drawing.Point(152, 70)
        Me.cboFAPRCLSE.Name = "cboFAPRCLSE"
        Me.cboFAPRCLSE.Size = New System.Drawing.Size(291, 22)
        Me.cboFAPRCLSE.TabIndex = 80
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(18, 72)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(130, 20)
        Me.Label13.TabIndex = 81
        Me.Label13.Text = "Clase o sector"
        '
        'lblFAPRDEPA
        '
        Me.lblFAPRDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFAPRDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFAPRDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFAPRDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblFAPRDEPA.Location = New System.Drawing.Point(449, 25)
        Me.lblFAPRDEPA.Name = "lblFAPRDEPA"
        Me.lblFAPRDEPA.Size = New System.Drawing.Size(124, 20)
        Me.lblFAPRDEPA.TabIndex = 79
        '
        'cboFAPRDEPA
        '
        Me.cboFAPRDEPA.AccessibleDescription = "Departamento"
        Me.cboFAPRDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFAPRDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFAPRDEPA.Enabled = False
        Me.cboFAPRDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFAPRDEPA.FormattingEnabled = True
        Me.cboFAPRDEPA.Location = New System.Drawing.Point(152, 23)
        Me.cboFAPRDEPA.Name = "cboFAPRDEPA"
        Me.cboFAPRDEPA.Size = New System.Drawing.Size(291, 22)
        Me.cboFAPRDEPA.TabIndex = 74
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(18, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(130, 20)
        Me.Label9.TabIndex = 78
        Me.Label9.Text = "Departamento"
        '
        'lblFAPRMUNI
        '
        Me.lblFAPRMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFAPRMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFAPRMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFAPRMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblFAPRMUNI.Location = New System.Drawing.Point(449, 49)
        Me.lblFAPRMUNI.Name = "lblFAPRMUNI"
        Me.lblFAPRMUNI.Size = New System.Drawing.Size(124, 20)
        Me.lblFAPRMUNI.TabIndex = 77
        '
        'cboFAPRMUNI
        '
        Me.cboFAPRMUNI.AccessibleDescription = "Municipio"
        Me.cboFAPRMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFAPRMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFAPRMUNI.Enabled = False
        Me.cboFAPRMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFAPRMUNI.FormattingEnabled = True
        Me.cboFAPRMUNI.Location = New System.Drawing.Point(152, 47)
        Me.cboFAPRMUNI.Name = "cboFAPRMUNI"
        Me.cboFAPRMUNI.Size = New System.Drawing.Size(291, 22)
        Me.cboFAPRMUNI.TabIndex = 75
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(18, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(130, 20)
        Me.Label11.TabIndex = 76
        Me.Label11.Text = "Municipio"
        '
        'lblFAPRPROY
        '
        Me.lblFAPRPROY.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFAPRPROY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFAPRPROY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFAPRPROY.ForeColor = System.Drawing.Color.Black
        Me.lblFAPRPROY.Location = New System.Drawing.Point(449, 95)
        Me.lblFAPRPROY.Name = "lblFAPRPROY"
        Me.lblFAPRPROY.Size = New System.Drawing.Size(124, 20)
        Me.lblFAPRPROY.TabIndex = 70
        '
        'cboFAPRPROY
        '
        Me.cboFAPRPROY.AccessibleDescription = "Tipo de variable"
        Me.cboFAPRPROY.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFAPRPROY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFAPRPROY.Enabled = False
        Me.cboFAPRPROY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFAPRPROY.FormattingEnabled = True
        Me.cboFAPRPROY.Location = New System.Drawing.Point(152, 93)
        Me.cboFAPRPROY.Name = "cboFAPRPROY"
        Me.cboFAPRPROY.Size = New System.Drawing.Size(291, 22)
        Me.cboFAPRPROY.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(18, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 20)
        Me.Label8.TabIndex = 69
        Me.Label8.Text = "Proyecto"
        '
        'txtFAPRFAAP
        '
        Me.txtFAPRFAAP.AccessibleDescription = "Factor aplicado"
        Me.txtFAPRFAAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtFAPRFAAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFAPRFAAP.Location = New System.Drawing.Point(152, 233)
        Me.txtFAPRFAAP.MaxLength = 6
        Me.txtFAPRFAAP.Name = "txtFAPRFAAP"
        Me.txtFAPRFAAP.Size = New System.Drawing.Size(130, 20)
        Me.txtFAPRFAAP.TabIndex = 7
        Me.txtFAPRFAAP.Text = "0.0000"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(18, 233)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 20)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "Factor aplicado"
        '
        'txtFAPRFAFI
        '
        Me.txtFAPRFAFI.AccessibleDescription = "Factor final"
        Me.txtFAPRFAFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtFAPRFAFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFAPRFAFI.Location = New System.Drawing.Point(152, 210)
        Me.txtFAPRFAFI.MaxLength = 6
        Me.txtFAPRFAFI.Name = "txtFAPRFAFI"
        Me.txtFAPRFAFI.Size = New System.Drawing.Size(130, 20)
        Me.txtFAPRFAFI.TabIndex = 6
        Me.txtFAPRFAFI.Text = "0.0000"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(18, 210)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 20)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "Factor final"
        '
        'txtFAPRFAIN
        '
        Me.txtFAPRFAIN.AccessibleDescription = "Factor inicial"
        Me.txtFAPRFAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtFAPRFAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFAPRFAIN.Location = New System.Drawing.Point(152, 187)
        Me.txtFAPRFAIN.MaxLength = 6
        Me.txtFAPRFAIN.Name = "txtFAPRFAIN"
        Me.txtFAPRFAIN.Size = New System.Drawing.Size(130, 20)
        Me.txtFAPRFAIN.TabIndex = 5
        Me.txtFAPRFAIN.Text = "0.0000"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(18, 187)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 20)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "Factor inicial"
        '
        'lblFAPRTIVA
        '
        Me.lblFAPRTIVA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFAPRTIVA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFAPRTIVA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFAPRTIVA.ForeColor = System.Drawing.Color.Black
        Me.lblFAPRTIVA.Location = New System.Drawing.Point(449, 118)
        Me.lblFAPRTIVA.Name = "lblFAPRTIVA"
        Me.lblFAPRTIVA.Size = New System.Drawing.Size(124, 20)
        Me.lblFAPRTIVA.TabIndex = 58
        '
        'cboFAPRTIVA
        '
        Me.cboFAPRTIVA.AccessibleDescription = "Tipo de Variable"
        Me.cboFAPRTIVA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFAPRTIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFAPRTIVA.Enabled = False
        Me.cboFAPRTIVA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFAPRTIVA.FormattingEnabled = True
        Me.cboFAPRTIVA.Location = New System.Drawing.Point(152, 116)
        Me.cboFAPRTIVA.Name = "cboFAPRTIVA"
        Me.cboFAPRTIVA.Size = New System.Drawing.Size(291, 22)
        Me.cboFAPRTIVA.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(18, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 20)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Tipo de Variable"
        '
        'cboFAPRESTA
        '
        Me.cboFAPRESTA.AccessibleDescription = "Estado"
        Me.cboFAPRESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFAPRESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFAPRESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFAPRESTA.FormattingEnabled = True
        Me.cboFAPRESTA.Location = New System.Drawing.Point(152, 256)
        Me.cboFAPRESTA.Name = "cboFAPRESTA"
        Me.cboFAPRESTA.Size = New System.Drawing.Size(291, 22)
        Me.cboFAPRESTA.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(18, 256)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Estado"
        '
        'txtFAPRDESC
        '
        Me.txtFAPRDESC.AccessibleDescription = "Descripción"
        Me.txtFAPRDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtFAPRDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFAPRDESC.Location = New System.Drawing.Point(152, 164)
        Me.txtFAPRDESC.MaxLength = 100
        Me.txtFAPRDESC.Name = "txtFAPRDESC"
        Me.txtFAPRDESC.Size = New System.Drawing.Size(421, 20)
        Me.txtFAPRDESC.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(18, 164)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 20)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Descripción"
        '
        'lblCódigo
        '
        Me.lblCódigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCódigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCódigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCódigo.ForeColor = System.Drawing.Color.Black
        Me.lblCódigo.Location = New System.Drawing.Point(18, 141)
        Me.lblCódigo.Name = "lblCódigo"
        Me.lblCódigo.Size = New System.Drawing.Size(130, 20)
        Me.lblCódigo.TabIndex = 37
        Me.lblCódigo.Text = "Código"
        '
        'frm_modificar_FACTPROY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 409)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCLASSUEL)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(635, 445)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(635, 445)
        Me.Name = "frm_modificar_FACTPROY"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraCLASSUEL.ResumeLayout(False)
        Me.fraCLASSUEL.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraCLASSUEL As System.Windows.Forms.GroupBox
    Friend WithEvents lblFAPRTIVA As System.Windows.Forms.Label
    Friend WithEvents cboFAPRTIVA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboFAPRESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFAPRDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCódigo As System.Windows.Forms.Label
    Friend WithEvents txtFAPRFAAP As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFAPRFAFI As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFAPRFAIN As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFAPRPROY As System.Windows.Forms.Label
    Friend WithEvents cboFAPRPROY As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblFAPRCLSE As System.Windows.Forms.Label
    Friend WithEvents cboFAPRCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblFAPRDEPA As System.Windows.Forms.Label
    Friend WithEvents cboFAPRDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblFAPRMUNI As System.Windows.Forms.Label
    Friend WithEvents cboFAPRMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblFAPRVARI As System.Windows.Forms.Label
    Friend WithEvents cboFAPRVARI As System.Windows.Forms.ComboBox
    Friend WithEvents chkFAPRAPRA As System.Windows.Forms.CheckBox
End Class
