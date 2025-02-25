<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ACERCA_DE
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents LabelProductName As System.Windows.Forms.Label
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents LabelCompanyName As System.Windows.Forms.Label
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ACERCA_DE))
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.LabelProductName = New System.Windows.Forms.Label()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.LabelCopyright = New System.Windows.Forms.Label()
        Me.LabelCompanyName = New System.Windows.Forms.Label()
        Me.TextBoxDescription = New System.Windows.Forms.TextBox()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.TableLayoutPanel.SuspendLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 2
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.0!))
        Me.TableLayoutPanel.Controls.Add(Me.LogoPictureBox, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelProductName, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelVersion, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.LabelCopyright, 1, 2)
        Me.TableLayoutPanel.Controls.Add(Me.LabelCompanyName, 1, 3)
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxDescription, 1, 4)
        Me.TableLayoutPanel.Controls.Add(Me.OKButton, 1, 5)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(9, 9)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 6
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(862, 258)
        Me.TableLayoutPanel.TabIndex = 0
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LogoPictureBox.Image = Global.SICAFI.My.Resources.Resources.Contenido
        Me.LogoPictureBox.Location = New System.Drawing.Point(3, 3)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.TableLayoutPanel.SetRowSpan(Me.LogoPictureBox, 6)
        Me.LogoPictureBox.Size = New System.Drawing.Size(278, 252)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'LabelProductName
        '
        Me.LabelProductName.BackColor = System.Drawing.Color.White
        Me.LabelProductName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelProductName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProductName.ForeColor = System.Drawing.Color.Black
        Me.LabelProductName.Location = New System.Drawing.Point(290, 0)
        Me.LabelProductName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelProductName.MaximumSize = New System.Drawing.Size(0, 20)
        Me.LabelProductName.Name = "LabelProductName"
        Me.LabelProductName.Size = New System.Drawing.Size(569, 20)
        Me.LabelProductName.TabIndex = 0
        Me.LabelProductName.Text = "Nombre del producto"
        Me.LabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelVersion
        '
        Me.LabelVersion.BackColor = System.Drawing.Color.White
        Me.LabelVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelVersion.ForeColor = System.Drawing.Color.Black
        Me.LabelVersion.Location = New System.Drawing.Point(290, 25)
        Me.LabelVersion.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelVersion.MaximumSize = New System.Drawing.Size(0, 20)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(569, 20)
        Me.LabelVersion.TabIndex = 0
        Me.LabelVersion.Text = "Versión"
        Me.LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCopyright
        '
        Me.LabelCopyright.BackColor = System.Drawing.Color.White
        Me.LabelCopyright.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelCopyright.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCopyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCopyright.ForeColor = System.Drawing.Color.Black
        Me.LabelCopyright.Location = New System.Drawing.Point(290, 50)
        Me.LabelCopyright.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelCopyright.MaximumSize = New System.Drawing.Size(0, 20)
        Me.LabelCopyright.Name = "LabelCopyright"
        Me.LabelCopyright.Size = New System.Drawing.Size(569, 20)
        Me.LabelCopyright.TabIndex = 0
        Me.LabelCopyright.Text = "Copyright"
        Me.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCompanyName
        '
        Me.LabelCompanyName.BackColor = System.Drawing.Color.White
        Me.LabelCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCompanyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCompanyName.ForeColor = System.Drawing.Color.Black
        Me.LabelCompanyName.Location = New System.Drawing.Point(290, 75)
        Me.LabelCompanyName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelCompanyName.MaximumSize = New System.Drawing.Size(0, 20)
        Me.LabelCompanyName.Name = "LabelCompanyName"
        Me.LabelCompanyName.Size = New System.Drawing.Size(569, 20)
        Me.LabelCompanyName.TabIndex = 0
        Me.LabelCompanyName.Text = "Nombre de la compañía"
        Me.LabelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.BackColor = System.Drawing.Color.White
        Me.TextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxDescription.ForeColor = System.Drawing.Color.Black
        Me.TextBoxDescription.Location = New System.Drawing.Point(290, 103)
        Me.TextBoxDescription.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.TextBoxDescription.Multiline = True
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.ReadOnly = True
        Me.TextBoxDescription.Size = New System.Drawing.Size(569, 123)
        Me.TextBoxDescription.TabIndex = 0
        Me.TextBoxDescription.TabStop = False
        Me.TextBoxDescription.Text = resources.GetString("TextBoxDescription.Text")
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.BackColor = System.Drawing.SystemColors.Control
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.Location = New System.Drawing.Point(784, 232)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "&Aceptar"
        Me.OKButton.UseVisualStyleBackColor = False
        '
        'frm_ACERCA_DE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.OKButton
        Me.ClientSize = New System.Drawing.Size(880, 276)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(5, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ACERCA_DE"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ACERCA DE ..."
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

End Class
