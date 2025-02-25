Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_modificar_FIPRCACO

    '=============================================
    '*** INSERTAR CALIFICACIÓN DE CONSTRUCCIÓN ***
    '=============================================

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inFIPRNUFI As Integer, _
                  ByVal inFIPRNURE As Integer, _
                  ByVal stRESODEPA As String, _
                  ByVal stRESOMUNI As String, _
                  ByVal inRESOTIRE As Integer, _
                  ByVal inRESOCLSE As Integer, _
                  ByVal inRESOVIGE As Integer, _
                  ByVal inRESORESO As Integer, _
                  ByVal stFPCOTIPO As String, _
                  ByVal inFPCOUNID As Integer, _
                  ByVal inFPCOCLCO As Integer, _
                  ByVal stFPCOTICO As String, _
                  ByVal inFPCCSECU As Integer)

        vp_FichaPredial = inFIPRNUFI
        vl_inFIPRNURE = inFIPRNURE
        vl_stRESODEPA = stRESODEPA
        vl_stRESOMUNI = stRESOMUNI
        vl_inRESOTIRE = inRESOTIRE
        vl_inRESOCLSE = inRESOCLSE
        vl_inRESOVIGE = inRESOVIGE
        vl_inRESORESO = inRESORESO
        vl_stFPCCTIPO = stFPCOTIPO
        vl_inFPCCUNID = inFPCOUNID
        vl_inFPCCCLCO = inFPCOCLCO
        vl_stFPCCTICO = stFPCOTICO
        vl_inFPCCSECU = inFPCCSECU

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
        pro_SumaPuntosDeCalificacionDeConstruccion()
        pro_ReconsultarCalificacion()


    End Sub

#End Region

#Region "VARIABLES"

    '*** VARIABLES QUE RECIBE DEL FORMULARIO DE FICHA PREDIAL ***
    Dim vl_inFIPRNURE As Integer
    Dim vl_stRESODEPA As String
    Dim vl_stRESOMUNI As String
    Dim vl_inRESOTIRE As Integer
    Dim vl_inRESOCLSE As Integer
    Dim vl_inRESOVIGE As Integer
    Dim vl_inRESORESO As Integer
    Dim vl_stFPCCTIPO As String
    Dim vl_inFPCCUNID As Integer
    Dim vl_inFPCCCLCO As Integer
    Dim vl_stFPCCTICO As String
    Dim vl_inFPCCSECU As Integer

    Dim vl_boSWVerificaDatoAlGuardar As Boolean = True

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        If vl_stFPCCTIPO = "R" Then
            rbdFPCCRESI.Checked = True
        Else
            rbdFPCCRESI.Checked = False
        End If

        If vl_stFPCCTIPO = "C" Then
            rbdFPCCCOME.Checked = True
        Else
            rbdFPCCCOME.Checked = False
        End If

        If vl_stFPCCTIPO = "I" Then
            rbdFPCCINDU.Checked = True
        Else
            rbdFPCCINDU.Checked = False
        End If

        If vl_stFPCCTIPO = "O" Then
            rbdFPCCOTRA.Checked = True
        Else
            rbdFPCCOTRA.Checked = False
        End If

    End Sub
    Private Sub pro_ReconsultarCalificacion()
        Try
            Dim objdatos As New cla_FIPRCACO

            BindingSource_FIPRCACO_1.DataSource = objdatos.fun_Consultar_FIPRCACO(vp_FichaPredial, vl_inFPCCUNID)
            BindingNavigator_FIPRCACO_1.BindingSource = BindingSource_FIPRCACO_1
            dgvFIPRCACO.DataSource = BindingSource_FIPRCACO_1.DataSource

            dgvFIPRCACO.Columns(0).Visible = False
            dgvFIPRCACO.Columns(1).Visible = False

            strBARRESTA.Items(2).Text = "Registros : " & dgvFIPRCACO.RowCount.ToString

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_SumaPuntosDeCalificacionDeConstruccion()
        Dim objdatos2 As New cla_FIPRCACO
        Dim tbl1 As New DataTable

        tbl1 = objdatos2.fun_Consultar_SUMA_X_FPCCPUNT_FIPRCACO(vp_FichaPredial, vl_inFPCCUNID)

        Dim i As Integer
        Dim inTOTAL As Integer

        If tbl1.Rows.Count > 0 Then

            For i = 0 To tbl1.Rows.Count - 1
                inTOTAL += CType(tbl1.Rows(i).Item(0), Integer)
            Next

        End If

        lblFPCCTOTA.Text = inTOTAL.ToString

    End Sub
    Private Sub pro_LimpiarCampos()
        txtFPCCCODI.Text = ""
        lblFPCCCOPA.Text = ""
        lblFPCCCOHI.Text = ""
        lblFPCCCODI.Text = ""
        lblFPCCTOTA.Text = ""
    End Sub

#End Region

#Region "FUNCIONES"

    Public Function fun_ConsultarCodigoCalificacion(ByVal inCODIGO_SUBBLOQUE As Integer) As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            Dim tbl As New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select * from fiprcaco where "
            ParametrosConsulta += "FpccNufi = '" & vp_FichaPredial & "' and "
            ParametrosConsulta += "FpccCodi like '" & inCODIGO_SUBBLOQUE & "%' and "
            ParametrosConsulta += "FpccUnid = '" & vl_inFPCCUNID & "'"

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(tbl)

            ' cierra la conexion
            oConexion.Close()

            Return tbl

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If Trim(txtFPCCCODI.Text) = "" Then
                txtFPCCCODI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
                ErrorProvider1.SetError(Me.txtFPCCCODI, "")
            Else
                ' colsulta si el codigo existe en los datos maestros
                Dim objdatos1 As New cla_CODICALI
                Dim tbl1 As New DataTable

                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CODICALI(Trim(txtFPCCCODI.Text))

                If tbl1.Rows.Count = 0 Then
                    txtFPCCCODI.Focus()
                    ErrorProvider1.SetError(Me.txtFPCCCODI, "Código de calificación no existe")
                    strBARRESTA.Items(1).Text = "Código de calificación no existe"
                    txtFPCCCODI.SelectionStart = 0
                    txtFPCCCODI.SelectionLength = Len(txtFPCCCODI.Text)
                Else
                    ' consulta si el codigo existe en un sub bloque de calificación
                    Dim inCODIGO_BLOQUE As Integer = CType(Trim(txtFPCCCODI.Text), Integer)
                    Dim inCODIGO_SUBBLOQUE As Integer = CType(Trim(txtFPCCCODI.Text).Substring(0, 2), Integer)

                    ' verifica por cual sub-bloque realiza la OPERACIÓN
                    If inCODIGO_SUBBLOQUE = 11 Or _
                        inCODIGO_SUBBLOQUE = 12 Or _
                        inCODIGO_SUBBLOQUE = 13 Or _
                        inCODIGO_SUBBLOQUE = 14 Or _
                        inCODIGO_SUBBLOQUE = 21 Or _
                        inCODIGO_SUBBLOQUE = 22 Or _
                        inCODIGO_SUBBLOQUE = 23 Or _
                        inCODIGO_SUBBLOQUE = 24 Or _
                        inCODIGO_SUBBLOQUE = 31 Or _
                        inCODIGO_SUBBLOQUE = 32 Or _
                        inCODIGO_SUBBLOQUE = 33 Or _
                        inCODIGO_SUBBLOQUE = 34 Or _
                        inCODIGO_SUBBLOQUE = 41 Or _
                        inCODIGO_SUBBLOQUE = 42 Or _
                        inCODIGO_SUBBLOQUE = 43 Or _
                        inCODIGO_SUBBLOQUE = 44 Then

                        ' inicializo la tabla
                        dt = New DataTable

                        ' ejecuto la consulta
                        dt = fun_ConsultarCodigoCalificacion(inCODIGO_SUBBLOQUE)

                        If dt.Rows.Count > 0 Then

                            ' elimina el código existente
                            Dim objdatos15 As New cla_FIPRCACO

                            objdatos15.fun_Eliminar_Por_Codigo_FIPRCACO(vp_FichaPredial, vl_inFPCCUNID, dt.Rows(0).Item("FPCCCODI"))

                        End If

                        'Consulta los puntos segun codigo y tipo de calificacion
                        Dim objdatos3 As New cla_CODICACO
                        Dim tbl3 As New DataTable

                        tbl3 = objdatos3.fun_Consultar_PUNTOS_DE_CALIFICACION_X_CODIGO_Y_TIPO(Trim(txtFPCCCODI.Text), vl_stFPCCTIPO)

                        If tbl3.Rows.Count = 0 Then
                            txtFPCCCODI.Focus()
                            ErrorProvider1.SetError(Me.txtFPCCCODI, "No existe puntos para el codigo " & Trim(txtFPCCCODI.Text) & " de tipo " & vl_stFPCCTIPO)
                            strBARRESTA.Items(1).Text = "No existe puntos para el codigo " & Trim(txtFPCCCODI.Text) & " de tipo " & vl_stFPCCTIPO
                            txtFPCCCODI.SelectionStart = 0
                            txtFPCCCODI.SelectionLength = Len(txtFPCCCODI.Text)
                        Else
                            Dim inFPCCPUNT As Integer = 0

                            inFPCCPUNT = CType(tbl3.Rows(0).Item(3), Integer)

                            ' guarda la calificacion de construccion
                            Dim objdatos4 As New cla_FIPRCACO

                            If (objdatos4.fun_Insertar_FIPRCACO(vp_FichaPredial, Trim(txtFPCCCODI.Text), vl_stFPCCTIPO, inFPCCPUNT, vl_inFPCCUNID, vl_inFPCCCLCO, vl_stFPCCTICO, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, vl_inFPCCSECU, vl_inFIPRNURE, "ac")) Then
                                ErrorProvider1.SetError(Me.txtFPCCCODI, "")

                                strBARRESTA.Items(1).Text = ""

                                txtFPCCCODI.Text = ""
                                lblFPCCCOPA.Text = ""
                                lblFPCCCOHI.Text = ""
                                lblFPCCCODI.Text = ""

                                pro_ReconsultarCalificacion()
                                pro_SumaPuntosDeCalificacionDeConstruccion()

                                txtFPCCCODI.Focus()
                            Else
                                mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                            End If
                        End If

                        txtFPCCCODI.Focus()
                    Else
                        ' si el codigo son cerchas
                        If inCODIGO_SUBBLOQUE = 51 Then

                            'Consulta los puntos segun codigo y tipo de calificacion
                            Dim objdatos3 As New cla_CODICACO
                            Dim tbl3 As New DataTable

                            tbl3 = objdatos3.fun_Consultar_PUNTOS_DE_CALIFICACION_X_CODIGO_Y_TIPO(Trim(txtFPCCCODI.Text), vl_stFPCCTIPO)

                            If tbl3.Rows.Count = 0 Then
                                txtFPCCCODI.Focus()
                                ErrorProvider1.SetError(Me.txtFPCCCODI, "No existe puntos para el codigo " & Trim(txtFPCCCODI.Text) & " de tipo " & vl_stFPCCTIPO)
                                strBARRESTA.Items(1).Text = "No existe puntos para el codigo " & Trim(txtFPCCCODI.Text) & " de tipo " & vl_stFPCCTIPO
                                txtFPCCCODI.SelectionStart = 0
                                txtFPCCCODI.SelectionLength = Len(txtFPCCCODI.Text)
                            Else
                                Dim inFPCCPUNT As Integer = 0

                                inFPCCPUNT = CType(tbl3.Rows(0).Item(3), Integer)

                                ' guarda la calificacion de construccion
                                Dim objdatos4 As New cla_FIPRCACO

                                If (objdatos4.fun_Insertar_FIPRCACO(vp_FichaPredial, Trim(txtFPCCCODI.Text), vl_stFPCCTIPO, inFPCCPUNT, vl_inFPCCUNID, vl_inFPCCCLCO, vl_stFPCCTICO, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, vl_inFPCCSECU, vl_inFIPRNURE, "ac")) Then
                                    ErrorProvider1.SetError(Me.txtFPCCCODI, "")

                                    strBARRESTA.Items(1).Text = ""

                                    txtFPCCCODI.Text = ""
                                    lblFPCCCOPA.Text = ""
                                    lblFPCCCOHI.Text = ""
                                    lblFPCCCODI.Text = ""

                                    pro_ReconsultarCalificacion()
                                    pro_SumaPuntosDeCalificacionDeConstruccion()

                                    txtFPCCCODI.Focus()
                                Else
                                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                                End If
                            End If

                            txtFPCCCODI.Focus()

                        End If

                    End If
                End If
            End If
            

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click
        Try
            Dim objdatos As New cla_FIPRCACO
            Dim tbl10 As New DataTable

            tbl10 = objdatos.fun_Buscar_CODIGO_FIPRCACO(vp_FichaPredial, Trim(dgvFIPRCACO.CurrentRow.Cells(2).Value.ToString()), vl_inFPCCUNID)

            Dim Codigo As String = Trim(dgvFIPRCACO.CurrentRow.Cells(2).Value.ToString())

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim objdatos1 As New cla_FIPRCACO

                If objdatos1.fun_Eliminar_FIPRCACO(Val(tbl10.Rows(0).Item(0))) = True Then

                    pro_ReconsultarCalificacion()
                    pro_SumaPuntosDeCalificacionDeConstruccion()
                    txtFPCCCODI.Focus()

                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtFPCCCODI.Focus()

        ' actualiza los tipo residencial, comercial e industrial
        If vl_stFPCCTIPO <> "O" Then

            '=============================================
            '*** ACTUALIZA EL REGISTRO EN CONSTRUCCIÓN ***
            '=============================================

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' variables
            Dim stFPCCNUFI As String = vp_FichaPredial
            Dim stFPCCUNID As String = vl_inFPCCUNID
            Dim stFPCCPUNT As String = Trim(lblFPCCTOTA.Text)


            ' Concatena la condicion de la consulta
            ParametrosConsulta += "update FIPRCONS "
            ParametrosConsulta += "set FPCOPUNT = '" & stFPCCPUNT & "' "
            ParametrosConsulta += "where FPCONUFI = '" & stFPCCNUFI & "' and "
            ParametrosConsulta += "FPCOUNID = '" & stFPCCUNID & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oReader = oEjecutar.ExecuteReader

            ' cierra la conexion
            oConexion.Close()
            oReader = Nothing

        End If
        Me.Close()

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_FIPRCACO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtFPCCCODI.Focus()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtFPCCCODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCCCODI.GotFocus
        txtFPCCCODI.SelectionStart = 0
        txtFPCCCODI.SelectionLength = Len(txtFPCCCODI.Text)
        strBARRESTA.Items(0).Text = txtFPCCCODI.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdELIMINAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.GotFocus
        strBARRESTA.Items(0).Text = cmdELIMINAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub dgvFIPRCACO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFIPRCACO.GotFocus
        strBARRESTA.Items(0).Text = dgvFIPRCACO.AccessibleDescription
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtFPCCCODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCCCODI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    cmdGUARDAR.PerformClick()
                End If
            End If
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFPCCCODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCCCODI.Validated
        Try
            'If Trim(txtFPCCCODI.Text) = "" Then
            '    txtFPCCCODI.Focus()
            '    strBARRESTA.Items(1).Text = IncoValoNume
            '    ErrorProvider1.SetError(Me.txtFPCCCODI, "")
            'Else
            '    ' colsulta si el codigo existe en los datos maestros
            '    Dim objdatos1 As New cla_CODICALI
            '    Dim tbl1 As New DataTable

            '    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CODICALI(Trim(txtFPCCCODI.Text))

            '    If tbl1.Rows.Count = 0 Then
            '        txtFPCCCODI.Focus()
            '        ErrorProvider1.SetError(Me.txtFPCCCODI, "Código de calificación no existe")
            '        strBARRESTA.Items(1).Text = "Código de calificación no existe"
            '    Else
            '        ' consulta si el codigo existe en el bloque de calificación
            '        Dim objdatos As New cla_FIPRCACO
            '        Dim tbl As New DataTable

            '        tbl = objdatos.fun_Buscar_CODIGO_FIPRCACO(vp_FichaPredial, Trim(txtFPCCCODI.Text), vl_inFPCCUNID)

            '        If tbl.Rows.Count > 0 Then
            '            txtFPCCCODI.Focus()
            '            ErrorProvider1.SetError(Me.txtFPCCCODI, "Código de calificación existente en base de datos")
            '            strBARRESTA.Items(1).Text = "Código de calificación existente en base de datos"
            '        Else
            '            ' consulta si el codigo existe en un sub bloque de calificación
            '            Dim inCODIGO_SUBBLOQUE As Integer = CType(Trim(txtFPCCCODI.Text).Substring(0, 2), Integer)

            '            ' verifica por que subbloque realiza la consulta
            '            If inCODIGO_SUBBLOQUE = 11 Or _
            '                inCODIGO_SUBBLOQUE = 12 Or _
            '                inCODIGO_SUBBLOQUE = 13 Or _
            '                inCODIGO_SUBBLOQUE = 14 Or _
            '                inCODIGO_SUBBLOQUE = 21 Or _
            '                inCODIGO_SUBBLOQUE = 22 Or _
            '                inCODIGO_SUBBLOQUE = 23 Or _
            '                inCODIGO_SUBBLOQUE = 24 Or _
            '                inCODIGO_SUBBLOQUE = 31 Or _
            '                inCODIGO_SUBBLOQUE = 32 Or _
            '                inCODIGO_SUBBLOQUE = 33 Or _
            '                inCODIGO_SUBBLOQUE = 34 Or _
            '                inCODIGO_SUBBLOQUE = 41 Or _
            '                inCODIGO_SUBBLOQUE = 42 Or _
            '                inCODIGO_SUBBLOQUE = 43 Or _
            '                inCODIGO_SUBBLOQUE = 44 Then

            '                ' buscar cadena de conexion
            '                Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            '                Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            '                ' crea el datatable
            '                dt = New DataTable

            '                ' crear conexión
            '                oAdapter = New SqlDataAdapter
            '                oConexion = New SqlConnection(stCadenaConexion)

            '                ' abre la conexion
            '                oConexion.Open()

            '                ' parametros de la consulta
            '                Dim ParametrosConsulta As String = ""

            '                ' Concatena la condicion de la consulta
            '                ParametrosConsulta += "Select * from fiprcaco where "
            '                ParametrosConsulta += "FpccNufi = '" & vp_FichaPredial & "' and "
            '                ParametrosConsulta += "FpccCodi like '" & inCODIGO_SUBBLOQUE & "%' and "
            '                ParametrosConsulta += "FpccUnid = '" & vl_inFPCCUNID & "'"

            '                ' ejecuta la consulta
            '                oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            '                ' procesa la consulta 
            '                oEjecutar.CommandTimeout = 360
            '                oEjecutar.CommandType = CommandType.Text
            '                oAdapter.SelectCommand = oEjecutar

            '                ' llena el datatable 
            '                oAdapter.Fill(dt)

            '                ' cierra la conexion
            '                oConexion.Close()

            '                ' cuenta los registros
            '                If dt.Rows.Count > 0 Then
            '                    txtFPCCCODI.Focus()
            '                    ErrorProvider1.SetError(Me.txtFPCCCODI, "Código de calificación existente en el subbloque")
            '                    strBARRESTA.Items(1).Text = "Código de calificación existente en el subbloque"
            '                Else
            '                    ErrorProvider1.SetError(Me.txtFPCCCODI, "")
            '                    strBARRESTA.Items(1).Text = ""

            '                    strBARRESTA.Items(0).Text = ""
            '                    strBARRESTA.Items(1).Text = ""

            '                End If
            '            End If
            '        End If
            '    End If
            'End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtFPCCCODI_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCCCODI.TextChanged
        Dim inLONGITUG As Integer

        inLONGITUG = CType(Trim(txtFPCCCODI.Text).Length.ToString, Integer)

        If inLONGITUG = 3 Then
            '===========================================
            'CARGA LA DESCRIPCIÓN DE LA LISTA DE VALORES
            '===========================================

            lblFPCCCODI.Text = CType(fun_Buscar_Lista_Valores_CODICALI(txtFPCCCODI.Text), String)
            lblFPCCCOPA.Text = CType(fun_Buscar_Lista_Valores_CODICALI_COCACOPA(txtFPCCCODI.Text), String)
            lblFPCCCOHI.Text = CType(fun_Buscar_Lista_Valores_CODICALI_COCACOHI(txtFPCCCODI.Text), String)

        End If

        If inLONGITUG = 0 Then
            ErrorProvider1.SetError(Me.txtFPCCCODI, "")
            lblFPCCCOPA.Text = ""
            lblFPCCCOHI.Text = ""
            lblFPCCCODI.Text = ""
            strBARRESTA.Items(1).Text = ""
        End If

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