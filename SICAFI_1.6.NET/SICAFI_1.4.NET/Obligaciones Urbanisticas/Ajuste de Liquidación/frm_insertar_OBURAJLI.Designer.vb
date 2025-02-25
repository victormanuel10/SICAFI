<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_insertar_OBURAJLI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_insertar_OBURAJLI))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOUALNUAL = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraCEDUCATA = New System.Windows.Forms.GroupBox()
        Me.txtOUALOBSE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOUALLIAJ = New System.Windows.Forms.TextBox()
        Me.txtOUALLIQU = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.fraCEDUCATA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtOUALNUAL)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(16, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(686, 48)
        Me.GroupBox1.TabIndex = 360
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(185, 20)
        Me.Label1.TabIndex = 319
        Me.Label1.Text = "Nro. Ajuste"
        '
        'txtOUALNUAL
        '
        Me.txtOUALNUAL.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtOUALNUAL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtOUALNUAL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUALNUAL.ForeColor = System.Drawing.Color.Black
        Me.txtOUALNUAL.Location = New System.Drawing.Point(205, 17)
        Me.txtOUALNUAL.Name = "txtOUALNUAL"
        Me.txtOUALNUAL.Size = New System.Drawing.Size(258, 20)
        Me.txtOUALNUAL.TabIndex = 312
        Me.txtOUALNUAL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdSALIR)
        Me.GroupBox2.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 224)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(686, 46)
        Me.GroupBox2.TabIndex = 358
        Me.GroupBox2.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = CType(resources.GetObject("cmdSALIR.Image"), System.Drawing.Image)
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(344, 14)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 18
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = CType(resources.GetObject("cmdGUARDAR.Image"), System.Drawing.Image)
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(237, 14)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 17
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 287)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(720, 25)
        Me.strBARRESTA.TabIndex = 359
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
        'fraCEDUCATA
        '
        Me.fraCEDUCATA.Controls.Add(Me.txtOUALOBSE)
        Me.fraCEDUCATA.Controls.Add(Me.Label2)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUALLIAJ)
        Me.fraCEDUCATA.Controls.Add(Me.txtOUALLIQU)
        Me.fraCEDUCATA.Controls.Add(Me.Label10)
        Me.fraCEDUCATA.Controls.Add(Me.Label11)
        Me.fraCEDUCATA.Location = New System.Drawing.Point(16, 74)
        Me.fraCEDUCATA.Name = "fraCEDUCATA"
        Me.fraCEDUCATA.Size = New System.Drawing.Size(686, 144)
        Me.fraCEDUCATA.TabIndex = 357
        Me.fraCEDUCATA.TabStop = False
        Me.fraCEDUCATA.Text = "INSERTAR AJUSTE DE LIQUIDACIÓN"
        '
        'txtOUALOBSE
        '
        Me.txtOUALOBSE.AccessibleDescription = "Observación"
        Me.txtOUALOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUALOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUALOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUALOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtOUALOBSE.Location = New System.Drawing.Point(205, 72)
        Me.txtOUALOBSE.MaxLength = 2000
        Me.txtOUALOBSE.Multiline = True
        Me.txtOUALOBSE.Name = "txtOUALOBSE"
        Me.txtOUALOBSE.Size = New System.Drawing.Size(465, 56)
        Me.txtOUALOBSE.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(185, 20)
        Me.Label2.TabIndex = 429
        Me.Label2.Text = "Observación"
        '
        'txtOUALLIAJ
        '
        Me.txtOUALLIAJ.AccessibleDescription = "Liquidación ajustada"
        Me.txtOUALLIAJ.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUALLIAJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUALLIAJ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUALLIAJ.ForeColor = System.Drawing.Color.Black
        Me.txtOUALLIAJ.Location = New System.Drawing.Point(205, 49)
        Me.txtOUALLIAJ.MaxLength = 12
        Me.txtOUALLIAJ.Name = "txtOUALLIAJ"
        Me.txtOUALLIAJ.Size = New System.Drawing.Size(258, 20)
        Me.txtOUALLIAJ.TabIndex = 1
        '
        'txtOUALLIQU
        '
        Me.txtOUALLIQU.AccessibleDescription = "Liquidación formulada"
        Me.txtOUALLIQU.BackColor = System.Drawing.SystemColors.Window
        Me.txtOUALLIQU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOUALLIQU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOUALLIQU.ForeColor = System.Drawing.Color.Black
        Me.txtOUALLIQU.Location = New System.Drawing.Point(205, 26)
        Me.txtOUALLIQU.MaxLength = 12
        Me.txtOUALLIQU.Name = "txtOUALLIQU"
        Me.txtOUALLIQU.ReadOnly = True
        Me.txtOUALLIQU.Size = New System.Drawing.Size(258, 20)
        Me.txtOUALLIQU.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(16, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(185, 20)
        Me.Label10.TabIndex = 428
        Me.Label10.Text = "Liquidación nueva"
        '
        'Label11
        '
        Me.Label11.AccessibleDescription = ""
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(16, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(185, 20)
        Me.Label11.TabIndex = 427
        Me.Label11.Text = "Liquidación actual"
        '
        'frm_insertar_OBURAJLI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 312)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraCEDUCATA)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_insertar_OBURAJLI"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar registro"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraCEDUCATA.ResumeLayout(False)
        Me.fraCEDUCATA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOUALNUAL As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraCEDUCATA As System.Windows.Forms.GroupBox
    Friend WithEvents txtOUALLIAJ As System.Windows.Forms.TextBox
    Friend WithEvents txtOUALLIQU As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtOUALOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
