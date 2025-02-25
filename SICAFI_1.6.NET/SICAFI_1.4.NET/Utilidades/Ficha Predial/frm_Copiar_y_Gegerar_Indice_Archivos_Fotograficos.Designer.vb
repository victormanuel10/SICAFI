<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Copiar_y_Gegerar_Indice_Archivos_Fotograficos
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblRUCFCAFO = New System.Windows.Forms.Label()
        Me.cboRUCFCAFO = New System.Windows.Forms.ComboBox()
        Me.cboRUCFMUNI = New System.Windows.Forms.ComboBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.lblRUCFMUNI = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.cboRUCFCLSE = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cboRUCFDEPA = New System.Windows.Forms.ComboBox()
        Me.lblRUCFCLSE = New System.Windows.Forms.Label()
        Me.lblRUCFDEPA = New System.Windows.Forms.Label()
        Me.txtRUCFRUTA = New System.Windows.Forms.Label()
        Me.cmdBuscarRuta = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkImportarTodos = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.cmdAbrirCarpeta = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkRealizarCopia = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdGUARDAR = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.lstLISTADO_DOCUMENTOS = New System.Windows.Forms.ListBox()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.chkIndexarCroquisDelPredio = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblRUCFCAFO)
        Me.GroupBox1.Controls.Add(Me.cboRUCFCAFO)
        Me.GroupBox1.Controls.Add(Me.cboRUCFMUNI)
        Me.GroupBox1.Controls.Add(Me.Label60)
        Me.GroupBox1.Controls.Add(Me.lblRUCFMUNI)
        Me.GroupBox1.Controls.Add(Me.Label58)
        Me.GroupBox1.Controls.Add(Me.cboRUCFCLSE)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.cboRUCFDEPA)
        Me.GroupBox1.Controls.Add(Me.lblRUCFCLSE)
        Me.GroupBox1.Controls.Add(Me.lblRUCFDEPA)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(790, 125)
        Me.GroupBox1.TabIndex = 392
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PARAMETROS CARPETA FOTOGRAFICA"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 20)
        Me.Label3.TabIndex = 393
        Me.Label3.Text = "Carpeta"
        '
        'lblRUCFCAFO
        '
        Me.lblRUCFCAFO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUCFCAFO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUCFCAFO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUCFCAFO.ForeColor = System.Drawing.Color.Black
        Me.lblRUCFCAFO.Location = New System.Drawing.Point(528, 91)
        Me.lblRUCFCAFO.Name = "lblRUCFCAFO"
        Me.lblRUCFCAFO.Size = New System.Drawing.Size(244, 20)
        Me.lblRUCFCAFO.TabIndex = 394
        '
        'cboRUCFCAFO
        '
        Me.cboRUCFCAFO.AccessibleDescription = "Carpeta"
        Me.cboRUCFCAFO.BackColor = System.Drawing.Color.White
        Me.cboRUCFCAFO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUCFCAFO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUCFCAFO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUCFCAFO.Location = New System.Drawing.Point(145, 89)
        Me.cboRUCFCAFO.MaxDropDownItems = 15
        Me.cboRUCFCAFO.MaxLength = 1
        Me.cboRUCFCAFO.Name = "cboRUCFCAFO"
        Me.cboRUCFCAFO.Size = New System.Drawing.Size(379, 22)
        Me.cboRUCFCAFO.TabIndex = 4
        '
        'cboRUCFMUNI
        '
        Me.cboRUCFMUNI.AccessibleDescription = "Municipio"
        Me.cboRUCFMUNI.BackColor = System.Drawing.Color.White
        Me.cboRUCFMUNI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUCFMUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUCFMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUCFMUNI.Location = New System.Drawing.Point(145, 43)
        Me.cboRUCFMUNI.MaxDropDownItems = 15
        Me.cboRUCFMUNI.MaxLength = 1
        Me.cboRUCFMUNI.Name = "cboRUCFMUNI"
        Me.cboRUCFMUNI.Size = New System.Drawing.Size(379, 22)
        Me.cboRUCFMUNI.TabIndex = 2
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label60.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label60.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.ForeColor = System.Drawing.Color.Black
        Me.Label60.Location = New System.Drawing.Point(16, 45)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(126, 20)
        Me.Label60.TabIndex = 392
        Me.Label60.Text = "Municipio"
        '
        'lblRUCFMUNI
        '
        Me.lblRUCFMUNI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUCFMUNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUCFMUNI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUCFMUNI.ForeColor = System.Drawing.Color.Black
        Me.lblRUCFMUNI.Location = New System.Drawing.Point(528, 45)
        Me.lblRUCFMUNI.Name = "lblRUCFMUNI"
        Me.lblRUCFMUNI.Size = New System.Drawing.Size(244, 20)
        Me.lblRUCFMUNI.TabIndex = 391
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label58.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label58.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.Black
        Me.Label58.Location = New System.Drawing.Point(16, 22)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(126, 20)
        Me.Label58.TabIndex = 386
        Me.Label58.Text = "Departamento"
        '
        'cboRUCFCLSE
        '
        Me.cboRUCFCLSE.AccessibleDescription = "Clase o sector "
        Me.cboRUCFCLSE.BackColor = System.Drawing.Color.White
        Me.cboRUCFCLSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUCFCLSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUCFCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUCFCLSE.Location = New System.Drawing.Point(145, 66)
        Me.cboRUCFCLSE.MaxDropDownItems = 15
        Me.cboRUCFCLSE.MaxLength = 1
        Me.cboRUCFCLSE.Name = "cboRUCFCLSE"
        Me.cboRUCFCLSE.Size = New System.Drawing.Size(379, 22)
        Me.cboRUCFCLSE.TabIndex = 3
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(16, 68)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(126, 20)
        Me.Label27.TabIndex = 384
        Me.Label27.Text = "Clase o sector"
        '
        'cboRUCFDEPA
        '
        Me.cboRUCFDEPA.AccessibleDescription = "Departamento"
        Me.cboRUCFDEPA.BackColor = System.Drawing.Color.White
        Me.cboRUCFDEPA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRUCFDEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRUCFDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRUCFDEPA.Location = New System.Drawing.Point(145, 20)
        Me.cboRUCFDEPA.MaxDropDownItems = 15
        Me.cboRUCFDEPA.MaxLength = 1
        Me.cboRUCFDEPA.Name = "cboRUCFDEPA"
        Me.cboRUCFDEPA.Size = New System.Drawing.Size(379, 22)
        Me.cboRUCFDEPA.TabIndex = 1
        '
        'lblRUCFCLSE
        '
        Me.lblRUCFCLSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUCFCLSE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUCFCLSE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUCFCLSE.ForeColor = System.Drawing.Color.Black
        Me.lblRUCFCLSE.Location = New System.Drawing.Point(528, 68)
        Me.lblRUCFCLSE.Name = "lblRUCFCLSE"
        Me.lblRUCFCLSE.Size = New System.Drawing.Size(244, 20)
        Me.lblRUCFCLSE.TabIndex = 385
        '
        'lblRUCFDEPA
        '
        Me.lblRUCFDEPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRUCFDEPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRUCFDEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUCFDEPA.ForeColor = System.Drawing.Color.Black
        Me.lblRUCFDEPA.Location = New System.Drawing.Point(528, 22)
        Me.lblRUCFDEPA.Name = "lblRUCFDEPA"
        Me.lblRUCFDEPA.Size = New System.Drawing.Size(244, 20)
        Me.lblRUCFDEPA.TabIndex = 387
        '
        'txtRUCFRUTA
        '
        Me.txtRUCFRUTA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtRUCFRUTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtRUCFRUTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRUCFRUTA.ForeColor = System.Drawing.Color.Black
        Me.txtRUCFRUTA.Location = New System.Drawing.Point(145, 20)
        Me.txtRUCFRUTA.Name = "txtRUCFRUTA"
        Me.txtRUCFRUTA.Size = New System.Drawing.Size(627, 20)
        Me.txtRUCFRUTA.TabIndex = 402
        '
        'cmdBuscarRuta
        '
        Me.cmdBuscarRuta.AccessibleDescription = "Buscar ruta"
        Me.cmdBuscarRuta.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdBuscarRuta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBuscarRuta.Location = New System.Drawing.Point(19, 19)
        Me.cmdBuscarRuta.Name = "cmdBuscarRuta"
        Me.cmdBuscarRuta.Size = New System.Drawing.Size(123, 23)
        Me.cmdBuscarRuta.TabIndex = 5
        Me.cmdBuscarRuta.Text = "Buscar ruta..."
        Me.cmdBuscarRuta.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkImportarTodos)
        Me.GroupBox4.Location = New System.Drawing.Point(684, 266)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(118, 62)
        Me.GroupBox4.TabIndex = 395
        Me.GroupBox4.TabStop = False
        '
        'chkImportarTodos
        '
        Me.chkImportarTodos.AutoSize = True
        Me.chkImportarTodos.Checked = True
        Me.chkImportarTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkImportarTodos.Location = New System.Drawing.Point(14, 24)
        Me.chkImportarTodos.Name = "chkImportarTodos"
        Me.chkImportarTodos.Size = New System.Drawing.Size(93, 17)
        Me.chkImportarTodos.TabIndex = 0
        Me.chkImportarTodos.Text = "Importar todos"
        Me.chkImportarTodos.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblRuta)
        Me.GroupBox5.Controls.Add(Me.cmdAbrirCarpeta)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(12, 266)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(542, 62)
        Me.GroupBox5.TabIndex = 393
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "RUTA ARCHIVO"
        '
        'lblRuta
        '
        Me.lblRuta.AccessibleDescription = "Ruta archivo"
        Me.lblRuta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRuta.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRuta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.ForeColor = System.Drawing.Color.Black
        Me.lblRuta.Location = New System.Drawing.Point(145, 25)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(379, 20)
        Me.lblRuta.TabIndex = 356
        '
        'cmdAbrirCarpeta
        '
        Me.cmdAbrirCarpeta.AccessibleDescription = "Abrir carpeta"
        Me.cmdAbrirCarpeta.Enabled = False
        Me.cmdAbrirCarpeta.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdAbrirCarpeta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAbrirCarpeta.Location = New System.Drawing.Point(19, 23)
        Me.cmdAbrirCarpeta.Name = "cmdAbrirCarpeta"
        Me.cmdAbrirCarpeta.Size = New System.Drawing.Size(123, 23)
        Me.cmdAbrirCarpeta.TabIndex = 1
        Me.cmdAbrirCarpeta.Text = "Abrir carpeta"
        Me.cmdAbrirCarpeta.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkRealizarCopia)
        Me.GroupBox2.Location = New System.Drawing.Point(560, 266)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(118, 62)
        Me.GroupBox2.TabIndex = 394
        Me.GroupBox2.TabStop = False
        '
        'chkRealizarCopia
        '
        Me.chkRealizarCopia.AutoSize = True
        Me.chkRealizarCopia.Checked = True
        Me.chkRealizarCopia.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRealizarCopia.Location = New System.Drawing.Point(14, 24)
        Me.chkRealizarCopia.Name = "chkRealizarCopia"
        Me.chkRealizarCopia.Size = New System.Drawing.Size(93, 17)
        Me.chkRealizarCopia.TabIndex = 0
        Me.chkRealizarCopia.Text = "Realizar copia"
        Me.chkRealizarCopia.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cmdSALIR)
        Me.GroupBox3.Controls.Add(Me.cmdGUARDAR)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 510)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(790, 46)
        Me.GroupBox3.TabIndex = 396
        Me.GroupBox3.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Salir"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(401, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(101, 23)
        Me.cmdSALIR.TabIndex = 2
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdGUARDAR
        '
        Me.cmdGUARDAR.AccessibleDescription = "Guardar"
        Me.cmdGUARDAR.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGUARDAR.Location = New System.Drawing.Point(294, 15)
        Me.cmdGUARDAR.Name = "cmdGUARDAR"
        Me.cmdGUARDAR.Size = New System.Drawing.Size(101, 23)
        Me.cmdGUARDAR.TabIndex = 1
        Me.cmdGUARDAR.Text = "&Guardar"
        Me.cmdGUARDAR.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.lstLISTADO_DOCUMENTOS)
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(12, 334)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(790, 170)
        Me.GroupBox6.TabIndex = 398
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "ARCHIVOS"
        '
        'lstLISTADO_DOCUMENTOS
        '
        Me.lstLISTADO_DOCUMENTOS.AccessibleDescription = "Listado"
        Me.lstLISTADO_DOCUMENTOS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstLISTADO_DOCUMENTOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLISTADO_DOCUMENTOS.FormattingEnabled = True
        Me.lstLISTADO_DOCUMENTOS.ItemHeight = 16
        Me.lstLISTADO_DOCUMENTOS.Location = New System.Drawing.Point(19, 24)
        Me.lstLISTADO_DOCUMENTOS.Name = "lstLISTADO_DOCUMENTOS"
        Me.lstLISTADO_DOCUMENTOS.Size = New System.Drawing.Size(752, 116)
        Me.lstLISTADO_DOCUMENTOS.TabIndex = 335
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 574)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(816, 25)
        Me.strBARRESTA.TabIndex = 397
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
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtRUCFRUTA)
        Me.GroupBox7.Controls.Add(Me.cmdBuscarRuta)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 203)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(790, 57)
        Me.GroupBox7.TabIndex = 399
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "RUTA DESTINO"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.chkIndexarCroquisDelPredio)
        Me.GroupBox8.Location = New System.Drawing.Point(12, 143)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(790, 54)
        Me.GroupBox8.TabIndex = 400
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "CROQUIS DEL PREDIO"
        '
        'chkIndexarCroquisDelPredio
        '
        Me.chkIndexarCroquisDelPredio.Location = New System.Drawing.Point(16, 20)
        Me.chkIndexarCroquisDelPredio.Name = "chkIndexarCroquisDelPredio"
        Me.chkIndexarCroquisDelPredio.Size = New System.Drawing.Size(215, 17)
        Me.chkIndexarCroquisDelPredio.TabIndex = 0
        Me.chkIndexarCroquisDelPredio.Text = "Indexar croquis del predio"
        Me.chkIndexarCroquisDelPredio.UseVisualStyleBackColor = True
        '
        'frm_Copiar_y_Gegerar_Indice_Archivos_Fotograficos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 599)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_Copiar_y_Gegerar_Indice_Archivos_Fotograficos"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "COPIAR Y GENERAR INDICE DE ARCHIVOS FOTOGRAFICOS"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRUCFRUTA As System.Windows.Forms.Label
    Friend WithEvents cmdBuscarRuta As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblRUCFCAFO As System.Windows.Forms.Label
    Friend WithEvents cboRUCFCAFO As System.Windows.Forms.ComboBox
    Friend WithEvents cboRUCFMUNI As System.Windows.Forms.ComboBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents lblRUCFMUNI As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents cboRUCFCLSE As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cboRUCFDEPA As System.Windows.Forms.ComboBox
    Friend WithEvents lblRUCFCLSE As System.Windows.Forms.Label
    Friend WithEvents lblRUCFDEPA As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkImportarTodos As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents cmdAbrirCarpeta As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkRealizarCopia As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdGUARDAR As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents lstLISTADO_DOCUMENTOS As System.Windows.Forms.ListBox
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents chkIndexarCroquisDelPredio As System.Windows.Forms.CheckBox
End Class
