<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_SUJEIMPU
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdLimpiar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdConsultar = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraPERIODO = New System.Windows.Forms.GroupBox()
        Me.txtSUIMCSAN = New System.Windows.Forms.TextBox()
        Me.txtSUIMCOAN = New System.Windows.Forms.TextBox()
        Me.txtSUIMUPAN = New System.Windows.Forms.TextBox()
        Me.txtSUIMEDAN = New System.Windows.Forms.TextBox()
        Me.txtSUIMPRAN = New System.Windows.Forms.TextBox()
        Me.txtSUIMMAAN = New System.Windows.Forms.TextBox()
        Me.txtSUIMBAAN = New System.Windows.Forms.TextBox()
        Me.txtSUIMMUAN = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.txtSUIMESTA = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSUIMCAPR = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSUIMMAIN = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSUIMVIAN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSUIMVIAC = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSUIMSUAN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSUIMSUAC = New System.Windows.Forms.TextBox()
        Me.dgvCONSULTA = New System.Windows.Forms.DataGridView()
        Me.txtSUIMCLSE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSUIMNUFI = New System.Windows.Forms.TextBox()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.txtSUIMDIRE = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtSUIMCORR = New System.Windows.Forms.TextBox()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.txtSUIMMUNI = New System.Windows.Forms.TextBox()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblClaseOSector2 = New System.Windows.Forms.Label()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.txtSUIMUNPR = New System.Windows.Forms.TextBox()
        Me.lblManzana = New System.Windows.Forms.Label()
        Me.txtSUIMEDIF = New System.Windows.Forms.TextBox()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.txtSUIMPRED = New System.Windows.Forms.TextBox()
        Me.lblEdificio = New System.Windows.Forms.Label()
        Me.txtSUIMMANZ = New System.Windows.Forms.TextBox()
        Me.lblUnidadPredial = New System.Windows.Forms.Label()
        Me.txtSUIMBARR = New System.Windows.Forms.TextBox()
        Me.lblCodigoActual = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraPERIODO.SuspendLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdSalir)
        Me.GroupBox1.Controls.Add(Me.cmdLimpiar)
        Me.GroupBox1.Controls.Add(Me.cmdAceptar)
        Me.GroupBox1.Controls.Add(Me.cmdConsultar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 498)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(824, 60)
        Me.GroupBox1.TabIndex = 74
        Me.GroupBox1.TabStop = False
        '
        'cmdSalir
        '
        Me.cmdSalir.AccessibleDescription = "Salir"
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(708, 20)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(101, 23)
        Me.cmdSalir.TabIndex = 8
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdLimpiar
        '
        Me.cmdLimpiar.AccessibleDescription = "Limpiar"
        Me.cmdLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLimpiar.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLimpiar.Location = New System.Drawing.Point(19, 20)
        Me.cmdLimpiar.Name = "cmdLimpiar"
        Me.cmdLimpiar.Size = New System.Drawing.Size(101, 23)
        Me.cmdLimpiar.TabIndex = 5
        Me.cmdLimpiar.Text = "&Limpiar"
        Me.cmdLimpiar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.AccessibleDescription = "Aceptar"
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Enabled = False
        Me.cmdAceptar.Image = Global.SICAFI.My.Resources.Resources._22
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(601, 20)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(101, 23)
        Me.cmdAceptar.TabIndex = 7
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdConsultar
        '
        Me.cmdConsultar.AccessibleDescription = "Consultar"
        Me.cmdConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdConsultar.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdConsultar.Location = New System.Drawing.Point(494, 20)
        Me.cmdConsultar.Name = "cmdConsultar"
        Me.cmdConsultar.Size = New System.Drawing.Size(101, 23)
        Me.cmdConsultar.TabIndex = 6
        Me.cmdConsultar.Text = "&Consultar"
        Me.cmdConsultar.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 574)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(853, 25)
        Me.strBARRESTA.TabIndex = 75
        '
        'tstBAESVALI
        '
        Me.tstBAESVALI.AutoSize = False
        Me.tstBAESVALI.BackColor = System.Drawing.Color.White
        Me.tstBAESVALI.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tstBAESVALI.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tstBAESVALI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstBAESVALI.ForeColor = System.Drawing.Color.Black
        Me.tstBAESVALI.ImageTransparentColor = System.Drawing.Color.White
        Me.tstBAESVALI.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.tstBAESVALI.Name = "tstBAESVALI"
        Me.tstBAESVALI.Size = New System.Drawing.Size(125, 22)
        Me.tstBAESVALI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tstBAESDESC
        '
        Me.tstBAESDESC.AutoSize = False
        Me.tstBAESDESC.BackColor = System.Drawing.Color.White
        Me.tstBAESDESC.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tstBAESDESC.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tstBAESDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstBAESDESC.ForeColor = System.Drawing.Color.Black
        Me.tstBAESDESC.ImageTransparentColor = System.Drawing.Color.White
        Me.tstBAESDESC.LinkColor = System.Drawing.Color.Black
        Me.tstBAESDESC.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.tstBAESDESC.Name = "tstBAESDESC"
        Me.tstBAESDESC.Size = New System.Drawing.Size(300, 22)
        Me.tstBAESDESC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.White
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(125, 22)
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fraPERIODO
        '
        Me.fraPERIODO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fraPERIODO.BackColor = System.Drawing.SystemColors.Control
        Me.fraPERIODO.Controls.Add(Me.txtSUIMCSAN)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMCOAN)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMUPAN)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMEDAN)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMPRAN)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMMAAN)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMBAAN)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMMUAN)
        Me.fraPERIODO.Controls.Add(Me.Label9)
        Me.fraPERIODO.Controls.Add(Me.Label56)
        Me.fraPERIODO.Controls.Add(Me.Label57)
        Me.fraPERIODO.Controls.Add(Me.Label58)
        Me.fraPERIODO.Controls.Add(Me.Label68)
        Me.fraPERIODO.Controls.Add(Me.Label74)
        Me.fraPERIODO.Controls.Add(Me.Label76)
        Me.fraPERIODO.Controls.Add(Me.Label79)
        Me.fraPERIODO.Controls.Add(Me.Label80)
        Me.fraPERIODO.Controls.Add(Me.Label91)
        Me.fraPERIODO.Controls.Add(Me.Label92)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMESTA)
        Me.fraPERIODO.Controls.Add(Me.Label8)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMCAPR)
        Me.fraPERIODO.Controls.Add(Me.Label7)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMMAIN)
        Me.fraPERIODO.Controls.Add(Me.Label6)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMVIAN)
        Me.fraPERIODO.Controls.Add(Me.Label5)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMVIAC)
        Me.fraPERIODO.Controls.Add(Me.Label4)
        Me.fraPERIODO.Controls.Add(Me.Label3)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMSUAN)
        Me.fraPERIODO.Controls.Add(Me.Label2)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMSUAC)
        Me.fraPERIODO.Controls.Add(Me.dgvCONSULTA)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMCLSE)
        Me.fraPERIODO.Controls.Add(Me.Label1)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMNUFI)
        Me.fraPERIODO.Controls.Add(Me.lblDireccion)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMDIRE)
        Me.fraPERIODO.Controls.Add(Me.Label33)
        Me.fraPERIODO.Controls.Add(Me.lblCodigo)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMCORR)
        Me.fraPERIODO.Controls.Add(Me.lblMunicipio)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMMUNI)
        Me.fraPERIODO.Controls.Add(Me.lblCorregimiento)
        Me.fraPERIODO.Controls.Add(Me.lblClaseOSector2)
        Me.fraPERIODO.Controls.Add(Me.lblBarrio)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMUNPR)
        Me.fraPERIODO.Controls.Add(Me.lblManzana)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMEDIF)
        Me.fraPERIODO.Controls.Add(Me.lblPredio)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMPRED)
        Me.fraPERIODO.Controls.Add(Me.lblEdificio)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMMANZ)
        Me.fraPERIODO.Controls.Add(Me.lblUnidadPredial)
        Me.fraPERIODO.Controls.Add(Me.txtSUIMBARR)
        Me.fraPERIODO.Controls.Add(Me.lblCodigoActual)
        Me.fraPERIODO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPERIODO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPERIODO.Location = New System.Drawing.Point(12, 12)
        Me.fraPERIODO.Name = "fraPERIODO"
        Me.fraPERIODO.Size = New System.Drawing.Size(827, 480)
        Me.fraPERIODO.TabIndex = 1
        Me.fraPERIODO.TabStop = False
        Me.fraPERIODO.Text = "CONSULTA SUJETO DE IMPUESTO"
        '
        'txtSUIMCSAN
        '
        Me.txtSUIMCSAN.AccessibleDescription = "Clase o sector"
        Me.txtSUIMCSAN.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMCSAN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMCSAN.Location = New System.Drawing.Point(724, 166)
        Me.txtSUIMCSAN.MaxLength = 10
        Me.txtSUIMCSAN.Name = "txtSUIMCSAN"
        Me.txtSUIMCSAN.Size = New System.Drawing.Size(84, 20)
        Me.txtSUIMCSAN.TabIndex = 418
        '
        'txtSUIMCOAN
        '
        Me.txtSUIMCOAN.AccessibleDescription = "Corregimiento"
        Me.txtSUIMCOAN.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMCOAN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMCOAN.Location = New System.Drawing.Point(197, 166)
        Me.txtSUIMCOAN.MaxLength = 10
        Me.txtSUIMCOAN.Name = "txtSUIMCOAN"
        Me.txtSUIMCOAN.Size = New System.Drawing.Size(85, 20)
        Me.txtSUIMCOAN.TabIndex = 412
        '
        'txtSUIMUPAN
        '
        Me.txtSUIMUPAN.AccessibleDescription = "Unidad predial "
        Me.txtSUIMUPAN.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMUPAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUIMUPAN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMUPAN.ForeColor = System.Drawing.Color.Black
        Me.txtSUIMUPAN.Location = New System.Drawing.Point(637, 166)
        Me.txtSUIMUPAN.MaxLength = 10
        Me.txtSUIMUPAN.Name = "txtSUIMUPAN"
        Me.txtSUIMUPAN.Size = New System.Drawing.Size(84, 20)
        Me.txtSUIMUPAN.TabIndex = 417
        '
        'txtSUIMEDAN
        '
        Me.txtSUIMEDAN.AccessibleDescription = "Edificio "
        Me.txtSUIMEDAN.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMEDAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUIMEDAN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMEDAN.ForeColor = System.Drawing.Color.Black
        Me.txtSUIMEDAN.Location = New System.Drawing.Point(549, 166)
        Me.txtSUIMEDAN.MaxLength = 10
        Me.txtSUIMEDAN.Name = "txtSUIMEDAN"
        Me.txtSUIMEDAN.Size = New System.Drawing.Size(85, 20)
        Me.txtSUIMEDAN.TabIndex = 416
        '
        'txtSUIMPRAN
        '
        Me.txtSUIMPRAN.AccessibleDescription = "Predio "
        Me.txtSUIMPRAN.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMPRAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUIMPRAN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMPRAN.ForeColor = System.Drawing.Color.Black
        Me.txtSUIMPRAN.Location = New System.Drawing.Point(461, 166)
        Me.txtSUIMPRAN.MaxLength = 10
        Me.txtSUIMPRAN.Name = "txtSUIMPRAN"
        Me.txtSUIMPRAN.Size = New System.Drawing.Size(85, 20)
        Me.txtSUIMPRAN.TabIndex = 415
        '
        'txtSUIMMAAN
        '
        Me.txtSUIMMAAN.AccessibleDescription = "Manzana o vereda "
        Me.txtSUIMMAAN.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMMAAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUIMMAAN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMMAAN.ForeColor = System.Drawing.Color.Black
        Me.txtSUIMMAAN.Location = New System.Drawing.Point(373, 166)
        Me.txtSUIMMAAN.MaxLength = 10
        Me.txtSUIMMAAN.Name = "txtSUIMMAAN"
        Me.txtSUIMMAAN.Size = New System.Drawing.Size(85, 20)
        Me.txtSUIMMAAN.TabIndex = 414
        '
        'txtSUIMBAAN
        '
        Me.txtSUIMBAAN.AccessibleDescription = "Barrio "
        Me.txtSUIMBAAN.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMBAAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUIMBAAN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMBAAN.ForeColor = System.Drawing.Color.Black
        Me.txtSUIMBAAN.Location = New System.Drawing.Point(285, 166)
        Me.txtSUIMBAAN.MaxLength = 10
        Me.txtSUIMBAAN.Name = "txtSUIMBAAN"
        Me.txtSUIMBAAN.Size = New System.Drawing.Size(85, 20)
        Me.txtSUIMBAAN.TabIndex = 413
        '
        'txtSUIMMUAN
        '
        Me.txtSUIMMUAN.AccessibleDescription = "Municipio"
        Me.txtSUIMMUAN.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMMUAN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMMUAN.Location = New System.Drawing.Point(107, 166)
        Me.txtSUIMMUAN.MaxLength = 10
        Me.txtSUIMMUAN.Name = "txtSUIMMUAN"
        Me.txtSUIMMUAN.Size = New System.Drawing.Size(87, 20)
        Me.txtSUIMMUAN.TabIndex = 411
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(725, 143)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 20)
        Me.Label9.TabIndex = 410
        Me.Label9.Text = "Clase o Sector"
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label56.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label56.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.ForeColor = System.Drawing.Color.Black
        Me.Label56.Location = New System.Drawing.Point(19, 120)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(790, 20)
        Me.Label56.TabIndex = 399
        Me.Label56.Text = "CEDULA CATASTRAL ANTERIOR"
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label57.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label57.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.Black
        Me.Label57.Location = New System.Drawing.Point(19, 166)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(85, 20)
        Me.Label57.TabIndex = 398
        Me.Label57.Text = "Código Actual"
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label58.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label58.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.Black
        Me.Label58.Location = New System.Drawing.Point(638, 143)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(84, 20)
        Me.Label58.TabIndex = 397
        Me.Label58.Text = "Unidad Predial"
        '
        'Label68
        '
        Me.Label68.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label68.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label68.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.ForeColor = System.Drawing.Color.Black
        Me.Label68.Location = New System.Drawing.Point(550, 143)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(84, 20)
        Me.Label68.TabIndex = 396
        Me.Label68.Text = "Edificio"
        '
        'Label74
        '
        Me.Label74.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label74.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label74.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.ForeColor = System.Drawing.Color.Black
        Me.Label74.Location = New System.Drawing.Point(462, 143)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(84, 20)
        Me.Label74.TabIndex = 395
        Me.Label74.Text = "Predio"
        '
        'Label76
        '
        Me.Label76.AccessibleDescription = ""
        Me.Label76.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label76.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label76.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.ForeColor = System.Drawing.Color.Black
        Me.Label76.Location = New System.Drawing.Point(374, 143)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(84, 20)
        Me.Label76.TabIndex = 394
        Me.Label76.Text = "Manza / Vered"
        '
        'Label79
        '
        Me.Label79.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label79.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label79.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.ForeColor = System.Drawing.Color.Black
        Me.Label79.Location = New System.Drawing.Point(286, 143)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(84, 20)
        Me.Label79.TabIndex = 393
        Me.Label79.Text = "Barrio"
        '
        'Label80
        '
        Me.Label80.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label80.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label80.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.ForeColor = System.Drawing.Color.Black
        Me.Label80.Location = New System.Drawing.Point(198, 143)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(84, 20)
        Me.Label80.TabIndex = 392
        Me.Label80.Text = "Corregimiento"
        '
        'Label91
        '
        Me.Label91.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label91.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label91.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label91.ForeColor = System.Drawing.Color.Black
        Me.Label91.Location = New System.Drawing.Point(108, 143)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(86, 20)
        Me.Label91.TabIndex = 391
        Me.Label91.Text = "Municipio"
        '
        'Label92
        '
        Me.Label92.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label92.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label92.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label92.ForeColor = System.Drawing.Color.Black
        Me.Label92.Location = New System.Drawing.Point(19, 143)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(85, 20)
        Me.Label92.TabIndex = 390
        Me.Label92.Text = "CODIGO"
        '
        'txtSUIMESTA
        '
        Me.txtSUIMESTA.AccessibleDescription = "Estado"
        Me.txtSUIMESTA.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMESTA.Location = New System.Drawing.Point(725, 234)
        Me.txtSUIMESTA.MaxLength = 10
        Me.txtSUIMESTA.Name = "txtSUIMESTA"
        Me.txtSUIMESTA.Size = New System.Drawing.Size(84, 20)
        Me.txtSUIMESTA.TabIndex = 25
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(638, 235)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 20)
        Me.Label8.TabIndex = 314
        Me.Label8.Text = "Estado"
        '
        'txtSUIMCAPR
        '
        Me.txtSUIMCAPR.AccessibleDescription = "Caracteristica de predio"
        Me.txtSUIMCAPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMCAPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMCAPR.Location = New System.Drawing.Point(550, 235)
        Me.txtSUIMCAPR.MaxLength = 10
        Me.txtSUIMCAPR.Name = "txtSUIMCAPR"
        Me.txtSUIMCAPR.Size = New System.Drawing.Size(85, 20)
        Me.txtSUIMCAPR.TabIndex = 24
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(374, 236)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(172, 20)
        Me.Label7.TabIndex = 312
        Me.Label7.Text = "Caracteristica de predio"
        '
        'txtSUIMMAIN
        '
        Me.txtSUIMMAIN.AccessibleDescription = "Matricula inmobiliaria"
        Me.txtSUIMMAIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMMAIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMMAIN.Location = New System.Drawing.Point(198, 236)
        Me.txtSUIMMAIN.MaxLength = 20
        Me.txtSUIMMAIN.Name = "txtSUIMMAIN"
        Me.txtSUIMMAIN.Size = New System.Drawing.Size(173, 20)
        Me.txtSUIMMAIN.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(19, 235)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(176, 20)
        Me.Label6.TabIndex = 310
        Me.Label6.Text = "Matricula inmobiliaria"
        '
        'txtSUIMVIAN
        '
        Me.txtSUIMVIAN.AccessibleDescription = "Vigencia anterior"
        Me.txtSUIMVIAN.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMVIAN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMVIAN.Location = New System.Drawing.Point(638, 212)
        Me.txtSUIMVIAN.MaxLength = 10
        Me.txtSUIMVIAN.Name = "txtSUIMVIAN"
        Me.txtSUIMVIAN.Size = New System.Drawing.Size(171, 20)
        Me.txtSUIMVIAN.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(462, 212)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(173, 20)
        Me.Label5.TabIndex = 308
        Me.Label5.Text = "Vigencia anterior"
        '
        'txtSUIMVIAC
        '
        Me.txtSUIMVIAC.AccessibleDescription = "Vigencia actual"
        Me.txtSUIMVIAC.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMVIAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMVIAC.Location = New System.Drawing.Point(638, 189)
        Me.txtSUIMVIAC.MaxLength = 10
        Me.txtSUIMVIAC.Name = "txtSUIMVIAC"
        Me.txtSUIMVIAC.Size = New System.Drawing.Size(171, 20)
        Me.txtSUIMVIAC.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(462, 189)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(173, 20)
        Me.Label4.TabIndex = 306
        Me.Label4.Text = "Vigencia actual"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 212)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(176, 20)
        Me.Label3.TabIndex = 304
        Me.Label3.Text = "Sujeto Impuesto anterior"
        '
        'txtSUIMSUAN
        '
        Me.txtSUIMSUAN.AccessibleDescription = "Sujeto anterior"
        Me.txtSUIMSUAN.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMSUAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUIMSUAN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMSUAN.ForeColor = System.Drawing.Color.Black
        Me.txtSUIMSUAN.Location = New System.Drawing.Point(198, 212)
        Me.txtSUIMSUAN.MaxLength = 49
        Me.txtSUIMSUAN.Name = "txtSUIMSUAN"
        Me.txtSUIMSUAN.Size = New System.Drawing.Size(261, 20)
        Me.txtSUIMSUAN.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 189)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 20)
        Me.Label2.TabIndex = 302
        Me.Label2.Text = "Sujeto Impuesto actual"
        '
        'txtSUIMSUAC
        '
        Me.txtSUIMSUAC.AccessibleDescription = "Sujeto actual"
        Me.txtSUIMSUAC.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMSUAC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUIMSUAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMSUAC.ForeColor = System.Drawing.Color.Black
        Me.txtSUIMSUAC.Location = New System.Drawing.Point(198, 189)
        Me.txtSUIMSUAC.MaxLength = 49
        Me.txtSUIMSUAC.Name = "txtSUIMSUAC"
        Me.txtSUIMSUAC.Size = New System.Drawing.Size(261, 20)
        Me.txtSUIMSUAC.TabIndex = 19
        '
        'dgvCONSULTA
        '
        Me.dgvCONSULTA.AccessibleDescription = ""
        Me.dgvCONSULTA.AllowUserToAddRows = False
        Me.dgvCONSULTA.AllowUserToDeleteRows = False
        Me.dgvCONSULTA.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCONSULTA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCONSULTA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCONSULTA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCONSULTA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCONSULTA.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCONSULTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCONSULTA.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCONSULTA.ColumnHeadersHeight = 40
        Me.dgvCONSULTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvCONSULTA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCONSULTA.Location = New System.Drawing.Point(19, 262)
        Me.dgvCONSULTA.MultiSelect = False
        Me.dgvCONSULTA.Name = "dgvCONSULTA"
        Me.dgvCONSULTA.ReadOnly = True
        Me.dgvCONSULTA.RowHeadersVisible = False
        Me.dgvCONSULTA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCONSULTA.ShowCellToolTips = False
        Me.dgvCONSULTA.Size = New System.Drawing.Size(790, 200)
        Me.dgvCONSULTA.StandardTab = True
        Me.dgvCONSULTA.TabIndex = 40
        '
        'txtSUIMCLSE
        '
        Me.txtSUIMCLSE.AccessibleDescription = "Clase o sector"
        Me.txtSUIMCLSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMCLSE.Location = New System.Drawing.Point(725, 97)
        Me.txtSUIMCLSE.MaxLength = 10
        Me.txtSUIMCLSE.Name = "txtSUIMCLSE"
        Me.txtSUIMCLSE.Size = New System.Drawing.Size(84, 20)
        Me.txtSUIMCLSE.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 20)
        Me.Label1.TabIndex = 288
        Me.Label1.Text = "Nro. FICHA"
        '
        'txtSUIMNUFI
        '
        Me.txtSUIMNUFI.AccessibleDescription = "Nro. Ficha predial"
        Me.txtSUIMNUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMNUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMNUFI.Location = New System.Drawing.Point(108, 28)
        Me.txtSUIMNUFI.MaxLength = 9
        Me.txtSUIMNUFI.Name = "txtSUIMNUFI"
        Me.txtSUIMNUFI.Size = New System.Drawing.Size(175, 20)
        Me.txtSUIMNUFI.TabIndex = 1
        '
        'lblDireccion
        '
        Me.lblDireccion.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblDireccion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDireccion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccion.ForeColor = System.Drawing.Color.Black
        Me.lblDireccion.Location = New System.Drawing.Point(286, 29)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(84, 20)
        Me.lblDireccion.TabIndex = 99
        Me.lblDireccion.Text = "Dirección"
        '
        'txtSUIMDIRE
        '
        Me.txtSUIMDIRE.AccessibleDescription = "Dirección "
        Me.txtSUIMDIRE.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMDIRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUIMDIRE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMDIRE.ForeColor = System.Drawing.Color.Black
        Me.txtSUIMDIRE.Location = New System.Drawing.Point(374, 28)
        Me.txtSUIMDIRE.MaxLength = 49
        Me.txtSUIMDIRE.Name = "txtSUIMDIRE"
        Me.txtSUIMDIRE.Size = New System.Drawing.Size(435, 20)
        Me.txtSUIMDIRE.TabIndex = 2
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(19, 51)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(790, 20)
        Me.Label33.TabIndex = 278
        Me.Label33.Text = "CEDULA CATASTRAL ACTUAL"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(19, 74)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(85, 20)
        Me.lblCodigo.TabIndex = 300
        Me.lblCodigo.Text = "CODIGO"
        '
        'txtSUIMCORR
        '
        Me.txtSUIMCORR.AccessibleDescription = "Corregimiento"
        Me.txtSUIMCORR.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMCORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMCORR.Location = New System.Drawing.Point(198, 97)
        Me.txtSUIMCORR.MaxLength = 10
        Me.txtSUIMCORR.Name = "txtSUIMCORR"
        Me.txtSUIMCORR.Size = New System.Drawing.Size(85, 20)
        Me.txtSUIMCORR.TabIndex = 4
        '
        'lblMunicipio
        '
        Me.lblMunicipio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblMunicipio.Location = New System.Drawing.Point(108, 74)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(86, 20)
        Me.lblMunicipio.TabIndex = 300
        Me.lblMunicipio.Text = "Municipio"
        '
        'txtSUIMMUNI
        '
        Me.txtSUIMMUNI.AccessibleDescription = "Municipio"
        Me.txtSUIMMUNI.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMMUNI.Location = New System.Drawing.Point(108, 97)
        Me.txtSUIMMUNI.MaxLength = 10
        Me.txtSUIMMUNI.Name = "txtSUIMMUNI"
        Me.txtSUIMMUNI.Size = New System.Drawing.Size(86, 20)
        Me.txtSUIMMUNI.TabIndex = 3
        '
        'lblCorregimiento
        '
        Me.lblCorregimiento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCorregimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorregimiento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorregimiento.ForeColor = System.Drawing.Color.Black
        Me.lblCorregimiento.Location = New System.Drawing.Point(198, 74)
        Me.lblCorregimiento.Name = "lblCorregimiento"
        Me.lblCorregimiento.Size = New System.Drawing.Size(84, 20)
        Me.lblCorregimiento.TabIndex = 30
        Me.lblCorregimiento.Text = "Corregimiento"
        '
        'lblClaseOSector2
        '
        Me.lblClaseOSector2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseOSector2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseOSector2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseOSector2.ForeColor = System.Drawing.Color.Black
        Me.lblClaseOSector2.Location = New System.Drawing.Point(725, 74)
        Me.lblClaseOSector2.Name = "lblClaseOSector2"
        Me.lblClaseOSector2.Size = New System.Drawing.Size(84, 20)
        Me.lblClaseOSector2.TabIndex = 45
        Me.lblClaseOSector2.Text = "Clase o Sector"
        '
        'lblBarrio
        '
        Me.lblBarrio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblBarrio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBarrio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarrio.ForeColor = System.Drawing.Color.Black
        Me.lblBarrio.Location = New System.Drawing.Point(286, 74)
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Size = New System.Drawing.Size(84, 20)
        Me.lblBarrio.TabIndex = 22
        Me.lblBarrio.Text = "Barrio"
        '
        'txtSUIMUNPR
        '
        Me.txtSUIMUNPR.AccessibleDescription = "Unidad predial "
        Me.txtSUIMUNPR.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMUNPR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUIMUNPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMUNPR.ForeColor = System.Drawing.Color.Black
        Me.txtSUIMUNPR.Location = New System.Drawing.Point(638, 97)
        Me.txtSUIMUNPR.MaxLength = 10
        Me.txtSUIMUNPR.Name = "txtSUIMUNPR"
        Me.txtSUIMUNPR.Size = New System.Drawing.Size(84, 20)
        Me.txtSUIMUNPR.TabIndex = 9
        '
        'lblManzana
        '
        Me.lblManzana.AccessibleDescription = ""
        Me.lblManzana.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblManzana.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblManzana.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManzana.ForeColor = System.Drawing.Color.Black
        Me.lblManzana.Location = New System.Drawing.Point(374, 74)
        Me.lblManzana.Name = "lblManzana"
        Me.lblManzana.Size = New System.Drawing.Size(84, 20)
        Me.lblManzana.TabIndex = 23
        Me.lblManzana.Text = "Manza / Vered"
        '
        'txtSUIMEDIF
        '
        Me.txtSUIMEDIF.AccessibleDescription = "Edificio "
        Me.txtSUIMEDIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMEDIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUIMEDIF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMEDIF.ForeColor = System.Drawing.Color.Black
        Me.txtSUIMEDIF.Location = New System.Drawing.Point(550, 97)
        Me.txtSUIMEDIF.MaxLength = 10
        Me.txtSUIMEDIF.Name = "txtSUIMEDIF"
        Me.txtSUIMEDIF.Size = New System.Drawing.Size(85, 20)
        Me.txtSUIMEDIF.TabIndex = 8
        '
        'lblPredio
        '
        Me.lblPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredio.ForeColor = System.Drawing.Color.Black
        Me.lblPredio.Location = New System.Drawing.Point(462, 74)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(84, 20)
        Me.lblPredio.TabIndex = 24
        Me.lblPredio.Text = "Predio"
        '
        'txtSUIMPRED
        '
        Me.txtSUIMPRED.AccessibleDescription = "Predio "
        Me.txtSUIMPRED.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMPRED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUIMPRED.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMPRED.ForeColor = System.Drawing.Color.Black
        Me.txtSUIMPRED.Location = New System.Drawing.Point(462, 97)
        Me.txtSUIMPRED.MaxLength = 10
        Me.txtSUIMPRED.Name = "txtSUIMPRED"
        Me.txtSUIMPRED.Size = New System.Drawing.Size(85, 20)
        Me.txtSUIMPRED.TabIndex = 7
        '
        'lblEdificio
        '
        Me.lblEdificio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblEdificio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEdificio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdificio.ForeColor = System.Drawing.Color.Black
        Me.lblEdificio.Location = New System.Drawing.Point(550, 74)
        Me.lblEdificio.Name = "lblEdificio"
        Me.lblEdificio.Size = New System.Drawing.Size(84, 20)
        Me.lblEdificio.TabIndex = 25
        Me.lblEdificio.Text = "Edificio"
        '
        'txtSUIMMANZ
        '
        Me.txtSUIMMANZ.AccessibleDescription = "Manzana o vereda "
        Me.txtSUIMMANZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMMANZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUIMMANZ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMMANZ.ForeColor = System.Drawing.Color.Black
        Me.txtSUIMMANZ.Location = New System.Drawing.Point(374, 97)
        Me.txtSUIMMANZ.MaxLength = 10
        Me.txtSUIMMANZ.Name = "txtSUIMMANZ"
        Me.txtSUIMMANZ.Size = New System.Drawing.Size(85, 20)
        Me.txtSUIMMANZ.TabIndex = 6
        '
        'lblUnidadPredial
        '
        Me.lblUnidadPredial.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblUnidadPredial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUnidadPredial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidadPredial.ForeColor = System.Drawing.Color.Black
        Me.lblUnidadPredial.Location = New System.Drawing.Point(638, 74)
        Me.lblUnidadPredial.Name = "lblUnidadPredial"
        Me.lblUnidadPredial.Size = New System.Drawing.Size(84, 20)
        Me.lblUnidadPredial.TabIndex = 26
        Me.lblUnidadPredial.Text = "Unidad Predial"
        '
        'txtSUIMBARR
        '
        Me.txtSUIMBARR.AccessibleDescription = "Barrio "
        Me.txtSUIMBARR.BackColor = System.Drawing.SystemColors.Window
        Me.txtSUIMBARR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSUIMBARR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUIMBARR.ForeColor = System.Drawing.Color.Black
        Me.txtSUIMBARR.Location = New System.Drawing.Point(286, 97)
        Me.txtSUIMBARR.MaxLength = 10
        Me.txtSUIMBARR.Name = "txtSUIMBARR"
        Me.txtSUIMBARR.Size = New System.Drawing.Size(85, 20)
        Me.txtSUIMBARR.TabIndex = 5
        '
        'lblCodigoActual
        '
        Me.lblCodigoActual.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigoActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigoActual.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoActual.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoActual.Location = New System.Drawing.Point(19, 97)
        Me.lblCodigoActual.Name = "lblCodigoActual"
        Me.lblCodigoActual.Size = New System.Drawing.Size(85, 20)
        Me.lblCodigoActual.TabIndex = 27
        Me.lblCodigoActual.Text = "Código Actual"
        '
        'frm_consulta_SUJEIMPU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 599)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraPERIODO)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(869, 635)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(869, 635)
        Me.Name = "frm_consulta_SUJEIMPU"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraPERIODO.ResumeLayout(False)
        Me.fraPERIODO.PerformLayout()
        CType(Me.dgvCONSULTA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents cmdLimpiar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdConsultar As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraPERIODO As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCONSULTA As System.Windows.Forms.DataGridView
    Friend WithEvents txtSUIMCLSE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSUIMNUFI As System.Windows.Forms.TextBox
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents txtSUIMDIRE As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtSUIMCORR As System.Windows.Forms.TextBox
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents txtSUIMMUNI As System.Windows.Forms.TextBox
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblClaseOSector2 As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents txtSUIMUNPR As System.Windows.Forms.TextBox
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents txtSUIMEDIF As System.Windows.Forms.TextBox
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents txtSUIMPRED As System.Windows.Forms.TextBox
    Friend WithEvents lblEdificio As System.Windows.Forms.Label
    Friend WithEvents txtSUIMMANZ As System.Windows.Forms.TextBox
    Friend WithEvents lblUnidadPredial As System.Windows.Forms.Label
    Friend WithEvents txtSUIMBARR As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents txtSUIMMAIN As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSUIMVIAN As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSUIMVIAC As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSUIMSUAN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSUIMSUAC As System.Windows.Forms.TextBox
    Friend WithEvents txtSUIMCAPR As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSUIMESTA As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents txtSUIMMUAN As System.Windows.Forms.TextBox
    Friend WithEvents txtSUIMCSAN As System.Windows.Forms.TextBox
    Friend WithEvents txtSUIMCOAN As System.Windows.Forms.TextBox
    Friend WithEvents txtSUIMUPAN As System.Windows.Forms.TextBox
    Friend WithEvents txtSUIMEDAN As System.Windows.Forms.TextBox
    Friend WithEvents txtSUIMPRAN As System.Windows.Forms.TextBox
    Friend WithEvents txtSUIMMAAN As System.Windows.Forms.TextBox
    Friend WithEvents txtSUIMBAAN As System.Windows.Forms.TextBox
End Class
