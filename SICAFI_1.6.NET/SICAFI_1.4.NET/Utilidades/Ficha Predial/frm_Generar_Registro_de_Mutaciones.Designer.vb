<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Generar_Registro_de_Mutaciones
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Generar_Registro_de_Mutaciones))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BindingSource_REGIMUTA_1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigator_REGIMUTA_1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.dgvREGIMUTA_1 = New System.Windows.Forms.DataGridView()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblRutaArchivo = New System.Windows.Forms.Label()
        Me.cmdCarpetaDestino = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cmdEjecutar = New System.Windows.Forms.Button()
        Me.pbPROCESO = New System.Windows.Forms.ProgressBar()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdLimpiar = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cmdReconsultar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.BindingSource_REGIMUTA_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator_REGIMUTA_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator_REGIMUTA_1.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        CType(Me.dgvREGIMUTA_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BindingNavigator_REGIMUTA_1
        '
        Me.BindingNavigator_REGIMUTA_1.AddNewItem = Nothing
        Me.BindingNavigator_REGIMUTA_1.CountItem = Me.ToolStripLabel1
        Me.BindingNavigator_REGIMUTA_1.DeleteItem = Nothing
        Me.BindingNavigator_REGIMUTA_1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator19, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator20, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator21, Me.cmdReconsultar, Me.ToolStripSeparator1})
        Me.BindingNavigator_REGIMUTA_1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator_REGIMUTA_1.MoveFirstItem = Me.ToolStripButton1
        Me.BindingNavigator_REGIMUTA_1.MoveLastItem = Me.ToolStripButton4
        Me.BindingNavigator_REGIMUTA_1.MoveNextItem = Me.ToolStripButton3
        Me.BindingNavigator_REGIMUTA_1.MovePreviousItem = Me.ToolStripButton2
        Me.BindingNavigator_REGIMUTA_1.Name = "BindingNavigator_REGIMUTA_1"
        Me.BindingNavigator_REGIMUTA_1.PositionItem = Me.ToolStripTextBox1
        Me.BindingNavigator_REGIMUTA_1.Size = New System.Drawing.Size(963, 25)
        Me.BindingNavigator_REGIMUTA_1.TabIndex = 358
        Me.BindingNavigator_REGIMUTA_1.Text = "BindingNavigator1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel1.Text = "de {0}"
        Me.ToolStripLabel1.ToolTipText = "Número total de elementos"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Mover primero"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Mover anterior"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.AccessibleName = "Posición"
        Me.ToolStripTextBox1.AutoSize = False
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox1.Text = "0"
        Me.ToolStripTextBox1.ToolTipText = "Posición actual"
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Mover siguiente"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Mover último"
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(6, 25)
        '
        'GroupBox11
        '
        Me.GroupBox11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox11.Controls.Add(Me.dgvREGIMUTA_1)
        Me.GroupBox11.ForeColor = System.Drawing.Color.Black
        Me.GroupBox11.Location = New System.Drawing.Point(13, 38)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(933, 276)
        Me.GroupBox11.TabIndex = 357
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "REGISTRO DE MUTACIONES"
        '
        'dgvREGIMUTA_1
        '
        Me.dgvREGIMUTA_1.AccessibleDescription = "Registro mutaciones"
        Me.dgvREGIMUTA_1.AllowUserToAddRows = False
        Me.dgvREGIMUTA_1.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvREGIMUTA_1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvREGIMUTA_1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvREGIMUTA_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvREGIMUTA_1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvREGIMUTA_1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvREGIMUTA_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvREGIMUTA_1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvREGIMUTA_1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvREGIMUTA_1.ColumnHeadersHeight = 40
        Me.dgvREGIMUTA_1.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvREGIMUTA_1.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvREGIMUTA_1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvREGIMUTA_1.Location = New System.Drawing.Point(15, 19)
        Me.dgvREGIMUTA_1.Name = "dgvREGIMUTA_1"
        Me.dgvREGIMUTA_1.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvREGIMUTA_1.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvREGIMUTA_1.RowHeadersVisible = False
        Me.dgvREGIMUTA_1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvREGIMUTA_1.ShowCellToolTips = False
        Me.dgvREGIMUTA_1.Size = New System.Drawing.Size(902, 239)
        Me.dgvREGIMUTA_1.StandardTab = True
        Me.dgvREGIMUTA_1.TabIndex = 324
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 486)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(963, 25)
        Me.strBARRESTA.TabIndex = 356
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
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Controls.Add(Me.lblRutaArchivo)
        Me.GroupBox4.Controls.Add(Me.cmdCarpetaDestino)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(13, 320)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(933, 52)
        Me.GroupBox4.TabIndex = 359
        Me.GroupBox4.TabStop = False
        '
        'lblRutaArchivo
        '
        Me.lblRutaArchivo.AccessibleName = "Ruta archivo"
        Me.lblRutaArchivo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRutaArchivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRutaArchivo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRutaArchivo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutaArchivo.ForeColor = System.Drawing.Color.Black
        Me.lblRutaArchivo.Location = New System.Drawing.Point(156, 16)
        Me.lblRutaArchivo.Name = "lblRutaArchivo"
        Me.lblRutaArchivo.Size = New System.Drawing.Size(761, 20)
        Me.lblRutaArchivo.TabIndex = 229
        '
        'cmdCarpetaDestino
        '
        Me.cmdCarpetaDestino.AccessibleDescription = "Ruta archivo"
        Me.cmdCarpetaDestino.AccessibleName = ""
        Me.cmdCarpetaDestino.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCarpetaDestino.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCarpetaDestino.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCarpetaDestino.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdCarpetaDestino.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCarpetaDestino.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCarpetaDestino.Location = New System.Drawing.Point(15, 18)
        Me.cmdCarpetaDestino.Name = "cmdCarpetaDestino"
        Me.cmdCarpetaDestino.Size = New System.Drawing.Size(123, 23)
        Me.cmdCarpetaDestino.TabIndex = 1
        Me.cmdCarpetaDestino.Text = "&Carpeta"
        Me.cmdCarpetaDestino.UseVisualStyleBackColor = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox6.Controls.Add(Me.cmdEjecutar)
        Me.GroupBox6.Controls.Add(Me.pbPROCESO)
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(13, 378)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(933, 47)
        Me.GroupBox6.TabIndex = 360
        Me.GroupBox6.TabStop = False
        '
        'cmdEjecutar
        '
        Me.cmdEjecutar.AccessibleDescription = "Ejecutar"
        Me.cmdEjecutar.Enabled = False
        Me.cmdEjecutar.Image = Global.SICAFI.My.Resources.Resources._210
        Me.cmdEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEjecutar.Location = New System.Drawing.Point(15, 15)
        Me.cmdEjecutar.Name = "cmdEjecutar"
        Me.cmdEjecutar.Size = New System.Drawing.Size(123, 23)
        Me.cmdEjecutar.TabIndex = 25
        Me.cmdEjecutar.Text = "&Ejecutar"
        Me.cmdEjecutar.UseVisualStyleBackColor = True
        '
        'pbPROCESO
        '
        Me.pbPROCESO.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pbPROCESO.Location = New System.Drawing.Point(156, 19)
        Me.pbPROCESO.Name = "pbPROCESO"
        Me.pbPROCESO.Size = New System.Drawing.Size(761, 17)
        Me.pbPROCESO.TabIndex = 24
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cmdLimpiar)
        Me.GroupBox3.Controls.Add(Me.cmdSalir)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 426)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(933, 47)
        Me.GroupBox3.TabIndex = 361
        Me.GroupBox3.TabStop = False
        '
        'cmdLimpiar
        '
        Me.cmdLimpiar.AccessibleDescription = "Limpiar campo"
        Me.cmdLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLimpiar.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLimpiar.Location = New System.Drawing.Point(15, 15)
        Me.cmdLimpiar.Name = "cmdLimpiar"
        Me.cmdLimpiar.Size = New System.Drawing.Size(123, 23)
        Me.cmdLimpiar.TabIndex = 1
        Me.cmdLimpiar.Text = "&Limpiar campos"
        Me.cmdLimpiar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.AccessibleDescription = "Salir"
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(794, 15)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(123, 23)
        Me.cmdSalir.TabIndex = 2
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'cmdReconsultar
        '
        Me.cmdReconsultar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdReconsultar.Image = Global.SICAFI.My.Resources.Resources._096
        Me.cmdReconsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdReconsultar.Name = "cmdReconsultar"
        Me.cmdReconsultar.Size = New System.Drawing.Size(23, 22)
        Me.cmdReconsultar.Text = "ToolStripButton5"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'frm_Generar_Registro_de_Mutaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(963, 511)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.BindingNavigator_REGIMUTA_1)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_Generar_Registro_de_Mutaciones"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "GENERAR REGISTRO DE MUTACIONES"
        CType(Me.BindingSource_REGIMUTA_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator_REGIMUTA_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator_REGIMUTA_1.ResumeLayout(False)
        Me.BindingNavigator_REGIMUTA_1.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        CType(Me.dgvREGIMUTA_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BindingSource_REGIMUTA_1 As System.Windows.Forms.BindingSource
    Friend WithEvents BindingNavigator_REGIMUTA_1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator20 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvREGIMUTA_1 As System.Windows.Forms.DataGridView
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRutaArchivo As System.Windows.Forms.Label
    Friend WithEvents cmdCarpetaDestino As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents pbPROCESO As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLimpiar As System.Windows.Forms.Button
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents cmdEjecutar As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents cmdReconsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
