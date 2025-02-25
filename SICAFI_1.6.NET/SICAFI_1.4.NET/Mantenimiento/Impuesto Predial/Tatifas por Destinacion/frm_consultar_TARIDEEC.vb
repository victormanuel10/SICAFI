Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_TARIDEEC

    '=============================================
    '*** CONSULTA TARIFA POR DESTINO ECONOMICO ***
    '=============================================

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
            Dim stTADEDEPA As String = ""
            Dim stTADEMUNI As String = ""
            Dim stTADECLSE As String = ""
            Dim stTADEVIGE As String = ""
            Dim stTADEDEEC As String = ""
            Dim stTADETARI As String = ""
            Dim stTADEESTA As String = ""

            ' carga los campos
            If Trim(Me.txtTADEDEPA.Text) = "" Then
                stTADEDEPA = "%"
            Else
                stTADEDEPA = Trim(Me.txtTADEDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTADEMUNI.Text) = "" Then
                stTADEMUNI = "%"
            Else
                stTADEMUNI = Trim(Me.txtTADEMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTADECLSE.Text) = "" Then
                stTADECLSE = "%"
            Else
                stTADECLSE = Trim(Me.txtTADECLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTADEVIGE.Text) = "" Then
                stTADEVIGE = "%"
            Else
                stTADEVIGE = Trim(Me.txtTADEVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTADEDEEC.Text) = "" Then
                stTADEDEEC = "%"
            Else
                stTADEDEEC = Trim(Me.txtTADEDEEC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTADETARI.Text) = "" Then
                stTADETARI = "%"
            Else
                stTADETARI = Trim(Me.txtTADETARI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTADEESTA.Text) = "" Then
                stTADEESTA = "%"
            Else
                stTADEESTA = Trim(Me.txtTADEESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "TADEIDRE , "
            stConsulta += "TADEDEPA as 'Departamento', "
            stConsulta += "TADEMUNI as 'Municipio', "
            stConsulta += "TADECLSE as 'Sector', "
            stConsulta += "TADEVIGE as 'Vigencia', "
            stConsulta += "TADEDEEC as 'Destino', "
            stConsulta += "TADETARI as 'Tarifa', "
            stConsulta += "TADEESTA as 'Estado' "
            stConsulta += "From TARIDEEC "
            stConsulta += "Where "
            stConsulta += "TADEDEPA like '" & stTADEDEPA & "' and "
            stConsulta += "TADEMUNI like '" & stTADEMUNI & "' and "
            stConsulta += "TADECLSE like '" & stTADECLSE & "' and "
            stConsulta += "TADEVIGE like '" & stTADEVIGE & "' and "
            stConsulta += "TADEDEEC like '" & stTADEDEEC & "' and "
            stConsulta += "TADETARI like '" & stTADETARI & "' and "
            stConsulta += "TADEESTA like '" & stTADEESTA & "' "
            stConsulta += "Order by TADEDEPA, TADEMUNI, TADECLSE,TADEVIGE, TADEDEEC "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)
            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtTADEDEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtTADEDEPA.Text = ""
        Me.txtTADEMUNI.Text = ""
        Me.txtTADECLSE.Text = ""
        Me.txtTADEVIGE.Text = ""
        Me.txtTADEDEEC.Text = ""
        Me.txtTADETARI.Text = ""
        Me.txtTADEESTA.Text = ""

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
            Dim inId_Reg As New frm_TARIDEEC(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtTADEDEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtTADEDEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtTADEDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTADEDEPA.KeyPress, txtTADEMUNI.KeyPress, txtTADECLSE.KeyPress, txtTADEVIGE.KeyPress, txtTADEDEEC.KeyPress, txtTADETARI.KeyPress, txtTADETARI.KeyPress, txtTADEESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTADEDEPA.GotFocus, txtTADEMUNI.GotFocus, txtTADECLSE.GotFocus, txtTADEVIGE.GotFocus, txtTADEDEEC.GotFocus, txtTADETARI.GotFocus, txtTADETARI.GotFocus, txtTADEESTA.GotFocus
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