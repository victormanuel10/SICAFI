Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_insertar_FICHRESU

    '==============================
    '*** INSERTAR FICHA RESUMEN ***
    '==============================

#Region "CONSTRUCTORES"

    Public Sub New(ByVal stRESODEPA As String, _
                   ByVal stRESOMUNI As String, _
                   ByVal inRESOTIRE As Integer, _
                   ByVal inRESOCLSE As Integer, _
                   ByVal inRESOVIGE As Integer, _
                   ByVal inRESOCODI As Integer, _
                   ByVal inRESOCORE As String)

        vl_stRESODEPA = stRESODEPA
        vl_stRESOMUNI = stRESOMUNI
        vl_inRESOTIRE = inRESOTIRE
        vl_inRESOCLSE = inRESOCLSE
        vl_inRESOVIGE = inRESOVIGE
        vl_inRESOCODI = inRESOCODI
        vl_stRESOCORE = inRESOCORE

        InitializeComponent()
        pro_inicializarControles()
        pro_LimpiarCampos()

    End Sub

#End Region

#Region "VARIABLES LOCALES"

    '*** VARIABLES QUE RECIBE DEL FORMULARIO DE FICHA PREDIAL ***
    Dim vl_stRESODEPA As String
    Dim vl_stRESOMUNI As String
    Dim vl_inRESOTIRE As Integer
    Dim vl_inRESOCLSE As Integer
    Dim vl_inRESOVIGE As Integer
    Dim vl_inRESOCODI As Integer
    Dim vl_stRESOCORE As String
    Dim vl_boSWVerificaDatoAlGuardar As Boolean = True

    '*** VARIABLES DE LA MASCARA DE LA CEDULA CATASTRAL ***
    Dim Mascara As Integer
    Dim Formato As String

    ' Variables para el numero de registro del predio
    Private vl_inFIPRNURE As Integer

    ' variables de conexion
    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        '=========================================
        ' CARGA LOS COMBOBOX CON LOS DATOS ACTIVOS
        '=========================================


        Dim objdatos2 As New cla_CLASSECT

        cboFIPRCLSE.DataSource = objdatos2.fun_Consultar_MANT_CLASSECT_X_ESTADO
        cboFIPRCLSE.DisplayMember = "CLSECODI"
        cboFIPRCLSE.ValueMember = "CLSECODI"

        Dim objdatos4 As New cla_ESTADO

        cboFIPRESTA.DataSource = objdatos4.fun_Consultar_ESTADO_X_ESTADO
        cboFIPRESTA.DisplayMember = "ESTADESC"
        cboFIPRESTA.ValueMember = "ESTACODI"

        '====================
        'CARGA LA DESCRIPCIÓN 
        '====================

        Try
            cboFIPRCLSE.SelectedValue = vl_inRESOCLSE
            txtFIPRMUNI.Text = vl_stRESOMUNI

            Dim boFIPRCLSE As Boolean = fun_Buscar_Dato_CLASSECT(cboFIPRCLSE.SelectedValue)

            If boFIPRCLSE = True  Then
                lblFIPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(cboFIPRCLSE.SelectedValue), String)
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        Me.txtFIPRNUFI.Focus()

    End Sub
    Private Sub pro_AsignarNumeroDeRegistro()

        Try
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

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "max(FiprNure) "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprDepa like '" & vl_stRESODEPA & "' and "
            ParametrosConsulta += "FiprMuni like '" & vl_stRESOMUNI & "' and "
            ParametrosConsulta += "FiprTire like '" & vl_inRESOTIRE & "' and "
            ParametrosConsulta += "FiprVige like '" & vl_inRESOVIGE & "' and "
            ParametrosConsulta += "FiprClse like '" & vl_inRESOCLSE & "' and "
            ParametrosConsulta += "FiprReso like '" & vl_inRESOCODI & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            vl_inFIPRNURE = Val(dt.Rows(0).Item(0)) + 1

        Catch ex As Exception
            MessageBox.Show(Err.Description & ". Error en numero de registro de ficha predial")
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtFIPRNUFI.Text = ""
        Me.txtFIPRDIRE.Text = ""
        Me.txtFIPRDESC.Text = ""
        Me.chkFIPRCONJ.Checked = False
        Me.txtFIPRCORR.Text = ""
        Me.txtFIPRBARR.Text = ""
        Me.txtFIPRMANZ.Text = ""
        Me.txtFIPRPRED.Text = ""
        Me.txtFIPREDIF.Text = ""
        'Me.txtFIPRUNPR.Text = ""
        Me.txtFIPRMUAN.Text = ""
        Me.txtFIPRCOAN.Text = ""
        Me.txtFIPRBAAN.Text = ""
        Me.txtFIPRMAAN.Text = ""
        Me.txtFIPRPRAN.Text = ""
        Me.txtFIPREDAN.Text = ""
        'Me.txtFIPRUPAN.Text = ""
        Me.txtFIPRATLO.Text = ""
        Me.txtFIPRACLO.Text = ""
        Me.txtFIPRAPLO.Text = ""
        Me.txtFIPRTOED.Text = ""
        Me.txtFIPRUNCO.Text = ""
        Me.txtFIPRURPH.Text = ""
        Me.txtFIPRAPCA.Text = ""
        Me.txtFIPRLOCA.Text = ""
        Me.txtFIPRCUUT.Text = ""
        Me.txtFIPRGACU.Text = ""
        Me.txtFIPRGADE.Text = ""
        Me.txtFIPRPISO.Text = ""
        Me.chkFIPRCONJ.Checked = False

        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtFIPRNUFI, "")

        Dim tbl As New DataTable

        Me.cboFIPRCASU.DataSource = tbl
        Me.cboFIPRCSAN.DataSource = tbl
        Me.cboFIPRCASA.DataSource = tbl
        Me.cboFIPRCAPR.DataSource = tbl

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        ' verifica que los datos esten llenos
        If fun_Verificar_Campos_Llenos_35_DATOS(Trim(Me.txtFIPRNUFI.Text), _
                                                Trim(Me.cboFIPRTIFI.Text), _
                                                Trim(Me.txtFIPRDIRE.Text), _
                                                Trim(Me.txtFIPRMUNI.Text), _
                                                Trim(Me.txtFIPRCORR.Text), _
                                                Trim(Me.txtFIPRBARR.Text), _
                                                Trim(Me.txtFIPRMANZ.Text), _
                                                Trim(Me.txtFIPRPRED.Text), _
                                                Trim(Me.txtFIPREDIF.Text), _
                                                Trim(Me.txtFIPRUNPR.Text), _
                                                Trim(Me.cboFIPRCLSE.Text), _
                                                Trim(Me.cboFIPRCASU.Text), _
                                                Trim(Me.txtFIPRMUAN.Text), _
                                                Trim(Me.txtFIPRCOAN.Text), _
                                                Trim(Me.txtFIPRBAAN.Text), _
                                                Trim(Me.txtFIPRMAAN.Text), _
                                                Trim(Me.txtFIPRPRAN.Text), _
                                                Trim(Me.txtFIPREDAN.Text), _
                                                Trim(Me.txtFIPRUPAN.Text), _
                                                Trim(Me.cboFIPRCSAN.Text), _
                                                Trim(Me.cboFIPRCASA.Text), _
                                                Trim(Me.cboFIPRCAPR.Text), _
                                                Trim(Me.cboFIPRESTA.Text), _
                                                Trim(Me.txtFIPRATLO.Text), _
                                                Trim(Me.txtFIPRACLO.Text), _
                                                Trim(Me.txtFIPRAPLO.Text), _
                                                Trim(Me.txtFIPRTOED.Text), _
                                                Trim(Me.txtFIPRUNCO.Text), _
                                                Trim(Me.txtFIPRURPH.Text), _
                                                Trim(Me.txtFIPRAPCA.Text), _
                                                Trim(Me.txtFIPRLOCA.Text), _
                                                Trim(Me.txtFIPRCUUT.Text), _
                                                Trim(Me.txtFIPRGACU.Text), _
                                                Trim(Me.txtFIPRGADE.Text), _
                                                Trim(Me.txtFIPRPISO.Text)) = False Then
            mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
            txtFIPRNUFI.Focus()
        Else
            ' verifica que los datos esten correctos numericos o decimales
            If vl_boSWVerificaDatoAlGuardar = False Then
                mod_MENSAJE.Inco_Valo_Nume()
            Else
                Dim objdatos As New cla_MUNICIPIO
                Dim tbl1 As New DataTable

                tbl1 = objdatos.fun_Buscar_DEPARTAMENTO_Y_CODIGO_MANT_MUNICIPIO(vl_stRESODEPA, vl_stRESOMUNI)

                Dim inFIPRRAIN As Integer = Val(tbl1.Rows(0).Item(4))
                Dim inFIPRRAFI As Integer = Val(tbl1.Rows(0).Item(5))

                If Val(txtFIPRNUFI.Text) < inFIPRRAIN Or Val(txtFIPRNUFI.Text) > inFIPRRAFI Then
                    txtFIPRNUFI.Focus()
                    strBARRESTA.Items(1).Text = "El rango de la ficha no corresponde con el municipio"
                    ErrorProvider1.SetError(Me.txtFIPRNUFI, "El rango de la ficha no corresponde con el municipio")
                Else
                    strBARRESTA.Items(0).Text = ""
                    strBARRESTA.Items(1).Text = ""
                    ErrorProvider1.SetError(Me.txtFIPRNUFI, "")

                    Dim id_FIPRNUFI As String = txtFIPRNUFI.Text

                    Dim objdatos1 As New cla_FICHPRED
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(id_FIPRNUFI)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("Ficha existente en base de datos " & Chr(13) & "Nro: " & id_FIPRNUFI, "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        txtFIPRNUFI.Focus()
                    Else
                        Dim dateNow As DateTime = DateTime.Now
                        Dim daFIPRFECH As Date = DateTime.Now.ToString()    'Fecha y hora

                        ' Asigna el numero de registro
                        pro_AsignarNumeroDeRegistro()

                        ' declaración de variables
                        Dim inFIPRMOAD As Integer = 1
                        Dim boFIPRLITI As Boolean = False
                        Dim stFIPRPOLI As String = "0.00"
                        Dim inIFPRARTE As Integer = 0
                        Dim stFIPRCOPR As String = "0.000000"
                        Dim stFIPRCOED As String = "0.000000"
                        Dim stFIPRRUIM As String = "."
                        Dim boFIPRINCO As Boolean = False

                        Dim objdatos11 As New cla_FICHRESU

                        If (objdatos11.fun_Insertar_FICHRESU(txtFIPRNUFI.Text, _
                                                             vl_inRESOVIGE, _
                                                             vl_inRESOTIRE, _
                                                             vl_inRESOCODI, _
                                                             txtFIPRDIRE.Text, _
                                                             txtFIPRDESC.Text, _
                                                             chkFIPRCONJ.Checked, _
                                                             daFIPRFECH, _
                                                             vl_inFIPRNURE, _
                                                             vl_stRESODEPA, _
                                                             txtFIPRMUNI.Text, _
                                                             txtFIPRCORR.Text, _
                                                             txtFIPRBARR.Text, _
                                                             txtFIPRMANZ.Text, _
                                                             txtFIPRPRED.Text, _
                                                             txtFIPREDIF.Text, _
                                                             txtFIPRUNPR.Text, _
                                                             cboFIPRCLSE.SelectedValue, _
                                                             cboFIPRCASU.SelectedValue, _
                                                             txtFIPRMUAN.Text, _
                                                             txtFIPRCOAN.Text, _
                                                             txtFIPRBAAN.Text, _
                                                             txtFIPRMAAN.Text, _
                                                             txtFIPRPRAN.Text, _
                                                             txtFIPREDAN.Text, _
                                                             txtFIPRUPAN.Text, _
                                                             cboFIPRCSAN.SelectedValue, _
                                                             cboFIPRCASA.SelectedValue, _
                                                             cboFIPRCAPR.SelectedValue, _
                                                             inFIPRMOAD, _
                                                             cboFIPRESTA.SelectedValue, _
                                                             boFIPRLITI, _
                                                             stFIPRPOLI, _
                                                             vl_stRESOCORE, _
                                                             inIFPRARTE, _
                                                             stFIPRCOPR, _
                                                             stFIPRCOED, _
                                                             cboFIPRTIFI.Text, _
                                                             boFIPRINCO, _
                                                             stFIPRRUIM, _
                                                             txtFIPRATLO.Text, _
                                                             txtFIPRACLO.Text, _
                                                             txtFIPRAPLO.Text, _
                                                             txtFIPRTOED.Text, _
                                                             txtFIPRUNCO.Text, _
                                                             txtFIPRURPH.Text, _
                                                             txtFIPRAPCA.Text, _
                                                             txtFIPRLOCA.Text, _
                                                             txtFIPRCUUT.Text, _
                                                             txtFIPRGACU.Text, _
                                                             txtFIPRGADE.Text, _
                                                             txtFIPRPISO.Text)) Then

                            mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                            Dim frm_FICHPRED As New frm_FICHPRED(Val(txtFIPRNUFI.Text))

                            pro_LimpiarCampos()
                            txtFIPRNUFI.Focus()
                            Me.Close()
                        Else
                            mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                        End If
                    End If
                End If
            End If
        End If


    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Dim frm_FICHPRED As New frm_FICHPRED(0)
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txtFIPRNUFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRNUFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFIPRTIFI.Focus()
        End If
    End Sub
    Private Sub txtFIPRTIFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRTIFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRDESC.Focus()
        End If
    End Sub
    Private Sub txtFIPRDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRDESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRDIRE.Focus()
        End If
    End Sub
    Private Sub txtFIPRDIRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRDIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            chkFIPRCONJ.Focus()
        End If
    End Sub
    Private Sub chkFIPRCONJ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkFIPRCONJ.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMUNI.Focus()
        End If
    End Sub
    Private Sub txtFIPRMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMUNI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCORR.Focus()
        End If
    End Sub
    Private Sub txtFIPRCORR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCORR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRBARR.Focus()
        End If
    End Sub
    Private Sub txtFIPRBARR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRBARR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMANZ.Focus()
        End If
    End Sub
    Private Sub txtFIPRMANZ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMANZ.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRPRED.Focus()
        End If

    End Sub
    Private Sub txtFIPRPRED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPRED.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPREDIF.Focus()
        End If
    End Sub
    Private Sub txtFIPREDIF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPREDIF.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFIPRCASU.Focus()
        End If
    End Sub
    Private Sub txtFIPRUNPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRUNPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFIPRCASU.Focus()
        End If
    End Sub
    Private Sub cboFIPRCASU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRCASU.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMUAN.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CATESUEL(cboFIPRCASU, cboFIPRCASU.SelectedIndex)
        End If
    End Sub
    Private Sub txtFIPRMUAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMUAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCOAN.Focus()
        End If
    End Sub
    Private Sub txtFIPRCOAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCOAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRBAAN.Focus()
        End If
    End Sub
    Private Sub txtFIPRBAAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRBAAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMAAN.Focus()
        End If
    End Sub
    Private Sub txtFIPRMAAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMAAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRPRAN.Focus()
        End If
    End Sub
    Private Sub txtFIPRPRAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPRAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPREDAN.Focus()
        End If
    End Sub
    Private Sub txtFIPREDAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPREDAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFIPRCSAN.Focus()
        End If
    End Sub
    Private Sub txtFIPRUPAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRUPAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFIPRCSAN.Focus()
        End If
    End Sub
    Private Sub cboFIPRCSAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRCSAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFIPRCASA.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT(cboFIPRCSAN, cboFIPRCSAN.SelectedIndex)
        End If
    End Sub
    Private Sub cboFIPRCASA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRCASA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFIPRCAPR.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CATESUEL(cboFIPRCASA, cboFIPRCASA.SelectedIndex)
        End If
    End Sub
    Private Sub cboFIPRCAPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRCAPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFIPRESTA.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CARAPRED(cboFIPRCAPR, cboFIPRCAPR.SelectedIndex)
        End If
    End Sub
    Private Sub cboFIPRESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRATLO.Focus()
        End If
    End Sub
    Private Sub txtFIPRATLO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRATLO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRACLO.Focus()
        End If
    End Sub
    Private Sub txtFIPRACLO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRACLO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRAPLO.Focus()
        End If
    End Sub
    Private Sub txtFIPRAPLO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRAPLO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRTOED.Focus()
        End If
    End Sub
    Private Sub txtFIPRTOED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRTOED.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRUNCO.Focus()
        End If
    End Sub
    Private Sub txtFIPRUNCO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRUNCO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRURPH.Focus()
        End If
    End Sub
    Private Sub txtFIPRURPH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRURPH.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRAPCA.Focus()
        End If
    End Sub
    Private Sub txtFIPRAPCA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRAPCA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRLOCA.Focus()
        End If
    End Sub
    Private Sub txtFIPRLOCA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRLOCA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCUUT.Focus()
        End If
    End Sub
    Private Sub txtFIPRCUUT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCUUT.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRGACU.Focus()
        End If
    End Sub
    Private Sub txtFIPRGACU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRGACU.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRGADE.Focus()
        End If
    End Sub
    Private Sub txtFIPRGADE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRGADE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRPISO.Focus()
        End If
    End Sub
    Private Sub txtFIPRPISO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPISO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboFIPRCASU_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFIPRCASU.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_CATESUEL()
        End If
    End Sub
    Private Sub cboFIPRCSAN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFIPRCSAN.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_CLASSECT()
        End If
    End Sub
    Private Sub cboFIPRCASA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFIPRCASA.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_CATESUEL()
        End If
    End Sub
    Private Sub cboFIPRCAPR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFIPRCAPR.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_CARAPRED()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtFIPRNUFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRNUFI.GotFocus
        txtFIPRNUFI.SelectionStart = 0
        txtFIPRNUFI.SelectionLength = Len(txtFIPRNUFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRNUFI.AccessibleDescription
    End Sub
    Private Sub txtFIPRDESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRDESC.GotFocus
        txtFIPRDESC.SelectionStart = 0
        txtFIPRDESC.SelectionLength = Len(txtFIPRDESC.Text)
        strBARRESTA.Items(0).Text = txtFIPRDESC.AccessibleDescription
    End Sub
    Private Sub txtFIPRDIRE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRDIRE.GotFocus
        txtFIPRDIRE.SelectionStart = 0
        txtFIPRDIRE.SelectionLength = Len(txtFIPRDIRE.Text)
        strBARRESTA.Items(0).Text = txtFIPRDIRE.AccessibleDescription
    End Sub
    Private Sub chkFIPRCONJ_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFIPRCONJ.GotFocus
        strBARRESTA.Items(0).Text = chkFIPRCONJ.AccessibleDescription
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
    Private Sub txtFIPRMUAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUAN.GotFocus
        txtFIPRMUAN.SelectionStart = 0
        txtFIPRMUAN.SelectionLength = Len(txtFIPRMUAN.Text)
        strBARRESTA.Items(0).Text = txtFIPRMUAN.AccessibleDescription
    End Sub
    Private Sub txtFIPRCOAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCOAN.GotFocus
        txtFIPRCOAN.SelectionStart = 0
        txtFIPRCOAN.SelectionLength = Len(txtFIPRCOAN.Text)
        strBARRESTA.Items(0).Text = txtFIPRCOAN.AccessibleDescription
    End Sub
    Private Sub txtFIPRBAAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBAAN.GotFocus
        txtFIPRBAAN.SelectionStart = 0
        txtFIPRBAAN.SelectionLength = Len(txtFIPRBAAN.Text)
        strBARRESTA.Items(0).Text = txtFIPRBAAN.AccessibleDescription
    End Sub
    Private Sub txtFIPRMAAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMAAN.GotFocus
        txtFIPRMAAN.SelectionStart = 0
        txtFIPRMAAN.SelectionLength = Len(txtFIPRMAAN.Text)
        strBARRESTA.Items(0).Text = txtFIPRMAAN.AccessibleDescription
    End Sub
    Private Sub txtFIPRPRAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRAN.GotFocus
        txtFIPRPRAN.SelectionStart = 0
        txtFIPRPRAN.SelectionLength = Len(txtFIPRPRAN.Text)
        strBARRESTA.Items(0).Text = txtFIPRPRAN.AccessibleDescription
    End Sub
    Private Sub txtFIPREDAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDAN.GotFocus
        txtFIPREDAN.SelectionStart = 0
        txtFIPREDAN.SelectionLength = Len(txtFIPREDAN.Text)
        strBARRESTA.Items(0).Text = txtFIPREDAN.AccessibleDescription
    End Sub
    Private Sub txtFIPRUPAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUPAN.GotFocus
        txtFIPRUPAN.SelectionStart = 0
        txtFIPRUPAN.SelectionLength = Len(txtFIPRUPAN.Text)
        strBARRESTA.Items(0).Text = txtFIPRUPAN.AccessibleDescription
    End Sub
    Private Sub cboFIPRCASU_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCASU.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRCASU.AccessibleDescription
    End Sub
    Private Sub cboFIPRCSAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCSAN.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRCSAN.AccessibleDescription
    End Sub
    Private Sub cboFIPRCASA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCASA.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRCASA.AccessibleDescription
    End Sub
    Private Sub cboFIPRCAPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCAPR.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRCAPR.AccessibleDescription
    End Sub
    Private Sub cboFIPRESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRESTA.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRESTA.AccessibleDescription
    End Sub
    Private Sub txtFIPRATLO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRATLO.GotFocus
        txtFIPRATLO.SelectionStart = 0
        txtFIPRATLO.SelectionLength = Len(txtFIPRATLO.Text)
        strBARRESTA.Items(0).Text = txtFIPRATLO.AccessibleDescription
    End Sub
    Private Sub txtFIPRACLO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRACLO.GotFocus
        txtFIPRACLO.SelectionStart = 0
        txtFIPRACLO.SelectionLength = Len(txtFIPRACLO.Text)
        strBARRESTA.Items(0).Text = txtFIPRACLO.AccessibleDescription
    End Sub
    Private Sub txtFIPRAPLO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRAPLO.GotFocus
        txtFIPRAPLO.SelectionStart = 0
        txtFIPRAPLO.SelectionLength = Len(txtFIPRAPLO.Text)
        strBARRESTA.Items(0).Text = txtFIPRAPLO.AccessibleDescription
    End Sub
    Private Sub txtFIPRTOED_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRTOED.GotFocus
        txtFIPRTOED.SelectionStart = 0
        txtFIPRTOED.SelectionLength = Len(txtFIPRTOED.Text)
        strBARRESTA.Items(0).Text = txtFIPRTOED.AccessibleDescription
    End Sub
    Private Sub txtFIPRUNCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNCO.GotFocus
        txtFIPRUNCO.SelectionStart = 0
        txtFIPRUNCO.SelectionLength = Len(txtFIPRUNCO.Text)
        strBARRESTA.Items(0).Text = txtFIPRUNCO.AccessibleDescription
    End Sub
    Private Sub txtFIPRURPH_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRURPH.GotFocus
        txtFIPRURPH.SelectionStart = 0
        txtFIPRURPH.SelectionLength = Len(txtFIPRURPH.Text)
        strBARRESTA.Items(0).Text = txtFIPRURPH.AccessibleDescription
    End Sub
    Private Sub txtFIPRAPCA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRAPCA.GotFocus
        txtFIPRAPCA.SelectionStart = 0
        txtFIPRAPCA.SelectionLength = Len(txtFIPRAPCA.Text)
        strBARRESTA.Items(0).Text = txtFIPRAPCA.AccessibleDescription
    End Sub
    Private Sub txtFIPRLOCA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRLOCA.GotFocus
        txtFIPRLOCA.SelectionStart = 0
        txtFIPRLOCA.SelectionLength = Len(txtFIPRLOCA.Text)
        strBARRESTA.Items(0).Text = txtFIPRLOCA.AccessibleDescription
    End Sub
    Private Sub txtFIPRCUUT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCUUT.GotFocus
        txtFIPRCUUT.SelectionStart = 0
        txtFIPRCUUT.SelectionLength = Len(txtFIPRCUUT.Text)
        strBARRESTA.Items(0).Text = txtFIPRCUUT.AccessibleDescription
    End Sub
    Private Sub txtFIPRGACU_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRGACU.GotFocus
        txtFIPRGACU.SelectionStart = 0
        txtFIPRGACU.SelectionLength = Len(txtFIPRGACU.Text)
        strBARRESTA.Items(0).Text = txtFIPRGACU.AccessibleDescription
    End Sub
    Private Sub txtFIPRGADE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRGADE.GotFocus
        txtFIPRGADE.SelectionStart = 0
        txtFIPRGADE.SelectionLength = Len(txtFIPRGADE.Text)
        strBARRESTA.Items(0).Text = txtFIPRGADE.AccessibleDescription
    End Sub
    Private Sub txtFIPRPISO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPISO.GotFocus
        txtFIPRPISO.SelectionStart = 0
        txtFIPRPISO.SelectionLength = Len(txtFIPRPISO.Text)
        strBARRESTA.Items(0).Text = txtFIPRPISO.AccessibleDescription
    End Sub
    Private Sub cboFIPRTIFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRTIFI.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRTIFI.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFIPRNUFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRNUFI.Validated
        Try
            If Trim(txtFIPRNUFI.Text) = "" Then
                txtFIPRNUFI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
                ErrorProvider1.SetError(Me.txtFIPRNUFI, "Ingrese el numero de la ficha")

            Else
                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRNUFI.Text)) = False Then
                    vl_boSWVerificaDatoAlGuardar = False

                    txtFIPRNUFI.Focus()
                    strBARRESTA.Items(1).Text = IncoValoNume
                Else
                    vl_boSWVerificaDatoAlGuardar = True

                    strBARRESTA.Items(0).Text = ""
                    strBARRESTA.Items(1).Text = ""

                    Dim objdatos As New cla_MUNICIPIO
                    Dim tbl1 As New DataTable
                    tbl1 = objdatos.fun_Buscar_DEPARTAMENTO_Y_CODIGO_MANT_MUNICIPIO(vl_stRESODEPA, vl_stRESOMUNI)

                    Dim inFIPRRAIN As Integer = Val(tbl1.Rows(0).Item(4))
                    Dim inFIPRRAFI As Integer = Val(tbl1.Rows(0).Item(5))

                    If Val(txtFIPRNUFI.Text) < inFIPRRAIN Or Val(txtFIPRNUFI.Text) > inFIPRRAFI Then
                        txtFIPRNUFI.Focus()
                        strBARRESTA.Items(1).Text = "El rango de la ficha no corresponde con el municipio"
                        ErrorProvider1.SetError(Me.txtFIPRNUFI, "El rango de la ficha no corresponde con el municipio")
                    Else
                        strBARRESTA.Items(0).Text = ""
                        strBARRESTA.Items(1).Text = ""
                        ErrorProvider1.SetError(Me.txtFIPRNUFI, "")

                        Dim idNumero As Integer = Val(txtFIPRNUFI.Text)

                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl As New DataTable

                        If Trim(idNumero) = "" Then
                            idNumero = 0
                        End If

                        tbl = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(idNumero)

                        If tbl.Rows.Count > 0 Then
                            strBARRESTA.Items(1).Text = "Ficha existente en la base de datos"
                            ErrorProvider1.SetError(Me.txtFIPRNUFI, "Ficha existente en la base de datos")
                            txtFIPRNUFI.Focus()
                        Else
                            strBARRESTA.Items(0).Text = ""
                            strBARRESTA.Items(1).Text = ""
                            ErrorProvider1.SetError(Me.txtFIPRNUFI, "")
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cboFIPRTIFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRTIFI.Validated
        If Trim(cboFIPRTIFI.Text) = "" Then
            cboFIPRTIFI.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtFIPRDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRDESC.Validated
        If Trim(txtFIPRDESC.Text) = "" Then
            txtFIPRDESC.Text = "."
        End If

        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub
    Private Sub txtFIPRDIRE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRDIRE.Validated
        If Trim(cboFIPRCLSE.Text) = 1 Then
            If Trim(txtFIPRDIRE.Text) = "" Then
                txtFIPRDIRE.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
            Else
                If Trim(txtFIPRDIRE.Text) = "" Then
                    txtFIPRDIRE.Text = "."
                End If

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub chkFIPRCONJ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFIPRCONJ.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.Validated
        If Trim(txtFIPRMUNI.Text) = "" Then
            txtFIPRMUNI.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRMUNI.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRMUNI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRMUNI.Text)
                Formato = Format(Mascara, "000")
                txtFIPRMUNI.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.Validated
        If Trim(txtFIPRCORR.Text) = "" Or Trim(txtFIPRCORR.Text) = "0" Then
            txtFIPRCORR.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRCORR.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRCORR.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRCORR.Text)
                Formato = Format(Mascara, "00")
                txtFIPRCORR.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.Validated
        If Trim(txtFIPRBARR.Text) = "" Then
            txtFIPRBARR.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRBARR.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRBARR.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRBARR.Text)
                Formato = Format(Mascara, "000")
                txtFIPRBARR.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.Validated
        If Trim(txtFIPRMANZ.Text) = "" Or Trim(txtFIPRMANZ.Text) = "0" Then
            txtFIPRMANZ.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRMANZ.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRMANZ.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRMANZ.Text)
                Formato = Format(Mascara, "000")
                txtFIPRMANZ.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.Validated
        If Trim(txtFIPRPRED.Text) = "" Or Trim(txtFIPRPRED.Text) = "0" Then
            txtFIPRPRED.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRPRED.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRPRED.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRPRED.Text)
                Formato = Format(Mascara, "00000")
                txtFIPRPRED.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.Validated
        If Trim(txtFIPREDIF.Text) = "" Then
            txtFIPREDIF.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPREDIF.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPREDIF.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPREDIF.Text)
                Formato = Format(Mascara, "000")
                txtFIPREDIF.Text = Formato

                If Trim(txtFIPRMUAN.Text) = "" Then
                    txtFIPRMUAN.Text = txtFIPRMUNI.Text

                    Mascara = Val(txtFIPRMUAN.Text)
                    Formato = Format(Mascara, "000")
                    txtFIPRMUAN.Text = Formato
                End If

                If Trim(txtFIPRCOAN.Text) = "" Then
                    txtFIPRCOAN.Text = txtFIPRCORR.Text

                    Mascara = Val(txtFIPRCOAN.Text)
                    Formato = Format(Mascara, "00")
                    txtFIPRCOAN.Text = Formato
                End If

                If Trim(txtFIPRBAAN.Text) = "" Then
                    txtFIPRBAAN.Text = txtFIPRBARR.Text

                    Mascara = Val(txtFIPRBAAN.Text)
                    Formato = Format(Mascara, "000")
                    txtFIPRBAAN.Text = Formato
                End If

                If Trim(txtFIPRMAAN.Text) = "" Then
                    txtFIPRMAAN.Text = txtFIPRMANZ.Text

                    Mascara = Val(txtFIPRMAAN.Text)
                    Formato = Format(Mascara, "000")
                    txtFIPRMAAN.Text = Formato
                End If

                If Trim(txtFIPRPRAN.Text) = "" Then
                    txtFIPRPRAN.Text = txtFIPRPRED.Text

                    Mascara = Val(txtFIPRPRAN.Text)
                    Formato = Format(Mascara, "00000")
                    txtFIPRPRAN.Text = Formato
                End If

                If Trim(txtFIPREDAN.Text) = "" Then
                    txtFIPREDAN.Text = txtFIPREDIF.Text

                    Mascara = Val(txtFIPREDAN.Text)
                    Formato = Format(Mascara, "000")
                    txtFIPREDAN.Text = Formato
                End If

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.Validated
        If Trim(txtFIPRUNPR.Text) = "" Then
            txtFIPRUNPR.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRUNPR.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRUNPR.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRUNPR.Text)
                Formato = Format(Mascara, "00000")
                txtFIPRUNPR.Text = Formato

                If Trim(txtFIPRMUAN.Text) = "" Then
                    txtFIPRMUAN.Text = txtFIPRMUNI.Text

                    Mascara = Val(txtFIPRMUAN.Text)
                    Formato = Format(Mascara, "000")
                    txtFIPRMUAN.Text = Formato
                End If

                If Trim(txtFIPRCOAN.Text) = "" Then
                    txtFIPRCOAN.Text = txtFIPRCORR.Text

                    Mascara = Val(txtFIPRCOAN.Text)
                    Formato = Format(Mascara, "00")
                    txtFIPRCOAN.Text = Formato
                End If

                If Trim(txtFIPRBAAN.Text) = "" Then
                    txtFIPRBAAN.Text = txtFIPRBARR.Text

                    Mascara = Val(txtFIPRBAAN.Text)
                    Formato = Format(Mascara, "000")
                    txtFIPRBAAN.Text = Formato
                End If

                If Trim(txtFIPRMAAN.Text) = "" Then
                    txtFIPRMAAN.Text = txtFIPRMANZ.Text

                    Mascara = Val(txtFIPRMAAN.Text)
                    Formato = Format(Mascara, "000")
                    txtFIPRMAAN.Text = Formato
                End If

                If Trim(txtFIPRPRAN.Text) = "" Then
                    txtFIPRPRAN.Text = txtFIPRPRED.Text

                    Mascara = Val(txtFIPRPRAN.Text)
                    Formato = Format(Mascara, "00000")
                    txtFIPRPRAN.Text = Formato
                End If

                If Trim(txtFIPREDAN.Text) = "" Then
                    txtFIPREDAN.Text = txtFIPREDIF.Text

                    Mascara = Val(txtFIPREDAN.Text)
                    Formato = Format(Mascara, "000")
                    txtFIPREDAN.Text = Formato
                End If

                If Trim(txtFIPRUPAN.Text) = "" Then
                    txtFIPRUPAN.Text = txtFIPRUNPR.Text

                    Mascara = Val(txtFIPRUPAN.Text)
                    Formato = Format(Mascara, "00000")
                    txtFIPRUPAN.Text = Formato
                End If

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

            End If
        End If
    End Sub
    Private Sub txtFIPRMUAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUAN.Validated
        If Trim(txtFIPRMUAN.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRMUAN.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRMUAN.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRMUAN.Text)
                Formato = Format(Mascara, "000")
                txtFIPRMUAN.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRCOAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCOAN.Validated
        If Trim(txtFIPRCOAN.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRCOAN.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRCOAN.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRCOAN.Text)
                Formato = Format(Mascara, "00")
                txtFIPRCOAN.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRBAAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBAAN.Validated
        If Trim(txtFIPRBAAN.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRBAAN.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRBAAN.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRBAAN.Text)
                Formato = Format(Mascara, "000")
                txtFIPRBAAN.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRMAAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMAAN.Validated
        If Trim(txtFIPRMAAN.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRMAAN.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRMAAN.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRMAAN.Text)
                Formato = Format(Mascara, "000")
                txtFIPRMAAN.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRPRAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRAN.Validated
        If Trim(txtFIPRPRAN.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRPRAN.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRPRAN.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRPRAN.Text)
                Formato = Format(Mascara, "00000")
                txtFIPRPRAN.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPREDAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDAN.Validated
        If Trim(txtFIPREDAN.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPREDAN.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPREDAN.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPREDAN.Text)
                Formato = Format(Mascara, "000")
                txtFIPREDAN.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRUPAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUPAN.Validated
        If Trim(txtFIPRUPAN.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRUPAN.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRUPAN.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRUPAN.Text)
                Formato = Format(Mascara, "00000")
                txtFIPRUPAN.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub cboFIPRCLSE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCLSE.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboFIPRCASU_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCASU.Validated
        If Trim(cboFIPRCASU.Text) = "" Then
            cboFIPRCASU.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboFIPRCSAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCSAN.Validated
        If Trim(cboFIPRCSAN.Text) = "" Then
            cboFIPRCSAN.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboFIPRCASA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCASA.Validated
        If Trim(cboFIPRCASA.Text) = "" Then
            cboFIPRCASA.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboFIPRCAPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCAPR.Validated
        If Trim(cboFIPRCAPR.Text) = "" Then
            cboFIPRCAPR.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboFIPRESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRATLO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRATLO.Validated
        If Trim(txtFIPRATLO.Text) = "" Then
            txtFIPRATLO.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRATLO.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRATLO.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRACLO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRACLO.Validated
        If Trim(txtFIPRACLO.Text) = "" Then
            txtFIPRACLO.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRACLO.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRACLO.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRAPLO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRAPLO.Validated
        If Trim(txtFIPRAPLO.Text) = "" Then
            txtFIPRAPLO.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRAPLO.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRAPLO.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRTOED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRTOED.Validated
        If Trim(txtFIPRTOED.Text) = "" Then
            txtFIPRTOED.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRTOED.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRTOED.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRUNCO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNCO.Validated
        If Trim(txtFIPRUNCO.Text) = "" Then
            txtFIPRUNCO.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRUNCO.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRUNCO.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRURPH_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRURPH.Validated
        If Trim(txtFIPRURPH.Text) = "" Then
            txtFIPRURPH.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRURPH.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRURPH.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRAPCA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRAPCA.Validated
        If Trim(txtFIPRAPCA.Text) = "" Then
            txtFIPRAPCA.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRAPCA.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRAPCA.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRLOCA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRLOCA.Validated
        If Trim(txtFIPRLOCA.Text) = "" Then
            txtFIPRLOCA.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRLOCA.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRLOCA.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRCUUT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCUUT.Validated
        If Trim(txtFIPRCUUT.Text) = "" Then
            txtFIPRCUUT.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRCUUT.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRCUUT.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRGACU_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRGACU.Validated
        If Trim(txtFIPRGACU.Text) = "" Then
            txtFIPRGACU.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRGACU.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRGACU.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRGADE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRGADE.Validated
        If Trim(txtFIPRGADE.Text) = "" Then
            txtFIPRGADE.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRGADE.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRGADE.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRPISO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPISO.Validated
        If Trim(txtFIPRPISO.Text) = "" Then
            txtFIPRPISO.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRPISO.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRPISO.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    
#End Region

#Region "SelectedIndexChanged"

    Private Sub cboFIPRCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFIPRCLSE.SelectedIndexChanged
        lblFIPRCLSE.Text = fun_Buscar_Lista_Valores_CLASSECT(Trim(cboFIPRCLSE.Text))
    End Sub
    Private Sub cboFIPRCASU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFIPRCASU.SelectedIndexChanged
        lblFIPRCASU.Text = fun_Buscar_Lista_Valores_CATESUEL(Trim(cboFIPRCASU.Text))
    End Sub
    Private Sub cboFIPRCSAN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFIPRCSAN.SelectedIndexChanged
        lblFIPRCSAN.Text = fun_Buscar_Lista_Valores_CLASSECT(Trim(cboFIPRCSAN.Text))
    End Sub
    Private Sub cboFIPRCASA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFIPRCASA.SelectedIndexChanged
        lblFIPRCASA.Text = fun_Buscar_Lista_Valores_CATESUEL(Trim(cboFIPRCASA.Text))
    End Sub
    Private Sub cboFIPRCAPR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFIPRCAPR.SelectedIndexChanged
        lblFIPRCAPR.Text = fun_Buscar_Lista_Valores_CARAPRED(Trim(cboFIPRCAPR.Text))
    End Sub
  
#End Region

#Region "Clik"

    Private Sub cboFIPRCASU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCASU.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CATESUEL(cboFIPRCASU, cboFIPRCASU.SelectedIndex)
    End Sub
    Private Sub cboFIPRCSAN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCSAN.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT(cboFIPRCSAN, cboFIPRCSAN.SelectedIndex)
    End Sub
    Private Sub cboFIPRCASA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCASA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CATESUEL(cboFIPRCASA, cboFIPRCASA.SelectedIndex)
    End Sub
    Private Sub cboFIPRCAPR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCAPR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CARAPRED(cboFIPRCAPR, cboFIPRCAPR.SelectedIndex)
    End Sub

#End Region

#Region "TextChanged"

    Private Sub tstBAESDESC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tstBAESDESC.TextChanged
        ' coloca en modo de mensaje el texto que se muestra en la barra
        'If strBARRESTA.Items(1).Text <> "" Then
        '    MessageBox.Show(strBARRESTA.Items(1).Text, "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        'End If
    End Sub

#End Region

#Region "ResizeBegin"

    Private Sub frm_insertar_FICHPRED_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        Me.Opacity = vp_Opacity
    End Sub

#End Region

#Region "ResizeEnd"

    Private Sub frm_insertar_FICHPRED_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim opacity As Double = Convert.ToDouble(100)
        Me.Opacity = opacity
    End Sub

#End Region

#End Region

 
End Class