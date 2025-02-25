Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_PUNTREQU

    '==================================
    '*** CONSULTA PUNTOS REQUERIDOS ***
    '==================================

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
            Dim stPUREDEPA As String = ""
            Dim stPUREMUNI As String = ""
            Dim stPURECLSE As String = ""
            Dim stPUREPURE As String = ""
            Dim stPUREESTA As String = ""

            ' carga los campos
            If Trim(Me.txtPUREDEPA.Text) = "" Then
                stPUREDEPA = "%"
            Else
                stPUREDEPA = Trim(Me.txtPUREDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPUREMUNI.Text) = "" Then
                stPUREMUNI = "%"
            Else
                stPUREMUNI = Trim(Me.txtPUREMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPURECLSE.Text) = "" Then
                stPURECLSE = "%"
            Else
                stPURECLSE = Trim(Me.txtPURECLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPUREPURE.Text) = "" Then
                stPUREPURE = "%"
            Else
                stPUREPURE = Trim(Me.txtPUREPURE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPUREESTA.Text) = "" Then
                stPUREESTA = "%"
            Else
                stPUREESTA = Trim(Me.txtPUREESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "PUREIDRE , "
            stConsulta += "PUREDEPA as 'Departamento', "
            stConsulta += "PUREMUNI as 'Municipio', "
            stConsulta += "PURECLSE as 'Sector', "
            stConsulta += "PUREPURE as 'Puntos requeridos', "
            stConsulta += "PUREESTA as 'Estado' "
            stConsulta += "From PUNTREQU "
            stConsulta += "Where "
            stConsulta += "PUREDEPA like '" & stPUREDEPA & "' and "
            stConsulta += "PUREMUNI like '" & stPUREMUNI & "' and "
            stConsulta += "PURECLSE like '" & stPURECLSE & "' and "
            stConsulta += "PUREPURE like '" & stPUREPURE & "' and "
            stConsulta += "PUREESTA like '" & stPUREESTA & "' "
            stConsulta += "Order by PUREDEPA, PUREMUNI, PURECLSE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)
            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtPUREDEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtPUREDEPA.Text = ""
        Me.txtPUREMUNI.Text = ""
        Me.txtPURECLSE.Text = ""
        Me.txtPUREPURE.Text = ""
        Me.txtPUREESTA.Text = ""

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
            Dim inId_Reg As New frm_PUNTREQU(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtPUREDEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtPUREDEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtPUREDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPUREDEPA.KeyPress, txtPUREMUNI.KeyPress, txtPURECLSE.KeyPress, txtPUREPURE.KeyPress, txtPUREPURE.KeyPress, txtPUREESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPUREDEPA.GotFocus, txtPUREMUNI.GotFocus, txtPURECLSE.GotFocus, txtPUREPURE.GotFocus, txtPUREPURE.GotFocus, txtPUREESTA.GotFocus
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