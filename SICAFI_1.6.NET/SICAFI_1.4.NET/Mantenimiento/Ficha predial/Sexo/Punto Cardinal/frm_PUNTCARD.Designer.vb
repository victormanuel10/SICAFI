<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_PUNTCARD
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_PUNTCARD))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BindingNavigator_PUNTCARD_1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdAGREGAR = New System.Windows.Forms.ToolStripButton
        Me.cmdELIMINAR = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingSource_PUNTCARD_1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdMODIFICAR = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdSALIR = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.fraPUNTOCARDINAL = New System.Windows.Forms.GroupBox
        Me.dgvPUCAPUCA = New System.Windows.Forms.DataGridView
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        CType(Me.BindingNavigator_PUNTCARD_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator_PUNTCARD_1.SuspendLayout()
        CType(Me.BindingSource_PUNTCARD_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraPUNTOCARDINAL.SuspendLayout()
        CType(Me.dgvPUCAPUCA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.strBARRESTA.SuspendLayout()
        Me.SuspendLayout()
        '
        'BindingNavigator_PUNTCARD_1
        '
        Me.BindingNavigator_PUNTCARD_1.AddNewItem = Me.cmdAGREGAR
        Me.BindingNavigator_PUNTCARD_1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator_PUNTCARD_1.DeleteItem = Me.cmdELIMINAR
        Me.BindingNavigator_PUNTCARD_1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.cmdAGREGAR, Me.cmdMODIFICAR, Me.cmdELIMINAR, Me.ToolStripSeparator1, Me.cmdSALIR, Me.ToolStripSeparator2})
        Me.BindingNavigator_PUNTCARD_1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator_PUNTCARD_1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator_PUNTCARD_1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator_PUNTCARD_1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator_PUNTCARD_1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator_PUNTCARD_1.Name = "BindingNavigator_PUNTCARD_1"
        Me.BindingNavigator_PUNTCARD_1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator_PUNTCARD_1.Size = New System.Drawing.Size(642, 25)
        Me.BindingNavigator_PUNTCARD_1.TabIndex = 0
        Me.BindingNavigator_PUNTCARD_1.Text = "BindingNavigator1"
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
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(38, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Número total de elementos"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'cmdAGREGAR
        '
        Me.cmdAGREGAR.AccessibleDescription = "Agregar"
        Me.cmdAGREGAR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdAGREGAR.Image = CType(resources.GetObject("cmdAGREGAR.Image"), System.Drawing.Image)
        Me.cmdAGREGAR.Name = "cmdAGREGAR"
        Me.cmdAGREGAR.RightToLeftAutoMirrorImage = True
        Me.cmdAGREGAR.Size = New System.Drawing.Size(23, 22)
        Me.cmdAGREGAR.ToolTipText = "Agregar (F2)"
        '
        'cmdELIMINAR
        '
        Me.cmdELIMINAR.AccessibleDescription = "Eliminar"
        Me.cmdELIMINAR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdELIMINAR.Image = CType(resources.GetObject("cmdELIMINAR.Image"), System.Drawing.Image)
        Me.cmdELIMINAR.Name = "cmdELIMINAR"
        Me.cmdELIMINAR.RightToLeftAutoMirrorImage = True
        Me.cmdELIMINAR.Size = New System.Drawing.Size(23, 22)
        Me.cmdELIMINAR.ToolTipText = "Eliminar (F4)"
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
        'fraPUNTOCARDINAL
        '
        Me.fraPUNTOCARDINAL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fraPUNTOCARDINAL.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.fraPUNTOCARDINAL.Controls.Add(Me.dgvPUCAPUCA)
        Me.fraPUNTOCARDINAL.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPUNTOCARDINAL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPUNTOCARDINAL.Location = New System.Drawing.Point(12, 37)
        Me.fraPUNTOCARDINAL.Name = "fraPUNTOCARDINAL"
        Me.fraPUNTOCARDINAL.Size = New System.Drawing.Size(618, 366)
        Me.fraPUNTOCARDINAL.TabIndex = 25
        Me.fraPUNTOCARDINAL.TabStop = False
        Me.fraPUNTOCARDINAL.Text = "PUNTO CARDINAL"
        '
        'dgvPUCAPUCA
        '
        Me.dgvPUCAPUCA.AccessibleDescription = "Punto cardinal"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvPUCAPUCA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPUCAPUCA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPUCAPUCA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvPUCAPUCA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPUCAPUCA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvPUCAPUCA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvPUCAPUCA.Location = New System.Drawing.Point(19, 26)
        Me.dgvPUCAPUCA.MultiSelect = False
        Me.dgvPUCAPUCA.Name = "dgvPUCAPUCA"
        Me.dgvPUCAPUCA.ReadOnly = True
        Me.dgvPUCAPUCA.ShowCellToolTips = False
        Me.dgvPUCAPUCA.Size = New System.Drawing.Size(580, 321)
        Me.dgvPUCAPUCA.StandardTab = True
        Me.dgvPUCAPUCA.TabIndex = 0
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 418)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(642, 25)
        Me.strBARRESTA.TabIndex = 24
        '
        'tstBAESVALI
        '
        Me.tstBAESVALI.AutoSize = False
        Me.tstBAESVALI.BackColor = System.Drawing.SystemColors.InactiveCaptionText
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
        Me.tstBAESDESC.BackColor = System.Drawing.SystemColors.InactiveCaptionText
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
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
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
        'frm_PUNTCARD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(642, 443)
        Me.Controls.Add(Me.fraPUNTOCARDINAL)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.BindingNavigator_PUNTCARD_1)
        Me.MaximumSize = New System.Drawing.Size(650, 471)
        Me.MinimumSize = New System.Drawing.Size(650, 471)
        Me.Name = "frm_PUNTCARD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento punto cardinal"
        CType(Me.BindingNavigator_PUNTCARD_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator_PUNTCARD_1.ResumeLayout(False)
        Me.BindingNavigator_PUNTCARD_1.PerformLayout()
        CType(Me.BindingSource_PUNTCARD_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraPUNTOCARDINAL.ResumeLayout(False)
        CType(Me.dgvPUCAPUCA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BindingSource_PUNTCARD_1 As System.Windows.Forms.BindingSource
    Friend WithEvents BindingNavigator_PUNTCARD_1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents cmdAGREGAR As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmdELIMINAR As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdMODIFICAR As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdSALIR As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents fraPUNTOCARDINAL As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPUCAPUCA As System.Windows.Forms.DataGridView
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
End Class
