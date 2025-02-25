Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_TARIALPU

    '=========================================
    '*** CONSULTA TARIFA ALUMBRADO PUBLICO ***
    '=========================================

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
            Dim stTAAPDEPA As String = ""
            Dim stTAAPMUNI As String = ""
            Dim stTAAPCLSE As String = ""
            Dim stTAAPVIGE As String = ""
            Dim stTAAPTIPO As String = ""
            Dim stTAAPTARE As String = ""
            Dim stTAAPTACO As String = ""
            Dim stTAAPTAIN As String = ""
            Dim stTAAPESTR As String = ""
            Dim stTAAPTA01 As String = ""
            Dim stTAAPTA02 As String = ""
            Dim stTAAPTA03 As String = ""
            Dim stTAAPTA04 As String = ""
            Dim stTAAPTA05 As String = ""
            Dim stTAAPAVIN As String = ""
            Dim stTAAPAVFI As String = ""
            Dim stTAAPESTA As String = ""

            ' carga los campos
            If Trim(Me.txtTAAPDEPA.Text) = "" Then
                stTAAPDEPA = "%"
            Else
                stTAAPDEPA = Trim(Me.txtTAAPDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAAPMUNI.Text) = "" Then
                stTAAPMUNI = "%"
            Else
                stTAAPMUNI = Trim(Me.txtTAAPMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAAPCLSE.Text) = "" Then
                stTAAPCLSE = "%"
            Else
                stTAAPCLSE = Trim(Me.txtTAAPCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAAPVIGE.Text) = "" Then
                stTAAPVIGE = "%"
            Else
                stTAAPVIGE = Trim(Me.txtTAAPVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAAPTIPO.Text) = "" Then
                stTAAPTIPO = "%"
            Else
                stTAAPTIPO = Trim(Me.txtTAAPTIPO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAAPTARE.Text) = "" Then
                stTAAPTARE = "%"
            Else
                stTAAPTARE = Trim(Me.txtTAAPTARE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAAPTACO.Text) = "" Then
                stTAAPTACO = "%"
            Else
                stTAAPTACO = Trim(Me.txtTAAPTACO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAAPTAIN.Text) = "" Then
                stTAAPTAIN = "%"
            Else
                stTAAPTAIN = Trim(Me.txtTAAPTAIN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAAPESTR.Text) = "" Then
                stTAAPESTR = "%"
            Else
                stTAAPESTR = Trim(Me.txtTAAPESTR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAAPTA01.Text) = "" Then
                stTAAPTA01 = "%"
            Else
                stTAAPTA01 = Trim(Me.txtTAAPTA01.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAAPTA02.Text) = "" Then
                stTAAPTA02 = "%"
            Else
                stTAAPTA02 = Trim(Me.txtTAAPTA02.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAAPTA03.Text) = "" Then
                stTAAPTA03 = "%"
            Else
                stTAAPTA03 = Trim(Me.txtTAAPTA03.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAAPTA04.Text) = "" Then
                stTAAPTA04 = "%"
            Else
                stTAAPTA04 = Trim(Me.txtTAAPTA04.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAAPTA05.Text) = "" Then
                stTAAPTA05 = "%"
            Else
                stTAAPTA05 = Trim(Me.txtTAAPTA05.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAAPAVIN.Text) = "" Then
                stTAAPAVIN = "%"
            Else
                stTAAPAVIN = Trim(Me.txtTAAPAVIN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAAPAVFI.Text) = "" Then
                stTAAPAVFI = "%"
            Else
                stTAAPAVFI = Trim(Me.txtTAAPAVFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTAAPESTA.Text) = "" Then
                stTAAPESTA = "%"
            Else
                stTAAPESTA = Trim(Me.txtTAAPESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "TAAPIDRE , "
            stConsulta += "TAAPDEPA as 'Departamento', "
            stConsulta += "TAAPMUNI as 'Municipio', "
            stConsulta += "TAAPCLSE as 'Sector', "
            stConsulta += "TAAPVIGE as 'Vigencia', "
            stConsulta += "TAAPTIPO as 'Tipo', "
            stConsulta += "TAAPTARE as 'Ta. Residencial', "
            stConsulta += "TAAPTACO as 'Ta. Comercial', "
            stConsulta += "TAAPTAIN as 'Ta. Industrial', "
            stConsulta += "TAAPESTR as 'Estrato', "
            stConsulta += "TAAPTA01 as 'Tarifa 01', "
            stConsulta += "TAAPTA02 as 'Tarifa 02', "
            stConsulta += "TAAPTA03 as 'Tarifa 03', "
            stConsulta += "TAAPTA04 as 'Tarifa 04', "
            stConsulta += "TAAPTA05 as 'Tarifa 05', "
            stConsulta += "TAAPAVIN as 'Avalúo inicial', "
            stConsulta += "TAAPAVFI as 'Avalúo final', "
            stConsulta += "TAAPESTA as 'Estado' "
            stConsulta += "From TARIALPU "
            stConsulta += "Where "
            stConsulta += "TAAPDEPA like '" & stTAAPDEPA & "' and "
            stConsulta += "TAAPMUNI like '" & stTAAPMUNI & "' and "
            stConsulta += "TAAPCLSE like '" & stTAAPCLSE & "' and "
            stConsulta += "TAAPVIGE like '" & stTAAPVIGE & "' and "
            stConsulta += "TAAPTIPO like '" & stTAAPTIPO & "' and "
            stConsulta += "TAAPTARE like '" & stTAAPTARE & "' and "
            stConsulta += "TAAPTACO like '" & stTAAPTACO & "' and "
            stConsulta += "TAAPTAIN like '" & stTAAPTAIN & "' and "
            stConsulta += "TAAPESTR like '" & stTAAPESTR & "' and "
            stConsulta += "TAAPTA01 like '" & stTAAPTA01 & "' and "
            stConsulta += "TAAPTA02 like '" & stTAAPTA02 & "' and "
            stConsulta += "TAAPTA03 like '" & stTAAPTA03 & "' and "
            stConsulta += "TAAPTA04 like '" & stTAAPTA04 & "' and "
            stConsulta += "TAAPTA05 like '" & stTAAPTA05 & "' and "
            stConsulta += "TAAPAVIN like '" & stTAAPAVIN & "' and "
            stConsulta += "TAAPAVFI like '" & stTAAPAVFI & "' and "
            stConsulta += "TAAPESTA like '" & stTAAPESTA & "' "
            stConsulta += "Order by TAAPDEPA, TAAPMUNI, TAAPCLSE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtTAAPDEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtTAAPDEPA.Text = ""
        Me.txtTAAPMUNI.Text = ""
        Me.txtTAAPCLSE.Text = ""
        Me.txtTAAPVIGE.Text = ""
        Me.txtTAAPTIPO.Text = ""
        Me.txtTAAPTARE.Text = ""
        Me.txtTAAPTACO.Text = ""
        Me.txtTAAPTAIN.Text = ""
        Me.txtTAAPTA01.Text = ""
        Me.txtTAAPTA02.Text = ""
        Me.txtTAAPTA03.Text = ""
        Me.txtTAAPTA04.Text = ""
        Me.txtTAAPTA05.Text = ""
        Me.txtTAAPAVIN.Text = ""
        Me.txtTAAPAVFI.Text = ""
        Me.txtTAAPESTA.Text = ""

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
            Dim inId_Reg As New frm_TARIALPU(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtTAAPDEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtTAAPDEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtTAAPDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTAAPDEPA.KeyPress, txtTAAPMUNI.KeyPress, txtTAAPCLSE.KeyPress, txtTAAPVIGE.KeyPress, txtTAAPTIPO.KeyPress, txtTAAPTARE.KeyPress, txtTAAPTARE.KeyPress, txtTAAPTACO.KeyPress, txtTAAPTAIN.KeyPress, txtTAAPESTR.KeyPress, txtTAAPTA01.KeyPress, txtTAAPTA02.KeyPress, txtTAAPTA03.KeyPress, txtTAAPTA04.KeyPress, txtTAAPTA05.KeyPress, txtTAAPAVIN.KeyPress, txtTAAPAVFI.KeyPress, txtTAAPESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAAPDEPA.GotFocus, txtTAAPMUNI.GotFocus, txtTAAPCLSE.GotFocus, txtTAAPVIGE.GotFocus, txtTAAPTIPO.GotFocus, txtTAAPTARE.GotFocus, txtTAAPTARE.GotFocus, txtTAAPTACO.GotFocus, txtTAAPTAIN.GotFocus, txtTAAPESTR.GotFocus, txtTAAPTA01.GotFocus, txtTAAPTA02.GotFocus, txtTAAPTA03.GotFocus, txtTAAPTA04.GotFocus, txtTAAPTA05.GotFocus, txtTAAPAVIN.GotFocus, txtTAAPAVFI.GotFocus, txtTAAPESTA.GotFocus
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