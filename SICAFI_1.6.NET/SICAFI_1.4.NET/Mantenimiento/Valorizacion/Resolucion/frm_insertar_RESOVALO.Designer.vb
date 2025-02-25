<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_RESOVALO
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
        Me.fraFORMMUNI = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbdREVARETO = New System.Windows.Forms.RadioButton()
        Me.rbdREVAREPA = New System.Windows.Forms.RadioButton()
        Me.txtREVACONT = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtREVADESC = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtREVADECR = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblREVATIRE = New System.Windows.Forms.Label()
        Me.cboREVATIRE = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblREVAPROY = New System.Windows.Forms.Label()
        Me.cboREVAPROY = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblREVAVIGE = New System.Windows.Forms.Label()
        Me.cboREVAVIGE = New System.Windows.Forms.ComboBox()
        Me.lblREVACLSE = New System.Windows.Forms.Label()
        Me.cboREVACLSE = New System.Windows.Forms.ComboBox()
        Me.lblClaseosector = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblREVADEPA = New System.Windows.Forms.Label()
        Me.cboREVADEPA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblREVAMUNI = New System.Windows.Forms.Label()
        Me.cboREVAMUNI = New System.Windows.Forms.ComboBox()
        Me.lblMUNICIPIO = New System.Windows.Forms.Label()
        Me.cboREVAESTA = New System.Windows.Forms.ComboBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtREVAFECH = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraFORMMUNI.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 367)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 52)
        Me.GroupBox1.TabIndex = 56
        Me.GroupBox1.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(293, 17)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 21
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(186, 17)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 20
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 441)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(601, 25)
        Me.strBARRESTA.TabIndex = 57
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
        'fraFORMMUNI
        '
        Me.fraFORMMUNI.BackColor = System.Drawing.SystemColors.Control
        Me.fraFORMMUNI.Controls.Add(Me.txtREVAFECH)
        Me.fraFORMMUNI.Controls.Add(Me.Label7)
        Me.fraFORMMUNI.Controls.Add(Me.GroupBox2)
        Me.fraFORMMUNI.Controls.Add(Me.txtREVACONT)
        Me.fraFORMMUNI.Controls.Add(Me.Label6)
        Me.fraFORMMUNI.Controls.Add(Me.txtREVADESC)
        Me.fraFORMMUNI.Controls.Add(Me.Label5)
        Me.fraFORMMUNI.Controls.Add(Me.txtREVADECR)
        Me.fraFORMMUNI.Controls.Add(Me.Label1)
        Me.fraFORMMUNI.Controls.Add(Me.lblREVATIRE)
        Me.fraFORMMUNI.Controls.Add(Me.cboREVATIRE)
        Me.fraFORMMUNI.Controls.Add(Me.Label2)
        Me.fraFORMMUNI.Controls.Add(Me.lblREVAPROY)
        Me.fraFORMMUNI.Controls.Add(Me.cboREVAPROY)
        Me.fraFORMMUNI.Controls.Add(Me.Label11)
        Me.fraFORMMUNI.Controls.Add(Me.lblREVAVIGE)
        Me.fraFORMMUNI.Controls.Add(Me.cboREVAVIGE)
        Me.fraFORMMUNI.Controls.Add(Me.lblREVACLSE)
        Me.fraFORMMUNI.Controls.Add(Me.cboREVACLSE)
        Me.fraFORMMUNI.Controls.Add(Me.lblClaseosector)
        Me.fraFORMMUNI.Controls.Add(Me.Label3)
        Me.fraFORMMUNI.Controls.Add(Me.lblREVADEPA)
        Me.fraFORMMUNI.Controls.Add(Me.cboREVADEPA)
        Me.fraFORMMUNI.Controls.Add(Me.Label4)
        Me.fraFORMMUNI.Controls.Add(Me.lblREVAMUNI)
        Me.fraFORMMUNI.Controls.Add(Me.cboREVAMUNI)
        Me.fraFORMMUNI.Controls.Add(Me.lblMUNICIPIO)
        Me.fraFORMMUNI.Controls.Add(Me.cboREVAESTA)
        Me.fraFORMMUNI.Controls.Add(Me.lblCodigo)
        Me.fraFORMMUNI.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraFORMMUNI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraFORMMUNI.Location = New System.Drawing.Point(12, 10)
        Me.fraFORMMUNI.Name = "fraFORMMUNI"
        Me.fraFORMMUNI.Size = New System.Drawing.Size(572, 351)
        Me.fraFORMMUNI.TabIndex = 55
        Me.fraFORMMUNI.TabStop = False
        Me.fraFORMMUNI.Text = "INSERTAR RESOLUCIÓN DE VALORIZACIÓN"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbdREVARETO)
        Me.GroupBox2.Controls.Add(Me.rbdREVAREPA)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 287)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(539, 49)
        Me.GroupBox2.TabIndex = 92
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PROYECTO"
        '
        'rbdREVARETO
        '
        Me.rbdREVARETO.AccessibleDescription = "Total"
        Me.rbdREVARETO.AutoSize = True
        Me.rbdREVARETO.Checked = True
        Me.rbdREVARETO.Location = New System.Drawing.Point(216, 20)
        Me.rbdREVARETO.Name = "rbdREVARETO"
        Me.rbdREVARETO.Size = New System.Drawing.Size(52, 19)
        Me.rbdREVARETO.TabIndex = 87
        Me.rbdREVARETO.TabStop = True
        Me.rbdREVARETO.Text = "Total"
        Me.rbdREVARETO.UseVisualStyleBackColor = True
        '
        'rbdREVAREPA
        '
        Me.rbdREVAREPA.AccessibleDescription = "Parcial"
        Me.rbdREVAREPA.AutoSize = True
        Me.rbdREVAREPA.Location = New System.Drawing.Point(286, 20)
        Me.rbdREVAREPA.Name = "rbdREVAREPA"
        Me.rbdREVAREPA.Size = New System.Drawing.Size(63, 19)
        Me.rbdREVAREPA.TabIndex = 86
        Me.rbdREVAREPA.Text = "Parcial"
        Me.rbdREVAREPA.UseVisualStyleBackColor = True
        '
        'txtREVACONT
        '
        Me.txtREVACONT.AccessibleDescription = "Descrpción"
        Me.txtREVACONT.BackColor = System.Drawing.SystemColors.Window
        Me.txtREVACONT.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREVACONT.Location = New System.Drawing.Point(137, 261)
        Me.txtREVACONT.MaxLength = 500
        Me.txtREVACONT.Name = "txtREVACONT"
        Me.txtREVACONT.Size = New System.Drawing.Size(421, 20)
        Me.txtREVACONT.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(19, 261)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "Contraseña"
        '
        'txtREVADESC
        '
        Me.txtREVADESC.AccessibleDescription = "Descrpción"
        Me.txtREVADESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtREVADESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREVADESC.Location = New System.Drawing.Point(137, 214)
        Me.txtREVADESC.MaxLength = 100
        Me.txtREVADESC.Name = "txtREVADESC"
        Me.txtREVADESC.Size = New System.Drawing.Size(421, 20)
        Me.txtREVADESC.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 214)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 89
        Me.Label5.Text = "Descripción"
        '
        'txtREVADECR
        '
        Me.txtREVADECR.AccessibleDescription = "Decreto"
        Me.txtREVADECR.BackColor = System.Drawing.SystemColors.Window
        Me.txtREVADECR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREVADECR.Location = New System.Drawing.Point(137, 168)
        Me.txtREVADECR.MaxLength = 9
        Me.txtREVADECR.Name = "txtREVADECR"
        Me.txtREVADECR.Size = New System.Drawing.Size(305, 20)
        Me.txtREVADECR.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Decreto"
        '
        'lblREVATIRE
        '
        Me.lblREVATIRE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREVATIRE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREVATIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREVATIRE.ForeColor = System.Drawing.Color.Black
        Me.lblREVATIRE.Location = New System.Drawing.Point(448, 144)
        Me.lblREVATIRE.Name = "lblREVATIRE"
        Me.lblREVATIRE.Size = New System.Drawing.Size(110, 20)
        Me.lblREVATIRE.TabIndex = 81
        '
        'cboREVATIRE
        '
        Me.cboREVATIRE.AccessibleDescription = "Tipo de resolución"
        Me.cboREVATIRE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboREVATIRE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboREVATIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboREVATIRE.FormattingEnabled = True
        Me.cboREVATIRE.Location = New System.Drawing.Point(137, 142)
        Me.cboREVATIRE.Name = "cboREVATIRE"
        Me.cboREVATIRE.Size = New System.Drawing.Size(305, 22)
        Me.cboREVATIRE.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Tipo de resolución"
        '
        'lblREVAPROY
        '
        Me.lblREVAPROY.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREVAPROY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREVAPROY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREVAPROY.ForeColor = System.Drawing.Color.Black
        Me.lblREVAPROY.Location = New System.Drawing.Point(448, 120)
        Me.lblREVAPROY.Name = "lblREVAPROY"
        Me.lblREVAPROY.Size = New System.Drawing.Size(110, 20)
        Me.lblREVAPROY.TabIndex = 78
        '
        'cboREVAPROY
        '
        Me.cboREVAPROY.AccessibleDescription = "Proyecto"
        Me.cboREVAPROY.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboREVAPROY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboREVAPROY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboREVAPROY.FormattingEnabled = True
        Me.cboREVAPROY.Location = New System.Drawing.Point(137, 118)
        Me.cboREVAPROY.Name = "cboREVAPROY"
        Me.cboREVAPROY.Size = New System.Drawing.Size(305, 22)
        Me.cboREVAPROY.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(19, 120)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 20)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "Proyecto"
        '
        'lblREVAVIGE
        '
        Me.lblREVAVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREVAVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREVAVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREVAVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblREVAVIGE.Location = New System.Drawing.Point(448, 97)
        Me.lblREVAVIGE.Name = "lblREVAVIGE"
        Me.lblREVAVIGE.Size = New System.Drawing.Size(110, 20)
        Me.lblREVAVIGE.TabIndex = 62
        '
        'cboREVAVIGE
        '
        Me.cboREVAVIGE.AccessibleDescription = "Vigencia"
        Me.cboREVAVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboREVAVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboREVAVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboREVAVIGE.FormattingEnabled = True
        Me.cboREVAVIGE.Location = New System.Drawing.Point(137, 95)
        Me.cboREVAVIGE.Name = "cboREVAVIGE"
        Me.cboREVAVIGE.Size = New System.Drawing.Size(305, 22)
        Me.cboREVAVIGE.TabIndex = 4
        '
        'lblREVACLSE
        '
        Me.lblREVACLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREVACLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREVACLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREVACLSE.ForeColor = System.Drawing.Color.Black
        Me.lblREVACLSE.Location = New System.Drawing.Point(448, 74)
        Me.lblREVACLSE.Name = "lblREVACLSE"
        Me.lblREVACLSE.Size = New System.Drawing.Size(110, 20)
        Me.lblREVACLSE.TabIndex = 57
        '
        'cboREVACLSE
        '
        Me.cboREVACLSE.AccessibleDescription = "Clase o sector"
        Me.cboREVACLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboREVACLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboREVACLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboREVACLSE.FormattingEnabled = True
        Me.cboREVACLSE.Location = New System.Drawing.Point(137, 72)
        Me.cboREVACLSE.Name = "cboREVACLSE"
        Me.cboREVACLSE.Size = New System.Drawing.Size(305, 22)
        Me.cboREVACLSE.TabIndex = 3
        '
        'lblClaseosector
        '
        Me.lblClaseosector.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseosector.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseosector.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseosector.ForeColor = System.Drawing.Color.Black
        Me.lblClaseosector.Location = New System.Drawing.Point(19, 74)
        Me.lblClaseosector.Name = "lblClaseosector"
        Me.lblClaseosector.Size = New System.Drawing.Size(112, 20)
        Me.lblClaseosector.TabIndex = 56
        Me.lblClaseosector.Text = "Clase o sector"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 237)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'lblREVADEPA
        '
        Me.lblREVADEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREVADEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREVADEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREVADEPA.ForeColor = System.Drawing.Color.Black
        Me.lblREVADEPA.Location = New System.Drawing.Point(448, 28)
        Me.lblREVADEPA.Name = "lblREVADEPA"
        Me.lblREVADEPA.Size = New System.Drawing.Size(110, 20)
        Me.lblREVADEPA.TabIndex = 52
        '
        'cboREVADEPA
        '
        Me.cboREVADEPA.AccessibleDescription = "Departamento"
        Me.cboREVADEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboREVADEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboREVADEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboREVADEPA.FormattingEnabled = True
        Me.cboREVADEPA.Location = New System.Drawing.Point(137, 26)
        Me.cboREVADEPA.Name = "cboREVADEPA"
        Me.cboREVADEPA.Size = New System.Drawing.Size(305, 22)
        Me.cboREVADEPA.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 20)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Departamento"
        '
        'lblREVAMUNI
        '
        Me.lblREVAMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREVAMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREVAMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREVAMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblREVAMUNI.Location = New System.Drawing.Point(448, 51)
        Me.lblREVAMUNI.Name = "lblREVAMUNI"
        Me.lblREVAMUNI.Size = New System.Drawing.Size(110, 20)
        Me.lblREVAMUNI.TabIndex = 50
        '
        'cboREVAMUNI
        '
        Me.cboREVAMUNI.AccessibleDescription = "Municipio"
        Me.cboREVAMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboREVAMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboREVAMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboREVAMUNI.FormattingEnabled = True
        Me.cboREVAMUNI.Location = New System.Drawing.Point(137, 49)
        Me.cboREVAMUNI.Name = "cboREVAMUNI"
        Me.cboREVAMUNI.Size = New System.Drawing.Size(305, 22)
        Me.cboREVAMUNI.TabIndex = 2
        '
        'lblMUNICIPIO
        '
        Me.lblMUNICIPIO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMUNICIPIO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUNICIPIO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUNICIPIO.ForeColor = System.Drawing.Color.Black
        Me.lblMUNICIPIO.Location = New System.Drawing.Point(19, 51)
        Me.lblMUNICIPIO.Name = "lblMUNICIPIO"
        Me.lblMUNICIPIO.Size = New System.Drawing.Size(112, 20)
        Me.lblMUNICIPIO.TabIndex = 49
        Me.lblMUNICIPIO.Text = "Municipio"
        '
        'cboREVAESTA
        '
        Me.cboREVAESTA.AccessibleDescription = "Estado"
        Me.cboREVAESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboREVAESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboREVAESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboREVAESTA.FormattingEnabled = True
        Me.cboREVAESTA.Location = New System.Drawing.Point(137, 237)
        Me.cboREVAESTA.Name = "cboREVAESTA"
        Me.cboREVAESTA.Size = New System.Drawing.Size(305, 22)
        Me.cboREVAESTA.TabIndex = 10
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(19, 97)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(112, 20)
        Me.lblCodigo.TabIndex = 37
        Me.lblCodigo.Text = "Vigencia"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(19, 191)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 20)
        Me.Label7.TabIndex = 94
        Me.Label7.Text = "Fecha"
        '
        'txtREVAFECH
        '
        Me.txtREVAFECH.AccessibleDescription = "Fecha "
        Me.txtREVAFECH.BackColor = System.Drawing.Color.White
        Me.txtREVAFECH.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREVAFECH.Location = New System.Drawing.Point(137, 191)
        Me.txtREVAFECH.Mask = "00-00-0000"
        Me.txtREVAFECH.Name = "txtREVAFECH"
        Me.txtREVAFECH.Size = New System.Drawing.Size(150, 20)
        Me.txtREVAFECH.TabIndex = 8
        Me.txtREVAFECH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtREVAFECH.ValidatingType = GetType(Date)
        '
        'frm_insertar_RESOVALO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 466)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraFORMMUNI)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(617, 502)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(617, 502)
        Me.Name = "frm_insertar_RESOVALO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraFORMMUNI.ResumeLayout(False)
        Me.fraFORMMUNI.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraFORMMUNI As System.Windows.Forms.GroupBox
    Friend WithEvents txtREVADECR As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblREVATIRE As System.Windows.Forms.Label
    Friend WithEvents cboREVATIRE As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblREVAPROY As System.Windows.Forms.Label
    Friend WithEvents cboREVAPROY As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblREVAVIGE As System.Windows.Forms.Label
    Friend WithEvents cboREVAVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents lblREVACLSE As System.Windows.Forms.Label
    Friend WithEvents cboREVACLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblREVADEPA As System.Windows.Forms.Label
    Friend WithEvents cboREVADEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblREVAMUNI As System.Windows.Forms.Label
    Friend WithEvents cboREVAMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cboREVAESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents rbdREVARETO As System.Windows.Forms.RadioButton
    Friend WithEvents rbdREVAREPA As System.Windows.Forms.RadioButton
    Friend WithEvents txtREVADESC As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtREVACONT As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtREVAFECH As System.Windows.Forms.MaskedTextBox
End Class
