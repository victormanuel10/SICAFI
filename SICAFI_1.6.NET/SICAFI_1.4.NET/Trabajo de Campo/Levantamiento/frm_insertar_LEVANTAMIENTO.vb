Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_insertar_LEVANTAMIENTO

    '==============================
    '*** INSERTAR LEVANTAMIENTO ***
    '==============================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer
    Dim inLEVASECU As Integer
    Dim stLEVANUDO As String

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inSECU As Integer)
        inLEVASECU = inSECU

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub
    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer, ByVal stNUDO As String)
        inID_REGISTRO = inIDRE
        inLEVASECU = inSECU
        stLEVANUDO = Trim(stNUDO)

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_ConsultaNombreUsuario(ByVal stNUMEDOCU As String) As String

        Try
            ' declara la variable
            Dim stUSUARIO As String = ""

            ' declara la instancia
            Dim obCONTRASENA As New cla_CONTRASENA
            Dim dtCONTRASENA As New DataTable

            dtCONTRASENA = obCONTRASENA.fun_Buscar_CODIGO_CONTRASENA(Trim(stNUMEDOCU))

            If dtCONTRASENA.Rows.Count > 0 Then
                stUSUARIO = Trim(dtCONTRASENA.Rows(0).Item("CONTUSUA").ToString)
            End If

            Return stUSUARIO

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_NumeroDeSecuenciaDeRegistro() As Integer

        Try
            Dim inFPDESECU As Integer = 0

            Dim objdatos5 As New cla_MOVIGEOG
            Dim tbl10 As New DataTable

            tbl10 = objdatos5.fun_Buscar_SECUENCIA_X_MOVIGEOG

            If tbl10.Rows.Count = 0 Then
                inFPDESECU = 1
            Else
                Dim i As Integer
                Dim NroMayor As Integer
                Dim Posicion As Integer

                Posicion = Val(tbl10.Rows(0).Item("MOGESECU"))

                For i = 0 To tbl10.Rows.Count - 1
                    NroMayor = Val(tbl10.Rows(i).Item("MOGESECU"))

                    If NroMayor > Posicion Then
                        inFPDESECU = NroMayor
                        Posicion = NroMayor
                    Else
                        inFPDESECU = Posicion
                    End If
                Next

                inFPDESECU += 1
            End If

            Return inFPDESECU

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboLEVANUDO.DataSource = New DataTable

        Me.txtLEVANUDO.Text = ""
        Me.txtLEVAFEEN.Text = ""
        Me.txtLEVAFERE.Text = ""
        Me.txtLEVAOBSE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try

            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_LEVANTAMIENTO
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_CODIGO_X_LEVANTAMIENTO(inID_REGISTRO, inLEVASECU, Trim(stLEVANUDO))

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraLEVANTAMIENTO.Text = "MODIFICAR LEVANTAMIENTO"

                    Me.cboLEVANUDO.Enabled = False

                    Dim objdatos1 As New cla_USUARIO

                    Me.cboLEVANUDO.DataSource = objdatos1.fun_Buscar_CODIGO_USUARIO(stLEVANUDO)
                    Me.cboLEVANUDO.DisplayMember = "USUANOMB"
                    Me.cboLEVANUDO.ValueMember = "USUANUDO"

                    Me.txtLEVANUDO.Text = Trim(tbl.Rows(0).Item("LEVANUDO"))
                    Me.txtLEVAFEEN.Text = Trim(tbl.Rows(0).Item("LEVAFEEN"))
                    Me.txtLEVAFERE.Text = Trim(tbl.Rows(0).Item("LEVAFERE"))
                    Me.txtLEVAOBSE.Text = Trim(tbl.Rows(0).Item("LEVAOBSE"))

                    Me.txtLEVAFEEN.Enabled = False
                    Me.dtpLEVAFEEN.Enabled = False

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraLEVANTAMIENTO.Text = "INSERTAR LEVANTAMIENTO"

                Me.dtpLEVAFEEN.MaxDate = DateTime.Today
                Me.dtpLEVAFERE.MaxDate = DateTime.Today

                Me.dtpLEVAFEEN.Value = fun_fecha()
                'Me.dtpLEVAFERE.Value = fun_fecha()

                Me.txtLEVAFEEN.Text = fun_fecha()
                Me.txtLEVAFERE.Text = ""

                Me.txtLEVAFERE.Enabled = False
                Me.dtpLEVAFERE.Enabled = False

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_InsertarMovimientoGeografico(ByVal inLEVASECU As Integer, ByVal stLEVANUDO As String, ByVal stLEVAFEEN As String)

        Try
            ' instancia la clase
            Dim obTRABCAMP As New cla_TRABCAMP
            Dim dtTRABCAMP As New DataTable

            dtTRABCAMP = obTRABCAMP.fun_Buscar_CODIGO_X_TRABCAMP(inLEVASECU)

            If dtTRABCAMP.Rows.Count > 0 Then

                ' declara la variables
                Dim inTRCASECU As Integer = inLEVASECU
                Dim stTRCANUDO As String = Trim(stLEVANUDO)
                Dim stTRCAFEEN As String = Trim(stLEVAFEEN).ToString.Replace("-", "/")
                Dim stTRCADEPA As String = CStr(Trim(dtTRABCAMP.Rows(0).Item("TRCADEPA").ToString))
                Dim stTRCAMUNI As String = CStr(Trim(dtTRABCAMP.Rows(0).Item("TRCAMUNI").ToString))
                Dim stTRCACORR As String = CStr(Trim(dtTRABCAMP.Rows(0).Item("TRCACORR").ToString))
                Dim stTRCABARR As String = CStr(Trim(dtTRABCAMP.Rows(0).Item("TRCABARR").ToString))
                Dim stTRCAMANZ As String = CStr(Trim(dtTRABCAMP.Rows(0).Item("TRCAMANZ").ToString))
                Dim stTRCAPRED As String = CStr(Trim(dtTRABCAMP.Rows(0).Item("TRCAPRED").ToString))
                Dim inTRCACLSE As Integer = CInt(dtTRABCAMP.Rows(0).Item("TRCACLSE"))
                Dim inTRCAVIGE As Integer = CInt(dtTRABCAMP.Rows(0).Item("TRCAVIGE"))
                Dim stTRCACAAC As String = CStr(Trim(dtTRABCAMP.Rows(0).Item("TRCACAAC").ToString))
                Dim stTRCAESTA As String = "as"
                Dim boMOGEUSUA As Boolean = False
                Dim inMOGECLVE As Integer = 1
                Dim stMOGEFFMU As String = ""
                Dim stFORMULARIO As String = "Movimiento Geografico"

                Dim stRECLOBSE_NUEVA As String = CStr(Trim(Me.txtLEVAOBSE.Text))
                Dim stMOGEUSUA As String = fun_ConsultaNombreUsuario(Trim(stTRCANUDO))

                If Trim(stMOGEUSUA) = "" Then
                    boMOGEUSUA = False
                    MessageBox.Show("El funcionario seleccionado no registra un perfil de usuario", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    boMOGEUSUA = True
                End If

                ' declara la clase
                Dim obMOVIGEOG As New cla_MOVIGEOG
                Dim dtMOVIGEOG As New DataTable

                dtMOVIGEOG = obMOVIGEOG.fun_Buscar_CODIGO_X_MOVIGEOG(inTRCASECU)

                If dtMOVIGEOG.Rows.Count = 0 Then

                    ' verifica que exista el roles de usuario
                    If boMOGEUSUA = True Then

                        If Trim(stRECLOBSE_NUEVA) = "" And dtMOVIGEOG.Rows.Count = 0 Then
                            stRECLOBSE_NUEVA = "Asigno el tramite de " & stFORMULARIO
                        End If

                        Dim stMOGEOBSE As String = " Nota ingresada por: " & vp_usuario & " " & fun_fecha() & " : " & stRECLOBSE_NUEVA & ". "

                        If obMOVIGEOG.fun_Insertar_MOVIGEOG(inTRCASECU, _
                                                            stTRCAMUNI, _
                                                            stTRCACORR, _
                                                            stTRCABARR, _
                                                            stTRCAMANZ, _
                                                            stTRCAPRED, _
                                                            inTRCACLSE, _
                                                            inTRCAVIGE, _
                                                            stTRCANUDO, _
                                                            stMOGEUSUA, _
                                                            stTRCAFEEN, _
                                                            stTRCACAAC, _
                                                            inMOGECLVE, _
                                                            stMOGEFFMU, _
                                                            stMOGEOBSE, _
                                                            stTRCAESTA) = True Then

                            MessageBox.Show("El registro de " & stFORMULARIO & " se guardo correctamente.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                            ' instancia la clase
                            Dim objRutas As New cla_RUTAS
                            Dim tblRutas As New DataTable

                            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(13)

                            If tblRutas.Rows.Count > 0 Then

                                Dim stRuta As String = Trim(stTRCAMUNI) & "-" & inTRCACLSE & "-" & Trim(stTRCACORR) & "-" & Trim(stTRCABARR) & "-" & Trim(stTRCAMANZ) & "-" & Trim(stTRCAPRED) & "-" & inTRCAVIGE

                                If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                                    System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                                End If

                            End If

                        End If

                    Else
                        MessageBox.Show("El registro de " & stFORMULARIO & " NO se guardo correctamente.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    End If

                Else
                    ' instancia la clase
                    Dim obMOVIGEOG1 As New cla_MOVIGEOG
                    Dim dtMOVIGEOG1 As New DataTable

                    dtMOVIGEOG1 = obMOVIGEOG1.fun_Buscar_CONSULTA_CEDULA_CATASTRAL_Y_USUARIO(stTRCAMUNI, stTRCACORR, stTRCABARR, stTRCAMANZ, stTRCAPRED, inTRCACLSE, inTRCAVIGE, stMOGEUSUA)

                    If dtMOVIGEOG1.Rows.Count = 0 Then

                        ' verifica que exista el roles de usuario
                        If boMOGEUSUA = True Then

                            If MessageBox.Show("¿ Desea registrar el tramite en " & stFORMULARIO & " nuevamente ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                                Dim stMOGEOBSE As String = Trim(dtMOVIGEOG.Rows(0).Item("MOGEOBSE").ToString)

                                If Trim(stRECLOBSE_NUEVA) = "" And Trim(stMOGEOBSE) = "" Then
                                    stRECLOBSE_NUEVA = "Asigno el tramite de " & stFORMULARIO & ""

                                ElseIf Trim(stMOGEOBSE) = "" Then
                                    stRECLOBSE_NUEVA = "Asigno el tramite de " & stFORMULARIO & ""

                                ElseIf Trim(stMOGEOBSE) <> "" Then
                                    stMOGEOBSE += vbCrLf & " Nota ingresada por: " & vp_usuario & " " & fun_fecha() & " : " & "Asigno el tramite de Movimiento Geografico" & ". "

                                End If

                                ' establece el numero de secuencia
                                inTRCASECU = fun_NumeroDeSecuenciaDeRegistro()

                                ' inserta el registro
                                If obMOVIGEOG.fun_Insertar_MOVIGEOG(inTRCASECU, _
                                                                    stTRCAMUNI, _
                                                                    stTRCACORR, _
                                                                    stTRCABARR, _
                                                                    stTRCAMANZ, _
                                                                    stTRCAPRED, _
                                                                    inTRCACLSE, _
                                                                    inTRCAVIGE, _
                                                                    stTRCANUDO, _
                                                                    stMOGEUSUA, _
                                                                    stTRCAFEEN, _
                                                                    stTRCACAAC, _
                                                                    inMOGECLVE, _
                                                                    stMOGEFFMU, _
                                                                    stMOGEOBSE, _
                                                                    stTRCAESTA) = True Then

                                    MessageBox.Show("El registro de " & stFORMULARIO & " se guardo correctamente.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                                    ' instancia la clase
                                    Dim objRutas As New cla_RUTAS
                                    Dim tblRutas As New DataTable

                                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(13)

                                    If tblRutas.Rows.Count > 0 Then

                                        Dim stRuta As String = Trim(stTRCAMUNI) & "-" & inTRCACLSE & "-" & Trim(stTRCACORR) & "-" & Trim(stTRCABARR) & "-" & Trim(stTRCAMANZ) & "-" & Trim(stTRCAPRED) & "-" & inTRCAVIGE

                                        If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                                            System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                                        End If

                                    End If

                                End If

                            Else
                                MessageBox.Show("El registro de " & stFORMULARIO & " NO se guardo correctamente.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                            End If

                        Else
                            MessageBox.Show("El registro de " & stFORMULARIO & " NO se guardo correctamente.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        End If

                    Else
                        MessageBox.Show("El registro de " & stFORMULARIO & " ya existe para el usuario seleccionado.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    End If

                End If

            Else
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_FinalizarMovimientoGeografico(ByVal inLEVASECU As Integer, ByVal stLEVANUDO As String, ByVal stLEVAFEFI As String)

        Try
            ' declara la clase
            Dim obMOVIGEOG1 As New cla_MOVIGEOG
            Dim dtMOVIGEOG1 As New DataTable

            dtMOVIGEOG1 = obMOVIGEOG1.fun_Buscar_CODIGO_X_MOVIGEOG(inLEVASECU)

            If dtMOVIGEOG1.Rows.Count > 0 Then

                Dim inMOGEIDRE As Integer = CInt(dtMOVIGEOG1.Rows(0).Item("MOGEIDRE"))

                ' declara la clase
                Dim obMOVIGEOG2 As New cla_MOVIGEOG
                Dim dtMOVIGEOG2 As New DataTable

                dtMOVIGEOG2 = obMOVIGEOG2.fun_Buscar_ID_MOVIGEOG(inMOGEIDRE)

                If dtMOVIGEOG2.Rows.Count > 0 Then

                    Dim stRECLOBSE_ACTUAL As String = Trim(dtMOVIGEOG2.Rows(0).Item("MOGEOBSE").ToString)

                    Dim stNotaFinalizacion As String = " Nota ingresada por: " & vp_usuario & " " & fun_fecha() & " : " & " FINALIZO EL TRAMITE MOVIMIENTO GEOGRAFICO. "

                    If Trim(stRECLOBSE_ACTUAL) <> "" Then
                        stRECLOBSE_ACTUAL += vbCrLf & stNotaFinalizacion

                    ElseIf Trim(stRECLOBSE_ACTUAL) = "" Then
                        stRECLOBSE_ACTUAL = stNotaFinalizacion

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
                    Dim stMOGEESTA As String = "fi"
                    Dim stMOGEFFMU As String = Trim(stLEVAFEFI)

                    stMOGEFFMU = stMOGEFFMU.ToString.Replace("-", "/")

                    ' parametros de la consulta
                    Dim ParametrosConsulta As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta += "update MOVIGEOG "
                    ParametrosConsulta += "set MOGEESTA = '" & stMOGEESTA & "', "
                    ParametrosConsulta += "MOGEFFMU = '" & stMOGEFFMU & "', "
                    ParametrosConsulta += "MOGEOBSE = '" & stRECLOBSE_ACTUAL & "'  "
                    ParametrosConsulta += "where MOGEIDRE = '" & inMOGEIDRE & "'  "

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

                    MessageBox.Show("Se finalizo correctamente el tramite N°: " & inLEVASECU & " del Movimiento Geografico.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' inserta el registro
            If boINSERTAR = True Then

                ' instancia la clase
                Dim objdatos1 As New cla_LEVANTAMIENTO

                'Dim boLLAVEPRIMARIA As Boolean = objdatos1.fun_Verifica_llave_Primaria_LEVANTAMIENTO(inLEVASECU, Me.txtLEVANUDO)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boLEVANUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtLEVANUDO)
                Dim boLEVAFEEN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtLEVAFEEN)

                ' verifica los datos del formulario 
                If boLEVANUDO = True And _
                   boLEVAFEEN = True Then

                    Dim objdatos22 As New cla_LEVANTAMIENTO

                    If (objdatos22.fun_Insertar_LEVANTAMIENTO(inLEVASECU, _
                                                         Me.txtLEVANUDO.Text, _
                                                         Me.txtLEVAFEEN.Text, _
                                                         Me.txtLEVAFERE.Text, _
                                                         Me.txtLEVAOBSE.Text)) = True Then

                        ' actualiza el material cargado al funcionario
                        Dim objTRABCAMP As New cla_TRABCAMP
                        objTRABCAMP.fun_Actualizar_MATECARG_X_TRABCAMP(inLEVASECU, Me.txtLEVANUDO.Text)

                        ' inserta el movimiento geografico
                        pro_InsertarMovimientoGeografico(inLEVASECU, Trim(Me.txtLEVANUDO.Text), Trim(Me.txtLEVAFEEN.Text))

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboLEVANUDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boLEVANUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtLEVANUDO)
                Dim boLEVAFEEN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtLEVAFEEN)

                ' verifica los datos del formulario 
                If boLEVANUDO = True And _
                   boLEVAFEEN = True Then

                    Dim objdatos22 As New cla_LEVANTAMIENTO

                    If (objdatos22.fun_Actualizar_LEVANTAMIENTO(inID_REGISTRO, _
                                                                inLEVASECU, _
                                                                Me.txtLEVANUDO.Text, _
                                                                Me.txtLEVAFEEN.Text, _
                                                                Me.txtLEVAFERE.Text, _
                                                                Me.txtLEVAOBSE.Text)) = True Then

                        ' verifica la fecha de finalización
                        If fun_Verificar_Dato_Fecha_Evento_Validated(Trim(Me.txtLEVAFERE.Text)) = True Then

                            ' finaliza el movimiento geografico
                            pro_FinalizarMovimientoGeografico(inLEVASECU, Trim(Me.txtLEVANUDO.Text), Trim(Me.txtLEVAFERE.Text))

                        End If

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboLEVANUDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.cboLEVANUDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLEVANUDO.KeyPress, txtLEVAFEEN.KeyPress, txtLEVAFERE.KeyPress, txtLEVAOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLEVAFEEN.GotFocus, txtLEVAFERE.GotFocus, txtLEVAOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLEVANUDO.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboLEVANUDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLEVANUDO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboLEVANUDO, Me.cboLEVANUDO.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboLEVANUDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLEVANUDO.SelectedIndexChanged
        Me.txtLEVANUDO.Text = CType(fun_Buscar_Lista_Valores_USUARIO_Codigo(Me.cboLEVANUDO), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboLEVANUDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLEVANUDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboLEVANUDO, Me.cboLEVANUDO.SelectedIndex)
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpLEVAFEEN_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLEVAFEEN.ValueChanged
        Me.txtLEVAFEEN.Text = Me.dtpLEVAFEEN.Value
    End Sub
    Private Sub dtpLEVAFERE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLEVAFERE.ValueChanged
        Me.txtLEVAFERE.Text = Me.dtpLEVAFERE.Value
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