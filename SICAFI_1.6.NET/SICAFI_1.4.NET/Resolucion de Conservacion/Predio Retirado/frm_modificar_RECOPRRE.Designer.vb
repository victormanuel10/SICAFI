<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_RECOPRRE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_modificar_RECOPRRE))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraCEDUCATA = New System.Windows.Forms.GroupBox()
        Me.txtRCPRDIRE = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRCPRUNPR = New System.Windows.Forms.TextBox()
        Me.txtRCPREDIF = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboRCPRESTA = New System.Windows.Forms.ComboBox()
        Me.cboRCPRCLSE = New System.Windows.Forms.ComboBox()
        Me.lblRCPRCLSE = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRCPRMAIN = New System.Windows.Forms.TextBox()
        Me.txtRCPRNUFI = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtRCPRCORR = New System.Windows.Forms.TextBox()
        Me.txtRCPRMUNI = New System.Windows.Forms.TextBox()
        Me.txtRCPRPRED = New System.Windows.Forms.TextBox()
        Me.txtRCPRMANZ = New System.Windows.Forms.TextBox()
        Me.txtRCPRBARR = New System.Windows.Forms.TextBox()
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
        Me.GroupBox2.Location = New System.Drawing.Point(12, 242)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(753, 46)
        Me.GroupBox2.TabIndex = 351
        Me.GroupBox2.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = CType(resources.GetObject("cmdSALIR.Image"), System.Drawing.Image)
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(380, 15)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(273, 15)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 309)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(777, 25)
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
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPRDIRE)
        Me.fraCEDUCATA.Controls.Add(Me.Label7)
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPRUNPR)
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPREDIF)
        Me.fraCEDUCATA.Controls.Add(Me.Label1)
        Me.fraCEDUCATA.Controls.Add(Me.Label6)
        Me.fraCEDUCATA.Controls.Add(Me.cboRCPRESTA)
        Me.fraCEDUCATA.Controls.Add(Me.cboRCPRCLSE)
        Me.fraCEDUCATA.Controls.Add(Me.lblRCPRCLSE)
        Me.fraCEDUCATA.Controls.Add(Me.Label5)
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPRMAIN)
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPRNUFI)
        Me.fraCEDUCATA.Controls.Add(Me.Label2)
        Me.fraCEDUCATA.Controls.Add(Me.Label3)
        Me.fraCEDUCATA.Controls.Add(Me.Label4)
        Me.fraCEDUCATA.Controls.Add(Me.Label33)
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPRCORR)
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPRMUNI)
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPRPRED)
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPRMANZ)
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPRBARR)
        Me.fraCEDUCATA.Controls.Add(Me.lblCodigoActual)
        Me.fraCEDUCATA.Controls.Add(Me.lblPredio)
        Me.fraCEDUCATA.Controls.Add(Me.lblManzana)
        Me.fraCEDUCATA.Controls.Add(Me.lblBarrio)
        Me.fraCEDUCATA.Controls.Add(Me.lblCorregimiento)
        Me.fraCEDUCATA.Controls.Add(Me.lblMunicipio)
        Me.fraCEDUCATA.Controls.Add(Me.lblCodigo)
        Me.fraCEDUCATA.Location = New System.Drawing.Point(12, 9)
        Me.fraCEDUCATA.Name = "fraCEDUCATA"
        Me.fraCEDUCATA.Size = New System.Drawing.Size(753, 227)
        Me.fraCEDUCATA.TabIndex = 350
        Me.fraCEDUCATA.TabStop = False
        Me.fraCEDUCATA.Text = "MODIFICA PREDIO RETIRADO"
        '
        'txtRCPRDIRE
        '
        Me.txtRCPRDIRE.AccessibleDescription = "Dirección"
        Me.txtRCPRDIRE.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPRDIRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRCPRDIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPRDIRE.ForeColor = System.Drawing.Color.Black
        Me.txtRCPRDIRE.Location = New System.Drawing.Point(141, 117)
        Me.txtRCPRDIRE.MaxLength = 50
        Me.txtRCPRDIRE.Name = "txtRCPRDIRE"
        Me.txtRCPRDIRE.Size = New System.Drawing.Size(599, 20)
        Me.txtRCPRDIRE.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AccessibleDescription = ""
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(13, 117)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 20)
        Me.Label7.TabIndex = 416
        Me.Label7.Text = "Dirección"
        '
        'txtRCPRUNPR
        '
        Me.txtRCPRUNPR.AccessibleDescription = "Unidad Predial"
        Me.txtRCPRUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPRUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRCPRUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPRUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtRCPRUNPR.Location = New System.Drawing.Point(657, 71)
        Me.txtRCPRUNPR.MaxLength = 5
        Me.txtRCPRUNPR.Name = "txtRCPRUNPR"
        Me.txtRCPRUNPR.Size = New System.Drawing.Size(83, 20)
        Me.txtRCPRUNPR.TabIndex = 7
        '
        'txtRCPREDIF
        '
        Me.txtRCPREDIF.AccessibleDescription = "Edificio"
        Me.txtRCPREDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPREDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRCPREDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPREDIF.ForeColor = System.Drawing.Color.Black
        Me.txtRCPREDIF.Location = New System.Drawing.Point(571, 71)
        Me.txtRCPREDIF.MaxLength = 3
        Me.txtRCPREDIF.Name = "txtRCPREDIF"
        Me.txtRCPREDIF.Size = New System.Drawing.Size(83, 20)
        Me.txtRCPREDIF.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(657, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 20)
        Me.Label1.TabIndex = 414
        Me.Label1.Text = "Unidad Predial"
        '
        'Label6
        '
        Me.Label6.AccessibleDescription = ""
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(571, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 20)
        Me.Label6.TabIndex = 413
        Me.Label6.Text = "Edificio"
        '
        'cboRCPRESTA
        '
        Me.cboRCPRESTA.AccessibleDescription = "Estado"
        Me.cboRCPRESTA.BackColor = System.Drawing.Color.White
        Me.cboRCPRESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRCPRESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRCPRESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRCPRESTA.Location = New System.Drawing.Point(141, 185)
        Me.cboRCPRESTA.MaxDropDownItems = 15
        Me.cboRCPRESTA.MaxLength = 1
        Me.cboRCPRESTA.Name = "cboRCPRESTA"
        Me.cboRCPRESTA.Size = New System.Drawing.Size(255, 22)
        Me.cboRCPRESTA.TabIndex = 12
        '
        'cboRCPRCLSE
        '
        Me.cboRCPRCLSE.AccessibleDescription = "Clase o sector "
        Me.cboRCPRCLSE.BackColor = System.Drawing.Color.White
        Me.cboRCPRCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRCPRCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRCPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRCPRCLSE.Location = New System.Drawing.Point(141, 94)
        Me.cboRCPRCLSE.MaxDropDownItems = 15
        Me.cboRCPRCLSE.MaxLength = 1
        Me.cboRCPRCLSE.Name = "cboRCPRCLSE"
        Me.cboRCPRCLSE.Size = New System.Drawing.Size(255, 22)
        Me.cboRCPRCLSE.TabIndex = 8
        '
        'lblRCPRCLSE
        '
        Me.lblRCPRCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRCPRCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRCPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRCPRCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblRCPRCLSE.Location = New System.Drawing.Point(399, 95)
        Me.lblRCPRCLSE.Name = "lblRCPRCLSE"
        Me.lblRCPRCLSE.Size = New System.Drawing.Size(341, 20)
        Me.lblRCPRCLSE.TabIndex = 410
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(13, 186)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 20)
        Me.Label5.TabIndex = 408
        Me.Label5.Text = "Estado"
        '
        'txtRCPRMAIN
        '
        Me.txtRCPRMAIN.AccessibleDescription = "Matricula inmobiliaria"
        Me.txtRCPRMAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPRMAIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRCPRMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPRMAIN.ForeColor = System.Drawing.Color.Black
        Me.txtRCPRMAIN.Location = New System.Drawing.Point(141, 162)
        Me.txtRCPRMAIN.MaxLength = 11
        Me.txtRCPRMAIN.Name = "txtRCPRMAIN"
        Me.txtRCPRMAIN.Size = New System.Drawing.Size(255, 20)
        Me.txtRCPRMAIN.TabIndex = 11
        '
        'txtRCPRNUFI
        '
        Me.txtRCPRNUFI.AccessibleDescription = "Edificio"
        Me.txtRCPRNUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPRNUFI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRCPRNUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPRNUFI.ForeColor = System.Drawing.Color.Black
        Me.txtRCPRNUFI.Location = New System.Drawing.Point(141, 140)
        Me.txtRCPRNUFI.MaxLength = 9
        Me.txtRCPRNUFI.Name = "txtRCPRNUFI"
        Me.txtRCPRNUFI.ReadOnly = True
        Me.txtRCPRNUFI.Size = New System.Drawing.Size(255, 20)
        Me.txtRCPRNUFI.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(13, 163)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 20)
        Me.Label2.TabIndex = 407
        Me.Label2.Text = "Matricula inmobiliaria"
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = ""
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(13, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 20)
        Me.Label3.TabIndex = 406
        Me.Label3.Text = "Nro. Ficha Predial"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(13, 94)
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
        Me.Label33.Location = New System.Drawing.Point(13, 25)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(727, 20)
        Me.Label33.TabIndex = 397
        Me.Label33.Text = "CEDULA CATASTRAL ACTUAL"
        '
        'txtRCPRCORR
        '
        Me.txtRCPRCORR.AccessibleDescription = "Corregimiento"
        Me.txtRCPRCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPRCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPRCORR.Location = New System.Drawing.Point(227, 71)
        Me.txtRCPRCORR.MaxLength = 2
        Me.txtRCPRCORR.Name = "txtRCPRCORR"
        Me.txtRCPRCORR.Size = New System.Drawing.Size(83, 20)
        Me.txtRCPRCORR.TabIndex = 2
        '
        'txtRCPRMUNI
        '
        Me.txtRCPRMUNI.AccessibleDescription = "Municipio"
        Me.txtRCPRMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPRMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPRMUNI.Location = New System.Drawing.Point(141, 71)
        Me.txtRCPRMUNI.MaxLength = 3
        Me.txtRCPRMUNI.Name = "txtRCPRMUNI"
        Me.txtRCPRMUNI.Size = New System.Drawing.Size(83, 20)
        Me.txtRCPRMUNI.TabIndex = 1
        '
        'txtRCPRPRED
        '
        Me.txtRCPRPRED.AccessibleDescription = "Predio "
        Me.txtRCPRPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPRPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRCPRPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPRPRED.ForeColor = System.Drawing.Color.Black
        Me.txtRCPRPRED.Location = New System.Drawing.Point(485, 71)
        Me.txtRCPRPRED.MaxLength = 5
        Me.txtRCPRPRED.Name = "txtRCPRPRED"
        Me.txtRCPRPRED.Size = New System.Drawing.Size(83, 20)
        Me.txtRCPRPRED.TabIndex = 5
        '
        'txtRCPRMANZ
        '
        Me.txtRCPRMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtRCPRMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPRMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRCPRMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPRMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtRCPRMANZ.Location = New System.Drawing.Point(399, 71)
        Me.txtRCPRMANZ.MaxLength = 3
        Me.txtRCPRMANZ.Name = "txtRCPRMANZ"
        Me.txtRCPRMANZ.Size = New System.Drawing.Size(83, 20)
        Me.txtRCPRMANZ.TabIndex = 4
        '
        'txtRCPRBARR
        '
        Me.txtRCPRBARR.AccessibleDescription = "Barrio "
        Me.txtRCPRBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPRBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRCPRBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPRBARR.ForeColor = System.Drawing.Color.Black
        Me.txtRCPRBARR.Location = New System.Drawing.Point(313, 71)
        Me.txtRCPRBARR.MaxLength = 3
        Me.txtRCPRBARR.Name = "txtRCPRBARR"
        Me.txtRCPRBARR.Size = New System.Drawing.Size(83, 20)
        Me.txtRCPRBARR.TabIndex = 3
        '
        'lblCodigoActual
        '
        Me.lblCodigoActual.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigoActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigoActual.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoActual.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoActual.Location = New System.Drawing.Point(13, 71)
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
        Me.lblPredio.Location = New System.Drawing.Point(485, 48)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(83, 20)
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
        Me.lblManzana.Location = New System.Drawing.Point(399, 48)
        Me.lblManzana.Name = "lblManzana"
        Me.lblManzana.Size = New System.Drawing.Size(83, 20)
        Me.lblManzana.TabIndex = 393
        Me.lblManzana.Text = "Manz / Vere"
        '
        'lblBarrio
        '
        Me.lblBarrio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblBarrio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBarrio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarrio.ForeColor = System.Drawing.Color.Black
        Me.lblBarrio.Location = New System.Drawing.Point(313, 48)
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Size = New System.Drawing.Size(83, 20)
        Me.lblBarrio.TabIndex = 392
        Me.lblBarrio.Text = "Barrio"
        '
        'lblCorregimiento
        '
        Me.lblCorregimiento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCorregimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorregimiento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorregimiento.ForeColor = System.Drawing.Color.Black
        Me.lblCorregimiento.Location = New System.Drawing.Point(227, 48)
        Me.lblCorregimiento.Name = "lblCorregimiento"
        Me.lblCorregimiento.Size = New System.Drawing.Size(83, 20)
        Me.lblCorregimiento.TabIndex = 396
        Me.lblCorregimiento.Text = "Corregimiento"
        '
        'lblMunicipio
        '
        Me.lblMunicipio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblMunicipio.Location = New System.Drawing.Point(141, 48)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(83, 20)
        Me.lblMunicipio.TabIndex = 398
        Me.lblMunicipio.Text = "Municipio"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(13, 48)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(125, 20)
        Me.lblCodigo.TabIndex = 399
        Me.lblCodigo.Text = "CODIGO"
        '
        'frm_modificar_RECOPRRE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 334)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCEDUCATA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(793, 370)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(793, 370)
        Me.Name = "frm_modificar_RECOPRRE"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
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
    Friend WithEvents txtRCPRDIRE As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRCPRUNPR As System.Windows.Forms.TextBox
    Friend WithEvents txtRCPREDIF As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboRCPRESTA As System.Windows.Forms.ComboBox
    Friend WithEvents cboRCPRCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblRCPRCLSE As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRCPRMAIN As System.Windows.Forms.TextBox
    Friend WithEvents txtRCPRNUFI As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtRCPRCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtRCPRMUNI As System.Windows.Forms.TextBox
    Friend WithEvents txtRCPRPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtRCPRMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtRCPRBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
End Class
