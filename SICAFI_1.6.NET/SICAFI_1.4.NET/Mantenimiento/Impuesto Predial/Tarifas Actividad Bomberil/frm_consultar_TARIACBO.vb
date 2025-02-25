Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_TARIACBO

    '==========================================
    '*** CONSULTA TARIFA ACTIVIDAD BOMBERIL ***
    '==========================================

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
            Dim stTAABDEPA As String = ""
            Dim stTAABMUNI As String = ""
            Dim stTAABCLSE As String = ""
            Dim stTAABVIGE As String = ""
            Dim stTAABTIPO As String = ""
            Dim stTAABTARE As String = ""
            Dim stTAABTACO As String = ""
            Dim stTAABTAIN As String = ""
            Dim stTAABESTR As String = ""
            Dim stTAABTA01 As String = ""
            Dim stTAABTA02 As String = ""
            Dim stTAABTA03 As String = ""
            Dim stTAABTA04 As String = ""
            Dim stTAABTA05 As String = ""
            Dim stTAABAVIN As String = ""
            Dim stTAABAVFI As String = ""
            Dim stTAABESTA As String = ""

            ' carga los campos
            If Trim(Me.txtTAABDEPA.Text) = "" Then
                stTAABDEPA = "%"
            Else
                stTAABDEPA = Trim(Me.txtTAABDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAABMUNI.Text) = "" Then
                stTAABMUNI = "%"
            Else
                stTAABMUNI = Trim(Me.txtTAABMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAABCLSE.Text) = "" Then
                stTAABCLSE = "%"
            Else
                stTAABCLSE = Trim(Me.txtTAABCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAABVIGE.Text) = "" Then
                stTAABVIGE = "%"
            Else
                stTAABVIGE = Trim(Me.txtTAABVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAABTIPO.Text) = "" Then
                stTAABTIPO = "%"
            Else
                stTAABTIPO = Trim(Me.txtTAABTIPO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAABTARE.Text) = "" Then
                stTAABTARE = "%"
            Else
                stTAABTARE = Trim(Me.txtTAABTARE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAABTACO.Text) = "" Then
                stTAABTACO = "%"
            Else
                stTAABTACO = Trim(Me.txtTAABTACO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAABTAIN.Text) = "" Then
                stTAABTAIN = "%"
            Else
                stTAABTAIN = Trim(Me.txtTAABTAIN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAABESTR.Text) = "" Then
                stTAABESTR = "%"
            Else
                stTAABESTR = Trim(Me.txtTAABESTR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAABTA01.Text) = "" Then
                stTAABTA01 = "%"
            Else
                stTAABTA01 = Trim(Me.txtTAABTA01.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAABTA02.Text) = "" Then
                stTAABTA02 = "%"
            Else
                stTAABTA02 = Trim(Me.txtTAABTA02.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAABTA03.Text) = "" Then
                stTAABTA03 = "%"
            Else
                stTAABTA03 = Trim(Me.txtTAABTA03.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAABTA04.Text) = "" Then
                stTAABTA04 = "%"
            Else
                stTAABTA04 = Trim(Me.txtTAABTA04.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAABTA05.Text) = "" Then
                stTAABTA05 = "%"
            Else
                stTAABTA05 = Trim(Me.txtTAABTA05.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAABAVIN.Text) = "" Then
                stTAABAVIN = "%"
            Else
                stTAABAVIN = Trim(Me.txtTAABAVIN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAABAVFI.Text) = "" Then
                stTAABAVFI = "%"
            Else
                stTAABAVFI = Trim(Me.txtTAABAVFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAABESTA.Text) = "" Then
                stTAABESTA = "%"
            Else
                stTAABESTA = Trim(Me.txtTAABESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "TAABIDRE , "
            stConsulta += "TAABDEPA as 'Departamento', "
            stConsulta += "TAABMUNI as 'Municipio', "
            stConsulta += "TAABCLSE as 'Sector', "
            stConsulta += "TAABVIGE as 'Vigencia', "
            stConsulta += "TAABTIPO as 'Tipo', "
            stConsulta += "TAABTARE as 'Ta. Residencial', "
            stConsulta += "TAABTACO as 'Ta. Comercial', "
            stConsulta += "TAABTAIN as 'Ta. Industrial', "
            stConsulta += "TAABESTR as 'Estrato', "
            stConsulta += "TAABTA01 as 'Tarifa 01', "
            stConsulta += "TAABTA02 as 'Tarifa 02', "
            stConsulta += "TAABTA03 as 'Tarifa 03', "
            stConsulta += "TAABTA04 as 'Tarifa 04', "
            stConsulta += "TAABTA05 as 'Tarifa 05', "
            stConsulta += "TAABAVIN as 'Avalúo inicial', "
            stConsulta += "TAABAVFI as 'Avalúo final', "
            stConsulta += "TAABESTA as 'Estado' "
            stConsulta += "From TARIACBO "
            stConsulta += "Where "
            stConsulta += "TAABDEPA like '" & stTAABDEPA & "' and "
            stConsulta += "TAABMUNI like '" & stTAABMUNI & "' and "
            stConsulta += "TAABCLSE like '" & stTAABCLSE & "' and "
            stConsulta += "TAABVIGE like '" & stTAABVIGE & "' and "
            stConsulta += "TAABTIPO like '" & stTAABTIPO & "' and "
            stConsulta += "TAABTARE like '" & stTAABTARE & "' and "
            stConsulta += "TAABTACO like '" & stTAABTACO & "' and "
            stConsulta += "TAABTAIN like '" & stTAABTAIN & "' and "
            stConsulta += "TAABESTR like '" & stTAABESTR & "' and "
            stConsulta += "TAABTA01 like '" & stTAABTA01 & "' and "
            stConsulta += "TAABTA02 like '" & stTAABTA02 & "' and "
            stConsulta += "TAABTA03 like '" & stTAABTA03 & "' and "
            stConsulta += "TAABTA04 like '" & stTAABTA04 & "' and "
            stConsulta += "TAABTA05 like '" & stTAABTA05 & "' and "
            stConsulta += "TAABAVIN like '" & stTAABAVIN & "' and "
            stConsulta += "TAABAVFI like '" & stTAABAVFI & "' and "
            stConsulta += "TAABESTA like '" & stTAABESTA & "' "
            stConsulta += "Order by TAABDEPA, TAABMUNI, TAABCLSE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtTAABDEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtTAABDEPA.Text = ""
        Me.txtTAABMUNI.Text = ""
        Me.txtTAABCLSE.Text = ""
        Me.txtTAABVIGE.Text = ""
        Me.txtTAABTIPO.Text = ""
        Me.txtTAABTARE.Text = ""
        Me.txtTAABTACO.Text = ""
        Me.txtTAABTAIN.Text = ""
        Me.txtTAABTA01.Text = ""
        Me.txtTAABTA02.Text = ""
        Me.txtTAABTA03.Text = ""
        Me.txtTAABTA04.Text = ""
        Me.txtTAABTA05.Text = ""
        Me.txtTAABAVIN.Text = ""
        Me.txtTAABAVFI.Text = ""
        Me.txtTAABESTA.Text = ""

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
            Dim inId_Reg As New frm_TARIACBO(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtTAABDEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtTAABDEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtTAABDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTAABDEPA.KeyPress, txtTAABMUNI.KeyPress, txtTAABCLSE.KeyPress, txtTAABVIGE.KeyPress, txtTAABTIPO.KeyPress, txtTAABTARE.KeyPress, txtTAABTARE.KeyPress, txtTAABTACO.KeyPress, txtTAABTAIN.KeyPress, txtTAABESTR.KeyPress, txtTAABTA01.KeyPress, txtTAABTA02.KeyPress, txtTAABTA03.KeyPress, txtTAABTA04.KeyPress, txtTAABTA05.KeyPress, txtTAABAVIN.KeyPress, txtTAABAVFI.KeyPress, txtTAABESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAABDEPA.GotFocus, txtTAABMUNI.GotFocus, txtTAABCLSE.GotFocus, txtTAABVIGE.GotFocus, txtTAABTIPO.GotFocus, txtTAABTARE.GotFocus, txtTAABTARE.GotFocus, txtTAABTACO.GotFocus, txtTAABTAIN.GotFocus, txtTAABESTR.GotFocus, txtTAABTA01.GotFocus, txtTAABTA02.GotFocus, txtTAABTA03.GotFocus, txtTAABTA04.GotFocus, txtTAABTA05.GotFocus, txtTAABAVIN.GotFocus, txtTAABAVFI.GotFocus, txtTAABESTA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmdAceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
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