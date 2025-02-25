<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_RECOPRSE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_insertar_RECOPRSE))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraCEDUCATA = New System.Windows.Forms.GroupBox()
        Me.txtRCPSDIRE = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRCPSUNPR = New System.Windows.Forms.TextBox()
        Me.txtRCPSEDIF = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboRCPSESTA = New System.Windows.Forms.ComboBox()
        Me.cboRCPSCLSE = New System.Windows.Forms.ComboBox()
        Me.lblRCPSCLSE = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRCPSMAIN = New System.Windows.Forms.TextBox()
        Me.txtRCPSNUFI = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtRCPSCORR = New System.Windows.Forms.TextBox()
        Me.txtRCPSMUNI = New System.Windows.Forms.TextBox()
        Me.txtRCPSPRED = New System.Windows.Forms.TextBox()
        Me.txtRCPSMANZ = New System.Windows.Forms.TextBox()
        Me.txtRCPSBARR = New System.Windows.Forms.TextBox()
        Me.lblCodigoActual = New System.Windows.Forms.Label()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.lblManzana = New System.Windows.Forms.Label()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdLIMPIAR = New System.Windows.Forms.Button()
        Me.cmdCONSULTAR = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgvRECOPRRE = New System.Windows.Forms.DataGridView()
        Me.GroupBox2.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraCEDUCATA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvRECOPRRE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdSALIR)
        Me.GroupBox2.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 476)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(752, 46)
        Me.GroupBox2.TabIndex = 345
        Me.GroupBox2.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = CType(resources.GetObject("cmdSALIR.Image"), System.Drawing.Image)
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(379, 17)
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
        Me.cmdGUARDAR.Location = New System.Drawing.Point(272, 17)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 541)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(777, 25)
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
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPSDIRE)
        Me.fraCEDUCATA.Controls.Add(Me.Label7)
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPSUNPR)
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPSEDIF)
        Me.fraCEDUCATA.Controls.Add(Me.Label1)
        Me.fraCEDUCATA.Controls.Add(Me.Label6)
        Me.fraCEDUCATA.Controls.Add(Me.cboRCPSESTA)
        Me.fraCEDUCATA.Controls.Add(Me.cboRCPSCLSE)
        Me.fraCEDUCATA.Controls.Add(Me.lblRCPSCLSE)
        Me.fraCEDUCATA.Controls.Add(Me.Label5)
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPSMAIN)
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPSNUFI)
        Me.fraCEDUCATA.Controls.Add(Me.Label2)
        Me.fraCEDUCATA.Controls.Add(Me.Label3)
        Me.fraCEDUCATA.Controls.Add(Me.Label4)
        Me.fraCEDUCATA.Controls.Add(Me.Label33)
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPSCORR)
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPSMUNI)
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPSPRED)
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPSMANZ)
        Me.fraCEDUCATA.Controls.Add(Me.txtRCPSBARR)
        Me.fraCEDUCATA.Controls.Add(Me.lblCodigoActual)
        Me.fraCEDUCATA.Controls.Add(Me.lblPredio)
        Me.fraCEDUCATA.Controls.Add(Me.lblManzana)
        Me.fraCEDUCATA.Controls.Add(Me.lblBarrio)
        Me.fraCEDUCATA.Controls.Add(Me.lblCorregimiento)
        Me.fraCEDUCATA.Controls.Add(Me.lblMunicipio)
        Me.fraCEDUCATA.Controls.Add(Me.lblCodigo)
        Me.fraCEDUCATA.Location = New System.Drawing.Point(12, 8)
        Me.fraCEDUCATA.Name = "fraCEDUCATA"
        Me.fraCEDUCATA.Size = New System.Drawing.Size(752, 227)
        Me.fraCEDUCATA.TabIndex = 344
        Me.fraCEDUCATA.TabStop = False
        Me.fraCEDUCATA.Text = "PARAMETROS DE CONSULTA"
        '
        'txtRCPSDIRE
        '
        Me.txtRCPSDIRE.AccessibleDescription = "Dirección"
        Me.txtRCPSDIRE.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPSDIRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRCPSDIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPSDIRE.ForeColor = System.Drawing.Color.Black
        Me.txtRCPSDIRE.Location = New System.Drawing.Point(144, 118)
        Me.txtRCPSDIRE.MaxLength = 50
        Me.txtRCPSDIRE.Name = "txtRCPSDIRE"
        Me.txtRCPSDIRE.Size = New System.Drawing.Size(592, 20)
        Me.txtRCPSDIRE.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AccessibleDescription = ""
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(16, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 20)
        Me.Label7.TabIndex = 416
        Me.Label7.Text = "Dirección"
        '
        'txtRCPSUNPR
        '
        Me.txtRCPSUNPR.AccessibleDescription = "Unidad Predial"
        Me.txtRCPSUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPSUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRCPSUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPSUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtRCPSUNPR.Location = New System.Drawing.Point(654, 71)
        Me.txtRCPSUNPR.MaxLength = 5
        Me.txtRCPSUNPR.Name = "txtRCPSUNPR"
        Me.txtRCPSUNPR.Size = New System.Drawing.Size(82, 20)
        Me.txtRCPSUNPR.TabIndex = 7
        '
        'txtRCPSEDIF
        '
        Me.txtRCPSEDIF.AccessibleDescription = "Edificio"
        Me.txtRCPSEDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPSEDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRCPSEDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPSEDIF.ForeColor = System.Drawing.Color.Black
        Me.txtRCPSEDIF.Location = New System.Drawing.Point(569, 71)
        Me.txtRCPSEDIF.MaxLength = 3
        Me.txtRCPSEDIF.Name = "txtRCPSEDIF"
        Me.txtRCPSEDIF.Size = New System.Drawing.Size(83, 20)
        Me.txtRCPSEDIF.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(654, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 20)
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
        Me.Label6.Location = New System.Drawing.Point(569, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 20)
        Me.Label6.TabIndex = 413
        Me.Label6.Text = "Edificio"
        '
        'cboRCPSESTA
        '
        Me.cboRCPSESTA.AccessibleDescription = "Estado"
        Me.cboRCPSESTA.BackColor = System.Drawing.Color.White
        Me.cboRCPSESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRCPSESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRCPSESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRCPSESTA.Location = New System.Drawing.Point(144, 186)
        Me.cboRCPSESTA.MaxDropDownItems = 15
        Me.cboRCPSESTA.MaxLength = 1
        Me.cboRCPSESTA.Name = "cboRCPSESTA"
        Me.cboRCPSESTA.Size = New System.Drawing.Size(229, 22)
        Me.cboRCPSESTA.TabIndex = 12
        '
        'cboRCPSCLSE
        '
        Me.cboRCPSCLSE.AccessibleDescription = "Clase o sector "
        Me.cboRCPSCLSE.BackColor = System.Drawing.Color.White
        Me.cboRCPSCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRCPSCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRCPSCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRCPSCLSE.Location = New System.Drawing.Point(144, 94)
        Me.cboRCPSCLSE.MaxDropDownItems = 15
        Me.cboRCPSCLSE.MaxLength = 1
        Me.cboRCPSCLSE.Name = "cboRCPSCLSE"
        Me.cboRCPSCLSE.Size = New System.Drawing.Size(229, 22)
        Me.cboRCPSCLSE.TabIndex = 8
        '
        'lblRCPSCLSE
        '
        Me.lblRCPSCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRCPSCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRCPSCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRCPSCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblRCPSCLSE.Location = New System.Drawing.Point(376, 95)
        Me.lblRCPSCLSE.Name = "lblRCPSCLSE"
        Me.lblRCPSCLSE.Size = New System.Drawing.Size(360, 20)
        Me.lblRCPSCLSE.TabIndex = 410
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(16, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 20)
        Me.Label5.TabIndex = 408
        Me.Label5.Text = "Estado"
        '
        'txtRCPSMAIN
        '
        Me.txtRCPSMAIN.AccessibleDescription = "Matricula inmobiliaria"
        Me.txtRCPSMAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPSMAIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRCPSMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPSMAIN.ForeColor = System.Drawing.Color.Black
        Me.txtRCPSMAIN.Location = New System.Drawing.Point(144, 163)
        Me.txtRCPSMAIN.MaxLength = 11
        Me.txtRCPSMAIN.Name = "txtRCPSMAIN"
        Me.txtRCPSMAIN.Size = New System.Drawing.Size(229, 20)
        Me.txtRCPSMAIN.TabIndex = 11
        '
        'txtRCPSNUFI
        '
        Me.txtRCPSNUFI.AccessibleDescription = "Edificio"
        Me.txtRCPSNUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPSNUFI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRCPSNUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPSNUFI.ForeColor = System.Drawing.Color.Black
        Me.txtRCPSNUFI.Location = New System.Drawing.Point(144, 141)
        Me.txtRCPSNUFI.MaxLength = 9
        Me.txtRCPSNUFI.Name = "txtRCPSNUFI"
        Me.txtRCPSNUFI.Size = New System.Drawing.Size(229, 20)
        Me.txtRCPSNUFI.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 164)
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
        Me.Label3.Location = New System.Drawing.Point(16, 141)
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
        Me.Label33.Size = New System.Drawing.Size(720, 20)
        Me.Label33.TabIndex = 397
        Me.Label33.Text = "CEDULA CATASTRAL ACTUAL"
        '
        'txtRCPSCORR
        '
        Me.txtRCPSCORR.AccessibleDescription = "Corregimiento"
        Me.txtRCPSCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPSCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPSCORR.Location = New System.Drawing.Point(229, 71)
        Me.txtRCPSCORR.MaxLength = 2
        Me.txtRCPSCORR.Name = "txtRCPSCORR"
        Me.txtRCPSCORR.Size = New System.Drawing.Size(83, 20)
        Me.txtRCPSCORR.TabIndex = 2
        '
        'txtRCPSMUNI
        '
        Me.txtRCPSMUNI.AccessibleDescription = "Municipio"
        Me.txtRCPSMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPSMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPSMUNI.Location = New System.Drawing.Point(144, 71)
        Me.txtRCPSMUNI.MaxLength = 3
        Me.txtRCPSMUNI.Name = "txtRCPSMUNI"
        Me.txtRCPSMUNI.Size = New System.Drawing.Size(83, 20)
        Me.txtRCPSMUNI.TabIndex = 1
        '
        'txtRCPSPRED
        '
        Me.txtRCPSPRED.AccessibleDescription = "Predio "
        Me.txtRCPSPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPSPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRCPSPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPSPRED.ForeColor = System.Drawing.Color.Black
        Me.txtRCPSPRED.Location = New System.Drawing.Point(484, 71)
        Me.txtRCPSPRED.MaxLength = 5
        Me.txtRCPSPRED.Name = "txtRCPSPRED"
        Me.txtRCPSPRED.Size = New System.Drawing.Size(82, 20)
        Me.txtRCPSPRED.TabIndex = 5
        '
        'txtRCPSMANZ
        '
        Me.txtRCPSMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtRCPSMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPSMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRCPSMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPSMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtRCPSMANZ.Location = New System.Drawing.Point(399, 71)
        Me.txtRCPSMANZ.MaxLength = 3
        Me.txtRCPSMANZ.Name = "txtRCPSMANZ"
        Me.txtRCPSMANZ.Size = New System.Drawing.Size(83, 20)
        Me.txtRCPSMANZ.TabIndex = 4
        '
        'txtRCPSBARR
        '
        Me.txtRCPSBARR.AccessibleDescription = "Barrio "
        Me.txtRCPSBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRCPSBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRCPSBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRCPSBARR.ForeColor = System.Drawing.Color.Black
        Me.txtRCPSBARR.Location = New System.Drawing.Point(314, 71)
        Me.txtRCPSBARR.MaxLength = 3
        Me.txtRCPSBARR.Name = "txtRCPSBARR"
        Me.txtRCPSBARR.Size = New System.Drawing.Size(83, 20)
        Me.txtRCPSBARR.TabIndex = 3
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
        Me.lblPredio.Location = New System.Drawing.Point(484, 48)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(82, 20)
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
        Me.lblManzana.Size = New System.Drawing.Size(82, 20)
        Me.lblManzana.TabIndex = 393
        Me.lblManzana.Text = "Manz / Vere"
        '
        'lblBarrio
        '
        Me.lblBarrio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblBarrio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBarrio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarrio.ForeColor = System.Drawing.Color.Black
        Me.lblBarrio.Location = New System.Drawing.Point(314, 48)
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Size = New System.Drawing.Size(82, 20)
        Me.lblBarrio.TabIndex = 392
        Me.lblBarrio.Text = "Barrio"
        '
        'lblCorregimiento
        '
        Me.lblCorregimiento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCorregimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorregimiento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorregimiento.ForeColor = System.Drawing.Color.Black
        Me.lblCorregimiento.Location = New System.Drawing.Point(229, 48)
        Me.lblCorregimiento.Name = "lblCorregimiento"
        Me.lblCorregimiento.Size = New System.Drawing.Size(82, 20)
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
        Me.lblMunicipio.Size = New System.Drawing.Size(82, 20)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdLIMPIAR)
        Me.GroupBox1.Controls.Add(Me.cmdCONSULTAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 241)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(752, 46)
        Me.GroupBox1.TabIndex = 347
        Me.GroupBox1.TabStop = False
        '
        'cmdLIMPIAR
        '
        Me.cmdLIMPIAR.AccessibleDescription = "Limpiar"
        Me.cmdLIMPIAR.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLIMPIAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLIMPIAR.Location = New System.Drawing.Point(379, 15)
        Me.cmdLIMPIAR.Name = "cmdLIMPIAR"
        Me.cmdLIMPIAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdLIMPIAR.TabIndex = 18
        Me.cmdLIMPIAR.Text = "&Limpiar"
        Me.cmdLIMPIAR.UseVisualStyleBackColor = True
        '
        'cmdCONSULTAR
        '
        Me.cmdCONSULTAR.AccessibleDescription = "Consultar"
        Me.cmdCONSULTAR.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdCONSULTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCONSULTAR.Location = New System.Drawing.Point(272, 15)
        Me.cmdCONSULTAR.Name = "cmdCONSULTAR"
        Me.cmdCONSULTAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdCONSULTAR.TabIndex = 17
        Me.cmdCONSULTAR.Text = "&Consultar"
        Me.cmdCONSULTAR.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvRECOPRRE)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 293)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(752, 177)
        Me.GroupBox3.TabIndex = 348
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "CONSULTA DE PREDIOS"
        '
        'dgvRECOPRRE
        '
        Me.dgvRECOPRRE.AccessibleDescription = "Predio"
        Me.dgvRECOPRRE.AllowUserToAddRows = False
        Me.dgvRECOPRRE.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvRECOPRRE.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRECOPRRE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRECOPRRE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvRECOPRRE.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvRECOPRRE.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvRECOPRRE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvRECOPRRE.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRECOPRRE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRECOPRRE.ColumnHeadersHeight = 40
        Me.dgvRECOPRRE.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRECOPRRE.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvRECOPRRE.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvRECOPRRE.Location = New System.Drawing.Point(16, 19)
        Me.dgvRECOPRRE.Name = "dgvRECOPRRE"
        Me.dgvRECOPRRE.ReadOnly = True
        Me.dgvRECOPRRE.RowHeadersVisible = False
        Me.dgvRECOPRRE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRECOPRRE.ShowCellToolTips = False
        Me.dgvRECOPRRE.Size = New System.Drawing.Size(721, 143)
        Me.dgvRECOPRRE.StandardTab = True
        Me.dgvRECOPRRE.TabIndex = 330
        '
        'frm_insertar_RECOPRSE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 566)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCEDUCATA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(793, 602)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(793, 602)
        Me.Name = "frm_insertar_RECOPRSE"
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
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvRECOPRRE, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cboRCPSESTA As System.Windows.Forms.ComboBox
    Friend WithEvents cboRCPSCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblRCPSCLSE As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRCPSMAIN As System.Windows.Forms.TextBox
    Friend WithEvents txtRCPSNUFI As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtRCPSCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtRCPSMUNI As System.Windows.Forms.TextBox
    Friend WithEvents txtRCPSPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtRCPSMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtRCPSBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCONSULTAR As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvRECOPRRE As System.Windows.Forms.DataGridView
    Friend WithEvents cmdLIMPIAR As System.Windows.Forms.Button
    Friend WithEvents txtRCPSDIRE As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRCPSUNPR As System.Windows.Forms.TextBox
    Friend WithEvents txtRCPSEDIF As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
