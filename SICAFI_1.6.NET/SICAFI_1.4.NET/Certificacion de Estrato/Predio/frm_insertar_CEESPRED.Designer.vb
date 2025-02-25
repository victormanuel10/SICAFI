<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_CEESPRED
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_insertar_CEESPRED))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraCEDUCATA = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkCEPRPRPH = New System.Windows.Forms.CheckBox()
        Me.nudCEPRUNID = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCEPRDIPR = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboCEPRSEPU = New System.Windows.Forms.ComboBox()
        Me.lblCEPRSEPU = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCEPRAVCA = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCEPRVACP = New System.Windows.Forms.TextBox()
        Me.txtCEPRVATP = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCEPRARTE = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboCEPRESTA = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboCEPRZOPL = New System.Windows.Forms.ComboBox()
        Me.lblCEPRZOPL = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCEPRUNPR = New System.Windows.Forms.TextBox()
        Me.txtCEPREDIF = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboCEPRCLSE = New System.Windows.Forms.ComboBox()
        Me.lblCEPRCLSE = New System.Windows.Forms.Label()
        Me.txtCEPRNUFI = New System.Windows.Forms.TextBox()
        Me.txtCEPRMAIN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCEPRCORR = New System.Windows.Forms.TextBox()
        Me.txtCEPRMUNI = New System.Windows.Forms.TextBox()
        Me.txtCEPRPRED = New System.Windows.Forms.TextBox()
        Me.txtCEPRMANZ = New System.Windows.Forms.TextBox()
        Me.txtCEPRBARR = New System.Windows.Forms.TextBox()
        Me.lblCodigoActual = New System.Windows.Forms.Label()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.lblManzana = New System.Windows.Forms.Label()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraCEDUCATA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudCEPRUNID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdSALIR)
        Me.GroupBox2.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 418)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(769, 46)
        Me.GroupBox2.TabIndex = 354
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 487)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(794, 25)
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
        Me.fraCEDUCATA.Controls.Add(Me.GroupBox1)
        Me.fraCEDUCATA.Controls.Add(Me.nudCEPRUNID)
        Me.fraCEDUCATA.Controls.Add(Me.Label13)
        Me.fraCEDUCATA.Controls.Add(Me.txtCEPRDIPR)
        Me.fraCEDUCATA.Controls.Add(Me.Label15)
        Me.fraCEDUCATA.Controls.Add(Me.cboCEPRSEPU)
        Me.fraCEDUCATA.Controls.Add(Me.lblCEPRSEPU)
        Me.fraCEDUCATA.Controls.Add(Me.Label14)
        Me.fraCEDUCATA.Controls.Add(Me.Label12)
        Me.fraCEDUCATA.Controls.Add(Me.txtCEPRAVCA)
        Me.fraCEDUCATA.Controls.Add(Me.Label9)
        Me.fraCEDUCATA.Controls.Add(Me.txtCEPRVACP)
        Me.fraCEDUCATA.Controls.Add(Me.txtCEPRVATP)
        Me.fraCEDUCATA.Controls.Add(Me.Label10)
        Me.fraCEDUCATA.Controls.Add(Me.Label11)
        Me.fraCEDUCATA.Controls.Add(Me.txtCEPRARTE)
        Me.fraCEDUCATA.Controls.Add(Me.Label5)
        Me.fraCEDUCATA.Controls.Add(Me.cboCEPRESTA)
        Me.fraCEDUCATA.Controls.Add(Me.Label8)
        Me.fraCEDUCATA.Controls.Add(Me.cboCEPRZOPL)
        Me.fraCEDUCATA.Controls.Add(Me.lblCEPRZOPL)
        Me.fraCEDUCATA.Controls.Add(Me.Label7)
        Me.fraCEDUCATA.Controls.Add(Me.txtCEPRUNPR)
        Me.fraCEDUCATA.Controls.Add(Me.txtCEPREDIF)
        Me.fraCEDUCATA.Controls.Add(Me.Label1)
        Me.fraCEDUCATA.Controls.Add(Me.Label6)
        Me.fraCEDUCATA.Controls.Add(Me.cboCEPRCLSE)
        Me.fraCEDUCATA.Controls.Add(Me.lblCEPRCLSE)
        Me.fraCEDUCATA.Controls.Add(Me.txtCEPRNUFI)
        Me.fraCEDUCATA.Controls.Add(Me.txtCEPRMAIN)
        Me.fraCEDUCATA.Controls.Add(Me.Label2)
        Me.fraCEDUCATA.Controls.Add(Me.Label3)
        Me.fraCEDUCATA.Controls.Add(Me.Label4)
        Me.fraCEDUCATA.Controls.Add(Me.txtCEPRCORR)
        Me.fraCEDUCATA.Controls.Add(Me.txtCEPRMUNI)
        Me.fraCEDUCATA.Controls.Add(Me.txtCEPRPRED)
        Me.fraCEDUCATA.Controls.Add(Me.txtCEPRMANZ)
        Me.fraCEDUCATA.Controls.Add(Me.txtCEPRBARR)
        Me.fraCEDUCATA.Controls.Add(Me.lblCodigoActual)
        Me.fraCEDUCATA.Controls.Add(Me.lblPredio)
        Me.fraCEDUCATA.Controls.Add(Me.lblManzana)
        Me.fraCEDUCATA.Controls.Add(Me.lblBarrio)
        Me.fraCEDUCATA.Controls.Add(Me.lblCorregimiento)
        Me.fraCEDUCATA.Controls.Add(Me.lblMunicipio)
        Me.fraCEDUCATA.Controls.Add(Me.lblCodigo)
        Me.fraCEDUCATA.Location = New System.Drawing.Point(12, 7)
        Me.fraCEDUCATA.Name = "fraCEDUCATA"
        Me.fraCEDUCATA.Size = New System.Drawing.Size(769, 405)
        Me.fraCEDUCATA.TabIndex = 353
        Me.fraCEDUCATA.TabStop = False
        Me.fraCEDUCATA.Text = "INSERTAR PREDIO"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkCEPRPRPH)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 346)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(740, 42)
        Me.GroupBox1.TabIndex = 439
        Me.GroupBox1.TabStop = False
        '
        'chkCEPRPRPH
        '
        Me.chkCEPRPRPH.AccessibleDescription = "Predio RPH"
        Me.chkCEPRPRPH.Location = New System.Drawing.Point(17, 13)
        Me.chkCEPRPRPH.Name = "chkCEPRPRPH"
        Me.chkCEPRPRPH.Size = New System.Drawing.Size(300, 24)
        Me.chkCEPRPRPH.TabIndex = 438
        Me.chkCEPRPRPH.Text = "Predio sometido a Reglamento de Propiedad Horizontal"
        Me.chkCEPRPRPH.UseVisualStyleBackColor = True
        '
        'nudCEPRUNID
        '
        Me.nudCEPRUNID.AccessibleDescription = "Nro. Unidades"
        Me.nudCEPRUNID.Location = New System.Drawing.Point(144, 138)
        Me.nudCEPRUNID.Name = "nudCEPRUNID"
        Me.nudCEPRUNID.Size = New System.Drawing.Size(172, 20)
        Me.nudCEPRUNID.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(16, 138)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(125, 20)
        Me.Label13.TabIndex = 437
        Me.Label13.Text = "Nro. Unidades"
        '
        'txtCEPRDIPR
        '
        Me.txtCEPRDIPR.AccessibleDescription = "Dirección de predio"
        Me.txtCEPRDIPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEPRDIPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCEPRDIPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEPRDIPR.ForeColor = System.Drawing.Color.Black
        Me.txtCEPRDIPR.Location = New System.Drawing.Point(144, 115)
        Me.txtCEPRDIPR.MaxLength = 9
        Me.txtCEPRDIPR.Name = "txtCEPRDIPR"
        Me.txtCEPRDIPR.Size = New System.Drawing.Size(348, 20)
        Me.txtCEPRDIPR.TabIndex = 10
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(16, 115)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(125, 20)
        Me.Label15.TabIndex = 436
        Me.Label15.Text = "Dirección de predio"
        '
        'cboCEPRSEPU
        '
        Me.cboCEPRSEPU.AccessibleDescription = "Servicios públicos"
        Me.cboCEPRSEPU.BackColor = System.Drawing.Color.White
        Me.cboCEPRSEPU.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCEPRSEPU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCEPRSEPU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCEPRSEPU.Location = New System.Drawing.Point(144, 298)
        Me.cboCEPRSEPU.MaxDropDownItems = 15
        Me.cboCEPRSEPU.MaxLength = 1
        Me.cboCEPRSEPU.Name = "cboCEPRSEPU"
        Me.cboCEPRSEPU.Size = New System.Drawing.Size(173, 22)
        Me.cboCEPRSEPU.TabIndex = 18
        '
        'lblCEPRSEPU
        '
        Me.lblCEPRSEPU.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCEPRSEPU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCEPRSEPU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCEPRSEPU.ForeColor = System.Drawing.Color.Black
        Me.lblCEPRSEPU.Location = New System.Drawing.Point(320, 300)
        Me.lblCEPRSEPU.Name = "lblCEPRSEPU"
        Me.lblCEPRSEPU.Size = New System.Drawing.Size(172, 20)
        Me.lblCEPRSEPU.TabIndex = 433
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(16, 299)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(125, 20)
        Me.Label14.TabIndex = 432
        Me.Label14.Text = "Servicios"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(322, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(154, 20)
        Me.Label12.TabIndex = 430
        Me.Label12.Text = "Formato: ( 0000000 )"
        '
        'txtCEPRAVCA
        '
        Me.txtCEPRAVCA.AccessibleDescription = "Área de terreno"
        Me.txtCEPRAVCA.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEPRAVCA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCEPRAVCA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEPRAVCA.ForeColor = System.Drawing.Color.Black
        Me.txtCEPRAVCA.Location = New System.Drawing.Point(144, 253)
        Me.txtCEPRAVCA.MaxLength = 12
        Me.txtCEPRAVCA.Name = "txtCEPRAVCA"
        Me.txtCEPRAVCA.Size = New System.Drawing.Size(172, 20)
        Me.txtCEPRAVCA.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(16, 253)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 20)
        Me.Label9.TabIndex = 429
        Me.Label9.Text = "Avalúo catastral"
        '
        'txtCEPRVACP
        '
        Me.txtCEPRVACP.AccessibleDescription = "Nro. Ficha predial"
        Me.txtCEPRVACP.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEPRVACP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCEPRVACP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEPRVACP.ForeColor = System.Drawing.Color.Black
        Me.txtCEPRVACP.Location = New System.Drawing.Point(144, 230)
        Me.txtCEPRVACP.MaxLength = 12
        Me.txtCEPRVACP.Name = "txtCEPRVACP"
        Me.txtCEPRVACP.Size = New System.Drawing.Size(172, 20)
        Me.txtCEPRVACP.TabIndex = 15
        '
        'txtCEPRVATP
        '
        Me.txtCEPRVATP.AccessibleDescription = "Matricula"
        Me.txtCEPRVATP.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEPRVATP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCEPRVATP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEPRVATP.ForeColor = System.Drawing.Color.Black
        Me.txtCEPRVATP.Location = New System.Drawing.Point(144, 207)
        Me.txtCEPRVATP.MaxLength = 12
        Me.txtCEPRVATP.Name = "txtCEPRVATP"
        Me.txtCEPRVATP.Size = New System.Drawing.Size(172, 20)
        Me.txtCEPRVATP.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(16, 230)
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
        Me.Label11.Location = New System.Drawing.Point(16, 207)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(125, 20)
        Me.Label11.TabIndex = 427
        Me.Label11.Text = "Valor terreo privado"
        '
        'txtCEPRARTE
        '
        Me.txtCEPRARTE.AccessibleDescription = "Área de terreno"
        Me.txtCEPRARTE.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEPRARTE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCEPRARTE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEPRARTE.ForeColor = System.Drawing.Color.Black
        Me.txtCEPRARTE.Location = New System.Drawing.Point(144, 184)
        Me.txtCEPRARTE.MaxLength = 9
        Me.txtCEPRARTE.Name = "txtCEPRARTE"
        Me.txtCEPRARTE.Size = New System.Drawing.Size(172, 20)
        Me.txtCEPRARTE.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(16, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 20)
        Me.Label5.TabIndex = 423
        Me.Label5.Text = "Área de terreno m2"
        '
        'cboCEPRESTA
        '
        Me.cboCEPRESTA.AccessibleDescription = "Estado"
        Me.cboCEPRESTA.BackColor = System.Drawing.Color.White
        Me.cboCEPRESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCEPRESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCEPRESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCEPRESTA.Location = New System.Drawing.Point(144, 321)
        Me.cboCEPRESTA.MaxDropDownItems = 15
        Me.cboCEPRESTA.MaxLength = 1
        Me.cboCEPRESTA.Name = "cboCEPRESTA"
        Me.cboCEPRESTA.Size = New System.Drawing.Size(173, 22)
        Me.cboCEPRESTA.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(16, 322)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 20)
        Me.Label8.TabIndex = 421
        Me.Label8.Text = "Estado"
        '
        'cboCEPRZOPL
        '
        Me.cboCEPRZOPL.AccessibleDescription = "Zona de planificación"
        Me.cboCEPRZOPL.BackColor = System.Drawing.Color.White
        Me.cboCEPRZOPL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCEPRZOPL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCEPRZOPL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCEPRZOPL.Location = New System.Drawing.Point(144, 275)
        Me.cboCEPRZOPL.MaxDropDownItems = 15
        Me.cboCEPRZOPL.MaxLength = 1
        Me.cboCEPRZOPL.Name = "cboCEPRZOPL"
        Me.cboCEPRZOPL.Size = New System.Drawing.Size(173, 22)
        Me.cboCEPRZOPL.TabIndex = 17
        '
        'lblCEPRZOPL
        '
        Me.lblCEPRZOPL.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCEPRZOPL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCEPRZOPL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCEPRZOPL.ForeColor = System.Drawing.Color.Black
        Me.lblCEPRZOPL.Location = New System.Drawing.Point(320, 277)
        Me.lblCEPRZOPL.Name = "lblCEPRZOPL"
        Me.lblCEPRZOPL.Size = New System.Drawing.Size(172, 20)
        Me.lblCEPRZOPL.TabIndex = 419
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(16, 276)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 20)
        Me.Label7.TabIndex = 418
        Me.Label7.Text = "Zona de planificación"
        '
        'txtCEPRUNPR
        '
        Me.txtCEPRUNPR.AccessibleDescription = "Unidad predial"
        Me.txtCEPRUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEPRUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCEPRUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEPRUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtCEPRUNPR.Location = New System.Drawing.Point(671, 69)
        Me.txtCEPRUNPR.MaxLength = 5
        Me.txtCEPRUNPR.Name = "txtCEPRUNPR"
        Me.txtCEPRUNPR.Size = New System.Drawing.Size(85, 20)
        Me.txtCEPRUNPR.TabIndex = 8
        '
        'txtCEPREDIF
        '
        Me.txtCEPREDIF.AccessibleDescription = "Edificio"
        Me.txtCEPREDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEPREDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCEPREDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEPREDIF.ForeColor = System.Drawing.Color.Black
        Me.txtCEPREDIF.Location = New System.Drawing.Point(583, 69)
        Me.txtCEPREDIF.MaxLength = 3
        Me.txtCEPREDIF.Name = "txtCEPREDIF"
        Me.txtCEPREDIF.Size = New System.Drawing.Size(85, 20)
        Me.txtCEPREDIF.TabIndex = 7
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
        'cboCEPRCLSE
        '
        Me.cboCEPRCLSE.AccessibleDescription = "Clase o sector "
        Me.cboCEPRCLSE.BackColor = System.Drawing.Color.White
        Me.cboCEPRCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboCEPRCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCEPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCEPRCLSE.Location = New System.Drawing.Point(144, 91)
        Me.cboCEPRCLSE.MaxDropDownItems = 15
        Me.cboCEPRCLSE.MaxLength = 1
        Me.cboCEPRCLSE.Name = "cboCEPRCLSE"
        Me.cboCEPRCLSE.Size = New System.Drawing.Size(173, 22)
        Me.cboCEPRCLSE.TabIndex = 9
        '
        'lblCEPRCLSE
        '
        Me.lblCEPRCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCEPRCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCEPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCEPRCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblCEPRCLSE.Location = New System.Drawing.Point(320, 93)
        Me.lblCEPRCLSE.Name = "lblCEPRCLSE"
        Me.lblCEPRCLSE.Size = New System.Drawing.Size(172, 20)
        Me.lblCEPRCLSE.TabIndex = 410
        '
        'txtCEPRNUFI
        '
        Me.txtCEPRNUFI.AccessibleDescription = "Nro. Ficha predial"
        Me.txtCEPRNUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEPRNUFI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCEPRNUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEPRNUFI.ForeColor = System.Drawing.Color.Black
        Me.txtCEPRNUFI.Location = New System.Drawing.Point(144, 161)
        Me.txtCEPRNUFI.MaxLength = 9
        Me.txtCEPRNUFI.Name = "txtCEPRNUFI"
        Me.txtCEPRNUFI.Size = New System.Drawing.Size(172, 20)
        Me.txtCEPRNUFI.TabIndex = 12
        '
        'txtCEPRMAIN
        '
        Me.txtCEPRMAIN.AccessibleDescription = "Matricula"
        Me.txtCEPRMAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEPRMAIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCEPRMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEPRMAIN.ForeColor = System.Drawing.Color.Black
        Me.txtCEPRMAIN.Location = New System.Drawing.Point(144, 23)
        Me.txtCEPRMAIN.MaxLength = 7
        Me.txtCEPRMAIN.Name = "txtCEPRMAIN"
        Me.txtCEPRMAIN.Size = New System.Drawing.Size(172, 20)
        Me.txtCEPRMAIN.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 161)
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
        'txtCEPRCORR
        '
        Me.txtCEPRCORR.AccessibleDescription = "Corregimiento"
        Me.txtCEPRCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEPRCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEPRCORR.Location = New System.Drawing.Point(232, 69)
        Me.txtCEPRCORR.MaxLength = 2
        Me.txtCEPRCORR.Name = "txtCEPRCORR"
        Me.txtCEPRCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtCEPRCORR.TabIndex = 3
        '
        'txtCEPRMUNI
        '
        Me.txtCEPRMUNI.AccessibleDescription = "Municipio"
        Me.txtCEPRMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEPRMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEPRMUNI.Location = New System.Drawing.Point(144, 69)
        Me.txtCEPRMUNI.MaxLength = 3
        Me.txtCEPRMUNI.Name = "txtCEPRMUNI"
        Me.txtCEPRMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtCEPRMUNI.TabIndex = 2
        '
        'txtCEPRPRED
        '
        Me.txtCEPRPRED.AccessibleDescription = "Predio "
        Me.txtCEPRPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEPRPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCEPRPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEPRPRED.ForeColor = System.Drawing.Color.Black
        Me.txtCEPRPRED.Location = New System.Drawing.Point(496, 69)
        Me.txtCEPRPRED.MaxLength = 5
        Me.txtCEPRPRED.Name = "txtCEPRPRED"
        Me.txtCEPRPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtCEPRPRED.TabIndex = 6
        '
        'txtCEPRMANZ
        '
        Me.txtCEPRMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtCEPRMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEPRMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCEPRMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEPRMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtCEPRMANZ.Location = New System.Drawing.Point(408, 69)
        Me.txtCEPRMANZ.MaxLength = 3
        Me.txtCEPRMANZ.Name = "txtCEPRMANZ"
        Me.txtCEPRMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtCEPRMANZ.TabIndex = 5
        '
        'txtCEPRBARR
        '
        Me.txtCEPRBARR.AccessibleDescription = "Barrio "
        Me.txtCEPRBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEPRBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCEPRBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEPRBARR.ForeColor = System.Drawing.Color.Black
        Me.txtCEPRBARR.Location = New System.Drawing.Point(320, 69)
        Me.txtCEPRBARR.MaxLength = 3
        Me.txtCEPRBARR.Name = "txtCEPRBARR"
        Me.txtCEPRBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtCEPRBARR.TabIndex = 4
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
        'frm_insertar_CEESPRED
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 512)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCEDUCATA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(810, 548)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(810, 548)
        Me.Name = "frm_insertar_CEESPRED"
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
        CType(Me.nudCEPRUNID, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCEPRAVCA As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCEPRVACP As System.Windows.Forms.TextBox
    Friend WithEvents txtCEPRVATP As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCEPRARTE As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboCEPRESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboCEPRZOPL As System.Windows.Forms.ComboBox
    Friend WithEvents lblCEPRZOPL As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCEPRUNPR As System.Windows.Forms.TextBox
    Friend WithEvents txtCEPREDIF As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboCEPRCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblCEPRCLSE As System.Windows.Forms.Label
    Friend WithEvents txtCEPRNUFI As System.Windows.Forms.TextBox
    Friend WithEvents txtCEPRMAIN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCEPRCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtCEPRMUNI As System.Windows.Forms.TextBox
    Friend WithEvents txtCEPRPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtCEPRMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtCEPRBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents nudCEPRUNID As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCEPRDIPR As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboCEPRSEPU As System.Windows.Forms.ComboBox
    Friend WithEvents lblCEPRSEPU As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkCEPRPRPH As System.Windows.Forms.CheckBox
End Class
