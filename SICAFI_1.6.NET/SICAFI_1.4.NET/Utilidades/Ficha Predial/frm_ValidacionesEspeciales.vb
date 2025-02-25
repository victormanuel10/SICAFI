Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_ValidacionesEspeciales

    '=============================
    '*** VALIDAR FICHA PREDIAL ***
    '=============================

#Region "VARIABLES"

#Region "Conexion"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

    Private dt2 As New DataTable

#End Region

    Dim inProceso As Integer
    Dim inTotalRegistros As Integer
    Dim inNroInconsistencias As Integer
    Dim stSeparador As String

    ' almacena la relación de fichas prediales
    Dim dt_FICHPRED_Municipio As New DataTable
    Dim dt_FIPRPROP_Municipio As New DataTable
    Dim dt_FIPRCONS_Municipio As New DataTable
    Dim dt_FICHPRED_Registro As New DataTable
    Dim dt_PREDREAD As New DataTable

    ' almacena la carga de inconsistencias
    Dim dt_CargaIncoMunicipio As New DataTable
    Dim dt_CargaIncoDepartamento As New DataTable
    Dim dt_CargaIncoMatriculas As New DataTable
    Dim dt_CargaIncoRA As New DataTable
    Dim dt_CargaIncoHomonimos As New DataTable
    Dim dt_CargaImagenConstruccion As New DataTable
    Dim dt_CargaCaracterPropietario As New DataTable

    Dim j As Integer = 0
    Dim i As Integer = 0

    ' variables verificar datos
    Dim stFIPRNUFI As String
    Dim stFIPRMUNI As String
    Dim stFIPRCORR As String
    Dim stFIPRBARR As String
    Dim stFIPRMANZ As String
    Dim stFIPRPRED As String
    Dim stFIPREDIF As String
    Dim stFIPRUNPR As String
    Dim stFIPRCLSE As String
    Dim stFIPRESTA As String
    Dim stFPLIPUCA As String
    Dim stFPLICOLI As String
    Dim stFPLIESTA As String

    Private dt11 As New DataTable

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_ValidacionesEspeciales
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_ValidacionesEspeciales
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
        Me.txtFIPRTIFI.Text = "0"
        Me.txtFIPRMUNI.Text = "%"
        Me.txtFIPRCORR.Text = "%"
        Me.txtFIPRBARR.Text = "%"
        Me.txtFIPRMANZ.Text = "%"
        Me.txtFIPRPRED.Text = "%"
        Me.txtFIPREDIF.Text = "%"
        Me.txtFIPRUNPR.Text = "%"
        Me.txtFIPRCLSE.Text = "%"
        Me.txtFIPRINCO.Text = ""
        Me.strBARRESTA.Items(2).Text = "Registros : 0"
        Me.pbPROCESO.Value = 0

        Me.dgvFIPRINCO.DataSource = New DataTable

    End Sub
    Private Sub pro_VerificarDatos()

        '*** VERIFICA DATOS DE FICHA PREDIAL ***

        If Trim(txtFIPRMUNI.Text) = "" Then
            stFIPRMUNI = "%"
        Else
            stFIPRMUNI = Trim(txtFIPRMUNI.Text)
        End If

        If Trim(txtFIPRCORR.Text) = "" Then
            stFIPRCORR = "%"
        Else
            stFIPRCORR = Trim(txtFIPRCORR.Text)
        End If

        If Trim(txtFIPRBARR.Text) = "" Then
            stFIPRBARR = "%"
        Else
            stFIPRBARR = Trim(txtFIPRBARR.Text)
        End If

        If Trim(txtFIPRMANZ.Text) = "" Then
            stFIPRMANZ = "%"
        Else
            stFIPRMANZ = Trim(txtFIPRMANZ.Text)
        End If

        If Trim(txtFIPRPRED.Text) = "" Then
            stFIPRPRED = "%"
        Else
            stFIPRPRED = Trim(txtFIPRPRED.Text)
        End If

        If Trim(txtFIPREDIF.Text) = "" Then
            stFIPREDIF = "%"
        Else
            stFIPREDIF = Trim(txtFIPREDIF.Text)
        End If

        If Trim(txtFIPRUNPR.Text) = "" Then
            stFIPRUNPR = "%"
        Else
            stFIPRUNPR = Trim(txtFIPRUNPR.Text)
        End If

        If Trim(txtFIPRCLSE.Text) = "" Then
            stFIPRCLSE = "%"
        Else
            stFIPRCLSE = Trim(txtFIPRCLSE.Text)
        End If

    End Sub
    Private Sub pro_ActualizarEdificioFichaResumenDe001a000(ByVal stMunicipio As String, ByVal inSector As String)

        Try

            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stMunicipio)) = False Then
                MessageBox.Show("El campo municipio no es numerico", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                If (Trim(stMunicipio)) = "" Then
                    MessageBox.Show("El campo municipio esta vacio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(inSector)) = False Then
                        MessageBox.Show("El campo sector no es numerico", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    Else
                        If (Trim(inSector)) = "" Then
                            MessageBox.Show("El campo sector esta vacio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        Else

                            ' buscar cadena de conexion
                            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                            ' crear conexión
                            oAdapter = New SqlDataAdapter
                            oConexion = New SqlConnection(stCadenaConexion)

                            ' abre la conexion
                            oConexion.Open()

                            ' variables
                            Dim stFIPRMUNI As String = Trim(stMunicipio)
                            Dim inFIPRCLSE As Integer = inSector

                            ' parametros de la consulta
                            Dim ParametrosConsulta As String = ""

                            ' Concatena la condicion de la consulta
                            ParametrosConsulta += "update FICHPRED "
                            ParametrosConsulta += "set FIPREDIF = '" & "000" & "' "
                            ParametrosConsulta += "where FIPREDIF = '" & "001" & "' AND FIPRTIFI = 2  AND FIPRMUNI = '" & stFIPRMUNI & "' AND FIPRCLSE = '" & inFIPRCLSE & "' AND FIPRESTA = 'ac' "

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

                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ActualizarEdificioFichaResumenDe000a001(ByVal stMunicipio As String, ByVal inSector As String)

        Try

            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stMunicipio)) = False Then
                MessageBox.Show("El campo municipio no es numerico", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                If (Trim(stMunicipio)) = "" Then
                    MessageBox.Show("El campo municipio esta vacio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(inSector)) = False Then
                        MessageBox.Show("El campo sector no es numerico", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    Else
                        If (Trim(inSector)) = "" Then
                            MessageBox.Show("El campo sector esta vacio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        Else

                            ' buscar cadena de conexion
                            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                            ' crear conexión
                            oAdapter = New SqlDataAdapter
                            oConexion = New SqlConnection(stCadenaConexion)

                            ' abre la conexion
                            oConexion.Open()

                            ' variables
                            Dim stFIPRMUNI As String = Trim(stMunicipio)
                            Dim inFIPRCLSE As Integer = inSector

                            ' parametros de la consulta
                            Dim ParametrosConsulta As String = ""

                            ' Concatena la condicion de la consulta
                            ParametrosConsulta += "update FICHPRED "
                            ParametrosConsulta += "set FIPREDIF = '" & "001" & "' "
                            ParametrosConsulta += "where FIPREDIF = '" & "000" & "' AND FIPRTIFI = 2  AND FIPRMUNI = '" & stFIPRMUNI & "' AND FIPRCLSE = '" & inFIPRCLSE & "' AND FIPRESTA = 'ac' "

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

                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EliminarLinderosDuplicados()

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
            pro_VerificarDatos()

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi, "
            ParametrosConsulta += "FiprMuni, "
            ParametrosConsulta += "FiprCorr, "
            ParametrosConsulta += "FiprBarr, "
            ParametrosConsulta += "FiprManz, "
            ParametrosConsulta += "FiprPred, "
            ParametrosConsulta += "FiprEdif, "
            ParametrosConsulta += "FiprUnpr, "
            ParametrosConsulta += "FiprClse  "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & stFIPRMUNI & "' and "
            ParametrosConsulta += "FiprCorr like '" & stFIPRCORR & "' and "
            ParametrosConsulta += "FiprBarr like '" & stFIPRBARR & "' and "
            ParametrosConsulta += "FiprManz like '" & stFIPRMANZ & "' and "
            ParametrosConsulta += "FiprPred like '" & stFIPRPRED & "' and "
            ParametrosConsulta += "FiprEdif like '" & stFIPREDIF & "' and "
            ParametrosConsulta += "FiprUnpr like '" & stFIPRUNPR & "' and "
            ParametrosConsulta += "FiprClse like '" & stFIPRCLSE & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "'  "
            ParametrosConsulta += "Order by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr"

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

            ' cuenta los registros
            If dt.Rows.Count > 0 Then

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                dt1.Columns.Add(New DataColumn("Punto_Cardinal", GetType(String)))
                dt1.Columns.Add(New DataColumn("Lindero", GetType(String)))

                ' delcara la variable
                Dim inRegistrosEliminados As Integer = 0

                ' declara el contador
                Dim i As Integer = 0

                For i = 0 To dt.Rows.Count - 1

                    ' declara la variable
                    Dim inFIPRNUFI As Integer = dt.Rows(i).Item("FIPRNUFI")

                    ' declara la instancia
                    Dim obFIPRLIND As New cla_FIPRLIND
                    Dim dtFIPRLIND As New DataTable

                    dtFIPRLIND = obFIPRLIND.fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(inFIPRNUFI)

                    If dtFIPRLIND.Rows.Count > 0 Then

                        ' declaro el contador
                        Dim ii As Integer = 0

                        For ii = 0 To dtFIPRLIND.Rows.Count - 1

                            Dim inFPLINUFI As Integer = dtFIPRLIND.Rows(ii).Item("FPLINUFI")
                            Dim inFPLIIDRE As Integer = dtFIPRLIND.Rows(ii).Item("FPLIIDRE")
                            Dim stFPLIPUCA As String = Trim(dtFIPRLIND.Rows(ii).Item("FPLIPUCA"))
                            Dim stFPLICOLI As String = Trim(dtFIPRLIND.Rows(ii).Item("FPLICOLI"))

                            ' declara la instancia
                            Dim obFIPRLIND1 As New cla_FIPRLIND
                            Dim dtFIPRLIND1 As New DataTable
                            Dim dtFIPRLIND3 As New DataTable

                            dtFIPRLIND1 = obFIPRLIND1.fun_Buscar_ID_PUCA_COLI_FIPRLIND(inFPLINUFI, inFPLIIDRE, stFPLIPUCA, stFPLICOLI)

                            dtFIPRLIND3 = obFIPRLIND1.fun_Buscar_ID_FIPRLIND(inFPLIIDRE)

                            If dtFIPRLIND1.Rows.Count > 0 And dtFIPRLIND3.Rows.Count > 0 Then

                                ' declaro el contador
                                Dim iii As Integer = 0

                                For iii = 0 To dtFIPRLIND1.Rows.Count - 1

                                    ' declara la variable
                                    Dim inFIPRIDRE1 As Integer = dtFIPRLIND1.Rows(iii).Item("FPLIIDRE")

                                    ' declara la instancia
                                    Dim obFIPRLIND2 As New cla_FIPRLIND

                                    If obFIPRLIND2.fun_Eliminar_FIPRLIND(inFIPRIDRE1) = True Then
                                        inRegistrosEliminados += 1

                                        dr1 = dt1.NewRow()

                                        dr1("Nro_Ficha") = inFPLINUFI
                                        dr1("Punto_Cardinal") = stFPLIPUCA
                                        dr1("Lindero") = stFPLICOLI

                                        dt1.Rows.Add(dr1)

                                    End If

                                Next

                            End If

                        Next

                    End If

                Next

                Me.dgvFIPRINCO.DataSource = dt1

                MessageBox.Show("El proceso termino correctamente, se eliminaron " & inRegistrosEliminados & " registros", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                Me.dgvFIPRINCO.DataSource = New DataTable
                mod_MENSAJE.Consulta_No_Encontro_Registros()
            End If

            ' Numero de registros recuperados
            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRINCO.RowCount.ToString

            Me.dgvFIPRINCO.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_RestaAreaConstruccionUnidadUnoCalculoAutomatico()

        Try
            ' verifica los datos
            pro_VerificarDatos()

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
            ParametrosConsulta += "FiprNufi, "
            ParametrosConsulta += "FiprMuni, "
            ParametrosConsulta += "FiprCorr, "
            ParametrosConsulta += "FiprBarr, "
            ParametrosConsulta += "FiprManz, "
            ParametrosConsulta += "FiprPred, "
            ParametrosConsulta += "FiprClse, "
            ParametrosConsulta += "FiprArte "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(Me.txtFIPRMUNI.Text) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(Me.txtFIPRCORR.Text) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(Me.txtFIPRBARR.Text) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(Me.txtFIPRMANZ.Text) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(Me.txtFIPRPRED.Text) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(Me.txtFIPREDIF.Text) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(Me.txtFIPRUNPR.Text) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(Me.txtFIPRCLSE.Text) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "' and "
            ParametrosConsulta += "FiprTifi = '0' and "
            ParametrosConsulta += "FiprCapr in ('1','5','7') and "
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

            If dt.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dt.Rows.Count - 1

                    Dim inNroFicha As Integer = CInt(dt.Rows(i).Item("FiprNufi").ToString)

                    If fun_VerificaLaCantidadNroDeConstrucciones(inNroFicha) = True And _
                        fun_VerificaLaClaseDeConstruccion(inNroFicha) = True And _
                        fun_VerificaAreaConsMenorAreaTerreno(inNroFicha) = True Then

                        fun_ActualizaAreaConstruccionUnidadUno(inNroFicha)

                    End If

                Next

            Else
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
            End If

            mod_MENSAJE.Proceso_Termino_Correctamente()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListarPredioYConstruccionesMayoresUnPisoConDiferenteTipo()

        Try
            ' limpia los datagrigview
            Me.dgvFIPRINCO.DataSource = New DataTable

            ' verifica los datos
            pro_VerificarDatos()

            ' buscar cadena de conexion
            Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

            ' crea el datatable
            dt11 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion1)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta1 As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta1 += "Select "
            ParametrosConsulta1 += "* "
            ParametrosConsulta1 += "From FichPred where "
            ParametrosConsulta1 += "FiprMuni like '" & stFIPRMUNI & "' and "
            ParametrosConsulta1 += "FiprCorr like '" & stFIPRCORR & "' and "
            ParametrosConsulta1 += "FiprBarr like '" & stFIPRBARR & "' and "
            ParametrosConsulta1 += "FiprManz like '" & stFIPRMANZ & "' and "
            ParametrosConsulta1 += "FiprPred like '" & stFIPRPRED & "' and "
            ParametrosConsulta1 += "FiprEdif like '" & stFIPREDIF & "' and "
            ParametrosConsulta1 += "FiprUnpr like '" & stFIPRUNPR & "' and "
            ParametrosConsulta1 += "FiprClse like '" & stFIPRCLSE & "' and "
            ParametrosConsulta1 += "FiprTifi = '" & "0" & "' and "
            ParametrosConsulta1 += "FiprEsta = '" & "ac" & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt11)

            ' cierra la conexion
            oConexion.Close()

            ' Crea objeto de columnas y registros
            Dim dt1 As New DataTable
            Dim dr1 As DataRow

            ' Crea las columnas
            dt1.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
            dt1.Columns.Add(New DataColumn("Municipio", GetType(String)))
            dt1.Columns.Add(New DataColumn("Corregi", GetType(String)))
            dt1.Columns.Add(New DataColumn("Barrio", GetType(String)))
            dt1.Columns.Add(New DataColumn("Manzana", GetType(String)))
            dt1.Columns.Add(New DataColumn("Predio", GetType(String)))
            dt1.Columns.Add(New DataColumn("Edificio", GetType(String)))
            dt1.Columns.Add(New DataColumn("Unidad", GetType(String)))
            dt1.Columns.Add(New DataColumn("Caract", GetType(String)))
            dt1.Columns.Add(New DataColumn("Sector", GetType(String)))
            dt1.Columns.Add(New DataColumn("Nro_Cons", GetType(String)))
            dt1.Columns.Add(New DataColumn("Ident", GetType(String)))
            dt1.Columns.Add(New DataColumn("Area_Cons", GetType(String)))

            ' verifica los registros
            If dt11.Rows.Count > 0 Then

                ' Valores predeterminados ProgressBar
                inProceso = 0
                pbPROCESO.Value = 0
                pbPROCESO.Maximum = dt11.Rows.Count + 1
                Timer1.Enabled = True

                ' declaro la variable
                Dim i As Integer = 0

                For i = 0 To dt11.Rows.Count - 1

                    ' declaro la variable
                    Dim inFIPRNUFI As Integer = CInt(dt11.Rows(i).Item("FIPRNUFI"))

                    If fun_VerificaLaCantidadNroDeConstrucciones(inFIPRNUFI) = True Then
                        If fun_VerificaLaConstruccionDeDiferenteTipo(inFIPRNUFI) = True Then

                            Dim obFIPRCONS As New cla_FIPRCONS
                            Dim dtFIPRCONS As New DataTable

                            dtFIPRCONS = obFIPRCONS.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(inFIPRNUFI)

                            If dtFIPRCONS.Rows.Count > 0 Then

                                Dim ii As Integer = 0

                                For ii = 0 To dtFIPRCONS.Rows.Count - 1

                                    dr1 = dt1.NewRow()

                                    dr1("Nro_Ficha") = Trim(dt11.Rows(i).Item("FIPRNUFI").ToString)
                                    dr1("Municipio") = Trim(dt11.Rows(i).Item("FIPRMUNI").ToString)
                                    dr1("Corregi") = Trim(dt11.Rows(i).Item("FIPRCORR").ToString)
                                    dr1("Barrio") = Trim(dt11.Rows(i).Item("FIPRBARR").ToString)
                                    dr1("Manzana") = Trim(dt11.Rows(i).Item("FIPRMANZ").ToString)
                                    dr1("Predio") = Trim(dt11.Rows(i).Item("FIPRPRED").ToString)
                                    dr1("Edificio") = Trim(dt11.Rows(i).Item("FIPREDIF").ToString)
                                    dr1("Unidad") = Trim(dt11.Rows(i).Item("FIPRUNPR").ToString)
                                    dr1("Caract") = Trim(dt11.Rows(i).Item("FIPRCAPR").ToString)
                                    dr1("Sector") = Trim(dt11.Rows(i).Item("FIPRCLSE").ToString)
                                    dr1("Nro_Cons") = Trim(dtFIPRCONS.Rows(ii).Item("FPCOUNID").ToString)
                                    dr1("Ident") = Trim(dtFIPRCONS.Rows(ii).Item("FPCOTICO").ToString)
                                    dr1("Area_Cons") = Trim(dtFIPRCONS.Rows(ii).Item("FPCOARCO").ToString)

                                    dt1.Rows.Add(dr1)

                                Next

                            End If

                        End If

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbPROCESO.Value = inProceso

                Next

            End If

            ' Llena el datagrigview
            Me.dgvFIPRINCO.DataSource = dt1
            pbPROCESO.Value = 0

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_ObtenerNroFicha(ByVal stCadena As String) As String

        Try
            Dim stResultado As String = ""

            Dim inTamano As Integer = stCadena.ToString.Length

            Dim sw1 As Byte = 0
            Dim j1 As Integer = 0

            While j1 < stCadena.ToString.Length And sw1 = 0

                If fun_Verificar_Dato_Numerico_Evento_Validated(stCadena.ToString.Substring(j1, 1)) = True Then
                    stResultado += stCadena.ToString.Substring(j1, 1)
                    j1 = j1 + 1
                Else
                    sw1 = 1
                End If

            End While

            Return stResultado

        Catch ex As Exception
            Return ""
        End Try

    End Function
    Private Function fun_ObtenerNroConstruccion(ByVal stCadena As String) As String

        Try
            Dim stResultado As String = ""
            Dim stNroFicha As String = ""
            Dim boMejora As Boolean = False

            Dim inTamano As Integer = stCadena.ToString.Length

            Dim sw1 As Byte = 0
            Dim j1 As Integer = 0
            Dim inContador As Integer = 0

            While j1 < stCadena.ToString.Length And sw1 = 0

                If fun_Verificar_Dato_Numerico_Evento_Validated(stCadena.ToString.Substring(j1, 1)) = True Then
                    stNroFicha += stCadena.ToString.Substring(j1, 1)

                    j1 = j1 + 1

                ElseIf stCadena.ToString.Substring(j1, 1) = "-" Or stCadena.ToString.Substring(j1, 1) = "_" Then

                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stNroFicha)) = True Then

                        Dim obFIPRCONS As New cla_FIPRCONS
                        Dim dtFIPRCONS As New DataTable

                        dtFIPRCONS = obFIPRCONS.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(Trim(stNroFicha))

                        If dtFIPRCONS.Rows.Count > 0 Then

                            Dim i As Integer = 0

                            For i = 0 To dtFIPRCONS.Rows.Count - 1

                                boMejora = dtFIPRCONS.Rows(i).Item("FPCOMEJO")

                            Next

                        End If

                    End If

                    If boMejora = False Then
                        stResultado += stCadena.ToString.Substring((j1 + 1), 1)

                    ElseIf boMejora = True Then
                        stResultado += stCadena.ToString.Substring((j1 + 1), 4)

                    End If

                    sw1 = 1

                Else
                    j1 = j1 + 1
                End If

            End While

            Return stResultado

        Catch ex As Exception
            Return ""
        End Try

    End Function
    Private Function fun_ObtenerNroFoto(ByVal stCadena As String) As String

        Try
            Dim stResultado As String = ""

            Dim inTamano As Integer = stCadena.ToString.Length

            Dim sw1 As Byte = 0
            Dim j1 As Integer = 0
            Dim inContador As Integer = 0

            While j1 < stCadena.ToString.Length And sw1 = 0

                If stCadena.ToString.Substring(j1, 1) = "-" Or stCadena.ToString.Substring(j1, 1) = "_" Then
                    inContador += 1
                    j1 = j1 + 1
                Else
                    j1 = j1 + 1
                    If inContador = 2 Then
                        stResultado += stCadena.ToString.Substring((j1 - 1), 1)
                        sw1 = 1

                    End If
                End If

            End While

            Return stResultado

        Catch ex As Exception
            Return ""
        End Try

    End Function
    Private Function fun_CorregirSaltoDeCarrilObservacionFichaPredial(ByVal stCadena As String) As String

        Try
            Dim stContenido As String = ""
          
            stContenido = Replace(Replace(stCadena, Chr(10), " "), Chr(13), " ")

            Return stContenido

        Catch ex As Exception
            Return ""
        End Try

    End Function
    Private Function fun_VerificarCaracterEspecial(ByVal stDato As String) As Boolean

        Try
            Dim boResultado As Boolean = False
            Dim inCantidad As Integer = Trim(stDato.ToString.Length)

            Dim y As Integer = 0
            Dim bySW As Byte = 0

            For y = 0 To inCantidad - 1

                Dim SW As Byte = 0

                Dim stLetra As String = stDato.ToString.Substring(y, 1)

                If stLetra = "'" Then
                    SW = 1
                End If

                ' existen caracteres
                If SW = 1 And bySW = 0 Then
                    boResultado = True
                    bySW = 1
                End If

            Next

            Return boResultado

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_CambiarLetraDeLaPlanchaCartografica(ByVal stPlancha As String, ByVal stPlanchaGrafica As String) As String

        Try
            Dim stPlanchaCartografica As String = Trim(stPlancha)
            Dim stPlachaCorregida As String = stPlanchaCartografica

            If Trim(stPlanchaCartografica) <> "" And Trim(stPlanchaGrafica) = "1:5000" Then

                Dim inCantidadLetras As Integer = CInt(stPlancha.ToString.Length)

                If inCantidadLetras > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To inCantidadLetras - 1

                        If i = inCantidadLetras - 1 Then

                            Dim stLetra As String = stPlanchaCartografica.ToString.Substring(i, 1)

                            If fun_Verificar_Dato_Numerico_Evento_Validated(stLetra) = False Then

                                stPlachaCorregida = stPlanchaCartografica.ToString.Substring(0, i - 1) & "-" & stLetra.ToString.ToLower

                            End If

                        End If

                    Next

                End If

            End If

            Return stPlachaCorregida

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ActualizaPlanchaCartografica(ByVal inIdregistros As Integer, _
                                                      ByVal stPlancha As String) As Boolean

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
            ParametrosConsulta += "update FIPRCART "
            ParametrosConsulta += "set FPCAPLAN = '" & CStr(Trim(stPlancha)) & "' "
            ParametrosConsulta += "where "
            ParametrosConsulta += "FPCAIDRE = '" & CInt(inIdregistros) & "' "

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

    Private Function fun_VerificaLaCantidadNroDeConstrucciones(ByVal inFIPRNUFI) As Boolean

        Try
            Dim boResultado As Boolean = False

            Dim obFIPRCONS As New cla_FIPRCONS
            Dim dtFIPRCONS As New DataTable

            dtFIPRCONS = obFIPRCONS.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(inFIPRNUFI)

            If dtFIPRCONS.Rows.Count > 1 Then

                boResultado = True

            End If

            Return boResultado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_VerificaLaConstruccionDeDiferenteTipo(ByVal inFIPRNUFI) As Boolean

        Try
            Dim boResultado As Boolean = False
            Dim inContadorR As Integer = 0
            Dim inContadorC As Integer = 0
            Dim inContadorI As Integer = 0

            Dim obFIPRCONS As New cla_FIPRCONS
            Dim dtFIPRCONS As New DataTable

            dtFIPRCONS = obFIPRCONS.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(inFIPRNUFI)

            If dtFIPRCONS.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dtFIPRCONS.Rows.Count - 1

                    Dim stDepartamento As String = CStr(dtFIPRCONS.Rows(i).Item("FPCODEPA"))
                    Dim stMunicipio As String = CStr(dtFIPRCONS.Rows(i).Item("FPCOMUNI"))
                    Dim stClase As String = CStr(dtFIPRCONS.Rows(i).Item("FPCOCLCO"))
                    Dim stIdentificador As String = CStr(dtFIPRCONS.Rows(i).Item("FPCOTICO"))
                    Dim stSector As String = CStr(dtFIPRCONS.Rows(i).Item("FPCOCLSE"))

                    Dim obTIPOCONS As New cla_TIPOCONS
                    Dim dtTIPOCONS As New DataTable

                    dtTIPOCONS = obTIPOCONS.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(stDepartamento, stMunicipio, stClase, stSector, stIdentificador)

                    If dtTIPOCONS.Rows.Count > 0 Then

                        ' declaro la variable
                        Dim stTipo As String = CStr(dtTIPOCONS.Rows(0).Item("TICOTIPO"))

                        If Trim(stTipo) = "R" Then
                            inContadorR += 1

                        ElseIf Trim(stTipo) = "C" Then
                            inContadorC += 1

                        ElseIf Trim(stTipo) = "I" Then
                            inContadorI += 1

                        End If

                    End If

                Next

                If inContadorR >= 1 Then
                    If inContadorC >= 1 Then
                        boResultado = True
                    End If
                End If


                If inContadorR >= 1 Then
                    If inContadorI >= 1 Then
                        boResultado = True
                    End If
                End If

                If inContadorC >= 1 Then
                    If inContadorI >= 1 Then
                        boResultado = True
                    End If
                End If

            End If

            Return boResultado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_VerificaLaClaseDeConstruccion(ByVal inFIPRNUFI) As Boolean

        Try
            Dim boResultado As Boolean = True

            Dim obFIPRCONS As New cla_FIPRCONS
            Dim dtFIPRCONS As New DataTable

            dtFIPRCONS = obFIPRCONS.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(inFIPRNUFI)

            If dtFIPRCONS.Rows.Count > 1 Then

                Dim sw1 As Byte = 0
                Dim j1 As Integer = 0

                While j1 < dtFIPRCONS.Rows.Count And sw1 = 0

                    If dtFIPRCONS.Rows(j1).Item("FPCOCLCO") <> 1 Then

                        sw1 = 1
                        boResultado = False
                    Else
                        j1 = j1 + 1
                    End If

                End While

            End If

            Return boResultado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_VerificaAreaConsMenorAreaTerreno(ByVal inFIPRNUFI) As Boolean

        Try
            Dim boResultado As Boolean = False
            Dim inAreaTerreno As Integer = 0
            Dim inAreaConstruccion As Integer = 0
            Dim inTotalAreaConstruccion As Integer = 0
            Dim inTotalPisosConstruccion As Integer = 0

            Dim obFICHPRED As New cla_FICHPRED
            Dim dtFICHPRED As New DataTable

            dtFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(inFIPRNUFI)

            If dtFICHPRED.Rows.Count > 0 Then

                inAreaTerreno = CInt(dtFICHPRED.Rows(0).Item("FIPRARTE").ToString)

                Dim obFIPRCONS As New cla_FIPRCONS
                Dim dtFIPRCONS As New DataTable

                dtFIPRCONS = obFIPRCONS.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(inFIPRNUFI)

                If dtFIPRCONS.Rows.Count > 1 Then

                    Dim i As Integer = 0

                    For i = 0 To dtFIPRCONS.Rows.Count - 1

                        inTotalAreaConstruccion += CInt(dtFIPRCONS.Rows(i).Item("FPCOARCO").ToString)
                        inTotalPisosConstruccion += CInt(dtFIPRCONS.Rows(i).Item("FPCOPISO").ToString)

                    Next

                    If inTotalPisosConstruccion <> 0 Then

                        ' inAreaConstruccion = (inTotalAreaConstruccion / inTotalPisosConstruccion)

                        If inTotalAreaConstruccion > inAreaTerreno Then

                            boResultado = True

                        End If

                    Else
                        boResultado = False

                    End If

                End If

            End If

            Return boResultado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_SumatoriaDeAreasConsMayorUnidadUno(ByVal inFIPRNUFI As Integer) As Double

        Try
            Dim doTotalAreaConstruccion As Double = 0

            Dim obFIPRCONS As New cla_FIPRCONS
            Dim dtFIPRCONS As New DataTable

            dtFIPRCONS = obFIPRCONS.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(inFIPRNUFI)

            If dtFIPRCONS.Rows.Count > 1 Then

                Dim i As Integer = 0

                For i = 0 To dtFIPRCONS.Rows.Count - 1

                    If CInt(dtFIPRCONS.Rows(i).Item("FPCOUNID").ToString) <> 1 Then

                        doTotalAreaConstruccion += CInt(dtFIPRCONS.Rows(i).Item("FPCOARCO").ToString)

                    End If

                Next

            End If

            Return doTotalAreaConstruccion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ActualizaAreaConstruccionUnidadUno(ByVal inFIPRNUFI As Integer) As Boolean

        Try
            Dim doSumatoriaAreas As Double = fun_SumatoriaDeAreasConsMayorUnidadUno(inFIPRNUFI)
            Dim doAreaConsUnidadUno As Double = 0

            Dim obFIPRCONS As New cla_FIPRCONS
            Dim dtFIPRCONS As New DataTable

            dtFIPRCONS = obFIPRCONS.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(inFIPRNUFI)

            If dtFIPRCONS.Rows.Count > 0 Then

                Dim ii As Integer = 0

                For ii = 0 To dtFIPRCONS.Rows.Count - 1

                    If CInt(dtFIPRCONS.Rows(ii).Item("FPCOUNID").ToString) = 1 Then
                        doAreaConsUnidadUno = CDbl(dtFIPRCONS.Rows(ii).Item("FPCOARCO").ToString)
                    End If

                Next

                If doAreaConsUnidadUno > doSumatoriaAreas Then

                    Dim stAreaDefinitiva As String = (doAreaConsUnidadUno - doSumatoriaAreas)
                    stAreaDefinitiva = fun_Formato_Decimal_2_Decimales(stAreaDefinitiva)

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
                    ParametrosConsulta += "update FIPRCONS "
                    ParametrosConsulta += "set FPCOARCO = '" & stAreaDefinitiva & "' "
                    ParametrosConsulta += "where FPCONUFI = '" & inFIPRNUFI & "' AND FPCOUNID = 1 AND FPCOESTA = 'ac' "

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

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "MENU"

    Private Sub cmdVALIDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVALIDAR.Click

        Try
            ' valores predeterminados
            Me.txtFIPRINCO.Text = ""
            Me.cmdVALIDAR.Enabled = False
            inNroInconsistencias = 0

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
            ParametrosConsulta += "FiprNufi, "
            ParametrosConsulta += "FiprDepa, "
            ParametrosConsulta += "FiprMuni, "
            ParametrosConsulta += "FiprCorr, "
            ParametrosConsulta += "FiprBarr, "
            ParametrosConsulta += "FiprManz, "
            ParametrosConsulta += "FiprPred, "
            ParametrosConsulta += "FiprEdif, "
            ParametrosConsulta += "FiprUnpr, "
            ParametrosConsulta += "FiprClse, "
            ParametrosConsulta += "FiprArte, "
            ParametrosConsulta += "FiprTifi, "
            ParametrosConsulta += "FiprObse "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(Me.txtFIPRMUNI.Text) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(Me.txtFIPRCORR.Text) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(Me.txtFIPRBARR.Text) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(Me.txtFIPRMANZ.Text) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(Me.txtFIPRPRED.Text) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(Me.txtFIPREDIF.Text) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(Me.txtFIPRUNPR.Text) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(Me.txtFIPRCLSE.Text) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(Me.txtFIPRTIFI.Text) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(Me.txtFIPRFIIN.Text) & "' and '" & Trim(Me.txtFIPRFIFI.Text) & "' and "
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

                ' Total de registros
                inTotalRegistros = dt.Rows.Count

                If Me.chkProcesos.Checked = False Then

                    '=========================================================
                    ' *** VERIFICA LOS HOMONIMOS POR NOMBRE DE PROPIETARIO ***
                    '=========================================================
                    If Me.rbdHomonimosNombre.Checked = True Then

                        ' Valores predeterminados ProgressBar
                        inProceso = 0
                        pbPROCESO.Value = 0
                        pbPROCESO.Maximum = dt.Rows.Count
                        Timer1.Enabled = True

                        ' instancia la tabla
                        dt_CargaIncoMatriculas = New DataTable

                        ' Crea las columnas
                        dt_CargaIncoMatriculas.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                        dt_CargaIncoMatriculas.Columns.Add(New DataColumn("Cedula_catastral", GetType(String)))
                        dt_CargaIncoMatriculas.Columns.Add(New DataColumn("Tipo_Docu", GetType(String)))
                        dt_CargaIncoMatriculas.Columns.Add(New DataColumn("Nro_Documento", GetType(String)))
                        dt_CargaIncoMatriculas.Columns.Add(New DataColumn("Nombre", GetType(String)))
                        dt_CargaIncoMatriculas.Columns.Add(New DataColumn("Primer_Apellido", GetType(String)))
                        dt_CargaIncoMatriculas.Columns.Add(New DataColumn("Segundo_Apellido", GetType(String)))

                        ' crea el datarow
                        Dim dr1 As DataRow

                        ' declara la variable
                        Dim inFicha As Integer = 0

                        ' limpia la variable
                        i = 0

                        For i = 0 To dt.Rows.Count - 1

                            ' crea la variable para validar individualmente
                            inFicha = dt.Rows(i).Item("FIPRNUFI")

                            'instancia la clase
                            Dim objdatos35 As New cla_FIPRPROP
                            dt_FIPRPROP_Municipio = New DataTable

                            ' Consulta las matriculas por ficha predial
                            dt_FIPRPROP_Municipio = objdatos35.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(inFicha)

                            ' verifica que existan registros
                            If dt_FIPRPROP_Municipio.Rows.Count > 0 Then

                                ' declara la variable
                                Dim d As Integer = 0

                                For d = 0 To dt_FIPRPROP_Municipio.Rows.Count - 1

                                    ' declara la variable y almacena los nombre y apellidos
                                    Dim stTipoDocumento As String = Trim(dt_FIPRPROP_Municipio.Rows(d).Item("FPPRTIDO"))
                                    Dim stNroDcumento As String = Trim(dt_FIPRPROP_Municipio.Rows(d).Item("FPPRNUDO"))
                                    Dim stNombre As String = Trim(dt_FIPRPROP_Municipio.Rows(d).Item("FPPRNOMB"))
                                    Dim stPrimerApellido As String = Trim(dt_FIPRPROP_Municipio.Rows(d).Item("FPPRPRAP"))
                                    Dim stSegundoApellido As String = Trim(dt_FIPRPROP_Municipio.Rows(d).Item("FPPRSEAP"))

                                    If Trim(stNroDcumento) <> "" Then

                                        ' buscar cadena de conexion
                                        Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                                        Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

                                        ' crea el datatable
                                        Dim dt1 As New DataTable

                                        ' crear conexión
                                        oAdapter = New SqlDataAdapter
                                        oConexion = New SqlConnection(stCadenaConexion1)

                                        ' abre la conexion
                                        oConexion.Open()

                                        ' parametros de la consulta
                                        Dim ParametrosConsulta1 As String = ""

                                        ' Concatena la condicion de la consulta
                                        ParametrosConsulta1 += "Select "
                                        ParametrosConsulta1 += "Fiprnufi, "
                                        ParametrosConsulta1 += "FiprClse, "
                                        ParametrosConsulta1 += "FiprMuni, "
                                        ParametrosConsulta1 += "FiprCorr, "
                                        ParametrosConsulta1 += "FiprBarr, "
                                        ParametrosConsulta1 += "FiprManz, "
                                        ParametrosConsulta1 += "FiprPred, "
                                        ParametrosConsulta1 += "FiprEdif, "
                                        ParametrosConsulta1 += "FiprUnpr, "
                                        ParametrosConsulta1 += "FiprCeca, "
                                        ParametrosConsulta1 += "FpprTido, "
                                        ParametrosConsulta1 += "FpprNudo, "
                                        ParametrosConsulta1 += "FpprNomb, "
                                        ParametrosConsulta1 += "FpprPrap, "
                                        ParametrosConsulta1 += "FpprSeap, "
                                        ParametrosConsulta1 += "FpprTomo, "
                                        ParametrosConsulta1 += "FpprMain "
                                        ParametrosConsulta1 += "From FichPred, FiprProp where FiprNufi = FpprNufi and "
                                        ParametrosConsulta1 += "FpprNomb = '" & Trim(stNombre) & "' and "
                                        ParametrosConsulta1 += "FpprPrap = '" & Trim(stPrimerApellido) & "' and "
                                        ParametrosConsulta1 += "FpprSeap = '" & Trim(stSegundoApellido) & "' and "
                                        ParametrosConsulta1 += "FiprMuni = '" & Trim(dt.Rows(i).Item("FIPRMUNI")) & "' and "
                                        ParametrosConsulta1 += "FiprClse = '" & Trim(dt.Rows(i).Item("FIPRCLSE")) & "' and "
                                        ParametrosConsulta1 += "FiprTifi = '" & Trim(dt.Rows(i).Item("FIPRTIFI")) & "' and "
                                        ParametrosConsulta1 += "FiprEsta = 'ac' and "
                                        ParametrosConsulta1 += "FpprEsta = 'ac' "

                                        ' ejecuta la consulta
                                        oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

                                        ' procesa la consulta 
                                        oEjecutar.CommandTimeout = 360
                                        oEjecutar.CommandType = CommandType.Text
                                        oAdapter.SelectCommand = oEjecutar

                                        ' llena el datatable 
                                        oAdapter.Fill(dt1)

                                        ' cierra la conexion
                                        oConexion.Close()

                                        ' verifica que existan mas fichas con la misma matricula
                                        If dt1.Rows.Count > 0 Then

                                            ' declara la variable
                                            Dim inContadorRegistro As Integer = 0
                                            Dim y As Integer = 0

                                            For y = 0 To dt1.Rows.Count - 1

                                                If Trim(dt1.Rows(y).Item("FIPRNUFI")) <> CInt(inFicha) Then
                                                    If Trim(stNombre) = Trim(dt1.Rows(y).Item("FPPRNOMB")) And _
                                                       Trim(stPrimerApellido) = Trim(dt1.Rows(y).Item("FPPRPRAP")) And _
                                                       Trim(stSegundoApellido) = Trim(dt1.Rows(y).Item("FPPRSEAP")) Then

                                                        If Trim(stNroDcumento) <> Trim(dt1.Rows(y).Item("FPPRNUDO")) Then
                                                            inContadorRegistro = inContadorRegistro + 1
                                                        End If

                                                    End If
                                                End If

                                            Next

                                            ' verifica el contador
                                            If inContadorRegistro > 0 Then

                                                ' declara la variable
                                                Dim k As Integer = 0

                                                ' Recorro la tabla del municipio
                                                For k = 0 To dt1.Rows.Count - 1

                                                    ' declaración de variables
                                                    Dim stFIPRNUFI As String = ""
                                                    Dim stFIPRCLSE As String = ""
                                                    Dim stFIPRMUNI As String = ""
                                                    Dim stFIPRCORR As String = ""
                                                    Dim stFIPRBARR As String = ""
                                                    Dim stFIPRMANZ As String = ""
                                                    Dim stFIPRPRED As String = ""
                                                    Dim stFIPREDIF As String = ""
                                                    Dim stFIPRUNPR As String = ""
                                                    Dim stFIPRCECA As String = ""
                                                    Dim stFPPRTIDO As String = ""
                                                    Dim stFPPRNUDO As String = ""
                                                    Dim stFPPRNOMB As String = ""
                                                    Dim stFPPRPRAP As String = ""
                                                    Dim stFPPRSEAP As String = ""
                                                    Dim stFPPRTOMO As String = ""
                                                    Dim stFPPRMAIN As String = ""

                                                    stFIPRNUFI = Trim(dt1.Rows(k).Item("FIPRNUFI"))
                                                    stFIPRMUNI = Trim(dt1.Rows(k).Item("FIPRMUNI"))
                                                    stFIPRCLSE = Trim(dt1.Rows(k).Item("FIPRCLSE"))
                                                    stFIPRCORR = Trim(dt1.Rows(k).Item("FIPRCORR"))
                                                    stFIPRBARR = Trim(dt1.Rows(k).Item("FIPRBARR"))
                                                    stFIPRMANZ = Trim(dt1.Rows(k).Item("FIPRMANZ"))
                                                    stFIPRPRED = Trim(dt1.Rows(k).Item("FIPRPRED"))
                                                    stFIPREDIF = Trim(dt1.Rows(k).Item("FIPREDIF"))
                                                    stFIPRUNPR = Trim(dt1.Rows(k).Item("FIPRUNPR"))
                                                    stFPPRTIDO = Trim(dt1.Rows(k).Item("FPPRTIDO"))
                                                    stFPPRNUDO = Trim(dt1.Rows(k).Item("FPPRNUDO"))
                                                    stFPPRNOMB = Trim(dt1.Rows(k).Item("FPPRNOMB"))
                                                    stFPPRPRAP = Trim(dt1.Rows(k).Item("FPPRPRAP"))
                                                    stFPPRSEAP = Trim(dt1.Rows(k).Item("FPPRSEAP"))

                                                    stFIPRCECA = stFIPRMUNI & "-" & stFIPRCLSE & "-" & stFIPRCORR & "-" & stFIPRBARR & "-" & stFIPRMANZ & "-" & stFIPRPRED & "-" & stFIPREDIF & "-" & stFIPRUNPR

                                                    ' almacena la inconsistencia 
                                                    dr1 = dt_CargaIncoMatriculas.NewRow()

                                                    dr1("Nro_Ficha") = stFIPRNUFI
                                                    dr1("Cedula_catastral") = stFIPRCECA
                                                    dr1("Tipo_Docu") = stFPPRTIDO
                                                    dr1("Nro_Documento") = stFPPRNUDO
                                                    dr1("Nombre") = stFPPRNOMB
                                                    dr1("Primer_Apellido") = stFPPRPRAP
                                                    dr1("Segundo_Apellido") = stFPPRSEAP

                                                    dt_CargaIncoMatriculas.Rows.Add(dr1)

                                                Next

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

                        ' verifica el resultado
                        If dt_CargaIncoMatriculas.Rows.Count > 0 Then

                            ' Llena el datagrigview
                            Me.dgvFIPRINCO.DataSource = dt_CargaIncoMatriculas

                            MessageBox.Show("Existen inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        Else
                            ' limpia el datagrid
                            Me.dgvFIPRINCO.DataSource = New DataTable

                            MessageBox.Show("Cruce sin inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If


                        '===============================================
                        ' *** VERIFICA LAS MATRICULAS INMOBILIARIAS ***
                        '===============================================
                    ElseIf Me.rbdMatriculas.Checked = True Then

                        ' Valores predeterminados ProgressBar
                        inProceso = 0
                        pbPROCESO.Value = 0
                        pbPROCESO.Maximum = dt.Rows.Count
                        Timer1.Enabled = True

                        ' instancia la tabla
                        dt_CargaIncoMatriculas = New DataTable

                        ' Crea las columnas
                        dt_CargaIncoMatriculas.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                        dt_CargaIncoMatriculas.Columns.Add(New DataColumn("Cedula_catastral", GetType(String)))
                        dt_CargaIncoMatriculas.Columns.Add(New DataColumn("Tomo", GetType(String)))
                        dt_CargaIncoMatriculas.Columns.Add(New DataColumn("Matricula", GetType(String)))

                        ' crea el datarow
                        Dim dr1 As DataRow

                        ' declara la variable
                        Dim inFicha As Integer = 0

                        ' Recorre el rango asignado
                        Dim i As Integer

                        For i = 0 To dt.Rows.Count - 1

                            ' crea la variable para validar individualmente
                            inFicha = dt.Rows(i).Item("FIPRNUFI")

                            'instancia la clase
                            Dim objdatos35 As New cla_FIPRPROP
                            dt_FIPRPROP_Municipio = New DataTable

                            ' Consulta las matriculas por ficha predial
                            dt_FIPRPROP_Municipio = objdatos35.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(inFicha)

                            ' verifica que existan registros
                            If dt_FIPRPROP_Municipio.Rows.Count > 0 Then

                                ' declara la variable y almacena la matricula
                                Dim stMatricula As String = Trim(dt_FIPRPROP_Municipio.Rows(0).Item("FPPRMAIN").ToString)

                                If Trim(stMatricula) <> "" Then

                                    ' buscar cadena de conexion
                                    Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                                    Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

                                    ' crea el datatable
                                    Dim dt1 As New DataTable

                                    ' crear conexión
                                    oAdapter = New SqlDataAdapter
                                    oConexion = New SqlConnection(stCadenaConexion1)

                                    ' abre la conexion
                                    oConexion.Open()

                                    ' parametros de la consulta
                                    Dim ParametrosConsulta1 As String = ""

                                    ' Concatena la condicion de la consulta
                                    ParametrosConsulta1 += "Select "
                                    ParametrosConsulta1 += "Fiprnufi, "
                                    ParametrosConsulta1 += "FiprClse, "
                                    ParametrosConsulta1 += "FiprMuni, "
                                    ParametrosConsulta1 += "FiprCorr, "
                                    ParametrosConsulta1 += "FiprBarr, "
                                    ParametrosConsulta1 += "FiprManz, "
                                    ParametrosConsulta1 += "FiprPred, "
                                    ParametrosConsulta1 += "FiprEdif, "
                                    ParametrosConsulta1 += "FiprUnpr, "
                                    ParametrosConsulta1 += "FiprCeca, "
                                    ParametrosConsulta1 += "FpprNudo, "
                                    ParametrosConsulta1 += "FpprNomb, "
                                    ParametrosConsulta1 += "FpprPrap, "
                                    ParametrosConsulta1 += "FpprSeap, "
                                    ParametrosConsulta1 += "FpprTomo, "
                                    ParametrosConsulta1 += "FpprMain "
                                    ParametrosConsulta1 += "From FichPred, FiprProp where FiprNufi = FpprNufi and "
                                    ParametrosConsulta1 += "FpprMain = '" & Trim(stMatricula) & "' and "
                                    ParametrosConsulta1 += "FiprMuni = '" & Trim(dt.Rows(i).Item("FIPRMUNI")) & "' and "
                                    ParametrosConsulta1 += "FiprClse = '" & Trim(dt.Rows(i).Item("FIPRCLSE")) & "' and "
                                    ParametrosConsulta1 += "FiprTifi = '" & Trim(dt.Rows(i).Item("FIPRTIFI")) & "' and "
                                    ParametrosConsulta1 += "FiprEsta = 'ac' and "
                                    ParametrosConsulta1 += "FpprEsta = 'ac' "

                                    ' ejecuta la consulta
                                    oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

                                    ' procesa la consulta 
                                    oEjecutar.CommandTimeout = 0
                                    oEjecutar.CommandType = CommandType.Text
                                    oAdapter.SelectCommand = oEjecutar

                                    ' llena el datatable 
                                    oAdapter.Fill(dt1)

                                    ' cierra la conexion
                                    oConexion.Close()

                                    ' verifica que existan mas fichas con la misma matricula
                                    If dt1.Rows.Count > 0 Then

                                        ' declara la variable
                                        Dim inContadorRegistro As Integer = 0
                                        Dim y As Integer = 0

                                        For y = 0 To dt1.Rows.Count - 1

                                            If Trim(dt1.Rows(y).Item("FIPRNUFI").ToString) <> CInt(inFicha) Then
                                                inContadorRegistro = inContadorRegistro + 1
                                            End If

                                        Next

                                        ' verifica el contador
                                        If inContadorRegistro > 0 Then

                                            ' declara la variable
                                            Dim k As Integer = 0

                                            ' Recorro la tabla del municipio
                                            For k = 0 To dt1.Rows.Count - 1

                                                ' declaración de variables
                                                Dim stFIPRNUFI As String = ""
                                                Dim stFIPRCLSE As String = ""
                                                Dim stFIPRMUNI As String = ""
                                                Dim stFIPRCORR As String = ""
                                                Dim stFIPRBARR As String = ""
                                                Dim stFIPRMANZ As String = ""
                                                Dim stFIPRPRED As String = ""
                                                Dim stFIPREDIF As String = ""
                                                Dim stFIPRUNPR As String = ""
                                                Dim stFIPRCECA As String = ""
                                                Dim stFIPRNUDO As String = ""
                                                Dim stFIPRNOMB As String = ""
                                                Dim stFIPRPRAP As String = ""
                                                Dim stFIPRSEAP As String = ""
                                                Dim stFPPRTOMO As String = ""
                                                Dim stFPPRMAIN As String = ""

                                                stFIPRNUFI = Trim(dt1.Rows(k).Item("FIPRNUFI"))
                                                stFIPRMUNI = Trim(dt1.Rows(k).Item("FIPRMUNI"))
                                                stFIPRCLSE = Trim(dt1.Rows(k).Item("FIPRCLSE"))
                                                stFIPRCORR = Trim(dt1.Rows(k).Item("FIPRCORR"))
                                                stFIPRBARR = Trim(dt1.Rows(k).Item("FIPRBARR"))
                                                stFIPRMANZ = Trim(dt1.Rows(k).Item("FIPRMANZ"))
                                                stFIPRPRED = Trim(dt1.Rows(k).Item("FIPRPRED"))
                                                stFIPREDIF = Trim(dt1.Rows(k).Item("FIPREDIF"))
                                                stFIPRUNPR = Trim(dt1.Rows(k).Item("FIPRUNPR"))
                                                stFPPRTOMO = Trim(dt1.Rows(k).Item("FPPRTOMO"))
                                                stFPPRMAIN = Trim(dt1.Rows(k).Item("FPPRMAIN"))

                                                stFIPRCECA = stFIPRMUNI & "-" & stFIPRCLSE & "-" & stFIPRCORR & "-" & stFIPRBARR & "-" & stFIPRMANZ & "-" & stFIPRPRED & "-" & stFIPREDIF & "-" & stFIPRUNPR

                                                ' almacena la inconsistencia 
                                                dr1 = dt_CargaIncoMatriculas.NewRow()

                                                dr1("Nro_Ficha") = stFIPRNUFI
                                                dr1("Cedula_catastral") = stFIPRCECA
                                                dr1("Tomo") = stFPPRTOMO
                                                dr1("Matricula") = stFPPRMAIN

                                                dt_CargaIncoMatriculas.Rows.Add(dr1)

                                            Next


                                        End If
                                    End If
                                End If
                            End If

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbPROCESO.Value = inProceso

                        Next

                        ' inicia la barra de progreso
                        pbPROCESO.Value = 0

                        ' verifica el resultado
                        If dt_CargaIncoMatriculas.Rows.Count > 0 Then

                            ' Llena el datagrigview
                            Me.dgvFIPRINCO.DataSource = dt_CargaIncoMatriculas

                            MessageBox.Show("Existen inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        Else
                            ' limpia el datagrid
                            Me.dgvFIPRINCO.DataSource = New DataTable

                            MessageBox.Show("Cruce sin inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If

                        '=========================================================
                        ' *** VERIFICA LOS HOMONIMOS POR CEDULA DE PROPIETARIO ***
                        '=========================================================
                    ElseIf Me.rbdHomonimoCedula.Checked = True Then

                        ' Valores predeterminados ProgressBar
                        inProceso = 0
                        pbPROCESO.Value = 0
                        pbPROCESO.Maximum = dt.Rows.Count
                        Timer1.Enabled = True

                        ' instancia la tabla
                        dt_CargaIncoMatriculas = New DataTable

                        ' Crea las columnas
                        dt_CargaIncoMatriculas.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                        dt_CargaIncoMatriculas.Columns.Add(New DataColumn("Cedula_catastral", GetType(String)))
                        dt_CargaIncoMatriculas.Columns.Add(New DataColumn("Tipo_Docu", GetType(String)))
                        dt_CargaIncoMatriculas.Columns.Add(New DataColumn("Nro_Documento", GetType(String)))
                        dt_CargaIncoMatriculas.Columns.Add(New DataColumn("Nombre", GetType(String)))
                        dt_CargaIncoMatriculas.Columns.Add(New DataColumn("Primer_Apellido", GetType(String)))
                        dt_CargaIncoMatriculas.Columns.Add(New DataColumn("Segundo_Apellido", GetType(String)))

                        ' crea el datarow
                        Dim dr1 As DataRow

                        ' declara la variable
                        Dim inFicha As Integer = 0

                        ' limpia la variable
                        i = 0

                        For i = 0 To dt.Rows.Count - 1

                            ' crea la variable para validar individualmente
                            inFicha = dt.Rows(i).Item("FIPRNUFI")

                            'instancia la clase
                            Dim objdatos35 As New cla_FIPRPROP
                            dt_FIPRPROP_Municipio = New DataTable

                            ' Consulta las matriculas por ficha predial
                            dt_FIPRPROP_Municipio = objdatos35.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(inFicha)

                            ' verifica que existan registros
                            If dt_FIPRPROP_Municipio.Rows.Count > 0 Then

                                ' declara la variable
                                Dim d As Integer = 0

                                For d = 0 To dt_FIPRPROP_Municipio.Rows.Count - 1

                                    ' declara la variable y almacena los nombre y apellidos
                                    Dim stTipoDocumento As String = Trim(dt_FIPRPROP_Municipio.Rows(d).Item("FPPRTIDO"))
                                    Dim stNroDcumento As String = Trim(dt_FIPRPROP_Municipio.Rows(d).Item("FPPRNUDO"))
                                    Dim stNombre As String = Trim(dt_FIPRPROP_Municipio.Rows(d).Item("FPPRNOMB"))
                                    Dim stPrimerApellido As String = Trim(dt_FIPRPROP_Municipio.Rows(d).Item("FPPRPRAP"))
                                    Dim stSegundoApellido As String = Trim(dt_FIPRPROP_Municipio.Rows(d).Item("FPPRSEAP"))

                                    If Trim(stNroDcumento) <> "" Then

                                        ' buscar cadena de conexion
                                        Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                                        Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

                                        ' crea el datatable
                                        Dim dt1 As New DataTable

                                        ' crear conexión
                                        oAdapter = New SqlDataAdapter
                                        oConexion = New SqlConnection(stCadenaConexion1)

                                        ' abre la conexion
                                        oConexion.Open()

                                        ' parametros de la consulta
                                        Dim ParametrosConsulta1 As String = ""

                                        ' Concatena la condicion de la consulta
                                        ParametrosConsulta1 += "Select "
                                        ParametrosConsulta1 += "Fiprnufi, "
                                        ParametrosConsulta1 += "FiprClse, "
                                        ParametrosConsulta1 += "FiprMuni, "
                                        ParametrosConsulta1 += "FiprCorr, "
                                        ParametrosConsulta1 += "FiprBarr, "
                                        ParametrosConsulta1 += "FiprManz, "
                                        ParametrosConsulta1 += "FiprPred, "
                                        ParametrosConsulta1 += "FiprEdif, "
                                        ParametrosConsulta1 += "FiprUnpr, "
                                        ParametrosConsulta1 += "FiprCeca, "
                                        ParametrosConsulta1 += "FpprTido, "
                                        ParametrosConsulta1 += "FpprNudo, "
                                        ParametrosConsulta1 += "FpprNomb, "
                                        ParametrosConsulta1 += "FpprPrap, "
                                        ParametrosConsulta1 += "FpprSeap, "
                                        ParametrosConsulta1 += "FpprTomo, "
                                        ParametrosConsulta1 += "FpprMain "
                                        ParametrosConsulta1 += "From FichPred, FiprProp where FiprNufi = FpprNufi and "
                                        ParametrosConsulta1 += "FpprNudo = '" & Trim(stNroDcumento) & "' and "
                                        ParametrosConsulta1 += "FiprMuni = '" & Trim(dt.Rows(i).Item("FIPRMUNI")) & "' and "
                                        ParametrosConsulta1 += "FiprClse = '" & Trim(dt.Rows(i).Item("FIPRCLSE")) & "' and "
                                        ParametrosConsulta1 += "FiprTifi = '" & Trim(dt.Rows(i).Item("FIPRTIFI")) & "' and "
                                        ParametrosConsulta1 += "FiprEsta = 'ac' and "
                                        ParametrosConsulta1 += "FpprEsta = 'ac' "

                                        ' ejecuta la consulta
                                        oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

                                        ' procesa la consulta 
                                        oEjecutar.CommandTimeout = 0
                                        oEjecutar.CommandType = CommandType.Text
                                        oAdapter.SelectCommand = oEjecutar

                                        ' llena el datatable 
                                        oAdapter.Fill(dt1)

                                        ' cierra la conexion
                                        oConexion.Close()

                                        ' verifica que existan mas fichas con la misma matricula
                                        If dt1.Rows.Count > 0 Then

                                            ' declara la variable
                                            Dim inContadorRegistro As Integer = 0
                                            Dim y As Integer = 0

                                            For y = 0 To dt1.Rows.Count - 1

                                                If Trim(dt1.Rows(y).Item("FIPRNUFI")) <> CInt(inFicha) Then
                                                    If Trim(stNombre) <> Trim(dt1.Rows(y).Item("FPPRNOMB")) Or _
                                                       Trim(stPrimerApellido) <> Trim(dt1.Rows(y).Item("FPPRPRAP")) Or _
                                                       Trim(stSegundoApellido) <> Trim(dt1.Rows(y).Item("FPPRSEAP")) Then

                                                        If Trim(stNroDcumento) = Trim(dt1.Rows(y).Item("FPPRNUDO")) Then
                                                            inContadorRegistro = inContadorRegistro + 1
                                                        End If

                                                    End If
                                                End If

                                            Next

                                            ' verifica el contador
                                            If inContadorRegistro > 0 Then

                                                ' declara la variable
                                                Dim k As Integer = 0

                                                ' Recorro la tabla del municipio
                                                For k = 0 To dt1.Rows.Count - 1

                                                    ' declaración de variables
                                                    Dim stFIPRNUFI As String = ""
                                                    Dim stFIPRCLSE As String = ""
                                                    Dim stFIPRMUNI As String = ""
                                                    Dim stFIPRCORR As String = ""
                                                    Dim stFIPRBARR As String = ""
                                                    Dim stFIPRMANZ As String = ""
                                                    Dim stFIPRPRED As String = ""
                                                    Dim stFIPREDIF As String = ""
                                                    Dim stFIPRUNPR As String = ""
                                                    Dim stFIPRCECA As String = ""
                                                    Dim stFPPRTIDO As String = ""
                                                    Dim stFPPRNUDO As String = ""
                                                    Dim stFPPRNOMB As String = ""
                                                    Dim stFPPRPRAP As String = ""
                                                    Dim stFPPRSEAP As String = ""
                                                    Dim stFPPRTOMO As String = ""
                                                    Dim stFPPRMAIN As String = ""

                                                    stFIPRNUFI = Trim(dt1.Rows(k).Item("FIPRNUFI"))
                                                    stFIPRMUNI = Trim(dt1.Rows(k).Item("FIPRMUNI"))
                                                    stFIPRCLSE = Trim(dt1.Rows(k).Item("FIPRCLSE"))
                                                    stFIPRCORR = Trim(dt1.Rows(k).Item("FIPRCORR"))
                                                    stFIPRBARR = Trim(dt1.Rows(k).Item("FIPRBARR"))
                                                    stFIPRMANZ = Trim(dt1.Rows(k).Item("FIPRMANZ"))
                                                    stFIPRPRED = Trim(dt1.Rows(k).Item("FIPRPRED"))
                                                    stFIPREDIF = Trim(dt1.Rows(k).Item("FIPREDIF"))
                                                    stFIPRUNPR = Trim(dt1.Rows(k).Item("FIPRUNPR"))
                                                    stFPPRTIDO = Trim(dt1.Rows(k).Item("FPPRTIDO"))
                                                    stFPPRNUDO = Trim(dt1.Rows(k).Item("FPPRNUDO"))
                                                    stFPPRNOMB = Trim(dt1.Rows(k).Item("FPPRNOMB"))
                                                    stFPPRPRAP = Trim(dt1.Rows(k).Item("FPPRPRAP"))
                                                    stFPPRSEAP = Trim(dt1.Rows(k).Item("FPPRSEAP"))

                                                    stFIPRCECA = stFIPRMUNI & "-" & stFIPRCLSE & "-" & stFIPRCORR & "-" & stFIPRBARR & "-" & stFIPRMANZ & "-" & stFIPRPRED & "-" & stFIPREDIF & "-" & stFIPRUNPR

                                                    ' almacena la inconsistencia 
                                                    dr1 = dt_CargaIncoMatriculas.NewRow()

                                                    dr1("Nro_Ficha") = stFIPRNUFI
                                                    dr1("Cedula_catastral") = stFIPRCECA
                                                    dr1("Tipo_Docu") = stFPPRTIDO
                                                    dr1("Nro_Documento") = stFPPRNUDO
                                                    dr1("Nombre") = stFPPRNOMB
                                                    dr1("Primer_Apellido") = stFPPRPRAP
                                                    dr1("Segundo_Apellido") = stFPPRSEAP

                                                    dt_CargaIncoMatriculas.Rows.Add(dr1)

                                                Next

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

                        ' verifica el resultado
                        If dt_CargaIncoMatriculas.Rows.Count > 0 Then

                            ' Llena el datagrigview
                            Me.dgvFIPRINCO.DataSource = dt_CargaIncoMatriculas

                            MessageBox.Show("Existen inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        Else
                            ' limpia el datagrid
                            Me.dgvFIPRINCO.DataSource = New DataTable

                            MessageBox.Show("Cruce sin inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If

                        '=========================================
                        ' *** VERIFICA LAS IMAGENES POR PREDIO ***
                        '=========================================
                    ElseIf Me.rbdImagenConstruccion.Checked = True And Me.rbdListadoDeRuta.Checked = True Then

                        ' Valores predeterminados ProgressBar
                        inProceso = 0
                        Me.pbPROCESO.Value = 0
                        Me.pbPROCESO.Maximum = dt.Rows.Count
                        Me.Timer1.Enabled = True

                        ' instancia la tabla
                        dt_CargaImagenConstruccion = New DataTable

                        ' crea las tablas
                        Dim dr1 As DataRow

                        ' Crea las columnas
                        dt_CargaImagenConstruccion.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                        dt_CargaImagenConstruccion.Columns.Add(New DataColumn("Nro_Construccion", GetType(String)))
                        dt_CargaImagenConstruccion.Columns.Add(New DataColumn("Foto", GetType(String)))
                        dt_CargaImagenConstruccion.Columns.Add(New DataColumn("Path", GetType(String)))
                        dt_CargaImagenConstruccion.Columns.Add(New DataColumn("Cedula_Catastral", GetType(String)))

                        ' Recorre el rango asignado
                        Dim i As Integer

                        For i = 0 To dt.Rows.Count - 1

                            ' crea la variable 
                            Dim inFIPRNUFI As Integer = CInt(dt.Rows(i).Item("FIPRNUFI"))
                            Dim stFIPRDEPA As String = CStr(Trim(dt.Rows(i).Item("FIPRDEPA")))
                            Dim stFIPRMUNI As String = CStr(Trim(dt.Rows(i).Item("FIPRMUNI")))
                            Dim stFIPRCORR As String = CStr(Trim(dt.Rows(i).Item("FIPRCORR")))
                            Dim stFIPRBARR As String = CStr(Trim(dt.Rows(i).Item("FIPRBARR")))
                            Dim stFIPRMANZ As String = CStr(Trim(dt.Rows(i).Item("FIPRMANZ")))
                            Dim stFIPRPRED As String = CStr(Trim(dt.Rows(i).Item("FIPRPRED")))
                            Dim stFIPREDIF As String = CStr(Trim(dt.Rows(i).Item("FIPREDIF")))
                            Dim stFIPRUNPR As String = CStr(Trim(dt.Rows(i).Item("FIPRUNPR")))
                            Dim inFIPRCLSE As Integer = CInt(dt.Rows(i).Item("FIPRCLSE"))

                            Dim stFIPRCECA As String = stFIPRMUNI & "-" & inFIPRCLSE & "-" & stFIPRCORR & "-" & stFIPRBARR & "-" & stFIPRMANZ & "-" & stFIPRPRED & "-" & stFIPREDIF & "-" & stFIPRUNPR

                            'instancia la clase
                            Dim objdatos35 As New cla_FIPRCONS
                            dt_FIPRCONS_Municipio = New DataTable

                            ' Consulta las construcciones por ficha predial
                            dt_FIPRCONS_Municipio = objdatos35.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(CInt(inFIPRNUFI))

                            ' verifica que existan registros con construccion
                            If dt_FIPRCONS_Municipio.Rows.Count > 0 Then

                                ' declara la variable
                                Dim j As Integer = 0

                                ' recorre la tabla
                                For j = 0 To dt_FIPRCONS_Municipio.Rows.Count - 1

                                    ' declara la variable y almacena la matricula
                                    Dim inFPCOUNID As String = CInt(dt_FIPRCONS_Municipio.Rows(j).Item("FPCOUNID").ToString)
                                    Dim boFPCOMEJO As Boolean = CBool(dt_FIPRCONS_Municipio.Rows(j).Item("FPCOMEJO"))
                                    Dim inFPCOCLCO As String = CInt(dt_FIPRCONS_Municipio.Rows(j).Item("FPCOCLCO").ToString)
                                    Dim stFPCOTICO As String = CStr(dt_FIPRCONS_Municipio.Rows(j).Item("FPCOTICO").ToString)

                                    ' verifica el registro
                                    If CInt(inFPCOUNID) > 0 Then
                                        'If CInt(inFPCOUNID) < 1000 And boFPCOMEJO = False Then

                                        ' declara las variables
                                        Dim inNroFicha As Integer = CInt(inFIPRNUFI)
                                        Dim inNroConstruccion As String = CInt(inFPCOUNID)
                                        Dim stArchivoFoto As String = ""
                                        Dim stRutaArchivo As String = ""

                                        ' delcara la instancia
                                        Dim obRUTACAFO As New cla_RUTACAFO
                                        Dim dtRUTACAFO As New DataTable

                                        dtRUTACAFO = obRUTACAFO.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_MANT_RUTACAFO(stFIPRDEPA, stFIPRMUNI, inFIPRCLSE)

                                        If dtRUTACAFO.Rows.Count > 0 Then

                                            ' declara la variable
                                            Dim i2 As Integer = 0

                                            For i2 = 0 To dtRUTACAFO.Rows.Count - 1

                                                ' encontro el archivo 
                                                If dtRUTACAFO.Rows(i2).Item("RUCFCAFO") = 1 Then

                                                    ' declara la instancia
                                                    Dim obFOTOTICO As New cla_FOTOTICO
                                                    Dim dtFOTOTICO As New DataTable

                                                    dtFOTOTICO = obFOTOTICO.fun_Buscar_CODIGO_X_MANT_FOTOTICO(stFIPRDEPA, stFIPRMUNI, inFIPRCLSE, inFPCOCLCO, stFPCOTICO, CInt(1))

                                                    ' declara la variable
                                                    Dim boAplicaFotografia As Boolean = False

                                                    If dtFOTOTICO.Rows.Count > 0 Then
                                                        boAplicaFotografia = True
                                                    End If

                                                    ' declara la instancia
                                                    Dim obFIPRIMAG As New cla_FIPRIMAG
                                                    Dim dtFIPRIMAG As New DataTable

                                                    dtFIPRIMAG = obFIPRIMAG.fun_Buscar_CODIGO_FIPRIMAG(inNroFicha, inNroConstruccion, "1")

                                                    If dtFIPRIMAG.Rows.Count > 0 And boAplicaFotografia = True Then

                                                        stArchivoFoto = (inNroFicha) & "-" & (inNroConstruccion) & "-" & "1" & ".jpg"

                                                        dr1 = dt_CargaImagenConstruccion.NewRow()

                                                        dr1("Nro_Ficha") = CInt(inNroFicha)
                                                        dr1("Nro_Construccion") = CInt(inNroConstruccion)
                                                        dr1("Foto") = stArchivoFoto
                                                        dr1("Path") = "..." & stRutaArchivo & "\" & stArchivoFoto
                                                        dr1("Cedula_Catastral") = stFIPRCECA

                                                        dt_CargaImagenConstruccion.Rows.Add(dr1)

                                                    ElseIf dtFIPRIMAG.Rows.Count = 0 And boAplicaFotografia = True Then

                                                        stArchivoFoto = "No existe foto" & " 1"

                                                        dr1 = dt_CargaImagenConstruccion.NewRow()

                                                        dr1("Nro_Ficha") = CInt(inNroFicha)
                                                        dr1("Nro_Construccion") = CInt(inNroConstruccion)
                                                        dr1("Foto") = stArchivoFoto
                                                        dr1("Path") = "..." & stRutaArchivo
                                                        dr1("Cedula_Catastral") = stFIPRCECA

                                                        dt_CargaImagenConstruccion.Rows.Add(dr1)

                                                    End If

                                                End If

                                                ' encontro el archivo 
                                                If dtRUTACAFO.Rows(i2).Item("RUCFCAFO") = 2 Then

                                                    ' declara la instancia
                                                    Dim obFOTOTICO As New cla_FOTOTICO
                                                    Dim dtFOTOTICO As New DataTable

                                                    dtFOTOTICO = obFOTOTICO.fun_Buscar_CODIGO_X_MANT_FOTOTICO(stFIPRDEPA, stFIPRMUNI, inFIPRCLSE, inFPCOCLCO, stFPCOTICO, CInt(2))

                                                    ' declara la variable
                                                    Dim boAplicaFotografia As Boolean = False

                                                    If dtFOTOTICO.Rows.Count > 0 Then
                                                        boAplicaFotografia = True
                                                    End If

                                                    ' declara la instancia
                                                    Dim obFIPRIMAG As New cla_FIPRIMAG
                                                    Dim dtFIPRIMAG As New DataTable

                                                    dtFIPRIMAG = obFIPRIMAG.fun_Buscar_CODIGO_FIPRIMAG(inNroFicha, inNroConstruccion, "2")

                                                    If dtFIPRIMAG.Rows.Count > 0 And boAplicaFotografia = True Then

                                                        stArchivoFoto = (inNroFicha) & "-" & (inNroConstruccion) & "-" & "2" & ".jpg"

                                                        dr1 = dt_CargaImagenConstruccion.NewRow()

                                                        dr1("Nro_Ficha") = CInt(inNroFicha)
                                                        dr1("Nro_Construccion") = CInt(inNroConstruccion)
                                                        dr1("Foto") = stArchivoFoto
                                                        dr1("Path") = "..." & stRutaArchivo & "\" & stArchivoFoto
                                                        dr1("Cedula_Catastral") = stFIPRCECA

                                                        dt_CargaImagenConstruccion.Rows.Add(dr1)

                                                    ElseIf dtFIPRIMAG.Rows.Count = 0 And boAplicaFotografia = True Then

                                                        stArchivoFoto = "No existe foto" & " 2"

                                                        dr1 = dt_CargaImagenConstruccion.NewRow()

                                                        dr1("Nro_Ficha") = CInt(inNroFicha)
                                                        dr1("Nro_Construccion") = CInt(inNroConstruccion)
                                                        dr1("Foto") = stArchivoFoto
                                                        dr1("Path") = "..." & stRutaArchivo
                                                        dr1("Cedula_Catastral") = stFIPRCECA

                                                        dt_CargaImagenConstruccion.Rows.Add(dr1)

                                                    End If

                                                End If

                                                ' encontro el archivo 
                                                If dtRUTACAFO.Rows(i2).Item("RUCFCAFO") = 3 Then

                                                    ' declara la instancia
                                                    Dim obFOTOTICO As New cla_FOTOTICO
                                                    Dim dtFOTOTICO As New DataTable

                                                    dtFOTOTICO = obFOTOTICO.fun_Buscar_CODIGO_X_MANT_FOTOTICO(stFIPRDEPA, stFIPRMUNI, inFIPRCLSE, inFPCOCLCO, stFPCOTICO, CInt(3))

                                                    ' declara la variable
                                                    Dim boAplicaFotografia As Boolean = False

                                                    If dtFOTOTICO.Rows.Count > 0 Then
                                                        boAplicaFotografia = True
                                                    End If

                                                    ' declara la instancia
                                                    Dim obFIPRIMAG As New cla_FIPRIMAG
                                                    Dim dtFIPRIMAG As New DataTable

                                                    dtFIPRIMAG = obFIPRIMAG.fun_Buscar_CODIGO_FIPRIMAG(inNroFicha, inNroConstruccion, "3")

                                                    If dtFIPRIMAG.Rows.Count > 0 And boAplicaFotografia = True Then

                                                        stArchivoFoto = (inNroFicha) & "-" & (inNroConstruccion) & "-" & "3" & ".jpg"

                                                        dr1 = dt_CargaImagenConstruccion.NewRow()

                                                        dr1("Nro_Ficha") = CInt(inNroFicha)
                                                        dr1("Nro_Construccion") = CInt(inNroConstruccion)
                                                        dr1("Foto") = stArchivoFoto
                                                        dr1("Path") = "..." & stRutaArchivo & "\" & stArchivoFoto
                                                        dr1("Cedula_Catastral") = stFIPRCECA

                                                        dt_CargaImagenConstruccion.Rows.Add(dr1)

                                                    ElseIf dtFIPRIMAG.Rows.Count = 0 And boAplicaFotografia = True Then

                                                        stArchivoFoto = "No existe foto" & " 3"

                                                        dr1 = dt_CargaImagenConstruccion.NewRow()

                                                        dr1("Nro_Ficha") = CInt(inNroFicha)
                                                        dr1("Nro_Construccion") = CInt(inNroConstruccion)
                                                        dr1("Foto") = stArchivoFoto
                                                        dr1("Path") = "..." & stRutaArchivo
                                                        dr1("Cedula_Catastral") = stFIPRCECA

                                                        dt_CargaImagenConstruccion.Rows.Add(dr1)

                                                    End If

                                                End If

                                                ' encontro el archivo 
                                                If dtRUTACAFO.Rows(i2).Item("RUCFCAFO") = 4 Then

                                                    ' declara la instancia
                                                    Dim obFOTOTICO As New cla_FOTOTICO
                                                    Dim dtFOTOTICO As New DataTable

                                                    dtFOTOTICO = obFOTOTICO.fun_Buscar_CODIGO_X_MANT_FOTOTICO(stFIPRDEPA, stFIPRMUNI, inFIPRCLSE, inFPCOCLCO, stFPCOTICO, CInt(4))

                                                    ' declara la variable
                                                    Dim boAplicaFotografia As Boolean = False

                                                    If dtFOTOTICO.Rows.Count > 0 Then
                                                        boAplicaFotografia = True
                                                    End If

                                                    ' declara la instancia
                                                    Dim obFIPRIMAG As New cla_FIPRIMAG
                                                    Dim dtFIPRIMAG As New DataTable

                                                    dtFIPRIMAG = obFIPRIMAG.fun_Buscar_CODIGO_FIPRIMAG(inNroFicha, inNroConstruccion, "4")

                                                    If dtFIPRIMAG.Rows.Count > 0 And boAplicaFotografia = True Then

                                                        stArchivoFoto = (inNroFicha) & "-" & (inNroConstruccion) & "-" & "4" & ".jpg"

                                                        dr1 = dt_CargaImagenConstruccion.NewRow()

                                                        dr1("Nro_Ficha") = CInt(inNroFicha)
                                                        dr1("Nro_Construccion") = CInt(inNroConstruccion)
                                                        dr1("Foto") = stArchivoFoto
                                                        dr1("Path") = "..." & stRutaArchivo & "\" & stArchivoFoto
                                                        dr1("Cedula_Catastral") = stFIPRCECA

                                                        dt_CargaImagenConstruccion.Rows.Add(dr1)

                                                    ElseIf dtFIPRIMAG.Rows.Count = 0 And boAplicaFotografia = True Then

                                                        stArchivoFoto = "No existe foto" & " 4"

                                                        dr1 = dt_CargaImagenConstruccion.NewRow()

                                                        dr1("Nro_Ficha") = CInt(inNroFicha)
                                                        dr1("Nro_Construccion") = CInt(inNroConstruccion)
                                                        dr1("Foto") = stArchivoFoto
                                                        dr1("Path") = "..." & stRutaArchivo
                                                        dr1("Cedula_Catastral") = stFIPRCECA

                                                        dt_CargaImagenConstruccion.Rows.Add(dr1)

                                                    End If

                                                End If

                                                ' encontro el archivo 
                                                If dtRUTACAFO.Rows(i2).Item("RUCFCAFO") = 5 Then

                                                    ' instancia la clase
                                                    Dim obFOTOTICO As New cla_FOTOTICO
                                                    Dim dtFOTOTICO As New DataTable

                                                    dtFOTOTICO = obFOTOTICO.fun_Buscar_CODIGO_X_MANT_FOTOTICO(stFIPRDEPA, stFIPRMUNI, inFIPRCLSE, inFPCOCLCO, stFPCOTICO, CInt(5))

                                                    ' declara la variable
                                                    Dim boAplicaFotografia As Boolean = False

                                                    If dtFOTOTICO.Rows.Count > 0 Then
                                                        boAplicaFotografia = True
                                                    End If

                                                    ' instancia la clase
                                                    Dim obFIPRCACO As New cla_FIPRCACO
                                                    Dim dtFIPRCACO As New DataTable

                                                    dtFIPRCACO = obFIPRCACO.fun_Consultar_FIPRCACO_X_FICHA_PREDIAL(inNroFicha, inNroConstruccion)

                                                    ' declaro la variable
                                                    Dim boAplicaCerchas As Boolean = False

                                                    If dtFIPRCACO.Rows.Count > 0 Then

                                                        ' declaro la variable
                                                        Dim j6 As Integer = 0

                                                        For j6 = 0 To dtFIPRCACO.Rows.Count - 1

                                                            If CStr(Trim(dtFIPRCACO.Rows(j6).Item("FPCCCODI").ToString)) = "511" Or _
                                                               CStr(Trim(dtFIPRCACO.Rows(j6).Item("FPCCCODI").ToString)) = "512" Or _
                                                               CStr(Trim(dtFIPRCACO.Rows(j6).Item("FPCCCODI").ToString)) = "513" Or _
                                                               CStr(Trim(dtFIPRCACO.Rows(j6).Item("FPCCCODI").ToString)) = "514" Or _
                                                               CStr(Trim(dtFIPRCACO.Rows(j6).Item("FPCCCODI").ToString)) = "515" Then

                                                                boAplicaCerchas = True

                                                            End If

                                                        Next

                                                    End If

                                                    ' declara la instancia
                                                    Dim obFIPRIMAG As New cla_FIPRIMAG
                                                    Dim dtFIPRIMAG As New DataTable

                                                    dtFIPRIMAG = obFIPRIMAG.fun_Buscar_CODIGO_FIPRIMAG(inNroFicha, inNroConstruccion, "5")

                                                    If dtFIPRIMAG.Rows.Count > 0 And boAplicaFotografia = True And boAplicaCerchas = True Then

                                                        stArchivoFoto = (inNroFicha) & "-" & (inNroConstruccion) & "-" & "5" & ".jpg"

                                                        dr1 = dt_CargaImagenConstruccion.NewRow()

                                                        dr1("Nro_Ficha") = CInt(inNroFicha)
                                                        dr1("Nro_Construccion") = CInt(inNroConstruccion)
                                                        dr1("Foto") = stArchivoFoto
                                                        dr1("Path") = "..." & stRutaArchivo & "\" & stArchivoFoto
                                                        dr1("Cedula_Catastral") = stFIPRCECA

                                                        dt_CargaImagenConstruccion.Rows.Add(dr1)

                                                    ElseIf dtFIPRIMAG.Rows.Count = 0 And boAplicaFotografia = True And boAplicaCerchas = True Then

                                                        stArchivoFoto = "No existe foto" & " 5"

                                                        dr1 = dt_CargaImagenConstruccion.NewRow()

                                                        dr1("Nro_Ficha") = CInt(inNroFicha)
                                                        dr1("Nro_Construccion") = CInt(inNroConstruccion)
                                                        dr1("Foto") = stArchivoFoto
                                                        dr1("Path") = "..." & stRutaArchivo
                                                        dr1("Cedula_Catastral") = stFIPRCECA

                                                        dt_CargaImagenConstruccion.Rows.Add(dr1)

                                                    End If

                                                End If

                                            Next

                                        End If

                                    End If

                                Next

                                ' predio sin construccion
                            ElseIf dt_FIPRCONS_Municipio.Rows.Count = 0 Then

                                ' declaro la variable
                                Dim stArchivoFoto As String = ""
                                Dim stRutaArchivo As String = ""

                                ' declara la instancia
                                Dim obFIPRIMAG As New cla_FIPRIMAG
                                Dim dtFIPRIMAG As New DataTable

                                dtFIPRIMAG = obFIPRIMAG.fun_Buscar_CODIGO_FIPRIMAG(inFIPRNUFI, "0", "1")

                                If dtFIPRIMAG.Rows.Count > 0 Then

                                    stArchivoFoto = (inFIPRNUFI) & "-" & "0" & "-" & "1" & ".jpg"

                                    dr1 = dt_CargaImagenConstruccion.NewRow()

                                    dr1("Nro_Ficha") = CInt(inFIPRNUFI)
                                    dr1("Nro_Construccion") = CInt("0")
                                    dr1("Foto") = stArchivoFoto
                                    dr1("Path") = "..." & stRutaArchivo & "\" & stArchivoFoto
                                    dr1("Cedula_Catastral") = stFIPRCECA

                                    dt_CargaImagenConstruccion.Rows.Add(dr1)

                                Else
                                    stArchivoFoto = "No existe foto" & " 0"

                                    dr1 = dt_CargaImagenConstruccion.NewRow()

                                    dr1("Nro_Ficha") = CInt(inFIPRNUFI)
                                    dr1("Nro_Construccion") = CInt("0")
                                    dr1("Foto") = stArchivoFoto
                                    dr1("Path") = "..." & stRutaArchivo
                                    dr1("Cedula_Catastral") = stFIPRCECA

                                    dt_CargaImagenConstruccion.Rows.Add(dr1)

                                End If

                            End If

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbPROCESO.Value = inProceso

                        Next

                        ' inicia la barra de progreso
                        pbPROCESO.Value = 0

                        ' verifica el resultado
                        If dt_CargaImagenConstruccion.Rows.Count > 0 Then

                            ' Llena el datagrigview
                            Me.dgvFIPRINCO.DataSource = dt_CargaImagenConstruccion

                            MessageBox.Show("Se genero el listado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Else
                            ' limpia el datagrid
                            Me.dgvFIPRINCO.DataSource = New DataTable

                            MessageBox.Show("Consulta no encontro registros", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If

                    ElseIf Me.rbdImagenConstruccion.Checked = True And Me.rbdEnrutarImagenCalificacion.Checked = True Then

                        '=====================================
                        '*** ENRUTA IMAGEN DE CALIFICACION ***
                        '=====================================

                        ' instancia la clase
                        Dim objdatos333 As New cla_RUTAS
                        Dim tbl333 As New DataTable

                        Dim stRuta1 As String = ""
                        Dim stRuta2 As String = ""
                        Dim stRutaArchivo1 As String = ""

                        ' almacena la consulta
                        tbl333 = objdatos333.fun_Buscar_CODIGO_MANT_RUTAS(2)

                        ' verifica que exista registros
                        If tbl333.Rows.Count > 0 Then

                            ' verifica los campos numericos
                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRMUNI.Text)) = True And _
                               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRCLSE.Text)) = True Then

                                ' declara la instancia
                                Dim obMUNICIPIO As New cla_MUNICIPIO
                                Dim dtMUNICIPIO As New DataTable

                                dtMUNICIPIO = obMUNICIPIO.fun_Buscar_CODIGO_MANT_MUNICIPIO(Trim(Me.txtFIPRMUNI.Text))

                                If dtMUNICIPIO.Rows.Count > 0 Then

                                    ' declara la instancia
                                    Dim obSECTOR As New cla_CLASSECT
                                    Dim dtSECTOR As New DataTable

                                    dtSECTOR = obSECTOR.fun_Buscar_CODIGO_MANT_CLASSECT(Trim(Me.txtFIPRCLSE.Text))

                                    If dtSECTOR.Rows.Count > 0 Then

                                        Dim obFIPRIMAG11 As New cla_FIPRIMAG
                                        obFIPRIMAG11.fun_Eliminar_X_DEPA_X_MUNI_X_CLSE_X_FIPRIMAG(vp_Departamento, Trim(Me.txtFIPRMUNI.Text), Trim(Me.txtFIPRCLSE.Text))

                                        ' instancia la clase
                                        Dim obRUTACAFO As New cla_RUTACAFO
                                        Dim dtRUTACAFO As New DataTable

                                        dtRUTACAFO = obRUTACAFO.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_MANT_RUTACAFO(vp_Departamento, Trim(Me.txtFIPRMUNI.Text), Trim(Me.txtFIPRCLSE.Text))

                                        'Valores predeterminados ProgressBar
                                        inProceso = 0
                                        pbPROCESO.Value = 0
                                        pbPROCESO.Maximum = dtRUTACAFO.Rows.Count
                                        Timer1.Enabled = True

                                        ' declaro la variable
                                        Dim i As Integer = 0

                                        For i = 0 To dtRUTACAFO.Rows.Count - 1

                                            ' almacena la variable ruta
                                            stRuta2 = Trim(dtRUTACAFO.Rows(i).Item("RUCFRUTA"))

                                            Dim ObjCarpeta As Object
                                            Dim Carpeta As Object

                                            ObjCarpeta = CreateObject("Scripting.FileSystemObject")
                                            Carpeta = ObjCarpeta.GetFolder(stRuta2)

                                            If Trim(stRuta2) = "" Then
                                                MessageBox.Show("Se debe introducir una ruta valida", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                            Else
                                                ' verifica la ruta
                                                ChDir(stRuta2)

                                                ' almacena la ruta definitiva
                                                stRutaArchivo1 = stRuta2

                                                ' consulta los archivos por extension
                                                stRutaArchivo1 = Dir("*.jpg").ToString.ToLower

                                                ' verifica que exista archivos
                                                If stRutaArchivo1 <> "" Then

                                                    ' declara la variable
                                                    Dim inFicha As Integer = 0

                                                    Try
                                                        ' recorre la carpeta
                                                        Do Until stRutaArchivo1 = ""

                                                            Dim stNroFicha As String = fun_ObtenerNroFicha(stRutaArchivo1)
                                                            Dim stNroConstruccion As String = fun_ObtenerNroConstruccion(stRutaArchivo1)
                                                            Dim stNroFoto As String = fun_ObtenerNroFoto(stRutaArchivo1)

                                                            If stNroFicha.ToString.Length <= 9 AndAlso
                                                               fun_Verificar_Dato_Numerico_Evento_Validated(stNroFicha) = True And _
                                                               fun_Verificar_Dato_Numerico_Evento_Validated(stNroConstruccion) = True And _
                                                               fun_Verificar_Dato_Numerico_Evento_Validated(stNroFoto) = True Then

                                                                ' instancia la clase
                                                                Dim obFIPRIMAG1 As New cla_FIPRIMAG
                                                                Dim tdFIPRIMAG1 As New DataTable

                                                                tdFIPRIMAG1 = obFIPRIMAG1.fun_Buscar_CODIGO_FIPRIMAG(stNroFicha, stNroConstruccion, stNroFoto)

                                                                If tdFIPRIMAG1.Rows.Count = 0 Then
                                                                    obFIPRIMAG1.fun_Insertar_FIPRIMAG(stNroFicha, stNroConstruccion, stNroFoto, Trim(stRuta2) & "\" & stNroFicha & "-" & stNroConstruccion & "-" & stNroFoto & ".jpg", vp_Departamento, Trim(Me.txtFIPRMUNI.Text), Trim(Me.txtFIPRCLSE.Text))
                                                                Else
                                                                    obFIPRIMAG1.fun_Actualizar_FIPRIMAG(stNroFicha, stNroConstruccion, stNroFoto, Trim(stRuta2) & "\" & stNroFicha & "-" & stNroConstruccion & "-" & stNroFoto & ".jpg", vp_Departamento, Trim(Me.txtFIPRMUNI.Text), Trim(Me.txtFIPRCLSE.Text))
                                                                End If

                                                            End If

                                                            ' desplaza al siguiente registro
                                                            stRutaArchivo1 = Dir()

                                                        Loop

                                                    Catch ex As Exception
                                                        MessageBox.Show(Err.Description)
                                                    End Try

                                                End If
                                            End If

                                        Next

                                        ' Incrementa la barra
                                        inProceso = inProceso + 1
                                        pbPROCESO.Value = inProceso

                                    Else
                                        MessageBox.Show("No existe el Sector", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                                    End If

                                Else
                                    MessageBox.Show("No existe el Municipio", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                                End If

                            Else
                                MessageBox.Show("El campo del Municipio y/o Sector No es númerico", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                            End If

                        Else
                            MessageBox.Show("No existe en base de datos la ruta de código 2.", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        End If

                        ' inicia la barra de progreso
                        pbPROCESO.Value = 0

                        MessageBox.Show("Se genero el proceso correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


                    ElseIf Me.rbdImagenConstruccion.Checked = True And Me.rbdEnrutarImagenCroquis.Checked = True Then

                        ' instancia la clase
                        Dim objdatos333 As New cla_RUTAS
                        Dim tbl333 As New DataTable

                        Dim stRuta1 As String = ""
                        Dim stRuta2 As String = ""
                        Dim stRutaArchivo1 As String = ""

                        ' almacena la consulta
                        tbl333 = objdatos333.fun_Buscar_CODIGO_MANT_RUTAS(1)

                        ' verifica que exista registros
                        If tbl333.Rows.Count > 0 Then

                            ' almacena la variable ruta
                            stRuta2 = Trim(tbl333.Rows(0).Item("RUTARUTA"))

                            Dim ObjCarpeta As Object
                            Dim Carpeta As Object

                            ObjCarpeta = CreateObject("Scripting.FileSystemObject")
                            Carpeta = ObjCarpeta.GetFolder(stRuta2)

                            ' Valores predeterminados ProgressBar
                            'inProceso = 0
                            'pbPROCESO.Value = 0
                            'pbPROCESO.Maximum = Carpeta.Files.Count + 1
                            'Timer1.Enabled = True

                            If Trim(stRuta2) = "" Then
                                MessageBox.Show("Se debe introducir una ruta valida", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Else
                                ' verifica la ruta
                                ChDir(stRuta2)

                                ' almacena la ruta definitiva
                                stRutaArchivo1 = stRuta2

                                ' consulta los archivos por extension
                                stRutaArchivo1 = Dir("*.jpg").ToString.ToLower

                                ' verifica que exista archivos
                                If stRutaArchivo1 <> "" Then

                                    Dim obFIPRIMAG11 As New cla_FIPRCROQ
                                    obFIPRIMAG11.fun_Eliminar_FIPRCROQ()

                                    ' declara la variable
                                    Dim inFicha As Integer = 0

                                    Try
                                        ' recorre la carpeta
                                        Do Until stRutaArchivo1 = ""

                                            Dim stNroFicha As String = fun_ObtenerNroFicha(stRutaArchivo1)
                                            Dim stNroConstruccion As String = fun_ObtenerNroConstruccion(stRutaArchivo1)
                                            Dim stNroFoto As String = fun_ObtenerNroFoto(stRutaArchivo1)

                                            If fun_Verificar_Dato_Numerico_Evento_Validated(stNroFicha) = True And _
                                                   fun_Verificar_Dato_Numerico_Evento_Validated(stNroConstruccion) = False And _
                                                   fun_Verificar_Dato_Numerico_Evento_Validated(stNroFoto) = False Then

                                                ' instancia la clase
                                                Dim obFIPRIMAG1 As New cla_FIPRCROQ
                                                Dim tdFIPRIMAG1 As New DataTable

                                                tdFIPRIMAG1 = obFIPRIMAG1.fun_Buscar_CODIGO_FIPRCROQ(stNroFicha, "0", "0")

                                                If tdFIPRIMAG1.Rows.Count = 0 Then
                                                    obFIPRIMAG1.fun_Insertar_FIPRCROQ(stNroFicha, "0", "0", Trim(stRuta2) & "\" & stNroFicha & ".jpg")
                                                Else
                                                    obFIPRIMAG1.fun_Actualizar_FIPRCROQ(stNroFicha, "0", "0", Trim(stRuta2) & "\" & stNroFicha & ".jpg")
                                                End If

                                            End If

                                            '*** DESPLAZARSE AL SIGUIENTE REGISTRO ***
                                            stRutaArchivo1 = Dir()

                                            ' Incrementa la barra
                                            'inProceso = inProceso + 1

                                        Loop

                                        'pbPROCESO.Value = Carpeta.Files.Count

                                    Catch ex As Exception
                                        MessageBox.Show(Err.Description)
                                    End Try

                                End If
                            End If
                        End If

                        ' inicia la barra de progreso
                        pbPROCESO.Value = 0

                        MessageBox.Show("Se genero el proceso correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


                        '=====================================================
                        ' *** LOS PREDIOS CON RESOLUCIONES ADMINISTRATIVAS ***
                        '=====================================================

                    ElseIf Me.rbdPrediosConRA.Checked = True Then

                        ' Valores predeterminados ProgressBar
                        inProceso = 0
                        pbPROCESO.Value = 0
                        pbPROCESO.Maximum = dt.Rows.Count
                        Timer1.Enabled = True

                        ' instancia la tabla
                        dt_CargaIncoRA = New DataTable

                        ' Crea las columnas
                        dt_CargaIncoRA.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                        dt_CargaIncoRA.Columns.Add(New DataColumn("Cedula_catastral", GetType(String)))
                        dt_CargaIncoRA.Columns.Add(New DataColumn("Area_SICAFI", GetType(String)))
                        dt_CargaIncoRA.Columns.Add(New DataColumn("Area_RA", GetType(String)))
                        dt_CargaIncoRA.Columns.Add(New DataColumn("Observacion", GetType(String)))

                        ' crea el datarow
                        Dim dr1 As DataRow

                        ' limpia la variable
                        i = 0

                        For i = 0 To dt.Rows.Count - 1

                            ' crea las variables
                            Dim inPRRANUFI As Integer = 0
                            Dim stPRRACECA As String = ""
                            Dim inPRRAARTE_SICAFI As Integer = 0
                            Dim inPRRAARTE_RA As Integer = 0
                            Dim stPRRAOBSE As String = ""

                            ' crea la variable para validar individualmente
                            inPRRANUFI = dt.Rows(i).Item("FIPRNUFI")
                            inPRRAARTE_SICAFI = dt.Rows(i).Item("FIPRARTE")

                            'instancia la clase
                            Dim objdatos35 As New cla_PREDREAD
                            dt_PREDREAD = New DataTable

                            ' Consulta los predios con RA
                            dt_PREDREAD = objdatos35.fun_Buscar_NRO_FICHA_MANT_PREDREAD(inPRRANUFI)

                            ' verifica que existan registros
                            If dt_PREDREAD.Rows.Count > 0 Then

                                ' crea la variable para validar individualmente
                                inPRRAARTE_RA = CInt(dt_PREDREAD.Rows(0).Item("PRRAARTE"))

                                If CInt(inPRRAARTE_SICAFI) = CInt(inPRRAARTE_RA) Then

                                    stPRRACECA = Trim(dt.Rows(i).Item("FIPRMUNI")) & "-" & Trim(dt.Rows(i).Item("FIPRCORR")) & "-" & Trim(dt.Rows(i).Item("FIPRBARR")) & "-" & Trim(dt.Rows(i).Item("FIPRMANZ")) & "-" & Trim(dt.Rows(i).Item("FIPRPRED")) & "-" & Trim(dt.Rows(i).Item("FIPREDIF")) & "-" & Trim(dt.Rows(i).Item("FIPRUNPR"))
                                    stPRRAOBSE = "Las areas de terreno SI son iguales"

                                    ' almacena la inconsistencia 
                                    dr1 = dt_CargaIncoRA.NewRow()

                                    dr1("Nro_Ficha") = inPRRANUFI
                                    dr1("Cedula_catastral") = stPRRACECA
                                    dr1("Area_SICAFI") = inPRRAARTE_SICAFI
                                    dr1("Area_RA") = inPRRAARTE_RA
                                    dr1("Observacion") = stPRRAOBSE

                                    dt_CargaIncoRA.Rows.Add(dr1)

                                Else

                                    stPRRACECA = Trim(dt.Rows(i).Item("FIPRMUNI")) & "-" & Trim(dt.Rows(i).Item("FIPRCORR")) & "-" & Trim(dt.Rows(i).Item("FIPRBARR")) & "-" & Trim(dt.Rows(i).Item("FIPRMANZ")) & "-" & Trim(dt.Rows(i).Item("FIPRPRED")) & "-" & Trim(dt.Rows(i).Item("FIPREDIF")) & "-" & Trim(dt.Rows(i).Item("FIPRUNPR"))
                                    stPRRAOBSE = "Las areas de terreno NO son iguales"

                                    dr1 = dt_CargaIncoRA.NewRow()

                                    dr1("Nro_Ficha") = inPRRANUFI
                                    dr1("Cedula_catastral") = stPRRACECA
                                    dr1("Area_SICAFI") = inPRRAARTE_SICAFI
                                    dr1("Area_RA") = inPRRAARTE_RA
                                    dr1("Observacion") = stPRRAOBSE

                                    dt_CargaIncoRA.Rows.Add(dr1)

                                End If

                            End If

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbPROCESO.Value = inProceso

                        Next

                        ' inicia la barra de progreso
                        pbPROCESO.Value = 0

                        ' verifica el resultado
                        If dt_CargaIncoRA.Rows.Count > 0 Then

                            ' Llena el datagrigview
                            Me.dgvFIPRINCO.DataSource = dt_CargaIncoRA

                            MessageBox.Show("Se genero el listado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Else
                            ' limpia el datagrid
                            Me.dgvFIPRINCO.DataSource = New DataTable

                            MessageBox.Show("Consulta no encontro registros", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If

                    End If

                ElseIf Me.chkProcesos.Checked = True Then

                    ' Valores predeterminados ProgressBar
                    inProceso = 0
                    pbPROCESO.Value = 0
                    pbPROCESO.Maximum = dt.Rows.Count
                    Timer1.Enabled = True

                    Dim seleccion As String

                    seleccion = Me.cboProcesos.SelectedIndex

                    Select Case seleccion

                        Case 0

                            Dim i As Integer = 0

                            For i = 0 To dt.Rows.Count - 1

                                Dim stFIPROBSE As String = ""

                                stFIPROBSE = fun_CorregirSaltoDeCarrilObservacionFichaPredial(Trim(dt.Rows(i).Item("FIPROBSE").ToString))

                                Dim oFICHPRED As New cla_FICHPRED

                                oFICHPRED.fun_actualizar_OBSERVACION_FICHPRED(dt.Rows(i).Item("FIPRNUFI"), Trim(stFIPROBSE))


                                ' Incrementa la barra
                                inProceso = inProceso + 1
                                pbPROCESO.Value = inProceso

                            Next

                            ' inicia la barra de progreso
                            pbPROCESO.Value = 0

                            MessageBox.Show("El proceso termino correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


                        Case 1

                            ' instancia la tabla
                            dt_CargaCaracterPropietario = New DataTable

                            ' Crea las columnas
                            dt_CargaCaracterPropietario.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                            dt_CargaCaracterPropietario.Columns.Add(New DataColumn("Cedula", GetType(String)))
                            dt_CargaCaracterPropietario.Columns.Add(New DataColumn("Nombre", GetType(String)))
                            dt_CargaCaracterPropietario.Columns.Add(New DataColumn("Primer_Apellido", GetType(String)))
                            dt_CargaCaracterPropietario.Columns.Add(New DataColumn("Segundo_Apellido", GetType(String)))

                            ' crea el datarow
                            Dim dr2 As DataRow

                            Dim i As Integer = 0

                            For i = 0 To dt.Rows.Count - 1

                                Dim boCaracterNombre As Boolean = False
                                Dim boCaracterPrApellido As Boolean = False
                                Dim boCaracterSeApellido As Boolean = False

                                Dim inNroFicha As Integer = CInt(dt.Rows(i).Item("FIPRNUFI"))

                                Dim objPropietario As New cla_FIPRPROP
                                Dim tblPropietario As New DataTable

                                tblPropietario = objPropietario.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(inNroFicha)

                                If tblPropietario.Rows.Count > 0 Then

                                    Dim ii As Integer = 0

                                    For ii = 0 To tblPropietario.Rows.Count - 1

                                        Dim stCedula As String = Trim(tblPropietario.Rows(ii).Item("FPPRNUDO").ToString)
                                        Dim stNombre As String = Trim(tblPropietario.Rows(ii).Item("FPPRNOMB").ToString)
                                        Dim stPrApellido As String = Trim(tblPropietario.Rows(ii).Item("FPPRPRAP").ToString)
                                        Dim stSeApellido As String = Trim(tblPropietario.Rows(ii).Item("FPPRSEAP").ToString)

                                        If fun_VerificarCaracterEspecial(stNombre) = True Or _
                                           fun_VerificarCaracterEspecial(stPrApellido) = True Or _
                                           fun_VerificarCaracterEspecial(stSeApellido) = True Then

                                            ' almacena la inconsistencia 
                                            dr2 = dt_CargaCaracterPropietario.NewRow()

                                            dr2("Nro_Ficha") = inNroFicha
                                            dr2("Cedula") = stCedula
                                            dr2("Nombre") = stNombre
                                            dr2("Primer_Apellido") = stPrApellido
                                            dr2("Segundo_Apellido") = stSeApellido

                                            dt_CargaCaracterPropietario.Rows.Add(dr2)

                                        End If

                                    Next

                                End If

                                ' Incrementa la barra
                                inProceso = inProceso + 1
                                pbPROCESO.Value = inProceso

                            Next

                            Me.dgvFIPRINCO.DataSource = dt_CargaCaracterPropietario

                            ' inicia la barra de progreso
                            pbPROCESO.Value = 0

                            MessageBox.Show("El proceso termino correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


                        Case 2

                            ' instancia la tabla
                            dt_CargaCaracterPropietario = New DataTable

                            ' Crea las columnas
                            dt_CargaCaracterPropietario.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                            dt_CargaCaracterPropietario.Columns.Add(New DataColumn("Cedula", GetType(String)))
                            dt_CargaCaracterPropietario.Columns.Add(New DataColumn("Nombre", GetType(String)))
                            dt_CargaCaracterPropietario.Columns.Add(New DataColumn("Primer_Apellido", GetType(String)))
                            dt_CargaCaracterPropietario.Columns.Add(New DataColumn("Segundo_Apellido", GetType(String)))

                            ' crea el datarow
                            Dim dr2 As DataRow

                            Dim boCaracterNombre As Boolean = False
                            Dim boCaracterPrApellido As Boolean = False
                            Dim boCaracterSeApellido As Boolean = False

                            Dim inNroFicha As Integer = CInt(dt.Rows(i).Item("FIPRNUFI"))

                            Dim objTercero As New cla_TERCERO
                            Dim tblTercero As New DataTable

                            tblTercero = objTercero.fun_Consultar_CAMPOS_TERCERO

                            If tblTercero.Rows.Count > 0 Then

                                ' Valores predeterminados ProgressBar
                                inProceso = 0
                                pbPROCESO.Value = 0
                                pbPROCESO.Maximum = tblTercero.Rows.Count + 1
                                Timer1.Enabled = True

                                Dim iii As Integer = 0

                                For iii = 0 To tblTercero.Rows.Count - 1

                                    Dim stCedula1 As String = Trim(tblTercero.Rows(iii).Item("TERCNUDO").ToString)
                                    Dim stNombre1 As String = Trim(tblTercero.Rows(iii).Item("TERCNOMB").ToString)
                                    Dim stPrApellido1 As String = Trim(tblTercero.Rows(iii).Item("TERCPRAP").ToString)
                                    Dim stSeApellido1 As String = Trim(tblTercero.Rows(iii).Item("TERCSEAP").ToString)

                                    If fun_VerificarCaracterEspecial(stNombre1) = True Or _
                                       fun_VerificarCaracterEspecial(stPrApellido1) = True Or _
                                       fun_VerificarCaracterEspecial(stSeApellido1) = True Then

                                        ' almacena la inconsistencia 
                                        dr2 = dt_CargaCaracterPropietario.NewRow()

                                        dr2("Nro_Ficha") = "Tercero"
                                        dr2("Cedula") = stCedula1
                                        dr2("Nombre") = stNombre1
                                        dr2("Primer_Apellido") = stPrApellido1
                                        dr2("Segundo_Apellido") = stSeApellido1

                                        dt_CargaCaracterPropietario.Rows.Add(dr2)

                                    End If

                                    ' Incrementa la barra
                                    inProceso = inProceso + 1
                                    pbPROCESO.Value = inProceso

                                Next

                                Me.dgvFIPRINCO.DataSource = dt_CargaCaracterPropietario

                                ' inicia la barra de progreso
                                pbPROCESO.Value = 0

                                MessageBox.Show("El proceso termino correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


                            End If

                        Case 3

                            ' cambiar la letra de la plancha por minuscula
                            If dt.Rows.Count > 0 Then

                                Dim inContadorModificaciones As Integer = 0

                                ' Valores predeterminados ProgressBar
                                inProceso = 0
                                pbPROCESO.Value = 0
                                pbPROCESO.Maximum = dt.Rows.Count + 1
                                Timer1.Enabled = True

                                ' declara la variable
                                Dim i As Integer = 0

                                For i = 0 To dt.Rows.Count - 1

                                    Dim inNroFicha As Integer = CInt(dt.Rows(i).Item("FIPRNUFI"))

                                    ' instancia la clase
                                    Dim obFIPRCART As New cla_FIPRCART
                                    Dim dtFIPRCART As New DataTable

                                    dtFIPRCART = obFIPRCART.fun_Consultar_FIPRCART_X_FICHA_PREDIAL(inNroFicha)

                                    If dtFIPRCART.Rows.Count > 0 Then

                                        ' declara la variable
                                        Dim k As Integer = 0

                                        For k = 0 To dtFIPRCART.Rows.Count - 1

                                            ' almacena la plancha
                                            Dim stPlancha As String = Trim(dtFIPRCART.Rows(k).Item("FPCAPLAN"))
                                            Dim stEscalaGrafica As String = Trim(dtFIPRCART.Rows(k).Item("FPCAESGR"))
                                            Dim inIdRegistro As Integer = CInt(dtFIPRCART.Rows(k).Item("FPCAIDRE"))

                                            stPlancha = fun_CambiarLetraDeLaPlanchaCartografica(stPlancha, stEscalaGrafica)

                                            If fun_ActualizaPlanchaCartografica(inIdRegistro, stPlancha) = True Then
                                                inContadorModificaciones += 1
                                            End If

                                        Next

                                    End If

                                Next

                                ' inicia la barra de progreso
                                pbPROCESO.Value = 0

                                MessageBox.Show("El proceso termino correctamente. " & "Se modificaron: " & inContadorModificaciones & " registros.", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                            End If

                        Case 4
                            pro_ActualizarEdificioFichaResumenDe001a000(Me.txtFIPRMUNI.Text, Me.txtFIPRCLSE.Text)
                        Case 5
                            pro_ActualizarEdificioFichaResumenDe000a001(Me.txtFIPRMUNI.Text, Me.txtFIPRCLSE.Text)
                        Case 6
                            pro_EliminarLinderosDuplicados()
                        Case 7
                            pro_RestaAreaConstruccionUnidadUnoCalculoAutomatico()
                        Case 8
                            pro_ListarPredioYConstruccionesMayoresUnPisoConDiferenteTipo()


                    End Select

                End If

            Else
                MessageBox.Show("Consulta no encontro registros", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRINCO.RowCount

            cmdVALIDAR.Enabled = True
            cmdVALIDAR.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description & dt.Rows(j).Item("FIPRNUFI"))
            MessageBox.Show(Err.Description & dt.Rows(i).Item("FIPRNUFI"))
            cmdVALIDAR.Enabled = True
        End Try

    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
        txtFIPRFIIN.Focus()

    End Sub
    Private Sub cmdIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIMPRIMIR.Click
        ' PrintDialog permite al usuario seleccionar la impresora en la que desea imprimir, 
        ' además de otras opciones de impresión.

        PrintDialog1.Document = PrintDocument1
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.Print()
        End If

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        pro_LimpiarCampos()
        txtFIPRFIIN.Focus()
        Me.Close()
    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try
            If Me.dgvFIPRINCO.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvFIPRINCO.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarPlano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.Click
        Try

            If dgvFIPRINCO.RowCount > 0 Then

                ' crea la instancia para crear y salvar
                Dim oCrear As New SaveFileDialog

                oCrear.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                oCrear.Filter = "Archivo de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*" 'Colocar varias extensiones
                oCrear.FilterIndex = 1 'coloca por defecto el *.txt
                oCrear.ShowDialog() 'abre la caja de dialogo para guardar


                ' si existe una ruta seleccionada
                If Trim(oCrear.FileName) <> "" Then

                    ' lleba la ruta al label
                    'txtRUTA.Text = oCrear.FileName

                    ' se carga el stSeparador
                    stSeparador = Trim(txtSEPARADOR.Text)

                    'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas
                    Using archivo As StreamWriter = New StreamWriter(oCrear.FileName)

                        ' variable para almacenar la línea actual del dataview
                        Dim linea As String = String.Empty

                        With dgvFIPRINCO
                            ' Recorrer las filas del dataGridView
                            For fila As Integer = 0 To .RowCount - 1
                                ' vaciar la línea
                                linea = String.Empty

                                ' Recorrer la cantidad de columnas que contiene el dataGridView
                                For col As Integer = 0 To .Columns.Count - 1
                                    ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
                                    linea = linea & Trim(.Item(col, fila).Value.ToString) & stSeparador
                                Next

                                ' Escribir una línea con el método WriteLine
                                With archivo
                                    ' eliminar el último caracter ";" de la cadena
                                    linea = linea.Remove(linea.Length - 1).ToString
                                    ' escribir la fila
                                    .WriteLine(linea.ToString)
                                End With
                            Next
                        End With
                    End Using

                    MessageBox.Show("Plano generado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    If MessageBox.Show("¿ Desea abrir el archivo plano ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        ' Abrir con Process.Start el archivo de texto
                        Process.Start(oCrear.FileName)
                    End If

                Else
                    txtFIPRFIIN.Focus()
                End If
            Else
                MessageBox.Show("Ejecute la consulta antes de exportar el plano", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        ' PrintPreviewDialog está asociado a PrintDocument; cuando se procesa la 
        ' vista previa, se desencadena el evento PrintPage. A este evento se pasa un contexto 
        ' gráfico en el que se "dibuja" la página.

        Try
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.ShowDialog()
        Catch exp As Exception
            MsgBox("An error occurred while trying to load the " & _
                "document for Print Preview. Make sure you currently have " & _
                "access to a printer. A printer must be connected and " & _
                "accessible for Print Preview to work.", MsgBoxStyle.OkOnly, _
                 Me.Text)
        End Try

    End Sub
    Private Sub btnPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPageSetup.Click
        ' La configuración de página permite especificar aspectos tales como el tamaño del papel, la orientación vertical, 
        ' horizontal, etc.

        With PageSetupDialog1
            .Document = PrintDocument1
            .PageSettings = PrintDocument1.DefaultPageSettings
        End With

        If PageSetupDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.DefaultPageSettings = PageSetupDialog1.PageSettings
        End If

    End Sub
    Private Sub pdoc_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        '-------------------------------------------------------------------------------------------------------
        '*** ESTE SUB PROGRAMA DEBE COPIAR EN EL FORMULARIO QUE SE INSTALE LOS BOTONES PARA IMPRIMIR ***
        '-----------------------------------------------------------------------------------------------

        'TamanoFuente = "10" 'nudTAMANO.Value 'determina el tamaño de la letra de impresión

        ' Declare una variable que contenga la posición del último carácter impreso. Declárela
        ' como estática para que los siguiente eventos PrintPage puedan hacer referencia a ella.
        Static intCurrentChar As Int32
        ' Inicialice la fuente que se va a utilizar en la impresión.
        Dim font As New Font("Arial", 10)

        Dim intPrintAreaHeight, intPrintAreaWidth, marginLeft, marginTop As Int32
        With PrintDocument1.DefaultPageSettings
            ' Inicialice variables locales que contengan los límites del rectángulo del 
            ' área de impresión.
            intPrintAreaHeight = .PaperSize.Height - .Margins.Top - .Margins.Bottom
            intPrintAreaWidth = .PaperSize.Width - .Margins.Left - .Margins.Right

            ' Inicialice variables locales que contengan los valores de margen que servirán
            ' de coordenadas X e Y para la esquina superior izquierda del rectángulo 
            ' del área de impresión.
            marginLeft = .Margins.Left ' Coordenada X
            marginTop = .Margins.Top ' Coordenada Y
        End With

        ' Si el usuario ha seleccionado el modo Horizontal, cambie el alto y el ancho 
        ' del área de impresión.
        If PrintDocument1.DefaultPageSettings.Landscape Then
            Dim intTemp As Int32
            intTemp = intPrintAreaHeight
            intPrintAreaHeight = intPrintAreaWidth
            intPrintAreaWidth = intTemp
        End If

        ' Calcule el número total de líneas en el documento a partir del alto del
        ' área de impresión y del alto de la fuente.
        Dim intLineCount As Int32 = CInt(intPrintAreaHeight / font.Height)
        ' Inicialice la estructura del rectángulo que define el área de impresión.
        Dim rectPrintingArea As New RectangleF(marginLeft, marginTop, intPrintAreaWidth, intPrintAreaHeight)

        ' Cree una instancia de la clase StringFormat, que encapsula la información de diseño 
        ' del texto (como la alineación y el espaciado de las líneas ), muestra las manipulaciones 
        ' (como la inserción de puntos suspensivos y la sustitución de dígitos nacionales) y las características de 
        ' OpenType. El uso de StringFormat permite que MeasureString y DrawString utilicen
        ' sólo un número entero de líneas al imprimir cada página, omitiendo las líneas
        ' parciales que probablemente se imprimirían si el número de líneas por 
        ' página no se dividiera exactamente para cada página (lo que ocurre habitualmente).
        ' Consulte la documentación del SDK sobre StringFormatFlags para obtener más información.
        Dim fmt As New StringFormat(StringFormatFlags.LineLimit)
        ' Llame a MeasureString para determinar el número de caracteres que caben en
        ' el rectángulo del área de impresión. A CharFitted Int32 se pasa ByRef y se utiliza
        ' más adelante cuando se calcula intCurrentChar y, por tanto, HasMorePages. LinesFilled 
        ' no es necesario para este ejemplo, pero debe pasarse cuando se pasa CharsFitted.
        ' Mid se utiliza para pasar el segmento de texto restante que queda de la 
        ' página anterior impresa (recuerde que intCurrentChar se declaró como 
        ' estática).
        Dim intLinesFilled, intCharsFitted As Int32
        e.Graphics.MeasureString(Mid(txtFIPRINCO.Text, intCurrentChar + 1), font, _
                    New SizeF(intPrintAreaWidth, intPrintAreaHeight), fmt, _
                    intCharsFitted, intLinesFilled)

        ' Imprima el texto en la página.
        e.Graphics.DrawString(Mid(txtFIPRINCO.Text, intCurrentChar + 1), font, _
            Brushes.Black, rectPrintingArea, fmt)

        ' Haga avanzar el carácter actual hasta el último carácter impreso de esta página. Como 
        ' intCurrentChar es una variable estática, su valor se puede utilizar para la página
        ' siguiente que se va a imprimir. Aumenta en 1 y se pasa a Mid() para imprimir la
        ' página siguiente (vea MeasureString() más arriba).
        intCurrentChar += intCharsFitted

        ' HasMorePages indica al módulo de impresión si debe desencadenarse otro
        ' evento PrintPage.
        If intCurrentChar < txtFIPRINCO.Text.Length Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            ' Debe restablecer explícitamente intCurrentChar ya que es estática.
            intCurrentChar = 0
        End If
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_REPO_FIPRINCO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strBARRESTA.Items(2).Text = "Registros : 0"
    End Sub

#End Region

#Region "Timer1"

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If inProceso = inTotalRegistros Then
            inProceso = 0
            Timer1.Enabled = False
        End If

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
            txtFIPRTIFI.Focus()
        End If
    End Sub
    Private Sub txtFIPRTIFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRTIFI.KeyPress
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
                        txtFIPRCLSE.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCLSE.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        cmdVALIDAR.Focus()
                    End If
                End If
            End If
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
    Private Sub txtFIPRTIFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRTIFI.GotFocus
        txtFIPRTIFI.SelectionStart = 0
        txtFIPRTIFI.SelectionLength = Len(txtFIPRTIFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRTIFI.AccessibleDescription
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
    Private Sub txtFIPRINCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        strBARRESTA.Items(0).Text = txtFIPRINCO.AccessibleDescription
    End Sub
    Private Sub cmdVALIDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdVALIDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdVALIDAR.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub cmdIMPRIMIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdIMPRIMIR.GotFocus
        strBARRESTA.Items(0).Text = cmdIMPRIMIR.AccessibleDescription
    End Sub
    Private Sub btnPrintPreview_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintPreview.GotFocus
        strBARRESTA.Items(0).Text = btnPrintPreview.AccessibleDescription
    End Sub
    Private Sub btnPageSetup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPageSetup.GotFocus
        strBARRESTA.Items(0).Text = btnPageSetup.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub cmdExportarExcel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.GotFocus
        strBARRESTA.Items(0).Text = cmdExportarExcel.AccessibleDescription
    End Sub
    Private Sub cmdExportarPlano_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.GotFocus
        strBARRESTA.Items(0).Text = cmdExportarPlano.AccessibleDescription
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
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRFIFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIFI.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRFIFI.Text)) = True Then
            Me.txtFIPRFIFI.Text = Val(Trim(Me.txtFIPRFIFI.Text))
        Else
            Me.txtFIPRFIFI.Focus()
            mod_MENSAJE.Inco_Valo_Nume()
        End If
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRTIFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRTIFI.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRTIFI.Text)) = True Then
            Me.txtFIPRTIFI.Text = Val(Trim(Me.txtFIPRTIFI.Text))
        Else
            Me.txtFIPRTIFI.Focus()
            mod_MENSAJE.Inco_Valo_Nume()
        End If

        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.Validated
        txtFIPRMUNI.Text = fun_Formato_Mascara_3_String(txtFIPRMUNI.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.Validated
        txtFIPRCORR.Text = fun_Formato_Mascara_2_String(txtFIPRCORR.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.Validated
        txtFIPRBARR.Text = fun_Formato_Mascara_3_String(txtFIPRBARR.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.Validated
        txtFIPRMANZ.Text = fun_Formato_Mascara_3_String(txtFIPRMANZ.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.Validated
        txtFIPRPRED.Text = fun_Formato_Mascara_5_String(txtFIPRPRED.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.Validated
        txtFIPREDIF.Text = fun_Formato_Mascara_3_String(txtFIPREDIF.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.Validated
        txtFIPRUNPR.Text = fun_Formato_Mascara_5_String(txtFIPRUNPR.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "CheckedChanged"

    Private Sub rbdImagenConstruccion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdImagenConstruccion.CheckedChanged, rbdHomonimoCedula.CheckedChanged, rbdHomonimosNombre.CheckedChanged, rbdMatriculas.CheckedChanged, rbdPrediosConRA.CheckedChanged

        If Me.rbdImagenConstruccion.Checked = True Then
            Me.rbdEnrutarImagenCalificacion.Visible = True
            Me.rbdEnrutarImagenCroquis.Visible = True
            Me.rbdListadoDeRuta.Visible = True

        ElseIf Me.rbdImagenConstruccion.Checked = False Then
            Me.rbdEnrutarImagenCalificacion.Visible = False
            Me.rbdEnrutarImagenCroquis.Visible = False
            Me.rbdListadoDeRuta.Visible = False
        Else
            Me.rbdEnrutarImagenCalificacion.Visible = False
            Me.rbdEnrutarImagenCroquis.Visible = False
            Me.rbdListadoDeRuta.Visible = False
        End If

    End Sub
    Private Sub chkProcesos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProcesos.CheckedChanged

        If Me.chkProcesos.Checked = True Then
            Me.cboProcesos.Visible = True
        Else
            Me.cboProcesos.Visible = False
        End If

    End Sub
#End Region

#End Region

End Class