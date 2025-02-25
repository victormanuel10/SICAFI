Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_Liquida_Historico_Avaluo_HISTAVAL

    '========================================================
    '*** LIQUIDAR HISTORICO DE AVALUOS SUJETO DE IMPUESTO ***
    '========================================================

#Region "VARIABLES"

#Region "Conexion"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

    ' variables de procesos
    Private inProceso As Integer
    Private inTotalRegistros As Integer
    Private inNroInconsistencias As Integer
    Private stSeparador As String

    ' variables ficha predial
    Private stFIPRFIIN As String
    Private stFIPRFIFI As String
    Private stFIPRVIGE As String
    Private stFIPRMUNI As String
    Private stFIPRCORR As String
    Private stFIPRBARR As String
    Private stFIPRMANZ As String
    Private stFIPRPRED As String
    Private stFIPREDIF As String
    Private stFIPRUNPR As String
    Private stFIPRCLSE As String

    Private boHILIZONA As Boolean = False
    Private boHILITICO As Boolean = False

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Liquida_Historico_Avaluo_HISTAVAL
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Liquida_Historico_Avaluo_HISTAVAL
        End If

        frm_Instance.bringtofront()

        Return frm_Instance

    End Function

    Private Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtFIPRFIIN.Text = "0"
        Me.txtFIPRFIFI.Text = "999999999"
        Me.txtFIPRMUNI.Text = ""
        Me.txtFIPRCORR.Text = ""
        Me.txtFIPRBARR.Text = ""
        Me.txtFIPRMANZ.Text = ""
        Me.txtFIPRPRED.Text = ""
        Me.txtFIPREDIF.Text = ""
        Me.txtFIPRUNPR.Text = ""
        Me.lblFIPRVIGE.Text = ""
        Me.lblFIPRCLSE.Text = ""

        Me.pbPROCESO.Value = 0

        Me.cboFIPRCLSE.DataSource = New DataTable
        Me.cboFIPRVIGE.DataSource = New DataTable

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub
    Private Sub pro_VerificarCampos()

        Try
            If Trim(Me.txtFIPRFIIN.Text) = "" Then
                stFIPRFIIN = "0"
            Else
                stFIPRFIIN = Trim(Me.txtFIPRFIIN.Text)
            End If

            If Trim(Me.txtFIPRFIFI.Text) = "" Then
                stFIPRFIFI = "0"
            Else
                stFIPRFIFI = Trim(Me.txtFIPRFIFI.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRFIIN.Text)) = False Then
                stFIPRFIIN = "0"
            Else
                stFIPRFIIN = Trim(Me.txtFIPRFIIN.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRFIFI.Text)) = False Then
                stFIPRFIFI = "0"
            Else
                stFIPRFIFI = Trim(Me.txtFIPRFIFI.Text)
            End If

            If Trim(Me.txtFIPRMUNI.Text) = "" Then
                stFIPRMUNI = "%"
            Else
                stFIPRMUNI = Trim(Me.txtFIPRMUNI.Text)
            End If

            If Trim(Me.txtFIPRCORR.Text) = "" Then
                stFIPRCORR = "%"
            Else
                stFIPRCORR = Trim(Me.txtFIPRCORR.Text)
            End If

            If Trim(Me.txtFIPRBARR.Text) = "" Then
                stFIPRBARR = "%"
            Else
                stFIPRBARR = Trim(Me.txtFIPRBARR.Text)
            End If

            If Trim(Me.txtFIPRMANZ.Text) = "" Then
                stFIPRMANZ = "%"
            Else
                stFIPRMANZ = Trim(Me.txtFIPRMANZ.Text)
            End If

            If Trim(Me.txtFIPRPRED.Text) = "" Then
                stFIPRPRED = "%"
            Else
                stFIPRPRED = Trim(Me.txtFIPRPRED.Text)
            End If

            If Trim(Me.txtFIPREDIF.Text) = "" Then
                stFIPREDIF = "%"
            Else
                stFIPREDIF = Trim(Me.txtFIPREDIF.Text)
            End If

            If Trim(Me.txtFIPRUNPR.Text) = "" Then
                stFIPRUNPR = "%"
            Else
                stFIPRUNPR = Trim(Me.txtFIPRUNPR.Text)
            End If

            If Trim(Me.cboFIPRCLSE.Text) = "" Then
                stFIPRCLSE = "%"
            Else
                stFIPRCLSE = Trim(Me.cboFIPRCLSE.SelectedValue)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdLIQUIDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIQUIDAR.Click

        Try
            ' verifica la vigencia
            If Me.cboFIPRVIGE.Text = "" Or Me.cboFIPRCLSE.Text = "" Then
                MessageBox.Show("Ingrese la vigencia y/o el sector.", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Me.cboFIPRVIGE.Focus()
            Else

                ' valores predeterminados
                Me.cmdLIQUIDAR.Enabled = False

                ' buscar cadena de conexion
                Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                ' crea el datatable
                dt = New DataTable

                ' crear conexión
                oAdapter = New SqlDataAdapter
                oConexion = New SqlConnection(stCadenaConexion)

                ' abre la conexion
                oConexion.Open()

                ' verifica los campos
                pro_VerificarCampos()

                ' parametros de la consulta
                Dim ParametrosConsulta As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Select "
                ParametrosConsulta += "Fiprnufi, "
                ParametrosConsulta += "Fiprreso, "
                ParametrosConsulta += "Fiprvige, "
                ParametrosConsulta += "Fiprtire "
                ParametrosConsulta += "From FichPred where "
                ParametrosConsulta += "FiprMuni like '" & stFIPRMUNI & "' and "
                ParametrosConsulta += "FiprCorr like '" & stFIPRCORR & "' and "
                ParametrosConsulta += "FiprBarr like '" & stFIPRBARR & "' and "
                ParametrosConsulta += "FiprManz like '" & stFIPRMANZ & "' and "
                ParametrosConsulta += "FiprPred like '" & stFIPRPRED & "' and "
                ParametrosConsulta += "FiprEdif like '" & stFIPREDIF & "' and "
                ParametrosConsulta += "FiprUnpr like '" & stFIPRUNPR & "' and "
                ParametrosConsulta += "FiprClse like '" & stFIPRCLSE & "' and "
                ParametrosConsulta += "FiprTifi like '" & "0" & "' and "
                ParametrosConsulta += "FiprNufi between '" & stFIPRFIIN & "' and '" & stFIPRFIFI & "' and "
                ParametrosConsulta += "FiprEsta = 'ac' "

                ' ejecuta la consulta
                oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                ' procesa la consulta 
                oEjecutar.CommandTimeout = 0
                oEjecutar.CommandType = CommandType.Text
                oAdapter.SelectCommand = oEjecutar

                ' llena el datatable 
                oAdapter.Fill(dt)

                ' cierra la conexion
                oConexion.Close()

                ' valida las ficha encontradas en la consulta
                If dt.Rows.Count > 0 Then

                    If MessageBox.Show("Se liquidaran: " & dt.Rows.Count & " predios. " & " ¿ Desea continuar ? ", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        ' Valores predeterminados ProgressBar
                        inProceso = 0
                        Me.pbPROCESO.Value = 0
                        Me.pbPROCESO.Maximum = dt.Rows.Count
                        Me.Timer1.Enabled = True

                        'Recorre el rango asignado
                        Dim i As Integer

                        ' recorre la fichas consultadas
                        For i = 0 To dt.Rows.Count - 1

                            ' instancia la clase
                            Dim objdatos55 As New cla_FICHPRED
                            Dim tbl55 As New DataTable

                            tbl55 = objdatos55.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dt.Rows(i).Item("FIPRNUFI"))

                            ' declara la variable
                            Dim inFIPRNUFI As Integer = CInt(dt.Rows(i).Item("FIPRNUFI"))

                            Dim stFIPRDEPA As String = CStr(Trim(tbl55.Rows(0).Item("FIPRDEPA").ToString))
                            Dim stFIPRMUNI As String = CStr(Trim(tbl55.Rows(0).Item("FIPRMUNI").ToString))
                            Dim inFIPRCLSE As Integer = CInt(Me.cboFIPRCLSE.SelectedValue)
                            Dim inFIPRVIGE As Integer = CInt(Me.cboFIPRVIGE.SelectedValue)
                            Dim inFIPRTIIM As Integer = CInt(Me.cboAFSITIIM.SelectedValue)
                            Dim inFIPRCONC As Integer = CInt(Me.cboAFSICONC.SelectedValue)

                            ' instancia la clase
                            Dim objdatos66 As New cla_PEPELIQU
                            Dim tbl66 As New DataTable

                            tbl66 = objdatos66.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_TIIM_CONC_X_PEPELIQU(stFIPRDEPA, stFIPRMUNI, inFIPRCLSE, inFIPRVIGE, inFIPRTIIM, inFIPRCONC)

                            If tbl66.Rows.Count = 0 OrElse CBool(tbl66.Rows(0).Item("PPLIHIAV")) = False Then
                                If MessageBox.Show("La ficha Nro.: " & inFIPRNUFI & " no tiene permiso para ejecutar el proceso." & Chr(Keys.Enter) & "¿ Desea continuar ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                                    Exit For
                                End If
                            Else
                                pro_LIQUIDA_HISTORICO_DE_AVALUO_IMPUESTO(inFIPRNUFI, Me.cboFIPRVIGE.SelectedValue, Me.chkLIHIZONA.Checked, Me.chkHILITICO.Checked)
                            End If

                            ' incrementa la barra
                            inProceso = inProceso + 1
                            Me.pbPROCESO.Value = inProceso

                        Next

                        ' Llena el datagrigview
                        Me.pbPROCESO.Value = 0

                        MessageBox.Show("Proceso de liquidación de avalúos terminado", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    End If

                Else
                    ' Mensaje terminacion
                    MessageBox.Show("NO existen registros con los parametros asignados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.strBARRESTA.Items(2).Text = "Registros : 0"
                End If

                Me.cmdLIQUIDAR.Enabled = True
                Me.cmdLIQUIDAR.Focus()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdLIQUIDAR.Enabled = True
        End Try

    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        pro_LimpiarCampos()
        txtFIPRFIIN.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_REPO_FIPRINCO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtFIPRFIIN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRFIIN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRFIFI.Focus()
        End If
    End Sub
    Private Sub txtFIPRFIFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRFIFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRMUNI.Focus()
        End If
    End Sub
    Private Sub cboTAAPVIGE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRVIGE.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRMUNI.Focus()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtFIPRMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMUNI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRCORR.Focus()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtFIPRCORR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCORR.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRBARR.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRBARR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRBARR.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRMANZ.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRMANZ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMANZ.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRPRED.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRPRED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPRED.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPREDIF.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPREDIF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPREDIF.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRUNPR.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRUNPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRUNPR.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        cboFIPRVIGE.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub cboFIPRVIGE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRVIGE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cboFIPRCLSE.Focus()
        End If
    End Sub
    Private Sub cboFIPRCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRCLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cmdLIQUIDAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtFIPRFIIN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIIN.GotFocus
        txtFIPRFIIN.SelectionStart = 0
        txtFIPRFIIN.SelectionLength = Len(txtFIPRFIIN.Text)
        strBARRESTA.Items(0).Text = txtFIPRFIIN.AccessibleDescription
    End Sub
    Private Sub txtFIPRFIFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIFI.GotFocus
        txtFIPRFIFI.SelectionStart = 0
        txtFIPRFIFI.SelectionLength = Len(txtFIPRFIFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRFIFI.AccessibleDescription
    End Sub
    Private Sub cboTAAPVIGE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRVIGE.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRVIGE.AccessibleDescription
    End Sub
    Private Sub cboTAAPCLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCLSE.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRCLSE.AccessibleDescription
    End Sub
    Private Sub txtFIPRMUNI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.GotFocus
        txtFIPRMUNI.SelectionStart = 0
        txtFIPRMUNI.SelectionLength = Len(txtFIPRMUNI.Text)
        strBARRESTA.Items(0).Text = txtFIPRMUNI.AccessibleDescription
    End Sub
    Private Sub txtFIPRCORR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.GotFocus
        txtFIPRCORR.SelectionStart = 0
        txtFIPRCORR.SelectionLength = Len(txtFIPRCORR.Text)
        strBARRESTA.Items(0).Text = txtFIPRCORR.AccessibleDescription
    End Sub
    Private Sub txtFIPRBARR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.GotFocus
        txtFIPRBARR.SelectionStart = 0
        txtFIPRBARR.SelectionLength = Len(txtFIPRBARR.Text)
        strBARRESTA.Items(0).Text = txtFIPRBARR.AccessibleDescription
    End Sub
    Private Sub txtFIPRMANZ_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.GotFocus
        txtFIPRMANZ.SelectionStart = 0
        txtFIPRMANZ.SelectionLength = Len(txtFIPRMANZ.Text)
        strBARRESTA.Items(0).Text = txtFIPRMANZ.AccessibleDescription
    End Sub
    Private Sub txtFIPRPRED_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.GotFocus
        txtFIPRPRED.SelectionStart = 0
        txtFIPRPRED.SelectionLength = Len(txtFIPRPRED.Text)
        strBARRESTA.Items(0).Text = txtFIPRPRED.AccessibleDescription
    End Sub
    Private Sub txtFIPREDIF_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.GotFocus
        txtFIPREDIF.SelectionStart = 0
        txtFIPREDIF.SelectionLength = Len(txtFIPREDIF.Text)
        strBARRESTA.Items(0).Text = txtFIPREDIF.AccessibleDescription
    End Sub
    Private Sub txtFIPRUNPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.GotFocus
        txtFIPRUNPR.SelectionStart = 0
        txtFIPRUNPR.SelectionLength = Len(txtFIPRUNPR.Text)
        strBARRESTA.Items(0).Text = txtFIPRUNPR.AccessibleDescription
    End Sub
    Private Sub cboFIPRCLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCLSE.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRCLSE.AccessibleDescription
    End Sub
    Private Sub cmdVALIDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIQUIDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIQUIDAR.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFIPRFIIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIIN.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRFIIN.Text)) = True Then
            Me.txtFIPRFIIN.Text = Val(Trim(Me.txtFIPRFIIN.Text))
        Else
            Me.txtFIPRFIIN.Focus()
            mod_MENSAJE.Inco_Valo_Nume()
        End If

    End Sub
    Private Sub txtFIPRFIFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIFI.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRFIFI.Text)) = True Then
            Me.txtFIPRFIFI.Text = Val(Trim(Me.txtFIPRFIFI.Text))
        Else
            Me.txtFIPRFIFI.Focus()
            mod_MENSAJE.Inco_Valo_Nume()
        End If

    End Sub
    Private Sub txtFIPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.Validated
        If Trim(Me.txtFIPRMUNI.Text) <> "" Then
            txtFIPRMUNI.Text = fun_Formato_Mascara_3_String(Me.txtFIPRMUNI.Text)
        End If
    End Sub
    Private Sub txtFIPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.Validated
        If Trim(Me.txtFIPRCORR.Text) <> "" Then
            Me.txtFIPRCORR.Text = fun_Formato_Mascara_2_String(Me.txtFIPRCORR.Text)
        End If
    End Sub
    Private Sub txtFIPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.Validated
        If Trim(Me.txtFIPRBARR.Text) <> "" Then
            Me.txtFIPRBARR.Text = fun_Formato_Mascara_3_String(Me.txtFIPRBARR.Text)
        End If
    End Sub
    Private Sub txtFIPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.Validated
        If Trim(Me.txtFIPRMANZ.Text) <> "" Then
            Me.txtFIPRMANZ.Text = fun_Formato_Mascara_3_String(Me.txtFIPRMANZ.Text)
        End If
    End Sub
    Private Sub txtFIPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.Validated
        If Trim(Me.txtFIPRPRED.Text) <> "" Then
            Me.txtFIPRPRED.Text = fun_Formato_Mascara_5_String(Me.txtFIPRPRED.Text)
        End If
    End Sub
    Private Sub txtFIPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.Validated
        If Trim(Me.txtFIPREDIF.Text) <> "" Then
            Me.txtFIPREDIF.Text = fun_Formato_Mascara_3_String(Me.txtFIPREDIF.Text)
        End If
    End Sub
    Private Sub txtFIPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.Validated
        If Trim(Me.txtFIPRUNPR.Text) <> "" Then
            Me.txtFIPRUNPR.Text = fun_Formato_Mascara_5_String(Me.txtFIPRUNPR.Text)
        End If
    End Sub

#End Region

#Region "Click"

    Private Sub cboFIPRCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboFIPRCLSE, Me.cboFIPRCLSE.SelectedIndex)
    End Sub
    Private Sub cboFIPRVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboFIPRVIGE, Me.cboFIPRVIGE.SelectedIndex)
    End Sub
    Private Sub cboAFSITIIM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFSITIIM.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboAFSITIIM, Me.cboAFSITIIM.SelectedIndex)
    End Sub
    Private Sub cboAFSICONC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFSICONC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboAFSICONC, Me.cboAFSICONC.SelectedIndex, Me.cboAFSITIIM)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboFIPRCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFIPRCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboFIPRCLSE, Me.cboFIPRCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboFIPRVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFIPRVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboFIPRVIGE, Me.cboFIPRVIGE.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboFIPRCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFIPRCLSE.SelectedIndexChanged
        Me.lblFIPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboFIPRCLSE), String)
    End Sub
    Private Sub cboFIPRVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFIPRVIGE.SelectedIndexChanged
        Me.lblFIPRVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboFIPRVIGE), String)
    End Sub
    Private Sub cboAFSITIIM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAFSITIIM.SelectedIndexChanged
        Me.lblAFSITIIM.Text = CType(fun_Buscar_Lista_Valores_TIPOIMPU_Codigo(Me.cboAFSITIIM), String)

        Me.cboAFSICONC.DataSource = New DataTable
        Me.lblAFSICONC.Text = ""
    End Sub
    Private Sub cboAFSICONC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAFSICONC.SelectedIndexChanged
        Me.lblAFSICONC.Text = CType(fun_Buscar_Lista_Valores_CONCEPTO_Codigo(Me.cboAFSITIIM, Me.cboAFSICONC), String)
    End Sub

#End Region

#End Region

End Class