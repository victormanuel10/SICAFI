<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_TARIZOEC
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
        Me.fraZONAECONOMICA = New System.Windows.Forms.GroupBox()
        Me.txtTAZETALO = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTAZEPORC = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboTAZESIGN = New System.Windows.Forms.ComboBox()
        Me.lblTAZEVIGE = New System.Windows.Forms.Label()
        Me.cboTAZEVIGE = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTAZETA06 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTAZETA05 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTAZETA04 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTAZETA03 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTAZETA02 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTAZEZOAP = New System.Windows.Forms.Label()
        Me.cboTAZEZOAP = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTAZEZOEC = New System.Windows.Forms.Label()
        Me.cboTAZEZOEC = New System.Windows.Forms.ComboBox()
        Me.txtTAZETA01 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTAZECLSE = New System.Windows.Forms.Label()
        Me.cboTAZECLSE = New System.Windows.Forms.ComboBox()
        Me.lblClaseosector = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTAZEDEPA = New System.Windows.Forms.Label()
        Me.cboTAZEDEPA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTAZEMUNI = New System.Windows.Forms.Label()
        Me.cboTAZEMUNI = New System.Windows.Forms.ComboBox()
        Me.lblMUNICIPIO = New System.Windows.Forms.Label()
        Me.cboTAZEESTA = New System.Windows.Forms.ComboBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraZONAECONOMICA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 427)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 52)
        Me.GroupBox1.TabIndex = 34
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
        Me.cmdSALIR.TabIndex = 14
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
        Me.cmdGUARDAR.TabIndex = 13
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 493)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(598, 25)
        Me.strBARRESTA.TabIndex = 33
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
        'fraZONAECONOMICA
        '
        Me.fraZONAECONOMICA.BackColor = System.Drawing.SystemColors.Control
        Me.fraZONAECONOMICA.Controls.Add(Me.txtTAZETALO)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label13)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtTAZEPORC)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label12)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label10)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTAZESIGN)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblTAZEVIGE)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTAZEVIGE)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label11)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtTAZETA06)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label9)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtTAZETA05)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label8)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtTAZETA04)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label7)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtTAZETA03)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label6)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtTAZETA02)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label1)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblTAZEZOAP)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTAZEZOAP)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label5)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblTAZEZOEC)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTAZEZOEC)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtTAZETA01)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label2)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblTAZECLSE)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTAZECLSE)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblClaseosector)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label3)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblTAZEDEPA)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTAZEDEPA)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label4)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblTAZEMUNI)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTAZEMUNI)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblMUNICIPIO)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTAZEESTA)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblCodigo)
        Me.fraZONAECONOMICA.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraZONAECONOMICA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraZONAECONOMICA.Location = New System.Drawing.Point(12, 10)
        Me.fraZONAECONOMICA.Name = "fraZONAECONOMICA"
        Me.fraZONAECONOMICA.Size = New System.Drawing.Size(572, 411)
        Me.fraZONAECONOMICA.TabIndex = 32
        Me.fraZONAECONOMICA.TabStop = False
        Me.fraZONAECONOMICA.Text = "INSERTA TARIFA POR ZONA ECONÓMICA"
        '
        'txtTAZETALO
        '
        Me.txtTAZETALO.AccessibleDescription = "Tarifa lote"
        Me.txtTAZETALO.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZETALO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZETALO.Location = New System.Drawing.Point(137, 373)
        Me.txtTAZETALO.MaxLength = 5
        Me.txtTAZETALO.Name = "txtTAZETALO"
        Me.txtTAZETALO.Size = New System.Drawing.Size(112, 20)
        Me.txtTAZETALO.TabIndex = 16
        Me.txtTAZETALO.Text = "0.00"
        Me.txtTAZETALO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(19, 373)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 20)
        Me.Label13.TabIndex = 83
        Me.Label13.Text = "Talifa lote"
        '
        'txtTAZEPORC
        '
        Me.txtTAZEPORC.AccessibleDescription = "Porcentaje"
        Me.txtTAZEPORC.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZEPORC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZEPORC.Location = New System.Drawing.Point(137, 350)
        Me.txtTAZEPORC.MaxLength = 5
        Me.txtTAZEPORC.Name = "txtTAZEPORC"
        Me.txtTAZEPORC.Size = New System.Drawing.Size(112, 20)
        Me.txtTAZEPORC.TabIndex = 15
        Me.txtTAZEPORC.Text = "0.00"
        Me.txtTAZEPORC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(19, 350)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 20)
        Me.Label12.TabIndex = 81
        Me.Label12.Text = "Porcentaje"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(19, 327)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 20)
        Me.Label10.TabIndex = 80
        Me.Label10.Text = "Signo (+,-,*)"
        '
        'cboTAZESIGN
        '
        Me.cboTAZESIGN.AccessibleDescription = "Signo"
        Me.cboTAZESIGN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAZESIGN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAZESIGN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAZESIGN.FormattingEnabled = True
        Me.cboTAZESIGN.Items.AddRange(New Object() {"+", "-", "*"})
        Me.cboTAZESIGN.Location = New System.Drawing.Point(137, 327)
        Me.cboTAZESIGN.Name = "cboTAZESIGN"
        Me.cboTAZESIGN.Size = New System.Drawing.Size(112, 22)
        Me.cboTAZESIGN.TabIndex = 14
        '
        'lblTAZEVIGE
        '
        Me.lblTAZEVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAZEVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAZEVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAZEVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblTAZEVIGE.Location = New System.Drawing.Point(445, 97)
        Me.lblTAZEVIGE.Name = "lblTAZEVIGE"
        Me.lblTAZEVIGE.Size = New System.Drawing.Size(113, 20)
        Me.lblTAZEVIGE.TabIndex = 78
        '
        'cboTAZEVIGE
        '
        Me.cboTAZEVIGE.AccessibleDescription = "Vigencia"
        Me.cboTAZEVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAZEVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAZEVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAZEVIGE.FormattingEnabled = True
        Me.cboTAZEVIGE.Location = New System.Drawing.Point(137, 95)
        Me.cboTAZEVIGE.Name = "cboTAZEVIGE"
        Me.cboTAZEVIGE.Size = New System.Drawing.Size(302, 22)
        Me.cboTAZEVIGE.TabIndex = 4
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
        Me.Label11.Text = "Vigencia"
        '
        'txtTAZETA06
        '
        Me.txtTAZETA06.AccessibleDescription = "Tarifa 06"
        Me.txtTAZETA06.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZETA06.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZETA06.Location = New System.Drawing.Point(137, 258)
        Me.txtTAZETA06.MaxLength = 5
        Me.txtTAZETA06.Name = "txtTAZETA06"
        Me.txtTAZETA06.Size = New System.Drawing.Size(112, 20)
        Me.txtTAZETA06.TabIndex = 11
        Me.txtTAZETA06.Text = "0.00"
        Me.txtTAZETA06.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(19, 258)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 20)
        Me.Label9.TabIndex = 75
        Me.Label9.Text = "6. Alto 85 a 100"
        '
        'txtTAZETA05
        '
        Me.txtTAZETA05.AccessibleDescription = "Tarifa 05"
        Me.txtTAZETA05.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZETA05.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZETA05.Location = New System.Drawing.Point(137, 235)
        Me.txtTAZETA05.MaxLength = 5
        Me.txtTAZETA05.Name = "txtTAZETA05"
        Me.txtTAZETA05.Size = New System.Drawing.Size(112, 20)
        Me.txtTAZETA05.TabIndex = 10
        Me.txtTAZETA05.Text = "0.00"
        Me.txtTAZETA05.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(19, 235)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 20)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "5. Med-Alto 65 a 84"
        '
        'txtTAZETA04
        '
        Me.txtTAZETA04.AccessibleDescription = "Tarifa 04"
        Me.txtTAZETA04.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZETA04.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZETA04.Location = New System.Drawing.Point(137, 212)
        Me.txtTAZETA04.MaxLength = 5
        Me.txtTAZETA04.Name = "txtTAZETA04"
        Me.txtTAZETA04.Size = New System.Drawing.Size(112, 20)
        Me.txtTAZETA04.TabIndex = 9
        Me.txtTAZETA04.Text = "0.00"
        Me.txtTAZETA04.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(19, 212)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 20)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "4. Medio 47 a 64"
        '
        'txtTAZETA03
        '
        Me.txtTAZETA03.AccessibleDescription = "Tarifa 03"
        Me.txtTAZETA03.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZETA03.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZETA03.Location = New System.Drawing.Point(137, 189)
        Me.txtTAZETA03.MaxLength = 5
        Me.txtTAZETA03.Name = "txtTAZETA03"
        Me.txtTAZETA03.Size = New System.Drawing.Size(112, 20)
        Me.txtTAZETA03.TabIndex = 8
        Me.txtTAZETA03.Text = "0.00"
        Me.txtTAZETA03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(19, 189)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "3. Med-Baj 29 a 46"
        '
        'txtTAZETA02
        '
        Me.txtTAZETA02.AccessibleDescription = "Tarifa 02"
        Me.txtTAZETA02.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZETA02.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZETA02.Location = New System.Drawing.Point(137, 166)
        Me.txtTAZETA02.MaxLength = 5
        Me.txtTAZETA02.Name = "txtTAZETA02"
        Me.txtTAZETA02.Size = New System.Drawing.Size(112, 20)
        Me.txtTAZETA02.TabIndex = 7
        Me.txtTAZETA02.Text = "0.00"
        Me.txtTAZETA02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 166)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "2. Bajo 11 a 28"
        '
        'lblTAZEZOAP
        '
        Me.lblTAZEZOAP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAZEZOAP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAZEZOAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAZEZOAP.ForeColor = System.Drawing.Color.Black
        Me.lblTAZEZOAP.Location = New System.Drawing.Point(445, 283)
        Me.lblTAZEZOAP.Name = "lblTAZEZOAP"
        Me.lblTAZEZOAP.Size = New System.Drawing.Size(113, 20)
        Me.lblTAZEZOAP.TabIndex = 65
        '
        'cboTAZEZOAP
        '
        Me.cboTAZEZOAP.AccessibleDescription = "Zona aplicada"
        Me.cboTAZEZOAP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAZEZOAP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAZEZOAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAZEZOAP.FormattingEnabled = True
        Me.cboTAZEZOAP.Location = New System.Drawing.Point(137, 280)
        Me.cboTAZEZOAP.Name = "cboTAZEZOAP"
        Me.cboTAZEZOAP.Size = New System.Drawing.Size(302, 22)
        Me.cboTAZEZOAP.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 281)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Zona aplicada"
        '
        'lblTAZEZOEC
        '
        Me.lblTAZEZOEC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAZEZOEC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAZEZOEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAZEZOEC.ForeColor = System.Drawing.Color.Black
        Me.lblTAZEZOEC.Location = New System.Drawing.Point(445, 120)
        Me.lblTAZEZOEC.Name = "lblTAZEZOEC"
        Me.lblTAZEZOEC.Size = New System.Drawing.Size(113, 20)
        Me.lblTAZEZOEC.TabIndex = 62
        '
        'cboTAZEZOEC
        '
        Me.cboTAZEZOEC.AccessibleDescription = "Zona económica"
        Me.cboTAZEZOEC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAZEZOEC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAZEZOEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAZEZOEC.FormattingEnabled = True
        Me.cboTAZEZOEC.Location = New System.Drawing.Point(137, 118)
        Me.cboTAZEZOEC.Name = "cboTAZEZOEC"
        Me.cboTAZEZOEC.Size = New System.Drawing.Size(302, 22)
        Me.cboTAZEZOEC.TabIndex = 5
        '
        'txtTAZETA01
        '
        Me.txtTAZETA01.AccessibleDescription = "Tarifa 01"
        Me.txtTAZETA01.BackColor = System.Drawing.SystemColors.Window
        Me.txtTAZETA01.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTAZETA01.Location = New System.Drawing.Point(137, 143)
        Me.txtTAZETA01.MaxLength = 5
        Me.txtTAZETA01.Name = "txtTAZETA01"
        Me.txtTAZETA01.Size = New System.Drawing.Size(112, 20)
        Me.txtTAZETA01.TabIndex = 6
        Me.txtTAZETA01.Text = "0.00"
        Me.txtTAZETA01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "1. Bajo-Bajo 0 a 10"
        '
        'lblTAZECLSE
        '
        Me.lblTAZECLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAZECLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAZECLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAZECLSE.ForeColor = System.Drawing.Color.Black
        Me.lblTAZECLSE.Location = New System.Drawing.Point(445, 74)
        Me.lblTAZECLSE.Name = "lblTAZECLSE"
        Me.lblTAZECLSE.Size = New System.Drawing.Size(113, 20)
        Me.lblTAZECLSE.TabIndex = 57
        '
        'cboTAZECLSE
        '
        Me.cboTAZECLSE.AccessibleDescription = "Clase o sector"
        Me.cboTAZECLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAZECLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAZECLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAZECLSE.FormattingEnabled = True
        Me.cboTAZECLSE.Location = New System.Drawing.Point(137, 72)
        Me.cboTAZECLSE.Name = "cboTAZECLSE"
        Me.cboTAZECLSE.Size = New System.Drawing.Size(302, 22)
        Me.cboTAZECLSE.TabIndex = 3
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
        Me.Label3.Location = New System.Drawing.Point(19, 304)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'lblTAZEDEPA
        '
        Me.lblTAZEDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAZEDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAZEDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAZEDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblTAZEDEPA.Location = New System.Drawing.Point(445, 28)
        Me.lblTAZEDEPA.Name = "lblTAZEDEPA"
        Me.lblTAZEDEPA.Size = New System.Drawing.Size(113, 20)
        Me.lblTAZEDEPA.TabIndex = 52
        '
        'cboTAZEDEPA
        '
        Me.cboTAZEDEPA.AccessibleDescription = "Departamento"
        Me.cboTAZEDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAZEDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAZEDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAZEDEPA.FormattingEnabled = True
        Me.cboTAZEDEPA.Location = New System.Drawing.Point(137, 26)
        Me.cboTAZEDEPA.Name = "cboTAZEDEPA"
        Me.cboTAZEDEPA.Size = New System.Drawing.Size(302, 22)
        Me.cboTAZEDEPA.TabIndex = 1
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
        'lblTAZEMUNI
        '
        Me.lblTAZEMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAZEMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAZEMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAZEMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblTAZEMUNI.Location = New System.Drawing.Point(445, 51)
        Me.lblTAZEMUNI.Name = "lblTAZEMUNI"
        Me.lblTAZEMUNI.Size = New System.Drawing.Size(113, 20)
        Me.lblTAZEMUNI.TabIndex = 50
        '
        'cboTAZEMUNI
        '
        Me.cboTAZEMUNI.AccessibleDescription = "Municipio"
        Me.cboTAZEMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAZEMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAZEMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAZEMUNI.FormattingEnabled = True
        Me.cboTAZEMUNI.Location = New System.Drawing.Point(137, 49)
        Me.cboTAZEMUNI.Name = "cboTAZEMUNI"
        Me.cboTAZEMUNI.Size = New System.Drawing.Size(302, 22)
        Me.cboTAZEMUNI.TabIndex = 2
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
        'cboTAZEESTA
        '
        Me.cboTAZEESTA.AccessibleDescription = "Estado"
        Me.cboTAZEESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTAZEESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTAZEESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTAZEESTA.FormattingEnabled = True
        Me.cboTAZEESTA.Location = New System.Drawing.Point(137, 304)
        Me.cboTAZEESTA.Name = "cboTAZEESTA"
        Me.cboTAZEESTA.Size = New System.Drawing.Size(302, 22)
        Me.cboTAZEESTA.TabIndex = 13
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(19, 120)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(112, 20)
        Me.lblCodigo.TabIndex = 37
        Me.lblCodigo.Text = "Zona económica"
        '
        'frm_insertar_TARIZOEC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 518)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraZONAECONOMICA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(614, 554)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(614, 554)
        Me.Name = "frm_insertar_TARIZOEC"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraZONAECONOMICA.ResumeLayout(False)
        Me.fraZONAECONOMICA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraZONAECONOMICA As System.Windows.Forms.GroupBox
    Friend WithEvents lblTAZEZOAP As System.Windows.Forms.Label
    Friend WithEvents cboTAZEZOAP As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTAZEZOEC As System.Windows.Forms.Label
    Friend WithEvents cboTAZEZOEC As System.Windows.Forms.ComboBox
    Friend WithEvents txtTAZETA01 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTAZECLSE As System.Windows.Forms.Label
    Friend WithEvents cboTAZECLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTAZEDEPA As System.Windows.Forms.Label
    Friend WithEvents cboTAZEDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTAZEMUNI As System.Windows.Forms.Label
    Friend WithEvents cboTAZEMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cboTAZEESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtTAZETA06 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTAZETA05 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTAZETA04 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTAZETA03 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTAZETA02 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTAZEVIGE As System.Windows.Forms.Label
    Friend WithEvents cboTAZEVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboTAZESIGN As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTAZEPORC As System.Windows.Forms.TextBox
    Friend WithEvents txtTAZETALO As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
