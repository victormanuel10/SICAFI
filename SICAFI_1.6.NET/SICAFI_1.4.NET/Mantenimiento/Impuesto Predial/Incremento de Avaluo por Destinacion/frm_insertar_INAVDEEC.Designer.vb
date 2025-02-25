<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_INAVDEEC
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
        Me.lblIADEVIGE = New System.Windows.Forms.Label
        Me.cboIADEVIGE = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblIADEDEEC = New System.Windows.Forms.Label
        Me.cboIADEDEEC = New System.Windows.Forms.ComboBox
        Me.txtIADETARI = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblIADECLSE = New System.Windows.Forms.Label
        Me.cboIADECLSE = New System.Windows.Forms.ComboBox
        Me.lblClaseosector = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblIADEDEPA = New System.Windows.Forms.Label
        Me.cboIADEDEPA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblIADEMUNI = New System.Windows.Forms.Label
        Me.cboIADEMUNI = New System.Windows.Forms.ComboBox
        Me.lblMUNICIPIO = New System.Windows.Forms.Label
        Me.cboIADEESTA = New System.Windows.Forms.ComboBox
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 225)
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
        Me.fraZONAECONOMICA.Controls.Add(Me.lblIADEVIGE)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboIADEVIGE)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label5)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblIADEDEEC)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboIADEDEEC)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtIADETARI)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label2)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblIADECLSE)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboIADECLSE)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblClaseosector)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label3)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblIADEDEPA)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboIADEDEPA)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label4)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblIADEMUNI)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboIADEMUNI)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblMUNICIPIO)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboIADEESTA)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblCodigo)
        Me.fraZONAECONOMICA.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraZONAECONOMICA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraZONAECONOMICA.Location = New System.Drawing.Point(12, 10)
        Me.fraZONAECONOMICA.Name = "fraZONAECONOMICA"
        Me.fraZONAECONOMICA.Size = New System.Drawing.Size(572, 209)
        Me.fraZONAECONOMICA.TabIndex = 32
        Me.fraZONAECONOMICA.TabStop = False
        Me.fraZONAECONOMICA.Text = "INSERTA INCREMENTO DE AVALÚO POR DESTINACIÓN ECONÓMICA"
        '
        'lblIADEVIGE
        '
        Me.lblIADEVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblIADEVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIADEVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIADEVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblIADEVIGE.Location = New System.Drawing.Point(438, 97)
        Me.lblIADEVIGE.Name = "lblIADEVIGE"
        Me.lblIADEVIGE.Size = New System.Drawing.Size(120, 20)
        Me.lblIADEVIGE.TabIndex = 65
        '
        'cboIADEVIGE
        '
        Me.cboIADEVIGE.AccessibleDescription = "Vigencia"
        Me.cboIADEVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboIADEVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIADEVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboIADEVIGE.FormattingEnabled = True
        Me.cboIADEVIGE.Location = New System.Drawing.Point(137, 95)
        Me.cboIADEVIGE.Name = "cboIADEVIGE"
        Me.cboIADEVIGE.Size = New System.Drawing.Size(295, 22)
        Me.cboIADEVIGE.TabIndex = 4
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
        'lblIADEDEEC
        '
        Me.lblIADEDEEC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblIADEDEEC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIADEDEEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIADEDEEC.ForeColor = System.Drawing.Color.Black
        Me.lblIADEDEEC.Location = New System.Drawing.Point(438, 120)
        Me.lblIADEDEEC.Name = "lblIADEDEEC"
        Me.lblIADEDEEC.Size = New System.Drawing.Size(120, 20)
        Me.lblIADEDEEC.TabIndex = 62
        '
        'cboIADEDEEC
        '
        Me.cboIADEDEEC.AccessibleDescription = "Destinación eco."
        Me.cboIADEDEEC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboIADEDEEC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIADEDEEC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboIADEDEEC.FormattingEnabled = True
        Me.cboIADEDEEC.Location = New System.Drawing.Point(137, 118)
        Me.cboIADEDEEC.Name = "cboIADEDEEC"
        Me.cboIADEDEEC.Size = New System.Drawing.Size(295, 22)
        Me.cboIADEDEEC.TabIndex = 5
        '
        'txtIADETARI
        '
        Me.txtIADETARI.AccessibleDescription = "Tarifa"
        Me.txtIADETARI.BackColor = System.Drawing.SystemColors.Window
        Me.txtIADETARI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIADETARI.Location = New System.Drawing.Point(137, 143)
        Me.txtIADETARI.MaxLength = 5
        Me.txtIADETARI.Name = "txtIADETARI"
        Me.txtIADETARI.Size = New System.Drawing.Size(112, 20)
        Me.txtIADETARI.TabIndex = 6
        Me.txtIADETARI.Text = "0.00"
        Me.txtIADETARI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'lblIADECLSE
        '
        Me.lblIADECLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblIADECLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIADECLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIADECLSE.ForeColor = System.Drawing.Color.Black
        Me.lblIADECLSE.Location = New System.Drawing.Point(438, 74)
        Me.lblIADECLSE.Name = "lblIADECLSE"
        Me.lblIADECLSE.Size = New System.Drawing.Size(120, 20)
        Me.lblIADECLSE.TabIndex = 57
        '
        'cboIADECLSE
        '
        Me.cboIADECLSE.AccessibleDescription = "Clase o sector"
        Me.cboIADECLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboIADECLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIADECLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboIADECLSE.FormattingEnabled = True
        Me.cboIADECLSE.Location = New System.Drawing.Point(137, 72)
        Me.cboIADECLSE.Name = "cboIADECLSE"
        Me.cboIADECLSE.Size = New System.Drawing.Size(295, 22)
        Me.cboIADECLSE.TabIndex = 3
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
        'lblIADEDEPA
        '
        Me.lblIADEDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblIADEDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIADEDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIADEDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblIADEDEPA.Location = New System.Drawing.Point(438, 28)
        Me.lblIADEDEPA.Name = "lblIADEDEPA"
        Me.lblIADEDEPA.Size = New System.Drawing.Size(120, 20)
        Me.lblIADEDEPA.TabIndex = 52
        '
        'cboIADEDEPA
        '
        Me.cboIADEDEPA.AccessibleDescription = "Departamento"
        Me.cboIADEDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboIADEDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIADEDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboIADEDEPA.FormattingEnabled = True
        Me.cboIADEDEPA.Location = New System.Drawing.Point(137, 26)
        Me.cboIADEDEPA.Name = "cboIADEDEPA"
        Me.cboIADEDEPA.Size = New System.Drawing.Size(295, 22)
        Me.cboIADEDEPA.TabIndex = 1
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
        'lblIADEMUNI
        '
        Me.lblIADEMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblIADEMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIADEMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIADEMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblIADEMUNI.Location = New System.Drawing.Point(438, 51)
        Me.lblIADEMUNI.Name = "lblIADEMUNI"
        Me.lblIADEMUNI.Size = New System.Drawing.Size(120, 20)
        Me.lblIADEMUNI.TabIndex = 50
        '
        'cboIADEMUNI
        '
        Me.cboIADEMUNI.AccessibleDescription = "Municipio"
        Me.cboIADEMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboIADEMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIADEMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboIADEMUNI.FormattingEnabled = True
        Me.cboIADEMUNI.Location = New System.Drawing.Point(137, 49)
        Me.cboIADEMUNI.Name = "cboIADEMUNI"
        Me.cboIADEMUNI.Size = New System.Drawing.Size(295, 22)
        Me.cboIADEMUNI.TabIndex = 2
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
        'cboIADEESTA
        '
        Me.cboIADEESTA.AccessibleDescription = "Estado"
        Me.cboIADEESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboIADEESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIADEESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboIADEESTA.FormattingEnabled = True
        Me.cboIADEESTA.Location = New System.Drawing.Point(137, 166)
        Me.cboIADEESTA.Name = "cboIADEESTA"
        Me.cboIADEESTA.Size = New System.Drawing.Size(295, 22)
        Me.cboIADEESTA.TabIndex = 7
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
        'frm_insertar_INAVDEEC
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
        Me.Name = "frm_insertar_INAVDEEC"
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
    Friend WithEvents lblIADEVIGE As System.Windows.Forms.Label
    Friend WithEvents cboIADEVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblIADEDEEC As System.Windows.Forms.Label
    Friend WithEvents cboIADEDEEC As System.Windows.Forms.ComboBox
    Friend WithEvents txtIADETARI As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblIADECLSE As System.Windows.Forms.Label
    Friend WithEvents cboIADECLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblIADEDEPA As System.Windows.Forms.Label
    Friend WithEvents cboIADEDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblIADEMUNI As System.Windows.Forms.Label
    Friend WithEvents cboIADEMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cboIADEESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
End Class
