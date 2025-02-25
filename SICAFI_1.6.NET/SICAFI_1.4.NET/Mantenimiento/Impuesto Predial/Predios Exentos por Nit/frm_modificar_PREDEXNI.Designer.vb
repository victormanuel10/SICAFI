<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_PREDEXNI
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.cmdGUARDAR = New System.Windows.Forms.Button
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.fraPREDEXEN = New System.Windows.Forms.GroupBox
        Me.lblPRENSEXO = New System.Windows.Forms.Label
        Me.cboPRENSEXO = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblPRENCAPR = New System.Windows.Forms.Label
        Me.cboPRENCAPR = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtPRENNUDO = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPRENDESC = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblPRENCONC = New System.Windows.Forms.Label
        Me.cboPRENCONC = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblPRENTIIM = New System.Windows.Forms.Label
        Me.cboPRENTIIM = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblPRENTIDO = New System.Windows.Forms.Label
        Me.cboPRENTIDO = New System.Windows.Forms.ComboBox
        Me.lblPRENCLSE = New System.Windows.Forms.Label
        Me.cboPRENCLSE = New System.Windows.Forms.ComboBox
        Me.lblClaseosector = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblPRENDEPA = New System.Windows.Forms.Label
        Me.cboPRENDEPA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblPRENMUNI = New System.Windows.Forms.Label
        Me.cboPRENMUNI = New System.Windows.Forms.ComboBox
        Me.lblMUNICIPIO = New System.Windows.Forms.Label
        Me.cboPRENESTA = New System.Windows.Forms.ComboBox
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraPREDEXEN.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 317)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 52)
        Me.GroupBox1.TabIndex = 59
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 378)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(599, 25)
        Me.strBARRESTA.TabIndex = 60
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
        'fraPREDEXEN
        '
        Me.fraPREDEXEN.BackColor = System.Drawing.SystemColors.Control
        Me.fraPREDEXEN.Controls.Add(Me.lblPRENSEXO)
        Me.fraPREDEXEN.Controls.Add(Me.cboPRENSEXO)
        Me.fraPREDEXEN.Controls.Add(Me.Label7)
        Me.fraPREDEXEN.Controls.Add(Me.lblPRENCAPR)
        Me.fraPREDEXEN.Controls.Add(Me.cboPRENCAPR)
        Me.fraPREDEXEN.Controls.Add(Me.Label8)
        Me.fraPREDEXEN.Controls.Add(Me.txtPRENNUDO)
        Me.fraPREDEXEN.Controls.Add(Me.Label5)
        Me.fraPREDEXEN.Controls.Add(Me.txtPRENDESC)
        Me.fraPREDEXEN.Controls.Add(Me.Label1)
        Me.fraPREDEXEN.Controls.Add(Me.lblPRENCONC)
        Me.fraPREDEXEN.Controls.Add(Me.cboPRENCONC)
        Me.fraPREDEXEN.Controls.Add(Me.Label2)
        Me.fraPREDEXEN.Controls.Add(Me.lblPRENTIIM)
        Me.fraPREDEXEN.Controls.Add(Me.cboPRENTIIM)
        Me.fraPREDEXEN.Controls.Add(Me.Label11)
        Me.fraPREDEXEN.Controls.Add(Me.lblPRENTIDO)
        Me.fraPREDEXEN.Controls.Add(Me.cboPRENTIDO)
        Me.fraPREDEXEN.Controls.Add(Me.lblPRENCLSE)
        Me.fraPREDEXEN.Controls.Add(Me.cboPRENCLSE)
        Me.fraPREDEXEN.Controls.Add(Me.lblClaseosector)
        Me.fraPREDEXEN.Controls.Add(Me.Label3)
        Me.fraPREDEXEN.Controls.Add(Me.lblPRENDEPA)
        Me.fraPREDEXEN.Controls.Add(Me.cboPRENDEPA)
        Me.fraPREDEXEN.Controls.Add(Me.Label4)
        Me.fraPREDEXEN.Controls.Add(Me.lblPRENMUNI)
        Me.fraPREDEXEN.Controls.Add(Me.cboPRENMUNI)
        Me.fraPREDEXEN.Controls.Add(Me.lblMUNICIPIO)
        Me.fraPREDEXEN.Controls.Add(Me.cboPRENESTA)
        Me.fraPREDEXEN.Controls.Add(Me.lblCodigo)
        Me.fraPREDEXEN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPREDEXEN.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPREDEXEN.Location = New System.Drawing.Point(12, 12)
        Me.fraPREDEXEN.Name = "fraPREDEXEN"
        Me.fraPREDEXEN.Size = New System.Drawing.Size(572, 299)
        Me.fraPREDEXEN.TabIndex = 58
        Me.fraPREDEXEN.TabStop = False
        Me.fraPREDEXEN.Text = "INSERTAR PREDIOS EXENTOS POR NIT"
        '
        'lblPRENSEXO
        '
        Me.lblPRENSEXO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPRENSEXO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPRENSEXO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPRENSEXO.ForeColor = System.Drawing.Color.Black
        Me.lblPRENSEXO.Location = New System.Drawing.Point(448, 190)
        Me.lblPRENSEXO.Name = "lblPRENSEXO"
        Me.lblPRENSEXO.Size = New System.Drawing.Size(110, 20)
        Me.lblPRENSEXO.TabIndex = 99
        '
        'cboPRENSEXO
        '
        Me.cboPRENSEXO.AccessibleDescription = "Sexo"
        Me.cboPRENSEXO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPRENSEXO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPRENSEXO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPRENSEXO.FormattingEnabled = True
        Me.cboPRENSEXO.Location = New System.Drawing.Point(137, 188)
        Me.cboPRENSEXO.Name = "cboPRENSEXO"
        Me.cboPRENSEXO.Size = New System.Drawing.Size(305, 22)
        Me.cboPRENSEXO.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(19, 190)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 20)
        Me.Label7.TabIndex = 98
        Me.Label7.Text = "Sexo"
        '
        'lblPRENCAPR
        '
        Me.lblPRENCAPR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPRENCAPR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPRENCAPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPRENCAPR.ForeColor = System.Drawing.Color.Black
        Me.lblPRENCAPR.Location = New System.Drawing.Point(448, 167)
        Me.lblPRENCAPR.Name = "lblPRENCAPR"
        Me.lblPRENCAPR.Size = New System.Drawing.Size(110, 20)
        Me.lblPRENCAPR.TabIndex = 90
        '
        'cboPRENCAPR
        '
        Me.cboPRENCAPR.AccessibleDescription = "Calidad propietario"
        Me.cboPRENCAPR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPRENCAPR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPRENCAPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPRENCAPR.FormattingEnabled = True
        Me.cboPRENCAPR.Location = New System.Drawing.Point(137, 165)
        Me.cboPRENCAPR.Name = "cboPRENCAPR"
        Me.cboPRENCAPR.Size = New System.Drawing.Size(305, 22)
        Me.cboPRENCAPR.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(19, 167)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 20)
        Me.Label8.TabIndex = 89
        Me.Label8.Text = "Calidad propietario"
        '
        'txtPRENNUDO
        '
        Me.txtPRENNUDO.AccessibleDescription = "Nro. documento"
        Me.txtPRENNUDO.BackColor = System.Drawing.SystemColors.Window
        Me.txtPRENNUDO.Enabled = False
        Me.txtPRENNUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRENNUDO.Location = New System.Drawing.Point(137, 213)
        Me.txtPRENNUDO.MaxLength = 14
        Me.txtPRENNUDO.Name = "txtPRENNUDO"
        Me.txtPRENNUDO.Size = New System.Drawing.Size(421, 20)
        Me.txtPRENNUDO.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 213)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 87
        Me.Label5.Text = "Nro. Documento"
        '
        'txtPRENDESC
        '
        Me.txtPRENDESC.AccessibleDescription = "Descripción"
        Me.txtPRENDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtPRENDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRENDESC.Location = New System.Drawing.Point(137, 236)
        Me.txtPRENDESC.MaxLength = 100
        Me.txtPRENDESC.Name = "txtPRENDESC"
        Me.txtPRENDESC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPRENDESC.Size = New System.Drawing.Size(421, 20)
        Me.txtPRENDESC.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 236)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Descripción"
        '
        'lblPRENCONC
        '
        Me.lblPRENCONC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPRENCONC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPRENCONC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPRENCONC.ForeColor = System.Drawing.Color.Black
        Me.lblPRENCONC.Location = New System.Drawing.Point(448, 121)
        Me.lblPRENCONC.Name = "lblPRENCONC"
        Me.lblPRENCONC.Size = New System.Drawing.Size(110, 20)
        Me.lblPRENCONC.TabIndex = 81
        '
        'cboPRENCONC
        '
        Me.cboPRENCONC.AccessibleDescription = "Concepto"
        Me.cboPRENCONC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPRENCONC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPRENCONC.Enabled = False
        Me.cboPRENCONC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPRENCONC.FormattingEnabled = True
        Me.cboPRENCONC.Location = New System.Drawing.Point(137, 119)
        Me.cboPRENCONC.Name = "cboPRENCONC"
        Me.cboPRENCONC.Size = New System.Drawing.Size(305, 22)
        Me.cboPRENCONC.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Concepto"
        '
        'lblPRENTIIM
        '
        Me.lblPRENTIIM.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPRENTIIM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPRENTIIM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPRENTIIM.ForeColor = System.Drawing.Color.Black
        Me.lblPRENTIIM.Location = New System.Drawing.Point(448, 97)
        Me.lblPRENTIIM.Name = "lblPRENTIIM"
        Me.lblPRENTIIM.Size = New System.Drawing.Size(110, 20)
        Me.lblPRENTIIM.TabIndex = 78
        '
        'cboPRENTIIM
        '
        Me.cboPRENTIIM.AccessibleDescription = "Tipo de impuesto"
        Me.cboPRENTIIM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPRENTIIM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPRENTIIM.Enabled = False
        Me.cboPRENTIIM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPRENTIIM.FormattingEnabled = True
        Me.cboPRENTIIM.Location = New System.Drawing.Point(137, 95)
        Me.cboPRENTIIM.Name = "cboPRENTIIM"
        Me.cboPRENTIIM.Size = New System.Drawing.Size(305, 22)
        Me.cboPRENTIIM.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(19, 97)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 20)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "Tipo de impuesto"
        '
        'lblPRENTIDO
        '
        Me.lblPRENTIDO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPRENTIDO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPRENTIDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPRENTIDO.ForeColor = System.Drawing.Color.Black
        Me.lblPRENTIDO.Location = New System.Drawing.Point(448, 144)
        Me.lblPRENTIDO.Name = "lblPRENTIDO"
        Me.lblPRENTIDO.Size = New System.Drawing.Size(110, 20)
        Me.lblPRENTIDO.TabIndex = 62
        '
        'cboPRENTIDO
        '
        Me.cboPRENTIDO.AccessibleDescription = "Tipo documento"
        Me.cboPRENTIDO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPRENTIDO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPRENTIDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPRENTIDO.FormattingEnabled = True
        Me.cboPRENTIDO.Location = New System.Drawing.Point(137, 142)
        Me.cboPRENTIDO.Name = "cboPRENTIDO"
        Me.cboPRENTIDO.Size = New System.Drawing.Size(305, 22)
        Me.cboPRENTIDO.TabIndex = 6
        '
        'lblPRENCLSE
        '
        Me.lblPRENCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPRENCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPRENCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPRENCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblPRENCLSE.Location = New System.Drawing.Point(448, 74)
        Me.lblPRENCLSE.Name = "lblPRENCLSE"
        Me.lblPRENCLSE.Size = New System.Drawing.Size(110, 20)
        Me.lblPRENCLSE.TabIndex = 57
        '
        'cboPRENCLSE
        '
        Me.cboPRENCLSE.AccessibleDescription = "Clase o sector"
        Me.cboPRENCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPRENCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPRENCLSE.Enabled = False
        Me.cboPRENCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPRENCLSE.FormattingEnabled = True
        Me.cboPRENCLSE.Location = New System.Drawing.Point(137, 72)
        Me.cboPRENCLSE.Name = "cboPRENCLSE"
        Me.cboPRENCLSE.Size = New System.Drawing.Size(305, 22)
        Me.cboPRENCLSE.TabIndex = 3
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
        Me.Label3.Location = New System.Drawing.Point(19, 259)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'lblPRENDEPA
        '
        Me.lblPRENDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPRENDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPRENDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPRENDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblPRENDEPA.Location = New System.Drawing.Point(448, 28)
        Me.lblPRENDEPA.Name = "lblPRENDEPA"
        Me.lblPRENDEPA.Size = New System.Drawing.Size(110, 20)
        Me.lblPRENDEPA.TabIndex = 52
        '
        'cboPRENDEPA
        '
        Me.cboPRENDEPA.AccessibleDescription = "Departamento"
        Me.cboPRENDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPRENDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPRENDEPA.Enabled = False
        Me.cboPRENDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPRENDEPA.FormattingEnabled = True
        Me.cboPRENDEPA.Location = New System.Drawing.Point(137, 26)
        Me.cboPRENDEPA.Name = "cboPRENDEPA"
        Me.cboPRENDEPA.Size = New System.Drawing.Size(305, 22)
        Me.cboPRENDEPA.TabIndex = 1
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
        'lblPRENMUNI
        '
        Me.lblPRENMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPRENMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPRENMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPRENMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblPRENMUNI.Location = New System.Drawing.Point(448, 51)
        Me.lblPRENMUNI.Name = "lblPRENMUNI"
        Me.lblPRENMUNI.Size = New System.Drawing.Size(110, 20)
        Me.lblPRENMUNI.TabIndex = 50
        '
        'cboPRENMUNI
        '
        Me.cboPRENMUNI.AccessibleDescription = "Municipio"
        Me.cboPRENMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPRENMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPRENMUNI.Enabled = False
        Me.cboPRENMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPRENMUNI.FormattingEnabled = True
        Me.cboPRENMUNI.Location = New System.Drawing.Point(137, 49)
        Me.cboPRENMUNI.Name = "cboPRENMUNI"
        Me.cboPRENMUNI.Size = New System.Drawing.Size(305, 22)
        Me.cboPRENMUNI.TabIndex = 2
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
        'cboPRENESTA
        '
        Me.cboPRENESTA.AccessibleDescription = "Estado"
        Me.cboPRENESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPRENESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPRENESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPRENESTA.FormattingEnabled = True
        Me.cboPRENESTA.Location = New System.Drawing.Point(137, 258)
        Me.cboPRENESTA.Name = "cboPRENESTA"
        Me.cboPRENESTA.Size = New System.Drawing.Size(305, 22)
        Me.cboPRENESTA.TabIndex = 11
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(19, 144)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(112, 20)
        Me.lblCodigo.TabIndex = 37
        Me.lblCodigo.Text = "Tipo documento"
        '
        'frm_modificar_PREDEXNI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 403)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraPREDEXEN)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(615, 439)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(615, 439)
        Me.Name = "frm_modificar_PREDEXNI"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraPREDEXEN.ResumeLayout(False)
        Me.fraPREDEXEN.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraPREDEXEN As System.Windows.Forms.GroupBox
    Friend WithEvents lblPRENSEXO As System.Windows.Forms.Label
    Friend WithEvents cboPRENSEXO As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblPRENCAPR As System.Windows.Forms.Label
    Friend WithEvents cboPRENCAPR As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPRENNUDO As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPRENDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPRENCONC As System.Windows.Forms.Label
    Friend WithEvents cboPRENCONC As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPRENTIIM As System.Windows.Forms.Label
    Friend WithEvents cboPRENTIIM As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblPRENTIDO As System.Windows.Forms.Label
    Friend WithEvents cboPRENTIDO As System.Windows.Forms.ComboBox
    Friend WithEvents lblPRENCLSE As System.Windows.Forms.Label
    Friend WithEvents cboPRENCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPRENDEPA As System.Windows.Forms.Label
    Friend WithEvents cboPRENDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblPRENMUNI As System.Windows.Forms.Label
    Friend WithEvents cboPRENMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cboPRENESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
End Class
