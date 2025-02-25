<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Marcar_Predio_Como_Conjunto
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
        Me.components = New System.ComponentModel.Container()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblFIPRMOAD = New System.Windows.Forms.Label()
        Me.txtFIPRTIFI = New System.Windows.Forms.TextBox()
        Me.lblFIPRCAPR = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblFIPRCASU = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFIPRCLSE = New System.Windows.Forms.Label()
        Me.txtFIPRFIFI = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFIPRMOAD = New System.Windows.Forms.TextBox()
        Me.txtFIPRFIIN = New System.Windows.Forms.TextBox()
        Me.txtFIPRCAPR = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFIPRCASU = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFIPRCLSE = New System.Windows.Forms.TextBox()
        Me.txtFIPRCORR = New System.Windows.Forms.TextBox()
        Me.txtFIPRMUNI = New System.Windows.Forms.TextBox()
        Me.txtFIPRUNPR = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.txtFIPREDIF = New System.Windows.Forms.TextBox()
        Me.lblAdquisicionDelPredio = New System.Windows.Forms.Label()
        Me.txtFIPRPRED = New System.Windows.Forms.TextBox()
        Me.txtFIPRMANZ = New System.Windows.Forms.TextBox()
        Me.txtFIPRBARR = New System.Windows.Forms.TextBox()
        Me.lblClaseOSector2 = New System.Windows.Forms.Label()
        Me.lblCategoriaDeSuelo = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.fraPROPIETARIO = New System.Windows.Forms.GroupBox()
        Me.chkPredioEnConjunto = New System.Windows.Forms.CheckBox()
        Me.cmdAPLICAR = New System.Windows.Forms.Button()
        Me.lblClaseDeConstruccion2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdLIMPIAR = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdDepurarLinderos = New System.Windows.Forms.Button()
        Me.cmdDepurarCartografia = New System.Windows.Forms.Button()
        Me.pbPROCESO = New System.Windows.Forms.ProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.fraPROPIETARIO.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 552)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(812, 25)
        Me.strBARRESTA.TabIndex = 45
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.fraPROPIETARIO)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(14, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(781, 529)
        Me.GroupBox1.TabIndex = 44
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MARCAR PREDIO COMO CONJUNTO"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.lblFIPRMOAD)
        Me.GroupBox2.Controls.Add(Me.txtFIPRTIFI)
        Me.GroupBox2.Controls.Add(Me.lblFIPRCAPR)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lblFIPRCASU)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.lblFIPRCLSE)
        Me.GroupBox2.Controls.Add(Me.txtFIPRFIFI)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtFIPRMOAD)
        Me.GroupBox2.Controls.Add(Me.txtFIPRFIIN)
        Me.GroupBox2.Controls.Add(Me.txtFIPRCAPR)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtFIPRCASU)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtFIPRCLSE)
        Me.GroupBox2.Controls.Add(Me.txtFIPRCORR)
        Me.GroupBox2.Controls.Add(Me.txtFIPRMUNI)
        Me.GroupBox2.Controls.Add(Me.txtFIPRUNPR)
        Me.GroupBox2.Controls.Add(Me.Label59)
        Me.GroupBox2.Controls.Add(Me.txtFIPREDIF)
        Me.GroupBox2.Controls.Add(Me.lblAdquisicionDelPredio)
        Me.GroupBox2.Controls.Add(Me.txtFIPRPRED)
        Me.GroupBox2.Controls.Add(Me.txtFIPRMANZ)
        Me.GroupBox2.Controls.Add(Me.txtFIPRBARR)
        Me.GroupBox2.Controls.Add(Me.lblClaseOSector2)
        Me.GroupBox2.Controls.Add(Me.lblCategoriaDeSuelo)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(15, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(746, 208)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DATOS FICHA PREDIAL "
        '
        'lblFIPRMOAD
        '
        Me.lblFIPRMOAD.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFIPRMOAD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFIPRMOAD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFIPRMOAD.ForeColor = System.Drawing.Color.Black
        Me.lblFIPRMOAD.Location = New System.Drawing.Point(550, 166)
        Me.lblFIPRMOAD.Name = "lblFIPRMOAD"
        Me.lblFIPRMOAD.Size = New System.Drawing.Size(173, 20)
        Me.lblFIPRMOAD.TabIndex = 312
        '
        'txtFIPRTIFI
        '
        Me.txtFIPRTIFI.AccessibleDescription = "Tipo de ficha"
        Me.txtFIPRTIFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRTIFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRTIFI.Location = New System.Drawing.Point(638, 51)
        Me.txtFIPRTIFI.MaxLength = 1
        Me.txtFIPRTIFI.Name = "txtFIPRTIFI"
        Me.txtFIPRTIFI.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRTIFI.TabIndex = 3
        Me.txtFIPRTIFI.Text = "%"
        '
        'lblFIPRCAPR
        '
        Me.lblFIPRCAPR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFIPRCAPR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFIPRCAPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFIPRCAPR.ForeColor = System.Drawing.Color.Black
        Me.lblFIPRCAPR.Location = New System.Drawing.Point(198, 166)
        Me.lblFIPRCAPR.Name = "lblFIPRCAPR"
        Me.lblFIPRCAPR.Size = New System.Drawing.Size(173, 20)
        Me.lblFIPRCAPR.TabIndex = 311
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(550, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 20)
        Me.Label4.TabIndex = 317
        Me.Label4.Text = "Tipo ficha"
        '
        'lblFIPRCASU
        '
        Me.lblFIPRCASU.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFIPRCASU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFIPRCASU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFIPRCASU.ForeColor = System.Drawing.Color.Black
        Me.lblFIPRCASU.Location = New System.Drawing.Point(550, 143)
        Me.lblFIPRCASU.Name = "lblFIPRCASU"
        Me.lblFIPRCASU.Size = New System.Drawing.Size(173, 20)
        Me.lblFIPRCASU.TabIndex = 310
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 20)
        Me.Label3.TabIndex = 315
        Me.Label3.Text = "Rango inicial"
        '
        'lblFIPRCLSE
        '
        Me.lblFIPRCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblFIPRCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFIPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFIPRCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblFIPRCLSE.Location = New System.Drawing.Point(198, 143)
        Me.lblFIPRCLSE.Name = "lblFIPRCLSE"
        Me.lblFIPRCLSE.Size = New System.Drawing.Size(173, 20)
        Me.lblFIPRCLSE.TabIndex = 309
        '
        'txtFIPRFIFI
        '
        Me.txtFIPRFIFI.AccessibleDescription = "Ficha final"
        Me.txtFIPRFIFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRFIFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRFIFI.Location = New System.Drawing.Point(374, 51)
        Me.txtFIPRFIFI.MaxLength = 9
        Me.txtFIPRFIFI.Name = "txtFIPRFIFI"
        Me.txtFIPRFIFI.Size = New System.Drawing.Size(172, 20)
        Me.txtFIPRFIFI.TabIndex = 2
        Me.txtFIPRFIFI.Text = "999999999"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(286, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 20)
        Me.Label5.TabIndex = 313
        Me.Label5.Text = "Rango final"
        '
        'txtFIPRMOAD
        '
        Me.txtFIPRMOAD.AccessibleDescription = "Modo de adquisición"
        Me.txtFIPRMOAD.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMOAD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRMOAD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMOAD.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRMOAD.Location = New System.Drawing.Point(461, 166)
        Me.txtFIPRMOAD.MaxLength = 1
        Me.txtFIPRMOAD.Name = "txtFIPRMOAD"
        Me.txtFIPRMOAD.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRMOAD.TabIndex = 14
        Me.txtFIPRMOAD.Text = "%"
        '
        'txtFIPRFIIN
        '
        Me.txtFIPRFIIN.AccessibleDescription = "Ficha inicial"
        Me.txtFIPRFIIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRFIIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRFIIN.Location = New System.Drawing.Point(109, 51)
        Me.txtFIPRFIIN.MaxLength = 9
        Me.txtFIPRFIIN.Name = "txtFIPRFIIN"
        Me.txtFIPRFIIN.Size = New System.Drawing.Size(173, 20)
        Me.txtFIPRFIIN.TabIndex = 1
        Me.txtFIPRFIIN.Text = "0"
        '
        'txtFIPRCAPR
        '
        Me.txtFIPRCAPR.AccessibleDescription = "Caracteristica de predio"
        Me.txtFIPRCAPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRCAPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRCAPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRCAPR.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRCAPR.Location = New System.Drawing.Point(109, 166)
        Me.txtFIPRCAPR.MaxLength = 1
        Me.txtFIPRCAPR.Name = "txtFIPRCAPR"
        Me.txtFIPRCAPR.Size = New System.Drawing.Size(86, 20)
        Me.txtFIPRCAPR.TabIndex = 13
        Me.txtFIPRCAPR.Text = "%"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(19, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(704, 20)
        Me.Label6.TabIndex = 288
        Me.Label6.Text = "NUMERO DE FICHA"
        '
        'txtFIPRCASU
        '
        Me.txtFIPRCASU.AccessibleDescription = "Categoria de suelo"
        Me.txtFIPRCASU.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRCASU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRCASU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRCASU.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRCASU.Location = New System.Drawing.Point(461, 143)
        Me.txtFIPRCASU.MaxLength = 1
        Me.txtFIPRCASU.Name = "txtFIPRCASU"
        Me.txtFIPRCASU.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRCASU.TabIndex = 12
        Me.txtFIPRCASU.Text = "%"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(19, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(703, 20)
        Me.Label7.TabIndex = 278
        Me.Label7.Text = "CEDULA CATASTRAL ACTUAL"
        '
        'txtFIPRCLSE
        '
        Me.txtFIPRCLSE.AccessibleDescription = "Clase o sector"
        Me.txtFIPRCLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRCLSE.Location = New System.Drawing.Point(109, 143)
        Me.txtFIPRCLSE.MaxLength = 1
        Me.txtFIPRCLSE.Name = "txtFIPRCLSE"
        Me.txtFIPRCLSE.Size = New System.Drawing.Size(86, 20)
        Me.txtFIPRCLSE.TabIndex = 11
        Me.txtFIPRCLSE.Text = "%"
        '
        'txtFIPRCORR
        '
        Me.txtFIPRCORR.AccessibleDescription = "Corregimiento"
        Me.txtFIPRCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRCORR.Location = New System.Drawing.Point(198, 120)
        Me.txtFIPRCORR.MaxLength = 10
        Me.txtFIPRCORR.Name = "txtFIPRCORR"
        Me.txtFIPRCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRCORR.TabIndex = 5
        Me.txtFIPRCORR.Text = "%"
        '
        'txtFIPRMUNI
        '
        Me.txtFIPRMUNI.AccessibleDescription = "Municipio"
        Me.txtFIPRMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMUNI.Location = New System.Drawing.Point(110, 120)
        Me.txtFIPRMUNI.MaxLength = 10
        Me.txtFIPRMUNI.Name = "txtFIPRMUNI"
        Me.txtFIPRMUNI.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRMUNI.TabIndex = 4
        Me.txtFIPRMUNI.Text = "%"
        '
        'txtFIPRUNPR
        '
        Me.txtFIPRUNPR.AccessibleDescription = "Unidad predial "
        Me.txtFIPRUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRUNPR.Location = New System.Drawing.Point(638, 120)
        Me.txtFIPRUNPR.MaxLength = 10
        Me.txtFIPRUNPR.Name = "txtFIPRUNPR"
        Me.txtFIPRUNPR.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRUNPR.TabIndex = 10
        Me.txtFIPRUNPR.Text = "%"
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label59.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label59.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.ForeColor = System.Drawing.Color.Black
        Me.Label59.Location = New System.Drawing.Point(18, 166)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(85, 20)
        Me.Label59.TabIndex = 276
        Me.Label59.Text = "Caract. Predio"
        '
        'txtFIPREDIF
        '
        Me.txtFIPREDIF.AccessibleDescription = "Edificio "
        Me.txtFIPREDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPREDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPREDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPREDIF.ForeColor = System.Drawing.Color.Black
        Me.txtFIPREDIF.Location = New System.Drawing.Point(550, 120)
        Me.txtFIPREDIF.MaxLength = 10
        Me.txtFIPREDIF.Name = "txtFIPREDIF"
        Me.txtFIPREDIF.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPREDIF.TabIndex = 9
        Me.txtFIPREDIF.Text = "%"
        '
        'lblAdquisicionDelPredio
        '
        Me.lblAdquisicionDelPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblAdquisicionDelPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAdquisicionDelPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdquisicionDelPredio.ForeColor = System.Drawing.Color.Black
        Me.lblAdquisicionDelPredio.Location = New System.Drawing.Point(374, 166)
        Me.lblAdquisicionDelPredio.Name = "lblAdquisicionDelPredio"
        Me.lblAdquisicionDelPredio.Size = New System.Drawing.Size(84, 20)
        Me.lblAdquisicionDelPredio.TabIndex = 273
        Me.lblAdquisicionDelPredio.Text = "Adquisición"
        '
        'txtFIPRPRED
        '
        Me.txtFIPRPRED.AccessibleDescription = "Predio "
        Me.txtFIPRPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRPRED.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRPRED.Location = New System.Drawing.Point(462, 120)
        Me.txtFIPRPRED.MaxLength = 10
        Me.txtFIPRPRED.Name = "txtFIPRPRED"
        Me.txtFIPRPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRPRED.TabIndex = 8
        Me.txtFIPRPRED.Text = "%"
        '
        'txtFIPRMANZ
        '
        Me.txtFIPRMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtFIPRMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRMANZ.Location = New System.Drawing.Point(374, 120)
        Me.txtFIPRMANZ.MaxLength = 10
        Me.txtFIPRMANZ.Name = "txtFIPRMANZ"
        Me.txtFIPRMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRMANZ.TabIndex = 7
        Me.txtFIPRMANZ.Text = "%"
        '
        'txtFIPRBARR
        '
        Me.txtFIPRBARR.AccessibleDescription = "Barrio "
        Me.txtFIPRBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRBARR.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRBARR.Location = New System.Drawing.Point(286, 120)
        Me.txtFIPRBARR.MaxLength = 10
        Me.txtFIPRBARR.Name = "txtFIPRBARR"
        Me.txtFIPRBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRBARR.TabIndex = 6
        Me.txtFIPRBARR.Text = "%"
        '
        'lblClaseOSector2
        '
        Me.lblClaseOSector2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseOSector2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseOSector2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseOSector2.ForeColor = System.Drawing.Color.Black
        Me.lblClaseOSector2.Location = New System.Drawing.Point(19, 143)
        Me.lblClaseOSector2.Name = "lblClaseOSector2"
        Me.lblClaseOSector2.Size = New System.Drawing.Size(85, 20)
        Me.lblClaseOSector2.TabIndex = 45
        Me.lblClaseOSector2.Text = "Clase o Sector"
        '
        'lblCategoriaDeSuelo
        '
        Me.lblCategoriaDeSuelo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCategoriaDeSuelo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCategoriaDeSuelo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoriaDeSuelo.ForeColor = System.Drawing.Color.Black
        Me.lblCategoriaDeSuelo.Location = New System.Drawing.Point(374, 143)
        Me.lblCategoriaDeSuelo.Name = "lblCategoriaDeSuelo"
        Me.lblCategoriaDeSuelo.Size = New System.Drawing.Size(84, 20)
        Me.lblCategoriaDeSuelo.TabIndex = 44
        Me.lblCategoriaDeSuelo.Text = "Categ de Suelo"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(19, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 20)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Código Actual"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(638, 97)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 20)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Unidad Predial"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(550, 97)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 20)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Edificio"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(462, 97)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 20)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Predio"
        '
        'Label13
        '
        Me.Label13.AccessibleDescription = ""
        Me.Label13.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(374, 97)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 20)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Manza / Vered"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(286, 97)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 20)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Barrio"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(198, 97)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 20)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "Corregimiento"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(110, 97)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 20)
        Me.Label16.TabIndex = 300
        Me.Label16.Text = "Municipio"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(19, 97)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(85, 20)
        Me.Label17.TabIndex = 300
        Me.Label17.Text = "CODIGO"
        '
        'fraPROPIETARIO
        '
        Me.fraPROPIETARIO.Controls.Add(Me.chkPredioEnConjunto)
        Me.fraPROPIETARIO.Controls.Add(Me.cmdAPLICAR)
        Me.fraPROPIETARIO.Controls.Add(Me.lblClaseDeConstruccion2)
        Me.fraPROPIETARIO.ForeColor = System.Drawing.Color.Black
        Me.fraPROPIETARIO.Location = New System.Drawing.Point(15, 233)
        Me.fraPROPIETARIO.Name = "fraPROPIETARIO"
        Me.fraPROPIETARIO.Size = New System.Drawing.Size(746, 126)
        Me.fraPROPIETARIO.TabIndex = 2
        Me.fraPROPIETARIO.TabStop = False
        Me.fraPROPIETARIO.Text = "ESTADO DEL PREDIO"
        '
        'chkPredioEnConjunto
        '
        Me.chkPredioEnConjunto.AccessibleDescription = "Predio en conjunto"
        Me.chkPredioEnConjunto.AutoSize = True
        Me.chkPredioEnConjunto.Location = New System.Drawing.Point(316, 51)
        Me.chkPredioEnConjunto.Name = "chkPredioEnConjunto"
        Me.chkPredioEnConjunto.Size = New System.Drawing.Size(115, 17)
        Me.chkPredioEnConjunto.TabIndex = 404
        Me.chkPredioEnConjunto.Text = "Predio en conjunto"
        Me.chkPredioEnConjunto.UseVisualStyleBackColor = True
        '
        'cmdAPLICAR
        '
        Me.cmdAPLICAR.AccessibleDescription = "Aplicar"
        Me.cmdAPLICAR.Image = Global.SICAFI.My.Resources.Resources._208
        Me.cmdAPLICAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAPLICAR.Location = New System.Drawing.Point(286, 88)
        Me.cmdAPLICAR.Name = "cmdAPLICAR"
        Me.cmdAPLICAR.Size = New System.Drawing.Size(172, 23)
        Me.cmdAPLICAR.TabIndex = 17
        Me.cmdAPLICAR.Text = "&Aplicar"
        Me.cmdAPLICAR.UseVisualStyleBackColor = True
        '
        'lblClaseDeConstruccion2
        '
        Me.lblClaseDeConstruccion2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseDeConstruccion2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseDeConstruccion2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseDeConstruccion2.ForeColor = System.Drawing.Color.Black
        Me.lblClaseDeConstruccion2.Location = New System.Drawing.Point(198, 28)
        Me.lblClaseDeConstruccion2.Name = "lblClaseDeConstruccion2"
        Me.lblClaseDeConstruccion2.Size = New System.Drawing.Size(348, 20)
        Me.lblClaseDeConstruccion2.TabIndex = 403
        Me.lblClaseDeConstruccion2.Text = "PREDIO COMO CONJUNTO SI / NO"
        Me.lblClaseDeConstruccion2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdLIMPIAR)
        Me.GroupBox3.Controls.Add(Me.cmdSALIR)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(15, 466)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(746, 47)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'cmdLIMPIAR
        '
        Me.cmdLIMPIAR.AccessibleDescription = "Limpiar campo"
        Me.cmdLIMPIAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLIMPIAR.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLIMPIAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLIMPIAR.Location = New System.Drawing.Point(18, 15)
        Me.cmdLIMPIAR.Name = "cmdLIMPIAR"
        Me.cmdLIMPIAR.Size = New System.Drawing.Size(123, 23)
        Me.cmdLIMPIAR.TabIndex = 18
        Me.cmdLIMPIAR.Text = "&Limpiar campos"
        Me.cmdLIMPIAR.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Cancelar"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(600, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(123, 23)
        Me.cmdSALIR.TabIndex = 19
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.pbPROCESO)
        Me.GroupBox4.Controls.Add(Me.cmdDepurarLinderos)
        Me.GroupBox4.Controls.Add(Me.cmdDepurarCartografia)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(15, 365)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(746, 95)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        '
        'cmdDepurarLinderos
        '
        Me.cmdDepurarLinderos.AccessibleDescription = ""
        Me.cmdDepurarLinderos.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdDepurarLinderos.Image = Global.SICAFI.My.Resources.Resources._179
        Me.cmdDepurarLinderos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDepurarLinderos.Location = New System.Drawing.Point(18, 20)
        Me.cmdDepurarLinderos.Name = "cmdDepurarLinderos"
        Me.cmdDepurarLinderos.Size = New System.Drawing.Size(353, 23)
        Me.cmdDepurarLinderos.TabIndex = 18
        Me.cmdDepurarLinderos.Text = "Eliminar linderos duplicados"
        Me.cmdDepurarLinderos.UseVisualStyleBackColor = True
        '
        'cmdDepurarCartografia
        '
        Me.cmdDepurarCartografia.AccessibleDescription = "Cancelar"
        Me.cmdDepurarCartografia.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdDepurarCartografia.Image = Global.SICAFI.My.Resources.Resources._179
        Me.cmdDepurarCartografia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDepurarCartografia.Location = New System.Drawing.Point(374, 20)
        Me.cmdDepurarCartografia.Name = "cmdDepurarCartografia"
        Me.cmdDepurarCartografia.Size = New System.Drawing.Size(349, 23)
        Me.cmdDepurarCartografia.TabIndex = 19
        Me.cmdDepurarCartografia.Text = "Eliminar cartografia duplicada"
        Me.cmdDepurarCartografia.UseVisualStyleBackColor = True
        '
        'pbPROCESO
        '
        Me.pbPROCESO.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pbPROCESO.Location = New System.Drawing.Point(18, 56)
        Me.pbPROCESO.Name = "pbPROCESO"
        Me.pbPROCESO.Size = New System.Drawing.Size(704, 17)
        Me.pbPROCESO.TabIndex = 24
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'frm_Marcar_Predio_Como_Conjunto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(812, 577)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox1)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_Marcar_Predio_Como_Conjunto"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "MARCAR PREDIO COMO CONJUNTO"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.fraPROPIETARIO.ResumeLayout(False)
        Me.fraPROPIETARIO.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblFIPRMOAD As System.Windows.Forms.Label
    Friend WithEvents txtFIPRTIFI As System.Windows.Forms.TextBox
    Friend WithEvents lblFIPRCAPR As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFIPRCASU As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFIPRCLSE As System.Windows.Forms.Label
    Friend WithEvents txtFIPRFIFI As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFIPRMOAD As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRFIIN As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRCAPR As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFIPRCASU As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFIPRCLSE As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRCORR As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRMUNI As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRUNPR As System.Windows.Forms.TextBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents txtFIPREDIF As System.Windows.Forms.TextBox
    Friend WithEvents lblAdquisicionDelPredio As System.Windows.Forms.Label
    Friend WithEvents txtFIPRPRED As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRMANZ As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblClaseOSector2 As System.Windows.Forms.Label
    Friend WithEvents lblCategoriaDeSuelo As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents fraPROPIETARIO As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAPLICAR As System.Windows.Forms.Button
    Friend WithEvents lblClaseDeConstruccion2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLIMPIAR As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents chkPredioEnConjunto As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDepurarLinderos As System.Windows.Forms.Button
    Friend WithEvents cmdDepurarCartografia As System.Windows.Forms.Button
    Friend WithEvents pbPROCESO As System.Windows.Forms.ProgressBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
