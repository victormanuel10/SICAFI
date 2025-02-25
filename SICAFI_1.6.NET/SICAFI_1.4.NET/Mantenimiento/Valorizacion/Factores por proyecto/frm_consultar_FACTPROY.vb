Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_FACTPROY

    '=========================
    '*** CONSULTA FACTORES ***
    '=========================

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
            Dim stFAPRDEPA As String = ""
            Dim stFAPRMUNI As String = ""
            Dim stFAPRCLSE As String = ""
            Dim stFAPRPROY As String = ""
            Dim stFAPRTIVA As String = ""
            Dim stFAPRVARI As String = ""
            Dim stFAPRDESC As String = ""
            Dim stFAPRESTA As String = ""

            ' carga los campos
            If Trim(Me.txtFAPRDEPA.Text) = "" Then
                stFAPRDEPA = "%"
            Else
                stFAPRDEPA = Trim(Me.txtFAPRDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtFAPRMUNI.Text) = "" Then
                stFAPRMUNI = "%"
            Else
                stFAPRMUNI = Trim(Me.txtFAPRMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtFAPRCLSE.Text) = "" Then
                stFAPRCLSE = "%"
            Else
                stFAPRCLSE = Trim(Me.txtFAPRCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtFAPRPROY.Text) = "" Then
                stFAPRPROY = "%"
            Else
                stFAPRPROY = Trim(Me.txtFAPRPROY.Text)
            End If

            ' carga los campos
            If Trim(Me.txtFAPRTIVA.Text) = "" Then
                stFAPRTIVA = "%"
            Else
                stFAPRTIVA = Trim(Me.txtFAPRTIVA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtFAPRVARI.Text) = "" Then
                stFAPRVARI = "%"
            Else
                stFAPRVARI = Trim(Me.txtFAPRVARI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtFAPRDESC.Text) = "" Then
                stFAPRDESC = "%"
            Else
                stFAPRDESC = Trim(Me.txtFAPRDESC.Text)
            End If

            If Trim(Me.txtFAPRESTA.Text) = "" Then
                stFAPRESTA = "%"
            Else
                stFAPRESTA = Trim(Me.txtFAPRESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "FAPRIDRE , "
            stConsulta += "FAPRDEPA as 'Depart.', "
            stConsulta += "FAPRMUNI as 'Municipio', "
            stConsulta += "FAPRCLSE as 'Sector', "
            stConsulta += "FAPRPROY as 'Proyecto', "
            stConsulta += "FAPRTIVA as 'Tipo Variable', "
            stConsulta += "FAPRVARI as 'Variable', "
            stConsulta += "FAPRDESC as 'Descripción', "
            stConsulta += "FAPRESTA as 'Estado' "
            stConsulta += "From MANT_FACTPROY "
            stConsulta += "Where "
            stConsulta += "FAPRDEPA like '" & stFAPRDEPA & "' and "
            stConsulta += "FAPRMUNI like '" & stFAPRMUNI & "' and "
            stConsulta += "FAPRCLSE like '" & stFAPRCLSE & "' and "
            stConsulta += "FAPRPROY like '" & stFAPRPROY & "' and "
            stConsulta += "FAPRTIVA like '" & stFAPRTIVA & "' and "
            stConsulta += "FAPRVARI like '" & stFAPRVARI & "' and "
            stConsulta += "FAPRDESC like '" & stFAPRDESC & "' and "
            stConsulta += "FAPRESTA like '" & stFAPRESTA & "' "
            stConsulta += "Order by FAPRDEPA, FAPRMUNI, FAPRCLSE, FAPRPROY, FAPRTIVA, FAPRVARI "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtFAPRVARI.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtFAPRTIVA.Text = ""
        Me.txtFAPRVARI.Text = ""
        Me.txtFAPRDESC.Text = ""
        Me.txtFAPRESTA.Text = ""

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
            Dim inId_Reg As New frm_FACTPROY(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtFAPRVARI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtFAPRVARI.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtFAPRTIVA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFAPRVARI.KeyPress, txtFAPRDESC.KeyPress, txtFAPRESTA.KeyPress, txtFAPRTIVA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFAPRVARI.GotFocus, txtFAPRDESC.GotFocus, txtFAPRESTA.GotFocus, txtFAPRTIVA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmdAceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#End Region

End Class