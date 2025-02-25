<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_RELIPRED
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_insertar_RELIPRED))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraCEDUCATA = New System.Windows.Forms.GroupBox()
        Me.txtRLPRUNPR = New System.Windows.Forms.TextBox()
        Me.txtRLPREDIF = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboRLPRCLSE = New System.Windows.Forms.ComboBox()
        Me.lblRLPRCLSE = New System.Windows.Forms.Label()
        Me.txtRLPRNUFI = New System.Windows.Forms.TextBox()
        Me.txtRLPRMAIN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtRLPRCORR = New System.Windows.Forms.TextBox()
        Me.txtRLPRMUNI = New System.Windows.Forms.TextBox()
        Me.txtRLPRPRED = New System.Windows.Forms.TextBox()
        Me.txtRLPRMANZ = New System.Windows.Forms.TextBox()
        Me.txtRLPRBARR = New System.Windows.Forms.TextBox()
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
        Me.GroupBox2.TabIndex = 348
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
        Me.strBARRESTA.TabIndex = 349
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
        Me.fraCEDUCATA.Controls.Add(Me.txtRLPRUNPR)
        Me.fraCEDUCATA.Controls.Add(Me.txtRLPREDIF)
        Me.fraCEDUCATA.Controls.Add(Me.Label1)
        Me.fraCEDUCATA.Controls.Add(Me.Label6)
        Me.fraCEDUCATA.Controls.Add(Me.cboRLPRCLSE)
        Me.fraCEDUCATA.Controls.Add(Me.lblRLPRCLSE)
        Me.fraCEDUCATA.Controls.Add(Me.txtRLPRNUFI)
        Me.fraCEDUCATA.Controls.Add(Me.txtRLPRMAIN)
        Me.fraCEDUCATA.Controls.Add(Me.Label2)
        Me.fraCEDUCATA.Controls.Add(Me.Label3)
        Me.fraCEDUCATA.Controls.Add(Me.Label4)
        Me.fraCEDUCATA.Controls.Add(Me.Label33)
        Me.fraCEDUCATA.Controls.Add(Me.txtRLPRCORR)
        Me.fraCEDUCATA.Controls.Add(Me.txtRLPRMUNI)
        Me.fraCEDUCATA.Controls.Add(Me.txtRLPRPRED)
        Me.fraCEDUCATA.Controls.Add(Me.txtRLPRMANZ)
        Me.fraCEDUCATA.Controls.Add(Me.txtRLPRBARR)
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
        Me.fraCEDUCATA.TabIndex = 347
        Me.fraCEDUCATA.TabStop = False
        Me.fraCEDUCATA.Text = "INSERTAR PREDIOS"
        '
        'txtRLPRUNPR
        '
        Me.txtRLPRUNPR.AccessibleDescription = "Unidad predial"
        Me.txtRLPRUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLPRUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLPRUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLPRUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtRLPRUNPR.Location = New System.Drawing.Point(672, 71)
        Me.txtRLPRUNPR.MaxLength = 5
        Me.txtRLPRUNPR.Name = "txtRLPRUNPR"
        Me.txtRLPRUNPR.Size = New System.Drawing.Size(85, 20)
        Me.txtRLPRUNPR.TabIndex = 7
        '
        'txtRLPREDIF
        '
        Me.txtRLPREDIF.AccessibleDescription = "Edificio"
        Me.txtRLPREDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLPREDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLPREDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLPREDIF.ForeColor = System.Drawing.Color.Black
        Me.txtRLPREDIF.Location = New System.Drawing.Point(584, 71)
        Me.txtRLPREDIF.MaxLength = 3
        Me.txtRLPREDIF.Name = "txtRLPREDIF"
        Me.txtRLPREDIF.Size = New System.Drawing.Size(85, 20)
        Me.txtRLPREDIF.TabIndex = 6
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
        'cboRLPRCLSE
        '
        Me.cboRLPRCLSE.AccessibleDescription = "Clase o sector "
        Me.cboRLPRCLSE.BackColor = System.Drawing.Color.White
        Me.cboRLPRCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRLPRCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRLPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRLPRCLSE.Location = New System.Drawing.Point(144, 93)
        Me.cboRLPRCLSE.MaxDropDownItems = 15
        Me.cboRLPRCLSE.MaxLength = 1
        Me.cboRLPRCLSE.Name = "cboRLPRCLSE"
        Me.cboRLPRCLSE.Size = New System.Drawing.Size(173, 22)
        Me.cboRLPRCLSE.TabIndex = 8
        '
        'lblRLPRCLSE
        '
        Me.lblRLPRCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRLPRCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRLPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRLPRCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblRLPRCLSE.Location = New System.Drawing.Point(320, 95)
        Me.lblRLPRCLSE.Name = "lblRLPRCLSE"
        Me.lblRLPRCLSE.Size = New System.Drawing.Size(172, 20)
        Me.lblRLPRCLSE.TabIndex = 410
        '
        'txtRLPRNUFI
        '
        Me.txtRLPRNUFI.AccessibleDescription = "Nro. Ficha predial"
        Me.txtRLPRNUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLPRNUFI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLPRNUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLPRNUFI.ForeColor = System.Drawing.Color.Black
        Me.txtRLPRNUFI.Location = New System.Drawing.Point(144, 140)
        Me.txtRLPRNUFI.MaxLength = 9
        Me.txtRLPRNUFI.Name = "txtRLPRNUFI"
        Me.txtRLPRNUFI.Size = New System.Drawing.Size(172, 20)
        Me.txtRLPRNUFI.TabIndex = 10
        '
        'txtRLPRMAIN
        '
        Me.txtRLPRMAIN.AccessibleDescription = "Matricula"
        Me.txtRLPRMAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLPRMAIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLPRMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLPRMAIN.ForeColor = System.Drawing.Color.Black
        Me.txtRLPRMAIN.Location = New System.Drawing.Point(144, 117)
        Me.txtRLPRMAIN.MaxLength = 7
        Me.txtRLPRMAIN.Name = "txtRLPRMAIN"
        Me.txtRLPRMAIN.Size = New System.Drawing.Size(172, 20)
        Me.txtRLPRMAIN.TabIndex = 9
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
        'txtRLPRCORR
        '
        Me.txtRLPRCORR.AccessibleDescription = "Corregimiento"
        Me.txtRLPRCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLPRCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLPRCORR.Location = New System.Drawing.Point(232, 71)
        Me.txtRLPRCORR.MaxLength = 2
        Me.txtRLPRCORR.Name = "txtRLPRCORR"
        Me.txtRLPRCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtRLPRCORR.TabIndex = 2
        '
        'txtRLPRMUNI
        '
        Me.txtRLPRMUNI.AccessibleDescription = "Municipio"
        Me.txtRLPRMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLPRMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLPRMUNI.Location = New System.Drawing.Point(144, 71)
        Me.txtRLPRMUNI.MaxLength = 3
        Me.txtRLPRMUNI.Name = "txtRLPRMUNI"
        Me.txtRLPRMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtRLPRMUNI.TabIndex = 1
        '
        'txtRLPRPRED
        '
        Me.txtRLPRPRED.AccessibleDescription = "Predio "
        Me.txtRLPRPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLPRPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLPRPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLPRPRED.ForeColor = System.Drawing.Color.Black
        Me.txtRLPRPRED.Location = New System.Drawing.Point(496, 71)
        Me.txtRLPRPRED.MaxLength = 5
        Me.txtRLPRPRED.Name = "txtRLPRPRED"
        Me.txtRLPRPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtRLPRPRED.TabIndex = 5
        '
        'txtRLPRMANZ
        '
        Me.txtRLPRMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtRLPRMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLPRMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLPRMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLPRMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtRLPRMANZ.Location = New System.Drawing.Point(408, 71)
        Me.txtRLPRMANZ.MaxLength = 3
        Me.txtRLPRMANZ.Name = "txtRLPRMANZ"
        Me.txtRLPRMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtRLPRMANZ.TabIndex = 4
        '
        'txtRLPRBARR
        '
        Me.txtRLPRBARR.AccessibleDescription = "Barrio "
        Me.txtRLPRBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRLPRBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRLPRBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRLPRBARR.ForeColor = System.Drawing.Color.Black
        Me.txtRLPRBARR.Location = New System.Drawing.Point(320, 71)
        Me.txtRLPRBARR.MaxLength = 3
        Me.txtRLPRBARR.Name = "txtRLPRBARR"
        Me.txtRLPRBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtRLPRBARR.TabIndex = 3
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
        'frm_insertar_RELIPRED
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
        Me.Name = "frm_insertar_RELIPRED"
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
    Friend WithEvents txtRLPRUNPR As System.Windows.Forms.TextBox
    Friend WithEvents txtRLPREDIF As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboRLPRCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblRLPRCLSE As System.Windows.Forms.Label
    Friend WithEvents txtRLPRNUFI As System.Windows.Forms.TextBox
    Friend WithEvents txtRLPRMAIN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtRLPRCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtRLPRMUNI As System.Windows.Forms.TextBox
    Friend WithEvents txtRLPRPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtRLPRMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtRLPRBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
End Class
