Imports REGLAS_DEL_NEGOCIO

Public Class frm_comandos_PREDREAD

    '======================================================
    '*** INSERTAR PREDIOS CON RESOLUCIÓN ADMINISTRATIVA ***
    '======================================================

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

            Me.fraPREDREAD.Text = "INSERTAR PREDIO CON RESOLUCÓN ADMINISTRATIVA"

            Me.ClientSize = New System.Drawing.Size(642, 380)
            Me.MaximumSize = New System.Drawing.Size(642, 380)
            Me.MinimumSize = New System.Drawing.Size(642, 380)
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

            Me.fraPREDREAD.Text = "MODIFICAR PREDIO CON RESOLUCÓN ADMINISTRATIVA"

            Dim objdatos1 As New cla_ESTADO

            Me.cboPRRAESTA.DataSource = objdatos1.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboPRRAESTA.DisplayMember = "ESTADESC"
            Me.cboPRRAESTA.ValueMember = "ESTACODI"

            Dim objdatos2 As New cla_TIPOTRAM

            Me.cboPRRATITR.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_TIPOTRAM
            Me.cboPRRATITR.DisplayMember = "TITRDESC"
            Me.cboPRRATITR.ValueMember = "TITRCODI"

            Dim objdatos3 As New cla_CLASSECT

            Me.cboPRRACLSE.DataSource = objdatos3.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboPRRACLSE.DisplayMember = "CLSEDESC"
            Me.cboPRRACLSE.ValueMember = "CLSECODI"

            Dim objdatos4 As New cla_VIGENCIA

            Me.cboPRRAVIGE.DataSource = objdatos4.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboPRRAVIGE.DisplayMember = "VIGEDESC"
            Me.cboPRRAVIGE.ValueMember = "VIGECODI"

            Dim objdatos5 As New cla_PREDREAD
            Dim tbl As New DataTable

            tbl = objdatos5.fun_Buscar_ID_MANT_PREDREAD(inIDREGISTRO)

            Me.cboPRRATITR.SelectedValue = tbl.Rows(0).Item("PRRATITR").ToString
            Me.txtPRRANUFI.Text = CStr(Trim(tbl.Rows(0).Item("PRRANUFI").ToString))
            Me.txtPRRARESO.Text = CStr(Trim(tbl.Rows(0).Item("PRRARESO").ToString))
            Me.cboPRRACLSE.SelectedValue = tbl.Rows(0).Item("PRRACLSE").ToString
            Me.cboPRRAVIGE.SelectedValue = tbl.Rows(0).Item("PRRAVIGE").ToString
            Me.txtPRRAARTE.Text = CStr(Trim(tbl.Rows(0).Item("PRRAARTE").ToString))
            Me.txtPRRAOBSE.Text = CStr(Trim(tbl.Rows(0).Item("PRRAOBSE").ToString))
            Me.cboPRRAESTA.SelectedValue = tbl.Rows(0).Item("PRRAESTA").ToString

            Me.cboPRRATITR.Enabled = False
            Me.txtPRRANUFI.Enabled = False

            Me.ClientSize = New System.Drawing.Size(642, 380)
            Me.MaximumSize = New System.Drawing.Size(642, 380)
            Me.MinimumSize = New System.Drawing.Size(642, 380)
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

            Me.fraPREDREAD.Text = "CONSULTAR PREDIO CON RESOLUCÓN ADMINISTRATIVA"

            Me.ClientSize = New System.Drawing.Size(642, 651)
            Me.MaximumSize = New System.Drawing.Size(642, 651)
            Me.MinimumSize = New System.Drawing.Size(642, 651)
            Me.fraCOMANDOS2.Visible = True
            Me.fraCONSULTA.Visible = True
            Me.cmdGUARDAR.Visible = False

            boCONSULTAR = True

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try



    End Sub

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraPREDREAD)

        Me.lblPRRACLSE.Text = ""
        Me.lblPRRATITR.Text = ""
        Me.lblPRRAVIGE.Text = ""

        Me.dgvCONSULTA.DataSource = New DataTable

    End Sub
    Private Sub pro_Consultar()

        Try
            ' instancia un dt
            dtTABLA = New DataTable

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            ' crea la variable de los campos
            Dim stPRRATITR As String = ""
            Dim stPRRANUFI As String = ""
            Dim stPRRARESO As String = ""
            Dim stPRRACLSE As String = ""
            Dim stPRRAVIGE As String = ""
            Dim stPRRAARTE As String = ""
            Dim stPRRAOBSE As String = ""
            Dim stPRRAESTA As String = ""

            ' guarda la consulta
            If Trim(Me.cboPRRATITR.SelectedValue) = "" Then
                stPRRATITR = "%"
            Else
                stPRRATITR = Trim(Me.cboPRRATITR.SelectedValue)
            End If

            If Trim(Me.txtPRRANUFI.Text) = "" Then
                stPRRANUFI = "%"
            Else
                stPRRANUFI = Trim(Me.txtPRRANUFI.Text)
            End If

            If Trim(Me.txtPRRARESO.Text) = "" Then
                stPRRARESO = "%"
            Else
                stPRRARESO = Trim(Me.txtPRRARESO.Text)
            End If

            If Trim(Me.cboPRRACLSE.SelectedValue) = "" Then
                stPRRACLSE = "%"
            Else
                stPRRACLSE = Trim(Me.cboPRRACLSE.SelectedValue)
            End If

            If Trim(Me.cboPRRAVIGE.SelectedValue) = "" Then
                stPRRAVIGE = "%"
            Else
                stPRRAVIGE = Trim(Me.cboPRRAVIGE.SelectedValue)
            End If

            If Trim(Me.txtPRRAARTE.Text) = "" Then
                stPRRAARTE = "%"
            Else
                stPRRAARTE = Trim(Me.txtPRRAARTE.Text)
            End If

            If Trim(Me.txtPRRAOBSE.Text) = "" Then
                stPRRAOBSE = "%"
            Else
                stPRRAOBSE = Trim(Me.txtPRRAOBSE.Text)
            End If

            If Trim(Me.cboPRRAESTA.SelectedValue) = "" Then
                stPRRAESTA = "%"
            Else
                stPRRAESTA = Trim(Me.cboPRRAESTA.SelectedValue)
            End If

            ' concatena la consulta
            stConsulta += "Select "
            stConsulta += "PRRAIDRE , "
            stConsulta += "PRRATITR as 'Tipo tramite', "
            stConsulta += "PRRANUFI as 'Nro. ficha', "
            stConsulta += "PRRARESO as 'Nro. resolución', "
            stConsulta += "PRRACLSE as 'Sector', "
            stConsulta += "PRRAVIGE as 'Vigencia', "
            stConsulta += "PRRAARTE as 'Área de terreno', "
            stConsulta += "PRRAOBSE as 'Observación', "
            stConsulta += "PRRAESTA as 'Estado' "
            stConsulta += "From MANT_PREDREAD "
            stConsulta += "Where "
            stConsulta += "PRRATITR like '" & stPRRATITR & "' and "
            stConsulta += "PRRANUFI like '" & stPRRANUFI & "' and "
            stConsulta += "PRRARESO like '" & stPRRARESO & "' and "
            stConsulta += "PRRACLSE like '" & stPRRACLSE & "' and "
            stConsulta += "PRRAVIGE like '" & stPRRAVIGE & "' and "
            stConsulta += "PRRAARTE like '" & stPRRAARTE & "' and "
            stConsulta += "PRRAOBSE like '" & stPRRAOBSE & "' and "
            stConsulta += "PRRAESTA like '" & stPRRAESTA & "' "
            stConsulta += "Order by PRRATITR,PRRANUFI,PRRACLSE,PRRAVIGE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dtTABLA = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dtTABLA

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdACEPTAR.Enabled = False
                Me.txtPRRANUFI.Focus()
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
            ' instancia la clase
            Dim objdatos As New cla_PREDREAD

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_PREDREAD(Me.cboPRRATITR, Me.txtPRRANUFI)

            Dim objVerifica As New cla_Verificar_Dato

            Dim boPRRATITR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRRATITR)
            Dim boPRRANUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtPRRANUFI)
            Dim boPRRARESO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtPRRARESO)
            Dim boPRRACLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRRACLSE)
            Dim boPRRAVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRRAVIGE)
            Dim boPRRAARTE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtPRRAARTE)
            Dim boPRRAOBSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtPRRAOBSE)
            Dim boPRRAESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRRAESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boPRRATITR = True And _
               boPRRANUFI = True And _
               boPRRARESO = True And _
               boPRRACLSE = True And _
               boPRRAVIGE = True And _
               boPRRAARTE = True And _
               boPRRAOBSE = True And _
               boPRRAESTA = True Then

                Dim objdatos22 As New cla_PREDREAD

                If (objdatos22.fun_Insertar_MANT_PREDREAD(Me.cboPRRATITR.SelectedValue, _
                                                          Me.txtPRRANUFI.Text, _
                                                          Me.txtPRRARESO.Text, _
                                                          Me.cboPRRACLSE.SelectedValue, _
                                                          Me.cboPRRAVIGE.SelectedValue, _
                                                          Me.txtPRRAARTE.Text, _
                                                          Me.txtPRRAOBSE.Text, _
                                                          Me.cboPRRAESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboPRRATITR.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboPRRATITR.Focus()
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

            Dim objVerifica As New cla_Verificar_Dato

            Dim boPRRATITR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRRATITR)
            Dim boPRRANUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtPRRANUFI)
            Dim boPRRARESO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtPRRARESO)
            Dim boPRRACLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRRACLSE)
            Dim boPRRAVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRRAVIGE)
            Dim boPRRAARTE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtPRRAARTE)
            Dim boPRRAOBSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtPRRAOBSE)
            Dim boPRRAESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRRAESTA)

            ' verifica los datos del formulario 
            If boPRRATITR = True And _
               boPRRANUFI = True And _
               boPRRARESO = True And _
               boPRRACLSE = True And _
               boPRRAVIGE = True And _
               boPRRAARTE = True And _
               boPRRAOBSE = True And _
               boPRRAESTA = True Then

                Dim objdatos As New cla_PREDREAD

                If (objdatos.fun_Actualizar_MANT_PREDREAD(inIDREGISTRO, _
                                                          Me.cboPRRATITR.SelectedValue, _
                                                          Me.txtPRRANUFI.Text, _
                                                          Me.txtPRRARESO.Text, _
                                                          Me.cboPRRACLSE.SelectedValue, _
                                                          Me.cboPRRAVIGE.SelectedValue, _
                                                          Me.txtPRRAARTE.Text, _
                                                          Me.txtPRRAOBSE.Text, _
                                                          Me.cboPRRAESTA.SelectedValue)) = True Then
                    Me.txtPRRARESO.Focus()
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
            Dim inId_Reg As New frm_ACTOADMI(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtPRRANUFI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
        Me.txtPRRANUFI.Focus()
    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtPRRANUFI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPRRANUFI.KeyPress, cboPRRATITR.KeyPress, txtPRRARESO.KeyPress, cboPRRACLSE.KeyPress, cboPRRAVIGE.KeyPress, txtPRRAARTE.KeyPress, txtPRRAOBSE.KeyPress, cboPRRAESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboPRRATITR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRRATITR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOTRAM_Descripcion(Me.cboPRRATITR, Me.cboPRRATITR.SelectedIndex)
        End If
    End Sub
    Private Sub cboPRRACLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRRACLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboPRRACLSE, Me.cboPRRACLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboPRRAVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRRAVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboPRRAVIGE, Me.cboPRRAVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboPRRAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRRAESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPRRAESTA, Me.cboPRRAESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "Click"

    Private Sub cboPRRATITR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRRATITR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOTRAM_Descripcion(cboPRRATITR, cboPRRATITR.SelectedIndex)
    End Sub
    Private Sub cboPRRACLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRRACLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(cboPRRACLSE, cboPRRACLSE.SelectedIndex)
    End Sub
    Private Sub cboPRRAVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRRAVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(cboPRRAVIGE, cboPRRAVIGE.SelectedIndex)
    End Sub
    Private Sub cboPRRAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRRAESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboPRRAESTA, cboPRRAESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboPRRATITR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRRATITR.SelectedIndexChanged
        Me.lblPRRATITR.Text = CType(fun_Buscar_Lista_Valores_TIPOTRAM_Codigo(Me.cboPRRATITR), String)
    End Sub
    Private Sub cboPRRACLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRRACLSE.SelectedIndexChanged
        Me.lblPRRACLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboPRRACLSE), String)
    End Sub
    Private Sub cboPRRAVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRRAVIGE.SelectedIndexChanged
        Me.lblPRRAVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboPRRAVIGE), String)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPRRANUFI.GotFocus, txtPRRARESO.GotFocus, txtPRRAARTE.GotFocus, txtPRRAOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus, cmdACEPTAR.GotFocus, cmdCONSULTAR.GotFocus, cmdLIMPIAR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRRATITR.GotFocus, cboPRRACLSE.GotFocus, cboPRRAVIGE.GotFocus, cboPRRAESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
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

#End Region

End Class