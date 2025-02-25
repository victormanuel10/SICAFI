<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_RANGARTE
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdSALIR = New System.Windows.Forms.Button
        Me.cmdGUARDAR = New System.Windows.Forms.Button
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.fraZONAECONOMICA = New System.Windows.Forms.GroupBox
        Me.txtRAATATFI = New System.Windows.Forms.TextBox
        Me.txtRAATATIN = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtRAATPORC = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblRAATCLSE = New System.Windows.Forms.Label
        Me.cboRAATCLSE = New System.Windows.Forms.ComboBox
        Me.lblClaseosector = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblRAATDEPA = New System.Windows.Forms.Label
        Me.cboRAATDEPA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblRAATMUNI = New System.Windows.Forms.Label
        Me.cboRAATMUNI = New System.Windows.Forms.ComboBox
        Me.lblMUNICIPIO = New System.Windows.Forms.Label
        Me.cboRAATESTA = New System.Windows.Forms.ComboBox
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraZONAECONOMICA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 222)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 52)
        Me.GroupBox1.TabIndex = 37
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
        Me.cmdSALIR.TabIndex = 9
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
        Me.cmdGUARDAR.TabIndex = 8
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 294)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(598, 25)
        Me.strBARRESTA.TabIndex = 36
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
        'fraZONAECONOMICA
        '
        Me.fraZONAECONOMICA.BackColor = System.Drawing.SystemColors.Control
        Me.fraZONAECONOMICA.Controls.Add(Me.txtRAATATFI)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtRAATATIN)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label5)
        Me.fraZONAECONOMICA.Controls.Add(Me.txtRAATPORC)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label2)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblRAATCLSE)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboRAATCLSE)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblClaseosector)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label3)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblRAATDEPA)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboRAATDEPA)
        Me.fraZONAECONOMICA.Controls.Add(Me.Label4)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblRAATMUNI)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboRAATMUNI)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblMUNICIPIO)
        Me.fraZONAECONOMICA.Controls.Add(Me.cboRAATESTA)
        Me.fraZONAECONOMICA.Controls.Add(Me.lblCodigo)
        Me.fraZONAECONOMICA.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraZONAECONOMICA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraZONAECONOMICA.Location = New System.Drawing.Point(12, 7)
        Me.fraZONAECONOMICA.Name = "fraZONAECONOMICA"
        Me.fraZONAECONOMICA.Size = New System.Drawing.Size(572, 209)
        Me.fraZONAECONOMICA.TabIndex = 35
        Me.fraZONAECONOMICA.TabStop = False
        Me.fraZONAECONOMICA.Text = "MODIFICAR RANGO DE AREA DE TERRENO"
        '
        'txtRAATATFI
        '
        Me.txtRAATATFI.AccessibleDescription = "Area final"
        Me.txtRAATATFI.BackColor = System.Drawing.SystemColors.Window
        Me.txtRAATATFI.Enabled = False
        Me.txtRAATATFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRAATATFI.Location = New System.Drawing.Point(137, 120)
        Me.txtRAATATFI.MaxLength = 9
        Me.txtRAATATFI.Name = "txtRAATATFI"
        Me.txtRAATATFI.Size = New System.Drawing.Size(112, 20)
        Me.txtRAATATFI.TabIndex = 5
        Me.txtRAATATFI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRAATATIN
        '
        Me.txtRAATATIN.AccessibleDescription = "Tarifa"
        Me.txtRAATATIN.AccessibleName = "Area inicial"
        Me.txtRAATATIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtRAATATIN.Enabled = False
        Me.txtRAATATIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRAATATIN.Location = New System.Drawing.Point(137, 97)
        Me.txtRAATATIN.MaxLength = 9
        Me.txtRAATATIN.Name = "txtRAATATIN"
        Me.txtRAATATIN.Size = New System.Drawing.Size(112, 20)
        Me.txtRAATATIN.TabIndex = 4
        Me.txtRAATATIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Area inicial mts2"
        '
        'txtRAATPORC
        '
        Me.txtRAATPORC.AccessibleDescription = "Porcentaje (%)"
        Me.txtRAATPORC.BackColor = System.Drawing.SystemColors.Window
        Me.txtRAATPORC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRAATPORC.Location = New System.Drawing.Point(137, 143)
        Me.txtRAATPORC.MaxLength = 5
        Me.txtRAATPORC.Name = "txtRAATPORC"
        Me.txtRAATPORC.Size = New System.Drawing.Size(112, 20)
        Me.txtRAATPORC.TabIndex = 6
        Me.txtRAATPORC.Text = "0.00"
        Me.txtRAATPORC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Porc (%) tolerancia"
        '
        'lblRAATCLSE
        '
        Me.lblRAATCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRAATCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRAATCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRAATCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblRAATCLSE.Location = New System.Drawing.Point(438, 74)
        Me.lblRAATCLSE.Name = "lblRAATCLSE"
        Me.lblRAATCLSE.Size = New System.Drawing.Size(120, 20)
        Me.lblRAATCLSE.TabIndex = 57
        '
        'cboRAATCLSE
        '
        Me.cboRAATCLSE.AccessibleDescription = "Clase o sector"
        Me.cboRAATCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRAATCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRAATCLSE.Enabled = False
        Me.cboRAATCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRAATCLSE.FormattingEnabled = True
        Me.cboRAATCLSE.Location = New System.Drawing.Point(137, 72)
        Me.cboRAATCLSE.Name = "cboRAATCLSE"
        Me.cboRAATCLSE.Size = New System.Drawing.Size(295, 22)
        Me.cboRAATCLSE.TabIndex = 3
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
        Me.Label3.Location = New System.Drawing.Point(19, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'lblRAATDEPA
        '
        Me.lblRAATDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRAATDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRAATDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRAATDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblRAATDEPA.Location = New System.Drawing.Point(438, 28)
        Me.lblRAATDEPA.Name = "lblRAATDEPA"
        Me.lblRAATDEPA.Size = New System.Drawing.Size(120, 20)
        Me.lblRAATDEPA.TabIndex = 52
        '
        'cboRAATDEPA
        '
        Me.cboRAATDEPA.AccessibleDescription = "Departamento"
        Me.cboRAATDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRAATDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRAATDEPA.Enabled = False
        Me.cboRAATDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRAATDEPA.FormattingEnabled = True
        Me.cboRAATDEPA.Location = New System.Drawing.Point(137, 26)
        Me.cboRAATDEPA.Name = "cboRAATDEPA"
        Me.cboRAATDEPA.Size = New System.Drawing.Size(295, 22)
        Me.cboRAATDEPA.TabIndex = 1
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
        'lblRAATMUNI
        '
        Me.lblRAATMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRAATMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRAATMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRAATMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblRAATMUNI.Location = New System.Drawing.Point(438, 51)
        Me.lblRAATMUNI.Name = "lblRAATMUNI"
        Me.lblRAATMUNI.Size = New System.Drawing.Size(120, 20)
        Me.lblRAATMUNI.TabIndex = 50
        '
        'cboRAATMUNI
        '
        Me.cboRAATMUNI.AccessibleDescription = "Municipio"
        Me.cboRAATMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRAATMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRAATMUNI.Enabled = False
        Me.cboRAATMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRAATMUNI.FormattingEnabled = True
        Me.cboRAATMUNI.Location = New System.Drawing.Point(137, 49)
        Me.cboRAATMUNI.Name = "cboRAATMUNI"
        Me.cboRAATMUNI.Size = New System.Drawing.Size(295, 22)
        Me.cboRAATMUNI.TabIndex = 2
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
        'cboRAATESTA
        '
        Me.cboRAATESTA.AccessibleDescription = "Estado"
        Me.cboRAATESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRAATESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRAATESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRAATESTA.FormattingEnabled = True
        Me.cboRAATESTA.Location = New System.Drawing.Point(137, 166)
        Me.cboRAATESTA.Name = "cboRAATESTA"
        Me.cboRAATESTA.Size = New System.Drawing.Size(295, 22)
        Me.cboRAATESTA.TabIndex = 7
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(19, 120)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(112, 20)
        Me.lblCodigo.TabIndex = 37
        Me.lblCodigo.Text = "Area final mts2"
        '
        'frm_modificar_RANGARTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 319)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraZONAECONOMICA)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(614, 355)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(614, 355)
        Me.Name = "frm_modificar_RANGARTE"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraZONAECONOMICA.ResumeLayout(False)
        Me.fraZONAECONOMICA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraZONAECONOMICA As System.Windows.Forms.GroupBox
    Friend WithEvents txtRAATATFI As System.Windows.Forms.TextBox
    Friend WithEvents txtRAATATIN As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRAATPORC As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblRAATCLSE As System.Windows.Forms.Label
    Friend WithEvents cboRAATCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblRAATDEPA As System.Windows.Forms.Label
    Friend WithEvents cboRAATDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblRAATMUNI As System.Windows.Forms.Label
    Friend WithEvents cboRAATMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents cboRAATESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
End Class
