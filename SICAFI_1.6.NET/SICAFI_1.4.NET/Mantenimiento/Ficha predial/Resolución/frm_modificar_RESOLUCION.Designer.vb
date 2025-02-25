<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_RESOLUCION
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.fraTIPODOCUMENTO = New System.Windows.Forms.GroupBox
        Me.chkRESOPATO = New System.Windows.Forms.CheckBox
        Me.lblRESOVIGE = New System.Windows.Forms.Label
        Me.cboRESOVIGE = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblRESOCLSE = New System.Windows.Forms.Label
        Me.cboRESOCLSE = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblRESOTIRE = New System.Windows.Forms.Label
        Me.cboRESOTIRE = New System.Windows.Forms.ComboBox
        Me.lblClaseosector = New System.Windows.Forms.Label
        Me.lblRESODEPA = New System.Windows.Forms.Label
        Me.cboRESODEPA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblRESOMUNI = New System.Windows.Forms.Label
        Me.cboRESOMUNI = New System.Windows.Forms.ComboBox
        Me.lblMUNICIPIO = New System.Windows.Forms.Label
        Me.cboRESOESTA = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtRESODESC = New System.Windows.Forms.TextBox
        Me.txtRESOCODI = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblCódigo = New System.Windows.Forms.Label
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.cmdGUARDAR = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtRESOLUCION = New System.Windows.Forms.TextBox
        Me.chkRESORESO = New System.Windows.Forms.CheckBox
        Me.cmdACTURESO = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtVIGENCIA = New System.Windows.Forms.TextBox
        Me.chkRESOVIGE = New System.Windows.Forms.CheckBox
        Me.cmdACTUVIGE = New System.Windows.Forms.Button
        Me.strBARRESTA.SuspendLayout()
        Me.fraTIPODOCUMENTO.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 440)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(606, 25)
        Me.strBARRESTA.TabIndex = 31
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
        'fraTIPODOCUMENTO
        '
        Me.fraTIPODOCUMENTO.BackColor = System.Drawing.SystemColors.Control
        Me.fraTIPODOCUMENTO.Controls.Add(Me.chkRESOPATO)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.lblRESOVIGE)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.cboRESOVIGE)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.Label10)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.lblRESOCLSE)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.cboRESOCLSE)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.Label5)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.lblRESOTIRE)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.cboRESOTIRE)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.lblClaseosector)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.lblRESODEPA)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.cboRESODEPA)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.Label4)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.lblRESOMUNI)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.cboRESOMUNI)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.lblMUNICIPIO)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.cboRESOESTA)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.Label2)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.txtRESODESC)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.txtRESOCODI)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.Label1)
        Me.fraTIPODOCUMENTO.Controls.Add(Me.lblCódigo)
        Me.fraTIPODOCUMENTO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraTIPODOCUMENTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraTIPODOCUMENTO.Location = New System.Drawing.Point(12, 6)
        Me.fraTIPODOCUMENTO.Name = "fraTIPODOCUMENTO"
        Me.fraTIPODOCUMENTO.Size = New System.Drawing.Size(580, 225)
        Me.fraTIPODOCUMENTO.TabIndex = 30
        Me.fraTIPODOCUMENTO.TabStop = False
        Me.fraTIPODOCUMENTO.Text = "MODIFICAR RESOLUCIÓN ACTUALIZACIÓN"
        '
        'chkRESOPATO
        '
        Me.chkRESOPATO.AccessibleDescription = "Resolución parcial"
        Me.chkRESOPATO.AutoSize = True
        Me.chkRESOPATO.Checked = True
        Me.chkRESOPATO.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRESOPATO.Location = New System.Drawing.Point(256, 192)
        Me.chkRESOPATO.Name = "chkRESOPATO"
        Me.chkRESOPATO.Size = New System.Drawing.Size(115, 19)
        Me.chkRESOPATO.TabIndex = 9
        Me.chkRESOPATO.Text = "Resolución total"
        Me.chkRESOPATO.UseVisualStyleBackColor = True
        '
        'lblRESOVIGE
        '
        Me.lblRESOVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblRESOVIGE.Location = New System.Drawing.Point(256, 119)
        Me.lblRESOVIGE.Name = "lblRESOVIGE"
        Me.lblRESOVIGE.Size = New System.Drawing.Size(302, 20)
        Me.lblRESOVIGE.TabIndex = 82
        '
        'cboRESOVIGE
        '
        Me.cboRESOVIGE.AccessibleDescription = "Vigencia"
        Me.cboRESOVIGE.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboRESOVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRESOVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRESOVIGE.Enabled = False
        Me.cboRESOVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRESOVIGE.FormattingEnabled = True
        Me.cboRESOVIGE.Location = New System.Drawing.Point(137, 119)
        Me.cboRESOVIGE.Name = "cboRESOVIGE"
        Me.cboRESOVIGE.Size = New System.Drawing.Size(112, 22)
        Me.cboRESOVIGE.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(19, 119)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 20)
        Me.Label10.TabIndex = 81
        Me.Label10.Text = "Vigencia"
        '
        'lblRESOCLSE
        '
        Me.lblRESOCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblRESOCLSE.Location = New System.Drawing.Point(256, 95)
        Me.lblRESOCLSE.Name = "lblRESOCLSE"
        Me.lblRESOCLSE.Size = New System.Drawing.Size(302, 20)
        Me.lblRESOCLSE.TabIndex = 69
        '
        'cboRESOCLSE
        '
        Me.cboRESOCLSE.AccessibleDescription = "Resolución"
        Me.cboRESOCLSE.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboRESOCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRESOCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRESOCLSE.Enabled = False
        Me.cboRESOCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRESOCLSE.FormattingEnabled = True
        Me.cboRESOCLSE.Location = New System.Drawing.Point(137, 94)
        Me.cboRESOCLSE.Name = "cboRESOCLSE"
        Me.cboRESOCLSE.Size = New System.Drawing.Size(112, 22)
        Me.cboRESOCLSE.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "Clase o sector"
        '
        'lblRESOTIRE
        '
        Me.lblRESOTIRE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOTIRE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOTIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOTIRE.ForeColor = System.Drawing.Color.Black
        Me.lblRESOTIRE.Location = New System.Drawing.Point(256, 72)
        Me.lblRESOTIRE.Name = "lblRESOTIRE"
        Me.lblRESOTIRE.Size = New System.Drawing.Size(302, 20)
        Me.lblRESOTIRE.TabIndex = 66
        '
        'cboRESOTIRE
        '
        Me.cboRESOTIRE.AccessibleDescription = "Tipo de resolución"
        Me.cboRESOTIRE.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboRESOTIRE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRESOTIRE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRESOTIRE.Enabled = False
        Me.cboRESOTIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRESOTIRE.FormattingEnabled = True
        Me.cboRESOTIRE.Location = New System.Drawing.Point(137, 70)
        Me.cboRESOTIRE.Name = "cboRESOTIRE"
        Me.cboRESOTIRE.Size = New System.Drawing.Size(112, 22)
        Me.cboRESOTIRE.TabIndex = 3
        '
        'lblClaseosector
        '
        Me.lblClaseosector.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseosector.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseosector.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseosector.ForeColor = System.Drawing.Color.Black
        Me.lblClaseosector.Location = New System.Drawing.Point(19, 72)
        Me.lblClaseosector.Name = "lblClaseosector"
        Me.lblClaseosector.Size = New System.Drawing.Size(112, 20)
        Me.lblClaseosector.TabIndex = 65
        Me.lblClaseosector.Text = "Tipo de resolución"
        '
        'lblRESODEPA
        '
        Me.lblRESODEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESODEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESODEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESODEPA.ForeColor = System.Drawing.Color.Black
        Me.lblRESODEPA.Location = New System.Drawing.Point(256, 26)
        Me.lblRESODEPA.Name = "lblRESODEPA"
        Me.lblRESODEPA.Size = New System.Drawing.Size(302, 20)
        Me.lblRESODEPA.TabIndex = 64
        '
        'cboRESODEPA
        '
        Me.cboRESODEPA.AccessibleDescription = "Departamento"
        Me.cboRESODEPA.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboRESODEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRESODEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRESODEPA.Enabled = False
        Me.cboRESODEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRESODEPA.FormattingEnabled = True
        Me.cboRESODEPA.Location = New System.Drawing.Point(137, 24)
        Me.cboRESODEPA.Name = "cboRESODEPA"
        Me.cboRESODEPA.Size = New System.Drawing.Size(112, 22)
        Me.cboRESODEPA.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 20)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "Departamento"
        '
        'lblRESOMUNI
        '
        Me.lblRESOMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRESOMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRESOMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRESOMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblRESOMUNI.Location = New System.Drawing.Point(256, 49)
        Me.lblRESOMUNI.Name = "lblRESOMUNI"
        Me.lblRESOMUNI.Size = New System.Drawing.Size(302, 20)
        Me.lblRESOMUNI.TabIndex = 62
        '
        'cboRESOMUNI
        '
        Me.cboRESOMUNI.AccessibleDescription = "Municipio"
        Me.cboRESOMUNI.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboRESOMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRESOMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRESOMUNI.Enabled = False
        Me.cboRESOMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRESOMUNI.FormattingEnabled = True
        Me.cboRESOMUNI.Location = New System.Drawing.Point(137, 47)
        Me.cboRESOMUNI.Name = "cboRESOMUNI"
        Me.cboRESOMUNI.Size = New System.Drawing.Size(112, 22)
        Me.cboRESOMUNI.TabIndex = 2
        '
        'lblMUNICIPIO
        '
        Me.lblMUNICIPIO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMUNICIPIO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUNICIPIO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUNICIPIO.ForeColor = System.Drawing.Color.Black
        Me.lblMUNICIPIO.Location = New System.Drawing.Point(19, 49)
        Me.lblMUNICIPIO.Name = "lblMUNICIPIO"
        Me.lblMUNICIPIO.Size = New System.Drawing.Size(112, 20)
        Me.lblMUNICIPIO.TabIndex = 61
        Me.lblMUNICIPIO.Text = "Municipio"
        '
        'cboRESOESTA
        '
        Me.cboRESOESTA.AccessibleDescription = "Estado"
        Me.cboRESOESTA.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboRESOESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRESOESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRESOESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRESOESTA.FormattingEnabled = True
        Me.cboRESOESTA.Location = New System.Drawing.Point(137, 189)
        Me.cboRESOESTA.Name = "cboRESOESTA"
        Me.cboRESOESTA.Size = New System.Drawing.Size(112, 22)
        Me.cboRESOESTA.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 189)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Estado"
        '
        'txtRESODESC
        '
        Me.txtRESODESC.AccessibleDescription = "Descripción"
        Me.txtRESODESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtRESODESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRESODESC.Location = New System.Drawing.Point(137, 166)
        Me.txtRESODESC.MaxLength = 50
        Me.txtRESODESC.Name = "txtRESODESC"
        Me.txtRESODESC.Size = New System.Drawing.Size(421, 20)
        Me.txtRESODESC.TabIndex = 7
        '
        'txtRESOCODI
        '
        Me.txtRESOCODI.AccessibleDescription = "Resolución"
        Me.txtRESOCODI.BackColor = System.Drawing.SystemColors.Window
        Me.txtRESOCODI.Enabled = False
        Me.txtRESOCODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRESOCODI.Location = New System.Drawing.Point(137, 143)
        Me.txtRESOCODI.MaxLength = 7
        Me.txtRESOCODI.Name = "txtRESOCODI"
        Me.txtRESOCODI.Size = New System.Drawing.Size(112, 20)
        Me.txtRESOCODI.TabIndex = 6
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
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Descripción"
        '
        'lblCódigo
        '
        Me.lblCódigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCódigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCódigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCódigo.ForeColor = System.Drawing.Color.Black
        Me.lblCódigo.Location = New System.Drawing.Point(19, 143)
        Me.lblCódigo.Name = "lblCódigo"
        Me.lblCódigo.Size = New System.Drawing.Size(112, 20)
        Me.lblCódigo.TabIndex = 37
        Me.lblCódigo.Text = "Resolución"
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(299, 19)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(192, 19)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 10
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 369)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(580, 60)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtRESOLUCION)
        Me.GroupBox2.Controls.Add(Me.chkRESORESO)
        Me.GroupBox2.Controls.Add(Me.cmdACTURESO)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 237)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(580, 60)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        '
        'txtRESOLUCION
        '
        Me.txtRESOLUCION.AccessibleDescription = "Resolución"
        Me.txtRESOLUCION.BackColor = System.Drawing.SystemColors.Window
        Me.txtRESOLUCION.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRESOLUCION.Location = New System.Drawing.Point(137, 20)
        Me.txtRESOLUCION.MaxLength = 7
        Me.txtRESOLUCION.Name = "txtRESOLUCION"
        Me.txtRESOLUCION.Size = New System.Drawing.Size(112, 20)
        Me.txtRESOLUCION.TabIndex = 12
        Me.txtRESOLUCION.Visible = False
        '
        'chkRESORESO
        '
        Me.chkRESORESO.AutoSize = True
        Me.chkRESORESO.Location = New System.Drawing.Point(19, 20)
        Me.chkRESORESO.Name = "chkRESORESO"
        Me.chkRESORESO.Size = New System.Drawing.Size(115, 17)
        Me.chkRESORESO.TabIndex = 11
        Me.chkRESORESO.Text = "Cambiar resolución"
        Me.chkRESORESO.UseVisualStyleBackColor = True
        '
        'cmdACTURESO
        '
        Me.cmdACTURESO.AccessibleDescription = "Actualizar"
        Me.cmdACTURESO.Image = Global.SICAFI.My.Resources.Resources.icon_edit
        Me.cmdACTURESO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdACTURESO.Location = New System.Drawing.Point(457, 20)
        Me.cmdACTURESO.Name = "cmdACTURESO"
        Me.cmdACTURESO.Size = New System.Drawing.Size(101, 23)
        Me.cmdACTURESO.TabIndex = 10
        Me.cmdACTURESO.Text = "&Actualizar"
        Me.cmdACTURESO.UseVisualStyleBackColor = True
        Me.cmdACTURESO.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtVIGENCIA)
        Me.GroupBox3.Controls.Add(Me.chkRESOVIGE)
        Me.GroupBox3.Controls.Add(Me.cmdACTUVIGE)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 303)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(580, 60)
        Me.GroupBox3.TabIndex = 34
        Me.GroupBox3.TabStop = False
        '
        'txtVIGENCIA
        '
        Me.txtVIGENCIA.AccessibleDescription = "Vigencia"
        Me.txtVIGENCIA.BackColor = System.Drawing.SystemColors.Window
        Me.txtVIGENCIA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVIGENCIA.Location = New System.Drawing.Point(137, 20)
        Me.txtVIGENCIA.MaxLength = 7
        Me.txtVIGENCIA.Name = "txtVIGENCIA"
        Me.txtVIGENCIA.Size = New System.Drawing.Size(112, 20)
        Me.txtVIGENCIA.TabIndex = 12
        Me.txtVIGENCIA.Visible = False
        '
        'chkRESOVIGE
        '
        Me.chkRESOVIGE.AutoSize = True
        Me.chkRESOVIGE.Location = New System.Drawing.Point(19, 20)
        Me.chkRESOVIGE.Name = "chkRESOVIGE"
        Me.chkRESOVIGE.Size = New System.Drawing.Size(107, 17)
        Me.chkRESOVIGE.TabIndex = 11
        Me.chkRESOVIGE.Text = "Cambiar vigencia"
        Me.chkRESOVIGE.UseVisualStyleBackColor = True
        '
        'cmdACTUVIGE
        '
        Me.cmdACTUVIGE.AccessibleDescription = "Actualizar"
        Me.cmdACTUVIGE.Image = Global.SICAFI.My.Resources.Resources.icon_edit
        Me.cmdACTUVIGE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdACTUVIGE.Location = New System.Drawing.Point(457, 20)
        Me.cmdACTUVIGE.Name = "cmdACTUVIGE"
        Me.cmdACTUVIGE.Size = New System.Drawing.Size(101, 23)
        Me.cmdACTUVIGE.TabIndex = 10
        Me.cmdACTUVIGE.Text = "&Actualizar"
        Me.cmdACTUVIGE.UseVisualStyleBackColor = True
        Me.cmdACTUVIGE.Visible = False
        '
        'frm_modificar_RESOLUCION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdSALIR
        Me.ClientSize = New System.Drawing.Size(606, 465)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraTIPODOCUMENTO)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_modificar_RESOLUCION"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraTIPODOCUMENTO.ResumeLayout(False)
        Me.fraTIPODOCUMENTO.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraTIPODOCUMENTO As System.Windows.Forms.GroupBox
    Friend WithEvents lblRESOVIGE As System.Windows.Forms.Label
    Friend WithEvents cboRESOVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblRESOCLSE As System.Windows.Forms.Label
    Friend WithEvents cboRESOCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblRESOTIRE As System.Windows.Forms.Label
    Friend WithEvents cboRESOTIRE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents lblRESODEPA As System.Windows.Forms.Label
    Friend WithEvents cboRESODEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblRESOMUNI As System.Windows.Forms.Label
    Friend WithEvents cboRESOMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents cboRESOESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRESODESC As System.Windows.Forms.TextBox
    Friend WithEvents txtRESOCODI As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCódigo As System.Windows.Forms.Label
    Friend WithEvents chkRESOPATO As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdACTURESO As System.Windows.Forms.Button
    Friend WithEvents txtRESOLUCION As System.Windows.Forms.TextBox
    Friend WithEvents chkRESORESO As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtVIGENCIA As System.Windows.Forms.TextBox
    Friend WithEvents chkRESOVIGE As System.Windows.Forms.CheckBox
    Friend WithEvents cmdACTUVIGE As System.Windows.Forms.Button
End Class
