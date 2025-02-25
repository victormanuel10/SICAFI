Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_RANGARTE

    '==========================================
    '*** CONSULTA RANGO DE AREAS DE TERRENO ***
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
            Dim stRAATDEPA As String = ""
            Dim stRAATMUNI As String = ""
            Dim stRAATCLSE As String = ""
            Dim stRAATATIN As String = ""
            Dim stRAATATFI As String = ""
            Dim stRAATPORC As String = ""
            Dim stRAATESTA As String = ""

            ' carga los campos
            If Trim(Me.txtRAATDEPA.Text) = "" Then
                stRAATDEPA = "%"
            Else
                stRAATDEPA = Trim(Me.txtRAATDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRAATMUNI.Text) = "" Then
                stRAATMUNI = "%"
            Else
                stRAATMUNI = Trim(Me.txtRAATMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRAATCLSE.Text) = "" Then
                stRAATCLSE = "%"
            Else
                stRAATCLSE = Trim(Me.txtRAATCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRAATATIN.Text) = "" Then
                stRAATATIN = "%"
            Else
                stRAATATIN = Trim(Me.txtRAATATIN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRAATATFI.Text) = "" Then
                stRAATATFI = "%"
            Else
                stRAATATFI = Trim(Me.txtRAATATFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRAATPORC.Text) = "" Then
                stRAATPORC = "%"
            Else
                stRAATPORC = Trim(Me.txtRAATPORC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRAATESTA.Text) = "" Then
                stRAATESTA = "%"
            Else
                stRAATESTA = Trim(Me.txtRAATESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "RAATIDRE , "
            stConsulta += "RAATDEPA as 'Departamento', "
            stConsulta += "RAATMUNI as 'Municipio', "
            stConsulta += "RAATCLSE as 'Sector', "
            stConsulta += "RAATATIN as 'Area inicial', "
            stConsulta += "RAATATFI as 'Area final', "
            stConsulta += "RAATPORC as 'Porcentaje', "
            stConsulta += "RAATESTA as 'Estado' "
            stConsulta += "From RANGARTE "
            stConsulta += "Where "
            stConsulta += "RAATDEPA like '" & stRAATDEPA & "' and "
            stConsulta += "RAATMUNI like '" & stRAATMUNI & "' and "
            stConsulta += "RAATCLSE like '" & stRAATCLSE & "' and "
            stConsulta += "RAATATIN like '" & stRAATATIN & "' and "
            stConsulta += "RAATATFI like '" & stRAATATFI & "' and "
            stConsulta += "RAATPORC like '" & stRAATPORC & "' and "
            stConsulta += "RAATESTA like '" & stRAATESTA & "' "
            stConsulta += "Order by RAATDEPA, RAATMUNI, RAATCLSE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)
            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtRAATDEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtRAATDEPA.Text = ""
        Me.txtRAATMUNI.Text = ""
        Me.txtRAATCLSE.Text = ""
        Me.txtRAATATIN.Text = ""
        Me.txtRAATATFI.Text = ""
        Me.txtRAATPORC.Text = ""
        Me.txtRAATESTA.Text = ""

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
            Dim inId_Reg As New frm_RANGARTE(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtRAATDEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtRAATDEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtRAATDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRAATDEPA.KeyPress, txtRAATMUNI.KeyPress, txtRAATCLSE.KeyPress, txtRAATATIN.KeyPress, txtRAATATFI.KeyPress, txtRAATPORC.KeyPress, txtRAATPORC.KeyPress, txtRAATESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRAATDEPA.GotFocus, txtRAATMUNI.GotFocus, txtRAATCLSE.GotFocus, txtRAATATIN.GotFocus, txtRAATATFI.GotFocus, txtRAATPORC.GotFocus, txtRAATPORC.GotFocus, txtRAATESTA.GotFocus
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