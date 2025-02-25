<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Duplicar_Ficha_Predial
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbdCedulaCatastral = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtFIPRCORR_FUENTE = New System.Windows.Forms.TextBox()
        Me.txtFIPRMUNI_FUENTE = New System.Windows.Forms.TextBox()
        Me.txtFIPRUNPR_FUENTE = New System.Windows.Forms.TextBox()
        Me.txtFIPREDIF_FUENTE = New System.Windows.Forms.TextBox()
        Me.txtFIPRPRED_FUENTE = New System.Windows.Forms.TextBox()
        Me.txtFIPRMANZ_FUENTE = New System.Windows.Forms.TextBox()
        Me.txtFIPRBARR_FUENTE = New System.Windows.Forms.TextBox()
        Me.lblCodigoActual = New System.Windows.Forms.Label()
        Me.lblUnidadPredial = New System.Windows.Forms.Label()
        Me.lblEdificio = New System.Windows.Forms.Label()
        Me.lblPredio = New System.Windows.Forms.Label()
        Me.lblManzana = New System.Windows.Forms.Label()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.lblCorregimiento = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFIPRNFFU = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtFIPRCORR_FINAL = New System.Windows.Forms.TextBox()
        Me.txtFIPRMUNI_FINAL = New System.Windows.Forms.TextBox()
        Me.txtFIPRUNPR_FINAL = New System.Windows.Forms.TextBox()
        Me.txtFIPREDIF_FINAL = New System.Windows.Forms.TextBox()
        Me.txtFIPRPRED_FINAL = New System.Windows.Forms.TextBox()
        Me.txtFIPRMANZ_FINAL = New System.Windows.Forms.TextBox()
        Me.txtFIPRBARR_FINAL = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cmdConsultar = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cmdLimpiar = New System.Windows.Forms.Button()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.cmdEjecutarCopia = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.pbProceso = New System.Windows.Forms.ProgressBar()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFIPRNFIN = New System.Windows.Forms.TextBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.txtFIPRCORR_INICIAL = New System.Windows.Forms.TextBox()
        Me.txtFIPRMUNI_INICIAL = New System.Windows.Forms.TextBox()
        Me.txtFIPRUNPR_INICIAL = New System.Windows.Forms.TextBox()
        Me.txtFIPREDIF_INICIAL = New System.Windows.Forms.TextBox()
        Me.txtFIPRPRED_INICIAL = New System.Windows.Forms.TextBox()
        Me.txtFIPRMANZ_INICIAL = New System.Windows.Forms.TextBox()
        Me.txtFIPRBARR_INICIAL = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbdCedulaCatastral)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(744, 60)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PARAMETRO"
        '
        'rbdCedulaCatastral
        '
        Me.rbdCedulaCatastral.AutoSize = True
        Me.rbdCedulaCatastral.Checked = True
        Me.rbdCedulaCatastral.Location = New System.Drawing.Point(23, 24)
        Me.rbdCedulaCatastral.Name = "rbdCedulaCatastral"
        Me.rbdCedulaCatastral.Size = New System.Drawing.Size(101, 17)
        Me.rbdCedulaCatastral.TabIndex = 10
        Me.rbdCedulaCatastral.TabStop = True
        Me.rbdCedulaCatastral.Text = "Cedula catastral"
        Me.rbdCedulaCatastral.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtFIPRCORR_FUENTE)
        Me.GroupBox3.Controls.Add(Me.txtFIPRMUNI_FUENTE)
        Me.GroupBox3.Controls.Add(Me.txtFIPRUNPR_FUENTE)
        Me.GroupBox3.Controls.Add(Me.txtFIPREDIF_FUENTE)
        Me.GroupBox3.Controls.Add(Me.txtFIPRPRED_FUENTE)
        Me.GroupBox3.Controls.Add(Me.txtFIPRMANZ_FUENTE)
        Me.GroupBox3.Controls.Add(Me.txtFIPRBARR_FUENTE)
        Me.GroupBox3.Controls.Add(Me.lblCodigoActual)
        Me.GroupBox3.Controls.Add(Me.lblUnidadPredial)
        Me.GroupBox3.Controls.Add(Me.lblEdificio)
        Me.GroupBox3.Controls.Add(Me.lblPredio)
        Me.GroupBox3.Controls.Add(Me.lblManzana)
        Me.GroupBox3.Controls.Add(Me.lblBarrio)
        Me.GroupBox3.Controls.Add(Me.lblCorregimiento)
        Me.GroupBox3.Controls.Add(Me.lblMunicipio)
        Me.GroupBox3.Controls.Add(Me.lblCodigo)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 144)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(744, 85)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "CEDULA CATASTRAL FUENTE"
        '
        'txtFIPRCORR_FUENTE
        '
        Me.txtFIPRCORR_FUENTE.AccessibleDescription = "Corregimiento"
        Me.txtFIPRCORR_FUENTE.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRCORR_FUENTE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRCORR_FUENTE.Location = New System.Drawing.Point(202, 48)
        Me.txtFIPRCORR_FUENTE.MaxLength = 10
        Me.txtFIPRCORR_FUENTE.Name = "txtFIPRCORR_FUENTE"
        Me.txtFIPRCORR_FUENTE.ReadOnly = True
        Me.txtFIPRCORR_FUENTE.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRCORR_FUENTE.TabIndex = 4
        '
        'txtFIPRMUNI_FUENTE
        '
        Me.txtFIPRMUNI_FUENTE.AccessibleDescription = "Municipio"
        Me.txtFIPRMUNI_FUENTE.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMUNI_FUENTE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMUNI_FUENTE.Location = New System.Drawing.Point(114, 48)
        Me.txtFIPRMUNI_FUENTE.MaxLength = 10
        Me.txtFIPRMUNI_FUENTE.Name = "txtFIPRMUNI_FUENTE"
        Me.txtFIPRMUNI_FUENTE.ReadOnly = True
        Me.txtFIPRMUNI_FUENTE.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRMUNI_FUENTE.TabIndex = 3
        '
        'txtFIPRUNPR_FUENTE
        '
        Me.txtFIPRUNPR_FUENTE.AccessibleDescription = "Unidad predial "
        Me.txtFIPRUNPR_FUENTE.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRUNPR_FUENTE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRUNPR_FUENTE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRUNPR_FUENTE.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRUNPR_FUENTE.Location = New System.Drawing.Point(642, 48)
        Me.txtFIPRUNPR_FUENTE.MaxLength = 10
        Me.txtFIPRUNPR_FUENTE.Name = "txtFIPRUNPR_FUENTE"
        Me.txtFIPRUNPR_FUENTE.ReadOnly = True
        Me.txtFIPRUNPR_FUENTE.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRUNPR_FUENTE.TabIndex = 9
        '
        'txtFIPREDIF_FUENTE
        '
        Me.txtFIPREDIF_FUENTE.AccessibleDescription = "Edificio "
        Me.txtFIPREDIF_FUENTE.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPREDIF_FUENTE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPREDIF_FUENTE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPREDIF_FUENTE.ForeColor = System.Drawing.Color.Black
        Me.txtFIPREDIF_FUENTE.Location = New System.Drawing.Point(554, 48)
        Me.txtFIPREDIF_FUENTE.MaxLength = 10
        Me.txtFIPREDIF_FUENTE.Name = "txtFIPREDIF_FUENTE"
        Me.txtFIPREDIF_FUENTE.ReadOnly = True
        Me.txtFIPREDIF_FUENTE.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPREDIF_FUENTE.TabIndex = 8
        '
        'txtFIPRPRED_FUENTE
        '
        Me.txtFIPRPRED_FUENTE.AccessibleDescription = "Predio "
        Me.txtFIPRPRED_FUENTE.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRPRED_FUENTE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRPRED_FUENTE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRPRED_FUENTE.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRPRED_FUENTE.Location = New System.Drawing.Point(466, 48)
        Me.txtFIPRPRED_FUENTE.MaxLength = 10
        Me.txtFIPRPRED_FUENTE.Name = "txtFIPRPRED_FUENTE"
        Me.txtFIPRPRED_FUENTE.ReadOnly = True
        Me.txtFIPRPRED_FUENTE.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRPRED_FUENTE.TabIndex = 7
        '
        'txtFIPRMANZ_FUENTE
        '
        Me.txtFIPRMANZ_FUENTE.AccessibleDescription = "Manzana o vereda "
        Me.txtFIPRMANZ_FUENTE.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMANZ_FUENTE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRMANZ_FUENTE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMANZ_FUENTE.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRMANZ_FUENTE.Location = New System.Drawing.Point(378, 48)
        Me.txtFIPRMANZ_FUENTE.MaxLength = 10
        Me.txtFIPRMANZ_FUENTE.Name = "txtFIPRMANZ_FUENTE"
        Me.txtFIPRMANZ_FUENTE.ReadOnly = True
        Me.txtFIPRMANZ_FUENTE.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRMANZ_FUENTE.TabIndex = 6
        '
        'txtFIPRBARR_FUENTE
        '
        Me.txtFIPRBARR_FUENTE.AccessibleDescription = "Barrio "
        Me.txtFIPRBARR_FUENTE.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRBARR_FUENTE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRBARR_FUENTE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRBARR_FUENTE.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRBARR_FUENTE.Location = New System.Drawing.Point(290, 48)
        Me.txtFIPRBARR_FUENTE.MaxLength = 10
        Me.txtFIPRBARR_FUENTE.Name = "txtFIPRBARR_FUENTE"
        Me.txtFIPRBARR_FUENTE.ReadOnly = True
        Me.txtFIPRBARR_FUENTE.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRBARR_FUENTE.TabIndex = 5
        '
        'lblCodigoActual
        '
        Me.lblCodigoActual.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigoActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigoActual.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoActual.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoActual.Location = New System.Drawing.Point(23, 48)
        Me.lblCodigoActual.Name = "lblCodigoActual"
        Me.lblCodigoActual.Size = New System.Drawing.Size(87, 20)
        Me.lblCodigoActual.TabIndex = 314
        Me.lblCodigoActual.Text = "Código Actual"
        '
        'lblUnidadPredial
        '
        Me.lblUnidadPredial.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblUnidadPredial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUnidadPredial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidadPredial.ForeColor = System.Drawing.Color.Black
        Me.lblUnidadPredial.Location = New System.Drawing.Point(642, 25)
        Me.lblUnidadPredial.Name = "lblUnidadPredial"
        Me.lblUnidadPredial.Size = New System.Drawing.Size(84, 20)
        Me.lblUnidadPredial.TabIndex = 313
        Me.lblUnidadPredial.Text = "Unidad Predial"
        '
        'lblEdificio
        '
        Me.lblEdificio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblEdificio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEdificio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdificio.ForeColor = System.Drawing.Color.Black
        Me.lblEdificio.Location = New System.Drawing.Point(554, 25)
        Me.lblEdificio.Name = "lblEdificio"
        Me.lblEdificio.Size = New System.Drawing.Size(84, 20)
        Me.lblEdificio.TabIndex = 312
        Me.lblEdificio.Text = "Edificio"
        '
        'lblPredio
        '
        Me.lblPredio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblPredio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPredio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredio.ForeColor = System.Drawing.Color.Black
        Me.lblPredio.Location = New System.Drawing.Point(466, 25)
        Me.lblPredio.Name = "lblPredio"
        Me.lblPredio.Size = New System.Drawing.Size(84, 20)
        Me.lblPredio.TabIndex = 311
        Me.lblPredio.Text = "Predio"
        '
        'lblManzana
        '
        Me.lblManzana.AccessibleDescription = ""
        Me.lblManzana.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblManzana.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblManzana.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManzana.ForeColor = System.Drawing.Color.Black
        Me.lblManzana.Location = New System.Drawing.Point(378, 25)
        Me.lblManzana.Name = "lblManzana"
        Me.lblManzana.Size = New System.Drawing.Size(84, 20)
        Me.lblManzana.TabIndex = 310
        Me.lblManzana.Text = "Manza / Vered"
        '
        'lblBarrio
        '
        Me.lblBarrio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblBarrio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBarrio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarrio.ForeColor = System.Drawing.Color.Black
        Me.lblBarrio.Location = New System.Drawing.Point(290, 25)
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Size = New System.Drawing.Size(84, 20)
        Me.lblBarrio.TabIndex = 309
        Me.lblBarrio.Text = "Barrio"
        '
        'lblCorregimiento
        '
        Me.lblCorregimiento.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCorregimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCorregimiento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorregimiento.ForeColor = System.Drawing.Color.Black
        Me.lblCorregimiento.Location = New System.Drawing.Point(202, 25)
        Me.lblCorregimiento.Name = "lblCorregimiento"
        Me.lblCorregimiento.Size = New System.Drawing.Size(84, 20)
        Me.lblCorregimiento.TabIndex = 315
        Me.lblCorregimiento.Text = "Corregimiento"
        '
        'lblMunicipio
        '
        Me.lblMunicipio.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblMunicipio.Location = New System.Drawing.Point(114, 25)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(84, 20)
        Me.lblMunicipio.TabIndex = 319
        Me.lblMunicipio.Text = "Municipio"
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(23, 25)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(87, 20)
        Me.lblCodigo.TabIndex = 318
        Me.lblCodigo.Text = "CODIGO"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.txtFIPRNFFU)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 78)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(286, 60)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Nro. FICHA PREDIAL FUENTE"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(23, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 20)
        Me.Label4.TabIndex = 320
        Me.Label4.Text = "Nro. Ficha "
        '
        'txtFIPRNFFU
        '
        Me.txtFIPRNFFU.AccessibleDescription = "Ficha fuente"
        Me.txtFIPRNFFU.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRNFFU.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRNFFU.Location = New System.Drawing.Point(114, 25)
        Me.txtFIPRNFFU.MaxLength = 9
        Me.txtFIPRNFFU.Name = "txtFIPRNFFU"
        Me.txtFIPRNFFU.Size = New System.Drawing.Size(155, 20)
        Me.txtFIPRNFFU.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtFIPRCORR_FINAL)
        Me.GroupBox2.Controls.Add(Me.txtFIPRMUNI_FINAL)
        Me.GroupBox2.Controls.Add(Me.txtFIPRUNPR_FINAL)
        Me.GroupBox2.Controls.Add(Me.txtFIPREDIF_FINAL)
        Me.GroupBox2.Controls.Add(Me.txtFIPRPRED_FINAL)
        Me.GroupBox2.Controls.Add(Me.txtFIPRMANZ_FINAL)
        Me.GroupBox2.Controls.Add(Me.txtFIPRBARR_FINAL)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 326)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(744, 85)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CEDULA CATASTRAL FINAL"
        '
        'txtFIPRCORR_FINAL
        '
        Me.txtFIPRCORR_FINAL.AccessibleDescription = "Corregimiento"
        Me.txtFIPRCORR_FINAL.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRCORR_FINAL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRCORR_FINAL.Location = New System.Drawing.Point(202, 48)
        Me.txtFIPRCORR_FINAL.MaxLength = 10
        Me.txtFIPRCORR_FINAL.Name = "txtFIPRCORR_FINAL"
        Me.txtFIPRCORR_FINAL.ReadOnly = True
        Me.txtFIPRCORR_FINAL.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRCORR_FINAL.TabIndex = 11
        '
        'txtFIPRMUNI_FINAL
        '
        Me.txtFIPRMUNI_FINAL.AccessibleDescription = "Municipio"
        Me.txtFIPRMUNI_FINAL.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMUNI_FINAL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMUNI_FINAL.Location = New System.Drawing.Point(114, 48)
        Me.txtFIPRMUNI_FINAL.MaxLength = 10
        Me.txtFIPRMUNI_FINAL.Name = "txtFIPRMUNI_FINAL"
        Me.txtFIPRMUNI_FINAL.ReadOnly = True
        Me.txtFIPRMUNI_FINAL.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRMUNI_FINAL.TabIndex = 10
        '
        'txtFIPRUNPR_FINAL
        '
        Me.txtFIPRUNPR_FINAL.AccessibleDescription = "Unidad predial final"
        Me.txtFIPRUNPR_FINAL.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRUNPR_FINAL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRUNPR_FINAL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRUNPR_FINAL.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRUNPR_FINAL.Location = New System.Drawing.Point(642, 48)
        Me.txtFIPRUNPR_FINAL.MaxLength = 10
        Me.txtFIPRUNPR_FINAL.Name = "txtFIPRUNPR_FINAL"
        Me.txtFIPRUNPR_FINAL.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRUNPR_FINAL.TabIndex = 16
        '
        'txtFIPREDIF_FINAL
        '
        Me.txtFIPREDIF_FINAL.AccessibleDescription = "Edificio "
        Me.txtFIPREDIF_FINAL.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPREDIF_FINAL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPREDIF_FINAL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPREDIF_FINAL.ForeColor = System.Drawing.Color.Black
        Me.txtFIPREDIF_FINAL.Location = New System.Drawing.Point(554, 48)
        Me.txtFIPREDIF_FINAL.MaxLength = 10
        Me.txtFIPREDIF_FINAL.Name = "txtFIPREDIF_FINAL"
        Me.txtFIPREDIF_FINAL.ReadOnly = True
        Me.txtFIPREDIF_FINAL.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPREDIF_FINAL.TabIndex = 15
        '
        'txtFIPRPRED_FINAL
        '
        Me.txtFIPRPRED_FINAL.AccessibleDescription = "Predio "
        Me.txtFIPRPRED_FINAL.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRPRED_FINAL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRPRED_FINAL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRPRED_FINAL.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRPRED_FINAL.Location = New System.Drawing.Point(466, 48)
        Me.txtFIPRPRED_FINAL.MaxLength = 10
        Me.txtFIPRPRED_FINAL.Name = "txtFIPRPRED_FINAL"
        Me.txtFIPRPRED_FINAL.ReadOnly = True
        Me.txtFIPRPRED_FINAL.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRPRED_FINAL.TabIndex = 14
        '
        'txtFIPRMANZ_FINAL
        '
        Me.txtFIPRMANZ_FINAL.AccessibleDescription = "Manzana o vereda "
        Me.txtFIPRMANZ_FINAL.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMANZ_FINAL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRMANZ_FINAL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMANZ_FINAL.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRMANZ_FINAL.Location = New System.Drawing.Point(378, 48)
        Me.txtFIPRMANZ_FINAL.MaxLength = 10
        Me.txtFIPRMANZ_FINAL.Name = "txtFIPRMANZ_FINAL"
        Me.txtFIPRMANZ_FINAL.ReadOnly = True
        Me.txtFIPRMANZ_FINAL.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRMANZ_FINAL.TabIndex = 13
        '
        'txtFIPRBARR_FINAL
        '
        Me.txtFIPRBARR_FINAL.AccessibleDescription = "Barrio "
        Me.txtFIPRBARR_FINAL.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRBARR_FINAL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRBARR_FINAL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRBARR_FINAL.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRBARR_FINAL.Location = New System.Drawing.Point(290, 48)
        Me.txtFIPRBARR_FINAL.MaxLength = 10
        Me.txtFIPRBARR_FINAL.Name = "txtFIPRBARR_FINAL"
        Me.txtFIPRBARR_FINAL.ReadOnly = True
        Me.txtFIPRBARR_FINAL.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRBARR_FINAL.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(23, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 20)
        Me.Label2.TabIndex = 314
        Me.Label2.Text = "Código Actual"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(642, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 313
        Me.Label3.Text = "Unidad Predial"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(554, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 20)
        Me.Label5.TabIndex = 312
        Me.Label5.Text = "Edificio"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(466, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 20)
        Me.Label6.TabIndex = 311
        Me.Label6.Text = "Predio"
        '
        'Label7
        '
        Me.Label7.AccessibleDescription = ""
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(378, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 20)
        Me.Label7.TabIndex = 310
        Me.Label7.Text = "Manza / Vered"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(290, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 20)
        Me.Label8.TabIndex = 309
        Me.Label8.Text = "Barrio"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(202, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 20)
        Me.Label9.TabIndex = 315
        Me.Label9.Text = "Corregimiento"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(114, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 20)
        Me.Label10.TabIndex = 319
        Me.Label10.Text = "Municipio"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(23, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 20)
        Me.Label11.TabIndex = 318
        Me.Label11.Text = "CODIGO"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmdConsultar)
        Me.GroupBox5.Location = New System.Drawing.Point(566, 78)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(190, 60)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "CONSULTA"
        '
        'cmdConsultar
        '
        Me.cmdConsultar.AccessibleDescription = "Consultar"
        Me.cmdConsultar.Image = Global.SICAFI.My.Resources.Resources._2101
        Me.cmdConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdConsultar.Location = New System.Drawing.Point(17, 23)
        Me.cmdConsultar.Name = "cmdConsultar"
        Me.cmdConsultar.Size = New System.Drawing.Size(155, 23)
        Me.cmdConsultar.TabIndex = 2
        Me.cmdConsultar.Text = "&Consultar"
        Me.cmdConsultar.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cmdLimpiar)
        Me.GroupBox6.Controls.Add(Me.cmdSALIR)
        Me.GroupBox6.Controls.Add(Me.cmdEjecutarCopia)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 483)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(744, 60)
        Me.GroupBox6.TabIndex = 5
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "COMANDOS"
        '
        'cmdLimpiar
        '
        Me.cmdLimpiar.AccessibleDescription = "Limpiar campo"
        Me.cmdLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLimpiar.Image = Global.SICAFI.My.Resources.Resources._025
        Me.cmdLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLimpiar.Location = New System.Drawing.Point(183, 21)
        Me.cmdLimpiar.Name = "cmdLimpiar"
        Me.cmdLimpiar.Size = New System.Drawing.Size(153, 23)
        Me.cmdLimpiar.TabIndex = 18
        Me.cmdLimpiar.Text = "&Limpiar campos"
        Me.cmdLimpiar.UseVisualStyleBackColor = True
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Cancelar"
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(575, 21)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(151, 23)
        Me.cmdSALIR.TabIndex = 19
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = True
        '
        'cmdEjecutarCopia
        '
        Me.cmdEjecutarCopia.AccessibleDescription = "Ejecutar copia"
        Me.cmdEjecutarCopia.Enabled = False
        Me.cmdEjecutarCopia.Image = Global.SICAFI.My.Resources.Resources._008
        Me.cmdEjecutarCopia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEjecutarCopia.Location = New System.Drawing.Point(23, 21)
        Me.cmdEjecutarCopia.Name = "cmdEjecutarCopia"
        Me.cmdEjecutarCopia.Size = New System.Drawing.Size(154, 23)
        Me.cmdEjecutarCopia.TabIndex = 17
        Me.cmdEjecutarCopia.Text = "Ejecutar copia"
        Me.cmdEjecutarCopia.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 550)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(773, 25)
        Me.strBARRESTA.TabIndex = 82
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
        Me.GroupBox7.Controls.Add(Me.pbProceso)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 417)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(744, 60)
        Me.GroupBox7.TabIndex = 83
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "PROGRESO"
        '
        'pbProceso
        '
        Me.pbProceso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbProceso.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pbProceso.Location = New System.Drawing.Point(23, 24)
        Me.pbProceso.Name = "pbProceso"
        Me.pbProceso.Size = New System.Drawing.Size(703, 17)
        Me.pbProceso.TabIndex = 25
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label1)
        Me.GroupBox8.Controls.Add(Me.txtFIPRNFIN)
        Me.GroupBox8.Location = New System.Drawing.Point(302, 78)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(261, 60)
        Me.GroupBox8.TabIndex = 84
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Nro. FICHA PREDIAL INICIAL"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(23, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 20)
        Me.Label1.TabIndex = 320
        Me.Label1.Text = "Nro. Ficha "
        '
        'txtFIPRNFIN
        '
        Me.txtFIPRNFIN.AccessibleDescription = "Ficha fuente"
        Me.txtFIPRNFIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRNFIN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRNFIN.Location = New System.Drawing.Point(114, 25)
        Me.txtFIPRNFIN.MaxLength = 9
        Me.txtFIPRNFIN.Name = "txtFIPRNFIN"
        Me.txtFIPRNFIN.Size = New System.Drawing.Size(129, 20)
        Me.txtFIPRNFIN.TabIndex = 1
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.txtFIPRCORR_INICIAL)
        Me.GroupBox9.Controls.Add(Me.txtFIPRMUNI_INICIAL)
        Me.GroupBox9.Controls.Add(Me.txtFIPRUNPR_INICIAL)
        Me.GroupBox9.Controls.Add(Me.txtFIPREDIF_INICIAL)
        Me.GroupBox9.Controls.Add(Me.txtFIPRPRED_INICIAL)
        Me.GroupBox9.Controls.Add(Me.txtFIPRMANZ_INICIAL)
        Me.GroupBox9.Controls.Add(Me.txtFIPRBARR_INICIAL)
        Me.GroupBox9.Controls.Add(Me.Label12)
        Me.GroupBox9.Controls.Add(Me.Label13)
        Me.GroupBox9.Controls.Add(Me.Label14)
        Me.GroupBox9.Controls.Add(Me.Label15)
        Me.GroupBox9.Controls.Add(Me.Label16)
        Me.GroupBox9.Controls.Add(Me.Label17)
        Me.GroupBox9.Controls.Add(Me.Label18)
        Me.GroupBox9.Controls.Add(Me.Label19)
        Me.GroupBox9.Controls.Add(Me.Label20)
        Me.GroupBox9.Location = New System.Drawing.Point(12, 235)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(744, 85)
        Me.GroupBox9.TabIndex = 85
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "CEDULA CATASTRAL INICIAL"
        '
        'txtFIPRCORR_INICIAL
        '
        Me.txtFIPRCORR_INICIAL.AccessibleDescription = "Corregimiento"
        Me.txtFIPRCORR_INICIAL.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRCORR_INICIAL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRCORR_INICIAL.Location = New System.Drawing.Point(202, 48)
        Me.txtFIPRCORR_INICIAL.MaxLength = 10
        Me.txtFIPRCORR_INICIAL.Name = "txtFIPRCORR_INICIAL"
        Me.txtFIPRCORR_INICIAL.ReadOnly = True
        Me.txtFIPRCORR_INICIAL.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRCORR_INICIAL.TabIndex = 11
        '
        'txtFIPRMUNI_INICIAL
        '
        Me.txtFIPRMUNI_INICIAL.AccessibleDescription = "Municipio"
        Me.txtFIPRMUNI_INICIAL.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMUNI_INICIAL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMUNI_INICIAL.Location = New System.Drawing.Point(114, 48)
        Me.txtFIPRMUNI_INICIAL.MaxLength = 10
        Me.txtFIPRMUNI_INICIAL.Name = "txtFIPRMUNI_INICIAL"
        Me.txtFIPRMUNI_INICIAL.ReadOnly = True
        Me.txtFIPRMUNI_INICIAL.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRMUNI_INICIAL.TabIndex = 10
        '
        'txtFIPRUNPR_INICIAL
        '
        Me.txtFIPRUNPR_INICIAL.AccessibleDescription = "Unidad predial inicial"
        Me.txtFIPRUNPR_INICIAL.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRUNPR_INICIAL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRUNPR_INICIAL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRUNPR_INICIAL.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRUNPR_INICIAL.Location = New System.Drawing.Point(642, 48)
        Me.txtFIPRUNPR_INICIAL.MaxLength = 10
        Me.txtFIPRUNPR_INICIAL.Name = "txtFIPRUNPR_INICIAL"
        Me.txtFIPRUNPR_INICIAL.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRUNPR_INICIAL.TabIndex = 16
        '
        'txtFIPREDIF_INICIAL
        '
        Me.txtFIPREDIF_INICIAL.AccessibleDescription = "Edificio "
        Me.txtFIPREDIF_INICIAL.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPREDIF_INICIAL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPREDIF_INICIAL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPREDIF_INICIAL.ForeColor = System.Drawing.Color.Black
        Me.txtFIPREDIF_INICIAL.Location = New System.Drawing.Point(554, 48)
        Me.txtFIPREDIF_INICIAL.MaxLength = 10
        Me.txtFIPREDIF_INICIAL.Name = "txtFIPREDIF_INICIAL"
        Me.txtFIPREDIF_INICIAL.ReadOnly = True
        Me.txtFIPREDIF_INICIAL.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPREDIF_INICIAL.TabIndex = 15
        '
        'txtFIPRPRED_INICIAL
        '
        Me.txtFIPRPRED_INICIAL.AccessibleDescription = "Predio "
        Me.txtFIPRPRED_INICIAL.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRPRED_INICIAL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRPRED_INICIAL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRPRED_INICIAL.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRPRED_INICIAL.Location = New System.Drawing.Point(466, 48)
        Me.txtFIPRPRED_INICIAL.MaxLength = 10
        Me.txtFIPRPRED_INICIAL.Name = "txtFIPRPRED_INICIAL"
        Me.txtFIPRPRED_INICIAL.ReadOnly = True
        Me.txtFIPRPRED_INICIAL.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRPRED_INICIAL.TabIndex = 14
        '
        'txtFIPRMANZ_INICIAL
        '
        Me.txtFIPRMANZ_INICIAL.AccessibleDescription = "Manzana o vereda "
        Me.txtFIPRMANZ_INICIAL.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRMANZ_INICIAL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRMANZ_INICIAL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRMANZ_INICIAL.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRMANZ_INICIAL.Location = New System.Drawing.Point(378, 48)
        Me.txtFIPRMANZ_INICIAL.MaxLength = 10
        Me.txtFIPRMANZ_INICIAL.Name = "txtFIPRMANZ_INICIAL"
        Me.txtFIPRMANZ_INICIAL.ReadOnly = True
        Me.txtFIPRMANZ_INICIAL.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRMANZ_INICIAL.TabIndex = 13
        '
        'txtFIPRBARR_INICIAL
        '
        Me.txtFIPRBARR_INICIAL.AccessibleDescription = "Barrio "
        Me.txtFIPRBARR_INICIAL.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIPRBARR_INICIAL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPRBARR_INICIAL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPRBARR_INICIAL.ForeColor = System.Drawing.Color.Black
        Me.txtFIPRBARR_INICIAL.Location = New System.Drawing.Point(290, 48)
        Me.txtFIPRBARR_INICIAL.MaxLength = 10
        Me.txtFIPRBARR_INICIAL.Name = "txtFIPRBARR_INICIAL"
        Me.txtFIPRBARR_INICIAL.ReadOnly = True
        Me.txtFIPRBARR_INICIAL.Size = New System.Drawing.Size(85, 20)
        Me.txtFIPRBARR_INICIAL.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(23, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 20)
        Me.Label12.TabIndex = 314
        Me.Label12.Text = "Código Actual"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(642, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 20)
        Me.Label13.TabIndex = 313
        Me.Label13.Text = "Unidad Predial"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(554, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 20)
        Me.Label14.TabIndex = 312
        Me.Label14.Text = "Edificio"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(466, 25)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 20)
        Me.Label15.TabIndex = 311
        Me.Label15.Text = "Predio"
        '
        'Label16
        '
        Me.Label16.AccessibleDescription = ""
        Me.Label16.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(378, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 20)
        Me.Label16.TabIndex = 310
        Me.Label16.Text = "Manza / Vered"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(290, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(84, 20)
        Me.Label17.TabIndex = 309
        Me.Label17.Text = "Barrio"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(202, 25)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 20)
        Me.Label18.TabIndex = 315
        Me.Label18.Text = "Corregimiento"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(114, 25)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 20)
        Me.Label19.TabIndex = 319
        Me.Label19.Text = "Municipio"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(23, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(87, 20)
        Me.Label20.TabIndex = 318
        Me.Label20.Text = "CODIGO"
        '
        'frm_Duplicar_Ficha_Predial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(773, 575)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_Duplicar_Ficha_Predial"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "DUPLICAR FICHA PREDIAL"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdCedulaCatastral As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFIPRCORR_FUENTE As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRMUNI_FUENTE As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRUNPR_FUENTE As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPREDIF_FUENTE As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRPRED_FUENTE As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRMANZ_FUENTE As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRBARR_FUENTE As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoActual As System.Windows.Forms.Label
    Friend WithEvents lblUnidadPredial As System.Windows.Forms.Label
    Friend WithEvents lblEdificio As System.Windows.Forms.Label
    Friend WithEvents lblPredio As System.Windows.Forms.Label
    Friend WithEvents lblManzana As System.Windows.Forms.Label
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents lblCorregimiento As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFIPRNFFU As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFIPRCORR_FINAL As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRMUNI_FINAL As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRUNPR_FINAL As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPREDIF_FINAL As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRPRED_FINAL As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRMANZ_FINAL As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRBARR_FINAL As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmdEjecutarCopia As System.Windows.Forms.Button
    Friend WithEvents cmdConsultar As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents cmdLimpiar As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents pbProceso As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFIPRNFIN As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFIPRCORR_INICIAL As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRMUNI_INICIAL As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRUNPR_INICIAL As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPREDIF_INICIAL As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRPRED_INICIAL As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRMANZ_INICIAL As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPRBARR_INICIAL As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
End Class
