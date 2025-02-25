<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_TARIDEEC
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
        Me.fraZONAECONOMICA = New System.Windows.Forms.GroupBox
        Me.lblTADEVIGE = New System.Windows.Forms.Label
        Me.cboTADEVIGE = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblTADEDEEC = New System.Windows.Forms.Label
        Me.cboTADEDEEC = New System.Windows.Forms.ComboBox
        Me.txtTADETARI = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblTADECLSE = New System.Windows.Forms.Label
        Me.cboTADECLSE = New System.Windows.Forms.ComboBox
        Me.lblClaseosector = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblTADEDEPA = New System.Windows.Forms.Label
        Me.cboTADEDEPA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblTADEMUNI = New System.Windows.Forms.Label
        Me.cboTADEMUNI = New System.Windows.Forms.ComboBox
        Me.lblMUNICIPIO = New System.Windows.Forms.Label
        Me.cboTADEESTA = New System.Windows.Forms.ComboBox
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraZONAECONOMICA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 227)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 52)
        Me.GroupBox1.TabIndex = 31
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
        Me.cmdSALIR.TabIndex = 9
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
        Me.cmdGUARDAR.TabIndex = 8
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 294)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(598, 25)
        Me.strBARRESTA.TabIndex = 30
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
        Me.fraZONAECONOMICA.Controls.Add(Me.lblTADEVIGE)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTADEVIGE)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label5)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblTADEDEEC)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTADEDEEC)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtTADETARI)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label2)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblTADECLSE)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTADECLSE)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblClaseosector)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label3)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblTADEDEPA)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTADEDEPA)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label4)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblTADEMUNI)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTADEMUNI)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblMUNICIPIO)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboTADEESTA)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblCodigo)
        Me.fraZONAECONOMICA.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraZONAECONOMICA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraZONAECONOMICA.Location = New System.Drawing.Point(12, 12)
        Me.fraZONAECONOMICA.Name = "fraZONAECONOMICA"
        Me.fraZONAECONOMICA.Size = New System.Drawing.Size(572, 209)
        Me.fraZONAECONOMICA.TabIndex = 29
        Me.fraZONAECONOMICA.TabStop = False
        Me.fraZONAECONOMICA.Text = "INSERTA TARIFA POR DESTINACIÓN ECONÓMICA"
        '
        'lblTADEVIGE
        '
        Me.lblTADEVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTADEVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTADEVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTADEVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblTADEVIGE.Location = New System.Drawing.Point(438, 97)
        Me.lblTADEVIGE.Name = "lblTADEVIGE"
        Me.lblTADEVIGE.Size = New System.Drawing.Size(120, 20)
        Me.lblTADEVIGE.TabIndex = 65
        '
        'cboTADEVIGE
        '
        Me.cboTADEVIGE.AccessibleDescription = "Vigencia"
        Me.cboTADEVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTADEVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTADEVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTADEVIGE.FormattingEnabled = True
        Me.cboTADEVIGE.Location = New System.Drawing.Point(137, 95)
        Me.cboTADEVIGE.Name = "cboTADEVIGE"
        Me.cboTADEVIGE.Size = New System.Drawing.Size(295, 22)
        Me.cboTADEVIGE.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Vigencia"
        '
        'lblTADEDEEC
        '
        Me.lblTADEDEEC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTADEDEEC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTADEDEEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTADEDEEC.ForeColor = System.Drawing.Color.Black
        Me.lblTADEDEEC.Location = New System.Drawing.Point(438, 120)
        Me.lblTADEDEEC.Name = "lblTADEDEEC"
        Me.lblTADEDEEC.Size = New System.Drawing.Size(120, 20)
        Me.lblTADEDEEC.TabIndex = 62
        '
        'cboTADEDEEC
        '
        Me.cboTADEDEEC.AccessibleDescription = "Destinación eco."
        Me.cboTADEDEEC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTADEDEEC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTADEDEEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTADEDEEC.FormattingEnabled = True
        Me.cboTADEDEEC.Location = New System.Drawing.Point(137, 118)
        Me.cboTADEDEEC.Name = "cboTADEDEEC"
        Me.cboTADEDEEC.Size = New System.Drawing.Size(295, 22)
        Me.cboTADEDEEC.TabIndex = 5
        '
        'txtTADETARI
        '
        Me.txtTADETARI.AccessibleDescription = "Tarifa"
        Me.txtTADETARI.BackColor = System.Drawing.SystemColors.Window
        Me.txtTADETARI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTADETARI.Location = New System.Drawing.Point(137, 143)
        Me.txtTADETARI.MaxLength = 5
        Me.txtTADETARI.Name = "txtTADETARI"
        Me.txtTADETARI.Size = New System.Drawing.Size(112, 20)
        Me.txtTADETARI.TabIndex = 6
        Me.txtTADETARI.Text = "0.00"
        Me.txtTADETARI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.Label2.Text = "Tarifa"
        '
        'lblTADECLSE
        '
        Me.lblTADECLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTADECLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTADECLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTADECLSE.ForeColor = System.Drawing.Color.Black
        Me.lblTADECLSE.Location = New System.Drawing.Point(438, 74)
        Me.lblTADECLSE.Name = "lblTADECLSE"
        Me.lblTADECLSE.Size = New System.Drawing.Size(120, 20)
        Me.lblTADECLSE.TabIndex = 57
        '
        'cboTADECLSE
        '
        Me.cboTADECLSE.AccessibleDescription = "Clase o sector"
        Me.cboTADECLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTADECLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTADECLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTADECLSE.FormattingEnabled = True
        Me.cboTADECLSE.Location = New System.Drawing.Point(137, 72)
        Me.cboTADECLSE.Name = "cboTADECLSE"
        Me.cboTADECLSE.Size = New System.Drawing.Size(295, 22)
        Me.cboTADECLSE.TabIndex = 3
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
        Me.Label3.Location = New System.Drawing.Point(19, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'lblTADEDEPA
        '
        Me.lblTADEDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTADEDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTADEDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTADEDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblTADEDEPA.Location = New System.Drawing.Point(438, 28)
        Me.lblTADEDEPA.Name = "lblTADEDEPA"
        Me.lblTADEDEPA.Size = New System.Drawing.Size(120, 20)
        Me.lblTADEDEPA.TabIndex = 52
        '
        'cboTADEDEPA
        '
        Me.cboTADEDEPA.AccessibleDescription = "Departamento"
        Me.cboTADEDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTADEDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTADEDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTADEDEPA.FormattingEnabled = True
        Me.cboTADEDEPA.Location = New System.Drawing.Point(137, 26)
        Me.cboTADEDEPA.Name = "cboTADEDEPA"
        Me.cboTADEDEPA.Size = New System.Drawing.Size(295, 22)
        Me.cboTADEDEPA.TabIndex = 1
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
        'lblTADEMUNI
        '
        Me.lblTADEMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTADEMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTADEMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTADEMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblTADEMUNI.Location = New System.Drawing.Point(438, 51)
        Me.lblTADEMUNI.Name = "lblTADEMUNI"
        Me.lblTADEMUNI.Size = New System.Drawing.Size(120, 20)
        Me.lblTADEMUNI.TabIndex = 50
        '
        'cboTADEMUNI
        '
        Me.cboTADEMUNI.AccessibleDescription = "Municipio"
        Me.cboTADEMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTADEMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTADEMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTADEMUNI.FormattingEnabled = True
        Me.cboTADEMUNI.Location = New System.Drawing.Point(137, 49)
        Me.cboTADEMUNI.Name = "cboTADEMUNI"
        Me.cboTADEMUNI.Size = New System.Drawing.Size(295, 22)
        Me.cboTADEMUNI.TabIndex = 2
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
        'cboTADEESTA
        '
        Me.cboTADEESTA.AccessibleDescription = "Estado"
        Me.cboTADEESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTADEESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTADEESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTADEESTA.FormattingEnabled = True
        Me.cboTADEESTA.Location = New System.Drawing.Point(137, 166)
        Me.cboTADEESTA.Name = "cboTADEESTA"
        Me.cboTADEESTA.Size = New System.Drawing.Size(295, 22)
        Me.cboTADEESTA.TabIndex = 7
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
        Me.lblCodigo.Text = "Destinación Eco."
        '
        'frm_insertar_TARIDEEC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 319)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraZONAECONOMICA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(614, 355)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(614, 355)
        Me.Name = "frm_insertar_TARIDEEC"
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
    Friend WithEvents txtTADETARI As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTADECLSE As System.Windows.Forms.Label
    Friend WithEvents cboTADECLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTADEDEPA As System.Windows.Forms.Label
    Friend WithEvents cboTADEDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTADEMUNI As System.Windows.Forms.Label
    Friend WithEvents cboTADEMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cboTADEESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblTADEDEEC As System.Windows.Forms.Label
    Friend WithEvents cboTADEDEEC As System.Windows.Forms.ComboBox
    Friend WithEvents lblTADEVIGE As System.Windows.Forms.Label
    Friend WithEvents cboTADEVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
