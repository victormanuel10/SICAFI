Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_MOVIALFA

    '=========================================
    '*** CONSULTA MOVIMIENTO ALFANUMERICOS ***
    '=========================================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False
    Dim dt As DataTable

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_Reconsultar()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            ' crea la variable de los campos
            Dim stMOALMUNI As String = ""
            Dim stMOALCORR As String = ""
            Dim stMOALBARR As String = ""
            Dim stMOALMANZ As String = ""
            Dim stMOALPRED As String = ""
            Dim stMOALCLSE As String = ""
            Dim stMOALVIGE As String = ""
            Dim stMOALFEIN As String = ""
            Dim stMOALFEFI As String = ""
            Dim stMOALCAAC As String = ""
            Dim stMOALESTA As String = ""
            Dim stMOALOBSE As String = ""
            Dim stMOALUSUA As String = ""

            ' carga los campos
            If Trim(Me.txtMOALMUNI.Text) = "" Then
                stMOALMUNI = "%"
            Else
                stMOALMUNI = Trim(Me.txtMOALMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMOALCORR.Text) = "" Then
                stMOALCORR = "%"
            Else
                stMOALCORR = Trim(Me.txtMOALCORR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMOALBARR.Text) = "" Then
                stMOALBARR = "%"
            Else
                stMOALBARR = Trim(Me.txtMOALBARR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMOALMANZ.Text) = "" Then
                stMOALMANZ = "%"
            Else
                stMOALMANZ = Trim(Me.txtMOALMANZ.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMOALPRED.Text) = "" Then
                stMOALPRED = "%"
            Else
                stMOALPRED = Trim(Me.txtMOALPRED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMOALCLSE.Text) = "" Then
                stMOALCLSE = "%"
            Else
                stMOALCLSE = Trim(Me.txtMOALCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMOALVIGE.Text) = "" Then
                stMOALVIGE = "%"
            Else
                stMOALVIGE = Trim(Me.txtMOALVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMOALCAAC.Text) = "" Then
                stMOALCAAC = "%"
            Else
                stMOALCAAC = Trim(Me.txtMOALCAAC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMOALESTA.Text) = "" Then
                stMOALESTA = "%"
            Else
                stMOALESTA = Trim(Me.txtMOALESTA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMOALOBSE.Text) = "" Then
                stMOALOBSE = "%"
            Else
                stMOALOBSE = Trim(Me.txtMOALOBSE.Text)
            End If

            If Trim(Me.txtMOALFEIN.Text) = "" Then
                stMOALFEIN = "%"
            Else
                stMOALFEIN = Trim(Me.txtMOALFEIN.Text)
            End If

            If Trim(Me.txtMOALFEFI.Text) = "" Then
                stMOALFEFI = "%"
            Else
                stMOALFEFI = Trim(Me.txtMOALFEFI.Text)
            End If

            If Trim(Me.txtMOALUSUA.Text) = "" Then
                stMOALUSUA = "%"
            Else
                stMOALUSUA = Trim(Me.txtMOALUSUA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "MOALIDRE , "
            stConsulta += "MOALMUNI as 'Municipio', "
            stConsulta += "MOALCORR as 'Correg', "
            stConsulta += "MOALBARR as 'Barrio', "
            stConsulta += "MOALMANZ as 'Manzana', "
            stConsulta += "MOALPRED as 'Predio', "
            stConsulta += "MOALCLSE as 'Sector', "
            stConsulta += "MOALVIGE as 'Vigencia', "
            stConsulta += "MOALCAAC as 'Causa', "
            stConsulta += "CAACDESC as 'Descripción', "
            stConsulta += "MOALFEIN as 'Fecha ingreso', "
            stConsulta += "MOALFFMU as 'Fecha finaliza.', "
            stConsulta += "MOALUSUA as 'Usuario', "
            stConsulta += "MOALESTA as 'Estado', "
            stConsulta += "ESTADESC as 'Descripción' "

            stConsulta += "From MOVIALFA, MANT_CAUSACTO, ESTADO "
            stConsulta += "Where "
            stConsulta += "MOALCAAC = CAACCODI and  "
            stConsulta += "MOALESTA = ESTACODI and  "
            stConsulta += "MOALMUNI like '" & stMOALMUNI & "' and "
            stConsulta += "MOALCORR like '" & stMOALCORR & "' and "
            stConsulta += "MOALBARR like '" & stMOALBARR & "' and "
            stConsulta += "MOALMANZ like '" & stMOALMANZ & "' and "
            stConsulta += "MOALPRED like '" & stMOALPRED & "' and "
            stConsulta += "MOALCLSE like '" & stMOALCLSE & "' and "
            stConsulta += "MOALVIGE like '" & stMOALVIGE & "' and "
            stConsulta += "MOALCAAC like '" & stMOALCAAC & "' and "
            stConsulta += "MOALFEIN like '" & stMOALFEIN & "' and "
            stConsulta += "MOALFFMU like '" & stMOALFEFI & "' and "
            stConsulta += "MOALESTA like '" & stMOALESTA & "' and "
            stConsulta += "MOALOBSE like '" & stMOALOBSE & "' and "
            stConsulta += "MOALUSUA like '" & stMOALUSUA & "'  "
            stConsulta += "Order by MOALMUNI, MOALCORR, MOALBARR, MOALMANZ, MOALPRED, MOALCLSE, MOALVIGE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtMOALMUNI.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtMOALMUNI.Text = ""
        Me.txtMOALCORR.Text = ""
        Me.txtMOALBARR.Text = ""
        Me.txtMOALMANZ.Text = ""
        Me.txtMOALPRED.Text = ""
        Me.txtMOALCLSE.Text = ""
        Me.txtMOALVIGE.Text = ""
        Me.txtMOALFEIN.Text = ""
        Me.txtMOALCAAC.Text = ""
        Me.txtMOALVIGE.Text = ""
        Me.txtMOALESTA.Text = ""
        Me.txtMOALUSUA.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click

        Try
            pro_Reconsultar()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click

        If Me.dgvCONSULTA.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_MOVIALFA(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtMOALMUNI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtMOALMUNI.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()

    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_consultar_TRABCAMP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.txtMOALMUNI.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMOALMUNI.KeyPress, txtMOALCORR.KeyPress, txtMOALBARR.KeyPress, txtMOALMANZ.KeyPress, txtMOALPRED.KeyPress, txtMOALCLSE.KeyPress, txtMOALVIGE.KeyPress, txtMOALCAAC.KeyPress, txtMOALESTA.KeyPress, txtMOALOBSE.KeyPress, txtMOALUSUA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub


#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOALMUNI.GotFocus, txtMOALCORR.GotFocus, txtMOALBARR.GotFocus, txtMOALMANZ.GotFocus, txtMOALPRED.GotFocus, txtMOALOBSE.GotFocus, txtMOALFEIN.GotFocus, txtMOALESTA.GotFocus, txtMOALUSUA.GotFocus, txtMOALVIGE.GotFocus, txtMOALCAAC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdSalir.GotFocus, cmdConsultar.GotFocus, cmdLimpiar.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOALMUNI.Validated
        If Me.txtMOALMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOALMUNI.Text) = True Then
            Me.txtMOALMUNI.Text = fun_Formato_Mascara_3_String(Me.txtMOALMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOALCORR.Validated
        If Me.txtMOALCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOALCORR.Text) = True Then
            Me.txtMOALCORR.Text = fun_Formato_Mascara_2_String(Me.txtMOALCORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOALBARR.Validated
        If Me.txtMOALBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOALBARR.Text) = True Then
            Me.txtMOALBARR.Text = fun_Formato_Mascara_3_String(Me.txtMOALBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOALMANZ.Validated
        If Me.txtMOALMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOALMANZ.Text) = True Then
            Me.txtMOALMANZ.Text = fun_Formato_Mascara_3_String(Me.txtMOALMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOALPRED.Validated
        If Me.txtMOALPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOALPRED.Text) = True Then
            Me.txtMOALPRED.Text = fun_Formato_Mascara_5_String(Me.txtMOALPRED.Text)
        End If
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