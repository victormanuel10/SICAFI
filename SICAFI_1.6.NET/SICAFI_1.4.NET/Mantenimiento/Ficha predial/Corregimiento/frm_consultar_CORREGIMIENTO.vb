Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_CORREGIMIENTO

    '==============================
    '*** CONSULTA CORREGIMIENTO ***
    '==============================

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
            Dim stCORRDEPA As String = ""
            Dim stCORRMUNI As String = ""
            Dim stCORRCLSE As String = ""
            Dim stCORRCODI As String = ""
            Dim stCORRDESC As String = ""
            Dim stCORRESTA As String = ""


            ' carga los campos
            If Trim(Me.txtCORRDEPA.Text) = "" Then
                stCORRDEPA = "%"
            Else
                stCORRDEPA = Trim(Me.txtCORRDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCORRMUNI.Text) = "" Then
                stCORRMUNI = "%"
            Else
                stCORRMUNI = Trim(Me.txtCORRMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCORRCLSE.Text) = "" Then
                stCORRCLSE = "%"
            Else
                stCORRCLSE = Trim(Me.txtCORRCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCORRCLSE.Text) = "" Then
                stCORRCLSE = "%"
            Else
                stCORRCLSE = Trim(Me.txtCORRCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCORRCODI.Text) = "" Then
                stCORRCODI = "%"
            Else
                stCORRCODI = Trim(Me.txtCORRCODI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCORRDESC.Text) = "" Then
                stCORRDESC = "%"
            Else
                stCORRDESC = Trim(Me.txtCORRDESC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCORRESTA.Text) = "" Then
                stCORRESTA = "%"
            Else
                stCORRESTA = Trim(Me.txtCORRESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "CORRIDRE , "
            stConsulta += "CORRDEPA as 'Departamento', "
            stConsulta += "CORRMUNI as 'Municipio', "
            stConsulta += "CORRCLSE as 'Sector', "
            stConsulta += "CORRCODI as 'Corregimiento', "
            stConsulta += "CORRDESC as 'Descripción', "
            stConsulta += "CORRESTA as 'Estado' "
            stConsulta += "From MANT_CORREGIMIENTO "
            stConsulta += "Where "
            stConsulta += "CORRDEPA like '" & stCORRDEPA & "' and "
            stConsulta += "CORRMUNI like '" & stCORRMUNI & "' and "
            stConsulta += "CORRCLSE like '" & stCORRCLSE & "' and "
            stConsulta += "CORRCODI like '" & stCORRCODI & "' and "
            stConsulta += "CORRDESC like '" & stCORRDESC & "' and "
            stConsulta += "CORRESTA like '" & stCORRESTA & "' "
            stConsulta += "Order by CORRDEPA, CORRMUNI, CORRCLSE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)
            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtCORRDEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtCORRDEPA.Text = ""
        Me.txtCORRMUNI.Text = ""
        Me.txtCORRCLSE.Text = ""
        Me.txtCORRCODI.Text = ""
        Me.txtCORRDESC.Text = ""
        Me.txtCORRESTA.Text = ""

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
            Me.txtCORRDEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtCORRDEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtCORRDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCORRDEPA.KeyPress, txtCORRMUNI.KeyPress, txtCORRCLSE.KeyPress, txtCORRCODI.KeyPress, txtCORRDESC.KeyPress, txtCORRESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCORRDEPA.GotFocus, txtCORRMUNI.GotFocus, txtCORRCLSE.GotFocus, txtCORRCODI.GotFocus, txtCORRDESC.GotFocus, txtCORRESTA.GotFocus
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