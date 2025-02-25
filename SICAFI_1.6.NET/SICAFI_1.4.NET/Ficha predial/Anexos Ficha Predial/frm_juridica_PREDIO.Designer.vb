<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_juridica_PREDIO
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
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fraUSUAOBSE = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtJURIARTE = New System.Windows.Forms.TextBox()
        Me.chkJURIPLPR = New System.Windows.Forms.CheckBox()
        Me.chkJURIFATR = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtJURIOBSE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtJURIADEO = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtJURIFOAB = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtJURITOAB = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtJURIMAAB = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtJURIMASE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtJUDIFOLI = New System.Windows.Forms.TextBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.strBARRESTA.SuspendLayout()
        Me.fraUSUAOBSE.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 359)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(735, 25)
        Me.strBARRESTA.TabIndex = 35
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
        'fraUSUAOBSE
        '
        Me.fraUSUAOBSE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraUSUAOBSE.Controls.Add(Me.Label5)
        Me.fraUSUAOBSE.Controls.Add(Me.txtJURIARTE)
        Me.fraUSUAOBSE.Controls.Add(Me.chkJURIPLPR)
        Me.fraUSUAOBSE.Controls.Add(Me.chkJURIFATR)
        Me.fraUSUAOBSE.Controls.Add(Me.Label9)
        Me.fraUSUAOBSE.Controls.Add(Me.txtJURIOBSE)
        Me.fraUSUAOBSE.Controls.Add(Me.Label6)
        Me.fraUSUAOBSE.Controls.Add(Me.txtJURIADEO)
        Me.fraUSUAOBSE.Controls.Add(Me.Label8)
        Me.fraUSUAOBSE.Controls.Add(Me.txtJURIFOAB)
        Me.fraUSUAOBSE.Controls.Add(Me.Label2)
        Me.fraUSUAOBSE.Controls.Add(Me.txtJURITOAB)
        Me.fraUSUAOBSE.Controls.Add(Me.Label4)
        Me.fraUSUAOBSE.Controls.Add(Me.txtJURIMAAB)
        Me.fraUSUAOBSE.Controls.Add(Me.Label1)
        Me.fraUSUAOBSE.Controls.Add(Me.txtJURIMASE)
        Me.fraUSUAOBSE.Controls.Add(Me.Label3)
        Me.fraUSUAOBSE.Controls.Add(Me.txtJUDIFOLI)
        Me.fraUSUAOBSE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraUSUAOBSE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraUSUAOBSE.Location = New System.Drawing.Point(12, 5)
        Me.fraUSUAOBSE.Name = "fraUSUAOBSE"
        Me.fraUSUAOBSE.Size = New System.Drawing.Size(711, 270)
        Me.fraUSUAOBSE.TabIndex = 1
        Me.fraUSUAOBSE.TabStop = False
        Me.fraUSUAOBSE.Text = "INVESTIGACIÓN JURIDICA"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(16, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(168, 20)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Area según escritura"
        '
        'txtJURIARTE
        '
        Me.txtJURIARTE.AccessibleDescription = "Area de terreno"
        Me.txtJURIARTE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJURIARTE.BackColor = System.Drawing.SystemColors.Window
        Me.txtJURIARTE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJURIARTE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJURIARTE.ForeColor = System.Drawing.Color.Black
        Me.txtJURIARTE.Location = New System.Drawing.Point(188, 142)
        Me.txtJURIARTE.MaxLength = 100
        Me.txtJURIARTE.Name = "txtJURIARTE"
        Me.txtJURIARTE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtJURIARTE.Size = New System.Drawing.Size(165, 20)
        Me.txtJURIARTE.TabIndex = 6
        '
        'chkJURIPLPR
        '
        Me.chkJURIPLPR.AccessibleDescription = "Plano protocolizado"
        Me.chkJURIPLPR.AutoSize = True
        Me.chkJURIPLPR.Location = New System.Drawing.Point(16, 210)
        Me.chkJURIPLPR.Name = "chkJURIPLPR"
        Me.chkJURIPLPR.Size = New System.Drawing.Size(134, 19)
        Me.chkJURIPLPR.TabIndex = 9
        Me.chkJURIPLPR.Text = "Plano protocolizado"
        Me.chkJURIPLPR.UseVisualStyleBackColor = True
        '
        'chkJURIFATR
        '
        Me.chkJURIFATR.AccessibleDescription = "Falsa tradición"
        Me.chkJURIFATR.AutoSize = True
        Me.chkJURIFATR.Location = New System.Drawing.Point(16, 165)
        Me.chkJURIFATR.Name = "chkJURIFATR"
        Me.chkJURIFATR.Size = New System.Drawing.Size(107, 19)
        Me.chkJURIFATR.TabIndex = 7
        Me.chkJURIFATR.Text = "Falsa tradición"
        Me.chkJURIFATR.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(16, 233)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(168, 20)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "Observaciones"
        '
        'txtJURIOBSE
        '
        Me.txtJURIOBSE.AccessibleDescription = "Observaciones"
        Me.txtJURIOBSE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJURIOBSE.BackColor = System.Drawing.SystemColors.Window
        Me.txtJURIOBSE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJURIOBSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJURIOBSE.ForeColor = System.Drawing.Color.Black
        Me.txtJURIOBSE.Location = New System.Drawing.Point(188, 233)
        Me.txtJURIOBSE.MaxLength = 1000
        Me.txtJURIOBSE.Name = "txtJURIOBSE"
        Me.txtJURIOBSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtJURIOBSE.Size = New System.Drawing.Size(504, 20)
        Me.txtJURIOBSE.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(16, 187)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 20)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Adju. de entidades oficiales"
        '
        'txtJURIADEO
        '
        Me.txtJURIADEO.AccessibleDescription = "Adjudicación"
        Me.txtJURIADEO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJURIADEO.BackColor = System.Drawing.SystemColors.Window
        Me.txtJURIADEO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJURIADEO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJURIADEO.ForeColor = System.Drawing.Color.Black
        Me.txtJURIADEO.Location = New System.Drawing.Point(188, 187)
        Me.txtJURIADEO.MaxLength = 100
        Me.txtJURIADEO.Name = "txtJURIADEO"
        Me.txtJURIADEO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtJURIADEO.Size = New System.Drawing.Size(504, 20)
        Me.txtJURIADEO.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(16, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(168, 20)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "Folio abierto"
        '
        'txtJURIFOAB
        '
        Me.txtJURIFOAB.AccessibleDescription = "Observaciones"
        Me.txtJURIFOAB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJURIFOAB.BackColor = System.Drawing.SystemColors.Window
        Me.txtJURIFOAB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJURIFOAB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJURIFOAB.ForeColor = System.Drawing.Color.Black
        Me.txtJURIFOAB.Location = New System.Drawing.Point(188, 119)
        Me.txtJURIFOAB.MaxLength = 100
        Me.txtJURIFOAB.Name = "txtJURIFOAB"
        Me.txtJURIFOAB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtJURIFOAB.Size = New System.Drawing.Size(165, 20)
        Me.txtJURIFOAB.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 20)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Tomo abierto "
        '
        'txtJURITOAB
        '
        Me.txtJURITOAB.AccessibleDescription = "Tomo abierto"
        Me.txtJURITOAB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJURITOAB.BackColor = System.Drawing.SystemColors.Window
        Me.txtJURITOAB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJURITOAB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJURITOAB.ForeColor = System.Drawing.Color.Black
        Me.txtJURITOAB.Location = New System.Drawing.Point(188, 96)
        Me.txtJURITOAB.MaxLength = 100
        Me.txtJURITOAB.Name = "txtJURITOAB"
        Me.txtJURITOAB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtJURITOAB.Size = New System.Drawing.Size(165, 20)
        Me.txtJURITOAB.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 20)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "Matricula abierta basada en"
        '
        'txtJURIMAAB
        '
        Me.txtJURIMAAB.AccessibleDescription = "Matricula abierta"
        Me.txtJURIMAAB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJURIMAAB.BackColor = System.Drawing.SystemColors.Window
        Me.txtJURIMAAB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJURIMAAB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJURIMAAB.ForeColor = System.Drawing.Color.Black
        Me.txtJURIMAAB.Location = New System.Drawing.Point(188, 73)
        Me.txtJURIMAAB.MaxLength = 100
        Me.txtJURIMAAB.Name = "txtJURIMAAB"
        Me.txtJURIMAAB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtJURIMAAB.Size = New System.Drawing.Size(504, 20)
        Me.txtJURIMAAB.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 20)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Matricula segregada"
        '
        'txtJURIMASE
        '
        Me.txtJURIMASE.AccessibleDescription = "Matricula segregada"
        Me.txtJURIMASE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJURIMASE.BackColor = System.Drawing.SystemColors.Window
        Me.txtJURIMASE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJURIMASE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJURIMASE.ForeColor = System.Drawing.Color.Black
        Me.txtJURIMASE.Location = New System.Drawing.Point(188, 50)
        Me.txtJURIMASE.MaxLength = 100
        Me.txtJURIMASE.Name = "txtJURIMASE"
        Me.txtJURIMASE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtJURIMASE.Size = New System.Drawing.Size(504, 20)
        Me.txtJURIMASE.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 20)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Folio"
        '
        'txtJUDIFOLI
        '
        Me.txtJUDIFOLI.AccessibleDescription = "Folio"
        Me.txtJUDIFOLI.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJUDIFOLI.BackColor = System.Drawing.SystemColors.Window
        Me.txtJUDIFOLI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJUDIFOLI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJUDIFOLI.ForeColor = System.Drawing.Color.Black
        Me.txtJUDIFOLI.Location = New System.Drawing.Point(188, 27)
        Me.txtJUDIFOLI.MaxLength = 100
        Me.txtJUDIFOLI.Name = "txtJUDIFOLI"
        Me.txtJUDIFOLI.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtJUDIFOLI.Size = New System.Drawing.Size(165, 20)
        Me.txtJUDIFOLI.TabIndex = 1
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Cancelar"
        Me.cmdSALIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(359, 22)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 2
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(252, 22)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 1
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox1.Controls.Add(Me.cmdSALIR)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 283)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(711, 61)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'frm_juridica_PREDIO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 384)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.fraUSUAOBSE)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(751, 420)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(751, 420)
        Me.Name = "frm_juridica_PREDIO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JURIDICA PREDIO"
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.fraUSUAOBSE.ResumeLayout(False)
        Me.fraUSUAOBSE.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents fraUSUAOBSE As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtJUDIFOLI As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtJURIOBSE As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtJURIADEO As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtJURIFOAB As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtJURITOAB As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtJURIMAAB As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtJURIMASE As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkJURIPLPR As System.Windows.Forms.CheckBox
    Friend WithEvents chkJURIFATR As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtJURIARTE As System.Windows.Forms.TextBox
End Class
