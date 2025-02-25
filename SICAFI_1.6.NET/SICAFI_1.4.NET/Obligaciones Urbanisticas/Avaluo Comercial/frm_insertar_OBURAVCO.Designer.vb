<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_OBURAVCO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_insertar_OBURAVCO))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraCEDUCATA = New System.Windows.Forms.GroupBox()
        Me.dtpOUACFEIN = New System.Windows.Forms.DateTimePicker()
        Me.txtOUACFEIN = New System.Windows.Forms.MaskedTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtpOUACFEVI = New System.Windows.Forms.DateTimePicker()
        Me.txtOUACFEVI = New System.Windows.Forms.MaskedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboOUACESTA = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtOUACAVCO = New System.Windows.Forms.TextBox()
        Me.cboOUACVIAV = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblOUACVIAV = New System.Windows.Forms.Label()
        Me.txtOUACNUAV = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtOUACACM2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtOUACARTE = New System.Windows.Forms.TextBox()
        Me.txtOUACSOLI = New System.Windows.Forms.TextBox()
        Me.txtOUACEMPR = New System.Windows.Forms.TextBox()
        Me.txtOUACDIRE = New System.Windows.Forms.TextBox()
        Me.txtOUACPROY = New System.Windows.Forms.TextBox()
        Me.txtOUACPUNT = New System.Windows.Forms.TextBox()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.lblManzana = New System.Windows.Forms.Label()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraCEDUCATA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdSALIR)
        Me.GroupBox2.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 355)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(697, 46)
        Me.GroupBox2.TabIndex = 354
        Me.GroupBox2.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = CType(resources.GetObject("cmdSALIR.Image"), System.Drawing.Image)
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(352, 14)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 21
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = CType(resources.GetObject("cmdGUARDAR.Image"), System.Drawing.Image)
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(245, 14)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 20
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 418)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(728, 25)
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
        Me.fraCEDUCATA.Controls.Add(Me.Label2)
        Me.fraCEDUCATA.Controls.Add(Me.Label1)
        Me.fraCEDUCATA.Controls.Add(Me.dtpOUACFEIN)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUACFEIN)
        Me.fraCEDUCATA.Controls.Add(Me.Label13)
        Me.fraCEDUCATA.Controls.Add(Me.dtpOUACFEVI)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUACFEVI)
        Me.fraCEDUCATA.Controls.Add(Me.Label12)
        Me.fraCEDUCATA.Controls.Add(Me.cboOUACESTA)
        Me.fraCEDUCATA.Controls.Add(Me.Label8)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUACAVCO)
        Me.fraCEDUCATA.Controls.Add(Me.cboOUACVIAV)
        Me.fraCEDUCATA.Controls.Add(Me.Label9)
        Me.fraCEDUCATA.Controls.Add(Me.lblOUACVIAV)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUACNUAV)
        Me.fraCEDUCATA.Controls.Add(Me.Label5)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUACACM2)
        Me.fraCEDUCATA.Controls.Add(Me.Label3)
        Me.fraCEDUCATA.Controls.Add(Me.Label10)
        Me.fraCEDUCATA.Controls.Add(Me.Label4)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUACARTE)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUACSOLI)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUACEMPR)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUACDIRE)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUACPROY)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUACPUNT)
        Me.fraCEDUCATA.Controls.Add(Me.lblPredio)
        Me.fraCEDUCATA.Controls.Add(Me.lblManzana)
        Me.fraCEDUCATA.Controls.Add(Me.lblBarrio)
        Me.fraCEDUCATA.Controls.Add(Me.lblCorregimiento)
        Me.fraCEDUCATA.Controls.Add(Me.lblMunicipio)
        Me.fraCEDUCATA.Location = New System.Drawing.Point(12, 6)
        Me.fraCEDUCATA.Name = "fraCEDUCATA"
        Me.fraCEDUCATA.Size = New System.Drawing.Size(697, 343)
        Me.fraCEDUCATA.TabIndex = 353
        Me.fraCEDUCATA.TabStop = False
        Me.fraCEDUCATA.Text = "INSERTAR AVALÚO COMERCIAL"
        '
        'dtpOUACFEIN
        '
        Me.dtpOUACFEIN.Location = New System.Drawing.Point(321, 114)
        Me.dtpOUACFEIN.Name = "dtpOUACFEIN"
        Me.dtpOUACFEIN.Size = New System.Drawing.Size(21, 20)
        Me.dtpOUACFEIN.TabIndex = 7
        '
        'txtOUACFEIN
        '
        Me.txtOUACFEIN.AccessibleDescription = "Fecha de informe"
        Me.txtOUACFEIN.BackColor = System.Drawing.Color.White
        Me.txtOUACFEIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUACFEIN.Location = New System.Drawing.Point(144, 114)
        Me.txtOUACFEIN.Mask = "00-00-0000"
        Me.txtOUACFEIN.Name = "txtOUACFEIN"
        Me.txtOUACFEIN.Size = New System.Drawing.Size(172, 20)
        Me.txtOUACFEIN.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(16, 115)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(125, 20)
        Me.Label13.TabIndex = 436
        Me.Label13.Text = "Fecha de informe"
        '
        'dtpOUACFEVI
        '
        Me.dtpOUACFEVI.Location = New System.Drawing.Point(321, 91)
        Me.dtpOUACFEVI.Name = "dtpOUACFEVI"
        Me.dtpOUACFEVI.Size = New System.Drawing.Size(21, 20)
        Me.dtpOUACFEVI.TabIndex = 5
        '
        'txtOUACFEVI
        '
        Me.txtOUACFEVI.AccessibleDescription = "Fecha de visita"
        Me.txtOUACFEVI.BackColor = System.Drawing.Color.White
        Me.txtOUACFEVI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUACFEVI.Location = New System.Drawing.Point(144, 91)
        Me.txtOUACFEVI.Mask = "00-00-0000"
        Me.txtOUACFEVI.Name = "txtOUACFEVI"
        Me.txtOUACFEVI.Size = New System.Drawing.Size(172, 20)
        Me.txtOUACFEVI.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(16, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(125, 20)
        Me.Label12.TabIndex = 433
        Me.Label12.Text = "Fecha de visita"
        '
        'cboOUACESTA
        '
        Me.cboOUACESTA.AccessibleDescription = "Estado"
        Me.cboOUACESTA.BackColor = System.Drawing.Color.White
        Me.cboOUACESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUACESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUACESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUACESTA.Location = New System.Drawing.Point(144, 298)
        Me.cboOUACESTA.MaxDropDownItems = 15
        Me.cboOUACESTA.MaxLength = 1
        Me.cboOUACESTA.Name = "cboOUACESTA"
        Me.cboOUACESTA.Size = New System.Drawing.Size(173, 22)
        Me.cboOUACESTA.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(16, 299)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 20)
        Me.Label8.TabIndex = 421
        Me.Label8.Text = "Estado"
        '
        'txtOUACAVCO
        '
        Me.txtOUACAVCO.AccessibleDescription = "Avalúo comercial"
        Me.txtOUACAVCO.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUACAVCO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUACAVCO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUACAVCO.ForeColor = System.Drawing.Color.Black
        Me.txtOUACAVCO.Location = New System.Drawing.Point(144, 253)
        Me.txtOUACAVCO.MaxLength = 12
        Me.txtOUACAVCO.Name = "txtOUACAVCO"
        Me.txtOUACAVCO.Size = New System.Drawing.Size(172, 20)
        Me.txtOUACAVCO.TabIndex = 13
        '
        'cboOUACVIAV
        '
        Me.cboOUACVIAV.AccessibleDescription = "Viegncia de avalúo"
        Me.cboOUACVIAV.BackColor = System.Drawing.Color.White
        Me.cboOUACVIAV.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOUACVIAV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOUACVIAV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOUACVIAV.Location = New System.Drawing.Point(144, 45)
        Me.cboOUACVIAV.MaxDropDownItems = 15
        Me.cboOUACVIAV.MaxLength = 1
        Me.cboOUACVIAV.Name = "cboOUACVIAV"
        Me.cboOUACVIAV.Size = New System.Drawing.Size(173, 22)
        Me.cboOUACVIAV.TabIndex = 2
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
        Me.Label9.Text = "Avalúo comercial"
        '
        'lblOUACVIAV
        '
        Me.lblOUACVIAV.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblOUACVIAV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOUACVIAV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOUACVIAV.ForeColor = System.Drawing.Color.Black
        Me.lblOUACVIAV.Location = New System.Drawing.Point(320, 47)
        Me.lblOUACVIAV.Name = "lblOUACVIAV"
        Me.lblOUACVIAV.Size = New System.Drawing.Size(360, 20)
        Me.lblOUACVIAV.TabIndex = 410
        '
        'txtOUACNUAV
        '
        Me.txtOUACNUAV.AccessibleDescription = "Nro. de avalúo"
        Me.txtOUACNUAV.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUACNUAV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUACNUAV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUACNUAV.ForeColor = System.Drawing.Color.Black
        Me.txtOUACNUAV.Location = New System.Drawing.Point(144, 23)
        Me.txtOUACNUAV.MaxLength = 9
        Me.txtOUACNUAV.Name = "txtOUACNUAV"
        Me.txtOUACNUAV.Size = New System.Drawing.Size(172, 20)
        Me.txtOUACNUAV.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(16, 230)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 20)
        Me.Label5.TabIndex = 423
        Me.Label5.Text = "Área de terreno m2"
        '
        'txtOUACACM2
        '
        Me.txtOUACACM2.AccessibleDescription = "Avalúo comercial m2"
        Me.txtOUACACM2.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUACACM2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUACACM2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUACACM2.ForeColor = System.Drawing.Color.Black
        Me.txtOUACACM2.Location = New System.Drawing.Point(144, 276)
        Me.txtOUACACM2.MaxLength = 12
        Me.txtOUACACM2.Name = "txtOUACACM2"
        Me.txtOUACACM2.Size = New System.Drawing.Size(172, 20)
        Me.txtOUACACM2.TabIndex = 14
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
        Me.Label3.Text = "Nro. de avalúo"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(16, 276)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(125, 20)
        Me.Label10.TabIndex = 428
        Me.Label10.Text = "Avalúo comercial m2"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 20)
        Me.Label4.TabIndex = 405
        Me.Label4.Text = "Vigencia del avalúo"
        '
        'txtOUACARTE
        '
        Me.txtOUACARTE.AccessibleDescription = "Área de terreno"
        Me.txtOUACARTE.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUACARTE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUACARTE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUACARTE.ForeColor = System.Drawing.Color.Black
        Me.txtOUACARTE.Location = New System.Drawing.Point(144, 230)
        Me.txtOUACARTE.MaxLength = 9
        Me.txtOUACARTE.Name = "txtOUACARTE"
        Me.txtOUACARTE.Size = New System.Drawing.Size(172, 20)
        Me.txtOUACARTE.TabIndex = 12
        '
        'txtOUACSOLI
        '
        Me.txtOUACSOLI.AccessibleDescription = "Solicitante"
        Me.txtOUACSOLI.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUACSOLI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUACSOLI.Location = New System.Drawing.Point(144, 138)
        Me.txtOUACSOLI.MaxLength = 100
        Me.txtOUACSOLI.Name = "txtOUACSOLI"
        Me.txtOUACSOLI.Size = New System.Drawing.Size(536, 20)
        Me.txtOUACSOLI.TabIndex = 8
        '
        'txtOUACEMPR
        '
        Me.txtOUACEMPR.AccessibleDescription = "Empresa"
        Me.txtOUACEMPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUACEMPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUACEMPR.Location = New System.Drawing.Point(144, 69)
        Me.txtOUACEMPR.MaxLength = 100
        Me.txtOUACEMPR.Name = "txtOUACEMPR"
        Me.txtOUACEMPR.Size = New System.Drawing.Size(536, 20)
        Me.txtOUACEMPR.TabIndex = 3
        '
        'txtOUACDIRE
        '
        Me.txtOUACDIRE.AccessibleDescription = "Dirección"
        Me.txtOUACDIRE.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUACDIRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUACDIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUACDIRE.ForeColor = System.Drawing.Color.Black
        Me.txtOUACDIRE.Location = New System.Drawing.Point(144, 207)
        Me.txtOUACDIRE.MaxLength = 100
        Me.txtOUACDIRE.Name = "txtOUACDIRE"
        Me.txtOUACDIRE.Size = New System.Drawing.Size(536, 20)
        Me.txtOUACDIRE.TabIndex = 11
        '
        'txtOUACPROY
        '
        Me.txtOUACPROY.AccessibleDescription = "Proyecto"
        Me.txtOUACPROY.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUACPROY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUACPROY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUACPROY.ForeColor = System.Drawing.Color.Black
        Me.txtOUACPROY.Location = New System.Drawing.Point(144, 184)
        Me.txtOUACPROY.MaxLength = 100
        Me.txtOUACPROY.Name = "txtOUACPROY"
        Me.txtOUACPROY.Size = New System.Drawing.Size(536, 20)
        Me.txtOUACPROY.TabIndex = 10
        '
        'txtOUACPUNT
        '
        Me.txtOUACPUNT.AccessibleDescription = "Punto"
        Me.txtOUACPUNT.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUACPUNT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUACPUNT.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUACPUNT.ForeColor = System.Drawing.Color.Black
        Me.txtOUACPUNT.Location = New System.Drawing.Point(144, 161)
        Me.txtOUACPUNT.MaxLength = 10
        Me.txtOUACPUNT.Name = "txtOUACPUNT"
        Me.txtOUACPUNT.Size = New System.Drawing.Size(173, 20)
        Me.txtOUACPUNT.TabIndex = 9
        '
        'lblPredio
        '
        Me.lblPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredio.ForeColor = System.Drawing.Color.Black
        Me.lblPredio.Location = New System.Drawing.Point(16, 207)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(125, 20)
        Me.lblPredio.TabIndex = 394
        Me.lblPredio.Text = "Dirección"
        '
        'lblManzana
        '
        Me.lblManzana.AccessibleDescription = ""
        Me.lblManzana.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblManzana.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblManzana.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManzana.ForeColor = System.Drawing.Color.Black
        Me.lblManzana.Location = New System.Drawing.Point(16, 184)
        Me.lblManzana.Name = "lblManzana"
        Me.lblManzana.Size = New System.Drawing.Size(125, 20)
        Me.lblManzana.TabIndex = 393
        Me.lblManzana.Text = "Proyecto"
        '
        'lblBarrio
        '
        Me.lblBarrio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblBarrio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBarrio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarrio.ForeColor = System.Drawing.Color.Black
        Me.lblBarrio.Location = New System.Drawing.Point(16, 161)
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Size = New System.Drawing.Size(125, 20)
        Me.lblBarrio.TabIndex = 392
        Me.lblBarrio.Text = "Punto"
        '
        'lblCorregimiento
        '
        Me.lblCorregimiento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCorregimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorregimiento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorregimiento.ForeColor = System.Drawing.Color.Black
        Me.lblCorregimiento.Location = New System.Drawing.Point(16, 138)
        Me.lblCorregimiento.Name = "lblCorregimiento"
        Me.lblCorregimiento.Size = New System.Drawing.Size(125, 20)
        Me.lblCorregimiento.TabIndex = 396
        Me.lblCorregimiento.Text = "Solicitante"
        '
        'lblMunicipio
        '
        Me.lblMunicipio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblMunicipio.Location = New System.Drawing.Point(16, 69)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(125, 20)
        Me.lblMunicipio.TabIndex = 398
        Me.lblMunicipio.Text = "Empresa"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(348, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 20)
        Me.Label1.TabIndex = 437
        Me.Label1.Text = "( dd-mm-aaaa )"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(348, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 20)
        Me.Label2.TabIndex = 438
        Me.Label2.Text = "( dd-mm-aaaa )"
        '
        'frm_insertar_OBURAVCO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 443)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCEDUCATA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(744, 479)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(744, 479)
        Me.Name = "frm_insertar_OBURAVCO"
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
    Friend WithEvents txtOUACAVCO As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtOUACACM2 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtOUACARTE As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboOUACESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboOUACVIAV As System.Windows.Forms.ComboBox
    Friend WithEvents lblOUACVIAV As System.Windows.Forms.Label
    Friend WithEvents txtOUACNUAV As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtOUACSOLI As System.Windows.Forms.TextBox
    Friend WithEvents txtOUACEMPR As System.Windows.Forms.TextBox
    Friend WithEvents txtOUACDIRE As System.Windows.Forms.TextBox
    Friend WithEvents txtOUACPROY As System.Windows.Forms.TextBox
    Friend WithEvents txtOUACPUNT As System.Windows.Forms.TextBox
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents dtpOUACFEIN As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtOUACFEIN As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpOUACFEVI As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtOUACFEVI As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
