<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_VIGEACTU
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
        Me.fraVIGEACTU = New System.Windows.Forms.GroupBox()
        Me.rbdVIACCONS = New System.Windows.Forms.RadioButton()
        Me.rbdVIACACTU = New System.Windows.Forms.RadioButton()
        Me.lblVIACVIAC = New System.Windows.Forms.Label()
        Me.cboVIACVIAC = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboVIACESTA = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtVIACPOIN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblVIACCLSE = New System.Windows.Forms.Label()
        Me.cboVIACCLSE = New System.Windows.Forms.ComboBox()
        Me.lblClaseosector = New System.Windows.Forms.Label()
        Me.lblVIACDEPA = New System.Windows.Forms.Label()
        Me.cboVIACDEPA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblVIACMUNI = New System.Windows.Forms.Label()
        Me.cboVIACMUNI = New System.Windows.Forms.ComboBox()
        Me.lblMUNICIPIO = New System.Windows.Forms.Label()
        Me.txtVIACDESC = New System.Windows.Forms.TextBox()
        Me.txtVIACRESO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraVIGEACTU.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 231)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(588, 52)
        Me.GroupBox1.TabIndex = 34
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 297)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(613, 25)
        Me.strBARRESTA.TabIndex = 33
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
        'fraVIGEACTU
        '
        Me.fraVIGEACTU.BackColor = System.Drawing.SystemColors.Control
        Me.fraVIGEACTU.Controls.Add(Me.rbdVIACCONS)
        Me.fraVIGEACTU.Controls.Add(Me.rbdVIACACTU)
        Me.fraVIGEACTU.Controls.Add(Me.lblVIACVIAC)
        Me.fraVIGEACTU.Controls.Add(Me.cboVIACVIAC)
        Me.fraVIGEACTU.Controls.Add(Me.Label3)
        Me.fraVIGEACTU.Controls.Add(Me.cboVIACESTA)
        Me.fraVIGEACTU.Controls.Add(Me.Label6)
        Me.fraVIGEACTU.Controls.Add(Me.txtVIACPOIN)
        Me.fraVIGEACTU.Controls.Add(Me.Label2)
        Me.fraVIGEACTU.Controls.Add(Me.lblVIACCLSE)
        Me.fraVIGEACTU.Controls.Add(Me.cboVIACCLSE)
        Me.fraVIGEACTU.Controls.Add(Me.lblClaseosector)
        Me.fraVIGEACTU.Controls.Add(Me.lblVIACDEPA)
        Me.fraVIGEACTU.Controls.Add(Me.cboVIACDEPA)
        Me.fraVIGEACTU.Controls.Add(Me.Label4)
        Me.fraVIGEACTU.Controls.Add(Me.lblVIACMUNI)
        Me.fraVIGEACTU.Controls.Add(Me.cboVIACMUNI)
        Me.fraVIGEACTU.Controls.Add(Me.lblMUNICIPIO)
        Me.fraVIGEACTU.Controls.Add(Me.txtVIACDESC)
        Me.fraVIGEACTU.Controls.Add(Me.txtVIACRESO)
        Me.fraVIGEACTU.Controls.Add(Me.Label1)
        Me.fraVIGEACTU.Controls.Add(Me.lblCodigo)
        Me.fraVIGEACTU.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraVIGEACTU.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraVIGEACTU.Location = New System.Drawing.Point(12, 2)
        Me.fraVIGEACTU.Name = "fraVIGEACTU"
        Me.fraVIGEACTU.Size = New System.Drawing.Size(588, 225)
        Me.fraVIGEACTU.TabIndex = 32
        Me.fraVIGEACTU.TabStop = False
        Me.fraVIGEACTU.Text = "MODIFICAR PERIODO DE ACTUALIZACIÓN"
        '
        'rbdVIACCONS
        '
        Me.rbdVIACCONS.AutoSize = True
        Me.rbdVIACCONS.Location = New System.Drawing.Point(417, 168)
        Me.rbdVIACCONS.Name = "rbdVIACCONS"
        Me.rbdVIACCONS.Size = New System.Drawing.Size(101, 19)
        Me.rbdVIACCONS.TabIndex = 9
        Me.rbdVIACCONS.Text = "Conservación"
        Me.rbdVIACCONS.UseVisualStyleBackColor = True
        '
        'rbdVIACACTU
        '
        Me.rbdVIACACTU.AutoSize = True
        Me.rbdVIACACTU.Checked = True
        Me.rbdVIACACTU.Location = New System.Drawing.Point(315, 168)
        Me.rbdVIACACTU.Name = "rbdVIACACTU"
        Me.rbdVIACACTU.Size = New System.Drawing.Size(96, 19)
        Me.rbdVIACACTU.TabIndex = 8
        Me.rbdVIACACTU.TabStop = True
        Me.rbdVIACACTU.Text = "Actualización"
        Me.rbdVIACACTU.UseVisualStyleBackColor = True
        '
        'lblVIACVIAC
        '
        Me.lblVIACVIAC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblVIACVIAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVIACVIAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVIACVIAC.ForeColor = System.Drawing.Color.Black
        Me.lblVIACVIAC.Location = New System.Drawing.Point(454, 143)
        Me.lblVIACVIAC.Name = "lblVIACVIAC"
        Me.lblVIACVIAC.Size = New System.Drawing.Size(120, 20)
        Me.lblVIACVIAC.TabIndex = 63
        '
        'cboVIACVIAC
        '
        Me.cboVIACVIAC.AccessibleDescription = "Vigencia actualización"
        Me.cboVIACVIAC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboVIACVIAC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVIACVIAC.Enabled = False
        Me.cboVIACVIAC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVIACVIAC.FormattingEnabled = True
        Me.cboVIACVIAC.Location = New System.Drawing.Point(153, 141)
        Me.cboVIACVIAC.Name = "cboVIACVIAC"
        Me.cboVIACVIAC.Size = New System.Drawing.Size(295, 22)
        Me.cboVIACVIAC.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 189)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'cboVIACESTA
        '
        Me.cboVIACESTA.AccessibleDescription = "Estado"
        Me.cboVIACESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboVIACESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVIACESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVIACESTA.FormattingEnabled = True
        Me.cboVIACESTA.Location = New System.Drawing.Point(153, 189)
        Me.cboVIACESTA.Name = "cboVIACESTA"
        Me.cboVIACESTA.Size = New System.Drawing.Size(295, 22)
        Me.cboVIACESTA.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(19, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 20)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "Vigencia actualización"
        '
        'txtVIACPOIN
        '
        Me.txtVIACPOIN.AccessibleDescription = "% de incremento"
        Me.txtVIACPOIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtVIACPOIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVIACPOIN.Location = New System.Drawing.Point(153, 166)
        Me.txtVIACPOIN.MaxLength = 5
        Me.txtVIACPOIN.Name = "txtVIACPOIN"
        Me.txtVIACPOIN.Size = New System.Drawing.Size(112, 20)
        Me.txtVIACPOIN.TabIndex = 7
        Me.txtVIACPOIN.Text = "1.000"
        Me.txtVIACPOIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 20)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "(%) de incremento"
        '
        'lblVIACCLSE
        '
        Me.lblVIACCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblVIACCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVIACCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVIACCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblVIACCLSE.Location = New System.Drawing.Point(454, 74)
        Me.lblVIACCLSE.Name = "lblVIACCLSE"
        Me.lblVIACCLSE.Size = New System.Drawing.Size(120, 20)
        Me.lblVIACCLSE.TabIndex = 57
        '
        'cboVIACCLSE
        '
        Me.cboVIACCLSE.AccessibleDescription = "Clase o sector"
        Me.cboVIACCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboVIACCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVIACCLSE.Enabled = False
        Me.cboVIACCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVIACCLSE.FormattingEnabled = True
        Me.cboVIACCLSE.Location = New System.Drawing.Point(153, 72)
        Me.cboVIACCLSE.Name = "cboVIACCLSE"
        Me.cboVIACCLSE.Size = New System.Drawing.Size(295, 22)
        Me.cboVIACCLSE.TabIndex = 3
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
        'lblVIACDEPA
        '
        Me.lblVIACDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblVIACDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVIACDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVIACDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblVIACDEPA.Location = New System.Drawing.Point(454, 28)
        Me.lblVIACDEPA.Name = "lblVIACDEPA"
        Me.lblVIACDEPA.Size = New System.Drawing.Size(120, 20)
        Me.lblVIACDEPA.TabIndex = 52
        '
        'cboVIACDEPA
        '
        Me.cboVIACDEPA.AccessibleDescription = "Departamento"
        Me.cboVIACDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboVIACDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVIACDEPA.Enabled = False
        Me.cboVIACDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVIACDEPA.FormattingEnabled = True
        Me.cboVIACDEPA.Location = New System.Drawing.Point(153, 26)
        Me.cboVIACDEPA.Name = "cboVIACDEPA"
        Me.cboVIACDEPA.Size = New System.Drawing.Size(295, 22)
        Me.cboVIACDEPA.TabIndex = 1
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
        'lblVIACMUNI
        '
        Me.lblVIACMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblVIACMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVIACMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVIACMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblVIACMUNI.Location = New System.Drawing.Point(454, 51)
        Me.lblVIACMUNI.Name = "lblVIACMUNI"
        Me.lblVIACMUNI.Size = New System.Drawing.Size(120, 20)
        Me.lblVIACMUNI.TabIndex = 50
        '
        'cboVIACMUNI
        '
        Me.cboVIACMUNI.AccessibleDescription = "Municipio"
        Me.cboVIACMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboVIACMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVIACMUNI.Enabled = False
        Me.cboVIACMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVIACMUNI.FormattingEnabled = True
        Me.cboVIACMUNI.Location = New System.Drawing.Point(153, 49)
        Me.cboVIACMUNI.Name = "cboVIACMUNI"
        Me.cboVIACMUNI.Size = New System.Drawing.Size(295, 22)
        Me.cboVIACMUNI.TabIndex = 2
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
        'txtVIACDESC
        '
        Me.txtVIACDESC.AccessibleDescription = "Descripción"
        Me.txtVIACDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtVIACDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVIACDESC.Location = New System.Drawing.Point(153, 120)
        Me.txtVIACDESC.MaxLength = 50
        Me.txtVIACDESC.Name = "txtVIACDESC"
        Me.txtVIACDESC.Size = New System.Drawing.Size(421, 20)
        Me.txtVIACDESC.TabIndex = 5
        '
        'txtVIACRESO
        '
        Me.txtVIACRESO.AccessibleDescription = "Resolución"
        Me.txtVIACRESO.BackColor = System.Drawing.SystemColors.Window
        Me.txtVIACRESO.Enabled = False
        Me.txtVIACRESO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVIACRESO.Location = New System.Drawing.Point(153, 97)
        Me.txtVIACRESO.MaxLength = 9
        Me.txtVIACRESO.Name = "txtVIACRESO"
        Me.txtVIACRESO.Size = New System.Drawing.Size(112, 20)
        Me.txtVIACRESO.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 120)
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
        Me.lblCodigo.Location = New System.Drawing.Point(19, 97)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(130, 20)
        Me.lblCodigo.TabIndex = 37
        Me.lblCodigo.Text = "Resolución"
        '
        'frm_modificar_VIGEACTU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 322)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraVIGEACTU)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(629, 358)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(629, 358)
        Me.Name = "frm_modificar_VIGEACTU"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraVIGEACTU.ResumeLayout(False)
        Me.fraVIGEACTU.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraVIGEACTU As System.Windows.Forms.GroupBox
    Friend WithEvents rbdVIACCONS As System.Windows.Forms.RadioButton
    Friend WithEvents rbdVIACACTU As System.Windows.Forms.RadioButton
    Friend WithEvents lblVIACVIAC As System.Windows.Forms.Label
    Friend WithEvents cboVIACVIAC As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboVIACESTA As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtVIACPOIN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblVIACCLSE As System.Windows.Forms.Label
    Friend WithEvents cboVIACCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaseosector As System.Windows.Forms.Label
    Friend WithEvents lblVIACDEPA As System.Windows.Forms.Label
    Friend WithEvents cboVIACDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblVIACMUNI As System.Windows.Forms.Label
    Friend WithEvents cboVIACMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents txtVIACDESC As System.Windows.Forms.TextBox
    Friend WithEvents txtVIACRESO As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
End Class
