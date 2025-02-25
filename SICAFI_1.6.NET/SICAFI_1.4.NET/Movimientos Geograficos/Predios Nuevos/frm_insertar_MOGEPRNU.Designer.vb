<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_MOGEPRNU
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_insertar_MOGEPRNU))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraCEDUCATA = New System.Windows.Forms.GroupBox()
        Me.cboMGPNCAAC = New System.Windows.Forms.ComboBox()
        Me.lblMGPNCAAC = New System.Windows.Forms.Label()
        Me.cboMGPNCLSE = New System.Windows.Forms.ComboBox()
        Me.lblMGPNCLSE = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMGPNNUOV = New System.Windows.Forms.TextBox()
        Me.txtMGPNNUFI = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtMGPNCORR = New System.Windows.Forms.TextBox()
        Me.txtMGPNMUNI = New System.Windows.Forms.TextBox()
        Me.txtMGPNPRED = New System.Windows.Forms.TextBox()
        Me.txtMGPNMANZ = New System.Windows.Forms.TextBox()
        Me.txtMGPNBARR = New System.Windows.Forms.TextBox()
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
        Me.GroupBox2.Location = New System.Drawing.Point(12, 214)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(598, 46)
        Me.GroupBox2.TabIndex = 342
        Me.GroupBox2.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = CType(resources.GetObject("cmdSALIR.Image"), System.Drawing.Image)
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(303, 14)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(196, 14)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 276)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(626, 25)
        Me.strBARRESTA.TabIndex = 343
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
        Me.fraCEDUCATA.Controls.Add(Me.cboMGPNCAAC)
        Me.fraCEDUCATA.Controls.Add(Me.lblMGPNCAAC)
        Me.fraCEDUCATA.Controls.Add(Me.cboMGPNCLSE)
        Me.fraCEDUCATA.Controls.Add(Me.lblMGPNCLSE)
        Me.fraCEDUCATA.Controls.Add(Me.Label5)
        Me.fraCEDUCATA.Controls.Add(Me.txtMGPNNUOV)
        Me.fraCEDUCATA.Controls.Add(Me.txtMGPNNUFI)
        Me.fraCEDUCATA.Controls.Add(Me.Label2)
        Me.fraCEDUCATA.Controls.Add(Me.Label3)
        Me.fraCEDUCATA.Controls.Add(Me.Label4)
        Me.fraCEDUCATA.Controls.Add(Me.Label33)
        Me.fraCEDUCATA.Controls.Add(Me.txtMGPNCORR)
        Me.fraCEDUCATA.Controls.Add(Me.txtMGPNMUNI)
        Me.fraCEDUCATA.Controls.Add(Me.txtMGPNPRED)
        Me.fraCEDUCATA.Controls.Add(Me.txtMGPNMANZ)
        Me.fraCEDUCATA.Controls.Add(Me.txtMGPNBARR)
        Me.fraCEDUCATA.Controls.Add(Me.lblCodigoActual)
        Me.fraCEDUCATA.Controls.Add(Me.lblPredio)
        Me.fraCEDUCATA.Controls.Add(Me.lblManzana)
        Me.fraCEDUCATA.Controls.Add(Me.lblBarrio)
        Me.fraCEDUCATA.Controls.Add(Me.lblCorregimiento)
        Me.fraCEDUCATA.Controls.Add(Me.lblMunicipio)
        Me.fraCEDUCATA.Controls.Add(Me.lblCodigo)
        Me.fraCEDUCATA.Location = New System.Drawing.Point(12, 6)
        Me.fraCEDUCATA.Name = "fraCEDUCATA"
        Me.fraCEDUCATA.Size = New System.Drawing.Size(598, 202)
        Me.fraCEDUCATA.TabIndex = 341
        Me.fraCEDUCATA.TabStop = False
        Me.fraCEDUCATA.Text = "INSERTAR PREDIOS NUEVOS"
        '
        'cboMGPNCAAC
        '
        Me.cboMGPNCAAC.AccessibleDescription = "Causa del acto"
        Me.cboMGPNCAAC.BackColor = System.Drawing.Color.White
        Me.cboMGPNCAAC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMGPNCAAC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMGPNCAAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMGPNCAAC.Location = New System.Drawing.Point(144, 116)
        Me.cboMGPNCAAC.MaxDropDownItems = 15
        Me.cboMGPNCAAC.MaxLength = 1
        Me.cboMGPNCAAC.Name = "cboMGPNCAAC"
        Me.cboMGPNCAAC.Size = New System.Drawing.Size(260, 22)
        Me.cboMGPNCAAC.TabIndex = 411
        '
        'lblMGPNCAAC
        '
        Me.lblMGPNCAAC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblMGPNCAAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMGPNCAAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMGPNCAAC.ForeColor = System.Drawing.Color.Black
        Me.lblMGPNCAAC.Location = New System.Drawing.Point(408, 118)
        Me.lblMGPNCAAC.Name = "lblMGPNCAAC"
        Me.lblMGPNCAAC.Size = New System.Drawing.Size(172, 20)
        Me.lblMGPNCAAC.TabIndex = 412
        '
        'cboMGPNCLSE
        '
        Me.cboMGPNCLSE.AccessibleDescription = "Clase o sector "
        Me.cboMGPNCLSE.BackColor = System.Drawing.Color.White
        Me.cboMGPNCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMGPNCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMGPNCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMGPNCLSE.Location = New System.Drawing.Point(144, 93)
        Me.cboMGPNCLSE.MaxDropDownItems = 15
        Me.cboMGPNCLSE.MaxLength = 1
        Me.cboMGPNCLSE.Name = "cboMGPNCLSE"
        Me.cboMGPNCLSE.Size = New System.Drawing.Size(260, 22)
        Me.cboMGPNCLSE.TabIndex = 409
        '
        'lblMGPNCLSE
        '
        Me.lblMGPNCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblMGPNCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMGPNCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMGPNCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblMGPNCLSE.Location = New System.Drawing.Point(408, 95)
        Me.lblMGPNCLSE.Name = "lblMGPNCLSE"
        Me.lblMGPNCLSE.Size = New System.Drawing.Size(172, 20)
        Me.lblMGPNCLSE.TabIndex = 410
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(16, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 20)
        Me.Label5.TabIndex = 408
        Me.Label5.Text = "Causa del acto"
        '
        'txtMGPNNUOV
        '
        Me.txtMGPNNUOV.AccessibleDescription = "Nro. Ficha predial"
        Me.txtMGPNNUOV.BackColor = System.Drawing.SystemColors.Window
        Me.txtMGPNNUOV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMGPNNUOV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMGPNNUOV.ForeColor = System.Drawing.Color.Black
        Me.txtMGPNNUOV.Location = New System.Drawing.Point(144, 163)
        Me.txtMGPNNUOV.MaxLength = 9
        Me.txtMGPNNUOV.Name = "txtMGPNNUOV"
        Me.txtMGPNNUOV.Size = New System.Drawing.Size(172, 20)
        Me.txtMGPNNUOV.TabIndex = 10
        '
        'txtMGPNNUFI
        '
        Me.txtMGPNNUFI.AccessibleDescription = "Edificio"
        Me.txtMGPNNUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtMGPNNUFI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMGPNNUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMGPNNUFI.ForeColor = System.Drawing.Color.Black
        Me.txtMGPNNUFI.Location = New System.Drawing.Point(144, 140)
        Me.txtMGPNNUFI.MaxLength = 9
        Me.txtMGPNNUFI.Name = "txtMGPNNUFI"
        Me.txtMGPNNUFI.Size = New System.Drawing.Size(172, 20)
        Me.txtMGPNNUFI.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 163)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 20)
        Me.Label2.TabIndex = 407
        Me.Label2.Text = "Nro. Ficha OVC"
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = ""
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 20)
        Me.Label3.TabIndex = 406
        Me.Label3.Text = "Nro. Ficha Municipio"
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
        Me.Label33.Size = New System.Drawing.Size(564, 20)
        Me.Label33.TabIndex = 397
        Me.Label33.Text = "CEDULA CATASTRAL ACTUAL"
        '
        'txtMGPNCORR
        '
        Me.txtMGPNCORR.AccessibleDescription = "Corregimiento"
        Me.txtMGPNCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtMGPNCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMGPNCORR.Location = New System.Drawing.Point(232, 71)
        Me.txtMGPNCORR.MaxLength = 2
        Me.txtMGPNCORR.Name = "txtMGPNCORR"
        Me.txtMGPNCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtMGPNCORR.TabIndex = 2
        '
        'txtMGPNMUNI
        '
        Me.txtMGPNMUNI.AccessibleDescription = "Municipio"
        Me.txtMGPNMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtMGPNMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMGPNMUNI.Location = New System.Drawing.Point(144, 71)
        Me.txtMGPNMUNI.MaxLength = 3
        Me.txtMGPNMUNI.Name = "txtMGPNMUNI"
        Me.txtMGPNMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtMGPNMUNI.TabIndex = 1
        '
        'txtMGPNPRED
        '
        Me.txtMGPNPRED.AccessibleDescription = "Predio "
        Me.txtMGPNPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtMGPNPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMGPNPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMGPNPRED.ForeColor = System.Drawing.Color.Black
        Me.txtMGPNPRED.Location = New System.Drawing.Point(496, 71)
        Me.txtMGPNPRED.MaxLength = 5
        Me.txtMGPNPRED.Name = "txtMGPNPRED"
        Me.txtMGPNPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtMGPNPRED.TabIndex = 5
        '
        'txtMGPNMANZ
        '
        Me.txtMGPNMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtMGPNMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtMGPNMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMGPNMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMGPNMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtMGPNMANZ.Location = New System.Drawing.Point(408, 71)
        Me.txtMGPNMANZ.MaxLength = 3
        Me.txtMGPNMANZ.Name = "txtMGPNMANZ"
        Me.txtMGPNMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtMGPNMANZ.TabIndex = 4
        '
        'txtMGPNBARR
        '
        Me.txtMGPNBARR.AccessibleDescription = "Barrio "
        Me.txtMGPNBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtMGPNBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMGPNBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMGPNBARR.ForeColor = System.Drawing.Color.Black
        Me.txtMGPNBARR.Location = New System.Drawing.Point(320, 71)
        Me.txtMGPNBARR.MaxLength = 3
        Me.txtMGPNBARR.Name = "txtMGPNBARR"
        Me.txtMGPNBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtMGPNBARR.TabIndex = 3
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
        'frm_insertar_MOGEPRNU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 301)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCEDUCATA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(642, 337)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(642, 337)
        Me.Name = "frm_insertar_MOGEPRNU"
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
    Friend WithEvents txtMGPNNUOV As System.Windows.Forms.TextBox
    Friend WithEvents txtMGPNNUFI As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtMGPNCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtMGPNMUNI As System.Windows.Forms.TextBox
    Friend WithEvents txtMGPNPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtMGPNMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtMGPNBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboMGPNCAAC As System.Windows.Forms.ComboBox
    Friend WithEvents lblMGPNCAAC As System.Windows.Forms.Label
    Friend WithEvents cboMGPNCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblMGPNCLSE As System.Windows.Forms.Label
End Class
