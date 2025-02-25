Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_modificar_TERCERO

    '=========================
    '*** MODIFICAR TERCERO ***
    '=========================

#Region "VARIABLES"

    Dim id As Integer

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#Region "CONSTRUCTORES"

    Public Sub New(ByVal idDataGrid As Integer)
        id = idDataGrid
        InitializeComponent()
        pro_inicializarControles()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        '=================================
        ' CARGA LOS COMBOBOX CON LOS DATOS 
        '=================================

        fun_Cargar_ComboBox_Con_Todos_Los_Datos_TIPODOCU(cboTERCTIDO, cboTERCTIDO.SelectedIndex)
        fun_Cargar_ComboBox_Con_Todos_Los_Datos_CALIPROP(cboTERCCAPR, cboTERCCAPR.SelectedIndex)
        fun_Cargar_ComboBox_Con_Todos_Los_Datos_SEXO(cboTERCSEXO, cboTERCSEXO.SelectedIndex)
        fun_Cargar_ComboBox_Con_Todos_Los_Datos_ESTADO(cboTERCESTA, cboTERCESTA.SelectedIndex)


        Dim objdatos As New cla_TERCERO
        Dim tbl As New DataTable

        tbl = objdatos.fun_Buscar_ID_TERCERO(id)

        txtTERCNUDO.Text = Trim(tbl.Rows(0).Item(1))
        cboTERCTIDO.SelectedValue = tbl.Rows(0).Item(2)
        cboTERCCAPR.SelectedValue = tbl.Rows(0).Item(3)
        cboTERCSEXO.SelectedValue = tbl.Rows(0).Item(4)
        txtTERCNOMB.Text = Trim(tbl.Rows(0).Item(5))
        txtTERCPRAP.Text = Trim(tbl.Rows(0).Item(6))
        txtTERCSEAP.Text = Trim(tbl.Rows(0).Item(7))
        txtTERCSICO.Text = Trim(tbl.Rows(0).Item(8))
        txtTERCTEL1.Text = Trim(tbl.Rows(0).Item(9))
        txtTERCTEL2.Text = Trim(tbl.Rows(0).Item(10))
        txtTERCFAX1.Text = Trim(tbl.Rows(0).Item(11))
        txtTERCDIRE.Text = Trim(tbl.Rows(0).Item(12))
        cboTERCESTA.SelectedValue = tbl.Rows(0).Item(13)
        txtTERCOBSE.Text = Trim(tbl.Rows(0).Item(18))

        '==========================================================
        ' CARGA LA DESCRIPCIÓN (Los reg. activos ya estan cargados)
        '==========================================================
        Try
            Dim boTERCTIDO As Boolean = fun_Buscar_Dato_TIPODOCU(cboTERCTIDO.SelectedValue)
            Dim boTERCCAPR As Boolean = fun_Buscar_Dato_CALIPROP(cboTERCCAPR.SelectedValue)
            Dim boTERCSEXO As Boolean = fun_Buscar_Dato_SEXO(cboTERCSEXO.SelectedValue)

            If boTERCTIDO = True OrElse boTERCCAPR = True OrElse boTERCSEXO = True Then

                lblTERCTIDO.Text = CType(fun_Buscar_Lista_Valores_TIPODOCU(cboTERCTIDO.SelectedValue), String)
                lblTERCCAPR.Text = CType(fun_Buscar_Lista_Valores_CALIPROP(cboTERCCAPR.SelectedValue), String)
                lblTERCSEXO.Text = CType(fun_Buscar_Lista_Valores_SEXO(cboTERCSEXO.SelectedValue), String)
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        cboTERCTIDO.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        txtTERCNUDO.Text = ""
        txtTERCNOMB.Text = ""
        txtTERCPRAP.Text = ""
        txtTERCSEAP.Text = ""
        txtTERCSICO.Text = ""
        txtTERCTEL1.Text = ""
        txtTERCTEL2.Text = ""
        txtTERCFAX1.Text = ""
        txtTERCDIRE.Text = ""
        txtTERCOBSE.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        If fun_Verificar_Campos_Llenos_6_DATOS(txtTERCNUDO.Text, cboTERCTIDO.Text, cboTERCCAPR.Text, cboTERCSEXO.Text, txtTERCNOMB.Text, txtTERCPRAP.Text) = True Then

            '==========================================================
            '*** BUSCA EL USUARIO QUE INGRESA Y LA FECHA DE INGRESO ***
            '==========================================================
            Dim objdatos1 As New cla_TERCERO
            Dim tbl1 As New DataTable

            tbl1 = objdatos1.fun_Buscar_ID_TERCERO(id)

            Dim stTERCUSIN As String = Trim(tbl1.Rows(0).Item(14))
            Dim daTERCFEIN As Date = Trim(tbl1.Rows(0).Item(16))

            '========================================
            '*** ACTUALIZA EL REGISTRO DE TERCERO ***
            '========================================

            Dim objdatos As New cla_TERCERO

            If (objdatos.fun_Actualizar_TERCERO(id, txtTERCNUDO.Text, cboTERCTIDO.SelectedValue, cboTERCCAPR.SelectedValue, cboTERCSEXO.SelectedValue, txtTERCNOMB.Text, txtTERCPRAP.Text, txtTERCSEAP.Text, txtTERCSICO.Text, txtTERCTEL1.Text, txtTERCTEL2.Text, txtTERCFAX1.Text, txtTERCDIRE.Text, cboTERCESTA.SelectedValue, stTERCUSIN, daTERCFEIN, txtTERCOBSE.Text)) Then
             

                '=============================================
                '*** ACTUALIZA EL REGISTRO EN PROPIETARIOS ***
                '=============================================

                ' buscar cadena de conexion
                Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                ' crear conexión
                oAdapter = New SqlDataAdapter
                oConexion = New SqlConnection(stCadenaConexion)

                ' abre la conexion
                oConexion.Open()

                ' variables
                Dim stFPPRNUDO As String = Trim(txtTERCNUDO.Text)
                Dim stFPPRCAPR As String = Trim(cboTERCCAPR.Text)
                Dim stFPPRSEXO As String = Trim(cboTERCSEXO.Text)
                Dim stFPPRTIDO As String = Trim(cboTERCTIDO.Text)
                Dim stFPPRPRAP As String = Trim(txtTERCPRAP.Text)
                Dim stFPPRSEAP As String = Trim(txtTERCSEAP.Text)
                Dim stFPPRNOMB As String = Trim(txtTERCNOMB.Text)
                Dim stFPPRSICO As String = Trim(txtTERCSICO.Text)

                ' parametros de la consulta
                Dim ParametrosConsulta As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "update FIPRPROP "
                ParametrosConsulta += "set FPPRTIDO = '" & stFPPRTIDO & "', "
                ParametrosConsulta += "FPPRSEXO = '" & stFPPRSEXO & "', "
                ParametrosConsulta += "FPPRCAPR = '" & stFPPRCAPR & "', "
                ParametrosConsulta += "FPPRNOMB = '" & stFPPRNOMB & "', "
                ParametrosConsulta += "FPPRPRAP = '" & stFPPRPRAP & "', "
                ParametrosConsulta += "FPPRSEAP = '" & stFPPRSEAP & "', "
                ParametrosConsulta += "FPPRSICO = '" & stFPPRSICO & "' "
                ParametrosConsulta += "where FPPRNUDO = '" & stFPPRNUDO & "'"

                ' ejecuta la consulta
                oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                ' procesa la consulta 
                oEjecutar.CommandTimeout = 0
                oEjecutar.CommandType = CommandType.Text

                oReader = oEjecutar.ExecuteReader

                Dim i As Integer = oReader.RecordsAffected

                ' cierra la conexion
                oConexion.Close()
                oReader = Nothing

                mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                cboTERCTIDO.Focus()
                Me.Close()
            Else
                mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
            End If

        Else
            mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
            cboTERCTIDO.Focus()
        End If

    End Sub

    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cboTERCTIDO.Focus()
        Me.Close()

    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txtTERCNUDO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCNUDO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTERCTIDO.Focus()
        End If
    End Sub
    Private Sub cboTERCTIDO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTERCTIDO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTERCCAPR.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Todos_Los_Datos_TIPODOCU(cboTERCTIDO, cboTERCTIDO.SelectedIndex)
        End If
    End Sub
    Private Sub cboTERCCAPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTERCCAPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTERCSEXO.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Todos_Los_Datos_CALIPROP(cboTERCCAPR, cboTERCCAPR.SelectedIndex)
        End If
    End Sub
    Private Sub cboTERCSEXO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTERCSEXO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTERCNOMB.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Todos_Los_Datos_SEXO(cboTERCSEXO, cboTERCSEXO.SelectedIndex)
        End If
    End Sub
    Private Sub txtTERCNOMB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCNOMB.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTERCPRAP.Focus()
        End If
    End Sub
    Private Sub txtTERCPRAP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCPRAP.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTERCSEAP.Focus()
        End If
    End Sub
    Private Sub txtTERCSEAP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCSEAP.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTERCSICO.Focus()
        End If
    End Sub
    Private Sub txtTERCSICO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCSICO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTERCTEL1.Focus()
        End If
    End Sub
    Private Sub txtTERCTEL1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCTEL1.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtTERCTEL2.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtTERCTEL2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCTEL2.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtTERCFAX1.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtTERCFAX1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCFAX1.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtTERCDIRE.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtTERCDIRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTERCDIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTERCESTA.Focus()
        End If
    End Sub
    Private Sub cboTERCESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTERCESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTERCNUDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCNUDO.Validated
        If Trim(txtTERCNUDO.Text) = "" Then
            txtTERCNUDO.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If

    End Sub
    Private Sub cboTERCTIDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCTIDO.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboTERCCAPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCCAPR.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboTERCSEXO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCSEXO.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtTERCNOMB_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCNOMB.Validated
        If Trim(txtTERCNOMB.Text) = "" Then
            txtTERCNOMB.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtTERCPRAP_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCPRAP.Validated
        If Trim(txtTERCPRAP.Text) = "" Then
            txtTERCPRAP.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtTERCSEAP_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCSEAP.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtTERCSICO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCSICO.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtTERCTEL1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCTEL1.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtTERCTEL2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCTEL2.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtTERCFAX1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCFAX1.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtTERCDIRE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCDIRE.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboTERCESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtTERCOBSE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCOBSE.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtTERCNUDO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCNUDO.GotFocus
        txtTERCNUDO.SelectionStart = 0
        txtTERCNUDO.SelectionLength = Len(txtTERCNUDO.Text)
        strBARRESTA.Items(0).Text = txtTERCNUDO.AccessibleDescription
    End Sub
    Private Sub cboTERCTIDO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCTIDO.GotFocus
        strBARRESTA.Items(0).Text = cboTERCTIDO.AccessibleDescription
    End Sub
    Private Sub cboTERCCAPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCCAPR.GotFocus
        strBARRESTA.Items(0).Text = cboTERCCAPR.AccessibleDescription
    End Sub
    Private Sub cboTERCSEXO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCSEXO.GotFocus
        strBARRESTA.Items(0).Text = cboTERCSEXO.AccessibleDescription
    End Sub
    Private Sub txtTERCNOMB_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCNOMB.GotFocus
        txtTERCNOMB.SelectionStart = 0
        txtTERCNOMB.SelectionLength = Len(txtTERCNOMB.Text)
        strBARRESTA.Items(0).Text = txtTERCNOMB.AccessibleDescription
    End Sub
    Private Sub txtTERCPRAP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCPRAP.GotFocus
        txtTERCPRAP.SelectionStart = 0
        txtTERCPRAP.SelectionLength = Len(txtTERCPRAP.Text)
        strBARRESTA.Items(0).Text = txtTERCPRAP.AccessibleDescription
    End Sub
    Private Sub txtTERCSEAP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCSEAP.GotFocus
        txtTERCSEAP.SelectionStart = 0
        txtTERCSEAP.SelectionLength = Len(txtTERCSEAP.Text)
        strBARRESTA.Items(0).Text = txtTERCSEAP.AccessibleDescription
    End Sub
    Private Sub txtTERCSICO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCSICO.GotFocus
        txtTERCSICO.SelectionStart = 0
        txtTERCSICO.SelectionLength = Len(txtTERCSICO.Text)
        strBARRESTA.Items(0).Text = txtTERCSICO.AccessibleDescription
    End Sub
    Private Sub txtTERCTEL1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCTEL1.GotFocus
        txtTERCTEL1.SelectionStart = 0
        txtTERCTEL1.SelectionLength = Len(txtTERCTEL1.Text)
        strBARRESTA.Items(0).Text = txtTERCTEL1.AccessibleDescription
    End Sub
    Private Sub txtTERCTEL2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCTEL2.GotFocus
        txtTERCTEL2.SelectionStart = 0
        txtTERCTEL2.SelectionLength = Len(txtTERCTEL2.Text)
        strBARRESTA.Items(0).Text = txtTERCTEL2.AccessibleDescription
    End Sub
    Private Sub txtTERCFAX1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCFAX1.GotFocus
        txtTERCFAX1.SelectionStart = 0
        txtTERCFAX1.SelectionLength = Len(txtTERCFAX1.Text)
        strBARRESTA.Items(0).Text = txtTERCFAX1.AccessibleDescription
    End Sub
    Private Sub txtTERCDIRE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCDIRE.GotFocus
        txtTERCDIRE.SelectionStart = 0
        txtTERCDIRE.SelectionLength = Len(txtTERCDIRE.Text)
        strBARRESTA.Items(0).Text = txtTERCDIRE.AccessibleDescription
    End Sub
    Private Sub cboTERCESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCESTA.GotFocus
        strBARRESTA.Items(0).Text = cboTERCESTA.AccessibleDescription
    End Sub
    Private Sub txtTERCOBSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTERCOBSE.GotFocus
        strBARRESTA.Items(0).Text = txtTERCOBSE.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTERCTIDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTERCTIDO.SelectedIndexChanged
        lblTERCTIDO.Text = CType(fun_Buscar_Lista_Valores_TIPODOCU(cboTERCTIDO.Text), String)
    End Sub
    Private Sub cboTERCCAPR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTERCCAPR.SelectedIndexChanged
        lblTERCCAPR.Text = CType(fun_Buscar_Lista_Valores_CALIPROP(cboTERCCAPR.Text), String)
    End Sub
    Private Sub cboTERCSEXO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTERCSEXO.SelectedIndexChanged
        lblTERCSEXO.Text = CType(fun_Buscar_Lista_Valores_SEXO(cboTERCSEXO.Text), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTERCTIDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCTIDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPODOCU(cboTERCTIDO, cboTERCTIDO.SelectedIndex)
    End Sub
    Private Sub cboTERCCAPR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCCAPR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CALIPROP(cboTERCCAPR, cboTERCCAPR.SelectedIndex)
    End Sub
    Private Sub cboTERCSEXO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTERCSEXO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_SEXO(cboTERCSEXO, cboTERCSEXO.SelectedIndex)
    End Sub

#End Region
    
#End Region

End Class