<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_CARGBENE
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
        Me.fraCOMANDOS = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraCARGBENE = New System.Windows.Forms.GroupBox()
        Me.txtCABECOEQ = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCABECOVI = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCABECEVI = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCABECOEP = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCABECEEP = New System.Windows.Forms.TextBox()
        Me.cboCABEPLPA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboCABEESTA = New System.Windows.Forms.ComboBox()
        Me.lblCAPRESTA = New System.Windows.Forms.Label()
        Me.txtCABEDESC = New System.Windows.Forms.TextBox()
        Me.txtCABEUAU = New System.Windows.Forms.TextBox()
        Me.lblCAPRDESC = New System.Windows.Forms.Label()
        Me.lblCAPRCODI = New System.Windows.Forms.Label()
        Me.txtCABECEDI = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCABECVAI = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.fraCOMANDOS.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraCARGBENE.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraCOMANDOS
        '
        Me.fraCOMANDOS.Controls.Add(Me.cmdSALIR)
        Me.fraCOMANDOS.Controls.Add(Me.cmdGUARDAR)
        Me.fraCOMANDOS.Location = New System.Drawing.Point(18, 310)
        Me.fraCOMANDOS.Name = "fraCOMANDOS"
        Me.fraCOMANDOS.Size = New System.Drawing.Size(588, 50)
        Me.fraCOMANDOS.TabIndex = 43
        Me.fraCOMANDOS.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(296, 16)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(189, 16)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 381)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(621, 25)
        Me.strBARRESTA.TabIndex = 44
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
        'fraCARGBENE
        '
        Me.fraCARGBENE.BackColor = System.Drawing.SystemColors.Control
        Me.fraCARGBENE.Controls.Add(Me.txtCABECEDI)
        Me.fraCARGBENE.Controls.Add(Me.Label7)
        Me.fraCARGBENE.Controls.Add(Me.txtCABECVAI)
        Me.fraCARGBENE.Controls.Add(Me.Label8)
        Me.fraCARGBENE.Controls.Add(Me.txtCABECOEQ)
        Me.fraCARGBENE.Controls.Add(Me.Label6)
        Me.fraCARGBENE.Controls.Add(Me.txtCABECOVI)
        Me.fraCARGBENE.Controls.Add(Me.Label5)
        Me.fraCARGBENE.Controls.Add(Me.txtCABECEVI)
        Me.fraCARGBENE.Controls.Add(Me.Label3)
        Me.fraCARGBENE.Controls.Add(Me.txtCABECOEP)
        Me.fraCARGBENE.Controls.Add(Me.Label2)
        Me.fraCARGBENE.Controls.Add(Me.txtCABECEEP)
        Me.fraCARGBENE.Controls.Add(Me.cboCABEPLPA)
        Me.fraCARGBENE.Controls.Add(Me.Label4)
        Me.fraCARGBENE.Controls.Add(Me.Label1)
        Me.fraCARGBENE.Controls.Add(Me.cboCABEESTA)
        Me.fraCARGBENE.Controls.Add(Me.lblCAPRESTA)
        Me.fraCARGBENE.Controls.Add(Me.txtCABEDESC)
        Me.fraCARGBENE.Controls.Add(Me.txtCABEUAU)
        Me.fraCARGBENE.Controls.Add(Me.lblCAPRDESC)
        Me.fraCARGBENE.Controls.Add(Me.lblCAPRCODI)
        Me.fraCARGBENE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraCARGBENE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraCARGBENE.Location = New System.Drawing.Point(18, 5)
        Me.fraCARGBENE.Name = "fraCARGBENE"
        Me.fraCARGBENE.Size = New System.Drawing.Size(588, 299)
        Me.fraCARGBENE.TabIndex = 42
        Me.fraCARGBENE.TabStop = False
        Me.fraCARGBENE.Text = "INSERTAR CARGAS Y BENEFICIOS DEL PLAN PARCIAL"
        '
        'txtCABECOEQ
        '
        Me.txtCABECOEQ.AccessibleDescription = "Const. equipamiento"
        Me.txtCABECOEQ.BackColor = System.Drawing.SystemColors.Window
        Me.txtCABECOEQ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCABECOEQ.Location = New System.Drawing.Point(151, 189)
        Me.txtCABECOEQ.MaxLength = 9
        Me.txtCABECOEQ.Name = "txtCABECOEQ"
        Me.txtCABECOEQ.Size = New System.Drawing.Size(144, 20)
        Me.txtCABECOEQ.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(17, 189)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 20)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "Cons. Equipamiento m2"
        '
        'txtCABECOVI
        '
        Me.txtCABECOVI.AccessibleDescription = "Construcción vias"
        Me.txtCABECOVI.BackColor = System.Drawing.SystemColors.Window
        Me.txtCABECOVI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCABECOVI.Location = New System.Drawing.Point(151, 166)
        Me.txtCABECOVI.MaxLength = 9
        Me.txtCABECOVI.Name = "txtCABECOVI"
        Me.txtCABECOVI.Size = New System.Drawing.Size(144, 20)
        Me.txtCABECOVI.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(17, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 20)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Cons. de Vias m2"
        '
        'txtCABECEVI
        '
        Me.txtCABECEVI.AccessibleDescription = "Cesión vias"
        Me.txtCABECEVI.BackColor = System.Drawing.SystemColors.Window
        Me.txtCABECEVI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCABECEVI.Location = New System.Drawing.Point(151, 143)
        Me.txtCABECEVI.MaxLength = 9
        Me.txtCABECEVI.Name = "txtCABECEVI"
        Me.txtCABECEVI.Size = New System.Drawing.Size(144, 20)
        Me.txtCABECEVI.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(17, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 20)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Cesión Suelo Vias m2"
        '
        'txtCABECOEP
        '
        Me.txtCABECOEP.AccessibleDescription = "Cons. Espacio público"
        Me.txtCABECOEP.BackColor = System.Drawing.SystemColors.Window
        Me.txtCABECOEP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCABECOEP.Location = New System.Drawing.Point(151, 120)
        Me.txtCABECOEP.MaxLength = 9
        Me.txtCABECOEP.Name = "txtCABECOEP"
        Me.txtCABECOEP.Size = New System.Drawing.Size(144, 20)
        Me.txtCABECOEP.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(17, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 20)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Cons. Espacio Público"
        '
        'txtCABECEEP
        '
        Me.txtCABECEEP.AccessibleDescription = "Cesión espacio público"
        Me.txtCABECEEP.BackColor = System.Drawing.SystemColors.Window
        Me.txtCABECEEP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCABECEEP.Location = New System.Drawing.Point(151, 97)
        Me.txtCABECEEP.MaxLength = 9
        Me.txtCABECEEP.Name = "txtCABECEEP"
        Me.txtCABECEEP.Size = New System.Drawing.Size(144, 20)
        Me.txtCABECEEP.TabIndex = 4
        '
        'cboCABEPLPA
        '
        Me.cboCABEPLPA.AccessibleDescription = "Plan Parcial"
        Me.cboCABEPLPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCABEPLPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCABEPLPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCABEPLPA.FormattingEnabled = True
        Me.cboCABEPLPA.Location = New System.Drawing.Point(151, 26)
        Me.cboCABEPLPA.Name = "cboCABEPLPA"
        Me.cboCABEPLPA.Size = New System.Drawing.Size(421, 22)
        Me.cboCABEPLPA.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(17, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 20)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Proyecto Plan Parcial"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 20)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Cesión Espacio Público"
        '
        'cboCABEESTA
        '
        Me.cboCABEESTA.AccessibleDescription = "Estado"
        Me.cboCABEESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCABEESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCABEESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCABEESTA.FormattingEnabled = True
        Me.cboCABEESTA.Items.AddRange(New Object() {""})
        Me.cboCABEESTA.Location = New System.Drawing.Point(151, 258)
        Me.cboCABEESTA.Name = "cboCABEESTA"
        Me.cboCABEESTA.Size = New System.Drawing.Size(291, 22)
        Me.cboCABEESTA.TabIndex = 11
        '
        'lblCAPRESTA
        '
        Me.lblCAPRESTA.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCAPRESTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAPRESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAPRESTA.ForeColor = System.Drawing.Color.Black
        Me.lblCAPRESTA.Location = New System.Drawing.Point(17, 258)
        Me.lblCAPRESTA.Name = "lblCAPRESTA"
        Me.lblCAPRESTA.Size = New System.Drawing.Size(130, 20)
        Me.lblCAPRESTA.TabIndex = 41
        Me.lblCAPRESTA.Text = "Estado"
        '
        'txtCABEDESC
        '
        Me.txtCABEDESC.AccessibleDescription = "Descripción"
        Me.txtCABEDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtCABEDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCABEDESC.Location = New System.Drawing.Point(151, 74)
        Me.txtCABEDESC.MaxLength = 50
        Me.txtCABEDESC.Name = "txtCABEDESC"
        Me.txtCABEDESC.Size = New System.Drawing.Size(421, 20)
        Me.txtCABEDESC.TabIndex = 3
        '
        'txtCABEUAU
        '
        Me.txtCABEUAU.AccessibleDescription = "Unidad de actuación"
        Me.txtCABEUAU.BackColor = System.Drawing.SystemColors.Window
        Me.txtCABEUAU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCABEUAU.Location = New System.Drawing.Point(151, 51)
        Me.txtCABEUAU.MaxLength = 9
        Me.txtCABEUAU.Name = "txtCABEUAU"
        Me.txtCABEUAU.Size = New System.Drawing.Size(144, 20)
        Me.txtCABEUAU.TabIndex = 2
        '
        'lblCAPRDESC
        '
        Me.lblCAPRDESC.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCAPRDESC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAPRDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAPRDESC.ForeColor = System.Drawing.Color.Black
        Me.lblCAPRDESC.Location = New System.Drawing.Point(17, 74)
        Me.lblCAPRDESC.Name = "lblCAPRDESC"
        Me.lblCAPRDESC.Size = New System.Drawing.Size(130, 20)
        Me.lblCAPRDESC.TabIndex = 38
        Me.lblCAPRDESC.Text = "Descripción"
        '
        'lblCAPRCODI
        '
        Me.lblCAPRCODI.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCAPRCODI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCAPRCODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCAPRCODI.ForeColor = System.Drawing.Color.Black
        Me.lblCAPRCODI.Location = New System.Drawing.Point(17, 51)
        Me.lblCAPRCODI.Name = "lblCAPRCODI"
        Me.lblCAPRCODI.Size = New System.Drawing.Size(130, 20)
        Me.lblCAPRCODI.TabIndex = 37
        Me.lblCAPRCODI.Text = "U. A. U."
        '
        'txtCABECEDI
        '
        Me.txtCABECEDI.AccessibleDescription = "Const. equipamiento"
        Me.txtCABECEDI.BackColor = System.Drawing.SystemColors.Window
        Me.txtCABECEDI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCABECEDI.Location = New System.Drawing.Point(151, 235)
        Me.txtCABECEDI.MaxLength = 9
        Me.txtCABECEDI.Name = "txtCABECEDI"
        Me.txtCABECEDI.Size = New System.Drawing.Size(144, 20)
        Me.txtCABECEDI.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(17, 235)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(130, 20)
        Me.Label7.TabIndex = 67
        Me.Label7.Text = "Cesión en Dinero"
        '
        'txtCABECVAI
        '
        Me.txtCABECVAI.AccessibleDescription = "Const. vias A.I."
        Me.txtCABECVAI.BackColor = System.Drawing.SystemColors.Window
        Me.txtCABECVAI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCABECVAI.Location = New System.Drawing.Point(151, 212)
        Me.txtCABECVAI.MaxLength = 9
        Me.txtCABECVAI.Name = "txtCABECVAI"
        Me.txtCABECVAI.Size = New System.Drawing.Size(144, 20)
        Me.txtCABECVAI.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(17, 212)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 20)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Cons. Vias Fuera A.I. m2"
        '
        'frm_insertar_CARGBENE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 406)
        Me.Controls.Add(Me.fraCOMANDOS)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCARGBENE)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(637, 442)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(637, 442)
        Me.Name = "frm_insertar_CARGBENE"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.fraCOMANDOS.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraCARGBENE.ResumeLayout(False)
        Me.fraCARGBENE.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraCOMANDOS As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraCARGBENE As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCABEESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCAPRESTA As System.Windows.Forms.Label
    Friend WithEvents txtCABEDESC As System.Windows.Forms.TextBox
    Friend WithEvents txtCABEUAU As System.Windows.Forms.TextBox
    Friend WithEvents lblCAPRDESC As System.Windows.Forms.Label
    Friend WithEvents lblCAPRCODI As System.Windows.Forms.Label
    Friend WithEvents cboCABEPLPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCABECEEP As System.Windows.Forms.TextBox
    Friend WithEvents txtCABECOEQ As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCABECOVI As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCABECEVI As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCABECOEP As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCABECEDI As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCABECVAI As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
