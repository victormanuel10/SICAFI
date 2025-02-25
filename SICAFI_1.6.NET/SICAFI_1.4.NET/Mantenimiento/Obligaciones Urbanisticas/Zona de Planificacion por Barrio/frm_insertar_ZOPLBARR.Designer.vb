<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_ZOPLBARR
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
        Me.fraZOPLBARR = New System.Windows.Forms.GroupBox()
        Me.lblZPBAZOPL = New System.Windows.Forms.Label()
        Me.cboZPBAZOPL = New System.Windows.Forms.ComboBox()
        Me.lblZPBABARR = New System.Windows.Forms.Label()
        Me.cboZPBABARR = New System.Windows.Forms.ComboBox()
        Me.lblZPBACORR = New System.Windows.Forms.Label()
        Me.cboZPBACORR = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboZPBAESTA = New System.Windows.Forms.ComboBox()
        Me.lblZPBACLSE = New System.Windows.Forms.Label()
        Me.cboZPBACLSE = New System.Windows.Forms.ComboBox()
        Me.lblClaseosector = New System.Windows.Forms.Label()
        Me.lblZPBADEPA = New System.Windows.Forms.Label()
        Me.cboCPBADEPA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblZPBAMUNI = New System.Windows.Forms.Label()
        Me.cboZPBAMUNI = New System.Windows.Forms.ComboBox()
        Me.lblMUNICIPIO = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraZOPLBARR.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 224)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(588, 52)
        Me.GroupBox1.TabIndex = 40
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
        Me.cmdSALIR.TabIndex = 11
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
        Me.cmdGUARDAR.TabIndex = 10
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 293)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(616, 25)
        Me.strBARRESTA.TabIndex = 39
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
        'fraZOPLBARR
        '
        Me.fraZOPLBARR.BackColor = System.Drawing.SystemColors.Control
        Me.fraZOPLBARR.Controls.Add(Me.lblZPBAZOPL)
        Me.fraZOPLBARR.Controls.Add(Me.cboZPBAZOPL)
        Me.fraZOPLBARR.Controls.Add(Me.lblZPBABARR)
        Me.fraZOPLBARR.Controls.Add(Me.cboZPBABARR)
        Me.fraZOPLBARR.Controls.Add(Me.lblZPBACORR)
        Me.fraZOPLBARR.Controls.Add(Me.cboZPBACORR)
        Me.fraZOPLBARR.Controls.Add(Me.Label5)
        Me.fraZOPLBARR.Controls.Add(Me.Label3)
        Me.fraZOPLBARR.Controls.Add(Me.cboZPBAESTA)
        Me.fraZOPLBARR.Controls.Add(Me.lblZPBACLSE)
        Me.fraZOPLBARR.Controls.Add(Me.cboZPBACLSE)
        Me.fraZOPLBARR.Controls.Add(Me.lblClaseosector)
        Me.fraZOPLBARR.Controls.Add(Me.lblZPBADEPA)
        Me.fraZOPLBARR.Controls.Add(Me.cboCPBADEPA)
        Me.fraZOPLBARR.Controls.Add(Me.Label4)
        Me.fraZOPLBARR.Controls.Add(Me.lblZPBAMUNI)
        Me.fraZOPLBARR.Controls.Add(Me.cboZPBAMUNI)
        Me.fraZOPLBARR.Controls.Add(Me.lblMUNICIPIO)
        Me.fraZOPLBARR.Controls.Add(Me.Label1)
        Me.fraZOPLBARR.Controls.Add(Me.lblCodigo)
        Me.fraZOPLBARR.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraZOPLBARR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraZOPLBARR.Location = New System.Drawing.Point(12, 10)
        Me.fraZOPLBARR.Name = "fraZOPLBARR"
        Me.fraZOPLBARR.Size = New System.Drawing.Size(588, 208)
        Me.fraZOPLBARR.TabIndex = 38
        Me.fraZOPLBARR.TabStop = False
        Me.fraZOPLBARR.Text = "INSERTAR ZONA DE PLANIFICACIÓN POR BARRIO"
        '
        'lblZPBAZOPL
        '
        Me.lblZPBAZOPL.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZPBAZOPL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZPBAZOPL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZPBAZOPL.ForeColor = System.Drawing.Color.Black
        Me.lblZPBAZOPL.Location = New System.Drawing.Point(450, 143)
        Me.lblZPBAZOPL.Name = "lblZPBAZOPL"
        Me.lblZPBAZOPL.Size = New System.Drawing.Size(124, 20)
        Me.lblZPBAZOPL.TabIndex = 64
        '
        'cboZPBAZOPL
        '
        Me.cboZPBAZOPL.AccessibleDescription = "Zona de planificacion"
        Me.cboZPBAZOPL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboZPBAZOPL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZPBAZOPL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZPBAZOPL.FormattingEnabled = True
        Me.cboZPBAZOPL.Location = New System.Drawing.Point(153, 141)
        Me.cboZPBAZOPL.Name = "cboZPBAZOPL"
        Me.cboZPBAZOPL.Size = New System.Drawing.Size(291, 22)
        Me.cboZPBAZOPL.TabIndex = 6
        '
        'lblZPBABARR
        '
        Me.lblZPBABARR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZPBABARR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZPBABARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZPBABARR.ForeColor = System.Drawing.Color.Black
        Me.lblZPBABARR.Location = New System.Drawing.Point(450, 120)
        Me.lblZPBABARR.Name = "lblZPBABARR"
        Me.lblZPBABARR.Size = New System.Drawing.Size(124, 20)
        Me.lblZPBABARR.TabIndex = 63
        '
        'cboZPBABARR
        '
        Me.cboZPBABARR.AccessibleDescription = "Barrio o Vereda"
        Me.cboZPBABARR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboZPBABARR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZPBABARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZPBABARR.FormattingEnabled = True
        Me.cboZPBABARR.Location = New System.Drawing.Point(153, 118)
        Me.cboZPBABARR.Name = "cboZPBABARR"
        Me.cboZPBABARR.Size = New System.Drawing.Size(291, 22)
        Me.cboZPBABARR.TabIndex = 5
        '
        'lblZPBACORR
        '
        Me.lblZPBACORR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZPBACORR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZPBACORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZPBACORR.ForeColor = System.Drawing.Color.Black
        Me.lblZPBACORR.Location = New System.Drawing.Point(450, 97)
        Me.lblZPBACORR.Name = "lblZPBACORR"
        Me.lblZPBACORR.Size = New System.Drawing.Size(124, 20)
        Me.lblZPBACORR.TabIndex = 60
        '
        'cboZPBACORR
        '
        Me.cboZPBACORR.AccessibleDescription = "Corregimiento"
        Me.cboZPBACORR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboZPBACORR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZPBACORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZPBACORR.FormattingEnabled = True
        Me.cboZPBACORR.Location = New System.Drawing.Point(153, 95)
        Me.cboZPBACORR.Name = "cboZPBACORR"
        Me.cboZPBACORR.Size = New System.Drawing.Size(291, 22)
        Me.cboZPBACORR.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 20)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Corregimiento"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'cboZPBAESTA
        '
        Me.cboZPBAESTA.AccessibleDescription = "Estado"
        Me.cboZPBAESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboZPBAESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZPBAESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZPBAESTA.FormattingEnabled = True
        Me.cboZPBAESTA.Location = New System.Drawing.Point(153, 164)
        Me.cboZPBAESTA.MaximumSize = New System.Drawing.Size(291, 0)
        Me.cboZPBAESTA.MinimumSize = New System.Drawing.Size(291, 0)
        Me.cboZPBAESTA.Name = "cboZPBAESTA"
        Me.cboZPBAESTA.Size = New System.Drawing.Size(291, 22)
        Me.cboZPBAESTA.TabIndex = 7
        '
        'lblZPBACLSE
        '
        Me.lblZPBACLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZPBACLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZPBACLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZPBACLSE.ForeColor = System.Drawing.Color.Black
        Me.lblZPBACLSE.Location = New System.Drawing.Point(450, 74)
        Me.lblZPBACLSE.Name = "lblZPBACLSE"
        Me.lblZPBACLSE.Size = New System.Drawing.Size(124, 20)
        Me.lblZPBACLSE.TabIndex = 57
        '
        'cboZPBACLSE
        '
        Me.cboZPBACLSE.AccessibleDescription = "Clase o sector"
        Me.cboZPBACLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboZPBACLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZPBACLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZPBACLSE.FormattingEnabled = True
        Me.cboZPBACLSE.Location = New System.Drawing.Point(153, 72)
        Me.cboZPBACLSE.Name = "cboZPBACLSE"
        Me.cboZPBACLSE.Size = New System.Drawing.Size(291, 22)
        Me.cboZPBACLSE.TabIndex = 3
        '
        'lblClaseosector
        '
        Me.lblClaseosector.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseosector.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseosector.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseosector.ForeColor = System.Drawing.Color.Black
        Me.lblClaseosector.Location = New System.Drawing.Point(19, 74)
        Me.lblClaseosector.Name = "lblClaseosector"
        Me.lblClaseosector.Size = New System.Drawing.Size(130, 20)
        Me.lblClaseosector.TabIndex = 56
        Me.lblClaseosector.Text = "Clase o sector"
        '
        'lblZPBADEPA
        '
        Me.lblZPBADEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZPBADEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZPBADEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZPBADEPA.ForeColor = System.Drawing.Color.Black
        Me.lblZPBADEPA.Location = New System.Drawing.Point(450, 28)
        Me.lblZPBADEPA.Name = "lblZPBADEPA"
        Me.lblZPBADEPA.Size = New System.Drawing.Size(124, 20)
        Me.lblZPBADEPA.TabIndex = 52
        '
        'cboCPBADEPA
        '
        Me.cboCPBADEPA.AccessibleDescription = "Departamento"
        Me.cboCPBADEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCPBADEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCPBADEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCPBADEPA.FormattingEnabled = True
        Me.cboCPBADEPA.Location = New System.Drawing.Point(153, 26)
        Me.cboCPBADEPA.Name = "cboCPBADEPA"
        Me.cboCPBADEPA.Size = New System.Drawing.Size(291, 22)
        Me.cboCPBADEPA.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 20)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Departamento"
        '
        'lblZPBAMUNI
        '
        Me.lblZPBAMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZPBAMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZPBAMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZPBAMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblZPBAMUNI.Location = New System.Drawing.Point(450, 51)
        Me.lblZPBAMUNI.Name = "lblZPBAMUNI"
        Me.lblZPBAMUNI.Size = New System.Drawing.Size(124, 20)
        Me.lblZPBAMUNI.TabIndex = 50
        '
        'cboZPBAMUNI
        '
        Me.cboZPBAMUNI.AccessibleDescription = "Municipio"
        Me.cboZPBAMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboZPBAMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZPBAMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZPBAMUNI.FormattingEnabled = True
        Me.cboZPBAMUNI.Location = New System.Drawing.Point(153, 49)
        Me.cboZPBAMUNI.Name = "cboZPBAMUNI"
        Me.cboZPBAMUNI.Size = New System.Drawing.Size(291, 22)
        Me.cboZPBAMUNI.TabIndex = 2
        '
        'lblMUNICIPIO
        '
        Me.lblMUNICIPIO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMUNICIPIO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUNICIPIO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUNICIPIO.ForeColor = System.Drawing.Color.Black
        Me.lblMUNICIPIO.Location = New System.Drawing.Point(19, 51)
        Me.lblMUNICIPIO.Name = "lblMUNICIPIO"
        Me.lblMUNICIPIO.Size = New System.Drawing.Size(130, 20)
        Me.lblMUNICIPIO.TabIndex = 49
        Me.lblMUNICIPIO.Text = "Municipio"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 20)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Zona de planificación"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(19, 120)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(130, 20)
        Me.lblCodigo.TabIndex = 37
        Me.lblCodigo.Text = "Barrio - Vereda"
        '
        'frm_insertar_ZOPLBARR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 318)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraZOPLBARR)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(632, 354)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(632, 354)
        Me.Name = "frm_insertar_ZOPLBARR"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraZOPLBARR.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraZOPLBARR As System.Windows.Forms.GroupBox
    Friend WithEvents lblZPBACORR As System.Windows.Forms.Label
    Friend WithEvents cboZPBACORR As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboZPBAESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblZPBACLSE As System.Windows.Forms.Label
    Friend WithEvents cboZPBACLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents lblZPBADEPA As System.Windows.Forms.Label
    Friend WithEvents cboCPBADEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblZPBAMUNI As System.Windows.Forms.Label
    Friend WithEvents cboZPBAMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblZPBAZOPL As System.Windows.Forms.Label
    Friend WithEvents cboZPBAZOPL As System.Windows.Forms.ComboBox
    Friend WithEvents lblZPBABARR As System.Windows.Forms.Label
    Friend WithEvents cboZPBABARR As System.Windows.Forms.ComboBox
End Class
