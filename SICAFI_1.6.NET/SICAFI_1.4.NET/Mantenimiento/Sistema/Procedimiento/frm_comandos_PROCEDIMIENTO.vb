Imports REGLAS_DEL_NEGOCIO

Public Class frm_comandos_PROCEDIMIENTO

    '==============================
    '*** COMANDOS PROCEDIMIENTO ***
    '==============================

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

            Me.ClientSize = New System.Drawing.Size(690, 240)
            Me.MaximumSize = New System.Drawing.Size(690, 240)
            Me.MinimumSize = New System.Drawing.Size(690, 240)
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

            Me.cboPROCESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboPROCESTA.DisplayMember = "ESTADESC"
            Me.cboPROCESTA.ValueMember = "ESTACODI"

            Dim objdatos1 As New cla_PROCEDIMIENTO
            Dim tbl As New DataTable

            tbl = objdatos1.fun_Buscar_ID_PROCEDIMIENTO(inIDREGISTRO)

            Me.txtPROCCODI.Text = CStr(Trim(tbl.Rows(0).Item("PROCCODI").ToString))
            Me.txtPROCDESC.Text = CStr(Trim(tbl.Rows(0).Item("PROCDESC").ToString))
            Me.rbdPROCINSE.Checked = CBool(tbl.Rows(0).Item("PROCINSE"))
            Me.rbdPROCMODI.Checked = CBool(tbl.Rows(0).Item("PROCMODI"))
            Me.rbdPROCELIM.Checked = CBool(tbl.Rows(0).Item("PROCELIM"))
            Me.rbdPROCCONS.Checked = CBool(tbl.Rows(0).Item("PROCCONS"))
            Me.cboPROCESTA.SelectedValue = tbl.Rows(0).Item("PROCESTA").ToString

            Me.txtPROCCODI.ReadOnly = True
            Me.ClientSize = New System.Drawing.Size(690, 240)
            Me.MaximumSize = New System.Drawing.Size(690, 240)
            Me.MinimumSize = New System.Drawing.Size(690, 240)
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

            Me.ClientSize = New System.Drawing.Size(690, 470)
            Me.MaximumSize = New System.Drawing.Size(690, 470)
            Me.MinimumSize = New System.Drawing.Size(690, 470)
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
            Dim stPROCCODI As String = ""
            Dim stPROCDESC As String = ""
            Dim stPROCINSE As String = ""
            Dim stPROCMODI As String = ""
            Dim stPROCELIM As String = ""
            Dim stPROCCONS As String = ""
            Dim stPROCESTA As String = ""

            ' carga los campos
            If Trim(Me.txtPROCCODI.Text) = "" Then
                stPROCCODI = "%"
            Else
                stPROCCODI = Trim(Me.txtPROCCODI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPROCDESC.Text) = "" Then
                stPROCDESC = "%"
            Else
                stPROCDESC = Trim(Me.txtPROCDESC.Text)
            End If

            ' carga los campos
            If Me.rbdPROCINSE.Checked = False Then
                stPROCINSE = "0"
            ElseIf Me.rbdPROCINSE.Checked = True Then
                stPROCINSE = "1"
            End If

            ' carga los campos
            If Me.rbdPROCMODI.Checked = False Then
                stPROCMODI = "0"
            ElseIf Me.rbdPROCMODI.Checked = True Then
                stPROCMODI = "1"
            End If

            ' carga los campos
            If Me.rbdPROCELIM.Checked = False Then
                stPROCELIM = "0"
            ElseIf Me.rbdPROCELIM.Checked = True Then
                stPROCELIM = "1"
            End If

            ' carga los campos
            If Me.rbdPROCCONS.Checked = False Then
                stPROCCONS = "0"
            ElseIf Me.rbdPROCCONS.Checked = True Then
                stPROCCONS = "1"
            End If

            ' carga los campos
            If Trim(Me.cboPROCESTA.SelectedValue) = "" Then
                stPROCESTA = "%"
            Else
                stPROCESTA = Trim(Me.cboPROCESTA.SelectedValue)
            End If

            'TIIMatena la consulta
            stConsulta += "Select "
            stConsulta += "PROCIDRE , "
            stConsulta += "PROCCODI as 'Codigo', "
            stConsulta += "PROCDESC as 'Descripción', "
            stConsulta += "PROCINSE as 'Insertar', "
            stConsulta += "PROCMODI as 'Modificar', "
            stConsulta += "PROCELIM as 'Eliminar', "
            stConsulta += "PROCCONS as 'Consultar', "
            stConsulta += "PROCESTA as 'Estado' "
            stConsulta += "From PROCEDIMIENTO "
            stConsulta += "Where "
            stConsulta += "PROCCODI like '" & stPROCCODI & "' and "
            stConsulta += "PROCDESC like '" & stPROCDESC & "' and "
            stConsulta += "PROCINSE like '" & stPROCINSE & "' and "
            stConsulta += "PROCMODI like '" & stPROCMODI & "' and "
            stConsulta += "PROCELIM like '" & stPROCELIM & "' and "
            stConsulta += "PROCCONS like '" & stPROCCONS & "' and "
            stConsulta += "PROCESTA like '" & stPROCESTA & "' "
            stConsulta += "Order by PROCCODI"

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dtTABLA = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dtTABLA

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdACEPTAR.Enabled = False
                Me.txtPROCCODI.Focus()
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
            Dim objdatos As New cla_PROCEDIMIENTO

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_PROCEDIMIENTO(Me.txtPROCCODI)

            Dim objVerifica As New cla_Verificar_Dato

            Dim boPROCCODI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtPROCCODI)
            Dim boPROCDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtPROCDESC)
            Dim boPROCESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPROCESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And boPROCCODI = True And boPROCDESC = True And boPROCESTA = True Then

                Dim objdatos22 As New cla_PROCEDIMIENTO

                If (objdatos22.fun_Insertar_PROCEDIMIENTO(Me.txtPROCCODI.Text, _
                                                          Me.txtPROCDESC.Text, _
                                                          Me.rbdPROCINSE.Checked, _
                                                          Me.rbdPROCMODI.Checked, _
                                                          Me.rbdPROCELIM.Checked, _
                                                          Me.rbdPROCCONS.Checked, _
                                                          Me.cboPROCESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.txtPROCCODI.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.txtPROCCODI.Focus()
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

            Dim boPROCCODI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtPROCCODI)
            Dim boPROCDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtPROCDESC)
            Dim boPROCESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPROCESTA)

            ' verifica los datos del formulario 
            If boPROCCODI = True And boPROCDESC = True And boPROCESTA = True Then

                Dim objdatos As New cla_PROCEDIMIENTO

                If objdatos.fun_Actualizar_PROCEDIMIENTO(inIDREGISTRO, _
                                                         Me.txtPROCCODI.Text, _
                                                         Me.txtPROCDESC.Text, _
                                                         Me.rbdPROCINSE.Checked, _
                                                         Me.rbdPROCMODI.Checked, _
                                                         Me.rbdPROCELIM.Checked, _
                                                         Me.rbdPROCCONS.Checked, _
                                                         Me.cboPROCESTA.SelectedValue) = True Then
                    Me.txtPROCDESC.Focus()
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
            Dim inId_Reg As New frm_PROCEDIMIENTO(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtPROCCODI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
        Me.txtPROCCODI.Focus()
    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtPROCCODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboPROCESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPROCESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPROCESTA, Me.cboPROCESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPROCCODI.KeyPress, txtPROCDESC.KeyPress, cboPROCESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPROCCODI.GotFocus, txtPROCDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPROCESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


#End Region

#Region "Click"

    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPROCESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboPROCESTA, cboPROCESTA.SelectedIndex)
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