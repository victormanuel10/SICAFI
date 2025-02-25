<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_ZOFIACTU
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
        Me.fraZOFIACTU = New System.Windows.Forms.GroupBox()
        Me.lblZFACCLSE = New System.Windows.Forms.Label()
        Me.cboZFACCLSE = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboZFACESTA = New System.Windows.Forms.ComboBox()
        Me.lblZFACDEPA = New System.Windows.Forms.Label()
        Me.cboZFACDEPA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblZFACMUNI = New System.Windows.Forms.Label()
        Me.cboZFACMUNI = New System.Windows.Forms.ComboBox()
        Me.lblMUNICIPIO = New System.Windows.Forms.Label()
        Me.txtZFACDESC = New System.Windows.Forms.TextBox()
        Me.txtZFACCODI = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraZOFIACTU.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 193)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(588, 52)
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
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 266)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(613, 25)
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
        'fraZOFIACTU
        '
        Me.fraZOFIACTU.BackColor = System.Drawing.SystemColors.Control
        Me.fraZOFIACTU.Controls.Add(Me.lblZFACCLSE)
        Me.fraZOFIACTU.Controls.Add(Me.cboZFACCLSE)
        Me.fraZOFIACTU.Controls.Add(Me.Label5)
        Me.fraZOFIACTU.Controls.Add(Me.Label3)
        Me.fraZOFIACTU.Controls.Add(Me.cboZFACESTA)
        Me.fraZOFIACTU.Controls.Add(Me.lblZFACDEPA)
        Me.fraZOFIACTU.Controls.Add(Me.cboZFACDEPA)
        Me.fraZOFIACTU.Controls.Add(Me.Label4)
        Me.fraZOFIACTU.Controls.Add(Me.lblZFACMUNI)
        Me.fraZOFIACTU.Controls.Add(Me.cboZFACMUNI)
        Me.fraZOFIACTU.Controls.Add(Me.lblMUNICIPIO)
        Me.fraZOFIACTU.Controls.Add(Me.txtZFACDESC)
        Me.fraZOFIACTU.Controls.Add(Me.txtZFACCODI)
        Me.fraZOFIACTU.Controls.Add(Me.Label1)
        Me.fraZOFIACTU.Controls.Add(Me.lblCodigo)
        Me.fraZOFIACTU.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraZOFIACTU.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraZOFIACTU.Location = New System.Drawing.Point(12, 6)
        Me.fraZOFIACTU.Name = "fraZOFIACTU"
        Me.fraZOFIACTU.Size = New System.Drawing.Size(588, 181)
        Me.fraZOFIACTU.TabIndex = 35
        Me.fraZOFIACTU.TabStop = False
        Me.fraZOFIACTU.Text = "INSERTAR ZONA FÍSICA ACTUALIZACIÓN"
        '
        'lblZFACCLSE
        '
        Me.lblZFACCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZFACCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZFACCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZFACCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblZFACCLSE.Location = New System.Drawing.Point(450, 74)
        Me.lblZFACCLSE.Name = "lblZFACCLSE"
        Me.lblZFACCLSE.Size = New System.Drawing.Size(124, 20)
        Me.lblZFACCLSE.TabIndex = 56
        '
        'cboZFACCLSE
        '
        Me.cboZFACCLSE.AccessibleDescription = "Clase o sector"
        Me.cboZFACCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboZFACCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZFACCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZFACCLSE.FormattingEnabled = True
        Me.cboZFACCLSE.Location = New System.Drawing.Point(153, 72)
        Me.cboZFACCLSE.Name = "cboZFACCLSE"
        Me.cboZFACCLSE.Size = New System.Drawing.Size(291, 22)
        Me.cboZFACCLSE.TabIndex = 3
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
        Me.Label3.Location = New System.Drawing.Point(19, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 20)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Estado"
        '
        'cboZFACESTA
        '
        Me.cboZFACESTA.AccessibleDescription = "Estado"
        Me.cboZFACESTA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboZFACESTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZFACESTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZFACESTA.FormattingEnabled = True
        Me.cboZFACESTA.Location = New System.Drawing.Point(153, 143)
        Me.cboZFACESTA.Name = "cboZFACESTA"
        Me.cboZFACESTA.Size = New System.Drawing.Size(291, 22)
        Me.cboZFACESTA.TabIndex = 10
        '
        'lblZFACDEPA
        '
        Me.lblZFACDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZFACDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZFACDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZFACDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblZFACDEPA.Location = New System.Drawing.Point(450, 28)
        Me.lblZFACDEPA.Name = "lblZFACDEPA"
        Me.lblZFACDEPA.Size = New System.Drawing.Size(124, 20)
        Me.lblZFACDEPA.TabIndex = 52
        '
        'cboZFACDEPA
        '
        Me.cboZFACDEPA.AccessibleDescription = "Departamento"
        Me.cboZFACDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboZFACDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZFACDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZFACDEPA.FormattingEnabled = True
        Me.cboZFACDEPA.Location = New System.Drawing.Point(153, 26)
        Me.cboZFACDEPA.Name = "cboZFACDEPA"
        Me.cboZFACDEPA.Size = New System.Drawing.Size(291, 22)
        Me.cboZFACDEPA.TabIndex = 1
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
        'lblZFACMUNI
        '
        Me.lblZFACMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblZFACMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZFACMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZFACMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblZFACMUNI.Location = New System.Drawing.Point(450, 51)
        Me.lblZFACMUNI.Name = "lblZFACMUNI"
        Me.lblZFACMUNI.Size = New System.Drawing.Size(124, 20)
        Me.lblZFACMUNI.TabIndex = 50
        '
        'cboZFACMUNI
        '
        Me.cboZFACMUNI.AccessibleDescription = "Municipio"
        Me.cboZFACMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboZFACMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZFACMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboZFACMUNI.FormattingEnabled = True
        Me.cboZFACMUNI.Location = New System.Drawing.Point(153, 49)
        Me.cboZFACMUNI.Name = "cboZFACMUNI"
        Me.cboZFACMUNI.Size = New System.Drawing.Size(291, 22)
        Me.cboZFACMUNI.TabIndex = 2
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
        'txtZFACDESC
        '
        Me.txtZFACDESC.AccessibleDescription = "Descripción"
        Me.txtZFACDESC.BackColor = System.Drawing.SystemColors.Window
        Me.txtZFACDESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZFACDESC.Location = New System.Drawing.Point(153, 120)
        Me.txtZFACDESC.MaxLength = 100
        Me.txtZFACDESC.Name = "txtZFACDESC"
        Me.txtZFACDESC.Size = New System.Drawing.Size(421, 20)
        Me.txtZFACDESC.TabIndex = 5
        '
        'txtZFACCODI
        '
        Me.txtZFACCODI.AccessibleDescription = "Código"
        Me.txtZFACCODI.BackColor = System.Drawing.SystemColors.Window
        Me.txtZFACCODI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZFACCODI.Location = New System.Drawing.Point(153, 97)
        Me.txtZFACCODI.MaxLength = 9
        Me.txtZFACCODI.Name = "txtZFACCODI"
        Me.txtZFACCODI.Size = New System.Drawing.Size(112, 20)
        Me.txtZFACCODI.TabIndex = 4
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
        Me.lblCodigo.Text = "Código"
        '
        'frm_insertar_ZOFIACTU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 291)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraZOFIACTU)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(629, 327)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(629, 327)
        Me.Name = "frm_insertar_ZOFIACTU"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraZOFIACTU.ResumeLayout(False)
        Me.fraZOFIACTU.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraZOFIACTU As System.Windows.Forms.GroupBox
    Friend WithEvents lblZFACCLSE As System.Windows.Forms.Label
    Friend WithEvents cboZFACCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboZFACESTA As System.Windows.Forms.ComboBox
    Friend WithEvents lblZFACDEPA As System.Windows.Forms.Label
    Friend WithEvents cboZFACDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblZFACMUNI As System.Windows.Forms.Label
    Friend WithEvents cboZFACMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents txtZFACDESC As System.Windows.Forms.TextBox
    Friend WithEvents txtZFACCODI As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
End Class
