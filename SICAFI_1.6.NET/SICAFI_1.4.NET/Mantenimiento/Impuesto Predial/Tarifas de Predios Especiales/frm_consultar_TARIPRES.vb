Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_TARIPRES

    '==========================================
    '*** CONSULTA TARIFA PREDIOS ESPECIALES ***
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
            Dim stTAPEDEPA As String = ""
            Dim stTAPEMUNI As String = ""
            Dim stTAPECLSE As String = ""
            Dim stTAPEVIGE As String = ""
            Dim stTAPEDEEC As String = ""
            Dim stTAPETARI As String = ""
            Dim stTAPEAVIN As String = ""
            Dim stTAPEAVFI As String = ""
            Dim stTAPEESTA As String = ""

            ' carga los campos
            If Trim(Me.txtTAPEDEPA.Text) = "" Then
                stTAPEDEPA = "%"
            Else
                stTAPEDEPA = Trim(Me.txtTAPEDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAPEMUNI.Text) = "" Then
                stTAPEMUNI = "%"
            Else
                stTAPEMUNI = Trim(Me.txtTAPEMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAPECLSE.Text) = "" Then
                stTAPECLSE = "%"
            Else
                stTAPECLSE = Trim(Me.txtTAPECLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAPEVIGE.Text) = "" Then
                stTAPEVIGE = "%"
            Else
                stTAPEVIGE = Trim(Me.txtTAPEVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAPEDEEC.Text) = "" Then
                stTAPEDEEC = "%"
            Else
                stTAPEDEEC = Trim(Me.txtTAPEDEEC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAPETARI.Text) = "" Then
                stTAPETARI = "%"
            Else
                stTAPETARI = Trim(Me.txtTAPETARI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAPEAVIN.Text) = "" Then
                stTAPEAVIN = "%"
            Else
                stTAPEAVIN = Trim(Me.txtTAPEAVIN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAPEAVFI.Text) = "" Then
                stTAPEAVFI = "%"
            Else
                stTAPEAVFI = Trim(Me.txtTAPEAVFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAPEESTA.Text) = "" Then
                stTAPEESTA = "%"
            Else
                stTAPEESTA = Trim(Me.txtTAPEESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "TAPEIDRE , "
            stConsulta += "TAPEDEPA as 'Departamento', "
            stConsulta += "TAPEMUNI as 'Municipio', "
            stConsulta += "TAPECLSE as 'Sector', "
            stConsulta += "TAPEVIGE as 'Vigencia', "
            stConsulta += "TAPEDEEC as 'Destinación', "
            stConsulta += "TAPETARI as 'Tarifa', "
            stConsulta += "TAPEAVIN as 'Avalúo inicial', "
            stConsulta += "TAPEAVFI as 'Avalúo final', "
            stConsulta += "TAPEESTA as 'Estado' "
            stConsulta += "From TARIPRES "
            stConsulta += "Where "
            stConsulta += "TAPEDEPA like '" & stTAPEDEPA & "' and "
            stConsulta += "TAPEMUNI like '" & stTAPEMUNI & "' and "
            stConsulta += "TAPECLSE like '" & stTAPECLSE & "' and "
            stConsulta += "TAPEVIGE like '" & stTAPEVIGE & "' and "
            stConsulta += "TAPEDEEC like '" & stTAPEDEEC & "' and "
            stConsulta += "TAPETARI like '" & stTAPETARI & "' and "
            stConsulta += "TAPEAVIN like '" & stTAPEAVIN & "' and "
            stConsulta += "TAPEAVFI like '" & stTAPEAVFI & "' and "
            stConsulta += "TAPEESTA like '" & stTAPEESTA & "' "
            stConsulta += "Order by TAPEDEPA, TAPEMUNI, TAPECLSE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtTAPEDEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtTAPEDEPA.Text = ""
        Me.txtTAPEMUNI.Text = ""
        Me.txtTAPECLSE.Text = ""
        Me.txtTAPEVIGE.Text = ""
        Me.txtTAPEDEEC.Text = ""
        Me.txtTAPETARI.Text = ""
        Me.txtTAPEAVIN.Text = ""
        Me.txtTAPEAVFI.Text = ""
        Me.txtTAPEESTA.Text = ""

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
            Dim inId_Reg As New frm_TARIPRES(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtTAPEDEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtTAPEDEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtTAPEDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTAPEDEPA.KeyPress, txtTAPEMUNI.KeyPress, txtTAPECLSE.KeyPress, txtTAPEVIGE.KeyPress, txtTAPEDEEC.KeyPress, txtTAPETARI.KeyPress, txtTAPETARI.KeyPress, txtTAPEAVIN.KeyPress, txtTAPEAVFI.KeyPress, txtTAPEESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAPEDEPA.GotFocus, txtTAPEMUNI.GotFocus, txtTAPECLSE.GotFocus, txtTAPEVIGE.GotFocus, txtTAPEDEEC.GotFocus, txtTAPETARI.GotFocus, txtTAPETARI.GotFocus, txtTAPEAVIN.GotFocus, txtTAPEAVFI.GotFocus, txtTAPEESTA.GotFocus
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