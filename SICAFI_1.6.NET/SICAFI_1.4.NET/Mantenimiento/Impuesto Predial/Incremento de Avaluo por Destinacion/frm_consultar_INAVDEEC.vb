Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_INAVDEEC

    '===========================================================
    '*** CONSULTA INCREMENTO DE AVALÚO POR DESTINO ECONOMICO ***
    '===========================================================

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
            Dim stIADEDEPA As String = ""
            Dim stIADEMUNI As String = ""
            Dim stIADECLSE As String = ""
            Dim stIADEVIGE As String = ""
            Dim stIADEDEEC As String = ""
            Dim stIADETARI As String = ""
            Dim stIADEESTA As String = ""

            ' carga los campos
            If Trim(Me.txtIADEDEPA.Text) = "" Then
                stIADEDEPA = "%"
            Else
                stIADEDEPA = Trim(Me.txtIADEDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtIADEMUNI.Text) = "" Then
                stIADEMUNI = "%"
            Else
                stIADEMUNI = Trim(Me.txtIADEMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtIADECLSE.Text) = "" Then
                stIADECLSE = "%"
            Else
                stIADECLSE = Trim(Me.txtIADECLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtIADEVIGE.Text) = "" Then
                stIADEVIGE = "%"
            Else
                stIADEVIGE = Trim(Me.txtIADEVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtIADEDEEC.Text) = "" Then
                stIADEDEEC = "%"
            Else
                stIADEDEEC = Trim(Me.txtIADEDEEC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtIADETARI.Text) = "" Then
                stIADETARI = "%"
            Else
                stIADETARI = Trim(Me.txtIADETARI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtIADEESTA.Text) = "" Then
                stIADEESTA = "%"
            Else
                stIADEESTA = Trim(Me.txtIADEESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "IADEIDRE , "
            stConsulta += "IADEDEPA as 'Departamento', "
            stConsulta += "IADEMUNI as 'Municipio', "
            stConsulta += "IADECLSE as 'Sector', "
            stConsulta += "IADEVIGE as 'Vigencia', "
            stConsulta += "IADEDEEC as 'Destino', "
            stConsulta += "IADETARI as 'Tarifa', "
            stConsulta += "IADEESTA as 'Estado' "
            stConsulta += "From INAVDEEC "
            stConsulta += "Where "
            stConsulta += "IADEDEPA like '" & stIADEDEPA & "' and "
            stConsulta += "IADEMUNI like '" & stIADEMUNI & "' and "
            stConsulta += "IADECLSE like '" & stIADECLSE & "' and "
            stConsulta += "IADEVIGE like '" & stIADEVIGE & "' and "
            stConsulta += "IADEDEEC like '" & stIADEDEEC & "' and "
            stConsulta += "IADETARI like '" & stIADETARI & "' and "
            stConsulta += "IADEESTA like '" & stIADEESTA & "' "
            stConsulta += "Order by IADEDEPA, IADEMUNI, IADECLSE,IADEVIGE, IADEDEEC "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)
            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtIADEDEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtIADEDEPA.Text = ""
        Me.txtIADEMUNI.Text = ""
        Me.txtIADECLSE.Text = ""
        Me.txtIADEVIGE.Text = ""
        Me.txtIADEDEEC.Text = ""
        Me.txtIADETARI.Text = ""
        Me.txtIADEESTA.Text = ""

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
            Dim inId_Reg As New frm_INAVDEEC(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtIADEDEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtIADEDEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtIADEDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIADEDEPA.KeyPress, txtIADEMUNI.KeyPress, txtIADECLSE.KeyPress, txtIADEVIGE.KeyPress, txtIADEDEEC.KeyPress, txtIADETARI.KeyPress, txtIADETARI.KeyPress, txtIADEESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIADEDEPA.GotFocus, txtIADEMUNI.GotFocus, txtIADECLSE.GotFocus, txtIADEVIGE.GotFocus, txtIADEDEEC.GotFocus, txtIADETARI.GotFocus, txtIADETARI.GotFocus, txtIADEESTA.GotFocus
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