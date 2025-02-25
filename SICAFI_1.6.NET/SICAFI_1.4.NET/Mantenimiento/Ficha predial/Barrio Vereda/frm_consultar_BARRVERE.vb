Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_BARRVERE

    '================================
    '*** CONSULTA BARRIO - VEREDA ***
    '================================

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
            Dim stBAVEDEPA As String = ""
            Dim stBAVEMUNI As String = ""
            Dim stBAVECLSE As String = ""
            Dim stBAVECODI As String = ""
            Dim stBAVEDESC As String = ""
            Dim stBAVEESTA As String = ""


            ' carga los campos
            If Trim(Me.txtBAVEDEPA.Text) = "" Then
                stBAVEDEPA = "%"
            Else
                stBAVEDEPA = Trim(Me.txtBAVEDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtBAVEMUNI.Text) = "" Then
                stBAVEMUNI = "%"
            Else
                stBAVEMUNI = Trim(Me.txtBAVEMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtBAVECLSE.Text) = "" Then
                stBAVECLSE = "%"
            Else
                stBAVECLSE = Trim(Me.txtBAVECLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtBAVECLSE.Text) = "" Then
                stBAVECLSE = "%"
            Else
                stBAVECLSE = Trim(Me.txtBAVECLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtBAVECODI.Text) = "" Then
                stBAVECODI = "%"
            Else
                stBAVECODI = Trim(Me.txtBAVECODI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtBAVEDESC.Text) = "" Then
                stBAVEDESC = "%"
            Else
                stBAVEDESC = Trim(Me.txtBAVEDESC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtBAVEESTA.Text) = "" Then
                stBAVEESTA = "%"
            Else
                stBAVEESTA = Trim(Me.txtBAVEESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "BAVEIDRE , "
            stConsulta += "BAVEDEPA as 'Departamento', "
            stConsulta += "BAVEMUNI as 'Municipio', "
            stConsulta += "BAVECLSE as 'Sector', "
            stConsulta += "BAVECODI as 'Barrio - Vereda', "
            stConsulta += "BAVEDESC as 'Descripción', "
            stConsulta += "BAVEESTA as 'Estado' "
            stConsulta += "From MANT_BARRVERE "
            stConsulta += "Where "
            stConsulta += "BAVEDEPA like '" & stBAVEDEPA & "' and "
            stConsulta += "BAVEMUNI like '" & stBAVEMUNI & "' and "
            stConsulta += "BAVECLSE like '" & stBAVECLSE & "' and "
            stConsulta += "BAVECODI like '" & stBAVECODI & "' and "
            stConsulta += "BAVEDESC like '" & stBAVEDESC & "' and "
            stConsulta += "BAVEESTA like '" & stBAVEESTA & "' "
            stConsulta += "Order by BAVEDEPA, BAVEMUNI, BAVECLSE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)
            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtBAVEDEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtBAVEDEPA.Text = ""
        Me.txtBAVEMUNI.Text = ""
        Me.txtBAVECLSE.Text = ""
        Me.txtBAVECODI.Text = ""
        Me.txtBAVEDESC.Text = ""
        Me.txtBAVEESTA.Text = ""

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
            Dim inId_Reg As New frm_VIGEACTU(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtBAVEDEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtBAVEDEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtBAVEDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBAVEDEPA.KeyPress, txtBAVEMUNI.KeyPress, txtBAVECLSE.KeyPress, txtBAVECODI.KeyPress, txtBAVEDESC.KeyPress, txtBAVEESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBAVEDEPA.GotFocus, txtBAVEMUNI.GotFocus, txtBAVECLSE.GotFocus, txtBAVECODI.GotFocus, txtBAVEDESC.GotFocus, txtBAVEESTA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
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