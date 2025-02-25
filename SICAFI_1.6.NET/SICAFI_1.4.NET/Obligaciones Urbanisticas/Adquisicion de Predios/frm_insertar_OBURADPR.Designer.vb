<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_OBURADPR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_insertar_OBURADPR))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraCEDUCATA = New System.Windows.Forms.GroupBox()
        Me.txtOUAPDIRE = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboOUAPCLOU = New System.Windows.Forms.ComboBox()
        Me.lblOUAPCLOU = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblOUAPNDSU = New System.Windows.Forms.Label()
        Me.txtOUAPOBSE = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtOUAPDESC = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtOUAPVACO = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtOUAPAVCO = New System.Windows.Forms.TextBox()
        Me.txtOUAPAVCA = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtOUAPARTE = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboOUAPESTA = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboOUAPSUPE = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtOUAPUNPR = New System.Windows.Forms.TextBox()
        Me.txtOUAPEDIF = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboOUAPCLSE = New System.Windows.Forms.ComboBox()
        Me.txtOUAPNUOF = New System.Windows.Forms.TextBox()
        Me.txtOUAPMAIN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtOUAPCORR = New System.Windows.Forms.TextBox()
        Me.txtOUAPMUNI = New System.Windows.Forms.TextBox()
        Me.txtOUAPPRED = New System.Windows.Forms.TextBox()
        Me.txtOUAPMANZ = New System.Windows.Forms.TextBox()
        Me.txtOUAPBARR = New System.Windows.Forms.TextBox()
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
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdSALIR)
        Me.GroupBox2.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 403)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 465)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(797, 25)
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
        Me.fraCEDUCATA.Controls.Add(Me.txtOUAPDIRE)
        Me.fraCEDUCATA.Controls.Add(Me.Label16)
        Me.fraCEDUCATA.Controls.Add(Me.cboOUAPCLOU)
        Me.fraCEDUCATA.Controls.Add(Me.lblOUAPCLOU)
        Me.fraCEDUCATA.Controls.Add(Me.Label15)
        Me.fraCEDUCATA.Controls.Add(Me.lblOUAPNDSU)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUAPOBSE)
        Me.fraCEDUCATA.Controls.Add(Me.Label13)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUAPDESC)
        Me.fraCEDUCATA.Controls.Add(Me.Label14)
        Me.fraCEDUCATA.Controls.Add(Me.Label12)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUAPVACO)
        Me.fraCEDUCATA.Controls.Add(Me.Label9)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUAPAVCO)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUAPAVCA)
        Me.fraCEDUCATA.Controls.Add(Me.Label10)
        Me.fraCEDUCATA.Controls.Add(Me.Label11)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUAPARTE)
        Me.fraCEDUCATA.Controls.Add(Me.Label5)
        Me.fraCEDUCATA.Controls.Add(Me.cboOUAPESTA)
        Me.fraCEDUCATA.Controls.Add(Me.Label8)
        Me.fraCEDUCATA.Controls.Add(Me.cboOUAPSUPE)
        Me.fraCEDUCATA.Controls.Add(Me.Label7)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUAPUNPR)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUAPEDIF)
        Me.fraCEDUCATA.Controls.Add(Me.Label1)
        Me.fraCEDUCATA.Controls.Add(Me.Label6)
        Me.fraCEDUCATA.Controls.Add(Me.cboOUAPCLSE)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUAPNUOF)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUAPMAIN)
        Me.fraCEDUCATA.Controls.Add(Me.Label2)
        Me.fraCEDUCATA.Controls.Add(Me.Label3)
        Me.fraCEDUCATA.Controls.Add(Me.Label4)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUAPCORR)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUAPMUNI)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUAPPRED)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUAPMANZ)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUAPBARR)
        Me.fraCEDUCATA.Controls.Add(Me.lblCodigoActual)
        Me.fraCEDUCATA.Controls.Add(Me.lblPredio)
        Me.fraCEDUCATA.Controls.Add(Me.lblManzana)
        Me.fraCEDUCATA.Controls.Add(Me.lblBarrio)
        Me.fraCEDUCATA.Controls.Add(Me.lblCorregimiento)
        Me.fraCEDUCATA.Controls.Add(Me.lblMunicipio)
        Me.fraCEDUCATA.Controls.Add(Me.lblCodigo)
        Me.fraCEDUCATA.Location = New System.Drawing.Point(12, 8)
        Me.fraCEDUCATA.Name = "fraCEDUCATA"
        Me.fraCEDUCATA.Size = New System.Drawing.Size(769, 389)
        Me.fraCEDUCATA.TabIndex = 353
        Me.fraCEDUCATA.TabStop = False
        Me.fraCEDUCATA.Text = "INSERTAR ADQUISICIÓN DE PREDIO"
        '
        'txtOUAPDIRE
        '
        Me.txtOUAPDIRE.AccessibleDescription = "Dirección"
        Me.txtOUAPDIRE.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUAPDIRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUAPDIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUAPDIRE.ForeColor = System.Drawing.Color.Black
        Me.txtOUAPDIRE.Location = New System.Drawing.Point(144, 115)
        Me.txtOUAPDIRE.MaxLength = 50
        Me.txtOUAPDIRE.Name = "txtOUAPDIRE"
        Me.txtOUAPDIRE.Size = New System.Drawing.Size(436, 20)
        Me.txtOUAPDIRE.TabIndex = 10
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(16, 115)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(125, 20)
        Me.Label16.TabIndex = 440
        Me.Label16.Text = "Dirección"
        '
        'cboOUAPCLOU
        '
        Me.cboOUAPCLOU.AccessibleDescription = "Clase de obligación"
        Me.cboOUAPCLOU.BackColor = System.Drawing.Color.White
        Me.cboOUAPCLOU.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUAPCLOU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUAPCLOU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUAPCLOU.Location = New System.Drawing.Point(144, 136)
        Me.cboOUAPCLOU.MaxDropDownItems = 15
        Me.cboOUAPCLOU.MaxLength = 1
        Me.cboOUAPCLOU.Name = "cboOUAPCLOU"
        Me.cboOUAPCLOU.Size = New System.Drawing.Size(436, 22)
        Me.cboOUAPCLOU.TabIndex = 11
        '
        'lblOUAPCLOU
        '
        Me.lblOUAPCLOU.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblOUAPCLOU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOUAPCLOU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOUAPCLOU.ForeColor = System.Drawing.Color.Black
        Me.lblOUAPCLOU.Location = New System.Drawing.Point(583, 138)
        Me.lblOUAPCLOU.Name = "lblOUAPCLOU"
        Me.lblOUAPCLOU.Size = New System.Drawing.Size(173, 20)
        Me.lblOUAPCLOU.TabIndex = 438
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(16, 138)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(125, 20)
        Me.Label15.TabIndex = 437
        Me.Label15.Text = "Clase de obligación"
        '
        'lblOUAPNDSU
        '
        Me.lblOUAPNDSU.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblOUAPNDSU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOUAPNDSU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOUAPNDSU.ForeColor = System.Drawing.Color.Black
        Me.lblOUAPNDSU.Location = New System.Drawing.Point(583, 185)
        Me.lblOUAPNDSU.Name = "lblOUAPNDSU"
        Me.lblOUAPNDSU.Size = New System.Drawing.Size(173, 20)
        Me.lblOUAPNDSU.TabIndex = 435
        '
        'txtOUAPOBSE
        '
        Me.txtOUAPOBSE.AccessibleDescription = "Observaciones"
        Me.txtOUAPOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUAPOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUAPOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUAPOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtOUAPOBSE.Location = New System.Drawing.Point(144, 322)
        Me.txtOUAPOBSE.MaxLength = 3000
        Me.txtOUAPOBSE.Name = "txtOUAPOBSE"
        Me.txtOUAPOBSE.Size = New System.Drawing.Size(612, 20)
        Me.txtOUAPOBSE.TabIndex = 19
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(16, 322)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(125, 20)
        Me.Label13.TabIndex = 434
        Me.Label13.Text = "Observaciones"
        '
        'txtOUAPDESC
        '
        Me.txtOUAPDESC.AccessibleDescription = "Descripción"
        Me.txtOUAPDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUAPDESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUAPDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUAPDESC.ForeColor = System.Drawing.Color.Black
        Me.txtOUAPDESC.Location = New System.Drawing.Point(144, 299)
        Me.txtOUAPDESC.MaxLength = 1000
        Me.txtOUAPDESC.Name = "txtOUAPDESC"
        Me.txtOUAPDESC.Size = New System.Drawing.Size(612, 20)
        Me.txtOUAPDESC.TabIndex = 18
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
        Me.Label14.TabIndex = 433
        Me.Label14.Text = "Descripción"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(322, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(154, 20)
        Me.Label12.TabIndex = 430
        Me.Label12.Text = "Formato: ( 0000000 )"
        '
        'txtOUAPVACO
        '
        Me.txtOUAPVACO.AccessibleDescription = "Valor compra"
        Me.txtOUAPVACO.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUAPVACO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUAPVACO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUAPVACO.ForeColor = System.Drawing.Color.Black
        Me.txtOUAPVACO.Location = New System.Drawing.Point(144, 276)
        Me.txtOUAPVACO.MaxLength = 12
        Me.txtOUAPVACO.Name = "txtOUAPVACO"
        Me.txtOUAPVACO.Size = New System.Drawing.Size(172, 20)
        Me.txtOUAPVACO.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(16, 276)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 20)
        Me.Label9.TabIndex = 429
        Me.Label9.Text = "Valor compra $"
        '
        'txtOUAPAVCO
        '
        Me.txtOUAPAVCO.AccessibleDescription = "Avalúo comercial"
        Me.txtOUAPAVCO.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUAPAVCO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUAPAVCO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUAPAVCO.ForeColor = System.Drawing.Color.Black
        Me.txtOUAPAVCO.Location = New System.Drawing.Point(144, 253)
        Me.txtOUAPAVCO.MaxLength = 12
        Me.txtOUAPAVCO.Name = "txtOUAPAVCO"
        Me.txtOUAPAVCO.Size = New System.Drawing.Size(172, 20)
        Me.txtOUAPAVCO.TabIndex = 16
        '
        'txtOUAPAVCA
        '
        Me.txtOUAPAVCA.AccessibleDescription = "Avalúo catastral"
        Me.txtOUAPAVCA.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUAPAVCA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUAPAVCA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUAPAVCA.ForeColor = System.Drawing.Color.Black
        Me.txtOUAPAVCA.Location = New System.Drawing.Point(144, 230)
        Me.txtOUAPAVCA.MaxLength = 12
        Me.txtOUAPAVCA.Name = "txtOUAPAVCA"
        Me.txtOUAPAVCA.Size = New System.Drawing.Size(172, 20)
        Me.txtOUAPAVCA.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(16, 253)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(125, 20)
        Me.Label10.TabIndex = 428
        Me.Label10.Text = "Avalúo comercial $"
        '
        'Label11
        '
        Me.Label11.AccessibleDescription = ""
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(16, 230)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(125, 20)
        Me.Label11.TabIndex = 427
        Me.Label11.Text = "Avalúo catastral $"
        '
        'txtOUAPARTE
        '
        Me.txtOUAPARTE.AccessibleDescription = "Área de terreno"
        Me.txtOUAPARTE.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUAPARTE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUAPARTE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUAPARTE.ForeColor = System.Drawing.Color.Black
        Me.txtOUAPARTE.Location = New System.Drawing.Point(144, 207)
        Me.txtOUAPARTE.MaxLength = 9
        Me.txtOUAPARTE.Name = "txtOUAPARTE"
        Me.txtOUAPARTE.Size = New System.Drawing.Size(172, 20)
        Me.txtOUAPARTE.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(16, 207)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 20)
        Me.Label5.TabIndex = 423
        Me.Label5.Text = "Área de terreno m2"
        '
        'cboOUAPESTA
        '
        Me.cboOUAPESTA.AccessibleDescription = "Estado"
        Me.cboOUAPESTA.BackColor = System.Drawing.Color.White
        Me.cboOUAPESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUAPESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUAPESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUAPESTA.Location = New System.Drawing.Point(144, 344)
        Me.cboOUAPESTA.MaxDropDownItems = 15
        Me.cboOUAPESTA.MaxLength = 1
        Me.cboOUAPESTA.Name = "cboOUAPESTA"
        Me.cboOUAPESTA.Size = New System.Drawing.Size(172, 22)
        Me.cboOUAPESTA.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(16, 345)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 20)
        Me.Label8.TabIndex = 421
        Me.Label8.Text = "Estado"
        '
        'cboOUAPSUPE
        '
        Me.cboOUAPSUPE.AccessibleDescription = "Supervisor"
        Me.cboOUAPSUPE.BackColor = System.Drawing.Color.White
        Me.cboOUAPSUPE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUAPSUPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUAPSUPE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUAPSUPE.Location = New System.Drawing.Point(144, 183)
        Me.cboOUAPSUPE.MaxDropDownItems = 15
        Me.cboOUAPSUPE.MaxLength = 1
        Me.cboOUAPSUPE.Name = "cboOUAPSUPE"
        Me.cboOUAPSUPE.Size = New System.Drawing.Size(436, 22)
        Me.cboOUAPSUPE.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(16, 184)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 20)
        Me.Label7.TabIndex = 418
        Me.Label7.Text = "Supervisor"
        '
        'txtOUAPUNPR
        '
        Me.txtOUAPUNPR.AccessibleDescription = "Unidad predial"
        Me.txtOUAPUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUAPUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUAPUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUAPUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtOUAPUNPR.Location = New System.Drawing.Point(671, 69)
        Me.txtOUAPUNPR.MaxLength = 5
        Me.txtOUAPUNPR.Name = "txtOUAPUNPR"
        Me.txtOUAPUNPR.Size = New System.Drawing.Size(85, 20)
        Me.txtOUAPUNPR.TabIndex = 8
        '
        'txtOUAPEDIF
        '
        Me.txtOUAPEDIF.AccessibleDescription = "Edificio"
        Me.txtOUAPEDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUAPEDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUAPEDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUAPEDIF.ForeColor = System.Drawing.Color.Black
        Me.txtOUAPEDIF.Location = New System.Drawing.Point(583, 69)
        Me.txtOUAPEDIF.MaxLength = 3
        Me.txtOUAPEDIF.Name = "txtOUAPEDIF"
        Me.txtOUAPEDIF.Size = New System.Drawing.Size(85, 20)
        Me.txtOUAPEDIF.TabIndex = 7
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
        'cboOUAPCLSE
        '
        Me.cboOUAPCLSE.AccessibleDescription = "Clase o sector "
        Me.cboOUAPCLSE.BackColor = System.Drawing.Color.White
        Me.cboOUAPCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUAPCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUAPCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUAPCLSE.Location = New System.Drawing.Point(144, 91)
        Me.cboOUAPCLSE.MaxDropDownItems = 15
        Me.cboOUAPCLSE.MaxLength = 1
        Me.cboOUAPCLSE.Name = "cboOUAPCLSE"
        Me.cboOUAPCLSE.Size = New System.Drawing.Size(173, 22)
        Me.cboOUAPCLSE.TabIndex = 9
        '
        'txtOUAPNUOF
        '
        Me.txtOUAPNUOF.AccessibleDescription = "Nro. Oficio"
        Me.txtOUAPNUOF.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUAPNUOF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUAPNUOF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUAPNUOF.ForeColor = System.Drawing.Color.Black
        Me.txtOUAPNUOF.Location = New System.Drawing.Point(144, 161)
        Me.txtOUAPNUOF.MaxLength = 9
        Me.txtOUAPNUOF.Name = "txtOUAPNUOF"
        Me.txtOUAPNUOF.Size = New System.Drawing.Size(172, 20)
        Me.txtOUAPNUOF.TabIndex = 12
        '
        'txtOUAPMAIN
        '
        Me.txtOUAPMAIN.AccessibleDescription = "Matricula"
        Me.txtOUAPMAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUAPMAIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUAPMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUAPMAIN.ForeColor = System.Drawing.Color.Black
        Me.txtOUAPMAIN.Location = New System.Drawing.Point(144, 23)
        Me.txtOUAPMAIN.MaxLength = 7
        Me.txtOUAPMAIN.Name = "txtOUAPMAIN"
        Me.txtOUAPMAIN.Size = New System.Drawing.Size(172, 20)
        Me.txtOUAPMAIN.TabIndex = 1
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
        Me.Label2.Text = "Número de oficio"
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
        'txtOUAPCORR
        '
        Me.txtOUAPCORR.AccessibleDescription = "Corregimiento"
        Me.txtOUAPCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUAPCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUAPCORR.Location = New System.Drawing.Point(232, 69)
        Me.txtOUAPCORR.MaxLength = 2
        Me.txtOUAPCORR.Name = "txtOUAPCORR"
        Me.txtOUAPCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtOUAPCORR.TabIndex = 3
        '
        'txtOUAPMUNI
        '
        Me.txtOUAPMUNI.AccessibleDescription = "Municipio"
        Me.txtOUAPMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUAPMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUAPMUNI.Location = New System.Drawing.Point(144, 69)
        Me.txtOUAPMUNI.MaxLength = 3
        Me.txtOUAPMUNI.Name = "txtOUAPMUNI"
        Me.txtOUAPMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtOUAPMUNI.TabIndex = 2
        '
        'txtOUAPPRED
        '
        Me.txtOUAPPRED.AccessibleDescription = "Predio "
        Me.txtOUAPPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUAPPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUAPPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUAPPRED.ForeColor = System.Drawing.Color.Black
        Me.txtOUAPPRED.Location = New System.Drawing.Point(496, 69)
        Me.txtOUAPPRED.MaxLength = 5
        Me.txtOUAPPRED.Name = "txtOUAPPRED"
        Me.txtOUAPPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtOUAPPRED.TabIndex = 6
        '
        'txtOUAPMANZ
        '
        Me.txtOUAPMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtOUAPMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUAPMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUAPMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUAPMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtOUAPMANZ.Location = New System.Drawing.Point(408, 69)
        Me.txtOUAPMANZ.MaxLength = 3
        Me.txtOUAPMANZ.Name = "txtOUAPMANZ"
        Me.txtOUAPMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtOUAPMANZ.TabIndex = 5
        '
        'txtOUAPBARR
        '
        Me.txtOUAPBARR.AccessibleDescription = "Barrio "
        Me.txtOUAPBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUAPBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUAPBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUAPBARR.ForeColor = System.Drawing.Color.Black
        Me.txtOUAPBARR.Location = New System.Drawing.Point(320, 69)
        Me.txtOUAPBARR.MaxLength = 3
        Me.txtOUAPBARR.Name = "txtOUAPBARR"
        Me.txtOUAPBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtOUAPBARR.TabIndex = 4
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
        'frm_insertar_OBURADPR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 490)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCEDUCATA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(813, 526)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(813, 526)
        Me.Name = "frm_insertar_OBURADPR"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox2.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraCEDUCATA.ResumeLayout(False)
        Me.fraCEDUCATA.PerformLayout()
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
    Friend WithEvents txtOUAPVACO As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtOUAPAVCO As System.Windows.Forms.TextBox
    Friend WithEvents txtOUAPAVCA As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtOUAPARTE As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboOUAPESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboOUAPSUPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtOUAPUNPR As System.Windows.Forms.TextBox
    Friend WithEvents txtOUAPEDIF As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboOUAPCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents txtOUAPNUOF As System.Windows.Forms.TextBox
    Friend WithEvents txtOUAPMAIN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtOUAPCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtOUAPMUNI As System.Windows.Forms.TextBox
    Friend WithEvents txtOUAPPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtOUAPMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtOUAPBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtOUAPOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtOUAPDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblOUAPNDSU As System.Windows.Forms.Label
    Friend WithEvents cboOUAPCLOU As System.Windows.Forms.ComboBox
    Friend WithEvents lblOUAPCLOU As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtOUAPDIRE As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
