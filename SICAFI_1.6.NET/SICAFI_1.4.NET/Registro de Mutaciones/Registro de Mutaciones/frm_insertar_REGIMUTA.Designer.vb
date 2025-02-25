<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_REGIMUTA
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtREMUSECU = New System.Windows.Forms.Label()
        Me.fraFICHPRED = New System.Windows.Forms.GroupBox()
        Me.dtpREMUFEFI = New System.Windows.Forms.DateTimePicker()
        Me.txtREMUFEFI = New System.Windows.Forms.MaskedTextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtpREMUFEAS = New System.Windows.Forms.DateTimePicker()
        Me.txtREMUFEAS = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblREMUUSUA = New System.Windows.Forms.Label()
        Me.cboREMUUSUA = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboREMUMES = New System.Windows.Forms.ComboBox()
        Me.lblREMUMES = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtREMUOBSE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboREMUESTA = New System.Windows.Forms.ComboBox()
        Me.cboREMUVIGE = New System.Windows.Forms.ComboBox()
        Me.lblREMUVIGE = New System.Windows.Forms.Label()
        Me.lblCategoriaDeSuelo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox2.SuspendLayout()
        Me.fraFICHPRED.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtREMUSECU)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(637, 48)
        Me.GroupBox2.TabIndex = 343
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "REGISTRO"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(20, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 20)
        Me.Label8.TabIndex = 319
        Me.Label8.Text = "Nro. Secuencia"
        '
        'txtREMUSECU
        '
        Me.txtREMUSECU.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtREMUSECU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtREMUSECU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREMUSECU.ForeColor = System.Drawing.Color.Black
        Me.txtREMUSECU.Location = New System.Drawing.Point(109, 17)
        Me.txtREMUSECU.Name = "txtREMUSECU"
        Me.txtREMUSECU.Size = New System.Drawing.Size(86, 20)
        Me.txtREMUSECU.TabIndex = 312
        Me.txtREMUSECU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fraFICHPRED
        '
        Me.fraFICHPRED.BackColor = System.Drawing.SystemColors.Control
        Me.fraFICHPRED.Controls.Add(Me.dtpREMUFEFI)
        Me.fraFICHPRED.Controls.Add(Me.txtREMUFEFI)
        Me.fraFICHPRED.Controls.Add(Me.Label14)
        Me.fraFICHPRED.Controls.Add(Me.dtpREMUFEAS)
        Me.fraFICHPRED.Controls.Add(Me.txtREMUFEAS)
        Me.fraFICHPRED.Controls.Add(Me.Label11)
        Me.fraFICHPRED.Controls.Add(Me.lblREMUUSUA)
        Me.fraFICHPRED.Controls.Add(Me.cboREMUUSUA)
        Me.fraFICHPRED.Controls.Add(Me.Label9)
        Me.fraFICHPRED.Controls.Add(Me.cboREMUMES)
        Me.fraFICHPRED.Controls.Add(Me.lblREMUMES)
        Me.fraFICHPRED.Controls.Add(Me.Label4)
        Me.fraFICHPRED.Controls.Add(Me.Label5)
        Me.fraFICHPRED.Controls.Add(Me.txtREMUOBSE)
        Me.fraFICHPRED.Controls.Add(Me.Label2)
        Me.fraFICHPRED.Controls.Add(Me.cboREMUESTA)
        Me.fraFICHPRED.Controls.Add(Me.cboREMUVIGE)
        Me.fraFICHPRED.Controls.Add(Me.lblREMUVIGE)
        Me.fraFICHPRED.Controls.Add(Me.lblCategoriaDeSuelo)
        Me.fraFICHPRED.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraFICHPRED.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraFICHPRED.Location = New System.Drawing.Point(15, 69)
        Me.fraFICHPRED.Name = "fraFICHPRED"
        Me.fraFICHPRED.Size = New System.Drawing.Size(637, 269)
        Me.fraFICHPRED.TabIndex = 340
        Me.fraFICHPRED.TabStop = False
        Me.fraFICHPRED.Text = "INSERTAR REGISTRO DE MUTACIONES"
        '
        'dtpREMUFEFI
        '
        Me.dtpREMUFEFI.Location = New System.Drawing.Point(318, 141)
        Me.dtpREMUFEFI.Name = "dtpREMUFEFI"
        Me.dtpREMUFEFI.Size = New System.Drawing.Size(21, 21)
        Me.dtpREMUFEFI.TabIndex = 428
        '
        'txtREMUFEFI
        '
        Me.txtREMUFEFI.AccessibleDescription = "Fecha finalización"
        Me.txtREMUFEFI.BackColor = System.Drawing.Color.White
        Me.txtREMUFEFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREMUFEFI.Location = New System.Drawing.Point(155, 141)
        Me.txtREMUFEFI.Mask = "00-00-0000"
        Me.txtREMUFEFI.Name = "txtREMUFEFI"
        Me.txtREMUFEFI.Size = New System.Drawing.Size(160, 20)
        Me.txtREMUFEFI.TabIndex = 6
        Me.txtREMUFEFI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(20, 142)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(132, 20)
        Me.Label14.TabIndex = 427
        Me.Label14.Text = "Fecha finalización"
        '
        'dtpREMUFEAS
        '
        Me.dtpREMUFEAS.Location = New System.Drawing.Point(318, 118)
        Me.dtpREMUFEAS.Name = "dtpREMUFEAS"
        Me.dtpREMUFEAS.Size = New System.Drawing.Size(21, 21)
        Me.dtpREMUFEAS.TabIndex = 426
        '
        'txtREMUFEAS
        '
        Me.txtREMUFEAS.AccessibleDescription = "Fecha asignación"
        Me.txtREMUFEAS.BackColor = System.Drawing.Color.White
        Me.txtREMUFEAS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREMUFEAS.Location = New System.Drawing.Point(155, 118)
        Me.txtREMUFEAS.Mask = "00-00-0000"
        Me.txtREMUFEAS.Name = "txtREMUFEAS"
        Me.txtREMUFEAS.Size = New System.Drawing.Size(160, 20)
        Me.txtREMUFEAS.TabIndex = 5
        Me.txtREMUFEAS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(20, 119)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 20)
        Me.Label11.TabIndex = 425
        Me.Label11.Text = "Fecha asignación"
        '
        'lblREMUUSUA
        '
        Me.lblREMUUSUA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREMUUSUA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREMUUSUA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREMUUSUA.ForeColor = System.Drawing.Color.Black
        Me.lblREMUUSUA.Location = New System.Drawing.Point(499, 72)
        Me.lblREMUUSUA.Name = "lblREMUUSUA"
        Me.lblREMUUSUA.Size = New System.Drawing.Size(121, 20)
        Me.lblREMUUSUA.TabIndex = 422
        '
        'cboREMUUSUA
        '
        Me.cboREMUUSUA.AccessibleDescription = "Usuario"
        Me.cboREMUUSUA.BackColor = System.Drawing.Color.White
        Me.cboREMUUSUA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboREMUUSUA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboREMUUSUA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboREMUUSUA.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboREMUUSUA.Location = New System.Drawing.Point(155, 70)
        Me.cboREMUUSUA.MaxDropDownItems = 15
        Me.cboREMUUSUA.MaxLength = 1
        Me.cboREMUUSUA.Name = "cboREMUUSUA"
        Me.cboREMUUSUA.Size = New System.Drawing.Size(340, 22)
        Me.cboREMUUSUA.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(20, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(132, 20)
        Me.Label9.TabIndex = 421
        Me.Label9.Text = "Usuario"
        '
        'cboREMUMES
        '
        Me.cboREMUMES.AccessibleDescription = "Mes"
        Me.cboREMUMES.BackColor = System.Drawing.Color.White
        Me.cboREMUMES.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboREMUMES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboREMUMES.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboREMUMES.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboREMUMES.Location = New System.Drawing.Point(155, 47)
        Me.cboREMUMES.MaxDropDownItems = 15
        Me.cboREMUMES.MaxLength = 1
        Me.cboREMUMES.Name = "cboREMUMES"
        Me.cboREMUMES.Size = New System.Drawing.Size(340, 22)
        Me.cboREMUMES.TabIndex = 2
        '
        'lblREMUMES
        '
        Me.lblREMUMES.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREMUMES.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREMUMES.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREMUMES.ForeColor = System.Drawing.Color.Black
        Me.lblREMUMES.Location = New System.Drawing.Point(499, 49)
        Me.lblREMUMES.Name = "lblREMUMES"
        Me.lblREMUMES.Size = New System.Drawing.Size(121, 20)
        Me.lblREMUMES.TabIndex = 419
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(20, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 20)
        Me.Label4.TabIndex = 418
        Me.Label4.Text = "Mes"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(20, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(600, 20)
        Me.Label5.TabIndex = 380
        Me.Label5.Text = "OBSERVACIONES"
        '
        'txtREMUOBSE
        '
        Me.txtREMUOBSE.AccessibleDescription = "Observaciones"
        Me.txtREMUOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtREMUOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREMUOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREMUOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtREMUOBSE.Location = New System.Drawing.Point(20, 188)
        Me.txtREMUOBSE.MaxLength = 1000
        Me.txtREMUOBSE.Multiline = True
        Me.txtREMUOBSE.Name = "txtREMUOBSE"
        Me.txtREMUOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtREMUOBSE.Size = New System.Drawing.Size(600, 60)
        Me.txtREMUOBSE.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(20, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 20)
        Me.Label2.TabIndex = 301
        Me.Label2.Text = "Estado"
        '
        'cboREMUESTA
        '
        Me.cboREMUESTA.AccessibleDescription = "Estado"
        Me.cboREMUESTA.BackColor = System.Drawing.Color.White
        Me.cboREMUESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboREMUESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboREMUESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboREMUESTA.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11"})
        Me.cboREMUESTA.Location = New System.Drawing.Point(155, 93)
        Me.cboREMUESTA.MaxDropDownItems = 15
        Me.cboREMUESTA.MaxLength = 2
        Me.cboREMUESTA.Name = "cboREMUESTA"
        Me.cboREMUESTA.Size = New System.Drawing.Size(340, 22)
        Me.cboREMUESTA.TabIndex = 4
        '
        'cboREMUVIGE
        '
        Me.cboREMUVIGE.AccessibleDescription = "Vigencia"
        Me.cboREMUVIGE.BackColor = System.Drawing.Color.White
        Me.cboREMUVIGE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboREMUVIGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboREMUVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboREMUVIGE.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboREMUVIGE.Location = New System.Drawing.Point(155, 24)
        Me.cboREMUVIGE.MaxDropDownItems = 15
        Me.cboREMUVIGE.MaxLength = 1
        Me.cboREMUVIGE.Name = "cboREMUVIGE"
        Me.cboREMUVIGE.Size = New System.Drawing.Size(340, 22)
        Me.cboREMUVIGE.TabIndex = 1
        '
        'lblREMUVIGE
        '
        Me.lblREMUVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblREMUVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblREMUVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREMUVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblREMUVIGE.Location = New System.Drawing.Point(499, 26)
        Me.lblREMUVIGE.Name = "lblREMUVIGE"
        Me.lblREMUVIGE.Size = New System.Drawing.Size(121, 20)
        Me.lblREMUVIGE.TabIndex = 51
        '
        'lblCategoriaDeSuelo
        '
        Me.lblCategoriaDeSuelo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCategoriaDeSuelo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCategoriaDeSuelo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoriaDeSuelo.ForeColor = System.Drawing.Color.Black
        Me.lblCategoriaDeSuelo.Location = New System.Drawing.Point(20, 26)
        Me.lblCategoriaDeSuelo.Name = "lblCategoriaDeSuelo"
        Me.lblCategoriaDeSuelo.Size = New System.Drawing.Size(132, 20)
        Me.lblCategoriaDeSuelo.TabIndex = 44
        Me.lblCategoriaDeSuelo.Text = "Vigencia"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 344)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(637, 46)
        Me.GroupBox1.TabIndex = 341
        Me.GroupBox1.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(321, 15)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(214, 15)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 407)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(665, 25)
        Me.strBARRESTA.TabIndex = 342
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
        'frm_insertar_REGIMUTA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 432)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.fraFICHPRED)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(681, 468)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(681, 468)
        Me.Name = "frm_insertar_REGIMUTA"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox2.ResumeLayout(False)
        Me.fraFICHPRED.ResumeLayout(False)
        Me.fraFICHPRED.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtREMUSECU As System.Windows.Forms.Label
    Friend WithEvents fraFICHPRED As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtREMUOBSE As System.Windows.Forms.TextBox
    Friend WithEvents cboREMUESTA As System.Windows.Forms.ComboBox
    Friend WithEvents cboREMUVIGE As System.Windows.Forms.ComboBox
    Friend WithEvents lblREMUVIGE As System.Windows.Forms.Label
    Friend WithEvents lblCategoriaDeSuelo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cboREMUUSUA As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboREMUMES As System.Windows.Forms.ComboBox
    Friend WithEvents lblREMUMES As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblREMUUSUA As System.Windows.Forms.Label
    Friend WithEvents dtpREMUFEFI As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtREMUFEFI As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpREMUFEAS As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtREMUFEAS As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
