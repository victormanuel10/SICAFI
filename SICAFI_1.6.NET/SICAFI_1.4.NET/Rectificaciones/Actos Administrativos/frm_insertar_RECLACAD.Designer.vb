<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_RECLACAD
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
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.fraINFOUSUA = New System.Windows.Forms.GroupBox()
        Me.lblREAATITR = New System.Windows.Forms.Label()
        Me.cboREAATITR = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtREAANUEM = New System.Windows.Forms.TextBox()
        Me.dtpREAAFEEM = New System.Windows.Forms.DateTimePicker()
        Me.txtREAAFEEM = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtREAANURR = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtREAANURA = New System.Windows.Forms.TextBox()
        Me.lblREAAACAD = New System.Windows.Forms.Label()
        Me.cboREAAACAD = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpREAAFERR = New System.Windows.Forms.DateTimePicker()
        Me.dtpREAAFERA = New System.Windows.Forms.DateTimePicker()
        Me.txtREAAFERR = New System.Windows.Forms.MaskedTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtREAAFERA = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtREAAOBSE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.fraINFOUSUA.SuspendLayout()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 301)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(801, 25)
        Me.strBARRESTA.TabIndex = 355
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
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdSALIR)
        Me.GroupBox4.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 239)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(772, 49)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(404, 15)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(297, 15)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 10
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'fraINFOUSUA
        '
        Me.fraINFOUSUA.Controls.Add(Me.lblREAATITR)
        Me.fraINFOUSUA.Controls.Add(Me.cboREAATITR)
        Me.fraINFOUSUA.Controls.Add(Me.Label10)
        Me.fraINFOUSUA.Controls.Add(Me.Label5)
        Me.fraINFOUSUA.Controls.Add(Me.txtREAANUEM)
        Me.fraINFOUSUA.Controls.Add(Me.dtpREAAFEEM)
        Me.fraINFOUSUA.Controls.Add(Me.txtREAAFEEM)
        Me.fraINFOUSUA.Controls.Add(Me.Label6)
        Me.fraINFOUSUA.Controls.Add(Me.txtREAANURR)
        Me.fraINFOUSUA.Controls.Add(Me.Label3)
        Me.fraINFOUSUA.Controls.Add(Me.Label1)
        Me.fraINFOUSUA.Controls.Add(Me.txtREAANURA)
        Me.fraINFOUSUA.Controls.Add(Me.lblREAAACAD)
        Me.fraINFOUSUA.Controls.Add(Me.cboREAAACAD)
        Me.fraINFOUSUA.Controls.Add(Me.Label4)
        Me.fraINFOUSUA.Controls.Add(Me.dtpREAAFERR)
        Me.fraINFOUSUA.Controls.Add(Me.dtpREAAFERA)
        Me.fraINFOUSUA.Controls.Add(Me.txtREAAFERR)
        Me.fraINFOUSUA.Controls.Add(Me.Label8)
        Me.fraINFOUSUA.Controls.Add(Me.txtREAAFERA)
        Me.fraINFOUSUA.Controls.Add(Me.Label7)
        Me.fraINFOUSUA.Controls.Add(Me.txtREAAOBSE)
        Me.fraINFOUSUA.Controls.Add(Me.Label2)
        Me.fraINFOUSUA.Location = New System.Drawing.Point(12, 12)
        Me.fraINFOUSUA.Name = "fraINFOUSUA"
        Me.fraINFOUSUA.Size = New System.Drawing.Size(771, 221)
        Me.fraINFOUSUA.TabIndex = 1
        Me.fraINFOUSUA.TabStop = False
        Me.fraINFOUSUA.Text = "INSERTAR ACTOS ADMINISTRATIVOS"
        '
        'lblREAATITR
        '
        Me.lblREAATITR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREAATITR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREAATITR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREAATITR.ForeColor = System.Drawing.Color.Black
        Me.lblREAATITR.Location = New System.Drawing.Point(541, 50)
        Me.lblREAATITR.Name = "lblREAATITR"
        Me.lblREAATITR.Size = New System.Drawing.Size(212, 20)
        Me.lblREAATITR.TabIndex = 96
        '
        'cboREAATITR
        '
        Me.cboREAATITR.AccessibleDescription = "Tipo de tramite"
        Me.cboREAATITR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboREAATITR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboREAATITR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboREAATITR.FormattingEnabled = True
        Me.cboREAATITR.Location = New System.Drawing.Point(181, 48)
        Me.cboREAATITR.Name = "cboREAATITR"
        Me.cboREAATITR.Size = New System.Drawing.Size(357, 22)
        Me.cboREAATITR.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(17, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(160, 20)
        Me.Label10.TabIndex = 95
        Me.Label10.Text = "Tipo de tramite"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(280, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 20)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Fecha expediente municipal"
        '
        'txtREAANUEM
        '
        Me.txtREAANUEM.AccessibleDescription = "Nro. expediente municipal"
        Me.txtREAANUEM.BackColor = System.Drawing.Color.White
        Me.txtREAANUEM.Location = New System.Drawing.Point(181, 73)
        Me.txtREAANUEM.Name = "txtREAANUEM"
        Me.txtREAANUEM.ReadOnly = True
        Me.txtREAANUEM.Size = New System.Drawing.Size(95, 20)
        Me.txtREAANUEM.TabIndex = 3
        '
        'dtpREAAFEEM
        '
        Me.dtpREAAFEEM.AccessibleDescription = "Fecha expediente municipal"
        Me.dtpREAAFEEM.Enabled = False
        Me.dtpREAAFEEM.Location = New System.Drawing.Point(541, 73)
        Me.dtpREAAFEEM.Name = "dtpREAAFEEM"
        Me.dtpREAAFEEM.Size = New System.Drawing.Size(20, 20)
        Me.dtpREAAFEEM.TabIndex = 5
        '
        'txtREAAFEEM
        '
        Me.txtREAAFEEM.AccessibleDescription = "Fecha expediente municipal"
        Me.txtREAAFEEM.BackColor = System.Drawing.Color.White
        Me.txtREAAFEEM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAAFEEM.Location = New System.Drawing.Point(444, 73)
        Me.txtREAAFEEM.Mask = "00-00-0000"
        Me.txtREAAFEEM.Name = "txtREAAFEEM"
        Me.txtREAAFEEM.ReadOnly = True
        Me.txtREAAFEEM.Size = New System.Drawing.Size(94, 20)
        Me.txtREAAFEEM.TabIndex = 4
        Me.txtREAAFEEM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtREAAFEEM.ValidatingType = GetType(Date)
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(17, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 20)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "Nro. expediente municipal"
        '
        'txtREAANURR
        '
        Me.txtREAANURR.AccessibleDescription = "Nro. recurso de reposición"
        Me.txtREAANURR.Location = New System.Drawing.Point(181, 119)
        Me.txtREAANURR.Name = "txtREAANURR"
        Me.txtREAANURR.Size = New System.Drawing.Size(95, 20)
        Me.txtREAANURR.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(17, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 20)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "Nro. recurso de reposición"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(280, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 20)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Fecha resolución administriva"
        '
        'txtREAANURA
        '
        Me.txtREAANURA.AccessibleDescription = "Nro. resolución administrativa"
        Me.txtREAANURA.Location = New System.Drawing.Point(181, 96)
        Me.txtREAANURA.Name = "txtREAANURA"
        Me.txtREAANURA.Size = New System.Drawing.Size(95, 20)
        Me.txtREAANURA.TabIndex = 6
        '
        'lblREAAACAD
        '
        Me.lblREAAACAD.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREAAACAD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREAAACAD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREAAACAD.ForeColor = System.Drawing.Color.Black
        Me.lblREAAACAD.Location = New System.Drawing.Point(541, 27)
        Me.lblREAAACAD.Name = "lblREAAACAD"
        Me.lblREAAACAD.Size = New System.Drawing.Size(212, 20)
        Me.lblREAAACAD.TabIndex = 84
        '
        'cboREAAACAD
        '
        Me.cboREAAACAD.AccessibleDescription = "Acto administrativo"
        Me.cboREAAACAD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboREAAACAD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboREAAACAD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboREAAACAD.FormattingEnabled = True
        Me.cboREAAACAD.Location = New System.Drawing.Point(181, 25)
        Me.cboREAAACAD.Name = "cboREAAACAD"
        Me.cboREAAACAD.Size = New System.Drawing.Size(357, 22)
        Me.cboREAAACAD.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(17, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(160, 20)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "Acto administrativo"
        '
        'dtpREAAFERR
        '
        Me.dtpREAAFERR.AccessibleDescription = "Fecha recurso de reposición"
        Me.dtpREAAFERR.Location = New System.Drawing.Point(541, 118)
        Me.dtpREAAFERR.Name = "dtpREAAFERR"
        Me.dtpREAAFERR.Size = New System.Drawing.Size(20, 20)
        Me.dtpREAAFERR.TabIndex = 11
        '
        'dtpREAAFERA
        '
        Me.dtpREAAFERA.AccessibleDescription = "Fecha resolución administrativa"
        Me.dtpREAAFERA.Location = New System.Drawing.Point(541, 96)
        Me.dtpREAAFERA.Name = "dtpREAAFERA"
        Me.dtpREAAFERA.Size = New System.Drawing.Size(20, 20)
        Me.dtpREAAFERA.TabIndex = 8
        '
        'txtREAAFERR
        '
        Me.txtREAAFERR.AccessibleDescription = "Fecha recurso de reposición"
        Me.txtREAAFERR.BackColor = System.Drawing.Color.White
        Me.txtREAAFERR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAAFERR.Location = New System.Drawing.Point(444, 119)
        Me.txtREAAFERR.Mask = "00-00-0000"
        Me.txtREAAFERR.Name = "txtREAAFERR"
        Me.txtREAAFERR.Size = New System.Drawing.Size(94, 20)
        Me.txtREAAFERR.TabIndex = 10
        Me.txtREAAFERR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtREAAFERR.ValidatingType = GetType(Date)
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(280, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(160, 20)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "Fecha recurso de reposición"
        '
        'txtREAAFERA
        '
        Me.txtREAAFERA.AccessibleDescription = "Fecha resolución administrativa"
        Me.txtREAAFERA.BackColor = System.Drawing.Color.White
        Me.txtREAAFERA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAAFERA.Location = New System.Drawing.Point(444, 96)
        Me.txtREAAFERA.Mask = "00-00-0000"
        Me.txtREAAFERA.Name = "txtREAAFERA"
        Me.txtREAAFERA.Size = New System.Drawing.Size(94, 20)
        Me.txtREAAFERA.TabIndex = 7
        Me.txtREAAFERA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtREAAFERA.ValidatingType = GetType(Date)
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(17, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(160, 20)
        Me.Label7.TabIndex = 79
        Me.Label7.Text = "Nro. resolución administriva"
        '
        'txtREAAOBSE
        '
        Me.txtREAAOBSE.AccessibleDescription = "Observación"
        Me.txtREAAOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtREAAOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREAAOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREAAOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtREAAOBSE.Location = New System.Drawing.Point(181, 142)
        Me.txtREAAOBSE.MaxLength = 1000
        Me.txtREAAOBSE.Multiline = True
        Me.txtREAAOBSE.Name = "txtREAAOBSE"
        Me.txtREAAOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtREAAOBSE.Size = New System.Drawing.Size(572, 62)
        Me.txtREAAOBSE.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(17, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 20)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Observación"
        '
        'frm_insertar_RECLACAD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 326)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.fraINFOUSUA)
        Me.Controls.Add(Me.strBARRESTA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(817, 362)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(817, 362)
        Me.Name = "frm_insertar_RECLACAD"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.fraINFOUSUA.ResumeLayout(False)
        Me.fraINFOUSUA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents fraINFOUSUA As System.Windows.Forms.GroupBox
    Friend WithEvents dtpREAAFERR As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpREAAFERA As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtREAAFERR As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtREAAFERA As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtREAAOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblREAAACAD As System.Windows.Forms.Label
    Friend WithEvents cboREAAACAD As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtREAANURR As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtREAANURA As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtREAANUEM As System.Windows.Forms.TextBox
    Friend WithEvents dtpREAAFEEM As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtREAAFEEM As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblREAATITR As System.Windows.Forms.Label
    Friend WithEvents cboREAATITR As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
