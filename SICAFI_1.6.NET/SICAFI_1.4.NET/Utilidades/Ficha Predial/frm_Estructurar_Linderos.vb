Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_Estructurar_Linderos

    '============================
    '*** ESTRUCTURAR LINDEROS ***
    '============================

#Region "CONSTRUCTORES"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader

    Private dt As New DataTable

    Dim inFichaPredial As Integer = 0
 
    Dim tblCONSULTA As New DataTable

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Estructurar_Linderos
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Estructurar_Linderos
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

#Region "VARIABLES LOCALES"

    Dim stFIPRNUFI As String
    Dim stFIPRDIRE As String
    Dim stFIPRMUNI As String
    Dim stFIPRCORR As String
    Dim stFIPRBARR As String
    Dim stFIPRMANZ As String
    Dim stFIPRPRED As String
    Dim stFIPREDIF As String
    Dim stFIPRUNPR As String
    Dim stFIPRCLSE As String
    Dim stFIPRCASU As String
    Dim stFIPRCAPR As String
    Dim stFIPRMOAD As String
    Dim stFIPRTIFI As String

    Dim boCAMPOLLENO As Boolean = False

    Dim inProceso As Integer = 0

    Dim dt_CargaLinderos As New DataTable

#End Region

#Region "FUNCION"

    Private Function fun_ConsultaDatoAntesDeLa1Posicion(ByVal stColindante As String) As String

        Dim stDato As String = ""

        Dim inTamano As Integer = stColindante.Length
        Dim stLetra As String = ""
        Dim inContador As Integer = 0

        Dim sw2 As Integer = 0
        Dim j2 As Integer = 0

        While j2 < inTamano And sw2 = 0

            stLetra = stColindante.Substring(j2, 1)

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
    Private Function fun_ConsultaDatoAntesDeLa2Posicion(ByVal stColindante As String) As String

        Dim stDato As String = ""

        Dim inTamano As Integer = stColindante.Length
        Dim stLetra As String = ""
        Dim inContador As Integer = 0

        Dim sw2 As Integer = 0
        Dim j2 As Integer = 0

        While j2 < inTamano And sw2 = 0

            stLetra = stColindante.Substring(j2, 1)

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
    Private Function fun_ConsultaDatoAntesDeLa3Posicion(ByVal stColindante As String) As String

        Dim stDato As String = ""

        Dim inTamano As Integer = stColindante.Length
        Dim stLetra As String = ""
        Dim inContador As Integer = 0

        Dim sw2, j2 As Integer

        While j2 < inTamano And sw2 = 0

            stLetra = stColindante.Substring(j2, 1)

            If stLetra <> "" Then

                If stLetra = "-" Then
                    inContador += 1
                End If

                If inContador = 2 Then
                    stDato += stLetra
                End If

                j2 = j2 + 1

            ElseIf stLetra = "-" And inContador = 3 Then
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
    Private Function fun_ConsultaDatoAntesDeLa4Posicion(ByVal stColindante As String) As String

        Dim stDato As String = ""

        Dim inTamano As Integer = stColindante.Length
        Dim stLetra As String = ""
        Dim inContador As Integer = 0

        Dim sw2, j2 As Integer

        While j2 < inTamano And sw2 = 0

            stLetra = stColindante.Substring(j2, 1)

            If stLetra <> "" Then

                If stLetra = "-" Then
                    inContador += 1
                End If

                If inContador = 3 Then
                    stDato += stLetra
                End If

                j2 = j2 + 1

            ElseIf stLetra = "-" And inContador = 4 Then
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
    Private Function fun_ConsultaDatoDespuesDeLa4Posicion(ByVal stColindante As String) As String

        Dim stDato As String = ""

        Dim inTamano As Integer = stColindante.Length
        Dim stLetra As String = ""
        Dim inContador As Integer = 0

        Dim j2 As Integer = 0
        Dim sw As Byte = 0

        For j2 = 0 To inTamano - 1

            stLetra = stColindante.Substring(j2, 1)

            If stLetra = "-" Then
                inContador += 1
            End If

            If inContador = 4 And sw = 0 Then
                stDato = stColindante.ToString.Substring(j2, inTamano - j2)
                stDato = stDato.ToString.Substring(1, stDato.ToString.Length - 1)

                sw = 1
            End If

        Next

        Return stDato

    End Function
    Private Function fun_ConsultaDatoPredio(ByVal stColindante As String) As String

        Dim stDato As String = ""

        Dim inTamano As Integer = stColindante.Length
        Dim stLetra As String = ""
        Dim inContador As Integer = 0

        Dim sw2 As Integer = 0
        Dim j2 As Integer = 0

        While j2 < inTamano And sw2 = 0

            stLetra = stColindante.Substring(j2, 1)

            If stLetra <> "" Then

                If (stLetra <> "-" Or stLetra <> "/" Or stLetra <> "\") And fun_Verificar_Dato_Numerico_Evento_Validated(stLetra) = True Then
                    stDato += stLetra
                Else
                    sw2 = 1
                End If

                j2 = j2 + 1
            Else
                j2 = j2 + 1

            End If

        End While

        Return stDato

    End Function
    Private Function fun_ActualizaLindero(ByVal inSecuencia As Integer, ByVal stLindero As String) As Boolean

        Try
            Dim boResultado As Boolean = False

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

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "update FIPRLIND "
            ParametrosConsulta += "set FPLICOLI = '" & stLindero & "' "
            ParametrosConsulta += "where FPLIIDRE = '" & inSecuencia & "'"

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text

            oReader = oEjecutar.ExecuteReader

            Dim i As Integer = oReader.RecordsAffected

            If i > 0 Then
                boResultado = True
            Else
                boResultado = False
            End If

            ' cierra la conexion
            oConexion.Close()
            oReader = Nothing

            Return boResultado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_EliminaLindero(ByVal inSecuencia As Integer) As Boolean

        Try
            Dim boResultado As Boolean = False

            Dim obFIPRLIND As New cla_FIPRLIND

            If obFIPRLIND.fun_Eliminar_FIPRLIND(inSecuencia) = True Then
                boResultado = True
            Else
                boResultado = False
            End If

            Return boResultado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ConsultarFichaPredialPorCedulaCatastralActual(ByVal stFIPRMUNI As String, _
                                                                       ByVal stFIPRCORR As String, _
                                                                       ByVal stFIPRBARR As String, _
                                                                       ByVal stFIPRMANZ As String, _
                                                                       ByVal stFIPRPRED As String, _
                                                                       ByVal inFIPRCLSE As Integer, _
                                                                       ByVal inFIPRTIFI As Integer) As DataTable

        Try
            ' instancia un dt
            Dim dtFICHA As New DataTable

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            'concatena la consulta
            stConsulta += "Select * "
            stConsulta += "From FICHPRED "
            stConsulta += "Where "
            stConsulta += "FIPRMUNI like '" & stFIPRMUNI & "' and "
            stConsulta += "FIPRCORR like '" & stFIPRCORR & "' and "
            stConsulta += "FIPRBARR like '" & stFIPRBARR & "' and "
            stConsulta += "FIPRMANZ like '" & stFIPRMANZ & "' and "
            stConsulta += "FIPRPRED like '" & stFIPRPRED & "' and "
            stConsulta += "FIPRCLSE like '" & inFIPRCLSE & "' and "
            stConsulta += "FIPRTIFI like '" & inFIPRTIFI & "' and FIPRESTA = 'ac' "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dtFICHA = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Return dtFICHA

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ConsultarFichaPredialPorCedulaCatastralAnterior(ByVal stFIPRMUAN As String, _
                                                                         ByVal stFIPRCOAN As String, _
                                                                         ByVal stFIPRBAAN As String, _
                                                                         ByVal stFIPRMAAN As String, _
                                                                         ByVal stFIPRPRAN As String, _
                                                                         ByVal inFIPRCSAN As Integer, _
                                                                         ByVal inFIPRTIFI As Integer) As DataTable

        Try
            ' instancia un dt
            Dim dtFICHA As New DataTable

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            'concatena la consulta
            stConsulta += "Select * "
            stConsulta += "From FICHPRED "
            stConsulta += "Where "
            stConsulta += "FIPRMUAN like '" & stFIPRMUAN & "' and "
            stConsulta += "FIPRCOAN like '" & stFIPRCOAN & "' and "
            stConsulta += "FIPRBAAN like '" & stFIPRBAAN & "' and "
            stConsulta += "FIPRMAAN like '" & stFIPRMAAN & "' and "
            stConsulta += "FIPRPRAN like '" & stFIPRPRAN & "' and "
            stConsulta += "FIPRCSAN like '" & inFIPRCSAN & "' and "
            stConsulta += "FIPRTIFI like '" & inFIPRTIFI & "' and FIPRESTA = 'ac' "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dtFICHA = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Return dtFICHA

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_NumeroDeSecuenciaDeRegistroLindero(ByVal inFICHA As Integer) As Integer

        Try
            Dim inFPLISECU As Integer = 0

            Dim objdatos5 As New cla_FIPRLIND
            Dim tbl10 As New DataTable

            tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRLIND_X_FICHA_PREDIAL(Val(inFICHA))

            If tbl10.Rows.Count = 0 Then
                inFPLISECU = 1
            Else
                Dim i As Integer
                Dim NroMayor As Integer
                Dim Posicion As Integer

                Posicion = Val(tbl10.Rows(0).Item(10))

                For i = 0 To tbl10.Rows.Count - 1
                    NroMayor = Val(tbl10.Rows(i).Item(10))

                    If NroMayor > Posicion Then
                        inFPLISECU = NroMayor
                        Posicion = NroMayor
                    Else
                        inFPLISECU = Posicion
                    End If
                Next

                inFPLISECU = inFPLISECU + 1
            End If

            Return inFPLISECU

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ConsultaSeparadores(ByVal stColindante As String) As Boolean

        Dim boDato As Boolean = False

        Dim inTamano As Integer = stColindante.Length
        Dim stLetra As String = ""
        Dim inContador As Integer = 0

        Dim sw2 As Integer = 0
        Dim j2 As Integer = 0

        While j2 < inTamano And sw2 = 0

            stLetra = stColindante.Substring(j2, 1)

            If stLetra <> "" Then

                If stLetra = "-" Then
                    inContador += 1
                End If

                j2 = j2 + 1
            Else
                j2 = j2 + 1
            End If

        End While

        If inContador > 1 Then
            boDato = True
        Else
            boDato = False
        End If

        Return boDato

    End Function
    Private Function fun_ContarSeparadores(ByVal stColindante As String) As Integer

        Dim inTamano As Integer = stColindante.Length
        Dim stLetra As String = ""
        Dim inContador As Integer = 0

        Dim sw2 As Integer = 0
        Dim j2 As Integer = 0

        While j2 < inTamano And sw2 = 0

            stLetra = stColindante.Substring(j2, 1)

            If stLetra <> "" Then

                If stLetra = "-" Or stLetra = "/" Then
                    inContador += 1
                End If

                j2 = j2 + 1
            Else
                j2 = j2 + 1
            End If

        End While

        Return inContador

    End Function
    Private Function fun_SeleccionarUltimoDigito(ByVal stColindante As String) As String

        ' almacena la cantidada de separadores
        Dim inNroSeparadores As Integer = fun_ContarSeparadores(stColindante)
        Dim stDigitoPredio As String = ""
        Dim swSeparador As Byte = 0

        Dim inTamano As Integer = stColindante.Length
        Dim stLetra As String = ""
        Dim inContador As Integer = 0

        Dim sw2 As Integer = 0
        Dim j2 As Integer = 0

        While j2 < inTamano And sw2 = 0

            stLetra = stColindante.Substring(j2, 1)

            If stLetra <> "" Then

                If stLetra = "-" Or stLetra = "/" Then
                    inContador += 1
                End If

                If inContador = inNroSeparadores Then

                    If swSeparador = 1 And fun_Verificar_Dato_Numerico_Evento_Validated(stLetra) = True Then
                        stDigitoPredio += stLetra
                    Else
                        swSeparador = 1
                    End If

                End If

                j2 = j2 + 1
            Else
                j2 = j2 + 1
            End If

        End While

        Return stDigitoPredio

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtFIPRNUFI.Text = ""
        Me.txtFIPRTIFI.Text = ""
        Me.txtFIPRDIRE.Text = ""
        Me.txtFIPRMUNI.Text = ""
        Me.txtFIPRCORR.Text = ""
        Me.txtFIPRBARR.Text = ""
        Me.txtFIPRMANZ.Text = ""
        Me.txtFIPRPRED.Text = ""
        Me.txtFIPREDIF.Text = ""
        Me.txtFIPRUNPR.Text = ""
        Me.txtFIPRCLSE.Text = ""
        Me.txtFIPRCASU.Text = ""
        Me.txtFIPRCAPR.Text = ""
        Me.txtFIPRMOAD.Text = ""
        Me.txtFIPRTIFI.Text = ""
        Me.lblFIPRCLSE.Text = ""
        Me.lblFIPRCASU.Text = ""
        Me.lblFIPRCAPR.Text = ""
        Me.lblFIPRMOAD.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.cmdEJECUTAR.Enabled = True

        Me.dgvCONSULTA.DataSource = New DataTable



    End Sub
    Private Sub pro_VerificarCampos()

        ' VERIFICA LOS CAMPOS DEL FORMULARIO

        If Trim(Me.txtFIPRNUFI.Text) = "" Then
            stFIPRNUFI = "%"
        Else
            stFIPRNUFI = Trim(Me.txtFIPRNUFI.Text)
        End If

        If Trim(Me.txtFIPRTIFI.Text) = "" Then
            stFIPRTIFI = "%"
        Else
            stFIPRTIFI = Trim(Me.txtFIPRTIFI.Text)
        End If

        If Trim(Me.txtFIPRDIRE.Text) = "" Then
            stFIPRDIRE = "%"
        Else
            stFIPRDIRE = Trim(Me.txtFIPRDIRE.Text)
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

        If Trim(Me.txtFIPRCLSE.Text) = "" Then
            stFIPRCLSE = "%"
        Else
            stFIPRCLSE = Trim(Me.txtFIPRCLSE.Text)
        End If

        If Trim(Me.txtFIPRCASU.Text) = "" Then
            stFIPRCASU = "%"
        Else
            stFIPRCASU = Trim(Me.txtFIPRCASU.Text)
        End If

        If Trim(Me.txtFIPRCAPR.Text) = "" Then
            stFIPRCAPR = "%"
        Else
            stFIPRCAPR = Trim(Me.txtFIPRCAPR.Text)
        End If

        If Trim(Me.txtFIPRMOAD.Text) = "" Then
            stFIPRMOAD = "%"
        Else
            stFIPRMOAD = Trim(Me.txtFIPRMOAD.Text)
        End If

        If Trim(Me.txtFIPRTIFI.Text) = "" Then
            stFIPRTIFI = "%"
        Else
            stFIPRTIFI = Trim(Me.txtFIPRTIFI.Text)
        End If

    End Sub
    Private Sub pro_ConsultarFichaPredial()

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

            ' verifica los datos de los campos
            pro_VerificarCampos()

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "* "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprNufi like '" & stFIPRNUFI & "' and "
            ParametrosConsulta += "FiprDire like '" & stFIPRDIRE & "' and "
            ParametrosConsulta += "FiprMuni like '" & stFIPRMUNI & "' and "
            ParametrosConsulta += "FiprCorr like '" & stFIPRCORR & "' and "
            ParametrosConsulta += "FiprBarr like '" & stFIPRBARR & "' and "
            ParametrosConsulta += "FiprManz like '" & stFIPRMANZ & "' and "
            ParametrosConsulta += "FiprPred like '" & stFIPRPRED & "' and "
            ParametrosConsulta += "FiprEdif like '" & stFIPREDIF & "' and "
            ParametrosConsulta += "FiprUnpr like '" & stFIPRUNPR & "' and "
            ParametrosConsulta += "FiprClse like '" & stFIPRCLSE & "' and "
            ParametrosConsulta += "FiprCasu like '" & stFIPRCASU & "' and "
            ParametrosConsulta += "FiprCapr like '" & stFIPRCAPR & "' and "
            ParametrosConsulta += "FiprMoad like '" & stFIPRMOAD & "' and "
            ParametrosConsulta += "FiprTifi like '" & stFIPRTIFI & "' "
            ParametrosConsulta += "order by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr"

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

            ' Numero de registros recuperados
            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

            Me.txtFIPRMUNI.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_CodificarEstructuraAnteriorAlaNuevaNivelPredio()

        Try
            ' Valores predeterminados ProgressBar
            inProceso = 0
            pbPROCESO.Value = 0
            pbPROCESO.Maximum = dt.Rows.Count * 2
            Timer1.Enabled = True

            If MessageBox.Show("Se revisaran N° " & dt.Rows.Count & " registros. ¿ Desea Continuar ?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim k As Integer = 2

                For k = 0 To 2 - 1

                    ' declara la variable
                    Dim i As Integer = 0

                    ' recorre la tabla
                    For i = 0 To dt.Rows.Count - 1

                        inFichaPredial = CInt(dt.Rows(i).Item("FIPRNUFI"))

                        Dim stFIPRMUNI As String = fun_Formato_Mascara_3_String(CStr(Trim(dt.Rows(i).Item("FIPRMUNI").ToString)))
                        Dim stFIPRCORR As String = fun_Formato_Mascara_3_String(CStr(Trim(dt.Rows(i).Item("FIPRCORR").ToString)))
                        Dim stFIPRBARR As String = fun_Formato_Mascara_3_String(CStr(Trim(dt.Rows(i).Item("FIPRBARR").ToString)))
                        Dim stFIPRMANZ As String = fun_Formato_Mascara_4_String(CStr(Trim(dt.Rows(i).Item("FIPRMANZ").ToString)))
                        Dim stFIPRPRED As String = fun_Formato_Mascara_5_String(CStr(Trim(dt.Rows(i).Item("FIPRPRED").ToString)))
                        Dim inFIPRCLSE As Integer = CInt(dt.Rows(i).Item("FIPRCLSE"))

                        ' instancia la clase
                        Dim obj_FIPRLIND As New cla_FIPRLIND
                        Dim tbl_FIPRLIND As New DataTable

                        tbl_FIPRLIND = obj_FIPRLIND.fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(CInt(dt.Rows(i).Item("FIPRNUFI")))

                        If tbl_FIPRLIND.Rows.Count > 0 Then

                            ' declara la variable
                            Dim j As Integer

                            ' recorre la tabla
                            For j = 0 To tbl_FIPRLIND.Rows.Count - 1

                                ' declara la variable
                                Dim inIdRegistro As Integer = CInt(tbl_FIPRLIND.Rows(j).Item("FPLIIDRE"))
                                Dim stColindante As String = CStr(Trim(tbl_FIPRLIND.Rows(j).Item("FPLICOLI").ToString))
                                Dim stPuntoCardinal As String = CStr(Trim(tbl_FIPRLIND.Rows(j).Item("FPLIPUCA").ToString))
                                Dim bySW As Byte = 0

                                ' Verifica un unico registro con estructura
                                If fun_Verificar_Dato_Numerico_Evento_Validated(stColindante) = True AndAlso stColindante.ToString.Length = 19 Then
                                    bySW = 1
                                Else
                                    ' verifica si es unidad predial
                                    If fun_Verificar_Dato_Numerico_Evento_Validated(stColindante) = True AndAlso stColindante.ToString.Length >= 5 Then
                                        bySW = 1
                                    Else
                                        ' verifica si es nomenclatura
                                        If stColindante.ToString.Length <= 2 And fun_Verificar_Dato_Numerico_Evento_Validated(stColindante.ToString.Substring(0, 1)) = False Then
                                            bySW = 1
                                        Else
                                            ' se estructura el colindante
                                            If bySW = 0 Then

                                                If stColindante.ToString.Length >= 3 Then

                                                    ' verifica si comienza por el municipio
                                                    If fun_Verificar_Dato_Numerico_Evento_Validated(stColindante.ToString.Substring(0, 3)) = True AndAlso _
                                                       stColindante.ToString.Substring(0, 3) = stFIPRMUNI Then

                                                        ' verifica si posee la estructura de 14 mas los colindantes
                                                        If fun_Verificar_Dato_Numerico_Evento_Validated(stColindante) = False Then

                                                            ' verifica los separadores
                                                            Dim inCantidadSeparadores As Integer = 0
                                                            Dim stBaseSeparadores As String = ""

                                                            ' quita los números
                                                            stBaseSeparadores = stColindante

                                                            stBaseSeparadores = stBaseSeparadores.ToString.Replace("0", "")
                                                            stBaseSeparadores = stBaseSeparadores.ToString.Replace("1", "")
                                                            stBaseSeparadores = stBaseSeparadores.ToString.Replace("2", "")
                                                            stBaseSeparadores = stBaseSeparadores.ToString.Replace("3", "")
                                                            stBaseSeparadores = stBaseSeparadores.ToString.Replace("4", "")
                                                            stBaseSeparadores = stBaseSeparadores.ToString.Replace("5", "")
                                                            stBaseSeparadores = stBaseSeparadores.ToString.Replace("6", "")
                                                            stBaseSeparadores = stBaseSeparadores.ToString.Replace("7", "")
                                                            stBaseSeparadores = stBaseSeparadores.ToString.Replace("8", "")
                                                            stBaseSeparadores = stBaseSeparadores.ToString.Replace("9", "")

                                                            inCantidadSeparadores = stBaseSeparadores.ToString.Length

                                                            If inCantidadSeparadores >= 4 Then

                                                                Dim stFPLIMUNI As String = fun_Formato_Mascara_3_String(fun_ConsultaDatoAntesDeLa1Posicion(stColindante.ToString.Replace("/", "-")))
                                                                Dim stFPLICORR As String = fun_Formato_Mascara_3_String(fun_ConsultaDatoAntesDeLa2Posicion(stColindante.ToString.Replace("/", "-")))
                                                                Dim stFPLIBARR As String = fun_Formato_Mascara_3_String(fun_ConsultaDatoAntesDeLa3Posicion(stColindante.ToString.Replace("/", "-")))
                                                                Dim stFPLIMANZ As String = fun_Formato_Mascara_4_String(fun_ConsultaDatoAntesDeLa4Posicion(stColindante.ToString.Replace("/", "-")))

                                                                ' actualiza el registro 
                                                                Dim stRestanteColindante As String = fun_ConsultaDatoDespuesDeLa4Posicion(stColindante)
                                                                Dim stBaseManzana As String = stFPLIMUNI & inFIPRCLSE & stFPLICORR & stFPLIBARR & stFPLIMANZ
                                                                Dim stBaseTotal As String = stBaseManzana & stRestanteColindante

                                                                Dim objDatos As New cla_FIPRLIND

                                                                ' verifica si el registro es numerico
                                                                If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True And _
                                                                   fun_Verificar_Dato_Numerico_Evento_Validated(stRestanteColindante) = True Then

                                                                    ' actualiza el registro
                                                                    stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)
                                                                    objDatos.fun_Actualizar_FIPRLIND(inIdRegistro, CInt(dt.Rows(i).Item("FIPRNUFI")), stPuntoCardinal, stBaseTotal)
                                                                Else
                                                                    If stBaseTotal.ToString.Length >= 14 Then
                                                                        Dim stBaseColindante As String = stBaseTotal.ToString.Substring(0, 14)

                                                                        ' declara la variable
                                                                        Dim ii As Integer = 0
                                                                        Dim sw As Byte = 0

                                                                        ' recorre la cadena
                                                                        For ii = 0 To stRestanteColindante.ToString.Length - 1

                                                                            If stRestanteColindante.ToString.Length > 0 Then

                                                                                If fun_Verificar_Dato_Numerico_Evento_Validated(stRestanteColindante.ToString.Substring(0, 1)) = True Then
                                                                                    If stRestanteColindante.ToString.Substring(0, 1) <> "-" Then
                                                                                        If stRestanteColindante.ToString.Substring(0, 1) <> "\" Then
                                                                                            If stRestanteColindante.ToString.Substring(0, 1) <> "/" Then

                                                                                                ' almacena el predio
                                                                                                Dim stPredio As String = fun_ConsultaDatoPredio(stRestanteColindante)

                                                                                                If ii = 0 And fun_Verificar_Dato_Numerico_Evento_Validated(stPredio) = True And sw = 0 Then

                                                                                                    ' actualiza el registro
                                                                                                    stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stPredio)
                                                                                                    objDatos.fun_Actualizar_FIPRLIND(inIdRegistro, CInt(dt.Rows(i).Item("FIPRNUFI")), stPuntoCardinal, stBaseTotal)

                                                                                                    stRestanteColindante = stRestanteColindante.ToString.Replace(stPredio, "")

                                                                                                ElseIf sw = 1 And Trim(stRestanteColindante) <> "" Then

                                                                                                    ' inseerta el registro
                                                                                                    stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stPredio)
                                                                                                    objDatos.fun_Insertar_FIPRLIND(CInt(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                                                   stPuntoCardinal, _
                                                                                                                                   stBaseTotal, _
                                                                                                                                   dt.Rows(i).Item("FIPRDEPA"), _
                                                                                                                                   dt.Rows(i).Item("FIPRMUNI"), _
                                                                                                                                   dt.Rows(i).Item("FIPRTIRE"), _
                                                                                                                                   dt.Rows(i).Item("FIPRCLSE"), _
                                                                                                                                   dt.Rows(i).Item("FIPRVIGE"), _
                                                                                                                                   dt.Rows(i).Item("FIPRRESO"), _
                                                                                                                                   fun_NumeroDeSecuenciaDeRegistroLindero(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                                                   dt.Rows(i).Item("FIPRNURE"), _
                                                                                                                                   dt.Rows(i).Item("FIPRESTA"))

                                                                                                    stRestanteColindante = stRestanteColindante.ToString.Replace(stPredio, "")

                                                                                                End If

                                                                                            Else
                                                                                                stRestanteColindante = stRestanteColindante.ToString.Substring(1, stRestanteColindante.ToString.Length - 1)
                                                                                                sw = 1
                                                                                            End If
                                                                                        Else
                                                                                            stRestanteColindante = stRestanteColindante.ToString.Substring(1, stRestanteColindante.ToString.Length - 1)
                                                                                            sw = 1
                                                                                        End If
                                                                                    Else
                                                                                        stRestanteColindante = stRestanteColindante.ToString.Substring(1, stRestanteColindante.ToString.Length - 1)
                                                                                        sw = 1
                                                                                    End If
                                                                                Else
                                                                                    stRestanteColindante = stRestanteColindante.ToString.Substring(1, stRestanteColindante.ToString.Length - 1)
                                                                                    sw = 1
                                                                                End If

                                                                            End If

                                                                        Next

                                                                    End If
                                                                End If

                                                            Else

                                                                ' verifica si posee la estructura de 19 mas los colindantes
                                                                If stColindante.ToString.Length >= 19 Then

                                                                    ' verifica los separadores
                                                                    Dim inCantidadSeparadores1 As Integer = 0
                                                                    Dim stBaseSeparadores1 As String = ""

                                                                    ' quita los números
                                                                    stBaseSeparadores1 = stColindante

                                                                    stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("0", "")
                                                                    stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("1", "")
                                                                    stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("2", "")
                                                                    stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("3", "")
                                                                    stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("4", "")
                                                                    stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("5", "")
                                                                    stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("6", "")
                                                                    stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("7", "")
                                                                    stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("8", "")
                                                                    stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("9", "")

                                                                    inCantidadSeparadores1 = stBaseSeparadores1.ToString.Length

                                                                    If inCantidadSeparadores1 >= 1 Then

                                                                        If fun_Verificar_Dato_Numerico_Evento_Validated(stColindante.ToString.Substring(0, 19)) = True Then

                                                                            ' actualiza el registro 
                                                                            Dim stRestanteColindante As String = stColindante.ToString.Substring(19, stColindante.ToString.Length - 19)
                                                                            Dim stBasePredio As String = stColindante.ToString.Substring(0, 19)
                                                                            Dim stBaseManzana As String = stColindante.ToString.Substring(0, 14)
                                                                            Dim stBaseTotal As String = stBasePredio & stRestanteColindante

                                                                            Dim stBaseColindante As String = stBaseTotal.ToString.Substring(0, 19)

                                                                            ' declara la variable
                                                                            Dim ii As Integer = 0
                                                                            Dim sw As Byte = 0

                                                                            ' recorre la cadena
                                                                            For ii = 0 To stRestanteColindante.ToString.Length - 1

                                                                                If stRestanteColindante.ToString.Length > 0 Then

                                                                                    Dim objDatos1 As New cla_FIPRLIND

                                                                                    If ii = 0 And sw = 0 Then

                                                                                        ' actualiza el registro
                                                                                        stBaseTotal = stBasePredio
                                                                                        objDatos1.fun_Actualizar_FIPRLIND(inIdRegistro, CInt(dt.Rows(i).Item("FIPRNUFI")), stPuntoCardinal, stBaseTotal)

                                                                                    End If

                                                                                    If fun_Verificar_Dato_Numerico_Evento_Validated(stRestanteColindante.ToString.Substring(0, 1)) = True Then
                                                                                        If stRestanteColindante.ToString.Substring(0, 1) <> "-" Then
                                                                                            If stRestanteColindante.ToString.Substring(0, 1) <> "\" Then
                                                                                                If stRestanteColindante.ToString.Substring(0, 1) <> "/" Then

                                                                                                    Dim objDatos As New cla_FIPRLIND

                                                                                                    ' almacena el predio
                                                                                                    Dim stPredio As String = fun_ConsultaDatoPredio(stRestanteColindante)

                                                                                                    If sw = 1 And Trim(stRestanteColindante) <> "" Then

                                                                                                        ' inseerta el registro
                                                                                                        stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stPredio)
                                                                                                        objDatos.fun_Insertar_FIPRLIND(CInt(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                                                       stPuntoCardinal, _
                                                                                                                                       stBaseTotal, _
                                                                                                                                       dt.Rows(i).Item("FIPRDEPA"), _
                                                                                                                                       dt.Rows(i).Item("FIPRMUNI"), _
                                                                                                                                       dt.Rows(i).Item("FIPRTIRE"), _
                                                                                                                                       dt.Rows(i).Item("FIPRCLSE"), _
                                                                                                                                       dt.Rows(i).Item("FIPRVIGE"), _
                                                                                                                                       dt.Rows(i).Item("FIPRRESO"), _
                                                                                                                                       fun_NumeroDeSecuenciaDeRegistroLindero(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                                                       dt.Rows(i).Item("FIPRNURE"), _
                                                                                                                                       dt.Rows(i).Item("FIPRESTA"))

                                                                                                        stRestanteColindante = stRestanteColindante.ToString.Replace(stPredio, "")

                                                                                                    End If

                                                                                                Else
                                                                                                    stRestanteColindante = stRestanteColindante.ToString.Substring(1, stRestanteColindante.ToString.Length - 1)
                                                                                                    sw = 1
                                                                                                End If
                                                                                            Else
                                                                                                stRestanteColindante = stRestanteColindante.ToString.Substring(1, stRestanteColindante.ToString.Length - 1)
                                                                                                sw = 1
                                                                                            End If
                                                                                        Else
                                                                                            stRestanteColindante = stRestanteColindante.ToString.Substring(1, stRestanteColindante.ToString.Length - 1)
                                                                                            sw = 1
                                                                                        End If
                                                                                    Else
                                                                                        stRestanteColindante = stRestanteColindante.ToString.Substring(1, stRestanteColindante.ToString.Length - 1)
                                                                                        sw = 1
                                                                                    End If

                                                                                End If

                                                                            Next

                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                        End If

                                                    Else
                                                        ' verifica si posee la estructura de 5 mas los colindantes unidades prediales
                                                        If stColindante.ToString.Length >= 5 And fun_Verificar_Dato_Numerico_Evento_Validated(stColindante.ToString.Substring(0, 1)) = True Then

                                                            ' verifica los separadores
                                                            Dim inCantidadSeparadores1 As Integer = 0
                                                            Dim stBaseSeparadores1 As String = ""

                                                            ' quita los números
                                                            stBaseSeparadores1 = stColindante

                                                            stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("0", "")
                                                            stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("1", "")
                                                            stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("2", "")
                                                            stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("3", "")
                                                            stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("4", "")
                                                            stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("5", "")
                                                            stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("6", "")
                                                            stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("7", "")
                                                            stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("8", "")
                                                            stBaseSeparadores1 = stBaseSeparadores1.ToString.Replace("9", "")

                                                            inCantidadSeparadores1 = stBaseSeparadores1.ToString.Length

                                                            If inCantidadSeparadores1 >= 1 Then

                                                                If fun_Verificar_Dato_Numerico_Evento_Validated(stColindante.ToString.Substring(0, 5)) = True Then

                                                                    ' actualiza el registro 
                                                                    Dim stRestanteColindante As String = stColindante.ToString.Substring(5, stColindante.ToString.Length - 5)
                                                                    'Dim stBasePredio As String = stColindante.ToString.Substring(0, 19)
                                                                    'Dim stBaseManzana As String = stColindante.ToString.Substring(0, 14)
                                                                    Dim stBaseUnidad As String = stColindante.ToString.Substring(0, 5)
                                                                    Dim stBaseTotal As String = stBaseUnidad & stRestanteColindante

                                                                    Dim stBaseColindante As String = stBaseTotal.ToString.Substring(0, 5)

                                                                    ' declara la variable
                                                                    Dim ii As Integer = 0
                                                                    Dim sw As Byte = 0

                                                                    ' recorre la cadena
                                                                    For ii = 0 To stRestanteColindante.ToString.Length - 1

                                                                        If stRestanteColindante.ToString.Length > 0 Then

                                                                            Dim objDatos1 As New cla_FIPRLIND

                                                                            If ii = 0 And sw = 0 Then

                                                                                ' actualiza el registro
                                                                                stBaseTotal = stBaseUnidad
                                                                                objDatos1.fun_Actualizar_FIPRLIND(inIdRegistro, CInt(dt.Rows(i).Item("FIPRNUFI")), stPuntoCardinal, stBaseTotal)

                                                                            End If

                                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stRestanteColindante.ToString.Substring(0, 1)) = True Then
                                                                                If stRestanteColindante.ToString.Substring(0, 1) <> "-" Then
                                                                                    If stRestanteColindante.ToString.Substring(0, 1) <> "\" Then
                                                                                        If stRestanteColindante.ToString.Substring(0, 1) <> "/" Then

                                                                                            Dim objDatos As New cla_FIPRLIND

                                                                                            ' almacena el predio
                                                                                            Dim stPredio As String = fun_ConsultaDatoPredio(stRestanteColindante)

                                                                                            If sw = 1 And Trim(stRestanteColindante) <> "" Then

                                                                                                ' inseerta el registro
                                                                                                stBaseTotal = fun_Formato_Mascara_5_String(stPredio)
                                                                                                objDatos.fun_Insertar_FIPRLIND(CInt(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                                               stPuntoCardinal, _
                                                                                                                               stBaseTotal, _
                                                                                                                               dt.Rows(i).Item("FIPRDEPA"), _
                                                                                                                               dt.Rows(i).Item("FIPRMUNI"), _
                                                                                                                               dt.Rows(i).Item("FIPRTIRE"), _
                                                                                                                               dt.Rows(i).Item("FIPRCLSE"), _
                                                                                                                               dt.Rows(i).Item("FIPRVIGE"), _
                                                                                                                               dt.Rows(i).Item("FIPRRESO"), _
                                                                                                                               fun_NumeroDeSecuenciaDeRegistroLindero(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                                               dt.Rows(i).Item("FIPRNURE"), _
                                                                                                                               dt.Rows(i).Item("FIPRESTA"))

                                                                                                stRestanteColindante = stRestanteColindante.ToString.Replace(stPredio, "")

                                                                                            End If

                                                                                        Else
                                                                                            stRestanteColindante = stRestanteColindante.ToString.Substring(1, stRestanteColindante.ToString.Length - 1)
                                                                                            sw = 1
                                                                                        End If
                                                                                    Else
                                                                                        stRestanteColindante = stRestanteColindante.ToString.Substring(1, stRestanteColindante.ToString.Length - 1)
                                                                                        sw = 1
                                                                                    End If
                                                                                Else
                                                                                    stRestanteColindante = stRestanteColindante.ToString.Substring(1, stRestanteColindante.ToString.Length - 1)
                                                                                    sw = 1
                                                                                End If
                                                                            Else
                                                                                stRestanteColindante = stRestanteColindante.ToString.Substring(1, stRestanteColindante.ToString.Length - 1)
                                                                                sw = 1
                                                                            End If

                                                                        End If

                                                                    Next
                                                                End If
                                                            End If
                                                        End If

                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If


                                End If

                            Next

                        End If

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbPROCESO.Value = inProceso

                    Next

                    ' inicia la barra de progreso
                    pbPROCESO.Value = 0
                    Me.cmdEJECUTAR.Enabled = True

                Next

                mod_MENSAJE.Proceso_Termino_Correctamente()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CodificarEstructuraAnteriorAlaNuevaNivelUnidadPredial()

        Try

            If MessageBox.Show("Se revisaran N° " & dt.Rows.Count & " registros. ¿ Desea Continuar ?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                inProceso = 0
                pbPROCESO.Value = 0
                pbPROCESO.Maximum = dt.Rows.Count
                Timer1.Enabled = True

                Dim i As Integer = 0

                For i = 0 To dt.Rows.Count - 1

                    inFichaPredial = CInt(dt.Rows(i).Item("FIPRNUFI"))

                    Dim stFIPRMUNI As String = fun_Formato_Mascara_3_String(CStr(Trim(dt.Rows(i).Item("FIPRMUNI").ToString)))
                    Dim stFIPRCORR As String = fun_Formato_Mascara_3_String(CStr(Trim(dt.Rows(i).Item("FIPRCORR").ToString)))
                    Dim stFIPRBARR As String = fun_Formato_Mascara_3_String(CStr(Trim(dt.Rows(i).Item("FIPRBARR").ToString)))
                    Dim stFIPRMANZ As String = fun_Formato_Mascara_4_String(CStr(Trim(dt.Rows(i).Item("FIPRMANZ").ToString)))
                    Dim stFIPRPRED As String = fun_Formato_Mascara_5_String(CStr(Trim(dt.Rows(i).Item("FIPRPRED").ToString)))
                    Dim stFIPREDIF As String = fun_Formato_Mascara_4_String(CStr(Trim(dt.Rows(i).Item("FIPREDIF").ToString)))
                    Dim stFIPRUNPR As String = fun_Formato_Mascara_5_String(CStr(Trim(dt.Rows(i).Item("FIPRUNPR").ToString)))

                    Dim inFIPRCLSE As Integer = CInt(dt.Rows(i).Item("FIPRCLSE"))

                    ' instancia la clase
                    Dim obj_FIPRLIND As New cla_FIPRLIND
                    Dim tbl_FIPRLIND As New DataTable

                    tbl_FIPRLIND = obj_FIPRLIND.fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(CInt(dt.Rows(i).Item("FIPRNUFI")))

                    If tbl_FIPRLIND.Rows.Count > 0 Then

                        ' declara la variable
                        Dim j As Integer

                        ' recorre la tabla
                        For j = 0 To tbl_FIPRLIND.Rows.Count - 1

                            ' declara la variable
                            Dim inIdRegistro As Integer = CInt(tbl_FIPRLIND.Rows(j).Item("FPLIIDRE"))
                            Dim stColindante As String = CStr(Trim(tbl_FIPRLIND.Rows(j).Item("FPLICOLI").ToString))
                            Dim stPuntoCardinal As String = CStr(Trim(tbl_FIPRLIND.Rows(j).Item("FPLIPUCA").ToString))

                            Dim bySW As Byte = 0

                            ' Verifica un unico registro con estructura
                            If fun_Verificar_Dato_Numerico_Evento_Validated(stColindante) = True AndAlso stColindante.ToString.Length = 19 Then
                                bySW = 1
                            Else
                                ' verifica si es nomenclatura
                                If stColindante.ToString.Length <= 2 And fun_Verificar_Dato_Numerico_Evento_Validated(stColindante.ToString.Substring(0, 1)) = False Then
                                    bySW = 1
                                Else
                                    If stColindante.ToString.Length >= 3 Then

                                        ' verifica si comienza por el municipio
                                        If fun_Verificar_Dato_Numerico_Evento_Validated(stColindante.ToString.Substring(0, 3)) = True AndAlso _
                                           stColindante.ToString.Substring(0, 3) = stFIPRMUNI Then
                                            bySW = 1
                                        Else
                                            ' verifica si es unidad predial
                                            If stColindante.ToString.Length >= 5 Then

                                                If bySW = 0 Then

                                                    ' verifica los separadores
                                                    Dim inCantidadSeparadores As Integer = 0
                                                    Dim stBaseSeparadores As String = ""

                                                    ' quita los números
                                                    stBaseSeparadores = stColindante

                                                    stBaseSeparadores = stBaseSeparadores.ToString.Replace("0", "")
                                                    stBaseSeparadores = stBaseSeparadores.ToString.Replace("1", "")
                                                    stBaseSeparadores = stBaseSeparadores.ToString.Replace("2", "")
                                                    stBaseSeparadores = stBaseSeparadores.ToString.Replace("3", "")
                                                    stBaseSeparadores = stBaseSeparadores.ToString.Replace("4", "")
                                                    stBaseSeparadores = stBaseSeparadores.ToString.Replace("5", "")
                                                    stBaseSeparadores = stBaseSeparadores.ToString.Replace("6", "")
                                                    stBaseSeparadores = stBaseSeparadores.ToString.Replace("7", "")
                                                    stBaseSeparadores = stBaseSeparadores.ToString.Replace("8", "")
                                                    stBaseSeparadores = stBaseSeparadores.ToString.Replace("9", "")

                                                    inCantidadSeparadores = stBaseSeparadores.ToString.Length

                                                    Dim stRestanteColindante As String = Trim(stColindante)
                                                    Dim stBaseManzana As String = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                    Dim stBaseTotal As String = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                    Dim objDatos As New cla_FIPRLIND

                                                    ' sin separadores
                                                    If inCantidadSeparadores = 0 Then

                                                        ' actualiza el registro 
                                                        stRestanteColindante = Trim(stColindante)
                                                        stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                        stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                        ' verifica si el registro es numerico
                                                        If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                            ' actualiza el registro
                                                            objDatos.fun_Actualizar_FIPRLIND(inIdRegistro, CInt(dt.Rows(i).Item("FIPRNUFI")), stPuntoCardinal, stBaseTotal)

                                                        End If

                                                        ' con un separador
                                                    ElseIf inCantidadSeparadores = 1 Then

                                                        If stColindante.ToString.Length = 11 Then

                                                            ' actualiza el registro 
                                                            stRestanteColindante = Trim(stColindante).Substring(0, 5)
                                                            stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                            stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                            ' verifica si el registro es numerico
                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                ' actualiza el registro
                                                                objDatos.fun_Actualizar_FIPRLIND(inIdRegistro, CInt(dt.Rows(i).Item("FIPRNUFI")), stPuntoCardinal, stBaseTotal)

                                                            End If

                                                            stRestanteColindante = stColindante.ToString.Substring(6, 5)

                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stRestanteColindante) = True Then

                                                                stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                                stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                                ' verifica si el registro es numerico
                                                                If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                    ' inserta el registro
                                                                    objDatos.fun_Insertar_FIPRLIND(CInt(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   stPuntoCardinal, _
                                                                                                   stBaseTotal, _
                                                                                                   dt.Rows(i).Item("FIPRDEPA"), _
                                                                                                   dt.Rows(i).Item("FIPRMUNI"), _
                                                                                                   dt.Rows(i).Item("FIPRTIRE"), _
                                                                                                   dt.Rows(i).Item("FIPRCLSE"), _
                                                                                                   dt.Rows(i).Item("FIPRVIGE"), _
                                                                                                   dt.Rows(i).Item("FIPRRESO"), _
                                                                                                   fun_NumeroDeSecuenciaDeRegistroLindero(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   dt.Rows(i).Item("FIPRNURE"), _
                                                                                                   dt.Rows(i).Item("FIPRESTA"))
                                                                End If

                                                            End If

                                                        End If

                                                        ' con dos separadores
                                                    ElseIf inCantidadSeparadores = 2 Then

                                                        If stColindante.ToString.Length = 17 Then

                                                            ' actualiza el registro 
                                                            stRestanteColindante = Trim(stColindante).Substring(0, 5)
                                                            stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                            stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                            ' verifica si el registro es numerico
                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                ' actualiza el registro
                                                                objDatos.fun_Actualizar_FIPRLIND(inIdRegistro, CInt(dt.Rows(i).Item("FIPRNUFI")), stPuntoCardinal, stBaseTotal)

                                                            End If

                                                            stRestanteColindante = stColindante.ToString.Substring(6, 5)

                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stRestanteColindante) = True Then

                                                                stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                                stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                                ' verifica si el registro es numerico
                                                                If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                    ' inserta el registro
                                                                    objDatos.fun_Insertar_FIPRLIND(CInt(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   stPuntoCardinal, _
                                                                                                   stBaseTotal, _
                                                                                                   dt.Rows(i).Item("FIPRDEPA"), _
                                                                                                   dt.Rows(i).Item("FIPRMUNI"), _
                                                                                                   dt.Rows(i).Item("FIPRTIRE"), _
                                                                                                   dt.Rows(i).Item("FIPRCLSE"), _
                                                                                                   dt.Rows(i).Item("FIPRVIGE"), _
                                                                                                   dt.Rows(i).Item("FIPRRESO"), _
                                                                                                   fun_NumeroDeSecuenciaDeRegistroLindero(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   dt.Rows(i).Item("FIPRNURE"), _
                                                                                                   dt.Rows(i).Item("FIPRESTA"))
                                                                End If

                                                            End If

                                                            stRestanteColindante = stColindante.ToString.Substring(12, 5)

                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stRestanteColindante) = True Then

                                                                stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                                stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                                ' verifica si el registro es numerico
                                                                If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                    ' inserta el registro
                                                                    objDatos.fun_Insertar_FIPRLIND(CInt(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   stPuntoCardinal, _
                                                                                                   stBaseTotal, _
                                                                                                   dt.Rows(i).Item("FIPRDEPA"), _
                                                                                                   dt.Rows(i).Item("FIPRMUNI"), _
                                                                                                   dt.Rows(i).Item("FIPRTIRE"), _
                                                                                                   dt.Rows(i).Item("FIPRCLSE"), _
                                                                                                   dt.Rows(i).Item("FIPRVIGE"), _
                                                                                                   dt.Rows(i).Item("FIPRRESO"), _
                                                                                                   fun_NumeroDeSecuenciaDeRegistroLindero(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   dt.Rows(i).Item("FIPRNURE"), _
                                                                                                   dt.Rows(i).Item("FIPRESTA"))

                                                                End If

                                                            End If

                                                        End If

                                                        ' con tres separadores
                                                    ElseIf inCantidadSeparadores = 3 Then

                                                        If stColindante.ToString.Length = 23 Then

                                                            ' actualiza el registro 
                                                            stRestanteColindante = Trim(stColindante).Substring(0, 5)
                                                            stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                            stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                            ' verifica si el registro es numerico
                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                ' actualiza el registro
                                                                objDatos.fun_Actualizar_FIPRLIND(inIdRegistro, CInt(dt.Rows(i).Item("FIPRNUFI")), stPuntoCardinal, stBaseTotal)

                                                            End If

                                                            stRestanteColindante = stColindante.ToString.Substring(6, 5)

                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stRestanteColindante) = True Then

                                                                stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                                stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                                ' verifica si el registro es numerico
                                                                If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                    ' inserta el registro
                                                                    objDatos.fun_Insertar_FIPRLIND(CInt(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   stPuntoCardinal, _
                                                                                                   stBaseTotal, _
                                                                                                   dt.Rows(i).Item("FIPRDEPA"), _
                                                                                                   dt.Rows(i).Item("FIPRMUNI"), _
                                                                                                   dt.Rows(i).Item("FIPRTIRE"), _
                                                                                                   dt.Rows(i).Item("FIPRCLSE"), _
                                                                                                   dt.Rows(i).Item("FIPRVIGE"), _
                                                                                                   dt.Rows(i).Item("FIPRRESO"), _
                                                                                                   fun_NumeroDeSecuenciaDeRegistroLindero(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   dt.Rows(i).Item("FIPRNURE"), _
                                                                                                   dt.Rows(i).Item("FIPRESTA"))
                                                                End If

                                                            End If

                                                            stRestanteColindante = stColindante.ToString.Substring(12, 5)

                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stRestanteColindante) = True Then

                                                                stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                                stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                                ' verifica si el registro es numerico
                                                                If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                    ' inserta el registro
                                                                    objDatos.fun_Insertar_FIPRLIND(CInt(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   stPuntoCardinal, _
                                                                                                   stBaseTotal, _
                                                                                                   dt.Rows(i).Item("FIPRDEPA"), _
                                                                                                   dt.Rows(i).Item("FIPRMUNI"), _
                                                                                                   dt.Rows(i).Item("FIPRTIRE"), _
                                                                                                   dt.Rows(i).Item("FIPRCLSE"), _
                                                                                                   dt.Rows(i).Item("FIPRVIGE"), _
                                                                                                   dt.Rows(i).Item("FIPRRESO"), _
                                                                                                   fun_NumeroDeSecuenciaDeRegistroLindero(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   dt.Rows(i).Item("FIPRNURE"), _
                                                                                                   dt.Rows(i).Item("FIPRESTA"))

                                                                End If

                                                            End If

                                                            stRestanteColindante = stColindante.ToString.Substring(18, 5)

                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stRestanteColindante) = True Then

                                                                stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                                stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                                ' verifica si el registro es numerico
                                                                If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                    ' inserta el registro
                                                                    objDatos.fun_Insertar_FIPRLIND(CInt(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   stPuntoCardinal, _
                                                                                                   stBaseTotal, _
                                                                                                   dt.Rows(i).Item("FIPRDEPA"), _
                                                                                                   dt.Rows(i).Item("FIPRMUNI"), _
                                                                                                   dt.Rows(i).Item("FIPRTIRE"), _
                                                                                                   dt.Rows(i).Item("FIPRCLSE"), _
                                                                                                   dt.Rows(i).Item("FIPRVIGE"), _
                                                                                                   dt.Rows(i).Item("FIPRRESO"), _
                                                                                                   fun_NumeroDeSecuenciaDeRegistroLindero(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   dt.Rows(i).Item("FIPRNURE"), _
                                                                                                   dt.Rows(i).Item("FIPRESTA"))

                                                                End If

                                                            End If

                                                        End If

                                                        ' con cuatro separadores
                                                    ElseIf inCantidadSeparadores = 4 Then

                                                        If stColindante.ToString.Length = 29 Then

                                                            ' actualiza el registro 
                                                            stRestanteColindante = Trim(stColindante).Substring(0, 5)
                                                            stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                            stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                            ' verifica si el registro es numerico
                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                ' actualiza el registro
                                                                objDatos.fun_Actualizar_FIPRLIND(inIdRegistro, CInt(dt.Rows(i).Item("FIPRNUFI")), stPuntoCardinal, stBaseTotal)

                                                            End If

                                                            stRestanteColindante = stColindante.ToString.Substring(6, 5)

                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stRestanteColindante) = True Then

                                                                stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                                stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                                ' verifica si el registro es numerico
                                                                If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                    ' inserta el registro
                                                                    objDatos.fun_Insertar_FIPRLIND(CInt(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   stPuntoCardinal, _
                                                                                                   stBaseTotal, _
                                                                                                   dt.Rows(i).Item("FIPRDEPA"), _
                                                                                                   dt.Rows(i).Item("FIPRMUNI"), _
                                                                                                   dt.Rows(i).Item("FIPRTIRE"), _
                                                                                                   dt.Rows(i).Item("FIPRCLSE"), _
                                                                                                   dt.Rows(i).Item("FIPRVIGE"), _
                                                                                                   dt.Rows(i).Item("FIPRRESO"), _
                                                                                                   fun_NumeroDeSecuenciaDeRegistroLindero(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   dt.Rows(i).Item("FIPRNURE"), _
                                                                                                   dt.Rows(i).Item("FIPRESTA"))
                                                                End If

                                                            End If

                                                            stRestanteColindante = stColindante.ToString.Substring(12, 5)

                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stRestanteColindante) = True Then

                                                                stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                                stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                                ' verifica si el registro es numerico
                                                                If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                    ' inserta el registro
                                                                    objDatos.fun_Insertar_FIPRLIND(CInt(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   stPuntoCardinal, _
                                                                                                   stBaseTotal, _
                                                                                                   dt.Rows(i).Item("FIPRDEPA"), _
                                                                                                   dt.Rows(i).Item("FIPRMUNI"), _
                                                                                                   dt.Rows(i).Item("FIPRTIRE"), _
                                                                                                   dt.Rows(i).Item("FIPRCLSE"), _
                                                                                                   dt.Rows(i).Item("FIPRVIGE"), _
                                                                                                   dt.Rows(i).Item("FIPRRESO"), _
                                                                                                   fun_NumeroDeSecuenciaDeRegistroLindero(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   dt.Rows(i).Item("FIPRNURE"), _
                                                                                                   dt.Rows(i).Item("FIPRESTA"))

                                                                End If

                                                            End If

                                                            stRestanteColindante = stColindante.ToString.Substring(18, 5)

                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stRestanteColindante) = True Then

                                                                stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                                stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                                ' verifica si el registro es numerico
                                                                If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                    ' inserta el registro
                                                                    objDatos.fun_Insertar_FIPRLIND(CInt(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   stPuntoCardinal, _
                                                                                                   stBaseTotal, _
                                                                                                   dt.Rows(i).Item("FIPRDEPA"), _
                                                                                                   dt.Rows(i).Item("FIPRMUNI"), _
                                                                                                   dt.Rows(i).Item("FIPRTIRE"), _
                                                                                                   dt.Rows(i).Item("FIPRCLSE"), _
                                                                                                   dt.Rows(i).Item("FIPRVIGE"), _
                                                                                                   dt.Rows(i).Item("FIPRRESO"), _
                                                                                                   fun_NumeroDeSecuenciaDeRegistroLindero(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   dt.Rows(i).Item("FIPRNURE"), _
                                                                                                   dt.Rows(i).Item("FIPRESTA"))

                                                                End If

                                                            End If

                                                            stRestanteColindante = stColindante.ToString.Substring(24, 5)

                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stRestanteColindante) = True Then

                                                                stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                                stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                                ' verifica si el registro es numerico
                                                                If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                    ' inserta el registro
                                                                    objDatos.fun_Insertar_FIPRLIND(CInt(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   stPuntoCardinal, _
                                                                                                   stBaseTotal, _
                                                                                                   dt.Rows(i).Item("FIPRDEPA"), _
                                                                                                   dt.Rows(i).Item("FIPRMUNI"), _
                                                                                                   dt.Rows(i).Item("FIPRTIRE"), _
                                                                                                   dt.Rows(i).Item("FIPRCLSE"), _
                                                                                                   dt.Rows(i).Item("FIPRVIGE"), _
                                                                                                   dt.Rows(i).Item("FIPRRESO"), _
                                                                                                   fun_NumeroDeSecuenciaDeRegistroLindero(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   dt.Rows(i).Item("FIPRNURE"), _
                                                                                                   dt.Rows(i).Item("FIPRESTA"))

                                                                End If

                                                            End If

                                                        End If

                                                        ' con cinco separadores
                                                    ElseIf inCantidadSeparadores = 5 Then

                                                        If stColindante.ToString.Length = 35 Then

                                                            ' actualiza el registro 
                                                            stRestanteColindante = Trim(stColindante).Substring(0, 5)
                                                            stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                            stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                            ' verifica si el registro es numerico
                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                ' actualiza el registro
                                                                objDatos.fun_Actualizar_FIPRLIND(inIdRegistro, CInt(dt.Rows(i).Item("FIPRNUFI")), stPuntoCardinal, stBaseTotal)

                                                            End If

                                                            stRestanteColindante = stColindante.ToString.Substring(6, 5)

                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stRestanteColindante) = True Then

                                                                stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                                stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                                ' verifica si el registro es numerico
                                                                If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                    ' inserta el registro
                                                                    objDatos.fun_Insertar_FIPRLIND(CInt(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   stPuntoCardinal, _
                                                                                                   stBaseTotal, _
                                                                                                   dt.Rows(i).Item("FIPRDEPA"), _
                                                                                                   dt.Rows(i).Item("FIPRMUNI"), _
                                                                                                   dt.Rows(i).Item("FIPRTIRE"), _
                                                                                                   dt.Rows(i).Item("FIPRCLSE"), _
                                                                                                   dt.Rows(i).Item("FIPRVIGE"), _
                                                                                                   dt.Rows(i).Item("FIPRRESO"), _
                                                                                                   fun_NumeroDeSecuenciaDeRegistroLindero(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   dt.Rows(i).Item("FIPRNURE"), _
                                                                                                   dt.Rows(i).Item("FIPRESTA"))
                                                                End If

                                                            End If

                                                            stRestanteColindante = stColindante.ToString.Substring(12, 5)

                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stRestanteColindante) = True Then

                                                                stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                                stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                                ' verifica si el registro es numerico
                                                                If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                    ' inserta el registro
                                                                    objDatos.fun_Insertar_FIPRLIND(CInt(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   stPuntoCardinal, _
                                                                                                   stBaseTotal, _
                                                                                                   dt.Rows(i).Item("FIPRDEPA"), _
                                                                                                   dt.Rows(i).Item("FIPRMUNI"), _
                                                                                                   dt.Rows(i).Item("FIPRTIRE"), _
                                                                                                   dt.Rows(i).Item("FIPRCLSE"), _
                                                                                                   dt.Rows(i).Item("FIPRVIGE"), _
                                                                                                   dt.Rows(i).Item("FIPRRESO"), _
                                                                                                   fun_NumeroDeSecuenciaDeRegistroLindero(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   dt.Rows(i).Item("FIPRNURE"), _
                                                                                                   dt.Rows(i).Item("FIPRESTA"))

                                                                End If

                                                            End If

                                                            stRestanteColindante = stColindante.ToString.Substring(18, 5)

                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stRestanteColindante) = True Then

                                                                stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                                stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                                ' verifica si el registro es numerico
                                                                If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                    ' inserta el registro
                                                                    objDatos.fun_Insertar_FIPRLIND(CInt(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   stPuntoCardinal, _
                                                                                                   stBaseTotal, _
                                                                                                   dt.Rows(i).Item("FIPRDEPA"), _
                                                                                                   dt.Rows(i).Item("FIPRMUNI"), _
                                                                                                   dt.Rows(i).Item("FIPRTIRE"), _
                                                                                                   dt.Rows(i).Item("FIPRCLSE"), _
                                                                                                   dt.Rows(i).Item("FIPRVIGE"), _
                                                                                                   dt.Rows(i).Item("FIPRRESO"), _
                                                                                                   fun_NumeroDeSecuenciaDeRegistroLindero(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   dt.Rows(i).Item("FIPRNURE"), _
                                                                                                   dt.Rows(i).Item("FIPRESTA"))

                                                                End If

                                                            End If

                                                            stRestanteColindante = stColindante.ToString.Substring(24, 5)

                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stRestanteColindante) = True Then

                                                                stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                                stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                                ' verifica si el registro es numerico
                                                                If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                    ' inserta el registro
                                                                    objDatos.fun_Insertar_FIPRLIND(CInt(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   stPuntoCardinal, _
                                                                                                   stBaseTotal, _
                                                                                                   dt.Rows(i).Item("FIPRDEPA"), _
                                                                                                   dt.Rows(i).Item("FIPRMUNI"), _
                                                                                                   dt.Rows(i).Item("FIPRTIRE"), _
                                                                                                   dt.Rows(i).Item("FIPRCLSE"), _
                                                                                                   dt.Rows(i).Item("FIPRVIGE"), _
                                                                                                   dt.Rows(i).Item("FIPRRESO"), _
                                                                                                   fun_NumeroDeSecuenciaDeRegistroLindero(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   dt.Rows(i).Item("FIPRNURE"), _
                                                                                                   dt.Rows(i).Item("FIPRESTA"))

                                                                End If

                                                            End If

                                                            stRestanteColindante = stColindante.ToString.Substring(30, 5)

                                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stRestanteColindante) = True Then

                                                                stBaseManzana = stFIPRMUNI & inFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED & stFIPREDIF
                                                                stBaseTotal = stBaseManzana & fun_Formato_Mascara_5_String(stRestanteColindante)

                                                                ' verifica si el registro es numerico
                                                                If fun_Verificar_Dato_Numerico_Evento_Validated(stBaseTotal) = True Then

                                                                    ' inserta el registro
                                                                    objDatos.fun_Insertar_FIPRLIND(CInt(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   stPuntoCardinal, _
                                                                                                   stBaseTotal, _
                                                                                                   dt.Rows(i).Item("FIPRDEPA"), _
                                                                                                   dt.Rows(i).Item("FIPRMUNI"), _
                                                                                                   dt.Rows(i).Item("FIPRTIRE"), _
                                                                                                   dt.Rows(i).Item("FIPRCLSE"), _
                                                                                                   dt.Rows(i).Item("FIPRVIGE"), _
                                                                                                   dt.Rows(i).Item("FIPRRESO"), _
                                                                                                   fun_NumeroDeSecuenciaDeRegistroLindero(dt.Rows(i).Item("FIPRNUFI")), _
                                                                                                   dt.Rows(i).Item("FIPRNURE"), _
                                                                                                   dt.Rows(i).Item("FIPRESTA"))

                                                                End If

                                                            End If

                                                        End If

                                                    End If

                                                End If

                                            End If

                                        End If

                                    End If

                                End If

                            End If

                        Next

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbPROCESO.Value = inProceso

                Next

                ' inicia la barra de progreso
                pbPROCESO.Value = 0

                mod_MENSAJE.Proceso_Termino_Correctamente()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CodificarEstructuraAnteriorAlaNuevaNivelPredioPorCambioDeCedulaCatastral()

        Try

            If MessageBox.Show("Se revisaran N° " & dt.Rows.Count & " registros. ¿ Desea Continuar ?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                ' verifica que existan registros
                If dt.Rows.Count > 0 Then

                    inProceso = 0
                    pbPROCESO.Value = 0
                    pbPROCESO.Maximum = dt.Rows.Count
                    Timer1.Enabled = True

                    Dim inContador As Integer = 0
                    Dim i As Integer = 0

                    For i = 0 To dt.Rows.Count - 1

                        ' almacena la cedula catastral actual
                        Dim stFIPRMUNI As String = CStr(Trim(dt.Rows(i).Item("FIPRMUNI").ToString))
                        Dim stFIPRCORR As String = CStr(Trim(dt.Rows(i).Item("FIPRCORR").ToString))
                        Dim stFIPRBARR As String = CStr(Trim(dt.Rows(i).Item("FIPRBARR").ToString))
                        Dim stFIPRMANZ As String = CStr(Trim(dt.Rows(i).Item("FIPRMANZ").ToString))
                        Dim stFIPRPRED As String = CStr(Trim(dt.Rows(i).Item("FIPRPRED").ToString))
                        Dim inFIPRCLSE As Integer = CInt(dt.Rows(i).Item("FIPRCLSE"))
                        Dim inFIPRTIFI As Integer = CInt(dt.Rows(i).Item("FIPRTIFI"))

                        Dim stLinderoCedulaActual As String = fun_Formato_Mascara_3_String(stFIPRMUNI) & _
                                                              inFIPRCLSE & _
                                                              fun_Formato_Mascara_3_String(stFIPRCORR) & _
                                                              fun_Formato_Mascara_3_String(stFIPRBARR) & _
                                                              fun_Formato_Mascara_4_String(stFIPRMANZ)

                        ' almacena la cedula anterior
                        Dim stFIPRMUAN As String = CStr(Trim(dt.Rows(i).Item("FIPRMUAN").ToString))
                        Dim stFIPRCOAN As String = CStr(Trim(dt.Rows(i).Item("FIPRCOAN").ToString))
                        Dim stFIPRBAAN As String = CStr(Trim(dt.Rows(i).Item("FIPRBAAN").ToString))
                        Dim stFIPRMAAN As String = CStr(Trim(dt.Rows(i).Item("FIPRMAAN").ToString))
                        Dim stFIPRPRAN As String = CStr(Trim(dt.Rows(i).Item("FIPRPRAN").ToString))
                        Dim inFIPRCSAN As Integer = CInt(dt.Rows(i).Item("FIPRCSAN"))

                        Dim stLinderoCedulaAnterior As String = fun_Formato_Mascara_3_String(stFIPRMUAN) & _
                                                                inFIPRCSAN & _
                                                                fun_Formato_Mascara_3_String(stFIPRCOAN) & _
                                                                fun_Formato_Mascara_3_String(stFIPRBAAN) & _
                                                                fun_Formato_Mascara_4_String(stFIPRMAAN)

                        ' declara la instancia
                        Dim obFIPRLIND As New cla_FIPRLIND
                        Dim dtFIPRLIND As New DataTable

                        dtFIPRLIND = obFIPRLIND.fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(CInt(dt.Rows(i).Item("FIPRNUFI")))

                        If dtFIPRLIND.Rows.Count > 0 Then

                            Dim k As Integer = 0

                            For k = 0 To dtFIPRLIND.Rows.Count - 1

                                Dim stLinderoActual As String = Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString)
                                Dim inSecuencia As Integer = CInt(dtFIPRLIND.Rows(k).Item("FPLIIDRE"))

                                ' verifica la longitud
                                If Trim(stLinderoActual.ToString.Length) = 19 AndAlso fun_Verificar_Dato_Numerico_Evento_Validated(stLinderoActual) = True Then

                                    ' verifica la codificación si el predio NO es de la misma vereda o manzana
                                    Dim dtFichaCedulaActual As New DataTable
                                    Dim dtFichaCedulaAnterior As New DataTable

                                    dtFichaCedulaActual = fun_ConsultarFichaPredialPorCedulaCatastralActual(Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(0, 3)), _
                                                                                                            Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(5, 2)), _
                                                                                                            Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(7, 3)), _
                                                                                                            Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(11, 3)), _
                                                                                                            Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(14, 5)), _
                                                                                                            inFIPRCLSE, _
                                                                                                            inFIPRTIFI)

                                    dtFichaCedulaAnterior = fun_ConsultarFichaPredialPorCedulaCatastralAnterior(Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(0, 3)), _
                                                                                                                Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(5, 2)), _
                                                                                                                Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(7, 3)), _
                                                                                                                Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(11, 3)), _
                                                                                                                Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(14, 5)), _
                                                                                                                inFIPRCSAN, _
                                                                                                                inFIPRTIFI)

                                    ' verifica el lindero con la cedula catastral actual
                                    If dtFichaCedulaActual.Rows.Count > 0 Then

                                        Dim stFIPRMUNI_1 As String = CStr(Trim(dtFichaCedulaActual.Rows(0).Item("FIPRMUNI").ToString))
                                        Dim stFIPRCORR_1 As String = CStr(Trim(dtFichaCedulaActual.Rows(0).Item("FIPRCORR").ToString))
                                        Dim stFIPRBARR_1 As String = CStr(Trim(dtFichaCedulaActual.Rows(0).Item("FIPRBARR").ToString))
                                        Dim stFIPRMANZ_1 As String = CStr(Trim(dtFichaCedulaActual.Rows(0).Item("FIPRMANZ").ToString))
                                        Dim stFIPRPRED_1 As String = CStr(Trim(dtFichaCedulaActual.Rows(0).Item("FIPRPRED").ToString))
                                        Dim inFIPRCLSE_1 As Integer = CInt(dtFichaCedulaActual.Rows(0).Item("FIPRCLSE"))

                                        Dim stLinderoCedulaActual_1 As String = fun_Formato_Mascara_3_String(stFIPRMUNI_1) & _
                                                                                inFIPRCLSE_1 & _
                                                                                fun_Formato_Mascara_3_String(stFIPRCORR_1) & _
                                                                                fun_Formato_Mascara_3_String(stFIPRBARR_1) & _
                                                                                fun_Formato_Mascara_4_String(stFIPRMANZ_1) & _
                                                                                fun_Formato_Mascara_5_String(stFIPRPRED_1)


                                        Dim stLinderoCorregido_1 As String = Trim(stLinderoCedulaActual_1)

                                        If fun_ActualizaLindero(inSecuencia, stLinderoCorregido_1) = True Then
                                            inContador += 1
                                        End If

                                    Else

                                        ' verifica el lindero con la cedula catastral anterior
                                        If dtFichaCedulaAnterior.Rows.Count > 0 Then

                                            ' declara la instancia
                                            Dim obFICHPRED As New cla_FICHPRED
                                            Dim tbFICHPRED As New DataTable

                                            tbFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dtFichaCedulaAnterior.Rows(0).Item("FIPRNUFI"))

                                            If tbFICHPRED.Rows.Count > 0 Then

                                                ' verifica el lindero con la cedula catastral anterior
                                                Dim stFIPRMUNI_1 As String = CStr(Trim(tbFICHPRED.Rows(0).Item("FIPRMUNI").ToString))
                                                Dim stFIPRCORR_1 As String = CStr(Trim(tbFICHPRED.Rows(0).Item("FIPRCORR").ToString))
                                                Dim stFIPRBARR_1 As String = CStr(Trim(tbFICHPRED.Rows(0).Item("FIPRBARR").ToString))
                                                Dim stFIPRMANZ_1 As String = CStr(Trim(tbFICHPRED.Rows(0).Item("FIPRMANZ").ToString))
                                                Dim inFIPRCLSE_1 As Integer = CInt(tbFICHPRED.Rows(0).Item("FIPRCLSE"))

                                                Dim stLinderoCedulaActual_1 As String = fun_Formato_Mascara_3_String(stFIPRMUNI_1) & _
                                                                                        inFIPRCLSE_1 & _
                                                                                        fun_Formato_Mascara_3_String(stFIPRCORR_1) & _
                                                                                        fun_Formato_Mascara_3_String(stFIPRBARR_1) & _
                                                                                        fun_Formato_Mascara_4_String(stFIPRMANZ_1)


                                                Dim stLinderoCorregido_1 As String = Trim(stLinderoCedulaActual_1) & Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(14, 5))

                                                If fun_ActualizaLindero(inSecuencia, stLinderoCorregido_1) = True Then
                                                    inContador += 1
                                                End If

                                            End If

                                        End If

                                    End If

                                End If

                            Next

                        End If

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbPROCESO.Value = inProceso

                    Next

                    ' inicia la barra de progreso
                    pbPROCESO.Value = 0

                    MessageBox.Show("Se actualizaron: " & inContador & " registros de linderos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                End If

            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CodificarLinderoDeUnPredioColindanteNuevo()

        Try
            If MessageBox.Show("Se revisaran N° " & dt.Rows.Count & " registros. ¿ Desea Continuar ?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                ' verifica que existan registros
                If dt.Rows.Count > 0 Then

                    ' apaga el boton
                    Me.cmdEJECUTAR.Enabled = False

                    ' limpia el contenedor de consulta
                    Me.dgvCONSULTA.DataSource = New DataTable

                    ' inicia la barra de progreso
                    inProceso = 0
                    pbPROCESO.Value = 0
                    pbPROCESO.Maximum = dt.Rows.Count
                    Timer1.Enabled = True

                    ' instancia la tabla
                    dt_CargaLinderos = New DataTable

                    ' Crea las columnas
                    dt_CargaLinderos.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                    dt_CargaLinderos.Columns.Add(New DataColumn("Cedula_Catastral", GetType(String)))
                    dt_CargaLinderos.Columns.Add(New DataColumn("Punto_Cardinal", GetType(String)))
                    dt_CargaLinderos.Columns.Add(New DataColumn("Colindante_Actual", GetType(String)))
                    dt_CargaLinderos.Columns.Add(New DataColumn("Colindante_Propuesto", GetType(String)))
                    dt_CargaLinderos.Columns.Add(New DataColumn("Observacion", GetType(String)))

                    ' crea el datarow
                    Dim dr1 As DataRow

                    Dim inContadorActualizados As Integer = 0
                    Dim inContadorEliminados As Integer = 0
                    Dim inContadorInsertados As Integer = 0

                    Dim i As Integer = 0

                    For i = 0 To dt.Rows.Count - 1

                        ' almacena la cedula catastral actual
                        Dim stFIPRNUFI As String = CStr(Trim(dt.Rows(i).Item("FIPRNUFI").ToString))
                        Dim stFIPRMUNI As String = CStr(Trim(dt.Rows(i).Item("FIPRMUNI").ToString))
                        Dim stFIPRCORR As String = CStr(Trim(dt.Rows(i).Item("FIPRCORR").ToString))
                        Dim stFIPRBARR As String = CStr(Trim(dt.Rows(i).Item("FIPRBARR").ToString))
                        Dim stFIPRMANZ As String = CStr(Trim(dt.Rows(i).Item("FIPRMANZ").ToString))
                        Dim stFIPRPRED As String = CStr(Trim(dt.Rows(i).Item("FIPRPRED").ToString))
                        Dim stFIPREDIF As String = CStr(Trim(dt.Rows(i).Item("FIPREDIF").ToString))
                        Dim stFIPRUNPR As String = CStr(Trim(dt.Rows(i).Item("FIPRUNPR").ToString))
                        Dim inFIPRCLSE As Integer = CInt(dt.Rows(i).Item("FIPRCLSE"))
                        Dim inFIPRTIFI As Integer = CInt(dt.Rows(i).Item("FIPRTIFI"))

                        ' lindero actual
                        Dim stLinderoCedulaActual As String = fun_Formato_Mascara_3_String(stFIPRMUNI) & _
                                                              inFIPRCLSE & _
                                                              fun_Formato_Mascara_3_String(stFIPRCORR) & _
                                                              fun_Formato_Mascara_3_String(stFIPRBARR) & _
                                                              fun_Formato_Mascara_4_String(stFIPRMANZ)

                        ' almacena la cedula anterior
                        Dim stFIPRMUAN As String = CStr(Trim(dt.Rows(i).Item("FIPRMUAN").ToString))
                        Dim stFIPRCOAN As String = CStr(Trim(dt.Rows(i).Item("FIPRCOAN").ToString))
                        Dim stFIPRBAAN As String = CStr(Trim(dt.Rows(i).Item("FIPRBAAN").ToString))
                        Dim stFIPRMAAN As String = CStr(Trim(dt.Rows(i).Item("FIPRMAAN").ToString))
                        Dim stFIPRPRAN As String = CStr(Trim(dt.Rows(i).Item("FIPRPRAN").ToString))
                        Dim inFIPRCSAN As Integer = CInt(dt.Rows(i).Item("FIPRCSAN"))

                        ' lindero anterior
                        Dim stLinderoCedulaAnterior As String = fun_Formato_Mascara_3_String(stFIPRMUAN) & _
                                                                inFIPRCSAN & _
                                                                fun_Formato_Mascara_3_String(stFIPRCOAN) & _
                                                                fun_Formato_Mascara_3_String(stFIPRBAAN) & _
                                                                fun_Formato_Mascara_4_String(stFIPRMAAN)

                        ' cedula catastral actual
                        Dim stCedulaCatastralActual As String = fun_Formato_Mascara_3_String(stFIPRMUNI) & "-" & _
                                                                inFIPRCLSE & "-" & _
                                                                fun_Formato_Mascara_2_String(stFIPRCORR) & "-" & _
                                                                fun_Formato_Mascara_3_String(stFIPRBARR) & "-" & _
                                                                fun_Formato_Mascara_3_String(stFIPRMANZ) & "-" & _
                                                                fun_Formato_Mascara_5_String(stFIPRPRED) & "-" & _
                                                                fun_Formato_Mascara_3_String(stFIPREDIF) & "-" & _
                                                                fun_Formato_Mascara_5_String(stFIPRUNPR)

                        ' declara la instancia
                        Dim obFIPRLIND As New cla_FIPRLIND
                        Dim dtFIPRLIND As New DataTable

                        dtFIPRLIND = obFIPRLIND.fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(CInt(dt.Rows(i).Item("FIPRNUFI")))

                        If dtFIPRLIND.Rows.Count > 0 Then

                            Dim k As Integer = 0

                            For k = 0 To dtFIPRLIND.Rows.Count - 1

                                Dim stPuntoCardinalDescripcion As String = Trim(fun_Buscar_Lista_Valores_PUNTCARD(Trim(dtFIPRLIND.Rows(k).Item("FPLIPUCA").ToString)))
                                Dim stPuntoCardinal As String = Trim(dtFIPRLIND.Rows(k).Item("FPLIPUCA").ToString)
                                Dim stLinderoActual As String = Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString)
                                Dim inSecuencia As Integer = CInt(dtFIPRLIND.Rows(k).Item("FPLIIDRE"))

                                ' verifica la longitud
                                If Trim(stLinderoActual.ToString.Length) = 19 AndAlso fun_Verificar_Dato_Numerico_Evento_Validated(stLinderoActual) = True Then

                                    ' verifica la codificación si el predio NO es de la misma vereda o manzana
                                    Dim dtFichaCedulaActual As New DataTable
                                    Dim dtFichaCedulaAnterior As New DataTable

                                    dtFichaCedulaActual = fun_ConsultarFichaPredialPorCedulaCatastralActual(Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(0, 3)), _
                                                                                                            Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(5, 2)), _
                                                                                                            Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(7, 3)), _
                                                                                                            Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(11, 3)), _
                                                                                                            Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(14, 5)), _
                                                                                                            inFIPRCLSE, _
                                                                                                            inFIPRTIFI)

                                    dtFichaCedulaAnterior = fun_ConsultarFichaPredialPorCedulaCatastralAnterior(Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(0, 3)), _
                                                                                                                Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(5, 2)), _
                                                                                                                Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(7, 3)), _
                                                                                                                Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(11, 3)), _
                                                                                                                Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString.Substring(14, 5)), _
                                                                                                                inFIPRCSAN, _
                                                                                                                inFIPRTIFI)

                                    ' verifica el lindero con la cedula catastral actual
                                    If dtFichaCedulaActual.Rows.Count > 0 Then

                                        ' almacena el lindero que colinda con accidente geografico
                                        dr1 = dt_CargaLinderos.NewRow()

                                        dr1("Nro_Ficha") = CInt(dt.Rows(i).Item("FIPRNUFI"))
                                        dr1("Cedula_Catastral") = CStr(stCedulaCatastralActual)
                                        dr1("Punto_Cardinal") = stPuntoCardinalDescripcion
                                        dr1("Colindante_Actual") = stLinderoActual & "_"
                                        dr1("Colindante_Propuesto") = ""
                                        dr1("Observacion") = "Lindero correcto"

                                        dt_CargaLinderos.Rows.Add(dr1)

                                        Dim stFIPRMUNI_1 As String = CStr(Trim(dtFichaCedulaActual.Rows(0).Item("FIPRMUNI").ToString))
                                        Dim stFIPRCORR_1 As String = CStr(Trim(dtFichaCedulaActual.Rows(0).Item("FIPRCORR").ToString))
                                        Dim stFIPRBARR_1 As String = CStr(Trim(dtFichaCedulaActual.Rows(0).Item("FIPRBARR").ToString))
                                        Dim stFIPRMANZ_1 As String = CStr(Trim(dtFichaCedulaActual.Rows(0).Item("FIPRMANZ").ToString))
                                        Dim stFIPRPRED_1 As String = CStr(Trim(dtFichaCedulaActual.Rows(0).Item("FIPRPRED").ToString))
                                        Dim inFIPRCLSE_1 As Integer = CInt(dtFichaCedulaActual.Rows(0).Item("FIPRCLSE"))

                                        Dim stLinderoCedulaActual_1 As String = fun_Formato_Mascara_3_String(stFIPRMUNI_1) & _
                                                                                inFIPRCLSE_1 & _
                                                                                fun_Formato_Mascara_3_String(stFIPRCORR_1) & _
                                                                                fun_Formato_Mascara_3_String(stFIPRBARR_1) & _
                                                                                fun_Formato_Mascara_4_String(stFIPRMANZ_1) & _
                                                                                fun_Formato_Mascara_5_String(stFIPRPRED_1)

                                        Dim stLinderoCorregido_1 As String = Trim(stLinderoCedulaActual_1)

                                    Else
                                        ' inserta linderos de movimientos de loteo
                                        If dtFichaCedulaActual.Rows.Count = 0 And dtFichaCedulaAnterior.Rows.Count > 1 Then

                                            If dtFichaCedulaAnterior.Rows.Count > 1 Then

                                                If Me.chkInsertayActualizaLinderoEnBD.Checked = True Then

                                                    ' elimina el lindero 
                                                    If fun_EliminaLindero(inSecuencia) = True Then
                                                        inContadorEliminados += 1
                                                    End If

                                                End If

                                                ' declaro la variable
                                                Dim ii As Integer = 0

                                                For ii = 0 To dtFichaCedulaAnterior.Rows.Count - 1

                                                    ' declara la instancia
                                                    Dim obFICHPRED As New cla_FICHPRED
                                                    Dim tbFICHPRED As New DataTable

                                                    tbFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dtFichaCedulaAnterior.Rows(ii).Item("FIPRNUFI"))

                                                    If tbFICHPRED.Rows.Count > 0 Then

                                                        ' verifica el lindero con la cedula catastral anterior
                                                        Dim inFIPRNUFI_1 As Integer = CInt(tbFICHPRED.Rows(0).Item("FIPRNUFI"))
                                                        Dim stFIPRDEPA_1 As String = CStr(Trim(tbFICHPRED.Rows(0).Item("FIPRDEPA").ToString))
                                                        Dim inFIPRTIRE_1 As Integer = CInt(tbFICHPRED.Rows(0).Item("FIPRTIRE").ToString)
                                                        Dim inFIPRVIGE_1 As Integer = CInt(tbFICHPRED.Rows(0).Item("FIPRVIGE").ToString)
                                                        Dim inFIPRRESO_1 As Integer = CInt(tbFICHPRED.Rows(0).Item("FIPRRESO").ToString)
                                                        Dim inFIPRNURE_1 As Integer = CInt(tbFICHPRED.Rows(0).Item("FIPRNURE").ToString)
                                                        Dim stFIPRESTA_1 As String = CStr(Trim(tbFICHPRED.Rows(0).Item("FIPRESTA").ToString))
                                                        Dim inFPLISECU_1 As Integer = fun_NumeroDeSecuenciaDeRegistroLindero(inFIPRNUFI_1)

                                                        Dim stFIPRMUNI_1 As String = CStr(Trim(tbFICHPRED.Rows(0).Item("FIPRMUNI").ToString))
                                                        Dim stFIPRCORR_1 As String = CStr(Trim(tbFICHPRED.Rows(0).Item("FIPRCORR").ToString))
                                                        Dim stFIPRBARR_1 As String = CStr(Trim(tbFICHPRED.Rows(0).Item("FIPRBARR").ToString))
                                                        Dim stFIPRMANZ_1 As String = CStr(Trim(tbFICHPRED.Rows(0).Item("FIPRMANZ").ToString))
                                                        Dim stFIPRPRED_1 As String = CStr(Trim(tbFICHPRED.Rows(0).Item("FIPRPRED").ToString))
                                                        Dim inFIPRCLSE_1 As Integer = CInt(tbFICHPRED.Rows(0).Item("FIPRCLSE"))

                                                        Dim stLinderoCedulaActual_1 As String = fun_Formato_Mascara_3_String(stFIPRMUNI_1) & _
                                                                                                inFIPRCLSE_1 & _
                                                                                                fun_Formato_Mascara_3_String(stFIPRCORR_1) & _
                                                                                                fun_Formato_Mascara_3_String(stFIPRBARR_1) & _
                                                                                                fun_Formato_Mascara_4_String(stFIPRMANZ_1) & _
                                                                                                fun_Formato_Mascara_5_String(stFIPRPRED_1)

                                                        ' almacena el lindero
                                                        Dim stLinderoCorregido_1 As String = Trim(stLinderoCedulaActual_1)

                                                        dr1 = dt_CargaLinderos.NewRow()

                                                        dr1("Nro_Ficha") = CInt(dt.Rows(i).Item("FIPRNUFI"))
                                                        dr1("Cedula_Catastral") = stCedulaCatastralActual
                                                        dr1("Punto_Cardinal") = stPuntoCardinalDescripcion
                                                        dr1("Colindante_Actual") = stLinderoActual & "_"
                                                        dr1("Colindante_Propuesto") = stLinderoCorregido_1 & "_"
                                                        dr1("Observacion") = "Lindero para verificar por loteo"

                                                        dt_CargaLinderos.Rows.Add(dr1)

                                                        ' inserta lindero en la base de datos
                                                        If Me.chkInsertayActualizaLinderoEnBD.Checked = True Then

                                                            Dim obFIPRLIND_1 As New cla_FIPRLIND

                                                            If obFIPRLIND_1.fun_Insertar_FIPRLIND(inFIPRNUFI_1, stPuntoCardinal, stLinderoCorregido_1, stFIPRDEPA_1, stFIPRMUNI_1, inFIPRTIRE_1, inFIPRCLSE_1, inFIPRVIGE_1, inFIPRRESO_1, inFPLISECU_1, inFIPRNURE_1, stFIPRESTA_1) = True Then
                                                                inContadorInsertados += 1
                                                            End If

                                                        End If

                                                    End If

                                                Next

                                            End If

                                            ' inserta linderos de movimientos de venta parcial
                                        ElseIf dtFichaCedulaAnterior.Rows.Count > 0 And dtFichaCedulaActual.Rows.Count > 0 Then

                                            If dtFichaCedulaActual.Rows.Count = 1 And dtFichaCedulaAnterior.Rows.Count >= 1 Then

                                                dr1 = dt_CargaLinderos.NewRow()

                                                dr1("Nro_Ficha") = CInt(dt.Rows(i).Item("FIPRNUFI"))
                                                dr1("Cedula_Catastral") = stCedulaCatastralActual
                                                dr1("Punto_Cardinal") = stPuntoCardinalDescripcion
                                                dr1("Colindante_Actual") = stLinderoActual & "_"
                                                dr1("Colindante_Propuesto") = stLinderoActual & "_"
                                                dr1("Observacion") = "Lindero a verificar por venta parcial"

                                                dt_CargaLinderos.Rows.Add(dr1)

                                                ' declaro la variable
                                                Dim ii As Integer = 0

                                                For ii = 0 To dtFichaCedulaAnterior.Rows.Count - 1

                                                    ' declara la instancia
                                                    Dim obFICHPRED As New cla_FICHPRED
                                                    Dim tbFICHPRED As New DataTable

                                                    tbFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dtFichaCedulaAnterior.Rows(ii).Item("FIPRNUFI"))

                                                    If tbFICHPRED.Rows.Count > 0 Then

                                                        ' verifica el lindero con la cedula catastral anterior
                                                        Dim inFIPRNUFI_1 As Integer = CInt(tbFICHPRED.Rows(ii).Item("FIPRNUFI").ToString)
                                                        Dim stFIPRDEPA_1 As String = CStr(Trim(tbFICHPRED.Rows(ii).Item("FIPRDEPA").ToString))
                                                        Dim inFIPRTIRE_1 As Integer = CInt(tbFICHPRED.Rows(ii).Item("FIPRTIRE").ToString)
                                                        Dim inFIPRVIGE_1 As Integer = CInt(tbFICHPRED.Rows(ii).Item("FIPRVIGE").ToString)
                                                        Dim inFIPRRESO_1 As Integer = CInt(tbFICHPRED.Rows(ii).Item("FIPRRESO").ToString)
                                                        Dim inFIPRNURE_1 As Integer = CInt(tbFICHPRED.Rows(ii).Item("FIPRNURE").ToString)
                                                        Dim stFIPRESTA_1 As String = CStr(Trim(tbFICHPRED.Rows(ii).Item("FIPRESTA").ToString))
                                                        Dim inFPLISECU_1 As Integer = fun_NumeroDeSecuenciaDeRegistroLindero(inFIPRNUFI_1)

                                                        Dim stFIPRMUNI_1 As String = CStr(Trim(tbFICHPRED.Rows(ii).Item("FIPRMUNI").ToString))
                                                        Dim stFIPRCORR_1 As String = CStr(Trim(tbFICHPRED.Rows(ii).Item("FIPRCORR").ToString))
                                                        Dim stFIPRBARR_1 As String = CStr(Trim(tbFICHPRED.Rows(ii).Item("FIPRBARR").ToString))
                                                        Dim stFIPRMANZ_1 As String = CStr(Trim(tbFICHPRED.Rows(ii).Item("FIPRMANZ").ToString))
                                                        Dim stFIPRPRED_1 As String = CStr(Trim(tbFICHPRED.Rows(ii).Item("FIPRPRED").ToString))
                                                        Dim inFIPRCLSE_1 As Integer = CInt(tbFICHPRED.Rows(ii).Item("FIPRCLSE"))

                                                        Dim stLinderoCedulaActual_1 As String = fun_Formato_Mascara_3_String(stFIPRMUNI_1) & _
                                                                                                inFIPRCLSE_1 & _
                                                                                                fun_Formato_Mascara_3_String(stFIPRCORR_1) & _
                                                                                                fun_Formato_Mascara_3_String(stFIPRBARR_1) & _
                                                                                                fun_Formato_Mascara_4_String(stFIPRMANZ_1) & _
                                                                                                fun_Formato_Mascara_5_String(stFIPRPRED_1)

                                                        ' almacena el lindero
                                                        Dim stLinderoCorregido_1 As String = Trim(stLinderoCedulaActual_1)

                                                        dr1 = dt_CargaLinderos.NewRow()

                                                        dr1("Nro_Ficha") = inFIPRNUFI_1
                                                        dr1("Cedula_Catastral") = stCedulaCatastralActual
                                                        dr1("Punto_Cardinal") = stPuntoCardinalDescripcion
                                                        dr1("Colindante_Actual") = stLinderoActual & "_"
                                                        dr1("Colindante_Propuesto") = stLinderoCorregido_1 & "_"
                                                        dr1("Observacion") = "Lindero a verificar por venta parcial"

                                                        dt_CargaLinderos.Rows.Add(dr1)

                                                        ' inserta lindero en la base de datos
                                                        If Me.chkInsertayActualizaLinderoEnBD.Checked = True Then

                                                            Dim obFIPRLIND_1 As New cla_FIPRLIND

                                                            If obFIPRLIND_1.fun_Insertar_FIPRLIND(inFIPRNUFI_1, stPuntoCardinal, stLinderoCorregido_1, stFIPRDEPA_1, stFIPRMUNI_1, inFIPRTIRE_1, inFIPRCLSE_1, inFIPRVIGE_1, inFIPRRESO_1, inFPLISECU_1, inFIPRNURE_1, stFIPRESTA_1) = True Then
                                                                inContadorInsertados += 1
                                                            End If

                                                        End If

                                                    End If

                                                Next

                                            End If

                                            ' inserta linderos de movimientos de englobe
                                        ElseIf dtFichaCedulaAnterior.Rows.Count = 1 And dtFichaCedulaActual.Rows.Count = 0 Then

                                            Dim bySW As Byte = 0

                                            If dtFichaCedulaAnterior.Rows.Count = 1 Then

                                                ' declara la instancia
                                                Dim obFICHPRED As New cla_FICHPRED
                                                Dim tbFICHPRED As New DataTable

                                                tbFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dtFichaCedulaAnterior.Rows(0).Item("FIPRNUFI"))

                                                If tbFICHPRED.Rows.Count > 0 Then

                                                    ' verifica el lindero con la cedula catastral anterior
                                                    Dim inFIPRNUFI_1 As Integer = CInt(tbFICHPRED.Rows(0).Item("FIPRNUFI").ToString)
                                                    Dim stFIPRDEPA_1 As String = CStr(Trim(tbFICHPRED.Rows(0).Item("FIPRDEPA").ToString))
                                                    Dim inFIPRTIRE_1 As Integer = CInt(tbFICHPRED.Rows(0).Item("FIPRTIRE").ToString)
                                                    Dim inFIPRVIGE_1 As Integer = CInt(tbFICHPRED.Rows(0).Item("FIPRVIGE").ToString)
                                                    Dim inFIPRRESO_1 As Integer = CInt(tbFICHPRED.Rows(0).Item("FIPRRESO").ToString)
                                                    Dim inFIPRNURE_1 As Integer = CInt(tbFICHPRED.Rows(0).Item("FIPRNURE").ToString)
                                                    Dim stFIPRESTA_1 As String = CStr(Trim(tbFICHPRED.Rows(0).Item("FIPRESTA").ToString))
                                                    Dim inFPLISECU_1 As Integer = fun_NumeroDeSecuenciaDeRegistroLindero(inFIPRNUFI_1)

                                                    Dim stFIPRMUNI_1 As String = CStr(Trim(tbFICHPRED.Rows(0).Item("FIPRMUNI").ToString))
                                                    Dim stFIPRCORR_1 As String = CStr(Trim(tbFICHPRED.Rows(0).Item("FIPRCORR").ToString))
                                                    Dim stFIPRBARR_1 As String = CStr(Trim(tbFICHPRED.Rows(0).Item("FIPRBARR").ToString))
                                                    Dim stFIPRMANZ_1 As String = CStr(Trim(tbFICHPRED.Rows(0).Item("FIPRMANZ").ToString))
                                                    Dim stFIPRPRED_1 As String = CStr(Trim(tbFICHPRED.Rows(0).Item("FIPRPRED").ToString))
                                                    Dim inFIPRCLSE_1 As Integer = CInt(tbFICHPRED.Rows(0).Item("FIPRCLSE"))

                                                    Dim stLinderoCedulaActual_1 As String = fun_Formato_Mascara_3_String(stFIPRMUNI_1) & _
                                                                                            inFIPRCLSE_1 & _
                                                                                            fun_Formato_Mascara_3_String(stFIPRCORR_1) & _
                                                                                            fun_Formato_Mascara_3_String(stFIPRBARR_1) & _
                                                                                            fun_Formato_Mascara_4_String(stFIPRMANZ_1) & _
                                                                                            fun_Formato_Mascara_5_String(stFIPRPRED_1)

                                                    ' almacena el lindero
                                                    Dim stLinderoCorregido_1 As String = Trim(stLinderoCedulaActual_1)

                                                    ' declaro la instancia
                                                    Dim obFIPRLIND_2 As New cla_FIPRLIND
                                                    Dim dtFIPRLIND_2 As New DataTable

                                                    dtFIPRLIND_2 = obFIPRLIND_2.fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(CInt(dt.Rows(i).Item("FIPRNUFI")))

                                                    If dtFIPRLIND_2.Rows.Count > 0 Then

                                                        Dim sw1 As Byte = 0
                                                        Dim j1 As Integer = 0

                                                        While j1 < dtFIPRLIND_2.Rows.Count And sw1 = 0

                                                            Dim inFichaPredial_2 As Integer = CInt(dtFIPRLIND_2.Rows(j1).Item("FPLINUFI"))
                                                            Dim inSecuencia_1 As Integer = CInt(dtFIPRLIND_2.Rows(j1).Item("FPLIIDRE"))

                                                            ' verifica la longitud
                                                            If Trim(stLinderoActual.ToString.Length) = 19 AndAlso fun_Verificar_Dato_Numerico_Evento_Validated(stLinderoActual) = True Then

                                                                ' verifica la codificación 
                                                                Dim dtFichaCedulaActual_1 As New DataTable

                                                                dtFichaCedulaActual_1 = fun_ConsultarFichaPredialPorCedulaCatastralActual(Trim(dtFIPRLIND_2.Rows(j1).Item("FPLICOLI").ToString.Substring(0, 3)), _
                                                                                                                                          Trim(dtFIPRLIND_2.Rows(j1).Item("FPLICOLI").ToString.Substring(5, 2)), _
                                                                                                                                          Trim(dtFIPRLIND_2.Rows(j1).Item("FPLICOLI").ToString.Substring(7, 3)), _
                                                                                                                                          Trim(dtFIPRLIND_2.Rows(j1).Item("FPLICOLI").ToString.Substring(11, 3)), _
                                                                                                                                          Trim(dtFIPRLIND_2.Rows(j1).Item("FPLICOLI").ToString.Substring(14, 5)), _
                                                                                                                                          inFIPRCLSE, _
                                                                                                                                          inFIPRTIFI)
                                                                ' verifica si existe los registros
                                                                If dtFichaCedulaActual_1.Rows.Count = 0 Then

                                                                    dr1 = dt_CargaLinderos.NewRow()

                                                                    dr1("Nro_Ficha") = CInt(inFichaPredial_2)
                                                                    dr1("Cedula_Catastral") = stCedulaCatastralActual
                                                                    dr1("Punto_Cardinal") = stPuntoCardinalDescripcion
                                                                    dr1("Colindante_Actual") = stLinderoActual & "_"
                                                                    dr1("Colindante_Propuesto") = stLinderoCorregido_1 & "_"
                                                                    dr1("Observacion") = "Lindero a verificar por englobe"

                                                                    dt_CargaLinderos.Rows.Add(dr1)

                                                                    ' actualiza lindero en la base de datos
                                                                    If Me.chkInsertayActualizaLinderoEnBD.Checked = True Then

                                                                        If fun_ActualizaLindero(inSecuencia_1, stLinderoCorregido_1) = True Then
                                                                            inContadorActualizados += 1
                                                                        End If

                                                                    End If

                                                                    ' sale del ciclo
                                                                    sw1 = 1
                                                                Else
                                                                    ' incrementa el ciclo
                                                                    j1 = j1 + 1

                                                                End If

                                                            Else
                                                                ' incrementa el ciclo
                                                                j1 = j1 + 1

                                                            End If

                                                        End While

                                                    End If

                                                End If

                                            End If

                                        Else
                                            ' almacena el lindero que colinda con accidente geografico o no cumple las condiciones
                                            dr1 = dt_CargaLinderos.NewRow()

                                            dr1("Nro_Ficha") = CInt(dt.Rows(i).Item("FIPRNUFI"))
                                            dr1("Cedula_Catastral") = CStr(stCedulaCatastralActual)
                                            dr1("Punto_Cardinal") = stPuntoCardinalDescripcion
                                            dr1("Colindante_Actual") = stLinderoActual & "_"
                                            dr1("Colindante_Propuesto") = ""
                                            dr1("Observacion") = "Lindero no se ubico por colindancia"

                                            dt_CargaLinderos.Rows.Add(dr1)

                                        End If

                                    End If

                                Else
                                    ' almacena el lindero que colinda con accidente geografico
                                    dr1 = dt_CargaLinderos.NewRow()

                                    dr1("Nro_Ficha") = CInt(dt.Rows(i).Item("FIPRNUFI"))
                                    dr1("Cedula_Catastral") = CStr(stCedulaCatastralActual)
                                    dr1("Punto_Cardinal") = stPuntoCardinalDescripcion
                                    dr1("Colindante_Actual") = stLinderoActual & "_"
                                    dr1("Colindante_Propuesto") = ""
                                    dr1("Observacion") = "Lindero correcto"

                                    dt_CargaLinderos.Rows.Add(dr1)

                                End If

                            Next

                        End If

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbPROCESO.Value = inProceso

                    Next

                    ' llena el datagrid
                    Me.dgvCONSULTA.DataSource = dt_CargaLinderos

                    ' prende el boton
                    Me.cmdEJECUTAR.Enabled = True

                    ' inicia la barra de progreso
                    pbPROCESO.Value = 0

                    ' Numero de registros recuperados
                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCONSULTA.RowCount

                    MessageBox.Show("Se actualizaron: " & inContadorActualizados & " registros de linderos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "-" & stFIPRNUFI)
        End Try

    End Sub
    Private Sub pro_DepurarLinderosQueNoFueronCodificados()

        Try
            If MessageBox.Show("Se depuraran N° " & dt.Rows.Count & " registros. ¿ Desea Continuar ?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                ' verifica que existan registros
                If dt.Rows.Count > 0 Then

                    ' apaga el boton
                    Me.cmdEJECUTAR.Enabled = False

                    ' declara la variable
                    Dim inContadorActualizados As Integer = 0

                    ' inicia la barra de progreso
                    inProceso = 0
                    pbPROCESO.Value = 0
                    pbPROCESO.Maximum = dt.Rows.Count
                    Timer1.Enabled = True

                    ' instancia la tabla
                    dt_CargaLinderos = New DataTable

                    ' Crea las columnas
                    dt_CargaLinderos.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                    dt_CargaLinderos.Columns.Add(New DataColumn("Cedula_Catastral", GetType(String)))
                    dt_CargaLinderos.Columns.Add(New DataColumn("Punto_Cardinal", GetType(String)))
                    dt_CargaLinderos.Columns.Add(New DataColumn("Colindante_Actual", GetType(String)))
                    dt_CargaLinderos.Columns.Add(New DataColumn("Colindante_Propuesto", GetType(String)))
                    dt_CargaLinderos.Columns.Add(New DataColumn("Observacion", GetType(String)))

                    ' crea el datarow
                    Dim dr1 As DataRow

                    Dim i As Integer = 0

                    For i = 0 To dt.Rows.Count - 1

                        Dim inFicha As Integer = CInt(dt.Rows(i).Item("FIPRNUFI"))

                        ' declara la instancia
                        Dim obFIPRLIND As New cla_FIPRLIND
                        Dim dtFIPRLIND As New DataTable

                        dtFIPRLIND = obFIPRLIND.fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(inFicha)

                        If dtFIPRLIND.Rows.Count > 0 Then

                            Dim k As Integer = 0

                            For k = 0 To dtFIPRLIND.Rows.Count - 1

                                Dim inFichaPredial As Integer = CInt(dtFIPRLIND.Rows(k).Item("FPLINUFI"))
                                Dim stPuntoCardinalDescripcion As String = fun_Buscar_Lista_Valores_PUNTCARD(Trim(dtFIPRLIND.Rows(k).Item("FPLIPUCA").ToString))
                                Dim stPuntoCardinal As String = Trim(dtFIPRLIND.Rows(k).Item("FPLIPUCA").ToString)
                                Dim stLinderoActual As String = Trim(dtFIPRLIND.Rows(k).Item("FPLICOLI").ToString)
                                Dim inSecuencia As Integer = CInt(dtFIPRLIND.Rows(k).Item("FPLIIDRE"))

                                ' verifica la longitud
                                If Trim(stLinderoActual.ToString.Length) >= 3 Then
                                    If Trim(stLinderoActual.ToString.Length) <= 19 AndAlso fun_Verificar_Dato_Numerico_Evento_Validated(stLinderoActual) = True Then
                                        If Trim(stLinderoActual.ToString.Substring(0, 3)) = Trim(dtFIPRLIND.Rows(k).Item("FPLIMUNI").ToString) Then
                                            If fun_ConsultaSeparadores(stLinderoActual) = True Then

                                                Dim stFIPRMUNI_1 As String = CStr(Trim(dt.Rows(i).Item("FIPRMUNI").ToString))
                                                Dim stFIPRCORR_1 As String = CStr(Trim(dt.Rows(i).Item("FIPRCORR").ToString))
                                                Dim stFIPRBARR_1 As String = CStr(Trim(dt.Rows(i).Item("FIPRBARR").ToString))
                                                Dim stFIPRMANZ_1 As String = CStr(Trim(dt.Rows(i).Item("FIPRMANZ").ToString))
                                                Dim stFIPRPRED_1 As String = CStr(Trim(dt.Rows(i).Item("FIPRPRED").ToString))
                                                Dim stFIPREDIF_1 As String = CStr(Trim(dt.Rows(i).Item("FIPREDIF").ToString))
                                                Dim stFIPRUNPR_1 As String = CStr(Trim(dt.Rows(i).Item("FIPRUNPR").ToString))
                                                Dim inFIPRCLSE_1 As Integer = CInt(dt.Rows(i).Item("FIPRCLSE"))

                                                ' cedula catastral actual
                                                Dim stCedulaCatastralActual As String = fun_Formato_Mascara_3_String(stFIPRMUNI_1) & "-" & _
                                                                                        inFIPRCLSE_1 & "-" & _
                                                                                        fun_Formato_Mascara_2_String(stFIPRCORR_1) & "-" & _
                                                                                        fun_Formato_Mascara_3_String(stFIPRBARR_1) & "-" & _
                                                                                        fun_Formato_Mascara_3_String(stFIPRMANZ_1) & "-" & _
                                                                                        fun_Formato_Mascara_5_String(stFIPRPRED_1) & "-" & _
                                                                                        fun_Formato_Mascara_3_String(stFIPREDIF_1) & "-" & _
                                                                                        fun_Formato_Mascara_5_String(stFIPRUNPR_1)

                                                Dim stLinderoCedulaActual_1 As String = fun_Formato_Mascara_3_String(stFIPRMUNI_1) & _
                                                                                        inFIPRCLSE_1 & _
                                                                                        fun_Formato_Mascara_3_String(stFIPRCORR_1) & _
                                                                                        fun_Formato_Mascara_3_String(stFIPRBARR_1) & _
                                                                                        fun_Formato_Mascara_4_String(stFIPRMANZ_1)

                                                Dim stLinderoCorregido_1 As String = Trim(stLinderoCedulaActual_1) & fun_Formato_Mascara_5_String(fun_SeleccionarUltimoDigito(stLinderoActual))

                                                ' almacena el lindero que colinda con accidente geografico
                                                dr1 = dt_CargaLinderos.NewRow()

                                                dr1("Nro_Ficha") = CInt(inFichaPredial)
                                                dr1("Cedula_Catastral") = CStr(stCedulaCatastralActual)
                                                dr1("Punto_Cardinal") = stPuntoCardinalDescripcion
                                                dr1("Colindante_Actual") = stLinderoActual & "_"
                                                dr1("Colindante_Propuesto") = stLinderoCorregido_1 & "_"
                                                dr1("Observacion") = "Verificar o completar lindero en el campo de predio"

                                                dt_CargaLinderos.Rows.Add(dr1)

                                                ' actualiza lindero en la base de datos
                                                If Me.chkInsertayActualizaLinderoEnBD.Checked = True Then

                                                    If fun_ActualizaLindero(inSecuencia, stLinderoCorregido_1) = True Then
                                                        inContadorActualizados += 1
                                                    End If

                                                End If

                                            End If
                                        End If
                                    End If
                                End If

                                ' verifica la longitud y corrige cuando tiene los 19 caracteres y posee guion
                                If Trim(stLinderoActual.ToString.Length) >= 19 Then
                                    If Trim(stLinderoActual.ToString.Substring(0, 3)) = Trim(dtFIPRLIND.Rows(k).Item("FPLIMUNI").ToString) Then
                                        If fun_ContarSeparadores(stLinderoActual) > 0 Then
                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stLinderoActual.ToString.Substring(0, 19)) = True Then

                                                Dim stFIPRMUNI_1 As String = CStr(Trim(dt.Rows(i).Item("FIPRMUNI").ToString))
                                                Dim stFIPRCORR_1 As String = CStr(Trim(dt.Rows(i).Item("FIPRCORR").ToString))
                                                Dim stFIPRBARR_1 As String = CStr(Trim(dt.Rows(i).Item("FIPRBARR").ToString))
                                                Dim stFIPRMANZ_1 As String = CStr(Trim(dt.Rows(i).Item("FIPRMANZ").ToString))
                                                Dim stFIPRPRED_1 As String = CStr(Trim(dt.Rows(i).Item("FIPRPRED").ToString))
                                                Dim stFIPREDIF_1 As String = CStr(Trim(dt.Rows(i).Item("FIPREDIF").ToString))
                                                Dim stFIPRUNPR_1 As String = CStr(Trim(dt.Rows(i).Item("FIPRUNPR").ToString))
                                                Dim inFIPRCLSE_1 As Integer = CInt(dt.Rows(i).Item("FIPRCLSE"))

                                                ' cedula catastral actual
                                                Dim stCedulaCatastralActual As String = fun_Formato_Mascara_3_String(stFIPRMUNI_1) & "-" & _
                                                                                        inFIPRCLSE_1 & "-" & _
                                                                                        fun_Formato_Mascara_2_String(stFIPRCORR_1) & "-" & _
                                                                                        fun_Formato_Mascara_3_String(stFIPRBARR_1) & "-" & _
                                                                                        fun_Formato_Mascara_3_String(stFIPRMANZ_1) & "-" & _
                                                                                        fun_Formato_Mascara_5_String(stFIPRPRED_1) & "-" & _
                                                                                        fun_Formato_Mascara_3_String(stFIPREDIF_1) & "-" & _
                                                                                        fun_Formato_Mascara_5_String(stFIPRUNPR_1)

                                                Dim stLinderoCorregido_1 As String = Trim(stLinderoActual.ToString.Substring(0, 19))

                                                ' almacena el lindero que colinda con accidente geografico
                                                dr1 = dt_CargaLinderos.NewRow()

                                                dr1("Nro_Ficha") = CInt(inFichaPredial)
                                                dr1("Cedula_Catastral") = CStr(stCedulaCatastralActual)
                                                dr1("Punto_Cardinal") = stPuntoCardinalDescripcion
                                                dr1("Colindante_Actual") = stLinderoActual & "_"
                                                dr1("Colindante_Propuesto") = stLinderoCorregido_1 & "_"
                                                dr1("Observacion") = "Se depuro el lindero en el campo despues de predio"

                                                dt_CargaLinderos.Rows.Add(dr1)

                                                ' actualiza lindero en la base de datos
                                                If Me.chkInsertayActualizaLinderoEnBD.Checked = True Then

                                                    If fun_ActualizaLindero(inSecuencia, stLinderoCorregido_1) = True Then
                                                        inContadorActualizados += 1
                                                    End If

                                                End If

                                            End If
                                        End If
                                    End If
                                End If

                            Next

                        End If

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbPROCESO.Value = inProceso

                    Next

                    ' llena el datagrid
                    Me.dgvCONSULTA.DataSource = dt_CargaLinderos

                    ' prende el boton
                    Me.cmdEJECUTAR.Enabled = True

                    ' inicia la barra de progreso
                    pbPROCESO.Value = 0

                    ' Numero de registros recuperados
                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCONSULTA.RowCount

                    MessageBox.Show("Se actualizaron: " & inContadorActualizados & " registros de linderos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdEJECUTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEJECUTAR.Click

        Try
            ' ejecuta la consulta
            pro_ConsultarFichaPredial()

            If dt.Rows.Count > 0 Then

                Me.cmdEJECUTAR.Enabled = False

                Dim inSeleccion As Integer = Me.cboProcesos.SelectedIndex

                Select Case inSeleccion

                    Case 0
                        pro_CodificarEstructuraAnteriorAlaNuevaNivelPredio()
                    Case 1
                        pro_CodificarEstructuraAnteriorAlaNuevaNivelUnidadPredial()
                    Case 2
                        pro_CodificarEstructuraAnteriorAlaNuevaNivelPredioPorCambioDeCedulaCatastral()
                    Case 3
                        pro_CodificarLinderoDeUnPredioColindanteNuevo()
                    Case 4
                        pro_DepurarLinderosQueNoFueronCodificados()

                End Select

                Me.cmdEJECUTAR.Enabled = True

            Else
                mod_MENSAJE.Consulta_No_Encontro_Registros()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " Error ficha: " & inFichaPredial)
            Me.cmdEJECUTAR.Enabled = True
        End Try

    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
        Me.txtFIPRNUFI.Focus()
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
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

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_Insertar_Cartografia_Por_Lotes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtFIPRNUFI.Focus()
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFIPRCLSE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCLSE.Validated
        If Trim(txtFIPRCLSE.Text) = "" Then
            lblFIPRCLSE.Text = ""
        Else
            lblFIPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(txtFIPRCLSE.Text)), String)
        End If
    End Sub
    Private Sub txtFIPRCASU_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCASU.Validated
        If Trim(txtFIPRCASU.Text) = "" Then
            lblFIPRCASU.Text = ""
        Else
            lblFIPRCASU.Text = CType(fun_Buscar_Lista_Valores_CATESUEL(Trim(txtFIPRCASU.Text)), String)
        End If
    End Sub
    Private Sub txtFIPRCAPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCAPR.Validated
        If Trim(txtFIPRCAPR.Text) = "" Then
            lblFIPRCAPR.Text = ""
        Else
            lblFIPRCAPR.Text = CType(fun_Buscar_Lista_Valores_CARAPRED(Trim(txtFIPRCAPR.Text)), String)
        End If
    End Sub
    Private Sub txtFIPRMOAD_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMOAD.Validated
        If Trim(txtFIPRMOAD.Text) = "" Then
            lblFIPRMOAD.Text = ""
        Else
            lblFIPRMOAD.Text = CType(fun_Buscar_Lista_Valores_MODOADQU(Trim(txtFIPRMOAD.Text)), String)
        End If
    End Sub
    Private Sub txtFIPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.Validated
        If Me.txtFIPRMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRMUNI.Text) = True Then
            Me.txtFIPRMUNI.Text = fun_Formato_Mascara_3_String(Me.txtFIPRMUNI.Text)
        End If
    End Sub
    Private Sub txtFIPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.Validated
        If Me.txtFIPRCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRCORR.Text) = True Then
            Me.txtFIPRCORR.Text = fun_Formato_Mascara_2_String(Me.txtFIPRCORR.Text)
        End If
    End Sub
    Private Sub txtFIPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.Validated
        If Me.txtFIPRBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRBARR.Text) = True Then
            Me.txtFIPRBARR.Text = fun_Formato_Mascara_3_String(Me.txtFIPRBARR.Text)
        End If
    End Sub
    Private Sub txtFIPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.Validated
        If Me.txtFIPRMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRMANZ.Text) = True Then
            Me.txtFIPRMANZ.Text = fun_Formato_Mascara_3_String(Me.txtFIPRMANZ.Text)
        End If
    End Sub
    Private Sub txtFIPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.Validated
        If Me.txtFIPRPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRPRED.Text) = True Then
            Me.txtFIPRPRED.Text = fun_Formato_Mascara_5_String(Me.txtFIPRPRED.Text)
        End If
    End Sub
    Private Sub txtFIPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.Validated
        If Me.txtFIPREDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPREDIF.Text) = True Then
            Me.txtFIPREDIF.Text = fun_Formato_Mascara_3_String(Me.txtFIPREDIF.Text)
        End If
    End Sub
    Private Sub txtFIPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.Validated
        If Me.txtFIPRUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRUNPR.Text) = True Then
            Me.txtFIPRUNPR.Text = fun_Formato_Mascara_5_String(Me.txtFIPRUNPR.Text)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtFIPRNUFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRNUFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRTIFI.Focus()
        End If
    End Sub
    Private Sub txtFIPRTIFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRTIFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRDIRE.Focus()
        End If
    End Sub
    Private Sub txtFIPRDIRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRDIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRMUNI.Focus()
        End If
    End Sub
    Private Sub txtFIPRMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMUNI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRCORR.Focus()
        End If
    End Sub
    Private Sub txtFIPRCORR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCORR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRBARR.Focus()
        End If
    End Sub
    Private Sub txtFIPRBARR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRBARR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRMANZ.Focus()
        End If
    End Sub
    Private Sub txtFIPRMANZ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMANZ.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRPRED.Focus()
        End If
    End Sub
    Private Sub txtFIPRPRED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPRED.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPREDIF.Focus()
        End If
    End Sub
    Private Sub txtFIPREDIF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPREDIF.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRUNPR.Focus()
        End If
    End Sub
    Private Sub txtFIPRUNPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRUNPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRCLSE.Focus()
        End If
    End Sub
    Private Sub txtFIPRCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRCASU.Focus()
        End If
    End Sub
    Private Sub txtFIPRCASU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCASU.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRCAPR.Focus()
        End If
    End Sub
    Private Sub txtFIPRCAPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCAPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRMOAD.Focus()
        End If
    End Sub
    Private Sub txtFIPRMOAD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMOAD.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cmdEJECUTAR.Focus()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cmdEJECUTAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdEJECUTAR.KeyDown, txtFIPRNUFI.KeyDown, txtFIPRDIRE.KeyDown, txtFIPRMUNI.KeyDown, txtFIPRCORR.KeyDown, txtFIPRBARR.KeyDown, txtFIPRMANZ.KeyDown, txtFIPRPRED.KeyDown, txtFIPREDIF.KeyDown, txtFIPRUNPR.KeyDown, txtFIPRCLSE.KeyDown, txtFIPRCASU.KeyDown, txtFIPRCAPR.KeyDown, txtFIPRMOAD.KeyDown
        If e.KeyCode = Keys.F8 Then
            cmdEJECUTAR.PerformClick()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtFIPRNUFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRNUFI.GotFocus
        txtFIPRNUFI.SelectionStart = 0
        txtFIPRNUFI.SelectionLength = Len(txtFIPRNUFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRNUFI.AccessibleDescription
    End Sub
    Private Sub txtFIPRDIRE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRDIRE.GotFocus
        txtFIPRDIRE.SelectionStart = 0
        txtFIPRDIRE.SelectionLength = Len(txtFIPRDIRE.Text)
        strBARRESTA.Items(0).Text = txtFIPRDIRE.AccessibleDescription
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
    Private Sub txtFIPRCLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCLSE.GotFocus
        txtFIPRCLSE.SelectionStart = 0
        txtFIPRCLSE.SelectionLength = Len(txtFIPRCLSE.Text)
        strBARRESTA.Items(0).Text = txtFIPRCLSE.AccessibleDescription
    End Sub
    Private Sub txtFIPRCASU_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCASU.GotFocus
        txtFIPRCASU.SelectionStart = 0
        txtFIPRCASU.SelectionLength = Len(txtFIPRCASU.Text)
        strBARRESTA.Items(0).Text = txtFIPRCASU.AccessibleDescription
    End Sub
    Private Sub txtFIPRCAPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCAPR.GotFocus
        txtFIPRCAPR.SelectionStart = 0
        txtFIPRCAPR.SelectionLength = Len(txtFIPRCAPR.Text)
        strBARRESTA.Items(0).Text = txtFIPRCAPR.AccessibleDescription
    End Sub
    Private Sub txtFIPRMOAD_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMOAD.GotFocus
        txtFIPRMOAD.SelectionStart = 0
        txtFIPRMOAD.SelectionLength = Len(txtFIPRMOAD.Text)
        strBARRESTA.Items(0).Text = txtFIPRMOAD.AccessibleDescription
    End Sub


    Private Sub cmdEJECUTAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEJECUTAR.GotFocus
        strBARRESTA.Items(0).Text = cmdEJECUTAR.AccessibleDescription
    End Sub
    Private Sub cmdINSERTAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEJECUTAR.GotFocus
        strBARRESTA.Items(0).Text = cmdEJECUTAR.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboProcesos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProcesos.SelectedIndexChanged

        If Me.cboProcesos.SelectedIndex = 3 Or Me.cboProcesos.SelectedIndex = 4 Then
            Me.chkInsertayActualizaLinderoEnBD.Visible = True
        Else
            Me.chkInsertayActualizaLinderoEnBD.Visible = False
        End If

    End Sub

#End Region

#End Region

End Class