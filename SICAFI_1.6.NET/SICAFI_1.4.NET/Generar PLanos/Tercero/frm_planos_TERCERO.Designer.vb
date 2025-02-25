<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_planos_TERCERO
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdSALIR = New System.Windows.Forms.Button()
        Me.tabEXIMPLANO = New System.Windows.Forms.TabControl()
        Me.tabEXPORTACION = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboGPEXSEPA = New System.Windows.Forms.ComboBox()
        Me.cmdGEPLEXPO = New System.Windows.Forms.Button()
        Me.lblGPEXRUTA = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tabIMPORTACION = New System.Windows.Forms.TabPage()
        Me.cmdIMPOPLAN = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTamano = New System.Windows.Forms.TextBox()
        Me.txtFechaAcceso = New System.Windows.Forms.TextBox()
        Me.txtAtributos = New System.Windows.Forms.TextBox()
        Me.lstARCHIVO = New System.Windows.Forms.ListBox()
        Me.chkULTIMO_ACCESO = New System.Windows.Forms.CheckBox()
        Me.chkTAMANO_ARCHIVO = New System.Windows.Forms.CheckBox()
        Me.chkATRIBUTOS = New System.Windows.Forms.CheckBox()
        Me.cmdRUTA = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtGPIMRUTA = New System.Windows.Forms.TextBox()
        Me.strBARRESTA = New System.Windows.Forms.StatusStrip()
        Me.tstBAESVALI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBAESDESC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.tabEXIMPLANO.SuspendLayout()
        Me.tabEXPORTACION.SuspendLayout()
        Me.tabIMPORTACION.SuspendLayout()
        Me.strBARRESTA.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.tabEXIMPLANO)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(813, 475)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "EXPORTAR E IMPORTAR DE ARCHIVOS PLANOS"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cmdSALIR)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 412)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(775, 47)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        '
        'cmdSALIR
        '
        Me.cmdSALIR.AccessibleDescription = "Cancelar"
        Me.cmdSALIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSALIR.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSALIR.Image = Global.SICAFI.My.Resources.Resources._787
        Me.cmdSALIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSALIR.Location = New System.Drawing.Point(624, 15)
        Me.cmdSALIR.Name = "cmdSALIR"
        Me.cmdSALIR.Size = New System.Drawing.Size(123, 23)
        Me.cmdSALIR.TabIndex = 16
        Me.cmdSALIR.Text = "&Salir"
        Me.cmdSALIR.UseVisualStyleBackColor = False
        '
        'tabEXIMPLANO
        '
        Me.tabEXIMPLANO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tabEXIMPLANO.Controls.Add(Me.tabEXPORTACION)
        Me.tabEXIMPLANO.Controls.Add(Me.tabIMPORTACION)
        Me.tabEXIMPLANO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabEXIMPLANO.Location = New System.Drawing.Point(16, 31)
        Me.tabEXIMPLANO.Name = "tabEXIMPLANO"
        Me.tabEXIMPLANO.SelectedIndex = 0
        Me.tabEXIMPLANO.Size = New System.Drawing.Size(775, 375)
        Me.tabEXIMPLANO.TabIndex = 1
        '
        'tabEXPORTACION
        '
        Me.tabEXPORTACION.BackColor = System.Drawing.SystemColors.Control
        Me.tabEXPORTACION.Controls.Add(Me.Label1)
        Me.tabEXPORTACION.Controls.Add(Me.cboGPEXSEPA)
        Me.tabEXPORTACION.Controls.Add(Me.cmdGEPLEXPO)
        Me.tabEXPORTACION.Controls.Add(Me.lblGPEXRUTA)
        Me.tabEXPORTACION.Controls.Add(Me.Label5)
        Me.tabEXPORTACION.Location = New System.Drawing.Point(4, 25)
        Me.tabEXPORTACION.Name = "tabEXPORTACION"
        Me.tabEXPORTACION.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEXPORTACION.Size = New System.Drawing.Size(767, 346)
        Me.tabEXPORTACION.TabIndex = 0
        Me.tabEXPORTACION.Text = "Exportar planos"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(547, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 20)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Separador"
        '
        'cboGPEXSEPA
        '
        Me.cboGPEXSEPA.AccessibleDescription = "Separador"
        Me.cboGPEXSEPA.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboGPEXSEPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGPEXSEPA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGPEXSEPA.FormattingEnabled = True
        Me.cboGPEXSEPA.Items.AddRange(New Object() {"Ninguno", "|", "-", "_", "/", "Espacio "" """})
        Me.cboGPEXSEPA.Location = New System.Drawing.Point(645, 96)
        Me.cboGPEXSEPA.MaxLength = 1
        Me.cboGPEXSEPA.Name = "cboGPEXSEPA"
        Me.cboGPEXSEPA.Size = New System.Drawing.Size(98, 22)
        Me.cboGPEXSEPA.TabIndex = 95
        '
        'cmdGEPLEXPO
        '
        Me.cmdGEPLEXPO.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGEPLEXPO.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdGEPLEXPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGEPLEXPO.ForeColor = System.Drawing.Color.Black
        Me.cmdGEPLEXPO.Image = Global.SICAFI.My.Resources.Resources._71
        Me.cmdGEPLEXPO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGEPLEXPO.Location = New System.Drawing.Point(18, 96)
        Me.cmdGEPLEXPO.Name = "cmdGEPLEXPO"
        Me.cmdGEPLEXPO.Size = New System.Drawing.Size(123, 23)
        Me.cmdGEPLEXPO.TabIndex = 94
        Me.cmdGEPLEXPO.Text = "&Exportar plano"
        Me.cmdGEPLEXPO.UseVisualStyleBackColor = False
        '
        'lblGPEXRUTA
        '
        Me.lblGPEXRUTA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGPEXRUTA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblGPEXRUTA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblGPEXRUTA.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGPEXRUTA.ForeColor = System.Drawing.Color.Black
        Me.lblGPEXRUTA.Location = New System.Drawing.Point(18, 47)
        Me.lblGPEXRUTA.Name = "lblGPEXRUTA"
        Me.lblGPEXRUTA.Size = New System.Drawing.Size(725, 20)
        Me.lblGPEXRUTA.TabIndex = 54
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(18, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(725, 20)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "RUTA ARCHIVO"
        '
        'tabIMPORTACION
        '
        Me.tabIMPORTACION.BackColor = System.Drawing.SystemColors.Control
        Me.tabIMPORTACION.Controls.Add(Me.cmdIMPOPLAN)
        Me.tabIMPORTACION.Controls.Add(Me.Label9)
        Me.tabIMPORTACION.Controls.Add(Me.Label8)
        Me.tabIMPORTACION.Controls.Add(Me.Label7)
        Me.tabIMPORTACION.Controls.Add(Me.txtTamano)
        Me.tabIMPORTACION.Controls.Add(Me.txtFechaAcceso)
        Me.tabIMPORTACION.Controls.Add(Me.txtAtributos)
        Me.tabIMPORTACION.Controls.Add(Me.lstARCHIVO)
        Me.tabIMPORTACION.Controls.Add(Me.chkULTIMO_ACCESO)
        Me.tabIMPORTACION.Controls.Add(Me.chkTAMANO_ARCHIVO)
        Me.tabIMPORTACION.Controls.Add(Me.chkATRIBUTOS)
        Me.tabIMPORTACION.Controls.Add(Me.cmdRUTA)
        Me.tabIMPORTACION.Controls.Add(Me.Label2)
        Me.tabIMPORTACION.Controls.Add(Me.txtGPIMRUTA)
        Me.tabIMPORTACION.Location = New System.Drawing.Point(4, 25)
        Me.tabIMPORTACION.Name = "tabIMPORTACION"
        Me.tabIMPORTACION.Padding = New System.Windows.Forms.Padding(3)
        Me.tabIMPORTACION.Size = New System.Drawing.Size(767, 346)
        Me.tabIMPORTACION.TabIndex = 1
        Me.tabIMPORTACION.Text = "Importar planos"
        '
        'cmdIMPOPLAN
        '
        Me.cmdIMPOPLAN.AccessibleDescription = "Guardar datos"
        Me.cmdIMPOPLAN.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdIMPOPLAN.Enabled = False
        Me.cmdIMPOPLAN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdIMPOPLAN.ForeColor = System.Drawing.Color.Black
        Me.cmdIMPOPLAN.Image = Global.SICAFI.My.Resources.Resources._003
        Me.cmdIMPOPLAN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdIMPOPLAN.Location = New System.Drawing.Point(18, 294)
        Me.cmdIMPOPLAN.Name = "cmdIMPOPLAN"
        Me.cmdIMPOPLAN.Size = New System.Drawing.Size(123, 23)
        Me.cmdIMPOPLAN.TabIndex = 111
        Me.cmdIMPOPLAN.Text = "&Guardar datos"
        Me.cmdIMPOPLAN.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(366, 149)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 22)
        Me.Label9.TabIndex = 108
        Me.Label9.Text = "Tamaño archivo :"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(366, 124)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 22)
        Me.Label8.TabIndex = 107
        Me.Label8.Text = "Fecha acceso :"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(366, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 22)
        Me.Label7.TabIndex = 106
        Me.Label7.Text = "Atributos :"
        '
        'txtTamano
        '
        Me.txtTamano.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTamano.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtTamano.Location = New System.Drawing.Point(467, 149)
        Me.txtTamano.Name = "txtTamano"
        Me.txtTamano.Size = New System.Drawing.Size(283, 22)
        Me.txtTamano.TabIndex = 102
        '
        'txtFechaAcceso
        '
        Me.txtFechaAcceso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFechaAcceso.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtFechaAcceso.Location = New System.Drawing.Point(467, 124)
        Me.txtFechaAcceso.Name = "txtFechaAcceso"
        Me.txtFechaAcceso.Size = New System.Drawing.Size(283, 22)
        Me.txtFechaAcceso.TabIndex = 101
        '
        'txtAtributos
        '
        Me.txtAtributos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAtributos.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtAtributos.Location = New System.Drawing.Point(467, 99)
        Me.txtAtributos.Name = "txtAtributos"
        Me.txtAtributos.Size = New System.Drawing.Size(283, 22)
        Me.txtAtributos.TabIndex = 100
        '
        'lstARCHIVO
        '
        Me.lstARCHIVO.AccessibleDescription = "Archivo"
        Me.lstARCHIVO.FormattingEnabled = True
        Me.lstARCHIVO.ItemHeight = 16
        Me.lstARCHIVO.Location = New System.Drawing.Point(18, 99)
        Me.lstARCHIVO.Name = "lstARCHIVO"
        Me.lstARCHIVO.Size = New System.Drawing.Size(342, 180)
        Me.lstARCHIVO.TabIndex = 99
        '
        'chkULTIMO_ACCESO
        '
        Me.chkULTIMO_ACCESO.AccessibleDescription = "Ultimo acceso"
        Me.chkULTIMO_ACCESO.AutoSize = True
        Me.chkULTIMO_ACCESO.Checked = True
        Me.chkULTIMO_ACCESO.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkULTIMO_ACCESO.Location = New System.Drawing.Point(464, 184)
        Me.chkULTIMO_ACCESO.Name = "chkULTIMO_ACCESO"
        Me.chkULTIMO_ACCESO.Size = New System.Drawing.Size(113, 20)
        Me.chkULTIMO_ACCESO.TabIndex = 98
        Me.chkULTIMO_ACCESO.Text = "Ultimo acceso"
        Me.chkULTIMO_ACCESO.UseVisualStyleBackColor = True
        '
        'chkTAMANO_ARCHIVO
        '
        Me.chkTAMANO_ARCHIVO.AccessibleDescription = "Tamañp archivo"
        Me.chkTAMANO_ARCHIVO.AutoSize = True
        Me.chkTAMANO_ARCHIVO.Checked = True
        Me.chkTAMANO_ARCHIVO.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTAMANO_ARCHIVO.Location = New System.Drawing.Point(583, 184)
        Me.chkTAMANO_ARCHIVO.Name = "chkTAMANO_ARCHIVO"
        Me.chkTAMANO_ARCHIVO.Size = New System.Drawing.Size(125, 20)
        Me.chkTAMANO_ARCHIVO.TabIndex = 97
        Me.chkTAMANO_ARCHIVO.Text = "Tamaño archivo"
        Me.chkTAMANO_ARCHIVO.UseVisualStyleBackColor = True
        '
        'chkATRIBUTOS
        '
        Me.chkATRIBUTOS.AccessibleDescription = "Atributos"
        Me.chkATRIBUTOS.AutoSize = True
        Me.chkATRIBUTOS.Checked = True
        Me.chkATRIBUTOS.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkATRIBUTOS.Location = New System.Drawing.Point(366, 184)
        Me.chkATRIBUTOS.Name = "chkATRIBUTOS"
        Me.chkATRIBUTOS.Size = New System.Drawing.Size(79, 20)
        Me.chkATRIBUTOS.TabIndex = 96
        Me.chkATRIBUTOS.Text = "Atributos"
        Me.chkATRIBUTOS.UseVisualStyleBackColor = True
        '
        'cmdRUTA
        '
        Me.cmdRUTA.AccessibleDescription = "Ruta"
        Me.cmdRUTA.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRUTA.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRUTA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRUTA.ForeColor = System.Drawing.Color.Black
        Me.cmdRUTA.Image = Global.SICAFI.My.Resources.Resources._002
        Me.cmdRUTA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRUTA.Location = New System.Drawing.Point(18, 54)
        Me.cmdRUTA.Name = "cmdRUTA"
        Me.cmdRUTA.Size = New System.Drawing.Size(123, 23)
        Me.cmdRUTA.TabIndex = 95
        Me.cmdRUTA.Text = "&Ruta archivo"
        Me.cmdRUTA.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(18, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(732, 20)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "RUTA ARCHIVO"
        '
        'txtGPIMRUTA
        '
        Me.txtGPIMRUTA.AccessibleDescription = "Ruta carpeta"
        Me.txtGPIMRUTA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGPIMRUTA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtGPIMRUTA.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGPIMRUTA.Location = New System.Drawing.Point(147, 55)
        Me.txtGPIMRUTA.Name = "txtGPIMRUTA"
        Me.txtGPIMRUTA.ReadOnly = True
        Me.txtGPIMRUTA.Size = New System.Drawing.Size(603, 22)
        Me.txtGPIMRUTA.TabIndex = 1
        '
        'strBARRESTA
        '
        Me.strBARRESTA.AutoSize = False
        Me.strBARRESTA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstBAESVALI, Me.tstBAESDESC, Me.ToolStripStatusLabel1})
        Me.strBARRESTA.Location = New System.Drawing.Point(0, 511)
        Me.strBARRESTA.Name = "strBARRESTA"
        Me.strBARRESTA.Size = New System.Drawing.Size(837, 25)
        Me.strBARRESTA.TabIndex = 24
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
        'frm_planos_TERCERO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(837, 536)
        Me.Controls.Add(Me.strBARRESTA)
        Me.Controls.Add(Me.GroupBox1)
        Me.Location = New System.Drawing.Point(5, 5)
        Me.Name = "frm_planos_TERCERO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "GENERACIÓN DE ARCHIVOS PLANOS DE TERCERO"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.tabEXIMPLANO.ResumeLayout(False)
        Me.tabEXPORTACION.ResumeLayout(False)
        Me.tabIMPORTACION.ResumeLayout(False)
        Me.tabIMPORTACION.PerformLayout()
        Me.strBARRESTA.ResumeLayout(False)
        Me.strBARRESTA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tabEXIMPLANO As System.Windows.Forms.TabControl
    Friend WithEvents tabEXPORTACION As System.Windows.Forms.TabPage
    Friend WithEvents tabIMPORTACION As System.Windows.Forms.TabPage
    Friend WithEvents strBARRESTA As System.Windows.Forms.StatusStrip
    Friend WithEvents tstBAESVALI As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstBAESDESC As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmdGEPLEXPO As System.Windows.Forms.Button
    Friend WithEvents lblGPEXRUTA As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboGPEXSEPA As System.Windows.Forms.ComboBox
    Friend WithEvents cmdRUTA As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGPIMRUTA As System.Windows.Forms.TextBox
    Friend WithEvents chkULTIMO_ACCESO As System.Windows.Forms.CheckBox
    Friend WithEvents chkTAMANO_ARCHIVO As System.Windows.Forms.CheckBox
    Friend WithEvents chkATRIBUTOS As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTamano As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaAcceso As System.Windows.Forms.TextBox
    Friend WithEvents txtAtributos As System.Windows.Forms.TextBox
    Friend WithEvents lstARCHIVO As System.Windows.Forms.ListBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdIMPOPLAN As System.Windows.Forms.Button
    Friend WithEvents cmdSALIR As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
End Class
