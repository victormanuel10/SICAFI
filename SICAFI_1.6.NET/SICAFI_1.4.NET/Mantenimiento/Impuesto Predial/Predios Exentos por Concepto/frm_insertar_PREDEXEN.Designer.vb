<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_PREDEXEN
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraPREDEXEN = New System.Windows.Forms.GroupBox()
        Me.txtPREXFECH = New System.Windows.Forms.MaskedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPREXRESO = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPREXPOAP = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblPREXVIFI = New System.Windows.Forms.Label()
        Me.cboPREXVIFI = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPREXNUFI = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPREXOBSE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPREXCONC = New System.Windows.Forms.Label()
        Me.cboPREXCONC = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPREXTIIM = New System.Windows.Forms.Label()
        Me.cboPREXTIIM = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblPREXVIIN = New System.Windows.Forms.Label()
        Me.cboPREXVIIN = New System.Windows.Forms.ComboBox()
        Me.lblPREXCLSE = New System.Windows.Forms.Label()
        Me.cboPREXCLSE = New System.Windows.Forms.ComboBox()
        Me.lblClaseosector = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPREXDEPA = New System.Windows.Forms.Label()
        Me.cboPREXDEPA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblPREXMUNI = New System.Windows.Forms.Label()
        Me.cboPREXMUNI = New System.Windows.Forms.ComboBox()
        Me.lblMUNICIPIO = New System.Windows.Forms.Label()
        Me.cboPREXESTA = New System.Windows.Forms.ComboBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraPREDEXEN.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 442)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 52)
        Me.GroupBox1.TabIndex = 53
        Me.GroupBox1.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(293, 17)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 21
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(186, 17)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 507)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(606, 25)
        Me.strBARRESTA.TabIndex = 54
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
        'fraPREDEXEN
        '
        Me.fraPREDEXEN.BackColor = System.Drawing.SystemColors.Control
        Me.fraPREDEXEN.Controls.Add(Me.txtPREXFECH)
        Me.fraPREDEXEN.Controls.Add(Me.Label12)
        Me.fraPREDEXEN.Controls.Add(Me.txtPREXRESO)
        Me.fraPREDEXEN.Controls.Add(Me.Label10)
        Me.fraPREDEXEN.Controls.Add(Me.txtPREXPOAP)
        Me.fraPREDEXEN.Controls.Add(Me.Label9)
        Me.fraPREDEXEN.Controls.Add(Me.lblPREXVIFI)
        Me.fraPREDEXEN.Controls.Add(Me.cboPREXVIFI)
        Me.fraPREDEXEN.Controls.Add(Me.Label8)
        Me.fraPREDEXEN.Controls.Add(Me.txtPREXNUFI)
        Me.fraPREDEXEN.Controls.Add(Me.Label5)
        Me.fraPREDEXEN.Controls.Add(Me.txtPREXOBSE)
        Me.fraPREDEXEN.Controls.Add(Me.Label1)
        Me.fraPREDEXEN.Controls.Add(Me.lblPREXCONC)
        Me.fraPREDEXEN.Controls.Add(Me.cboPREXCONC)
        Me.fraPREDEXEN.Controls.Add(Me.Label2)
        Me.fraPREDEXEN.Controls.Add(Me.lblPREXTIIM)
        Me.fraPREDEXEN.Controls.Add(Me.cboPREXTIIM)
        Me.fraPREDEXEN.Controls.Add(Me.Label11)
        Me.fraPREDEXEN.Controls.Add(Me.lblPREXVIIN)
        Me.fraPREDEXEN.Controls.Add(Me.cboPREXVIIN)
        Me.fraPREDEXEN.Controls.Add(Me.lblPREXCLSE)
        Me.fraPREDEXEN.Controls.Add(Me.cboPREXCLSE)
        Me.fraPREDEXEN.Controls.Add(Me.lblClaseosector)
        Me.fraPREDEXEN.Controls.Add(Me.Label3)
        Me.fraPREDEXEN.Controls.Add(Me.lblPREXDEPA)
        Me.fraPREDEXEN.Controls.Add(Me.cboPREXDEPA)
        Me.fraPREDEXEN.Controls.Add(Me.Label4)
        Me.fraPREDEXEN.Controls.Add(Me.lblPREXMUNI)
        Me.fraPREDEXEN.Controls.Add(Me.cboPREXMUNI)
        Me.fraPREDEXEN.Controls.Add(Me.lblMUNICIPIO)
        Me.fraPREDEXEN.Controls.Add(Me.cboPREXESTA)
        Me.fraPREDEXEN.Controls.Add(Me.lblCodigo)
        Me.fraPREDEXEN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPREDEXEN.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPREDEXEN.Location = New System.Drawing.Point(16, 5)
        Me.fraPREDEXEN.Name = "fraPREDEXEN"
        Me.fraPREDEXEN.Size = New System.Drawing.Size(572, 431)
        Me.fraPREDEXEN.TabIndex = 52
        Me.fraPREDEXEN.TabStop = False
        Me.fraPREDEXEN.Text = "INSERTAR PREDIOS EXENTOS"
        '
        'txtPREXFECH
        '
        Me.txtPREXFECH.AccessibleDescription = "Fecha de resolución"
        Me.txtPREXFECH.BackColor = System.Drawing.Color.White
        Me.txtPREXFECH.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPREXFECH.Location = New System.Drawing.Point(137, 260)
        Me.txtPREXFECH.Mask = "00-00-0000"
        Me.txtPREXFECH.Name = "txtPREXFECH"
        Me.txtPREXFECH.Size = New System.Drawing.Size(150, 20)
        Me.txtPREXFECH.TabIndex = 11
        Me.txtPREXFECH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(19, 260)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 20)
        Me.Label12.TabIndex = 96
        Me.Label12.Text = "Fecha resolución"
        '
        'txtPREXRESO
        '
        Me.txtPREXRESO.AccessibleDescription = "Resolución"
        Me.txtPREXRESO.BackColor = System.Drawing.SystemColors.Window
        Me.txtPREXRESO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPREXRESO.Location = New System.Drawing.Point(137, 237)
        Me.txtPREXRESO.MaxLength = 20
        Me.txtPREXRESO.Name = "txtPREXRESO"
        Me.txtPREXRESO.Size = New System.Drawing.Size(150, 20)
        Me.txtPREXRESO.TabIndex = 10
        Me.txtPREXRESO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(19, 237)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 20)
        Me.Label10.TabIndex = 94
        Me.Label10.Text = "Resolución"
        '
        'txtPREXPOAP
        '
        Me.txtPREXPOAP.AccessibleDescription = "(%) Aplicado"
        Me.txtPREXPOAP.BackColor = System.Drawing.SystemColors.Window
        Me.txtPREXPOAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPREXPOAP.Location = New System.Drawing.Point(137, 214)
        Me.txtPREXPOAP.MaxLength = 3
        Me.txtPREXPOAP.Name = "txtPREXPOAP"
        Me.txtPREXPOAP.Size = New System.Drawing.Size(150, 20)
        Me.txtPREXPOAP.TabIndex = 9
        Me.txtPREXPOAP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(19, 214)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 20)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "(%) Aplicado"
        '
        'lblPREXVIFI
        '
        Me.lblPREXVIFI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPREXVIFI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPREXVIFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPREXVIFI.ForeColor = System.Drawing.Color.Black
        Me.lblPREXVIFI.Location = New System.Drawing.Point(448, 191)
        Me.lblPREXVIFI.Name = "lblPREXVIFI"
        Me.lblPREXVIFI.Size = New System.Drawing.Size(110, 20)
        Me.lblPREXVIFI.TabIndex = 90
        '
        'cboPREXVIFI
        '
        Me.cboPREXVIFI.AccessibleDescription = "Vigencia final"
        Me.cboPREXVIFI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPREXVIFI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPREXVIFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPREXVIFI.FormattingEnabled = True
        Me.cboPREXVIFI.Location = New System.Drawing.Point(137, 189)
        Me.cboPREXVIFI.Name = "cboPREXVIFI"
        Me.cboPREXVIFI.Size = New System.Drawing.Size(305, 22)
        Me.cboPREXVIFI.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(19, 191)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 20)
        Me.Label8.TabIndex = 89
        Me.Label8.Text = "Vigencia final"
        '
        'txtPREXNUFI
        '
        Me.txtPREXNUFI.AccessibleDescription = "Nro. de ficha"
        Me.txtPREXNUFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtPREXNUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPREXNUFI.Location = New System.Drawing.Point(137, 97)
        Me.txtPREXNUFI.MaxLength = 8
        Me.txtPREXNUFI.Name = "txtPREXNUFI"
        Me.txtPREXNUFI.Size = New System.Drawing.Size(150, 20)
        Me.txtPREXNUFI.TabIndex = 4
        Me.txtPREXNUFI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 87
        Me.Label5.Text = "Nro. de ficha"
        '
        'txtPREXOBSE
        '
        Me.txtPREXOBSE.AccessibleDescription = "Observación"
        Me.txtPREXOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtPREXOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPREXOBSE.Location = New System.Drawing.Point(137, 307)
        Me.txtPREXOBSE.MaxLength = 100
        Me.txtPREXOBSE.Multiline = True
        Me.txtPREXOBSE.Name = "txtPREXOBSE"
        Me.txtPREXOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPREXOBSE.Size = New System.Drawing.Size(421, 106)
        Me.txtPREXOBSE.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 307)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Descripción"
        '
        'lblPREXCONC
        '
        Me.lblPREXCONC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPREXCONC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPREXCONC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPREXCONC.ForeColor = System.Drawing.Color.Black
        Me.lblPREXCONC.Location = New System.Drawing.Point(448, 145)
        Me.lblPREXCONC.Name = "lblPREXCONC"
        Me.lblPREXCONC.Size = New System.Drawing.Size(110, 20)
        Me.lblPREXCONC.TabIndex = 81
        '
        'cboPREXCONC
        '
        Me.cboPREXCONC.AccessibleDescription = "Concepto"
        Me.cboPREXCONC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPREXCONC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPREXCONC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPREXCONC.FormattingEnabled = True
        Me.cboPREXCONC.Location = New System.Drawing.Point(137, 143)
        Me.cboPREXCONC.Name = "cboPREXCONC"
        Me.cboPREXCONC.Size = New System.Drawing.Size(305, 22)
        Me.cboPREXCONC.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Concepto"
        '
        'lblPREXTIIM
        '
        Me.lblPREXTIIM.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPREXTIIM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPREXTIIM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPREXTIIM.ForeColor = System.Drawing.Color.Black
        Me.lblPREXTIIM.Location = New System.Drawing.Point(448, 121)
        Me.lblPREXTIIM.Name = "lblPREXTIIM"
        Me.lblPREXTIIM.Size = New System.Drawing.Size(110, 20)
        Me.lblPREXTIIM.TabIndex = 78
        '
        'cboPREXTIIM
        '
        Me.cboPREXTIIM.AccessibleDescription = "Tipo de impuesto"
        Me.cboPREXTIIM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPREXTIIM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPREXTIIM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPREXTIIM.FormattingEnabled = True
        Me.cboPREXTIIM.Location = New System.Drawing.Point(137, 119)
        Me.cboPREXTIIM.Name = "cboPREXTIIM"
        Me.cboPREXTIIM.Size = New System.Drawing.Size(305, 22)
        Me.cboPREXTIIM.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(19, 121)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 20)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "Tipo de impuesto"
        '
        'lblPREXVIIN
        '
        Me.lblPREXVIIN.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPREXVIIN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPREXVIIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPREXVIIN.ForeColor = System.Drawing.Color.Black
        Me.lblPREXVIIN.Location = New System.Drawing.Point(448, 168)
        Me.lblPREXVIIN.Name = "lblPREXVIIN"
        Me.lblPREXVIIN.Size = New System.Drawing.Size(110, 20)
        Me.lblPREXVIIN.TabIndex = 62
        '
        'cboPREXVIIN
        '
        Me.cboPREXVIIN.AccessibleDescription = "Vigencia inicial"
        Me.cboPREXVIIN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPREXVIIN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPREXVIIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPREXVIIN.FormattingEnabled = True
        Me.cboPREXVIIN.Location = New System.Drawing.Point(137, 166)
        Me.cboPREXVIIN.Name = "cboPREXVIIN"
        Me.cboPREXVIIN.Size = New System.Drawing.Size(305, 22)
        Me.cboPREXVIIN.TabIndex = 7
        '
        'lblPREXCLSE
        '
        Me.lblPREXCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPREXCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPREXCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPREXCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblPREXCLSE.Location = New System.Drawing.Point(448, 74)
        Me.lblPREXCLSE.Name = "lblPREXCLSE"
        Me.lblPREXCLSE.Size = New System.Drawing.Size(110, 20)
        Me.lblPREXCLSE.TabIndex = 57
        '
        'cboPREXCLSE
        '
        Me.cboPREXCLSE.AccessibleDescription = "Clase o sector"
        Me.cboPREXCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPREXCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPREXCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPREXCLSE.FormattingEnabled = True
        Me.cboPREXCLSE.Location = New System.Drawing.Point(137, 72)
        Me.cboPREXCLSE.Name = "cboPREXCLSE"
        Me.cboPREXCLSE.Size = New System.Drawing.Size(305, 22)
        Me.cboPREXCLSE.TabIndex = 3
        '
        'lblClaseosector
        '
        Me.lblClaseosector.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseosector.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseosector.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseosector.ForeColor = System.Drawing.Color.Black
        Me.lblClaseosector.Location = New System.Drawing.Point(19, 74)
        Me.lblClaseosector.Name = "lblClaseosector"
        Me.lblClaseosector.Size = New System.Drawing.Size(112, 20)
        Me.lblClaseosector.TabIndex = 56
        Me.lblClaseosector.Text = "Clase o sector"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 283)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'lblPREXDEPA
        '
        Me.lblPREXDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPREXDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPREXDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPREXDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblPREXDEPA.Location = New System.Drawing.Point(448, 28)
        Me.lblPREXDEPA.Name = "lblPREXDEPA"
        Me.lblPREXDEPA.Size = New System.Drawing.Size(110, 20)
        Me.lblPREXDEPA.TabIndex = 52
        '
        'cboPREXDEPA
        '
        Me.cboPREXDEPA.AccessibleDescription = "Departamento"
        Me.cboPREXDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPREXDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPREXDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPREXDEPA.FormattingEnabled = True
        Me.cboPREXDEPA.Location = New System.Drawing.Point(137, 26)
        Me.cboPREXDEPA.Name = "cboPREXDEPA"
        Me.cboPREXDEPA.Size = New System.Drawing.Size(305, 22)
        Me.cboPREXDEPA.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 20)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Departamento"
        '
        'lblPREXMUNI
        '
        Me.lblPREXMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPREXMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPREXMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPREXMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblPREXMUNI.Location = New System.Drawing.Point(448, 51)
        Me.lblPREXMUNI.Name = "lblPREXMUNI"
        Me.lblPREXMUNI.Size = New System.Drawing.Size(110, 20)
        Me.lblPREXMUNI.TabIndex = 50
        '
        'cboPREXMUNI
        '
        Me.cboPREXMUNI.AccessibleDescription = "Municipio"
        Me.cboPREXMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPREXMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPREXMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPREXMUNI.FormattingEnabled = True
        Me.cboPREXMUNI.Location = New System.Drawing.Point(137, 49)
        Me.cboPREXMUNI.Name = "cboPREXMUNI"
        Me.cboPREXMUNI.Size = New System.Drawing.Size(305, 22)
        Me.cboPREXMUNI.TabIndex = 2
        '
        'lblMUNICIPIO
        '
        Me.lblMUNICIPIO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMUNICIPIO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUNICIPIO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUNICIPIO.ForeColor = System.Drawing.Color.Black
        Me.lblMUNICIPIO.Location = New System.Drawing.Point(19, 51)
        Me.lblMUNICIPIO.Name = "lblMUNICIPIO"
        Me.lblMUNICIPIO.Size = New System.Drawing.Size(112, 20)
        Me.lblMUNICIPIO.TabIndex = 49
        Me.lblMUNICIPIO.Text = "Municipio"
        '
        'cboPREXESTA
        '
        Me.cboPREXESTA.AccessibleDescription = "Estado"
        Me.cboPREXESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPREXESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPREXESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPREXESTA.FormattingEnabled = True
        Me.cboPREXESTA.Location = New System.Drawing.Point(137, 282)
        Me.cboPREXESTA.Name = "cboPREXESTA"
        Me.cboPREXESTA.Size = New System.Drawing.Size(305, 22)
        Me.cboPREXESTA.TabIndex = 12
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(19, 168)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(112, 20)
        Me.lblCodigo.TabIndex = 37
        Me.lblCodigo.Text = "Vigencia inicial "
        '
        'frm_insertar_PREDEXEN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606, 532)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraPREDEXEN)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(622, 568)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(622, 568)
        Me.Name = "frm_insertar_PREDEXEN"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraPREDEXEN.ResumeLayout(False)
        Me.fraPREDEXEN.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraPREDEXEN As System.Windows.Forms.GroupBox
    Friend WithEvents txtPREXOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPREXCONC As System.Windows.Forms.Label
    Friend WithEvents cboPREXCONC As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPREXTIIM As System.Windows.Forms.Label
    Friend WithEvents cboPREXTIIM As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblPREXVIIN As System.Windows.Forms.Label
    Friend WithEvents cboPREXVIIN As System.Windows.Forms.ComboBox
    Friend WithEvents lblPREXCLSE As System.Windows.Forms.Label
    Friend WithEvents cboPREXCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPREXDEPA As System.Windows.Forms.Label
    Friend WithEvents cboPREXDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblPREXMUNI As System.Windows.Forms.Label
    Friend WithEvents cboPREXMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cboPREXESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblPREXVIFI As System.Windows.Forms.Label
    Friend WithEvents cboPREXVIFI As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPREXNUFI As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPREXRESO As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPREXPOAP As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPREXFECH As System.Windows.Forms.MaskedTextBox
End Class
