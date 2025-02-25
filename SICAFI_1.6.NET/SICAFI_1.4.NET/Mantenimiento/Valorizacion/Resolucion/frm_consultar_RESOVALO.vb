Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_RESOVALO

    '===========================================
    '*** CONSULTA RESOLUCIÓN DE VALORIZACIÓN ***
    '===========================================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False

    Dim dt As DataTable

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_Reconsultar()
        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stREVADEPA As String = ""
            Dim stREVAMUNI As String = ""
            Dim stREVACLSE As String = ""
            Dim stREVAVIGE As String = ""
            Dim stREVAPROY As String = ""
            Dim stREVATIRE As String = ""
            Dim stREVARESO As String = ""
            Dim stREVADESC As String = ""
            Dim stREVAESTA As String = ""

            ' carga los campos
            If Trim(Me.txtREVADEPA.Text) = "" Then
                stREVADEPA = "%"
            Else
                stREVADEPA = Trim(Me.txtREVADEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREVAMUNI.Text) = "" Then
                stREVAMUNI = "%"
            Else
                stREVAMUNI = Trim(Me.txtREVAMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREVACLSE.Text) = "" Then
                stREVACLSE = "%"
            Else
                stREVACLSE = Trim(Me.txtREVACLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREVAVIGE.Text) = "" Then
                stREVAVIGE = "%"
            Else
                stREVAVIGE = Trim(Me.txtREVAVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREVAPROY.Text) = "" Then
                stREVAPROY = "%"
            Else
                stREVAPROY = Trim(Me.txtREVAPROY.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREVATIRE.Text) = "" Then
                stREVATIRE = "%"
            Else
                stREVATIRE = Trim(Me.txtREVATIRE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPROYRESO.Text) = "" Then
                stREVARESO = "%"
            Else
                stREVARESO = Trim(Me.txtPROYRESO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREVADESC.Text) = "" Then
                stREVADESC = "%"
            Else
                stREVADESC = Trim(Me.txtREVADESC.Text)
            End If

            If Trim(Me.txtPROYESTA.Text) = "" Then
                stREVAESTA = "%"
            Else
                stREVAESTA = Trim(Me.txtPROYESTA.Text)
            End If

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            ' concatena la consulta
            stConsulta += "Select "
            stConsulta += "REVAIDRE , "
            stConsulta += "REVADEPA as 'Departamento', "
            stConsulta += "REVAMUNI as 'Municipio', "
            stConsulta += "REVACLSE as 'Sector', "
            stConsulta += "REVAVIGE as 'Vigencia', "
            stConsulta += "REVAPROY as 'Proyecto', "
            stConsulta += "REVATIRE as 'Tipo Resolución', "
            stConsulta += "REVARESO as 'Resolución', "
            stConsulta += "REVADESC as 'Descripción', "
            stConsulta += "REVAESTA as 'Estado' "
            stConsulta += "From RESOVALO "
            stConsulta += "Where "
            stConsulta += "REVADEPA like '" & stREVADEPA & "' and "
            stConsulta += "REVAMUNI like '" & stREVAMUNI & "' and "
            stConsulta += "REVACLSE like '" & stREVACLSE & "' and "
            stConsulta += "REVAVIGE like '" & stREVAVIGE & "' and "
            stConsulta += "REVAPROY like '" & stREVAPROY & "' and "
            stConsulta += "REVARESO like '" & stREVARESO & "' and "
            stConsulta += "REVADESC like '" & stREVADESC & "' and "
            stConsulta += "REVAESTA like '" & stREVAESTA & "' "
            stConsulta += "Order by REVADEPA, REVAMUNI, REVACLSE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtPROYRESO.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtREVADEPA.Text = ""
        Me.txtREVAMUNI.Text = ""
        Me.txtREVACLSE.Text = ""
        Me.txtREVAVIGE.Text = ""
        Me.txtREVATIRE.Text = ""
        Me.txtREVAPROY.Text = ""
        Me.txtPROYRESO.Text = ""
        Me.txtREVADESC.Text = ""
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
            Dim inId_Reg As New frm_RESOVALO(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtPROYRESO.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtPROYRESO.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtREVADEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPROYRESO.KeyPress, txtREVADESC.KeyPress, txtPROYESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPROYRESO.GotFocus, txtREVADESC.GotFocus, txtPROYESTA.GotFocus
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