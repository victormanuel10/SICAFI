Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_TARIZOEC

    '======================================
    '*** CONSULTA TARIFA ZONA ECONOMICA ***
    '======================================

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
            Dim stTAZEDEPA As String = ""
            Dim stTAZEMUNI As String = ""
            Dim stTAZECLSE As String = ""
            Dim stTAZEVIGE As String = ""
            Dim stTAZEZOEC As String = ""
            Dim stTAZEZOAP As String = ""
            Dim stTAZETA01 As String = ""
            Dim stTAZETA02 As String = ""
            Dim stTAZETA03 As String = ""
            Dim stTAZETA04 As String = ""
            Dim stTAZETA05 As String = ""
            Dim stTAZETA06 As String = ""
            Dim stTAZEESTA As String = ""

            ' carga los campos
            If Trim(Me.txtTAZEDEPA.Text) = "" Then
                stTAZEDEPA = "%"
            Else
                stTAZEDEPA = Trim(Me.txtTAZEDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZEMUNI.Text) = "" Then
                stTAZEMUNI = "%"
            Else
                stTAZEMUNI = Trim(Me.txtTAZEMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZECLSE.Text) = "" Then
                stTAZECLSE = "%"
            Else
                stTAZECLSE = Trim(Me.txtTAZECLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZEVIGE.Text) = "" Then
                stTAZEVIGE = "%"
            Else
                stTAZEVIGE = Trim(Me.txtTAZEVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZEZOEC.Text) = "" Then
                stTAZEZOEC = "%"
            Else
                stTAZEZOEC = Trim(Me.txtTAZEZOEC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZEZOAP.Text) = "" Then
                stTAZEZOAP = "%"
            Else
                stTAZEZOAP = Trim(Me.txtTAZEZOAP.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZETA01.Text) = "" Then
                stTAZETA01 = "%"
            Else
                stTAZETA01 = Trim(Me.txtTAZETA01.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZETA02.Text) = "" Then
                stTAZETA02 = "%"
            Else
                stTAZETA02 = Trim(Me.txtTAZETA02.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZETA03.Text) = "" Then
                stTAZETA03 = "%"
            Else
                stTAZETA03 = Trim(Me.txtTAZETA03.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZETA04.Text) = "" Then
                stTAZETA04 = "%"
            Else
                stTAZETA04 = Trim(Me.txtTAZETA04.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZETA05.Text) = "" Then
                stTAZETA05 = "%"
            Else
                stTAZETA05 = Trim(Me.txtTAZETA05.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZETA06.Text) = "" Then
                stTAZETA06 = "%"
            Else
                stTAZETA06 = Trim(Me.txtTAZETA06.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAZEESTA.Text) = "" Then
                stTAZEESTA = "%"
            Else
                stTAZEESTA = Trim(Me.txtTAZEESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "TAZEIDRE , "
            stConsulta += "TAZEDEPA as 'Departamento', "
            stConsulta += "TAZEMUNI as 'Municipio', "
            stConsulta += "TAZECLSE as 'Sector', "
            stConsulta += "TAZEVIGE as 'Vigencia', "
            stConsulta += "TAZEZOEC as 'Zona economica', "
            stConsulta += "TAZEZOAP as 'Zona aplicada', "
            stConsulta += "TAZETA01 as 'Tarifa 01', "
            stConsulta += "TAZETA02 as 'Tarifa 02', "
            stConsulta += "TAZETA03 as 'Tarifa 03', "
            stConsulta += "TAZETA04 as 'Tarifa 04', "
            stConsulta += "TAZETA05 as 'Tarifa 05', "
            stConsulta += "TAZETA06 as 'Tarifa 06', "
            stConsulta += "TAZEESTA as 'Estado' "
            stConsulta += "From TARIZOEC "
            stConsulta += "Where "
            stConsulta += "TAZEDEPA like '" & stTAZEDEPA & "' and "
            stConsulta += "TAZEMUNI like '" & stTAZEMUNI & "' and "
            stConsulta += "TAZECLSE like '" & stTAZECLSE & "' and "
            stConsulta += "TAZEVIGE like '" & stTAZEVIGE & "' and "
            stConsulta += "TAZEZOEC like '" & stTAZEZOEC & "' and "
            stConsulta += "TAZEZOAP like '" & stTAZEZOAP & "' and "
            stConsulta += "TAZETA01 like '" & stTAZETA01 & "' and "
            stConsulta += "TAZETA02 like '" & stTAZETA02 & "' and "
            stConsulta += "TAZETA03 like '" & stTAZETA03 & "' and "
            stConsulta += "TAZETA04 like '" & stTAZETA04 & "' and "
            stConsulta += "TAZETA05 like '" & stTAZETA05 & "' and "
            stConsulta += "TAZETA06 like '" & stTAZETA06 & "' and "
            stConsulta += "TAZEESTA like '" & stTAZEESTA & "' "
            stConsulta += "Order by TAZEDEPA, TAZEMUNI, TAZEVIGE, TAZECLSE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtTAZEDEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtTAZEDEPA.Text = ""
        Me.txtTAZEMUNI.Text = ""
        Me.txtTAZECLSE.Text = ""
        Me.txtTAZEVIGE.Text = ""
        Me.txtTAZEZOEC.Text = ""
        Me.txtTAZEZOAP.Text = ""
        Me.txtTAZETA01.Text = ""
        Me.txtTAZETA02.Text = ""
        Me.txtTAZETA03.Text = ""
        Me.txtTAZETA04.Text = ""
        Me.txtTAZETA05.Text = ""
        Me.txtTAZETA06.Text = ""
        Me.txtTAZEESTA.Text = ""

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
            Dim inId_Reg As New frm_TARIZOEC(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtTAZEDEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtTAZEDEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtTAZEDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTAZEDEPA.KeyPress, txtTAZEMUNI.KeyPress, txtTAZECLSE.KeyPress, txtTAZEVIGE.KeyPress, txtTAZEZOEC.KeyPress, txtTAZEZOAP.KeyPress, txtTAZEZOAP.KeyPress, txtTAZETA01.KeyPress, txtTAZETA02.KeyPress, txtTAZETA03.KeyPress, txtTAZETA04.KeyPress, txtTAZETA05.KeyPress, txtTAZEESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAZEDEPA.GotFocus, txtTAZEMUNI.GotFocus, txtTAZECLSE.GotFocus, txtTAZEVIGE.GotFocus, txtTAZEZOEC.GotFocus, txtTAZEZOAP.GotFocus, txtTAZEZOAP.GotFocus, txtTAZETA01.GotFocus, txtTAZETA02.GotFocus, txtTAZETA03.GotFocus, txtTAZETA04.GotFocus, txtTAZETA05.GotFocus, txtTAZEESTA.GotFocus
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