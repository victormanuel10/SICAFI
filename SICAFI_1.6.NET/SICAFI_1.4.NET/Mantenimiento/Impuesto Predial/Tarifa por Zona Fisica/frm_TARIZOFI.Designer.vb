<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_TARIZOFI
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_TARIZOFI))
        Me.fraTarifasZonasEconomicas = New System.Windows.Forms.GroupBox()
        Me.lblTAZFVIGE = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTAZFZOAP = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTAZFZOFI = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTAZFCLSE = New System.Windows.Forms.Label()
        Me.lblclaseosector = New System.Windows.Forms.Label()
        Me.lblTAZFDEPA = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTAZFMUNI = New System.Windows.Forms.Label()
        Me.lblMUNICIPIO = New System.Windows.Forms.Label()
        Me.dgvTARIZOFI = New System.Windows.Forms.DataGridView()
        Me.BindingSource_TARIZOFI_1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BindingNavigator_TARIZOFI_1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdAGREGAR = New System.Windows.Forms.ToolStripButton()
        Me.cmdMODIFICAR = New System.Windows.Forms.ToolStripButton()
        Me.cmdELIMINAR = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdCONSULTAR = New System.Windows.Forms.ToolStripButton()
        Me.cmdRECONSULTAR = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdSALIR = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.fraTarifasZonasEconomicas.SuspendLayout()
        CType(Me.dgvTARIZOFI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource_TARIZOFI_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        CType(Me.BindingNavigator_TARIZOFI_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator_TARIZOFI_1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraTarifasZonasEconomicas
        '
        Me.fraTarifasZonasEconomicas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraTarifasZonasEconomicas.BackColor = System.Drawing.SystemColors.Control
        Me.fraTarifasZonasEconomicas.Controls.Add(Me.lblTAZFVIGE)
        Me.fraTarifasZonasEconomicas.Controls.Add(Me.Label5)
        Me.fraTarifasZonasEconomicas.Controls.Add(Me.lblTAZFZOAP)
        Me.fraTarifasZonasEconomicas.Controls.Add(Me.Label4)
        Me.fraTarifasZonasEconomicas.Controls.Add(Me.lblTAZFZOFI)
        Me.fraTarifasZonasEconomicas.Controls.Add(Me.Label3)
        Me.fraTarifasZonasEconomicas.Controls.Add(Me.lblTAZFCLSE)
        Me.fraTarifasZonasEconomicas.Controls.Add(Me.lblclaseosector)
        Me.fraTarifasZonasEconomicas.Controls.Add(Me.lblTAZFDEPA)
        Me.fraTarifasZonasEconomicas.Controls.Add(Me.Label2)
        Me.fraTarifasZonasEconomicas.Controls.Add(Me.lblTAZFMUNI)
        Me.fraTarifasZonasEconomicas.Controls.Add(Me.lblMUNICIPIO)
        Me.fraTarifasZonasEconomicas.Controls.Add(Me.dgvTARIZOFI)
        Me.fraTarifasZonasEconomicas.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraTarifasZonasEconomicas.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraTarifasZonasEconomicas.Location = New System.Drawing.Point(14, 35)
        Me.fraTarifasZonasEconomicas.Name = "fraTarifasZonasEconomicas"
        Me.fraTarifasZonasEconomicas.Size = New System.Drawing.Size(1072, 514)
        Me.fraTarifasZonasEconomicas.TabIndex = 33
        Me.fraTarifasZonasEconomicas.TabStop = False
        Me.fraTarifasZonasEconomicas.Text = "TARIFAS ZONAS FÍSICAS"
        '
        'lblTAZFVIGE
        '
        Me.lblTAZFVIGE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTAZFVIGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAZFVIGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAZFVIGE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAZFVIGE.ForeColor = System.Drawing.Color.Black
        Me.lblTAZFVIGE.Location = New System.Drawing.Point(664, 478)
        Me.lblTAZFVIGE.Name = "lblTAZFVIGE"
        Me.lblTAZFVIGE.Size = New System.Drawing.Size(390, 20)
        Me.lblTAZFVIGE.TabIndex = 60
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(546, 478)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Vigencia"
        '
        'lblTAZFZOAP
        '
        Me.lblTAZFZOAP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTAZFZOAP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAZFZOAP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAZFZOAP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAZFZOAP.ForeColor = System.Drawing.Color.Black
        Me.lblTAZFZOAP.Location = New System.Drawing.Point(664, 454)
        Me.lblTAZFZOAP.Name = "lblTAZFZOAP"
        Me.lblTAZFZOAP.Size = New System.Drawing.Size(390, 20)
        Me.lblTAZFZOAP.TabIndex = 58
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(546, 454)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 20)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Zona aplicada"
        '
        'lblTAZFZOFI
        '
        Me.lblTAZFZOFI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTAZFZOFI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAZFZOFI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAZFZOFI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAZFZOFI.ForeColor = System.Drawing.Color.Black
        Me.lblTAZFZOFI.Location = New System.Drawing.Point(664, 431)
        Me.lblTAZFZOFI.Name = "lblTAZFZOFI"
        Me.lblTAZFZOFI.Size = New System.Drawing.Size(390, 20)
        Me.lblTAZFZOFI.TabIndex = 56
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(546, 431)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Zona física"
        '
        'lblTAZFCLSE
        '
        Me.lblTAZFCLSE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTAZFCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAZFCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAZFCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAZFCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblTAZFCLSE.Location = New System.Drawing.Point(137, 479)
        Me.lblTAZFCLSE.Name = "lblTAZFCLSE"
        Me.lblTAZFCLSE.Size = New System.Drawing.Size(403, 20)
        Me.lblTAZFCLSE.TabIndex = 54
        '
        'lblclaseosector
        '
        Me.lblclaseosector.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblclaseosector.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblclaseosector.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblclaseosector.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblclaseosector.ForeColor = System.Drawing.Color.Black
        Me.lblclaseosector.Location = New System.Drawing.Point(19, 479)
        Me.lblclaseosector.Name = "lblclaseosector"
        Me.lblclaseosector.Size = New System.Drawing.Size(112, 20)
        Me.lblclaseosector.TabIndex = 53
        Me.lblclaseosector.Text = "Clase o sector"
        '
        'lblTAZFDEPA
        '
        Me.lblTAZFDEPA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTAZFDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAZFDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAZFDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAZFDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblTAZFDEPA.Location = New System.Drawing.Point(137, 431)
        Me.lblTAZFDEPA.Name = "lblTAZFDEPA"
        Me.lblTAZFDEPA.Size = New System.Drawing.Size(403, 20)
        Me.lblTAZFDEPA.TabIndex = 52
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 431)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Departamento"
        '
        'lblTAZFMUNI
        '
        Me.lblTAZFMUNI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTAZFMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTAZFMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAZFMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAZFMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblTAZFMUNI.Location = New System.Drawing.Point(137, 455)
        Me.lblTAZFMUNI.Name = "lblTAZFMUNI"
        Me.lblTAZFMUNI.Size = New System.Drawing.Size(403, 20)
        Me.lblTAZFMUNI.TabIndex = 50
        '
        'lblMUNICIPIO
        '
        Me.lblMUNICIPIO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMUNICIPIO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMUNICIPIO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMUNICIPIO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMUNICIPIO.ForeColor = System.Drawing.Color.Black
        Me.lblMUNICIPIO.Location = New System.Drawing.Point(19, 455)
        Me.lblMUNICIPIO.Name = "lblMUNICIPIO"
        Me.lblMUNICIPIO.Size = New System.Drawing.Size(112, 20)
        Me.lblMUNICIPIO.TabIndex = 49
        Me.lblMUNICIPIO.Text = "Municipio"
        '
        'dgvTARIZOFI
        '
        Me.dgvTARIZOFI.AccessibleDescription = "Tarifas zonas"
        Me.dgvTARIZOFI.AllowUserToAddRows = False
        Me.dgvTARIZOFI.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvTARIZOFI.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTARIZOFI.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTARIZOFI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvTARIZOFI.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvTARIZOFI.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvTARIZOFI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvTARIZOFI.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTARIZOFI.ColumnHeadersHeight = 40
        Me.dgvTARIZOFI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvTARIZOFI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvTARIZOFI.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvTARIZOFI.Location = New System.Drawing.Point(19, 26)
        Me.dgvTARIZOFI.Name = "dgvTARIZOFI"
        Me.dgvTARIZOFI.ReadOnly = True
        Me.dgvTARIZOFI.RowHeadersVisible = False
        Me.dgvTARIZOFI.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvTARIZOFI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTARIZOFI.ShowCellToolTips = False
        Me.dgvTARIZOFI.Size = New System.Drawing.Size(1035, 390)
        Me.dgvTARIZOFI.StandardTab = True
        Me.dgvTARIZOFI.TabIndex = 0
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 560)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(1098, 25)
        Me.strBARRESTA.TabIndex = 32
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
        'BindingNavigator_TARIZOFI_1
        '
        Me.BindingNavigator_TARIZOFI_1.AddNewItem = Nothing
        Me.BindingNavigator_TARIZOFI_1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator_TARIZOFI_1.DeleteItem = Nothing
        Me.BindingNavigator_TARIZOFI_1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.cmdAGREGAR, Me.cmdMODIFICAR, Me.cmdELIMINAR, Me.ToolStripSeparator3, Me.cmdCONSULTAR, Me.cmdRECONSULTAR, Me.ToolStripSeparator1, Me.cmdSALIR, Me.ToolStripSeparator2})
        Me.BindingNavigator_TARIZOFI_1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator_TARIZOFI_1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator_TARIZOFI_1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator_TARIZOFI_1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator_TARIZOFI_1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator_TARIZOFI_1.Name = "BindingNavigator_TARIZOFI_1"
        Me.BindingNavigator_TARIZOFI_1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator_TARIZOFI_1.Size = New System.Drawing.Size(1098, 25)
        Me.BindingNavigator_TARIZOFI_1.TabIndex = 31
        Me.BindingNavigator_TARIZOFI_1.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Número total de elementos"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Mover primero"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Mover anterior"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Posición"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Posición actual"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Mover siguiente"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Mover último"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'cmdAGREGAR
        '
        Me.cmdAGREGAR.AccessibleDescription = "Agregar"
        Me.cmdAGREGAR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdAGREGAR.Image = Global.SICAFI.My.Resources.Resources._210
        Me.cmdAGREGAR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdAGREGAR.Name = "cmdAGREGAR"
        Me.cmdAGREGAR.Size = New System.Drawing.Size(23, 22)
        Me.cmdAGREGAR.ToolTipText = "Agregar (F2)"
        '
        'cmdMODIFICAR
        '
        Me.cmdMODIFICAR.AccessibleDescription = "Modificar"
        Me.cmdMODIFICAR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdMODIFICAR.Image = Global.SICAFI.My.Resources.Resources.icon_edit
        Me.cmdMODIFICAR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdMODIFICAR.Name = "cmdMODIFICAR"
        Me.cmdMODIFICAR.Size = New System.Drawing.Size(23, 22)
        Me.cmdMODIFICAR.ToolTipText = "Modificar (F3)"
        '
        'cmdELIMINAR
        '
        Me.cmdELIMINAR.AccessibleDescription = "Eliminar"
        Me.cmdELIMINAR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdELIMINAR.Image = Global.SICAFI.My.Resources.Resources._132
        Me.cmdELIMINAR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdELIMINAR.Name = "cmdELIMINAR"
        Me.cmdELIMINAR.Size = New System.Drawing.Size(23, 22)
        Me.cmdELIMINAR.ToolTipText = "Eliminar (Supr)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'cmdCONSULTAR
        '
        Me.cmdCONSULTAR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdCONSULTAR.Image = Global.SICAFI.My.Resources.Resources._045
        Me.cmdCONSULTAR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdCONSULTAR.Name = "cmdCONSULTAR"
        Me.cmdCONSULTAR.Size = New System.Drawing.Size(23, 22)
        Me.cmdCONSULTAR.ToolTipText = "Consultar (F7)"
        '
        'cmdRECONSULTAR
        '
        Me.cmdRECONSULTAR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdRECONSULTAR.Image = Global.SICAFI.My.Resources.Resources._096
        Me.cmdRECONSULTAR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdRECONSULTAR.Name = "cmdRECONSULTAR"
        Me.cmdRECONSULTAR.Size = New System.Drawing.Size(23, 22)
        Me.cmdRECONSULTAR.ToolTipText = "Reconsultar (F8)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(23, 22)
        Me.cmdSALIR.ToolTipText = "Salir"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'frm_TARIZOFI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1098, 585)
        Me.Controls.Add(Me.fraTarifasZonasEconomicas)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.BindingNavigator_TARIZOFI_1)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_TARIZOFI"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "TARIFAS POR ZONA FÍSICA"
        Me.fraTarifasZonasEconomicas.ResumeLayout(False)
        CType(Me.dgvTARIZOFI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource_TARIZOFI_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        CType(Me.BindingNavigator_TARIZOFI_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator_TARIZOFI_1.ResumeLayout(False)
        Me.BindingNavigator_TARIZOFI_1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraTarifasZonasEconomicas As System.Windows.Forms.GroupBox
    Friend WithEvents lblTAZFVIGE As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTAZFZOAP As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTAZFZOFI As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTAZFCLSE As System.Windows.Forms.Label
    Friend WithEvents lblclaseosector As System.Windows.Forms.Label
    Friend WithEvents lblTAZFDEPA As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTAZFMUNI As System.Windows.Forms.Label
    Friend WithEvents lblMUNICIPIO As System.Windows.Forms.Label
    Friend WithEvents dgvTARIZOFI As System.Windows.Forms.DataGridView
    Friend WithEvents BindingSource_TARIZOFI_1 As System.Windows.Forms.BindingSource
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BindingNavigator_TARIZOFI_1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdAGREGAR As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdMODIFICAR As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdELIMINAR As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdCONSULTAR As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdRECONSULTAR As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdSALIR As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
