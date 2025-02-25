<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_OBURINGE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_insertar_OBURINGE))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraCEDUCATA = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkOUIGPLPA = New System.Windows.Forms.CheckBox()
        Me.chkOUIGADLI = New System.Windows.Forms.CheckBox()
        Me.txtOUIGOBSE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboOUIGESSO = New System.Windows.Forms.ComboBox()
        Me.lblOUIGESSO = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboOUIGTIPO = New System.Windows.Forms.ComboBox()
        Me.lblOUIGTIPO = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboOUIGTILI = New System.Windows.Forms.ComboBox()
        Me.lblOUIGTILI = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtOUIGLIQU = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtOUIGAVCO = New System.Windows.Forms.TextBox()
        Me.txtOUIGAVCA = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtOUIGATCO = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboOUIGESTA = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboOUIGCLOU = New System.Windows.Forms.ComboBox()
        Me.lblOUIGCLOU = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboOUIGCLSE = New System.Windows.Forms.ComboBox()
        Me.lblOUIGCLSE = New System.Windows.Forms.Label()
        Me.txtOUIGATLO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtOUIGUNID = New System.Windows.Forms.TextBox()
        Me.txtOUIGDENS = New System.Windows.Forms.TextBox()
        Me.txtOUIGSMLV = New System.Windows.Forms.TextBox()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOUIGNULI = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraCEDUCATA.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdSALIR)
        Me.GroupBox2.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 517)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(686, 46)
        Me.GroupBox2.TabIndex = 354
        Me.GroupBox2.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = CType(resources.GetObject("cmdSALIR.Image"), System.Drawing.Image)
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(344, 14)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 18
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = CType(resources.GetObject("cmdGUARDAR.Image"), System.Drawing.Image)
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(237, 14)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 17
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 584)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(720, 25)
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
        'fraCEDUCATA
        '
        Me.fraCEDUCATA.Controls.Add(Me.GroupBox3)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUIGOBSE)
        Me.fraCEDUCATA.Controls.Add(Me.Label3)
        Me.fraCEDUCATA.Controls.Add(Me.cboOUIGESSO)
        Me.fraCEDUCATA.Controls.Add(Me.lblOUIGESSO)
        Me.fraCEDUCATA.Controls.Add(Me.Label15)
        Me.fraCEDUCATA.Controls.Add(Me.cboOUIGTIPO)
        Me.fraCEDUCATA.Controls.Add(Me.lblOUIGTIPO)
        Me.fraCEDUCATA.Controls.Add(Me.Label17)
        Me.fraCEDUCATA.Controls.Add(Me.cboOUIGTILI)
        Me.fraCEDUCATA.Controls.Add(Me.lblOUIGTILI)
        Me.fraCEDUCATA.Controls.Add(Me.Label13)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUIGLIQU)
        Me.fraCEDUCATA.Controls.Add(Me.Label9)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUIGAVCO)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUIGAVCA)
        Me.fraCEDUCATA.Controls.Add(Me.Label10)
        Me.fraCEDUCATA.Controls.Add(Me.Label11)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUIGATCO)
        Me.fraCEDUCATA.Controls.Add(Me.Label5)
        Me.fraCEDUCATA.Controls.Add(Me.cboOUIGESTA)
        Me.fraCEDUCATA.Controls.Add(Me.Label8)
        Me.fraCEDUCATA.Controls.Add(Me.cboOUIGCLOU)
        Me.fraCEDUCATA.Controls.Add(Me.lblOUIGCLOU)
        Me.fraCEDUCATA.Controls.Add(Me.Label7)
        Me.fraCEDUCATA.Controls.Add(Me.cboOUIGCLSE)
        Me.fraCEDUCATA.Controls.Add(Me.lblOUIGCLSE)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUIGATLO)
        Me.fraCEDUCATA.Controls.Add(Me.Label2)
        Me.fraCEDUCATA.Controls.Add(Me.Label4)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUIGUNID)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUIGDENS)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUIGSMLV)
        Me.fraCEDUCATA.Controls.Add(Me.lblBarrio)
        Me.fraCEDUCATA.Controls.Add(Me.lblCorregimiento)
        Me.fraCEDUCATA.Controls.Add(Me.lblMunicipio)
        Me.fraCEDUCATA.Location = New System.Drawing.Point(16, 70)
        Me.fraCEDUCATA.Name = "fraCEDUCATA"
        Me.fraCEDUCATA.Size = New System.Drawing.Size(686, 441)
        Me.fraCEDUCATA.TabIndex = 353
        Me.fraCEDUCATA.TabStop = False
        Me.fraCEDUCATA.Text = "INSERTAR INFORMACIÓN GENERAL"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkOUIGPLPA)
        Me.GroupBox3.Controls.Add(Me.chkOUIGADLI)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 377)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(651, 47)
        Me.GroupBox3.TabIndex = 443
        Me.GroupBox3.TabStop = False
        '
        'chkOUIGPLPA
        '
        Me.chkOUIGPLPA.Location = New System.Drawing.Point(187, 15)
        Me.chkOUIGPLPA.Name = "chkOUIGPLPA"
        Me.chkOUIGPLPA.Size = New System.Drawing.Size(123, 24)
        Me.chkOUIGPLPA.TabIndex = 439
        Me.chkOUIGPLPA.Text = "Aplica plan parcial"
        Me.chkOUIGPLPA.UseVisualStyleBackColor = True
        '
        'chkOUIGADLI
        '
        Me.chkOUIGADLI.Location = New System.Drawing.Point(328, 15)
        Me.chkOUIGADLI.Name = "chkOUIGADLI"
        Me.chkOUIGADLI.Size = New System.Drawing.Size(147, 24)
        Me.chkOUIGADLI.TabIndex = 442
        Me.chkOUIGADLI.Text = "Adición de liquidación"
        Me.chkOUIGADLI.UseVisualStyleBackColor = True
        '
        'txtOUIGOBSE
        '
        Me.txtOUIGOBSE.AccessibleDescription = "Observación"
        Me.txtOUIGOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUIGOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUIGOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtOUIGOBSE.Location = New System.Drawing.Point(205, 351)
        Me.txtOUIGOBSE.MaxLength = 1000
        Me.txtOUIGOBSE.Name = "txtOUIGOBSE"
        Me.txtOUIGOBSE.Size = New System.Drawing.Size(462, 20)
        Me.txtOUIGOBSE.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 351)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(185, 20)
        Me.Label3.TabIndex = 441
        Me.Label3.Text = "Observación"
        '
        'cboOUIGESSO
        '
        Me.cboOUIGESSO.AccessibleDescription = "Estrato"
        Me.cboOUIGESSO.BackColor = System.Drawing.Color.White
        Me.cboOUIGESSO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUIGESSO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUIGESSO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUIGESSO.Location = New System.Drawing.Point(205, 96)
        Me.cboOUIGESSO.MaxDropDownItems = 15
        Me.cboOUIGESSO.MaxLength = 1
        Me.cboOUIGESSO.Name = "cboOUIGESSO"
        Me.cboOUIGESSO.Size = New System.Drawing.Size(258, 22)
        Me.cboOUIGESSO.TabIndex = 4
        '
        'lblOUIGESSO
        '
        Me.lblOUIGESSO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblOUIGESSO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOUIGESSO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOUIGESSO.ForeColor = System.Drawing.Color.Black
        Me.lblOUIGESSO.Location = New System.Drawing.Point(469, 98)
        Me.lblOUIGESSO.Name = "lblOUIGESSO"
        Me.lblOUIGESSO.Size = New System.Drawing.Size(198, 20)
        Me.lblOUIGESSO.TabIndex = 438
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(16, 98)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(185, 20)
        Me.Label15.TabIndex = 437
        Me.Label15.Text = "Estrato socioeconómico"
        '
        'cboOUIGTIPO
        '
        Me.cboOUIGTIPO.AccessibleDescription = "Tipo de calificación"
        Me.cboOUIGTIPO.BackColor = System.Drawing.Color.White
        Me.cboOUIGTIPO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUIGTIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUIGTIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUIGTIPO.Location = New System.Drawing.Point(205, 73)
        Me.cboOUIGTIPO.MaxDropDownItems = 15
        Me.cboOUIGTIPO.MaxLength = 1
        Me.cboOUIGTIPO.Name = "cboOUIGTIPO"
        Me.cboOUIGTIPO.Size = New System.Drawing.Size(258, 22)
        Me.cboOUIGTIPO.TabIndex = 3
        '
        'lblOUIGTIPO
        '
        Me.lblOUIGTIPO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblOUIGTIPO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOUIGTIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOUIGTIPO.ForeColor = System.Drawing.Color.Black
        Me.lblOUIGTIPO.Location = New System.Drawing.Point(469, 75)
        Me.lblOUIGTIPO.Name = "lblOUIGTIPO"
        Me.lblOUIGTIPO.Size = New System.Drawing.Size(198, 20)
        Me.lblOUIGTIPO.TabIndex = 435
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(16, 75)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(185, 20)
        Me.Label17.TabIndex = 434
        Me.Label17.Text = "Tipo de calificación"
        '
        'cboOUIGTILI
        '
        Me.cboOUIGTILI.AccessibleDescription = "Tipo de liquidación"
        Me.cboOUIGTILI.BackColor = System.Drawing.Color.White
        Me.cboOUIGTILI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUIGTILI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUIGTILI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUIGTILI.Location = New System.Drawing.Point(205, 119)
        Me.cboOUIGTILI.MaxDropDownItems = 15
        Me.cboOUIGTILI.MaxLength = 1
        Me.cboOUIGTILI.Name = "cboOUIGTILI"
        Me.cboOUIGTILI.Size = New System.Drawing.Size(258, 22)
        Me.cboOUIGTILI.TabIndex = 5
        '
        'lblOUIGTILI
        '
        Me.lblOUIGTILI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblOUIGTILI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOUIGTILI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOUIGTILI.ForeColor = System.Drawing.Color.Black
        Me.lblOUIGTILI.Location = New System.Drawing.Point(469, 121)
        Me.lblOUIGTILI.Name = "lblOUIGTILI"
        Me.lblOUIGTILI.Size = New System.Drawing.Size(198, 20)
        Me.lblOUIGTILI.TabIndex = 432
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(16, 121)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(185, 20)
        Me.Label13.TabIndex = 431
        Me.Label13.Text = "Tipo de liquidación"
        '
        'txtOUIGLIQU
        '
        Me.txtOUIGLIQU.AccessibleDescription = "Liquidación"
        Me.txtOUIGLIQU.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUIGLIQU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUIGLIQU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUIGLIQU.ForeColor = System.Drawing.Color.Black
        Me.txtOUIGLIQU.Location = New System.Drawing.Point(205, 305)
        Me.txtOUIGLIQU.MaxLength = 12
        Me.txtOUIGLIQU.Name = "txtOUIGLIQU"
        Me.txtOUIGLIQU.ReadOnly = True
        Me.txtOUIGLIQU.Size = New System.Drawing.Size(258, 20)
        Me.txtOUIGLIQU.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(16, 305)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(185, 20)
        Me.Label9.TabIndex = 429
        Me.Label9.Text = "Valor liquidado"
        '
        'txtOUIGAVCO
        '
        Me.txtOUIGAVCO.AccessibleDescription = "Avalúo comercial"
        Me.txtOUIGAVCO.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUIGAVCO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUIGAVCO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUIGAVCO.ForeColor = System.Drawing.Color.Black
        Me.txtOUIGAVCO.Location = New System.Drawing.Point(205, 282)
        Me.txtOUIGAVCO.MaxLength = 12
        Me.txtOUIGAVCO.Name = "txtOUIGAVCO"
        Me.txtOUIGAVCO.ReadOnly = True
        Me.txtOUIGAVCO.Size = New System.Drawing.Size(258, 20)
        Me.txtOUIGAVCO.TabIndex = 12
        '
        'txtOUIGAVCA
        '
        Me.txtOUIGAVCA.AccessibleDescription = "Avalúo catastral"
        Me.txtOUIGAVCA.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUIGAVCA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUIGAVCA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUIGAVCA.ForeColor = System.Drawing.Color.Black
        Me.txtOUIGAVCA.Location = New System.Drawing.Point(205, 259)
        Me.txtOUIGAVCA.MaxLength = 12
        Me.txtOUIGAVCA.Name = "txtOUIGAVCA"
        Me.txtOUIGAVCA.ReadOnly = True
        Me.txtOUIGAVCA.Size = New System.Drawing.Size(258, 20)
        Me.txtOUIGAVCA.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(16, 282)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(185, 20)
        Me.Label10.TabIndex = 428
        Me.Label10.Text = "Avalúo comercial (m2)"
        '
        'Label11
        '
        Me.Label11.AccessibleDescription = ""
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(16, 259)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(185, 20)
        Me.Label11.TabIndex = 427
        Me.Label11.Text = "Avalúo de terreno"
        '
        'txtOUIGATCO
        '
        Me.txtOUIGATCO.AccessibleDescription = "Área total construcción"
        Me.txtOUIGATCO.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUIGATCO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUIGATCO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUIGATCO.ForeColor = System.Drawing.Color.Black
        Me.txtOUIGATCO.Location = New System.Drawing.Point(205, 166)
        Me.txtOUIGATCO.MaxLength = 9
        Me.txtOUIGATCO.Name = "txtOUIGATCO"
        Me.txtOUIGATCO.Size = New System.Drawing.Size(258, 20)
        Me.txtOUIGATCO.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(16, 167)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(185, 20)
        Me.Label5.TabIndex = 423
        Me.Label5.Text = "Área total de construcción (m2)"
        '
        'cboOUIGESTA
        '
        Me.cboOUIGESTA.AccessibleDescription = "Estado"
        Me.cboOUIGESTA.BackColor = System.Drawing.Color.White
        Me.cboOUIGESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUIGESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUIGESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUIGESTA.Location = New System.Drawing.Point(205, 327)
        Me.cboOUIGESTA.MaxDropDownItems = 15
        Me.cboOUIGESTA.MaxLength = 1
        Me.cboOUIGESTA.Name = "cboOUIGESTA"
        Me.cboOUIGESTA.Size = New System.Drawing.Size(258, 22)
        Me.cboOUIGESTA.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(16, 328)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(185, 20)
        Me.Label8.TabIndex = 421
        Me.Label8.Text = "Estado"
        '
        'cboOUIGCLOU
        '
        Me.cboOUIGCLOU.AccessibleDescription = "Clase de obligación"
        Me.cboOUIGCLOU.BackColor = System.Drawing.Color.White
        Me.cboOUIGCLOU.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUIGCLOU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUIGCLOU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUIGCLOU.Location = New System.Drawing.Point(205, 27)
        Me.cboOUIGCLOU.MaxDropDownItems = 15
        Me.cboOUIGCLOU.MaxLength = 1
        Me.cboOUIGCLOU.Name = "cboOUIGCLOU"
        Me.cboOUIGCLOU.Size = New System.Drawing.Size(258, 22)
        Me.cboOUIGCLOU.TabIndex = 1
        '
        'lblOUIGCLOU
        '
        Me.lblOUIGCLOU.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblOUIGCLOU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOUIGCLOU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOUIGCLOU.ForeColor = System.Drawing.Color.Black
        Me.lblOUIGCLOU.Location = New System.Drawing.Point(469, 29)
        Me.lblOUIGCLOU.Name = "lblOUIGCLOU"
        Me.lblOUIGCLOU.Size = New System.Drawing.Size(198, 20)
        Me.lblOUIGCLOU.TabIndex = 419
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(16, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(185, 20)
        Me.Label7.TabIndex = 418
        Me.Label7.Text = "Clase de obligación"
        '
        'cboOUIGCLSE
        '
        Me.cboOUIGCLSE.AccessibleDescription = "Clase o sector "
        Me.cboOUIGCLSE.BackColor = System.Drawing.Color.White
        Me.cboOUIGCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUIGCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUIGCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUIGCLSE.Location = New System.Drawing.Point(205, 50)
        Me.cboOUIGCLSE.MaxDropDownItems = 15
        Me.cboOUIGCLSE.MaxLength = 1
        Me.cboOUIGCLSE.Name = "cboOUIGCLSE"
        Me.cboOUIGCLSE.Size = New System.Drawing.Size(258, 22)
        Me.cboOUIGCLSE.TabIndex = 2
        '
        'lblOUIGCLSE
        '
        Me.lblOUIGCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblOUIGCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOUIGCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOUIGCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblOUIGCLSE.Location = New System.Drawing.Point(469, 52)
        Me.lblOUIGCLSE.Name = "lblOUIGCLSE"
        Me.lblOUIGCLSE.Size = New System.Drawing.Size(198, 20)
        Me.lblOUIGCLSE.TabIndex = 410
        '
        'txtOUIGATLO
        '
        Me.txtOUIGATLO.AccessibleDescription = "Área total de terreno"
        Me.txtOUIGATLO.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUIGATLO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUIGATLO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUIGATLO.ForeColor = System.Drawing.Color.Black
        Me.txtOUIGATLO.Location = New System.Drawing.Point(205, 143)
        Me.txtOUIGATLO.MaxLength = 9
        Me.txtOUIGATLO.Name = "txtOUIGATLO"
        Me.txtOUIGATLO.Size = New System.Drawing.Size(258, 20)
        Me.txtOUIGATLO.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(185, 20)
        Me.Label2.TabIndex = 407
        Me.Label2.Text = "Área total de terreno (m2)"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(185, 20)
        Me.Label4.TabIndex = 405
        Me.Label4.Text = "Clase o Sector"
        '
        'txtOUIGUNID
        '
        Me.txtOUIGUNID.AccessibleDescription = "Unidad"
        Me.txtOUIGUNID.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUIGUNID.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUIGUNID.Location = New System.Drawing.Point(205, 212)
        Me.txtOUIGUNID.MaxLength = 9
        Me.txtOUIGUNID.Name = "txtOUIGUNID"
        Me.txtOUIGUNID.Size = New System.Drawing.Size(258, 20)
        Me.txtOUIGUNID.TabIndex = 9
        '
        'txtOUIGDENS
        '
        Me.txtOUIGDENS.AccessibleDescription = "Densidad"
        Me.txtOUIGDENS.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUIGDENS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUIGDENS.ForeColor = System.Drawing.Color.Black
        Me.txtOUIGDENS.Location = New System.Drawing.Point(205, 189)
        Me.txtOUIGDENS.MaxLength = 5
        Me.txtOUIGDENS.Name = "txtOUIGDENS"
        Me.txtOUIGDENS.Size = New System.Drawing.Size(258, 20)
        Me.txtOUIGDENS.TabIndex = 8
        '
        'txtOUIGSMLV
        '
        Me.txtOUIGSMLV.AccessibleDescription = "SMMLV"
        Me.txtOUIGSMLV.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUIGSMLV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUIGSMLV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUIGSMLV.ForeColor = System.Drawing.Color.Black
        Me.txtOUIGSMLV.Location = New System.Drawing.Point(205, 235)
        Me.txtOUIGSMLV.MaxLength = 12
        Me.txtOUIGSMLV.Name = "txtOUIGSMLV"
        Me.txtOUIGSMLV.ReadOnly = True
        Me.txtOUIGSMLV.Size = New System.Drawing.Size(258, 20)
        Me.txtOUIGSMLV.TabIndex = 10
        '
        'lblBarrio
        '
        Me.lblBarrio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblBarrio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBarrio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarrio.ForeColor = System.Drawing.Color.Black
        Me.lblBarrio.Location = New System.Drawing.Point(16, 236)
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Size = New System.Drawing.Size(185, 20)
        Me.lblBarrio.TabIndex = 392
        Me.lblBarrio.Text = "SMMLV"
        '
        'lblCorregimiento
        '
        Me.lblCorregimiento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCorregimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorregimiento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorregimiento.ForeColor = System.Drawing.Color.Black
        Me.lblCorregimiento.Location = New System.Drawing.Point(16, 213)
        Me.lblCorregimiento.Name = "lblCorregimiento"
        Me.lblCorregimiento.Size = New System.Drawing.Size(185, 20)
        Me.lblCorregimiento.TabIndex = 396
        Me.lblCorregimiento.Text = "Nro. Unidades"
        '
        'lblMunicipio
        '
        Me.lblMunicipio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblMunicipio.Location = New System.Drawing.Point(16, 190)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(185, 20)
        Me.lblMunicipio.TabIndex = 398
        Me.lblMunicipio.Text = "Densidad"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtOUIGNULI)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(686, 48)
        Me.GroupBox1.TabIndex = 356
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(185, 20)
        Me.Label1.TabIndex = 319
        Me.Label1.Text = "Nro. de liquidación"
        '
        'txtOUIGNULI
        '
        Me.txtOUIGNULI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtOUIGNULI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtOUIGNULI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUIGNULI.ForeColor = System.Drawing.Color.Black
        Me.txtOUIGNULI.Location = New System.Drawing.Point(205, 17)
        Me.txtOUIGNULI.Name = "txtOUIGNULI"
        Me.txtOUIGNULI.Size = New System.Drawing.Size(258, 20)
        Me.txtOUIGNULI.TabIndex = 312
        Me.txtOUIGNULI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frm_insertar_OBURINGE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 609)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCEDUCATA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(736, 645)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(736, 645)
        Me.Name = "frm_insertar_OBURINGE"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox2.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraCEDUCATA.ResumeLayout(False)
        Me.fraCEDUCATA.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraCEDUCATA As System.Windows.Forms.GroupBox
    Friend WithEvents txtOUIGLIQU As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtOUIGAVCO As System.Windows.Forms.TextBox
    Friend WithEvents txtOUIGAVCA As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtOUIGATCO As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboOUIGESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboOUIGCLOU As System.Windows.Forms.ComboBox
    Friend WithEvents lblOUIGCLOU As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboOUIGCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblOUIGCLSE As System.Windows.Forms.Label
    Friend WithEvents txtOUIGATLO As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtOUIGUNID As System.Windows.Forms.TextBox
    Friend WithEvents txtOUIGDENS As System.Windows.Forms.TextBox
    Friend WithEvents txtOUIGSMLV As System.Windows.Forms.TextBox
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents cboOUIGESSO As System.Windows.Forms.ComboBox
    Friend WithEvents lblOUIGESSO As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboOUIGTIPO As System.Windows.Forms.ComboBox
    Friend WithEvents lblOUIGTIPO As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboOUIGTILI As System.Windows.Forms.ComboBox
    Friend WithEvents lblOUIGTILI As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOUIGNULI As System.Windows.Forms.Label
    Friend WithEvents txtOUIGOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkOUIGPLPA As System.Windows.Forms.CheckBox
    Friend WithEvents chkOUIGADLI As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
End Class
