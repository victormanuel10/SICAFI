<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consultar_TERCERO
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.fraTERCERO = New System.Windows.Forms.GroupBox
        Me.cboTERCESTA = New System.Windows.Forms.TextBox
        Me.cboTERCSEXO = New System.Windows.Forms.TextBox
        Me.cboTERCCAPR = New System.Windows.Forms.TextBox
        Me.cboTERCTIDO = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTERCDIRE = New System.Windows.Forms.TextBox
        Me.lblDireccion = New System.Windows.Forms.Label
        Me.txtTERCFAX1 = New System.Windows.Forms.TextBox
        Me.lblFax = New System.Windows.Forms.Label
        Me.txtTERCTEL2 = New System.Windows.Forms.TextBox
        Me.txtTERCTEL1 = New System.Windows.Forms.TextBox
        Me.lblTelefonos = New System.Windows.Forms.Label
        Me.lblTERCCAPR = New System.Windows.Forms.Label
        Me.lblTERCSEXO = New System.Windows.Forms.Label
        Me.txtTERCNUDO = New System.Windows.Forms.TextBox
        Me.lblTERCTIDO = New System.Windows.Forms.Label
        Me.txtTERCSICO = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtTERCSEAP = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTERCPRAP = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTERCNOMB = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblCalidadPropietario2 = New System.Windows.Forms.Label
        Me.lblSexo2 = New System.Windows.Forms.Label
        Me.lblTipoDocumento2 = New System.Windows.Forms.Label
        Me.lblNumeroDocumento = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdACEPTAR = New System.Windows.Forms.Button
        Me.cmdLIMPIAR = New System.Windows.Forms.Button
        Me.cmdCONSULTAR = New System.Windows.Forms.Button
        Me.cmdPLANO = New System.Windows.Forms.Button
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtRUTA = New System.Windows.Forms.Label
        Me.txtSEPARADOR = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvCONSULTA = New System.Windows.Forms.DataGridView
        Me.strBARRESTA.SuspendLayout()
        Me.fraTERCERO.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel2, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 513)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(753, 25)
        Me.strBARRESTA.TabIndex = 30
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
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.AutoSize = False
        Me.ToolStripStatusLabel3.BackColor = System.Drawing.SystemColors.Window
        Me.ToolStripStatusLabel3.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel3.ForeColor = System.Drawing.Color.Red
        Me.ToolStripStatusLabel3.LinkColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel3.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(300, 22)
        Me.ToolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.AutoSize = False
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.SystemColors.Window
        Me.ToolStripStatusLabel2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(125, 22)
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tstBAESDESC
        '
        Me.tstBAESDESC.AutoSize = False
        Me.tstBAESDESC.BackColor = System.Drawing.SystemColors.InactiveCaptionText
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
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
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
        'fraTERCERO
        '
        Me.fraTERCERO.BackColor = System.Drawing.SystemColors.Control
        Me.fraTERCERO.Controls.Add(Me.cboTERCESTA)
        Me.fraTERCERO.Controls.Add(Me.cboTERCSEXO)
        Me.fraTERCERO.Controls.Add(Me.cboTERCCAPR)
        Me.fraTERCERO.Controls.Add(Me.cboTERCTIDO)
        Me.fraTERCERO.Controls.Add(Me.Label1)
        Me.fraTERCERO.Controls.Add(Me.txtTERCDIRE)
        Me.fraTERCERO.Controls.Add(Me.lblDireccion)
        Me.fraTERCERO.Controls.Add(Me.txtTERCFAX1)
        Me.fraTERCERO.Controls.Add(Me.lblFax)
        Me.fraTERCERO.Controls.Add(Me.txtTERCTEL2)
        Me.fraTERCERO.Controls.Add(Me.txtTERCTEL1)
        Me.fraTERCERO.Controls.Add(Me.lblTelefonos)
        Me.fraTERCERO.Controls.Add(Me.lblTERCCAPR)
        Me.fraTERCERO.Controls.Add(Me.lblTERCSEXO)
        Me.fraTERCERO.Controls.Add(Me.txtTERCNUDO)
        Me.fraTERCERO.Controls.Add(Me.lblTERCTIDO)
        Me.fraTERCERO.Controls.Add(Me.txtTERCSICO)
        Me.fraTERCERO.Controls.Add(Me.Label7)
        Me.fraTERCERO.Controls.Add(Me.txtTERCSEAP)
        Me.fraTERCERO.Controls.Add(Me.Label6)
        Me.fraTERCERO.Controls.Add(Me.txtTERCPRAP)
        Me.fraTERCERO.Controls.Add(Me.Label5)
        Me.fraTERCERO.Controls.Add(Me.txtTERCNOMB)
        Me.fraTERCERO.Controls.Add(Me.Label4)
        Me.fraTERCERO.Controls.Add(Me.lblCalidadPropietario2)
        Me.fraTERCERO.Controls.Add(Me.lblSexo2)
        Me.fraTERCERO.Controls.Add(Me.lblTipoDocumento2)
        Me.fraTERCERO.Controls.Add(Me.lblNumeroDocumento)
        Me.fraTERCERO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraTERCERO.ForeColor = System.Drawing.Color.Black
        Me.fraTERCERO.Location = New System.Drawing.Point(12, 12)
        Me.fraTERCERO.Name = "fraTERCERO"
        Me.fraTERCERO.Size = New System.Drawing.Size(723, 232)
        Me.fraTERCERO.TabIndex = 29
        Me.fraTERCERO.TabStop = False
        Me.fraTERCERO.Text = "CONSULTAR TERCERO"
        '
        'cboTERCESTA
        '
        Me.cboTERCESTA.AccessibleDescription = "Estado"
        Me.cboTERCESTA.BackColor = System.Drawing.SystemColors.Window
        Me.cboTERCESTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.cboTERCESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTERCESTA.ForeColor = System.Drawing.Color.Black
        Me.cboTERCESTA.Location = New System.Drawing.Point(137, 196)
        Me.cboTERCESTA.MaxLength = 15
        Me.cboTERCESTA.Name = "cboTERCESTA"
        Me.cboTERCESTA.Size = New System.Drawing.Size(50, 20)
        Me.cboTERCESTA.TabIndex = 45
        '
        'cboTERCSEXO
        '
        Me.cboTERCSEXO.AccessibleDescription = "Sexo"
        Me.cboTERCSEXO.BackColor = System.Drawing.SystemColors.Window
        Me.cboTERCSEXO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cboTERCSEXO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTERCSEXO.ForeColor = System.Drawing.Color.Black
        Me.cboTERCSEXO.Location = New System.Drawing.Point(476, 52)
        Me.cboTERCSEXO.MaxLength = 15
        Me.cboTERCSEXO.Name = "cboTERCSEXO"
        Me.cboTERCSEXO.Size = New System.Drawing.Size(50, 20)
        Me.cboTERCSEXO.TabIndex = 44
        '
        'cboTERCCAPR
        '
        Me.cboTERCCAPR.AccessibleDescription = "Calidad de propietario"
        Me.cboTERCCAPR.BackColor = System.Drawing.SystemColors.Window
        Me.cboTERCCAPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cboTERCCAPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTERCCAPR.ForeColor = System.Drawing.Color.Black
        Me.cboTERCCAPR.Location = New System.Drawing.Point(137, 52)
        Me.cboTERCCAPR.MaxLength = 15
        Me.cboTERCCAPR.Name = "cboTERCCAPR"
        Me.cboTERCCAPR.Size = New System.Drawing.Size(50, 20)
        Me.cboTERCCAPR.TabIndex = 43
        '
        'cboTERCTIDO
        '
        Me.cboTERCTIDO.AccessibleDescription = "Tipo documento"
        Me.cboTERCTIDO.BackColor = System.Drawing.SystemColors.Window
        Me.cboTERCTIDO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cboTERCTIDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTERCTIDO.ForeColor = System.Drawing.Color.Black
        Me.cboTERCTIDO.Location = New System.Drawing.Point(476, 28)
        Me.cboTERCTIDO.MaxLength = 15
        Me.cboTERCTIDO.Name = "cboTERCTIDO"
        Me.cboTERCTIDO.Size = New System.Drawing.Size(50, 20)
        Me.cboTERCTIDO.TabIndex = 42
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 196)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 20)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Estado"
        '
        'txtTERCDIRE
        '
        Me.txtTERCDIRE.AccessibleDescription = "Dirección de predio"
        Me.txtTERCDIRE.BackColor = System.Drawing.SystemColors.Window
        Me.txtTERCDIRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTERCDIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTERCDIRE.ForeColor = System.Drawing.Color.Black
        Me.txtTERCDIRE.Location = New System.Drawing.Point(137, 172)
        Me.txtTERCDIRE.MaxLength = 49
        Me.txtTERCDIRE.Name = "txtTERCDIRE"
        Me.txtTERCDIRE.Size = New System.Drawing.Size(567, 20)
        Me.txtTERCDIRE.TabIndex = 12
        '
        'lblDireccion
        '
        Me.lblDireccion.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblDireccion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDireccion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccion.ForeColor = System.Drawing.Color.Black
        Me.lblDireccion.Location = New System.Drawing.Point(17, 172)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(116, 20)
        Me.lblDireccion.TabIndex = 40
        Me.lblDireccion.Text = "Dirección"
        '
        'txtTERCFAX1
        '
        Me.txtTERCFAX1.AccessibleDescription = "Fax 1"
        Me.txtTERCFAX1.BackColor = System.Drawing.SystemColors.Window
        Me.txtTERCFAX1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTERCFAX1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTERCFAX1.ForeColor = System.Drawing.Color.Black
        Me.txtTERCFAX1.Location = New System.Drawing.Point(476, 148)
        Me.txtTERCFAX1.MaxLength = 15
        Me.txtTERCFAX1.Name = "txtTERCFAX1"
        Me.txtTERCFAX1.Size = New System.Drawing.Size(228, 20)
        Me.txtTERCFAX1.TabIndex = 11
        '
        'lblFax
        '
        Me.lblFax.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblFax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFax.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFax.ForeColor = System.Drawing.Color.Black
        Me.lblFax.Location = New System.Drawing.Point(357, 148)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(116, 20)
        Me.lblFax.TabIndex = 37
        Me.lblFax.Text = "Fax"
        '
        'txtTERCTEL2
        '
        Me.txtTERCTEL2.AccessibleDescription = "Telefono 2"
        Me.txtTERCTEL2.BackColor = System.Drawing.SystemColors.Window
        Me.txtTERCTEL2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTERCTEL2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTERCTEL2.ForeColor = System.Drawing.Color.Black
        Me.txtTERCTEL2.Location = New System.Drawing.Point(248, 148)
        Me.txtTERCTEL2.MaxLength = 15
        Me.txtTERCTEL2.Name = "txtTERCTEL2"
        Me.txtTERCTEL2.Size = New System.Drawing.Size(107, 20)
        Me.txtTERCTEL2.TabIndex = 10
        '
        'txtTERCTEL1
        '
        Me.txtTERCTEL1.AccessibleDescription = "Telefono 1"
        Me.txtTERCTEL1.BackColor = System.Drawing.SystemColors.Window
        Me.txtTERCTEL1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTERCTEL1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTERCTEL1.ForeColor = System.Drawing.Color.Black
        Me.txtTERCTEL1.Location = New System.Drawing.Point(137, 148)
        Me.txtTERCTEL1.MaxLength = 15
        Me.txtTERCTEL1.Name = "txtTERCTEL1"
        Me.txtTERCTEL1.Size = New System.Drawing.Size(108, 20)
        Me.txtTERCTEL1.TabIndex = 9
        '
        'lblTelefonos
        '
        Me.lblTelefonos.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblTelefonos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTelefonos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefonos.ForeColor = System.Drawing.Color.Black
        Me.lblTelefonos.Location = New System.Drawing.Point(17, 148)
        Me.lblTelefonos.Name = "lblTelefonos"
        Me.lblTelefonos.Size = New System.Drawing.Size(116, 20)
        Me.lblTelefonos.TabIndex = 34
        Me.lblTelefonos.Text = "Telefonos"
        '
        'lblTERCCAPR
        '
        Me.lblTERCCAPR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTERCCAPR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTERCCAPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTERCCAPR.ForeColor = System.Drawing.Color.Black
        Me.lblTERCCAPR.Location = New System.Drawing.Point(193, 52)
        Me.lblTERCCAPR.Name = "lblTERCCAPR"
        Me.lblTERCCAPR.Size = New System.Drawing.Size(160, 20)
        Me.lblTERCCAPR.TabIndex = 33
        '
        'lblTERCSEXO
        '
        Me.lblTERCSEXO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTERCSEXO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTERCSEXO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTERCSEXO.ForeColor = System.Drawing.Color.Black
        Me.lblTERCSEXO.Location = New System.Drawing.Point(532, 52)
        Me.lblTERCSEXO.Name = "lblTERCSEXO"
        Me.lblTERCSEXO.Size = New System.Drawing.Size(172, 20)
        Me.lblTERCSEXO.TabIndex = 32
        '
        'txtTERCNUDO
        '
        Me.txtTERCNUDO.AccessibleDescription = "Numero de documento"
        Me.txtTERCNUDO.BackColor = System.Drawing.SystemColors.Window
        Me.txtTERCNUDO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTERCNUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTERCNUDO.ForeColor = System.Drawing.Color.Black
        Me.txtTERCNUDO.Location = New System.Drawing.Point(137, 28)
        Me.txtTERCNUDO.MaxLength = 14
        Me.txtTERCNUDO.Name = "txtTERCNUDO"
        Me.txtTERCNUDO.Size = New System.Drawing.Size(218, 20)
        Me.txtTERCNUDO.TabIndex = 1
        '
        'lblTERCTIDO
        '
        Me.lblTERCTIDO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTERCTIDO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTERCTIDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTERCTIDO.ForeColor = System.Drawing.Color.Black
        Me.lblTERCTIDO.Location = New System.Drawing.Point(532, 29)
        Me.lblTERCTIDO.Name = "lblTERCTIDO"
        Me.lblTERCTIDO.Size = New System.Drawing.Size(172, 20)
        Me.lblTERCTIDO.TabIndex = 29
        '
        'txtTERCSICO
        '
        Me.txtTERCSICO.AccessibleDescription = "Sigla comercial"
        Me.txtTERCSICO.BackColor = System.Drawing.SystemColors.Window
        Me.txtTERCSICO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTERCSICO.ForeColor = System.Drawing.Color.Black
        Me.txtTERCSICO.Location = New System.Drawing.Point(137, 124)
        Me.txtTERCSICO.MaxLength = 20
        Me.txtTERCSICO.Name = "txtTERCSICO"
        Me.txtTERCSICO.Size = New System.Drawing.Size(567, 20)
        Me.txtTERCSICO.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(17, 124)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 20)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Sigla Comercial"
        '
        'txtTERCSEAP
        '
        Me.txtTERCSEAP.AccessibleDescription = "Segundo apellido"
        Me.txtTERCSEAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtTERCSEAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTERCSEAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTERCSEAP.ForeColor = System.Drawing.Color.Black
        Me.txtTERCSEAP.Location = New System.Drawing.Point(476, 100)
        Me.txtTERCSEAP.MaxLength = 15
        Me.txtTERCSEAP.Name = "txtTERCSEAP"
        Me.txtTERCSEAP.Size = New System.Drawing.Size(228, 20)
        Me.txtTERCSEAP.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(357, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 20)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Segundo Apellido"
        '
        'txtTERCPRAP
        '
        Me.txtTERCPRAP.AccessibleDescription = "Primer apellido"
        Me.txtTERCPRAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtTERCPRAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTERCPRAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTERCPRAP.ForeColor = System.Drawing.Color.Black
        Me.txtTERCPRAP.Location = New System.Drawing.Point(137, 100)
        Me.txtTERCPRAP.MaxLength = 15
        Me.txtTERCPRAP.Name = "txtTERCPRAP"
        Me.txtTERCPRAP.Size = New System.Drawing.Size(218, 20)
        Me.txtTERCPRAP.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(17, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 20)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Primer Apellido"
        '
        'txtTERCNOMB
        '
        Me.txtTERCNOMB.AccessibleDescription = "Nombre (s)"
        Me.txtTERCNOMB.BackColor = System.Drawing.SystemColors.Window
        Me.txtTERCNOMB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTERCNOMB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTERCNOMB.ForeColor = System.Drawing.Color.Black
        Me.txtTERCNOMB.Location = New System.Drawing.Point(137, 76)
        Me.txtTERCNOMB.MaxLength = 20
        Me.txtTERCNOMB.Name = "txtTERCNOMB"
        Me.txtTERCNOMB.Size = New System.Drawing.Size(567, 20)
        Me.txtTERCNOMB.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(17, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 20)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Nombre (S)"
        '
        'lblCalidadPropietario2
        '
        Me.lblCalidadPropietario2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCalidadPropietario2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCalidadPropietario2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalidadPropietario2.ForeColor = System.Drawing.Color.Black
        Me.lblCalidadPropietario2.Location = New System.Drawing.Point(17, 52)
        Me.lblCalidadPropietario2.Name = "lblCalidadPropietario2"
        Me.lblCalidadPropietario2.Size = New System.Drawing.Size(116, 20)
        Me.lblCalidadPropietario2.TabIndex = 20
        Me.lblCalidadPropietario2.Text = "Calidad Propietario"
        '
        'lblSexo2
        '
        Me.lblSexo2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblSexo2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSexo2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSexo2.ForeColor = System.Drawing.Color.Black
        Me.lblSexo2.Location = New System.Drawing.Point(357, 52)
        Me.lblSexo2.Name = "lblSexo2"
        Me.lblSexo2.Size = New System.Drawing.Size(116, 19)
        Me.lblSexo2.TabIndex = 18
        Me.lblSexo2.Text = "Sexo"
        '
        'lblTipoDocumento2
        '
        Me.lblTipoDocumento2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblTipoDocumento2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoDocumento2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoDocumento2.ForeColor = System.Drawing.Color.Black
        Me.lblTipoDocumento2.Location = New System.Drawing.Point(357, 29)
        Me.lblTipoDocumento2.Name = "lblTipoDocumento2"
        Me.lblTipoDocumento2.Size = New System.Drawing.Size(116, 19)
        Me.lblTipoDocumento2.TabIndex = 16
        Me.lblTipoDocumento2.Text = "Tipo de documento"
        '
        'lblNumeroDocumento
        '
        Me.lblNumeroDocumento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblNumeroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumeroDocumento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroDocumento.ForeColor = System.Drawing.Color.Black
        Me.lblNumeroDocumento.Location = New System.Drawing.Point(17, 28)
        Me.lblNumeroDocumento.Name = "lblNumeroDocumento"
        Me.lblNumeroDocumento.Size = New System.Drawing.Size(116, 20)
        Me.lblNumeroDocumento.TabIndex = 14
        Me.lblNumeroDocumento.Text = "Nro. Documento"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdACEPTAR)
        Me.GroupBox3.Controls.Add(Me.cmdLIMPIAR)
        Me.GroupBox3.Controls.Add(Me.cmdCONSULTAR)
        Me.GroupBox3.Controls.Add(Me.cmdPLANO)
        Me.GroupBox3.Controls.Add(Me.cmdSALIR)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(12, 250)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(723, 47)
        Me.GroupBox3.TabIndex = 36
        Me.GroupBox3.TabStop = False
        '
        'cmdACEPTAR
        '
        Me.cmdACEPTAR.AccessibleDescription = "Aceptar"
        Me.cmdACEPTAR.Image = Global.SICAFI.My.Resources.Resources._208
        Me.cmdACEPTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdACEPTAR.Location = New System.Drawing.Point(452, 15)
        Me.cmdACEPTAR.Name = "cmdACEPTAR"
        Me.cmdACEPTAR.Size = New System.Drawing.Size(123, 23)
        Me.cmdACEPTAR.TabIndex = 36
        Me.cmdACEPTAR.Text = "&Aceptar"
        Me.cmdACEPTAR.UseVisualStyleBackColor = True
        '
        'cmdLIMPIAR
        '
        Me.cmdLIMPIAR.AccessibleDescription = "Limpiar campo"
        Me.cmdLIMPIAR.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLIMPIAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLIMPIAR.Location = New System.Drawing.Point(277, 15)
        Me.cmdLIMPIAR.Name = "cmdLIMPIAR"
        Me.cmdLIMPIAR.Size = New System.Drawing.Size(123, 23)
        Me.cmdLIMPIAR.TabIndex = 19
        Me.cmdLIMPIAR.Text = "&Limpiar campos"
        Me.cmdLIMPIAR.UseVisualStyleBackColor = True
        '
        'cmdCONSULTAR
        '
        Me.cmdCONSULTAR.AccessibleDescription = "Consultar"
        Me.cmdCONSULTAR.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdCONSULTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCONSULTAR.Location = New System.Drawing.Point(19, 15)
        Me.cmdCONSULTAR.Name = "cmdCONSULTAR"
        Me.cmdCONSULTAR.Size = New System.Drawing.Size(123, 23)
        Me.cmdCONSULTAR.TabIndex = 17
        Me.cmdCONSULTAR.Text = "&Consultar"
        Me.cmdCONSULTAR.UseVisualStyleBackColor = True
        '
        'cmdPLANO
        '
        Me.cmdPLANO.AccessibleDescription = "Plano"
        Me.cmdPLANO.Image = Global.SICAFI.My.Resources.Resources._71
        Me.cmdPLANO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPLANO.Location = New System.Drawing.Point(148, 15)
        Me.cmdPLANO.Name = "cmdPLANO"
        Me.cmdPLANO.Size = New System.Drawing.Size(123, 23)
        Me.cmdPLANO.TabIndex = 18
        Me.cmdPLANO.Text = "&Generar archivo"
        Me.cmdPLANO.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Cancelar"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(581, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(123, 23)
        Me.cmdSALIR.TabIndex = 20
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.txtRUTA)
        Me.GroupBox4.Controls.Add(Me.txtSEPARADOR)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 303)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(723, 47)
        Me.GroupBox4.TabIndex = 106
        Me.GroupBox4.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 20)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Ruta de archivo :"
        '
        'txtRUTA
        '
        Me.txtRUTA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRUTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtRUTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRUTA.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRUTA.ForeColor = System.Drawing.Color.Black
        Me.txtRUTA.Location = New System.Drawing.Point(137, 16)
        Me.txtRUTA.Name = "txtRUTA"
        Me.txtRUTA.Size = New System.Drawing.Size(438, 20)
        Me.txtRUTA.TabIndex = 101
        Me.txtRUTA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSEPARADOR
        '
        Me.txtSEPARADOR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSEPARADOR.Location = New System.Drawing.Point(671, 16)
        Me.txtSEPARADOR.Name = "txtSEPARADOR"
        Me.txtSEPARADOR.Size = New System.Drawing.Size(33, 20)
        Me.txtSEPARADOR.TabIndex = 103
        Me.txtSEPARADOR.Text = "|"
        Me.txtSEPARADOR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(581, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 21)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "Separador"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.dgvCONSULTA)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(12, 356)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(723, 143)
        Me.GroupBox2.TabIndex = 107
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CONSULTA"
        '
        'dgvCONSULTA
        '
        Me.dgvCONSULTA.AccessibleDescription = "Consulta "
        Me.dgvCONSULTA.AllowUserToAddRows = False
        Me.dgvCONSULTA.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCONSULTA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCONSULTA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCONSULTA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCONSULTA.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCONSULTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCONSULTA.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCONSULTA.ColumnHeadersHeight = 40
        Me.dgvCONSULTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCONSULTA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA.Location = New System.Drawing.Point(18, 20)
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        Me.dgvCONSULTA.RowHeadersVisible = False
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(686, 106)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 1
        '
        'frm_consultar_TERCERO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 538)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraTERCERO)
        Me.Name = "frm_consultar_TERCERO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONSULTAR TERCERO"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraTERCERO.ResumeLayout(False)
        Me.fraTERCERO.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraTERCERO As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTERCDIRE As System.Windows.Forms.TextBox
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents txtTERCFAX1 As System.Windows.Forms.TextBox
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents txtTERCTEL2 As System.Windows.Forms.TextBox
    Friend WithEvents txtTERCTEL1 As System.Windows.Forms.TextBox
    Friend WithEvents lblTelefonos As System.Windows.Forms.Label
    Friend WithEvents lblTERCCAPR As System.Windows.Forms.Label
    Friend WithEvents lblTERCSEXO As System.Windows.Forms.Label
    Friend WithEvents txtTERCNUDO As System.Windows.Forms.TextBox
    Friend WithEvents lblTERCTIDO As System.Windows.Forms.Label
    Friend WithEvents txtTERCSICO As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTERCSEAP As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTERCPRAP As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTERCNOMB As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCalidadPropietario2 As System.Windows.Forms.Label
    Friend WithEvents lblSexo2 As System.Windows.Forms.Label
    Friend WithEvents lblTipoDocumento2 As System.Windows.Forms.Label
    Friend WithEvents lblNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLIMPIAR As System.Windows.Forms.Button
    Friend WithEvents cmdCONSULTAR As System.Windows.Forms.Button
    Friend WithEvents cmdPLANO As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRUTA As System.Windows.Forms.Label
    Friend WithEvents txtSEPARADOR As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents cmdACEPTAR As System.Windows.Forms.Button
    Friend WithEvents cboTERCTIDO As System.Windows.Forms.TextBox
    Friend WithEvents cboTERCESTA As System.Windows.Forms.TextBox
    Friend WithEvents cboTERCSEXO As System.Windows.Forms.TextBox
    Friend WithEvents cboTERCCAPR As System.Windows.Forms.TextBox
End Class
