<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_RANGOS
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
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraRANGO = New System.Windows.Forms.GroupBox()
        Me.txtRANGRAFI = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRANGRAIN = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblRANGVARI = New System.Windows.Forms.Label()
        Me.cboRANGVARI = New System.Windows.Forms.ComboBox()
        Me.lblRANGCLSE = New System.Windows.Forms.Label()
        Me.cboRANGCLSE = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblRANGDEPA = New System.Windows.Forms.Label()
        Me.cboRANGDEPA = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblRANGMUNI = New System.Windows.Forms.Label()
        Me.cboRANGMUNI = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblRANGPROY = New System.Windows.Forms.Label()
        Me.cboRANGPROY = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRANGFAAP = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRANGFAFI = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRANGFAIN = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblRANGTIVA = New System.Windows.Forms.Label()
        Me.cboRANGTIVA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboRANGESTA = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCódigo = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraRANGO.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 338)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(591, 54)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(289, 19)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(182, 19)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 407)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(619, 25)
        Me.strBARRESTA.TabIndex = 37
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
        'fraRANGO
        '
        Me.fraRANGO.BackColor = System.Drawing.SystemColors.Control
        Me.fraRANGO.Controls.Add(Me.txtRANGRAFI)
        Me.fraRANGO.Controls.Add(Me.Label7)
        Me.fraRANGO.Controls.Add(Me.txtRANGRAIN)
        Me.fraRANGO.Controls.Add(Me.Label10)
        Me.fraRANGO.Controls.Add(Me.lblRANGVARI)
        Me.fraRANGO.Controls.Add(Me.cboRANGVARI)
        Me.fraRANGO.Controls.Add(Me.lblRANGCLSE)
        Me.fraRANGO.Controls.Add(Me.cboRANGCLSE)
        Me.fraRANGO.Controls.Add(Me.Label13)
        Me.fraRANGO.Controls.Add(Me.lblRANGDEPA)
        Me.fraRANGO.Controls.Add(Me.cboRANGDEPA)
        Me.fraRANGO.Controls.Add(Me.Label9)
        Me.fraRANGO.Controls.Add(Me.lblRANGMUNI)
        Me.fraRANGO.Controls.Add(Me.cboRANGMUNI)
        Me.fraRANGO.Controls.Add(Me.Label11)
        Me.fraRANGO.Controls.Add(Me.lblRANGPROY)
        Me.fraRANGO.Controls.Add(Me.cboRANGPROY)
        Me.fraRANGO.Controls.Add(Me.Label8)
        Me.fraRANGO.Controls.Add(Me.txtRANGFAAP)
        Me.fraRANGO.Controls.Add(Me.Label6)
        Me.fraRANGO.Controls.Add(Me.txtRANGFAFI)
        Me.fraRANGO.Controls.Add(Me.Label5)
        Me.fraRANGO.Controls.Add(Me.txtRANGFAIN)
        Me.fraRANGO.Controls.Add(Me.Label3)
        Me.fraRANGO.Controls.Add(Me.lblRANGTIVA)
        Me.fraRANGO.Controls.Add(Me.cboRANGTIVA)
        Me.fraRANGO.Controls.Add(Me.Label4)
        Me.fraRANGO.Controls.Add(Me.cboRANGESTA)
        Me.fraRANGO.Controls.Add(Me.Label2)
        Me.fraRANGO.Controls.Add(Me.lblCódigo)
        Me.fraRANGO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraRANGO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraRANGO.Location = New System.Drawing.Point(12, 7)
        Me.fraRANGO.Name = "fraRANGO"
        Me.fraRANGO.Size = New System.Drawing.Size(591, 325)
        Me.fraRANGO.TabIndex = 36
        Me.fraRANGO.TabStop = False
        Me.fraRANGO.Text = "INSERTAR RANGOS"
        '
        'txtRANGRAFI
        '
        Me.txtRANGRAFI.AccessibleDescription = "Rango final"
        Me.txtRANGRAFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtRANGRAFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRANGRAFI.Location = New System.Drawing.Point(152, 260)
        Me.txtRANGRAFI.MaxLength = 12
        Me.txtRANGRAFI.Name = "txtRANGRAFI"
        Me.txtRANGRAFI.Size = New System.Drawing.Size(130, 20)
        Me.txtRANGRAFI.TabIndex = 12
        Me.txtRANGRAFI.Text = "0"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(18, 260)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(130, 20)
        Me.Label7.TabIndex = 79
        Me.Label7.Text = "Rango final"
        '
        'txtRANGRAIN
        '
        Me.txtRANGRAIN.AccessibleDescription = "Rango inicial"
        Me.txtRANGRAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtRANGRAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRANGRAIN.Location = New System.Drawing.Point(152, 237)
        Me.txtRANGRAIN.MaxLength = 12
        Me.txtRANGRAIN.Name = "txtRANGRAIN"
        Me.txtRANGRAIN.Size = New System.Drawing.Size(130, 20)
        Me.txtRANGRAIN.TabIndex = 11
        Me.txtRANGRAIN.Text = "0"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(18, 237)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(130, 20)
        Me.Label10.TabIndex = 78
        Me.Label10.Text = "Rango inicial"
        '
        'lblRANGVARI
        '
        Me.lblRANGVARI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRANGVARI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRANGVARI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRANGVARI.ForeColor = System.Drawing.Color.Black
        Me.lblRANGVARI.Location = New System.Drawing.Point(449, 145)
        Me.lblRANGVARI.Name = "lblRANGVARI"
        Me.lblRANGVARI.Size = New System.Drawing.Size(124, 20)
        Me.lblRANGVARI.TabIndex = 75
        '
        'cboRANGVARI
        '
        Me.cboRANGVARI.AccessibleDescription = "Variable"
        Me.cboRANGVARI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRANGVARI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRANGVARI.Enabled = False
        Me.cboRANGVARI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRANGVARI.FormattingEnabled = True
        Me.cboRANGVARI.Location = New System.Drawing.Point(152, 143)
        Me.cboRANGVARI.Name = "cboRANGVARI"
        Me.cboRANGVARI.Size = New System.Drawing.Size(291, 22)
        Me.cboRANGVARI.TabIndex = 6
        '
        'lblRANGCLSE
        '
        Me.lblRANGCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRANGCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRANGCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRANGCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblRANGCLSE.Location = New System.Drawing.Point(449, 74)
        Me.lblRANGCLSE.Name = "lblRANGCLSE"
        Me.lblRANGCLSE.Size = New System.Drawing.Size(124, 20)
        Me.lblRANGCLSE.TabIndex = 73
        '
        'cboRANGCLSE
        '
        Me.cboRANGCLSE.AccessibleDescription = "Clase o sector"
        Me.cboRANGCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRANGCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRANGCLSE.Enabled = False
        Me.cboRANGCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRANGCLSE.FormattingEnabled = True
        Me.cboRANGCLSE.Location = New System.Drawing.Point(152, 72)
        Me.cboRANGCLSE.Name = "cboRANGCLSE"
        Me.cboRANGCLSE.Size = New System.Drawing.Size(291, 22)
        Me.cboRANGCLSE.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(18, 74)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(130, 20)
        Me.Label13.TabIndex = 72
        Me.Label13.Text = "Clase o sector"
        '
        'lblRANGDEPA
        '
        Me.lblRANGDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRANGDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRANGDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRANGDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblRANGDEPA.Location = New System.Drawing.Point(449, 27)
        Me.lblRANGDEPA.Name = "lblRANGDEPA"
        Me.lblRANGDEPA.Size = New System.Drawing.Size(124, 20)
        Me.lblRANGDEPA.TabIndex = 70
        '
        'cboRANGDEPA
        '
        Me.cboRANGDEPA.AccessibleDescription = "Departamento"
        Me.cboRANGDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRANGDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRANGDEPA.Enabled = False
        Me.cboRANGDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRANGDEPA.FormattingEnabled = True
        Me.cboRANGDEPA.Location = New System.Drawing.Point(152, 25)
        Me.cboRANGDEPA.Name = "cboRANGDEPA"
        Me.cboRANGDEPA.Size = New System.Drawing.Size(291, 22)
        Me.cboRANGDEPA.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(18, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(130, 20)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "Departamento"
        '
        'lblRANGMUNI
        '
        Me.lblRANGMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRANGMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRANGMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRANGMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblRANGMUNI.Location = New System.Drawing.Point(449, 51)
        Me.lblRANGMUNI.Name = "lblRANGMUNI"
        Me.lblRANGMUNI.Size = New System.Drawing.Size(124, 20)
        Me.lblRANGMUNI.TabIndex = 68
        '
        'cboRANGMUNI
        '
        Me.cboRANGMUNI.AccessibleDescription = "Municipio"
        Me.cboRANGMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRANGMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRANGMUNI.Enabled = False
        Me.cboRANGMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRANGMUNI.FormattingEnabled = True
        Me.cboRANGMUNI.Location = New System.Drawing.Point(152, 49)
        Me.cboRANGMUNI.Name = "cboRANGMUNI"
        Me.cboRANGMUNI.Size = New System.Drawing.Size(291, 22)
        Me.cboRANGMUNI.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(18, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(130, 20)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "Municipio"
        '
        'lblRANGPROY
        '
        Me.lblRANGPROY.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRANGPROY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRANGPROY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRANGPROY.ForeColor = System.Drawing.Color.Black
        Me.lblRANGPROY.Location = New System.Drawing.Point(449, 97)
        Me.lblRANGPROY.Name = "lblRANGPROY"
        Me.lblRANGPROY.Size = New System.Drawing.Size(124, 20)
        Me.lblRANGPROY.TabIndex = 64
        '
        'cboRANGPROY
        '
        Me.cboRANGPROY.AccessibleDescription = "Proyecto"
        Me.cboRANGPROY.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRANGPROY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRANGPROY.Enabled = False
        Me.cboRANGPROY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRANGPROY.FormattingEnabled = True
        Me.cboRANGPROY.Location = New System.Drawing.Point(152, 95)
        Me.cboRANGPROY.Name = "cboRANGPROY"
        Me.cboRANGPROY.Size = New System.Drawing.Size(291, 22)
        Me.cboRANGPROY.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(18, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 20)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Proyecto"
        '
        'txtRANGFAAP
        '
        Me.txtRANGFAAP.AccessibleDescription = "Factor aplicado"
        Me.txtRANGFAAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtRANGFAAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRANGFAAP.Location = New System.Drawing.Point(152, 214)
        Me.txtRANGFAAP.MaxLength = 6
        Me.txtRANGFAAP.Name = "txtRANGFAAP"
        Me.txtRANGFAAP.Size = New System.Drawing.Size(130, 20)
        Me.txtRANGFAAP.TabIndex = 10
        Me.txtRANGFAAP.Text = "1.0000"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(18, 214)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 20)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "Factor aplicado"
        '
        'txtRANGFAFI
        '
        Me.txtRANGFAFI.AccessibleDescription = "Factor final"
        Me.txtRANGFAFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtRANGFAFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRANGFAFI.Location = New System.Drawing.Point(152, 191)
        Me.txtRANGFAFI.MaxLength = 6
        Me.txtRANGFAFI.Name = "txtRANGFAFI"
        Me.txtRANGFAFI.Size = New System.Drawing.Size(130, 20)
        Me.txtRANGFAFI.TabIndex = 9
        Me.txtRANGFAFI.Text = "1.0000"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(18, 191)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 20)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Factor final"
        '
        'txtRANGFAIN
        '
        Me.txtRANGFAIN.AccessibleDescription = "Factor inicial"
        Me.txtRANGFAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtRANGFAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRANGFAIN.Location = New System.Drawing.Point(152, 168)
        Me.txtRANGFAIN.MaxLength = 6
        Me.txtRANGFAIN.Name = "txtRANGFAIN"
        Me.txtRANGFAIN.Size = New System.Drawing.Size(130, 20)
        Me.txtRANGFAIN.TabIndex = 8
        Me.txtRANGFAIN.Text = "1.0000"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(18, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 20)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Factor inicial"
        '
        'lblRANGTIVA
        '
        Me.lblRANGTIVA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRANGTIVA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRANGTIVA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRANGTIVA.ForeColor = System.Drawing.Color.Black
        Me.lblRANGTIVA.Location = New System.Drawing.Point(449, 121)
        Me.lblRANGTIVA.Name = "lblRANGTIVA"
        Me.lblRANGTIVA.Size = New System.Drawing.Size(124, 20)
        Me.lblRANGTIVA.TabIndex = 55
        '
        'cboRANGTIVA
        '
        Me.cboRANGTIVA.AccessibleDescription = "Tipo de variable"
        Me.cboRANGTIVA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRANGTIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRANGTIVA.Enabled = False
        Me.cboRANGTIVA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRANGTIVA.FormattingEnabled = True
        Me.cboRANGTIVA.Location = New System.Drawing.Point(152, 119)
        Me.cboRANGTIVA.Name = "cboRANGTIVA"
        Me.cboRANGTIVA.Size = New System.Drawing.Size(291, 22)
        Me.cboRANGTIVA.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(18, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 20)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Tipo de Variable"
        '
        'cboRANGESTA
        '
        Me.cboRANGESTA.AccessibleDescription = "Estado"
        Me.cboRANGESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRANGESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRANGESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRANGESTA.FormattingEnabled = True
        Me.cboRANGESTA.Location = New System.Drawing.Point(152, 283)
        Me.cboRANGESTA.Name = "cboRANGESTA"
        Me.cboRANGESTA.Size = New System.Drawing.Size(291, 22)
        Me.cboRANGESTA.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(18, 283)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Estado"
        '
        'lblCódigo
        '
        Me.lblCódigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCódigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCódigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCódigo.ForeColor = System.Drawing.Color.Black
        Me.lblCódigo.Location = New System.Drawing.Point(18, 144)
        Me.lblCódigo.Name = "lblCódigo"
        Me.lblCódigo.Size = New System.Drawing.Size(130, 20)
        Me.lblCódigo.TabIndex = 37
        Me.lblCódigo.Text = "Variable"
        '
        'frm_modificar_RANGOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 432)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraRANGO)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(635, 468)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(635, 468)
        Me.Name = "frm_modificar_RANGOS"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraRANGO.ResumeLayout(False)
        Me.fraRANGO.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraRANGO As System.Windows.Forms.GroupBox
    Friend WithEvents txtRANGRAFI As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRANGRAIN As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblRANGVARI As System.Windows.Forms.Label
    Friend WithEvents cboRANGVARI As System.Windows.Forms.ComboBox
    Friend WithEvents lblRANGCLSE As System.Windows.Forms.Label
    Friend WithEvents cboRANGCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblRANGDEPA As System.Windows.Forms.Label
    Friend WithEvents cboRANGDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblRANGMUNI As System.Windows.Forms.Label
    Friend WithEvents cboRANGMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblRANGPROY As System.Windows.Forms.Label
    Friend WithEvents cboRANGPROY As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRANGFAAP As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRANGFAFI As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRANGFAIN As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblRANGTIVA As System.Windows.Forms.Label
    Friend WithEvents cboRANGTIVA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboRANGESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCódigo As System.Windows.Forms.Label
End Class
