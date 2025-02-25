Imports REGLAS_DEL_NEGOCIO

Public Class frm_Comandos_SMMLV

    '=====================================================
    '*** COMANDOS SALARIO MIMINO MENSUAL LEGAL VIGENTE ***
    '=====================================================

#Region "VARIABLES"

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False
    Dim boCONSULTAR As Boolean = False

    Dim inIDREGISTRO As Integer = 0

    Dim dtTABLA As DataTable

#End Region

#Region "CONSTRUCTOR"

    ''' <summary>
    ''' constructor para insertar
    ''' </summary>
    Public Sub New(ByVal inRegistroInsertar As Boolean, ByVal inRegistroConsultar As Boolean)
        boINSERTAR = inRegistroInsertar
        boCONSULTAR = inRegistroConsultar

        InitializeComponent()

        If boINSERTAR = True Then

            pro_LimpiarCampos()
            pro_InicializarControlesInsertar()

        End If

        If boCONSULTAR = True Then

            pro_LimpiarCampos()
            pro_InicializarControlesConsultar()

        End If

    End Sub

    ''' <summary>
    ''' constructor para modificar
    ''' </summary>
    Public Sub New(ByVal inRegistroModificar As Integer)
        inIDREGISTRO = inRegistroModificar

        InitializeComponent()

        pro_LimpiarCampos()
        pro_InicializarControlesModificar()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_InicializarControlesInsertar()

        Try
            Me.Text = "Insertar registro"

            Me.ClientSize = New System.Drawing.Size(844, 240)
            Me.MaximumSize = New System.Drawing.Size(844, 240)
            Me.MinimumSize = New System.Drawing.Size(844, 240)
            Me.fraCOMANDOS2.Visible = False
            Me.fraCONSULTA.Visible = False
            Me.cmdGUARDAR.Visible = True

            boINSERTAR = True

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_InicializarControlesModificar()

        Try
            Me.Text = "Modificar registro"

            Dim objdatos As New cla_ESTADO

            Me.cboSAMIESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboSAMIESTA.DisplayMember = "ESTADESC"
            Me.cboSAMIESTA.ValueMember = "ESTACODI"

            Dim objdatos2 As New cla_VIGENCIA

            Me.cboSAMIVIGE.DataSource = objdatos2.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboSAMIVIGE.DisplayMember = "VIGEDESC"
            Me.cboSAMIVIGE.ValueMember = "VIGECODI"

            Dim objdatos1 As New cla_SALAMINI
            Dim tbl As New DataTable

            tbl = objdatos1.fun_Buscar_ID_SALAMINI(inIDREGISTRO)

            Me.txtSAMISAMI.Text = CStr(fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("SAMISAMI").ToString)))
            Me.txtSAMIDESC.Text = CStr(Trim(tbl.Rows(0).Item("SAMIDESC").ToString))
            Me.cboSAMIVIGE.SelectedValue = tbl.Rows(0).Item("SAMIVIGE").ToString
            Me.cboSAMIESTA.SelectedValue = tbl.Rows(0).Item("SAMIESTA").ToString

            Me.cboSAMIVIGE.Enabled = False
            Me.ClientSize = New System.Drawing.Size(844, 240)
            Me.MaximumSize = New System.Drawing.Size(844, 240)
            Me.MinimumSize = New System.Drawing.Size(844, 240)
            Me.fraCOMANDOS2.Visible = False
            Me.fraCONSULTA.Visible = False
            Me.cmdGUARDAR.Visible = True

            boMODIFICAR = True

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_InicializarControlesConsultar()

        Try
            Me.Text = "Consultar registro"

            Me.ClientSize = New System.Drawing.Size(844, 470)
            Me.MaximumSize = New System.Drawing.Size(844, 470)
            Me.MinimumSize = New System.Drawing.Size(844, 470)
            Me.fraCOMANDOS2.Visible = True
            Me.fraCONSULTA.Visible = True
            Me.cmdGUARDAR.Visible = False

            boCONSULTAR = True

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try



    End Sub

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraACTOADMI)

        Me.dgvCONSULTA.DataSource = New DataTable

    End Sub
    Private Sub pro_Consultar()

        Try
            ' instancia un dt
            dtTABLA = New DataTable

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            ' crea la variable de los campos
            Dim stSAMISAMI As String = ""
            Dim stSAMIVIGE As String = ""
            Dim stSAMIDESC As String = ""
            Dim stSAMIESTA As String = ""

            ' carga los campos
            If Trim(Me.txtSAMISAMI.Text) = "" Then
                stSAMISAMI = "%"
            Else
                stSAMISAMI = Trim(Me.txtSAMISAMI.Text)
            End If

            ' carga los campos
            If Trim(Me.cboSAMIVIGE.SelectedValue) = "" Then
                stSAMIVIGE = "%"
            Else
                stSAMIVIGE = Trim(Me.cboSAMIVIGE.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.txtSAMIDESC.Text) = "" Then
                stSAMIDESC = "%"
            Else
                stSAMIDESC = Trim(Me.txtSAMIDESC.Text)
            End If

            ' carga los campos
            If Trim(Me.cboSAMIESTA.SelectedValue) = "" Then
                stSAMIESTA = "%"
            Else
                stSAMIESTA = Trim(Me.cboSAMIESTA.SelectedValue)
            End If

            'TIIMatena la consulta
            stConsulta += "Select "
            stConsulta += "SAMIIDRE , "
            stConsulta += "SAMISAMI as 'Salario', "
            stConsulta += "SAMIVIGE as 'Vigencia', "
            stConsulta += "SAMIDESC as 'Descripción', "
            stConsulta += "SAMIESTA as 'Estado' "
            stConsulta += "From SALAMINI "
            stConsulta += "Where "
            stConsulta += "SAMISAMI like '" & stSAMISAMI & "' and "
            stConsulta += "SAMIVIGE like '" & stSAMIVIGE & "' and "
            stConsulta += "SAMIDESC like '" & stSAMIDESC & "' and "
            stConsulta += "SAMIESTA like '" & stSAMIESTA & "' "
            stConsulta += "Order by SAMIVIGE"

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dtTABLA = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dtTABLA

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdACEPTAR.Enabled = False
                Me.txtSAMISAMI.Focus()
            Else
                Me.cmdACEPTAR.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dtTABLA.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_Insertar()

        Try
            ' convierte el numero entero
            Me.txtSAMISAMI.Text = fun_Quita_Letras(Me.txtSAMISAMI)

            ' instancia la clase
            Dim objdatos As New cla_SALAMINI

            ' verifica llave primaria
            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_SALAMINI(Me.cboSAMIVIGE)

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            ' valida los datos
            Dim boSAMISAMI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtSAMISAMI)
            Dim boSAMIVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboSAMIVIGE)
            Dim boSAMIDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtSAMIDESC)
            Dim boPROCESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboSAMIESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And boSAMISAMI = True And boSAMIVIGE = True And boSAMIDESC = True And boPROCESTA = True Then

                ' instancia la clase
                Dim objdatos22 As New cla_SALAMINI

                ' inserta el registro
                If (objdatos22.fun_Insertar_SALAMINI(Me.txtSAMISAMI.Text, _
                                                     Me.cboSAMIVIGE.SelectedValue, _
                                                     Me.txtSAMIDESC.Text, _
                                                     Me.cboSAMIESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.txtSAMISAMI.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.txtSAMISAMI.Focus()
                    End If

                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Guardar")
        End Try

    End Sub
    Private Sub pro_Modificar()

        Try
            ' convierte el numero entero
            Me.txtSAMISAMI.Text = fun_Quita_Letras(Me.txtSAMISAMI)

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            ' valida los datos
            Dim boSAMISAMI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtSAMISAMI)
            Dim boSAMIVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboSAMIVIGE)
            Dim boSAMIDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtSAMIDESC)
            Dim boPROCESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboSAMIESTA)

            ' verifica los datos del formulario 
            If boSAMISAMI = True And boSAMIVIGE = True And boSAMIDESC = True And boPROCESTA = True Then

                Dim objdatos As New cla_SALAMINI

                If objdatos.fun_Actualizar_SALAMINI(inIDREGISTRO, _
                                                     Me.txtSAMISAMI.Text, _
                                                     Me.cboSAMIVIGE.SelectedValue, _
                                                     Me.txtSAMIDESC.Text, _
                                                     Me.cboSAMIESTA.SelectedValue) = True Then
                    Me.txtSAMISAMI.Focus()
                    Me.Close()

                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                Else
                    mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        If boINSERTAR = True Then
            pro_Insertar()

        ElseIf boMODIFICAR = True Then
            pro_Modificar()

        ElseIf boCONSULTAR Then
            pro_Consultar()

        End If

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            pro_Consultar()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdACEPTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdACEPTAR.Click

        If Me.dgvCONSULTA.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_SALAMINI(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtSAMISAMI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
        Me.txtSAMISAMI.Focus()
    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtSAMISAMI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboPROCESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSAMIESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboSAMIESTA, Me.cboSAMIESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSAMISAMI.KeyPress, cboSAMIVIGE.KeyPress, txtSAMIDESC.KeyPress, cboSAMIESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSAMISAMI.GotFocus, txtSAMIDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSAMIESTA.GotFocus, cboSAMIVIGE.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


#End Region

#Region "Click"

    Private Sub cboSAMIVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSAMIVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboSAMIVIGE, Me.cboSAMIVIGE.SelectedIndex)
    End Sub
    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSAMIESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboSAMIESTA, cboSAMIESTA.SelectedIndex)
    End Sub

#End Region

#Region "ResizeBegin"

    Private Sub frm_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        Me.Opacity = vp_Opacity
    End Sub

#End Region

#Region "ResizeEnd"

    Private Sub frm_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim opacity As Double = Convert.ToDouble(100)
        Me.Opacity = opacity
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboSAMIVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSAMIVIGE.SelectedIndexChanged
        Me.lblSAMIVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboSAMIVIGE), String)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtSAMISAMI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSAMISAMI.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtSAMISAMI.Text) = True Then
                Me.txtSAMISAMI.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtSAMISAMI.Text)
            End If

        End If

    End Sub

#End Region

#End Region

End Class