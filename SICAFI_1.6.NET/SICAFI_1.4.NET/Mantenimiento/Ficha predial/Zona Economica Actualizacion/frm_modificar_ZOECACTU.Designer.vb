<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificar_ZOECACTU
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
        Me.fraZOECACTU = New System.Windows.Forms.GroupBox()
        Me.txtZEACVACA = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtZEACVACO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblZEACCLSE = New System.Windows.Forms.Label()
        Me.cboZEACCLSE = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboZEACESTA = New System.Windows.Forms.ComboBox()
        Me.lblZEACDEPA = New System.Windows.Forms.Label()
        Me.cboZEACDEPA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblZEACMUNI = New System.Windows.Forms.Label()
        Me.cboZEACMUNI = New System.Windows.Forms.ComboBox()
        Me.lblMUNICIPIO = New System.Windows.Forms.Label()
        Me.txtZEACDESC = New System.Windows.Forms.TextBox()
        Me.txtZEACCODI = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraZOECACTU.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 244)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(588, 52)
        Me.GroupBox1.TabIndex = 43
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 309)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(613, 25)
        Me.strBARRESTA.TabIndex = 42
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
        'fraZOECACTU
        '
        Me.fraZOECACTU.BackColor = System.Drawing.SystemColors.Control
        Me.fraZOECACTU.Controls.Add(Me.txtZEACVACA)
        Me.fraZOECACTU.Controls.Add(Me.Label6)
        Me.fraZOECACTU.Controls.Add(Me.txtZEACVACO)
        Me.fraZOECACTU.Controls.Add(Me.Label2)
        Me.fraZOECACTU.Controls.Add(Me.lblZEACCLSE)
        Me.fraZOECACTU.Controls.Add(Me.cboZEACCLSE)
        Me.fraZOECACTU.Controls.Add(Me.Label5)
        Me.fraZOECACTU.Controls.Add(Me.Label3)
        Me.fraZOECACTU.Controls.Add(Me.cboZEACESTA)
        Me.fraZOECACTU.Controls.Add(Me.lblZEACDEPA)
        Me.fraZOECACTU.Controls.Add(Me.cboZEACDEPA)
        Me.fraZOECACTU.Controls.Add(Me.Label4)
        Me.fraZOECACTU.Controls.Add(Me.lblZEACMUNI)
        Me.fraZOECACTU.Controls.Add(Me.cboZEACMUNI)
        Me.fraZOECACTU.Controls.Add(Me.lblMUNICIPIO)
        Me.fraZOECACTU.Controls.Add(Me.txtZEACDESC)
        Me.fraZOECACTU.Controls.Add(Me.txtZEACCODI)
        Me.fraZOECACTU.Controls.Add(Me.Label1)
        Me.fraZOECACTU.Controls.Add(Me.lblCodigo)
        Me.fraZOECACTU.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraZOECACTU.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraZOECACTU.Location = New System.Drawing.Point(12, 8)
        Me.fraZOECACTU.Name = "fraZOECACTU"
        Me.fraZOECACTU.Size = New System.Drawing.Size(588, 230)
        Me.fraZOECACTU.TabIndex = 41
        Me.fraZOECACTU.TabStop = False
        Me.fraZOECACTU.Text = "MODIFICAR ZONA ECONÓMICA ACTUALIZACIÓN"
        '
        'txtZEACVACA
        '
        Me.txtZEACVACA.AccessibleDescription = "Código"
        Me.txtZEACVACA.BackColor = System.Drawing.SystemColors.Window
        Me.txtZEACVACA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZEACVACA.Location = New System.Drawing.Point(153, 143)
        Me.txtZEACVACA.MaxLength = 12
        Me.txtZEACVACA.Name = "txtZEACVACA"
        Me.txtZEACVACA.Size = New System.Drawing.Size(134, 20)
        Me.txtZEACVACA.TabIndex = 6
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
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "Valor m2 catastral"
        '
        'txtZEACVACO
        '
        Me.txtZEACVACO.AccessibleDescription = "Código"
        Me.txtZEACVACO.BackColor = System.Drawing.SystemColors.Window
        Me.txtZEACVACO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZEACVACO.Location = New System.Drawing.Point(153, 120)
        Me.txtZEACVACO.MaxLength = 12
        Me.txtZEACVACO.Name = "txtZEACVACO"
        Me.txtZEACVACO.Size = New System.Drawing.Size(134, 20)
        Me.txtZEACVACO.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 20)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Valor m2 comercial"
        '
        'lblZEACCLSE
        '
        Me.lblZEACCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZEACCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZEACCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZEACCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblZEACCLSE.Location = New System.Drawing.Point(450, 74)
        Me.lblZEACCLSE.Name = "lblZEACCLSE"
        Me.lblZEACCLSE.Size = New System.Drawing.Size(124, 20)
        Me.lblZEACCLSE.TabIndex = 56
        '
        'cboZEACCLSE
        '
        Me.cboZEACCLSE.AccessibleDescription = "Clase o sector"
        Me.cboZEACCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboZEACCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZEACCLSE.Enabled = False
        Me.cboZEACCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZEACCLSE.FormattingEnabled = True
        Me.cboZEACCLSE.Location = New System.Drawing.Point(153, 72)
        Me.cboZEACCLSE.Name = "cboZEACCLSE"
        Me.cboZEACCLSE.Size = New System.Drawing.Size(291, 22)
        Me.cboZEACCLSE.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 20)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Clase o sector"
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
        'cboZEACESTA
        '
        Me.cboZEACESTA.AccessibleDescription = "Estado"
        Me.cboZEACESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboZEACESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZEACESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZEACESTA.FormattingEnabled = True
        Me.cboZEACESTA.Location = New System.Drawing.Point(153, 189)
        Me.cboZEACESTA.Name = "cboZEACESTA"
        Me.cboZEACESTA.Size = New System.Drawing.Size(291, 22)
        Me.cboZEACESTA.TabIndex = 8
        '
        'lblZEACDEPA
        '
        Me.lblZEACDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZEACDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZEACDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZEACDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblZEACDEPA.Location = New System.Drawing.Point(450, 28)
        Me.lblZEACDEPA.Name = "lblZEACDEPA"
        Me.lblZEACDEPA.Size = New System.Drawing.Size(124, 20)
        Me.lblZEACDEPA.TabIndex = 52
        '
        'cboZEACDEPA
        '
        Me.cboZEACDEPA.AccessibleDescription = "Departamento"
        Me.cboZEACDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboZEACDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZEACDEPA.Enabled = False
        Me.cboZEACDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZEACDEPA.FormattingEnabled = True
        Me.cboZEACDEPA.Location = New System.Drawing.Point(153, 26)
        Me.cboZEACDEPA.Name = "cboZEACDEPA"
        Me.cboZEACDEPA.Size = New System.Drawing.Size(291, 22)
        Me.cboZEACDEPA.TabIndex = 1
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
        'lblZEACMUNI
        '
        Me.lblZEACMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZEACMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZEACMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZEACMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblZEACMUNI.Location = New System.Drawing.Point(450, 51)
        Me.lblZEACMUNI.Name = "lblZEACMUNI"
        Me.lblZEACMUNI.Size = New System.Drawing.Size(124, 20)
        Me.lblZEACMUNI.TabIndex = 50
        '
        'cboZEACMUNI
        '
        Me.cboZEACMUNI.AccessibleDescription = "Municipio"
        Me.cboZEACMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboZEACMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZEACMUNI.Enabled = False
        Me.cboZEACMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZEACMUNI.FormattingEnabled = True
        Me.cboZEACMUNI.Location = New System.Drawing.Point(153, 49)
        Me.cboZEACMUNI.Name = "cboZEACMUNI"
        Me.cboZEACMUNI.Size = New System.Drawing.Size(291, 22)
        Me.cboZEACMUNI.TabIndex = 2
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
        'txtZEACDESC
        '
        Me.txtZEACDESC.AccessibleDescription = "Descripción"
        Me.txtZEACDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtZEACDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZEACDESC.Location = New System.Drawing.Point(153, 166)
        Me.txtZEACDESC.MaxLength = 100
        Me.txtZEACDESC.Name = "txtZEACDESC"
        Me.txtZEACDESC.Size = New System.Drawing.Size(421, 20)
        Me.txtZEACDESC.TabIndex = 7
        '
        'txtZEACCODI
        '
        Me.txtZEACCODI.AccessibleDescription = "Código"
        Me.txtZEACCODI.BackColor = System.Drawing.SystemColors.Window
        Me.txtZEACCODI.Enabled = False
        Me.txtZEACCODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZEACCODI.Location = New System.Drawing.Point(153, 97)
        Me.txtZEACCODI.MaxLength = 9
        Me.txtZEACCODI.Name = "txtZEACCODI"
        Me.txtZEACCODI.Size = New System.Drawing.Size(134, 20)
        Me.txtZEACCODI.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 166)
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
        Me.lblCodigo.Text = "Código"
        '
        'frm_modificar_ZOECACTU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 334)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraZOECACTU)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(629, 370)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(629, 370)
        Me.Name = "frm_modificar_ZOECACTU"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraZOECACTU.ResumeLayout(False)
        Me.fraZOECACTU.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraZOECACTU As System.Windows.Forms.GroupBox
    Friend WithEvents lblZEACCLSE As System.Windows.Forms.Label
    Friend WithEvents cboZEACCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboZEACESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblZEACDEPA As System.Windows.Forms.Label
    Friend WithEvents cboZEACDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblZEACMUNI As System.Windows.Forms.Label
    Friend WithEvents cboZEACMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents txtZEACDESC As System.Windows.Forms.TextBox
    Friend WithEvents txtZEACCODI As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtZEACVACA As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtZEACVACO As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
