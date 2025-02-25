Imports REGLAS_DEL_NEGOCIO

Public Class frm_consulta_SUJEIMPU

    '===================================
    '*** CONSULTA SUJETO DE IMPUESTO ***
    '===================================

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
            Dim stSUIMNUFI As String = ""
            Dim stSUIMMUNI As String = ""
            Dim stSUIMCORR As String = ""
            Dim stSUIMBARR As String = ""
            Dim stSUIMMANZ As String = ""
            Dim stSUIMPRED As String = ""
            Dim stSUIMEDIF As String = ""
            Dim stSUIMUNPR As String = ""
            Dim stSUIMCLSE As String = ""
            Dim stSUIMMUAN As String = ""
            Dim stSUIMCOAN As String = ""
            Dim stSUIMBAAN As String = ""
            Dim stSUIMMAAN As String = ""
            Dim stSUIMPRAN As String = ""
            Dim stSUIMEDAN As String = ""
            Dim stSUIMUPAN As String = ""
            Dim stSUIMCSAN As String = ""

            Dim stSUIMSUAN As String = ""
            Dim stSUIMSUAC As String = ""
            Dim stSUIMVIAN As String = ""
            Dim stSUIMVIAC As String = ""
            Dim stSUIMMAIN As String = ""
            Dim stSUIMDIRE As String = ""
            Dim stSUIMCAPR As String = ""
            Dim stSUIMESTA As String = ""

            ' carga los campos
            If Trim(Me.txtSUIMNUFI.Text) = "" Then
                stSUIMNUFI = "%"
            Else
                stSUIMNUFI = Trim(Me.txtSUIMNUFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMMUNI.Text) = "" Then
                stSUIMMUNI = "%"
            Else
                stSUIMMUNI = Trim(Me.txtSUIMMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMCORR.Text) = "" Then
                stSUIMCORR = "%"
            Else
                stSUIMCORR = Trim(Me.txtSUIMCORR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMBARR.Text) = "" Then
                stSUIMBARR = "%"
            Else
                stSUIMBARR = Trim(Me.txtSUIMBARR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMMANZ.Text) = "" Then
                stSUIMMANZ = "%"
            Else
                stSUIMMANZ = Trim(Me.txtSUIMMANZ.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMPRED.Text) = "" Then
                stSUIMPRED = "%"
            Else
                stSUIMPRED = Trim(Me.txtSUIMPRED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMEDIF.Text) = "" Then
                stSUIMEDIF = "%"
            Else
                stSUIMEDIF = Trim(Me.txtSUIMEDIF.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMUNPR.Text) = "" Then
                stSUIMUNPR = "%"
            Else
                stSUIMUNPR = Trim(Me.txtSUIMUNPR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMCLSE.Text) = "" Then
                stSUIMCLSE = "%"
            Else
                stSUIMCLSE = Trim(Me.txtSUIMCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMSUAN.Text) = "" Then
                stSUIMSUAN = "%"
            Else
                stSUIMSUAN = Trim(Me.txtSUIMSUAN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMSUAC.Text) = "" Then
                stSUIMSUAC = "%"
            Else
                stSUIMSUAC = Trim(Me.txtSUIMSUAC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMVIAC.Text) = "" Then
                stSUIMVIAC = "%"
            Else
                stSUIMVIAC = Trim(Me.txtSUIMVIAC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMVIAN.Text) = "" Then
                stSUIMVIAN = "%"
            Else
                stSUIMVIAN = Trim(Me.txtSUIMVIAN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMMAIN.Text) = "" Then
                stSUIMMAIN = "%"
            Else
                stSUIMMAIN = Trim(Me.txtSUIMMAIN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMCAPR.Text) = "" Then
                stSUIMCAPR = "%"
            Else
                stSUIMCAPR = Trim(Me.txtSUIMCAPR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMDIRE.Text) = "" Then
                stSUIMDIRE = "%"
            Else
                stSUIMDIRE = Trim(Me.txtSUIMDIRE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMESTA.Text) = "" Then
                stSUIMESTA = "%"
            Else
                stSUIMESTA = Trim(Me.txtSUIMESTA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMMUAN.Text) = "" Then
                stSUIMMUAN = "%"
            Else
                stSUIMMUAN = Trim(Me.txtSUIMMUAN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMCOAN.Text) = "" Then
                stSUIMCOAN = "%"
            Else
                stSUIMCOAN = Trim(Me.txtSUIMCOAN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMBAAN.Text) = "" Then
                stSUIMBAAN = "%"
            Else
                stSUIMBAAN = Trim(Me.txtSUIMBAAN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMMAAN.Text) = "" Then
                stSUIMMAAN = "%"
            Else
                stSUIMMAAN = Trim(Me.txtSUIMMAAN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMPRAN.Text) = "" Then
                stSUIMPRAN = "%"
            Else
                stSUIMPRAN = Trim(Me.txtSUIMPRAN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMEDAN.Text) = "" Then
                stSUIMEDAN = "%"
            Else
                stSUIMEDAN = Trim(Me.txtSUIMEDAN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMUPAN.Text) = "" Then
                stSUIMUPAN = "%"
            Else
                stSUIMUPAN = Trim(Me.txtSUIMUPAN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtSUIMCSAN.Text) = "" Then
                stSUIMCSAN = "%"
            Else
                stSUIMCSAN = Trim(Me.txtSUIMCSAN.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "SUIMIDRE, "
            stConsulta += "SUIMNUFI as 'Nro_Ficha', "
            stConsulta += "SUIMMUNI as 'Municipio actual', "
            stConsulta += "SUIMCORR as 'Correg actual', "
            stConsulta += "SUIMBARR as 'Barrio actual', "
            stConsulta += "SUIMMANZ as 'Manzana actual', "
            stConsulta += "SUIMPRED as 'Predio actual', "
            stConsulta += "SUIMEDIF as 'Edificio actual', "
            stConsulta += "SUIMUNPR as 'Unidad actual', "
            stConsulta += "SUIMCLSE as 'Sector actual', "
            stConsulta += "SUIMMUAN as 'Municipio anterior', "
            stConsulta += "SUIMCOAN as 'Correg anterior', "
            stConsulta += "SUIMBAAN as 'Barrio anterior', "
            stConsulta += "SUIMMAAN as 'Manzana anterior', "
            stConsulta += "SUIMPRAN as 'Predio anterior', "
            stConsulta += "SUIMEDAN as 'Edificio anterior', "
            stConsulta += "SUIMUPAN as 'Unidad anterior', "
            stConsulta += "SUIMCSAN as 'Sector anterior', "
            stConsulta += "SUIMESTA as 'Estado' "
            stConsulta += "From SUJEIMPU "
            stConsulta += "Where "
            stConsulta += "SUIMNUFI like '" & Trim(stSUIMNUFI) & "%' and "
            stConsulta += "SUIMMUNI like '" & Trim(stSUIMMUNI) & "%' and "
            stConsulta += "SUIMCORR like '" & Trim(stSUIMCORR) & "%' and "
            stConsulta += "SUIMBARR like '" & Trim(stSUIMBARR) & "%' and "
            stConsulta += "SUIMMANZ like '" & Trim(stSUIMMANZ) & "%' and "
            stConsulta += "SUIMPRED like '" & Trim(stSUIMPRED) & "%' and "
            stConsulta += "SUIMEDIF like '" & Trim(stSUIMEDIF) & "%' and "
            stConsulta += "SUIMUNPR like '" & Trim(stSUIMUNPR) & "%' and "
            stConsulta += "SUIMMUAN like '" & Trim(stSUIMMUAN) & "%' and "
            stConsulta += "SUIMCOAN like '" & Trim(stSUIMCOAN) & "%' and "
            stConsulta += "SUIMBAAN like '" & Trim(stSUIMBAAN) & "%' and "
            stConsulta += "SUIMMAAN like '" & Trim(stSUIMMAAN) & "%' and "
            stConsulta += "SUIMPRAN like '" & Trim(stSUIMPRAN) & "%' and "
            stConsulta += "SUIMEDAN like '" & Trim(stSUIMEDAN) & "%' and "
            stConsulta += "SUIMUPAN like '" & Trim(stSUIMUPAN) & "%' and "
            stConsulta += "SUIMSUAN like '" & Trim(stSUIMSUAN) & "%' and "
            stConsulta += "SUIMSUAC like '" & Trim(stSUIMSUAC) & "%' and "
            stConsulta += "SUIMVIAN like '" & Trim(stSUIMVIAN) & "%' and "
            stConsulta += "SUIMVIAC like '" & Trim(stSUIMVIAC) & "%' and "
            stConsulta += "SUIMMAIN like '" & Trim(stSUIMMAIN) & "%' and "
            stConsulta += "SUIMCAPR like '" & Trim(stSUIMCAPR) & "%' and "
            stConsulta += "SUIMDIRE like '" & Trim(stSUIMDIRE) & "%' and "
            stConsulta += "SUIMCLSE like '" & Trim(stSUIMCLSE) & "%' and "
            stConsulta += "SUIMCSAN like '" & Trim(stSUIMCSAN) & "%' and "
            stConsulta += "SUIMESTA like '" & Trim(stSUIMESTA) & "%' "
            stConsulta += "Order by SUIMCLSE, SUIMMUNI, SUIMCORR, SUIMBARR, SUIMMANZ, SUIMPRED, SUIMEDIF, SUIMUNPR "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            ' llena el datagridview
            If dt.Rows.Count > 0 Then
                ' control de sobrecarga
                If dt.Rows.Count > 500 Then
                    If MessageBox.Show("La consulta puede sobrecargar el sistema. Nro de registros: " & dt.Rows.Count & " ¿ desea continuar ?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        Me.dgvCONSULTA.DataSource = dt

                        ' llena la lista de valores
                        pro_ListaDeValores()
                        Me.dgvCONSULTA.Focus()
                    End If
                Else
                    Me.dgvCONSULTA.DataSource = dt

                    ' llena la lista de valores
                    pro_ListaDeValores()
                    Me.dgvCONSULTA.Focus()
                End If
            Else
                Me.dgvCONSULTA.DataSource = New DataTable
                Me.dgvCONSULTA.Focus()

                mod_MENSAJE.Consulta_No_Encontro_Registros()
            End If

            If Me.dgvCONSULTA.RowCount > 0 Then
                Me.dgvCONSULTA.Columns("SUIMIDRE").Visible = False
                Me.cmdAceptar.Enabled = True
            Else
                Me.cmdAceptar.Enabled = False
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValores()

        Try
            ' encuestra la posición seleccionada
            Dim I, SW As Byte

            While I < dgvCONSULTA.RowCount And SW = 0
                If dgvCONSULTA.CurrentRow.Cells(I).Selected Then

                    ' selecciona el numero de ficha 
                    Me.txtSUIMNUFI.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(1).Value.ToString())

                    ' llena los campos del sujeto de impuesto

                    Dim objdatos15 As New cla_SUJEIMPU
                    Dim tbl_SUJEIMPU As New DataTable

                    tbl_SUJEIMPU = objdatos15.fun_Buscar_NUFI_X_CONSULTA_PARAMETRIZADA_SUJEIMPU(Val(Me.txtSUIMNUFI.Text))

                    If tbl_SUJEIMPU.Rows.Count > 0 Then

                        Me.txtSUIMNUFI.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMNUFI"))
                        Me.txtSUIMDIRE.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMDIRE"))
                        Me.txtSUIMSUAC.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMSUAC"))
                        Me.txtSUIMSUAN.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMSUAN"))
                        Me.txtSUIMMUNI.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMMUNI"))
                        Me.txtSUIMCORR.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMCORR"))
                        Me.txtSUIMBARR.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMBARR"))
                        Me.txtSUIMMANZ.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMMANZ"))
                        Me.txtSUIMPRED.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMPRED"))
                        Me.txtSUIMEDIF.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMEDIF"))
                        Me.txtSUIMUNPR.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMUNPR"))
                        Me.txtSUIMCLSE.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMCLSE"))
                        Me.txtSUIMVIAC.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMVIAC"))
                        Me.txtSUIMVIAN.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMVIAN"))
                        Me.txtSUIMMAIN.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMMAIN"))
                        Me.txtSUIMCAPR.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMCAPR"))
                        Me.txtSUIMESTA.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMESTA"))
                        Me.txtSUIMMUAN.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMMUAN"))
                        Me.txtSUIMCOAN.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMCOAN"))
                        Me.txtSUIMBAAN.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMBAAN"))
                        Me.txtSUIMMAAN.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMMAAN"))
                        Me.txtSUIMPRAN.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMPRAN"))
                        Me.txtSUIMEDAN.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMEDAN"))
                        Me.txtSUIMUPAN.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMUPAN"))
                        Me.txtSUIMCSAN.Text = Trim(tbl_SUJEIMPU.Rows(0).Item("SUIMCSAN"))

                    End If

                    SW = 1
                Else
                    I = I + 1
                End If
            End While

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtSUIMNUFI.Text = ""
        Me.txtSUIMMUNI.Text = ""
        Me.txtSUIMCORR.Text = ""
        Me.txtSUIMBARR.Text = ""
        Me.txtSUIMMANZ.Text = ""
        Me.txtSUIMPRED.Text = ""
        Me.txtSUIMEDIF.Text = ""
        Me.txtSUIMUNPR.Text = ""
        Me.txtSUIMCLSE.Text = ""
        Me.txtSUIMMUAN.Text = ""
        Me.txtSUIMCOAN.Text = ""
        Me.txtSUIMBAAN.Text = ""
        Me.txtSUIMMAAN.Text = ""
        Me.txtSUIMPRAN.Text = ""
        Me.txtSUIMEDAN.Text = ""
        Me.txtSUIMUPAN.Text = ""
        Me.txtSUIMCSAN.Text = ""
        Me.txtSUIMDIRE.Text = ""
        Me.txtSUIMSUAC.Text = ""
        Me.txtSUIMSUAN.Text = ""
        Me.txtSUIMVIAN.Text = ""
        Me.txtSUIMVIAC.Text = ""
        Me.txtSUIMMAIN.Text = ""
        Me.txtSUIMCAPR.Text = ""
        Me.txtSUIMESTA.Text = ""

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
            Dim inId_Reg As New frm_SUJEIMPU(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(1).Value.ToString()))
            Me.txtSUIMNUFI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtSUIMNUFI.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.txtSUIMNUFI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtSUIMNUFI.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSUIMNUFI.KeyPress, txtSUIMDIRE.KeyPress, txtSUIMMUNI.KeyPress, txtSUIMCORR.KeyPress, txtSUIMBARR.KeyPress, txtSUIMMANZ.KeyPress, txtSUIMPRED.KeyPress, txtSUIMEDIF.KeyPress, txtSUIMUNPR.KeyPress, txtSUIMCLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSUIMMUNI.GotFocus, txtSUIMCORR.GotFocus, txtSUIMBARR.GotFocus, txtSUIMMANZ.GotFocus, txtSUIMPRED.GotFocus, txtSUIMEDIF.GotFocus, txtSUIMUNPR.GotFocus, txtSUIMNUFI.GotFocus, txtSUIMDIRE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmdAceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvCONSULTA_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFIPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSUIMMUNI.Validated
        If Me.txtSUIMMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtSUIMMUNI.Text) = True Then
            Me.txtSUIMMUNI.Text = fun_Formato_Mascara_3_String(Me.txtSUIMMUNI.Text)
        End If
    End Sub
    Private Sub txtFIPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSUIMCORR.Validated
        If Me.txtSUIMCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtSUIMCORR.Text) = True Then
            Me.txtSUIMCORR.Text = fun_Formato_Mascara_2_String(Me.txtSUIMCORR.Text)
        End If
    End Sub
    Private Sub txtFIPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSUIMBARR.Validated
        If Me.txtSUIMBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtSUIMBARR.Text) = True Then
            Me.txtSUIMBARR.Text = fun_Formato_Mascara_3_String(Me.txtSUIMBARR.Text)
        End If
    End Sub
    Private Sub txtFIPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSUIMMANZ.Validated
        If Me.txtSUIMMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtSUIMMANZ.Text) = True Then
            Me.txtSUIMMANZ.Text = fun_Formato_Mascara_3_String(Me.txtSUIMMANZ.Text)
        End If
    End Sub
    Private Sub txtFIPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSUIMPRED.Validated
        If Me.txtSUIMPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtSUIMPRED.Text) = True Then
            Me.txtSUIMPRED.Text = fun_Formato_Mascara_5_String(Me.txtSUIMPRED.Text)
        End If
    End Sub
    Private Sub txtFIPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSUIMEDIF.Validated
        If Me.txtSUIMEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtSUIMEDIF.Text) = True Then
            Me.txtSUIMEDIF.Text = fun_Formato_Mascara_3_String(Me.txtSUIMEDIF.Text)
        End If
    End Sub
    Private Sub txtFIPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSUIMUNPR.Validated
        If Me.txtSUIMUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtSUIMUNPR.Text) = True Then
            Me.txtSUIMUNPR.Text = fun_Formato_Mascara_5_String(Me.txtSUIMUNPR.Text)
        End If
    End Sub
    Private Sub txtSUIMNUFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSUIMNUFI.Validated

        If Trim(Me.txtSUIMNUFI.Text) <> "" Then

            pro_Reconsultar()

            If Me.dgvCONSULTA.RowCount > 0 Then
                Me.cmdAceptar.Focus()
            End If

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

#Region "KeyUp"

    Private Sub dgvCONSULTA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCONSULTA.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#End Region

End Class