<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_OBURPRED
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_insertar_OBURPRED))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraCEDUCATA = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtOUPRAVCA = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtOUPRVACP = New System.Windows.Forms.TextBox()
        Me.txtOUPRVATP = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtOUPRARTE = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboOUPRESTA = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboOUPRZOPL = New System.Windows.Forms.ComboBox()
        Me.lblOUPRZOPL = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtOUPRUNPR = New System.Windows.Forms.TextBox()
        Me.txtOUPREDIF = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboOUPRCLSE = New System.Windows.Forms.ComboBox()
        Me.lblOUPRCLSE = New System.Windows.Forms.Label()
        Me.txtOUPRNUFI = New System.Windows.Forms.TextBox()
        Me.txtOUPRMAIN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtOUPRCORR = New System.Windows.Forms.TextBox()
        Me.txtOUPRMUNI = New System.Windows.Forms.TextBox()
        Me.txtOUPRPRED = New System.Windows.Forms.TextBox()
        Me.txtOUPRMANZ = New System.Windows.Forms.TextBox()
        Me.txtOUPRBARR = New System.Windows.Forms.TextBox()
        Me.lblCodigoActual = New System.Windows.Forms.Label()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.lblManzana = New System.Windows.Forms.Label()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbdOUPRARCA = New System.Windows.Forms.RadioButton()
        Me.rbdOUPRARRE = New System.Windows.Forms.RadioButton()
        Me.GroupBox2.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraCEDUCATA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdSALIR)
        Me.GroupBox2.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 302)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(769, 46)
        Me.GroupBox2.TabIndex = 351
        Me.GroupBox2.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = CType(resources.GetObject("cmdSALIR.Image"), System.Drawing.Image)
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(388, 14)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(281, 14)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 362)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(794, 25)
        Me.strBARRESTA.TabIndex = 352
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
        Me.fraCEDUCATA.Controls.Add(Me.GroupBox1)
        Me.fraCEDUCATA.Controls.Add(Me.Label12)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUPRAVCA)
        Me.fraCEDUCATA.Controls.Add(Me.Label9)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUPRVACP)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUPRVATP)
        Me.fraCEDUCATA.Controls.Add(Me.Label10)
        Me.fraCEDUCATA.Controls.Add(Me.Label11)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUPRARTE)
        Me.fraCEDUCATA.Controls.Add(Me.Label5)
        Me.fraCEDUCATA.Controls.Add(Me.cboOUPRESTA)
        Me.fraCEDUCATA.Controls.Add(Me.Label8)
        Me.fraCEDUCATA.Controls.Add(Me.cboOUPRZOPL)
        Me.fraCEDUCATA.Controls.Add(Me.lblOUPRZOPL)
        Me.fraCEDUCATA.Controls.Add(Me.Label7)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUPRUNPR)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUPREDIF)
        Me.fraCEDUCATA.Controls.Add(Me.Label1)
        Me.fraCEDUCATA.Controls.Add(Me.Label6)
        Me.fraCEDUCATA.Controls.Add(Me.cboOUPRCLSE)
        Me.fraCEDUCATA.Controls.Add(Me.lblOUPRCLSE)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUPRNUFI)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUPRMAIN)
        Me.fraCEDUCATA.Controls.Add(Me.Label2)
        Me.fraCEDUCATA.Controls.Add(Me.Label3)
        Me.fraCEDUCATA.Controls.Add(Me.Label4)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUPRCORR)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUPRMUNI)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUPRPRED)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUPRMANZ)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUPRBARR)
        Me.fraCEDUCATA.Controls.Add(Me.lblCodigoActual)
        Me.fraCEDUCATA.Controls.Add(Me.lblPredio)
        Me.fraCEDUCATA.Controls.Add(Me.lblManzana)
        Me.fraCEDUCATA.Controls.Add(Me.lblBarrio)
        Me.fraCEDUCATA.Controls.Add(Me.lblCorregimiento)
        Me.fraCEDUCATA.Controls.Add(Me.lblMunicipio)
        Me.fraCEDUCATA.Controls.Add(Me.lblCodigo)
        Me.fraCEDUCATA.Location = New System.Drawing.Point(12, 4)
        Me.fraCEDUCATA.Name = "fraCEDUCATA"
        Me.fraCEDUCATA.Size = New System.Drawing.Size(769, 292)
        Me.fraCEDUCATA.TabIndex = 350
        Me.fraCEDUCATA.TabStop = False
        Me.fraCEDUCATA.Text = "INSERTAR PREDIO"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(322, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(154, 20)
        Me.Label12.TabIndex = 430
        Me.Label12.Text = "Formato: ( 0000000 )"
        '
        'txtOUPRAVCA
        '
        Me.txtOUPRAVCA.AccessibleDescription = "Área de terreno"
        Me.txtOUPRAVCA.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUPRAVCA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUPRAVCA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUPRAVCA.ForeColor = System.Drawing.Color.Black
        Me.txtOUPRAVCA.Location = New System.Drawing.Point(144, 207)
        Me.txtOUPRAVCA.MaxLength = 12
        Me.txtOUPRAVCA.Name = "txtOUPRAVCA"
        Me.txtOUPRAVCA.Size = New System.Drawing.Size(172, 20)
        Me.txtOUPRAVCA.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(16, 207)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 20)
        Me.Label9.TabIndex = 429
        Me.Label9.Text = "Avalúo catastral"
        '
        'txtOUPRVACP
        '
        Me.txtOUPRVACP.AccessibleDescription = "Nro. Ficha predial"
        Me.txtOUPRVACP.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUPRVACP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUPRVACP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUPRVACP.ForeColor = System.Drawing.Color.Black
        Me.txtOUPRVACP.Location = New System.Drawing.Point(144, 184)
        Me.txtOUPRVACP.MaxLength = 12
        Me.txtOUPRVACP.Name = "txtOUPRVACP"
        Me.txtOUPRVACP.Size = New System.Drawing.Size(172, 20)
        Me.txtOUPRVACP.TabIndex = 13
        '
        'txtOUPRVATP
        '
        Me.txtOUPRVATP.AccessibleDescription = "Matricula"
        Me.txtOUPRVATP.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUPRVATP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUPRVATP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUPRVATP.ForeColor = System.Drawing.Color.Black
        Me.txtOUPRVATP.Location = New System.Drawing.Point(144, 161)
        Me.txtOUPRVATP.MaxLength = 12
        Me.txtOUPRVATP.Name = "txtOUPRVATP"
        Me.txtOUPRVATP.Size = New System.Drawing.Size(172, 20)
        Me.txtOUPRVATP.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(16, 184)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(125, 20)
        Me.Label10.TabIndex = 428
        Me.Label10.Text = "Valor const. privada"
        '
        'Label11
        '
        Me.Label11.AccessibleDescription = ""
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(16, 161)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(125, 20)
        Me.Label11.TabIndex = 427
        Me.Label11.Text = "Valor terreo privado"
        '
        'txtOUPRARTE
        '
        Me.txtOUPRARTE.AccessibleDescription = "Área de terreno"
        Me.txtOUPRARTE.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUPRARTE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUPRARTE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUPRARTE.ForeColor = System.Drawing.Color.Black
        Me.txtOUPRARTE.Location = New System.Drawing.Point(144, 138)
        Me.txtOUPRARTE.MaxLength = 9
        Me.txtOUPRARTE.Name = "txtOUPRARTE"
        Me.txtOUPRARTE.Size = New System.Drawing.Size(172, 20)
        Me.txtOUPRARTE.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(16, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 20)
        Me.Label5.TabIndex = 423
        Me.Label5.Text = "Área de terreno m2"
        '
        'cboOUPRESTA
        '
        Me.cboOUPRESTA.AccessibleDescription = "Estado"
        Me.cboOUPRESTA.BackColor = System.Drawing.Color.White
        Me.cboOUPRESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUPRESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUPRESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUPRESTA.Location = New System.Drawing.Point(144, 252)
        Me.cboOUPRESTA.MaxDropDownItems = 15
        Me.cboOUPRESTA.MaxLength = 1
        Me.cboOUPRESTA.Name = "cboOUPRESTA"
        Me.cboOUPRESTA.Size = New System.Drawing.Size(173, 22)
        Me.cboOUPRESTA.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(16, 253)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 20)
        Me.Label8.TabIndex = 421
        Me.Label8.Text = "Estado"
        '
        'cboOUPRZOPL
        '
        Me.cboOUPRZOPL.AccessibleDescription = "Zona de planificación"
        Me.cboOUPRZOPL.BackColor = System.Drawing.Color.White
        Me.cboOUPRZOPL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUPRZOPL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUPRZOPL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUPRZOPL.Location = New System.Drawing.Point(144, 229)
        Me.cboOUPRZOPL.MaxDropDownItems = 15
        Me.cboOUPRZOPL.MaxLength = 1
        Me.cboOUPRZOPL.Name = "cboOUPRZOPL"
        Me.cboOUPRZOPL.Size = New System.Drawing.Size(173, 22)
        Me.cboOUPRZOPL.TabIndex = 15
        '
        'lblOUPRZOPL
        '
        Me.lblOUPRZOPL.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblOUPRZOPL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOUPRZOPL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOUPRZOPL.ForeColor = System.Drawing.Color.Black
        Me.lblOUPRZOPL.Location = New System.Drawing.Point(320, 231)
        Me.lblOUPRZOPL.Name = "lblOUPRZOPL"
        Me.lblOUPRZOPL.Size = New System.Drawing.Size(260, 20)
        Me.lblOUPRZOPL.TabIndex = 419
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(16, 230)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 20)
        Me.Label7.TabIndex = 418
        Me.Label7.Text = "Zona de planificación"
        '
        'txtOUPRUNPR
        '
        Me.txtOUPRUNPR.AccessibleDescription = "Unidad predial"
        Me.txtOUPRUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUPRUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUPRUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUPRUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtOUPRUNPR.Location = New System.Drawing.Point(671, 69)
        Me.txtOUPRUNPR.MaxLength = 5
        Me.txtOUPRUNPR.Name = "txtOUPRUNPR"
        Me.txtOUPRUNPR.Size = New System.Drawing.Size(85, 20)
        Me.txtOUPRUNPR.TabIndex = 8
        '
        'txtOUPREDIF
        '
        Me.txtOUPREDIF.AccessibleDescription = "Edificio"
        Me.txtOUPREDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUPREDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUPREDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUPREDIF.ForeColor = System.Drawing.Color.Black
        Me.txtOUPREDIF.Location = New System.Drawing.Point(583, 69)
        Me.txtOUPREDIF.MaxLength = 3
        Me.txtOUPREDIF.Name = "txtOUPREDIF"
        Me.txtOUPREDIF.Size = New System.Drawing.Size(85, 20)
        Me.txtOUPREDIF.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(671, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 20)
        Me.Label1.TabIndex = 416
        Me.Label1.Text = "Unidad predial"
        '
        'Label6
        '
        Me.Label6.AccessibleDescription = ""
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(583, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 20)
        Me.Label6.TabIndex = 415
        Me.Label6.Text = "Edificio"
        '
        'cboOUPRCLSE
        '
        Me.cboOUPRCLSE.AccessibleDescription = "Clase o sector "
        Me.cboOUPRCLSE.BackColor = System.Drawing.Color.White
        Me.cboOUPRCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUPRCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUPRCLSE.Location = New System.Drawing.Point(144, 91)
        Me.cboOUPRCLSE.MaxDropDownItems = 15
        Me.cboOUPRCLSE.MaxLength = 1
        Me.cboOUPRCLSE.Name = "cboOUPRCLSE"
        Me.cboOUPRCLSE.Size = New System.Drawing.Size(173, 22)
        Me.cboOUPRCLSE.TabIndex = 9
        '
        'lblOUPRCLSE
        '
        Me.lblOUPRCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblOUPRCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOUPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOUPRCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblOUPRCLSE.Location = New System.Drawing.Point(320, 93)
        Me.lblOUPRCLSE.Name = "lblOUPRCLSE"
        Me.lblOUPRCLSE.Size = New System.Drawing.Size(261, 20)
        Me.lblOUPRCLSE.TabIndex = 410
        '
        'txtOUPRNUFI
        '
        Me.txtOUPRNUFI.AccessibleDescription = "Nro. Ficha predial"
        Me.txtOUPRNUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUPRNUFI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUPRNUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUPRNUFI.ForeColor = System.Drawing.Color.Black
        Me.txtOUPRNUFI.Location = New System.Drawing.Point(144, 115)
        Me.txtOUPRNUFI.MaxLength = 9
        Me.txtOUPRNUFI.Name = "txtOUPRNUFI"
        Me.txtOUPRNUFI.Size = New System.Drawing.Size(172, 20)
        Me.txtOUPRNUFI.TabIndex = 10
        '
        'txtOUPRMAIN
        '
        Me.txtOUPRMAIN.AccessibleDescription = "Matricula"
        Me.txtOUPRMAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUPRMAIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUPRMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUPRMAIN.ForeColor = System.Drawing.Color.Black
        Me.txtOUPRMAIN.Location = New System.Drawing.Point(144, 23)
        Me.txtOUPRMAIN.MaxLength = 7
        Me.txtOUPRMAIN.Name = "txtOUPRMAIN"
        Me.txtOUPRMAIN.Size = New System.Drawing.Size(172, 20)
        Me.txtOUPRMAIN.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 20)
        Me.Label2.TabIndex = 407
        Me.Label2.Text = "Nro. Ficha predial"
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = ""
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 20)
        Me.Label3.TabIndex = 406
        Me.Label3.Text = "Matricula inmobiliaria"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 20)
        Me.Label4.TabIndex = 405
        Me.Label4.Text = "Clase o Sector"
        '
        'txtOUPRCORR
        '
        Me.txtOUPRCORR.AccessibleDescription = "Corregimiento"
        Me.txtOUPRCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUPRCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUPRCORR.Location = New System.Drawing.Point(232, 69)
        Me.txtOUPRCORR.MaxLength = 2
        Me.txtOUPRCORR.Name = "txtOUPRCORR"
        Me.txtOUPRCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtOUPRCORR.TabIndex = 3
        '
        'txtOUPRMUNI
        '
        Me.txtOUPRMUNI.AccessibleDescription = "Municipio"
        Me.txtOUPRMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUPRMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUPRMUNI.Location = New System.Drawing.Point(144, 69)
        Me.txtOUPRMUNI.MaxLength = 3
        Me.txtOUPRMUNI.Name = "txtOUPRMUNI"
        Me.txtOUPRMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtOUPRMUNI.TabIndex = 2
        '
        'txtOUPRPRED
        '
        Me.txtOUPRPRED.AccessibleDescription = "Predio "
        Me.txtOUPRPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUPRPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUPRPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUPRPRED.ForeColor = System.Drawing.Color.Black
        Me.txtOUPRPRED.Location = New System.Drawing.Point(496, 69)
        Me.txtOUPRPRED.MaxLength = 5
        Me.txtOUPRPRED.Name = "txtOUPRPRED"
        Me.txtOUPRPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtOUPRPRED.TabIndex = 6
        '
        'txtOUPRMANZ
        '
        Me.txtOUPRMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtOUPRMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUPRMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUPRMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUPRMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtOUPRMANZ.Location = New System.Drawing.Point(408, 69)
        Me.txtOUPRMANZ.MaxLength = 3
        Me.txtOUPRMANZ.Name = "txtOUPRMANZ"
        Me.txtOUPRMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtOUPRMANZ.TabIndex = 5
        '
        'txtOUPRBARR
        '
        Me.txtOUPRBARR.AccessibleDescription = "Barrio "
        Me.txtOUPRBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUPRBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUPRBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUPRBARR.ForeColor = System.Drawing.Color.Black
        Me.txtOUPRBARR.Location = New System.Drawing.Point(320, 69)
        Me.txtOUPRBARR.MaxLength = 3
        Me.txtOUPRBARR.Name = "txtOUPRBARR"
        Me.txtOUPRBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtOUPRBARR.TabIndex = 4
        '
        'lblCodigoActual
        '
        Me.lblCodigoActual.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigoActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigoActual.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoActual.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoActual.Location = New System.Drawing.Point(16, 69)
        Me.lblCodigoActual.Name = "lblCodigoActual"
        Me.lblCodigoActual.Size = New System.Drawing.Size(125, 20)
        Me.lblCodigoActual.TabIndex = 395
        Me.lblCodigoActual.Text = "Código Actual"
        '
        'lblPredio
        '
        Me.lblPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredio.ForeColor = System.Drawing.Color.Black
        Me.lblPredio.Location = New System.Drawing.Point(496, 46)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(84, 20)
        Me.lblPredio.TabIndex = 394
        Me.lblPredio.Text = "Predio"
        '
        'lblManzana
        '
        Me.lblManzana.AccessibleDescription = ""
        Me.lblManzana.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblManzana.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblManzana.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManzana.ForeColor = System.Drawing.Color.Black
        Me.lblManzana.Location = New System.Drawing.Point(408, 46)
        Me.lblManzana.Name = "lblManzana"
        Me.lblManzana.Size = New System.Drawing.Size(84, 20)
        Me.lblManzana.TabIndex = 393
        Me.lblManzana.Text = "Manza / Vered"
        '
        'lblBarrio
        '
        Me.lblBarrio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblBarrio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBarrio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarrio.ForeColor = System.Drawing.Color.Black
        Me.lblBarrio.Location = New System.Drawing.Point(320, 46)
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Size = New System.Drawing.Size(84, 20)
        Me.lblBarrio.TabIndex = 392
        Me.lblBarrio.Text = "Barrio"
        '
        'lblCorregimiento
        '
        Me.lblCorregimiento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCorregimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorregimiento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorregimiento.ForeColor = System.Drawing.Color.Black
        Me.lblCorregimiento.Location = New System.Drawing.Point(232, 46)
        Me.lblCorregimiento.Name = "lblCorregimiento"
        Me.lblCorregimiento.Size = New System.Drawing.Size(84, 20)
        Me.lblCorregimiento.TabIndex = 396
        Me.lblCorregimiento.Text = "Corregimiento"
        '
        'lblMunicipio
        '
        Me.lblMunicipio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblMunicipio.Location = New System.Drawing.Point(144, 46)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(84, 20)
        Me.lblMunicipio.TabIndex = 398
        Me.lblMunicipio.Text = "Municipio"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(16, 46)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(125, 20)
        Me.lblCodigo.TabIndex = 399
        Me.lblCodigo.Text = "Cedula catastral"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbdOUPRARRE)
        Me.GroupBox1.Controls.Add(Me.rbdOUPRARCA)
        Me.GroupBox1.Location = New System.Drawing.Point(320, 116)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(260, 66)
        Me.GroupBox1.TabIndex = 431
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FUENTE DEL ÁREA DE TERRENO"
        '
        'rbdOUPRARCA
        '
        Me.rbdOUPRARCA.Checked = True
        Me.rbdOUPRARCA.Location = New System.Drawing.Point(26, 25)
        Me.rbdOUPRARCA.Name = "rbdOUPRARCA"
        Me.rbdOUPRARCA.Size = New System.Drawing.Size(93, 24)
        Me.rbdOUPRARCA.TabIndex = 0
        Me.rbdOUPRARCA.TabStop = True
        Me.rbdOUPRARCA.Text = "Catastro"
        Me.rbdOUPRARCA.UseVisualStyleBackColor = True
        '
        'rbdOUPRARRE
        '
        Me.rbdOUPRARRE.Location = New System.Drawing.Point(145, 25)
        Me.rbdOUPRARRE.Name = "rbdOUPRARRE"
        Me.rbdOUPRARRE.Size = New System.Drawing.Size(95, 24)
        Me.rbdOUPRARRE.TabIndex = 1
        Me.rbdOUPRARRE.Text = "Registro"
        Me.rbdOUPRARRE.UseVisualStyleBackColor = True
        '
        'frm_insertar_OBURPRED
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 387)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCEDUCATA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(810, 423)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(810, 423)
        Me.Name = "frm_insertar_OBURPRED"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox2.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraCEDUCATA.ResumeLayout(False)
        Me.fraCEDUCATA.PerformLayout()
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
    Friend WithEvents txtOUPRUNPR As System.Windows.Forms.TextBox
    Friend WithEvents txtOUPREDIF As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboOUPRCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblOUPRCLSE As System.Windows.Forms.Label
    Friend WithEvents txtOUPRNUFI As System.Windows.Forms.TextBox
    Friend WithEvents txtOUPRMAIN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtOUPRCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtOUPRMUNI As System.Windows.Forms.TextBox
    Friend WithEvents txtOUPRPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtOUPRMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtOUPRBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents cboOUPRESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboOUPRZOPL As System.Windows.Forms.ComboBox
    Friend WithEvents lblOUPRZOPL As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtOUPRARTE As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtOUPRAVCA As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtOUPRVACP As System.Windows.Forms.TextBox
    Friend WithEvents txtOUPRVATP As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdOUPRARRE As System.Windows.Forms.RadioButton
    Friend WithEvents rbdOUPRARCA As System.Windows.Forms.RadioButton
End Class
