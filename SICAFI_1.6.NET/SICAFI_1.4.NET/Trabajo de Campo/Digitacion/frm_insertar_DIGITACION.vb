Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_insertar_DIGITACION

    '===========================
    '*** INSERTAR DIGITACIÓN ***
    '===========================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer
    Dim inDIGISECU As Integer
    Dim stDIGINUDO As String

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
        inDIGISECU = inSECU

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub
    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer, ByVal stNUDO As String)
        inID_REGISTRO = inIDRE
        inDIGISECU = inSECU
        stDIGINUDO = stNUDO

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

            Dim objdatos5 As New cla_MOVIALFA
            Dim tbl10 As New DataTable

            tbl10 = objdatos5.fun_Buscar_SECUENCIA_X_MOVIALFA

            If tbl10.Rows.Count = 0 Then
                inFPDESECU = 1
            Else
                Dim i As Integer
                Dim NroMayor As Integer
                Dim Posicion As Integer

                Posicion = Val(tbl10.Rows(0).Item("MOALSECU"))

                For i = 0 To tbl10.Rows.Count - 1
                    NroMayor = Val(tbl10.Rows(i).Item("MOALSECU"))

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

        Me.cboDIGINUDO.DataSource = New DataTable

        Me.txtDIGINUDO.Text = ""
        Me.txtDIGIFEEN.Text = ""
        Me.txtDIGIFERE.Text = ""
        Me.txtDIGIOBSE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()

        Try

            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_DIGITACION
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_CODIGO_X_DIGITACION(inID_REGISTRO, inDIGISECU, Trim(stDIGINUDO))

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraDIGITACION.Text = "MODIFICAR DIGITACION"

                    Me.cboDIGINUDO.Enabled = False

                    Dim objdatos1 As New cla_USUARIO

                    Me.cboDIGINUDO.DataSource = objdatos1.fun_Buscar_CODIGO_USUARIO(stDIGINUDO)
                    Me.cboDIGINUDO.DisplayMember = "USUANOMB"
                    Me.cboDIGINUDO.ValueMember = "USUANUDO"

                    Me.txtDIGINUDO.Text = Trim(tbl.Rows(0).Item("DIGINUDO"))
                    Me.txtDIGIFEEN.Text = Trim(tbl.Rows(0).Item("DIGIFEEN"))
                    Me.txtDIGIFERE.Text = Trim(tbl.Rows(0).Item("DIGIFERE"))
                    Me.txtDIGIOBSE.Text = Trim(tbl.Rows(0).Item("DIGIOBSE"))

                    Me.txtDIGIFEEN.Enabled = False
                    Me.dtpDIGIFEEN.Enabled = False

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraDIGITACION.Text = "INSERTAR DIGITACION"

                Me.dtpDIGIFEEN.MaxDate = DateTime.Today
                Me.dtpDIGIFERE.MaxDate = DateTime.Today

                Me.dtpDIGIFEEN.Value = fun_fecha()
                'Me.dtpDIGIFERE.Value = fun_fecha()

                Me.txtDIGIFEEN.Text = fun_fecha()
                Me.txtDIGIFERE.Text = ""

                Me.txtDIGIFERE.Enabled = False
                Me.dtpDIGIFERE.Enabled = False

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_InsertarMovimientoAlfanumericos(ByVal inLEVASECU As Integer, ByVal stLEVANUDO As String, ByVal stLEVAFEEN As String)

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
                Dim boMOALUSUA As Boolean = False
                Dim inMOALCLVE As Integer = 1
                Dim stMOALFFMU As String = ""
                Dim stFORMULARIO As String = "Movimiento Alfanumérico"

                Dim stRECLOBSE_NUEVA As String = CStr(Trim(Me.txtDIGIOBSE.Text))
                Dim stMOGEUSUA As String = fun_ConsultaNombreUsuario(Trim(stTRCANUDO))

                If Trim(stMOGEUSUA) = "" Then
                    boMOALUSUA = False
                    MessageBox.Show("El funcionario seleccionado no registra un perfil de usuario", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    boMOALUSUA = True
                End If

                ' declara la clase
                Dim obMOVIALFA As New cla_MOVIALFA
                Dim dtMOVIALFA As New DataTable

                dtMOVIALFA = obMOVIALFA.fun_Buscar_CODIGO_X_MOVIALFA(inTRCASECU)

                If dtMOVIALFA.Rows.Count = 0 Then

                    ' verifica que exista el roles de usuario
                    If boMOALUSUA = True Then

                        If Trim(stRECLOBSE_NUEVA) = "" And dtMOVIALFA.Rows.Count = 0 Then
                            stRECLOBSE_NUEVA = "Asigno el tramite de " & stFORMULARIO
                        End If

                        Dim stMOGEOBSE As String = " Nota ingresada por: " & vp_usuario & " " & fun_fecha() & " : " & stRECLOBSE_NUEVA & ". "

                        If obMOVIALFA.fun_Insertar_MOVIALFA(inTRCASECU, _
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
                                                            inMOALCLVE, _
                                                            stMOALFFMU, _
                                                            stMOGEOBSE, _
                                                            stTRCAESTA) = True Then

                            MessageBox.Show("El registro de " & stFORMULARIO & " se guardo correctamente.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                            ' instancia la clase
                            Dim objRutas As New cla_RUTAS
                            Dim tblRutas As New DataTable

                            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(16)

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
                    Dim obMOVIALFA1 As New cla_MOVIALFA
                    Dim dtMOVIALFA1 As New DataTable

                    dtMOVIALFA1 = obMOVIALFA1.fun_Buscar_CONSULTA_CEDULA_CATASTRAL_Y_USUARIO(stTRCAMUNI, stTRCACORR, stTRCABARR, stTRCAMANZ, stTRCAPRED, inTRCACLSE, inTRCAVIGE, stMOGEUSUA)

                    If dtMOVIALFA1.Rows.Count = 0 Then

                        ' verifica que exista el roles de usuario
                        If boMOALUSUA = True Then

                            If MessageBox.Show("¿ Desea registrar el tramite en " & stFORMULARIO & " nuevamente ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                                Dim stMOALOBSE As String = Trim(dtMOVIALFA1.Rows(0).Item("MOALOBSE").ToString)

                                If Trim(stRECLOBSE_NUEVA) = "" And Trim(stMOALOBSE) = "" Then
                                    stRECLOBSE_NUEVA = "Asigno el tramite de " & stFORMULARIO & ""

                                ElseIf Trim(stMOALOBSE) = "" Then
                                    stRECLOBSE_NUEVA = "Asigno el tramite de " & stFORMULARIO & ""

                                ElseIf Trim(stMOALOBSE) <> "" Then
                                    stMOALOBSE += vbCrLf & " Nota ingresada por: " & vp_usuario & " " & fun_fecha() & " : " & "Asigno el tramite de " & stFORMULARIO & ". "

                                End If

                                ' establece el numero de secuencia
                                inTRCASECU = fun_NumeroDeSecuenciaDeRegistro()

                                ' inserta el registro
                                If obMOVIALFA.fun_Insertar_MOVIALFA(inTRCASECU, _
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
                                                                    inMOALCLVE, _
                                                                    stMOALFFMU, _
                                                                    stMOALOBSE, _
                                                                    stTRCAESTA) = True Then

                                    MessageBox.Show("El registro de " & stFORMULARIO & " se guardo correctamente.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                                    ' instancia la clase
                                    Dim objRutas As New cla_RUTAS
                                    Dim tblRutas As New DataTable

                                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(16)

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
    Private Sub pro_FinalizarMovimientoAlfanumerico(ByVal inLEVASECU As Integer, ByVal stLEVANUDO As String, ByVal stLEVAFEFI As String)

        Try
            ' declara la clase
            Dim obMOVIALFA1 As New cla_MOVIALFA
            Dim dtMOVIALFA1 As New DataTable

            dtMOVIALFA1 = obMOVIALFA1.fun_Buscar_CODIGO_X_MOVIALFA(inLEVASECU)

            If dtMOVIALFA1.Rows.Count > 0 Then

                Dim inMOALIDRE As Integer = CInt(dtMOVIALFA1.Rows(0).Item("MOALIDRE"))

                ' declara la clase
                Dim obMOVIALFA2 As New cla_MOVIALFA
                Dim dtMOVIALFA2 As New DataTable

                dtMOVIALFA2 = obMOVIALFA2.fun_Buscar_ID_MOVIALFA(inMOALIDRE)

                If dtMOVIALFA2.Rows.Count > 0 Then

                    Dim stRECLOBSE_ACTUAL As String = Trim(dtMOVIALFA2.Rows(0).Item("MOALOBSE").ToString)

                    Dim stNotaFinalizacion As String = " Nota ingresada por: " & vp_usuario & " " & fun_fecha() & " : " & " FINALIZO EL TRAMITE MOVIMIENTO ALFANUMÉRICO. "

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
                    Dim stMOALESTA As String = "fi"
                    Dim stMOALFFMU As String = Trim(stLEVAFEFI)

                    stMOALFFMU = stMOALFFMU.ToString.Replace("-", "/")

                    ' parametros de la consulta
                    Dim ParametrosConsulta As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta += "update MOVIALFA "
                    ParametrosConsulta += "set MOALESTA = '" & stMOALESTA & "', "
                    ParametrosConsulta += "MOALFFMU = '" & stMOALFFMU & "', "
                    ParametrosConsulta += "MOALOBSE = '" & stRECLOBSE_ACTUAL & "'  "
                    ParametrosConsulta += "where MOALIDRE = '" & inMOALIDRE & "'  "

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

                    MessageBox.Show("Se finalizo correctamente el tramite N°: " & inLEVASECU & " del Movimiento Alfanumérico.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

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
                Dim objdatos1 As New cla_DIGITACION

                'Dim boLLAVEPRIMARIA As Boolean = objdatos1.fun_Verifica_llave_Primaria_DIGITACION(inDIGISECU, Me.txtDIGINUDO)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boDIGINUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtDIGINUDO)
                Dim boDIGIFEEN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtDIGIFEEN)

                ' verifica los datos del formulario 
                If boDIGINUDO = True And _
                   boDIGIFEEN = True Then

                    Dim objdatos22 As New cla_DIGITACION

                    If (objdatos22.fun_Insertar_DIGITACION(inDIGISECU, _
                                                         Me.txtDIGINUDO.Text, _
                                                         Me.txtDIGIFEEN.Text, _
                                                         Me.txtDIGIFERE.Text, _
                                                         Me.txtDIGIOBSE.Text)) = True Then

                        ' actualiza el material cargado al funcionario
                        Dim objTRABCAMP As New cla_TRABCAMP
                        objTRABCAMP.fun_Actualizar_MATECARG_X_TRABCAMP(inDIGISECU, Me.txtDIGINUDO.Text)

                        ' inserta el movimiento geografico
                        pro_InsertarMovimientoAlfanumericos(inDIGISECU, Trim(Me.txtDIGINUDO.Text), Trim(Me.txtDIGIFEEN.Text))

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboDIGINUDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boDIGINUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtDIGINUDO)
                Dim boDIGIFEEN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtDIGIFEEN)

                ' verifica los datos del formulario 
                If boDIGINUDO = True And _
                   boDIGIFEEN = True Then

                    Dim objdatos22 As New cla_DIGITACION

                    If (objdatos22.fun_Actualizar_DIGITACION(inID_REGISTRO, _
                                                                inDIGISECU, _
                                                                Me.txtDIGINUDO.Text, _
                                                                Me.txtDIGIFEEN.Text, _
                                                                Me.txtDIGIFERE.Text, _
                                                                Me.txtDIGIOBSE.Text)) = True Then

                        ' verifica la fecha de finalización
                        If fun_Verificar_Dato_Fecha_Evento_Validated(Trim(Me.txtDIGIFERE.Text)) = True Then

                            ' finaliza el movimiento geografico
                            pro_FinalizarMovimientoAlfanumerico(inDIGISECU, Trim(Me.txtDIGINUDO.Text), Trim(Me.txtDIGIFERE.Text))

                        End If

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboDIGINUDO.Focus()
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
        Me.cboDIGINUDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDIGINUDO.KeyPress, txtDIGIFEEN.KeyPress, txtDIGIFERE.KeyPress, txtDIGIOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDIGIFEEN.GotFocus, txtDIGIFERE.GotFocus, txtDIGIOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDIGINUDO.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboDIGINUDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDIGINUDO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboDIGINUDO, Me.cboDIGINUDO.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboDIGINUDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDIGINUDO.SelectedIndexChanged
        Me.txtDIGINUDO.Text = CType(fun_Buscar_Lista_Valores_USUARIO_Codigo(Me.cboDIGINUDO), String)
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpLEVAFEEN_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDIGIFEEN.ValueChanged
        Me.txtDIGIFEEN.Text = Me.dtpDIGIFEEN.Value
    End Sub
    Private Sub dtpLEVAFERE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDIGIFERE.ValueChanged
        Me.txtDIGIFERE.Text = Me.dtpDIGIFERE.Value
    End Sub

#End Region

#Region "Click"

    Private Sub cboDIGINUDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDIGINUDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboDIGINUDO, Me.cboDIGINUDO.SelectedIndex)
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