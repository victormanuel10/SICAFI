Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_MOVIGEOG

    '======================================
    '*** CONSULTA MOVIMIENTO GEOGRAFICO ***
    '======================================

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
            Dim stMOGEMUNI As String = ""
            Dim stMOGECORR As String = ""
            Dim stMOGEBARR As String = ""
            Dim stMOGEMANZ As String = ""
            Dim stMOGEPRED As String = ""
            Dim stMOGECLSE As String = ""
            Dim stMOGEVIGE As String = ""
            Dim stMOGEFEIN As String = ""
            Dim stMOGEFEFI As String = ""
            Dim stMOGECAAC As String = ""
            Dim stMOGEESTA As String = ""
            Dim stMOGEOBSE As String = ""
            Dim stMOGEUSUA As String = ""

            ' carga los campos
            If Trim(Me.txtMOGEMUNI.Text) = "" Then
                stMOGEMUNI = "%"
            Else
                stMOGEMUNI = Trim(Me.txtMOGEMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMOGECORR.Text) = "" Then
                stMOGECORR = "%"
            Else
                stMOGECORR = Trim(Me.txtMOGECORR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMOGEBARR.Text) = "" Then
                stMOGEBARR = "%"
            Else
                stMOGEBARR = Trim(Me.txtMOGEBARR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMOGEMANZ.Text) = "" Then
                stMOGEMANZ = "%"
            Else
                stMOGEMANZ = Trim(Me.txtMOGEMANZ.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMOGEPRED.Text) = "" Then
                stMOGEPRED = "%"
            Else
                stMOGEPRED = Trim(Me.txtMOGEPRED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMOGECLSE.Text) = "" Then
                stMOGECLSE = "%"
            Else
                stMOGECLSE = Trim(Me.txtMOGECLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMOGEVIGE.Text) = "" Then
                stMOGEVIGE = "%"
            Else
                stMOGEVIGE = Trim(Me.txtMOGEVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMOGECAAC.Text) = "" Then
                stMOGECAAC = "%"
            Else
                stMOGECAAC = Trim(Me.txtMOGECAAC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMOGEESTA.Text) = "" Then
                stMOGEESTA = "%"
            Else
                stMOGEESTA = Trim(Me.txtMOGEESTA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTRCAOBSE.Text) = "" Then
                stMOGEOBSE = "%"
            Else
                stMOGEOBSE = Trim(Me.txtTRCAOBSE.Text)
            End If

            If Trim(Me.txtMOGEFEIN.Text) = "" Then
                stMOGEFEIN = "%"
            Else
                stMOGEFEIN = Trim(Me.txtMOGEFEIN.Text)
            End If

            If Trim(Me.txtMOGEFEFI.Text) = "" Then
                stMOGEFEFI = "%"
            Else
                stMOGEFEFI = Trim(Me.txtMOGEFEFI.Text)
            End If

            If Trim(Me.txtMOGEUSUA.Text) = "" Then
                stMOGEUSUA = "%"
            Else
                stMOGEUSUA = Trim(Me.txtMOGEUSUA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "MOGEIDRE , "
            stConsulta += "MOGEMUNI as 'Municipio', "
            stConsulta += "MOGECORR as 'Correg', "
            stConsulta += "MOGEBARR as 'Barrio', "
            stConsulta += "MOGEMANZ as 'Manzana', "
            stConsulta += "MOGEPRED as 'Predio', "
            stConsulta += "MOGECLSE as 'Sector', "
            stConsulta += "MOGEVIGE as 'Vigencia', "
            stConsulta += "MOGECAAC as 'Causa', "
            stConsulta += "CAACDESC as 'Descripción', "
            stConsulta += "MOGEFEIN as 'Fecha ingreso', "
            stConsulta += "MOGEFFMU as 'Fecha finaliza.', "
            stConsulta += "MOGEUSUA as 'Usuario', "
            stConsulta += "MOGEESTA as 'Estado', "
            stConsulta += "ESTADESC as 'Descripción' "

            stConsulta += "From MOVIGEOG, MANT_CAUSACTO, ESTADO "
            stConsulta += "Where "
            stConsulta += "MOGECAAC = CAACCODI and  "
            stConsulta += "MOGEESTA = ESTACODI and  "
            stConsulta += "MOGEMUNI like '" & stMOGEMUNI & "' and "
            stConsulta += "MOGECORR like '" & stMOGECORR & "' and "
            stConsulta += "MOGEBARR like '" & stMOGEBARR & "' and "
            stConsulta += "MOGEMANZ like '" & stMOGEMANZ & "' and "
            stConsulta += "MOGEPRED like '" & stMOGEPRED & "' and "
            stConsulta += "MOGECLSE like '" & stMOGECLSE & "' and "
            stConsulta += "MOGEVIGE like '" & stMOGEVIGE & "' and "
            stConsulta += "MOGECAAC like '" & stMOGECAAC & "' and "
            stConsulta += "MOGEFEIN like '" & stMOGEFEIN & "' and "
            stConsulta += "MOGEFFMU like '" & stMOGEFEFI & "' and "
            stConsulta += "MOGEESTA like '" & stMOGEESTA & "' and "
            stConsulta += "MOGEOBSE like '" & stMOGEOBSE & "' and "
            stConsulta += "MOGEUSUA like '" & stMOGEUSUA & "'  "
            stConsulta += "Order by MOGEMUNI, MOGECORR, MOGEBARR, MOGEMANZ, MOGEPRED, MOGECLSE, MOGEVIGE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtMOGEMUNI.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtMOGEMUNI.Text = ""
        Me.txtMOGECORR.Text = ""
        Me.txtMOGEBARR.Text = ""
        Me.txtMOGEMANZ.Text = ""
        Me.txtMOGEPRED.Text = ""
        Me.txtMOGECLSE.Text = ""
        Me.txtMOGEVIGE.Text = ""
        Me.txtMOGEFEIN.Text = ""
        Me.txtMOGECAAC.Text = ""
        Me.txtMOGEVIGE.Text = ""
        Me.txtMOGEESTA.Text = ""
        Me.txtMOGEUSUA.Text = ""

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
            Dim inId_Reg As New frm_MOVIGEOG(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtMOGEMUNI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtMOGEMUNI.Focus()
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
        Me.txtMOGEMUNI.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMOGEMUNI.KeyPress, txtMOGECORR.KeyPress, txtMOGEBARR.KeyPress, txtMOGEMANZ.KeyPress, txtMOGEPRED.KeyPress, txtMOGECLSE.KeyPress, txtMOGEVIGE.KeyPress, txtMOGECAAC.KeyPress, txtMOGEESTA.KeyPress, txtTRCAOBSE.KeyPress, txtMOGEUSUA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub


#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOGEMUNI.GotFocus, txtMOGECORR.GotFocus, txtMOGEBARR.GotFocus, txtMOGEMANZ.GotFocus, txtMOGEPRED.GotFocus, txtTRCAOBSE.GotFocus, txtMOGEFEIN.GotFocus, txtMOGEESTA.GotFocus, txtMOGEUSUA.GotFocus, txtMOGEVIGE.GotFocus, txtMOGECAAC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdSalir.GotFocus, cmdConsultar.GotFocus, cmdLimpiar.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOGEMUNI.Validated
        If Me.txtMOGEMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOGEMUNI.Text) = True Then
            Me.txtMOGEMUNI.Text = fun_Formato_Mascara_3_String(Me.txtMOGEMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOGECORR.Validated
        If Me.txtMOGECORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOGECORR.Text) = True Then
            Me.txtMOGECORR.Text = fun_Formato_Mascara_2_String(Me.txtMOGECORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOGEBARR.Validated
        If Me.txtMOGEBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOGEBARR.Text) = True Then
            Me.txtMOGEBARR.Text = fun_Formato_Mascara_3_String(Me.txtMOGEBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOGEMANZ.Validated
        If Me.txtMOGEMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOGEMANZ.Text) = True Then
            Me.txtMOGEMANZ.Text = fun_Formato_Mascara_3_String(Me.txtMOGEMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOGEPRED.Validated
        If Me.txtMOGEPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOGEPRED.Text) = True Then
            Me.txtMOGEPRED.Text = fun_Formato_Mascara_5_String(Me.txtMOGEPRED.Text)
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