Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_AJUSIMPR

    '===========================================
    '*** CONSULTA AJUSTE DE IMPUESTO PREDIAL ***
    '===========================================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False

    Dim dt As DataTable

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_Reconsultar()

        Try

            ' crea la variable de los campos
            Dim stAJIPMUNI As String = ""
            Dim stAJIPCORR As String = ""
            Dim stAJIPBARR As String = ""
            Dim stAJIPMANZ As String = ""
            Dim stAJIPPRED As String = ""
            Dim stAJIPEDIF As String = ""
            Dim stAJIPUNPR As String = ""
            Dim stAJIPCLSE As String = ""
            Dim stAJIPVIGE As String = ""
            Dim stAJIPMAIN As String = ""
            Dim stAJIPNUFI As String = ""
            Dim stAJIPNURA As String = ""
            Dim stAJIPFERA As String = ""
            Dim stAJIPNURE As String = ""
            Dim stAJIPFERE As String = ""
            Dim stAJIPNUOF As String = ""
            Dim stAJIPFEOF As String = ""
            Dim stAJIPESTA As String = ""
            Dim stAJIPOBSE As String = ""
            Dim stAJIPSECU As String = ""

            ' carga los campos
            If Trim(Me.txtAJIPSECU.Text) = "" Then
                stAJIPSECU = "%"
            Else
                stAJIPSECU = Trim(Me.txtAJIPSECU.Text)
            End If

            ' carga los campos
            If Trim(Me.txtAJIPMUNI.Text) = "" Then
                stAJIPMUNI = "%"
            Else
                stAJIPMUNI = Trim(Me.txtAJIPMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtAJIPCORR.Text) = "" Then
                stAJIPCORR = "%"
            Else
                stAJIPCORR = Trim(Me.txtAJIPCORR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtAJIPBARR.Text) = "" Then
                stAJIPBARR = "%"
            Else
                stAJIPBARR = Trim(Me.txtAJIPBARR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtAJIPMANZ.Text) = "" Then
                stAJIPMANZ = "%"
            Else
                stAJIPMANZ = Trim(Me.txtAJIPMANZ.Text)
            End If

            ' carga los campos
            If Trim(Me.txtAJIPPRED.Text) = "" Then
                stAJIPPRED = "%"
            Else
                stAJIPPRED = Trim(Me.txtAJIPPRED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtAJIPEDIF.Text) = "" Then
                stAJIPEDIF = "%"
            Else
                stAJIPEDIF = Trim(Me.txtAJIPEDIF.Text)
            End If

            ' carga los campos
            If Trim(Me.txtAJIPUNPR.Text) = "" Then
                stAJIPUNPR = "%"
            Else
                stAJIPUNPR = Trim(Me.txtAJIPUNPR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtAJIPCLSE.Text) = "" Then
                stAJIPCLSE = "%"
            Else
                stAJIPCLSE = Trim(Me.txtAJIPCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtAJIPVIGE.Text) = "" Then
                stAJIPVIGE = "%"
            Else
                stAJIPVIGE = Trim(Me.txtAJIPVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtAJIPNUFI.Text) = "" Then
                stAJIPNUFI = "%"
            Else
                stAJIPNUFI = Trim(Me.txtAJIPNUFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtAJIPMAIN.Text) = "" Then
                stAJIPMAIN = "%"
            Else
                stAJIPMAIN = Trim(Me.txtAJIPMAIN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtAJIPNURA.Text) = "" Then
                stAJIPNURA = "%"
            Else
                stAJIPNURA = Trim(Me.txtAJIPNURA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtAJIPFERA.Text) = "" Then
                stAJIPFERA = "%"
            Else
                stAJIPFERA = Trim(Me.txtAJIPFERA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtAJIPNURE.Text) = "" Then
                stAJIPNURE = "%"
            Else
                stAJIPNURE = Trim(Me.txtAJIPNURE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtAJIPFERE.Text) = "" Then
                stAJIPFERE = "%"
            Else
                stAJIPFERE = Trim(Me.txtAJIPFERE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtAJIPNUOF.Text) = "" Then
                stAJIPNUOF = "%"
            Else
                stAJIPNUOF = Trim(Me.txtAJIPNUOF.Text)
            End If

            ' carga los campos
            If Trim(Me.txtAJIPFEOF.Text) = "" Then
                stAJIPFEOF = "%"
            Else
                stAJIPFEOF = Trim(Me.txtAJIPFEOF.Text)
            End If

            ' carga los campos
            If Trim(Me.txtAJIPESTA.Text) = "" Then
                stAJIPESTA = "%"
            Else
                stAJIPESTA = Trim(Me.txtAJIPESTA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtAJIPOBSE.Text) = "" Then
                stAJIPOBSE = "%"
            Else
                stAJIPOBSE = Trim(Me.txtAJIPOBSE.Text)
            End If

            ' instancia un dt
            dt = New DataTable

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "AJIPIDRE , "
            stConsulta += "AJIPSECU as 'Nro. Tramite', "
            stConsulta += "AJIPMUNI as 'Municipio', "
            stConsulta += "AJIPCORR as 'Correg', "
            stConsulta += "AJIPBARR as 'Barrio', "
            stConsulta += "AJIPMANZ as 'Manzana', "
            stConsulta += "AJIPPRED as 'Predio', "
            stConsulta += "AJIPEDIF as 'Edicio', "
            stConsulta += "AJIPUNPR as 'Unidad', "
            stConsulta += "AJIPCLSE as 'Sector', "
            stConsulta += "AJIPVIGE as 'Vigencia', "
            stConsulta += "AJIPMAIN as 'Matricula', "
            stConsulta += "AJIPNUFI as 'Nro. Ficha', "
            stConsulta += "AJIPNURA as 'Nro. Radicado', "
            stConsulta += "AJIPFERA as 'Fecha Radicado', "
            stConsulta += "AJIPNURE as 'Nro. Resolución', "
            stConsulta += "AJIPFERE as 'Fecha Resolución', "
            stConsulta += "AJIPNUOF as 'Nro. Oficio', "
            stConsulta += "AJIPFEOF as 'Fecha Oficio', "
            stConsulta += "AJIPESTA as 'Estado', "
            stConsulta += "AJIPOBSE as 'Observación' "

            stConsulta += "From AJUSIMPR  "
            stConsulta += "Where "

            stConsulta += "AJIPMUNI like '" & stAJIPMUNI & "' and "
            stConsulta += "AJIPCORR like '" & stAJIPCORR & "' and "
            stConsulta += "AJIPBARR like '" & stAJIPBARR & "' and "
            stConsulta += "AJIPMANZ like '" & stAJIPMANZ & "' and "
            stConsulta += "AJIPPRED like '" & stAJIPPRED & "' and "
            stConsulta += "AJIPEDIF like '" & stAJIPEDIF & "' and "
            stConsulta += "AJIPUNPR like '" & stAJIPUNPR & "' and "
            stConsulta += "AJIPCLSE like '" & stAJIPCLSE & "' and "
            stConsulta += "AJIPVIGE like '" & stAJIPVIGE & "' and "
            stConsulta += "AJIPNUFI like '" & stAJIPNUFI & "' and "
            stConsulta += "AJIPMAIN like '" & stAJIPMAIN & "' and "
            stConsulta += "AJIPNURA like '" & stAJIPNURA & "' and "
            stConsulta += "AJIPFERA like '" & stAJIPFERA & "' and "
            stConsulta += "AJIPNURE like '" & stAJIPNURE & "' and "
            stConsulta += "AJIPFERE like '" & stAJIPFERE & "' and "
            stConsulta += "AJIPNUOF like '" & stAJIPNUOF & "' and "
            stConsulta += "AJIPFEOF like '" & stAJIPFEOF & "' and "
            stConsulta += "AJIPESTA like '" & stAJIPESTA & "' and "
            stConsulta += "AJIPOBSE like '" & stAJIPOBSE & "' and "
            stConsulta += "AJIPSECU like '" & stAJIPSECU & "' "

            stConsulta += "Order by AJIPSECU "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtAJIPMUNI.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtAJIPMUNI.Text = ""
        Me.txtAJIPCORR.Text = ""
        Me.txtAJIPBARR.Text = ""
        Me.txtAJIPMANZ.Text = ""
        Me.txtAJIPPRED.Text = ""
        Me.txtAJIPEDIF.Text = ""
        Me.txtAJIPUNPR.Text = ""
        Me.txtAJIPCLSE.Text = ""
        Me.txtAJIPVIGE.Text = ""
        Me.txtAJIPNUFI.Text = ""
        Me.txtAJIPMAIN.Text = ""
        Me.txtAJIPNURA.Text = ""
        Me.txtAJIPFERA.Text = ""
        Me.txtAJIPNURE.Text = ""
        Me.txtAJIPFERE.Text = ""
        Me.txtAJIPNUOF.Text = ""
        Me.txtAJIPFEOF.Text = ""
        Me.txtAJIPESTA.Text = ""
        Me.txtAJIPOBSE.Text = ""
        Me.txtAJIPSECU.Text = ""

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
            Dim inId_Reg As New frm_AJUSIMPR(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtAJIPMUNI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtAJIPMUNI.Focus()
    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try
            If Me.dgvCONSULTA.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvCONSULTA.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()

    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_consultar_TRABCAMP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.txtAJIPMUNI.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAJIPMUNI.KeyPress, txtAJIPCORR.KeyPress, txtAJIPBARR.KeyPress, txtAJIPMANZ.KeyPress, txtAJIPPRED.KeyPress, txtAJIPEDIF.KeyPress, txtAJIPUNPR.KeyPress, txtAJIPCLSE.KeyPress, txtAJIPVIGE.KeyPress, txtAJIPNUFI.KeyPress, txtAJIPMAIN.KeyPress, txtAJIPNURA.KeyPress, txtAJIPFERA.KeyPress, txtAJIPFERE.KeyPress, txtAJIPNURE.KeyPress, txtAJIPNUOF.KeyPress, txtAJIPFEOF.KeyPress, txtAJIPESTA.KeyPress, txtAJIPOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPMUNI.GotFocus, txtAJIPCORR.GotFocus, txtAJIPBARR.GotFocus, txtAJIPMANZ.GotFocus, txtAJIPPRED.GotFocus, txtAJIPEDIF.GotFocus, txtAJIPUNPR.GotFocus, txtAJIPCLSE.GotFocus, txtAJIPVIGE.GotFocus, txtAJIPNUFI.GotFocus, txtAJIPMAIN.GotFocus, txtAJIPNURA.GotFocus, txtAJIPFERA.GotFocus, txtAJIPFERE.GotFocus, txtAJIPNURE.GotFocus, txtAJIPNUOF.GotFocus, txtAJIPFEOF.GotFocus, txtAJIPESTA.GotFocus, txtAJIPOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdSalir.GotFocus, cmdConsultar.GotFocus, cmdLimpiar.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtAJIPMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPMUNI.Validated
        If Me.txtAJIPMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtAJIPMUNI.Text) = True Then
            Me.txtAJIPMUNI.Text = fun_Formato_Mascara_3_String(Me.txtAJIPMUNI.Text)
        End If
    End Sub
    Private Sub txtAJIPCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPCORR.Validated
        If Me.txtAJIPCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtAJIPCORR.Text) = True Then
            Me.txtAJIPCORR.Text = fun_Formato_Mascara_2_String(Me.txtAJIPCORR.Text)
        End If
    End Sub
    Private Sub txtAJIPBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPBARR.Validated
        If Me.txtAJIPBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtAJIPBARR.Text) = True Then
            Me.txtAJIPBARR.Text = fun_Formato_Mascara_3_String(Me.txtAJIPBARR.Text)
        End If
    End Sub
    Private Sub txtAJIPMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPMANZ.Validated
        If Me.txtAJIPMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtAJIPMANZ.Text) = True Then
            Me.txtAJIPMANZ.Text = fun_Formato_Mascara_3_String(Me.txtAJIPMANZ.Text)
        End If
    End Sub
    Private Sub txtAJIPPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPPRED.Validated
        If Me.txtAJIPPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtAJIPPRED.Text) = True Then
            Me.txtAJIPPRED.Text = fun_Formato_Mascara_5_String(Me.txtAJIPPRED.Text)
        End If
    End Sub
    Private Sub txtAJIPEDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPEDIF.Validated
        If Me.txtAJIPEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtAJIPEDIF.Text) = True Then
            Me.txtAJIPEDIF.Text = fun_Formato_Mascara_3_String(Me.txtAJIPEDIF.Text)
        End If
    End Sub
    Private Sub txtAJIPUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPUNPR.Validated
        If Me.txtAJIPUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtAJIPUNPR.Text) = True Then
            Me.txtAJIPUNPR.Text = fun_Formato_Mascara_5_String(Me.txtAJIPUNPR.Text)
        End If
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