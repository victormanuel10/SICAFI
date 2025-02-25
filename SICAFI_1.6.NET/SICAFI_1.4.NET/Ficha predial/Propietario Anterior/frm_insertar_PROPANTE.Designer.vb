<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_PROPANTE
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPRACNUDO = New System.Windows.Forms.TextBox()
        Me.txtPRACSEAP = New System.Windows.Forms.Label()
        Me.txtPRACPRAP = New System.Windows.Forms.Label()
        Me.txtPRACNOMB = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.chkGuardarEnTodosLosPropietarios = New System.Windows.Forms.CheckBox()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cboPRANESTA = New System.Windows.Forms.ComboBox()
        Me.cboPRANCAAC = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPRANNUFI = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtPRANOBSE = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPRANSEAP = New System.Windows.Forms.TextBox()
        Me.txtPRANPRAP = New System.Windows.Forms.TextBox()
        Me.txtPRANNOMB = New System.Windows.Forms.TextBox()
        Me.lblPRANCAAC = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPRACNUDO)
        Me.GroupBox2.Controls.Add(Me.txtPRACSEAP)
        Me.GroupBox2.Controls.Add(Me.txtPRACPRAP)
        Me.GroupBox2.Controls.Add(Me.txtPRACNOMB)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox2.Location = New System.Drawing.Point(12, 81)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(700, 84)
        Me.GroupBox2.TabIndex = 184
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PROPIETARIO ACTUAL"
        '
        'txtPRACNUDO
        '
        Me.txtPRACNUDO.AccessibleDescription = "Nro. documento"
        Me.txtPRACNUDO.BackColor = System.Drawing.Color.White
        Me.txtPRACNUDO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPRACNUDO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRACNUDO.Location = New System.Drawing.Point(17, 50)
        Me.txtPRACNUDO.Margin = New System.Windows.Forms.Padding(0)
        Me.txtPRACNUDO.MaxLength = 15
        Me.txtPRACNUDO.Name = "txtPRACNUDO"
        Me.txtPRACNUDO.ReadOnly = True
        Me.txtPRACNUDO.Size = New System.Drawing.Size(134, 20)
        Me.txtPRACNUDO.TabIndex = 50
        Me.txtPRACNUDO.Tag = "Dirección de Residencia"
        '
        'txtPRACSEAP
        '
        Me.txtPRACSEAP.AccessibleDescription = "Segundo apellido"
        Me.txtPRACSEAP.BackColor = System.Drawing.Color.White
        Me.txtPRACSEAP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtPRACSEAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRACSEAP.ForeColor = System.Drawing.Color.Black
        Me.txtPRACSEAP.Location = New System.Drawing.Point(308, 50)
        Me.txtPRACSEAP.Name = "txtPRACSEAP"
        Me.txtPRACSEAP.Size = New System.Drawing.Size(148, 20)
        Me.txtPRACSEAP.TabIndex = 154
        '
        'txtPRACPRAP
        '
        Me.txtPRACPRAP.AccessibleDescription = "Primer apellido"
        Me.txtPRACPRAP.BackColor = System.Drawing.Color.White
        Me.txtPRACPRAP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtPRACPRAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRACPRAP.ForeColor = System.Drawing.Color.Black
        Me.txtPRACPRAP.Location = New System.Drawing.Point(154, 50)
        Me.txtPRACPRAP.Name = "txtPRACPRAP"
        Me.txtPRACPRAP.Size = New System.Drawing.Size(151, 20)
        Me.txtPRACPRAP.TabIndex = 153
        '
        'txtPRACNOMB
        '
        Me.txtPRACNOMB.AccessibleDescription = "Nombre (s)"
        Me.txtPRACNOMB.BackColor = System.Drawing.Color.White
        Me.txtPRACNOMB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtPRACNOMB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRACNOMB.ForeColor = System.Drawing.Color.Black
        Me.txtPRACNOMB.Location = New System.Drawing.Point(459, 50)
        Me.txtPRACNOMB.Name = "txtPRACNOMB"
        Me.txtPRACNOMB.Size = New System.Drawing.Size(225, 20)
        Me.txtPRACNOMB.TabIndex = 152
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(308, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 20)
        Me.Label1.TabIndex = 140
        Me.Label1.Text = "Segundo apellido                                                                 " & _
            "                                                                                " & _
            "         "
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Silver
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(459, 25)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(225, 20)
        Me.Label10.TabIndex = 138
        Me.Label10.Text = "Nombre (s)                                                                       " & _
            "                                                                                " & _
            "  "
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Silver
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 25)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(134, 20)
        Me.Label7.TabIndex = 137
        Me.Label7.Text = "Nro. Documento                                                                   " & _
            "                                                                                " & _
            "       "
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Silver
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(154, 25)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 20)
        Me.Label3.TabIndex = 139
        Me.Label3.Text = "Primer apellido                                                                  " & _
            "                                                                                " & _
            "       "
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdSALIR)
        Me.GroupBox4.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 376)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(700, 55)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Cancelar"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(351, 19)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 8
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(244, 19)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 7
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'chkGuardarEnTodosLosPropietarios
        '
        Me.chkGuardarEnTodosLosPropietarios.Location = New System.Drawing.Point(17, 169)
        Me.chkGuardarEnTodosLosPropietarios.Name = "chkGuardarEnTodosLosPropietarios"
        Me.chkGuardarEnTodosLosPropietarios.Size = New System.Drawing.Size(250, 17)
        Me.chkGuardarEnTodosLosPropietarios.TabIndex = 7
        Me.chkGuardarEnTodosLosPropietarios.Text = "Guardar en todos los propietarios actuales"
        Me.chkGuardarEnTodosLosPropietarios.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 444)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(728, 25)
        Me.strBARRESTA.TabIndex = 186
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
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(10, 3, 0, 0)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(125, 22)
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPRANESTA
        '
        Me.cboPRANESTA.AccessibleDescription = "Estado"
        Me.cboPRANESTA.BackColor = System.Drawing.Color.White
        Me.cboPRANESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPRANESTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPRANESTA.Location = New System.Drawing.Point(564, 140)
        Me.cboPRANESTA.MaxLength = 2
        Me.cboPRANESTA.Name = "cboPRANESTA"
        Me.cboPRANESTA.Size = New System.Drawing.Size(120, 21)
        Me.cboPRANESTA.TabIndex = 6
        '
        'cboPRANCAAC
        '
        Me.cboPRANCAAC.AccessibleDescription = "Causa del acto"
        Me.cboPRANCAAC.BackColor = System.Drawing.Color.White
        Me.cboPRANCAAC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPRANCAAC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPRANCAAC.Location = New System.Drawing.Point(17, 48)
        Me.cboPRANCAAC.MaxLength = 50
        Me.cboPRANCAAC.Name = "cboPRANCAAC"
        Me.cboPRANCAAC.Size = New System.Drawing.Size(151, 21)
        Me.cboPRANCAAC.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtPRANNUFI)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(700, 63)
        Me.GroupBox1.TabIndex = 188
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "INFORMACIÓN PREDIO"
        '
        'txtPRANNUFI
        '
        Me.txtPRANNUFI.AccessibleDescription = "Nro. Ficha predial"
        Me.txtPRANNUFI.BackColor = System.Drawing.Color.White
        Me.txtPRANNUFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRANNUFI.Location = New System.Drawing.Point(154, 26)
        Me.txtPRANNUFI.Name = "txtPRANNUFI"
        Me.txtPRANNUFI.ReadOnly = True
        Me.txtPRANNUFI.Size = New System.Drawing.Size(151, 20)
        Me.txtPRANNUFI.TabIndex = 54
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(17, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 21)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Nro. Ficha Predial"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkGuardarEnTodosLosPropietarios)
        Me.GroupBox3.Controls.Add(Me.txtPRANOBSE)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtPRANSEAP)
        Me.GroupBox3.Controls.Add(Me.txtPRANPRAP)
        Me.GroupBox3.Controls.Add(Me.cboPRANESTA)
        Me.GroupBox3.Controls.Add(Me.txtPRANNOMB)
        Me.GroupBox3.Controls.Add(Me.lblPRANCAAC)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.cboPRANCAAC)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox3.Location = New System.Drawing.Point(12, 171)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(700, 199)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "PROPIETARIO ANTERIOR"
        '
        'txtPRANOBSE
        '
        Me.txtPRANOBSE.AccessibleDescription = "Observación"
        Me.txtPRANOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPRANOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRANOBSE.Location = New System.Drawing.Point(17, 141)
        Me.txtPRANOBSE.MaxLength = 100
        Me.txtPRANOBSE.Name = "txtPRANOBSE"
        Me.txtPRANOBSE.Size = New System.Drawing.Size(544, 20)
        Me.txtPRANOBSE.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Silver
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(564, 118)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 20)
        Me.Label4.TabIndex = 157
        Me.Label4.Text = "Estado"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 118)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(544, 20)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "Observación"
        '
        'txtPRANSEAP
        '
        Me.txtPRANSEAP.AccessibleDescription = "Segundo apellido"
        Me.txtPRANSEAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPRANSEAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRANSEAP.Location = New System.Drawing.Point(171, 95)
        Me.txtPRANSEAP.MaxLength = 15
        Me.txtPRANSEAP.Name = "txtPRANSEAP"
        Me.txtPRANSEAP.Size = New System.Drawing.Size(148, 20)
        Me.txtPRANSEAP.TabIndex = 3
        '
        'txtPRANPRAP
        '
        Me.txtPRANPRAP.AccessibleDescription = "Primer apellido"
        Me.txtPRANPRAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPRANPRAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRANPRAP.Location = New System.Drawing.Point(17, 95)
        Me.txtPRANPRAP.MaxLength = 15
        Me.txtPRANPRAP.Name = "txtPRANPRAP"
        Me.txtPRANPRAP.Size = New System.Drawing.Size(151, 20)
        Me.txtPRANPRAP.TabIndex = 2
        '
        'txtPRANNOMB
        '
        Me.txtPRANNOMB.AccessibleDescription = "Nombre"
        Me.txtPRANNOMB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPRANNOMB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRANNOMB.Location = New System.Drawing.Point(322, 95)
        Me.txtPRANNOMB.MaxLength = 20
        Me.txtPRANNOMB.Name = "txtPRANNOMB"
        Me.txtPRANNOMB.Size = New System.Drawing.Size(362, 20)
        Me.txtPRANNOMB.TabIndex = 4
        '
        'lblPRANCAAC
        '
        Me.lblPRANCAAC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPRANCAAC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPRANCAAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPRANCAAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPRANCAAC.ForeColor = System.Drawing.Color.Black
        Me.lblPRANCAAC.Location = New System.Drawing.Point(171, 48)
        Me.lblPRANCAAC.Name = "lblPRANCAAC"
        Me.lblPRANCAAC.Size = New System.Drawing.Size(513, 20)
        Me.lblPRANCAAC.TabIndex = 155
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Silver
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(171, 72)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(148, 20)
        Me.Label13.TabIndex = 140
        Me.Label13.Text = "Segundo apellido                                                                 " & _
            "                                                                                " & _
            "         "
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Silver
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(322, 72)
        Me.Label15.Margin = New System.Windows.Forms.Padding(0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(362, 20)
        Me.Label15.TabIndex = 138
        Me.Label15.Text = "Nombre (s)                                                                       " & _
            "                                                                                " & _
            "  "
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Silver
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(17, 25)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(667, 20)
        Me.Label17.TabIndex = 137
        Me.Label17.Text = "Causa del acto"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Silver
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(17, 72)
        Me.Label14.Margin = New System.Windows.Forms.Padding(0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(151, 20)
        Me.Label14.TabIndex = 139
        Me.Label14.Text = "Primer apellido                                                                  " & _
            "                                                                                " & _
            "       "
        '
        'frm_insertar_PROPANTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 469)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.strBARRESTA)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_insertar_PROPANTE"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents txtPRACNUDO As System.Windows.Forms.TextBox
    Friend WithEvents txtPRACSEAP As System.Windows.Forms.Label
    Friend WithEvents txtPRACPRAP As System.Windows.Forms.Label
    Friend WithEvents txtPRACNOMB As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cboPRANESTA As System.Windows.Forms.ComboBox
    Friend WithEvents cboPRANCAAC As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPRANNUFI As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents Label13 As System.Windows.Forms.Label
    Private WithEvents Label14 As System.Windows.Forms.Label
    Private WithEvents Label15 As System.Windows.Forms.Label
    Private WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblPRANCAAC As System.Windows.Forms.Label
    Friend WithEvents txtPRANSEAP As System.Windows.Forms.TextBox
    Friend WithEvents txtPRANPRAP As System.Windows.Forms.TextBox
    Friend WithEvents txtPRANNOMB As System.Windows.Forms.TextBox
    Friend WithEvents txtPRANOBSE As System.Windows.Forms.TextBox
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkGuardarEnTodosLosPropietarios As System.Windows.Forms.CheckBox
End Class
