<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_visor_imagen
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
        Me.pibImagenPredio = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkHabilitarZoom = New System.Windows.Forms.CheckBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.optRotarLibre = New System.Windows.Forms.RadioButton()
        Me.optRotarIzq = New System.Windows.Forms.RadioButton()
        Me.optRotarDer = New System.Windows.Forms.RadioButton()
        Me.cmdROTAR = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        CType(Me.pibImagenPredio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pibImagenPredio
        '
        Me.pibImagenPredio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pibImagenPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pibImagenPredio.Location = New System.Drawing.Point(15, 19)
        Me.pibImagenPredio.Name = "pibImagenPredio"
        Me.pibImagenPredio.Size = New System.Drawing.Size(909, 390)
        Me.pibImagenPredio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pibImagenPredio.TabIndex = 0
        Me.pibImagenPredio.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chkHabilitarZoom)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox1.Controls.Add(Me.optRotarLibre)
        Me.GroupBox1.Controls.Add(Me.optRotarIzq)
        Me.GroupBox1.Controls.Add(Me.optRotarDer)
        Me.GroupBox1.Controls.Add(Me.cmdROTAR)
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 505)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(939, 49)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'chkHabilitarZoom
        '
        Me.chkHabilitarZoom.Location = New System.Drawing.Point(498, 20)
        Me.chkHabilitarZoom.Name = "chkHabilitarZoom"
        Me.chkHabilitarZoom.Size = New System.Drawing.Size(117, 17)
        Me.chkHabilitarZoom.TabIndex = 32
        Me.chkHabilitarZoom.Text = "Habilitar (%) zoom"
        Me.chkHabilitarZoom.UseVisualStyleBackColor = True
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown1.Enabled = False
        Me.NumericUpDown1.Location = New System.Drawing.Point(621, 17)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(75, 20)
        Me.NumericUpDown1.TabIndex = 30
        Me.NumericUpDown1.Visible = False
        '
        'optRotarLibre
        '
        Me.optRotarLibre.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.optRotarLibre.AutoSize = True
        Me.optRotarLibre.Checked = True
        Me.optRotarLibre.Location = New System.Drawing.Point(254, 20)
        Me.optRotarLibre.Name = "optRotarLibre"
        Me.optRotarLibre.Size = New System.Drawing.Size(67, 17)
        Me.optRotarLibre.TabIndex = 29
        Me.optRotarLibre.TabStop = True
        Me.optRotarLibre.Text = "90° Libre"
        Me.optRotarLibre.UseVisualStyleBackColor = True
        '
        'optRotarIzq
        '
        Me.optRotarIzq.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.optRotarIzq.AutoSize = True
        Me.optRotarIzq.Location = New System.Drawing.Point(28, 20)
        Me.optRotarIzq.Name = "optRotarIzq"
        Me.optRotarIzq.Size = New System.Drawing.Size(87, 17)
        Me.optRotarIzq.TabIndex = 28
        Me.optRotarIzq.Text = "90° Izquierda"
        Me.optRotarIzq.UseVisualStyleBackColor = True
        '
        'optRotarDer
        '
        Me.optRotarDer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.optRotarDer.AutoSize = True
        Me.optRotarDer.Location = New System.Drawing.Point(144, 20)
        Me.optRotarDer.Name = "optRotarDer"
        Me.optRotarDer.Size = New System.Drawing.Size(85, 17)
        Me.optRotarDer.TabIndex = 27
        Me.optRotarDer.Text = "90° Derecha"
        Me.optRotarDer.UseVisualStyleBackColor = True
        '
        'cmdROTAR
        '
        Me.cmdROTAR.AccessibleDescription = "Ultima consulta"
        Me.cmdROTAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdROTAR.Image = Global.SICAFI.My.Resources.Resources._667
        Me.cmdROTAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdROTAR.Location = New System.Drawing.Point(348, 17)
        Me.cmdROTAR.Name = "cmdROTAR"
        Me.cmdROTAR.Size = New System.Drawing.Size(123, 23)
        Me.cmdROTAR.TabIndex = 25
        Me.cmdROTAR.Text = "&Rotar"
        Me.cmdROTAR.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Cancelar"
        Me.cmdSALIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(788, 17)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(123, 23)
        Me.cmdSALIR.TabIndex = 26
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.pibImagenPredio)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(939, 427)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "IMAGEN"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cmdImprimir)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 450)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(939, 49)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'cmdImprimir
        '
        Me.cmdImprimir.AccessibleDescription = "Imprimir"
        Me.cmdImprimir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdImprimir.Image = Global.SICAFI.My.Resources.Resources._004
        Me.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdImprimir.Location = New System.Drawing.Point(408, 16)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(123, 23)
        Me.cmdImprimir.TabIndex = 26
        Me.cmdImprimir.Text = "&Imprimir"
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'frm_visor_imagen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(963, 566)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.MinimizeBox = False
        Me.Name = "frm_visor_imagen"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pibImagenPredio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pibImagenPredio As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optRotarLibre As System.Windows.Forms.RadioButton
    Friend WithEvents optRotarIzq As System.Windows.Forms.RadioButton
    Friend WithEvents optRotarDer As System.Windows.Forms.RadioButton
    Friend WithEvents cmdROTAR As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkHabilitarZoom As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdImprimir As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
End Class
