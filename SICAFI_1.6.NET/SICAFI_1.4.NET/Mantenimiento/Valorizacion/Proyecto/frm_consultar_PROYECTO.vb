Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_PROYECTO

    '==========================
    '*** CONSULTA PROYECTOS ***
    '==========================

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
            Dim stPROYDEPA As String = ""
            Dim stPROYMUNI As String = ""
            Dim stPROYCLSE As String = ""
            Dim stPROYCODI As String = ""
            Dim stPROYDESC As String = ""
            Dim stPROYESTA As String = ""

            ' carga los campos
            If Trim(Me.txtPROYDEPA.Text) = "" Then
                stPROYDEPA = "%"
            Else
                stPROYDEPA = Trim(Me.txtPROYDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPROYMUNI.Text) = "" Then
                stPROYMUNI = "%"
            Else
                stPROYMUNI = Trim(Me.txtPROYMUNI.Text)
            End If

            If Trim(Me.txtPROYCLSE.Text) = "" Then
                stPROYCLSE = "%"
            Else
                stPROYCLSE = Trim(Me.txtPROYCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPROYCODI.Text) = "" Then
                stPROYCODI = "%"
            Else
                stPROYCODI = Trim(Me.txtPROYCODI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPROYDESC.Text) = "" Then
                stPROYDESC = "%"
            Else
                stPROYDESC = Trim(Me.txtPROYDESC.Text)
            End If

            If Trim(Me.txtPROYESTA.Text) = "" Then
                stPROYESTA = "%"
            Else
                stPROYESTA = Trim(Me.txtPROYESTA.Text)
            End If

            'TIIMatena la consulta
            stConsulta += "Select "
            stConsulta += "PROYIDRE , "
            stConsulta += "PROYDEPA as 'Departamento', "
            stConsulta += "PROYMUNI as 'Municipio', "
            stConsulta += "PROYCLSE as 'Sector', "
            stConsulta += "PROYCODI as 'Codigo', "
            stConsulta += "PROYDESC as 'Descripción', "
            stConsulta += "PROYESTA as 'Estado' "
            stConsulta += "From PROYECTO "
            stConsulta += "Where "
            stConsulta += "PROYDEPA like '" & stPROYDEPA & "' and "
            stConsulta += "PROYMUNI like '" & stPROYMUNI & "' and "
            stConsulta += "PROYCLSE like '" & stPROYCLSE & "' and "
            stConsulta += "PROYCODI like '" & stPROYCODI & "' and "
            stConsulta += "PROYDESC like '" & stPROYDESC & "' and "
            stConsulta += "PROYESTA like '" & stPROYESTA & "' "
            stConsulta += "Order by PROYDEPA, PROYMUNI, PROYCLSE, PROYCODI "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtPROYCODI.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtPROYDEPA.Text = ""
        Me.txtPROYMUNI.Text = ""
        Me.txtPROYCLSE.Text = ""
        Me.txtPROYCODI.Text = ""
        Me.txtPROYDESC.Text = ""
        Me.txtPROYESTA.Text = ""

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
            Dim inId_Reg As New frm_PROYECTO(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtPROYCODI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtPROYCODI.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtPROYDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPROYCODI.KeyPress, txtPROYDESC.KeyPress, txtPROYESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPROYCODI.GotFocus, txtPROYDESC.GotFocus, txtPROYESTA.GotFocus
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