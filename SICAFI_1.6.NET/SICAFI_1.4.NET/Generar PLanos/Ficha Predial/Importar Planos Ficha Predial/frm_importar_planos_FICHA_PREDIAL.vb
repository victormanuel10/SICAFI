Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_importar_planos_FICHA_PREDIAL

    '================================================
    '*** FORMULARIO IMPORTAR PLANOS FICHA PREDIAL ***
    '================================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_importar_planos_FICHA_PREDIAL
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_importar_planos_FICHA_PREDIAL
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

#Region "VARIABLES"

    Dim oLeer As New OpenFileDialog

    ' crea los objetos datatable
    Dim dt_RESOLUCI As New DataTable
    Dim dt_FICHPRED As New DataTable
    Dim dt_FICHRES1 As New DataTable
    Dim dt_FICHRES2 As New DataTable
    Dim dt_FIPRDEEC As New DataTable
    Dim dt_FIPRPROP As New DataTable
    Dim dt_FIPRCONS As New DataTable
    Dim dt_FIPRCACO As New DataTable
    Dim dt_FIPRLIND As New DataTable
    Dim dt_FIPRCART As New DataTable

    ' otros procesos
    Dim stRutaArchivo As String
    Dim stSeparador As String
    Dim inTotalRegistros As Integer
    Dim stRESOLUCION As String
    Dim inProceso As Integer

    ' variables ficha predial
    Dim vl_inFIPRNURE As Integer
    Dim vl_stFIPRCORE As String
    Dim vl_stFIPRCECA As String

    ' variables ficha resumen
    Dim vl_inFIRENUFI As Integer

    ' variables locales de la resolucion
    Dim vl_stRESODEPA As String
    Dim vl_stRESOMUNI As String
    Dim vl_inRESOVIGE As Integer
    Dim vl_inRESOTIRE As Integer
    Dim vl_inRESORESO As Integer
    Dim vl_inRESOCLSE As Integer

    ' varables locales del municipio
    Dim vl_inMUNIRAIN As Integer = 0
    Dim vl_inMUNIRAFI As Integer = 0

    ' variables locales para ficha predial
    Dim vl_inFIPRNUFI As Integer
    Dim vl_stFIPRMUNI As String
    Dim vl_stFIPRCORR As String
    Dim vl_stFIPRBARR As String
    Dim vl_stFIPRMANZ As String
    Dim vl_stFIPRPRED As String
    Dim vl_stFIPREDIF As String
    Dim vl_stFIPRUNPR As String

    ' variables locales para inconsistencias
    Dim vl_stFPINCODI As String
    Dim vl_stFPINDESC As String

    ' variable contador de registros totales
    Dim a As Integer
    Dim boPredioNuevo As Boolean = False

    ' variables de conexion
    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

    ' sw de consulta a la base de datos
    Private bySW As Byte = 0
    Private bySWResumen As Byte = 0

#End Region

#Region "FUNCIONES"

    Private Function fun_BuscarNroSecuenciaDestinacionEconomica(ByVal inFPDENUFI As Integer) As Integer
        Dim inFPDESECU As Integer = 0

        Dim objdatos5 As New cla_FIPRDEEC
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRDEEC_X_FICHA_PREDIAL(Val(inFPDENUFI))

        If tbl10.Rows.Count = 0 Then
            inFPDESECU = 1
        Else
            Dim i As Integer
            Dim NroMayor As Integer
            Dim Posicion As Integer

            Posicion = Val(tbl10.Rows(0).Item("FPDESECU"))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item("FPDESECU"))

                If NroMayor > Posicion Then
                    inFPDESECU = NroMayor
                    Posicion = NroMayor
                Else
                    inFPDESECU = Posicion
                End If
            Next
            inFPDESECU = inFPDESECU + 1
        End If

        Return inFPDESECU

    End Function
    Private Function fun_BuscarNroSecuenciaPropietario(ByVal inFPPRNUFI As Integer) As Integer
        Dim inSECUENCIA As Integer = 0

        ' busca el numero de secuencia de la base datos
        Dim objdatos5 As New cla_FIPRPROP
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRPROP_X_FICHA_PREDIAL(Val(inFPPRNUFI))

        If tbl10.Rows.Count = 0 Then
            inSECUENCIA = 1
        Else
            ' asigna el numero de secuencia
            Dim i As Integer
            Dim NroMayor As Integer = 0
            Dim Posicion As Integer = 0

            Posicion = Val(tbl10.Rows(0).Item("FPPRSECU"))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item("FPPRSECU"))

                If NroMayor > Posicion Then
                    inSECUENCIA = NroMayor
                    Posicion = NroMayor
                Else
                    inSECUENCIA = Posicion
                End If
            Next

            inSECUENCIA = inSECUENCIA + 1
        End If

        Return inSECUENCIA

    End Function
    Private Function fun_BuscarNroSecuenciaConstruccion(ByVal inFPCONUFI As Integer) As Integer
        Dim inSECUENCIA As Integer = 0

        Dim objdatos5 As New cla_FIPRCONS
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRCONS_X_FICHA_PREDIAL(Val(inFPCONUFI))

        If tbl10.Rows.Count = 0 Then
            inSECUENCIA = 1
        Else
            Dim i As Integer
            Dim NroMayor As Integer
            Dim Posicion As Integer

            Posicion = Val(tbl10.Rows(0).Item("FPCOSECU"))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item("FPCOSECU"))

                If NroMayor > Posicion Then
                    inSECUENCIA = NroMayor
                    Posicion = NroMayor
                Else
                    inSECUENCIA = Posicion
                End If
            Next
            inSECUENCIA = inSECUENCIA + 1
        End If

        Return inSECUENCIA

    End Function
    Private Function fun_BuscarNroSecuenciaLindero(ByVal inFPLINUFI As Integer) As Integer
        Dim inSECUENCIA As Integer = 0

        Dim objdatos5 As New cla_FIPRLIND
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRLIND_X_FICHA_PREDIAL(Val(inFPLINUFI))

        If tbl10.Rows.Count = 0 Then
            inSECUENCIA = 1
        Else
            Dim i As Integer
            Dim NroMayor As Integer
            Dim Posicion As Integer

            Posicion = Val(tbl10.Rows(0).Item("FPLISECU"))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item("FPLISECU"))

                If NroMayor > Posicion Then
                    inSECUENCIA = NroMayor
                    Posicion = NroMayor
                Else
                    inSECUENCIA = Posicion
                End If
            Next
            inSECUENCIA = inSECUENCIA + 1
        End If

        Return inSECUENCIA

    End Function
    Private Function fun_BuscarNroSecuenciaCartografia(ByVal inFPCANUFI As Integer) As Integer
        Dim inSECUENCIA As Integer = 0

        Dim objdatos5 As New cla_FIPRCART
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRCART_X_FICHA_PREDIAL(Val(inFPCANUFI))

        If tbl10.Rows.Count = 0 Then
            inSECUENCIA = 1
        Else
            Dim i As Integer
            Dim NroMayor As Integer
            Dim Posicion As Integer

            Posicion = Val(tbl10.Rows(0).Item("FPCASECU"))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item("FPCASECU"))

                If NroMayor > Posicion Then
                    inSECUENCIA = NroMayor
                    Posicion = NroMayor
                Else
                    inSECUENCIA = Posicion
                End If
            Next
            inSECUENCIA = inSECUENCIA + 1
        End If

        Return inSECUENCIA

    End Function
    Private Function fun_BuscarNroSecuenciaZonaEconomica(ByVal inFPZENUFI As Integer) As Integer
        Dim inFPZESECU As Integer = 0

        Dim objdatos5 As New cla_FIPRZOEC
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRZOEC_X_FICHA_PREDIAL(Val(inFPZENUFI))

        If tbl10.Rows.Count = 0 Then
            inFPZESECU = 1
        Else
            Dim i As Integer
            Dim NroMayor As Integer
            Dim Posicion As Integer

            Posicion = Val(tbl10.Rows(0).Item("FPZESECU"))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item("FPZESECU"))

                If NroMayor > Posicion Then
                    inFPZESECU = NroMayor
                    Posicion = NroMayor
                Else
                    inFPZESECU = Posicion
                End If
            Next
            inFPZESECU = inFPZESECU + 1
        End If

        Return inFPZESECU

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.dgvFIPRINCO.DataSource = New DataTable
        Me.dgvFIREINCO.DataSource = New DataTable

        Me.lblAbrirArchivoResolucionActualizacion.Text = ""
        Me.lblAbrirArchivoResolucionAdministrativa.Text = ""
        Me.strBARRESTA.Items(2).Text = "Registros: 0"

        Me.cmdValidaDatosResolucionActualizacion.Enabled = False
        Me.cmdGrabarDatosResolucionActualizacion.Enabled = False
        Me.lblFecha2ResolucionActualizacion.Visible = False

        Me.cmdValidaDatosResolucionAdministrativa.Enabled = False
        Me.cmdGrabarDatosResolucionAdministrativa.Enabled = False
        Me.lblFecha2ResolucionAdministrativa.Visible = False

        Me.txtREACDEPA.Text = ""
        Me.txtREACMUNI.Text = ""
        Me.txtREACTIRE.Text = ""
        Me.txtREACVIGE.Text = ""
        Me.txtREACCLSE.Text = ""
        Me.txtREACRESO.Text = ""
        Me.lblREACDEPA.Text = ""
        Me.lblREACMUNI.Text = ""
        Me.lblREACTIRE.Text = ""
        Me.lblREACVIGE.Text = ""
        Me.lblREACCLSE.Text = ""
        Me.lblREACRESO.Text = ""

        Me.txtREADDEPA.Text = ""
        Me.txtREADMUNI.Text = ""
        Me.txtREADTIRE.Text = ""
        Me.txtREADVIGE.Text = ""
        Me.txtREADCLSE.Text = ""
        Me.txtREADRESO.Text = ""
        Me.lblREADDEPA.Text = ""
        Me.lblREADMUNI.Text = ""
        Me.lblREADTIRE.Text = ""
        Me.lblREADVIGE.Text = ""
        Me.lblREADCLSE.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registro : 0"


    End Sub
    Private Sub pro_ExportarPlano(ByVal dtl As DataTable)
        Try
            Me.dgvFIPRINCO.DataSource = dtl

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
                    Me.cmdExportarPlano.Focus()
                End If
            Else
                MessageBox.Show("Ejecute la consulta antes de exportar el plano", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_AsignarNumeroDeRegistroResolucionActualizacion()

        Try
            If bySW = 0 Then

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

                ' declara las variables
                vl_stRESODEPA = Trim(Me.txtREACDEPA.Text)
                vl_stRESOMUNI = Trim(Me.txtREACMUNI.Text)
                vl_inRESOTIRE = Trim(Me.txtREACTIRE.Text)
                vl_inRESOVIGE = Trim(Me.txtREACVIGE.Text)
                vl_inRESOCLSE = Trim(Me.txtREACCLSE.Text)
                vl_inRESORESO = Trim(Me.txtREACRESO.Text)

                ' parametros de la consulta
                Dim ParametrosConsulta As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Select "
                ParametrosConsulta += "max(FiprNure) as FiprNure "
                ParametrosConsulta += "From FichPred where "
                ParametrosConsulta += "FiprDepa like '" & vl_stRESODEPA & "' and "
                ParametrosConsulta += "FiprMuni like '" & vl_stRESOMUNI & "' and "
                ParametrosConsulta += "FiprTire like '" & vl_inRESOTIRE & "' and "
                ParametrosConsulta += "FiprVige like '" & vl_inRESOVIGE & "' and "
                ParametrosConsulta += "FiprClse like '" & vl_inRESOCLSE & "' and "
                ParametrosConsulta += "FiprReso like '" & vl_inRESORESO & "' "

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

                If dt.Rows.Count > 0 Then

                    Dim stNUMEFIPR As String = dt.Rows(0).Item("FiprNure").ToString

                    If fun_Verificar_Dato_Numerico_Evento_Validated(stNUMEFIPR) = False Then
                        vl_inFIPRNURE = 1
                    Else
                        vl_inFIPRNURE = Val(dt.Rows(0).Item("FiprNure")) + 1
                    End If

                End If

                bySW = 1

            Else

                ' incrementa la veriable
                vl_inFIPRNURE += 1

            End If



        Catch ex As Exception
            MessageBox.Show(Err.Description & ". Error en numero de regiso de ficha predial")
        End Try

    End Sub
    Private Sub pro_AsignarNumeroDeRegistroResolucionAdministrativa()

        Try
            If bySW = 0 Then

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

                ' declara las variables
                vl_stRESODEPA = Trim(Me.txtREADDEPA.Text)
                vl_stRESOMUNI = Trim(Me.txtREADMUNI.Text)
                vl_inRESOTIRE = Trim(Me.txtREADTIRE.Text)
                vl_inRESOVIGE = Trim(Me.txtREADVIGE.Text)
                vl_inRESOCLSE = Trim(Me.txtREADCLSE.Text)
                vl_inRESORESO = Trim(Me.txtREADRESO.Text)

                ' parametros de la consulta
                Dim ParametrosConsulta As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Select "
                ParametrosConsulta += "max(FiprNure) as FiprNure "
                ParametrosConsulta += "From FichPred where "
                ParametrosConsulta += "FiprDepa like '" & vl_stRESODEPA & "' and "
                ParametrosConsulta += "FiprMuni like '" & vl_stRESOMUNI & "' and "
                ParametrosConsulta += "FiprTire like '" & vl_inRESOTIRE & "' and "
                ParametrosConsulta += "FiprVige like '" & vl_inRESOVIGE & "' and "
                ParametrosConsulta += "FiprClse like '" & vl_inRESOCLSE & "' and "
                ParametrosConsulta += "FiprReso like '" & vl_inRESORESO & "' "

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

                    Dim stNUMEFIPR As String = dt.Rows(0).Item("FiprNure").ToString

                    If fun_Verificar_Dato_Numerico_Evento_Validated(stNUMEFIPR) = False Then
                        vl_inFIPRNURE = 1
                    Else
                        vl_inFIPRNURE = Val(dt.Rows(0).Item("FiprNure")) + 1
                    End If

                End If

                bySW = 1

            Else

                ' incrementa la veriable
                vl_inFIPRNURE += 1

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & ". Error en numero de regiso de ficha predial")
        End Try

    End Sub

    Private Sub pro_AsignarNumeroDeFichaResumen()

        Try
            If bySWResumen = 0 Then

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
                ParametrosConsulta += "max(FiprNufi) "
                ParametrosConsulta += "From FichPred "

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

                vl_inFIRENUFI = Val(dt.Rows(0).Item(0)) + 1

                If vl_inFIRENUFI < 999000000 Then
                    vl_inFIRENUFI = 999000001
                End If

                bySWResumen = 1

            Else

                ' incrementa la variable
                vl_inFIRENUFI += 1

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & ". Error en numero de regiso de ficha predial")
        End Try

    End Sub
    Private Sub pro_ObtenerResolucionCancatenada()

        Dim stRESODEPA_CODI As String = vl_stRESODEPA
        Dim stRESOMUNI_CODI As String = vl_stRESOMUNI
        Dim stRESOTIRE_CODI As String = vl_inRESOTIRE
        Dim stRESOCLSE_CODI As String = vl_inRESOCLSE
        Dim stRESOVIGE_CODI As String = vl_inRESOVIGE
        Dim stRESORESO_CODI As String = vl_inRESORESO

        stRESODEPA_CODI = stRESODEPA_CODI.PadLeft(2, "0")
        stRESODEPA_CODI = stRESODEPA_CODI.Substring(0, 2)

        stRESOMUNI_CODI = stRESOMUNI_CODI.PadLeft(3, "0")
        stRESOMUNI_CODI = stRESOMUNI_CODI.Substring(0, 3)

        stRESOTIRE_CODI = stRESOTIRE_CODI.PadLeft(3, "0")
        stRESOTIRE_CODI = stRESOTIRE_CODI.Substring(0, 3)

        stRESOCLSE_CODI = stRESOCLSE_CODI.PadLeft(1, "0")
        stRESOCLSE_CODI = stRESOCLSE_CODI.Substring(0, 1)

        stRESOVIGE_CODI = stRESOVIGE_CODI.PadLeft(4, "0")
        stRESOVIGE_CODI = stRESOVIGE_CODI.Substring(0, 4)

        stRESORESO_CODI = stRESORESO_CODI.PadLeft(7, "0")
        stRESORESO_CODI = stRESORESO_CODI.Substring(0, 7)

        vl_stFIPRCORE = stRESODEPA_CODI & stRESOMUNI_CODI & stRESOTIRE_CODI & stRESOCLSE_CODI & stRESOVIGE_CODI & stRESORESO_CODI

    End Sub
    Private Sub pro_ObtenerCedulaCatastralConcatenada(ByVal stFIPRMUNI As String, _
                                                      ByVal stFIPRCORR As String, _
                                                      ByVal stFIPRBARR As String, _
                                                      ByVal stFIPRMANZ As String, _
                                                      ByVal stFIPRPRED As String, _
                                                      ByVal stFIPREDIF As String, _
                                                      ByVal stFIPRUNPR As String, _
                                                      ByVal inFIPRCLSE As String)

        Dim stFIPRCLSE_CODI As String = inFIPRCLSE
        Dim stFIPRMUNI_CODI As String = stFIPRMUNI
        Dim stFIPRCORR_CODI As String = stFIPRCORR
        Dim stFIPRBARR_CODI As String = stFIPRBARR
        Dim stFIPRMANZ_CODI As String = stFIPRMANZ
        Dim stFIPRPRED_CODI As String = stFIPRPRED
        Dim stFIPREDIF_CODI As String = stFIPREDIF
        Dim stFIPRUNPR_CODI As String = stFIPRUNPR

        stFIPRCLSE_CODI = stFIPRCLSE_CODI.PadLeft(1, "0")
        stFIPRCLSE_CODI = stFIPRCLSE_CODI.Substring(0, 1)

        stFIPRMUNI_CODI = stFIPRMUNI_CODI.PadLeft(3, "0")
        stFIPRMUNI_CODI = stFIPRMUNI_CODI.Substring(0, 3)

        stFIPRCORR_CODI = stFIPRCORR_CODI.PadLeft(2, "0")
        stFIPRCORR_CODI = stFIPRCORR_CODI.Substring(0, 2)

        stFIPRBARR_CODI = stFIPRBARR_CODI.PadLeft(3, "0")
        stFIPRBARR_CODI = stFIPRBARR_CODI.Substring(0, 3)

        stFIPRMANZ_CODI = stFIPRMANZ_CODI.PadLeft(3, "0")
        stFIPRMANZ_CODI = stFIPRMANZ_CODI.Substring(0, 3)

        stFIPRPRED_CODI = stFIPRPRED_CODI.PadLeft(5, "0")
        stFIPRPRED_CODI = stFIPRPRED_CODI.Substring(0, 5)

        stFIPREDIF_CODI = stFIPREDIF_CODI.PadLeft(3, "0")
        stFIPREDIF_CODI = stFIPREDIF_CODI.Substring(0, 3)

        stFIPRUNPR_CODI = stFIPRUNPR_CODI.PadLeft(5, "0")
        stFIPRUNPR_CODI = stFIPRUNPR_CODI.Substring(0, 5)

        vl_stFIPRCECA = stFIPRCLSE_CODI & stFIPRMUNI_CODI & stFIPRCORR_CODI & stFIPRBARR_CODI & stFIPRMANZ_CODI & stFIPRPRED_CODI & stFIPREDIF_CODI & stFIPRUNPR_CODI

    End Sub
    Private Sub pro_GrabarInconsistencia(ByVal stCODIGO As String, ByVal stDESCRIPCION As String)

        Dim objdatos1 As New cla_VALIFIPR

        objdatos1.fun_Insertar_FIPRINCO(vl_inFIPRNUFI, _
                                        stCODIGO, _
                                        stDESCRIPCION, _
                                        vl_stFIPRMUNI, _
                                        vl_stFIPRCORR, _
                                        vl_stFIPRBARR, _
                                        vl_stFIPRMANZ, _
                                        vl_stFIPRPRED, _
                                        vl_stFIPREDIF, _
                                        vl_stFIPRUNPR, _
                                        vl_inRESOCLSE, _
                                        stRESOLUCION)

    End Sub
    Private Sub pro_ActualizarFichaPredial(ByVal inFPPRNUFI As Integer, _
                                           ByVal inFPPRMOAD As Integer, _
                                           ByVal inFPPRLITI As Integer, _
                                           ByVal stFPPRPOLI As String)

        ' buscar cadena de conexion
        Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
        Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

        ' crear conexión
        oAdapter = New SqlDataAdapter
        oConexion = New SqlConnection(stCadenaConexion)

        ' abre la conexion
        oConexion.Open()

        ' variables
        Dim inFIPRNUFI As Integer = inFPPRNUFI
        Dim inFIPRMOAD As Integer = inFPPRMOAD
        Dim inFIPRLITI As Integer = 0
        Dim stFIPRPOLI As String = stFPPRPOLI

        If inFPPRLITI = 2 Then
            inFIPRLITI = 0
        Else
            inFIPRLITI = 1
        End If

        ' parametros de la consulta
        Dim ParametrosConsulta As String = ""

        ' Concatena la condicion de la consulta
        ParametrosConsulta += "update FICHPRED "
        ParametrosConsulta += "set FIPRMOAD = '" & inFIPRMOAD & "', "
        ParametrosConsulta += "FIPRLITI = '" & inFIPRLITI & "', "
        ParametrosConsulta += "FIPRPOLI = '" & stFIPRPOLI & "' "
        ParametrosConsulta += "where FIPRNUFI = '" & inFIPRNUFI & "'"

        ' ejecuta la consulta
        oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

        ' procesa la consulta 
        oEjecutar.CommandTimeout = 360
        oEjecutar.CommandType = CommandType.Text
        oReader = oEjecutar.ExecuteReader

        ' cierra la conexion
        oConexion.Close()
        oReader = Nothing

    End Sub

    Private Sub pro_ValidarFichaPredialResolucionActualizacion()

        ' limpia los datagrigview
        Me.dgvFIPRINCO.DataSource = New DataTable
        Me.dgvFIREINCO.DataSource = New DataTable

        stRESOLUCION = Me.txtREACMUNI.Text & Me.txtREACVIGE.Text & Me.txtREACTIRE.Text & Me.txtREACRESO.Text & Me.txtREACCLSE.Text

        ' instancia la clase
        Dim objdatos11 As New cla_VALIFIPR
        'Dim tbl11 As New DataTable

        ' elimina las inconsistencias
        objdatos11.fun_Eliminar_FIPRINCO_X_RESOLUCION(Trim(stRESOLUCION))

        ' abre el archivo
        FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

        ' almacena la linea
        Dim stContenidoLinea As String = ""
        Dim stContenidoRegistro As String = ""
        Dim inNroDeCaracteresLindero As Integer = 0
        Dim inNroDeCaracteresCartografia As Integer = 0
        Dim stNroDeFichaPredial As String = ""

        Dim boPlanoSicafi As Boolean = Me.chkInsertarMaestrosResolucionActualizacion.Checked
        Dim boFichaOVC As Boolean = Me.chkFichasOVCResolucionActualizacion.Checked

        ' Valores predeterminados ProgressBar
        inProceso = 0
        pbProcesoResolucionActualizacion.Value = 0
        pbProcesoResolucionActualizacion.Maximum = inTotalRegistros + 1
        Timer1.Enabled = True

        ' recorre el archivo plano y repita hasta que se acabe las lineas
        Do Until EOF(1)

            ' extrae la linea
            stContenidoLinea = LineInput(1)

            ' verifica cual es el registro de la tabla
            stContenidoRegistro = stContenidoLinea.Substring(0, 1).ToString

            ' optiene la longitud de la linea
            If stContenidoRegistro = "7" Then
                inNroDeCaracteresLindero = stContenidoLinea.Length.ToString - 31
            End If

            If stContenidoRegistro = "8" Then
                inNroDeCaracteresCartografia = stContenidoLinea.Length.ToString - 142
            End If

            ' crea tablas
            dt_RESOLUCI = New DataTable
            dt_FICHPRED = New DataTable
            dt_FIPRDEEC = New DataTable
            dt_FIPRPROP = New DataTable
            dt_FIPRCONS = New DataTable
            dt_FIPRCACO = New DataTable
            dt_FIPRLIND = New DataTable
            dt_FIPRCART = New DataTable


            ' Tabla RESOLUCION
            If stContenidoRegistro = "1" Then

                Dim dr_RESOLUCI As DataRow

                ' TABLA RESOLUCION
                dt_RESOLUCI.Columns.Add(New DataColumn("RESOIDRE", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESOVIGE", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESOTIRE", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESORESO", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESOMUNI", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESOCLSE", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESONURE", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESOARTE", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESOARCO", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESOSUPU", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESOPATO", GetType(String)))

                dr_RESOLUCI = dt_RESOLUCI.NewRow()

                dr_RESOLUCI("RESOIDRE") = stContenidoLinea.Substring(0, 1).ToString
                dr_RESOLUCI("RESOVIGE") = stContenidoLinea.Substring(1, 4).ToString
                dr_RESOLUCI("RESOTIRE") = stContenidoLinea.Substring(5, 3).ToString
                dr_RESOLUCI("RESORESO") = stContenidoLinea.Substring(8, 7).ToString
                dr_RESOLUCI("RESOMUNI") = stContenidoLinea.Substring(15, 3).ToString
                dr_RESOLUCI("RESOCLSE") = stContenidoLinea.Substring(18, 1).ToString
                dr_RESOLUCI("RESONURE") = stContenidoLinea.Substring(19, 7).ToString
                dr_RESOLUCI("RESOARTE") = stContenidoLinea.Substring(26, 12).ToString
                dr_RESOLUCI("RESOARCO") = stContenidoLinea.Substring(38, 10).ToString
                dr_RESOLUCI("RESOSUPU") = stContenidoLinea.Substring(48, 10).ToString
                dr_RESOLUCI("RESOPATO") = stContenidoLinea.Substring(58, 1).ToString

                dt_RESOLUCI.Rows.Add(dr_RESOLUCI)

                ' almacena el numero de ficha predial
                stNroDeFichaPredial = stRESOLUCION

                ' valida los datos cargados
                pro_VALIDAR_CARGA_FICHA_PREDIAL(dt_RESOLUCI, dt_FICHPRED, dt_FIPRDEEC, dt_FIPRPROP, dt_FIPRCONS, dt_FIPRCACO, dt_FIPRLIND, dt_FIPRCART, stRESOLUCION, stNroDeFichaPredial, boPlanoSicafi, boFichaOVC)

            End If

            ' Tabla FICHPRED
            If stContenidoRegistro = "2" Then

                Dim dr_FICHPRED As DataRow

                ' TABLA FICHPRED
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRIDRE", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRVIGE", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRTIRE", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRRESO", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRNUFI", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRNURE", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRMUNI", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRCLSE", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRCORR", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRBARR", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRMANZ", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRPRED", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPREDIF", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRUNPR", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRARTE", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRDIRE", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRCAPR", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRCASU", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRCOPR", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRCOED", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRMUAN", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRCSAN", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRCOAN", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRBAAN", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRMAAN", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRPRAN", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPREDAN", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRUPAN", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("FIPRCASA", GetType(String)))

                dr_FICHPRED = dt_FICHPRED.NewRow()

                dr_FICHPRED("FIPRIDRE") = stContenidoLinea.Substring(0, 1).ToString
                dr_FICHPRED("FIPRVIGE") = stContenidoLinea.Substring(1, 4).ToString
                dr_FICHPRED("FIPRTIRE") = stContenidoLinea.Substring(5, 3).ToString
                dr_FICHPRED("FIPRRESO") = stContenidoLinea.Substring(8, 7).ToString
                dr_FICHPRED("FIPRNUFI") = stContenidoLinea.Substring(15, 9).ToString
                dr_FICHPRED("FIPRNURE") = stContenidoLinea.Substring(24, 5).ToString
                dr_FICHPRED("FIPRMUNI") = stContenidoLinea.Substring(29, 3).ToString
                dr_FICHPRED("FIPRCLSE") = stContenidoLinea.Substring(32, 1).ToString
                dr_FICHPRED("FIPRCORR") = stContenidoLinea.Substring(33, 3).ToString
                dr_FICHPRED("FIPRBARR") = stContenidoLinea.Substring(36, 3).ToString
                dr_FICHPRED("FIPRMANZ") = stContenidoLinea.Substring(39, 3).ToString
                dr_FICHPRED("FIPRPRED") = stContenidoLinea.Substring(42, 5).ToString
                dr_FICHPRED("FIPREDIF") = stContenidoLinea.Substring(47, 5).ToString
                dr_FICHPRED("FIPRUNPR") = stContenidoLinea.Substring(52, 5).ToString
                dr_FICHPRED("FIPRARTE") = stContenidoLinea.Substring(57, 10).ToString
                dr_FICHPRED("FIPRDIRE") = stContenidoLinea.Substring(67, 49).ToString
                dr_FICHPRED("FIPRCAPR") = stContenidoLinea.Substring(116, 1).ToString
                dr_FICHPRED("FIPRCASU") = stContenidoLinea.Substring(117, 1).ToString
                dr_FICHPRED("FIPRCOPR") = stContenidoLinea.Substring(118, 9).ToString
                dr_FICHPRED("FIPRCOED") = stContenidoLinea.Substring(127, 9).ToString
                dr_FICHPRED("FIPRMUAN") = stContenidoLinea.Substring(136, 3).ToString
                dr_FICHPRED("FIPRCSAN") = stContenidoLinea.Substring(139, 1).ToString
                dr_FICHPRED("FIPRCOAN") = stContenidoLinea.Substring(140, 3).ToString
                dr_FICHPRED("FIPRBAAN") = stContenidoLinea.Substring(143, 3).ToString
                dr_FICHPRED("FIPRMAAN") = stContenidoLinea.Substring(146, 3).ToString
                dr_FICHPRED("FIPRPRAN") = stContenidoLinea.Substring(149, 5).ToString
                dr_FICHPRED("FIPREDAN") = stContenidoLinea.Substring(154, 5).ToString
                dr_FICHPRED("FIPRUPAN") = stContenidoLinea.Substring(159, 5).ToString
                dr_FICHPRED("FIPRCASA") = stContenidoLinea.Substring(164, 1).ToString

                dt_FICHPRED.Rows.Add(dr_FICHPRED)

                ' almacena el numero de ficha predial
                stNroDeFichaPredial = stContenidoLinea.Substring(15, 9).ToString

                ' valida los datos cargados
                pro_VALIDAR_CARGA_FICHA_PREDIAL(dt_RESOLUCI, dt_FICHPRED, dt_FIPRDEEC, dt_FIPRPROP, dt_FIPRCONS, dt_FIPRCACO, dt_FIPRLIND, dt_FIPRCART, stRESOLUCION, stNroDeFichaPredial, Me.chkInsertarMaestrosResolucionActualizacion.Checked, boFichaOVC)

            End If

            ' Tabla FIPRDEEC
            If stContenidoRegistro = "3" Then

                Dim dr_FIPRDEEC As DataRow

                ' TABLA FIPRDEEC
                dt_FIPRDEEC.Columns.Add(New DataColumn("FPDEIDRE", GetType(String)))
                dt_FIPRDEEC.Columns.Add(New DataColumn("FPDEVIGE", GetType(String)))
                dt_FIPRDEEC.Columns.Add(New DataColumn("FPDETIRE", GetType(String)))
                dt_FIPRDEEC.Columns.Add(New DataColumn("FPDERESO", GetType(String)))
                dt_FIPRDEEC.Columns.Add(New DataColumn("FPDENUFI", GetType(String)))
                dt_FIPRDEEC.Columns.Add(New DataColumn("FPDENURE", GetType(String)))
                dt_FIPRDEEC.Columns.Add(New DataColumn("FPDEDEEC", GetType(String)))
                dt_FIPRDEEC.Columns.Add(New DataColumn("FPDEPORC", GetType(String)))

                dr_FIPRDEEC = dt_FIPRDEEC.NewRow()

                dr_FIPRDEEC("FPDEIDRE") = stContenidoLinea.Substring(0, 1).ToString
                dr_FIPRDEEC("FPDEVIGE") = stContenidoLinea.Substring(1, 4).ToString
                dr_FIPRDEEC("FPDETIRE") = stContenidoLinea.Substring(5, 3).ToString
                dr_FIPRDEEC("FPDERESO") = stContenidoLinea.Substring(8, 7).ToString
                dr_FIPRDEEC("FPDENUFI") = stContenidoLinea.Substring(15, 9).ToString
                dr_FIPRDEEC("FPDENURE") = stContenidoLinea.Substring(24, 5).ToString
                dr_FIPRDEEC("FPDEDEEC") = stContenidoLinea.Substring(29, 2).ToString
                dr_FIPRDEEC("FPDEPORC") = stContenidoLinea.Substring(31, 3).ToString

                dt_FIPRDEEC.Rows.Add(dr_FIPRDEEC)

                ' almacena el numero de ficha predial
                stNroDeFichaPredial = stContenidoLinea.Substring(15, 9).ToString

                ' valida los datos cargados
                pro_VALIDAR_CARGA_FICHA_PREDIAL(dt_RESOLUCI, dt_FICHPRED, dt_FIPRDEEC, dt_FIPRPROP, dt_FIPRCONS, dt_FIPRCACO, dt_FIPRLIND, dt_FIPRCART, stRESOLUCION, stNroDeFichaPredial, boPlanoSicafi, boFichaOVC)

            End If

            ' Tabla FIPRPROP
            If stContenidoRegistro = "4" Then

                Dim dr_FIPRPROP As DataRow

                ' TABLA FIPRPROP
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRIDRE", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRVIGE", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRTIRE", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRRESO", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRNUFI", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRNURE", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRTIDO", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRNUDO", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRPRAP", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRNOMB", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRDERE", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRDENO", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRMUNO", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRNOTA", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRESCR", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRFEES", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRFERE", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRTOMO", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRMAIN", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRCAPR", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRGRAV", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRMOAD", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRLITI", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRPOLI", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRSEAP", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRSICO", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRSEXO", GetType(String)))

                dr_FIPRPROP = dt_FIPRPROP.NewRow()

                dr_FIPRPROP("FPPRIDRE") = stContenidoLinea.Substring(0, 1).ToString
                dr_FIPRPROP("FPPRVIGE") = stContenidoLinea.Substring(1, 4).ToString
                dr_FIPRPROP("FPPRTIRE") = stContenidoLinea.Substring(5, 3).ToString
                dr_FIPRPROP("FPPRRESO") = stContenidoLinea.Substring(8, 7).ToString
                dr_FIPRPROP("FPPRNUFI") = stContenidoLinea.Substring(15, 9).ToString
                dr_FIPRPROP("FPPRNURE") = stContenidoLinea.Substring(24, 5).ToString
                dr_FIPRPROP("FPPRTIDO") = stContenidoLinea.Substring(29, 2).ToString
                dr_FIPRPROP("FPPRNUDO") = stContenidoLinea.Substring(31, 14).ToString
                dr_FIPRPROP("FPPRPRAP") = stContenidoLinea.Substring(45, 15).ToString
                dr_FIPRPROP("FPPRNOMB") = stContenidoLinea.Substring(60, 20).ToString
                dr_FIPRPROP("FPPRDERE") = stContenidoLinea.Substring(80, 9).ToString
                dr_FIPRPROP("FPPRDENO") = stContenidoLinea.Substring(89, 2).ToString
                dr_FIPRPROP("FPPRMUNO") = stContenidoLinea.Substring(91, 3).ToString
                dr_FIPRPROP("FPPRNOTA") = stContenidoLinea.Substring(94, 5).ToString
                dr_FIPRPROP("FPPRESCR") = stContenidoLinea.Substring(99, 7).ToString
                dr_FIPRPROP("FPPRFEES") = stContenidoLinea.Substring(106, 10).ToString
                dr_FIPRPROP("FPPRFERE") = stContenidoLinea.Substring(116, 10).ToString
                dr_FIPRPROP("FPPRTOMO") = stContenidoLinea.Substring(126, 3).ToString
                dr_FIPRPROP("FPPRMAIN") = stContenidoLinea.Substring(129, 15).ToString
                dr_FIPRPROP("FPPRCAPR") = stContenidoLinea.Substring(144, 2).ToString
                dr_FIPRPROP("FPPRGRAV") = stContenidoLinea.Substring(146, 1).ToString
                dr_FIPRPROP("FPPRMOAD") = stContenidoLinea.Substring(147, 1).ToString
                dr_FIPRPROP("FPPRLITI") = stContenidoLinea.Substring(148, 1).ToString
                dr_FIPRPROP("FPPRPOLI") = stContenidoLinea.Substring(149, 5).ToString
                dr_FIPRPROP("FPPRSEAP") = stContenidoLinea.Substring(154, 15).ToString
                dr_FIPRPROP("FPPRSICO") = stContenidoLinea.Substring(169, 20).ToString
                dr_FIPRPROP("FPPRSEXO") = stContenidoLinea.Substring(189, 1).ToString

                dt_FIPRPROP.Rows.Add(dr_FIPRPROP)

                ' almacena el numero de ficha predial
                stNroDeFichaPredial = stContenidoLinea.Substring(15, 9).ToString

                ' valida los datos cargados
                pro_VALIDAR_CARGA_FICHA_PREDIAL(dt_RESOLUCI, dt_FICHPRED, dt_FIPRDEEC, dt_FIPRPROP, dt_FIPRCONS, dt_FIPRCACO, dt_FIPRLIND, dt_FIPRCART, stRESOLUCION, stNroDeFichaPredial, boPlanoSicafi, boFichaOVC)


            End If

            ' Tabla FIPRCONS
            If stContenidoRegistro = "5" Then

                Dim dr_FIPRCONS As DataRow

                ' TABLA FIPRCONS
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOIDRE", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOVIGE", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOTIRE", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCORESO", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCONUFI", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCONURE", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOUNID", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOPUNT", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOARCO", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOMEJO", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOLEY", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOTICO", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOACUE", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOTELE", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOALCA", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOENER", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOGAS", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOPISO", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOPOCO", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOEDCO", GetType(String)))

                dr_FIPRCONS = dt_FIPRCONS.NewRow()

                dr_FIPRCONS("FPCOIDRE") = stContenidoLinea.Substring(0, 1).ToString
                dr_FIPRCONS("FPCOVIGE") = stContenidoLinea.Substring(1, 4).ToString
                dr_FIPRCONS("FPCOTIRE") = stContenidoLinea.Substring(5, 3).ToString
                dr_FIPRCONS("FPCORESO") = stContenidoLinea.Substring(8, 7).ToString
                dr_FIPRCONS("FPCONUFI") = stContenidoLinea.Substring(15, 9).ToString
                dr_FIPRCONS("FPCONURE") = stContenidoLinea.Substring(24, 5).ToString
                dr_FIPRCONS("FPCOUNID") = stContenidoLinea.Substring(29, 5).ToString
                dr_FIPRCONS("FPCOPUNT") = stContenidoLinea.Substring(34, 3).ToString
                dr_FIPRCONS("FPCOARCO") = stContenidoLinea.Substring(37, 9).ToString
                dr_FIPRCONS("FPCOMEJO") = stContenidoLinea.Substring(46, 1).ToString
                dr_FIPRCONS("FPCOLEY") = stContenidoLinea.Substring(47, 1).ToString
                dr_FIPRCONS("FPCOTICO") = stContenidoLinea.Substring(48, 3).ToString
                dr_FIPRCONS("FPCOACUE") = stContenidoLinea.Substring(51, 1).ToString
                dr_FIPRCONS("FPCOTELE") = stContenidoLinea.Substring(52, 1).ToString
                dr_FIPRCONS("FPCOALCA") = stContenidoLinea.Substring(53, 1).ToString
                dr_FIPRCONS("FPCOENER") = stContenidoLinea.Substring(54, 1).ToString
                dr_FIPRCONS("FPCOGAS") = stContenidoLinea.Substring(55, 1).ToString
                dr_FIPRCONS("FPCOPISO") = stContenidoLinea.Substring(56, 2).ToString
                dr_FIPRCONS("FPCOPOCO") = stContenidoLinea.Substring(58, 3).ToString
                dr_FIPRCONS("FPCOEDCO") = stContenidoLinea.Substring(61, 4).ToString

                dt_FIPRCONS.Rows.Add(dr_FIPRCONS)

                ' almacena el numero de ficha predial
                stNroDeFichaPredial = stContenidoLinea.Substring(15, 9).ToString

                ' valida los datos cargados
                pro_VALIDAR_CARGA_FICHA_PREDIAL(dt_RESOLUCI, dt_FICHPRED, dt_FIPRDEEC, dt_FIPRPROP, dt_FIPRCONS, dt_FIPRCACO, dt_FIPRLIND, dt_FIPRCART, stRESOLUCION, stNroDeFichaPredial, boPlanoSicafi, boFichaOVC)

            End If

            ' Tabla FIPRCACO
            If stContenidoRegistro = "6" Then

                Dim dr_FIPRCACO As DataRow

                ' TABLA FIPRCACO
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCIDRE", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCVIGE", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCTIRE", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCRESO", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCNUFI", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCNURE", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCUNID", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCTIPO", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCCODI", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCPUNT", GetType(String)))

                dr_FIPRCACO = dt_FIPRCACO.NewRow()

                dr_FIPRCACO("FPCCIDRE") = stContenidoLinea.Substring(0, 1).ToString
                dr_FIPRCACO("FPCCVIGE") = stContenidoLinea.Substring(1, 4).ToString
                dr_FIPRCACO("FPCCTIRE") = stContenidoLinea.Substring(5, 3).ToString
                dr_FIPRCACO("FPCCRESO") = stContenidoLinea.Substring(8, 7).ToString
                dr_FIPRCACO("FPCCNUFI") = stContenidoLinea.Substring(15, 9).ToString
                dr_FIPRCACO("FPCCNURE") = stContenidoLinea.Substring(24, 5).ToString
                dr_FIPRCACO("FPCCUNID") = stContenidoLinea.Substring(29, 5).ToString
                dr_FIPRCACO("FPCCTIPO") = stContenidoLinea.Substring(34, 1).ToString
                dr_FIPRCACO("FPCCCODI") = stContenidoLinea.Substring(35, 4).ToString
                dr_FIPRCACO("FPCCPUNT") = stContenidoLinea.Substring(39, 3).ToString

                dt_FIPRCACO.Rows.Add(dr_FIPRCACO)

                ' almacena el numero de ficha predial
                stNroDeFichaPredial = stContenidoLinea.Substring(15, 9).ToString

                ' valida los datos cargados
                pro_VALIDAR_CARGA_FICHA_PREDIAL(dt_RESOLUCI, dt_FICHPRED, dt_FIPRDEEC, dt_FIPRPROP, dt_FIPRCONS, dt_FIPRCACO, dt_FIPRLIND, dt_FIPRCART, stRESOLUCION, stNroDeFichaPredial, boPlanoSicafi, boFichaOVC)

            End If

            ' Tabla FIPRLIND
            If stContenidoRegistro = "7" Then

                Dim dr_FIPRLIND As DataRow

                ' TABLA FIPRLIND
                dt_FIPRLIND.Columns.Add(New DataColumn("FPLIIDRE", GetType(String)))
                dt_FIPRLIND.Columns.Add(New DataColumn("FPLIVIGE", GetType(String)))
                dt_FIPRLIND.Columns.Add(New DataColumn("FPLITIRE", GetType(String)))
                dt_FIPRLIND.Columns.Add(New DataColumn("FPLIRESO", GetType(String)))
                dt_FIPRLIND.Columns.Add(New DataColumn("FPLINUFI", GetType(String)))
                dt_FIPRLIND.Columns.Add(New DataColumn("FPLINURE", GetType(String)))
                dt_FIPRLIND.Columns.Add(New DataColumn("FPLIPUCA", GetType(String)))
                dt_FIPRLIND.Columns.Add(New DataColumn("FPLICOLI", GetType(String)))

                dr_FIPRLIND = dt_FIPRLIND.NewRow()

                dr_FIPRLIND("FPLIIDRE") = stContenidoLinea.Substring(0, 1).ToString
                dr_FIPRLIND("FPLIVIGE") = stContenidoLinea.Substring(1, 4).ToString
                dr_FIPRLIND("FPLITIRE") = stContenidoLinea.Substring(5, 3).ToString
                dr_FIPRLIND("FPLIRESO") = stContenidoLinea.Substring(8, 7).ToString
                dr_FIPRLIND("FPLINUFI") = stContenidoLinea.Substring(15, 9).ToString
                dr_FIPRLIND("FPLINURE") = stContenidoLinea.Substring(24, 5).ToString
                dr_FIPRLIND("FPLIPUCA") = stContenidoLinea.Substring(29, 2).ToString
                dr_FIPRLIND("FPLICOLI") = stContenidoLinea.Substring(31, inNroDeCaracteresLindero).ToString

                dt_FIPRLIND.Rows.Add(dr_FIPRLIND)

                ' almacena el numero de ficha predial
                stNroDeFichaPredial = stContenidoLinea.Substring(15, 9).ToString

                ' valida los datos cargados
                pro_VALIDAR_CARGA_FICHA_PREDIAL(dt_RESOLUCI, dt_FICHPRED, dt_FIPRDEEC, dt_FIPRPROP, dt_FIPRCONS, dt_FIPRCACO, dt_FIPRLIND, dt_FIPRCART, stRESOLUCION, stNroDeFichaPredial, boPlanoSicafi, boFichaOVC)

            End If

            ' Tabla FIPRCART
            If stContenidoRegistro = "8" Then

                Dim dr_FIPRCART As DataRow

                ' TABLA FIPRCART
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAIDRE", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAVIGE", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCATIRE", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCARESO", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCANUFI", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCANURE", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAPLAN", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAVENT", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAESGR", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAVIGR", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAVUEL", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAFAJA", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAFOTO", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAVIAE", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAAMPL", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAESAE", GetType(String)))

                dr_FIPRCART = dt_FIPRCART.NewRow()

                dr_FIPRCART("FPCAIDRE") = stContenidoLinea.Substring(0, 1).ToString
                dr_FIPRCART("FPCAVIGE") = stContenidoLinea.Substring(1, 4).ToString
                dr_FIPRCART("FPCATIRE") = stContenidoLinea.Substring(5, 3).ToString
                dr_FIPRCART("FPCARESO") = stContenidoLinea.Substring(8, 7).ToString
                dr_FIPRCART("FPCANUFI") = stContenidoLinea.Substring(15, 9).ToString
                dr_FIPRCART("FPCANURE") = stContenidoLinea.Substring(24, 5).ToString
                dr_FIPRCART("FPCAPLAN") = stContenidoLinea.Substring(29, 15).ToString
                dr_FIPRCART("FPCAVENT") = stContenidoLinea.Substring(44, 15).ToString
                dr_FIPRCART("FPCAESGR") = stContenidoLinea.Substring(59, 15).ToString
                dr_FIPRCART("FPCAVIGR") = stContenidoLinea.Substring(74, 4).ToString
                dr_FIPRCART("FPCAVUEL") = stContenidoLinea.Substring(78, 15).ToString
                dr_FIPRCART("FPCAFAJA") = stContenidoLinea.Substring(93, 15).ToString
                dr_FIPRCART("FPCAFOTO") = stContenidoLinea.Substring(108, 15).ToString
                dr_FIPRCART("FPCAVIAE") = stContenidoLinea.Substring(123, 4).ToString
                dr_FIPRCART("FPCAAMPL") = stContenidoLinea.Substring(127, 15).ToString
                dr_FIPRCART("FPCAESAE") = stContenidoLinea.Substring(142, inNroDeCaracteresCartografia).ToString

                dt_FIPRCART.Rows.Add(dr_FIPRCART)

                ' almacena el numero de ficha predial
                stNroDeFichaPredial = stContenidoLinea.Substring(15, 9).ToString

                ' valida los datos cargados
                pro_VALIDAR_CARGA_FICHA_PREDIAL(dt_RESOLUCI, dt_FICHPRED, dt_FIPRDEEC, dt_FIPRPROP, dt_FIPRCONS, dt_FIPRCACO, dt_FIPRLIND, dt_FIPRCART, stRESOLUCION, stNroDeFichaPredial, boPlanoSicafi, boFichaOVC)

            End If

            ' Incrementa la barra
            inProceso = inProceso + 1
            pbProcesoResolucionActualizacion.Value = inProceso

        Loop

        ' consulta las inconsistencas de las fichas validadas
        Dim objdatos As New cla_VALIFIPR
        Dim tbl As New DataTable

        tbl = objdatos.fun_Consultar_INCONSISTENCIA_X_RESOLUCION(stRESOLUCION)

        ' Crea objeto de columnas y registros
        Dim dt1 As New DataTable
        Dim dr1 As DataRow

        ' Crea las columnas
        dt1.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
        dt1.Columns.Add(New DataColumn("Cedula catastral", GetType(String)))
        dt1.Columns.Add(New DataColumn("Codigo incons.", GetType(String)))
        dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))

        Dim i As Integer

        For i = 0 To tbl.Rows.Count - 1

            dr1 = dt1.NewRow()
            dr1("Nro_Ficha") = tbl.Rows(i).Item("FPINNUFI")
            dr1("Cedula catastral") = tbl.Rows(i).Item("FPINMUNI") & "-" & _
                                     tbl.Rows(i).Item("FPINCORR") & "-" & _
                                     tbl.Rows(i).Item("FPINBARR") & "-" & _
                                     tbl.Rows(i).Item("FPINMANZ") & "-" & _
                                     tbl.Rows(i).Item("FPINPRED") & "-" & _
                                     tbl.Rows(i).Item("FPINEDIF") & "-" & _
                                     tbl.Rows(i).Item("FPINUNPR")
            dr1("Codigo incons.") = tbl.Rows(i).Item("FPINCODI")
            dr1("Descripcion") = tbl.Rows(i).Item("FPINDESC")
            dt1.Rows.Add(dr1)

        Next

        ' Llena el datagrigview
        TabControl1.SelectTab(TabPage1)
        Me.dgvFIPRINCO.DataSource = dt1
        pbProcesoResolucionActualizacion.Value = 0

        ' comando grabar datos
        If dt1.Rows.Count = 0 Then
            Me.cmdGrabarDatosResolucionActualizacion.Enabled = True
            Me.lblFecha2ResolucionActualizacion.Visible = True
            Me.cmdValidaDatosResolucionActualizacion.Enabled = False
            Me.cmdGrabarDatosResolucionActualizacion.Focus()

            MessageBox.Show("Proceso de validación terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            'Me.cmdGrabarDatos.PerformClick()
        Else
            Me.cmdValidaDatosResolucionActualizacion.Enabled = True
            MessageBox.Show("Proceso de validación inconsistente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

        Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRINCO.RowCount

    End Sub
    Private Sub pro_ValidarFichaResumenResolucionActualizacion()

        ' limpia los datagrigview
        Me.dgvFIPRINCO.DataSource = New DataTable
        Me.dgvFIREINCO.DataSource = New DataTable

        stRESOLUCION = Me.txtREACMUNI.Text & Me.txtREACVIGE.Text & Me.txtREACTIRE.Text & Me.txtREACRESO.Text & Me.txtREACCLSE.Text

        ' instancia la clase
        Dim objdatos11 As New cla_VALIFIPR
        'Dim tbl11 As New DataTable

        ' elimina las inconsistencias
        objdatos11.fun_Eliminar_FIPRINCO_X_RESOLUCION(Trim(stRESOLUCION))

        ' abre el archivo
        FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

        ' almacena la linea
        Dim stContenidoLinea As String = ""
        Dim stContenidoRegistro As String = ""
        Dim inNroDeCaracteresLindero As Integer = 0
        Dim inNroDeCaracteresCartografia As Integer = 0
        Dim stNroDeFichaPredial As String = ""

        ' Valores predeterminados ProgressBar
        inProceso = 0
        pbProcesoResolucionActualizacion.Value = 0
        pbProcesoResolucionActualizacion.Maximum = inTotalRegistros + 1
        Timer1.Enabled = True

        ' recorre el archivo plano y repita hasta que se acabe las lineas
        Do Until EOF(1)

            ' extrae la linea
            stContenidoLinea = LineInput(1)

            ' verifica cual es el registro de la tabla
            stContenidoRegistro = stContenidoLinea.Substring(0, 1).ToString

            ' optiene la longitud de la linea
            If stContenidoRegistro = "6" Then
                inNroDeCaracteresLindero = stContenidoLinea.Length.ToString - 26
            End If

            If stContenidoRegistro = "5" Then
                inNroDeCaracteresCartografia = stContenidoLinea.Length.ToString - 137
            End If

            ' crea tablas
            dt_FICHRES1 = New DataTable
            dt_FICHRES2 = New DataTable
            dt_FIPRCONS = New DataTable
            dt_FIPRCACO = New DataTable
            dt_FIPRLIND = New DataTable
            dt_FIPRCART = New DataTable

            ' Tabla RESOLUCION
            If stContenidoRegistro = "1" Then

                Dim dr_FICHRES1 As DataRow

                ' TABLA FICHA RESUMEN 1
                dt_FICHRES1.Columns.Add(New DataColumn("RES1IDRE", GetType(String)))
                dt_FICHRES1.Columns.Add(New DataColumn("RES1MUNI", GetType(String)))
                dt_FICHRES1.Columns.Add(New DataColumn("RES1CLSE", GetType(String)))
                dt_FICHRES1.Columns.Add(New DataColumn("RES1CORR", GetType(String)))
                dt_FICHRES1.Columns.Add(New DataColumn("RES1BARR", GetType(String)))
                dt_FICHRES1.Columns.Add(New DataColumn("RES1MANZ", GetType(String)))
                dt_FICHRES1.Columns.Add(New DataColumn("RES1PRED", GetType(String)))
                dt_FICHRES1.Columns.Add(New DataColumn("RES1ATLO", GetType(String)))
                dt_FICHRES1.Columns.Add(New DataColumn("RES1ACLO", GetType(String)))
                dt_FICHRES1.Columns.Add(New DataColumn("RES1APCA", GetType(String)))
                dt_FICHRES1.Columns.Add(New DataColumn("RES1UNCO", GetType(String)))
                dt_FICHRES1.Columns.Add(New DataColumn("RES1TOED", GetType(String)))
                dt_FICHRES1.Columns.Add(New DataColumn("RES1CUUT", GetType(String)))
                dt_FICHRES1.Columns.Add(New DataColumn("RES1LOCA", GetType(String)))
                dt_FICHRES1.Columns.Add(New DataColumn("RES1GACU", GetType(String)))
                dt_FICHRES1.Columns.Add(New DataColumn("RES1GADE", GetType(String)))
                dt_FICHRES1.Columns.Add(New DataColumn("RES1DIRE", GetType(String)))
                dt_FICHRES1.Columns.Add(New DataColumn("RES1CAPR", GetType(String)))

                dr_FICHRES1 = dt_FICHRES1.NewRow()

                dr_FICHRES1("RES1IDRE") = stContenidoLinea.Substring(0, 1).ToString
                dr_FICHRES1("RES1MUNI") = stContenidoLinea.Substring(1, 3).ToString
                dr_FICHRES1("RES1CLSE") = stContenidoLinea.Substring(4, 1).ToString
                dr_FICHRES1("RES1CORR") = stContenidoLinea.Substring(5, 3).ToString
                dr_FICHRES1("RES1BARR") = stContenidoLinea.Substring(8, 3).ToString
                dr_FICHRES1("RES1MANZ") = stContenidoLinea.Substring(11, 3).ToString
                dr_FICHRES1("RES1PRED") = stContenidoLinea.Substring(14, 5).ToString
                dr_FICHRES1("RES1ATLO") = stContenidoLinea.Substring(19, 11).ToString
                dr_FICHRES1("RES1ACLO") = stContenidoLinea.Substring(30, 11).ToString
                dr_FICHRES1("RES1APCA") = stContenidoLinea.Substring(41, 4).ToString
                dr_FICHRES1("RES1UNCO") = stContenidoLinea.Substring(45, 4).ToString
                dr_FICHRES1("RES1TOED") = stContenidoLinea.Substring(49, 4).ToString
                dr_FICHRES1("RES1CUUT") = stContenidoLinea.Substring(53, 4).ToString
                dr_FICHRES1("RES1LOCA") = stContenidoLinea.Substring(57, 4).ToString
                dr_FICHRES1("RES1GACU") = stContenidoLinea.Substring(61, 4).ToString
                dr_FICHRES1("RES1GADE") = stContenidoLinea.Substring(65, 4).ToString
                dr_FICHRES1("RES1DIRE") = stContenidoLinea.Substring(69, 49).ToString
                dr_FICHRES1("RES1CAPR") = stContenidoLinea.Substring(118, 1).ToString

                dt_FICHRES1.Rows.Add(dr_FICHRES1)

                ' almacena el numero de ficha resumen
                stNroDeFichaPredial = stRESOLUCION

                ' valida los datos cargados
                pro_VALIDAR_CARGA_FICHA_RESUMEN(dt_FICHRES1, dt_FICHRES2, dt_FIPRCONS, dt_FIPRCACO, dt_FIPRLIND, dt_FIPRCART, stRESOLUCION, stNroDeFichaPredial)

            End If

            ' Tabla FICHPRED
            If stContenidoRegistro = "2" Then

                Dim dr_FICHRES2 As DataRow

                ' TABLA FICHA RESUMEN 2
                dt_FICHRES2.Columns.Add(New DataColumn("RES2IDRE", GetType(String)))
                dt_FICHRES2.Columns.Add(New DataColumn("RES2MUNI", GetType(String)))
                dt_FICHRES2.Columns.Add(New DataColumn("RES2CLSE", GetType(String)))
                dt_FICHRES2.Columns.Add(New DataColumn("RES2CORR", GetType(String)))
                dt_FICHRES2.Columns.Add(New DataColumn("RES2BARR", GetType(String)))
                dt_FICHRES2.Columns.Add(New DataColumn("RES2MANZ", GetType(String)))
                dt_FICHRES2.Columns.Add(New DataColumn("RES2PRED", GetType(String)))
                dt_FICHRES2.Columns.Add(New DataColumn("RES2EDIF", GetType(String)))
                dt_FICHRES2.Columns.Add(New DataColumn("RES2ATLO", GetType(String)))
                dt_FICHRES2.Columns.Add(New DataColumn("RES2ACLO", GetType(String)))
                dt_FICHRES2.Columns.Add(New DataColumn("RES2PISO", GetType(String)))
                dt_FICHRES2.Columns.Add(New DataColumn("RES2URPH", GetType(String)))
                dt_FICHRES2.Columns.Add(New DataColumn("RES2APCA", GetType(String)))
                dt_FICHRES2.Columns.Add(New DataColumn("RES2CUUT", GetType(String)))
                dt_FICHRES2.Columns.Add(New DataColumn("RES2LOCA", GetType(String)))
                dt_FICHRES2.Columns.Add(New DataColumn("RES2GACU", GetType(String)))
                dt_FICHRES2.Columns.Add(New DataColumn("RES2GADE", GetType(String)))
                dt_FICHRES2.Columns.Add(New DataColumn("RES2DIRE", GetType(String)))
                dt_FICHRES2.Columns.Add(New DataColumn("RES2CAPR", GetType(String)))

                dr_FICHRES2 = dt_FICHRES2.NewRow()

                dr_FICHRES2("RES2IDRE") = stContenidoLinea.Substring(0, 1).ToString
                dr_FICHRES2("RES2MUNI") = stContenidoLinea.Substring(1, 3).ToString
                dr_FICHRES2("RES2CLSE") = stContenidoLinea.Substring(4, 1).ToString
                dr_FICHRES2("RES2CORR") = stContenidoLinea.Substring(5, 3).ToString
                dr_FICHRES2("RES2BARR") = stContenidoLinea.Substring(8, 3).ToString
                dr_FICHRES2("RES2MANZ") = stContenidoLinea.Substring(11, 3).ToString
                dr_FICHRES2("RES2PRED") = stContenidoLinea.Substring(14, 5).ToString
                dr_FICHRES2("RES2EDIF") = stContenidoLinea.Substring(19, 5).ToString
                dr_FICHRES2("RES2ATLO") = stContenidoLinea.Substring(24, 10).ToString
                dr_FICHRES2("RES2ACLO") = stContenidoLinea.Substring(34, 10).ToString
                dr_FICHRES2("RES2PISO") = stContenidoLinea.Substring(44, 3).ToString
                dr_FICHRES2("RES2URPH") = stContenidoLinea.Substring(47, 4).ToString
                dr_FICHRES2("RES2APCA") = stContenidoLinea.Substring(51, 4).ToString
                dr_FICHRES2("RES2CUUT") = stContenidoLinea.Substring(56, 4).ToString
                dr_FICHRES2("RES2LOCA") = stContenidoLinea.Substring(59, 4).ToString
                dr_FICHRES2("RES2GACU") = stContenidoLinea.Substring(63, 4).ToString
                dr_FICHRES2("RES2GADE") = stContenidoLinea.Substring(67, 4).ToString
                dr_FICHRES2("RES2DIRE") = stContenidoLinea.Substring(71, 49).ToString
                dr_FICHRES2("RES2CAPR") = stContenidoLinea.Substring(120, 1).ToString

                dt_FICHRES2.Rows.Add(dr_FICHRES2)

                ' almacena el numero de resolución
                stNroDeFichaPredial = stRESOLUCION

                ' valida los datos cargados
                pro_VALIDAR_CARGA_FICHA_RESUMEN(dt_FICHRES1, dt_FICHRES2, dt_FIPRCONS, dt_FIPRCACO, dt_FIPRLIND, dt_FIPRCART, stRESOLUCION, stNroDeFichaPredial)

            End If

            ' Tabla FIPRCONS
            If stContenidoRegistro = "3" Then

                Dim dr_FIPRCONS As DataRow

                ' TABLA FIPRCONS
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOIDRE", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOMUNI", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOCLSE", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOCORR", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOBARR", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOMANZ", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOPRED", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOEDIF", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOUNID", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOTIPO", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOTICO", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOARCO", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOPUNT", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOACUE", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOALCA", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOENER", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOTELE", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOGAS", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOPISO", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOPOCO", GetType(String)))
                dt_FIPRCONS.Columns.Add(New DataColumn("FPCOEDCO", GetType(String)))

                dr_FIPRCONS = dt_FIPRCONS.NewRow()

                dr_FIPRCONS("FPCOIDRE") = stContenidoLinea.Substring(0, 1).ToString
                dr_FIPRCONS("FPCOMUNI") = stContenidoLinea.Substring(1, 3).ToString
                dr_FIPRCONS("FPCOCLSE") = stContenidoLinea.Substring(4, 1).ToString
                dr_FIPRCONS("FPCOCORR") = stContenidoLinea.Substring(5, 3).ToString
                dr_FIPRCONS("FPCOBARR") = stContenidoLinea.Substring(8, 3).ToString
                dr_FIPRCONS("FPCOMANZ") = stContenidoLinea.Substring(11, 3).ToString
                dr_FIPRCONS("FPCOPRED") = stContenidoLinea.Substring(14, 5).ToString
                dr_FIPRCONS("FPCOEDIF") = stContenidoLinea.Substring(19, 5).ToString
                dr_FIPRCONS("FPCOUNID") = stContenidoLinea.Substring(24, 5).ToString
                dr_FIPRCONS("FPCOTIPO") = stContenidoLinea.Substring(29, 1).ToString
                dr_FIPRCONS("FPCOTICO") = stContenidoLinea.Substring(30, 3).ToString
                dr_FIPRCONS("FPCOARCO") = stContenidoLinea.Substring(33, 8).ToString
                dr_FIPRCONS("FPCOPUNT") = stContenidoLinea.Substring(41, 3).ToString
                dr_FIPRCONS("FPCOACUE") = stContenidoLinea.Substring(44, 1).ToString
                dr_FIPRCONS("FPCOALCA") = stContenidoLinea.Substring(45, 1).ToString
                dr_FIPRCONS("FPCOENER") = stContenidoLinea.Substring(46, 1).ToString
                dr_FIPRCONS("FPCOTELE") = stContenidoLinea.Substring(47, 1).ToString
                dr_FIPRCONS("FPCOGAS") = stContenidoLinea.Substring(48, 1).ToString
                dr_FIPRCONS("FPCOPISO") = stContenidoLinea.Substring(49, 2).ToString
                dr_FIPRCONS("FPCOPOCO") = stContenidoLinea.Substring(51, 5).ToString
                dr_FIPRCONS("FPCOEDCO") = stContenidoLinea.Substring(56, 4).ToString

                dt_FIPRCONS.Rows.Add(dr_FIPRCONS)

                ' almacena el numero de resolución
                stNroDeFichaPredial = stRESOLUCION

                ' valida los datos cargados
                pro_VALIDAR_CARGA_FICHA_RESUMEN(dt_FICHRES1, dt_FICHRES2, dt_FIPRCONS, dt_FIPRCACO, dt_FIPRLIND, dt_FIPRCART, stRESOLUCION, stNroDeFichaPredial)

            End If

            ' Tabla FIPRCACO
            If stContenidoRegistro = "4" Then

                Dim dr_FIPRCACO As DataRow

                ' TABLA FIPRCACO
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCIDRE", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCMUNI", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCCLSE", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCCORR", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCBARR", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCMANZ", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCPRED", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCEDIF", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCUNID", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCCODI", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCTIPO", GetType(String)))
                dt_FIPRCACO.Columns.Add(New DataColumn("FPCCPUNT", GetType(String)))

                dr_FIPRCACO = dt_FIPRCACO.NewRow()

                dr_FIPRCACO("FPCCIDRE") = stContenidoLinea.Substring(0, 1).ToString
                dr_FIPRCACO("FPCCMUNI") = stContenidoLinea.Substring(1, 3).ToString
                dr_FIPRCACO("FPCCCLSE") = stContenidoLinea.Substring(4, 1).ToString
                dr_FIPRCACO("FPCCCORR") = stContenidoLinea.Substring(5, 3).ToString
                dr_FIPRCACO("FPCCBARR") = stContenidoLinea.Substring(8, 3).ToString
                dr_FIPRCACO("FPCCMANZ") = stContenidoLinea.Substring(11, 3).ToString
                dr_FIPRCACO("FPCCPRED") = stContenidoLinea.Substring(14, 5).ToString
                dr_FIPRCACO("FPCCEDIF") = stContenidoLinea.Substring(19, 5).ToString
                dr_FIPRCACO("FPCCUNID") = stContenidoLinea.Substring(24, 5).ToString
                dr_FIPRCACO("FPCCCODI") = stContenidoLinea.Substring(29, 3).ToString
                dr_FIPRCACO("FPCCTIPO") = stContenidoLinea.Substring(32, 1).ToString
                dr_FIPRCACO("FPCCPUNT") = stContenidoLinea.Substring(33, 3).ToString

                dt_FIPRCACO.Rows.Add(dr_FIPRCACO)

                ' almacena el numero de resolución
                stNroDeFichaPredial = stRESOLUCION

                ' valida los datos cargados
                pro_VALIDAR_CARGA_FICHA_RESUMEN(dt_FICHRES1, dt_FICHRES2, dt_FIPRCONS, dt_FIPRCACO, dt_FIPRLIND, dt_FIPRCART, stRESOLUCION, stNroDeFichaPredial)

            End If

            ' Tabla FIPRCART
            If stContenidoRegistro = "5" Then

                Dim dr_FIPRCART As DataRow

                ' TABLA FIPRCART
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAIDRE", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAMUNI", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCACLSE", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCACORR", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCABARR", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAMANZ", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAPRED", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAEDIF", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAPLAN", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAVENT", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAESGR", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAVIGR", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAVUEL", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAFAJA", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAFOTO", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAVIAE", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAAMPL", GetType(String)))
                dt_FIPRCART.Columns.Add(New DataColumn("FPCAESAE", GetType(String)))

                dr_FIPRCART = dt_FIPRCART.NewRow()

                dr_FIPRCART("FPCAIDRE") = stContenidoLinea.Substring(0, 1).ToString
                dr_FIPRCART("FPCAMUNI") = stContenidoLinea.Substring(1, 3).ToString
                dr_FIPRCART("FPCACLSE") = stContenidoLinea.Substring(4, 1).ToString
                dr_FIPRCART("FPCACORR") = stContenidoLinea.Substring(5, 3).ToString
                dr_FIPRCART("FPCABARR") = stContenidoLinea.Substring(8, 3).ToString
                dr_FIPRCART("FPCAMANZ") = stContenidoLinea.Substring(11, 3).ToString
                dr_FIPRCART("FPCAPRED") = stContenidoLinea.Substring(14, 5).ToString
                dr_FIPRCART("FPCAEDIF") = stContenidoLinea.Substring(19, 5).ToString
                dr_FIPRCART("FPCAPLAN") = stContenidoLinea.Substring(24, 15).ToString
                dr_FIPRCART("FPCAVENT") = stContenidoLinea.Substring(39, 15).ToString
                dr_FIPRCART("FPCAESGR") = stContenidoLinea.Substring(54, 15).ToString
                dr_FIPRCART("FPCAVIGR") = stContenidoLinea.Substring(69, 4).ToString
                dr_FIPRCART("FPCAVUEL") = stContenidoLinea.Substring(73, 15).ToString
                dr_FIPRCART("FPCAFAJA") = stContenidoLinea.Substring(88, 15).ToString
                dr_FIPRCART("FPCAFOTO") = stContenidoLinea.Substring(103, 15).ToString
                dr_FIPRCART("FPCAVIAE") = stContenidoLinea.Substring(118, 4).ToString
                dr_FIPRCART("FPCAAMPL") = stContenidoLinea.Substring(122, 15).ToString
                dr_FIPRCART("FPCAESAE") = stContenidoLinea.Substring(137, inNroDeCaracteresCartografia).ToString

                dt_FIPRCART.Rows.Add(dr_FIPRCART)

                ' almacena el numero de resolución
                stNroDeFichaPredial = stRESOLUCION

                ' valida los datos cargados
                pro_VALIDAR_CARGA_FICHA_RESUMEN(dt_FICHRES1, dt_FICHRES2, dt_FIPRCONS, dt_FIPRCACO, dt_FIPRLIND, dt_FIPRCART, stRESOLUCION, stNroDeFichaPredial)

            End If

            ' Tabla FIPRLIND
            If stContenidoRegistro = "6" Then

                Dim dr_FIPRLIND As DataRow

                ' TABLA FIPRLIND
                dt_FIPRLIND.Columns.Add(New DataColumn("FPLIIDRE", GetType(String)))
                dt_FIPRLIND.Columns.Add(New DataColumn("FPLIMUNI", GetType(String)))
                dt_FIPRLIND.Columns.Add(New DataColumn("FPLICLSE", GetType(String)))
                dt_FIPRLIND.Columns.Add(New DataColumn("FPLICORR", GetType(String)))
                dt_FIPRLIND.Columns.Add(New DataColumn("FPLIBARR", GetType(String)))
                dt_FIPRLIND.Columns.Add(New DataColumn("FPLIMANZ", GetType(String)))
                dt_FIPRLIND.Columns.Add(New DataColumn("FPLIPRED", GetType(String)))
                dt_FIPRLIND.Columns.Add(New DataColumn("FPLIEDIF", GetType(String)))
                dt_FIPRLIND.Columns.Add(New DataColumn("FPLIPUCA", GetType(String)))
                dt_FIPRLIND.Columns.Add(New DataColumn("FPLICOLI", GetType(String)))

                dr_FIPRLIND = dt_FIPRLIND.NewRow()

                dr_FIPRLIND("FPLIIDRE") = stContenidoLinea.Substring(0, 1).ToString
                dr_FIPRLIND("FPLIMUNI") = stContenidoLinea.Substring(1, 3).ToString
                dr_FIPRLIND("FPLICLSE") = stContenidoLinea.Substring(4, 1).ToString
                dr_FIPRLIND("FPLICORR") = stContenidoLinea.Substring(5, 3).ToString
                dr_FIPRLIND("FPLIBARR") = stContenidoLinea.Substring(8, 3).ToString
                dr_FIPRLIND("FPLIMANZ") = stContenidoLinea.Substring(11, 3).ToString
                dr_FIPRLIND("FPLIPRED") = stContenidoLinea.Substring(14, 5).ToString
                dr_FIPRLIND("FPLIEDIF") = stContenidoLinea.Substring(19, 5).ToString
                dr_FIPRLIND("FPLIPUCA") = stContenidoLinea.Substring(24, 2).ToString
                dr_FIPRLIND("FPLICOLI") = stContenidoLinea.Substring(26, inNroDeCaracteresLindero).ToString

                dt_FIPRLIND.Rows.Add(dr_FIPRLIND)

                ' almacena el numero de resolución
                stNroDeFichaPredial = stRESOLUCION

                ' valida los datos cargados
                pro_VALIDAR_CARGA_FICHA_RESUMEN(dt_FICHRES1, dt_FICHRES2, dt_FIPRCONS, dt_FIPRCACO, dt_FIPRLIND, dt_FIPRCART, stRESOLUCION, stNroDeFichaPredial)

            End If



            ' Incrementa la barra
            inProceso = inProceso + 1
            pbProcesoResolucionActualizacion.Value = inProceso

        Loop

        ' consulta las inconsistencas de las fichas validadas
        Dim objdatos As New cla_VALIFIPR
        Dim tbl As New DataTable

        tbl = objdatos.fun_Consultar_INCONSISTENCIA_X_RESOLUCION(stRESOLUCION)

        ' Crea objeto de columnas y registros
        Dim dt1 As New DataTable
        Dim dr1 As DataRow

        ' Crea las columnas
        dt1.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
        dt1.Columns.Add(New DataColumn("Cedula catastral", GetType(String)))
        dt1.Columns.Add(New DataColumn("Codigo incons.", GetType(String)))
        dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))

        Dim i As Integer

        For i = 0 To tbl.Rows.Count - 1

            dr1 = dt1.NewRow()
            dr1("Nro_Ficha") = tbl.Rows(i).Item("FPINNUFI")
            dr1("Cedula catastral") = tbl.Rows(i).Item("FPINMUNI") & "-" & _
                                     tbl.Rows(i).Item("FPINCORR") & "-" & _
                                     tbl.Rows(i).Item("FPINBARR") & "-" & _
                                     tbl.Rows(i).Item("FPINMANZ") & "-" & _
                                     tbl.Rows(i).Item("FPINPRED") & "-" & _
                                     tbl.Rows(i).Item("FPINEDIF") & "-" & _
                                     tbl.Rows(i).Item("FPINUNPR")
            dr1("Codigo incons.") = tbl.Rows(i).Item("FPINCODI")
            dr1("Descripcion") = tbl.Rows(i).Item("FPINDESC")
            dt1.Rows.Add(dr1)

        Next

        ' Llena el datagrigview
        TabControl1.SelectTab(TabPage2)
        Me.dgvFIREINCO.DataSource = dt1
        pbProcesoResolucionActualizacion.Value = 0

        ' comando grabar datos
        If dt1.Rows.Count = 0 Then
            Me.cmdGrabarDatosResolucionActualizacion.Enabled = True
            Me.lblFecha2ResolucionActualizacion.Visible = True
            Me.cmdValidaDatosResolucionActualizacion.Enabled = False
            Me.cmdGrabarDatosResolucionActualizacion.Focus()
            MessageBox.Show("Proceso de validación terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Me.cmdValidaDatosResolucionActualizacion.Enabled = True
            MessageBox.Show("Proceso de validación inconsistente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

        Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIREINCO.RowCount

    End Sub
    Private Sub pro_ValidarFichaPredialResolucionAdministrativa()

    End Sub

    Private Sub pro_GuardarDatosFichaPredialResolucionActualizacion()

        Try
            ' apaga el boton grabar datos
            Me.cmdGrabarDatosResolucionActualizacion.Enabled = False

            ' eliminar la base de datos existente de acuerdo al archivo plano
            If Me.chkSobrescribirBDexistenteResolucionActualizacion.Checked = True And Me.rbdFichaPredialResolucionActualizacion.Checked = True Then

                ' elimina ficha predial
                If Trim(Me.txtREACMUNI.Text) <> "" And _
                   Trim(Me.txtREACCLSE.Text) <> "" Then

                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtREACMUNI.Text)) = True And _
                       fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtREACCLSE.Text)) = True Then

                        Dim objFichaPredial11 As New cla_FICHPRED

                        objFichaPredial11.fun_Eliminar_DB_FICHA_PREDIAL(Trim(Me.txtREACMUNI.Text), Trim(Me.txtREACCLSE.Text))

                    End If

                End If

            ElseIf Me.chkSobrescribirBDexistenteResolucionActualizacion.Checked = True And Me.rbdFichaResumenResolucionActualizacion.Checked = True Then

                ' elimina ficha resumen
                If Trim(Me.txtREACMUNI.Text) <> "" And _
                   Trim(Me.txtREACCLSE.Text) <> "" Then

                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtREACMUNI.Text)) = True And _
                       fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtREACCLSE.Text)) = True Then

                        Dim objFichaPredial11 As New cla_FICHPRED

                        objFichaPredial11.fun_Eliminar_DB_FICHA_RESUMEN(Trim(Me.txtREACMUNI.Text), Trim(Me.txtREACCLSE.Text))

                    End If

                End If

            End If

            ' inactiva las fichas prediales
            If Me.chkInactivasFichasResolucionActualizacion.Checked = True Then
                pro_InactivarPredios()
            End If

            ' almacena la resolucion para la consulta de inconsistencias
            stRESOLUCION = Me.txtREACMUNI.Text & Me.txtREACVIGE.Text & Me.txtREACTIRE.Text & Me.txtREACRESO.Text & Me.txtREACCLSE.Text

            ' instancia la clase
            Dim objdatos11 As New cla_VALIFIPR
            'Dim tbl11 As New DataTable

            ' elimina las inconsistencias
            objdatos11.fun_Eliminar_FIPRINCO_X_RESOLUCION(Trim(stRESOLUCION))

            ' abre el archivo
            FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

            ' almacena la linea
            Dim stContenidoLinea As String = ""
            Dim stContenidoRegistro As String = ""
            Dim inNroDeCaracteresLindero As Integer = 0
            Dim inNroDeCaracteresCartografia As Integer = 0
            Dim stNroDeFichaPredial As String = ""
            Dim inNroDeRegistroDelPlano As Integer = 0

            ' Valores predeterminados ProgressBar
            inProceso = 0
            pbProcesoResolucionActualizacion.Value = 0
            pbProcesoResolucionActualizacion.Maximum = inTotalRegistros + 1
            Timer1.Enabled = True

            ' recorre el archivo plano y repita hasta que se acabe las lineas
            Do Until EOF(1)

                ' numero de registro del plano utilizado en codigos asignados
                inNroDeRegistroDelPlano += 1

                a = inNroDeRegistroDelPlano

                ' extrae la linea
                stContenidoLinea = LineInput(1)

                ' verifica cual es el registro de la tabla
                stContenidoRegistro = stContenidoLinea.Substring(0, 1).ToString

                ' optiene la longitud de la linea
                If stContenidoRegistro = "7" Then
                    inNroDeCaracteresLindero = stContenidoLinea.Length.ToString - 31
                End If

                If stContenidoRegistro = "8" Then
                    inNroDeCaracteresCartografia = stContenidoLinea.Length.ToString - 142
                End If

                '================================
                '*** Inserta tabla RESOLUCION ***
                '================================
                If stContenidoRegistro = "1" Then

                    ' variables indirectas
                    Dim stRESODEPA As String = "05"
                    Dim boRESOPATO As Boolean = False
                    Dim stRESOESTA As String = "ac"

                    ' variables directas
                    Dim inRESOIDRE As Integer = stContenidoLinea.Substring(0, 1).ToString
                    Dim inRESOVIGE As Integer = stContenidoLinea.Substring(1, 4).ToString
                    Dim inRESOTIRE As Integer = stContenidoLinea.Substring(5, 3).ToString
                    Dim inRESORESO As Integer = stContenidoLinea.Substring(8, 7).ToString
                    Dim stRESOMUNI As String = stContenidoLinea.Substring(15, 3).ToString
                    Dim inRESOCLSE As Integer = stContenidoLinea.Substring(18, 1).ToString
                    Dim inRESONURE As Integer = stContenidoLinea.Substring(19, 7).ToString
                    Dim loRESOARTE As Long = stContenidoLinea.Substring(26, 12).ToString
                    Dim inRESOARCO As Integer = stContenidoLinea.Substring(38, 10).ToString
                    Dim inRESOSUPU As Integer = stContenidoLinea.Substring(48, 10).ToString
                    Dim inRESOPATO As Integer = stContenidoLinea.Substring(58, 1).ToString

                    ' instancia el objeto
                    Dim objdatos1 As New cla_RESOLUCION
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_TIPO_Y_CLASE_Y_VIGENCIA_Y_CODIGO_RESOLUCION(stRESODEPA, stRESOMUNI, inRESOTIRE, inRESOCLSE, inRESOVIGE, inRESORESO)

                    ' verifica si la resolucion existe
                    If tbl1.Rows.Count > 0 Then

                        ' almacena la resolucion
                        vl_stRESODEPA = stRESODEPA
                        vl_stRESOMUNI = stRESOMUNI
                        vl_inRESOVIGE = inRESOVIGE
                        vl_inRESOTIRE = inRESOTIRE
                        vl_inRESORESO = inRESORESO
                        vl_inRESOCLSE = inRESOCLSE

                        ' declara las variables
                        Dim objdatos44 As New cla_MUNICIPIO
                        Dim tbl44 As New DataTable

                        tbl44 = objdatos44.fun_Buscar_DEPARTAMENTO_Y_CODIGO_MANT_MUNICIPIO(vl_stRESODEPA, vl_stRESOMUNI)

                        If tbl44.Rows.Count > 0 Then
                            vl_inMUNIRAIN = tbl44.Rows(0).Item("MUNIRAIN").ToString
                            vl_inMUNIRAFI = tbl44.Rows(0).Item("MUNIRAFI").ToString
                        End If

                    Else
                        MessageBox.Show("Resolución no existe", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

                        ' sale del proceso
                        Exit Sub

                    End If

                End If

                '==============================
                '*** Inserta tabla FICHPRED ***
                '==============================
                If stContenidoRegistro = "2" Then

                    ' variables indirectas
                    Dim stFIPRDESC As String = "."
                    Dim boFIPRCONJ As Boolean = False
                    Dim boFIPRLITI As Boolean = False
                    Dim boFIPRINCO As Boolean = False
                    Dim daFIPRFECH As Date = fun_Hora_y_fecha()
                    Dim stFIPRESTA As String = "ac"
                    Dim stFIPRPOLI As String = "0.00"
                    Dim stFIPRMOAD As Integer = 1
                    Dim stFIPRTIFI As Integer = 0

                    ' variables directas
                    Dim inFIPRNUFI As Integer = stContenidoLinea.Substring(15, 9).ToString
                    Dim inFIPRNURE As Integer = stContenidoLinea.Substring(24, 5).ToString
                    Dim stFIPRMUNI As String = stContenidoLinea.Substring(29, 3).ToString
                    Dim inFIPRCLSE As Integer = stContenidoLinea.Substring(32, 1).ToString
                    Dim stFIPRCORR As String = stContenidoLinea.Substring(33, 3).ToString
                    Dim stFIPRBARR As String = stContenidoLinea.Substring(36, 3).ToString
                    Dim stFIPRMANZ As String = stContenidoLinea.Substring(39, 3).ToString
                    Dim stFIPRPRED As String = stContenidoLinea.Substring(42, 5).ToString
                    Dim stFIPREDIF As String = stContenidoLinea.Substring(47, 5).ToString
                    Dim stFIPRUNPR As String = stContenidoLinea.Substring(52, 5).ToString
                    Dim loFIPRARTE As Long = stContenidoLinea.Substring(57, 10).ToString
                    Dim stFIPRDIRE As String = stContenidoLinea.Substring(67, 49).ToString
                    Dim inFIPRCAPR As Integer = stContenidoLinea.Substring(116, 1).ToString
                    Dim inFIPRCASU As Integer = stContenidoLinea.Substring(117, 1).ToString
                    Dim stFIPRCOPR As String = stContenidoLinea.Substring(118, 9).ToString
                    Dim stFIPRCOED As String = stContenidoLinea.Substring(127, 9).ToString
                    Dim stFIPRMUAN As String = stContenidoLinea.Substring(136, 3).ToString
                    Dim inFIPRCSAN As Integer = stContenidoLinea.Substring(139, 1).ToString
                    Dim stFIPRCOAN As String = stContenidoLinea.Substring(140, 3).ToString
                    Dim stFIPRBAAN As String = stContenidoLinea.Substring(143, 3).ToString
                    Dim stFIPRMAAN As String = stContenidoLinea.Substring(146, 3).ToString
                    Dim stFIPRPRAN As String = stContenidoLinea.Substring(149, 5).ToString
                    Dim stFIPREDAN As String = stContenidoLinea.Substring(154, 5).ToString
                    Dim stFIPRUPAN As String = stContenidoLinea.Substring(159, 5).ToString
                    Dim inFIPRCASA As Integer = stContenidoLinea.Substring(164, 1).ToString

                    ' formato de campos
                    stFIPRMUNI = CType(fun_Formato_Mascara_3_Reales(stFIPRMUNI), String)
                    stFIPRCORR = CType(fun_Formato_Mascara_2_Reales(stFIPRCORR.Substring(1, 2).ToString), String)
                    stFIPRBARR = CType(fun_Formato_Mascara_3_Reales(stFIPRBARR), String)
                    stFIPRMANZ = CType(fun_Formato_Mascara_3_Reales(stFIPRMANZ), String)
                    stFIPRPRED = CType(fun_Formato_Mascara_5_Reales(stFIPRPRED), String)
                    stFIPREDIF = CType(fun_Formato_Mascara_3_Reales(stFIPREDIF.Substring(2, 3).ToString), String)
                    stFIPRUNPR = CType(fun_Formato_Mascara_5_Reales(stFIPRUNPR), String)
                    stFIPRMUAN = CType(fun_Formato_Mascara_3_Reales(stFIPRMUAN), String)
                    stFIPRCOAN = CType(fun_Formato_Mascara_2_Reales(stFIPRCOAN), String)
                    stFIPRBAAN = CType(fun_Formato_Mascara_3_Reales(stFIPRBAAN), String)
                    stFIPRMAAN = CType(fun_Formato_Mascara_3_Reales(stFIPRMAAN), String)
                    stFIPRPRAN = CType(fun_Formato_Mascara_5_Reales(stFIPRPRAN), String)
                    stFIPREDAN = CType(fun_Formato_Mascara_3_Reales(stFIPREDAN), String)
                    stFIPRUPAN = CType(fun_Formato_Mascara_5_Reales(stFIPRUPAN), String)

                    ' campo coeficiente de predio
                    Dim stFIPRCOPR_1 As String = Val(stFIPRCOPR.Substring(0, 3))
                    Dim stFIPRCOPR_2 As String = "."
                    Dim stFIPRCOPR_3 As String = stFIPRCOPR.Substring(3, 6)
                    Dim stFIPRCOPR_4 As String = stFIPRCOPR_1 & stFIPRCOPR_2 & stFIPRCOPR_3

                    stFIPRCOPR = CType(fun_Formato_Decimal_6_Decimales(stFIPRCOPR_4), String)

                    ' campo coeficiente de edificio
                    Dim stFIPRCOED_1 As String = Val(stFIPRCOED.Substring(0, 3))
                    Dim stFIPRCOED_2 As String = "."
                    Dim stFIPRCOED_3 As String = stFIPRCOED.Substring(3, 6)
                    Dim stFIPRCOED_4 As String = stFIPRCOED_1 & stFIPRCOED_2 & stFIPRCOED_3

                    stFIPRCOED = CType(fun_Formato_Decimal_6_Decimales(stFIPRCOED_4), String)

                    ' convierte en variable boleona
                    If inFIPRCAPR = 3 Or inFIPRCAPR = 4 Then
                        boFIPRCONJ = True
                    Else
                        boFIPRCONJ = False
                    End If

                    ' mascara del campo de la unidad predial
                    If stFIPREDIF = "000" AndAlso stFIPRUNPR >= "00001" Then
                        stFIPRUNPR = "00000"
                    End If

                    ' asigna el nuemro de registro
                    pro_AsignarNumeroDeRegistroResolucionActualizacion()

                    ' obtiene la resolucion concatenada
                    pro_ObtenerResolucionCancatenada()

                    ' obtiene la cedula catastral concatenada
                    pro_ObtenerCedulaCatastralConcatenada(stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPREDIF, stFIPRUNPR, inFIPRCLSE)

                    ' declaro la variable
                    Dim boRangoFichaMuncipio As Boolean = False
                    Dim boRangoFichaNueva As Boolean = False
                    Dim boRangoFichaOVC As Boolean = False

                    Dim boRangoFichaInconsistente As Boolean = True

                    ' valida el rango de ficha nueva
                    Dim stFIPRNUFI As String = stContenidoLinea.Substring(15, 9).ToString

                    If stFIPRNUFI.ToString.Substring(0, 3) = Trim(stFIPRMUNI) And stFIPRNUFI.ToString.Substring(3, 1) = inFIPRCLSE Then
                        boRangoFichaNueva = True
                    Else
                        boRangoFichaNueva = False
                    End If

                    ' valida el rango de ficha municipio
                    Dim inFIPRRAIN As Integer = vl_inMUNIRAIN
                    Dim inFIPRRAFI As Integer = vl_inMUNIRAFI

                    If Val(inFIPRNUFI) < inFIPRRAIN Or Val(inFIPRNUFI) > inFIPRRAFI Then
                        boRangoFichaMuncipio = False
                    Else
                        boRangoFichaMuncipio = True
                    End If

                    ' valida el rango de ficha OVC
                    If Me.chkFichasOVCResolucionActualizacion.Checked = True Then
                        boRangoFichaOVC = True
                    Else
                        boRangoFichaOVC = False
                    End If

                    ' valida el rango de ficha
                    If boRangoFichaMuncipio = True Then
                        boRangoFichaInconsistente = False

                    Else
                        If boRangoFichaMuncipio = False And boRangoFichaNueva = True Then
                            boRangoFichaInconsistente = False

                        Else
                            If boRangoFichaMuncipio = False And boRangoFichaNueva = False And boRangoFichaOVC = True Then
                                boRangoFichaInconsistente = False

                            End If

                        End If

                    End If

                    If boRangoFichaInconsistente = True Then

                        ' guarda la inconsistencia
                        vl_inFIPRNUFI = inFIPRNUFI
                        vl_stFPINCODI = "1-FICHA PREDIAL"
                        vl_stFPINDESC = "Nro ficha predial " & inFIPRNUFI & " con rango incorrecto para el municipio. "
                        vl_stFIPRMUNI = vl_stRESOMUNI
                        vl_stFIPRCORR = stFIPRCORR
                        vl_stFIPRBARR = stFIPRBARR
                        vl_stFIPRMANZ = stFIPRMANZ
                        vl_stFIPRPRED = stFIPRPRED
                        vl_stFIPREDIF = stFIPREDIF
                        vl_stFIPRUNPR = stFIPRUNPR

                        pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                    Else

                        ' si elimina los registros
                        If Me.chkSobrescribirBDexistenteResolucionActualizacion.Checked = True Then

                            ' verifica que la ficha exista
                            Dim objdatos1 As New cla_FICHPRED
                            Dim tbl1 As New DataTable

                            tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFIPRNUFI)

                            If tbl1.Rows.Count = 0 Then

                                ' instancia la funcion eliminar
                                Dim obj_FICHPRED As New cla_FICHPRED
                                obj_FICHPRED.fun_Eliminar_FICHPRED(inFIPRNUFI)

                                Dim obj_FICHPRED1 As New cla_FICHPRED
                                obj_FICHPRED1.fun_Insertar_FICHPRED(inFIPRNUFI, vl_inRESOVIGE, vl_inRESOTIRE, vl_inRESORESO, stFIPRDIRE, stFIPRDESC, boFIPRCONJ, daFIPRFECH, vl_inFIPRNURE, vl_stRESODEPA, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPREDIF, stFIPRUNPR, inFIPRCLSE, inFIPRCASU, stFIPRMUAN, stFIPRCOAN, stFIPRBAAN, stFIPRMAAN, stFIPRPRAN, stFIPREDAN, stFIPRUPAN, inFIPRCSAN, inFIPRCASA, inFIPRCAPR, stFIPRMOAD, stFIPRESTA, boFIPRLITI, stFIPRPOLI, vl_stFIPRCORE, loFIPRARTE, stFIPRCOPR, stFIPRCOED, stFIPRTIFI, boFIPRINCO)

                            End If

                            ' inserta solo los predios nuevos 
                        ElseIf Me.rbdInsertaPrediosNuevosResolucionActualizacion.Checked = True Then

                            ' verifica que la ficha exista
                            Dim objdatos1 As New cla_FICHPRED
                            Dim tbl1 As New DataTable

                            tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFIPRNUFI)

                            If tbl1.Rows.Count = 0 Then

                                ' instancia la funcion insertar
                                Dim obj_FICHPRED1 As New cla_FICHPRED
                                obj_FICHPRED1.fun_Insertar_FICHPRED(inFIPRNUFI, vl_inRESOVIGE, vl_inRESOTIRE, vl_inRESORESO, stFIPRDIRE, stFIPRDESC, boFIPRCONJ, daFIPRFECH, vl_inFIPRNURE, vl_stRESODEPA, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPREDIF, stFIPRUNPR, inFIPRCLSE, inFIPRCASU, stFIPRMUAN, stFIPRCOAN, stFIPRBAAN, stFIPRMAAN, stFIPRPRAN, stFIPREDAN, stFIPRUPAN, inFIPRCSAN, inFIPRCASA, inFIPRCAPR, stFIPRMOAD, stFIPRESTA, boFIPRLITI, stFIPRPOLI, vl_stFIPRCORE, loFIPRARTE, stFIPRCOPR, stFIPRCOED, stFIPRTIFI, boFIPRINCO)

                                boPredioNuevo = True
                            Else
                                boPredioNuevo = False

                            End If

                            ' actualiza e inserta los predios
                        ElseIf Me.rbdActualizarInsertarPrediosResolucionActualizacion.Checked = True Then

                            ' verifica que la ficha exista
                            Dim objdatos1 As New cla_FICHPRED
                            Dim tbl1 As New DataTable

                            tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFIPRNUFI)

                            If tbl1.Rows.Count = 0 Then

                                ' instancia la funcion insertar
                                Dim obj_FICHPRED1 As New cla_FICHPRED
                                obj_FICHPRED1.fun_Insertar_FICHPRED(inFIPRNUFI, vl_inRESOVIGE, vl_inRESOTIRE, vl_inRESORESO, stFIPRDIRE, stFIPRDESC, boFIPRCONJ, daFIPRFECH, vl_inFIPRNURE, vl_stRESODEPA, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPREDIF, stFIPRUNPR, inFIPRCLSE, inFIPRCASU, stFIPRMUAN, stFIPRCOAN, stFIPRBAAN, stFIPRMAAN, stFIPRPRAN, stFIPREDAN, stFIPRUPAN, inFIPRCSAN, inFIPRCASA, inFIPRCAPR, stFIPRMOAD, stFIPRESTA, boFIPRLITI, stFIPRPOLI, vl_stFIPRCORE, loFIPRARTE, stFIPRCOPR, stFIPRCOED, stFIPRTIFI, boFIPRINCO)

                                boPredioNuevo = True
                            Else
                                ' instancia la funcion modificar
                                Dim obj_FICHPRED1 As New cla_FICHPRED
                                If obj_FICHPRED1.fun_Actualizar_X_NUFI_FICHPRED(inFIPRNUFI, vl_inRESOVIGE, vl_inRESOTIRE, vl_inRESORESO, stFIPRDIRE, stFIPRDESC, boFIPRCONJ, daFIPRFECH, vl_inFIPRNURE, vl_stRESODEPA, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPREDIF, stFIPRUNPR, inFIPRCLSE, inFIPRCASU, stFIPRMUAN, stFIPRCOAN, stFIPRBAAN, stFIPRMAAN, stFIPRPRAN, stFIPREDAN, stFIPRUPAN, inFIPRCSAN, inFIPRCASA, inFIPRCAPR, stFIPRMOAD, stFIPRESTA, boFIPRLITI, stFIPRPOLI, loFIPRARTE, stFIPRCOPR, stFIPRCOED, stFIPRTIFI) = True Then

                                End If

                                ' borrar todas las tablas
                                If Me.chkDestinoEconomicoResolucionActualizacion.Checked = True Then
                                    Dim obj_FIPRDEEC1 As New cla_FIPRDEEC
                                    obj_FIPRDEEC1.fun_Eliminar_NUFI_FIPRDEEC(inFIPRNUFI)
                                End If

                                If Me.chkPropietarioResolucionActualizacion.Checked = True Then
                                    Dim obj_FIPRPROP1 As New cla_FIPRPROP
                                    obj_FIPRPROP1.fun_Eliminar_NUFI_FIPRPROP(inFIPRNUFI)
                                End If

                                If Me.chkConstruccionResolucionActualizacion.Checked = True Then
                                    Dim obj_FIPRCONS1 As New cla_FIPRCONS
                                    obj_FIPRCONS1.fun_Eliminar_NUFI_FIPRCONS(inFIPRNUFI)
                                End If

                                If Me.chkLinderoResolucionActualizacion.Checked = True Then
                                    Dim obj_FIPRLIND As New cla_FIPRLIND
                                    obj_FIPRLIND.fun_Eliminar_NUFI_FIPRLIND(inFIPRNUFI)
                                End If

                                If Me.chkCartografiaResolucionActualizacion.Checked = True Then
                                    Dim obj_FIPRCART As New cla_FIPRCART
                                    obj_FIPRCART.fun_Eliminar_NUFI_FIPRCART(inFIPRNUFI)
                                End If

                                boPredioNuevo = False

                            End If

                        End If
                    End If

                End If

                '==============================
                '*** Inserta tabla FIPRDEEC ***
                '==============================
                If stContenidoRegistro = "3" Then

                    ' variables indirectas
                    Dim stFPDEESTA As String = "ac"
                    Dim inFPDENURE As Integer = 0
                    Dim inFPDESECU As Integer = 0

                    ' variables directas
                    Dim inFPDENUFI As Integer = stContenidoLinea.Substring(15, 9).ToString
                    Dim inFPDEDEEC As Integer = stContenidoLinea.Substring(29, 2).ToString
                    Dim inFPDEPORC As Integer = stContenidoLinea.Substring(31, 3).ToString

                    ' inserta solo predios nuevos
                    If boPredioNuevo = True And Me.rbdInsertaPrediosNuevosResolucionActualizacion.Checked = True Then

                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPDENUFI)

                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPDENURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' busca la secuencia de registro
                            inFPDESECU = fun_BuscarNroSecuenciaDestinacionEconomica(inFPDENUFI)

                            Dim obj_FIPRDEEC As New cla_FIPRDEEC

                            ' inserta el registro
                            obj_FIPRDEEC.fun_Insertar_FIPRDEEC(inFPDENUFI, inFPDEDEEC, inFPDEPORC, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPDESECU, inFPDENURE, stFPDEESTA)

                        End If

                    Else
                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPDENUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPDENURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' instancia la clase
                            Dim obj2_FIPRDEEC As New cla_FIPRDEEC
                            Dim tbl2 As New DataTable

                            ' consulta la llave primaria
                            tbl2 = obj2_FIPRDEEC.fun_Buscar_CODIGO_FIPRDEEC(inFPDENUFI, inFPDEDEEC)

                            ' cuenta los registros
                            If tbl2.Rows.Count = 0 Then

                                ' busca la secuencia de registro
                                inFPDESECU = fun_BuscarNroSecuenciaDestinacionEconomica(inFPDENUFI)

                                Dim obj_FIPRDEEC As New cla_FIPRDEEC

                                If Me.rbdActualizarInsertarPrediosResolucionActualizacion.Checked = True And Me.chkDestinoEconomicoResolucionActualizacion.Checked = True And boPredioNuevo = False Then
                                    ' instancia la clase 
                                    obj_FIPRDEEC.fun_Insertar_FIPRDEEC(inFPDENUFI, inFPDEDEEC, inFPDEPORC, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPDESECU, inFPDENURE, stFPDEESTA)

                                ElseIf Me.chkSobrescribirBDexistenteResolucionActualizacion.Checked = True Or boPredioNuevo = True Then
                                    ' inserta el registro
                                    obj_FIPRDEEC.fun_Insertar_FIPRDEEC(inFPDENUFI, inFPDEDEEC, inFPDEPORC, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPDESECU, inFPDENURE, stFPDEESTA)

                                End If

                            ElseIf Me.chkSobrescribirBDexistenteResolucionActualizacion.Checked = True Or boPredioNuevo = True Then

                                ' guarda la inconsistencia
                                vl_inFIPRNUFI = inFPDENUFI
                                vl_stFPINCODI = "3-DESTINACION"
                                vl_stFPINDESC = "Destino " & inFPDEDEEC & " existe en base de datos. " & inFPDENUFI
                                vl_stFIPRMUNI = vl_stRESOMUNI
                                vl_stFIPRCORR = ""
                                vl_stFIPRBARR = ""
                                vl_stFIPRMANZ = ""
                                vl_stFIPRPRED = ""
                                vl_stFIPREDIF = ""
                                vl_stFIPRUNPR = ""

                                pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                            End If

                        Else
                            ' guarda la inconsistencia
                            vl_inFIPRNUFI = inFPDENUFI
                            vl_stFPINCODI = "3-DESTINACION"
                            vl_stFPINDESC = "Ficha " & inFPDENUFI & " no existe en base de datos."
                            vl_stFIPRMUNI = vl_stRESOMUNI
                            vl_stFIPRCORR = ""
                            vl_stFIPRBARR = ""
                            vl_stFIPRMANZ = ""
                            vl_stFIPRPRED = ""
                            vl_stFIPREDIF = ""
                            vl_stFIPRUNPR = ""

                            pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                        End If
                    End If
                End If

                '==============================
                '*** Inserta tabla FIPRPROP ***
                '==============================
                If stContenidoRegistro = "4" Then

                    ' variables indirectas
                    Dim stFPPRESTA As String = "ac"
                    Dim inFPPRNURE As Integer = 0
                    Dim inFPPRSECU As Integer = 0
                    Dim boFPPRGRAV As Boolean = False
                    Dim boFPPRLITI As Boolean = False
                    Dim stFPPRDENO As String = ""
                    Dim stFPPRMUNO As String = ""

                    ' variables directas
                    Dim inFPPRNUFI As Integer = stContenidoLinea.Substring(15, 9).ToString
                    Dim inFPPRTIDO As Integer = stContenidoLinea.Substring(29, 2).ToString
                    Dim stFPPRNUDO As String = stContenidoLinea.Substring(31, 14).ToString
                    Dim sTFPPRPRAP As String = Trim(stContenidoLinea.Substring(45, 15).ToString)
                    Dim stFPPRNOMB As String = Trim(stContenidoLinea.Substring(60, 20).ToString)
                    Dim stFPPRDERE As String = stContenidoLinea.Substring(80, 9).ToString
                    Dim stFPPRNOTA As String = stContenidoLinea.Substring(89, 10).ToString
                    Dim inFPPRESCR As Integer = stContenidoLinea.Substring(99, 7).ToString
                    Dim stFPPRFEES As String = stContenidoLinea.Substring(106, 10).ToString
                    Dim stFPPRFERE As String = stContenidoLinea.Substring(116, 10).ToString
                    Dim inFPPRTOMO As Integer = stContenidoLinea.Substring(126, 3).ToString
                    Dim stFPPRMAIN As String = stContenidoLinea.Substring(129, 15).ToString
                    Dim inFPPRCAPR As Integer = stContenidoLinea.Substring(144, 2).ToString
                    Dim inFPPRGRAV As Integer = stContenidoLinea.Substring(146, 1).ToString
                    Dim inFPPRMOAD As Integer = stContenidoLinea.Substring(147, 1).ToString
                    Dim inFPPRLITI As Integer = stContenidoLinea.Substring(148, 1).ToString
                    Dim stFPPRPOLI As String = stContenidoLinea.Substring(149, 5).ToString
                    Dim stFPPRSEAP As String = Trim(stContenidoLinea.Substring(154, 15).ToString)
                    Dim stFPPRSICO As String = stContenidoLinea.Substring(169, 20).ToString
                    Dim inFPPRSEXO As Integer = stContenidoLinea.Substring(189, 1).ToString

                    ' campo derecho
                    Dim stFPPRDERE_1 As String = Val(stFPPRDERE.Substring(0, 3))
                    Dim stFPPRDERE_2 As String = "."
                    Dim stFPPRDERE_3 As String = stFPPRDERE.Substring(3, 6)
                    Dim stFPPRDERE_4 As String = stFPPRDERE_1 & stFPPRDERE_2 & stFPPRDERE_3

                    stFPPRDERE = CType(fun_Formato_Decimal_6_Decimales(stFPPRDERE_4), String)

                    ' campo porcentaje de litigio
                    Dim stFPPRPOLI_1 As String = Val(stFPPRPOLI.Substring(0, 3))
                    Dim stFPPRPOLI_2 As String = "."
                    Dim stFPPRPOLI_3 As String = stFPPRPOLI.Substring(3, 2)
                    Dim stFPPRPOLI_4 As String = stFPPRPOLI_1 & stFPPRPOLI_2 & stFPPRPOLI_3

                    stFPPRPOLI = CType(fun_Formato_Decimal_2_Decimales(stFPPRPOLI_4), String)

                    ' verifica el formato de las fechas
                    If fun_Verificar_Dato_Fecha_Evento_Validated(stFPPRFEES) = True Then

                        Dim stFPPRFEES_1 As String = stFPPRFEES.Replace("/", "-").ToString
                        stFPPRFEES = stFPPRFEES_1

                        Dim stDia As String = stFPPRFEES.ToString.Substring(0, 2)
                        Dim stMes As String = stFPPRFEES.ToString.Substring(3, 2)
                        Dim stAno As String = stFPPRFEES.ToString.Substring(6, 4)

                        stFPPRFEES = stDia & "-" & stMes & "-" & stAno

                    Else
                        stFPPRFEES = ""

                    End If

                    If fun_Verificar_Dato_Fecha_Evento_Validated(stFPPRFERE) = True Then

                        Dim stFPPRFERE_1 As String = stFPPRFERE.Replace("/", "-").ToString
                        stFPPRFERE = stFPPRFERE_1

                        Dim stDia As String = stFPPRFERE.ToString.Substring(0, 2)
                        Dim stMes As String = stFPPRFERE.ToString.Substring(3, 2)
                        Dim stAno As String = stFPPRFERE.ToString.Substring(6, 4)

                        stFPPRFERE = stDia & "-" & stMes & "-" & stAno

                    Else
                        stFPPRFERE = ""

                    End If

                    ' verifica el formato de la notaria
                    stFPPRDENO = Trim(stFPPRNOTA.Substring(0, 2).ToString)
                    stFPPRMUNO = Trim(stFPPRNOTA.Substring(2, 3).ToString)
                    stFPPRNOTA = Trim(stFPPRNOTA.Substring(5, 5).ToString)

                    ' convierte en variable boleona
                    If inFPPRGRAV = 1 Then
                        boFPPRGRAV = True
                    Else
                        boFPPRGRAV = False
                    End If

                    If inFPPRLITI = 1 Then
                        boFPPRLITI = True
                    Else
                        boFPPRLITI = False
                    End If

                    ' inserta solo predios nuevos
                    If boPredioNuevo = True And Me.rbdInsertaPrediosNuevosResolucionActualizacion.Checked = True Then

                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPPRNUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPPRNURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' asigna numero de documento para codigo asignado
                            If Trim(stFPPRNUDO) = "" Then
                                stFPPRNUDO = inNroDeRegistroDelPlano
                            End If

                            ' busca la secuencia de registro
                            inFPPRSECU = fun_BuscarNroSecuenciaPropietario(inFPPRNUFI)

                            ' instancia la clase 
                            Dim obj_FIPRPROP As New cla_FIPRPROP

                            ' inserta el registro
                            obj_FIPRPROP.fun_Insertar_FIPRPROP(inFPPRNUFI, inFPPRCAPR, inFPPRSEXO, inFPPRTIDO, stFPPRNUDO, sTFPPRPRAP, stFPPRSEAP, stFPPRNOMB, stFPPRDERE, stFPPRSICO, inFPPRESCR, stFPPRDENO, stFPPRMUNO, stFPPRNOTA, stFPPRFEES, stFPPRFERE, inFPPRTOMO, stFPPRMAIN, boFPPRGRAV, inFPPRMOAD, boFPPRLITI, stFPPRPOLI, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPPRSECU, inFPPRNURE, stFPPRESTA)

                            ' actualiza ficha predial
                            pro_ActualizarFichaPredial(inFPPRNUFI, inFPPRMOAD, inFPPRLITI, stFPPRPOLI)

                            ' instancia la clase tercero
                            Dim obj_TERCERO As New cla_TERCERO
                            Dim tbl_TERCERO As New DataTable

                            tbl_TERCERO = obj_TERCERO.fun_Buscar_CODIGO_TERCERO(stFPPRNUDO)

                            If tbl_TERCERO.Rows.Count = 0 Then

                                Dim obj1_TERCERO As New cla_TERCERO

                                obj1_TERCERO.fun_Insertar_TERCERO(stFPPRNUDO, inFPPRTIDO, inFPPRCAPR, inFPPRSEXO, stFPPRNOMB, sTFPPRPRAP, stFPPRSEAP, stFPPRSICO, "", "", "", "", "ac", "Tercero ingresado por importación de datos")

                            End If

                        End If

                    Else

                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPPRNUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPPRNURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' asigna numero de documento para codigo asignado
                            If Trim(stFPPRNUDO) = "" Then
                                stFPPRNUDO = inNroDeRegistroDelPlano
                            End If

                            ' instancia la clase
                            Dim obj2_FIPRPROP As New cla_FIPRPROP
                            Dim tbl2 As New DataTable

                            ' consulta si ya existe el propietario
                            tbl2 = obj2_FIPRPROP.fun_Buscar_CODIGO_FIPRPROP(inFPPRNUFI, stFPPRNUDO)

                            ' cuenta los registros
                            If tbl2.Rows.Count = 0 Then

                                ' busca la secuencia de registro
                                inFPPRSECU = fun_BuscarNroSecuenciaPropietario(inFPPRNUFI)

                                ' instancia la clase 
                                Dim obj_FIPRPROP As New cla_FIPRPROP

                                If Me.rbdActualizarInsertarPrediosResolucionActualizacion.Checked = True And Me.chkPropietarioResolucionActualizacion.Checked = True And boPredioNuevo = False Then
                                    ' inserta el registro
                                    obj_FIPRPROP.fun_Insertar_FIPRPROP(inFPPRNUFI, inFPPRCAPR, inFPPRSEXO, inFPPRTIDO, stFPPRNUDO, sTFPPRPRAP, stFPPRSEAP, stFPPRNOMB, stFPPRDERE, stFPPRSICO, inFPPRESCR, stFPPRDENO, stFPPRMUNO, stFPPRNOTA, stFPPRFEES, stFPPRFERE, inFPPRTOMO, stFPPRMAIN, boFPPRGRAV, inFPPRMOAD, boFPPRLITI, stFPPRPOLI, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPPRSECU, inFPPRNURE, stFPPRESTA)

                                ElseIf Me.chkSobrescribirBDexistenteResolucionActualizacion.Checked = True Or boPredioNuevo = True Then
                                    ' inserta el registro
                                    obj_FIPRPROP.fun_Insertar_FIPRPROP(inFPPRNUFI, inFPPRCAPR, inFPPRSEXO, inFPPRTIDO, stFPPRNUDO, sTFPPRPRAP, stFPPRSEAP, stFPPRNOMB, stFPPRDERE, stFPPRSICO, inFPPRESCR, stFPPRDENO, stFPPRMUNO, stFPPRNOTA, stFPPRFEES, stFPPRFERE, inFPPRTOMO, stFPPRMAIN, boFPPRGRAV, inFPPRMOAD, boFPPRLITI, stFPPRPOLI, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPPRSECU, inFPPRNURE, stFPPRESTA)

                                End If

                                ' actualiza ficha predial
                                pro_ActualizarFichaPredial(inFPPRNUFI, inFPPRMOAD, inFPPRLITI, stFPPRPOLI)

                                ' instancia la clase tercero
                                Dim obj_TERCERO As New cla_TERCERO
                                Dim tbl_TERCERO As New DataTable

                                tbl_TERCERO = obj_TERCERO.fun_Buscar_CODIGO_TERCERO(stFPPRNUDO)

                                If tbl_TERCERO.Rows.Count = 0 Then

                                    Dim obj1_TERCERO As New cla_TERCERO

                                    obj1_TERCERO.fun_Insertar_TERCERO(stFPPRNUDO, inFPPRTIDO, inFPPRCAPR, inFPPRSEXO, stFPPRNOMB, sTFPPRPRAP, stFPPRSEAP, stFPPRSICO, "", "", "", "", "ac", "Tercero ingresado por importación de datos")

                                End If

                            ElseIf Me.chkSobrescribirBDexistenteResolucionActualizacion.Checked = True Or boPredioNuevo = True Then

                                ' guarda la inconsistencia
                                vl_inFIPRNUFI = inFPPRNUFI
                                vl_stFPINCODI = "4-PROPIETARIO"
                                vl_stFPINDESC = "Nro. documento " & stFPPRNUDO & " existe en base de datos. " & inFPPRNUFI
                                vl_stFIPRMUNI = vl_stRESOMUNI
                                vl_stFIPRCORR = ""
                                vl_stFIPRBARR = ""
                                vl_stFIPRMANZ = ""
                                vl_stFIPRPRED = ""
                                vl_stFIPREDIF = ""
                                vl_stFIPRUNPR = ""

                                pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                            End If


                        Else

                            ' guarda la inconsistencia
                            vl_inFIPRNUFI = inFPPRNUFI
                            vl_stFPINCODI = "4-PROPIETARIO"
                            vl_stFPINDESC = "Ficha " & inFPPRNUFI & " no existe en base de datos."
                            vl_stFIPRMUNI = vl_stRESOMUNI
                            vl_stFIPRCORR = ""
                            vl_stFIPRBARR = ""
                            vl_stFIPRMANZ = ""
                            vl_stFIPRPRED = ""
                            vl_stFIPREDIF = ""
                            vl_stFIPRUNPR = ""

                            pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                        End If

                    End If

                End If

                '===============================
                '*** Insertar tabla FIPRCONS ***
                '===============================
                If stContenidoRegistro = "5" Then

                    ' variables indirectas
                    Dim stFPCOESTA As String = "ac"
                    Dim inFPCONURE As Integer = 0
                    Dim inFPCOSECU As Integer = 0
                    Dim boFPCOMEJO As Boolean = False
                    Dim boFPCOLEY As Boolean = False
                    Dim inFPCOCLCO As Integer = 1
                    Dim inFPCOAVCO As Integer = 0

                    ' variables directas
                    Dim inFPCONUFI As Integer = stContenidoLinea.Substring(15, 9).ToString
                    Dim inFPCOUNID As Integer = stContenidoLinea.Substring(29, 5).ToString
                    Dim inFPCOPUNT As Integer = stContenidoLinea.Substring(34, 3).ToString
                    Dim stFPCOARCO As String = stContenidoLinea.Substring(37, 9).ToString
                    Dim inFPCOMEJO As Integer = stContenidoLinea.Substring(46, 1).ToString
                    Dim inFPCOLEY As Integer = stContenidoLinea.Substring(47, 1).ToString
                    Dim stFPCOTICO As String = stContenidoLinea.Substring(48, 3).ToString
                    Dim inFPCOACUE As Integer = stContenidoLinea.Substring(51, 1).ToString
                    Dim inFPCOTELE As Integer = stContenidoLinea.Substring(52, 1).ToString
                    Dim inFPCOALCA As Integer = stContenidoLinea.Substring(53, 1).ToString
                    Dim inFPCOENER As Integer = stContenidoLinea.Substring(54, 1).ToString
                    Dim inFPCOGAS As Integer = stContenidoLinea.Substring(55, 1).ToString
                    Dim inFPCOPISO As Integer = stContenidoLinea.Substring(56, 2).ToString
                    Dim inFPCOPOCO As Integer = stContenidoLinea.Substring(58, 3).ToString
                    Dim inFPCOEDCO As Integer = stContenidoLinea.Substring(61, 4).ToString

                    ' campo porcentaje de litigio
                    Dim stFPCOARCO_1 As String = Val(stFPCOARCO.Substring(0, 7))
                    Dim stFPCOARCO_2 As String = "."
                    Dim stFPCOARCO_3 As String = stFPCOARCO.Substring(7, 2)
                    Dim stFPCOARCO_4 As String = stFPCOARCO_1 & stFPCOARCO_2 & stFPCOARCO_3

                    stFPCOARCO = CType(fun_Formato_Decimal_2_Decimales(stFPCOARCO_4), String)

                    ' variables boleanas
                    If inFPCOMEJO = 1 Then
                        boFPCOMEJO = True
                    Else
                        boFPCOMEJO = False
                    End If

                    If inFPCOLEY = 1 Then
                        boFPCOLEY = True
                    Else
                        boFPCOLEY = False
                    End If

                    ' coloca la clase 1
                    If stFPCOTICO < 500 AndAlso _
                           stFPCOTICO <> "020" AndAlso stFPCOTICO <> "037" AndAlso _
                           stFPCOTICO <> "019" AndAlso stFPCOTICO <> "028" AndAlso _
                           stFPCOTICO <> "032" AndAlso stFPCOTICO <> "072" AndAlso _
                           stFPCOTICO <> "074" AndAlso stFPCOTICO <> "075" AndAlso _
                           stFPCOTICO <> "076" AndAlso stFPCOTICO <> "077" AndAlso _
                           stFPCOTICO <> "078" AndAlso stFPCOTICO <> "073" Then

                        inFPCOCLCO = 1
                    End If

                    ' coloca la clase 2
                    If stFPCOTICO < 500 AndAlso _
                           stFPCOTICO = "020" Or stFPCOTICO = "037" Or _
                           stFPCOTICO = "019" Or stFPCOTICO = "028" Or _
                           stFPCOTICO = "032" Or stFPCOTICO = "072" Or _
                           stFPCOTICO = "074" Or stFPCOTICO = "075" Or _
                           stFPCOTICO = "076" Or stFPCOTICO = "077" Or _
                           stFPCOTICO = "078" Or stFPCOTICO = "073" Then

                        inFPCOCLCO = 2
                    End If

                    ' coloca la clase 3
                    If stFPCOTICO > 500 Then
                        inFPCOCLCO = 3
                    End If

                    ' inserta solo predios nuevos
                    If boPredioNuevo = True And Me.rbdInsertaPrediosNuevosResolucionActualizacion.Checked = True Then

                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPCONUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPCONURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' busca la secuencia de registro
                            inFPCOSECU = fun_BuscarNroSecuenciaConstruccion(inFPCONUFI)

                            ' instancia la clase 
                            Dim obj_FIPRCONS As New cla_FIPRCONS

                            ' inserta el registro
                            obj_FIPRCONS.fun_Insertar_FIPRCONS(inFPCONUFI, inFPCOUNID, inFPCOCLCO, stFPCOTICO, inFPCOPUNT, stFPCOARCO, inFPCOACUE, inFPCOALCA, inFPCOENER, inFPCOTELE, inFPCOGAS, inFPCOPISO, inFPCOEDCO, inFPCOPOCO, boFPCOMEJO, boFPCOLEY, inFPCOAVCO, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPCOSECU, inFPCONURE, stFPCOESTA)

                        End If

                    Else

                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPCONUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPCONURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' instancia la clase
                            Dim obj2_FIPRCONS As New cla_FIPRCONS
                            Dim tbl2 As New DataTable

                            ' consulta si ya existe el propietario
                            tbl2 = obj2_FIPRCONS.fun_Buscar_CODIGO_FIPRCONS(inFPCONUFI, inFPCOUNID)

                            ' cuenta los registros
                            If tbl2.Rows.Count = 0 Then

                                ' busca la secuencia de registro
                                inFPCOSECU = fun_BuscarNroSecuenciaConstruccion(inFPCONUFI)

                                ' instancia la clase 
                                Dim obj_FIPRCONS As New cla_FIPRCONS

                                If Me.rbdActualizarInsertarPrediosResolucionActualizacion.Checked = True And Me.chkConstruccionResolucionActualizacion.Checked = True And boPredioNuevo = False Then
                                    ' inserta el registro
                                    obj_FIPRCONS.fun_Insertar_FIPRCONS(inFPCONUFI, inFPCOUNID, inFPCOCLCO, stFPCOTICO, inFPCOPUNT, stFPCOARCO, inFPCOACUE, inFPCOALCA, inFPCOENER, inFPCOTELE, inFPCOGAS, inFPCOPISO, inFPCOEDCO, inFPCOPOCO, boFPCOMEJO, boFPCOLEY, inFPCOAVCO, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPCOSECU, inFPCONURE, stFPCOESTA)

                                ElseIf Me.chkSobrescribirBDexistenteResolucionActualizacion.Checked = True Or boPredioNuevo = True Then
                                    ' inserta el registro
                                    obj_FIPRCONS.fun_Insertar_FIPRCONS(inFPCONUFI, inFPCOUNID, inFPCOCLCO, stFPCOTICO, inFPCOPUNT, stFPCOARCO, inFPCOACUE, inFPCOALCA, inFPCOENER, inFPCOTELE, inFPCOGAS, inFPCOPISO, inFPCOEDCO, inFPCOPOCO, boFPCOMEJO, boFPCOLEY, inFPCOAVCO, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPCOSECU, inFPCONURE, stFPCOESTA)

                                End If

                            ElseIf Me.chkSobrescribirBDexistenteResolucionActualizacion.Checked = True Or boPredioNuevo = True Then

                                ' guarda la inconsistencia
                                vl_inFIPRNUFI = inFPCONUFI
                                vl_stFPINCODI = "5-CONSTRUCCION"
                                vl_stFPINDESC = "Nro. construcción " & inFPCOUNID & " existe en base de datos. " & inFPCONUFI
                                vl_stFIPRMUNI = vl_stRESOMUNI
                                vl_stFIPRCORR = ""
                                vl_stFIPRBARR = ""
                                vl_stFIPRMANZ = ""
                                vl_stFIPRPRED = ""
                                vl_stFIPREDIF = ""
                                vl_stFIPRUNPR = ""

                                pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                            End If

                        Else

                            ' guarda la inconsistencia
                            vl_inFIPRNUFI = inFPCONUFI
                            vl_stFPINCODI = "5-CONSTRUCCION"
                            vl_stFPINDESC = "Ficha " & inFPCONUFI & " no existe en base de datos."
                            vl_stFIPRMUNI = vl_stRESOMUNI
                            vl_stFIPRCORR = ""
                            vl_stFIPRBARR = ""
                            vl_stFIPRMANZ = ""
                            vl_stFIPRPRED = ""
                            vl_stFIPREDIF = ""
                            vl_stFIPRUNPR = ""

                            pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                        End If
                    End If
                End If

                '===============================
                '*** Insertar tabla FIPRCACO ***
                '===============================
                If stContenidoRegistro = "6" Then

                    ' variables indirectas
                    Dim stFPCCESTA As String = "ac"
                    Dim inFPCCNURE As Integer = 0
                    Dim inFPCCSECU As Integer = 0
                    Dim inFPCCCLCO As Integer = 1
                    Dim stFPCCTICO As String = ""

                    ' variables directas
                    Dim inFPCCNUFI As Integer = stContenidoLinea.Substring(15, 9).ToString
                    Dim inFPCCUNID As Integer = stContenidoLinea.Substring(29, 5).ToString
                    Dim stFPCCTIPO As String = stContenidoLinea.Substring(34, 1).ToString
                    Dim inFPCCCODI As Integer = stContenidoLinea.Substring(35, 4).ToString
                    Dim inFPCCPUNT As Integer = stContenidoLinea.Substring(39, 3).ToString

                    ' inserta solo predios nuevos
                    If boPredioNuevo = True And Me.rbdInsertaPrediosNuevosResolucionActualizacion.Checked = True Then

                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPCCNUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPCCNURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' instancia la clase
                            Dim obj2_FIPRCONS As New cla_FIPRCONS
                            Dim tbl2 As New DataTable

                            ' consulta si ya existe la construcción
                            tbl2 = obj2_FIPRCONS.fun_Buscar_CODIGO_FIPRCONS(inFPCCNUFI, inFPCCUNID)

                            ' cuenta los registros
                            If tbl2.Rows.Count > 0 Then

                                ' busca la secuencia de registro
                                inFPCCSECU = Val(tbl2.Rows(0).Item("FPCOSECU"))

                                ' busca la clase y el identificador
                                inFPCCCLCO = Val(tbl2.Rows(0).Item("FPCOCLCO"))
                                stFPCCTICO = tbl2.Rows(0).Item("FPCOTICO")

                                ' instancia la clase 
                                Dim obj_FIPRCACO1 As New cla_FIPRCACO

                                ' inserta el registro
                                obj_FIPRCACO1.fun_Insertar_FIPRCACO(inFPCCNUFI, inFPCCCODI, stFPCCTIPO, inFPCCPUNT, inFPCCUNID, inFPCCCLCO, stFPCCTICO, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPCCSECU, inFPCCNURE, stFPCCESTA)

                            End If

                        End If

                    Else

                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPCCNUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPCCNURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' instancia la clase
                            Dim obj2_FIPRCONS As New cla_FIPRCONS
                            Dim tbl2 As New DataTable

                            ' consulta si ya existe la construcción
                            tbl2 = obj2_FIPRCONS.fun_Buscar_CODIGO_FIPRCONS(inFPCCNUFI, inFPCCUNID)

                            ' cuenta los registros
                            If tbl2.Rows.Count > 0 Then

                                ' busca la secuencia de registro
                                inFPCCSECU = Val(tbl2.Rows(0).Item("FPCOSECU"))

                                ' busca la clase y el identificador
                                inFPCCCLCO = Val(tbl2.Rows(0).Item("FPCOCLCO"))
                                stFPCCTICO = tbl2.Rows(0).Item("FPCOTICO")

                                ' instancia la clase 
                                Dim obj_FIPRCACO As New cla_FIPRCACO
                                Dim tbl3 As New DataTable

                                ' verifica si el código de calificación existe
                                Dim tbl13 As New DataTable

                                tbl13 = obj_FIPRCACO.fun_Buscar_CODIGO_FIPRCACO(inFPCCNUFI, inFPCCCODI, inFPCCUNID)

                                If tbl13.Rows.Count = 0 Then

                                    ' instancia la clase 
                                    Dim obj_FIPRCACO1 As New cla_FIPRCACO

                                    If Me.rbdActualizarInsertarPrediosResolucionActualizacion.Checked = True And Me.chkConstruccionResolucionActualizacion.Checked = True And boPredioNuevo = False Then
                                        ' inserta el registro
                                        obj_FIPRCACO1.fun_Insertar_FIPRCACO(inFPCCNUFI, inFPCCCODI, stFPCCTIPO, inFPCCPUNT, inFPCCUNID, inFPCCCLCO, stFPCCTICO, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPCCSECU, inFPCCNURE, stFPCCESTA)

                                    ElseIf Me.chkSobrescribirBDexistenteResolucionActualizacion.Checked = True Or boPredioNuevo = True Then
                                        ' inserta el registro
                                        obj_FIPRCACO1.fun_Insertar_FIPRCACO(inFPCCNUFI, inFPCCCODI, stFPCCTIPO, inFPCCPUNT, inFPCCUNID, inFPCCCLCO, stFPCCTICO, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPCCSECU, inFPCCNURE, stFPCCESTA)

                                    End If

                                ElseIf Me.chkSobrescribirBDexistenteResolucionActualizacion.Checked = True Or boPredioNuevo = True Then

                                    ' guarda la inconsistencia
                                    vl_inFIPRNUFI = inFPCCNUFI
                                    vl_stFPINCODI = "6-CALIFICACION"
                                    vl_stFPINDESC = "Nro. código " & inFPCCCODI & " existe en base de datos unidad: " & inFPCCUNID & " Nro. ficha: " & inFPCCNUFI
                                    vl_stFIPRMUNI = vl_stRESOMUNI
                                    vl_stFIPRCORR = ""
                                    vl_stFIPRBARR = ""
                                    vl_stFIPRMANZ = ""
                                    vl_stFIPRPRED = ""
                                    vl_stFIPREDIF = ""
                                    vl_stFIPRUNPR = ""

                                    pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)
                                End If

                            Else
                                ' guarda la inconsistencia
                                vl_inFIPRNUFI = inFPCCNUFI
                                vl_stFPINCODI = "6-CALIFICACION"
                                vl_stFPINDESC = "Nro. construcción " & inFPCCUNID & " existe en base de datos. " & inFPCCNUFI
                                vl_stFIPRMUNI = vl_stRESOMUNI
                                vl_stFIPRCORR = ""
                                vl_stFIPRBARR = ""
                                vl_stFIPRMANZ = ""
                                vl_stFIPRPRED = ""
                                vl_stFIPREDIF = ""
                                vl_stFIPRUNPR = ""

                                pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                            End If

                        Else

                            ' guarda la inconsistencia
                            vl_inFIPRNUFI = inFPCCNUFI
                            vl_stFPINCODI = "6-CALIFICACION"
                            vl_stFPINDESC = "Ficha " & inFPCCNUFI & " no existe en base de datos."
                            vl_stFIPRMUNI = vl_stRESOMUNI
                            vl_stFIPRCORR = ""
                            vl_stFIPRBARR = ""
                            vl_stFIPRMANZ = ""
                            vl_stFIPRPRED = ""
                            vl_stFIPREDIF = ""
                            vl_stFIPRUNPR = ""

                            pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                        End If
                    End If
                End If

                '===============================
                '*** Insertar tabla FIPRLIND ***
                '===============================
                If stContenidoRegistro = "7" Then

                    ' variables indirectas
                    Dim stFPLIESTA As String = "ac"
                    Dim inFPLINURE As Integer = 0
                    Dim inFPLISECU As Integer = 0

                    ' variables directas
                    Dim inFPLINUFI As Integer = stContenidoLinea.Substring(15, 9).ToString
                    Dim stFPLIPUCA As String = stContenidoLinea.Substring(29, 2).ToString
                    Dim stFPLICOLI As String = Trim(stContenidoLinea.Substring(31, inNroDeCaracteresLindero).ToString)

                    ' inserta solo predios nuevos
                    If boPredioNuevo = True And Me.rbdInsertaPrediosNuevosResolucionActualizacion.Checked = True Then

                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPLINUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPLINURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' busca la secuencia de registro
                            inFPLISECU = fun_BuscarNroSecuenciaLindero(inFPLINUFI)

                            ' instancia la clase 
                            Dim obj_FIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            obj_FIPRLIND.fun_Insertar_FIPRLIND(inFPLINUFI, stFPLIPUCA, stFPLICOLI, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPLISECU, inFPLINURE, stFPLIESTA)

                        End If

                    Else

                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPLINUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPLINURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' busca la secuencia de registro
                            inFPLISECU = fun_BuscarNroSecuenciaLindero(inFPLINUFI)

                            ' instancia la clase 
                            Dim obj_FIPRLIND As New cla_FIPRLIND

                            If Me.rbdActualizarInsertarPrediosResolucionActualizacion.Checked = True And Me.chkLinderoResolucionActualizacion.Checked = True And boPredioNuevo = False Then
                                ' inserta el registro
                                obj_FIPRLIND.fun_Insertar_FIPRLIND(inFPLINUFI, stFPLIPUCA, stFPLICOLI, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPLISECU, inFPLINURE, stFPLIESTA)

                            ElseIf Me.chkSobrescribirBDexistenteResolucionActualizacion.Checked = True Or boPredioNuevo = True Then
                                ' inserta el registro
                                obj_FIPRLIND.fun_Insertar_FIPRLIND(inFPLINUFI, stFPLIPUCA, stFPLICOLI, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPLISECU, inFPLINURE, stFPLIESTA)

                            End If

                        Else

                            ' guarda la inconsistencia
                            vl_inFIPRNUFI = inFPLINUFI
                            vl_stFPINCODI = "7-LINDEROS"
                            vl_stFPINDESC = "Ficha " & inFPLINUFI & " no existe en base de datos."
                            vl_stFIPRMUNI = vl_stRESOMUNI
                            vl_stFIPRCORR = ""
                            vl_stFIPRBARR = ""
                            vl_stFIPRMANZ = ""
                            vl_stFIPRPRED = ""
                            vl_stFIPREDIF = ""
                            vl_stFIPRUNPR = ""

                            pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                        End If
                    End If
                End If

                '===============================
                '*** Insertar tabla FIPRCART ***
                '===============================
                If stContenidoRegistro = "8" Then

                    ' variables indirectas
                    Dim stFPCAESTA As String = "ac"
                    Dim inFPCANURE As Integer = 0
                    Dim inFPCASECU As Integer = 0

                    ' variables directas
                    Dim inFPCANUFI As Integer = stContenidoLinea.Substring(15, 9).ToString
                    Dim stFPCAPLAN As String = stContenidoLinea.Substring(29, 15).ToString
                    Dim stFPCAVENT As String = stContenidoLinea.Substring(44, 15).ToString
                    Dim stFPCAESGR As String = stContenidoLinea.Substring(59, 15).ToString
                    Dim inFPCAVIGR As Integer = stContenidoLinea.Substring(74, 4).ToString
                    Dim stFPCAVUEL As String = stContenidoLinea.Substring(78, 15).ToString
                    Dim stFPCAFAJA As String = stContenidoLinea.Substring(93, 15).ToString
                    Dim stFPCAFOTO As String = stContenidoLinea.Substring(108, 15).ToString
                    Dim inFPCAVIAE As Integer = stContenidoLinea.Substring(123, 4).ToString
                    Dim stFPCAAMPL As String = stContenidoLinea.Substring(127, 15).ToString
                    Dim stFPCAESAE As String = stContenidoLinea.Substring(142, inNroDeCaracteresCartografia).ToString

                    ' inserta solo predios nuevos
                    If boPredioNuevo = True And Me.rbdInsertaPrediosNuevosResolucionActualizacion.Checked = True Then

                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPCANUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPCANURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' busca la secuencia de registro
                            inFPCASECU = fun_BuscarNroSecuenciaCartografia(inFPCANUFI)

                            ' instancia la clase 
                            Dim obj_FIPRCART As New cla_FIPRCART

                            ' inserta el registro
                            obj_FIPRCART.fun_Insertar_FIPRCART(inFPCANUFI, stFPCAPLAN, stFPCAVENT, stFPCAESGR, inFPCAVIGR, stFPCAVUEL, stFPCAFAJA, stFPCAFOTO, inFPCAVIAE, stFPCAAMPL, stFPCAESAE, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPCASECU, inFPCANURE, stFPCAESTA)

                        End If

                    Else

                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPCANUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPCANURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' busca la secuencia de registro
                            inFPCASECU = fun_BuscarNroSecuenciaCartografia(inFPCANUFI)

                            ' instancia la clase 
                            Dim obj_FIPRCART As New cla_FIPRCART

                            If Me.rbdActualizarInsertarPrediosResolucionActualizacion.Checked = True And Me.chkCartografiaResolucionActualizacion.Checked = True And boPredioNuevo = False Then
                                ' inserta el registro
                                obj_FIPRCART.fun_Insertar_FIPRCART(inFPCANUFI, stFPCAPLAN, stFPCAVENT, stFPCAESGR, inFPCAVIGR, stFPCAVUEL, stFPCAFAJA, stFPCAFOTO, inFPCAVIAE, stFPCAAMPL, stFPCAESAE, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPCASECU, inFPCANURE, stFPCAESTA)

                            ElseIf Me.chkSobrescribirBDexistenteResolucionActualizacion.Checked = True Or boPredioNuevo = True Then
                                ' inserta el registro
                                obj_FIPRCART.fun_Insertar_FIPRCART(inFPCANUFI, stFPCAPLAN, stFPCAVENT, stFPCAESGR, inFPCAVIGR, stFPCAVUEL, stFPCAFAJA, stFPCAFOTO, inFPCAVIAE, stFPCAAMPL, stFPCAESAE, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPCASECU, inFPCANURE, stFPCAESTA)

                            End If

                        Else

                            ' guarda la inconsistencia
                            vl_inFIPRNUFI = inFPCANUFI
                            vl_stFPINCODI = "8-CARTOGRAFIA"
                            vl_stFPINDESC = "Ficha " & inFPCANUFI & " no existe en base de datos."
                            vl_stFIPRMUNI = vl_stRESOMUNI
                            vl_stFIPRCORR = ""
                            vl_stFIPRBARR = ""
                            vl_stFIPRMANZ = ""
                            vl_stFIPRPRED = ""
                            vl_stFIPREDIF = ""
                            vl_stFIPRUNPR = ""

                            pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                        End If
                    End If
                End If

                ' Incrementa la barra
                inProceso = inProceso + 1
                pbProcesoResolucionActualizacion.Value = inProceso

            Loop

            ' consulta las inconsistencas de las fichas validadas
            Dim objdatos As New cla_VALIFIPR
            Dim tbl As New DataTable

            tbl = objdatos.fun_Consultar_INCONSISTENCIA_X_RESOLUCION(stRESOLUCION)

            ' Crea objeto de columnas y registros
            Dim dt1 As New DataTable
            Dim dr1 As DataRow

            ' Crea las columnas
            dt1.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
            dt1.Columns.Add(New DataColumn("Cedula catastral", GetType(String)))
            dt1.Columns.Add(New DataColumn("Codigo incons.", GetType(String)))
            dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))

            Dim i As Integer

            For i = 0 To tbl.Rows.Count - 1

                dr1 = dt1.NewRow()
                dr1("Nro_Ficha") = tbl.Rows(i).Item("FPINNUFI")
                dr1("Cedula catastral") = tbl.Rows(i).Item("FPINMUNI") & "-" & _
                                         tbl.Rows(i).Item("FPINCORR") & "-" & _
                                         tbl.Rows(i).Item("FPINBARR") & "-" & _
                                         tbl.Rows(i).Item("FPINMANZ") & "-" & _
                                         tbl.Rows(i).Item("FPINPRED") & "-" & _
                                         tbl.Rows(i).Item("FPINEDIF") & "-" & _
                                         tbl.Rows(i).Item("FPINUNPR")
                dr1("Codigo incons.") = tbl.Rows(i).Item("FPINCODI")
                dr1("Descripcion") = tbl.Rows(i).Item("FPINDESC")
                dt1.Rows.Add(dr1)

            Next

            ' Llena el datagrigview
            TabControl1.SelectTab(TabPage1)
            Me.dgvFIPRINCO.DataSource = dt1
            pbProcesoResolucionActualizacion.Value = 0

            ' comando grabar datos
            If dt1.Rows.Count = 0 Then
                MessageBox.Show("Proceso de guardado terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("Proceso de guardado con inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

            Me.cmdGrabarDatosResolucionActualizacion.Enabled = False
            Me.lblFecha2ResolucionActualizacion.Visible = False
            Me.cmdValidaDatosResolucionActualizacion.Enabled = False

            Me.cmdAbrirArchivoResolucionActualizacion.Focus()

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRINCO.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub pro_GuardarDatosFichaResumenResolucionActualizacion()

        Try
            ' apaga el boton de grabar datos
            Me.cmdGrabarDatosResolucionActualizacion.Enabled = False

            ' eliminar la base de datos existente de acuerdo al archivo plano
            If Me.chkSobrescribirBDexistenteResolucionActualizacion.Checked = True And Me.rbdFichaPredialResolucionActualizacion.Checked = True Then

                ' elimina ficha predial
                If Trim(Me.txtREACMUNI.Text) <> "" And _
                   Trim(Me.txtREACCLSE.Text) <> "" Then

                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtREACMUNI.Text)) = True And _
                       fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtREACCLSE.Text)) = True Then

                        Dim objFichaPredial11 As New cla_FICHPRED

                        objFichaPredial11.fun_Eliminar_DB_FICHA_PREDIAL(Trim(Me.txtREACMUNI.Text), Trim(Me.txtREACCLSE.Text))

                    End If

                End If

            ElseIf Me.chkSobrescribirBDexistenteResolucionActualizacion.Checked = True And Me.rbdFichaResumenResolucionActualizacion.Checked = True Then

                ' elimina ficha resumen
                If Trim(Me.txtREACMUNI.Text) <> "" And _
                   Trim(Me.txtREACCLSE.Text) <> "" Then

                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtREACMUNI.Text)) = True And _
                       fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtREACCLSE.Text)) = True Then

                        Dim objFichaPredial11 As New cla_FICHPRED

                        objFichaPredial11.fun_Eliminar_DB_FICHA_RESUMEN(Trim(Me.txtREACMUNI.Text), Trim(Me.txtREACCLSE.Text))

                    End If

                End If

            End If

            ' almacena la resolucion para la consulta de inconsistencias
            stRESOLUCION = Me.txtREACMUNI.Text & Me.txtREACVIGE.Text & Me.txtREACTIRE.Text & Me.txtREACRESO.Text & Me.txtREACCLSE.Text

            ' instancia la clase
            Dim objdatos11 As New cla_VALIFIPR
            'Dim tbl11 As New DataTable

            ' elimina las inconsistencias
            objdatos11.fun_Eliminar_FIPRINCO_X_RESOLUCION(Trim(stRESOLUCION))

            ' abre el archivo
            FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

            ' almacena la linea
            Dim stContenidoLinea As String = ""
            Dim stContenidoRegistro As String = ""
            Dim inNroDeCaracteresLindero As Integer = 0
            Dim inNroDeCaracteresCartografia As Integer = 0
            Dim stNroDeFichaPredial As String = ""
            Dim inNroDeRegistroDelPlano As Integer = 0

            ' Valores predeterminados ProgressBar
            inProceso = 0
            pbProcesoResolucionActualizacion.Value = 0
            pbProcesoResolucionActualizacion.Maximum = inTotalRegistros + 1
            Timer1.Enabled = True

            ' declara las variables de las resolución
            vl_stRESODEPA = Trim(Me.txtREACDEPA.Text)
            vl_stRESOMUNI = Trim(Me.txtREACMUNI.Text)
            vl_inRESOVIGE = Trim(Me.txtREACVIGE.Text)
            vl_inRESOTIRE = Trim(Me.txtREACTIRE.Text)
            vl_inRESORESO = Trim(Me.txtREACRESO.Text)
            vl_inRESOCLSE = Trim(Me.txtREACCLSE.Text)

            ' recorre el archivo plano y repita hasta que se acabe las lineas
            Do Until EOF(1)

                ' numero de registro del plano utilizado en codigos asignados
                inNroDeRegistroDelPlano += 1

                a = inNroDeRegistroDelPlano

                ' extrae la linea
                stContenidoLinea = LineInput(1)

                ' verifica cual es el registro de la tabla
                stContenidoRegistro = stContenidoLinea.Substring(0, 1).ToString

                ' optiene la longitud de la linea
                If stContenidoRegistro = "6" Then
                    inNroDeCaracteresLindero = stContenidoLinea.Length.ToString - 26
                End If

                If stContenidoRegistro = "5" Then
                    inNroDeCaracteresCartografia = stContenidoLinea.Length.ToString - 137
                End If

                '=====================================
                '*** Inserta tabla FICHA RESUMEN 1 ***
                '=====================================
                If stContenidoRegistro = "1" Then

                    ' variables directas
                    Dim inRES1IDRE As Integer = stContenidoLinea.Substring(0, 1).ToString
                    Dim stRES1MUNI As String = stContenidoLinea.Substring(1, 3).ToString
                    Dim inRES1CLSE As Integer = stContenidoLinea.Substring(4, 1).ToString
                    Dim stRES1CORR As String = stContenidoLinea.Substring(5, 3).ToString
                    Dim stRES1BARR As String = stContenidoLinea.Substring(8, 3).ToString
                    Dim stRES1MANZ As String = stContenidoLinea.Substring(11, 3).ToString
                    Dim stRES1PRED As String = stContenidoLinea.Substring(14, 5).ToString
                    Dim inRES1ATLO As Integer = stContenidoLinea.Substring(19, 11).ToString
                    Dim inRES1ACLO As Integer = stContenidoLinea.Substring(30, 11).ToString
                    Dim inRES1APCA As Integer = stContenidoLinea.Substring(41, 4).ToString
                    Dim inRES1UNCO As Integer = stContenidoLinea.Substring(45, 4).ToString
                    Dim inRES1TOED As Integer = stContenidoLinea.Substring(49, 4).ToString
                    Dim inRES1CUUT As Integer = stContenidoLinea.Substring(53, 4).ToString
                    Dim inRES1LOCA As Integer = stContenidoLinea.Substring(57, 4).ToString
                    Dim inRES1GACU As Integer = stContenidoLinea.Substring(61, 4).ToString
                    Dim inRES1GADE As Integer = stContenidoLinea.Substring(65, 4).ToString
                    Dim stRES1DIRE As String = stContenidoLinea.Substring(69, 49).ToString
                    Dim inRES1CAPR As Integer = stContenidoLinea.Substring(118, 1).ToString

                    ' variables indirectas
                    Dim stRES1DEPA As String = "05"
                    Dim stRES1ESTA As String = "ac"
                    Dim stRES1DESC As String = "."
                    Dim boRES1CONJ As Boolean = False
                    Dim boRES1LITI As Boolean = False
                    Dim boRES1INCO As Boolean = False
                    Dim stRES1POLI As String = "0.00"
                    Dim daRES1FECH As Date = fun_Hora_y_fecha()
                    Dim inRES1MOAD As Integer = 1
                    Dim inRES1TIFI As Integer = 1
                    Dim stRES1EDIF As String = "000"
                    Dim stRES1UNPR As String = "00000"
                    Dim inRES1ARTE As Integer = 0
                    Dim inRES1CASU As Integer = 3
                    Dim stRES1COPR As String = "0.000000"
                    Dim stRES1COED As String = "0.000000"
                    Dim stRES1MUAN As String = stRES1MUNI
                    Dim inRES1CSAN As Integer = inRES1CLSE
                    Dim stRES1COAN As String = stRES1CORR
                    Dim stRES1BAAN As String = stRES1BARR
                    Dim stRES1MAAN As String = stRES1MANZ
                    Dim stRES1PRAN As String = stRES1PRED
                    Dim stRES1EDAN As String = "000"
                    Dim stRES1UPAN As String = "00000"
                    Dim inRES1CASA As Integer = 3
                    Dim inRES1PISO As Integer = 0
                    Dim stRES1RUIM As String = "."
                    Dim inRES1APLO As Integer = 0
                    Dim inRES1URPH As Integer = 0

                    ' formato de campos
                    stRES1MUNI = CType(fun_Formato_Mascara_3_Reales(stRES1MUNI), String)
                    stRES1CORR = CType(fun_Formato_Mascara_2_Reales(stRES1CORR.Substring(1, 2).ToString), String)
                    stRES1BARR = CType(fun_Formato_Mascara_3_Reales(stRES1BARR), String)
                    stRES1MANZ = CType(fun_Formato_Mascara_3_Reales(stRES1MANZ), String)
                    stRES1PRED = CType(fun_Formato_Mascara_5_Reales(stRES1PRED), String)
                    stRES1EDIF = CType(fun_Formato_Mascara_3_Reales(stRES1EDIF), String)
                    stRES1UNPR = CType(fun_Formato_Mascara_5_Reales(stRES1UNPR), String)
                    stRES1MUAN = CType(fun_Formato_Mascara_3_Reales(stRES1MUAN), String)
                    stRES1COAN = CType(fun_Formato_Mascara_2_Reales(stRES1COAN), String)
                    stRES1BAAN = CType(fun_Formato_Mascara_3_Reales(stRES1BAAN), String)
                    stRES1MAAN = CType(fun_Formato_Mascara_3_Reales(stRES1MAAN), String)
                    stRES1PRAN = CType(fun_Formato_Mascara_5_Reales(stRES1PRAN), String)
                    stRES1EDAN = CType(fun_Formato_Mascara_3_Reales(stRES1EDAN), String)
                    stRES1UPAN = CType(fun_Formato_Mascara_5_Reales(stRES1UPAN), String)

                    ' convierte en variable boleona
                    If inRES1CAPR = 3 Or inRES1CAPR = 4 Then
                        boRES1CONJ = True
                    Else
                        boRES1CONJ = False
                    End If

                    ' asignar el numero de ficha resumen
                    pro_AsignarNumeroDeFichaResumen()

                    ' asigna el nuemro de registro
                    pro_AsignarNumeroDeRegistroResolucionActualizacion()

                    ' obtiene la resolucion concatenada
                    pro_ObtenerResolucionCancatenada()

                    ' obtiene la cedula catastral concatenada
                    pro_ObtenerCedulaCatastralConcatenada(stRES1MUNI, stRES1CORR, stRES1BARR, stRES1MANZ, stRES1PRED, stRES1EDIF, stRES1UNPR, inRES1CLSE)

                    ' verifica que la ficha exista
                    Dim objdatos1 As New cla_FICHRESU
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_buscar_CEDULA_CATASTRAL_FICHRESU(stRES1MUNI, stRES1CORR, stRES1BARR, stRES1MANZ, stRES1PRED, stRES1EDIF, stRES1UNPR, inRES1CLSE, inRES1TIFI)

                    ' SI EXISTE LA FICHA SE ELIMINA PORQUE SI EL ARCHIVO TEXTO
                    ' TIENE MODIFICACIONES NO HAY NECESIDAD DE BORRAR EL MUNICIPIO 
                    ' Y SE PUEDE CARGAR PARCIALMENTE LAS MODIFCACIONES, EL BORRADO 
                    ' LO REALIZA LA BASE DE DATOS EN RELACION ELIMINAR EN CASCADA.

                    If tbl1.Rows.Count > 0 Then

                        ' instancia la funcion eliminar
                        Dim obj_FICHPRED As New cla_FICHRESU

                        obj_FICHPRED.fun_eliminar_POR_CEDULA_CATASTRAL_FICHRESU(stRES1MUNI, stRES1CORR, stRES1BARR, stRES1MANZ, stRES1PRED, stRES1EDIF, stRES1UNPR, inRES1CLSE, inRES1TIFI)

                    End If

                    ' instancia la funcion insertar
                    Dim obj_FICHRESU1 As New cla_FICHRESU

                    obj_FICHRESU1.fun_Insertar_FICHRESU(vl_inFIRENUFI, vl_inRESOVIGE, vl_inRESOTIRE, vl_inRESORESO, stRES1DIRE, stRES1DESC, boRES1CONJ, daRES1FECH, vl_inFIPRNURE, vl_stRESODEPA, stRES1MUNI, stRES1CORR, stRES1BARR, stRES1MANZ, stRES1PRED, stRES1EDIF, stRES1UNPR, inRES1CLSE, inRES1CASU, stRES1MUAN, stRES1COAN, stRES1BAAN, stRES1MAAN, stRES1PRAN, stRES1EDAN, stRES1UPAN, inRES1CSAN, inRES1CASA, inRES1CAPR, inRES1MOAD, stRES1ESTA, boRES1LITI, stRES1POLI, vl_stFIPRCORE, inRES1ARTE, stRES1COPR, stRES1COED, inRES1TIFI, boRES1INCO, stRES1RUIM, inRES1ATLO, inRES1ACLO, inRES1APLO, inRES1TOED, inRES1UNCO, inRES1URPH, inRES1APCA, inRES1LOCA, inRES1CUUT, inRES1GACU, inRES1GADE, inRES1PISO)


                End If

                '=====================================
                '*** Inserta tabla FICHA RESUMEN 2 ***
                '=====================================
                If stContenidoRegistro = "2" Then

                    ' variables directas
                    Dim inRES2IDRE As Integer = stContenidoLinea.Substring(0, 1).ToString
                    Dim stRES2MUNI As String = stContenidoLinea.Substring(1, 3).ToString
                    Dim inRES2CLSE As Integer = stContenidoLinea.Substring(4, 1).ToString
                    Dim stRES2CORR As String = stContenidoLinea.Substring(5, 3).ToString
                    Dim stRES2BARR As String = stContenidoLinea.Substring(8, 3).ToString
                    Dim stRES2MANZ As String = stContenidoLinea.Substring(11, 3).ToString
                    Dim stRES2PRED As String = stContenidoLinea.Substring(14, 5).ToString
                    Dim stRES2EDIF As String = stContenidoLinea.Substring(19, 5).ToString

                    If Trim(stRES2EDIF) = "00000" Then
                        stRES2EDIF = "00001"
                    End If

                    Dim inRES2ATLO As Integer = stContenidoLinea.Substring(24, 10).ToString
                    Dim inRES2ACLO As Integer = stContenidoLinea.Substring(34, 10).ToString
                    Dim inRES2PISO As Integer = stContenidoLinea.Substring(44, 3).ToString
                    Dim inRES2URPH As Integer = stContenidoLinea.Substring(47, 4).ToString
                    Dim inRES2APCA As Integer = stContenidoLinea.Substring(51, 4).ToString
                    Dim inRES2CUUT As Integer = stContenidoLinea.Substring(55, 4).ToString
                    Dim inRES2LOCA As Integer = stContenidoLinea.Substring(59, 4).ToString
                    Dim inRES2GACU As Integer = stContenidoLinea.Substring(63, 4).ToString
                    Dim inRES2GADE As Integer = stContenidoLinea.Substring(67, 4).ToString
                    Dim stRES2DIRE As String = stContenidoLinea.Substring(71, 49).ToString
                    Dim inRES2CAPR As Integer = stContenidoLinea.Substring(120, 1).ToString

                    ' variables indirectas
                    Dim stRES2DEPA As String = "05"
                    Dim stRES2ESTA As String = "ac"
                    Dim stRES2DESC As String = "."
                    Dim boRES2CONJ As Boolean = False
                    Dim boRES2LITI As Boolean = False
                    Dim boRES2INCO As Boolean = False
                    Dim stRES2POLI As String = "0.00"
                    Dim daRES2FECH As Date = fun_Hora_y_fecha()
                    Dim inRES2MOAD As Integer = 1
                    Dim inRES2TIFI As Integer = 2
                    Dim stRES2UNPR As String = "00000"
                    Dim inRES2ARTE As Integer = 0
                    Dim inRES2CASU As Integer = 3
                    Dim stRES2COPR As String = "0.000000"
                    Dim stRES2COED As String = "0.000000"
                    Dim stRES2MUAN As String = stRES2MUNI
                    Dim inRES2CSAN As Integer = inRES2CLSE
                    Dim stRES2COAN As String = stRES2CORR
                    Dim stRES2BAAN As String = stRES2BARR
                    Dim stRES2MAAN As String = stRES2MANZ
                    Dim stRES2PRAN As String = stRES2PRED
                    Dim stRES2EDAN As String = "000"
                    Dim stRES2UPAN As String = "00000"
                    Dim inRES2CASA As Integer = 3
                    Dim stRES2RUIM As String = "."
                    Dim inRES2APLO As Integer = inRES2ATLO - inRES2ACLO
                    Dim inRES2UNCO As Integer = 0
                    Dim inRES2TOED As Integer = 1

                    ' formato de campos
                    stRES2MUNI = CType(fun_Formato_Mascara_3_Reales(stRES2MUNI), String)
                    stRES2CORR = CType(fun_Formato_Mascara_2_Reales(stRES2CORR.Substring(1, 2).ToString), String)
                    stRES2BARR = CType(fun_Formato_Mascara_3_Reales(stRES2BARR), String)
                    stRES2MANZ = CType(fun_Formato_Mascara_3_Reales(stRES2MANZ), String)
                    stRES2PRED = CType(fun_Formato_Mascara_5_Reales(stRES2PRED), String)
                    stRES2EDIF = CType(fun_Formato_Mascara_3_Reales(stRES2EDIF.Substring(2, 3).ToString), String)
                    stRES2UNPR = CType(fun_Formato_Mascara_5_Reales(stRES2UNPR), String)
                    stRES2MUAN = CType(fun_Formato_Mascara_3_Reales(stRES2MUAN), String)
                    stRES2COAN = CType(fun_Formato_Mascara_2_Reales(stRES2COAN), String)
                    stRES2BAAN = CType(fun_Formato_Mascara_3_Reales(stRES2BAAN), String)
                    stRES2MAAN = CType(fun_Formato_Mascara_3_Reales(stRES2MAAN), String)
                    stRES2PRAN = CType(fun_Formato_Mascara_5_Reales(stRES2PRAN), String)
                    stRES2EDAN = CType(fun_Formato_Mascara_3_Reales(stRES2EDAN), String)
                    stRES2UPAN = CType(fun_Formato_Mascara_5_Reales(stRES2UPAN), String)

                    ' convierte en variable boleona
                    If inRES2CAPR = 3 Or inRES2CAPR = 4 Then
                        boRES2CONJ = True
                    Else
                        boRES2CONJ = False
                    End If

                    ' asignar el numero de ficha resumen
                    pro_AsignarNumeroDeFichaResumen()

                    ' asigna el nuemro de registro
                    pro_AsignarNumeroDeRegistroResolucionActualizacion()

                    ' obtiene la resolucion concatenada
                    pro_ObtenerResolucionCancatenada()

                    ' obtiene la cedula catastral concatenada
                    pro_ObtenerCedulaCatastralConcatenada(stRES2MUNI, stRES2CORR, stRES2BARR, stRES2MANZ, stRES2PRED, stRES2EDIF, stRES2UNPR, inRES2CLSE)

                    ' verifica que la ficha exista
                    Dim objdatos1 As New cla_FICHRESU
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_buscar_CEDULA_CATASTRAL_FICHRESU(stRES2MUNI, stRES2CORR, stRES2BARR, stRES2MANZ, stRES2PRED, stRES2EDIF, stRES2UNPR, inRES2CLSE, inRES2TIFI)

                    ' SI EXISTE LA FICHA SE ELIMINA PORQUE SI EL ARCHIVO TEXTO
                    ' TIENE MODIFICACIONES NO HAY NECESIDAD DE BORRAR EL MUNICIPIO 
                    ' Y SE PUEDE CARGAR PARCIALMENTE LAS MODIFCACIONES, EL BORRADO 
                    ' LO REALIZA LA BASE DE DATOS EN RELACION ELIMINAR EN CASCADA.

                    If tbl1.Rows.Count > 0 Then

                        ' instancia la funcion eliminar
                        Dim obj_FICHPRED As New cla_FICHRESU

                        obj_FICHPRED.fun_eliminar_POR_CEDULA_CATASTRAL_FICHRESU(stRES2MUNI, stRES2CORR, stRES2BARR, stRES2MANZ, stRES2PRED, stRES2EDIF, stRES2UNPR, inRES2CLSE, inRES2TIFI)

                    End If

                    ' instancia la funcion insertar
                    Dim obj_FICHRESU1 As New cla_FICHRESU

                    obj_FICHRESU1.fun_Insertar_FICHRESU(vl_inFIRENUFI, vl_inRESOVIGE, vl_inRESOTIRE, vl_inRESORESO, stRES2DIRE, stRES2DESC, boRES2CONJ, daRES2FECH, vl_inFIPRNURE, vl_stRESODEPA, stRES2MUNI, stRES2CORR, stRES2BARR, stRES2MANZ, stRES2PRED, stRES2EDIF, stRES2UNPR, inRES2CLSE, inRES2CASU, stRES2MUAN, stRES2COAN, stRES2BAAN, stRES2MAAN, stRES2PRAN, stRES2EDAN, stRES2UPAN, inRES2CSAN, inRES2CASA, inRES2CAPR, inRES2MOAD, stRES2ESTA, boRES2LITI, stRES2POLI, vl_stFIPRCORE, inRES2ARTE, stRES2COPR, stRES2COED, inRES2TIFI, boRES2INCO, stRES2RUIM, inRES2ATLO, inRES2ACLO, inRES2APLO, inRES2TOED, inRES2UNCO, inRES2URPH, inRES2APCA, inRES2LOCA, inRES2CUUT, inRES2GACU, inRES2GADE, inRES2PISO)

                End If

                '===============================
                '*** Insertar tabla FIPRCONS ***
                '===============================
                If stContenidoRegistro = "3" Then

                    ' variables indirectas
                    Dim stFPCOESTA As String = "ac"
                    Dim inFPCONURE As Integer = 0
                    Dim inFPCOSECU As Integer = 0
                    Dim boFPCOMEJO As Boolean = False
                    Dim boFPCOLEY As Boolean = False
                    Dim inFPCOCLCO As Integer = 1
                    Dim inFPCOAVCO As Integer = 0
                    Dim inFPCONUFI As Integer = 0
                    Dim stFPCOUNPR As String = "00000"
                    Dim inFPCOTIFI As Integer = 0
                    Dim stFPCOCECA As String = ""

                    ' variables directas
                    Dim inFPCOIDRE As Integer = stContenidoLinea.Substring(0, 1).ToString
                    Dim stFPCOMUNI As String = stContenidoLinea.Substring(1, 3).ToString
                    Dim inFPCOCLSE As Integer = stContenidoLinea.Substring(4, 1).ToString
                    Dim stFPCOCORR As String = stContenidoLinea.Substring(5, 3).ToString
                    Dim stFPCOBARR As String = stContenidoLinea.Substring(8, 3).ToString
                    Dim stFPCOMANZ As String = stContenidoLinea.Substring(11, 3).ToString
                    Dim stFPCOPRED As String = stContenidoLinea.Substring(14, 5).ToString
                    Dim stFPCOEDIF As String = stContenidoLinea.Substring(19, 5).ToString

                    If Trim(stFPCOEDIF) = "00000" Then
                        stFPCOEDIF = "00001"
                    End If

                    Dim inFPCOUNID As Integer = stContenidoLinea.Substring(24, 5).ToString
                    Dim stFPCOTIPO As String = stContenidoLinea.Substring(29, 1).ToString
                    Dim stFPCOTICO As String = stContenidoLinea.Substring(30, 3).ToString
                    Dim stFPCOARCO As String = stContenidoLinea.Substring(33, 8).ToString
                    Dim inFPCOPUNT As Integer = stContenidoLinea.Substring(41, 3).ToString
                    Dim inFPCOACUE As Integer = stContenidoLinea.Substring(44, 1).ToString
                    Dim inFPCOALCA As Integer = stContenidoLinea.Substring(45, 1).ToString
                    Dim inFPCOENER As Integer = stContenidoLinea.Substring(46, 1).ToString
                    Dim inFPCOTELE As Integer = stContenidoLinea.Substring(47, 1).ToString
                    Dim inFPCOGAS As Integer = stContenidoLinea.Substring(48, 1).ToString
                    Dim inFPCOPISO As Integer = stContenidoLinea.Substring(49, 2).ToString
                    Dim inFPCOPOCO As Integer = stContenidoLinea.Substring(51, 3).ToString
                    Dim inFPCOEDCO As Integer = stContenidoLinea.Substring(56, 4).ToString

                    ' campo porcentaje de litigio
                    Dim stFPCOARCO_1 As String = Val(stFPCOARCO.Substring(0, 6))
                    Dim stFPCOARCO_2 As String = "."
                    Dim stFPCOARCO_3 As String = stFPCOARCO.Substring(6, 2)
                    Dim stFPCOARCO_4 As String = stFPCOARCO_1 & stFPCOARCO_2 & stFPCOARCO_3

                    stFPCOARCO = CType(fun_Formato_Decimal_2_Decimales(stFPCOARCO_4), String)

                    ' coloca la clase 1
                    If stFPCOTICO < 500 AndAlso _
                           stFPCOTICO <> "020" AndAlso stFPCOTICO <> "037" AndAlso _
                           stFPCOTICO <> "019" AndAlso stFPCOTICO <> "028" AndAlso _
                           stFPCOTICO <> "032" AndAlso stFPCOTICO <> "072" AndAlso _
                           stFPCOTICO <> "074" AndAlso stFPCOTICO <> "075" AndAlso _
                           stFPCOTICO <> "076" AndAlso stFPCOTICO <> "077" AndAlso _
                           stFPCOTICO <> "078" AndAlso stFPCOTICO <> "073" Then

                        inFPCOCLCO = 1
                    End If

                    ' coloca la clase 2
                    If stFPCOTICO < 500 AndAlso _
                           stFPCOTICO = "020" Or stFPCOTICO = "037" Or _
                           stFPCOTICO = "019" Or stFPCOTICO = "028" Or _
                           stFPCOTICO = "032" Or stFPCOTICO = "072" Or _
                           stFPCOTICO = "074" Or stFPCOTICO = "075" Or _
                           stFPCOTICO = "076" Or stFPCOTICO = "077" Or _
                           stFPCOTICO = "078" Or stFPCOTICO = "073" Then

                        inFPCOCLCO = 2
                    End If

                    ' coloca la clase 3
                    If stFPCOTICO > 500 Then
                        inFPCOCLCO = 3
                    End If

                    ' formato de campos
                    stFPCOMUNI = CType(fun_Formato_Mascara_3_Reales(stFPCOMUNI), String)
                    stFPCOCORR = CType(fun_Formato_Mascara_2_Reales(stFPCOCORR), String)
                    stFPCOBARR = CType(fun_Formato_Mascara_3_Reales(stFPCOBARR), String)
                    stFPCOMANZ = CType(fun_Formato_Mascara_3_Reales(stFPCOMANZ), String)
                    stFPCOPRED = CType(fun_Formato_Mascara_5_Reales(stFPCOPRED), String)
                    stFPCOEDIF = CType(fun_Formato_Mascara_3_Reales(stFPCOEDIF), String)
                    stFPCOUNPR = CType(fun_Formato_Mascara_5_Reales(stFPCOUNPR), String)

                    stFPCOCECA = inFPCOCLSE & stFPCOMUNI & stFPCOCORR & stFPCOBARR & stFPCOMANZ & stFPCOPRED & stFPCOEDIF & stFPCOUNPR

                    ' verifica que la ficha exista
                    Dim objdatos51 As New cla_FICHRESU
                    Dim tbl51 As New DataTable

                    tbl51 = objdatos51.fun_Consultar_FICHA_RESUMEN_X_CEDULA_CONCATENADA(stFPCOCECA)

                    If tbl51.Rows.Count > 0 Then

                        ' almacena el numero de ficha 
                        inFPCONUFI = tbl51.Rows(0).Item(0)

                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPCONUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPCONURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' instancia la clase
                            Dim obj2_FIPRCONS As New cla_FIPRCONS
                            Dim tbl2 As New DataTable

                            ' consulta si ya existe el propietario
                            tbl2 = obj2_FIPRCONS.fun_Buscar_CODIGO_FIPRCONS(inFPCONUFI, inFPCOUNID)

                            ' cuenta los registros
                            If tbl2.Rows.Count = 0 Then

                                ' busca la secuencia de registro
                                inFPCOSECU = fun_BuscarNroSecuenciaConstruccion(inFPCONUFI)

                                ' instancia la clase 
                                Dim obj_FIPRCONS As New cla_FIPRCONS

                                ' inserta el registro
                                obj_FIPRCONS.fun_Insertar_FIPRCONS(inFPCONUFI, inFPCOUNID, inFPCOCLCO, stFPCOTICO, inFPCOPUNT, stFPCOARCO, inFPCOACUE, inFPCOALCA, inFPCOENER, inFPCOTELE, inFPCOGAS, inFPCOPISO, inFPCOEDCO, inFPCOPOCO, boFPCOMEJO, boFPCOLEY, inFPCOAVCO, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPCOSECU, inFPCONURE, stFPCOESTA)

                            Else
                                ' guarda la inconsistencia
                                vl_inFIPRNUFI = inFPCONUFI
                                vl_stFPINCODI = "3-CONSTRUCCION"
                                vl_stFPINDESC = "Nro. construcción " & inFPCOUNID & " existe en base de datos. " & inFPCONUFI
                                vl_stFIPRMUNI = stFPCOMUNI
                                vl_stFIPRCORR = stFPCOCORR
                                vl_stFIPRBARR = stFPCOBARR
                                vl_stFIPRMANZ = stFPCOMANZ
                                vl_stFIPRPRED = stFPCOPRED
                                vl_stFIPREDIF = stFPCOEDIF
                                vl_stFIPRUNPR = stFPCOUNPR

                                pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                            End If

                        Else

                            ' guarda la inconsistencia
                            vl_inFIPRNUFI = inFPCONUFI
                            vl_stFPINCODI = "3-CONSTRUCCION"
                            vl_stFPINDESC = "Ficha " & inFPCONUFI & " no existe en base de datos."
                            vl_stFIPRMUNI = stFPCOMUNI
                            vl_stFIPRCORR = stFPCOCORR
                            vl_stFIPRBARR = stFPCOBARR
                            vl_stFIPRMANZ = stFPCOMANZ
                            vl_stFIPRPRED = stFPCOPRED
                            vl_stFIPREDIF = stFPCOEDIF
                            vl_stFIPRUNPR = stFPCOUNPR

                            pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                        End If

                    Else
                        ' guarda la inconsistencia
                        vl_inFIPRNUFI = inFPCONUFI
                        vl_stFPINCODI = "1-FICHA RESUMEN"
                        vl_stFPINDESC = "Cedula " & stFPCOCECA & " no existe en base de datos."
                        vl_stFIPRMUNI = stFPCOMUNI
                        vl_stFIPRCORR = stFPCOCORR
                        vl_stFIPRBARR = stFPCOBARR
                        vl_stFIPRMANZ = stFPCOMANZ
                        vl_stFIPRPRED = stFPCOPRED
                        vl_stFIPREDIF = stFPCOEDIF
                        vl_stFIPRUNPR = stFPCOUNPR

                        pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                    End If

                End If

                '===============================
                '*** Insertar tabla FIPRCACO ***
                '===============================
                If stContenidoRegistro = "4" Then

                    ' variables indirectas
                    Dim stFPCCESTA As String = "ac"
                    Dim inFPCCNURE As Integer = 0
                    Dim inFPCCSECU As Integer = 0
                    Dim boFPCCMEJO As Boolean = False
                    Dim boFPCCLEY As Boolean = False
                    Dim inFPCCNUFI As Integer = 0
                    Dim stFPCCUNPR As String = "00000"
                    Dim inFPCCTIFI As Integer = 0
                    Dim stFPCCCECA As String = ""
                    Dim inFPCCCLCO As Integer = 1
                    Dim stFPCCTICO As String = ""

                    ' variables directas
                    Dim inFPCCIDRE As Integer = stContenidoLinea.Substring(0, 1).ToString
                    Dim stFPCCMUNI As String = stContenidoLinea.Substring(1, 3).ToString
                    Dim inFPCCCLSE As Integer = stContenidoLinea.Substring(4, 1).ToString
                    Dim stFPCCCORR As String = stContenidoLinea.Substring(5, 3).ToString
                    Dim stFPCCBARR As String = stContenidoLinea.Substring(8, 3).ToString
                    Dim stFPCCMANZ As String = stContenidoLinea.Substring(11, 3).ToString
                    Dim stFPCCPRED As String = stContenidoLinea.Substring(14, 5).ToString
                    Dim stFPCCEDIF As String = stContenidoLinea.Substring(19, 5).ToString

                    If Trim(stFPCCEDIF) = "00000" Then
                        stFPCCEDIF = "00001"
                    End If

                    Dim inFPCCUNID As Integer = stContenidoLinea.Substring(24, 5).ToString
                    Dim inFPCCCODI As Integer = stContenidoLinea.Substring(29, 3).ToString
                    Dim stFPCCTIPO As String = stContenidoLinea.Substring(32, 1).ToString
                    Dim inFPCCPUNT As Integer = stContenidoLinea.Substring(33, 3).ToString

                    ' formato de campos
                    stFPCCMUNI = CType(fun_Formato_Mascara_3_Reales(stFPCCMUNI), String)
                    stFPCCCORR = CType(fun_Formato_Mascara_2_Reales(stFPCCCORR), String)
                    stFPCCBARR = CType(fun_Formato_Mascara_3_Reales(stFPCCBARR), String)
                    stFPCCMANZ = CType(fun_Formato_Mascara_3_Reales(stFPCCMANZ), String)
                    stFPCCPRED = CType(fun_Formato_Mascara_5_Reales(stFPCCPRED), String)
                    stFPCCEDIF = CType(fun_Formato_Mascara_3_Reales(stFPCCEDIF), String)
                    stFPCCUNPR = CType(fun_Formato_Mascara_5_Reales(stFPCCUNPR), String)

                    stFPCCCECA = inFPCCCLSE & stFPCCMUNI & stFPCCCORR & stFPCCBARR & stFPCCMANZ & stFPCCPRED & stFPCCEDIF & stFPCCUNPR

                    ' verifica que la ficha exista
                    Dim objdatos51 As New cla_FICHRESU
                    Dim tbl51 As New DataTable

                    tbl51 = objdatos51.fun_Consultar_FICHA_RESUMEN_X_CEDULA_CONCATENADA(stFPCCCECA)

                    If tbl51.Rows.Count > 0 Then

                        ' almacena el numero de ficha 
                        inFPCCNUFI = tbl51.Rows(0).Item(0)

                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPCCNUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPCCNURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' instancia la clase
                            Dim obj2_FIPRCONS As New cla_FIPRCONS
                            Dim tbl2 As New DataTable

                            ' consulta si ya existe la construcción
                            tbl2 = obj2_FIPRCONS.fun_Buscar_CODIGO_FIPRCONS(inFPCCNUFI, inFPCCUNID)

                            ' cuenta los registros
                            If tbl2.Rows.Count > 0 Then

                                ' busca la secuencia de registro
                                inFPCCSECU = Val(tbl2.Rows(0).Item("FPCOSECU"))

                                ' busca la clase y el identificador
                                inFPCCCLCO = Val(tbl2.Rows(0).Item("FPCOCLCO"))
                                stFPCCTICO = tbl2.Rows(0).Item("FPCOTICO")

                                ' instancia la clase 
                                Dim obj_FIPRCACO As New cla_FIPRCACO
                                Dim tbl3 As New DataTable

                                ' verifica si el código de calificación existe
                                Dim tbl13 As New DataTable

                                tbl13 = obj_FIPRCACO.fun_Buscar_CODIGO_FIPRCACO(inFPCCNUFI, inFPCCCODI, inFPCCUNID)

                                If tbl13.Rows.Count = 0 Then

                                    ' instancia la clase 
                                    Dim obj_FIPRCACO1 As New cla_FIPRCACO

                                    ' inserta el registro
                                    obj_FIPRCACO1.fun_Insertar_FIPRCACO(inFPCCNUFI, inFPCCCODI, stFPCCTIPO, inFPCCPUNT, inFPCCUNID, inFPCCCLCO, stFPCCTICO, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPCCSECU, inFPCCNURE, stFPCCESTA)
                                Else
                                    ' guarda la inconsistencia
                                    vl_inFIPRNUFI = inFPCCNUFI
                                    vl_stFPINCODI = "4-CALIFICACION"
                                    vl_stFPINDESC = "Nro. código " & inFPCCCODI & " existe en base de datos unidad: " & inFPCCUNID & " Nro. ficha: " & inFPCCNUFI
                                    vl_stFIPRMUNI = vl_stRESOMUNI
                                    vl_stFIPRCORR = ""
                                    vl_stFIPRBARR = ""
                                    vl_stFIPRMANZ = ""
                                    vl_stFIPRPRED = ""
                                    vl_stFIPREDIF = ""
                                    vl_stFIPRUNPR = ""

                                    pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)
                                End If

                            Else
                                ' guarda la inconsistencia
                                vl_inFIPRNUFI = inFPCCNUFI
                                vl_stFPINCODI = "4-CALIFICACION"
                                vl_stFPINDESC = "Nro. construcción " & inFPCCUNID & " existe en base de datos. " & inFPCCNUFI
                                vl_stFIPRMUNI = vl_stRESOMUNI
                                vl_stFIPRCORR = ""
                                vl_stFIPRBARR = ""
                                vl_stFIPRMANZ = ""
                                vl_stFIPRPRED = ""
                                vl_stFIPREDIF = ""
                                vl_stFIPRUNPR = ""

                                pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                            End If

                        Else

                            ' guarda la inconsistencia
                            vl_inFIPRNUFI = inFPCCNUFI
                            vl_stFPINCODI = "4-CALIFICACION"
                            vl_stFPINDESC = "Ficha " & inFPCCNUFI & " no existe en base de datos."
                            vl_stFIPRMUNI = vl_stRESOMUNI
                            vl_stFIPRCORR = ""
                            vl_stFIPRBARR = ""
                            vl_stFIPRMANZ = ""
                            vl_stFIPRPRED = ""
                            vl_stFIPREDIF = ""
                            vl_stFIPRUNPR = ""

                            pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                        End If

                    Else
                        ' guarda la inconsistencia
                        vl_inFIPRNUFI = inFPCCNUFI
                        vl_stFPINCODI = "1-FICHA RESUMEN"
                        vl_stFPINDESC = "Cedula " & stFPCCCECA & " no existe en base de datos."
                        vl_stFIPRMUNI = vl_stRESOMUNI
                        vl_stFIPRCORR = ""
                        vl_stFIPRBARR = ""
                        vl_stFIPRMANZ = ""
                        vl_stFIPRPRED = ""
                        vl_stFIPREDIF = ""
                        vl_stFIPRUNPR = ""

                        pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)
                    End If

                End If

                '===============================
                '*** Insertar tabla FIPRCART ***
                '===============================
                If stContenidoRegistro = "5" Then

                    ' variables indirectas
                    Dim stFPCAESTA As String = "ac"
                    Dim inFPCANURE As Integer = 0
                    Dim inFPCASECU As Integer = 0
                    Dim stFPCAUNPR As String = "00000"
                    Dim stFPCACECA As String = ""
                    Dim inFPCANUFI As Integer = 0

                    ' variables directas
                    Dim inFPCAIDRE As Integer = stContenidoLinea.Substring(0, 1).ToString
                    Dim stFPCAMUNI As String = stContenidoLinea.Substring(1, 3).ToString
                    Dim inFPCACLSE As Integer = stContenidoLinea.Substring(4, 1).ToString
                    Dim stFPCACORR As String = stContenidoLinea.Substring(5, 3).ToString
                    Dim stFPCABARR As String = stContenidoLinea.Substring(8, 3).ToString
                    Dim stFPCAMANZ As String = stContenidoLinea.Substring(11, 3).ToString
                    Dim stFPCAPRED As String = stContenidoLinea.Substring(14, 5).ToString
                    Dim stFPCAEDIF As String = stContenidoLinea.Substring(19, 5).ToString

                    If Trim(stFPCAEDIF) = "00000" Then
                        stFPCAEDIF = "00001"
                    End If

                    Dim stFPCAPLAN As String = stContenidoLinea.Substring(24, 15).ToString
                    Dim stFPCAVENT As String = stContenidoLinea.Substring(39, 15).ToString
                    Dim stFPCAESGR As String = stContenidoLinea.Substring(54, 15).ToString
                    Dim inFPCAVIGR As Integer = stContenidoLinea.Substring(69, 4).ToString
                    Dim stFPCAVUEL As String = stContenidoLinea.Substring(73, 15).ToString
                    Dim stFPCAFAJA As String = stContenidoLinea.Substring(88, 15).ToString
                    Dim stFPCAFOTO As String = stContenidoLinea.Substring(103, 15).ToString
                    Dim inFPCAVIAE As Integer = stContenidoLinea.Substring(118, 4).ToString
                    Dim stFPCAAMPL As String = stContenidoLinea.Substring(122, 15).ToString
                    Dim stFPCAESAE As String = stContenidoLinea.Substring(137, inNroDeCaracteresCartografia).ToString

                    ' formato de campos
                    stFPCAMUNI = CType(fun_Formato_Mascara_3_Reales(stFPCAMUNI), String)
                    stFPCACORR = CType(fun_Formato_Mascara_2_Reales(stFPCACORR), String)
                    stFPCABARR = CType(fun_Formato_Mascara_3_Reales(stFPCABARR), String)
                    stFPCAMANZ = CType(fun_Formato_Mascara_3_Reales(stFPCAMANZ), String)
                    stFPCAPRED = CType(fun_Formato_Mascara_5_Reales(stFPCAPRED), String)
                    stFPCAEDIF = CType(fun_Formato_Mascara_3_Reales(stFPCAEDIF), String)
                    stFPCAUNPR = CType(fun_Formato_Mascara_5_Reales(stFPCAUNPR), String)

                    stFPCACECA = inFPCACLSE & stFPCAMUNI & stFPCACORR & stFPCABARR & stFPCAMANZ & stFPCAPRED & stFPCAEDIF & stFPCAUNPR

                    ' verifica que la ficha exista
                    Dim objdatos51 As New cla_FICHRESU
                    Dim tbl51 As New DataTable

                    tbl51 = objdatos51.fun_Consultar_FICHA_RESUMEN_X_CEDULA_CONCATENADA(stFPCACECA)

                    If tbl51.Rows.Count > 0 Then

                        ' almacena el numero de ficha 
                        inFPCANUFI = tbl51.Rows(0).Item(0)

                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPCANUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPCANURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' busca la secuencia de registro
                            inFPCASECU = fun_BuscarNroSecuenciaCartografia(inFPCANUFI)

                            ' instancia la clase 
                            Dim obj_FIPRCART As New cla_FIPRCART

                            ' inserta el registro
                            obj_FIPRCART.fun_Insertar_FIPRCART(inFPCANUFI, stFPCAPLAN, stFPCAVENT, stFPCAESGR, inFPCAVIGR, stFPCAVUEL, stFPCAFAJA, stFPCAFOTO, inFPCAVIAE, stFPCAAMPL, stFPCAESAE, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPCASECU, inFPCANURE, stFPCAESTA)

                        Else

                            ' guarda la inconsistencia
                            vl_inFIPRNUFI = inFPCANUFI
                            vl_stFPINCODI = "5-CARTOGRAFIA"
                            vl_stFPINDESC = "Ficha " & inFPCANUFI & " no existe en base de datos."
                            vl_stFIPRMUNI = vl_stRESOMUNI
                            vl_stFIPRCORR = ""
                            vl_stFIPRBARR = ""
                            vl_stFIPRMANZ = ""
                            vl_stFIPRPRED = ""
                            vl_stFIPREDIF = ""
                            vl_stFIPRUNPR = ""

                            pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                        End If

                    Else
                        ' guarda la inconsistencia
                        vl_inFIPRNUFI = inFPCANUFI
                        vl_stFPINCODI = "1-FICHA RESUMEN"
                        vl_stFPINDESC = "Cedula " & stFPCACECA & " no existe en base de datos."
                        vl_stFIPRMUNI = vl_stRESOMUNI
                        vl_stFIPRCORR = ""
                        vl_stFIPRBARR = ""
                        vl_stFIPRMANZ = ""
                        vl_stFIPRPRED = ""
                        vl_stFIPREDIF = ""
                        vl_stFIPRUNPR = ""

                        pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)
                    End If

                End If

                '===============================
                '*** Insertar tabla FIPRLIND ***
                '===============================
                If stContenidoRegistro = "6" Then

                    ' variables indirectas
                    Dim stFPLIESTA As String = "ac"
                    Dim inFPLINURE As Integer = 0
                    Dim inFPLISECU As Integer = 0
                    Dim stFPLIUNPR As String = "00000"
                    Dim stFPLICECA As String = ""
                    Dim inFPLINUFI As Integer = 0

                    ' variables directas
                    Dim inFPLIIDRE As Integer = stContenidoLinea.Substring(0, 1).ToString
                    Dim stFPLIMUNI As String = stContenidoLinea.Substring(1, 3).ToString
                    Dim inFPLICLSE As Integer = stContenidoLinea.Substring(4, 1).ToString
                    Dim stFPLICORR As String = stContenidoLinea.Substring(5, 3).ToString
                    Dim stFPLIBARR As String = stContenidoLinea.Substring(8, 3).ToString
                    Dim stFPLIMANZ As String = stContenidoLinea.Substring(11, 3).ToString
                    Dim stFPLIPRED As String = stContenidoLinea.Substring(14, 5).ToString
                    Dim stFPLIEDIF As String = stContenidoLinea.Substring(19, 5).ToString

                    If Trim(stFPLIEDIF) = "00000" Then
                        stFPLIEDIF = "00001"
                    End If

                    Dim stFPLIPUCA As String = stContenidoLinea.Substring(24, 2).ToString
                    Dim stFPLICOLI As String = Trim(stContenidoLinea.Substring(26, inNroDeCaracteresLindero).ToString)

                    ' formato de campos
                    stFPLIMUNI = CType(fun_Formato_Mascara_3_Reales(stFPLIMUNI), String)
                    stFPLICORR = CType(fun_Formato_Mascara_2_Reales(stFPLICORR), String)
                    stFPLIBARR = CType(fun_Formato_Mascara_3_Reales(stFPLIBARR), String)
                    stFPLIMANZ = CType(fun_Formato_Mascara_3_Reales(stFPLIMANZ), String)
                    stFPLIPRED = CType(fun_Formato_Mascara_5_Reales(stFPLIPRED), String)
                    stFPLIEDIF = CType(fun_Formato_Mascara_3_Reales(stFPLIEDIF), String)
                    stFPLIUNPR = CType(fun_Formato_Mascara_5_Reales(stFPLIUNPR), String)

                    stFPLICECA = inFPLICLSE & stFPLIMUNI & stFPLICORR & stFPLIBARR & stFPLIMANZ & stFPLIPRED & stFPLIEDIF & stFPLIUNPR

                    ' verifica que la ficha exista
                    Dim objdatos51 As New cla_FICHRESU
                    Dim tbl51 As New DataTable

                    tbl51 = objdatos51.fun_Consultar_FICHA_RESUMEN_X_CEDULA_CONCATENADA(stFPLICECA)

                    If tbl51.Rows.Count > 0 Then

                        ' almacena el numero de ficha 
                        inFPLINUFI = tbl51.Rows(0).Item(0)

                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPLINUFI)
                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPLINURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' busca la secuencia de registro
                            inFPLISECU = fun_BuscarNroSecuenciaLindero(inFPLINUFI)

                            ' instancia la clase 
                            Dim obj_FIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            obj_FIPRLIND.fun_Insertar_FIPRLIND(inFPLINUFI, stFPLIPUCA, stFPLICOLI, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPLISECU, inFPLINURE, stFPLIESTA)

                        Else

                            ' guarda la inconsistencia
                            vl_inFIPRNUFI = inFPLINUFI
                            vl_stFPINCODI = "6-LINDEROS"
                            vl_stFPINDESC = "Ficha " & inFPLINUFI & " no existe en base de datos."
                            vl_stFIPRMUNI = vl_stRESOMUNI
                            vl_stFIPRCORR = ""
                            vl_stFIPRBARR = ""
                            vl_stFIPRMANZ = ""
                            vl_stFIPRPRED = ""
                            vl_stFIPREDIF = ""
                            vl_stFIPRUNPR = ""

                            pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                        End If
                    Else
                        ' guarda la inconsistencia
                        vl_inFIPRNUFI = inFPLINUFI
                        vl_stFPINCODI = "1-FICHA RESUMEN"
                        vl_stFPINDESC = "Cedula " & stFPLICECA & " no existe en base de datos."
                        vl_stFIPRMUNI = vl_stRESOMUNI
                        vl_stFIPRCORR = ""
                        vl_stFIPRBARR = ""
                        vl_stFIPRMANZ = ""
                        vl_stFIPRPRED = ""
                        vl_stFIPREDIF = ""
                        vl_stFIPRUNPR = ""

                        pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)
                    End If

                End If

                ' Incrementa la barra
                inProceso = inProceso + 1
                pbProcesoResolucionActualizacion.Value = inProceso

            Loop

            ' consulta las inconsistencas de las fichas validadas
            Dim objdatos As New cla_VALIFIPR
            Dim tbl As New DataTable

            tbl = objdatos.fun_Consultar_INCONSISTENCIA_X_RESOLUCION(stRESOLUCION)

            ' Crea objeto de columnas y registros
            Dim dt1 As New DataTable
            Dim dr1 As DataRow

            ' Crea las columnas
            dt1.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
            dt1.Columns.Add(New DataColumn("Cedula catastral", GetType(String)))
            dt1.Columns.Add(New DataColumn("Codigo incons.", GetType(String)))
            dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))

            Dim i As Integer

            For i = 0 To tbl.Rows.Count - 1

                dr1 = dt1.NewRow()
                dr1("Nro_Ficha") = tbl.Rows(i).Item("FPINNUFI")
                dr1("Cedula catastral") = tbl.Rows(i).Item("FPINMUNI") & "-" & _
                                         tbl.Rows(i).Item("FPINCORR") & "-" & _
                                         tbl.Rows(i).Item("FPINBARR") & "-" & _
                                         tbl.Rows(i).Item("FPINMANZ") & "-" & _
                                         tbl.Rows(i).Item("FPINPRED") & "-" & _
                                         tbl.Rows(i).Item("FPINEDIF") & "-" & _
                                         tbl.Rows(i).Item("FPINUNPR")
                dr1("Codigo incons.") = tbl.Rows(i).Item("FPINCODI")
                dr1("Descripcion") = tbl.Rows(i).Item("FPINDESC")
                dt1.Rows.Add(dr1)

            Next

            ' Llena el datagrigview
            TabControl1.SelectTab(TabPage2)
            Me.dgvFIREINCO.DataSource = dt1
            pbProcesoResolucionActualizacion.Value = 0

            ' comando grabar datos
            If dt1.Rows.Count = 0 Then
                MessageBox.Show("Proceso de guardado terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("Proceso de guardado con inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

            Me.cmdGrabarDatosResolucionActualizacion.Enabled = False
            Me.lblFecha2ResolucionActualizacion.Visible = False
            Me.cmdValidaDatosResolucionActualizacion.Enabled = False

            Me.cmdAbrirArchivoResolucionActualizacion.Focus()

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRINCO.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description & " Registro: " & a)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub pro_GuardarDatosFichaPredialResolucionAdministrativa()

        Try
            ' apaga el boton grabar datos
            Me.cmdGrabarDatosResolucionAdministrativa.Enabled = False

            ' eliminar la base de datos existente de acuerdo al archivo plano
            If Me.chkSobrescribirBDexistenteResolucionAdministrativa.Checked = True And Me.rbdFichaPredialResolucionAdministrativa.Checked = True Then

                ' elimina ficha predial
                If Trim(Me.txtREADMUNI.Text) <> "" And _
                   Trim(Me.txtREADCLSE.Text) <> "" Then

                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtREADMUNI.Text)) = True And _
                       fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtREADCLSE.Text)) = True Then

                        Dim objFichaPredial11 As New cla_FICHPRED

                        objFichaPredial11.fun_Eliminar_DB_FICHA_PREDIAL(Trim(Me.txtREADMUNI.Text), Trim(Me.txtREADCLSE.Text))

                    End If

                End If

            End If

            ' inactiva las fichas prediales
            If Me.chkInactivasFichasResolucionAdministrativa.Checked = True Then
                pro_InactivarPredios()
            End If

            ' almacena la resolucion para la consulta de inconsistencias
            stRESOLUCION = Me.txtREADMUNI.Text & Me.txtREADVIGE.Text & Me.txtREADTIRE.Text & Me.txtREADRESO.Text & Me.txtREADCLSE.Text

            ' instancia la clase
            Dim objdatos11 As New cla_VALIFIPR
            'Dim tbl11 As New DataTable

            ' elimina las inconsistencias
            objdatos11.fun_Eliminar_FIPRINCO_X_RESOLUCION(Trim(stRESOLUCION))

            ' abre el archivo
            FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

            ' almacena la linea
            Dim stContenidoLinea As String = ""
            Dim stContenidoRegistro As String = ""
            Dim inNroDeCaracteresLindero As Integer = 0
            Dim inNroDeCaracteresCartografia As Integer = 0
            Dim stNroDeFichaPredial As String = ""
            Dim inNroDeRegistroDelPlano As Integer = 0

            ' Valores predeterminados ProgressBar
            inProceso = 0
            pbProcesoResolucionAdministrativa.Value = 0
            pbProcesoResolucionAdministrativa.Maximum = inTotalRegistros + 1
            Timer1.Enabled = True

            ' recorre el archivo plano y repita hasta que se acabe las lineas
            Do Until EOF(1)

                ' numero de registro del plano utilizado en codigos asignados
                inNroDeRegistroDelPlano += 1

                a = inNroDeRegistroDelPlano

                ' extrae la linea
                stContenidoLinea = LineInput(1)

                ' verifica cual es el registro de la tabla
                stContenidoRegistro = stContenidoLinea.Substring(0, 1).ToString

                '==============================
                '*** Inserta tabla FICHPRED ***
                '==============================
                If stContenidoRegistro = "1" Then

                    ' variables indirectas
                    Dim stFIPRDESC As String = "."
                    Dim boFIPRCONJ As Boolean = False
                    Dim boFIPRLITI As Boolean = False
                    Dim boFIPRINCO As Boolean = False
                    Dim daFIPRFECH As Date = fun_Hora_y_fecha()
                    Dim stFIPRESTA As String = "ac"
                    Dim stFIPRPOLI As String = "0.00"
                    Dim stFIPRMOAD As Integer = 1
                    Dim stFIPRTIFI As Integer = 0
                    Dim inFIPRNURE As Integer = 1
                    Dim loFIPRARTE As Long = 0
                    Dim inFIPRCAPR As Integer = 0
                    Dim inFIPRCASU As Integer = 3
                    Dim inFIPRCASA As Integer = 3
                    Dim stFIPRCOPR As String = "0.000000"
                    Dim stFIPRCOED As String = "0.000000"

                    ' variables directas
                    Dim inFIPRNUFI As Integer = stContenidoLinea.Substring(16, 9).ToString
                    Dim stFIPRMUNI As String = stContenidoLinea.Substring(26, 3).ToString
                    Dim inFIPRCLSE As Integer = stContenidoLinea.Substring(30, 1).ToString
                    Dim stFIPRCORR As String = stContenidoLinea.Substring(33, 2).ToString
                    Dim stFIPRBARR As String = stContenidoLinea.Substring(36, 3).ToString
                    Dim stFIPRMANZ As String = stContenidoLinea.Substring(41, 3).ToString
                    Dim stFIPRPRED As String = stContenidoLinea.Substring(45, 5).ToString
                    Dim stFIPREDIF As String = stContenidoLinea.Substring(52, 3).ToString
                    Dim stFIPRUNPR As String = stContenidoLinea.Substring(56, 5).ToString
                    Dim stFIPRDIRE As String = stContenidoLinea.Substring(112, 49).ToString
                    Dim stFIPRMUAN As String = stContenidoLinea.Substring(26, 3).ToString
                    Dim inFIPRCSAN As Integer = stContenidoLinea.Substring(30, 1).ToString
                    Dim stFIPRCOAN As String = stContenidoLinea.Substring(33, 2).ToString
                    Dim stFIPRBAAN As String = stContenidoLinea.Substring(36, 3).ToString
                    Dim stFIPRMAAN As String = stContenidoLinea.Substring(41, 3).ToString
                    Dim stFIPRPRAN As String = stContenidoLinea.Substring(45, 5).ToString
                    Dim stFIPREDAN As String = stContenidoLinea.Substring(52, 3).ToString
                    Dim stFIPRUPAN As String = stContenidoLinea.Substring(56, 5).ToString

                    ' caracteristica de predio
                    If CInt(inFIPRCLSE) = 1 Then
                        If CStr(Trim(stFIPREDIF)) = "000" Then
                            inFIPRCAPR = 1
                        ElseIf CStr(Trim(stFIPREDIF)) = "001" Then
                            inFIPRCAPR = 2
                        End If
                    ElseIf CInt(inFIPRCLSE) = 2 Then
                        If CStr(Trim(stFIPREDIF)) = "000" Then
                            inFIPRCAPR = 1
                        ElseIf CStr(Trim(stFIPREDIF)) = "001" Then
                            inFIPRCAPR = 3
                        End If
                    End If

                    ' formato de campos
                    stFIPRMUNI = CType(fun_Formato_Mascara_3_Reales(stFIPRMUNI), String)
                    stFIPRCORR = CType(fun_Formato_Mascara_2_Reales(stFIPRCORR), String)
                    stFIPRBARR = CType(fun_Formato_Mascara_3_Reales(stFIPRBARR), String)
                    stFIPRMANZ = CType(fun_Formato_Mascara_3_Reales(stFIPRMANZ), String)
                    stFIPRPRED = CType(fun_Formato_Mascara_5_Reales(stFIPRPRED), String)
                    stFIPREDIF = CType(fun_Formato_Mascara_3_Reales(stFIPREDIF), String)
                    stFIPRUNPR = CType(fun_Formato_Mascara_5_Reales(stFIPRUNPR), String)
                    stFIPRMUAN = CType(fun_Formato_Mascara_3_Reales(stFIPRMUAN), String)
                    stFIPRCOAN = CType(fun_Formato_Mascara_2_Reales(stFIPRCOAN), String)
                    stFIPRBAAN = CType(fun_Formato_Mascara_3_Reales(stFIPRBAAN), String)
                    stFIPRMAAN = CType(fun_Formato_Mascara_3_Reales(stFIPRMAAN), String)
                    stFIPRPRAN = CType(fun_Formato_Mascara_5_Reales(stFIPRPRAN), String)
                    stFIPREDAN = CType(fun_Formato_Mascara_3_Reales(stFIPREDAN), String)
                    stFIPRUPAN = CType(fun_Formato_Mascara_5_Reales(stFIPRUPAN), String)

                    ' asigna el nuemro de registro
                    pro_AsignarNumeroDeRegistroResolucionAdministrativa()

                    ' obtiene la resolucion concatenada
                    pro_ObtenerResolucionCancatenada()

                    ' obtiene la cedula catastral concatenada
                    pro_ObtenerCedulaCatastralConcatenada(stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPREDIF, stFIPRUNPR, inFIPRCLSE)

                    ' declaro la variable
                    Dim boRangoFichaMuncipio As Boolean = False
                    Dim boRangoFichaNueva As Boolean = False
                    Dim boRangoFichaOVC As Boolean = False

                    Dim boRangoFichaInconsistente As Boolean = True

                    ' valida el rango de ficha nueva
                    Dim stFIPRNUFI As String = stContenidoLinea.Substring(16, 9).ToString

                    If stFIPRNUFI.ToString.Substring(0, 3) = Trim(stFIPRMUNI) And stFIPRNUFI.ToString.Substring(3, 1) = inFIPRCLSE Then
                        boRangoFichaNueva = True
                    Else
                        boRangoFichaNueva = False
                    End If

                    ' valida el rango de ficha municipio
                    Dim inFIPRRAIN As Integer = vl_inMUNIRAIN
                    Dim inFIPRRAFI As Integer = vl_inMUNIRAFI

                    If Val(inFIPRNUFI) < inFIPRRAIN Or Val(inFIPRNUFI) > inFIPRRAFI Then
                        boRangoFichaMuncipio = False
                    Else
                        boRangoFichaMuncipio = True
                    End If

                    ' valida el rango de ficha OVC
                    If Me.chkFichasOVCResolucionAdministrativa.Checked = True Then
                        boRangoFichaOVC = True
                    Else
                        boRangoFichaOVC = False
                    End If

                    ' valida el rango de ficha
                    If boRangoFichaMuncipio = True Then
                        boRangoFichaInconsistente = False

                    Else
                        If boRangoFichaMuncipio = False And boRangoFichaNueva = True Then
                            boRangoFichaInconsistente = False

                        Else
                            If boRangoFichaMuncipio = False And boRangoFichaNueva = False And boRangoFichaOVC = True Then
                                boRangoFichaInconsistente = False

                            End If

                        End If

                    End If

                    If boRangoFichaInconsistente = True Then

                        ' guarda la inconsistencia
                        vl_inFIPRNUFI = inFIPRNUFI
                        vl_stFPINCODI = "1-FICHA PREDIAL"
                        vl_stFPINDESC = "Nro ficha predial " & inFIPRNUFI & " con rango incorrecto para el municipio. "
                        vl_stFIPRMUNI = vl_stRESOMUNI
                        vl_stFIPRCORR = stFIPRCORR
                        vl_stFIPRBARR = stFIPRBARR
                        vl_stFIPRMANZ = stFIPRMANZ
                        vl_stFIPRPRED = stFIPRPRED
                        vl_stFIPREDIF = stFIPREDIF
                        vl_stFIPRUNPR = stFIPRUNPR

                        pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                    Else

                        ' si elimina los registros
                        If Me.chkSobrescribirBDexistenteResolucionAdministrativa.Checked = True Then

                            ' verifica que la ficha exista
                            Dim objdatos1 As New cla_FICHPRED
                            Dim tbl1 As New DataTable

                            tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFIPRNUFI)

                            If tbl1.Rows.Count = 0 Then

                                ' instancia la funcion eliminar
                                Dim obj_FICHPRED As New cla_FICHPRED
                                obj_FICHPRED.fun_Eliminar_FICHPRED(inFIPRNUFI)

                                Dim obj_FICHPRED1 As New cla_FICHPRED
                                obj_FICHPRED1.fun_Insertar_FICHPRED(inFIPRNUFI, vl_inRESOVIGE, vl_inRESOTIRE, vl_inRESORESO, stFIPRDIRE, stFIPRDESC, boFIPRCONJ, daFIPRFECH, vl_inFIPRNURE, vl_stRESODEPA, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPREDIF, stFIPRUNPR, inFIPRCLSE, inFIPRCASU, stFIPRMUAN, stFIPRCOAN, stFIPRBAAN, stFIPRMAAN, stFIPRPRAN, stFIPREDAN, stFIPRUPAN, inFIPRCSAN, inFIPRCASA, inFIPRCAPR, stFIPRMOAD, stFIPRESTA, boFIPRLITI, stFIPRPOLI, vl_stFIPRCORE, loFIPRARTE, stFIPRCOPR, stFIPRCOED, stFIPRTIFI, boFIPRINCO)

                            End If

                            ' inserta solo los predios nuevos 
                        ElseIf Me.rbdInsertaPrediosNuevosResolucionAdministrativa.Checked = True Then

                            ' verifica que la ficha exista
                            Dim objdatos1 As New cla_FICHPRED
                            Dim tbl1 As New DataTable

                            tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFIPRNUFI)

                            If tbl1.Rows.Count = 0 Then

                                ' instancia la funcion insertar
                                Dim obj_FICHPRED1 As New cla_FICHPRED
                                obj_FICHPRED1.fun_Insertar_FICHPRED(inFIPRNUFI, vl_inRESOVIGE, vl_inRESOTIRE, vl_inRESORESO, stFIPRDIRE, stFIPRDESC, boFIPRCONJ, daFIPRFECH, vl_inFIPRNURE, vl_stRESODEPA, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPREDIF, stFIPRUNPR, inFIPRCLSE, inFIPRCASU, stFIPRMUAN, stFIPRCOAN, stFIPRBAAN, stFIPRMAAN, stFIPRPRAN, stFIPREDAN, stFIPRUPAN, inFIPRCSAN, inFIPRCASA, inFIPRCAPR, stFIPRMOAD, stFIPRESTA, boFIPRLITI, stFIPRPOLI, vl_stFIPRCORE, loFIPRARTE, stFIPRCOPR, stFIPRCOED, stFIPRTIFI, boFIPRINCO)

                                boPredioNuevo = True
                            Else
                                boPredioNuevo = False

                            End If

                            ' actualiza e inserta los predios
                        ElseIf Me.rbdActualizarInsertarPrediosResolucionAdministrativa.Checked = True Then

                            ' verifica que la ficha exista
                            Dim objdatos1 As New cla_FICHPRED
                            Dim tbl1 As New DataTable

                            tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFIPRNUFI)

                            If tbl1.Rows.Count = 0 Then

                                ' instancia la funcion insertar
                                Dim obj_FICHPRED1 As New cla_FICHPRED
                                obj_FICHPRED1.fun_Insertar_FICHPRED(inFIPRNUFI, vl_inRESOVIGE, vl_inRESOTIRE, vl_inRESORESO, stFIPRDIRE, stFIPRDESC, boFIPRCONJ, daFIPRFECH, vl_inFIPRNURE, vl_stRESODEPA, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPREDIF, stFIPRUNPR, inFIPRCLSE, inFIPRCASU, stFIPRMUAN, stFIPRCOAN, stFIPRBAAN, stFIPRMAAN, stFIPRPRAN, stFIPREDAN, stFIPRUPAN, inFIPRCSAN, inFIPRCASA, inFIPRCAPR, stFIPRMOAD, stFIPRESTA, boFIPRLITI, stFIPRPOLI, vl_stFIPRCORE, loFIPRARTE, stFIPRCOPR, stFIPRCOED, stFIPRTIFI, boFIPRINCO)

                                boPredioNuevo = True
                            Else
                                ' instancia la funcion modificar
                                Dim obj_FICHPRED1 As New cla_FICHPRED
                                If obj_FICHPRED1.fun_Actualizar_X_NUFI_FICHPRED(inFIPRNUFI, vl_inRESOVIGE, vl_inRESOTIRE, vl_inRESORESO, stFIPRDIRE, stFIPRDESC, boFIPRCONJ, daFIPRFECH, vl_inFIPRNURE, vl_stRESODEPA, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPREDIF, stFIPRUNPR, inFIPRCLSE, inFIPRCASU, stFIPRMUAN, stFIPRCOAN, stFIPRBAAN, stFIPRMAAN, stFIPRPRAN, stFIPREDAN, stFIPRUPAN, inFIPRCSAN, inFIPRCASA, inFIPRCAPR, stFIPRMOAD, stFIPRESTA, boFIPRLITI, stFIPRPOLI, loFIPRARTE, stFIPRCOPR, stFIPRCOED, stFIPRTIFI) = True Then

                                End If

                                ' borrar todas las tablas
                                If Me.chkDestinoEconomicoResolucionAdministrativa.Checked = True Then
                                    Dim obj_FIPRDEEC1 As New cla_FIPRDEEC
                                    obj_FIPRDEEC1.fun_Eliminar_NUFI_FIPRDEEC(inFIPRNUFI)
                                End If

                                If Me.chkPropietarioResolucionAdministrativa.Checked = True Then
                                    Dim obj_FIPRPROP1 As New cla_FIPRPROP
                                    obj_FIPRPROP1.fun_Eliminar_NUFI_FIPRPROP(inFIPRNUFI)
                                End If

                                If Me.chkConstruccionResolucionAdministrativa.Checked = True Then
                                    Dim obj_FIPRCONS1 As New cla_FIPRCONS
                                    obj_FIPRCONS1.fun_Eliminar_NUFI_FIPRCONS(inFIPRNUFI)
                                End If

                                boPredioNuevo = False

                            End If

                        End If
                    End If

                End If

                '==============================
                '*** Inserta tabla FIPRDEEC ***
                '==============================
                If stContenidoRegistro = "1" Then

                    ' variables indirectas
                    Dim stFPDEESTA As String = "ac"
                    Dim inFPDENURE As Integer = 0
                    Dim inFPDESECU As Integer = 0
                    Dim inFPDEPORC As Integer = "100"

                    ' variables directas
                    Dim inFPDENUFI As Integer = stContenidoLinea.Substring(16, 9).ToString
                    Dim inFPDEDEEC As Integer = stContenidoLinea.Substring(108, 3).ToString

                    ' inserta solo predios nuevos
                    If boPredioNuevo = True And Me.rbdInsertaPrediosNuevosResolucionAdministrativa.Checked = True Then

                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPDENUFI)

                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPDENURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' busca la secuencia de registro
                            inFPDESECU = fun_BuscarNroSecuenciaDestinacionEconomica(inFPDENUFI)

                            Dim obj_FIPRDEEC As New cla_FIPRDEEC

                            ' inserta el registro
                            obj_FIPRDEEC.fun_Insertar_FIPRDEEC(inFPDENUFI, inFPDEDEEC, inFPDEPORC, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPDESECU, inFPDENURE, stFPDEESTA)

                        End If

                    Else
                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPDENUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPDENURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' instancia la clase
                            Dim obj2_FIPRDEEC As New cla_FIPRDEEC
                            Dim tbl2 As New DataTable

                            ' consulta la llave primaria
                            tbl2 = obj2_FIPRDEEC.fun_Buscar_CODIGO_FIPRDEEC(inFPDENUFI, inFPDEDEEC)

                            ' cuenta los registros
                            If tbl2.Rows.Count = 0 Then

                                ' busca la secuencia de registro
                                inFPDESECU = fun_BuscarNroSecuenciaDestinacionEconomica(inFPDENUFI)

                                Dim obj_FIPRDEEC As New cla_FIPRDEEC

                                If Me.rbdActualizarInsertarPrediosResolucionAdministrativa.Checked = True And Me.chkDestinoEconomicoResolucionAdministrativa.Checked = True And boPredioNuevo = False Then
                                    ' instancia la clase 
                                    obj_FIPRDEEC.fun_Insertar_FIPRDEEC(inFPDENUFI, inFPDEDEEC, inFPDEPORC, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPDESECU, inFPDENURE, stFPDEESTA)

                                ElseIf Me.chkSobrescribirBDexistenteResolucionAdministrativa.Checked = True Or boPredioNuevo = True Then
                                    ' inserta el registro
                                    obj_FIPRDEEC.fun_Insertar_FIPRDEEC(inFPDENUFI, inFPDEDEEC, inFPDEPORC, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPDESECU, inFPDENURE, stFPDEESTA)

                                End If

                            ElseIf Me.chkSobrescribirBDexistenteResolucionAdministrativa.Checked = True Or boPredioNuevo = True Then

                                ' guarda la inconsistencia
                                vl_inFIPRNUFI = inFPDENUFI
                                vl_stFPINCODI = "3-DESTINACION"
                                vl_stFPINDESC = "Destino " & inFPDEDEEC & " existe en base de datos. " & inFPDENUFI
                                vl_stFIPRMUNI = vl_stRESOMUNI
                                vl_stFIPRCORR = ""
                                vl_stFIPRBARR = ""
                                vl_stFIPRMANZ = ""
                                vl_stFIPRPRED = ""
                                vl_stFIPREDIF = ""
                                vl_stFIPRUNPR = ""

                                pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                            End If

                        Else
                            ' guarda la inconsistencia
                            vl_inFIPRNUFI = inFPDENUFI
                            vl_stFPINCODI = "3-DESTINACION"
                            vl_stFPINDESC = "Ficha " & inFPDENUFI & " no existe en base de datos."
                            vl_stFIPRMUNI = vl_stRESOMUNI
                            vl_stFIPRCORR = ""
                            vl_stFIPRBARR = ""
                            vl_stFIPRMANZ = ""
                            vl_stFIPRPRED = ""
                            vl_stFIPREDIF = ""
                            vl_stFIPRUNPR = ""

                            pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                        End If
                    End If
                End If

                '==============================
                '*** Inserta tabla FIPRAVAL ***
                '==============================
                If stContenidoRegistro = "2" Then

                    ' variables directas
                    Dim inFPAVNUFI As Integer = stContenidoLinea.Substring(2, 9).ToString
                    Dim inFPAVARTE As Integer = stContenidoLinea.Substring(28, 10).ToString

                    ' instancia la ficha predial
                    Dim objdatos1 As New cla_FICHPRED

                    objdatos1.fun_Actualizar_FICHPRED_X_FIPRARTE(inFPAVNUFI, inFPAVARTE)

                End If

                '==============================
                '*** Inserta tabla FIPRPROP ***
                '==============================
                If stContenidoRegistro = "3" Then

                    ' variables indirectas
                    Dim stFPPRESTA As String = "ac"
                    Dim inFPPRNURE As Integer = 0
                    Dim inFPPRSECU As Integer = 0
                    Dim boFPPRGRAV As Boolean = False
                    Dim boFPPRLITI As Boolean = False
                    Dim stFPPRDENO As String = "05"
                    Dim stFPPRMUNO As String = ""
                    Dim stFPPRFERE As String = ""
                    Dim inFPPRCAPR As Integer = 1
                    Dim inFPPRMOAD As Integer = 1
                    Dim inFPPRSEXO As Integer = 1

                    ' variables directas
                    Dim inFPPRNUFI As Integer = stContenidoLinea.Substring(2, 9).ToString
                    Dim inFPPRTIDO As Integer = stContenidoLinea.Substring(14, 2).ToString
                    Dim stFPPRNUDO As String = stContenidoLinea.Substring(17, 14).ToString
                    Dim sTFPPRPRAP As String = Trim(stContenidoLinea.Substring(35, 15).ToString)
                    Dim stFPPRSEAP As String = Trim(stContenidoLinea.Substring(51, 15).ToString)
                    Dim stFPPRNOMB As String = Trim(stContenidoLinea.Substring(67, 20).ToString)
                    Dim stFPPRSICO As String = Trim(stContenidoLinea.Substring(98, 20).ToString)
                    Dim stFPPRNOTA As String = Trim(stContenidoLinea.Substring(139, 5).ToString)
                    Dim inFPPRESCR As Integer = stContenidoLinea.Substring(150, 6).ToString
                    Dim stFPPRFEES As String = stContenidoLinea.Substring(157, 8).ToString
                    Dim stFPPRDERE As String = stContenidoLinea.Substring(166, 9).ToString
                    Dim inFPPRLITI As Integer = stContenidoLinea.Substring(176, 1).ToString
                    Dim stFPPRPOLI As String = stContenidoLinea.Substring(178, 5).ToString
                    Dim inFPPRGRAV As Integer = stContenidoLinea.Substring(184, 1).ToString
                    Dim stFPPRMAIN As String = fun_Formato_Mascara_3_String(Trim(stContenidoLinea.Substring(186, 3).ToString)) & "-" & fun_Formato_Mascara_7_String(Trim(stContenidoLinea.Substring(190, 7).ToString))
                    Dim inFPPRTOMO As Integer = stContenidoLinea.Substring(198, 5).ToString

                    ' verifica campo nombre
                    If Trim(stFPPRNOMB) = "" Then
                        If Trim(stContenidoLinea.Substring(98, 10).ToString) <> "" Then
                            stFPPRNOMB = Trim(stContenidoLinea.Substring(98, 10).ToString)
                        Else
                            stFPPRNOMB = "N.N."
                        End If
                    End If

                    ' verifica campo nombre
                    If Trim(sTFPPRPRAP) = "" Then
                        If Trim(stContenidoLinea.Substring(108, 10).ToString) <> "" Then
                            sTFPPRPRAP = Trim(stContenidoLinea.Substring(99, 10).ToString)
                        Else
                            sTFPPRPRAP = "N.N."
                        End If
                    End If

                    ' campo modo adquisicion
                    If Trim(stFPPRMAIN) = "" Then
                        inFPPRMOAD = 2
                    Else
                        inFPPRMOAD = 1
                    End If

                    ' campo sexo
                    If CInt(inFPPRTIDO) = 1 Then
                        inFPPRSEXO = 1
                    ElseIf CInt(inFPPRTIDO) = 2 Then
                        inFPPRSEXO = 2
                    ElseIf CInt(inFPPRTIDO) = 3 Then
                        inFPPRSEXO = 3
                    Else
                        inFPPRSEXO = 1
                    End If

                    ' campo fecha de escritura
                    Dim stDia As String = stFPPRFEES.ToString.Substring(0, 2)
                    Dim stMes As String = stFPPRFEES.ToString.Substring(2, 2)
                    Dim stAno As String = stFPPRFEES.ToString.Substring(4, 4)

                    stFPPRFEES = stDia & "-" & stMes & "-" & stAno

                    ' campo derecho
                    Dim stFPPRDERE_1 As String = Val(stFPPRDERE.Substring(0, 3))
                    Dim stFPPRDERE_2 As String = "."
                    Dim stFPPRDERE_3 As String = stFPPRDERE.Substring(3, 6)
                    Dim stFPPRDERE_4 As String = stFPPRDERE_1 & stFPPRDERE_2 & stFPPRDERE_3

                    stFPPRDERE = CType(fun_Formato_Decimal_6_Decimales(stFPPRDERE_4), String)

                    ' campo porcentaje de litigio
                    Dim stFPPRPOLI_1 As String = Val(stFPPRPOLI.Substring(0, 3))
                    Dim stFPPRPOLI_2 As String = "."
                    Dim stFPPRPOLI_3 As String = stFPPRPOLI.Substring(3, 2)
                    Dim stFPPRPOLI_4 As String = stFPPRPOLI_1 & stFPPRPOLI_2 & stFPPRPOLI_3

                    stFPPRPOLI = CType(fun_Formato_Decimal_2_Decimales(stFPPRPOLI_4), String)

                    ' convierte en variable boleona
                    If inFPPRGRAV = 1 Then
                        boFPPRGRAV = True
                    Else
                        boFPPRGRAV = False
                    End If

                    If inFPPRLITI = 1 Then
                        boFPPRLITI = True
                    Else
                        boFPPRLITI = False
                    End If

                    ' inserta solo predios nuevos
                    If boPredioNuevo = True And Me.rbdInsertaPrediosNuevosResolucionAdministrativa.Checked = True Then

                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPPRNUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPPRNURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' asigna numero de documento para codigo asignado
                            If Trim(stFPPRNUDO) = "" Then
                                stFPPRNUDO = inNroDeRegistroDelPlano
                            End If

                            ' busca la secuencia de registro
                            inFPPRSECU = fun_BuscarNroSecuenciaPropietario(inFPPRNUFI)

                            ' instancia la clase 
                            Dim obj_FIPRPROP As New cla_FIPRPROP

                            ' inserta el registro
                            obj_FIPRPROP.fun_Insertar_FIPRPROP(inFPPRNUFI, inFPPRCAPR, inFPPRSEXO, inFPPRTIDO, stFPPRNUDO, sTFPPRPRAP, stFPPRSEAP, stFPPRNOMB, stFPPRDERE, stFPPRSICO, inFPPRESCR, stFPPRDENO, stFPPRMUNO, stFPPRNOTA, stFPPRFEES, stFPPRFERE, inFPPRTOMO, stFPPRMAIN, boFPPRGRAV, inFPPRMOAD, boFPPRLITI, stFPPRPOLI, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPPRSECU, inFPPRNURE, stFPPRESTA)

                            ' actualiza ficha predial
                            pro_ActualizarFichaPredial(inFPPRNUFI, inFPPRMOAD, inFPPRLITI, stFPPRPOLI)

                            ' instancia la clase tercero
                            Dim obj_TERCERO As New cla_TERCERO
                            Dim tbl_TERCERO As New DataTable

                            tbl_TERCERO = obj_TERCERO.fun_Buscar_CODIGO_TERCERO(stFPPRNUDO)

                            If tbl_TERCERO.Rows.Count = 0 Then

                                Dim obj1_TERCERO As New cla_TERCERO

                                obj1_TERCERO.fun_Insertar_TERCERO(stFPPRNUDO, inFPPRTIDO, inFPPRCAPR, inFPPRSEXO, stFPPRNOMB, sTFPPRPRAP, stFPPRSEAP, stFPPRSICO, "", "", "", "", "ac", "Tercero ingresado por importación de datos")

                            End If

                        End If

                    Else

                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPPRNUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPPRNURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' asigna numero de documento para codigo asignado
                            If Trim(stFPPRNUDO) = "" Then
                                stFPPRNUDO = inNroDeRegistroDelPlano
                            End If

                            ' instancia la clase
                            Dim obj2_FIPRPROP As New cla_FIPRPROP
                            Dim tbl2 As New DataTable

                            ' consulta si ya existe el propietario
                            tbl2 = obj2_FIPRPROP.fun_Buscar_CODIGO_FIPRPROP(inFPPRNUFI, stFPPRNUDO)

                            ' cuenta los registros
                            If tbl2.Rows.Count = 0 Then

                                ' busca la secuencia de registro
                                inFPPRSECU = fun_BuscarNroSecuenciaPropietario(inFPPRNUFI)

                                ' instancia la clase 
                                Dim obj_FIPRPROP As New cla_FIPRPROP

                                If Me.rbdActualizarInsertarPrediosResolucionAdministrativa.Checked = True And Me.chkPropietarioResolucionAdministrativa.Checked = True And boPredioNuevo = False Then
                                    ' inserta el registro
                                    obj_FIPRPROP.fun_Insertar_FIPRPROP(inFPPRNUFI, inFPPRCAPR, inFPPRSEXO, inFPPRTIDO, stFPPRNUDO, sTFPPRPRAP, stFPPRSEAP, stFPPRNOMB, stFPPRDERE, stFPPRSICO, inFPPRESCR, stFPPRDENO, stFPPRMUNO, stFPPRNOTA, stFPPRFEES, stFPPRFERE, inFPPRTOMO, stFPPRMAIN, boFPPRGRAV, inFPPRMOAD, boFPPRLITI, stFPPRPOLI, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPPRSECU, inFPPRNURE, stFPPRESTA)

                                ElseIf Me.chkSobrescribirBDexistenteResolucionAdministrativa.Checked = True Or boPredioNuevo = True Then
                                    ' inserta el registro
                                    obj_FIPRPROP.fun_Insertar_FIPRPROP(inFPPRNUFI, inFPPRCAPR, inFPPRSEXO, inFPPRTIDO, stFPPRNUDO, sTFPPRPRAP, stFPPRSEAP, stFPPRNOMB, stFPPRDERE, stFPPRSICO, inFPPRESCR, stFPPRDENO, stFPPRMUNO, stFPPRNOTA, stFPPRFEES, stFPPRFERE, inFPPRTOMO, stFPPRMAIN, boFPPRGRAV, inFPPRMOAD, boFPPRLITI, stFPPRPOLI, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPPRSECU, inFPPRNURE, stFPPRESTA)

                                End If

                                ' actualiza ficha predial
                                pro_ActualizarFichaPredial(inFPPRNUFI, inFPPRMOAD, inFPPRLITI, stFPPRPOLI)

                                ' instancia la clase tercero
                                Dim obj_TERCERO As New cla_TERCERO
                                Dim tbl_TERCERO As New DataTable

                                tbl_TERCERO = obj_TERCERO.fun_Buscar_CODIGO_TERCERO(stFPPRNUDO)

                                If tbl_TERCERO.Rows.Count = 0 Then

                                    Dim obj1_TERCERO As New cla_TERCERO

                                    obj1_TERCERO.fun_Insertar_TERCERO(stFPPRNUDO, inFPPRTIDO, inFPPRCAPR, inFPPRSEXO, stFPPRNOMB, sTFPPRPRAP, stFPPRSEAP, stFPPRSICO, "", "", "", "", "ac", "Tercero ingresado por importación de datos")

                                End If

                            ElseIf Me.chkSobrescribirBDexistenteResolucionAdministrativa.Checked = True Or boPredioNuevo = True Then

                                ' guarda la inconsistencia
                                vl_inFIPRNUFI = inFPPRNUFI
                                vl_stFPINCODI = "4-PROPIETARIO"
                                vl_stFPINDESC = "Nro. documento " & stFPPRNUDO & " existe en base de datos. " & inFPPRNUFI
                                vl_stFIPRMUNI = vl_stRESOMUNI
                                vl_stFIPRCORR = ""
                                vl_stFIPRBARR = ""
                                vl_stFIPRMANZ = ""
                                vl_stFIPRPRED = ""
                                vl_stFIPREDIF = ""
                                vl_stFIPRUNPR = ""

                                pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                            End If


                        Else

                            ' guarda la inconsistencia
                            vl_inFIPRNUFI = inFPPRNUFI
                            vl_stFPINCODI = "4-PROPIETARIO"
                            vl_stFPINDESC = "Ficha " & inFPPRNUFI & " no existe en base de datos."
                            vl_stFIPRMUNI = vl_stRESOMUNI
                            vl_stFIPRCORR = ""
                            vl_stFIPRBARR = ""
                            vl_stFIPRMANZ = ""
                            vl_stFIPRPRED = ""
                            vl_stFIPREDIF = ""
                            vl_stFIPRUNPR = ""

                            pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                        End If

                    End If

                End If

                '==============================
                '*** Inserta tabla FIPRZOEC ***
                '==============================
                If stContenidoRegistro = "4" Then

                    ' variables indirectas
                    Dim stFPZEESTA As String = "ac"
                    Dim inFPZENURE As Integer = 0
                    Dim inFPZESECU As Integer = 0

                    ' variables directas
                    Dim inFPZENUFI As Integer = stContenidoLinea.Substring(2, 9).ToString
                    Dim inFPZEZOEC As Integer = stContenidoLinea.Substring(12, 3).ToString
                    Dim inFPZEPORC As Integer = stContenidoLinea.Substring(16, 3).ToString


                    ' inserta solo predios nuevos
                    If boPredioNuevo = True And Me.rbdInsertaPrediosNuevosResolucionAdministrativa.Checked = True And inFPZEPORC <> 0 Then

                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPZENUFI)

                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPZENURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' busca la secuencia de registro
                            inFPZESECU = fun_BuscarNroSecuenciaZonaEconomica(inFPZENUFI)

                            Dim obj_FIPRZOEC As New cla_FIPRZOEC

                            ' inserta el registro
                            obj_FIPRZOEC.fun_Insertar_FIPRZOEC(inFPZENUFI, inFPZEZOEC, inFPZEPORC, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPZESECU, inFPZENURE, stFPZEESTA)

                        End If

                    Else
                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPZENUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 And inFPZEPORC <> 0 Then

                            ' busca el numero de registro
                            inFPZENURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' instancia la clase
                            Dim obj2_FIPRZOEC As New cla_FIPRZOEC
                            Dim tbl2 As New DataTable

                            ' consulta la llave primaria
                            tbl2 = obj2_FIPRZOEC.fun_Buscar_CODIGO_FIPRZOEC(inFPZENUFI, inFPZEZOEC)

                            ' cuenta los registros
                            If tbl2.Rows.Count = 0 Then

                                ' busca la secuencia de registro
                                inFPZESECU = fun_BuscarNroSecuenciaZonaEconomica(inFPZENUFI)

                                Dim obj_FIPRZOEC As New cla_FIPRZOEC

                                If Me.rbdActualizarInsertarPrediosResolucionAdministrativa.Checked = True And Me.chkDestinoEconomicoResolucionAdministrativa.Checked = True And boPredioNuevo = False Then
                                    ' instancia la clase 
                                    obj_FIPRZOEC.fun_Insertar_FIPRZOEC(inFPZENUFI, inFPZEZOEC, inFPZEPORC, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPZESECU, inFPZENURE, stFPZEESTA)

                                ElseIf Me.chkSobrescribirBDexistenteResolucionAdministrativa.Checked = True Or boPredioNuevo = True Then
                                    ' inserta el registro
                                    obj_FIPRZOEC.fun_Insertar_FIPRZOEC(inFPZENUFI, inFPZEZOEC, inFPZEPORC, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPZESECU, inFPZENURE, stFPZEESTA)

                                End If

                            ElseIf Me.chkSobrescribirBDexistenteResolucionAdministrativa.Checked = True Or boPredioNuevo = True Then

                                ' guarda la inconsistencia
                                vl_inFIPRNUFI = inFPZENUFI
                                vl_stFPINCODI = "4-ZONAECONOMICA"
                                vl_stFPINDESC = "Zona economica " & inFPZEZOEC & " existe en base de datos. " & inFPZENUFI
                                vl_stFIPRMUNI = vl_stRESOMUNI
                                vl_stFIPRCORR = ""
                                vl_stFIPRBARR = ""
                                vl_stFIPRMANZ = ""
                                vl_stFIPRPRED = ""
                                vl_stFIPREDIF = ""
                                vl_stFIPRUNPR = ""

                                pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                            End If

                        Else
                            ' guarda la inconsistencia
                            vl_inFIPRNUFI = inFPZENUFI
                            vl_stFPINCODI = "4-ZONAECONOMICA"
                            vl_stFPINDESC = "Ficha " & inFPZENUFI & " no existe en base de datos."
                            vl_stFIPRMUNI = vl_stRESOMUNI
                            vl_stFIPRCORR = ""
                            vl_stFIPRBARR = ""
                            vl_stFIPRMANZ = ""
                            vl_stFIPRPRED = ""
                            vl_stFIPREDIF = ""
                            vl_stFIPRUNPR = ""

                            pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                        End If
                    End If
                End If

                '===============================
                '*** Insertar tabla FIPRCONS ***
                '===============================
                If stContenidoRegistro = "5" Then

                    ' variables indirectas
                    Dim stFPCOESTA As String = "ac"
                    Dim inFPCONURE As Integer = 0
                    Dim inFPCOSECU As Integer = 0
                    Dim boFPCOMEJO As Boolean = False
                    Dim boFPCOLEY As Boolean = False
                    Dim inFPCOCLCO As Integer = 1
                    Dim inFPCOAVCO As Integer = 0
                    Dim inFPCOMEJO As Integer = 2
                    Dim inFPCOLEY As Integer = 2
                    Dim inFPCOACUE As Integer = 1
                    Dim inFPCOTELE As Integer = 1
                    Dim inFPCOALCA As Integer = 1
                    Dim inFPCOENER As Integer = 1
                    Dim inFPCOGAS As Integer = 2
                    Dim inFPCOPISO As Integer = 1
                    Dim inFPCOPOCO As Integer = 100
                    Dim inFPCOEDCO As Integer = 1

                    ' variables directas
                    Dim inFPCONUFI As Integer = stContenidoLinea.Substring(2, 9).ToString
                    Dim inFPCOUNID As Integer = stContenidoLinea.Substring(12, 4).ToString
                    Dim stFPCOARCO As String = stContenidoLinea.Substring(17, 10).ToString
                    Dim inFPCOPUNT As Integer = stContenidoLinea.Substring(28, 3).ToString
                    Dim stFPCOTICO As String = stContenidoLinea.Substring(32, 3).ToString
                    ' campo porcentaje de litigio
                    Dim stFPCOARCO_1 As String = Val(stFPCOARCO.Substring(0, 8))
                    Dim stFPCOARCO_2 As String = "."
                    Dim stFPCOARCO_3 As String = stFPCOARCO.Substring(8, 2)
                    Dim stFPCOARCO_4 As String = stFPCOARCO_1 & stFPCOARCO_2 & stFPCOARCO_3

                    stFPCOARCO = CType(fun_Formato_Decimal_2_Decimales(stFPCOARCO_4), String)

                    ' variables boleanas
                    If inFPCOMEJO = 1 Then
                        boFPCOMEJO = True
                    Else
                        boFPCOMEJO = False
                    End If

                    If inFPCOLEY = 1 Then
                        boFPCOLEY = True
                    Else
                        boFPCOLEY = False
                    End If

                    ' coloca la clase 1
                    If stFPCOTICO < 500 AndAlso _
                           stFPCOTICO <> "020" AndAlso stFPCOTICO <> "037" AndAlso _
                           stFPCOTICO <> "019" AndAlso stFPCOTICO <> "028" AndAlso _
                           stFPCOTICO <> "032" AndAlso stFPCOTICO <> "072" AndAlso _
                           stFPCOTICO <> "074" AndAlso stFPCOTICO <> "075" AndAlso _
                           stFPCOTICO <> "076" AndAlso stFPCOTICO <> "077" AndAlso _
                           stFPCOTICO <> "078" AndAlso stFPCOTICO <> "073" Then

                        inFPCOCLCO = 1
                    End If

                    ' coloca la clase 2
                    If stFPCOTICO < 500 AndAlso _
                           stFPCOTICO = "020" Or stFPCOTICO = "037" Or _
                           stFPCOTICO = "019" Or stFPCOTICO = "028" Or _
                           stFPCOTICO = "032" Or stFPCOTICO = "072" Or _
                           stFPCOTICO = "074" Or stFPCOTICO = "075" Or _
                           stFPCOTICO = "076" Or stFPCOTICO = "077" Or _
                           stFPCOTICO = "078" Or stFPCOTICO = "073" Then

                        inFPCOCLCO = 2
                    End If

                    ' coloca la clase 3
                    If stFPCOTICO > 500 Then
                        inFPCOCLCO = 3
                    End If

                    ' inserta solo predios nuevos
                    If boPredioNuevo = True And Me.rbdInsertaPrediosNuevosResolucionAdministrativa.Checked = True Then

                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPCONUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPCONURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' busca la secuencia de registro
                            inFPCOSECU = fun_BuscarNroSecuenciaConstruccion(inFPCONUFI)

                            ' instancia la clase 
                            Dim obj_FIPRCONS As New cla_FIPRCONS

                            ' inserta el registro
                            obj_FIPRCONS.fun_Insertar_FIPRCONS(inFPCONUFI, inFPCOUNID, inFPCOCLCO, stFPCOTICO, inFPCOPUNT, stFPCOARCO, inFPCOACUE, inFPCOALCA, inFPCOENER, inFPCOTELE, inFPCOGAS, inFPCOPISO, inFPCOEDCO, inFPCOPOCO, boFPCOMEJO, boFPCOLEY, inFPCOAVCO, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPCOSECU, inFPCONURE, stFPCOESTA)

                        End If

                    Else

                        ' instancia la ficha predial
                        Dim objdatos1 As New cla_FICHPRED
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPCONUFI)

                        ' verifica si existe la ficha predial
                        If tbl1.Rows.Count > 0 Then

                            ' busca el numero de registro
                            inFPCONURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                            ' instancia la clase
                            Dim obj2_FIPRCONS As New cla_FIPRCONS
                            Dim tbl2 As New DataTable

                            ' consulta si ya existe el propietario
                            tbl2 = obj2_FIPRCONS.fun_Buscar_CODIGO_FIPRCONS(inFPCONUFI, inFPCOUNID)

                            ' cuenta los registros
                            If tbl2.Rows.Count = 0 Then

                                ' busca la secuencia de registro
                                inFPCOSECU = fun_BuscarNroSecuenciaConstruccion(inFPCONUFI)

                                ' instancia la clase 
                                Dim obj_FIPRCONS As New cla_FIPRCONS

                                If Me.rbdActualizarInsertarPrediosResolucionAdministrativa.Checked = True And Me.chkConstruccionResolucionAdministrativa.Checked = True And boPredioNuevo = False Then
                                    ' inserta el registro
                                    obj_FIPRCONS.fun_Insertar_FIPRCONS(inFPCONUFI, inFPCOUNID, inFPCOCLCO, stFPCOTICO, inFPCOPUNT, stFPCOARCO, inFPCOACUE, inFPCOALCA, inFPCOENER, inFPCOTELE, inFPCOGAS, inFPCOPISO, inFPCOEDCO, inFPCOPOCO, boFPCOMEJO, boFPCOLEY, inFPCOAVCO, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPCOSECU, inFPCONURE, stFPCOESTA)

                                ElseIf Me.chkSobrescribirBDexistenteResolucionAdministrativa.Checked = True Or boPredioNuevo = True Then
                                    ' inserta el registro
                                    obj_FIPRCONS.fun_Insertar_FIPRCONS(inFPCONUFI, inFPCOUNID, inFPCOCLCO, stFPCOTICO, inFPCOPUNT, stFPCOARCO, inFPCOACUE, inFPCOALCA, inFPCOENER, inFPCOTELE, inFPCOGAS, inFPCOPISO, inFPCOEDCO, inFPCOPOCO, boFPCOMEJO, boFPCOLEY, inFPCOAVCO, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPCOSECU, inFPCONURE, stFPCOESTA)

                                End If

                            ElseIf Me.chkSobrescribirBDexistenteResolucionAdministrativa.Checked = True Or boPredioNuevo = True Then

                                ' guarda la inconsistencia
                                vl_inFIPRNUFI = inFPCONUFI
                                vl_stFPINCODI = "5-CONSTRUCCION"
                                vl_stFPINDESC = "Nro. construcción " & inFPCOUNID & " existe en base de datos. " & inFPCONUFI
                                vl_stFIPRMUNI = vl_stRESOMUNI
                                vl_stFIPRCORR = ""
                                vl_stFIPRBARR = ""
                                vl_stFIPRMANZ = ""
                                vl_stFIPRPRED = ""
                                vl_stFIPREDIF = ""
                                vl_stFIPRUNPR = ""

                                pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                            End If

                        Else

                            ' guarda la inconsistencia
                            vl_inFIPRNUFI = inFPCONUFI
                            vl_stFPINCODI = "5-CONSTRUCCION"
                            vl_stFPINDESC = "Ficha " & inFPCONUFI & " no existe en base de datos."
                            vl_stFIPRMUNI = vl_stRESOMUNI
                            vl_stFIPRCORR = ""
                            vl_stFIPRBARR = ""
                            vl_stFIPRMANZ = ""
                            vl_stFIPRPRED = ""
                            vl_stFIPREDIF = ""
                            vl_stFIPRUNPR = ""

                            pro_GrabarInconsistencia(vl_stFPINCODI, vl_stFPINDESC)

                        End If
                    End If
                End If

                ' Incrementa la barra
                inProceso = inProceso + 1
                pbProcesoResolucionAdministrativa.Value = inProceso

            Loop

            ' consulta las inconsistencas de las fichas validadas
            Dim objdatos As New cla_VALIFIPR
            Dim tbl As New DataTable

            tbl = objdatos.fun_Consultar_INCONSISTENCIA_X_RESOLUCION(stRESOLUCION)

            ' Crea objeto de columnas y registros
            Dim dt1 As New DataTable
            Dim dr1 As DataRow

            ' Crea las columnas
            dt1.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
            dt1.Columns.Add(New DataColumn("Cedula catastral", GetType(String)))
            dt1.Columns.Add(New DataColumn("Codigo incons.", GetType(String)))
            dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))

            Dim i As Integer

            For i = 0 To tbl.Rows.Count - 1

                dr1 = dt1.NewRow()
                dr1("Nro_Ficha") = tbl.Rows(i).Item("FPINNUFI")
                dr1("Cedula catastral") = tbl.Rows(i).Item("FPINMUNI") & "-" & _
                                         tbl.Rows(i).Item("FPINCORR") & "-" & _
                                         tbl.Rows(i).Item("FPINBARR") & "-" & _
                                         tbl.Rows(i).Item("FPINMANZ") & "-" & _
                                         tbl.Rows(i).Item("FPINPRED") & "-" & _
                                         tbl.Rows(i).Item("FPINEDIF") & "-" & _
                                         tbl.Rows(i).Item("FPINUNPR")
                dr1("Codigo incons.") = tbl.Rows(i).Item("FPINCODI")
                dr1("Descripcion") = tbl.Rows(i).Item("FPINDESC")
                dt1.Rows.Add(dr1)

            Next

            ' Llena el datagrigview
            TabControl1.SelectTab(TabPage1)
            Me.dgvFIPRINCO.DataSource = dt1
            pbProcesoResolucionAdministrativa.Value = 0

            ' comando grabar datos
            If dt1.Rows.Count = 0 Then
                MessageBox.Show("Proceso de guardado terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("Proceso de guardado con inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

            Me.cmdGrabarDatosResolucionAdministrativa.Enabled = False
            Me.lblFecha2ResolucionAdministrativa.Visible = False
            Me.cmdValidaDatosResolucionAdministrativa.Enabled = False

            Me.cmdAbrirArchivoResolucionAdministrativa.Focus()

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRINCO.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub

    Private Sub pro_InactivarPredios()

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' variables
            Dim stFIPRMUNI As String = Trim(txtREACMUNI.Text)
            Dim stFIPRCLSE As String = Trim(txtREACCLSE.Text)
            Dim stFIPRESTA As String = "in"


            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "update FICHPRED "
            ParametrosConsulta += "set FIPRESTA = '" & stFIPRESTA & "' "
            ParametrosConsulta += "where FIPRMUNI = '" & stFIPRMUNI & "' and "
            ParametrosConsulta += "FIPRCLSE = '" & stFIPRCLSE & "' and "
            ParametrosConsulta += "FIPRTIFI = '" & "0" & "' "

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

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAbrirArchivoResolucionActualizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivoResolucionActualizacion.Click

        Try
            ' declara variable
            inTotalRegistros = 0

            ' apaga los comandos
            Me.cmdValidaDatosResolucionActualizacion.Enabled = False
            Me.cmdGrabarDatosResolucionActualizacion.Enabled = False

            If Me.rbdFichaPredialResolucionActualizacion.Checked = True Then
                pro_LimpiarCampos()
            End If

            Me.lblFecha2ResolucionActualizacion.Visible = False

            ' enruta el archivo
            oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
            oLeer.Filter = "Archivo de texto (*.txt)|*.txt" 'Colocar varias extensiones
            oLeer.FilterIndex = 1 'coloca por defecto el *.txt
            oLeer.FileName = ""
            oLeer.ShowDialog()

            stRutaArchivo = Trim(oLeer.FileName)
            lblAbrirArchivoResolucionActualizacion.Text = Trim(oLeer.FileName)

            ' selecciona ficha predial
            If Me.rbdFichaPredialResolucionActualizacion.Checked = True Then

                If Trim(stRutaArchivo) <> "" Then

                    ' almacena la linea
                    Dim stContenidoLinea As String = ""
                    Dim stContenidoRegistro As String = ""

                    ' abre el archivo
                    FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                    stContenidoLinea = LineInput(1)

                    Me.txtREACDEPA.Text = "05"
                    Me.txtREACVIGE.Text = CType(fun_Formato_Mascara_4_Reales(stContenidoLinea.Substring(1, 4).ToString), String)
                    Me.txtREACTIRE.Text = CType(fun_Formato_Mascara_3_Reales(stContenidoLinea.Substring(5, 3).ToString), String)
                    Me.txtREACRESO.Text = CType(fun_Formato_Mascara_7_Reales(stContenidoLinea.Substring(8, 7).ToString), String)
                    Me.txtREACMUNI.Text = CType(fun_Formato_Mascara_3_Reales(stContenidoLinea.Substring(15, 3).ToString), String)
                    Me.txtREACCLSE.Text = stContenidoLinea.Substring(18, 1).ToString

                    ' lista de valores
                    Me.lblREACCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(Me.txtREACCLSE.Text)), String)
                    Me.lblREACTIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO(Trim(Me.txtREACTIRE.Text)), String)
                    Me.lblREACMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO("05", Me.txtREACMUNI.Text), String)
                    Me.lblREACDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Trim("05")), String)
                    Me.lblREACVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Trim(Me.txtREACVIGE.Text)), String)
                    Me.lblREACRESO.Text = CType(fun_Buscar_Lista_Valores_RESOLUCION(Trim(Me.txtREACDEPA.Text), Trim(Me.txtREACMUNI.Text), Trim(Me.txtREACTIRE.Text), Trim(Me.txtREACCLSE.Text), Trim(Me.txtREACVIGE.Text), Trim(Me.txtREACRESO.Text)), String)

                    ' Total de registros
                    Do Until EOF(1)
                        stContenidoLinea = LineInput(1)
                        inTotalRegistros += 1
                    Loop

                    Me.strBARRESTA.Items(2).Text = "Registro : " & inTotalRegistros

                    Me.cmdValidaDatosResolucionActualizacion.Enabled = True
                    Me.cmdValidaDatosResolucionActualizacion.Focus()

                    If CStr(Trim(vp_usuario)) = CStr("ADMINISTRADOR") Then
                        Me.cmdGrabarDatosResolucionActualizacion.Enabled = True
                    End If

                End If

            End If

            ' selecciona ficha resumen
            If Me.rbdFichaResumenResolucionActualizacion.Checked = True Then

                If Trim(stRutaArchivo) <> "" Then

                    ' almacena la linea
                    Dim stContenidoLinea As String = ""
                    Dim stContenidoRegistro As String = ""

                    ' abre el archivo
                    FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                    stContenidoLinea = LineInput(1)

                    ' Total de registros
                    Do Until EOF(1)
                        stContenidoLinea = LineInput(1)
                        inTotalRegistros += 1
                    Loop

                    Me.strBARRESTA.Items(2).Text = "Registro : " & inTotalRegistros

                    If Trim(Me.txtREACRESO.Text) <> "" Then

                        Me.cmdValidaDatosResolucionActualizacion.Enabled = True
                        Me.cmdValidaDatosResolucionActualizacion.Focus()

                        If CStr(Trim(vp_usuario)) = CStr("ADMINISTRADOR") Then
                            Me.cmdGrabarDatosResolucionActualizacion.Enabled = True
                        End If

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub cmdValidaDatosResolucionActualizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidaDatosResolucionActualizacion.Click
        Try
            ' apaga los comandos
            Me.cmdValidaDatosResolucionActualizacion.Enabled = False
            Me.cmdGrabarDatosResolucionActualizacion.Enabled = False

            Me.lblFecha2ResolucionActualizacion.Visible = False

            ' selecciona ficha predial
            If Me.rbdFichaPredialResolucionActualizacion.Checked = True Then
                If Trim(stRutaArchivo) <> "" Then

                    pro_ValidarFichaPredialResolucionActualizacion()

                End If
            End If

            If Me.rbdFichaResumenResolucionActualizacion.Checked = True Then
                If Trim(stRutaArchivo) <> "" Then

                    pro_ValidarFichaResumenResolucionActualizacion()

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            MessageBox.Show("Error al importar el archivo, revise la longitud o tipo de archivo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub cmdGrabarDatosResolucionActualizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabarDatosResolucionActualizacion.Click

        Try
            If Me.rbdFichaPredialResolucionActualizacion.Checked = True Then
                If Me.dgvFIPRINCO.RowCount = 0 Then
                    If Trim(stRutaArchivo) <> "" Then

                        pro_GuardarDatosFichaPredialResolucionActualizacion()

                    End If
                End If
            End If

            ' selecciona ficha resumen
            If Me.rbdFichaResumenResolucionActualizacion.Checked = True Then
                If Me.dgvFIREINCO.RowCount = 0 Then
                    If Trim(stRutaArchivo) <> "" Then

                        pro_GuardarDatosFichaResumenResolucionActualizacion()

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & a)
            MessageBox.Show("Error al guardar los datos, revise la integridad del archivo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        Finally
            FileClose(1)
        End Try

    End Sub

    Private Sub cmdAbrirArchivoResolucionAdministrativa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivoResolucionAdministrativa.Click

        Try
            ' declara variable
            inTotalRegistros = 0

            ' apaga los comandos
            Me.cmdValidaDatosResolucionAdministrativa.Enabled = False
            Me.cmdGrabarDatosResolucionAdministrativa.Enabled = False

            If Me.rbdFichaPredialResolucionAdministrativa.Checked = True And Trim(Me.txtREADRESO.Text) = "" Then
                pro_LimpiarCampos()
            End If

            Me.lblFecha2ResolucionAdministrativa.Visible = False

            ' enruta el archivo
            oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
            oLeer.Filter = "Archivo de texto (*.txt)|*.txt" 'Colocar varias extensiones
            oLeer.FilterIndex = 1 'coloca por defecto el *.txt
            oLeer.FileName = ""
            oLeer.ShowDialog()

            stRutaArchivo = Trim(oLeer.FileName)
            lblAbrirArchivoResolucionAdministrativa.Text = Trim(oLeer.FileName)

            ' selecciona ficha predial
            If Me.rbdFichaPredialResolucionAdministrativa.Checked = True Then

                If Trim(stRutaArchivo) <> "" Then

                    ' almacena la linea
                    Dim stContenidoLinea As String = ""
                    Dim stContenidoRegistro As String = ""

                    ' abre el archivo
                    FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                    stContenidoLinea = LineInput(1)

                    Me.txtREADDEPA.Text = "05"
                    Me.txtREADMUNI.Text = CType(fun_Formato_Mascara_3_Reales(stContenidoLinea.Substring(26, 3).ToString), String)

                    ' lista de valores
                    Me.lblREADDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Trim("05")), String)
                    Me.lblREADMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO("05", Me.txtREADMUNI.Text), String)


                    ' Total de registros
                    Do Until EOF(1)
                        stContenidoLinea = LineInput(1)
                        inTotalRegistros += 1
                    Loop

                    Me.strBARRESTA.Items(2).Text = "Registro : " & inTotalRegistros

                    Me.cmdValidaDatosResolucionAdministrativa.Enabled = True
                    Me.cmdValidaDatosResolucionAdministrativa.Focus()

                    If CStr(Trim(vp_usuario)) = CStr("ADMINISTRADOR") Then
                        Me.cmdGrabarDatosResolucionAdministrativa.Enabled = True
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub cmdValidaDatosResolucionAdministrativa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidaDatosResolucionAdministrativa.Click
        Me.cmdGrabarDatosResolucionAdministrativa.Enabled = True
    End Sub
    Private Sub cmdGrabarDatosResolucionAdministrativa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabarDatosResolucionAdministrativa.Click

        Try

            If Me.rbdFichaPredialResolucionAdministrativa.Checked = True Then
                If Trim(stRutaArchivo) <> "" Then

                    pro_GuardarDatosFichaPredialResolucionAdministrativa()

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & a)
            MessageBox.Show("Error al guardar los datos, revise la integridad del archivo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        Finally
            FileClose(1)
        End Try

    End Sub

    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try
            ' exporta ficha predial
            If Me.rbdFichaPredialResolucionActualizacion.Checked = True Then
                If Me.dgvFIPRINCO.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvFIPRINCO.DataSource, DataTable))
                End If
            End If

            ' exporta ficha resumen
            If Me.rbdFichaResumenResolucionActualizacion.Checked = True Then
                If Me.dgvFIREINCO.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvFIREINCO.DataSource, DataTable))
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarPlano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.Click
        Try

            If Me.rbdFichaPredialResolucionActualizacion.Checked = True Then
                pro_ExportarPlano(Me.dgvFIPRINCO.DataSource)
            End If

            If Me.rbdFichaResumenResolucionActualizacion.Checked = True Then
                pro_ExportarPlano(Me.dgvFIREINCO.DataSource)
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_importar_planos_FICHA_PREDIAL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.strBARRESTA.Items(0).Text = "Importar planos"
        Me.strBARRESTA.Items(2).Text = "Registros: 0"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmdAbrirArchivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivoResolucionActualizacion.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdAbrirArchivoResolucionActualizacion.AccessibleDescription
    End Sub
    Private Sub cmdValidaDatos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdValidaDatosResolucionActualizacion.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdValidaDatosResolucionActualizacion.AccessibleDescription
    End Sub
    Private Sub cmdGrabarDatos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGrabarDatosResolucionActualizacion.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdGrabarDatosResolucionActualizacion.AccessibleDescription
    End Sub
    Private Sub cmdExportarExcel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdExportarExcel.AccessibleDescription
    End Sub
    Private Sub cmdExportarPlano_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdExportarPlano.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub rbdFichaPredial_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbdFichaPredialResolucionActualizacion.GotFocus
        Me.strBARRESTA.Items(0).Text = rbdFichaPredialResolucionActualizacion.AccessibleDescription
    End Sub
    Private Sub rbdFichaResumen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbdFichaResumenResolucionActualizacion.GotFocus
        Me.strBARRESTA.Items(0).Text = rbdFichaResumenResolucionActualizacion.AccessibleDescription
    End Sub
    Private Sub dgvFIPRINCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFIPRINCO.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvFIPRINCO.AccessibleDescription
    End Sub
    Private Sub dgvFIREINCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFIREINCO.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvFIREINCO.AccessibleDescription
    End Sub

#End Region

#Region "TextChanged"

    Private Sub lblRUTA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblAbrirArchivoResolucionActualizacion.TextChanged, lblAbrirArchivoResolucionAdministrativa.TextChanged

        If Me.rbdFichaPredialResolucionActualizacion.Checked = True And Trim(Me.lblAbrirArchivoResolucionActualizacion.Text) <> "" Then
            Me.cmdValidaDatosResolucionActualizacion.Enabled = True
        Else
            Me.cmdValidaDatosResolucionActualizacion.Enabled = False
        End If

        If Me.rbdFichaResumenResolucionActualizacion.Checked = True And Trim(Me.lblAbrirArchivoResolucionActualizacion.Text) <> "" And Trim(Me.txtREACRESO.Text) <> "" Then
            Me.cmdValidaDatosResolucionActualizacion.Enabled = True
        Else
            Me.cmdValidaDatosResolucionActualizacion.Enabled = False
        End If

        If Me.rbdFichaPredialResolucionAdministrativa.Checked = True And Trim(Me.lblAbrirArchivoResolucionAdministrativa.Text) <> "" Then
            Me.cmdValidaDatosResolucionAdministrativa.Enabled = True
        Else
            Me.cmdValidaDatosResolucionAdministrativa.Enabled = False
        End If

    End Sub

#End Region

#Region "CheckedChanged"

    Private Sub rbdFichaResumen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdFichaResumenResolucionActualizacion.CheckedChanged

        If rbdFichaResumenResolucionActualizacion.Checked = True Then

            Me.cmdSeleccionResolucionActualizacion.Visible = True
            Me.cmdAbrirArchivoResolucionActualizacion.Enabled = False

            Me.rbdActualizarInsertarPrediosResolucionActualizacion.Visible = False
            Me.rbdInsertaPrediosNuevosResolucionActualizacion.Visible = False

            Me.rbdActualizarInsertarPrediosResolucionActualizacion.Checked = False
            Me.rbdInsertaPrediosNuevosResolucionActualizacion.Checked = False

            pro_LimpiarCampos()

        ElseIf rbdFichaPredialResolucionActualizacion.Checked = True Then

            Me.cmdSeleccionResolucionActualizacion.Visible = False
            Me.cmdAbrirArchivoResolucionActualizacion.Enabled = True
            Me.chkSobrescribirBDexistenteResolucionActualizacion.Checked = False

            Me.rbdActualizarInsertarPrediosResolucionActualizacion.Visible = True
            Me.rbdInsertaPrediosNuevosResolucionActualizacion.Visible = True

            Me.rbdActualizarInsertarPrediosResolucionActualizacion.Checked = True
            Me.rbdInsertaPrediosNuevosResolucionActualizacion.Checked = False

            pro_LimpiarCampos()

        End If

    End Sub

#End Region

#Region "Click"

    Private Sub cmdSeleccionResolucionActualizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeleccionResolucionActualizacion.Click

        Try
            ' seleccina ninguna resolución
            vp_inConsulta = 0

            ' llama el formulario de consulta
            Dim frm_RESOLUCION As New frm_consultar_RESOLUCION_PUBLICA
            frm_RESOLUCION.ShowDialog()

            ' verifica si hay alguna seleccionada
            If vp_inConsulta <> 0 Then

                Dim objdatos As New cla_RESOLUCION
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_RESOLUCION(vp_inConsulta)

                ' coloca los valores en los campos
                Me.txtREACDEPA.Text = CType(fun_Formato_Mascara_2_Reales(Trim(tbl.Rows(0).Item("RESODEPA"))), String)
                Me.txtREACMUNI.Text = CType(fun_Formato_Mascara_3_Reales(Trim(tbl.Rows(0).Item("RESOMUNI"))), String)
                Me.txtREACTIRE.Text = CType(fun_Formato_Mascara_3_Reales(Trim(tbl.Rows(0).Item("RESOTIRE"))), String)
                Me.txtREACCLSE.Text = Trim(tbl.Rows(0).Item("RESOCLSE"))
                Me.txtREACVIGE.Text = CType(fun_Formato_Mascara_4_Reales(Trim(tbl.Rows(0).Item("RESOVIGE"))), String)
                Me.txtREACRESO.Text = CType(fun_Formato_Mascara_7_Reales(Trim(tbl.Rows(0).Item("RESOCODI"))), String)
                Me.lblREACRESO.Text = Trim(tbl.Rows(0).Item("RESODESC"))

                ' coloca la lista de valores
                Me.lblREACDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Trim(Me.txtREACDEPA.Text)), String)
                Me.lblREACMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Trim(Me.txtREACDEPA.Text), Trim(Me.txtREACMUNI.Text)), String)
                Me.lblREACTIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO(Trim(Me.txtREACTIRE.Text)), String)
                Me.lblREACCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(Me.txtREACCLSE.Text)), String)
                Me.lblREACVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Trim(Me.txtREACVIGE.Text)), String)

                Me.cmdAbrirArchivoResolucionActualizacion.Enabled = True
                Me.cmdAbrirArchivoResolucionActualizacion.Focus()
            Else
                Me.cmdAbrirArchivoResolucionActualizacion.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSeleccionResolucionAdministrativa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeleccionResolucionAdministrativa.Click

        Try
            ' seleccina ninguna resolución
            vp_inConsulta = 0

            ' llama el formulario de consulta
            Dim frm_RESOADMI As New frm_consultar_RESOADMI_PUBLICA
            frm_RESOADMI.ShowDialog()

            ' verifica si hay alguna seleccionada
            If vp_inConsulta <> 0 Then

                Dim objdatos As New cla_RESOADMI
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_RESOADMI(vp_inConsulta)

                ' coloca los valores en los campos
                Me.txtREADDEPA.Text = ""
                Me.txtREADMUNI.Text = ""
                Me.txtREADTIRE.Text = CStr(fun_Formato_Mascara_3_Reales(Trim(tbl.Rows(0).Item("READTIRE"))))
                Me.txtREADCLSE.Text = CInt(tbl.Rows(0).Item("READCLSE"))
                Me.txtREADVIGE.Text = CStr(fun_Formato_Mascara_4_Reales(Trim(tbl.Rows(0).Item("READVIRE"))))
                Me.txtREADRESO.Text = CStr(fun_Formato_Mascara_7_Reales(Trim(tbl.Rows(0).Item("READNURE"))))

                ' coloca la lista de valores
                Me.lblREADTIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO(Trim(Me.txtREADTIRE.Text)), String)
                Me.lblREADCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(Me.txtREADCLSE.Text)), String)
                Me.lblREADVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Trim(Me.txtREADVIGE.Text)), String)

                Me.cmdAbrirArchivoResolucionAdministrativa.Enabled = True
                Me.cmdAbrirArchivoResolucionAdministrativa.Focus()
            Else
                Me.cmdAbrirArchivoResolucionAdministrativa.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "CheckedChanged"

    Private Sub chkSobrescribirBDexistente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSobrescribirBDexistenteResolucionActualizacion.CheckedChanged, chkSobrescribirBDexistenteResolucionAdministrativa.CheckedChanged

        If Me.chkSobrescribirBDexistenteResolucionActualizacion.Checked = False And Me.rbdFichaPredialResolucionActualizacion.Checked = True Then

            Me.rbdActualizarInsertarPrediosResolucionActualizacion.Enabled = True
            Me.rbdInsertaPrediosNuevosResolucionActualizacion.Enabled = True

            Me.rbdActualizarInsertarPrediosResolucionActualizacion.Checked = True
            Me.rbdInsertaPrediosNuevosResolucionActualizacion.Checked = False

            Me.rbdActualizarInsertarPrediosResolucionActualizacion.Visible = True
            Me.rbdInsertaPrediosNuevosResolucionActualizacion.Visible = True
        Else
            Me.rbdActualizarInsertarPrediosResolucionActualizacion.Enabled = False
            Me.rbdInsertaPrediosNuevosResolucionActualizacion.Enabled = False

            Me.rbdActualizarInsertarPrediosResolucionActualizacion.Visible = False
            Me.rbdInsertaPrediosNuevosResolucionActualizacion.Visible = False

            Me.rbdActualizarInsertarPrediosResolucionActualizacion.Checked = False
            Me.rbdInsertaPrediosNuevosResolucionActualizacion.Checked = False

            Me.fraTablasResolucionActualizacion.Visible = False
        End If

        If Me.chkSobrescribirBDexistenteResolucionAdministrativa.Checked = False And Me.rbdFichaPredialResolucionAdministrativa.Checked = True Then

            Me.rbdActualizarInsertarPrediosResolucionAdministrativa.Enabled = True
            Me.rbdInsertaPrediosNuevosResolucionAdministrativa.Enabled = True

            Me.rbdActualizarInsertarPrediosResolucionAdministrativa.Checked = True
            Me.rbdInsertaPrediosNuevosResolucionAdministrativa.Checked = False

            Me.rbdActualizarInsertarPrediosResolucionAdministrativa.Visible = True
            Me.rbdInsertaPrediosNuevosResolucionAdministrativa.Visible = True
        Else
            Me.rbdActualizarInsertarPrediosResolucionAdministrativa.Enabled = False
            Me.rbdInsertaPrediosNuevosResolucionAdministrativa.Enabled = False

            Me.rbdActualizarInsertarPrediosResolucionAdministrativa.Visible = False
            Me.rbdInsertaPrediosNuevosResolucionAdministrativa.Visible = False

            Me.rbdActualizarInsertarPrediosResolucionAdministrativa.Checked = False
            Me.rbdInsertaPrediosNuevosResolucionAdministrativa.Checked = False

            Me.fraTablasResolucionAdminsitrativa.Visible = False
        End If

    End Sub
    Private Sub rbdActualizarInsertarPredios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdActualizarInsertarPrediosResolucionActualizacion.CheckedChanged

        If Me.rbdActualizarInsertarPrediosResolucionActualizacion.Checked = True Then
            Me.fraTablasResolucionActualizacion.Visible = True
            Me.chkInactivasFichasResolucionActualizacion.Visible = True
        Else
            Me.fraTablasResolucionActualizacion.Visible = False
            Me.chkInactivasFichasResolucionActualizacion.Checked = False
            Me.chkInactivasFichasResolucionActualizacion.Visible = False
        End If

    End Sub
    Private Sub rbdInsertaPrediosNuevos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdInsertaPrediosNuevosResolucionActualizacion.CheckedChanged

        If Me.rbdInsertaPrediosNuevosResolucionActualizacion.Checked = True Then
            Me.fraTablasResolucionActualizacion.Visible = False
        Else
            Me.fraTablasResolucionActualizacion.Visible = True
        End If

    End Sub

#End Region

#End Region

End Class