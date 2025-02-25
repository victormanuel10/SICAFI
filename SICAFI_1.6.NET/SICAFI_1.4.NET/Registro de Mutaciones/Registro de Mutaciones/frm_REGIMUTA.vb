Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_REGIMUTA

    '==============================
    '*** REGISTRO DE MUTACIONES ***
    '==============================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False

    Dim stMensaje01 As String = "¿ Desea cambiar el estado del tramite ? "

    Dim vl_stRutaDocumentos As String = ""
    Dim vl_stRutaImagenes As String = ""
    Dim vl_stRutaResolucion As String = ""

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_REGIMUTA
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_REGIMUTA
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

#Region "CONSTRUCTOR"

    Public Sub New(ByVal idCodigo As Integer)

        vp_inConsulta = idCodigo
        InitializeComponent()

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_VerificarCarpetaExistenteDocumentos() As Boolean

        Try
            Dim stRuta As String = ""
            Dim stCarpetaABuscar As String = ""

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(15)

            If tblRutas.Rows.Count > 0 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' directorio expediente 
                stCarpetaABuscar = Trim(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUMES").Value.ToString) & "-" & _
                                   Trim(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUVIGE").Value.ToString)

                Dim Ruta As New DirectoryInfo(stRuta)

                Dim TodasLasCarpetas(), CarpetaABuscar As DirectoryInfo

                ' declara la variable 
                Dim sw As Byte = 1

                TodasLasCarpetas = Ruta.GetDirectories()

                ' recorre el directorio
                For Each CarpetaABuscar In TodasLasCarpetas

                    If CarpetaABuscar.FullName = Ruta.FullName & stCarpetaABuscar Then
                        sw = 0

                        If sw = 0 Then
                            Exit For
                        End If

                    End If

                Next

                ' retorna la respuesta
                If sw = 1 Then
                    Return False
                Else
                    Return True
                End If

            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Function fun_ConsultaDatoAntesDeLa1Posicion(ByVal stArchivo As String) As String

        Dim stDato As String = ""

        Dim inTamano As Integer = stArchivo.Length
        Dim stLetra As String = ""
        Dim inContador As Integer = 0

        Dim sw2 As Integer = 0
        Dim j2 As Integer = 0

        While j2 < inTamano And sw2 = 0

            stLetra = stArchivo.Substring(j2, 1)

            If stLetra <> "" Then

                If stLetra = "-" Then
                    inContador += 1
                    sw2 = 1
                Else
                    stDato += stLetra
                End If

                j2 = j2 + 1

            ElseIf stLetra = "" Then
                sw2 = 1

            Else
                sw2 = 1

            End If

        End While

        Return stDato

    End Function
    Private Function fun_ConsultaDatoAntesDeLa2Posicion(ByVal stArchivo As String) As String

        Dim stDato As String = ""

        Dim inTamano As Integer = stArchivo.Length
        Dim stLetra As String = ""
        Dim inContador As Integer = 0

        Dim sw2 As Integer = 0
        Dim j2 As Integer = 0

        While j2 < inTamano And sw2 = 0

            stLetra = stArchivo.Substring(j2, 1)

            If stLetra <> "" Then

                If stLetra = "-" Then
                    inContador += 1
                End If

                If inContador = 1 Then
                    stDato += stLetra
                End If

                j2 = j2 + 1

            ElseIf stLetra = "-" And inContador = 2 Then
                sw2 = 1
            ElseIf stLetra = "" Then
                sw2 = 1
            Else
                sw2 = 1
            End If

        End While

        stDato = stDato.ToString.Substring(1, stDato.ToString.Length - 1)

        Return stDato

    End Function
    Private Function fun_ConsultaDatoDespuesDeLa2Posicion(ByVal stArchivo As String) As String

        Dim stDato As String = ""

        Dim inTamano As Integer = stArchivo.Length
        Dim stLetra As String = ""
        Dim inContador As Integer = 0

        Dim sw2 As Integer = 0
        Dim j2 As Integer = 0

        For j2 = 0 To inTamano - 1

            stLetra = stArchivo.Substring(j2, 1)

            If stLetra = "-" Or stLetra = "." Then
                inContador += 1
            End If

            If inContador = 2 And sw2 = 1 Then
                stDato += stLetra
            ElseIf inContador = 2 Then
                sw2 = 1
            End If

        Next

        Return stDato

    End Function
    Private Function fun_ContarGuiones(ByVal stArchivo As String) As Integer

        Try
            Dim inTamano As Integer = stArchivo.Length
            Dim stLetra As String = ""
            Dim inContador As Integer = 0

            Dim sw2 As Integer = 0
            Dim j2 As Integer = 0

            While j2 < inTamano And sw2 = 0

                stLetra = stArchivo.Substring(j2, 1)

                If stLetra <> "" Then

                    If stLetra = "-" Then
                        inContador += 1
                    End If

                    j2 = j2 + 1
                Else
                    j2 = j2 + 1
                End If

            End While

            Return inContador

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Private Function fun_CantidadRegistrosDePredios(ByVal inREMUSECU As Integer) As Integer

        Try
            ' declara la variable
            Dim inCANTIDAD As Integer = 0

            ' instancia la clase
            Dim obREMUPRED As New cla_REMUPRED
            Dim dtREMUPRED As New DataTable

            dtREMUPRED = obREMUPRED.fun_Buscar_CODIGO_X_SECUENCIA_REMUPRED(inREMUSECU)

            If dtREMUPRED.Rows.Count > 0 Then
                inCANTIDAD = dtREMUPRED.Rows.Count
            End If

            Return inCANTIDAD

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS REGISTRO DE MUTACIONES"

    Private Sub pro_ReconsultarRegistroMutaciones()

        Try
            Dim objdatos As New cla_REGIMUTA

            If boCONSULTA = False Then
                Me.BindingSource_REGIMUTA_1.DataSource = objdatos.fun_Consultar_REGIMUTA
            Else
                Me.BindingSource_REGIMUTA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REGIMUTA(vp_inConsulta)
            End If

            Me.dgvREGIMUTA_1.DataSource = BindingSource_REGIMUTA_1
            Me.BindingNavigator_REGIMUTA_1.BindingSource = BindingSource_REGIMUTA_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_REGIMUTA_1.Count

            Me.dgvREGIMUTA_1.Columns("REMUIDRE").HeaderText = "Id"
            Me.dgvREGIMUTA_1.Columns("REMUSECU").HeaderText = "Nro. Secuencia"

            Me.dgvREGIMUTA_1.Columns("REMUVIGE").HeaderText = "Vigencia"
            Me.dgvREGIMUTA_1.Columns("PERIDESC").HeaderText = "Mes"
            Me.dgvREGIMUTA_1.Columns("REMUFEIN").HeaderText = "Fecha Ingreso"
            Me.dgvREGIMUTA_1.Columns("REMUFEAS").HeaderText = "Fecha Asignación"
            Me.dgvREGIMUTA_1.Columns("REMUFEFI").HeaderText = "Fecha Finalización"
            Me.dgvREGIMUTA_1.Columns("REMUUSUA").HeaderText = "Usuario"
            Me.dgvREGIMUTA_1.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvREGIMUTA_1.Columns("REMUIDRE").Visible = False
            Me.dgvREGIMUTA_1.Columns("REMUMES").Visible = False
            Me.dgvREGIMUTA_1.Columns("REMUNUPR").Visible = False
            Me.dgvREGIMUTA_1.Columns("REMUNUAR").Visible = False
            Me.dgvREGIMUTA_1.Columns("REMUNUDO").Visible = False
            Me.dgvREGIMUTA_1.Columns("REMUOBSE").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_REGIMUTA_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_REGIMUTA_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_REGIMUTA.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_REGIMUTA.Enabled = boCONTMODI
            Me.cmdELIMINAR_REGIMUTA.Enabled = boCONTELIM
            Me.cmdCONSULTAR_REGIMUTA.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_REGIMUTA.Enabled = boCONTRECO


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresRegistroMutaciones()

        Try
            If Me.dgvREGIMUTA_1.RowCount > 0 Then

                Me.txtREMUNUPR.Text = Trim(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUNUPR").Value.ToString)
                Me.txtREMUNUAR.Text = Trim(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUNUAR").Value.ToString)
                Me.txtREMUOBSE.Text = Trim(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUOBSE").Value.ToString)

                Me.txtREMUUSUA.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUNUDO").Value.ToString), String)

                pro_ListaDeValoresRegistroPredios()

                pro_ReconsultarRegistroPredios()
                pro_ListaDeValoresRegistroPredios()

                pro_ListadoArchivosDocumentos()

            Else
                pro_LimpiarCamposRegistroMutaciones()
                pro_LimpiarCamposRegistroPredios()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposRegistroMutaciones()

        Me.txtREMUNUPR.Text = ""
        Me.txtREMUNUAR.Text = ""
        Me.txtREMUOBSE.Text = ""
        Me.txtREMUUSUA.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub

    Private Sub pro_EjecutarBotonObservaciones()

        Try
            If Me.dgvREGIMUTA_1.RowCount > 0 Then

                If MessageBox.Show("¿ Desea ingresar una observación al tramite Nro. " & Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim stObservacionNueva As String = InputBox("Ingrese la observación.", "Mensaje")

                    If Trim(stObservacionNueva) = "" Then
                        MessageBox.Show("Se requiere una observación.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                    Else

                        Dim stREMUOBSE_ACTUAL As String = ""
                        Dim stREMUOBSE_NUEVA As String = Trim(stObservacionNueva.ToString.ToUpper)

                        Dim obMOGEGEOG As New cla_REGIMUTA
                        Dim dtAJUSGEOG As New DataTable

                        dtAJUSGEOG = obMOGEGEOG.fun_Buscar_ID_REGIMUTA(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUIDRE").Value.ToString())

                        If dtAJUSGEOG.Rows.Count > 0 Then
                            stREMUOBSE_ACTUAL = Trim(dtAJUSGEOG.Rows(0).Item("REMUOBSE").ToString)
                        End If

                        If Trim(stREMUOBSE_ACTUAL) <> "" And Trim(stREMUOBSE_NUEVA) <> "" Then
                            stREMUOBSE_ACTUAL += vbCrLf & " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stREMUOBSE_NUEVA & ". "

                        ElseIf Trim(stREMUOBSE_ACTUAL) = "" And Trim(stREMUOBSE_NUEVA) <> "" Then
                            stREMUOBSE_ACTUAL = " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stREMUOBSE_NUEVA & ". "

                        End If

                        ' buscar cadena de conexion
                        Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion)

                        ' abre la conexion
                        oConexion.Open()

                        ' variables
                        Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUIDRE").Value.ToString())

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update REGIMUTA "
                        ParametrosConsulta += "set REMUOBSE = '" & stREMUOBSE_ACTUAL & "' "
                        ParametrosConsulta += "where REMUIDRE = '" & inMOGEIDRE & "' "

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

                        vp_inConsulta = inMOGEIDRE

                        boCONSULTA = True

                        pro_ReconsultarRegistroMutaciones()
                        pro_ListaDeValoresRegistroMutaciones()

                        Me.TabMAESTRO_2.SelectTab(TabObservaciones)

                    End If

                End If
            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GuardarCantidadDeArchivos(ByVal inIdRegistro As Integer, ByVal inCantidad As Integer)

        Try
            ' declara la instancia
            Dim obREGIMUTA As New cla_REGIMUTA

            obREGIMUTA.fun_Actualizar_NUAR_X_REGIMUTA(inIdRegistro, inCantidad)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GuardarCantidadDeRegistrosPredios(ByVal inIdRegistro As Integer, ByVal inCantidad As Integer)

        Try
            ' declara la instancia
            Dim obREGIMUTA As New cla_REGIMUTA

            obREGIMUTA.fun_Actualizar_NUPR_X_REGIMUTA(inIdRegistro, inCantidad)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "PROCEDIMIENTO REGISTRO DE PREDIOS"

    Private Sub pro_ReconsultarRegistroPredios()

        Try
            ' instancia la clase
            Dim obREMUPRED As New cla_REMUPRED
            Dim dtREMUPRED As New DataTable

            dtREMUPRED = obREMUPRED.fun_Buscar_CODIGO_X_SECUENCIA_REMUPRED(CInt(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUSECU").Value.ToString))

            If dtREMUPRED.Rows.Count > 0 Then

                '================================================
                '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
                '================================================

                Me.dgvREGIMUTA_2.DataSource = dtREMUPRED

                Me.dgvREGIMUTA_2.Columns("RMPRIDRE").HeaderText = "Id"
                Me.dgvREGIMUTA_2.Columns("RMPRSECU").HeaderText = "Nro. Secuencia"

                Me.dgvREGIMUTA_2.Columns("RMPRMUNI").HeaderText = "Municipio"
                Me.dgvREGIMUTA_2.Columns("RMPRCORR").HeaderText = "Correg."
                Me.dgvREGIMUTA_2.Columns("RMPRBARR").HeaderText = "Barrio"
                Me.dgvREGIMUTA_2.Columns("RMPRMANZ").HeaderText = "Manzana Vereda"
                Me.dgvREGIMUTA_2.Columns("RMPRPRED").HeaderText = "Predio"
                Me.dgvREGIMUTA_2.Columns("RMPREDIF").HeaderText = "Edificio"
                Me.dgvREGIMUTA_2.Columns("RMPRUNPR").HeaderText = "Unidad Predial"
                Me.dgvREGIMUTA_2.Columns("RMPRCLSE").HeaderText = "Sector"
                Me.dgvREGIMUTA_2.Columns("RMPRVIGE").HeaderText = "Vigencia"
                Me.dgvREGIMUTA_2.Columns("RMPRNUFI").HeaderText = "Nro. Ficha"
                Me.dgvREGIMUTA_2.Columns("RMPRMAIN").HeaderText = "Matricula"

                Me.dgvREGIMUTA_2.Columns("RMPRIDRE").Visible = False
                Me.dgvREGIMUTA_2.Columns("RMPRSECU").Visible = False
                Me.dgvREGIMUTA_2.Columns("RMPRDEPA").Visible = False
                Me.dgvREGIMUTA_2.Columns("RMPRFEIN").Visible = False
                Me.dgvREGIMUTA_2.Columns("RMPRESCR").Visible = False
                Me.dgvREGIMUTA_2.Columns("RMPRFEES").Visible = False
                Me.dgvREGIMUTA_2.Columns("RMPRNURE").Visible = False
                Me.dgvREGIMUTA_2.Columns("RMPRFERE").Visible = False

            Else

                Me.dgvREGIMUTA_2.DataSource = dtREMUPRED

                Me.dgvREGIMUTA_2.Columns("RMPRIDRE").HeaderText = "Id"
                Me.dgvREGIMUTA_2.Columns("RMPRSECU").HeaderText = "Nro. Secuencia"

                Me.dgvREGIMUTA_2.Columns("RMPRMUNI").HeaderText = "Municipio"
                Me.dgvREGIMUTA_2.Columns("RMPRCORR").HeaderText = "Correg."
                Me.dgvREGIMUTA_2.Columns("RMPRBARR").HeaderText = "Barrio"
                Me.dgvREGIMUTA_2.Columns("RMPRMANZ").HeaderText = "Manzana Vereda"
                Me.dgvREGIMUTA_2.Columns("RMPRPRED").HeaderText = "Predio"
                Me.dgvREGIMUTA_2.Columns("RMPREDIF").HeaderText = "Edificio"
                Me.dgvREGIMUTA_2.Columns("RMPRUNPR").HeaderText = "Unidad Predial"
                Me.dgvREGIMUTA_2.Columns("RMPRCLSE").HeaderText = "Sector"
                Me.dgvREGIMUTA_2.Columns("RMPRVIGE").HeaderText = "Vigencia"
                Me.dgvREGIMUTA_2.Columns("RMPRNUFI").HeaderText = "Nro. Ficha"
                Me.dgvREGIMUTA_2.Columns("RMPRMAIN").HeaderText = "Matricula"

                Me.dgvREGIMUTA_2.Columns("RMPRIDRE").Visible = False
                Me.dgvREGIMUTA_2.Columns("RMPRSECU").Visible = False
                Me.dgvREGIMUTA_2.Columns("RMPRDEPA").Visible = False
                Me.dgvREGIMUTA_2.Columns("RMPRFEIN").Visible = False
                Me.dgvREGIMUTA_2.Columns("RMPRESCR").Visible = False
                Me.dgvREGIMUTA_2.Columns("RMPRFEES").Visible = False
                Me.dgvREGIMUTA_2.Columns("RMPRNURE").Visible = False
                Me.dgvREGIMUTA_2.Columns("RMPRFERE").Visible = False

            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_REGIMUTA_1.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresRegistroPredios()

        Try
            If Me.dgvREGIMUTA_2.RowCount > 0 Then

                Me.txtRMPRNURE.Text = Trim(Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRNURE").Value.ToString)
                Me.txtRMPRFERE.Text = Trim(Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRFERE").Value.ToString)
                Me.txtRMPRESCR.Text = Trim(Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRESCR").Value.ToString)
                Me.txtRMPRFEES.Text = Trim(Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRFEES").Value.ToString)

                Me.lblRMPRMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRDEPA").Value.ToString, Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRMUNI").Value.ToString), String)
                Me.lblRMPRCORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO(Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRDEPA").Value.ToString, Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRMUNI").Value.ToString, Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRCLSE").Value.ToString, Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRCORR").Value.ToString), String)

                If CInt(Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRCLSE").Value.ToString) = 1 Then
                    Me.lblRMPRBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRDEPA").Value.ToString, Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRMUNI").Value.ToString, Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRCLSE").Value.ToString, Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRBARR").Value.ToString, Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRCLSE").Value.ToString) = 2 Then
                    Me.lblRMPRBAVE.Text = CType(fun_Buscar_Lista_Valores_VEREDA(Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRDEPA").Value.ToString, Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRMUNI").Value.ToString, Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRCLSE").Value.ToString, Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRMANZ").Value.ToString, Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRCLSE").Value.ToString) = 3 Then
                    Me.lblRMPRBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRDEPA").Value.ToString, Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRMUNI").Value.ToString, Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRCLSE").Value.ToString, Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRBARR").Value.ToString, Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRCORR").Value.ToString), String)
                End If

                Me.lblRMPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvREGIMUTA_2.SelectedRows.Item(0).Cells("RMPRCLSE").Value.ToString), String)

            Else
                pro_LimpiarCamposRegistroPredios()
                pro_LimpiarDocumentos()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposRegistroPredios()

        Me.lblRMPRBAVE.Text = ""
        Me.lblRMPRMUNI.Text = ""
        Me.lblRMPRCORR.Text = ""
        Me.lblRMPRCLSE.Text = ""
        Me.txtRMPRNURE.Text = ""
        Me.txtRMPRFERE.Text = ""
        Me.txtRMPRESCR.Text = ""
        Me.txtRMPRFEES.Text = ""

    End Sub
    Private Sub pro_GuardarRegistroPredios()

        Try
            ' declara la variable
            Dim ContentItem As String = ""

            ContentItem = Dir("*.*")

            ' verifca el objeto
            If ContentItem <> "" Then
                Me.lstLISTADO_DOCUMENTOS.Focus()
            End If

            ' recorre los arcchivos
            Do Until ContentItem = ""

                ' declara la variable
                Dim stNombreArchivo As String = Trim(ContentItem)

                ' declara la variable
                Dim inRMPRSECU As Integer = 0
                Dim stRMPRDEPA As String = ""
                Dim stRMPRMUNI As String = ""
                Dim stRMPRCORR As String = ""
                Dim stRMPRBARR As String = ""
                Dim stRMPRMANZ As String = ""
                Dim stRMPRPRED As String = ""
                Dim stRMPREDIF As String = ""
                Dim stRMPRUNPR As String = ""
                Dim inRMPRCLSE As Integer = 0
                Dim inRMPRVIGE As Integer = 0
                Dim stRMPRNURE As String = ""
                Dim stRMPRFERE As String = ""
                Dim inRMPRESCR As Integer = 0
                Dim stRMPRFEES As String = ""
                Dim inRMPRNUFI As Integer = 0
                Dim stRMPRMAIN As String = ""
                Dim daRMPRFEIN As Date = fun_fecha()

                ' declaro la variables
                Dim inCatidadGuines As Integer = fun_ContarGuiones(Trim(ContentItem))

                ' valida los guiones
                If inCatidadGuines = 2 Then

                    ' declara la variable
                    Dim stARCHMAIN As String = fun_ConsultaDatoAntesDeLa1Posicion(Trim(ContentItem))
                    Dim stARCHNURE As String = fun_ConsultaDatoAntesDeLa2Posicion(Trim(ContentItem))
                    Dim stARCHFERE As String = fun_ConsultaDatoDespuesDeLa2Posicion(Trim(ContentItem))

                    ' verifica los datos
                    Dim boARCHMAIN As Boolean = fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stARCHMAIN))
                    Dim boARCHNURE As Boolean = fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stARCHNURE))
                    Dim boARCHFERE As Boolean = False

                    ' estructura la fecha
                    If Trim(stARCHFERE).ToString.Length = 8 Then
                        Dim stDIA As String = Trim(stARCHFERE).ToString.Substring(0, 2)
                        Dim stMES As String = Trim(stARCHFERE).ToString.Substring(2, 2)
                        Dim stANO As String = Trim(stARCHFERE).ToString.Substring(4, 4)

                        boARCHFERE = fun_Verificar_Dato_Fecha_Evento_Validated(stDIA & "-" & stMES & "-" & stANO)

                        If boARCHFERE = True Then
                            stARCHFERE = stDIA & "-" & stMES & "-" & stANO
                        End If

                    End If

                    ' valida los datos de consulta
                    If boARCHMAIN = True And boARCHNURE = True And boARCHFERE = True Then

                        ' instancia la clase
                        Dim obMUTACIONES As New cla_MUTACIONES
                        Dim dtMUTACIONES As New DataTable

                        dtMUTACIONES = obMUTACIONES.fun_Buscar_MUTACIONES_X_MATRICULA(CStr(Trim(stARCHMAIN)))

                        If dtMUTACIONES.Rows.Count > 0 Then

                            ' llena las variables
                            inRMPRSECU = CInt(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUSECU").Value.ToString)
                            stRMPRDEPA = CStr(Trim(dtMUTACIONES.Rows(0).Item("MUTADEPA").ToString))
                            stRMPRMUNI = CStr(Trim(dtMUTACIONES.Rows(0).Item("MUTAMUNI").ToString))
                            stRMPRCORR = CStr(Trim(dtMUTACIONES.Rows(0).Item("MUTACORR").ToString))
                            stRMPRBARR = CStr(Trim(dtMUTACIONES.Rows(0).Item("MUTABARR").ToString))
                            stRMPRMANZ = CStr(Trim(dtMUTACIONES.Rows(0).Item("MUTAMANZ").ToString))
                            stRMPRPRED = CStr(Trim(dtMUTACIONES.Rows(0).Item("MUTAPRED").ToString))
                            stRMPREDIF = CStr(Trim(dtMUTACIONES.Rows(0).Item("MUTAEDIF").ToString))
                            stRMPRUNPR = CStr(Trim(dtMUTACIONES.Rows(0).Item("MUTAUNPR").ToString))
                            inRMPRCLSE = CInt(dtMUTACIONES.Rows(0).Item("MUTACLSE").ToString)
                            inRMPRVIGE = CInt(dtMUTACIONES.Rows(0).Item("MUTAVIGE").ToString)
                            stRMPRNURE = CInt(stARCHNURE)
                            stRMPRFERE = CStr(Trim(stARCHFERE))
                            inRMPRESCR = CInt(dtMUTACIONES.Rows(0).Item("MUTAESCR").ToString)
                            stRMPRFEES = CStr(Trim(dtMUTACIONES.Rows(0).Item("MUTAFEES").ToString))
                            inRMPRNUFI = CInt(dtMUTACIONES.Rows(0).Item("MUTANUFI").ToString)
                            stRMPRMAIN = CStr(Trim(dtMUTACIONES.Rows(0).Item("MUTAMAIN").ToString))

                            ' formato de fecha
                            stRMPRFEES = stRMPRFEES.ToString.Replace("/", "-")

                            ' instancia la clase
                            Dim obREMUPRED As New cla_REMUPRED
                            Dim dtREMUPRED As New DataTable

                            dtREMUPRED = obREMUPRED.fun_Buscar_CODIGO_X_REMUPRED(stRMPRDEPA, stRMPRMUNI, stRMPRCORR, stRMPRBARR, stRMPRMANZ, stRMPRPRED, stRMPREDIF, stRMPRUNPR, inRMPRCLSE, inRMPRSECU)

                            If dtREMUPRED.Rows.Count = 0 Then

                                ' insertar el registro
                                obREMUPRED.fun_Insertar_REMUPRED(inRMPRSECU, stRMPRDEPA, stRMPRMUNI, stRMPRCORR, stRMPRBARR, stRMPRMANZ, stRMPRPRED, stRMPREDIF, stRMPRUNPR, inRMPRCLSE, inRMPRVIGE, stARCHNURE, stARCHFERE, inRMPRESCR, stRMPRFEES, inRMPRNUFI, stRMPRMAIN)
                            End If

                        Else
                            ' instancia la clase
                            Dim obFIPRPROP As New cla_FIPRPROP
                            Dim dtFIPRPROP As New DataTable

                            dtFIPRPROP = obFIPRPROP.fun_Buscar_FIPRPROP_X_MATRICULA("001-" & fun_Formato_Mascara_7_Reales(stARCHMAIN))

                            If dtFIPRPROP.Rows.Count > 0 Then

                                ' declara la variable
                                Dim inFIPRNUFI As Integer = CInt(dtFIPRPROP.Rows(0).Item("FPPRNUFI").ToString)

                                inRMPRESCR = CInt(dtFIPRPROP.Rows(0).Item("FPPRESCR").ToString)
                                stRMPRFEES = CStr(Trim(dtFIPRPROP.Rows(0).Item("FPPRFEES").ToString))

                                ' instancia la clase
                                Dim obFICHPRED As New cla_FICHPRED
                                Dim dtFICHPRED As New DataTable

                                dtFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(inFIPRNUFI)

                                If dtFICHPRED.Rows.Count > 0 Then

                                    ' llena las variables
                                    inRMPRSECU = CInt(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUSECU").Value.ToString)
                                    stRMPRDEPA = CStr(Trim(dtFICHPRED.Rows(0).Item("FIPRDEPA").ToString))
                                    stRMPRMUNI = CStr(Trim(dtFICHPRED.Rows(0).Item("FIPRMUNI").ToString))
                                    stRMPRCORR = CStr(Trim(dtFICHPRED.Rows(0).Item("FIPRCORR").ToString))
                                    stRMPRBARR = CStr(Trim(dtFICHPRED.Rows(0).Item("FIPRBARR").ToString))
                                    stRMPRMANZ = CStr(Trim(dtFICHPRED.Rows(0).Item("FIPRMANZ").ToString))
                                    stRMPRPRED = CStr(Trim(dtFICHPRED.Rows(0).Item("FIPRPRED").ToString))
                                    stRMPREDIF = CStr(Trim(dtFICHPRED.Rows(0).Item("FIPREDIF").ToString))
                                    stRMPRUNPR = CStr(Trim(dtFICHPRED.Rows(0).Item("FIPRUNPR").ToString))
                                    inRMPRCLSE = CInt(dtFICHPRED.Rows(0).Item("FIPRCLSE").ToString)
                                    inRMPRVIGE = CInt(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUVIGE").Value.ToString)
                                    stRMPRNURE = CInt(stARCHNURE)
                                    stRMPRFERE = CStr(Trim(stARCHFERE))
                                    inRMPRESCR = CInt(inRMPRESCR)
                                    stRMPRFEES = CStr(Trim(stRMPRFEES))
                                    inRMPRNUFI = CInt(dtFICHPRED.Rows(0).Item("FIPRNUFI").ToString)
                                    stRMPRMAIN = CStr(Trim(stARCHMAIN))

                                    ' instancia la clase
                                    Dim obREMUPRED As New cla_REMUPRED
                                    Dim dtREMUPRED As New DataTable

                                    dtREMUPRED = obREMUPRED.fun_Buscar_CODIGO_X_REMUPRED(stRMPRDEPA, stRMPRMUNI, stRMPRCORR, stRMPRBARR, stRMPRMANZ, stRMPRPRED, stRMPREDIF, stRMPRUNPR, inRMPRCLSE, inRMPRSECU)

                                    If dtREMUPRED.Rows.Count = 0 Then

                                        ' insertar el registro
                                        obREMUPRED.fun_Insertar_REMUPRED(inRMPRSECU, stRMPRDEPA, stRMPRMUNI, stRMPRCORR, stRMPRBARR, stRMPRMANZ, stRMPRPRED, stRMPREDIF, stRMPRUNPR, inRMPRCLSE, inRMPRVIGE, stARCHNURE, stARCHFERE, inRMPRESCR, stRMPRFEES, inRMPRNUFI, stRMPRMAIN)
                                    End If

                                End If

                            End If

                        End If

                    End If
                End If
                'desplaza el registro
                ContentItem = Dir()

            Loop

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "PROCEDIMIENTOS DOCUMENTOS"

    Private Sub pro_ListadoArchivosDocumentos()

        Try
            Me.lstLISTADO_DOCUMENTOS.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(15)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentos() = True Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUMES").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUVIGE").Value.ToString) 

                vl_stRutaDocumentos = stNewPath


                ChDir(stNewPath)
                Me.lstLISTADO_DOCUMENTOS.Items.Clear()

                ContentItem = Dir("*.*")

                If ContentItem <> "" Then
                    Me.lstLISTADO_DOCUMENTOS.Focus()
                End If

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_DOCUMENTOS.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()
                Loop

            Else
                Me.lstLISTADO_DOCUMENTOS.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarDocumentos()

        Me.lstLISTADO_DOCUMENTOS.Items.Clear()

    End Sub

#End Region

#Region "MENU REGISTRO DE MUTACIONES"

    Private Sub cmdAGREGAR_REGIMUTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_REGIMUTA.Click

        Try
            If Me.dgvREGIMUTA_1.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_REGIMUTA(Integer.Parse(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
                frm_insertar.ShowDialog()
            Else
                frm_insertar_REGIMUTA.ShowDialog()
            End If

            boCONSULTA = False

            pro_ReconsultarRegistroMutaciones()
            pro_ListaDeValoresRegistroMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_REGIMUTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_REGIMUTA.Click

        Try
            Dim frm_modificar As New frm_modificar_REGIMUTA(Integer.Parse(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUIDRE").Value.ToString()),
                                                                          Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUNUDO").Value.ToString())
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarRegistroMutaciones()
            pro_ListaDeValoresRegistroMutaciones()

            Me.TabMAESTRO_2.SelectTab(TabInformacion)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_REGIMUTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_REGIMUTA.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_REGIMUTA

                If objdatos.fun_Eliminar_IDRE_REGIMUTA(Integer.Parse(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells(0).Value.ToString())) Then

                    boCONSULTA = False
                    pro_LimpiarCamposRegistroMutaciones()
                    pro_ReconsultarRegistroMutaciones()
                    pro_ListaDeValoresRegistroMutaciones()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_REGIMUTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_REGIMUTA.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_REGIMUTA(Integer.Parse(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUIDRE").Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarRegistroMutaciones()
            pro_ListaDeValoresRegistroMutaciones()

            Me.TabMAESTRO_2.SelectTab(TabInformacion)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_REGIMUTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_REGIMUTA.Click

        Try
            boCONSULTA = False
            pro_ReconsultarRegistroMutaciones()
            pro_ListaDeValoresRegistroMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click

        Try
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdIMPORTAR_DOCUMENTOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIMPORTAR_DOCUMENTOS.Click

        Try
            Dim frm_inserta_archivo As New frm_insertar_archivo_REGIMUTA(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUIDRE").Value.ToString(), _
                                                                         Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUMES").Value.ToString(), _
                                                                         Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUVIGE").Value.ToString())
            frm_inserta_archivo.ShowDialog()

            pro_ListadoArchivosDocumentos()

            pro_GuardarCantidadDeArchivos(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUIDRE").Value.ToString(), Me.lstLISTADO_DOCUMENTOS.Items.Count)
            pro_GuardarRegistroPredios()
            pro_GuardarCantidadDeRegistrosPredios(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUIDRE").Value.ToString(), fun_CantidadRegistrosDePredios(Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUSECU").Value.ToString()))

            vp_inConsulta = Me.dgvREGIMUTA_1.SelectedRows.Item(0).Cells("REMUIDRE").Value.ToString()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarRegistroMutaciones()
            pro_ListaDeValoresRegistroMutaciones()

            mod_MENSAJE.Proceso_Termino_Correctamente()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub cmdOBSERVACIONES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOBSERVACIONES.Click
        pro_EjecutarBotonObservaciones()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Try
            pro_ListaDeValoresRegistroMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        Try
            pro_ListaDeValoresRegistroMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click

        Try
            pro_ListaDeValoresRegistroMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click

        Try
            pro_ListaDeValoresRegistroMutaciones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_TRABCAMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        pro_ReconsultarRegistroMutaciones()
        pro_ListadoArchivosDocumentos()
        Me.strBARRESTA.Items(0).Text = "Registro de mutaciones"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_REGIMUTA_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValoresRegistroMutaciones()
    End Sub
    Private Sub dgvREGIMUTA_1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvREGIMUTA_1.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvREGIMUTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvREGIMUTA_1.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================


        If e.KeyCode = Keys.F2 Then
            If Me.cmdAGREGAR_REGIMUTA.Enabled = True Then
                Me.cmdAGREGAR_REGIMUTA.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If Me.cmdMODIFICAR_REGIMUTA.Enabled = True Then
                Me.cmdMODIFICAR_REGIMUTA.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_REGIMUTA_1.Count

                If ContarRegistros = 0 Then
                    mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
                Else
                    mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
                End If

            End If
        End If

        '===============================================================================================
        '*** ELIMINAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.Delete Then
            If Me.cmdELIMINAR_REGIMUTA.Enabled = True Then
                Me.cmdELIMINAR_REGIMUTA.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_REGIMUTA_1.Count

                If ContarRegistros = 0 Then
                    mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
                Else
                    mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
                End If

            End If
        End If

        '===============================================================================================
        '*** CONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F7 Then
            If Me.cmdCONSULTAR_REGIMUTA.Enabled = True Then
                Me.cmdCONSULTAR_REGIMUTA.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If Me.cmdCONSULTAR_REGIMUTA.Enabled = True Then
                Me.cmdRECONSULTAR_REGIMUTA.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvREGIMUTA_1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvREGIMUTA_1.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresRegistroMutaciones()
        End If
    End Sub
    Private Sub dgvREGIMUTA_2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvREGIMUTA_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresRegistroPredios()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvREGIMUTA_1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvREGIMUTA_1.CellClick
        pro_ListaDeValoresRegistroMutaciones()
    End Sub
    Private Sub dgvREGIMUTA_2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvREGIMUTA_2.CellClick
        pro_ListaDeValoresRegistroPredios()
    End Sub

#End Region

#Region "DoubleClick"

    Private Sub lstLISTADO_DOCUMENTOS_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLISTADO_DOCUMENTOS.DoubleClick

        Try
            If lstLISTADO_DOCUMENTOS.SelectedIndex <> -1 Then

                Dim stArchivo As String = lstLISTADO_DOCUMENTOS.SelectedItem
                Process.Start(vl_stRutaDocumentos & "\" & stArchivo)
            Else

                If lstLISTADO_DOCUMENTOS.Items.Count > 0 Then
                    MessageBox.Show("Seleccione un archivo de la lista", "mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#End Region

End Class