<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_BARRVERE
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
        Me.fraBARRVERE = New System.Windows.Forms.GroupBox()
        Me.lblBAVECORR = New System.Windows.Forms.Label()
        Me.cboBAVECORR = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboBAVEESTA = New System.Windows.Forms.ComboBox()
        Me.lblBAVECLSE = New System.Windows.Forms.Label()
        Me.cboBAVECLSE = New System.Windows.Forms.ComboBox()
        Me.lblClaseosector = New System.Windows.Forms.Label()
        Me.lblBAVEDEPA = New System.Windows.Forms.Label()
        Me.cboBAVEDEPA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblBAVEMUNI = New System.Windows.Forms.Label()
        Me.cboBAVEMUNI = New System.Windows.Forms.ComboBox()
        Me.lblMUNICIPIO = New System.Windows.Forms.Label()
        Me.txtBAVEDESC = New System.Windows.Forms.TextBox()
        Me.txtBAVECODI = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraBARRVERE.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 216)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(588, 52)
        Me.GroupBox1.TabIndex = 40
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
        Me.cmdSALIR.TabIndex = 11
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
        Me.cmdGUARDAR.TabIndex = 10
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 284)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(613, 25)
        Me.strBARRESTA.TabIndex = 39
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
        'fraBARRVERE
        '
        Me.fraBARRVERE.BackColor = System.Drawing.SystemColors.Control
        Me.fraBARRVERE.Controls.Add(Me.lblBAVECORR)
        Me.fraBARRVERE.Controls.Add(Me.cboBAVECORR)
        Me.fraBARRVERE.Controls.Add(Me.Label5)
        Me.fraBARRVERE.Controls.Add(Me.Label3)
        Me.fraBARRVERE.Controls.Add(Me.cboBAVEESTA)
        Me.fraBARRVERE.Controls.Add(Me.lblBAVECLSE)
        Me.fraBARRVERE.Controls.Add(Me.cboBAVECLSE)
        Me.fraBARRVERE.Controls.Add(Me.lblClaseosector)
        Me.fraBARRVERE.Controls.Add(Me.lblBAVEDEPA)
        Me.fraBARRVERE.Controls.Add(Me.cboBAVEDEPA)
        Me.fraBARRVERE.Controls.Add(Me.Label4)
        Me.fraBARRVERE.Controls.Add(Me.lblBAVEMUNI)
        Me.fraBARRVERE.Controls.Add(Me.cboBAVEMUNI)
        Me.fraBARRVERE.Controls.Add(Me.lblMUNICIPIO)
        Me.fraBARRVERE.Controls.Add(Me.txtBAVEDESC)
        Me.fraBARRVERE.Controls.Add(Me.txtBAVECODI)
        Me.fraBARRVERE.Controls.Add(Me.Label1)
        Me.fraBARRVERE.Controls.Add(Me.lblCodigo)
        Me.fraBARRVERE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraBARRVERE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraBARRVERE.Location = New System.Drawing.Point(12, 6)
        Me.fraBARRVERE.Name = "fraBARRVERE"
        Me.fraBARRVERE.Size = New System.Drawing.Size(588, 204)
        Me.fraBARRVERE.TabIndex = 38
        Me.fraBARRVERE.TabStop = False
        Me.fraBARRVERE.Text = "MODIFICAR BARRIO - VEREDA"
        '
        'lblBAVECORR
        '
        Me.lblBAVECORR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblBAVECORR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBAVECORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBAVECORR.ForeColor = System.Drawing.Color.Black
        Me.lblBAVECORR.Location = New System.Drawing.Point(454, 97)
        Me.lblBAVECORR.Name = "lblBAVECORR"
        Me.lblBAVECORR.Size = New System.Drawing.Size(120, 20)
        Me.lblBAVECORR.TabIndex = 63
        '
        'cboBAVECORR
        '
        Me.cboBAVECORR.AccessibleDescription = "Corregimiento"
        Me.cboBAVECORR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboBAVECORR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBAVECORR.Enabled = False
        Me.cboBAVECORR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBAVECORR.FormattingEnabled = True
        Me.cboBAVECORR.Location = New System.Drawing.Point(153, 95)
        Me.cboBAVECORR.Name = "cboBAVECORR"
        Me.cboBAVECORR.Size = New System.Drawing.Size(295, 22)
        Me.cboBAVECORR.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 20)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "Corregimiento"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'cboBAVEESTA
        '
        Me.cboBAVEESTA.AccessibleDescription = "Estado"
        Me.cboBAVEESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboBAVEESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBAVEESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBAVEESTA.FormattingEnabled = True
        Me.cboBAVEESTA.Location = New System.Drawing.Point(153, 166)
        Me.cboBAVEESTA.Name = "cboBAVEESTA"
        Me.cboBAVEESTA.Size = New System.Drawing.Size(295, 22)
        Me.cboBAVEESTA.TabIndex = 7
        '
        'lblBAVECLSE
        '
        Me.lblBAVECLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblBAVECLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBAVECLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBAVECLSE.ForeColor = System.Drawing.Color.Black
        Me.lblBAVECLSE.Location = New System.Drawing.Point(454, 74)
        Me.lblBAVECLSE.Name = "lblBAVECLSE"
        Me.lblBAVECLSE.Size = New System.Drawing.Size(120, 20)
        Me.lblBAVECLSE.TabIndex = 57
        '
        'cboBAVECLSE
        '
        Me.cboBAVECLSE.AccessibleDescription = "Clase o sector"
        Me.cboBAVECLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboBAVECLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBAVECLSE.Enabled = False
        Me.cboBAVECLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBAVECLSE.FormattingEnabled = True
        Me.cboBAVECLSE.Location = New System.Drawing.Point(153, 72)
        Me.cboBAVECLSE.Name = "cboBAVECLSE"
        Me.cboBAVECLSE.Size = New System.Drawing.Size(295, 22)
        Me.cboBAVECLSE.TabIndex = 3
        '
        'lblClaseosector
        '
        Me.lblClaseosector.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblClaseosector.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClaseosector.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaseosector.ForeColor = System.Drawing.Color.Black
        Me.lblClaseosector.Location = New System.Drawing.Point(19, 74)
        Me.lblClaseosector.Name = "lblClaseosector"
        Me.lblClaseosector.Size = New System.Drawing.Size(130, 20)
        Me.lblClaseosector.TabIndex = 56
        Me.lblClaseosector.Text = "Clase o sector"
        '
        'lblBAVEDEPA
        '
        Me.lblBAVEDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblBAVEDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBAVEDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBAVEDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblBAVEDEPA.Location = New System.Drawing.Point(454, 28)
        Me.lblBAVEDEPA.Name = "lblBAVEDEPA"
        Me.lblBAVEDEPA.Size = New System.Drawing.Size(120, 20)
        Me.lblBAVEDEPA.TabIndex = 52
        '
        'cboBAVEDEPA
        '
        Me.cboBAVEDEPA.AccessibleDescription = "Departamento"
        Me.cboBAVEDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboBAVEDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBAVEDEPA.Enabled = False
        Me.cboBAVEDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBAVEDEPA.FormattingEnabled = True
        Me.cboBAVEDEPA.Location = New System.Drawing.Point(153, 26)
        Me.cboBAVEDEPA.Name = "cboBAVEDEPA"
        Me.cboBAVEDEPA.Size = New System.Drawing.Size(295, 22)
        Me.cboBAVEDEPA.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 20)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Departamento"
        '
        'lblBAVEMUNI
        '
        Me.lblBAVEMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblBAVEMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBAVEMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBAVEMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblBAVEMUNI.Location = New System.Drawing.Point(454, 51)
        Me.lblBAVEMUNI.Name = "lblBAVEMUNI"
        Me.lblBAVEMUNI.Size = New System.Drawing.Size(120, 20)
        Me.lblBAVEMUNI.TabIndex = 50
        '
        'cboBAVEMUNI
        '
        Me.cboBAVEMUNI.AccessibleDescription = "Municipio"
        Me.cboBAVEMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboBAVEMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBAVEMUNI.Enabled = False
        Me.cboBAVEMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBAVEMUNI.FormattingEnabled = True
        Me.cboBAVEMUNI.Location = New System.Drawing.Point(153, 49)
        Me.cboBAVEMUNI.Name = "cboBAVEMUNI"
        Me.cboBAVEMUNI.Size = New System.Drawing.Size(295, 22)
        Me.cboBAVEMUNI.TabIndex = 2
        '
        'lblMUNICIPIO
        '
        Me.lblMUNICIPIO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMUNICIPIO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUNICIPIO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUNICIPIO.ForeColor = System.Drawing.Color.Black
        Me.lblMUNICIPIO.Location = New System.Drawing.Point(19, 51)
        Me.lblMUNICIPIO.Name = "lblMUNICIPIO"
        Me.lblMUNICIPIO.Size = New System.Drawing.Size(130, 20)
        Me.lblMUNICIPIO.TabIndex = 49
        Me.lblMUNICIPIO.Text = "Municipio"
        '
        'txtBAVEDESC
        '
        Me.txtBAVEDESC.AccessibleDescription = "Descripción"
        Me.txtBAVEDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtBAVEDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBAVEDESC.Location = New System.Drawing.Point(153, 143)
        Me.txtBAVEDESC.MaxLength = 50
        Me.txtBAVEDESC.Name = "txtBAVEDESC"
        Me.txtBAVEDESC.Size = New System.Drawing.Size(421, 20)
        Me.txtBAVEDESC.TabIndex = 6
        '
        'txtBAVECODI
        '
        Me.txtBAVECODI.AccessibleDescription = "Barrio - Vereda"
        Me.txtBAVECODI.BackColor = System.Drawing.SystemColors.Window
        Me.txtBAVECODI.Enabled = False
        Me.txtBAVECODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBAVECODI.Location = New System.Drawing.Point(153, 120)
        Me.txtBAVECODI.MaxLength = 9
        Me.txtBAVECODI.Name = "txtBAVECODI"
        Me.txtBAVECODI.Size = New System.Drawing.Size(112, 20)
        Me.txtBAVECODI.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 20)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Descripción"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(19, 120)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(130, 20)
        Me.lblCodigo.TabIndex = 37
        Me.lblCodigo.Text = "Barrio - Vereda"
        '
        'frm_modificar_BARRVERE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 309)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraBARRVERE)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(629, 345)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(629, 345)
        Me.Name = "frm_modificar_BARRVERE"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraBARRVERE.ResumeLayout(False)
        Me.fraBARRVERE.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraBARRVERE As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboBAVEESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblBAVECLSE As System.Windows.Forms.Label
    Friend WithEvents cboBAVECLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents lblBAVEDEPA As System.Windows.Forms.Label
    Friend WithEvents cboBAVEDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblBAVEMUNI As System.Windows.Forms.Label
    Friend WithEvents cboBAVEMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents txtBAVEDESC As System.Windows.Forms.TextBox
    Friend WithEvents txtBAVECODI As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblBAVECORR As System.Windows.Forms.Label
    Friend WithEvents cboBAVECORR As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
