<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_LIRAPRED
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_insertar_LIRAPRED))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraCEDUCATA = New System.Windows.Forms.GroupBox()
        Me.txtLRPRUNPR = New System.Windows.Forms.TextBox()
        Me.txtLRPREDIF = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboLRPRCLSE = New System.Windows.Forms.ComboBox()
        Me.lblLRPRCLSE = New System.Windows.Forms.Label()
        Me.txtLRPRNUFI = New System.Windows.Forms.TextBox()
        Me.txtLRPRMAIN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtLRPRCORR = New System.Windows.Forms.TextBox()
        Me.txtLRPRMUNI = New System.Windows.Forms.TextBox()
        Me.txtLRPRPRED = New System.Windows.Forms.TextBox()
        Me.txtLRPRMANZ = New System.Windows.Forms.TextBox()
        Me.txtLRPRBARR = New System.Windows.Forms.TextBox()
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
        Me.GroupBox2.Location = New System.Drawing.Point(12, 191)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(769, 46)
        Me.GroupBox2.TabIndex = 345
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 256)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(793, 25)
        Me.strBARRESTA.TabIndex = 346
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
        Me.fraCEDUCATA.Controls.Add(Me.txtLRPRUNPR)
        Me.fraCEDUCATA.Controls.Add(Me.txtLRPREDIF)
        Me.fraCEDUCATA.Controls.Add(Me.Label1)
        Me.fraCEDUCATA.Controls.Add(Me.Label6)
        Me.fraCEDUCATA.Controls.Add(Me.cboLRPRCLSE)
        Me.fraCEDUCATA.Controls.Add(Me.lblLRPRCLSE)
        Me.fraCEDUCATA.Controls.Add(Me.txtLRPRNUFI)
        Me.fraCEDUCATA.Controls.Add(Me.txtLRPRMAIN)
        Me.fraCEDUCATA.Controls.Add(Me.Label2)
        Me.fraCEDUCATA.Controls.Add(Me.Label3)
        Me.fraCEDUCATA.Controls.Add(Me.Label4)
        Me.fraCEDUCATA.Controls.Add(Me.Label33)
        Me.fraCEDUCATA.Controls.Add(Me.txtLRPRCORR)
        Me.fraCEDUCATA.Controls.Add(Me.txtLRPRMUNI)
        Me.fraCEDUCATA.Controls.Add(Me.txtLRPRPRED)
        Me.fraCEDUCATA.Controls.Add(Me.txtLRPRMANZ)
        Me.fraCEDUCATA.Controls.Add(Me.txtLRPRBARR)
        Me.fraCEDUCATA.Controls.Add(Me.lblCodigoActual)
        Me.fraCEDUCATA.Controls.Add(Me.lblPredio)
        Me.fraCEDUCATA.Controls.Add(Me.lblManzana)
        Me.fraCEDUCATA.Controls.Add(Me.lblBarrio)
        Me.fraCEDUCATA.Controls.Add(Me.lblCorregimiento)
        Me.fraCEDUCATA.Controls.Add(Me.lblMunicipio)
        Me.fraCEDUCATA.Controls.Add(Me.lblCodigo)
        Me.fraCEDUCATA.Location = New System.Drawing.Point(12, 7)
        Me.fraCEDUCATA.Name = "fraCEDUCATA"
        Me.fraCEDUCATA.Size = New System.Drawing.Size(769, 178)
        Me.fraCEDUCATA.TabIndex = 344
        Me.fraCEDUCATA.TabStop = False
        Me.fraCEDUCATA.Text = "INSERTAR PREDIOS"
        '
        'txtLRPRUNPR
        '
        Me.txtLRPRUNPR.AccessibleDescription = "Unidad predial"
        Me.txtLRPRUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRPRUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRPRUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRPRUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtLRPRUNPR.Location = New System.Drawing.Point(672, 71)
        Me.txtLRPRUNPR.MaxLength = 5
        Me.txtLRPRUNPR.Name = "txtLRPRUNPR"
        Me.txtLRPRUNPR.Size = New System.Drawing.Size(85, 20)
        Me.txtLRPRUNPR.TabIndex = 7
        '
        'txtLRPREDIF
        '
        Me.txtLRPREDIF.AccessibleDescription = "Edificio"
        Me.txtLRPREDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRPREDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRPREDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRPREDIF.ForeColor = System.Drawing.Color.Black
        Me.txtLRPREDIF.Location = New System.Drawing.Point(584, 71)
        Me.txtLRPREDIF.MaxLength = 3
        Me.txtLRPREDIF.Name = "txtLRPREDIF"
        Me.txtLRPREDIF.Size = New System.Drawing.Size(85, 20)
        Me.txtLRPREDIF.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(672, 48)
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
        Me.Label6.Location = New System.Drawing.Point(584, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 20)
        Me.Label6.TabIndex = 415
        Me.Label6.Text = "Edificio"
        '
        'cboLRPRCLSE
        '
        Me.cboLRPRCLSE.AccessibleDescription = "Clase o sector "
        Me.cboLRPRCLSE.BackColor = System.Drawing.Color.White
        Me.cboLRPRCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboLRPRCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLRPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLRPRCLSE.Location = New System.Drawing.Point(144, 93)
        Me.cboLRPRCLSE.MaxDropDownItems = 15
        Me.cboLRPRCLSE.MaxLength = 1
        Me.cboLRPRCLSE.Name = "cboLRPRCLSE"
        Me.cboLRPRCLSE.Size = New System.Drawing.Size(173, 22)
        Me.cboLRPRCLSE.TabIndex = 8
        '
        'lblLRPRCLSE
        '
        Me.lblLRPRCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblLRPRCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLRPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLRPRCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblLRPRCLSE.Location = New System.Drawing.Point(320, 95)
        Me.lblLRPRCLSE.Name = "lblLRPRCLSE"
        Me.lblLRPRCLSE.Size = New System.Drawing.Size(172, 20)
        Me.lblLRPRCLSE.TabIndex = 410
        '
        'txtLRPRNUFI
        '
        Me.txtLRPRNUFI.AccessibleDescription = "Nro. Ficha predial"
        Me.txtLRPRNUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRPRNUFI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRPRNUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRPRNUFI.ForeColor = System.Drawing.Color.Black
        Me.txtLRPRNUFI.Location = New System.Drawing.Point(144, 140)
        Me.txtLRPRNUFI.MaxLength = 9
        Me.txtLRPRNUFI.Name = "txtLRPRNUFI"
        Me.txtLRPRNUFI.Size = New System.Drawing.Size(172, 20)
        Me.txtLRPRNUFI.TabIndex = 10
        '
        'txtLRPRMAIN
        '
        Me.txtLRPRMAIN.AccessibleDescription = "Matricula"
        Me.txtLRPRMAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRPRMAIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRPRMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRPRMAIN.ForeColor = System.Drawing.Color.Black
        Me.txtLRPRMAIN.Location = New System.Drawing.Point(144, 117)
        Me.txtLRPRMAIN.MaxLength = 7
        Me.txtLRPRMAIN.Name = "txtLRPRMAIN"
        Me.txtLRPRMAIN.Size = New System.Drawing.Size(172, 20)
        Me.txtLRPRMAIN.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 140)
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
        Me.Label3.Location = New System.Drawing.Point(16, 117)
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
        Me.Label4.Location = New System.Drawing.Point(16, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 20)
        Me.Label4.TabIndex = 405
        Me.Label4.Text = "Clase o Sector"
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(16, 25)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(741, 20)
        Me.Label33.TabIndex = 397
        Me.Label33.Text = "CEDULA CATASTRAL ACTUAL"
        '
        'txtLRPRCORR
        '
        Me.txtLRPRCORR.AccessibleDescription = "Corregimiento"
        Me.txtLRPRCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRPRCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRPRCORR.Location = New System.Drawing.Point(232, 71)
        Me.txtLRPRCORR.MaxLength = 2
        Me.txtLRPRCORR.Name = "txtLRPRCORR"
        Me.txtLRPRCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtLRPRCORR.TabIndex = 2
        '
        'txtLRPRMUNI
        '
        Me.txtLRPRMUNI.AccessibleDescription = "Municipio"
        Me.txtLRPRMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRPRMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRPRMUNI.Location = New System.Drawing.Point(144, 71)
        Me.txtLRPRMUNI.MaxLength = 3
        Me.txtLRPRMUNI.Name = "txtLRPRMUNI"
        Me.txtLRPRMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtLRPRMUNI.TabIndex = 1
        '
        'txtLRPRPRED
        '
        Me.txtLRPRPRED.AccessibleDescription = "Predio "
        Me.txtLRPRPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRPRPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRPRPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRPRPRED.ForeColor = System.Drawing.Color.Black
        Me.txtLRPRPRED.Location = New System.Drawing.Point(496, 71)
        Me.txtLRPRPRED.MaxLength = 5
        Me.txtLRPRPRED.Name = "txtLRPRPRED"
        Me.txtLRPRPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtLRPRPRED.TabIndex = 5
        '
        'txtLRPRMANZ
        '
        Me.txtLRPRMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtLRPRMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRPRMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRPRMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRPRMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtLRPRMANZ.Location = New System.Drawing.Point(408, 71)
        Me.txtLRPRMANZ.MaxLength = 3
        Me.txtLRPRMANZ.Name = "txtLRPRMANZ"
        Me.txtLRPRMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtLRPRMANZ.TabIndex = 4
        '
        'txtLRPRBARR
        '
        Me.txtLRPRBARR.AccessibleDescription = "Barrio "
        Me.txtLRPRBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtLRPRBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLRPRBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRPRBARR.ForeColor = System.Drawing.Color.Black
        Me.txtLRPRBARR.Location = New System.Drawing.Point(320, 71)
        Me.txtLRPRBARR.MaxLength = 3
        Me.txtLRPRBARR.Name = "txtLRPRBARR"
        Me.txtLRPRBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtLRPRBARR.TabIndex = 3
        '
        'lblCodigoActual
        '
        Me.lblCodigoActual.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigoActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigoActual.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoActual.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoActual.Location = New System.Drawing.Point(16, 71)
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
        Me.lblPredio.Location = New System.Drawing.Point(496, 48)
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
        Me.lblManzana.Location = New System.Drawing.Point(408, 48)
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
        Me.lblBarrio.Location = New System.Drawing.Point(320, 48)
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
        Me.lblCorregimiento.Location = New System.Drawing.Point(232, 48)
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
        Me.lblMunicipio.Location = New System.Drawing.Point(144, 48)
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
        Me.lblCodigo.Location = New System.Drawing.Point(16, 48)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(125, 20)
        Me.lblCodigo.TabIndex = 399
        Me.lblCodigo.Text = "CODIGO"
        '
        'frm_insertar_LIRAPRED
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 281)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCEDUCATA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(809, 317)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(809, 317)
        Me.Name = "frm_insertar_LIRAPRED"
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
    Friend WithEvents cboLRPRCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblLRPRCLSE As System.Windows.Forms.Label
    Friend WithEvents txtLRPRNUFI As System.Windows.Forms.TextBox
    Friend WithEvents txtLRPRMAIN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtLRPRCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtLRPRMUNI As System.Windows.Forms.TextBox
    Friend WithEvents txtLRPRPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtLRPRMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtLRPRBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtLRPRUNPR As System.Windows.Forms.TextBox
    Friend WithEvents txtLRPREDIF As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
